using System;
using System.Data;
using System.Configuration;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Windows.Forms;
using ACMSDAL;

namespace ACMSLogic
{
	/// <summary>
	/// Summary description for POSHelper.
	/// </summary>
	public class POSHelper
	{
		private int myCategoryID;
		private string myStrBranchCode;
        private int myNQty;
		private ACMSLogic.POS myPOS;

		public POSHelper(int nCategoryID, string strBranchCode, ACMSLogic.POS pos)
		{
			//
			// TODO: Add constructor logic here
			//
			myPOS = pos;	
			myCategoryID = nCategoryID;
			myStrBranchCode = strBranchCode;
		}

		public POSHelper(ACMSLogic.POS pos)
		{
			//
			// TODO: Add constructor logic here
			//
			myPOS = pos;	
			myCategoryID = myPOS.NCategoryID;
			myStrBranchCode = myPOS.StrBranchCode;
            myNQty = myPOS.NQty;
		}

		public DataTable SearchOneProductCode(string strProductCode)
		{
			if (myCategoryID == 11 || myCategoryID == 12)
			{
				TblProduct product = new TblProduct();
			
				string cmdText = "Select A.* from tblProduct A, tblProductBranch B where nCategoryID = @nCategoryID AND " + 
					" A.dtValidStart <= @today and A.dtValidEnd >= @today AND A.strProductCode = B.strProductCode AND " + 
					" B.strBranchCode = @strBranchCode AND A.nStatus = 1 AND A.strProductCode = @strProductCode";

				DataTable table = product.LoadData(cmdText, new string[] {"@nCategoryID", "@today", "@strBranchCode", "@strProductCode"}, 
					new object[] {myCategoryID, DateTime.Today.Date, myStrBranchCode, strProductCode});
			
				return table;
			}
			else return null;
		}
		
		public DataTable SearchOnePackageCode(string strPackageCode)
		{
			TblEmployee employee = new TblEmployee();
			DataTable table = new DataTable();
				
			string cmdText = "";

			if (myCategoryID == 1 || myCategoryID == 3 || 
				myCategoryID == 4 || myCategoryID == 5 || myCategoryID == 6)
			{
				cmdText = "Select A.* from tblPackage A, tblPackageBranch B where nCategoryID = @nCategoryID AND " + 
					" A.dtValidStart <= @today and A.dtValidEnd >= @today AND A.strPackageCode = B.strPackageCode AND " + 
					" B.strBranchCode = @strBranchCode AND A.nStatus = 1 and A.strPackageCode = @strPackageCode";

				table = employee.LoadData(cmdText, new string[] {"@nCategoryID", "@today", "@strBranchCode", "@strPackageCode"},
					new object[] {myCategoryID, DateTime.Today.Date, myStrBranchCode, strPackageCode});
			
				return table;
			}
			if ((myCategoryID == 2) || (myCategoryID == 34))
			{
				cmdText = "Select A.* from tblPackage A, tblPackageBranch B where nCategoryID = @nCategoryID AND " + 
					" A.dtValidStart <= @today and A.dtValidEnd >= @today AND A.strPackageCode = B.strPackageCode AND " + 
					" B.strBranchCode = @strBranchCode AND A.nStatus = 1 AND A.fGiro = 1 and A.strPackageCode = @strPackageCode";

				table = employee.LoadData(cmdText, new string[] {"@nCategoryID", "@today", "@strBranchCode", "@strPackageCode"}, 
							new object[] {myCategoryID, DateTime.Today.Date, myStrBranchCode, strPackageCode});
			
				return table;
			}
			if (myCategoryID == 7)
			{
				cmdText = "Select * from tblCreditPackage where nCategoryID = 7 AND " + 
					" dtValidStart <= @today and dtValidEnd >= @today and strCreditPackageCode = @strCreditPackageCode " ;

				table = employee.LoadData(cmdText, new string[] {"@today", "@strCreditPackageCode"}, 
					new object[] {DateTime.Today.Date, strPackageCode});
			
				return table;
			}
			if (myCategoryID == 8 || myCategoryID == 9)
			{
				cmdText = "Select * from tblPackageGroup where nCategoryID = @nCategoryID AND " + 
					" dtValidStart <= @today and dtValidEnd >= @today and strPackageGroupCode = @strPackageGroupCode";

				table = employee.LoadData(cmdText, new string[] {"@nCategoryID", "@today", "@strPackageGroupCode"}, 
					new object[] {myCategoryID, DateTime.Today.Date, strPackageCode});
			
				return table;
			}	
	

			return null;
		}

