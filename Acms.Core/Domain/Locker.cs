using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region Locker
	
	/// <summary>
	/// Locker object for NHibernate mapped table 'tblLocker'.
	/// </summary>
	public class Locker
	{
		#region Member Variables
		
		protected int _nLockerNo;
		protected int _nStatusID;
		protected string _strRemarks;
		protected Branch _branch;
		protected Member _member;

		#endregion
		
		#region Constructors
		
		public Locker() { }
		
		public Locker( int nLockerNo, int nStatusID, string strRemarks, Branch branch, Member member )
		{
			this._nLockerNo = nLockerNo;
			this._nStatusID = nStatusID;
			this._strRemarks = strRemarks;
			this._branch = branch;
			this._member = member;
		}
		
		#endregion		

		#region Public Properties
		

		public int NLockerNo
		{
			get { return _nLockerNo; }
			set { _nLockerNo = value; }
		}

		public int NStatusID
		{
			get { return _nStatusID; }
			set { _nStatusID = value; }
		}
		
		public string StrRemarks
		{
			get { return _strRemarks; }
			set { _strRemarks = value; }
		}
		
		public Branch Branch
		{
			get { return _branch; }
			set { _branch = value; }
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
