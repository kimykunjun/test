using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;
using System.Data.OleDb;


namespace ACMS.ACMSManager.MasterData
{
	/// <summary>
	/// Summary description for frmUserRights.
	/// </summary>
	public class frmUserRights : System.Windows.Forms.Form
	{
		private ACMS.XtraUtils.LookupEditBuilder.BranchCodeLookupEditBuilder myBranch;
		
		private string connectionString;
		private SqlConnection connection;
		private DevExpress.XtraEditors.GroupControl grpMDUserRight;
		private DevExpress.XtraTab.XtraTabControl TabControlMd_UserRightLevel;
		private DevExpress.XtraTab.XtraTabPage TabPageBranchRight;
		private DevExpress.XtraTab.XtraTabPage TabPageRight;
		private DevExpress.XtraTab.XtraTabPage TabPageRightLevel;
		private DevExpress.XtraTab.XtraTabPage TabPageRightLevelEntries;
		private DevExpress.XtraEditors.GroupControl groupControl1;
		private DevExpress.XtraGrid.GridControl gridControlMd_UserBranchRight;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewMd_BRight;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnBRight1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnBRight2;
		private System.Windows.Forms.ImageList imageList1;
		private DevExpress.XtraEditors.GroupControl groupControl2;
		private DevExpress.XtraGrid.GridControl gridControlMd_RightCode;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewMd_RightCode;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnRightCode1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnRightCode2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnRightCode3;
		private DevExpress.XtraEditors.GroupControl groupControl3;
		private DevExpress.XtraGrid.GridControl gridControlMd_RightLevel;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewMd_RightLevel;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnMdRL1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnMdRL2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnMdRL3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnMdRL4;
		private DevExpress.XtraEditors.GroupControl groupControl4;
		private DevExpress.XtraGrid.GridControl gridControlMd_RightLevelEntries;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewRightLevelEntries;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnRLE1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnRLE2;
		internal DevExpress.XtraEditors.SimpleButton btnBranch_Add;
		internal DevExpress.XtraEditors.SimpleButton btnBranch_Del;
		private System.ComponentModel.IContainer components;
		private DataTable dtBranchRight;
		private DataTable dtRightCode;
		private DataTable dtRightLevel;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_EmployeeID;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_BranchID;
		internal DevExpress.XtraEditors.SimpleButton btnRightCode_Add;
		internal DevExpress.XtraEditors.SimpleButton btnRightCode_Del;
		private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox cmbRightType;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_RightLevelEmployeeID;
		internal DevExpress.XtraEditors.SimpleButton btnRightLevel_Add;
		internal DevExpress.XtraEditors.SimpleButton btnRightLevel_Del;
		internal DevExpress.XtraEditors.SimpleButton btnRLEntries_Add;
		internal DevExpress.XtraEditors.SimpleButton btnRLEntries_Del;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_RightsLevel;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_Rights;
		private DevExpress.XtraEditors.TextEdit ddlMember;
		private System.Windows.Forms.Label label5;
		internal DevExpress.XtraEditors.SimpleButton btnPcReset;
		internal DevExpress.XtraEditors.SimpleButton btnPcSearch;
		private DataTable dtRightLevelEntries;

