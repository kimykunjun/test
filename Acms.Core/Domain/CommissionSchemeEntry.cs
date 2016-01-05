using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region CommissionSchemeEntry
	
	/// <summary>
	/// CommissionSchemeEntry object for NHibernate mapped table 'tblCommissionSchemeEntries'.
	/// </summary>
	public class CommissionSchemeEntry
	{
		#region Member Variables
		
		protected string _id;
		protected int _nPriorityID;
		protected int _nFitnessPackageBranchTargetPercent;
		protected int _nFitnessProductBranchTargetPercent;
		protected int _nSpaPackageBranchTargetPercent;
		protected int _nSpaProductBranchTargetPercent;
		protected int _nPTPackageBranchTargetPercent;
		protected int _nFitnessPackageIndTargetPercent;
		protected int _nFitnessProductIndTargetPercent;
		protected int _nSpaPackageIndTargetPercent;
		protected int _nSpaProductIndTargetPercent;
		protected int _nPTPackageIndTargetPercent;
		protected int _nFitnessPackageBranchExcess;
		protected int _nFitnessProductBranchExcess;
		protected int _nSpaPackageBranchExcess;
		protected int _nSpaProductBranchExcess;
		protected int _nPTPackageBranchExcess;
		protected int _nFitnessPackageIndExcess;
		protected int _nFitnessProductIndExcess;
		protected int _nSpaPackageIndExcess;
		protected int _nSpaProductIndExcess;
		protected int _nPTPackageIndExcess;
		protected int _nBranchPercentComm;
		protected int _nBranchPercentSharedComm;
		protected int _nIndPercentComm;
		protected decimal _mCommissionAmount;
		protected CommissionScheme _commissionScheme;

		#endregion
		
		#region Constructors
		
		public CommissionSchemeEntry() { }
		
		public CommissionSchemeEntry( int nPriorityID, int nFitnessPackageBranchTargetPercent, int nFitnessProductBranchTargetPercent, int nSpaPackageBranchTargetPercent, int nSpaProductBranchTargetPercent, int nPTPackageBranchTargetPercent, int nFitnessPackageIndTargetPercent, int nFitnessProductIndTargetPercent, int nSpaPackageIndTargetPercent, int nSpaProductIndTargetPercent, int nPTPackageIndTargetPercent, int nFitnessPackageBranchExcess, int nFitnessProductBranchExcess, int nSpaPackageBranchExcess, int nSpaProductBranchExcess, int nPTPackageBranchExcess, int nFitnessPackageIndExcess, int nFitnessProductIndExcess, int nSpaPackageIndExcess, int nSpaProductIndExcess, int nPTPackageIndExcess, int nBranchPercentComm, int nBranchPercentSharedComm, int nIndPercentComm, decimal mCommissionAmount, CommissionScheme commissionScheme )
		{
			this._nPriorityID = nPriorityID;
			this._nFitnessPackageBranchTargetPercent = nFitnessPackageBranchTargetPercent;
			this._nFitnessProductBranchTargetPercent = nFitnessProductBranchTargetPercent;
			this._nSpaPackageBranchTargetPercent = nSpaPackageBranchTargetPercent;
			this._nSpaProductBranchTargetPercent = nSpaProductBranchTargetPercent;
			this._nPTPackageBranchTargetPercent = nPTPackageBranchTargetPercent;
			this._nFitnessPackageIndTargetPercent = nFitnessPackageIndTargetPercent;
			this._nFitnessProductIndTargetPercent = nFitnessProductIndTargetPercent;
			this._nSpaPackageIndTargetPercent = nSpaPackageIndTargetPercent;
			this._nSpaProductIndTargetPercent = nSpaProductIndTargetPercent;
			this._nPTPackageIndTargetPercent = nPTPackageIndTargetPercent;
			this._nFitnessPackageBranchExcess = nFitnessPackageBranchExcess;
			this._nFitnessProductBranchExcess = nFitnessProductBranchExcess;
			this._nSpaPackageBranchExcess = nSpaPackageBranchExcess;
			this._nSpaProductBranchExcess = nSpaProductBranchExcess;
			this._nPTPackageBranchExcess = nPTPackageBranchExcess;
			this._nFitnessPackageIndExcess = nFitnessPackageIndExcess;
			this._nFitnessProductIndExcess = nFitnessProductIndExcess;
			this._nSpaPackageIndExcess = nSpaPackageIndExcess;
			this._nSpaProductIndExcess = nSpaProductIndExcess;
			this._nPTPackageIndExcess = nPTPackageIndExcess;
			this._nBranchPercentComm = nBranchPercentComm;
			this._nBranchPercentSharedComm = nBranchPercentSharedComm;
			this._nIndPercentComm = nIndPercentComm;
			this._mCommissionAmount = mCommissionAmount;
			this._commissionScheme = commissionScheme;
		}
		
		#endregion		

		#region Public Properties
		
		public string Id
		{
			get {return _id;}
			set {_id = value;}
		}

		public int NPriorityID
		{
			get {return _nPriorityID;}
			set {_nPriorityID = value;}
		}


		public int NFitnessPackageBranchTargetPercent
		{
			get { return _nFitnessPackageBranchTargetPercent; }
			set { _nFitnessPackageBranchTargetPercent = value; }
		}
		
		public int NFitnessProductBranchTargetPercent
		{
			get { return _nFitnessProductBranchTargetPercent; }
			set { _nFitnessProductBranchTargetPercent = value; }
		}
		
		public int NSpaPackageBranchTargetPercent
		{
			get { return _nSpaPackageBranchTargetPercent; }
			set { _nSpaPackageBranchTargetPercent = value; }
		}
		
		public int NSpaProductBranchTargetPercent
		{
			get { return _nSpaProductBranchTargetPercent; }
			set { _nSpaProductBranchTargetPercent = value; }
		}
		
		public int NPTPackageBranchTargetPercent
		{
			get { return _nPTPackageBranchTargetPercent; }
			set { _nPTPackageBranchTargetPercent = value; }
		}
		
		public int NFitnessPackageIndTargetPercent
		{
			get { return _nFitnessPackageIndTargetPercent; }
			set { _nFitnessPackageIndTargetPercent = value; }
		}
		
		public int NFitnessProductIndTargetPercent
		{
			get { return _nFitnessProductIndTargetPercent; }
			set { _nFitnessProductIndTargetPercent = value; }
		}
		
		public int NSpaPackageIndTargetPercent
		{
			get { return _nSpaPackageIndTargetPercent; }
			set { _nSpaPackageIndTargetPercent = value; }
		}
		
		public int NSpaProductIndTargetPercent
		{
			get { return _nSpaProductIndTargetPercent; }
			set { _nSpaProductIndTargetPercent = value; }
		}
		
		public int NPTPackageIndTargetPercent
		{
			get { return _nPTPackageIndTargetPercent; }
			set { _nPTPackageIndTargetPercent = value; }
		}
		
		public int NFitnessPackageBranchExcess
		{
			get { return _nFitnessPackageBranchExcess; }
			set { _nFitnessPackageBranchExcess = value; }
		}
		
		public int NFitnessProductBranchExcess
		{
			get { return _nFitnessProductBranchExcess; }
			set { _nFitnessProductBranchExcess = value; }
		}
		
		public int NSpaPackageBranchExcess
		{
			get { return _nSpaPackageBranchExcess; }
			set { _nSpaPackageBranchExcess = value; }
		}
		
		public int NSpaProductBranchExcess
		{
			get { return _nSpaProductBranchExcess; }
			set { _nSpaProductBranchExcess = value; }
		}
		
		public int NPTPackageBranchExcess
		{
			get { return _nPTPackageBranchExcess; }
			set { _nPTPackageBranchExcess = value; }
		}
		
		public int NFitnessPackageIndExcess
		{
			get { return _nFitnessPackageIndExcess; }
			set { _nFitnessPackageIndExcess = value; }
		}
		
		public int NFitnessProductIndExcess
		{
			get { return _nFitnessProductIndExcess; }
			set { _nFitnessProductIndExcess = value; }
		}
		
		public int NSpaPackageIndExcess
		{
			get { return _nSpaPackageIndExcess; }
			set { _nSpaPackageIndExcess = value; }
		}
		
		public int NSpaProductIndExcess
		{
			get { return _nSpaProductIndExcess; }
			set { _nSpaProductIndExcess = value; }
		}
		
		public int NPTPackageIndExcess
		{
			get { return _nPTPackageIndExcess; }
			set { _nPTPackageIndExcess = value; }
		}
		
		public int NBranchPercentComm
		{
			get { return _nBranchPercentComm; }
			set { _nBranchPercentComm = value; }
		}
		
		public int NBranchPercentSharedComm
		{
			get { return _nBranchPercentSharedComm; }
			set { _nBranchPercentSharedComm = value; }
		}
		
		public int NIndPercentComm
		{
			get { return _nIndPercentComm; }
			set { _nIndPercentComm = value; }
		}
		
		public decimal MCommissionAmount
		{
			get { return _mCommissionAmount; }
			set { _mCommissionAmount = value; }
		}
		
		public CommissionScheme CommissionScheme
		{
			get { return _commissionScheme; }
			set { _commissionScheme = value; }
		}

		#endregion
	}
	
	#endregion
}
