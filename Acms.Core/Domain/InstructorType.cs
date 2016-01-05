using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region InstructorType
	
	/// <summary>
	/// InstructorType object for NHibernate mapped table 'tblInstructorType'.
	/// </summary>
	public class InstructorType
	{
		#region Member Variables
		
		protected int _id;
		protected string _strDescription;
		protected int _nBonusTypeID;
		protected IList _employees = new ArrayList();
		protected IList _instructorCommissions = new ArrayList();

		#endregion
		
		#region Constructors
		
		public InstructorType() { }
		
		public InstructorType( string strDescription, int nBonusTypeID )
		{
			this._strDescription = strDescription;
			this._nBonusTypeID = nBonusTypeID;
		}
		
		#endregion		

		#region Public Properties
		
		public virtual int Id
		{
			get {return _id;}
			set {_id = value;}
		}

		public virtual string StrDescription
		{
			get { return _strDescription; }
			set { _strDescription = value; }
		}
		
		public virtual int NBonusTypeID
		{
			get { return _nBonusTypeID; }
			set { _nBonusTypeID = value; }
		}
		
		public IList Employees
		{
			get { return _employees; }
			set { _employees = value; }
		}
		
		public IList InstructorCommissions
		{
			get { return _instructorCommissions; }
			set { _instructorCommissions = value; }
		}
		
		
		public void AddInstructorCommission(InstructorCommission instructorCommission)
		{
			instructorCommission.InstructorType = this;
			_instructorCommissions.Add(instructorCommission);
			
		}

		#endregion
	}
	
	#endregion
}
