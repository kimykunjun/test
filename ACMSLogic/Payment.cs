using System;
using System.Data;
using System.Data.SqlClient;
using ACMSDAL;
using Do = Acms.Core.Domain;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;
using System.Text.RegularExpressions;

namespace ACMSLogic
{
	/// <summary>
	/// Summary description for Payment.
	/// </summary>
	public class Payment
	{
        private string connectionString;
        private SqlConnection connection;
		private TblReceipt myReceipt = new TblReceipt();
		private DataTable myTable = new DataTable();
		private Do.Employee employee;

		public Payment()
		{
			//
			// TODO: Add constructor logic here
			//
            connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"];
            connection = new SqlConnection(connectionString);
		}

		public DataTable Table
		{
			get {return myTable; }
		}
		
		public void SalesConvertion(int newCategoryID, string strReceiptNo, string remarks)
		{
			ACMSDAL.TblReceipt sqlReceipt = new TblReceipt();
			sqlReceipt.StrReceiptNo = strReceiptNo;
			sqlReceipt.SelectOne();
			sqlReceipt.NCategoryID = newCategoryID;
			sqlReceipt.Update();
		}

		public void ChangeSalesPersonID(int newSalesPersonID, string strReceiptNo)
		{
			ACMSDAL.TblReceipt sqlReceipt = new TblReceipt();
			sqlReceipt.StrReceiptNo = strReceiptNo;
			sqlReceipt.SelectOne();
			sqlReceipt.NSalespersonID = newSalesPersonID;
			sqlReceipt.Update();
		}

		public DataTable GetReceipt(string strMembershipID, int nSalesCategoryID)
		{
		
			myTable = myReceipt.GetReceipt(strMembershipID, nSalesCategoryID);
			DataColumn colDiscountAmt = new DataColumn("DiscountAmt", System.Type.GetType("System.Decimal"));
			//DataColumn colTenderedAmt = new DataColumn("TenderedAmt", System.Type.GetType("System.Decimal"), "mTotalAmount - mOutstandingAmount");
			myTable.Columns.Add(colDiscountAmt);
			//myTable.Columns.Add(colTenderedAmt);

			foreach (DataRow r in myTable.Rows)
			{
				if (r["dDiscountPercent"] != DBNull.Value)
				{
					decimal discountPercent = ACMS.Convert.ToDecimal(r["dDiscountPercent"]);
					decimal netTotal =  GetReceiptNetTotal(r["strReceiptNo"].ToString());
	
					decimal discountAmt = netTotal * discountPercent / 100;
					r["DiscountAmt"] = discountAmt;
				}
				else if (r["dDiscountValue"] != DBNull.Value)
				{
					r["DiscountAmt"] = ACMS.Convert.ToDecimal(r["dDiscountValue"]);
				}
			}

			return myTable;
		}

		public DataTable GetReceipt(string strMembershipID, int nSalesCategoryID,string strReceiptNo)
		{
		
			myTable = myReceipt.GetReceipt(strMembershipID, nSalesCategoryID,strReceiptNo);
			DataColumn colDiscountAmt = new DataColumn("DiscountAmt", System.Type.GetType("System.Decimal"));
			DataColumn colTenderedAmt = new DataColumn("TenderedAmt", System.Type.GetType("System.Decimal"), "mTotalAmount - mOutstandingAmount");
			myTable.Columns.Add(colDiscountAmt);
			myTable.Columns.Add(colTenderedAmt);

			foreach (DataRow r in myTable.Rows)
			{
				if (r["dDiscountPercent"] != DBNull.Value)
				{
					decimal discountPercent = ACMS.Convert.ToDecimal(r["dDiscountPercent"]);
					decimal netTotal =  GetReceiptNetTotal(r["strReceiptNo"].ToString());
	
					decimal discountAmt = netTotal * discountPercent / 100;
					r["DiscountAmt"] = discountAmt;
				}
				else if (r["dDiscountValue"] != DBNull.Value)
				{
					r["DiscountAmt"] = ACMS.Convert.ToDecimal(r["dDiscountValue"]);
				}
			}

			return myTable;
		}

		public DataTable GetReceipt(string strMembershipID)
		{
			myTable = myReceipt.GetReceipt(strMembershipID);
			DataColumn colDiscountAmt = new DataColumn("DiscountAmt", System.Type.GetType("System.Decimal"));
			DataColumn colTenderedAmt = new DataColumn("TenderedAmt", System.Type.GetType("System.Decimal"), "mTotalAmount - mOutstandingAmount");
			myTable.Columns.Add(colDiscountAmt);
			myTable.Columns.Add(colTenderedAmt);

			foreach (DataRow r in myTable.Rows)
			{
				if (r["dDiscountPercent"] != DBNull.Value)
				{
					decimal discountPercent = ACMS.Convert.ToDecimal(r["dDiscountPercent"]);
					decimal netTotal =  GetReceiptNetTotal(r["strReceiptNo"].ToString());
	
					decimal discountAmt = netTotal * discountPercent / 100;
					r["DiscountAmt"] = discountAmt;
				}
				else if (r["dDiscountValue"] != DBNull.Value)
				{
					r["DiscountAmt"] = ACMS.Convert.ToDecimal(r["dDiscountValue"]);
				}
			}

			return myTable;
		}

