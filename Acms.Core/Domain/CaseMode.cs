using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region CaseMode
	
	/// <summary>
	/// CaseMode object for NHibernate mapped table 'tblCaseMode'.
	/// </summary>
	public class CaseMode
	{
		#region Member Variables
		
		protected int _id;
		protected string _strDescription;
		protected IList _caseActions = new ArrayList();

		#endregion
		
		#region Constructors
		
		public CaseMode() { }
		
		public CaseMode( string strDescription )
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
		
		public IList CaseActions
		{
			get { return _caseActions; }
			set { _caseActions = value; }
		}
		
		public void AddCaseAction(CaseAction caseAction)
		{
			caseAction.CaseMode = this;
			_caseActions.Add(caseAction);
		}
		#endregion
	}
	
	#endregion
}
