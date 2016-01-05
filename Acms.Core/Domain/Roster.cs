using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region Roster
	
	/// <summary>
	/// Roster object for NHibernate mapped table 'tblRoster'.
	/// </summary>
	public class Roster
	{
		#region Member Variables
		
		protected int _id;
		protected DateTime _dtDate;
		protected DateTime _dtStartTime;
		protected DateTime _dtEndTime;
		protected string _strRemarks;
		protected Branch _branch;
		protected Employee _employee;

		#endregion
		
		#region Constructors
		
		public Roster() { }
		
		public Roster( DateTime dtDate, DateTime dtStartTime, DateTime dtEndTime, string strRemarks, Branch branch, Employee employee )
		{
			this._dtDate = dtDate;
			this._dtStartTime = dtStartTime;
			this._dtEndTime = dtEndTime;
			this._strRemarks = strRemarks;
			this._branch = branch;
			this._employee = employee;
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
		
		public DateTime DtStartTime
		{
			get { return _dtStartTime; }
			set { _dtStartTime = value; }
		}
		
		public DateTime DtEndTime
		{
			get { return _dtEndTime; }
			set { _dtEndTime = value; }
		}
		
		public string StrRemarks
		{
			get { return _strRemarks; }
			set { _strRemarks = value; }
		}
		
		public Branch Branch
		{
			get { return _branch; }
			set { _branch = value; }
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