		public DataTable GetOutstandingReceipt(string strMembershipID)
		{
			DataTable table = myReceipt.GetOutStandingReceipt(strMembershipID);
			DataColumn colDiscountAmt = new DataColumn("DiscountAmt", System.Type.GetType("System.Decimal"));
			DataColumn colTenderedAmt = new DataColumn("TenderedAmt", System.Type.GetType("System.Decimal"), "mTotalAmount - mOutstandingAmount");
			table.Columns.Add(colDiscountAmt);
			table.Columns.Add(colTenderedAmt);

			foreach (DataRow r in table.Rows)
			{
				if (r["dDiscountPercent"] != DBNull.Value)
				{
					decimal discountPercent = ACMS.Convert.ToDecimal(r["dDiscountPercent"]);
					decimal netTotal = GetReceiptNetTotal(r["strReceiptNo"].ToString());
	
					decimal discountAmt = netTotal * discountPercent / 100;
					r["DiscountAmt"] = discountAmt;
				}
				else if (r["dDiscountValue"] != DBNull.Value)
				{
					r["DiscountAmt"] = ACMS.Convert.ToDecimal(r["dDiscountValue"]);
				}
			}

			return table;
		}
		
		public DataTable GetReceiptPayment(string strMembershipID, int nSalesCategoryID)
		{
			TblReceiptPayment receiptPayment = new TblReceiptPayment();
			DataTable table = receiptPayment.GetReceiptPayment(strMembershipID, nSalesCategoryID);
			return table;
		}

		public DataTable GetReceiptPayment(string strReceiptNo)
		{
			TblReceiptPayment receiptPayment = new TblReceiptPayment();
			receiptPayment.StrReceiptNo = strReceiptNo;
			DataTable table = receiptPayment.SelectAllWstrReceiptNoLogic();
			return table;
		}


		/// <summary>
		/// 2.2.4.2. View Receipt Details
		/// </summary>
		/// <param name="strReceiptNo"></param>
		/// <returns></returns>
		public DataTable GetReceiptEntries(string strReceiptNo)
		{
			TblReceiptEntries receiptEntries = new TblReceiptEntries();
			receiptEntries.StrReceiptNo = strReceiptNo;
			DataTable table = receiptEntries.SelectAllWstrReceiptNoLogic();
			return table;
		}
	
		private decimal GetReceiptNetTotal(string strReceiptNo)
		{
			TblReceiptEntries receiptEntries = new TblReceiptEntries();
			DataTable table = receiptEntries.LoadData("Select Sum (mSubTotal) as mSubTotal From tblReceiptEntries where strReceiptNo = @strReceiptNo group by strReceiptNo", new string[] {"@strReceiptNo"}, new object[] {strReceiptNo});
			decimal netTotal = 0;
			if (table.Rows.Count > 0)
				netTotal = ACMS.Convert.ToDecimal(table.Rows[0]["mSubTotal"]);
			
			return netTotal;
		}
		
		public void DeleteFreeMemberPackage(string strReceiptNo, ConnectionProvider connProvider)
		{
			ActionTakeWhenVoidReceiptForCategory_1_3_4_5_6_8_9_14_23(strReceiptNo, connProvider);
		}

