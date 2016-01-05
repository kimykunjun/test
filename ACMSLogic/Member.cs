using System;
using System.Data;
using System.Data.SqlClient;
using ACMSDAL;

namespace ACMSLogic
{
	/// <summary>
	/// Summary description for Member.
	/// </summary>
	/// 
	public class Member
	{
		private DataTable myDataTable;
		private TblMember myMember;

		public Member()
		{
			//
			// TODO: Add constructor logic here
			//
			Init();
		}

		private void Init()
		{
			myMember = new TblMember();
			myDataTable = myMember.SelectAllForLookupEdit();
		}
		
		public DataTable Table
		{
			get { return myDataTable; }
		}

		public void Refresh()
		{
			myDataTable = myMember.SelectAllForLookupEdit();
		}
	}
}
