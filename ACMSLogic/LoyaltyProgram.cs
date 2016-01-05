using System;
using System.Data;
using System.Data.SqlClient;
using ACMSDAL;
using Microsoft.ApplicationBlocks.Data;

namespace ACMSLogic
{
	/// <summary>
	/// Summary description for LoyaltyProgram.
	/// </summary>
	public class LoyaltyProgram
	{
		private DataTable myDataTable;
		private TblRewardsTransaction myRewardsTrans;
 

		public LoyaltyProgram()
		{
			//
			// TODO: Add constructor logic here
			//
			myRewardsTrans = new TblRewardsTransaction();
			myDataTable = new DataTable();
		}

		public DataTable Table
		{
			get {return myDataTable;}
		}

		public DataTable GetRewardsTransaction(string strMembershipID)
		{
			myRewardsTrans.StrMembershipID = strMembershipID;
			myDataTable = myRewardsTrans.SelectAllWstrMembershipIDLogic();
			
			if (!myDataTable.Columns.Contains("strDescription"))
			{
				DataColumn colDesc = new DataColumn("strDescription", typeof(string));
				myDataTable.Columns.Add(colDesc);
			}

			foreach (DataRow r in myDataTable.Rows)
			{
				if (r["nTypeID"].ToString() == "0")
				{
					r["strDescription"] = "Introduce A Friend";
				}
				else if (r["nTypeID"].ToString() == "1")
				{
					r["strDescription"] = "Receipt (for purchase)";
				}
				else if (r["nTypeID"].ToString() == "2")
				{
					r["strDescription"] = "Redemption";
				}
				else if (r["nTypeID"].ToString() == "3")
				{
					r["strDescription"] = "Void receipt";
				}
                else if (r["nTypeID"].ToString() == "9")
                {
                    r["strDescription"] = "Game Loyalty Point Reward";
                }
			}
			return myDataTable;
		}
		
		public void DeleteRedemption(int nTransactionID, int qtyOfItemToRestoreAfterDelete)
		{
			TblRewardsTransaction rewardTrans = new TblRewardsTransaction();
			rewardTrans.NTransactionID = nTransactionID;
			rewardTrans.SelectOne();

            if (rewardTrans.NTypeID != 2 || (Convert.ToDateTime(rewardTrans.DtDate.Value).Date != DateTime.Now.Date && ACMSLogic.User.RightsLevelID != 9000))
                throw new Exception("You have no right to delete this record. It is not a redemption or the redemption date is before today. ");

			string itemCode = rewardTrans.StrReferenceNo.IsNull ? "" : rewardTrans.StrReferenceNo.Value;

            //TblProductInventory productInvent = new TblProductInventory();
            //productInvent.StrProductCode = itemCode;
            //productInvent.SelectOne();

            //productInvent.NQuantity = ACMS.Convert.ToInt32(productInvent.NQuantity) + qtyOfItemToRestoreAfterDelete;

			ACMSDAL.ConnectionProvider connProvider = new ConnectionProvider();

			try
			{
				
				rewardTrans.MainConnectionProvider = connProvider;
				//productInvent.MainConnectionProvider = connProvider;

				connProvider.OpenConnection();
				connProvider.BeginTransaction("DeleteRedemption");
				rewardTrans.Delete();
				//productInvent.Update();

				connProvider.CommitTransaction();
			}
			catch (Exception)
			{
				connProvider.RollbackTransaction("DeleteRedemption");
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
				rewardTrans.MainConnactionIsCreatedLocal = true;
				//productInvent.MainConnactionIsCreatedLocal = true;
			}
			
		}

        public string GetCurrentYearExpiredPoint(SqlConnection conn, string strMembershipID)
        {
            DataSet _ds = new DataSet();
         
            string strSql = "sp_GetCurrentYearExpiredPoint";
            ACMSDAL.ConnectionProvider connProvider = new ConnectionProvider();
            connProvider.OpenConnection();
            SqlCommand cmd_NewLead = conn.CreateCommand();
            cmd_NewLead.CommandText = strSql;
            cmd_NewLead.CommandType = CommandType.StoredProcedure;

            cmd_NewLead.Parameters.Add(new SqlParameter("@strMembershipID", strMembershipID));
            SqlHelper.FillDataset(conn, CommandType.StoredProcedure, "sp_GetCurrentYearExpiredPoint", _ds, new string[] { "Table" }, new SqlParameter("@strMembershipID", strMembershipID));
            
            if (_ds.Tables[0].Rows.Count>0)
                return "Current Year Expired Points: " + _ds.Tables[0].Rows[0]["ExpiredPoint"].ToString();
            else
                return "";
        }

