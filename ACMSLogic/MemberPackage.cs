using System;
using System.Data;
using System.Data.SqlClient;
using ACMSDAL;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;
using System.Windows.Forms;

namespace ACMSLogic
{
	/// <summary>
	/// Summary description for MemberPackage.
	/// </summary>
	public class MemberPackage
	{
        private string connectionString;
        private SqlConnection connection;
		private TblAudit myAudit;
		private TblMemberPackage myMemberPackage;
		private DataTable myDataTable;
		
		

		public MemberPackage()
		{
			//
			// TODO: Add constructor logic here
			//
            connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"];
            connection = new SqlConnection(connectionString);
			myMemberPackage = new TblMemberPackage();
			myAudit = new TblAudit();
		}


		private void Init()
		{
			myMemberPackage = new TblMemberPackage();
			//myDataTable = myMemberPackage.SelectAll(); 
		}

        public void Refresh(string strMembershipID, string strMembershipPackageCode)
		{
			if (strMembershipID == "") strMembershipID = "-1";
			
			//UpdateExpiryStatus(strMembershipID);
			myDataTable = myMemberPackage.SelectActivenExpiryMemberPackage(strMembershipID);
            //CalculateBalance(strMembershipID, strMembershipPackageCode);
		}

        //2006 strPackage,  strRemark
        public static void CreateFreeMemberSpaPackage_IntroFriend(string strMembershipID, string strPackage, string strRemark, ref int nPackageID)
        {
            TblMemberPackage sqlMemberPackage = new TblMemberPackage();
                sqlMemberPackage.StrMembershipID = strMembershipID;
                sqlMemberPackage.StrPackageCode = strPackage;
                sqlMemberPackage.DtPurchaseDate = DateTime.Now;
                sqlMemberPackage.NStatusID = 0;
                sqlMemberPackage.NEmployeeID = User.EmployeeID;
                sqlMemberPackage.DtLastEdit = DateTime.Now;
                sqlMemberPackage.nAdjust = 0;
                sqlMemberPackage.nBalance = 1;
                sqlMemberPackage.StrRemarks = strRemark;
                sqlMemberPackage.FFree =  true ;
                sqlMemberPackage.Insert();
                nPackageID = sqlMemberPackage.NPackageID.Value;

        }

		public static void CreateUnlinkedMemberPackage(string strMembershipID, ref int nPackageID)
		{
			TblMemberPackage sqlMemberPackage = new TblMemberPackage();
			//bool haveUnLinkedPackage = sqlMemberPackage.IsMemberHaveUnLinkedPackage(strMembershipID);
            DataTable dt = sqlMemberPackage.GetMemberUnLinkedPackage(strMembershipID);
			//if (!haveUnLinkedPackage)
			if(dt.Rows.Count==0)
            {
				sqlMemberPackage.StrMembershipID = strMembershipID;
				sqlMemberPackage.StrPackageCode = "Unlinked";
				sqlMemberPackage.DtPurchaseDate = DateTime.Now;
				sqlMemberPackage.DtStartDate = DateTime.Now;
				sqlMemberPackage.DtExpiryDate = DateTime.Today.AddYears(10);
				sqlMemberPackage.NStatusID = 2; //Delete status, so that it can be found in normal memberpackage
				sqlMemberPackage.NEmployeeID = User.EmployeeID;
				sqlMemberPackage.DtLastEdit = DateTime.Now;
				sqlMemberPackage.nAdjust=0;
				sqlMemberPackage.nBalance=1;
				sqlMemberPackage.Insert();

				nPackageID = sqlMemberPackage.NPackageID.Value;
			}
			else
			{
                //sqlMemberPackage.StrPackageCode= "Unlinked";
                //DataTable table = sqlMemberPackage.SelectAllWstrPackageCodeLogic();
				nPackageID = ACMS.Convert.ToInt32(dt.Rows[0]["nPackageID"]);
			}
		}

		/// <summary>
		/// Balance for new member package is not allow to set nMaxSession is bcoz need the value zero
		/// to do calculation In POS
		/// </summary>
		/// <param name="strMembershipID"></param>
		/// <returns></returns>
        public DataView GetActive_n_NonFreeMemberPackage_For_POS_Calculation(string strMembershipID)
        {
            //DataTable table = myMemberPackage.GetActivenNonFreeMemberPackage(strMembershipID);
            DataTable table = myMemberPackage.GetActivenNonFreeMemberPackage(strMembershipID);

            if (table != null)
            {
                if (!table.Columns.Contains("Balance"))
                {
                    DataColumn colBalance = new DataColumn("Balance", System.Type.GetType("System.Int32"));
                    table.Columns.Add(colBalance);
                }
                if (!table.Columns.Contains("FNew"))
                {
                    DataColumn colNew = new DataColumn("FNew", System.Type.GetType("System.Int32"));
                    table.Columns.Add(colNew);
                }

                TblClassAttendance classAttendance = new TblClassAttendance();
                TblServiceSession serviceSession = new TblServiceSession();

                foreach (DataRow r in table.Rows)
                {
                    int nCategoryID = ACMS.Convert.ToInt32(r["nCategoryID"]);
                    int nPackageID = ACMS.Convert.ToInt32(r["nPackageID"]);
                    // class Attendance
                    if (nCategoryID == 1 || nCategoryID == 2)
                    {
                        classAttendance.NPackageID = nPackageID;
                        DataView classAttendanceTable = classAttendance.SelectAllWnPackageIDLogic().DefaultView;
                        classAttendanceTable.RowFilter = "nStatusID = 1 or nStatusID = 2";
                        if (classAttendanceTable.Count > 0)
                        {
                            r["Balance"] = ACMS.Convert.ToInt32(r["nMaxSession"]) - classAttendanceTable.Count;
                            r["FNew"] = 0;
                        }
                        else
                        {
                            r["Balance"] = 0;
                            r["FNew"] = 1;
                        }
                    }
                    else if (nCategoryID == 3 || nCategoryID == 4 || nCategoryID == 5 || nCategoryID == 6) // Service Session
                    {

                        /// Checkout any Outstanding for nCategoryID == 3 PT 13/09/2012 
                        //if (nCategoryID == 3)
                        //{
                        //    ACMSDAL.TblMemberPackage sqlCalcAnyOS = new ACMSDAL.TblMemberPackage();
                        //    int dOutAmount = sqlCalcAnyOS.CalculateAnyOutStandingPayment(strMembershipID, nCategoryID);

                        //    if (dOutAmount > 0)
                        //    {

                        //    }

                        //}
                        /// 
                        serviceSession.NPackageID = nPackageID;
                        DataView serviceSessionTable = serviceSession.SelectAllWnPackageIDLogic().DefaultView;
                        serviceSessionTable.RowFilter = "nStatusID = 5 or nStatusID = 6";
                        if (serviceSessionTable.Count > 0)
                        {
                            r["Balance"] = ACMS.Convert.ToInt32(r["nMaxSession"]) - serviceSessionTable.Count;
                            r["FNew"] = 0;
                        }
                        else
                        {
                            r["Balance"] = 0;
                            r["FNew"] = 1;
                        }
                    }
                }
            }

            table.DefaultView.RowFilter = " Balance > 0 OR (Balance = 0 AND FNew = 1)";
            return table.DefaultView;
        }

        public DataView GetActive_n_NonFreeMemberPackage_For_POS_Calculation_New(ACMSLogic.POS myPOS)
        {
            myDataTable = myMemberPackage.GetActivenNonFreeMemberPackageNew(myPOS.StrMembershipID, myPOS.NCategoryID);
            DeleteOutstandingPackage();
            CalculateBalance(myPOS.StrMembershipID, "");
            DeleteUntouchSamePackage(myPOS);
            CalculateUsageBalanceForConvert(myPOS);
            if (!myDataTable.Columns.Contains("Checked")) 
            {
                DataColumn colChecked = new DataColumn("Checked", typeof(bool));
                myDataTable.Columns.Add(colChecked);
            }
            
            myDataTable.DefaultView.RowFilter = " Balance > 0 ";
            
            return myDataTable.DefaultView;
        }

        private void DeleteUntouchSamePackage(ACMSLogic.POS myPOS)
        {
            foreach (DataRow dr in myDataTable.Rows)
            {
                DataRow[] foundRow = myPOS.ReceiptItemsTable.Select("strCode = '" + dr["strPackageCode"] + "'");

                if (foundRow.Length > 0 && dr["strBalNew"]=="New")
				{                    
                    dr.Delete();                 
                }
            }
            myDataTable.AcceptChanges();
        }

        private void DeleteOutstandingPackage()
        {
            foreach (DataRow dr in myDataTable.Rows)
            {
                DataSet _ds = new DataSet();
                string strSQL = "Select dbo.GetReceiptOutstandingAmount('" + dr["strReceiptNo"].ToString() + "') as mOutStandingAmount ";
                SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA", _ds, new string[] { "Table" }, new SqlParameter("@strSQL", strSQL));

                if (_ds.Tables["table"].Rows[0]["mOutStandingAmount"].ToString() != "")
                {
                    if (Convert.ToDouble(_ds.Tables["table"].Rows[0]["mOutStandingAmount"]) > 0)
                    {
                        dr.Delete();
                        //myDataTable.Rows.Remove(dr);

                    }
                }

                _ds.Dispose();
            }
            myDataTable.AcceptChanges();
        }


