using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region LeaveType
	
	/// <summary>
	/// LeaveType object for NHibernate mapped table 'tblLeaveType'.
	/// </summary>
	public class LeaveType
	{
		#region Member Variables
		
		protected string _id;
		protected string _strDescription;
		protected IList _leaves = new ArrayList();

		#endregion
		
		#region Constructors
		
		public LeaveType() { }
		
		public LeaveType( string strDescription )
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
		
		public IList Leaves
		{
			get { return _leaves; }
			set { _leaves = value; }
		}
		
		public void AddLeave(Leave leave)
		{
			leave.LeaveType = this;
			_leaves.Add(leave);
		}
		#endregion
	}
	
	#endregion
}
