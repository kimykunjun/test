using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region GIROBatchEntry
	
	/// <summary>
	/// GIROBatchEntry object for NHibernate mapped table 'tblGIROBatchEntries'.
	/// </summary>
	public class GIROBatchEntry
	{
		#region Member Variables
		
		protected int _id;
		protected decimal _mNettAmount;
		protected decimal _mGSTAmount;
		protected decimal _mTotalAmount;
		protected int _nStatusID;
		protected string _strRemarks;
		protected GIRO _gIRO;
		protected GIROBatch _gIROBatch;

		#endregion
		
		#region Constructors
		
		public GIROBatchEntry() { }
		
		public GIROBatchEntry( decimal mNettAmount, decimal mGSTAmount, decimal mTotalAmount, int nStatusID, string strRemarks, GIRO gIRO, GIROBatch gIROBatch )
		{
			this._mNettAmount = mNettAmount;
			this._mGSTAmount = mGSTAmount;
			this._mTotalAmount = mTotalAmount;
			this._nStatusID = nStatusID;
			this._strRemarks = strRemarks;
			this._gIRO = gIRO;
			this._gIROBatch = gIROBatch;
		}
		
		#endregion		

		#region Public Properties
		
		public int Id
		{
			get {return _id;}
			set {_id = value;}
		}

		public decimal MNettAmount
		{
			get { return _mNettAmount; }
			set { _mNettAmount = value; }
		}
		
		public decimal MGSTAmount
		{
			get { return _mGSTAmount; }
			set { _mGSTAmount = value; }
		}
		
		public decimal MTotalAmount
		{
			get { return _mTotalAmount; }
			set { _mTotalAmount = value; }
		}
		
		public int NStatusID
		{
			get { return _nStatusID; }
			set { _nStatusID = value; }
		}
		
		public string StrRemarks
		{
			get { return _strRemarks; }
			set { _strRemarks = value; }
		}
		
		public GIRO GIRO
		{
			get { return _gIRO; }
			set { _gIRO = value; }
		}

		public GIROBatch GIROBatch
		{
			get { return _gIROBatch; }
			set { _gIROBatch = value; }
		}

		#endregion
	}
	
	#endregion
}
