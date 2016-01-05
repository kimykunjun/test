using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region MemoReceipient
	
	/// <summary>
	/// MemoReceipient object for NHibernate mapped table 'tblMemoReceipient'.
	/// </summary>
	public class MemoReceipient
	{
		#region Member Variables
		
		protected int _id;
		protected int _nReceipientID;
		protected int _nTypeID;
		protected Memo _memo;

		#endregion
		
		#region Constructors
		
		public MemoReceipient() { }
		
		public MemoReceipient( Memo memo )
		{
			this._memo = memo;
		}
		
		#endregion		

		#region Public Properties
		
		public int Id
		{
			get {return _id;}
			set {_id = value;}
		}

		public int NReceipientID
		{
			get {return _nReceipientID;}
			set {_nReceipientID = value;}
		}

		public int NTypeID
		{
			get {return _nTypeID;}
			set {_nTypeID = value;}
		}

		public Memo Memo
		{
			get { return _memo; }
			set { _memo = value; }
		}

		#endregion
	}
	
	#endregion
}
