using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region SalonUse
	
	/// <summary>
	/// SalonUse object for NHibernate mapped table 'tblSalonUse'.
	/// </summary>
	public class SalonUse
	{
		#region Member Variables
		
		protected int _id;
		protected DateTime _dtDate;
		protected int _nQuantity;
		protected Branch _branch;
		protected Product _product;
		protected Employee _employee;

		#endregion
		
		#region Constructors
		
		public SalonUse() { }
		
		public SalonUse( DateTime dtDate, int nQuantity, Branch branch, Product product, Employee employee )
		{
			this._dtDate = dtDate;
			this._nQuantity = nQuantity;
			this._branch = branch;
			this._product = product;
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
		
		public int NQuantity
		{
			get { return _nQuantity; }
			set { _nQuantity = value; }
		}
		
		public Branch Branch
		{
			get { return _branch; }
			set { _branch = value; }
		}

		public Product Product
		{
			get { return _product; }
			set { _product = value; }
		}

		public Employee Employee
		{
			get { return _employee; }
			set { _employee = value; }
		}

		#endregion
	}
	
	#endregion
}
