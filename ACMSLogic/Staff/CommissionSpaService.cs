using System;
using System.Data;
using System.Data.SqlClient;
using ACMSDAL;
using ACMS;

namespace ACMSLogic.Staff
{
	/// <summary>
	/// Summary description for CommissionSpaService.
	/// </summary>
	public class CommissionSpaService: DBInteractionBase
	{
		private int nEmployeeID;
		private string strBranchCode;
		private Month month;
		private int year;
		private bool IsPTFreelance;
		private bool IsBM;
		private ACMSDAL.Common myDBCommon;
		private DataSet myResultDataSet;
		private DataSet DsMSE;
		private DataTable DtMSEComm;
		private DataTable DtSPACComm;
		private DataTable DtTHEPComm;
		private DataTable DtBMComm;
		private DataTable DtPTComm;
		/// <summary>
		/// Store all current employee info like ID, nServiceCommLevel, Total Commission
		/// </summary>
		public const string EMPLOYEEINFO = "tblEmployeeInfo";
		/// <summary>
		/// Store all Service Session for current employee within particular month and info like strServiceCode, nServiceEmployeeID
		/// </summary>
		public const string SERVICESESSION = "tblServiceSessionInfo";
		/// <summary>
		/// Store all Service info with strServiceCode from SERVICESESSIONTABLE
		/// </summary>
		public const string SERVICE = "tblServiceInfo";

		/// <summary>
		/// Get the Result DataTable contain EmployeeID and Commission only
		/// </summary>
		public DataTable ResultTableInSummary
		{
			get {return myResultDataSet.Tables[EMPLOYEEINFO];}
		}
		/// <summary>
		/// Get the Result DataTable contain all ServiceSession and commission
		/// </summary>
		
		public DataTable MSECommDetail
		{
			get {return DtMSEComm;}
		}

		public DataTable BMCommDetail
		{
			get {return DtBMComm;}
		}

		public DataTable PTCommDetail
		{
			get {return DtPTComm;}
		}
		
		public DataTable THEPCommDetail
		{
			get {return DtTHEPComm;}
		}

		public DataTable SPACCommDetail
		{
			get {return DtSPACComm;}
		}

		public DataTable ResultTableInDetail
		{
			get {return myResultDataSet.Tables[SERVICESESSION];}
		}


		public CommissionSpaService()
		{
			myDBCommon = new ACMSDAL.Common();
		}

		public void CalculateSpaServiceCommission(int aEmployeeID, Month aMonth, int aYear, bool isBM)
		{
			CalculateSpaServiceCommission(aEmployeeID, string.Empty, aMonth, aYear, isBM);
		}

		public void CalculateSpaServiceCommission(int aEmployeeID, string aBranchCode, Month aMonth, int aYear, bool isBM)
		{
			nEmployeeID = aEmployeeID;
			strBranchCode = aBranchCode;
			month = aMonth;
			year = aYear;
			IsPTFreelance = isBM;
			IsBM = isBM;
			DtMSEComm = new DataTable();
			DtSPACComm = new DataTable();
			DtTHEPComm = new DataTable();
			DtBMComm = new DataTable();
			DtPTComm = new DataTable();
			ProcessMSECalculation();
			ProcessSPACCalculation();
			ProcessTHEPCalculation();
			ProcessServiceCommCalculation();
			ProcessBMCalculation();
			ProcessPTCalculation();


		}

		private void ProcessServiceCommCalculation()
		{
			myResultDataSet = new DataSet();
			GetBasicEmployeeInfo();

			// Check have commission code for current employee or not. If don't have return 0 commission.
			if (myResultDataSet.Tables[SERVICESESSION].Rows.Count == 0)
			{
				// Actually is don't need foreach. Should be have 1 row only.
				foreach(DataRow myRow in myResultDataSet.Tables[EMPLOYEEINFO].Rows)
				{
					myRow.BeginEdit();
					myRow["mCommission"] = 0m;
					myRow.EndEdit();
				}
				return;
			}

			decimal commission = 0m;
			// Sum all mServiceCommission using strServiceCode commission.
			foreach (DataRow myRow in myResultDataSet.Tables[SERVICESESSION].Rows)
			{
				decimal currentCommission = 0m;
				currentCommission = CalculateCommission(myRow["strServiceCode"].ToString(), 
					ACMS.Convert.ToInt32(myResultDataSet.Tables[EMPLOYEEINFO].Rows[0]["nServiceCommLevel"]));
				commission += currentCommission;
				myRow["mCommission"] = currentCommission;
			}
			foreach(DataRow myRow in myResultDataSet.Tables[EMPLOYEEINFO].Rows)
			{
				myRow.BeginEdit();
				myRow["mCommission"] = commission;
				myRow.EndEdit();
			}
		}

