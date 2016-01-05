using System;
using System.Data;
using System.Data.SqlClient;
using ACMSDAL;
using ACMS;

namespace ACMSLogic.Staff
{
	/// <summary>
	/// Summary description for CommissionSaleProduct.
	/// </summary>
	public class CommissionSaleProduct
	{
		private int nEmployeeID;
		private SaleProductType myType;
		private Month month;
		private int year;
		private ACMSDAL.Common myDBCommon;
		private DataSet myResultDataSet;
		private DataRow myResultDataRow;

		/// <summary>
		/// Contain info from tblEmployee like BranchCode, EmployeeID, mFitnessPackageTarget, total commission
		/// </summary>
		public const string EMPLOYEEINFO = "EmployeeInfo";
		/// <summary>
		/// Contain info from tblEmployeeCommissionScheme. Store all commission code for current employee.
		/// </summary>
		public const string EMPLOYEECOMMISSIONCODE = "EmployeeCommissionCode";
		/// <summary>
		/// Contain info from tblBranchTarget like BranchCode, mFitnessPackageTarget, mFitnessProductTarget.
		/// </summary>
		public const string BRANCHTARGET = "BranchTarget";
		/// <summary>
		/// Contain info from tblReceipt. Store NettAmount for current employee.
		/// </summary>
		public const string EMPLOYEENETTAMOUNT = "EmployeeNettAmount";
		/// <summary>
		/// Contain info from tblReceipt. Store NettAmount for current employee branch.
		/// </summary>
		public const string BRANCHNETTAMOUNT = "BranchNettAmount";
		/// <summary>
		/// Contain info from tblCommissionSchemeEntries. Use commission code from EMPLOYEECOMMISSIONCODE.
		/// </summary>
		public const string COMMISSIONSCHEMEENTRIES = "CommissionSchemeEntries";

		public DataRow DetailsResultDataRow
		{
			get {return myResultDataRow;}
		}

		/// <summary>
		/// Get the Result DataTable
		/// </summary>
		public DataTable ResultTable
		{
			get {return myResultDataSet.Tables[EMPLOYEEINFO];}
		}

		public CommissionSaleProduct()
		{
			myDBCommon = new ACMSDAL.Common();
		}

		public void CalculateCommissionProduct(int aEmployeeID, SaleProductType aType, Month aMonth, int aYear)
		{
			nEmployeeID = aEmployeeID;
			myType = aType;
			month = aMonth;
			year = aYear;
			ProcessCalculation();
		}

		private void ProcessCalculation()
		{
			myResultDataSet = new DataSet();
			myResultDataRow = null;
			GetBasicEmployeeInfo();

			// Check have commission code for current employee or not. If don't have return 0 commission.
			if (myResultDataSet.Tables[EMPLOYEECOMMISSIONCODE].Rows.Count == 0)
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
			GetBranchTarget();
			GetNettAmmount();

			decimal commission = 0m;
			// Sum all CommissionCode commission.
			foreach (DataRow myRow in myResultDataSet.Tables[EMPLOYEECOMMISSIONCODE].Rows)
			{
				commission += CalculateCommission(myRow["strCommissionCode"].ToString(), ACMS.Convert.ToInt32(myRow["TotalEmployee"]));
			}
			foreach(DataRow myRow in myResultDataSet.Tables[EMPLOYEEINFO].Rows)
			{
				myRow.BeginEdit();
				myRow["mCommission"] = commission;
				myRow.EndEdit();
			}
		}

		private void GetBasicEmployeeInfo()
		{
			string text = GenerateEmployeeInfo() + GenerateEmployeeCommission();
			SqlCommand myCmd = new SqlCommand(text);
			myCmd.Parameters.Add("@nnEmployeeID", nEmployeeID);
			myDBCommon.SelectDataSet(myCmd, myResultDataSet);
			myResultDataSet.Tables[0].TableName = EMPLOYEEINFO;
			myResultDataSet.Tables[1].TableName = EMPLOYEECOMMISSIONCODE;

			Ultis.AddColumn(myResultDataSet.Tables[EMPLOYEEINFO], "mCommission", "System.Decimal");			
		}

		private void GetBranchTarget()
		{
			string text = GenerateBranchTarget();
			SqlCommand myCmd = new SqlCommand(text);
			myCmd.Parameters.Add("@sstrBranchCode", myResultDataSet.Tables[EMPLOYEEINFO].Rows[0]["strBranchCode"].ToString());
			myCmd.Parameters.Add("@nYearID", year);
			myCmd.Parameters.Add("@nMonthID", ((int)month) + 1);
			DataSet myDataSet = new DataSet();
			myDBCommon.SelectDataSet(myCmd, myDataSet);
			myDataSet.Tables[0].TableName = BRANCHTARGET;

			myResultDataSet.Tables.Add(myDataSet.Tables[BRANCHTARGET].Copy());
		}

