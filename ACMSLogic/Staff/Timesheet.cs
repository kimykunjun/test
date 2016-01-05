using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using ACMS.Utils;

namespace ACMSLogic.Staff
{
	/// <summary>
	/// Summary description for Timesheet.
	/// </summary>
	public class Timesheet
	{
		public Timesheet()
		{
		}

		#region Timesheet
		public void ListTimesheetDetail(int nEmployeeID, DateTime startDate, DateTime endDate, out DataTable timesheetTable,
			out DataTable timecardTable)
		{
			DataSet dsTimesheeDetail = SqlHelperUtils.ExecuteDatasetSP("pr_SelectTimesheetDetail",
				new SqlParameter("@inEmployeeID", nEmployeeID),
				new SqlParameter("@dtStartDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, startDate),
				new SqlParameter("@dtEndDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, endDate));

			timesheetTable = dsTimesheeDetail.Tables[0];
			timecardTable = dsTimesheeDetail.Tables[1];
		}

		public DataTable ListTimesheetWithLateness(int nEmployeeID, Month aMonth, int aYear)
		{
			DateTime startDate, endDate;
			ACMSLogic.Staff.Ultis.DatesRange(out startDate, out endDate, aMonth, aYear);
			DataTable myRosterTable = ListTimesheet(nEmployeeID, startDate, endDate);
//			if (!myRosterTable.Columns.Contains("nRosterID"))
//				throw new Exception("Missing 'nRosterID' at Sv_Staff_Timesheet view.");

			//myRosterTable.PrimaryKey = new DataColumn[] {myRosterTable.Columns["nRosterID"]};
			myRosterTable.DefaultView.Sort = "dtDate";

			Lateness myLateness = new Lateness();
			myLateness.GetLateness(nEmployeeID, aMonth, aYear);
			DataTable myLatenessTable = myLateness.LatenessTable;

			foreach (DataRow rLateness in myLatenessTable.Rows)
			{
				if (Convert.ToDateTime(rLateness["dtDate"]) >= DateTime.Now)
					continue;
				////DataRow rRoster = myRosterTable.Rows.Find(rLateness["nRosterID"]);
				//DataRow[] rRoster = myRosterTable.Select("dtDate = '" +rLateness["dtDate"] +"'");
                DataRow[] rRoster = myRosterTable.Select("nRosterID = '" + rLateness["nRosterID"] + "'");
				//if (rRoster != null && rRoster.Length >= 1)
				foreach (DataRow r in rRoster)
				{
					r.BeginEdit();
					r["fLateness"] = true;
					r["nLateness"] = ACMS.Convert.ToInt32(r["nLateness"]) + ACMS.Convert.ToInt32(rLateness["nLateness"]);
					r["dtLateness"] = DateTime.Today.AddMinutes(ACMS.Convert.ToInt32(r["nLateness"]));
					r.EndEdit();
				}
			}
			return myRosterTable;
		}

		public DataTable ListTimesheet(int nEmployeeID, DateTime startDate, DateTime endDate)
		{
			DataTable myTable = ListBasicTimesheet(nEmployeeID, startDate, endDate);
			ListAdvancedTimesheet(myTable, nEmployeeID, startDate, endDate);
			return myTable;
		}

		private DataTable ListBasicTimesheet(int nEmployeeID, DateTime startDate, DateTime endDate)
		{
			string cmdtxt = "SELECT * FROM Sv_StaffTimesheet "
				+"WHERE nEmployeeID = @nEmployeeID AND dtDate >= @startDate AND dtDate < @endDate and dtDate<=getdate()";
			return SqlHelperUtils.ExecuteDataTableText(cmdtxt,
				new SqlParameter("@nEmployeeID", nEmployeeID),
				new SqlParameter("@startDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, startDate),
				new SqlParameter("@endDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, endDate));
		}

		private void ListAdvancedTimesheet(DataTable basicTable, int nEmployeeID, DateTime startDate, DateTime endDate)
		{
			basicTable.Columns.Add("strBranchCodeIn", typeof(string));
			basicTable.Columns.Add("strRemarksIn", typeof(string));
			basicTable.Columns.Add("strManagerNameIn", typeof(string));
			basicTable.Columns.Add("strBranchCodeOut", typeof(string));
			basicTable.Columns.Add("strRemarksOut", typeof(string));
			basicTable.Columns.Add("strManagerNameOut", typeof(string));
			basicTable.Columns.Add("fLateness", typeof(bool));
			basicTable.Columns.Add("nLateness", typeof(int));
			basicTable.Columns.Add("dtLateness", typeof(DateTime));
			SqlConnection conn = new SqlConnection(SqlHelperUtils.connectionString);
			string cmdtxt = "SELECT  A.strBranchCode, A.strRemarks, B.strEmployeeName AS strManagerName "
				+"FROM tblTimeCard A LEFT JOIN tblEmployee B ON A.nManagerID = B.nEmployeeID "
				+"WHERE DATEDIFF(day, A.dtDate, @dtdate)=0 and "
				+"DATEDIFF(day, A.dtTime, @dtTime)=0 "
				+"AND A.nEmployeeID = @nEmployeeID "
				+"Order by dtDate asc";
			
			SqlCommand cmd = new SqlCommand(cmdtxt, conn);
			try
			{
				conn.Open();
				foreach (DataRow rCurrent in basicTable.Rows)
				{
					if (rCurrent["First Time In"] != DBNull.Value)
					{
						cmd.Parameters.Clear();
						cmd.Parameters.Add(new SqlParameter("@nEmployeeID", rCurrent["nEmployeeID"]));
						cmd.Parameters.Add(new SqlParameter("@dtDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, rCurrent["dtDate"]));
						cmd.Parameters.Add(new SqlParameter("@dtTime", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, rCurrent["First Time In"]));
						SqlDataReader myReader = cmd.ExecuteReader();
						if (myReader.Read())
						{
							rCurrent.BeginEdit();
							if (!myReader.IsDBNull(0))
								rCurrent["strBranchCodeIn"] = myReader.GetString(0);
							if (!myReader.IsDBNull(1))
								rCurrent["strRemarksIn"] = myReader.GetString(1);
							if (!myReader.IsDBNull(2))
								rCurrent["strManagerNameIn"] = myReader.GetString(2);
							rCurrent.EndEdit();
						}
						myReader.Close();
					}
					if (rCurrent["Last Time Out"] != DBNull.Value)
					{
						cmd.Parameters.Clear();
						cmd.Parameters.Add(new SqlParameter("@nEmployeeID", rCurrent["nEmployeeID"]));
						cmd.Parameters.Add(new SqlParameter("@dtDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, rCurrent["dtDate"]));
						cmd.Parameters.Add(new SqlParameter("@dtTime", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, rCurrent["Last Time Out"]));
						SqlDataReader myReader = cmd.ExecuteReader();
						
						while (myReader.Read())
						{
							rCurrent.BeginEdit();
							if (!myReader.IsDBNull(0))
								rCurrent["strBranchCodeOut"] = myReader.GetString(0);
							if (!myReader.IsDBNull(1))
								rCurrent["strRemarksOut"] = myReader.GetString(1);
							if (!myReader.IsDBNull(2))
								rCurrent["strManagerNameOut"] = myReader.GetString(2);
							rCurrent.EndEdit();
						}

						myReader.Close();
					}
				}
			}
			finally
			{
				conn.Close();
				conn.Dispose();
			}
		}
		#endregion

		#region Overtime
		public DataTable ListOvertime(int nEmployeeID, DateTime startDate, DateTime endDate)
		{
			return SqlHelperUtils.ExecuteDataTableSP("pr_tblOvertime_SelectAllWnEmployeeIDDateTime",
				new SqlParameter("@inEmployeeID", nEmployeeID),
				new SqlParameter("@ddtStartDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, startDate),
				new SqlParameter("@ddtEndDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, endDate));
		}

		public void ApplyOvertime(int nEmployeeID, DateTime dtDate, DateTime dtStartDate, DateTime dtEndDate, double nMins, 
			string sstrReason)
		{
			if (nMins >= 6)
				nMins = nMins -1;

			SqlHelperUtils.ExecuteNonQuerySP("pr_tblOvertime_Insert", 
				new SqlParameter("@inEmployeeID", nEmployeeID),
				new SqlParameter("@dadtDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, dtDate),
				new SqlParameter("@dadtStartTime", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, dtStartDate),
				new SqlParameter("@dadtEndTime", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, dtEndDate),
				new SqlParameter("@inHours", SqlDbType.Float,8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed,nMins),
				new SqlParameter("@sstrReason", sstrReason));
		}

        public void ApplyPH(int nEmployeeID, DateTime dtDate,string sstrReason)
        {          

            SqlHelperUtils.ExecuteNonQuerySP("dw_tblLeavePH_Insert",
                new SqlParameter("@inEmployeeID", nEmployeeID),
                new SqlParameter("@dadtDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, dtDate),               
                new SqlParameter("@sstrReason", sstrReason));
        }

        public void CancelPH(int nEmployeeID, DateTime dtDate)
        {
            SqlHelperUtils.ExecuteNonQuerySP("dw_tblLeavePH_UpdateCancel",
                        new SqlParameter("@Employee", nEmployeeID),
                        new SqlParameter("@dtDate", dtDate),
                        new SqlParameter("@ManagerID", 0)
                        );
        }

		public bool DeleteOvertime(int nOvertimeID, int nEmployeeID)
		{
			try
			{
				SqlHelperUtils.ExecuteNonQuerySP("pr_tblOvertime_Delete", 
					new SqlParameter("@inOvertimeID", nOvertimeID),
					new SqlParameter("@inEmployeeID", nEmployeeID));
			}
			catch 
			{
				throw;
			}
			return true;
		}
		#endregion
	}
}
