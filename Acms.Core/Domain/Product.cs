using System;
using System.Collections;


// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region Product
	
	/// <summary>
	/// Product object for NHibernate mapped table 'tblProduct'.
	/// </summary>
	public class Product
	{
		#region Member Variables
		
		protected string _id;
		protected string _strDescription;

		protected DateTime _dtValidStart;
		protected DateTime _dtValidEnd;
		protected int _nCategoryID;
		protected decimal _mBaseUnitPrice;
		protected int _nStatus;
		protected ProductType _productTypenProductTypeId;
		protected IList _itemPromotions;

		protected Brand _brand;
		protected Color _color;
		protected Size _size;
		protected Style _style;
	
		protected IList _iBTEntriesesstrItemCode = new ArrayList();
		protected RewardsCatalogue _rewardsCataloguestrProductCode;
		protected IList _productBranches = new ArrayList();
		protected IList _productInventories = new ArrayList();
		protected IList _stockRequestEntries = new ArrayList();
		protected IList _salonUses = new ArrayList();
		#endregion
		
		#region Constructors
		
		public Product() { }
		
		public Product(string Id,string strDescription)
		{
			this._id = Id;
			this._strDescription = strDescription;
		}

		public Product( string strDescription, DateTime dtValidStart, DateTime dtValidEnd, int nCategoryID, decimal mBaseUnitPrice, int nStatus, Brand brand, Color color, ProductType productTypenProductTypeId, Size size, Style style )
		{
			this._strDescription = strDescription;
			this._dtValidStart = dtValidStart;
			this._dtValidEnd = dtValidEnd;
			this._nCategoryID = nCategoryID;
			this._mBaseUnitPrice = mBaseUnitPrice;
			this._nStatus = nStatus;
			this._brand = brand;
			this._color = color;
			this._productTypenProductTypeId = productTypenProductTypeId;
			this._size = size;
			this._style = style;
		}
		
		#endregion		

		#region Public Properties
		
		public string Id
		{
			get {return _id;}
			set {_id = value;}
		}

//		public string ProductStrItemCode
//		{
//			get {return _id;}
//		}

		public string StrDescription
		{
			get { return _strDescription; }
			set { _strDescription = value; }
		}

//		public string ProductStrDescription
//		{
//			get { return _strDescription; }
//		}
		
		public Brand Brand
		{
			get { return _brand; }
			set { _brand = value; }
		}

		public string StrBrand
		{
			get{return _brand.Id;}
		}
		
		public Color Color
		{
			get { return _color; }
			set { _color = value; }
		}

		public string StrColor
		{
			get{ return _color.Id;}
		}

		public Size Size
		{
			get { return _size; }
			set { _size = value; }
		}

		public string StrSize
		{
			get{return _size.Id;}
		}

		public Style Style
		{
			get { return _style; }
			set { _style = value; }
		}

		public string StrStyle
		{
			get{return _style.Id;}
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
		
		public int NCategoryID
		{
			get { return _nCategoryID; }
			set { _nCategoryID = value; }
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
		
		public ProductType ProductTypenProductTypeId
		{
			get { return _productTypenProductTypeId; }
			set { _productTypenProductTypeId = value; }
		}

		public IList ItemPromotions
		{
			get { return _itemPromotions; }
			set { _itemPromotions = value; }
		}
		
		public IList ProductInventories
		{
			get { return _productInventories; }
			set { _productInventories = value; }
		}
		
		public IList ProductBranches
		{
			get { return _productBranches; }
			set { _productBranches = value; }
		}
		
		public IList IBTEntriesesstrItemCode
		{
			get { return _iBTEntriesesstrItemCode; }
			set { _iBTEntriesesstrItemCode = value; }
		}
		
		public IList StockRequestEntries
		{
			get{return _stockRequestEntries;}
			set{_stockRequestEntries = value;}
		}

		public IList SalonUses
		{
			get { return _salonUses; }
			set { _salonUses = value; }
		}
		
//		public int NQuantity
//		{
//			get{return ((Acms.Core.Domain.StockRequestEntry)_stockRequestEntries[0]).NQuantity;}
//		}

		public RewardsCatalogue RewardsCataloguestrProductCode
		{
			get { return _rewardsCataloguestrProductCode; }
			set { _rewardsCataloguestrProductCode = value; }
		}

		public void AddIBTEntriesesstrItemCode(IBTEntry ibtEntry)
		{
			ibtEntry.Product_StrItemCode = this;
			_iBTEntriesesstrItemCode.Add(ibtEntry);
		}

		public void AddProductBranch(ProductBranch productBranch)
		{
			productBranch.Product = this;
			_productBranches.Add(productBranch);
		}
		
		public void AddProductInventory(ProductInventory productInventory)
		{
			productInventory.Product = this;
			_productInventories.Add(productInventory);
		}

		public void AddStockRequestEntry(StockRequestEntry stockRequestEntry)
		{
			stockRequestEntry.Product = this;
			_stockRequestEntries.Add(stockRequestEntry);
		}

		public void AddSalonUse(SalonUse salonUse)
		{
			salonUse.Product = this;
			_salonUses.Add(salonUse);
		}
		
		#endregion
	}
	
	#endregion
}
