using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using Acms.Core.Domain;
using ACMS.Utils;
using System.Configuration;
using AesWinApp;

namespace ACMSLogic.Login
{
	/// <summary>
	/// Summary description for Login.
	/// </summary>
	public class Login
	{
		private string connectionString; 
							   
		//private DataSet ds = new DataSet();

		public Login()
		{
			System.Security.Principal.WindowsIdentity appSessionID = System.Security.Principal.WindowsIdentity.GetCurrent();
		
			connectionString = ConfigurationSettings.AppSettings["Main.ConnectionString"] + ";WorkStation ID = " + appSessionID.Name + ";Application Name =AIMS" ; 
		
			//
			// TODO: Add constructor logic here
			//
		}

		public TerminalUser GetTerminalUserByUserId(string strTerminalUserCode)
		{
			TerminalUser tu = null;
			Branch branch = null;
			try
			{
				SqlHelper.ExecuteNonQuery(connectionString,"Set_DemoTerminal",
					new SqlParameter("@strTerminalUserCode", strTerminalUserCode));
					
				SqlParameter param1 = new SqlParameter("strTerminalUserCode", strTerminalUserCode);
				
				DataSet dsTerminalUser = SqlHelper.ExecuteDataset(SqlHelperUtils.connectionString, "SP_GetTerminalUserByUserId", param1);
			
				if(dsTerminalUser.Tables[0].Rows.Count>0)
				{
					foreach(DataRow dr in dsTerminalUser.Tables[0].Rows)
					{
						tu = new TerminalUser();
						branch = new Branch();
						tu.Id = dr["strTerminalUserCode"].ToString();
						tu.NServiceID = Convert.ToInt32(dr["nServiceID"].ToString());
						tu.NTerminalID = Convert.ToInt32(dr["nTerminalID"].ToString());
						branch.Id = dr["strBranchCode"].ToString();
						tu.Branch = branch;
						
					}
					}
				else
				{
					UI.ShowErrorMessage(null, "Terminal ID does not exists", "Error");
					return null;
				}

				
				return tu;
			}
			catch (Exception ex)
			{
				UI.ShowErrorMessage(null, ex.Message, "Error");
				return null;
			}

		}
	
		public bool Check_Concurrent()
		{
			int nLicenseNo = 0;
			try
			{
				DataSet _ds1 = new DataSet(); 
				DataTable dt1 = _ds1.Tables["Table"];

				string strSQL1 ="select top 1 strLicenseNo from TblCompany";
				SqlHelper.FillDataset(SqlHelperUtils.connectionString,CommandType.StoredProcedure,"UP_GETDATA",_ds1,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL1) );
						
				if(_ds1.Tables[0].Rows.Count>0)
				{
					foreach(DataRow dr1 in _ds1.Tables[0].Rows)
					{
						AesWinApp.Decipher ChkLicense= new AesWinApp.Decipher();
						nLicenseNo=ChkLicense.Decipher_License(dr1[0].ToString());
					}
				}
			
				DataSet _ds2 = new DataSet(); 
				DataTable dt2 = _ds2.Tables["Table"];

				string strSQL2 ="select distinct count(*) from Master..sysprocesses where spid > 50 and program_Name='AIMS' and lastwaittype='NETWORKIO'";
				SqlHelper.FillDataset(SqlHelperUtils.connectionString,CommandType.StoredProcedure,"UP_GETDATA",_ds2,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL2) );
				
				if(_ds2.Tables[0].Rows.Count>0)
				{
					foreach(DataRow dr2 in _ds2.Tables[0].Rows)
					{
						if (ACMS.Convert.ToInt32(dr2[0])< nLicenseNo )
								return true;
								break;
//						UI.ShowMessage(dr2[0].ToString());
					}
				}
			}
			catch (Exception ex)
			{
				//UI.ShowMessage(ex.Message);
			}
		//	dtBankMerchant = _ds.Tables["table"];
			
			return false;
		}

		public Employee GetEmployeeByIdAndPassword(string employeeId,string password)
		{
			Employee emp = null;
			Department dpt = null;
			JobPosition jpos = null;
			EmployeeBranchRights ebr = null;
			try
			{
				SqlParameter param1 = new SqlParameter("nEmployeeID", employeeId);
				SqlParameter param2 = new SqlParameter("strPassword", password);
				DataSet dsEmployee = SqlHelper.ExecuteDataset(SqlHelperUtils.connectionString, "sp_GetEmployeeByIdAndPassword", param1, param2);
			
				if(dsEmployee.Tables[0].Rows.Count>0)
				{
					emp = new Employee();
					dpt = new Department();
					jpos = new JobPosition();
					foreach(DataRow dr in dsEmployee.Tables[0].Rows)
					{
						emp.Id = Convert.ToInt32(dr["nEmployeeID"].ToString());
						dpt.Id =  Convert.ToInt32(dr["nDepartmentId"].ToString());
						emp.StrEmployeeName = dr["strEmployeeName"].ToString();
                        emp.MobileNo = dr["strContactNo"].ToString();
						jpos.Id = dr["strJobPositionCode"].ToString();

						emp.Department = dpt;
						emp.JobPosition = jpos;

					}
				}
				else
				{
					return null;
				}

				if(dsEmployee.Tables[1].Rows.Count>0)
				{
					foreach(DataRow dr in dsEmployee.Tables[1].Rows)
					{
						ebr = new EmployeeBranchRights();
						Employee _emp = new Employee();
						Branch _branch = new Branch();
						_emp.Id = Convert.ToInt32(dr["nEmployeeID"].ToString());
						_branch.Id = dr["strBranchCode"].ToString();

						ebr.Employee = _emp;
						ebr.Branch = _branch;
						emp.EmployeeBranchRights.Add(ebr);
					}
				}

				if(dsEmployee.Tables[2].Rows.Count>0)
				{
					RightsLevel _rl = new RightsLevel();
					foreach(DataRow dr in dsEmployee.Tables[2].Rows)
					{
						Right _r = new Right();
						
						RightsLevelEntry _rle = new RightsLevelEntry();

						_r.Id = Convert.ToInt32(dr["nRightsID"].ToString());
						_r.StrDescription = dr["strDescription"].ToString();
						_rl.Id = Convert.ToInt32(dr["nRightsLevelID"].ToString());

						_rle.Right = _r;
						_rle.RightsLevel = _rl;
						
						_rl.RightsLevelEntrys.Add(_rle);

					}
					emp.RightsLevel = _rl;
				}

				return emp;
			}
			catch (Exception ex)
			{
				UI.ShowErrorMessage(null, ex.Message, "Error");
				return null;
			}

		}
	}
}
