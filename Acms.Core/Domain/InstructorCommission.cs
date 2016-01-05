using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region InstructorCommission
	
	/// <summary>
	/// InstructorCommission object for NHibernate mapped table 'tblInstructorCommission'.
	/// </summary>
	public class InstructorCommission
	{
		#region Member Variables
		
		protected int _id;
		protected decimal _mCommissionAmount;
		protected InstructorType _instructorType;
		protected InstructorTypeCommission _instructorTypeCommission;

		#endregion
		
		#region Constructors
		
		public InstructorCommission() { }
		
		public InstructorCommission( decimal mCommissionAmount, InstructorType instructorType, InstructorTypeCommission instructorTypeCommission )
		{
			this._mCommissionAmount = mCommissionAmount;
			this._instructorType = instructorType;
			this._instructorTypeCommission = instructorTypeCommission;
		}
		
		#endregion		

		#region Public Properties
		
		public int Id
		{
			get {return _id;}
			set {_id = value;}
		}

		public decimal MCommissionAmount
		{
			get { return _mCommissionAmount; }
			set { _mCommissionAmount = value; }
		}
		
		public InstructorType InstructorType
		{
			get { return _instructorType; }
			set { _instructorType = value; }
		}

		public InstructorTypeCommission InstructorTypeCommission
		{
			get { return _instructorTypeCommission; }
			set { _instructorTypeCommission = value; }
		}

		#endregion
	}
	
	#endregion
}
