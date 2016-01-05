using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using ACMS.Utils;
using ACMSLogic.Staff;
using ACMSDAL;

namespace ACMS.ACMSManager.Human_Resource
{
	/// <summary>
	/// Summary description for Timesheet.
	/// </summary>
	public class Timesheet
	{
		public delegate void DetailTableChangedUpdate();

		private DetailTableChangedUpdate myDetailTableChangedUpdate;
		private DataTable myMasterTable;
		private DataTable myDetailTable;
		private int mynManagerID;

		/// <summary>
		/// TimeSheet/tblRoster table
		/// </summary>
		public DataTable MasterTable
		{
			get { return myMasterTable; }
			set { myMasterTable = value; }
		}

		/// <summary>
		/// tblRoster table
		/// </summary>
		public DataTable DetailTable
		{
			get { return myDetailTable; }
			set { myDetailTable = value; }
		}

		public DetailTableChangedUpdate OnDetailTableChangedUpdate
		{
			set { myDetailTableChangedUpdate = value; }
		}

		public Timesheet(int nManagerID)
		{
			//
			// TODO: Add constructor logic here
			//
			myMasterTable = new DataTable("tblRoster");
			myDetailTable = new DataTable("tblTimeCard");
			mynManagerID = nManagerID;
		}

		#region List Timesheet
		public void ListTimesheetDetail(int nEmployeeID, string strBranchCode,DateTime startDate, DateTime endDate)
		{
			DataSet dsTimesheeDetail = SqlHelperUtils.ExecuteDatasetSP("pr_SelectTimesheetDetail",
				new SqlParameter("@inEmployeeID", nEmployeeID),
				new SqlParameter("@dtStartDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, startDate),
				new SqlParameter("@dtEndDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, endDate));

			myDetailTable = dsTimesheeDetail.Tables[1];
			AddDetailRowChangeEvent();
		}

		public void ListTimesheetWithLateness(int nEmployeeID,string strBranchCode,Month aMonth, int aYear)
		{
			DateTime startDate, endDate;
			ACMSLogic.Staff.Ultis.DatesRange(out startDate, out endDate, aMonth, aYear);
			DataTable myRosterTable = ListTimesheet(nEmployeeID, strBranchCode,startDate, endDate);
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
				//DataRow rRoster = myRosterTable.Rows.Find(rLateness["nRosterID"]);
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
			myMasterTable = myRosterTable;
			myDetailTable.Clear();
		}

		private DataTable ListTimesheet(int nEmployeeID, string strBranchCode, DateTime startDate, DateTime endDate)
		{
			DataTable myTable = ListBasicTimesheet(nEmployeeID, strBranchCode, startDate, endDate);
			ListAdvancedTimesheet(myTable, nEmployeeID, strBranchCode,startDate, endDate);
			return myTable;
		}

		private DataTable ListBasicTimesheet(int nEmployeeID, string strBranchCode,DateTime startDate, DateTime endDate)
		{
					string cmdtxt = "SELECT * FROM SV_EMPLOYEE_TIMESHEET "
	//			string cmdtxt = "SELECT * FROM Sv_StaffTimesheet "
					+"WHERE nEmployeeID = @nEmployeeID and dtDate >= @startDate AND dtDate < @endDate";//AND strBranchCode=@strBranchCode 
			return SqlHelperUtils.ExecuteDataTableText(cmdtxt,
				new SqlParameter("@nEmployeeID", nEmployeeID),
				new SqlParameter("@strBranchCode",strBranchCode),
				new SqlParameter("@startDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, startDate),
				new SqlParameter("@endDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, endDate));
		}

		private void ListAdvancedTimesheet(DataTable basicTable, int nEmployeeID, string strBranchCode,DateTime startDate, DateTime endDate)
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
			
//			string cmdtxt = "SELECT A.strBranchCode, A.strRemarks, B.strEmployeeName AS strManagerName "
//				+"FROM tblTimeCard A INNER JOIN tblEmployee B ON A.nManagerID = B.nEmployeeID "
//				+"WHERE A.dtDate = @dtDate AND A.dtTime = @dtTime AND A.nEmployeeID = @nEmployeeID";// AND A.strBranchCode=@strBranchCode";
			SqlCommand cmd = new SqlCommand(cmdtxt, conn);
			try
			{
				conn.Open();
				foreach (DataRow rCurrent in basicTable.Rows)
				{
					if (rCurrent["First Time In"] != DBNull.Value)
					{
						cmd.Parameters.Clear();
						cmd.Parameters.Add(new SqlParameter("@strBranchCode", rCurrent["strBranchCode"]));
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
						cmd.Parameters.Add(new SqlParameter("@strBranchCode", rCurrent["strBranchCode"]));
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

		private void AddDetailRowChangeEvent()
		{
			myDetailTable.ColumnChanged += new DataColumnChangeEventHandler(myDetailTable_ColumnChanged);
			myDetailTable.RowDeleted += new DataRowChangeEventHandler(myDetailTable_RowDeleted);
		}

		private void DeleteDetailRowChangeEvent()
		{
			myDetailTable.ColumnChanged -= new DataColumnChangeEventHandler(myDetailTable_ColumnChanged);
			myDetailTable.RowDeleted -= new DataRowChangeEventHandler(myDetailTable_RowDeleted);
		}

		private void myDetailTable_ColumnChanged(object sender, System.Data.DataColumnChangeEventArgs e)
		{
			if (myDetailTableChangedUpdate != null)
				myDetailTableChangedUpdate();
			if (e.Column.ColumnName != "nManagerID")
			{
				e.Row.BeginEdit();
				e.Row["nManagerID"] = mynManagerID;
				e.Row.EndEdit();
			}
			if (e.Column.ColumnName == "dtTime")
			{
				DeleteDetailRowChangeEvent();
				e.Row.BeginEdit();
				DateTime date = Convert.ToDateTime(e.Row["dtDate"]);
				DateTime time = Convert.ToDateTime(e.Row["dtTime"]);
				DateTime newDate = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second, 
					time.Millisecond);
				e.Row["dtTime"] = newDate;
				e.Row.EndEdit();
				AddDetailRowChangeEvent();
			}
		}

		private void myDetailTable_RowDeleted(object sender, System.Data.DataRowChangeEventArgs e)
		{
			if (myDetailTableChangedUpdate != null)
				myDetailTableChangedUpdate();
		}

		public DataRow AddNewRow(int nManagerID, int nEmployeeID, DateTime dtDate)
		{
			DataRow rNew = myDetailTable.NewRow();
			rNew.BeginEdit();
			rNew["dtDate"] = dtDate;
			rNew["nManagerID"] = nManagerID;
			rNew["nEmployeeID"] = nEmployeeID;
			rNew["dtLastEditDate"] = DateTime.Now;
			rNew.EndEdit();
			myDetailTable.Rows.Add(rNew);

			return rNew;
		}

		public void Save()
		{
			TblTimeCard myTimeCard = new TblTimeCard();
			myTimeCard.SaveData(myDetailTable, "SELECT * FROM tblTimeCard");
		}
	}
}
