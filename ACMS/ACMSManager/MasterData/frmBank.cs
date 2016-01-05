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
	/// Summary description for frmBank.
	/// </summary>
	public class frmBank : DevExpress.XtraEditors.XtraForm
	{
		internal DevExpress.XtraEditors.SimpleButton sBtnAdd;
		internal DevExpress.XtraEditors.SimpleButton sBtnSubtract;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_ManagerID;
		private System.Windows.Forms.ImageList imageList1;
		private System.ComponentModel.IContainer components;
		private string connectionString;
		private DevExpress.XtraGrid.GridControl gridControlMd_Bank;
		private SqlConnection connection;
		private DevExpress.XtraEditors.GroupControl grpMdBankTop;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewMd_Bank;
		private DevExpress.XtraGrid.Columns.GridColumn strBankCode;
		private DevExpress.XtraGrid.Columns.GridColumn strDescription;
		private DevExpress.XtraGrid.Columns.GridColumn strIPP;
		private DevExpress.XtraEditors.GroupControl grpMdBankBottom;
		private DevExpress.XtraTab.XtraTabPage tabPage_1;
		private DevExpress.XtraTab.XtraTabPage tabPage_2;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView_BankBranch;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
		private DevExpress.XtraGrid.GridControl grid_BankBranch;
		private DevExpress.XtraGrid.Columns.GridColumn strBankBranchCode;
		private DevExpress.XtraGrid.Columns.GridColumn BankBranchDescription;
		private DevExpress.XtraGrid.GridControl gridBankIpp;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView_BankIpp;
		private DevExpress.XtraGrid.Columns.GridColumn nMonth;
		private DevExpress.XtraGrid.Columns.GridColumn dInterestRate;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit2;
		private DevExpress.XtraTab.XtraTabPage tabPage_3;
		private DevExpress.XtraGrid.GridControl gridBankMerchant;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit3;
		private DevExpress.XtraGrid.Columns.GridColumn strBranchCode;
		private DevExpress.XtraGrid.Columns.GridColumn strMerchantNo;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView_BankMerchant;
		private DevExpress.XtraTab.XtraTabControl tabBank;
		internal DevExpress.XtraEditors.SimpleButton btn_Bottom_Add;
		internal DevExpress.XtraEditors.SimpleButton btn_Bottom_Del;
		private DataTable dtBank;

		public frmBank()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			//
			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);
			mdBankInit();	}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// 
		private void mdBankInit()
		{
			DataSet _ds = new DataSet(); 
			DataTable dt = _ds.Tables["Table"];

			_ds = new DataSet(); 
			
			string strSQL = "select * from tblBank";
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			dtBank = _ds.Tables["table"];
			gridControlMd_Bank.DataSource = dtBank;
		
		}

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
			DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
			DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
			DevExpress.XtraGrid.GridLevelNode gridLevelNode3 = new DevExpress.XtraGrid.GridLevelNode();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmBank));
			DevExpress.XtraGrid.GridLevelNode gridLevelNode4 = new DevExpress.XtraGrid.GridLevelNode();
			this.grpMdBankTop = new DevExpress.XtraEditors.GroupControl();
			this.grpMdBankBottom = new DevExpress.XtraEditors.GroupControl();
			this.tabBank = new DevExpress.XtraTab.XtraTabControl();
			this.tabPage_1 = new DevExpress.XtraTab.XtraTabPage();
			this.grid_BankBranch = new DevExpress.XtraGrid.GridControl();
			this.gridView_BankBranch = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.strBankBranchCode = new DevExpress.XtraGrid.Columns.GridColumn();
			this.BankBranchDescription = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			this.tabPage_2 = new DevExpress.XtraTab.XtraTabPage();
			this.gridBankIpp = new DevExpress.XtraGrid.GridControl();
			this.gridView_BankIpp = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.nMonth = new DevExpress.XtraGrid.Columns.GridColumn();
			this.dInterestRate = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			this.tabPage_3 = new DevExpress.XtraTab.XtraTabPage();
			this.gridBankMerchant = new DevExpress.XtraGrid.GridControl();
			this.gridView_BankMerchant = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.strBranchCode = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.strMerchantNo = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemLookUpEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			this.btn_Bottom_Del = new DevExpress.XtraEditors.SimpleButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.btn_Bottom_Add = new DevExpress.XtraEditors.SimpleButton();
			this.sBtnAdd = new DevExpress.XtraEditors.SimpleButton();
			this.sBtnSubtract = new DevExpress.XtraEditors.SimpleButton();
			this.gridControlMd_Bank = new DevExpress.XtraGrid.GridControl();
			this.gridViewMd_Bank = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.strBankCode = new DevExpress.XtraGrid.Columns.GridColumn();
			this.strDescription = new DevExpress.XtraGrid.Columns.GridColumn();
			this.strIPP = new DevExpress.XtraGrid.Columns.GridColumn();
			this.lk_ManagerID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			((System.ComponentModel.ISupportInitialize)(this.grpMdBankTop)).BeginInit();
			this.grpMdBankTop.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grpMdBankBottom)).BeginInit();
			this.grpMdBankBottom.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tabBank)).BeginInit();
			this.tabBank.SuspendLayout();
			this.tabPage_1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grid_BankBranch)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView_BankBranch)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
			this.tabPage_2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridBankIpp)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView_BankIpp)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).BeginInit();
			this.tabPage_3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridBankMerchant)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView_BankMerchant)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControlMd_Bank)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewMd_Bank)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_ManagerID)).BeginInit();
			this.SuspendLayout();
			// 
			// grpMdBankTop
			// 
			this.grpMdBankTop.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.grpMdBankTop.Appearance.Options.UseBackColor = true;
			this.grpMdBankTop.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.grpMdBankTop.AppearanceCaption.Options.UseFont = true;
			this.grpMdBankTop.Controls.Add(this.grpMdBankBottom);
			this.grpMdBankTop.Controls.Add(this.sBtnAdd);
			this.grpMdBankTop.Controls.Add(this.sBtnSubtract);
			this.grpMdBankTop.Controls.Add(this.gridControlMd_Bank);
			this.grpMdBankTop.Dock = System.Windows.Forms.DockStyle.Left;
			this.grpMdBankTop.ImeMode = System.Windows.Forms.ImeMode.On;
			this.grpMdBankTop.Location = new System.Drawing.Point(0, 0);
			this.grpMdBankTop.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.grpMdBankTop.LookAndFeel.UseDefaultLookAndFeel = false;
			this.grpMdBankTop.LookAndFeel.UseWindowsXPTheme = false;
			this.grpMdBankTop.Name = "grpMdBankTop";
			this.grpMdBankTop.Size = new System.Drawing.Size(976, 454);
			this.grpMdBankTop.TabIndex = 88;
			this.grpMdBankTop.Text = "Bank";
			// 
			// grpMdBankBottom
			// 
			this.grpMdBankBottom.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.grpMdBankBottom.Appearance.Options.UseBackColor = true;
			this.grpMdBankBottom.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.grpMdBankBottom.AppearanceCaption.Options.UseFont = true;
			this.grpMdBankBottom.Controls.Add(this.tabBank);
			this.grpMdBankBottom.Controls.Add(this.btn_Bottom_Del);
			this.grpMdBankBottom.Controls.Add(this.btn_Bottom_Add);
			this.grpMdBankBottom.Location = new System.Drawing.Point(0, 240);
			this.grpMdBankBottom.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.grpMdBankBottom.LookAndFeel.UseDefaultLookAndFeel = false;
			this.grpMdBankBottom.LookAndFeel.UseWindowsXPTheme = false;
			this.grpMdBankBottom.Name = "grpMdBankBottom";
			this.grpMdBankBottom.Size = new System.Drawing.Size(1040, 280);
			this.grpMdBankBottom.TabIndex = 57;
			this.grpMdBankBottom.Text = "Bank Branch and IPP Code";
			// 
			// tabBank
			// 
			this.tabBank.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.tabBank.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tabBank.Appearance.Options.UseFont = true;
			this.tabBank.AppearancePage.Header.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tabBank.AppearancePage.Header.Options.UseFont = true;
			this.tabBank.Location = new System.Drawing.Point(8, 44);
			this.tabBank.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.tabBank.LookAndFeel.UseDefaultLookAndFeel = false;
			this.tabBank.LookAndFeel.UseWindowsXPTheme = false;
			this.tabBank.Name = "tabBank";
			this.tabBank.SelectedTabPage = this.tabPage_1;
			this.tabBank.Size = new System.Drawing.Size(800, 196);
			this.tabBank.TabIndex = 83;
			this.tabBank.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
																					this.tabPage_1,
																					this.tabPage_2,
																					this.tabPage_3});
			this.tabBank.Text = "TabBank";
			// 
			// tabPage_1
			// 
			this.tabPage_1.Controls.Add(this.grid_BankBranch);
			this.tabPage_1.Name = "tabPage_1";
			this.tabPage_1.Size = new System.Drawing.Size(791, 163);
			this.tabPage_1.Text = "Branch";
			// 
			// grid_BankBranch
			// 
			// 
			// grid_BankBranch.EmbeddedNavigator
			// 
			this.grid_BankBranch.EmbeddedNavigator.Name = "";
			this.grid_BankBranch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			gridLevelNode1.RelationName = "Level1";
			this.grid_BankBranch.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
																									  gridLevelNode1});
			this.grid_BankBranch.Location = new System.Drawing.Point(0, 8);
			this.grid_BankBranch.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.grid_BankBranch.LookAndFeel.UseDefaultLookAndFeel = false;
			this.grid_BankBranch.MainView = this.gridView_BankBranch;
			this.grid_BankBranch.Name = "grid_BankBranch";
			this.grid_BankBranch.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																													 this.repositoryItemLookUpEdit1});
			this.grid_BankBranch.Size = new System.Drawing.Size(544, 144);
			this.grid_BankBranch.TabIndex = 124;
			this.grid_BankBranch.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										   this.gridView_BankBranch});
			// 
			// gridView_BankBranch
			// 
			this.gridView_BankBranch.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																									   this.strBankBranchCode,
																									   this.BankBranchDescription});
			this.gridView_BankBranch.GridControl = this.grid_BankBranch;
			this.gridView_BankBranch.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
			this.gridView_BankBranch.Name = "gridView_BankBranch";
			this.gridView_BankBranch.OptionsCustomization.AllowColumnMoving = false;
			this.gridView_BankBranch.OptionsCustomization.AllowFilter = false;
			this.gridView_BankBranch.OptionsCustomization.AllowSort = false;
			this.gridView_BankBranch.OptionsView.ColumnAutoWidth = false;
			this.gridView_BankBranch.OptionsView.ShowGroupPanel = false;
			this.gridView_BankBranch.LostFocus += new System.EventHandler(this.gridView_BankBranch_LostFocus);
			// 
			// strBankBranchCode
			// 
			this.strBankBranchCode.Caption = "Bank Branch Code";
			this.strBankBranchCode.FieldName = "strBankBranchCode";
			this.strBankBranchCode.Name = "strBankBranchCode";
			this.strBankBranchCode.Visible = true;
			this.strBankBranchCode.VisibleIndex = 0;
			this.strBankBranchCode.Width = 116;
			// 
			// BankBranchDescription
			// 
			this.BankBranchDescription.Caption = "Description ";
			this.BankBranchDescription.FieldName = "strDescription";
			this.BankBranchDescription.Name = "BankBranchDescription";
			this.BankBranchDescription.Visible = true;
			this.BankBranchDescription.VisibleIndex = 1;
			this.BankBranchDescription.Width = 413;
			// 
			// repositoryItemLookUpEdit1
			// 
			this.repositoryItemLookUpEdit1.AutoHeight = false;
			this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
			// 
			// tabPage_2
			// 
			this.tabPage_2.Controls.Add(this.gridBankIpp);
			this.tabPage_2.Name = "tabPage_2";
			this.tabPage_2.Size = new System.Drawing.Size(791, 163);
			this.tabPage_2.Text = "IPP Rate";
			// 
			// gridBankIpp
			// 
			// 
			// gridBankIpp.EmbeddedNavigator
			// 
			this.gridBankIpp.EmbeddedNavigator.Name = "";
			this.gridBankIpp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			gridLevelNode2.RelationName = "Level1";
			this.gridBankIpp.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
																								  gridLevelNode2});
			this.gridBankIpp.Location = new System.Drawing.Point(0, 8);
			this.gridBankIpp.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.gridBankIpp.LookAndFeel.UseDefaultLookAndFeel = false;
			this.gridBankIpp.MainView = this.gridView_BankIpp;
			this.gridBankIpp.Name = "gridBankIpp";
			this.gridBankIpp.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																												 this.repositoryItemLookUpEdit2});
			this.gridBankIpp.Size = new System.Drawing.Size(544, 144);
			this.gridBankIpp.TabIndex = 129;
			this.gridBankIpp.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																									   this.gridView_BankIpp});
			// 
			// gridView_BankIpp
			// 
			this.gridView_BankIpp.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																									this.nMonth,
																									this.dInterestRate});
			this.gridView_BankIpp.GridControl = this.gridBankIpp;
			this.gridView_BankIpp.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
			this.gridView_BankIpp.Name = "gridView_BankIpp";
			this.gridView_BankIpp.OptionsCustomization.AllowColumnMoving = false;
			this.gridView_BankIpp.OptionsCustomization.AllowFilter = false;
			this.gridView_BankIpp.OptionsCustomization.AllowSort = false;
			this.gridView_BankIpp.OptionsView.ColumnAutoWidth = false;
			this.gridView_BankIpp.OptionsView.ShowGroupPanel = false;
			this.gridView_BankIpp.LostFocus += new System.EventHandler(this.gridView_BankIPP_LostFocus);
			// 
			// nMonth
			// 
			this.nMonth.Caption = "No. of Month";
			this.nMonth.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.nMonth.FieldName = "nMonth";
			this.nMonth.Name = "nMonth";
			this.nMonth.Visible = true;
			this.nMonth.VisibleIndex = 0;
			this.nMonth.Width = 116;
			// 
			// dInterestRate
			// 
			this.dInterestRate.Caption = "Interest Rate";
			this.dInterestRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.dInterestRate.FieldName = "dInterestRate";
			this.dInterestRate.Name = "dInterestRate";
			this.dInterestRate.Visible = true;
			this.dInterestRate.VisibleIndex = 1;
			this.dInterestRate.Width = 413;
			// 
			// repositoryItemLookUpEdit2
			// 
			this.repositoryItemLookUpEdit2.AutoHeight = false;
			this.repositoryItemLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemLookUpEdit2.Name = "repositoryItemLookUpEdit2";
			// 
			// tabPage_3
			// 
			this.tabPage_3.Controls.Add(this.gridBankMerchant);
			this.tabPage_3.Name = "tabPage_3";
			this.tabPage_3.Size = new System.Drawing.Size(791, 163);
			this.tabPage_3.Text = "Merchant Code";
			// 
			// gridBankMerchant
			// 
			// 
			// gridBankMerchant.EmbeddedNavigator
			// 
			this.gridBankMerchant.EmbeddedNavigator.Name = "";
			this.gridBankMerchant.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			gridLevelNode3.RelationName = "Level1";
			this.gridBankMerchant.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
																									   gridLevelNode3});
			this.gridBankMerchant.Location = new System.Drawing.Point(0, 8);
			this.gridBankMerchant.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.gridBankMerchant.LookAndFeel.UseDefaultLookAndFeel = false;
			this.gridBankMerchant.MainView = this.gridView_BankMerchant;
			this.gridBankMerchant.Name = "gridBankMerchant";
			this.gridBankMerchant.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																													  this.repositoryItemLookUpEdit3});
			this.gridBankMerchant.Size = new System.Drawing.Size(472, 144);
			this.gridBankMerchant.TabIndex = 132;
			this.gridBankMerchant.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																											this.gridView_BankMerchant});
			// 
			// gridView_BankMerchant
			// 
			this.gridView_BankMerchant.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																										 this.strBranchCode,
																										 this.gridColumn1,
																										 this.strMerchantNo});
			this.gridView_BankMerchant.GridControl = this.gridBankMerchant;
			this.gridView_BankMerchant.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
			this.gridView_BankMerchant.Name = "gridView_BankMerchant";
			this.gridView_BankMerchant.OptionsCustomization.AllowColumnMoving = false;
			this.gridView_BankMerchant.OptionsCustomization.AllowFilter = false;
			this.gridView_BankMerchant.OptionsCustomization.AllowSort = false;
			this.gridView_BankMerchant.OptionsView.ColumnAutoWidth = false;
			this.gridView_BankMerchant.OptionsView.ShowGroupPanel = false;
			this.gridView_BankMerchant.LostFocus += new System.EventHandler(this.gridView_BankMerchant_LostFocus);
			// 
			// strBranchCode
			// 
			this.strBranchCode.Caption = "Company Branch Code";
			this.strBranchCode.FieldName = "strBranchCode";
			this.strBranchCode.Name = "strBranchCode";
			this.strBranchCode.Visible = true;
			this.strBranchCode.VisibleIndex = 0;
			this.strBranchCode.Width = 130;
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "No. of Month";
			this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumn1.FieldName = "nMonth";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 1;
			this.gridColumn1.Width = 116;
			// 
			// strMerchantNo
			// 
			this.strMerchantNo.Caption = "Merchant No.";
			this.strMerchantNo.FieldName = "strMerchantNo";
			this.strMerchantNo.Name = "strMerchantNo";
			this.strMerchantNo.Visible = true;
			this.strMerchantNo.VisibleIndex = 2;
			this.strMerchantNo.Width = 96;
			// 
			// repositoryItemLookUpEdit3
			// 
			this.repositoryItemLookUpEdit3.AutoHeight = false;
			this.repositoryItemLookUpEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemLookUpEdit3.Name = "repositoryItemLookUpEdit3";
			// 
			// btn_Bottom_Del
			// 
			this.btn_Bottom_Del.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btn_Bottom_Del.Appearance.Options.UseFont = true;
			this.btn_Bottom_Del.Appearance.Options.UseTextOptions = true;
			this.btn_Bottom_Del.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.btn_Bottom_Del.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
			this.btn_Bottom_Del.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.btn_Bottom_Del.ImageIndex = 1;
			this.btn_Bottom_Del.ImageList = this.imageList1;
			this.btn_Bottom_Del.Location = new System.Drawing.Point(48, 24);
			this.btn_Bottom_Del.Name = "btn_Bottom_Del";
			this.btn_Bottom_Del.Size = new System.Drawing.Size(38, 16);
			this.btn_Bottom_Del.TabIndex = 122;
			this.btn_Bottom_Del.Click += new System.EventHandler(this.btn_Bottom_Del_Click);
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
			// 
			// btn_Bottom_Add
			// 
			this.btn_Bottom_Add.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btn_Bottom_Add.Appearance.Options.UseFont = true;
			this.btn_Bottom_Add.Appearance.Options.UseTextOptions = true;
			this.btn_Bottom_Add.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.btn_Bottom_Add.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
			this.btn_Bottom_Add.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.btn_Bottom_Add.ImageIndex = 0;
			this.btn_Bottom_Add.ImageList = this.imageList1;
			this.btn_Bottom_Add.Location = new System.Drawing.Point(8, 24);
			this.btn_Bottom_Add.Name = "btn_Bottom_Add";
			this.btn_Bottom_Add.Size = new System.Drawing.Size(38, 16);
			this.btn_Bottom_Add.TabIndex = 123;
			this.btn_Bottom_Add.Click += new System.EventHandler(this.btn_Bottom_Add_Click);
			// 
			// sBtnAdd
			// 
			this.sBtnAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
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
			this.sBtnSubtract.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
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
			// gridControlMd_Bank
			// 
			// 
			// gridControlMd_Bank.EmbeddedNavigator
			// 
			this.gridControlMd_Bank.EmbeddedNavigator.Name = "";
			this.gridControlMd_Bank.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			gridLevelNode4.RelationName = "Level1";
			this.gridControlMd_Bank.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
																										 gridLevelNode4});
			this.gridControlMd_Bank.Location = new System.Drawing.Point(2, 46);
			this.gridControlMd_Bank.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.gridControlMd_Bank.LookAndFeel.UseDefaultLookAndFeel = false;
			this.gridControlMd_Bank.MainView = this.gridViewMd_Bank;
			this.gridControlMd_Bank.Name = "gridControlMd_Bank";
			this.gridControlMd_Bank.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																														this.lk_ManagerID});
			this.gridControlMd_Bank.Size = new System.Drawing.Size(972, 186);
			this.gridControlMd_Bank.TabIndex = 17;
			this.gridControlMd_Bank.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																											  this.gridViewMd_Bank});
			// 
			// gridViewMd_Bank
			// 
			this.gridViewMd_Bank.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																								   this.strBankCode,
																								   this.strDescription,
																								   this.strIPP});
			this.gridViewMd_Bank.GridControl = this.gridControlMd_Bank;
			this.gridViewMd_Bank.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
			this.gridViewMd_Bank.Name = "gridViewMd_Bank";
			this.gridViewMd_Bank.OptionsCustomization.AllowColumnMoving = false;
			this.gridViewMd_Bank.OptionsCustomization.AllowFilter = false;
			this.gridViewMd_Bank.OptionsCustomization.AllowSort = false;
			this.gridViewMd_Bank.OptionsView.ColumnAutoWidth = false;
			this.gridViewMd_Bank.OptionsView.ShowGroupPanel = false;
			this.gridViewMd_Bank.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.InitBankBottom);
			this.gridViewMd_Bank.LostFocus += new System.EventHandler(this.gridViewMd_Bank_LostFocus);
			// 
			// strBankCode
			// 
			this.strBankCode.Caption = "Bank Code";
			this.strBankCode.FieldName = "strBankCode";
			this.strBankCode.Name = "strBankCode";
			this.strBankCode.Visible = true;
			this.strBankCode.VisibleIndex = 0;
			this.strBankCode.Width = 92;
			// 
			// strDescription
			// 
			this.strDescription.Caption = "Description ";
			this.strDescription.FieldName = "strDescription";
			this.strDescription.Name = "strDescription";
			this.strDescription.Visible = true;
			this.strDescription.VisibleIndex = 1;
			this.strDescription.Width = 298;
			// 
			// strIPP
			// 
			this.strIPP.Caption = "IPP Code";
			this.strIPP.FieldName = "strIPP";
			this.strIPP.Name = "strIPP";
			this.strIPP.Visible = true;
			this.strIPP.VisibleIndex = 2;
			this.strIPP.Width = 137;
			// 
			// lk_ManagerID
			// 
			this.lk_ManagerID.AutoHeight = false;
			this.lk_ManagerID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																									  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lk_ManagerID.Name = "lk_ManagerID";
			// 
			// frmBank
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(752, 454);
			this.Controls.Add(this.grpMdBankTop);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmBank";
			this.Text = "frmBank";
			((System.ComponentModel.ISupportInitialize)(this.grpMdBankTop)).EndInit();
			this.grpMdBankTop.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grpMdBankBottom)).EndInit();
			this.grpMdBankBottom.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.tabBank)).EndInit();
			this.tabBank.ResumeLayout(false);
			this.tabPage_1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grid_BankBranch)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView_BankBranch)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
			this.tabPage_2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridBankIpp)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView_BankIpp)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).EndInit();
			this.tabPage_3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridBankMerchant)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView_BankMerchant)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControlMd_Bank)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewMd_Bank)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_ManagerID)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private DataTable dtBankBranch;
		private DataTable dtBankIppRate;
		private DataTable dtBankMerchant;

		private void InitBankBottom(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
			init_BankBranch();
			init_BankIpp();
			init_BankMerchant();
		}

		private void init_BankBranch()
		{
			DataRow row = this.gridViewMd_Bank.GetDataRow(gridViewMd_Bank.FocusedRowHandle);

			DataSet _ds = new DataSet(); 
			DataTable dt = _ds.Tables["Table"];

			_ds = new DataSet(); 
			
			string strSQL = "select * from tblBankBranch where strBankCode='" + row["strBankCode"].ToString() + "'" ;
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			dtBankBranch = _ds.Tables["table"];
			grid_BankBranch.DataSource= dtBankBranch;
		}

		private void init_BankIpp()
		{
			DataRow row = this.gridViewMd_Bank.GetDataRow(gridViewMd_Bank.FocusedRowHandle);

			DataSet _ds = new DataSet(); 
			DataTable dt = _ds.Tables["Table"];

			_ds = new DataSet(); 
			
			string strSQL = "select * from tblBankIPPRate where strBankCode='" + row["strBankCode"].ToString() + "'" ;
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			dtBankIppRate = _ds.Tables["table"];
			gridBankIpp.DataSource= dtBankIppRate;
		}

		private void init_BankMerchant()
		{
			DataRow row = this.gridViewMd_Bank.GetDataRow(gridViewMd_Bank.FocusedRowHandle);

			DataSet _ds = new DataSet(); 
			DataTable dt = _ds.Tables["Table"];

			_ds = new DataSet(); 
			
			string strSQL = "select * from tblBanklPPMerchant where strBankCode='" + row["strBankCode"].ToString() + "'" ;
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			dtBankMerchant = _ds.Tables["table"];
			gridBankMerchant.DataSource= dtBankMerchant;
		}

		private bool AddNew;

		private void sBtnAdd_Click(object sender, System.EventArgs e)
		{
			AddNew = true;
			DataRow dr = dtBank.NewRow();
			dtBank.Rows.Add(dr);
			this.gridControlMd_Bank.Refresh();
			this.gridViewMd_Bank.FocusedRowHandle = dtBank.Rows.Count - 1;
		}

		private void sBtnSubtract_Click(object sender, System.EventArgs e)
		{
			DataRow row = gridViewMd_Bank.GetDataRow(gridViewMd_Bank.FocusedRowHandle);
				if (row != null)
				{
	
					if (AddNew)
					{
						AddNew = false;
						gridViewMd_Bank.DeleteRow(gridViewMd_Bank.FocusedRowHandle);
					}
					else
					{

						DialogResult result = MessageBox.Show(this, "Do you really want to delete record with Bank Code = " + row["strBankCode"].ToString(),
							"Delete?", MessageBoxButtons.YesNo);
						if (result == DialogResult.Yes)
						{
							try
							{
								SqlHelper.ExecuteNonQuery(connection,"del_Bank",
									new SqlParameter("@strBankCode",row["strBankCode"].ToString() )
									);
							}
							catch(Exception ex)
							{
								MessageBox.Show(ex.Message ,"Delete Process Failed");
								return;
							}
							MessageBox.Show("Record Deleted Successfully","Message");
						}
						mdBankInit();
					}
				}
		}

		private void btn_Bottom_Add_Click(object sender, System.EventArgs e)
		{
			if (tabBank.SelectedTabPage.Text == "Branch")
			{
				AddNew = true;
				DataRow dr = dtBankBranch.NewRow();
				dtBankBranch.Rows.Add(dr);
				this.grid_BankBranch.Refresh();
				this.gridView_BankBranch.FocusedRowHandle = dtBankBranch.Rows.Count - 1;
			}
			else if (tabBank.SelectedTabPage.Text == "IPP Rate")
			{
				AddNew = true;
				DataRow dr = dtBankIppRate.NewRow();
				dtBankIppRate.Rows.Add(dr);
				this.gridBankIpp.Refresh();
				this.gridView_BankIpp.FocusedRowHandle = dtBankIppRate.Rows.Count - 1;
			}
			else if (tabBank.SelectedTabPage.Text == "Merchant Code")
			{
				AddNew = true;
				DataRow dr = dtBankMerchant.NewRow();
				dtBankMerchant.Rows.Add(dr);
				this.gridBankMerchant.Refresh();
				this.gridView_BankMerchant.FocusedRowHandle = dtBankMerchant.Rows.Count - 1;
			}

		}

		private void del_Ipp()
		{
			DataRow row = gridView_BankIpp.GetDataRow(gridView_BankIpp.FocusedRowHandle);
			if (row != null)
			{
	
				if (AddNew)
				{
					AddNew = false;
					gridView_BankIpp.DeleteRow(gridView_BankIpp.FocusedRowHandle);
				}
				else
				{

					DialogResult result = MessageBox.Show(this, "Do you really want to delete this record ?","Delete?", MessageBoxButtons.YesNo);
					if (result == DialogResult.Yes)
					{
						try
						{
							SqlHelper.ExecuteNonQuery(connection,"del_TblBankIpp",
								new SqlParameter("@strBankCode",row["strBankCode"].ToString()),
								new SqlParameter("@nMonth",row["nMonth"])

								);
						}
						catch(Exception ex)
						{
							MessageBox.Show(ex.Message ,"Delete Process Failed");
							return;
						}
						MessageBox.Show("Record Deleted Successfully","Message");
					}
					init_BankIpp();
				}
			}
		}

		private void del_Merchant()
		{
			DataRow row = gridView_BankMerchant.GetDataRow(gridView_BankMerchant.FocusedRowHandle);
			if (row != null)
			{
	
				if (AddNew)
				{
					AddNew = false;
					gridView_BankMerchant.DeleteRow(gridView_BankMerchant.FocusedRowHandle);
				}
				else
				{

					DialogResult result = MessageBox.Show(this, "Do you really want to delete this record ?","Delete?", MessageBoxButtons.YesNo);
					if (result == DialogResult.Yes)
					{
						try
						{
							SqlHelper.ExecuteNonQuery(connection,"del_TblBankMerchant",
								new SqlParameter("@strBankCode",row["strBankCode"].ToString()),
								new SqlParameter("@strBranchCode",row["strBranchCode"].ToString()),
								new SqlParameter("@nMonth",row["nMonth"])
								);
						}
						catch(Exception ex)
						{
							MessageBox.Show(ex.Message ,"Delete Process Failed");
							return;
						}
						MessageBox.Show("Record Deleted Successfully","Message");
					}
					init_BankMerchant();
				}
			}
		}


		private void del_BankBranch()
		{
			DataRow row = gridView_BankBranch.GetDataRow(gridView_BankBranch.FocusedRowHandle);
			if (row != null)
			{
	
				if (AddNew)
				{
					AddNew = false;
					gridView_BankBranch.DeleteRow(gridView_BankBranch.FocusedRowHandle);
				}
				else
				{

					DialogResult result = MessageBox.Show(this, "Do you really want to delete record with Bank Bracnh Code = " + row["strBankBranchCode"].ToString(),
						"Delete?", MessageBoxButtons.YesNo);
					if (result == DialogResult.Yes)
					{
						try
						{
							SqlHelper.ExecuteNonQuery(connection,"del_TblBankBranch",
								new SqlParameter("@strBankCode",row["strBankCode"].ToString()),
								new SqlParameter("@strBankBranchCode",row["strBankBranchCode"].ToString())

								);
						}
						catch(Exception ex)
						{
							MessageBox.Show(ex.Message ,"Delete Process Failed");
							return;
						}
						MessageBox.Show("Record Deleted Successfully","Message");
					}
					init_BankBranch();
				}
			}
		}

		private void btn_Bottom_Del_Click(object sender, System.EventArgs e)
		{
			if (tabBank.SelectedTabPage.Text == "Branch")
			{
				del_BankBranch();
			}
			else if (tabBank.SelectedTabPage.Text == "IPP Rate")
			{
				del_Ipp();
			}
			else if (tabBank.SelectedTabPage.Text == "Merchant Code")
			{
				del_Merchant();
			}
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
		
		private bool mdBank_FieldValidation(DataRow dr)
		{
			if (dr["strBankCode"].ToString() == "")
				return false;

			return true;
		}

		private void gridViewMd_Bank_LostFocus(object sender, System.EventArgs e)
		{
			DataRow row = this.gridViewMd_Bank.GetDataRow(gridViewMd_Bank.FocusedRowHandle);
			
			string strSQL = "Select * from tblBank";
			if (AddNew)
			{
				if(mdBank_FieldValidation(row))
				{
					this.gridControlMd_Bank.MainView.UpdateCurrentRow();
					CreateCmdsAndUpdate(strSQL,dtBank);
					AddNew = false;
				}
			}
			else
			{
				gridViewMd_Bank.CloseEditor();
				gridViewMd_Bank.UpdateCurrentRow();

				CreateCmdsAndUpdate(strSQL,dtBank);
			}
		}

		private void gridView_BankBranch_LostFocus(object sender, System.EventArgs e)
		{
			DataRow MasterRow = gridViewMd_Bank.GetDataRow(gridViewMd_Bank.FocusedRowHandle);

			DataRow row = this.gridView_BankBranch.GetDataRow(gridView_BankBranch.FocusedRowHandle);
			
			string strSQL = "Select * from tblBankBranch";
			if (AddNew)
			{
				row["strBankCode"]= MasterRow["strBankCode"].ToString();

				if(CheckClassTypeField((row)))
				{
					this.grid_BankBranch.MainView.UpdateCurrentRow();
					CreateCmdsAndUpdate(strSQL,dtBankBranch);
					AddNew = false;
				}
			}
			else	
			{
				gridView_BankBranch.CloseEditor();
				gridView_BankBranch.UpdateCurrentRow();

				CreateCmdsAndUpdate(strSQL,dtBankBranch);
			}
		}

		private void gridView_BankMerchant_LostFocus(object sender, System.EventArgs e)
		{
			DataRow MasterRow = gridViewMd_Bank.GetDataRow(gridViewMd_Bank.FocusedRowHandle);

			DataRow row = this.gridView_BankMerchant.GetDataRow(gridView_BankMerchant.FocusedRowHandle);
			
			string strSQL = "Select * from tblBanklPPMerchant";
			if (AddNew)
			{
				row["strBankCode"]= MasterRow["strBankCode"].ToString();

				if(CheckClassTypeField((row)))
				{
					this.gridBankMerchant.MainView.UpdateCurrentRow();
					CreateCmdsAndUpdate(strSQL,dtBankMerchant);
					AddNew = false;
				}
			}
			else
			{
				gridView_BankMerchant.CloseEditor();
				gridView_BankMerchant.UpdateCurrentRow();

				CreateCmdsAndUpdate(strSQL,dtBankMerchant);
			}
		}


		private void gridView_BankIPP_LostFocus(object sender, System.EventArgs e)
		{
			DataRow MasterRow = gridViewMd_Bank.GetDataRow(gridViewMd_Bank.FocusedRowHandle);

			DataRow row = this.gridView_BankIpp.GetDataRow(gridView_BankIpp.FocusedRowHandle);
			
			string strSQL = "Select * from tblBankIppRate";
			if (AddNew)
			{
				row["strBankCode"]= MasterRow["strBankCode"].ToString();

				if(CheckClassTypeField((row)))
				{
					this.gridBankIpp.MainView.UpdateCurrentRow();
					CreateCmdsAndUpdate(strSQL,dtBankIppRate);
					AddNew = false;
				}
			}
			else
			{
				gridView_BankIpp.CloseEditor();
				gridView_BankIpp.UpdateCurrentRow();

				CreateCmdsAndUpdate(strSQL,dtBankIppRate);
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
		
	}
}

