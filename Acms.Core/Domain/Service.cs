using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region Service
	
	/// <summary>
	/// Service object for NHibernate mapped table 'tblService'.
	/// </summary>
	public class Service
	{
		#region Member Variables
		
		protected string _id;
		protected string _strDescription;
		protected int _nDuration;
		protected decimal _mServiceCommission1;
		protected decimal _mServiceCommission2;
		protected decimal _mServiceCommission3;
		protected decimal _mServiceCommission4;
		protected decimal _mServiceCommission5;
		protected decimal _mBasePrice;
		protected ServiceType _serviceType;
		protected IList _packageServices = new ArrayList();
		protected IList _serviceSessions = new ArrayList();

		#endregion
		
		#region Constructors
		
		public Service() { }
		
		public Service( string strDescription, int nDuration, decimal mServiceCommission1, decimal mServiceCommission2, decimal mServiceCommission3, decimal mServiceCommission4, decimal mServiceCommission5, decimal mBasePrice, ServiceType serviceType )
		{
			this._strDescription = strDescription;
			this._nDuration = nDuration;
			this._mServiceCommission1 = mServiceCommission1;
			this._mServiceCommission2 = mServiceCommission2;
			this._mServiceCommission3 = mServiceCommission3;
			this._mServiceCommission4 = mServiceCommission4;
			this._mServiceCommission5 = mServiceCommission5;
			this._mBasePrice = mBasePrice;
			this._serviceType = serviceType;
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
		
		public int NDuration
		{
			get { return _nDuration; }
			set { _nDuration = value; }
		}
		
		public decimal MServiceCommission1
		{
			get { return _mServiceCommission1; }
			set { _mServiceCommission1 = value; }
		}
		
		public decimal MServiceCommission2
		{
			get { return _mServiceCommission2; }
			set { _mServiceCommission2 = value; }
		}
		
		public decimal MServiceCommission3
		{
			get { return _mServiceCommission3; }
			set { _mServiceCommission3 = value; }
		}
		
		public decimal MServiceCommission4
		{
			get { return _mServiceCommission4; }
			set { _mServiceCommission4 = value; }
		}
		
		public decimal MServiceCommission5
		{
			get { return _mServiceCommission5; }
			set { _mServiceCommission5 = value; }
		}
		
		public decimal MBasePrice
		{
			get { return _mBasePrice; }
			set { _mBasePrice = value; }
		}
		
		public ServiceType ServiceType
		{
			get { return _serviceType; }
			set { _serviceType = value; }
		}

		public IList PackageServices
		{
			get { return _packageServices; }
			set { _packageServices = value; }
		}

		public void AddServiceSession(ServiceSession serviceSession)
		{
			serviceSession.Service = this;
			_serviceSessions.Add(serviceSession);
		}
		
		public IList ServiceSessions
		{
			get { return _serviceSessions; }
			set { _serviceSessions = value; }
		}
		
		public void AddPackageService(PackageService packageService)
		{
			packageService.Service = this;
			_packageServices.Add(packageService);
			
		}

		#endregion
	}
	
	#endregion
}
