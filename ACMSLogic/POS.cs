using System;
using System.Data;
using System.Configuration;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Windows.Forms;
using ACMSDAL;
using Microsoft.ApplicationBlocks.Data;

namespace ACMSLogic
{
	
	#region Class POSCommand
	
	//public delegate void GridBeginUpdateDelegate();
	//public delegate void GridEndUpdateDelegate();
	public class POSCommand
	{
		//dw decrale
		private SqlString _StrDeposit;
        private string connectionString;
        private SqlConnection connection;        
//		
		internal POSCommand()
		{
            connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"];
            connection = new SqlConnection(connectionString);
		}

		public static POSCommand Create()
		{
			return new POSCommand();
		}

		public POS NewPOS(int nCategoryID, int nEmployeeID, string strMembershipID,
            string strBranchCode, int nterminalID, int nShiftID, string strLocation, int nPackageID, int nGIRO)
		{

            POS pos = new POS(nCategoryID, nEmployeeID, strMembershipID, strBranchCode, nterminalID, nShiftID, strLocation, nPackageID, nGIRO);
		
			return pos;
			
		}

		private int GetOriginalCatID(ACMSDAL.ConnectionProvider connProvider, ACMSLogic.POS pos, ref DataTable tableRec)
		{
			TblReceipt strCatReceiptNo = new  TblReceipt();
			strCatReceiptNo.MainConnectionProvider = connProvider;
			tableRec = strCatReceiptNo.GetOriginalCatID(pos.StrParentReceiptNo);
			
			int orgCatID = 0;
			if (tableRec.Rows.Count > 0)
			{
				orgCatID = ACMS.Convert.ToInt32(tableRec.Rows[0]["nCategoryID"]);
			}
			return orgCatID;
		}
		
		private int GetLatestReceiptNo(ACMSDAL.ConnectionProvider connProvider, ACMSLogic.POS pos, ref DataTable branchReceiptNoTable)
		{
			TblBranchReceiptNo branchReceiptNo = new TblBranchReceiptNo();
			branchReceiptNo.MainConnectionProvider = connProvider;
			branchReceiptNoTable = branchReceiptNo.GetLatestReceiptNo(pos.StrBranchCode, pos.NTerminalID);
			
			int receiptNo = 0;
			if (branchReceiptNoTable.Rows.Count > 0)
			{
				receiptNo = ACMS.Convert.ToInt32(branchReceiptNoTable.Rows[0]["nReceiptNo"]);
			}
			return receiptNo;
		}

		private void SaveUpToDateReceiptNo(ACMSDAL.ConnectionProvider connProvider, DataTable branchReceiptNoTable)
		{
			TblBranchReceiptNo branchReceiptNo = new TblBranchReceiptNo();
			branchReceiptNo.MainConnectionProvider = connProvider;

			branchReceiptNo.SaveData(branchReceiptNoTable);
		}
		
		public void PrintReceipt(ACMSLogic.POS pos)
		{
			PrintReceipt(pos.StrReceiptNo);
		}

        //DEREK Instalment Plan Need to Update Receipt Here
		public void PrintReceipt(string receiptNo)
		{
			DataColumn colItemDiscountAmt = new DataColumn("DiscountAmt", typeof(decimal));
			DataColumn colBillDiscountAmt = new DataColumn("DiscountAmt", typeof(decimal));
			DataColumn colMemberName = new DataColumn("strMemberName", typeof(string));
			DataColumn colRewardPoint = new DataColumn("RewardPoint", typeof(decimal));
            DataColumn colGSTPaid = new DataColumn("GSTPaid", typeof(decimal));
            //DataColumn colOSAmt = new DataColumn("mOutstandingAmount", typeof(decimal));
			

			TblReceipt receipt = new TblReceipt();
			receipt.StrReceiptNo = receiptNo;
			DataTable tableReceipt = receipt.SelectOne();
			tableReceipt.TableName = "TblReceipt";
			tableReceipt.Columns.Add(colBillDiscountAmt);
			tableReceipt.Columns.Add(colMemberName);
			tableReceipt.Columns.Add(colRewardPoint);
            tableReceipt.Columns.Add(colGSTPaid);
           // tableReceipt.Columns.Add(colOSAmt);
			
			TblMember sqlMember = new TblMember();
			sqlMember.StrMembershipID = receipt.StrMembershipID;
			sqlMember.SelectOne();
			
			tableReceipt.Rows[0]["strMemberName"] = sqlMember.StrMemberName.IsNull ? "" : sqlMember.StrMemberName.Value.ToUpper();
			
			TblBranch sqlBranch = new TblBranch();
			sqlBranch.StrBranchCode = receipt.StrBranchCode == SqlString.Null ? "" : receipt.StrBranchCode.Value; 
			DataTable branchTable = sqlBranch.SelectOne();
			

			TblRewardsTransaction sqlRewTrans = new TblRewardsTransaction();
			decimal rewardpoint = sqlRewTrans.GetMemberLoyaltyPoint(receipt.StrMembershipID.Value);
			tableReceipt.Rows[0]["RewardPoint"] = System.Math.Round(rewardpoint);

			TblReceiptEntries receiptEntries = new TblReceiptEntries();
			receiptEntries.StrReceiptNo = receiptNo;
			DataTable tableReceiptEntries = receiptEntries.SelectAllWstrReceiptNoLogic();
			tableReceiptEntries.TableName = "TblReceiptEntries";
			tableReceiptEntries.Columns.Add(colItemDiscountAmt);
			
			TblReceiptFreebie freebie = new TblReceiptFreebie();
			freebie.StrReceiptNo = receiptNo;
			DataTable tableReceiptFreebie = freebie.SelectReceiptFreebie();
			tableReceiptFreebie.TableName = "TblReceiptFreebie";

			TblMemberPackage FreePackage = new TblMemberPackage();
			FreePackage.StrReceiptNo = receiptNo;
			DataTable tableFreePackage = FreePackage.GetFreePackage(receiptNo);
			tableFreePackage.TableName = "TblFreePackage";

            TblMemberPackage ConvertedPackage = new TblMemberPackage();
            ConvertedPackage.StrReceiptNo = receiptNo;            
            DataTable tableConvertedPackage = ConvertedPackage.GetConvertedPackage(receiptNo);
            tableConvertedPackage.TableName = "TblConvertedPackage";

            TblPaymentPlan myPaymentPlan = new TblPaymentPlan();
            DataTable tablePaymentPlan = myPaymentPlan.GetInhouseIPPOSByReceiptNo(receiptNo);
            tablePaymentPlan.TableName = "TblPaymentPlan";

            DataTable tableDeposit = myPaymentPlan.GetInhouseIPPReceiptDeposit(receiptNo);
            tableDeposit.TableName = "TblReceiptDeposit";

//			TblProduct Product = new TblProduct();
//		//	Product.StrProductCode = tableReceiptFreebie.Rows[0]["strItemCode"].ToString();
//			DataTable tableProduct = Product.SelectAll();
//			tableProduct.TableName = "TblProductName";
		
			decimal nettAmountB4Discount = 0;
			decimal discoutnAmt =0;
            decimal depositAmt = 0;

            if (tableDeposit.Rows.Count > 0)
            {
                depositAmt = Convert.ToDecimal(tableDeposit.Rows[0]["TotalDeposit"]);
            }

			foreach (DataRow r in tableReceiptEntries.Rows)
			{
				int qty = ACMS.Convert.ToInt32(r["nQuantity"]);
				decimal unitPrice = ACMS.Convert.ToDecimal(r["mUnitPrice"]);
				decimal currSubtotal = ACMS.Convert.ToDecimal(r["mSubTotal"]);
				discoutnAmt = (unitPrice * qty) - currSubtotal;
				r["DiscountAmt"] = decimal.Round(discoutnAmt, 2);

				nettAmountB4Discount += currSubtotal;
			}

			//Sub Total
			DataColumn colSubTotal = new DataColumn("mSubTotal", typeof(decimal));
			tableReceipt.Columns.Add(colSubTotal);
			tableReceipt.Rows[0]["mSubTotal"] = nettAmountB4Discount;
	
			 decimal nettAmountAfterDiscount = ACMS.Convert.ToDecimal(tableReceipt.Rows[0]["mNettAmount"]);

			if (tableReceipt.Rows[0]["strDiscountCode"].ToString().Length > 0 &&
				tableReceipt.Rows[0]["strDiscountCode"] != DBNull.Value)
			{
				tableReceipt.Rows[0]["DiscountAmt"] = nettAmountB4Discount - (nettAmountAfterDiscount + depositAmt);
			}

			TblReceiptPayment receiptPayment = new TblReceiptPayment();
			receiptPayment.StrReceiptNo = receiptNo;
			DataTable tableReceiptPayment = receiptPayment.SelectAllWstrReceiptNoLogic();
			tableReceiptPayment.TableName = "TblReceiptPayment";

			TblCompany comp = new TblCompany();

			DataTable compTable = comp.SelectAll();

			int myTaxID = ACMS.Convert.ToInt32(compTable.Rows[0]["NTaxID"]);
			TblTax tax = new TblTax();
			tax.NTaxID = myTaxID;
			tax.SelectOne();
            decimal myGSTRate = tax.DTaxRate.IsNull ? 0 : (decimal)tax.DTaxRate.Value;
			
			decimal GSTAmtPaid=0;
			decimal GSTRate1=myGSTRate;//0.05M;
			decimal GSTRate2=myGSTRate+1;// 1.05M;

			foreach (DataRow p in tableReceiptPayment.Rows)
			{
				GSTAmtPaid=GSTAmtPaid+ACMS.Convert.ToDecimal(p[3])* GSTRate1 /GSTRate2; 
			}
            if (receipt.NCategoryID.ToString() != "38")
            {
                tableReceipt.Rows[0]["GSTPaid"] = decimal.Round(GSTAmtPaid, 2);
            }
            else
            {
                tableReceipt.Rows[0]["GSTPaid"] = decimal.Round(0, 2);
            }

			DataSet newDS = new DataSet("Receipt");
			newDS.Tables.Add(tableReceipt);

			newDS.Tables.Add(tableReceiptEntries);
			newDS.Tables.Add(tableReceiptPayment);
			newDS.Tables.Add(branchTable);
//			newDS.Tables.Add(tableProduct);
			newDS.Tables.Add(tableReceiptFreebie);
			newDS.Tables.Add(tableFreePackage);
            newDS.Tables.Add(tableConvertedPackage);
            newDS.Tables.Add(tablePaymentPlan);
            newDS.Tables.Add(tableDeposit);

			DataRelation relation1 = new DataRelation("Receipt_ReceiptEntries_Relation", newDS.Tables["TblReceipt"].Columns["strReceiptNo"],
				newDS.Tables["TblReceiptEntries"].Columns["strReceiptNo"], false);
			
			DataRelation relation2 = new DataRelation("Receipt_ReceiptPayment_Relation", newDS.Tables["TblReceipt"].Columns["strReceiptNo"],
				newDS.Tables["TblReceiptPayment"].Columns["strReceiptNo"], false);

			DataRelation relation3 = new DataRelation("Receipt_ReceiptFreebie_Relation", newDS.Tables["TblReceipt"].Columns["strReceiptNo"],
				newDS.Tables["TblReceiptFreebie"].Columns["strReceiptNo"], false);

			DataRelation relation4 = new DataRelation("Receipt_FreePackage_Relation", newDS.Tables["TblReceipt"].Columns["strReceiptNo"],
				newDS.Tables["TblFreePackage"].Columns["strReceiptNo"], false);

            DataRelation relation5 = new DataRelation("Receipt_ConvertedPackage_Relation", newDS.Tables["TblReceipt"].Columns["strReceiptNo"],
                newDS.Tables["TblConvertedPackage"].Columns["strReceiptNo"], false);

            DataRelation relation6 = new DataRelation("Receipt_PaymentPlan_Relation", newDS.Tables["TblReceipt"].Columns["strReceiptNo"],
                newDS.Tables["TblPaymentPlan"].Columns["strReceiptNo"], false);

            DataRelation relation7 = new DataRelation("Receipt_Deposit_Relation", newDS.Tables["TblReceipt"].Columns["strReceiptNo"],
                newDS.Tables["TblReceiptDeposit"].Columns["strReceiptNo"], false);

			newDS.Relations.Add(relation1);
			newDS.Relations.Add(relation2);
			newDS.Relations.Add(relation3);
			newDS.Relations.Add(relation4);
            newDS.Relations.Add(relation5);
            newDS.Relations.Add(relation6);
            newDS.Relations.Add(relation7);

			//display GST %
			DataColumn colGstTax = new DataColumn("GstTax", typeof(int));
			tableReceipt.Columns.Add(colGstTax);
			tableReceipt.Rows[0]["GstTax"] = myGSTRate * 100;

			ACMSLogic.Report.Receipt receiptReport = new ACMSLogic.Report.Receipt();

			receiptReport.DataSource = newDS;

//			if (ACMS.Convert.ToDecimal(tableReceipt.Rows[0]["DiscountAmt"])==0)
//			{
//				receiptReport.HideFields(false);
//            }
//			else
//			{
//				receiptReport.HideFields(true);
//			}

           // receiptReport.ShowDesignerDialog();
			receiptReport.Print();
			
		}

