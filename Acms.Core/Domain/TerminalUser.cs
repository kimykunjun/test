using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region TerminalUser
	
	/// <summary>
	/// TerminalUser object for NHibernate mapped table 'tblTerminalUser'.
	/// </summary>
	public class TerminalUser
	{
		#region Member Variables
		
		protected string _id;
		protected int _nServiceID;
		protected int _nTerminalID;
		protected Branch _branch;

		#endregion
		
		#region Constructors
		
		public TerminalUser() { }
		
		public TerminalUser( int nServiceID, int nTerminalID, Branch branch )
		{
			this._nServiceID = nServiceID;
			this._nTerminalID = nTerminalID;
			this._branch = branch;
		}
		
		#endregion		

		#region Public Properties
		
		public string Id
		{
			get {return _id;}
			set {_id = value;}
		}

		public int NServiceID
		{
			get { return _nServiceID; }
			set { _nServiceID = value; }
		}
		
		public int NTerminalID
		{
			get { return _nTerminalID; }
			set { _nTerminalID = value; }
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
