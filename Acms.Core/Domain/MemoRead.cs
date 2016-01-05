using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region MemoRead
	
	/// <summary>
	/// MemoRead object for NHibernate mapped table 'tblMemoRead'.
	/// </summary>
	public class MemoRead
	{
		#region Member Variables
		
		protected int _id;
		protected DateTime _dtDate;
		protected Employee _employee;
		protected Memo _memo;

		#endregion
		
		#region Constructors
		
		public MemoRead() { }
		
		public MemoRead( DateTime dtDate, Employee employee, Memo memo )
		{
			this._dtDate = dtDate;
			this._employee = employee;
			this._memo = memo;
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
		
		public Employee Employee
		{
			get { return _employee; }
			set { _employee = value; }
		}

		public Memo Memo
		{
			get { return _memo; }
			set { _memo = value; }
		}

		#endregion
	}
	
	#endregion
}
