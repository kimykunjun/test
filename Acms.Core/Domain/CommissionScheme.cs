using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region CommissionScheme
	
	/// <summary>
	/// CommissionScheme object for NHibernate mapped table 'tblCommissionScheme'.
	/// </summary>
	public class CommissionScheme
	{
		#region Member Variables
		
		protected string _id;
		protected string _strDescription;
		protected DateTime _dtLastEditDate;
		protected IList _employeeCommissionSchemes = new ArrayList();
		protected SalesCategory _salesCategory;
		protected IList _commissionSchemeEntrys = new ArrayList();
		protected IList _employees = new ArrayList();
		protected Employee _employee;

		#endregion
		
		#region Constructors
		
		public CommissionScheme() { }
		
		public CommissionScheme( string strDescription, DateTime dtLastEditDate, Employee employee, SalesCategory salesCategory )
		{
			this._strDescription = strDescription;
			this._dtLastEditDate = dtLastEditDate;
			this._employee = employee;
			this._salesCategory = salesCategory;
		}
		
		#endregion		

		#region Public Properties
		
		public string Id
		{
			get {return _id;}
			set {_id = value;}
		}

		public string StrDescription
		{
			get { return _strDescription; }
			set { _strDescription = value; }
		}
		
		public DateTime DtLastEditDate
		{
			get { return _dtLastEditDate; }
			set { _dtLastEditDate = value; }
		}
		
		public IList EmployeeCommissionSchemes
		{
			get { return _employeeCommissionSchemes; }
			set { _employeeCommissionSchemes = value; }
		}

		public SalesCategory SalesCategory
		{
			get { return _salesCategory; }
			set { _salesCategory = value; }
		}

		public IList CommissionSchemeEntrys
		{
			get { return _commissionSchemeEntrys; }
			set { _commissionSchemeEntrys = value; }
		}

		public Employee Employee
		{
			get { return _employee; }
			set { _employee = value; }
		}
		
		public IList Employees
		{
			get { return _employees; }
			set { _employees = value; }
		}

		public void AddCommissionSchemeEntry(CommissionSchemeEntry commissionSchemeEntry)
		{
			commissionSchemeEntry.CommissionScheme = this;
			_commissionSchemeEntrys.Add(commissionSchemeEntry);
			
		}

		public void AddEmployeeCommissionScheme(EmployeeCommissionScheme employeeCommissionScheme)
		{
			employeeCommissionScheme.CommissionScheme = this;
			_employeeCommissionSchemes.Add(employeeCommissionScheme);
			
		}
		
		#endregion
	}
	
	#endregion
}
