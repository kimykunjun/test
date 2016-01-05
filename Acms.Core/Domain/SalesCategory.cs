using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region SalesCategory
	
	/// <summary>
	/// SalesCategory object for NHibernate mapped table 'tblSalesCategory'.
	/// </summary>
	public class SalesCategory
	{
		#region Member Variables
		
		protected int _id;
		protected string _strDescription;
		protected IList _commissionSchemes = new ArrayList();
		protected IList _packageGroupsnCategoryID = new ArrayList();
		protected IList _promotionReceiptSalesCategorys = new ArrayList();
		protected IList _rewardses = new ArrayList();
		protected IList _categories = new ArrayList();

		#endregion
		
		#region Constructors
		
		public SalesCategory() { }
		
		public SalesCategory( string strDescription )
		{
			this._strDescription = strDescription;
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
		
		public IList CommissionSchemes
		{
			get { return _commissionSchemes; }
			set { _commissionSchemes = value; }
		}
		
		public IList PackageGroupsnCategoryID
		{
			get { return _packageGroupsnCategoryID; }
			set { _packageGroupsnCategoryID = value; }
		}
		
		public IList PromotionReceiptSalesCategorys
		{
			get { return _promotionReceiptSalesCategorys; }
			set { _promotionReceiptSalesCategorys = value; }
		}
		
		public IList Rewardses
		{
			get { return _rewardses; }
			set { _rewardses = value; }
		}
		
		public IList Categories
		{
			get { return _categories; }
			set { _categories = value; }
		}
	

		public void AddPromotionReceiptSalesCategory(PromotionReceiptSalesCategory promotionReceiptSalesCategory)
		{
			promotionReceiptSalesCategory.SalesCategory = this;
			_promotionReceiptSalesCategorys.Add(promotionReceiptSalesCategory);
			
		}

		public void AddCommissionScheme(CommissionScheme commissionScheme)
		{
			commissionScheme.SalesCategory = this;
			_commissionSchemes.Add(commissionScheme);
		}

		public void AddPackageGroup(PackageGroup packageGroup)
		{
			packageGroup.SalesCategorynCategoryID = this;
			_packageGroupsnCategoryID.Add(packageGroup);
		}

		public void AddReward(Reward reward)
		{
			reward.SalesCategory = this;
			_rewardses.Add(reward);
		}

		public void AddCategory(Category category)
		{
			category.SalesCategory = this;
			_categories.Add(category);
		}


		#endregion
	}
	
	#endregion
}
