using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region PaymentGroup
	
	/// <summary>
	/// PaymentGroup object for NHibernate mapped table 'tblPaymentGroup'.
	/// </summary>
	public class PaymentGroup
	{
		#region Member Variables
		
		protected string _id;
		protected string _strDescription;
		protected IList _payments = new ArrayList();

		#endregion
		
		#region Constructors
		
		public PaymentGroup() { }
		
		public PaymentGroup( string strDescription )
		{
			this._strDescription = strDescription;
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
		
		public IList Payments
		{
			get { return _payments; }
			set { _payments = value; }
		}
		
		public void AddPayment(Payment payment)
		{
			payment.PaymentGroup = this;
			_payments.Add(payment);
		}
		#endregion
	}
	
	#endregion
}
