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
	/// Summary description for frmReceipt.
	/// </summary>
	public class frmReceipt : System.Windows.Forms.Form
	{
		private string connectionString;
		private SqlConnection connection;
        private DevExpress.XtraEditors.GroupControl grpMdReceipt;
		private DevExpress.XtraEditors.GroupControl groupControl2;
		private DevExpress.XtraGrid.GridControl gridControlMd_Receipt;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewMd_Receipt;
        private System.Windows.Forms.ImageList imageList1;
		private System.ComponentModel.IContainer components;
        private DataTable dtClassType;
		private DevExpress.XtraGrid.Columns.GridColumn strReceiptNo;
		private DevExpress.XtraGrid.Columns.GridColumn strMembershipID;
        private DevExpress.XtraGrid.Columns.GridColumn strBranchCode;
        private DevExpress.XtraGrid.Columns.GridColumn nCategoryID;
        private DevExpress.XtraGrid.Columns.GridColumn dtDate;
        private DevExpress.XtraGrid.Columns.GridColumn nSalespersonID;
        private DevExpress.XtraGrid.Columns.GridColumn nCashierID;
        private DevExpress.XtraGrid.Columns.GridColumn nShiftID;
        private DevExpress.XtraGrid.Columns.GridColumn nTerminalID;
        private DevExpress.XtraGrid.Columns.GridColumn mNettAmount;
        private DevExpress.XtraGrid.Columns.GridColumn mGSTAmount;
        private DevExpress.XtraGrid.Columns.GridColumn mTotalAmount;
        private DevExpress.XtraGrid.Columns.GridColumn strDiscountCode;
        private DevExpress.XtraGrid.Columns.GridColumn strFreebieCode;
        private DevExpress.XtraGrid.Columns.GridColumn nTaxID;
        private DevExpress.XtraGrid.Columns.GridColumn mVoucherTypeID;
        private DevExpress.XtraGrid.Columns.GridColumn mVoucherAmount;
        private DevExpress.XtraGrid.Columns.GridColumn nTherapistID;
        private DevExpress.XtraGrid.Columns.GridColumn strRewardsCode;
        private DevExpress.XtraGrid.Columns.GridColumn fVoid;
        private DevExpress.XtraGrid.Columns.GridColumn strReferenceNo;
        private DevExpress.XtraGrid.Columns.GridColumn strParentReceiptNo;
        private DevExpress.XtraGrid.Columns.GridColumn mOutstandingAmount;
        private DevExpress.XtraGrid.Columns.GridColumn strRemarks;
        private DevExpress.XtraGrid.Columns.GridColumn fDeposit;
        private DevExpress.XtraGrid.Columns.GridColumn mBalance;
        private DevExpress.XtraGrid.Columns.GridColumn strBillReferenceNo;
        private DevExpress.XtraGrid.Columns.GridColumn strLocation;
        private DevExpress.XtraGrid.Columns.GridColumn dtDateTime;
        private DevExpress.XtraGrid.Columns.GridColumn mUpgradeAmount;
        private DevExpress.XtraGrid.Columns.GridColumn fRefund;
        private DevExpress.XtraGrid.Columns.GridColumn strChequeNo;
        private DevExpress.XtraGrid.Columns.GridColumn mRefundAmount;
        private DevExpress.XtraGrid.Columns.GridColumn nChequeUpdateBy;
        private DevExpress.XtraGrid.Columns.GridColumn mDiscountAmount;
        private DevExpress.XtraGrid.Columns.GridColumn strSignedPDFPath;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraTab.XtraTabControl tabCtrlMd_Freebie;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraGrid.GridControl gridControlMd_Freebie;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewMd_Freebie;
        private DevExpress.XtraGrid.Columns.GridColumn nFreebieID;
        private DevExpress.XtraGrid.Columns.GridColumn nEntryID;
        private DevExpress.XtraGrid.Columns.GridColumn strReceiptNo1;
        private DevExpress.XtraGrid.Columns.GridColumn strItemCode;
        private DevExpress.XtraGrid.Columns.GridColumn strPromotionCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_RPClassType;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraGrid.GridControl gridControlMd_Entries;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewMd_Entries;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private DevExpress.XtraGrid.GridControl gridControlMd_Payment;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewMd_Payment;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraEditors.ImageComboBoxEdit ddlReceiptCategory;
        private Label label31;
        private Panel Searchpanel;
        internal DevExpress.XtraEditors.SimpleButton btn_Search;
        internal DevExpress.XtraEditors.TextEdit txtSearch;
		private DataTable dtFreebie;
        private DataTable dtEntry;
        private DataTable dtPayment;

		public frmReceipt()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReceipt));
            this.grpMdReceipt = new DevExpress.XtraEditors.GroupControl();
            this.Searchpanel = new System.Windows.Forms.Panel();
            this.btn_Search = new DevExpress.XtraEditors.SimpleButton();
            this.txtSearch = new DevExpress.XtraEditors.TextEdit();
            this.ddlReceiptCategory = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.label31 = new System.Windows.Forms.Label();
            this.tabCtrlMd_Freebie = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlMd_Freebie = new DevExpress.XtraGrid.GridControl();
            this.gridViewMd_Freebie = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.nFreebieID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nEntryID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.strReceiptNo1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.strItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.strPromotionCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lk_RPClassType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlMd_Entries = new DevExpress.XtraGrid.GridControl();
            this.gridViewMd_Entries = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlMd_Payment = new DevExpress.XtraGrid.GridControl();
            this.gridViewMd_Payment = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gridControlMd_Receipt = new DevExpress.XtraGrid.GridControl();
            this.gridViewMd_Receipt = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.strReceiptNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.strMembershipID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.strBranchCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nCategoryID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dtDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nSalespersonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nCashierID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nShiftID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nTerminalID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mNettAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mGSTAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mTotalAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.strDiscountCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.strFreebieCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nTaxID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mVoucherTypeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mVoucherAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nTherapistID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.strRewardsCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.fVoid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.strReferenceNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.strParentReceiptNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mOutstandingAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.strRemarks = new DevExpress.XtraGrid.Columns.GridColumn();
            this.fDeposit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mBalance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.strBillReferenceNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.strLocation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dtDateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mUpgradeAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.fRefund = new DevExpress.XtraGrid.Columns.GridColumn();
            this.strChequeNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mRefundAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nChequeUpdateBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mDiscountAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.strSignedPDFPath = new DevExpress.XtraGrid.Columns.GridColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.grpMdReceipt)).BeginInit();
            this.grpMdReceipt.SuspendLayout();
            this.Searchpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlReceiptCategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabCtrlMd_Freebie)).BeginInit();
            this.tabCtrlMd_Freebie.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMd_Freebie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMd_Freebie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_RPClassType)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMd_Entries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMd_Entries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            this.xtraTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMd_Payment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMd_Payment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMd_Receipt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMd_Receipt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // grpMdReceipt
            // 
            this.grpMdReceipt.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.grpMdReceipt.Appearance.Options.UseBackColor = true;
            this.grpMdReceipt.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.grpMdReceipt.Controls.Add(this.Searchpanel);
            this.grpMdReceipt.Controls.Add(this.ddlReceiptCategory);
            this.grpMdReceipt.Controls.Add(this.label31);
            this.grpMdReceipt.Controls.Add(this.tabCtrlMd_Freebie);
            this.grpMdReceipt.Controls.Add(this.groupControl2);
            this.grpMdReceipt.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grpMdReceipt.Location = new System.Drawing.Point(8, 0);
            this.grpMdReceipt.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.grpMdReceipt.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grpMdReceipt.Name = "grpMdReceipt";
            this.grpMdReceipt.Size = new System.Drawing.Size(970, 560);
            this.grpMdReceipt.TabIndex = 33;
            this.grpMdReceipt.Text = "Class";
            // 
            // Searchpanel
            // 
            this.Searchpanel.Controls.Add(this.btn_Search);
            this.Searchpanel.Controls.Add(this.txtSearch);
            this.Searchpanel.Location = new System.Drawing.Point(498, 22);
            this.Searchpanel.Name = "Searchpanel";
            this.Searchpanel.Size = new System.Drawing.Size(464, 24);
            this.Searchpanel.TabIndex = 153;
            // 
            // btn_Search
            // 
            this.btn_Search.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_Search.Appearance.Options.UseFont = true;
            this.btn_Search.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btn_Search.Location = new System.Drawing.Point(392, 3);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(56, 20);
            this.btn_Search.TabIndex = 137;
            this.btn_Search.Text = "Search";
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.EditValue = "";
            this.txtSearch.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtSearch.Location = new System.Drawing.Point(232, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Properties.Appearance.Options.UseFont = true;
            this.txtSearch.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtSearch.Size = new System.Drawing.Size(152, 20);
            this.txtSearch.TabIndex = 136;
            // 
            // ddlReceiptCategory
            // 
            this.ddlReceiptCategory.EditValue = 0;
            this.ddlReceiptCategory.Location = new System.Drawing.Point(79, 25);
            this.ddlReceiptCategory.Name = "ddlReceiptCategory";
            this.ddlReceiptCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlReceiptCategory.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.ddlReceiptCategory.Properties.SmallImages = "";
            this.ddlReceiptCategory.Size = new System.Drawing.Size(176, 20);
            this.ddlReceiptCategory.TabIndex = 136;
            this.ddlReceiptCategory.SelectedIndexChanged += new System.EventHandler(this.ddlReceiptCategory_SelectedIndexChanged);
            // 
            // label31
            // 
            this.label31.BackColor = System.Drawing.Color.Transparent;
            this.label31.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(6, 26);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(136, 16);
            this.label31.TabIndex = 137;
            this.label31.Text = "Category";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabCtrlMd_Freebie
            // 
            this.tabCtrlMd_Freebie.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabCtrlMd_Freebie.Appearance.Options.UseFont = true;
            this.tabCtrlMd_Freebie.AppearancePage.Header.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabCtrlMd_Freebie.AppearancePage.Header.Options.UseFont = true;
            this.tabCtrlMd_Freebie.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabCtrlMd_Freebie.Location = new System.Drawing.Point(2, 302);
            this.tabCtrlMd_Freebie.LookAndFeel.UseDefaultLookAndFeel = false;
            this.tabCtrlMd_Freebie.Name = "tabCtrlMd_Freebie";
            this.tabCtrlMd_Freebie.SelectedTabPage = this.xtraTabPage1;
            this.tabCtrlMd_Freebie.Size = new System.Drawing.Size(966, 256);
            this.tabCtrlMd_Freebie.TabIndex = 135;
            this.tabCtrlMd_Freebie.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.gridControlMd_Freebie);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(957, 222);
            this.xtraTabPage1.Text = "Freebies";
            // 
            // gridControlMd_Freebie
            // 
            this.gridControlMd_Freebie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlMd_Freebie.Location = new System.Drawing.Point(0, 0);
            this.gridControlMd_Freebie.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControlMd_Freebie.MainView = this.gridViewMd_Freebie;
            this.gridControlMd_Freebie.Name = "gridControlMd_Freebie";
            this.gridControlMd_Freebie.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lk_RPClassType});
            this.gridControlMd_Freebie.Size = new System.Drawing.Size(957, 222);
            this.gridControlMd_Freebie.TabIndex = 128;
            this.gridControlMd_Freebie.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMd_Freebie});
            // 
            // gridViewMd_Freebie
            // 
            this.gridViewMd_Freebie.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.nFreebieID,
            this.nEntryID,
            this.strReceiptNo1,
            this.strItemCode,
            this.strPromotionCode});
            this.gridViewMd_Freebie.GridControl = this.gridControlMd_Freebie;
            this.gridViewMd_Freebie.Name = "gridViewMd_Freebie";
            this.gridViewMd_Freebie.OptionsCustomization.AllowFilter = false;
            this.gridViewMd_Freebie.OptionsCustomization.AllowSort = false;
            this.gridViewMd_Freebie.OptionsView.ShowGroupPanel = false;
            this.gridViewMd_Freebie.LostFocus += new System.EventHandler(this.gridViewMd_Freebie_LostFocus);
            // 
            // nFreebieID
            // 
            this.nFreebieID.Caption = "FreebieID";
            this.nFreebieID.FieldName = "nFreebieID";
            this.nFreebieID.Name = "nFreebieID";
            this.nFreebieID.Visible = true;
            this.nFreebieID.VisibleIndex = 0;
            // 
            // nEntryID
            // 
            this.nEntryID.Caption = "EntryID";
            this.nEntryID.FieldName = "nEntryID";
            this.nEntryID.Name = "nEntryID";
            this.nEntryID.Visible = true;
            this.nEntryID.VisibleIndex = 1;
            // 
            // strReceiptNo1
            // 
            this.strReceiptNo1.Caption = "ReceiptNo";
            this.strReceiptNo1.FieldName = "strReceiptNo";
            this.strReceiptNo1.Name = "strReceiptNo1";
            this.strReceiptNo1.Visible = true;
            this.strReceiptNo1.VisibleIndex = 2;
            // 
            // strItemCode
            // 
            this.strItemCode.Caption = "ItemCode";
            this.strItemCode.FieldName = "strItemCode";
            this.strItemCode.Name = "strItemCode";
            this.strItemCode.Visible = true;
            this.strItemCode.VisibleIndex = 3;
            // 
            // strPromotionCode
            // 
            this.strPromotionCode.Caption = "PromotionCode";
            this.strPromotionCode.FieldName = "strPromotionCode";
            this.strPromotionCode.Name = "strPromotionCode";
            this.strPromotionCode.Visible = true;
            this.strPromotionCode.VisibleIndex = 4;
            // 
            // lk_RPClassType
            // 
            this.lk_RPClassType.AutoHeight = false;
            this.lk_RPClassType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lk_RPClassType.Name = "lk_RPClassType";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.gridControlMd_Entries);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(957, 222);
            this.xtraTabPage2.Text = "Entries";
            // 
            // gridControlMd_Entries
            // 
            this.gridControlMd_Entries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlMd_Entries.Location = new System.Drawing.Point(0, 0);
            this.gridControlMd_Entries.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControlMd_Entries.MainView = this.gridViewMd_Entries;
            this.gridControlMd_Entries.Name = "gridControlMd_Entries";
            this.gridControlMd_Entries.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1});
            this.gridControlMd_Entries.Size = new System.Drawing.Size(957, 222);
            this.gridControlMd_Entries.TabIndex = 128;
            this.gridControlMd_Entries.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMd_Entries,
            this.gridView3});
            // 
            // gridViewMd_Entries
            // 
            this.gridViewMd_Entries.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn3,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17});
            this.gridViewMd_Entries.GridControl = this.gridControlMd_Entries;
            this.gridViewMd_Entries.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridViewMd_Entries.Name = "gridViewMd_Entries";
            this.gridViewMd_Entries.OptionsCustomization.AllowFilter = false;
            this.gridViewMd_Entries.OptionsCustomization.AllowSort = false;
            this.gridViewMd_Entries.OptionsView.ShowGroupPanel = false;
            this.gridViewMd_Entries.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridViewMd_Entries.LostFocus += new System.EventHandler(this.gridViewMd_Entries_LostFocus);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "EntryID";
            this.gridColumn1.FieldName = "nEntryID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "ReceiptNo";
            this.gridColumn2.FieldName = "strReceiptNo";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Code";
            this.gridColumn4.FieldName = "strCode";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Description";
            this.gridColumn5.FieldName = "strDescription";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Quantity";
            this.gridColumn3.FieldName = "nQuantity";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "UnitPrice";
            this.gridColumn11.FieldName = "mUnitPrice";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 5;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "DiscountCode";
            this.gridColumn12.FieldName = "strDiscountCode";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 6;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "FreebieCode";
            this.gridColumn13.FieldName = "strFreebieCode";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 7;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "SubTotal";
            this.gridColumn14.FieldName = "mSubTotal";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 8;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "ReferenceNo";
            this.gridColumn15.FieldName = "strReferenceNo";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 9;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "TempEntryID";
            this.gridColumn16.FieldName = "nTempEntryID";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 10;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "UpgradeAmount";
            this.gridColumn17.FieldName = "mUpgradeAmount";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 11;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            // 
            // gridView3
            // 
            this.gridView3.GridControl = this.gridControlMd_Entries;
            this.gridView3.Name = "gridView3";
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Controls.Add(this.gridControlMd_Payment);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(957, 222);
            this.xtraTabPage3.Text = "Payment";
            // 
            // gridControlMd_Payment
            // 
            this.gridControlMd_Payment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlMd_Payment.Location = new System.Drawing.Point(0, 0);
            this.gridControlMd_Payment.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControlMd_Payment.MainView = this.gridViewMd_Payment;
            this.gridControlMd_Payment.Name = "gridControlMd_Payment";
            this.gridControlMd_Payment.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit2});
            this.gridControlMd_Payment.Size = new System.Drawing.Size(957, 222);
            this.gridControlMd_Payment.TabIndex = 128;
            this.gridControlMd_Payment.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMd_Payment});
            // 
            // gridViewMd_Payment
            // 
            this.gridViewMd_Payment.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn18});
            this.gridViewMd_Payment.GridControl = this.gridControlMd_Payment;
            this.gridViewMd_Payment.Name = "gridViewMd_Payment";
            this.gridViewMd_Payment.OptionsCustomization.AllowFilter = false;
            this.gridViewMd_Payment.OptionsCustomization.AllowSort = false;
            this.gridViewMd_Payment.OptionsView.ShowGroupPanel = false;
            this.gridViewMd_Payment.LostFocus += new System.EventHandler(this.gridViewMd_Payment_LostFocus);
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "PaymentID";
            this.gridColumn6.FieldName = "nPaymentID";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "ReceiptNo";
            this.gridColumn7.FieldName = "strReceiptNo";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 1;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "PaymentCode";
            this.gridColumn8.FieldName = "strPaymentCode";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 2;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Amount";
            this.gridColumn9.FieldName = "mAmount";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 3;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "IPPID";
            this.gridColumn10.FieldName = "nIPPID";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 4;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "ReferenceNo";
            this.gridColumn18.FieldName = "strReferenceNo";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 5;
            // 
            // repositoryItemLookUpEdit2
            // 
            this.repositoryItemLookUpEdit2.AutoHeight = false;
            this.repositoryItemLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit2.Name = "repositoryItemLookUpEdit2";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.gridControlMd_Receipt);
            this.groupControl2.Location = new System.Drawing.Point(0, 50);
            this.groupControl2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(968, 246);
            this.groupControl2.TabIndex = 128;
            this.groupControl2.Text = "Class Type";
            // 
            // gridControlMd_Receipt
            // 
            this.gridControlMd_Receipt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlMd_Receipt.Location = new System.Drawing.Point(2, 19);
            this.gridControlMd_Receipt.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControlMd_Receipt.MainView = this.gridViewMd_Receipt;
            this.gridControlMd_Receipt.Name = "gridControlMd_Receipt";
            this.gridControlMd_Receipt.Size = new System.Drawing.Size(964, 225);
            this.gridControlMd_Receipt.TabIndex = 126;
            this.gridControlMd_Receipt.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMd_Receipt});
            // 
            // gridViewMd_Receipt
            // 
            this.gridViewMd_Receipt.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.strReceiptNo,
            this.strMembershipID,
            this.strBranchCode,
            this.nCategoryID,
            this.dtDate,
            this.nSalespersonID,
            this.nCashierID,
            this.nShiftID,
            this.nTerminalID,
            this.mNettAmount,
            this.mGSTAmount,
            this.mTotalAmount,
            this.strDiscountCode,
            this.strFreebieCode,
            this.nTaxID,
            this.mVoucherTypeID,
            this.mVoucherAmount,
            this.nTherapistID,
            this.strRewardsCode,
            this.fVoid,
            this.strReferenceNo,
            this.strParentReceiptNo,
            this.mOutstandingAmount,
            this.strRemarks,
            this.fDeposit,
            this.mBalance,
            this.strBillReferenceNo,
            this.strLocation,
            this.dtDateTime,
            this.mUpgradeAmount,
            this.fRefund,
            this.strChequeNo,
            this.mRefundAmount,
            this.nChequeUpdateBy,
            this.mDiscountAmount,
            this.strSignedPDFPath});
            this.gridViewMd_Receipt.GridControl = this.gridControlMd_Receipt;
            this.gridViewMd_Receipt.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridViewMd_Receipt.Name = "gridViewMd_Receipt";
            this.gridViewMd_Receipt.OptionsCustomization.AllowColumnMoving = false;
            this.gridViewMd_Receipt.OptionsCustomization.AllowFilter = false;
            this.gridViewMd_Receipt.OptionsCustomization.AllowSort = false;
            this.gridViewMd_Receipt.OptionsView.ColumnAutoWidth = false;
            this.gridViewMd_Receipt.OptionsView.ShowGroupPanel = false;
            this.gridViewMd_Receipt.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridViewMd_Receipt.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewMd_Receipt_FocusedRowChanged);
            this.gridViewMd_Receipt.LostFocus += new System.EventHandler(this.gridViewMd_Receipt_LostFocus);
            // 
            // strReceiptNo
            // 
            this.strReceiptNo.Caption = "ReceiptNo";
            this.strReceiptNo.FieldName = "strReceiptNo";
            this.strReceiptNo.Name = "strReceiptNo";
            this.strReceiptNo.Visible = true;
            this.strReceiptNo.VisibleIndex = 0;
            this.strReceiptNo.Width = 95;
            // 
            // strMembershipID
            // 
            this.strMembershipID.Caption = "MembershipID";
            this.strMembershipID.FieldName = "strMembershipID";
            this.strMembershipID.Name = "strMembershipID";
            this.strMembershipID.Visible = true;
            this.strMembershipID.VisibleIndex = 1;
            this.strMembershipID.Width = 80;
            // 
            // strBranchCode
            // 
            this.strBranchCode.Caption = "BranchCode";
            this.strBranchCode.FieldName = "strBranchCode";
            this.strBranchCode.Name = "strBranchCode";
            this.strBranchCode.Visible = true;
            this.strBranchCode.VisibleIndex = 2;
            this.strBranchCode.Width = 70;
            // 
            // nCategoryID
            // 
            this.nCategoryID.Caption = "CategoryID";
            this.nCategoryID.FieldName = "nCategoryID";
            this.nCategoryID.Name = "nCategoryID";
            this.nCategoryID.Visible = true;
            this.nCategoryID.VisibleIndex = 3;
            this.nCategoryID.Width = 68;
            // 
            // dtDate
            // 
            this.dtDate.Caption = "Date";
            this.dtDate.FieldName = "dtDate";
            this.dtDate.Name = "dtDate";
            this.dtDate.Visible = true;
            this.dtDate.VisibleIndex = 4;
            this.dtDate.Width = 77;
            // 
            // nSalespersonID
            // 
            this.nSalespersonID.Caption = "SalespersonID";
            this.nSalespersonID.FieldName = "nSalespersonID";
            this.nSalespersonID.Name = "nSalespersonID";
            this.nSalespersonID.Visible = true;
            this.nSalespersonID.VisibleIndex = 5;
            this.nSalespersonID.Width = 81;
            // 
            // nCashierID
            // 
            this.nCashierID.Caption = "CashierID";
            this.nCashierID.FieldName = "nCashierID";
            this.nCashierID.Name = "nCashierID";
            this.nCashierID.Visible = true;
            this.nCashierID.VisibleIndex = 6;
            this.nCashierID.Width = 59;
            // 
            // nShiftID
            // 
            this.nShiftID.Caption = "ShiftID";
            this.nShiftID.FieldName = "nShiftID";
            this.nShiftID.Name = "nShiftID";
            this.nShiftID.Visible = true;
            this.nShiftID.VisibleIndex = 7;
            this.nShiftID.Width = 45;
            // 
            // nTerminalID
            // 
            this.nTerminalID.Caption = "TerminalID";
            this.nTerminalID.FieldName = "nTerminalID";
            this.nTerminalID.Name = "nTerminalID";
            this.nTerminalID.Visible = true;
            this.nTerminalID.VisibleIndex = 8;
            this.nTerminalID.Width = 63;
            // 
            // mNettAmount
            // 
            this.mNettAmount.Caption = "NettAmount";
            this.mNettAmount.FieldName = "mNettAmount";
            this.mNettAmount.Name = "mNettAmount";
            this.mNettAmount.Visible = true;
            this.mNettAmount.VisibleIndex = 9;
            this.mNettAmount.Width = 70;
            // 
            // mGSTAmount
            // 
            this.mGSTAmount.Caption = "GSTAmount";
            this.mGSTAmount.FieldName = "mGSTAmount";
            this.mGSTAmount.Name = "mGSTAmount";
            this.mGSTAmount.Visible = true;
            this.mGSTAmount.VisibleIndex = 10;
            this.mGSTAmount.Width = 68;
            // 
            // mTotalAmount
            // 
            this.mTotalAmount.Caption = "TotalAmount";
            this.mTotalAmount.FieldName = "mTotalAmount";
            this.mTotalAmount.Name = "mTotalAmount";
            this.mTotalAmount.Visible = true;
            this.mTotalAmount.VisibleIndex = 11;
            this.mTotalAmount.Width = 73;
            // 
            // strDiscountCode
            // 
            this.strDiscountCode.Caption = "DiscountCode";
            this.strDiscountCode.FieldName = "strDiscountCode";
            this.strDiscountCode.Name = "strDiscountCode";
            this.strDiscountCode.Visible = true;
            this.strDiscountCode.VisibleIndex = 12;
            this.strDiscountCode.Width = 78;
            // 
            // strFreebieCode
            // 
            this.strFreebieCode.Caption = "FreebieCode";
            this.strFreebieCode.FieldName = "strFreebieCode";
            this.strFreebieCode.Name = "strFreebieCode";
            this.strFreebieCode.Visible = true;
            this.strFreebieCode.VisibleIndex = 13;
            this.strFreebieCode.Width = 73;
            // 
            // nTaxID
            // 
            this.nTaxID.Caption = "TaxID";
            this.nTaxID.FieldName = "nTaxID";
            this.nTaxID.Name = "nTaxID";
            this.nTaxID.Visible = true;
            this.nTaxID.VisibleIndex = 14;
            this.nTaxID.Width = 41;
            // 
            // mVoucherTypeID
            // 
            this.mVoucherTypeID.Caption = "VoucherTypeID";
            this.mVoucherTypeID.FieldName = "mVoucherTypeID";
            this.mVoucherTypeID.Name = "mVoucherTypeID";
            this.mVoucherTypeID.Visible = true;
            this.mVoucherTypeID.VisibleIndex = 15;
            this.mVoucherTypeID.Width = 86;
            // 
            // mVoucherAmount
            // 
            this.mVoucherAmount.Caption = "VoucherAmount";
            this.mVoucherAmount.FieldName = "mVoucherAmount";
            this.mVoucherAmount.Name = "mVoucherAmount";
            this.mVoucherAmount.Visible = true;
            this.mVoucherAmount.VisibleIndex = 16;
            this.mVoucherAmount.Width = 88;
            // 
            // nTherapistID
            // 
            this.nTherapistID.Caption = "TherapistID";
            this.nTherapistID.FieldName = "nTherapistID";
            this.nTherapistID.Name = "nTherapistID";
            this.nTherapistID.Visible = true;
            this.nTherapistID.VisibleIndex = 17;
            this.nTherapistID.Width = 68;
            // 
            // strRewardsCode
            // 
            this.strRewardsCode.Caption = "RewardsCode";
            this.strRewardsCode.FieldName = "strRewardsCode";
            this.strRewardsCode.Name = "strRewardsCode";
            this.strRewardsCode.Visible = true;
            this.strRewardsCode.VisibleIndex = 18;
            this.strRewardsCode.Width = 79;
            // 
            // fVoid
            // 
            this.fVoid.Caption = "Void";
            this.fVoid.FieldName = "fVoid";
            this.fVoid.Name = "fVoid";
            this.fVoid.Visible = true;
            this.fVoid.VisibleIndex = 19;
            this.fVoid.Width = 32;
            // 
            // strReferenceNo
            // 
            this.strReferenceNo.Caption = "ReferenceNo";
            this.strReferenceNo.FieldName = "strReferenceNo";
            this.strReferenceNo.Name = "strReferenceNo";
            this.strReferenceNo.Visible = true;
            this.strReferenceNo.VisibleIndex = 20;
            // 
            // strParentReceiptNo
            // 
            this.strParentReceiptNo.Caption = "ParentReceiptNo";
            this.strParentReceiptNo.FieldName = "strParentReceiptNo";
            this.strParentReceiptNo.Name = "strParentReceiptNo";
            this.strParentReceiptNo.Visible = true;
            this.strParentReceiptNo.VisibleIndex = 21;
            this.strParentReceiptNo.Width = 93;
            // 
            // mOutstandingAmount
            // 
            this.mOutstandingAmount.Caption = "OutstandingAmount";
            this.mOutstandingAmount.FieldName = "mOutstandingAmount";
            this.mOutstandingAmount.Name = "mOutstandingAmount";
            this.mOutstandingAmount.Visible = true;
            this.mOutstandingAmount.VisibleIndex = 22;
            this.mOutstandingAmount.Width = 108;
            // 
            // strRemarks
            // 
            this.strRemarks.Caption = "Remarks";
            this.strRemarks.FieldName = "strRemarks";
            this.strRemarks.Name = "strRemarks";
            this.strRemarks.Visible = true;
            this.strRemarks.VisibleIndex = 23;
            this.strRemarks.Width = 53;
            // 
            // fDeposit
            // 
            this.fDeposit.Caption = "Deposit";
            this.fDeposit.FieldName = "fDeposit";
            this.fDeposit.Name = "fDeposit";
            this.fDeposit.Visible = true;
            this.fDeposit.VisibleIndex = 24;
            this.fDeposit.Width = 48;
            // 
            // mBalance
            // 
            this.mBalance.Caption = "Balance";
            this.mBalance.FieldName = "mBalance";
            this.mBalance.Name = "mBalance";
            this.mBalance.Visible = true;
            this.mBalance.VisibleIndex = 25;
            this.mBalance.Width = 49;
            // 
            // strBillReferenceNo
            // 
            this.strBillReferenceNo.Caption = "BillReferenceNo";
            this.strBillReferenceNo.FieldName = "strBillReferenceNo";
            this.strBillReferenceNo.Name = "strBillReferenceNo";
            this.strBillReferenceNo.Visible = true;
            this.strBillReferenceNo.VisibleIndex = 26;
            this.strBillReferenceNo.Width = 87;
            // 
            // strLocation
            // 
            this.strLocation.Caption = "Location";
            this.strLocation.FieldName = "strLocation";
            this.strLocation.Name = "strLocation";
            this.strLocation.Visible = true;
            this.strLocation.VisibleIndex = 27;
            this.strLocation.Width = 52;
            // 
            // dtDateTime
            // 
            this.dtDateTime.Caption = "DateTime";
            this.dtDateTime.FieldName = "dtDateTime";
            this.dtDateTime.Name = "dtDateTime";
            this.dtDateTime.Visible = true;
            this.dtDateTime.VisibleIndex = 28;
            this.dtDateTime.Width = 57;
            // 
            // mUpgradeAmount
            // 
            this.mUpgradeAmount.Caption = "UpgradeAmount";
            this.mUpgradeAmount.FieldName = "mUpgradeAmount";
            this.mUpgradeAmount.Name = "mUpgradeAmount";
            this.mUpgradeAmount.Visible = true;
            this.mUpgradeAmount.VisibleIndex = 29;
            this.mUpgradeAmount.Width = 90;
            // 
            // fRefund
            // 
            this.fRefund.Caption = "Refund";
            this.fRefund.FieldName = "fRefund";
            this.fRefund.Name = "fRefund";
            this.fRefund.Visible = true;
            this.fRefund.VisibleIndex = 30;
            this.fRefund.Width = 47;
            // 
            // strChequeNo
            // 
            this.strChequeNo.Caption = "ChequeNo";
            this.strChequeNo.FieldName = "strChequeNo";
            this.strChequeNo.Name = "strChequeNo";
            this.strChequeNo.Visible = true;
            this.strChequeNo.VisibleIndex = 31;
            this.strChequeNo.Width = 62;
            // 
            // mRefundAmount
            // 
            this.mRefundAmount.Caption = "RefundAmount";
            this.mRefundAmount.FieldName = "mRefundAmount";
            this.mRefundAmount.Name = "mRefundAmount";
            this.mRefundAmount.Visible = true;
            this.mRefundAmount.VisibleIndex = 32;
            this.mRefundAmount.Width = 84;
            // 
            // nChequeUpdateBy
            // 
            this.nChequeUpdateBy.Caption = "ChequeUpdateBy";
            this.nChequeUpdateBy.FieldName = "nChequeUpdateBy";
            this.nChequeUpdateBy.Name = "nChequeUpdateBy";
            this.nChequeUpdateBy.Visible = true;
            this.nChequeUpdateBy.VisibleIndex = 33;
            this.nChequeUpdateBy.Width = 96;
            // 
            // mDiscountAmount
            // 
            this.mDiscountAmount.Caption = "DiscountAmount";
            this.mDiscountAmount.FieldName = "mDiscountAmount";
            this.mDiscountAmount.Name = "mDiscountAmount";
            this.mDiscountAmount.Visible = true;
            this.mDiscountAmount.VisibleIndex = 34;
            this.mDiscountAmount.Width = 90;
            // 
            // strSignedPDFPath
            // 
            this.strSignedPDFPath.Caption = "SignedPDFPath";
            this.strSignedPDFPath.FieldName = "strSignedPDFPath";
            this.strSignedPDFPath.Name = "strSignedPDFPath";
            this.strSignedPDFPath.Visible = true;
            this.strSignedPDFPath.VisibleIndex = 35;
            this.strSignedPDFPath.Width = 85;
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
            // gridView1
            // 
            this.gridView1.Name = "gridView1";
            // 
            // frmReceipt
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(990, 560);
            this.Controls.Add(this.grpMdReceipt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmReceipt";
            this.Text = "frmReceipt";
            this.Load += new System.EventHandler(this.frmReceipt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpMdReceipt)).EndInit();
            this.grpMdReceipt.ResumeLayout(false);
            this.Searchpanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlReceiptCategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabCtrlMd_Freebie)).EndInit();
            this.tabCtrlMd_Freebie.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMd_Freebie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMd_Freebie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_RPClassType)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMd_Entries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMd_Entries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            this.xtraTabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMd_Payment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMd_Payment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMd_Receipt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMd_Receipt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region class

        string load = "";
        string strSQL;

		private void mdFreebieInit()
		{
			DataRow row = this.gridViewMd_Receipt.GetDataRow(gridViewMd_Receipt.FocusedRowHandle);
				
			if (row == null)
					return;

			string strSQL = "select * from tblReceiptFreebie Where strReceiptNo= '" + (row["strReceiptNo"] + "'");

            DataSet _ds = new DataSet();
            dtFreebie = new DataTable();
            SqlHelper.FillDataset(connection, CommandType.Text, strSQL, _ds, new string[] { "table" });
            dtFreebie = _ds.Tables["table"];
            this.gridControlMd_Freebie.DataSource = dtFreebie;
		
		}

        private void mdEntriesInit()
        {
            DataRow row = this.gridViewMd_Receipt.GetDataRow(gridViewMd_Receipt.FocusedRowHandle);

            if (row == null)
                return;

            string strSQL = "select * from tblReceiptEntries Where strReceiptNo= '" + (row["strReceiptNo"] + "'");

            DataSet _ds = new DataSet();
            dtEntry = new DataTable();
            SqlHelper.FillDataset(connection, CommandType.Text, strSQL, _ds, new string[] { "table" });
            dtEntry = _ds.Tables["table"];
            this.gridControlMd_Entries.DataSource = dtEntry;

        }

        private void mdPaymentInit()
        {
            DataRow row = this.gridViewMd_Receipt.GetDataRow(gridViewMd_Receipt.FocusedRowHandle);

            if (row == null)
                return;

            string strSQL = "select * from tblReceiptPayment Where strReceiptNo= '" + (row["strReceiptNo"] + "'");

            DataSet _ds = new DataSet();
            dtPayment = new DataTable();
            SqlHelper.FillDataset(connection, CommandType.Text, strSQL, _ds, new string[] { "table" });
            dtPayment = _ds.Tables["table"];
            this.gridControlMd_Payment.DataSource = dtPayment;

        }

		private void mdReceiptInit()
		{
			string strSQL = "select * from tblReceipt where nCategoryID = " + load;
			DataSet _ds = new DataSet();
			
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
		    dtClassType = _ds.Tables["Table"];

			gridControlMd_Receipt.DataSource = dtClassType;
		}
	
		#endregion
		
		#region common

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


        private bool FieldChecking(DataRow dr)
        {
            if (dr["strReceiptNo"].ToString() == "")
                return false;
            return true;
        }

        private bool FieldFreebieChecking(DataRow dr)
        {
            if (dr["nFreebieID"].ToString() == "")
                return false;

            return true;
        }

        private bool FieldEntriesChecking(DataRow dr)
        {
            if (dr["nEntryID"].ToString() == "")
                return false;

            return true;
        }

        private bool FieldPaymentChecking(DataRow dr)
        {
            if (dr["nPaymentID"].ToString() == "")
                return false;

            return true;
        }

		private void frmReceipt_Load(object sender, System.EventArgs e)
		{
            DataSet _ds = new DataSet();
            string strSQL;

            strSQL = "select * from tblCategory order by strDescription";
            comboBind(ddlReceiptCategory, strSQL, "strDescription", "nCategoryID");	
		}

		private void gridViewMd_Receipt_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
            mdFreebieInit();
            mdEntriesInit();
            mdPaymentInit();
        }

        #region Receipt

        private bool AddNew = false;

		private void gridViewMd_Receipt_LostFocus(object sender, System.EventArgs e)
		{
            DataRow row = this.gridViewMd_Receipt.GetDataRow(gridViewMd_Receipt.FocusedRowHandle);

            string strSQL = "Select * from tblReceipt";
            if (AddNew)
            {
                if (FieldChecking(row))
                {
                    this.gridControlMd_Receipt.MainView.UpdateCurrentRow();
                    try
                    {
                        CreateCmdsAndUpdate(strSQL, dtClassType);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Delete Process Failed");
                        return;
                    }
                    AddNew = false;
                }
            }
            else
            {
                gridViewMd_Receipt.CloseEditor();
                gridViewMd_Receipt.UpdateCurrentRow();

                CreateCmdsAndUpdate(strSQL, dtClassType);
            }
        }

        #endregion

        #region Freebie

        private bool AddNewFreebie = false;

		private void gridViewMd_Freebie_LostFocus(object sender, System.EventArgs e)
		{
            DataRow row = this.gridViewMd_Freebie.GetDataRow(gridViewMd_Freebie.FocusedRowHandle);

            string strSQL = "Select * from tblReceiptFreebie";
            if (AddNewFreebie)
            {
                if (FieldFreebieChecking(row))
                {
                    this.gridControlMd_Freebie.MainView.UpdateCurrentRow();
                    try
                    {
                        CreateCmdsAndUpdate(strSQL, dtFreebie);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Delete Process Failed");
                        return;
                    }
                    AddNewFreebie = false;
                }
            }
            else
            {
                gridViewMd_Freebie.CloseEditor();
                gridViewMd_Freebie.UpdateCurrentRow();

                CreateCmdsAndUpdate(strSQL, dtFreebie);
            }
        }

        #endregion

        #region Entry

        private bool AddNewEntry = false;

        private void gridViewMd_Entries_LostFocus(object sender, System.EventArgs e)
        {
            DataRow row = this.gridViewMd_Entries.GetDataRow(gridViewMd_Entries.FocusedRowHandle);

            string strSQL = "Select * from tblReceiptEntries";
            if (AddNewEntry)
            {
                if (FieldEntriesChecking(row))
                {
                    this.gridControlMd_Entries.MainView.UpdateCurrentRow();
                    try
                    {
                        CreateCmdsAndUpdate(strSQL, dtEntry);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Delete Process Failed");
                        return;
                    }
                    AddNewEntry = false;
                }
            }
            else
            {
                gridViewMd_Entries.CloseEditor();
                gridViewMd_Entries.UpdateCurrentRow();

                CreateCmdsAndUpdate(strSQL, dtEntry);
            }
        }

        #endregion

        #region Payment

        private bool AddNewPayment = false;

        private void gridViewMd_Payment_LostFocus(object sender, System.EventArgs e)
        {
            DataRow row = this.gridViewMd_Payment.GetDataRow(gridViewMd_Payment.FocusedRowHandle);

            string strSQL = "Select * from tblReceiptPayment";
            if (AddNewPayment)
            {
                if (FieldFreebieChecking(row))
                {
                    this.gridControlMd_Payment.MainView.UpdateCurrentRow();
                    try
                    {
                        CreateCmdsAndUpdate(strSQL, dtPayment);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Delete Process Failed");
                        return;
                    }
                    AddNewPayment = false;
                }
            }
            else
            {
                gridViewMd_Payment.CloseEditor();
                gridViewMd_Payment.UpdateCurrentRow();

                CreateCmdsAndUpdate(strSQL, dtPayment);
            }
        }

        #endregion

        private void ddlReceiptCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (row1 != null)
            {

            }
            else
            {
                load = ddlReceiptCategory.Value.ToString();

                mdReceiptInit();
                mdFreebieInit();
                mdEntriesInit();
                mdPaymentInit();
            }
            
        }

        string search;

        private void btn_Search_Click(object sender, EventArgs e)
        {
            search = txtSearch.Text;
            loadSearch();
        }

        DataTable dtSearch;
        DataRow row1 = null;

        private void loadSearch()
        {
            strSQL = "select * from tblReceipt where strReceiptNo = '" + search + "'";
            DataSet _ds = new DataSet();

            SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA", _ds, new string[] { "Table" }, new SqlParameter("@strSQL", strSQL));
            dtSearch = _ds.Tables["Table"];

            gridControlMd_Receipt.DataSource = dtSearch;

            row1 = this.gridViewMd_Receipt.GetDataRow(gridViewMd_Receipt.FocusedRowHandle);

            if (row1 != null)
            {
                ddlReceiptCategory.SelectedIndex = int.Parse(row1["nCategoryID"].ToString());
                row1 = null;
            }

            mdFreebieInit();
            mdEntriesInit();
            mdPaymentInit();
        }
	}
}