		private void ProcessMSECalculation()
		{
			try
			{			
			DsMSE = new DataSet();
			DataTable tblMSESales = GetMSEInfo();
			if(tblMSESales.Rows.Count > 0)
			{	
				//string strBranchCode = tblMSESales.Rows[0]["strBranchCode"].ToString();			
				DataTable tblMSEComm = GetMSEComm(strBranchCode);
				DataTable tblBranchTarget = GetBranchComm(strBranchCode);
				DataTable tblBranchSales = GetMSEBranchSale(strBranchCode);		
				
				Ultis.AddColumn(DtMSEComm, "nEmployeeID", "System.Int64");			
				Ultis.AddColumn(DtMSEComm, "TotalCommission", "System.Decimal");		
				foreach(DataRow myRow in tblMSESales.Rows)
				{
					int PersonSales = ACMS.Convert.ToInt32(myRow["mCommission"]);
					int PersonTarget = ACMS.Convert.ToInt32(tblMSEComm.Rows[0]["mTargetFrom"]);
					int ActualBranchSales = ACMS.Convert.ToInt32(tblBranchSales.Rows[0]["mBranchSales"]);
					int NewBranchTarget = ACMS.Convert.ToInt32(tblBranchTarget.Rows[0]["mFitnessPackageTarget"]);
					int BaseBranchTarget = ACMS.Convert.ToInt32(tblBranchTarget.Rows[0]["mBaseFitnessPackage"]); 
					decimal mMSEcomm;
					if (PersonSales >= PersonTarget && ActualBranchSales >= NewBranchTarget)				
						mMSEcomm = System.Convert.ToDecimal(PersonSales * 0.05);
					else if (PersonSales >= PersonTarget && ActualBranchSales >= BaseBranchTarget)
						mMSEcomm = System.Convert.ToDecimal(PersonSales * 0.04);
					else if (PersonSales >= PersonTarget && ActualBranchSales < BaseBranchTarget)
						mMSEcomm = System.Convert.ToDecimal(PersonSales * 0.03);
					else
						mMSEcomm = System.Convert.ToDecimal(PersonSales * 0.01);
                
					DataRow rowMSEComm = DtMSEComm.NewRow();
					rowMSEComm["nEmployeeID"] = nEmployeeID;
					rowMSEComm["TotalCommission"] = mMSEcomm;	
					DtMSEComm.Rows.Add(rowMSEComm);			
				}
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.ToString());
			}	
		}

		private void ProcessSPACCalculation()
		{			
			try
			{
				DsMSE = new DataSet();
				DataTable tblSPACSales = GetSPACInfo();
				if(tblSPACSales.Rows.Count > 0)
				{	
					//string strBranchCode = tblSPACSales.Rows[0]["strBranchCode"].ToString();			
					DataTable tblSPACComm = GetSPACComm(strBranchCode);
					DataTable tblBranchTarget = GetBranchComm(strBranchCode);
					DataTable tblBranchSales = GetSPACBranchSale(strBranchCode);	
					DataTable tblProductSales = GetProductBranchSale(strBranchCode);
					DataTable tblNoBranchSPAC = GetSPACCommCount(strBranchCode);
					DataTable tblReferComm = GetReferral(strBranchCode);
					DataTable tblServiceComm = GetServiceComm();

					Ultis.AddColumn(DtSPACComm, "nEmployeeID", "System.Int64");			
					Ultis.AddColumn(DtSPACComm, "TotalCommission", "System.Double");		
					foreach(DataRow myRow2 in tblSPACSales.Rows)
					{
						double PersonSales = ACMS.Convert.ToDouble(myRow2["mCommission"]);
						double PersonTarget = ACMS.Convert.ToDouble(tblSPACComm.Rows[0]["mPackageTargetFrom"]);
						double ActualBranchSales = ACMS.Convert.ToDouble(tblBranchSales.Rows[0]["mBranchSales"]);
						double NewBranchTarget = ACMS.Convert.ToDouble(tblBranchTarget.Rows[0]["mSpaPackageTarget"]);
						double BaseBranchTarget = ACMS.Convert.ToDouble(tblBranchTarget.Rows[0]["mBaseSpaPackage"]);
						double ProductBranchTarget = ACMS.Convert.ToDouble(tblBranchTarget.Rows[0]["mSpaProductTarget"]);
						double ProductBranchSales = ACMS.Convert.ToDouble(tblProductSales.Rows[0]["mBranchSales"]);
						double NoOfSPAC = 1;
						
						if(tblNoBranchSPAC.Rows.Count>0)
						NoOfSPAC = ACMS.Convert.ToDouble(tblNoBranchSPAC.Rows[0][0]);


						double mSPACcomm = 0;
						double mProductComm = 0;
						double mTotalComm = 0;
						double mReferralComm = 0;
						double mServiceComm = 0;

						if (PersonSales >= PersonTarget && ActualBranchSales >= NewBranchTarget)				
							mSPACcomm = System.Convert.ToDouble(PersonSales * 0.04);
						else if (PersonSales >= PersonTarget && ActualBranchSales >= BaseBranchTarget)
							mSPACcomm = System.Convert.ToDouble(PersonSales * 0.03);
						else if (PersonSales >= PersonTarget && ActualBranchSales < BaseBranchTarget)
							mSPACcomm = System.Convert.ToDouble(PersonSales * 0.02);
						else
							mSPACcomm = System.Convert.ToDouble(PersonSales * 0.01);
                
						if (ProductBranchSales >= ProductBranchTarget)
							mProductComm = System.Convert.ToDouble(ProductBranchSales * 0.04/NoOfSPAC);
						else 
							mProductComm = System.Convert.ToDouble(ProductBranchSales * 0.02/NoOfSPAC);

						if(tblReferComm.Rows.Count > 0)
						mReferralComm = ACMS.Convert.ToDouble(tblReferComm.Rows[0]["mCommission"]);

						if(tblServiceComm.Rows.Count > 0)
						mServiceComm = ACMS.Convert.ToDouble(tblServiceComm.Rows[0]["mServiceComm"]);

						mTotalComm = mSPACcomm + mProductComm + mReferralComm + mServiceComm;

						DataRow rowSPACComm = DtSPACComm.NewRow();
						rowSPACComm["nEmployeeID"] = nEmployeeID;
						rowSPACComm["TotalCommission"] = mTotalComm;	
						DtSPACComm.Rows.Add(rowSPACComm);
					}

				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.ToString());
			}			
			}

