using System;
using System.Data;
using System.Data.SqlClient;
using ACMSDAL;
using System.Data.SqlTypes;
using System.Windows.Forms;

namespace ACMSLogic
{
	/// <summary>
	/// Summary description for CreditAccount.
	/// </summary>
	/// 
	public class CreditAccount
	{
		private TblMemberCreditPackage myCreditPkg;
		private DataTable myDataTable;
        
		public CreditAccount()
		{
			//
			// TODO: Add constructor logic here
			//
            
			Init();
		}
		
		private void Init()
		{
			myCreditPkg = new TblMemberCreditPackage();
            
		}

		public void Refresh(string strMembershipID)
		{
            //myDataTable = myCreditPkg.GetValidMemberCreditPackage(strMembershipID);
            myDataTable = myCreditPkg.GetValidAndExpiredMemberCreditPackage(strMembershipID);
			
			if (myDataTable != null)
			{
				if (!myDataTable.Columns.Contains("Balance"))
				{
					DataColumn colBalance = new DataColumn("Balance", System.Type.GetType("System.Decimal"));
					myDataTable.Columns.Add(colBalance);
				}
                if (!myDataTable.Columns.Contains("strBalNew"))
                {
                    DataColumn colFNew = new DataColumn("strBalNew", System.Type.GetType("System.String"));
                    myDataTable.Columns.Add(colFNew);
                }
				MemberPackage memberPackage = new MemberPackage();
				//Select Sum (mCreditPackageUsagePrice) From tblMemberPackage 
				//Where nCreditPackageID = A.nCreditPackageID and nStatusID <> 2 Group by nCreditPackageID
				int nCreditPackageID = 0;
				foreach (DataRow r in myDataTable.Rows)
				{
					nCreditPackageID = ACMS.Convert.ToInt32(r["nCreditPackageID"]);
                    r["Balance"] = ACMS.Convert.ToDecimal(r["mCreditAmount"]) + ACMS.Convert.ToDecimal(r["mFreeCredit"]) + ACMS.Convert.ToDecimal(r["mTopupAmount"]) -
						    memberPackage.GetCreditPackageUsagePrice(nCreditPackageID);
                    r["strBalNew"] = 0;
				}
			}
		}

