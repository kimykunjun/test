using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region Color
	
	/// <summary>
	/// Color object for NHibernate mapped table 'tblColor'.
	/// </summary>
	public class Color
	{
		#region Member Variables
		
		protected string _id;
		protected string _strDescription;
		protected IList _products;

		#endregion
		
		#region Constructors
		
		public Color() { }
		
		public Color( string strDescription )
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
