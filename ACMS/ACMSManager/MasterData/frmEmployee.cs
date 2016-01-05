using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;
using ACMS.XtraUtils.LookupEditBuilder;
using System.Data.OleDb;
using ACMS.Utils;

namespace ACMS.ACMSManager.MasterData
{
	/// <summary>
	/// Summary description for frmEmployee.
	/// </summary>
	public class frmEmployee : System.Windows.Forms.Form
	{
		private string connectionString;
		private SqlConnection connection;
		private DevExpress.XtraEditors.GroupControl grpMDEmployeeTop;
		internal DevExpress.XtraEditors.SimpleButton btn_Add;
		internal DevExpress.XtraEditors.SimpleButton btn_Del;
		private System.Windows.Forms.ImageList imageList1;
		private System.ComponentModel.IContainer components;
		private DevExpress.XtraGrid.GridControl gridControlMd_Employee;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewMd_Employee;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnEmp1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnEmp2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_JobPosition;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_BranchCode;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit EmpStartDate;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_RightsLevel;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_InstructorType;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
		private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox cmbServiceCom;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkPartTime;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
		private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox cmbStatus;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_Department;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chk_Probation;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chk_MaternityLeave;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chk_ChildCareLeave;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chk_RegisterFee;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chk_PTInstructor;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chk_SalesPerson;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chk_ServiceComm;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit lk_Instructor;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit lk_MemoGroup;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_ServiceComm;
		private System.Windows.Forms.Panel Searchpanel;
		internal DevExpress.XtraEditors.TextEdit txtSearch;
        internal DevExpress.XtraEditors.SimpleButton btn_Search;
		private DevExpress.XtraGrid.Columns.GridColumn nLeaveGroup;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chk_StatusID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
		private DataTable dtEmployee;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit EditCessation;
        private DevExpress.XtraEditors.GroupControl grpBranch;
        private DevExpress.XtraEditors.SimpleButton btnPacBranch_Del;
        private DevExpress.XtraEditors.SimpleButton btnPacBranch_DelAll;
        private DevExpress.XtraEditors.SimpleButton btnPacBranch_AddAll;
        private DevExpress.XtraEditors.SimpleButton btnPacBranch_Add;
        private DevExpress.XtraGrid.GridControl gridPacBranch2;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPacBranch2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn33;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn34;
        private Label label6;
        private DevExpress.XtraGrid.GridControl gridPacBranch;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPacBranch;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn35;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn36;
        private Label label2;
        private Label label1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private Label label3;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn26;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private Label label4;
        private DevExpress.XtraEditors.GroupControl gcServiceType;
        private DevExpress.XtraEditors.SimpleButton sbPrevious;
        private DevExpress.XtraEditors.SimpleButton sbPreviousAll;
        private DevExpress.XtraEditors.SimpleButton sbNextAll;
        private DevExpress.XtraEditors.SimpleButton sbNext;
        private DevExpress.XtraGrid.GridControl gridControl5;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn31;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn32;
        private Label label7;
        private DevExpress.XtraGrid.GridControl gridControl6;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn37;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn38;
        public string strEditEmployee;