        public void RefreshForPackageUsage(string strMembershipID, int nCategoryID)
        {
            if (nCategoryID == 7)
                myDataTable = myCreditPkg.GetValidMemberCreditPackageForPackageUsage(strMembershipID);
            else if (nCategoryID == 36 || nCategoryID == 37)
                myDataTable = myCreditPkg.GetValidMemberCreditPackageForHolisticPackageUsage(strMembershipID);

            if (myDataTable != null)
            {
                if (!myDataTable.Columns.Contains("PaidAmt"))
                {
                    DataColumn colBalance = new DataColumn("PaidAmt", System.Type.GetType("System.Decimal"));
                    myDataTable.Columns.Add(colBalance);
                    double paidAmt = 0;
                    foreach (DataRow r in myDataTable.Rows)
                    {
                        paidAmt = ACMS.Convert.ToDouble(r["mSubTotal"]) - ACMS.Convert.ToDouble(r["mDiscountAmount"]) + ACMS.Convert.ToDouble(r["mUpgradeAmount"]);
                        r["PaidAmt"] = paidAmt;
                    }
                }
            }
        }
        public void RefreshForConvert(string strMembershipID, int nCategoryID, DataTable receiptItemTable)
        {
            if (nCategoryID == 1)
                myDataTable = myCreditPkg.GetValidMemberCreditPackageForConvertToFit(strMembershipID);
            else if (nCategoryID == 4 || nCategoryID == 5 || nCategoryID == 6 || nCategoryID == 7 || nCategoryID == 9)
                myDataTable = myCreditPkg.GetValidMemberCreditPackageForConvert(strMembershipID);
            else if (nCategoryID == 36)
                myDataTable = myCreditPkg.GetValidMemberCreditPackageForConvertHolisticToHolisticFit(strMembershipID);            
            else if (nCategoryID == 37)
                myDataTable = myCreditPkg.GetValidMemberCreditPackageForConvertHolistic(strMembershipID);            

            if (myDataTable != null)
            {                
                if (!myDataTable.Columns.Contains("Balance"))
                {
                    DataColumn colBalance = new DataColumn("Balance", System.Type.GetType("System.Decimal"));
                    myDataTable.Columns.Add(colBalance);
                }
                if (!myDataTable.Columns.Contains("mPackagePaidAmount"))
                {
                    DataColumn colBalance = new DataColumn("mPackagePaidAmount", System.Type.GetType("System.Decimal"));
                    myDataTable.Columns.Add(colBalance);
                }
                if (!myDataTable.Columns.Contains("strBalNew"))
                {
                    DataColumn colFNew = new DataColumn("strBalNew", System.Type.GetType("System.String"));
                    myDataTable.Columns.Add(colFNew);
                }
                if (!myDataTable.Columns.Contains("nFreeUtil"))
                {
                    DataColumn colNFreeUtil = new DataColumn("nFreeUtil", System.Type.GetType("System.Int32"));
                    myDataTable.Columns.Add(colNFreeUtil);
                }
                if (!myDataTable.Columns.Contains("mFreeUtil"))
                {
                    DataColumn colMFreeUtil = new DataColumn("mFreeUtil", System.Type.GetType("System.Decimal"));
                    myDataTable.Columns.Add(colMFreeUtil);
                }
                if (!myDataTable.Columns.Contains("strCalculation"))
                {
                    DataColumn colBalance = new DataColumn("strCalculation", System.Type.GetType("System.String"));
                    myDataTable.Columns.Add(colBalance);
                }
                MemberPackage memberPackage = new MemberPackage();
                double paidAmt=0;
                int nCreditPackageID = 0;
                foreach (DataRow r in myDataTable.Rows)
                {
                    string strCalculation = "Calculation:\n";
                    nCreditPackageID = ACMS.Convert.ToInt32(r["nCreditPackageID"]);
                    r["strBalNew"] = 0;
                    if (nCategoryID == 7 && nCategoryID == ACMS.Convert.ToInt32(r["nCategoryID"])) //Same spa credit category upgrade
                    {
                        r["Balance"] = ACMS.Convert.ToDecimal(r["mCreditAmount"]) + ACMS.Convert.ToDecimal(r["mTopupAmount"]) - memberPackage.GetCreditPackageUsagePrice(nCreditPackageID);
                        if (memberPackage.GetCreditPackageUsagePrice(nCreditPackageID) == 0)
                        {
                            r["strBalNew"] = "New";
                        }                        
                        strCalculation += "Is same category upgrade? Yes\n";
                        strCalculation += "Used Amt = " + memberPackage.GetCreditPackageUsagePrice(nCreditPackageID).ToString() + "\n";                        
                    }
                    else if ((nCategoryID == 36 || nCategoryID == 37) && (ACMS.Convert.ToInt32(r["nCategoryID"]) == 36 || ACMS.Convert.ToInt32(r["nCategoryID"]) == 37)) //Same Holistic category upgrade
                    {
                        strCalculation += "Is same category upgrade? Yes\n";
                        strCalculation += "Used Amt = " + memberPackage.GetCreditPackageUsagePrice(nCreditPackageID).ToString() + "\n";
                        if ((ACMS.Convert.ToDecimal(r["mCreditAmount"]) + ACMS.Convert.ToDecimal(r["mTopupAmount"]) - memberPackage.GetCreditPackageUsagePrice(nCreditPackageID)) <= (ACMS.Convert.ToDecimal(r["mCreditAmount"]) / 2) || memberPackage.GetCreditPackageUsagePrice(nCreditPackageID) == 0)
                        {
                            r["Balance"] = ACMS.Convert.ToDecimal(r["mCreditAmount"]) + ACMS.Convert.ToDecimal(r["mTopupAmount"]) - memberPackage.GetCreditPackageUsagePrice(nCreditPackageID);
                            if (memberPackage.GetCreditPackageUsagePrice(nCreditPackageID) == 0)
                            {
                                r["strBalNew"] = "New";                                
                            }                            
                        }
                        else
                        {
                            TblCreditPackage creditPackage = new TblCreditPackage();
                            creditPackage.StrCreditPackageCode = receiptItemTable.Rows[0]["strCode"].ToString();
                            creditPackage.SelectOne();

                            if (ACMS.Convert.ToDecimal(creditPackage.MCreditAmount) == ACMS.Convert.ToDecimal(r["mCreditAmount"]) && receiptItemTable.Rows.Count == 1)
                            {
                                r["Balance"] = (ACMS.Convert.ToDecimal(r["mCreditAmount"]) / 2);
                                strCalculation += "Top up of same category Utilization < 50%\nBalance to convert only 50% of credit amount";
                            }                            
                            else
                                r["Balance"] = ACMS.Convert.ToDecimal(r["mCreditAmount"]) + ACMS.Convert.ToDecimal(r["mTopupAmount"]) - memberPackage.GetCreditPackageUsagePrice(nCreditPackageID);
                        }                        
                    }
                    else if (ACMS.Convert.ToInt32(r["nCategoryID"]) == 36 || ACMS.Convert.ToInt32(r["nCategoryID"]) == 37) //Holistic different category upgrade
                    {
                        strCalculation += "Is same category upgrade? No\n";
                        strCalculation += "Used Amt = " + memberPackage.GetCreditPackageUsagePriceForDifferentCategoryConvert(nCreditPackageID).ToString() + "\n";
                                                
                        paidAmt = ACMS.Convert.ToDouble(r["mPackagePaidAmount"]);
                        r["Balance"] = ACMS.Convert.ToDecimal(paidAmt) + ACMS.Convert.ToDecimal(r["mTopupAmount"]) - memberPackage.GetCreditPackageUsagePriceForDifferentCategoryConvert(nCreditPackageID);
                        
                        if (memberPackage.GetCreditPackageUsagePriceForDifferentCategoryConvert(nCreditPackageID) == 0)
                        {
                            r["strBalNew"] = "New";                        
                        }                        
                    }                    
                    else //Spa credit different category upgrade
                    {
                        paidAmt = ACMS.Convert.ToDouble(r["mPackagePaidAmount"]); 

                        r["Balance"] = ACMS.Convert.ToDecimal(paidAmt) + ACMS.Convert.ToDecimal(r["mTopupAmount"]) - memberPackage.GetCreditPackageUsagePriceForDifferentCategoryConvert(nCreditPackageID);
                        if (memberPackage.GetCreditPackageUsagePrice(nCreditPackageID) == 0)
                        {
                            r["strBalNew"] = "New";
                        }
                        strCalculation += "Is same category upgrade? No\n";
                        strCalculation += "Used Amt = " + memberPackage.GetCreditPackageUsagePriceForDifferentCategoryConvert(nCreditPackageID).ToString() + "\n";
                    }
                
                    strCalculation += "Usage Bal Amt = " + r["Balance"].ToString();
                    r["strCalculation"] = strCalculation;
                }
            }
        }        
		public DataView GetValidCreditPackage(string strMembershipID)
		{
			DataTable table = myCreditPkg.GetValid_NonExpiry_MemberCreditPackage(strMembershipID);

			if (table != null)
			{
				if (!table.Columns.Contains("Balance"))
				{
					DataColumn colBalance = new DataColumn("Balance", System.Type.GetType("System.Decimal"));
					table.Columns.Add(colBalance);
				}
				MemberPackage memberPackage = new MemberPackage();
				//Select Sum (mCreditPackageUsagePrice) From tblMemberPackage 
				//Where nCreditPackageID = A.nCreditPackageID and nStatusID <> 2 Group by nCreditPackageID
				int nCreditPackageID = 0;
				foreach (DataRow r in table.Rows)
				{
					nCreditPackageID = ACMS.Convert.ToInt32(r["nCreditPackageID"]);
				//	r["Balance"] = ACMS.Convert.ToDecimal(r["mCreditAmount"]) + ACMS.Convert.ToDecimal(r["mTopupAmount"]) -
				//		memberPackage.GetCreditPackageUsagePrice(nCreditPackageID);



                    r["Balance"] = ACMS.Convert.ToDecimal(r["mCreditAmount"]) + ACMS.Convert.ToDecimal(r["mFreeCredit"]) + ACMS.Convert.ToDecimal(r["mTopupAmount"]) -
                            memberPackage.GetCreditPackageUsagePrice(nCreditPackageID);
				}
				
				table.DefaultView.RowFilter = "Balance > 0";


				return table.DefaultView;
				
			}
			else
				return null;

		}

