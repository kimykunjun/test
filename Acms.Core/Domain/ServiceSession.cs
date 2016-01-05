using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region ServiceSession
	
	/// <summary>
	/// ServiceSession object for NHibernate mapped table 'tblServiceSession'.
	/// </summary>
	public class ServiceSession
	{
		#region Member Variables
		
		protected int _id;
		protected DateTime _dtDate;
		protected DateTime _dtStartTime;
		protected DateTime _dtEndTime;
		protected int _nStatusID;
		protected DateTime _dtLastEditDate;
		protected bool _fUOBBooking;
		protected Branch _branch;
		protected Employee _employee;
		protected Employee _employeenServiceEmployeeID;
		protected Member _member;
		protected MemberPackage _memberPackage;
		protected Service _service;

		#endregion
		
		#region Constructors
		
		public ServiceSession() { }
		
		public ServiceSession( DateTime dtDate, DateTime dtStartTime, DateTime dtEndTime, int nStatusID, DateTime dtLastEditDate, bool fUOBBooking, Branch branch, Employee employee, Employee employeenServiceEmployeeID, Member member, MemberPackage memberPackage, Service service )
		{
			this._dtDate = dtDate;
			this._dtStartTime = dtStartTime;
			this._dtEndTime = dtEndTime;
			this._nStatusID = nStatusID;
			this._dtLastEditDate = dtLastEditDate;
			this._fUOBBooking = fUOBBooking;
			this._branch = branch;
			this._employee = employee;
			this._employeenServiceEmployeeID = employeenServiceEmployeeID;
			this._member = member;
			this._memberPackage = memberPackage;
			this._service = service;
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

		public Employee EmployeenServiceEmployeeID
		{
			get { return _employeenServiceEmployeeID; }
			set { _employeenServiceEmployeeID = value; }
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

		public Service Service
		{
			get { return _service; }
			set { _service = value; }
		}

		#endregion
	}
	
	#endregion
}
