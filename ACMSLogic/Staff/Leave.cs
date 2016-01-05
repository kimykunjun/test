using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using ACMS.Utils;
using ACMSDAL;

namespace ACMSLogic.Staff
{
	/// <summary>
	/// Summary description for Leave.
	/// </summary>
	public class Leave
	{
		public Leave()
		{
		}

		#region Form Logic
		#region Abandon Method
		public DataTable ListLeave(int nEmployeeID, Month aMonth, int year)
		{
			SqlParameter paramEmployeeID = new SqlParameter("@inEmployeeID", SqlDbType.Int);
			paramEmployeeID.Value = nEmployeeID;
			SqlParameter paramCurrentMonth = new SqlParameter("@ddtCurrentDate", SqlDbType.DateTime);
			paramCurrentMonth.Value = new DateTime(year, ((int)aMonth + 1), 1);

			return SqlHelperUtils.ExecuteDataTableSP("pr_tblLeave_SelectCurrentMonthBynEmployeeID", paramEmployeeID,
				paramCurrentMonth);
		}

		public DataTable ListMiscLeave(int nEmployeeID, string strLeaveCode)
		{
			int nYearID = GetNYearID(nEmployeeID);

			SqlParameter paramEmployeeID = new SqlParameter("@inEmployeeID", SqlDbType.Int);
			paramEmployeeID.Value = nEmployeeID;
			SqlParameter paramYearID = new SqlParameter("@inYearID", SqlDbType.Int);
			paramYearID.Value = nYearID;
			SqlParameter paramLeaveCode = new SqlParameter("@sstrLeaveCode", SqlDbType.VarChar);
			paramLeaveCode.Value = strLeaveCode;

			return SqlHelperUtils.ExecuteDataTableSP("pr_tblLeave_SelectMiscLeave", paramEmployeeID, paramYearID, paramLeaveCode);
		}
		#endregion

		public DataTable ListLeaveByYearIDStatus(int nEmployeeID, int nYearID, ListLeaveStatus aStatus)
		{
			SqlParameter paramEmployeeID = new SqlParameter("@inEmployeeID", SqlDbType.Int);
			paramEmployeeID.Value = nEmployeeID;
			SqlParameter paramYearID = new SqlParameter("@inYearID", SqlDbType.Int);
			paramYearID.Value = nYearID;
			SqlParameter paramLeaveStatus = new SqlParameter("@inStatusID", SqlDbType.Int);
			paramLeaveStatus.Value = (int)aStatus;
			if (aStatus != ListLeaveStatus.All)
			{
				return SqlHelperUtils.ExecuteDataTableSP("pr_tblLeave_SelectLeaveBynEmployeeIDnYearIDnStatusID", paramEmployeeID,
					paramYearID, paramLeaveStatus);
			}
			else
			{
				return SqlHelperUtils.ExecuteDataTableSP("pr_tblLeave_SelectAllLeaveBynEmployeeIDnYearID", paramEmployeeID,
					paramYearID);
			}
		}

		public DataTable ListOneDetail(int nLeaveID)
		{
			SqlParameter paramLeaveID = new SqlParameter("@inLeaveID", SqlDbType.Int);
			paramLeaveID.Value = nLeaveID;

			return SqlHelperUtils.ExecuteDataTableSP("pr_tblLeave_SelectBynLeaveID", paramLeaveID);
		}


