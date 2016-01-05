using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region Shift
	
	/// <summary>
	/// Shift object for NHibernate mapped table 'tblShift'.
	/// </summary>
	public class Shift
	{
		#region Member Variables

		protected string _id;

		protected DateTime _dtDate;
		protected int _nTerminalID;
		protected int _nShiftID;

		protected DateTime _dtOpenTime;
		protected DateTime _dtCloseTime;
		protected decimal _mOpeningFloat;
		protected decimal _mClosingFloat;
		protected string _strRemarks;
		protected Branch _branch;
		protected Employee _employeenOpenShiftStaffID;
		protected Employee _employeenCloseShiftStaffID;
		protected Employee _employeenVerifyStaffID;

		#endregion
		
		#region Constructors
		
		public Shift() { }
		
		public Shift(DateTime dtDate, int nTerminalID, int nShiftID, DateTime dtOpenTime, DateTime dtCloseTime, decimal mOpeningFloat, decimal mClosingFloat, string strRemarks, Branch branch, Employee employeenOpenShiftStaffID, Employee employeenCloseShiftStaffID, Employee employeenVerifyStaffID )
		{
			this._dtDate = dtDate;
			this._nTerminalID = nTerminalID;
			this._nShiftID = nShiftID;
			this._dtOpenTime = dtOpenTime;
			this._dtCloseTime = dtCloseTime;
			this._mOpeningFloat = mOpeningFloat;
			this._mClosingFloat = mClosingFloat;
			this._strRemarks = strRemarks;
			this._branch = branch;
			this._employeenOpenShiftStaffID = employeenOpenShiftStaffID;
			this._employeenCloseShiftStaffID = employeenCloseShiftStaffID;
			this._employeenVerifyStaffID = employeenVerifyStaffID;
		}
		
		#endregion		

		#region Public Properties
		
		public string Id
		{
			get {return _id;}
			set {_id = value;}
		}

		public DateTime DtDate
		{
			get { return _dtDate; }
			set { _dtDate = value; }
		}

		public int NTerminalID
		{
			get {return _nTerminalID;}
			set {_nTerminalID = value;}
		}

		public int NShiftID
		{
			get {return _nShiftID;}
			set {_nShiftID = value;}
		}

		public DateTime DtOpenTime
		{
			get { return _dtOpenTime; }
			set { _dtOpenTime = value; }
		}
		
		public DateTime DtCloseTime
		{
			get { return _dtCloseTime; }
			set { _dtCloseTime = value; }
		}
		
		public decimal MOpeningFloat
		{
			get { return _mOpeningFloat; }
			set { _mOpeningFloat = value; }
		}
		
		public decimal MClosingFloat
		{
			get { return _mClosingFloat; }
			set { _mClosingFloat = value; }
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

		public Employee EmployeenOpenShiftStaffID
		{
			get { return _employeenOpenShiftStaffID; }
			set { _employeenOpenShiftStaffID = value; }
		}

		public Employee EmployeenCloseShiftStaffID
		{
			get { return _employeenCloseShiftStaffID; }
			set { _employeenCloseShiftStaffID = value; }
		}

		public Employee EmployeenVerifyStaffID
		{
			get { return _employeenVerifyStaffID; }
			set { _employeenVerifyStaffID = value; }
		}

		#endregion
	}
	
	#endregion
}
