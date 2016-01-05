using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using Acms.Core.Domain;
using ACMS.Utils;
using System.Configuration;

namespace ACMSLogic.Promotion
{
	/// <summary>
	/// Summary description for Promotion.
	/// </summary>
	public class Promotion
	{
		public Promotion()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public DataSet FindPromotionByBranch(string strBranchCode)
		{
			DataSet ds = null;
			SqlParameter param1 = new SqlParameter("strBranchCode", strBranchCode);
			try
			{
				ds = SqlHelper.ExecuteDataset(SqlHelperUtils.connectionString,"Sp_GetPromotionByBranchCode",param1);
			}
			catch(Exception err)
			{
				UI.ShowErrorMessage(null, err.Message, "Error");
			}
			return ds;
		}

		public DataSet FindAllocatedPromotion(string strBranchCode,string strPromotionCode)
		{
			DataSet ds = null;
			SqlParameter param1 = new SqlParameter("strBranchCode", strBranchCode);
			SqlParameter param2 = new SqlParameter("strPromotionCode", strPromotionCode);

			try
			{
				ds = SqlHelper.ExecuteDataset(SqlHelperUtils.connectionString,"Sp_GetAllocatedPromotion",param1,param2);
			}
			catch(Exception err)
			{
				UI.ShowErrorMessage(null, err.Message, "Error");
			}
			return ds;
		}

		public DataSet FindUnAllocatedPromotion(string strBranchCode,string strPromotionCode)
		{
			DataSet ds = null;
			SqlParameter param1 = new SqlParameter("strBranchCode", strBranchCode);
			SqlParameter param2 = new SqlParameter("strPromotionCode", strPromotionCode);

			try
			{
				ds = SqlHelper.ExecuteDataset(SqlHelperUtils.connectionString,"Sp_GetUnAllocatedPromotion",param1,param2);
			}
			catch(Exception err)
			{
				UI.ShowErrorMessage(null, err.Message, "Error");
			}
			return ds;
		}

		public void DeleteAdjustmentPromotion(System.Data.SqlClient.SqlTransaction trans,string strReceiptNo,string strPromotionCode)
		{
			SqlParameter param1 = new SqlParameter("strPromotionCode", strPromotionCode);
			SqlParameter param2 = new SqlParameter("strReceiptNo", strReceiptNo);

			try
			{
				int query = SqlHelper.ExecuteNonQuery(trans,"SP_DeleteAdjustmentPromotion",param1,param2);
				
			}
			catch(Exception err)
			{
				UI.ShowErrorMessage(null, err.Message, "Error");
				
			}
		}

