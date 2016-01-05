using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region JobPosition
	
	/// <summary>
	/// JobPosition object for NHibernate mapped table 'tblJobPosition'.
	/// </summary>
	public class JobPosition
	{
		#region Member Variables
		
		protected string _id;
		protected string _strDescription;
		protected DiscountCategory _discountCategory;
		protected IList _employees = new ArrayList();

		#endregion
		
		#region Constructors
		
		public JobPosition() { }
		
		public JobPosition( string strDescription, DiscountCategory discountCategory )
		{
			this._strDescription = strDescription;
			this._discountCategory = discountCategory;
		}
		
		#endregion		

		#region Public Properties
		
		public virtual string Id
		{
			get {return _id;}
			set {_id = value;}
		}

		public virtual string StrDescription
		{
			get { return _strDescription; }
			set { _strDescription = value; }
		}
		
		public virtual DiscountCategory DiscountCategory
		{
			get { return _discountCategory; }
			set { _discountCategory = value; }
		}

		public IList Employees
		{
			get { return _employees; }
			set { _employees = value; }
		}
		
		#endregion
	}
	
	#endregion
}
