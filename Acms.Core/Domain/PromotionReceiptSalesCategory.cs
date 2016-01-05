using System;

namespace Acms.Core.Domain
{
	/// <summary>
	/// Summary description for EmployeeBranchRights.
	/// </summary>
	public class PromotionReceiptSalesCategory
	{
		protected SalesCategory _salesCategory;
		protected Promotion _promotion;

		public PromotionReceiptSalesCategory()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public PromotionReceiptSalesCategory(SalesCategory salesCategory, Promotion promotion)
		{
			this._salesCategory = salesCategory;
			this._promotion = promotion;
		}

		public SalesCategory SalesCategory
		{
			set{_salesCategory = value;}
			get{return _salesCategory;}
		}

		public Promotion Promotion
		{
			set{_promotion = value;}
			get{return _promotion;}
		}
	}
}

