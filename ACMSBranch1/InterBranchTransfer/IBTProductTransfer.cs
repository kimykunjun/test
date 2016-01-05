using System;

namespace ACMS.ACMSBranch.InterBranchTransfer
{
	/// <summary>
	/// Summary description for IBTProductTransfer.
	/// </summary>
	public class IBTProductTransfer
	{
		private string strProductCode;

		private int quantity;

		private int nEntryID;

		public IBTProductTransfer()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public IBTProductTransfer(string strProductCode,int quantity)
		{
			this.strProductCode=strProductCode;
			this.quantity = quantity;
		}

		public IBTProductTransfer(string strProductCode,int quantity,int nEntryID)
		{
			this.strProductCode=strProductCode;
			this.quantity = quantity;
			this.nEntryID=nEntryID;
		}

		public string StrProductCode
		{
			set{strProductCode=value;}
			get{return strProductCode;}
		}

		public int Quantity
		{
			set{quantity=value;}
			get{return quantity;}
		}

		public int NEntryID
		{
			set{nEntryID=value;}
			get{return nEntryID;}
		}
	}
}
