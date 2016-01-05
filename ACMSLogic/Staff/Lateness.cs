using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using ACMS.Utils;

namespace ACMSLogic.Staff
{
	/// <summary>
	/// Summary description for Lateness.
	/// </summary>
	public class Lateness
	{
		private const string ROSTERTABLE = "Roster";
		private const string TIMECARDTABLE = "TimeCard";
		private const string LEAVETABLE = "Leave";
		private const string LATENESSTABLE = "Lateness";
		private DataSet myResultDataSet;
		private DateTime startDate;
		private DateTime endDate;
		private int nEmployeeID;

		public DataTable LatenessTable
		{
			get {return myResultDataSet.Tables[LATENESSTABLE];}
		}

		public Lateness()
		{
		}

		public void GetLateness(int nEmployeeID, Month aMonth, int aYear)
		{
			this.nEmployeeID = nEmployeeID;
			Ultis.DatesRange(out startDate, out endDate, aMonth, aYear);
			GetLatenessData();
			GenerateLatenessTable();
			CalculateLateness();
		}

		private void GetLatenessData()
		{
			SqlParameter paramEmployeeID = new SqlParameter("@inEmployeeID", nEmployeeID);
			SqlParameter paramStartDate = new SqlParameter("@ddtStartDate", startDate);
			SqlParameter paramEndDate = new SqlParameter("@ddtEndDate", endDate);
			myResultDataSet = SqlHelperUtils.ExecuteDatasetSP("pr_SelectLatenessTable", paramEmployeeID, paramStartDate,
				paramEndDate);
			myResultDataSet.Tables[0].TableName = ROSTERTABLE;
			myResultDataSet.Tables[1].TableName = TIMECARDTABLE;
			myResultDataSet.Tables[2].TableName = LEAVETABLE;

			myResultDataSet.Tables[TIMECARDTABLE].DefaultView.Sort = "dtDate, strBranchCode";
		}

		private void GenerateLatenessTable()
		{
			DataTable table1 = new DataTable();
			table1.TableName = LATENESSTABLE;
			table1.Columns.Add(new DataColumn("nRosterID", typeof(int)));
			table1.Columns.Add(new DataColumn("dtDate", typeof(DateTime)));
			table1.Columns.Add(new DataColumn("strBranchCode", typeof(string)));
			table1.Columns.Add(new DataColumn("strType", typeof(string)));
			table1.Columns.Add(new DataColumn("dtExpected", typeof(DateTime)));
			table1.Columns.Add(new DataColumn("dtActual", typeof(DateTime)));
			table1.Columns.Add(new DataColumn("nLateness", typeof(decimal)));
			myResultDataSet.Tables.Add(table1);
		}

