using System;
using System.Data;
using System.Data.SqlClient;
using ACMSDAL;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;

namespace ACMSLogic
{
	/// <summary>
	/// Summary description for ClassAttendance.
	/// </summary>
	public class ClassAttendance
	{
		public const string TEMP_INSTRUCTOR = "temp";

		private TblClassInstance myClassInstance;
		private DataTable myDataTable;
        private string connectionString;
        private SqlConnection connection;
		public ClassAttendance()
		{
			//
			// TODO: Add constructor logic here
			//
			Init();
		}
		
		public DataTable ClassInstanceTable
		{
			get { return myDataTable;}
		}

		private void Init()
		{
			//myDataTab
			myClassInstance = new TblClassInstance();
			GetClassInstance(DateTime.Now.Date, User.BranchCode);
            connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"];
            connection = new SqlConnection(connectionString);
		}
		
		/// <summary>
		/// 2.3.1.1.3.1 ) View Class Instance
		/// can use for 2.3.1.2 ) View Class Restriction
		/// </summary>
		/// <param name="dtDate"></param>
		public DataTable GetClassInstance(DateTime dtDate, string strBranchCode)
		{
			myDataTable = myClassInstance.GetClassInstanceBaseDate(dtDate, strBranchCode);
			return myDataTable;
		}

		public bool LoginClassInstance(int nClassInstanceID, string employeeID, string employeePassword)
		{
			myClassInstance.NClassInstanceID = nClassInstanceID;
			myClassInstance.SelectOne();
			
			int nEmployeeID = 0;

			if (employeeID != TEMP_INSTRUCTOR)
			{
				try
				{
					nEmployeeID = System.Convert.ToInt32(employeeID);
				}
				catch
				{
					return false;
				}
			}
			
			if (employeeID.ToLower().Trim() != TEMP_INSTRUCTOR)
			{
				int nReplacementInstructorID = myClassInstance.NReplacementInstructorID.IsNull ? 0 : myClassInstance.NReplacementInstructorID.Value;
				int nPermanentInstructorID = myClassInstance.NPermanentInstructorID.IsNull ? 0 : myClassInstance.NPermanentInstructorID.Value;

				if (nReplacementInstructorID == nEmployeeID ||
					nPermanentInstructorID == nEmployeeID)
				{
					TblEmployee employee = new TblEmployee();
					employee.NEmployeeID = nEmployeeID;
					employee.SelectOne(); 
					if (employee.StrPassword.Value == employeePassword)
					{
						myClassInstance.NActualInstructorID = nEmployeeID;
						myClassInstance.DtInstructorLogin = DateTime.Now;
				
						myClassInstance.Update();
						return true;
					}
					else
						return false;
				}
				else 
				{
					return false;
				}
			}
			else
			{
				return true;
			}
		}
			
		public bool VerifyIntructor(int nClassInstanceIDToBeVerified, int verifyUserID,string verifyUserPassword,
			int nStandingIntructorID, string remark)

		{

			TblEmployee verifyUser = new TblEmployee();

			verifyUser.NEmployeeID = verifyUserID;

			verifyUser.SelectOne();

			int [,] intArray = new int[50,2];

			int ArrayNo=1;

                  

			if (verifyUser.StrPassword.Value != verifyUserPassword)

				return false;

                  

			myClassInstance.NClassInstanceID = nClassInstanceIDToBeVerified;

			myClassInstance.SelectOne();

 

			if (myClassInstance.NActualInstructorID.IsNull)

				throw new Exception("Missing Intructor login info");

 

			if (myClassInstance.NActualInstructorID.Value == verifyUserID)

				throw new Exception("Instructor are not allowed to verfiy for the same class.");

 

			if (!myClassInstance.NVerifyID.IsNull)

				throw new Exception("This class have been verify by other staff with the employee ID : "+  myClassInstance.NVerifyID.Value.ToString());

                  

			bool isLate =false;

                  

			DateTime StartTime;

			DateTime LoginTime;

 

			myClassInstance.MInstructorDeduction=0;

 

			StartTime=ACMS.Convert.ToDBDateTime(myClassInstance.DtStartTime.Value.ToLongTimeString());

 

			LoginTime=ACMS.Convert.ToDBDateTime(myClassInstance.DtInstructorLogin.Value.ToLongTimeString());

 

                  

			if (DateTime.Compare(LoginTime,StartTime)>0)

			{

				isLate=true;

			}

 

			bool haveStandingIntructor = nStandingIntructorID > 0;

 

			if (haveStandingIntructor)

				myClassInstance.NStandinInstructorID = nStandingIntructorID;

 

			if (isLate)

			{

				TblCompany company = new TblCompany();

				DataTable companyTable = company.SelectAll();

				decimal instructorLateDeductionFee = 0;

				if (companyTable.Rows.Count > 0)

				{

					instructorLateDeductionFee =  ACMS.Convert.ToDecimal(companyTable.Rows[0]["mInstructorLateDeductionFee"]);

				}

                        

				myClassInstance.MInstructorDeduction=instructorLateDeductionFee;

 

 

				if (nStandingIntructorID != 0)

					myClassInstance.MStandinInstructorFees = instructorLateDeductionFee;

			}

 

			int nCommissionTypeID = myClassInstance.NCommissionTypeID.Value;

			TblEmployee actualInstructor = new TblEmployee();

			actualInstructor.NEmployeeID = myClassInstance.NActualInstructorID;

			actualInstructor.SelectOne();

			int nInstructorTypeID = ACMS.Convert.ToInt32(actualInstructor.NInstructorTypeID);

			myClassInstance.MInstructorFees = (GetCommission(nCommissionTypeID, nInstructorTypeID) - myClassInstance.MInstructorDeduction);

            

			TblClassAttendance classAttendance = new TblClassAttendance();

			classAttendance.NClassInstanceID = nClassInstanceIDToBeVerified;

			DataTable classAttendanceTable = classAttendance.SelectAllWnClassInstanceIDLogic();

            

			DataRow[] classAttendanceRowList = null;

 

			if (classAttendanceTable != null && classAttendanceTable.Rows.Count > 0)

			{                 

				classAttendanceRowList = classAttendanceTable.Select("nStatusID = 0", "nAttendanceID", DataViewRowState.CurrentRows);

				foreach (DataRow r in classAttendanceRowList)

				{

					r["nStatusID"] = 2;
					r["nTypeID"]=0;

				}

			}

 

			ACMSDAL.ConnectionProvider connProvider = new ConnectionProvider();

			try

			{                       

				myClassInstance.MainConnectionProvider = connProvider;

				classAttendance.MainConnectionProvider = connProvider;

 

				connProvider.OpenConnection();

				connProvider.BeginTransaction("VerifyClassInstance");

 

				myClassInstance.NVerifyID = verifyUserID;

				myClassInstance.StrRemarks = remark;

				myClassInstance.Update();

				classAttendance.SaveData(classAttendanceTable);

                        

				TblMemberPackage sqlMemberPackage = new TblMemberPackage();

				sqlMemberPackage.MainConnectionProvider = connProvider;

 

            

				if (classAttendanceRowList != null)

				{

					int nPackageID = -1;

 

					foreach (DataRow r in classAttendanceRowList)

					{

						nPackageID = ACMS.Convert.ToInt32(r["nPackageID"]);

						int nAttendanceID=ACMS.Convert.ToInt32(r["nAttendanceID"]);

						DataTable memberPackageTable = sqlMemberPackage.GetMemberPackage(nPackageID);

                                    

						if (memberPackageTable.Rows[0]["strPackageCode"].ToString() != "Unlinked")

						{

							#region test

                            //MemberPackage.CalculateMemberPackageBalance(memberPackageTable, connProvider); 

							if (ACMS.Convert.ToInt32(memberPackageTable.Rows[0]["Balance"]) > 0)

							{

								DateTime classDate = myClassInstance.DtDate.IsNull ? DateTime.Today.Date : myClassInstance.DtDate.Value;

								DataRow masterRow = memberPackageTable.Rows[0];// Means new class Attendance gonna insert

								if (masterRow["dtStartDate"] == DBNull.Value && 

									masterRow["dtExpiryDate"] == DBNull.Value)

								{

                                                

									TblPackage package = new TblPackage();

									package.StrPackageCode = masterRow["strPackageCode"].ToString();

									package.SelectOne();


                                    if (package.NPackageDuration == 0 && package.NPackageDay > 0)
                                    {
                                        masterRow["dtStartDate"] = classDate;
                                        masterRow["dtExpiryDate"] = classDate.AddDays(package.NPackageDay.Value -1);
                                    }
                                    else
                                    {
                                        masterRow["dtStartDate"] = classDate;
                                        masterRow["dtExpiryDate"] = classDate.AddMonths(package.NPackageDuration.Value).AddDays(-1);
                                    }

								}

								else

								{

									DateTime memberPackageStartDate =  ACMS.Convert.ToDateTime(masterRow["DtStartDate"]);

									DateTime memberPackageExpiryDate = ACMS.Convert.ToDateTime(masterRow["dtExpiryDate"]);

									if (memberPackageStartDate > classDate)

									{

										masterRow["dtExpiryDate"] = memberPackageExpiryDate.Subtract(memberPackageStartDate.Subtract(classDate)); 

									}

								}

							}

 

							else if (ACMS.Convert.ToInt32(memberPackageTable.Rows[0]["Balance"]) <=0)

							{

								intArray[ArrayNo,0]=nPackageID;

								intArray[ArrayNo,1]=nAttendanceID;

								ArrayNo=ArrayNo+1;                  

								MessageBox.Show("Package Balance of " + memberPackageTable.Rows[0]["strMembershipID"].ToString().TrimEnd() + " is Zero. Attendance will be cancel");

							}

                                          

							#endregion

						}



                        if (ACMS.Convert.ToInt32(memberPackageTable.Rows[0]["nMaxSession"]) == 9999 && memberPackageTable.Rows[0]["fGIRO"].ToString() != "1")
						{

							DateTime dtExpiryDate = ACMS.Convert.ToDateTime(memberPackageTable.Rows[0]["dtExpiryDate"]);

							DateTime dtStartDate = ACMS.Convert.ToDateTime(memberPackageTable.Rows[0]["dtStartDate"]);

 

							if (dtExpiryDate != DateTime.MinValue)

							{

								memberPackageTable.Rows[0]["dtExpiryDate"] = dtExpiryDate.AddDays(-1);

                                                

							}

						}

						sqlMemberPackage.SaveData(memberPackageTable);  

                              

					}

				}

				connProvider.CommitTransaction();

			}

			catch (Exception)

			{

				connProvider.RollbackTransaction("VerifyClassInstance");

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

				myClassInstance.MainConnactionIsCreatedLocal = true;

				classAttendance.MainConnactionIsCreatedLocal = true;

			}

                  

			for (int j=1;j<=50;j++)

			{

				if (intArray[j,0]>0) DeleteClassAttendance(intArray[j,0],intArray[j,1],"");

				else if (intArray[j,0]<=0) 

				{return true;}    

			}

                        

			return true;

		}

