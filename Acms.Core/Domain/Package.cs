using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region Package
	
	/// <summary>
	/// Package object for NHibernate mapped table 'tblPackage'.
	/// </summary>
	public class Package
	{
		#region Member Variables
		
		protected string _id;
		protected string _strDescription;
		protected string _strReceiptDesc;
		protected decimal _mListPrice;
		protected int _nMaxSession;
		protected int _nPackageDuration;
		protected decimal _mBaseUnitPrice;
		protected DateTime _dtValidStart;
		protected DateTime _dtValidEnd;
		protected bool _fPeak;
		protected int _nValidMonths;
		protected int _nWarrantyMonths;
		protected bool _fGIRO;
		protected bool _fNoRestrictionUpgrade;
		protected int _nStatus;
		protected Category _category;
		protected IList _creditPackageRestrictions = new ArrayList();
		protected IList _gIROs = new ArrayList();
		protected IList _memberPackages = new ArrayList();
		protected IList _packageBranchs = new ArrayList();
		protected IList _packageClasses = new ArrayList();
		protected IList _packageGroupEntrys = new ArrayList();
		protected IList _packageServices = new ArrayList();
		protected IList _promotionPackages = new ArrayList();

		#endregion
		
		#region Constructors
		
		public Package() { }
		
		public Package( string strDescription, string strReceiptDesc, decimal mListPrice, int nMaxSession, int nPackageDuration, decimal mBaseUnitPrice, DateTime dtValidStart, DateTime dtValidEnd, bool fPeak, int nValidMonths, int nWarrantyMonths, bool fGIRO, bool fNoRestrictionUpgrade, int nStatus, Category category )
		{
			this._strDescription = strDescription;
			this._strReceiptDesc = strReceiptDesc;
			this._mListPrice = mListPrice;
			this._nMaxSession = nMaxSession;
			this._nPackageDuration = nPackageDuration;
			this._mBaseUnitPrice = mBaseUnitPrice;
			this._dtValidStart = dtValidStart;
			this._dtValidEnd = dtValidEnd;
			this._fPeak = fPeak;
			this._nValidMonths = nValidMonths;
			this._nWarrantyMonths = nWarrantyMonths;
			this._fGIRO = fGIRO;
			this._fNoRestrictionUpgrade = fNoRestrictionUpgrade;
			this._nStatus = nStatus;
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
		
		public int NMaxSession
		{
			get { return _nMaxSession; }
			set { _nMaxSession = value; }
		}
		
		public int NPackageDuration
		{
			get { return _nPackageDuration; }
			set { _nPackageDuration = value; }
		}
		
		public decimal MBaseUnitPrice
		{
			get { return _mBaseUnitPrice; }
			set { _mBaseUnitPrice = value; }
		}
		
		public int NStatus
		{
			get { return _nStatus; }
			set { _nStatus = value; }
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
		
		public bool FPeak
		{
			get { return _fPeak; }
			set { _fPeak = value; }
		}
		
		public int NValidMonths
		{
			get { return _nValidMonths; }
			set { _nValidMonths = value; }
		}
		
		public int NWarrantyMonths
		{
			get { return _nWarrantyMonths; }
			set { _nWarrantyMonths = value; }
		}
		
		public bool FGIRO
		{
			get { return _fGIRO; }
			set { _fGIRO = value; }
		}
		
		public bool FNoRestrictionUpgrade
		{
			get { return _fNoRestrictionUpgrade; }
			set { _fNoRestrictionUpgrade = value; }
		}
		
		public Category Category
		{
			get { return _category; }
			set { _category = value; }
		}

		public string CategoryDescription
		{
			get { return _category.StrDescription; }
		}

		public IList CreditPackageRestrictions
		{
			get { return _creditPackageRestrictions; }
			set { _creditPackageRestrictions = value; }
		}
		
		public IList GIROs
		{
			get { return _gIROs; }
			set { _gIROs = value; }
		}
		
		public IList MemberPackages
		{
			get { return _memberPackages; }
			set { _memberPackages = value; }
		}
		
		public IList PackageBranchs
		{
			get { return _packageBranchs; }
			set { _packageBranchs = value; }
		}
		
		public IList PackageClasses
		{
			get { return _packageClasses; }
			set { _packageClasses = value; }
		}
		
		public IList PackageGroupEntrys
		{
			get { return _packageGroupEntrys; }
			set { _packageGroupEntrys = value; }
		}
		
		public IList PackageServices
		{
			get { return _packageServices; }
			set { _packageServices = value; }
		}
		
		public IList PromotionPackages
		{
			get { return _promotionPackages; }
			set { _promotionPackages = value; }
		}

		public void AddPackageBranch(PackageBranch packageBranch)
		{
			packageBranch.Package = this;
			_packageBranchs.Add(packageBranch);
			
		}
		

		public void AddPackageClass(PackageClass packageClass)
		{
			packageClass.Package = this;
			_packageClasses.Add(packageClass);
			
		}
		

		public void AddPackageService(PackageService packageService)
		{
			packageService.Package = this;
			_packageServices.Add(packageService);
			
		}

		public void AddPromotionPackage(PromotionPackage promotionPackage)
		{
			promotionPackage.Package = this;
			_promotionPackages.Add(promotionPackage);
			
		}

		public void AddPackageGroupEntry(PackageGroupEntry packageGroupEntry)
		{
			packageGroupEntry.Package = this;
			_packageGroupEntrys.Add(packageGroupEntry);
			
		}

		public void AddCreditPackageRestriction(CreditPackageRestriction creditPackageRestriction)
		{
			creditPackageRestriction.Package = this;
			_creditPackageRestrictions.Add(creditPackageRestriction);
			
		}

		public void AddGIRO(GIRO gIRO)
		{
			gIRO.Package = this;
			_gIROs.Add(gIRO);
			
		}

		public void AddMemberPackage(MemberPackage memberPackage)
		{
			memberPackage.Package = this;
			_memberPackages.Add(memberPackage);
			
		}

		#endregion
	}
	
	#endregion
}
