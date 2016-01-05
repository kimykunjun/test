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
		private DevExpress.XtraEditors.GroupControl groupSalesComm;
		private DevExpress.XtraGrid.GridControl gridSalesComm;
		private DevExpress.XtraGrid.Columns.GridColumn nCommGroupID;
		private DevExpress.XtraGrid.Columns.GridColumn mIndivTarget;
		private DevExpress.XtraGrid.Columns.GridColumn dtFrom;
		private DevExpress.XtraGrid.Columns.GridColumn dtTo;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_CommGroupID;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView_SalesComm;
		internal DevExpress.XtraEditors.SimpleButton btn_Comm_Add;
		internal DevExpress.XtraEditors.SimpleButton btn_Comm_Del;
		private DevExpress.XtraGrid.Columns.GridColumn nLeaveGroup;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chk_StatusID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
		private DataTable dtEmployee;
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
            this.btn_Comm_Add = new DevExpress.XtraEditors.SimpleButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btn_Comm_Del = new DevExpress.XtraEditors.SimpleButton();
            this.groupSalesComm = new DevExpress.XtraEditors.GroupControl();
            this.gridSalesComm = new DevExpress.XtraGrid.GridControl();
            this.gridView_SalesComm = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.nCommGroupID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lk_CommGroupID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.mIndivTarget = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dtFrom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dtTo = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.cmbStatus = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.lk_ServiceComm = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.btn_Add = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Del = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grpMDEmployeeTop)).BeginInit();
            this.grpMDEmployeeTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupSalesComm)).BeginInit();
            this.groupSalesComm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSalesComm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_SalesComm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_CommGroupID)).BeginInit();
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
            this.grpMDEmployeeTop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.grpMDEmployeeTop.Controls.Add(this.btn_Comm_Add);
            this.grpMDEmployeeTop.Controls.Add(this.btn_Comm_Del);
            this.grpMDEmployeeTop.Controls.Add(this.groupSalesComm);
            this.grpMDEmployeeTop.Controls.Add(this.Searchpanel);
            this.grpMDEmployeeTop.Controls.Add(this.gridControlMd_Employee);
            this.grpMDEmployeeTop.Controls.Add(this.btn_Add);
            this.grpMDEmployeeTop.Controls.Add(this.btn_Del);
            this.grpMDEmployeeTop.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grpMDEmployeeTop.Location = new System.Drawing.Point(0, 0);
            this.grpMDEmployeeTop.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.grpMDEmployeeTop.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grpMDEmployeeTop.Name = "grpMDEmployeeTop";
            this.grpMDEmployeeTop.Size = new System.Drawing.Size(1072, 560);
            this.grpMDEmployeeTop.TabIndex = 90;
            this.grpMDEmployeeTop.Text = "Employee";
            // 
            // btn_Comm_Add
            // 
            this.btn_Comm_Add.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Comm_Add.Appearance.Options.UseFont = true;
            this.btn_Comm_Add.Appearance.Options.UseTextOptions = true;
            this.btn_Comm_Add.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btn_Comm_Add.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.btn_Comm_Add.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btn_Comm_Add.ImageIndex = 0;
            this.btn_Comm_Add.ImageList = this.imageList1;
            this.btn_Comm_Add.ImeMode = System.Windows.Forms.ImeMode.On;
            this.btn_Comm_Add.Location = new System.Drawing.Point(8, 416);
            this.btn_Comm_Add.Name = "btn_Comm_Add";
            this.btn_Comm_Add.Size = new System.Drawing.Size(38, 16);
            this.btn_Comm_Add.TabIndex = 153;
            this.btn_Comm_Add.Click += new System.EventHandler(this.btn_Comm_Add_Click);
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
            // btn_Comm_Del
            // 
            this.btn_Comm_Del.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Comm_Del.Appearance.Options.UseFont = true;
            this.btn_Comm_Del.Appearance.Options.UseTextOptions = true;
            this.btn_Comm_Del.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btn_Comm_Del.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.btn_Comm_Del.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btn_Comm_Del.ImageIndex = 1;
            this.btn_Comm_Del.ImageList = this.imageList1;
            this.btn_Comm_Del.Location = new System.Drawing.Point(48, 416);
            this.btn_Comm_Del.Name = "btn_Comm_Del";
            this.btn_Comm_Del.Size = new System.Drawing.Size(38, 16);
            this.btn_Comm_Del.TabIndex = 152;
            this.btn_Comm_Del.Click += new System.EventHandler(this.btn_Comm_Del_Click);
            // 
            // groupSalesComm
            // 
            this.groupSalesComm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupSalesComm.Controls.Add(this.gridSalesComm);
            this.groupSalesComm.Location = new System.Drawing.Point(0, 440);
            this.groupSalesComm.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupSalesComm.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupSalesComm.Name = "groupSalesComm";
            this.groupSalesComm.Size = new System.Drawing.Size(984, 120);
            this.groupSalesComm.TabIndex = 151;
            this.groupSalesComm.Text = "Sales Commission Setup";
            // 
            // gridSalesComm
            // 
            this.gridSalesComm.Dock = System.Windows.Forms.DockStyle.Left;
            this.gridSalesComm.EmbeddedNavigator.Name = "";
            this.gridSalesComm.Location = new System.Drawing.Point(2, 19);
            this.gridSalesComm.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridSalesComm.MainView = this.gridView_SalesComm;
            this.gridSalesComm.Name = "gridSalesComm";
            this.gridSalesComm.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lk_CommGroupID});
            this.gridSalesComm.Size = new System.Drawing.Size(958, 99);
            this.gridSalesComm.TabIndex = 126;
            this.gridSalesComm.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_SalesComm});
            // 
            // gridView_SalesComm
            // 
            this.gridView_SalesComm.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.nCommGroupID,
            this.mIndivTarget,
            this.dtFrom,
            this.dtTo});
            this.gridView_SalesComm.GridControl = this.gridSalesComm;
            this.gridView_SalesComm.Name = "gridView_SalesComm";
            this.gridView_SalesComm.OptionsCustomization.AllowColumnMoving = false;
            this.gridView_SalesComm.OptionsCustomization.AllowFilter = false;
            this.gridView_SalesComm.OptionsCustomization.AllowSort = false;
            this.gridView_SalesComm.OptionsView.ShowGroupPanel = false;
            this.gridView_SalesComm.LostFocus += new System.EventHandler(this.gridView_SalesComm_LostFocus);
            // 
            // nCommGroupID
            // 
            this.nCommGroupID.Caption = "Commission Type";
            this.nCommGroupID.ColumnEdit = this.lk_CommGroupID;
            this.nCommGroupID.FieldName = "nCommGroupID";
            this.nCommGroupID.Name = "nCommGroupID";
            this.nCommGroupID.Visible = true;
            this.nCommGroupID.VisibleIndex = 2;
            // 
            // lk_CommGroupID
            // 
            this.lk_CommGroupID.AutoHeight = false;
            this.lk_CommGroupID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lk_CommGroupID.Name = "lk_CommGroupID";
            // 
            // mIndivTarget
            // 
            this.mIndivTarget.Caption = "Commission Target";
            this.mIndivTarget.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.mIndivTarget.FieldName = "mIndivTarget";
            this.mIndivTarget.Name = "mIndivTarget";
            this.mIndivTarget.Visible = true;
            this.mIndivTarget.VisibleIndex = 3;
            // 
            // dtFrom
            // 
            this.dtFrom.Caption = "Valid From";
            this.dtFrom.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtFrom.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtFrom.FieldName = "dtFrom";
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Visible = true;
            this.dtFrom.VisibleIndex = 0;
            // 
            // dtTo
            // 
            this.dtTo.Caption = "Valid Till";
            this.dtTo.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtTo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtTo.FieldName = "dtTo";
            this.dtTo.Name = "dtTo";
            this.dtTo.Visible = true;
            this.dtTo.VisibleIndex = 1;
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
            this.gridControlMd_Employee.EmbeddedNavigator.Name = "";
            this.gridControlMd_Employee.Location = new System.Drawing.Point(8, 46);
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
            this.chk_StatusID});
            this.gridControlMd_Employee.Size = new System.Drawing.Size(984, 344);
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
            this.gridColumn6});
            this.gridViewMd_Employee.GridControl = this.gridControlMd_Employee;
            this.gridViewMd_Employee.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridViewMd_Employee.Name = "gridViewMd_Employee";
            this.gridViewMd_Employee.OptionsCustomization.AllowFilter = false;
            this.gridViewMd_Employee.OptionsCustomization.AllowSort = false;
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
            this.gridColumn5.VisibleIndex = 6;
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
            this.gridColumn11.VisibleIndex = 7;
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
            this.gridColumn12.VisibleIndex = 8;
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
            this.gridColumn13.VisibleIndex = 9;
            this.gridColumn13.Width = 78;
            // 
            // nLeaveGroup
            // 
            this.nLeaveGroup.Caption = "Leave Grp";
            this.nLeaveGroup.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.nLeaveGroup.FieldName = "nLeaveGroup";
            this.nLeaveGroup.Name = "nLeaveGroup";
            this.nLeaveGroup.Visible = true;
            this.nLeaveGroup.VisibleIndex = 10;
            this.nLeaveGroup.Width = 61;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Part Time";
            this.gridColumn14.ColumnEdit = this.chkPartTime;
            this.gridColumn14.FieldName = "fPartTime";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 11;
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
            this.gridColumn15.VisibleIndex = 12;
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
            this.gridColumn16.VisibleIndex = 13;
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
            this.gridColumn17.VisibleIndex = 14;
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
            this.gridColumn18.VisibleIndex = 15;
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
            this.gridColumn19.VisibleIndex = 16;
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
            this.gridColumn20.VisibleIndex = 17;
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
            this.gridColumn21.VisibleIndex = 18;
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
            this.gridColumn22.VisibleIndex = 19;
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
            this.gridColumn23.VisibleIndex = 20;
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
            this.gridColumn24.VisibleIndex = 21;
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
            this.gridColumn25.VisibleIndex = 22;
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
            this.gridColumn6.VisibleIndex = 23;
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
            ((System.ComponentModel.ISupportInitialize)(this.groupSalesComm)).EndInit();
            this.groupSalesComm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSalesComm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_SalesComm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_CommGroupID)).EndInit();
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
			DataRow row = this.gridViewMd_Employee.GetDataRow(gridViewMd_Employee.FocusedRowHandle);
		
			string strSQL="Select * from tblCommEmployee where nEmployeeID=" + row["nEmployeeID"] + "";
			DataSet _ds = new DataSet();
	
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dtSaleComm = _ds.Tables["table"];
			this.gridSalesComm.DataSource = dtSaleComm;
		}

		private void SalesComm_Init(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
			load_SalesComm();
		}

		private void lk_CommGroupID_Init()
		{
			DataSet _ds = new DataSet();
			string strSQL;
			
			strSQL = "select distinct(nCommGroupID), strGroupName from tblCommGroup";
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			DataTable dt = _ds.Tables["table"];
						
			DevExpress.XtraEditors.Controls.LookUpColumnInfo[] col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
						
			col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nCommGroupID","Style ID",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strGroupName","Description",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
					
			new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(lk_CommGroupID,dt,col,"strGroupName","nCommGroupID","Commission Type");
		}

		private void btn_Comm_Add_Click(object sender, System.EventArgs e)
		{
			AddNew=true;
			DataRow dr = gridView_SalesComm.GetDataRow(gridView_SalesComm.FocusedRowHandle);
			
			dr = dtSaleComm.NewRow();
			dtSaleComm.Rows.Add(dr);
			gridView_SalesComm.FocusedRowHandle = dtSaleComm.Rows.Count - 1;
		
		}

		private void btn_Comm_Del_Click(object sender, System.EventArgs e)
		{
			DataRow row = this.gridView_SalesComm.GetDataRow(gridView_SalesComm.FocusedRowHandle);
			if (row != null)
			{
	
				if (AddNew)
				{
					AddNew = false;
					gridView_SalesComm.DeleteRow(gridView_SalesComm.FocusedRowHandle);
				}
				else
				{

					DialogResult result = MessageBox.Show(this, "Do you really want to delete this record ?","Delete?", MessageBoxButtons.YesNo);
					if (result == DialogResult.Yes)
					{
						try
						{
							SqlHelper.ExecuteNonQuery(connection,"del_SalesCommEmployee",
								new SqlParameter("@nEmployeeID",row["nEmployeeID"].ToString()),
								new SqlParameter("@nCommGroupID",row["nCommGroupID"].ToString()),
								new SqlParameter("@dtFrom",row["dtFrom"].ToString()),
								new SqlParameter("@dtTo",row["dtTo"].ToString()));
						}
						catch(Exception ex)
						{
							MessageBox.Show(ex.Message ,"Delete Process Failed");
							return;
						}
						MessageBox.Show("Record Deleted Successfully","Message");
					}
					load_SalesComm();
				}
			}
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

		private void gridView_SalesComm_LostFocus(object sender, System.EventArgs e)
		{
			DataRow row = this.gridView_SalesComm.GetDataRow(gridView_SalesComm.FocusedRowHandle);
			
			DataRow MasterRow = this.gridViewMd_Employee.GetDataRow(gridViewMd_Employee.FocusedRowHandle);
		
			//string strSQL="Select * from tblCommEmployee where nEmployeeID=" + row["nEmployeeID"] + "";
		
			string strSQL = "Select * from tblCommEmployee";
			if (AddNew)
			{
				row[0]= MasterRow["nEmployeeID"].ToString();
				if( CheckClassTypeField(row))
				{

					gridView_SalesComm.UpdateCurrentRow();
					try
					{
						CreateCmdsAndUpdate(strSQL,dtSaleComm);
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
				this.gridView_SalesComm.CloseEditor();
				gridView_SalesComm.UpdateCurrentRow();
				CreateCmdsAndUpdate(strSQL,dtSaleComm);
			}
		}


		}
}