		private void GetNettAmmount()
		{
			DateTime startDate;
			DateTime endDate;
			Ultis.DatesRange(out startDate, out endDate, month, year);

			string text = GenerateEmployeeNettAmount() + GenerateBranchNettAmount();
			DataSet myDataSet = new DataSet();
			SqlCommand myCmd = new SqlCommand(text);
			myCmd.Parameters.Add("@nnSalespersonID", nEmployeeID);
			myCmd.Parameters.Add("@sstrBranchCode", myResultDataSet.Tables[EMPLOYEEINFO].Rows[0]["strBranchCode"]);
			myCmd.Parameters.Add("@dtStartDate", startDate);
			myCmd.Parameters.Add("@dtEndDate", endDate);
			myDBCommon.SelectDataSet(myCmd, myDataSet);
			myDataSet.Tables[0].TableName = EMPLOYEENETTAMOUNT;
			myDataSet.Tables[1].TableName = BRANCHNETTAMOUNT;
			myResultDataSet.Tables.Add(myDataSet.Tables[EMPLOYEENETTAMOUNT].Copy());
			myResultDataSet.Tables.Add(myDataSet.Tables[BRANCHNETTAMOUNT].Copy());
		}

		/// <summary>
		/// Calculate commission for same CommissionCode
		/// </summary>
		/// <param name="commissionCode"></param>
		/// <param name="totalEmployee"></param>
		/// <returns></returns>
		private decimal CalculateCommission(string commissionCode, int totalEmployee)
		{
			DataTable commissionTable = GetCommissionCode(commissionCode);
			// Just return zero if not row in tblCommissionSchemeEntries
			if (commissionTable.Rows.Count == 0)
			{
				// Should be don't need.
				foreach(DataRow myRow in myResultDataSet.Tables[EMPLOYEEINFO].Rows)
				{
					myRow.BeginEdit();
					myRow["mCommission"] = 0m;
					myRow.EndEdit();
				}
				return 0;
			}

			foreach (DataRow myRow in commissionTable.Rows)
			{
				decimal commission = 0m;
				if (CalcSaleProductCommission(myRow, totalEmployee, ref commission))
				{
					return commission;
				}
			}
			// Return zero if all commission row also didn't meet target.
			return 0;
		}

