using System;
using System.Data;
using DevExpress.XtraEditors.Repository;
using ACMS;


namespace ACMS.XtraUtils.LookupEditBuilder
{
	#region LookupEditBuilderBase
	public class LookupEditBuilderBase
	{
        protected DataTable myDataTable, myDataTable1;
		protected RepositoryItemLookUpEdit myLookupEdit;
		protected string myCmdText;
		protected string myDisplayMember;
		protected string myValueMember;
        protected DateTime dtDate;
		internal LookupEditBuilderBase(RepositoryItemLookUpEdit lookupEdit)
		{
			myLookupEdit = lookupEdit;
			myLookupEdit.NullText = "";
		}

		internal LookupEditBuilderBase(DataTable myTable, RepositoryItemLookUpEdit lookupEdit)
		{
			myDataTable = myTable;
			myLookupEdit = lookupEdit;
			myLookupEdit.NullText = "";
		}

		protected void Init()
		{
			//myDataTable = ACMSLogic.Common.DBAccess.LoadData(myCmdText);
			if (myDataTable != null)
			{
				myLookupEdit.DataSource = myDataTable;
				myLookupEdit.DisplayMember = myDisplayMember;
				myLookupEdit.ValueMember = myValueMember;
				myLookupEdit.PopupWidth = 350;				
				myLookupEdit.NullText = "";
			}
			else
				throw new Exception("Please Call Refresh method before Init()");
		}
		
		public virtual void Refresh()
		{
			myDataTable = ACMSDAL.DBAccess.LoadData(myCmdText);
			Init();
		}
	}
	#endregion

	#region CommonLookupEditBuilder
	public class CommonLookupEditBuilder : LookupEditBuilderBase
	{
		public CommonLookupEditBuilder(RepositoryItemLookUpEdit lookupEdt, DataTable dt, DevExpress.XtraEditors.Controls.LookUpColumnInfo[] LookUpInfo, string DisplayMember, string ValueMember, 
			string DisplayHeader) : base(lookupEdt)
		{
			
			myDisplayMember = DisplayMember;
			myValueMember = ValueMember;
			myDataTable = dt;
			Init();
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(LookUpInfo);
			
		}
		