		public bool SavePOS(ACMSLogic.POS pos)
		{
			ACMSDAL.ConnectionProvider connProvider = new ConnectionProvider();
            //ACMSDAL.ConnectionProvider connProvider1 = new ConnectionProvider();
			
			try
			{
				DataTable branchReceiptNoTable = new DataTable();
				int latestReceiptNo = GetLatestReceiptNo(connProvider, pos, ref branchReceiptNoTable) + 1;
				string receiptNo = pos.StrBranchCode.ToString().Trim() + pos.NTerminalID.ToString().Trim() + latestReceiptNo.ToString().Trim();

                pos.StrReceiptNo = receiptNo;

                //Derek Instalment Plan Need to Add PaymentPlan Table Here
                //Get pos.NCategoryID here to determine if the item is Pay O/S  
                //Here Can get the new Receipt No Value
				//3 Main table that always need to update

				TblReceipt receipt = new TblReceipt();
				TblReceiptEntries receiptEntries = new TblReceiptEntries();
				TblReceiptPayment receiptPayment = new TblReceiptPayment();
                TblPaymentPlan myPaymentPlan = new TblPaymentPlan();

				receipt.MainConnectionProvider = connProvider;
				receiptEntries.MainConnectionProvider = connProvider;
				receiptPayment.MainConnectionProvider = connProvider;
                myPaymentPlan.MainConnectionProvider = connProvider;

				connProvider.OpenConnection();
				connProvider.BeginTransaction("SaveReceipt");

				DataTable receiptTable = pos.ReceiptMasterTable.Copy();
				DataTable receiptEntriesTable = pos.ReceiptItemsTable.Copy();
				DataTable receiptPaymentTable = pos.ReceiptPaymentTable.Copy();
				DataTable freeMemberPackageTable = receipt.FillSchema("Select * From tblMemberPackage"); // use to store the free member package.
                DataTable freeMemberCreditPackageTable = receipt.FillSchema("Select * From tblMemberCreditPackage");

                if (pos.PaymentPlanTable != null && pos.NCategoryID != 0)
                {
                    DataTable paymentPlanTable = pos.PaymentPlanTable.Copy();

                    if (paymentPlanTable != null && paymentPlanTable.Rows.Count > 0)
                    {                        
                        foreach (DataRow r in paymentPlanTable.Rows)
                        {
                            r["strReceiptNo"] = pos.StrReceiptNo;

                            if (r["nInstalmentNo"].ToString() == "1")
                            {
                                r["strPaymentReceiptNo"] = pos.StrReceiptNo;

                                myPaymentPlan.IPPPrimaryEntry(r["strReceiptNo"].ToString(), Convert.ToInt32(r["nInstalmentNo"]),
                                                                r["strPaymentReceiptNo"].ToString(), Convert.ToDecimal(r["mPaymentPlanAmt"]),
                                                                Convert.ToDecimal(r["mPaidAmount"]), Convert.ToDecimal(r["mAdjustedPaymentPlanAmt"]),
                                                                Convert.ToDecimal(r["mOutstandingAmt"]), Convert.ToDateTime(r["dtPaymentDate"]),
                                                                Convert.ToDateTime(r["dtDueDate"]), Convert.ToDateTime(r["dtFinalDueDate"]),
                                                                Convert.ToInt32(r["nPaymentPlanID"]));

                            }
                            else
                            {
                                myPaymentPlan.IPPSubsequentEntry(r["strReceiptNo"].ToString(), Convert.ToInt32(r["nInstalmentNo"]),
                                                                    Convert.ToDecimal(r["mPaymentPlanAmt"]), Convert.ToDecimal(r["mPaidAmount"]),
                                                                    Convert.ToDecimal(r["mAdjustedPaymentPlanAmt"]), Convert.ToDecimal(r["mOutstandingAmt"]),
                                                                    Convert.ToDateTime(r["dtDueDate"]), Convert.ToDateTime(r["dtFinalDueDate"]),
                                                                    Convert.ToInt32(r["nPaymentPlanID"]));
                            }
                        }                    
                        paymentPlanTable.AcceptChanges();
                    }
                    pos.PaymentPlanTable.AcceptChanges();

                } 
                else if (pos.PaymentPlanTable != null && pos.NCategoryID == 0)
                {
                    DataTable paymentPlanTable = pos.PaymentPlanTable.Copy();

                    if (paymentPlanTable != null && paymentPlanTable.Rows.Count > 0)
                    {
                        foreach (DataRow r in paymentPlanTable.Rows)
                        {
                            if (r["lastestUpdate"].ToString() == "1")
                            {
                                r["strPaymentReceiptNo"] = pos.StrReceiptNo;

                                myPaymentPlan.IPPPrimaryUpdate(Convert.ToInt32(r["nPaymentPlanID"]), r["strReceiptNo"].ToString(),
                                                                Convert.ToInt32(r["nInstalmentNo"]), r["strPaymentReceiptNo"].ToString(),
                                                                Convert.ToDecimal(r["mPaidAmount"]), Convert.ToDecimal(r["mAdjustedPaymentPlanAmt"]),
                                                                Convert.ToDecimal(r["mOutstandingAmt"]), Convert.ToDateTime(r["dtPaymentDate"]));


                            }
                            else
                            {
                                myPaymentPlan.IPPSubsequentUpdate(Convert.ToInt32(r["nPaymentPlanID"]), r["strReceiptNo"].ToString(),
                                                                    Convert.ToInt32(r["nInstalmentNo"]), Convert.ToDecimal(r["mPaidAmount"]),
                                                                    Convert.ToDecimal(r["mAdjustedPaymentPlanAmt"]), Convert.ToDecimal(r["mOutstandingAmt"]));
                            }
                        }

                        //paymentPlanTable.AcceptChanges();
                    }
                    pos.PaymentPlanTable.AcceptChanges();
                }

				receipt.SaveData(receiptTable);
				receiptEntries.SaveData(receiptEntriesTable);
				receiptPayment.SaveData(receiptPaymentTable);

				receiptEntries.StrReceiptNo = pos.StrReceiptNo;
				DataTable savedReceiptEntriesTable = receiptEntries.SelectAllWstrReceiptNoLogic();

				pos.ReceiptMasterTable.AcceptChanges();

                if (pos.StrFreebieCode.HasValue && pos.StrFreebieCode.ToString() != "")
                {
                    //Update Bill Freebie here
                    if (pos.ReceiptFreebieTable.Rows.Count > 0)
                    {
                        TblReceiptFreebie receiptFreebie = new TblReceiptFreebie();
                        receiptFreebie.MainConnectionProvider = connProvider;
                        DataTable receiptFreebieTable = pos.ReceiptFreebieTable.Copy();

                        // Save Bill Receipt Freebie
                        receiptFreebie.SaveData(receiptFreebieTable);

                        //TblProductInventory proInven = new TblProductInventory();
                        //proInven.MainConnectionProvider = connProvider;

                        //// deduct stock
                        //foreach (DataRow r in receiptFreebieTable.Rows)
                        //{
                        //    proInven.IncreaseQuantity(r["strItemCode"].ToString(), pos.StrBranchCode, -1);
                        //}
                    }
                    if (pos.ReceiptPackageTable.Rows.Count > 0)
                    {
                        // update package

                        foreach (DataRow r in pos.ReceiptPackageTable.Rows)
                        {
                            TblCreditPackage p = new TblCreditPackage();
                            p.StrCreditPackageCode = r["strPackageCode"].ToString();
                            p.SelectOne();

                            if (p.StrDescription.ToString() != "Null")
                            {
                                DataRow rowToAdd = freeMemberCreditPackageTable.NewRow();

                                ACMSLogic.MemberPackage.InitMemberCreditPackageRowInPOS(rowToAdd, pos.StrReceiptNo, pos.StrMembershipID,
                                    r["strPackageCode"].ToString(), r["strPromotionCode"].ToString(), true);

                                // Add to freeMemberPackageTable and will save 
                                freeMemberCreditPackageTable.Rows.Add(rowToAdd);
                            }
                            else
                            {
                                DataRow rowToAdd = freeMemberPackageTable.NewRow();

                                ACMSLogic.MemberPackage.InitMemberPackageRowInPOS(rowToAdd, pos.StrReceiptNo, pos.StrMembershipID,
                                    r["strPackageCode"].ToString(), r["strPromotionCode"].ToString(), true);

                                // Add to freeMemberPackageTable and will save 
                                freeMemberPackageTable.Rows.Add(rowToAdd);
                            }                            
                        }
                    }
                    //else
                    //{
                    //    throw new Exception("Bill Freebie have no free any product or package although the strFreebieCode is not null");
                    //}
                }

                if (pos.ReceiptItemsFreebiePackageTable.Rows.Count > 0)
                {
                    foreach (DataRow r in pos.ReceiptItemsFreebiePackageTable.Rows)
                    {
                        TblCreditPackage p = new TblCreditPackage();
                        p.StrCreditPackageCode = r["strPackageCode"].ToString();
                        p.SelectOne();

                        if (p.StrDescription.ToString() != "Null")
                        {
                            DataRow rowToAdd = freeMemberCreditPackageTable.NewRow();
                          
                            ACMSLogic.MemberPackage.InitMemberCreditPackageRowInPOS(rowToAdd, pos.StrReceiptNo, pos.StrMembershipID,
                                r["strPackageCode"].ToString(), r["strPromotionCode"].ToString(), true);
                          
                            // Add to freeMemberPackageTable and will save 
                            freeMemberCreditPackageTable.Rows.Add(rowToAdd);
                        }
                        else
                        {
                            DataRow rowToAdd = freeMemberPackageTable.NewRow();
                            // Kean Yiap
                            if (pos.NCategoryID == 34)
                            {
                                MemberPackage.InitMemberPackageRowInPOS(rowToAdd, pos.StrReceiptNo, pos.StrMembershipID, r["strPackageCode"].ToString(), "",
                                    true, -1, pos.dtPackageStart, pos.NProrateDays);
                            }
                            else
                            {
                                ACMSLogic.MemberPackage.InitMemberPackageRowInPOS(rowToAdd, pos.StrReceiptNo, pos.StrMembershipID,
                                    r["strPackageCode"].ToString(), r["strPromotionCode"].ToString(), true);
                            }
                            // Add to freeMemberPackageTable and will save 
                            freeMemberPackageTable.Rows.Add(rowToAdd);
                        }
                    }
                }

                if (pos.ReceiptItemsFreebieProductTable.Rows.Count > 0)
                {
                    //					Update product
                    TblReceiptFreebie receiptFreebie = new TblReceiptFreebie();
                    receiptFreebie.MainConnectionProvider = connProvider;
                    DataTable receiptItemsFreebieProductTable = pos.ReceiptFreebieTable.Clone(); // i have to use this structure bcoz i wan to save to this table;

                    foreach (DataRow r in pos.ReceiptItemsFreebieProductTable.Rows)
                    {
                        DataRow rowToAdd = receiptItemsFreebieProductTable.NewRow();
                        rowToAdd["strReceiptNo"] = pos.StrReceiptNo;
                        rowToAdd["strItemCode"] = r["strProductCode"];
                        rowToAdd["strPromotionCode"] = r["strPromotionCode"];

                        DataRow[] tempRows = savedReceiptEntriesTable.Select("nTempEntryID = " + r["nEntryID"].ToString(),
                            "", DataViewRowState.CurrentRows);

                        if (tempRows.Length > 0)
                            rowToAdd["nEntryID"] = tempRows[0]["nEntryID"];

                        receiptItemsFreebieProductTable.Rows.Add(rowToAdd);
                    }

                    receiptFreebie.SaveData(receiptItemsFreebieProductTable);

                    //TblProductInventory proInven = new TblProductInventory();
                    //proInven.MainConnectionProvider = connProvider;

                    //foreach (DataRow r in receiptItemsFreebieProductTable.Rows)
                    //{
                    //    proInven.IncreaseQuantity(r["strItemCode"].ToString(), pos.StrBranchCode, -1);
                    //}
                }

                if (freeMemberPackageTable.Rows.Count > 0)
                {
                    // update the member package to database
                    TblMemberPackage memberPackage = new TblMemberPackage();
                    memberPackage.MainConnectionProvider = connProvider;
                    memberPackage.SaveData(freeMemberPackageTable);
                }

                if (freeMemberCreditPackageTable.Rows.Count > 0)
                {
                    // update the member package to database
                    TblMemberCreditPackage memberPackage = new TblMemberCreditPackage();
                    memberPackage.MainConnectionProvider = connProvider;
                    memberPackage.SaveData(freeMemberCreditPackageTable);
                }

//part 2
                DeleteUselessIPP(connProvider, pos);
                UpdateRegistrationFee(connProvider, pos);
                UpdateOldPackSetDeactivate(connProvider, pos); //Update when upgrade                
                PostToMemberCreditPackage(connProvider, pos);
                PostToMemberPackage(connProvider, pos);
                UpdateUsedCashVoucher(connProvider, pos);

                int ParentCategoryID = pos.NCategoryID;

                if (pos.NCategoryID == 10)
                {
                    ParentCategoryID = UpgradePackage(connProvider, pos);
                    if (ParentCategoryID == 10)
                    {
                        ParentCategoryID = UpgradeCreditPackage(connProvider, pos);
                    }
                }

                TopUpCreditPackage(connProvider, pos);
                TopUpSingleTreatmentTransaction(connProvider, pos);
                MakeDeposit(connProvider, pos);
                                
                CashVoucherTransaction(connProvider, pos);
                LockerTransaction(connProvider, pos);
                ForgetCardTransaction(connProvider, pos);
                ReplaceMembershipCardTransaction(connProvider, pos);
                //MineralWaterTransaction(connProvider, pos);
                TblRewards rewardcode = new TblRewards();
                ACMSDAL.TblCategory category = new ACMSDAL.TblCategory();
                category.NCategoryID = pos.NCategoryID;
                category.SelectOne();
                int SalesCategory = ACMS.Convert.ToInt32(category.NSalesCategoryID);

                //Derek Instalment Plan - Here it assigned the Category to the Pay O/S Receipt Record
                if (pos.NCategoryID == 0)
                {            
                    ParentCategoryID = PayOutstanding(connProvider, pos);
                    pos.StrRewardsCode = rewardcode.SelectRewards(ParentCategoryID, pos.StrBranchCode);
                }
                else
                    pos.StrRewardsCode = rewardcode.SelectRewards(pos.NCategoryID, pos.StrBranchCode);

                if (pos.StrRewardsCode.HasValue && pos.StrRewardsCode.ToString() != "" && pos.StrRewardsCode.ToString() != "Null")
                {
                    TblRewards rewards = new TblRewards();
                    rewards.StrRewardsCode = pos.StrRewardsCode.ToString();
                    rewards.SelectOne();

                    double dRewardPoint = 0;

                    double dRewardPercent = (rewards.DRewardsPercent.IsNull ? 0 : rewards.DRewardsPercent.Value);
                    double dRewardValue = (rewards.DRewardsValue.IsNull ? 0 : rewards.DRewardsValue.Value);
                  
                    //jackie 23 others give 50% GIRO
                    //if (ParentCategoryID == 23 && pos.MNettAmount > 60)//pos.MNettAmount
                    //{
                    //    dRewardPercent = 50;

                    //}

                    if (dRewardPercent > 0 && dRewardValue == 0)
                    {
                        decimal mnettTotal = 0;

                        if (pos.MOutstandingAmount > 0)
                        {
                            mnettTotal = pos.MNettAmount - (pos.MOutstandingAmount - pos.MGSTAmount);
                        }
                        else
                        {
                            mnettTotal = pos.MNettAmount;
                        }

                        dRewardPoint = ((double)mnettTotal) * dRewardPercent / 100;
                    }
                    else
                    {
                        if (pos.NCategoryID == 0)
                        {
                            dRewardPoint = dRewardValue;
                        }
                    }
                    if (pos.NThisMonthBirthday == 1)
                    {
                        DialogResult result1 = MessageBox.Show("Member is having birthday this months. Do you want to give double point?", "Warning",
                        MessageBoxButtons.YesNo);

                        if (result1 == DialogResult.Yes)
                            dRewardPoint *= 2;
                    }
                                    
                    TblRewardsTransaction rewardTran = new TblRewardsTransaction();
                    rewardTran.MainConnectionProvider = connProvider;
                    if (pos.NCategoryID == 20)
                    {
                        rewardTran.StrMembershipID = pos.StrNewMembershipID;
                    }
                    else
                    {
                        rewardTran.StrMembershipID = pos.StrMembershipID;
                    }
                    rewardTran.DtDate = pos.DtDate;
                    rewardTran.NTypeID = 1;
                    rewardTran.NEmployeeID = pos.NCashierID;
                    rewardTran.DRewardsPoints = dRewardPoint;
                    rewardTran.StrReferenceNo = pos.StrReceiptNo;
                    if (dRewardPoint > 0) // rewards point > 0 then insert records //3004
                    {
                        rewardTran.Insert();
                    }
                }

                if (pos.StrRewardsCode.ToString() == "Null") pos.StrRewardsCode = "";

                DataTable QtyTable = receiptEntries.Get_StrCodeReceiptNo(pos.StrReceiptNo);
                //check is the receipt fully paid
                string Nett = pos.MNettAmount.ToString();
                string Outstanding = pos.MOutstandingAmount.ToString();

                //if (pos.MOutstandingAmount == 0 && (pos.NCategoryID == 11 || pos.NCategoryID == 12))
                //    PostToStock(connProvider, QtyTable, pos);


                receiptTable = pos.ReceiptMasterTable.Copy();
                int PosCategory = ACMS.Convert.ToInt32(receiptTable.Rows[0]["nCategoryID"]);
                if (PosCategory == 24)
                {
                    receiptTable.Rows[0]["fDeposit"] = true;
                    receipt.SaveData(receiptTable);
                }

                if (pos.StrBillReferenceNo != "")
                {
                    receiptTable.Rows[0]["strBillReferenceNo"] = pos.StrBillReferenceNo;
                    receipt.SaveData(receiptTable);
                }

                if (pos.NCategoryID == 0 || pos.NCategoryID == 10)
                {
                    receipt.StrReceiptNo = pos.StrReceiptNo;
                    receipt.SelectOne();
                    receipt.MOutstandingAmount = Convert.ToDecimal(pos.MOutstandingAmount);
                    receipt.NCategoryID = ParentCategoryID;
                    receipt.Update();
                    //TblReceipt receipt3 = new TblReceipt();
                    //receipt3.StrReceiptNo = pos.StrReceiptNo;
                    //receipt3.SelectOne();
                    //receipt3.MOutstandingAmount = Convert.ToDecimal(pos.MOutstandingAmount);
                    //receipt3.NCategoryID = ParentCategoryID;
                    //receipt3.Update();
                }

                if (pos.StrDeposit != "")
                {
                    receipt.StrReceiptNo = pos.StrDeposit;
                    DataTable tblDeposit = receipt.SelectOne();
                    if (tblDeposit.Rows.Count > 0)
                    {
                        receipt.FDeposit = false;
                        receipt.Update();

                    }
                    else
                    {
                        TblMemberPackage ConvertedPackage = new TblMemberPackage();
                        ConvertedPackage.NPackageID = ACMS.Convert.ToSqlInt32(pos.StrDeposit);
                        ConvertedPackage.NStatusID = 1;
                        ConvertedPackage.UpdateConvertedPackageStatus();
                    }
                }

                if (pos.ReceiptItemsTable.Select("", "", DataViewRowState.ModifiedCurrent).Length > 0)
                {
                    receiptEntriesTable = pos.ReceiptItemsTable.Copy();
                    receipt.SaveData(receiptEntriesTable);
                }
                //1503
                branchReceiptNoTable.Rows[0]["nReceiptNo"] = latestReceiptNo;

                SaveUpToDateReceiptNo(connProvider, branchReceiptNoTable);
                connProvider.CommitTransaction();


                if (pos.StrDeposit != "")
                {
                    TblReceipt receipt2 = new TblReceipt();
                    receipt2.StrReceiptNo = pos.StrDeposit;
                    receipt2.SelectOne();
                    receipt2.StrChildReceiptNo = receiptNo;
                    receipt2.Update();
                }
                return true;

            }
			catch (Exception ex)
			{
				throw ex;
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
			}
		}
     
	
		private void TopUpSingleTreatmentTransaction(ACMSDAL.ConnectionProvider connProvider, ACMSLogic.POS pos)
		{
			if (pos.NCategoryID == 19)
			{
				TblServiceSession sqlserviceSession = new TblServiceSession();
				sqlserviceSession.MainConnectionProvider = connProvider;

				string strServiceCode = "";
				int nPackageID = -1;

				foreach (DataRow r in pos.ReceiptItemsTable.Rows)
				{
					strServiceCode = r["strCode"].ToString();
					nPackageID = ACMS.Convert.ToInt32(r["strReferenceNo"]);	
					
					sqlserviceSession.DtDate = DateTime.Today.Date;
					sqlserviceSession.DtStartTime = DateTime.Now;
					sqlserviceSession.DtEndTime = DateTime.Now.AddMinutes(15);
					sqlserviceSession.DtLastEditDate = DateTime.Now;
					sqlserviceSession.NEmployeeID = User.EmployeeID;
					sqlserviceSession.NPackageID = nPackageID;
					sqlserviceSession.NStatusID = 5;
					sqlserviceSession.StrBranchCode = User.BranchCode;
					sqlserviceSession.StrMembershipID = pos.StrMembershipID;
					sqlserviceSession.StrServiceCode = strServiceCode;
					sqlserviceSession.Insert();
					r["strReferenceNo"] = sqlserviceSession.NSessionID;
				}
			}
		}