		/// <summary>
		/// Calculate Sales & Product commission by package
		/// </summary>
		/// <param name="myRow"></param>
		/// <param name="commission"></param>
		/// <returns>return true if have commission</returns>
		private bool CalcSaleProductCommission(DataRow myRow, int totalEmployee, ref decimal commission)
		{
			decimal indTarget = 0m;
			decimal indSales = 0m;
			decimal branchTarget = 0m;
			decimal branchSales = 0m;
			string mBranchTargetName;
			string nBranchTargetPercentName, nIndTargetPercentName, nBranchExcessName, nIndExcessName;
			string nBranchPercentComm, nBranchPercentSharedComm, nIndPercentComm;
			if (myType == SaleProductType.FitnessPackage)
			{
				mBranchTargetName = "mFitnessPackageTarget";
				nBranchTargetPercentName = "nFitnessPackageBranchTargetPercent";
				nIndTargetPercentName = "nFitnessPackageIndTargetPercent";
				nBranchExcessName = "nFitnessPackageBranchExcess";
				nIndExcessName = "nFitnessPackageIndExcess";
				nBranchPercentComm = "nFitnessPackageBranchPercentComm";
				nBranchPercentSharedComm = "nFitnessPackageBranchPercentSharedComm";
				nIndPercentComm = "nFitnessPackageIndPercentComm";
			}
			else if (myType == SaleProductType.FitnessProduct)
			{
				mBranchTargetName = "mFitnessProductTarget";
				nBranchTargetPercentName = "nFitnessProductBranchTargetPercent";
				nIndTargetPercentName = "nFitnessProductIndTargetPercent";
				nBranchExcessName = "nFitnessProductBranchExcess";
				nIndExcessName = "nFitnessProductIndExcess";
				nBranchPercentComm = "nFitnessProductBranchPercentComm";
				nBranchPercentSharedComm = "nFitnessProductBranchPercentSharedComm";
				nIndPercentComm = "nFitnessProductIndPercentComm";
			}
			else if (myType == SaleProductType.SpaPackage)
			{
				mBranchTargetName = "mSpaPackageTarget";
				nBranchTargetPercentName = "nSpaPackageBranchTargetPercent";
				nIndTargetPercentName = "nSpaPackageIndTargetPercent";
				nBranchExcessName = "nSpaPackageBranchExcess";
				nIndExcessName = "nSpaPackageIndExcess";
				nBranchPercentComm = "nSpaPackageBranchPercentComm";
				nBranchPercentSharedComm = "nSpaPackageBranchPercentSharedComm";
				nIndPercentComm = "nSpaPackageIndPercentComm";
			}
			else if (myType == SaleProductType.SpaProduct)
			{
				mBranchTargetName = "mSpaProductTarget";
				nBranchTargetPercentName = "nSpaProductBranchTargetPercent";
				nIndTargetPercentName = "nSpaProductIndTargetPercent";
				nBranchExcessName = "nSpaProductBranchExcess";
				nIndExcessName = "nSpaProductIndExcess";
				nBranchPercentComm = "nSpaProductBranchPercentComm";
				nBranchPercentSharedComm = "nSpaProductBranchPercentSharedComm";
				nIndPercentComm = "nSpaProductIndPercentComm";
			}
			else 
			{
				mBranchTargetName = "mPTPackageTarget";
				nBranchTargetPercentName = "nPTPackageBranchTargetPercent";
				nIndTargetPercentName = "nPTPackageIndTargetPercent";
				nBranchExcessName = "nPTPackageBranchExcess";
				nIndExcessName = "nPTPackageIndExcess";
				nBranchPercentComm = "nPTPackageBranchPercentComm";
				nBranchPercentSharedComm = "nPTPackageBranchPercentSharedComm";
				nIndPercentComm = "nPTPackageIndPercentComm";
			}
			bool isAllDBNull = true;
			indTarget = ACMS.Convert.ToDecimal(myResultDataSet.Tables[EMPLOYEEINFO].Rows[0][mBranchTargetName]);
			if (myResultDataSet.Tables[EMPLOYEENETTAMOUNT].Rows.Count > 0)
				indSales = ACMS.Convert.ToDecimal(myResultDataSet.Tables[EMPLOYEENETTAMOUNT].Rows[0]["mIndNetAmount"]);
			else
				indSales = 0;
			if (myResultDataSet.Tables[BRANCHTARGET].Rows.Count > 0)
				branchTarget = ACMS.Convert.ToDecimal(myResultDataSet.Tables[BRANCHTARGET].Rows[0][mBranchTargetName]);
			else
				branchTarget = 0;
			if (myResultDataSet.Tables[BRANCHNETTAMOUNT].Rows.Count > 0)
				branchSales = ACMS.Convert.ToDecimal(myResultDataSet.Tables[BRANCHNETTAMOUNT].Rows[0]["mBranchNetAmount"]);
			else
				branchSales = 0;
			if (myRow[nBranchTargetPercentName] != DBNull.Value)
			{
				isAllDBNull = false;
				decimal nFitnessPackageBranchTargetPercent = ACMS.Convert.ToDecimal(myRow[nBranchTargetPercentName]);
				decimal currentPercent;
				if (branchTarget != 0)
					currentPercent = branchSales / branchTarget * 100;
				else
					currentPercent = 0;
				if (currentPercent < nFitnessPackageBranchTargetPercent)
					return false;
			}
			if (myRow[nIndTargetPercentName] != DBNull.Value)
			{
				isAllDBNull = false;
				decimal nFitnessPackageIndTargetPercent = ACMS.Convert.ToDecimal(myRow[nIndTargetPercentName]);
				decimal currentPercent;
				if (indTarget != 0)
					currentPercent = indSales / indTarget * 100;
				else
					currentPercent = 0;
				if (currentPercent < nFitnessPackageIndTargetPercent)
					return false;
			}
			if (myRow[nBranchExcessName] != DBNull.Value &&
				ACMS.Convert.ToDecimal(myRow[nBranchExcessName]) != 0)
			{
				isAllDBNull = false;
				decimal nFitnessPackageBranchExcess = ACMS.Convert.ToDecimal(myRow[nBranchExcessName]);
				if (branchSales < (branchTarget + nFitnessPackageBranchExcess))
					return false;
			}
			if (myRow[nIndExcessName] != DBNull.Value &&
				ACMS.Convert.ToDecimal(myRow[nIndExcessName]) != 0)
			{
				isAllDBNull = false;
				decimal nFitnessPackageIndExcess = ACMS.Convert.ToDecimal(myRow[nIndExcessName]);
				if (indSales < (indTarget + nFitnessPackageIndExcess))
					return false;
			}
			// Continue to next new row if all is DBNull value
			if (isAllDBNull)
				return false;
			// Return the commission is high priority meet
			commission = ACMS.Convert.ToDecimal(myRow[nBranchPercentComm]) * branchTarget / 100;
			if (totalEmployee != 0)
				commission += ACMS.Convert.ToDecimal(myRow[nBranchPercentSharedComm]) * branchTarget / 100 / totalEmployee;
			commission += ACMS.Convert.ToDecimal(myRow[nIndPercentComm]) * indTarget / 100;
			commission += ACMS.Convert.ToDecimal(myRow["mCommissionAmount"]);

			// Modified by Chloe, for payroll portion
			myResultDataRow = myRow;

			return true;	
		}

