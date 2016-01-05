using System;

namespace Acms.Core.Domain
{
	/// <summary>
	/// Summary description for EmployeeBranchRights.
	/// </summary>
	public class PackageBranch
	{
		protected Branch _branch;
		protected Package _packageCode;

		public PackageBranch()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public PackageBranch(Branch branch, Package packageCode)
		{
			this._branch = branch;
			this._packageCode = packageCode;
		}

		public Branch Branch
		{
			set{_branch = value;}
			get{return _branch;}
		}

		public Package Package
		{
			set{_packageCode = value;}
			get{return _packageCode;}
		}
	}
}
