using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region MemberCreditPackage
	
	/// <summary>
	/// MemberCreditPackage object for NHibernate mapped table 'tblMemberCreditPackage'.
	/// </summary>
	public class MemberCreditPackage
	{
		#region Member Variables
		
		protected int _id;
		protected DateTime _dtPurchaseDate;
		protected DateTime _dtStartDate;
		protected DateTime _dtExpiryDate;
		protected bool _fFree;
		protected string _strReceiptNo;
		protected int _nStatusID;
		protected string _strRemarks;
		protected DateTime _dtLastEditDate;
		protected decimal _mTopupAmount;
		protected int _nTempPackageID;
		protected CreditPackage _creditPackage;
		protected Employee _employee;
		protected Member _member;
		protected IList _memberPackages = new ArrayList();

		#endregion
		
		#region Constructors
		
		public MemberCreditPackage() { }
		
		public MemberCreditPackage( DateTime dtPurchaseDate, DateTime dtStartDate, DateTime dtExpiryDate, bool fFree, string strReceiptNo, int nStatusID, string strRemarks, DateTime dtLastEditDate, decimal mTopupAmount, int nTempPackageID, CreditPackage creditPackage, Employee employee, Member member )
		{
			this._dtPurchaseDate = dtPurchaseDate;
			this._dtStartDate = dtStartDate;
			this._dtExpiryDate = dtExpiryDate;
			this._fFree = fFree;
			this._strReceiptNo = strReceiptNo;
			this._nStatusID = nStatusID;
			this._strRemarks = strRemarks;
			this._dtLastEditDate = dtLastEditDate;
			this._mTopupAmount = mTopupAmount;
			this._nTempPackageID = nTempPackageID;
			this._creditPackage = creditPackage;
			this._employee = employee;
			this._member = member;
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
		
		public DateTime DtLastEditDate
		{
			get { return _dtLastEditDate; }
			set { _dtLastEditDate = value; }
		}
		
		public decimal MTopupAmount
		{
			get { return _mTopupAmount; }
			set { _mTopupAmount = value; }
		}
		
		public int NTempPackageID
		{
			get { return _nTempPackageID; }
			set { _nTempPackageID = value; }
		}
		
		public CreditPackage CreditPackage
		{
			get { return _creditPackage; }
			set { _creditPackage = value; }
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

		public IList MemberPackages
		{
			get { return _memberPackages; }
			set { _memberPackages = value; }
		}

		public void AddMemberPackage(MemberPackage memberPackage)
		{
			memberPackage.MemberCreditPackage = this;
			_memberPackages.Add(memberPackage);
		}
		
		#endregion
	}
	
	#endregion
}
