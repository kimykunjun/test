using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using ACMS.Utils;

namespace ACMSLogic.Staff
{
	/// <summary>
	/// Summary description for Contacts.
	/// </summary>
	public class Contacts
	{
		public Contacts()
		{
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

        public bool CheckDupNRIC(string strNricfin)
        {
            DataSet ContactDataSet = SqlHelperUtils.ExecuteDatasetSP("sp_tblContacts_chkDupNRIC", new SqlParameter("@strNRICFIN", strNricfin));
            bool nStatus = Convert.ToBoolean(ContactDataSet.Tables[0].Rows[0]["nStatus"]);

            if (nStatus)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckDupMobileNo(string strMobileNo)
        {
            DataSet ContactDataSet = SqlHelperUtils.ExecuteDatasetSP("sp_tblContacts_chkDupMobileNo", new SqlParameter("@strMobileNo", strMobileNo));
            bool nStatus = Convert.ToBoolean(ContactDataSet.Tables[0].Rows[0]["nStatus"]);

            if (nStatus)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool GetMemberNRIC(string strNricfin, string strMobileNo)
        {
            DataSet ContactDataSet = SqlHelperUtils.ExecuteDatasetSP("sp_tblContacts_VerifyNRICMobileNo",
                    new SqlParameter("@strNRICFIN", strNricfin),
                    new SqlParameter("@strMobileNo", strMobileNo));
            bool nStatus = Convert.ToBoolean(ContactDataSet.Tables[0].Rows[0]["nStatus"]);
         
            if (nStatus)
               return true;
            else
               return false;
           
        }
    
        public bool DeleteContact(int nContactId)
        {
            SqlHelperUtils.ExecuteNonQuerySP("sp_tblContacts_Delete", new SqlParameter("@inContactId", nContactId),
                SqlHelperUtils.paramErrorCode);
            return true;
        }

		public DataTable ListContacts(string strBranchCode,int nstatus,string txtSearchString)
		{
            return SqlHelperUtils.ExecuteDataTableSP("sp_tblContactsNew_SelectAllWnBranchCodeLogic",
                new SqlParameter("@strBranchCode", strBranchCode),                
                new SqlParameter("@nstatus", nstatus),
                new SqlParameter("@strSearchString", txtSearchString), SqlHelperUtils.paramErrorCode);
		}

        //DEREK DNC New Contact Insert Function
        //DEREK DNC New Contact Update Function
        public void NewContact(int nEmployeeID, string strContactName, string strNric, string strBranchCode, string strEmail,
            string strGender, DateTime dob, int nMediaSourceID, string strMediaSource, string strMobileNo, string strRemarks,int nStatus)
        {
            SqlHelperUtils.ExecuteNonQuerySP("sp_tblContactsNew_Insert",
                new SqlParameter("@inEmployeeID", nEmployeeID),
                new SqlParameter("@sstrContactName", strContactName),
                new SqlParameter("@sstrNRICFIN", strNric),
                new SqlParameter("@sstrBranchCode", strBranchCode),
                new SqlParameter("@sstrEmail", strEmail),
                new SqlParameter("@sstrGender", strGender),
                new SqlParameter("@dadtDOB", dob == DateTime.Now.Date ? System.Data.SqlTypes.SqlDateTime.Null : dob),
                new SqlParameter("@inMediaSourceID", nMediaSourceID),
                new SqlParameter("@sstrMediaSource", strMediaSource),
                new SqlParameter("@sstrMobileNo", strMobileNo),
                new SqlParameter("@sstrRemarks", strRemarks),
                new SqlParameter("@inStatus", nStatus),
                new SqlParameter("@inContactId", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, new Int32()),
                SqlHelperUtils.paramErrorCode);
        }


        public void EditContact(int nContactID, int nEmployeeID, string strContactName, string strNric, string strBranchCode, string strEmail,
            string strGender, DateTime dob, int nMediaSourceID, string strMediaSource, string strMobileNo, string strRemarks, int nStatus)
		{
            SqlHelperUtils.ExecuteNonQuerySP("sp_tblContactsNew_Update", 
				new SqlParameter("@inContactId", nContactID),
             new SqlParameter("@inEmployeeID", nEmployeeID),
                new SqlParameter("@sstrContactName", strContactName),
                new SqlParameter("@sstrNRICFIN", strNric),
                new SqlParameter("@sstrBranchCode", strBranchCode),
                new SqlParameter("@sstrEmail", strEmail),
                new SqlParameter("@sstrGender", strGender),
                new SqlParameter("@dadtDOB", dob.Date == DateTime.Now.Date ? System.Data.SqlTypes.SqlDateTime.Null : dob),
                new SqlParameter("@inMediaSourceID", nMediaSourceID),
                new SqlParameter("@sstrMediaSource", strMediaSource),
                new SqlParameter("@sstrMobileNo", strMobileNo),
                new SqlParameter("@sstrRemarks", strRemarks),
                new SqlParameter("@inStatus", nStatus),
				SqlHelperUtils.paramErrorCode);
		}

		
	}
}