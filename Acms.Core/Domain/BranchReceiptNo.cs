using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region BranchReceiptNo
	
	/// <summary>
	/// BranchReceiptNo object for NHibernate mapped table 'tblBranchReceiptNo'.
	/// </summary>
	public class BranchReceiptNo
	{
		#region Member Variables
		
		protected string _id;
		protected int _nReceiptNo;
		protected int _nTerminalID;
		protected Branch _branch;
		#endregion
		
		#region Constructors
		
		public BranchReceiptNo() { }
		
		public BranchReceiptNo( int nReceiptNo )
		{
			this._nReceiptNo = nReceiptNo;
		}
		
		#endregion		

		#region Public Properties
		
		public string Id
		{
			get {return _id;}
			set {_id = value;}
		}

		public int NTerminalID
		{
			get { return _nTerminalID; }
			set { _nTerminalID = value; }
		}

		public int NReceiptNo
		{
			get { return _nReceiptNo; }
			set { _nReceiptNo = value; }
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
