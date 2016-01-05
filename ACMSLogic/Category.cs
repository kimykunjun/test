using System;
using System.Data;
using System.Data.SqlClient;
using ACMSDAL;

namespace ACMSLogic
{
	/// <summary>
	/// Summary description for PackageCategory.
	/// </summary>
	public class Category
	{
		private TblCategory myCategory;
		//private DataTable myDataTable;

		public Category()
		{
			//
			// TODO: Add constructor logic here
			//

			Init();
		}
		
		private void Init()
		{
			myCategory = new TblCategory();
			//myDataTable = myCategory.SelectAll(); 
		}

		public DataTable GetPackageCategory()
		{
			return myCategory.GetPackageCategory();
		}
		
		public DataTable GetCreditPackageCategory()
		{
			return myCategory.GetCreditPackageCategory();
		}

	}
}
