using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region RightsLevel
	
	/// <summary>
	/// RightsLevel object for NHibernate mapped table 'tblRightsLevel'.
	/// </summary>
	public class RightsLevel
	{
		#region Member Variables
		
		protected int _id;
		protected string _strDescription;
		protected DateTime _dtLastEditDate;
		protected Employee _employee;
		protected IList _employees = new ArrayList();
		protected IList _rightsLevelEntrys = new ArrayList();

		#endregion
		
		#region Constructors
		
		public RightsLevel() { }
		
		public RightsLevel( string strDescription, DateTime dtLastEditDate, Employee employee )
		{
			this._strDescription = strDescription;
			this._dtLastEditDate = dtLastEditDate;
			this._employee = employee;
		}
		
		#endregion		

		#region Public Properties
		
		public virtual int Id
		{
			get {return _id;}
			set {_id = value;}
		}

		public virtual string StrDescription
		{
			get { return _strDescription; }
			set { _strDescription = value; }
		}
		
		public virtual DateTime DtLastEditDate
		{
			get { return _dtLastEditDate; }
			set { _dtLastEditDate = value; }
		}
		
		public virtual Employee Employee
		{
			get { return _employee; }
			set { _employee = value; }
		}

		public IList Employees
		{
			get { return _employees; }
			set { _employees = value; }
		}
		
		public IList RightsLevelEntrys
		{
			get { return _rightsLevelEntrys; }
			set { _rightsLevelEntrys = value; }
		}
		
		public void AddRightsLevelEntry(RightsLevelEntry rightsLevelEntry)
		{
			rightsLevelEntry.RightsLevel = this;
			_rightsLevelEntrys.Add(rightsLevelEntry);
			
		}
		
		#endregion
	}
	
	#endregion
}
