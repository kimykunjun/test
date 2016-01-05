using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region IPP
	
	/// <summary>
	/// IPP object for NHibernate mapped table 'tblIPP'.
	/// </summary>
	public class IPP
	{
		#region Member Variables
		
		protected int _id;
		protected DateTime _dtDate;
		protected int _nMonths;
		protected string _strCreditCardNo;
		protected Bank _bank;
		protected Member _member;
		protected IList _receiptPayments = new ArrayList();

		#endregion
		
		#region Constructors
		
		public IPP() { }
		
		public IPP( DateTime dtDate, int nMonths, string strCreditCardNo, Bank bank, Member member )
		{
			this._dtDate = dtDate;
			this._nMonths = nMonths;
			this._strCreditCardNo = strCreditCardNo;
			this._bank = bank;
			this._member = member;
		}
		
		#endregion		

		#region Public Properties
		
		public int Id
		{
			get {return _id;}
			set {_id = value;}
		}

		public DateTime DtDate
		{
			get { return _dtDate; }
			set { _dtDate = value; }
		}
		
		public int NMonths
		{
			get { return _nMonths; }
			set { _nMonths = value; }
		}
		
		public string StrCreditCardNo
		{
			get { return _strCreditCardNo; }
			set { _strCreditCardNo = value; }
		}
		
		public Bank Bank
		{
			get { return _bank; }
			set { _bank = value; }
		}

		public Member Member
		{
			get { return _member; }
			set { _member = value; }
		}

		public IList ReceiptPayments
		{
			get { return _receiptPayments; }
			set { _receiptPayments = value; }
		}
		
		public void AddReceiptPayment(ReceiptPayment receiptPayment)
		{
			receiptPayment.IPP = this;
			_receiptPayments.Add(receiptPayment);
		}
		#endregion
	}
	
	#endregion
}