        //Derek Instalment Plan - Void Pay OS - Update Payment Plan
        public void VoidReceipt(string strReceiptNo, bool VoidPre)
        {
            ACMSDAL.ConnectionProvider connProvider = new ConnectionProvider();

            try
            {
                // Check Access Right here
                TblReceipt receipt = new TblReceipt();                
                TblReceiptFreebie sqlReceiptFreebie = new TblReceiptFreebie();
                TblRewardsTransaction mRewardTransaction = new TblRewardsTransaction();
                TblReceiptPayment sqlReceiptPayment = new TblReceiptPayment();
                TblPaymentPlan myPaymentPlan = new TblPaymentPlan();

                myPaymentPlan.MainConnectionProvider = connProvider;
                mRewardTransaction.MainConnectionProvider = connProvider;
                receipt.MainConnectionProvider = connProvider;                
                sqlReceiptFreebie.MainConnectionProvider = connProvider;
                sqlReceiptPayment.MainConnectionProvider = connProvider;

                connProvider.OpenConnection();
                connProvider.BeginTransaction("VoidReceipt");

                receipt.StrReceiptNo = strReceiptNo;
                receipt.SelectOne();

                int nCategoryID = receipt.NCategoryID.Value;
                string strBranchCode = receipt.StrBranchCode.Value;

                if (receipt.DtDate.Value != System.DateTime.Today && VoidPre == false)
                    throw new Exception("Not allow to void previous data receipt. ");

                if (strBranchCode != User.BranchCode)
                    throw new Exception("Not allow to void other's branches' receipt. ");

                receipt.FVoid = System.Data.SqlTypes.SqlBoolean.True;
                receipt.Update();
               
                string strSQL;
                if (receipt.NCategoryID == 7 || receipt.NCategoryID == 36 || receipt.NCategoryID == 37)
                    strSQL = "select top 1 * from tblMemberCreditPackage where strReceiptNo ='" + receipt.StrReceiptNo.ToString() + "' AND fFree=0";
                else
                    strSQL = "select top 1 * from tblMemberPackage where strReceiptNo ='" + receipt.StrReceiptNo.ToString() + "' AND fFree=0";
                DataSet _ds1 = new DataSet();
                SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA", _ds1, new string[] { "table" }, new SqlParameter("@strSQL", strSQL));

                //Roll back when package conversion
                if (_ds1.Tables["table"].Rows.Count > 0)
                {
                    string strPkgRemark = _ds1.Tables["table"].Rows[0]["strUpgradeFrom"].ToString();
                    string[] rollbackPackages = strPkgRemark.ToString().Split(',');

                    foreach (string rollbackPackage in rollbackPackages)
                    {
                        if (rollbackPackage.Trim() != "" && rollbackPackage.Trim() != "Null")
                        {
                            if (rollbackPackage.Contains("(C)"))
                            {
                                int nPackageID = Convert.ToInt32(rollbackPackage.Trim().Replace("(C)", ""));
                                TblMemberCreditPackage mp2 = new TblMemberCreditPackage();
                                mp2.NCreditPackageID = nPackageID;
                                mp2.SelectOne();
                                mp2.StrUpgradeTo = "";
                                mp2.StrRemarks = "";
                                mp2.NStatusID = 0;
                                mp2.Update();
                            }
                            else if (rollbackPackage.Contains("(B)"))
                            {
                                string strSQL2 = "select * from tblMemberPackage where strUpgradeTo='" + receipt.StrReceiptNo.ToString() + "' ";
                                DataSet _ds2 = new DataSet();
                                SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA", _ds2, new string[] { "table" }, new SqlParameter("@strSQL", strSQL2));
                                foreach (DataRow drComboPkg in _ds2.Tables["table"].Rows)
                                {
                                    TblMemberPackage mp = new TblMemberPackage();
                                    DataTable convertedPkgTable = mp.LoadData("select * from tblMemberPackage where nPackageID=" + drComboPkg["nPackageID"].ToString());
                                    if (convertedPkgTable.Rows.Count > 0)
                                    {
                                        convertedPkgTable.Rows[0]["nStatusID"] = 0;
                                        convertedPkgTable.Rows[0]["strUpgradeTo"] = "";
                                        convertedPkgTable.Rows[0]["strRemarks"] = "";
                                        mp.SaveData(convertedPkgTable);
                                    }
                                }
                            }
                            else
                            {
                                int nPackageID = Convert.ToInt32(rollbackPackage.Trim());
                                TblMemberPackage mp2 = new TblMemberPackage();
                                mp2.NPackageID = nPackageID;
                                mp2.SelectOne();
                                mp2.StrUpgradeTo = "";
                                mp2.StrRemarks = "";
                                mp2.NStatusID = 0;
                                mp2.Update();

                                //rollback free package if have any      
                                TblMemberPackage mp3 = new TblMemberPackage();
                                string strFreePackageCode = "";
                                string strSQL3 = "select strFreePkgCode from tblPackage where strPackageCode='" + Convert.ToString(mp2.StrPackageCode) + "' ";
                                DataSet _ds = new DataSet();
                                SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA", _ds, new string[] { "table" }, new SqlParameter("@strSQL", strSQL3));
                                if (_ds.Tables["table"].Rows.Count > 0)
                                {
                                    strFreePackageCode = _ds.Tables["table"].Rows[0]["strFreePkgCode"].ToString();
                                }
                                DataTable freePkgTable = mp3.LoadData("select * from tblMemberPackage where strReceiptNo=@strReceiptNo and strPackageCode =@strFreePackageCode ",
                                    new string[] { "@strReceiptNo", "@strFreePackageCode" }, new object[] { mp2.StrReceiptNo.ToString(), strFreePackageCode });

                                if (freePkgTable.Rows.Count > 0)
                                {
                                    freePkgTable.Rows[0]["nStatusID"] = 0;
                                    freePkgTable.Rows[0]["strUpgradeTo"] = "";
                                    freePkgTable.Rows[0]["strRemarks"] = "";
                                    mp3.SaveData(freePkgTable);
                                }
                            }
                        }
                    }
                }

                receipt.MUpgradeAmount = System.Data.SqlTypes.SqlMoney.Null;
                receipt.StrRemarks = "";
                receipt.Update();


                #region ====== Added By Albert ======
                /*
				 * To remove reward transaction.
				 */
                mRewardTransaction.StrReferenceNo = strReceiptNo;
                mRewardTransaction.SelectAllWReferenceNo();
                mRewardTransaction.NTypeID = 3;
                mRewardTransaction.Update();
                #endregion
                             

                //rollback used cash voucher
                TblReceiptPayment tblReceiptPayment = new ACMSDAL.TblReceiptPayment();
                tblReceiptPayment.StrReceiptNo = strReceiptNo;
                DataTable tblPayment = tblReceiptPayment.SelectAllWstrReceiptNoLogic();

                foreach (DataRow dr in tblPayment.Rows)
                {
                    if (dr["strPaymentCode"].ToString() == "CASHVOUCHER")
                    {
                        TblCashVoucher sqlCV = new TblCashVoucher();
                        sqlCV.MainConnectionProvider = connProvider;
                        sqlCV.StrSN = dr["strReferenceNo"].ToString();
                        DataTable table = sqlCV.SelectOne();
                        sqlCV.NStatusID = 1;
                        sqlCV.StrRedeemedByID = System.Data.SqlTypes.SqlString.Null;
                        sqlCV.DtRedeemedDate = System.Data.SqlTypes.SqlDateTime.Null;
                        sqlCV.StrRedeemedBranch = System.Data.SqlTypes.SqlString.Null;
                        sqlCV.Update();
                        sqlCV.SaveData(table);
                    }
                }

                if (!receipt.StrChildReceiptNo.IsNull)
                {                    
                    int IsVoid = 0;

                    IsVoid = receipt.CheckIfChildReceiptVoid(receipt.StrChildReceiptNo.Value);

                    if (IsVoid == 0)
                    {
                        throw new Exception("The receipt given has child receipt, please void child receipt first before void this receipt");
                    }
                }

                string strDepositReceiptNo = "";

                if (!receipt.StrParentReceiptNo.IsNull)
                {
                    TblReceiptEntries pReceipt = new TblReceiptEntries();
                    pReceipt.StrReceiptNo = receipt.StrParentReceiptNo.Value;
                    pReceipt.SelectAllWstrReceiptNoLogic();
                    if (pReceipt.StrCode.Value != "Deposit")
                    {
                        nCategoryID = 0; //Check if pay outstanding receipt, reset category to 0
                    }
                    else if (pReceipt.StrCode.Value == "Deposit")
                    {
                        strDepositReceiptNo = receipt.StrParentReceiptNo.Value;
                    }
                    pReceipt.Dispose();
                }

                if (strDepositReceiptNo != "")
                {
                    try
                    {
                        receipt.ReviveDepositForVoidMasterReceipt(strReceiptNo, strDepositReceiptNo);
                    }
                    catch { }
                }

                if (nCategoryID == 1 || nCategoryID == 3 || nCategoryID == 4 || nCategoryID == 5 ||
                    nCategoryID == 6 || nCategoryID == 8 || nCategoryID == 9 || nCategoryID == 14 || nCategoryID == 23)
                {
                    ActionTakeWhenVoidReceiptForCategory_1_3_4_5_6_8_9_14_23(strReceiptNo, connProvider);
                }
                else if (nCategoryID == 2)
                {
                    //Fitness GIRO
                    ActionTakeWhenVoidReceiptForCategory_2(strReceiptNo, connProvider);
                }
                else if (nCategoryID == 7)
                {
                    // Spa Credit Account
                    ActionTakeWhenVoidReceiptForCategory_7(strReceiptNo, connProvider);
                }
                else if (nCategoryID == 36 || nCategoryID == 37)
                {
                    // Holistic Credit Account
                    ActionTakeWhenVoidReceiptForCategory_7(strReceiptNo, connProvider);
                }
                else if (nCategoryID == 38)
                { 
                    // Cash Voucher
                    ActionTakeWhenVoidReceiptForCategory_38(strReceiptNo, connProvider);
                }
                else
                {
                    DeleteFreeMemberPackage(strReceiptNo, connProvider);

                    if (nCategoryID == 11 || nCategoryID == 12)
                    {
                        //ActionTakeWhenVoidReceiptForCategory_11_12(strReceiptNo, connProvider);
                    }
                    else if (nCategoryID == 21)
                    {
                        // mineral water
                    }
                    else if (nCategoryID == 15)
                    {
                        //Locker Rental
                    }
                    else if (nCategoryID == 0)
                    {
                        // Pay Outstanding
                        ActionTakeWhenVoidReceiptForCategory_0(receipt, connProvider);

                        //Get New Payment Plan
                        //If Table Row Count > 0 Then Update Payment Plan

                        //Derek Instalment Plan - Update tblPaymentPlan (if any)
                        //Reset Payment Plan's Receipt by payment receipt No - Bool 1 Updated 0 Not Found
                        //Get Bool If 1
                        //Find the Master Receipt No if 1 

                        string strMasterReceiptNo = "";

                        strMasterReceiptNo = myPaymentPlan.GetInhouseIPPMasterOSReceiptSimple(strReceiptNo);

                        if (strMasterReceiptNo != "")
                        {
                            if (myPaymentPlan.GetInhouseResetIPP_VoidPayOS(strReceiptNo) == 1)
                            {
                                DataTable paymentPlanTable = myPaymentPlan.GetInhouseAdjustedIPP_VoidPayOS(strMasterReceiptNo);

                                if (paymentPlanTable != null && paymentPlanTable.Rows.Count > 0)
                                {
                                    foreach (DataRow r in paymentPlanTable.Rows)
                                    {
                                        if (r["lastestUpdate"].ToString() == "1")
                                        {
                                            myPaymentPlan.IPPSubsequentUpdate(Convert.ToInt32(r["nPaymentPlanID"]), r["strReceiptNo"].ToString(),
                                                                                Convert.ToInt32(r["nInstalmentNo"]), Convert.ToDecimal(r["mPaidAmount"]),
                                                                                Convert.ToDecimal(r["mAdjustedPaymentPlanAmt"]), Convert.ToDecimal(r["mOutstandingAmt"]));
                                        }
                                    }
                                    //paymentPlanTable.AcceptChanges();
                                }
                            }
                        }
                    }
                    else if (nCategoryID == 18)
                    {
                        ActionTakeWhenVoidReceiptForCategory_18(strReceiptNo, connProvider);
                    }
                    else if (nCategoryID == 19)
                    {
                        ActionTakeWhenVoidReceiptForCategory_19(strReceiptNo, connProvider);
                    }
                    #region Un-support voiding
                    /*
					else if (nCategoryID == 17)
					{
						//throw new Exception("Forget card's receipt is not allow to void.");
						//do notthing. Just void the receipt
					}
					else if (nCategoryID == 10)
					{
						//throw new Exception("Upgrade Package's receipt is not allow to void.");
						// do notthing. Just void the receipt.
					}
					else if (nCategoryID == 20)
					{
						//Replace Membership Card
						//throw new Exception("Replace member card's receipt is not allow to void.");
						//do notthing, just void the receipt
					}
					*/
                    #endregion

                }

                connProvider.CommitTransaction();
            }
            catch (Exception ex)
            {
                connProvider.RollbackTransaction("VoidReceipt");
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

        public void Refund(string strReceiptNo, string strChequeNo, double mRefundAmount)
        {
            ACMSDAL.ConnectionProvider connProvider = new ConnectionProvider();

            try
            {
                // Check Access Right here
                TblReceipt receipt = new TblReceipt();                                
                receipt.MainConnectionProvider = connProvider;

                connProvider.OpenConnection();
                connProvider.BeginTransaction("Refund");

                receipt.StrReceiptNo = strReceiptNo;
                receipt.SelectOne();

                receipt.FRefund = System.Data.SqlTypes.SqlBoolean.True;
                receipt.StrChequeNo = strChequeNo;
                receipt.MRefundAmount = ACMS.Convert.ToDecimal(mRefundAmount);
                receipt.NChequeUpdateBy = User.EmployeeID;
                receipt.UpdateChequeDetails();

                connProvider.CommitTransaction();
            }
            catch (Exception ex)
            {
                connProvider.RollbackTransaction("Refund");
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
		
		private void ActionTakeWhenVoidReceiptForCategory_1_3_4_5_6_8_9_14_23(string strReceiptNo, 
			ConnectionProvider connProvider)
		{
			//1	Fitness Package
			//3	PT Package
			//4	Spa Single Treatment
			//5	Spa Package
			//6	IPL Package
			//8	Fitness Combined Package
			//9	Spa Combined Package

			TblMemberPackage memberPackage = new TblMemberPackage();
			memberPackage.MainConnectionProvider = connProvider;
			memberPackage.StrReceiptNo = strReceiptNo;
			DataTable table = memberPackage.SelectAllWstrReceiptNo(strReceiptNo);
			
			TblClassAttendance sqlClassAttendance = new TblClassAttendance();
			TblServiceSession sqlServiceSession = new TblServiceSession();

			sqlClassAttendance.MainConnectionProvider = connProvider;
			sqlServiceSession.MainConnectionProvider = connProvider;
			
			if (table.Rows.Count > 0)
			{
				int nPackageID = 0;
				foreach (DataRow r in table.Rows)
				{

					nPackageID = ACMS.Convert.ToInt32(r["nPackageID"]);
					sqlClassAttendance.NPackageID = nPackageID;
					DataTable classAttTable = sqlClassAttendance.SelectAllWnPackageIDLogic();
					if (classAttTable.Rows.Count > 0)
						throw new Exception("The item(s) has been used, you are not allow to void the receipt");
					else 
					{
						sqlServiceSession.NPackageID = nPackageID;
						classAttTable = sqlServiceSession.SelectAllWnPackageIDLogic();
						if (classAttTable.Rows.Count > 0)
							throw new Exception("The item(s) has been used, you are not allow to void the receipt");
					}

					r["nEmployeeID"] = User.EmployeeID;
					r["nStatusID"] = 2;
					r["strRemarks"] = "Voided Receipt";
					r["dtLastEdit"] = System.DateTime.Now;
				}
				memberPackage.SaveData(table);
			}

            TblMemberCreditPackage memberCreditPackage = new TblMemberCreditPackage();
            memberCreditPackage.MainConnectionProvider = connProvider;
            memberCreditPackage.StrReceiptNo = strReceiptNo;
            DataTable table2 = memberCreditPackage.SelectAllWstrReceiptNo(strReceiptNo);

            TblMemberPackage sqlMemberPackage = new TblMemberPackage();
            sqlMemberPackage.MainConnectionProvider = connProvider;

            if (table2.Rows.Count > 0)
            {
                int nCreditPackageID = 0;
                foreach (DataRow r in table2.Rows)
                {
                    nCreditPackageID = ACMS.Convert.ToInt32(r["nCreditPackageID"]);
                    
                    DataTable mpTable = sqlMemberPackage.SelectAllWnCreditPackageIDLogic();
                    if (mpTable.Rows.Count > 0)
                        throw new Exception("The item(s) has been used, you are not allow to void the receipt");
                    
                    r["nEmployeeID"] = User.EmployeeID;
                    r["nStatusID"] = 2;
                    r["strRemarks"] = "Voided Receipt";
                    r["dtLastEditDate"] = System.DateTime.Now;
                }
                memberCreditPackage.SaveData(table2);
            }
		}

		private void ActionTakeWhenVoidReceiptForCategory_2(string strReceiptNo, ConnectionProvider connProvider)
		{
			TblMemberPackage memberPackage = new TblMemberPackage();
			TblGIRO giro = new TblGIRO();
			giro.MainConnectionProvider = connProvider;
			memberPackage.MainConnectionProvider = connProvider;

			memberPackage.StrReceiptNo = strReceiptNo;
			DataTable table = memberPackage.SelectAllWstrReceiptNo(strReceiptNo);

			TblClassAttendance sqlClassAttendance = new TblClassAttendance();
			TblServiceSession sqlServiceSession = new TblServiceSession();

			sqlClassAttendance.MainConnectionProvider = connProvider;
			sqlServiceSession.MainConnectionProvider = connProvider;

			if (table.Rows.Count > 0)
			{
				int nPackageID = 0;
				foreach (DataRow r in table.Rows)
				{
					nPackageID = ACMS.Convert.ToInt32(r["nPackageID"]);
					sqlClassAttendance.NPackageID = nPackageID;
					DataTable classAttTable = sqlClassAttendance.SelectAllWnPackageIDLogic();
					if (classAttTable.Rows.Count > 0)
						throw new Exception("The item(s) has been used, you are not allow to void the receipt");
					else 
					{
						sqlServiceSession.NPackageID = nPackageID;
						classAttTable = sqlServiceSession.SelectAllWnPackageIDLogic();
						if (classAttTable.Rows.Count > 0)
							throw new Exception("The item(s) has been used, you are not allow to void the receipt");
					}

					r["nEmployeeID"] = User.EmployeeID;
					r["nStatusID"] = 2;
					r["strRemarks"] = "Voided Receipt";
					r["dtLastEdit"] = System.DateTime.Now;
				
					if (r["nGIRORefID"] != DBNull.Value)
					{
						int nGiroRefID = ACMS.Convert.ToInt32(r["nGIRORefID"]);
					
						giro.NGIRORefID = nGiroRefID;
						giro.SelectOne();
						giro.NEmployeeID = User.EmployeeID;
						giro.NStatusID = 4;
						giro.StrRemarks =  "Voided Receipt" + " - " + System.DateTime.Now.ToString("dd/MM/yyyy");			
						giro.Update();
					}
				}
				
				
				memberPackage.SaveData(table);
			}
		}

		private void ActionTakeWhenVoidReceiptForCategory_7(string strReceiptNo, ConnectionProvider connProvider)
		{
			TblMemberCreditPackage memberCreditPackage = new TblMemberCreditPackage();
			memberCreditPackage.MainConnectionProvider = connProvider;
			DataTable table = memberCreditPackage.SelectAllWstrReceiptNo(strReceiptNo);
				
			TblMemberPackage sqlMemberPackage = new TblMemberPackage();
			sqlMemberPackage.MainConnectionProvider = connProvider;


			if (table.Rows.Count > 0)
			{
				int nCreditPackageID = 0;

				foreach (DataRow r in table.Rows)
				{
					nCreditPackageID = ACMS.Convert.ToInt32(r["nCreditPackageID"]);
					sqlMemberPackage.NCreditPackageID = nCreditPackageID;
					DataTable memberPackagetable = sqlMemberPackage.SelectAllWnCreditPackageIDLogic();
                    if (Convert.ToInt32(memberPackagetable.Compute("COUNT(nStatusID)", "nStatusID=0 OR nStatusID=1")) > 0)					
						throw new Exception("The item(s) has been used, you are not allow to void the receipt");

					r["nEmployeeID"] = User.EmployeeID;
					r["nStatusID"] = 2;
					r["strRemarks"] = "Voided Receipt";
					r["dtLastEditDate"] = System.DateTime.Now;
				}
				memberCreditPackage.SaveData(table);
			}

				sqlMemberPackage.StrReceiptNo = strReceiptNo;
				DataTable tblMemPackage = sqlMemberPackage.SelectAllWstrReceiptNo(strReceiptNo);
			
				TblClassAttendance sqlClassAttendance = new TblClassAttendance();
				TblServiceSession sqlServiceSession = new TblServiceSession();

				sqlClassAttendance.MainConnectionProvider = connProvider;
				sqlServiceSession.MainConnectionProvider = connProvider;
			
				if (tblMemPackage.Rows.Count > 0)
				{
					int nPackageID = 0;
					foreach (DataRow row in tblMemPackage.Rows)
					{

						nPackageID = ACMS.Convert.ToInt32(row["nPackageID"]);
						sqlClassAttendance.NPackageID = nPackageID;
						DataTable classAttTable = sqlClassAttendance.SelectAllWnPackageIDLogic();
						if (classAttTable.Rows.Count > 0)
							throw new Exception("The item(s) has been used, you are not allow to void the receipt");
						else 
						{
							sqlServiceSession.NPackageID = nPackageID;
							classAttTable = sqlServiceSession.SelectAllWnPackageIDLogic();
							if (classAttTable.Rows.Count > 0)
								throw new Exception("The item(s) has been used, you are not allow to void the receipt");
						}

						row["nEmployeeID"] = User.EmployeeID;
						row["nStatusID"] = 2;
						row["strRemarks"] = "Voided Receipt";
						row["dtLastEdit"] = System.DateTime.Now;
					}
					sqlMemberPackage.SaveData(tblMemPackage);
				
			}
		}

        private void ActionTakeWhenVoidReceiptForCategory_38(string strReceiptNo, ConnectionProvider connProvider)
        {
            TblReceiptEntries receiptEntries = new TblReceiptEntries();
            receiptEntries.MainConnectionProvider = connProvider;
            DataTable table = receiptEntries.GetQty_StrCodeBaseStrReceiptNo(strReceiptNo);

            if (table.Rows.Count > 0)
            {
                foreach (DataRow r in table.Rows)
                {
                    if (CheckIsRegistrationRow(r)) return;

                    if (r["strCode"].ToString().Length > 0)
                    {
                        string strSQL;
                        strSQL = "select * from tblReceiptPayment rp, tblReceipt r where strPaymentCode='CASHVOUCHER' and rp.strReferenceNo='" + r["strCode"].ToString() + "' and rp.strReceiptNo=r.strReceiptNo  and fVoid=0";
                        DataSet _ds1 = new DataSet();
                        SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA", _ds1, new string[] { "table" }, new SqlParameter("@strSQL", strSQL));

                        //Roll back when cash voucher used
                        if (_ds1.Tables["table"].Rows.Count > 0)
                            throw new Exception("Cash Voucher(s) purchased in this receipt already used in receipt " + _ds1.Tables["table"].Rows[0]["strReceiptNo"] + " under member " + _ds1.Tables["table"].Rows[0]["strMembershipID"] + ".");

                        TblCashVoucher sqlCV = new TblCashVoucher();
                        sqlCV.MainConnectionProvider = connProvider;
                        string strCVCode = r["strCode"].ToString();
                        sqlCV.StrSN = strCVCode;
                        DataTable dtCV = sqlCV.SelectOne();
                        sqlCV.NStatusID = 0;
                        sqlCV.StrSoldToID = System.Data.SqlTypes.SqlString.Null;
                        sqlCV.DtSoldDate = System.Data.SqlTypes.SqlDateTime.Null;
                        sqlCV.StrSoldBranch = System.Data.SqlTypes.SqlString.Null;
                        sqlCV.DtStartDate = System.Data.SqlTypes.SqlDateTime.Null;
                        sqlCV.DtExpiryDate = System.Data.SqlTypes.SqlDateTime.Null;
                        sqlCV.Update();
                        sqlCV.SaveData(table);
                    }
                }
            }
        }

		private void ActionTakeWhenVoidReceiptForCategory_11_12(string strReceiptNo, ConnectionProvider connProvider)
		{
			//string cmdText = "Select sum (nQuantity) as Qty, strCode From tblReceiptEntries where strReceiptNo = @strReceiptNo group by strReceiptNo, strCode";
			TblReceiptEntries receiptEntries = new TblReceiptEntries();
			receiptEntries.MainConnectionProvider = connProvider;
			DataTable table = receiptEntries.GetQty_StrCodeBaseStrReceiptNo(strReceiptNo);
	
			if (table.Rows.Count > 0)
			{
				TblProductInventory productInven = new TblProductInventory();
				productInven.MainConnectionProvider = connProvider;

				foreach (DataRow r in table.Rows)
				{
					if (CheckIsRegistrationRow(r)) return;

					if (r["strCode"].ToString().Length > 0)
					{
						string strCode = r["strCode"].ToString();
						int totalQtyToAddup = ACMS.Convert.ToInt32(r["Qty"]);
						productInven.IncreaseQuantity(strCode, User.BranchCode, totalQtyToAddup);
					}
				}
			}
		}

		private void ActionTakeWhenVoidReceiptForCategory_15(string strReceiptNo, ConnectionProvider connProvider)
		{
			TblLocker locker = new TblLocker();
			TblMember member = new TblMember();
			
			DataTable table = locker.SelectAllWstrReceiptNo(strReceiptNo);
			
			if (table != null && table.Rows.Count > 0)
			{
				member.MainConnectionProvider = connProvider;

				foreach (DataRow r in table.Rows)
				{
					r["nStatusID"] = "0";
					r["strReceiptNo"] = DBNull.Value;
					r["dtExpiry"] = DBNull.Value;
					r["strRemarks"] = DBNull.Value;

					string memberID = r["strMembershipID"].ToString();
					r["strMembershipID"] = DBNull.Value;
					
					member.StrMembershipID = memberID;
					member.SelectOne();
					member.FLockerDeposit = System.Data.SqlTypes.SqlBoolean.True;
					
					member.Update();
				}

				locker.MainConnectionProvider = connProvider;
				locker.SaveData(table);
			}
		}	

		private void ActionTakeWhenVoidReceiptForCategory_0(TblReceipt receipt, ConnectionProvider connProvider)
		{
			if (receipt.StrParentReceiptNo.IsNull || receipt.StrParentReceiptNo.Value.Trim().Length == 0)
			{
				throw new Exception("This is not an outstanding receipt because there is no parent receipt for the given receipt no.");
			}
            else if (!receipt.StrChildReceiptNo.IsNull)
			{
				throw new Exception("The receipt given has child receipt, please void child receipt first before void this receipt");
			}
			else
			{
				decimal mTotalAmount = receipt.MTotalAmount.Value;
                decimal myOutStandingAmt = mTotalAmount;
				
				TblReceipt parentReceipt = new TblReceipt();
                parentReceipt.MainConnectionProvider = connProvider;
				parentReceipt.StrReceiptNo = receipt.StrParentReceiptNo.Value;
				parentReceipt.SelectOne();
				
				parentReceipt.StrChildReceiptNo = System.Data.SqlTypes.SqlString.Null;


                try
                {
                    decimal prevOutstanding = Convert.ToDecimal(parentReceipt.MBalance.Value);
                    decimal remainder = prevOutstanding % ACMS.Convert.ToDecimal(0.05);

                    if (myOutStandingAmt == prevOutstanding - remainder)
                    {
                        myOutStandingAmt = prevOutstanding;                     
                    }
                }
                catch (Exception ex) {}

				//parentReceipt.MOutstandingAmount += ACMS.Convert.ToDecimal(receipt.MTotalAmount);
                //parentReceipt.MOutstandingAmount += ACMS.Convert.ToDecimal(parentReceipt.MBalance);

                parentReceipt.MOutstandingAmount = ACMS.Convert.ToDecimal(myOutStandingAmt);
				
				//parentReceipt.MainConnectionProvider = connProvider;
				parentReceipt.Update();
			}
		}
		
		private void ActionTakeWhenVoidReceiptForCategory_18(string strReceiptNo, ConnectionProvider connProvider)
		{
			//Top-up Spa Credit
			// need to find back the member credit package that been upgraded.
			TblMemberCreditPackage memberCreditPackage = new TblMemberCreditPackage();
			memberCreditPackage.MainConnectionProvider = connProvider;

			TblReceiptEntries sqlReceiptEntiries = new TblReceiptEntries();
			sqlReceiptEntiries.MainConnectionProvider = connProvider;

			sqlReceiptEntiries.StrReceiptNo= strReceiptNo;
			DataTable tableReceiptEntries = sqlReceiptEntiries.SelectAllWstrReceiptNoLogic();

			if (tableReceiptEntries.Rows.Count > 0)
			{
				// Get back the receiptEntries.
				// refer to Pos, strCode=nCreditPackageID,  mSubTotal = topupAmount

				foreach (DataRow r in tableReceiptEntries.Rows)
				{
					if (!CheckIsRegistrationRow(r))
					{
						int nCrdPackageID = ACMS.Convert.ToInt32(r["strCode"]);
						decimal topupAmt = ACMS.Convert.ToInt32(r["mSubTotal"]);
						memberCreditPackage.NCreditPackageID = nCrdPackageID;

						if (memberCreditPackage.SelectOne().Rows.Count > 0)
						{
							memberCreditPackage.MTopupAmount = ACMS.Convert.ToInt32(memberCreditPackage.MTopupAmount) - topupAmt;
							memberCreditPackage.Update();
						}
					}
				}
			}
		}
		
		private bool CheckIsRegistrationRow(DataRow row)
		{
			return row["strCode"].ToString().ToUpper() == "Reg";
		}

		private void ActionTakeWhenVoidReceiptForCategory_19(string strReceiptNo, ConnectionProvider connProvider)
		{
			//Top-up Single Treatment
			// strServiceSession = strCode
			// nSessionID = strReferenceCode
			// find out the service Session and void it..
			TblServiceSession sqlServiceSession = new TblServiceSession();
			sqlServiceSession.MainConnectionProvider = connProvider;

			TblReceiptEntries sqlReceiptEntries = new TblReceiptEntries();
			sqlReceiptEntries.MainConnectionProvider = connProvider;
			
			sqlReceiptEntries.StrReceiptNo = strReceiptNo;
			DataTable tableReceiptEntries = sqlReceiptEntries.SelectAllWstrReceiptNoLogic();

			if (tableReceiptEntries.Rows.Count > 0)
			{
				int nSessionID = 0;
				foreach (DataRow r in tableReceiptEntries.Rows)
				{
					if (!CheckIsRegistrationRow(r))
					{
						nSessionID = ACMS.Convert.ToInt32(r["strReferenceNo"]);
						sqlServiceSession.NSessionID = nSessionID;
						sqlServiceSession.SelectOne();
					
						sqlServiceSession.StrRemarks = "Void Receipt : " + strReceiptNo;
						sqlServiceSession.NStatusID = 1;
						sqlServiceSession.Update();
					}
				}
			}
		}

		private void ActionTakeWhenVoidReceiptForCategory_21(string strReceiptNo, ConnectionProvider connProvider)
		{
			//Mineral Water			
		}

		/*private void ActionTakeWhenVoidReceiptForCategory_20(TblReceipt receipt, ConnectionProvider connProviider)
		{
			string strMembershipID = receipt.StrMembershipID.Value;

			TblCardRequn.StrRemarks = "Void Receipt : " + strReceiptNo;
						sqlServiceSession.NStatusID = 1;
						sqlServiceSession.Update();
					}
				}
			}
		}

		private void ActionTakeWhenVoidReceiptForCategory_21(string strReceiptNo, ConnectionProvider connProvider)
		{
			//Mineral Water			
		}

		/*private void ActionTakeWhenVoidReceiptForCategory_20(TblReceipt receipt, ConnectionProvider connProvider)
		{
			string strMembershipID = receipt.StrMembershipID.Value;

			TblCardRequest cardRequest = new TblCardRequest();
			cardRequest.StrMembershipID = strMembershipID;
			DataTable table = cardRequest.SelectAllWstrMembershipIDLogic();

			if (table != null && table.Rows.Count > 0)
			{
				DataView view = table.DefaultView;
				view.Sort = "nRequestID DESC";
				view[0]["nStatusID"] = 6;
				view[0]["nEmployeeID"] = User.EmployeeID;
				view[0]["dtLastEditDate"] = DateTime.Now;
				
				cardRequest.MainConnectionProvider = connProvider;
				cardRequest.SaveData(table);
			}
		}
		*/

        /*private void ActionTakeWhenVoidReceiptForCategory_17(string strReceiptNo, ConnectionProvider connProvider)
        {
            TblReceiptEntries receiptEntries = new TblReceiptEntries();
            receiptEntries.StrReceiptNo = strReceiptNo;
            DataTable table = receiptEntries.SelectAllWstrReceiptNoLogic();

            if (table != null && table.Rows.Count > 0)
            {
                TblClassAttendance classAttendance = new TblClassAttendance();
                classAttendance.MainConnectionProvider = connProvider;
				
                foreach (DataRow r in table.Rows)
                {
                    int qty = ACMS.Convert.ToInt32(r["nQuantity"]);
                    if (qty == 0) continue;

                    try
                    {
                        int nAttendanceID = Int32.Parse(r["StrCode"].ToString());
                        classAttendance.NAttendanceID = nAttendanceID;
                        classAttendance.SelectOne();
						
                        classAttendance.DtLastEditDate = DateTime.Now;
                        classAttendance.NEmployeeID = User.EmployeeID;
                        if (qty > 0)
                        {
                            classAttendance.FRefunded = System.Data.SqlTypes.SqlBoolean.True;
                            classAttendance.NStatusID = 5;
                        }
                        else 
                        {
                            classAttendance.FRefunded = System.Data.SqlTypes.SqlBoolean.False;
                        }
                        classAttendance.Update();
                    }
lassAttendance.Update();
                    }
                    catch (InvalidCastException)
                    {
                        throw new Exception("Invalid Category ID/Class Attendance ID when try to void a 'Forget Card' Receipt"); 
                    }
                }
            }
        }
        */
    }
}
