using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using ACMS.Utils;

namespace ACMSLogic.Staff
{
	/// <summary>
	/// Summary description for Memo.
	/// </summary>
	public class Memo
	{
		public const string PRINTMEMOTABLENAME = "Memo";
		public const string PRINTRECIPIENTTABLENAME = "Recipient";
		public const string PRINTREPLIESTABLENAME = "Replies";

		public Memo()
		{
		}

		public DataTable ViewMemo(int nEmployeeID, ViewMemoType aType)
		{
			DataTable dtblMessage;
			SqlParameter param1 = new SqlParameter("@nEmployeeID", nEmployeeID);
			if (aType == ViewMemoType.All)
			{
				dtblMessage = SqlHelperUtils.ExecuteDataTableSP("pr_tblMemo_SelectAllBynEmployeeID", param1);
			}
			else if (aType == ViewMemoType.BranchBulletin)
			{
				dtblMessage = SqlHelperUtils.ExecuteDataTableSP("pr_tblMemo_SelectBranchBulletinBynEmployeeID", param1);
			}
			else if (aType == ViewMemoType.PersonalMail)
			{
				dtblMessage = SqlHelperUtils.ExecuteDataTableSP("pr_tblMemo_SelectPersonalMailBynEmployeeID", param1);
			}
			else
			{
				dtblMessage = SqlHelperUtils.ExecuteDataTableSP("pr_tblMemo_SelectSentMailBynEmployeeID", param1);
			}
			return dtblMessage;
		}

		public DataTable GetPersonalGroupLookupEdit(int nEmployeeID)
		{
			return SqlHelper.ExecuteDataset(SqlHelperUtils.connectionString, "pr_tblMemoGroup_SelectAllWGroupRecepient", 
				new SqlParameter("@inEmployeeID", nEmployeeID)).Tables[0];
		}

		public DataTable GetDepartmentGroupLookupEdit()
		{
			return SqlHelper.ExecuteDataset(SqlHelperUtils.connectionString, "pr_tblMemoGroup_SelectAllWDepartmentRecepient").Tables[0];
		}

		public DataTable GetBranchLookupEdit()
		{
			return SqlHelper.ExecuteDataset(SqlHelperUtils.connectionString, "pr_tblBranch_LookupEdit",
				SqlHelperUtils.paramErrorCode).Tables[0];
		}

		public DataTable GetEmployeeLookupEditForMemoGroup()
		{
			return SqlHelper.ExecuteDataset(SqlHelperUtils.connectionString, "pr_tblEmployee_LookupEditForMemoGroup").Tables[0];
		}

		public void InitNewReceipient(out DataTable dtBranch, out DataTable dtDepartment, out DataTable dtGroup, out DataTable dtEmployee)
		{
			dtEmployee = new DataTable();
			dtEmployee.Columns.Add(new DataColumn("nEmployeeID", typeof(int)));
			dtEmployee.Columns.Add(new DataColumn("strEmployeeName", typeof(string)));

			DataTable myTable = new DataTable();
			myTable.Columns.Add(new DataColumn("nMemoGroupID", typeof(int)));
			myTable.Columns.Add(new DataColumn("strMemoGroupCode", typeof(string)));
			myTable.Columns.Add(new DataColumn("strDescription", typeof(string)));
			dtDepartment = myTable;
			dtGroup = myTable.Copy();

			dtBranch = new DataTable();
			dtBranch.Columns.Add(new DataColumn("strBranchCode", typeof(string)));
			dtBranch.Columns.Add(new DataColumn("strBranchName", typeof(string)));
			dtBranch.Columns.Add(new DataColumn("nMembershipNo", typeof(int)));
		}

        public bool SaveNewMemo(string strTitle, string strMessage, string strImgPath, string strFilePath1, string strFilePath2, string strFilePath3, int nEmployeeID, MemoStatusID aMemoStatus, DataTable dtBranch,
			DataTable dtDepartment, DataTable dtGroup, DataTable dtEmployee)
		{
			SqlConnection con = new SqlConnection(SqlHelperUtils.connectionString);
			SqlTransaction tran = null;
			SqlParameter paramErrorCode = new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, new Int32());

