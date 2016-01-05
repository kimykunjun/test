using System;

namespace ACMSLogic
{
	/// <summary>
	/// Summary description for AuditTypeID.
	/// </summary>
	public class AuditTypeID
	{
		private AuditTypeID()
		{
		}

		// Please use these, as they are define by Jayson in DBScheme 0.9 (tblAudit).
		public const int MemberRecord = 1;
		public const int MemberCard = 2;
		public const int MemberPackage = 3;
		public const int MemberCreditPackage = 4;
		public const int Receipt = 5;
		public const int Class = 6;
		public const int StockRequest = 7;
		public const int InterBranchTransfer = 8;
		public const int Shift = 9;
		// End

		// User define....
		public const int DeleteMemberCreditPackage = 100;
		public const int TransferMemberCreditPackage = 101;
		public const int ClassAuditTypeID = 6;
		public const int Service = 10;
	}
}
