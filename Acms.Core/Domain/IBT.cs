using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region IBT
	
	/// <summary>
	/// IBT object for NHibernate mapped table 'tblIBT'.
	/// </summary>
	public class IBT
	{
		#region Member Variables
		
		protected int _id;
		protected DateTime _dtDate;
		protected int _nStatusID;
		protected DateTime _dtLastEditDate;
		protected string _strRemarks;
		protected Branch _branchFrom;
		protected Branch _branchTo;
		protected Employee _employee;
		protected IList _iBTEntrieses = new ArrayList();
		protected IList _stockRequests = new ArrayList();

		#endregion
		
		#region Constructors
		
		public IBT() { }
		
		public IBT( DateTime dtDate, int nStatusID, DateTime dtLastEditDate, string strRemarks, Branch branchFrom, Branch branchTo, Employee employee )
		{
			this._dtDate = dtDate;
			this._nStatusID = nStatusID;
			this._dtLastEditDate = dtLastEditDate;
			this._strRemarks = strRemarks;
			this._branchFrom = branchFrom;
			this._branchTo = branchTo;
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
		
		public int NStatusID
		{
			get { return _nStatusID; }
			set { _nStatusID = value; }
		}
		
		public string StatusDesc
		{
			get
			{
				if(NStatusID==0)
				{
					return "Pending Receipt";
				}
				else if(NStatusID==1)
				{
					return "Received";
				}
				else if(NStatusID==2)
				{
					return "Cancelled";
				}
				else
				{
					return "Not valid  Id";
				}
			}
		}

		public DateTime DtLastEditDate
		{
			get { return _dtLastEditDate; }
			set { _dtLastEditDate = value; }
		}
		
		public string StrRemarks
		{
			get { return _strRemarks; }
			set { _strRemarks = value; }
		}
		
		public Branch BranchFrom
		{
			get { return _branchFrom; }
			set { _branchFrom = value; }
		}

		public Branch BranchTo
		{
			get { return _branchTo; }
			set { _branchTo = value; }
		}

		public string StrBranchCodeFrom
		{
			get{ return _branchFrom.Id;}
		}

		public string StrBranchCodeTo
		{
			get{ return _branchTo.Id;}
		}

		public Employee Employee
		{
			get { return _employee; }
			set { _employee = value; }
		}

		public string RequestedBy
		{
			get{ return _employee.StrEmployeeName;}
		}

		public IList IBTEntrieses
		{
			get { return _iBTEntrieses; }
			set { _iBTEntrieses = value; }
		}
		
		public IList StockRequests
		{
			get { return _stockRequests; }
			set { _stockRequests = value; }
		}

		public void AddIBTEntry(IBTEntry iBTEntry)
		{
			iBTEntry.IBT = this;
			_iBTEntrieses.Add(iBTEntry);
		}
		
		#endregion
	}
	
	#endregion
}
