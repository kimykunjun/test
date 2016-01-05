using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using ACMS.Utils;

namespace ACMSLogic.Staff
{
	/// <summary>
	/// Summary description for CV.
	/// </summary>
	public class CV
	{
		public const string PRINTCVTABLENAME = "CV";
		public const string PRINTCVACTIONTABLENAME = "CVACTION";
		private string cmdtxtTblCaseInit = "SELECT * FROM tblCase WHERE (1 = 0)";
		private string cmdtxtTblCaseSave = "SELECT * FROM tblCase";
		private string cmdtxtTblCaseActionInit = "SELECT * FROM tblCaseAction WHERE (1 = 0)";
		private string cmdtxtTblCaseActionSave = "SELECT * FROM tblCaseAction";
		private DataTable listCVTable;
		private DataSet newCVDataSet;

		public DataSet NewCVDataSet
		{
			get { return newCVDataSet; }
			set { newCVDataSet = value; }    
		}

		public DataTable ListCVTable
		{
			get { return listCVTable; }
			//set { listCVTable = value; }
		}

		public CV()
		{
			listCVTable = new DataTable();
			newCVDataSet = new DataSet();
		}

		public void ListCV(int nEmployeeID, object nSubmitter, object nAssignTo, CVStatusID aCVStatusID, bool isManager)
		{			
			SqlParameter paramEmp = new SqlParameter("@inEmployeeID", nEmployeeID);
			SqlParameter paramSum = new SqlParameter("@inSubmiterID", nSubmitter);
			SqlParameter paramAss = new SqlParameter("@inAssignToID", nAssignTo);
			if (aCVStatusID != CVStatusID.All)
			{
				SqlParameter paramCVStatus = new SqlParameter("@inStatusID", (int)aCVStatusID);
				if (nSubmitter == DBNull.Value && nAssignTo == DBNull.Value)
				{
					listCVTable = SqlHelperUtils.ExecuteDataTableSP("pr_tblCase_SelectCVBynEmployeeIDnStatusID", paramEmp, 
						paramCVStatus);
				}
				else if (nSubmitter == DBNull.Value && nAssignTo != DBNull.Value)
				{
					listCVTable = SqlHelperUtils.ExecuteDataTableSP("pr_tblCase_SelectCVBynAssignTonStatusID", paramAss,
						paramCVStatus);
				}
				else if (nSubmitter != DBNull.Value && nAssignTo == DBNull.Value)
				{
					if (!isManager)
					{
						listCVTable = SqlHelperUtils.ExecuteDataTableSP("pr_tblCase_SelectCVBynSubmiternStatusID", paramSum,
							paramCVStatus);
					}
					else
					{
						listCVTable = SqlHelperUtils.ExecuteDataTableSP("pr_tblCase_SelectCVBynSubmiternStatusIDManager", paramSum,
							paramCVStatus);
					}
				}
				else
				{
					if (!isManager)
					{
						listCVTable = SqlHelperUtils.ExecuteDataTableSP("pr_tblCase_SelectCVBynSubmiternAssignTonStatusID", 
							paramSum, paramAss, paramCVStatus);
					}
					else
					{
						listCVTable = SqlHelperUtils.ExecuteDataTableSP("pr_tblCase_SelectCVBynSubmiternAssignTonStatusIDManager", 
							paramSum, paramAss, paramCVStatus);
					}
				}
			}
			else
			{
				if (nSubmitter == DBNull.Value && nAssignTo == DBNull.Value)
					listCVTable = SqlHelperUtils.ExecuteDataTableSP("pr_tblCase_SelectAllCVBynEmployeeID", paramEmp);
				else if (nSubmitter == DBNull.Value && nAssignTo != DBNull.Value)
					listCVTable = SqlHelperUtils.ExecuteDataTableSP("pr_tblCase_SelectAllCVByAssignTo", paramAss);
				else if (nSubmitter != DBNull.Value && nAssignTo == DBNull.Value)
				{
					if (!isManager)
						listCVTable = SqlHelperUtils.ExecuteDataTableSP("pr_tblCase_SelectAllCVBySubmiter", paramSum);
					else
						listCVTable = SqlHelperUtils.ExecuteDataTableSP("pr_tblCase_SelectAllCVBySubmiterManager", paramSum);
				}
				else
				{
					if (!isManager)
					{
						listCVTable = SqlHelperUtils.ExecuteDataTableSP("pr_tblCase_SelectAllCVBySubmiterAssignTo", paramSum, 
							paramAss);
					}
					else
					{
						listCVTable = SqlHelperUtils.ExecuteDataTableSP("pr_tblCase_SelectAllCVBySubmiterAssignToManager", paramSum, 
							paramAss);
					}
				}
			}
		}

		public void LoadNewCV(string strBranchCode)
		{
			newCVDataSet = SqlHelperUtils.ExecuteDatasetText(cmdtxtTblCaseInit);
			newCVDataSet.Tables[0].Clear();
			DataRow newRow = newCVDataSet.Tables[0].NewRow();
			newRow.BeginEdit();
			newRow["dtDate"] = DateTime.Today;
			newRow["strBranchCode"] = strBranchCode;
			newRow["nDepartmentID"] = -1;
			newRow["nTypeID"] = -1;
			newRow["nCategoryID"] = -1;
			newRow["strMembershipID"] = "";
			newRow["nSubmittedByID"] = -1;
			newRow["nEmployeeID"] = -1;
			newRow.EndEdit();
			newCVDataSet.Tables[0].Rows.Add(newRow);
		}

