using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using ACMS.Utils;

namespace ACMSLogic.Staff
{
	/// <summary>
	/// Summary description for ReceipientGroup.
	/// </summary>
	public class ReceipientGroup
	{
		public ReceipientGroup()
		{
		}

		public DataTable ViewReceipientGroup(int nEmployeeID)
		{
			return SqlHelperUtils.ExecuteDataTableSP("pr_tblMemoGroup_SelectAllWnEmployeeID", 
				new SqlParameter("@inEmployeeID", nEmployeeID));
		}

		public void NewReceipientGroup(string strMemoGroupCode, string strDescription, int nEmployeeID)
		{
			SqlHelperUtils.ExecuteNonQuerySP("pr_tblMemoGroup_InsertReceipientGroup", 
				new SqlParameter("@sstrMemoGroupCode", strMemoGroupCode),
				new SqlParameter("@sstrDescription", strDescription),
				new SqlParameter("@inEmployeeID", nEmployeeID));
		}

		public void UpdateNewReceipientGroup(string strMemoGroupCode, string strDescription, int nMemoGroupID)
		{
			SqlHelperUtils.ExecuteNonQuerySP("pr_tblMemoGroup_Update",
				new SqlParameter("@inMemoGroupID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, nMemoGroupID),
				new SqlParameter("@sstrMemoGroupCode", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, strMemoGroupCode),
				new SqlParameter("@sstrDescription", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, strDescription));
		}

		public bool DeleteReceipientGroup(int nMemoGroupID)
		{
			try
			{
				SqlHelperUtils.ExecuteNonQuerySP("pr_tblMemoGroup_Delete", new SqlParameter("@inMemoGroupID", nMemoGroupID));
			}
			catch
			{
				throw;
			}
			return true;
		}

		public DataTable ViewReceipientGroupEntries(int nMemoGroupID)
		{
			return SqlHelperUtils.ExecuteDataTableSP("pr_tblMemoGroupEntries_SelectAllWnMemoGroupID",
				new SqlParameter("@inMemoGroupID", nMemoGroupID));
		}

		public bool NewReceipientGroupEntries(int nMemoGroupID, int nEmployeeID)
		{
			try
			{
				SqlHelperUtils.ExecuteNonQuerySP("sp_tblMemoGroupEntries_Insert",
					new SqlParameter("@inMemoGroupID", nMemoGroupID),
					new SqlParameter("@inEmployeeID", nEmployeeID),
					SqlHelperUtils.paramErrorCode);
			}
			catch (SqlException ex)
			{
				if (ex.Message.IndexOf("PK_tblMemoGroupEntries") >= 0)
				{
					UI.ShowErrorMessage("Please don't insert duplicate employee.");
					return false;
				}
				else
					throw;
			}
			return true;
		}

		public bool DeleteReceipientGroupEntries(int nMemoGroupID, int nEmployeeID)
		{
			try
			{
				SqlHelperUtils.ExecuteNonQuerySP("pr_tblMemoGroupEntries_Delete", new SqlParameter("@inMemoGroupID", nMemoGroupID),
					new SqlParameter("@inEmployeeID", nEmployeeID));
			}
			catch
			{
				throw;
			}
			return true;
		}
	}
}
