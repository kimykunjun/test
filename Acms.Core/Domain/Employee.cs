using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region Employee
	
	/// <summary>
	/// Employee object for NHibernate mapped table 'tblEmployee'.
	/// </summary>
	public class Employee
	{
		#region Member Variables
		
		protected int _id;
		protected string _strEmployeeName;
		protected string _strPassword;
		protected string _strContactNo;
		protected decimal _mFitnessPackageTarget;
		protected decimal _mFitnessProductTarget;
		protected decimal _mSpaPackageTarget;
		protected decimal _mSpaProductTarget;
		protected decimal _mPTPackageTarget;
		protected int _nServiceCommLevel;
        protected string _MobileNo;
		protected Branch _branch;
		protected Department _department;
		protected InstructorType _instructorType;
		protected JobPosition _jobPosition;
		protected RightsLevel _rightsLevel;
		protected IList _employeeBranchRights = new ArrayList();
		protected IList _classInstancesnReplacementIssueID = new ArrayList();
		protected IList _classInstancesnReplacementVerifyID = new ArrayList();
		protected IList _classInstancesnActualInstructorID = new ArrayList();
		protected IList _timeCards = new ArrayList();
		protected IList _classInstancesnStandinInstructorID = new ArrayList();
		protected IList _classInstancesnVerifyID = new ArrayList();
		protected IList _classSchedulesnInstructorID = new ArrayList();
		protected IList _commissionSchemes = new ArrayList();
		protected IList _branches = new ArrayList();
		protected IList _commissionSchemes2 = new ArrayList();
		protected IList _gIROs = new ArrayList();
		protected IList _gIROBatches = new ArrayList();
		protected IList _iBTs = new ArrayList();
		protected IList _leaves = new ArrayList();
		protected IList _leavesnEditID = new ArrayList();
		protected IList _membersnSignupID = new ArrayList();
		protected IList _memberCreditPackages = new ArrayList();
		protected IList _memberPackages = new ArrayList();
		protected IList _memos = new ArrayList();
		protected IList _memoBulletins = new ArrayList();
		protected IList _memoGroups = new ArrayList();
		protected IList _memoGroupEntrys = new ArrayList();
		protected IList _memoReads = new ArrayList();
		protected IList _promotionsnApprovedStatusID = new ArrayList();
		protected IList _receiptsnSalespersonID = new ArrayList();
		protected IList _receiptsnCashierID = new ArrayList();
		protected IList _receiptsnTherapistID = new ArrayList();
		protected IList _audits = new ArrayList();
		protected IList _cardRequests = new ArrayList();
		protected IList _rewardsTransactions = new ArrayList();
		//protected IList _rightsLevels = new ArrayList();
		protected IList _casesnSubmittedByID = new ArrayList();
		protected IList _cases = new ArrayList();
		protected IList _rosters = new ArrayList();
		protected IList _caseActionsnActionByID = new ArrayList();
		protected IList _serviceSessions = new ArrayList();
		protected IList _serviceSessionsnServiceEmployeeID;
		protected IList _classAttendances = new ArrayList();
		protected IList _shiftsnOpenShiftStaffID = new ArrayList();
		protected IList _shiftsnCloseShiftStaffID = new ArrayList();
		protected IList _shiftsnVerifyStaffID = new ArrayList();
		protected IList _classInstancesnPermanentInstructorID = new ArrayList();
		protected IList _stockRequests = new ArrayList();
		protected IList _classInstancesnReplacementInstructorID = new ArrayList();
		protected IList _salonUses = new ArrayList();

		protected IList _employeeCommissionSchemes = new ArrayList();

		#endregion
		
		#region Constructors
		
		public Employee() { }
		
		public Employee( string strEmployeeName,string strPassword, string strContactNo, decimal mFitnessPackageTarget, decimal mFitnessProductTarget, decimal mSpaPackageTarget, decimal mSpaProductTarget, decimal mPTPackageTarget, int nServiceCommLevel, Branch branch, Department department, InstructorType instructorType, JobPosition jobPosition, RightsLevel rightsLevel )
		{
			this._strEmployeeName = strEmployeeName;
			this._mFitnessPackageTarget = mFitnessPackageTarget;
			this._mFitnessProductTarget = mFitnessProductTarget;
			this._mSpaPackageTarget = mSpaPackageTarget;
			this._mSpaProductTarget = mSpaProductTarget;
			this._mPTPackageTarget = mPTPackageTarget;
			this._nServiceCommLevel = nServiceCommLevel;
			this._branch = branch;
			this._department = department;
			this._instructorType = instructorType;
			this._jobPosition = jobPosition;
			this._rightsLevel = rightsLevel;
			this._strPassword = strPassword;
			this._strContactNo = strContactNo;
		}
		
		#endregion		

		#region Public Properties
		
		public virtual int Id
		{
			get {return _id;}
			set {_id = value;}
		}

		public virtual string StrEmployeeName
		{
			get { return _strEmployeeName; }
			set { _strEmployeeName = value; }
		}

		public virtual string StrPassword
		{
			get { return _strPassword; }
			set { _strPassword = value; }
		}

		public virtual string StrContactNo
		{
			get { return _strContactNo; }
			set { _strContactNo = value; }
		}
		
		public virtual decimal MFitnessPackageTarget
		{
			get { return _mFitnessPackageTarget; }
			set { _mFitnessPackageTarget = value; }
		}
		
		public virtual decimal MFitnessProductTarget
		{
			get { return _mFitnessProductTarget; }
			set { _mFitnessProductTarget = value; }
		}
		
		public virtual decimal MSpaPackageTarget
		{
			get { return _mSpaPackageTarget; }
			set { _mSpaPackageTarget = value; }
		}
		
		public virtual decimal MSpaProductTarget
		{
			get { return _mSpaProductTarget; }
			set { _mSpaProductTarget = value; }
		}
		
		public virtual decimal MPTPackageTarget
		{
			get { return _mPTPackageTarget; }
			set { _mPTPackageTarget = value; }
		}
		
		public virtual int NServiceCommLevel
		{
			get { return _nServiceCommLevel; }
			set { _nServiceCommLevel = value; }
		}
		
		public virtual Branch Branch
		{
			get { return _branch; }
			set { _branch = value; }
		}

        public virtual string MobileNo
        {
            get { return _MobileNo; }
            set { _MobileNo = value; }
        }

		public virtual Department Department
		{
			get { return _department; }
			set { _department = value; }
		}

		public virtual InstructorType InstructorType
		{
			get { return _instructorType; }
			set { _instructorType = value; }
		}

		public virtual JobPosition JobPosition
		{
			get { return _jobPosition; }
			set { _jobPosition = value; }
		}

		public virtual RightsLevel RightsLevel
		{
			get { return _rightsLevel; }
			set { _rightsLevel = value; }
		}

		public IList ClassInstancesnReplacementIssueID
		{
			get { return _classInstancesnReplacementIssueID; }
			set { _classInstancesnReplacementIssueID = value; }
		}
		
		public IList ClassInstancesnReplacementVerifyID
		{
			get { return _classInstancesnReplacementVerifyID; }
			set { _classInstancesnReplacementVerifyID = value; }
		}
		
		public IList ClassInstancesnActualInstructorID
		{
			get { return _classInstancesnActualInstructorID; }
			set { _classInstancesnActualInstructorID = value; }
		}
		
		public IList TimeCards
		{
			get { return _timeCards; }
			set { _timeCards = value; }
		}
		
		public IList ClassInstancesnStandinInstructorID
		{
			get { return _classInstancesnStandinInstructorID; }
			set { _classInstancesnStandinInstructorID = value; }
		}
		
		public IList ClassInstancesnVerifyID
		{
			get { return _classInstancesnVerifyID; }
			set { _classInstancesnVerifyID = value; }
		}
		
		public IList ClassSchedulesnInstructorID
		{
			get { return _classSchedulesnInstructorID; }
			set { _classSchedulesnInstructorID = value; }
		}
		
		public IList CommissionSchemes2
		{
			get { return _commissionSchemes2; }
			set { _commissionSchemes2 = value; }
		}
		
		public IList Branches
		{
			get { return _branches; }
			set { _branches = value; }
		}
		
		public IList CommissionSchemes
		{
			get { return _commissionSchemes; }
			set { _commissionSchemes = value; }
		}
		
		public IList GIROs
		{
			get { return _gIROs; }
			set { _gIROs = value; }
		}
		
		public IList GIROBatches
		{
			get { return _gIROBatches; }
			set { _gIROBatches = value; }
		}
		
		public IList IBTs
		{
			get { return _iBTs; }
			set { _iBTs = value; }
		}
		
		public IList Leaves
		{
			get { return _leaves; }
			set { _leaves = value; }
		}
		
		public IList LeavesnEditID
		{
			get { return _leavesnEditID; }
			set { _leavesnEditID = value; }
		}
		
		public IList MembersnSignupID
		{
			get { return _membersnSignupID; }
			set { _membersnSignupID = value; }
		}
		
		public IList MemberCreditPackages
		{
			get { return _memberCreditPackages; }
			set { _memberCreditPackages = value; }
		}
		
		public IList MemberPackages
		{
			get { return _memberPackages; }
			set { _memberPackages = value; }
		}
		
		public IList Memos
		{
			get { return _memos; }
			set { _memos = value; }
		}
		
		public IList MemoBulletins
		{
			get { return _memoBulletins; }
			set { _memoBulletins = value; }
		}
		
		public IList MemoGroups
		{
			get { return _memoGroups; }
			set { _memoGroups = value; }
		}
		
		public IList MemoGroupEntrys
		{
			get { return _memoGroupEntrys; }
			set { _memoGroupEntrys = value; }
		}
		
		public IList MemoReads
		{
			get { return _memoReads; }
			set { _memoReads = value; }
		}
		
		public IList PromotionsnApprovedStatusID
		{
			get { return _promotionsnApprovedStatusID; }
			set { _promotionsnApprovedStatusID = value; }
		}
		
		public IList ReceiptsnSalespersonID
		{
			get { return _receiptsnSalespersonID; }
			set { _receiptsnSalespersonID = value; }
		}
		
		public IList ReceiptsnCashierID
		{
			get { return _receiptsnCashierID; }
			set { _receiptsnCashierID = value; }
		}
		
		public IList ReceiptsnTherapistID
		{
			get { return _receiptsnTherapistID; }
			set { _receiptsnTherapistID = value; }
		}
		
		public IList Audits
		{
			get { return _audits; }
			set { _audits = value; }
		}
		
		public IList CardRequests
		{
			get { return _cardRequests; }
			set { _cardRequests = value; }
		}
		
		public IList RewardsTransactions
		{
			get { return _rewardsTransactions; }
			set { _rewardsTransactions = value; }
		}
		
//		public IList RightsLevels
//		{
//			get { return _rightsLevels; }
//			set { _rightsLevels = value; }
//		}
		
		public IList CasesnSubmittedByID
		{
			get { return _casesnSubmittedByID; }
			set { _casesnSubmittedByID = value; }
		}
		
		public IList Cases
		{
			get { return _cases; }
			set { _cases = value; }
		}
		
		public IList Rosters
		{
			get { return _rosters; }
			set { _rosters = value; }
		}
		
		public IList CaseActionsnActionByID
		{
			get { return _caseActionsnActionByID; }
			set { _caseActionsnActionByID = value; }
		}
		
		public IList ServiceSessions
		{
			get { return _serviceSessions; }
			set { _serviceSessions = value; }
		}
		
		public IList ServiceSessionsnServiceEmployeeID
		{
			get { return _serviceSessionsnServiceEmployeeID; }
			set { _serviceSessionsnServiceEmployeeID = value; }
		}
		
		public IList ClassAttendances
		{
			get { return _classAttendances; }
			set { _classAttendances = value; }
		}
		
		public IList ShiftsnOpenShiftStaffID
		{
			get { return _shiftsnOpenShiftStaffID; }
			set { _shiftsnOpenShiftStaffID = value; }
		}
		
		public IList ShiftsnCloseShiftStaffID
		{
			get { return _shiftsnCloseShiftStaffID; }
			set { _shiftsnCloseShiftStaffID = value; }
		}
		
		public IList ShiftsnVerifyStaffID
		{
			get { return _shiftsnVerifyStaffID; }
			set { _shiftsnVerifyStaffID = value; }
		}
		
		public IList ClassInstancesnPermanentInstructorID
		{
			get { return _classInstancesnPermanentInstructorID; }
			set { _classInstancesnPermanentInstructorID = value; }
		}
		
		public IList StockRequests
		{
			get { return _stockRequests; }
			set { _stockRequests = value; }
		}
		
		public IList ClassInstancesnReplacementInstructorID
		{
			get { return _classInstancesnReplacementInstructorID; }
			set { _classInstancesnReplacementInstructorID = value; }
		}

		public IList EmployeeBranchRights
		{
			get { return _employeeBranchRights; }
			set { _employeeBranchRights = value; }
		}

		public IList EmployeeCommissionSchemes
		{
			get { return _employeeCommissionSchemes; }
			set { _employeeCommissionSchemes = value; }
		}

		public IList SalonUses
		{
			get { return _salonUses; }
			set { _salonUses = value; }
		}


		public void AddAudit(Audit audit)
		{
			audit.Employee = this;
			_audits.Add(audit);
		}

		public void AddEmployeeCommissionScheme(EmployeeCommissionScheme employeeCommissionScheme)
		{
			employeeCommissionScheme.Employee = this;
			_employeeCommissionSchemes.Add(employeeCommissionScheme);
			
		}

		public void AddMemoGroupEntry(MemoGroupEntry memoGroupEntry)
		{
			memoGroupEntry.Employee = this;
			_memoGroupEntrys.Add(memoGroupEntry);
			
		}

		public void AddMemoRead(MemoRead memoRead)
		{
			memoRead.Employee = this;
			_memoReads.Add(memoRead);
			
		}

		public void AddSalonUse(SalonUse salonUse)
		{
			salonUse.Employee = this;
			_salonUses.Add(salonUse);
		}
		
		
		#endregion

		#region Business Logic
		private bool ValidOperation(string strDescription)
		{
			foreach(Acms.Core.Domain.RightsLevelEntry rle in this.RightsLevel.RightsLevelEntrys)
			{
				if(rle.Right.StrDescription.ToLower()==strDescription.ToLower())
				{
					return true;
				}
			}
			return false;
		}

		public bool CanDelete(string strDescription)
		{
			return ValidOperation(strDescription);
		}

		public bool HasRight(string strRightDescription)
		{
			return ValidOperation(strRightDescription);
		}

		public bool HasBranchRight(string strRightDescription,string strBranchCode)
		{
			return CanAccess(strRightDescription,strBranchCode);
		}

		public bool CanAccess(string strDescription,string strBranchCode)
		{
			bool isInBranch = false;
			if(this.EmployeeBranchRights.Count>0)
			{
				foreach(Acms.Core.Domain.EmployeeBranchRights ebr in EmployeeBranchRights)
				{
					if(strBranchCode==ebr.Branch.Id)
					{
						isInBranch=true;
					}
				}

				if(isInBranch)
				{
					return ValidOperation(strDescription);
				}
			}
			return false;
		}

		#endregion
	}
	
	#endregion
}
