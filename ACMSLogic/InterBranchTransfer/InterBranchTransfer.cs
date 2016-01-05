using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using Acms.Core.Domain;
using ACMS.Utils;
using System.Configuration;

namespace ACMSLogic.InterBranchTransfer
{
	/// <summary>
	/// Summary description for InterBranchTransfer.
	/// </summary>
	public class InterBranchTransfer
	{
		public InterBranchTransfer()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public bool DeleteIBT(int nIBTNo,string strBranchCode)
		{
			SqlParameter param1 = new SqlParameter("nIBTNo", nIBTNo);
			SqlParameter param2 = new SqlParameter("strBranchCode", strBranchCode);
			
			try
			{
				int query = SqlHelper.ExecuteNonQuery(SqlHelperUtils.connectionString,"SP_DeleteIBT",param1,param2);
				
				if(query>0)
					return true;
			}
		
			catch(Exception err)
			{
				UI.ShowErrorMessage(null, err.Message, "Error");
				return false;
			}
			return false;
		}

		public DataTable GetIBTById(int nIBTNo)
		{
			SqlParameter param1 = new SqlParameter("nIBTNo", nIBTNo);
			try
			{
				DataSet ds = SqlHelper.ExecuteDataset(SqlHelperUtils.connectionString, "SP_GetIBTById",param1);
				if(ds!=null)
				{
					if(ds.Tables[0].Rows.Count>0)
					{
						return ds.Tables[0];
					}
				}
				return null;
			}
			catch(Exception err)
			{
				UI.ShowErrorMessage(null, err.Message, "Error");
				return null;
			}
		}


		public DataTable GetIBTDetail(int nIBTNo)
		{
			SqlParameter param1 = new SqlParameter("nIBTNo", nIBTNo);
			try
			{
				DataSet ds = SqlHelper.ExecuteDataset(SqlHelperUtils.connectionString, "SP_GetIBTDetail",param1);
				if(ds!=null)
				{
					if(ds.Tables[0].Rows.Count>0)
					{
						return ds.Tables[0];
					}
				}
				return null;
			}
			catch(Exception err)
			{
				UI.ShowErrorMessage(null, err.Message, "Error");
				return null;
			}
		}

		public bool UpdateIBTStatusAndProductInventory(int nIBTNo,int nStatusId,string wareHouseBranch,string strBranchCode,DateTime ReceiveDate)
		{
			SqlParameter param1 = new SqlParameter("nIBTNo", nIBTNo);
			SqlParameter param2 = new SqlParameter("nStatusId", nStatusId);
			SqlParameter param3 = new SqlParameter("wareHouseBranch", wareHouseBranch);
			SqlParameter param4 = new SqlParameter("strBranchCode", strBranchCode);
			SqlParameter param5 = new SqlParameter("dtDate", ReceiveDate);

			try
			{
				int updateRow = (int)SqlHelper.ExecuteNonQuery(SqlHelperUtils.connectionString,"SP_UpdateIBTStatusAndProductInventory",param1,param2,param3,param4,param5);
				
				if(updateRow>0)
					return true;
			}
		
			catch(Exception err)
			{
				UI.ShowErrorMessage(null, err.Message, "Error");
				return false;
			}
			return false;
		}

		public bool UpdateIBT(SqlTransaction trans,DateTime dtDate,string strBranchCodeFrom,string strBranchCodeTo,int nStatusID,int nEmployeeID,DateTime dtLastEditDate,string strRemarks,int nIBTNo)
		{
			SqlParameter param1 = new SqlParameter("dtDate", dtDate);
			SqlParameter param2 = new SqlParameter("strBranchCodeFrom", strBranchCodeFrom);
			SqlParameter param3 = new SqlParameter("strBranchCodeTo", strBranchCodeTo);
			SqlParameter param4 = new SqlParameter("nStatusID", nStatusID);
			SqlParameter param5 = new SqlParameter("nEmployeeID", nEmployeeID);
			SqlParameter param6 = new SqlParameter("dtLastEditDate", dtLastEditDate);
			SqlParameter param7 = new SqlParameter("strRemarks", strRemarks);
			SqlParameter param8 = new SqlParameter("nIBTNo", nIBTNo);

			try
			{
				int updateRow = (int)SqlHelper.ExecuteNonQuery(trans,"SP_UpdateIBT",param1,param2,param3,param4,param5,param6,param7,param8);
				
				if(updateRow>0)
					return true;
			}
		
			catch(Exception err)
			{
				UI.ShowErrorMessage(null, err.Message, "Error");
				return false;
			}
			return false;
		}

