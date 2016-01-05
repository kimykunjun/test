using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region CardRequest
	
	/// <summary>
	/// CardRequest object for NHibernate mapped table 'tblCardRequest'.
	/// </summary>
	public class CardRequest
	{
		#region Member Variables
		
		protected int _id;
		protected DateTime _dtLastEditDate;
		protected int _nStatusID;
		protected Branch _branch;
		protected Employee _employee;
		protected Member _member;

		#endregion
		
		#region Constructors
		
		public CardRequest() { }
		
		public CardRequest( DateTime dtLastEditDate, int nStatusID, Branch branch, Employee employee, Member member )
		{
			this._dtLastEditDate = dtLastEditDate;
			this._nStatusID = nStatusID;
			this._branch = branch;
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

		public DateTime DtLastEditDate
		{
			get { return _dtLastEditDate; }
			set { _dtLastEditDate = value; }
		}
		
		public int NStatusID
		{
			get { return _nStatusID; }
			set { _nStatusID = value; }
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

		#endregion
	}
	
	#endregion
}