		public frmUserRights()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmUserRights));
			this.grpMDUserRight = new DevExpress.XtraEditors.GroupControl();
			this.TabControlMd_UserRightLevel = new DevExpress.XtraTab.XtraTabControl();
			this.TabPageBranchRight = new DevExpress.XtraTab.XtraTabPage();
			this.btnPcReset = new DevExpress.XtraEditors.SimpleButton();
			this.btnPcSearch = new DevExpress.XtraEditors.SimpleButton();
			this.ddlMember = new DevExpress.XtraEditors.TextEdit();
			this.label5 = new System.Windows.Forms.Label();
			this.btnBranch_Add = new DevExpress.XtraEditors.SimpleButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.btnBranch_Del = new DevExpress.XtraEditors.SimpleButton();
			this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
			this.gridControlMd_UserBranchRight = new DevExpress.XtraGrid.GridControl();
			this.gridViewMd_BRight = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumnBRight1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.lk_EmployeeID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			this.gridColumnBRight2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.lk_BranchID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			this.TabPageRight = new DevExpress.XtraTab.XtraTabPage();
			this.btnRightCode_Add = new DevExpress.XtraEditors.SimpleButton();
			this.btnRightCode_Del = new DevExpress.XtraEditors.SimpleButton();
			this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
			this.gridControlMd_RightCode = new DevExpress.XtraGrid.GridControl();
			this.gridViewMd_RightCode = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumnRightCode1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumnRightCode2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumnRightCode3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.cmbRightType = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
			this.TabPageRightLevel = new DevExpress.XtraTab.XtraTabPage();
			this.btnRightLevel_Add = new DevExpress.XtraEditors.SimpleButton();
			this.btnRightLevel_Del = new DevExpress.XtraEditors.SimpleButton();
			this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
			this.gridControlMd_RightLevel = new DevExpress.XtraGrid.GridControl();
			this.gridViewMd_RightLevel = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumnMdRL1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumnMdRL2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumnMdRL3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumnMdRL4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.lk_RightLevelEmployeeID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			this.TabPageRightLevelEntries = new DevExpress.XtraTab.XtraTabPage();
			this.btnRLEntries_Add = new DevExpress.XtraEditors.SimpleButton();
			this.btnRLEntries_Del = new DevExpress.XtraEditors.SimpleButton();
			this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
			this.gridControlMd_RightLevelEntries = new DevExpress.XtraGrid.GridControl();
			this.gridViewRightLevelEntries = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumnRLE1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.lk_RightsLevel = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			this.gridColumnRLE2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.lk_Rights = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			((System.ComponentModel.ISupportInitialize)(this.grpMDUserRight)).BeginInit();
			this.grpMDUserRight.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.TabControlMd_UserRightLevel)).BeginInit();
			this.TabControlMd_UserRightLevel.SuspendLayout();
			this.TabPageBranchRight.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ddlMember.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
			this.groupControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControlMd_UserBranchRight)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewMd_BRight)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_EmployeeID)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_BranchID)).BeginInit();
			this.TabPageRight.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
			this.groupControl2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControlMd_RightCode)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewMd_RightCode)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbRightType)).BeginInit();
			this.TabPageRightLevel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
			this.groupControl3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControlMd_RightLevel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewMd_RightLevel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_RightLevelEmployeeID)).BeginInit();
			this.TabPageRightLevelEntries.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
			this.groupControl4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControlMd_RightLevelEntries)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewRightLevelEntries)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_RightsLevel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_Rights)).BeginInit();
			this.SuspendLayout();
			// 
			// grpMDUserRight
			// 
			this.grpMDUserRight.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.grpMDUserRight.Appearance.Options.UseBackColor = true;
			this.grpMDUserRight.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.grpMDUserRight.AppearanceCaption.Options.UseFont = true;
			this.grpMDUserRight.Controls.Add(this.TabControlMd_UserRightLevel);
			this.grpMDUserRight.ImeMode = System.Windows.Forms.ImeMode.On;
			this.grpMDUserRight.Location = new System.Drawing.Point(8, 0);
			this.grpMDUserRight.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.grpMDUserRight.LookAndFeel.UseDefaultLookAndFeel = false;
			this.grpMDUserRight.LookAndFeel.UseWindowsXPTheme = false;
			this.grpMDUserRight.Name = "grpMDUserRight";
			this.grpMDUserRight.Size = new System.Drawing.Size(960, 528);
			this.grpMDUserRight.TabIndex = 91;
			this.grpMDUserRight.Text = "User Rights";
			// 
			// TabControlMd_UserRightLevel
			// 
			this.TabControlMd_UserRightLevel.AppearancePage.Header.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.TabControlMd_UserRightLevel.AppearancePage.Header.Options.UseFont = true;
			this.TabControlMd_UserRightLevel.Dock = System.Windows.Forms.DockStyle.Top;
			this.TabControlMd_UserRightLevel.Location = new System.Drawing.Point(2, 20);
			this.TabControlMd_UserRightLevel.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.TabControlMd_UserRightLevel.LookAndFeel.UseDefaultLookAndFeel = false;
			this.TabControlMd_UserRightLevel.Name = "TabControlMd_UserRightLevel";
			this.TabControlMd_UserRightLevel.SelectedTabPage = this.TabPageBranchRight;
			this.TabControlMd_UserRightLevel.Size = new System.Drawing.Size(956, 506);
			this.TabControlMd_UserRightLevel.TabIndex = 21;
			this.TabControlMd_UserRightLevel.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
																										this.TabPageBranchRight,
																										this.TabPageRight,
																										this.TabPageRightLevel,
																										this.TabPageRightLevelEntries});
			this.TabControlMd_UserRightLevel.Text = "xtraTabControl2";
			// 
			// TabPageBranchRight
			// 
			this.TabPageBranchRight.Controls.Add(this.btnPcReset);
			this.TabPageBranchRight.Controls.Add(this.btnPcSearch);
			this.TabPageBranchRight.Controls.Add(this.ddlMember);
			this.TabPageBranchRight.Controls.Add(this.label5);
			this.TabPageBranchRight.Controls.Add(this.btnBranch_Add);
			this.TabPageBranchRight.Controls.Add(this.btnBranch_Del);
			this.TabPageBranchRight.Controls.Add(this.groupControl1);
			this.TabPageBranchRight.Name = "TabPageBranchRight";
			this.TabPageBranchRight.Size = new System.Drawing.Size(950, 477);
			this.TabPageBranchRight.Text = "Branch Right";
			// 
			// btnPcReset
			// 
			this.btnPcReset.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.btnPcReset.Appearance.Options.UseFont = true;
			this.btnPcReset.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnPcReset.Location = new System.Drawing.Point(392, 8);
			this.btnPcReset.Name = "btnPcReset";
			this.btnPcReset.Size = new System.Drawing.Size(72, 20);
			this.btnPcReset.TabIndex = 179;
			this.btnPcReset.Text = "Reset";
			this.btnPcReset.Click += new System.EventHandler(this.btnPcReset_Click);
			// 
			// btnPcSearch
			// 
			this.btnPcSearch.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.btnPcSearch.Appearance.Options.UseFont = true;
			this.btnPcSearch.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnPcSearch.Location = new System.Drawing.Point(312, 8);
			this.btnPcSearch.Name = "btnPcSearch";
			this.btnPcSearch.Size = new System.Drawing.Size(72, 20);
			this.btnPcSearch.TabIndex = 178;
			this.btnPcSearch.Text = "Search";
			this.btnPcSearch.Click += new System.EventHandler(this.btnPcSearch_Click);
			// 
			// ddlMember
			// 
			this.ddlMember.EditValue = "";
			this.ddlMember.Location = new System.Drawing.Point(184, 8);
			this.ddlMember.Name = "ddlMember";
			this.ddlMember.Size = new System.Drawing.Size(120, 20);
			this.ddlMember.TabIndex = 177;
			this.ddlMember.ToolTip = "Use Search Member Tools For Input ";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.Location = new System.Drawing.Point(104, 8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(80, 22);
			this.label5.TabIndex = 175;
			this.label5.Text = "Employee ID";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnBranch_Add
			// 
			this.btnBranch_Add.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnBranch_Add.Appearance.Options.UseFont = true;
			this.btnBranch_Add.Appearance.Options.UseTextOptions = true;
			this.btnBranch_Add.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.btnBranch_Add.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
			this.btnBranch_Add.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.btnBranch_Add.ImageIndex = 0;
			this.btnBranch_Add.ImageList = this.imageList1;
			this.btnBranch_Add.ImeMode = System.Windows.Forms.ImeMode.On;
			this.btnBranch_Add.Location = new System.Drawing.Point(8, 8);
			this.btnBranch_Add.Name = "btnBranch_Add";
			this.btnBranch_Add.Size = new System.Drawing.Size(38, 20);
			this.btnBranch_Add.TabIndex = 136;
			this.btnBranch_Add.Click += new System.EventHandler(this.btnBranch_Add_Click);
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
			// 
			// btnBranch_Del
			// 
			this.btnBranch_Del.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnBranch_Del.Appearance.Options.UseFont = true;
			this.btnBranch_Del.Appearance.Options.UseTextOptions = true;
			this.btnBranch_Del.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.btnBranch_Del.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
			this.btnBranch_Del.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.btnBranch_Del.ImageIndex = 1;
			this.btnBranch_Del.ImageList = this.imageList1;
			this.btnBranch_Del.Location = new System.Drawing.Point(56, 8);
			this.btnBranch_Del.Name = "btnBranch_Del";
			this.btnBranch_Del.Size = new System.Drawing.Size(38, 20);
			this.btnBranch_Del.TabIndex = 135;
			this.btnBranch_Del.Click += new System.EventHandler(this.btnBranch_Del_Click);
			// 
			// groupControl1
			// 
			this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.groupControl1.Controls.Add(this.gridControlMd_UserBranchRight);
			this.groupControl1.Location = new System.Drawing.Point(0, 32);
			this.groupControl1.Name = "groupControl1";
			this.groupControl1.Size = new System.Drawing.Size(944, 456);
			this.groupControl1.TabIndex = 0;
			// 
			// gridControlMd_UserBranchRight
			// 
			this.gridControlMd_UserBranchRight.Dock = System.Windows.Forms.DockStyle.Top;
			// 
			// gridControlMd_UserBranchRight.EmbeddedNavigator
			// 
			this.gridControlMd_UserBranchRight.EmbeddedNavigator.Name = "";
			this.gridControlMd_UserBranchRight.Location = new System.Drawing.Point(0, 0);
			this.gridControlMd_UserBranchRight.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.gridControlMd_UserBranchRight.LookAndFeel.UseDefaultLookAndFeel = false;
			this.gridControlMd_UserBranchRight.MainView = this.gridViewMd_BRight;
			this.gridControlMd_UserBranchRight.Name = "gridControlMd_UserBranchRight";
			this.gridControlMd_UserBranchRight.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																																   this.lk_EmployeeID,
																																   this.lk_BranchID});
			this.gridControlMd_UserBranchRight.Size = new System.Drawing.Size(944, 434);
			this.gridControlMd_UserBranchRight.TabIndex = 21;
			this.gridControlMd_UserBranchRight.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																														 this.gridViewMd_BRight});
			// 
			// gridViewMd_BRight
			// 
			this.gridViewMd_BRight.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																									 this.gridColumnBRight1,
																									 this.gridColumnBRight2});
			this.gridViewMd_BRight.GridControl = this.gridControlMd_UserBranchRight;
			this.gridViewMd_BRight.Name = "gridViewMd_BRight";
			this.gridViewMd_BRight.OptionsCustomization.AllowFilter = false;
			this.gridViewMd_BRight.OptionsCustomization.AllowSort = false;
			this.gridViewMd_BRight.OptionsView.ShowGroupPanel = false;
			this.gridViewMd_BRight.LostFocus += new System.EventHandler(this.gridViewMd_BRight_LostFocus);
			// 
			// gridColumnBRight1
			// 
			this.gridColumnBRight1.Caption = "Employee Name";
			this.gridColumnBRight1.ColumnEdit = this.lk_EmployeeID;
			this.gridColumnBRight1.FieldName = "nEmployeeID";
			this.gridColumnBRight1.Name = "gridColumnBRight1";
			this.gridColumnBRight1.Visible = true;
			this.gridColumnBRight1.VisibleIndex = 0;
			this.gridColumnBRight1.Width = 106;
			// 
			// lk_EmployeeID
			// 
			this.lk_EmployeeID.AutoHeight = false;
			this.lk_EmployeeID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																									   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lk_EmployeeID.Name = "lk_EmployeeID";
			// 
			// gridColumnBRight2
			// 
			this.gridColumnBRight2.Caption = "Branch Access";
			this.gridColumnBRight2.ColumnEdit = this.lk_BranchID;
			this.gridColumnBRight2.FieldName = "strBranchCode";
			this.gridColumnBRight2.Name = "gridColumnBRight2";
			this.gridColumnBRight2.Visible = true;
			this.gridColumnBRight2.VisibleIndex = 1;
			this.gridColumnBRight2.Width = 820;
			// 
			// lk_BranchID
			// 
			this.lk_BranchID.AutoHeight = false;
			this.lk_BranchID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																									 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lk_BranchID.Name = "lk_BranchID";
			// 
			// TabPageRight
			// 
			this.TabPageRight.Controls.Add(this.btnRightCode_Add);
			this.TabPageRight.Controls.Add(this.btnRightCode_Del);
			this.TabPageRight.Controls.Add(this.groupControl2);
			this.TabPageRight.Name = "TabPageRight";
			this.TabPageRight.Size = new System.Drawing.Size(950, 477);
			this.TabPageRight.Text = "Right Code";
			// 
			// btnRightCode_Add
			// 
			this.btnRightCode_Add.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnRightCode_Add.Appearance.Options.UseFont = true;
			this.btnRightCode_Add.Appearance.Options.UseTextOptions = true;
			this.btnRightCode_Add.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.btnRightCode_Add.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
			this.btnRightCode_Add.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.btnRightCode_Add.ImageIndex = 0;
			this.btnRightCode_Add.ImageList = this.imageList1;
			this.btnRightCode_Add.ImeMode = System.Windows.Forms.ImeMode.On;
			this.btnRightCode_Add.Location = new System.Drawing.Point(8, 0);
			this.btnRightCode_Add.Name = "btnRightCode_Add";
			this.btnRightCode_Add.Size = new System.Drawing.Size(38, 20);
			this.btnRightCode_Add.TabIndex = 138;
			this.btnRightCode_Add.Click += new System.EventHandler(this.btnRightCode_Add_Click);
			// 
			// btnRightCode_Del
			// 
			this.btnRightCode_Del.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnRightCode_Del.Appearance.Options.UseFont = true;
			this.btnRightCode_Del.Appearance.Options.UseTextOptions = true;
			this.btnRightCode_Del.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.btnRightCode_Del.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
			this.btnRightCode_Del.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.btnRightCode_Del.ImageIndex = 1;
			this.btnRightCode_Del.ImageList = this.imageList1;
			this.btnRightCode_Del.Location = new System.Drawing.Point(48, 0);
			this.btnRightCode_Del.Name = "btnRightCode_Del";
			this.btnRightCode_Del.Size = new System.Drawing.Size(38, 20);
			this.btnRightCode_Del.TabIndex = 137;
			this.btnRightCode_Del.Click += new System.EventHandler(this.btnRightCode_Del_Click);
			// 
			// groupControl2
			// 
			this.groupControl2.Controls.Add(this.gridControlMd_RightCode);
			this.groupControl2.Location = new System.Drawing.Point(8, 16);
			this.groupControl2.Name = "groupControl2";
			this.groupControl2.Size = new System.Drawing.Size(944, 456);
			this.groupControl2.TabIndex = 8;
			// 
			// gridControlMd_RightCode
			// 
			this.gridControlMd_RightCode.Dock = System.Windows.Forms.DockStyle.Top;
			// 
			// gridControlMd_RightCode.EmbeddedNavigator
			// 
			this.gridControlMd_RightCode.EmbeddedNavigator.Name = "";
			this.gridControlMd_RightCode.Location = new System.Drawing.Point(4, 18);
			this.gridControlMd_RightCode.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.gridControlMd_RightCode.LookAndFeel.UseDefaultLookAndFeel = false;
			this.gridControlMd_RightCode.MainView = this.gridViewMd_RightCode;
			this.gridControlMd_RightCode.Name = "gridControlMd_RightCode";
			this.gridControlMd_RightCode.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																															 this.cmbRightType});
			this.gridControlMd_RightCode.Size = new System.Drawing.Size(936, 434);
			this.gridControlMd_RightCode.TabIndex = 1;
			this.gridControlMd_RightCode.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																												   this.gridViewMd_RightCode});
			// 
			// gridViewMd_RightCode
			// 
			this.gridViewMd_RightCode.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																										this.gridColumnRightCode1,
																										this.gridColumnRightCode2,
																										this.gridColumnRightCode3});
			this.gridViewMd_RightCode.GridControl = this.gridControlMd_RightCode;
			this.gridViewMd_RightCode.Name = "gridViewMd_RightCode";
			this.gridViewMd_RightCode.OptionsCustomization.AllowFilter = false;
			this.gridViewMd_RightCode.OptionsCustomization.AllowSort = false;
			this.gridViewMd_RightCode.OptionsView.ShowGroupPanel = false;
			this.gridViewMd_RightCode.LostFocus += new System.EventHandler(this.gridViewMd_RightCode_LostFocus);
			// 
			// gridColumnRightCode1
			// 
			this.gridColumnRightCode1.Caption = "Right Code";
			this.gridColumnRightCode1.FieldName = "nRightsID";
			this.gridColumnRightCode1.Name = "gridColumnRightCode1";
			this.gridColumnRightCode1.Visible = true;
			this.gridColumnRightCode1.VisibleIndex = 0;
			this.gridColumnRightCode1.Width = 136;
			// 
			// gridColumnRightCode2
			// 
			this.gridColumnRightCode2.Caption = "Description";
			this.gridColumnRightCode2.FieldName = "strDescription";
			this.gridColumnRightCode2.MinWidth = 40;
			this.gridColumnRightCode2.Name = "gridColumnRightCode2";
			this.gridColumnRightCode2.Visible = true;
			this.gridColumnRightCode2.VisibleIndex = 1;
			this.gridColumnRightCode2.Width = 119;
			// 
			// gridColumnRightCode3
			// 
			this.gridColumnRightCode3.Caption = "Right Type";
			this.gridColumnRightCode3.ColumnEdit = this.cmbRightType;
			this.gridColumnRightCode3.FieldName = "nRightsTypeID";
			this.gridColumnRightCode3.Name = "gridColumnRightCode3";
			this.gridColumnRightCode3.Visible = true;
			this.gridColumnRightCode3.VisibleIndex = 2;
			this.gridColumnRightCode3.Width = 671;
			// 
			// cmbRightType
			// 
			this.cmbRightType.AutoHeight = false;
			this.cmbRightType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																									  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cmbRightType.Items.AddRange(new object[] {
															  new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Login", 0, -1),
															  new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Transaction", 1, -1),
															  new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Report", 2, -1)});
			this.cmbRightType.Name = "cmbRightType";
			// 
			// TabPageRightLevel
			// 
			this.TabPageRightLevel.Controls.Add(this.btnRightLevel_Add);
			this.TabPageRightLevel.Controls.Add(this.btnRightLevel_Del);
			this.TabPageRightLevel.Controls.Add(this.groupControl3);
			this.TabPageRightLevel.Name = "TabPageRightLevel";
			this.TabPageRightLevel.Size = new System.Drawing.Size(950, 477);
			this.TabPageRightLevel.Text = "Right Level";
			// 
			// btnRightLevel_Add
			// 
			this.btnRightLevel_Add.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnRightLevel_Add.Appearance.Options.UseFont = true;
			this.btnRightLevel_Add.Appearance.Options.UseTextOptions = true;
			this.btnRightLevel_Add.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.btnRightLevel_Add.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
			this.btnRightLevel_Add.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.btnRightLevel_Add.ImageIndex = 0;
			this.btnRightLevel_Add.ImageList = this.imageList1;
			this.btnRightLevel_Add.ImeMode = System.Windows.Forms.ImeMode.On;
			this.btnRightLevel_Add.Location = new System.Drawing.Point(8, 0);
			this.btnRightLevel_Add.Name = "btnRightLevel_Add";
			this.btnRightLevel_Add.Size = new System.Drawing.Size(38, 20);
			this.btnRightLevel_Add.TabIndex = 138;
			this.btnRightLevel_Add.Click += new System.EventHandler(this.btnRightLevel_Add_Click);
			// 
			// btnRightLevel_Del
			// 
			this.btnRightLevel_Del.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnRightLevel_Del.Appearance.Options.UseFont = true;
			this.btnRightLevel_Del.Appearance.Options.UseTextOptions = true;
			this.btnRightLevel_Del.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.btnRightLevel_Del.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
			this.btnRightLevel_Del.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.btnRightLevel_Del.ImageIndex = 1;
			this.btnRightLevel_Del.ImageList = this.imageList1;
			this.btnRightLevel_Del.Location = new System.Drawing.Point(48, 0);
			this.btnRightLevel_Del.Name = "btnRightLevel_Del";
			this.btnRightLevel_Del.Size = new System.Drawing.Size(38, 20);
			this.btnRightLevel_Del.TabIndex = 137;
			this.btnRightLevel_Del.Click += new System.EventHandler(this.btnRightLevel_Del_Click);
			// 
			// groupControl3
			// 
			this.groupControl3.Controls.Add(this.gridControlMd_RightLevel);
			this.groupControl3.Location = new System.Drawing.Point(8, 16);
			this.groupControl3.Name = "groupControl3";
			this.groupControl3.Size = new System.Drawing.Size(944, 448);
			this.groupControl3.TabIndex = 1;
			// 
			// gridControlMd_RightLevel
			// 
			this.gridControlMd_RightLevel.Dock = System.Windows.Forms.DockStyle.Top;
			// 
			// gridControlMd_RightLevel.EmbeddedNavigator
			// 
			this.gridControlMd_RightLevel.EmbeddedNavigator.Name = "";
			this.gridControlMd_RightLevel.Location = new System.Drawing.Point(4, 18);
			this.gridControlMd_RightLevel.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.gridControlMd_RightLevel.LookAndFeel.UseDefaultLookAndFeel = false;
			this.gridControlMd_RightLevel.MainView = this.gridViewMd_RightLevel;
			this.gridControlMd_RightLevel.Name = "gridControlMd_RightLevel";
			this.gridControlMd_RightLevel.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																															  this.lk_RightLevelEmployeeID});
			this.gridControlMd_RightLevel.Size = new System.Drawing.Size(936, 426);
			this.gridControlMd_RightLevel.TabIndex = 1;
			this.gridControlMd_RightLevel.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																													this.gridViewMd_RightLevel});
			// 
			// gridViewMd_RightLevel
			// 
			this.gridViewMd_RightLevel.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																										 this.gridColumnMdRL1,
																										 this.gridColumnMdRL2,
																										 this.gridColumnMdRL3,
																										 this.gridColumnMdRL4});
			this.gridViewMd_RightLevel.GridControl = this.gridControlMd_RightLevel;
			this.gridViewMd_RightLevel.Name = "gridViewMd_RightLevel";
			this.gridViewMd_RightLevel.OptionsCustomization.AllowFilter = false;
			this.gridViewMd_RightLevel.OptionsCustomization.AllowSort = false;
			this.gridViewMd_RightLevel.OptionsView.ShowGroupPanel = false;
			this.gridViewMd_RightLevel.LostFocus += new System.EventHandler(this.gridViewMd_RightLevel_LostFocus);
			// 
			// gridColumnMdRL1
			// 
			this.gridColumnMdRL1.Caption = "Right Level ID";
			this.gridColumnMdRL1.FieldName = "nRightsLevelID";
			this.gridColumnMdRL1.Name = "gridColumnMdRL1";
			this.gridColumnMdRL1.Visible = true;
			this.gridColumnMdRL1.VisibleIndex = 0;
			this.gridColumnMdRL1.Width = 121;
			// 
			// gridColumnMdRL2
			// 
			this.gridColumnMdRL2.Caption = "Description";
			this.gridColumnMdRL2.FieldName = "strDescription";
			this.gridColumnMdRL2.Name = "gridColumnMdRL2";
			this.gridColumnMdRL2.Visible = true;
			this.gridColumnMdRL2.VisibleIndex = 1;
			this.gridColumnMdRL2.Width = 546;
			// 
			// gridColumnMdRL3
			// 
			this.gridColumnMdRL3.Caption = "Modified On";
			this.gridColumnMdRL3.FieldName = "dtLastEditDate";
			this.gridColumnMdRL3.Name = "gridColumnMdRL3";
			this.gridColumnMdRL3.Visible = true;
			this.gridColumnMdRL3.VisibleIndex = 2;
			this.gridColumnMdRL3.Width = 101;
			// 
			// gridColumnMdRL4
			// 
			this.gridColumnMdRL4.Caption = "Modified By";
			this.gridColumnMdRL4.ColumnEdit = this.lk_RightLevelEmployeeID;
			this.gridColumnMdRL4.FieldName = "nEmployeeID";
			this.gridColumnMdRL4.Name = "gridColumnMdRL4";
			this.gridColumnMdRL4.Visible = true;
			this.gridColumnMdRL4.VisibleIndex = 3;
			this.gridColumnMdRL4.Width = 158;
			// 
			// lk_RightLevelEmployeeID
			// 
			this.lk_RightLevelEmployeeID.AutoHeight = false;
			this.lk_RightLevelEmployeeID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lk_RightLevelEmployeeID.Name = "lk_RightLevelEmployeeID";
			// 
			// TabPageRightLevelEntries
			// 
			this.TabPageRightLevelEntries.Controls.Add(this.btnRLEntries_Add);
			this.TabPageRightLevelEntries.Controls.Add(this.btnRLEntries_Del);
			this.TabPageRightLevelEntries.Controls.Add(this.groupControl4);
			this.TabPageRightLevelEntries.Name = "TabPageRightLevelEntries";
			this.TabPageRightLevelEntries.Size = new System.Drawing.Size(950, 477);
			this.TabPageRightLevelEntries.Text = "Right Level Entries";
			// 
			// btnRLEntries_Add
			// 
			this.btnRLEntries_Add.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnRLEntries_Add.Appearance.Options.UseFont = true;
			this.btnRLEntries_Add.Appearance.Options.UseTextOptions = true;
			this.btnRLEntries_Add.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.btnRLEntries_Add.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
			this.btnRLEntries_Add.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.btnRLEntries_Add.ImageIndex = 0;
			this.btnRLEntries_Add.ImageList = this.imageList1;
			this.btnRLEntries_Add.ImeMode = System.Windows.Forms.ImeMode.On;
			this.btnRLEntries_Add.Location = new System.Drawing.Point(8, 0);
			this.btnRLEntries_Add.Name = "btnRLEntries_Add";
			this.btnRLEntries_Add.Size = new System.Drawing.Size(38, 20);
			this.btnRLEntries_Add.TabIndex = 138;
			this.btnRLEntries_Add.Click += new System.EventHandler(this.btnRLEntries_Add_Click);
			// 
			// btnRLEntries_Del
			// 
			this.btnRLEntries_Del.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnRLEntries_Del.Appearance.Options.UseFont = true;
			this.btnRLEntries_Del.Appearance.Options.UseTextOptions = true;
			this.btnRLEntries_Del.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.btnRLEntries_Del.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
			this.btnRLEntries_Del.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.btnRLEntries_Del.ImageIndex = 1;
			this.btnRLEntries_Del.ImageList = this.imageList1;
			this.btnRLEntries_Del.Location = new System.Drawing.Point(48, 0);
			this.btnRLEntries_Del.Name = "btnRLEntries_Del";
			this.btnRLEntries_Del.Size = new System.Drawing.Size(38, 20);
			this.btnRLEntries_Del.TabIndex = 137;
			this.btnRLEntries_Del.Click += new System.EventHandler(this.btnRLEntries_Del_Click);
			// 
			// groupControl4
			// 
			this.groupControl4.Controls.Add(this.gridControlMd_RightLevelEntries);
			this.groupControl4.Location = new System.Drawing.Point(8, 16);
			this.groupControl4.Name = "groupControl4";
			this.groupControl4.Size = new System.Drawing.Size(952, 456);
			this.groupControl4.TabIndex = 9;
			// 
			// gridControlMd_RightLevelEntries
			// 
			this.gridControlMd_RightLevelEntries.Dock = System.Windows.Forms.DockStyle.Top;
			// 
			// gridControlMd_RightLevelEntries.EmbeddedNavigator
			// 
			this.gridControlMd_RightLevelEntries.EmbeddedNavigator.Name = "";
			this.gridControlMd_RightLevelEntries.Location = new System.Drawing.Point(4, 18);
			this.gridControlMd_RightLevelEntries.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.gridControlMd_RightLevelEntries.LookAndFeel.UseDefaultLookAndFeel = false;
			this.gridControlMd_RightLevelEntries.MainView = this.gridViewRightLevelEntries;
			this.gridControlMd_RightLevelEntries.Name = "gridControlMd_RightLevelEntries";
			this.gridControlMd_RightLevelEntries.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																																	 this.lk_RightsLevel,
																																	 this.lk_Rights});
			this.gridControlMd_RightLevelEntries.Size = new System.Drawing.Size(944, 442);
			this.gridControlMd_RightLevelEntries.TabIndex = 1;
			this.gridControlMd_RightLevelEntries.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																														   this.gridViewRightLevelEntries});
			// 
			// gridViewRightLevelEntries
			// 
			this.gridViewRightLevelEntries.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																											 this.gridColumnRLE1,
																											 this.gridColumnRLE2});
			this.gridViewRightLevelEntries.GridControl = this.gridControlMd_RightLevelEntries;
			this.gridViewRightLevelEntries.Name = "gridViewRightLevelEntries";
			this.gridViewRightLevelEntries.OptionsCustomization.AllowFilter = false;
			this.gridViewRightLevelEntries.OptionsCustomization.AllowSort = false;
			this.gridViewRightLevelEntries.OptionsView.ShowGroupPanel = false;
			this.gridViewRightLevelEntries.LostFocus += new System.EventHandler(this.gridViewRightLevelEntries_LostFocus);
			// 
			// gridColumnRLE1
			// 
			this.gridColumnRLE1.Caption = "Right Level ID";
			this.gridColumnRLE1.ColumnEdit = this.lk_RightsLevel;
			this.gridColumnRLE1.FieldName = "nRightsLevelID";
			this.gridColumnRLE1.Name = "gridColumnRLE1";
			this.gridColumnRLE1.Visible = true;
			this.gridColumnRLE1.VisibleIndex = 0;
			this.gridColumnRLE1.Width = 126;
			// 
			// lk_RightsLevel
			// 
			this.lk_RightsLevel.AutoHeight = false;
			this.lk_RightsLevel.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																										new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lk_RightsLevel.Name = "lk_RightsLevel";
			// 
			// gridColumnRLE2
			// 
			this.gridColumnRLE2.Caption = "Right ID";
			this.gridColumnRLE2.ColumnEdit = this.lk_Rights;
			this.gridColumnRLE2.FieldName = "nRightsID";
			this.gridColumnRLE2.Name = "gridColumnRLE2";
			this.gridColumnRLE2.Visible = true;
			this.gridColumnRLE2.VisibleIndex = 1;
			this.gridColumnRLE2.Width = 800;
			// 
			// lk_Rights
			// 
			this.lk_Rights.AutoHeight = false;
			this.lk_Rights.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																								   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lk_Rights.Name = "lk_Rights";
			// 
			// frmUserRights
			// 
			this.AutoScale = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(982, 533);
			this.Controls.Add(this.grpMDUserRight);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmUserRights";
			this.Text = "frmUserRights";
			this.Load += new System.EventHandler(this.frmUserRights_Load);
			((System.ComponentModel.ISupportInitialize)(this.grpMDUserRight)).EndInit();
			this.grpMDUserRight.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.TabControlMd_UserRightLevel)).EndInit();
			this.TabControlMd_UserRightLevel.ResumeLayout(false);
			this.TabPageBranchRight.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ddlMember.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
			this.groupControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControlMd_UserBranchRight)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewMd_BRight)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_EmployeeID)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_BranchID)).EndInit();
			this.TabPageRight.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
			this.groupControl2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControlMd_RightCode)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewMd_RightCode)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbRightType)).EndInit();
			this.TabPageRightLevel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
			this.groupControl3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControlMd_RightLevel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewMd_RightLevel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_RightLevelEmployeeID)).EndInit();
			this.TabPageRightLevelEntries.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
			this.groupControl4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControlMd_RightLevelEntries)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewRightLevelEntries)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_RightsLevel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_Rights)).EndInit();
			this.ResumeLayout(false);

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

		#endregion

		private void frmUserRights_Load(object sender, System.EventArgs e)
		{
			BindCombo();
			mdBranchRightInit();
			mdRightCodeInit();
			mdRightLevelInit();
			mdRightLevelEntriesInit();
		}

		#region init
		private void BindCombo()
		{
			DataTable dt;

			string strSQL = "select * from tblEmployee";
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dt = _ds.Tables["table"];

			DevExpress.XtraEditors.Controls.LookUpColumnInfo[] col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
			
			col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nEmployeeID","Employee Id",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strEmployeeName","Employee Name",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
		
			new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(lk_EmployeeID,dt,col,"strEmployeeName","nEmployeeID","Manager");
			
			new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(this.lk_RightLevelEmployeeID,dt,col,"strEmployeeName","nEmployeeID","Manager");

			strSQL = "select strBranchCode, strBranchName from tblBranch";
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dt = _ds.Tables["table"];
			myBranch = new ACMS.XtraUtils.LookupEditBuilder.BranchCodeLookupEditBuilder(dt,lk_BranchID);

			strSQL = "select nRightsID, strDescription from tblRights";
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dt = _ds.Tables["table"];
			
			col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
			
			col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nRightsID","Rights Id",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription","Description",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
		
			new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(this.lk_Rights,dt,col,"strDescription","nRightsID","Rights");


			strSQL = "select nRightsLevelID, strDescription from tblRightsLevel";
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dt = _ds.Tables["table"];
			
			col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
			
			col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nRightsLevelID","Rights Level Id",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription","Description",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
		
			new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(this.lk_RightsLevel,dt,col,"strDescription","nRightsLevelID","Rights");

		}

	
	
		#endregion

	
		#region BranchRight

		private void mdBranchRightInit()
		{
			string strSQL;
			
			strSQL = "select * from tblEmployeeBranchRights ";

			if (ddlMember.EditValue.ToString() != "")
				strSQL += "Where nEmployeeId = '" + ddlMember.EditValue.ToString() + "'";

			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dtBranchRight = _ds.Tables["table"];
			this.gridControlMd_UserBranchRight.DataSource = dtBranchRight;
		
			
		}

		private bool FieldBranchChecking(DataRow dr)
		{
			if ( dr["strBranchCode"].ToString() == "" || dr["strBranchCode"].ToString() == "")
				return false;
			return true;
		}

		private bool AddNewBranch;
		private void btnBranch_Add_Click(object sender, System.EventArgs e)
		{
			AddNewBranch = true;
			DataRow dr = dtBranchRight.NewRow();
			dtBranchRight.Rows.Add(dr);
			this.gridControlMd_UserBranchRight.Refresh();
			this.gridViewMd_BRight.FocusedRowHandle = dtBranchRight.Rows.Count - 1;
		}

		private void btnBranch_Del_Click(object sender, System.EventArgs e)
		{
			DataRow row = gridViewMd_BRight.GetDataRow(gridViewMd_BRight.FocusedRowHandle);
			if (row != null)
			{
	
				if (AddNewBranch)
				{
					AddNewBranch = false;
					gridViewMd_BRight.DeleteRow(gridViewMd_BRight.FocusedRowHandle);
				}
				else
				{

					DialogResult result = MessageBox.Show(this, "Do you really want to delete record with Branch Code = " + row["strBranchCode"].ToString() + " And Employee Id = " + row["nEmployeeID"],
						"Delete?", MessageBoxButtons.YesNo);
					if (result == DialogResult.Yes)
					{
						try
						{
							SqlHelper.ExecuteNonQuery(connection,"del_BranchRight",
								new SqlParameter("@branchCode",row["strBranchCode"].ToString() ),
								new SqlParameter("@Employee",row["nEmployeeID"].ToString() )
								);
						}
						catch(Exception ex)
						{
							MessageBox.Show(ex.Message ,"Delete Process Failed");
							return;
						}
						MessageBox.Show("Record Deleted Successfully","Message");
					}
					mdBranchRightInit();
				}
			}
		}

		private void gridViewMd_BRight_LostFocus(object sender, System.EventArgs e)
		{
			DataRow row = this.gridViewMd_BRight.GetDataRow(gridViewMd_BRight.FocusedRowHandle);
		
			string strSQL = "select * from tblEmployeeBranchRights where strBranchCode='" + row["strBranchCode"] + "' And nEmployeeId = " + Convert.ToInt32(row["nEmployeeID"]);
			
			if (AddNewBranch)
			{
				if( FieldBranchChecking(row))
				{
					this.gridControlMd_UserBranchRight.MainView.UpdateCurrentRow();
					CreateCmdsAndUpdate(strSQL,dtBranchRight);
					AddNewBranch = false;
				}
			}
			else
			{
				this.gridViewMd_BRight.CloseEditor();
				this.gridViewMd_BRight.UpdateCurrentRow();

				CreateCmdsAndUpdate(strSQL,dtBranchRight);
			}
		}
		#endregion

		#region Right Code

		
		private void mdRightCodeInit()
		{
			string strSQL;

			strSQL = "select * from tblRights";
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dtRightCode = _ds.Tables["table"];
			this.gridControlMd_RightCode.DataSource = dtRightCode;

		}
		private bool FieldRightCodeChecking(DataRow dr)
		{
			if ( dr["nRightsID"].ToString() == "" || dr["nRightsID"].ToString() == "")
				return false;
			return true;
		}

		private bool AddNewRightCode;
		private void btnRightCode_Add_Click(object sender, System.EventArgs e)
		{
			AddNewRightCode = true;
			DataRow dr = dtRightCode.NewRow();
			dtRightCode.Rows.Add(dr);
			this.gridControlMd_RightCode.Refresh();
			this.gridViewMd_RightCode.FocusedRowHandle = dtRightCode.Rows.Count - 1;
		}

		private void btnRightCode_Del_Click(object sender, System.EventArgs e)
		{
			DataRow row = this.gridViewMd_RightCode.GetDataRow(gridViewMd_RightCode.FocusedRowHandle);
			if (row != null)
			{
	
				if (AddNewRightCode)
				{
					AddNewRightCode = false;
					gridViewMd_RightCode.DeleteRow(gridViewMd_RightCode.FocusedRowHandle);
				}
				else
				{

					DialogResult result = MessageBox.Show(this, "Do you really want to delete record with Rights ID = " + row["nRightsID"].ToString(),
						"Delete?", MessageBoxButtons.YesNo);
					if (result == DialogResult.Yes)
					{
						try
						{
							SqlHelper.ExecuteNonQuery(connection,"del_Rights",
								new SqlParameter("@RightsID",Convert.ToInt32(row["nRightsID"]) )
								);
						}
						catch(Exception ex)
						{
							MessageBox.Show(ex.Message ,"Delete Process Failed");
							return;
						}
						MessageBox.Show("Record Deleted Successfully","Message");
					}
					mdRightCodeInit();
				}
			}
		}

		private void gridViewMd_RightCode_LostFocus(object sender, System.EventArgs e)
		{
			DataRow row = this.gridViewMd_RightCode.GetDataRow(gridViewMd_RightCode.FocusedRowHandle);
		
			string strSQL = "select * from tblRights where nRightsID=" + row["nRightsID"];
			
			if (AddNewRightCode)
			{
				if( FieldRightCodeChecking(row))
				{
					this.gridControlMd_RightCode.MainView.UpdateCurrentRow();
					CreateCmdsAndUpdate(strSQL,dtRightCode);
					AddNewRightCode = false;
				}
			}
			else
			{
				this.gridViewMd_RightCode.CloseEditor();
				this.gridViewMd_RightCode.UpdateCurrentRow();

				CreateCmdsAndUpdate(strSQL,dtRightCode);
			}
		}
		#endregion

		#region Right Level
	
		private void mdRightLevelInit()
		{
			string strSQL;

			strSQL = "select * from tblRightsLevel";
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dtRightLevel = _ds.Tables["table"];
			this.gridControlMd_RightLevel.DataSource = dtRightLevel;
		}
	
		private bool FieldRightLevelChecking(DataRow dr)
		{
			if ( dr["nRightsLevelID"].ToString() == "" || dr["nEmployeeID"].ToString() == "")
				return false;
			return true;
		}

		private bool AddNewRightLevel;
		private void btnRightLevel_Add_Click(object sender, System.EventArgs e)
		{
			AddNewRightLevel = true;
			DataRow dr = dtRightLevel.NewRow();
			dtRightLevel.Rows.Add(dr);
			this.gridControlMd_RightLevel.Refresh();
			this.gridViewMd_RightLevel.FocusedRowHandle = dtRightLevel.Rows.Count - 1;
		}

		private void gridViewMd_RightLevel_LostFocus(object sender, System.EventArgs e)
		{
			DataRow row = this.gridViewMd_RightLevel.GetDataRow(gridViewMd_RightLevel.FocusedRowHandle);
		
			string strSQL = "select * from tblRightsLevel";
			
			if (AddNewRightLevel)
			{
				if( FieldRightLevelChecking(row))
				{
					this.gridControlMd_RightLevel.MainView.UpdateCurrentRow();
					CreateCmdsAndUpdate(strSQL,dtRightLevel);
					AddNewRightLevel = false;
				}
			}
			else
			{
				this.gridViewMd_RightLevel.CloseEditor();
				this.gridViewMd_RightLevel.UpdateCurrentRow();

				CreateCmdsAndUpdate(strSQL,dtRightLevel);
			}
		}

		private void btnRightLevel_Del_Click(object sender, System.EventArgs e)
		{
			DataRow row = this.gridViewMd_RightLevel.GetDataRow(gridViewMd_RightLevel.FocusedRowHandle);
			if (row != null)
			{	
				if (AddNewRightLevel)
				{
					AddNewRightLevel = false;
					gridViewMd_RightLevel.DeleteRow(gridViewMd_RightLevel.FocusedRowHandle);
				}
				else
				{

					DialogResult result = MessageBox.Show(this, "Do you really want to delete record with Rights Level ID = " + row["nRightsLevelID"].ToString(),
						"Delete?", MessageBoxButtons.YesNo);
					if (result == DialogResult.Yes)
					{
						try
						{
							SqlHelper.ExecuteNonQuery(connection,"del_RightsLevel",
								new SqlParameter("@branchCode",Convert.ToInt32(row["nRightsLevelID"]) )
								);
						}
						catch(Exception ex)
						{
							MessageBox.Show(ex.Message ,"Delete Process Failed");
							return;
						}
						MessageBox.Show("Record Deleted Successfully","Message");
					}
					mdRightLevelInit();
				}
			}
		}
	
		#endregion

		#region Rights Entries
		private bool AddNewRightLevelEntries = false;
		private void mdRightLevelEntriesInit()
		{
			string strSQL;

			strSQL = "select * from tblRightsLevelEntries";
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dtRightLevelEntries = _ds.Tables["table"];
			this.gridControlMd_RightLevelEntries.DataSource = dtRightLevelEntries;
			}
		private void btnRLEntries_Del_Click(object sender, System.EventArgs e)
		{
			DataRow row = this.gridViewRightLevelEntries.GetDataRow(gridViewRightLevelEntries.FocusedRowHandle);
			if (row != null)
			{	
				if (AddNewRightLevelEntries)
				{
					AddNewRightLevelEntries = false;
					this.gridViewRightLevelEntries.DeleteRow(gridViewRightLevelEntries.FocusedRowHandle);
				}
				else
				{

					DialogResult result = MessageBox.Show(this, "Do you really want to delete record with Rights Level ID = " + row["nRightsLevelID"].ToString() + " And Rights ID = " + row["nRightsID"],
						"Delete?", MessageBoxButtons.YesNo);
					if (result == DialogResult.Yes)
					{
						try
						{
							SqlHelper.ExecuteNonQuery(connection,"del_RightsLevelEntries",
								new SqlParameter("@RightsLevelID",Convert.ToInt32(row["nRightsLevelID"]) ),
								new SqlParameter("@Right",Convert.ToInt32(row["nRightsID"]) )
                                );
						}
						catch(Exception ex)
						{
							MessageBox.Show(ex.Message ,"Delete Process Failed");
							return;
						}
						MessageBox.Show("Record Deleted Successfully","Message");
					}
					mdRightLevelEntriesInit();
				}
			}
		}

		private void btnRLEntries_Add_Click(object sender, System.EventArgs e)
		{
			AddNewRightLevelEntries = true;
			DataRow dr = dtRightLevelEntries.NewRow();
			dtRightLevelEntries.Rows.Add(dr);
			this.gridControlMd_RightLevelEntries.Refresh();
			this.gridViewRightLevelEntries.FocusedRowHandle = dtRightLevelEntries.Rows.Count - 1;
		}

		private bool FieldRightLevelEntriesChecking(DataRow dr)
		{
			if ( dr["nRightsLevelID"].ToString() == "" || dr["nRightsID"].ToString() == "")
				return false;
			return true;
		}

		private void gridViewRightLevelEntries_LostFocus(object sender, System.EventArgs e)
		{
			DataRow row = this.gridViewRightLevelEntries.GetDataRow(gridViewRightLevelEntries.FocusedRowHandle);
		
			string strSQL = "select * from tblRightsLevelEntries";
			
			if (AddNewRightLevelEntries)
			{
				if( FieldRightLevelEntriesChecking(row))
				{
					this.gridControlMd_RightLevelEntries.MainView.UpdateCurrentRow();
					CreateCmdsAndUpdate(strSQL,dtRightLevelEntries);
					AddNewRightLevelEntries = false;
				}
			}
			else
			{
				this.gridViewRightLevelEntries.CloseEditor();
				this.gridViewRightLevelEntries.UpdateCurrentRow();

				CreateCmdsAndUpdate(strSQL,dtRightLevelEntries);
			}
		}

		#endregion

		
		private void btnPcSearch_Click(object sender, System.EventArgs e)
		{
			ACMS.ACMSManager.frmSearchEmployee myForm = new ACMS.ACMSManager.frmSearchEmployee(ddlMember.EditValue.ToString());
			if (DialogResult.OK == myForm.ShowDialog(this))
			{
				ddlMember.EditValue = myForm.StrEmployeeID;
				this.mdBranchRightInit();
			}
			myForm.Dispose();
		}

		private void btnPcReset_Click(object sender, System.EventArgs e)
		{
			ddlMember.EditValue = "";
			mdBranchRightInit();
		}

	
	
	
	}
}