		public void CancelClassInstance(int nClassInstanceID, string remark)
		{
			myClassInstance.NClassInstanceID = nClassInstanceID;
			myClassInstance.SelectOne();
			myClassInstance.FCancelled = System.Data.SqlTypes.SqlBoolean.True;
			myClassInstance.StrRemarks = remark;
			TblAudit audit = new TblAudit();

			audit.DtDate = DateTime.Today;
			audit.NAuditTypeID = AuditTypeID.ClassAuditTypeID;
			audit.NEmployeeID = ACMSLogic.User.EmployeeID;
			audit.StrAuditEntry = "Cancel class instance " + nClassInstanceID.ToString();
			audit.StrReference = nClassInstanceID.ToString();
			
			TblClassAttendance classAttendance = new TblClassAttendance();
			classAttendance.NClassInstanceID = nClassInstanceID;
			DataTable classAttendanceTable = classAttendance.SelectAllWnClassInstanceIDLogic();

			if (classAttendanceTable != null && classAttendanceTable.Rows.Count > 0)
			{
				foreach (DataRow r in classAttendanceTable.Rows)
				{
					r["nStatusID"] = 3;
				}
			}
			
			ACMSDAL.ConnectionProvider connProvider = new ConnectionProvider();

			try
			{
				myClassInstance.MainConnectionProvider = connProvider;
				audit.MainConnectionProvider = connProvider;
				classAttendance.MainConnectionProvider = connProvider;

				connProvider.OpenConnection();
				connProvider.BeginTransaction("CancelClassInstance");
				myClassInstance.Update();
				audit.Insert();
				classAttendance.SaveData(classAttendanceTable);
				connProvider.CommitTransaction();

                DataTable dtAttendance = new DataTable();
                dtAttendance = GetClassAttendanceReservedAndAttended(nClassInstanceID);

                DialogResult result1 = MessageBox.Show("Push Notification to Mobile app users? ", "Confirm", MessageBoxButtons.YesNo);
                if (result1 == DialogResult.Yes)
                {
                    foreach (DataRow row in dtAttendance.Rows)
                    {
                        string strMsgContent = row["strDescription"].ToString() + " at " + row["strBranchName"] + " at " + Convert.ToDateTime(myClassInstance.DtStartTime).ToString("h.mmtt") + " on " + Convert.ToDateTime(myClassInstance.DtStartTime).ToString("dd MMM") + " has been cancelled. Sorry for any inconvenience caused.";
                        PushNotification(row["strMembershipID"].ToString(), strMsgContent);
                    }
                }
			}
			catch (Exception)
			{
				connProvider.RollbackTransaction("CancelClassInstance");
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
				myClassInstance.MainConnactionIsCreatedLocal = true;
			}
		}
		
		public void AssignReplacementInstructor(int nClassInstanceID, int newReplacementInstructorID)
		{
			myClassInstance.NClassInstanceID = nClassInstanceID;
			myClassInstance.SelectOne();

			if (myClassInstance.DtDate < DateTime.Now.Date)
				throw new Exception("Only future class can assign replacement instructor");

			myClassInstance.NReplacementInstructorID = newReplacementInstructorID;
			myClassInstance.NReplacementIssueID = User.EmployeeID;
			myClassInstance.DtReplacementIssueDate = DateTime.Now.Date;

			myClassInstance.Update();
		}

