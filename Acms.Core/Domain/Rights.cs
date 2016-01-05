using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region Right
	
	/// <summary>
	/// Right object for NHibernate mapped table 'tblRights'.
	/// </summary>
	public class Right
	{
		#region Member Variables
		
		protected int _id;
		protected string _strDescription;
		protected int _nRightsTypeID;
		protected IList _rightsLevelEntrys = new ArrayList();

		#endregion
		
		#region Constructors
		
		public Right() { }
		
		public Right( string strDescription, int nRightsTypeID )
		{
			this._strDescription = strDescription;
			this._nRightsTypeID = nRightsTypeID;
		}
		
		#endregion		

		#region Public Properties
		
		public int Id
		{
			get {return _id;}
			set {_id = value;}
		}

		public string StrDescription
		{
			get { return _strDescription; }
			set { _strDescription = value; }
		}
		
		public int NRightsTypeID
		{
			get { return _nRightsTypeID; }
			set { _nRightsTypeID = value; }
		}
		
		public IList RightsLevelEntrys
		{
			get { return _rightsLevelEntrys; }
			set { _rightsLevelEntrys = value; }
		}
		
		public void AddRightsLevelEntry(RightsLevelEntry rightsLevelEntry)
		{
			rightsLevelEntry.Right = this;
			_rightsLevelEntrys.Add(rightsLevelEntry);
			
		}


		#endregion
	}
	
	#endregion
}
