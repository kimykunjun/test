using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region Audit
	
	/// <summary>
	/// Audit object for NHibernate mapped table 'tblAudit'.
	/// </summary>
	public class Audit
	{
		#region Member Variables
		
		protected int _id;
		protected int _nAuditTypeID;
		protected string _strReference;
		protected string _strAuditEntry;
		protected DateTime _dtDate;
		protected Employee _employee;

		#endregion
		
		#region Constructors
		
		public Audit() { }
		
		public Audit( int nAuditTypeID, string strReference, string strAuditEntry, DateTime dtDate, Employee employee )
		{
			this._nAuditTypeID = nAuditTypeID;
			this._strReference = strReference;
			this._strAuditEntry = strAuditEntry;
			this._dtDate = dtDate;
			this._employee = employee;
		}
		
		#endregion		

		#region Public Properties
		
		public int Id
		{
			get {return _id;}
			set {_id = value;}
		}

		public int NAuditTypeID
		{
			get { return _nAuditTypeID; }
			set { _nAuditTypeID = value; }
		}
		
		public string StrReference
		{
			get { return _strReference; }
			set { _strReference = value; }
		}
		
		public string StrAuditEntry
		{
			get { return _strAuditEntry; }
			set { _strAuditEntry = value; }
		}
		
		public DateTime DtDate
		{
			get { return _dtDate; }
			set { _dtDate = value; }
		}
		
		public Employee Employee
		{
			get { return _employee; }
			set { _employee = value; }
		}

		#endregion
	}
	
	#endregion
}
