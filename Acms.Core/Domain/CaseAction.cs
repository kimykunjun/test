using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region CaseAction
	
	/// <summary>
	/// CaseAction object for NHibernate mapped table 'tblCaseAction'.
	/// </summary>
	public class CaseAction
	{
		#region Member Variables
		
		protected int _id;
		protected DateTime _dtDate;
		protected string _strActionDetails;
		protected Case _case;
		protected CaseMode _caseMode;
		protected Employee _employeenActionByID;

		#endregion
		
		#region Constructors
		
		public CaseAction() { }
		
		public CaseAction( DateTime dtDate, string strActionDetails, Case cases, CaseMode caseMode, Employee employeenActionByID )
		{
			this._dtDate = dtDate;
			this._strActionDetails = strActionDetails;
			this._case = cases;
			this._caseMode = caseMode;
			this._employeenActionByID = employeenActionByID;
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
		
		public string StrActionDetails
		{
			get { return _strActionDetails; }
			set { _strActionDetails = value; }
		}
		
		public Case Case
		{
			get { return _case; }
			set { _case = value; }
		}

		public CaseMode CaseMode
		{
			get { return _caseMode; }
			set { _caseMode = value; }
		}

		public Employee EmployeenActionByID
		{
			get { return _employeenActionByID; }
			set { _employeenActionByID = value; }
		}

		#endregion
	}
	
	#endregion
}
