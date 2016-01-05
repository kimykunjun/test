using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region CreditPackageRestriction
	
	/// <summary>
	/// CreditPackageRestriction object for NHibernate mapped table 'tblCreditPackageRestriction'.
	/// </summary>
	public class CreditPackageRestriction
	{
		#region Member Variables
		
		protected string _id;
		protected bool _fAllowDiscount;
		protected CreditPackage _creditPackage;
		protected Package _package;

		#endregion
		
		#region Constructors
		
		public CreditPackageRestriction() { }
		
		public CreditPackageRestriction( bool fAllowDiscount, CreditPackage creditPackage, Package package )
		{
			this._fAllowDiscount = fAllowDiscount;
			this._creditPackage = creditPackage;
			this._package = package;
		}
		
		#endregion		

		#region Public Properties
		
		public string Id
		{
			get {return _id;}
			set {_id = value;}
		}

		public bool FAllowDiscount
		{
			get { return _fAllowDiscount; }
			set { _fAllowDiscount = value; }
		}
		
		public CreditPackage CreditPackage
		{
			get { return _creditPackage; }
			set { _creditPackage = value; }
		}

		public Package Package
		{
			get { return _package; }
			set { _package = value; }
		}

		#endregion
	}
	
	#endregion
}
