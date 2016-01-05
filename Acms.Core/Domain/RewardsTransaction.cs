using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region RewardsTransaction
	
	/// <summary>
	/// RewardsTransaction object for NHibernate mapped table 'tblRewardsTransaction'.
	/// </summary>
	public class RewardsTransaction
	{
		#region Member Variables
		
		protected int _id;
		protected DateTime _dtDate;
		protected int _nTypeID;
		protected double _dRewardsPoints;
		protected string _strReferenceNo;
		protected RewardsCatalogue _rewardsCataloguestrReferenceNo;
		protected Employee _employee;
		protected Member _member;

		#endregion
		
		#region Constructors
		
		public RewardsTransaction() { }
		
		public RewardsTransaction( DateTime dtDate, int nTypeID, double dRewardsPoints, RewardsCatalogue rewardsCataloguestrReferenceNo, Employee employee, Member member )
		{
			this._dtDate = dtDate;
			this._nTypeID = nTypeID;
			this._dRewardsPoints = dRewardsPoints;
			this._rewardsCataloguestrReferenceNo = rewardsCataloguestrReferenceNo;
			this._employee = employee;
			this._member = member;
		}
		
		#endregion		

		#region Public Properties
		
		public int Id
		{
			get {return _id;}
			set {_id = value;}
		}

		public string StrReferenceNo
		{
			set{_strReferenceNo=value;}
			get{return _strReferenceNo;}
		}

		public DateTime DtDate
		{
			get { return _dtDate; }
			set { _dtDate = value; }
		}
		
		public int NTypeID
		{
			get { return _nTypeID; }
			set { _nTypeID = value; }
		}
		
		public double DRewardsPoints
		{
			get { return _dRewardsPoints; }
			set { _dRewardsPoints = value; }
		}
		
		public RewardsCatalogue RewardsCataloguestrReferenceNo
		{
			get { return _rewardsCataloguestrReferenceNo; }
			set { _rewardsCataloguestrReferenceNo = value; }
		}

		public Employee Employee
		{
			get { return _employee; }
			set { _employee = value; }
		}

		public Member Member
		{
			get { return _member; }
			set { _member = value; }
		}

		#endregion
	}
	
	#endregion
}
