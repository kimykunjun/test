using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region ClassType
	
	/// <summary>
	/// ClassType object for NHibernate mapped table 'tblClassType'.
	/// </summary>
	public class ClassType
	{
		#region Member Variables
		
		protected int _id;
		protected string _strDescription;
		protected IList _classes = new ArrayList();

		#endregion
		
		#region Constructors
		
		public ClassType() { }
		
		public ClassType( string strDescription )
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
		
		public IList Classes
		{
			get { return _classes; }
			set { _classes = value; }
		}

		public void AddClass(Class classs)
		{
			classs.ClassType = this;
			_classes.Add(classs);
		}
		
		#endregion
	}
	
	#endregion
}
