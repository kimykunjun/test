using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region ItemPromotion
	
	/// <summary>
	/// ItemPromotion object for NHibernate mapped table 'tblItemPromotion'.
	/// </summary>
	public class ItemPromotion
	{
		#region Member Variables
		
		protected Id _id;
		
		protected int _nCategoryTypeID;
		protected int _nGroupID;
		protected Promotion _promotion;
		protected Product _productstrCode;
		
		#endregion
		
		#region Constructors
		
		public ItemPromotion() { }
		
		public ItemPromotion( Id id, int nCategoryTypeID, int nGroupID, Promotion promotion, Product productstrCode )
		{
			this._id = id;
			this._nCategoryTypeID = nCategoryTypeID;
			this._nGroupID = nGroupID;
			this._promotion = promotion;
			this._productstrCode = productstrCode;

			_id.StringId1 = _promotion.Id;
			_id.StringId2 = _productstrCode.Id;
		}

		public override bool Equals(object obj)
		{
			return base.Equals (obj);
		}

		
		#endregion		

		#region Public Properties
		
		public Id Id
		{
			get {return _id;}
			set {_id = value;}
		}

		public int NCategoryTypeID
		{
			get { return _nCategoryTypeID; }
			set { _nCategoryTypeID = value; }
		}
		
		public int NGroupID
		{
			get { return _nGroupID; }
			set { _nGroupID = value; }
		}
		
		public Promotion Promotion
		{
			get { return _promotion; }
			set { _promotion = value;
			_id.StringId1 = _promotion.Id;}
		}

		public Product ProductstrCode
		{
			get { return _productstrCode; }
			set { _productstrCode = value;
			_id.StringId2 = _productstrCode.Id;}
		}
		

		public override int GetHashCode()
		{
			return base.GetHashCode ();
		}

		#endregion
	}
	
	#endregion
}
