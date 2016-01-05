using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region Tax
	
	/// <summary>
	/// Tax object for NHibernate mapped table 'tblTax'.
	/// </summary>
	public class Tax
	{
		#region Member Variables
		
		protected int _id;
		protected string _strDescription;
		protected double _dTaxRate;
		protected IList _companies = new ArrayList();
		protected IList _receipts = new ArrayList();

		#endregion
		
		#region Constructors
		
		public Tax() { }
		
		public Tax( string strDescription, double dTaxRate )
		{
			this._strDescription = strDescription;
			this._dTaxRate = dTaxRate;
		}
		
		#endregion		

		#region Public Properties
		
		public int Id
		{
			get {return _id;}
			set {_id = value;}
		}

		public string StrDescription
		{
			get { return _strDescription; }
			set { _strDescription = value; }
		}
		
		public double DTaxRate
		{
			get { return _dTaxRate; }
			set { _dTaxRate = value; }
		}
		
		public IList Companies
		{
			get { return _companies; }
			set { _companies = value; }
		}
		
		public IList Receipts
		{
			get { return _receipts; }
			set { _receipts = value; }
		}

		public void AddCompany(Company company)
		{
			company.Tax = this;
			_companies.Add(company);
		}
		
		public void AddReceipt(Receipt receipt)
		{
			receipt.Tax = this;
			_receipts.Add(receipt);
		}

		#endregion
	}
	
	#endregion
}
