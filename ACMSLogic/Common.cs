using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using ACMSDAL;

namespace ACMSLogic.Common
{
	public delegate void SchedulerChangedDelegate(DataRow row); 
	public delegate void EditValueChangedDelegate(string strValue);

	/// <summary>
	/// Summary description for Common.
	/// </summary>

	public class ReceiptContent
	{

	
				
		public const string STR_REDEMPTIONHEADER = "REWARD REDEMPTION VERIFICATION";
		public const string STR_COMPANY_NAME = "AMORE FITNESS PTE LTD";
		public const string STR_INTRODUCEFRIENDSHEADER = "INTRODUCE FRIENDS REWARDS";



	}
}
