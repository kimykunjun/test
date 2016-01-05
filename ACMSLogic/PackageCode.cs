using System;
using System.Data;
using System.Data.SqlClient;
using ACMSDAL;

namespace ACMSLogic
{
	/// <summary>
	/// Summary description for PackageCode.
	/// </summary>
	public class PackageCode
	{
		private DataTable myAllValidPackageTable;
		private DataTable myAllPackageTable;
		private DataTable myAllValidPackageTableBaseCategory;
		private TblPackage myPackageCode;

		public PackageCode()
		{
			//
			// TODO: Add constructor logic here
			//
			Init();
		}

		public static void CreateUnLinkPackage()
		{
			TblPackage sqlPackage = new TblPackage();
			sqlPackage.StrPackageCode = "Unlinked";
			DataTable packageTable = sqlPackage.SelectOne();

			if (packageTable == null || packageTable.Rows.Count == 0)
			{
				sqlPackage.StrPackageCode = "Unlinked";
				sqlPackage.NCategoryID = 1;
				sqlPackage.NStatus = 2;
				sqlPackage.DtValidEnd = DateTime.Now;
				sqlPackage.DtValidStart = DateTime.Now;
				sqlPackage.NMaxSession = 10000;
				sqlPackage.Insert();
			}
		}
		
		private void Init()
		{
			myPackageCode = new TblPackage();
			GetAllValidPackage();
		}

		public DataTable AllValidPackageTable
		{
			get 
			{
				if (myAllValidPackageTable == null)
					GetAllValidPackage();
				return myAllValidPackageTable; 
			}
		}


		public DataTable AllPackageTable
		{
			get 
			{
				if (myAllPackageTable == null)
					GetAllPackage();
				return myAllPackageTable;
			}
		}
		
		/// <summary>
		/// Get All Package from Package which include valid n nonValid base on Branch
		/// </summary>
		/// <returns></returns>
		public DataTable GetAllPackage()
		{
			myAllPackageTable = myPackageCode.GetAllPackageFromBranch(ACMSLogic.User.BranchCode);
			return myAllPackageTable;
		}

		/// <summary>
		/// Get All Valid Package Which is Valid, startDate <= currentDate <= endDate
		/// </summary>
		/// <returns></returns>
		public DataTable GetAllValidPackage()
		{
			myAllValidPackageTable = myPackageCode.GetValidPackage(ACMSLogic.User.BranchCode);
			return myAllValidPackageTable;
		}

		public DataTable GetAllValidPackageBaseCategory(int nCategoryID)
		{
			myAllValidPackageTableBaseCategory = myPackageCode.GetValidPackageFromBranchBaseCategory(ACMSLogic.User.BranchCode, nCategoryID);
			return myAllValidPackageTableBaseCategory;
		}
		
		public DataTable GetAllValidUpgradablePackageBaseOldPackage(string strPackageCode)
		{
            DataTable table = myPackageCode.GetValidUpgradablePackageBaseOldPackage(User.BranchCode, strPackageCode); 
			return table;			
		}

        public DataTable GetAllValidConvertPackage(string strPackageCode, decimal BaseUnitPrice)//jackie
        {
            DataTable table = myPackageCode.GetValidConvertPackage(User.BranchCode, BaseUnitPrice); 
            return table;
        }
        
		public DataTable GetPromotionPackage(int nCategoryID)
		{
			return myPackageCode.GetPromotionPackage(User.BranchCode, nCategoryID);
		}

		public DataTable GetPromotionPackageBasePromotionCode(string strPromotionCode)
		{
			return myPackageCode.GetPromotionPackageBasePromotionCode(strPromotionCode);
		}

		public DataTable GetUpgradeCreditPackageList(string strPackageCode)
		{
			return myPackageCode.GetUpgradableCreditPackage(strPackageCode);
		}
	}
}
