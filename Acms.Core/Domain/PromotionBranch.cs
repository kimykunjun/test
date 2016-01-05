using System;

namespace Acms.Core.Domain
{
	/// <summary>
	/// Summary description for EmployeeBranchRights.
	/// </summary>
	public class PromotionBranch
	{
		protected Branch _branch;
		protected Promotion _promotion;

		public PromotionBranch()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public PromotionBranch(Branch branch, Promotion promotion)
		{
			this._branch = branch;
			this._promotion = promotion;
		}

		public Branch Branch
		{
			set{_branch = value;}
			get{return _branch;}
		}

		public Promotion Promotion
		{
			set{_promotion = value;}
			get{return _promotion;}
		}
	}
}