        /// <summary>
        /// Balance for new member package is not allow to set nMaxSession is bcoz need the value zero
        /// to do calculation In POS
        /// </summary>
        /// <param name="strMembershipID"></param>
        /// <returns></returns>
        /// start jackie 4/3/2012
        public DataView GetActive_n_NonFreeMemberPackage_Convert_Calculation(string strMembershipID)
        {
            DataTable table = myMemberPackage.GetActivenNonFreeMemberPackage(strMembershipID);

            if (table != null)
            {
                if (!table.Columns.Contains("Balance"))
                {
                    DataColumn colBalance = new DataColumn("Balance", System.Type.GetType("System.Int32"));
                    table.Columns.Add(colBalance);
                }
                if (!table.Columns.Contains("FNew"))
                {
                    DataColumn colNew = new DataColumn("FNew", System.Type.GetType("System.Int32"));
                    table.Columns.Add(colNew);
                }

                TblClassAttendance classAttendance = new TblClassAttendance();
                TblServiceSession serviceSession = new TblServiceSession();

                foreach (DataRow r in table.Rows)
                {
                    int nCategoryID = ACMS.Convert.ToInt32(r["nCategoryID"]);
                    int nPackageID = ACMS.Convert.ToInt32(r["nPackageID"]);
                    // class Attendance
                    if (nCategoryID == 1 || nCategoryID == 2)
                    {
                        classAttendance.NPackageID = nPackageID;
                        DataView classAttendanceTable = classAttendance.SelectAllWnPackageIDLogic().DefaultView;
                        classAttendanceTable.RowFilter = "nStatusID = 1 or nStatusID = 2";
                        if (classAttendanceTable.Count > 0)
                        {
                          //  r["Balance"] = ACMS.Convert.ToInt32(r["nMaxSession"]) - classAttendanceTable.Count;
                            r["Balance"] = (ACMS.Convert.ToInt32(r["mbaseunitprice"]) * classAttendanceTable.Count);
                            r["FNew"] = 0;
                        }
                        else
                        {
                            r["Balance"] = 0;
                            r["FNew"] = 1;
                        }
                    }
                    else if (nCategoryID == 3 || nCategoryID == 4 || nCategoryID == 5 || nCategoryID == 6) // Service Session
                    {
                        serviceSession.NPackageID = nPackageID;
                        DataView serviceSessionTable = serviceSession.SelectAllWnPackageIDLogic().DefaultView;
                        serviceSessionTable.RowFilter = "nStatusID = 5 or nStatusID = 6";
                        if (serviceSessionTable.Count > 0)
                        {
                           // r["Balance"] = ACMS.Convert.ToInt32(r["nMaxSession"]) - serviceSessionTable.Count;
                            r["Balance"] =ACMS.Convert.ToInt32(r["mlistprice"])- (ACMS.Convert.ToInt32(r["mbaseunitprice"]) * serviceSessionTable.Count);
                            r["FNew"] = 0;
                        }
                        else
                        {
                            r["Balance"] = 0;
                            r["FNew"] = 1;
                        }
                    }
                }
            }

            table.DefaultView.RowFilter = " Balance > 0 OR (Balance = 0 AND FNew = 1)";
            return table.DefaultView;
        }//end jackie 4/3/2012
		private void CalculateBalance(string strMembershipID,string strMembershipPackageCode)            
		{
			if (myDataTable != null)
			{
                if (!myDataTable.Columns.Contains("strBalNew"))
                {
                    DataColumn colBalNew = new DataColumn("strBalNew", System.Type.GetType("System.String"));
                    myDataTable.Columns.Add(colBalNew);
                }

				if (!myDataTable.Columns.Contains("Balance"))
				{
					DataColumn colBalance = new DataColumn("Balance", System.Type.GetType("System.Int32"));
					myDataTable.Columns.Add(colBalance);
				}

                if (!myDataTable.Columns.Contains("strPackageType"))
                {
                    DataColumn colPackageType = new DataColumn("strPackageType", System.Type.GetType("System.String"));
                    myDataTable.Columns.Add(colPackageType);
                }
                
				TblClassAttendance classAttendance = new TblClassAttendance();
				TblServiceSession serviceSession = new TblServiceSession();

				DataTable gymTable = new DataTable();
				DataColumn colDtdate = new DataColumn("dtDate", typeof(string));
				DataColumn colPackageID = new DataColumn("nPackageID", typeof(int));
				DataColumn colAttendanceID = new DataColumn("nAttendanceID", typeof(int));
				gymTable.Columns.Add(colDtdate);
				gymTable.Columns.Add(colPackageID);
				gymTable.Columns.Add(colAttendanceID);

				foreach (DataRow r in myDataTable.Rows)
				{
					r["Balance"] = r["nMaxSession"];

					if (ACMS.Convert.ToInt32(r["nMaxSession"]) == 9999)
					{
						r["Balance"] = 9999;
                        r["strBalNew"] = r["Balance"].ToString();
                        if (r["dtStartDate"] == DBNull.Value)
                            r["strBalNew"] = "New";
                        else
                        {
                            if (r["strPackageType"].ToString() == "Normal Package")
                            {
                                if (ACMS.Convert.ToInt32(r["nMaxSession"]) == ACMS.Convert.ToInt32(r["Balance"]) && ACMS.Convert.ToInt32(r["nMaxSession"])!=9999)
                                    r["strBalNew"] = "New";
                            }
                        }
						continue;
					}

					int nCategoryID = ACMS.Convert.ToInt32(r["nCategoryID"]);
					int nPackageID = ACMS.Convert.ToInt32(r["nPackageID"]);
					// class Attendance
					if (nCategoryID == 1 || nCategoryID == 2)
					{

						classAttendance.NPackageID = nPackageID;
						DataTable classAttendanceTable = classAttendance.SelectAllWnPackageIDLogic();
					
						if (classAttendanceTable == null || classAttendanceTable.Rows.Count == 0) 
						{
							if (ACMS.Convert.ToDBInt32(r["nAdjust"])>=1 && ACMS.Convert.ToInt32(r["nMaxSession"]) < 9999)
							{
								r["Balance"]=ACMS.Convert.ToDBInt32(r["Balance"])-ACMS.Convert.ToDBInt32(r["nAdjust"]);
							}
                            r["strBalNew"] = r["Balance"].ToString();
                            if (r["dtStartDate"] == DBNull.Value)
                                r["strBalNew"] = "New";
                            else
                            {
                                if (r["strPackageType"].ToString() == "Normal Package")
                                {
                                    if (ACMS.Convert.ToInt32(r["nMaxSession"]) == ACMS.Convert.ToInt32(r["Balance"]))
                                        r["strBalNew"] = "New";
                                }
                            }
							continue;
						}

						DataView classAttendanceTableView = classAttendanceTable.DefaultView;

						// Need to filter out the non GYM attendance here
						classAttendanceTableView.RowFilter = "((nStatusID = 1 or nStatusID = 2) AND nTypeID = 0)";

						if (classAttendanceTableView.Count > 0)
						{                          
                            
                            ACMSDAL.TblMemberPackage sqlFindPackageCode = new ACMSDAL.TblMemberPackage();
                            string strPackageCode = sqlFindPackageCode.GetPackageCode(strMembershipID, nPackageID);

                            //if (strPackageCode == "AA(1080/12)" || strPackageCode == "AA(2160/24)" )
                            //{
                            //    r["Balance"] = ACMS.Convert.ToInt32(r["Balance"]) - myDTransactionID;
                            //}

                            if (r["fEntries"].ToString()=="True")
                            {
                                if (nCategoryID == 2) //2604
                                {
                                    string strPackageID = nPackageID.ToString();
                                    ACMSDAL.TblMemberPackage sqlCalcTotalGIRO = new ACMSDAL.TblMemberPackage();//jackie 15/03/2012
                                    int intTotalGIRO = sqlCalcTotalGIRO.CalculateTotalGIRO(strMembershipID, strPackageID, strPackageCode);

                                    ACMSDAL.TblMemberPackage sqlCalcPackages = new ACMSDAL.TblMemberPackage();
                                    int myDTransactionID = sqlCalcPackages.CalculateSpecialSessionPackages(strMembershipID, nPackageID);
                                    r["Balance"] = (intTotalGIRO * ACMS.Convert.ToInt32(r["Balance"])) - myDTransactionID;
                                }
                                else
                                {
                                    //1203 jackie
                                    ACMSDAL.TblMemberPackage sqlCalcPackages = new ACMSDAL.TblMemberPackage();
                                    int myDTransactionID = sqlCalcPackages.CalculateSpecialSessionPackages(strMembershipID, nPackageID);
                                    r["Balance"] = ACMS.Convert.ToInt32(r["Balance"]) - myDTransactionID;
                                }
                            }
                            else//2604
                                if ( strPackageCode == "FTRIAL")
                                {
                                    r["Balance"] =  classAttendanceTableView.Count;
                                }
                                else
                            {

                                if (nCategoryID == 2 || ACMS.Convert.ToInt32(r["Balance"]) == 9999) //2604
                                {
                                    string strPackageID = nPackageID.ToString();
                                    ACMSDAL.TblMemberPackage sqlCalcTotalGIRO = new ACMSDAL.TblMemberPackage();//jackie 15/03/2012
                                    int intTotalGIRO = sqlCalcTotalGIRO.CalculateTotalGIRO(strMembershipID, strPackageID,strPackageCode);
                                    r["Balance"] = (intTotalGIRO * ACMS.Convert.ToInt32(r["Balance"])) - classAttendanceTableView.Count;

                                }
                                else
                                {
                                    r["Balance"] = ACMS.Convert.ToInt32(r["Balance"]) - classAttendanceTableView.Count;
                                }
                            }

						}
                        else
                        {
                            if (nCategoryID == 2) //2604
                            {
                                if (r["fEntries"].ToString() == "True")
                                {
                                    ACMSDAL.TblMemberPackage sqlFindPackageCode = new ACMSDAL.TblMemberPackage();
                                    string strPackageCode = sqlFindPackageCode.GetPackageCode(strMembershipID, nPackageID);
                                    string strPackageID = nPackageID.ToString();
                                    ACMSDAL.TblMemberPackage sqlCalcTotalGIRO = new ACMSDAL.TblMemberPackage();//jackie 15/03/2012
                                    int intTotalGIRO = sqlCalcTotalGIRO.CalculateTotalGIRO(strMembershipID, strPackageID, strPackageCode);

                                    ACMSDAL.TblMemberPackage sqlCalcPackages = new ACMSDAL.TblMemberPackage();
                                    int myDTransactionID = sqlCalcPackages.CalculateSpecialSessionPackages(strMembershipID, nPackageID);
                                    r["Balance"] = (intTotalGIRO * ACMS.Convert.ToInt32(r["Balance"]));
                                }
                                else
                                {
                                    ACMSDAL.TblMemberPackage sqlFindPackageCode = new ACMSDAL.TblMemberPackage();
                                    string strPackageCode = sqlFindPackageCode.GetPackageCode(strMembershipID, nPackageID);
                                    string strPackageID = nPackageID.ToString();
                                    ACMSDAL.TblMemberPackage sqlCalcTotalGIRO = new ACMSDAL.TblMemberPackage();//jackie 15/03/2012
                                    int intTotalGIRO = sqlCalcTotalGIRO.CalculateTotalGIRO(strMembershipID, strPackageID, strPackageCode);
                                    r["Balance"] = (intTotalGIRO * ACMS.Convert.ToInt32(r["Balance"]));
                                }
                            }
                        }

						if (ACMS.Convert.ToDBInt32(r["nAdjust"])>=1 && ACMS.Convert.ToInt32(r["nMaxSession"]) < 9999)
						{
							r["Balance"]=ACMS.Convert.ToDBInt32(r["Balance"])-ACMS.Convert.ToDBInt32(r["nAdjust"]);

						}



						// Start calculate the POWER Package
						// It is consider PWR Package if the class attendance is GYM Class
						classAttendanceTableView.RowFilter = "((nStatusID = 1 or nStatusID = 2) AND nTypeID = 1 AND nPackageID ='" +nPackageID+ "')";
					
						if (classAttendanceTableView.Count > 0)
						{
							for (int i = 0; i < classAttendanceTableView.Count; i ++)
							{
								DataRow row = classAttendanceTableView[i].Row;
								string  dtDate = ACMS.Convert.ToDateTime(row["dtDate"]).ToString("yyyy/MM/dd");
								int nAttendanceID = ACMS.Convert.ToInt32(row["nAttendanceID"]);

								DataRow[] foundRow = gymTable.Select("dtDate = '" + dtDate + "'" + "AND nPackageID = '" + nPackageID + "'");
						
								if (foundRow.Length == 0)
								{
									DataRow addRow = gymTable.NewRow();	
									addRow["dtDate"] = dtDate;
									addRow["nPackageID"] = nPackageID;
									addRow["nAttendanceID"] = nAttendanceID;
									gymTable.Rows.Add(addRow);
								}
							}
						
							foreach (DataRow pRow in gymTable.Rows)
							{
								DateTime dtDate = ACMS.Convert.ToDateTime(pRow["dtDate"]);
								int nPackageIDInGymTable = ACMS.Convert.ToInt32(pRow["nPackageID"]);
							
								string strFilter = string.Format("(nStatusID = 1 or nStatusID = 2) "  + 
									" AND nTypeID = 0 AND nPackageID = {0} AND DtDate = #{1}#", nPackageID, dtDate.ToString("yyyy/MM/dd"));

								DataRow[] foundRow = classAttendanceTable.Select(strFilter, "nPackageID", DataViewRowState.CurrentRows);
							
								if (foundRow.Length > 0)
									r["Balance"] = ACMS.Convert.ToInt32(r["Balance"]) + 1;
							}

                            if (gymTable.Rows.Count>0)
                                r["Balance"] = ACMS.Convert.ToInt32(r["Balance"]) - gymTable.Rows.Count;

                            gymTable.Rows.Clear();
                            ////////////

                            //ACMSDAL.TblMemberPackage sqlCalcPackages = new ACMSDAL.TblMemberPackage();//jackie 15/03/2012
                            //int myDTransactionID = sqlCalcPackages.CalculateSpecialSessionPackages(strMembershipID, nPackageID);

                            //ACMSDAL.TblMemberPackage sqlFindPackageCode = new ACMSDAL.TblMemberPackage();
                            //string strPackageCode = sqlFindPackageCode.GetPackageCode(strMembershipID, nPackageID);

                            ////if (strPackageCode == "AA(1080/12)" || strPackageCode == "AA(2160/24)")
                            ////{
                            ////    r["Balance"] = ACMS.Convert.ToInt32(r["nMaxSession"]) - myDTransactionID;
                            ////}
                            //if (r["fEntries"].ToString() == "True")
                            //{
                            //    r["Balance"] = ACMS.Convert.ToInt32(r["nMaxSession"]) - myDTransactionID;
                            //}
                            //else
                            //    if (strPackageCode == "FTRIAL")
                            //    {
                            //        r["Balance"] = myDTransactionID;
                            //    }
                            //    else



                            //    /////////
                            //    {
                            //        r["Balance"] = ACMS.Convert.ToInt32(r["Balance"]) - gymTable.Rows.Count;

                            //    }
                            //gymTable.Rows.Clear();

						}						
					}
                    else if (nCategoryID == 3 || nCategoryID == 4 || nCategoryID == 5 || nCategoryID == 6 || nCategoryID == 34) // Service Session
					{
						serviceSession.NPackageID = nPackageID;
						DataView serviceSessionTable = serviceSession.SelectAllWnPackageIDLogic().DefaultView;
						serviceSessionTable.RowFilter = "nStatusID = 5 or nStatusID = 6";

                        if (nCategoryID == 34)
                        {
                            r["Balance"] = ACMS.Convert.ToInt32(r["Balance"]) - serviceSessionTable.Count + ACMS.Convert.ToDBInt32(r["nAdjust"]);
                        }
                        else
                        {

                            ACMSDAL.TblMemberPackage sqlCalcPackages = new ACMSDAL.TblMemberPackage();//jackie 15/03/2012
                            int myDTransactionID = sqlCalcPackages.CalculateSpecialSessionPackages(strMembershipID, nPackageID);
                            
                            ACMSDAL.TblMemberPackage sqlFindPackageCode = new ACMSDAL.TblMemberPackage();
                            string strPackageCode = sqlFindPackageCode.GetPackageCode(strMembershipID, nPackageID);

                            if (strPackageCode == "AA(1080/12)" || strPackageCode == "AA(2160/24)" )
                            {
                                r["Balance"] = ACMS.Convert.ToInt32(r["Balance"]) - myDTransactionID;
                            }
                            else
                                if (strPackageCode == "FTRIAL")
                                {
                                    r["Balance"] =  myDTransactionID;
                                }
                                else
                            {

                                if (nCategoryID == 2 || ACMS.Convert.ToInt32(r["Balance"]) == 9999) //2604
                   
                                {

                                    string strPackageID = nPackageID.ToString();
                                    ACMSDAL.TblMemberPackage sqlCalcTotalGIRO = new ACMSDAL.TblMemberPackage();//jackie 15/03/2012
                                    int intTotalGIRO = sqlCalcTotalGIRO.CalculateTotalGIRO(strMembershipID, strPackageID,strPackageCode);
                                    r["Balance"] = (intTotalGIRO * ACMS.Convert.ToInt32(r["Balance"])) - serviceSessionTable.Count;
                                }
                                else
                                {
                                    r["Balance"] = ACMS.Convert.ToInt32(r["Balance"]) - serviceSessionTable.Count;
                                }
                            }

                           

                            if (ACMS.Convert.ToDBInt32(r["nAdjust"]) >= 1 && ACMS.Convert.ToInt32(r["nMaxSession"]) < 9999)
                            {

                                //jackie
                                r["Balance"] = ACMS.Convert.ToDBInt32(r["Balance"]) - ACMS.Convert.ToDBInt32(r["nAdjust"]);
                            }
                        }

                        //if (dr["strFreePkgCode"].ToString() != string.Empty)
                        //{
                        //    myPOS.EditItemFreebieAndDiscount(dr["strFreePkgCode"].ToString());
                        //}
					}
                    r["strBalNew"] = r["Balance"].ToString();
                    if (r["dtStartDate"] == DBNull.Value)
                        r["strBalNew"] = "New";
                    else
                    {
                        if (r["strPackageType"].ToString() == "Normal Package")
                        {
                            if (ACMS.Convert.ToInt32(r["nMaxSession"]) == ACMS.Convert.ToInt32(r["Balance"]))
                                r["strBalNew"] = "New"; 
                        }                        
                    }
				}                
			}
		}
        private void CalculateUsageBalance()
        {
            
            if (myDataTable != null)
            {
                if (!myDataTable.Columns.Contains("PaidAmt"))
                {
                    DataColumn colBalance = new DataColumn("PaidAmt", System.Type.GetType("System.Decimal"));
                    myDataTable.Columns.Add(colBalance);
                }
                if (!myDataTable.Columns.Contains("UsedSession"))
                {
                    DataColumn colBalance = new DataColumn("UsedSession", System.Type.GetType("System.Int32"));
                    myDataTable.Columns.Add(colBalance);
                }
                if (!myDataTable.Columns.Contains("UsedAmt"))
                {
                    DataColumn colBalance = new DataColumn("UsedAmt", System.Type.GetType("System.Decimal"));
                    myDataTable.Columns.Add(colBalance);
                }
                if (!myDataTable.Columns.Contains("UsageBalAmt"))
                {
                    DataColumn colBalance = new DataColumn("UsageBalAmt", System.Type.GetType("System.Decimal"));
                    myDataTable.Columns.Add(colBalance);
                }
                                
                foreach (DataRow r in myDataTable.Rows)
                {
                    int usedSession=0;
                    if (ACMS.Convert.ToInt32(r["nMaxSession"]) != 9999)
                    {
                        usedSession = (ACMS.Convert.ToInt32(r["nMaxSession"]) - ACMS.Convert.ToInt32(r["nFreeSession"])) - (ACMS.Convert.ToInt32(r["Balance"])-ACMS.Convert.ToInt32(r["nFreeSession"]));
                    }
                    else
                    {
                        if (r["dtStartDate"] == DBNull.Value)
                            usedSession = 0;
                        else
                        {
                            usedSession = ((DateTime.Now.Month - Convert.ToDateTime(r["dtStartDate"]).Month) + 12 * (DateTime.Now.Year - Convert.ToDateTime(r["dtStartDate"]).Year));
                            //r["nMaxSession"] = r["nPackageDuration"];
                        }                        
                    }                    
                    
                    double usedAmount = usedSession * ACMS.Convert.ToDouble(r["mBaseUnitPrice"]);
                    double subTotal = ACMS.Convert.ToDouble(r["mSubTotal"]);
                    double totalSubTotal = ACMS.Convert.ToDouble(r["totalSubTotal"]);
                    double totalBillDiscount;
                    double packageBillDiscount=0;
                    double packageOutstanding=0;
                    double paidAmount;
                    if (r["strDiscountCode"] != DBNull.Value && ACMS.Convert.ToDouble(r["mNettAmount"]) < totalSubTotal)
                    {
                        totalBillDiscount = totalSubTotal - ACMS.Convert.ToDouble(r["mNettAmount"]);
                        packageBillDiscount = totalBillDiscount * subTotal / totalSubTotal;
                    }

                    if (ACMS.Convert.ToDouble(r["mOutstandingAmount"]) > 0)
                    {
                        packageOutstanding = ACMS.Convert.ToDouble(r["mOutstandingAmount"]) * subTotal / totalSubTotal / 1.07;
                    }
                    paidAmount = (subTotal + ACMS.Convert.ToDouble(r["mUpgradeAmount"]) - packageBillDiscount) - packageOutstanding;
                    r["PaidAmt"] =paidAmount;
                    r["UsedSession"] = usedSession;
                    r["UsedAmt"] = usedAmount;
					r["UsageBalAmt"] = paidAmount - usedAmount;                    
                }
            }
        }

        private int getUsedMonth(DateTime oldDate, DateTime newDate)
        {
            int monthCount = 0, dayCount = 0;
            
            DateTime lastAddDate = oldDate;
            bool isEnd = false;

            while (!isEnd)
            {
                if (lastAddDate.AddMonths(1).AddDays(-1) >= newDate)
                {
                    if (lastAddDate.AddMonths(1).AddDays(-1) == newDate)
                        monthCount += 1;
                    else
                        dayCount += getDiffDaysBetween2Dates(newDate, lastAddDate) + 1;
                    break;
                }
                else
                {
                    monthCount += 1;
                    lastAddDate = lastAddDate.AddMonths(1);
                }
            }

            if (dayCount > 7)
                monthCount += 1;

            return monthCount;
        }

        private int getBalMonthExtend(DateTime oldDate, DateTime newDate)
        {
            int monthCount = 0, dayCount = 0;
            
            DateTime lastAddDate = oldDate;
            bool isEnd = false;

            while (!isEnd)
            {
                if (lastAddDate.AddMonths(1).AddDays(-1) >= newDate)
                {
                    if (lastAddDate.AddMonths(1).AddDays(-1) == newDate)
                        monthCount += 1;
                    else
                        dayCount += getDiffDaysBetween2Dates(newDate, lastAddDate) + 1;
                    break;
                }
                else
                {
                    monthCount += 1;
                    lastAddDate = lastAddDate.AddMonths(1);
                }
            }

            if (dayCount >= 23)
                monthCount += 1;

            return monthCount;
        }

        private int getDiffDaysBetween2Dates(DateTime d1, DateTime d2)
        {
            // Difference in days, hours, and minutes.
            TimeSpan ts = d1 - d2;
            // Difference in days.
            return ts.Days;
        }

        private int getLastDayOfMonth(int m, int y)
        {
            int endOfMonth;
            if (m == 1 && m == 3 && m == 5 && m == 7 && m == 8 && m == 10 && m == 12)
                endOfMonth = 31;
            else if (m == 4 && m == 6 && m == 9 && m == 11)
                endOfMonth = 30;
            else
            {
                if (y % 4 == 0)
                    endOfMonth = 29;
                else
                    endOfMonth = 28;
            }
            return endOfMonth;
        }

