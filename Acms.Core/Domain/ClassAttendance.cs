using System;
using System.Collections;


namespace Acms.Core.Domain
{
	#region ClassAttendance
	
	/// <summary>
	/// ClassAttendance object for NHibernate mapped table 'tblClassAttendance'.
	/// </summary>
	public class ClassAttendance
	{
		#region Member Variables
		
		protected int _id;
		protected DateTime _dtDate;
		protected DateTime _dtStartTime;
		protected DateTime _dtEndTime;
		protected int _nTypeID;
		protected int _nStatusID;
		protected DateTime _dtLastEditDate;
		protected bool _fUOBBooking;
		protected bool _fRefunded;
		protected Branch _branch;
		protected ClassInstance _classInstance;
		protected Employee _employee;
		protected Member _member;
		protected MemberPackage _memberPackage;

		#endregion
		
		#region Constructors
		
		public ClassAttendance() { }
		
		public ClassAttendance( DateTime dtDate, DateTime dtStartTime, DateTime dtEndTime, int nTypeID, int nStatusID, DateTime dtLastEditDate, bool fUOBBooking, bool fRefunded, Branch branch, ClassInstance classInstance, Employee employee, Member member, MemberPackage memberPackage )
		{
			this._dtDate = dtDate;
			this._dtStartTime = dtStartTime;
			this._dtEndTime = dtEndTime;
			this._nTypeID = nTypeID;
			this._nStatusID = nStatusID;
			this._dtLastEditDate = dtLastEditDate;
			this._fUOBBooking = fUOBBooking;
			this._fRefunded = fRefunded;
			this._branch = branch;
			this._classInstance = classInstance;
			this._employee = employee;
			this._member = member;
			this._memberPackage = memberPackage;
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
		
		public bool FUOBBooking
		{
			get { return _fUOBBooking; }
			set { _fUOBBooking = value; }
		}
		
		public bool FRefunded
		{
			get { return _fRefunded; }
			set { _fRefunded = value; }
		}
		
		public Branch Branch
		{
			get { return _branch; }
			set { _branch = value; }
		}

		public ClassInstance ClassInstance
		{
			get { return _classInstance; }
			set { _classInstance = value; }
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

		public MemberPackage MemberPackage
		{
			get { return _memberPackage; }
			set { _memberPackage = value; }
		}

		#endregion
	}
	
	#endregion
}