		public DataTable SearchProductCode(string searchText)
		{
			if (myCategoryID == 11 || myCategoryID == 12)
			{
				TblProduct product = new TblProduct();

				if (searchText.Length > 0)
				{
					searchText = "%" + searchText + "%";

					string cmdText = "Select A.*, C.strDescription as BrandDesc, D.strDescription as ColorDesc, " + 
						" E.strDescription as SizeDesc, F.strDescription as StyleDesc,R.nQty from tblProduct A " + 
						" Inner Join tblProductBranch B On A.strProductCode = B.strProductCode " + 
						" left outer join tblBrand C on A.strBrandCode = C.strBrandCode "+
						" left outer join tblColor D on A.strColorCode = D.strColorCode "+
						" left outer join tblSize E on A.strSizeCode = E.strSizeCode "+
						" left outer join tblStyle F on A.strStyleCode = F.strStyleCode "+
                        " left outer join tblSCStockRecon R on (A.strProductCode = R.strProductCode AND B.strBranchCode=R.strBranchCode) " +
						" where nCategoryID = @nCategoryID AND " + 
						" A.dtValidStart <= @today and A.dtValidEnd >= @today AND " + 
						" B.strBranchCode = @strBranchCode AND A.nStatus = 1 AND " + 
						" (A.strProductCode like @Param or A.strDescription like @Param or " +
                        "  F.strStyleCode like @Param or F.strDescription like @Param) ";

					DataTable table = product.LoadData(cmdText, new string[] {"@nCategoryID", "@today", "@strBranchCode", "@Param" }, 
						new object[] {myCategoryID, DateTime.Today.Date, myStrBranchCode, searchText});
					return table;
				}
				else
				{
					string cmdText = "Select A.* from tblProduct A, tblProductBranch B where nCategoryID = @nCategoryID AND " + 
						" A.dtValidStart <= @today and A.dtValidEnd >= @today AND A.strProductCode = B.strProductCode AND " + 
						" B.strBranchCode = @strBranchCode AND A.nStatus = 1";

					DataTable table = product.LoadData(cmdText, new string[] {"@nCategoryID", "@today", "@strBranchCode"}, new object[] {myCategoryID, DateTime.Today.Date, myStrBranchCode});
			
					return table;
				}
			}
            else if (myCategoryID == 38)
            {
                TblProduct product = new TblProduct();
                if (searchText.Length > 0)
                {
                    searchText = "%" + searchText + "%";
                    string cmdText = "Select * from tblCashVoucher where strbranchcode=@strBranchCode and fsell=1 and nstatusid=0 and nTerminalID=@nTerminalID and " +
                    " (strSN like @Param or strDescription like @Param ) ";
                    
                    DataTable table = product.LoadData(cmdText, new string[] { "@strBranchCode", "@Param" }, new object[] { myStrBranchCode, myPOS.NTerminalID, searchText });

                    return table;
                }
                else
                {
                    string cmdText = "Select * from tblCashVoucher where strbranchcode=@strBranchCode and fsell=1 and nstatusid=0 and nTerminalID=@nTerminalID";

                    DataTable table = product.LoadData(cmdText, new string[] { "@strBranchCode" }, new object[] { myStrBranchCode, myPOS.NTerminalID });

                    return table;
                }                
            }
            else
            {
                return null;
            }
		}
        public DataTable GetDataTable()
		{
			TblEmployee employee = new TblEmployee();
			DataTable table = new DataTable();
				
			string cmdText = "";
			int MemberAge = 0;

			//string cmdAge = "select datediff(yy, dtDOB,getdate()) from tblmember where strMembershipID = @strMembershipID";
            string cmdAge = "select case when datediff(yy, dtDOB,getdate())=22 and getdate()<(case when ISDATE(Convert(varchar(4),year(GETDATE()))+'-'+Convert(varchar(5),dtDOB,110))=1 then Convert(varchar(4),year(GETDATE()))+'-'+Convert(varchar(5),dtDOB,110) else Convert(varchar(4),year(GETDATE()))+'-02-28' end) then 21 else datediff(yy, dtDOB,getdate()) end from tblmember where strMembershipID = @strMembershipID";
			DataTable AgeTable = new DataTable();
			AgeTable = employee.LoadData(cmdAge, new string[] {"@strMembershipID"},new object[] {myPOS.StrMembershipID});
			if (ACMS.Convert.ToInt32(AgeTable.Rows[0][0]) <= 21)//jackie change to 18yrs old 1507
				MemberAge =1;                       

			if (myCategoryID == 1 || myCategoryID == 3 || 
				myCategoryID == 4 || myCategoryID == 5 || myCategoryID == 6 ||
				myCategoryID == 14 || myCategoryID == 23)
			{
				if (MemberAge == 0)
                    cmdText = "Select A.* from tblPackage A, tblPackageBranch B where nCategoryID = @nCategoryID AND " + 
					" A.dtValidStart <= @today and A.dtValidEnd >= @today AND A.strPackageCode = B.strPackageCode AND " + 
					" B.strBranchCode = @strBranchCode AND A.nStatus = 1 and fSell=1 and fstudentpackage <> 1";
				else
                    cmdText = "Select A.* from tblPackage A, tblPackageBranch B where nCategoryID = @nCategoryID AND " + 
						" A.dtValidStart <= @today and A.dtValidEnd >= @today AND A.strPackageCode = B.strPackageCode AND " + 
						" B.strBranchCode = @strBranchCode AND A.nStatus = 1 and fSell=1";


				table = employee.LoadData(cmdText, new string[] {"@nCategoryID", "@today", "@strBranchCode","@strMembershipID","@fMemberAge"}, new object[] {myCategoryID, DateTime.Today.Date, myStrBranchCode,myPOS.StrMembershipID,MemberAge});
			
				return table;
			}
			if (myCategoryID == 2)
			{
				cmdText = "Select A.* from tblPackage A, tblPackageBranch B where nCategoryID = @nCategoryID AND " + 
					" A.dtValidStart <= @today and A.dtValidEnd >= @today AND A.strPackageCode = B.strPackageCode AND " + 
					" B.strBranchCode = @strBranchCode AND A.nStatus = 1 AND A.fGiro = 1";

				table = employee.LoadData(cmdText, new string[] {"@nCategoryID", "@today", "@strBranchCode"}, new object[] {myCategoryID, DateTime.Today.Date, myStrBranchCode});
			
				return table;
			}
			if (myCategoryID == 7)
			{
				cmdText = "Select * from tblCreditPackage where nCategoryID = 7 AND " + 
					" dtValidStart <= @today and dtValidEnd >= @today";

				table = employee.LoadData(cmdText, new string[] {"@today"}, new object[] {DateTime.Today.Date});
			
				return table;
			}
            //if (myCategoryID == 13)
            //{
            //    cmdText = "Select * from tblCreditPackage where nCategoryID = 13 AND " +
            //        " dtValidStart <= @today and dtValidEnd >= @today";

            //    table = employee.LoadData(cmdText, new string[] { "@today" }, new object[] { DateTime.Today.Date });

            //    return table;
            //}
            if (myCategoryID == 36)
            {
                cmdText = "Select * from tblCreditPackage where nCategoryID = 36 AND " +
                    " dtValidStart <= @today and dtValidEnd >= @today";

                table = employee.LoadData(cmdText, new string[] { "@today" }, new object[] { DateTime.Today.Date });

                return table;
            }
            if (myCategoryID == 37)
            {
                cmdText = "Select * from tblCreditPackage where nCategoryID = 37 AND " +
                    " dtValidStart <= @today and dtValidEnd >= @today";

                table = employee.LoadData(cmdText, new string[] { "@today" }, new object[] { DateTime.Today.Date });

                return table;
            }
            if (myCategoryID == 38)
            {
                cmdText = "Select * from tblCashVoucher where strbranchcode=@strBranchCode and fsell=1 and nstatusid=0 ORDER BY strSN ";

                table = employee.LoadData(cmdText, new string[] { "@strBranchCode" }, new object[] { myStrBranchCode });

                return table;
            }
			if (myCategoryID == 8 || myCategoryID == 9)
			{
				cmdText = "Select * from tblPackageGroup where nCategoryID = @nCategoryID AND " + 
					" dtValidStart <= @today and dtValidEnd >= @today";

				table = employee.LoadData(cmdText, new string[] {"@nCategoryID", "@today"}, new object[] {myCategoryID, DateTime.Today.Date});
			
				return table;
			}
			else if (myCategoryID == 11 || myCategoryID == 12 || myCategoryID == 21)
			{
				cmdText = "Select A.*, C.strDescription as BrandDesc, D.strDescription as ColorDesc, " + 
					" E.strDescription as SizeDesc, F.strDescription as StyleDesc, R.nQty " +
					" from tblProduct A inner join tblProductBranch B on A.strProductCode = B.strProductCode " + 
					" left outer join tblBrand C on A.strBrandCode = C.strBrandCode "+
					" left outer join tblColor D on A.strColorCode = D.strColorCode "+
					" left outer join tblSize E on A.strSizeCode = E.strSizeCode "+
					" left outer join tblStyle F on A.strStyleCode = F.strStyleCode "+
                    " left outer join tblSCStockRecon R on (A.strProductCode = R.strProductCode AND B.strBranchCode=R.strBranchCode) "+
					" where nCategoryID = @nCategoryID AND " + 
					" A.dtValidStart <= @today and A.dtValidEnd >= @today AND " +
                    " B.strBranchCode = @strBranchCode AND A.nStatus = 1 ";

				table = employee.LoadData(cmdText, new string[] {"@nCategoryID", "@today", "@strBranchCode"}, new object[] {myCategoryID, DateTime.Today.Date, myStrBranchCode});
			
				return table;
			}
			else if (myCategoryID == 21)
			{
				cmdText = "Select A.* from tblProduct A, tblProductBranch B where nCategoryID = @nCategoryID AND " + 
					" A.dtValidStart <= @today and A.dtValidEnd >= @today AND A.strProductCode = B.strProductCode AND " + 
					" B.strBranchCode = @strBranchCode AND A.nStatus = 1 AND A.strProductCode = 'MW' ";

				table = employee.LoadData(cmdText, new string[] {"@nCategoryID", "@today", "@strBranchCode"}, new object[] {myCategoryID, DateTime.Today.Date, myStrBranchCode});
			
				return table;
			}
            else if (myCategoryID == 17)
            {
                //cmdText = "select r2.* from tblreceipt r2 Where strMembershipID = @strMembershipID AND nCategoryID = 17 AND fVoid = 0 AND mTotalAmount > 0 and strReceiptNo not in (select strcode from tblReceiptEntries re join tblReceipt r on re.strReceiptNo=r.strReceiptNo where r.fVoid=0 and r.strReceiptNo=r2.strReceiptNo)";
                cmdText = "select r1.* from (select r.* from tblreceipt r Where strMembershipID = '" + myPOS.StrMembershipID  + "' AND nCategoryID = 17 AND fVoid = 0 AND mTotalAmount > 0) r1 left join (select re.strCode from tblReceiptEntries re join tblReceipt r on re.strReceiptNo=r.strReceiptNo where r.fVoid=0) r2 on r1.strReceiptNo=r2.strCode where strCode is null ";
                table = employee.LoadData(cmdText, new string[] { "@strMembershipID" }, new object[] { myPOS.StrMembershipID });

                return table;
            }

            return null;
        }
    }
}
