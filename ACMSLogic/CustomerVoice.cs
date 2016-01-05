using System;
using System.Data;
using System.Data.SqlClient;
using ACMSDAL;

namespace ACMSLogic
{
	/// <summary>
	/// Summary description for CustomerVoice.
	/// </summary>
	public class CustomerVoice
	{
		private TblCase myCase;
		private DataTable myDataTable;
		private TblCaseAction myCaseAction;
		
		public CustomerVoice()
		{
			//
			// TODO: Add constructor logic here
			//
			Init();
		}

		public DataTable Table
		{
			get { return myDataTable; }
		}

		public void Save(DataTable table)
		{
			myCase.SaveData(table);
		}
		
		public DataTable New()
		{
			myCase.NCaseID = -1;
			DataTable table = myCase.SelectOne();
			DataRow row = table.NewRow();
			row["dtDate"] = ACMS.Convert.ToDateTime(System.DateTime.Today);
			row["dtLastEditDate"] = ACMS.Convert.ToDateTime(System.DateTime.Today);
			row["nEmployeeID"] = ACMSLogic.User.EmployeeID;
			row["nStatusID"] = 0;
			row["nSubmittedByID"] = ACMSLogic.User.EmployeeID;
			row["strBranchCode"] = User.BranchCode; 
			table.Rows.Add(row);

			return table;
		}

		public DataTable Edit(int nCaseID)
		{
			myCase.NCaseID = nCaseID;
			DataTable table = myCase.SelectOne();
			return table;
		}

		public bool Delete(int nCaseID)
		{
			ACMSDAL.ConnectionProvider connProvider = new ConnectionProvider();

			try
			{
				myCase.MainConnectionProvider = connProvider;
				myCaseAction.MainConnectionProvider = connProvider;

				connProvider.OpenConnection();
				connProvider.BeginTransaction("CancelMemberPackage");

				myCase.NCaseID = nCaseID;
				myCaseAction.NCaseID = nCaseID;

				myCaseAction.DeleteAllWnCaseIDLogic();
				myCase.Delete();

				connProvider.CommitTransaction();
				return true;
			}
			catch (Exception)
			{
				connProvider.RollbackTransaction("DeleteCase");
				throw;
			}
			finally
			{
				if (connProvider.CurrentTransaction != null)
					connProvider.CurrentTransaction.Dispose();
				if (connProvider.DBConnection != null)
				{
					if (connProvider.DBConnection.State == ConnectionState.Open)
						connProvider.DBConnection.Close();
					//connProvider.DBConnection.Dispose();
				}
				myCase.MainConnactionIsCreatedLocal = true;
				myCaseAction.MainConnactionIsCreatedLocal = true;
			}
		}

		private void Init()
		{
			myCase = new TblCase();
			myCaseAction = new TblCaseAction();
		}

		public void Refresh(string strMemberShipID)
		{
			myDataTable = myCase.SelectCustomerVoiceWithMoreDetail(strMemberShipID); 
		}

		public DataTable GetActionTable(int nCaseID)
		{

			//myCaseAction.NCaseID = nCaseID;
			return myCaseAction.GetCustomerVoiceAction(nCaseID);
		}

		public DataTable NewAction(int nCaseID)
		{
			myCaseAction.NActionID = -1;
			DataTable table = myCaseAction.SelectOne();
			DataRow row = table.NewRow();

			row["nCaseID"] = nCaseID;
			row["dtDate"] = System.DateTime.Today;
			row["nActionByID"] = ACMSLogic.User.EmployeeID;
			table.Rows.Add(row);
			return table;
		}

		public void SaveAction(DataTable table)
		{
			myCaseAction.SaveData(table);
		}
	}
}
