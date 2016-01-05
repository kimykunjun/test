using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region IBTEntry
	
	/// <summary>
	/// IBTEntry object for NHibernate mapped table 'tblIBTEntries'.
	/// </summary>
	public class IBTEntry
	{
		#region Member Variables
		
		protected int _id;
		protected int _nQuantity;
		protected IBT _iBT;
		protected Product _productstrItemCode;

		#endregion
		
		#region Constructors
		
		public IBTEntry() { }
		
		
		public IBTEntry( int nQuantity, IBT iBT, Product productstrItemCode )
		{

			this._nQuantity = nQuantity;
			this._iBT = iBT;
			this._productstrItemCode = productstrItemCode;
		}

		#endregion		

		#region Public Properties
		
		public int Id
		{
			get {return _id;}
			set {_id = value;}
		}

		
		
		public int NQuantity
		{
			get { return _nQuantity; }
			set { _nQuantity = value; }
		}
		
		public IBT IBT
		{
			get { return _iBT; }
			set { _iBT = value; }
		}

		public Product Product_StrItemCode
		{
			get { return _productstrItemCode; }
			set { _productstrItemCode = value; }
		}

		public string ProductStrItemCode
		{
			get{return _productstrItemCode.Id;} 
		}

		public bool IsModify
		{
			get{return false;}
		}

		public string ItemDescription
		{
			get{return _productstrItemCode.StrDescription;} 
		}
		#endregion
	}
	
	#endregion
}