		public DataTable New()
		{
			myCreditPkg.NCreditPackageID = -1;
			DataTable table = myCreditPkg.SelectOne();
			DataRow row = table.NewRow();
			row["dtLastEditDate"] = ACMS.Convert.ToDateTime(System.DateTime.Today);
			row["dtPurchaseDate"] = ACMS.Convert.ToDateTime(System.DateTime.Today);
			row["nEmployeeID"] = User.EmployeeID;
			row["nStatusID"] = 0;
			table.Rows.Add(row);

			return table;
		}

		public static void InitMemberCreditPackageRowInPOS(DataRow memberCreditPackageRow, string strReceiptNo,
			string strMembershipID, string strCreditPackageCode, bool isFree)
		{
			TblCreditPackage creditPackage = new TblCreditPackage();
			creditPackage.StrCreditPackageCode = strCreditPackageCode;
			creditPackage.SelectOne();

			int validMonths = creditPackage.NValidMonths.IsNull ? 0 : creditPackage.NValidMonths.Value;
			memberCreditPackageRow["strMembershipID"] = strMembershipID;
			memberCreditPackageRow["strCreditPackageCode"] = strCreditPackageCode;
			memberCreditPackageRow["dtPurchaseDate"] = System.DateTime.Today.Date;
            //if (creditPackage.NCategoryID == 7)
            //memberCreditPackageRow["dtExpiryDate"] = System.DateTime.Today.AddMonths(validMonths).AddDays(-1);
			memberCreditPackageRow["fFree"] = isFree ? 1 : 0;
			memberCreditPackageRow["strReceiptNo"] = strReceiptNo;
			memberCreditPackageRow["nStatusID"] = 0;
			memberCreditPackageRow["nEmployeeID"] = ACMSLogic.User.EmployeeID;
			memberCreditPackageRow["dtLastEditDate"] = System.DateTime.Now;
			memberCreditPackageRow["mTopupAmount"] = 0;

		}
		
