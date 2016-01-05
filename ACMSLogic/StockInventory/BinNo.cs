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
	/// Summary description for BinNo.
	/// </summary>
	public class BinNo
	{
		public BinNo()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public bool UpdateBinNo(string strBranchCode,string strProductCode,string binNo)
		{
			SqlParameter param1 = new SqlParameter("strBranchCode", strBranchCode);
			SqlParameter param2 = new SqlParameter("strProductCode", strProductCode);
			SqlParameter param3 = new SqlParameter("binNo", binNo);

			try
			{
				int query = SqlHelper.ExecuteNonQuery(SqlHelperUtils.connectionString,"Sp_UpdateBinNo",param1,param2,param3);
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
	}
}
