using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text;
using System.Text.RegularExpressions;
using ACMS;
using ACMS.Utils;
using ACMSDAL;

namespace ACMSLogic
{
	/// <summary>
	/// Summary description for MemberRecord.
	/// </summary>
	public class MemberRecord
	{
		#region Member
		private string _NewMemberID;
		private string myCurrentBranch;
		private DataTable dtblPreset;
		private DataTable dtblBranchLookupEdit;
		private TblMember myMember;
		private TblBranch myBranch;
		private TblCardRequest myCardRequest;
		private TblAudit myCardRequestAudit;
		private TblAudit myAuditTrail;

		public string NewMemberID 
		{
			get
			{
				return _NewMemberID;
			}
			set
			{				
				_NewMemberID = value;
			}
		}
		public DataTable SelectPresetTable
		{
			get {return dtblPreset;}
			set {dtblPreset = value;}
		}
		public DataTable BranchLookupEditTable
		{
			get {return dtblBranchLookupEdit;}
			set {dtblBranchLookupEdit = value;}
		}

		public MemberRecord(string strMembershipID, string strBranchCode)
		{
			
		myMember = new TblMember();
		dtblPreset = myMember.SelectFixedOne(strMembershipID,strBranchCode);
		}

		public MemberRecord(string aBranchCode)
		{
			myCurrentBranch = aBranchCode;
			myMember = new TblMember();
			InitLookupEdit();

			dtblPreset = myMember.SelectLast15(myCurrentBranch);
		}

		private void InitLookupEdit()
		{
			myBranch = new TblBranch();
			dtblBranchLookupEdit = myBranch.SelectAllForLookupEdit();
		}

		public void RefreshLookupEdit()
		{
			dtblBranchLookupEdit = myBranch.SelectAllForLookupEdit();
		}
		//DEREK DNC UPDATE 2014-03-03
		public void RefreshPreset(int preset, string strMembershipID, string aBranchCode)
		{
			if (preset == 0)
				dtblPreset = myMember.SelectLast15(aBranchCode);
			else if (preset == 1)
				dtblPreset = myMember.SelectBirthOfMonth(aBranchCode);
			else if (preset == 2)
				dtblPreset = myMember.SelectExpireInAWeek(aBranchCode);
			else
			{
				dtblPreset = myMember.SelectFixedOne(strMembershipID, aBranchCode);
			}
		}

		public bool Delete(string strMembershipID, User aUser, string strRemark)
		{
			ACMSDAL.ConnectionProvider connProvider = new ConnectionProvider();
			TblMember sqlMember = new TblMember();
			TblAudit sqlAudit = new TblAudit();

			bool isSuccess = false;
			try
			{
				sqlMember.MainConnectionProvider = connProvider;
				sqlAudit.MainConnectionProvider = connProvider;
				connProvider.OpenConnection();
				connProvider.BeginTransaction("DeleteMember");

				sqlMember.DeleteMember(strMembershipID, strRemark);
				sqlAudit.NAuditTypeID = ACMSLogic.AuditTypeID.MemberRecord;
				sqlAudit.NEmployeeID = aUser.NEmployeeID();
				sqlAudit.StrAuditEntry = "Delete member " +strMembershipID;
				sqlAudit.StrReference = strMembershipID;
				sqlAudit.DtDate = DateTime.Now;
				sqlAudit.Insert();

				connProvider.CommitTransaction();
				isSuccess = true;
			}
			catch (Exception)
			{
				connProvider.RollbackTransaction("DeleteMember");
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
					connProvider.DBConnection.Dispose();
				}
				sqlMember.Dispose();
				sqlAudit.Dispose();
			}
			return isSuccess;
		}

		public void Cancel(string strMembershipID)
		{
			myMember.StrMembershipID = strMembershipID;
			myMember.Update();
		}

