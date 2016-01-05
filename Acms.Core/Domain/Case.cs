using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region Case
	
	/// <summary>
	/// Case object for NHibernate mapped table 'tblCase'.
	/// </summary>
	public class Case
	{
		#region Member Variables
		
		protected int _id;
		protected DateTime _dtDate;
		protected DateTime _dtLastEditDate;
		protected int _nStatusID;
		protected string _strSubject;
		protected string _strDetails;
		protected Branch _branch;
		protected CaseCategory _caseCategory;
		protected CaseType _caseType;
		protected Department _department;
		protected Department _departmentnDepartmentAssignedID;
		protected Employee _employeenSubmittedByID;
		protected Employee _employee;
		protected Member _member;
		protected IList _caseActions = new ArrayList();

		#endregion
		
		#region Constructors
		
		public Case() { }
		
		public Case( DateTime dtDate, DateTime dtLastEditDate, int nStatusID, string strSubject, string strDetails, Branch branch, CaseCategory caseCategory, CaseType caseType, Department department, Department departmentnDepartmentAssignedID, Employee employeenSubmittedByID, Employee employee, Member member )
		{
			this._dtDate = dtDate;
			this._dtLastEditDate = dtLastEditDate;
			this._nStatusID = nStatusID;
			this._strSubject = strSubject;
			this._strDetails = strDetails;
			this._branch = branch;
			this._caseCategory = caseCategory;
			this._caseType = caseType;
			this._department = department;
			this._departmentnDepartmentAssignedID = departmentnDepartmentAssignedID;
			this._employeenSubmittedByID = employeenSubmittedByID;
			this._employee = employee;
			this._member = member;
		}
		
		#endregion		

		#region Public Properties
		
		public int Id
		{
			get {return _id;}
			set {_id = value;}
		}

		public DateTime DtDate
		{
			get { return _dtDate; }
			set { _dtDate = value; }
		}
		
		public DateTime DtLastEditDate
		{
			get { return _dtLastEditDate; }
			set { _dtLastEditDate = value; }
		}
		
		public int NStatusID
		{
			get { return _nStatusID; }
			set { _nStatusID = value; }
		}
		
		public string StrSubject
		{
			get { return _strSubject; }
			set { _strSubject = value; }
		}
		
		public string StrDetails
		{
			get { return _strDetails; }
			set { _strDetails = value; }
		}
		
		public Branch Branch
		{
			get { return _branch; }
			set { _branch = value; }
		}

		public CaseCategory CaseCategory
		{
			get { return _caseCategory; }
			set { _caseCategory = value; }
		}

		public CaseType CaseType
		{
			get { return _caseType; }
			set { _caseType = value; }
		}

		public Department Department
		{
			get { return _department; }
			set { _department = value; }
		}

		public Department DepartmentnDepartmentAssignedID
		{
			get { return _departmentnDepartmentAssignedID; }
			set { _departmentnDepartmentAssignedID = value; }
		}

		public Employee EmployeenSubmittedByID
		{
			get { return _employeenSubmittedByID; }
			set { _employeenSubmittedByID = value; }
		}

		public Employee Employee
		{
			get { return _employee; }
			set { _employee = value; }
		}

		public Member Member
		{
			get { return _member; }
			set { _member = value; }
		}

		public IList CaseActions
		{
			get { return _caseActions; }
			set { _caseActions = value; }
		}
		
		public void AddCaseAction(CaseAction _caseAction)
		{
			_caseAction.Case = this;
			_caseActions.Add(_caseAction);
		}

		#endregion
	}
	
	#endregion
}
