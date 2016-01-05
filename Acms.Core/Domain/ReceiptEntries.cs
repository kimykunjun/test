using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region ReceiptEntry
	
	/// <summary>
	/// ReceiptEntry object for NHibernate mapped table 'tblReceiptEntries'.
	/// </summary>
	public class ReceiptEntries
	{
		#region Member Variables
		
		protected int _id;
		protected string _strCode;
		protected string _strDescription;
		protected int _nQuantity;
		protected decimal _mUnitPrice;
		protected string _strReferenceNo;
		protected Promotion _promotionstrDiscountCode;
		protected Promotion _promotionstrFreebieCode;
		protected Receipt _receipt;
		protected Category _category;

		#endregion
		
		#region Constructors
		
		public ReceiptEntries() { }
		
		public ReceiptEntries( string strCode, string strDescription, int nQuantity, decimal mUnitPrice, string strReferenceNo, Promotion promotionstrDiscountCode, Promotion promotionstrFreebieCode, Receipt receipt )
		{
			this._strCode = strCode;
			this._strDescription = strDescription;
			this._nQuantity = nQuantity;
			this._mUnitPrice = mUnitPrice;
			this._strReferenceNo = strReferenceNo;
			this._promotionstrDiscountCode = promotionstrDiscountCode;
			this._promotionstrFreebieCode = promotionstrFreebieCode;
			this._receipt = receipt;
		}
		
		#endregion		

		#region Public Properties
		
		public int Id
		{
			get {return _id;}
			set {_id = value;}
		}

		public string StrCode
		{
			get { return _strCode; }
			set { _strCode = value; }
		}
		
		public Category Category
		{
			get { return _category; }
			set { _category = value; }
		}

		public string StrDescription
		{
			get { return _strDescription; }
			set { _strDescription = value; }
		}
		
		public int NQuantity
		{
			get { return _nQuantity; }
			set { _nQuantity = value; }
		}
		
		public decimal MUnitPrice
		{
			get { return _mUnitPrice; }
			set { _mUnitPrice = value; }
		}
		
		public string StrReferenceNo
		{
			get { return _strReferenceNo; }
			set { _strReferenceNo = value; }
		}
		
		public Promotion PromotionstrDiscountCode
		{
			get { return _promotionstrDiscountCode; }
			set { _promotionstrDiscountCode = value; }
		}

		public Promotion PromotionstrFreebieCode
		{
			get { return _promotionstrFreebieCode; }
			set { _promotionstrFreebieCode = value; }
		}

		public Receipt Receipt
		{
			get { return _receipt; }
			set { _receipt = value; }
		}

		#endregion
	}
	
	#endregion
}
