using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region Test
	
	/// <summary>
	/// Test object for NHibernate mapped table 'Test'.
	/// </summary>
	public class Test
	{
		#region Member Variables
		
		protected int _id;
		protected string _strDescription;
		protected string _strBrand;
		protected string _strStyle;
		protected string _strColor;
		protected string _strSize;
		protected DateTime _dtValidStart;
		protected DateTime _dtValidEnd;
		protected int _nCategoryID;
		protected decimal _mBaseUnitPrice;
		protected int _nStatus;
		protected ProductType _productTypenProductTypeId;
		protected IList _memoBulletins;

		#endregion
		
		#region Constructors
		
		public Test() { }
		
		
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
		
		public string StrBrand
		{
			get { return _strBrand; }
			set { _strBrand = value; }
		}
		
		public string StrStyle
		{
			get { return _strStyle; }
			set { _strStyle = value; }
		}
		
		public string StrColor
		{
			get { return _strColor; }
			set { _strColor = value; }
		}
		
		public string StrSize
		{
			get { return _strSize; }
			set { _strSize = value; }
		}
		
//		public DateTime DtValidStart
//		{
//			get { return _dtValidStart; }
//			set { _dtValidStart = value; }
//		}
//		
//		public DateTime DtValidEnd
//		{
//			get { return _dtValidEnd; }
//			set { _dtValidEnd = value; }
//		}
		
		public int NCategoryID
		{
			get { return _nCategoryID; }
			set { _nCategoryID = value; }
		}
		
		public decimal MBaseUnitPrice
		{
			get { return _mBaseUnitPrice; }
			set { _mBaseUnitPrice = value; }
		}
		
		public int NStatus
		{
			get { return _nStatus; }
			set { _nStatus = value; }
		}
		
		
		public IList MemoBulletins
		{
			get { return _memoBulletins; }
			set { _memoBulletins = value; }
		}
		
		public ProductType ProductTypenProductTypeId
		{
			get { return _productTypenProductTypeId; }
			set { _productTypenProductTypeId = value; }
		}


		#endregion
	}
	
	#endregion
}
