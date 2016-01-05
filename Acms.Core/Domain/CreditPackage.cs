using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region CreditPackage
	
	/// <summary>
	/// CreditPackage object for NHibernate mapped table 'tblCreditPackage'.
	/// </summary>
	public class CreditPackage
	{
		#region Member Variables
		
		protected string _id;
		protected string _strDescription;
		protected string _strReceiptDesc;
		protected decimal _mListPrice;
		protected DateTime _dtValidStart;
		protected DateTime _dtValidEnd;
		protected int _nValidMonths;
		protected decimal _mCreditAmount;
		protected double _dCreditDiscount;
		protected Category _category;
		protected IList _creditPackageRestrictions = new ArrayList();
		protected IList _memberCreditPackages = new ArrayList();

		#endregion
		
		#region Constructors
		
		public CreditPackage() { }
		
		public CreditPackage( string strDescription, string strReceiptDesc, decimal mListPrice, DateTime dtValidStart, DateTime dtValidEnd, int nValidMonths, decimal mCreditAmount, double dCreditDiscount, Category category )
		{
			this._strDescription = strDescription;
			this._strReceiptDesc = strReceiptDesc;
			this._mListPrice = mListPrice;
			this._dtValidStart = dtValidStart;
			this._dtValidEnd = dtValidEnd;
			this._nValidMonths = nValidMonths;
			this._mCreditAmount = mCreditAmount;
			this._dCreditDiscount = dCreditDiscount;
			this._category = category;
		}
		
		#endregion		

		#region Public Properties
		
		public string Id
		{
			get {return _id;}
			set {_id = value;}
		}

		public string StrDescription
		{
			get { return _strDescription; }
			set { _strDescription = value; }
		}
		
		public string StrReceiptDesc
		{
			get { return _strReceiptDesc; }
			set { _strReceiptDesc = value; }
		}
		
		public decimal MListPrice
		{
			get { return _mListPrice; }
			set { _mListPrice = value; }
		}
		
		public DateTime DtValidStart
		{
			get { return _dtValidStart; }
			set { _dtValidStart = value; }
		}
		
		public DateTime DtValidEnd
		{
			get { return _dtValidEnd; }
			set { _dtValidEnd = value; }
		}
		
		public int NValidMonths
		{
			get { return _nValidMonths; }
			set { _nValidMonths = value; }
		}
		
		public decimal MCreditAmount
		{
			get { return _mCreditAmount; }
			set { _mCreditAmount = value; }
		}
		
		public double DCreditDiscount
		{
			get { return _dCreditDiscount; }
			set { _dCreditDiscount = value; }
		}
		
		public Category Category
		{
			get { return _category; }
			set { _category = value; }
		}

		public IList CreditPackageRestrictions
		{
			get { return _creditPackageRestrictions; }
			set { _creditPackageRestrictions = value; }
		}
		
		public IList MemberCreditPackages
		{
			get { return _memberCreditPackages; }
			set { _memberCreditPackages = value; }
		}

		public void AddCreditPackageRestriction(CreditPackageRestriction creditPackageRestriction)
		{
			creditPackageRestriction.CreditPackage = this;
			_creditPackageRestrictions.Add(creditPackageRestriction);
			
		}

		public void AddMemberCreditPackage(MemberCreditPackage memberCreditPackage)
		{
			memberCreditPackage.CreditPackage = this;
			_memberCreditPackages.Add(memberCreditPackage);
			
		}
		
		#endregion
	}
	
	#endregion
}
