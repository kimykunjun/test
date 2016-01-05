using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region CaseCategory
	
	/// <summary>
	/// CaseCategory object for NHibernate mapped table 'tblCaseCategory'.
	/// </summary>
	public class CaseCategory
	{
		#region Member Variables
		
		protected int _id;
		protected string _strDescription;
		protected IList _cases = new ArrayList();

		#endregion
		
		#region Constructors
		
		public CaseCategory() { }
		
		public CaseCategory( string strDescription )
		{
			this._strDescription = strDescription;
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
		
		public IList Cases
		{
			get { return _cases; }
			set { _cases = value; }
		}

		public void AddCase(Case cases)
		{
			cases.CaseCategory = this;
			_cases.Add(cases);
		}
		
		#endregion
	}
	
	#endregion
}
