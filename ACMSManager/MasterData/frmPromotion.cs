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
using ACMS.Utils;


namespace ACMS.ACMSManager.MasterData
{
	/// <summary>
	/// Summary description for frmPromotion.
	/// </summary>
	public class frmPromotion : System.Windows.Forms.Form
	{
		private string connectionString;
		private SqlConnection connection;
		private DevExpress.XtraEditors.GroupControl grpMDPromotionTop;
		private DevExpress.XtraGrid.GridControl gridControlMd_Promotion;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewMd_Promotion;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnPM1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnPM2;
		private DevExpress.XtraEditors.GroupControl grpMDPromotionBelow;
		private DevExpress.XtraEditors.GroupControl grpMDPromotionBelow2;
		private DevExpress.XtraTab.XtraTabControl TabControlPromotion;
		private DevExpress.XtraTab.XtraTabPage tabPromo_Brnch;
		private DevExpress.XtraTab.XtraTabPage tabPromo_Freebies;
		private DevExpress.XtraTab.XtraTabPage tabPromo_Package;
		private DevExpress.XtraTab.XtraTabPage tabPromo_ReceiptSalesCategory;
		private DataTable dtPromotion;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_DiscountCategory;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox cmPromotionType;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
		private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit dtStartDate;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
		private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit dtEndDate;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
		private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox cmbApprovedStatus;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
		internal DevExpress.XtraEditors.SimpleButton btn_Add;
		internal DevExpress.XtraEditors.SimpleButton btn_Del;
		private System.Windows.Forms.ImageList imageList1;
		private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox cmbItemDiscount;
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.TextEdit txtItemDesc;
		private System.Windows.Forms.Label label2;
		private DevExpress.XtraEditors.TextEdit txtItemCode;
		private DevExpress.XtraEditors.TextEdit txtItemStyle;
		private System.Windows.Forms.Label label3;
		internal DevExpress.XtraEditors.SimpleButton btnSearch;
		internal DevExpress.XtraEditors.SimpleButton btnReset;
		internal DevExpress.XtraEditors.SimpleButton btnPcReset;
		internal DevExpress.XtraEditors.SimpleButton btnPcSearch;
		private DevExpress.XtraEditors.TextEdit txtPcItemCode;
		private System.Windows.Forms.Label label5;
		private DevExpress.XtraEditors.TextEdit txtPcItemDesc;
		private System.Windows.Forms.Label label6;
		private DevExpress.XtraEditors.GroupControl groupControl1;
		private DevExpress.XtraEditors.SimpleButton btnBranch_Del;
		private DevExpress.XtraEditors.SimpleButton btnBranch_DelAll;
		private DevExpress.XtraEditors.SimpleButton btnBranch_AddAll;
		private DevExpress.XtraEditors.SimpleButton btnBranch_Add;
		private DevExpress.XtraGrid.GridControl gridBranch2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn33;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn34;
		private System.Windows.Forms.Label label4;
		private DevExpress.XtraGrid.GridControl gridBranch;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn35;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn36;
		private DevExpress.XtraGrid.Views.Grid.GridView gvBranch2;
		private DevExpress.XtraGrid.Views.Grid.GridView gvBranch;
		private DevExpress.XtraEditors.GroupControl groupControl2;
		private DevExpress.XtraEditors.SimpleButton btnFreebies_Del;
		private DevExpress.XtraEditors.SimpleButton btnFreebies_DelAll;
		private DevExpress.XtraEditors.SimpleButton btnFreebies_AddAll;
		private DevExpress.XtraEditors.SimpleButton btnFreebies_Add;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
		private DevExpress.XtraGrid.GridControl gdFreebies2;
		private DevExpress.XtraGrid.Views.Grid.GridView gvFreebies2;
		private DevExpress.XtraGrid.GridControl gdFreebies;
		private DevExpress.XtraGrid.Views.Grid.GridView gvFreebies;
		private DevExpress.XtraEditors.GroupControl groupControl3;
		private DevExpress.XtraEditors.SimpleButton btnPackage_Del;
		private DevExpress.XtraEditors.SimpleButton btnPackage_DelAll;
		private DevExpress.XtraEditors.SimpleButton btnPackage_AddAll;
		private DevExpress.XtraEditors.SimpleButton btnPackage_Add;
		private DevExpress.XtraGrid.GridControl gdPackage2;
		private DevExpress.XtraGrid.GridControl gdPackage;
		private DevExpress.XtraGrid.Views.Grid.GridView gvPackage2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
		private DevExpress.XtraGrid.Views.Grid.GridView gvPackage;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
		private DevExpress.XtraEditors.GroupControl groupControl4;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
		private DevExpress.XtraEditors.SimpleButton btnSales_AddAll;
		private DevExpress.XtraEditors.SimpleButton btnSales_Add;
		private DevExpress.XtraGrid.GridControl gridSales2;
		private DevExpress.XtraGrid.GridControl gridSales;
		private DevExpress.XtraEditors.SimpleButton btnSales_Del;
		private DevExpress.XtraEditors.SimpleButton btnSales_DelAll;
		private DevExpress.XtraGrid.Views.Grid.GridView gvSales2;
		private DevExpress.XtraGrid.Views.Grid.GridView gvSales;
		private System.Windows.Forms.Panel Searchpanel;
		internal DevExpress.XtraEditors.TextEdit txtSearch;
		internal DevExpress.XtraEditors.SimpleButton btn_Search;
		private System.ComponentModel.IContainer components;

