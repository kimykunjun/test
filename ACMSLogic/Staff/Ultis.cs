using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using ACMS.Utils;

namespace ACMSLogic.Staff
{
	/// <summary>
	/// Summary description for Ultis.
	/// </summary>
	public class Ultis
	{
		private Ultis()
		{
		}

		public static void DatesRange(out DateTime startDate, out DateTime endDate, Month month, int year)
		{
			if (month == Month.January)
			{
				startDate = new DateTime(year, 1, 1);
				endDate = new DateTime(year, 2, 1);
			}
			else if (month == Month.February)
			{
				startDate = new DateTime(year, 2, 1);
				endDate = new DateTime(year, 3, 1);
			}
			else if (month == Month.March)
			{
				startDate = new DateTime(year, 3, 1);
				endDate = new DateTime(year, 4, 1);
			}
			else if (month == Month.April)
			{
				startDate = new DateTime(year, 4, 1);
				endDate = new DateTime(year, 5, 1);
			}
			else if (month == Month.May)
			{
				startDate = new DateTime(year, 5, 1);
				endDate = new DateTime(year, 6, 1);
			}
			else if (month == Month.June)
			{
				startDate = new DateTime(year, 6, 1);
				endDate = new DateTime(year, 7, 1);
			}
			else if (month == Month.July)
			{
				startDate = new DateTime(year, 7, 1);
				endDate = new DateTime(year, 8, 1);
			}
			else if (month == Month.August)
			{
				startDate = new DateTime(year, 8, 1);
				endDate = new DateTime(year, 9, 1);
			}
			else if (month == Month.September)
			{
				startDate = new DateTime(year, 9, 1);
				endDate = new DateTime(year, 10, 1);
			}
			else if (month == Month.Octorber)
			{
				startDate = new DateTime(year, 10, 1);
				endDate = new DateTime(year, 11, 1);
			}
			else if (month == Month.November)
			{
				startDate = new DateTime(year, 11, 1);
				endDate = new DateTime(year, 12, 1);
			}
			else //if (month == Month.December)
			{
				startDate = new DateTime(year, 12, 1);
				endDate = new DateTime(year + 1, 1, 1);
			}
		}

		public static void FirstAndLastOfMonth(out DateTime startDate, out DateTime endDate, Month month, int year)
		{
			DatesRange(out startDate, out endDate, month, year);

			startDate = startDate.AddDays(-((int)startDate.DayOfWeek));
			endDate = endDate.AddDays(((int)endDate.DayOfWeek) + 1);
		}

		public static DateTime ToDateTime(int year, int week, int weekday)
		{
			DateTime dt = new DateTime(year, 1, 1); 

			if(dt.DayOfWeek <= DayOfWeek.Thursday)
			{ 
				dt = dt.AddDays(7 * week - 1); 
			}
			else
			{ 
				dt = dt.AddDays(7 * week); 
			} 

			int WeekDay = (dt.DayOfWeek == DayOfWeek.Sunday) ? 6 : Convert.ToInt32(dt.DayOfWeek); 
			//DateTime Monday = (dt.DayOfWeek == DayOfWeek.Monday) ? dt : dt.AddDays(-(WeekDay - 1)); 
			DateTime Sunday = (dt.DayOfWeek == DayOfWeek.Sunday) ? dt : dt.AddDays(7 - WeekDay); 
			return Sunday.AddDays(weekday - 1);
		}

		public static int WeekNumber(DateTime fromDate)
		{
			// Get jan 1st of the year
			DateTime startOfYear = fromDate.AddDays(- fromDate.Day + 1).AddMonths(- fromDate.Month +1);
			// Get dec 31st of the year
			DateTime endOfYear = startOfYear.AddYears(1).AddDays(-1);
			// ISO 8601 weeks start with Monday 
			// The first week of a year includes the first Thursday 
			// DayOfWeek returns 0 for sunday up to 6 for saterday
			int[] iso8601Correction = {7,8,9,10,4,5,6};//{6,7,8,9,10,4,5};
			int nds = fromDate.Subtract(startOfYear).Days  + iso8601Correction[(int)startOfYear.DayOfWeek];
			int wk = nds / 7;
			switch(wk)
			{
				case 0 : 
					// Return weeknumber of dec 31st of the previous year
					return WeekNumber(startOfYear.AddDays(-1));
				case 53 : 
					// If dec 31st falls before thursday it is week 01 of next year
					if (endOfYear.DayOfWeek < DayOfWeek.Thursday)
						return 1;
					else
						return wk;
				default : return wk;
			}
		}

		/// <summary>
		/// Return month from int to Month. Index is start from 1 = January.
		/// </summary>
		/// <param name="month"></param>
		/// <returns></returns>
		public static Month GetMonth(int month)
		{
			if (month == 1)
				return Month.January;
			else if (month == 2)
				return Month.February;
			else if (month == 3)
				return Month.March;
			else if (month == 4)
				return Month.April;
			else if (month == 5)
				return Month.May;
			else if (month == 6)
				return Month.June;
			else if (month == 7)
				return Month.July;
			else if (month == 8)
				return Month.August;
			else if (month == 9)
				return Month.September;
			else if (month == 10)
				return Month.Octorber;
			else if (month == 11)
				return Month.November;
			else
				return Month.December;
		}

		public static void AddColumn(DataTable myTable, string colName, string dataType)
		{
			DataColumn col = new DataColumn(colName);
			col.DataType = System.Type.GetType(dataType);
			myTable.Columns.Add(col);
		}

		public static int NYearID(DateTime employeeStartDate, DateTime leaveStartDate)
		{
			// get the difference in years
			int years = leaveStartDate.Year - employeeStartDate.Year; 
			// subtract another year if we're before the
			// birth day in the current year
			if (leaveStartDate.Month < employeeStartDate.Month || 
				(leaveStartDate.Month == employeeStartDate.Month && leaveStartDate.Day < employeeStartDate.Day)) 
			{
				years--;
			}

			return years + 1;
		}

		public static DataRow EmployeeInfo(int nEmployeeID)
		{
			return SqlHelperUtils.ExecuteDataTableSP("pr_tblEmployee_SelectOne", 
				new SqlParameter("@inEmployeeID", nEmployeeID)).Rows[0];
		}

		public static void ChangePassword(int nEmployeeID, string strPassword)
		{
			SqlHelperUtils.ExecuteNonQuerySP("pr_tblEmployee_ChangePassword", 
				new SqlParameter("@inEmployeeID", nEmployeeID), new SqlParameter("@sstrPassword", strPassword));
		}
	}

	public enum Month
	{
		January,
		February,
		March,
		April,
		May,
		June,
		July,
		August,
		September,
		Octorber,
		November,
		December
	}
}
