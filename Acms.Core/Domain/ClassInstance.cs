using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region ClassInstance
	
	/// <summary>
	/// ClassInstance object for NHibernate mapped table 'tblClassInstance'.
	/// </summary>
	public class ClassInstance
	{
		#region Member Variables
		
		protected int _id;
		protected DateTime _dtDate;
		protected DateTime _dtStartTime;
		protected DateTime _dtEndTime;
		protected int _nHallNo;
		protected bool _fFree;
		protected bool _fPeak;
		protected bool _fReservation;
		protected int _nMaxNo;
		protected bool _fAllowUOBBooking;
		protected DateTime _dtReplacementIssueDate;
		protected DateTime _dtReplacementVerifyDate;
		protected DateTime _dtInstructorLogin;
		protected decimal _mStandinInstructorFees;
		protected bool _fCancelled;
		protected string _strRemarks;
		protected decimal _mInstructorFees;
		protected bool _fTraineeClass;
		protected decimal _mInstructorDeduction;
		protected Employee _employeenReplacementIssueID;
		protected Employee _employeenReplacementVerifyID;
		protected Employee _employeenActualInstructorID;
		protected Employee _employeenStandinInstructorID;
		protected Employee _employeenVerifyID;
		protected InstructorTypeCommission _instructorTypeCommission;
		protected Branch _branch;
		protected Class _class;
		protected Employee _employeenPermanentInstructorID;
		protected Employee _employeenReplacementInstructorID;
		protected IList _classAttendances = new ArrayList();
		protected int _nClassSchedule;
		

		#endregion
		
		#region Constructors
		
		public ClassInstance() { }
		
		public ClassInstance( DateTime dtDate, DateTime dtStartTime, DateTime dtEndTime, int nHallNo, bool fFree, bool fPeak, bool fReservation, int nMaxNo, bool fAllowUOBBooking, DateTime dtReplacementIssueDate, DateTime dtReplacementVerifyDate, DateTime dtInstructorLogin, decimal mStandinInstructorFees, bool fCancelled, string strRemarks, decimal mInstructorFees, bool fTraineeClass, decimal mInstructorDeduction, Employee employeenReplacementIssueID, Employee employeenReplacementVerifyID, Employee employeenActualInstructorID, Employee employeenStandinInstructorID, Employee employeenVerifyID, InstructorTypeCommission instructorTypeCommission, Branch branch, Class classd, Employee employeenPermanentInstructorID, Employee employeenReplacementInstructorID,int nClassSchedule)
		{
			this._dtDate = dtDate;
			this._dtStartTime = dtStartTime;
			this._dtEndTime = dtEndTime;
			this._nHallNo = nHallNo;
			this._fFree = fFree;
			this._fPeak = fPeak;
			this._fReservation = fReservation;
			this._nMaxNo = nMaxNo;
			this._fAllowUOBBooking = fAllowUOBBooking;
			this._dtReplacementIssueDate = dtReplacementIssueDate;
			this._dtReplacementVerifyDate = dtReplacementVerifyDate;
			this._dtInstructorLogin = dtInstructorLogin;
			this._mStandinInstructorFees = mStandinInstructorFees;
			this._fCancelled = fCancelled;
			this._strRemarks = strRemarks;
			this._mInstructorFees = mInstructorFees;
			this._fTraineeClass = fTraineeClass;
			this._mInstructorDeduction = mInstructorDeduction;
			this._employeenReplacementIssueID = employeenReplacementIssueID;
			this._employeenReplacementVerifyID = employeenReplacementVerifyID;
			this._employeenActualInstructorID = employeenActualInstructorID;
			this._employeenStandinInstructorID = employeenStandinInstructorID;
			this._employeenVerifyID = employeenVerifyID;
			this._instructorTypeCommission = instructorTypeCommission;
			this._branch = branch;
			this._class = classd;
			this._employeenPermanentInstructorID = employeenPermanentInstructorID;
			this._employeenReplacementInstructorID = employeenReplacementInstructorID;
			this._nClassSchedule=nClassSchedule;
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
		
		public int NHallNo
		{
			get { return _nHallNo; }
			set { _nHallNo = value; }
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
		
		public DateTime DtReplacementIssueDate
		{
			get { return _dtReplacementIssueDate; }
			set { _dtReplacementIssueDate = value; }
		}
		
		public DateTime DtReplacementVerifyDate
		{
			get { return _dtReplacementVerifyDate; }
			set { _dtReplacementVerifyDate = value; }
		}
		
		public DateTime DtInstructorLogin
		{
			get { return _dtInstructorLogin; }
			set { _dtInstructorLogin = value; }
		}
		
		public decimal MStandinInstructorFees
		{
			get { return _mStandinInstructorFees; }
			set { _mStandinInstructorFees = value; }
		}
		
		public bool FCancelled
		{
			get { return _fCancelled; }
			set { _fCancelled = value; }
		}
		
		public string StrRemarks
		{
			get { return _strRemarks; }
			set { _strRemarks = value; }
		}
		
		public decimal MInstructorFees
		{
			get { return _mInstructorFees; }
			set { _mInstructorFees = value; }
		}
		
		public bool FTraineeClass
		{
			get { return _fTraineeClass; }
			set { _fTraineeClass = value; }
		}
		
		public decimal MInstructorDeduction
		{
			get { return _mInstructorDeduction; }
			set { _mInstructorDeduction = value; }
		}
		
		public Employee EmployeenReplacementIssueID
		{
			get { return _employeenReplacementIssueID; }
			set { _employeenReplacementIssueID = value; }
		}

		public Employee EmployeenReplacementVerifyID
		{
			get { return _employeenReplacementVerifyID; }
			set { _employeenReplacementVerifyID = value; }
		}

		public Employee EmployeenActualInstructorID
		{
			get { return _employeenActualInstructorID; }
			set { _employeenActualInstructorID = value; }
		}

		public Employee EmployeenStandinInstructorID
		{
			get { return _employeenStandinInstructorID; }
			set { _employeenStandinInstructorID = value; }
		}

		public Employee EmployeenVerifyID
		{
			get { return _employeenVerifyID; }
			set { _employeenVerifyID = value; }
		}

		public InstructorTypeCommission InstructorTypeCommission
		{
			get { return _instructorTypeCommission; }
			set { _instructorTypeCommission = value; }
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

		public Employee EmployeenPermanentInstructorID
		{
			get { return _employeenPermanentInstructorID; }
			set { _employeenPermanentInstructorID = value; }
		}

		public Employee EmployeenReplacementInstructorID
		{
			get { return _employeenReplacementInstructorID; }
			set { _employeenReplacementInstructorID = value; }
		}

		public IList ClassAttendances
		{
			get { return _classAttendances; }
			set { _classAttendances = value; }
		}

		public void AddClassAttendance(ClassAttendance classAttendance)
		{
			classAttendance.ClassInstance = this;
			_classAttendances.Add(classAttendance);
		}
		
			
		public int nClassSchedule
		{
			get { return _nClassSchedule; }
			set { _nClassSchedule = value; }
		}
		#endregion
	}
	
	#endregion
}
