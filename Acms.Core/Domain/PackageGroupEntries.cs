using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region PackageGroupEntry
	
	/// <summary>
	/// PackageGroupEntry object for NHibernate mapped table 'tblPackageGroupEntries'.
	/// </summary>
	public class PackageGroupEntry
	{
		#region Member Variables
		
		protected string _id;
		protected int _nQuantity;
		protected Package _package;
		protected PackageGroup _packageGroup;

		#endregion
		
		#region Constructors
		
		public PackageGroupEntry() { }
		
		public PackageGroupEntry( int nQuantity, Package package, PackageGroup packageGroup )
		{
			this._nQuantity = nQuantity;
			this._package = package;
			this._packageGroup = packageGroup;
		}
		
		#endregion		

		#region Public Properties
		
		public string Id
		{
			get {return _id;}
			set {_id = value;}
		}

		public int NQuantity
		{
			get { return _nQuantity; }
			set { _nQuantity = value; }
		}
		
		public Package Package
		{
			get { return _package; }
			set { _package = value; }
		}

		public PackageGroup PackageGroup
		{
			get { return _packageGroup; }
			set { _packageGroup = value; }
		}

		#endregion
	}
	
	#endregion
}
