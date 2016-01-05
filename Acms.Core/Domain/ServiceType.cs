using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region ServiceType
	
	/// <summary>
	/// ServiceType object for NHibernate mapped table 'tblServiceType'.
	/// </summary>
	public class ServiceType
	{
		#region Member Variables
		
		protected int _id;
		protected string _strDescription;
		protected IList _services = new ArrayList();

		#endregion
		
		#region Constructors
		
		public ServiceType() { }
		
		public ServiceType( string strDescription )
		{
			this._strDescription = strDescription;
		}
		
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
		
		public IList Services
		{
			get { return _services; }
			set { _services = value; }
		}
		
		public void AddService(Service service)
		{
			service.ServiceType = this;
			_services.Add(service);
		}
		#endregion
	}
	
	#endregion
}
