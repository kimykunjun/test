using System;
using System.Data;
using System.Configuration;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using ACMSDAL;

namespace ACMSLogic
{
	/// <summary>
	/// Summary description for IPP.
	/// </summary>
	public class IPP
	{
		private AppSettingsReader configReader;
		private string connString = string.Empty;
		private DataTable myDataTable;
		private DataTable dtblPreset;
		private DataTable dtblIPPLookupEdit;
		private TblIPP myIPP;

		
		public IPP()
		{
			configReader = new AppSettingsReader();
			connString = configReader.GetValue("Main.ConnectionString", typeof(string)).ToString();

			myIPP = new TblIPP();
			dtblPreset = myIPP.SelectAllIPPMembership();
		}

		private void Init()
		{
			myIPP = new TblIPP();
			myDataTable = myIPP.SelectAll();
		}
		
		private void InitLookupEdit(int Id)
		{
			myIPP = new TblIPP();
			myIPP.NIPPID = Id;
			dtblIPPLookupEdit = myIPP.SelectOne();
			
		}

		public DataTable Table
		{
			get { return myDataTable; }
		}

		public DataTable SelectPresetTable
		{
			get {return dtblPreset;}
			set {dtblPreset = value;}
		}

		public DataTable SelectOne
		{
			get {return dtblIPPLookupEdit;}
			set {dtblIPPLookupEdit = value;}
		}

		public void RefreshPreset(int preset, string IPPId)
		{
			if (preset == 0)
				dtblPreset = myIPP.SelectNotSent();
			else if (preset == 1)
				dtblPreset = myIPP.SelectSentNotRec();
			else
			{
				myIPP.NIPPID = Convert.ToInt32(IPPId);
				dtblPreset = myIPP.SelectOne();
			}
		}

		public void Refresh()
		{
			dtblPreset = myIPP.SelectAllIPPMembership();
		}

		public void AddNewIPP(string MemberId, string BranchCode, string BankCode, string CCNo, SqlInt32 nMonths, string MerchantNo)
		{
			myIPP.StrMembershipID = MemberId;
			myIPP.StrBranchCode = BranchCode;
			myIPP.StrBankCode = BankCode;
			myIPP.StrCreditCardNo = CCNo;
			myIPP.NMonths = nMonths;
			myIPP.DtDate = DateTime.Now.Date;
			myIPP.Insert();
			
		}

		public void UpdateIPPSend(DateTime SentDate, SqlInt32 IPPId)
		{
			myIPP.NIPPID = IPPId;
			myIPP.dtSentDate = SentDate;
						
			myIPP.UpdateSendMembershipIDLogic();
			
		}

	
		public void UpdateOne(SqlInt32 IPPId, string BankCode, string CCNo, SqlInt32 nMonths)
		{
			myIPP.NIPPID = IPPId;
			myIPP.StrBankCode = BankCode;
			myIPP.StrCreditCardNo = CCNo;
			myIPP.NMonths = nMonths;
					
			myIPP.UpdateOne();
		
		}

		public void UpdateIPPReceived(SqlDateTime ReceivedDate, SqlInt32 Status, SqlInt32 IPPId)
		{
			myIPP.NIPPID = IPPId;
			myIPP.dtReceivedDate = ReceivedDate;
			myIPP.nIPPStatus = Status;
						
			myIPP.UpdateSendMembershipIDLogic();
			
		}

		public bool Delete(SqlInt32 Id)
		{
			myIPP.NIPPID = Id;
			return myIPP.Delete();
		}

	}
}

