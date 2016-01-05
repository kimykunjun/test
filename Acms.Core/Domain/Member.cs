using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region Member
	
	/// <summary>
	/// Member object for NHibernate mapped table 'tblMember'.
	/// </summary>
	public class Member
	{
		#region Member Variables
		
		protected string _id;
		//protected string _strBranchCode;
		protected int _nMembershipNo;
		protected string _strMemberName;
		protected string _strCardName;
		protected string _strNRICFIN;
		protected bool _fSingaporean;
		protected bool _fMember;
		protected bool _fAirCrew;
		protected DateTime _dtDOB;
		protected string _strAddress1;
		protected string _strAddress2;
		protected string _strPostalCode;
		protected string _strHomeNo;
		protected string _strOfficeNo;
		protected string _strMobileNo;
		protected string _strPagerNo;
		protected bool _fSMS;
		protected bool _fEmail;
		protected bool _fPostalMail;
		protected string _strEmail;
		protected string _strAltEmail;
		protected int _nMediaSourceID;
		protected string _strMediaSource;
		protected string _strCompany;
		protected string _strOccupation;
		protected string _strRemarks;
		protected DateTime _dtSignupDate;
		protected string _strCreditCardNo;
		protected string _strIntroducerMembershipID;
		protected int _nCardStatusID;
		protected bool _fLockerDeposit;
		protected int _nStatus;
		protected bool _fGiroFailed;
		protected bool _fBounceCheck;

		protected Branch _branchstrCardBranchCode;
		protected Branch _strBranchCode;
		protected Employee _employeenSignupID;
		protected LoyaltyStatus _loyaltyStatus;
		
		protected IList _gIROs = new ArrayList();
		protected IList _iPPs = new ArrayList();
		protected IList _lockers = new ArrayList();
		protected IList _memberCreditPackages = new ArrayList();
		protected IList _memberPackages = new ArrayList();
		protected IList _receipts = new ArrayList();
		protected IList _cardRequests = new ArrayList();
		protected IList _rewardsTransactions = new ArrayList();
		protected IList _cases = new ArrayList();
		protected IList _serviceSessions = new ArrayList();
		protected IList _classAttendances = new ArrayList();

		#endregion
		
		#region Constructors
		
		public Member() { }
		
		public Member( int nMembershipNo, string strMemberName, string strCardName, string strNRICFIN, bool fSingaporean, bool fMember, bool fAirCrew, DateTime dtDOB, string strAddress1, string strAddress2, string strPostalCode, string strHomeNo, string strOfficeNo, string strMobileNo, string strPagerNo, bool fSMS, bool fEmail, bool fPostalMail, string strEmail, string strAltEmail, int nMediaSourceID, string strMediaSource, string strCompany, string strOccupation, string strRemarks, DateTime dtSignupDate, string strCreditCardNo, string strIntroducerMembershipID, int nCardStatusID, bool fLockerDeposit, int nStatus, bool fGiroFailed, bool fBounceCheck, Branch branchstrCardBranchCode, Employee employeenSignupID, LoyaltyStatus loyaltyStatus )
		{
			//this._strBranchCode = strBranchCode;
			this._nMembershipNo = nMembershipNo;
			this._strMemberName = strMemberName;
			this._strCardName = strCardName;
			this._strNRICFIN = strNRICFIN;
			this._fSingaporean = fSingaporean;
			this._fMember = fMember;
			this._fAirCrew = fAirCrew;
			this._dtDOB = dtDOB;
			this._strAddress1 = strAddress1;
			this._strAddress2 = strAddress2;
			this._strPostalCode = strPostalCode;
			this._strHomeNo = strHomeNo;
			this._strOfficeNo = strOfficeNo;
			this._strMobileNo = strMobileNo;
			this._strPagerNo = strPagerNo;
			this._fSMS = fSMS;
			this._fEmail = fEmail;
			this._fPostalMail = fPostalMail;
			this._strEmail = strEmail;
			this._strAltEmail = strAltEmail;
			this._nMediaSourceID = nMediaSourceID;
			this._strMediaSource = strMediaSource;
			this._strCompany = strCompany;
			this._strOccupation = strOccupation;
			this._strRemarks = strRemarks;
			this._dtSignupDate = dtSignupDate;
			this._strCreditCardNo = strCreditCardNo;
			this._strIntroducerMembershipID = strIntroducerMembershipID;
			this._nCardStatusID = nCardStatusID;
			this._fLockerDeposit = fLockerDeposit;
			this._nStatus = nStatus;
			this._fGiroFailed = fGiroFailed;
			this._fBounceCheck = fBounceCheck;
			this._branchstrCardBranchCode = branchstrCardBranchCode;
			this._employeenSignupID = employeenSignupID;
			this._loyaltyStatus = loyaltyStatus;
		}
		
		#endregion		

		#region Public Properties
		
		public virtual string Id
		{
			get {return _id;}
			set {_id = value;}
		}

//		public string StrBranchCode
//		{
//			get { return _strBranchCode; }
//			set { _strBranchCode = value; }
//		}
		
		public virtual int NMembershipNo
		{
			get { return _nMembershipNo; }
			set { _nMembershipNo = value; }
		}
		
		public virtual string StrMemberName
		{
			get { return _strMemberName; }
			set { _strMemberName = value; }
		}
		
		public virtual string StrCardName
		{
			get { return _strCardName; }
			set { _strCardName = value; }
		}
		
		public virtual string StrNRICFIN
		{
			get { return _strNRICFIN; }
			set { _strNRICFIN = value; }
		}
		
		public virtual bool FSingaporean
		{
			get { return _fSingaporean; }
			set { _fSingaporean = value; }
		}
		
		public virtual bool FMember
		{
			get { return _fMember; }
			set { _fMember = value; }
		}
		
		public virtual bool FAirCrew
		{
			get { return _fAirCrew; }
			set { _fAirCrew = value; }
		}
		
		public virtual DateTime DtDOB
		{
			get { return _dtDOB; }
			set { _dtDOB = value; }
		}
		
		public virtual string StrAddress1
		{
			get { return _strAddress1; }
			set { _strAddress1 = value; }
		}
		
		public virtual string StrAddress2
		{
			get { return _strAddress2; }
			set { _strAddress2 = value; }
		}
		
		public virtual string StrPostalCode
		{
			get { return _strPostalCode; }
			set { _strPostalCode = value; }
		}
		
		public virtual string StrHomeNo
		{
			get { return _strHomeNo; }
			set { _strHomeNo = value; }
		}
		
		public virtual string StrOfficeNo
		{
			get { return _strOfficeNo; }
			set { _strOfficeNo = value; }
		}
		
		public virtual string StrMobileNo
		{
			get { return _strMobileNo; }
			set { _strMobileNo = value; }
		}
		
		public virtual string StrPagerNo
		{
			get { return _strPagerNo; }
			set { _strPagerNo = value; }
		}
		
		public virtual bool FSMS
		{
			get { return _fSMS; }
			set { _fSMS = value; }
		}
		
		public virtual bool FEmail
		{
			get { return _fEmail; }
			set { _fEmail = value; }
		}
		
		public virtual bool FPostalMail
		{
			get { return _fPostalMail; }
			set { _fPostalMail = value; }
		}
		
		public virtual string StrEmail
		{
			get { return _strEmail; }
			set { _strEmail = value; }
		}
		
		public virtual string StrAltEmail
		{
			get { return _strAltEmail; }
			set { _strAltEmail = value; }
		}
		
		public virtual int NMediaSourceID
		{
			get { return _nMediaSourceID; }
			set { _nMediaSourceID = value; }
		}
		
		public virtual string StrMediaSource
		{
			get { return _strMediaSource; }
			set { _strMediaSource = value; }
		}
		
		public virtual string StrCompany
		{
			get { return _strCompany; }
			set { _strCompany = value; }
		}
		
		public virtual string StrOccupation
		{
			get { return _strOccupation; }
			set { _strOccupation = value; }
		}
		
		public virtual string StrRemarks
		{
			get { return _strRemarks; }
			set { _strRemarks = value; }
		}
		
		public virtual DateTime DtSignupDate
		{
			get { return _dtSignupDate; }
			set { _dtSignupDate = value; }
		}
		
		public virtual string StrCreditCardNo
		{
			get { return _strCreditCardNo; }
			set { _strCreditCardNo = value; }
		}
		
		public virtual string StrIntroducerMembershipID
		{
			get { return _strIntroducerMembershipID; }
			set { _strIntroducerMembershipID = value; }
		}
		
		public virtual int NCardStatusID
		{
			get { return _nCardStatusID; }
			set { _nCardStatusID = value; }
		}
		
		public virtual bool FLockerDeposit
		{
			get { return _fLockerDeposit; }
			set { _fLockerDeposit = value; }
		}

		public virtual int NStatus
		{
			get { return _nStatus; }
			set { _nStatus = value; }
		}
		
		public virtual bool FGiroFailed
		{
			get { return _fGiroFailed; }
			set { _fGiroFailed = value; }
		}

		public virtual bool FBounceCheck
		{
			get { return _fBounceCheck; }
			set { _fBounceCheck = value; }
		}
		public Branch StrBranchCode
		{
			get { return _strBranchCode; }
			set { _strBranchCode = value; }
		}

		public Branch BranchstrCardBranchCode
		{
			get { return _branchstrCardBranchCode; }
			set { _branchstrCardBranchCode = value; }
		}

		public Employee EmployeenSignupID
		{
			get { return _employeenSignupID; }
			set { _employeenSignupID = value; }
		}

		public LoyaltyStatus LoyaltyStatus
		{
			get { return _loyaltyStatus; }
			set { _loyaltyStatus = value; }
		}

		public IList GIROs
		{
			get { return _gIROs; }
			set { _gIROs = value; }
		}
		
		public IList IPPs
		{
			get { return _iPPs; }
			set { _iPPs = value; }
		}
		
		public IList Lockers
		{
			get { return _lockers; }
			set { _lockers = value; }
		}
		
		public IList MemberCreditPackages
		{
			get { return _memberCreditPackages; }
			set { _memberCreditPackages = value; }
		}
		
		public IList MemberPackages
		{
			get { return _memberPackages; }
			set { _memberPackages = value; }
		}
		
		public IList Receipts
		{
			get { return _receipts; }
			set { _receipts = value; }
		}
		
		public IList CardRequests
		{
			get { return _cardRequests; }
			set { _cardRequests = value; }
		}
		
		public IList RewardsTransactions
		{
			get { return _rewardsTransactions; }
			set { _rewardsTransactions = value; }
		}
		
		public IList Cases
		{
			get { return _cases; }
			set { _cases = value; }
		}
		
		public IList ServiceSessions
		{
			get { return _serviceSessions; }
			set { _serviceSessions = value; }
		}
		
		public IList ClassAttendances
		{
			get { return _classAttendances; }
			set { _classAttendances = value; }
		}

		public void AddGiro(GIRO giro)
		{
			giro.Member = this;
			_gIROs.Add(giro);
		}

		public void AddIPP(IPP ipp)
		{
			ipp.Member = this;
			_iPPs.Add(ipp);
		}

		public void AddLocker(Locker locker)
		{
			locker.Member = this;
			_lockers.Add(locker);
		}

		public void AddMemberCreditPackage(MemberCreditPackage memberCreditPackage)
		{
			memberCreditPackage.Member = this;
			_memberCreditPackages.Add(memberCreditPackage);
		}

		public void AddMemberPackage(MemberPackage memberPackage)
		{
			memberPackage.Member = this;
			_memberPackages.Add(memberPackage);
		}

		public void AddReceipt(Receipt receipt)
		{
			receipt.Member = this;
			_receipts.Add(receipt);
		}

		public void AddCardRequest(CardRequest cardRequest)
		{
			cardRequest.Member = this;
			_cardRequests.Add(cardRequest);
		}

		public void AddRewardsTransaction(RewardsTransaction rewardsTransaction)
		{
			rewardsTransaction.Member = this;
			_rewardsTransactions.Add(rewardsTransaction);
		}

		public void AddCase(Case cases)
		{
			cases.Member = this;
			_cases.Add(cases);
		}

	

		public void AddServiceSession(ServiceSession serviceSession)
		{
			serviceSession.Member = this;
			_serviceSessions.Add(serviceSession);
		}

		public void AddClassAttendance(ClassAttendance classAttendance)
		{
			classAttendance.Member = this;
			_classAttendances.Add(classAttendance);
		}
		#endregion
	}
	
	#endregion
}
