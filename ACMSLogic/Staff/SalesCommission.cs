using System;
using System.Data;
using System.Data.SqlClient;
using ACMS;
using ACMS.Utils;
using ACMSLogic.Staff;

namespace ACMSLogic.Staff
{
	/// <summary>
	/// Summary description for Sales.
	/// </summary>
	public class SalesCommission
	{
		public SalesCommission()
		{
		}

		public DataTable GetSalesCommission(int nEmployeeID, string strBranchCode, CategoryType myCategory, Month month, int year)
		{
			DateTime startDate, endDate;
			Ultis.DatesRange(out startDate, out endDate, month, year);
			SqlParameter paramStartDate = new SqlParameter("@ddtStartDate", SqlDbType.DateTime);
			paramStartDate.Value = startDate;
			SqlParameter paramEndDate = new SqlParameter("@ddtEndDate", SqlDbType.DateTime);
			paramEndDate.Value = endDate;
			SqlParameter paramEmployeeID = new SqlParameter("@inEmployeeID", SqlDbType.Int);
			paramEmployeeID.Value = nEmployeeID;
			SqlParameter paramCategoryID = new SqlParameter("@inCategoryID", SqlDbType.Int);
			paramCategoryID.Value = (int)myCategory;
			return SqlHelperUtils.ExecuteDataTableSP("pr_tblReceipt_SelectSalesCommission", paramCategoryID, paramStartDate, 
				paramEndDate, paramEmployeeID, new SqlParameter("@sstrBranchCode", strBranchCode));
		}
	}
}