		public int SaveIBT(SqlTransaction trans,DateTime dtDate,string strBranchCodeFrom,string strBranchCodeTo,int nStatusID,int nEmployeeID,DateTime dtLastEditDate,string strRemarks)
		{
			SqlParameter param1 = new SqlParameter("dtDate", dtDate);
			SqlParameter param2 = new SqlParameter("strBranchCodeFrom", strBranchCodeFrom);
			SqlParameter param3 = new SqlParameter("strBranchCodeTo", strBranchCodeTo);
			SqlParameter param4 = new SqlParameter("nStatusID", nStatusID);
			SqlParameter param5 = new SqlParameter("nEmployeeID", nEmployeeID);
			SqlParameter param6 = new SqlParameter("dtLastEditDate", dtLastEditDate);
			SqlParameter param7 = new SqlParameter("strRemarks", strRemarks);
		

			try
			{
				int nIBTNo = (int)SqlHelper.ExecuteScalar(trans,"SP_SaveIBT",param1,param2,param3,param4,param5,param6,param7);
				
				if(nIBTNo>0)
					return nIBTNo;
			}
		
			catch(Exception err)
			{
				UI.ShowErrorMessage(null, err.Message, "Error");
				return 0;
			}
			return 0;
		}

		public bool DeleteIBTEntries(SqlTransaction trans,int nIBTNo, int nEntryID, string strBranchCode)
		{
			SqlParameter param1 = new SqlParameter("nIBTNo", nIBTNo);
			SqlParameter param2 = new SqlParameter("nEntryID", nEntryID);
			SqlParameter param3 = new SqlParameter("strBranchCode", strBranchCode);
				
			try
			{
				int rowDelete = (int)SqlHelper.ExecuteNonQuery(trans,"SP_DeleteIBTEntries",param1,param2,param3);
				
				if(rowDelete>0)
					return true;
			}
		
			catch(Exception err)
			{
				UI.ShowErrorMessage(null, err.Message, "Error");
				return false;
			}
			return false;
		
		}
		
		public bool UpdateIBTEntries(SqlTransaction trans,int nIBTNo,string strItemCode,int nQuantity,string strBranchCode,int nEntryID)
		{
			SqlParameter param1 = new SqlParameter("nIBTNo", nIBTNo);
			SqlParameter param2 = new SqlParameter("strItemCode", strItemCode);
			SqlParameter param3 = new SqlParameter("nQuantity", nQuantity);
			SqlParameter param4 = new SqlParameter("strBranchCode", strBranchCode);
			SqlParameter param5 = new SqlParameter("nEntryID", nEntryID);
			try
			{
				int rowUpdate = (int)SqlHelper.ExecuteNonQuery(trans,"SP_UpdateIBTEntries",param1,param2,param3,param4,param5);
				
				if(rowUpdate>0)
					return true;
			}
		
			catch(Exception err)
			{
				UI.ShowErrorMessage(null, err.Message, "Error");
				return false;
			}
			return false;
		}

		public bool SaveIBTEntries(SqlTransaction trans,int nIBTNo,string strItemCode,int nQuantity,string strBranchCode)
		{
			SqlParameter param1 = new SqlParameter("nIBTNo", nIBTNo);
			SqlParameter param2 = new SqlParameter("strItemCode", strItemCode);
			SqlParameter param3 = new SqlParameter("nQuantity", nQuantity);
			SqlParameter param4 = new SqlParameter("strBranchCode", strBranchCode);

			try
			{
				int rowInsert = (int)SqlHelper.ExecuteNonQuery(trans,"SP_SaveIBTEntries",param1,param2,param3,param4);
				
				if(rowInsert>0)
					return true;
			}
		
			catch(Exception err)
			{
				UI.ShowErrorMessage(null, err.Message, "Error");
				return false;
			}
			return false;
		}


		public DataSet FindIBTList(string type,string strBranchCode)
		{
			DataSet ds = null;
			SqlParameter param1 = new SqlParameter("type", type);
			SqlParameter param2 = new SqlParameter("strBranchCode", strBranchCode);
			
			try
			{
				ds = SqlHelper.ExecuteDataset(SqlHelperUtils.connectionString,"Sp_GetIBTList",param1,param2);
			}
			catch(Exception err)
			{
				UI.ShowErrorMessage(null, err.Message, "Error");
			}
			return ds;
		}

		public DataSet FindIBTDetailList(int nIBTNo)
		{
			DataSet ds = null;
			SqlParameter param1 = new SqlParameter("nIBTNo", nIBTNo);
			
			
			try
			{
				ds = SqlHelper.ExecuteDataset(SqlHelperUtils.connectionString,"Sp_GetIBTDetailList",param1);
			}
			catch(Exception err)
			{
				UI.ShowErrorMessage(null, err.Message, "Error");
			}
			return ds;
		}
	}
}
