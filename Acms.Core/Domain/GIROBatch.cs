using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region GIROBatch
	
	/// <summary>
	/// GIROBatch object for NHibernate mapped table 'tblGIROBatch'.
	/// </summary>
	public class GIROBatch
	{
		#region Member Variables
		
		protected string _id;
		protected DateTime _dtSendDate;
		protected DateTime _dtReceiveDate;
		protected string _strRemarks;
		protected Employee _employee;
		protected IList _gIROBatchEntrieses = new ArrayList();

		#endregion
		
		#region Constructors
		
		public GIROBatch() { }
		
		public GIROBatch( DateTime dtSendDate, DateTime dtReceiveDate, string strRemarks, Employee employee )
		{
			this._dtSendDate = dtSendDate;
			this._dtReceiveDate = dtReceiveDate;
			this._strRemarks = strRemarks;
			this._employee = employee;
		}
		
		#endregion		

		#region Public Properties
		
		public string Id
		{
			get {return _id;}
			set {_id = value;}
		}

		public DateTime DtSendDate
		{
			get { return _dtSendDate; }
			set { _dtSendDate = value; }
		}
		
		public DateTime DtReceiveDate
		{
			get { return _dtReceiveDate; }
			set { _dtReceiveDate = value; }
		}
		
		public string StrRemarks
		{
			get { return _strRemarks; }
			set { _strRemarks = value; }
		}
		
		public Employee Employee
		{
			get { return _employee; }
			set { _employee = value; }
		}

		public IList GIROBatchEntrieses
		{
			get { return _gIROBatchEntrieses; }
			set { _gIROBatchEntrieses = value; }
		}
		
		#endregion
	}
	
	#endregion
}
