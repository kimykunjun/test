using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region CaseType
	
	/// <summary>
	/// CaseType object for NHibernate mapped table 'tblCaseType'.
	/// </summary>
	public class CaseType
	{
		#region Member Variables
		
		protected int _id;
		protected string _strDescription;
		protected IList _cases = new ArrayList();

		#endregion
		
		#region Constructors
		
		public CaseType() { }
		
		public CaseType( string strDescription )
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
		
		public void AddCase(Case _case)
		{
			_case.CaseType = this;
			_cases.Add(_case);
		}
		#endregion
	}
	
	#endregion
}