		private void CalculateLateness()
		{
			DataTable timeCardTable = myResultDataSet.Tables[TIMECARDTABLE];
            //int i = 0;
            bool nMorning = true;
			foreach (DataRow rRoster in myResultDataSet.Tables[ROSTERTABLE].Rows)
			{
				string select = "dtDate='" +rRoster["dtDate"] +"'";
				//timesheet with branch
				//string select = "dtDate='" +rRoster["dtDate"] +"' AND strBranchCode='" +rRoster["strBranchCode"] +"'";
				DateTime dtExpected1 = Convert.ToDateTime(rRoster["dtStartTime"]);
				DataRow[] rSelectTimeCard = timeCardTable.Select(select, "dtTime");
                DataRow[] rDayRoster = myResultDataSet.Tables[ROSTERTABLE].Select(select,"dtStartTime");
				DataRow[] rLeave1 = myResultDataSet.Tables[LEAVETABLE].Select("dtStartTime >= '" +dtExpected1.Date +"' AND dtEndTime < '"
					+dtExpected1.AddDays(1).Date +"'");
              
				//multi shift
                if (rDayRoster.Length < 2)
                {
                    //Come to work.
                    #region 1 roster in 1 day
                    if (rSelectTimeCard.Length > 0)
                    {
                        // COrrect time in and out
                        //SHould check got how many roster

                        if (rSelectTimeCard.Length >= 2)
                        {
                            //First row is come
                            AddLateness(rRoster, rSelectTimeCard[0], true);
                            //Last row is back
                            AddLateness(rRoster, rSelectTimeCard[rSelectTimeCard.Length - 1], false);
                        }
                        else //clock in 1 time or none
                        {
                            AddLateness(rRoster, rSelectTimeCard[0], true);
                            AddLateness(rRoster, rSelectTimeCard[0], false);
                        }
                    }
                    else
                    {

                        //Not come to work. or on leave
                        DateTime dtExpected = Convert.ToDateTime(rRoster["dtStartTime"]);
                        //Positive or Negative?
                        TimeSpan lateness = Convert.ToDateTime(rRoster["dtEndTime"]) - Convert.ToDateTime(rRoster["dtStartTime"]);


                        //Check for leave
                        //object actualTime = rSelectTimeCard[0];
                        DataRow[] rLeave = myResultDataSet.Tables[LEAVETABLE].Select("dtStartTime >= '" + dtExpected.Date + "' AND dtEndTime < '"
                            + dtExpected.AddDays(1).Date + "'");
                        if (rLeave != null && rLeave.Length == 1)
                        {
                            // NOt Full day leave, check for lateness
                            if (!ACMS.Convert.ToBoolean(rLeave[0]["fFullDay"]))
                            {
                                TimeSpan LeaveSpan = Convert.ToDateTime(rLeave[0]["dtEndTime"]) - Convert.ToDateTime(rLeave[0]["dtStartTime"]);
                                TimeSpan HalfDayLateness = lateness - LeaveSpan;
                                if (HalfDayLateness.TotalMinutes > 60)
                                {
                                    DataRow rNew = myResultDataSet.Tables[LATENESSTABLE].NewRow();
                                    rNew.BeginEdit();
                                    rNew["nRosterID"] = rRoster["nRosterID"];
                                    rNew["dtDate"] = rRoster["dtDate"];
                                    rNew["strBranchCode"] = rRoster["strBranchCode"];
                                    rNew["strType"] = "Time In";
                                    rNew["dtExpected"] = dtExpected;
                                    rNew["dtActual"] = DBNull.Value;//rRoster["dtStartTime"];
                                    rNew["nLateness"] = HalfDayLateness.TotalMinutes - 60;
                                    rNew.EndEdit();
                                    myResultDataSet.Tables[LATENESSTABLE].Rows.Add(rNew);
                                }
                            }
                        }
                        else if (rLeave.Length == 2)
                        {
                            // 1 shift is half day, anotner is time off
                            TimeSpan LeaveSpan1 = Convert.ToDateTime(rLeave[0]["dtEndTime"]) - Convert.ToDateTime(rLeave[0]["dtStartTime"]);
                            TimeSpan LeaveSpan2 = Convert.ToDateTime(rLeave[1]["dtEndTime"]) - Convert.ToDateTime(rLeave[1]["dtStartTime"]);
                            TimeSpan TotalLateness = lateness - (LeaveSpan1 + LeaveSpan2);

                            if (TotalLateness.TotalMinutes > 60)
                            {
                                DataRow rNew = myResultDataSet.Tables[LATENESSTABLE].NewRow();
                                rNew.BeginEdit();
                                rNew["nRosterID"] = rRoster["nRosterID"];
                                rNew["dtDate"] = rRoster["dtDate"];
                                rNew["strBranchCode"] = rRoster["strBranchCode"];
                                rNew["strType"] = "Time In";
                                rNew["dtExpected"] = dtExpected;
                                rNew["dtActual"] = DBNull.Value;//rRoster["dtStartTime"];
                                rNew["nLateness"] = TotalLateness.TotalMinutes - 60;
                                rNew.EndEdit();
                                myResultDataSet.Tables[LATENESSTABLE].Rows.Add(rNew);
                            }


                        }

                        else
                        {
                            DataRow rNew = myResultDataSet.Tables[LATENESSTABLE].NewRow();
                            rNew.BeginEdit();
                            rNew["nRosterID"] = rRoster["nRosterID"];
                            rNew["dtDate"] = rRoster["dtDate"];
                            rNew["strBranchCode"] = rRoster["strBranchCode"];
                            rNew["strType"] = "Time In";
                            rNew["dtExpected"] = dtExpected;
                            rNew["dtActual"] = DBNull.Value;//rRoster["dtStartTime"];
                            rNew["nLateness"] = lateness.TotalMinutes;
                            rNew.EndEdit();
                            myResultDataSet.Tables[LATENESSTABLE].Rows.Add(rNew);
                        }


                    }
                    #endregion
                }
                else if (rDayRoster.Length >= 2)
                {
                    #region 2 roster in 1 day
                    //come to work
                    // Get the 1 st roster and check is that any lateness
                    
                    if (rSelectTimeCard.Length > 0)
                    {
                                                             
                            //should check 4 time card instead of 2
                            if (rSelectTimeCard.Length == 4)
                            {
                                //for (int i = 0; i < 2; i++)
                                //{
                                if (nMorning == true)
                                    {
                                        //First row is come
                                        AddLateness(rRoster, rSelectTimeCard[0], true);
                                        //Last row is back
                                        AddLateness(rRoster, rSelectTimeCard[1], false);
                                        nMorning = false;
                                    }
                                    else
                                    {
                                        //First row is come
                                        AddLateness(rDayRoster[1], rSelectTimeCard[2], true);
                                        //Last row is back
                                        AddLateness(rDayRoster[1], rSelectTimeCard[3], false);
                                        nMorning = true;
                                    }                                
                            }
                            else //clock in 1 time or none
                            {
                                AddLateness(rRoster, rSelectTimeCard[0], true);
                                AddLateness(rRoster, rSelectTimeCard[0], false);
                            }
                            
                        
                    }
                    else
                    {

                        //Not come to work. or on leave
                        DateTime dtExpected = Convert.ToDateTime(rRoster["dtStartTime"]);
                        //Positive or Negative?
                        TimeSpan lateness = Convert.ToDateTime(rRoster["dtEndTime"]) - Convert.ToDateTime(rRoster["dtStartTime"]);


                        //Check for leave
                        //object actualTime = rSelectTimeCard[0];
                        DataRow[] rLeave = myResultDataSet.Tables[LEAVETABLE].Select("dtStartTime >= '" + dtExpected.Date + "' AND dtEndTime < '"
                            + dtExpected.AddDays(1).Date + "'");
                        if (rLeave != null && rLeave.Length == 1)
                        {
                            // NOt Full day leave, check for lateness
                            if (!ACMS.Convert.ToBoolean(rLeave[0]["fFullDay"]))
                            {
                                TimeSpan LeaveSpan = Convert.ToDateTime(rLeave[0]["dtEndTime"]) - Convert.ToDateTime(rLeave[0]["dtStartTime"]);
                                TimeSpan HalfDayLateness = lateness - LeaveSpan;
                                if (HalfDayLateness.TotalMinutes > 60)
                                {
                                    DataRow rNew = myResultDataSet.Tables[LATENESSTABLE].NewRow();
                                    rNew.BeginEdit();
                                    rNew["nRosterID"] = rRoster["nRosterID"];
                                    rNew["dtDate"] = rRoster["dtDate"];
                                    rNew["strBranchCode"] = rRoster["strBranchCode"];
                                    rNew["strType"] = "Time In";
                                    rNew["dtExpected"] = dtExpected;
                                    rNew["dtActual"] = DBNull.Value;//rRoster["dtStartTime"];
                                    rNew["nLateness"] = HalfDayLateness.TotalMinutes - 60;
                                    rNew.EndEdit();
                                    myResultDataSet.Tables[LATENESSTABLE].Rows.Add(rNew);
                                }
                            }
                        }
                        else if (rLeave.Length == 2)
                        {
                            // 1 shift is half day, anotner is time off
                            TimeSpan LeaveSpan1 = Convert.ToDateTime(rLeave[0]["dtEndTime"]) - Convert.ToDateTime(rLeave[0]["dtStartTime"]);
                            TimeSpan LeaveSpan2 = Convert.ToDateTime(rLeave[1]["dtEndTime"]) - Convert.ToDateTime(rLeave[1]["dtStartTime"]);
                            TimeSpan TotalLateness = lateness - (LeaveSpan1 + LeaveSpan2);

                            if (TotalLateness.TotalMinutes > 60)
                            {
                                DataRow rNew = myResultDataSet.Tables[LATENESSTABLE].NewRow();
                                rNew.BeginEdit();
                                rNew["nRosterID"] = rRoster["nRosterID"];
                                rNew["dtDate"] = rRoster["dtDate"];
                                rNew["strBranchCode"] = rRoster["strBranchCode"];
                                rNew["strType"] = "Time In";
                                rNew["dtExpected"] = dtExpected;
                                rNew["dtActual"] = DBNull.Value;//rRoster["dtStartTime"];
                                rNew["nLateness"] = TotalLateness.TotalMinutes - 60;
                                rNew.EndEdit();
                                myResultDataSet.Tables[LATENESSTABLE].Rows.Add(rNew);
                            }


                        }

                        else
                        {
                            DataRow rNew = myResultDataSet.Tables[LATENESSTABLE].NewRow();
                            rNew.BeginEdit();
                            rNew["nRosterID"] = rRoster["nRosterID"];
                            rNew["dtDate"] = rRoster["dtDate"];
                            rNew["strBranchCode"] = rRoster["strBranchCode"];
                            rNew["strType"] = "Time In";
                            rNew["dtExpected"] = dtExpected;
                            rNew["dtActual"] = DBNull.Value;//rRoster["dtStartTime"];
                            rNew["nLateness"] = lateness.TotalMinutes;
                            rNew.EndEdit();
                            myResultDataSet.Tables[LATENESSTABLE].Rows.Add(rNew);
                        }


                    }
                    #endregion
                }
            }
			}
			

