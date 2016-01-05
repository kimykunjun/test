using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region Receipt
	
	/// <summary>
	/// Receipt object for NHibernate mapped table 'tblReceipt'.
	/// </summary>
	public class Receipt
	{
		#region Member Variables
		
		protected string _id;
		protected DateTime _dtDate;
		protected int _nShiftID;
		protected int _nTerminalID;
		protected decimal _mNettAmount;
		protected decimal _mGSTAmount;
		protected decimal _mTotalAmount;
		protected decimal _mVoucherAmount;
		protected bool _fVoid;
		protected string _strReferenceNo;
		protected string _strParentReceiptNo;
		protected string _strChildReceiptNo;
		protected Branch _branch;
		protected Category _category;
		protected Employee _employeenSalespersonID;
		protected Employee _employeenCashierID;
		protected Employee _employeenTherapistID;
		protected Member _member;
		protected Promotion _promotionstrDiscountCode;
		protected Promotion _promotionstrFreebieCode;
		protected Reward _reward;
		protected Tax _tax;
		protected IList _receiptEntrieses = new ArrayList();
		protected IList _receiptFreebies = new ArrayList();
		protected IList _receiptPayments = new ArrayList();

		#endregion
		
		#region Constructors
		
		public Receipt() { }
		
		public Receipt( DateTime dtDate, int nShiftID, int nTerminalID, decimal mNettAmount, decimal mGSTAmount, decimal mTotalAmount, decimal mVoucherAmount, bool fVoid, string strReferenceNo, string strParentReceiptNo, string strChildReceiptNo, Branch branch, Category category, Employee employeenSalespersonID, Employee employeenCashierID, Employee employeenTherapistID, Member member, Promotion promotionstrDiscountCode, Promotion promotionstrFreebieCode, Reward reward, Tax tax )
		{
			this._dtDate = dtDate;
			this._nShiftID = nShiftID;
			this._nTerminalID = nTerminalID;
			this._mNettAmount = mNettAmount;
			this._mGSTAmount = mGSTAmount;
			this._mTotalAmount = mTotalAmount;
			this._mVoucherAmount = mVoucherAmount;
			this._fVoid = fVoid;
			this._strReferenceNo = strReferenceNo;
			this._strParentReceiptNo = strParentReceiptNo;
			this._strChildReceiptNo = strChildReceiptNo;
			this._branch = branch;
			this._category = category;
			this._employeenSalespersonID = employeenSalespersonID;
			this._employeenCashierID = employeenCashierID;
			this._employeenTherapistID = employeenTherapistID;
			this._member = member;
			this._promotionstrDiscountCode = promotionstrDiscountCode;
			this._promotionstrFreebieCode = promotionstrFreebieCode;
			this._reward = reward;
			this._tax = tax;
		}
		
		#endregion		

		#region Public Properties
		
		public string Id
		{
			get {return _id;}
			set {_id = value;}
		}

		public DateTime DtDate
		{
			get { return _dtDate; }
			set { _dtDate = value; }
		}
		
		public int NShiftID
		{
			get { return _nShiftID; }
			set { _nShiftID = value; }
		}
		
		public int NTerminalID
		{
			get { return _nTerminalID; }
			set { _nTerminalID = value; }
		}
		
		public decimal MNettAmount
		{
			get { return _mNettAmount; }
			set { _mNettAmount = value; }
		}
		
		public decimal MGSTAmount
		{
			get { return _mGSTAmount; }
			set { _mGSTAmount = value; }
		}
		
		public decimal MTotalAmount
		{
			get { return _mTotalAmount; }
			set { _mTotalAmount = value; }
		}
		
		public decimal MVoucherAmount
		{
			get { return _mVoucherAmount; }
			set { _mVoucherAmount = value; }
		}
		
		public bool FVoid
		{
			get { return _fVoid; }
			set { _fVoid = value; }
		}
		
		public string StrReferenceNo
		{
			get { return _strReferenceNo; }
			set { _strReferenceNo = value; }
		}
		
		public string StrParentReceiptNo
		{
			get { return _strParentReceiptNo; }
			set { _strParentReceiptNo = value; }
		}
		
		public string StrChildReceiptNo
		{
			get { return _strChildReceiptNo; }
			set { _strChildReceiptNo = value; }
		}
		
		public Branch Branch
		{
			get { return _branch; }
			set { _branch = value; }
		}

		public Category Category
		{
			get { return _category; }
			set { _category = value; }
		}

		public Employee EmployeenSalespersonID
		{
			get { return _employeenSalespersonID; }
			set { _employeenSalespersonID = value; }
		}

		public Employee EmployeenCashierID
		{
			get { return _employeenCashierID; }
			set { _employeenCashierID = value; }
		}

		public Employee EmployeenTherapistID
		{
			get { return _employeenTherapistID; }
			set { _employeenTherapistID = value; }
		}

		public Member Member
		{
			get { return _member; }
			set { _member = value; }
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

		public Reward Reward
		{
			get { return _reward; }
			set { _reward = value; }
		}

		public Tax Tax
		{
			get { return _tax; }
			set { _tax = value; }
		}

		public IList ReceiptEntrieses
		{
			get { return _receiptEntrieses; }
			set { _receiptEntrieses = value; }
		}
		
		public IList ReceiptFreebies
		{
			get { return _receiptFreebies; }
			set { _receiptFreebies = value; }
		}
		
		public IList ReceiptPayments
		{
			get { return _receiptPayments; }
			set { _receiptPayments = value; }
		}

//		protected IList _receiptEntrieses = new ArrayList();
//		protected IList _receiptFreebies = new ArrayList();
//		protected IList _receiptPayments = new ArrayList();

		public void AddReceiptEntry(ReceiptEntries receiptEntries)
		{
			receiptEntries.Receipt = this;
			_receiptEntrieses.Add(receiptEntries);
		}

		public void AddReceiptFreebie(ReceiptFreebie receiptFreebie)
		{
			receiptFreebie.Receipt = this;
			_receiptFreebies.Add(receiptFreebie);
		}

		public void AddReceiptPayment(ReceiptPayment receiptPayment)
		{
			receiptPayment.Receipt = this;
			_receiptPayments.Add(receiptPayment);
		}
		
		#endregion
	}
	
	#endregion
}
