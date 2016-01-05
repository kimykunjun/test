using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region MemoGroup
	
	/// <summary>
	/// MemoGroup object for NHibernate mapped table 'tblMemoGroup'.
	/// </summary>
	public class MemoGroup
	{
		#region Member Variables
		
		protected int _id;
		protected string _strMemoGroupCode;
		protected string _strDescription;
		protected DateTime _dtLastEditDate;
		protected bool _fPublicAccess;
		protected Employee _employee;
		protected IList _memoGroupEntrys = new ArrayList();

		#endregion
		
		#region Constructors
		
		public MemoGroup() { }
		
		public MemoGroup( string strMemoGroupCode, string strDescription, DateTime dtLastEditDate, bool fPublicAccess, Employee employee )
		{
			this._strMemoGroupCode = strMemoGroupCode;
			this._strDescription = strDescription;
			this._dtLastEditDate = dtLastEditDate;
			this._fPublicAccess = fPublicAccess;
			this._employee = employee;
		}
		
		#endregion		

		#region Public Properties
		
		public int Id
		{
			get {return _id;}
			set {_id = value;}
		}

		public string StrMemoGroupCode
		{
			get { return _strMemoGroupCode; }
			set { _strMemoGroupCode = value; }
		}
		
		public string StrDescription
		{
			get { return _strDescription; }
			set { _strDescription = value; }
		}
		
		public DateTime DtLastEditDate
		{
			get { return _dtLastEditDate; }
			set { _dtLastEditDate = value; }
		}
		
		public bool FPublicAccess
		{
			get { return _fPublicAccess; }
			set { _fPublicAccess = value; }
		}
		
		public Employee Employee
		{
			get { return _employee; }
			set { _employee = value; }
		}

		public IList MemoGroupEntrys
		{
			get { return _memoGroupEntrys; }
			set { _memoGroupEntrys = value; }
		}
		
		public void AddMemoGroupEntry(MemoGroupEntry memoGroupEntry)
		{
			memoGroupEntry.MemoGroup = this;
			_memoGroupEntrys.Add(memoGroupEntry);
			
		}

		#endregion
	}
	
	#endregion
}
