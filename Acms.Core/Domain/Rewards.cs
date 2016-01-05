using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region Reward
	
	/// <summary>
	/// Reward object for NHibernate mapped table 'tblRewards'.
	/// </summary>
	public class Reward
	{
		#region Member Variables
		
		protected string _id;
		protected string _strDescription;
		protected double _dRewardsPercent;
		protected double _dRewardsValue;
		protected DateTime _dtValidStart;
		protected DateTime _dtValidEnd;
		protected SalesCategory _salesCategory;
		protected IList _receipts = new ArrayList();
		protected IList _rewardsBranchs = new ArrayList();

		#endregion
		
		#region Constructors
		
		public Reward() { }
		
		public Reward( string strDescription, double dRewardsPercent, double dRewardsValue, DateTime dtValidStart, DateTime dtValidEnd, SalesCategory salesCategory )
		{
			this._strDescription = strDescription;
			this._dRewardsPercent = dRewardsPercent;
			this._dRewardsValue = dRewardsValue;
			this._dtValidStart = dtValidStart;
			this._dtValidEnd = dtValidEnd;
			this._salesCategory = salesCategory;
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
		
		public double DRewardsPercent
		{
			get { return _dRewardsPercent; }
			set { _dRewardsPercent = value; }
		}
		
		public double DRewardsValue
		{
			get { return _dRewardsValue; }
			set { _dRewardsValue = value; }
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
		
		public SalesCategory SalesCategory
		{
			get { return _salesCategory; }
			set { _salesCategory = value; }
		}

		public IList Receipts
		{
			get { return _receipts; }
			set { _receipts = value; }
		}
		
		public void AddReceipt(Receipt receipt)
		{
			receipt.Reward = this;
			_receipts.Add(receipt);
		}

		public IList RewardsBranchs
		{
			get { return _rewardsBranchs; }
			set { _rewardsBranchs = value; }
		}

		public void AddRewardsBranch(RewardsBranch rewardsBranch)
		{
			rewardsBranch.Reward = this;
			_rewardsBranchs.Add(rewardsBranch);
		}
		
		#endregion
	}
	
	#endregion
}
