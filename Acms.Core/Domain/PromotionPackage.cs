using System;

namespace Acms.Core.Domain
{
	/// <summary>
	/// Summary description for EmployeeBranchRights.
	/// </summary>
	public class PromotionPackage
	{
		protected Package _package;
		protected Promotion _promotion;

		public PromotionPackage()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public PromotionPackage(Package package, Promotion promotion)
		{
			this._package = package;
			this._promotion = promotion;
		}

		public Package Package
		{
			set{_package = value;}
			get{return _package;}
		}

		public Promotion Promotion
		{
			set{_promotion = value;}
			get{return _promotion;}
		}
	}
}

