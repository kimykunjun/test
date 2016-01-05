using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region POSCategory
	
	/// <summary>
	/// POSCategory object for NHibernate mapped table 'tblPOSCategory'.
	/// </summary>
	public class POSCategory
	{
		#region Member Variables
		
		protected int _id;
		protected string _strDescription;
		protected IList _categories = new ArrayList();

		#endregion
		
		#region Constructors
		
		public POSCategory() { }
		
		public POSCategory( string strDescription )
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
		
		public IList Categories
		{
			get { return _categories; }
			set { _categories = value; }
		}

		public void AddCategory(Category category)
		{
			category.POSCategory = this;
			_categories.Add(category);
		}
		
		#endregion
	}
	
	#endregion
}