		private DataTable GetCommissionCode(string commissionCode)
		{
			string text = GenerateCommissionSchemeEntries();
			SqlCommand myCmd = new SqlCommand(text);
			myCmd.Parameters.Add("@sstrCommissionCode", commissionCode);
			DataTable myTable = myDBCommon.SelectDataTable(myCmd);
			myTable.TableName = COMMISSIONSCHEMEENTRIES;
			return myTable;
		}

		private string GenerateEmployeeInfo()
		{
			string text = "SELECT nEmployeeID, strEmployeeName, strJobPositionCode, strBranchCode, ";
			if (myType == SaleProductType.FitnessPackage)
				text += "mFitnessPackageTarget ";
			else if (myType == SaleProductType.FitnessProduct)
				text += "mFitnessProductTarget ";
			else if (myType == SaleProductType.SpaPackage)
				text += "mSpaPackageTarget ";
			else if (myType == SaleProductType.SpaProduct)
				text += "mSpaProductTarget ";
			else
				text += "mPTPackageTarget ";
			text += "FROM tblEmployee WHERE nEmployeeID = @nnEmployeeID;";

			return text;
		}

		private string GenerateEmployeeCommission()
		{
			string text = "SELECT A.*, "
				+"(SELECT Count(*) "
				+"FROM tblEmployeeCommissionScheme C INNER JOIN tblEmployee D ON C.nEmployeeID = D.nEmployeeID "
				+"WHERE C.strCommissionCode = A.strCommissionCode AND D.strBranchCode = B.strBranchCode) AS TotalEmployee "
				+"FROM tblEmployeeCommissionScheme A INNER JOIN tblEmployee B ON A.nEmployeeID = B.nEmployeeID "
				+"WHERE A.nEmployeeID = @nnEmployeeID;";
			return text;
		}

		private string GenerateBranchTarget()
		{
			string text = "SELECT * FROM tblBranchTarget WHERE strBranchCode = @sstrBranchCode AND nYearID = @nYearID AND nMonthID = @nMonthID;";
			return text;
		}

		private string GenerateEmployeeNettAmount()
		{
			string text = "SELECT SUM(mNettAmount) AS mIndNetAmount, nSalespersonID FROM tblReceipt "
				+"WHERE nSalespersonID = @nnSalespersonID AND dtDate >= @dtStartDate AND dtDate < @dtEndDate "
				+NettAmountCategoryString()
				+"GROUP BY nSalespersonID;";

			return text;
		}

		///<summary>
		/// Refactored from  GenerateEmployeeNettAmount
		///</summary>
		private string NettAmountCategoryString()
		{
			string text;
			if (myType == SaleProductType.FitnessPackage)
			{
				text = "AND nCategoryID IN (1, 2, 8) ";
			}
			else if (myType == SaleProductType.FitnessProduct)
			{
				text = "AND nCategoryID = 11  ";
			}
			else if (myType == SaleProductType.SpaPackage)
			{
				text = "AND nCategoryID IN (4, 5, 6, 9, 7) ";
			}
			else if (myType == SaleProductType.SpaProduct)
			{
				text = "AND nCategoryID = 12 ";
			}
			else
			{
				text = "AND nCategoryID = 3 ";	
			}

			return text;
		}

		private string GenerateBranchNettAmount()
		{
			string text = "SELECT SUM(mNettAmount) AS mBranchNetAmount, strBranchCode FROM tblReceipt "
				+"WHERE strBranchCode = @sstrBranchCode AND dtDate >= @dtStartDate AND dtDate < @dtEndDate "
				+NettAmountCategoryString()
				+"GROUP BY strBranchCode;";

			return text;
		}

		private string GenerateCommissionSchemeEntries()
		{
			string text = "SELECT * FROM tblCommissionSchemeEntries WHERE strCommissionCode = @sstrCommissionCode "
				+"ORDER BY nPriorityID;";
			return text;
		}
	}

	public enum SaleProductType
	{
		/// <summary>
		/// Fitness Package, Fitness GIRO, Fitness Combined Package
		/// </summary>
		FitnessPackage,
		FitnessProduct,
		/// <summary>
		/// Spa Single Treatment, Spa Package, IPL Package, Spa Combined Package, Spa Credit Account
		/// </summary>
		SpaPackage,
		SpaProduct,
		/// <summary>
		/// PT Package
		/// </summary>
		PTPackage
	}
}