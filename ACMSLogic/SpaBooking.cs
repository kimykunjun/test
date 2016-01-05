using System;
using System.Data;
using System.Data.SqlClient;
using ACMSDAL;

namespace ACMSLogic
{
	/// <summary>
	/// Summary description for SpaBooking.
	/// </summary>
	public class SpaBooking
	{
		private TblServiceSession myServiceSession;
		//private DataTable myDataTable;

		public SpaBooking()
		{
			//
			// TODO: Add constructor logic here
			//
			Init();
		}
		
//		public DataTable Table
//		{
//			get { return myDataTable; }
//		}

		public void Save(DataTable table, bool isBooking)
		{
			DataRow masterRow = table.Rows[0];
			int nPackageID = ACMS.Convert.ToInt32(masterRow["nPackageID"]);
			string strServiceCode = masterRow["strServiceCode"].ToString();
				
			if (!isBooking)
			{
				if (!VerifyMemberPackageAllowCertainService(nPackageID, strServiceCode))
					throw new Exception("The package you wish to use is not allow to use this service. Please use other package.");
			}

			int nEmployeeID = ACMS.Convert.ToInt32(masterRow["nServiceEmployeeID"]);
			DateTime dtDate = ACMS.Convert.ToDateTime(masterRow["dtDate"]);
			DateTime dtStartTime = ACMS.Convert.ToDateTime(masterRow["dtStartTime"]);
			DateTime dtEndTime = ACMS.Convert.ToDateTime(masterRow["dtEndTime"]);
			string strBranchCode = masterRow["strBranchCode"].ToString();
			bool isWaitingList = ACMS.Convert.ToInt32(masterRow["nStatusID"]) == 3;

			if (!isWaitingList)
			{
				if (TherapistIsAvailableToBook(nEmployeeID, dtDate, dtStartTime, dtEndTime, strBranchCode))
				{
					myServiceSession.SaveData(table);
				}
			}
			else
			{
				myServiceSession.SaveData(table);
			}
		}

		public void SaveUOBBooking(DataTable table)
		{
			
			DataRow masterRow = table.Rows[0];
			int nPackageID = ACMS.Convert.ToInt32(masterRow["nPackageID"]);
			string strServiceCode = masterRow["strServiceCode"].ToString();
			int nWeekDayOffPeekMax = 0, nWeekDayPeekMax=0, nWeekEndOffPeekMax = 0, nWeekEndPeekMax = 0;
			
			if (!IsBranchAllowUOBBooking(User.BranchCode, ref nWeekDayOffPeekMax, ref nWeekDayPeekMax, ref nWeekEndOffPeekMax, ref nWeekEndPeekMax))
			{
				throw new Exception(string.Format("Branch {0} is not allow UOB Booking.", User.BranchCode));
			}

			if (!VerifyMemberPackageAllowCertainService(nPackageID, strServiceCode))
				throw new Exception("The package you wish to use is not allow to use this service. Please use other package.");
			
			int nEmployeeID = ACMS.Convert.ToInt32(masterRow["nServiceEmployeeID"]);
			string strMembershipID = masterRow["strMembershipID"].ToString();
			DateTime dtDate = ACMS.Convert.ToDateTime(masterRow["dtDate"]);
			DateTime dtStartTime = ACMS.Convert.ToDateTime(masterRow["dtStartTime"]);
			DateTime dtEndTime = ACMS.Convert.ToDateTime(masterRow["dtEndTime"]);
			string strBranchCode = masterRow["strBranchCode"].ToString();
			
			if (IsMemberExceedUOBBookingThisMonth(strMembershipID, dtDate))
				throw new Exception(string.Format("This member have exceeded the limit that allow for month {0}.", ACMS.Convert.ToMonth(dtDate.Month)));
			
			bool isWeekDay = true;
			if (dtDate.DayOfWeek == System.DayOfWeek.Saturday || dtDate.DayOfWeek == System.DayOfWeek.Sunday)
				isWeekDay = false;
			
			if (isWeekDay)
			{
				int totalServiceSession = 0; 
				bool isPeak = IsPeakHour(dtDate, dtStartTime, dtEndTime, isWeekDay, strServiceCode, ref totalServiceSession);
				if (isPeak)
				{
					if (totalServiceSession >= nWeekDayPeekMax)
						throw new Exception("The UOB Booking is been fully booked.");

				}
				else
				{
					if (totalServiceSession >= nWeekDayOffPeekMax)
						throw new Exception("The UOB Booking is been fully booked.");
				}
			}
			else
			{
				int totalServiceSession = 0; 
				bool isPeak = IsPeakHour(dtDate, dtStartTime, dtEndTime, isWeekDay, strServiceCode, ref totalServiceSession);
				if (isPeak)
				{
					if (totalServiceSession >= nWeekDayPeekMax)
						throw new Exception("The UOB Booking is been fully booked.");

				}
				else
				{
					if (totalServiceSession >= nWeekDayOffPeekMax)
						throw new Exception("The UOB Booking is been fully booked.");
				}
			}

			Save(table, true);
		}

