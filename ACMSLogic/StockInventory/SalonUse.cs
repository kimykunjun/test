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
	/// Summary description for SalonUse.
	/// </summary>
	public class SalonUse
	{
		//private string connectionString = ConfigurationSettings.AppSettings["Main.ConnectionString"];

		public SalonUse()
		{
			//
			// TODO: Add constructor logic here
			//
		}


		public bool SaveSalonUse(DateTime dtDate,int nQuantity,string strBranchCode,string strProductCode,int nEmployeeId)
		{
			SqlParameter param1 = new SqlParameter("dtDate", dtDate);
			SqlParameter param2 = new SqlParameter("nQuantity", nQuantity);
			SqlParameter param3 = new SqlParameter("strBranchCode",strBranchCode);
			SqlParameter param4 = new SqlParameter("strProductCode",strProductCode);
			SqlParameter param5 = new SqlParameter("nEmployeeID",nEmployeeId);
		
			try
			{
				int rowInsert = SqlHelper.ExecuteNonQuery(SqlHelperUtils.connectionString,"Sp_SaveSalonUse",param1,param2,param3,param4,param5);
				if(rowInsert>0)
					return true;
			}
			catch(Exception err)
			{
				UI.ShowErrorMessage(null, err.Message, "Error");
			}
			return false;
		}

		public void DeleteSalonUse(string referenceNo,string strBranchCode,string strProductCode,int quantity,int nEmployeeID,string strAuditEntry,string strReference,int nAuditTypeID)
		{
			SqlParameter param1 = new SqlParameter("nSalesUseID", referenceNo);
			SqlParameter param2 = new SqlParameter("strBranchCode", strBranchCode);
			SqlParameter param3 = new SqlParameter("strProductCode",strProductCode);
			SqlParameter param4 = new SqlParameter("quantity",quantity);
			SqlParameter param5 = new SqlParameter("nEmployeeID",nEmployeeID);
			SqlParameter param6 = new SqlParameter("strAuditEntry",strAuditEntry);
			SqlParameter param7 = new SqlParameter("strReference",strReference);
			SqlParameter param8 = new SqlParameter("nAuditTypeID",nAuditTypeID);
			try
			{
				SqlHelper.ExecuteNonQuery(SqlHelperUtils.connectionString,"Sp_DeleteSalonUse",param1,param2,param3,param4,param5,param6,param7,param8);
			}
			catch(Exception err)
			{
				UI.ShowErrorMessage(null, err.Message, "Error");
			}
		}
	}
}