		public void TransferMemberCreditPackage(int nCreditPackageID, string newStrMemberShipID, string remark)
		{
			myCreditPkg.NCreditPackageID = nCreditPackageID;
			myCreditPkg.SelectOne();
			myCreditPkg.StrRemarks = remark;
			TblAudit audit = new TblAudit();
			audit.NAuditTypeID = AuditTypeID.TransferMemberCreditPackage;
			audit.NEmployeeID = User.EmployeeID;
			audit.DtDate = DateTime.Now;
			audit.StrReference= nCreditPackageID.ToString();
			audit.StrAuditEntry= "Old Owner : " + myCreditPkg.StrMembershipID + " New Owner : " + newStrMemberShipID; 
			myCreditPkg.StrMembershipID = newStrMemberShipID;
			
			TblMemberPackage sqlMemberPackage = new TblMemberPackage();
			
			ACMSDAL.ConnectionProvider connProvider = new ConnectionProvider();

			try
			{
					
				myCreditPkg.MainConnectionProvider = connProvider;
				audit.MainConnectionProvider = connProvider;
				sqlMemberPackage.MainConnectionProvider = connProvider;

				sqlMemberPackage.NCreditPackageID = nCreditPackageID;
				DataTable memberPackageTable = sqlMemberPackage.SelectAllWnCreditPackageIDLogic();
				
				foreach (DataRow row in memberPackageTable.Rows)
				{
					row["strMembershipID"] = newStrMemberShipID;
				}

				connProvider.OpenConnection();
				connProvider.BeginTransaction("TransferMemberCreditPackage");
				
				myCreditPkg.Update();
				sqlMemberPackage.SaveData(memberPackageTable);
				audit.Insert();

				connProvider.CommitTransaction();
			}
			catch (Exception)
			{
				connProvider.RollbackTransaction("TransferMemberCreditPackage");
				throw;
			}
			finally
			{
				if (connProvider.CurrentTransaction != null)
					connProvider.CurrentTransaction.Dispose();
				if (connProvider.DBConnection != null)
				{
					if (connProvider.DBConnection.State == ConnectionState.Open)
						connProvider.DBConnection.Close();
				}
				myCreditPkg.MainConnactionIsCreatedLocal = true;
				audit.MainConnactionIsCreatedLocal = true;
			}
		}

		public bool Delete(int creditPackageID)
		{
			myCreditPkg.NCreditPackageID = creditPackageID;
			myCreditPkg.SelectOne();
			myCreditPkg.NStatusID = 2;
			TblAudit audit = new TblAudit();
			audit.NAuditTypeID = AuditTypeID.DeleteMemberCreditPackage;
			audit.NEmployeeID = User.EmployeeID;
			audit.StrAuditEntry = " Delete member credit Package " + creditPackageID.ToString();
			audit.StrReference = creditPackageID.ToString();
			
			ACMSDAL.ConnectionProvider connProvider = new ConnectionProvider();

			try
			{
				
				myCreditPkg.MainConnectionProvider = connProvider;
				audit.MainConnectionProvider = connProvider;
				connProvider.OpenConnection();
				connProvider.BeginTransaction("DeleteMemberCreditPackage");
				
				myCreditPkg.Update();
				audit.Insert();

				connProvider.CommitTransaction();
				return true;
			}
			catch (Exception)
			{
				connProvider.RollbackTransaction("DeleteMemberCreditPackage");
				throw;
			}
			finally
			{
				if (connProvider.CurrentTransaction != null)
					connProvider.CurrentTransaction.Dispose();
				if (connProvider.DBConnection != null)
				{
					if (connProvider.DBConnection.State == ConnectionState.Open)
						connProvider.DBConnection.Close();
				}
				myCreditPkg.MainConnactionIsCreatedLocal = true;
				audit.MainConnactionIsCreatedLocal = true;
			}
		}
		
		/// <summary>
		/// 2.2..3.4) Update Member Credit Package
		/// </summary>
		/// <param name="nCreditPackgeID"></param>
		/// <param name="packageExpiryDate"></param>
		public void UpdateMemberCreditPackage(int nCreditPackgeID, DateTime NewPackageExpiryDate, int CurrentPackageStatus)        
		{
            myCreditPkg.NCreditPackageID = nCreditPackgeID;
            myCreditPkg.SelectOne();
            myCreditPkg.DtExpiryDate = NewPackageExpiryDate;
            myCreditPkg.NEmployeeID = User.EmployeeID;
            myCreditPkg.DtLastEditDate = DateTime.Now;

            DateTime date1 = NewPackageExpiryDate;
            DateTime date2 = DateTime.Now.Date;

            int result = DateTime.Compare(date1, date2);

            if (result >= 0)
            {
                //Update Status ID = 1, if Current status = 0
                if (CurrentPackageStatus == 1)
                {
                    myCreditPkg.NStatusID = 0;
                }
            }
            else
            {
                //Update Status ID = 0, if Current status = 1
                if (CurrentPackageStatus == 0)
                {
                    myCreditPkg.NStatusID = 1;
                }
            }			
			myCreditPkg.Update();
		}

		
		/// <summary>
		/// 2.2.3.6) view Credit Package Usage.
		/// </summary>
		/// <param name="nCreditPackageID"></param>
		/// <param name="strMembershipID"></param>
		/// <returns></returns>
		public DataTable GetValidCreditPackageUsage(int nCreditPackageID, string strMembershipID)
		{
			TblMemberPackage memberPackage = new TblMemberPackage();
            DataTable table = memberPackage.GetValidCreditPackageUsage(nCreditPackageID, strMembershipID);
            //ACMSLogic.MemberPackage.CalculateCreditMemberPackageBalance(table); 
           // string strPackageCode = table.Rows[0]["StrPackageCode"].ToString();
           // ACMSLogic.MemberPackage.CalculateMemberPackageBalance(strPackageCode, strMembershipID, table);

      		return table;
		}
		
