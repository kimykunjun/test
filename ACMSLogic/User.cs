using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using ACMSDAL;
using System.Data.SqlTypes;
using System.Data.SqlClient;


namespace ACMSLogic
{
	public class User
	{
		public static int EmployeeID;
		public static string EmployeeName;
		public static string JobPositionCode;
		public static string BranchCode;
		public static int RightsLevelID;
        public static int DepartmentID;
        public static string RoadShow;
        public static string OSAmount;
        public static DateTime dtCessation;
		
		public bool Login(string nEmployeeID, string strPassword)
		{	
			TblEmployee oEmployee = new TblEmployee();
			DataTable dtEmployee;
			int rowCount;
			
			ACMSDAL.TblEmployee emp = new ACMSDAL.TblEmployee();
			DataTable dt = emp.SelectAll();
			
			int empId = int.MinValue;
			
			DataRow row;
			foreach (DataRow tempLoopVar_row in dt.Rows)
			{
				row = tempLoopVar_row;
				if (row["strEmployeeName"].ToString() == nEmployeeID)
				{
					empId = System.Convert.ToInt32(row[0].ToString());
				}
			}
			
			oEmployee.NEmployeeID = new SqlInt32(empId);
			oEmployee.StrPassword = new SqlString(strPassword.Trim());
			
			try
			{
				dtEmployee = oEmployee.SelectOne();
				rowCount = dtEmployee.Rows.Count;
				
				if (dtEmployee.Rows.Count > 0)
				{
					DataRow dr;
					dr = dtEmployee.Rows[0];
				
					if (rowCount > 0 && dr[2].ToString() == strPassword)
					{
						EmployeeID = oEmployee.NEmployeeID.Value;
						EmployeeName = oEmployee.StrEmployeeName.ToString();
						JobPositionCode = oEmployee.StrJobPositionCode.ToString();
						BranchCode = oEmployee.StrBranchCode.ToString();
						RightsLevelID = oEmployee.NRightsLevelID.Value;
						DepartmentID = oEmployee.NDepartmentID.Value;
                        dtCessation = System.Convert.ToDateTime(oEmployee.DtCessation.Value);
                        //RoadShow= ch
						return true;
					}
				}	
				else
				{
					return false;
				}
//				oEmployee.Dispose();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message);
			}
			return true;
		}
		
		public int NEmployeeID()
		{
			return EmployeeID;
		}
		
		public string StrEmployeeName()
		{
			return EmployeeName;
		}
		
		public string StrJobPositionCode()
		{
			return JobPositionCode;
		}
		
		public string StrBranchCode()
		{
			return BranchCode;
		}
		
		public int NRightsLevelID()
		{
			return RightsLevelID;
		}
		
		public int NDepartmentID()
		{
			return DepartmentID;
		}

        public DateTime DTCessation()
        {
            return dtCessation;
        }
	}
	
}
