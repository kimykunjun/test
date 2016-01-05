using System;

namespace Acms.Core.Domain
{
	/// <summary>
	/// Summary description for EmployeeBranchRights.
	/// </summary>
	public class MemoGroupEntry
	{
		protected MemoGroup _memoGroup;
		protected Employee _employee;

		public MemoGroupEntry()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public MemoGroupEntry(MemoGroup _memoGroup, Employee employee)
		{
			this._memoGroup = _memoGroup;
			this._employee = employee;
		}

		public MemoGroup MemoGroup
		{
			set{_memoGroup = value;}
			get{return _memoGroup;}
		}

		public Employee Employee
		{
			set{_employee = value;}
			get{return _employee;}
		}
	}
}
