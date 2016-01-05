using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region PTCommLevel
	
	/// <summary>
	/// PTCommLevel object for NHibernate mapped table 'tblPTCommLevel'.
	/// </summary>
	public class PTCommLevel
	{
		#region Member Variables
		
		protected int _id;
		protected int _nUpperLimit;
		protected decimal _mServiceCommission;

		#endregion
		
		#region Constructors
		
		public PTCommLevel() { }
		
		public PTCommLevel(int nUpperLimit, decimal mServiceCommission )
		{
			this._nUpperLimit = nUpperLimit;
			this._mServiceCommission = mServiceCommission;
		}
		
		#endregion		

		#region Public Properties
		
		public int Id
		{
			get {return _id;}
			set {_id = value;}
		}

		public int NUpperLimit
		{
			set{_nUpperLimit =value;}
			get{return _nUpperLimit;}
		}

		public decimal MServiceCommission
		{
			get { return _mServiceCommission; }
			set { _mServiceCommission = value; }
		}
		
		#endregion
	}
	
	#endregion
}
