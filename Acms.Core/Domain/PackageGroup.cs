using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region PackageGroup
	
	/// <summary>
	/// PackageGroup object for NHibernate mapped table 'tblPackageGroup'.
	/// </summary>
	public class PackageGroup
	{
		#region Member Variables
		
		protected string _id;
		protected string _strDescription;
		protected decimal _mListPrice;
		protected DateTime _dtValidStart;
		protected DateTime _dtValidEnd;
		protected SalesCategory _salesCategorynCategoryID;
		protected IList _packageGroupEntrys;

		#endregion
		
		#region Constructors
		
		public PackageGroup() { }
		
		public PackageGroup( string strDescription, decimal mListPrice, DateTime dtValidStart, DateTime dtValidEnd, SalesCategory salesCategorynCategoryID )
		{
			this._strDescription = strDescription;
			this._mListPrice = mListPrice;
			this._dtValidStart = dtValidStart;
			this._dtValidEnd = dtValidEnd;
			this._salesCategorynCategoryID = salesCategorynCategoryID;
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
		
		public decimal MListPrice
		{
			get { return _mListPrice; }
			set { _mListPrice = value; }
		}
		
		public DateTime DtValidStart
		{
			get { return _dtValidStart; }
			set { _dtValidStart = value; }
		}
		
		public DateTime DtValidEnd
		{
			get { return _dtValidEnd; }
			set { _dtValidEnd = value; }
		}
		
		public SalesCategory SalesCategorynCategoryID
		{
			//get { return _salesCategorynCategoryID; }
			set { _salesCategorynCategoryID = value; }
		}

		public string SalesCategory_CategoryID
		{
			get { return _salesCategorynCategoryID.StrDescription; }
			//set { _salesCategorynCategoryID.st = value; }
		}

		public IList PackageGroupEntrys
		{
			get { return _packageGroupEntrys; }
			set { _packageGroupEntrys = value; }
		}
		
		public void AddPackageGroupEntry(PackageGroupEntry packageGroupEntry)
		{
			packageGroupEntry.PackageGroup = this;
			_packageGroupEntrys.Add(packageGroupEntry);
			
		}
		#endregion
	}
	
	#endregion
}
