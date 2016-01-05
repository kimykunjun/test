using System;

namespace Acms.Core.Domain
{
	/// <summary>
	/// Summary description for EmployeeBranchRights.
	/// </summary>
	public class PackageClass
	{
		protected Class _class;
		protected Package _packageCode;

		public PackageClass()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public PackageClass(Class classd, Package packageCode)
		{
			this._class = classd;
			this._packageCode = packageCode;
		}

		public Class Class
		{
			set{_class = value;}
			get{return _class;}
		}

		public Package Package
		{
			set{_packageCode = value;}
			get{return _packageCode;}
		}
	}
}