		/// <summary>
		/// Use Member Credit Package means use the credit to buy the package and then store in the tblMemberPackage
		/// be aware some package is not allow to purchase using credit package. Must check tblCreditPackageRestriction
		/// </summary>
		/// <returns></returns>
        public string[,] UseMemberCreditPackage(string[,] strPackageCode,
            int nCreditPackageID, string strSignID, string strSigKey, string strPdfExportPath, string remark)
        {
            //ACMSDAL.ConnectionProvider connProvider = new ConnectionProvider();
            DataRow[] rows, row1s = new DataRow[strPackageCode.Length / 2];
            string[,] strUsage = new string[strPackageCode.Length / 2, 3];
            //DataColumn[] dc = new DataColumn["Usage",System.Type.GetType("System.Int")];

            try
            {
                TblMemberCreditPackage memberCreditPackage = new TblMemberCreditPackage();

                //connProvider.OpenConnection();
                //connProvider.BeginTransaction("UseMemberCreditPackage");

                //memberCreditPackage.MainConnectionProvider = connProvider;
                memberCreditPackage.NCreditPackageID = nCreditPackageID;
                DataTable table = memberCreditPackage.SelectOne();

                if (table == null || table.Rows.Count == 0)
                    throw new Exception("This member credit package been deleted by others");

                if (ACMS.Convert.ToInt32(table.Rows[0]["nStatusID"]) > 0)
                    throw new Exception("This member credit package has been deleted/expired/suspended.");

                string strCreditPackageCode = memberCreditPackage.StrCreditPackageCode.Value;
                string strMembershipID = memberCreditPackage.StrMembershipID.Value;
                TblCreditPackageRestriction restriction = new TblCreditPackageRestriction();
                restriction.StrCreditPackageCode = strCreditPackageCode;
                TblReceipt creditReceipt = new TblReceipt();
                if (!memberCreditPackage.StrReceiptNo.IsNull)
                {                    
                    creditReceipt.StrReceiptNo = memberCreditPackage.StrReceiptNo.Value;
                    creditReceipt.SelectOne();
                }                

                DataTable restricttable = restriction.SelectAllWstrCreditPackageCodeLogic();
                DataColumn colQuantity = new DataColumn("colQuantity", System.Type.GetType("System.Int32"));
                restricttable.Columns.Add(colQuantity);

                bool isAllowDiscount = false;

                if (restricttable.Rows.Count == 0)
                    throw new Exception("No allow to use credit package for this package.");
                else
                {

                    for (int j = 0; j < strPackageCode.Length / 2; j++)
                    {
                        rows = restricttable.Select("strPackageCode = '" + strPackageCode[j, 0] + "'", "strCreditPackageCode");
                        rows[0]["colQuantity"] = strPackageCode[j, 1];
                        row1s[j] = rows[0];

                    }
                    if (row1s.Length == 0)
                        throw new Exception("No allow to use credit package for this package.");
                    // check later as got two package now
                    //else
                    //{
                    //    isAllowDiscount = ACMS.Convert.ToBoolean(row1s[0]["fAllowDiscount"]);
                    //}
                }

                // Must Check balance is enough to buy a Package or not
                TblCreditPackage creditPackage = new TblCreditPackage();
                creditPackage.StrCreditPackageCode = memberCreditPackage.StrCreditPackageCode.Value;
                creditPackage.SelectOne();                
                
                decimal creditPackageValue = ACMS.Convert.ToDecimal(creditPackage.MCreditAmount);
                decimal mmbCreditPackageFreeCredit = ACMS.Convert.ToDecimal(creditPackage.MFreeCredit);
                decimal mmbCreditPackageTopupAmt = ACMS.Convert.ToDecimal(memberCreditPackage.MTopupAmount);

                decimal totalCreditUsage = GetCreditUsageFromMemberPackage(nCreditPackageID);

                decimal balance = (creditPackageValue + mmbCreditPackageTopupAmt + mmbCreditPackageFreeCredit) - totalCreditUsage;

                if (creditReceipt.MOutstandingAmount > 0 && !memberCreditPackage.StrReceiptNo.IsNull)
                {
                    DataTable creditUsageMemberPackage = null;
                    RefreshForPackageUsage(strMembershipID, ACMS.Convert.ToInt32(creditPackage.NCategoryID));
                    creditUsageMemberPackage = myDataTable;

                    double m70PercPaidAmount = 0;
                    if (creditUsageMemberPackage.Rows.Count > 0)
                        m70PercPaidAmount = ACMS.Convert.ToDouble(creditUsageMemberPackage.Select("nCreditPackageID=" + nCreditPackageID)[0]["PaidAmt"]) * 0.7;

                    if (totalCreditUsage > ACMS.Convert.ToDecimal(m70PercPaidAmount)) throw new Exception(string.Format("Total usage is more than 70% of paid amount. \n Please clear the outstanding."));
                }               

                if (balance < 0) throw new Exception(string.Format("Balance for Member Credit Package : {0} is not enough.\n Please topup your credit.", nCreditPackageID.ToString()));

                // Need to know here whether it is 1st use
                TblMemberPackage mp = new TblMemberPackage();
                //mp.MainConnectionProvider = connProvider;
                mp.NCreditPackageID = nCreditPackageID;
                DataTable temptable = mp.SelectAllWnCreditPackageIDLogic();

                bool is1stUseCreditPck = false;
                if (Convert.ToInt32(temptable.Compute("COUNT(nStatusID)", "nStatusID=0 or nStatusID=1")) == 0)
                {
                    //means news insert
                    is1stUseCreditPck = true;
                }
                int i = 0;
                foreach (DataRow drPackage in row1s)
                {
                    for (int x = 0; x < ACMS.Convert.ToInt32(drPackage[3]); x++) // quantity
                    {
                        MemberPackage memberPackage = new MemberPackage();
                        DataTable memberPackageTable = memberPackage.New(false, strMembershipID);
                        DataRow memberPackageRow = memberPackageTable.Rows[0];
                        memberPackageRow["nCreditPackageID"] = nCreditPackageID;
                        memberPackageRow["strMembershipID"] = strMembershipID;
                        memberPackageRow["dtPurchaseDate"] = DateTime.Now;
                        memberPackageRow["strRemarks"] = remark;
                        memberPackageRow["strSignatureID"] = strSignID;
                        memberPackageRow["strSigKey"] = strSigKey;
                        memberPackageRow["strSigPdfPath"] = strPdfExportPath;
                        memberPackageRow["strUtilData"] = strSigKey;
                        memberPackageRow["nStatusID"] = 0;

                        memberPackageRow["strPackageCode"] = drPackage["strPackageCode"];//strPackageCode;
                        TblPackage package = new TblPackage();
                        package.StrPackageCode = drPackage["strPackageCode"].ToString(); // strPackageCode;
                        package.SelectOne();
                        decimal creditUsage = 0;
                        decimal packageListPrice = ACMS.Convert.ToDecimal(package.MListPrice);

                        TblMember sqlMember = new TblMember();
                        //Check if redeemed spa single treatment from holistic in birthday month, give 50% discount
                        if ((creditPackage.NCategoryID == 36 || creditPackage.NCategoryID == 37) && (package.NCategoryID == 4 || (package.NCategoryID == 6 && package.NMaxSession == 1)) && sqlMember.MembershipThisMonthBirtdayForUtilised(strMembershipID, nCreditPackageID))
                        {
                            DialogResult result1 = MessageBox.Show("Member is having birthday this months and having 50% discount. Do you want to utilies?", "Warning",
                            MessageBoxButtons.YesNo);

                            if (result1 == DialogResult.Yes)
                            {
                                double discountPercent = 50;
                                memberPackageRow["strPromotionCode"] = "120046SSD";
                                // calcualte usage * quantity
                                creditUsage = packageListPrice - (packageListPrice * (decimal)discountPercent / 100);
                            }
                            else
                            {
                                if (ACMS.Convert.ToBoolean(drPackage["fAllowDiscount"]))
                                {
                                    double discountPercent = creditPackage.DCreditDiscount.Value;
                                    // calcualte usage * quantity
                                    creditUsage = packageListPrice - (packageListPrice * (decimal)discountPercent / 100);
                                }
                                else
                                {
                                    creditUsage = packageListPrice;
                                }
                            }
                        }
                        else if (ACMS.Convert.ToBoolean(drPackage["fAllowDiscount"]))
                        {
                            double discountPercent = creditPackage.DCreditDiscount.Value;
                            // calcualte usage * quantity
                            creditUsage = packageListPrice - (packageListPrice * (decimal)discountPercent / 100);
                        }
                        else
                        {
                            creditUsage = packageListPrice;
                        }

                        decimal previousBal = balance;
                        balance = decimal.Parse(previousBal.ToString("N2")) - decimal.Parse(creditUsage.ToString("N2"));
                        if (balance < 0)
                            throw new Exception(string.Format("Balance for Member Credit Package : {0} is not enough. \n Please topup your credit.", nCreditPackageID.ToString()));

                        memberPackageRow["mCreditPackageUsagePrice"] = creditUsage;
                        memberPackageRow["strRemarks"] = memberPackageRow["strRemarks"] + " " + x;

                        //Initially designed for immediate kick start
                        if (memberPackageRow["dtStartDate"].ToString() == "")
                        {
                            int iduration = package.NPackageDuration.Value;
                            DateTime dtNow = DateTime.Now.Date;
                            memberPackageRow["dtStartDate"] = dtNow;
                            if (package.StrDurationUnit.ToString().Trim() == "DAY")
                                memberPackageRow["dtExpiryDate"] = dtNow.AddDays(iduration - 1).AddDays(0);
                            else if (package.StrDurationUnit.ToString().Trim() == "WEEK")
                            {
                                iduration = iduration * 7;
                                memberPackageRow["dtExpiryDate"] = dtNow.AddDays(iduration - 1).AddDays(0);
                            }
                            else
                                memberPackageRow["dtExpiryDate"] = dtNow.AddMonths(iduration).AddDays(-1);
                        }                        

                        mp.SaveData(memberPackageTable);                        
                        strUsage[i, 0] = package.StrDescription.ToString();
                        strUsage[i, 1] = creditUsage.ToString();
                    }

                    strUsage[i, 2] = drPackage[3].ToString();
                    i++;

                }

                if (is1stUseCreditPck)
                {
                    if (memberCreditPackage.DtStartDate.ToString() == "Null")
                    {
                        memberCreditPackage.NCreditPackageID = nCreditPackageID;
                        memberCreditPackage.DtStartDate = DateTime.Now.Date;
                        memberCreditPackage.DtExpiryDate = DateTime.Now.Date.AddMonths(ACMS.Convert.ToInt32(creditPackage.NValidMonths)).AddDays(-1);
                        memberCreditPackage.Update();
                    }                    
                }

                //connProvider.CommitTransaction();
            }
            catch (Exception)
            {
                //connProvider.RollbackTransaction("UseMemberCreditPackage");
                throw;
            }
            finally
            {
                //if (connProvider.CurrentTransaction != null)
                //    connProvider.CurrentTransaction.Dispose();
                //if (connProvider.DBConnection != null)
                //{
                //    if (connProvider.DBConnection.State == ConnectionState.Open)
                //        connProvider.DBConnection.Close();
                //}
            }
            return strUsage;
        }