		private void ProcessPTCalculation()
		{			
			try
			{
				
				Ultis.AddColumn(DtPTComm, "nEmployeeID", "System.Int64");			
				Ultis.AddColumn(DtPTComm, "TotalCommission", "System.Double");	
				DataTable tblPTSales = GetPTInfo();
				DataTable tblPTWorkOut= PTWorkOutService();
				DataTable tblPTSession= PTServiceSession();


				//for PT
				foreach(DataRow rowPT in tblPTSales.Rows)
				{										
					double mPTsalesComm = System.Convert.ToDouble(rowPT["mCommission"])*0.1;	

					int PTWorkoutSess = 0;
					if(tblPTWorkOut.Rows.Count>0)
					PTWorkoutSess = System.Convert.ToInt32(tblPTWorkOut.Rows[0]["nTotalWorkout"]);
					
					int PTServiceSess = 0;
					int PTServiceAmount = 0;
					if (tblPTSession.Rows.Count>0)
					{
						PTServiceSess = System.Convert.ToInt32(tblPTSession.Rows[0]["nTotalSession"]);
						PTServiceAmount = System.Convert.ToInt32(tblPTSession.Rows[0]["mServiceComm"]);
					}

					double mPTWorkoutComm = PTWorkoutSess * 5;
					double mPTserviceComm = 0;

					if(IsPTFreelance)
					{
						if(PTServiceSess >=80)
							mPTserviceComm = PTServiceAmount * 0.3;
						else
							mPTserviceComm = PTServiceAmount * 0.25;
					}

					double TotalPTComm = mPTsalesComm + mPTWorkoutComm + mPTserviceComm;
					DataRow rowPTComm = DtPTComm.NewRow();
					rowPTComm["nEmployeeID"] = nEmployeeID;
					rowPTComm["TotalCommission"] = TotalPTComm;	
					DtPTComm.Rows.Add(rowPTComm);
				}
			}	
			catch (Exception ex)
			{
				throw new Exception(ex.ToString());
			}	
		}
		private void ProcessBMCalculation()
		{			
			try
			{
				double BMFitnessComm = 0;
				double BMSpaComm = 0;
				double TotalSPAComm = 0;
				double TotalFitnessComm = 0;
				Ultis.AddColumn(DtBMComm, "nEmployeeID", "System.Int64");			
				Ultis.AddColumn(DtBMComm, "TotalCommission", "System.Double");	
				DataTable tblBMList = GetBMInfo();
				DataRow[] DrFitnessBM = tblBMList.Select("nManagerID = " + nEmployeeID);
				DataRow[] DrSPABM = tblBMList.Select("nSpaManagerID = " + nEmployeeID);
		//for fitness manager
				foreach(DataRow rowFitness in DrFitnessBM)
				{	
					BMFitnessComm = 0;
					string strBranchCode = rowFitness["strBranchCode"].ToString();							
					DataTable tblBranchTarget = GetBranchComm(strBranchCode);
					DataTable tblBranchSales = GetMSEBranchSale(strBranchCode);	
					double BaseTarget = System.Convert.ToDouble(tblBranchTarget.Rows[0]["mBaseFitnessPackage"]);				
					double NewTarget = System.Convert.ToDouble(tblBranchTarget.Rows[0]["mFitnessPackageTarget"]);
					double ActualBranchSales = ACMS.Convert.ToDouble(tblBranchSales.Rows[0]["mBranchSales"]);
					double SalesPercent = System.Convert.ToDouble(ActualBranchSales/BaseTarget*100);
					if (ActualBranchSales > NewTarget)
					{
						if (IsBM)
							BMFitnessComm = System.Convert.ToDouble(ActualBranchSales * 0.0125);
						else 
							BMFitnessComm = System.Convert.ToDouble(ActualBranchSales * 0.01);
					}
					else if (SalesPercent >= 100)
					{
						if (IsBM)
							BMFitnessComm = System.Convert.ToDouble(ActualBranchSales * 0.01);
						else 
							BMFitnessComm = System.Convert.ToDouble(ActualBranchSales * 0.007);
					}						
					else if (SalesPercent >= 85 && SalesPercent < 100 )
					{
						if (IsBM)
							BMFitnessComm = System.Convert.ToDouble(ActualBranchSales * 0.007);
						else 
							BMFitnessComm = System.Convert.ToDouble(ActualBranchSales * 0.005);
					}
					else if (SalesPercent >= 75 && SalesPercent < 85 )
					{
						if (IsBM)
							BMFitnessComm = System.Convert.ToDouble(ActualBranchSales * 0.005);
						else 
							BMFitnessComm = System.Convert.ToDouble(ActualBranchSales * 0.003);
					}

					//for manager should not use MSE, use manager personal sales
					DataTable tblBMSales = GetBMPersonal();
					double FitnessBMSales = 0;
					if (tblBMSales.Rows.Count > 0)
					FitnessBMSales = ACMS.Convert.ToDouble(tblBMSales.Rows[0]["mCommission"])* 0.01;
										
					TotalFitnessComm = TotalFitnessComm + BMFitnessComm + FitnessBMSales;
				}

			//for Spa manager
				foreach(DataRow rowSPA in DrSPABM)
				{	
					BMSpaComm = 0;
					string strBranchCode = rowSPA["strBranchCode"].ToString();							
					DataTable tblSPABranchTarget = GetBranchComm(strBranchCode);
					DataTable tblSPABranchSales = GetSPACBranchSale(strBranchCode);	
					DataTable tblProductSales = GetProductBranchSale(strBranchCode);

					double ActualSPABranchSales = 0;
					if(tblSPABranchSales.Rows.Count>0)
					ActualSPABranchSales = ACMS.Convert.ToDouble(tblSPABranchSales.Rows[0]["mBranchSales"]);

					double BaseSpaTarget = System.Convert.ToDouble(tblSPABranchTarget.Rows[0]["mBaseSpaPackage"]);
					double NewSpaTarget = System.Convert.ToDouble(tblSPABranchTarget.Rows[0]["mSpaPackageTarget"]);
					double ProductTarget = System.Convert.ToDouble(tblSPABranchTarget.Rows[0]["mSpaProductTarget"]);
					
					double ProductBranchSales = 0;
					if(tblProductSales.Rows.Count>0)
					ProductBranchSales = System.Convert.ToDouble(tblProductSales.Rows[0]["mBranchSales"]);

					double SPASalesPercent = ActualSPABranchSales/BaseSpaTarget*100;
					
					if (ActualSPABranchSales > NewSpaTarget)
					{
						if (IsBM)
						BMSpaComm = System.Convert.ToDouble(ActualSPABranchSales * 0.0125);
						else
						BMSpaComm = System.Convert.ToDouble(ActualSPABranchSales * 0.01);
					}
					else if (SPASalesPercent >= 100)
					{
						if (IsBM)
							BMSpaComm = System.Convert.ToDouble(ActualSPABranchSales * 0.01);
						else
							BMSpaComm = System.Convert.ToDouble(ActualSPABranchSales * 0.007);
					}
					else if (SPASalesPercent >= 85 && SPASalesPercent < 100 )
					{
						if (IsBM)
							BMSpaComm = System.Convert.ToDouble(ActualSPABranchSales * 0.007);
						else
							BMSpaComm = System.Convert.ToDouble(ActualSPABranchSales * 0.005);
					}
					else if (SPASalesPercent >= 75 && SPASalesPercent < 85 )
					{
						if (IsBM)
							BMSpaComm = System.Convert.ToDouble(ActualSPABranchSales * 0.005);
						else
							BMSpaComm = System.Convert.ToDouble(ActualSPABranchSales * 0.003);
					}

					DataTable tblSPACSales = GetSPACInfo();
					double SpaBMSales = 0;
					if (tblSPACSales.Rows.Count > 0)
						SpaBMSales = ACMS.Convert.ToDouble(tblSPACSales.Rows[0]["mCommission"])* 0.01;
					double BranchProductSales = 0;
					if (ProductBranchSales >= ProductTarget)
					{
						if (IsBM)
							BranchProductSales = ACMS.Convert.ToDouble(ProductBranchSales * 0.03);
						else
							BranchProductSales = ACMS.Convert.ToDouble(ProductBranchSales * 0.02);
					}
					else
					{
						if (IsBM)
							BranchProductSales = ACMS.Convert.ToDouble(ProductBranchSales * 0.01);
						else
							BranchProductSales = ACMS.Convert.ToDouble(ProductBranchSales * 0.007);
					}
						
					TotalSPAComm = TotalSPAComm + BMSpaComm + SpaBMSales + BranchProductSales;
				}
					
						//find 2 branch manager, if 2nd branch then add in commission
						DataRow[] DrBMlist = DtBMComm.Select("nEmployeeID = " + nEmployeeID);
						if (DrBMlist.Length > 0)
						{
							foreach (DataRow drBMcomm in DrBMlist)
								drBMcomm["TotalCommission"] = ACMS.Convert.ToDouble(drBMcomm["TotalCommission"]) + BMFitnessComm + BMSpaComm;
						}
						else //if new branch manager, add new commission
						{
							DataRow rowBMComm = DtBMComm.NewRow();
							rowBMComm["nEmployeeID"] = nEmployeeID;
							rowBMComm["TotalCommission"] = TotalSPAComm + TotalFitnessComm;	
							DtBMComm.Rows.Add(rowBMComm);
						}									
			}
			catch (Exception ex)
			{
				throw new Exception(ex.ToString());
			}			
		}
		
