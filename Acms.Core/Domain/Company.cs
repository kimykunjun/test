using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region Company
	
	/// <summary>
	/// Company object for NHibernate mapped table 'tblCompany'.
	/// </summary>
	public class Company
	{
		#region Member Variables
		
		protected string _id;
		protected string _strCompanyName;
		protected decimal _mForgetCardRate;
		protected decimal _mReplaceCardRate;
		protected decimal _mRegistrationFees;
		protected string _strBankCode;
		protected string _strBranchCode;
		protected string _strAccountNo;
		protected string _strAccountName;
		protected int _strBatchNo;
		protected string _strCompanyCodeRef;
		protected string _strCompanyID;
		protected string _strCPFReferenceNo;
		protected int _nCancelBookingLimit;
		protected int _nUOBMonthlyBooking;
		protected DateTime _dtUOBWeekdayPeakStart;
		protected DateTime _dtUOBWeekdayPeakEnd;
		protected DateTime _dtUOBWeekendPeakStart;
		protected DateTime _dtUOBWeekendPeakEnd;
		protected Tax _tax;

		#endregion
		
		#region Constructors
		
		public Company() { }
		
		public Company( string strCompanyName, decimal mForgetCardRate, decimal mReplaceCardRate, decimal mRegistrationFees, string strBankCode, string strBranchCode, string strAccountNo, string strAccountName, int strBatchNo, string strCompanyCodeRef, string strCompanyID, string strCPFReferenceNo, int nCancelBookingLimit, int nUOBMonthlyBooking, DateTime dtUOBWeekdayPeakStart, DateTime dtUOBWeekdayPeakEnd, DateTime dtUOBWeekendPeakStart, DateTime dtUOBWeekendPeakEnd, Tax tax )
		{
			this._strCompanyName = strCompanyName;
			this._mForgetCardRate = mForgetCardRate;
			this._mReplaceCardRate = mReplaceCardRate;
			this._mRegistrationFees = mRegistrationFees;
			this._strBankCode = strBankCode;
			this._strBranchCode = strBranchCode;
			this._strAccountNo = strAccountNo;
			this._strAccountName = strAccountName;
			this._strBatchNo = strBatchNo;
			this._strCompanyCodeRef = strCompanyCodeRef;
			this._strCompanyID = strCompanyID;
			this._strCPFReferenceNo = strCPFReferenceNo;
			this._nCancelBookingLimit = nCancelBookingLimit;
			this._nUOBMonthlyBooking = nUOBMonthlyBooking;
			this._dtUOBWeekdayPeakStart = dtUOBWeekdayPeakStart;
			this._dtUOBWeekdayPeakEnd = dtUOBWeekdayPeakEnd;
			this._dtUOBWeekendPeakStart = dtUOBWeekendPeakStart;
			this._dtUOBWeekendPeakEnd = dtUOBWeekendPeakEnd;
			this._tax = tax;
		}
		
		#endregion		

		#region Public Properties
		
		public string Id
		{
			get {return _id;}
			set {_id = value;}
		}

		public string StrCompanyName
		{
			get { return _strCompanyName; }
			set { _strCompanyName = value; }
		}
		
		public decimal MForgetCardRate
		{
			get { return _mForgetCardRate; }
			set { _mForgetCardRate = value; }
		}
		
		public decimal MReplaceCardRate
		{
			get { return _mReplaceCardRate; }
			set { _mReplaceCardRate = value; }
		}
		
		public decimal MRegistrationFees
		{
			get { return _mRegistrationFees; }
			set { _mRegistrationFees = value; }
		}
		
		public string StrBankCode
		{
			get { return _strBankCode; }
			set { _strBankCode = value; }
		}
		
		public string StrBranchCode
		{
			get { return _strBranchCode; }
			set { _strBranchCode = value; }
		}
		
		public string StrAccountNo
		{
			get { return _strAccountNo; }
			set { _strAccountNo = value; }
		}
		
		public string StrAccountName
		{
			get { return _strAccountName; }
			set { _strAccountName = value; }
		}
		
		public int StrBatchNo
		{
			get { return _strBatchNo; }
			set { _strBatchNo = value; }
		}
		
		public string StrCompanyCodeRef
		{
			get { return _strCompanyCodeRef; }
			set { _strCompanyCodeRef = value; }
		}
		
		public string StrCompanyID
		{
			get { return _strCompanyID; }
			set { _strCompanyID = value; }
		}
		
		public string StrCPFReferenceNo
		{
			get { return _strCPFReferenceNo; }
			set { _strCPFReferenceNo = value; }
		}
		
		public int NCancelBookingLimit
		{
			get { return _nCancelBookingLimit; }
			set { _nCancelBookingLimit = value; }
		}
		
		public int NUOBMonthlyBooking
		{
			get { return _nUOBMonthlyBooking; }
			set { _nUOBMonthlyBooking = value; }
		}
		
		public DateTime DtUOBWeekdayPeakStart
		{
			get { return _dtUOBWeekdayPeakStart; }
			set { _dtUOBWeekdayPeakStart = value; }
		}
		
		public DateTime DtUOBWeekdayPeakEnd
		{
			get { return _dtUOBWeekdayPeakEnd; }
			set { _dtUOBWeekdayPeakEnd = value; }
		}
		
		public DateTime DtUOBWeekendPeakStart
		{
			get { return _dtUOBWeekendPeakStart; }
			set { _dtUOBWeekendPeakStart = value; }
		}
		
		public DateTime DtUOBWeekendPeakEnd
		{
			get { return _dtUOBWeekendPeakEnd; }
			set { _dtUOBWeekendPeakEnd = value; }
		}
		

		public Tax Tax
		{
			get { return _tax; }
			set { _tax = value; }
		}

		#endregion
	}
	
	#endregion
}
