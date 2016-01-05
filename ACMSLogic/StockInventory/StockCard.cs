using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using Acms.Core.Domain;
using ACMS.Utils;
using System.Configuration;

namespace ACMSLogic.StockInventory
{
	/// <summary>
	/// Summary description for StockCard.
	/// </summary>
	public class StockCard
	{
		public StockCard()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public DataSet GetStockCard(string strProductCode,string strBranchCode)
		{
			SqlParameter param1 = new SqlParameter("strProductCode", strProductCode);
			SqlParameter param2 = new SqlParameter("strBranchCode", strBranchCode);
			
			DataSet dsProduct = SqlHelper.ExecuteDataset(SqlHelperUtils.connectionString, "SP_GetStockCard",param1,param2);

			if(dsProduct!=null)
			{
				return dsProduct;
			}
			return null;
		}
	}
}
