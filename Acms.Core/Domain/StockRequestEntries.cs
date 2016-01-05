using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region StockRequestEntry
	
	/// <summary>
	/// StockRequestEntry object for NHibernate mapped table 'tblStockRequestEntries'.
	/// </summary>
	public class StockRequestEntry
	{
		#region Member Variables
		
		protected int _id;
		protected Product _strItemCode;
		protected int _nQuantity;
		protected StockRequest _stockRequest;
		protected Employee _employee;
		protected Test _test;

		#endregion
		
		#region Constructors
		
		public StockRequestEntry() { }
		
		public StockRequestEntry( Product strItemCode, int nQuantity, StockRequest stockRequest )
		{
			this._strItemCode = strItemCode;
			this._nQuantity = nQuantity;
			this._stockRequest = stockRequest;
		}
		
		#endregion		

		#region Public Properties
		
		public int Id
		{
			get {return _id;}
			set {_id = value;}
		}

		public Product Product
		{
			get { return _strItemCode; }
			set { _strItemCode = value; }
		}

		

		public Employee Employee
		{
			get { return _employee; }
			set { _employee = value; }
		}

		public string ProductStrItemCode
		{
			get { return _strItemCode.Id; }
			
		}

		public string ProductStrDescription
		{
			get { return _strItemCode.StrDescription; }
			
		}
		
		public int NQuantity
		{
			get { return _nQuantity; }
			set { _nQuantity = value; }
		}
		
		public StockRequest StockRequest
		{
			get { return _stockRequest; }
			set { _stockRequest = value; }
		}

		
		public Test Test
		{
			set{_test=value;}
			get{return _test;}
		}
		#endregion
	}
	
	#endregion
}
