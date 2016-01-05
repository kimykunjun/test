using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region ReceiptFreebie
	
	/// <summary>
	/// ReceiptFreebie object for NHibernate mapped table 'tblReceiptFreebie'.
	/// </summary>
	public class ReceiptFreebie
	{
		#region Member Variables
		
		protected int _id;
		protected string _strItemCode;
		protected Promotion _promotion;
		protected Receipt _receipt;

		#endregion
		
		#region Constructors
		
		public ReceiptFreebie() { }
		
		public ReceiptFreebie( string strItemCode, Promotion promotion, Receipt receipt )
		{
			this._strItemCode = strItemCode;
			this._promotion = promotion;
			this._receipt = receipt;
		}
		
		#endregion		

		#region Public Properties
		
		public int Id
		{
			get {return _id;}
			set {_id = value;}
		}

		public string StrItemCode
		{
			get { return _strItemCode; }
			set { _strItemCode = value; }
		}
		
		public Promotion Promotion
		{
			get { return _promotion; }
			set { _promotion = value; }
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