		public bool UpdateAdjustmentPromotion(System.Data.SqlClient.SqlTransaction trans,string strReceiptNo,string strItemCode,string strPromotionCode,string strBranchCode,int nEntryID,string panel)
		{
			//DataSet ds = null;
			SqlParameter param1 = new SqlParameter("strPromotionCode", strPromotionCode);
			SqlParameter param2 = new SqlParameter("strItemCode", strItemCode);
			SqlParameter param3 = new SqlParameter("strReceiptNo", strReceiptNo);
			SqlParameter param4 = new SqlParameter("strBranchCode", strBranchCode);
			SqlParameter param5 = new SqlParameter("nEntryID", nEntryID);
			SqlParameter param6 = new SqlParameter("panel", panel);
			try
			{
				int query = SqlHelper.ExecuteNonQuery(trans,"SP_UpdateAdjustmentPromotion",param1,param2,param3,param4,param5,param6);
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

		public DataSet FindPromotionList(string strReceiptNo,string type)
		{
			DataSet ds = null;
			SqlParameter param1 = new SqlParameter("strReceiptNo", strReceiptNo);
	
			SqlParameter param2 = new SqlParameter("type", type);
			try
			{
				ds = SqlHelper.ExecuteDataset(SqlHelperUtils.connectionString,"Sp_GetPromotionList",param1,param2);
			}
			catch(Exception err)
			{
				UI.ShowErrorMessage(null, err.Message, "Error");
			}
			return ds;
		}

		public DataTable FindPromotionSelectionList(string strBranchCode,string mTotalAmount,string strMemberShipId,string nCategoryId,string strPromotionCode,string type,string strReceiptNo,string strItemCode)
		{
			DataSet ds = null;

			SqlParameter param1 = new SqlParameter("strBranchCode", strBranchCode);
			SqlParameter param2 = new SqlParameter("mTotalAmount", mTotalAmount);
			SqlParameter param3 = new SqlParameter("strMemberShipID", strMemberShipId);
			SqlParameter param4 = new SqlParameter("nSalesCategoryID", nCategoryId);
			SqlParameter param5 = new SqlParameter("strPromotionCode", strPromotionCode);
			SqlParameter param6 = new SqlParameter("type", type);
			SqlParameter param7 = new SqlParameter("strReceiptNo", strReceiptNo);
			SqlParameter param8 = new SqlParameter("strItemCode", strItemCode);
			//try
			//{
			ds = SqlHelper.ExecuteDataset(SqlHelperUtils.connectionString,"Sp_GetPromotionSelectionList",param1,param2,param3,param4,param5,param6,param7,param8);
			if(ds.Tables.Count>0)
			{
				return ds.Tables[0];
			}
			//}
			//catch(Exception err)
			//{
			//	UI.ShowErrorMessage(null, err.Message, "Error");
			//}
			return null;
		}

		public DataSet FindPromotionSelectionForBillFreebie(string strBranchCode,string strPromotionCode,string strReceiptNo)
		{
			DataSet ds = null;
			
			SqlParameter param1 = new SqlParameter("strBranchCode", strBranchCode);
			SqlParameter param2 = new SqlParameter("strPromotionCode", strPromotionCode);
			SqlParameter param3 = new SqlParameter("strReceiptNo", strReceiptNo);
			try
			{
				ds = SqlHelper.ExecuteDataset(SqlHelperUtils.connectionString,"Sp_GetPromotionSelectionForBillFreebie",param1,param2,param3);
			}
			catch(Exception err)
			{
				UI.ShowErrorMessage(null, err.Message, "Error");
			}
			return ds;
		}

		public DataSet FindPromotionByPromotionCode(string strPromotionCode,string strBranchCode,string strRecieptNo,string type,string panel)
		{
			DataSet ds = null;
			SqlParameter param1 = new SqlParameter("strPromotionCode", strPromotionCode);
			SqlParameter param2 = new SqlParameter("strBranchCode", strBranchCode);
			SqlParameter param3 = new SqlParameter("strRecieptNo", strRecieptNo);
			SqlParameter param4 = new SqlParameter("type", type);
			SqlParameter param5 = new SqlParameter("panel", panel);
			try
			{
				ds = SqlHelper.ExecuteDataset(SqlHelperUtils.connectionString,"Sp_GetPromotionByPromotionCodeByBranchCode",param1,param2,param3,param4,param5);
			}
			catch(Exception err)
			{
				UI.ShowErrorMessage(null, err.Message, "Error");
			}
			return ds;
		}

		#region Old Code
		//		public DataSet FindReceiptFreebie(string strReceiptNo)
		//		{
		//			DataSet ds = null;
		//			SqlParameter param1 = new SqlParameter("strReceiptNo", strReceiptNo);
		//		
		//			try
		//			{
		//				ds = SqlHelper.ExecuteDataset(SqlHelperUtils.connectionString,"Sp_GetReceiptFreebie",param1);
		//			}
		//			catch(Exception err)
		//			{
		//				UI.ShowErrorMessage(null, err.Message, "Error");
		//			}
		//			return ds;
		//		}
		//
		//		public DataSet FindReceiptEntries(string strReceiptNo)
		//		{
		//			DataSet ds = null;
		//			SqlParameter param1 = new SqlParameter("strReceiptNo", strReceiptNo);
		//		
		//			try
		//			{
		//				ds = SqlHelper.ExecuteDataset(SqlHelperUtils.connectionString,"Sp_GetReceiptEntries",param1);
		//			}
		//			catch(Exception err)
		//			{
		//				UI.ShowErrorMessage(null, err.Message, "Error");
		//			}
		//			return ds;
		//		}
		#endregion
	}
}