		public CommonLookupEditBuilder(RepositoryItemLookUpEdit lookupEdt, DataTable dt, string DisplayMember, string ValueMember, 
			string DisplayHeader) : base(lookupEdt)
		{
			
			myDisplayMember = DisplayMember;
			myValueMember = ValueMember;
			myDataTable = dt;
			Init();
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] 
									  {
										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo(ValueMember,DisplayHeader,15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None)});
		}
	}

	//	public class CommonLookupEditBuilder : LookupEditBuilderBase
	//	{
	//		public CommonLookupEditBuilder(RepositoryItemLookUpEdit lookupEdt, DataTable dt, string DisplayMember, string ValueMember, string DisplayHeader) : base(lookupEdt)
	//		{
	//			myDisplayMember = DisplayMember;
	//			myValueMember = ValueMember;
	//			Init();
	//			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] 
	//									  {
	//										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo(ValueMember,DisplayHeader,15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None)});
	//		}
	//	}
	#endregion

	#region MemberIDLookupEditBuilder
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	/// 

	public class MemberIDLookupEditBuilder
	{
		private DataTable myTable;
		private RepositoryItemLookUpEdit myLookupEdit;

		public MemberIDLookupEditBuilder(ACMSLogic.Member member, RepositoryItemLookUpEdit lookupEdt)
		{
			//
			// TODO: Add constructor logic here
			//
			myLookupEdit = lookupEdt;
			myTable = member.Table;
			Init();
		}

		public MemberIDLookupEditBuilder(DataTable table, RepositoryItemLookUpEdit lookupEdt)
		{
			//
			// TODO: Add constructor logic here
			//
			myLookupEdit = lookupEdt;
			myTable = table;
			Init();
		}

		private void Init()
		{
			myLookupEdit.DataSource = myTable;
			myLookupEdit.DisplayMember = "strMembershipID";
			myLookupEdit.ValueMember = "strMembershipID";
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strMembershipID", "Member ID", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strNRICFIN", "NRIC/FIN", 100, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strMemberName", "Member Name", 250, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			myLookupEdit.NullText = "";
			myLookupEdit.PopupWidth = 450;
		}
	}
	#endregion
	
	#region MemberIDLookupEditBuilder2
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	/// 

	public class MemberIDLookupEditBuilder2 : LookupEditBuilderBase
	{
		private string myStrBranchCode;

		public MemberIDLookupEditBuilder2(RepositoryItemLookUpEdit lookupEdt, string strBranchCode) : base(lookupEdt)
		{
			//
			// TODO: Add constructor logic here
			//
			myLookupEdit = lookupEdt;
			myStrBranchCode = strBranchCode;
			myLookupEdit.DisplayMember = "strMembershipID";
			myLookupEdit.ValueMember = "strMembershipID";
			Refresh();
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strMembershipID", "Member ID", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strNRICFIN", "NRIC/FIN", 100, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strMemberName", "Member Name", 250, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
		}


		public override void Refresh()
		{
			ACMSDAL.TblMember sqlMember = new ACMSDAL.TblMember();

			if (myStrBranchCode != "")
				myDataTable = sqlMember.GetMemberBaseBranchCode(myStrBranchCode);
			else
				myDataTable = sqlMember.GetMember();
			Init();
		}
	}
	#endregion
	
	#region PackageCodeLookupEditBuilder
	public class PackageCodeLookupEditBuilder : LookupEditBuilderBase
	{
		private ACMSLogic.PackageCode myPackageCode;
		//private RepositoryItemLookUpEdit myLookupEdit;
		//private DataTable myDataTable;

		public PackageCodeLookupEditBuilder(ACMSLogic.PackageCode packageCode, RepositoryItemLookUpEdit lookupEdt) : base(lookupEdt)
		{
			//
			// TODO: Add constructor logic here
			//
			myPackageCode = packageCode;
			myDataTable = packageCode.AllValidPackageTable;
			myDisplayMember = "strDescription";
			myValueMember = "strPackageCode";
			Init();
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strPackageCode", "Package Code", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription", "Description", 25, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("dtValidEnd", "Valid End", 20, DevExpress.Utils.FormatType.DateTime, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			
			
		}

		public PackageCodeLookupEditBuilder(DataTable packageCodeTable, RepositoryItemLookUpEdit lookupEdt): base(lookupEdt)
		{
			//
			// TODO: Add constructor logic here
			//
			myDataTable = packageCodeTable;
			myDisplayMember = "strDescription";
			myValueMember = "strPackageCode";
			Init();
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strPackageCode", "Package Code", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription", "Description", 25, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("dtValidEnd", "Valid End", 20, DevExpress.Utils.FormatType.DateTime, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			
			
		}
	}
	#endregion

	#region ServiceCodeLookupEditBuilder
	public class ServiceCodeLookupEditBuilder
	{
		private DataTable myTable;
		private RepositoryItemLookUpEdit myLookupEdit;

		public ServiceCodeLookupEditBuilder(DataTable table, RepositoryItemLookUpEdit lookupEdt)
		{
			//
			// TODO: Add constructor logic here
			//
			myTable = table;
			myLookupEdit = lookupEdt;
			Init();
		}

		private void Init()
		{
			myLookupEdit.DataSource = myTable;
			myLookupEdit.DisplayMember = "strServiceCode";
			myLookupEdit.ValueMember = "strServiceCode";
			//myLookupEdit.PopulateColumns();
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strServiceCode", "Service Code", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription", "Description", 50, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			myLookupEdit.NullText = "";
		}
	}
	#endregion

	#region EmployeeIDLookupEditBuilder
	public class EmployeeIDLookupEditBuilder : LookupEditBuilderBase
	{
		public EmployeeIDLookupEditBuilder(RepositoryItemLookUpEdit lookupEdt) : base(lookupEdt)
		{
			//
			// TODO: Add constructor logic here
			//
			myDisplayMember = "strEmployeeName";
			myValueMember = "nEmployeeID";
			Refresh(false);
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nEmployeeID", "Employee ID", 80, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strEmployeeName", "Name", 250, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.Ascending),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strBranchCode", "Branch Code", 80, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nDepartmentID", "Department ID", 80, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			myLookupEdit.PopupWidth = 490;
		}

		public EmployeeIDLookupEditBuilder(RepositoryItemLookUpEdit lookupEdt, bool loadCurrentBranch) : base(lookupEdt)
		{
			//
			// TODO: Add constructor logic here
			//
			myDisplayMember = "strEmployeeName";
			myValueMember = "nEmployeeID";
			Refresh(loadCurrentBranch);
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nEmployeeID", "Employee ID", 80, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strEmployeeName", "Name", 250, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.Ascending),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strBranchCode", "Branch Code", 80, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nDepartmentID", "Department ID", 80, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			myLookupEdit.PopupWidth = 490;
		}

        public EmployeeIDLookupEditBuilder(RepositoryItemLookUpEdit lookupEdt,int nType)
            : base(lookupEdt)
        {
            //
            // TODO: Add constructor logic here
            // type = 0 is branch, 1 is department
            myDisplayMember = "strEmployeeName";
            myValueMember = "nEmployeeID";
            Refresh(nType);
            myLookupEdit.Columns.Clear();
            myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nEmployeeID", "Employee ID", 80, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strEmployeeName", "Name", 250, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.Ascending),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strBranchCode", "Branch Code", 80, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nDepartmentID", "Department ID", 80, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            myLookupEdit.PopupWidth = 490;
        }

        public void Refresh(int nType)
        {
            //ACMSLogic.User.BranchCode	
            ACMSDAL.TblEmployee employee = new ACMSDAL.TblEmployee();
            if (nType == 0)
            {
                employee.StrBranchCode = ACMSLogic.User.BranchCode;
                myDataTable = employee.SelectAllBranchEmployee();
            }
            else if (nType == 1)
            {
                employee.NDepartmentID = ACMSLogic.User.DepartmentID;
                myDataTable = employee.SelectHqDepartmentEmployee();
            }

            Init();
        }

		public void Refresh(bool isLoadCurrentBranch)
		{
			//ACMSLogic.User.BranchCode	
			ACMSDAL.TblEmployee employee = new ACMSDAL.TblEmployee();
			if (isLoadCurrentBranch)
			{
				employee.StrBranchCode = ACMSLogic.User.BranchCode; 
				myDataTable = employee.SelectAllWstrBranchCodeLogic();
			}
			else
				myDataTable = employee.SelectAll();

			Init();
		}

		public void Refresh(string strBranchCode)
		{
			ACMSDAL.TblEmployee employee = new ACMSDAL.TblEmployee();
			employee.StrBranchCode = strBranchCode;
			myDataTable =employee.SelectAllWstrBranchCodeLogic();
			Init();
		}
	}
	#endregion

	#region InstructorLookupEditBuilder
	public class InstructorLookupEditBuilder : LookupEditBuilderBase
	{
		private string myStrBranchCode = "";
		public InstructorLookupEditBuilder(RepositoryItemLookUpEdit lookupEdt) : base(lookupEdt)
		{
			//
			// TODO: Add constructor logic here
			//
			myDisplayMember = "strEmployeeName";
			myValueMember = "nEmployeeID";
			Refresh("");
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nEmployeeID", "Employee ID", 80, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strEmployeeName", "Name", 250, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strBranchCode", "Branch Code", 80, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nDepartmentID", "Department ID", 80, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			myLookupEdit.PopupWidth = 490;
		}

		public InstructorLookupEditBuilder(RepositoryItemLookUpEdit lookupEdt, string currentBranch) : base(lookupEdt)
		{
			//
			// TODO: Add constructor logic here
			//
			myDisplayMember = "strEmployeeName";
			myValueMember = "nEmployeeID";
			myStrBranchCode = currentBranch;
			Refresh(currentBranch);
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nEmployeeID", "Employee ID", 80, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strEmployeeName", "Name", 250, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strBranchCode", "Branch Code", 80, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nDepartmentID", "Department ID", 80, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			myLookupEdit.PopupWidth = 490;
		}

		public void Refresh(string strBranchCode)
		{
			ACMSDAL.TblEmployee employee = new ACMSDAL.TblEmployee();
			myStrBranchCode = strBranchCode;

			if (myStrBranchCode == "")
				myDataTable = employee.GetInstructorEmployee();
			else
				myDataTable = employee.GetInstructorEmployee(myStrBranchCode);
			Init();
		}
	}
	#endregion

	#region TherapistForCommisionLookupEditBuilder
	public class TherapistForCommisionLookupEditBuilder : LookupEditBuilderBase
	{
		public TherapistForCommisionLookupEditBuilder(RepositoryItemLookUpEdit lookupEdt, string strBranchCode) : base(lookupEdt)
		{
			//
			// TODO: Add constructor logic here
			//
			myDisplayMember = "strEmployeeName";
			myValueMember = "nEmployeeID";
			Refresh(strBranchCode);
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nEmployeeID", "Employee ID", 20, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strEmployeeName", "Name", 30, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strBranchCode", "Branch Code", 10, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nDepartmentID", "Department ID", 5, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
		}

		public void Refresh(string strBranchCode)
		{
			ACMSDAL.TblEmployee employee = new ACMSDAL.TblEmployee();
			myDataTable = employee.GetTherapistForCommision();
			Init();
		}
	}
	#endregion

    #region InhouseIPPTotalNOptionsLookupEditBuilder
    public class InhouseIPPTotalNOptionsLookupEditBuilder : LookupEditBuilderBase
    {
        public InhouseIPPTotalNOptionsLookupEditBuilder(RepositoryItemLookUpEdit lookupEdt, string strMasterReceiptNo, 
                                                            decimal mMasterReceiptTotal, decimal mPaymentAmount,
                                                            decimal mOutstandingAmount, string strPackageList)
            : base(lookupEdt)
        {
            //
            // TODO: Add constructor logic here
            //
            myDisplayMember = "nInstalmentNo";
            myValueMember = "nInstalmentNo";
            Refresh(strMasterReceiptNo, mMasterReceiptTotal, mPaymentAmount, mOutstandingAmount, strPackageList);
            myLookupEdit.Columns.Clear();
            myLookupEdit.Columns.AddRange(
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
					new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nInstalmentNo", 
                                                                            "No of Instalments", 
                                                                            10, 
                                                                            DevExpress.Utils.FormatType.Numeric, 
                                                                            "", 
                                                                            true, 
                                                                            DevExpress.Utils.HorzAlignment.Near, 
                                                                            DevExpress.Data.ColumnSortOrder.None)});
            myLookupEdit.PopupWidth = 10;           
        }

        public void Refresh(string strMasterReceiptNo, decimal mMasterReceiptTotal, decimal mPaymentAmount,
                                                    decimal mOutstandingAmount, string strPackageList)
        {
            ACMSDAL.TblPaymentPlan myPaymentPlan = new ACMSDAL.TblPaymentPlan();
            myDataTable = myPaymentPlan.GetInhouseIPPTotalNOptions(strMasterReceiptNo, mMasterReceiptTotal, mPaymentAmount,
                                                                    mOutstandingAmount, strPackageList);

            Init();
        }
    }
    #endregion

	#region TherapistForPOSSalesLookupEditBuilder
	public class TherapistForPOSSalesLookupEditBuilder : LookupEditBuilderBase
	{
		public TherapistForPOSSalesLookupEditBuilder(RepositoryItemLookUpEdit lookupEdt, string strBranchCode) : base(lookupEdt)
		{
			//
			// TODO: Add constructor logic here
			//
			myDisplayMember = "strEmployeeName";
			myValueMember = "nEmployeeID";
			Refresh(strBranchCode);
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nEmployeeID", "Employee ID", 20, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strEmployeeName", "Name", 30, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strBranchCode", "Branch Code", 10, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nDepartmentID", "Department ID", 5, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
		}

		public void Refresh(string strBranchCode)
		{
			ACMSDAL.TblEmployee employee = new ACMSDAL.TblEmployee();
			myDataTable = employee.GetTherapistForSales();
			Init();
		}
	}
	#endregion

	#region PersonalTrainerLookupEditBuilder
	public class PersonalTrainerLookupEditBuilder : LookupEditBuilderBase
	{
		public PersonalTrainerLookupEditBuilder(RepositoryItemLookUpEdit lookupEdt, string strBranchCode) : base(lookupEdt)
		{
			//
			// TODO: Add constructor logic here
			//
			myDisplayMember = "strEmployeeName";
			myValueMember = "nEmployeeID";
			Refresh(strBranchCode);
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nEmployeeID", "ID", 20, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strEmployeeName","Employee Name", 30, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strBranchCode", "Branch", 10, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nDepartmentID", "Department", 5, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			myLookupEdit.BestFit();
		}

		public void Refresh(string strBranchCode)
		{
			ACMSDAL.TblEmployee employee = new ACMSDAL.TblEmployee();
			myDataTable = employee.GetPersonalTrainer(strBranchCode);
			Init();
		}
	}
	#endregion

	#region MemberPackageLookupEditBuilder
	public class MemberPackageLookupEditBuilder
	{
		private DataTable myTable;
		private RepositoryItemLookUpEdit myLookupEdit;

		public MemberPackageLookupEditBuilder(DataTable table, RepositoryItemLookUpEdit lookupEdt)
		{
			//
			// TODO: Add constructor logic here
			//
			myTable = table;
			myLookupEdit = lookupEdt;
			myLookupEdit.NullText = "";
			Init();
		}

		private void Init()
		{
			myLookupEdit.DataSource = myTable;
			myLookupEdit.DisplayMember = "nPackageID";
			myLookupEdit.ValueMember = "nPackageID";
			//myLookupEdit.PopulateColumns();
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nPackageID", "Package ID", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strPackageCode", "Package Code", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("dtExpiryDate", "Expiry Date", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
																									 
			myLookupEdit.NullText = "";
		}
	}
	#endregion

	#region BranchCodeLookupEditBuilder
	public class BranchCodeLookupEditBuilder
	{
		private DataTable myDataSource;
		private RepositoryItemLookUpEdit myLookupEdit;

		public BranchCodeLookupEditBuilder(DataTable dataSource, RepositoryItemLookUpEdit lookupEdt)
		{
			//
			// TODO: Add constructor logic here
			//
			myLookupEdit = lookupEdt;
			myDataSource = dataSource;
			Init();
		}

		private void Init()
		{
			myLookupEdit.DataSource = myDataSource;
			myLookupEdit.DisplayMember = "strBranchCode";
			myLookupEdit.ValueMember = "strBranchCode";
			//myLookupEdit.PopulateColumns();
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strBranchCode", "Branch Code", 50, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.Ascending),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strBranchName", "Branch Name", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			myLookupEdit.NullText = "";
			myLookupEdit.PopupWidth = 350;
		}
	}
	#endregion

	#region CaseCategoryLookupEditBuilder
	public class CaseCategoryLookupEditBuilder
	{
		private DataTable myTable;
		private RepositoryItemLookUpEdit myLookupEdit;

		public CaseCategoryLookupEditBuilder(DataTable table, RepositoryItemLookUpEdit lookupEdt)
		{
			//
			// TODO: Add constructor logic here
			//
			myTable = table;
			myLookupEdit = lookupEdt;
			Init();
		}

		private void Init()
		{
			myLookupEdit.DataSource = myTable;
			myLookupEdit.DisplayMember = "strDescription";
			myLookupEdit.ValueMember = "nCategoryID";
			//myLookupEdit.PopulateColumns();
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nCategoryID", "Category ID", 50, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription", "Description", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			myLookupEdit.NullText = "";
			myLookupEdit.PopupWidth = 250;
		}
	}
	#endregion

	#region CaseModeLookupEditBuilder
	public class CaseModeLookupEditBuilder
	{
		private DataTable myTable;
		private RepositoryItemLookUpEdit myLookupEdit;

		public CaseModeLookupEditBuilder(DataTable table, RepositoryItemLookUpEdit lookupEdt)
		{
			//
			// TODO: Add constructor logic here
			//
			myTable = table;
			myLookupEdit = lookupEdt;
			Init();
		}

		private void Init()
		{
			myLookupEdit.DataSource = myTable;
			myLookupEdit.DisplayMember = "strDescription";
			myLookupEdit.ValueMember = "nModeID";
			//myLookupEdit.PopulateColumns();
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nModeID", "Mode ID", 50, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription", "Description", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			myLookupEdit.NullText = "";
			myLookupEdit.PopupWidth = 250;
		}
	}
	#endregion

	#region CaseTypeLookupEditBuilder
	public class CaseTypeLookupEditBuilder
	{
		private DataTable myTable;
		private RepositoryItemLookUpEdit myLookupEdit;

		public CaseTypeLookupEditBuilder(DataTable table, RepositoryItemLookUpEdit lookupEdt)
		{
			//
			// TODO: Add constructor logic here
			//
			myTable = table;
			myLookupEdit = lookupEdt;
			Init();
		}

		private void Init()
		{
			myLookupEdit.DataSource = myTable;
			myLookupEdit.DisplayMember = "strDescription";
			myLookupEdit.ValueMember = "nTypeID";
			//myLookupEdit.PopulateColumns();
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nTypeID", "Type ID", 50, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription", "Description", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			myLookupEdit.NullText = "";
			myLookupEdit.PopupWidth = 250;
		}
	}
	#endregion

	#region DepartmentLookupEditBuilder
	public class DepartmentLookupEditBuilder
	{
		private DataTable myTable;
		private RepositoryItemLookUpEdit myLookupEdit;

		public DepartmentLookupEditBuilder(DataTable table, RepositoryItemLookUpEdit lookupEdt)
		{
			//
			// TODO: Add constructor logic here
			//
			myTable = table;
			myLookupEdit = lookupEdt;
			Init();
		}

		private void Init()
		{
			myLookupEdit.DataSource = myTable;
			myLookupEdit.DisplayMember = "strDescription";
			myLookupEdit.ValueMember = "nDepartmentID";
			//myLookupEdit.PopulateColumns();
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nDepartmentID", "Department ID", 50, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription", "Description", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			myLookupEdit.NullText = "";
			myLookupEdit.PopupWidth = 250;
		}
	}

	public class DepartmentLookupEditBuilder2 : LookupEditBuilderBase
	{
		public DepartmentLookupEditBuilder2 (RepositoryItemLookUpEdit lookupEdt) :  base(lookupEdt)
		{
            myDisplayMember = "strDescription";
            myValueMember = "nDepartmentID";
            myLookupEdit.DisplayMember = myDisplayMember;
            myLookupEdit.ValueMember = myValueMember;
			Refresh();
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nDepartmentID", "Department ID", 50, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription", "Description", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			//myLookupEdit.NullText = "";
			myLookupEdit.PopupWidth = 250;
		}

		public override void Refresh()
		{
			ACMSDAL.TblDepartment dept = new ACMSDAL.TblDepartment();
			myDataTable = dept.SelectAll();
			Init();
		}
        //public void Refresh(bool isLoadCurrentBranch)
        //{
        //    //ACMSLogic.User.BranchCode	
        //    ACMSDAL.TblEmployee employee = new ACMSDAL.TblEmployee();
        //    if (isLoadCurrentBranch)
        //    {
        //        employee.StrBranchCode = ACMSLogic.User.BranchCode;
        //        myDataTable = employee.SelectAllWstrBranchCodeLogic();
        //    }
        //    else
        //        myDataTable = employee.SelectAll();

        //    Init();
        //}

	}
	#endregion

	#region MemberPackageLeaveTypeLookupEditBuilder
	public class MemberPackageLeaveTypeLookupEditBuilder : LookupEditBuilderBase
	{
		//private RepositoryItemLookUpEdit myLookupEdt;

		public MemberPackageLeaveTypeLookupEditBuilder(RepositoryItemLookUpEdit lookupEdt) : base(lookupEdt)
		{
			myDisplayMember = "strDescription";
			myValueMember = "nReasonID";
			myCmdText = "Select * From TblPackageExtensionReasonType";
			Refresh();
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nReasonID", "Leave Type", 20, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription", "Description", 25, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
		}

		public MemberPackageLeaveTypeLookupEditBuilder(RepositoryItemLookUpEdit lookupEdt, string cmdtext) : base(lookupEdt)
		{
			myDisplayMember = "strDescription";
			myValueMember = "nReasonID";
			myCmdText = cmdtext;
			Refresh();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nReasonID", "Leave Type", 20, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription", "Description", 25, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
		}
	}
	#endregion

	#region CategoryIDLookupEditBuilder
	public class CategoryIDLookupEditBuilder : LookupEditBuilderBase
	{
		public CategoryIDLookupEditBuilder(RepositoryItemLookUpEdit lookupEdt) : base(lookupEdt)
		{
			myDisplayMember = "strDescription";
			myValueMember = "nCategoryID";
			Refresh();
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nCategoryID", "Category ID", 50, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription", "Description", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			myLookupEdit.PopupWidth = 250;
		}

		public override void Refresh()
		{
			//base.Refresh ();
			ACMSLogic.Category category = new ACMSLogic.Category();
			myDataTable = category.GetPackageCategory();
			Init();
		}
	}
	#endregion

	#region AllowedSalesConversionCategoryIDLookupEditBuilder
	public class AllowedSalesConversionCategoryIDLookupEditBuilder : LookupEditBuilderBase
	{
		public AllowedSalesConversionCategoryIDLookupEditBuilder(RepositoryItemLookUpEdit lookupEdt) : 
			base(lookupEdt)
		{
			myDisplayMember = "strDescription";
			myValueMember = "nCategoryID";
			Refresh();
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nCategoryID", "Category ID", 50, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription", "Description", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			myLookupEdit.PopupWidth = 250;
		}

		public override void Refresh()
		{
			//base.Refresh ();
			ACMSDAL.TblCategory sqlcategory = new ACMSDAL.TblCategory();
			myDataTable = sqlcategory.GetAllowedSalesConversionCategory();
			Init();
		}
	}
	#endregion

	#region CategoryIDForCreditPackageLookupEditBuilder
	public class CategoryIDForCreditPackageLookupEditBuilder : LookupEditBuilderBase
	{
		public CategoryIDForCreditPackageLookupEditBuilder(RepositoryItemLookUpEdit lookupEdt) : base(lookupEdt)
		{
			myDisplayMember = "strDescription";
			myValueMember = "nCategoryID";
			Refresh();
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nCategoryID", "Category ID", 20, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription", "Description", 25, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
		}

		public override void Refresh()
		{
			//base.Refresh ();
			ACMSLogic.Category category = new ACMSLogic.Category();
			myDataTable = category.GetCreditPackageCategory();
			Init();
		}
	}
	#endregion

	#region BranchCodeLookupEditBuilder2
	public class BranchCodeLookupEditBuilder2 : LookupEditBuilderBase
	{
		public BranchCodeLookupEditBuilder2(RepositoryItemLookUpEdit lookupEdt) : base(lookupEdt)
		{
			myDisplayMember = "strBranchCode";
			myValueMember = "strBranchCode";
			Refresh();
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strBranchCode", "Branch Code", 50, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.Ascending),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strBranchName", "Branch Name", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			myLookupEdit.PopupWidth = 250;
		}

		public override void Refresh()
		{
			ACMSDAL.TblBranch branch = new ACMSDAL.TblBranch();
			myDataTable = branch.SelectAllForLookupEdit();
			Init();
		}
	}
	#endregion

	#region ClassInstanceLookupEditBuilder
	public class ClassInstanceLookupEditBuilder : LookupEditBuilderBase
	{
		public ClassInstanceLookupEditBuilder(RepositoryItemLookUpEdit lookupEdt) : base(lookupEdt)
		{
			myDisplayMember = "strClassCode";
			myValueMember = "nClassInstanceID";
			Refresh(DateTime.Now, "", "");
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nClassInstanceID", "Class ID", 10, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strClassCode", "Class Code", 25, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("dtStartTime", "Start Time", 20, DevExpress.Utils.FormatType.DateTime, "T", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None), 
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("dtEndTime", "End Time", 20, DevExpress.Utils.FormatType.DateTime, "T", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
		}

		public void Refresh(DateTime classDate, string strBranchCode, string strPackageCode)
		{
			ACMSDAL.TblClassInstance instance = new ACMSDAL.TblClassInstance();
			myDataTable = instance.GetValidClassInstance(classDate, strBranchCode, strPackageCode);
			Init();
		}
	}
	#endregion

	#region CreditPackageLookupEditBuilder
	public class CreditPackageLookupEditBuilder : LookupEditBuilderBase
	{
		public CreditPackageLookupEditBuilder(RepositoryItemLookUpEdit lookupEdt) : base(lookupEdt)
		{
			myDisplayMember = "strCreditPackageCode";
			myValueMember = "strCreditPackageCode";
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strCreditPackageCode", "Credit Package Code", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription", "Description", 25, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
		}

		public void Refresh(int nCategoryID)
		{
			ACMSDAL.TblCreditPackage creditPackage = new ACMSDAL.TblCreditPackage();
			creditPackage.NCategoryID = nCategoryID;
			myDataTable = creditPackage.SelectAllWnCategoryIDLogic();
			Init();
		}

	}
	#endregion

	#region MemberPackageCategoryIDLookupEditBuilder
	public class MemberPackageCategoryIDLookupEditBuilder : LookupEditBuilderBase
	{
		public MemberPackageCategoryIDLookupEditBuilder(RepositoryItemLookUpEdit lookupEdt) : base(lookupEdt)
		{
			myDisplayMember = "strDescription";
			myValueMember = "nCategoryID";
			Refresh();
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nCategoryID", "Category ID", 20, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription", "Description", 25, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
		}

		public override void Refresh()
		{
			//base.Refresh ();
			ACMSLogic.Category category = new ACMSLogic.Category();
			myDataTable = category.GetPackageCategory();
			Init();
		}

	}
	#endregion

	#region MemberCreditPackageCategoryIDLookupEditBuilder
	public class MemberCreditPackageCategoryIDLookupEditBuilder : LookupEditBuilderBase
	{
		public MemberCreditPackageCategoryIDLookupEditBuilder(RepositoryItemLookUpEdit lookupEdt) : base(lookupEdt)
		{
			myDisplayMember = "strDescription";
			myValueMember = "nCategoryID";
			Refresh();
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nCategoryID", "Category ID", 20, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription", "Description", 25, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
		}

		public override void Refresh()
		{
			//base.Refresh ();
			ACMSLogic.Category category = new ACMSLogic.Category();
			myDataTable = category.GetCreditPackageCategory();
			Init();
		}

	}
	#endregion
	
	#region MemberPackageLookupEditBuilder2
	public class MemberPackageLookupEditBuilder2 : LookupEditBuilderBase
	{
		private bool myIsServiceSession = false;
		private string myStrMemberShipID = "";
        
		public MemberPackageLookupEditBuilder2(RepositoryItemLookUpEdit lookupEdt, bool isServiceSession, string strMembershipID) : base(lookupEdt)
		{
			//
			// TODO: Add constructor logic here
			//
			myIsServiceSession = isServiceSession;
			myStrMemberShipID = strMembershipID;
			myDisplayMember = "strDescription";
			myValueMember = "nPackageID";
			Refresh();
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nPackageID", "Package ID", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strPackageCode", "Package Code", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("dtExpiryDate", "Expiry Date", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
		}

		public override void Refresh()
		{
			if (myStrMemberShipID != "")
			{
				if (myIsServiceSession)
				{
					ACMSDAL.TblMemberPackage memberPackage = new ACMSDAL.TblMemberPackage();
					myDataTable = memberPackage.GetActiveMemberPackageForServiceSession(myStrMemberShipID);
					Init();
				}
				else
				{
					ACMSDAL.TblMemberPackage memberPackage = new ACMSDAL.TblMemberPackage();
					myDataTable = memberPackage.GetAllMemberPackageForClassAttendance(myStrMemberShipID);
                    ACMSLogic.MemberPackage myMemberPackage = new ACMSLogic.MemberPackage();
                    myMemberPackage.CalculateMemberPackageBalance(myStrMemberShipID, myDataTable);
                    foreach (DataRow dr in myDataTable.Rows)
                    {
                        if (Convert.ToInt32(dr["Balance"]) <= 0)
                            dr.Delete();
                    }
                    myDataTable.AcceptChanges();

					Init();
				}
			}
		}

        //public void CalculateBalance()
        //{
        //    if (myDataTable != null)
        //    {
        //        if (!myDataTable.Columns.Contains("strBalNew"))
        //        {
        //            DataColumn colBalNew = new DataColumn("strBalNew", System.Type.GetType("System.String"));
        //            myDataTable.Columns.Add(colBalNew);
        //        }

        //        if (!myDataTable.Columns.Contains("Balance"))
        //        {
        //            DataColumn colBalance = new DataColumn("Balance", System.Type.GetType("System.Int32"));
        //            myDataTable.Columns.Add(colBalance);
        //        }

        //        if (!myDataTable.Columns.Contains("strPackageType"))
        //        {
        //            DataColumn colPackageType = new DataColumn("strPackageType", System.Type.GetType("System.String"));
        //            myDataTable.Columns.Add(colPackageType);
        //        }

        //        TblClassAttendance classAttendance = new TblClassAttendance();
        //        TblServiceSession serviceSession = new TblServiceSession();

        //        DataTable gymTable = new DataTable();
        //        DataColumn colDtdate = new DataColumn("dtDate", typeof(string));
        //        DataColumn colPackageID = new DataColumn("nPackageID", typeof(int));
        //        DataColumn colAttendanceID = new DataColumn("nAttendanceID", typeof(int));
        //        gymTable.Columns.Add(colDtdate);
        //        gymTable.Columns.Add(colPackageID);
        //        gymTable.Columns.Add(colAttendanceID);

        //        foreach (DataRow r in myDataTable.Rows)
        //        {
        //            r["Balance"] = r["nMaxSession"];

        //            if (ACMS.Convert.ToInt32(r["nMaxSession"]) == 9999)
        //            {
        //                r["Balance"] = 9999;
        //                r["strBalNew"] = r["Balance"].ToString();
        //                if (r["dtStartDate"] == DBNull.Value)
        //                    r["strBalNew"] = "New";
        //                else
        //                {
        //                    if (r["strPackageType"].ToString() == "Normal Package")
        //                    {
        //                        if (ACMS.Convert.ToInt32(r["nMaxSession"]) == ACMS.Convert.ToInt32(r["Balance"]) && ACMS.Convert.ToInt32(r["nMaxSession"]) != 9999)
        //                            r["strBalNew"] = "New";
        //                    }
        //                }
        //                continue;
        //            }

        //            int nCategoryID = ACMS.Convert.ToInt32(r["nCategoryID"]);
        //            int nPackageID = ACMS.Convert.ToInt32(r["nPackageID"]);
        //            // class Attendance
        //            if (nCategoryID == 1 || nCategoryID == 2)
        //            {

        //                classAttendance.NPackageID = nPackageID;
        //                DataTable classAttendanceTable = classAttendance.SelectAllWnPackageIDLogic();

        //                if (classAttendanceTable == null || classAttendanceTable.Rows.Count == 0)
        //                {
        //                    if (ACMS.Convert.ToDBInt32(r["nAdjust"]) >= 1 && ACMS.Convert.ToInt32(r["nMaxSession"]) < 9999)
        //                    {
        //                        r["Balance"] = ACMS.Convert.ToDBInt32(r["Balance"]) - ACMS.Convert.ToDBInt32(r["nAdjust"]);
        //                    }
        //                    r["strBalNew"] = r["Balance"].ToString();
        //                    if (r["dtStartDate"] == DBNull.Value)
        //                        r["strBalNew"] = "New";
        //                    else
        //                    {
        //                        if (r["strPackageType"].ToString() == "Normal Package")
        //                        {
        //                            if (ACMS.Convert.ToInt32(r["nMaxSession"]) == ACMS.Convert.ToInt32(r["Balance"]))
        //                                r["strBalNew"] = "New";
        //                        }
        //                    }
        //                    continue;
        //                }

        //                DataView classAttendanceTableView = classAttendanceTable.DefaultView;

        //                // Need to filter out the non GYM attendance here
        //                classAttendanceTableView.RowFilter = "((nStatusID = 1 or nStatusID = 2) AND nTypeID = 0 AND fFree = 0)";

        //                if (classAttendanceTableView.Count > 0)
        //                {

        //                    ACMSDAL.TblMemberPackage sqlFindPackageCode = new ACMSDAL.TblMemberPackage();
        //                    string strPackageCode = sqlFindPackageCode.GetPackageCode(strMembershipID, nPackageID);

        //                    //if (strPackageCode == "AA(1080/12)" || strPackageCode == "AA(2160/24)" )
        //                    //{
        //                    //    r["Balance"] = ACMS.Convert.ToInt32(r["Balance"]) - myDTransactionID;
        //                    //}

        //                    if (r["fEntries"].ToString() == "True")
        //                    {
        //                        //1203 jackie
        //                        ACMSDAL.TblMemberPackage sqlCalcPackages = new ACMSDAL.TblMemberPackage();
        //                        int myDTransactionID = sqlCalcPackages.CalculateSpecialSessionPackages(strMembershipID, nPackageID);
        //                        r["Balance"] = ACMS.Convert.ToInt32(r["Balance"]) - myDTransactionID;
        //                    }
        //                    else//2604
        //                        if (strPackageCode == "FTRIAL")
        //                        {
        //                            r["Balance"] = classAttendanceTableView.Count;
        //                        }
        //                        else
        //                        {

        //                            if (nCategoryID == 2 || ACMS.Convert.ToInt32(r["Balance"]) == 9999) //2604
        //                            {
        //                                string strPackageID = nPackageID.ToString();
        //                                ACMSDAL.TblMemberPackage sqlCalcTotalGIRO = new ACMSDAL.TblMemberPackage();//jackie 15/03/2012
        //                                int intTotalGIRO = sqlCalcTotalGIRO.CalculateTotalGIRO(strMembershipID, strPackageID, strPackageCode);
        //                                r["Balance"] = (intTotalGIRO * ACMS.Convert.ToInt32(r["Balance"])) - classAttendanceTableView.Count;

        //                            }
        //                            else
        //                            {
        //                                r["Balance"] = ACMS.Convert.ToInt32(r["Balance"]) - classAttendanceTableView.Count;
        //                            }



        //                        }

        //                }

        //                if (ACMS.Convert.ToDBInt32(r["nAdjust"]) >= 1 && ACMS.Convert.ToInt32(r["nMaxSession"]) < 9999)
        //                {
        //                    r["Balance"] = ACMS.Convert.ToDBInt32(r["Balance"]) - ACMS.Convert.ToDBInt32(r["nAdjust"]);

        //                }



        //                // Start calculate the POWER Package
        //                // It is consider PWR Package if the class attendance is GYM Class
        //                classAttendanceTableView.RowFilter = "((nStatusID = 1 or nStatusID = 2) AND nTypeID = 1 AND nPackageID ='" + nPackageID + "')";

        //                if (classAttendanceTableView.Count > 0)
        //                {
        //                    for (int i = 0; i < classAttendanceTableView.Count; i++)
        //                    {
        //                        DataRow row = classAttendanceTableView[i].Row;
        //                        string dtDate = ACMS.Convert.ToDateTime(row["dtDate"]).ToString("yyyy/MM/dd");
        //                        int nAttendanceID = ACMS.Convert.ToInt32(row["nAttendanceID"]);

        //                        DataRow[] foundRow = gymTable.Select("dtDate = '" + dtDate + "'" + "AND nPackageID = '" + nPackageID + "'");

        //                        if (foundRow.Length == 0)
        //                        {
        //                            DataRow addRow = gymTable.NewRow();
        //                            addRow["dtDate"] = dtDate;
        //                            addRow["nPackageID"] = nPackageID;
        //                            addRow["nAttendanceID"] = nAttendanceID;
        //                            gymTable.Rows.Add(addRow);
        //                        }
        //                    }

        //                    foreach (DataRow pRow in gymTable.Rows)
        //                    {
        //                        DateTime dtDate = ACMS.Convert.ToDateTime(pRow["dtDate"]);
        //                        int nPackageIDInGymTable = ACMS.Convert.ToInt32(pRow["nPackageID"]);

        //                        string strFilter = string.Format("(nStatusID = 1 or nStatusID = 2) " +
        //                            " AND nTypeID = 0 AND nPackageID = {0} AND DtDate = #{1}#", nPackageID, dtDate.ToString("yyyy/MM/dd"));

        //                        DataRow[] foundRow = classAttendanceTable.Select(strFilter, "nPackageID", DataViewRowState.CurrentRows);

        //                        if (foundRow.Length > 0)
        //                            r["Balance"] = ACMS.Convert.ToInt32(r["Balance"]) + 1;
        //                    }



        //                    ////////////

        //                    ACMSDAL.TblMemberPackage sqlCalcPackages = new ACMSDAL.TblMemberPackage();//jackie 15/03/2012
        //                    int myDTransactionID = sqlCalcPackages.CalculateSpecialSessionPackages(strMembershipID, nPackageID);

        //                    ACMSDAL.TblMemberPackage sqlFindPackageCode = new ACMSDAL.TblMemberPackage();
        //                    string strPackageCode = sqlFindPackageCode.GetPackageCode(strMembershipID, nPackageID);

        //                    if (strPackageCode == "AA(1080/12)" || strPackageCode == "AA(2160/24)")
        //                    {
        //                        r["Balance"] = ACMS.Convert.ToInt32(r["nMaxSession"]) - myDTransactionID;
        //                    }
        //                    else
        //                        if (strPackageCode == "FTRIAL")
        //                        {
        //                            r["Balance"] = myDTransactionID;
        //                        }
        //                        else



        //                        /////////
        //                        {
        //                            r["Balance"] = ACMS.Convert.ToInt32(r["Balance"]) - gymTable.Rows.Count;

        //                        }
        //                    gymTable.Rows.Clear();

        //                }
        //            }
        //            else if (nCategoryID == 3 || nCategoryID == 4 || nCategoryID == 5 || nCategoryID == 6 || nCategoryID == 34) // Service Session
        //            {
        //                serviceSession.NPackageID = nPackageID;
        //                DataView serviceSessionTable = serviceSession.SelectAllWnPackageIDLogic().DefaultView;
        //                serviceSessionTable.RowFilter = "nStatusID = 5 or nStatusID = 6";

        //                if (nCategoryID == 34)
        //                {
        //                    r["Balance"] = ACMS.Convert.ToInt32(r["Balance"]) - serviceSessionTable.Count + ACMS.Convert.ToDBInt32(r["nAdjust"]);
        //                }
        //                else
        //                {

        //                    ACMSDAL.TblMemberPackage sqlCalcPackages = new ACMSDAL.TblMemberPackage();//jackie 15/03/2012
        //                    int myDTransactionID = sqlCalcPackages.CalculateSpecialSessionPackages(strMembershipID, nPackageID);

        //                    ACMSDAL.TblMemberPackage sqlFindPackageCode = new ACMSDAL.TblMemberPackage();
        //                    string strPackageCode = sqlFindPackageCode.GetPackageCode(strMembershipID, nPackageID);

        //                    if (strPackageCode == "AA(1080/12)" || strPackageCode == "AA(2160/24)")
        //                    {
        //                        r["Balance"] = ACMS.Convert.ToInt32(r["Balance"]) - myDTransactionID;
        //                    }
        //                    else
        //                        if (strPackageCode == "FTRIAL")
        //                        {
        //                            r["Balance"] = myDTransactionID;
        //                        }
        //                        else
        //                        {

        //                            if (nCategoryID == 2 || ACMS.Convert.ToInt32(r["Balance"]) == 9999) //2604
        //                            {

        //                                string strPackageID = nPackageID.ToString();
        //                                ACMSDAL.TblMemberPackage sqlCalcTotalGIRO = new ACMSDAL.TblMemberPackage();//jackie 15/03/2012
        //                                int intTotalGIRO = sqlCalcTotalGIRO.CalculateTotalGIRO(strMembershipID, strPackageID, strPackageCode);
        //                                r["Balance"] = (intTotalGIRO * ACMS.Convert.ToInt32(r["Balance"])) - serviceSessionTable.Count;
        //                            }
        //                            else
        //                            {
        //                                r["Balance"] = ACMS.Convert.ToInt32(r["Balance"]) - serviceSessionTable.Count;
        //                            }
        //                        }



        //                    if (ACMS.Convert.ToDBInt32(r["nAdjust"]) >= 1 && ACMS.Convert.ToInt32(r["nMaxSession"]) < 9999)
        //                    {

        //                        //jackie
        //                        r["Balance"] = ACMS.Convert.ToDBInt32(r["Balance"]) - ACMS.Convert.ToDBInt32(r["nAdjust"]);
        //                    }
        //                }

        //                //if (dr["strFreePkgCode"].ToString() != string.Empty)
        //                //{
        //                //    myPOS.EditItemFreebieAndDiscount(dr["strFreePkgCode"].ToString());
        //                //}
        //            }
        //            r["strBalNew"] = r["Balance"].ToString();
        //            if (r["dtStartDate"] == DBNull.Value)
        //                r["strBalNew"] = "New";
        //            else
        //            {
        //                if (r["strPackageType"].ToString() == "Normal Package")
        //                {
        //                    if (ACMS.Convert.ToInt32(r["nMaxSession"]) == ACMS.Convert.ToInt32(r["Balance"]))
        //                        r["strBalNew"] = "New";
        //                }
        //            }
        //        }
        //    }
        //}

		public void Refresh(string strMemberShipID)
		{
			myStrMemberShipID = strMemberShipID;
			Refresh();
		}
	}
	#endregion

	#region PackageCodeBasePromotionLookupEditBuilder
	public class PackageCodeBasePromotionLookupEditBuilder : LookupEditBuilderBase
	{
		private string myStrPromotionCode = "";


		public PackageCodeBasePromotionLookupEditBuilder(RepositoryItemLookUpEdit lookupEdt, string strPromotionCode) :  base(lookupEdt)
		{
			//
			// TODO: Add constructor logic here
			//

			myStrPromotionCode = strPromotionCode;
			myDisplayMember = "strPackageCode";
			myValueMember = "strPackageCode";
			Refresh(myStrPromotionCode);
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strPackageCode", "Package Code", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription", "Description", 50, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			
		}

		public void Refresh(string strPromotionCode)
		{
			myStrPromotionCode = strPromotionCode;
			
			ACMSDAL.TblPromotionPackage sqlProPckg = new ACMSDAL.TblPromotionPackage();
			string cmdText = "Select A.* from tblPackage A inner Join tblPromotionPackage B on A.strPackageCode = B.strPackageCode Where " +
				" B.strPromotionCode = @strPromotionCode";
			myDataTable = sqlProPckg.LoadData(cmdText, new string[] {"@strPromotionCode"}, new object[] {myStrPromotionCode});
			Init();
		}
	}
	#endregion

	#region ServiceCodeLookupEditBuilder2
	public class ServiceCodeLookupEditBuilder2 : LookupEditBuilderBase
	{
		private string myStrPackageCode = "";

		public ServiceCodeLookupEditBuilder2(RepositoryItemLookUpEdit lookupEdt, int nPackageID) :  base(lookupEdt)
		{
			//
			// TODO: Add constructor logic here
			//
			ACMSDAL.TblMemberPackage memberPackage = new ACMSDAL.TblMemberPackage();
			memberPackage.NPackageID = nPackageID;
			memberPackage.SelectOne();
			myStrPackageCode = memberPackage.StrPackageCode.IsNull ? "" : memberPackage.StrPackageCode.Value;
			myDisplayMember = "strServiceCode";
			myValueMember = "strServiceCode";
			Refresh();
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strServiceCode", "Service Code", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription", "Description", 50, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			
		}

		public ServiceCodeLookupEditBuilder2(RepositoryItemLookUpEdit lookupEdt, string strPackageCode) :  base(lookupEdt)
		{
			//
			// TODO: Add constructor logic here
			//

			myStrPackageCode = strPackageCode;
			myDisplayMember = "strServiceCode";
			myValueMember = "strServiceCode";
			Refresh();
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strServiceCode", "Service Code", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription", "Description", 50, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			
		}

		public override void Refresh()
		{
			ACMSDAL.TblPackageService packageService = new ACMSDAL.TblPackageService();
			myDataTable = packageService.GetServiceBasePackage(myStrPackageCode);
			Init();
		}

		public void Refresh(int nPackageID)
		{
			ACMSDAL.TblMemberPackage memberPackage = new ACMSDAL.TblMemberPackage();
			memberPackage.NPackageID = nPackageID;
			memberPackage.SelectOne();
			myStrPackageCode = memberPackage.StrPackageCode.IsNull ? "" : memberPackage.StrPackageCode.Value;
			Refresh();
		}

		public void Refresh(string strPackageCode)
		{
			myStrPackageCode = strPackageCode;
			Refresh();
		}
	}
	#endregion
	
	#region ClassCodeLookupEditBuilder 
	public class ClassCodeLookupEditBuilder : LookupEditBuilderBase
	{
		public ClassCodeLookupEditBuilder(RepositoryItemLookUpEdit lookupEdt) :  base(lookupEdt)
		{
			//
			// TODO: Add constructor logic here
			//
			myDisplayMember = "strClassCode";
			myValueMember = "strClassCode";
			Refresh();
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] 
									  {
										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strClassCode", "Class Code", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription", "Description", 50, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None), 
										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nClassTypeID", "Class Type ID", 3, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			
		}

		public override void Refresh()
		{
			ACMSDAL.TblClass _class = new ACMSDAL.TblClass();
			myDataTable = _class.SelectAll();
			Init();
		}
	}
	#endregion
	
	#region ReceiptNoLookupEditBuilder
	public class ReceiptNoLookupEditBuilder : LookupEditBuilderBase
	{
		public ReceiptNoLookupEditBuilder(RepositoryItemLookUpEdit lookupEdt) :  base(lookupEdt)
		{
			myDisplayMember = "strReceiptNo";
			myValueMember = "strReceiptNo";
			Refresh("", -1);
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] 
										  {
											  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strReceiptNo", "Receipt No", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
											  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("mTotalAmount", "Total Amount", 10, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None), 
											  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("mOutstandingAmount", "Outstanding Amount", 10, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			
		}

		public void Refresh(string strMembershipID, int nCategoryID)
		{
			ACMSDAL.TblReceipt receipt = new ACMSDAL.TblReceipt();
			myDataTable = receipt.GetValidReceiptBaseCategoryID(strMembershipID, nCategoryID);
			Init();
		}

	}
	#endregion

	#region SalesCategoryIDLookupEditBuilder
	public class SalesCategoryIDLookupEditBuilder : LookupEditBuilderBase
	{
		public SalesCategoryIDLookupEditBuilder (RepositoryItemLookUpEdit lookupEdt) :  base(lookupEdt)
		{
			myDisplayMember = "strDescription";
			myValueMember = "nSalesCategoryID";
			Refresh();
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] 
									  {
										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nSalesCategoryID", "Category ID", 10, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription", "Description", 30, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			
		}

		public override void Refresh()
		{
			ACMSDAL.TblSalesCategory sc = new ACMSDAL.TblSalesCategory();
			myDataTable = sc.SelectAll();
			DataRow row = myDataTable.NewRow();
			row["nSalesCategoryID"] = -1;
			row["strDescription"] = "View All";
			myDataTable.Rows.Add(row);
			Init();
		}
	}

	#endregion

	#region VoucherTypeLookupEditBuilder
	public class VoucherTypeLookupEditBuilder : LookupEditBuilderBase
	{
		public VoucherTypeLookupEditBuilder (RepositoryItemLookUpEdit lookupEdt) :  base(lookupEdt)
		{
			myDisplayMember = "nVoucherTypeID";
			myValueMember = "nVoucherTypeID";
			Refresh();
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] 
									  {
										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nVoucherTypeID", "Voucher Type ID", 10, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription", "Description", 30, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			
		}

		public override void Refresh()
		{
			ACMSDAL.TblVoucherType vcher= new  ACMSDAL.TblVoucherType();
			myDataTable = vcher.SelectAll();
			Init();
		}
	}

	#endregion

	#region RewardsCatalogueLookupEditBuilder
	public class RewardsCatalogueLookupEditBuilder : LookupEditBuilderBase
	{
		private decimal myPointFilter = 0;

		public RewardsCatalogueLookupEditBuilder (RepositoryItemLookUpEdit lookupEdt, decimal pointFilter) :  base(lookupEdt)
		{
			myDisplayMember = "strItemCode";
			myValueMember = "strItemCode";
			myPointFilter = pointFilter;
			Refresh();
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] 
									  {
										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strItemCode", "Item Code", 15, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription", "Description", 30, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("dRewardsPoints", "Rewards Point", 10, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
										
		}

		public override void Refresh()
		{
			ACMSDAL.TblRewardsCatalogue catalogue = new ACMSDAL.TblRewardsCatalogue();
			myDataTable = catalogue.GetValidCatalogue(myPointFilter);
			Init();
		}
	}
	#endregion

	#region LoyalStatusLookupEditBuilder
	public class LoyalStatusLookupEditBuilder
	{
		private DataTable myTable;
		private RepositoryItemLookUpEdit myLookupEdit;

		public LoyalStatusLookupEditBuilder(DataTable table, RepositoryItemLookUpEdit lookupEdt)
		{
			//
			// TODO: Add constructor logic here
			//
			myTable = table;
			myLookupEdit = lookupEdt;
			Init();
		}

		private void Init()
		{
			myLookupEdit.DataSource = myTable;
			myLookupEdit.DisplayMember = "strDescription";
			myLookupEdit.ValueMember = "nLoyaltyStatusID";
			//myLookupEdit.PopulateColumns();
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription", "Description", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nLoyaltyStatusID", "Loyalty Status ID", 50, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			myLookupEdit.NullText = "";
			myLookupEdit.PopupWidth = 250;
		}

		public void Refresh()
		{
			ACMSDAL.TblLoyaltyStatus myTblLoyaltyStatus = new ACMSDAL.TblLoyaltyStatus();
			myTable = myTblLoyaltyStatus.SelectAll();
			Init();
		}
	}
	#endregion

	#region MediaSourceLookupEditBuilder
	public class MediaSourceLookupEditBuilder
	{
		private DataTable myTable;
		private RepositoryItemLookUpEdit myLookupEdit;

		public MediaSourceLookupEditBuilder(RepositoryItemLookUpEdit lookupEdt, string strCategory)
		{

            ACMSDAL.TblMember Member = new ACMSDAL.TblMember();
            myTable = Member.GetMediaSource(strCategory);         
			myLookupEdit = lookupEdt;
			Init();
		}
		
		private void Init()
		{
			myLookupEdit.DataSource = myTable;
			myLookupEdit.DisplayMember = "strDescription";
			myLookupEdit.ValueMember = "nMediaSourceID";
			//myLookupEdit.PopulateColumns();
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription", "Description", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nMediaSourceID", "Media Source ID", 50, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			myLookupEdit.NullText = "";
			myLookupEdit.PopupWidth = 250;
		}
	}
	#endregion

    #region 
    public class SecurityQuestionLookupEditBuilder
    {
        private DataTable myTable;
        private RepositoryItemLookUpEdit myLookupEdit;

        public SecurityQuestionLookupEditBuilder(RepositoryItemLookUpEdit lookupEdt)
        {

            ACMSDAL.TblMember Member = new ACMSDAL.TblMember();
            string cmdText = "select * from tblSecurityQuestion where nTypeID=1 ";
            myTable = Member.LoadData(cmdText, new string[] { }, new object[] { });
            //myTable = Member.GetMediaSourceCategory();

            myLookupEdit = lookupEdt;
            Init();
        }

        private void Init()
        {
            myLookupEdit.DataSource = myTable;
            myLookupEdit.DisplayMember = "strSecurityQuestion";
            myLookupEdit.ValueMember = "strSecurityQuestion";
            //myLookupEdit.PopulateColumns();
            myLookupEdit.Columns.Clear();
            myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strSecurityQuestion", "Security Question", 400, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            myLookupEdit.NullText = "";
            myLookupEdit.PopupWidth = 450;
        }
    }
    #endregion

    #region MediaSourceCategoryLookupEditBuilder
    public class MediaSourceCategoryLookupEditBuilder
    {
        private DataTable myTable;
        private RepositoryItemLookUpEdit myLookupEdit;

        public MediaSourceCategoryLookupEditBuilder(RepositoryItemLookUpEdit lookupEdt)
        {

            ACMSDAL.TblMember Member = new ACMSDAL.TblMember();
            string cmdText = "select distinct strCategory from tblMediaSource ";
            myTable = Member.LoadData(cmdText, new string[] {  }, new object[] {  });
            //myTable = Member.GetMediaSourceCategory();
            
            myLookupEdit = lookupEdt;
            Init();
        }
       
        private void Init()
        {
            myLookupEdit.DataSource = myTable;
            myLookupEdit.DisplayMember = "strCategory";
            myLookupEdit.ValueMember = "strCategory";
            //myLookupEdit.PopulateColumns();
            myLookupEdit.Columns.Clear();
            myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strCategory", "Category", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            myLookupEdit.NullText = "";
            myLookupEdit.PopupWidth = 250;
        }
    }
    #endregion

    #region MemberRelationshipLookupEditBuilder
    public class MemberRelationshipLookupEditBuilder
    {
        private DataTable myTable;
        private RepositoryItemLookUpEdit myLookupEdit;

        public MemberRelationshipLookupEditBuilder(RepositoryItemLookUpEdit lookupEdt)
        {

            ACMSDAL.TblMember Member = new ACMSDAL.TblMember();
            myTable = Member.GetRelationShip();
            myLookupEdit = lookupEdt;
            Init();
        }

        private void Init()
        {
            myLookupEdit.DataSource = myTable;
            myLookupEdit.DisplayMember = "strRelationCode";
            myLookupEdit.ValueMember = "strRelationCode";
            //myLookupEdit.PopulateColumns();
            myLookupEdit.Columns.Clear();
            myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
									      new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strRelationCode", "Description", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            myLookupEdit.NullText = "";
            myLookupEdit.PopupWidth = 250;
        }
    }
    #endregion
    #region MemberRelationshipLookupEditBuilder
    public class RelatedMemberLookupEditBuilder
    {
        private DataTable myTable;
        private RepositoryItemLookUpEdit myLookupEdit;

        public RelatedMemberLookupEditBuilder(RepositoryItemLookUpEdit lookupEdt)
        {
            ACMSDAL.TblMember Member = new ACMSDAL.TblMember();
            myTable = Member.SelectAll();
            myLookupEdit = lookupEdt;
            Init();
        }



        private void Init()
        {
            myLookupEdit.DataSource = myTable;
            myLookupEdit.DisplayMember = "strMembershipID";
            myLookupEdit.ValueMember = "strMemberName";
            //myLookupEdit.PopulateColumns();
            myLookupEdit.Columns.Clear();
            myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
                                          new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strMembershipID", "MemberID", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
									      new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strMemberName", "Name", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            myLookupEdit.NullText = "";
            myLookupEdit.PopupWidth = 250;
        }
    }
    #endregion

	#region LoyalPointsLookupEditBuilder
	public class LoyalPointsLookupEditBuilder
	{
		private DataTable myTable;
		private RepositoryItemLookUpEdit myLookupEdit;

		public LoyalPointsLookupEditBuilder(DataTable table, RepositoryItemLookUpEdit lookupEdt)
		{
			//
			// TODO: Add constructor logic here
			//
			myTable = table;
			myLookupEdit = lookupEdt;
			Init();
		}

		private void Init()
		{
			myLookupEdit.DataSource = myTable;
			myLookupEdit.DisplayMember = "strDescription";
			myLookupEdit.ValueMember = "dRewardsValue";
			//myLookupEdit.PopulateColumns();
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strRewardsCode", "Rewards Code", 125, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription", "Description", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("dRewardsValue", "Rewards Value", 75, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			myLookupEdit.PopupWidth = 400;
			myLookupEdit.NullText = "";
		}
	}
	#endregion
	#region FriendPromotionLookupEditBuilder
	public class FriendPromotionLookupEditBuilder
	{
		private DataTable myTable;
		private RepositoryItemLookUpEdit myLookupEdit;

		public FriendPromotionLookupEditBuilder(DataTable table, RepositoryItemLookUpEdit lookupEdt)
		{
			//
			// TODO: Add constructor logic here
			//
			myTable = table;
			myLookupEdit = lookupEdt;
			Init();
		}

		private void Init()
		{
			myLookupEdit.DataSource = myTable;
			myLookupEdit.DisplayMember = "strDescription";
			myLookupEdit.ValueMember = "strPromotionCode";
			//myLookupEdit.PopulateColumns();
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strPromotionCode", "Rewards Code", 125, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription", "Description", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			myLookupEdit.PopupWidth = 400;
			myLookupEdit.NullText = "";
		}
	}
	#endregion

	#region CVStatusLookupEditBuilder
	public class CVStatusLookupEditBuilder
	{
		private DataTable myTable;
		private RepositoryItemLookUpEdit myLookupEdit;

		public CVStatusLookupEditBuilder(RepositoryItemLookUpEdit lookupEdt)
		{
			myTable = new DataTable();
			myTable.Columns.Add("strDescription", typeof(string));
			myTable.Columns.Add("nStatusID", typeof(int));
			AddRow("New", 0);
			AddRow("Pending", 1);
			AddRow("Closed", 2);

			myLookupEdit = lookupEdt;
			Init();
		}

		///<summary>
		/// Refactored from  MediaSourceLookupEditBuilder
		///</summary>
		private void AddRow(string strDescription, int nStatusID)
		{
			DataRow newRow = myTable.NewRow();
			newRow.BeginEdit();
			newRow["strDescription"] = strDescription;
			newRow["nStatusID"] = nStatusID;
			newRow.EndEdit();
			myTable.Rows.Add(newRow);		
		}

		private void Init()
		{
			myLookupEdit.DataSource = myTable;
			myLookupEdit.DisplayMember = "strDescription";
			myLookupEdit.ValueMember = "nStatusID";
			//myLookupEdit.PopulateColumns();
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription", "Description", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nStatusID", "Status ID", 50, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			myLookupEdit.NullText = "";
			myLookupEdit.PopupWidth = 250;
		}
	}
	#endregion

	#region MemoGroupLookupEditBuilder
	public class MemoGroupLookupEditBuilder
	{
		private DataTable myTable;
		private RepositoryItemLookUpEdit myLookupEdit;

		public MemoGroupLookupEditBuilder(DataTable table, RepositoryItemLookUpEdit lookupEdt)
		{
			//
			// TODO: Add constructor logic here
			//
			myTable = table;
			myLookupEdit = lookupEdt;
			Init();
		}

		private void Init()
		{
			myLookupEdit.DataSource = myTable;
			myLookupEdit.DisplayMember = "strMemoGroupCode";
			myLookupEdit.ValueMember = "nMemoGroupID";
			//myLookupEdit.PopulateColumns();
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strMemoGroupCode", "Memo Group Code", 50, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nMemoGroupID", "Memo Group ID", 50, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription", "Description", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			myLookupEdit.NullText = "";
			myLookupEdit.PopupWidth = 300;
		}
	}
	#endregion

	#region ContactsLookupEditBuilder
	public class ContactsLookupEditBuilder : LookupEditBuilderBase
	{
        string strBranchCode;
		public ContactsLookupEditBuilder (RepositoryItemLookUpEdit lookupEdt, string strBranchCode) :  base(lookupEdt)
		{
            this.strBranchCode = strBranchCode;
			myDisplayMember = "strContactName";
			myValueMember = "nContactId";
			Refresh();
			//myLookupEdit.PopulateColumns();
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] 
									  {
										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nContactId", "Contact ID", 50, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strContactName", "Contact Name", 150, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strOrganization", "Organization", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
                                          new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strMobileNo", "Mobile No", 150, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});							
			myLookupEdit.PopupWidth = 350;
		}

		public override void Refresh()
		{
			ACMSDAL.TblContacts contact = new ACMSDAL.TblContacts();
            contact.StrBranchCode = strBranchCode;
            myDataTable = contact.SelectAllWnBranchCodeLogic();
			Init();
		}
	}
	#endregion

	#region AppointmentTypeLookupEditBuilder
	public class AppointmentTypeLookupEditBuilder : LookupEditBuilderBase
	{
		public AppointmentTypeLookupEditBuilder (RepositoryItemLookUpEdit lookupEdt) :  base(lookupEdt)
		{
			myDisplayMember = "strDescription";
			myValueMember = "nAppointmentTypeId";
			Refresh();
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] 
									  {
										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nAppointmentTypeId", "Appointment Type", 50, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription", "Description", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});						
			myLookupEdit.PopupWidth = 250;
		}

		public override void Refresh()
		{
			ACMSDAL.TblAppointmentType appointment = new ACMSDAL.TblAppointmentType();
			myDataTable = appointment.SelectAll();
			Init();
		}
	}
	#endregion

	#region MemberPackageIDLookupEditBuilder
	public class MemberPackageIDLookupEditBuilder : LookupEditBuilderBase
	{
		private string myMembershipID;
		private bool myIsServiceSession = false;
        private DateTime myDtAttendedDate;
        public MemberPackageIDLookupEditBuilder(RepositoryItemLookUpEdit lookupEdt, string strMembershipID, bool isServiceSession, DateTime dtAttendedDate)
            : base(lookupEdt)
        {
            myMembershipID = strMembershipID;
            myIsServiceSession = isServiceSession;
            myDtAttendedDate = dtAttendedDate;

            myDisplayMember = "nPackageID";
            myValueMember = "nPackageID";
            Refresh();
            myLookupEdit.Columns.Clear();
            myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] 
									  {
										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nPackageID", "Package ID", 10, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strPackageCode", "Package Code", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("dtExpiryDate", "Expiry Date", 20, DevExpress.Utils.FormatType.DateTime, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});

        }

        public override void Refresh()
        {
            ACMSDAL.TblMemberPackage memberPckg = new ACMSDAL.TblMemberPackage();
            if (myIsServiceSession)
                myDataTable = memberPckg.GetActiveMemberPackageForServiceSession(myMembershipID);
            else
                myDataTable = memberPckg.GetActiveMemberPackageForClassAttendance(myMembershipID);

            Init();
        }
	}
	#endregion

	#region BillFreebiePromotionCodeLookupEditBuilder
	public class BillFreebiePromotionCodeLookupEditBuilder : LookupEditBuilderBase
	{
		private string myID;
		private decimal myReceiptAmt;
        private string myBranchCode, myReceipt;
		private bool myIsMember = true;
		private int mySalesCategoryID;

		public BillFreebiePromotionCodeLookupEditBuilder(RepositoryItemLookUpEdit lookupEdt,
            string strID, decimal receiptAmt, string branchCode, int nCategoryID, bool isMember, string strReceipt)
            : base(lookupEdt)
		{
			ACMSDAL.TblCategory category = new ACMSDAL.TblCategory();
			category.NCategoryID = nCategoryID;
			category.SelectOne();
			mySalesCategoryID = ACMS.Convert.ToInt32(category.NSalesCategoryID); 

			myID = strID;
			myReceiptAmt = receiptAmt;
			myBranchCode = branchCode;
			myIsMember = isMember;
            myReceipt = strReceipt;

			myDisplayMember = "strPromotionCode";
			myValueMember = "strPromotionCode";
			Refresh();
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] 
									  {
										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strPromotionCode", "Promotion Code", 10, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription", "Description", 30, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("mMinimumAmount", "Minimum Amount", 15, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			
		}

		public DataRow GetDataRow(string strPromotionCode)
		{
			DataRow[] rowList = myDataTable.Select("strPromotionCode = '" + strPromotionCode + "'");
			if (rowList.Length == 1)
			{
				return rowList[0];
			}
			else
				return null;
		}

		public override void Refresh()
		{
            string cmdtext = "";

            ACMSDAL.TblPromotion promotion1 = new ACMSDAL.TblPromotion();
            myDataTable1 = promotion1.LoadData("select dtdate from tblreceipt where strreceiptNo = @strReceipt",
                new string[] { "@strReceipt" },
                new object[] { myReceipt });
            dtDate = DateTime.Now;
            if (myDataTable1.Rows.Count > 0)
                dtDate = System.Convert.ToDateTime(myDataTable1.Rows[0][0]);
			
			//if (myIsMember)
			//{
			cmdtext = " Select distinct A.* from tblPromotion A, tblMember B, tblLoyaltyStatus C, tblPromotionBranch D, tblPromotionReceiptSalesCategory E " + 
				" where A.FItemDiscount = 0 AND " + 
				" A.mMinimumAmount <= @ReceiptAmount And A.nApprovedStatusID = 1 AND " +
				" ( A.nPromotionTypeID = 1 or A.nPromotionTypeID = 2) AND " + 
				" A.dtValidStart <= @Date AND CONVERT(VARCHAR(10),A.dtValidEnd,102)+' 23:59:59' >= @Date AND " + 
				" ((A.nDiscountCategoryID = C.nDiscountCategoryID AND B.nLoyaltyStatusID = C.nLoyaltyStatusID) or A.nDiscountCategoryID =0) AND" + 
				" D.strPromotionCode = A.strPromotionCode and D.strBranchCode = @strBranchCode AND E.strPromotionCode = A.strPromotionCode AND " + 
				" B.StrMembershipID = @ID AND E.nSalesCategoryID = @nSalesCategoryID";
			//}
			ACMSDAL.TblPromotion promotion = new ACMSDAL.TblPromotion();
			myDataTable = promotion.LoadData(cmdtext, new string[] {"@ReceiptAmount", "@Date", "@strBranchCode", "@ID" , "@nSalesCategoryID"},
                new object[] { myReceiptAmt, dtDate, myBranchCode, myID, mySalesCategoryID });
			
			Init();
		}
	}
	#endregion

	#region BillDiscountPromotionCodeLookupEditBuilder
	public class BillDiscountPromotionCodeLookupEditBuilder : LookupEditBuilderBase
	{
		private string myID;
		private decimal myReceiptAmt;
		private string myBranchCode;
		private bool myIsMember = true;
		private int mySalesCategoryID;

		public BillDiscountPromotionCodeLookupEditBuilder(RepositoryItemLookUpEdit lookupEdt, 
			string strID, decimal receiptAmt, string branchCode, int nCategoryID, bool isMember) : base(lookupEdt)
		{
			ACMSDAL.TblCategory category = new ACMSDAL.TblCategory();
			category.NCategoryID = nCategoryID;
			category.SelectOne();
			mySalesCategoryID = ACMS.Convert.ToInt32(category.NSalesCategoryID); 

			myID = strID;
			myReceiptAmt = receiptAmt;
			myBranchCode = branchCode;
			myIsMember = isMember;

			myDisplayMember = "strPromotionCode";
			myValueMember = "strPromotionCode";
			Refresh();
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] 
									  {
										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strPromotionCode", "Promotion Code", 10, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription", "Description", 30, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("dDiscountPercent", "Discount Percent", 15, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("dDiscountValue", "Discount Value", 15, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			
		}

		public DataRow GetDataRow(string strPromotionCode)
		{
			DataRow[] rowList = myDataTable.Select("strPromotionCode = '" + strPromotionCode + "'");
			if (rowList.Length == 1)
			{
				return rowList[0];
			}
			else
				return null;
		}

		public override void Refresh()
		{

			string cmdtext = "";
			//if (myIsMember)
			//{
			cmdtext = " Select distinct A.* from tblPromotion A, tblMember B, tblLoyaltyStatus C, tblPromotionBranch D, tblPromotionReceiptSalesCategory E " + 
				" where A.FItemDiscount = 0 AND " + 
				" A.mMinimumAmount <= @ReceiptAmount And A.nApprovedStatusID = 1 AND " +
				" (A.nPromotionTypeID = 0) AND " + 
				" A.dtValidStart <= @Date AND A.dtValidEnd >= @Date AND " + 
				" ((A.nDiscountCategoryID = C.nDiscountCategoryID AND B.nLoyaltyStatusID = C.nLoyaltyStatusID) or A.nDiscountCategoryID =0) AND" + 
				" D.strPromotionCode = A.strPromotionCode and D.strBranchCode = @strBranchCode AND E.strPromotionCode = A.strPromotionCode AND " + 
				" B.StrMembershipID = @ID AND E.nSalesCategoryID = @nSalesCategoryID";
			//}
			ACMSDAL.TblPromotion promotion = new ACMSDAL.TblPromotion();
			myDataTable = promotion.LoadData(cmdtext, new string[] {"@ReceiptAmount", "@Date", "@strBranchCode", "@ID", "@nSalesCategoryID"},
				new object[]{myReceiptAmt, DateTime.Now.Date, myBranchCode, myID, mySalesCategoryID});
			
			Init();
		}
	}
	#endregion 
	#region BillDepositPromotionCodeLookupEditBuilder
	public class BillDepositPromotionCodeLookupEditBuilder : LookupEditBuilderBase
	{
		private string myID;
		private int mySalesCategoryID;
      

		public BillDepositPromotionCodeLookupEditBuilder(RepositoryItemLookUpEdit lookupEdt, 
			string strID, int nCategoryID) : base(lookupEdt)
		{
			ACMSDAL.TblCategory category = new ACMSDAL.TblCategory();
			category.NCategoryID = nCategoryID;
			category.SelectOne();
			mySalesCategoryID = ACMS.Convert.ToInt32(category.NSalesCategoryID); 

			myID = strID;
           
			myDisplayMember = "strReceiptNo";
			myValueMember = "strReceiptNo";
			RefreshDeposit();
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] 
									  {
										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strReceiptNo", "Receipt No", 10, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription", "Description", 30, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("mNettAmount", "Deposit Amount", 15, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
										  //new DevExpress.XtraEditors.Controls.LookUpColumnInfo("dDiscountValue", "Discount Value", 15, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			
		}

		public DataRow GetDataRow(string strPromotionCode)
		{
			DataRow[] rowList = myDataTable.Select("strPromotionCode = '" + strPromotionCode + "'");
			if (rowList.Length == 1)
			{
				return rowList[0];
			}
			else
				return null;
		}

		
		public void RefreshDeposit()
		{

			string cmdtext = "";
			//if (myIsMember)
			//{
            if (mySalesCategoryID == 6)
            {
                cmdtext = " Select strReceiptNo,strDescription,mNettAmount from tblReceipt R inner join tblCategory C on R.ncategoryID = C.ncategoryID" +
                               " where R.fDeposit <> '' and R.StrMembershipID = @ID AND C.nSalesCategoryID IN (1,2,6)" +
                               //" Union select cast(c.nPackageID as varchar(10)) as strReceiptNo,'Upgrade' as strDescription,mConverted as mNettAmount from tblmemberpackageconvertion c" +
                               " Union select strReceiptNo,'Upgrade' as strDescription,mConverted as mNettAmount from tblmemberpackageconvertion c" +
                               " inner join tblmemberpackage mp on c.nPackageID = mp.nPackageID where mp.strMembershipID= @ID AND C.nSalesCategory IN (1,2,6) and c.nStatusID = 0";
               
                ACMSDAL.TblReceipt Receipt = new ACMSDAL.TblReceipt();
                myDataTable = Receipt.LoadData(cmdtext, new string[] { "@ID", "@nSalesCategoryID" },
                    new object[] { myID, mySalesCategoryID });

                Init();
            }
            else
            {
                cmdtext = " Select strReceiptNo,strDescription,mNettAmount from tblReceipt R inner join tblCategory C on R.ncategoryID = C.ncategoryID" +
                        " where R.fDeposit <> '' and R.StrMembershipID = @ID  AND C.nSalesCategoryID = @nSalesCategoryID and R.fVoid=0 " +
                        //" Union select cast(c.nPackageID as varchar(10)) as strReceiptNo,'Upgrade' as strDescription,mConverted as mNettAmount from tblmemberpackageconvertion c" +
                         " Union select strReceiptNo,'Upgrade' as strDescription,mConverted as mNettAmount from tblmemberpackageconvertion c" +
                        " inner join tblmemberpackage mp on c.nPackageID = mp.nPackageID where mp.strMembershipID= @ID AND C.nSalesCategory = @nSalesCategoryID and c.nStatusID = 0" +
                        " Union select strReceiptNo,'Upgrade Credit' as strDescription,mConverted as mNettAmount from tblmemberpackageconvertion c" +
                        " inner join tblmembercreditpackage mc on c.nPackageID = mc.nCreditPackageID where mc.strMembershipID= @ID AND C.nSalesCategory = @nSalesCategoryID and c.nStatusID = 0";
                //}
                if (mySalesCategoryID == 1 || mySalesCategoryID == 2)
                    cmdtext = string.Concat(cmdtext, " Union Select strReceiptNo,strDescription,mNettAmount from tblReceipt R inner join tblCategory C on R.ncategoryID = C.ncategoryID where R.fDeposit <> '' and R.StrMembershipID = @ID AND fVoid=0 AND C.nSalesCategoryID = 9 ");

                ACMSDAL.TblReceipt Receipt = new ACMSDAL.TblReceipt();
                myDataTable = Receipt.LoadData(cmdtext, new string[] { "@ID", "@nSalesCategoryID" },
                    new object[] { myID, mySalesCategoryID });

                Init();
            }
		}
	}

	
	

	#endregion 

	#region ItemDiscountPromotionCodeLookupEditBuilder
	public class ItemDiscountPromotionCodeLookupEditBuilder : LookupEditBuilderBase
	{
		private string myID;
		private decimal myReceiptAmt;
		private int myCategoryTypeID;
		private int myCategoryID;
		private string myBranchCode;
		private string myStrCodeInTblItemPromotionToMatch;
		private bool myIsStaffPurchase = false;

		public ItemDiscountPromotionCodeLookupEditBuilder(RepositoryItemLookUpEdit lookupEdt, 
			string strID, decimal receiptAmt, int nCategoryTypeID, int nCategoryID, 
			string strCodeInTblItemPromotionToMatch, string branchCode, bool isStaffPurchase) : base(lookupEdt)
		{
			myID = strID;
			myReceiptAmt = receiptAmt;
			myBranchCode = branchCode;
			myIsStaffPurchase = isStaffPurchase;
			myCategoryTypeID = nCategoryTypeID;
			myCategoryID = nCategoryID;
			myStrCodeInTblItemPromotionToMatch = strCodeInTblItemPromotionToMatch;

			myDisplayMember = "strPromotionCode";
			myValueMember = "strPromotionCode";
			Refresh();
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] 
									  {
										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strPromotionCode", "Promotion Code", 10, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription", "Description", 30, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("dDiscountPercent", "Discount Percent", 15, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("dDiscountValue", "Discount Value", 15, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			
		}

		public DataRow GetDataRow(string strPromotionCode)
		{
			DataRow[] rowList = myDataTable.Select("strPromotionCode = '" + strPromotionCode + "'");
			if (rowList.Length == 1)
			{
				return rowList[0];
			}
			else
				return null;
		}

		public override void Refresh()
		{

			string cmdtext = "";
			if (!myIsStaffPurchase)
			{
					cmdtext = " Select distinct A.* from tblPromotion A, tblMember B, tblLoyaltyStatus C, tblPromotionBranch D where A.FItemDiscount = 1 AND " +
                    "  A.strPromotionCode <>'090018SPD' AND A.mMinimumAmount <= @ReceiptAmount And A.nApprovedStatusID = 1 AND " +
					" (A.nPromotionTypeID = 0) AND " + 
					" A.dtValidStart <= @Date AND A.dtValidEnd >= @Date AND " + 
					" ((A.nDiscountCategoryID = C.nDiscountCategoryID AND B.nLoyaltyStatusID = C.nLoyaltyStatusID) or A.nDiscountCategoryID = 0) AND" + 
					" D.strPromotionCode = A.strPromotionCode and D.strBranchCode = @strBranchCode AND " +
                    " B.StrMembershipID = @ID AND A.strPromotionCode in " +
                    " ( Select strPromotionCode from tblItemPromotion where " +
                    " (nCategoryTypeID = @nCategoryTypeID and nGroupID = 0 and strCode = @strCodeInTblItemPromotionToMatch) " +
                    " or (nCategoryTypeID = @nCategoryTypeID and nGroupID = 1 and strCode = '@nCategoryID'))" +
                    " union Select distinct A.* from tblPromotion A, tblMember B, tblLoyaltyStatus C where A.FItemDiscount = 1 AND " + //1105 newly add jackie
                    " A.mMinimumAmount <= @ReceiptAmount And A.nApprovedStatusID = 1 AND " +
                    " (A.nPromotionTypeID = 0) AND  ((A.nDiscountCategoryID = C.nDiscountCategoryID AND B.nLoyaltyStatusID = C.nLoyaltyStatusID) or A.nDiscountCategoryID = 0) AND " +
                    " strPromotionCode='090018SPD' and @nCategoryID =12 AND B.StrMembershipID = @ID and month(B.dtDOB) =month(GETDATE()) ";
			}
			else
			{
				cmdtext = " Select distinct A.* from tblPromotion A, tblEmployee B, tblJobPosition C, tblPromotionBranch D, tblMember E where A.FItemDiscount = 1 AND " + 
					" A.mMinimumAmount <= @ReceiptAmount And A.nApprovedStatusID = 1 AND " +
					" (A.nPromotionTypeID = 0) AND " + 
					" A.dtValidStart <= @Date AND A.dtValidEnd >= @Date AND " + 
					" ((A.nDiscountCategoryID = C.nDiscountCategoryID AND B.strJobPositionCode = C.strJobPositionCode) or A.nDiscountCategoryID =0) AND " + 
					" D.strPromotionCode = A.strPromotionCode and D.strBranchCode = @strBranchCode AND B.nEmployeeID = E.nMembershipNo AND " +
                    " E.StrMembershipID = @ID AND A.strPromotionCode in " +
                    " ( Select strPromotionCode from tblItemPromotion where " +
                    " (nCategoryTypeID = @nCategoryTypeID and nGroupID = 0 and strCode = @strCodeInTblItemPromotionToMatch) " +
                    " or (nCategoryTypeID = @nCategoryTypeID and nGroupID = 1 and strCode = '@nCategoryID'))";
			}


			ACMSDAL.TblPromotion promotion = new ACMSDAL.TblPromotion();
			myDataTable = promotion.LoadData(cmdtext, new string[] {"@ReceiptAmount", "@Date", "@strBranchCode", "@ID", "@nCategoryTypeID", "@strCodeInTblItemPromotionToMatch", "@nCategoryID"},
				new object[]{myReceiptAmt, DateTime.Now.Date, myBranchCode, myID, myCategoryTypeID, myStrCodeInTblItemPromotionToMatch, myCategoryID});
			
			Init();
		}
	}
	#endregion

	#region ItemFreebiePromotionCodeLookupEditBuilder
	public class ItemFreebiePromotionCodeLookupEditBuilder : LookupEditBuilderBase
	{
		private string myID;
		private decimal myReceiptAmt;
		private int myCategoryTypeID;
		private int myCategoryID;
		private string myBranchCode,myReceipt;
		private string myStrCodeInTblItemPromotionToMatch;
		private bool myIsStaffPurchase = false;
        private int myEntry;

		public ItemFreebiePromotionCodeLookupEditBuilder(RepositoryItemLookUpEdit lookupEdt, 
			string strID, decimal receiptAmt, int nCategoryTypeID, int nCategoryID,
            string strCodeInTblItemPromotionToMatch, string branchCode, bool isStaffPurchase,string strReceipt)
            : base(lookupEdt)
		{
			myID = strID;
			myReceiptAmt = receiptAmt;
			myBranchCode = branchCode;
			myIsStaffPurchase = isStaffPurchase;
			myCategoryTypeID = nCategoryTypeID;
			myCategoryID = nCategoryID;
			myStrCodeInTblItemPromotionToMatch = strCodeInTblItemPromotionToMatch;
            myReceipt = strReceipt;
           // myEntry = nEntryID;

			myDisplayMember = "strPromotionCode";
			myValueMember = "strPromotionCode";
			Refresh();
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] 
									  {
										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strPromotionCode", "Promotion Code", 10, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription", "Description", 30, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("mMinimumAmount", "Minimum Amount", 15, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			
		}

		public DataRow GetDataRow(string strPromotionCode)
		{
			DataRow[] rowList = myDataTable.Select("strPromotionCode = '" + strPromotionCode + "'");
			if (rowList.Length == 1)
			{
				return rowList[0];
			}
			else
				return null;
		}

		public override void Refresh()
		{

			string cmdtext = "";
            
            ACMSDAL.TblPromotion promotion1 = new ACMSDAL.TblPromotion();
            myDataTable1 = promotion1.LoadData("select dtdate from tblreceipt where strreceiptNo = @strReceipt",
                new string[] { "@strReceipt"},
                new object[] { myReceipt });
            dtDate = DateTime.Now;
            if (myDataTable1.Rows.Count > 0)
                dtDate = System.Convert.ToDateTime(myDataTable1.Rows[0][0]);
			if (!myIsStaffPurchase)//1105
			{
                cmdtext = " Select distinct A.* from tblPromotion A, tblEmployee B, tblJobPosition C, tblPromotionBranch D, tblMember E where A.FItemDiscount = 1 AND " +
                        " A.mMinimumAmount <= @ReceiptAmount And A.nApprovedStatusID = 1 AND " +
                        " (A.nPromotionTypeID = 1 or A.nPromotionTypeID = 2) AND " +
                        " A.dtValidStart <= cast(@Date as varchar(11)) AND A.dtValidEnd >= cast(@Date as varchar(11)) AND " +
                        " ((A.nDiscountCategoryID = C.nDiscountCategoryID AND B.strJobPositionCode = C.strJobPositionCode) or A.nDiscountCategoryID =0) AND " +
                        " D.strPromotionCode = A.strPromotionCode and D.strBranchCode = @strBranchCode AND " +
                        " E.StrMembershipID = @ID AND A.strPromotionCode in " +
                        " ( Select strPromotionCode from tblItemPromotion where " +
                        " (nCategoryTypeID = @nCategoryTypeID and nGroupID = 0 and strCode = @strCodeInTblItemPromotionToMatch) " +
                        " or (nCategoryTypeID = @nCategoryTypeID and nGroupID = 1 and strCode = @strCodeInTblItemPromotionToMatch))";

			}


			else
			{
				cmdtext = " Select distinct A.* from tblPromotion A, tblEmployee B, tblJobPosition C, tblPromotionBranch D, tblMember E where A.FItemDiscount = 1 AND " + 
					" A.mMinimumAmount <= @ReceiptAmount And A.nApprovedStatusID = 1 AND " +
					" (A.nPromotionTypeID = 1 or A.nPromotionTypeID = 2) AND " +
                    " A.dtValidStart <= cast(@Date as varchar(11)) AND A.dtValidEnd >= cast(@Date as varchar(11)) AND " + 
					" ((A.nDiscountCategoryID = C.nDiscountCategoryID AND B.strJobPositionCode = C.strJobPositionCode) or A.nDiscountCategoryID =0) AND " + 
					" D.strPromotionCode = A.strPromotionCode and D.strBranchCode = @strBranchCode AND B.nEmployeeID = E.nMembershipNo AND " + 
					" E.StrMembershipID = @ID AND A.strPromotionCode in " +
                    " ( Select strPromotionCode from tblItemPromotion where " +
                    " (nCategoryTypeID = @nCategoryTypeID and nGroupID = 0 and strCode = @strCodeInTblItemPromotionToMatch) " +
                    " or (nCategoryTypeID = @nCategoryTypeID and nGroupID = 1 and strCode = @strCodeInTblItemPromotionToMatch))";
			}


			ACMSDAL.TblPromotion promotion = new ACMSDAL.TblPromotion();
			myDataTable = promotion.LoadData(cmdtext, 
				new string[] {"@ReceiptAmount", "@Date", "@strBranchCode", "@ID", "@nCategoryTypeID", "@strCodeInTblItemPromotionToMatch", "@nCategoryID"},
                new object[] { myReceiptAmt, dtDate, myBranchCode, myID, myCategoryTypeID, myStrCodeInTblItemPromotionToMatch, myCategoryID });
			
			Init();
		}
	}
	#endregion

	#region RewardCodeLookupEditBuilder
	public class RewardCodeLookupEditBuilder : LookupEditBuilderBase
	{
		private string myStrBranchCode;
		private int mySalesCategory;

		public RewardCodeLookupEditBuilder(RepositoryItemLookUpEdit lookupEdt, 
			string strBranchCode, int nSalesCategoryID) : base(lookupEdt)
		{
			myStrBranchCode = strBranchCode;
			mySalesCategory = nSalesCategoryID;

			myDisplayMember = "strRewardsCode";
			myValueMember = "strRewardsCode";
			Refresh();
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] 
									  {
										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strRewardsCode", "Reward Code", 10, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription", "Description", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			
		}

		public override void Refresh()
		{
			string cmdText = "Select * From tblRewards A, tblRewardsBRanch B Where A.strRewardsCode = B.strRewardsCode AND " + 
				" A.nTypeID = 1 AND A.nSalesCategoryID = @nSalesCategoryID AND A.dtValidStart <= @dtDate AND " + 
				" A.dtValidEnd >= @dtDate AND B.strBranchCode = @strBranchCode ";

			ACMSDAL.TblRewards reward = new ACMSDAL.TblRewards();
			myDataTable = reward.LoadData(cmdText, new string []{"@nSalesCategoryID", "@dtDate", "@strBranchCode" }, 
				new object[] {mySalesCategory, DateTime.Today.Date, myStrBranchCode});
			Init();
		}

		public DataTable SelectRewards(int SalesCategory,string strBranchCode)
		{
			string cmdText = "Select * From tblRewards A, tblRewardsBRanch B Where A.strRewardsCode = B.strRewardsCode AND " + 
				" A.nTypeID = 1 AND A.nSalesCategoryID = @nSalesCategoryID AND A.dtValidStart <= @dtDate AND " + 
				" A.dtValidEnd >= @dtDate AND B.strBranchCode = @strBranchCode ";

			ACMSDAL.TblRewards reward = new ACMSDAL.TblRewards();
			myDataTable = reward.LoadData(cmdText, new string []{"@nSalesCategoryID", "@dtDate", "@strBranchCode" }, 
				new object[] {SalesCategory, DateTime.Today.Date, strBranchCode});
			return myDataTable;
		}
	}
	#endregion

	#region PaymentGroupCodeLookupEditBuilder
	public class PaymentGroupCodeLookupEditBuilder : LookupEditBuilderBase
	{
		public PaymentGroupCodeLookupEditBuilder(RepositoryItemLookUpEdit lookupEdt) : base(lookupEdt)
		{
			myDisplayMember = "strPaymentGroupCode";
			myValueMember =   "strPaymentGroupCode";
			Refresh();
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] 
									  {
										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strPaymentGroupCode", "Payment Group Code", 10, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription", "Description", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			
		}

		public override void Refresh()
		{
			ACMSDAL.TblPaymentGroup paymentGroup = new ACMSDAL.TblPaymentGroup();
			myDataTable = paymentGroup.SelectAll();
			Init();
		}
	}
	#endregion

	#region PaymentCodeLookupEditBuilder
	public class PaymentCodeLookupEditBuilder : LookupEditBuilderBase
	{
		private string myPaymentGroupCode;
		public PaymentCodeLookupEditBuilder(RepositoryItemLookUpEdit lookupEdt, string strPaymentGroupCode) : base(lookupEdt)
		{
			myPaymentGroupCode = strPaymentGroupCode;
			myDisplayMember = "strPaymentCode";
			myValueMember = "strPaymentCode";
			Refresh();
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] 
									  {
										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strPaymentCode", "Payment Code", 10, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription", "Description", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			
		}

		public override void Refresh()
		{
			ACMSDAL.TblPayment payment = new ACMSDAL.TblPayment();
			payment.StrPaymentGroupCode = myPaymentGroupCode;
			myDataTable = payment.SelectAllWstrPaymentGroupCodeLogic();
			Init();
		}

		public void Refresh(string paymentGroupCode)
		{
			myPaymentGroupCode = paymentGroupCode;
			ACMSDAL.TblPayment payment = new ACMSDAL.TblPayment();
			payment.StrPaymentGroupCode = myPaymentGroupCode;
			myDataTable = payment.SelectAllWstrPaymentGroupCodeLogic();
			Init();
		}
	}
	#endregion

	#region BankCodeLookupEditBuilder
	public class BankCodeLookupEditBuilder : LookupEditBuilderBase
	{
		public BankCodeLookupEditBuilder(RepositoryItemLookUpEdit lookupEdt) : base(lookupEdt)
		{
			myDisplayMember = "strBankCode";
			myValueMember = "strBankCode";
			Refresh();
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] 
									  {
										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strBankCode", "Bank Code", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription", "Description", 30, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			
		}

		public override void Refresh()
		{
			ACMSDAL.TblBank bank = new ACMSDAL.TblBank(); 
			myDataTable = bank.SelectAll();
			Init();
		}
	}
	#endregion

	#region MonthOfInstallmentLookupEditBuilder
	public class MonthOfInstallmentLookupEditBuilder : LookupEditBuilderBase
	{
		private string myStrBankCode = "";
		//private string strBranchCode = "";

		public MonthOfInstallmentLookupEditBuilder(RepositoryItemLookUpEdit lookupEdt, 
			string strBankCode) : base(lookupEdt)
		{
			myStrBankCode = strBankCode;
			myDisplayMember = "nMonth";
			myValueMember = "nMonth";
			Refresh();
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] 
									  {
										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nMonth", "No Of Months Of Installment", 15, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			
		}

		public override void Refresh()
		{
			ACMSDAL.TblBankIPPRate bankIPPRate = new ACMSDAL.TblBankIPPRate(); 
			bankIPPRate.StrBankCode = myStrBankCode;
			myDataTable = bankIPPRate.SelectAllWstrBankCodeLogic();
			Init();
		}

		public void Refresh(string strBankCode)
		{
			myStrBankCode = strBankCode;
			ACMSDAL.TblBankIPPRate bankIPPRate = new ACMSDAL.TblBankIPPRate(); 
			bankIPPRate.StrBankCode = myStrBankCode;
			myDataTable = bankIPPRate.SelectAllWstrBankCodeLogic();
			Init();
		}
	}
	#endregion

	#region BankIPPMerchantLookupEditBuilder
	public class BankIPPMerchantLookupEditBuilder : LookupEditBuilderBase
	{
		private string myStrBankCode = "";
		private string myStrBranchCode = "";
		private int myNMonthOfInstallment;

		public BankIPPMerchantLookupEditBuilder(RepositoryItemLookUpEdit lookupEdt,
			string strBankCode, string strBranchCode, int nMonthsOfInstallment) : base(lookupEdt)
		{
			myStrBankCode = strBankCode;
			myStrBranchCode = strBranchCode;
			myNMonthOfInstallment = nMonthsOfInstallment;

			myDisplayMember = "strMerchantNo";
			myValueMember = "strMerchantNo";
			Refresh();
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] 
									  {
										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strMerchantNo", "Merchant No", 15, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strBranchCode", "Branch Code", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			
		}

		public override void Refresh()
		{
			ACMSDAL.TblBanklPPMerchant bankIPPMerchant = new ACMSDAL.TblBanklPPMerchant(); 
			myDataTable = bankIPPMerchant.GetMerchant(myStrBankCode, 
				myStrBranchCode, myNMonthOfInstallment);
			Init();
		}

        public DataTable MerchantNoTable
		{
			get {return myDataTable; }
		}

		public void Refresh(string strBankCode, 
			string strBranchCode, int nMonthsOfInstallment)
		{
			myStrBankCode = strBankCode;
			myStrBranchCode = strBranchCode;
			myNMonthOfInstallment = nMonthsOfInstallment;

			ACMSDAL.TblBanklPPMerchant bankIPPMerchant = new ACMSDAL.TblBanklPPMerchant(); 
			myDataTable = bankIPPMerchant.GetMerchant(myStrBankCode, 
				myStrBranchCode, myNMonthOfInstallment);
			Init();
		}
	}
	#endregion

	#region BankBranchCodeLookupEditBuilder
	public class BankBranchCodeLookupEditBuilder : LookupEditBuilderBase
	{
		string myBankCode = "";

		public BankBranchCodeLookupEditBuilder(RepositoryItemLookUpEdit lookupEdt, string bankCode) : base(lookupEdt)
		{
			myBankCode = bankCode;
			myDisplayMember = "strBankBranchCode";
			myValueMember = "strBankBranchCode";
			Refresh();
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] 
									  {
										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strBankBranchCode", "Bank Branch Code", 10, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription", "Description", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			
		}

		public override void Refresh()
		{
			ACMSDAL.TblBankBranch bankbranch = new ACMSDAL.TblBankBranch();
			bankbranch.StrBankCode = myBankCode;
			myDataTable = bankbranch.SelectAllWstrBankCodeLogic();
			Init();
		}

		public void Refresh(string bankCode)
		{
			myBankCode = bankCode;
			ACMSDAL.TblBankBranch bankbranch = new ACMSDAL.TblBankBranch();
			bankbranch.StrBankCode = myBankCode;
			myDataTable = bankbranch.SelectAllWstrBankCodeLogic();
			Init();
		}
	}
	#endregion

	#region IPPLookupEditBuilder
	public class IPPLookupEditBuilder : LookupEditBuilderBase
	{
		private string myStrMembershipID = "";
		private string myStrBranchCode = "";

		public IPPLookupEditBuilder(RepositoryItemLookUpEdit lookupEdt, 
			string strBranchCode, string strMembershipID) : base(lookupEdt)
		{
			myStrBranchCode = strBranchCode;
			myStrMembershipID = strMembershipID;
			myDisplayMember = "BankDesc";
			myValueMember = "nIPPID";
			Refresh();
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] 
									  {
											new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nIPPID", "IPP ID", 15, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
											new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strBankCode", "Bank Code", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
											new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strMerchantNo", "Merchant No", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
											new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nMonths", "Months", 15, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
											new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strCreditCardNo", "Credit Card", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			
		}

		public override void Refresh()
		{
			ACMSDAL.TblIPP sqlIPP = new ACMSDAL.TblIPP();
			myDataTable = sqlIPP.GetIPP(myStrMembershipID, myStrBranchCode);
			Init();
		}

		public void Refresh(string strMembershipID, string strBranchCode)
		{
			myStrBranchCode = strBranchCode;
			myStrMembershipID = strMembershipID;
			ACMSDAL.TblIPP sqlIPP = new ACMSDAL.TblIPP();
			myDataTable = sqlIPP.GetIPP(myStrMembershipID, myStrBranchCode);
			Init();
		}

		public DataTable GetDataTable()
		{
			return myDataTable;
		}
	}
	#endregion

	#region LeaveCodeLookupEditBuilder
	public class LeaveCodeLookupEditBuilder : LookupEditBuilderBase
	{
		public LeaveCodeLookupEditBuilder (int nEmployee,RepositoryItemLookUpEdit lookupEdt) :  base(lookupEdt)
		{
			myDisplayMember = "strDescription";
			myValueMember = "strLeaveCode";
            Refresh(nEmployee);
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] 
									  {
										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strLeaveCode", "Leave Code", 50, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription", "Description", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});						
			myLookupEdit.PopupWidth = 250;
		}

        public void Refresh(int nEmployeeID)
		{
			ACMSDAL.TblLeaveType leaveType = new ACMSDAL.TblLeaveType();

            myDataTable = leaveType.SelectAll(nEmployeeID);
			Init();
		}
	}
	#endregion

	#region DiscountCategoryLookupEditBuilder
	public class DiscountCategoryLookupEditBuilder : LookupEditBuilderBase
	{
		public DiscountCategoryLookupEditBuilder (RepositoryItemLookUpEdit lookupEdt) :  base(lookupEdt)
		{
			myDisplayMember = "strDescription";
			myValueMember = "nDiscountCategoryID";
			Refresh();
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] 
									  {
										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nDiscountCategoryID", "Discount Category", 50, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
										  new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription", "Description", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});						
			myLookupEdit.PopupWidth = 250;
		}

		public override void Refresh()
		{
			ACMSDAL.TblDiscountCategory discountCategory = new ACMSDAL.TblDiscountCategory();
			myDataTable = discountCategory.SelectAll();
			Init();
		}
	}
	#endregion

	#region EmployeeIDWithfMemoGroupFilterLookupEditBuilder
	public class EmployeeIDWithfMemoGroupFilterLookupEditBuilder : LookupEditBuilderBase
	{
		public EmployeeIDWithfMemoGroupFilterLookupEditBuilder(RepositoryItemLookUpEdit lookupEdt) : base(lookupEdt)
		{
			//
			// TODO: Add constructor logic here
			//
			myDisplayMember = "strEmployeeName";
			myValueMember = "nEmployeeID";
			Refresh(false);
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nEmployeeID", "Employee ID", 50, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strEmployeeName", "Name", 150, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.Ascending),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strBranchCode", "Branch Code", 50, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nDepartmentID", "Department ID", 50, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			myLookupEdit.PopupWidth = 300;
		}

		public void Refresh(bool isLoadCurrentBranch)
		{
			ACMSDAL.TblEmployee employee = new ACMSDAL.TblEmployee();
			myDataTable = employee.SelectAllWithfMemoGroupFilter();

			Init();
		}
	}
	#endregion

	#region PackageCodeForCreditPackageLookupEditBuilder
	public class PackageCodeForCreditPackageLookupEditBuilder : LookupEditBuilderBase
	{
		private int myCreditPackageID;

		public PackageCodeForCreditPackageLookupEditBuilder(RepositoryItemLookUpEdit lookupEdt, 
			int nCreditPackageID) : base(lookupEdt)
		{
			myDisplayMember = "strDescription";
			myValueMember = "strPackageCode";
			myCreditPackageID = nCreditPackageID;
			Refresh();
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strPackageCode", "Package Code", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription", "Description", 25, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("dtValidEnd", "Valid End", 20, DevExpress.Utils.FormatType.DateTime, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			
		}
        

		public override void Refresh()
		{
			ACMSDAL.TblPackage sqlPackage = new ACMSDAL.TblPackage();
			myDataTable = sqlPackage.GetValidPackageFromBranchForCreditPackageUsage(ACMSLogic.User.BranchCode, myCreditPackageID);
			Init();
		}
	}
	#endregion


	#region PromotionCodeForMemberPackageLookupEditBuilder
	public class PromotionCodeForMemberPackageLookupEditBuilder : LookupEditBuilderBase
	{
		private string myStrBranchCode;

		public PromotionCodeForMemberPackageLookupEditBuilder(RepositoryItemLookUpEdit lookupEdt, 
			string strMembershipID, string strBranchCode) : base(lookupEdt)
		{
			myDisplayMember = "strPromotionCode";
			myValueMember = "strPromotionCode";
			myStrBranchCode = strBranchCode;
			Refresh();
            myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strPromotionCode", "Promotion Code", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription", "Description", 25, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("dtValidEnd", "Valid End", 20, DevExpress.Utils.FormatType.DateTime, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			
		}

		public override void Refresh()
		{
			ACMSDAL.TblPromotion sqlPromotion = new ACMSDAL.TblPromotion();
			myDataTable = sqlPromotion.GetPromotionForMemberPackage(myStrBranchCode);
			Init();
		}
	}		
	

	#endregion

	#region MemberLookerLookupEditBuilder
	public class MemberLookerLookupEditBuilder : LookupEditBuilderBase
	{
		string strMembershipID = string.Empty;

		public MemberLookerLookupEditBuilder (string strMembershipID, RepositoryItemLookUpEdit lookupEdt) :  base(lookupEdt)
		{
			this.strMembershipID = strMembershipID;
			myDisplayMember = "nLockerNo";
			myValueMember = "nLockerNo";
			Refresh();
			myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strBranchCode", "Branch", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nLockerNo", "Locker No.", 100, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("dtExpiry", "Expiry Date", 250, DevExpress.Utils.FormatType.DateTime, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			myLookupEdit.PopupWidth = 450;
		}

		public override void Refresh()
		{
			if (strMembershipID.Length != 0)
			{
				ACMSDAL.TblLocker locker = new ACMSDAL.TblLocker();
				locker.StrMembershipID = strMembershipID;
				myDataTable = locker.SelectAllWstrMembershipIDLogic();
				Init();
			}
			else
			{
				myDataTable = new DataTable();
				Init();
			}

		}
	}
	#endregion

	#region Manager Module
	#region ManagerMemberIDLookupEditBuilder
	public class ManagerMemberIDLookupEditBuilder : LookupEditBuilderBase
	{
		public ManagerMemberIDLookupEditBuilder(DataTable table, RepositoryItemLookUpEdit lookupEdt) : base (table, lookupEdt)
		{
			//
			// TODO: Add constructor logic here
			//
			myDataTable = table;
			myLookupEdit = lookupEdt;
			Init();

			myLookupEdit.DisplayMember = "strMembershipID";
			myLookupEdit.ValueMember = "strMembershipID";

			myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strMembershipID", "Member ID", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strMemberName", "Member Name", 250, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			myLookupEdit.NullText = "";
			myLookupEdit.PopupWidth = 450;
		}
	}
	#endregion

	#region ManagerMemberIDLookupEditBuilder
	public class ManagerEmployeeIDLookupEditBuilder : LookupEditBuilderBase
	{
		public ManagerEmployeeIDLookupEditBuilder(DataTable table, RepositoryItemLookUpEdit lookupEdt) : base (table, lookupEdt)
		{
			//
			// TODO: Add constructor logic here
			//
			myDataTable = table;
			myLookupEdit = lookupEdt;
			Init();

			myLookupEdit.DisplayMember = "strEmployeeName";
			myLookupEdit.ValueMember = "nEmployeeID";

			myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nEmployeeID", "Member ID", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strEmployeeName", "Member Name", 250, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			myLookupEdit.NullText = "";
			myLookupEdit.PopupWidth = 450;
		}
	}
	#endregion

	#region ManagerBranchCodeLookupEditBuilder
	public class ManagerBranchCodeLookupEditBuilder : LookupEditBuilderBase
	{
		public ManagerBranchCodeLookupEditBuilder(DataTable table, RepositoryItemLookUpEdit lookupEdt) : base (table, lookupEdt)
		{
			//
			// TODO: Add constructor logic here
			//
			myDataTable = table;
			myLookupEdit = lookupEdt;
			Init();

			myLookupEdit.DisplayMember = "strBranchCode";
			myLookupEdit.ValueMember = "strBranchCode";

			myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strBranchCode", "BranchCode", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strBranchName", "Branch Name", 250, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			myLookupEdit.NullText = "";
			myLookupEdit.PopupWidth = 450;
		}
	}
	#endregion
    #region ManagerHallCodeLookupEditBuilder 
    public class ManagerHallCodeLookupEditBuilder : LookupEditBuilderBase
    {
        public ManagerHallCodeLookupEditBuilder(DataTable table, RepositoryItemLookUpEdit lookupEdt)
            : base(table, lookupEdt)
        {
            //
            // TODO: Add constructor logic here
            //
            myDataTable = table;
            myLookupEdit = lookupEdt;
            Init();

            myLookupEdit.DisplayMember = "strHallName";
            myLookupEdit.ValueMember = "nHallNo";

            myLookupEdit.Columns.Clear();
            myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nHallNo", "HallNo", 10, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strHallName", "Hall Name", 250, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            myLookupEdit.NullText = "";
            myLookupEdit.PopupWidth = 450;
        }
    }
    #endregion

    #region ManagerPeriodLookupEditBuilder
    public class ManagerPeriodLookupEditBuilder : LookupEditBuilderBase
    {
        public ManagerPeriodLookupEditBuilder(DataTable table, RepositoryItemLookUpEdit lookupEdt)
            : base(table, lookupEdt)
        {
            //
            // TODO: Add constructor logic here
            //
            myDataTable = table;
            myLookupEdit = lookupEdt;
            Init();

            myLookupEdit.DisplayMember = "strPeriod";
            myLookupEdit.ValueMember = "strPeriod";

            myLookupEdit.Columns.Clear();
            myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {																									 
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strPeriod", "Period", 250, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            myLookupEdit.NullText = "";
            myLookupEdit.PopupWidth = 350;
        }
    }
    #endregion

	#region ManagerBankLookupEditBuilder
	public class ManagerBankLookupEditBuilder : LookupEditBuilderBase
	{
		public ManagerBankLookupEditBuilder(DataTable table, RepositoryItemLookUpEdit lookupEdt) : base (table, lookupEdt)
		{
			//
			// TODO: Add constructor logic here
			//
			myDataTable = table;
			myLookupEdit = lookupEdt;
			Init();

			myLookupEdit.DisplayMember = "strDescription";
			myLookupEdit.ValueMember = "strBankCode";

			myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strBankCode", "Bank Code", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription", "Description", 250, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			myLookupEdit.NullText = "";
			myLookupEdit.PopupWidth = 450;
		}
	}
	#endregion

	#region ManagerBankBranchLookupEditBuilder
	public class ManagerBankBranchLookupEditBuilder : LookupEditBuilderBase
	{
		public ManagerBankBranchLookupEditBuilder(DataTable table, RepositoryItemLookUpEdit lookupEdt) : base (table, lookupEdt)
		{
			//
			// TODO: Add constructor logic here
			//
			myDataTable = table;
			myLookupEdit = lookupEdt;
			Init();

			myLookupEdit.DisplayMember = "strDescription";
			myLookupEdit.ValueMember = "strBankBranchCode";

			myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strBankBranchCode", "Bank Branch Code", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strBankCode", "Bank Code", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription", "Description", 250, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			myLookupEdit.NullText = "";
			myLookupEdit.PopupWidth = 450;
		}
	}
	#endregion

	#region ManagerPackageLookupEditBuilder
	public class ManagerPackageLookupEditBuilder : LookupEditBuilderBase
	{
		public ManagerPackageLookupEditBuilder(DataTable table, RepositoryItemLookUpEdit lookupEdt) : base (table, lookupEdt)
		{
			//
			// TODO: Add constructor logic here
			//
			myDataTable = table;
			myLookupEdit = lookupEdt;
			Init();

			myLookupEdit.DisplayMember = "strDescription";
			myLookupEdit.ValueMember = "strPackageCode";

			myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strPackageCode", "Package Code", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription", "Description", 250, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			myLookupEdit.NullText = "";
			myLookupEdit.PopupWidth = 450;
		}
	}
	#endregion

	#region ManagerClassTypeLookupEditBuilder
	public class ManagerClassTypeLookupEditBuilder : LookupEditBuilderBase
	{
		public ManagerClassTypeLookupEditBuilder(DataTable table, RepositoryItemLookUpEdit lookupEdt) : base (table, lookupEdt)
		{
			//
			// TODO: Add constructor logic here
			//
			myDataTable = table;
			myLookupEdit = lookupEdt;
			Init();

			myLookupEdit.DisplayMember = "strDescription";
			myLookupEdit.ValueMember = "nClassTypeID";

			myLookupEdit.Columns.Clear();
			myLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nClassTypeID", "Class Type ID", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
																									 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strBranchName", "Description", 250, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			myLookupEdit.NullText = "";
			myLookupEdit.PopupWidth = 450;
		}
	}
	#endregion
	#endregion
}