		public void ChangeClass(int nClassInstanceID, string strClassCode, string strRemark)
		{
			TblAudit audit = new TblAudit();
			TblClassInstance sqlClassIns = new TblClassInstance();
            TblClass sqlClass = new TblClass();
            TblBranch sqlBranch = new TblBranch();

			ACMSDAL.ConnectionProvider connProvider = new ConnectionProvider();
			
			string oldClassCode = "";
            string oldClassName="";
            string newClassName = "";
            string strBranchName = "";

			try
			{
				sqlClassIns.MainConnectionProvider = connProvider;
				audit.MainConnectionProvider = connProvider;
				
				connProvider.OpenConnection();
				connProvider.BeginTransaction("ChangeClassInstance");	

				sqlClassIns.NClassInstanceID = nClassInstanceID;
				sqlClassIns.SelectOne();
				oldClassCode = sqlClassIns.StrClassCode.Value;
				if (sqlClassIns.DtDate < DateTime.Now.Date)
					throw new Exception("Only future class can assign new class code");
            
				sqlClassIns.StrClassCode = strClassCode;
				sqlClassIns.StrRemarks = strRemark;
				sqlClassIns.Update();

                sqlClass.StrClassCode = oldClassCode;
                sqlClass.SelectOne();
                oldClassName = sqlClass.StrDescription.ToString();

                sqlBranch.StrBranchCode = sqlClassIns.StrBranchCode.ToString();
                sqlBranch.SelectOne();
                strBranchName = sqlBranch.StrBranchName.ToString();

                sqlClass.StrClassCode = strClassCode;
                sqlClass.SelectOne();
                newClassName = sqlClass.StrDescription.ToString();

				audit.DtDate = DateTime.Now;
				audit.NAuditTypeID = AuditTypeID.ClassAuditTypeID;
				audit.NEmployeeID = ACMSLogic.User.EmployeeID;
				audit.StrAuditEntry = string.Format("Old Class Code = {0}, " + 
													"New Class Code = {1}", 
													oldClassCode, strClassCode); // "Change class instance : " + nClassInstanceID.ToString() + " to class code: " + strClassCode;
				audit.StrReference = "Class InstanceID :" + nClassInstanceID.ToString();
				audit.Insert();
				connProvider.CommitTransaction();

                DataTable dtAttendance = new DataTable();
                dtAttendance = GetClassAttendanceReservedAndAttended(nClassInstanceID);

                DialogResult result1 = MessageBox.Show("Push Notification to Mobile app users? ", "Confirm", MessageBoxButtons.YesNo);
                if (result1 == DialogResult.Yes)
                {
                    foreach (DataRow row in dtAttendance.Rows)
                    {
                        string strMsgContent = oldClassName + " at " + strBranchName + " at " + Convert.ToDateTime(row["dtStartTime"]).ToString("h.mmtt") + " on " + Convert.ToDateTime(row["dtStartTime"]).ToString("dd MMM") + " has been changed to " + newClassName + ". Sorry for any inconvenience caused.";
                        PushNotification(row["strMembershipID"].ToString(), strMsgContent);
                    }
                }
			}
			catch (Exception)
			{
				connProvider.RollbackTransaction("ChangeClassInstance");
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
			}
		}

        public static void PushNotification(string strMembershipID, string strMsgContent)
        {
            WebRequest request = WebRequest.Create("http://web.amorefitness.com:8080/amore_app/exec/exec_notification_modified/pushMember/" + strMembershipID + "/" + strMsgContent);
            // Set the Method property of the request to POST.
            request.Method = "POST";
            // Create POST data and convert it to a byte array.

            string postData = "memberid=" + strMembershipID + "&msg=" + strMsgContent;
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/x-www-form-urlencoded";
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;
            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();
        }

		/// <summary>
		/// Use to calculate the total attendance
		/// </summary>
		/// <param name="nClassInstanceID"></param>
		/// <returns></returns>
		public DataView GetdwClassAttendanceView(int nClassInstanceID)
		{
			TblClassAttendance classAttendance = new TblClassAttendance();
			DataTable table = classAttendance.GetClassAttendancesBaseClassInstanceID(nClassInstanceID);
			table.DefaultView.RowFilter = "nStatusID = 1 or nStatusID = 2 or nStatusID = 4 or nStatusID is null";

			return table.DefaultView;
		}

        public DataTable GetWaitingListView(int nClassInstanceID)
        {
            TblWaitingList wl = new TblWaitingList();
            DataTable table = wl.GetWaitingListBaseClassInstanceID(nClassInstanceID);
            table.DefaultView.RowFilter = "nStatusID = 0";

            return table.DefaultView.ToTable();
        }

        public DataView GetWaitingList(int nClassInstanceID)
        {
            TblClassAttendance classAttendance = new TblClassAttendance();
            DataTable table = classAttendance.GetClassAttendancesBaseClassInstanceID(nClassInstanceID);
            table.DefaultView.RowFilter = "nStatusID = 1 or nStatusID = 2 or nStatusID = 4 or nStatusID is null";

            return table.DefaultView;
        }

		public DataView GetClassAttendanceView(int nClassInstanceID)
		{
			TblClassAttendance classAttendance = new TblClassAttendance();
			DataTable table = classAttendance.GetClassAttendancesBaseClassInstanceID(nClassInstanceID);
			table.DefaultView.RowFilter = "nStatusID = 1";

			return table.DefaultView;
		}

        public DataTable GetClassAttendanceReservedAndAttended(int nClassInstanceID)
        {
            TblClassAttendance classAttendance = new TblClassAttendance();
            DataTable table = classAttendance.GetClassAttendancesBaseClassInstanceID(nClassInstanceID);
            table.DefaultView.RowFilter = "(nStatusID = 0 or nStatusID = 1) and fMobileBooking=1";

            return table.DefaultView.ToTable();
        }

		public DataTable GetClassAttendance(int nClassInstanceID)
		{
			TblClassAttendance classAttendance = new TblClassAttendance();
			DataTable table = classAttendance.GetClassAttendancesBaseClassInstanceID(nClassInstanceID);
			return table;
		}

		public DataTable GetAttendedMember(int nClassInstanceID)
		{
			TblClassAttendance classAttendance = new TblClassAttendance();
			DataTable table = classAttendance.LoadData(string.Format("Select strMembershipID From tblClassAttendance Where nClassInstanceID = {0}", nClassInstanceID));
			return table;
		}

		public DataView GetGymAttendance(DateTime dtDate)
		{
			TblClassAttendance classAttendance = new TblClassAttendance();
			DataTable table = classAttendance.GetGymAttendancesBaseDate(dtDate, ACMSLogic.User.BranchCode);

			table.DefaultView.RowFilter = "nTypeID = 1 And (nStatusID = 1 or nStatusID = 2 or nStatusID = 4 or nStatusID is null)";
			return table.DefaultView;
		}