		private DataTable GetServiceSessionBaseTime(string strBranchCode, string strServiceCode, 
			DateTime dtDate, DateTime startTime, DateTime endTime)
		{
			DataTable table = myServiceSession.GetServiceSessionBaseTime(strBranchCode, strServiceCode, 
				dtDate, startTime, endTime);
			return table;
		}


		public bool IsPeakHour(DateTime dtDate, DateTime dtStartTime, DateTime dtEndTime, 
				bool isWeekDay, string serviceCode, ref int totalServiceSession)
		{
			TblCompany comp = new TblCompany();
			DataTable table = comp.SelectAll();
			DataRow masterRow = table.Rows[0];
			TimeSpan dtStartTimeSpan = dtStartTime.TimeOfDay;
			TimeSpan dtEndTimeSpan = dtEndTime.TimeOfDay;

			if (isWeekDay)
			{
				if (masterRow["DtUOBWeekdayPeakStart"] == DBNull.Value || 
					masterRow["DtUOBWeekdayPeakEnd"] == DBNull.Value)
					return false;
				
				DateTime weekDayPeakStart = ACMS.Convert.ToDateTime(masterRow["DtUOBWeekdayPeakStart"]);
				DateTime weekDayPeakEnd = ACMS.Convert.ToDateTime(masterRow["DtUOBWeekdayPeakEnd"]);

				DateTime startTime = new DateTime(dtDate.Year, dtDate.Month, dtDate.Day, 
					weekDayPeakStart.Hour, weekDayPeakStart.Minute, weekDayPeakStart.Second);

				
				DateTime endTime = new DateTime(dtDate.Year, dtDate.Month, dtDate.Day, 
					weekDayPeakEnd.Hour, weekDayPeakEnd.Minute, weekDayPeakEnd.Second);

				totalServiceSession = 0;
				DataTable serviceSessionTable = GetServiceSessionBaseTime(User.BranchCode, serviceCode, dtDate, startTime, endTime);
				if (serviceSessionTable != null && serviceSessionTable.Rows.Count > 0)
					totalServiceSession = serviceSessionTable.Rows.Count;
				

				TimeSpan weekDayPeakStartTimeSpan = weekDayPeakStart.TimeOfDay;
				TimeSpan weekDayPeakEndTimeSpan = weekDayPeakEnd.TimeOfDay;
				
				if (weekDayPeakStartTimeSpan >= dtStartTimeSpan &&
					weekDayPeakEndTimeSpan <= dtStartTimeSpan)
					return true;
				else if (weekDayPeakStartTimeSpan >= dtEndTimeSpan &&
					weekDayPeakEndTimeSpan <= dtEndTimeSpan)
					return true;
				else
					return false;
				
			}
			else
			{
				DateTime weekendPeakStart = ACMS.Convert.ToDateTime(masterRow["DtUOBWeekendPeakStart"]);
				DateTime weekendPeakEnd = ACMS.Convert.ToDateTime(masterRow["DtUOBWeekendPeakEnd"]);

				DateTime startTime = new DateTime(dtDate.Year, dtDate.Month, dtDate.Day, 
					weekendPeakStart.Hour, weekendPeakStart.Minute, weekendPeakStart.Second);

				
				DateTime endTime = new DateTime(dtDate.Year, dtDate.Month, dtDate.Day, 
					weekendPeakEnd.Hour, weekendPeakEnd.Minute, weekendPeakEnd.Second);

				totalServiceSession = 0;
				DataTable serviceSessionTable = GetServiceSessionBaseTime(User.BranchCode, serviceCode, dtDate, startTime, endTime);
				if (serviceSessionTable != null && serviceSessionTable.Rows.Count > 0)
					totalServiceSession = serviceSessionTable.Rows.Count;


				TimeSpan weekendPeakStartTimeSpan = ACMS.Convert.ToDateTime(masterRow["DtUOBWeekendPeakStart"]).TimeOfDay;
				TimeSpan weekendPeakEndTimeSpan = ACMS.Convert.ToDateTime(masterRow["DtUOBWeekendPeakEnd"]).TimeOfDay;
			
				if (weekendPeakStartTimeSpan >= dtStartTimeSpan &&
					weekendPeakEndTimeSpan <= dtStartTimeSpan)
					return true;
				else if (weekendPeakStartTimeSpan >= dtEndTimeSpan &&
					weekendPeakEndTimeSpan <= dtEndTimeSpan)
					return true;
				else
					return false;
			}
		}