		public frmPromotion()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmPromotion));
			this.grpMDPromotionTop = new DevExpress.XtraEditors.GroupControl();
			this.gridControlMd_Promotion = new DevExpress.XtraGrid.GridControl();
			this.gridViewMd_Promotion = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumnPM1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumnPM2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.lk_DiscountCategory = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.cmPromotionType = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.cmbItemDiscount = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.dtStartDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
			this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.dtEndDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
			this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.cmbApprovedStatus = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
			this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.Searchpanel = new System.Windows.Forms.Panel();
			this.btn_Search = new DevExpress.XtraEditors.SimpleButton();
			this.txtSearch = new DevExpress.XtraEditors.TextEdit();
			this.btn_Add = new DevExpress.XtraEditors.SimpleButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.btn_Del = new DevExpress.XtraEditors.SimpleButton();
			this.grpMDPromotionBelow = new DevExpress.XtraEditors.GroupControl();
			this.grpMDPromotionBelow2 = new DevExpress.XtraEditors.GroupControl();
			this.TabControlPromotion = new DevExpress.XtraTab.XtraTabControl();
			this.tabPromo_Brnch = new DevExpress.XtraTab.XtraTabPage();
			this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
			this.btnBranch_Del = new DevExpress.XtraEditors.SimpleButton();
			this.btnBranch_DelAll = new DevExpress.XtraEditors.SimpleButton();
			this.btnBranch_AddAll = new DevExpress.XtraEditors.SimpleButton();
			this.btnBranch_Add = new DevExpress.XtraEditors.SimpleButton();
			this.gridBranch2 = new DevExpress.XtraGrid.GridControl();
			this.gvBranch2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn33 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn34 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.label4 = new System.Windows.Forms.Label();
			this.gridBranch = new DevExpress.XtraGrid.GridControl();
			this.gvBranch = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn35 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn36 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.tabPromo_Freebies = new DevExpress.XtraTab.XtraTabPage();
			this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
			this.btnFreebies_Del = new DevExpress.XtraEditors.SimpleButton();
			this.btnFreebies_DelAll = new DevExpress.XtraEditors.SimpleButton();
			this.btnFreebies_AddAll = new DevExpress.XtraEditors.SimpleButton();
			this.btnFreebies_Add = new DevExpress.XtraEditors.SimpleButton();
			this.gdFreebies2 = new DevExpress.XtraGrid.GridControl();
			this.gvFreebies2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gdFreebies = new DevExpress.XtraGrid.GridControl();
			this.gvFreebies = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.btnReset = new DevExpress.XtraEditors.SimpleButton();
			this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
			this.txtItemStyle = new DevExpress.XtraEditors.TextEdit();
			this.label3 = new System.Windows.Forms.Label();
			this.txtItemCode = new DevExpress.XtraEditors.TextEdit();
			this.label2 = new System.Windows.Forms.Label();
			this.txtItemDesc = new DevExpress.XtraEditors.TextEdit();
			this.label1 = new System.Windows.Forms.Label();
			this.tabPromo_Package = new DevExpress.XtraTab.XtraTabPage();
			this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
			this.btnPackage_Del = new DevExpress.XtraEditors.SimpleButton();
			this.btnPackage_DelAll = new DevExpress.XtraEditors.SimpleButton();
			this.btnPackage_AddAll = new DevExpress.XtraEditors.SimpleButton();
			this.btnPackage_Add = new DevExpress.XtraEditors.SimpleButton();
			this.gdPackage2 = new DevExpress.XtraGrid.GridControl();
			this.gvPackage2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gdPackage = new DevExpress.XtraGrid.GridControl();
			this.gvPackage = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.btnPcReset = new DevExpress.XtraEditors.SimpleButton();
			this.btnPcSearch = new DevExpress.XtraEditors.SimpleButton();
			this.txtPcItemCode = new DevExpress.XtraEditors.TextEdit();
			this.label5 = new System.Windows.Forms.Label();
			this.txtPcItemDesc = new DevExpress.XtraEditors.TextEdit();
			this.label6 = new System.Windows.Forms.Label();
			this.tabPromo_ReceiptSalesCategory = new DevExpress.XtraTab.XtraTabPage();
			this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
			this.btnSales_Del = new DevExpress.XtraEditors.SimpleButton();
			this.btnSales_DelAll = new DevExpress.XtraEditors.SimpleButton();
			this.btnSales_AddAll = new DevExpress.XtraEditors.SimpleButton();
			this.btnSales_Add = new DevExpress.XtraEditors.SimpleButton();
			this.gridSales2 = new DevExpress.XtraGrid.GridControl();
			this.gvSales2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridSales = new DevExpress.XtraGrid.GridControl();
			this.gvSales = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
			((System.ComponentModel.ISupportInitialize)(this.grpMDPromotionTop)).BeginInit();
			this.grpMDPromotionTop.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControlMd_Promotion)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewMd_Promotion)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_DiscountCategory)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmPromotionType)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbItemDiscount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtStartDate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtEndDate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbApprovedStatus)).BeginInit();
			this.Searchpanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grpMDPromotionBelow)).BeginInit();
			this.grpMDPromotionBelow.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grpMDPromotionBelow2)).BeginInit();
			this.grpMDPromotionBelow2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.TabControlPromotion)).BeginInit();
			this.TabControlPromotion.SuspendLayout();
			this.tabPromo_Brnch.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
			this.groupControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridBranch2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvBranch2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridBranch)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvBranch)).BeginInit();
			this.tabPromo_Freebies.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
			this.groupControl2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gdFreebies2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvFreebies2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gdFreebies)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvFreebies)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtItemStyle.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtItemCode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtItemDesc.Properties)).BeginInit();
			this.tabPromo_Package.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
			this.groupControl3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gdPackage2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvPackage2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gdPackage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvPackage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPcItemCode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPcItemDesc.Properties)).BeginInit();
			this.tabPromo_ReceiptSalesCategory.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
			this.groupControl4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridSales2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvSales2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridSales)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvSales)).BeginInit();
			this.SuspendLayout();
			// 
			// grpMDPromotionTop
			// 
			this.grpMDPromotionTop.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.grpMDPromotionTop.Appearance.Options.UseBackColor = true;
			this.grpMDPromotionTop.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.grpMDPromotionTop.AppearanceCaption.Options.UseFont = true;
			this.grpMDPromotionTop.Controls.Add(this.gridControlMd_Promotion);
			this.grpMDPromotionTop.Controls.Add(this.Searchpanel);
			this.grpMDPromotionTop.Controls.Add(this.btn_Add);
			this.grpMDPromotionTop.Controls.Add(this.btn_Del);
			this.grpMDPromotionTop.ImeMode = System.Windows.Forms.ImeMode.On;
			this.grpMDPromotionTop.Location = new System.Drawing.Point(8, 0);
			this.grpMDPromotionTop.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.grpMDPromotionTop.LookAndFeel.UseDefaultLookAndFeel = false;
			this.grpMDPromotionTop.LookAndFeel.UseWindowsXPTheme = false;
			this.grpMDPromotionTop.Name = "grpMDPromotionTop";
			this.grpMDPromotionTop.Size = new System.Drawing.Size(960, 224);
			this.grpMDPromotionTop.TabIndex = 92;
			this.grpMDPromotionTop.Text = "Promotion";
			// 
			// gridControlMd_Promotion
			// 
			this.gridControlMd_Promotion.Dock = System.Windows.Forms.DockStyle.Bottom;
			// 
			// gridControlMd_Promotion.EmbeddedNavigator
			// 
			this.gridControlMd_Promotion.EmbeddedNavigator.Name = "";
			gridLevelNode1.RelationName = "Level1";
			this.gridControlMd_Promotion.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
																											  gridLevelNode1});
			this.gridControlMd_Promotion.Location = new System.Drawing.Point(2, 46);
			this.gridControlMd_Promotion.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.gridControlMd_Promotion.LookAndFeel.UseDefaultLookAndFeel = false;
			this.gridControlMd_Promotion.MainView = this.gridViewMd_Promotion;
			this.gridControlMd_Promotion.Name = "gridControlMd_Promotion";
			this.gridControlMd_Promotion.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																															 this.lk_DiscountCategory,
																															 this.cmPromotionType,
																															 this.dtStartDate,
																															 this.dtEndDate,
																															 this.cmbApprovedStatus,
																															 this.cmbItemDiscount});
			this.gridControlMd_Promotion.Size = new System.Drawing.Size(956, 176);
			this.gridControlMd_Promotion.TabIndex = 20;
			this.gridControlMd_Promotion.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																												   this.gridViewMd_Promotion});
			// 
			// gridViewMd_Promotion
			// 
			this.gridViewMd_Promotion.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																										this.gridColumnPM1,
																										this.gridColumnPM2,
																										this.gridColumn1,
																										this.gridColumn2,
																										this.gridColumn3,
																										this.gridColumn4,
																										this.gridColumn5,
																										this.gridColumn6,
																										this.gridColumn7,
																										this.gridColumn8,
																										this.gridColumn9});
			this.gridViewMd_Promotion.CustomizationFormBounds = new System.Drawing.Rectangle(465, 203, 208, 156);
			this.gridViewMd_Promotion.GridControl = this.gridControlMd_Promotion;
			this.gridViewMd_Promotion.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
			this.gridViewMd_Promotion.Name = "gridViewMd_Promotion";
			this.gridViewMd_Promotion.OptionsCustomization.AllowFilter = false;
			this.gridViewMd_Promotion.OptionsCustomization.AllowSort = false;
			this.gridViewMd_Promotion.OptionsView.ColumnAutoWidth = false;
			this.gridViewMd_Promotion.OptionsView.ShowGroupPanel = false;
			this.gridViewMd_Promotion.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewMd_Promotion_FocusedRowChanged);
			this.gridViewMd_Promotion.LostFocus += new System.EventHandler(this.gridViewMd_Promotion_LostFocus);
			// 
			// gridColumnPM1
			// 
			this.gridColumnPM1.Caption = "Promotion Code";
			this.gridColumnPM1.FieldName = "strPromotionCode";
			this.gridColumnPM1.MinWidth = 10;
			this.gridColumnPM1.Name = "gridColumnPM1";
			this.gridColumnPM1.Visible = true;
			this.gridColumnPM1.VisibleIndex = 0;
			this.gridColumnPM1.Width = 90;
			// 
			// gridColumnPM2
			// 
			this.gridColumnPM2.Caption = "Description";
			this.gridColumnPM2.FieldName = "strDescription";
			this.gridColumnPM2.Name = "gridColumnPM2";
			this.gridColumnPM2.Visible = true;
			this.gridColumnPM2.VisibleIndex = 1;
			this.gridColumnPM2.Width = 173;
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "Discount Category";
			this.gridColumn1.ColumnEdit = this.lk_DiscountCategory;
			this.gridColumn1.FieldName = "nDiscountCategoryID";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 2;
			this.gridColumn1.Width = 155;
			// 
			// lk_DiscountCategory
			// 
			this.lk_DiscountCategory.AutoHeight = false;
			this.lk_DiscountCategory.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lk_DiscountCategory.Name = "lk_DiscountCategory";
			// 
			// gridColumn2
			// 
			this.gridColumn2.Caption = "Promotion Type";
			this.gridColumn2.ColumnEdit = this.cmPromotionType;
			this.gridColumn2.FieldName = "nPromotionTypeID";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 3;
			this.gridColumn2.Width = 116;
			// 
			// cmPromotionType
			// 
			this.cmPromotionType.AutoHeight = false;
			this.cmPromotionType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																										 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cmPromotionType.Items.AddRange(new object[] {
																 new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Discount Promotion", 0, -1),
																 new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Free Product", 1, -1),
																 new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Free Package", 2, -1)});
			this.cmPromotionType.Name = "cmPromotionType";
			// 
			// gridColumn3
			// 
			this.gridColumn3.Caption = "Item Discount?";
			this.gridColumn3.ColumnEdit = this.cmbItemDiscount;
			this.gridColumn3.FieldName = "fItemDiscount";
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 4;
			this.gridColumn3.Width = 101;
			// 
			// cmbItemDiscount
			// 
			this.cmbItemDiscount.AutoHeight = false;
			this.cmbItemDiscount.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																										 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cmbItemDiscount.Items.AddRange(new object[] {
																 new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Item Discount", true, -1),
																 new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Bill Discount", false, -1)});
			this.cmbItemDiscount.Name = "cmbItemDiscount";
			// 
			// gridColumn4
			// 
			this.gridColumn4.Caption = "Minimum Amount";
			this.gridColumn4.DisplayFormat.FormatString = "#.##";
			this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumn4.FieldName = "mMinimumAmount";
			this.gridColumn4.Name = "gridColumn4";
			this.gridColumn4.Visible = true;
			this.gridColumn4.VisibleIndex = 5;
			this.gridColumn4.Width = 101;
			// 
			// gridColumn5
			// 
			this.gridColumn5.Caption = "Start Date";
			this.gridColumn5.ColumnEdit = this.dtStartDate;
			this.gridColumn5.DisplayFormat.FormatString = "d";
			this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.gridColumn5.FieldName = "dtValidStart";
			this.gridColumn5.Name = "gridColumn5";
			this.gridColumn5.Visible = true;
			this.gridColumn5.VisibleIndex = 6;
			this.gridColumn5.Width = 95;
			// 
			// dtStartDate
			// 
			this.dtStartDate.AutoHeight = false;
			this.dtStartDate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																									 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dtStartDate.Name = "dtStartDate";
			// 
			// gridColumn6
			// 
			this.gridColumn6.Caption = "End Date";
			this.gridColumn6.ColumnEdit = this.dtEndDate;
			this.gridColumn6.DisplayFormat.FormatString = "d";
			this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.gridColumn6.FieldName = "dtValidEnd";
			this.gridColumn6.Name = "gridColumn6";
			this.gridColumn6.Visible = true;
			this.gridColumn6.VisibleIndex = 7;
			this.gridColumn6.Width = 90;
			// 
			// dtEndDate
			// 
			this.dtEndDate.AutoHeight = false;
			this.dtEndDate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																								   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dtEndDate.Name = "dtEndDate";
			// 
			// gridColumn7
			// 
			this.gridColumn7.Caption = "Approved Status";
			this.gridColumn7.ColumnEdit = this.cmbApprovedStatus;
			this.gridColumn7.FieldName = "nApprovedStatusID";
			this.gridColumn7.Name = "gridColumn7";
			this.gridColumn7.Visible = true;
			this.gridColumn7.VisibleIndex = 8;
			this.gridColumn7.Width = 89;
			// 
			// cmbApprovedStatus
			// 
			this.cmbApprovedStatus.AutoHeight = false;
			this.cmbApprovedStatus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																										   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cmbApprovedStatus.Items.AddRange(new object[] {
																   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Pending Approval", 0, -1),
																   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Approved", 1, -1),
																   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Rejected", 2, -1)});
			this.cmbApprovedStatus.Name = "cmbApprovedStatus";
			// 
			// gridColumn8
			// 
			this.gridColumn8.Caption = "Discount %";
			this.gridColumn8.DisplayFormat.FormatString = "P";
			this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumn8.FieldName = "dDiscountPercent";
			this.gridColumn8.Name = "gridColumn8";
			this.gridColumn8.Visible = true;
			this.gridColumn8.VisibleIndex = 9;
			this.gridColumn8.Width = 71;
			// 
			// gridColumn9
			// 
			this.gridColumn9.Caption = "Discount Value";
			this.gridColumn9.DisplayFormat.FormatString = "#.##";
			this.gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumn9.FieldName = "dDiscountValue";
			this.gridColumn9.Name = "gridColumn9";
			this.gridColumn9.Visible = true;
			this.gridColumn9.VisibleIndex = 10;
			this.gridColumn9.Width = 111;
			// 
			// Searchpanel
			// 
			this.Searchpanel.BackColor = System.Drawing.Color.Transparent;
			this.Searchpanel.Controls.Add(this.btn_Search);
			this.Searchpanel.Controls.Add(this.txtSearch);
			this.Searchpanel.Location = new System.Drawing.Point(456, 16);
			this.Searchpanel.Name = "Searchpanel";
			this.Searchpanel.Size = new System.Drawing.Size(464, 32);
			this.Searchpanel.TabIndex = 149;
			// 
			// btn_Search
			// 
			this.btn_Search.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.btn_Search.Appearance.Options.UseFont = true;
			this.btn_Search.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btn_Search.Location = new System.Drawing.Point(384, 8);
			this.btn_Search.Name = "btn_Search";
			this.btn_Search.Size = new System.Drawing.Size(56, 20);
			this.btn_Search.TabIndex = 137;
			this.btn_Search.Text = "Search";
			this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
			// 
			// txtSearch
			// 
			this.txtSearch.EditValue = "";
			this.txtSearch.Location = new System.Drawing.Point(200, 8);
			this.txtSearch.Name = "txtSearch";
			// 
			// txtSearch.Properties
			// 
			this.txtSearch.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtSearch.Properties.Appearance.Options.UseFont = true;
			this.txtSearch.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.txtSearch.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.txtSearch.Size = new System.Drawing.Size(168, 20);
			this.txtSearch.TabIndex = 136;
			this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
			// 
			// btn_Add
			// 
			this.btn_Add.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
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
			this.btn_Add.TabIndex = 134;
			this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
			// 
			// btn_Del
			// 
			this.btn_Del.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
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
			this.btn_Del.TabIndex = 133;
			this.btn_Del.Click += new System.EventHandler(this.btn_Del_Click);
			// 
			// grpMDPromotionBelow
			// 
			this.grpMDPromotionBelow.Controls.Add(this.grpMDPromotionBelow2);
			this.grpMDPromotionBelow.Location = new System.Drawing.Point(8, 240);
			this.grpMDPromotionBelow.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.grpMDPromotionBelow.LookAndFeel.UseDefaultLookAndFeel = false;
			this.grpMDPromotionBelow.LookAndFeel.UseWindowsXPTheme = false;
			this.grpMDPromotionBelow.Name = "grpMDPromotionBelow";
			this.grpMDPromotionBelow.Size = new System.Drawing.Size(960, 288);
			this.grpMDPromotionBelow.TabIndex = 93;
			this.grpMDPromotionBelow.Text = "Branch Promotion ";
			// 
			// grpMDPromotionBelow2
			// 
			this.grpMDPromotionBelow2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.grpMDPromotionBelow2.Controls.Add(this.TabControlPromotion);
			this.grpMDPromotionBelow2.Location = new System.Drawing.Point(8, 24);
			this.grpMDPromotionBelow2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.grpMDPromotionBelow2.LookAndFeel.UseDefaultLookAndFeel = false;
			this.grpMDPromotionBelow2.Name = "grpMDPromotionBelow2";
			this.grpMDPromotionBelow2.ShowCaption = false;
			this.grpMDPromotionBelow2.Size = new System.Drawing.Size(944, 264);
			this.grpMDPromotionBelow2.TabIndex = 6;
			this.grpMDPromotionBelow2.Text = "groupControl1";
			// 
			// TabControlPromotion
			// 
			this.TabControlPromotion.AppearancePage.Header.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.TabControlPromotion.AppearancePage.Header.Options.UseFont = true;
			this.TabControlPromotion.Location = new System.Drawing.Point(8, 8);
			this.TabControlPromotion.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.TabControlPromotion.LookAndFeel.UseDefaultLookAndFeel = false;
			this.TabControlPromotion.Name = "TabControlPromotion";
			this.TabControlPromotion.SelectedTabPage = this.tabPromo_Brnch;
			this.TabControlPromotion.Size = new System.Drawing.Size(928, 248);
			this.TabControlPromotion.TabIndex = 132;
			this.TabControlPromotion.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
																								this.tabPromo_Brnch,
																								this.tabPromo_Freebies,
																								this.tabPromo_Package,
																								this.tabPromo_ReceiptSalesCategory});
			this.TabControlPromotion.Text = "xtraTabControl1";
			// 
			// tabPromo_Brnch
			// 
			this.tabPromo_Brnch.Controls.Add(this.groupControl1);
			this.tabPromo_Brnch.Name = "tabPromo_Brnch";
			this.tabPromo_Brnch.Size = new System.Drawing.Size(919, 217);
			this.tabPromo_Brnch.Text = "Branch";
			// 
			// groupControl1
			// 
			this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.groupControl1.Controls.Add(this.btnBranch_Del);
			this.groupControl1.Controls.Add(this.btnBranch_DelAll);
			this.groupControl1.Controls.Add(this.btnBranch_AddAll);
			this.groupControl1.Controls.Add(this.btnBranch_Add);
			this.groupControl1.Controls.Add(this.gridBranch2);
			this.groupControl1.Controls.Add(this.label4);
			this.groupControl1.Controls.Add(this.gridBranch);
			this.groupControl1.Location = new System.Drawing.Point(0, 8);
			this.groupControl1.Name = "groupControl1";
			this.groupControl1.Size = new System.Drawing.Size(912, 240);
			this.groupControl1.TabIndex = 88;
			this.groupControl1.Text = "groupControl1";
			// 
			// btnBranch_Del
			// 
			this.btnBranch_Del.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnBranch_Del.Location = new System.Drawing.Point(440, 120);
			this.btnBranch_Del.Name = "btnBranch_Del";
			this.btnBranch_Del.Size = new System.Drawing.Size(30, 20);
			this.btnBranch_Del.TabIndex = 28;
			this.btnBranch_Del.Text = "<";
			this.btnBranch_Del.Click += new System.EventHandler(this.btnBranch_Del_Click);
			// 
			// btnBranch_DelAll
			// 
			this.btnBranch_DelAll.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnBranch_DelAll.Location = new System.Drawing.Point(440, 72);
			this.btnBranch_DelAll.Name = "btnBranch_DelAll";
			this.btnBranch_DelAll.Size = new System.Drawing.Size(30, 20);
			this.btnBranch_DelAll.TabIndex = 27;
			this.btnBranch_DelAll.Text = "<<";
			this.btnBranch_DelAll.Click += new System.EventHandler(this.btnBranch_DelAll_Click);
			// 
			// btnBranch_AddAll
			// 
			this.btnBranch_AddAll.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnBranch_AddAll.Location = new System.Drawing.Point(440, 96);
			this.btnBranch_AddAll.Name = "btnBranch_AddAll";
			this.btnBranch_AddAll.Size = new System.Drawing.Size(30, 20);
			this.btnBranch_AddAll.TabIndex = 26;
			this.btnBranch_AddAll.Text = ">>";
			this.btnBranch_AddAll.Click += new System.EventHandler(this.btnBranch_AddAll_Click);
			// 
			// btnBranch_Add
			// 
			this.btnBranch_Add.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnBranch_Add.Location = new System.Drawing.Point(440, 48);
			this.btnBranch_Add.Name = "btnBranch_Add";
			this.btnBranch_Add.Size = new System.Drawing.Size(30, 20);
			this.btnBranch_Add.TabIndex = 25;
			this.btnBranch_Add.Text = ">";
			this.btnBranch_Add.Click += new System.EventHandler(this.btnBranch_Add_Click);
			// 
			// gridBranch2
			// 
			// 
			// gridBranch2.EmbeddedNavigator
			// 
			this.gridBranch2.EmbeddedNavigator.Name = "";
			this.gridBranch2.Location = new System.Drawing.Point(480, 8);
			this.gridBranch2.MainView = this.gvBranch2;
			this.gridBranch2.Name = "gridBranch2";
			this.gridBranch2.Size = new System.Drawing.Size(424, 192);
			this.gridBranch2.TabIndex = 29;
			this.gridBranch2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																									   this.gvBranch2});
			// 
			// gvBranch2
			// 
			this.gvBranch2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn33,
																							 this.gridColumn34});
			this.gvBranch2.GridControl = this.gridBranch2;
			this.gvBranch2.Name = "gvBranch2";
			this.gvBranch2.OptionsBehavior.AllowIncrementalSearch = true;
			this.gvBranch2.OptionsBehavior.Editable = false;
			this.gvBranch2.OptionsCustomization.AllowFilter = false;
			this.gvBranch2.OptionsSelection.MultiSelect = true;
			this.gvBranch2.OptionsView.ShowGroupPanel = false;
			this.gvBranch2.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
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
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(-116, -24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(92, 34);
			this.label4.TabIndex = 30;
			this.label4.Text = "Package Branch";
			// 
			// gridBranch
			// 
			// 
			// gridBranch.EmbeddedNavigator
			// 
			this.gridBranch.EmbeddedNavigator.Name = "";
			this.gridBranch.Location = new System.Drawing.Point(8, 8);
			this.gridBranch.MainView = this.gvBranch;
			this.gridBranch.Name = "gridBranch";
			this.gridBranch.Size = new System.Drawing.Size(424, 200);
			this.gridBranch.TabIndex = 24;
			this.gridBranch.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																									  this.gvBranch});
			// 
			// gvBranch
			// 
			this.gvBranch.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							this.gridColumn35,
																							this.gridColumn36});
			this.gvBranch.GridControl = this.gridBranch;
			this.gvBranch.Name = "gvBranch";
			this.gvBranch.OptionsBehavior.AllowIncrementalSearch = true;
			this.gvBranch.OptionsBehavior.Editable = false;
			this.gvBranch.OptionsCustomization.AllowFilter = false;
			this.gvBranch.OptionsSelection.MultiSelect = true;
			this.gvBranch.OptionsView.ShowGroupPanel = false;
			this.gvBranch.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
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
			// tabPromo_Freebies
			// 
			this.tabPromo_Freebies.Controls.Add(this.groupControl2);
			this.tabPromo_Freebies.Controls.Add(this.btnReset);
			this.tabPromo_Freebies.Controls.Add(this.btnSearch);
			this.tabPromo_Freebies.Controls.Add(this.txtItemStyle);
			this.tabPromo_Freebies.Controls.Add(this.label3);
			this.tabPromo_Freebies.Controls.Add(this.txtItemCode);
			this.tabPromo_Freebies.Controls.Add(this.label2);
			this.tabPromo_Freebies.Controls.Add(this.txtItemDesc);
			this.tabPromo_Freebies.Controls.Add(this.label1);
			this.tabPromo_Freebies.Name = "tabPromo_Freebies";
			this.tabPromo_Freebies.Size = new System.Drawing.Size(919, 217);
			this.tabPromo_Freebies.Text = "Freebies";
			// 
			// groupControl2
			// 
			this.groupControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.groupControl2.Controls.Add(this.btnFreebies_Del);
			this.groupControl2.Controls.Add(this.btnFreebies_DelAll);
			this.groupControl2.Controls.Add(this.btnFreebies_AddAll);
			this.groupControl2.Controls.Add(this.btnFreebies_Add);
			this.groupControl2.Controls.Add(this.gdFreebies2);
			this.groupControl2.Controls.Add(this.gdFreebies);
			this.groupControl2.Location = new System.Drawing.Point(0, 32);
			this.groupControl2.Name = "groupControl2";
			this.groupControl2.Size = new System.Drawing.Size(912, 184);
			this.groupControl2.TabIndex = 115;
			this.groupControl2.Text = "groupControl2";
			// 
			// btnFreebies_Del
			// 
			this.btnFreebies_Del.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnFreebies_Del.Location = new System.Drawing.Point(440, 88);
			this.btnFreebies_Del.Name = "btnFreebies_Del";
			this.btnFreebies_Del.Size = new System.Drawing.Size(30, 20);
			this.btnFreebies_Del.TabIndex = 94;
			this.btnFreebies_Del.Text = "<";
			this.btnFreebies_Del.Click += new System.EventHandler(this.btnFreebies_Del_Click);
			// 
			// btnFreebies_DelAll
			// 
			this.btnFreebies_DelAll.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnFreebies_DelAll.Location = new System.Drawing.Point(440, 64);
			this.btnFreebies_DelAll.Name = "btnFreebies_DelAll";
			this.btnFreebies_DelAll.Size = new System.Drawing.Size(30, 20);
			this.btnFreebies_DelAll.TabIndex = 93;
			this.btnFreebies_DelAll.Text = "<<";
			this.btnFreebies_DelAll.Click += new System.EventHandler(this.btnFreebies_DelAll_Click);
			// 
			// btnFreebies_AddAll
			// 
			this.btnFreebies_AddAll.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnFreebies_AddAll.Location = new System.Drawing.Point(440, 40);
			this.btnFreebies_AddAll.Name = "btnFreebies_AddAll";
			this.btnFreebies_AddAll.Size = new System.Drawing.Size(30, 20);
			this.btnFreebies_AddAll.TabIndex = 92;
			this.btnFreebies_AddAll.Text = ">>";
			this.btnFreebies_AddAll.Click += new System.EventHandler(this.btnFreebies_AddAll_Click);
			// 
			// btnFreebies_Add
			// 
			this.btnFreebies_Add.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnFreebies_Add.Location = new System.Drawing.Point(440, 16);
			this.btnFreebies_Add.Name = "btnFreebies_Add";
			this.btnFreebies_Add.Size = new System.Drawing.Size(30, 20);
			this.btnFreebies_Add.TabIndex = 91;
			this.btnFreebies_Add.Text = ">";
			this.btnFreebies_Add.Click += new System.EventHandler(this.btnFreebies_Add_Click);
			// 
			// gdFreebies2
			// 
			// 
			// gdFreebies2.EmbeddedNavigator
			// 
			this.gdFreebies2.EmbeddedNavigator.Name = "";
			this.gdFreebies2.Location = new System.Drawing.Point(484, 12);
			this.gdFreebies2.MainView = this.gvFreebies2;
			this.gdFreebies2.Name = "gdFreebies2";
			this.gdFreebies2.Size = new System.Drawing.Size(424, 160);
			this.gdFreebies2.TabIndex = 95;
			this.gdFreebies2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																									   this.gvFreebies2});
			// 
			// gvFreebies2
			// 
			this.gvFreebies2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							   this.gridColumn10,
																							   this.gridColumn11,
																							   this.gridColumn14});
			this.gvFreebies2.GridControl = this.gdFreebies2;
			this.gvFreebies2.Name = "gvFreebies2";
			this.gvFreebies2.OptionsBehavior.AllowIncrementalSearch = true;
			this.gvFreebies2.OptionsBehavior.Editable = false;
			this.gvFreebies2.OptionsCustomization.AllowFilter = false;
			this.gvFreebies2.OptionsSelection.MultiSelect = true;
			this.gvFreebies2.OptionsView.ShowGroupPanel = false;
			this.gvFreebies2.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
																										new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn10, DevExpress.Data.ColumnSortOrder.Ascending)});
			// 
			// gridColumn10
			// 
			this.gridColumn10.Caption = "Product Code";
			this.gridColumn10.FieldName = "strItemCode";
			this.gridColumn10.Name = "gridColumn10";
			this.gridColumn10.Visible = true;
			this.gridColumn10.VisibleIndex = 0;
			this.gridColumn10.Width = 104;
			// 
			// gridColumn11
			// 
			this.gridColumn11.Caption = "Description";
			this.gridColumn11.FieldName = "strDescription";
			this.gridColumn11.Name = "gridColumn11";
			this.gridColumn11.Visible = true;
			this.gridColumn11.VisibleIndex = 1;
			this.gridColumn11.Width = 282;
			// 
			// gridColumn14
			// 
			this.gridColumn14.Caption = "Promotion Code";
			this.gridColumn14.FieldName = "strPromotionCode";
			this.gridColumn14.Name = "gridColumn14";
			// 
			// gdFreebies
			// 
			// 
			// gdFreebies.EmbeddedNavigator
			// 
			this.gdFreebies.EmbeddedNavigator.Name = "";
			this.gdFreebies.Location = new System.Drawing.Point(4, 12);
			this.gdFreebies.MainView = this.gvFreebies;
			this.gdFreebies.Name = "gdFreebies";
			this.gdFreebies.Size = new System.Drawing.Size(424, 164);
			this.gdFreebies.TabIndex = 90;
			this.gdFreebies.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																									  this.gvFreebies});
			// 
			// gvFreebies
			// 
			this.gvFreebies.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							  this.gridColumn12,
																							  this.gridColumn13});
			this.gvFreebies.GridControl = this.gdFreebies;
			this.gvFreebies.Name = "gvFreebies";
			this.gvFreebies.OptionsBehavior.AllowIncrementalSearch = true;
			this.gvFreebies.OptionsBehavior.Editable = false;
			this.gvFreebies.OptionsCustomization.AllowFilter = false;
			this.gvFreebies.OptionsSelection.MultiSelect = true;
			this.gvFreebies.OptionsView.ShowGroupPanel = false;
			this.gvFreebies.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
																									   new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn12, DevExpress.Data.ColumnSortOrder.Ascending)});
			// 
			// gridColumn12
			// 
			this.gridColumn12.Caption = "Product Code";
			this.gridColumn12.FieldName = "strProductCode";
			this.gridColumn12.Name = "gridColumn12";
			this.gridColumn12.Visible = true;
			this.gridColumn12.VisibleIndex = 0;
			this.gridColumn12.Width = 107;
			// 
			// gridColumn13
			// 
			this.gridColumn13.Caption = "Description";
			this.gridColumn13.FieldName = "strDescription";
			this.gridColumn13.Name = "gridColumn13";
			this.gridColumn13.Visible = true;
			this.gridColumn13.VisibleIndex = 1;
			this.gridColumn13.Width = 279;
			// 
			// btnReset
			// 
			this.btnReset.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.btnReset.Appearance.Options.UseFont = true;
			this.btnReset.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnReset.Location = new System.Drawing.Point(688, 8);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(72, 20);
			this.btnReset.TabIndex = 114;
			this.btnReset.Text = "Reset";
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// btnSearch
			// 
			this.btnSearch.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.btnSearch.Appearance.Options.UseFont = true;
			this.btnSearch.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnSearch.Location = new System.Drawing.Point(600, 8);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(72, 20);
			this.btnSearch.TabIndex = 113;
			this.btnSearch.Text = "Search";
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// txtItemStyle
			// 
			this.txtItemStyle.EditValue = "";
			this.txtItemStyle.Location = new System.Drawing.Point(472, 8);
			this.txtItemStyle.Name = "txtItemStyle";
			this.txtItemStyle.TabIndex = 112;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(392, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 16);
			this.label3.TabIndex = 111;
			this.label3.Text = "Item Style :";
			// 
			// txtItemCode
			// 
			this.txtItemCode.EditValue = "";
			this.txtItemCode.Location = new System.Drawing.Point(280, 8);
			this.txtItemCode.Name = "txtItemCode";
			this.txtItemCode.TabIndex = 110;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(192, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 16);
			this.label2.TabIndex = 109;
			this.label2.Text = "Item Code :";
			// 
			// txtItemDesc
			// 
			this.txtItemDesc.EditValue = "";
			this.txtItemDesc.Location = new System.Drawing.Point(80, 8);
			this.txtItemDesc.Name = "txtItemDesc";
			this.txtItemDesc.TabIndex = 108;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 16);
			this.label1.TabIndex = 107;
			this.label1.Text = "Item Desc :";
			// 
			// tabPromo_Package
			// 
			this.tabPromo_Package.Controls.Add(this.groupControl3);
			this.tabPromo_Package.Controls.Add(this.btnPcReset);
			this.tabPromo_Package.Controls.Add(this.btnPcSearch);
			this.tabPromo_Package.Controls.Add(this.txtPcItemCode);
			this.tabPromo_Package.Controls.Add(this.label5);
			this.tabPromo_Package.Controls.Add(this.txtPcItemDesc);
			this.tabPromo_Package.Controls.Add(this.label6);
			this.tabPromo_Package.Name = "tabPromo_Package";
			this.tabPromo_Package.Size = new System.Drawing.Size(919, 217);
			this.tabPromo_Package.Text = "Package";
			// 
			// groupControl3
			// 
			this.groupControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.groupControl3.Controls.Add(this.btnPackage_Del);
			this.groupControl3.Controls.Add(this.btnPackage_DelAll);
			this.groupControl3.Controls.Add(this.btnPackage_AddAll);
			this.groupControl3.Controls.Add(this.btnPackage_Add);
			this.groupControl3.Controls.Add(this.gdPackage2);
			this.groupControl3.Controls.Add(this.gdPackage);
			this.groupControl3.Location = new System.Drawing.Point(0, 32);
			this.groupControl3.Name = "groupControl3";
			this.groupControl3.Size = new System.Drawing.Size(912, 184);
			this.groupControl3.TabIndex = 123;
			this.groupControl3.Text = "groupControl3";
			// 
			// btnPackage_Del
			// 
			this.btnPackage_Del.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnPackage_Del.Location = new System.Drawing.Point(440, 88);
			this.btnPackage_Del.Name = "btnPackage_Del";
			this.btnPackage_Del.Size = new System.Drawing.Size(30, 20);
			this.btnPackage_Del.TabIndex = 94;
			this.btnPackage_Del.Text = "<";
			this.btnPackage_Del.Click += new System.EventHandler(this.btnPackage_Del_Click);
			// 
			// btnPackage_DelAll
			// 
			this.btnPackage_DelAll.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnPackage_DelAll.Location = new System.Drawing.Point(440, 64);
			this.btnPackage_DelAll.Name = "btnPackage_DelAll";
			this.btnPackage_DelAll.Size = new System.Drawing.Size(30, 20);
			this.btnPackage_DelAll.TabIndex = 93;
			this.btnPackage_DelAll.Text = "<<";
			this.btnPackage_DelAll.Click += new System.EventHandler(this.btnPackage_DelAll_Click);
			// 
			// btnPackage_AddAll
			// 
			this.btnPackage_AddAll.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnPackage_AddAll.Location = new System.Drawing.Point(440, 40);
			this.btnPackage_AddAll.Name = "btnPackage_AddAll";
			this.btnPackage_AddAll.Size = new System.Drawing.Size(30, 20);
			this.btnPackage_AddAll.TabIndex = 92;
			this.btnPackage_AddAll.Text = ">>";
			this.btnPackage_AddAll.Click += new System.EventHandler(this.btnPackage_AddAll_Click);
			// 
			// btnPackage_Add
			// 
			this.btnPackage_Add.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnPackage_Add.Location = new System.Drawing.Point(440, 16);
			this.btnPackage_Add.Name = "btnPackage_Add";
			this.btnPackage_Add.Size = new System.Drawing.Size(30, 20);
			this.btnPackage_Add.TabIndex = 91;
			this.btnPackage_Add.Text = ">";
			this.btnPackage_Add.Click += new System.EventHandler(this.btnPackage_Add_Click);
			// 
			// gdPackage2
			// 
			// 
			// gdPackage2.EmbeddedNavigator
			// 
			this.gdPackage2.EmbeddedNavigator.Name = "";
			this.gdPackage2.Location = new System.Drawing.Point(484, 12);
			this.gdPackage2.MainView = this.gvPackage2;
			this.gdPackage2.Name = "gdPackage2";
			this.gdPackage2.Size = new System.Drawing.Size(424, 160);
			this.gdPackage2.TabIndex = 95;
			this.gdPackage2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																									  this.gvPackage2});
			// 
			// gvPackage2
			// 
			this.gvPackage2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							  this.gridColumn15,
																							  this.gridColumn16,
																							  this.gridColumn17});
			this.gvPackage2.GridControl = this.gdPackage2;
			this.gvPackage2.Name = "gvPackage2";
			this.gvPackage2.OptionsBehavior.AllowIncrementalSearch = true;
			this.gvPackage2.OptionsBehavior.Editable = false;
			this.gvPackage2.OptionsCustomization.AllowFilter = false;
			this.gvPackage2.OptionsSelection.MultiSelect = true;
			this.gvPackage2.OptionsView.ShowGroupPanel = false;
			this.gvPackage2.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
																									   new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn15, DevExpress.Data.ColumnSortOrder.Ascending)});
			// 
			// gridColumn15
			// 
			this.gridColumn15.Caption = "Product Code";
			this.gridColumn15.FieldName = "strPackageCode";
			this.gridColumn15.Name = "gridColumn15";
			this.gridColumn15.Visible = true;
			this.gridColumn15.VisibleIndex = 0;
			this.gridColumn15.Width = 104;
			// 
			// gridColumn16
			// 
			this.gridColumn16.Caption = "Description";
			this.gridColumn16.FieldName = "strDescription";
			this.gridColumn16.Name = "gridColumn16";
			this.gridColumn16.Visible = true;
			this.gridColumn16.VisibleIndex = 1;
			this.gridColumn16.Width = 282;
			// 
			// gridColumn17
			// 
			this.gridColumn17.Caption = "Promotion Code";
			this.gridColumn17.FieldName = "strPromotionCode";
			this.gridColumn17.Name = "gridColumn17";
			// 
			// gdPackage
			// 
			// 
			// gdPackage.EmbeddedNavigator
			// 
			this.gdPackage.EmbeddedNavigator.Name = "";
			this.gdPackage.Location = new System.Drawing.Point(4, 12);
			this.gdPackage.MainView = this.gvPackage;
			this.gdPackage.Name = "gdPackage";
			this.gdPackage.Size = new System.Drawing.Size(424, 164);
			this.gdPackage.TabIndex = 90;
			this.gdPackage.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																									 this.gvPackage});
			// 
			// gvPackage
			// 
			this.gvPackage.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn18,
																							 this.gridColumn19});
			this.gvPackage.GridControl = this.gdPackage;
			this.gvPackage.Name = "gvPackage";
			this.gvPackage.OptionsBehavior.AllowIncrementalSearch = true;
			this.gvPackage.OptionsBehavior.Editable = false;
			this.gvPackage.OptionsCustomization.AllowFilter = false;
			this.gvPackage.OptionsSelection.MultiSelect = true;
			this.gvPackage.OptionsView.ShowGroupPanel = false;
			this.gvPackage.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
																									  new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn18, DevExpress.Data.ColumnSortOrder.Ascending)});
			// 
			// gridColumn18
			// 
			this.gridColumn18.Caption = "Product Code";
			this.gridColumn18.FieldName = "strPackageCode";
			this.gridColumn18.Name = "gridColumn18";
			this.gridColumn18.Visible = true;
			this.gridColumn18.VisibleIndex = 0;
			this.gridColumn18.Width = 107;
			// 
			// gridColumn19
			// 
			this.gridColumn19.Caption = "Description";
			this.gridColumn19.FieldName = "strDescription";
			this.gridColumn19.Name = "gridColumn19";
			this.gridColumn19.Visible = true;
			this.gridColumn19.VisibleIndex = 1;
			this.gridColumn19.Width = 279;
			// 
			// btnPcReset
			// 
			this.btnPcReset.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.btnPcReset.Appearance.Options.UseFont = true;
			this.btnPcReset.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnPcReset.Location = new System.Drawing.Point(464, 8);
			this.btnPcReset.Name = "btnPcReset";
			this.btnPcReset.Size = new System.Drawing.Size(72, 20);
			this.btnPcReset.TabIndex = 122;
			this.btnPcReset.Text = "Reset";
			this.btnPcReset.Click += new System.EventHandler(this.btnPcReset_Click);
			// 
			// btnPcSearch
			// 
			this.btnPcSearch.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.btnPcSearch.Appearance.Options.UseFont = true;
			this.btnPcSearch.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnPcSearch.Location = new System.Drawing.Point(376, 8);
			this.btnPcSearch.Name = "btnPcSearch";
			this.btnPcSearch.Size = new System.Drawing.Size(72, 20);
			this.btnPcSearch.TabIndex = 121;
			this.btnPcSearch.Text = "Search";
			this.btnPcSearch.Click += new System.EventHandler(this.btnPcSearch_Click);
			// 
			// txtPcItemCode
			// 
			this.txtPcItemCode.EditValue = "";
			this.txtPcItemCode.Location = new System.Drawing.Point(80, 8);
			this.txtPcItemCode.Name = "txtPcItemCode";
			this.txtPcItemCode.Size = new System.Drawing.Size(96, 20);
			this.txtPcItemCode.TabIndex = 118;
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.Location = new System.Drawing.Point(192, 8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 16);
			this.label5.TabIndex = 117;
			this.label5.Text = "Item Desc :";
			// 
			// txtPcItemDesc
			// 
			this.txtPcItemDesc.EditValue = "";
			this.txtPcItemDesc.Location = new System.Drawing.Point(264, 8);
			this.txtPcItemDesc.Name = "txtPcItemDesc";
			this.txtPcItemDesc.Size = new System.Drawing.Size(96, 20);
			this.txtPcItemDesc.TabIndex = 116;
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label6.Location = new System.Drawing.Point(8, 8);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(96, 16);
			this.label6.TabIndex = 115;
			this.label6.Text = "Item Code :";
			// 
			// tabPromo_ReceiptSalesCategory
			// 
			this.tabPromo_ReceiptSalesCategory.Controls.Add(this.groupControl4);
			this.tabPromo_ReceiptSalesCategory.Name = "tabPromo_ReceiptSalesCategory";
			this.tabPromo_ReceiptSalesCategory.Size = new System.Drawing.Size(919, 217);
			this.tabPromo_ReceiptSalesCategory.Text = "Receipt Sales Category";
			// 
			// groupControl4
			// 
			this.groupControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.groupControl4.Controls.Add(this.btnSales_Del);
			this.groupControl4.Controls.Add(this.btnSales_DelAll);
			this.groupControl4.Controls.Add(this.btnSales_AddAll);
			this.groupControl4.Controls.Add(this.btnSales_Add);
			this.groupControl4.Controls.Add(this.gridSales2);
			this.groupControl4.Controls.Add(this.gridSales);
			this.groupControl4.Location = new System.Drawing.Point(3, 16);
			this.groupControl4.Name = "groupControl4";
			this.groupControl4.Size = new System.Drawing.Size(912, 184);
			this.groupControl4.TabIndex = 124;
			this.groupControl4.Text = "groupControl4";
			// 
			// btnSales_Del
			// 
			this.btnSales_Del.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnSales_Del.Location = new System.Drawing.Point(440, 88);
			this.btnSales_Del.Name = "btnSales_Del";
			this.btnSales_Del.Size = new System.Drawing.Size(30, 20);
			this.btnSales_Del.TabIndex = 94;
			this.btnSales_Del.Text = "<";
			this.btnSales_Del.Click += new System.EventHandler(this.btnSales_Del_Click);
			// 
			// btnSales_DelAll
			// 
			this.btnSales_DelAll.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnSales_DelAll.Location = new System.Drawing.Point(440, 64);
			this.btnSales_DelAll.Name = "btnSales_DelAll";
			this.btnSales_DelAll.Size = new System.Drawing.Size(30, 20);
			this.btnSales_DelAll.TabIndex = 93;
			this.btnSales_DelAll.Text = "<<";
			this.btnSales_DelAll.Click += new System.EventHandler(this.btnSales_DelAll_Click);
			// 
			// btnSales_AddAll
			// 
			this.btnSales_AddAll.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnSales_AddAll.Location = new System.Drawing.Point(440, 40);
			this.btnSales_AddAll.Name = "btnSales_AddAll";
			this.btnSales_AddAll.Size = new System.Drawing.Size(30, 20);
			this.btnSales_AddAll.TabIndex = 92;
			this.btnSales_AddAll.Text = ">>";
			this.btnSales_AddAll.Click += new System.EventHandler(this.btnSales_AddAll_Click);
			// 
			// btnSales_Add
			// 
			this.btnSales_Add.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnSales_Add.Location = new System.Drawing.Point(440, 16);
			this.btnSales_Add.Name = "btnSales_Add";
			this.btnSales_Add.Size = new System.Drawing.Size(30, 20);
			this.btnSales_Add.TabIndex = 91;
			this.btnSales_Add.Text = ">";
			this.btnSales_Add.Click += new System.EventHandler(this.btnSales_Add_Click);
			// 
			// gridSales2
			// 
			// 
			// gridSales2.EmbeddedNavigator
			// 
			this.gridSales2.EmbeddedNavigator.Name = "";
			this.gridSales2.Location = new System.Drawing.Point(484, 12);
			this.gridSales2.MainView = this.gvSales2;
			this.gridSales2.Name = "gridSales2";
			this.gridSales2.Size = new System.Drawing.Size(424, 160);
			this.gridSales2.TabIndex = 95;
			this.gridSales2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																									  this.gvSales2});
			// 
			// gvSales2
			// 
			this.gvSales2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							this.gridColumn20,
																							this.gridColumn21,
																							this.gridColumn22});
			this.gvSales2.GridControl = this.gridSales2;
			this.gvSales2.Name = "gvSales2";
			this.gvSales2.OptionsBehavior.AllowIncrementalSearch = true;
			this.gvSales2.OptionsBehavior.Editable = false;
			this.gvSales2.OptionsCustomization.AllowFilter = false;
			this.gvSales2.OptionsSelection.MultiSelect = true;
			this.gvSales2.OptionsView.ShowGroupPanel = false;
			this.gvSales2.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
																									 new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn20, DevExpress.Data.ColumnSortOrder.Ascending)});
			// 
			// gridColumn20
			// 
			this.gridColumn20.Caption = "Sales Category Id";
			this.gridColumn20.FieldName = "nSalesCategoryID";
			this.gridColumn20.Name = "gridColumn20";
			this.gridColumn20.Visible = true;
			this.gridColumn20.VisibleIndex = 0;
			this.gridColumn20.Width = 104;
			// 
			// gridColumn21
			// 
			this.gridColumn21.Caption = "Description";
			this.gridColumn21.FieldName = "strDescription";
			this.gridColumn21.Name = "gridColumn21";
			this.gridColumn21.Visible = true;
			this.gridColumn21.VisibleIndex = 1;
			this.gridColumn21.Width = 282;
			// 
			// gridColumn22
			// 
			this.gridColumn22.Caption = "Promotion Code";
			this.gridColumn22.FieldName = "strPromotionCode";
			this.gridColumn22.Name = "gridColumn22";
			// 
			// gridSales
			// 
			// 
			// gridSales.EmbeddedNavigator
			// 
			this.gridSales.EmbeddedNavigator.Name = "";
			this.gridSales.Location = new System.Drawing.Point(4, 12);
			this.gridSales.MainView = this.gvSales;
			this.gridSales.Name = "gridSales";
			this.gridSales.Size = new System.Drawing.Size(424, 164);
			this.gridSales.TabIndex = 90;
			this.gridSales.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																									 this.gvSales});
			// 
			// gvSales
			// 
			this.gvSales.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																						   this.gridColumn23,
																						   this.gridColumn24});
			this.gvSales.GridControl = this.gridSales;
			this.gvSales.Name = "gvSales";
			this.gvSales.OptionsBehavior.AllowIncrementalSearch = true;
			this.gvSales.OptionsBehavior.Editable = false;
			this.gvSales.OptionsCustomization.AllowFilter = false;
			this.gvSales.OptionsSelection.MultiSelect = true;
			this.gvSales.OptionsView.ShowGroupPanel = false;
			this.gvSales.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
																									new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn23, DevExpress.Data.ColumnSortOrder.Ascending)});
			// 
			// gridColumn23
			// 
			this.gridColumn23.Caption = "Sales Category Id";
			this.gridColumn23.FieldName = "nSalesCategoryID";
			this.gridColumn23.Name = "gridColumn23";
			this.gridColumn23.Visible = true;
			this.gridColumn23.VisibleIndex = 0;
			this.gridColumn23.Width = 107;
			// 
			// gridColumn24
			// 
			this.gridColumn24.Caption = "Description";
			this.gridColumn24.FieldName = "strDescription";
			this.gridColumn24.Name = "gridColumn24";
			this.gridColumn24.Visible = true;
			this.gridColumn24.VisibleIndex = 1;
			this.gridColumn24.Width = 279;
			// 
			// frmPromotion
			// 
			this.AutoScale = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(982, 533);
			this.Controls.Add(this.grpMDPromotionBelow);
			this.Controls.Add(this.grpMDPromotionTop);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmPromotion";
			this.Text = "frmPromotion";
			this.Load += new System.EventHandler(this.frmPromotion_Load);
			((System.ComponentModel.ISupportInitialize)(this.grpMDPromotionTop)).EndInit();
			this.grpMDPromotionTop.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControlMd_Promotion)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewMd_Promotion)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_DiscountCategory)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmPromotionType)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbItemDiscount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtStartDate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtEndDate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbApprovedStatus)).EndInit();
			this.Searchpanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grpMDPromotionBelow)).EndInit();
			this.grpMDPromotionBelow.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grpMDPromotionBelow2)).EndInit();
			this.grpMDPromotionBelow2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.TabControlPromotion)).EndInit();
			this.TabControlPromotion.ResumeLayout(false);
			this.tabPromo_Brnch.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
			this.groupControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridBranch2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvBranch2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridBranch)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvBranch)).EndInit();
			this.tabPromo_Freebies.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
			this.groupControl2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gdFreebies2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvFreebies2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gdFreebies)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvFreebies)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtItemStyle.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtItemCode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtItemDesc.Properties)).EndInit();
			this.tabPromo_Package.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
			this.groupControl3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gdPackage2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvPackage2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gdPackage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvPackage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPcItemCode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPcItemDesc.Properties)).EndInit();
			this.tabPromo_ReceiptSalesCategory.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
			this.groupControl4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridSales2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvSales2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridSales)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvSales)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region load
		private void mdPromotionInit()
		{
			DataSet _ds = new DataSet();
			string strSQL;

			strSQL = "select * from tblDiscountCategory";
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			DataTable dt = _ds.Tables["table"];
			
			DevExpress.XtraEditors.Controls.LookUpColumnInfo[] col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
			
			col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nDiscountCategoryID","Discount Category Id",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription","Description",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
		
			new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(lk_DiscountCategory,dt,col,"strDescription","nDiscountCategoryID","Discount Category");

			strSQL = "select * from tblPromotion where strPromotionCode like '%" + txtSearch.Text + "%' or  strDescription like '%" + txtSearch.Text +"%'";
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dtPromotion = _ds.Tables["table"];
			gridControlMd_Promotion.DataSource = dtPromotion;

		}

		private void RefreshPromotion()
		{
			mdPromotionInit();
		}

		private void ClearCheckedList(DevExpress.XtraEditors.CheckedListBoxControl control)
		{
			//Clear Item List
			control.Refresh();
			for (int i=0;i<control.Items.Count;i++)
				control.SetItemChecked(i,false);

		}
		#endregion

		#region common
		private void createCheckedListBox(DevExpress.XtraEditors.CheckedListBoxControl control,string strSQL,string _value)
		{
			ClearCheckedList(control);
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			foreach(DataRow dr in _ds.Tables["Table"].Rows)
			{
				//Initialize each item
				control.Items.Add(dr[_value],false);
			}
	
		}

		private void SetCheckedListValue(DevExpress.XtraEditors.CheckedListBoxControl control,string strSQL,string target)
		{
			//Clear Item List
			control.Refresh();
			for (int i=0;i<control.Items.Count;i++)
				control.SetItemChecked(i,false);

			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			
			DataView dv;
			dv = _ds.Tables["table"].DefaultView;

			//set check value					
			try
			{
				for (int i=0; i< dv.Count; i++ ) 
				{
					for (int j=0; j<control.ItemCount; j++)
					{
						if (dv[i].Row[target].ToString()== control.GetItemValue(j).ToString()) 
						{
							control.SetItemChecked(j,true);
							break;
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

		}
	
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

			
		private void gridViewMd_Promotion_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{

			LoadBranch();
			LoadFreebies();
			LoadPackage();
			LoadSales();

		}

		private void frmPromotion_Load(object sender, System.EventArgs e)
		{
		//	CheckedBoxAddItem();
			mdPromotionInit();
			LoadBranch();
			LoadFreebies();
			LoadPackage();
			LoadSales();
		}
		private bool AddNew = false;
		private void btn_Add_Click(object sender, System.EventArgs e)
		{
			AddNew = true;
			DataRow dr = dtPromotion.NewRow();
			dtPromotion.Rows.Add(dr);
			this.gridControlMd_Promotion.Refresh();
			this.gridViewMd_Promotion.FocusedRowHandle = dtPromotion.Rows.Count - 1;
			
		}

		private void btn_Del_Click(object sender, System.EventArgs e)
		{
			DataRow row = this.gridViewMd_Promotion.GetDataRow(gridViewMd_Promotion.FocusedRowHandle);
			if (row != null)
			{
	
				if (AddNew)
				{
					AddNew = false;
					gridViewMd_Promotion.DeleteRow(gridViewMd_Promotion.FocusedRowHandle);
				}
				else
				{

					DialogResult result = MessageBox.Show(this, "Do you really want to delete record with Promotion Code = " + row["strPromotionCode"].ToString(),
						"Delete?", MessageBoxButtons.YesNo);
					if (result == DialogResult.Yes)
					{
						try
						{
							SqlHelper.ExecuteNonQuery(connection,"del_Promotion",
								new SqlParameter("@strClassCode",row["strPromotionCode"].ToString() )
								);
						}
						catch(Exception ex)
						{
							MessageBox.Show(ex.Message ,"Delete Process Failed");
							return;
						}
						MessageBox.Show("Record Deleted Successfully","Message");
					}
					mdPromotionInit();
				}
			}
		}

		private bool FieldChecking(DataRow dr)
		{
			if (dr["strPromotionCode"].ToString() == "")
				return false;
			return true;
		}

		private void gridViewMd_Promotion_LostFocus(object sender, System.EventArgs e)
		{
			DataRow row = this.gridViewMd_Promotion.GetDataRow(gridViewMd_Promotion.FocusedRowHandle);
			
			string strSQL = "Select * from TblPromotion";
			if (AddNew)
			{
				if( FieldChecking(row))
				{
					this.gridControlMd_Promotion.MainView.UpdateCurrentRow();
					try
					{
						CreateCmdsAndUpdate(strSQL,dtPromotion);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message ,"Delete Process Failed");
						return;
					}
					AddNew = false;

////					UpdatePromotionSubItem(row);
					
				}
			}
			else
			{
				gridViewMd_Promotion.CloseEditor();
				gridViewMd_Promotion.UpdateCurrentRow();

				CreateCmdsAndUpdate(strSQL,dtPromotion);
//				UpdatePromotionSubItem(row);
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

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			LoadFreebies();
		}

		private void btnReset_Click(object sender, System.EventArgs e)
		{
			this.txtItemCode.EditValue = "";
			this.txtItemDesc.EditValue = "";
			this.txtItemStyle.EditValue = "";
			LoadFreebies();
			
		}

	

		private void btnPcSearch_Click(object sender, System.EventArgs e)
		{
			LoadPackage();
		}

		private void btnPcReset_Click(object sender, System.EventArgs e)
		{
			this.txtPcItemCode.EditValue = "";
			this.txtPcItemDesc.EditValue = "";
			LoadPackage();
		}

		#region branch
		private DataTable dtBranch;
		private void btnBranch_Add_Click(object sender, System.EventArgs e)
		{
			DataRow dr = this.gridViewMd_Promotion.GetDataRow(this.gridViewMd_Promotion.FocusedRowHandle);

			int[] rowsHandle = this.gvBranch.GetSelectedRows();
			if (rowsHandle == null || rowsHandle.Length == 0)
			{
				UI.ShowErrorMessage(this, "Please select at least one row.");
				return;
			}
			
			foreach(int index in rowsHandle)
			{
				DataRow rCopy = gvBranch.GetDataRow(index);
				DataRow rNew = dtBranch.NewRow();
				rNew.BeginEdit();
				rNew["strPromotionCode"] = dr["strPromotionCode"];
				rNew["strBranchCode"] = rCopy["strBranchCode"];
				rNew["strBranchName"] = rCopy["strBranchName"];
				rNew.EndEdit();
				dtBranch.Rows.Add(rNew);
			}

			gvBranch.DeleteSelectedRows();
						
			try
			{
				string strSQL = "select strPromotionCode, strBranchCode from tblPromotionBranch Where strPromotionCode = '" + dr["strPromotionCode"].ToString() + "'";
				CreateCmdsAndUpdate(strSQL,dtBranch);
			}
			catch (Exception)
			{
				return;
			}
		}

		private void btnBranch_DelAll_Click(object sender, System.EventArgs e)
		{
			DataRow dr = this.gridViewMd_Promotion.GetDataRow(this.gridViewMd_Promotion.FocusedRowHandle);

			gvBranch.BeginDataUpdate();
			gvBranch2.BeginDataUpdate();
			DataTable dtTemp = (gvBranch.DataSource as DataView).Table;

			for (int i = dtBranch.Rows.Count - 1; i >= 0; i--)
			{
				DataRow rCopy = gvBranch2.GetDataRow(i);
				DataRow rNew = dtTemp.NewRow();
				rNew.BeginEdit();
				rNew["strBranchCode"] = rCopy["strBranchCode"];
				rNew["strBranchName"] = rCopy["strBranchName"];
				rNew.EndEdit();
				dtTemp.Rows.Add(rNew);
			}

			for (int i = dtBranch.Rows.Count - 1; i >= 0; i--)
			{
				if (dtBranch.Rows[i].RowState != DataRowState.Deleted)
					dtBranch.Rows[i].Delete();
			}

			gvBranch2.EndDataUpdate();
			gvBranch.EndDataUpdate();

			string strSQL = "select strPromotionCode, strBranchCode from tblPromotionBranch Where strPromotionCode = '" + dr["strPromotionCode"].ToString() + "'";
			CreateCmdsAndUpdate(strSQL,dtBranch);
		}

		private void btnBranch_AddAll_Click(object sender, System.EventArgs e)
		{
			gvBranch.BeginDataUpdate();
			gvBranch2.BeginDataUpdate();

			DataRow dr = this.gridViewMd_Promotion.GetDataRow(this.gridViewMd_Promotion.FocusedRowHandle);
			DataTable dtTemp = (gvBranch.DataSource as DataView).Table;
			//dtTemp.RejectChanges();
			dtTemp.AcceptChanges();

			for (int i = dtTemp.Rows.Count - 1; i >= 0; i--)
			{
				DataRow rCopy = gvBranch.GetDataRow(i);
				DataRow rNew = dtBranch.NewRow();
				rNew.BeginEdit();
				rNew["strPromotionCode"] = dr["strPromotionCode"];
				rNew["strBranchCode"] = rCopy["strBranchCode"];
				rNew["strBranchName"] = rCopy["strBranchName"];
				rNew.EndEdit();
				dtBranch.Rows.Add(rNew);
			}

			for (int i = dtTemp.Rows.Count - 1; i >= 0; i--)
			{
				if (dtTemp.Rows[i].RowState != DataRowState.Deleted)
					dtTemp.Rows[i].Delete();
			}

			gvBranch.EndDataUpdate();
			gvBranch2.EndDataUpdate();

			string strSQL = "select strPromotionCode, strBranchCode from tblPromotionBranch Where strPromotionCode = '" + dr["strPromotionCode"].ToString() + "'";
			CreateCmdsAndUpdate(strSQL,dtBranch);
		}

		private void btnBranch_Del_Click(object sender, System.EventArgs e)
		{
			DataRow dr = this.gridViewMd_Promotion.GetDataRow(this.gridViewMd_Promotion.FocusedRowHandle);

			int[] rowsHandle = gvBranch2.GetSelectedRows();
			if (rowsHandle == null || rowsHandle.Length == 0)
			{
				UI.ShowErrorMessage(this, "Please select at least one row.");
				return;
			}
			DataTable dtTemp = (gvBranch.DataSource as DataView).Table;
			foreach(int index in rowsHandle)
			{
				DataRow rCopy = gvBranch2.GetDataRow(index);
				DataRow rNew = dtTemp.NewRow();
				rNew.BeginEdit();
				rNew["strBranchCode"] = rCopy["strBranchCode"];
				rNew["strBranchName"] = rCopy["strBranchName"];
				rNew.EndEdit();
				dtTemp.Rows.Add(rNew);
			}
			gvBranch2.DeleteSelectedRows();

			try
			{
				string strSQL = "select strPromotionCode, strBranchCode from tblPromotionBranch Where strPromotionCode = '" + dr["strPromotionCode"].ToString() + "'";
				CreateCmdsAndUpdate(strSQL,dtBranch);
			}
			catch (Exception)
			{
				return;
			}
		}

		
		private void LoadBranch()
		{
			DataSet _ds;
			DataRow dr = this.gridViewMd_Promotion.GetDataRow(this.gridViewMd_Promotion.FocusedRowHandle);
			
			if (dr == null)
				return;

			string strSQL;
			strSQL = "select strBranchCode, strBranchName from TblBranch Where strBranchCode Not In (Select strBranchCode From tblPromotionBranch Where strPromotionCode = '" + dr["strPromotionCode"].ToString() + "')";
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			this.gridBranch.DataSource = _ds.Tables["table"];
				
			strSQL = "select P.strPromotionCode, B.strBranchCode, strBranchName from tblPromotionBranch P Inner Join TblBranch B On B.strBranchCode = P.strBranchCode Where P.strPromotionCode = '" + dr["strPromotionCode"].ToString() + "'";
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dtBranch = _ds.Tables["table"];
			gridBranch2.DataSource = dtBranch;
		}
		#endregion

		#region Freebies

		private DataTable dtFreebies;
        private void LoadFreebies()
		{
			string Condition = "";
			DataSet _ds;
			DataRow dr = this.gridViewMd_Promotion.GetDataRow(this.gridViewMd_Promotion.FocusedRowHandle);
			
			if (dr == null)
				return;

			string strSQL = "select * from tblProduct Left Join TblStyle S On S.strStyleCode = tblProduct.strStyleCode Where strProductCode Not In (Select strItemCode From tblPromotionfreebie Where strPromotionCode = '" + dr["strPromotionCode"].ToString() + "')";
			
			if (this.txtItemCode.EditValue.ToString() != "")
				Condition = " tblProduct.strProductCode like '%" + this.txtItemCode.EditValue + "%' And";

			if (this.txtItemDesc.EditValue.ToString() != "")
				Condition += " tblProduct.strDescription like '%" + this.txtItemDesc.EditValue + "%' And";

			if (this.txtItemStyle.EditValue.ToString() != "")
				Condition += " (tblProduct.strStyleCode like '%" + this.txtItemStyle.EditValue + "%' Or S.strDescription like '%" + this.txtItemStyle.EditValue + "%') And";

			if (Condition != "")
				strSQL = strSQL + " And " + Condition.Substring(0,Condition.Length - 4);

			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			gdFreebies.DataSource = _ds.Tables["table"];


			strSQL = "select strPromotionCode, B.strDescription, strItemCode from tblPromotionFreebie A join tblProduct B on A.strItemCode = B.strProductCode where strPromotionCode='" + dr["strPromotionCode"].ToString() + "'";
			if (this.txtItemCode.EditValue.ToString() != "")
				Condition = " B.strProductCode like '%" + this.txtItemCode.EditValue + "%' And";

			if (this.txtItemDesc.EditValue.ToString() != "")
				Condition += " B.strDescription like '%" + this.txtItemDesc.EditValue + "%' And";

			if (this.txtItemStyle.EditValue.ToString() != "")
				Condition += " (B.strStyleCode like '%" + this.txtItemStyle.EditValue + "%') And";

			if (Condition != "")
				strSQL = strSQL + " And " + Condition.Substring(0,Condition.Length - 4);

			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dtFreebies = _ds.Tables["table"];
			gdFreebies2.DataSource = dtFreebies;
		}

		private void btnFreebies_Add_Click(object sender, System.EventArgs e)
		{
			DataRow dr = this.gridViewMd_Promotion.GetDataRow(this.gridViewMd_Promotion.FocusedRowHandle);

			int[] rowsHandle = this.gvFreebies.GetSelectedRows();
			if (rowsHandle == null || rowsHandle.Length == 0)
			{
				UI.ShowErrorMessage(this, "Please select at least one row.");
				return;
			}
			
			foreach(int index in rowsHandle)
			{
				DataRow rCopy = gvFreebies.GetDataRow(index);
				DataRow rNew = dtFreebies.NewRow();
				rNew.BeginEdit();
				rNew["strPromotionCode"] = dr["strPromotionCode"];
				rNew["strItemCode"] = rCopy["strProductCode"];
				rNew["strDescription"] = rCopy["strDescription"];
				rNew.EndEdit();
				dtFreebies.Rows.Add(rNew);
			}

			gvFreebies.DeleteSelectedRows();
						
			try
			{
				string strSQL = "select strPromotionCode, strItemCode from tblPromotionfreebie Where strPromotionCode = '" + dr["strPromotionCode"].ToString() + "'";
				CreateCmdsAndUpdate(strSQL,dtFreebies);
			}
			catch (Exception)
			{
				return;
			}
		}

		private void btnFreebies_AddAll_Click(object sender, System.EventArgs e)
		{
			gvFreebies.BeginDataUpdate();
			gvFreebies2.BeginDataUpdate();

			DataRow dr = this.gridViewMd_Promotion.GetDataRow(this.gridViewMd_Promotion.FocusedRowHandle);
			DataTable dtTemp = (gvFreebies.DataSource as DataView).Table;
			//dtTemp.RejectChanges();
			dtTemp.AcceptChanges();

			for (int i = dtTemp.Rows.Count - 1; i >= 0; i--)
			{
				DataRow rCopy = gvFreebies.GetDataRow(i);
				DataRow rNew = dtFreebies.NewRow();
				rNew.BeginEdit();
				rNew["strPromotionCode"] = dr["strPromotionCode"];
				rNew["strItemCode"] = rCopy["strProductCode"];
				rNew["strDescription"] = rCopy["strDescription"];
				rNew.EndEdit();
				dtFreebies.Rows.Add(rNew);
			}

			for (int i = dtTemp.Rows.Count - 1; i >= 0; i--)
			{
				if (dtTemp.Rows[i].RowState != DataRowState.Deleted)
					dtTemp.Rows[i].Delete();
			}

			gvFreebies.EndDataUpdate();
			gvFreebies2.EndDataUpdate();

			string strSQL = "select strPromotionCode, strItemCode from tblPromotionfreebie Where strPromotionCode = '" + dr["strPromotionCode"].ToString() + "'";
			CreateCmdsAndUpdate(strSQL,dtFreebies);
		}

		private void btnFreebies_DelAll_Click(object sender, System.EventArgs e)
		{
			DataRow dr = this.gridViewMd_Promotion.GetDataRow(this.gridViewMd_Promotion.FocusedRowHandle);

			gvFreebies.BeginDataUpdate();
			gvFreebies2.BeginDataUpdate();
			DataTable dtTemp = (gvFreebies.DataSource as DataView).Table;

			for (int i = dtFreebies.Rows.Count - 1; i >= 0; i--)
			{
				DataRow rCopy = gvFreebies2.GetDataRow(i);
				DataRow rNew = dtTemp.NewRow();
				rNew.BeginEdit();
				rNew["strProductCode"] = rCopy["strItemCode"];
				rNew["strDescription"] = rCopy["strDescription"];
				rNew.EndEdit();
				dtTemp.Rows.Add(rNew);
			}

			for (int i = dtFreebies.Rows.Count - 1; i >= 0; i--)
			{
				if (dtFreebies.Rows[i].RowState != DataRowState.Deleted)
					dtFreebies.Rows[i].Delete();
			}

			gvFreebies2.EndDataUpdate();
			gvFreebies.EndDataUpdate();

			string strSQL = "select strPromotionCode, strItemCode from tblPromotionfreebie Where strPromotionCode = '" + dr["strPromotionCode"].ToString() + "'";
			CreateCmdsAndUpdate(strSQL,dtFreebies);
		}

		private void btnFreebies_Del_Click(object sender, System.EventArgs e)
		{
			DataRow dr = this.gridViewMd_Promotion.GetDataRow(this.gridViewMd_Promotion.FocusedRowHandle);

			int[] rowsHandle = gvFreebies2.GetSelectedRows();
			if (rowsHandle == null || rowsHandle.Length == 0)
			{
				UI.ShowErrorMessage(this, "Please select at least one row.");
				return;
			}
			DataTable dtTemp = (gvFreebies.DataSource as DataView).Table;
			foreach(int index in rowsHandle)
			{
				DataRow rCopy = gvFreebies2.GetDataRow(index);
				DataRow rNew = dtTemp.NewRow();
				rNew.BeginEdit();
				rNew["strProductCode"] = rCopy["strItemCode"];
				rNew["strDescription"] = rCopy["strDescription"];
				rNew.EndEdit();
				dtTemp.Rows.Add(rNew);
			}
			gvFreebies2.DeleteSelectedRows();

			try
			{
				string strSQL = "select * from tblPromotionfreebie Where strPromotionCode = '" + dr["strPromotionCode"].ToString() + "'";
				CreateCmdsAndUpdate(strSQL,dtFreebies);
			}
			catch (Exception)
			{
				return;
			}
		}
		#endregion

		#region Package
		private DataTable dtPackage;
		private void LoadPackage()
		{
			string Condition = "";
			DataSet _ds;
			DataRow dr = this.gridViewMd_Promotion.GetDataRow(this.gridViewMd_Promotion.FocusedRowHandle);
			
			if (dr == null)
				return;

			string strSQL = "select * from tblPackage Where strPackageCode Not In (Select strPackageCode From tblpromotionpackage Where strPromotionCode = '" + dr["strPromotionCode"].ToString() + "')";
			if (this.txtPcItemCode.EditValue.ToString() != "")
				Condition = " strPackageCode like '%" + this.txtPcItemCode.EditValue + "%' And";

			if (this.txtPcItemDesc.EditValue.ToString() != "")
				Condition += " strDescription like '%" + this.txtPcItemDesc.EditValue + "%' And";

			if (Condition != "")
				strSQL = strSQL + " And " + Condition.Substring(0,Condition.Length - 4);
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			gdPackage.DataSource = _ds.Tables["table"];

			strSQL = "select * from tblPromotionPackage A join tblPackage B on A.strPackageCode=B.strPackageCode where strPromotionCode='" + dr["strPromotionCode"].ToString() + "'";
			if (this.txtPcItemCode.EditValue.ToString() != "")
				Condition = " B.strPackageCode like '%" + this.txtPcItemCode.EditValue + "%' And";

			if (this.txtPcItemDesc.EditValue.ToString() != "")
				Condition += " B.strDescription like '%" + this.txtPcItemDesc.EditValue + "%' And";
			if (Condition != "")
				strSQL = strSQL + " And " + Condition.Substring(0,Condition.Length - 4);

			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dtPackage = _ds.Tables["table"];
			gdPackage2.DataSource = dtPackage;
		}

		private void btnPackage_Add_Click(object sender, System.EventArgs e)
		{
			DataRow dr = this.gridViewMd_Promotion.GetDataRow(this.gridViewMd_Promotion.FocusedRowHandle);

			int[] rowsHandle = this.gvPackage.GetSelectedRows();
			if (rowsHandle == null || rowsHandle.Length == 0)
			{
				UI.ShowErrorMessage(this, "Please select at least one row.");
				return;
			}
			
			foreach(int index in rowsHandle)
			{
				DataRow rCopy = gvPackage.GetDataRow(index);
				DataRow rNew = dtPackage.NewRow();
				rNew.BeginEdit();
				rNew["strPromotionCode"] = dr["strPromotionCode"];
				rNew["strPackageCode"] = rCopy["strPackageCode"];
				rNew["strDescription"] = rCopy["strDescription"];
				rNew.EndEdit();
				dtPackage.Rows.Add(rNew);
			}

			gvPackage.DeleteSelectedRows();
						
			try
			{
				string strSQL = "select * from tblpromotionpackage Where strPromotionCode = '" + dr["strPromotionCode"].ToString() + "'";
				CreateCmdsAndUpdate(strSQL,dtPackage);
			}
			catch (Exception)
			{
				return;
			}
		}

		private void btnPackage_AddAll_Click(object sender, System.EventArgs e)
		{
			gvPackage.BeginDataUpdate();
			gvPackage2.BeginDataUpdate();

			DataRow dr = this.gridViewMd_Promotion.GetDataRow(this.gridViewMd_Promotion.FocusedRowHandle);
			DataTable dtTemp = (gvPackage.DataSource as DataView).Table;
			//dtTemp.RejectChanges();
			dtTemp.AcceptChanges();

			for (int i = dtTemp.Rows.Count - 1; i >= 0; i--)
			{
				DataRow rCopy = gvPackage.GetDataRow(i);
				DataRow rNew = dtPackage.NewRow();
				rNew.BeginEdit();
				rNew["strPromotionCode"] = dr["strPromotionCode"];
				rNew["strPackageCode"] = rCopy["strPackageCode"];
				rNew["strDescription"] = rCopy["strDescription"];
				rNew.EndEdit();
				dtPackage.Rows.Add(rNew);
			}

			for (int i = dtTemp.Rows.Count - 1; i >= 0; i--)
			{
				if (dtTemp.Rows[i].RowState != DataRowState.Deleted)
					dtTemp.Rows[i].Delete();
			}

			gvPackage.EndDataUpdate();
			gvPackage2.EndDataUpdate();

			string strSQL = "select * from tblpromotionpackage Where strPromotionCode = '" + dr["strPromotionCode"].ToString() + "'";
			CreateCmdsAndUpdate(strSQL,dtPackage);
		}

		private void btnPackage_DelAll_Click(object sender, System.EventArgs e)
		{
			DataRow dr = this.gridViewMd_Promotion.GetDataRow(this.gridViewMd_Promotion.FocusedRowHandle);

			gvPackage.BeginDataUpdate();
			gvPackage2.BeginDataUpdate();
			DataTable dtTemp = (gvPackage.DataSource as DataView).Table;

			for (int i = dtPackage.Rows.Count - 1; i >= 0; i--)
			{
				DataRow rCopy = gvPackage2.GetDataRow(i);
				DataRow rNew = dtTemp.NewRow();
				rNew.BeginEdit();
				rNew["strPackageCode"] = rCopy["strPackageCode"];
				rNew["strDescription"] = rCopy["strDescription"];
				rNew.EndEdit();
				dtTemp.Rows.Add(rNew);
			}

			for (int i = dtPackage.Rows.Count - 1; i >= 0; i--)
			{
				if (dtPackage.Rows[i].RowState != DataRowState.Deleted)
					dtPackage.Rows[i].Delete();
			}

			gvPackage2.EndDataUpdate();
			gvPackage.EndDataUpdate();

			string strSQL = "select * from tblpromotionpackage Where strPromotionCode = '" + dr["strPromotionCode"].ToString() + "'";
			CreateCmdsAndUpdate(strSQL,dtPackage);
		}

		private void btnPackage_Del_Click(object sender, System.EventArgs e)
		{
			DataRow dr = this.gridViewMd_Promotion.GetDataRow(this.gridViewMd_Promotion.FocusedRowHandle);

			int[] rowsHandle = gvPackage2.GetSelectedRows();
			if (rowsHandle == null || rowsHandle.Length == 0)
			{
				UI.ShowErrorMessage(this, "Please select at least one row.");
				return;
			}
			DataTable dtTemp = (gvPackage.DataSource as DataView).Table;
			foreach(int index in rowsHandle)
			{
				DataRow rCopy = gvPackage2.GetDataRow(index);
				DataRow rNew = dtTemp.NewRow();
				rNew.BeginEdit();
				rNew["strPackageCode"] = rCopy["strPackageCode"];
				rNew["strDescription"] = rCopy["strDescription"];
				rNew.EndEdit();
				dtTemp.Rows.Add(rNew);
			}
			gvPackage2.DeleteSelectedRows();

			try
			{
				string strSQL = "select * from tblpromotionpackage Where strPromotionCode = '" + dr["strPromotionCode"].ToString() + "'";
				CreateCmdsAndUpdate(strSQL,dtPackage);
			}
			catch (Exception)
			{
				return;
			}
		}
		#endregion
		
		#region Sales

		private DataTable dtSales;
		private void LoadSales()
		{
			DataSet _ds;
			DataRow dr = this.gridViewMd_Promotion.GetDataRow(this.gridViewMd_Promotion.FocusedRowHandle);
			
			if (dr == null)
				return;

			string strSQL = "select * from TbLSalesCategory Where nSalesCategoryID Not In (Select nSalesCategoryID From tblPromotionReceiptSalesCategory Where strPromotionCode = '" + dr["strPromotionCode"].ToString() + "')";
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			gridSales.DataSource = _ds.Tables["table"];

			strSQL = "select * from tblPromotionReceiptSalesCategory A join tblSalesCategory B on A.nSalesCategoryID=B.nSalesCategoryID where strPromotionCode='" + dr["strPromotionCode"].ToString() + "'";
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dtSales = _ds.Tables["table"];
			gridSales2.DataSource = dtSales;
		}

		private void btnSales_Add_Click(object sender, System.EventArgs e)
		{
			DataRow dr = this.gridViewMd_Promotion.GetDataRow(this.gridViewMd_Promotion.FocusedRowHandle);

			int[] rowsHandle = this.gvSales.GetSelectedRows();
			if (rowsHandle == null || rowsHandle.Length == 0)
			{
				UI.ShowErrorMessage(this, "Please select at least one row.");
				return;
			}
			
			foreach(int index in rowsHandle)
			{
				DataRow rCopy = this.gvSales.GetDataRow(index);
				DataRow rNew = dtSales.NewRow();
				rNew.BeginEdit();
				rNew["strPromotionCode"] = dr["strPromotionCode"];
				rNew["nSalesCategoryID"] = rCopy["nSalesCategoryID"];
				rNew["strDescription"] = rCopy["strDescription"];
				rNew.EndEdit();
				dtSales.Rows.Add(rNew);
			}

			gvSales.DeleteSelectedRows();
						
			try
			{
				string strSQL = "select * from tblPromotionReceiptSalesCategory Where strPromotionCode = '" + dr["strPromotionCode"].ToString() + "'";
				CreateCmdsAndUpdate(strSQL,dtSales);
			}
			catch  (Exception)
			{
				return;
			}
		}

		private void btnSales_AddAll_Click(object sender, System.EventArgs e)
		{
			gvSales.BeginDataUpdate();
			gvSales2.BeginDataUpdate();

			DataRow dr = this.gridViewMd_Promotion.GetDataRow(this.gridViewMd_Promotion.FocusedRowHandle);
			DataTable dtTemp = (gvSales.DataSource as DataView).Table;
			//dtTemp.RejectChanges();
			dtTemp.AcceptChanges();

			for (int i = dtTemp.Rows.Count - 1; i >= 0; i--)
			{
				DataRow rCopy = gvSales.GetDataRow(i);
				DataRow rNew = dtSales.NewRow();
				rNew.BeginEdit();
				rNew["strPromotionCode"] = dr["strPromotionCode"];
				rNew["nSalesCategoryID"] = rCopy["nSalesCategoryID"];
				rNew["strDescription"] = rCopy["strDescription"];
				rNew.EndEdit();
				dtSales.Rows.Add(rNew);
			}

			for (int i = dtTemp.Rows.Count - 1; i >= 0; i--)
			{
				if (dtTemp.Rows[i].RowState != DataRowState.Deleted)
					dtTemp.Rows[i].Delete();
			}

			gvSales.EndDataUpdate();
			gvSales2.EndDataUpdate();

			string strSQL = "select * from tblPromotionReceiptSalesCategory Where strPromotionCode = '" + dr["strPromotionCode"].ToString() + "'";
			CreateCmdsAndUpdate(strSQL,dtSales);
		}

		private void btnSales_Del_Click(object sender, System.EventArgs e)
		{
			DataRow dr = this.gridViewMd_Promotion.GetDataRow(this.gridViewMd_Promotion.FocusedRowHandle);

			int[] rowsHandle = gvSales2.GetSelectedRows();
			if (rowsHandle == null || rowsHandle.Length == 0)
			{
				UI.ShowErrorMessage(this, "Please select at least one row.");
				return;
			}
			DataTable dtTemp = (gvSales.DataSource as DataView).Table;
			foreach(int index in rowsHandle)
			{
				DataRow rCopy = gvSales2.GetDataRow(index);
				DataRow rNew = dtTemp.NewRow();
				rNew.BeginEdit();
				rNew["nSalesCategoryID"] = rCopy["nSalesCategoryID"];
				rNew["strDescription"] = rCopy["strDescription"];
				rNew.EndEdit();
				dtTemp.Rows.Add(rNew);
			}
			gvSales2.DeleteSelectedRows();

			try
			{
				string strSQL = "select * from tblPromotionReceiptSalesCategory Where strPromotionCode = '" + dr["strPromotionCode"].ToString() + "'";
				CreateCmdsAndUpdate(strSQL,dtSales);
			}
			catch (Exception)
			{
				return;
			}
		}

		private void btnSales_DelAll_Click(object sender, System.EventArgs e)
		{
			DataRow dr = this.gridViewMd_Promotion.GetDataRow(this.gridViewMd_Promotion.FocusedRowHandle);

			gvSales.BeginDataUpdate();
			gvSales2.BeginDataUpdate();
			DataTable dtTemp = (gvSales.DataSource as DataView).Table;

			for (int i = dtSales.Rows.Count - 1; i >= 0; i--)
			{
				DataRow rCopy = gvSales2.GetDataRow(i);
				DataRow rNew = dtTemp.NewRow();
				rNew.BeginEdit();
				rNew["nSalesCategoryID"] = rCopy["nSalesCategoryID"];
				rNew["strDescription"] = rCopy["strDescription"];
				rNew.EndEdit();
				dtTemp.Rows.Add(rNew);
			}

			for (int i = dtSales.Rows.Count - 1; i >= 0; i--)
			{
				if (dtSales.Rows[i].RowState != DataRowState.Deleted)
					dtSales.Rows[i].Delete();
			}

			gvSales2.EndDataUpdate();
			gvSales.EndDataUpdate();

			string strSQL = "select * from tblPromotionReceiptSalesCategory Where strPromotionCode = '" + dr["strPromotionCode"].ToString() + "'";
			CreateCmdsAndUpdate(strSQL,dtSales);
		}

		#endregion

		private void btn_Search_Click(object sender, System.EventArgs e)
		{
			mdPromotionInit();
		}
		private void txtSearch_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btn_Search_Click(sender,e);
			}
		}


		
	
	}
}
