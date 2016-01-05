using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using Acms.Core.Domain;
using ACMS.Utils;
using System.Configuration;

namespace ACMSLogic.AuditTrail
{
	/// <summary>
	/// Summary description for AuditTrail.
	/// </summary>
	public class AuditTrail
	{
		public AuditTrail()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public bool SaveAuditTrail(int nAuditTypeID, string strReference, string strAuditEntry,int nEmployeeID)
		{
			SqlParameter param1 = new SqlParameter("nAuditTypeID", nAuditTypeID);
			SqlParameter param2 = new SqlParameter("strReference", strReference);
			SqlParameter param3 = new SqlParameter("strAuditEntry", strAuditEntry);
			SqlParameter param4 = new SqlParameter("nEmployeeID", nEmployeeID);

			try
			{
				int rowInsert = SqlHelper.ExecuteNonQuery(SqlHelperUtils.connectionString,"SP_SaveAuditTrail",param1,param2,param3,param4);
				
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

		public bool SaveAuditTrail(SqlTransaction trans,int nAuditTypeID, string strReference, string strAuditEntry,int nEmployeeID)
		{
			SqlParameter param1 = new SqlParameter("nAuditTypeID", nAuditTypeID);
			SqlParameter param2 = new SqlParameter("strReference", strReference);
			SqlParameter param3 = new SqlParameter("strAuditEntry", strAuditEntry);
			SqlParameter param4 = new SqlParameter("nEmployeeID", nEmployeeID);

			try
			{
				int rowInsert = SqlHelper.ExecuteNonQuery(trans,"SP_SaveAuditTrail",param1,param2,param3,param4);
				
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
