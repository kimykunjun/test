using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;

namespace ACMS.ACMSManager.MasterData
{
	/// <summary>
	/// Summary description for frmBranch.
	/// </summary>
	public class frmBranch : System.Windows.Forms.Form
	{
		private ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder myManager;

		private string connectionString;
		private SqlConnection connection;
		private DevExpress.XtraEditors.GroupControl grpMdBranchBelow2;
		private DevExpress.XtraTab.XtraTabControl tabCtrlMd_Branch;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
		private DevExpress.XtraGrid.GridControl gridControlMd_BranchTarget;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
		private DevExpress.XtraGrid.GridControl gridControlMd_BranchReceipt;
		private DevExpress.XtraEditors.GroupControl grpMdBranchTop;
		private DevExpress.XtraGrid.GridControl gridControlMd_Branch;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewMd_BranchTarget;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewMd_BranchReceipt;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewMd_Branch;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
		private DevExpress.XtraGrid.Columns.GridColumn strBranchCode;
		private DevExpress.XtraGrid.Columns.GridColumn strBranchName;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_ManagerID;
		internal DevExpress.XtraEditors.SimpleButton sBtnSubtract;
		private System.Windows.Forms.ImageList imageList1;
		private DevExpress.XtraGrid.Columns.GridColumn ReceiptHeader1;
		private DevExpress.XtraGrid.Columns.GridColumn ReceiptHeader2;
		private DevExpress.XtraGrid.Columns.GridColumn ReceiptHeader3;
		private DevExpress.XtraGrid.Columns.GridColumn ReceiptHeader4;
		private DevExpress.XtraGrid.Columns.GridColumn LockerRental1;
		private DevExpress.XtraGrid.Columns.GridColumn LockerRental2;
		private DevExpress.XtraGrid.Columns.GridColumn LockerDepositRate;
		private DevExpress.XtraGrid.Columns.GridColumn LockerGracePeriod;
		private DevExpress.XtraGrid.Columns.GridColumn NonMembershipNo;
		private DevExpress.XtraGrid.Columns.GridColumn ManagerID;
		internal DevExpress.XtraEditors.SimpleButton btnBranchTarget_Add;
		internal DevExpress.XtraEditors.SimpleButton btnBranchTarget_Del;
		private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox mdBT_cbNYearID;
		private DevExpress.XtraGrid.Columns.GridColumn mdBT_txtMFitnessPackageTarget;
		private DevExpress.XtraGrid.Columns.GridColumn mdBT_txtMFitnessProductTarget;
		private DevExpress.XtraGrid.Columns.GridColumn mdBT_txtMSpaPackageTarget;
		private DevExpress.XtraGrid.Columns.GridColumn mdBT_txtMSpaProductTarget;
		private DevExpress.XtraGrid.Columns.GridColumn mdBT_txtMPTPackageTarget;
        private DevExpress.XtraGrid.Columns.GridColumn mdBT_txtMMergeTarget;
		private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox mdBT_cbNMonthID;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private System.ComponentModel.IContainer components;
		internal DevExpress.XtraEditors.SimpleButton sBtnAdd;
		internal DevExpress.XtraEditors.SimpleButton btnReceipt_Add;
		internal DevExpress.XtraEditors.SimpleButton btnReceipt_Del;
		private DataTable dtBranch;
		private DataTable dtBranchReceipt;
		private DevExpress.XtraGrid.Columns.GridColumn ReceiptHeader5;
		private DevExpress.XtraGrid.Columns.GridColumn ReceiptFooter;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chk_Status;
		private DataTable dtBranchTarget;

