using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region TimeCard
	
	/// <summary>
	/// TimeCard object for NHibernate mapped table 'tblTimeCard'.
	/// </summary>
	public class TimeCard
	{
		#region Member Variables
		
		protected int _id;
		protected DateTime _dtDate;
		protected DateTime _dtTime;
		protected Branch _branch;
		protected Employee _employee;

		#endregion
		
		#region Constructors
		
		public TimeCard() { }
		
		public TimeCard( DateTime dtDate, DateTime dtTime, Branch branch, Employee employee )
		{
			this._dtDate = dtDate;
			this._dtTime = dtTime;
			this._branch = branch;
			this._employee = employee;
		}
		
		#endregion		

		#region Public Properties
		
		public int Id
		{
			get {return _id;}
			set {_id = value;}
		}

		public DateTime DtDate
		{
			get { return _dtDate; }
			set { _dtDate = value; }
		}
		
		public DateTime DtTime
		{
			get { return _dtTime; }
			set { _dtTime = value; }
		}
		
		public Branch Branch
		{
			get { return _branch; }
			set { _branch = value; }
		}

		public Employee Employee
		{
			get { return _employee; }
			set { _employee = value; }
		}

		#endregion
	}
	
	#endregion
}
