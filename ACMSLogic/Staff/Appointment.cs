using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using ACMS.Utils;
using ACMSDAL;

namespace ACMSLogic.Staff
{
	/// <summary>
	/// Summary description for Appointment.
	/// </summary>
	public class Appointment
	{
		public Appointment()
		{
		}

		public DataTable ListAppointment(string strBranchCode, DateTime startDate, DateTime endDate)
		{
			return SqlHelperUtils.ExecuteDataTableSP("pr_tblAppointment_SelectAllWnBranchCode",
				new SqlParameter("@strBranchCode", strBranchCode),
				new SqlParameter("@ddtStartDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, startDate),
				new SqlParameter("@ddtEndDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, endDate));
		}

		public void NewAppoinment(int nEmployeeID, DateTime dtDate, DateTime dtStartTime, DateTime dtEndTime,
            string strOrganization, string strBranchCode, int nContactID, string strRemarks, string strMembershipID, int nServedBy)
		{
				SqlHelperUtils.ExecuteNonQuerySP("pr_tblAppointment_Insert", 
					new SqlParameter("@inEmployeeID", nEmployeeID),
					new SqlParameter("@dadtDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, dtDate),
					new SqlParameter("@dadtStartTime", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, dtStartTime),
					new SqlParameter("@dadtEndTime", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, dtEndTime),
					new SqlParameter("@sstrOrganization", strOrganization),
                    new SqlParameter("@sstrBranchCode", strBranchCode),
                    new SqlParameter("@inContactId", nContactID),
                    new SqlParameter("@sstrRemarks", strRemarks),
                    new SqlParameter("@sstrMembershipID", strMembershipID),
                    new SqlParameter("@inServedBy", nServedBy));
		}

        

		public void EditAppointment(int nAppointmentId, int nEmployeeID,DateTime dtDate, DateTime dtStartTime, DateTime dtEndTime,
            string strOrganization, string strBranchCode, int nContactID, string strRemarks, int nStatusID, string strMembershipID, int nServedBy)
		{
			SqlHelperUtils.ExecuteNonQuerySP("pr_tblAppointment_Update",
                new SqlParameter("@inAppointmentId", nAppointmentId),
                new SqlParameter("@inEmployeeID", nEmployeeID),
				new SqlParameter("@dadtDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, dtDate),
				new SqlParameter("@dadtStartTime", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, dtStartTime),
				new SqlParameter("@dadtEndTime", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, dtEndTime),
                new SqlParameter("@sstrOrganization", strOrganization),
                new SqlParameter("@sstrBranchCode", strBranchCode),
                new SqlParameter("@inContactId", nContactID),
                new SqlParameter("@sstrRemarks", strRemarks),
                new SqlParameter("@inStatus", nStatusID),
                new SqlParameter("@sstrMembershipID", strMembershipID),
                new SqlParameter("@inServedBy", nServedBy));
		}

		public bool DeleteAppointment(int nAppointmentId)
		{
			try
			{
				SqlHelperUtils.ExecuteNonQuerySP("sp_tblAppointment_Delete", new SqlParameter("@inAppointmentId", nAppointmentId),
					SqlHelperUtils.paramErrorCode);
			}
			catch 
			{
				throw;
			}
			return true;
		}

        public bool VerifyAppointment(int verifyUserID, string verifyUserPassword, int nAppointmentID)
        {
            TblEmployee verifyUser = new TblEmployee();

            verifyUser.NEmployeeID = verifyUserID;

            verifyUser.SelectOne();

            if (verifyUser.StrPassword.IsNull)
                throw new Exception("Invalid User ID or Password");

            if (verifyUser.StrPassword.Value != verifyUserPassword)
                throw new Exception("Invalid User ID or Password");

            TblAppointment myAppointment = new TblAppointment();
            myAppointment.NAppointmentId = nAppointmentID;
            myAppointment.SelectOne();

            if (!myAppointment.NVerifiedBy.IsNull)
                throw new Exception("This appointment have been verified by other staff with the employee ID : " + myAppointment.NVerifiedBy.Value.ToString());
                        
            myAppointment.NVerifiedBy = verifyUserID;
            //myAppointment.NStatus = 1;
            myAppointment.Update();
            return true;
        }

        public bool CloseAppointment(int nAppointmentID)
        {            
            TblAppointment myAppointment = new TblAppointment();
            myAppointment.NAppointmentId = nAppointmentID;
            myAppointment.SelectOne();
            myAppointment.NStatus = 2;
            myAppointment.Update();

            TblContacts myContact = new TblContacts();
            myContact.UpdateLeadStatus(Convert.ToInt32(myAppointment.NContactId.Value), 0);
            return true;
        }

        public bool VerifyAppointmentLimit(int nContactID)
        {
            TblAppointment appt = new TblAppointment();
            DataTable table = appt.LoadData("Select COUNT (*) as nCount From TblAppointment where nContactID = @nContactID group by strReceiptNo", new string[] { "@nContactID" }, new object[] { nContactID });
            decimal netTotal = 0;
            if (table.Rows.Count > 0)
                netTotal = ACMS.Convert.ToDecimal(table.Rows[0]["mSubTotal"]);
            return true;
        }
	}
}