		public DataTable GetPrintBalanceTable(int nCreditPackageID)
		{
			TblMemberCreditPackage memberCreditPackage = new TblMemberCreditPackage();
			memberCreditPackage.NCreditPackageID = nCreditPackageID;
			DataTable table = memberCreditPackage.SelectOne();

			TblCreditPackage creditPackage = new TblCreditPackage();
			creditPackage.StrCreditPackageCode = memberCreditPackage.StrCreditPackageCode.Value;
			creditPackage.SelectOne();

			decimal creditPackageValue = ACMS.Convert.ToDecimal(creditPackage.MCreditAmount);

			decimal mmbCreditPackageTopupAmt = ACMS.Convert.ToDecimal(memberCreditPackage.MTopupAmount);
			
			decimal totalCreditUsage = GetCreditUsageFromMemberPackage(nCreditPackageID);
			
			decimal balance =  (creditPackageValue + mmbCreditPackageTopupAmt) - totalCreditUsage;

			DataTable tableToReturn = new DataTable();

			DataColumn colCreditPackageID = new DataColumn("nCreditPackageID", System.Type.GetType("System.Int32"));
			DataColumn colBalance = new DataColumn("Balance", System.Type.GetType("System.Decimal"));
			DataColumn colExpiryDate = new DataColumn("ExpiryDate", System.Type.GetType("System.DateTime"));

			tableToReturn.Columns.Add(colBalance);
			tableToReturn.Columns.Add(colCreditPackageID);
			tableToReturn.Columns.Add(colExpiryDate);

			DataRow r = tableToReturn.NewRow();
			r["nCreditPackageID"] = nCreditPackageID;
			r["Balance"] = balance;
			r["ExpiryDate"] = memberCreditPackage.DtExpiryDate.Value;

			return tableToReturn;
		}
		
