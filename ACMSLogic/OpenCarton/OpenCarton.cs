using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using Acms.Core.Domain;
using ACMS.Utils;
using System.Configuration;

namespace ACMSLogic.OpenCarton
{
	/// <summary>
	/// Summary description for OpenCarton.
	/// </summary>
	public class OpenCarton
	{
		

		public OpenCarton()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public DataSet FindCurrentProductBalance(string strProductCode,string strBranchCode)
		{
			DataSet ds = null;
			SqlParameter param1 = new SqlParameter("strProductCode", strProductCode);
			SqlParameter param2 = new SqlParameter("strBranchCode", strBranchCode);
			try
			{
				ds = SqlHelper.ExecuteDataset(SqlHelperUtils.connectionString,"Sp_FindCurrentProductBalance",param1,param2);
			}
			catch(Exception err)
			{
				UI.ShowErrorMessage(null, err.Message, "Error");
			}
			return ds;
		}

		public DataSet AddProduct(string strProductCode,string strBranchCode,int nQuantity)
		{
			DataSet ds = null;
			SqlParameter param1 = new SqlParameter("strProductCode", strProductCode);
			SqlParameter param2 = new SqlParameter("strBranchCode", strBranchCode);
			SqlParameter param3 = new SqlParameter("nQuantity", nQuantity);

			try
			{
				ds = SqlHelper.ExecuteDataset(SqlHelperUtils.connectionString,"Sp_OpenCartonAddProduct",param1,param2,param3);
			}
			catch(Exception err)
			{
				UI.ShowErrorMessage(null, err.Message, "Error");
			}
			return ds;
		}
	}
}
