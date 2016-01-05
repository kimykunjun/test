using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region Category
	
	/// <summary>
	/// Category object for NHibernate mapped table 'tblCategory'.
	/// </summary>
	public class Category
	{
		#region Member Variables
		
		protected int _id;
		protected string _strDescription;
		protected POSCategory _pOSCategory;
		protected SalesCategory _salesCategory;
		protected IList _creditPackages = new ArrayList();
		protected IList _packages = new ArrayList();
		protected IList _receipts = new ArrayList();

		#endregion
		
		#region Constructors
		
		public Category() { }
		
		public Category( string strDescription, POSCategory pOSCategory, SalesCategory salesCategory )
		{
			this._strDescription = strDescription;
			this._pOSCategory = pOSCategory;
			this._salesCategory = salesCategory;
		}
		
		#endregion		

		#region Public Properties
		
		public int Id
		{
			get {return _id;}
			set {_id = value;}
		}

		public string StrDescription
		{
			get { return _strDescription; }
			set { _strDescription = value; }
		}
		
		public POSCategory POSCategory
		{
			get { return _pOSCategory; }
			set { _pOSCategory = value; }
		}

		public SalesCategory SalesCategory
		{
			get { return _salesCategory; }
			set { _salesCategory = value; }
		}

		public IList CreditPackages
		{
			get { return _creditPackages; }
			set { _creditPackages = value; }
		}
		
		public IList Packages
		{
			get { return _packages; }
			set { _packages = value; }
		}
		
		public IList Receipts
		{
			get { return _receipts; }
			set { _receipts = value; }
		}

		public void AddCreditPackage(CreditPackage creditPackage)
		{
			creditPackage.Category = this;
			_creditPackages.Add(creditPackage);
		}

		public void AddPackage(Package package)
		{
			package.Category = this;
			_packages.Add(package);
		}

		public void AddReceipt(Receipt receipt)
		{
			receipt.Category = this;
			_receipts.Add(receipt);
		}


		
		#endregion
	}
	
	#endregion
}
