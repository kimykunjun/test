using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region ReceiptPayment
	
	/// <summary>
	/// ReceiptPayment object for NHibernate mapped table 'tblReceiptPayment'.
	/// </summary>
	public class ReceiptPayment
	{
		#region Member Variables
		
		protected int _id;
		protected decimal _mAmount;
		protected string _strReferenceNo;
		protected IPP _iPP;
		protected Payment _payment;
		protected Receipt _receipt;

		#endregion
		
		#region Constructors
		
		public ReceiptPayment() { }
		
		public ReceiptPayment( decimal mAmount, string strReferenceNo, IPP iPP, Payment payment, Receipt receipt )
		{
			this._mAmount = mAmount;
			this._strReferenceNo = strReferenceNo;
			this._iPP = iPP;
			this._payment = payment;
			this._receipt = receipt;
		}
		
		#endregion		

		#region Public Properties
		
		public int Id
		{
			get {return _id;}
			set {_id = value;}
		}

		public decimal MAmount
		{
			get { return _mAmount; }
			set { _mAmount = value; }
		}
		
		public string StrReferenceNo
		{
			get { return _strReferenceNo; }
			set { _strReferenceNo = value; }
		}
		
		public IPP IPP
		{
			get { return _iPP; }
			set { _iPP = value; }
		}

		public Payment Payment
		{
			get { return _payment; }
			set { _payment = value; }
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