		public void MarkAttendance(int nClassInstanceID, int nPackageID, string strMembershipID, 
			int nClassType, bool isRefunded, bool needToVerifyMemberPackage)
		{
			
			MemberPackage memberPackage = new MemberPackage();
			bool createNewClassAttendance = false;
			
			ACMSDAL.TblClassInstance sqlClassInstance = new TblClassInstance();
			sqlClassInstance.NClassInstanceID = nClassInstanceID;
			sqlClassInstance.SelectOne();

			if (sqlClassInstance.NActualInstructorID.IsNull)
				throw new Exception("No intructor has logined to this class. You cannot mark the attendance now.");

            //verify non peak package holder
            TblMemberPackage clsMemberPackage = new TblMemberPackage();
            clsMemberPackage.NPackageID = nPackageID;
            clsMemberPackage.SelectOne();

            TblPackage clsPackage = new TblPackage();
            clsPackage.StrPackageCode = clsMemberPackage.StrPackageCode;
            clsPackage.SelectOne();

            if (clsPackage.FPeak.IsNull == false && sqlClassInstance.FPeak.IsNull == false) {
                if (clsPackage.FPeak.Value == false && sqlClassInstance.FPeak == false) { }
                else
                {
                    throw new Exception("Member holding Leisure Package and only allow to mark the attendance for non peak classes.");
                }
            }            

			if (needToVerifyMemberPackage)
			{
				if (!VerifyMemberPackageAllowCertainClass(nPackageID, sqlClassInstance.StrClassCode.Value))
				{
					//throw new Exception("The package you wish to use is not allow to attend the class. Please use other package.");
					DialogResult result = MessageBox.Show("The package you wish to use is not allow to attend the class. Do you still want to mark it. \n " + 
						"(An unlinked record will be create if you click yes) ", "Warning",MessageBoxButtons.YesNo);
				
					if (result == DialogResult.Yes)
					{
						MemberPackage.CreateUnlinkedMemberPackage(strMembershipID, ref nPackageID);
					}
					else
					{
						return;
					}
				}
			}

			createNewClassAttendance = memberPackage.NewClassAttendance(nPackageID, strMembershipID, nClassInstanceID, nClassType, 
				User.BranchCode, sqlClassInstance.DtDate.Value, sqlClassInstance.DtStartTime.Value, sqlClassInstance.DtEndTime.Value, isRefunded);
			
			
			if (nPackageID >= 0)
				PrintClassAttendanceReminder(nPackageID, strMembershipID, nClassInstanceID);
			
		}


		public void MarkGymAttendance(int nPackageID, string strMembershipID, bool needToVerify)
		{
            string cmdText = "select npackageid from tblMemberPackage mp left join tblReceipt r on mp.strReceiptNo=r.strReceiptNo left join tblPackage p on mp.strPackageCode=p.strPackageCode " +
                            "where mp.strReceiptNo is not null and r.strReceiptNo is null and nStatusID=0 and mp.strRemarks not like '%PKG MISSING FROM SYSTEM%' " +
                            "and mp.strReceiptNo not like '%FOC%' and fFree=0 and p.nCategoryID not in (23,14) and nPackageID=@nPackageID ";

            TblInstructorCommission commission = new TblInstructorCommission();
            DataTable dt = commission.LoadData(cmdText, new string[] { "@nPackageID" }, new object[] { nPackageID });
            if (dt != null && dt.Rows.Count > 0)            
            {
                MessageBox.Show("Not allow to use this package as not receipt found.", "Warning", MessageBoxButtons.OK);
                return;
            }

			MemberPackage memberPackage = new MemberPackage();
			myClassInstance.StrClassCode = "GYM";
			DataTable table = myClassInstance.SelectAllWstrClassCodeLogic();

			if (table == null || table.Rows.Count == 0)
				throw new Exception("Failed to mark GYM Attendance.");

			int nClassInstanceID = ACMS.Convert.ToInt32(table.Rows[0]["nClassInstanceID"]);

			bool createNewClassAttendance = false;

			if (needToVerify)
			{
			
				if (!VerifyMemberPackageAllowCertainClass(nPackageID,"GYM"))
				{
					DialogResult result = MessageBox.Show("The package you wish to use is not allow to attend the class. Do you still want to mark it. \n " + 
						"(An unlinked record will be create if you click yes) ", "Warning",MessageBoxButtons.YesNo);
				
					if (result == DialogResult.Yes)
					{
						MemberPackage.CreateUnlinkedMemberPackage(strMembershipID, ref nPackageID);
					}
					else
					{
						return;
					}
					//throw new Exception("The package you wish to use is not allow to attend the class. Please use other package.");
				}
			}

			createNewClassAttendance = memberPackage.NewClassAttendance(nPackageID, strMembershipID, nClassInstanceID, 1, 
				User.BranchCode, DateTime.Today.Date, DateTime.Now, DateTime.Now, true);
			
			PrintClassAttendanceReminder(nPackageID, strMembershipID, nClassInstanceID);
			
		}


		public void MarkGymAttendance(int nPackageID, string strMembershipID, DateTime dtDate, DateTime dtStartTime, DateTime dtEndTime ,bool needToVerify)
		{
			MemberPackage memberPackage = new MemberPackage();
			myClassInstance.StrClassCode = "GYM";
			DataTable table = myClassInstance.SelectAllWstrClassCodeLogic();

			if (table == null || table.Rows.Count == 0)
				throw new Exception("Failed to mark GYM Attendance.");

			int nClassInstanceID = ACMS.Convert.ToInt32(table.Rows[0]["nClassInstanceID"]);

			bool createNewClassAttendance = false;

			if (needToVerify)
			{
			
				if (!VerifyMemberPackageAllowCertainClass(nPackageID,"GYM"))
				{
					DialogResult result = MessageBox.Show("The package you wish to use is not allow to attend the class. Do you still want to mark it. \n " + 
						"(An unlinked record will be create if you click yes) ", "Warning",MessageBoxButtons.YesNo);
				
					if (result == DialogResult.Yes)
					{
						MemberPackage.CreateUnlinkedMemberPackage(strMembershipID, ref nPackageID);
					}
					else
					{
						return;
					}
					//throw new Exception("The package you wish to use is not allow to attend the class. Please use other package.");
				}
			}

			createNewClassAttendance = memberPackage.NewClassAttendance(nPackageID, strMembershipID, nClassInstanceID, 1, 
				User.BranchCode, dtDate, dtStartTime, dtEndTime, true);
			
			PrintClassAttendanceReminder(nPackageID, strMembershipID, nClassInstanceID);
			
		}