		public DataSet LoadNewCVAction()
		{
			DataSet newCVAction = SqlHelperUtils.ExecuteDatasetText(cmdtxtTblCaseActionInit);
			newCVAction.Tables[0].Clear();
			DataRow newRow = newCVAction.Tables[0].NewRow();
			newRow.BeginEdit();
			newRow["nCaseID"] = -1;
			newRow["nModeID"] = -1;
			newRow["nActionByID"] = -1;
			newRow.EndEdit();
			newCVAction.Tables[0].Rows.Add(newRow);
			return newCVAction;
		}

		public bool SaveNewCV()
		{
			SqlHelperUtils.UpdateDataSetSingleTableWithTransaction(newCVDataSet, cmdtxtTblCaseSave);
			return true;
		}

		public bool SaveNewCVAction(DataSet dsTblCaseAction, int nCaseID, DataSet dsTblCase)
		{
			string cmdtxt = "SELECT * FROM tblCase WHERE nCaseID = '" 
				+SqlHelperUtils.ToSingleQuoteString(nCaseID.ToString()) +"'";
			SqlHelperUtils.UpdateDataSetTwoTableWithTransaction(dsTblCase, cmdtxt, dsTblCaseAction, cmdtxtTblCaseActionSave);
			return true;
		}

		public bool DeleteCV(int nCaseID)
		{
			SqlParameter param1 = new SqlParameter("@inCaseID", nCaseID);
			SqlParameter param2 = new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, new Int32());
			SqlHelper.ExecuteNonQuery(SqlHelperUtils.connectionString, "sp_tblCase_Delete", param1, param2);
			return true;
		}

		public bool DeleteFullCV(int nCaseID)
		{
			SqlConnection connection = null;
			string tblCaseDelete = "DELETE FROM tblCase WHERE nCaseID = @inCaseID";
			string tblCaseActionDelete = "DELETE FROM tblCaseAction WHERE nCaseID = @inCaseID";

			try
			{
				connection = new SqlConnection(SqlHelperUtils.connectionString);
				connection.Open();

				using (SqlTransaction trans = connection.BeginTransaction())
				{
					try
					{	
						SqlHelper.ExecuteNonQuery(trans, CommandType.Text, tblCaseActionDelete, 
							new SqlParameter("@inCaseID", nCaseID));

						SqlHelper.ExecuteNonQuery(trans, CommandType.Text, tblCaseDelete, new SqlParameter("@inCaseID", nCaseID));
						
						trans.Commit();					
					}
					catch
					{					
						trans.Rollback();
						throw;						
					}
				}
			}
			catch
			{
				throw;
			}
			finally
			{
				if(connection != null)
					connection.Dispose();
			}

			return true;
		}

		public bool AssignCV(int nDeparmentID, int nEmployeeID, int nCaseID)
		{
			SqlParameter param1 = new SqlParameter("@inDepartmentAssignedID", nDeparmentID);
			SqlParameter param2 = new SqlParameter("@inEmployeeID", nEmployeeID);
			SqlParameter param3 = new SqlParameter("@inCaseID", nCaseID);
			SqlHelper.ExecuteNonQuery(SqlHelperUtils.connectionString, "pr_tblCase_SetnDepartmentID", param1, param2, param3);
			return true;
		}

		public DataSet LoadCV(int nCaseID)
		{
			SqlParameter param1 = new SqlParameter("@inCaseID", nCaseID);
			SqlParameter param2 = new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, new Int32());
			DataSet ds = SqlHelper.ExecuteDataset(SqlHelperUtils.connectionString, "sp_tblCase_SelectOne", param1, param2);
			return ds;
		}

		public bool SaveCV(int nCaseID, DataSet ds)
		{
			string cmdtxt = "SELECT * FROM tblCase WHERE nCaseID = '" 
				+SqlHelperUtils.ToSingleQuoteString(nCaseID.ToString()) +"'";
			SqlHelperUtils.UpdateDataSetSingleTableWithTransaction(ds, cmdtxt);
			return true;
		}

		public DataSet LoadCVAction(int nCaseID)
		{
			SqlParameter param1 = new SqlParameter("@inCaseID", nCaseID);
			DataSet ds = SqlHelper.ExecuteDataset(SqlHelperUtils.connectionString, "pr_tblCaseAction_SelectBynActionID", param1);
			return ds;
		}

		public DataSet PrintCV(int nCaseID)
		{
			DataSet myDataSet = SqlHelperUtils.ExecuteDatasetSP("pr_CVPrint", new SqlParameter("@inCaseID", nCaseID));
			myDataSet.Tables[0].TableName = PRINTCVTABLENAME;
			myDataSet.Tables[1].TableName = PRINTCVACTIONTABLENAME;

			myDataSet.Relations.Add("MemoRecipient", myDataSet.Tables[PRINTCVTABLENAME].Columns["nCaseID"],
				myDataSet.Tables[PRINTCVACTIONTABLENAME].Columns["nCaseID"], true);

			return myDataSet;
		}
	}

	public enum CVStatusID
	{
		New,
		Pending,
		Closed,
		All
	}
}