		public static bool IsMemberExceedUOBBookingThisMonth(string strMembershipID, DateTime uobBookingDate)
		{
			TblCompany comp = new TblCompany();
			DataTable table = comp.SelectAll();
			DataRow compMasterRow = table.Rows[0];

			int nUOBMonthlyBooking = ACMS.Convert.ToInt32(compMasterRow["nUOBMonthlyBooking"]);
			TblServiceSession serviceSession = new TblServiceSession();
			DataTable uobBookingTable = serviceSession.GetUOBBookingServiceSessionBaseMembershipID(strMembershipID);
			
			int uobBookingMade = 0;
			
			if (uobBookingTable != null && uobBookingTable.Rows.Count > 0)
			{
				foreach (DataRow r in uobBookingTable.Rows)
				{
					DateTime serviceSessionDate = ACMS.Convert.ToDateTime(r["dtDate"]);
					if (serviceSessionDate != DateTime.MinValue)
					{
						if (serviceSessionDate.Month == uobBookingDate.Month 
							&& serviceSessionDate.Year == uobBookingDate.Year)
							uobBookingMade++;
					}
				}
			}

			return uobBookingMade >= nUOBMonthlyBooking;
		}

		public void MarkService(int nSessionID, DateTime dtDate, DateTime startTime,  DateTime endTime,
			string strBranchCode, int nPackageID, string strServiceCode, 
			int nEmployeeInChargeID, string remark)
		{
			MemberPackage memberPackage = new MemberPackage();
			memberPackage.UpdateServiceSession(nSessionID, dtDate, startTime, endTime, strBranchCode, nPackageID, 
				strServiceCode, nEmployeeInChargeID, remark, 5, false);
		}