		private void AddLateness(DataRow rRoster, DataRow rTimeCard, bool isTimeIn)
		{
			DateTime dtExpected = Convert.ToDateTime(isTimeIn ? rRoster["dtStartTime"] : rRoster["dtEndTime"]);
			//Positive or Negative?
			TimeSpan lateness;		
			string halfday;
			int TimeOff;

			if (isTimeIn)
				lateness = Convert.ToDateTime(rTimeCard["dtTime"]) - dtExpected;
			else
				lateness = dtExpected - Convert.ToDateTime(rTimeCard["dtTime"]);
			//Not lateness
			if (lateness.TotalMinutes < 1)
				return;

			//Check for leave
			object actualTime = rTimeCard["dtTime"];
			DataRow[] rLeave = myResultDataSet.Tables[LEAVETABLE].Select("dtStartTime >= '" +dtExpected.Date +"' AND dtEndTime < '"
				+dtExpected.AddDays(1).Date +"'");
			if (rLeave != null && rLeave.Length > 0)
			{
				//Full day leave, don't need check for lateness
				if (ACMS.Convert.ToBoolean(rLeave[0]["fFullDay"]))
					return;
				else
				{
					//check start time is 1st half or 2nd half agaist with time card
					/*DateTime ActualExpectedSpan;
					if (Convert.ToDateTime(rLeave[0]["dtStartTime"])>Convert.ToDateTime(rRoster["dtStartTime"]))
						ActualExpectedSpan = Convert.ToDateTime(isTimeIn ? rRoster["dtStartTime"] : rLeave[0]["dtStartTime"]);						
							else
						ActualExpectedSpan = Convert.ToDateTime(isTimeIn ? rLeave[0]["dtEndTime"]: rRoster["dtEndTime"]);
					*/
					DateTime ActualExpectedSpan;
					if (isTimeIn)
					{
						halfday = rLeave[0]["nLeaveQuantity"].ToString();
						TimeOff = ACMS.Convert.ToInt32(rLeave[0]["nTimeOffQuantity"]);
						if (Convert.ToDateTime(rLeave[0]["dtStartTime"])>Convert.ToDateTime(rRoster["dtStartTime"]))
						
							ActualExpectedSpan = Convert.ToDateTime(rRoster["dtStartTime"]);	
							else
						    ActualExpectedSpan = Convert.ToDateTime(rLeave[0]["dtEndTime"]);

						TimeSpan tempLateness = Convert.ToDateTime(rTimeCard["dtTime"]) - ActualExpectedSpan;
						if (tempLateness.TotalMinutes >0)
						lateness = Convert.ToDateTime(rTimeCard["dtTime"]) - ActualExpectedSpan;
						else 
							lateness = ActualExpectedSpan-ActualExpectedSpan;
													
					}
					
					else
					{
						halfday = rLeave[0]["nLeaveQuantity"].ToString();
						TimeOff = ACMS.Convert.ToInt32(rLeave[0]["nTimeOffQuantity"]);
						if (Convert.ToDateTime(rLeave[rLeave.Length-1]["dtEndTime"])>Convert.ToDateTime(rRoster["dtEndTime"]))
						
							ActualExpectedSpan = Convert.ToDateTime(rRoster["dtEndTime"]);	
							//ActualExpectedSpan = Convert.ToDateTime(rLeave[rLeave.Length-1]["dtStartTime"]);
							else
						   // ActualExpectedSpan = Convert.ToDateTime(rLeave[rLeave.Length-1]["dtEndTime"]);	
							ActualExpectedSpan = Convert.ToDateTime(rLeave[rLeave.Length-1]["dtStartTime"]);
	
						TimeSpan tempLateness1 = ActualExpectedSpan - Convert.ToDateTime(rTimeCard["dtTime"]);
						if (tempLateness1.TotalMinutes >0)
							lateness = ActualExpectedSpan - Convert.ToDateTime(rTimeCard["dtTime"]);
						else 
							lateness = ActualExpectedSpan-ActualExpectedSpan;
					}			
					
					//Not lateness, 61 is because 1 hour lunch break
					if (isTimeIn && lateness.TotalMinutes >= 1)
					{
						DataRow rNew = myResultDataSet.Tables[LATENESSTABLE].NewRow();
						rNew.BeginEdit();
						rNew["nRosterID"] = rRoster["nRosterID"];
						rNew["dtDate"] = rRoster["dtDate"];
						rNew["strBranchCode"] = rRoster["strBranchCode"];
						rNew["strType"] = isTimeIn ? "Time In" : "Time Out";
						rNew["dtExpected"] = dtExpected;
						rNew["dtActual"] = actualTime;//rTimeCard["dtTime"];					
						rNew["nLateness"] = Math.Floor(lateness.TotalMinutes); // 1 hour lunch break						
						rNew.EndEdit();
						myResultDataSet.Tables[LATENESSTABLE].Rows.Add(rNew);
						return;
					}
					else
					{

						if (halfday == "0.5" ||TimeOff > 4)					
						{
							DataRow rNew = myResultDataSet.Tables[LATENESSTABLE].NewRow();
							rNew.BeginEdit();
							rNew["nRosterID"] = rRoster["nRosterID"];
							rNew["dtDate"] = rRoster["dtDate"];
							rNew["strBranchCode"] = rRoster["strBranchCode"];
							rNew["strType"] = isTimeIn ? "Time In" : "Time Out";
							rNew["dtExpected"] = dtExpected;
							rNew["dtActual"] = actualTime;//rTimeCard["dtTime"];

							// Have problem when staff late is 3 minute ??
							if (lateness.TotalMinutes > 60)
								rNew["nLateness"] = lateness.TotalMinutes - 60; // 1 hour lunch break
							else
							{
								rNew["nLateness"] = 0; 
								return;
							}

							rNew.EndEdit();
							myResultDataSet.Tables[LATENESSTABLE].Rows.Add(rNew);
							return;
						}
						
					}
				/*	else if (lateness.TotalMinutes >= 1)
					{
						
						DataRow rNew1 = myResultDataSet.Tables[LATENESSTABLE].NewRow();
						rNew1.BeginEdit();
						rNew1["nRosterID"] = rRoster["nRosterID"];
						rNew1["dtDate"] = rRoster["dtDate"];
						rNew1["strBranchCode"] = rRoster["strBranchCode"];
						rNew1["strType"] = isTimeIn ? "Time In" : "Time Out";
						rNew1["dtExpected"] = dtExpected;
						rNew1["dtActual"] = actualTime;//rTimeCard["dtTime"];
						rNew1["nLateness"] = lateness.TotalMinutes; 
						rNew1.EndEdit();
						myResultDataSet.Tables[LATENESSTABLE].Rows.Add(rNew1);
						return;
								
					}*/
				}
			}

			if (lateness.TotalMinutes >= 1)
			{
			DataRow rNew2 = myResultDataSet.Tables[LATENESSTABLE].NewRow();
			rNew2.BeginEdit();
			rNew2["nRosterID"] = rRoster["nRosterID"];
			rNew2["dtDate"] = rRoster["dtDate"];
			rNew2["strBranchCode"] = rRoster["strBranchCode"];
			rNew2["strType"] = isTimeIn ? "Time In" : "Time Out";
			rNew2["dtExpected"] = dtExpected;
			rNew2["dtActual"] = actualTime;//rTimeCard["dtTime"];
			rNew2["nLateness"] = Math.Floor(lateness.TotalMinutes); 
			rNew2.EndEdit();
			myResultDataSet.Tables[LATENESSTABLE].Rows.Add(rNew2);
			}
		}
	}
}