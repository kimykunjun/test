using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using Acms.Core.Domain;
using ACMS.Utils;
using System.Configuration;

namespace ACMSLogic.Bulletin
{
	/// <summary>
	/// Summary description for Employee.
	/// </summary>
	public class Employee
	{
		public Employee()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public Acms.Core.Domain.Employee GetEmployee(int nEmployeeId)
		{
			SqlParameter param1 = new SqlParameter("nEmployeeId", nEmployeeId);
			try
			{
				DataSet ds = SqlHelper.ExecuteDataset(SqlHelperUtils.connectionString, "SP_GetEmployee",param1);
				if(ds!=null)
				{
					if(ds.Tables[0].Rows.Count>0)
					{
						Acms.Core.Domain.Employee emp = new Acms.Core.Domain.Employee();
						foreach(DataRow dr in ds.Tables[0].Rows)
						{
							emp.Id=Convert.ToInt32(dr["nEmployeeId"].ToString());
							emp.StrEmployeeName = dr["strEmployeeName"].ToString();
						}
						return emp;
					}
				}
				return null;
			}
			catch(Exception err)
			{
				UI.ShowErrorMessage(null, err.Message, "Error");
				return null;
			}
		}

	}
}