		public void DeleteCreditPackageUsage(int nPackageID)
		{
			int nCreditPackageID; 
            TblServiceSession ssUsage = new TblServiceSession();
            ssUsage.NPackageID = nPackageID;
            DataTable tblUsage = ssUsage.SelectAllWnPackageIDLogic();
            if (tblUsage.Rows.Count > 0)
                throw new Exception("You Cant deleted a Used Package.");
			TblMemberPackage mmbPckg = new TblMemberPackage();
			mmbPckg.NPackageID = nPackageID;
			DataTable table = mmbPckg.SelectOne();
			
			if (table == null || table.Rows.Count == 0)
				throw new Exception("The Data has been deleted from database.");

			mmbPckg.NStatusID = 2;

			mmbPckg.Update();
			nCreditPackageID = mmbPckg.NCreditPackageID.Value;

            //Check any package redeemed from this credit package
            ACMSDAL.TblMemberPackage memberPackage = new TblMemberPackage();
			string cmdText = "Select COUNT(*) from TblMemberPackage Where (nStatusID = 0 or nStatusID = 1) AND " + 
				" nCreditPackageID = @nCreditPackageID ";
 
			int nExist = (int) memberPackage.ExecuteScalar(cmdText, new string [] {"@nCreditPackageID"}, new object[] {nCreditPackageID});
            if (nExist==0)
            {                
                TblMemberCreditPackage creditPackage = new TblMemberCreditPackage();
                creditPackage.NCreditPackageID = nCreditPackageID;
                creditPackage.SelectOne();
                creditPackage.DtStartDate = SqlDateTime.Null;
                creditPackage.DtExpiryDate = SqlDateTime.Null;
                creditPackage.Update();
            }   
		}