			try
			{
				con.Open();
				tran = con.BeginTransaction();
				int nMemoID = 0;
				nMemoID = (int)SqlHelper.ExecuteScalar(tran, "pr_tblMemo_Insert", new SqlParameter("@sstrTitle", strTitle),
                    new SqlParameter("@sstrMessage", strMessage), new SqlParameter("@sstrImgPath", strImgPath), new SqlParameter("@sstrFilePath1", strFilePath1), new SqlParameter("@sstrFilePath2", strFilePath2), new SqlParameter("@sstrFilePath3", strFilePath3), new SqlParameter("@inEmployeeID", nEmployeeID),
					new SqlParameter("@inStatusID", ((int)aMemoStatus)));

				foreach (DataRow row in dtBranch.Select())
				{
					SqlHelper.ExecuteNonQuery(tran, "sp_tblMemoBranch_Insert", new SqlParameter("@inMemoID", nMemoID),
						new SqlParameter("@sstrBranchCode", row["strBranchCode"].ToString()), paramErrorCode);
				}
				foreach (DataRow row in dtDepartment.Select())
				{
					SqlHelper.ExecuteNonQuery(tran, "sp_tblMemoReceipient_Insert", 
						new SqlParameter("@inTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, 1), 
						new SqlParameter("@inReceipientID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, Convert.ToInt32(row["nMemoGroupID"])), 
						new SqlParameter("@inMemoID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, nMemoID),
						paramErrorCode);
				}
				foreach (DataRow row in dtGroup.Select())
				{
					SqlHelper.ExecuteNonQuery(tran, "sp_tblMemoReceipient_Insert", 
						new SqlParameter("@inTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, 1), 
						new SqlParameter("@inReceipientID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, Convert.ToInt32(row["nMemoGroupID"])), 
						new SqlParameter("@inMemoID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, nMemoID),
						paramErrorCode);
				}
				foreach (DataRow row in dtEmployee.Select())
				{
					SqlHelper.ExecuteNonQuery(tran, "sp_tblMemoReceipient_Insert",
						new SqlParameter("@inTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, 0), 
						new SqlParameter("@inReceipientID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, Convert.ToInt32(row["nEmployeeID"])), 
						new SqlParameter("@inMemoID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, nMemoID),
						paramErrorCode);
				}

				tran.Commit();
				return true;
			}
			catch//(Exception ex)
			{
				if (tran != null)
					tran.Rollback();
				throw;
			}
			finally
			{
				con.Close();
				con.Dispose();
			}
		}

        public bool UpdateMessage(int nMemoID, string strMessage, string strImgPath, string strFilePath1, string strFilePath2, string strFilePath3)
		{
			SqlConnection con = new SqlConnection(SqlHelperUtils.connectionString);
			SqlTransaction tran = null;

			try
			{
				con.Open();
				tran = con.BeginTransaction();
				SqlHelper.ExecuteNonQuery(tran, "pr_tblMemo_UpdateMessage", new SqlParameter("@inMemoID", nMemoID),
                    new SqlParameter("@sstrMessage", strMessage), new SqlParameter("@sstrImgPath", strImgPath), new SqlParameter("@sstrFilePath1", strFilePath1), new SqlParameter("@sstrFilePath2", strFilePath2), new SqlParameter("@sstrFilePath3", strFilePath3));
				SqlHelper.ExecuteNonQuery(tran, "sp_tblMemoRead_DeleteWnMemoIDLogic", new SqlParameter("@inMemoID", nMemoID),
					new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, new Int32()));
				tran.Commit();
				return true;
			}
			catch//(Exception ex)
			{
				if (tran != null)
					tran.Rollback();
				throw;
			}
			finally
			{
				con.Close();
				con.Dispose();
			}
		}

		public bool ReadMessage(int nMemoID, int nEmployeeID)
		{
			SqlConnection con = new SqlConnection(SqlHelperUtils.connectionString);

			try
			{
				con.Open();
				SqlHelper.ExecuteNonQuery(con, "pr_tblMemoRead_Insert", new SqlParameter("@inMemoID", nMemoID),
					new SqlParameter("@@inEmployeeID", nEmployeeID));
				return true;
			}
			catch//(Exception ex)
			{
				throw;
				//return false;
			}
			finally
			{
				con.Close();
				con.Dispose();
			}
		}

		public bool UnpostMessage(int nMemoID)
		{
			SqlConnection con = new SqlConnection(SqlHelperUtils.connectionString);
			SqlTransaction tran = null;

			try
			{
				con.Open();
				tran = con.BeginTransaction();
				SqlHelper.ExecuteNonQuery(tran, "pr_tblMemo_UnpostMessage", new SqlParameter("@inMemoID", nMemoID));
				tran.Commit();
				return true;
			}
			catch//(Exception ex)
			{
				if (tran != null)
					tran.Rollback();
				throw;
			}
			finally
			{
				con.Close();
				con.Dispose();
			}
		}

		public DataTable ViewReply(int nMemoID)
		{
			SqlConnection con = new SqlConnection(SqlHelperUtils.connectionString);
			DataSet ds = new DataSet();

			try
			{
				con.Open();
				ds = SqlHelper.ExecuteDataset(con, "pr_tblMemoBulletin_SelectAllWnMemoIDLogic", 
					new SqlParameter("@inMemoID", nMemoID));
			}
			finally
			{
				con.Close();
				con.Dispose();
			}

			return ds.Tables[0];
		}

		public DataTable GetReply(int nBulletinID)
		{
			SqlConnection con = new SqlConnection(SqlHelperUtils.connectionString);
			DataSet ds = new DataSet();

			try
			{
				con.Open();
				ds = SqlHelper.ExecuteDataset(con, "sp_tblMemoBulletin_SelectOne", new SqlParameter("@inBulletinID", nBulletinID),
					new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, new Int32()));
			}
			catch//(Exception ex)
			{
				throw;
			}
			finally
			{
				con.Close();
				con.Dispose();
			}

			return ds.Tables[0];
		}

		public bool SaveNewReply(int nMemoID, int nEmployeeID, string strMessage)
		{
			SqlConnection con = new SqlConnection(SqlHelperUtils.connectionString);
			SqlTransaction tran = null;

			try
			{
				con.Open();
				tran = con.BeginTransaction();
				SqlHelper.ExecuteNonQuery(tran, "pr_tblMemoBulletin_Insert", new SqlParameter("@inMemoID", nMemoID), 
					new SqlParameter("@@inEmployeeID", nEmployeeID), new SqlParameter("@sstrMessage", strMessage));
				SqlHelper.ExecuteNonQuery(tran, "pr_tblMemo_UpdateLastEditDate", new SqlParameter("@inMemoID", nMemoID));
				SqlHelper.ExecuteNonQuery(tran, "sp_tblMemoRead_DeleteWnMemoIDLogic", new SqlParameter("@inMemoID", nMemoID),
					new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, new Int32()));
				tran.Commit();
				return true;
			}
			catch//(Exception ex)
			{
				if (tran != null)
					tran.Rollback();
				throw;
			}
			finally
			{
				con.Close();
				con.Dispose();
			}
		}

		public bool UpdateReply(int nBulletionID, int nMemoID, string strMessage)
		{
			SqlConnection con = new SqlConnection(SqlHelperUtils.connectionString);
			SqlTransaction tran = null;

			try
			{
				con.Open();
				tran = con.BeginTransaction();
				SqlHelper.ExecuteNonQuery(tran, "pr_tblMemoBulletin_Update", new SqlParameter("@inBulletinID", nBulletionID),
					new SqlParameter("@sstrMessage", strMessage));
				SqlHelper.ExecuteNonQuery(tran, "pr_tblMemo_UpdateLastEditDate", new SqlParameter("@inMemoID", nMemoID));
				SqlHelper.ExecuteNonQuery(tran, "sp_tblMemoRead_DeleteWnMemoIDLogic", new SqlParameter("@inMemoID", nMemoID),
					new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, new Int32()));
				tran.Commit();
				return true;
			}
			catch//(Exception ex)
			{
				if (tran != null)
					tran.Rollback();
				throw;
			}
			finally
			{
				con.Close();
				con.Dispose();
			}
		}

		public bool DeleteReply(int nBulletinID)
		{
			SqlConnection con = new SqlConnection(SqlHelperUtils.connectionString);

			try
			{
				con.Open();
				SqlHelper.ExecuteNonQuery(con, "sp_tblMemoBulletin_Delete", new SqlParameter("@inBulletinID", nBulletinID),
					new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, new Int32()));
				return true;
			}
			catch//(Exception ex)
			{
				throw;
				//return false;
			}
			finally
			{
				con.Close();
				con.Dispose();
			}
		}

		public DataTable ViewRecipient(int nMemoID, ReceipientType aReceipientType)
		{
			SqlConnection con = new SqlConnection(SqlHelperUtils.connectionString);
			DataSet ds = new DataSet();

			try
			{
				con.Open();
				if (aReceipientType == ReceipientType.BranchGroup)
				{
					ds = SqlHelper.ExecuteDataset(con, "pr_tblMemo_SelectReceipientByBranchGroup", 
						new SqlParameter("@inMemoID", nMemoID));
				}
				else if (aReceipientType == ReceipientType.DepartmentGroup)
				{
					ds = SqlHelper.ExecuteDataset(con, "pr_tblMemo_SelectReceipientByDepartmentGroup", 
						new SqlParameter("@inMemoID", nMemoID));
				}
				else if (aReceipientType == ReceipientType.Employee)
				{
					ds = SqlHelper.ExecuteDataset(con, "pr_tblMemo_SelectReceipientByEmployee", 
						new SqlParameter("@inMemoID", nMemoID));
				}
				else
				{
					ds = SqlHelper.ExecuteDataset(con, "pr_tblMemo_SelectReceipientByPersonalGroup", 
						new SqlParameter("@inMemoID", nMemoID));
				}
			}
			catch//(Exception ex)
			{
				throw;
			}
			finally
			{
				con.Close();
				con.Dispose();
			}

			return ds.Tables[0];
		}

		public bool AddReceipient(int nMemoID, DataTable dtBranch, DataTable dtDepartment, DataTable dtGroup, DataTable dtEmployee)
		{
			SqlConnection con = new SqlConnection(SqlHelperUtils.connectionString);
			SqlTransaction tran = null;
			SqlParameter paramErrorCode = new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, new Int32());

			try
			{
				con.Open();
				tran = con.BeginTransaction();

				foreach (DataRow row in dtBranch.Select())
				{
					SqlHelper.ExecuteNonQuery(tran, "sp_tblMemoBranch_Insert", new SqlParameter("@inMemoID", nMemoID),
						new SqlParameter("@sstrBranchCode", row["strBranchCode"].ToString()), paramErrorCode);
				}
				foreach (DataRow row in dtDepartment.Select())
				{
					SqlHelper.ExecuteNonQuery(tran, "sp_tblMemoReceipient_Insert", 
						new SqlParameter("@inTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, 1), 
						new SqlParameter("@inReceipientID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, Convert.ToInt32(row["nMemoGroupID"])), 
						new SqlParameter("@inMemoID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, nMemoID),
						paramErrorCode);
				}
				foreach (DataRow row in dtGroup.Select())
				{
					SqlHelper.ExecuteNonQuery(tran, "sp_tblMemoReceipient_Insert", 
						new SqlParameter("@inTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, 1), 
						new SqlParameter("@inReceipientID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, Convert.ToInt32(row["nMemoGroupID"])), 
						new SqlParameter("@inMemoID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, nMemoID),
						paramErrorCode);
				}
				foreach (DataRow row in dtEmployee.Select())
				{
					SqlHelper.ExecuteNonQuery(tran, "sp_tblMemoReceipient_Insert",
						new SqlParameter("@inTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, 0), 
						new SqlParameter("@inReceipientID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, Convert.ToInt32(row["nEmployeeID"])), 
						new SqlParameter("@inMemoID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, nMemoID),
						paramErrorCode);
				}

				tran.Commit();
				return true;
			}
			catch(Exception ex)
			{
				if (tran != null)
					tran.Rollback();
				if (((SqlException)ex).Number == 2627)
					throw new Exception("Please don't enter receipient that already inside receipient list.", ex);
				else 
					throw;
			}
			finally
			{
				con.Close();
				con.Dispose();
			}
		}

		public bool DeleteReceipient(int nTypeID, string strReceipientID, int nMemoID)
		{
			SqlConnection con = new SqlConnection(SqlHelperUtils.connectionString);
			SqlTransaction tran = null;
			// tblMemoBranch
			if (nTypeID == 2)
			{
				try
				{
					con.Open();
					tran = con.BeginTransaction();
					SqlHelper.ExecuteNonQuery(tran, "pr_tblMemoBranch_DeleteReceipient", 
						new SqlParameter("@inMemoID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, nMemoID),
						new SqlParameter("@sstrBranchCode", strReceipientID));
					tran.Commit();
					return true;
				}
				catch// (Exception ex)
				{
					if (tran != null)
						tran.Rollback();
					throw;
				}
				finally
				{
					con.Close();
					con.Dispose();
				}
			}
			else
			{
				try
				{
					con.Open();
					tran = con.BeginTransaction();
					SqlHelper.ExecuteNonQuery(tran, "pr_tblMemoReceipient_DeleteReceipient",
						new SqlParameter("@inTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, nTypeID), 
						new SqlParameter("@inReceipientID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, Convert.ToInt32(strReceipientID)), 
						new SqlParameter("@inMemoID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, nMemoID));
					tran.Commit();
					return true;
				}
				catch //(Exception ex)
				{
					if (tran != null)
						tran.Rollback();
					throw;
				}
				finally
				{
					con.Close();
					con.Dispose();
				}
			}
		}

		public DataSet PrintMemo(int nMemoID)
		{
			DataSet myDataSet = SqlHelperUtils.ExecuteDatasetSP("pr_MemoPrint", new SqlParameter("@inMemoID", nMemoID));
			myDataSet.Tables[0].TableName = PRINTMEMOTABLENAME;
			myDataSet.Tables[1].TableName = PRINTRECIPIENTTABLENAME;
			myDataSet.Tables[2].TableName = PRINTREPLIESTABLENAME;

			myDataSet.Relations.Add("MemoRecipient", myDataSet.Tables[PRINTMEMOTABLENAME].Columns["nMemoID"],
				myDataSet.Tables[PRINTRECIPIENTTABLENAME].Columns["nMemoID"], true);
			myDataSet.Relations.Add("MemoReplies", myDataSet.Tables[PRINTMEMOTABLENAME].Columns["nMemoID"],
				myDataSet.Tables[PRINTREPLIESTABLENAME].Columns["nMemoID"], true);

			return myDataSet;
		}
	}

	public enum ViewMemoType
	{
		All,
		PersonalMail,
		BranchBulletin,
		SentMemo
	}

	public enum ReceipientType
	{
		BranchGroup,
		DepartmentGroup,
		PersonalGroup,
		Employee
	}

	public enum MemoStatusID
	{
		Active,
		Deleted,
		Draft
	}

	public enum MemoReceipientType
	{
		Individual,
		Group
	}

	public enum MemoReplyAction
	{
		Add,
		View,
		Update
	}
}