		public int GetLeaveEntitlement(int nYearID, int nEmployeeID)
		{
			SqlParameter paramYearID = new SqlParameter("@inYearID", SqlDbType.Int);
			SqlParameter paramEmployeeID = new SqlParameter("@nEmployeeID", SqlDbType.Int);
			paramYearID.Value = nYearID;
			paramEmployeeID.Value = nEmployeeID;

			return ACMS.Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelperUtils.connectionString, "pr_GetLeaveEntitlement", 
				paramYearID,paramEmployeeID));
		}

		public bool CancelLeave(int nEmployeeID, int nLeaveID)
		{
			try
			{
				SqlHelperUtils.ExecuteNonQuerySP("pr_tblLeave_CancelLeave", 
					new SqlParameter("@inLeaveID", nLeaveID),
					new SqlParameter("@inEmployeeID", nEmployeeID));
			}
			catch 
			{
				throw;
			}
			return true;
		}
		#endregion

		#region Leave Balance
		public int GetNYearID(int nEmployeeID)
		{
			DateTime startDate = DateTime.Now;
			DataTable employeeTable = SqlHelperUtils.ExecuteDataTableSP("pr_tblEmployee_SelectOne", 
				new SqlParameter("@inEmployeeID", nEmployeeID));

			DateTime employeeStartDate;
			if (employeeTable.Rows[0]["dtEmployeeStartDate"] != DBNull.Value)
				employeeStartDate = Convert.ToDateTime(employeeTable.Rows[0]["dtEmployeeStartDate"]);
			else
				employeeStartDate = new DateTime(DateTime.Today.Year, 1, 1);

			int nYearID = Ultis.NYearID(employeeStartDate, startDate);
			return nYearID;
		}

		#region Abandon method
		public DataTable GetAnnualLeaveBalance(int nEmployeeID, int nYearID)
		{
			DataTable employeeTable = SqlHelperUtils.ExecuteDataTableSP("pr_tblEmployee_SelectOne", 
				new SqlParameter("@inEmployeeID", nEmployeeID));

			DateTime employeeStartDate;
			if (employeeTable.Rows[0]["dtEmployeeStartDate"] != DBNull.Value)
				employeeStartDate = Convert.ToDateTime(employeeTable.Rows[0]["dtEmployeeStartDate"]);
			else
				employeeStartDate = new DateTime(DateTime.Today.Year, 1, 1);

			DateTime startDate = employeeStartDate.AddYears(nYearID).AddDays(-1);

			DataTable leaveTable = SqlHelperUtils.ExecuteDataTableSP("pr_SelectAnnualLeaveBalance", 
				new SqlParameter("@inEmployeeID", nEmployeeID),
				new SqlParameter("@inYearID", nYearID));

			if (!ACMS.Convert.ToBoolean(employeeTable.Rows[0]["fProbation"]))
			{
				TimeSpan dayDifferent = startDate -(employeeStartDate.AddYears(nYearID - 1));
				double leaveEarned = Convert.ToDouble(leaveTable.Rows[0]["inLeaveMaxQty"]) / 365.00 * dayDifferent.Days;
				leaveEarned = Math.Round(leaveEarned, 0);

				DataRow rNew = leaveTable.NewRow();
				rNew.BeginEdit();
				rNew["dtDate"] = DateTime.Today;
				rNew["Transaction"] = "Leave earned";
				rNew["NoOfDays"] = leaveEarned;
				rNew.EndEdit();
				leaveTable.Rows.Add(rNew);
			}
			else
			{
				leaveTable.Rows[0].Delete();
			}

			return leaveTable;
		}
		#endregion

		public DataTable dwGetAnnualLeaveBalance(int nEmployeeID, int nYearID)
		{		

			DataTable employeeTable = SqlHelperUtils.ExecuteDataTableSP("pr_tblEmployee_SelectOne", 
				new SqlParameter("@inEmployeeID", nEmployeeID));

            DateTime startDate;
            if (employeeTable.Rows[0]["dtCessation"] != DBNull.Value)
            {
                if(System.Convert.ToDateTime(employeeTable.Rows[0]["dtCessation"].ToString()) < DateTime.Now)
                    startDate = System.Convert.ToDateTime(employeeTable.Rows[0]["dtCessation"].ToString());
                else
                    startDate = DateTime.Now;
            }
            else
                startDate = DateTime.Now;

			DateTime employeeStartDate;
			if (employeeTable.Rows[0]["dtEmployeeStartDate"] != DBNull.Value)
				employeeStartDate = Convert.ToDateTime(employeeTable.Rows[0]["dtEmployeeStartDate"]);
			else
				employeeStartDate = new DateTime(DateTime.Today.Year, 1, 1);

			//int nYearID = Ultis.NYearID(employeeStartDate, startDate);

			DataTable leaveTable = SqlHelperUtils.ExecuteDataTableSP("pr_SelectAnnualLeaveBalance", 
				new SqlParameter("@inEmployeeID", nEmployeeID),
				new SqlParameter("@inYearID", nYearID));

			if (!ACMS.Convert.ToBoolean(employeeTable.Rows[0]["fProbation"]))
			{
				leaveTable.Rows[0].BeginEdit();
				leaveTable.Rows[0]["dtDate"] = employeeStartDate.AddYears(nYearID - 1);
				leaveTable.Rows[0].EndEdit();
				
				double leaveEarned;
				TimeSpan dayDifferent = startDate -(employeeStartDate.AddYears(nYearID - 1));
				if (dayDifferent.Days >= 365)
				leaveEarned = Convert.ToDouble(leaveTable.Rows[0]["inLeaveMaxQty"]);
				else
				leaveEarned = Convert.ToDouble(leaveTable.Rows[0]["inLeaveMaxQty"]) / 365.00 * dayDifferent.Days;

				leaveEarned = Math.Round(leaveEarned, 0);

				DataRow rNew = leaveTable.NewRow();
				rNew.BeginEdit();
				rNew["dtDate"] = DateTime.Today;
				rNew["Transaction"] = " Leave earned";
				rNew["NoOfDays"] = leaveEarned;
				rNew.EndEdit();
				leaveTable.Rows.Add(rNew);
			
			}
			else
			{
				leaveTable.Rows[0].Delete();
			}
					return leaveTable;
		}

		public void UpdatePreviousBal(int nEmployeeID, int nYearID, decimal TotalBal)
		{
            if (nYearID > 0)
            {
                SqlHelperUtils.ExecuteNonQuerySP("pr_tblLeaveAdjust_InUp",
                    new SqlParameter("@inEmployeeID", nEmployeeID),
                    new SqlParameter("@inYearID", (nYearID)),
                    new SqlParameter("@LeaveEarned", TotalBal),
                    new SqlParameter("@Type", "A"));
            }
		}

		public void ConvertLeavetoTimeOff(int nEmployeeID, int nYearID,int nQuantity)
		{
			SqlHelperUtils.ExecuteNonQuerySP("pr_tblLeave_ConvertLeavetoTimeOff", 
				new SqlParameter("@inEmployeeID", nEmployeeID),
				new SqlParameter("@inYearID", (nYearID)),
				new SqlParameter("@nQuantity", nQuantity));
		
		}

		public void ManualUpdatePreviousBal(int nEmployeeID, int nYearID, decimal TotalBal)
		{
			SqlHelperUtils.ExecuteNonQuerySP("pr_tblLeaveAdjust_InUp", 
				new SqlParameter("@inEmployeeID", nEmployeeID),
				new SqlParameter("@inYearID", (nYearID)),
				new SqlParameter("@LeaveEarned", TotalBal),
				new SqlParameter("@Type","M"));
		}

		public DataTable GetTimeOffBalance(int nEmployeeID)
		{
			return SqlHelperUtils.ExecuteDataTableSP("pr_SelectTimeOffBalance", 
				new SqlParameter("@inEmployeeID", nEmployeeID));
		}

		public DataTable GetMiscBalance(int nEmployeeID)
		{
			int nYearID = GetNYearID(nEmployeeID);
			return SqlHelperUtils.ExecuteDataTableSP("pr_GetAllMiscLeaveBalanceInfo", 
				new SqlParameter("@inEmployeeID", nEmployeeID), new SqlParameter("@inYearID", nYearID));
		}

        public DataTable GetMCBalance(int nEmployeeID)
        {
            int nYearID = GetNYearID(nEmployeeID);
            return SqlHelperUtils.ExecuteDataTableSP("pr_GetAllMCBalanceInfo",
                new SqlParameter("@inEmployeeID", nEmployeeID), new SqlParameter("@inYearID", nYearID));
        }
		#endregion

		#region Apply/Edit Leave
		/// <returns>true if same work year.</returns>
		public bool CheckDateRangeIsSameWorkYear(DateTime startDate, DateTime endDate, DateTime employeeStartDate)
		{
			if (ACMSLogic.Staff.Ultis.NYearID(employeeStartDate, startDate) != 
				ACMSLogic.Staff.Ultis.NYearID(employeeStartDate, endDate))
				return false;
			else
				return true;
		}

		public void ApplyMiscLeave(int nEmployeeID, DataRow rEmployeeInfo, string strLeaveCode, string strRemarks, bool isFullDay,
			DateTime startDate, DateTime endDate, bool showNotEnoughBalance)
		{
			if (string.Compare(strLeaveCode, "AL", true) == 0 || string.Compare(strLeaveCode, "OFF", true) == 0)
				throw new Exception("Annual Leave or Time Off Leave is not until this Misc Leave.");

			if
				(!ACMS.Convert.ToBoolean(rEmployeeInfo["fMaternityLeave"]) && 
				(string.Compare(strLeaveCode, "MTL", true) == 0 || string.Compare(strLeaveCode, "MT3", true) == 0))
			{
				throw new Exception("You are not allow to apply Maternity Leave.");
			}
				
			if
				(!ACMS.Convert.ToBoolean(rEmployeeInfo["fChildCareLeave"]) && string.Compare(strLeaveCode, "CHD", true) == 0)
			{
				throw new Exception("You are not allow to apply ChildCare Leave.");
			}

			DateTime employeeStartDate;
			if (rEmployeeInfo["dtEmployeeStartDate"] !=
				DBNull.Value)
				employeeStartDate =
					Convert.ToDateTime(rEmployeeInfo["dtEmployeeStartDate"]);
			else
				employeeStartDate = new
					DateTime(DateTime.Today.Year, 1, 1);

			int nYearID = Ultis.NYearID(employeeStartDate, startDate);

			double nLeaveQty;
			if (isFullDay)
				nLeaveQty = 1.0;
			else
				nLeaveQty = 0.5;
            TimeSpan nWorkMonth = employeeStartDate - startDate;
            //if
            //    (!ACMS.Convert.ToBoolean(rEmployeeInfo["fProbation"]) ||
	
            //    (ACMS.Convert.ToBoolean(rEmployeeInfo["fProbation"]) && string.Compare("CHD", strLeaveCode, true) == 0))
            if (employeeStartDate.AddMonths(3).AddDays(-1) < startDate)
			{
				DataSet leaveDataSet =
					SqlHelperUtils.ExecuteDatasetSP("pr_GetMiscLeaveBalanceInfo", 
					new SqlParameter("@inEmployeeID",
					nEmployeeID),
					new SqlParameter("@inYear",
					startDate),
					new SqlParameter("@sstrLeaveCode",
					strLeaveCode));

				double nLeaveBalance = 0;
				if (leaveDataSet.Tables[0].Rows.Count > 0)
					nLeaveBalance =
						Convert.ToDouble(leaveDataSet.Tables[0].Rows[0]["nUnusedLeaveQuantity"]);
				else
					nLeaveBalance =
						Convert.ToDouble(leaveDataSet.Tables[1].Rows[0]["nMaxDays"]);

				if (showNotEnoughBalance && nLeaveQty >
					nLeaveBalance)
					throw new Exception("Not enough Misc Balance");

				if (nLeaveBalance >= nLeaveQty)
				{
					NewLeave(nEmployeeID, strLeaveCode, nYearID, strRemarks, false, nLeaveQty, 0, 0, 0, isFullDay, startDate, 
						endDate);
				}
				else if (nLeaveBalance >= 0)
				{
					NewLeave(nEmployeeID, strLeaveCode, nYearID, strRemarks, false, nLeaveBalance, 
						nLeaveQty - nLeaveBalance,
						0, 0, isFullDay, startDate, endDate);
				}
				else
				{
					NewLeave(nEmployeeID, strLeaveCode, nYearID, strRemarks, false, 0, nLeaveQty, 0, 0, isFullDay, startDate, 
						endDate);
				}
			}
			else
			{
				NewLeave(nEmployeeID, strLeaveCode, nYearID, strRemarks, false, 0, nLeaveQty, 0, 0, isFullDay, startDate, endDate);
			}
		}

        public bool ValidatePH(int nEmployeeID, DateTime startDate)
        {
            DataSet PHDataSet = SqlHelperUtils.ExecuteDatasetSP("dw_ComparePH",
                   new SqlParameter("@nEmployeeID",
                    nEmployeeID),
                    new SqlParameter("@dtDate",
                    startDate));
            int nClaim = Convert.ToInt32(PHDataSet.Tables[0].Rows[0]["nClaim"]);
            int nUsage = Convert.ToInt32(PHDataSet.Tables[1].Rows[0]["nUsage"]);

            if (nClaim > nUsage)
                return true;
            else
                return false;

        }

		public void ApplyTimeOff(int nEmployeeID, string strRemarks, DataRow rEmployeeInfo, DateTime startDate, DateTime endDate)
		{
			/*
			 * Edited by Albert. To get exact TimeOff Value.
			 */
			TimeSpan span = endDate - startDate;
			double tTimeOff = span.TotalMinutes/60;

			if (tTimeOff > 4.0)
				throw new Exception("Can't apply TimeOff exceeding 4 hours.");

			DataTable timeOffTable = SqlHelperUtils.ExecuteDataTableSP("pr_GetTimeOffBalanceInfo", 
				new SqlParameter("@inEmployeeID", nEmployeeID));

			double nTimeOffBalance;
			if (timeOffTable.Rows.Count == 0)
				nTimeOffBalance = 0;
			else 
				nTimeOffBalance = ACMS.Convert.ToDouble(timeOffTable.Rows[0]["nTimeOffBalance"]);

			DateTime employeeStartDate;
			if (rEmployeeInfo["dtEmployeeStartDate"] != DBNull.Value)
				employeeStartDate = Convert.ToDateTime(rEmployeeInfo["dtEmployeeStartDate"]);
			else
				employeeStartDate = new DateTime(DateTime.Today.Year, 1, 1);

			int nYearID = Ultis.NYearID(employeeStartDate, startDate);

			if (nTimeOffBalance >= tTimeOff)
			{
				NewLeave(nEmployeeID, "OFF", nYearID, strRemarks, true, 0, 0, tTimeOff, 0, false, startDate, endDate);
			}
			else
			{
				DialogResult result1 = MessageBox.Show(
					"Insufficent time accumulated, take " + (tTimeOff - nTimeOffBalance) +" Hrs as Unpaid Time-Off?", 
					"Confirm Time Off", 
					MessageBoxButtons.YesNo,MessageBoxIcon.Question);

				if (result1 == DialogResult.Yes)
				{
				
					NewLeave(nEmployeeID, "OFF", nYearID, strRemarks, true, 0, 0, nTimeOffBalance, (tTimeOff - nTimeOffBalance), false, startDate, endDate);
				}
				else if (result1 == DialogResult.No)
				{
					return;
				}
//				throw new Exception("Not enough time off balance.");
			}
		}

		public double GetActual_AnnualBalance(int nEmployeeID,int nYearID,DateTime startDate)
		{
			DataTable leaveTable = SqlHelperUtils.ExecuteDataTableSP("pr_SelectAnnualLeaveBalance", 
				new SqlParameter("@inEmployeeID", nEmployeeID),
				new SqlParameter("@inYearID", nYearID));
			
			DateTime employeeStartDate=DateTime.Today;

			TimeSpan dayDifferent = startDate - (employeeStartDate.AddYears(nYearID - 1));
			double leaveEarned = Convert.ToDouble(leaveTable.Rows[0]["inLeaveMaxQty"]) / 365.00 * dayDifferent.Days;
			leaveEarned = Math.Round(leaveEarned, 0);

			double leaveUsed = 0;
				
			if (leaveTable.Rows.Count>1)
			{
				for (int i = 1; i <= leaveTable.Rows.Count-1; i++)
				{
					leaveUsed=leaveUsed+(Convert.ToDouble(leaveTable.Rows[i]["NoOfDays"])*-1);
			}
			}

			double nLeaveBalance = leaveEarned -leaveUsed +
				Convert.ToDouble(leaveTable.Rows[0]["NoOfDays"]);

			return nLeaveBalance;

		}

		public void ApplyAnnualLeave(int nEmployeeID, string strLeaveCode, string strRemarks, bool isFullDay, DateTime startDate, 
			DateTime endDate)
		{
			DataTable employeeTable = SqlHelperUtils.ExecuteDataTableSP("pr_tblEmployee_SelectOne", 
				new SqlParameter("@inEmployeeID", nEmployeeID));

			DateTime employeeStartDate;
			if (employeeTable.Rows[0]["dtEmployeeStartDate"] != DBNull.Value)
				employeeStartDate = Convert.ToDateTime(employeeTable.Rows[0]["dtEmployeeStartDate"]);
			else
				employeeStartDate = new DateTime(DateTime.Today.Year, 1, 1);

			int nYearID = Ultis.NYearID(employeeStartDate, startDate);
            int CurrentYearID = Ultis.NYearID(employeeStartDate, DateTime.Now);

			double nLeaveQty;
			if (isFullDay)
				nLeaveQty = 1.0;
			else
				nLeaveQty = 0.5;

			if (!ACMS.Convert.ToBoolean(employeeTable.Rows[0]["fProbation"]))
			{
				DataTable leaveTable = SqlHelperUtils.ExecuteDataTableSP("pr_SelectAnnualLeaveBalance", 
					new SqlParameter("@inEmployeeID", nEmployeeID),
					new SqlParameter("@inYearID", nYearID));

				TimeSpan dayDifferent = startDate - (employeeStartDate.AddYears(nYearID - 1));
				double leaveEarned = Convert.ToDouble(leaveTable.Rows[0]["inLeaveMaxQty"]) / 365.00 * dayDifferent.Days;
				leaveEarned = Math.Round(leaveEarned, 0);
//				double nLeaveBalance = leaveEarned - Convert.ToDouble(leaveTable.Rows[0]["inSumLeaveQty"]) +
//					Convert.ToDouble(leaveTable.Rows[0]["NoOfDays"]);

				
				double leaveUsed = 0;
				
				if (leaveTable.Rows.Count>1)
				{
					for (int i = 1; i <= leaveTable.Rows.Count-1; i++)
					{
						leaveUsed=leaveUsed+(Convert.ToDouble(leaveTable.Rows[i]["NoOfDays"])*-1);
					}
				}

				double nLeaveBalance = leaveEarned -leaveUsed +
				Convert.ToDouble(leaveTable.Rows[0]["NoOfDays"]);

                if (nLeaveBalance >= nLeaveQty && nYearID == CurrentYearID)
						{
							NewLeave(nEmployeeID, strLeaveCode, nYearID, strRemarks, false, nLeaveQty, 0, 0, 0, isFullDay, startDate, 
								endDate);
						}
                else if (nLeaveBalance >= 0 || nYearID > CurrentYearID)//unpaid leave
						{
					
						DialogResult result1 = MessageBox.Show(
						"Take as Unpaid Leave?", 
						"Confirm Leave", 
						MessageBoxButtons.YesNo,MessageBoxIcon.Question);

						if (result1 == DialogResult.Yes)
						{
                            if (nYearID > CurrentYearID)
                            {
                                NewLeave(nEmployeeID, strLeaveCode, nYearID, strRemarks, false, nLeaveBalance, 1, 0, 0,
                                isFullDay, startDate, endDate);
                            }
                            else
                                NewLeave(nEmployeeID, strLeaveCode, nYearID, strRemarks, false, nLeaveBalance, nLeaveQty - nLeaveBalance, 0, 0,
                            isFullDay, startDate, endDate);
						}
						else if (result1 == DialogResult.No)
						{
								return;
						}
						}
				else
						{
							NewLeave(nEmployeeID, strLeaveCode, nYearID, strRemarks, false, 0, nLeaveQty, 0, 0, isFullDay, startDate, 
								endDate);
						}
			}
			else
			{
				NewLeave(nEmployeeID, strLeaveCode, nYearID, strRemarks, false, 0, nLeaveQty, 0, 0, isFullDay, startDate, endDate);
			}
		}

		private void NewLeave(int nEmployeeID, string strLeaveCode, int nYearID, string strRemarks, bool isTimeOff, double nLeaveQty,
			double nUnpaidLeaveQty, double nTimeOffQty, double nUnpaidTimeOff, bool isFullDay, DateTime startDate, DateTime endDate)
		{
			SqlHelperUtils.ExecuteNonQuerySP("pr_tblLeave_Insert", 
				new SqlParameter("@inEmployeeID", nEmployeeID),
				new SqlParameter("@sstrLeaveCode", strLeaveCode),
				new SqlParameter("@inYearID", nYearID),
				new SqlParameter("@sstrRemarks", strRemarks),
				new SqlParameter("@bfTimeOff", isTimeOff),
				new SqlParameter("@dadtStartTime", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, startDate),
				new SqlParameter("@dadtEndTime", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, endDate),
				new SqlParameter("@fnLeaveQuantity", nLeaveQty),
				new SqlParameter("@fnUnpaidLeave", nUnpaidLeaveQty),
				new SqlParameter("@fnTimeOffQuantity", nTimeOffQty),
				new SqlParameter("@fnUnpaidTimeOff", nUnpaidTimeOff),
				new SqlParameter("@bfFullDay", isFullDay));
		}

		
		#endregion

		#region Edit Leave
		public void UpdateMiscLeave(int nLeaveID, int nEmployeeID, DataRow rEmployeeInfo, string strLeaveCode, string strRemarks, 
			bool isFullDay,	DateTime startDate, DateTime endDate, bool showNotEnoughBalance)
		{
			if (string.Compare(strLeaveCode, "AL", true) == 0 || string.Compare(strLeaveCode, "OFF", true) == 0)
				throw new Exception("Annual Leave or Time Off Leave is not until this Misc Leave.");

			if (!ACMS.Convert.ToBoolean(rEmployeeInfo["fMaternityLeave"]) && 
				(string.Compare(strLeaveCode, "MTL", true) == 0 || string.Compare(strLeaveCode, "MT3", true) == 0))
			{
				throw new Exception("You are not allow to apply Maternity Leave.");
			}
				
			if (!ACMS.Convert.ToBoolean(rEmployeeInfo["fChildCareLeave"]) && string.Compare(strLeaveCode, "CHD", true) == 0)
			{
				throw new Exception("You are not allow to apply ChildCare Leave.");
			}

			DateTime employeeStartDate;
			if (rEmployeeInfo["dtEmployeeStartDate"] != DBNull.Value)
				employeeStartDate = Convert.ToDateTime(rEmployeeInfo["dtEmployeeStartDate"]);
			else
				employeeStartDate = new DateTime(DateTime.Today.Year, 1, 1);

			int nYearID = Ultis.NYearID(employeeStartDate, startDate);

			double nLeaveQty;
			if (isFullDay)
				nLeaveQty = 1.0;
			else
				nLeaveQty = 0.5;

			if (!ACMS.Convert.ToBoolean(rEmployeeInfo["fProbation"]) ||
				(ACMS.Convert.ToBoolean(rEmployeeInfo["fProbation"]) && string.Compare("CHD", strLeaveCode, true) == 0))
			{
				DataSet leaveDataSet = SqlHelperUtils.ExecuteDatasetSP("pr_GetUpdateMiscLeaveBalanceInfo", 
					new SqlParameter("@inEmployeeID", nEmployeeID),
					new SqlParameter("@inLeaveID", nLeaveID),
					new SqlParameter("@inYearID", nYearID),
					new SqlParameter("@sstrLeaveCode", strLeaveCode));

				double nLeaveBalance = 0;
				if (leaveDataSet.Tables[0].Rows.Count > 0)
					nLeaveBalance = Convert.ToDouble(leaveDataSet.Tables[0].Rows[0]["nUnusedLeaveQuantity"]);
				else
					nLeaveBalance = Convert.ToDouble(leaveDataSet.Tables[1].Rows[0]["nMaxDays"]);

				if (showNotEnoughBalance && nLeaveQty > nLeaveBalance)
					throw new Exception("Not enough Misc balance.");

				if (nLeaveBalance >= nLeaveQty)
				{
					EditLeave(nLeaveID, nEmployeeID, nYearID, strRemarks, nLeaveQty, 0, 0, 0, isFullDay, startDate, 
						endDate);
				}
				else if (nLeaveBalance >= 0)
				{
					EditLeave(nLeaveID, nEmployeeID, nYearID, strRemarks, nLeaveBalance, 
						nLeaveQty - nLeaveBalance, 0, 0, isFullDay, startDate, endDate);
				}
				else
				{
					EditLeave(nLeaveID, nEmployeeID, nYearID, strRemarks, 0, nLeaveQty, 0, 0, isFullDay, startDate, 
						endDate);
				}
			}
			else
			{
				EditLeave(nLeaveID, nEmployeeID, nYearID, strRemarks, 0, nLeaveQty, 0, 0, isFullDay, startDate, 
					endDate);
			}
		}

		public void UpdateTimeOff(int nLeaveID, int nEmployeeID, string strRemarks, DataRow rEmployeeInfo, DateTime startDate, 
			DateTime endDate)
		{
			TimeSpan span = endDate - startDate;

			if (span.TotalHours > 4.0)
				throw new Exception("Can't apply TimeOff larger then 4 hours.");

			DataTable timeOffTable = SqlHelperUtils.ExecuteDataTableSP("pr_GetUpdateTimeOffBalanceInfo", 
				new SqlParameter("@inEmployeeID", nEmployeeID),
				new SqlParameter("@inLeaveID", nLeaveID));

			int nTimeOffBalance = ACMS.Convert.ToInt32(timeOffTable.Rows[0]["nTimeOffBalance"]);

			DateTime employeeStartDate;
			if (rEmployeeInfo["dtEmployeeStartDate"] != DBNull.Value)
				employeeStartDate = Convert.ToDateTime(rEmployeeInfo["dtEmployeeStartDate"]);
			else
				employeeStartDate = new DateTime(DateTime.Today.Year, 1, 1);

			int nYearID = Ultis.NYearID(employeeStartDate, startDate);

			if (nTimeOffBalance >= span.Hours)
			{
				EditLeave(nLeaveID, nEmployeeID, nYearID, strRemarks, 0, 0, span.Hours, 0, false, startDate, endDate);
			}
			else
			{
				throw new Exception("Not enough time off balance.");
			}
		}

		public void UpdateAnnualLeave(int nLeaveID, int nEmployeeID, string strLeaveCode, string strRemarks, bool isFullDay, 
			DateTime startDate, DateTime endDate)
		{
			DataTable employeeTable = SqlHelperUtils.ExecuteDataTableSP("pr_tblEmployee_SelectOne", 
				new SqlParameter("@inEmployeeID", nEmployeeID));

			DateTime employeeStartDate;
			if (employeeTable.Rows[0]["dtEmployeeStartDate"] != DBNull.Value)
				employeeStartDate = Convert.ToDateTime(employeeTable.Rows[0]["dtEmployeeStartDate"]);
			else
				employeeStartDate = new DateTime(DateTime.Today.Year, 1, 1);

			int nYearID = Ultis.NYearID(employeeStartDate, startDate);

			double nLeaveQty;
			if (isFullDay)
				nLeaveQty = 1.0;
			else
				nLeaveQty = 0.5;

			if (!ACMS.Convert.ToBoolean(employeeTable.Rows[0]["fProbation"]))
			{
				DataTable leaveTable = SqlHelperUtils.ExecuteDataTableSP("pr_GetUpdateAnnualLeaveBalanceInfo", 
					new SqlParameter("@inEmployeeID", nEmployeeID),
					new SqlParameter("@inLeaveID", nLeaveID),
					new SqlParameter("@inYearID", nYearID));

				TimeSpan dayDifferent = startDate - (employeeStartDate.AddYears(nYearID - 1));
				double leaveEarned = Convert.ToDouble(leaveTable.Rows[0]["inLeaveMaxQty"]) / 365.00 * dayDifferent.Days;
				leaveEarned = Math.Round(leaveEarned, 0);

				double nLeaveBalance = leaveEarned - Convert.ToDouble(leaveTable.Rows[0]["inSumLeaveQty"]) +
					Convert.ToDouble(leaveTable.Rows[0]["inSumBFLeaveQty"]);

				if (nLeaveBalance >= nLeaveQty)
				{
					EditLeave(nLeaveID, nEmployeeID, nYearID, strRemarks, nLeaveQty, 0, 0, 0, isFullDay, startDate, endDate);
				}
				else if (nLeaveBalance >= 0)
				{
					EditLeave(nLeaveID, nEmployeeID, nYearID, strRemarks, nLeaveBalance, nLeaveQty - nLeaveBalance, 0, 0, 
						isFullDay, startDate, endDate);
				}
				else
				{
					EditLeave(nLeaveID, nEmployeeID, nYearID, strRemarks, 0, nLeaveQty, 0, 0, isFullDay, startDate, endDate);
				}
			}
			else
			{
				EditLeave(nLeaveID, nEmployeeID, nYearID, strRemarks, 0, nLeaveQty, 0, 0, isFullDay, startDate, endDate);
			}
		}

		private void EditLeave(int nLeaveID, int nEmployeeID, int nYearID, string strRemarks, double nLeaveQty, 
			double nUnpaidLeaveQty, double nTimeOffQty, double nUnpaidTimeOff, bool isFullDay, DateTime startDate, DateTime endDate)
		{
			SqlHelperUtils.ExecuteNonQuerySP("pr_tblLeave_Update", 
				new SqlParameter("@inLeaveID", nLeaveID),
				new SqlParameter("@inEmployeeID", nEmployeeID),
				new SqlParameter("@inYearID", nYearID),
				new SqlParameter("@sstrRemarks", strRemarks),
				new SqlParameter("@dadtStartTime", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, startDate),
				new SqlParameter("@dadtEndTime", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, endDate),
				new SqlParameter("@fnLeaveQuantity", nLeaveQty),
				new SqlParameter("@fnUnpaidLeave", nUnpaidLeaveQty),
				new SqlParameter("@fnTimeOffQuantity", nTimeOffQty),
				new SqlParameter("@fnUnpaidTimeOff", nUnpaidTimeOff),
				new SqlParameter("@bfFullDay", isFullDay));
		}
		#endregion

		#region ListLeaveStatus enum
		public enum ListLeaveStatus
		{
			PendingApproval,
			Approved,
			Rejected,
			Cancelled,
			All
		}
		#endregion
	}
}