        public void DeleteLastCreditPackageExtensionHistory(int nCreditPackageID, int last_nExtensionID, string CurrentMembershipID)
        {
            ACMSDAL.ConnectionProvider connProvider = new ConnectionProvider();

            TblMemberCreditPackage myMemberCreditPackage = new TblMemberCreditPackage();
            TblCreditPackageExtension myCreditPackageExtension = new TblCreditPackageExtension();

            myMemberCreditPackage.MainConnectionProvider = connProvider;
            myCreditPackageExtension.MainConnectionProvider = connProvider;

            connProvider.OpenConnection();
            connProvider.BeginTransaction("SaveCreditPackageExtension");

            myCreditPackageExtension.NCreditPackageID = nCreditPackageID;

            DataTable tblCreditPackageExtension = myCreditPackageExtension.SelectAllWnCreditPackageIDLogic();

            if (tblCreditPackageExtension == null)
            {
                throw new Exception("This extension row has been deleted by others");
            }
            else if (tblCreditPackageExtension.Rows.Count == 0)
            {
                throw new Exception("This extension row has been deleted by others");
            }

            if (tblCreditPackageExtension.Rows.Count > 0)
            {
                DataRow[] rowList = tblCreditPackageExtension.Select(" nStatusID = 0 AND nExtensionID > " + last_nExtensionID.ToString());

                if (rowList.Length > 0) // mean is not last package extension
                {
                    throw new Exception("Only the most recent package extension can be deleted.");
                }
            }

            DataRow[] deletedDataRowList = tblCreditPackageExtension.Select("nStatusID = 0 and nExtensionID = " + last_nExtensionID, "nExtensionID", DataViewRowState.CurrentRows);
            
            if (deletedDataRowList.Length == 0)
            {
                throw new Exception("This extension row has been deleted by others");
            }            

            DateTime dtOldExpiry = Convert.ToDateTime(deletedDataRowList[0]["dtOldExpiry"]);

            int nCreditPackageStatusID = -1;

            if (DateTime.Compare(dtOldExpiry, DateTime.Now) < 0)
            {
                nCreditPackageStatusID = 1;
            }            

            try
            {
                //Update Credit Package Extension set nStatusID = 1 => Deleted
                myCreditPackageExtension.MemberCreditPackage_ExtensionDelete(nCreditPackageID, last_nExtensionID);

                //Update Member Credit Package Expiry Date; nStatusID = 1 If Expired           
                myMemberCreditPackage.MemberCreditPackage_ExtensionUpdate(nCreditPackageID, nCreditPackageStatusID, dtOldExpiry, CurrentMembershipID);

                connProvider.CommitTransaction();
            }
            catch (Exception)
            {
                             connProvider.RollbackTransaction("SaveCreditPackageExtension");
                throw new Exception("Failed to Create New Extension");
            }
            finally
            {
                if (connProvider.CurrentTransaction != null)
                {
                    connProvider.CurrentTransaction.Dispose();
                }

                if (connProvider.DBConnection != null)
                {
                    if (connProvider.DBConnection.State == ConnectionState.Open)
                    {
                        connProvider.DBConnection.Close();
                    }
                }

                myMemberCreditPackage.MainConnactionIsCreatedLocal = true;
                myCreditPackageExtension.MainConnactionIsCreatedLocal = true;
            }
        }

		private decimal GetCreditUsageFromMemberPackage(int nCreditPackageID)
		{
			ACMSDAL.TblMemberPackage memberPackage = new TblMemberPackage();
			string cmdText = "Select Sum(mCreditPackageUsagePrice) from TblMemberPackage Where (nStatusID = 0 or nStatusID = 1) AND " + 
				" nCreditPackageID = @nCreditPackageID Group By nCreditPackageID";
 
			object obj = memberPackage.ExecuteScalar(cmdText, new string [] {"@nCreditPackageID"}, new object[] {nCreditPackageID});
			if (obj == null)
				return 0;
			else
			{
				if (obj is DataRow)
				{
					DataRow r = (DataRow) obj;
					decimal mCreditPackageUsagePrice = ACMS.Convert.ToDecimal(r["mCreditPackageUsagePrice"]);
					return mCreditPackageUsagePrice;
				}
				else
				{
					decimal mCreditPackageUsagePrice = ACMS.Convert.ToDecimal(obj);
					return mCreditPackageUsagePrice;
				}
			}
		}


		public void PrintCreditAccountExpiryReport(DataTable sourceTable, string memberName)
		{
			if (!sourceTable.Columns.Contains("MemberName"))
			{
				DataColumn colMemberName = new DataColumn("MemberName", typeof(string));
				sourceTable.Columns.Add(colMemberName);
			}
			sourceTable.Rows[0]["MemberName"] = memberName;

			ACMSLogic.Report.MemberCreditPackageExpiryReport report = new ACMSLogic.Report.MemberCreditPackageExpiryReport();
			report.DataSource=sourceTable;
			report.CreateDataBindings();
					report.DataSource=sourceTable;
			report.CreateDataBindings();
			report.Print();
		}

		public void Save(DataTable table)
		{
			myCreditPkg.SaveData(table);
		}

		public DataTable Table
		{
			get { return myDataTable; }
		}

        /*public DataTable NewExtensionHistory(int nCreditPackageID)
        {
            TblCreditPackageExtension CreditPackageExtension = new TblCreditPackageExtension();
            CreditPackageExtension.NExtensionID = -1;
            DataTable table = CreditPackageExtension.SelectOne();

            DataRow row = table.NewRow();
            row["nCreditPackageID"] = nCreditPackageID;
            row["nEmployeeID"] = ACMSLogic.User.EmployeeID;
            row["nStatusID"] = 0;
            row["strRemarks"] = "";
            table.Rows.Add(row);
            return table;
        }*/
    }
}
