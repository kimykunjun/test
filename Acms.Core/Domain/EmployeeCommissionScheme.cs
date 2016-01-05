using System;

namespace Acms.Core.Domain
{
	/// <summary>
	/// Summary description for EmployeeBranchRights.
	/// </summary>
	public class EmployeeCommissionScheme
	{
		protected CommissionScheme _commissionScheme;
		protected Employee _employee;

		public EmployeeCommissionScheme()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public EmployeeCommissionScheme(CommissionScheme commissionScheme, Employee employee)
		{
			this._commissionScheme = commissionScheme;
			this._employee = employee;
		}

		public CommissionScheme CommissionScheme
		{
			set{_commissionScheme = value;}
			get{return _commissionScheme;}
		}

		public Employee Employee
		{
			set{_employee = value;}
			get{return _employee;}
		}
	}
}