		public frmBranch()
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
			mdBranchInit();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBranch));
            this.grpMdBranchBelow2 = new DevExpress.XtraEditors.GroupControl();
            this.tabCtrlMd_Branch = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.btnBranchTarget_Add = new DevExpress.XtraEditors.SimpleButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnBranchTarget_Del = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlMd_BranchTarget = new DevExpress.XtraGrid.GridControl();
            this.gridViewMd_BranchTarget = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mdBT_cbNYearID = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mdBT_cbNMonthID = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.mdBT_txtMFitnessPackageTarget = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mdBT_txtMFitnessProductTarget = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mdBT_txtMSpaPackageTarget = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mdBT_txtMSpaProductTarget = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mdBT_txtMPTPackageTarget = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mdBT_txtMMergeTarget = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.btnReceipt_Add = new DevExpress.XtraEditors.SimpleButton();
            this.btnReceipt_Del = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlMd_BranchReceipt = new DevExpress.XtraGrid.GridControl();
            this.gridViewMd_BranchReceipt = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grpMdBranchTop = new DevExpress.XtraEditors.GroupControl();
            this.sBtnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.sBtnSubtract = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlMd_Branch = new DevExpress.XtraGrid.GridControl();
            this.gridViewMd_Branch = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.strBranchCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.strBranchName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ReceiptHeader1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ReceiptHeader2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ReceiptHeader3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ReceiptHeader4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ReceiptHeader5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ReceiptFooter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LockerRental1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LockerRental2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LockerDepositRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LockerGracePeriod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NonMembershipNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ManagerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lk_ManagerID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chk_Status = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMdBranchBelow2)).BeginInit();
            this.grpMdBranchBelow2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabCtrlMd_Branch)).BeginInit();
            this.tabCtrlMd_Branch.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMd_BranchTarget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMd_BranchTarget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mdBT_cbNYearID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mdBT_cbNMonthID)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMd_BranchReceipt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMd_BranchReceipt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMdBranchTop)).BeginInit();
            this.grpMdBranchTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMd_Branch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMd_Branch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_ManagerID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_Status)).BeginInit();
            this.SuspendLayout();
            // 
            // grpMdBranchBelow2
            // 
            this.grpMdBranchBelow2.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.grpMdBranchBelow2.Appearance.Options.UseBackColor = true;
            this.grpMdBranchBelow2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMdBranchBelow2.AppearanceCaption.Options.UseFont = true;
            this.grpMdBranchBelow2.Controls.Add(this.tabCtrlMd_Branch);
            this.grpMdBranchBelow2.Location = new System.Drawing.Point(8, 272);
            this.grpMdBranchBelow2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.grpMdBranchBelow2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grpMdBranchBelow2.Name = "grpMdBranchBelow2";
            this.grpMdBranchBelow2.Size = new System.Drawing.Size(976, 280);
            this.grpMdBranchBelow2.TabIndex = 15;
            this.grpMdBranchBelow2.Text = "Company Branch";
            // 
            // tabCtrlMd_Branch
            // 
            this.tabCtrlMd_Branch.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabCtrlMd_Branch.Appearance.Options.UseFont = true;
            this.tabCtrlMd_Branch.AppearancePage.Header.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabCtrlMd_Branch.AppearancePage.Header.Options.UseFont = true;
            this.tabCtrlMd_Branch.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabCtrlMd_Branch.Location = new System.Drawing.Point(2, 22);
            this.tabCtrlMd_Branch.LookAndFeel.UseDefaultLookAndFeel = false;
            this.tabCtrlMd_Branch.Name = "tabCtrlMd_Branch";
            this.tabCtrlMd_Branch.SelectedTabPage = this.xtraTabPage1;
            this.tabCtrlMd_Branch.Size = new System.Drawing.Size(972, 256);
            this.tabCtrlMd_Branch.TabIndex = 83;
            this.tabCtrlMd_Branch.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.btnBranchTarget_Add);
            this.xtraTabPage1.Controls.Add(this.btnBranchTarget_Del);
            this.xtraTabPage1.Controls.Add(this.gridControlMd_BranchTarget);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(963, 222);
            this.xtraTabPage1.Text = "Branch Target";
            // 
            // btnBranchTarget_Add
            // 
            this.btnBranchTarget_Add.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBranchTarget_Add.Appearance.Options.UseFont = true;
            this.btnBranchTarget_Add.Appearance.Options.UseTextOptions = true;
            this.btnBranchTarget_Add.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnBranchTarget_Add.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.btnBranchTarget_Add.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnBranchTarget_Add.ImageIndex = 0;
            this.btnBranchTarget_Add.ImageList = this.imageList1;
            this.btnBranchTarget_Add.Location = new System.Drawing.Point(8, 0);
            this.btnBranchTarget_Add.Name = "btnBranchTarget_Add";
            this.btnBranchTarget_Add.Size = new System.Drawing.Size(38, 16);
            this.btnBranchTarget_Add.TabIndex = 123;
            this.btnBranchTarget_Add.Click += new System.EventHandler(this.btnBranchTarget_Add_Click);
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
            // btnBranchTarget_Del
            // 
            this.btnBranchTarget_Del.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBranchTarget_Del.Appearance.Options.UseFont = true;
            this.btnBranchTarget_Del.Appearance.Options.UseTextOptions = true;
            this.btnBranchTarget_Del.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnBranchTarget_Del.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.btnBranchTarget_Del.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnBranchTarget_Del.ImageIndex = 1;
            this.btnBranchTarget_Del.ImageList = this.imageList1;
            this.btnBranchTarget_Del.Location = new System.Drawing.Point(48, 0);
            this.btnBranchTarget_Del.Name = "btnBranchTarget_Del";
            this.btnBranchTarget_Del.Size = new System.Drawing.Size(38, 16);
            this.btnBranchTarget_Del.TabIndex = 122;
            this.btnBranchTarget_Del.Click += new System.EventHandler(this.btnBranchTarget_Del_Click);
            // 
            // gridControlMd_BranchTarget
            // 
            this.gridControlMd_BranchTarget.Location = new System.Drawing.Point(0, 24);
            this.gridControlMd_BranchTarget.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControlMd_BranchTarget.MainView = this.gridViewMd_BranchTarget;
            this.gridControlMd_BranchTarget.Name = "gridControlMd_BranchTarget";
            this.gridControlMd_BranchTarget.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.mdBT_cbNYearID,
            this.mdBT_cbNMonthID});
            this.gridControlMd_BranchTarget.Size = new System.Drawing.Size(952, 184);
            this.gridControlMd_BranchTarget.TabIndex = 103;
            this.gridControlMd_BranchTarget.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMd_BranchTarget});
            // 
            // gridViewMd_BranchTarget
            // 
            this.gridViewMd_BranchTarget.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn13,
            this.mdBT_txtMFitnessPackageTarget,
            this.mdBT_txtMFitnessProductTarget,
            this.mdBT_txtMSpaPackageTarget,
            this.mdBT_txtMSpaProductTarget,
            this.mdBT_txtMPTPackageTarget,
            this.mdBT_txtMMergeTarget});
            this.gridViewMd_BranchTarget.GridControl = this.gridControlMd_BranchTarget;
            this.gridViewMd_BranchTarget.Name = "gridViewMd_BranchTarget";
            this.gridViewMd_BranchTarget.OptionsCustomization.AllowFilter = false;
            this.gridViewMd_BranchTarget.OptionsCustomization.AllowSort = false;
            this.gridViewMd_BranchTarget.OptionsView.ShowGroupPanel = false;
            this.gridViewMd_BranchTarget.LostFocus += new System.EventHandler(this.gridViewMd_BranchTarget_LostFocus);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Given Year";
            this.gridColumn1.ColumnEdit = this.mdBT_cbNYearID;
            this.gridColumn1.FieldName = "nYearID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // mdBT_cbNYearID
            // 
            this.mdBT_cbNYearID.AutoHeight = false;
            this.mdBT_cbNYearID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.mdBT_cbNYearID.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("2000", 2000, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("2001", 2001, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("2002", 2002, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("2003", 2003, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("2004", 2004, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("2005", 2005, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("2006", 2006, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("2007", 2007, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("2008", 2008, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("2009", 2009, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("2010", 2010, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("2011", 2011, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("2012", 2012, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("2013", 2013, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("2014", 2014, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("2015", 2015, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("2016", 2016, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("2017", 2017, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("2018", 2018, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("2019", 2019, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("2020", 2020, -1)});
            this.mdBT_cbNYearID.Name = "mdBT_cbNYearID";
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Given Month";
            this.gridColumn13.ColumnEdit = this.mdBT_cbNMonthID;
            this.gridColumn13.DisplayFormat.FormatString = "F0";
            this.gridColumn13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn13.FieldName = "nMonthID";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 1;
            this.gridColumn13.Width = 90;
            // 
            // mdBT_cbNMonthID
            // 
            this.mdBT_cbNMonthID.AutoHeight = false;
            this.mdBT_cbNMonthID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.mdBT_cbNMonthID.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("January", 1, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("February", 2, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("March", 3, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("April", 4, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("May", 5, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("June", 6, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("July", 7, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("August", 8, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("September", 9, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("October", 10, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("November", 11, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("December", 12, -1)});
            this.mdBT_cbNMonthID.Name = "mdBT_cbNMonthID";
            // 
            // mdBT_txtMFitnessPackageTarget
            // 
            this.mdBT_txtMFitnessPackageTarget.Caption = "Fitness Package Target";
            this.mdBT_txtMFitnessPackageTarget.DisplayFormat.FormatString = "c";
            this.mdBT_txtMFitnessPackageTarget.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.mdBT_txtMFitnessPackageTarget.FieldName = "mFitnessPackageTarget";
            this.mdBT_txtMFitnessPackageTarget.Name = "mdBT_txtMFitnessPackageTarget";
            this.mdBT_txtMFitnessPackageTarget.Visible = true;
            this.mdBT_txtMFitnessPackageTarget.VisibleIndex = 2;
            this.mdBT_txtMFitnessPackageTarget.Width = 152;
            // 
            // mdBT_txtMFitnessProductTarget
            // 
            this.mdBT_txtMFitnessProductTarget.Caption = "Fitness Product Target";
            this.mdBT_txtMFitnessProductTarget.DisplayFormat.FormatString = "c";
            this.mdBT_txtMFitnessProductTarget.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.mdBT_txtMFitnessProductTarget.FieldName = "mFitnessProductTarget";
            this.mdBT_txtMFitnessProductTarget.Name = "mdBT_txtMFitnessProductTarget";
            this.mdBT_txtMFitnessProductTarget.Visible = true;
            this.mdBT_txtMFitnessProductTarget.VisibleIndex = 3;
            this.mdBT_txtMFitnessProductTarget.Width = 152;
            // 
            // mdBT_txtMSpaPackageTarget
            // 
            this.mdBT_txtMSpaPackageTarget.Caption = "Spa Package Target";
            this.mdBT_txtMSpaPackageTarget.DisplayFormat.FormatString = "c";
            this.mdBT_txtMSpaPackageTarget.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.mdBT_txtMSpaPackageTarget.FieldName = "mSpaPackageTarget";
            this.mdBT_txtMSpaPackageTarget.Name = "mdBT_txtMSpaPackageTarget";
            this.mdBT_txtMSpaPackageTarget.Visible = true;
            this.mdBT_txtMSpaPackageTarget.VisibleIndex = 4;
            this.mdBT_txtMSpaPackageTarget.Width = 152;
            // 
            // mdBT_txtMSpaProductTarget
            // 
            this.mdBT_txtMSpaProductTarget.Caption = "Spa Product Target";
            this.mdBT_txtMSpaProductTarget.DisplayFormat.FormatString = "c";
            this.mdBT_txtMSpaProductTarget.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.mdBT_txtMSpaProductTarget.FieldName = "mSpaProductTarget";
            this.mdBT_txtMSpaProductTarget.Name = "mdBT_txtMSpaProductTarget";
            this.mdBT_txtMSpaProductTarget.Visible = true;
            this.mdBT_txtMSpaProductTarget.VisibleIndex = 5;
            this.mdBT_txtMSpaProductTarget.Width = 152;
            // 
            // mdBT_txtMPTPackageTarget
            // 
            this.mdBT_txtMPTPackageTarget.Caption = "PT Package Target";
            this.mdBT_txtMPTPackageTarget.DisplayFormat.FormatString = "c";
            this.mdBT_txtMPTPackageTarget.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.mdBT_txtMPTPackageTarget.FieldName = "mPTPackageTarget";
            this.mdBT_txtMPTPackageTarget.Name = "mdBT_txtMPTPackageTarget";
            this.mdBT_txtMPTPackageTarget.Visible = true;
            this.mdBT_txtMPTPackageTarget.VisibleIndex = 6;
            this.mdBT_txtMPTPackageTarget.Width = 155;
            // 
            // mdBT_txtMMergeTarget
            // 
            this.mdBT_txtMMergeTarget.Caption = "Merge Target";
            this.mdBT_txtMMergeTarget.DisplayFormat.FormatString = "c";
            this.mdBT_txtMMergeTarget.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.mdBT_txtMMergeTarget.FieldName = "mMergeTarget";
            this.mdBT_txtMMergeTarget.Name = "mdBT_txtMMergeTarget";
            this.mdBT_txtMMergeTarget.Visible = true;
            this.mdBT_txtMMergeTarget.VisibleIndex = 6;
            this.mdBT_txtMMergeTarget.Width = 155;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.btnReceipt_Add);
            this.xtraTabPage2.Controls.Add(this.btnReceipt_Del);
            this.xtraTabPage2.Controls.Add(this.gridControlMd_BranchReceipt);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(963, 222);
            this.xtraTabPage2.Text = "Receipt No";
            // 
            // btnReceipt_Add
            // 
            this.btnReceipt_Add.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReceipt_Add.Appearance.Options.UseFont = true;
            this.btnReceipt_Add.Appearance.Options.UseTextOptions = true;
            this.btnReceipt_Add.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnReceipt_Add.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.btnReceipt_Add.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnReceipt_Add.ImageIndex = 0;
            this.btnReceipt_Add.ImageList = this.imageList1;
            this.btnReceipt_Add.ImeMode = System.Windows.Forms.ImeMode.On;
            this.btnReceipt_Add.Location = new System.Drawing.Point(8, 0);
            this.btnReceipt_Add.Name = "btnReceipt_Add";
            this.btnReceipt_Add.Size = new System.Drawing.Size(32, 24);
            this.btnReceipt_Add.TabIndex = 128;
            this.btnReceipt_Add.Click += new System.EventHandler(this.btnReceipt_Add_Click);
            // 
            // btnReceipt_Del
            // 
            this.btnReceipt_Del.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReceipt_Del.Appearance.Options.UseFont = true;
            this.btnReceipt_Del.Appearance.Options.UseTextOptions = true;
            this.btnReceipt_Del.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnReceipt_Del.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.btnReceipt_Del.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnReceipt_Del.ImageIndex = 1;
            this.btnReceipt_Del.ImageList = this.imageList1;
            this.btnReceipt_Del.Location = new System.Drawing.Point(40, 0);
            this.btnReceipt_Del.Name = "btnReceipt_Del";
            this.btnReceipt_Del.Size = new System.Drawing.Size(32, 24);
            this.btnReceipt_Del.TabIndex = 127;
            this.btnReceipt_Del.Click += new System.EventHandler(this.btnReceipt_Del_Click);
            // 
            // gridControlMd_BranchReceipt
            // 
            this.gridControlMd_BranchReceipt.Location = new System.Drawing.Point(0, 24);
            this.gridControlMd_BranchReceipt.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControlMd_BranchReceipt.MainView = this.gridViewMd_BranchReceipt;
            this.gridControlMd_BranchReceipt.Name = "gridControlMd_BranchReceipt";
            this.gridControlMd_BranchReceipt.Size = new System.Drawing.Size(960, 184);
            this.gridControlMd_BranchReceipt.TabIndex = 104;
            this.gridControlMd_BranchReceipt.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMd_BranchReceipt});
            // 
            // gridViewMd_BranchReceipt
            // 
            this.gridViewMd_BranchReceipt.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn19,
            this.gridColumn20});
            this.gridViewMd_BranchReceipt.GridControl = this.gridControlMd_BranchReceipt;
            this.gridViewMd_BranchReceipt.Name = "gridViewMd_BranchReceipt";
            this.gridViewMd_BranchReceipt.OptionsCustomization.AllowFilter = false;
            this.gridViewMd_BranchReceipt.OptionsCustomization.AllowSort = false;
            this.gridViewMd_BranchReceipt.OptionsView.ShowGroupPanel = false;
            this.gridViewMd_BranchReceipt.LostFocus += new System.EventHandler(this.gridViewMd_BranchReceipt_LostFocus);
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "Terminal ID";
            this.gridColumn19.DisplayFormat.FormatString = "F0";
            this.gridColumn19.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn19.FieldName = "nTerminalID";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 0;
            this.gridColumn19.Width = 143;
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "Receipt Number";
            this.gridColumn20.DisplayFormat.FormatString = "F0";
            this.gridColumn20.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn20.FieldName = "nReceiptNo";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 1;
            this.gridColumn20.Width = 796;
            // 
            // grpMdBranchTop
            // 
            this.grpMdBranchTop.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.grpMdBranchTop.Appearance.Options.UseBackColor = true;
            this.grpMdBranchTop.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMdBranchTop.AppearanceCaption.Options.UseFont = true;
            this.grpMdBranchTop.Controls.Add(this.sBtnAdd);
            this.grpMdBranchTop.Controls.Add(this.sBtnSubtract);
            this.grpMdBranchTop.Controls.Add(this.gridControlMd_Branch);
            this.grpMdBranchTop.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grpMdBranchTop.Location = new System.Drawing.Point(8, 0);
            this.grpMdBranchTop.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.grpMdBranchTop.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grpMdBranchTop.Name = "grpMdBranchTop";
            this.grpMdBranchTop.Size = new System.Drawing.Size(976, 264);
            this.grpMdBranchTop.TabIndex = 87;
            this.grpMdBranchTop.Text = "Branch";
            // 
            // sBtnAdd
            // 
            this.sBtnAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sBtnAdd.Appearance.Options.UseFont = true;
            this.sBtnAdd.Appearance.Options.UseTextOptions = true;
            this.sBtnAdd.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.sBtnAdd.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.sBtnAdd.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.sBtnAdd.ImageIndex = 0;
            this.sBtnAdd.ImageList = this.imageList1;
            this.sBtnAdd.ImeMode = System.Windows.Forms.ImeMode.On;
            this.sBtnAdd.Location = new System.Drawing.Point(8, 24);
            this.sBtnAdd.Name = "sBtnAdd";
            this.sBtnAdd.Size = new System.Drawing.Size(38, 16);
            this.sBtnAdd.TabIndex = 56;
            this.sBtnAdd.Click += new System.EventHandler(this.sBtnAdd_Click);
            // 
            // sBtnSubtract
            // 
            this.sBtnSubtract.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sBtnSubtract.Appearance.Options.UseFont = true;
            this.sBtnSubtract.Appearance.Options.UseTextOptions = true;
            this.sBtnSubtract.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.sBtnSubtract.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.sBtnSubtract.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.sBtnSubtract.ImageIndex = 1;
            this.sBtnSubtract.ImageList = this.imageList1;
            this.sBtnSubtract.Location = new System.Drawing.Point(48, 24);
            this.sBtnSubtract.Name = "sBtnSubtract";
            this.sBtnSubtract.Size = new System.Drawing.Size(38, 16);
            this.sBtnSubtract.TabIndex = 55;
            this.sBtnSubtract.Click += new System.EventHandler(this.sBtnSubtract_Click);
            // 
            // gridControlMd_Branch
            // 
            this.gridControlMd_Branch.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridControlMd_Branch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gridControlMd_Branch.Location = new System.Drawing.Point(2, 46);
            this.gridControlMd_Branch.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControlMd_Branch.MainView = this.gridViewMd_Branch;
            this.gridControlMd_Branch.Name = "gridControlMd_Branch";
            this.gridControlMd_Branch.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lk_ManagerID,
            this.chk_Status});
            this.gridControlMd_Branch.Size = new System.Drawing.Size(972, 216);
            this.gridControlMd_Branch.TabIndex = 17;
            this.gridControlMd_Branch.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMd_Branch});
            // 
            // gridViewMd_Branch
            // 
            this.gridViewMd_Branch.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.strBranchCode,
            this.strBranchName,
            this.ReceiptHeader1,
            this.ReceiptHeader2,
            this.ReceiptHeader3,
            this.ReceiptHeader4,
            this.ReceiptHeader5,
            this.ReceiptFooter,
            this.LockerRental1,
            this.LockerRental2,
            this.LockerDepositRate,
            this.LockerGracePeriod,
            this.NonMembershipNo,
            this.ManagerID,
            this.gridColumn2});
            this.gridViewMd_Branch.GridControl = this.gridControlMd_Branch;
            this.gridViewMd_Branch.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridViewMd_Branch.Name = "gridViewMd_Branch";
            this.gridViewMd_Branch.OptionsCustomization.AllowColumnMoving = false;
            this.gridViewMd_Branch.OptionsCustomization.AllowFilter = false;
            this.gridViewMd_Branch.OptionsCustomization.AllowSort = false;
            this.gridViewMd_Branch.OptionsView.ColumnAutoWidth = false;
            this.gridViewMd_Branch.OptionsView.ShowGroupPanel = false;
            this.gridViewMd_Branch.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewMd_Branch_FocusedRowChanged);
            this.gridViewMd_Branch.LostFocus += new System.EventHandler(this.gridViewMd_Branch_LostFocus);
            // 
            // strBranchCode
            // 
            this.strBranchCode.Caption = "Branch";
            this.strBranchCode.FieldName = "strBranchCode";
            this.strBranchCode.Name = "strBranchCode";
            this.strBranchCode.Visible = true;
            this.strBranchCode.VisibleIndex = 0;
            this.strBranchCode.Width = 62;
            // 
            // strBranchName
            // 
            this.strBranchName.Caption = "Name";
            this.strBranchName.FieldName = "strBranchName";
            this.strBranchName.Name = "strBranchName";
            this.strBranchName.Visible = true;
            this.strBranchName.VisibleIndex = 1;
            this.strBranchName.Width = 100;
            // 
            // ReceiptHeader1
            //  
            this.ReceiptHeader1.Caption = "Receipt Header 1";
            this.ReceiptHeader1.FieldName = "strHeader1";
            this.ReceiptHeader1.Name = "ReceiptHeader1";
            this.ReceiptHeader1.Visible = true;
            this.ReceiptHeader1.VisibleIndex = 2;
            this.ReceiptHeader1.Width = 100;
            // 
            // ReceiptHeader2
            // 
            this.ReceiptHeader2.Caption = "Receipt Header 2";
            this.ReceiptHeader2.FieldName = "strHeader2";
            this.ReceiptHeader2.Name = "ReceiptHeader2";
            this.ReceiptHeader2.Visible = true;
            this.ReceiptHeader2.VisibleIndex = 3;
            this.ReceiptHeader2.Width = 100;
            // 
            // ReceiptHeader3
            // 
            this.ReceiptHeader3.Caption = "Receipt Header 3";
            this.ReceiptHeader3.FieldName = "strHeader3";
            this.ReceiptHeader3.Name = "ReceiptHeader3";
            this.ReceiptHeader3.Visible = true;
            this.ReceiptHeader3.VisibleIndex = 4;
            this.ReceiptHeader3.Width = 100;
            // 
            // ReceiptHeader4
            // 
            this.ReceiptHeader4.Caption = "Receipt Header 4";
            this.ReceiptHeader4.FieldName = "strHeader4";
            this.ReceiptHeader4.Name = "ReceiptHeader4";
            this.ReceiptHeader4.Visible = true;
            this.ReceiptHeader4.VisibleIndex = 5;
            this.ReceiptHeader4.Width = 100;
            // 
            // ReceiptHeader5
            // 
            this.ReceiptHeader5.Caption = "Receipt Header 5";
            this.ReceiptHeader5.FieldName = "strHeader5";
            this.ReceiptHeader5.Name = "ReceiptHeader5";
            this.ReceiptHeader5.Visible = true;
            this.ReceiptHeader5.VisibleIndex = 6;
            this.ReceiptHeader5.Width = 95;
            // 
            // ReceiptFooter
            // 
            this.ReceiptFooter.Caption = "Receipt Footer";
            this.ReceiptFooter.FieldName = "strFooter1";
            this.ReceiptFooter.Name = "ReceiptFooter";
            this.ReceiptFooter.Visible = true;
            this.ReceiptFooter.VisibleIndex = 7;
            this.ReceiptFooter.Width = 87;
            // 
            // LockerRental1
            // 
            this.LockerRental1.AppearanceCell.Options.UseTextOptions = true;
            this.LockerRental1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.LockerRental1.Caption = "Locker Rental 1";
            this.LockerRental1.DisplayFormat.FormatString = "c";
            this.LockerRental1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.LockerRental1.FieldName = "mLockerRentalRate1";
            this.LockerRental1.Name = "LockerRental1";
            this.LockerRental1.Visible = true;
            this.LockerRental1.VisibleIndex = 8;
            this.LockerRental1.Width = 100;
            // 
            // LockerRental2
            // 
            this.LockerRental2.AppearanceCell.Options.UseTextOptions = true;
            this.LockerRental2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.LockerRental2.Caption = "Locker Rental 2";
            this.LockerRental2.DisplayFormat.FormatString = "c";
            this.LockerRental2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.LockerRental2.FieldName = "mLockerRentalRate2";
            this.LockerRental2.Name = "LockerRental2";
            this.LockerRental2.Visible = true;
            this.LockerRental2.VisibleIndex = 9;
            this.LockerRental2.Width = 100;
            // 
            // LockerDepositRate
            // 
            this.LockerDepositRate.AppearanceCell.Options.UseTextOptions = true;
            this.LockerDepositRate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.LockerDepositRate.Caption = "Locker Deposit Rate";
            this.LockerDepositRate.DisplayFormat.FormatString = "c";
            this.LockerDepositRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.LockerDepositRate.FieldName = "mLockerDepositRate";
            this.LockerDepositRate.Name = "LockerDepositRate";
            this.LockerDepositRate.Visible = true;
            this.LockerDepositRate.VisibleIndex = 10;
            this.LockerDepositRate.Width = 110;
            // 
            // LockerGracePeriod
            // 
            this.LockerGracePeriod.AppearanceCell.Options.UseTextOptions = true;
            this.LockerGracePeriod.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.LockerGracePeriod.Caption = "Locker Grace Period";
            this.LockerGracePeriod.DisplayFormat.FormatString = "n";
            this.LockerGracePeriod.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.LockerGracePeriod.FieldName = "nLockerGracePeriod";
            this.LockerGracePeriod.Name = "LockerGracePeriod";
            this.LockerGracePeriod.Visible = true;
            this.LockerGracePeriod.VisibleIndex = 11;
            this.LockerGracePeriod.Width = 110;
            // 
            // NonMembershipNo
            // 
            this.NonMembershipNo.Caption = "Non-Membership No";
            this.NonMembershipNo.DisplayFormat.FormatString = "f0";
            this.NonMembershipNo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.NonMembershipNo.FieldName = "nMembershipNo";
            this.NonMembershipNo.Name = "NonMembershipNo";
            this.NonMembershipNo.Visible = true;
            this.NonMembershipNo.VisibleIndex = 12;
            this.NonMembershipNo.Width = 108;
            // 
            // ManagerID
            // 
            this.ManagerID.Caption = "Manager";
            this.ManagerID.ColumnEdit = this.lk_ManagerID;
            this.ManagerID.FieldName = "nManagerID";
            this.ManagerID.Name = "ManagerID";
            this.ManagerID.Visible = true;
            this.ManagerID.VisibleIndex = 13;
            this.ManagerID.Width = 120;
            // 
            // lk_ManagerID
            // 
            this.lk_ManagerID.AutoHeight = false;
            this.lk_ManagerID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lk_ManagerID.Name = "lk_ManagerID";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Status";
            this.gridColumn2.ColumnEdit = this.chk_Status;
            this.gridColumn2.FieldName = "nBrStatusID";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 14;
            // 
            // chk_Status
            // 
            this.chk_Status.AutoHeight = false;
            this.chk_Status.Name = "chk_Status";
            // 
            // frmBranch
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 570);
            this.Controls.Add(this.grpMdBranchBelow2);
            this.Controls.Add(this.grpMdBranchTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBranch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmBranch";
            ((System.ComponentModel.ISupportInitialize)(this.grpMdBranchBelow2)).EndInit();
            this.grpMdBranchBelow2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabCtrlMd_Branch)).EndInit();
            this.tabCtrlMd_Branch.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMd_BranchTarget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMd_BranchTarget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mdBT_cbNYearID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mdBT_cbNMonthID)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMd_BranchReceipt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMd_BranchReceipt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMdBranchTop)).EndInit();
            this.grpMdBranchTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMd_Branch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMd_Branch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_ManagerID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_Status)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region Branch Receipt
		private void mdBranchReceiptInit()
		{
			string strSQL;
			DataSet _ds2 = new DataSet();

			DataRow row = gridViewMd_Branch.GetDataRow(gridViewMd_Branch.FocusedRowHandle);
			if (row != null)
			{
						
				strSQL = "select * from tblBranchReceiptNo where strBranchCode='" + row["strBranchCode"] + "'";
				SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds2,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
				dtBranchReceipt = _ds2.Tables["Table"];
				this.gridControlMd_BranchReceipt.DataSource = dtBranchReceipt;
			}
		}

		private bool mdReceipt_FieldValidation(DataRow dr)
		{
			if (dr["nTerminalID"].ToString() == "")
				return false;

			return true;
		}

		private void btnReceipt_Add_Click(object sender, System.EventArgs e)
		{
			DataRow row = this.gridViewMd_Branch.GetDataRow(gridViewMd_Branch.FocusedRowHandle);

			AddNewReceipt = true;

			DataRow dr = dtBranchReceipt.NewRow();
			dr["strBranchCode"] = row["strBranchCode"].ToString();
			dtBranchReceipt.Rows.Add(dr);
			this.gridControlMd_BranchReceipt.Refresh();

			this.gridViewMd_BranchReceipt.FocusedRowHandle = dtBranchReceipt.Rows.Count - 1;
		}

		private void btnReceipt_Del_Click(object sender, System.EventArgs e)
		{
			DataRow row = this.gridViewMd_BranchReceipt.GetDataRow(gridViewMd_BranchReceipt.FocusedRowHandle);
			if (row != null)
			{

				if (AddNewReceipt)
				{
					AddNewReceipt = false;
					gridViewMd_BranchReceipt.DeleteRow(gridViewMd_BranchReceipt.FocusedRowHandle);
				}
				else
				{
					DialogResult result = MessageBox.Show(this, "Do you really want to delete branch receipt",
						"Delete?", MessageBoxButtons.YesNo);
					if (result == DialogResult.Yes)
					{

						try
						{
							SqlHelper.ExecuteNonQuery(connection,"Del_TblBranchReceipt",
								new SqlParameter("@strBranchCode",row["strBranchCode"].ToString() ),
								new SqlParameter("@nTerminalID",row["nTerminalID"].ToString() )
								);
						}
						catch(Exception ex)
						{
							MessageBox.Show(ex.Message ,"Delete Process Failed");
							return;
						}
						MessageBox.Show("Record Deleted Successfully","Message");
					}
					mdBranchReceiptInit();
				}
			}
		}

		private bool AddNewReceipt;
		private void gridViewMd_BranchReceipt_LostFocus(object sender, System.EventArgs e)
		{
			if (this.gridViewMd_Branch.RowCount < 0)
				return;

			DataRow row = this.gridViewMd_BranchReceipt.GetDataRow(gridViewMd_BranchReceipt.FocusedRowHandle);
			DataRow row2 = this.gridViewMd_Branch.GetDataRow(gridViewMd_Branch.FocusedRowHandle);

			string strSQL = "select * from tblBranchReceiptNo where strBranchCode='" + row2["strBranchCode"] + "'";
			
			if (AddNewReceipt)
			{
				if( mdReceipt_FieldValidation(row))
				{
					this.gridControlMd_BranchReceipt.MainView.UpdateCurrentRow();
					CreateCmdsAndUpdate(strSQL,dtBranchReceipt);
					AddNewReceipt = false;
				}
			}
			else
			{
				this.gridViewMd_BranchReceipt.CloseEditor();
				gridViewMd_BranchReceipt.UpdateCurrentRow();

				CreateCmdsAndUpdate(strSQL,dtBranchReceipt);
			}
		}
	
		#endregion
	
		#region Branchtarget

		
		private void mdBranchTargetInit()
		{
			//this.mdBT_cbNYearID.Enabled = false;
			this.mdBT_cbNMonthID.Enabled = false;
								
			string strSQL;
			DataSet _ds2 = new DataSet();
			DataRow row = gridViewMd_Branch.GetDataRow(gridViewMd_Branch.FocusedRowHandle);
			if (row != null)
			{
				strSQL = "select * from tblBranchTarget where strBranchCode='" + row["strBranchCode"] + "'";
				SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds2,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
				dtBranchTarget = _ds2.Tables["table"];
				this.gridControlMd_BranchTarget.DataSource = dtBranchTarget;
			}
		}

		private bool AddNewTarget = false;
		private void gridViewMd_BranchTarget_LostFocus(object sender, System.EventArgs e)
		{
			if (this.gridViewMd_Branch.RowCount < 0)
					return;

			DataRow row = this.gridViewMd_BranchTarget.GetDataRow(gridViewMd_BranchTarget.FocusedRowHandle);
			DataRow row2 = this.gridViewMd_Branch.GetDataRow(gridViewMd_Branch.FocusedRowHandle);

			string strSQL = "select * from tblBranchTarget where strBranchCode='" + row2["strBranchCode"] + "'";
			
			if (AddNewTarget)
			{
				if( mdBR_FieldValidation(row))
				{
					this.gridControlMd_BranchTarget.MainView.UpdateCurrentRow();
					CreateCmdsAndUpdate(strSQL,dtBranchTarget);
					AddNewTarget = false;
				}
			}
			else
			{
				gridViewMd_BranchTarget.CloseEditor();
				gridViewMd_BranchTarget.UpdateCurrentRow();

				CreateCmdsAndUpdate(strSQL,dtBranchTarget);
			}
		    
		}

		private bool mdBR_FieldValidation(DataRow dr)
		{
			if (dr["nYearID"].ToString() == "")
				return false;

			if (dr["nMonthID"].ToString() == "")
				return false;

			return true;
		}

		private void btnBranchTarget_Add_Click(object sender, System.EventArgs e)
		{
			DataRow row = this.gridViewMd_Branch.GetDataRow(gridViewMd_Branch.FocusedRowHandle);

			AddNewTarget = true;

			DataRow dr = dtBranchTarget.NewRow();
			dr["strBranchCode"] = row["strBranchCode"].ToString();
			dtBranchTarget.Rows.Add(dr);
			this.gridControlMd_BranchTarget.Refresh();

			this.gridViewMd_BranchTarget.FocusedRowHandle = dtBranchTarget.Rows.Count - 1;
			
		}

		private void btnBranchTarget_Del_Click(object sender, System.EventArgs e)
		{

				DataRow row = this.gridViewMd_BranchTarget.GetDataRow(gridViewMd_BranchTarget.FocusedRowHandle);
					if (row != null)
					{

						if (AddNewTarget)
						{
							AddNewTarget = false;
							gridViewMd_BranchTarget.DeleteRow(gridViewMd_BranchTarget.FocusedRowHandle);
						}
						else
						{
							DialogResult result = MessageBox.Show(this, "Do you really want to delete branch target record with Year = '" + row["nYearID"].ToString() + "' and Month='" + row["nMonthID"].ToString() + "'",
								"Delete?", MessageBoxButtons.YesNo);
							if (result == DialogResult.Yes)
							{

								try
								{
									SqlHelper.ExecuteNonQuery(connection,"del_TblBranchTarget",
										new SqlParameter("@strBranchCode",row["strBranchCode"].ToString() ),
										new SqlParameter("@nYearID",row["nYearID"].ToString() ),
										new SqlParameter("@nMonthID",row["nMonthID"].ToString() )
										);
								}
								catch(Exception ex)
								{
									MessageBox.Show(ex.Message ,"Delete Process Failed");
									return;
								}
								MessageBox.Show("Record Deleted Successfully","Message");
							}
							mdBranchInit();
						}
					}
		}
		
		private void btnBranchTarget_Cancel_Click(object sender, System.EventArgs e)
		{
			if (AddNew)
			{
				AddNew = false;
				gridViewMd_BranchTarget.FocusedRowHandle = RowFocus - 1;
				gridViewMd_BranchTarget.DeleteRow(RowFocus);
			}
		}
		#endregion

		#region Branch


		private int RowFocus = 0;
		private bool AddNew = false;
		
		private void mdBranchInit()
		{
			DataSet _ds = new DataSet(); 
			string strSQL = "select * from tblEmployee";
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			DataTable dt = _ds.Tables["Table"];

			DevExpress.XtraEditors.Controls.LookUpColumnInfo[] col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
			
			col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nEmployeeID","Employee Id",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strEmployeeName","Employee Name",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
		
			myManager = new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(lk_ManagerID,dt,col,"strEmployeeName","nEmployeeID","Manager");

			_ds = new DataSet(); 
			strSQL = "select * from tblBranch";
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			dtBranch = _ds.Tables["table"];
			gridControlMd_Branch.DataSource = dtBranch;
			
		}

		private bool mdBranch_FieldValidation(DataRow dr)
		{
			if (dr["strBranchCode"].ToString() == "")
				return false;

			return true;
		}
		
		private void gridViewMd_Branch_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
			mdBranchTargetInit();
			mdBranchReceiptInit();
		}

		private void gridViewMd_Branch_LostFocus(object sender, System.EventArgs e)
		{
			DataRow row = this.gridViewMd_Branch.GetDataRow(gridViewMd_Branch.FocusedRowHandle);
			
			string strSQL = "Select * from tblBranch";
			if (AddNew)
			{
				if( mdBranch_FieldValidation(row))
				{
					this.gridControlMd_Branch.MainView.UpdateCurrentRow();
					CreateCmdsAndUpdate(strSQL,dtBranch);
					AddNew = false;
				}
			}
			else
			{
				gridViewMd_Branch.CloseEditor();
				gridViewMd_Branch.UpdateCurrentRow();

				CreateCmdsAndUpdate(strSQL,dtBranch);
			}
		}

		private void sBtnAdd_Click(object sender, System.EventArgs e)
		{
			AddNew = true;
			DataRow dr = dtBranch.NewRow();
			dtBranch.Rows.Add(dr);
			this.gridControlMd_Branch.Refresh();
			this.gridViewMd_Branch.FocusedRowHandle = dtBranch.Rows.Count - 1;
		}

		private void sBtnSubtract_Click(object sender, System.EventArgs e)
		{
			DataRow row = gridViewMd_Branch.GetDataRow(gridViewMd_Branch.FocusedRowHandle);
			if (row != null)
			{
	
				if (AddNew)
				{
					AddNew = false;
					gridViewMd_Branch.DeleteRow(gridViewMd_Branch.FocusedRowHandle);
				}
				else
				{

					DialogResult result = MessageBox.Show(this, "Do you really want to delete record with Branch Code = " + row["strBranchCode"].ToString(),
						"Delete?", MessageBoxButtons.YesNo);
					if (result == DialogResult.Yes)
					{
						try
						{
							SqlHelper.ExecuteNonQuery(connection,"del_TblBranch",
								new SqlParameter("@strBranchCode",row["strBranchCode"].ToString() )
								);
						}
						catch(Exception ex)
						{
							MessageBox.Show(ex.Message ,"Delete Process Failed");
							return;
						}
						MessageBox.Show("Record Deleted Successfully","Message");
					}
					mdBranchInit();
				}
			}
		}
	
		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			if (AddNew)
			{
				AddNew = false;
				gridViewMd_Branch.FocusedRowHandle = RowFocus - 1;
				gridViewMd_Branch.DeleteRow(RowFocus);
			}
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


	}
}
