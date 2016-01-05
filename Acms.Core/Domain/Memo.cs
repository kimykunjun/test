using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region Memo
	
	/// <summary>
	/// Memo object for NHibernate mapped table 'tblMemo'.
	/// </summary>
	public class Memo
	{
		#region Member Variables
		
		protected int _id;
		protected DateTime _dtDate;
		protected string _strTitle;
		protected string _strMessage;
		protected DateTime _dtLastEditDate;
		protected int _nStatusID;
		protected Employee _employee;
		protected IList _memoBranchs = new ArrayList();
		protected IList _memoBulletins = new ArrayList();
		protected IList _memoReads = new ArrayList();
		protected IList _memoReceipients = new ArrayList();

		#endregion
		
		#region Constructors
		
		public Memo() { }
		
		public Memo( DateTime dtDate, string strTitle, string strMessage, DateTime dtLastEditDate, int nStatusID, Employee employee )
		{
			this._dtDate = dtDate;
			this._strTitle = strTitle;
			this._strMessage = strMessage;
			this._dtLastEditDate = dtLastEditDate;
			this._nStatusID = nStatusID;
			this._employee = employee;
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
		
		public string StrTitle
		{
			get { return _strTitle; }
			set { _strTitle = value; }
		}
		
		public string StrMessage
		{
			get { return _strMessage; }
			set { _strMessage = value; }
		}
		
		public DateTime DtLastEditDate
		{
			get { return _dtLastEditDate; }
			set { _dtLastEditDate = value; }
		}
		
		public int NStatusID
		{
			get { return _nStatusID; }
			set { _nStatusID = value; }
		}
		
		public Employee Employee
		{
			get { return _employee; }
			set { _employee = value; }
		}

		public IList MemoBranchs
		{
			get { return _memoBranchs; }
			set { _memoBranchs = value; }
		}
		
		public IList MemoBulletins
		{
			get { return _memoBulletins; }
			set { _memoBulletins = value; }
		}
		
		public IList MemoReads
		{
			get { return _memoReads; }
			set { _memoReads = value; }
		}
		
		public IList MemoReceipients
		{
			get { return _memoReceipients; }
			set { _memoReceipients = value; }
		}

		
		public void AddMemoBranch(MemoBranch memoBranch)
		{
			memoBranch.Memo = this;
			_memoBranchs.Add(memoBranch);
			
		}
		
		public void AddMemoRead(MemoRead memoRead)
		{
			memoRead.Memo = this;
			_memoReads.Add(memoRead);
			
		}

		public void AddMemoBulletin(MemoBulletin memoBulletin)
		{
			memoBulletin.Memo = this;
			_memoBulletins.Add(memoBulletin);
		}

		public void AddMemoReceipient(MemoReceipient memoReceipient)
		{
			memoReceipient.Memo = this;
			_memoReceipients.Add(memoReceipient);
		}

	

		#endregion
	}
	
	#endregion
}