		private void ProcessTHEPCalculation()
		{			
			try
			{
			
				DataTable tblTHEPSales = GetTHEPInfo();
				if(tblTHEPSales.Rows.Count > 0)
				{	
					//string strBranchCode = tblSPACSales.Rows[0]["strBranchCode"].ToString();			
					DataTable tblProductComm = GetProductComm();				
					DataTable tblReferComm = GetReferral(strBranchCode);
					DataTable tblServiceComm = GetServiceComm();

					Ultis.AddColumn(DtTHEPComm, "nEmployeeID", "System.Int64");			
					Ultis.AddColumn(DtTHEPComm, "TotalCommission", "System.Decimal");		
					foreach(DataRow myRow2 in tblTHEPSales.Rows)
					{
						double PersonSales = ACMS.Convert.ToDouble(myRow2["mCommission"]);					
						double mProductComm = 0;
						double mTotalComm = 0;
						double mReferralComm = 0;
						double mServiceComm = 0;
						
						foreach(DataRow myRow3 in tblProductComm.Rows)
						{
							if (PersonSales >=ACMS.Convert.ToInt32(myRow3["mProductTargetFrom"])&& PersonSales <=ACMS.Convert.ToInt32(myRow3["mProductTargetTo"]))
								mProductComm = PersonSales * ACMS.Convert.ToDouble(myRow3["nProductComm"])/100;
						}
											
						if(tblReferComm.Rows.Count > 0)
							mReferralComm = ACMS.Convert.ToDouble(tblReferComm.Rows[0]["mCommission"]) * 0.005;

						if(tblServiceComm.Rows.Count > 0)
							mServiceComm = ACMS.Convert.ToDouble(tblServiceComm.Rows[0]["mServiceComm"]);
						
						if(System.Convert.ToString(myRow2["strJobPositionCode"]).Trim() == "SBOTH" && mServiceComm >= 800)
							mServiceComm = System.Convert.ToDouble(mServiceComm) * 1.05;

						if(System.Convert.ToString(myRow2["strJobPositionCode"]).Trim() == "SSPAT" && mServiceComm >= 600)
							mServiceComm = System.Convert.ToDouble(mServiceComm) * 1.05;


						mTotalComm = mProductComm + mReferralComm + mServiceComm;

						DataRow rowTHEPComm = DtTHEPComm.NewRow();
						rowTHEPComm["nEmployeeID"] = nEmployeeID;
						rowTHEPComm["TotalCommission"] = mTotalComm;	
						DtTHEPComm.Rows.Add(rowTHEPComm);
					}

				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.ToString());
			}			
		}

