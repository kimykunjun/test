using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region BranchTarget
	
	/// <summary>
	/// BranchTarget object for NHibernate mapped table 'tblBranchTarget'.
	/// </summary>
	public class BranchTarget
	{
		#region Member Variables
		
		protected string _id;
		protected decimal _mFitnessPackageTarget;
		protected decimal _mFitnessProductTarget;
		protected decimal _mSpaPackageTarget;
		protected decimal _mSpaProductTarget;
		protected decimal _mPTPackageTarget;
		protected int _nYearId;
		protected int _nMonthId;
		protected Branch _branch;

		#endregion
		
		#region Constructors
		
		public BranchTarget() { }
		
		public BranchTarget( decimal mFitnessPackageTarget, decimal mFitnessProductTarget, decimal mSpaPackageTarget, decimal mSpaProductTarget, decimal mPTPackageTarget, Branch branch )
		{
			this._mFitnessPackageTarget = mFitnessPackageTarget;
			this._mFitnessProductTarget = mFitnessProductTarget;
			this._mSpaPackageTarget = mSpaPackageTarget;
			this._mSpaProductTarget = mSpaProductTarget;
			this._mPTPackageTarget = mPTPackageTarget;
			this._branch = branch;
		}
		
		#endregion		

		#region Public Properties
		
		public string Id
		{
			get {return _id;}
			set {_id = value;}
		}

		public int NMonthID
		{
			get{return _nMonthId;}
			set{_nMonthId = value;}
		}

		public int NYearID
		{
			get{return _nYearId;}
			set{_nYearId = value;}
		}

		public decimal MFitnessPackageTarget
		{
			get { return _mFitnessPackageTarget; }
			set { _mFitnessPackageTarget = value; }
		}
		
		public decimal MFitnessProductTarget
		{
			get { return _mFitnessProductTarget; }
			set { _mFitnessProductTarget = value; }
		}
		
		public decimal MSpaPackageTarget
		{
			get { return _mSpaPackageTarget; }
			set { _mSpaPackageTarget = value; }
		}
		
		public decimal MSpaProductTarget
		{
			get { return _mSpaProductTarget; }
			set { _mSpaProductTarget = value; }
		}
		
		public decimal MPTPackageTarget
		{
			get { return _mPTPackageTarget; }
			set { _mPTPackageTarget = value; }
		}
		
		public Branch Branch
		{
			get { return _branch; }
			set { _branch = value; }
		}

		#endregion
	}
	
	#endregion
}
