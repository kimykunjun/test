using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using Acms.Core.Domain;
using ACMS.Utils;
using System.Configuration;
using System.Collections;

namespace ACMSLogic.StockInventory
{
	/// <summary>
	/// Summary description for SearchInventory.
	/// </summary>
	public class SearchInventory
	{
		public SearchInventory()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public DataTable SearchStyle()
		{
			DataSet dsStyle = SqlHelper.ExecuteDataset(SqlHelperUtils.connectionString, "SP_SearchStyle");
			if(dsStyle!=null)
			{
				if(dsStyle.Tables[0].Rows.Count>0)
				{
					return dsStyle.Tables[0];
				}
			}
			return null;
		}

		public DataTable SearchItemDescription()
		{
			DataSet dsStyle = SqlHelper.ExecuteDataset(SqlHelperUtils.connectionString, "SP_SearchItemDescription");
			if(dsStyle!=null)
			{
				if(dsStyle.Tables[0].Rows.Count>0)
				{
					return dsStyle.Tables[0];
				}
			}
			return null;
		}

		public DataTable SearchItemCode()
		{
			DataSet dsStyle = SqlHelper.ExecuteDataset(SqlHelperUtils.connectionString, "SP_SearchItemCode");
			if(dsStyle!=null)
			{
				if(dsStyle.Tables[0].Rows.Count>0)
				{
					return dsStyle.Tables[0];
				}
			}
			return null;
		}

		public DataTable GetProductByTypeByBranch(string strBranchCode,string strStyle,string type)
		{
			SqlParameter param1 = new SqlParameter("strBranchCode", strBranchCode);
			SqlParameter param2 = new SqlParameter("strStyle", strStyle);
			SqlParameter param3 = new SqlParameter("type", type);
			try
			{
				DataSet dsProduct = SqlHelper.ExecuteDataset(SqlHelperUtils.connectionString, "SP_GetProductByTypeByBranch",param1,param2,param3);

				if(dsProduct!=null)
				{
					if(dsProduct.Tables[0].Rows.Count>0)
					{
						return dsProduct.Tables[0];
					}
				}
			}
			catch(Exception err)
			{
				UI.ShowErrorMessage(null, err.Message, "Error");
				return null;
			}
			return null;
		}

		public IList GetProductInventoryByProductCode(string strProductCode)
		{
			IList list = new ArrayList();
			SqlParameter param1 = new SqlParameter("strProductCode", strProductCode);
			//try
			//{
				DataSet ds = SqlHelper.ExecuteDataset(SqlHelperUtils.connectionString, "SP_GetProductInventoryByProductCode",param1);
				if(ds.Tables[0].Rows.Count>0)
				{
					foreach(DataRow dr in ds.Tables[0].Rows)
					{
						Acms.Core.Domain.ProductInventory pi = new ProductInventory();
						pi.StrBin = dr["StrBin"].ToString();
						pi.BranchId = dr["BranchId"].ToString();
						pi.NQuantity = Convert.ToInt32(dr["NQuantity"].ToString());
						list.Add(pi);
					}
					return list;
				}
				return null;
			//}
			//catch(Exception err)
			//{
			//	UI.ShowErrorMessage(null, err.Message, "Error");
			//	return null;
			//}
		}
	}
}