		public frmEmployee(string strEditEmp)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);
            strEditEmployee = strEditEmp;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmployee));
            this.grpMDEmployeeTop = new DevExpress.XtraEditors.GroupControl();
            this.gcServiceType = new DevExpress.XtraEditors.GroupControl();
            this.sbPrevious = new DevExpress.XtraEditors.SimpleButton();
            this.sbPreviousAll = new DevExpress.XtraEditors.SimpleButton();
            this.sbNextAll = new DevExpress.XtraEditors.SimpleButton();
            this.sbNext = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl5 = new DevExpress.XtraGrid.GridControl();
            this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn31 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn32 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.gridControl6 = new DevExpress.XtraGrid.GridControl();
            this.gridView6 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn37 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn38 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.grpBranch = new DevExpress.XtraEditors.GroupControl();
            this.btnPacBranch_Del = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnPacBranch_DelAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnPacBranch_AddAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnPacBranch_Add = new DevExpress.XtraEditors.SimpleButton();
            this.gridPacBranch2 = new DevExpress.XtraGrid.GridControl();
            this.gvPacBranch2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn33 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn34 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.gridPacBranch = new DevExpress.XtraGrid.GridControl();
            this.gvPacBranch = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn35 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn36 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Searchpanel = new System.Windows.Forms.Panel();
            this.btn_Search = new DevExpress.XtraEditors.SimpleButton();
            this.txtSearch = new DevExpress.XtraEditors.TextEdit();
            this.gridControlMd_Employee = new DevExpress.XtraGrid.GridControl();
            this.gridViewMd_Employee = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnEmp1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnEmp2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lk_JobPosition = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lk_BranchCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EmpStartDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lk_RightsLevel = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lk_InstructorType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmbServiceCom = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nLeaveGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkPartTime = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chk_StatusID = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lk_Department = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chk_Probation = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chk_MaternityLeave = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chk_ChildCareLeave = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chk_RegisterFee = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chk_PTInstructor = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chk_SalesPerson = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chk_ServiceComm = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lk_Instructor = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lk_MemoGroup = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EditCessation = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.cmbStatus = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.lk_ServiceComm = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.btn_Add = new DevExpress.XtraEditors.SimpleButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btn_Del = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grpMDEmployeeTop)).BeginInit();
            this.grpMDEmployeeTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcServiceType)).BeginInit();
            this.gcServiceType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpBranch)).BeginInit();
            this.grpBranch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPacBranch2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPacBranch2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPacBranch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPacBranch)).BeginInit();
            this.Searchpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMd_Employee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMd_Employee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_JobPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_BranchCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpStartDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpStartDate.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_RightsLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_InstructorType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbServiceCom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPartTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_StatusID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_Department)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_Probation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_MaternityLeave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_ChildCareLeave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_RegisterFee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_PTInstructor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_SalesPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_ServiceComm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_Instructor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_MemoGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditCessation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditCessation.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_ServiceComm)).BeginInit();
            this.SuspendLayout();
            // 
            // grpMDEmployeeTop
            // 
            this.grpMDEmployeeTop.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.grpMDEmployeeTop.Appearance.Options.UseBackColor = true;
            this.grpMDEmployeeTop.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMDEmployeeTop.AppearanceCaption.Options.UseFont = true;
            this.grpMDEmployeeTop.Controls.Add(this.gcServiceType);
            this.grpMDEmployeeTop.Controls.Add(this.label4);
            this.grpMDEmployeeTop.Controls.Add(this.grpBranch);
            this.grpMDEmployeeTop.Controls.Add(this.label2);
            this.grpMDEmployeeTop.Controls.Add(this.label1);
            this.grpMDEmployeeTop.Controls.Add(this.Searchpanel);
            this.grpMDEmployeeTop.Controls.Add(this.gridControlMd_Employee);
            this.grpMDEmployeeTop.Controls.Add(this.btn_Add);
            this.grpMDEmployeeTop.Controls.Add(this.btn_Del);
            this.grpMDEmployeeTop.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grpMDEmployeeTop.Location = new System.Drawing.Point(0, 0);
            this.grpMDEmployeeTop.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.grpMDEmployeeTop.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grpMDEmployeeTop.Name = "grpMDEmployeeTop";
            this.grpMDEmployeeTop.Size = new System.Drawing.Size(1063, 572);
            this.grpMDEmployeeTop.TabIndex = 90;
            this.grpMDEmployeeTop.Text = "Employee";
            // 
            // gcServiceType
            // 
            this.gcServiceType.Controls.Add(this.sbPrevious);
            this.gcServiceType.Controls.Add(this.sbPreviousAll);
            this.gcServiceType.Controls.Add(this.sbNextAll);
            this.gcServiceType.Controls.Add(this.sbNext);
            this.gcServiceType.Controls.Add(this.gridControl5);
            this.gcServiceType.Controls.Add(this.label7);
            this.gcServiceType.Controls.Add(this.gridControl6);
            this.gcServiceType.Location = new System.Drawing.Point(8, 352);
            this.gcServiceType.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.gcServiceType.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gcServiceType.Name = "gcServiceType";
            this.gcServiceType.Size = new System.Drawing.Size(984, 210);
            this.gcServiceType.TabIndex = 156;
            this.gcServiceType.Text = "Employee Service Type";
            // 
            // sbPrevious
            // 
            this.sbPrevious.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbPrevious.Location = new System.Drawing.Point(496, 96);
            this.sbPrevious.Name = "sbPrevious";
            this.sbPrevious.Size = new System.Drawing.Size(30, 20);
            this.sbPrevious.TabIndex = 21;
            this.sbPrevious.Text = "<";
            this.sbPrevious.Click += new System.EventHandler(this.sbPrevious_Click);
            // 
            // sbPreviousAll
            // 
            this.sbPreviousAll.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbPreviousAll.Location = new System.Drawing.Point(496, 72);
            this.sbPreviousAll.Name = "sbPreviousAll";
            this.sbPreviousAll.Size = new System.Drawing.Size(30, 20);
            this.sbPreviousAll.TabIndex = 20;
            this.sbPreviousAll.Text = "<<";
            this.sbPreviousAll.Click += new System.EventHandler(this.sbPreviousAll_Click);
            // 
            // sbNextAll
            // 
            this.sbNextAll.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbNextAll.Location = new System.Drawing.Point(496, 48);
            this.sbNextAll.Name = "sbNextAll";
            this.sbNextAll.Size = new System.Drawing.Size(30, 20);
            this.sbNextAll.TabIndex = 19;
            this.sbNextAll.Text = ">>";
            this.sbNextAll.Click += new System.EventHandler(this.sbNextAll_Click);
            // 
            // sbNext
            // 
            this.sbNext.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbNext.Location = new System.Drawing.Point(496, 24);
            this.sbNext.Name = "sbNext";
            this.sbNext.Size = new System.Drawing.Size(30, 20);
            this.sbNext.TabIndex = 18;
            this.sbNext.Text = ">";
            this.sbNext.Click += new System.EventHandler(this.sbNext_Click);
            // 
            // gridControl5
            // 
            this.gridControl5.Location = new System.Drawing.Point(536, 24);
            this.gridControl5.MainView = this.gridView5;
            this.gridControl5.Name = "gridControl5";
            this.gridControl5.Size = new System.Drawing.Size(424, 183);
            this.gridControl5.TabIndex = 22;
            this.gridControl5.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView5});
            // 
            // gridView5
            // 
            this.gridView5.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn31,
            this.gridColumn32});
            this.gridView5.GridControl = this.gridControl5;
            this.gridView5.Name = "gridView5";
            this.gridView5.OptionsBehavior.AllowIncrementalSearch = true;
            this.gridView5.OptionsBehavior.Editable = false;
            this.gridView5.OptionsCustomization.AllowFilter = false;
            this.gridView5.OptionsSelection.MultiSelect = true;
            this.gridView5.OptionsView.ShowGroupPanel = false;
            this.gridView5.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn31, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn31
            // 
            this.gridColumn31.Caption = "Service Type ID";
            this.gridColumn31.FieldName = "nServiceTypeID";
            this.gridColumn31.Name = "gridColumn31";
            this.gridColumn31.Visible = true;
            this.gridColumn31.VisibleIndex = 0;
            this.gridColumn31.Width = 104;
            // 
            // gridColumn32
            // 
            this.gridColumn32.Caption = "Service Type";
            this.gridColumn32.FieldName = "strDescription";
            this.gridColumn32.Name = "gridColumn32";
            this.gridColumn32.Visible = true;
            this.gridColumn32.VisibleIndex = 1;
            this.gridColumn32.Width = 282;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 44);
            this.label7.TabIndex = 23;
            this.label7.Text = "Service Type";
            // 
            // gridControl6
            // 
            this.gridControl6.Location = new System.Drawing.Point(64, 24);
            this.gridControl6.MainView = this.gridView6;
            this.gridControl6.Name = "gridControl6";
            this.gridControl6.Size = new System.Drawing.Size(424, 183);
            this.gridControl6.TabIndex = 17;
            this.gridControl6.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView6});
            // 
            // gridView6
            // 
            this.gridView6.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn37,
            this.gridColumn38});
            this.gridView6.GridControl = this.gridControl6;
            this.gridView6.Name = "gridView6";
            this.gridView6.OptionsBehavior.AllowIncrementalSearch = true;
            this.gridView6.OptionsBehavior.Editable = false;
            this.gridView6.OptionsCustomization.AllowFilter = false;
            this.gridView6.OptionsSelection.MultiSelect = true;
            this.gridView6.OptionsView.ShowGroupPanel = false;
            this.gridView6.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn37, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn37
            // 
            this.gridColumn37.Caption = "Service Type ID";
            this.gridColumn37.FieldName = "nServiceTypeID";
            this.gridColumn37.Name = "gridColumn37";
            this.gridColumn37.Visible = true;
            this.gridColumn37.VisibleIndex = 0;
            this.gridColumn37.Width = 107;
            // 
            // gridColumn38
            // 
            this.gridColumn38.Caption = "Service";
            this.gridColumn38.FieldName = "strDescription";
            this.gridColumn38.Name = "gridColumn38";
            this.gridColumn38.Visible = true;
            this.gridColumn38.VisibleIndex = 1;
            this.gridColumn38.Width = 279;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(314, 332);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 17);
            this.label4.TabIndex = 155;
            this.label4.Text = "Service Type";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // grpBranch
            // 
            this.grpBranch.Controls.Add(this.btnPacBranch_Del);
            this.grpBranch.Controls.Add(this.groupControl1);
            this.grpBranch.Controls.Add(this.btnPacBranch_DelAll);
            this.grpBranch.Controls.Add(this.btnPacBranch_AddAll);
            this.grpBranch.Controls.Add(this.btnPacBranch_Add);
            this.grpBranch.Controls.Add(this.gridPacBranch2);
            this.grpBranch.Controls.Add(this.label6);
            this.grpBranch.Controls.Add(this.gridPacBranch);
            this.grpBranch.Location = new System.Drawing.Point(8, 352);
            this.grpBranch.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.grpBranch.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grpBranch.Name = "grpBranch";
            this.grpBranch.Size = new System.Drawing.Size(984, 210);
            this.grpBranch.TabIndex = 151;
            this.grpBranch.Text = "Employee Branch";
            // 
            // btnPacBranch_Del
            // 
            this.btnPacBranch_Del.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnPacBranch_Del.Location = new System.Drawing.Point(496, 96);
            this.btnPacBranch_Del.Name = "btnPacBranch_Del";
            this.btnPacBranch_Del.Size = new System.Drawing.Size(30, 20);
            this.btnPacBranch_Del.TabIndex = 21;
            this.btnPacBranch_Del.Text = "<";
            this.btnPacBranch_Del.Click += new System.EventHandler(this.btnPacBranch_Del_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gridControl2);
            this.groupControl1.Controls.Add(this.simpleButton1);
            this.groupControl1.Controls.Add(this.simpleButton2);
            this.groupControl1.Controls.Add(this.simpleButton3);
            this.groupControl1.Controls.Add(this.simpleButton4);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.gridControl1);
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(984, 210);
            this.groupControl1.TabIndex = 154;
            this.groupControl1.Text = "Leave Entitlement";
            // 
            // gridControl2
            // 
            this.gridControl2.Location = new System.Drawing.Point(544, 22);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(424, 183);
            this.gridControl2.TabIndex = 24;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn8,
            this.gridColumn9});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.AllowIncrementalSearch = true;
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsCustomization.AllowFilter = false;
            this.gridView2.OptionsSelection.MultiSelect = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn8, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Leave";
            this.gridColumn8.FieldName = "strLeaveCode";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 0;
            this.gridColumn8.Width = 107;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Description";
            this.gridColumn9.FieldName = "strDescription";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 1;
            this.gridColumn9.Width = 279;
            // 
            // simpleButton1
            // 
            this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.simpleButton1.Location = new System.Drawing.Point(496, 96);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(30, 20);
            this.simpleButton1.TabIndex = 21;
            this.simpleButton1.Text = "<";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.simpleButton2.Location = new System.Drawing.Point(496, 72);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(30, 20);
            this.simpleButton2.TabIndex = 20;
            this.simpleButton2.Text = "<<";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton3
            // 
            this.simpleButton3.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.simpleButton3.Location = new System.Drawing.Point(496, 48);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(30, 20);
            this.simpleButton3.TabIndex = 19;
            this.simpleButton3.Text = ">>";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // simpleButton4
            // 
            this.simpleButton4.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.simpleButton4.Location = new System.Drawing.Point(496, 24);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(30, 20);
            this.simpleButton4.TabIndex = 18;
            this.simpleButton4.Text = ">";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(5, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 44);
            this.label3.TabIndex = 23;
            this.label3.Text = "Leave";
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(61, 22);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(424, 183);
            this.gridControl1.TabIndex = 17;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn10,
            this.gridColumn26});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowIncrementalSearch = true;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn10, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Leave";
            this.gridColumn10.FieldName = "strLeaveCode";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 0;
            this.gridColumn10.Width = 107;
            // 
            // gridColumn26
            // 
            this.gridColumn26.Caption = "Description";
            this.gridColumn26.FieldName = "strDescription";
            this.gridColumn26.Name = "gridColumn26";
            this.gridColumn26.Visible = true;
            this.gridColumn26.VisibleIndex = 1;
            this.gridColumn26.Width = 279;
            // 
            // btnPacBranch_DelAll
            // 
            this.btnPacBranch_DelAll.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnPacBranch_DelAll.Location = new System.Drawing.Point(496, 72);
            this.btnPacBranch_DelAll.Name = "btnPacBranch_DelAll";
            this.btnPacBranch_DelAll.Size = new System.Drawing.Size(30, 20);
            this.btnPacBranch_DelAll.TabIndex = 20;
            this.btnPacBranch_DelAll.Text = "<<";
            this.btnPacBranch_DelAll.Click += new System.EventHandler(this.btnPacBranch_DelAll_Click);
            // 
            // btnPacBranch_AddAll
            // 
            this.btnPacBranch_AddAll.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnPacBranch_AddAll.Location = new System.Drawing.Point(496, 48);
            this.btnPacBranch_AddAll.Name = "btnPacBranch_AddAll";
            this.btnPacBranch_AddAll.Size = new System.Drawing.Size(30, 20);
            this.btnPacBranch_AddAll.TabIndex = 19;
            this.btnPacBranch_AddAll.Text = ">>";
            this.btnPacBranch_AddAll.Click += new System.EventHandler(this.btnPacBranch_AddAll_Click);
            // 
            // btnPacBranch_Add
            // 
            this.btnPacBranch_Add.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnPacBranch_Add.Location = new System.Drawing.Point(496, 24);
            this.btnPacBranch_Add.Name = "btnPacBranch_Add";
            this.btnPacBranch_Add.Size = new System.Drawing.Size(30, 20);
            this.btnPacBranch_Add.TabIndex = 18;
            this.btnPacBranch_Add.Text = ">";
            this.btnPacBranch_Add.Click += new System.EventHandler(this.btnPacBranch_Add_Click);
            // 
            // gridPacBranch2
            // 
            this.gridPacBranch2.Location = new System.Drawing.Point(536, 24);
            this.gridPacBranch2.MainView = this.gvPacBranch2;
            this.gridPacBranch2.Name = "gridPacBranch2";
            this.gridPacBranch2.Size = new System.Drawing.Size(424, 183);
            this.gridPacBranch2.TabIndex = 22;
            this.gridPacBranch2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPacBranch2});
            // 
            // gvPacBranch2
            // 
            this.gvPacBranch2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn33,
            this.gridColumn34});
            this.gvPacBranch2.GridControl = this.gridPacBranch2;
            this.gvPacBranch2.Name = "gvPacBranch2";
            this.gvPacBranch2.OptionsBehavior.AllowIncrementalSearch = true;
            this.gvPacBranch2.OptionsBehavior.Editable = false;
            this.gvPacBranch2.OptionsCustomization.AllowFilter = false;
            this.gvPacBranch2.OptionsSelection.MultiSelect = true;
            this.gvPacBranch2.OptionsView.ShowGroupPanel = false;
            this.gvPacBranch2.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn33, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn33
            // 
            this.gridColumn33.Caption = "Branch";
            this.gridColumn33.FieldName = "strBranchCode";
            this.gridColumn33.Name = "gridColumn33";
            this.gridColumn33.Visible = true;
            this.gridColumn33.VisibleIndex = 0;
            this.gridColumn33.Width = 104;
            // 
            // gridColumn34
            // 
            this.gridColumn34.Caption = "Branch Name";
            this.gridColumn34.FieldName = "strBranchName";
            this.gridColumn34.Name = "gridColumn34";
            this.gridColumn34.Visible = true;
            this.gridColumn34.VisibleIndex = 1;
            this.gridColumn34.Width = 282;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 44);
            this.label6.TabIndex = 23;
            this.label6.Text = "Employe Branch";
            // 
            // gridPacBranch
            // 
            this.gridPacBranch.Location = new System.Drawing.Point(64, 24);
            this.gridPacBranch.MainView = this.gvPacBranch;
            this.gridPacBranch.Name = "gridPacBranch";
            this.gridPacBranch.Size = new System.Drawing.Size(424, 183);
            this.gridPacBranch.TabIndex = 17;
            this.gridPacBranch.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPacBranch});
            // 
            // gvPacBranch
            // 
            this.gvPacBranch.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn35,
            this.gridColumn36});
            this.gvPacBranch.GridControl = this.gridPacBranch;
            this.gvPacBranch.Name = "gvPacBranch";
            this.gvPacBranch.OptionsBehavior.AllowIncrementalSearch = true;
            this.gvPacBranch.OptionsBehavior.Editable = false;
            this.gvPacBranch.OptionsCustomization.AllowFilter = false;
            this.gvPacBranch.OptionsSelection.MultiSelect = true;
            this.gvPacBranch.OptionsView.ShowGroupPanel = false;
            this.gvPacBranch.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn35, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn35
            // 
            this.gridColumn35.Caption = "Branch";
            this.gridColumn35.FieldName = "strBranchCode";
            this.gridColumn35.Name = "gridColumn35";
            this.gridColumn35.Visible = true;
            this.gridColumn35.VisibleIndex = 0;
            this.gridColumn35.Width = 107;
            // 
            // gridColumn36
            // 
            this.gridColumn36.Caption = "Branch Name";
            this.gridColumn36.FieldName = "strBranchName";
            this.gridColumn36.Name = "gridColumn36";
            this.gridColumn36.Visible = true;
            this.gridColumn36.VisibleIndex = 1;
            this.gridColumn36.Width = 279;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(163, 332);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 17);
            this.label2.TabIndex = 153;
            this.label2.Text = "Employee Branch";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(7, 332);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 17);
            this.label1.TabIndex = 152;
            this.label1.Text = "Leave Entitlement";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Searchpanel
            // 
            this.Searchpanel.Controls.Add(this.btn_Search);
            this.Searchpanel.Controls.Add(this.txtSearch);
            this.Searchpanel.Location = new System.Drawing.Point(512, 24);
            this.Searchpanel.Name = "Searchpanel";
            this.Searchpanel.Size = new System.Drawing.Size(464, 24);
            this.Searchpanel.TabIndex = 150;
            // 
            // btn_Search
            // 
            this.btn_Search.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_Search.Appearance.Options.UseFont = true;
            this.btn_Search.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btn_Search.Location = new System.Drawing.Point(392, 0);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(56, 20);
            this.btn_Search.TabIndex = 137;
            this.btn_Search.Text = "Search";
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.EditValue = "";
            this.txtSearch.Location = new System.Drawing.Point(232, 0);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Properties.Appearance.Options.UseFont = true;
            this.txtSearch.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtSearch.Size = new System.Drawing.Size(152, 20);
            this.txtSearch.TabIndex = 136;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // gridControlMd_Employee
            // 
            this.gridControlMd_Employee.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.gridControlMd_Employee.Location = new System.Drawing.Point(8, 48);
            this.gridControlMd_Employee.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControlMd_Employee.MainView = this.gridViewMd_Employee;
            this.gridControlMd_Employee.Name = "gridControlMd_Employee";
            this.gridControlMd_Employee.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lk_JobPosition,
            this.lk_BranchCode,
            this.EmpStartDate,
            this.lk_RightsLevel,
            this.lk_InstructorType,
            this.chkPartTime,
            this.cmbStatus,
            this.lk_Department,
            this.chk_Probation,
            this.chk_MaternityLeave,
            this.chk_ChildCareLeave,
            this.chk_RegisterFee,
            this.chk_PTInstructor,
            this.chk_SalesPerson,
            this.chk_ServiceComm,
            this.lk_MemoGroup,
            this.lk_Instructor,
            this.lk_ServiceComm,
            this.cmbServiceCom,
            this.repositoryItemTextEdit1,
            this.chk_StatusID,
            this.EditCessation});
            this.gridControlMd_Employee.Size = new System.Drawing.Size(984, 281);
            this.gridControlMd_Employee.TabIndex = 133;
            this.gridControlMd_Employee.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMd_Employee});
            // 
            // gridViewMd_Employee
            // 
            this.gridViewMd_Employee.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnEmp1,
            this.gridColumnEmp2,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.nLeaveGroup,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn18,
            this.gridColumn19,
            this.gridColumn20,
            this.gridColumn21,
            this.gridColumn22,
            this.gridColumn23,
            this.gridColumn24,
            this.gridColumn25,
            this.gridColumn6,
            this.gridColumn7});
            this.gridViewMd_Employee.GridControl = this.gridControlMd_Employee;
            this.gridViewMd_Employee.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridViewMd_Employee.Name = "gridViewMd_Employee";
            this.gridViewMd_Employee.OptionsView.ColumnAutoWidth = false;
            this.gridViewMd_Employee.OptionsView.ShowGroupPanel = false;
            this.gridViewMd_Employee.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridViewMd_Employee.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.SalesComm_Init);
            this.gridViewMd_Employee.LostFocus += new System.EventHandler(this.gridViewMd_Employee_LostFocus);
            // 
            // gridColumnEmp1
            // 
            this.gridColumnEmp1.Caption = "Emp ID";
            this.gridColumnEmp1.FieldName = "nEmployeeID";
            this.gridColumnEmp1.Name = "gridColumnEmp1";
            this.gridColumnEmp1.Visible = true;
            this.gridColumnEmp1.VisibleIndex = 0;
            this.gridColumnEmp1.Width = 43;
            // 
            // gridColumnEmp2
            // 
            this.gridColumnEmp2.Caption = "Name";
            this.gridColumnEmp2.FieldName = "strEmployeeName";
            this.gridColumnEmp2.Name = "gridColumnEmp2";
            this.gridColumnEmp2.Visible = true;
            this.gridColumnEmp2.VisibleIndex = 1;
            this.gridColumnEmp2.Width = 104;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Password";
            this.gridColumn1.ColumnEdit = this.repositoryItemTextEdit1;
            this.gridColumn1.FieldName = "strPassword";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            this.repositoryItemTextEdit1.PasswordChar = '*';
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Job Position";
            this.gridColumn2.ColumnEdit = this.lk_JobPosition;
            this.gridColumn2.FieldName = "strJobPositionCode";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 3;
            // 
            // lk_JobPosition
            // 
            this.lk_JobPosition.AutoHeight = false;
            this.lk_JobPosition.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lk_JobPosition.Name = "lk_JobPosition";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Branch";
            this.gridColumn3.ColumnEdit = this.lk_BranchCode;
            this.gridColumn3.FieldName = "strBranchCode";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            this.gridColumn3.Width = 51;
            // 
            // lk_BranchCode
            // 
            this.lk_BranchCode.AutoHeight = false;
            this.lk_BranchCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lk_BranchCode.Name = "lk_BranchCode";
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Start Date";
            this.gridColumn4.ColumnEdit = this.EmpStartDate;
            this.gridColumn4.FieldName = "dtEmployeeStartDate";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 5;
            // 
            // EmpStartDate
            // 
            this.EmpStartDate.AutoHeight = false;
            this.EmpStartDate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.EmpStartDate.Name = "EmpStartDate";
            this.EmpStartDate.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Rights Lvl";
            this.gridColumn5.ColumnEdit = this.lk_RightsLevel;
            this.gridColumn5.FieldName = "nRightsLevelID";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 7;
            this.gridColumn5.Width = 67;
            // 
            // lk_RightsLevel
            // 
            this.lk_RightsLevel.AutoHeight = false;
            this.lk_RightsLevel.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lk_RightsLevel.Name = "lk_RightsLevel";
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Instructor Type";
            this.gridColumn11.ColumnEdit = this.lk_InstructorType;
            this.gridColumn11.FieldName = "nInstructorTypeID";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 8;
            this.gridColumn11.Width = 85;
            // 
            // lk_InstructorType
            // 
            this.lk_InstructorType.AutoHeight = false;
            this.lk_InstructorType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lk_InstructorType.Name = "lk_InstructorType";
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Service Comm Level";
            this.gridColumn12.ColumnEdit = this.cmbServiceCom;
            this.gridColumn12.FieldName = "nServiceCommLevel";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 9;
            this.gridColumn12.Width = 105;
            // 
            // cmbServiceCom
            // 
            this.cmbServiceCom.AutoHeight = false;
            this.cmbServiceCom.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbServiceCom.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Level 1", 1, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Level 2", 2, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Level 3", 3, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Level 4", 4, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Level 5", 5, -1)});
            this.cmbServiceCom.Name = "cmbServiceCom";
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Contact No";
            this.gridColumn13.FieldName = "strContactNo";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 10;
            this.gridColumn13.Width = 78;
            // 
            // nLeaveGroup
            // 
            this.nLeaveGroup.Caption = "Leave Grp";
            this.nLeaveGroup.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.nLeaveGroup.FieldName = "nLeaveGroup";
            this.nLeaveGroup.Name = "nLeaveGroup";
            this.nLeaveGroup.Visible = true;
            this.nLeaveGroup.VisibleIndex = 11;
            this.nLeaveGroup.Width = 61;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Part Time";
            this.gridColumn14.ColumnEdit = this.chkPartTime;
            this.gridColumn14.FieldName = "fPartTime";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 12;
            this.gridColumn14.Width = 54;
            // 
            // chkPartTime
            // 
            this.chkPartTime.AutoHeight = false;
            this.chkPartTime.Name = "chkPartTime";
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Status";
            this.gridColumn15.ColumnEdit = this.chk_StatusID;
            this.gridColumn15.FieldName = "nStatusID";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 13;
            this.gridColumn15.Width = 46;
            // 
            // chk_StatusID
            // 
            this.chk_StatusID.AutoHeight = false;
            this.chk_StatusID.Name = "chk_StatusID";
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Department";
            this.gridColumn16.ColumnEdit = this.lk_Department;
            this.gridColumn16.FieldName = "nDepartmentID";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 14;
            this.gridColumn16.Width = 71;
            // 
            // lk_Department
            // 
            this.lk_Department.AutoHeight = false;
            this.lk_Department.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lk_Department.Name = "lk_Department";
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "Probation";
            this.gridColumn17.ColumnEdit = this.chk_Probation;
            this.gridColumn17.FieldName = "fProbation";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 15;
            this.gridColumn17.Width = 55;
            // 
            // chk_Probation
            // 
            this.chk_Probation.AutoHeight = false;
            this.chk_Probation.Name = "chk_Probation";
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "Maternity";
            this.gridColumn18.ColumnEdit = this.chk_MaternityLeave;
            this.gridColumn18.FieldName = "fMaternityLeave";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 16;
            this.gridColumn18.Width = 55;
            // 
            // chk_MaternityLeave
            // 
            this.chk_MaternityLeave.AutoHeight = false;
            this.chk_MaternityLeave.Name = "chk_MaternityLeave";
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "Child Care";
            this.gridColumn19.ColumnEdit = this.chk_ChildCareLeave;
            this.gridColumn19.FieldName = "fChildcareLeave";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 17;
            this.gridColumn19.Width = 58;
            // 
            // chk_ChildCareLeave
            // 
            this.chk_ChildCareLeave.AutoHeight = false;
            this.chk_ChildCareLeave.Name = "chk_ChildCareLeave";
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "Reg Fee";
            this.gridColumn20.ColumnEdit = this.chk_RegisterFee;
            this.gridColumn20.FieldName = "fRegistrationFee";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 18;
            this.gridColumn20.Width = 55;
            // 
            // chk_RegisterFee
            // 
            this.chk_RegisterFee.AutoHeight = false;
            this.chk_RegisterFee.Name = "chk_RegisterFee";
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "PT Instructor";
            this.gridColumn21.ColumnEdit = this.chk_PTInstructor;
            this.gridColumn21.FieldName = "fPtInstructor";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 19;
            this.gridColumn21.Width = 72;
            // 
            // chk_PTInstructor
            // 
            this.chk_PTInstructor.AutoHeight = false;
            this.chk_PTInstructor.Name = "chk_PTInstructor";
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "Sales Person";
            this.gridColumn22.ColumnEdit = this.chk_SalesPerson;
            this.gridColumn22.FieldName = "fSalesPerson";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 20;
            this.gridColumn22.Width = 70;
            // 
            // chk_SalesPerson
            // 
            this.chk_SalesPerson.AutoHeight = false;
            this.chk_SalesPerson.Name = "chk_SalesPerson";
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "Svs Comm";
            this.gridColumn23.ColumnEdit = this.chk_ServiceComm;
            this.gridColumn23.FieldName = "fServiceCommission";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.Visible = true;
            this.gridColumn23.VisibleIndex = 21;
            this.gridColumn23.Width = 58;
            // 
            // chk_ServiceComm
            // 
            this.chk_ServiceComm.AutoHeight = false;
            this.chk_ServiceComm.Name = "chk_ServiceComm";
            // 
            // gridColumn24
            // 
            this.gridColumn24.Caption = "Instructor";
            this.gridColumn24.ColumnEdit = this.lk_Instructor;
            this.gridColumn24.FieldName = "fInstructor";
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.Visible = true;
            this.gridColumn24.VisibleIndex = 22;
            this.gridColumn24.Width = 57;
            // 
            // lk_Instructor
            // 
            this.lk_Instructor.AutoHeight = false;
            this.lk_Instructor.Name = "lk_Instructor";
            // 
            // gridColumn25
            // 
            this.gridColumn25.Caption = "Memo Grp";
            this.gridColumn25.ColumnEdit = this.lk_MemoGroup;
            this.gridColumn25.FieldName = "fMemoGroup";
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.Visible = true;
            this.gridColumn25.VisibleIndex = 23;
            this.gridColumn25.Width = 57;
            // 
            // lk_MemoGroup
            // 
            this.lk_MemoGroup.AutoHeight = false;
            this.lk_MemoGroup.Name = "lk_MemoGroup";
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Remarks";
            this.gridColumn6.FieldName = "strRemark";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 24;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Cessation Date";
            this.gridColumn7.ColumnEdit = this.EditCessation;
            this.gridColumn7.FieldName = "dtCessation";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            this.gridColumn7.Width = 88;
            // 
            // EditCessation
            // 
            this.EditCessation.AutoHeight = false;
            this.EditCessation.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.EditCessation.Name = "EditCessation";
            this.EditCessation.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // cmbStatus
            // 
            this.cmbStatus.AutoHeight = false;
            this.cmbStatus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbStatus.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Active", 0, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Deleted", 1, -1)});
            this.cmbStatus.Name = "cmbStatus";
            // 
            // lk_ServiceComm
            // 
            this.lk_ServiceComm.AutoHeight = false;
            this.lk_ServiceComm.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lk_ServiceComm.Name = "lk_ServiceComm";
            // 
            // btn_Add
            // 
            this.btn_Add.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Add.Appearance.Options.UseFont = true;
            this.btn_Add.Appearance.Options.UseTextOptions = true;
            this.btn_Add.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btn_Add.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.btn_Add.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btn_Add.ImageIndex = 0;
            this.btn_Add.ImageList = this.imageList1;
            this.btn_Add.ImeMode = System.Windows.Forms.ImeMode.On;
            this.btn_Add.Location = new System.Drawing.Point(8, 24);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(38, 16);
            this.btn_Add.TabIndex = 132;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            // 
            // btn_Del
            // 
            this.btn_Del.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Del.Appearance.Options.UseFont = true;
            this.btn_Del.Appearance.Options.UseTextOptions = true;
            this.btn_Del.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btn_Del.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.btn_Del.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btn_Del.ImageIndex = 1;
            this.btn_Del.ImageList = this.imageList1;
            this.btn_Del.Location = new System.Drawing.Point(48, 24);
            this.btn_Del.Name = "btn_Del";
            this.btn_Del.Size = new System.Drawing.Size(38, 16);
            this.btn_Del.TabIndex = 131;
            this.btn_Del.Click += new System.EventHandler(this.btn_Del_Click);
            // 
            // frmEmployee
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1036, 560);
            this.Controls.Add(this.grpMDEmployeeTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmEmployee";
            this.Text = "frmEmployee";
            this.Load += new System.EventHandler(this.frmEmployee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpMDEmployeeTop)).EndInit();
            this.grpMDEmployeeTop.ResumeLayout(false);
            this.grpMDEmployeeTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcServiceType)).EndInit();
            this.gcServiceType.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpBranch)).EndInit();
            this.grpBranch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPacBranch2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPacBranch2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPacBranch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPacBranch)).EndInit();
            this.Searchpanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMd_Employee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMd_Employee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_JobPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_BranchCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpStartDate.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpStartDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_RightsLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_InstructorType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbServiceCom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPartTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_StatusID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_Department)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_Probation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_MaternityLeave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_ChildCareLeave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_RegisterFee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_PTInstructor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_SalesPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_ServiceComm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_Instructor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_MemoGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditCessation.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditCessation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_ServiceComm)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region logic

		private void mdEmployeeInit()
		{
			string strSQL;
			DataSet _ds = new DataSet();
			DataTable dt;

			strSQL = "select * from tblJobPosition";
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dt = _ds.Tables["table"];

			DevExpress.XtraEditors.Controls.LookUpColumnInfo[] col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
			
			col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strJobPositionCode","Job Code",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription","Description",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
		
			new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(this.lk_JobPosition,dt,col,"strDescription","strJobPositionCode","Job Position");

            strSQL = "select * from tblRightsLevel";
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dt = _ds.Tables["table"];
			col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
			
			col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nRightsLevelID","Rights Level ID",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription","Description",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
		
			new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(this.lk_RightsLevel,dt,col,"strDescription","nRightsLevelID","Rights Level");


			strSQL = "select * from tblBranch";
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dt = _ds.Tables["table"];

			new ManagerBranchCodeLookupEditBuilder(dt,this.lk_BranchCode);
			
			strSQL = "select * from tblInstructorType";
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dt = _ds.Tables["table"];
            col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
            col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nInstructorTypeID", "Instructor ID", 15, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None);
            col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription", "Description", 15, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None);


            new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(this.lk_InstructorType, dt, col, "strDescription", "nInstructorTypeID", "Instructor Type");


			strSQL = "select * from tblDepartment";
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dt = _ds.Tables["table"];
            col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
            col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nDepartmentID", "Department ID", 15, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None);
            col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription", "Description", 15, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None);

            new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(this.lk_Department, dt, col, "strDescription", "nDepartmentID", "Department");


			strSQL = "select * from tblService";
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dt = _ds.Tables["table"];
			col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
			
			col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strServiceCode","Service Code",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription","Description",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
		
			new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(this.lk_ServiceComm,dt,col,"strDescription","strServiceCode","Service Code");
	
			BindEmployee();
		}

		private void BindEmployee()
		{
			//mdEmp_cbServiceCommLevel
			string strSQL = "select * from tblEmployee where nEmployeeID like '%" + txtSearch.Text + "%' or  strEmployeeName like '%" + txtSearch.Text +"%'";
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dtEmployee = _ds.Tables["table"];
			this.gridControlMd_Employee.DataSource = dtEmployee;

		}
        
        private DataTable dtServiceType;
        private void BindEmployeeServiceType()
        {
            DataSet _ds, _ds2;
            DataRow dr = this.gridViewMd_Employee.GetDataRow(this.gridViewMd_Employee.FocusedRowHandle);

            if (dr == null)
                return;

            string strSQL;
            strSQL = "select nServiceTypeID, strDescription from tblServiceType Where nServiceTypeID Not In (Select nServiceTypeID From tblEmployeeServiceType Where nEmployeeNo = '" + dr["nEmployeeID"].ToString() + "')";
            _ds = new DataSet();
            SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA", _ds, new string[] { "table" }, new SqlParameter("@strSQL", strSQL));
            this.gridControl6.DataSource = _ds.Tables["table"];

            strSQL = "select nEmployeeServiceTypeID, nEmployeeNo, st.nServiceTypeID, st.strDescription from tblEmployeeServiceType est Join tblServiceType  st On est.nServiceTypeID = st.nServiceTypeID Where est.nEmployeeNo = '" + dr["nEmployeeID"].ToString() + "'";
            _ds2 = new DataSet();
            
            SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA", _ds2, new string[] { "table" }, new SqlParameter("@strSQL", strSQL));
            gridControl5.DataSource = _ds2.Tables["table"];
            dtServiceType = _ds2.Tables["table"];

        }

        private DataTable dtPacBranch;
        private void BindEmployeeBranch()
        {
            DataSet _ds, _ds2;
            DataRow dr = this.gridViewMd_Employee.GetDataRow(this.gridViewMd_Employee.FocusedRowHandle);

            if (dr == null)
                return;

            string strSQL;
            strSQL = "select strBranchCode, strBranchName from TblBranch Where nBrStatusID = 1 and strBranchCode Not In (Select strBranchCode From tblEmployeeBranchRights Where nEmployeeID = '" + dr["nEmployeeID"].ToString() + "')";
            _ds = new DataSet();
            SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA", _ds, new string[] { "table" }, new SqlParameter("@strSQL", strSQL));
            this.gridPacBranch.DataSource = _ds.Tables["table"];

            strSQL = "select E.nEmployeeID, B.strBranchCode, strBranchName from tblEmployeeBranchRights E Inner Join tblBranch  B On E.strBranchCode = B.strBranchCode Where E.nEmployeeID = '" + dr["nEmployeeID"].ToString() + "'";
            _ds2 = new DataSet();
            
            SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA", _ds2, new string[] { "table" }, new SqlParameter("@strSQL", strSQL));         
            gridPacBranch2.DataSource = _ds2.Tables["table"];
            dtPacBranch = _ds2.Tables["table"];

        }

        private DataTable dtEmployeeLeave;
        private void BindEmployeeLeave()
        {
            DataSet _ds, _ds2;
            DataRow dr = this.gridViewMd_Employee.GetDataRow(this.gridViewMd_Employee.FocusedRowHandle);

            if (dr == null)
                return;

            string strSQL;
            strSQL = "select strLeaveCode, strDescription from tblLeaveType where strLeaveCode Not In (Select strLeaveCode From tblLeaveEntitlement Where nEmployeeID = '" + dr["nEmployeeID"].ToString() + "')";
            _ds = new DataSet();
            SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA", _ds, new string[] { "table" }, new SqlParameter("@strSQL", strSQL));
            this.gridControl1.DataSource = _ds.Tables["table"];

            strSQL = "select E.nEmployeeID,E.strLeaveCode,T.strDescription from tblLeaveEntitlement E Inner Join tblLeaveType  T On E.strLeaveCode = T.strLeaveCode Where E.nEmployeeID = '" + dr["nEmployeeID"].ToString() + "'";
            _ds2 = new DataSet();

            SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA", _ds2, new string[] { "table" }, new SqlParameter("@strSQL", strSQL));
            this.gridControl2.DataSource = _ds2.Tables["table"];
            dtEmployeeLeave = _ds2.Tables["table"];

        }

		#endregion

		#region common
		private string ConvertToDateTime(object target)
		{
			if (target.ToString() == "" )
				return null;
			else
				return Convert.ToDateTime(target).ToString();
		}

		private int ConvertToInt(object target)
		{
			if (target.ToString() == "" )
				return 0;
			else
				return Convert.ToInt32(target);
		}

		private decimal ConvertToDecimal(object target)
		{
			if (target.ToString() == "" )
				return 0;
			else
				return Convert.ToDecimal(target);
		}
		
		public void CreateCmdsAndUpdate(string mySelectQuery,DataTable myTableName) 
		{
			SqlConnection myConn = new SqlConnection(connectionString);
			SqlDataAdapter myDataAdapter = new SqlDataAdapter();
			myDataAdapter.SelectCommand=new SqlCommand(mySelectQuery, myConn);
			SqlCommandBuilder custCB = new SqlCommandBuilder(myDataAdapter);

			myConn.Open();
			DataSet custDS = new DataSet();
			myDataAdapter.Fill(custDS);

			//code to modify data in dataset here
			myDataAdapter.Update(myTableName);
			myConn.Close();
		}
		private void comboBind(DevExpress.XtraEditors.ImageComboBoxEdit control,string strSQL,string display,string strValue)
		{
		
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox properties = control.Properties;
			properties.Items.BeginUpdate();
			properties.Items.Clear();

			try 
			{
				foreach(DataRow dr in _ds.Tables["Table"].Rows)
				{
					//Initialize each item with the display text, value and image index
					properties.Items.Add( new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr[display].ToString(), dr[strValue].ToString(),-1));
				}
			}
			finally 
			{
				properties.Items.EndUpdate();
			}
			//Select the first item
			control.SelectedIndex = 0;
		}

		private void comboBind(DevExpress.XtraEditors.ImageComboBoxEdit control,string strSQL,string display,string strValue,bool fNum)
		{
		
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox properties = control.Properties;
			properties.Items.BeginUpdate();
			properties.Items.Clear();

			try 
			{
				foreach(DataRow dr in _ds.Tables["Table"].Rows)
				{
					//Initialize each item with the display text, value and image index
					properties.Items.Add( new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr[display].ToString(), dr[strValue],-1));
				}
			}
			finally 
			{
				properties.Items.EndUpdate();
			}
			//Select the first item
			control.SelectedIndex = 0;
		}
		

		#endregion

		private void frmEmployee_Load(object sender, System.EventArgs e)
		{
			lk_CommGroupID_Init();
			mdEmployeeInit();
		
		}
		private bool AddNew = false;
		private int EmployeeLastNo;
		private void btn_Add_Click(object sender, System.EventArgs e)
		{
			DataSet _ds = new DataSet();
			DataTable dt;

			string strSQL = "select isnull(employeeIdLastNo,0) + 1 as employeeIdLastNo from tblcompany";
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dt = _ds.Tables["table"];

			AddNew = true;
			DataRow dr = dtEmployee.NewRow();
			EmployeeLastNo = Convert.ToInt16(dt.Rows[0][0]);
			dr["nEmployeeID"] = dt.Rows[0][0];
			dr["strPassword"] = dt.Rows[0][0];
            dr["strRemark"] = "Modified by:" + strEditEmployee;
			dtEmployee.Rows.Add(dr);
			this.gridControlMd_Employee.Refresh();
			this.gridViewMd_Employee.FocusedRowHandle = dtEmployee.Rows.Count - 1;
		}

		private void btn_Del_Click(object sender, System.EventArgs e)
		{
			DataRow row = this.gridViewMd_Employee.GetDataRow(gridViewMd_Employee.FocusedRowHandle);
			if (row != null)
			{

				if (AddNew)
				{
					AddNew = false;
					gridViewMd_Employee.DeleteRow(gridViewMd_Employee.FocusedRowHandle);
				}
				else
				{

					DialogResult result = MessageBox.Show(this, "Do you really want to delete record with Employee Id = " + row["nEmployeeID"].ToString(),
						"Delete?", MessageBoxButtons.YesNo);
					if (result == DialogResult.Yes)
					{
						try
						{
							SqlHelper.ExecuteNonQuery(connection,"del_Employee",
								new SqlParameter("@nEmployeeID",row["nEmployeeID"].ToString() )
								);
						}
						catch(Exception ex)
						{
							MessageBox.Show(ex.Message ,"Delete Process Failed");
							return;
						}
						MessageBox.Show("Record Deleted Successfully","Message");
						BindEmployee();
					}
				}
				
			}
		}

		private bool FieldChecking(DataRow dr)
		{
			if ( dr["nEmployeeID"].ToString() == "" )
				return false;	

			if ( dr["strJobPositionCode"].ToString() == "" )
				return false;	

			if ( dr["strBranchCode"].ToString() == "" )
				return false;	

			if ( dr["nRightsLevelID"].ToString() == "" )
				return false;	
		
			return true;
		}

		private void gridViewMd_Employee_LostFocus(object sender, System.EventArgs e)
		{
			DataRow row = this.gridViewMd_Employee.GetDataRow(gridViewMd_Employee.FocusedRowHandle);
			
			string strSQL = "Select * from tblEmployee";
			if (AddNew)
			{
				if( FieldChecking(row))
				{
					this.gridControlMd_Employee.MainView.UpdateCurrentRow();
					try
					{
						CreateCmdsAndUpdate(strSQL,dtEmployee);

						string upd = "Update TblCompany Set " +
							 "employeeIdLastNo = " + EmployeeLastNo;
													
						SqlHelper.ExecuteNonQuery(connection,System.Data.CommandType.Text,upd);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message ,"Insert Failed");
						return;
					}
					AddNew = false;
				}
			}
			else
			{
                this.gridViewMd_Employee.GetDataRow(gridViewMd_Employee.FocusedRowHandle)["strRemark"] = "Modified by" + strEditEmployee;
				gridViewMd_Employee.CloseEditor();
				gridViewMd_Employee.UpdateCurrentRow();

				CreateCmdsAndUpdate(strSQL,dtEmployee);
			}
		}

		private void btn_Search_Click(object sender, System.EventArgs e)
		{
			BindEmployee();
			gridViewMd_Employee.GetDataRow(gridViewMd_Employee.FocusedRowHandle);
			load_SalesComm();	
		}

		private void txtSearch_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btn_Search_Click(sender,e);
			}
		}

		private DataTable dtSaleComm;

		private void load_SalesComm()
		{
            BindEmployeeBranch();
            BindEmployeeServiceType();
            BindEmployeeLeave();
            BindEmployeeServiceType();
		}

		private void SalesComm_Init(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
			load_SalesComm();
		}

		private void lk_CommGroupID_Init()
		{
            //DataSet _ds = new DataSet();
            //string strSQL;
			
            //strSQL = "select distinct(nCommGroupID), strGroupName from tblCommGroup";
            //SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
            //DataTable dt = _ds.Tables["table"];
						
            //DevExpress.XtraEditors.Controls.LookUpColumnInfo[] col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
						
            //col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nCommGroupID","Style ID",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
            //col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strGroupName","Description",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
					
            //new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(lk_CommGroupID,dt,col,"strGroupName","nCommGroupID","Commission Type");
		}


		private bool CheckClassTypeField(DataRow dr)
		{
			for (int a =0; a< dr.Table.Columns.Count; a++)
			{
				if (dr[a].ToString() == "")
					return false;
			}
			return true;
		}


        private void btnPacBranch_Add_Click(object sender, EventArgs e)
        {
            DataRow dr = this.gridViewMd_Employee.GetDataRow(this.gridViewMd_Employee.FocusedRowHandle);

            int[] rowsHandle = this.gvPacBranch.GetSelectedRows();
            if (rowsHandle == null || rowsHandle.Length == 0)
            {
                UI.ShowErrorMessage(this, "Please select at least one row.");
                return;
            }

            foreach (int index in rowsHandle)
            {
                DataRow rCopy = gvPacBranch.GetDataRow(index);
                DataRow rNew = dtPacBranch.NewRow();
                rNew.BeginEdit();
                rNew["nEmployeeID"] = dr["nEmployeeID"];
                rNew["strBranchCode"] = rCopy["strBranchCode"];
                rNew["strBranchName"] = rCopy["strBranchName"];
                rNew.EndEdit();
                dtPacBranch.Rows.Add(rNew);
            }

            gvPacBranch.DeleteSelectedRows();

            try
            {
                string strSQL = "select nEmployeeID, strBranchCode from tblEmployeeBranchRights Where nEmployeeID = '" + dr["nEmployeeID"].ToString() + "'";
                CreateCmdsAndUpdate(strSQL, dtPacBranch);
            }
            catch (Exception)
            {
                return;
            }
        }

        private void btnPacBranch_AddAll_Click(object sender, EventArgs e)
        {
            gvPacBranch.BeginDataUpdate();
            gvPacBranch2.BeginDataUpdate();

            DataRow dr = this.gridViewMd_Employee.GetDataRow(this.gridViewMd_Employee.FocusedRowHandle);
            DataTable dtTemp = (gvPacBranch.DataSource as DataView).Table;
            //dtTemp.RejectChanges();
            dtTemp.AcceptChanges();

            for (int i = dtTemp.Rows.Count - 1; i >= 0; i--)
            {
                DataRow rCopy = gvPacBranch.GetDataRow(i);
                DataRow rNew = dtPacBranch.NewRow();
                rNew.BeginEdit();
                rNew["nEmployeeID"] = dr["nEmployeeID"];
                rNew["strBranchCode"] = rCopy["strBranchCode"];
                rNew["strBranchName"] = rCopy["strBranchName"];
                rNew.EndEdit();
                dtPacBranch.Rows.Add(rNew);
            }

            for (int i = dtTemp.Rows.Count - 1; i >= 0; i--)
            {
                if (dtTemp.Rows[i].RowState != DataRowState.Deleted)
                    dtTemp.Rows[i].Delete();
            }

            gvPacBranch.EndDataUpdate();
            gvPacBranch2.EndDataUpdate();

            string strSQL = "select nEmployeeID, strBranchCode from tblEmployeeBranchRights Where nEmployeeID = '" + dr["nEmployeeID"].ToString() + "'";
            CreateCmdsAndUpdate(strSQL, dtPacBranch);
        }

        private void btnPacBranch_DelAll_Click(object sender, EventArgs e)
        {
            DataRow dr = this.gridViewMd_Employee.GetDataRow(this.gridViewMd_Employee.FocusedRowHandle);

            gvPacBranch.BeginDataUpdate();
            gvPacBranch2.BeginDataUpdate();
            DataTable dtTemp = (gvPacBranch.DataSource as DataView).Table;

            for (int i = dtPacBranch.Rows.Count - 1; i >= 0; i--)
            {
                DataRow rCopy = gvPacBranch2.GetDataRow(i);
                DataRow rNew = dtTemp.NewRow();
                rNew.BeginEdit();
                rNew["strBranchCode"] = rCopy["strBranchCode"];
                rNew["strBranchName"] = rCopy["strBranchName"];
                rNew.EndEdit();
                dtTemp.Rows.Add(rNew);
            }

            for (int i = dtPacBranch.Rows.Count - 1; i >= 0; i--)
            {
                if (dtPacBranch.Rows[i].RowState != DataRowState.Deleted)
                    dtPacBranch.Rows[i].Delete();
            }

            gvPacBranch2.EndDataUpdate();
            gvPacBranch.EndDataUpdate();

            string strSQL = "select nEmployeeID, strBranchCode from tblEmployeeBranchRights Where nEmployeeID = '" + dr["nEmployeeID"].ToString() + "'";
            CreateCmdsAndUpdate(strSQL, dtPacBranch);

        }

        private void btnPacBranch_Del_Click(object sender, EventArgs e)
        {
            DataRow dr = this.gridViewMd_Employee.GetDataRow(this.gridViewMd_Employee.FocusedRowHandle);

            int[] rowsHandle = gvPacBranch2.GetSelectedRows();
            if (rowsHandle == null || rowsHandle.Length == 0)
            {
                UI.ShowErrorMessage(this, "Please select at least one row.");
                return;
            }
            DataTable dtTemp = (gvPacBranch.DataSource as DataView).Table;
            foreach (int index in rowsHandle)
            {
                DataRow rCopy = gvPacBranch2.GetDataRow(index);
                DataRow rNew = dtTemp.NewRow();
                rNew.BeginEdit();
                rNew["strBranchCode"] = rCopy["strBranchCode"];
                rNew["strBranchName"] = rCopy["strBranchName"];
                rNew.EndEdit();
                dtTemp.Rows.Add(rNew);
            }
            gvPacBranch2.DeleteSelectedRows();

            try
            {
                string strSQL = "select nEmployeeID, strBranchCode from tblEmployeeBranchRights Where nEmployeeID = '" + dr["nEmployeeID"].ToString() + "'";
                CreateCmdsAndUpdate(strSQL, dtPacBranch);
            }
            catch (Exception)
            {
                return;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            grpBranch.Visible = false;
            groupControl1.Visible = true;
            gcServiceType.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            grpBranch.Visible = true;
            groupControl1.Visible = false;
            gcServiceType.Visible = false;
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            DataRow dr = this.gridViewMd_Employee.GetDataRow(this.gridViewMd_Employee.FocusedRowHandle);

            int[] rowsHandle = this.gridView1.GetSelectedRows();
            if (rowsHandle == null || rowsHandle.Length == 0)
            {
                UI.ShowErrorMessage(this, "Please select at least one row.");
                return;
            }

            foreach (int index in rowsHandle)
            {
                DataRow rCopy = gridView1.GetDataRow(index);
                DataRow rNew = dtEmployeeLeave.NewRow();
                rNew.BeginEdit();
                rNew["nEmployeeID"] = dr["nEmployeeID"];
                rNew["strLeaveCode"] = rCopy["strLeaveCode"];
                rNew["strDescription"] = rCopy["strDescription"];
                rNew.EndEdit();
                dtEmployeeLeave.Rows.Add(rNew);
            }

            gridView1.DeleteSelectedRows();

            try
            {
                string strSQL = "select nEmployeeID, strLeaveCode,'' from tblLeaveEntitlement Where nEmployeeID = '" + dr["nEmployeeID"].ToString() + "'";
                CreateCmdsAndUpdate(strSQL, dtEmployeeLeave);
            }
            catch (Exception)
            {
                return;
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            gridView1.BeginDataUpdate();
            gridView2.BeginDataUpdate();

            DataRow dr = this.gridViewMd_Employee.GetDataRow(this.gridViewMd_Employee.FocusedRowHandle);
            DataTable dtTemp = (gridView1.DataSource as DataView).Table;
            //dtTemp.RejectChanges();
            dtTemp.AcceptChanges();

            for (int i = dtTemp.Rows.Count - 1; i >= 0; i--)
            {
                DataRow rCopy = gridView1.GetDataRow(i);
                DataRow rNew = dtEmployeeLeave.NewRow();
                rNew.BeginEdit();
                rNew["nEmployeeID"] = dr["nEmployeeID"];
                rNew["strLeaveCode"] = rCopy["strLeaveCode"];
                rNew["strDescription"] = rCopy["strDescription"];
                rNew.EndEdit();
                dtEmployeeLeave.Rows.Add(rNew);
            }

            for (int i = dtTemp.Rows.Count - 1; i >= 0; i--)
            {
                if (dtTemp.Rows[i].RowState != DataRowState.Deleted)
                    dtTemp.Rows[i].Delete();
            }

            gridView1.EndDataUpdate();
            gridView2.EndDataUpdate();

            string strSQL = "select nEmployeeID, strLeaveCode,'' from tblLeaveEntitlement Where nEmployeeID = '" + dr["nEmployeeID"].ToString() + "'";
            CreateCmdsAndUpdate(strSQL, dtEmployeeLeave);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            DataRow dr = this.gridViewMd_Employee.GetDataRow(this.gridViewMd_Employee.FocusedRowHandle);

            gridView1.BeginDataUpdate();
            gridView2.BeginDataUpdate();
            DataTable dtTemp = (gridView1.DataSource as DataView).Table;

            for (int i = dtEmployeeLeave.Rows.Count - 1; i >= 0; i--)
            {
                DataRow rCopy = gridView2.GetDataRow(i);
                DataRow rNew = dtTemp.NewRow();
                rNew.BeginEdit();
                rNew["strLeaveCode"] = rCopy["strLeaveCode"];
                rNew["strDescription"] = rCopy["strDescription"];
                rNew.EndEdit();
                dtTemp.Rows.Add(rNew);
            }

            for (int i = dtEmployeeLeave.Rows.Count - 1; i >= 0; i--)
            {
                if (dtEmployeeLeave.Rows[i].RowState != DataRowState.Deleted)
                    dtEmployeeLeave.Rows[i].Delete();
            }

            gridView1.EndDataUpdate();
            gridView2.EndDataUpdate();

            string strSQL = "select nEmployeeID, strLeaveCode,'' from tblLeaveEntitlement Where nEmployeeID = '" + dr["nEmployeeID"].ToString() + "'";
            CreateCmdsAndUpdate(strSQL, dtEmployeeLeave);

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DataRow dr = this.gridViewMd_Employee.GetDataRow(this.gridViewMd_Employee.FocusedRowHandle);

            int[] rowsHandle = gridView2.GetSelectedRows();
            if (rowsHandle == null || rowsHandle.Length == 0)
            {
                UI.ShowErrorMessage(this, "Please select at least one row.");
                return;
            }
            DataTable dtTemp = (gridView1.DataSource as DataView).Table;
            foreach (int index in rowsHandle)
            {
                DataRow rCopy = gridView2.GetDataRow(index);
                DataRow rNew = dtTemp.NewRow();
                rNew.BeginEdit();
                rNew["strLeaveCode"] = rCopy["strLeaveCode"];
                rNew["strDescription"] = rCopy["strDescription"];
                rNew.EndEdit();
                dtTemp.Rows.Add(rNew);
            }
            gridView2.DeleteSelectedRows();

            try
            {
                string strSQL = "select nEmployeeID, strLeaveCode,'' from tblLeaveEntitlement Where nEmployeeID = '" + dr["nEmployeeID"].ToString() + "'";
                CreateCmdsAndUpdate(strSQL, dtEmployeeLeave);
            }
            catch (Exception)
            {
                return;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            grpBranch.Visible = false;
            groupControl1.Visible = false;
            gcServiceType.Visible = true;
        }

        private void sbNext_Click(object sender, EventArgs e)
        {
            DataRow dr = this.gridViewMd_Employee.GetDataRow(this.gridViewMd_Employee.FocusedRowHandle);

            int[] rowsHandle = this.gridView6.GetSelectedRows();
            if (rowsHandle == null || rowsHandle.Length == 0)
            {
                UI.ShowErrorMessage(this, "Please select at least one row.");
                return;
            }
            
            foreach (int index in rowsHandle)
            {
                DataRow rCopy = gridView6.GetDataRow(index);
                DataRow rNew = dtServiceType.NewRow();
                rNew.BeginEdit();
                rNew["nEmployeeNo"] = dr["nEmployeeID"];
                rNew["nServiceTypeID"] = rCopy["nServiceTypeID"];
                rNew["strDescription"] = rCopy["strDescription"];                
                rNew.EndEdit();
                dtServiceType.Rows.Add(rNew);
            }

            gridView6.DeleteSelectedRows();

            try
            {                
                string strSQL = "select nEmployeeNo, nServiceTypeID from tblEmployeeServiceType Where nEmployeeNo = " + dr["nEmployeeID"].ToString() + "";                
                CreateCmdsAndUpdate(strSQL, dtServiceType);
            }
            catch (Exception)
            {
                return;
            }
        }

        private void sbNextAll_Click(object sender, EventArgs e)
        {
            gridView6.BeginDataUpdate();
            gridView5.BeginDataUpdate();

            DataRow dr = this.gridViewMd_Employee.GetDataRow(this.gridViewMd_Employee.FocusedRowHandle);
            DataTable dtTemp = (gridView6.DataSource as DataView).Table;
            //dtTemp.RejectChanges();
            dtTemp.AcceptChanges();

            for (int i = dtTemp.Rows.Count - 1; i >= 0; i--)
            {
                DataRow rCopy = gridView6.GetDataRow(i);
                DataRow rNew = dtServiceType.NewRow();
                rNew.BeginEdit();
                rNew["nEmployeeNo"] = dr["nEmployeeID"];
                rNew["nServiceTypeID"] = rCopy["nServiceTypeID"];
                rNew["strDescription"] = rCopy["strDescription"];               
                rNew.EndEdit();
                dtServiceType.Rows.Add(rNew);
            }

            for (int i = dtTemp.Rows.Count - 1; i >= 0; i--)
            {
                if (dtTemp.Rows[i].RowState != DataRowState.Deleted)
                    dtTemp.Rows[i].Delete();
            }

            gridView6.EndDataUpdate();
            gridView5.EndDataUpdate();

            string strSQL = "select nEmployeeNo, nServiceTypeID from tblEmployeeServiceType Where nEmployeeNo = " + dr["nEmployeeID"].ToString() + "";
            CreateCmdsAndUpdate(strSQL, dtServiceType);
        }

        private void sbPreviousAll_Click(object sender, EventArgs e)
        {
            DataRow dr = this.gridViewMd_Employee.GetDataRow(this.gridViewMd_Employee.FocusedRowHandle);

            gridView6.BeginDataUpdate();
            gridView5.BeginDataUpdate();
            DataTable dtTemp = (gridView6.DataSource as DataView).Table;

            for (int i = dtServiceType.Rows.Count - 1; i >= 0; i--)
            {
                DataRow rCopy = gridView5.GetDataRow(i);
                DataRow rNew = dtTemp.NewRow();
                rNew.BeginEdit();                
                rNew["nServiceTypeID"] = rCopy["nServiceTypeID"];
                rNew["strDescription"] = rCopy["strDescription"];               
                rNew.EndEdit();
                dtTemp.Rows.Add(rNew);
            }

            for (int i = dtServiceType.Rows.Count - 1; i >= 0; i--)
            {
                if (dtServiceType.Rows[i].RowState != DataRowState.Deleted)
                    dtServiceType.Rows[i].Delete();
            }

            gridView6.EndDataUpdate();
            gridView5.EndDataUpdate();

            string strSQL = "select nEmployeeServiceTypeID, nEmployeeNo, nServiceTypeID from tblEmployeeServiceType Where nEmployeeNo = " + dr["nEmployeeID"].ToString() + "";
            CreateCmdsAndUpdate(strSQL, dtServiceType);
        }

        private void sbPrevious_Click(object sender, EventArgs e)
        {
            DataRow dr = this.gridViewMd_Employee.GetDataRow(this.gridViewMd_Employee.FocusedRowHandle);

            int[] rowsHandle = gridView5.GetSelectedRows();
            if (rowsHandle == null || rowsHandle.Length == 0)
            {
                UI.ShowErrorMessage(this, "Please select at least one row.");
                return;
            }
            DataTable dtTemp = (gridView6.DataSource as DataView).Table;
            foreach (int index in rowsHandle)
            {
                DataRow rCopy = gridView5.GetDataRow(index);
                DataRow rNew = dtTemp.NewRow();
                rNew.BeginEdit();
                rNew["nServiceTypeID"] = rCopy["nServiceTypeID"];
                rNew["strDescription"] = rCopy["strDescription"];        
                rNew.EndEdit();
                dtTemp.Rows.Add(rNew);
            }
            gridView5.DeleteSelectedRows();

            try
            {
                string strSQL = "select nEmployeeServiceTypeID, nEmployeeNo, nServiceTypeID from tblEmployeeServiceType Where nEmployeeNo = " + dr["nEmployeeID"].ToString() + "";
                CreateCmdsAndUpdate(strSQL, dtServiceType);
            }
            catch (Exception)
            {
                return;
            }
        }

      

		}
}
