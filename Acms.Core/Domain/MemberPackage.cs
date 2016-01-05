using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region MemberPackage
	
	/// <summary>
	/// MemberPackage object for NHibernate mapped table 'tblMemberPackage'.
	/// </summary>
	public class MemberPackage
	{
		#region Member Variables
		
		protected int _id;
		protected DateTime _dtPurchaseDate;
		protected DateTime _dtStartDate;
		protected DateTime _dtExpiryDate;
		protected DateTime _dtWarrantyDate;
		protected bool _fFree;
		protected string _strReceiptNo;
		protected int _nStatusID;
		protected string _strRemarks;
		protected int _nTempPackageID;
		protected string _strTempPackageCategory;
		protected DateTime _dtLastEdit;
		protected int _nVoucherTypeID;
		protected string _strVoucherNumber;
		protected Employee _employee;
		protected GIRO _gIRO;
		protected Member _member;
		protected MemberCreditPackage _memberCreditPackage;
		protected Package _package;
		protected IList _serviceSessions = new ArrayList();
		protected IList _classAttendances = new ArrayList();
		protected int _nBalance;
		protected int _nAdjust;
		

		#endregion
		
		#region Constructors
		
		public MemberPackage() { }
		
		public MemberPackage( DateTime dtPurchaseDate, DateTime dtStartDate, DateTime dtExpiryDate, DateTime dtWarrantyDate, bool fFree, string strReceiptNo, int nStatusID, string strRemarks, int nTempPackageID, string strTempPackageCategory, DateTime dtLastEdit, int nVoucherTypeID, string strVoucherNumber, int nBalance,int nAdjust, Employee employee, GIRO gIRO, Member member, MemberCreditPackage memberCreditPackage, Package package )
		{
			this._dtPurchaseDate = dtPurchaseDate;
			this._dtStartDate = dtStartDate;
			this._dtExpiryDate = dtExpiryDate;
			this._dtWarrantyDate = dtWarrantyDate;
			this._fFree = fFree;
			this._strReceiptNo = strReceiptNo;
			this._nStatusID = nStatusID;
			this._strRemarks = strRemarks;
			this._nTempPackageID = nTempPackageID;
			this._strTempPackageCategory = strTempPackageCategory;
			this._dtLastEdit = dtLastEdit;
			this._nVoucherTypeID = nVoucherTypeID;
			this._strVoucherNumber = strVoucherNumber;
			this._nBalance = nBalance;
			this._nAdjust=nAdjust;
			this._employee = employee;
			this._gIRO = gIRO;
			this._member = member;
			this._memberCreditPackage = memberCreditPackage;
			this._package = package;
		}
		
		#endregion		

		#region Public Properties
		
		public int Id
		{
			get {return _id;}
			set {_id = value;}
		}

		public DateTime DtPurchaseDate
		{
			get { return _dtPurchaseDate; }
			set { _dtPurchaseDate = value; }
		}
		
		public DateTime DtStartDate
		{
			get { return _dtStartDate; }
			set { _dtStartDate = value; }
		}
		
		public DateTime DtExpiryDate
		{
			get { return _dtExpiryDate; }
			set { _dtExpiryDate = value; }
		}
		
		public DateTime DtWarrantyDate
		{
			get { return _dtWarrantyDate; }
			set { _dtWarrantyDate = value; }
		}
		
		public bool FFree
		{
			get { return _fFree; }
			set { _fFree = value; }
		}
		
		public string StrReceiptNo
		{
			get { return _strReceiptNo; }
			set { _strReceiptNo = value; }
		}
		
		public int NStatusID
		{
			get { return _nStatusID; }
			set { _nStatusID = value; }
		}
		
		public string StrRemarks
		{
			get { return _strRemarks; }
			set { _strRemarks = value; }
		}
		
		public int NTempPackageID
		{
			get { return _nTempPackageID; }
			set { _nTempPackageID = value; }
		}
		
		public string StrTempPackageCategory
		{
			get { return _strTempPackageCategory; }
			set { _strTempPackageCategory = value; }
		}

		public DateTime DtLastEdit
		{
			get { return _dtLastEdit; }
			set { _dtLastEdit = value; }
		}
		
		public int NVoucherTypeID
		{
			get { return _nVoucherTypeID; }
			set { _nVoucherTypeID = value; }
		}
		
		public string StrVoucherNumber
		{
			get { return _strVoucherNumber; }
			set { _strVoucherNumber = value; }
		}
		
		public int NBalance
		{
			get { return _nBalance; }
			set { _nBalance = value; }
		}
		
		public int nAdjust
		{
			get { return _nAdjust; }
			set { _nAdjust = value; }
		}

		public Employee Employee
		{
			get { return _employee; }
			set { _employee = value; }
		}

		public GIRO GIRO
		{
			get { return _gIRO; }
			set { _gIRO = value; }
		}

		public Member Member
		{
			get { return _member; }
			set { _member = value; }
		}

		public MemberCreditPackage MemberCreditPackage
		{
			get { return _memberCreditPackage; }
			set { _memberCreditPackage = value; }
		}

		public Package Package
		{
			get { return _package; }
			set { _package = value; }
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
		
		public void AddServiceSession(ServiceSession serviceSession)
		{
			serviceSession.MemberPackage = this;
			_serviceSessions.Add(serviceSession);
		}

		public void AddClassAttendance(ClassAttendance classAttendance)
		{
			classAttendance.MemberPackage = this;
			_classAttendances.Add(classAttendance);
		}

		#endregion
	}
	
	#endregion
}
