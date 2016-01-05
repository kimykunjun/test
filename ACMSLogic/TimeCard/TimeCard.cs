using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using ACMS.Utils;

namespace ACMSLogic.TimeCard
{
	/// <summary>
	/// Summary description for TimeCard.
	/// </summary>
	public class TimeCard
	{
		private string cmdtxtTblTimeCardInit = "SELECT * FROM tblTimeCard WHERE (1 = 0)";
		private string cmdtxtTblTimeCardSave = "SELECT * FROM tblTimeCard";

		public TimeCard()
		{
		}

		public bool ValidatePassword(int nEmployeeID, string password)
		{
			try
			{
				SqlParameter param1 = new SqlParameter("nEmployeeID", nEmployeeID);
				SqlParameter param2 = new SqlParameter("strPassword", password);
				int count = (int)SqlHelper.ExecuteScalar(SqlHelperUtils.connectionString, "pr_tblEmployee_ValidatePassword", param1, param2);
				if (count > 0)
					return true;
				else
					return false;
			}
			catch (Exception ex)
			{
				UI.ShowErrorMessage(null, ex.Message, "Error");
				return false;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="nEmployeeID"></param>
		/// <param name="strBranchCode"></param>
		/// <returns>true is out, false is in</returns>
		public bool IsPunchIn(int nEmployeeID, string strBranchCode)
		{
			SqlParameter param1 = new SqlParameter("@dadtDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, 
				"", DataRowVersion.Proposed, DateTime.Today);
			SqlParameter param2 = new SqlParameter("@sstrBranchCode", strBranchCode);
			SqlParameter param3 = new SqlParameter("@inEmployeeID", nEmployeeID);
				
			int count = (int)SqlHelper.ExecuteScalar(SqlHelperUtils.connectionString, "pr_tblTimeCard_SelectCount", param1, 
				param2, param3);
			if ((count % 2) == 0)
				return true;
			else
				return false;
		}

		/// <summary>
		/// Save Time Card
		/// </summary>
		/// <param name="ds"></param>
		/// <returns>true is In, false is out</returns>
		public bool SaveTimeCard(string strBranchCode, int nEmployeeID)
		{
			DataSet ds = SqlHelperUtils.ExecuteDatasetText(cmdtxtTblTimeCardInit);
			ds.Tables[0].Clear();
			DataRow newRow = ds.Tables[0].NewRow();
			newRow.BeginEdit();
			newRow["strBranchCode"] = strBranchCode;
			newRow["nEmployeeID"] = nEmployeeID;
			newRow["dtDate"] = DateTime.Today;
			newRow["dtTime"] = DateTime.Now;
			newRow.EndEdit();
			ds.Tables[0].Rows.Add(newRow);
		
			SqlHelperUtils.UpdateDataSetSingleTableWithTransaction(ds, cmdtxtTblTimeCardSave);
			return IsPunchIn(nEmployeeID, strBranchCode);
		}
	}
}
