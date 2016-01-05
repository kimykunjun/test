using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region Promotion
	
	/// <summary>
	/// Promotion object for NHibernate mapped table 'tblPromotion'.
	/// </summary>
	public class Promotion
	{
		#region Member Variables
		
		protected string _id;
		protected string _strDescription;
		protected int _nPromotionTypeID;
		protected bool _fItemDiscount;
		protected decimal _mMinimumAmount;
		protected DateTime _dtValidStart;
		protected DateTime _dtValidEnd;
		protected double _dDiscountPercent;
		protected double _dDiscountValue;

		//many-to-one
		protected DiscountCategory _discountCategory;
		protected Employee _approvedStatus;
		
		//one-to-one
		//protected ItemPromotion _itemPromotion;
		protected IList _itemPromotions = new ArrayList();
		protected IList _promotionFreebies = new ArrayList();

		//one-to-many
		protected IList _promotionPackages = new ArrayList();
		protected IList _promotionBranchs = new ArrayList();
		protected IList _promotionReceiptSalesCategorys = new ArrayList();
		protected IList _receiptsstrDiscountCode = new ArrayList();
		protected IList _receiptsstrFreebieCode = new ArrayList();
		protected IList _receiptEntriesesstrDiscountCode = new ArrayList();
		protected IList _receiptEntriesesstrFreebieCode = new ArrayList();
		protected IList _receiptFreebies = new ArrayList();

		#endregion
		
		#region Constructors
		
		public Promotion() { }
		
		public Promotion( string strDescription, int nPromotionTypeID, bool fItemDiscount, decimal mMinimumAmount, DateTime dtValidStart, DateTime dtValidEnd, double dDiscountPercent, double dDiscountValue, DiscountCategory discountCategory, Employee approvedStatus )
		{
			this._strDescription = strDescription;
			this._nPromotionTypeID = nPromotionTypeID;
			this._fItemDiscount = fItemDiscount;
			this._mMinimumAmount = mMinimumAmount;
			this._dtValidStart = dtValidStart;
			this._dtValidEnd = dtValidEnd;
			this._dDiscountPercent = dDiscountPercent;
			this._dDiscountValue = dDiscountValue;
			this._discountCategory = discountCategory;
			this._approvedStatus = approvedStatus;
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
		
		public int NPromotionTypeID
		{
			get { return _nPromotionTypeID; }
			set { _nPromotionTypeID = value; }
		}
		
		public bool FItemDiscount
		{
			get { return _fItemDiscount; }
			set { _fItemDiscount = value; }
		}
		
		public decimal MMinimumAmount
		{
			get { return _mMinimumAmount; }
			set { _mMinimumAmount = value; }
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
		
		public double DDiscountPercent
		{
			get { return _dDiscountPercent; }
			set { _dDiscountPercent = value; }
		}
		
		public double DDiscountValue
		{
			get { return _dDiscountValue; }
			set { _dDiscountValue = value; }
		}
		
		public DiscountCategory DiscountCategory
		{
			get { return _discountCategory; }
			set { _discountCategory = value; }
		}

		public Employee ApprovedStatus
		{
			get { return _approvedStatus; }
			set { _approvedStatus = value; }
		}

		public IList ItemPromotions
		{
			get { return _itemPromotions; }
			set { _itemPromotions = value; }
		}
		
		public IList PromotionBranchs
		{
			get { return _promotionBranchs; }
			set { _promotionBranchs = value; }
		}
		
		public IList PromotionFreebies
		{
			get { return _promotionFreebies; }
			set { _promotionFreebies = value; }
		}

//		public PromotionFreebie PromotionFreebie
//		{
//			get { return _promotionFreebie; }
//			set { _promotionFreebie = value; }
//		}

		public IList PromotionPackages
		{
			get { return _promotionPackages; }
			set { _promotionPackages = value; }
		}
		
		public IList PromotionReceiptSalesCategorys
		{
			get { return _promotionReceiptSalesCategorys; }
			set { _promotionReceiptSalesCategorys = value; }
		}
		
		public IList ReceiptsstrDiscountCode
		{
			get { return _receiptsstrDiscountCode; }
			set { _receiptsstrDiscountCode = value; }
		}
		
		public IList ReceiptsstrFreebieCode
		{
			get { return _receiptsstrFreebieCode; }
			set { _receiptsstrFreebieCode = value; }
		}
		
		public IList ReceiptEntriesesstrDiscountCode
		{
			get { return _receiptEntriesesstrDiscountCode; }
			set { _receiptEntriesesstrDiscountCode = value; }
		}
		
		public IList ReceiptEntriesesstrFreebieCode
		{
			get { return _receiptEntriesesstrFreebieCode; }
			set { _receiptEntriesesstrFreebieCode = value; }
		}
		
		public IList ReceiptFreebies
		{
			get { return _receiptFreebies; }
			set { _receiptFreebies = value; }
		}

		
		public void AddPromotionBranch(PromotionBranch promotionBranch)
		{
			promotionBranch.Promotion = this;
			_promotionBranchs.Add(promotionBranch);
			
		}

		public void AddPromotionPackage(PromotionPackage promotionPackage)
		{
			promotionPackage.Promotion = this;
			_promotionPackages.Add(promotionPackage);
			
		}

		public void AddPromotionReceiptSalesCategory(PromotionReceiptSalesCategory promotionReceiptSalesCategory)
		{
			promotionReceiptSalesCategory.Promotion = this;
			_promotionReceiptSalesCategorys.Add(promotionReceiptSalesCategory);
			
		}

		public void AddPromotionReceiptDiscountCode(Receipt receiptsstrDiscountCode)
		{
			receiptsstrDiscountCode.PromotionstrDiscountCode = this;
			_receiptsstrDiscountCode.Add(receiptsstrDiscountCode);
			
		}

		public void AddPromotionReceiptFreebieCode(Receipt receiptsstrFreebieCode)
		{
			receiptsstrFreebieCode.PromotionstrFreebieCode = this;
			_receiptEntriesesstrFreebieCode.Add(receiptsstrFreebieCode);
			
		}

		public void AddReceiptEntriesesDiscountCode(ReceiptEntries receiptEntriesesstrDiscountCode)
		{ 
			receiptEntriesesstrDiscountCode.PromotionstrDiscountCode = this;
			_receiptEntriesesstrDiscountCode.Add(receiptEntriesesstrDiscountCode);
		}

		public void AddReceiptEntriesesFreebieCode(ReceiptEntries receiptEntriesesstrFreebieCode)
		{
			receiptEntriesesstrFreebieCode.PromotionstrFreebieCode = this;
			_receiptEntriesesstrFreebieCode.Add(receiptEntriesesstrFreebieCode);
		}

		public void AddReceiptFreebies(ReceiptFreebie receiptFreebie)
		{
			receiptFreebie.Promotion = this;
			_receiptFreebies.Add(receiptFreebie);
		}

		public void AddItemPromotion(ItemPromotion itemPromotion)
		{
			itemPromotion.Promotion = this;
			_itemPromotions.Add(itemPromotion);
		}

		public void AddPromotionFreebie(PromotionFreebie promotionFreebie)
		{
			promotionFreebie.Promotion = this;
			_promotionFreebies.Add(promotionFreebie);
		}

		#endregion
	}
	
	#endregion
}
