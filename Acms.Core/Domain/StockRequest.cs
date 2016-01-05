using System;
using System.Collections;


// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region StockRequest
	
	/// <summary>
	/// StockRequest object for NHibernate mapped table 'tblStockRequest'.
	/// </summary>
	public class StockRequest
	{
		#region Member Variables
		
		protected int _id;
		protected DateTime _dtDate;
		protected int _nStatusID;
		protected string _strRemarks;
		protected DateTime _dtLastEditDate;
		protected Branch _branchFrom;
		protected Branch _branchTo;
		protected Employee _employee;
		protected IBT _iBT;
		protected IList _stockRequestEntrieses = new ArrayList();

		#endregion
		
		#region Constructors
		
		public StockRequest() { }
		
		public StockRequest( DateTime dtDate, int nStatusID,string strRemarks, DateTime dtLastEditDate, Branch branchFrom, Branch branchTo, Employee employee, IBT iBT )
		{
			this._dtDate = dtDate;
			this._nStatusID = nStatusID;
			this._dtLastEditDate = dtLastEditDate;
			this._branchFrom = branchFrom;
			this._branchTo = branchTo;
			this._employee = employee;
			this._iBT = iBT;
			this._strRemarks=strRemarks;
		}
		
		#endregion		

		#region Public Properties
		
		public int Id
		{
			get {return _id;}
			set {_id = value;}
		}

		public string StrRemarks
		{
			get{return _strRemarks;}
			set{_strRemarks=value;}
		}

		public DateTime DtDate
		{
			get { return _dtDate; }
			set { _dtDate = value; }
		}

		//Bind To DataGrid
		public string DtDateString
		{
			get { return _dtDate.ToString(); }
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
				if(_nStatusID==0)
				{
					return "Pending";
				}
				else if(_nStatusID==1)
				{
					return "Processed";
				}
				else if(_nStatusID==2)
				{
					return "Rejected";
				}
				else
				{
					return "Unknown Type";
				}
			}
		}
		
		public DateTime DtLastEditDate
		{
			get { return _dtLastEditDate; }
			set { _dtLastEditDate = value; }
		}
		
		public Branch BranchFrom
		{
			get { return _branchFrom; }
			set { _branchFrom = value; }
		}

		public string BranchFromName
		{
			get{return _branchFrom.Id;}
		}

		public Branch BranchTo
		{
			get { return _branchTo; }
			set { _branchTo = value; }
		}

		public string BranchToName
		{
			get{return _branchTo.Id;}
		}

		public Employee Employee
		{
			get { return _employee; }
			set { _employee = value; }
		}

		public string EmployeeName
		{
			get{return _employee.StrEmployeeName;}
		}

		public IBT IBT
		{
			get { return _iBT; }
			set { _iBT = value; }
		}

		public IList StockRequestEntrieses
		{
			get { return _stockRequestEntrieses; }
			set { _stockRequestEntrieses = value; }
		}

		public void AddStockRequestEntry(StockRequestEntry stockRequestEntry)
		{
			stockRequestEntry.StockRequest = this;
			_stockRequestEntrieses.Add(stockRequestEntry);
		}
		
		#endregion
	}
	
	#endregion
}