		public void PrintClassAttendanceReminder(int nPackageID, string strMembershipID, int nClassInstanceID)
		{
			TblCompany comp = new TblCompany();
			DataTable compTable = comp.SelectAll();

			int nClassLeft = 0;
			int nDaysToExpire = 0;

			if (compTable != null && compTable.Rows.Count > 0)
			{
				nClassLeft = ACMS.Convert.ToInt32(compTable.Rows[0]["nClassLeft"]);
				nDaysToExpire = ACMS.Convert.ToInt32(compTable.Rows[0]["nDaysToExpire"]);
			}

			TblMemberPackage sqlMemberPackage = new TblMemberPackage();
			DataTable memberPackageTable = sqlMemberPackage.GetMemberPackage(nPackageID);
                        
            ACMSLogic.MemberPackage.CalculateMemberPackageBalance(memberPackageTable.Rows[0]["strPackageCode"].ToString(),strMembershipID, memberPackageTable);
			
			DateTime expiryDate = ACMS.Convert.ToDateTime(memberPackageTable.Rows[0]["dtExpiryDate"]);
			
			TblMember member = new TblMember();
			DataTable memberTable = member.LoadData("Select dtDOB, strMemberName from tblMember Where strMembershipID = @strMembershipID",
				new string[] {"@strMembershipID"}, new object[] {strMembershipID});
			
			ACMSLogic.Printing myReceiptPrinting = new Printing();
			myReceiptPrinting.WriteLine(string.Format("Branch : {0} {1}", User.BranchCode, 
				DateTime.Now.ToString("dd/MM/yyyy  hh:mm tt")));
			myReceiptPrinting.WriteLine(string.Format("Membership ID : {0}", strMembershipID));
			myReceiptPrinting.WriteLine(string.Format("Member Name : {0}", memberTable.Rows[0]["strMemberName"].ToString()));
			myReceiptPrinting.WriteLine("");
			
			if (memberPackageTable.Rows[0]["strPackageCode"].ToString() == "Unlinked")
			{
			
				myReceiptPrinting.WriteLine("No Valid Fitness Package.");
				//DataTable packageTable = sqlMemberPackage.LoadData("select mListPrice from tblPackage Where strDescription = 'Trial Gym'");
				//myReceiptPrinting.WriteLine("No Valid Fitness Package.");
				myReceiptPrinting.Print();
				return;
			}

			bool bClassPrint ;

			bClassPrint=false;

			if (memberPackageTable.Rows[0]["dtStartDate"] != DBNull.Value)
				myReceiptPrinting.WriteLine(string.Format("Package Start On : {0}", 
					ACMS.Convert.ToDateTime(memberPackageTable.Rows[0]["dtStartDate"]).ToString("dd/MM/yyyy")));
			
			if (memberPackageTable.Rows[0]["dtExpiryDate"] != DBNull.Value)
				myReceiptPrinting.WriteLine(string.Format("Package Expiry Date : {0}", 
					ACMS.Convert.ToDateTime(memberPackageTable.Rows[0]["dtExpiryDate"]).ToString("dd/MM/yyyy")));
			
			if (DateTime.Compare(ACMS.Convert.ToDBDateTime(memberPackageTable.Rows[0]["dtStartDate"]),DateTime.Today.Date)==0)		
				//if (memberPackageTable.Rows[0]["dtExpiryDate"] == DBNull.Value)
			{
				TblClassAttendance classAttendance = new TblClassAttendance();
				classAttendance.NPackageID = nPackageID;
				int totalClassAttend = classAttendance.SelectAllWnPackageIDLogic().Rows.Count;
				if (totalClassAttend == 1)
				{
					myReceiptPrinting.WriteLine("Package Has Been Activated.");
					bClassPrint = true;	
				}
			}

			//Print Day To Expiry
			System.TimeSpan timeSpan = expiryDate.Date.Subtract(DateTime.Today.Date);
			if (timeSpan.Days <= nDaysToExpire)
			{
				myReceiptPrinting.WriteLine(string.Format("Days To Expiry : {0}", timeSpan.Days));
				bClassPrint = true;	
			}

			//Print Member Package Balance
			int balance = ACMS.Convert.ToInt32(memberPackageTable.Rows[0]["Balance"]);
			if (balance <= nClassLeft)
			{
				myReceiptPrinting.WriteLine(string.Format("Balance Visit : {0} ", balance));
				bClassPrint = true;		
			}
			
			// Check Member Outstanding Receipt
			TblReceipt receipt = new TblReceipt();
			Decimal mTotalOutstanding = 0;
			object obj= receipt.GetOutStandingBalance(strMembershipID);
			
			if (obj != null)
			{
				mTotalOutstanding = (decimal)obj;
				mTotalOutstanding = decimal.Round(mTotalOutstanding, 2);
			}
			
			if (mTotalOutstanding > 0)
			{
				myReceiptPrinting.WriteLine("Outstanding Cash Bill Check.");
				bClassPrint = true;	
			}

			if (memberPackageTable.Rows[0]["strRemarks"].ToString().Length > 0)
			{
				myReceiptPrinting.WriteLine("Refer To Member Package's Remark.");
				bClassPrint = true;	
			}
			
			if (ACMS.Convert.ToDateTime(memberTable.Rows[0]["DtDOB"]).Date == DateTime.Today.Date)
			{
				myReceiptPrinting.WriteLine("");
				myReceiptPrinting.WriteLine(string.Format("Happy Birthday To {0}.", 
					memberTable.Rows[0]["strMemberName"].ToString()));
				bClassPrint = true;	
			}

			//	myReceiptPrinting.Close;
			if (bClassPrint == true)
			{
				myReceiptPrinting.Print();
			}
			else myReceiptPrinting.DelFile();
		

		}
		

		public void DeleteClassAttendance(int nPackageID, int nAttendanceID, string remark)
		{
			MemberPackage memberPackage = new MemberPackage();
			memberPackage.DeleteClassAttendance(nPackageID, nAttendanceID, remark);
		}

		public DataTable ViewReservation(int nClassInstanceID)
		{
			TblClassAttendance classAttendance = new TblClassAttendance();
			return classAttendance.GetReservation(nClassInstanceID);
		}

        public void AddWaitingList(string strMembershipID, int nPackageID, int nClassInstanceID, bool needToVerifyMemberPackage)
        {
            TblClassInstance classInstance = new TblClassInstance();
            classInstance.NClassInstanceID = nClassInstanceID;
            classInstance.SelectOne();

            TblWaitingList wl = new TblWaitingList();

            DateTime classDate = new DateTime(classInstance.DtDate.Value.Year, classInstance.DtDate.Value.Month, classInstance.DtDate.Value.Day,
                classInstance.DtStartTime.Value.Hour, classInstance.DtStartTime.Value.Minute, classInstance.DtStartTime.Value.Second);

            if (DateTime.Today > classDate)
                throw new Exception("You are not allow to add waiting list to the previous day class.");

            if (needToVerifyMemberPackage)
            {
                if (!VerifyMemberPackageAllowCertainClass(nPackageID, classInstance.StrClassCode.Value))
                {                    
                    DialogResult result = MessageBox.Show("The package you wish to use is not allow to attend the class. Do you still want to proceed. \n " +
                        "(An unlinked record will be create if you click yes) ", "Warning", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        MemberPackage.CreateUnlinkedMemberPackage(strMembershipID, ref nPackageID);
                    }
                    else
                    {
                        return;
                    }
                }
            }

            //Prompt Package going to expiry
            //Prompt Remaining class

            wl.NClassInstanceID = nClassInstanceID;
            wl.StrMembershipID = strMembershipID;                        
            wl.DtDate = classInstance.DtDate.Value;
            wl.DtRequestDate = DateTime.Today.Date;
            wl.DtStartTime = classInstance.DtStartTime.Value;
            wl.DtEndTime = classInstance.DtEndTime.Value;
            wl.StrBranchCode = User.BranchCode;            
            wl.NStatusID = 0;
            wl.NPackageID = nPackageID;
            wl.StrRemarks = "";
            wl.StrType = "System";          
            wl.Insert();
        }

