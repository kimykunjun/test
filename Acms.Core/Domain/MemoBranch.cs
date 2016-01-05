using System;

namespace Acms.Core.Domain
{
	/// <summary>
	/// Summary description for EmployeeBranchRights.
	/// </summary>
	public class MemoBranch
	{
		protected Branch _branch;
		protected Memo _memo;

		public MemoBranch()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public MemoBranch(Branch branch, Memo memo)
		{
			this._branch = branch;
			this._memo = memo;
		}

		public Branch Branch
		{
			set{_branch = value;}
			get{return _branch;}
		}

		public Memo Memo
		{
			set{_memo = value;}
			get{return _memo;}
		}
	}
}
