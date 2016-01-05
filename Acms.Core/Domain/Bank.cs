using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region Bank
	
	/// <summary>
	/// Bank object for NHibernate mapped table 'tblBank'.
	/// </summary>
	public class Bank
	{
		#region Member Variables
		
		protected string _id;
		protected string _strDescription;
		protected IList _gIROs = new ArrayList();
		protected IList _iPPs = new ArrayList();
		protected IList _bankIPPRates = new ArrayList();

		#endregion
		
		#region Constructors
		
		public Bank() { }
		
		public Bank( string strDescription )
		{
			this._strDescription = strDescription;
		}
		
		#endregion		

		#region Public Properties
		
		public string Id
		{
			get {return _id;}
			set {_id = value;}
		}

		public string StrDescription
		{
			get { return _strDescription; }
			set { _strDescription = value; }
		}
		
		public IList GIROs
		{
			get { return _gIROs; }
			set { _gIROs = value; }
		}
		
		public IList IPPs
		{
			get { return _iPPs; }
			set { _iPPs = value; }
		}
		
		public IList BankIPPRates
		{
			get { 
				
				return _bankIPPRates; 
			
			}
			set { _bankIPPRates = value; }
		}
		
		public void AddBankIPPRate(BankIPPRate bankIPPRate)
		{
			bankIPPRate.Bank = this;
			_bankIPPRates.Add(bankIPPRate);
		}

		public void AddGIRO(GIRO gIRO)
		{
			gIRO.Bank = this;
			_gIROs.Add(gIRO);
		}

		public void AddIPP(IPP iPP)
		{
			iPP.Bank = this;
			_iPPs.Add(iPP);
		}

		#endregion
	}
	
	#endregion
}