		public void NormalReserve(string strMembershipID, int nPackageID, int nClassInstanceID, bool needToVerifyMemberPackage)
		{
			TblClassInstance classInstance = new TblClassInstance();
			classInstance.NClassInstanceID = nClassInstanceID;
			classInstance.SelectOne(); 

			TblClassAttendance classAttendance = new TblClassAttendance();

			DateTime classDate = new DateTime(classInstance.DtDate.Value.Year, classInstance.DtDate.Value.Month, classInstance.DtDate.Value.Day, 
				classInstance.DtStartTime.Value.Hour, classInstance.DtStartTime.Value.Minute, classInstance.DtStartTime.Value.Second);

			if (DateTime.Today > classDate)
				throw new Exception("You are not allow to reserve the previous day class.");

			if (classAttendance.IsReservedThisClass(nClassInstanceID, strMembershipID))
			{
				throw new Exception("You have reserved this class.");
			}

			if (classAttendance.GetReservation(nClassInstanceID).Rows.Count > ACMS.Convert.ToInt32(classInstance.NMaxNo))
			{
				throw new Exception("Class is fully reserved by members. Please try again later.");
			}
			
			if (needToVerifyMemberPackage)
			{
				if (!VerifyMemberPackageAllowCertainClass(nPackageID, classInstance.StrClassCode.Value))
				{
					//throw new Exception("The package you wish to use is not allow to attend the class. Please use other package.");
					DialogResult result = MessageBox.Show("The package you wish to use is not allow to attend the class. Do you still want to reserve it. \n " + 
						"(An unlinked record will be create if you click yes) ", "Warning",MessageBoxButtons.YesNo);
				
					if (result == DialogResult.Yes)
					{
						MemberPackage.CreateUnlinkedMemberPackage(strMembershipID, ref nPackageID);
					}
					else
					{
						return;
					}
				}
			}
			
//			if (!VerifyMemberPackageAllowCertainClass(nPackageID, classInstance.StrClassCode.Value))
//				throw new Exception("The package you wish to use is not allow to reserve the class. Please use other package.");
			
			
			//Prompt Package going to expiry
			//Prompt Remaining class

			classAttendance.NClassInstanceID = nClassInstanceID;
			classAttendance.StrMembershipID = strMembershipID;
			classAttendance.NEmployeeID = User.EmployeeID;
			classAttendance.NReservedByID = User.EmployeeID;
			classAttendance.FUOBBooking = System.Data.SqlTypes.SqlBoolean.False;
			classAttendance.DtDate = classInstance.DtDate.Value;
			classAttendance.DtReservationDate = DateTime.Today.Date;
            classAttendance.DtStartTime = Convert.ToDateTime(classInstance.DtDate.Value.ToString("yyyy-MM-dd")+" "+ classInstance.DtStartTime.Value.ToString("H:mm:ss"));
            classAttendance.DtEndTime = Convert.ToDateTime(classInstance.DtDate.Value.ToString("yyyy-MM-dd") + " " + classInstance.DtEndTime.Value.ToString("H:mm:ss"));
			classAttendance.StrBranchCode = User.BranchCode;
			classAttendance.DtLastEditDate = DateTime.Now;
			classAttendance.NStatusID = 0;
			classAttendance.NPackageID = nPackageID;
			classAttendance.Insert();

            TblBranch sqlBranch = new TblBranch();
            TblClass sqlClass = new TblClass();

            sqlBranch.StrBranchCode = classAttendance.StrBranchCode.ToString();
            sqlBranch.SelectOne();

            sqlClass.StrClassCode = classInstance.StrClassCode;
            sqlClass.SelectOne();

            if (isMobileAppUser(strMembershipID))
                PushNotification(strMembershipID, "Your class booking for " + sqlClass.StrDescription.ToString() + " at " + sqlBranch.StrBranchName.ToString() + " at " + classAttendance.DtStartTime.Value.ToString("h.mmtt") + " on " + classAttendance.DtStartTime.Value.ToString("dd MMM") + " has been confirmed.");                            
		}

        private bool isMobileAppUser(string strMembershipID)
        {
            DataTable dt;

            string strSQL = "SELECT * FROM openquery(MA, 'SELECT * FROM amore_mobileapp.app_users where user_id=''" + strMembershipID + "''') ";
            DataSet _ds = new DataSet();
            SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA", _ds, new string[] { "table" }, new SqlParameter("@strSQL", strSQL));
            dt = _ds.Tables["table"];

            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }

		public void UOBReserve()
		{}

        public void UpdateWaitingListToTransfered(int nWaitingListID)
        {
            TblWaitingList wl = new TblWaitingList();
            wl.NWaitingListID = nWaitingListID;
            wl.SelectOne();
            wl.NStatusID = 1;
            wl.Update();            
        }
        public void DeleteWaitingList(int nWaitingListID)
        {
            TblWaitingList wl = new TblWaitingList();
            wl.NWaitingListID = nWaitingListID;
            wl.SelectOne();
            wl.NStatusID = 3;
            wl.Update();            
        }

