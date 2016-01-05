using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region GIRO
	
	/// <summary>
	/// GIRO object for NHibernate mapped table 'tblGIRO'.
	/// </summary>
	public class GIRO
	{
		#region Member Variables
		
		protected int _id;
		protected string _strBankBranchCode;
		protected string _strAccountNo;
		protected string _strRemarks;
		protected int _nStatusID;
		protected Bank _bank;
		protected Branch _branch;
		protected Employee _employee;
		protected Member _member;
		protected Package _package;
		protected IList _gIROBatchEntrieses = new ArrayList();
		protected IList _memberPackages = new ArrayList();

		#endregion
		
		#region Constructors
		
		public GIRO() { }
		
		public GIRO( string strBankBranchCode, string strAccountNo, string strRemarks, int nStatusID, Bank bank, Branch branch, Employee employee, Member member, Package package )
		{
			this._strBankBranchCode = strBankBranchCode;
			this._strAccountNo = strAccountNo;
			this._strRemarks = strRemarks;
			this._nStatusID = nStatusID;
			this._bank = bank;
			this._branch = branch;
			this._employee = employee;
			this._member = member;
			this._package = package;
		}
		
		#endregion		

		#region Public Properties
		
		public int Id
		{
			get {return _id;}
			set {_id = value;}
		}

		public string StrBankBranchCode
		{
			get { return _strBankBranchCode; }
			set { _strBankBranchCode = value; }
		}
		
		public string StrAccountNo
		{
			get { return _strAccountNo; }
			set { _strAccountNo = value; }
		}
		
		public string StrRemarks
		{
			get { return _strRemarks; }
			set { _strRemarks = value; }
		}
		
		public int NStatusID
		{
			get { return _nStatusID; }
			set { _nStatusID = value; }
		}
		
		public Bank Bank
		{
			get { return _bank; }
			set { _bank = value; }
		}

		public Branch Branch
		{
			get { return _branch; }
			set { _branch = value; }
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

		public Package Package
		{
			get { return _package; }
			set { _package = value; }
		}

		public IList GIROBatchEntrieses
		{
			get { return _gIROBatchEntrieses; }
			set { _gIROBatchEntrieses = value; }
		}
		
		public IList MemberPackages
		{
			get { return _memberPackages; }
			set { _memberPackages = value; }
		}


		public void AddGIROBatchEntry(GIROBatchEntry gIROBatchEntry)
		{
			gIROBatchEntry.GIRO = this;
			_gIROBatchEntrieses.Add(gIROBatchEntry);
		}
		
		public void AddMemberPackage(MemberPackage memberPackage)
		{
			memberPackage.GIRO = this;
			_memberPackages.Add(memberPackage);
		}
		#endregion
	}
	
	#endregion
}