        public void NewRedemption(string strMembershipID, string itemCode, int qtyOfItemCodeToRedempt, ref int strTransNo)
        {
            ACMSDAL.ConnectionProvider connProvider = new ConnectionProvider();
            connProvider.OpenConnection();
            TblRewardsCatalogue catalogue = new TblRewardsCatalogue();
            catalogue.StrItemCode = itemCode;
            catalogue.SelectOne();

            TblRewardsTransaction rewardTrans = new TblRewardsTransaction();
            rewardTrans.MainConnectionProvider = connProvider;
            rewardTrans.StrMembershipID = strMembershipID;
            rewardTrans.DtDate = DateTime.Now;
            rewardTrans.NTypeID = 2;
            rewardTrans.StrReferenceNo = itemCode;
            rewardTrans.NEmployeeID = User.EmployeeID;
            rewardTrans.StrBranchCode = User.BranchCode;
            
            if (!catalogue.DRewardsPoints.IsNull)
                rewardTrans.DRewardsPoints = -catalogue.DRewardsPoints.Value * qtyOfItemCodeToRedempt;

            rewardTrans.Insert();
            strTransNo = rewardTrans.NTransactionID.Value; 
            TblPromotionFreebie promoFreebie = new TblPromotionFreebie();
            promoFreebie.StrPromotionCode = itemCode;
            DataTable receiptFreebieTable = promoFreebie.SelectAllWstrPromotionCodeLogic();
            //Code selected is Promotion Freebie Code
            if (receiptFreebieTable.Rows.Count > 0)
            {
                //TblProductInventory proInven = new TblProductInventory();
                //proInven.MainConnectionProvider = connProvider;

                //// deduct stock
                //foreach (DataRow r in receiptFreebieTable.Rows)
                //{
                //    proInven.IncreaseQuantity(r["strItemCode"].ToString(), User.BranchCode, -qtyOfItemCodeToRedempt);
                //}
            }
            else
            {
                //Code selected is Package Code  
                TblPackage pkg = new TblPackage();
                pkg.StrPackageCode = itemCode;
                DataTable pkgTable = pkg.SelectOne();
                if (pkgTable.Rows.Count > 0)
                {
                    TblMemberPackage mp = new TblMemberPackage();
                    mp.SelectAll();
                    MemberPackage memberPackage = new MemberPackage();
                    DataTable memberPackageTable = memberPackage.New(false, strMembershipID);
                    DataRow memberPackageRow = memberPackageTable.Rows[0];

                    memberPackageRow["strMembershipID"] = strMembershipID;
                    memberPackageRow["dtPurchaseDate"] = DateTime.Now;
                    memberPackageRow["strRemarks"] = "REWARDS";
                    memberPackageRow["nStatusID"] = 0;
                    memberPackageRow["strPackageCode"] = itemCode;
                    memberPackageRow["fFree"] = 1;

                    mp.SaveData(memberPackageTable);
                }
                else
                {
                    //Code selected is Product Code
                    //TblProductInventory productInvent = new TblProductInventory();
                    //productInvent.MainConnectionProvider = connProvider;
                    //productInvent.StrProductCode = itemCode;
                    //productInvent.SelectOne();

                    //productInvent.NQuantity = ACMS.Convert.ToInt32(productInvent.NQuantity) - qtyOfItemCodeToRedempt;
                    //productInvent.Update();
                }
            }

            if (connProvider.CurrentTransaction != null)
                connProvider.CurrentTransaction.Dispose();

            if (connProvider.DBConnection != null)
            {
                if (connProvider.DBConnection.State == ConnectionState.Open)
                    connProvider.DBConnection.Close();
            }

        }
	}
}
