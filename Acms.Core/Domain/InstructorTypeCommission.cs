using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region InstructorTypeCommission
	
	/// <summary>
	/// InstructorTypeCommission object for NHibernate mapped table 'tblInstructorTypeCommission'.
	/// </summary>
	public class InstructorTypeCommission
	{
		#region Member Variables
		
		protected int _id;
		protected string _strDescription;
		protected IList _classInstances = new ArrayList();
		protected IList _classSchedules = new ArrayList();
		protected InstructorCommission _instructorCommission;

		#endregion
		
		#region Constructors
		
		public InstructorTypeCommission() { }
		
		public InstructorTypeCommission( string strDescription )
		{
			this._strDescription = strDescription;
		}
		
		#endregion		

		#region Public Properties
		
		public int Id
		{
			get {return _id;}
			set {_id = value;}
		}

		public string StrDescription
		{
			get { return _strDescription; }
			set { _strDescription = value; }
		}
		
		public IList ClassInstances
		{
			get { return _classInstances; }
			set { _classInstances = value; }
		}
		
		public IList ClassSchedules
		{
			get { return _classSchedules; }
			set { _classSchedules = value; }
		}
		
		public InstructorCommission InstructorCommission
		{
			get { return _instructorCommission; }
			set { _instructorCommission = value; }
		}
		
		#endregion
	}
	
	#endregion
}
