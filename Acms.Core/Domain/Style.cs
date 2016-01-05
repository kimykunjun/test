using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region Style
	
	/// <summary>
	/// Style object for NHibernate mapped table 'tblStyle'.
	/// </summary>
	public class Style
	{
		#region Member Variables
		
		protected string _id;
		protected string _strDescription;
		protected IList _products;

		#endregion
		
		#region Constructors
		
		public Style() { }
		
		public Style( string strDescription )
		{
			this._strDescription = strDescription;
		}
		
		#endregion		

		#region Public Properties
		
		public string Id
		{
			get {return _id;}
			set {_id = value;}
		}

		public string StrDescription
		{
			get { return _strDescription; }
			set { _strDescription = value; }
		}
		
		public IList Products
		{
			get { return _products; }
			set { _products = value; }
		}
		
		#endregion
	}
	
	#endregion
}
