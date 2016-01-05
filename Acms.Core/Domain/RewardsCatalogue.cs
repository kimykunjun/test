using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region RewardsCatalogue
	
	/// <summary>
	/// RewardsCatalogue object for NHibernate mapped table 'tblRewardsCatalogue'.
	/// </summary>
	public class RewardsCatalogue
	{
		#region Member Variables
		
		protected string _id;
		protected string _strDescription;
		protected double _dRewardsPoints;
		protected DateTime _dtValidStart;
		protected DateTime _dtValidEnd;
		protected Product _productstrItemCode;
		

		#endregion
		
		#region Constructors
		
		public RewardsCatalogue() { }
		
		public RewardsCatalogue( string strDescription, double dRewardsPoints, DateTime dtValidStart, DateTime dtValidEnd, Product productstrItemCode )
		{
			this._strDescription = strDescription;
			this._dRewardsPoints = dRewardsPoints;
			this._dtValidStart = dtValidStart;
			this._dtValidEnd = dtValidEnd;
			this._productstrItemCode = productstrItemCode;
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
		
		public double DRewardsPoints
		{
			get { return _dRewardsPoints; }
			set { _dRewardsPoints = value; }
		}
		
		public DateTime DtValidStart
		{
			get { return _dtValidStart; }
			set { _dtValidStart = value; }
		}
		
		public DateTime DtValidEnd
		{
			get { return _dtValidEnd; }
			set { _dtValidEnd = value; }
		}
		
		public Product ProductstrItemCode
		{
			get { return _productstrItemCode; }
			set { _productstrItemCode = value; }
		}

//		public IList RewardsTransactionsstrReferenceNo
//		{
//			get { return _rewardsTransactionsstrReferenceNo; }
//			set { _rewardsTransactionsstrReferenceNo = value; }
//		}
//		
//		public void AddRewardsTransactions(RewardsTransaction rewardsTransactions)
//		{
//			rewardsTransactions.RewardsCataloguestrReferenceNo = this;
//			_rewardsTransactionsstrReferenceNo.Add(rewardsTransactions);
//
//		}
		#endregion
	}
	
	#endregion
}
