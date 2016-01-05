using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region DiscountCategory
	
	/// <summary>
	/// DiscountCategory object for NHibernate mapped table 'tblDiscountCategory'.
	/// </summary>
	public class DiscountCategory
	{
		#region Member Variables
		
		protected int _id;
		protected string _strDescription;
		protected IList _jobPositions = new ArrayList();
		protected IList _loyaltyStatuses = new ArrayList();
		protected IList _promotions = new ArrayList();

		#endregion
		
		#region Constructors
		
		public DiscountCategory() { }
		
		public DiscountCategory( string strDescription )
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
		
		public IList JobPositions
		{
			get { return _jobPositions; }
			set { _jobPositions = value; }
		}

		public void AddJobPosition(JobPosition jobPosition)
		{
			jobPosition.DiscountCategory = this;
			_jobPositions.Add(jobPosition);
		}
		
		public IList LoyaltyStatuses
		{
			get { return _loyaltyStatuses; }
			set { _loyaltyStatuses = value; }
		}

		public void AddLoyaltyStatus(LoyaltyStatus loyaltyStatus)
		{
			loyaltyStatus.DiscountCategory = this;
			_loyaltyStatuses.Add(loyaltyStatus);
		}
		
		public IList Promotions
		{
			get { return _promotions; }
			set { _promotions = value; }
		}
		
		public void AddPromotion(Promotion promotion)
		{
			promotion.DiscountCategory = this;
			_promotions.Add(promotion);
		}
		#endregion
	}
	
	#endregion
}