		private decimal CalculateCommission(string strServiceCode, int nServiceCommLevel)
		{
			if (nServiceCommLevel < 1 || nServiceCommLevel > 5)
				return 0;

			DataTable serviceTable = GetServiceCode(strServiceCode);
			// Just return zero if not row in tblService, but should be not possible since PK/FK contraint
			if (serviceTable.Rows.Count == 0)
			{
				return 0;
			}

			decimal commission = ACMS.Convert.ToDecimal(serviceTable.Rows[0]["mServiceCommission" +nServiceCommLevel.ToString()]);

			return commission;
		}

		private void GetBasicEmployeeInfo()
		{
			DateTime startDate;
			DateTime endDate;
			Ultis.DatesRange(out startDate, out endDate, month, year);

			string text = GenerateEmployeeInfo() + GenerateServiceSession();
			SqlCommand myCmd = new SqlCommand(text);
			myCmd.Parameters.Add("@nnEmployeeID", nEmployeeID);
			myCmd.Parameters.Add("@dtStartDate", startDate);
			myCmd.Parameters.Add("@dtEndDate", endDate);
			if (strBranchCode.Length != 0)
				myCmd.Parameters.Add("@sstrBranchCode", strBranchCode);
			myDBCommon.SelectDataSet(myCmd, myResultDataSet);
			myResultDataSet.Tables[0].TableName = EMPLOYEEINFO;
			myResultDataSet.Tables[1].TableName = SERVICESESSION;

			Ultis.AddColumn(myResultDataSet.Tables[EMPLOYEEINFO], "mCommission", "System.Decimal");		
			Ultis.AddColumn(myResultDataSet.Tables[SERVICESESSION], "mCommission", "System.Decimal");
		}

