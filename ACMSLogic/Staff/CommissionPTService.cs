using System;
using System.Data;
using System.Data.SqlClient;
using ACMSDAL;
using ACMS;
using ACMS.Utils;

namespace ACMSLogic.Staff
{
	/// <summary>
	/// Summary description for CommissionPTService.
	/// </summary>
	public class CommissionPTService
	{
		private int nEmployeeID;
		private string strBranchCode;
		private Month month;
		private int year;
		private ACMSDAL.Common myDBCommon;
		private DataSet myResultDataSet;
		/// <summary>
		/// Store all current employee info like ID, Total Commission
		/// </summary>
		public const string EMPLOYEEINFO = "tblEmployeeInfo";
		/// <summary>
		/// Store all Service Session for current employee within particular month and info like strServiceCode, nServiceEmployeeID
		/// </summary>
		public const string SERVICESESSION = "tblServiceSessionInfo";
		/// <summary>
		/// Store all PTCommLevel
		/// </summary>
		public const string PTCOMMLEVEL = "tblPTCommLevel";

		/// <summary>
		/// Get the Result DataTable contain EmployeeID and Commission only
		/// </summary>
		public DataTable ResultTableInSummary
		{
			get {return myResultDataSet.Tables[EMPLOYEEINFO];}
		}
		/// <summary>
		/// Get the Result DataTable contain all ServiceSession and commission
		/// </summary>
		public DataTable ResultTableInDetail
		{
			get {return myResultDataSet.Tables[SERVICESESSION];}
		}

		public CommissionPTService()
		{
			myDBCommon = new ACMSDAL.Common();
		}

		public void CalculatePTServiceCommission(int aEmployeeID, Month aMonth, int aYear)
		{
			CalculatePTServiceCommission(aEmployeeID, string.Empty, aMonth, aYear);
		}

		public void CalculatePTServiceCommission(int aEmployeeID, string aBranchCode, Month aMonth, int aYear)
		{
			nEmployeeID = aEmployeeID;
			strBranchCode = aBranchCode;
			month = aMonth;
			year = aYear;
			ProcessCalculation();
		}

		private void ProcessCalculation()
		{
			myResultDataSet = new DataSet();
			GetBasicEmployeeInfo();

			if (myResultDataSet.Tables[EMPLOYEEINFO].Rows[0]["fPartTime"] != DBNull.Value && System.Convert.ToBoolean(myResultDataSet.Tables[EMPLOYEEINFO].Rows[0]["fPartTime"]) == true)
			{
				CommissionSpaService myCommission = new CommissionSpaService();
				myCommission.CalculateSpaServiceCommission(nEmployeeID, strBranchCode, month, year, true);
				myResultDataSet = new DataSet();
				myResultDataSet.Tables.Add(myCommission.ResultTableInSummary.Copy());
				//myResultDataSet.Tables.Add(myCommission.ResultTableInDetail.Copy());
				return;
			}

			// Check have commission code for current employee or not. If don't have return 0 commission.
			if (myResultDataSet.Tables[SERVICESESSION].Rows.Count == 0)
			{
				// Actually is don't need foreach. Should be have 1 row only.
				foreach(DataRow myRow in myResultDataSet.Tables[EMPLOYEEINFO].Rows)
				{
					myRow.BeginEdit();
					myRow["mCommission"] = 0m;
					myRow.EndEdit();
				}
				return;
			}

			decimal commission = 0m;
			// Sum all mServiceCommission using strServiceCode commission.
			//foreach (DataRow myRow in myResultDataSet.Tables[SERVICESESSION].Rows)
			for (int i = 1; i <= myResultDataSet.Tables[SERVICESESSION].Rows.Count; i++)
			{
				DataRow myRow = myResultDataSet.Tables[SERVICESESSION].Rows[i - 1];
				decimal currentCommission = 0m;
				currentCommission = CalculateCommission(i);
				commission += currentCommission;
				myRow["mCommission"] = currentCommission;
			}
			foreach(DataRow myRow in myResultDataSet.Tables[EMPLOYEEINFO].Rows)
			{
				myRow.BeginEdit();
				myRow["mCommission"] = commission;
				myRow.EndEdit();
			}
		}

		private decimal CalculateCommission(int range)
		{
			DataRow[] rangeRows = myResultDataSet.Tables[PTCOMMLEVEL].Select("nLowerLimit <= " +range.ToString() +" AND "
				+"nUpperLimit >= " +range.ToString());

			decimal commission = 0m;
			if (rangeRows.Length > 0)
				commission = ACMS.Convert.ToDecimal(rangeRows[0]["mServiceCommission"]);

			return commission;
		}

		private void GetBasicEmployeeInfo()
		{
			DateTime startDate;
			DateTime endDate;
			Ultis.DatesRange(out startDate, out endDate, month, year);

			string text = GenerateEmployeeInfo() + GenerateServiceSession() + GeneratePTCommLevel();
			SqlCommand myCmd = new SqlCommand(text);
			myCmd.Parameters.Add("@nnEmployeeID", nEmployeeID);
			myCmd.Parameters.Add("@dtStartDate", startDate);
			myCmd.Parameters.Add("@dtEndDate", endDate);
			if (strBranchCode.Length != 0)
				myCmd.Parameters.Add("@sstrBranchCode", strBranchCode);
			myDBCommon.SelectDataSet(myCmd, myResultDataSet);
			myResultDataSet.Tables[0].TableName = EMPLOYEEINFO;
			myResultDataSet.Tables[1].TableName = SERVICESESSION;
			myResultDataSet.Tables[2].TableName = PTCOMMLEVEL;

			Ultis.AddColumn(myResultDataSet.Tables[EMPLOYEEINFO], "mCommission", "System.Decimal");		
			Ultis.AddColumn(myResultDataSet.Tables[SERVICESESSION], "mCommission", "System.Decimal");
		}

		private string GenerateEmployeeInfo()
		{
			string text = "SELECT nEmployeeID, strEmployeeName, strJobPositionCode, strBranchCode, fPartTime "
				+"FROM tblEmployee WHERE nEmployeeID = @nnEmployeeID;";
			return text;
		}

		private string GenerateServiceSession()
		{
			string text = "SELECT A.* FROM tblServiceSession A INNER JOIN tblService B ON A.strServiceCode = B.strServiceCode "
				+"WHERE A.nStatusID = 5 And A.nServiceEmployeeID = @nnEmployeeID AND A.dtDate >= @dtStartDate AND A.dtDate < @dtEndDate "
				+"AND B.nServiceTypeID = 0 ";
			if (strBranchCode.Length != 0)
				text += "AND strBranchCode = @sstrBranchCode;";
			else
				text += ";";
			return text;
		}

		private string GeneratePTCommLevel()
		{
			string text = "SELECT * FROM tblPTCommLevel ORDER BY nLowerLimit;";
			return text;
		}
	}
}