		public void CancelReservation(int nAttendanceID)
		{
			TblCompany comp = new TblCompany();
			DataTable table = comp.SelectAll();
			int nhourBeforeToDelete = 0;
			
			if (table != null && table.Rows.Count>0)
			{
				nhourBeforeToDelete = ACMS.Convert.ToInt32(table.Rows[0]["nCancelBookingLimit"]);
			}

			TblClassAttendance classAttendance = new TblClassAttendance();
			classAttendance.NAttendanceID = nAttendanceID;
			classAttendance.SelectOne();

			TblClassInstance classInstance = new TblClassInstance();
			classInstance.NClassInstanceID = classAttendance.NClassInstanceID.Value;
			classInstance.SelectOne();

			if (DateTime.Today.Date > classInstance.DtDate.Value.Date)
				return;
			else if (DateTime.Today.Date == classInstance.DtDate.Value.Date)
			{
//				if (oUser.DateTime.Now.Hour + nhourBeforeToDelete > classAttendance.DtStartTime.Value.Hour)
//					throw new Exception("You are not allow to cancel this reservation because you have passed the time period that allow you to cancel the reservation.");
//				else
//				{
					classAttendance.NStatusID = 3;
					classAttendance.Update();
				
				//}
			}
			else
			{
				try
				{
					classAttendance.NStatusID = 3;
					classAttendance.Update();
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		public void PrintReservation()
		{}
		
		public static bool VerifyMemberPackageAllowCertainClass(int nPackageID, string strClassCode)
		{
			TblClassInstance clsInstance = new TblClassInstance();

			string cmdText = " Select Count (*) from tblPackageClass A  " + 
							" inner join tblMemberPackage B on A.strPackageCode = B.strPackageCode " + 
							" Where B.nPackageID = @nPackageID and A.strClassCode = @strClassCode";

			object obj = clsInstance.ExecuteScalar(cmdText, new string[] {"@nPackageID", "@strClassCode"}, new object[] {nPackageID, strClassCode});
			if (obj != null)
			{
				Int32 r = (Int32) obj;
				if (r > 0)
					return true;
				else
					return false;
			}
			else
				return true;
		}

        public bool VerifyMemberPackageAllowClass(int nPackageID, int nClassInstanceID)
        {
            TblClassInstance clsInstance = new TblClassInstance();

            string cmdText = " Select Count (*) from tblPackageClass A  " +
                            " inner join tblMemberPackage B on A.strPackageCode = B.strPackageCode " +
                            " inner join tblClassInstance C on A.strClassCode = C.strClassCode " +
                            " inner join tblPackageUseBranch D on A.strPackageCode = D.strPackageCode " +
                            " Where B.nPackageID = @nPackageID and C.nClassInstanceID = @nClassInstanceID and D.strBranchCode=@strBranchCode ";

            object obj = clsInstance.ExecuteScalar(cmdText, new string[] { "@nPackageID", "@nClassInstanceID", "@strBranchCode" }, new object[] { nPackageID, nClassInstanceID, User.BranchCode });
            if (obj != null)
            {
                Int32 r = (Int32)obj;
                if (r > 0)
                    return true;
                else
                    return false;
            }
            else
                return true;
        }

        public bool VerifyMemberPackageAllowGym(int nPackageID)
        {
            TblClassInstance clsInstance = new TblClassInstance();

            string cmdText = " Select Count (*) from tblPackageClass A  " +
                            " inner join tblMemberPackage B on A.strPackageCode = B.strPackageCode " +
                            " inner join tblPackageUseBranch D on A.strPackageCode = D.strPackageCode " +
                            " Where B.nPackageID = @nPackageID and A.strClassCode = 'GYM' and D.strBranchCode=@strBranchCode ";

            object obj = clsInstance.ExecuteScalar(cmdText, new string[] { "@nPackageID", "@strBranchCode" }, new object[] { nPackageID, User.BranchCode });
            if (obj != null)
            {
                Int32 r = (Int32)obj;
                if (r > 0)
                    return true;
                else
                    return false;
            }
            else
                return true;
        }

		private decimal GetCommission(int nCommissionTypeID, int nInstructorTypeID)
		{
			string cmdText = "Select * From tblInstructorTypeCommission where nCommissionTypeID = @nCommissionTypeID And nInstructorTypeID = @nInstructorTypeID";
			//myClassInstance.LoadData(cmdText, new string
			TblInstructorCommission commission = new TblInstructorCommission();
			DataTable table = commission.LoadData(cmdText, new string[] {"@nCommissionTypeID", "@nInstructorTypeID"}, new object[]{nCommissionTypeID, nInstructorTypeID});
			if (table != null && table.Rows.Count > 0)
			{
				return ACMS.Convert.ToDecimal(table.Rows[0]["mCommissionAmount"]);
			}
			return 0;
		}

		public void PrintClassAttendance(DataTable sourceTable)
		{
			int nClassInstanceID = ACMS.Convert.ToInt32(sourceTable.Rows[0]["nClassInstanceID"]);

			DataTable table = GetClassAttendance(nClassInstanceID);

			string membershipID = "";
			foreach (DataRow r in table.Rows)
			{
				membershipID += r["strMembershipID"].ToString() + ",";
			}

			if (!sourceTable.Columns.Contains("MembershipIDList"))
			{
				DataColumn colMembershipIDList = new DataColumn("MembershipIDList", typeof(string));
				sourceTable.Columns.Add(colMembershipIDList);
			}

			if (!sourceTable.Columns.Contains("strReplacementVerifyName"))
			{
				DataColumn colstrReplacementVerifyName = new DataColumn("strReplacementVerifyName", typeof(string));
				sourceTable.Columns.Add(colstrReplacementVerifyName);
			}

			string strReplacementVerifyName = "";
			if (sourceTable.Rows[0]["nReplacementVerifyID"] != DBNull.Value &&
				sourceTable.Rows[0]["nReplacementVerifyID"].ToString() != "")
			{
				TblEmployee employee = new TblEmployee();
				employee.NEmployeeID = ACMS.Convert.ToInt32(sourceTable.Rows[0]["nReplacementVerifyID"]);
				employee.SelectOne();
				strReplacementVerifyName = employee.StrEmployeeName.Value;
			}	
			sourceTable.Rows[0]["strReplacementVerifyName"] = strReplacementVerifyName;
			sourceTable.Rows[0]["MembershipIDList"] = membershipID;

			ACMSLogic.Report.ClassAttendanceReport report = new ACMSLogic.Report.ClassAttendanceReport();
			report.DataSource = sourceTable;
			report.CreateDataBindings();
			
			report.Print();
		}

		public static void CreateClassInstance()
		{
				TblClassInstance classInstance = new TblClassInstance();
				TblClassSchedule classSchedule = new TblClassSchedule();
			
				classInstance.StrClassCode = "GYM";
				DataTable temptable = classInstance.SelectAllWstrClassCodeLogic();
				if (temptable == null || temptable.Rows.Count == 0)
				{
                    TblInstructorTypeCommission dummyInstructorTypeCommission = new TblInstructorTypeCommission();
                    DataTable dummyTable = dummyInstructorTypeCommission.SelectAll();

                    if (dummyTable.Rows.Count == 0)
                        throw new Exception("Please insert a record in InstructorTypeCommission table.");

					
					classInstance.StrClassCode = "GYM";
					classInstance.NPermanentInstructorID = User.EmployeeID;
					classInstance.NCommissionTypeID = ACMS.Convert.ToInt32(dummyTable.Rows[0]["nCommissionTypeID"]);
					classInstance.StrBranchCode = User.BranchCode;
					classInstance.DtDate = DateTime.Today.Date;
					classInstance.DtEndTime = DateTime.Now;
					classInstance.DtStartTime = DateTime.Now;
					//classInstance.nClassScheduleID = 0;
					classInstance.Insert();
				}

				DateTime dateNow = System.DateTime.Now;

				for (double i = 0; i < 2; i++)
				{
					DateTime date;
					if (i == 0)
						date = DateTime.Today.Date;
					else
					{
						double dayToAdd = i * 7;
						date = dateNow.AddDays(dayToAdd).Date;
					}
					int nDay = ConvertDateToNDay(date);

					DataTable table = classSchedule.SelectAllWnDay(nDay, User.BranchCode);

					if (table == null || table.Rows.Count == 0)
						continue;
					else
					{
						foreach (DataRow r in table.Rows)
						{
							//DateTime newdate = System.DateTime.(date.Year, date.Month, date.Year);
							//DateTime dt= System.Convert.ToDateTime(date.ToString("dd/MM/yyyy"));
						
							DateTime dtEndTime = ACMS.Convert.ToDateTime(r["dtEndTime"]);
							DateTime dtStartTime = ACMS.Convert.ToDateTime(r["dtStartTime"]);
							string strClassCode = r["strClassCode"].ToString();
							int nHallNo = ACMS.Convert.ToInt32(r["nHallNo"]);
						
							bool createdInstance = classInstance.HaveClassInstance(date, 
								dtEndTime, dtStartTime, strClassCode, nHallNo, User.BranchCode);
						
							if (!createdInstance)
							{
								classInstance.DtDate = date;
								classInstance.DtEndTime = ACMS.Convert.ToDateTime(r["dtEndTime"]);
								classInstance.DtStartTime = ACMS.Convert.ToDateTime(r["dtStartTime"]);
								classInstance.StrClassCode = ACMS.Convert.ToSqlString(r["strClassCode"]);
								classInstance.NHallNo = ACMS.Convert.ToSqlInt32(r["nHallNo"]);
								classInstance.NPermanentInstructorID = ACMS.Convert.ToSqlInt32(r["nInstructorID"]);
								classInstance.FFree = ACMS.Convert.ToBoolean(r["fFree"]);
								classInstance.FPeak = ACMS.Convert.ToBoolean(r["fPeak"]);
								classInstance.FAllowStudentOnPeak = ACMS.Convert.ToBoolean(r["fAllowStudentOnPeak"]);
								classInstance.FReservation = ACMS.Convert.ToBoolean(r["fReservation"]);
								classInstance.NMaxNo = ACMS.Convert.ToSqlInt32(r["nMaxNo"]);
								classInstance.FAllowUOBBooking = ACMS.Convert.ToBoolean(r["fAllowUOBBooking"]);
								classInstance.NCommissionTypeID = ACMS.Convert.ToSqlInt32(r["nCommissionTypeID"]);
								classInstance.StrBranchCode = User.BranchCode;
								classInstance.FCancelled = System.Data.SqlTypes.SqlBoolean.False;
								#region ====== Added by Albert ======
								/*To insert class schedule id while creating class instance.*/
								classInstance.nClassScheduleID = ACMS.Convert.ToSqlInt32(r["nClassScheduleID"]);
								#endregion
								classInstance.Insert();
								
								}
						}
					}
				}

		}

		public static void CreateClassInstance(System.DayOfWeek dayOfWeek)
		{
			
			TblClassInstance classInstance = new TblClassInstance();
			TblClassSchedule classSchedule = new TblClassSchedule();

			DateTime dateNow = System.DateTime.Today.Date;
			
			if (dateNow.DayOfWeek != dayOfWeek)
			{
				for (double i = 1; i < 8; i++)
				{
					dateNow = dateNow.AddDays(1).Date;
					if (dateNow.DayOfWeek == dayOfWeek)
						break;
				}
			}

			for (double i = 0; i < 2; i++)
			{
				DateTime date;
				if (i == 0)
					date = dateNow;
				else
				{
					double dayToAdd = i * 7;
					date = dateNow.AddDays(dayToAdd).Date;
				}
				int nDay = ConvertDateToNDay(date);

				DataTable table = classSchedule.SelectAllWnDay(nDay, User.BranchCode);

				if (table == null || table.Rows.Count == 0)
					continue;
				else
				{
					foreach (DataRow r in table.Rows)
					{
						//DateTime newdate = System.DateTime.(date.Year, date.Month, date.Year);
						//DateTime dt= System.Convert.ToDateTime(date.ToString("dd/MM/yyyy"));
						
						DateTime dtEndTime = ACMS.Convert.ToDateTime(r["dtEndTime"]);
						DateTime dtStartTime = ACMS.Convert.ToDateTime(r["dtStartTime"]);
						string strClassCode = r["strClassCode"].ToString();
						int nHallNo = ACMS.Convert.ToInt32(r["nHallNo"]);
						
						bool createdInstance = classInstance.HaveClassInstance(date, 
							dtEndTime, dtStartTime, strClassCode, nHallNo, User.BranchCode);
						
						if (!createdInstance)
						{
							classInstance.DtDate = date;
							classInstance.DtEndTime = ACMS.Convert.ToDateTime(r["dtEndTime"]);
							classInstance.DtStartTime = ACMS.Convert.ToDateTime(r["dtStartTime"]);
							classInstance.StrClassCode = ACMS.Convert.ToSqlString(r["strClassCode"]);
							classInstance.NHallNo = ACMS.Convert.ToSqlInt32(r["nHallNo"]);
							classInstance.NPermanentInstructorID = ACMS.Convert.ToSqlInt32(r["nInstructorID"]);
							classInstance.FFree = ACMS.Convert.ToBoolean(r["fFree"]);
							classInstance.FPeak = ACMS.Convert.ToBoolean(r["fPeak"]);
							classInstance.FAllowStudentOnPeak = ACMS.Convert.ToBoolean(r["fAllowStudentOnPeak"]);
							classInstance.FReservation = ACMS.Convert.ToBoolean(r["fReservation"]);
									classInstance.FPeak = ACMS.Convert.ToBoolean(r["fPeak"]);
							classInstance.FAllowStudentOnPeak = ACMS.Convert.ToBoolean(r["fAllowStudentOnPeak"]);
							classInstance.FReservation = ACMS.Convert.ToBoolean(r["fReservation"]);
							classInstance.NMaxNo = ACMS.Convert.ToSqlInt32(r["nMaxNo"]);
							classInstance.FAllowUOBBooking = ACMS.Convert.ToBoolean(r["fAllowUOBBooking"]);
							classInstance.NCommissionTypeID = ACMS.Convert.ToSqlInt32(r["nCommissionTypeID"]);
							classInstance.StrBranchCode = User.BranchCode;
							classInstance.FCancelled = System.Data.SqlTypes.SqlBoolean.False;
							classInstance.Insert();
						}
					}
				}
			}
		}
		
		public static System.DayOfWeek ConvertNDayToDayOfWeek(int nDay)
		{
			if (nDay == 1)
			{
				return System.DayOfWeek.Monday;
			}
			else if (nDay == 2)
			{
				return System.DayOfWeek.Tuesday;
			}
			else if (nDay == 3)
			{
				return System.DayOfWeek.Wednesday;
			}
			else if (nDay == 4)
			{
				return System.DayOfWeek.Thursday;
			}
			else if (nDay == 5)
			{
				return System.DayOfWeek.Friday;
			}
			else if (nDay == 6)
			{
				return System.DayOfWeek.Saturday;
			}
			else
			{
				return System.DayOfWeek.Sunday;
			}
		}	

		public static int ConvertDateToNDay(DateTime date)
		{
			if (date.DayOfWeek == System.DayOfWeek.Monday)
			{
				return 1;
			}
			else if (date.DayOfWeek == System.DayOfWeek.Tuesday)
			{
				return 2;
			}
			else if (date.DayOfWeek == System.DayOfWeek.Wednesday)
			{
				return 3;
			}
            else if (date.DayOfWeek == System.DayOfWeek.Thursday)
            {
                return 4;
            }
            else if (date.DayOfWeek == System.DayOfWeek.Friday)
            {
                return 5;
            }
            else if (date.DayOfWeek == System.DayOfWeek.Saturday)
            {
                return 6;
            }
            else
            {
                return 0;
            }
        }
    }
}
