using System;

namespace Acms.Core.Domain
{
	/// <summary>
	/// Summary description for EmployeeBranchRights.
	/// </summary>
	public class RewardsBranch
	{
		protected Branch _branch;
		protected Reward _rewards;

		public RewardsBranch()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public RewardsBranch(Branch branch, Reward rewards)
		{
			this._branch = branch;
			this._rewards = rewards;
		}

		public Branch Branch
		{
			set{_branch = value;}
			get{return _branch;}
		}

		public Reward Reward
		{
			set{_rewards = value;}
			get{return _rewards;}
		}
	}
}