		/// <summary>
		/// Include member or non member
		/// </summary>
		/// <param name="isMember"></param>
		/// <param name="branchCode"></param>
		/// <param name="name"></param>
		/// <param name="isSingaporean"></param>
		/// <param name="NRIC"></param>
		/// <param name="nSignUpID"></param>
		/// <param name="dob"></param>
		/// <param name="aUser"></param>
        ///
        /// 0705
		public string AddNewMember(bool isMember, string branchCode, string name, bool isSingaporean, string NRIC, int nSignUpID,
            DateTime dob, User aUser, bool isFemale, int nmediaSource)
		{
			string membershipID = string.Empty;
			TblMember sqlMember = new TblMember();
			sqlMember.FMember = isMember;
			sqlMember.StrMemberName = name;
            sqlMember.FFemale = isFemale;
			if (name.Length >= 19)
				sqlMember.StrCardName = name.Substring(0, 19);
			else
				sqlMember.StrCardName = name;
			sqlMember.StrNRICFIN = NRIC;
			sqlMember.DtDOB = dob;
			sqlMember.StrBranchCode = branchCode;
			sqlMember.FSingaporean = isSingaporean;
            sqlMember.NMediaSourceID = nmediaSource;
			TblCardRequest sqlCardRequest = new TblCardRequest();
			TblAudit sqlAudit = new TblAudit();

			if (!isMember)
			{
				ACMSDAL.ConnectionProvider connProvider = new ConnectionProvider();
				TblCompany sqlCompany = new TblCompany();

				try
				{
					sqlCompany.MainConnectionProvider = connProvider;
					sqlMember.MainConnectionProvider = connProvider;
					sqlCardRequest.MainConnectionProvider = connProvider;
					sqlAudit.MainConnectionProvider = connProvider;
					connProvider.OpenConnection();
					connProvider.BeginTransaction("AddNewNonMember");
					
					sqlCompany.IncOne();
					sqlMember.NMembershipNo = sqlCompany.NNonMembershipNo;
					sqlMember.NStatus = 1;
					sqlMember.NSignupID = nSignUpID;
					sqlMember.StrMembershipID = "NMC" +sqlCompany.NNonMembershipNo;
					sqlMember.DtSignupDate = DateTime.Now;
					//sqlMember.NCardStatusID = (int)CardStatusType.RequestPrint;
					sqlMember.NLoyaltyStatusID = 1;
					sqlMember.Insert();

					membershipID = "NMC" +sqlCompany.NNonMembershipNo;

					connProvider.CommitTransaction();
				}
				catch (Exception)
				{
					connProvider.RollbackTransaction("AddNewNonMember");
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
						connProvider.DBConnection.Dispose();
					}
					sqlCompany.MainConnactionIsCreatedLocal = true;
					sqlMember.MainConnactionIsCreatedLocal = true;
					sqlCardRequest.MainConnactionIsCreatedLocal = true;
				}
			}
			else
			{
				ACMSDAL.ConnectionProvider connProvider = new ConnectionProvider();
				TblBranch sqlBranch = new TblBranch();

				try
				{
					sqlBranch.MainConnectionProvider = connProvider;
					sqlMember.MainConnectionProvider = connProvider;
					sqlCardRequest.MainConnectionProvider = connProvider;
					sqlAudit.MainConnectionProvider = connProvider;
					connProvider.OpenConnection();
					connProvider.BeginTransaction("AddNewNonMember");

					sqlBranch.StrBranchCode = branchCode;
                    //sqlBranch.StrBranchCode = "PM";
					sqlBranch.IncOne();
					sqlMember.NMembershipNo = sqlBranch.NMembershipNo;
					sqlMember.NStatus = 1;
					sqlMember.NSignupID = nSignUpID;
					sqlMember.StrMembershipID = branchCode.TrimEnd() +sqlBranch.NMembershipNo;
                   // sqlMember.StrMembershipID = "PM" + sqlBranch.NMembershipNo;
					sqlMember.DtSignupDate = DateTime.Now;
					sqlMember.NCardStatusID = (int)CardStatusType.RequestPrint;
					sqlMember.StrCardBranchCode = "HQ";
					sqlMember.NLoyaltyStatusID = 1;
					sqlMember.Insert();

					//Request print for member --now only for fitness member
//					sqlCardRequest.NEmployeeID = aUser.NEmployeeID();
//					sqlCardRequest.NStatusID = (int)CardStatusType.RequestPrint;
//					sqlCardRequest.StrBranchCode = aUser.StrBranchCode();
//					sqlCardRequest.StrMembershipID = branchCode.TrimEnd() +sqlBranch.NMembershipNo;
//					sqlCardRequest.DtLastEditDate = DateTime.Now;
//					sqlCardRequest.Insert();

					//Audit trail for request print
//					sqlAudit.NAuditTypeID = ACMSLogic.AuditTypeID.MemberCard;
//					sqlAudit.NEmployeeID = aUser.NEmployeeID();
//					sqlAudit.StrAuditEntry = "New member card request when create new member.";
//					sqlAudit.StrReference = branchCode.TrimEnd() +sqlBranch.NMembershipNo;
//					sqlAudit.DtDate = DateTime.Now;
//					sqlAudit.Insert();

					membershipID = branchCode.TrimEnd() +sqlBranch.NMembershipNo;

					connProvider.CommitTransaction();
				}
				catch (Exception)
				{
					connProvider.RollbackTransaction("AddNewNonMember");
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
						connProvider.DBConnection.Dispose();
					}
					sqlBranch.Dispose();
					sqlMember.Dispose();
					sqlCardRequest.Dispose();
				}
			}

			return membershipID;
		}

		public int CheckDuplicateNRIC(string strNRICFIN, string strMembershipID)
		{
			return myMember.CheckNRIC(strNRICFIN, strMembershipID);
		}

		public DataTable SearchMember(string searchKey, object strBranchCode, SearchMemberType aMemberType, int page)
		{
			object fMember;
			if (aMemberType == SearchMemberType.AllMember)
				fMember = DBNull.Value;
			else if (aMemberType == SearchMemberType.MemberOnly)
				fMember = true;
			else 
				fMember = false;
			return myMember.Search(searchKey, strBranchCode, fMember, page, 100);
		}

		public string ConvertMember(DataRow rowMember, User aUser)
		{
			ACMSDAL.ConnectionProvider connProvider = new ConnectionProvider();
			TblMember sqlMember = new TblMember();
			TblBranch sqlBranch = new TblBranch();
			TblAudit sqlAudit = new TblAudit();
			TblCardRequest sqlCardRequest = new TblCardRequest();

			try
			{
				sqlBranch.MainConnectionProvider = connProvider;
				sqlMember.MainConnectionProvider = connProvider;
				sqlAudit.MainConnectionProvider = connProvider;
				sqlCardRequest.MainConnectionProvider = connProvider;
				connProvider.OpenConnection();
				connProvider.BeginTransaction("ConvertMember");
				
				sqlBranch.StrBranchCode = aUser.StrBranchCode();
				sqlBranch.IncOne();
				string newMembershipID = aUser.StrBranchCode().TrimEnd() +sqlBranch.NMembershipNo;
				sqlMember.StrBranchCode = aUser.StrBranchCode();
				sqlMember.ConvertMember(rowMember["strMembershipID"].ToString(), newMembershipID);
				sqlMember.ConvertMemberPurchase(rowMember["strMembershipID"].ToString(), newMembershipID);
				sqlAudit.UpdateAllWstrReferenceLogic(newMembershipID, rowMember["strMembershipID"].ToString());
				sqlAudit.NAuditTypeID = ACMSLogic.AuditTypeID.MemberRecord;
				sqlAudit.NEmployeeID = aUser.NEmployeeID();
				sqlAudit.StrAuditEntry = "Convert member from " +rowMember["strMembershipID"].ToString() +" to " +newMembershipID;
				sqlAudit.StrReference = newMembershipID;
				sqlAudit.DtDate = DateTime.Now;
				sqlAudit.Insert();

				//Request print for convert non member to member
                //sqlCardRequest.NEmployeeID = aUser.NEmployeeID();
                //sqlCardRequest.NStatusID = (int)CardStatusType.RequestPrint;
                //sqlCardRequest.StrBranchCode = aUser.StrBranchCode();
                //sqlCardRequest.StrMembershipID = newMembershipID;
                //sqlCardRequest.DtLastEditDate = DateTime.Now;
                //sqlCardRequest.Insert();

                ////Audit trail for request print
                //sqlAudit.NAuditTypeID = ACMSLogic.AuditTypeID.MemberCard;
                //sqlAudit.NEmployeeID = aUser.NEmployeeID();
                //sqlAudit.StrAuditEntry = "New member card request when create convert member.";
                //sqlAudit.StrReference = newMembershipID;
                //sqlAudit.DtDate = DateTime.Now;
                //sqlAudit.Insert();

				connProvider.CommitTransaction();
				return newMembershipID;
			}
			catch (Exception)
			{
				connProvider.RollbackTransaction("ConvertMember");
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
					connProvider.DBConnection.Dispose();
				}
				sqlBranch.Dispose();
				sqlMember.Dispose();
				sqlAudit.Dispose();
				sqlCardRequest.Dispose();
			}
		}

		public bool UpdateMember(string strMembershipID, 
                                    object dateDob, 
                                    bool fAirCrew, 
                                    bool fBoundCheck, 
                                    bool fEmail, 
			                        bool fGiroFailed, 
                                    bool fPostalMail, 
                                    bool fSingaporean, 
                                    bool fSMS, 
                                    int nLoyaltyStatusID, 
                                    string strAdd1, 
                                    string strAdd2, 
			                        string strAltEmail, 
                                    string strCardName, 
                                    string strCompany, 
                                    string strCreditCardNo, 
                                    string strEmail, 
			                        string strEmergencyContactNo, 
                                    string strEmergencyContactPerson, 
                                    string strHomeNo, 
                                    string strMemberName, 
			                        string strMobileNo, 
                                    string strNIRCFIN, 
                                    string strOccupation, 
                                    string strOfficeNo, 
                                    string strPagerNo, 
			                        string strPostalCode, 
                                    string strRemark, 
                                    int nMediaSourceID, 
                                    string strMediaSource, 
                                    string strBeforePhoto,
			                        string strAfterPhoto, 
                                    byte[] imgPhoto, 
                                    User aUser, 
                                    bool fFemale,
                                    bool fPhoneCall,
                                    string strSecurityQuestion,
                                    string strSecurityAnswer,
                                    string strMobileAppPwd)
		{
			ACMSDAL.ConnectionProvider connProvider = new ConnectionProvider();
			TblMember sqlMember = new TblMember();
			TblAudit sqlAudit = new TblAudit();

			bool isSuccess = false;

			try
			{
				sqlMember.MainConnectionProvider = connProvider;
				sqlAudit.MainConnectionProvider = connProvider;
				connProvider.OpenConnection();
				connProvider.BeginTransaction("UpdateMemberRecord");
				
				sqlMember.StrMembershipID = strMembershipID;
                sqlMember.FFemale = fFemale;
				sqlMember.FAirCrew = fAirCrew;
				sqlMember.FBounceCheck = fBoundCheck;
				sqlMember.FEmail = fEmail;
				sqlMember.FGIROFailed = fGiroFailed;
				sqlMember.FPostalMail = fPostalMail;
				sqlMember.FSingaporean = fSingaporean;
				sqlMember.FSMS = fSMS;
                sqlMember.FPhoneCall = fPhoneCall;

                if (nLoyaltyStatusID != 0)
                {
                    sqlMember.NLoyaltyStatusID = nLoyaltyStatusID;
                }

				sqlMember.StrAddress1 = strAdd1;
				sqlMember.StrAddress2 = strAdd2;
				sqlMember.StrAltEmail = strAltEmail;
				sqlMember.StrCardName = strCardName;
				sqlMember.StrCompany = strCompany;
				sqlMember.StrCreditCardNo = strCreditCardNo;
				sqlMember.StrEmail = strEmail;
				sqlMember.StrEmergencyContactNumber = strEmergencyContactNo;
				sqlMember.StrEmergencyContactPerson = strEmergencyContactPerson;
				sqlMember.StrHomeNo = strHomeNo;
				sqlMember.StrMemberName = strMemberName;
				sqlMember.StrMobileNo = strMobileNo;
				sqlMember.StrNRICFIN = strNIRCFIN;
				sqlMember.StrOccupation = strOccupation;
				sqlMember.StrOfficeNo = strOfficeNo;
				sqlMember.StrPagerNo = strPagerNo;
				sqlMember.StrPostalCode = strPostalCode;
				sqlMember.StrRemarks = strRemark;
				sqlMember.NMediaSourceID = nMediaSourceID;
                sqlMember.StrMediaSource = strMediaSource;
                sqlMember.NEmployeeID = aUser.NEmployeeID();
                sqlMember.StrSecurityQuestion = strSecurityQuestion;
                sqlMember.StrSecurityAnswer = strSecurityAnswer;
                sqlMember.StrPassword = strMobileAppPwd;
		
				sqlMember.Update2(dateDob, strBeforePhoto, strAfterPhoto, imgPhoto);

				sqlAudit.NAuditTypeID = ACMSLogic.AuditTypeID.MemberRecord;
				sqlAudit.NEmployeeID = aUser.NEmployeeID();
				sqlAudit.StrAuditEntry = "Update member " +strMembershipID;
				sqlAudit.StrReference = strMembershipID;
				sqlAudit.DtDate = DateTime.Now;
				sqlAudit.Insert();

				connProvider.CommitTransaction();
				isSuccess = true;

			}
			catch (Exception)
			{
				connProvider.RollbackTransaction("UpdateMemberRecord");
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
					connProvider.DBConnection.Dispose();
				}
				sqlMember.Dispose();
				sqlAudit.Dispose();
			}
			return isSuccess;
		}

		public DataTable GetAuditTrail(string strMembershipID)
		{
			if (myAuditTrail == null)
				myAuditTrail = new TblAudit();
			return myAuditTrail.SelectForMemberRecord(strMembershipID);
		}

        public DataTable GetMemberBooking(string strMembershipID)
        {
            if (myMember == null)
                myMember = new TblMember();
            return myMember.GetMemberBooking(strMembershipID);
        }

		/// <summary>
		/// Method use to validate at beginning of Introduce friend.
		/// </summary>
		/// <returns></returns>
		public string IntroduceFriendValidation(string strMembershipID, bool hasIntroRight)
		{
			TblMember sqlMember = new TblMember();
			sqlMember.StrMembershipID = strMembershipID;
			DataTable myTable = sqlMember.SelectOne();
			sqlMember.Dispose();

			if (ACMS.Convert.ToDateTime(myTable.Rows[0]["dtSignupDate"]).Date != 
				DateTime.Now.Date)
			{
				if (!hasIntroRight)
					return "This member is not signup today. Therefore, can't introduce by anyone.";
			}

			if (myTable.Rows[0]["strIntroducerMembershipID"] != DBNull.Value)
			{
				return "This member already been introduced.";
			}

			return "";
		}

		public bool SaveIntroduceFriend(string strMembershipID, string strIntroducerID, double point, int employeeID)
		{
			ACMSDAL.ConnectionProvider connProvider = new ConnectionProvider();
			TblMember sqlMember = new TblMember();
			TblRewardsTransaction sqlRewardsTransaction = new TblRewardsTransaction();

			try
			{
				sqlRewardsTransaction.MainConnectionProvider = connProvider;
				sqlMember.MainConnectionProvider = connProvider;
				connProvider.OpenConnection();
				connProvider.BeginTransaction("SaveIntroduceFriend");

				sqlMember.UpdateIntroducerMembershipID(strMembershipID, strIntroducerID);

				sqlRewardsTransaction.DRewardsPoints = point;
				sqlRewardsTransaction.DtDate = DateTime.Now;
				sqlRewardsTransaction.NEmployeeID = employeeID;
				sqlRewardsTransaction.NTypeID = 0;
				sqlRewardsTransaction.StrMembershipID = strIntroducerID;
				sqlRewardsTransaction.StrReferenceNo = strMembershipID;
				sqlRewardsTransaction.Insert();

                for (int i=0;i<5;i++)
                {
                    sqlMember.InsertFWFChance(strIntroducerID);
                }

				connProvider.CommitTransaction();
				return true;
			}
			catch (Exception ex)
			{
				connProvider.RollbackTransaction("SaveIntroduceFriend");
				if (ex.InnerException.Message.IndexOf("FK_tblMember_tblMember") >= 0 || 
					ex.Message.IndexOf("FK_tblMember_tblMember") >= 0 ||
					ex.InnerException.Message.IndexOf("FK_tblRewardsTransaction_tblMember") >= 0 ||
					ex.Message.IndexOf("FK_tblRewardsTransaction_tblMember") >= 0)
				{
					ACMS.Utils.UI.ShowErrorMessage(null, "Please enter a valid Membership ID.", "Error");
					return false;
				}
				else
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
					connProvider.DBConnection.Dispose();
				}
				sqlRewardsTransaction.Dispose();
				sqlMember.Dispose();
			}
		}

		public DataTable SaveIntroduceFriend(string strMembershipID, string strIntroducerID, string Freebie, string strBranchCode,int employeeID)
		{
			ACMSDAL.ConnectionProvider connProvider = new ConnectionProvider();
			TblMember sqlMember = new TblMember();
			try 
			{			
			sqlMember.MainConnectionProvider = connProvider;
			connProvider.OpenConnection();
			connProvider.BeginTransaction("SaveIntroduceFriend");

			sqlMember.UpdateIntroducerMembershipID(strMembershipID, strIntroducerID);
			DataTable IntroFriendFreebieTable =sqlMember.AddIntroFriendFreebie(strMembershipID,strIntroducerID,Freebie,strBranchCode,employeeID);
			
			connProvider.CommitTransaction();
			return IntroFriendFreebieTable;
			}
			catch (Exception ex)
			{
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
					connProvider.DBConnection.Dispose();
				}
				//sqlRewardsTransaction.Dispose();
				sqlMember.Dispose();
			}
		}


        //2006

       // public DataTable SaveIntroduceFriendNew(string strMembershipID, string strIntroducerID, string strPackage, string strRemark, int employeeID)

		
		public bool SaveIntroduceFriendNew(string strMembershipID, string strIntroducerID, string strPackage, string strRemark, int employeeID,int nPackageID)

       {
            ACMSDAL.ConnectionProvider connProvider = new ConnectionProvider();
            TblMember sqlMember = new TblMember();
            TblMemberPackage sqlMemberPackage = new TblMemberPackage();
            TblPackage sqlPackage = new TblPackage();
            try
            {
 
                sqlMember.MainConnectionProvider = connProvider;
                connProvider.OpenConnection();
                connProvider.BeginTransaction("SaveIntroduceFriend");

              //  sqlMember.UpdateIntroducerMembershipID(strMembershipID, strIntroducerID);
                sqlMember.UpdateIntroducerMembershipID(strIntroducerID, strMembershipID);
                MemberPackage.CreateFreeMemberSpaPackage_IntroFriend(strMembershipID, strPackage, strRemark, ref nPackageID);
               // MemberPackage.CreateFreeMemberSpaPackage_IntroFriend(strIntroducerID, strPackage, strRemark, ref nPackageID);

                connProvider.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
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
                    connProvider.DBConnection.Dispose();
                }
                sqlPackage.Dispose();
                sqlMember.Dispose();
            }
        }

        //Amended by TBBC on 22 September 2015 for Intro friend package.
        public bool SaveIntroduceFriendforPackage(string strMembershipID, string strIntroducerID, string strPromotionCode, int employeeID)
        {
            bool bolReturn = false;
            ACMSDAL.ConnectionProvider connProvider = new ConnectionProvider();
            TblMember sqlMember = new TblMember();
            try
            {
                sqlMember.MainConnectionProvider = connProvider;
                connProvider.OpenConnection();
                connProvider.BeginTransaction("SaveIntroduceFriendforPackage");

                //sqlMember.UpdateIntroducerMembershipID(strMembershipID, strIntroducerID);
                DataTable IntroFriendFreebieTable = sqlMember.AddIntroFriendPackage(strIntroducerID, "INTRO " + strMembershipID, strPromotionCode, employeeID);

                //if (IntroFriendFreebieTable.Rows.Count > 0)
                //{
                //    bolReturn = true;
                //}
                connProvider.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
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
                    connProvider.DBConnection.Dispose();
                }
                //sqlRewardsTransaction.Dispose();
                sqlMember.Dispose();
            }
        }

		public DataTable GetCardRequest(string strMembershipID)
		{
			if (myCardRequest == null)
				myCardRequest = new TblCardRequest();
			return myCardRequest.SelectMembershipIDLastest(strMembershipID);
		}

		public DataTable GetCardRequestAudit(string strMembershipID)
		{
			if (myCardRequestAudit == null)
				myCardRequestAudit = new TblAudit();
			return myCardRequestAudit.SelectBynAuditTypeIDstrMembershipID(strMembershipID, ACMSLogic.AuditTypeID.MemberCard);
		}

		public bool UpdateCardStatus(string strMembershipID, User aUser, CardStatusType myType, int nRequestID, 
			string strBranchCode)
		{
			ACMSDAL.ConnectionProvider connProvider = new ConnectionProvider();
			TblMember sqlMember = new TblMember();
			TblCardRequest sqlCardRequest = new TblCardRequest();
			TblAudit sqlAudit = new TblAudit();

			bool isSuccess = false;
			try
			{
				sqlMember.MainConnectionProvider = connProvider;
				sqlCardRequest.MainConnectionProvider = connProvider;
				sqlAudit.MainConnectionProvider = connProvider;
				connProvider.OpenConnection();
				connProvider.BeginTransaction("ChangeCardStatus");

				if (CardStatusType.RequestPrint == myType)
					sqlMember.UpdateCardStatus(strMembershipID, (int)myType, "HQ");
				else
					sqlMember.UpdateCardStatus(strMembershipID, (int)myType, strBranchCode);
				sqlCardRequest.NEmployeeID = aUser.NEmployeeID();
				sqlCardRequest.NRequestID = nRequestID;
				sqlCardRequest.NStatusID = (int)myType;
				sqlCardRequest.StrBranchCode = strBranchCode;
				sqlCardRequest.StrMembershipID = strMembershipID;
				sqlCardRequest.DtLastEditDate = DateTime.Now;
				sqlCardRequest.Update();

				sqlAudit.NAuditTypeID = ACMSLogic.AuditTypeID.MemberCard;
				sqlAudit.NEmployeeID = aUser.NEmployeeID();
				sqlAudit.StrAuditEntry = "Update member card to " +myType.ToString() +".";
				sqlAudit.StrReference = strMembershipID;
				sqlAudit.DtDate = DateTime.Now;
				sqlAudit.Insert();

				connProvider.CommitTransaction();
				isSuccess = true;
			}
			catch (Exception)
			{
				connProvider.RollbackTransaction("ChangeCardStatus");
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
					connProvider.DBConnection.Dispose();
				}
				sqlMember.Dispose();
				sqlCardRequest.Dispose();
				sqlAudit.Dispose();
			}
			return isSuccess;
		}

		public bool Reprint(string strMembershipID, User aUser, CardStatusType myType, string strCardBranchCode)
		{
			ACMSDAL.ConnectionProvider connProvider = new ConnectionProvider();
			TblMember sqlMember = new TblMember();
			TblCardRequest sqlCardRequest = new TblCardRequest();
			TblAudit sqlAudit = new TblAudit();

			bool isSuccess = false;
			try
			{
				sqlMember.MainConnectionProvider = connProvider;
				sqlCardRequest.MainConnectionProvider = connProvider;
				sqlAudit.MainConnectionProvider = connProvider;
				connProvider.OpenConnection();
				connProvider.BeginTransaction("ReprintCard");

				sqlMember.UpdateCardStatus(strMembershipID, (int)myType, strCardBranchCode);
				sqlCardRequest.NEmployeeID = aUser.NEmployeeID();
				sqlCardRequest.NStatusID = (int)myType;
				sqlCardRequest.StrBranchCode = aUser.StrBranchCode();
				sqlCardRequest.StrMembershipID = strMembershipID;
				sqlCardRequest.DtLastEditDate = DateTime.Now;
				sqlCardRequest.Insert();

				sqlAudit.NAuditTypeID = ACMSLogic.AuditTypeID.MemberCard;
				sqlAudit.NEmployeeID = aUser.NEmployeeID();
				sqlAudit.StrAuditEntry = "Reprint member card.";
				sqlAudit.StrReference = strMembershipID;
				sqlAudit.DtDate = DateTime.Now;
				sqlAudit.Insert();

				connProvider.CommitTransaction();
				isSuccess = true;
			}
			catch (Exception)
			{
				connProvider.RollbackTransaction("ReprintCard");
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
					connProvider.DBConnection.Dispose();
				}
				sqlMember.Dispose();
				sqlCardRequest.Dispose();
				sqlAudit.Dispose();
			}
			return isSuccess;
		}

		public bool Reprint(string strMembershipID, int nEmployee, int CardStatus, string strCardBranchCode)
		{
			ACMSDAL.ConnectionProvider connProvider = new ConnectionProvider();
			TblMember sqlMember = new TblMember();
			TblCardRequest sqlCardRequest = new TblCardRequest();
			TblAudit sqlAudit = new TblAudit();

			bool isSuccess = false;
			try
			{
				sqlMember.MainConnectionProvider = connProvider;
				sqlCardRequest.MainConnectionProvider = connProvider;
				sqlAudit.MainConnectionProvider = connProvider;
				connProvider.OpenConnection();
				connProvider.BeginTransaction("ReprintCard");

				sqlMember.UpdateCardStatus(strMembershipID, CardStatus, strCardBranchCode);
				sqlCardRequest.NEmployeeID = nEmployee;
				sqlCardRequest.NStatusID = CardStatus;
				sqlCardRequest.StrBranchCode = strCardBranchCode;
				sqlCardRequest.StrMembershipID = strMembershipID;
				sqlCardRequest.DtLastEditDate = DateTime.Now;
				sqlCardRequest.Insert();

				sqlAudit.NAuditTypeID = ACMSLogic.AuditTypeID.MemberCard;
				sqlAudit.NEmployeeID = nEmployee;
				sqlAudit.StrAuditEntry = "Reprint member card.";
				sqlAudit.StrReference = strMembershipID;
				sqlAudit.DtDate = DateTime.Now;
				sqlAudit.Insert();

				connProvider.CommitTransaction();
				isSuccess = true;
			}
			catch (Exception)
			{
				connProvider.RollbackTransaction("ReprintCard");
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
					connProvider.DBConnection.Dispose();
				}
				sqlMember.Dispose();
				sqlCardRequest.Dispose();
				sqlAudit.Dispose();
			}
			return isSuccess;
		}
        

		#endregion


		#region Reset & Block membership
		public static void CurrentLastMembershipID(string strTerminalBranch, ref int lastNonMemberID, ref int lastMemberID)
		{
			ACMSDAL.ConnectionProvider connProvider = new ConnectionProvider();
			TblCompany sqlCompany = new TblCompany();
			TblBranch sqlBranch = new TblBranch();

			try
			{
				sqlCompany.MainConnectionProvider = connProvider;
				sqlBranch.MainConnectionProvider = connProvider;
				connProvider.OpenConnection();
				connProvider.BeginTransaction("LastMembershipID");

				DataTable companyTable = sqlCompany.SelectAll();
				sqlBranch.StrBranchCode = strTerminalBranch;
				DataTable branchTable = sqlBranch.SelectOne();

				connProvider.CommitTransaction();

				lastNonMemberID = ACMS.Convert.ToInt32(companyTable.Rows[0]["nNonMembershipNo"]);
				lastMemberID = ACMS.Convert.ToInt32(branchTable.Rows[0]["nMembershipNo"]);
				return;
			}
			catch (Exception)
			{
				connProvider.RollbackTransaction("ResetMembershipID");
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
					connProvider.DBConnection.Dispose();
				}
				sqlCompany.Dispose();
				sqlBranch.Dispose();
			}
		}

		public static bool MembershipIDExist(string strMembershipID)
		{
			ACMSDAL.ConnectionProvider connProvider = new ConnectionProvider();
			TblMember sqlMember = new TblMember();

			try
			{
				sqlMember.MainConnectionProvider = connProvider;
				connProvider.OpenConnection();

				return sqlMember.MembershipIDExists(strMembershipID);
			}
			finally
			{
				if (connProvider.DBConnection != null)
				{
					if (connProvider.DBConnection.State == ConnectionState.Open)
						connProvider.DBConnection.Close();
					connProvider.DBConnection.Dispose();
				}
				sqlMember.Dispose();
			}
		}

		public static bool ResetMembershipID(int lastNonMemberID, int lastMemberID, string strBranchCode)
		{
			ACMSDAL.ConnectionProvider connProvider = new ConnectionProvider();
			TblCompany sqlCompany = new TblCompany();
			TblBranch sqlBranch = new TblBranch();

			try
			{
				sqlCompany.MainConnectionProvider = connProvider;
				sqlBranch.MainConnectionProvider = connProvider;
				connProvider.OpenConnection();
				connProvider.BeginTransaction("ResetMembershipID");

				if (lastNonMemberID > 0)
				{
					sqlCompany.UpdateLastMembershipID(lastNonMemberID);
				}
				if (lastMemberID > 0)
				{
					sqlBranch.UpdateLastMembershipID(strBranchCode, lastMemberID);
				}

				connProvider.CommitTransaction();
				return true;
			}
			catch (Exception)
			{
				connProvider.RollbackTransaction("ResetMembershipID");
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
					connProvider.DBConnection.Dispose();
				}
				sqlCompany.Dispose();
				sqlBranch.Dispose();
			}
		}

		public static bool BlockMembershipID(int numberOfNonMemberID, int numberOfMemberID, string strBranchCode)
		{
			ACMSDAL.ConnectionProvider connProvider = new ConnectionProvider();
			TblCompany sqlCompany = new TblCompany();
			TblBranch sqlBranch = new TblBranch();

			try
			{
				sqlCompany.MainConnectionProvider = connProvider;
				sqlBranch.MainConnectionProvider = connProvider;
				connProvider.OpenConnection();
				connProvider.BeginTransaction("BlockMembershipID");

				if (numberOfNonMemberID > 0)
					sqlCompany.UpdateBlockNonMembershipID(numberOfNonMemberID);
				if (numberOfMemberID > 0)
					sqlBranch.UpdateBlockMembershipID(strBranchCode, numberOfMemberID);

				connProvider.CommitTransaction();
				return true;
			}
			catch (Exception)
			{
				connProvider.RollbackTransaction("BlockMembershipID");
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
					connProvider.DBConnection.Dispose();
				}
				sqlCompany.Dispose();
				sqlBranch.Dispose();
			}
		}
		#endregion

		#region Static Method
		public static bool ValidateNRICFormat(string strNRIC)
		{
			string pat = @"[A-Z]\d\d\d\d\d\d\d[A-Z]";
			Regex r = new Regex(pat, RegexOptions.IgnoreCase);
			Match m = r.Match(strNRIC);
			return m.Success;
		}

		public static bool IsNumeric(string inputString) 
		{ 
			return Regex.IsMatch(inputString, "^[0-9]+$"); 
		}

		/// <returns>return true if is correct format</returns>
		public static bool IsMask(string input)
		{
			if (input.IndexOf("_") >= 0)
				return false;
			else
				return true;
		}
		#endregion

		#region enum
		public enum SearchMemberType
		{
			AllMember,
			MemberOnly,
			NonMember
		}
		#endregion
	}
}
