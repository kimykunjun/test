using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region Payment
	
	/// <summary>
	/// Payment object for NHibernate mapped table 'tblPayment'.
	/// </summary>
	public class Payment
	{
		#region Member Variables
		
		protected string _id;
		protected string _strDescription;
		protected PaymentGroup _paymentGroup;
		protected IList _receiptPayments = new ArrayList();

		#endregion
		
		#region Constructors
		
		public Payment() { }
		
		public Payment( string strDescription, PaymentGroup paymentGroup )
		{
			this._strDescription = strDescription;
			this._paymentGroup = paymentGroup;
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
		
		public PaymentGroup PaymentGroup
		{
			get { return _paymentGroup; }
			set { _paymentGroup = value; }
		}

		public IList ReceiptPayments
		{
			get { return _receiptPayments; }
			set { _receiptPayments = value; }
		}

		public void AddReceiptPayment(ReceiptPayment receiptPayment)
		{
			receiptPayment.Payment = this;
			_receiptPayments.Add(receiptPayment);
		}
		
		#endregion
	}
	
	#endregion
}
