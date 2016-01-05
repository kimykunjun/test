using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region LoyaltyStatus
	
	/// <summary>
	/// LoyaltyStatus object for NHibernate mapped table 'tblLoyaltyStatus'.
	/// </summary>
	public class LoyaltyStatus
	{
		#region Member Variables
		
		protected int _id;
		protected string _strDescription;
		protected DiscountCategory _discountCategory;
		protected IList _members = new ArrayList();

		#endregion
		
		#region Constructors
		
		public LoyaltyStatus() { }
		
		public LoyaltyStatus( string strDescription, DiscountCategory discountCategory )
		{
			this._strDescription = strDescription;
			this._discountCategory = discountCategory;
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
		
		public DiscountCategory DiscountCategory
		{
			get { return _discountCategory; }
			set { _discountCategory = value; }
		}

		public IList Members
		{
			get { return _members; }
			set { _members = value; }
		}
		
		public void AddMember(Member member)
		{
			member.LoyaltyStatus = this;
			_members.Add(member);
		}
		#endregion
	}
	
	#endregion
}
