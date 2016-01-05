using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region ProductBranch
	
	/// <summary>
	/// ProductBranch object for NHibernate mapped table 'tblProductBranch'.
	/// </summary>
	public class ProductBranch
	{
		#region Member Variables
		
		protected Id _id;

		protected Product _product;
		protected Branch _branch;

		#endregion
		
		#region Constructors
		
		public ProductBranch() { }
		
		
		
		#endregion		

		#region Public Properties
		
		public Id Id
		{
			get {return _id;}
			set {_id = value;}
		}

		public Product Product
		{
			set{_product = value;
			_id.StringId1 = _product.Id;
			}
			get{return _product;}
		}

		public Branch Branch
		{
			set{_branch = value;
			_id.StringId2 = _branch.Id;}
			get{return _branch;}
		}

		#endregion
	}
	
	#endregion
}