		public static bool VerifyMemberPackageAllowCertainService(int nPackageID, string strServiceCode)
		{
			string cmdText = " Select Count (*) from tblPackageService A  " + 
				" inner join tblMemberPackage B on A.strPackageCode = B.strPackageCode " + 
				" Where B.nPackageID = @nPackageID and A.strServiceCode = @strServiceCode";
			
			TblServiceSession serviceSession = new TblServiceSession();
			object obj = serviceSession.ExecuteScalar(cmdText, new string[] {"@nPackageID", "@strServiceCode"}, new object[] {nPackageID, strServiceCode});
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
		
		public DataTable NewNormalSpaBooking()
		{
			myServiceSession.NSessionID = -1;
			DataTable table = myServiceSession.SelectOne();
			DataRow row = table.NewRow();
			row["dtDate"] = ACMS.Convert.ToDateTime(System.DateTime.Today);
			row["dtLastEditDate"] = ACMS.Convert.ToDateTime(System.DateTime.Today);
			row["dtStartTime"] = ACMS.Convert.ToDateTime(System.DateTime.Now);
			row["dtEndTime"] = ACMS.Convert.ToDateTime(System.DateTime.Now.AddMinutes(15));
			row["nEmployeeID"] = User.EmployeeID;
			row["strBranchCode"] = User.BranchCode;
			row["nStatusID"] = 2; 
			row["nBookedByID"] = User.EmployeeID;
			row["fUOBBooking"] = 0;

			table.Rows.Add(row);

			return table;
		}

		public DataTable NewUOBSpaBooking()
		{
			DataTable table = NewNormalSpaBooking();
			table.Rows[0]["fUOBBooking"] = 1;
			return table;
		}

		public bool DeleteBooking(int nSessionID)
		{
			myServiceSession.NSessionID = nSessionID;
			myServiceSession.SelectOne();

			if (myServiceSession.NStatusID.Value == 5)
				throw new Exception("You are not allow to delete marked service.");

			myServiceSession.NStatusID = 7; 
			myServiceSession.DtLastEditDate = DateTime.Now;
			myServiceSession.NEmployeeID = ACMSLogic.User.EmployeeID;

			TblAudit audit = new TblAudit();
			audit.DtDate = DateTime.Today;
			audit.NAuditTypeID = AuditTypeID.Service;
			audit.NEmployeeID = ACMSLogic.User.EmployeeID;
			audit.StrAuditEntry = "Cancel Booking " + nSessionID.ToString();
			audit.StrReference = nSessionID.ToString();

			ACMSDAL.ConnectionProvider connProvider = new ConnectionProvider();

			try
			{
				
				myServiceSession.MainConnectionProvider = connProvider;
				audit.MainConnectionProvider = connProvider;
				connProvider.OpenConnection();
				connProvider.BeginTransaction("CancelBooking");
				myServiceSession.Update();
				audit.Insert();
				connProvider.CommitTransaction();
				return true;
			}
			catch (Exception)
			{
				connProvider.RollbackTransaction("CancelBooking");
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
				myServiceSession.MainConnactionIsCreatedLocal = true;
				audit.MainConnactionIsCreatedLocal = true;
			}

		}


		public bool ForfeitBooking(int nSessionID)
		{
			myServiceSession.NSessionID = nSessionID;
			myServiceSession.SelectOne();

			myServiceSession.NStatusID = 6; 
			myServiceSession.DtLastEditDate = DateTime.Now;
			myServiceSession.NEmployeeID = ACMSLogic.User.EmployeeID;

			TblAudit audit = new TblAudit();
			audit.DtDate = DateTime.Today;
			audit.NAuditTypeID = AuditTypeID.Service;
			audit.NEmployeeID = ACMSLogic.User.EmployeeID;
			audit.StrAuditEntry = "Cancel Booking " + nSessionID.ToString();
			audit.StrReference = nSessionID.ToString();

			ACMSDAL.ConnectionProvider connProvider = new ConnectionProvider();

			try
			{
				
				myServiceSession.MainConnectionProvider = connProvider;
				audit.MainConnectionProvider = connProvider;
				connProvider.OpenConnection();
				connProvider.BeginTransaction("ForfeitBooking");
				myServiceSession.Update();
				audit.Insert();
				connProvider.CommitTransaction();
				return true;
			}
			catch (Exception)
			{
				connProvider.RollbackTransaction("ForfeitBooking");
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
				myServiceSession.MainConnactionIsCreatedLocal = true;
				audit.MainConnactionIsCreatedLocal = true;
			}

		}
		
		public DataTable GetWaitingListTable()
		{
			return myServiceSession.SelectWaitingList(User.BranchCode);
		}

		public DataTable GetMemberPackage(string strMemberShipID)
		{
			TblMemberPackage memberPackege = new TblMemberPackage();
			DataTable table = memberPackege.GetActiveMemberPackageForServiceSession();

			if (!table.Columns.Contains("Balance"))
			{
				DataColumn colBalance = new DataColumn("Balance", System.Type.GetType("System.Int32"));
				table.Columns.Add(colBalance);
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
					r["Balance"] = ACMS.Convert.ToInt32(r["nMaxSession"]) - classAttendanceTable.Count;
				}
				else if (nCategoryID == 4 || nCategoryID == 5 || nCategoryID == 6) // Service Session
				{
					serviceSession.NPackageID = nPackageID;
					DataView serviceSessionTable = serviceSession.SelectAllWnPackageIDLogic().DefaultView;
					serviceSessionTable.RowFilter = "nStatusID = 5 or nStatusID = 6";
					r["Balance"] = ACMS.Convert.ToInt32(r["nMaxSession"]) - serviceSessionTable.Count;
				}
			}
			return table;
		}

