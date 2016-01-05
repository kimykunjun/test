using System;

namespace Acms.Core.Domain
{
	/// <summary>
	/// Summary description for EmployeeBranchRights.
	/// </summary>
	public class EmployeeBranchRights
	{
		protected Branch _branch;
		protected Employee _employee;

		public EmployeeBranchRights()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public EmployeeBranchRights(Branch branch, Employee employee)
		{
			this._branch = branch;
			this._employee = employee;
		}

		public Branch Branch
		{
			set{_branch = value;}
			get{return _branch;}
		}

		public Employee Employee
		{
			set{_employee = value;}
			get{return _employee;}
		}
	}
}
