using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region Branch
	
	/// <summary>
	/// Branch object for NHibernate mapped table 'tblBranch'.
	/// </summary>
	public class Branch
	{
		#region Member Variables
		
		protected string _id;
		protected string _strBranchName;
		protected string _strHeader1;
		protected string _strHeader2;
		protected string _strHeader3;
		protected string _strHeader4;
		protected decimal _mLockerRentalRate1;
		protected decimal _mLockerRentalRate2;
		protected decimal _mLockerDepositRate;
		protected int _nMembershipNo;
		protected IList _timeCards = new ArrayList();
		protected IList _classSchedules = new ArrayList();
		protected IList _employeeBranchRights = new ArrayList();
		protected IList _employees2 = new ArrayList();
		protected IList _gIROs = new ArrayList();
		protected IList _iBTsFrom = new ArrayList();
		protected IList _iBTsTo = new ArrayList();
		protected IList _lockers = new ArrayList();
		protected IList _membersstrCardBranchCode = new ArrayList();
		protected IList _memoBranchs = new ArrayList();
		protected IList _packageBranchs = new ArrayList();
		protected IList _promotionBranchs = new ArrayList();
		protected IList _receipts = new ArrayList();
		protected IList _branchTargets = new ArrayList();
		protected IList _cardRequests = new ArrayList();
		protected IList _rewardsBranchs = new ArrayList();
		protected IList _cases = new ArrayList();
		protected IList _rosters = new ArrayList();
		protected IList _serviceSessions = new ArrayList();
		protected IList _classAttendances = new ArrayList();
		protected IList _shifts = new ArrayList();
		protected IList _classInstances = new ArrayList();
		protected IList _stockRequestsFrom = new ArrayList();
		protected IList _stockRequestsTo = new ArrayList();
		protected IList _branchReceiptNo = new ArrayList();
		protected IList _productBranches = new ArrayList();
		protected IList _productInventories = new ArrayList();
		protected IList _members = new ArrayList();
		protected IList _salonUses = new ArrayList();
		protected IList _terminalUsers = new ArrayList();
		#endregion
		
		#region Constructors
		
		public Branch() { }
		
		public Branch( string strBranchName, string strHeader1, string strHeader2, string strHeader3, string strHeader4, decimal mLockerRentalRate1, decimal mLockerRentalRate2, decimal mLockerDepositRate, int nMembershipNo )
		{
			this._strBranchName = strBranchName;
			this._strHeader1 = strHeader1;
			this._strHeader2 = strHeader2;
			this._strHeader3 = strHeader3;
			this._strHeader4 = strHeader4;
			this._mLockerRentalRate1 = mLockerRentalRate1;
			this._mLockerRentalRate2 = mLockerRentalRate2;
			this._mLockerDepositRate = mLockerDepositRate;
			this._nMembershipNo = nMembershipNo;
		}
		
		#endregion		

		#region Public Properties
		
		public virtual string Id
		{
			get {return _id;}
			set {_id = value;}
		}

		public virtual string StrBranchName
		{
			get { return _strBranchName; }
			set { _strBranchName = value; }
		}
		
		public virtual string StrHeader1
		{
			get { return _strHeader1; }
			set { _strHeader1 = value; }
		}
		
		public virtual string StrHeader2
		{
			get { return _strHeader2; }
			set { _strHeader2 = value; }
		}
		
		public virtual string StrHeader3
		{
			get { return _strHeader3; }
			set { _strHeader3 = value; }
		}
		
		public virtual string StrHeader4
		{
			get { return _strHeader4; }
			set { _strHeader4 = value; }
		}
		
		public virtual decimal MLockerRentalRate1
		{
			get { return _mLockerRentalRate1; }
			set { _mLockerRentalRate1 = value; }
		}
		
		public virtual decimal MLockerRentalRate2
		{
			get { return _mLockerRentalRate2; }
			set { _mLockerRentalRate2 = value; }
		}
		
		public virtual decimal MLockerDepositRate
		{
			get { return _mLockerDepositRate; }
			set { _mLockerDepositRate = value; }
		}
		
		public virtual int NMembershipNo
		{
			get { return _nMembershipNo; }
			set { _nMembershipNo = value; }
		}
		
		public IList TimeCards
		{
			get { return _timeCards; }
			set { _timeCards = value; }
		}
		
		public IList ClassSchedules
		{
			get { return _classSchedules; }
			set { _classSchedules = value; }
		}
		
		public IList Employees2
		{
			get { return _employees2; }
			set { _employees2 = value; }
		}
		
		public IList EmployeeBranchRights
		{
			get { return _employeeBranchRights; }
			set { _employeeBranchRights = value; }
		}
		
		public IList GIROs
		{
			get { return _gIROs; }
			set { _gIROs = value; }
		}
		
		public IList IBTsFrom
		{
			get { return _iBTsFrom; }
			set { _iBTsFrom = value; }
		}
		
		public IList IBTsTo
		{
			get { return _iBTsTo; }
			set { _iBTsTo = value; }
		}
		
		public IList Lockers
		{
			get { return _lockers; }
			set { _lockers = value; }
		}
		
		public IList MembersstrCardBranchCode
		{
			get { return _membersstrCardBranchCode; }
			set { _membersstrCardBranchCode = value; }
		}
		
		public IList MemoBranchs
		{
			get { return _memoBranchs; }
			set { _memoBranchs = value; }
		}
		
		public IList PackageBranchs
		{
			get { return _packageBranchs; }
			set { _packageBranchs = value; }
		}
		
		public IList PromotionBranchs
		{
			get { return _promotionBranchs; }
			set { _promotionBranchs = value; }
		}
		
		public IList Receipts
		{
			get { return _receipts; }
			set { _receipts = value; }
		}
		
		public IList BranchTargets
		{
			get { return _branchTargets; }
			set { _branchTargets = value; }
		}
		
		public IList CardRequests
		{
			get { return _cardRequests; }
			set { _cardRequests = value; }
		}
		
		public IList RewardsBranchs
		{
			get { return _rewardsBranchs; }
			set { _rewardsBranchs = value; }
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
		
		public IList ServiceSessions
		{
			get { return _serviceSessions; }
			set { _serviceSessions = value; }
		}
		
		public IList ClassAttendances
		{
			get { return _classAttendances; }
			set { _classAttendances = value; }
		}
		
		public IList Shifts
		{
			get { return _shifts; }
			set { _shifts = value; }
		}
		
		public IList ClassInstances
		{
			get { return _classInstances; }
			set { _classInstances = value; }
		}
		
		public IList StockRequestsFrom
		{
			get { return _stockRequestsFrom; }
			set { _stockRequestsFrom = value; }
		}
		
		public IList StockRequestsTo
		{
			get { return _stockRequestsTo; }
			set { _stockRequestsTo = value; }
		}

		public IList BranchReceiptNos
		{
			get { return _branchReceiptNo; }
			set { _branchReceiptNo = value; }
		}

		public IList ProductInventories
		{
			get { return _productInventories; }
			set { _productInventories = value; }
		}
		
		public IList ProductBranches
		{
			get { return _productBranches; }
			set { _productBranches = value; }
		}


		public IList Members
		{
			get { return _members; }
			set { _members = value; }
		}

		public IList SalonUses
		{
			get { return _salonUses; }
			set { _salonUses = value; }
		}

		public IList TerminalUsers
		{
			get{ return _terminalUsers;}
			set{ _terminalUsers = value;}
		}

		public void AddTimeCard(TimeCard timeCard)
		{
			timeCard.Branch = this;
			_timeCards.Add(timeCard);
		}

//		protected IList _employees2 = new ArrayList();
		public void AddEmployee2(Employee employee)
		{
			employee.Branch = this;
			_employees2.Add(employee);
		}

//		protected IList _gIROs = new ArrayList();
		public void AddGiro(GIRO giro)
		{
			giro.Branch = this;
			_gIROs.Add(giro);
		}

//		protected IList _iBTsFrom = new ArrayList();
		public void AddIBTSFrom(IBT ibt)
		{
			ibt.BranchFrom = this;
			_iBTsFrom.Add(ibt);
		}

//		protected IList _iBTsTo = new ArrayList();
		public void AddIBTSTo(IBT ibt)
		{
			ibt.BranchTo = this;
			_iBTsFrom.Add(ibt);
		}

//		protected IList _lockers = new ArrayList();
		public void AddLocker(Locker locker)
		{
			locker.Branch = this;
			_lockers.Add(locker);
		}

//		protected IList _membersstrCardBranchCode = new ArrayList();
		public void AddMemberStrCardBranchCode(Member member)
		{
			member.BranchstrCardBranchCode = this;
			_membersstrCardBranchCode.Add(member);
		}

//		protected IList _receipts = new ArrayList();
		public void AddReceipt(Receipt receipt)
		{
			receipt.Branch = this;
			_receipts.Add(receipt);
		}

//		protected IList _cases = new ArrayList();
		public void AddCase(Case cases)
		{
			cases.Branch = this;
			_cases.Add(cases);
		}

//		protected IList _rosters = new ArrayList();
		public void AddRoster(Roster roster)
		{
			roster.Branch = this;
			_rosters.Add(roster);
		}

//		protected IList _serviceSessions = new ArrayList();
		public void AddServiceSession(ServiceSession serviceSession)
		{
			serviceSession.Branch =this;
			_serviceSessions.Add(serviceSession);
		}

//		protected IList _classAttendances = new ArrayList();
		public void AddClassAttendance(ClassAttendance classAttendance)
		{
			classAttendance.Branch = this;
			_classAttendances.Add(classAttendance);
		}

//		protected IList _classInstances = new ArrayList();
		public void AddClassInstance(ClassInstance classInstance)
		{
			classInstance.Branch = this;
			_classInstances.Add(classInstance);
		}

//		protected IList _stockRequestsFrom = new ArrayList();
		public void AddStockRequestFrom(StockRequest stockRequest)
		{
			stockRequest.BranchFrom = this;
			_stockRequestsFrom.Add(stockRequest);
		}

//		protected IList _stockRequestsTo = new ArrayList();
		public void AddStockRequestTo(StockRequest stockRequest)
		{
			stockRequest.BranchTo = this;
			_stockRequestsTo.Add(stockRequest);
		}



		public void AddCardRequest(CardRequest cardRequest)
		{
			cardRequest.Branch = this;
			_cardRequests.Add(cardRequest);
		}

		public void AddBranchTarget(BranchTarget branchTarget)
		{
			branchTarget.Branch = this;
			_branchTargets.Add(branchTarget);
		}
		
		public void AddClassSchedule(ClassSchedule classSchedule)
		{
			classSchedule.Branch = this;
			_classSchedules.Add(classSchedule);
		}

		public void AddEmployeeBranchRight(EmployeeBranchRights employeeBranchRight)
		{
			employeeBranchRight.Branch = this;
			_classSchedules.Add(employeeBranchRight);
		}

		public void AddMemoBranch(MemoBranch memoBranch)
		{
			memoBranch.Branch = this;
			_memoBranchs.Add(memoBranch);
			
		}

		public void AddPackageBranch(PackageBranch packageBranch)
		{
			packageBranch.Branch = this;
			_packageBranchs.Add(packageBranch);
			
		}

		public void AddPromotionBranch(PromotionBranch promotionBranch)
		{
			promotionBranch.Branch = this;
			_promotionBranchs.Add(promotionBranch);
		}

		public void AddRewardsBranch(RewardsBranch rewardsBranch)
		{
			rewardsBranch.Branch = this;
			_rewardsBranchs.Add(rewardsBranch);
		}

		public void AddShift(Shift shift)
		{
			shift.Branch = this;
			_shifts.Add(shift);
		}

		public void AddBranchReceiptNo(BranchReceiptNo branchReceiptNo)
		{
			branchReceiptNo.Branch = this;
			_branchReceiptNo.Add(branchReceiptNo);
		}

		public void AddProductBranch(ProductBranch productBranch)
		{
			productBranch.Branch = this;
			_productBranches.Add(productBranch);
		}
		
		public void AddProductInventory(ProductInventory productInventory)
		{
			productInventory.Branch = this;
			_productInventories.Add(productInventory);
		}

		public void AddMember(Member member)
		{
			member.BranchstrCardBranchCode = this;
			_members.Add(member);
		}

		
		public void AddSalonUse(SalonUse salonUse)
		{
			salonUse.Branch = this;
			_salonUses.Add(salonUse);
		}

		public void AddTerminalUser(TerminalUser terminalUser)
		{
			terminalUser.Branch = this;
			_terminalUsers.Add(terminalUser);
		}

		#endregion
	}
	
	#endregion
}