		private void CalculateUsageBalanceForConvert(ACMSLogic.POS myPOS)
        {
            if (myDataTable != null)
            {
                if (!myDataTable.Columns.Contains("PaidAmt"))
                {
                    DataColumn colBalance = new DataColumn("PaidAmt", System.Type.GetType("System.Decimal"));
                    myDataTable.Columns.Add(colBalance);
                }
                if (!myDataTable.Columns.Contains("UsedSession"))
                {
                    DataColumn colBalance = new DataColumn("UsedSession", System.Type.GetType("System.Int32"));
                    myDataTable.Columns.Add(colBalance);
                }
                if (!myDataTable.Columns.Contains("UsedAmt"))
                {
                    DataColumn colBalance = new DataColumn("UsedAmt", System.Type.GetType("System.Decimal"));
                    myDataTable.Columns.Add(colBalance);
                }
                if (!myDataTable.Columns.Contains("UsageBalAmt"))
                {
                    DataColumn colBalance = new DataColumn("UsageBalAmt", System.Type.GetType("System.Decimal"));
                    myDataTable.Columns.Add(colBalance);
                }
                if (!myDataTable.Columns.Contains("strCalculation"))
                {
                    DataColumn colBalance = new DataColumn("strCalculation", System.Type.GetType("System.String"));
                    myDataTable.Columns.Add(colBalance);
                }

                //Added by TBBC on 9 September 2015 for SG 50 Promotion Upgrade Issue
                if (!myDataTable.Columns.Contains("PromoDis"))
                {
                    DataColumn colBalance = new DataColumn("PromoDis", System.Type.GetType("System.String"));
                    myDataTable.Columns.Add(colBalance);
                }

                DataTable dtSG50Promo;
                bool bolSG50Promo;
                bolSG50Promo = false;

                foreach (DataRow r in myDataTable.Rows)
                {
                    dtSG50Promo = myMemberPackage.GetSG50PromotionUpgrade(r["strReceiptNo"].ToString());

                    foreach (DataRow row in dtSG50Promo.Rows)
                    {
                        if ((ACMS.Convert.ToInt32(r["nPackageID"])) == (ACMS.Convert.ToInt32(row["nPackageID"])))
                        {
                            r["mSubTotal"] = row["mSubTotal"];
                            r["PromoDis"] = row["PromoDis"];
                            bolSG50Promo = true;
                        }
                    }

                    string strCalculation = "Calculation:\n";
                    int usedSession = 0;
                    if (ACMS.Convert.ToInt32(r["nMaxSession"]) != 9999)
                    {
                        usedSession = (ACMS.Convert.ToInt32(r["nMaxSession"]) - ACMS.Convert.ToInt32(r["nFreeSession"])) - (ACMS.Convert.ToInt32(r["Balance"]) - ACMS.Convert.ToInt32(r["nFreeSession"]));
                    }
                    else
                    {
                        if (r["dtStartDate"] == DBNull.Value || r["dtExpiryDate"] == DBNull.Value)
                            usedSession = 0;
                        else
                        {
                            strCalculation += "Unlimited Session Conversion:\n";
                            DateTime DtExpiryDate = Convert.ToDateTime(r["dtStartDate"]).AddMonths(Convert.ToInt16(r["nPackageDuration"])).AddDays(-1);
                            int extMonths=0;
                            if (Convert.ToDateTime(r["dtExpiryDate"]) > DtExpiryDate) //extension case
                            {
                                strCalculation += "Package Duration Extension Case: Yes\n";
                                int balMonth = getBalMonthExtend(DateTime.Now, Convert.ToDateTime(r["dtExpiryDate"]));
                                strCalculation += "Balance Months: " + balMonth.ToString() + "\n";
                                usedSession = Convert.ToInt16(r["nPackageDuration"]) - balMonth;                                
                            }
                            //extMonths = (Convert.ToDateTime(r["dtExpiryDate"]).Month - DtExpiryDate.Month) + 12 * (Convert.ToDateTime(r["dtExpiryDate"]).Year - DtExpiryDate.Year) - Convert.ToInt16(r["nFreeDuration"]);                                                      
                            else                            
                                usedSession = getUsedMonth(Convert.ToDateTime(r["dtStartDate"]), DateTime.Now);

                            strCalculation += "Used Months: " + usedSession.ToString() + "\n";
                            //usedSession = ((DateTime.Now.Month - Convert.ToDateTime(r["dtStartDate"]).Month) + 12 * (DateTime.Now.Year - Convert.ToDateTime(r["dtStartDate"]).Year)) - extMonths;
                            //r["nMaxSession"] = Convert.ToInt16(r["nPackageDuration"]);
                        }
                    }
                    bool isSameSpaCat = false;
                    if (ACMS.Convert.ToInt32(myPOS.NCategoryID) == ACMS.Convert.ToInt32(r["nCategoryID"]) && myPOS.NCategoryID == 5 && r["strFreePkgCode"] != DBNull.Value)
                    {
                        //spa package same category conversion                                       
                        foreach (DataRow dr in myPOS.ReceiptItemsTable.Rows)
                        {
                            TblPackage package = new TblPackage();
                            package.StrPackageCode = dr["strCode"].ToString();
                            package.SelectOne();
                            if (r["fNoRestrictionUpgrade"].ToString() == package.FNoRestrictionUpgrade.ToString())
                            {
                                isSameSpaCat = true;
                                if (ACMS.Convert.ToInt32(r["nFreeUtil"]) > usedSession)
                                    usedSession = ACMS.Convert.ToInt32(r["nFreeUtil"]);
                                break;
                            }                            
                        }                    
                    }
                    if (myPOS.NCategoryID == 5)
                        strCalculation += "Is same SPA category upgrade? " + (isSameSpaCat ? "Yes" : "No")+"\n";
                    double usedAmount = usedSession * ACMS.Convert.ToDouble(r["mBaseUnitPrice"]);
                                       
                    double subTotal = ACMS.Convert.ToDouble(r["mSubTotal"]);
                    double totalSubTotal = ACMS.Convert.ToDouble(r["totalSubTotal"]);
                    double totalBillDiscount;
                    double packageBillDiscount = 0;
                    //double packageOutstanding = 0;
                    double paidAmount;
                    //if (r["strDiscountCode"] != DBNull.Value && ACMS.Convert.ToDouble(r["mNettAmount"]) + ACMS.Convert.ToDouble(r["mUpgradeAmount"]) < totalSubTotal)
                    //{
                    if (ACMS.Convert.ToDouble(r["mNettAmount"]) + ACMS.Convert.ToDouble(r["mUpgradeAmount"]) < totalSubTotal)
                    {
                        //totalBillDiscount = totalSubTotal - (ACMS.Convert.ToDouble(r["mNettAmount"]) + ACMS.Convert.ToDouble(r["mUpgradeAmount"]));
                        totalBillDiscount = totalSubTotal - (ACMS.Convert.ToDouble(r["mTotalPaid"]));
                        packageBillDiscount = totalBillDiscount * subTotal / totalSubTotal;

                        if (subTotal != totalSubTotal)                        
                            strCalculation += "Proportionate Bill Discount= " + totalBillDiscount.ToString() + " (Total Bill Discount) x (" + subTotal.ToString() + "/" + totalSubTotal.ToString() + ")\n";
                        else
                            strCalculation += "Bill Discount= " + totalBillDiscount.ToString() + " (Total Bill Discount) x (" + subTotal.ToString() + "/" + totalSubTotal.ToString() + ")\n";
                    }

                    //if (ACMS.Convert.ToDouble(r["mOutstandingAmount"]) > 0)
                    //{
                    //    packageOutstanding = ACMS.Convert.ToDouble(r["mOutstandingAmount"]) * subTotal / totalSubTotal / 1.07;
                    //}
                    paidAmount = (subTotal - packageBillDiscount); // ACMS.Convert.ToDouble(r["mUpgradeAmount"]); //- packageOutstanding;
                    strCalculation += "Paid Amt = " + subTotal.ToString() + " (Price after Item Discount) - " + packageBillDiscount.ToString() + " (Proportionate Bill Discount) = " + paidAmount.ToString() +"\n";
                    r["PaidAmt"] = paidAmount;
                    r["UsedSession"] = usedSession;
                    r["UsedAmt"] = usedAmount;
                    r["UsageBalAmt"] = paidAmount - usedAmount;

                    //if ((isSameSpaCat==false && ACMS.Convert.ToInt32(r["nCategoryID"]) == 5 && r["strFreePkgCode"] != DBNull.Value) || (isSameSpaCat==false && (ACMS.Convert.ToInt32(r["nCategoryID"]) == 5 || ACMS.Convert.ToInt32(r["nCategoryID"]) == 6)))
                    if (isSameSpaCat == false && ACMS.Convert.ToInt32(r["nCategoryID"]) == 5 && r["strFreePkgCode"] != DBNull.Value) 
                    {
                        //spa package different category conversion
                        r["UsedAmt"] = ACMS.Convert.ToDouble(r["mFreeUtil"]);
                        r["UsageBalAmt"] = paidAmount - ACMS.Convert.ToDouble(r["mFreeUtil"]);                        
                    }
                    strCalculation += "Used Amt = " + r["UsedAmt"].ToString() + "\n";
                    strCalculation += "Usage Bal Amt = " + paidAmount.ToString() + " (Paid Amt) - " + r["UsedAmt"].ToString() + " (Used Amt) = " + Math.Round(ACMS.Convert.ToDouble(r["UsageBalAmt"]), 2).ToString() + "\n";
                    r["strCalculation"] = strCalculation;
                }
                if (bolSG50Promo == true)
                {
                    string message = "The member has purchased SG50 Promotion Package !";
                    string caption = "Upgrading from existing package to new package";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;
                    // Displays the MessageBox.


                    result = MessageBox.Show(message, caption, buttons);

                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        bolSG50Promo = false;
                    }
                }
            }
        }


        public static DataTable CalculateMemberPackageBalance(string strPackageCode, string strMemberShipID, int nPackageID)
        {
            ACMSDAL.TblMemberPackage memberPackage = new TblMemberPackage();
            DataTable memberPackageTable = memberPackage.GetMemberPackage(nPackageID);
            CalculateMemberPackageBalance(strPackageCode, strMemberShipID, memberPackageTable);
            return memberPackageTable;
        }


		public DataTable GetMemberGiroPackage(string strMemberShipID, int nCategoryID)
		{
			ACMSDAL.TblMemberPackage memberPackage = new TblMemberPackage();
            DataTable memberGIROTable = memberPackage.GetMemberGIROPackage(strMemberShipID, nCategoryID);		
			return memberGIROTable;
		}


        //19032012
        public static void CalculateCreditMemberPackageBalance(DataTable memberPackageTable)
        {

            if (!memberPackageTable.Columns.Contains("Balance"))
            {
                DataColumn colBalance = new DataColumn("Balance", System.Type.GetType("System.Int32"));
                memberPackageTable.Columns.Add(colBalance);
            }

            DataTable gymTable = new DataTable();
            DataColumn colDtdate = new DataColumn("dtDate", typeof(string));
            DataColumn colPackageID = new DataColumn("nPackageID", typeof(int));
            DataColumn colAttendanceID = new DataColumn("nAttendanceID", typeof(int));
            gymTable.Columns.Add(colDtdate);
            gymTable.Columns.Add(colPackageID);
            gymTable.Columns.Add(colAttendanceID);

            TblClassAttendance classAttendance = new TblClassAttendance();
            TblServiceSession serviceSession = new TblServiceSession();

            foreach (DataRow r in memberPackageTable.Rows)
            {
                r["Balance"] = r["nMaxSession"];

                // here to put the free class limit
                if (ACMS.Convert.ToInt32(r["nMaxSession"]) == 9999)
                {
                    r["Balance"] = 9999;
                    continue;
                }

                int nCategoryID = ACMS.Convert.ToInt32(r["nCategoryID"]);
                int nPackageID = ACMS.Convert.ToInt32(r["nPackageID"]);
                // class Attendance

                if (nCategoryID == 1 || nCategoryID == 2)
                {
                    classAttendance.NPackageID = nPackageID;
                    DataTable classAttendanceTable = classAttendance.SelectAllWnPackageIDLogic();

                    if (classAttendanceTable == null || classAttendanceTable.Rows.Count == 0)
                    {
                        if (ACMS.Convert.ToDBInt32(r["nAdjust"]) >= 1 && ACMS.Convert.ToInt32(r["nMaxSession"]) < 9999)
                        {
                            r["Balance"] = ACMS.Convert.ToDBInt32(r["Balance"]) - ACMS.Convert.ToDBInt32(r["nAdjust"]);
                        }
                        continue;
                    }
                    DataView classAttendanceTableView = classAttendanceTable.DefaultView;

                    // Need to filter out the non GYM attendance here
                    classAttendanceTableView.RowFilter = "((nStatusID = 1 or nStatusID = 2) AND nTypeID = 0)";

                    //dw testing
                    TblMemberPackage MemPackage = new TblMemberPackage();

                    if (ACMS.Convert.ToDBInt32(r["nAdjust"]) >= 1 && ACMS.Convert.ToInt32(r["nMaxSession"]) < 9999)
                    {
                        r["Balance"] = ACMS.Convert.ToDBInt32(r["Balance"]) - ACMS.Convert.ToDBInt32(r["nAdjust"]);
                    }

                    int nPackBalance;
                    if (classAttendanceTableView.Count > 0)
                    {
                        r["Balance"] = ACMS.Convert.ToInt32(r["Balance"]) - classAttendanceTableView.Count;
                        nPackBalance = ACMS.Convert.ToInt32(r["Balance"]);
                        if (nPackBalance <= 0)
                            MemPackage.nBalance = 1;
                    }
                    // Start calculate the POWER Package
                    // It is consider PWR Package if the class attendance is GYM Class
                    classAttendanceTableView.RowFilter = "((nStatusID = 1 or nStatusID = 2) AND nTypeID = 1)";

                    if (classAttendanceTableView.Count > 0)
                    {
                        for (int i = 0; i < classAttendanceTableView.Count; i++)
                        {
                            DataRow row = classAttendanceTableView[i].Row;
                            string dtDate = ACMS.Convert.ToDateTime(row["dtDate"]).ToString("yyyy/MM/dd");
                            int nAttendanceID = ACMS.Convert.ToInt32(row["nAttendanceID"]);

                            DataRow[] foundRow = gymTable.Select("dtDate = '" + dtDate + "'");

                            if (foundRow.Length == 0)
                            {
                                DataRow addRow = gymTable.NewRow();
                                addRow["dtDate"] = dtDate;
                                addRow["nPackageID"] = nPackageID;
                                addRow["nAttendanceID"] = nAttendanceID;
                                gymTable.Rows.Add(addRow);
                            }
                        }

                        foreach (DataRow pRow in gymTable.Rows)
                        {
                            DateTime dtDate = ACMS.Convert.ToDateTime(pRow["dtDate"]);
                            int nPackageIDInGymTable = ACMS.Convert.ToInt32(pRow["nPackageID"]);

                            string strFilter = string.Format("(nStatusID = 1 or nStatusID = 2) " +
                                " AND nTypeID = 0 AND nPackageID = {0} AND DtDate = #{1}#", nPackageIDInGymTable.ToString(), dtDate.ToString("yyyy/MM/dd"));

                            DataRow[] foundRow = classAttendanceTable.Select(strFilter, "nPackageID", DataViewRowState.CurrentRows);

                            if (foundRow.Length > 0)
                                r["Balance"] = ACMS.Convert.ToInt32(r["Balance"]) + 1;
                        }

                        r["Balance"] = ACMS.Convert.ToInt32(r["Balance"]) - gymTable.Rows.Count;
                    }
                }
                else if (nCategoryID == 3 || nCategoryID == 4 || nCategoryID == 5 || nCategoryID == 6) // Service Session
                {
                    serviceSession.NPackageID = nPackageID;
                    DataView serviceSessionTable = serviceSession.SelectAllWnPackageIDLogic().DefaultView;
                    serviceSessionTable.RowFilter = "nStatusID = 5 or nStatusID = 6";
                    if (serviceSessionTable.Count > 0)
                    {
                        r["Balance"] = ACMS.Convert.ToInt32(r["Balance"]) - serviceSessionTable.Count;
                    }
                    if (ACMS.Convert.ToDBInt32(r["nAdjust"]) >= 1 && ACMS.Convert.ToInt32(r["nMaxSession"]) < 9999)
                    {
                        r["Balance"] = ACMS.Convert.ToDBInt32(r["Balance"]) - ACMS.Convert.ToDBInt32(r["nAdjust"]);
                    }
                }
            }
        }
        public void CalculateMemberPackageBalance(string strMemberShipID, DataTable memberPackageTable)
        {
            myDataTable = memberPackageTable;
            CalculateBalance(strMemberShipID, "");
            CalculateUsageBalance();            
        }
        //steven 21052013
        public static void CalculateMemberPackageBalance(string strPackageCode, string strMemberShipID, DataTable memberPackageTable)
        {
            ACMSLogic.MemberPackage m = new ACMSLogic.MemberPackage();
            m.myDataTable = memberPackageTable;
            m.CalculateBalance(strMemberShipID, strPackageCode);
        }

        //public static void CalculateMemberPackageBalance(string strPackageCode, string strMemberShipID, DataTable memberPackageTable)
        //{

        //    if (!memberPackageTable.Columns.Contains("Balance"))
        //    {
        //        DataColumn colBalance = new DataColumn("Balance", System.Type.GetType("System.Int32"));
        //        memberPackageTable.Columns.Add(colBalance);
        //    }

        //    DataTable gymTable = new DataTable();
        //    DataColumn colDtdate = new DataColumn("dtDate", typeof(string));
        //    DataColumn colPackageID = new DataColumn("nPackageID", typeof(int));
        //    DataColumn colAttendanceID = new DataColumn("nAttendanceID", typeof(int));
        //    gymTable.Columns.Add(colDtdate);
        //    gymTable.Columns.Add(colPackageID);
        //    gymTable.Columns.Add(colAttendanceID);

        //    TblClassAttendance classAttendance = new TblClassAttendance();
        //    TblServiceSession serviceSession = new TblServiceSession();

        //    foreach (DataRow r in memberPackageTable.Rows)
        //    {
        //        r["Balance"] = r["nMaxSession"];

        //        // here to put the free class limit
        //        if (ACMS.Convert.ToInt32(r["nMaxSession"]) == 9999)
        //        {
        //            r["Balance"] = 9999;
        //            continue;
        //        }

        //        int nCategoryID = ACMS.Convert.ToInt32(r["nCategoryID"]);
        //        int nPackageID = ACMS.Convert.ToInt32(r["nPackageID"]);
        //        // class Attendance

        //        if (nCategoryID == 1 || nCategoryID == 2)
        //        {
        //            classAttendance.NPackageID = nPackageID;
        //            DataTable classAttendanceTable = classAttendance.SelectAllWnPackageIDLogic();

        //            if (classAttendanceTable == null || classAttendanceTable.Rows.Count == 0)
        //            {
        //                if (ACMS.Convert.ToDBInt32(r["nAdjust"]) >= 1 && ACMS.Convert.ToInt32(r["nMaxSession"]) < 9999)
        //                {
        //                    r["Balance"] = ACMS.Convert.ToDBInt32(r["Balance"]) - ACMS.Convert.ToDBInt32(r["nAdjust"]);
        //                }
        //                continue;
        //            }
        //            DataView classAttendanceTableView = classAttendanceTable.DefaultView;

