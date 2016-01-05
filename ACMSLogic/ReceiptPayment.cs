using System;
using System.Data;
using System.Configuration;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using ACMSDAL;

namespace ACMSLogic
{
	/// <summary>
	/// Summary description for ReceiptPayment.
	/// </summary>
	public class ReceiptPayment
	{
		private AppSettingsReader configReader;
		private string connString = string.Empty;
		private DataTable myDataTable;
		private DataTable dtblPreset;
		private TblReceiptPayment myRP;
		

		
		public ReceiptPayment()
		{
			configReader = new AppSettingsReader();
			connString = configReader.GetValue("Main.ConnectionString", typeof(string)).ToString();

			myRP = new TblReceiptPayment();
			dtblPreset = myRP.SelectAllWnReceiptIPPIDLogic();
		}

		private void Init()
		{
			myRP = new TblReceiptPayment();
			myDataTable = myRP.SelectAll();
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

		public void Refresh()
		{
			dtblPreset = myRP.SelectAll();
		}//

		public void UpdateIPP(SqlString nIPPId,SqlInt32 nPaymentId)
		{
			myRP.NNullIPPId = nIPPId;
			myRP.NPaymentID = nPaymentId;
			
			myRP.UpdateAllWnIPP_PaymentIDLogic();
			
		}

		public bool Delete(SqlInt32 Id)
		{
			myRP.NPaymentID = Id;
			return myRP.Delete();
		}

	}

	}

