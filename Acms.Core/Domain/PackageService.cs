using System;

namespace Acms.Core.Domain
{
	/// <summary>
	/// Summary description for EmployeeBranchRights.
	/// </summary>
	public class PackageService
	{
		protected Service _service;
		protected Package _packageCode;

		public PackageService()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public PackageService(Service service, Package packageCode)
		{
			this._service = service;
			this._packageCode = packageCode;
		}

		public Service Service
		{
			set{_service = value;}
			get{return _service;}
		}

		public Package Package
		{
			set{_packageCode = value;}
			get{return _packageCode;}
		}
	}
}