        //            // Need to filter out the non GYM attendance here
        //            classAttendanceTableView.RowFilter = "((nStatusID = 1 or nStatusID = 2) AND nTypeID = 0)";

        //            //dw testing
        //            TblMemberPackage MemPackage = new TblMemberPackage();

        //            if (ACMS.Convert.ToDBInt32(r["nAdjust"]) >= 1 && ACMS.Convert.ToInt32(r["nMaxSession"]) < 9999)
        //            {
        //                r["Balance"] = ACMS.Convert.ToDBInt32(r["Balance"]) - ACMS.Convert.ToDBInt32(r["nAdjust"]);
        //            }

        //            int nPackBalance;
        //            if (classAttendanceTableView.Count > 0)
        //            {
        //                //1403 jackie


        //                ACMSDAL.TblMemberPackage sqlCalcPackages = new ACMSDAL.TblMemberPackage();
        //                int myDTransactionID = sqlCalcPackages.CalculateSpecialSessionPackages(strMemberShipID, nPackageID);
        //                if (strPackageCode == "AA(1080/12)" || strPackageCode == "AA(2160/24)")
        //                {
        //                    r["Balance"] = ACMS.Convert.ToInt32(r["Balance"]) - myDTransactionID;
        //                }
        //                else

        //                    if (strPackageCode == "FTRIAL")
        //                    {
        //                        r["Balance"] = myDTransactionID;
        //                    }

        //                    else
        //                    {

        //                        if (nCategoryID == 2 || ACMS.Convert.ToInt32(r["Balance"]) == 9999) //2604
        //                        {
        //                            string strPackageID = nPackageID.ToString();
        //                            ACMSDAL.TblMemberPackage sqlCalcTotalGIRO = new ACMSDAL.TblMemberPackage();//jackie 15/03/2012
        //                            int intTotalGIRO = sqlCalcTotalGIRO.CalculateTotalGIRO(strMemberShipID, strPackageID, strPackageCode);
        //                            r["Balance"] = (intTotalGIRO * ACMS.Convert.ToInt32(r["Balance"])) - classAttendanceTableView.Count;

        //                        }
        //                        else
        //                        {
        //                            r["Balance"] = ACMS.Convert.ToInt32(r["Balance"]) - classAttendanceTableView.Count;
        //                            //r["Balance"] = 48;
        //                        }
        //                    }
        //                nPackBalance = ACMS.Convert.ToInt32(r["Balance"]);
        //                if (nPackBalance <= 0)
        //                    MemPackage.nBalance = 1;
        //            }
        //            // Start calculate the POWER Package
        //            // It is consider PWR Package if the class attendance is GYM Class
        //            classAttendanceTableView.RowFilter = "((nStatusID = 1 or nStatusID = 2) AND nTypeID = 1)";

        //            if (classAttendanceTableView.Count > 0)
        //            {
        //                for (int i = 0; i < classAttendanceTableView.Count; i++)
        //                {
        //                    DataRow row = classAttendanceTableView[i].Row;
        //                    string dtDate = ACMS.Convert.ToDateTime(row["dtDate"]).ToString("yyyy/MM/dd");
        //                    int nAttendanceID = ACMS.Convert.ToInt32(row["nAttendanceID"]);

        //                    DataRow[] foundRow = gymTable.Select("dtDate = '" + dtDate + "'");

        //                    if (foundRow.Length == 0)
        //                    {
        //                        DataRow addRow = gymTable.NewRow();
        //                        addRow["dtDate"] = dtDate;
        //                        addRow["nPackageID"] = nPackageID;
        //                        addRow["nAttendanceID"] = nAttendanceID;
        //                        gymTable.Rows.Add(addRow);
        //                    }
        //                }

        //                foreach (DataRow pRow in gymTable.Rows)
        //                {
        //                    DateTime dtDate = ACMS.Convert.ToDateTime(pRow["dtDate"]);
        //                    int nPackageIDInGymTable = ACMS.Convert.ToInt32(pRow["nPackageID"]);

        //                    string strFilter = string.Format("(nStatusID = 1 or nStatusID = 2) " +
        //                        " AND nTypeID = 0 AND nPackageID = {0} AND DtDate = #{1}#", nPackageIDInGymTable.ToString(), dtDate.ToString("yyyy/MM/dd"));

        //                    DataRow[] foundRow = classAttendanceTable.Select(strFilter, "nPackageID", DataViewRowState.CurrentRows);

        //                    if (foundRow.Length > 0)
        //                        r["Balance"] = ACMS.Convert.ToInt32(r["Balance"]) + 1;
        //                }

        //                r["Balance"] = ACMS.Convert.ToInt32(r["Balance"]) - gymTable.Rows.Count;
        //            }
        //        }
        //        // Kean Yiap
        //        else if (nCategoryID == 3 || nCategoryID == 4 || nCategoryID == 5 || nCategoryID == 6 || nCategoryID == 34) // Service Session
        //        {
        //            serviceSession.NPackageID = nPackageID;
        //            DataView serviceSessionTable = serviceSession.SelectAllWnPackageIDLogic().DefaultView;
        //            serviceSessionTable.RowFilter = "nStatusID = 5 or nStatusID = 6";
        //            if (nCategoryID == 34)
        //            {
        //                r["Balance"] = ACMS.Convert.ToInt32(r["Balance"]) - serviceSessionTable.Count + ACMS.Convert.ToDBInt32(r["nAdjust"]);
        //            }
        //            else
        //            {
        //                if (serviceSessionTable.Count > 0)
        //                {
        //                    r["Balance"] = ACMS.Convert.ToInt32(r["Balance"]) - serviceSessionTable.Count;
        //                }
        //                if (ACMS.Convert.ToDBInt32(r["nAdjust"]) >= 1 && ACMS.Convert.ToInt32(r["nMaxSession"]) < 9999)
        //                {
        //                    r["Balance"] = ACMS.Convert.ToDBInt32(r["Balance"]) - ACMS.Convert.ToDBInt32(r["nAdjust"]);
        //                }
        //            }
        //        }
        //    }
        //}
        //steven 21052013
        //public static void CalculateMemberPackageBalance(DataTable memberPackageTable, ConnectionProvider connProvider)
        //{
        //    string strMemberShipID = memberPackageTable.Rows[0]["strmembershipID"].ToString();
        //    string strPackageCode = memberPackageTable.Rows[0]["strPackageCode"].ToString();
        //    ACMSLogic.MemberPackage m = new ACMSLogic.MemberPackage();
        //    m.myDataTable = memberPackageTable;
        //    m.CalculateBalance(strMemberShipID, strPackageCode);
        //}
        public static void CalculateMemberPackageBalance(DataTable memberPackageTable, ConnectionProvider connProvider)
        {
            if (!memberPackageTable.Columns.Contains("Balance"))
            {
                DataColumn colBalance = new DataColumn("Balance", System.Type.GetType("System.Int32"));
                memberPackageTable.Columns.Add(colBalance);
            }

            DataTable gymTable = new DataTable();
            DataColumn colDtdate = new DataColumn("dtDate", typeof(string));
            DataColumn colPackageID = new DataColumn("nPackageID", typeof(int));
            DataColumn colAttendanceID = new DataColumn("nAttendanceID", typeof(int));
            gymTable.Columns.Add(colDtdate);
            gymTable.Columns.Add(colPackageID);
            gymTable.Columns.Add(colAttendanceID);

            TblClassAttendance classAttendance = new TblClassAttendance();
            TblServiceSession serviceSession = new TblServiceSession();

            //	classAttendance.MainConnectionProvider = connProvider;
            //	serviceSession.MainConnectionProvider = connProvider;

            foreach (DataRow r in memberPackageTable.Rows)
            {
                r["Balance"] = r["nMaxSession"];

                if (ACMS.Convert.ToInt32(r["nMaxSession"]) == 9999)
                {
                    r["Balance"] = 9999;
                    continue;
                }
                int nCategoryID = ACMS.Convert.ToInt32(r["nCategoryID"]);
                int nPackageID = ACMS.Convert.ToInt32(r["nPackageID"]);
                // class Attendance

                // if (nCategoryID == 1 || nCategoryID == 2)
                if (nCategoryID == 2) //solved verified problem 05042012 
                {

                    classAttendance.NPackageID = nPackageID;
                    DataTable classAttendanceTable = classAttendance.SelectAllWnPackageIDLogic();//03042012

                    if (classAttendanceTable == null || classAttendanceTable.Rows.Count == 0)
                    {
                        if (ACMS.Convert.ToDBInt32(r["nAdjust"]) >= 1 && ACMS.Convert.ToInt32(r["nMaxSession"]) < 9999)
                        {
                            r["Balance"] = ACMS.Convert.ToDBInt32(r["Balance"]) - ACMS.Convert.ToDBInt32(r["nAdjust"]);
                        }
                        continue;
                    }
                    DataView classAttendanceTableView = classAttendanceTable.DefaultView;

                    if (ACMS.Convert.ToDBInt32(r["nAdjust"]) >= 1 && ACMS.Convert.ToInt32(r["nMaxSession"]) < 9999)
                    {
                        r["Balance"] = ACMS.Convert.ToDBInt32(r["Balance"]) - ACMS.Convert.ToDBInt32(r["nAdjust"]);
                    }

                    // Need to filter out the non GYM attendance here
                    classAttendanceTableView.RowFilter = "((nStatusID = 1 or nStatusID = 2) AND nTypeID = 0)";

                    if (classAttendanceTableView.Count > 0)
                    {
                        r["Balance"] = ACMS.Convert.ToInt32(r["Balance"]) - classAttendanceTableView.Count;
                    }

                    // Start calculate the POWER Package
                    // It is consider PWR Package if the class attendance is GYM Class
                    classAttendanceTableView.RowFilter = "((nStatusID = 1 or nStatusID = 2) AND nTypeID = 1)";

                    if (classAttendanceTableView.Count > 0)
                    {
                        for (int i = 0; i < classAttendanceTableView.Count; i++)
                        {
                            DataRow row = classAttendanceTableView[i].Row;
                            string dtDate = ACMS.Convert.ToDateTime(row["dtDate"]).ToString("yyyy/MM/dd");
                            int nAttendanceID = ACMS.Convert.ToInt32(row["nAttendanceID"]);

                            DataRow[] foundRow = gymTable.Select("dtDate = '" + dtDate + "'");

                            if (foundRow.Length == 0)
                            {
                                DataRow addRow = gymTable.NewRow();
                                addRow["dtDate"] = dtDate;
                                addRow["nPackageID"] = nPackageID;
                                addRow["nAttendanceID"] = nAttendanceID;
                                gymTable.Rows.Add(addRow);
                            }
                        }

                        foreach (DataRow pRow in gymTable.Rows)
                        {
                            DateTime dtDate = ACMS.Convert.ToDateTime(pRow["dtDate"]);
                            int nPackageIDInGymTable = ACMS.Convert.ToInt32(pRow["nPackageID"]);

                            string strFilter = string.Format("(nStatusID = 1 or nStatusID = 2) " +
                                " AND nTypeID = 0 AND nPackageID = {0} AND DtDate = #{1}#", nPackageIDInGymTable.ToString(), dtDate.ToString("yyyy/MM/dd"));

                            DataRow[] foundRow = classAttendanceTable.Select(strFilter, "nPackageID", DataViewRowState.CurrentRows);

                            if (foundRow.Length > 0)
                                r["Balance"] = ACMS.Convert.ToInt32(r["Balance"]) + 1;
                        }
                        r["Balance"] = ACMS.Convert.ToInt32(r["Balance"]) - gymTable.Rows.Count;
                    }
                }
                else if (nCategoryID == 3 || nCategoryID == 4 || nCategoryID == 5 || nCategoryID == 6) // Service Session
                {
                    serviceSession.NPackageID = nPackageID;
                    DataView serviceSessionTable = serviceSession.SelectAllWnPackageIDLogic().DefaultView;
                    serviceSessionTable.RowFilter = "nStatusID = 5 or nStatusID = 6";
                    if (serviceSessionTable.Count > 0)
                    {
                        r["Balance"] = ACMS.Convert.ToInt32(r["Balance"]) - serviceSessionTable.Count;
                        //r["FNew"] = 0;
                    }
                    if (ACMS.Convert.ToDBInt32(r["nAdjust"]) >= 1 && ACMS.Convert.ToInt32(r["nMaxSession"]) < 9999)
                    {
                        r["Balance"] = ACMS.Convert.ToDBInt32(r["Balance"]) - ACMS.Convert.ToDBInt32(r["nAdjust"]);
                    }
                }
            }
        }

		public DataTable New(bool isPromotion, string strMembershipID)
		{
			myMemberPackage.NPackageID = -1;
			DataTable table = myMemberPackage.SelectOne();
			DataRow row = table.NewRow();
			row["strMembershipID"] = strMembershipID;
			row["nEmployeeID"] = ACMSLogic.User.EmployeeID;
			row["nStatusID"] = 0; // Active
			row["dtLastEdit"] = System.DateTime.Today.Date;
			row["fFree"] = 1;
			row["nAdjust"]=0;
			
			table.Rows.Add(row);

			return table;
		}

		public static void InitMemberPackageRowInPOS(DataRow memberPackageRow, string strReceiptNo,
			string strMembershipID, string strPackageCode, string strPromotionCode, bool isFree)
		{
			TblPackage package = new TblPackage();
			package.StrPackageCode = strPackageCode;
			package.SelectOne();
			//int packageDuration = package.NPackageDuration.IsNull ? 0 : package.NPackageDuration.Value;

			memberPackageRow["strMembershipID"] = strMembershipID;
			memberPackageRow["strReceiptNo"] = strReceiptNo;
			memberPackageRow["nEmployeeID"] = ACMSLogic.User.EmployeeID;
			memberPackageRow["nStatusID"] = 0; // Active
			memberPackageRow["dtLastEdit"] = System.DateTime.Today;
			memberPackageRow["fFree"] = isFree? 1 : 0;
			memberPackageRow["strPackageCode"] = strPackageCode;
			memberPackageRow["dtPurchaseDate"] = System.DateTime.Today;
			//memberPackageRow["dtExpiryDate"] = System.DateTime.Today.AddMonths(packageDuration - 1);
			memberPackageRow["strRemarks"] = strPromotionCode;
			memberPackageRow["nBalance"]=1;
			memberPackageRow["nAdjust"]=0;

			if (ACMS.Convert.ToInt32(package.NCategoryID) == 6)
			{
				int nWarrantyMonths = ACMS.Convert.ToInt32(package.NWarrantyMonths);
				memberPackageRow["dtWarrantyDate"] = System.DateTime.Today.Date.AddMonths(nWarrantyMonths - 1);
			}
		}

        public static void InitMemberCreditPackageRowInPOS(DataRow memberCreditPackageRow, string strReceiptNo,
            string strMembershipID, string strCreditPackageCode, string strPromotionCode, bool isFree)
        {
            TblCreditPackage package = new TblCreditPackage();
            package.StrCreditPackageCode = strCreditPackageCode;
            package.SelectOne();
            //int packageDuration = package.NPackageDuration.IsNull ? 0 : package.NPackageDuration.Value;

            memberCreditPackageRow["strMembershipID"] = strMembershipID;
            memberCreditPackageRow["strCreditPackageCode"] = strCreditPackageCode;
            memberCreditPackageRow["dtPurchaseDate"] = System.DateTime.Today;
            memberCreditPackageRow["fFree"] = isFree ? 1 : 0;
            memberCreditPackageRow["strReceiptNo"] = strReceiptNo;
            memberCreditPackageRow["nStatusID"] = 0; // Active
            memberCreditPackageRow["nEmployeeID"] = ACMSLogic.User.EmployeeID;
            memberCreditPackageRow["strRemarks"] = strPromotionCode;
            memberCreditPackageRow["dtLastEditDate"] = System.DateTime.Today;
            memberCreditPackageRow["mTopupAmount"] = 0;
        }

		
		public static void InitMemberPackageRowInPOS(DataRow memberPackageRow, string strReceiptNo,
			string strMembershipID, string strPackageCode, string strPromotionCode, bool isFree, int nGiroRefID,
			DateTime dtPackageStart, int ProDays)
		{
			TblPackage package = new TblPackage();
			package.StrPackageCode = strPackageCode;
			package.SelectOne();
			int packageDuration = package.NPackageDuration.IsNull ? 0 : package.NPackageDuration.Value;

			memberPackageRow["strMembershipID"] = strMembershipID;
			memberPackageRow["strReceiptNo"] = strReceiptNo;
			memberPackageRow["nEmployeeID"] = ACMSLogic.User.EmployeeID;
			memberPackageRow["nStatusID"] = 0; // Active
			memberPackageRow["dtLastEdit"] = System.DateTime.Today;
			memberPackageRow["fFree"] = isFree? 1 : 0;
			memberPackageRow["strPackageCode"] = strPackageCode;
			memberPackageRow["dtPurchaseDate"] = System.DateTime.Today;
			memberPackageRow["dtStartDate"] = dtPackageStart;
			
			if(dtPackageStart.Day > 1 && dtPackageStart.Day <=16)
			memberPackageRow["dtExpiryDate"] = new DateTime(dtPackageStart.Year,dtPackageStart.Month,15).AddMonths(packageDuration);
			else if(dtPackageStart.Day > 16 && dtPackageStart.Day <=31)
			memberPackageRow["dtExpiryDate"] = new DateTime(dtPackageStart.Year,dtPackageStart.Month,1).AddMonths(packageDuration+1).AddDays(-1);
			else if (dtPackageStart.Day == 1)
			memberPackageRow["dtExpiryDate"] = new DateTime(dtPackageStart.Year,dtPackageStart.Month,1).AddMonths(packageDuration).AddDays(-1);

			memberPackageRow["strRemarks"] = strPromotionCode;
			memberPackageRow["nBalance"]=1;
			memberPackageRow["nAdjust"]=0;


			if (nGiroRefID >= 0)
				memberPackageRow["nGIRORefID"] = nGiroRefID;

			if (ACMS.Convert.ToInt32(package.NCategoryID) == 6)
			{
				int nWarrantyMonths = ACMS.Convert.ToInt32(package.NWarrantyMonths);
				memberPackageRow["dtWarrantyDate"] = System.DateTime.Today.Date.AddMonths(nWarrantyMonths - 1);
			}
		}

