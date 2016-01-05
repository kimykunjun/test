using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region ProductInventory
	
	/// <summary>
	/// ProductInventory object for NHibernate mapped table 'tblProductInventory'.
	/// </summary>
	public class ProductInventory
	{
		#region Member Variables
		
		protected Id _id;
		protected string _strBin;
		protected int _nQuantity;
		protected int _nMinQuantity;
		protected int _nMaxQuantity;
		protected int _nReorderQuantity;
		protected Branch _branch;
		protected Product _product;
		protected string _branchId;

		#endregion
		
		#region Constructors
		
		public ProductInventory() { }
		
		public ProductInventory( string strBin, int nQuantity, int nMinQuantity, int nMaxQuantity, int nReorderQuantity, Branch branch, Product product )
		{
			this._strBin = strBin;
			this._nQuantity = nQuantity;
			this._nMinQuantity = nMinQuantity;
			this._nMaxQuantity = nMaxQuantity;
			this._nReorderQuantity = nReorderQuantity;
			this._branch = branch;
			this._product = product;
		}
		
		#endregion		

		#region Public Properties
		
		public Id Id
		{
			get {return _id;}
			set {_id = value;}
		}


		public string StrBin
		{
			get { return _strBin; }
			set { _strBin = value; }
		}
		
		public int NQuantity
		{
			get { return _nQuantity; }
			set { _nQuantity = value; }
		}
		
		public int NMinQuantity
		{
			get { return _nMinQuantity; }
			set { _nMinQuantity = value; }
		}
		
		public int NMaxQuantity
		{
			get { return _nMaxQuantity; }
			set { _nMaxQuantity = value; }
		}
		
		public int NReorderQuantity
		{
			get { return _nReorderQuantity; }
			set { _nReorderQuantity = value; }
		}
		
		public Branch Branch
		{
			get { return _branch; }
			set { _branch = value; 
			_id.StringId2 = _branch.Id;}
		}

		public string BranchId
		{
			set {_branchId=value;}
			get{return _branchId;}
		}

		public string StrBranchName
		{
			get{return _branch.StrBranchName;}
		}

		public Product Product
		{
			get { return _product; }
			set { _product = value; 
			_id.StringId1 = _product.Id;}
		}

		public string ProductId
		{
			get{return _product.Id;}
		}

		public string StrBrand
		{
			get { return _product.Brand.Id;}
		}

		public string StrStyle
		{
			get{return _product.Style.StrDescription;}
		}

		public string StrColor
		{
			get{return _product.Color.Id;}
		}

		public string StrSize
		{
			get{return _product.Size.Id;}
		}

		public string StrDescription
		{
			get{return _product.StrDescription;}
		}

		

		#endregion

		#region Business Process

		public bool IsValidQuantityRequest(int quantityRequest)
		{
			if(quantityRequest<=this.NQuantity)
				return true;
			return false;
		}
		#endregion
	}
	
	#endregion
}
