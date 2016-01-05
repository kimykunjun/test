using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region PromotionFreebie
	
	/// <summary>
	/// PromotionFreebie object for NHibernate mapped table 'tblPromotionFreebie'.
	/// </summary>
	public class PromotionFreebie
	{
		#region Member Variables
		
		protected Id _id;
		protected Product _strItemCode;
		protected Promotion _promotion;

		#endregion
		
		#region Constructors
		
		public PromotionFreebie() { }
		
		public PromotionFreebie(Id id, Product strItemCode, Promotion promotion )
		{
			this._id = id;
			this._strItemCode = strItemCode;
			this._promotion = promotion;
		}
		
		#endregion		

		#region Public Properties
		
		public Id Id
		{
			get {return _id;}
			set {_id = value;}
		}

		public Product Product
		{
			set{_strItemCode = value;
			_id.StringId1 = _strItemCode.Id;}
			get{return _strItemCode;}
		}

		public Promotion Promotion
		{
			get { return _promotion;}
			set { _promotion = value; 
			_id.StringId2 = _promotion.Id;}
		}

		#endregion
	}
	
	#endregion
}