		private DataTable GetMSEInfo()
		{
			DateTime startDate;
			DateTime endDate;
			Ultis.DatesRange(out startDate, out endDate, month, year);
			string strBranch = "";
			
			if (strBranchCode.Length != 0)
				strBranch = strBranchCode;	

			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_tblReceipt_MSECommission]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("tblMSEComm");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);
			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;
			try
			{
				//cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
				cmdToExecute.Parameters.Add("@nnEmployeeID", nEmployeeID);
				cmdToExecute.Parameters.Add("@dtStartDate", startDate);
				cmdToExecute.Parameters.Add("@dtEndDate", endDate);				
				cmdToExecute.Parameters.Add("@sstrBranchCode", strBranchCode);

				if(_mainConnectionIsCreatedLocal)
				{
					// Open connection.
					_mainConnection.Open();
				}
				else
				{
					if(_mainConnectionProvider.IsTransactionPending)
					{
						cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
					}
				}

				// Execute query.
				adapter.Fill(toReturn);
//				_errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;
//
//				if(_errorCode != (int)LLBLError.AllOk)
//				{
//					// Throw error.
//					throw new Exception("Stored Procedure 'pr_tblMember_SelectAllForLookupEdit' reported the ErrorCode: " + _errorCode);
//				}

				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("pr_tblReceipt_MSECommission", ex);
			}
			finally
			{
				if(_mainConnectionIsCreatedLocal)
				{
					// Close connection.
					_mainConnection.Close();
				}
				cmdToExecute.Dispose();
				adapter.Dispose();
			}
		}

		private DataTable GetBMPersonal()
		{
			DateTime startDate;
			DateTime endDate;
			Ultis.DatesRange(out startDate, out endDate, month, year);
			string strBranch = "";
			
			if (strBranchCode.Length != 0)
				strBranch = strBranchCode;	

			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_tblReceipt_BMCommission]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("tblMSEComm");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);
			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;
			try
			{
				//cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
				cmdToExecute.Parameters.Add("@nnEmployeeID", nEmployeeID);
				cmdToExecute.Parameters.Add("@dtStartDate", startDate);
				cmdToExecute.Parameters.Add("@dtEndDate", endDate);				
				cmdToExecute.Parameters.Add("@sstrBranchCode", strBranchCode);

				if(_mainConnectionIsCreatedLocal)
				{
					// Open connection.
					_mainConnection.Open();
				}
				else
				{
					if(_mainConnectionProvider.IsTransactionPending)
					{
						cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
					}
				}

				// Execute query.
				adapter.Fill(toReturn);
				//				_errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;
				//
				//				if(_errorCode != (int)LLBLError.AllOk)
				//				{
				//					// Throw error.
				//					throw new Exception("Stored Procedure 'pr_tblMember_SelectAllForLookupEdit' reported the ErrorCode: " + _errorCode);
				//				}

				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("pr_tblReceipt_MSECommission", ex);
			}
			finally
			{
				if(_mainConnectionIsCreatedLocal)
				{
					// Close connection.
					_mainConnection.Close();
				}
				cmdToExecute.Dispose();
				adapter.Dispose();
			}
		}
		
		private DataTable GetSPACInfo()
		{
			DateTime startDate;
			DateTime endDate;
			Ultis.DatesRange(out startDate, out endDate, month, year);
			string strBranch = "";
			
			if (strBranchCode.Length != 0)
				strBranch = strBranchCode;	

			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_tblReceipt_SPACCommission]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("tblMSEComm");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);
			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;
			try
			{
				//cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
				cmdToExecute.Parameters.Add("@nnEmployeeID", nEmployeeID);
				cmdToExecute.Parameters.Add("@dtStartDate", startDate);
				cmdToExecute.Parameters.Add("@dtEndDate", endDate);				
				cmdToExecute.Parameters.Add("@sstrBranchCode", strBranchCode);

				if(_mainConnectionIsCreatedLocal)
				{
					// Open connection.
					_mainConnection.Open();
				}
				else
				{
					if(_mainConnectionProvider.IsTransactionPending)
					{
						cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
					}
				}

				// Execute query.
				adapter.Fill(toReturn);				
				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("pr_tblReceipt_MSECommission", ex);
			}
			finally
			{
				if(_mainConnectionIsCreatedLocal)
				{
					// Close connection.
					_mainConnection.Close();
				}
				cmdToExecute.Dispose();
				adapter.Dispose();
			}
		}

		private DataTable PTServiceSession()
		{
			DateTime startDate;
			DateTime endDate;
			Ultis.DatesRange(out startDate, out endDate, month, year);
			string strBranch = "";
			
			if (strBranchCode.Length != 0)
				strBranch = strBranchCode;	

			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_tblServiceSession_PT]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("tblMSEComm");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);
			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;
			try
			{
				//cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
				cmdToExecute.Parameters.Add("@nnEmployeeID", nEmployeeID);
				cmdToExecute.Parameters.Add("@dtStartDate", startDate);
				cmdToExecute.Parameters.Add("@dtEndDate", endDate);				
				cmdToExecute.Parameters.Add("@sstrBranchCode", strBranchCode);

				if(_mainConnectionIsCreatedLocal)
				{
					// Open connection.
					_mainConnection.Open();
				}
				else
				{
					if(_mainConnectionProvider.IsTransactionPending)
					{
						cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
					}
				}

				// Execute query.
				adapter.Fill(toReturn);				
				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("pr_tblServiceSession_PT", ex);
			}
			finally
			{
				if(_mainConnectionIsCreatedLocal)
				{
					// Close connection.
					_mainConnection.Close();
				}
				cmdToExecute.Dispose();
				adapter.Dispose();
			}
		}

		private DataTable GetPTInfo()
		{
			DateTime startDate;
			DateTime endDate;
			Ultis.DatesRange(out startDate, out endDate, month, year);
			string strBranch = "";
			
			if (strBranchCode.Length != 0)
				strBranch = strBranchCode;	

			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_tblReceipt_PTCommission]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("tblMSEComm");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);
			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;
			try
			{
				//cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
				cmdToExecute.Parameters.Add("@nnEmployeeID", nEmployeeID);
				cmdToExecute.Parameters.Add("@dtStartDate", startDate);
				cmdToExecute.Parameters.Add("@dtEndDate", endDate);				
				cmdToExecute.Parameters.Add("@sstrBranchCode", strBranchCode);

				if(_mainConnectionIsCreatedLocal)
				{
					// Open connection.
					_mainConnection.Open();
				}
				else
				{
					if(_mainConnectionProvider.IsTransactionPending)
					{
						cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
					}
				}

				// Execute query.
				adapter.Fill(toReturn);				
				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("pr_tblReceipt_PTCommission", ex);
			}
			finally
			{
				if(_mainConnectionIsCreatedLocal)
				{
					// Close connection.
					_mainConnection.Close();
				}
				cmdToExecute.Dispose();
				adapter.Dispose();
			}
		}

		private DataTable GetBMInfo()
		{
			try
			{
				DateTime startDate;
				DateTime endDate;
				Ultis.DatesRange(out startDate, out endDate, month, year);
				string text = "select * from tblBranch where nBrStatusID = 1";
				SqlCommand myCmd = new SqlCommand(text);			
				DataTable tblBMComm = myDBCommon.SelectDataTable(myCmd);
			
				return tblBMComm;

			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("GetMSEComm", ex);
			}
		}

		private DataTable GetTHEPInfo()
		{
			DateTime startDate;
			DateTime endDate;
			Ultis.DatesRange(out startDate, out endDate, month, year);
			string strBranch = "";
			
			if (strBranchCode.Length != 0)
				strBranch = strBranchCode;	

			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_tblReceipt_THEPCommission]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable();
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);
			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;
			try
			{
				//cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
				cmdToExecute.Parameters.Add("@nnEmployeeID", nEmployeeID);
				cmdToExecute.Parameters.Add("@dtStartDate", startDate);
				cmdToExecute.Parameters.Add("@dtEndDate", endDate);				
			//	cmdToExecute.Parameters.Add("@sstrBranchCode", strBranchCode);

				if(_mainConnectionIsCreatedLocal)
				{
					// Open connection.
					_mainConnection.Open();
				}
				else
				{
					if(_mainConnectionProvider.IsTransactionPending)
					{
						cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
					}
				}

				// Execute query.
				adapter.Fill(toReturn);				
				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("pr_tblReceipt_MSECommission", ex);
			}
			finally
			{
				if(_mainConnectionIsCreatedLocal)
				{
					// Close connection.
					_mainConnection.Close();
				}
				cmdToExecute.Dispose();
				adapter.Dispose();
			}
		}

		private DataTable GetReferral(string strBranchCode)
		{
			DateTime startDate;
			DateTime endDate;
			Ultis.DatesRange(out startDate, out endDate, month, year);
			string strBranch = "";
			
			if (strBranchCode.Length != 0)
				strBranch = strBranchCode;	

			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_tblReceipt_ReferralCommission]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable();
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);
			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;
			try
			{
				//cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
				cmdToExecute.Parameters.Add("@nnEmployeeID", nEmployeeID);
				cmdToExecute.Parameters.Add("@dtStartDate", startDate);
				cmdToExecute.Parameters.Add("@dtEndDate", endDate);				
				cmdToExecute.Parameters.Add("@sstrBranchCode", strBranchCode);

				if(_mainConnectionIsCreatedLocal)
				{
					// Open connection.
					_mainConnection.Open();
				}
				else
				{
					if(_mainConnectionProvider.IsTransactionPending)
					{
						cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
					}
				}

				// Execute query.
				adapter.Fill(toReturn);				
				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("pr_tblReceipt_MSECommission", ex);
			}
			finally
			{
				if(_mainConnectionIsCreatedLocal)
				{
					// Close connection.
					_mainConnection.Close();
				}
				cmdToExecute.Dispose();
				adapter.Dispose();
			}
		}

		private DataTable GetServiceComm()
		{
			DateTime startDate;
			DateTime endDate;
			Ultis.DatesRange(out startDate, out endDate, month, year);
			string strBranch = "";
			
			if (strBranchCode.Length != 0)
				strBranch = strBranchCode;	

			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_tblReceipt_ServiceComm]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable();
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);
			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;
			try
			{
				//cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
				cmdToExecute.Parameters.Add("@nnEmployeeID", nEmployeeID);
				cmdToExecute.Parameters.Add("@dtStartDate", startDate);
				cmdToExecute.Parameters.Add("@dtEndDate", endDate);				
				//cmdToExecute.Parameters.Add("@sstrBranchCode", strBranchCode);

				if(_mainConnectionIsCreatedLocal)
				{
					// Open connection.
					_mainConnection.Open();
				}
				else
				{
					if(_mainConnectionProvider.IsTransactionPending)
					{
						cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
					}
				}

				// Execute query.
				adapter.Fill(toReturn);				
				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("pr_tblReceipt_MSECommission", ex);
			}
			finally
			{
				if(_mainConnectionIsCreatedLocal)
				{
					// Close connection.
					_mainConnection.Close();
				}
				cmdToExecute.Dispose();
				adapter.Dispose();
			}
		}

		private DataTable GetMSEBranchSale(string strBranch)
		{
			DateTime startDate;
			DateTime endDate;
			Ultis.DatesRange(out startDate, out endDate, month, year);
		
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_tblReceipt_MSEBranch]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("tblBranchSales");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);
			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;
			try
			{
				//cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
				cmdToExecute.Parameters.Add("@inEmployeeID", nEmployeeID);
				cmdToExecute.Parameters.Add("@ddtStartDate", startDate);
				cmdToExecute.Parameters.Add("@ddtEndDate", endDate);				
				cmdToExecute.Parameters.Add("@sstrBranchCode", strBranch);

				if(_mainConnectionIsCreatedLocal)
				{
					// Open connection.
					_mainConnection.Open();
				}
				else
				{
					if(_mainConnectionProvider.IsTransactionPending)
					{
						cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
					}
				}

				// Execute query.
				adapter.Fill(toReturn);
				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("pr_tblReceipt_MSECommission", ex);
			}
			finally
			{
				if(_mainConnectionIsCreatedLocal)
				{
					// Close connection.
					_mainConnection.Close();
				}
				cmdToExecute.Dispose();
				adapter.Dispose();
			}
		}

		private DataTable GetSPACBranchSale(string strBranch)
		{
			DateTime startDate;
			DateTime endDate;
			Ultis.DatesRange(out startDate, out endDate, month, year);
		
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_tblReceipt_SPACBranch]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("tblBranchSales");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);
			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;
			try
			{
				//cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
				cmdToExecute.Parameters.Add("@inEmployeeID", nEmployeeID);
				cmdToExecute.Parameters.Add("@ddtStartDate", startDate);
				cmdToExecute.Parameters.Add("@ddtEndDate", endDate);				
				cmdToExecute.Parameters.Add("@sstrBranchCode", strBranch);

				if(_mainConnectionIsCreatedLocal)
				{
					// Open connection.
					_mainConnection.Open();
				}
				else
				{
					if(_mainConnectionProvider.IsTransactionPending)
					{
						cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
					}
				}

				// Execute query.
				adapter.Fill(toReturn);				
				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("pr_tblReceipt_SPACBranch", ex);
			}
			finally
			{
				if(_mainConnectionIsCreatedLocal)
				{
					// Close connection.
					_mainConnection.Close();
				}
				cmdToExecute.Dispose();
				adapter.Dispose();
			}
		}

		private DataTable GetProductBranchSale(string strBranch)
		{
			DateTime startDate;
			DateTime endDate;
			Ultis.DatesRange(out startDate, out endDate, month, year);
		
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_tblReceipt_ProductBranch]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("tblBranchSales");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);
			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;
			try
			{
				//cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
				cmdToExecute.Parameters.Add("@inEmployeeID", nEmployeeID);
				cmdToExecute.Parameters.Add("@ddtStartDate", startDate);
				cmdToExecute.Parameters.Add("@ddtEndDate", endDate);				
				cmdToExecute.Parameters.Add("@sstrBranchCode", strBranch);

				if(_mainConnectionIsCreatedLocal)
				{
					// Open connection.
					_mainConnection.Open();
				}
				else
				{
					if(_mainConnectionProvider.IsTransactionPending)
					{
						cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
					}
				}

				// Execute query.
				adapter.Fill(toReturn);				
				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("pr_tblReceipt_ProductBranch", ex);
			}
			finally
			{
				if(_mainConnectionIsCreatedLocal)
				{
					// Close connection.
					_mainConnection.Close();
				}
				cmdToExecute.Dispose();
				adapter.Dispose();
			}
		}


		private DataTable GetServiceCode(string strServiceCode)
		{
			try
			{
				string text = GenerateService();
				SqlCommand myCmd = new SqlCommand(text);
				myCmd.Parameters.Add("@sstrServiceCode", strServiceCode);
				DataTable myTable = myDBCommon.SelectDataTable(myCmd);
				myTable.TableName = SERVICE;
				return myTable;

			}

			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("GetServiceCode", ex);
			}
		}

		private DataTable GetMSEComm(string strBranch)
		{
			
			try
			{
				DateTime startDate;
				DateTime endDate;
				Ultis.DatesRange(out startDate, out endDate, month, year);
				string text = "select * from tblCommMSE where nYear = '" + year + "' and strBranch = '"+ strBranch +"'";
				SqlCommand myCmd = new SqlCommand(text);			
				DataTable tblMSEComm = myDBCommon.SelectDataTable(myCmd);
			
				return tblMSEComm;

			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("GetMSEComm", ex);
			}
			
		}

		private DataTable PTWorkOutService()
		{
			
			try
			{
				DateTime startDate;
				DateTime endDate;
				Ultis.DatesRange(out startDate, out endDate, month, year);
				string text = "select count(*) as nTotalWorkout from tblServiceSession where year(dtStartTime) = '" + year + "' and month(dtStartTime) = '" + startDate.Month +"' and strServiceCode like 'WORKOUT%' and nStatusID = 5 and nServiceEmployeeID =";
				text = text + nEmployeeID;
				SqlCommand myCmd = new SqlCommand(text);			
				DataTable tblPTWorkOut = myDBCommon.SelectDataTable(myCmd);
			
				return tblPTWorkOut;

			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("PTWorkOutService", ex);
			}
			
		}
		private DataTable GetSPACComm(string strBranch)
		{
			try
			{
				DateTime startDate;
				DateTime endDate;
				Ultis.DatesRange(out startDate, out endDate, month, year);
				//string text = "select * from tblCommSpaConsult where nYear = '" + year + "' and nMonth = '" + startDate.Month +"' and strBranch = '"+ strBranch +"'";
				string text = "select * from tblCommSpaConsult where nYear = '" + year + "' and strBranch = '"+ strBranch +"'";
				SqlCommand myCmd = new SqlCommand(text);			
				DataTable tblMSEComm = myDBCommon.SelectDataTable(myCmd);
			
				return tblMSEComm;
			}

			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("GetSPACComm", ex);
			}
		}

		private DataTable GetProductComm()
		{
			try
			{
				DateTime startDate;
				DateTime endDate;
				Ultis.DatesRange(out startDate, out endDate, month, year);
				string text = "select * from tblCommProduct";
				SqlCommand myCmd = new SqlCommand(text);			
				DataTable tblCommProduct = myDBCommon.SelectDataTable(myCmd);
			
				return tblCommProduct;
			}

			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("GetSPACComm", ex);
			}
		}


		private DataTable GetSPACCommCount(string strBranchCodd)
		{
			try
			{
				
				string text = "select count(*) from tblemployee where fSpaConsult = 1 and nStatusID = 1 and strBranchCode = '"+ strBranchCodd +"'";
				SqlCommand myCmd = new SqlCommand(text);			
				DataTable tblSPACCount = myDBCommon.SelectDataTable(myCmd);
			
				return tblSPACCount;
			}

			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("GetSPACComm", ex);
			}
		}

		private DataTable GetBranchComm(string strBranch)
		{
			try
			{
				DateTime startDate;
				DateTime endDate;
				Ultis.DatesRange(out startDate, out endDate, month, year);

				string text = "select * from tblBranchTarget where nYearID = '" + year + "' and nMonthID = '" + startDate.Month +"' and strBranchCode = '"+ strBranch +"'";
				SqlCommand myCmd = new SqlCommand(text);			
				DataTable tblBranchComm = myDBCommon.SelectDataTable(myCmd);
			
				return tblBranchComm;

			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("GetBranchComm", ex);
			}

		}
		private string GenerateEmployeeInfo()
		{
			string text = "SELECT nEmployeeID, strEmployeeName, strJobPositionCode, strBranchCode, nServiceCommLevel "
				+"FROM tblEmployee WHERE nEmployeeID = @nnEmployeeID;";
			return text;
		}

		private string GenerateServiceSession()
		{
			string text = "SELECT * FROM tblServiceSession WHERE nStatusID = 5 and nServiceEmployeeID = @nnEmployeeID "
				+"AND dtDate >= @dtStartDate AND dtDate < @dtEndDate ";
			
			if (strBranchCode.Length != 0)
				text += "AND strBranchCode = @sstrBranchCode;";
			else
				text += ";";
			return text;
		}

		private string GenerateService()
		{
			string text = "SELECT * FROM tblService WHERE strServiceCode = @sstrServiceCode ";
			if (!IsPTFreelance)			
				text += "AND nServiceTypeID > 0;";
			else
				text += ";";
			return text;
		}
	}
}