		public static bool TherapistIsAvailableToBook(int nEmployeeID, DateTime dtDateToBook, 
			DateTime dtStartTimeToBook, DateTime dtEndTimeToBook, string strBranchCode)
		{
/* To remove the Therapist Roster checking
			string cmdText  = " Select * From tblRoster Where nEmployeeID = @nEmployeeID and dtDate = @dtDate and strBranchCode = @strBranchCode ";
            
			TblRoster roster = new TblRoster();
			DataTable table = roster.LoadData(cmdText, new string[] {"@nEmployeeID", "@dtDate", "@strBranchCode"},  new object [] {nEmployeeID, dtDateToBook, strBranchCode});

			if (table == null || table.Rows.Count == 0)
				throw new Exception(" The therapist is not available for the given time.");

			DataRow row = table.Rows[0];
			DateTime empStartTime = ACMS.Convert.ToDateTime(row["dtStartTime"]);
			DateTime empEndTime = ACMS.Convert.ToDateTime(row["dtEndTime"]);

			if (DateTime.Compare(dtStartTimeToBook ,empStartTime)<0)
				throw new Exception(" This Therapist is not available for the given time.");

			if (DateTime.Compare(dtStartTimeToBook ,empEndTime)>0)
				throw new Exception(" This therapist is not available for the given time.");

			cmdText = " Select Count(*) from tblServiceSession Where nServiceEmployeeID = @nEmployeeID and (nStatusID <> 7 AND nStatusID <> 6 AND nStatusID <> 1) " + 
				"    and dtDate = @dtDate and " +
				" ((@dtStartTimeToBook Between dtStartTime AND dtEndTime ) or (@dtEndTimeToBook Between dtStartTime AND dtEndTime))";
			
			object obj = roster.ExecuteScalar(cmdText, new string[] {"@nEmployeeID", "@dtDate", "@dtStartTimeToBook", "@dtEndTimeToBook"}, 
				new object[] {nEmployeeID, dtDateToBook, dtStartTimeToBook, dtEndTimeToBook});
			
			if (obj != null)
			{
				Int32 r = (Int32) obj;
				if (r > 0)
					throw new Exception(" Time period choosen is already in used. Please choose other time period.");
				else
					return true;
			}
			else*/
				return true;
		}

		private bool CheckIsServiceSessionTimeNoOverLap(int nEmployeeID, DateTime dtDateToBook, 
			DateTime dtStartTimeToBook, DateTime dtEndTimeToBook, string strBranchCode)
		{
			TblRoster roster = new TblRoster();

			string cmdText = " Select Count(*) from tblServiceSession Where nServiceEmployeeID = @nEmployeeID and (nStatusID <> 7 AND nStatusID <> 6 AND nStatusID <> 1) " + 
				"    and dtDate = @dtDate and " +
				" ((@dtStartTimeToBook Between dtStartTime AND dtEndTime ) or (@dtEndTimeToBook Between dtStartTime AND dtEndTime))";
			
			object obj = roster.ExecuteScalar(cmdText, new string[] {"@nEmployeeID", "@dtDate", "@dtStartTimeToBook", "@dtEndTimeToBook"}, 
				new object[] {nEmployeeID, dtDateToBook, dtStartTimeToBook, dtEndTimeToBook});
			
			if (obj != null)
			{
				Int32 r = (Int32) obj;
				if (r > 0)
					throw new Exception(" The Time period you choose is been used by others. Please choose other time period.");
				else
					return true;
			}
			else
				return true;
		}

		private void Init()
		{
			myServiceSession = new TblServiceSession();
		}

		public DataTable GetCurrentBranchServiceSession()
		{
			DataTable table = myServiceSession.GetServiceSession(User.BranchCode);
			return table;
		}

		public DataTable GetUOBSpaBooking(DateTime dtDate, string strBranchCode)
		{
			DataTable table = myServiceSession.GetUOBBookingServiceSessionBaseDate(strBranchCode, dtDate);
			return table;
		}

		public DataTable GetServiceSession(int nServiceSessionID)
		{
			myServiceSession.NSessionID = nServiceSessionID;
			DataTable table = myServiceSession.SelectOne();
			return table;
		}

		public static bool IsBranchAllowUOBBooking(string strBranchCode, ref int nWeekDayOffPeekMax
			, ref int nWeekDayPeekMax, ref int nWeekEndOffPeekMax, ref int nWeekEndPeekMax)
		{
			TblUOBBooking uobBooking = new TblUOBBooking();
			uobBooking.StrBranchCode = strBranchCode;
			DataTable table = uobBooking.SelectOne();
			if (table.Rows.Count > 0)
			{
				nWeekDayOffPeekMax = ACMS.Convert.ToInt32(uobBooking.NWeekDayOffPeak);
				nWeekDayPeekMax = ACMS.Convert.ToInt32(uobBooking.NWeekDayPeak);
				nWeekEndOffPeekMax = ACMS.Convert.ToInt32(uobBooking.NWeekEndOffPeak);
				nWeekEndPeekMax = ACMS.Convert.ToInt32(uobBooking.NWeekEndPeak);
			}
			return table.Rows.Count == 1;
		}
	}
}
