using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region MemoBulletin
	
	/// <summary>
	/// MemoBulletin object for NHibernate mapped table 'tblMemoBulletin'.
	/// </summary>
	public class MemoBulletin
	{
		#region Member Variables
		
		protected int _id;
		protected DateTime _dtDate;
		protected string _strMessage;
		protected Employee _employee;
		protected Memo _memo;
		protected Test _test;
		protected Product _product;

		#endregion
		
		#region Constructors
		
		public MemoBulletin() { }
		
		public MemoBulletin( DateTime dtDate, string strMessage, Employee employee, Memo memo )
		{
			this._dtDate = dtDate;
			this._strMessage = strMessage;
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
		
		public string StrMessage
		{
			get { return _strMessage; }
			set { _strMessage = value; }
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

		public Test Test
		{
			get{ return _test; }
			set{ _test = value;}
		}

		public Product Product
		{
			get{ return _product;}
			set{_product = value;}
		}

		#endregion
	}
	
	#endregion
}
