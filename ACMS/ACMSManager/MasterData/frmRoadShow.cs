using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;
using ACMS.Utils;
using System.Data.OleDb;
using DevExpress.XtraGrid.Views.Grid;
using ACMS.XtraUtils.LookupEditBuilder;

namespace ACMS.ACMSManager.MasterData
{
	/// <summary>
	/// Summary description for frmRoadShow.
	/// </summary>
	public class frmRoadShow : System.Windows.Forms.Form
	{
		#region windows control

		private string connectionString;
		private SqlConnection connection;
        private DevExpress.XtraEditors.GroupControl grpMDPackageTop;
		private DevExpress.XtraEditors.GroupControl grpPackage;
		private DevExpress.XtraEditors.GroupControl grpPackageGroup;
		private DevExpress.XtraEditors.GroupControl groupControl1;
		private DevExpress.XtraGrid.GridControl gridControlMd_BranchRoadShow;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewMd_BranchRoadShow;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPKG1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnPKG7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPKG8;
		internal DevExpress.XtraEditors.SimpleButton btn_Add;
		internal DevExpress.XtraEditors.SimpleButton btn_PackageDel;
        private System.Windows.Forms.ImageList imageList1;
		private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit StartDate;
		private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit EndDate;
        private System.ComponentModel.IContainer components;
		private DevExpress.XtraEditors.GroupControl groupControl4;
		private DevExpress.XtraGrid.GridControl gridControlMd_PackageGroup;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewMd_PackageGroup;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnPG1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnPG2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnPG3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnPG4;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnPG5;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnPG6;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_pkGroupCatID;		
		private DevExpress.XtraEditors.GroupControl grpCreditPackage;
		internal DevExpress.XtraEditors.SimpleButton btnCreditPackage_Add;
		internal DevExpress.XtraEditors.SimpleButton btnCreditPackage_Del;
		private DevExpress.XtraEditors.GroupControl groupControl5;
		private DevExpress.XtraGrid.GridControl gridControlMd_CreditPackage;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewMd_CreditPackage;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnCP1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnCP2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnCP3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnCP4;
		private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit EffCCStartDate;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnCP5;
		private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit EffCCEndDate;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnCP6;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_CreditCategoryID;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnCP7;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnCP8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCP9;
		internal DevExpress.XtraEditors.SimpleButton btnPacGroup_Add;
        internal DevExpress.XtraEditors.SimpleButton btnPacGroup_Del;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn29;
        private Label label31;
        private DevExpress.XtraEditors.ImageComboBoxEdit ddlBranchCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_BranchCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPKG9;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit tedit_RoadShowTitle;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPKG10;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit tedit_strType;
        private DataTable dtBranchRoadShow;
	#endregion
		public frmRoadShow()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRoadShow));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.grpMDPackageTop = new DevExpress.XtraEditors.GroupControl();
            this.label31 = new System.Windows.Forms.Label();
            this.ddlBranchCode = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.grpPackage = new DevExpress.XtraEditors.GroupControl();
            this.btn_Add = new DevExpress.XtraEditors.SimpleButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btn_PackageDel = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gridControlMd_BranchRoadShow = new DevExpress.XtraGrid.GridControl();
            this.gridViewMd_BranchRoadShow = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnPKG1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lk_BranchCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumnPKG7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EndDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.gridColumnPKG8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.StartDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.grpPackageGroup = new DevExpress.XtraEditors.GroupControl();
            this.btnPacGroup_Add = new DevExpress.XtraEditors.SimpleButton();
            this.btnPacGroup_Del = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.gridControlMd_PackageGroup = new DevExpress.XtraGrid.GridControl();
            this.gridViewMd_PackageGroup = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnPG1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPG2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPG3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPG4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lk_pkGroupCatID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumnPG5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPG6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grpCreditPackage = new DevExpress.XtraEditors.GroupControl();
            this.btnCreditPackage_Add = new DevExpress.XtraEditors.SimpleButton();
            this.btnCreditPackage_Del = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
            this.gridControlMd_CreditPackage = new DevExpress.XtraGrid.GridControl();
            this.gridViewMd_CreditPackage = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnCP1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCP2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCP3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCP4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EffCCStartDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.gridColumnCP5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EffCCEndDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.gridColumnCP6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lk_CreditCategoryID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn29 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCP7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCP8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCP9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPKG9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tedit_RoadShowTitle = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumnPKG10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tedit_strType = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMDPackageTop)).BeginInit();
            this.grpMDPackageTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlBranchCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpPackage)).BeginInit();
            this.grpPackage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMd_BranchRoadShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMd_BranchRoadShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_BranchCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndDate.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartDate.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpPackageGroup)).BeginInit();
            this.grpPackageGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMd_PackageGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMd_PackageGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_pkGroupCatID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpCreditPackage)).BeginInit();
            this.grpCreditPackage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
            this.groupControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMd_CreditPackage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMd_CreditPackage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EffCCStartDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EffCCStartDate.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EffCCEndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EffCCEndDate.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_CreditCategoryID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tedit_RoadShowTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tedit_strType)).BeginInit();
            this.SuspendLayout();
            // 
            // grpMDPackageTop
            // 
            this.grpMDPackageTop.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.grpMDPackageTop.Appearance.Options.UseBackColor = true;
            this.grpMDPackageTop.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMDPackageTop.AppearanceCaption.Options.UseFont = true;
            this.grpMDPackageTop.Controls.Add(this.label31);
            this.grpMDPackageTop.Controls.Add(this.ddlBranchCode);
            this.grpMDPackageTop.Controls.Add(this.grpPackage);
            this.grpMDPackageTop.Controls.Add(this.grpPackageGroup);
            this.grpMDPackageTop.Controls.Add(this.grpCreditPackage);
            this.grpMDPackageTop.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grpMDPackageTop.Location = new System.Drawing.Point(8, 2);
            this.grpMDPackageTop.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.grpMDPackageTop.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grpMDPackageTop.Name = "grpMDPackageTop";
            this.grpMDPackageTop.Size = new System.Drawing.Size(968, 280);
            this.grpMDPackageTop.TabIndex = 93;
            this.grpMDPackageTop.Text = "MASTER FILE";
            // 
            // label31
            // 
            this.label31.BackColor = System.Drawing.Color.Transparent;
            this.label31.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(8, 24);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(136, 16);
            this.label31.TabIndex = 116;
            this.label31.Text = "Branch Code";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ddlBranchCode
            // 
            this.ddlBranchCode.EditValue = "mdPKG_cbNCategoryID";
            this.ddlBranchCode.Location = new System.Drawing.Point(144, 24);
            this.ddlBranchCode.Name = "ddlBranchCode";
            this.ddlBranchCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlBranchCode.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.ddlBranchCode.Size = new System.Drawing.Size(176, 20);
            this.ddlBranchCode.TabIndex = 19;
            this.ddlBranchCode.SelectedIndexChanged += new System.EventHandler(this.ddlBranchCode_SelectedIndexChanged);
            // 
            // grpPackage
            // 
            this.grpPackage.Controls.Add(this.btn_Add);
            this.grpPackage.Controls.Add(this.btn_PackageDel);
            this.grpPackage.Controls.Add(this.groupControl1);
            this.grpPackage.Location = new System.Drawing.Point(0, 48);
            this.grpPackage.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.grpPackage.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grpPackage.Name = "grpPackage";
            this.grpPackage.Size = new System.Drawing.Size(960, 232);
            this.grpPackage.TabIndex = 118;
            this.grpPackage.Text = "Branch Road Show";
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
            // btn_PackageDel
            // 
            this.btn_PackageDel.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PackageDel.Appearance.Options.UseFont = true;
            this.btn_PackageDel.Appearance.Options.UseTextOptions = true;
            this.btn_PackageDel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btn_PackageDel.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.btn_PackageDel.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btn_PackageDel.ImageIndex = 1;
            this.btn_PackageDel.ImageList = this.imageList1;
            this.btn_PackageDel.Location = new System.Drawing.Point(48, 24);
            this.btn_PackageDel.Name = "btn_PackageDel";
            this.btn_PackageDel.Size = new System.Drawing.Size(38, 16);
            this.btn_PackageDel.TabIndex = 131;
            this.btn_PackageDel.Click += new System.EventHandler(this.btn_PackageDel_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl1.Controls.Add(this.gridControlMd_BranchRoadShow);
            this.groupControl1.Location = new System.Drawing.Point(0, 40);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(952, 192);
            this.groupControl1.TabIndex = 121;
            // 
            // gridControlMd_BranchRoadShow
            // 
            this.gridControlMd_BranchRoadShow.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.RelationName = "Level1";
            this.gridControlMd_BranchRoadShow.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControlMd_BranchRoadShow.Location = new System.Drawing.Point(0, 0);
            this.gridControlMd_BranchRoadShow.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControlMd_BranchRoadShow.MainView = this.gridViewMd_BranchRoadShow;
            this.gridControlMd_BranchRoadShow.Name = "gridControlMd_BranchRoadShow";
            this.gridControlMd_BranchRoadShow.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.StartDate,
            this.EndDate,
            this.lk_BranchCode,
            this.tedit_RoadShowTitle,
            this.tedit_strType});
            this.gridControlMd_BranchRoadShow.Size = new System.Drawing.Size(952, 192);
            this.gridControlMd_BranchRoadShow.TabIndex = 2;
            this.gridControlMd_BranchRoadShow.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMd_BranchRoadShow});
            // 
            // gridViewMd_BranchRoadShow
            // 
            this.gridViewMd_BranchRoadShow.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnPKG1,
            this.gridColumnPKG7,
            this.gridColumnPKG8,
            this.gridColumnPKG9,
            this.gridColumnPKG10});
            this.gridViewMd_BranchRoadShow.GridControl = this.gridControlMd_BranchRoadShow;
            this.gridViewMd_BranchRoadShow.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridViewMd_BranchRoadShow.Name = "gridViewMd_BranchRoadShow";
            this.gridViewMd_BranchRoadShow.OptionsCustomization.AllowFilter = false;
            this.gridViewMd_BranchRoadShow.OptionsCustomization.AllowSort = false;
            this.gridViewMd_BranchRoadShow.OptionsView.ColumnAutoWidth = false;
            this.gridViewMd_BranchRoadShow.OptionsView.ShowGroupPanel = false;
            this.gridViewMd_BranchRoadShow.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridViewMd_BranchRoadShow.LostFocus += new System.EventHandler(this.gridViewMd_BranchRoadShow_LostFocus);
            // 
            // gridColumnPKG1
            // 
            this.gridColumnPKG1.Caption = "Branch Code";
            this.gridColumnPKG1.ColumnEdit = this.lk_BranchCode;
            this.gridColumnPKG1.FieldName = "strBranchCode";
            this.gridColumnPKG1.Name = "gridColumnPKG1";
            this.gridColumnPKG1.Visible = true;
            this.gridColumnPKG1.VisibleIndex = 0;
            this.gridColumnPKG1.Width = 84;
            // 
            // lk_BranchCode
            // 
            this.lk_BranchCode.AutoHeight = false;
            this.lk_BranchCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lk_BranchCode.Name = "lk_BranchCode";
            // 
            // gridColumnPKG7
            // 
            this.gridColumnPKG7.Caption = "Date To";
            this.gridColumnPKG7.ColumnEdit = this.EndDate;
            this.gridColumnPKG7.FieldName = "dtTo";
            this.gridColumnPKG7.Name = "gridColumnPKG7";
            this.gridColumnPKG7.Visible = true;
            this.gridColumnPKG7.VisibleIndex = 2;
            this.gridColumnPKG7.Width = 89;
            // 
            // EndDate
            // 
            this.EndDate.AutoHeight = false;
            this.EndDate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.EndDate.Name = "EndDate";
            this.EndDate.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // gridColumnPKG8
            // 
            this.gridColumnPKG8.Caption = "Date From";
            this.gridColumnPKG8.ColumnEdit = this.StartDate;
            this.gridColumnPKG8.FieldName = "dtFrom";
            this.gridColumnPKG8.Name = "gridColumnPKG8";
            this.gridColumnPKG8.Visible = true;
            this.gridColumnPKG8.VisibleIndex = 1;
            // 
            // StartDate
            // 
            this.StartDate.AutoHeight = false;
            this.StartDate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.StartDate.Name = "StartDate";
            this.StartDate.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // grpPackageGroup
            // 
            this.grpPackageGroup.Controls.Add(this.btnPacGroup_Add);
            this.grpPackageGroup.Controls.Add(this.btnPacGroup_Del);
            this.grpPackageGroup.Controls.Add(this.groupControl4);
            this.grpPackageGroup.Location = new System.Drawing.Point(0, 48);
            this.grpPackageGroup.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.grpPackageGroup.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grpPackageGroup.Name = "grpPackageGroup";
            this.grpPackageGroup.Size = new System.Drawing.Size(960, 232);
            this.grpPackageGroup.TabIndex = 119;
            this.grpPackageGroup.Text = "Package Group";
            // 
            // btnPacGroup_Add
            // 
            this.btnPacGroup_Add.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPacGroup_Add.Appearance.Options.UseFont = true;
            this.btnPacGroup_Add.Appearance.Options.UseTextOptions = true;
            this.btnPacGroup_Add.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnPacGroup_Add.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.btnPacGroup_Add.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnPacGroup_Add.ImageIndex = 0;
            this.btnPacGroup_Add.ImageList = this.imageList1;
            this.btnPacGroup_Add.ImeMode = System.Windows.Forms.ImeMode.On;
            this.btnPacGroup_Add.Location = new System.Drawing.Point(8, 24);
            this.btnPacGroup_Add.Name = "btnPacGroup_Add";
            this.btnPacGroup_Add.Size = new System.Drawing.Size(38, 16);
            this.btnPacGroup_Add.TabIndex = 134;
            // 
            // btnPacGroup_Del
            // 
            this.btnPacGroup_Del.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPacGroup_Del.Appearance.Options.UseFont = true;
            this.btnPacGroup_Del.Appearance.Options.UseTextOptions = true;
            this.btnPacGroup_Del.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnPacGroup_Del.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.btnPacGroup_Del.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnPacGroup_Del.ImageIndex = 1;
            this.btnPacGroup_Del.ImageList = this.imageList1;
            this.btnPacGroup_Del.Location = new System.Drawing.Point(48, 24);
            this.btnPacGroup_Del.Name = "btnPacGroup_Del";
            this.btnPacGroup_Del.Size = new System.Drawing.Size(38, 16);
            this.btnPacGroup_Del.TabIndex = 133;
            // 
            // groupControl4
            // 
            this.groupControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl4.Controls.Add(this.gridControlMd_PackageGroup);
            this.groupControl4.Location = new System.Drawing.Point(0, 40);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(944, 184);
            this.groupControl4.TabIndex = 2;
            // 
            // gridControlMd_PackageGroup
            // 
            this.gridControlMd_PackageGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlMd_PackageGroup.Location = new System.Drawing.Point(0, 0);
            this.gridControlMd_PackageGroup.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControlMd_PackageGroup.MainView = this.gridViewMd_PackageGroup;
            this.gridControlMd_PackageGroup.Name = "gridControlMd_PackageGroup";
            this.gridControlMd_PackageGroup.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lk_pkGroupCatID});
            this.gridControlMd_PackageGroup.Size = new System.Drawing.Size(944, 184);
            this.gridControlMd_PackageGroup.TabIndex = 2;
            this.gridControlMd_PackageGroup.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMd_PackageGroup});
            // 
            // gridViewMd_PackageGroup
            // 
            this.gridViewMd_PackageGroup.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnPG1,
            this.gridColumnPG2,
            this.gridColumnPG3,
            this.gridColumnPG4,
            this.gridColumnPG5,
            this.gridColumnPG6});
            this.gridViewMd_PackageGroup.GridControl = this.gridControlMd_PackageGroup;
            this.gridViewMd_PackageGroup.Name = "gridViewMd_PackageGroup";
            this.gridViewMd_PackageGroup.OptionsCustomization.AllowFilter = false;
            this.gridViewMd_PackageGroup.OptionsCustomization.AllowSort = false;
            this.gridViewMd_PackageGroup.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumnPG1
            // 
            this.gridColumnPG1.Caption = "Package Group Code";
            this.gridColumnPG1.FieldName = "strPackageGroupCode";
            this.gridColumnPG1.Name = "gridColumnPG1";
            this.gridColumnPG1.Visible = true;
            this.gridColumnPG1.VisibleIndex = 0;
            // 
            // gridColumnPG2
            // 
            this.gridColumnPG2.Caption = "Description";
            this.gridColumnPG2.FieldName = "strDescription";
            this.gridColumnPG2.Name = "gridColumnPG2";
            this.gridColumnPG2.Visible = true;
            this.gridColumnPG2.VisibleIndex = 1;
            // 
            // gridColumnPG3
            // 
            this.gridColumnPG3.Caption = "Price";
            this.gridColumnPG3.DisplayFormat.FormatString = "d2";
            this.gridColumnPG3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnPG3.FieldName = "mListPrice";
            this.gridColumnPG3.Name = "gridColumnPG3";
            this.gridColumnPG3.Visible = true;
            this.gridColumnPG3.VisibleIndex = 2;
            // 
            // gridColumnPG4
            // 
            this.gridColumnPG4.Caption = "Package Category";
            this.gridColumnPG4.ColumnEdit = this.lk_pkGroupCatID;
            this.gridColumnPG4.FieldName = "nCategoryID";
            this.gridColumnPG4.Name = "gridColumnPG4";
            this.gridColumnPG4.Visible = true;
            this.gridColumnPG4.VisibleIndex = 3;
            // 
            // lk_pkGroupCatID
            // 
            this.lk_pkGroupCatID.AutoHeight = false;
            this.lk_pkGroupCatID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lk_pkGroupCatID.Name = "lk_pkGroupCatID";
            // 
            // gridColumnPG5
            // 
            this.gridColumnPG5.Caption = "Eff.Start Date";
            this.gridColumnPG5.FieldName = "dtValidStart";
            this.gridColumnPG5.Name = "gridColumnPG5";
            this.gridColumnPG5.Visible = true;
            this.gridColumnPG5.VisibleIndex = 4;
            // 
            // gridColumnPG6
            // 
            this.gridColumnPG6.Caption = "Eff.End Date";
            this.gridColumnPG6.FieldName = "dtValidEnd";
            this.gridColumnPG6.Name = "gridColumnPG6";
            this.gridColumnPG6.Visible = true;
            this.gridColumnPG6.VisibleIndex = 5;
            // 
            // grpCreditPackage
            // 
            this.grpCreditPackage.Controls.Add(this.btnCreditPackage_Add);
            this.grpCreditPackage.Controls.Add(this.btnCreditPackage_Del);
            this.grpCreditPackage.Controls.Add(this.groupControl5);
            this.grpCreditPackage.Location = new System.Drawing.Point(0, 48);
            this.grpCreditPackage.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.grpCreditPackage.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grpCreditPackage.Name = "grpCreditPackage";
            this.grpCreditPackage.Size = new System.Drawing.Size(960, 232);
            this.grpCreditPackage.TabIndex = 121;
            this.grpCreditPackage.Text = "Credit Package";
            // 
            // btnCreditPackage_Add
            // 
            this.btnCreditPackage_Add.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreditPackage_Add.Appearance.Options.UseFont = true;
            this.btnCreditPackage_Add.Appearance.Options.UseTextOptions = true;
            this.btnCreditPackage_Add.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnCreditPackage_Add.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.btnCreditPackage_Add.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnCreditPackage_Add.ImageIndex = 0;
            this.btnCreditPackage_Add.ImageList = this.imageList1;
            this.btnCreditPackage_Add.ImeMode = System.Windows.Forms.ImeMode.On;
            this.btnCreditPackage_Add.Location = new System.Drawing.Point(8, 24);
            this.btnCreditPackage_Add.Name = "btnCreditPackage_Add";
            this.btnCreditPackage_Add.Size = new System.Drawing.Size(38, 16);
            this.btnCreditPackage_Add.TabIndex = 136;
            // 
            // btnCreditPackage_Del
            // 
            this.btnCreditPackage_Del.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreditPackage_Del.Appearance.Options.UseFont = true;
            this.btnCreditPackage_Del.Appearance.Options.UseTextOptions = true;
            this.btnCreditPackage_Del.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnCreditPackage_Del.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.btnCreditPackage_Del.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnCreditPackage_Del.ImageIndex = 1;
            this.btnCreditPackage_Del.ImageList = this.imageList1;
            this.btnCreditPackage_Del.Location = new System.Drawing.Point(48, 24);
            this.btnCreditPackage_Del.Name = "btnCreditPackage_Del";
            this.btnCreditPackage_Del.Size = new System.Drawing.Size(38, 16);
            this.btnCreditPackage_Del.TabIndex = 135;
            // 
            // groupControl5
            // 
            this.groupControl5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl5.Controls.Add(this.gridControlMd_CreditPackage);
            this.groupControl5.Location = new System.Drawing.Point(0, 40);
            this.groupControl5.Name = "groupControl5";
            this.groupControl5.Size = new System.Drawing.Size(952, 192);
            this.groupControl5.TabIndex = 2;
            this.groupControl5.Text = "groupControl5";
            // 
            // gridControlMd_CreditPackage
            // 
            this.gridControlMd_CreditPackage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlMd_CreditPackage.Location = new System.Drawing.Point(0, 0);
            this.gridControlMd_CreditPackage.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControlMd_CreditPackage.MainView = this.gridViewMd_CreditPackage;
            this.gridControlMd_CreditPackage.Name = "gridControlMd_CreditPackage";
            this.gridControlMd_CreditPackage.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lk_CreditCategoryID,
            this.EffCCStartDate,
            this.EffCCEndDate});
            this.gridControlMd_CreditPackage.Size = new System.Drawing.Size(952, 192);
            this.gridControlMd_CreditPackage.TabIndex = 2;
            this.gridControlMd_CreditPackage.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMd_CreditPackage});
            // 
            // gridViewMd_CreditPackage
            // 
            this.gridViewMd_CreditPackage.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnCP1,
            this.gridColumnCP2,
            this.gridColumn24,
            this.gridColumnCP3,
            this.gridColumnCP4,
            this.gridColumnCP5,
            this.gridColumnCP6,
            this.gridColumn29,
            this.gridColumnCP7,
            this.gridColumnCP8,
            this.gridColumnCP9});
            this.gridViewMd_CreditPackage.GridControl = this.gridControlMd_CreditPackage;
            this.gridViewMd_CreditPackage.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridViewMd_CreditPackage.Name = "gridViewMd_CreditPackage";
            this.gridViewMd_CreditPackage.OptionsCustomization.AllowFilter = false;
            this.gridViewMd_CreditPackage.OptionsCustomization.AllowSort = false;
            this.gridViewMd_CreditPackage.OptionsView.ColumnAutoWidth = false;
            this.gridViewMd_CreditPackage.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumnCP1
            // 
            this.gridColumnCP1.Caption = "Credit Package Code";
            this.gridColumnCP1.FieldName = "strCreditPackageCode";
            this.gridColumnCP1.Name = "gridColumnCP1";
            this.gridColumnCP1.Visible = true;
            this.gridColumnCP1.VisibleIndex = 0;
            this.gridColumnCP1.Width = 111;
            // 
            // gridColumnCP2
            // 
            this.gridColumnCP2.Caption = "Description";
            this.gridColumnCP2.FieldName = "strDescription";
            this.gridColumnCP2.Name = "gridColumnCP2";
            this.gridColumnCP2.Visible = true;
            this.gridColumnCP2.VisibleIndex = 1;
            this.gridColumnCP2.Width = 200;
            // 
            // gridColumn24
            // 
            this.gridColumn24.Caption = "Receipt Description";
            this.gridColumn24.FieldName = "strReceiptDesc";
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.Visible = true;
            this.gridColumn24.VisibleIndex = 10;
            this.gridColumn24.Width = 262;
            // 
            // gridColumnCP3
            // 
            this.gridColumnCP3.Caption = "Price";
            this.gridColumnCP3.DisplayFormat.FormatString = "d2";
            this.gridColumnCP3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnCP3.FieldName = "mListPrice";
            this.gridColumnCP3.Name = "gridColumnCP3";
            this.gridColumnCP3.Visible = true;
            this.gridColumnCP3.VisibleIndex = 2;
            // 
            // gridColumnCP4
            // 
            this.gridColumnCP4.Caption = "Eff.Start Date";
            this.gridColumnCP4.ColumnEdit = this.EffCCStartDate;
            this.gridColumnCP4.FieldName = "dtValidStart";
            this.gridColumnCP4.Name = "gridColumnCP4";
            this.gridColumnCP4.Visible = true;
            this.gridColumnCP4.VisibleIndex = 3;
            this.gridColumnCP4.Width = 98;
            // 
            // EffCCStartDate
            // 
            this.EffCCStartDate.AutoHeight = false;
            this.EffCCStartDate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.EffCCStartDate.Name = "EffCCStartDate";
            this.EffCCStartDate.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // gridColumnCP5
            // 
            this.gridColumnCP5.Caption = "Eff.End Date";
            this.gridColumnCP5.ColumnEdit = this.EffCCEndDate;
            this.gridColumnCP5.FieldName = "dtValidEnd";
            this.gridColumnCP5.Name = "gridColumnCP5";
            this.gridColumnCP5.Visible = true;
            this.gridColumnCP5.VisibleIndex = 4;
            this.gridColumnCP5.Width = 91;
            // 
            // EffCCEndDate
            // 
            this.EffCCEndDate.AutoHeight = false;
            this.EffCCEndDate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.EffCCEndDate.Name = "EffCCEndDate";
            this.EffCCEndDate.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // gridColumnCP6
            // 
            this.gridColumnCP6.Caption = "Category";
            this.gridColumnCP6.ColumnEdit = this.lk_CreditCategoryID;
            this.gridColumnCP6.FieldName = "nCategoryID";
            this.gridColumnCP6.Name = "gridColumnCP6";
            this.gridColumnCP6.OptionsColumn.AllowEdit = false;
            this.gridColumnCP6.Visible = true;
            this.gridColumnCP6.VisibleIndex = 5;
            this.gridColumnCP6.Width = 97;
            // 
            // lk_CreditCategoryID
            // 
            this.lk_CreditCategoryID.AutoHeight = false;
            this.lk_CreditCategoryID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lk_CreditCategoryID.Name = "lk_CreditCategoryID";
            // 
            // gridColumn29
            // 
            this.gridColumn29.Caption = "Upgrade Group";
            this.gridColumn29.FieldName = "fNoRestrictionUpgrade";
            this.gridColumn29.Name = "gridColumn29";
            this.gridColumn29.Visible = true;
            this.gridColumn29.VisibleIndex = 7;
            this.gridColumn29.Width = 65;
            // 
            // gridColumnCP7
            // 
            this.gridColumnCP7.Caption = "Valid Months";
            this.gridColumnCP7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnCP7.FieldName = "nValidMonths";
            this.gridColumnCP7.Name = "gridColumnCP7";
            this.gridColumnCP7.Visible = true;
            this.gridColumnCP7.VisibleIndex = 6;
            // 
            // gridColumnCP8
            // 
            this.gridColumnCP8.Caption = "Credit Amount";
            this.gridColumnCP8.DisplayFormat.FormatString = "d2";
            this.gridColumnCP8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnCP8.FieldName = "mCreditAmount";
            this.gridColumnCP8.Name = "gridColumnCP8";
            this.gridColumnCP8.Visible = true;
            this.gridColumnCP8.VisibleIndex = 8;
            this.gridColumnCP8.Width = 80;
            // 
            // gridColumnCP9
            // 
            this.gridColumnCP9.Caption = "Credit discount";
            this.gridColumnCP9.DisplayFormat.FormatString = "d2";
            this.gridColumnCP9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnCP9.FieldName = "dCreditDiscount";
            this.gridColumnCP9.Name = "gridColumnCP9";
            this.gridColumnCP9.Visible = true;
            this.gridColumnCP9.VisibleIndex = 9;
            this.gridColumnCP9.Width = 80;
            // 
            // gridColumnPKG9
            // 
            this.gridColumnPKG9.Caption = "Title";
            this.gridColumnPKG9.ColumnEdit = this.tedit_RoadShowTitle;
            this.gridColumnPKG9.FieldName = "RoadShowTitle";
            this.gridColumnPKG9.Name = "gridColumnPKG9";
            this.gridColumnPKG9.Visible = true;
            this.gridColumnPKG9.VisibleIndex = 3;
            // 
            // tedit_RoadShowTitle
            // 
            this.tedit_RoadShowTitle.AutoHeight = false;
            this.tedit_RoadShowTitle.MaxLength = 50;
            this.tedit_RoadShowTitle.Name = "tedit_RoadShowTitle";
            // 
            // gridColumnPKG10
            // 
            this.gridColumnPKG10.Caption = "Type";
            this.gridColumnPKG10.ColumnEdit = this.tedit_strType;
            this.gridColumnPKG10.FieldName = "strType";
            this.gridColumnPKG10.Name = "gridColumnPKG10";
            this.gridColumnPKG10.Visible = true;
            this.gridColumnPKG10.VisibleIndex = 4;
            // 
            // tedit_strType
            // 
            this.tedit_strType.AutoHeight = false;
            this.tedit_strType.MaxLength = 50;
            this.tedit_strType.Name = "tedit_strType";
            // 
            // frmRoadShow
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(982, 600);
            this.Controls.Add(this.grpMDPackageTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRoadShow";
            this.Text = "frmRoadShow";
            this.Load += new System.EventHandler(this.frmRoadShow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpMDPackageTop)).EndInit();
            this.grpMDPackageTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ddlBranchCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpPackage)).EndInit();
            this.grpPackage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMd_BranchRoadShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMd_BranchRoadShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_BranchCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndDate.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartDate.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpPackageGroup)).EndInit();
            this.grpPackageGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMd_PackageGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMd_PackageGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_pkGroupCatID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpCreditPackage)).EndInit();
            this.grpCreditPackage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
            this.groupControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMd_CreditPackage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMd_CreditPackage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EffCCStartDate.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EffCCStartDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EffCCEndDate.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EffCCEndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_CreditCategoryID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tedit_RoadShowTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tedit_strType)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

	         
		
		private bool FieldCheckingPackageGrp(DataRow dr)
		{
			if (dr["strPackageGroupCode"] == null || dr["strPackageGroupCode"].ToString() == "")
				return false;

			return true;
		}

        private void frmRoadShow_Load(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.Controls.LookUpColumnInfo[] col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[1];
            string strSQL;
            DataSet _ds = new DataSet();
            DataTable dt;

            strSQL = "select * from tblBranch";
            comboBind(ddlBranchCode, strSQL, "strBranchCode", "strBranchCode");

            strSQL = "select * from tblBranch";
            _ds = new DataSet();
            SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA", _ds, new string[] { "table" }, new SqlParameter("@strSQL", strSQL));
            dt = _ds.Tables["table"];

            new ManagerBranchCodeLookupEditBuilder(dt, this.lk_BranchCode);

            strSQL = "select strBranchCode from tblBranchRoadShow";
            SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA", _ds, new string[] { "table" }, new SqlParameter("@strSQL", strSQL));
            dt = _ds.Tables["table"];

            col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[1];

            col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strBranchCode", "Branch Code", 15, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None);

            new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(lk_BranchCode, dt, col, "strBranchCode", "strBranchCode", "Branch Code");
            LoadBranchRoadShow();
        }
        private void LoadBranchRoadShow()
        {           
            string strSQL;
            strSQL = "select * from tblBranchRoadShow ";
            if (ddlBranchCode.EditValue.ToString() != "")
            {
                strSQL += " where strBranchCode = '" + ddlBranchCode.EditValue + "'";
            }

            DataSet _ds = new DataSet();
            SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA", _ds, new string[] { "table" }, new SqlParameter("@strSQL", strSQL));
            dtBranchRoadShow = _ds.Tables["table"];
            this.gridControlMd_BranchRoadShow.DataSource = dtBranchRoadShow;
        }       

        public void CreateCmdsAndUpdate(string mySelectQuery, DataTable myTableName)
        {
            SqlConnection myConn = new SqlConnection(connectionString);
            SqlDataAdapter myDataAdapter = new SqlDataAdapter();
            myDataAdapter.SelectCommand = new SqlCommand(mySelectQuery, myConn);
            SqlCommandBuilder custCB = new SqlCommandBuilder(myDataAdapter);

            myConn.Open();
            DataSet custDS = new DataSet();
            myDataAdapter.Fill(custDS);

            //code to modify data in dataset here
            myDataAdapter.Update(myTableName);
            myConn.Close();
        }

        private void comboBind(DevExpress.XtraEditors.ImageComboBoxEdit control, string strSQL, string display, string strValue)
        {

            DataSet _ds = new DataSet();
            SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA", _ds, new string[] { "Table" }, new SqlParameter("@strSQL", strSQL));
            DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox properties = control.Properties;
            properties.Items.BeginUpdate();
            properties.Items.Clear();

            try
            {
                foreach (DataRow dr in _ds.Tables["Table"].Rows)
                {
                    //Initialize each item with the display text, value and image index
                    properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr[display].ToString(), dr[strValue].ToString(), -1));
                }
            }
            finally
            {
                properties.Items.EndUpdate();
            }
            //Select the first item
            control.SelectedIndex = 0;
        }

        private void ddlBranchCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBranchRoadShow();
        }
        private bool FieldChecking(DataRow dr)
        {
            if (dr["strBranchCode"].ToString() == "")
                return false;

            if (dr["dtFrom"].ToString() == "")
                return false;

            if (dr["dtTo"].ToString() == "")
                return false;

            return true;
        }
        private bool AddNew = false;
        private void gridViewMd_BranchRoadShow_LostFocus(object sender, EventArgs e)
        {
            DataRow row = this.gridViewMd_BranchRoadShow.GetDataRow(gridViewMd_BranchRoadShow.FocusedRowHandle);

            string strSQL = "Select * from tblBranchRoadShow";
            if (AddNew)
            {
                if (FieldChecking(row))
                {
                    this.gridControlMd_BranchRoadShow.MainView.UpdateCurrentRow();
                    try
                    {
                        CreateCmdsAndUpdate(strSQL, dtBranchRoadShow);                     
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Insert Failed");
                        return;
                    }
                    AddNew = false;
                }
            }
            else
            {
                gridViewMd_BranchRoadShow.CloseEditor();
                gridViewMd_BranchRoadShow.UpdateCurrentRow();

                CreateCmdsAndUpdate(strSQL, dtBranchRoadShow);
            }
        }

        private void btn_PackageAdd_Click(object sender, EventArgs e)
        {

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {            

            AddNew = true;
            DataRow dr = dtBranchRoadShow.NewRow();

            dtBranchRoadShow.Rows.Add(dr);
            this.gridControlMd_BranchRoadShow.Refresh();
            this.gridViewMd_BranchRoadShow.FocusedRowHandle = dtBranchRoadShow.Rows.Count - 1;
        }

        private void btn_PackageDel_Click(object sender, EventArgs e)
        {
            DataRow row = this.gridViewMd_BranchRoadShow.GetDataRow(gridViewMd_BranchRoadShow.FocusedRowHandle);
            if (row != null)
            {
                if (AddNew)
                {
                    AddNew = false;
                    gridViewMd_BranchRoadShow.DeleteRow(gridViewMd_BranchRoadShow.FocusedRowHandle);
                }
                else
                {

                    DialogResult result = MessageBox.Show(this, "Do you really want to delete this record? ",
                        "Delete?", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {                            
                            SqlHelper.ExecuteNonQuery(connection, "del_BranchRoadShow",
                                new SqlParameter("@strBranchCode", row["strBranchCode"].ToString()),
                                new SqlParameter("@dtFrom", row["dtFrom"].ToString()),
                                new SqlParameter("@dtTo", row["dtTo"].ToString())
                            );
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Delete Process Failed");
                            return;
                        }
                        MessageBox.Show("Record Deleted Successfully", "Message");
                        LoadBranchRoadShow();
                    }
                }

            }
        }
	}
}
