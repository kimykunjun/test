using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region ClassSchedule
	
	/// <summary>
	/// ClassSchedule object for NHibernate mapped table 'tblClassSchedule'.
	/// </summary>
	public class ClassSchedule
	{
		#region Member Variables
		
		protected int _nClassScheduleID;
		protected int _nHallNo;
		protected int _nDay;
		protected DateTime _dtStartTime;
		protected DateTime _dtEndTime;
		protected bool _fFree;
		protected bool _fPeak;
		protected bool _fReservation;
		protected int _nMaxNo;
		protected bool _fAllowUOBBooking;
		protected Branch _branch;
		protected Class _class;
		protected Employee _employeenInstructorID;
		protected InstructorTypeCommission _instructorTypeCommission;

		#endregion
		
		#region Constructors
		
		public ClassSchedule() { }
		
		public ClassSchedule( int nClassSchedule,int nHallNo,int nDay, DateTime dtStartTime, DateTime dtEndTime, bool fFree, bool fPeak, bool fReservation, int nMaxNo, bool fAllowUOBBooking, Branch branch, Class classd, Employee employeenInstructorID, InstructorTypeCommission instructorTypeCommission )
//		public ClassSchedule( ClassScheduleId Id,DateTime dtEndTime, bool fFree, bool fPeak, bool fReservation, int nMaxNo, bool fAllowUOBBooking, Branch branch, Class classd, Employee employeenInstructorID, InstructorTypeCommission instructorTypeCommission )
		{
			this._nClassScheduleID=nClassSchedule;
			this._nHallNo = nHallNo;
			this._nDay = nDay;
			this._dtStartTime = dtStartTime;
			this._dtEndTime = dtEndTime;
			this._fFree = fFree;
			this._fPeak = fPeak;
			this._fReservation = fReservation;
			this._nMaxNo = nMaxNo;
			this._fAllowUOBBooking = fAllowUOBBooking;
			this._branch = branch;
			this._class = classd;
			this._employeenInstructorID = employeenInstructorID;
			this._instructorTypeCommission = instructorTypeCommission;
		}
		
		#endregion		

		#region Public Properties

		public int nClassScheduleID
		{
			get {return _nClassScheduleID;}
			set {_nClassScheduleID = value;}
		}

		public int NDay
		{
			get {return _nDay;}
			set {_nDay = value;}
		}

		public int NHallNo
		{
			get {return _nHallNo;}
			set {_nHallNo = value;}
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
		
		public bool FFree
		{
			get { return _fFree; }
			set { _fFree = value; }
		}
		
		public bool FPeak
		{
			get { return _fPeak; }
			set { _fPeak = value; }
		}
		
		public bool FReservation
		{
			get { return _fReservation; }
			set { _fReservation = value; }
		}
		
		public int NMaxNo
		{
			get { return _nMaxNo; }
			set { _nMaxNo = value; }
		}
		
		public bool FAllowUOBBooking
		{
			get { return _fAllowUOBBooking; }
			set { _fAllowUOBBooking = value; }
		}
		
		public Branch Branch
		{
			get { return _branch; }
			set { _branch = value; }
		}

		public Class Class
		{
			get { return _class; }
			set { _class = value; }
		}

		public Employee EmployeenInstructorID
		{
			get { return _employeenInstructorID; }
			set { _employeenInstructorID = value; }
		}

		public InstructorTypeCommission InstructorTypeCommission
		{
			get { return _instructorTypeCommission; }
			set { _instructorTypeCommission = value; }
		}

		#endregion
	}
	
	#endregion
}
