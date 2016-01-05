using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region ProductType
	
	/// <summary>
	/// ProductType object for NHibernate mapped table 'tblProductType'.
	/// </summary>
	public class ProductType
	{
		#region Member Variables
		
		protected int _id;
		protected string _strDescription;
		protected IList _productsnProductTypeId;

		#endregion
		
		#region Constructors
		
		public ProductType() { }
		
		public ProductType( string strDescription )
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
		
		public IList ProductsnProductTypeId
		{
			get { return _productsnProductTypeId; }
			set { _productsnProductTypeId = value; }
		}
		
		#endregion
	}
	
	#endregion
}