		private void DeleteUselessIPP(ACMSDAL.ConnectionProvider connProvider, ACMSLogic.POS pos)
		{
			DataRow[] rowListThatHaveIPP = pos.ReceiptPaymentTable.Select("nIPPID is not null", "", DataViewRowState.CurrentRows);
			
			if (rowListThatHaveIPP.Length > 0)
			{
				TblIPP sqlIPP = new TblIPP();
				sqlIPP.MainConnectionProvider = connProvider;

				DataTable table = sqlIPP.GetIPP(pos.StrMembershipID, pos.StrBranchCode);

				foreach (DataRow r in rowListThatHaveIPP)
				{
					int nIPPID = ACMS.Convert.ToInt32(r["nIPPID"]);

					DataRow[] rowToUpdate = table.Select("nIPPID = " + nIPPID.ToString());
					if (rowToUpdate.Length > 0)
					{
						rowToUpdate[0]["nIPPStatus"] = 0;
					}
				}

				DataRow[] rowListToDelete = table.Select("nIPPStatus = 3", "", DataViewRowState.CurrentRows);

				foreach (DataRow deleteRow in rowListToDelete)
				{
					deleteRow.Delete();
				}

				sqlIPP.SaveData(table);
			}
		}
        private void UpdateUsedCashVoucher(ACMSDAL.ConnectionProvider connProvider, ACMSLogic.POS pos)
        {
            if (Convert.ToInt16(pos.ReceiptPaymentTable.Compute("COUNT(nPaymentID)", "strPaymentCode='CASHVOUCHER'")) > 0)
            {
                foreach (DataRow dr in pos.ReceiptPaymentTable.Rows)
                {
                    if (dr["strPaymentCode"].ToString() == "CASHVOUCHER")
                    {
                        TblCashVoucher sqlCV = new TblCashVoucher();
                        sqlCV.MainConnectionProvider = connProvider;
                        sqlCV.StrSN = dr["strReferenceNo"].ToString();
                        DataTable table = sqlCV.SelectOne();
                        sqlCV.NStatusID = 3;
                        sqlCV.StrRedeemedByID = pos.StrMembershipID;
                        sqlCV.DtRedeemedDate = DateTime.Now;
                        sqlCV.StrRedeemedBranch = pos.StrBranchCode;
                        sqlCV.Update();
                        sqlCV.SaveData(table);
                    }
                }
            }
        }
        private void UpdateOldPackSetDeactivate(ACMSDAL.ConnectionProvider connProvider, ACMSLogic.POS pos)
        {
            try
            {
                string strFreePackageCode, strReceiptNo;
                foreach (DataRow dr in pos.WantToUpgradeMemberPackageTable.Rows)
                {
                    string strRemarks;

                    if (Convert.ToInt32(dr["nCategoryID"]) == 7 || Convert.ToInt32(dr["nCategoryID"]) == 36 || Convert.ToInt32(dr["nCategoryID"]) == 37)
                    {
                        TblMemberCreditPackage mp = new TblMemberCreditPackage();
                        mp.MainConnectionProvider = connProvider;

                        DataTable table = mp.LoadData("Select * from tblMemberCreditPackage Where nCreditPackageID = @nPackageID",
                            new string[] { "@nPackageID" }, new object[] { dr["nPackageID"] });

                        strReceiptNo = table.Rows[0]["strReceiptNo"].ToString();
                        table.Rows[0]["nStatusID"] = 3;
                        table.Rows[0]["strUpgradeTo"] = pos.StrReceiptNo;
                        strRemarks = "Convert to: " + pos.StrReceiptNo;
                        table.Rows[0]["strRemarks"] = strRemarks;
                        mp.SaveData(table);
                    }
                    else if (Convert.ToInt32(dr["nCategoryID"]) == 8 || Convert.ToInt32(dr["nCategoryID"]) == 9)
                    {
                        DataSet dsCombo = new DataSet();

                        string strSQL = "select pge.*,re.strReceiptNo from tblReceiptEntries re, tblPackageGroupEntries pge where nEntryID =" + dr["nPackageID"] + " and re.strCode=pge.strPackageGroupCode";
                        SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA", dsCombo, new string[] { "Table" }, new SqlParameter("@strSQL", strSQL));

                        foreach (DataRow drCombo in dsCombo.Tables["Table"].Rows)
                        {
                            for (int i = 1; i <= Convert.ToInt32(drCombo["nQuantity"]); i++)
                            {
                                TblMemberPackage mp = new TblMemberPackage();
                                mp.MainConnectionProvider = connProvider;

                                DataTable table = mp.LoadData("Select top 1 mp.* from tblMemberPackage mp Where strPackageCode = @nPackageID and strReceiptNo=@strReceiptNo and nStatusID=0 and nPackageID not in (SELECT nPackageID FROM [dbo].[tblServiceSession] s WHERE nStatusID = 5 and mp.nPackageID = S.nPackageID) ",
                                new string[] { "@nPackageID", "@strReceiptNo" }, new object[] { drCombo["strPackageCode"], drCombo["strReceiptNo"] });

                                strReceiptNo = drCombo["strReceiptNo"].ToString();
                                table.Rows[0]["nStatusID"] = 3;
                                table.Rows[0]["strUpgradeTo"] = pos.StrReceiptNo;
                                strRemarks = "Convert to: " + pos.StrReceiptNo;
                                table.Rows[0]["strRemarks"] = strRemarks;
                                mp.SaveData(table);

                            }
                        }
                    }
                    else
                    {
                        TblMemberPackage mp = new TblMemberPackage();
                        mp.MainConnectionProvider = connProvider;

                        DataTable table = mp.LoadData("Select * from tblMemberPackage Where nPackageID = @nPackageID",
                            new string[] { "@nPackageID" }, new object[] { dr["nPackageID"] });

                        strFreePackageCode = dr["strFreePkgCode"].ToString();
                        strReceiptNo = table.Rows[0]["strReceiptNo"].ToString();
                        table.Rows[0]["nStatusID"] = 3;
                        table.Rows[0]["strUpgradeTo"] = pos.StrReceiptNo;
                        strRemarks = "Convert to: " + pos.StrReceiptNo;
                        table.Rows[0]["strRemarks"] = strRemarks;
                        mp.SaveData(table);

                        DataTable freePkgTable = mp.LoadData("select * from tblMemberPackage where strReceiptNo=@strReceiptNo and strPackageCode =@strFreePackageCode ",
                            new string[] { "@strReceiptNo", "@strFreePackageCode" }, new object[] { strReceiptNo, strFreePackageCode });

                        if (freePkgTable.Rows.Count > 0)
                        {
                            freePkgTable.Rows[0]["nStatusID"] = 3;
                            freePkgTable.Rows[0]["strUpgradeTo"] = pos.StrReceiptNo;
                            freePkgTable.Rows[0]["strRemarks"] = strRemarks;
                            mp.SaveData(freePkgTable);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                string strError = ex.Message;
            }
        }

		private void UpdateRegistrationFee(ACMSDAL.ConnectionProvider connProvider, ACMSLogic.POS pos)
		{
			if (pos.ReceiptItemsTable.Select("strCode = 'Reg'", "", DataViewRowState.CurrentRows).Length == 1)
			{
				TblMember member = new TblMember();
				member.MainConnectionProvider = connProvider;
                TblMemberPackage mp = new TblMemberPackage();
                
				DataTable table  = member.LoadData("Select * from tblMember Where strMembershipID = @strMembershipID", 
					new string[] {"@strMembershipID"}, new object[]{pos.StrMembershipID});

				table.Rows[0]["fRegistrationFee"] = 1;

				member.SaveData(table);
			}
		}

		private void MineralWaterTransaction(ACMSDAL.ConnectionProvider connProvider, ACMSLogic.POS pos)
		{
			if (pos.NCategoryID == 21 && pos.ReceiptItemsTable.Rows.Count > 0)
			{
				string strProductCode = pos.ReceiptItemsTable.Rows[0]["strCode"].ToString();
				int qtyToDeduct = ACMS.Convert.ToInt32(pos.ReceiptItemsTable.Rows[0]["MineralWaterQty"]);

				TblProductInventory producInv = new TblProductInventory();
				
				producInv.MainConnectionProvider = connProvider;

				producInv.IncreaseQuantity(strProductCode, pos.StrBranchCode, -qtyToDeduct);
			}
		}

		private void ReplaceMembershipCardTransaction(ACMSDAL.ConnectionProvider connProvider, ACMSLogic.POS pos)
		{
			if (pos.NCategoryID == 20)
			{
				TblMember sqlMember = new TblMember();
				sqlMember.MainConnectionProvider = connProvider;

				sqlMember.StrMembershipID = pos.StrMembershipID;
				sqlMember.SelectOne();
				sqlMember.NCardStatusID = 0;
				sqlMember.StrCardBranchCode = "WL";
				sqlMember.Update();
				
				TblMember sqlIntroduceMember = new TblMember();
				sqlIntroduceMember.MainConnectionProvider = connProvider;
				sqlIntroduceMember.StrIntroducerMembershipID = pos.StrMembershipID;
				DataTable introduceMemberTable = sqlIntroduceMember.SelectAllWstrIntroducerMembershipIDLogic();
				
				if (introduceMemberTable != null && introduceMemberTable.Rows.Count > 0)
				{
					foreach (DataRow r in introduceMemberTable.Rows)
						r["StrIntroducerMembershipID"] = DBNull.Value;
				
					sqlIntroduceMember.SaveData(introduceMemberTable);
				}
				
				string membershipID = pos.StrMembershipID;
				string newStrMembershipID = "";
				bool isMember = !membershipID.StartsWith("NMC");
				
				if (!isMember)
				{
					TblCardRequest sqlCardRequest = new TblCardRequest();
					TblCompany sqlCompany = new TblCompany();
					sqlCompany.MainConnectionProvider = connProvider;
					sqlCardRequest.MainConnectionProvider = connProvider;
					
					sqlCompany.IncOne();
					
					sqlMember.StrMembershipID = pos.StrMembershipID;
					DataTable memberTable = sqlMember.SelectOne();
					
					newStrMembershipID = "NMC" + sqlCompany.NNonMembershipNo.Value.ToString();
					string origStrMembershipID = sqlMember.StrMembershipID.Value;
					pos.StrNewMembershipID = newStrMembershipID;

					memberTable.Rows[0]["nMembershipNo"] = sqlCompany.NNonMembershipNo.Value;
					memberTable.Rows[0]["strMembershipID"] = newStrMembershipID;
					memberTable.Rows[0]["nCardStatusID"] = (int)CardStatusType.RequestPrint;
					
					string cmdText = "Update tblMember SET strMembershipID = @NewStrMembershipID, " + 
						" nMembershipNo = @nMembershipNo Where strMembershipID = @OriginalStrMembershipID";
					
					sqlMember.UpdateKey(memberTable,  cmdText, "@NewStrMembershipID",  newStrMembershipID, 
						"@OriginalStrMembershipID", origStrMembershipID, new string[] {"@nMembershipNo"}, 
						new object[] {sqlCompany.NNonMembershipNo.Value});

					#region ====== Added By Albert ======
					//To update member packages after changing MembershipID.
					TblMemberPackage mMemberPackage;
					mMemberPackage = new TblMemberPackage();
					mMemberPackage.StrMembershipIDOld = origStrMembershipID;
					mMemberPackage.StrMembershipID = newStrMembershipID;
					mMemberPackage.UpdateAllWstrMembershipIDLogic();

					TblMemberCreditPackage mMemberCreditPackage;
					mMemberCreditPackage = new TblMemberCreditPackage();
					mMemberCreditPackage.StrMembershipIDOld = origStrMembershipID;
					mMemberCreditPackage.StrMembershipID = newStrMembershipID;
					mMemberCreditPackage.UpdateAllWstrMembershipIDLogic();
					#endregion

					//Request print for new non member
					sqlCardRequest.NEmployeeID = pos.NCashierID;
					sqlCardRequest.NStatusID = (int)CardStatusType.RequestPrint;
					sqlCardRequest.StrBranchCode = pos.StrBranchCode;
					sqlCardRequest.StrMembershipID = "NMC" +sqlCompany.NNonMembershipNo;
					sqlCardRequest.DtLastEditDate = DateTime.Now;
					sqlCardRequest.Insert();
				}
				else
				{
					TblCardRequest sqlCardRequest = new TblCardRequest();
					TblBranch sqlBranch = new TblBranch();

					sqlBranch.MainConnectionProvider = connProvider;
					sqlCardRequest.MainConnectionProvider = connProvider;
				
					sqlBranch.StrBranchCode = pos.StrBranchCode;
					sqlBranch.IncOne();

					sqlMember.StrMembershipID = pos.StrMembershipID;
					DataTable memberTable = sqlMember.SelectOne();
					
					newStrMembershipID = pos.StrBranchCode.TrimEnd() + ACMS.Convert.ToInt32(sqlBranch.NMembershipNo);
					string origStrMembershipID = sqlMember.StrMembershipID.Value;
					pos.StrNewMembershipID = newStrMembershipID;
					
					memberTable.Rows[0]["nMembershipNo"] = ACMS.Convert.ToInt32(sqlBranch.NMembershipNo);
					memberTable.Rows[0]["strMembershipID"] = newStrMembershipID;
					memberTable.Rows[0]["nCardStatusID"] = (int)CardStatusType.RequestPrint;
					
					string cmdText = "Update tblMember SET strMembershipID = @NewStrMembershipID, " + 
						" nMembershipNo = @nMembershipNo Where strMembershipID = @OriginalStrMembershipID";
					
					sqlMember.UpdateKey(memberTable,  cmdText, "@NewStrMembershipID",  newStrMembershipID, 
						"@OriginalStrMembershipID", origStrMembershipID, new string[] {"@nMembershipNo"}, 
						new object[] {ACMS.Convert.ToInt32(sqlBranch.NMembershipNo)});

					#region ====== Added By Albert ======
					//To update member packages after changing MembershipID.
					TblMemberPackage mMemberPackage;
					mMemberPackage = new TblMemberPackage();
					mMemberPackage.StrMembershipIDOld = origStrMembershipID;
					mMemberPackage.StrMembershipID = newStrMembershipID;
					mMemberPackage.UpdateAllWstrMembershipIDLogic();

					TblMemberCreditPackage mMemberCreditPackage;
					mMemberCreditPackage = new TblMemberCreditPackage();
					mMemberCreditPackage.StrMembershipIDOld = origStrMembershipID;
					mMemberCreditPackage.StrMembershipID = newStrMembershipID;
					mMemberCreditPackage.UpdateAllWstrMembershipIDLogic();
					#endregion

					//Request print for new non member
					sqlCardRequest.NEmployeeID = pos.NCashierID;
					sqlCardRequest.NStatusID = (int)CardStatusType.RequestPrint;
					sqlCardRequest.StrBranchCode = pos.StrBranchCode;
					sqlCardRequest.StrMembershipID = newStrMembershipID;
					sqlCardRequest.DtLastEditDate = DateTime.Now;
					sqlCardRequest.Insert();
				}

				if (introduceMemberTable != null && introduceMemberTable.Rows.Count > 0)
				{
					foreach (DataRow r in introduceMemberTable.Rows)
						r["StrIntroducerMembershipID"] = newStrMembershipID;
				
					sqlIntroduceMember.SaveData(introduceMemberTable);
				}

				TblAudit sqlAudit = new TblAudit();
				sqlAudit.MainConnectionProvider = connProvider;
				//Audit trail for request print
				sqlAudit.NAuditTypeID = ACMSLogic.AuditTypeID.MemberCard;
				sqlAudit.NEmployeeID = pos.NCashierID;
				sqlAudit.StrAuditEntry = "Replace member card with new ID";
				sqlAudit.StrReference = newStrMembershipID;
				sqlAudit.DtDate = DateTime.Now;
				sqlAudit.Insert();
			}
		}

		private void ForgetCardTransaction(ACMSDAL.ConnectionProvider connProvider, ACMSLogic.POS pos)
		{
			if (pos.NCategoryID == 17 && pos.POSForgetCardAction == ACMSLogic.POS.ForgetCardAction.Refund)
			{
				TblClassAttendance classAttendance = new TblClassAttendance();
				classAttendance.MainConnectionProvider = connProvider;
				TblReceipt sqlReceipt = new TblReceipt();
				sqlReceipt.MainConnectionProvider = connProvider;

				foreach (DataRow row in pos.ReceiptItemsTable.Rows)
				{
					DateTime dtDate = ACMS.Convert.ToDateTime(row["strReferenceNo"]);
					DataTable classAttendanceTable = classAttendance.GetForgetCardClassAttendance(pos.StrMembershipID, dtDate);
					
					foreach (DataRow r in classAttendanceTable.Rows)
					{
						r["fRefunded"] = true;
					}

					classAttendance.SaveData(classAttendanceTable);
/*
					string receiptToVoid = row["strCode"].ToString();

					sqlReceipt.StrReceiptNo = receiptToVoid;
					sqlReceipt.SelectOne();
					sqlReceipt.FVoid = SqlBoolean.True;
					sqlReceipt.Update();*/
				}
			}
		}


		private void UpdateCategoryID(ACMSDAL.ConnectionProvider connProvider, ACMSLogic.POS pos)
		{
			if (pos.NCategoryID == 0 )
			{
				
				TblReceipt sqlReceipt = new TblReceipt();
				sqlReceipt.MainConnectionProvider = connProvider;

				//foreach (DataRow row in pos.ReceiptItemsTable.Rows)
				
					//DataTable classAttendanceTable = classAttendance.GetForgetCardClassAttendance(pos.StrMembershipID, dtDate);
					
					DataTable receiptTable = new DataTable();
					//receipt.NCategoryIDOld = GetOriginalCatID(connProvider, pos, ref branchReceiptNoTable);
					//receipt.NCategoryID = GetOriginalCatID(connProvider, pos, ref branchReceiptNoTable);
					
					sqlReceipt.StrReceiptNo = pos.StrReceiptNo;
					sqlReceipt.SelectOne();
					sqlReceipt.SaveData(receiptTable);// .Update();
				}
		}

		private void GIROpkgTransaction(ACMSDAL.ConnectionProvider connProvider, ACMSLogic.POS pos)
		{
			if (pos.NCategoryID == 2)
			{
				TblMemberPackage GIROPackage = new TblMemberPackage();
				GIROPackage.MainConnectionProvider = connProvider;
				GIROPackage.NPackageID = pos.NExtendGIROpkg;
				DataTable memberGIROPKG = GIROPackage.SelectOne();
				memberGIROPKG.Rows[0]["dtexpirydate"] = GIROPackage.DtExpiryDate.Value.AddMonths(1);
				GIROPackage.SaveData(memberGIROPKG);
			}
		}
        private void CashVoucherTransaction(ACMSDAL.ConnectionProvider connProvider, ACMSLogic.POS pos)
        {
            if (pos.NCategoryID == 38)
            {
                DateTime dtStartDate = DateTime.Now.Date;
                DateTime dtExpiryDate;

                foreach (DataRow r in pos.ReceiptItemsTable.Rows)
                {
                    TblCashVoucher sqlCV = new TblCashVoucher();
                    sqlCV.MainConnectionProvider = connProvider;
                    string strCVCode = r["strCode"].ToString();
                    sqlCV.StrSN = strCVCode;
                    DataTable table = sqlCV.SelectOne();
                    sqlCV.NStatusID = 1;
                    sqlCV.StrSoldToID = pos.StrMembershipID;
                    sqlCV.DtSoldDate = DateTime.Now;
                    sqlCV.StrSoldBranch = pos.StrBranchCode;

                    int iduration = Convert.ToInt32(sqlCV.NValidDuration.ToString());
                    if (sqlCV.StrDurationUnit.ToString().Trim() == "DAY")
                        dtExpiryDate = dtStartDate.AddDays(iduration - 1).AddDays(0);
                    else if (sqlCV.StrDurationUnit.ToString().Trim() == "WEEK")
                    {
                        iduration = iduration * 7;
                        dtExpiryDate = dtStartDate.AddDays(iduration - 1).AddDays(0);
                    }
                    else
                        dtExpiryDate = dtStartDate.AddMonths(iduration).AddDays(-1);

                    sqlCV.DtStartDate = dtStartDate;
                    sqlCV.DtExpiryDate = dtExpiryDate;
                    sqlCV.Update();
                    sqlCV.SaveData(table);
                }
            }            
        }
		private void LockerTransaction(ACMSDAL.ConnectionProvider connProvider, ACMSLogic.POS pos)
		{
			if (pos.NCategoryID == 15)
			{
				if (pos.POSLockerAction == ACMSLogic.POS.LockerAction.Return)
				{
					// Locker Return.

					ACMSDAL.TblLocker sqlLocker = new ACMSDAL.TblLocker();
					sqlLocker.MainConnectionProvider = connProvider;

					DataTable table = sqlLocker.GetOccupiedLocker(pos.StrBranchCode, pos.StrMembershipID);

					if (table == null || table.Rows.Count == 0)
					{
						throw new Exception("No lockers have been rented.");
					}
					
					ACMSDAL.TblBranch sqlBranch = new ACMSDAL.TblBranch();
					sqlBranch.MainConnectionProvider = connProvider;

					sqlBranch.StrBranchCode = pos.StrBranchCode;
					sqlBranch.SelectOne();

					int gracePeriod =  ACMS.Convert.ToInt32(sqlBranch.NLockerGracePeriod);

					foreach (DataRow r in pos.ReceiptItemsTable.Rows)
					{
						
						string nLockerNo = r["strCode"].ToString();

						DataRow[] lockerRows = table.Select("nLockerNo = " + nLockerNo);

						if (lockerRows.Length > 0)
						{
							DataRow lockerRow = lockerRows[0];

							DateTime dtExpiryDate = ACMS.Convert.ToDateTime(lockerRow["dtExpiry"]);

							TimeSpan span = DateTime.Today.Subtract(dtExpiryDate.Date);
			
							if (span.Days > gracePeriod)
								throw new Exception(string.Format("locker No : {0} have exceed the grace period.", nLockerNo));
					
							lockerRow["strMembershipID"] = DBNull.Value;
							lockerRow["strReceiptNo"] = DBNull.Value;
							lockerRow["dtExpiry"] = DBNull.Value;
							lockerRow["nStatusID"] = 0;
						}
					}

					sqlLocker.SaveData(table);
				}
				else if (pos.POSLockerAction == ACMSLogic.POS.LockerAction.Extend)
				{
					ACMSDAL.TblLocker sqllocker = new ACMSDAL.TblLocker();
					sqllocker.MainConnectionProvider = connProvider;

					DataTable table = sqllocker.GetOccupiedLocker(pos.StrBranchCode, pos.StrMembershipID);

					if (table.Rows.Count > 0)
					{
						foreach (DataRow r in pos.ReceiptItemsTable.Rows)
						{
							string nLockerNo = r["strCode"].ToString();

							DataRow[] lockerRows = table.Select("nLockerNo = " + nLockerNo);

							if (lockerRows.Length > 0)
							{
								DataRow lockerRow = lockerRows[0];

								DateTime expiryDate = ACMS.Convert.ToDateTime(lockerRow["dtExpiry"]);
						
								int months = ACMS.Convert.ToInt32(r["nQuantity"]);

                                if (DateTime.Now.Year == 2015 && (DateTime.Now.Month == 3 || DateTime.Now.Month == 4) && (pos.StrBranchCode == "TO" || pos.StrBranchCode == "SM" || pos.StrBranchCode == "HM" || pos.StrBranchCode == "TS" || pos.StrBranchCode == "BJ" || pos.StrBranchCode == "SV") && ACMS.Convert.ToInt32(r["nQuantity"]) >= 3)
                                {
                                    int nFreeMonth;
                                    nFreeMonth = months / 3;

                                    DialogResult result1 = MessageBox.Show("Member entitled " + nFreeMonth.ToString() + " month free extension for locker ID " + nLockerNo.ToString() + ". Do you want to give the free extension?", "Warning",
                                            MessageBoxButtons.YesNo);
                                    if (result1 == DialogResult.Yes)
                                    {
                                        expiryDate = expiryDate.AddMonths(months + nFreeMonth);
                                    }
                                    else
                                        expiryDate = expiryDate.AddMonths(months);
                                }
                                else
								    expiryDate = expiryDate.AddMonths(months);

								//lockerRow["dtExpiry"] = expiryDate.AddDays(-1);
                                lockerRow["dtExpiry"] = expiryDate;
							}
						}
						sqllocker.SaveData(table);
					}
				}
				else if (pos.POSLockerAction == ACMSLogic.POS.LockerAction.New)
				{

					ACMSDAL.TblLocker sqllocker = new ACMSDAL.TblLocker();
					sqllocker.MainConnectionProvider = connProvider;

					foreach (DataRow r in pos.ReceiptItemsTable.Rows)
					{
						if (r["strDescription"].ToString() != "Locker Deposit")
						{
							int nlockerNO = ACMS.Convert.ToInt32(r["strCode"]);
							int months =  ACMS.Convert.ToInt32(r["nQuantity"]);

                            sqllocker.NLockerNo = nlockerNO;
                            sqllocker.SelectOne();

                            if (DateTime.Now.Year == 2015 && (DateTime.Now.Month == 3 || DateTime.Now.Month == 4) && (pos.StrBranchCode == "TO" || pos.StrBranchCode == "SM" || pos.StrBranchCode == "HM" || pos.StrBranchCode == "TS" || pos.StrBranchCode == "BJ" || pos.StrBranchCode == "SV") && ACMS.Convert.ToInt32(r["nQuantity"]) >= 3)
                            {
                                int nFreeMonth;
                                nFreeMonth = months / 3;

                                DialogResult result1 = MessageBox.Show("Member entitled " + nFreeMonth.ToString() + " month free extension for locker ID " + nlockerNO .ToString() + ". Do you want to give the free extension?", "Warning",
                                        MessageBoxButtons.YesNo);
                                if (result1 == DialogResult.Yes)
                                {
                                    sqllocker.DtExpiry = DateTime.Today.AddMonths(months+nFreeMonth).AddDays(-1);
                                }
                                else
                                    sqllocker.DtExpiry = DateTime.Today.AddMonths(months).AddDays(-1);
                            }                            
                            else
                                sqllocker.DtExpiry = DateTime.Today.AddMonths(months).AddDays(-1);
                            							
							sqllocker.StrBranchCode = pos.StrBranchCode;
							sqllocker.StrMembershipID = pos.StrMembershipID;
							sqllocker.StrReceiptNo = pos.StrReceiptNo;
							sqllocker.NStatusID = 1;							
							sqllocker.Update();
						}
					}
				}
			}
		}

        //Derek Instalment Plan Need Update tblPaymentPlan During Pay OutStanding
        //Derek Instalment Plan TblPaymentPlan.cs
		private int PayOutstanding(ACMSDAL.ConnectionProvider connProvider, ACMSLogic.POS pos)
		{
			int OriginalCategoryID = 0 ;

			if (pos.NCategoryID == 0)
			{
				TblReceipt receipt = new TblReceipt();
				
				receipt.MainConnectionProvider = connProvider;

				if (pos.ReceiptItemsTable.Rows.Count == 1)
				{
					string strReceiptNo = pos.ReceiptItemsTable.Rows[0]["strCode"].ToString();

					decimal payAmount = ACMS.Convert.ToDecimal(pos.ReceiptItemsTable.Rows[0]["mSubtotal"]);

					receipt.StrReceiptNo = strReceiptNo;

					receipt.SelectOne();

					OriginalCategoryID=receipt.NCategoryID.Value;

					receipt.MOutstandingAmount = 0;					
				
					receipt.StrChildReceiptNo = pos.StrReceiptNo;

					pos.StrRewardsCode=receipt.StrRewardsCode.ToString();

					//receipt.StrParentReceiptNo = strReceiptNo;

					if(receipt.NTherapistID.IsNull != true)
					{
						if(receipt.NTherapistID.Value.ToString().Length>0)
							pos.NTherapistID = receipt.NTherapistID.Value;
					}

					receipt.Update(); 


					receipt.StrReceiptNo = pos.StrReceiptNo;
					receipt.SelectOne();
					receipt.StrParentReceiptNo = strReceiptNo;
					receipt.Update();

				}			
			}
			return  OriginalCategoryID;
				
		}

		private void MakeDeposit(ACMSDAL.ConnectionProvider connProvider, ACMSLogic.POS pos)
		{
			if (pos.NCategoryID == 16)
			{
				TblMember member = new TblMember();
				member.MainConnectionProvider = connProvider;

				member.StrMembershipID = pos.StrMembershipID;
				member.SelectOne();
				member.FLockerDeposit = true;

				member.Update();
			}	
		}

		private void TopUpCreditPackage(ACMSDAL.ConnectionProvider connProvider, ACMSLogic.POS pos)
		{
			if (pos.NCategoryID == 18)
			{
				TblMemberCreditPackage memberCreditPackage = new TblMemberCreditPackage();
				memberCreditPackage.MainConnectionProvider = connProvider;

				foreach (DataRow r in pos.ReceiptItemsTable.Rows)
				{
					int nCreditPackageID = ACMS.Convert.ToInt32(r["strCode"]);
	
					memberCreditPackage.NCreditPackageID = nCreditPackageID;
					memberCreditPackage.SelectOne();
					memberCreditPackage.MTopupAmount = ACMS.Convert.ToDecimal(memberCreditPackage.MTopupAmount) +
						ACMS.Convert.ToDecimal(r["mSubTotal"]);
					memberCreditPackage.Update();
				}
			}
		}

		private int UpgradeCreditPackage (ACMSDAL.ConnectionProvider connProvider, ACMSLogic.POS pos)
		{
			int OriginalCategoryID = 10 ;

			if (pos.NCategoryID == 10 && pos.NoCredit != 0)
			{
				//delete the old package
				TblMemberCreditPackage memberCreditPackage = new TblMemberCreditPackage();
				
				//add back the uprade package
				memberCreditPackage.MainConnectionProvider = connProvider;
				
				DataTable memberCreditPackageTable = memberCreditPackage.FillSchema("Select * from tblMemberCreditPackage");

				foreach (DataRow r in pos.ReceiptItemsTable.Rows)
				{ 
					int nQuantity = ACMS.Convert.ToInt32(r["nQuantity"]);
					memberCreditPackage.NCreditPackageID = ACMS.Convert.ToInt32(r[17]);
					
					memberCreditPackage.Delete();
					for (int i = 0; i < nQuantity; i++)
					{
						DataRow rowToAdd = memberCreditPackageTable.NewRow();

						CreditAccount.InitMemberCreditPackageRowInPOS(rowToAdd, pos.StrReceiptNo, pos.StrMembershipID, r["strCode"].ToString(), false);
				
						memberCreditPackageTable.Rows.Add(rowToAdd);
					}
				}

				if (memberCreditPackageTable.Rows.Count > 0)
					memberCreditPackage.SaveData(memberCreditPackageTable);		
			}
			
			OriginalCategoryID= 7;

			return OriginalCategoryID;

		}

	
		private int UpgradePackage(ACMSDAL.ConnectionProvider connProvider, ACMSLogic.POS pos)
		{
			int OriginalCategoryID = 10 ;

			if (pos.NCategoryID == 10 && pos.WantToUpgradeMemberPackageTable.Rows.Count == 1)
			{
				int wantToUpgrade_nPackageID = ACMS.Convert.ToInt32(pos.WantToUpgradeMemberPackageRow["nPackageID"]);
				string oldStrPackageCode = pos.WantToUpgradeMemberPackageRow["strPackageCode"].ToString();

				foreach (DataRow r in pos.ReceiptItemsTable.Rows)
				{
					pos.CheckPackageWhenSave(r["strCode"].ToString(), wantToUpgrade_nPackageID);
				}

				// from here, we can get a list of strClassCode that already been used by member	
				//DataTable attendedClassCodetable = GetAttendedClassCode(ACMS.Convert.ToInt32(myWantToUpgradeMemberPackageTable.Rows[0]["nPackageID"]));

				// from here, we can get a list of strClassCode that already been used by member
				//DataTable attendedServiceCodetable = GetAttendedServiceCode(ACMS.Convert.ToInt32(myWantToUpgradeMemberPackageTable.Rows[0]["nPackageID"]));

				TblMemberPackage memberPackage = new TblMemberPackage();
				TblClassAttendance classAttendance = new TblClassAttendance();
				TblServiceSession serviceSession = new TblServiceSession();
				TblPackage freeSpaPackage = new TblPackage();

				memberPackage.MainConnectionProvider = connProvider;
				classAttendance.MainConnectionProvider = connProvider;
				serviceSession.MainConnectionProvider = connProvider;
				freeSpaPackage.MainConnectionProvider = connProvider;

				DataTable memberPackagetable = memberPackage.FillSchema("Select * from tblMemberPackage");

				//get old free spa package Code
				freeSpaPackage.StrPackageCode = oldStrPackageCode;
				DataTable OldFreePackageCode = freeSpaPackage.SelectSpaPackageFreebie();
				string strOldFreePackage = OldFreePackageCode.Rows[0]["strFreePkgCode"].ToString();
					
				
				foreach (DataRow r in pos.ReceiptItemsTable.Rows)
				{
					int nQuantity = ACMS.Convert.ToInt32(r["nQuantity"]);

					for (int i = 0; i < nQuantity; i++)
					{
						DataRow rowToAdd = memberPackagetable.NewRow();
						MemberPackage.InitMemberPackageRowInPOS(rowToAdd, pos.StrReceiptNo, pos.StrMembershipID, r["strCode"].ToString(), "", false);				
						memberPackagetable.Rows.Add(rowToAdd);						
					}
				}
//insert a new upgrade package to member package
				if (memberPackagetable.Rows.Count > 0)
					memberPackage.SaveData(memberPackagetable);
				
				DataTable newAddMemberPackageTable = memberPackage.SelectAllWstrReceiptNo(pos.StrReceiptNo);
				DataRow[] rowNewAddMemberPackage = newAddMemberPackageTable.Select("fFree = 0");
				DataTable attendedClassTable = classAttendance.GetAllClassAttendancesBasePackageID(wantToUpgrade_nPackageID, pos.StrMembershipID, pos.StrBranchCode);
				
				DataTable serviceUsedTable = serviceSession.GetMemberServiceSessionBasePackageID(wantToUpgrade_nPackageID, pos.StrMembershipID, pos.StrBranchCode); 

//insert a new freebie package based on new added upgrade pacakge
			
				string newStrPackageCode = "";
				for( int i = 0; i<newAddMemberPackageTable.Rows.Count; i++)
				{
                    if (newAddMemberPackageTable.Rows[i]["fFree"].ToString() == "False")
                    {
                        if (newAddMemberPackageTable.Rows.Count > 1)
                            newStrPackageCode = newAddMemberPackageTable.Rows[newAddMemberPackageTable.Rows.Count - 1]["strPackageCode"].ToString();
                            else
                             newStrPackageCode = newAddMemberPackageTable.Rows[0]["strPackageCode"].ToString();

                    }
				}
			    //get new free spa package Code
				
					freeSpaPackage.StrPackageCode = newStrPackageCode;
					DataTable NewFreePackageCode = freeSpaPackage.SelectSpaPackageFreebie();
                    string strNewFreePackage = NewFreePackageCode.Rows[0]["strFreePkgCode"].ToString();

				if (strNewFreePackage != "")
				{
					DataTable FreememberPackagetable = memberPackage.FillSchema("Select * from tblMemberPackage");
					DataRow rowToAdd2 = FreememberPackagetable.NewRow();
					MemberPackage.InitMemberPackageRowInPOS(rowToAdd2, pos.StrReceiptNo, pos.StrMembershipID, strNewFreePackage, "", true);				
					FreememberPackagetable.Rows.Add(rowToAdd2);	
					if (FreememberPackagetable.Rows.Count > 0)
						memberPackage.SaveData(FreememberPackagetable);

					//move session from old freebie to new freebie
					//find old free package ID,via wantToUpgrade_nPackageID
					freeSpaPackage.NPackageID = wantToUpgrade_nPackageID;
					freeSpaPackage.StrPackageCode = oldStrPackageCode;
					DataTable OldFreePackageID = freeSpaPackage.SelectSpaPackageFreebieID();
					int nOldFreePackageID;
                    if (OldFreePackageID.Rows.Count > 0)
                        nOldFreePackageID = ACMS.Convert.ToInt32(OldFreePackageID.Rows[OldFreePackageID.Rows.Count - 1]["nPackageID"]);
                    else
                        nOldFreePackageID = 0;

					DataTable newFreeMemberPackageTable = memberPackage.SelectAllWstrReceiptNo(pos.StrReceiptNo);
					DataRow[] rowNewFreeMemberPackage = newFreeMemberPackageTable.Select("fFree = 1");
					DataTable freeserviceUsedTable = serviceSession.GetMemberServiceSessionBasePackageID(nOldFreePackageID, pos.StrMembershipID, pos.StrBranchCode); 

                    //foreach (DataRow FmemberPackageRow in rowNewFreeMemberPackage)
                    //{
                    string strFreePackageCode ="";
                    if (rowNewFreeMemberPackage.Length > 0)
                        strFreePackageCode = rowNewFreeMemberPackage[rowNewFreeMemberPackage.Length - 1]["strPackageCode"].ToString();
									
						DataRow[] tempRowList3 = freeserviceUsedTable.Select("nPackageID = '"+nOldFreePackageID+"'", "dtDate");

						if (tempRowList3.Length > 0)
						{
							foreach (DataRow freeserviceUsedRow in tempRowList3)
							{
                                freeserviceUsedRow["nPackageID"] = rowNewFreeMemberPackage[rowNewFreeMemberPackage.Length - 1]["nPackageID"];
							}
						
						}				
				

						if (tempRowList3.Length > 0)
						{
							//update the expiryDate
					

							TblPackage package = new TblPackage();
							package.MainConnectionProvider = connProvider;

							package.StrPackageCode = strFreePackageCode;
							DataTable tablePackage = package.SelectOne();
					
							if (tablePackage == null && tablePackage.Rows.Count == 0)
								throw new Exception("Package no found.");
						
							if (tempRowList3.Length > 0)
							{
                                rowNewFreeMemberPackage[rowNewFreeMemberPackage.Length - 1]["DtStartDate"] = ACMS.Convert.ToDateTime(tempRowList3[0]["dtDate"]);

                                rowNewFreeMemberPackage[rowNewFreeMemberPackage.Length - 1]["DtExpiryDate"] = ACMS.Convert.ToDateTime(
                                    rowNewFreeMemberPackage[rowNewFreeMemberPackage.Length - 1]["DtStartDate"]).AddMonths(ACMS.Convert.ToInt32(package.NPackageDuration.Value)).AddDays(-1);
							}						
						}
					
                    //}
					
					DataTable oldFreeMemberPackageTable = memberPackage.SelectPackageID(nOldFreePackageID);
					oldFreeMemberPackageTable.Rows[0]["nStatusID"] = 2;
                    serviceSession.UpgradePackage(ACMS.Convert.ToInt32(rowNewFreeMemberPackage[rowNewFreeMemberPackage.Length - 1]["nPackageID"]), nOldFreePackageID, pos.StrMembershipID);
                    memberPackage.SaveData(oldFreeMemberPackageTable);
					memberPackage.SaveData(newFreeMemberPackageTable);					
                    
				}

//move session from old package to new package
				foreach (DataRow memberPackageRow in rowNewAddMemberPackage)
				{
					string strPackageCode = memberPackageRow["strPackageCode"].ToString();

                    DataRow[] tempRowList = attendedClassTable.Select("nPackageID = '" + wantToUpgrade_nPackageID + "'", "dtDate");
					
					if (tempRowList.Length > 0)
					{
						foreach (DataRow attendedClassRow in tempRowList)
						{   // new packageID 
							attendedClassRow["nPackageID"] = memberPackageRow["nPackageID"];
						}
					}

                    DataRow[] tempRowList2 = serviceUsedTable.Select("nPackageID = '" + wantToUpgrade_nPackageID + "'", "dtDate");

					if (tempRowList2.Length > 0)
					{
						foreach (DataRow serviceUsedRow in tempRowList2)
						{
						serviceUsedRow["nPackageID"] = memberPackageRow["nPackageID"];
						}
						
					}				
				

					if (tempRowList.Length > 0 ||
						tempRowList2.Length > 0)
					{
						//update the expiryDate
					

						TblPackage package = new TblPackage();
						package.MainConnectionProvider = connProvider;

						package.StrPackageCode = strPackageCode;
						DataTable tablePackage = package.SelectOne();

						
						TblPackageExtension PackExtension = new TblPackageExtension();
						PackExtension.MainConnectionProvider = connProvider;

						PackExtension.NPackageID = ACMS.Convert.ToInt32(rowNewAddMemberPackage[0]["nPackageID"]);
                        PackExtension.NPackageIDOld = wantToUpgrade_nPackageID;
						int days = 0;
						DataTable tblPkgExt = PackExtension.SelectExtensionDays();
						if (PackExtension.NDaysExtended.IsNull == false)
						days = System.Convert.ToInt32(PackExtension.NDaysExtended.Value);
					
						if (tablePackage == null && tablePackage.Rows.Count == 0)
							throw new Exception("Package no found.");
						
						if (tempRowList.Length > 0 && tempRowList2.Length == 0)
						{

                            ///07/11/2012 Jackie
                           
                            DataTable  myDataTable1;
                            DateTime dtDate;
                            ACMSDAL.TblClassAttendance ClassAttendance = new ACMSDAL.TblClassAttendance();
                            myDataTable1 = ClassAttendance.LoadData("Select top 1 dtDate From tblClassAttendance where  nstatusid=1 and nPackageID= " + wantToUpgrade_nPackageID + " and  " +
                             " strMemberShipID = @strMembershipID order by dtDate",
                                new string[] { "@strMembershipID" },
                                new object[] { pos.StrMembershipID });
                            dtDate = DateTime.Now;
                            if (myDataTable1.Rows.Count > 0)
                                dtDate = System.Convert.ToDateTime(myDataTable1.Rows[0][0]);

                            memberPackageRow["DtStartDate"] = dtDate;
                           // Stop

							memberPackageRow["DtExpiryDate"] =  ACMS.Convert.ToDateTime(
                                memberPackageRow["DtStartDate"]).AddMonths(ACMS.Convert.ToInt32(package.NPackageDuration.Value)).AddDays(days - 1);
						}
						else if (tempRowList2.Length > 0 &&
							tempRowList.Length == 0)
						{
							memberPackageRow["DtStartDate"] = ACMS.Convert.ToDateTime(tempRowList2[0]["dtDate"]);

							memberPackageRow["DtExpiryDate"] =  ACMS.Convert.ToDateTime(
                                memberPackageRow["DtStartDate"]).AddMonths(ACMS.Convert.ToInt32(package.NValidMonths.Value)).AddDays(days - 1);
						}
					}
				}
				OriginalCategoryID=  ACMS.Convert.ToDBInt32(pos.WantToUpgradeMemberPackageRow["nCategoryID"]) ;
				pos.WantToUpgradeMemberPackageRow["nStatusID"] = 2;

                serviceSession.UpgradePackage(ACMS.Convert.ToInt32(rowNewAddMemberPackage[0]["nPackageID"]), wantToUpgrade_nPackageID, pos.StrMembershipID);
				memberPackage.SaveData(pos.WantToUpgradeMemberPackageTable);
				memberPackage.SaveData(newAddMemberPackageTable);
							
				classAttendance.SaveData(wantToUpgrade_nPackageID,pos.StrMembershipID);
				
			

			}
			return OriginalCategoryID;
		}
        
        //private int UpgradePackage(ACMSDAL.ConnectionProvider connProvider, ACMSLogic.POS pos)
        //{
         
        //        UpgradeNonGIRO(connProvider, pos);

		private void PostToMemberPackage(ACMSDAL.ConnectionProvider connProvider, ACMSLogic.POS pos)
		{
			//MemberRecord myMemberRecord = new MemberRecord(pos.StrMembershipID.ToString(), pos.StrBranchCode.ToString());
			TblMemberPackage memberPackage = new TblMemberPackage();
			memberPackage.MainConnectionProvider = connProvider;

			DataTable memberPackagetable = memberPackage.FillSchema("Select * from tblMemberPackage");

            string strUpgradeFrom="";
			string strRemarks = "";
            foreach (DataRow dr in pos.WantToUpgradeMemberPackageTable.Rows)
            {
                strRemarks += dr["strPackageCode"].ToString() + " / " + dr["strReceiptNo"].ToString() + " / " + dr["UsageBalAmt"].ToString() + ",";
                if (dr["nCategoryID"].ToString() == "7" || dr["nCategoryID"].ToString() == "36" || dr["nCategoryID"].ToString() == "37")
                    strUpgradeFrom += dr["nPackageID"].ToString() + "(C),";
                else if (dr["nCategoryID"].ToString() == "8" || dr["nCategoryID"].ToString() == "9")
                    strUpgradeFrom += dr["nPackageID"].ToString() + "(B),";
                else
                    strUpgradeFrom += dr["nPackageID"].ToString() + ",";

                if (ACMS.Convert.ToInt32(dr["nCategoryID"]) == 5 && dr["strFreePkgCode"] != DBNull.Value)
                {
                    TblMemberPackage mp = new TblMemberPackage();
                    mp.MainConnectionProvider = connProvider;
                    DataTable freePkgTable = mp.LoadData("select * from tblMemberPackage where strReceiptNo=@strReceiptNo and strPackageCode =@strFreePackageCode ",
                        new string[] { "@strReceiptNo", "@strFreePackageCode" }, new object[] { dr["strReceiptNo"], dr["strFreePkgCode"].ToString() });

                    if (freePkgTable.Rows.Count > 0)
                    {
                        if (dr["nCategoryID"].ToString() == "7" || dr["nCategoryID"].ToString() == "36" || dr["nCategoryID"].ToString() == "37")
                            strUpgradeFrom += freePkgTable.Rows[0]["nPackageID"].ToString() + "(C),";
                        else if (dr["nCategoryID"].ToString() == "8" || dr["nCategoryID"].ToString() == "9")
                            strUpgradeFrom += freePkgTable.Rows[0]["nPackageID"].ToString() + "(B),";
                        else
                            strUpgradeFrom += freePkgTable.Rows[0]["nPackageID"].ToString() + ",";
                    }
                }
            }
            if (pos.WantToUpgradeMemberPackageTable.Rows.Count > 0)
            {
                strUpgradeFrom = strUpgradeFrom.Remove(strUpgradeFrom.Length - 1, 1);
                strRemarks = "Convert from: " + strRemarks.Remove(strRemarks.Length - 1, 1);                
            }

            if (pos.NCategoryID == 1 ||
                pos.NCategoryID == 3 || pos.NCategoryID == 4 ||
                pos.NCategoryID == 5 || pos.NCategoryID == 6 ||
                pos.NCategoryID == 14 || pos.NCategoryID == 23)


			{
				foreach (DataRow r in pos.ReceiptItemsTable.Rows)
				{
					int nQuantity = ACMS.Convert.ToInt32(r["nQuantity"]);
					
					if (r["strCode"].ToString().ToUpper() != "REG")
					{
						for (int i = 0; i < nQuantity; i++)
						{
							DataRow rowToAdd = memberPackagetable.NewRow();

							MemberPackage.InitMemberPackageRowInPOS(rowToAdd, pos.StrReceiptNo, pos.StrMembershipID, r["strCode"].ToString(), "", false);
							rowToAdd["strRemarks"] = strRemarks;
                            rowToAdd["strUpgradeFrom"] = strUpgradeFrom;
							memberPackagetable.Rows.Add(rowToAdd);
						}
					}
					else
					{ 	
						
						TblMember sqlMember = new TblMember();
						TblCardRequest sqlCardRequest = new TblCardRequest();
						TblAudit sqlAudit = new TblAudit();
						try
						{
							sqlMember.MainConnectionProvider = connProvider;
							sqlCardRequest.MainConnectionProvider = connProvider;
							sqlAudit.MainConnectionProvider = connProvider;
							sqlMember.UpdateCardStatus(pos.StrMembershipID.ToString(), 0, pos.StrBranchCode.ToString());
							sqlCardRequest.NEmployeeID = pos.NCashierID;
							sqlCardRequest.NStatusID = 0;
							sqlCardRequest.StrBranchCode = pos.StrBranchCode.ToString();
							sqlCardRequest.StrMembershipID = pos.StrMembershipID.ToString();
							sqlCardRequest.DtLastEditDate = DateTime.Now;
							sqlCardRequest.Insert();

							sqlAudit.NAuditTypeID = ACMSLogic.AuditTypeID.MemberCard;
							sqlAudit.NEmployeeID = pos.NCashierID;
							sqlAudit.StrAuditEntry = "Reprint member card.";
							sqlAudit.StrReference = pos.StrMembershipID.ToString();
							sqlAudit.DtDate = DateTime.Now;
							sqlAudit.Insert();

						}
						catch (Exception)
						{
							throw;
						}
						finally
						{

							sqlMember.Dispose();
							sqlCardRequest.Dispose();
							sqlAudit.Dispose();
						}
				
					}
				}

				if (memberPackagetable.Rows.Count > 0)
					memberPackage.SaveData(memberPackagetable);
			}
            else if (pos.NCategoryID == 7 ||
                pos.NCategoryID == 36 || pos.NCategoryID == 37) //Credit Pkg
            {
                foreach (DataRow r in pos.ReceiptItemsTable.Rows)
                {
                    if (r["strCode"].ToString() == "JOINFEES" || r["strCode"].ToString() == "JOINFEE" || r["strCode"].ToString() == "FA")
                    {
                        int nQuantity = ACMS.Convert.ToInt32(r["nQuantity"]);

                        if (r["strCode"].ToString().ToUpper() != "REG")
                        {
                            for (int i = 0; i < nQuantity; i++)
                            {
                                DataRow rowToAdd = memberPackagetable.NewRow();

                                MemberPackage.InitMemberPackageRowInPOS(rowToAdd, pos.StrReceiptNo, pos.StrMembershipID, r["strCode"].ToString(), "", false);
                                rowToAdd["strRemarks"] = strRemarks;
                                rowToAdd["strUpgradeFrom"] = strUpgradeFrom;
                                memberPackagetable.Rows.Add(rowToAdd);
                            }
                        }
                        else
                        {

                            TblMember sqlMember = new TblMember();
                            TblCardRequest sqlCardRequest = new TblCardRequest();
                            TblAudit sqlAudit = new TblAudit();
                            try
                            {
                                sqlMember.MainConnectionProvider = connProvider;
                                sqlCardRequest.MainConnectionProvider = connProvider;
                                sqlAudit.MainConnectionProvider = connProvider;
                                sqlMember.UpdateCardStatus(pos.StrMembershipID.ToString(), 0, pos.StrBranchCode.ToString());
                                sqlCardRequest.NEmployeeID = pos.NCashierID;
                                sqlCardRequest.NStatusID = 0;
                                sqlCardRequest.StrBranchCode = pos.StrBranchCode.ToString();
                                sqlCardRequest.StrMembershipID = pos.StrMembershipID.ToString();
                                sqlCardRequest.DtLastEditDate = DateTime.Now;
                                sqlCardRequest.Insert();

                                sqlAudit.NAuditTypeID = ACMSLogic.AuditTypeID.MemberCard;
                                sqlAudit.NEmployeeID = pos.NCashierID;
                                sqlAudit.StrAuditEntry = "Reprint member card.";
                                sqlAudit.StrReference = pos.StrMembershipID.ToString();
                                sqlAudit.DtDate = DateTime.Now;
                                sqlAudit.Insert();

                            }
                            catch (Exception)
                            {
                                throw;
                            }
                            finally
                            {

                                sqlMember.Dispose();
                                sqlCardRequest.Dispose();
                                sqlAudit.Dispose();
                            }
                        }
                    }                    
                }

                if (memberPackagetable.Rows.Count > 0)
                    memberPackage.SaveData(memberPackagetable);
            }
            else if ((pos.NCategoryID == 2) || (pos.NCategoryID == 34) || (pos.NCategoryID == 35))//New GIRO = 35
            {
                TblGIRO giro = new TblGIRO();
                giro.MainConnectionProvider = connProvider;

                foreach (DataRow r in pos.ReceiptItemsTable.Rows)
                {
                    // need to save tblGiro 1st
                    int nQuantity = ACMS.Convert.ToInt32(r["nQuantity"]);
                    DataRow[] giroRows = pos.GiroTable.Select("nEntryID = " + r["nEntryID"].ToString(), "", DataViewRowState.CurrentRows);
                    if (giroRows.Length > 0)
                    {

                        giro.strCardHolderName = giroRows[0]["strCardHolderName"].ToString();
                        giro.strReceiptNo = pos.StrReceiptNo;
                        giro.nCreditCard = giroRows[0]["nCreditCard"].ToString();
                        giro.dtCreditCardExpired = DateTime.Now;
                        giro.strTypeofCard = giroRows[0]["strTypeofCard"].ToString();
                        giro.strReceiptNo = pos.StrReceiptNo;
                        giro.Insert();


                        for (int i = 0; i < nQuantity; i++)
                        {
                            DataRow rowToAdd = memberPackagetable.NewRow();
                            MemberPackage.InitMemberPackageRowInPOS(rowToAdd, pos.StrReceiptNo, pos.StrMembershipID, r["strCode"].ToString(), "",
                                false, giro.NGIRORefID.IsNull ? -1 : giro.NGIRORefID.Value, pos.dtPackageStart, pos.NProrateDays);

                            memberPackagetable.Rows.Add(rowToAdd);
                        }
                    }
                    else
                    {
                        TblMemberPackage GIROPackage = new TblMemberPackage();
                        GIROPackage.MainConnectionProvider = connProvider;
                        GIROPackage.NPackageID = pos.NExtendGIROpkg;
                        DataTable memberGIROPKG = GIROPackage.SelectOne();

                        //start 
                        //if (pos.NExtendGIROpkg == 0)
                        //{

                        //    foreach (DataRow rs in pos.ReceiptItemsTable.Rows)
                        //    {
                        //        int nQuantity1 = ACMS.Convert.ToInt32(r["nQuantity"]);

                        //        if (rs["strCode"].ToString().ToUpper() != "REG")
                        //        {
                        //            for (int i = 0; i < nQuantity1; i++)
                        //            {
                        //                DataRow rowToAdd = memberPackagetable.NewRow();

                        //                MemberPackage.InitMemberPackageRowInPOS(rowToAdd, pos.StrReceiptNo, pos.StrMembershipID, rs["strCode"].ToString(), "", false);

                        //                memberPackagetable.Rows.Add(rowToAdd);

                        //            }
                        //        }

                        //    }
                        //GIROPackage.SaveData(memberGIROPKG);

                        //}
                        //else

                        //GIROPackage start
                        //  {
                        //DateTime ExtendExpiryDate = System.Convert.ToDateTime(GIROPackage.DtExpiryDate.ToString());
                        //if (ExtendExpiryDate.Day > 27)
                        //    memberGIROPKG.Rows[0]["dtexpirydate"] = new DateTime(ExtendExpiryDate.Year, ExtendExpiryDate.Month, 1).AddMonths(2).AddDays(-1);
                        //else if (ExtendExpiryDate.Day == 15)
                        //    memberGIROPKG.Rows[0]["dtexpirydate"] = new DateTime(ExtendExpiryDate.Year, ExtendExpiryDate.Month, 15).AddMonths(1);
                        //memberGIROPKG.Rows[0]["fGiroStatus"] = "S";

                        DateTime ExtendExpiryDate = System.Convert.ToDateTime(GIROPackage.DtExpiryDate.ToString());
                        if (ExtendExpiryDate.Day > 27)
                            if (nQuantity > 1)
                                memberGIROPKG.Rows[0]["dtexpirydate"] = new DateTime(ExtendExpiryDate.Year, ExtendExpiryDate.Month, 1).AddMonths(nQuantity + 1).AddDays(-1);
                            else
                                memberGIROPKG.Rows[0]["dtexpirydate"] = new DateTime(ExtendExpiryDate.Year, ExtendExpiryDate.Month, 1).AddMonths(2).AddDays(-1);
                        else if (ExtendExpiryDate.Day == 15)
                            if (nQuantity > 1)
                                memberGIROPKG.Rows[0]["dtexpirydate"] = new DateTime(ExtendExpiryDate.Year, ExtendExpiryDate.Month, 15).AddMonths(nQuantity + 1);
                            else
                                memberGIROPKG.Rows[0]["dtexpirydate"] = new DateTime(ExtendExpiryDate.Year, ExtendExpiryDate.Month, 15).AddMonths(1);

                        memberGIROPKG.Rows[0]["fGiroStatus"] = "S";

                        //set package status to active if expired date > today                            
                        if (Convert.ToDateTime(memberGIROPKG.Rows[0]["dtexpirydate"]) > DateTime.Now)
                            memberGIROPKG.Rows[0]["nStatusID"] = 0;

                        if (pos.NCategoryID == 34)
                        {
                            memberGIROPKG.Rows[0]["nAdjust"] = ACMS.Convert.ToDBInt32(memberGIROPKG.Rows[0]["nAdjust"]) + 1;

                            POSHelper myPOSHelper = new POSHelper(pos);
                            DataTable tblSpaPackage = myPOSHelper.SearchOnePackageCode(memberGIROPKG.Rows[0]["strPackageCode"].ToString());
                            if (tblSpaPackage != null)
                            {
                                if (tblSpaPackage.Rows.Count > 0)
                                {
                                    string strFreePackageCode = tblSpaPackage.Rows[0]["strFreePkgCode"].ToString();
                                    DataTable tblFreePackage = GIROPackage.SelectPackageCode(strFreePackageCode, pos.StrMembershipID);
                                    int nFreePackageID = Convert.ToInt32(tblFreePackage.Rows[0]["nPackageID"]);

                                    TblMemberPackage GIROFreePackage = new TblMemberPackage();
                                    GIROFreePackage.MainConnectionProvider = connProvider;
                                    GIROFreePackage.NPackageID = nFreePackageID;

                                    DataTable memberGIROFREEPKG = GIROFreePackage.SelectOne();

                                    memberGIROFREEPKG.Rows[0]["nAdjust"] = ACMS.Convert.ToDBInt32(memberGIROFREEPKG.Rows[0]["nAdjust"]) + 1;

                                    if (ExtendExpiryDate.Day > 27)
                                        memberGIROFREEPKG.Rows[0]["dtexpirydate"] = new DateTime(ExtendExpiryDate.Year, ExtendExpiryDate.Month, 1).AddMonths(2).AddDays(-1);
                                    else if (ExtendExpiryDate.Day == 15)
                                        memberGIROFREEPKG.Rows[0]["dtexpirydate"] = new DateTime(ExtendExpiryDate.Year, ExtendExpiryDate.Month, 15).AddMonths(1);
                                    memberGIROFREEPKG.Rows[0]["fGiroStatus"] = "S";
                                    GIROFreePackage.SaveData(memberGIROFREEPKG);
                                }
                            }
                        }
                        GIROPackage.SaveData(memberGIROPKG);
                        // }//GIROPackage start
                    }
                }

                if (memberPackagetable.Rows.Count > 0)
                    memberPackage.SaveData(memberPackagetable);
            }

            else if (pos.NCategoryID == 8 || pos.NCategoryID == 9)
            {
                TblPackageGroupEntries pckGroupEntries = new TblPackageGroupEntries();
                pckGroupEntries.MainConnectionProvider = connProvider;

                foreach (DataRow r in pos.ReceiptItemsTable.Rows)
                {
                    string strPackageGroupCode = r["strCode"].ToString();
                    int nQuantity = ACMS.Convert.ToInt32(r["nQuantity"]);

                    DataTable table = pckGroupEntries.GetPackageCodeList(strPackageGroupCode);

                    if (table != null && table.Rows.Count > 0)
                    {
                        int packageQty = 0;

                        foreach (DataRow r2 in table.Rows)
                        {
                            packageQty = ACMS.Convert.ToInt32(r2["nQuantity"]);

                            for (int i = 0; i < nQuantity; i++)
                            {
                                for (int j = 0; j < packageQty; j++)
                                {
                                    DataRow rowToAdd = memberPackagetable.NewRow();

                                    MemberPackage.InitMemberPackageRowInPOS(rowToAdd, pos.StrReceiptNo,
                                        pos.StrMembershipID, r2["strPackageCode"].ToString(), "", false);
                                    rowToAdd["strUpgradeFrom"] = strUpgradeFrom;
                                    rowToAdd["strRemarks"] = strRemarks;
                                    memberPackagetable.Rows.Add(rowToAdd);
                                }
                            }
                        }
                    }
                }
                if (memberPackagetable.Rows.Count > 0)
                    memberPackage.SaveData(memberPackagetable);
            }
		}
        

		private void PostToMemberCreditPackage(ACMSDAL.ConnectionProvider connProvider, ACMSLogic.POS pos)
		{
            if (pos.NCategoryID == 7 || pos.NCategoryID == 36 || pos.NCategoryID == 37)
			{
				TblMemberCreditPackage memberCreditPackage = new TblMemberCreditPackage();
				memberCreditPackage.MainConnectionProvider = connProvider;
				
				DataTable memberCreditPackageTable = memberCreditPackage.FillSchema("Select * from tblMemberCreditPackage");
                string strUpgradeFrom = "";
                string strRemarks = "";
                foreach (DataRow dr in pos.WantToUpgradeMemberPackageTable.Rows)
                {
                    strRemarks += dr["strPackageCode"].ToString() + " / " + dr["strReceiptNo"].ToString() + " / " + dr["UsageBalAmt"].ToString() + ",";
                    if (dr["nCategoryID"].ToString() == "7" || dr["nCategoryID"].ToString() == "36" || dr["nCategoryID"].ToString() == "37")
                        strUpgradeFrom += dr["nPackageID"].ToString() + "(C),";
                    else if (dr["nCategoryID"].ToString() == "8" || dr["nCategoryID"].ToString() == "9")
                        strUpgradeFrom += dr["nPackageID"].ToString() + "(B),";
                    else
                        strUpgradeFrom += dr["nPackageID"].ToString() + ",";

                    if (ACMS.Convert.ToInt32(dr["nCategoryID"]) == 5 && dr["strFreePkgCode"] != DBNull.Value)
                    {
                        TblMemberPackage mp = new TblMemberPackage();
                        mp.MainConnectionProvider = connProvider;
                        DataTable freePkgTable = mp.LoadData("select * from tblMemberPackage where strReceiptNo=@strReceiptNo and strPackageCode =@strFreePackageCode ",
                            new string[] { "@strReceiptNo", "@strFreePackageCode" }, new object[] { dr["strReceiptNo"], dr["strFreePkgCode"].ToString() });

                        if (freePkgTable.Rows.Count > 0)
                        {
                            if (dr["nCategoryID"].ToString() == "7" || dr["nCategoryID"].ToString() == "36" || dr["nCategoryID"].ToString() == "37")
                                strUpgradeFrom += freePkgTable.Rows[0]["nPackageID"].ToString() + "(C),";
                            else if (dr["nCategoryID"].ToString() == "8" || dr["nCategoryID"].ToString() == "9")
                                strUpgradeFrom += freePkgTable.Rows[0]["nPackageID"].ToString() + "(B),";
                            else
                                strUpgradeFrom += freePkgTable.Rows[0]["nPackageID"].ToString() + ",";
                        }
                    }
                }                
                if (pos.WantToUpgradeMemberPackageTable.Rows.Count > 0)
                {
                    strUpgradeFrom = strUpgradeFrom.Remove(strUpgradeFrom.Length - 1, 1);
                    strRemarks = "Convert from: " + strRemarks.Remove(strRemarks.Length - 1, 1);
                }

				foreach (DataRow r in pos.ReceiptItemsTable.Rows)
				{
                    if (r["strCode"].ToString() != "JOINFEES" && r["strCode"].ToString() != "JOINFEE" && r["strCode"].ToString() != "FA")
                    {
                        int nQuantity = ACMS.Convert.ToInt32(r["nQuantity"]);

                        for (int i = 0; i < nQuantity; i++)
                        {
                            DataRow rowToAdd = memberCreditPackageTable.NewRow();

                            CreditAccount.InitMemberCreditPackageRowInPOS(rowToAdd, pos.StrReceiptNo, pos.StrMembershipID, r["strCode"].ToString(), false);
                            rowToAdd["strUpgradeFrom"] = strUpgradeFrom;
                            rowToAdd["strRemarks"] = strRemarks;
                            memberCreditPackageTable.Rows.Add(rowToAdd);
                        }
                    }
				}

				if (memberCreditPackageTable.Rows.Count > 0)
					memberCreditPackage.SaveData(memberCreditPackageTable);
			}
		}

		private void PostToStock(ACMSDAL.ConnectionProvider connProvider, DataTable TblQty, ACMSLogic.POS pos)
		{
			
				TblProductInventory proInven = new TblProductInventory();
                proInven.MainConnectionProvider = connProvider; 
            //SelectedGridItemChangedEventArgs();
						
				// deduct stock
				foreach (DataRow r in TblQty.Rows)
				{
					if (r["strCode"].ToString().ToUpper() != "REG")
					{
						int nQuantity = ACMS.Convert.ToInt32(r["nQuantity"]);
						proInven.IncreaseQuantity(r["strCode"].ToString(), pos.StrBranchCode, -nQuantity);
					}
				}			
		}
	}
	#endregion
	
	#region POS
	/// <summary>
	/// Summary description for POS.
	/// </summary>
	public class POS
	{
		
		//Derek Instalment Plan Need to add DataTable for tblPaymentPlan
        public DataTable myPaymentPlanTable;
		private DataTable myReceiptMasterTable;
		private DataTable myReceiptItemsTable;
		private DataTable myReceiptFreebieTable; // This is a table to store the Bill freebie for product.
		private DataTable myReceiptPackageTable; // This is a temp table to store the Bill freebie for package.
		private DataTable myReceiptItemsFreebieTable; // This is a table to store the Item freebie for product.
		private DataTable myReceiptItemsPackageTable; // This is a temp table to store the Item freebie for package.
		private DataTable myReceiptPaymentTable;
		private DataTable myPaymentTypeTable; // Just a Datatable that use to store the paymentType, Max 3 record;
		private DataTable myWantToUpgradeMemberPackageTable;
		private DataTable myGiroTable;
		private int myPOSCategoryID;
		private int myCategoryID;
		private int myEmployeeID;
        private int myTerminalID;
        private int myGIROID;
        private int myPackageID;
        private string myLocation;
		private int myShiftID;
		private  int myTaxID;
		private int myDisableColumnChangedCount = 0;
        private decimal myGSTRate, _MConvertAmount;
		private string myMembershipID,_newMemberID;
		private string myBranchCode;
		private int intCredit;
        private int myThisMonthBirthdayID;
        private string _StrDeposit = "";
        private int _NThisMonthBirthday,_NProrateDays, _ExtendGIROpkg;
		private DateTime _dtPackageStart;
        private string _StrBillReferenceNo = "";
        private bool myIsNeedMinTopUp = false;
		
		//private Action myAction;
		private int myStaffPurchaseCategoryID = -1;
		private bool myIsStaffPurchase = false;
		private POS.LockerAction myLockerAction;
        private POS.ForgetCardAction myForgetCardAction;
        private int myThisMonthBirthday;
        private string connectionString;
        private SqlConnection connection;
        private int _NQty;

		//Derek Instalment Plan Need to add DataTable for tblPaymentPlan
		private void ChangeReceipNo()
		{
			foreach (DataRow r in myReceiptItemsTable.Rows)
			{
				r["strReceiptNo"] = StrReceiptNo;
			}
			
			foreach (DataRow r in myReceiptFreebieTable.Rows)
			{
				r["strReceiptNo"] = StrReceiptNo;
			}

			foreach (DataRow r in myReceiptPackageTable.Rows)
			{
				r["strReceiptNo"] = StrReceiptNo;
			}

			foreach (DataRow r in myReceiptPaymentTable.Rows)
			{
				r["strReceiptNo"] = StrReceiptNo;
			}
		}

		internal POS(int nCategoryID, int nEmployeeID, string strMembershipID,
            string strBranchCode, int nterminalID, int nShiftID, string strLocation, int nPackageID, int nGIRO)
		{
			//
			// TODO: Add constructor logic here
			//
			myCategoryID = nCategoryID;
			myEmployeeID = nEmployeeID;
            myMembershipID = strMembershipID;
            myLocation = strLocation;
			myBranchCode = strBranchCode;
            myTerminalID = nterminalID;
            myPackageID = nPackageID;
			myShiftID= nShiftID;
			TblCategory sqlCategory = new TblCategory();
            if (nGIRO == 1)//2704
            {
                myGIROID = nGIRO;
            }
            else
            {
                myGIROID = 0;
            }
            sqlCategory.NCategoryID = myCategoryID;
			sqlCategory.SelectOne();
			myPOSCategoryID = sqlCategory.NPOSCategoryID.IsNull ? -1 : sqlCategory.NPOSCategoryID.Value;

			Init();
			myLockerAction = LockerAction.None;
			myForgetCardAction = ForgetCardAction.None;
            //2106
            TblMember sqlMember = new TblMember();
            if (!sqlMember.MembershipThisMonthBirtday(strMembershipID))
            {
                myThisMonthBirthdayID = 0;
            }
            else
            {
                myThisMonthBirthdayID = 1;
            }

            string hder = strMembershipID.Substring(0, 2);
				
			if (hder == "HQ")
			{
				string ID = strMembershipID.Substring(2, StrMembershipID.Length - 2);
					
				try
				{
					int numberID = int.Parse(ID);

					if (numberID > 999)
					{
						myIsStaffPurchase = true;
						myStaffPurchaseCategoryID = myCategoryID;
					}
				}
				catch
				{
					myIsStaffPurchase = false;
				}
			}
		}
			
		public enum Action
		{
			New, Edit
		}

		public enum LockerAction 
		{
			None, New, Extend, Return
		}

		public enum ForgetCardAction
		{
			None, ForgetCard, Refund
		}

		#region Property

		//read

		public DataTable GiroTable
		{
			get { return myGiroTable; }
		}

        //Derek Instalment Plan Need to add DataTable for tblPaymentPlan
        public DataTable PaymentPlanTable
        {
            get { return myPaymentPlanTable; }
        }

		public DataTable ReceiptMasterTable
		{
			get { return myReceiptMasterTable; }
		}

		public DataTable ReceiptItemsTable
		{
			get { return myReceiptItemsTable; }
		}

		public DataTable ReceiptFreebieTable
		{
			get { return myReceiptFreebieTable; }
		}

		public DataTable ReceiptPackageTable
		{
			get { return myReceiptPackageTable; }
		}

		public DataTable ReceiptPaymentTable
		{
			get { return myReceiptPaymentTable; }
		}

		public DataTable PaymentTypeTable
		{
			get { return myPaymentTypeTable; }
		}

		public DataTable ReceiptItemsFreebieProductTable
		{
			get { return myReceiptItemsFreebieTable; }
		}

		public DataTable ReceiptItemsFreebiePackageTable
		{
			get { return myReceiptItemsPackageTable; }
		}

		public DataTable WantToUpgradeMemberPackageTable
		{
			get { return myWantToUpgradeMemberPackageTable; }
		}

		public DataRow WantToUpgradeMemberPackageRow
		{
			get { return myWantToUpgradeMemberPackageTable.Rows[0]; }
		}

		public POS.LockerAction POSLockerAction
		{
			get { return myLockerAction; }
			set { myLockerAction = value; }
		}

		public POS.ForgetCardAction POSForgetCardAction
		{
			get { return myForgetCardAction; }
			set { myForgetCardAction = value; }
		}

		public int NProrateDays
		{
			get
			{
				return _NProrateDays;
			}
			set
			{				
				_NProrateDays = value;
			}
		}
       
        public string StrBillReferenceNo
        {
            get { return _StrBillReferenceNo; }
            set { _StrBillReferenceNo = value; }
        }

		public string StrNewMembershipID
		{
			get { return _newMemberID; }
			set	{_newMemberID = value;}
		}

		public DateTime dtPackageStart
		{
			get
			{
				return _dtPackageStart;
			}
			set
			{				
				_dtPackageStart = value;
			}
		}
		public string StrReceiptNo
		{
			get { return myReceiptMasterTable.Rows[0]["strReceiptNo"].ToString(); }
			set { myReceiptMasterTable.Rows[0]["strReceiptNo"] = value;}
		}
		
		public bool IsStaffPurchase
		{
			get {return myIsStaffPurchase; }
		}

        public bool IsNeedMinTopUp
        {
            get { return myIsNeedMinTopUp; }
            set { myIsNeedMinTopUp = value; }
        }
		
		public int StaffPurchaseCategoryID
		{
			get {return myStaffPurchaseCategoryID;}
		}

		public string StrMembershipID
		{
			get { return myReceiptMasterTable.Rows[0]["strMembershipID"].ToString(); }
		}
		
		

		public string StrBranchCode
		{
			get { return myReceiptMasterTable.Rows[0]["strBranchCode"].ToString(); }
		}

        public string StrLocation //1503
        {
            get { return myReceiptMasterTable.Rows[0]["StrLocation"].ToString(); }
        }

        public int nPackageID //2103
        {
			get { return ACMS.Convert.ToInt32(myReceiptMasterTable.Rows[0]["nPackageID"]); }
        }

        public DateTime dtDateTime//2103
        {
            get { return ACMS.Convert.ToDateTime(myReceiptMasterTable.Rows[0]["dtDateTime"]); }
        }


		public int NCategoryID
        {
			get { return ACMS.Convert.ToInt32(myReceiptMasterTable.Rows[0]["nCategoryID"]); }
			set { myReceiptMasterTable.Rows[0]["nCategoryID"] =value; }
		}

		public int NExtendGIROpkg
		{
			get { return _ExtendGIROpkg; }
			set { _ExtendGIROpkg =value; }
		}

		public int NPOSCategoryID
		{
			get { return myPOSCategoryID; }
		}

		public DateTime DtDate
		{
			get { return ACMS.Convert.ToDateTime(myReceiptMasterTable.Rows[0]["dtDate"]); }
		}

		public int NCashierID
		{
			get { return ACMS.Convert.ToInt32(myReceiptMasterTable.Rows[0]["nCashierID"]); }
		}
	

		public int NShiftID
		{
			get { return ACMS.Convert.ToInt32(myReceiptMasterTable.Rows[0]["nShiftID"]); }
		}

		public int NTerminalID
		{
			get { return ACMS.Convert.ToInt32(myReceiptMasterTable.Rows[0]["nTerminalID"]); }
		}

		public int NTaxID
		{
			get { return ACMS.Convert.ToInt32(myReceiptMasterTable.Rows[0]["nTaxID"]); }
		}

		//read and write
		public ACMS.DBInt32 NSalespersonID
		{
			get { return ACMS.Convert.ToDBInt32(myReceiptMasterTable.Rows[0]["nSalespersonID"]); }
			set 
			{
				if (value == 0)
					myReceiptMasterTable.Rows[0]["nSalespersonID"] = 0;
				else
					myReceiptMasterTable.Rows[0]["nSalespersonID"] = ACMS.Convert.ToDBObject(value); 
			}
		}

		public ACMS.DBDecimal MNettAmount
		{
			get { return ACMS.Convert.ToDBDecimal(myReceiptMasterTable.Rows[0]["mNettAmount"]); }
		}

		public ACMS.DBDecimal MGSTAmount
		{
			get { return ACMS.Convert.ToDBDecimal(myReceiptMasterTable.Rows[0]["mGSTAmount"]); }
		}

		public ACMS.DBDecimal MTotalAmount
		{
			get { return ACMS.Convert.ToDBDecimal(myReceiptMasterTable.Rows[0]["mTotalAmount"]); }
			set { myReceiptMasterTable.Rows[0]["mTotalAmount"] = ACMS.Convert.ToDBObject(value); }
		}

		public ACMS.DBDecimal MOutstandingAmount
		{
			get { return ACMS.Convert.ToDBDecimal(myReceiptMasterTable.Rows[0]["mOutstandingAmount"]); }
            set { myReceiptMasterTable.Rows[0]["mOutstandingAmount"] = Convert.ToDecimal(value); }
		}

		public ACMS.DBDecimal MBalance
		{
			get { return ACMS.Convert.ToDBDecimal(myReceiptMasterTable.Rows[0]["mBalance"]); }
		}

		public ACMS.DBString StrDiscountCode
		{
			get { return ACMS.Convert.ToDBString(myReceiptMasterTable.Rows[0]["strDiscountCode"]); }
			set { myReceiptMasterTable.Rows[0]["strDiscountCode"] = ACMS.Convert.ToDBObject(value); }
		}

		public ACMS.DBString StrFreebieCode
		{
			get { return ACMS.Convert.ToDBString(myReceiptMasterTable.Rows[0]["strFreebieCode"]); }
			set { myReceiptMasterTable.Rows[0]["strFreebieCode"] = ACMS.Convert.ToDBObject(value); }
		}

	    public string StrDeposit
	    {
		    get { return _StrDeposit; }
		    set { _StrDeposit = value; }
	    }

        public int NQty
        {
            get { return _NQty; }
            set { _NQty = value; }
        }

		public ACMS.DBInt32 NVoucherTypeID
		{
			get { return ACMS.Convert.ToDBInt32(myReceiptMasterTable.Rows[0]["nVoucherTypeID"]); }
			set { myReceiptMasterTable.Rows[0]["nVoucherTypeID"] = ACMS.Convert.ToDBObject(value); }
		}

		public ACMS.DBDecimal MVoucherAmount
		{
			get { return ACMS.Convert.ToDBDecimal(myReceiptMasterTable.Rows[0]["mVoucherAmount"]); }
			set { myReceiptMasterTable.Rows[0]["mVoucherAmount"] = ACMS.Convert.ToDBObject(value); }
		}

        public decimal MConvertAmount
        {
            get { return _MConvertAmount; }
            set { _MConvertAmount = value; }
        }

		public ACMS.DBInt32 NTherapistID
		{
			get { return ACMS.Convert.ToDBInt32(myReceiptMasterTable.Rows[0]["nTherapistID"]); }
			set 
			{ 
				if (value == 0)	
					myReceiptMasterTable.Rows[0]["nTherapistID"] = 0;
				else
					myReceiptMasterTable.Rows[0]["nTherapistID"] = ACMS.Convert.ToDBObject(value); 
			}
		}

		public ACMS.DBString StrRewardsCode
		{
			get { return ACMS.Convert.ToDBString(myReceiptMasterTable.Rows[0]["strRewardsCode"]); }
			set { myReceiptMasterTable.Rows[0]["strRewardsCode"] = ACMS.Convert.ToDBObject(value); }
		}

		public bool FVoid
		{
			get { return ACMS.Convert.ToBoolean(myReceiptMasterTable.Rows[0]["fVoid"]); }
			set { myReceiptMasterTable.Rows[0]["fVoid"] = ACMS.Convert.ToBoolean(value); }
		}


		public ACMS.DBString StrReferenceNo
		{
			get { return ACMS.Convert.ToDBString(myReceiptMasterTable.Rows[0]["strReferenceNo"]); }
			set { myReceiptMasterTable.Rows[0]["strReferenceNo"] = ACMS.Convert.ToDBObject(value); }
		}

		public ACMS.DBString StrParentReceiptNo
		{
			get { return ACMS.Convert.ToDBString(myReceiptMasterTable.Rows[0]["strParentReceiptNo"]); }
			set { myReceiptMasterTable.Rows[0]["strParentReceiptNo"] = ACMS.Convert.ToDBObject(value); }
		}

		public ACMS.DBString StrChildReceiptNo
		{
			get { return ACMS.Convert.ToDBString(myReceiptMasterTable.Rows[0]["strChildReceiptNo"]); }
			set { myReceiptMasterTable.Rows[0]["strChildReceiptNo"] = ACMS.Convert.ToDBObject(value); }
		}

		public ACMS.DBString StrRemarks
		{
			get { return ACMS.Convert.ToDBString(myReceiptMasterTable.Rows[0]["strRemarks"]); }
			set { myReceiptMasterTable.Rows[0]["strRemarks"] = ACMS.Convert.ToDBObject(value); }
		}

		#endregion

		public void NewBillDiscount(string promotionCode)
		{
			if (promotionCode != "")
			{
				try
				{
					this.StrDiscountCode = promotionCode;
					DisableColumnChanged();
					RecalculateAll();
				}
				finally
				{
					EnableColumnChanged();
				}
			}
		}

		public void NewBillDeposit(string StrDepositReceipt)
		{
			if (StrDepositReceipt != "")
			{
				try
				{
					this.StrDeposit= StrDepositReceipt;
                    this.StrParentReceiptNo = StrDepositReceipt;
                    //this.MConvertAmount 
					DisableColumnChanged();
					RecalculateAll();
				}
				finally
				{
					EnableColumnChanged();
				}
			}
		}

		public void Delete(int nEntryID)
		{
			DataRow[] receiptItemToDelete = myReceiptItemsTable.Select("nEntryID = " + nEntryID.ToString(), "", DataViewRowState.CurrentRows);
			
			string strCode = "";
			decimal oldPackagePriceToRestore = 0;
			decimal oldPackageUsageToRestore = 0;

			if (receiptItemToDelete.Length == 1)
			{
				strCode = receiptItemToDelete[0]["strCode"].ToString();
				oldPackagePriceToRestore = ACMS.Convert.ToDecimal(receiptItemToDelete[0]["OldPackagePrice"]);
				oldPackageUsageToRestore = ACMS.Convert.ToDecimal(receiptItemToDelete[0]["OldPackageUsage"]);
				receiptItemToDelete[0].Delete();
			}
			else
				throw new Exception("Unable to find the row to delete.");
		
			DataRow[] rowsToDelete = myReceiptItemsFreebieTable.Select("nEntryID = " + nEntryID.ToString(), "", DataViewRowState.CurrentRows);	
			foreach (DataRow r in rowsToDelete)
				r.Delete();

			DataRow[] rowsToDelete2 = myReceiptItemsPackageTable.Select("", "", DataViewRowState.CurrentRows);
			foreach (DataRow r in rowsToDelete2)
				r.Delete();
			
			if (NCategoryID == 15)
			{
				receiptItemToDelete = myReceiptItemsTable.Select("strCode = '" + strCode + "'", "", DataViewRowState.CurrentRows);

				if (receiptItemToDelete.Length == 1)
					receiptItemToDelete[0].Delete();
			}
			else if (NCategoryID == 2)
			{
				DataRow[] rowToDelete3 = myGiroTable.Select("nEntryID = " + nEntryID.ToString(), "", DataViewRowState.CurrentRows);

				foreach (DataRow r in rowToDelete3)
					r.Delete();

				myGiroTable.AcceptChanges();
			}
			else if (NCategoryID == 10)
			{
				WantToUpgradeMemberPackageRow["OldMemberPackageListPrice"] =
					ACMS.Convert.ToDecimal(WantToUpgradeMemberPackageRow["OldMemberPackageListPrice"]) + oldPackagePriceToRestore;
				
				WantToUpgradeMemberPackageRow["OldMemberPackageUsage"] =
					ACMS.Convert.ToDecimal(WantToUpgradeMemberPackageRow["OldMemberPackageUsage"]) + oldPackageUsageToRestore;

				foreach (DataRow r in myReceiptItemsTable.Rows)
				{
					if (r.RowState != DataRowState.Deleted)
						CalculateSubTotal(r);
				}

				if (myReceiptItemsTable.Rows.Count == 0)
					myWantToUpgradeMemberPackageTable.Rows.Clear();
			}

			if (myReceiptItemsTable.Rows.Count == 0)
			{
				myLockerAction = ACMSLogic.POS.LockerAction.None;
				myForgetCardAction = ACMSLogic.POS.ForgetCardAction.None;
			}

            if (myReceiptItemsTable.Rows.Count == 0 && NCategoryID == 0)
            {
                myReceiptMasterTable.Rows[0]["mTotalAmount"] = 0;
            } 
		
			RecalculateAll();
			myReceiptItemsFreebieTable.AcceptChanges();
			myReceiptItemsPackageTable.AcceptChanges();

		}

		public void AddNewIPP(string strBankCode, int nMonths,
			string strCreditCardNo, string strMerchantNo)
		{
			TblIPP sqlIPP = new TblIPP();
			DataTable table = sqlIPP.FillSchema("Select * from tblIPP");
			DataRow r = table.NewRow();
			r["StrMembershipID"] = StrMembershipID;
			r["DtDate"] = DateTime.Today.Date;
			r["StrBranchCode"] = StrBranchCode;
			r["StrBankCode"] = strBankCode;
			r["NMonths"] = nMonths;
			r["strCreditCardNo"] = strCreditCardNo;
			r["strMerchantNo"] = strMerchantNo;
			r["nIPPStatus"] = 3;
			
			table.Rows.Add(r);

			sqlIPP.SaveData(table);
		}

		private void NewBillReceiptFreebies(string strPromotionCode, string strCode, bool isPackage)
		{
            //myReceiptFreebieTable.Clear();
            //myReceiptPackageTable.Clear();
			if (isPackage)
			{
				DataRow r = myReceiptPackageTable.NewRow();
				r["strPromotionCode"] = strPromotionCode;
				r["strReceiptNo"] = this.StrReceiptNo;
				r["strPackageCode"] = strCode;
				myReceiptPackageTable.Rows.Add(r);	
			}
			else
			{
				DataRow r = myReceiptFreebieTable.NewRow();
				r["strReceiptNo"] = this.StrReceiptNo;
				r["strPromotionCode"] = strPromotionCode;
				r["strItemCode"] = strCode;
				myReceiptFreebieTable.Rows.Add(r);
			}
		}

		public void NewBillReceiptFreebies(DataRow[] rowsToAdd, string promotionCode, bool isPackage)
		{
            if (isPackage)
                myReceiptPackageTable.Clear();
            else
                myReceiptFreebieTable.Clear();            

			foreach (DataRow r in rowsToAdd)
			{
                if (isPackage)
                {
                    for (int i = 0; i < Convert.ToInt16(r["nQuantity"]); i++)
                    {
                        NewBillReceiptFreebies(promotionCode, r["strPackageCode"].ToString(), isPackage);
                    }
                }                    
                else
                {
                    for (int i=0; i<Convert.ToInt16(r["nQuantity"]);i++)
                    {
                        NewBillReceiptFreebies(promotionCode, r["strProductCode"].ToString(), isPackage);
                    }                    
                }				
			}
			
			this.StrFreebieCode = promotionCode;
		}

		private void NewItemReceiptFreebies(int nEntryID, 
			string strCode, string promotionCode, bool isPackage)
		{
            //myReceiptItemsPackageTable.Clear();
            //myReceiptItemsFreebieTable.Clear();
			if (isPackage)
			{
				DataRow r = myReceiptItemsPackageTable.NewRow();
				r["nEntryID"] = nEntryID;
				r["strPackageCode"] = strCode;
				r["strPromotionCode"] = promotionCode;
				myReceiptItemsPackageTable.Rows.Add(r);
			}
			else
			{
				DataRow r = myReceiptItemsFreebieTable.NewRow();
				r["nEntryID"] = nEntryID;
				r["strProductCode"] = strCode;
				r["strPromotionCode"] = promotionCode;
				myReceiptItemsFreebieTable.Rows.Add(r);
			}
		}

		public void EditItemFreebieAndDiscount(DataRow freeBieEntryRow, 
			DataRow[] rowsToAddToReceiptItemsFreebieTable,  
			string promotionCode, string discountPromotionCode, bool isPackage)
		{
           // myReceiptItemsTable.Clear();
			int nEntryID = ACMS.Convert.ToInt32(freeBieEntryRow["nEntryID"]);

			if (rowsToAddToReceiptItemsFreebieTable != null && 
				rowsToAddToReceiptItemsFreebieTable.Length > 0 )
			{
				DataRow[] rowsToDelete1 = myReceiptItemsFreebieTable.Select("nEntryID = "+ nEntryID.ToString(), "", DataViewRowState.CurrentRows);
				if (rowsToDelete1.Length > 0)
				{
					//foreach (DataRow r in rowsToDelete1)
						//r.Delete();
				}

				DataRow[] rowsToDelete2 = myReceiptItemsPackageTable.Select("nEntryID = "+nEntryID.ToString(), "", DataViewRowState.CurrentRows);
				if (rowsToDelete2.Length > 0)
				{
					//foreach (DataRow r in rowsToDelete2)
						//r.Delete();
				}


				foreach (DataRow r in rowsToAddToReceiptItemsFreebieTable)
				{
                    if (isPackage)
                    {
                        for (int i = 0; i < Convert.ToInt16(r["nQuantity"]); i++)
                        {
                            NewItemReceiptFreebies(nEntryID, r["strPackageCode"].ToString(), promotionCode, isPackage);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < Convert.ToInt16(r["nQuantity"]); i++)
                        {
                            NewItemReceiptFreebies(nEntryID, r["strProductCode"].ToString(), promotionCode, isPackage);
                        }                        
                    }
					
				}
			}

			POSEntries posEntries = new POSEntries(freeBieEntryRow);
			if (promotionCode != "")
				posEntries.StrFreebieCode = promotionCode;
			if (discountPromotionCode != "")
				posEntries.StrDiscountCode = discountPromotionCode;
		}

        public void EditItemFreebieAndDiscount(string strFreePackage)
        {
            //myReceiptItemsTable.Clear();
            DataRow newEntries = myReceiptItemsTable.NewRow();
            NewItemReceiptFreebies(ACMS.Convert.ToInt32(newEntries["nEntryID"]), strFreePackage, "Auto Insert", true);
        }
		public bool CheckPackage(string packageWantToUpgrade, int nCategoryID_of_PackageWantToUpgrade)
		{
			// 1) Check Package to upgrade to have the class/service that no allow in current branch
			// Check tblPackageClass or tblPackageService
			
			// from here, we can get a list of strClassCode that already been used by member	
			DataTable attendedClassCodetable = GetAttendedClassCode(ACMS.Convert.ToInt32(myWantToUpgradeMemberPackageTable.Rows[0]["nPackageID"]));

			// from here, we can get a list of strClassCode that already been used by member
			DataTable attendedServiceCodetable = GetAttendedServiceCode(ACMS.Convert.ToInt32(myWantToUpgradeMemberPackageTable.Rows[0]["nPackageID"]));

			if (attendedClassCodetable == null) attendedClassCodetable = new DataTable();
			if (attendedServiceCodetable == null) attendedServiceCodetable = new DataTable();

			if (attendedClassCodetable.Rows.Count > 0 ||
				attendedServiceCodetable.Rows.Count > 0)
			{
				if (nCategoryID_of_PackageWantToUpgrade == 1 ||
					nCategoryID_of_PackageWantToUpgrade == 2 ||
					nCategoryID_of_PackageWantToUpgrade == 3)
				{
				
					TblPackageClass pkgClass = new TblPackageClass();

					string strClassCode = "";
				
					foreach (DataRow r in attendedClassCodetable.Rows)
					{
						strClassCode= r["strClassCode"].ToString();
						pkgClass.StrClassCode= strClassCode;
						DataTable tempTable = pkgClass.SelectAllWstrClassCodeLogic();

						//if this tempTable no have packageWantToUpgrade, then means cannot update..
						DataRow[] rowList = tempTable.Select("strPackageCode = '"+packageWantToUpgrade+"'");

						if (rowList.Length == 0)
						{
                            //katty request due to BM001(88) treatment
							MessageBox.Show(string.Format("Class Code <{0}> that been attended before is not allow in Package {1}, purchase of single session is required. ", strClassCode, packageWantToUpgrade), "Upgrade Failed");
							return false;
						}
					}
				}
				else if (nCategoryID_of_PackageWantToUpgrade == 4 ||
					nCategoryID_of_PackageWantToUpgrade == 5 ||
					nCategoryID_of_PackageWantToUpgrade == 6 )
				{

					TblPackageService pkgSvr = new TblPackageService();

					string strServiceCode = "";
				
					foreach (DataRow r in attendedServiceCodetable.Rows)
					{
						strServiceCode = r["strServiceCode"].ToString();
						pkgSvr.StrServiceCode = strServiceCode;
						DataTable tempTable = pkgSvr.SelectAllWstrServiceCodeLogic();

						//if this tempTable no have packageWantToUpgrade, then means cannot update..
						DataRow[] rowList = tempTable.Select("strPackageCode = '"+packageWantToUpgrade+"'");
						if (rowList.Length == 0)
						{
                            //katty request due to BM001(88) treatment
							//MessageBox.Show(string.Format(" Service Code <{0}> that been used before is not allow in Package {1}, purchase of single session is required. ", strServiceCode, packageWantToUpgrade), "Upgrade Failed");
							return true;
						}
					}
				}
			}
			
            			
			
			// 2) Check whether old package is been used.
			//  2a) If been used, check whether the used Class/Service 
			//		(* read comment below on how to get what class/service been use) is include in that 
			//		upgraded package allow list (check tblPackageClass/tblPackageService)
            
			//		2ai) If any of used class/service is no include, 
			//			 prompt msg that purchase of single session required
			//      2aii) If one of the used class/service is included but 
			//            the others no used class/service no included, then can upgrade.
			//		2aiii) If all of the used class/service include, then can upgrade..
			//  2b) if no been used, then can upgrade.
			   

			// * How to get attended class/used service
			return true;
		}

		public void CheckPackageWhenSave(string packageWantToUpgrade, int oldPackageID)
		{
			// 1) Check Package to upgrade to have the class/service that no allow in current branch
			// Check tblPackageClass or tblPackageService
			
			// from here, we can get a list of strClassCode that already been used by member	
			DataTable attendedClassCodetable = GetAttendedClassCode(oldPackageID);

			// from here, we can get a list of strClassCode that already been used by member
			DataTable attendedServiceCodetable = GetAttendedServiceCode(oldPackageID);

			if (attendedClassCodetable == null) attendedClassCodetable = new DataTable();
			if (attendedServiceCodetable == null) attendedServiceCodetable = new DataTable();

			if (attendedClassCodetable.Rows.Count > 0 ||
				attendedServiceCodetable.Rows.Count > 0)
			{	
				TblPackageClass pkgClass = new TblPackageClass();

				string strClassCode = "";
				
				foreach (DataRow r in attendedClassCodetable.Rows)
				{
					strClassCode= r["strClassCode"].ToString();
					pkgClass.StrClassCode= strClassCode;
					DataTable tempTable = pkgClass.SelectAllWstrClassCodeLogic();

					//if this tempTable no have packageWantToUpgrade, then means cannot update..
					DataRow[] rowList = tempTable.Select("strPackageCode = '"+packageWantToUpgrade+"'");

					if (rowList.Length == 0)
					{
						throw new Exception(string.Format("Class Code <{0}> that been attended before is not allow in Package {1}, purchase of single session is required. ", strClassCode, packageWantToUpgrade));
					}
				}
			
				TblPackageService pkgSvr = new TblPackageService();

				string strServiceCode = "";
				
				foreach (DataRow r in attendedServiceCodetable.Rows)
				{
					strServiceCode = r["strServiceCode"].ToString();
					pkgSvr.StrServiceCode = strServiceCode;
					DataTable tempTable = pkgSvr.SelectAllWstrServiceCodeLogic();

					//if this tempTable no have packageWantToUpgrade, then means cannot update..
					DataRow[] rowList = tempTable.Select("strPackageCode = '"+packageWantToUpgrade+"'");
					if (rowList.Length == 0)
					{
						//throw new Exception(string.Format(" Service Code <{0}> that been used before is not allow in Package {1}, purchase of single session is required. ", strServiceCode, packageWantToUpgrade));
					}
				}
			}
			
            			
			
			// 2) Check whether old package is been used.
			//  2a) If been used, check whether the used Class/Service 
			//		(* read comment below on how to get what class/service been use) is include in that 
			//		upgraded package allow list (check tblPackageClass/tblPackageService)
            
			//		2ai) If any of used class/service is no include, 
			//			 prompt msg that purchase of single session required
			//      2aii) If one of the used class/service is included but 
			//            the others no used class/service no included, then can upgrade.
			//		2aiii) If all of the used class/service include, then can upgrade..
			//  2b) if no been used, then can upgrade.
			   

			// * How to get attended class/used service
		}

		internal DataTable GetAttendedClassCode(int nPackageID)
		{
			TblClassAttendance classAttendance = new TblClassAttendance();
			return classAttendance.GetValidClassCodeBasePackageID(nPackageID);

		}

		internal DataTable GetAttendedServiceCode(int nPackageID)
		{
			TblServiceSession serviceSession = new TblServiceSession();
			return serviceSession.GetValidServiceCodeBasePackageID(nPackageID);
			
		}
		
		public void NewReceiptEntryForUpgrade(DataRow[] rowsToAdd, 
			DataRow wantToUpgradeMemberPackageRow)
		{	
			if (NCategoryID == 10)
			{
				if (myWantToUpgradeMemberPackageTable.Rows.Count == 1)
				{
					DataRow[] tempRow = myWantToUpgradeMemberPackageTable.Select("nPackageID = " + wantToUpgradeMemberPackageRow["nPackageID"].ToString(), "", DataViewRowState.CurrentRows);
					if (tempRow.Length == 0)
					{
						DialogResult result = MessageBox.Show("Only one package is allowed to upgrade (per receipt). Do you want system to clear the package that you upgraded just now?", "Warning",
							MessageBoxButtons.YesNo);

						if (result == DialogResult.Yes)
						{
							myReceiptItemsTable.Rows.Clear();
							myReceiptFreebieTable.Rows.Clear(); // This is a table to store the Bill freebie for product.
							myReceiptPackageTable.Rows.Clear(); // This is a temp table to store the Bill freebie for package.
							myReceiptItemsFreebieTable.Rows.Clear(); // This is a table to store the Item freebie for product.
							myReceiptItemsPackageTable.Rows.Clear(); // This is a temp table to store the Item freebie for package.
							myReceiptPaymentTable.Rows.Clear();
							myPaymentTypeTable.Rows.Clear(); // Just a Datatable that use to store the paymentType, Max 3 record;
							myWantToUpgradeMemberPackageTable.Rows.Clear();
							myGiroTable.Rows.Clear();
						}
						else
							return;
					}
				}

				myWantToUpgradeMemberPackageTable.Rows.Clear();

				myWantToUpgradeMemberPackageTable.ImportRow(wantToUpgradeMemberPackageRow);
				
				decimal useService = ACMS.Convert.ToDecimal(WantToUpgradeMemberPackageRow["nMaxSession"]) -
					ACMS.Convert.ToDecimal(WantToUpgradeMemberPackageRow["Balance"]) ;
						
				decimal mBaseUnitPrice = ACMS.Convert.ToDecimal(WantToUpgradeMemberPackageRow["mBaseUnitPrice"]);
					
				WantToUpgradeMemberPackageRow["OldMemberPackageUsage"] = mBaseUnitPrice * useService;

				WantToUpgradeMemberPackageRow["OldMemberPackageListPrice"] = WantToUpgradeMemberPackageRow["mListPrice"];

				foreach (DataRow r in myReceiptItemsTable.Rows)
				{
						r["OldPackagePrice"] = 0;
						r["OldPackageUsage"] = 0;
				}

				foreach (DataRow r in rowsToAdd)
				{
					if (!CheckPackage(r["strPackageCode"].ToString(), ACMS.Convert.ToInt32(r["nCategoryID"])))
						return;

					DataRow[] rowFind = myReceiptItemsTable.Select("strCode = '" +r["strPackageCode"].ToString()+"'", "", DataViewRowState.CurrentRows);
				
					if (rowFind.Length > 0)
					{
						rowFind[0]["nQuantity"]  = ACMS.Convert.ToInt32(rowFind[0]["nQuantity"]) + 1;
					}
					else
					{
						POSEntries entry = NewReceiptEntry(r["strPackageCode"].ToString(),
							-1, r["strDescription"].ToString(),
							1, ACMS.Convert.ToDecimal(r["mListPrice"]), "");
					}
				}
			}	
		}
        public void NewReceiptEntryForUpgrade2(DataRow[] rowsToAdd, string strRemark)
        {
            myWantToUpgradeMemberPackageTable.Clear();
            foreach (DataRow r in rowsToAdd)
            {
                myWantToUpgradeMemberPackageTable.ImportRow(r);                
            }
        }

        //start 04/03 jackie
        public void NewReceiptEntryForConvert(DataRow[] rowsToAdd,
    DataRow wantToUpgradeMemberPackageRow)
        {
            if (NCategoryID == 35)
            {
                if (myWantToUpgradeMemberPackageTable.Rows.Count == 1)
                {
                    DataRow[] tempRow = myWantToUpgradeMemberPackageTable.Select("nPackageID = " + wantToUpgradeMemberPackageRow["nPackageID"].ToString(), "", DataViewRowState.CurrentRows);
                    if (tempRow.Length == 0)
                    {
                        DialogResult result = MessageBox.Show("Only one package is allowed to upgrade (per receipt). Do you want system to clear the package that you upgraded just now?", "Warning",
                            MessageBoxButtons.YesNo);

                        if (result == DialogResult.Yes)
                        {
                            myReceiptItemsTable.Rows.Clear();
                            myReceiptFreebieTable.Rows.Clear(); // This is a table to store the Bill freebie for product.
                            myReceiptPackageTable.Rows.Clear(); // This is a temp table to store the Bill freebie for package.
                            myReceiptItemsFreebieTable.Rows.Clear(); // This is a table to store the Item freebie for product.
                            myReceiptItemsPackageTable.Rows.Clear(); // This is a temp table to store the Item freebie for package.
                            myReceiptPaymentTable.Rows.Clear();
                            myPaymentTypeTable.Rows.Clear(); // Just a Datatable that use to store the paymentType, Max 3 record;
                            myWantToUpgradeMemberPackageTable.Rows.Clear();
                            myGiroTable.Rows.Clear();
                        }
                        else
                            return;
                    }
                }

                myWantToUpgradeMemberPackageTable.Rows.Clear();

                myWantToUpgradeMemberPackageTable.ImportRow(wantToUpgradeMemberPackageRow);

                decimal useService = ACMS.Convert.ToDecimal(WantToUpgradeMemberPackageRow["nMaxSession"]) -
                    ACMS.Convert.ToDecimal(WantToUpgradeMemberPackageRow["Balance"]);

                decimal mBaseUnitPrice = ACMS.Convert.ToDecimal(WantToUpgradeMemberPackageRow["mBaseUnitPrice"]);

                WantToUpgradeMemberPackageRow["OldMemberPackageUsage"] = mBaseUnitPrice * useService;

                WantToUpgradeMemberPackageRow["OldMemberPackageListPrice"] = WantToUpgradeMemberPackageRow["mListPrice"];

                foreach (DataRow r in myReceiptItemsTable.Rows)
                {
                    r["OldPackagePrice"] = 0;
                    r["OldPackageUsage"] = 0;
                }

                foreach (DataRow r in rowsToAdd)
                {
                    if (!CheckPackage(r["strPackageCode"].ToString(), ACMS.Convert.ToInt32(r["nCategoryID"])))
                        return;

                    DataRow[] rowFind = myReceiptItemsTable.Select("strCode = '" + r["strPackageCode"].ToString() + "'", "", DataViewRowState.CurrentRows);

                    if (rowFind.Length > 0)
                    {
                        rowFind[0]["nQuantity"] = ACMS.Convert.ToInt32(rowFind[0]["nQuantity"]) + 1;
                    }
                    else
                    {
                        POSEntries entry = NewReceiptEntry(r["strPackageCode"].ToString(),
                            -1, r["strDescription"].ToString(),
                            1, ACMS.Convert.ToDecimal(r["mListPrice"]), "");
                    }
                }
            }
        }
        //end jackie 04/03
		public POSEntries NewReceiptEntry(string strCode, int nCategID, string strDes,
			int nQty, decimal unitPrice, string referenceNo)
		{
			DataRow newEntries = myReceiptItemsTable.NewRow();
			newEntries["strCode"] = strCode;
			if (NCategoryID == 22)
				newEntries["nCategoryID"] = myStaffPurchaseCategoryID;
			
			if (NCategoryID == 0)
			{
                //Derek Instalment Plan
                MTotalAmount = decimal.Round(unitPrice, 2);
				newEntries["mUnitPrice"] = unitPrice / (1 + myGSTRate);

			}
			else
			{
				newEntries["mUnitPrice"] = unitPrice;
			}

			if(NoCredit != 0)
				newEntries["OldCreditPackge"] = NoCredit;

			newEntries["strDescription"] = strDes;
			//newEntries["strParentReceiptNo"] = strDes;
			newEntries["nQuantity"] = nQty;
			
			newEntries["strReferenceNo"] = referenceNo;
			newEntries["strReceiptNo"] = this.StrReceiptNo;
			myReceiptItemsTable.Rows.Add(newEntries);
			newEntries["nTempEntryID"] = newEntries["nEntryID"];

            if (NCategoryID == 12)
            {        
                if (this.NThisMonthBirthday==1)
                {
                    DialogResult result1 = MessageBox.Show("Member is having birthday this months and having 30% discount. Do you want to utilies?", "Warning",
                    MessageBoxButtons.YesNo);

                    if (result1 == DialogResult.Yes)
                        newEntries["strDiscountCode"] = "090018SPD";                    
                }
            }

			CalculateSubTotal(newEntries);
			RecalculateAll();
		
			POSEntries posEntries = new POSEntries(newEntries);
			return posEntries;
		}

		public POSEntries NewReceiptEntry(string strCode, int nCategID, string strDes,
			int nQty, decimal unitPrice, string referenceNo,string _strCardHolder,string _strTypeCard
			,string _nCreditCardNo)
			
		{
			DataRow newEntries = myReceiptItemsTable.NewRow();
			newEntries["strCode"] = strCode;
			if (NCategoryID == 22)
				newEntries["nCategoryID"] = myStaffPurchaseCategoryID;
			newEntries["strDescription"] = strDes;
			newEntries["nQuantity"] = nQty;
			newEntries["mUnitPrice"] = unitPrice;
			newEntries["strReferenceNo"] = referenceNo;
			newEntries["strReceiptNo"] = this.StrReceiptNo;

			myReceiptItemsTable.Rows.Add(newEntries);
			newEntries["nTempEntryID"] = newEntries["nEntryID"];
			CalculateSubTotal(newEntries);
			RecalculateAll();
			POSEntries posEntries = new POSEntries(newEntries);

			if ((NCategoryID == 2) || (NCategoryID == 34))
			{
				DataRow newGiroEntry = myGiroTable.NewRow();
				newGiroEntry["strCardHolderName"] = _strCardHolder;
				newGiroEntry["strTypeofCard"] = _strTypeCard;
				newGiroEntry["nCreditCard"] = _nCreditCardNo;
				//newGiroEntry["dtCreditCardExpired"] = _dtCardExpiration;
				newGiroEntry["strVerificationNo"] = "-";
				
				int nEntryID = posEntries.NEntryID;
				newGiroEntry["nEntryID"] = nEntryID;
				myGiroTable.Rows.Add(newGiroEntry);

			}
			return posEntries;
		}

		public void NewReceiptEntryForCreditUpgrade(DataRow rowsToAdd,DataRow MemberCreditPackage)
		{
			decimal UpgradePrice = ACMS.Convert.ToDecimal(rowsToAdd["mListPrice"]) - ACMS.Convert.ToDecimal(MemberCreditPackage["Balance"]);

			POSEntries entry = NewReceiptEntry(rowsToAdd["strCreditPackageCode"].ToString(),
				ACMS.Convert.ToInt32(rowsToAdd["nCategoryID"].ToString()), rowsToAdd["strDescription"].ToString(),
				1, UpgradePrice, "");

		}


		public void NewReceiptPayment(string paymentCode, decimal amount, int nIPP, string strReferenceNo)
		{
			if (myReceiptPaymentTable == null)
				throw new Exception ("Error occured. Forgot to initialise tblReceiptPayment.");
	
			DataRow[] rowList = myReceiptPaymentTable.Select("strPaymentCode = '" + paymentCode + "'", "", DataViewRowState.CurrentRows);
			
			if (rowList.Length == 0)
			{
				if (myPaymentTypeTable.Rows.Count == 3) 
				{
					if (myPaymentTypeTable.Select("PaymentType = '" + paymentCode + "'", "", DataViewRowState.CurrentRows).Length == 0)
					{
						MessageBox.Show("Maximun 3 type of Payment is allow for one receipt.");
						return;
					}
				}
			}            

			DataRow newPaymentRow = myReceiptPaymentTable.NewRow();	

			newPaymentRow["strReceiptNo"] = this.StrReceiptNo;

			newPaymentRow["strPaymentCode"] = paymentCode;

			newPaymentRow["mAmount"] = amount;
			
			if (nIPP >0)
				newPaymentRow["nIPPID"] = nIPP;
			
			if (strReferenceNo.Length > 0) 
				newPaymentRow["strReferenceNo"] = strReferenceNo;

			myReceiptPaymentTable.Rows.Add(newPaymentRow);

			if (myPaymentTypeTable.Select("PaymentType = '" + paymentCode + "'", "", DataViewRowState.CurrentRows).Length == 0)
			{
				DataRow paymentTypeRow = myPaymentTypeTable.NewRow();

				paymentTypeRow["PaymentType"] = paymentCode;

				myPaymentTypeTable.Rows.Add(paymentTypeRow);
			}

			CalculateOutStanding();
		}

		public int NoCredit
		{
			get {return intCredit;}
			set {intCredit = value;}
		}
        //2106


        public int NThisMonthBirthday
        {
            get { return myThisMonthBirthdayID; }
            set { myThisMonthBirthdayID = value; }
        }

		private void CalculateSubTotal(DataRow detailRow)
		{
			decimal qty = ACMS.Convert.ToDecimal(detailRow["nQuantity"]);
			decimal unitPrice = ACMS.Convert.ToDecimal(detailRow["mUnitPrice"]);
			decimal subtotal = qty * unitPrice;
				
			if (NCategoryID == 10 && myWantToUpgradeMemberPackageTable != null && 
				myWantToUpgradeMemberPackageTable.Rows.Count > 0)
			{
				if (ACMS.Convert.ToInt32(myWantToUpgradeMemberPackageTable.Rows[0]["nCategoryID"]) == 1 ||
					ACMS.Convert.ToInt32(myWantToUpgradeMemberPackageTable.Rows[0]["nCategoryID"]) == 2 ||
					ACMS.Convert.ToInt32(myWantToUpgradeMemberPackageTable.Rows[0]["nCategoryID"]) == 3 ||
					ACMS.Convert.ToInt32(myWantToUpgradeMemberPackageTable.Rows[0]["nCategoryID"]) == 5 
					)
				{	
					decimal oldPackagePriceInDtl = ACMS.Convert.ToDecimal(detailRow["OldPackagePrice"]);
				
					subtotal -=oldPackagePriceInDtl;

					decimal oldMemberPackageListPrice = ACMS.Convert.ToDecimal(WantToUpgradeMemberPackageRow["OldMemberPackageListPrice"]);

					//old package with discount minus
//					decimal amtNeedToSubtract = 0;
//					amtNeedToSubtract = oldMemberPackageListPrice >= subtotal ? subtotal : oldMemberPackageListPrice;
//					subtotal -= amtNeedToSubtract;
//					oldMemberPackageListPrice = oldMemberPackageListPrice - amtNeedToSubtract;
//					WantToUpgradeMemberPackageRow["OldMemberPackageListPrice"] = oldMemberPackageListPrice < 0 ? 0 : oldMemberPackageListPrice;
//					detailRow["OldPackagePrice"] = oldPackagePriceInDtl + amtNeedToSubtract;
//
//					detailRow["OldPackagePrice"] = oldPackagePriceInDtl ;

					detailRow["OldPackagePrice"]=oldMemberPackageListPrice;
				}
				else if (ACMS.Convert.ToInt32(myWantToUpgradeMemberPackageTable.Rows[0]["nCategoryID"]) == 4 ||
					ACMS.Convert.ToInt32(myWantToUpgradeMemberPackageTable.Rows[0]["nCategoryID"]) == 5 || 
					ACMS.Convert.ToInt32(myWantToUpgradeMemberPackageTable.Rows[0]["nCategoryID"]) == 6 )
				{				
					if (ACMS.Convert.ToInt32(WantToUpgradeMemberPackageRow["FNew"]) == 0)
					{
						decimal oldPackageUsageInDtl = ACMS.Convert.ToDecimal(detailRow["OldPackageUsage"]);
				
						subtotal -=oldPackageUsageInDtl;

						decimal oldMemberPackageUsage = ACMS.Convert.ToDecimal(WantToUpgradeMemberPackageRow["OldMemberPackageUsage"]);

						decimal amtNeedToSubtract = 0;
						amtNeedToSubtract = oldMemberPackageUsage >= subtotal ? subtotal : oldMemberPackageUsage;
						subtotal -= amtNeedToSubtract;
						oldMemberPackageUsage = oldMemberPackageUsage - amtNeedToSubtract;
						WantToUpgradeMemberPackageRow["OldMemberPackageUsage"] = oldMemberPackageUsage < 0 ? 0 : oldMemberPackageUsage;
						detailRow["OldPackageUsage"] = oldPackageUsageInDtl + amtNeedToSubtract;
					
					}
				}

				if (subtotal < 0)
					subtotal = 0;
			}
            //2006
			if (detailRow["strDiscountCode"] != DBNull.Value)
			{
				TblPromotion promotion = new TblPromotion();
				promotion.StrPromotionCode = detailRow["strDiscountCode"].ToString();
				promotion.SelectOne();

				decimal discountValue = (decimal)(promotion.DDiscountValue.IsNull ? 0 : promotion.DDiscountValue.Value);
				decimal discountPercent = (decimal)(promotion.DDiscountPercent.IsNull ? 0 : promotion.DDiscountPercent.Value);

				decimal discountAmt = 0;

				if (discountPercent > 0 && discountValue <= 0)
				{
					discountAmt = decimal.Round((subtotal * discountPercent / 100), 2);	
				}
				else
				{
					discountAmt = discountValue;
				}

				detailRow["DiscountAmt"] = discountAmt;

				// Get DiscountAmt is this 2 field is empty
				// No write now coz no time. coz if implement correct, this situation should not happen
				//


				if (detailRow["DiscountAmt"] != DBNull.Value)
				{
					//decimal discountAmt = ACMS.Convert.ToDecimal(detailRow["DiscountAmt"]);
					subtotal = (subtotal) - discountAmt;
				}
			}

			detailRow["mSubTotal"]  = decimal.Round(subtotal, 2);
		}

        public void RecalculateAfterUpgrade(decimal usageBalAmt)
        {        
            decimal nettAmount = 0;
            nettAmount = ACMS.Convert.ToDecimal(myReceiptMasterTable.Rows[0]["mNettAmount"]) - usageBalAmt;
            myReceiptMasterTable.Rows[0]["mNettAmount"] = decimal.Round(nettAmount,2);
            myReceiptMasterTable.Rows[0]["mGSTAmount"] = decimal.Round(MNettAmount * myGSTRate, 2);
            myReceiptMasterTable.Rows[0]["mTotalAmount"] = MNettAmount + MGSTAmount;
            myReceiptMasterTable.Rows[0]["mOutstandingAmount"] = myReceiptMasterTable.Rows[0]["mTotalAmount"];
        }

        public void RecalculateAll()
        {
            decimal nettAmount = 0;
            decimal subtotal = 0;
            decimal nettAmountwGST = 0;
            Boolean isAllPricesWithGST = true;
            Boolean isAllPricesNoGST = false;

            //To check all items are with GST price or not, also cannot contain any discount
            foreach (DataRow r in myReceiptItemsTable.Rows)
            {
                if (myCategoryID == 7 || myCategoryID == 36 || myCategoryID == 37)
                {
                    TblCreditPackage pkg = new TblCreditPackage();
                    pkg.StrCreditPackageCode = r["strCode"].ToString();
                    pkg.SelectOne();
                    if (pkg.MListPriceWGST.IsNull || ACMS.Convert.ToDecimal(pkg.MListPriceWGST) == 0 || r["strDiscountCode"].ToString() != "" || myReceiptMasterTable.Rows[0]["strDiscountCode"].ToString() != "")
                    {
                        isAllPricesWithGST = false;
                        break;
                    }
                    pkg.Dispose();
                }
                if (myCategoryID == 38)
                {
                    isAllPricesWithGST = false;
                    isAllPricesNoGST = true;
                    break;
                }               
                else
                {
                    if (myCategoryID == 8 || myCategoryID == 9)
                    {
                        TblPackageGroup pkg = new TblPackageGroup();
                        pkg.StrPackageGroupCode = r["strCode"].ToString();
                        pkg.SelectOne();
                        if (pkg.MListPriceWGST.IsNull || ACMS.Convert.ToDecimal(pkg.MListPriceWGST) == 0 || r["strDiscountCode"].ToString() != "" || myReceiptMasterTable.Rows[0]["strDiscountCode"].ToString() != "")
                        {
                            isAllPricesWithGST = false;
                            break;
                        }
                        pkg.Dispose();
                    }
                    else
                    {
                        TblPackage pkg = new TblPackage();
                        pkg.StrPackageCode = r["strCode"].ToString();
                        pkg.SelectOne();
                        if (pkg.MListPriceWGST.IsNull || ACMS.Convert.ToDecimal(pkg.MListPriceWGST) == 0 || r["strDiscountCode"].ToString() != "" || myReceiptMasterTable.Rows[0]["strDiscountCode"].ToString() != "")
                        {
                            isAllPricesWithGST = false;
                            break;
                        }
                        pkg.Dispose();
                    }
                }
            }

            foreach (DataRow r in myReceiptItemsTable.Rows)
            {
                if ((myCategoryID == 7 || myCategoryID == 36 || myCategoryID == 37) && isAllPricesWithGST)
                {
                    TblCreditPackage pkg = new TblCreditPackage();
                    pkg.StrCreditPackageCode = r["strCode"].ToString();
                    pkg.SelectOne();
                    if (pkg.MListPriceWGST.IsNull == false && ACMS.Convert.ToDecimal(pkg.MListPriceWGST) != 0)
                    {
                        subtotal = ACMS.Convert.ToDecimal(r["nQuantity"]) * ACMS.Convert.ToDecimal(pkg.MListPriceWGST);
                        nettAmountwGST += subtotal;
                    }
                    pkg.Dispose();
                }                
				else
				{
	                if ((myCategoryID == 8 || myCategoryID == 9) && isAllPricesWithGST)
	                {
	                    TblPackageGroup pkg = new TblPackageGroup();
	                    pkg.StrPackageGroupCode = r["strCode"].ToString();
	                    pkg.SelectOne();
	                    if (pkg.MListPriceWGST.IsNull == false && ACMS.Convert.ToDecimal(pkg.MListPriceWGST) != 0)
	                    {
	                        subtotal = ACMS.Convert.ToDecimal(r["nQuantity"]) * ACMS.Convert.ToDecimal(pkg.MListPriceWGST);
	                        nettAmountwGST += subtotal;
                    	}
                   	 	pkg.Dispose();
                	}
                	else if (isAllPricesWithGST)
                	{
	                    TblPackage pkg = new TblPackage();
	                    pkg.StrPackageCode = r["strCode"].ToString();
	                    pkg.SelectOne();
	                    if (pkg.MListPriceWGST.IsNull == false && ACMS.Convert.ToDecimal(pkg.MListPriceWGST) != 0)
	                    {
	                        subtotal = ACMS.Convert.ToDecimal(r["nQuantity"]) * ACMS.Convert.ToDecimal(pkg.MListPriceWGST);
	                        nettAmountwGST += subtotal;
	                    }
	                    pkg.Dispose();
                	}
				}
                subtotal = ACMS.Convert.ToDecimal(r["mSubTotal"]);
                nettAmount += subtotal;            	    
			}

            if (myCategoryID == 11 || myCategoryID == 12)
            {
                if (nettAmount < 0)
                    nettAmount = 0;
	        }

            myReceiptMasterTable.Rows[0]["mNettAmount"] = nettAmount;
            if (StrDiscountCode.HasValue && StrDiscountCode.ToString().Length > 0)
            {
                TblPromotion promotion = new TblPromotion();
                promotion.StrPromotionCode = myReceiptMasterTable.Rows[0]["strDiscountCode"].ToString();
                promotion.SelectOne();

                decimal discountValue = (decimal)(promotion.DDiscountValue.IsNull ? 0 : promotion.DDiscountValue.Value);
                decimal discountPercent = (decimal)(promotion.DDiscountPercent.IsNull ? 0 : promotion.DDiscountPercent.Value);

                decimal discountAmt = 0;

                if (discountPercent > 0 && discountValue <= 0)
                {
                    discountAmt = decimal.Round((MNettAmount * discountPercent / 100), 2);
                }
                else
                {
                    discountAmt = discountValue;
                }
                if (discountAmt > ACMS.Convert.ToDecimal(myReceiptMasterTable.Rows[0]["mNettAmount"]))
                    discountAmt = ACMS.Convert.ToDecimal(myReceiptMasterTable.Rows[0]["mNettAmount"]);
                myReceiptMasterTable.Rows[0]["DiscountAmt"] = discountAmt;
                myReceiptMasterTable.Rows[0]["mNettAmount"] = ACMS.Convert.ToDecimal(myReceiptMasterTable.Rows[0]["mNettAmount"]) - discountAmt;
            }

            if (StrDeposit.ToString() != "")
            {
                isAllPricesWithGST = false;
                TblMemberPackage myPackage = new TblMemberPackage();
                myPackage.StrReceiptNo = StrDeposit;
                DataTable tblMemberPkg = myPackage.SelectOneReceipt();
                DataTable tblConverted = new DataTable();
                DataTable tblCreditConverted = new DataTable();
                if (tblMemberPkg.Rows.Count > 0)
                    tblConverted = myPackage.SelectConvertedPackageID(System.Convert.ToInt32(tblMemberPkg.Rows[0]["nPackageID"]));

                TblMemberCreditPackage myCreditPackage = new TblMemberCreditPackage();
                myCreditPackage.StrReceiptNo = StrDeposit;
                tblCreditConverted = myCreditPackage.SelectAllWstrReceiptNoLogic();

                if (tblCreditConverted.Rows.Count > 0)
                    tblConverted = myPackage.SelectConvertedPackageID(System.Convert.ToInt32(tblCreditConverted.Rows[0]["nCreditPackageID"]));

                if (tblConverted.Rows.Count > 0)
                {
                    decimal DepositAmount = System.Convert.ToDecimal(tblConverted.Rows[0]["mConverted"]);
                    myReceiptMasterTable.Rows[0]["mNettAmount"] = ACMS.Convert.ToDecimal(myReceiptMasterTable.Rows[0]["mNettAmount"]) - DepositAmount;
                    myReceiptMasterTable.Rows[0]["strRemarks"] = "Deposit from Convert";
                }
                //else if (tblCreditConverted.Rows.Count > 0)
                //{
                //    decimal DepositAmount = System.Convert.ToDecimal(tblCreditConverted.Rows[0]["mConverted"]);
                //    myReceiptMasterTable.Rows[0]["mNettAmount"] = ACMS.Convert.ToDecimal(myReceiptMasterTable.Rows[0]["mNettAmount"]) - DepositAmount;
                //    myReceiptMasterTable.Rows[0]["strRemarks"] = "Deposit from Credit Convert";
                //}
                else
                {
                    TblReceipt DepositReceipt = new TblReceipt();
                    DepositReceipt.StrReceiptNo = StrDeposit;
                    DataTable tblDeposit = DepositReceipt.SelectOne();
                    decimal DepositAmount = (decimal)(DepositReceipt.MNettAmount.IsNull ? 0 : DepositReceipt.MNettAmount.Value);
                    myReceiptMasterTable.Rows[0]["mNettAmount"] = ACMS.Convert.ToDecimal(myReceiptMasterTable.Rows[0]["mNettAmount"]) - decimal.Round(DepositAmount, 2);
                    myReceiptMasterTable.Rows[0]["strRemarks"] = "Deposit from " + StrDeposit;
                }

            }

            //Derek Instalment Plan - Pay OS
            if (myCategoryID == 0)
            {
                myReceiptMasterTable.Rows[0]["mGSTAmount"] = MTotalAmount - MNettAmount;
            }
            else
            {
                if (isAllPricesNoGST)
                {
                    myReceiptMasterTable.Rows[0]["mGSTAmount"] = 0;
                    myReceiptMasterTable.Rows[0]["mTotalAmount"] = decimal.Round(MNettAmount, 2);
                }
                else
                {
                    myReceiptMasterTable.Rows[0]["mGSTAmount"] = decimal.Round(MNettAmount * myGSTRate, 2);

                    if (isAllPricesWithGST)
                    {
                        myReceiptMasterTable.Rows[0]["mTotalAmount"] = decimal.Round(nettAmountwGST, 2);
                    }
                    else
                    {
                        myReceiptMasterTable.Rows[0]["mTotalAmount"] = MNettAmount + MGSTAmount;
                    }
                }
            }

            CalculateOutStanding();
               
			if (WantToUpgradeMemberPackageTable.Rows.Count > 0)
            {
                double usageBal = 0;
                double mTotalUsageWGST = 0;
                //Check convert packages' price all with GST
                bool isConvertAllPricesWithGST=true;
                double mTotalUsage = 0; 
                if (isAllPricesWithGST)
                {
                    double mTotalAmount=0;
                                       
                    for (int i = 0; i < WantToUpgradeMemberPackageTable.Rows.Count; i++)
                    {
                        int nCategory = Convert.ToInt32(WantToUpgradeMemberPackageTable.Rows[i]["nCategoryID"]);
                        if (nCategory == 7 || nCategory == 36 || nCategory == 37)
                        {
                            TblCreditPackage pkg = new TblCreditPackage();
                            pkg.StrCreditPackageCode = WantToUpgradeMemberPackageTable.Rows[i]["strPackageCode"].ToString();
                            pkg.SelectOne();
                            if (pkg.MListPriceWGST.IsNull || WantToUpgradeMemberPackageTable.Rows[i]["strDiscountCode"].ToString() != "")
                            {
                                isConvertAllPricesWithGST = false;
                                break;
                            }
                            mTotalAmount += pkg.MCreditAmount.ToDouble();
                            mTotalUsage += Convert.ToDouble(WantToUpgradeMemberPackageTable.Rows[i]["UsageBalAmt"]);
                            mTotalUsageWGST += pkg.MListPriceWGST.ToDouble();
                            pkg.Dispose();
                        }
                        else
                        {
                            TblPackage pkg = new TblPackage();
                            pkg.StrPackageCode = WantToUpgradeMemberPackageTable.Rows[i]["strPackageCode"].ToString();
                            pkg.SelectOne();
                            if (pkg.MListPriceWGST.IsNull || WantToUpgradeMemberPackageTable.Rows[i]["strDiscountCode"].ToString() != "")
                            {
                                isConvertAllPricesWithGST = false;
                                break;
                            }
                            mTotalAmount += pkg.MListPrice.ToDouble();
                            mTotalUsage += Convert.ToDouble(WantToUpgradeMemberPackageTable.Rows[i]["UsageBalAmt"]);
                            mTotalUsageWGST += pkg.MListPriceWGST.ToDouble();
                            pkg.Dispose();
                        }               
                    }
                    if (mTotalAmount != mTotalUsage)                    
                        isConvertAllPricesWithGST = false;
                    
                }                

                for (int i = 0; i < WantToUpgradeMemberPackageTable.Rows.Count; i++)
                {
                    int mainSession = Convert.ToInt32(WantToUpgradeMemberPackageTable.Rows[i]["nMaxSession"]) - Convert.ToInt32(WantToUpgradeMemberPackageTable.Rows[i]["nFreeSession"]);
                    int balSession = mainSession - Convert.ToInt32(WantToUpgradeMemberPackageTable.Rows[i]["UsedSession"]);
                    usageBal += Convert.ToDouble(WantToUpgradeMemberPackageTable.Rows[i]["UsageBalAmt"]);
                }
                //RecalculateAfterUpgrade(Convert.ToDecimal(usageBal));
                if (isConvertAllPricesWithGST && isAllPricesWithGST)
                {
                    nettAmount = ACMS.Convert.ToDecimal(myReceiptMasterTable.Rows[0]["mNettAmount"]) - Convert.ToDecimal(usageBal);
                    myReceiptMasterTable.Rows[0]["mNettAmount"] = decimal.Round(nettAmount, 2);
                    myReceiptMasterTable.Rows[0]["mGSTAmount"] = decimal.Round(MNettAmount * myGSTRate, 2);
                    myReceiptMasterTable.Rows[0]["mTotalAmount"] = decimal.Round(nettAmountwGST - Convert.ToDecimal(mTotalUsageWGST),2); 
                    myReceiptMasterTable.Rows[0]["mOutstandingAmount"] = myReceiptMasterTable.Rows[0]["mTotalAmount"];
                }
                else
                {
                    nettAmount = ACMS.Convert.ToDecimal(myReceiptMasterTable.Rows[0]["mNettAmount"]) - Convert.ToDecimal(usageBal);
                    myReceiptMasterTable.Rows[0]["mNettAmount"] = decimal.Round(nettAmount, 2);
                    myReceiptMasterTable.Rows[0]["mGSTAmount"] = decimal.Round(MNettAmount * myGSTRate, 2);
                    myReceiptMasterTable.Rows[0]["mTotalAmount"] = MNettAmount + MGSTAmount;
                    myReceiptMasterTable.Rows[0]["mOutstandingAmount"] = myReceiptMasterTable.Rows[0]["mTotalAmount"];
                }                
            }         
        }		

		private void CalculateOutStanding()
		{
			decimal paymentAmount = 0;

			if (myReceiptPaymentTable != null &&
				myReceiptPaymentTable.Rows.Count > 0)
			{
				foreach (DataRow r in myReceiptPaymentTable.Rows)
				{
					paymentAmount += ACMS.Convert.ToDecimal(r["mAmount"]);
				}
			}

			myReceiptMasterTable.Rows[0]["mOutstandingAmount"] = MTotalAmount - paymentAmount;
			myReceiptMasterTable.Rows[0]["mBalance"] = MTotalAmount - paymentAmount;
		}

        //Derek Instalment Plan Need to Add tblPaymentPlan
		private void Init()
		{

			TblCompany comp = new TblCompany();

			DataTable compTable = comp.SelectAll();

			myTaxID = ACMS.Convert.ToInt32(compTable.Rows[0]["NTaxID"]);
			
			TblTax tax = new TblTax();

			tax.NTaxID = myTaxID;

			tax.SelectOne();

			myGSTRate = tax.DTaxRate.IsNull ? 0 : (decimal)tax.DTaxRate.Value;

			myReceiptMasterTable = comp.FillSchema("Select * From tblReceipt");	

			myReceiptItemsTable = comp.FillSchema("Select * From tblReceiptEntries");

			myReceiptFreebieTable = comp.FillSchema("Select * From tblReceiptFreebie");

			myReceiptPaymentTable = comp.FillSchema("Select * From tblReceiptPayment");
			
			InitTblReceipt();

			InitTblReceiptEntries();

			InitTblReceiptPackage();

			InitTblReceiptItemsFreebie();

			InitTblReceiptItemsPackage();

			InitTblGiro();

			InitWantToUpgradeMemberPackageTableNew();
            //InitWantToUpgradeMemberPackageTable();

            //Derek Instalment Plan No Need Fire ColumnChanged Event for tblPaymentPlan
			myReceiptMasterTable.ColumnChanged +=new DataColumnChangeEventHandler(myReceiptMasterTable_ColumnChanged);
		
			myReceiptItemsTable.ColumnChanged +=new DataColumnChangeEventHandler(myReceiptItemsTable_ColumnChanged);

			myReceiptPaymentTable.ColumnChanged +=new DataColumnChangeEventHandler(myReceiptPaymentTable_ColumnChanged);

			InitPaymentTypeTable();
		}

		private void InitWantToUpgradeMemberPackageTableNew()
		{
			TblMemberPackage memberPackage = new TblMemberPackage();

            myWantToUpgradeMemberPackageTable = memberPackage.FillSchema(" Select A.*, B.strDescription, B.nPackageDuration, B.nMaxSession, B.mListPrice,B.mBaseUnitPrice, C.nCategoryID, C.strDescription as CategoryDescription, " +
                "B.strFreePkgCode,D.mSubTotal, B.nFreeSession, B.nFreeDuration, " +
                "(select SUM(mSubTotal) from tblReceiptEntries where strReceiptNo=A.strReceiptNo) as totalSubTotal, " +
                      "(select mNettAmount from tblReceipt where strReceiptNo=A.strReceiptNo) as mNettAmount, " +
                      "(select strDiscountCode from tblReceipt where strReceiptNo=A.strReceiptNo) as strDiscountCode, " +
                      "(select mOutstandingAmount from tblReceipt where strReceiptNo=A.strReceiptNo) as mOutstandingAmount " +
				" from tblMemberPackage A inner join tblPackage B on (A.strPackageCode = B.strPackageCode) inner join " + 
				" tblCategory C on (B.nCategoryID = C.nCategoryID) " +
                "left join tblReceiptEntries D on (A.strReceiptNo=D.strReceiptNo AND A.strPackageCode=D.strCode) ");

			if (!myWantToUpgradeMemberPackageTable.Columns.Contains("Balance"))
			{
				DataColumn colBalance = new DataColumn("Balance", System.Type.GetType("System.Int32"));
				myWantToUpgradeMemberPackageTable.Columns.Add(colBalance);
			}

			if (!myWantToUpgradeMemberPackageTable.Columns.Contains("PaidAmt"))
			{
                DataColumn colNew = new DataColumn("PaidAmt", System.Type.GetType("System.Decimal"));
				myWantToUpgradeMemberPackageTable.Columns.Add(colNew);
			}

            if (!myWantToUpgradeMemberPackageTable.Columns.Contains("UsageBalAmt"))
            {
                DataColumn colNew = new DataColumn("UsageBalAmt", System.Type.GetType("System.Decimal"));
                myWantToUpgradeMemberPackageTable.Columns.Add(colNew);
            }

            if (!myWantToUpgradeMemberPackageTable.Columns.Contains("UsedSession"))
            {
                DataColumn colNew = new DataColumn("UsedSession", System.Type.GetType("System.Int32"));
                myWantToUpgradeMemberPackageTable.Columns.Add(colNew);
            }			
		}

        private void InitWantToUpgradeMemberPackageTable()
        {
            TblMemberPackage memberPackage = new TblMemberPackage();

            myWantToUpgradeMemberPackageTable = memberPackage.FillSchema(" Select A.*, B.strDescription, B.nMaxSession, B.mListPrice,B.mBaseUnitPrice, C.nCategoryID, C.strDescription as CategoryDescription " +
                " from tblMemberPackage A inner join tblPackage B on (A.strPackageCode = B.strPackageCode) inner join " +
                " tblCategory C on (B.nCategoryID = C.nCategoryID) ");

            if (!myWantToUpgradeMemberPackageTable.Columns.Contains("Balance"))
            {
                DataColumn colBalance = new DataColumn("Balance", System.Type.GetType("System.Int32"));
                myWantToUpgradeMemberPackageTable.Columns.Add(colBalance);
            }

            if (!myWantToUpgradeMemberPackageTable.Columns.Contains("FNew"))
            {
                DataColumn colNew = new DataColumn("FNew", System.Type.GetType("System.Int32"));
                myWantToUpgradeMemberPackageTable.Columns.Add(colNew);
            }

            DataColumn colOldMemberPackageListPrice = new DataColumn("OldMemberPackageListPrice", typeof(decimal));
            myWantToUpgradeMemberPackageTable.Columns.Add(colOldMemberPackageListPrice);

            // this is for store the total usage of service session
            DataColumn colOldMemberPackageUsage = new DataColumn("OldMemberPackageUsage", typeof(decimal));
            myWantToUpgradeMemberPackageTable.Columns.Add(colOldMemberPackageUsage);

        }

		private void InitTblGiro()
		{
			myGiroTable = new DataTable();

			ACMSDAL.TblGIRO tblgiro = new TblGIRO();
			myGiroTable = tblgiro.FillSchema("Select * From tblReceiptGIROCredit");
			
			DataColumn colEntryID = new DataColumn("nEntryID", typeof(int));
			myGiroTable.Columns.Add(colEntryID);

		}

		private void InitTblReceiptItemsFreebie()
		{
			myReceiptItemsFreebieTable = new DataTable();
			DataColumn colReceiptFeebieID = new DataColumn("nReceiptItemsFreebieID", typeof(int));
			colReceiptFeebieID.AutoIncrement = true;
			colReceiptFeebieID.AutoIncrementSeed = 1;
			colReceiptFeebieID.AutoIncrementStep = 1;
			colReceiptFeebieID.Unique = true;
			
			DataColumn colEntryID = new DataColumn("nEntryID", typeof(int));
			DataColumn colProductCode = new DataColumn("strProductCode", typeof(string));
			DataColumn colPromotionCode = new DataColumn("strPromotionCode", typeof(string));
					
			myReceiptItemsFreebieTable.Columns.Add(colReceiptFeebieID);
			myReceiptItemsFreebieTable.Columns.Add(colEntryID);
			myReceiptItemsFreebieTable.Columns.Add(colProductCode);
			myReceiptItemsFreebieTable.Columns.Add(colPromotionCode);
		}

		private void InitTblReceiptItemsPackage()
		{
			myReceiptItemsPackageTable = new DataTable();
			DataColumn colReceiptPackageID = new DataColumn("nReceiptItemsPackageID", typeof(int));
			colReceiptPackageID.AutoIncrement = true;
			colReceiptPackageID.AutoIncrementSeed = 1;
			colReceiptPackageID.AutoIncrementStep = 1;
			colReceiptPackageID.Unique = true;
			
			DataColumn colEntryID = new DataColumn("nEntryID", typeof(int));
			DataColumn colPackageCode = new DataColumn("strPackageCode", typeof(string));
			DataColumn colPromotionCode = new DataColumn("strPromotionCode", typeof(string));
					
			myReceiptItemsPackageTable.Columns.Add(colReceiptPackageID);
			myReceiptItemsPackageTable.Columns.Add(colEntryID);
			myReceiptItemsPackageTable.Columns.Add(colPackageCode);
			myReceiptItemsPackageTable.Columns.Add(colPromotionCode);
		}

		private void InitTblReceiptPackage()
		{
			myReceiptPackageTable = new DataTable();
			DataColumn colReceiptPackageID = new DataColumn("nReceiptPackageID", typeof(int));
			colReceiptPackageID.AutoIncrement = true;
			colReceiptPackageID.AutoIncrementSeed = 1;
			colReceiptPackageID.AutoIncrementStep = 1;
			colReceiptPackageID.Unique = true;
			
			DataColumn colReceiptNo = new DataColumn("strReceiptNo", typeof(string));
			DataColumn colPackageCode = new DataColumn("strPackageCode", typeof(string));
			DataColumn colPromotionCode = new DataColumn("strPromotionCode", typeof(string));
					
			myReceiptPackageTable.Columns.Add(colReceiptPackageID);
			myReceiptPackageTable.Columns.Add(colReceiptNo);
			myReceiptPackageTable.Columns.Add(colPackageCode);
			myReceiptPackageTable.Columns.Add(colPromotionCode);
		}

		private void InitPaymentTypeTable()
		{
			myPaymentTypeTable = new DataTable();

			DataColumn colPaymentType = new DataColumn("PaymentType", typeof(string));

			myPaymentTypeTable.Columns.Add(colPaymentType);
		}

		private void InitTblReceiptEntries()
		{
			DataColumn colDiscountAmt = new DataColumn("DiscountAmt", typeof(decimal));
			DataColumn colOldPackagePrice = new DataColumn("OldPackagePrice", typeof(decimal));
			DataColumn colOldPackageUsage = new DataColumn("OldPackageUsage", typeof(decimal));
			DataColumn colCodeStatus = new DataColumn("CodeStatus", typeof(int));
			DataColumn colMineralWaterQty = new DataColumn("MineralWaterQty", typeof(int));
			
			DataColumn colOldCreditPackge = new DataColumn("OldCreditPackge", typeof(int));
		
			myReceiptItemsTable.Columns.Add(colDiscountAmt);
			myReceiptItemsTable.Columns.Add(colCodeStatus);// this is use to determine what kind of code store in strCode
			myReceiptItemsTable.Columns.Add(colOldPackagePrice);
			myReceiptItemsTable.Columns.Add(colOldPackageUsage);
			myReceiptItemsTable.Columns.Add(colMineralWaterQty);
			myReceiptItemsTable.Columns.Add(colOldCreditPackge);
			
			
			//myReceiptItemsTable.Columns["nTempEntryID"].Expression = "nEntryID * 1";

		}

		public void AddRegFees()
		{
			TblMember member = new TblMember();
			member.StrMembershipID = myMembershipID;
			DataTable table = member.SelectOne();
			DataRow memberRow = table.Rows[0];
			bool isRegistered = ACMS.Convert.ToBoolean(memberRow["fRegistrationFee"]);

			if (!isRegistered)
			{
				DialogResult result = MessageBox.Show("You are no yet paid the registration fees. Do you want to pay it now?", "Warning", 
					MessageBoxButtons.YesNo);

				if (result == DialogResult.Yes)
				{
					TblPackage pckg = new TblPackage();
                    pckg.StrPackageCode = "JOINFEE";
					pckg.SelectOne();

                    NewReceiptEntry("JOINFEE", myStaffPurchaseCategoryID, pckg.StrDescription.IsNull ? "" : pckg.StrDescription.Value, 
						1, ACMS.Convert.ToDecimal(pckg.MListPrice), "");

					pckg.StrPackageCode = "FA";
					pckg.SelectOne();

					NewReceiptEntry("FA", myStaffPurchaseCategoryID, pckg.StrDescription.IsNull ? "" : pckg.StrDescription.Value, 
						1, ACMS.Convert.ToDecimal(pckg.MListPrice), "");
				}

            			}
		}

		private void InitTblReceipt()
		{
			DataColumn colDiscountAmt = new DataColumn("DiscountAmt", typeof(decimal));
			DataColumn colCodeStatus= new DataColumn("CodeStatus", typeof(int));
			DataColumn colMemberName = new DataColumn("strMemberName", typeof(string));
			DataColumn colTherapistName = new DataColumn("strTherapistName", typeof(string));
			DataColumn colSalesPersonName = new DataColumn("strSalesPersonName", typeof(string));

			myReceiptMasterTable.Columns.Add(colMemberName);
			myReceiptMasterTable.Columns.Add(colDiscountAmt);
			myReceiptMasterTable.Columns.Add(colCodeStatus);// this is use to determine what kind of code store in strCode
			myReceiptMasterTable.Columns.Add(colTherapistName);
			myReceiptMasterTable.Columns.Add(colSalesPersonName);

			TblMember member = new TblMember();
			member.StrMembershipID = myMembershipID;
			member.SelectOne();

			DataRow r = myReceiptMasterTable.NewRow();
		
			r["strReceiptNo"] = GenerateAutoID();
			r["strMembershipID"] = myMembershipID;
			r["strBranchCode"] = myBranchCode;
			r["nCategoryID"] = myCategoryID;

			/*
            if (myGIROID == 1)
            {
                TblReceipt receipt = new TblReceipt();
                Decimal mTotalOutstanding = 0;
                object obj = receipt.GetConvertFitnessGirotoGiroFitness(myMembershipID);

                if (obj != null)
                {
                    mTotalOutstanding = (int)obj;
                }

                if (mTotalOutstanding > 0)
                {
                    r["nCategoryID"] = 35;//GIRO Fitness Jackie 11/10/2012
                }
                else
                {
                    r["nCategoryID"] = 2;//GIRO Fitness Jackie 11/10/2012
                }
            }
            else
            {
                r["nCategoryID"] = myCategoryID;
            }*/
			r["dtDate"] = DateTime.Now.Date;
			r["nCashierID"] = myEmployeeID;
			r["nShiftID"] = myShiftID;
			r["nTerminalID"] = myTerminalID;
			r["nTaxID"] = myTaxID;
			r["strMemberName"] = member.StrMemberName.IsNull ? "" : member.StrMemberName.Value;
			r["fVoid"] = 0;
            r["strLocation"] = myLocation;
          //  r["nPackageID"] = myPackageID;
            r["dtDateTime"] = DateTime.Now;
			
			myReceiptMasterTable.Rows.Add(r);

		}

		private void myReceiptMasterTable_ColumnChanged(object sender, DataColumnChangeEventArgs e)
		{
			if (IsColumnChangedDisable())
				return;

			if (System.String.Compare(e.Column.ColumnName, "strDiscountCode", true) == 0 ||
				System.String.Compare(e.Column.ColumnName, "DiscountAmt", true) == 0 || 
				System.String.Compare(e.Column.ColumnName, "mVoucherAmount", true) == 0 || 
				System.String.Compare(e.Column.ColumnName, "mNettAmount", true) == 0 ||
				System.String.Compare(e.Column.ColumnName, "mGSTAmount", true) == 0)
			{
				DisableColumnChanged();

				try
				{
					RecalculateAll();
				}
				finally
				{
					EnableColumnChanged();
				}
			}
			else if (System.String.Compare(e.Column.ColumnName, "nSalesPersonID", true) == 0)
			{
				DisableColumnChanged();

				try
				{
					TblEmployee employee = new TblEmployee();
					employee.NEmployeeID = ACMS.Convert.ToInt32(myReceiptMasterTable.Rows[0]["nSalesPersonID"]);
					employee.SelectOne();
					if (employee.StrEmployeeName.IsNull)
						e.Row["strSalesPersonName"] = DBNull.Value;
					else
						e.Row["strSalesPersonName"] = employee.StrEmployeeName.Value;
				}
				finally
				{
					EnableColumnChanged();
				}
			}
			else if (System.String.Compare(e.Column.ColumnName, "nTherapistID", true) == 0)
			{
				DisableColumnChanged();

				try
				{
					TblEmployee employee = new TblEmployee();
					employee.NEmployeeID = ACMS.Convert.ToInt32(myReceiptMasterTable.Rows[0]["nTherapistID"]);
					employee.SelectOne();
					if (employee.StrEmployeeName.IsNull)
						e.Row["strTherapistName"] = DBNull.Value;
					else
						e.Row["strTherapistName"] = employee.StrEmployeeName.Value;
				}
				finally
				{
					EnableColumnChanged();
				}
			}
			else if (System.String.Compare(e.Column.ColumnName, "strReceiptNo", true) == 0)
			{
				ChangeReceipNo();
			}
			
		}

		private void myReceiptItemsTable_ColumnChanged(object sender, DataColumnChangeEventArgs e)
		{
			if (IsColumnChangedDisable())
				return;

            connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"];
            connection = new SqlConnection(connectionString);
			if (System.String.Compare(e.Column.ColumnName, "strDiscountCode", true) == 0 ||
				System.String.Compare(e.Column.ColumnName, "mUnitPrice", true) == 0 || 
				System.String.Compare(e.Column.ColumnName, "nQuantity", true) == 0 || 
				System.String.Compare(e.Column.ColumnName, "DiscountAmt", true) == 0 )
			{
				DisableColumnChanged();
				//BeginGridUpdate();

				try
				{
                    if (myCategoryID != 11 && myCategoryID != 12)
                    {
                        if (ACMS.Convert.ToInt32(e.Row["nQuantity"]) < 0)
                        {
                            e.Row["nQuantity"] = 0;
                        }
                    }
                    else
                    {
                        string strSQL = "SELECT nQty from tblSCStockRecon where strProductCode='" + e.Row["strCode"] + "' AND strBranchCode='" + myBranchCode + "' ";
                        DataSet _ds = new DataSet();
                        SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA", _ds, new string[] { "table" }, new SqlParameter("@strSQL", strSQL));
                        if (_ds.Tables["table"].Rows.Count > 0 && e.Row["nQuantity"].ToString() != "")
                        {                            
                            if (Convert.ToInt16(e.Row["nQuantity"]) > Convert.ToInt16(_ds.Tables["table"].Rows[0]["nQty"]))
                            {
                                MessageBox.Show("Quantity entered greater than stock quantity ( " + _ds.Tables["table"].Rows[0]["nQty"].ToString() + " )", "Warning", MessageBoxButtons.OK);
                                e.Row["nQuantity"] = Convert.ToInt16(_ds.Tables["table"].Rows[0]["nQty"]);
                                return;
                            }
                        }
                        _ds.Dispose();
                    }

					CalculateSubTotal(e.Row);
					RecalculateAll();
				}
				finally
				{
					//EndGridUpdate();
					EnableColumnChanged();
				}

			}

			else if (System.String.Compare(e.Column.ColumnName, "StrReferenceNo", true) == 0)
			{
				StrReferenceNo = e.Row["StrReferenceNo"].ToString();
			}
			
		}

		private void myReceiptPaymentTable_ColumnChanged(object sender, DataColumnChangeEventArgs e)
		{
			if (IsColumnChangedDisable())
				return;

			if (System.String.Compare(e.Column.ColumnName, "mAmount", true) == 0)
			{
				DisableColumnChanged();
				//BeginGridUpdate();

				try
				{
					CalculateOutStanding();
				}
				finally
				{
					//EndGridUpdate();
					EnableColumnChanged();
				}
			}
		}

		private void DisableColumnChanged()
		{
			myDisableColumnChangedCount++;
		}
		
		private void EnableColumnChanged()
		{
			if (myDisableColumnChangedCount > 0)
				myDisableColumnChangedCount--;
		}
		
		private bool IsColumnChangedDisable()
		{
			return myDisableColumnChangedCount > 0;
		}
		
		private string GenerateAutoID()
		{
			string DNewID;
			DNewID = System.DateTime.Now.Year.ToString("0000");
			DNewID += System.DateTime.Now.DayOfYear.ToString("000");
			DNewID += System.DateTime.Now.Hour.ToString("00");
			DNewID += System.DateTime.Now.Minute.ToString("00");
			DNewID += System.DateTime.Now.Second.ToString("00");
			DNewID += System.DateTime.Now.Millisecond.ToString("000");

			string DTicks = System.DateTime.Now.Ticks.ToString();
			DNewID += DTicks.Substring(DTicks.Length-2, 2);

			return DNewID;
		}
	}

	public class POSEntries
	{
		private DataRow myRow;

		public POSEntries(DataRow receiptEntriesRow)
		{
			myRow = receiptEntriesRow;
		}
		
		public DataRow POSEntryRow
		{
			get { return myRow; }
		}

		public ACMS.DBInt32 NEntryID
		{
			get { return ACMS.Convert.ToDBInt32(myRow["nEntryID"]); }
		}

		public ACMS.DBString StrReceiptNo
		{
			get { return ACMS.Convert.ToDBString(myRow["strReceiptNo"]); }
		}

		public ACMS.DBInt32 NOldCreditPackage
		{
			get { return ACMS.Convert.ToDBInt32(myRow["OldCreditPackage"]); }
			set { myRow["OldCreditPackage"] = ACMS.Convert.ToDBObject(value); }
		}

		public ACMS.DBInt32 NCategoryID
		{
			get { return ACMS.Convert.ToDBInt32(myRow["nCategoryID"]); }
			set { myRow["nCategoryID"] = ACMS.Convert.ToDBObject(value); }
		}

		public ACMS.DBString StrDescription
		{
			get { return ACMS.Convert.ToDBString(myRow["strDescription"]); }
			set { myRow["strDescription"] = ACMS.Convert.ToDBObject(value); }
		}

		public ACMS.DBInt32 NQuantity
		{
			get { return ACMS.Convert.ToDBInt32(myRow["NQuantity"]); }
			set { myRow["NQuantity"] = ACMS.Convert.ToDBObject(value); }
		}
		
		public ACMS.DBDecimal MUnitPrice
		{
			get { return ACMS.Convert.ToDBDecimal(myRow["mUnitPrice"]); }
			set { myRow["mUnitPrice"] = ACMS.Convert.ToDBObject(value); }
		}

		public ACMS.DBString StrDiscountCode
		{
			get { return ACMS.Convert.ToDBString(myRow["strDiscountCode"]); }
			set { myRow["strDiscountCode"] = ACMS.Convert.ToDBObject(value); }
		}

		public ACMS.DBString StrFreebieCode
		{
			get { return ACMS.Convert.ToDBString(myRow["strFreebieCode"]); }
			set { myRow["strFreebieCode"] = ACMS.Convert.ToDBObject(value); }
		}

        public ACMS.DBString StrReferenceNo
        {
            get { return ACMS.Convert.ToDBString(myRow["strReferenceNo"]); }
            set { myRow["strReferenceNo"] = ACMS.Convert.ToDBObject(value); }
        }

    }
    #endregion
}
