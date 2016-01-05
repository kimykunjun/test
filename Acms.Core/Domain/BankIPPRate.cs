using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region BankIPPRate
	
	/// <summary>
	/// BankIPPRate object for NHibernate mapped table 'tblBankIPPRate'.
	/// </summary>
	public class BankIPPRate
	{
		#region Member Variables
		
		protected string _id;
		protected int _mMonth;
		protected double _dInterestRate;
		protected Bank _bank;

		#endregion
		
		#region Constructors
		
		public BankIPPRate() { }
		
		public BankIPPRate( int mMonth,double dInterestRate, Bank bank )
		{
			this._dInterestRate = dInterestRate;
			this._bank = bank;
			this._mMonth = mMonth;
		}
		
		#endregion		

		#region Public Properties
		
		public string Id
		{
			get {return _id;}
			set {_id = value;}
		}

		public int MMonth
		{
			get{return _mMonth;}
			set{_mMonth = value;}
		}

		public double DInterestRate
		{
			get { return _dInterestRate; }
			set { _dInterestRate = value; }
		}
		
		public Bank Bank
		{
			get { return _bank; }
			set { _bank = value; }
		}

		#endregion
	}
	
	#endregion
}
