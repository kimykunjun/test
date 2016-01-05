using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region Department
	
	/// <summary>
	/// Department object for NHibernate mapped table 'tblDepartment'.
	/// </summary>
	public class Department
	{
		#region Member Variables
		
		protected int _id;
		protected string _strDescription;
		protected IList _employees = new ArrayList();
		protected IList _cases = new ArrayList();
		protected IList _casesnDepartmentAssignedID = new ArrayList();

		#endregion
		
		#region Constructors
		
		public Department() { }
		
		public Department( string strDescription )
		{
			this._strDescription = strDescription;
		}
		
		#endregion		

		#region Public Properties
		
		public virtual int Id
		{
			get {return _id;}
			set {_id = value;}
		}

		public virtual string StrDescription
		{
			get { return _strDescription; }
			set { _strDescription = value; }
		}
		
		public IList Employees
		{
			get { return _employees; }
			set { _employees = value; }
		}

		public void AddEmployee(Employee employee)
		{
			employee.Department = this;
			_employees.Add(employee);
		}
		
		public IList Cases
		{
			get { return _cases; }
			set { _cases = value; }
		}

		public void AddCases(Case cases)
		{
			cases.Department = this;
			_cases.Add(cases);
		}
		
		public IList CasesnDepartmentAssignedID
		{
			get { return _casesnDepartmentAssignedID; }
			set { _casesnDepartmentAssignedID = value; }
		}
		
		public void AddCasesnDepartmentAssignedID(Case CasesnDepartmentAssignedID)
		{
			CasesnDepartmentAssignedID.DepartmentnDepartmentAssignedID = this;
			_casesnDepartmentAssignedID.Add(CasesnDepartmentAssignedID);
		}
		#endregion
	}
	
	#endregion
}