		public bool Delete(int NPackageID)
		{
			myMemberPackage.NCreditPackageID = NPackageID;
			return myMemberPackage.Delete();
		}

		public bool Cancel(int NPackageID)
		{
			myMemberPackage.NPackageID = NPackageID;
			myMemberPackage.SelectOne();
			myMemberPackage.NStatusID = 2;// 2 represent cancel
			myAudit.DtDate = DateTime.Today;
			myAudit.NAuditTypeID = 0;
			myAudit.NEmployeeID = ACMSLogic.User.EmployeeID;
			myAudit.StrAuditEntry = "Cancel Member Package " + NPackageID.ToString();
			myAudit.StrReference = NPackageID.ToString();

			ACMSDAL.ConnectionProvider connProvider = new ConnectionProvider();

			try
			{
				
				myMemberPackage.MainConnectionProvider = connProvider;
				myAudit.MainConnectionProvider = connProvider;
				connProvider.OpenConnection();
				connProvider.BeginTransaction("CancelMemberPackage");
				
				myMemberPackage.Update();
				myAudit.Insert();

				connProvider.CommitTransaction();
				return true;
			}
			catch (Exception)
			{
				connProvider.RollbackTransaction("CancelMemberPackage");
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
					//connProvider.DBConnection.Dispose();
				}
				myMemberPackage.MainConnactionIsCreatedLocal = true;
				myAudit.MainConnactionIsCreatedLocal = true;
			}
		}

		public void Save(DataTable table)
		{
			string strPackageCode = table.Rows[0]["StrPackageCode"].ToString();
			TblPackage package = new TblPackage();
			package.StrPackageCode = strPackageCode;
			package.SelectOne();
			//int packageDuration = package.NPackageDuration.IsNull ? 0 : package.NPackageDuration.Value;
			int nCategoryID = ACMS.Convert.ToInt32(package.NCategoryID);

			//table.Rows[0]["dtExpiryDate"] = System.DateTime.Today.Date.AddMonths(packageDuration - 1);
			
			if (nCategoryID == 6)
			{
				int nWarrantyMonths = ACMS.Convert.ToInt32(package.NWarrantyMonths);

				table.Rows[0]["dtWarrantyDate"] = System.DateTime.Today.Date.AddMonths(nWarrantyMonths - 1);
			}

			myMemberPackage.SaveData(table);
		}

		public void TransferMemberPackage(int packageID, string currMemberID, string newMemberID, string remark)
		{
			TblClassAttendance classAttendance = new TblClassAttendance();
			TblServiceSession serviceSession = new TblServiceSession();

			classAttendance.NPackageID = packageID;
			DataTable tableClassAttendance = classAttendance.SelectAllWnPackageIDLogic();

			serviceSession.NPackageID = packageID;
			DataTable tableServiceSession = serviceSession.SelectAllWnPackageIDLogic();
			
			//classAttendance.nP
			ACMSDAL.ConnectionProvider connProvider = new ConnectionProvider();

			try
			{
				classAttendance.MainConnectionProvider = connProvider;
				serviceSession.MainConnectionProvider = connProvider;
				myMemberPackage.MainConnectionProvider = connProvider;
				myAudit.MainConnectionProvider = connProvider;

				connProvider.OpenConnection();
				connProvider.BeginTransaction("TransferMemberPackage");

				if (tableClassAttendance != null && tableClassAttendance.Rows.Count > 0)
				{	
					foreach (DataRow r in tableClassAttendance.Rows)
					{
						r["strMembershipID"] = newMemberID;
					}
					//classAttendance.StrMembershipID = newMemberID;
					//classAttendance.UpdateAllWnEmployeeIDLogic();
				}
				
				if (tableServiceSession != null && tableServiceSession.Rows.Count > 0)
				{	
//					serviceSession.StrMembershipID = newMemberID;
//					serviceSession.UpdateAllWnPackageIDLogic();
					foreach (DataRow r in tableServiceSession.Rows)
					{
						r["strMembershipID"] = newMemberID;
					}
				}

				myMemberPackage.NPackageID = packageID;
				myMemberPackage.SelectOne();
				myMemberPackage.StrMembershipID = newMemberID;
				myMemberPackage.StrRemarks = remark;
			
				myAudit.DtDate = DateTime.Today;
				myAudit.NAuditTypeID = 1;
				myAudit.NEmployeeID = ACMSLogic.User.EmployeeID;
				myAudit.StrAuditEntry = "Transfer Member Package " + packageID.ToString() + "from " + currMemberID + "to " + newMemberID;
				myAudit.StrReference = packageID.ToString();
				
				classAttendance.SaveData(tableClassAttendance);
				serviceSession.SaveData(tableServiceSession);
				myMemberPackage.Update();
				myAudit.Insert();

				connProvider.CommitTransaction();
			}
			catch (Exception)
			{
				connProvider.RollbackTransaction("CancelMemberPackage");
				throw new Exception("Failed to transfer Member Package");
			}
			finally
			{
				if (connProvider.CurrentTransaction != null)
					connProvider.CurrentTransaction.Dispose();
				if (connProvider.DBConnection != null)
				{
					if (connProvider.DBConnection.State == ConnectionState.Open)
						connProvider.DBConnection.Close();
					//connProvider.DBConnection.Dispose();
				}
				myMemberPackage.MainConnactionIsCreatedLocal = true;
				myAudit.MainConnactionIsCreatedLocal = true;
				classAttendance.MainConnactionIsCreatedLocal = true;
				serviceSession.MainConnactionIsCreatedLocal = true;
			}
		}

		public void PrintPackageExpiry(DataTable sourceTable, string memberName)
		{
			if (!sourceTable.Columns.Contains("MemberName"))
			{
				DataColumn colMemberName = new DataColumn("MemberName", typeof(string));
				sourceTable.Columns.Add(colMemberName);
			}
			sourceTable.Rows[0]["MemberName"] = memberName;

			ACMSLogic.Report.MemberPackageExpiryReport report = new ACMSLogic.Report.MemberPackageExpiryReport();
			report.DataSource = sourceTable;
			report.CreateDataBindings();
			report.Print();
		}

		public DataTable Table
		{
			get { return myDataTable; }
		}

		public DataTable GetPromotionPackageCode()
		{
			return null;
		}

		public DataTable GetExtensionHistoryBasePackageID(int nPackageID)
		{
			TblPackageExtension packageExt = new TblPackageExtension();
			return packageExt.GetActivePackageExtension(nPackageID);
		}

		public DataTable GetExtensionHistoryBaseExtensionID(int nExtensionID)
		{
			TblPackageExtension packageExt = new TblPackageExtension();
			packageExt.NExtensionID = nExtensionID;
			return packageExt.SelectOne();
		}

		public DataTable NewExtensionHistory(int nPackageID)
		{
			TblPackageExtension packageExt = new TblPackageExtension();
			packageExt.NExtensionID = -1;
			DataTable table = packageExt.SelectOne();
			
			DataRow row = table.NewRow();
			row["nPackageID"] = nPackageID;
			row["nEmployeeID"] = ACMSLogic.User.EmployeeID;
			row["nStatusID"] = 0;
			row["strRemarks"]="";
			table.Rows.Add(row);
			return table;
		}
		
		public void DeleteLastExtensionHistory(int nPackageID, int last_nExtensionID)
		{
			myMemberPackage.NPackageID = nPackageID;
			myMemberPackage.SelectOne();

			TblPackageExtension packageExt = new TblPackageExtension();
			packageExt.NPackageID = nPackageID;
			DataTable packageExtTable = packageExt.SelectAllWnPackageIDLogic();
			
			if (packageExtTable == null) 
				throw new Exception("This extension row has been deleted by others");
			if (packageExtTable.Rows.Count == 0)
				throw new Exception("This extension row has been deleted by others");

			if (packageExtTable.Rows.Count > 0)
			{
				DataRow [] rowList = packageExtTable.Select(" nStatusID = 0 AND nExtensionID > " + last_nExtensionID.ToString());
				if (rowList.Length > 0) // mean is not last package extension
				{
					throw new Exception("Only the most recent package extension can be deleted.");
				}
			}


			DataRow[] deletedDataRowList = packageExtTable.Select("nStatusID = 0 and nExtensionID = " + last_nExtensionID, "nExtensionID", DataViewRowState.CurrentRows);
			if (deletedDataRowList.Length == 0)
				throw new Exception("This extension row has been deleted by others");
			//deletedDataRowList should be one row
			deletedDataRowList[0]["nStatusID"] = 1;
			TimeSpan durationToReverse = TimeSpan.FromDays((double) ACMS.Convert.ToInt32(deletedDataRowList[0]["nDaysExtended"]));

			DataRow[] tempDataRowList = packageExtTable.Select("nStatusID = 0", "nExtensionID", DataViewRowState.CurrentRows);
			// now need to use the last row's info to calculate the expriry date.
			// but if there is the only row in extension package for this member package, i have to use other info to calculate the expiry date for this memberpackage

			myMemberPackage.DtExpiryDate = myMemberPackage.DtExpiryDate.Value.Subtract(durationToReverse);
			
			ACMSDAL.ConnectionProvider connProvider = new ConnectionProvider();

			try
			{
				myMemberPackage.MainConnectionProvider = connProvider;
				packageExt.MainConnectionProvider = connProvider;
				connProvider.OpenConnection();
				connProvider.BeginTransaction("SaveExtension");
				myMemberPackage.Update();
				packageExt.SaveData(packageExtTable);
				connProvider.CommitTransaction();
			}
			catch (Exception)
			{
				connProvider.RollbackTransaction("SaveExtension");
				throw new Exception("Failed to Create New Extension");
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
				myMemberPackage.MainConnactionIsCreatedLocal = true;
				packageExt.MainConnactionIsCreatedLocal = true;
			}
		}
			
		public void UpdateExtensionHistory(int last_nExtensionID, DateTime startDate, 
			DateTime endDate, int nReasonID, DateTime newExpiryDate)
		{
            int iReasonID = 0;
			TblPackageExtension packageExt = new TblPackageExtension();
			
			packageExt.NExtensionID = last_nExtensionID;
			DataTable packageExtensionTable = packageExt.SelectOne();
			if (packageExtensionTable.Rows.Count == 0)
				throw new Exception("This extension row has been deleted by others");
			if (packageExt.NStatusID.Value == 1)
				throw new Exception("This extension row has been deleted by others");

			packageExt.DtStartDate = startDate;
			packageExt.DtEndDate = endDate;
			packageExt.NReasonID = nReasonID;

            SaveExtensionHistory(packageExt.NPackageID.Value, packageExtensionTable, newExpiryDate,false, startDate, endDate, iReasonID); 
		}

        public void UpdateGiftToFriends(int nServiceSessionID, int nNewServiceEmployeeID, DateTime dtDate, DateTime dtService)//2604
        {
            TblServiceSession ss = new TblServiceSession();
            ss.NSessionID = nServiceSessionID;
            ss.SelectOne();
            ss.DtDate = dtDate;
            ss.DtTreatment = dtService;
            ss.NServiceEmployeeID = nNewServiceEmployeeID;
            ss.Update();          
        }

		public void UpdateMemberGIRO(int nPackageID)//2604
		{
			myMemberPackage.NPackageID = nPackageID;
			DataTable myGIROtable = myMemberPackage.SelectOne();
			myMemberPackage.DtExpiryDate = myMemberPackage.DtExpiryDate.Value.AddMonths(1);
			myMemberPackage.SaveData(myGIROtable);
		}

		//public void SaveExtensionHistory(int nPackageID, DataTable packageExtensionTable, DateTime oldExpiryDate)
        public void SaveExtensionHistory(int nPackageID, DataTable packageExtensionTable, DateTime oldExpiryDate, bool isGiro, DateTime StartDate, DateTime EndDate, int iReasonID)
		{
			// *TO Do -- if dtStartDate is null, no allow extend 
			DataRow packExtRow = packageExtensionTable.Rows[0];
            int nReasonID=0;
            if (iReasonID != 0)
                nReasonID = iReasonID;
            else
			    nReasonID = ACMS.Convert.ToInt32(packExtRow["nReasonID"]);
			
			if (nReasonID < 0)
				return;
			// Assume that nReasonID = 0 is Others
			
			TblPackageExtension packageExt = new TblPackageExtension();
			ACMSDAL.ConnectionProvider connProvider = new ConnectionProvider();

			if (nReasonID > 0)
			{
				try
				{
					myMemberPackage.MainConnectionProvider = connProvider;
					packageExt.MainConnectionProvider = connProvider;

					connProvider.OpenConnection();
					connProvider.BeginTransaction("SaveExtension");
					
                        DateTime packageExtensionStartDate;
                        DateTime packageExtensionEndDate;

                        if (isGiro == true)
                    {
                        packExtRow["dtStartDate"] = StartDate;
                        packExtRow["dtEndDate"] = EndDate;
                        packageExtensionStartDate = StartDate;
                        packageExtensionEndDate = EndDate;
                    }
                    else
                    {
                            //to support extension for multiple package at once
                        if (StartDate.ToString() != "" && EndDate.ToString() != "")
                        {
                            // C=Leave Start Date
                            packageExtensionStartDate = Convert.ToDateTime(StartDate);
                            // D=Leave End Date
                            packageExtensionEndDate = Convert.ToDateTime(EndDate);
                        }
                        else
                        {
                            // C=Leave Start Date
                            packageExtensionStartDate = ACMS.Convert.ToDateTime(packExtRow["dtStartDate"]);
                            // D=Leave End Date
                            packageExtensionEndDate = ACMS.Convert.ToDateTime(packExtRow["dtEndDate"]);
                        }
                    }

					//B4 Save, must Check whether the startdate have overlap with previous one or not
					packageExt.NPackageID = nPackageID;
					DataTable table = packageExt.SelectAllWnPackageIDLogic();
					if (table != null && table.Rows.Count > 0)
					{
//						DataRow[] tempRow = table.Select("nStatusID = 0 and dtEndDate > '" + packageExtensionStartDate + "'", "nExtensionID");
//						if (tempRow.Length > 0)
//							throw new Exception("Overlapped date in extension package.");
						int RowExtention;
						DateTime e = packageExtensionStartDate;
						DateTime f = packageExtensionEndDate;
						for (RowExtention = 0; RowExtention <= table.Rows.Count-1; RowExtention++)
						{
							if (e < ACMS.Convert.ToDateTime(table.Rows[RowExtention]["dtEndDate"]) && f >= ACMS.Convert.ToDateTime(table.Rows[RowExtention]["dtStartDate"])
								|| (f < e))
							{
							throw new Exception("Overlapped date in extension package.");
							}																																			
						}
						
					}
					//end checking
					
					myMemberPackage.NPackageID = nPackageID;
					DataTable memberPackageTable = myMemberPackage.SelectOne();
					
					if  (myMemberPackage.DtStartDate.IsNull)
						throw new Exception("Member Package not been used yet.");

					if  (memberPackageTable.Rows[0]["DtStartDate"] == DBNull.Value)
						return;
	
					//bool isGiro = !myMemberPackage.NGIRORefID.IsNull;

					// A=Member Package Start Date
					DateTime memberPackageStartDate = myMemberPackage.DtStartDate.Value;
					// B=Member Package End Date
                    DateTime memberPackageExpiryDate = myMemberPackage.DtExpiryDate.Value;
                    DateTime memberPackagePurchaseDate = myMemberPackage.DtPurchaseDate.Value;
					
					//if (packageExtensionStartDate > memberPackageExpiryDate)
					//	throw new Exception("Extension Start Date is not allow to later than Member Package's Expiry Date.");



                    if (isGiro == false)
                    {
                        if (packageExtensionStartDate > memberPackageExpiryDate)
                            throw new Exception("Extension Start Date is not allow to later than Member Package's Expiry Date.");


                        DateTime latestNewExpiryDate = DateTime.MinValue;

                        if ( packageExtensionStartDate > memberPackageStartDate)
                        {

                              DateTime latestExpiryDate = DateTime.ParseExact("2012-04-01", "yyyy'-'MM'-'dd", null);
                              if (memberPackagePurchaseDate > latestExpiryDate && nReasonID != 6)
                            {
                                TimeSpan duration = packageExtensionEndDate.Subtract(packageExtensionStartDate);
                            
                                    if (2 > duration.Days )//01042012 Member only can apply extension with a minimun of 3 days 
                                    {
                                        throw new Exception("Extension only can apply for minimun of 3 days.");
                                    }
                                    else
                                    {
                                        TimeSpan duration1 = packageExtensionEndDate.Subtract(packageExtensionStartDate);
                                        myMemberPackage.DtExpiryDate = myMemberPackage.DtExpiryDate.Value.Add(duration1).AddDays(1);
                                    }

                            }
                            else
                            {
                                           TimeSpan duration = packageExtensionEndDate.Subtract(packageExtensionStartDate);
                                            myMemberPackage.DtExpiryDate = myMemberPackage.DtExpiryDate.Value.Add(duration).AddDays(1);
                            }
                        }
                        else if (packageExtensionStartDate < memberPackageStartDate)
                        {
                            TimeSpan duration = packageExtensionEndDate.Subtract(memberPackageStartDate);
                            myMemberPackage.DtExpiryDate = myMemberPackage.DtExpiryDate.Value.Add(duration).AddDays(1);
                        }

						myMemberPackage.DtLastEdit = System.DateTime.Now;
						myMemberPackage.NEmployeeID = User.EmployeeID;
					}
					else
					{
						//int nGiroRefID = (int)myMemberPackage.NGIRORefID;
						// if the member package is Giro
						// then need to make sure all the extension is follow the base one

                        myMemberPackage.NPackageID = nPackageID;
                        DataTable tempTable = myMemberPackage.SelectAllWnGIROPackageIDLogic();

						if (tempTable == null)
							return;
						if (tempTable.Rows.Count == 0)
							return;
 
						if (tempTable.Rows.Count > 1)
						{
							DataRow[] rowList = tempTable.Select("dtStartDate is not null", "nGiroRefID", DataViewRowState.CurrentRows);
									
							if (rowList.Length > 0)
							{
								DateTime latestNewExpiryDate = DateTime.MinValue;
								DateTime tempnewExpiryDate = DateTime.MinValue;

								memberPackageStartDate = ACMS.Convert.ToDateTime(rowList[0]["dtStartDate"]);
								memberPackageExpiryDate = ACMS.Convert.ToDateTime(rowList[0]["dtExpiryDate"]);

								if (packageExtensionStartDate > memberPackageStartDate)
								{
									TimeSpan duration = packageExtensionEndDate.Subtract(packageExtensionStartDate);
									tempnewExpiryDate = memberPackageExpiryDate.Add(duration).AddDays(1);
								}
								else if (packageExtensionStartDate < memberPackageStartDate)
								{
									TimeSpan duration = packageExtensionEndDate.Subtract(memberPackageStartDate);
									tempnewExpiryDate = memberPackageExpiryDate.Add(duration).AddDays(1);
								}
										
								tempTable.BeginInit();
								foreach (DataRow r in rowList)
								{
									r["dtExpiryDate"] = tempnewExpiryDate;
									r["dtLastEdit"] = DateTime.Now;
									r["nEmployeeID"] = User.EmployeeID;
								}
								tempTable.EndInit();
							}
							else
								return;
						}
						else
						{
							isGiro = false;
							myMemberPackage.NPackageID = nPackageID;
							myMemberPackage.SelectOne();
							myMemberPackage.DtLastEdit = System.DateTime.Now;
							myMemberPackage.NEmployeeID = User.EmployeeID;
							DateTime latestNewExpiryDate = DateTime.MinValue;
					
							if (packageExtensionStartDate > memberPackageStartDate)
							{
								TimeSpan duration = packageExtensionEndDate.Subtract(packageExtensionStartDate);
								myMemberPackage.DtExpiryDate = myMemberPackage.DtExpiryDate.Value.Add(duration).AddDays(1);
							}
							else if (packageExtensionStartDate < memberPackageStartDate)
							{
								TimeSpan duration = packageExtensionEndDate.Subtract(memberPackageStartDate);
								myMemberPackage.DtExpiryDate = myMemberPackage.DtExpiryDate.Value.Add(duration).AddDays(1);
							}
						}	
					}

                    //To support extension for multiple package at once
                    object dtEndValue = packExtRow["dtEndDate"];
                    object dtStartDate = packExtRow["dtEndDate"];
                    if (dtEndValue == DBNull.Value && dtStartDate == DBNull.Value)                    
                    {
                        packExtRow["dtEndDate"] = EndDate;
                        packExtRow["dtStartDate"] = StartDate;
                    }
					TimeSpan nDaysExtend = ACMS.Convert.ToDateTime(packExtRow["dtEndDate"]).Subtract(ACMS.Convert.ToDateTime(packExtRow["dtStartDate"]));
					
					packExtRow["nDaysExtended"] = nDaysExtend.TotalDays+1;
					packExtRow["dtOldExpiry"]=oldExpiryDate;	
					packExtRow["dtNewExpiry"]=	oldExpiryDate.AddDays(nDaysExtend.TotalDays+1);
                    packExtRow["dtCreateDate"] = System.DateTime.Now; //jackie 14032012
                    if (nReasonID != 0)
                        packExtRow["nReasonID"] = nReasonID;

                 
					packExtRow["nDaysExtended"]=(nDaysExtend.TotalDays)+1;
					#region ====== Added By Albert ======
					//To update member package status. If expiry date is greater than today date, change the status to active.
					DateTime dtExpireDate = Convert.ToDateTime(myMemberPackage.DtExpiryDate.ToString());
					if(DateTime.Compare(dtExpireDate,DateTime.Now)>0)
						myMemberPackage.NStatusID = 0;
					#endregion
					myMemberPackage.Update();

					packageExt.SaveData(packageExtensionTable);

					connProvider.CommitTransaction();
				}
				catch (Exception ex)
				{
					connProvider.RollbackTransaction("SaveExtension");
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
					myMemberPackage.MainConnactionIsCreatedLocal = true;
					packageExt.MainConnactionIsCreatedLocal = true;
				}
			}
			else
			{					
				try
				{
					myMemberPackage.MainConnectionProvider = connProvider;
					packageExt.MainConnectionProvider = connProvider;
						
					connProvider.OpenConnection();
					connProvider.BeginTransaction("SaveExtension");
					
					myMemberPackage.NPackageID = nPackageID;
					myMemberPackage.SelectOne();
				
					if (myMemberPackage.DtStartDate.IsNull)
						throw new Exception("Member Package is yet been used. No need to extend");

					myMemberPackage.DtExpiryDate = oldExpiryDate;
					myMemberPackage.DtLastEdit = System.DateTime.Today;
					myMemberPackage.NEmployeeID = User.EmployeeID;
					//packageExt
					packExtRow["dtStartDate"] = myMemberPackage.DtStartDate.Value;
					packExtRow["dtEndDate"] =  myMemberPackage.DtExpiryDate.Value;
					packExtRow["nDaysExtended"] = myMemberPackage.DtExpiryDate.Value.CompareTo(myMemberPackage.DtStartDate.Value);
									
					packageExt.SaveData(packageExtensionTable);
					myMemberPackage.Update();
									
					connProvider.CommitTransaction();
				}
				catch (Exception ex)
				{
					connProvider.RollbackTransaction("SaveExtension");
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
					myMemberPackage.MainConnactionIsCreatedLocal = true;
					packageExt.MainConnactionIsCreatedLocal = true;
				}
			}
		}


		public DataTable GetClassAttendance(int nPackageID, string strMemberShipID, string strBranchCode, int nTypeID)
		{
			TblClassAttendance classAttendance = new TblClassAttendance();
			return classAttendance.GetClassAttendancesBasePackageID(nPackageID, strMemberShipID, strBranchCode, nTypeID);
		}

		public DataTable GetClassAttendance(int nPackageID, string strMemberShipID, string strBranchCode)
		{
			TblClassAttendance classAttendance = new TblClassAttendance();
			return classAttendance.GetClassAttendancesBasePackageID(nPackageID, strMemberShipID, strBranchCode);
		}

		public DataTable GetClassAttendance(int nPackageID, string strMemberShipID, int nTypeID)
		{
			TblClassAttendance classAttendance = new TblClassAttendance();
			return classAttendance.GetClassAttendancesBasePackageID(nPackageID, strMemberShipID, nTypeID);
		}

		public DataTable GetMemberServiceSessionBasePackageID(int nPackageID, string strMemberShipID, string strBranchCode)
		{
			TblServiceSession serviceSession = new TblServiceSession();
			return serviceSession.GetMemberServiceSessionBasePackageID(nPackageID, strMemberShipID, strBranchCode);
		}
		
		public DataTable GetClassInstance(DateTime classDate, string strBranchCode, string strPackageCode)
		{
			TblClassInstance instance = new TblClassInstance();
			return instance.GetValidClassInstance(classDate, strBranchCode, strPackageCode);
		}
		
		public DataTable GetUnLinkedClassAttendance(string memberShipID)
		{
			TblClassAttendance classAttendance = new TblClassAttendance();
			return classAttendance.GetUnLinkedClassAttendance(memberShipID);
		}

        public bool NewServiceSession(int nPackageID, string strServiceCode, string strMemberShipID, int nEmployeeID,
            string strBranchCode, DateTime dtDate, DateTime startTime, DateTime dtTreatment, string strSignID, int nQuatity, Boolean forfeited,
            int MemberPackageCategoryID, string strSigKey, string strPdfExportPath, string SsRemark)
        {
            // i will know whether the service session is for PT or not by using strServiceCode and query out the record from tblService.
            // i also can calculate the endTime using the data(nduration) from tblService

            TblService service = new TblService();
            service.StrServiceCode = strServiceCode;
            DataTable table = service.SelectOne();
            if (table == null || table.Rows.Count == 0)
                throw new Exception("The service is not available.");

            int duration = ACMS.Convert.ToInt32(service.NDuration);

            bool isPT = ACMS.Convert.ToInt32(service.NServiceTypeID) == 0;

            DateTime endTime = startTime.AddMinutes((Double)duration);

            TblEmployee Employee = new TblEmployee();
            Employee.NEmployeeID = nEmployeeID;
            DataTable Emptable = Employee.SelectOne();


            if (Emptable.Rows[0]["fPartTime"].ToString() == "True" || ACMSLogic.SpaBooking.TherapistIsAvailableToBook(nEmployeeID, dtDate, startTime, endTime, strBranchCode))
            {

                TblServiceSession serviceSession = new TblServiceSession();
                serviceSession.NPackageID = nPackageID;
                serviceSession.StrMembershipID = strMemberShipID;
                serviceSession.StrServiceCode = strServiceCode;
                serviceSession.NStatusID = 5;
                serviceSession.DtDate = dtDate;
                serviceSession.DtStartTime = startTime;
                serviceSession.DtEndTime = endTime;
                serviceSession.DtLastEditDate = DateTime.Now;
                serviceSession.NEmployeeID = User.EmployeeID;
                serviceSession.NMarkedByID = User.EmployeeID;
                serviceSession.NServiceEmployeeID = nEmployeeID;
                serviceSession.DtTreatment = dtTreatment;
                serviceSession.StrSignID = strSignID;
                serviceSession.StrSigKey = strSigKey;
                serviceSession.StrSigPdfPath = strPdfExportPath;
                serviceSession.StrUtilData = strSigKey;
                serviceSession.StrRemarks = SsRemark;

                if (forfeited == true)
                {
                    serviceSession.StrRemarks = "FORFEITED";
                }

                if (isPT)
                {
                    serviceSession.StrBranchCode = strBranchCode;
                }
                else
                    serviceSession.StrBranchCode = User.BranchCode;

                TblMemberPackage memberPackage = new TblMemberPackage();
                //1309
                memberPackage.NPackageID = nPackageID;
                DataTable memberPackageTable = memberPackage.GetMemberPackage(nPackageID);
                if (memberPackageTable == null || memberPackageTable.Rows.Count == 0)
                    throw new Exception("Failed to create new service session. Member Package with npackageID = " + nPackageID.ToString() + "has been deleted");

                CalculateMemberPackageBalance(strServiceCode, strMemberShipID, memberPackageTable);
                if (ACMS.Convert.ToInt32(memberPackageTable.Rows[0]["Balance"]) == 0 || ACMS.Convert.ToInt32(memberPackageTable.Rows[0]["Balance"]) - nQuatity < 0)
                    throw new Exception("The balance of this member's package is zero.");

                // 13092012 checking
                // int nCategoryID = ACMS.Convert.ToInt32(r["nCategoryID"]);
                // if (MemberPackageCategoryID == 3)
                // {
                //     ACMSDAL.TblMemberPackage sqlCalcAnyOS = new ACMSDAL.TblMemberPackage();
                //     decimal dOutAmount = sqlCalcAnyOS.CalculateOutstandingAmount(strMemberShipID, MemberPackageCategoryID);

                //     if (dOutAmount > 0)
                //     {
                //         throw new Exception("Please Clear Outstanding, before you can utilised the services!");


                //     }

                //}

                // Kean Yiap
                DataRow masterRow = memberPackageTable.Rows[0];
                if (masterRow["dtStartDate"] == DBNull.Value &&
                    masterRow["dtExpiryDate"] == DBNull.Value)
                {
                    // Means new service session gonna insert
                    TblPackage package = new TblPackage();
                    package.StrPackageCode = masterRow["strPackageCode"].ToString();
                    package.SelectOne();
                    masterRow["dtStartDate"] = dtDate;
                    masterRow["dtExpiryDate"] = dtDate.AddMonths(package.NPackageDuration.Value).AddDays(-1);
                }
                else
                {
                    DateTime memberPackageStartDate = ACMS.Convert.ToDateTime(masterRow["DtStartDate"]);
                    DateTime memberPackageExpiryDate = ACMS.Convert.ToDateTime(masterRow["dtExpiryDate"]);

                    if (memberPackageStartDate > dtDate)
                    {
                        masterRow["dtExpiryDate"] = memberPackageExpiryDate.Subtract(memberPackageStartDate.Subtract(dtDate));
                    }
                }

                ACMSDAL.ConnectionProvider connProvider = new ConnectionProvider();

                try
                {
                    memberPackage.MainConnectionProvider = connProvider;
                    serviceSession.MainConnectionProvider = connProvider;

                    connProvider.OpenConnection();
                    connProvider.BeginTransaction("SaveServiceSession");

                    memberPackage.SaveData(memberPackageTable);

                    for (int i = 0; i < nQuatity; i++)
                        serviceSession.Insert();

                    connProvider.CommitTransaction();

                    return true;
                }
                catch (Exception)
                {
                    connProvider.RollbackTransaction("SaveClassAttendance");
                    throw new Exception("Failed to save Class Attendance");
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
                    memberPackage.MainConnactionIsCreatedLocal = true;
                    serviceSession.MainConnactionIsCreatedLocal = true;
                }
            }
            else
            {
                return false;
            }
        }
		
		public bool NewServiceSession(int nPackageID, string strServiceCode, string strMemberShipID, int nEmployeeID,
            string strBranchCode, DateTime dtDate, DateTime startTime, DateTime dtTreatment, string strSignID, int nQuatity, Boolean forfeited,
            int MemberPackageCategoryID, string strSigKey, string strPdfExportPath, ref DataTable dtSessionID, string SsRemark)
        {
            // i will know whether the service session is for PT or not by using strServiceCode and query out the record from tblService.
            // i also can calculate the endTime using the data(nduration) from tblService

            TblService service = new TblService();
            service.StrServiceCode = strServiceCode;
            DataTable table = service.SelectOne();
            if (table == null || table.Rows.Count == 0)
                throw new Exception("The service is not available.");

            int duration = ACMS.Convert.ToInt32(service.NDuration);

            bool isPT = ACMS.Convert.ToInt32(service.NServiceTypeID) == 0;

            DateTime endTime = startTime.AddMinutes((Double)duration);

            TblEmployee Employee = new TblEmployee();
            Employee.NEmployeeID = nEmployeeID;
            DataTable Emptable = Employee.SelectOne();


            if (Emptable.Rows[0]["fPartTime"].ToString() == "True" || ACMSLogic.SpaBooking.TherapistIsAvailableToBook(nEmployeeID, dtDate, startTime, endTime, strBranchCode))
            {

                TblServiceSession serviceSession = new TblServiceSession();
                serviceSession.NPackageID = nPackageID;
                serviceSession.StrMembershipID = strMemberShipID;
                serviceSession.StrServiceCode = strServiceCode;
                serviceSession.NStatusID = 5;
                serviceSession.DtDate = dtDate;
                serviceSession.DtStartTime = startTime;
                serviceSession.DtEndTime = endTime;
                serviceSession.DtLastEditDate = DateTime.Now;
                serviceSession.NEmployeeID = User.EmployeeID;
                serviceSession.NMarkedByID = User.EmployeeID;
                serviceSession.NServiceEmployeeID = nEmployeeID;
                serviceSession.DtTreatment = dtTreatment;
                serviceSession.StrSignID = strSignID;
                serviceSession.StrSigKey = strSigKey;
                serviceSession.StrSigPdfPath = strPdfExportPath;
                serviceSession.StrUtilData = strSigKey;
                serviceSession.StrRemarks = SsRemark;

                if (forfeited == true)
                {
                    serviceSession.StrRemarks = "FORFEITED";
                }

                if (isPT)
                {
                    serviceSession.StrBranchCode = strBranchCode;
                }
                else
                    serviceSession.StrBranchCode = User.BranchCode;

                TblMemberPackage memberPackage = new TblMemberPackage();
                //1309
                memberPackage.NPackageID = nPackageID;
                DataTable memberPackageTable = memberPackage.GetMemberPackage(nPackageID);
                if (memberPackageTable == null || memberPackageTable.Rows.Count == 0)
                    throw new Exception("Failed to create new service session. Member Package with npackageID = " + nPackageID.ToString() + "has been deleted");

                CalculateMemberPackageBalance(strServiceCode, strMemberShipID, memberPackageTable);
                if (ACMS.Convert.ToInt32(memberPackageTable.Rows[0]["Balance"]) == 0 || ACMS.Convert.ToInt32(memberPackageTable.Rows[0]["Balance"]) - nQuatity < 0)
                    throw new Exception("The balance of this member's package is zero.");             

                // Kean Yiap
                DataRow masterRow = memberPackageTable.Rows[0];
                if (masterRow["dtStartDate"] == DBNull.Value &&
                    masterRow["dtExpiryDate"] == DBNull.Value)
                {
                    // Means new service session gonna insert
                    TblPackage package = new TblPackage();
                    package.StrPackageCode = masterRow["strPackageCode"].ToString();
                    package.SelectOne();
                    masterRow["dtStartDate"] = dtDate;
                    masterRow["dtExpiryDate"] = dtDate.AddMonths(package.NPackageDuration.Value).AddDays(-1);
                }
                else
                {
                    DateTime memberPackageStartDate = ACMS.Convert.ToDateTime(masterRow["DtStartDate"]);
                    DateTime memberPackageExpiryDate = ACMS.Convert.ToDateTime(masterRow["dtExpiryDate"]);

                    if (memberPackageStartDate > dtDate)
                    {
                        masterRow["dtExpiryDate"] = memberPackageExpiryDate.Subtract(memberPackageStartDate.Subtract(dtDate));
                    }
                }

                ACMSDAL.ConnectionProvider connProvider = new ConnectionProvider();

                try
                {
                    memberPackage.MainConnectionProvider = connProvider;
                    serviceSession.MainConnectionProvider = connProvider;

                    connProvider.OpenConnection();
                    connProvider.BeginTransaction("SaveServiceSession");

                    memberPackage.SaveData(memberPackageTable);

                    for (int i = 0; i < nQuatity; i++)
                    {
                        serviceSession.Insert();  //Capture Session ID Here


                        DataRow ssRow;
                        ssRow = dtSessionID.NewRow();
                        ssRow["nSessionID"] = Convert.ToInt32(serviceSession.NSessionID.Value);
                        ssRow["strMembershipID"] = strMemberShipID;
                        dtSessionID.Rows.Add(ssRow);
                    }

                    connProvider.CommitTransaction();
                    //DEREK Wrong Here Need to Fix //Use DataTable //Same goes with Live Version
                    //mySessionID = Convert.ToInt32(serviceSession.NSessionID.Value);

                    return true;
                }
                catch (Exception ex)
                {
                    connProvider.RollbackTransaction("SaveClassAttendance");
                    throw new Exception("Failed to save Class Attendance");
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
                    memberPackage.MainConnactionIsCreatedLocal = true;
                    serviceSession.MainConnactionIsCreatedLocal = true;

                }

            }
            else
            {
                return false;
            }
        }

        public bool NewClassAttendance(int nPackageID, string strMemberShipID, int nClassInstance,
            int nType, string strBranchCode, DateTime classDate,
            DateTime startTime, DateTime endTime, bool isRefunded)
        {

            if (!isRefunded)
            {
                ACMSDAL.TblReceipt sqlReceipt = new ACMSDAL.TblReceipt();
                DataTable receipttable = sqlReceipt.GetToDayForgetCardReceipt(strMemberShipID, 17);

                if (receipttable == null || receipttable.Rows.Count == 0)
                {
                    throw new Exception("You have yet to pay the forget card deposit today.");
                }
            }

            TblClassAttendance classAttendance = new TblClassAttendance();
            bool isPostFromOtherRecord = false;
            bool needtoAddBackOneDayExpiryDate = false;
            bool BalanceStatus = true;
            DataTable memberPackageTable = null;

            if (nType != 1)
            {

                DataRow classAttendanceRow = null;

                bool isAttendedNow = classAttendance.IsAttendedThisClass(nClassInstance, strMemberShipID, ref classAttendanceRow);

                if (isAttendedNow)
                {
                    int nStatusID = ACMS.Convert.ToInt32(classAttendanceRow["nStatusID"]);

                    if (nStatusID == 1)
                    {
                        // Process
                        throw new Exception("Member already been marked in this class.");
                    }
                    else
                    {
                        //Forfeit and need to change to process
                        if (classAttendanceRow != null)
                        {
                            int nClassAttendanceID = ACMS.Convert.ToInt32(classAttendanceRow["nAttendanceID"]);
                            classAttendance.NAttendanceID = nClassAttendanceID;
                            classAttendance.SelectOne();
                            isPostFromOtherRecord = true;
                            nPackageID = classAttendance.NPackageID.Value;
                            isRefunded = classAttendance.FRefunded.IsNull ? true : classAttendance.FRefunded.Value;

                            // this only true if the package is unlimited one
                            memberPackageTable = myMemberPackage.GetMemberPackage(nPackageID);

                            if (ACMS.Convert.ToInt32(memberPackageTable.Rows[0]["nMaxSession"]) == 9999)
                                needtoAddBackOneDayExpiryDate = true;
                        }
                    }
                }
                else if (classAttendanceRow != null && nType == 0)
                {
                    int nClassAttendanceID = ACMS.Convert.ToInt32(classAttendanceRow["nAttendanceID"]);

                    classAttendance.NAttendanceID = nClassAttendanceID;
                    classAttendance.SelectOne();
                    isPostFromOtherRecord = true;
                    nPackageID = classAttendance.NPackageID.Value;
                    isRefunded = classAttendance.FRefunded.IsNull ? true : classAttendance.FRefunded.Value;
                }
            }


            if (memberPackageTable == null)
            {
                myMemberPackage.NPackageID = nPackageID;
                memberPackageTable = myMemberPackage.GetMemberPackage(nPackageID);
            }

            if (memberPackageTable == null || memberPackageTable.Rows.Count == 0)
                throw new Exception("Failed to create new class attendance. Member Package with npackageID = " + nPackageID.ToString() + "has been deleted");

            classAttendance.NPackageID = nPackageID;
            classAttendance.StrMembershipID = strMemberShipID;
            classAttendance.NClassInstanceID = nClassInstance;
            classAttendance.NTypeID = nType;
            classAttendance.StrBranchCode = strBranchCode;
            classAttendance.DtDate = classDate;
            classAttendance.DtStartTime = startTime;
            classAttendance.DtEndTime = endTime;
            classAttendance.DtLastEditDate = DateTime.Now;
            classAttendance.NEmployeeID = ACMSLogic.User.EmployeeID;

            //indicated free class or not
            TblClassInstance classInstance = new TblClassInstance();
            DataTable Instance = classInstance.LoadData("Select fFree from tblClassInstance Where nClassInstanceID = @nClassInstanceID",
                new string[] { "@nClassInstanceID" }, new object[] { nClassInstance });

            if (Instance.Rows[0][0].ToString() == "True")
                classAttendance.NStatusID = 4;
            else
                classAttendance.NStatusID = 1;

            classAttendance.FRefunded = isRefunded;// System.Data.SqlTypes.SqlBoolean.


            //UnLinked is for temporary only
            if (memberPackageTable.Rows[0]["strPackageCode"].ToString() != "Unlinked")
            {
                CalculateMemberPackageBalance(memberPackageTable.Rows[0]["strPackageCode"].ToString(), strMemberShipID, memberPackageTable);

                DataRow masterRow = memberPackageTable.Rows[0];

                //				if (ACMS.Convert.ToDBInt32(memberPackageTable.Rows[0]["Balance"])<999 &&  ACMS.Convert.ToDBInt32(memberPackageTable.Rows[0]["nAdjust"])>=1)
                //				{
                //					memberPackageTable.Rows[0]["Balance"]=ACMS.Convert.ToDBInt32(memberPackageTable.Rows[0]["Balance"])- ACMS.Convert.ToDBInt32(memberPackageTable.Rows[0]["nAdjust"]);
                //				}

                if (ACMS.Convert.ToInt32(memberPackageTable.Rows[0]["Balance"]) <= 0)
                {
                    throw new Exception("Balance is zero");
                    masterRow["nBalance"] = false;
                    BalanceStatus = false;
                }

                if (masterRow["fGiro"].ToString() != "1")
                {
                    if ((masterRow["dtStartDate"] == DBNull.Value &&
                    masterRow["dtExpiryDate"] == DBNull.Value) || (masterRow["dtStartDate"] != DBNull.Value && Convert.ToDateTime(masterRow["dtStartDate"]) > classDate))
                    {
                        // Means new class Attendance gonna insert
                        TblPackage package = new TblPackage();
                        package.StrPackageCode = masterRow["strPackageCode"].ToString();
                        package.SelectOne();

                        //if (package.NPackageDuration.Value == 0 && package.NPackageDay.Value > 0)
                        //{
                        //    masterRow["dtStartDate"] = classDate;
                        //    masterRow["dtExpiryDate"] = classDate.AddDays(package.NPackageDay.Value - 1);
                        //}
                        //else
                        //{
                        //    masterRow["dtStartDate"] = classDate;
                        //    masterRow["dtExpiryDate"] = classDate.AddMonths(package.NPackageDuration.Value).AddDays(-1);
                        //}

                        //jackie Start 05042012 
                        masterRow["dtStartDate"] = classDate;
                        if (package.NPackageDuration.Value == 0)
                        {

                            string txt = package.StrPackageCode.ToString();

                            if (txt == "FTRIAL")
                            {
                                masterRow["dtExpiryDate"] = classDate.AddDays(1).AddDays(0);
                            }
                            else
                            {
                                string strduration;

                                int cstarts = txt.IndexOf("(") + 1;
                                int len = txt.IndexOf(")") - cstarts;
                                txt = txt.Substring(cstarts, len);

                                if (string.IsNullOrEmpty(txt))
                                {
                                    strduration = string.Empty;
                                }
                                else
                                {
                                    int lens = txt.Length;
                                    strduration = txt.Substring(txt.Length - 1, 1);
                                }



                                if (strduration == "D")
                                {

                                    strduration = txt.Replace("D", "");
                                    int iduration = Int32.Parse(strduration);
                                    masterRow["dtExpiryDate"] = classDate.AddDays(iduration - 1).AddDays(0);

                                }
                                if (strduration == "W")
                                {
                                    strduration = txt.Replace("W", "");
                                    int iduration = Int32.Parse(strduration);
                                    iduration = iduration * 7;
                                    masterRow["dtExpiryDate"] = classDate.AddDays(iduration - 1).AddDays(0);

                                }
                            }

                        }
                        else
                        {
                            int iduration = package.NPackageDuration.Value;
                            if (package.StrDurationUnit.ToString().Trim() == "DAY")
                                masterRow["dtExpiryDate"] = classDate.AddDays(iduration - 1).AddDays(0);
                            else if (package.StrDurationUnit.ToString().Trim() == "WEEK")
                            {
                                iduration = iduration * 7;
                                masterRow["dtExpiryDate"] = classDate.AddDays(iduration - 1).AddDays(0);
                            }
                            else if (package.StrDurationUnit.ToString().Trim() == "MONTH")
                                masterRow["dtExpiryDate"] = classDate.AddMonths(package.NPackageDuration.Value).AddDays(-1);
                        }
                        //jackie END 2/02/2012 

                    }
                    else
                    {
                        // Kean Yiap
                        string strPackageCode = masterRow["strPackageCode"].ToString();
                        CalculateMemberPackageBalance(strPackageCode, strMemberShipID, memberPackageTable);
                        DateTime memberPackageStartDate = ACMS.Convert.ToDateTime(masterRow["DtStartDate"]);
                        DateTime memberPackageExpiryDate = ACMS.Convert.ToDateTime(masterRow["dtExpiryDate"]);

                        //if (memberPackageStartDate > classDate)
                        //{
                        //jackie why must change ExpiryDate 26042012
                        //	masterRow["dtExpiryDate"] = memberPackageExpiryDate.Subtract(memberPackageStartDate.Subtract(classDate));	
                        //}
                    }
                }                

                if (ACMS.Convert.ToInt32(memberPackageTable.Rows[0]["Balance"]) <= 1)
                {
                    if (masterRow["strPackageCode"].ToString() == "FTRIAL")
                    {
                        memberPackageTable.Rows[0]["nBalance"] = 1;
                    }
                    else
                    {
                        memberPackageTable.Rows[0]["nBalance"] = 0;
                    }
                }

            }

            ACMSDAL.ConnectionProvider connProvider = new ConnectionProvider();


            try
            {
                myMemberPackage.MainConnectionProvider = connProvider;
                classAttendance.MainConnectionProvider = connProvider;

                connProvider.OpenConnection();
                connProvider.BeginTransaction("SaveClassAttendance");

                if (needtoAddBackOneDayExpiryDate && memberPackageTable.Rows[0]["fGIRO"].ToString() != "1")
                {
                    memberPackageTable.Rows[0]["dtExpiryDate"] = ACMS.Convert.ToDateTime(memberPackageTable.Rows[0]["dtExpiryDate"]).AddDays(1);
                }

                myMemberPackage.SaveData(memberPackageTable);

                if (BalanceStatus)
                {
                    if (!isPostFromOtherRecord)
                        classAttendance.Insert();
                    else
                        classAttendance.Update();

                    connProvider.CommitTransaction();
                }

                return true;
            }
            catch (Exception)
            {
                connProvider.RollbackTransaction("SaveClassAttendance");
                throw new Exception("Failed to save Class Attendance");
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
                myMemberPackage.MainConnactionIsCreatedLocal = true;
                classAttendance.MainConnactionIsCreatedLocal = true;
            }
        }

		public void DeleteClassAttendance(int nPackageID, int nAttendanceID, string remark)
		{
			// i need to know it is only one record, and it is 1st record also
			TblClassAttendance classAttendance = new TblClassAttendance();
			classAttendance.NPackageID = nPackageID;
			DataTable table = classAttendance.SelectAllWnPackageIDLogic();

			bool setNullInMemberPackage = false;
			bool isDelete1stRecord = false;
            bool isGIRO = false;
            bool isGiveBackOneDay = false;
            
			DateTime newfirstRecordClassAttendanceDate = DateTime.MinValue;
            
			if (table != null && table.Rows.Count > 0)
			{
				table.DefaultView.RowFilter = "nStatusID = 1 or nStatusID = 2 or nStatusID = 4";

				if (table.DefaultView.Count == 1)
				{
                    DataSet ds = new DataSet();

                    string strSQL = "select nCategoryID from tblMemberPackage mp join tblPackage p on mp.strPackageCode=p.strPackageCode where nPackageID=" + nPackageID.ToString();                                                                   
                    SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA", ds, new string[] { "Table" }, new SqlParameter("@strSQL", strSQL));

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["nCategoryID"].ToString() == "2")
                        {
                            isGIRO = true;
                            setNullInMemberPackage = false;		
                        }                        
                        else
                            setNullInMemberPackage = true;
                    }
					else
                        setNullInMemberPackage = true;
				}
				else 
				{
					DataRow [] rowList = table.Select("nStatusID = 1 or nStatusID = 2 or nStatusID = 4", 
						"nAttendanceID", DataViewRowState.CurrentRows);
			
					int firstRecord_nAttendanceID = ACMS.Convert.ToInt32(rowList[0]["nAttendanceID"]);
					if (firstRecord_nAttendanceID == nAttendanceID)
					{   
						isDelete1stRecord = true;
						newfirstRecordClassAttendanceDate = ACMS.Convert.ToDateTime(rowList[1]["dtDate"]);			
					}
				}
			}
			
			classAttendance.NAttendanceID = nAttendanceID;
			classAttendance.SelectOne();    
			classAttendance.DtLastEditDate = DateTime.Now;
			classAttendance.NEmployeeID = ACMSLogic.User.EmployeeID;
            if (classAttendance.NStatusID == 2)
                isGiveBackOneDay = true;
			classAttendance.NStatusID = 5;
			classAttendance.StrRemarks = remark;
			
			TblAudit audit = new TblAudit();
			audit.DtDate = DateTime.Now;
			audit.NAuditTypeID = 3;
			audit.NEmployeeID = User.EmployeeID;
			audit.StrAuditEntry = "Delete class attendance with nAttendanceID = " + nAttendanceID + 
				" and nPackageID = " + nPackageID;
			audit.StrReference = nAttendanceID.ToString();
			
			TblMemberPackage memberPackage = new TblMemberPackage();
			memberPackage.NPackageID = nPackageID;
			memberPackage.SelectOne();

			if (setNullInMemberPackage)
			{
				//				bool isUnlimited = memberPackage.IsUnlimitedPackage(nPackageID);
				//				
				//				if (!isUnlimited)
				//				{
				memberPackage.DtExpiryDate = System.Data.SqlTypes.SqlDateTime.Null;
				memberPackage.DtStartDate = System.Data.SqlTypes.SqlDateTime.Null;
				memberPackage.DtLastEdit = DateTime.Now;
				memberPackage.NEmployeeID = User.EmployeeID; 
				//				}
			}
			else if (isDelete1stRecord)
			{
                if (!isGIRO)
                {
                    TimeSpan duration = memberPackage.DtExpiryDate.Value.Subtract(memberPackage.DtStartDate.Value);
                    DateTime newExpriry = newfirstRecordClassAttendanceDate.Add(duration);
                    memberPackage.DtExpiryDate = newExpriry;
                    memberPackage.DtStartDate = newfirstRecordClassAttendanceDate;
                    memberPackage.DtLastEdit = DateTime.Now;
                    memberPackage.NEmployeeID = User.EmployeeID;	
                }				
			}
            else if (isGiveBackOneDay)
            {
                if (!isGIRO)
                {
                    // Check if status = forfeited, give back 1 day to duration pkg
                    DateTime newExpriry = memberPackage.DtExpiryDate.Value.AddDays(1);
                    memberPackage.DtExpiryDate = newExpriry;
                    memberPackage.DtLastEdit = DateTime.Now;
                    memberPackage.NEmployeeID = User.EmployeeID;
                }
            }
			
			ACMSDAL.ConnectionProvider connProvider = new ConnectionProvider();

			try
			{
				memberPackage.MainConnectionProvider = connProvider;
				classAttendance.MainConnectionProvider = connProvider;
				audit.MainConnectionProvider = connProvider;

				connProvider.OpenConnection();
				connProvider.BeginTransaction("DeleteClassAttendance");

				memberPackage.Update();
				audit.Insert();
				classAttendance.Update();
				
				connProvider.CommitTransaction();
				//return true;
			}
			catch (Exception ex)
			{
				connProvider.RollbackTransaction("DeleteClassAttendance");
				throw new Exception("Failed to delete Class Attendance :: " + ex.Message);
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
				memberPackage.MainConnactionIsCreatedLocal = true;
				classAttendance.MainConnactionIsCreatedLocal = true;
				audit.MainConnactionIsCreatedLocal = true;
			}
		}

		public void DeleteServiceSession(int nPackageID, int nSessionID, string remark)
		{
			// i need to know it is only one record, and it is 1st record also
			TblServiceSession serviceSession = new TblServiceSession();
			serviceSession.NPackageID = nPackageID;
			DataTable table = serviceSession.SelectAllWnPackageIDLogic();

			bool setNullInMemberPackage = false;
			bool isDelete1stRecord = false;
			DateTime newfirstRecordServiceSessionDate = DateTime.MinValue;

			if (table != null && table.Rows.Count > 0)
			{
				if (table.Rows.Count == 1)
				{
					setNullInMemberPackage = true;		
				}
				else 
				{
					DataRow [] rowList = table.Select("", "nSessionID", DataViewRowState.CurrentRows);
			
					int firstRecord_nSessionID = ACMS.Convert.ToInt32(rowList[0]["nSessionID"]);
					if (firstRecord_nSessionID == nSessionID)
					{   
						isDelete1stRecord = true;
						newfirstRecordServiceSessionDate = ACMS.Convert.ToDateTime(rowList[1]["dtDate"]);			
					}
				}
			}
			
			serviceSession.NSessionID = nSessionID;
			serviceSession.SelectOne();
			
			serviceSession.DtLastEditDate = DateTime.Now;
			serviceSession.NEmployeeID = ACMSLogic.User.EmployeeID;
			//serviceSession.NPackageID = -1;
			serviceSession.NStatusID = 1;
			serviceSession.StrRemarks = remark;
			
			TblAudit audit = new TblAudit();
			audit.DtDate = DateTime.Now;
			audit.NAuditTypeID = 4;
			audit.NEmployeeID = User.EmployeeID;
			audit.StrAuditEntry = "Delete service session with nSessionID = " + nSessionID+ 
				" and nPackageID = " + nPackageID;
			audit.StrReference = nSessionID.ToString();
			
			TblMemberPackage memberPackage = new TblMemberPackage();
			memberPackage.NPackageID = nPackageID;
			memberPackage.SelectOne();

			if (setNullInMemberPackage)
			{
				bool isUnlimited = memberPackage.IsUnlimitedPackage(nPackageID);
				
				if (!isUnlimited)
				{

					memberPackage.DtStartDate = System.Data.SqlTypes.SqlDateTime.Null;
					memberPackage.DtExpiryDate = System.Data.SqlTypes.SqlDateTime.Null;
					memberPackage.DtLastEdit = DateTime.Now;
					memberPackage.NEmployeeID = User.EmployeeID; 
				}
			}
			else if (isDelete1stRecord)
			{
				TimeSpan duration = memberPackage.DtExpiryDate.Value.Subtract(memberPackage.DtStartDate.Value);
				DateTime newExpriry = newfirstRecordServiceSessionDate.Add(duration);
				memberPackage.DtExpiryDate = newExpriry;
				memberPackage.DtStartDate = newfirstRecordServiceSessionDate;
			}
			
			ACMSDAL.ConnectionProvider connProvider = new ConnectionProvider();

			try
			{
				memberPackage.MainConnectionProvider = connProvider;
				serviceSession.MainConnectionProvider = connProvider;
				audit.MainConnectionProvider = connProvider;

				connProvider.OpenConnection();
				connProvider.BeginTransaction("DeleteServiceSession");

				memberPackage.Update();
				audit.Insert();
				serviceSession.Update();
				
				connProvider.CommitTransaction();
				//return true;
			}
			catch (Exception)
			{
				connProvider.RollbackTransaction("DeleteServiceSession");
				throw new Exception("Failed to delete Service Session");
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
				memberPackage.MainConnactionIsCreatedLocal = true;
				serviceSession.MainConnactionIsCreatedLocal = true;
				audit.MainConnactionIsCreatedLocal = true;
			}
		}

		public void UpdateClassAttendance(int nAttendanceID, int nNewPackageID)
		{
			TblClassAttendance classAttendance = new TblClassAttendance();
			System.Data.SqlTypes.SqlInt32 nOldPackageID;
			
			classAttendance.NAttendanceID = nAttendanceID;
			DataTable table = classAttendance.SelectOne();
			if (table != null && table.Rows.Count > 0)
			{
				nOldPackageID = classAttendance.NPackageID;
				classAttendance.NEmployeeID = User.EmployeeID;
				classAttendance.NPackageID = nNewPackageID;
				
				myMemberPackage.NPackageID = nNewPackageID;
				DataTable memberPackageTable = myMemberPackage.SelectOne();
				if (memberPackageTable == null || memberPackageTable.Rows.Count == 0)
					throw new Exception("Failed to update/transfer class attendance. Member Package with Package ID = "+ nNewPackageID.ToString() + "has been deleted");                

				DataRow masterRow = memberPackageTable.Rows[0];
                TblPackage package = new TblPackage();
                package.StrPackageCode = masterRow["strPackageCode"].ToString();
                package.SelectOne();
                                
				if (masterRow["dtStartDate"] == DBNull.Value)
				{
                    if (!package.FGIRO || package.FGIRO.IsNull)
                    {
                        myMemberPackage.DtStartDate = classAttendance.DtDate;
                        int iduration = package.NPackageDuration.Value;
                        if (package.StrDurationUnit.ToString().Trim() == "DAY")
                            myMemberPackage.DtExpiryDate = classAttendance.DtDate.Value.AddDays(iduration - 1).AddDays(0);
                        else if (package.StrDurationUnit.ToString().Trim() == "WEEK")
                        {
                            iduration = iduration * 7;
                            myMemberPackage.DtExpiryDate = classAttendance.DtDate.Value.AddDays(iduration - 1).AddDays(0);
                        }
                        else
                            myMemberPackage.DtExpiryDate = classAttendance.DtDate.Value.AddMonths(package.NPackageDuration.Value).AddDays(-1);
                    }                    
				}
				else
				{
                    if (!package.FGIRO || package.FGIRO.IsNull)
                    {
                        if (classAttendance.DtDate < ACMS.Convert.ToDateTime(masterRow["DtStartDate"]))
                        {
                            myMemberPackage.DtStartDate = classAttendance.DtDate;
                            int iduration = package.NPackageDuration.Value;
                            if (package.StrDurationUnit.ToString().Trim() == "DAY")
                                myMemberPackage.DtExpiryDate = classAttendance.DtDate.Value.AddDays(iduration - 1).AddDays(0);
                            else if (package.StrDurationUnit.ToString().Trim() == "WEEK")
                            {
                                iduration = iduration * 7;
                                myMemberPackage.DtExpiryDate = classAttendance.DtDate.Value.AddDays(iduration - 1).AddDays(0);
                            }
                            else
                                myMemberPackage.DtExpiryDate = classAttendance.DtDate.Value.AddMonths(package.NPackageDuration.Value).AddDays(-1);
                        }
                        else
                        {
                            DateTime memberPackageStartDate = ACMS.Convert.ToDateTime(masterRow["DtStartDate"]);
                            DateTime memberPackageExpiryDate = ACMS.Convert.ToDateTime(masterRow["dtExpiryDate"]);

                            if (memberPackageStartDate > classAttendance.DtDate)
                            {
                                myMemberPackage.DtExpiryDate = memberPackageExpiryDate.Subtract(memberPackageStartDate.Subtract(classAttendance.DtDate.Value));
                                myMemberPackage.DtStartDate = classAttendance.DtDate;
                            }
                        }
                    }                    					
				}
				
				ACMSDAL.ConnectionProvider connProvider = new ConnectionProvider();

				try
				{
					myMemberPackage.MainConnectionProvider = connProvider;
					classAttendance.MainConnectionProvider = connProvider;

					connProvider.OpenConnection();
					connProvider.BeginTransaction("SaveClassAttendance");
					
					myMemberPackage.Update();
					classAttendance.Update();
					//UpdateStartExpiryDate(nOldPackageID);

					connProvider.CommitTransaction();
					connProvider.BeginTransaction("SaveClassAttendance");
					UpdateStartExpiryDate(nOldPackageID);
					connProvider.CommitTransaction();
				}
				catch (Exception)
				{
					connProvider.RollbackTransaction("SaveClassAttendance");
					throw new Exception("Failed to save Class Attendance");
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
					myMemberPackage.MainConnactionIsCreatedLocal = true;
					classAttendance.MainConnactionIsCreatedLocal = true;
				}
			}
		}
		
		/// <summary>
		/// Use to Transfer Service Session or Update the service Session
		/// </summary>
		/// <param name="nSessionID"></param>
		/// <param name="dtDate"></param>
		/// <param name="startTime"></param>
		/// <param name="endTime"></param>
		/// <param name="strBranchCode"></param>
		/// <param name="nPackageID"></param>
		/// <param name="strServiceCode"></param>
		/// <param name="nEmployeeInChargeID"></param>
		/// <param name="remark"></param>
		/// <param name="isTransfer"></param>
		public void UpdateServiceSession(int nSessionID, DateTime dtDate, DateTime startTime,  DateTime endTime,
			string strBranchCode, int nPackageID, string strServiceCode, 
			int nEmployeeInChargeID, string remark, int status, bool isTransfer)
		{

			TblServiceSession serviceSession = new TblServiceSession();
			serviceSession.NSessionID = nSessionID;
			DataTable table = serviceSession.SelectOne();
			if (table == null || table.Rows.Count == 0)
				throw new Exception("failed to update this package. Record not found");
			
			
			TblService service = new TblService();
			service.StrServiceCode = strServiceCode;
			DataTable serviceTable = service.SelectOne();
			if (serviceTable == null || serviceTable.Rows.Count == 0)
				throw new Exception("The service is not available.");

			int duration = ACMS.Convert.ToInt32(service.NDuration);

			bool isPT = ACMS.Convert.ToInt32(service.NServiceTypeID) == 0;
			
			if (!isTransfer)
			{
				if (!isPT && !ACMSLogic.SpaBooking.VerifyMemberPackageAllowCertainService(nPackageID, strServiceCode))
					throw new Exception("this member package is not allow to use the service");
				
				if (endTime == DateTime.MinValue)
					endTime = startTime.AddMinutes((Double)duration);

				if (dtDate != DateTime.MinValue)
					serviceSession.DtDate = dtDate;
				if (startTime != DateTime.MinValue) 
					serviceSession.DtStartTime = startTime;
				if (endTime != DateTime.MinValue)
					serviceSession.DtEndTime= endTime;
				if (strBranchCode != "")
					serviceSession.StrBranchCode = strBranchCode;
				if (strServiceCode != "")
					serviceSession.StrServiceCode = strServiceCode;
				if (nEmployeeInChargeID != -1)
					serviceSession.NServiceEmployeeID = nEmployeeInChargeID;
				if (nPackageID != -1)
					serviceSession.NPackageID = nPackageID;
				if (remark != "")
					serviceSession.StrRemarks = remark;
				if (status != -1)
					serviceSession.NStatusID  = status;

				if (status == 5)
					serviceSession.NMarkedByID = User.EmployeeID;
			}
			else
			{
				serviceSession.NPackageID = nPackageID;
			}
			
			myMemberPackage.NPackageID = nPackageID;
			DataTable memberPackageTable = myMemberPackage.SelectOne();
			
			if (memberPackageTable == null || memberPackageTable.Rows.Count == 0)
				throw new Exception("Failed to create new service session. Member Package with npackageID = "+ nPackageID.ToString() + "has been deleted");
			
			DataRow masterRow = memberPackageTable.Rows[0];
			
			if (masterRow["dtStartDate"] == DBNull.Value)
			{
				// Means new class Attendance gonna insert
				TblPackage package = new TblPackage();
				package.StrPackageCode = masterRow["strPackageCode"].ToString();
				DataTable tablePackage = package.SelectOne();
					
				if (tablePackage == null && tablePackage.Rows.Count == 0)
					throw new Exception("Failed to update service session. Package no found.");

				myMemberPackage.DtStartDate = serviceSession.DtDate.Value;
				myMemberPackage.DtExpiryDate = serviceSession.DtDate.Value.AddMonths(package.NPackageDuration.Value).AddDays(-1);
			}
			else
			{
				DateTime memberPackageStartDate =  ACMS.Convert.ToDateTime(masterRow["DtStartDate"]);
				DateTime memberPackageExpiryDate = ACMS.Convert.ToDateTime(masterRow["dtExpiryDate"]);

				if (memberPackageStartDate > serviceSession.DtDate.Value)
				{
					myMemberPackage.DtExpiryDate = memberPackageExpiryDate.Subtract(memberPackageStartDate.Subtract(serviceSession.DtDate.Value));	
				}
			}
			
			serviceSession.NEmployeeID = User.EmployeeID;
			serviceSession.DtLastEditDate = DateTime.Now;
			
			ACMSDAL.ConnectionProvider connProvider = new ConnectionProvider();

			try
			{
				myMemberPackage.MainConnectionProvider = connProvider;
				serviceSession.MainConnectionProvider = connProvider;

				connProvider.OpenConnection();
				connProvider.BeginTransaction("SaveServiceSession");

				myMemberPackage.Update();
				serviceSession.Update();

				connProvider.CommitTransaction();
			}
			catch (Exception)
			{
				connProvider.RollbackTransaction("SaveServiceSession");
				throw new Exception("Failed to save Service Session");
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
				myMemberPackage.MainConnactionIsCreatedLocal = true;
				serviceSession.MainConnactionIsCreatedLocal = true;
			}
		}

        public decimal GetCreditPackageUsagePrice(int nCreditPackageID)
        {
            string cmdText = "Select Sum (mCreditPackageUsagePrice) as mSumOfCreditPackageUsagePrice From tblMemberPackage  " +
                " Where nCreditPackageID = @nCreditPackageID and nStatusID <> 2 Group by nCreditPackageID";

            DataTable table = myMemberPackage.LoadData(cmdText, new string[] { "@nCreditPackageID" }, new object[] { nCreditPackageID });

            if (table != null && table.Rows.Count == 1)
            {
                return ACMS.Convert.ToDecimal(table.Rows[0]["mSumOfCreditPackageUsagePrice"]);
            }
            else
                return 0;
        }
        public decimal GetCreditPackageUsagePriceForDifferentCategoryConvert(int nCreditPackageID)
        {
            string cmdText = "Select SUM(mListPrice) as mSumOfCreditPackageUsagePrice From tblMemberPackage mp, tblPackage p " +
                             "Where nCreditPackageID = @nCreditPackageID and nStatusID <> 2 and p.strPackageCode = mp.strPackageCode " +
                             "group by nCreditPackageID ";            

    
  
            DataTable table = myMemberPackage.LoadData(cmdText, new string[] { "@nCreditPackageID" }, new object[] { nCreditPackageID });

            if (table != null && table.Rows.Count == 1)
            {
                return ACMS.Convert.ToDecimal(table.Rows[0]["mSumOfCreditPackageUsagePrice"]);
            }
            else
                return 0;
        }

		#region ====== Added By Albert ======
		private void UpdateStartExpiryDate(System.Data.SqlTypes.SqlInt32 nPackageID)
		{
			TblClassAttendance clsAttendance = new TblClassAttendance();
			clsAttendance.NPackageID = nPackageID;
			//DataTable tableClassAttendance = clsAttendance.SelectAllWnPackageIDLogic();
            DataView tableClassAttendance = clsAttendance.SelectAllWnPackageIDLogic().DefaultView;
            tableClassAttendance.RowFilter = "nStatusID = 1 or nStatusID = 2";
            if (tableClassAttendance.Count == 0)
            {
                myMemberPackage.NPackageID = nPackageID;
                DataTable tableMemberPackage = myMemberPackage.SelectOne();
                if (tableMemberPackage != null && tableMemberPackage.Rows.Count >= 0)
                {
                    myMemberPackage.DtExpiryDate = System.Data.SqlTypes.SqlDateTime.Null;
                    myMemberPackage.DtStartDate = System.Data.SqlTypes.SqlDateTime.Null;
                    myMemberPackage.NStatusID = 0;
                    myMemberPackage.Update();
                }
            }			
		}
		#endregion

        private void UpdateExpiryStatus(string strMembership)
        {
            myDataTable = myMemberPackage.SelectActivenExpiryMemberPackage(strMembership);
            foreach (DataRow r in myDataTable.Rows)
            {
                if (r["dtExpiryDate"].ToString() == "" || ACMS.Convert.ToDateTime(r["dtExpiryDate"]) >= DateTime.Now)
                {
                    myMemberPackage.NPackageID = ACMS.Convert.ToInt32(r["nPackageID"]);
                    myMemberPackage.SelectOne();
                    myMemberPackage.NStatusID = 0;
                    myMemberPackage.Update();
                    //myDataTable = myMemberPackage.SelectActivenExpiryMemberPackage(r["strMembershipID"].ToString());
                }
                else
                {
                    myMemberPackage.NPackageID = ACMS.Convert.ToInt32(r["nPackageID"]);
                    myMemberPackage.SelectOne();
                    myMemberPackage.NStatusID = 1;
                    myMemberPackage.Update();
                    //myDataTable = myMemberPackage.SelectActivenExpiryMemberPackage(r["strMembershipID"].ToString());
                }
            }
        }
    }
}
