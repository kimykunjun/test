using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region Leave
	
	/// <summary>
	/// Leave object for NHibernate mapped table 'tblLeave'.
	/// </summary>
	public class Leave
	{
		#region Member Variables
		
		protected int _id;
		protected DateTime _dtDate;
		protected int _nYearID;
		protected string _strRemarks;
		protected int _nTypeID;
		protected int _nStatusID;
		protected DateTime _dtLastEditDate;
		protected DateTime _dtStartTime;
		protected DateTime _dtEndTime;
		protected double _nQuantity;
		protected Employee _employee;
		protected Employee _employeenEditID;
		protected LeaveType _leaveType;

		#endregion
		
		#region Constructors
		
		public Leave() { }
		
		public Leave( DateTime dtDate, int nYearID, string strRemarks, int nTypeID, int nStatusID, DateTime dtLastEditDate, DateTime dtStartTime, DateTime dtEndTime, double nQuantity, Employee employee, Employee employeenEditID, LeaveType leaveType )
		{
			this._dtDate = dtDate;
			this._nYearID = nYearID;
			this._strRemarks = strRemarks;
			this._nTypeID = nTypeID;
			this._nStatusID = nStatusID;
			this._dtLastEditDate = dtLastEditDate;
			this._dtStartTime = dtStartTime;
			this._dtEndTime = dtEndTime;
			this._nQuantity = nQuantity;
			this._employee = employee;
			this._employeenEditID = employeenEditID;
			this._leaveType = leaveType;
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
		
		public int NYearID
		{
			get { return _nYearID; }
			set { _nYearID = value; }
		}
		
		public string StrRemarks
		{
			get { return _strRemarks; }
			set { _strRemarks = value; }
		}
		
		public int NTypeID
		{
			get { return _nTypeID; }
			set { _nTypeID = value; }
		}
		
		public int NStatusID
		{
			get { return _nStatusID; }
			set { _nStatusID = value; }
		}
		
		public DateTime DtLastEditDate
		{
			get { return _dtLastEditDate; }
			set { _dtLastEditDate = value; }
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
		
		public double NQuantity
		{
			get { return _nQuantity; }
			set { _nQuantity = value; }
		}
		
		public Employee Employee
		{
			get { return _employee; }
			set { _employee = value; }
		}

		public Employee EmployeenEditID
		{
			get { return _employeenEditID; }
			set { _employeenEditID = value; }
		}

		public LeaveType LeaveType
		{
			get { return _leaveType; }
			set { _leaveType = value; }
		}

		#endregion
	}
	
	#endregion
}
