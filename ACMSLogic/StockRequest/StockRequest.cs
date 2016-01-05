using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using Acms.Core.Domain;
using ACMS.Utils;
using System.Configuration;
namespace ACMSLogic.StockRequest
{
	/// <summary>
	/// Summary description for StockRequest.
	/// </summary>
	public class StockRequest
	{
		public StockRequest()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public bool DeleteStockRequest(int nStockRequestNo)
		{
			SqlParameter param1 = new SqlParameter("nStockRequestNo", nStockRequestNo);
			
			try
			{
				int query = SqlHelper.ExecuteNonQuery(SqlHelperUtils.connectionString,"SP_DeleteStockRequest",param1);
				
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

		public bool RejectStockRequest(int nStockRequestNo,int nStatusID,string strRemarks)
		{
			SqlParameter param1 = new SqlParameter("nStockRequestNo", nStockRequestNo);
			SqlParameter param2 = new SqlParameter("nStatusID", nStatusID);
			SqlParameter param3 = new SqlParameter("strRemarks", strRemarks);

			try
			{
				int query = SqlHelper.ExecuteNonQuery(SqlHelperUtils.connectionString,"SP_RejectStockRequest",param1,param2,param3);
				
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

		public DataTable GetListByDomainAndExcludeById(string strBranchCode)
		{
			SqlParameter param1 = new SqlParameter("strBranchCode", strBranchCode);
			try
			{
				DataSet ds = SqlHelper.ExecuteDataset(SqlHelperUtils.connectionString, "GetListByDomainAndExcludeById",param1);
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

		public DataTable GetProductByBranch(string strBranchCode)
		{
			SqlParameter param1 = new SqlParameter("strBranchCode", strBranchCode);
			try
			{
				DataSet ds = SqlHelper.ExecuteDataset(SqlHelperUtils.connectionString, "SP_GetProductByBranch",param1);
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

		public bool GetAvailableQuantity(string strItemCode,string strBranchCode,int nQuantity)
		{
			SqlParameter param1 = new SqlParameter("strItemCode", strItemCode);
			SqlParameter param2 = new SqlParameter("strBranchCode", strBranchCode);

			try
			{
				int availableQuantity = (int)SqlHelper.ExecuteScalar(SqlHelperUtils.connectionString,"SP_GetAvailableQuantity",param1,param2);
				
				if(availableQuantity>=nQuantity)
					return true;
			}
		
			catch(Exception err)
			{
				UI.ShowErrorMessage(null, err.Message, "Error");
				return false;
			}
			return false;
		}

		public DataTable GetStockRequestById(int nStockRequestNo)
		{
			SqlParameter param1 = new SqlParameter("nStockRequestNo", nStockRequestNo);
			try
			{
				DataSet ds = SqlHelper.ExecuteDataset(SqlHelperUtils.connectionString, "SP_GetStockRequestById",param1);
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

		public DataTable GetStockRequestEntriesById(int nStockRequestNo)
		{
			SqlParameter param1 = new SqlParameter("nStockRequestNo", nStockRequestNo);
			try
			{
				DataSet ds = SqlHelper.ExecuteDataset(SqlHelperUtils.connectionString, "SP_GetStockRequestEntriesById",param1);
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

		public bool UpdateStockRequestIBTNo(SqlTransaction trans,int nIBTNo,int nStockRequestNo)
		{
			SqlParameter param1 = new SqlParameter("nIBTNo", nIBTNo);
			SqlParameter param2 = new SqlParameter("nStockRequestNo", nStockRequestNo);

			try
			{
				int query = SqlHelper.ExecuteNonQuery(trans,"SP_UpdateStockRequestIBTNo",param1,param2);
				
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

		public bool ProcessStockRequestEntries(SqlTransaction trans,string strProductCode,int nQuantity,int nIBTNo,string strBranchCode,int nEntryId)
		{
			SqlParameter param1 = new SqlParameter("strProductCode", strProductCode);
			SqlParameter param2 = new SqlParameter("nQuantity", nQuantity);
			SqlParameter param3 = new SqlParameter("nIBTNo", nIBTNo);
			SqlParameter param4 = new SqlParameter("strBranchCode", strBranchCode);
			SqlParameter param5 = new SqlParameter("nEntryId", nEntryId);
			try
			{
				int query = SqlHelper.ExecuteNonQuery(trans,"SP_ProcessStockRequestEntries",param1,param2,param3,param4,param5);
				
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

		public int ProcessStockRequest(SqlTransaction trans,DateTime dtDate,int nStatusID,DateTime dtLastEditDate,string strRemarks,string strBranchCodeFrom,string strBranchCodeTo,int nEmployeeId)
		{
			SqlParameter param1 = new SqlParameter("dtDate", dtDate);
			SqlParameter param2 = new SqlParameter("nStatusID", nStatusID);
			SqlParameter param3 = new SqlParameter("dtLastEditDate", dtLastEditDate);
			SqlParameter param4 = new SqlParameter("strRemarks", strRemarks);
			SqlParameter param5 = new SqlParameter("strBranchCodeFrom", strBranchCodeFrom);
			SqlParameter param6 = new SqlParameter("strBranchCodeTo", strBranchCodeTo);
			SqlParameter param7 = new SqlParameter("nEmployeeId", nEmployeeId);
			//SqlParameter param8 = new SqlParameter("strProductCode", strProductCode);
			//SqlParameter param9 = new SqlParameter("nQuantity", nQuantity);

			try
			{
				int nIBTNo = (int)SqlHelper.ExecuteScalar(trans,"SP_ProcessStockRequest",param1,param2,param3,param4,param5,param6,param7);
				
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

		public DataSet FindStockRequestList(string type,string strBranchCode)
		{
			DataSet ds = null;
			SqlParameter param1 = new SqlParameter("type", type);
			SqlParameter param2 = new SqlParameter("strBranchCode", strBranchCode);
			
			try
			{
				ds = SqlHelper.ExecuteDataset(SqlHelperUtils.connectionString,"Sp_GetStockRequestList",param1,param2);
			}
			catch(Exception err)
			{
				UI.ShowErrorMessage(null, err.Message, "Error");
			}
			return ds;
		}

		public DataSet FindStockRequestEntryList(string stockRequestNo)
		{
			DataSet ds = null;
			SqlParameter param1 = new SqlParameter("stockRequestNo", stockRequestNo);

			
			try
			{
				ds = SqlHelper.ExecuteDataset(SqlHelperUtils.connectionString,"Sp_GetStockRequestEntryList",param1);
			}
			catch(Exception err)
			{
				UI.ShowErrorMessage(null, err.Message, "Error");
			}
			return ds;
		}

		public DataTable SearchProduct(string searchStyleCode,string searchProductCode,string searchProductDesc,string strBranchCode)
		{
			DataSet ds = null;
			SqlParameter param1 = new SqlParameter("searchStyle", searchStyleCode);
			SqlParameter param2 = new SqlParameter("searchProduct", searchProductCode);
			SqlParameter param3 = new SqlParameter("searchProductDesc", searchProductDesc);
			SqlParameter param4 = new SqlParameter("strBranchCode", strBranchCode);

			try
			{
				ds = SqlHelper.ExecuteDataset(SqlHelperUtils.connectionString,"Sp_GetSearchProduct",param1,param2,param3,param4);
			}
			catch(Exception err)
			{
				UI.ShowErrorMessage(null, err.Message, "Error");
			}
			if(ds.Tables[0].Rows.Count>0)
			{
				return ds.Tables[0];
			}
			else
			{
				return null;
			}
		}

		public bool EditStockRequest(SqlTransaction trans,DateTime dtDate,string strBranchCodeTo,int nEmployeeID,DateTime dtLastEditDate,int nStockRequestNo,string strRemarks)
		{
			SqlParameter param1 = new SqlParameter("dtDate", dtDate);
			SqlParameter param2 = new SqlParameter("strBranchCodeTo", strBranchCodeTo);
			SqlParameter param3 = new SqlParameter("nEmployeeID", nEmployeeID);
			SqlParameter param4 = new SqlParameter("dtLastEditDate", dtLastEditDate);
			SqlParameter param5 = new SqlParameter("nStockRequestNo", nStockRequestNo);
			SqlParameter param6 = new SqlParameter("strRemarks", strRemarks);
		

			try
			{
				int rowUpdate = (int)SqlHelper.ExecuteNonQuery(trans,"SP_UpdateStockRequest",param1,param2,param3,param4,param5,param6);
				
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

		public int SaveStockRequest(SqlTransaction trans,DateTime dtDate,string strBranchCodeFrom,string strBranchCodeTo,int nStatusID,int nEmployeeID,DateTime dtLastEditDate,int nIBTNo,string strRemarks)
		{
			SqlParameter param1 = new SqlParameter("dtDate", dtDate);
			SqlParameter param2 = new SqlParameter("strBranchCodeFrom", strBranchCodeFrom);
			SqlParameter param3 = new SqlParameter("strBranchCodeTo", strBranchCodeTo);
			SqlParameter param4 = new SqlParameter("nStatusID", nStatusID);
			SqlParameter param5 = new SqlParameter("nEmployeeID", nEmployeeID);
			SqlParameter param6 = new SqlParameter("dtLastEditDate", dtLastEditDate);
			SqlParameter param7 = new SqlParameter("nIBTNo", nIBTNo);
			SqlParameter param8 = new SqlParameter("strRemarks", strRemarks);
		

			try
			{
				int nStockRequestNo = (int)SqlHelper.ExecuteScalar(trans,"SP_SaveStockRequest",param1,param2,param3,param4,param5,param6,param7,param8);
				
				if(nStockRequestNo>0)
					return nStockRequestNo;
			}
		
			catch(Exception err)
			{
				UI.ShowErrorMessage(null, err.Message, "Error");
				return 0;
			}
			return 0;
		}

		public bool UpdateStockRequestEntries(SqlTransaction trans,int nEntryID,int nQuantity,string strItemCode,string strBranchCode)
		{
			SqlParameter param1 = new SqlParameter("nEntryID", nEntryID);
			SqlParameter param2 = new SqlParameter("nQuantity", nQuantity);
			SqlParameter param3 = new SqlParameter("strItemCode", strItemCode);
			SqlParameter param4 = new SqlParameter("strBranchCode", strBranchCode);

			try
			{
				int rowUpdate = (int)SqlHelper.ExecuteNonQuery(trans,"SP_UpdateStockRequestEntries",param1,param2,param3,param4);
				
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

		public bool SaveStockRequestEntries(SqlTransaction trans,int nStockRequestNo,string strItemCode,int nQuantity,string strBranchCode)
		{
			SqlParameter param1 = new SqlParameter("nStockRequestNo", nStockRequestNo);
			SqlParameter param2 = new SqlParameter("strItemCode", strItemCode);
			SqlParameter param3 = new SqlParameter("nQuantity", nQuantity);
			SqlParameter param4 = new SqlParameter("strBranchCode", strBranchCode);

			try
			{
				int rowInsert = (int)SqlHelper.ExecuteNonQuery(trans,"SP_SaveStockRequestEntries",param1,param2,param3,param4);
				
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
	
	}
}
