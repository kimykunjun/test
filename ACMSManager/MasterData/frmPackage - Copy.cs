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

namespace ACMS.ACMSManager.MasterData
{
	/// <summary>
	/// Summary description for frmPackage.
	/// </summary>
	public class frmPackage : System.Windows.Forms.Form
	{
		#region windows control

		private string connectionString;
		private SqlConnection connection;
		private DevExpress.XtraEditors.GroupControl grpMDPackageTop;
		private System.Windows.Forms.Label label31;
		private DevExpress.XtraEditors.ImageComboBoxEdit ddlPackageCategory;
		private DevExpress.XtraEditors.GroupControl grpPackage;
		private DevExpress.XtraEditors.GroupControl grpPackageGroup;
		private DevExpress.XtraEditors.GroupControl groupControl1;
		private DevExpress.XtraGrid.GridControl gridControlMd_Package;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewMd_Package;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnPKG1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnPKG2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnPKG3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnPKG4;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnPKG5;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnPKG6;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnPKG7;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnPKG8;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnPKG9;
		internal DevExpress.XtraEditors.SimpleButton btn_PackageAdd;
		internal DevExpress.XtraEditors.SimpleButton btn_PackageDel;
		private System.Windows.Forms.ImageList imageList1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox chk_Peak_1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox chk_StuPackage;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_Category;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chk_GIRO;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chk_Peak;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chk_StudentPackage;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chk_RestUpgrade;
		private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit StartDate;
		private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit EndDate;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Label label119;
		private System.Windows.Forms.Label label120;
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
		private DevExpress.XtraGrid.Columns.GridColumn colBranchCode2;
		private DevExpress.XtraGrid.Columns.GridColumn colBranchName2;
		private System.Windows.Forms.Label label3;
		private DevExpress.XtraGrid.Columns.GridColumn colBranchCode;
		private DevExpress.XtraGrid.Columns.GridColumn colBranchName;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
		private DevExpress.XtraEditors.GroupControl grpPackageService;
		private DevExpress.XtraEditors.SimpleButton btn_PB_Del;
		private DevExpress.XtraEditors.SimpleButton btn_PBAll_Del;
		private DevExpress.XtraEditors.SimpleButton btn_PBAll_Add;
		private DevExpress.XtraEditors.SimpleButton btn_PB_Add;
		private DevExpress.XtraGrid.GridControl gridPackageBranch2;
		private DevExpress.XtraGrid.GridControl gridPackageBranch;
		private DevExpress.XtraEditors.SimpleButton btn_PSAll_Del;
		private DevExpress.XtraEditors.SimpleButton btn_PS_Del;
		private DevExpress.XtraEditors.SimpleButton btn_PSAdd_Add;
		private DevExpress.XtraEditors.SimpleButton btn_PS_Add;
		private DevExpress.XtraGrid.GridControl gridPackageService2;
		private DevExpress.XtraGrid.GridControl gridPackageService;
		private DevExpress.XtraEditors.GroupControl grpPackageClass;
		private DevExpress.XtraEditors.SimpleButton btn_PGC_Del;
		private DevExpress.XtraEditors.SimpleButton btn_PGCAll_Del;
		private DevExpress.XtraEditors.SimpleButton btn_PGCAll_Add;
		private DevExpress.XtraEditors.SimpleButton btn_PGC_Add;
		private DevExpress.XtraGrid.GridControl gridPackageClass2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
		private System.Windows.Forms.Label label2;
		private DevExpress.XtraGrid.GridControl gridPackageClass;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
		private DevExpress.XtraEditors.SimpleButton btn_PGB_Del;
		private DevExpress.XtraEditors.SimpleButton btn_PGBAll_Del;
		private DevExpress.XtraEditors.SimpleButton btn_PGBAll_Add;
		private DevExpress.XtraEditors.SimpleButton btn_PGB_Add;
		private DevExpress.XtraGrid.GridControl gridPcGroupBranch2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
		private System.Windows.Forms.Label label4;
		private DevExpress.XtraGrid.GridControl gridPcGroupBranch;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
		private DevExpress.XtraGrid.Views.Grid.GridView gvPackageClass2;
		private DevExpress.XtraGrid.Views.Grid.GridView gvPackageClass;
		private DevExpress.XtraGrid.Views.Grid.GridView gvPcGroupBranch2;
		private DevExpress.XtraGrid.Views.Grid.GridView gvPcGroupBranch;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
		private DataTable dtPackageGroupEntries;
		private DataTable dtPackageCredit;
		private DataTable dtPackage;
		private DataTable dtPackageGroup;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
		private DevExpress.XtraGrid.Views.Grid.GridView gvPackageService2;
		private DevExpress.XtraGrid.Views.Grid.GridView gvPackageService;
		private DevExpress.XtraGrid.Views.Grid.GridView gvPSBranch2;
		private DevExpress.XtraGrid.Views.Grid.GridView gvPSBranch;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
		private DevExpress.XtraEditors.GroupControl PackageGroup;
		internal DevExpress.XtraEditors.SimpleButton btn_PacGroup_Add;
		internal DevExpress.XtraEditors.SimpleButton btn_PacGroup_Del;
		private DevExpress.XtraEditors.GroupControl groupControl2;
		private DevExpress.XtraGrid.GridControl gridControlMd_GroupEntries;
		private System.Windows.Forms.Splitter splitter2;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewMd_GroupEntries;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn44;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn45;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn46;
		private DevExpress.XtraEditors.GroupControl GroupCreditPackage;
		internal DevExpress.XtraEditors.SimpleButton btn_CreGroup_Add;
		internal DevExpress.XtraEditors.SimpleButton btn_CreGroup_Del;
		private DevExpress.XtraEditors.GroupControl groupControl3;
		private DevExpress.XtraGrid.GridControl GridCreditRestric;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewmd_CreditRestric;
		private DataTable dtClass;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn26;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_PackageCode;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn27;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chk_AllowDiscount;
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
		private DevExpress.XtraEditors.SimpleButton btnPacBranch_Del;
		private DevExpress.XtraEditors.SimpleButton btnPacBranch_DelAll;
		private DevExpress.XtraEditors.SimpleButton btnPacBranch_AddAll;
		private DevExpress.XtraEditors.SimpleButton btnPacBranch_Add;
		private DevExpress.XtraGrid.GridControl gridPacBranch2;
		private System.Windows.Forms.Label label6;
		private DevExpress.XtraGrid.GridControl gridPacBranch;
		private DevExpress.XtraGrid.Views.Grid.GridView gvPacBranch2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn33;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn34;
		private DevExpress.XtraGrid.Views.Grid.GridView gvPacBranch;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn35;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn36;
		private DevExpress.XtraEditors.GroupControl grpBranch;
		internal DevExpress.XtraEditors.SimpleButton btnPacGroup_Add;
		internal DevExpress.XtraEditors.SimpleButton btnPacGroup_Del;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_GrpPackageCode;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn28;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chk_Sell;
		private System.Windows.Forms.Panel Searchpanel;
		internal DevExpress.XtraEditors.TextEdit txtSearch;
		internal DevExpress.XtraEditors.SimpleButton btn_Search;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn29;
		private DataTable dtPackageCreditRestric;
	#endregion
		public frmPackage()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmPackage));
			DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
			DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
			this.grpMDPackageTop = new DevExpress.XtraEditors.GroupControl();
			this.grpCreditPackage = new DevExpress.XtraEditors.GroupControl();
			this.btnCreditPackage_Add = new DevExpress.XtraEditors.SimpleButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
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
			this.label31 = new System.Windows.Forms.Label();
			this.ddlPackageCategory = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.Searchpanel = new System.Windows.Forms.Panel();
			this.btn_Search = new DevExpress.XtraEditors.SimpleButton();
			this.txtSearch = new DevExpress.XtraEditors.TextEdit();
			this.grpPackage = new DevExpress.XtraEditors.GroupControl();
			this.btn_PackageAdd = new DevExpress.XtraEditors.SimpleButton();
			this.btn_PackageDel = new DevExpress.XtraEditors.SimpleButton();
			this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
			this.gridControlMd_Package = new DevExpress.XtraGrid.GridControl();
			this.gridViewMd_Package = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumnPKG1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumnPKG2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumnPKG3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumnPKG4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumnPKG5 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumnPKG6 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumnPKG7 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.StartDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
			this.gridColumnPKG8 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.EndDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
			this.gridColumnPKG9 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.chk_Peak = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.chk_StudentPackage = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.lk_Category = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.chk_GIRO = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.chk_Sell = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.chk_Peak_1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.chk_StuPackage = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.chk_RestUpgrade = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
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
			this.grpPackageClass = new DevExpress.XtraEditors.GroupControl();
			this.btn_PGC_Del = new DevExpress.XtraEditors.SimpleButton();
			this.btn_PGCAll_Del = new DevExpress.XtraEditors.SimpleButton();
			this.btn_PGCAll_Add = new DevExpress.XtraEditors.SimpleButton();
			this.btn_PGC_Add = new DevExpress.XtraEditors.SimpleButton();
			this.gridPackageClass2 = new DevExpress.XtraGrid.GridControl();
			this.gvPackageClass2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.label2 = new System.Windows.Forms.Label();
			this.gridPackageClass = new DevExpress.XtraGrid.GridControl();
			this.gvPackageClass = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.btn_PGB_Del = new DevExpress.XtraEditors.SimpleButton();
			this.btn_PGBAll_Del = new DevExpress.XtraEditors.SimpleButton();
			this.btn_PGBAll_Add = new DevExpress.XtraEditors.SimpleButton();
			this.btn_PGB_Add = new DevExpress.XtraEditors.SimpleButton();
			this.gridPcGroupBranch2 = new DevExpress.XtraGrid.GridControl();
			this.gvPcGroupBranch2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.label4 = new System.Windows.Forms.Label();
			this.gridPcGroupBranch = new DevExpress.XtraGrid.GridControl();
			this.gvPcGroupBranch = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.label119 = new System.Windows.Forms.Label();
			this.label120 = new System.Windows.Forms.Label();
			this.grpPackageService = new DevExpress.XtraEditors.GroupControl();
			this.btn_PSAll_Del = new DevExpress.XtraEditors.SimpleButton();
			this.btn_PS_Del = new DevExpress.XtraEditors.SimpleButton();
			this.btn_PSAdd_Add = new DevExpress.XtraEditors.SimpleButton();
			this.btn_PS_Add = new DevExpress.XtraEditors.SimpleButton();
			this.gridPackageService2 = new DevExpress.XtraGrid.GridControl();
			this.gvPackageService2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.label1 = new System.Windows.Forms.Label();
			this.gridPackageService = new DevExpress.XtraGrid.GridControl();
			this.gvPackageService = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.btn_PB_Del = new DevExpress.XtraEditors.SimpleButton();
			this.btn_PBAll_Del = new DevExpress.XtraEditors.SimpleButton();
			this.btn_PBAll_Add = new DevExpress.XtraEditors.SimpleButton();
			this.btn_PB_Add = new DevExpress.XtraEditors.SimpleButton();
			this.gridPackageBranch2 = new DevExpress.XtraGrid.GridControl();
			this.gvPSBranch2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colBranchCode2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colBranchName2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.label3 = new System.Windows.Forms.Label();
			this.gridPackageBranch = new DevExpress.XtraGrid.GridControl();
			this.gvPSBranch = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colBranchCode = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colBranchName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.PackageGroup = new DevExpress.XtraEditors.GroupControl();
			this.btn_PacGroup_Add = new DevExpress.XtraEditors.SimpleButton();
			this.btn_PacGroup_Del = new DevExpress.XtraEditors.SimpleButton();
			this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
			this.gridControlMd_GroupEntries = new DevExpress.XtraGrid.GridControl();
			this.gridViewMd_GroupEntries = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn44 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn45 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.lk_GrpPackageCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			this.gridColumn46 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.splitter2 = new System.Windows.Forms.Splitter();
			this.GroupCreditPackage = new DevExpress.XtraEditors.GroupControl();
			this.btn_CreGroup_Add = new DevExpress.XtraEditors.SimpleButton();
			this.btn_CreGroup_Del = new DevExpress.XtraEditors.SimpleButton();
			this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
			this.GridCreditRestric = new DevExpress.XtraGrid.GridControl();
			this.gridViewmd_CreditRestric = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.lk_PackageCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.chk_AllowDiscount = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.grpBranch = new DevExpress.XtraEditors.GroupControl();
			this.btnPacBranch_Del = new DevExpress.XtraEditors.SimpleButton();
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
			((System.ComponentModel.ISupportInitialize)(this.grpMDPackageTop)).BeginInit();
			this.grpMDPackageTop.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grpCreditPackage)).BeginInit();
			this.grpCreditPackage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
			this.groupControl5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControlMd_CreditPackage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewMd_CreditPackage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.EffCCStartDate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.EffCCEndDate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_CreditCategoryID)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ddlPackageCategory.Properties)).BeginInit();
			this.Searchpanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grpPackage)).BeginInit();
			this.grpPackage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
			this.groupControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControlMd_Package)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewMd_Package)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.StartDate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.EndDate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chk_Peak)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chk_StudentPackage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_Category)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chk_GIRO)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chk_Sell)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chk_Peak_1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chk_StuPackage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chk_RestUpgrade)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grpPackageGroup)).BeginInit();
			this.grpPackageGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
			this.groupControl4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControlMd_PackageGroup)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewMd_PackageGroup)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_pkGroupCatID)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grpPackageClass)).BeginInit();
			this.grpPackageClass.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridPackageClass2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvPackageClass2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridPackageClass)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvPackageClass)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridPcGroupBranch2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvPcGroupBranch2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridPcGroupBranch)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvPcGroupBranch)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grpPackageService)).BeginInit();
			this.grpPackageService.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridPackageService2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvPackageService2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridPackageService)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvPackageService)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridPackageBranch2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvPSBranch2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridPackageBranch)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvPSBranch)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PackageGroup)).BeginInit();
			this.PackageGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
			this.groupControl2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControlMd_GroupEntries)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewMd_GroupEntries)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_GrpPackageCode)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GroupCreditPackage)).BeginInit();
			this.GroupCreditPackage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
			this.groupControl3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.GridCreditRestric)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewmd_CreditRestric)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_PackageCode)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chk_AllowDiscount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grpBranch)).BeginInit();
			this.grpBranch.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridPacBranch2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvPacBranch2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridPacBranch)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvPacBranch)).BeginInit();
			this.SuspendLayout();
			// 
			// grpMDPackageTop
			// 
			this.grpMDPackageTop.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.grpMDPackageTop.Appearance.Options.UseBackColor = true;
			this.grpMDPackageTop.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.grpMDPackageTop.AppearanceCaption.Options.UseFont = true;
			this.grpMDPackageTop.Controls.Add(this.grpCreditPackage);
			this.grpMDPackageTop.Controls.Add(this.label31);
			this.grpMDPackageTop.Controls.Add(this.ddlPackageCategory);
			this.grpMDPackageTop.Controls.Add(this.Searchpanel);
			this.grpMDPackageTop.Controls.Add(this.grpPackage);
			this.grpMDPackageTop.Controls.Add(this.grpPackageGroup);
			this.grpMDPackageTop.ImeMode = System.Windows.Forms.ImeMode.On;
			this.grpMDPackageTop.Location = new System.Drawing.Point(8, 0);
			this.grpMDPackageTop.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.grpMDPackageTop.LookAndFeel.UseDefaultLookAndFeel = false;
			this.grpMDPackageTop.Name = "grpMDPackageTop";
			this.grpMDPackageTop.Size = new System.Drawing.Size(968, 280);
			this.grpMDPackageTop.TabIndex = 93;
			this.grpMDPackageTop.Text = "MASTER FILE";
			// 
			// grpCreditPackage
			// 
			this.grpCreditPackage.Controls.Add(this.btnCreditPackage_Add);
			this.grpCreditPackage.Controls.Add(this.btnCreditPackage_Del);
			this.grpCreditPackage.Controls.Add(this.groupControl5);
			this.grpCreditPackage.Location = new System.Drawing.Point(0, 48);
			this.grpCreditPackage.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.grpCreditPackage.LookAndFeel.UseDefaultLookAndFeel = false;
			this.grpCreditPackage.LookAndFeel.UseWindowsXPTheme = false;
			this.grpCreditPackage.Name = "grpCreditPackage";
			this.grpCreditPackage.Size = new System.Drawing.Size(960, 232);
			this.grpCreditPackage.TabIndex = 121;
			this.grpCreditPackage.Text = "Credit Package";
			// 
			// btnCreditPackage_Add
			// 
			this.btnCreditPackage_Add.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
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
			this.btnCreditPackage_Add.Click += new System.EventHandler(this.btnCreditPackage_Add_Click);
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
			// 
			// btnCreditPackage_Del
			// 
			this.btnCreditPackage_Del.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
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
			this.btnCreditPackage_Del.Click += new System.EventHandler(this.btnCreditPackage_Del_Click);
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
			// 
			// gridControlMd_CreditPackage.EmbeddedNavigator
			// 
			this.gridControlMd_CreditPackage.EmbeddedNavigator.Name = "";
			this.gridControlMd_CreditPackage.Location = new System.Drawing.Point(0, 0);
			this.gridControlMd_CreditPackage.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
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
			this.gridViewMd_CreditPackage.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewMd_CreditPackage_FocusedRowChanged);
			this.gridViewMd_CreditPackage.LostFocus += new System.EventHandler(this.gridViewMd_CreditPackage_LostFocus);
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
			// label31
			// 
			this.label31.BackColor = System.Drawing.Color.Transparent;
			this.label31.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label31.Location = new System.Drawing.Point(8, 24);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(136, 16);
			this.label31.TabIndex = 116;
			this.label31.Text = "Package Category";
			this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ddlPackageCategory
			// 
			this.ddlPackageCategory.EditValue = "mdPKG_cbNCategoryID";
			this.ddlPackageCategory.Location = new System.Drawing.Point(144, 24);
			this.ddlPackageCategory.Name = "ddlPackageCategory";
			// 
			// ddlPackageCategory.Properties
			// 
			this.ddlPackageCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.ddlPackageCategory.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.ddlPackageCategory.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.ddlPackageCategory.Size = new System.Drawing.Size(176, 20);
			this.ddlPackageCategory.TabIndex = 19;
			this.ddlPackageCategory.SelectedIndexChanged += new System.EventHandler(this.ddlPackageCategory_SelectedIndexChanged);
			// 
			// Searchpanel
			// 
			this.Searchpanel.Controls.Add(this.btn_Search);
			this.Searchpanel.Controls.Add(this.txtSearch);
			this.Searchpanel.Location = new System.Drawing.Point(488, 24);
			this.Searchpanel.Name = "Searchpanel";
			this.Searchpanel.Size = new System.Drawing.Size(464, 24);
			this.Searchpanel.TabIndex = 151;
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
			this.txtSearch.ImeMode = System.Windows.Forms.ImeMode.On;
			this.txtSearch.Location = new System.Drawing.Point(232, 0);
			this.txtSearch.Name = "txtSearch";
			// 
			// txtSearch.Properties
			// 
			this.txtSearch.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtSearch.Properties.Appearance.Options.UseFont = true;
			this.txtSearch.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.txtSearch.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.txtSearch.Size = new System.Drawing.Size(152, 20);
			this.txtSearch.TabIndex = 136;
			this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
			// 
			// grpPackage
			// 
			this.grpPackage.Controls.Add(this.btn_PackageAdd);
			this.grpPackage.Controls.Add(this.btn_PackageDel);
			this.grpPackage.Controls.Add(this.groupControl1);
			this.grpPackage.Location = new System.Drawing.Point(0, 48);
			this.grpPackage.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.grpPackage.LookAndFeel.UseDefaultLookAndFeel = false;
			this.grpPackage.LookAndFeel.UseWindowsXPTheme = false;
			this.grpPackage.Name = "grpPackage";
			this.grpPackage.Size = new System.Drawing.Size(960, 232);
			this.grpPackage.TabIndex = 118;
			this.grpPackage.Text = "Package";
			// 
			// btn_PackageAdd
			// 
			this.btn_PackageAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btn_PackageAdd.Appearance.Options.UseFont = true;
			this.btn_PackageAdd.Appearance.Options.UseTextOptions = true;
			this.btn_PackageAdd.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.btn_PackageAdd.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
			this.btn_PackageAdd.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.btn_PackageAdd.ImageIndex = 0;
			this.btn_PackageAdd.ImageList = this.imageList1;
			this.btn_PackageAdd.ImeMode = System.Windows.Forms.ImeMode.On;
			this.btn_PackageAdd.Location = new System.Drawing.Point(8, 24);
			this.btn_PackageAdd.Name = "btn_PackageAdd";
			this.btn_PackageAdd.Size = new System.Drawing.Size(38, 16);
			this.btn_PackageAdd.TabIndex = 132;
			this.btn_PackageAdd.Click += new System.EventHandler(this.btn_PackageAdd_Click);
			// 
			// btn_PackageDel
			// 
			this.btn_PackageDel.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
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
			this.groupControl1.Controls.Add(this.gridControlMd_Package);
			this.groupControl1.Location = new System.Drawing.Point(0, 40);
			this.groupControl1.Name = "groupControl1";
			this.groupControl1.Size = new System.Drawing.Size(952, 192);
			this.groupControl1.TabIndex = 121;
			// 
			// gridControlMd_Package
			// 
			this.gridControlMd_Package.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// gridControlMd_Package.EmbeddedNavigator
			// 
			this.gridControlMd_Package.EmbeddedNavigator.Name = "";
			gridLevelNode1.RelationName = "Level1";
			this.gridControlMd_Package.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
																											gridLevelNode1});
			this.gridControlMd_Package.Location = new System.Drawing.Point(0, 0);
			this.gridControlMd_Package.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.gridControlMd_Package.LookAndFeel.UseDefaultLookAndFeel = false;
			this.gridControlMd_Package.MainView = this.gridViewMd_Package;
			this.gridControlMd_Package.Name = "gridControlMd_Package";
			this.gridControlMd_Package.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																														   this.chk_Peak_1,
																														   this.chk_StuPackage,
																														   this.lk_Category,
																														   this.chk_GIRO,
																														   this.repositoryItemCheckEdit1,
																														   this.chk_Peak,
																														   this.chk_StudentPackage,
																														   this.chk_RestUpgrade,
																														   this.StartDate,
																														   this.EndDate,
																														   this.chk_Sell});
			this.gridControlMd_Package.Size = new System.Drawing.Size(952, 192);
			this.gridControlMd_Package.TabIndex = 2;
			this.gridControlMd_Package.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																												 this.gridViewMd_Package});
			// 
			// gridViewMd_Package
			// 
			this.gridViewMd_Package.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																									  this.gridColumnPKG1,
																									  this.gridColumnPKG2,
																									  this.gridColumnPKG3,
																									  this.gridColumnPKG4,
																									  this.gridColumnPKG5,
																									  this.gridColumnPKG6,
																									  this.gridColumnPKG7,
																									  this.gridColumnPKG8,
																									  this.gridColumnPKG9,
																									  this.gridColumn1,
																									  this.gridColumn2,
																									  this.gridColumn3,
																									  this.gridColumn4,
																									  this.gridColumn5,
																									  this.gridColumn6,
																									  this.gridColumn7,
																									  this.gridColumn8,
																									  this.gridColumn28});
			this.gridViewMd_Package.GridControl = this.gridControlMd_Package;
			this.gridViewMd_Package.Name = "gridViewMd_Package";
			this.gridViewMd_Package.OptionsCustomization.AllowFilter = false;
			this.gridViewMd_Package.OptionsCustomization.AllowSort = false;
			this.gridViewMd_Package.OptionsView.ColumnAutoWidth = false;
			this.gridViewMd_Package.OptionsView.ShowGroupPanel = false;
			this.gridViewMd_Package.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewMd_Package_FocusedRowChanged);
			this.gridViewMd_Package.LostFocus += new System.EventHandler(this.gridViewMd_Package_LostFocus);
			// 
			// gridColumnPKG1
			// 
			this.gridColumnPKG1.Caption = "Package Code";
			this.gridColumnPKG1.FieldName = "strPackageCode";
			this.gridColumnPKG1.Name = "gridColumnPKG1";
			this.gridColumnPKG1.Visible = true;
			this.gridColumnPKG1.VisibleIndex = 0;
			this.gridColumnPKG1.Width = 84;
			// 
			// gridColumnPKG2
			// 
			this.gridColumnPKG2.Caption = "Description";
			this.gridColumnPKG2.FieldName = "strDescription";
			this.gridColumnPKG2.Name = "gridColumnPKG2";
			this.gridColumnPKG2.Visible = true;
			this.gridColumnPKG2.VisibleIndex = 1;
			this.gridColumnPKG2.Width = 147;
			// 
			// gridColumnPKG3
			// 
			this.gridColumnPKG3.Caption = "Price";
			this.gridColumnPKG3.DisplayFormat.FormatString = "d2";
			this.gridColumnPKG3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumnPKG3.FieldName = "mListPrice";
			this.gridColumnPKG3.Name = "gridColumnPKG3";
			this.gridColumnPKG3.Visible = true;
			this.gridColumnPKG3.VisibleIndex = 3;
			this.gridColumnPKG3.Width = 61;
			// 
			// gridColumnPKG4
			// 
			this.gridColumnPKG4.Caption = "Max Session";
			this.gridColumnPKG4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumnPKG4.FieldName = "nMaxSession";
			this.gridColumnPKG4.Name = "gridColumnPKG4";
			this.gridColumnPKG4.Visible = true;
			this.gridColumnPKG4.VisibleIndex = 4;
			this.gridColumnPKG4.Width = 71;
			// 
			// gridColumnPKG5
			// 
			this.gridColumnPKG5.Caption = "Duration";
			this.gridColumnPKG5.FieldName = "nPackageDuration";
			this.gridColumnPKG5.Name = "gridColumnPKG5";
			this.gridColumnPKG5.Visible = true;
			this.gridColumnPKG5.VisibleIndex = 5;
			this.gridColumnPKG5.Width = 53;
			// 
			// gridColumnPKG6
			// 
			this.gridColumnPKG6.Caption = "Price per session ";
			this.gridColumnPKG6.DisplayFormat.FormatString = "d2";
			this.gridColumnPKG6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumnPKG6.FieldName = "mBaseUnitPrice";
			this.gridColumnPKG6.Name = "gridColumnPKG6";
			this.gridColumnPKG6.Visible = true;
			this.gridColumnPKG6.VisibleIndex = 6;
			this.gridColumnPKG6.Width = 95;
			// 
			// gridColumnPKG7
			// 
			this.gridColumnPKG7.Caption = "Eff. Start Date";
			this.gridColumnPKG7.ColumnEdit = this.StartDate;
			this.gridColumnPKG7.FieldName = "dtValidStart";
			this.gridColumnPKG7.Name = "gridColumnPKG7";
			this.gridColumnPKG7.Visible = true;
			this.gridColumnPKG7.VisibleIndex = 7;
			this.gridColumnPKG7.Width = 89;
			// 
			// StartDate
			// 
			this.StartDate.AutoHeight = false;
			this.StartDate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																								   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.StartDate.Name = "StartDate";
			// 
			// gridColumnPKG8
			// 
			this.gridColumnPKG8.Caption = "Eff. End Date";
			this.gridColumnPKG8.ColumnEdit = this.EndDate;
			this.gridColumnPKG8.FieldName = "dtValidEnd";
			this.gridColumnPKG8.Name = "gridColumnPKG8";
			this.gridColumnPKG8.Visible = true;
			this.gridColumnPKG8.VisibleIndex = 8;
			// 
			// EndDate
			// 
			this.EndDate.AutoHeight = false;
			this.EndDate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																								 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.EndDate.Name = "EndDate";
			// 
			// gridColumnPKG9
			// 
			this.gridColumnPKG9.Caption = "Status";
			this.gridColumnPKG9.FieldName = "nStatus";
			this.gridColumnPKG9.Name = "gridColumnPKG9";
			this.gridColumnPKG9.Visible = true;
			this.gridColumnPKG9.VisibleIndex = 17;
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "Receipt Desc";
			this.gridColumn1.FieldName = "strReceiptDesc";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 2;
			this.gridColumn1.Width = 119;
			// 
			// gridColumn2
			// 
			this.gridColumn2.Caption = "Peak";
			this.gridColumn2.ColumnEdit = this.chk_Peak;
			this.gridColumn2.FieldName = "fPeak";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 9;
			this.gridColumn2.Width = 39;
			// 
			// chk_Peak
			// 
			this.chk_Peak.AutoHeight = false;
			this.chk_Peak.Name = "chk_Peak";
			// 
			// gridColumn3
			// 
			this.gridColumn3.Caption = "Student Package";
			this.gridColumn3.ColumnEdit = this.chk_StudentPackage;
			this.gridColumn3.FieldName = "fStudentPackage";
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 10;
			this.gridColumn3.Width = 97;
			// 
			// chk_StudentPackage
			// 
			this.chk_StudentPackage.AutoHeight = false;
			this.chk_StudentPackage.Name = "chk_StudentPackage";
			// 
			// gridColumn4
			// 
			this.gridColumn4.Caption = "Category";
			this.gridColumn4.ColumnEdit = this.lk_Category;
			this.gridColumn4.FieldName = "nCategoryID";
			this.gridColumn4.Name = "gridColumn4";
			this.gridColumn4.OptionsColumn.AllowEdit = false;
			this.gridColumn4.Visible = true;
			this.gridColumn4.VisibleIndex = 11;
			// 
			// lk_Category
			// 
			this.lk_Category.AutoHeight = false;
			this.lk_Category.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																									 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lk_Category.Name = "lk_Category";
			// 
			// gridColumn5
			// 
			this.gridColumn5.Caption = "Valid Months";
			this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumn5.FieldName = "nValidMonths";
			this.gridColumn5.Name = "gridColumn5";
			this.gridColumn5.Visible = true;
			this.gridColumn5.VisibleIndex = 12;
			// 
			// gridColumn6
			// 
			this.gridColumn6.Caption = "Warranty Months";
			this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumn6.FieldName = "nWarrantyMonths";
			this.gridColumn6.Name = "gridColumn6";
			this.gridColumn6.Visible = true;
			this.gridColumn6.VisibleIndex = 13;
			this.gridColumn6.Width = 97;
			// 
			// gridColumn7
			// 
			this.gridColumn7.Caption = "GIRO";
			this.gridColumn7.ColumnEdit = this.chk_GIRO;
			this.gridColumn7.FieldName = "fGIRO";
			this.gridColumn7.Name = "gridColumn7";
			this.gridColumn7.Visible = true;
			this.gridColumn7.VisibleIndex = 14;
			this.gridColumn7.Width = 49;
			// 
			// chk_GIRO
			// 
			this.chk_GIRO.AutoHeight = false;
			this.chk_GIRO.Name = "chk_GIRO";
			// 
			// gridColumn8
			// 
			this.gridColumn8.Caption = "Upgrade Group";
			this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumn8.FieldName = "fNoRestrictionUpgrade";
			this.gridColumn8.Name = "gridColumn8";
			this.gridColumn8.Visible = true;
			this.gridColumn8.VisibleIndex = 15;
			this.gridColumn8.Width = 108;
			// 
			// gridColumn28
			// 
			this.gridColumn28.Caption = "POS";
			this.gridColumn28.ColumnEdit = this.chk_Sell;
			this.gridColumn28.FieldName = "fSell";
			this.gridColumn28.Name = "gridColumn28";
			this.gridColumn28.Visible = true;
			this.gridColumn28.VisibleIndex = 16;
			// 
			// chk_Sell
			// 
			this.chk_Sell.AutoHeight = false;
			this.chk_Sell.Name = "chk_Sell";
			// 
			// chk_Peak_1
			// 
			this.chk_Peak_1.AutoHeight = false;
			this.chk_Peak_1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																									new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.chk_Peak_1.Name = "chk_Peak_1";
			// 
			// chk_StuPackage
			// 
			this.chk_StuPackage.AutoHeight = false;
			this.chk_StuPackage.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																										new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.chk_StuPackage.Name = "chk_StuPackage";
			// 
			// repositoryItemCheckEdit1
			// 
			this.repositoryItemCheckEdit1.AutoHeight = false;
			this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
			// 
			// chk_RestUpgrade
			// 
			this.chk_RestUpgrade.AutoHeight = false;
			this.chk_RestUpgrade.Name = "chk_RestUpgrade";
			// 
			// grpPackageGroup
			// 
			this.grpPackageGroup.Controls.Add(this.btnPacGroup_Add);
			this.grpPackageGroup.Controls.Add(this.btnPacGroup_Del);
			this.grpPackageGroup.Controls.Add(this.groupControl4);
			this.grpPackageGroup.Location = new System.Drawing.Point(0, 48);
			this.grpPackageGroup.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.grpPackageGroup.LookAndFeel.UseDefaultLookAndFeel = false;
			this.grpPackageGroup.LookAndFeel.UseWindowsXPTheme = false;
			this.grpPackageGroup.Name = "grpPackageGroup";
			this.grpPackageGroup.Size = new System.Drawing.Size(960, 232);
			this.grpPackageGroup.TabIndex = 119;
			this.grpPackageGroup.Text = "Package Group";
			// 
			// btnPacGroup_Add
			// 
			this.btnPacGroup_Add.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
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
			this.btnPacGroup_Add.Click += new System.EventHandler(this.btnPacGroup_Add_Click);
			// 
			// btnPacGroup_Del
			// 
			this.btnPacGroup_Del.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
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
			this.btnPacGroup_Del.Click += new System.EventHandler(this.btnPacGroup_Del_Click);
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
			// 
			// gridControlMd_PackageGroup.EmbeddedNavigator
			// 
			this.gridControlMd_PackageGroup.EmbeddedNavigator.Name = "";
			this.gridControlMd_PackageGroup.Location = new System.Drawing.Point(0, 0);
			this.gridControlMd_PackageGroup.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
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
			this.gridViewMd_PackageGroup.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewMd_PackageGroup_FocusedRowChanged);
			this.gridViewMd_PackageGroup.LostFocus += new System.EventHandler(this.gridViewMd_PackageGroup_LostFocus);
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
			// grpPackageClass
			// 
			this.grpPackageClass.Controls.Add(this.btn_PGC_Del);
			this.grpPackageClass.Controls.Add(this.btn_PGCAll_Del);
			this.grpPackageClass.Controls.Add(this.btn_PGCAll_Add);
			this.grpPackageClass.Controls.Add(this.btn_PGC_Add);
			this.grpPackageClass.Controls.Add(this.gridPackageClass2);
			this.grpPackageClass.Controls.Add(this.label2);
			this.grpPackageClass.Controls.Add(this.gridPackageClass);
			this.grpPackageClass.Controls.Add(this.btn_PGB_Del);
			this.grpPackageClass.Controls.Add(this.btn_PGBAll_Del);
			this.grpPackageClass.Controls.Add(this.btn_PGBAll_Add);
			this.grpPackageClass.Controls.Add(this.btn_PGB_Add);
			this.grpPackageClass.Controls.Add(this.gridPcGroupBranch2);
			this.grpPackageClass.Controls.Add(this.label4);
			this.grpPackageClass.Controls.Add(this.gridPcGroupBranch);
			this.grpPackageClass.Controls.Add(this.label119);
			this.grpPackageClass.Controls.Add(this.label120);
			this.grpPackageClass.Location = new System.Drawing.Point(8, 288);
			this.grpPackageClass.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.grpPackageClass.LookAndFeel.UseDefaultLookAndFeel = false;
			this.grpPackageClass.LookAndFeel.UseWindowsXPTheme = false;
			this.grpPackageClass.Name = "grpPackageClass";
			this.grpPackageClass.Size = new System.Drawing.Size(968, 296);
			this.grpPackageClass.TabIndex = 94;
			this.grpPackageClass.Text = "EMPLOYEE PACKAGE SETUP .....";
			// 
			// btn_PGC_Del
			// 
			this.btn_PGC_Del.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btn_PGC_Del.Location = new System.Drawing.Point(496, 232);
			this.btn_PGC_Del.Name = "btn_PGC_Del";
			this.btn_PGC_Del.Size = new System.Drawing.Size(30, 20);
			this.btn_PGC_Del.TabIndex = 151;
			this.btn_PGC_Del.Text = "<";
			this.btn_PGC_Del.Click += new System.EventHandler(this.btn_PGC_Del_Click);
			// 
			// btn_PGCAll_Del
			// 
			this.btn_PGCAll_Del.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btn_PGCAll_Del.Location = new System.Drawing.Point(496, 208);
			this.btn_PGCAll_Del.Name = "btn_PGCAll_Del";
			this.btn_PGCAll_Del.Size = new System.Drawing.Size(30, 20);
			this.btn_PGCAll_Del.TabIndex = 150;
			this.btn_PGCAll_Del.Text = "<<";
			this.btn_PGCAll_Del.Click += new System.EventHandler(this.btn_PGCAll_Del_Click);
			// 
			// btn_PGCAll_Add
			// 
			this.btn_PGCAll_Add.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btn_PGCAll_Add.Location = new System.Drawing.Point(496, 184);
			this.btn_PGCAll_Add.Name = "btn_PGCAll_Add";
			this.btn_PGCAll_Add.Size = new System.Drawing.Size(30, 20);
			this.btn_PGCAll_Add.TabIndex = 149;
			this.btn_PGCAll_Add.Text = ">>";
			this.btn_PGCAll_Add.Click += new System.EventHandler(this.btn_PGCAll_Add_Click);
			// 
			// btn_PGC_Add
			// 
			this.btn_PGC_Add.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btn_PGC_Add.Location = new System.Drawing.Point(496, 160);
			this.btn_PGC_Add.Name = "btn_PGC_Add";
			this.btn_PGC_Add.Size = new System.Drawing.Size(30, 20);
			this.btn_PGC_Add.TabIndex = 148;
			this.btn_PGC_Add.Text = ">";
			this.btn_PGC_Add.Click += new System.EventHandler(this.btn_PGC_Add_Click);
			// 
			// gridPackageClass2
			// 
			// 
			// gridPackageClass2.EmbeddedNavigator
			// 
			this.gridPackageClass2.EmbeddedNavigator.Name = "";
			this.gridPackageClass2.Location = new System.Drawing.Point(536, 160);
			this.gridPackageClass2.MainView = this.gvPackageClass2;
			this.gridPackageClass2.Name = "gridPackageClass2";
			this.gridPackageClass2.Size = new System.Drawing.Size(424, 128);
			this.gridPackageClass2.TabIndex = 152;
			this.gridPackageClass2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																											 this.gvPackageClass2});
			// 
			// gvPackageClass2
			// 
			this.gvPackageClass2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																								   this.gridColumn13,
																								   this.gridColumn14,
																								   this.gridColumn21});
			this.gvPackageClass2.GridControl = this.gridPackageClass2;
			this.gvPackageClass2.Name = "gvPackageClass2";
			this.gvPackageClass2.OptionsBehavior.AllowIncrementalSearch = true;
			this.gvPackageClass2.OptionsBehavior.Editable = false;
			this.gvPackageClass2.OptionsCustomization.AllowFilter = false;
			this.gvPackageClass2.OptionsSelection.MultiSelect = true;
			this.gvPackageClass2.OptionsView.ShowGroupPanel = false;
			this.gvPackageClass2.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
																											new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn13, DevExpress.Data.ColumnSortOrder.Ascending)});
			// 
			// gridColumn13
			// 
			this.gridColumn13.Caption = "Class Code";
			this.gridColumn13.FieldName = "strClassCode";
			this.gridColumn13.Name = "gridColumn13";
			this.gridColumn13.Visible = true;
			this.gridColumn13.VisibleIndex = 0;
			this.gridColumn13.Width = 104;
			// 
			// gridColumn14
			// 
			this.gridColumn14.Caption = "Description";
			this.gridColumn14.FieldName = "strDescription";
			this.gridColumn14.Name = "gridColumn14";
			this.gridColumn14.Visible = true;
			this.gridColumn14.VisibleIndex = 1;
			this.gridColumn14.Width = 282;
			// 
			// gridColumn21
			// 
			this.gridColumn21.FieldName = "strPackageCode";
			this.gridColumn21.Name = "gridColumn21";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 160);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 34);
			this.label2.TabIndex = 153;
			this.label2.Text = "Package Class";
			// 
			// gridPackageClass
			// 
			// 
			// gridPackageClass.EmbeddedNavigator
			// 
			this.gridPackageClass.EmbeddedNavigator.Name = "";
			this.gridPackageClass.Location = new System.Drawing.Point(64, 160);
			this.gridPackageClass.MainView = this.gvPackageClass;
			this.gridPackageClass.Name = "gridPackageClass";
			this.gridPackageClass.Size = new System.Drawing.Size(424, 128);
			this.gridPackageClass.TabIndex = 147;
			this.gridPackageClass.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																											this.gvPackageClass});
			// 
			// gvPackageClass
			// 
			this.gvPackageClass.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																								  this.gridColumn15,
																								  this.gridColumn16});
			this.gvPackageClass.GridControl = this.gridPackageClass;
			this.gvPackageClass.Name = "gvPackageClass";
			this.gvPackageClass.OptionsBehavior.AllowIncrementalSearch = true;
			this.gvPackageClass.OptionsBehavior.Editable = false;
			this.gvPackageClass.OptionsCustomization.AllowFilter = false;
			this.gvPackageClass.OptionsSelection.MultiSelect = true;
			this.gvPackageClass.OptionsView.ShowGroupPanel = false;
			this.gvPackageClass.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
																										   new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn15, DevExpress.Data.ColumnSortOrder.Ascending)});
			// 
			// gridColumn15
			// 
			this.gridColumn15.Caption = "Class Code";
			this.gridColumn15.FieldName = "strClassCode";
			this.gridColumn15.Name = "gridColumn15";
			this.gridColumn15.Visible = true;
			this.gridColumn15.VisibleIndex = 0;
			this.gridColumn15.Width = 107;
			// 
			// gridColumn16
			// 
			this.gridColumn16.Caption = "Description";
			this.gridColumn16.FieldName = "strDescription";
			this.gridColumn16.Name = "gridColumn16";
			this.gridColumn16.Visible = true;
			this.gridColumn16.VisibleIndex = 1;
			this.gridColumn16.Width = 279;
			// 
			// btn_PGB_Del
			// 
			this.btn_PGB_Del.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btn_PGB_Del.Location = new System.Drawing.Point(496, 96);
			this.btn_PGB_Del.Name = "btn_PGB_Del";
			this.btn_PGB_Del.Size = new System.Drawing.Size(30, 20);
			this.btn_PGB_Del.TabIndex = 144;
			this.btn_PGB_Del.Text = "<";
			this.btn_PGB_Del.Click += new System.EventHandler(this.btn_PGB_Del_Click);
			// 
			// btn_PGBAll_Del
			// 
			this.btn_PGBAll_Del.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btn_PGBAll_Del.Location = new System.Drawing.Point(496, 72);
			this.btn_PGBAll_Del.Name = "btn_PGBAll_Del";
			this.btn_PGBAll_Del.Size = new System.Drawing.Size(30, 20);
			this.btn_PGBAll_Del.TabIndex = 143;
			this.btn_PGBAll_Del.Text = "<<";
			this.btn_PGBAll_Del.Click += new System.EventHandler(this.btn_PGBAll_Del_Click);
			// 
			// btn_PGBAll_Add
			// 
			this.btn_PGBAll_Add.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btn_PGBAll_Add.Location = new System.Drawing.Point(496, 48);
			this.btn_PGBAll_Add.Name = "btn_PGBAll_Add";
			this.btn_PGBAll_Add.Size = new System.Drawing.Size(30, 20);
			this.btn_PGBAll_Add.TabIndex = 142;
			this.btn_PGBAll_Add.Text = ">>";
			this.btn_PGBAll_Add.Click += new System.EventHandler(this.btn_PGBAll_Add_Click);
			// 
			// btn_PGB_Add
			// 
			this.btn_PGB_Add.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btn_PGB_Add.Location = new System.Drawing.Point(496, 24);
			this.btn_PGB_Add.Name = "btn_PGB_Add";
			this.btn_PGB_Add.Size = new System.Drawing.Size(30, 20);
			this.btn_PGB_Add.TabIndex = 141;
			this.btn_PGB_Add.Text = ">";
			this.btn_PGB_Add.Click += new System.EventHandler(this.btn_PGB_Add_Click);
			// 
			// gridPcGroupBranch2
			// 
			// 
			// gridPcGroupBranch2.EmbeddedNavigator
			// 
			this.gridPcGroupBranch2.EmbeddedNavigator.Name = "";
			this.gridPcGroupBranch2.Location = new System.Drawing.Point(536, 24);
			this.gridPcGroupBranch2.MainView = this.gvPcGroupBranch2;
			this.gridPcGroupBranch2.Name = "gridPcGroupBranch2";
			this.gridPcGroupBranch2.Size = new System.Drawing.Size(424, 128);
			this.gridPcGroupBranch2.TabIndex = 145;
			this.gridPcGroupBranch2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																											  this.gvPcGroupBranch2});
			// 
			// gvPcGroupBranch2
			// 
			this.gvPcGroupBranch2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																									this.gridColumn17,
																									this.gridColumn18,
																									this.gridColumn22});
			this.gvPcGroupBranch2.GridControl = this.gridPcGroupBranch2;
			this.gvPcGroupBranch2.Name = "gvPcGroupBranch2";
			this.gvPcGroupBranch2.OptionsBehavior.AllowIncrementalSearch = true;
			this.gvPcGroupBranch2.OptionsBehavior.Editable = false;
			this.gvPcGroupBranch2.OptionsCustomization.AllowFilter = false;
			this.gvPcGroupBranch2.OptionsSelection.MultiSelect = true;
			this.gvPcGroupBranch2.OptionsView.ShowGroupPanel = false;
			this.gvPcGroupBranch2.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
																											 new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn17, DevExpress.Data.ColumnSortOrder.Ascending)});
			// 
			// gridColumn17
			// 
			this.gridColumn17.Caption = "Branch";
			this.gridColumn17.FieldName = "strBranchCode";
			this.gridColumn17.Name = "gridColumn17";
			this.gridColumn17.Visible = true;
			this.gridColumn17.VisibleIndex = 0;
			this.gridColumn17.Width = 104;
			// 
			// gridColumn18
			// 
			this.gridColumn18.Caption = "Branch Name";
			this.gridColumn18.FieldName = "strBranchName";
			this.gridColumn18.Name = "gridColumn18";
			this.gridColumn18.Visible = true;
			this.gridColumn18.VisibleIndex = 1;
			this.gridColumn18.Width = 282;
			// 
			// gridColumn22
			// 
			this.gridColumn22.Caption = "strPackageCode";
			this.gridColumn22.FieldName = "strPackageCode";
			this.gridColumn22.Name = "gridColumn22";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 34);
			this.label4.TabIndex = 146;
			this.label4.Text = "Package Branch";
			// 
			// gridPcGroupBranch
			// 
			// 
			// gridPcGroupBranch.EmbeddedNavigator
			// 
			this.gridPcGroupBranch.EmbeddedNavigator.Name = "";
			this.gridPcGroupBranch.Location = new System.Drawing.Point(64, 24);
			this.gridPcGroupBranch.MainView = this.gvPcGroupBranch;
			this.gridPcGroupBranch.Name = "gridPcGroupBranch";
			this.gridPcGroupBranch.Size = new System.Drawing.Size(424, 128);
			this.gridPcGroupBranch.TabIndex = 140;
			this.gridPcGroupBranch.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																											 this.gvPcGroupBranch});
			// 
			// gvPcGroupBranch
			// 
			this.gvPcGroupBranch.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																								   this.gridColumn19,
																								   this.gridColumn20});
			this.gvPcGroupBranch.GridControl = this.gridPcGroupBranch;
			this.gvPcGroupBranch.Name = "gvPcGroupBranch";
			this.gvPcGroupBranch.OptionsBehavior.AllowIncrementalSearch = true;
			this.gvPcGroupBranch.OptionsBehavior.Editable = false;
			this.gvPcGroupBranch.OptionsCustomization.AllowFilter = false;
			this.gvPcGroupBranch.OptionsSelection.MultiSelect = true;
			this.gvPcGroupBranch.OptionsView.ShowGroupPanel = false;
			this.gvPcGroupBranch.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
																											new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn19, DevExpress.Data.ColumnSortOrder.Ascending)});
			// 
			// gridColumn19
			// 
			this.gridColumn19.Caption = "Branch";
			this.gridColumn19.FieldName = "strBranchCode";
			this.gridColumn19.Name = "gridColumn19";
			this.gridColumn19.Visible = true;
			this.gridColumn19.VisibleIndex = 0;
			this.gridColumn19.Width = 107;
			// 
			// gridColumn20
			// 
			this.gridColumn20.Caption = "Branch Name";
			this.gridColumn20.FieldName = "strBranchName";
			this.gridColumn20.Name = "gridColumn20";
			this.gridColumn20.Visible = true;
			this.gridColumn20.VisibleIndex = 1;
			this.gridColumn20.Width = 279;
			// 
			// label119
			// 
			this.label119.BackColor = System.Drawing.Color.Transparent;
			this.label119.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label119.Location = new System.Drawing.Point(560, 24);
			this.label119.Name = "label119";
			this.label119.Size = new System.Drawing.Size(56, 16);
			this.label119.TabIndex = 139;
			this.label119.Text = "Services";
			this.label119.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label120
			// 
			this.label120.BackColor = System.Drawing.Color.Transparent;
			this.label120.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label120.Location = new System.Drawing.Point(288, 24);
			this.label120.Name = "label120";
			this.label120.Size = new System.Drawing.Size(56, 16);
			this.label120.TabIndex = 138;
			this.label120.Text = "Class";
			this.label120.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// grpPackageService
			// 
			this.grpPackageService.Controls.Add(this.btn_PSAll_Del);
			this.grpPackageService.Controls.Add(this.btn_PS_Del);
			this.grpPackageService.Controls.Add(this.btn_PSAdd_Add);
			this.grpPackageService.Controls.Add(this.btn_PS_Add);
			this.grpPackageService.Controls.Add(this.gridPackageService2);
			this.grpPackageService.Controls.Add(this.label1);
			this.grpPackageService.Controls.Add(this.gridPackageService);
			this.grpPackageService.Controls.Add(this.btn_PB_Del);
			this.grpPackageService.Controls.Add(this.btn_PBAll_Del);
			this.grpPackageService.Controls.Add(this.btn_PBAll_Add);
			this.grpPackageService.Controls.Add(this.btn_PB_Add);
			this.grpPackageService.Controls.Add(this.gridPackageBranch2);
			this.grpPackageService.Controls.Add(this.label3);
			this.grpPackageService.Controls.Add(this.gridPackageBranch);
			this.grpPackageService.Location = new System.Drawing.Point(8, 288);
			this.grpPackageService.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.grpPackageService.LookAndFeel.UseDefaultLookAndFeel = false;
			this.grpPackageService.LookAndFeel.UseWindowsXPTheme = false;
			this.grpPackageService.Name = "grpPackageService";
			this.grpPackageService.Size = new System.Drawing.Size(960, 296);
			this.grpPackageService.TabIndex = 99;
			this.grpPackageService.Text = "EMPLOYEE PACKAGE SETUP .....";
			// 
			// btn_PSAll_Del
			// 
			this.btn_PSAll_Del.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btn_PSAll_Del.Location = new System.Drawing.Point(496, 232);
			this.btn_PSAll_Del.Name = "btn_PSAll_Del";
			this.btn_PSAll_Del.Size = new System.Drawing.Size(30, 20);
			this.btn_PSAll_Del.TabIndex = 28;
			this.btn_PSAll_Del.Text = "<";
			this.btn_PSAll_Del.Click += new System.EventHandler(this.btn_PSAll_Del_Click);
			// 
			// btn_PS_Del
			// 
			this.btn_PS_Del.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btn_PS_Del.Location = new System.Drawing.Point(496, 208);
			this.btn_PS_Del.Name = "btn_PS_Del";
			this.btn_PS_Del.Size = new System.Drawing.Size(30, 20);
			this.btn_PS_Del.TabIndex = 27;
			this.btn_PS_Del.Text = "<<";
			this.btn_PS_Del.Click += new System.EventHandler(this.btn_PS_Del_Click);
			// 
			// btn_PSAdd_Add
			// 
			this.btn_PSAdd_Add.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btn_PSAdd_Add.Location = new System.Drawing.Point(496, 184);
			this.btn_PSAdd_Add.Name = "btn_PSAdd_Add";
			this.btn_PSAdd_Add.Size = new System.Drawing.Size(30, 20);
			this.btn_PSAdd_Add.TabIndex = 26;
			this.btn_PSAdd_Add.Text = ">>";
			this.btn_PSAdd_Add.Click += new System.EventHandler(this.btn_PSAdd_Add_Click);
			// 
			// btn_PS_Add
			// 
			this.btn_PS_Add.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btn_PS_Add.Location = new System.Drawing.Point(496, 160);
			this.btn_PS_Add.Name = "btn_PS_Add";
			this.btn_PS_Add.Size = new System.Drawing.Size(30, 20);
			this.btn_PS_Add.TabIndex = 25;
			this.btn_PS_Add.Text = ">";
			this.btn_PS_Add.Click += new System.EventHandler(this.btn_PS_Add_Click);
			// 
			// gridPackageService2
			// 
			// 
			// gridPackageService2.EmbeddedNavigator
			// 
			this.gridPackageService2.EmbeddedNavigator.Name = "";
			this.gridPackageService2.Location = new System.Drawing.Point(536, 160);
			this.gridPackageService2.MainView = this.gvPackageService2;
			this.gridPackageService2.Name = "gridPackageService2";
			this.gridPackageService2.Size = new System.Drawing.Size(424, 128);
			this.gridPackageService2.TabIndex = 29;
			this.gridPackageService2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																											   this.gvPackageService2});
			// 
			// gvPackageService2
			// 
			this.gvPackageService2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																									 this.gridColumn9,
																									 this.gridColumn10,
																									 this.gridColumn23});
			this.gvPackageService2.GridControl = this.gridPackageService2;
			this.gvPackageService2.Name = "gvPackageService2";
			this.gvPackageService2.OptionsBehavior.AllowIncrementalSearch = true;
			this.gvPackageService2.OptionsBehavior.Editable = false;
			this.gvPackageService2.OptionsCustomization.AllowFilter = false;
			this.gvPackageService2.OptionsSelection.MultiSelect = true;
			this.gvPackageService2.OptionsView.ShowGroupPanel = false;
			this.gvPackageService2.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
																											  new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn9, DevExpress.Data.ColumnSortOrder.Ascending)});
			// 
			// gridColumn9
			// 
			this.gridColumn9.Caption = "Service Code";
			this.gridColumn9.FieldName = "strServiceCode";
			this.gridColumn9.Name = "gridColumn9";
			this.gridColumn9.Visible = true;
			this.gridColumn9.VisibleIndex = 0;
			this.gridColumn9.Width = 104;
			// 
			// gridColumn10
			// 
			this.gridColumn10.Caption = "Description";
			this.gridColumn10.FieldName = "strDescription";
			this.gridColumn10.Name = "gridColumn10";
			this.gridColumn10.Visible = true;
			this.gridColumn10.VisibleIndex = 1;
			this.gridColumn10.Width = 282;
			// 
			// gridColumn23
			// 
			this.gridColumn23.FieldName = "strPackageCode";
			this.gridColumn23.Name = "gridColumn23";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 168);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 34);
			this.label1.TabIndex = 30;
			this.label1.Text = "Package Service";
			// 
			// gridPackageService
			// 
			// 
			// gridPackageService.EmbeddedNavigator
			// 
			this.gridPackageService.EmbeddedNavigator.Name = "";
			this.gridPackageService.Location = new System.Drawing.Point(64, 160);
			this.gridPackageService.MainView = this.gvPackageService;
			this.gridPackageService.Name = "gridPackageService";
			this.gridPackageService.Size = new System.Drawing.Size(424, 128);
			this.gridPackageService.TabIndex = 24;
			this.gridPackageService.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																											  this.gvPackageService});
			// 
			// gvPackageService
			// 
			this.gvPackageService.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																									this.gridColumn11,
																									this.gridColumn12});
			this.gvPackageService.GridControl = this.gridPackageService;
			this.gvPackageService.Name = "gvPackageService";
			this.gvPackageService.OptionsBehavior.AllowIncrementalSearch = true;
			this.gvPackageService.OptionsBehavior.Editable = false;
			this.gvPackageService.OptionsCustomization.AllowFilter = false;
			this.gvPackageService.OptionsSelection.MultiSelect = true;
			this.gvPackageService.OptionsView.ShowGroupPanel = false;
			this.gvPackageService.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
																											 new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn11, DevExpress.Data.ColumnSortOrder.Ascending)});
			// 
			// gridColumn11
			// 
			this.gridColumn11.Caption = "Service Code";
			this.gridColumn11.FieldName = "strServiceCode";
			this.gridColumn11.Name = "gridColumn11";
			this.gridColumn11.Visible = true;
			this.gridColumn11.VisibleIndex = 0;
			this.gridColumn11.Width = 107;
			// 
			// gridColumn12
			// 
			this.gridColumn12.Caption = "Description";
			this.gridColumn12.FieldName = "strDescription";
			this.gridColumn12.Name = "gridColumn12";
			this.gridColumn12.Visible = true;
			this.gridColumn12.VisibleIndex = 1;
			this.gridColumn12.Width = 279;
			// 
			// btn_PB_Del
			// 
			this.btn_PB_Del.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btn_PB_Del.Location = new System.Drawing.Point(496, 96);
			this.btn_PB_Del.Name = "btn_PB_Del";
			this.btn_PB_Del.Size = new System.Drawing.Size(30, 20);
			this.btn_PB_Del.TabIndex = 21;
			this.btn_PB_Del.Text = "<";
			this.btn_PB_Del.Click += new System.EventHandler(this.btn_PB_Del_Click);
			// 
			// btn_PBAll_Del
			// 
			this.btn_PBAll_Del.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btn_PBAll_Del.Location = new System.Drawing.Point(496, 72);
			this.btn_PBAll_Del.Name = "btn_PBAll_Del";
			this.btn_PBAll_Del.Size = new System.Drawing.Size(30, 20);
			this.btn_PBAll_Del.TabIndex = 20;
			this.btn_PBAll_Del.Text = "<<";
			this.btn_PBAll_Del.Click += new System.EventHandler(this.btn_PBAll_Del_Click);
			// 
			// btn_PBAll_Add
			// 
			this.btn_PBAll_Add.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btn_PBAll_Add.Location = new System.Drawing.Point(496, 48);
			this.btn_PBAll_Add.Name = "btn_PBAll_Add";
			this.btn_PBAll_Add.Size = new System.Drawing.Size(30, 20);
			this.btn_PBAll_Add.TabIndex = 19;
			this.btn_PBAll_Add.Text = ">>";
			this.btn_PBAll_Add.Click += new System.EventHandler(this.btn_PBAll_Add_Click);
			// 
			// btn_PB_Add
			// 
			this.btn_PB_Add.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btn_PB_Add.Location = new System.Drawing.Point(496, 24);
			this.btn_PB_Add.Name = "btn_PB_Add";
			this.btn_PB_Add.Size = new System.Drawing.Size(30, 20);
			this.btn_PB_Add.TabIndex = 18;
			this.btn_PB_Add.Text = ">";
			this.btn_PB_Add.Click += new System.EventHandler(this.btn_PB_Add_Click);
			// 
			// gridPackageBranch2
			// 
			// 
			// gridPackageBranch2.EmbeddedNavigator
			// 
			this.gridPackageBranch2.EmbeddedNavigator.Name = "";
			this.gridPackageBranch2.Location = new System.Drawing.Point(536, 24);
			this.gridPackageBranch2.MainView = this.gvPSBranch2;
			this.gridPackageBranch2.Name = "gridPackageBranch2";
			this.gridPackageBranch2.Size = new System.Drawing.Size(424, 128);
			this.gridPackageBranch2.TabIndex = 22;
			this.gridPackageBranch2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																											  this.gvPSBranch2});
			// 
			// gvPSBranch2
			// 
			this.gvPSBranch2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							   this.colBranchCode2,
																							   this.colBranchName2});
			this.gvPSBranch2.GridControl = this.gridPackageBranch2;
			this.gvPSBranch2.Name = "gvPSBranch2";
			this.gvPSBranch2.OptionsBehavior.AllowIncrementalSearch = true;
			this.gvPSBranch2.OptionsBehavior.Editable = false;
			this.gvPSBranch2.OptionsCustomization.AllowFilter = false;
			this.gvPSBranch2.OptionsSelection.MultiSelect = true;
			this.gvPSBranch2.OptionsView.ShowGroupPanel = false;
			this.gvPSBranch2.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
																										new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colBranchCode2, DevExpress.Data.ColumnSortOrder.Ascending)});
			// 
			// colBranchCode2
			// 
			this.colBranchCode2.Caption = "Branch";
			this.colBranchCode2.FieldName = "strBranchCode";
			this.colBranchCode2.Name = "colBranchCode2";
			this.colBranchCode2.Visible = true;
			this.colBranchCode2.VisibleIndex = 0;
			this.colBranchCode2.Width = 104;
			// 
			// colBranchName2
			// 
			this.colBranchName2.Caption = "Branch Name";
			this.colBranchName2.FieldName = "strBranchName";
			this.colBranchName2.Name = "colBranchName2";
			this.colBranchName2.Visible = true;
			this.colBranchName2.VisibleIndex = 1;
			this.colBranchName2.Width = 282;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 34);
			this.label3.TabIndex = 23;
			this.label3.Text = "Package Branch";
			// 
			// gridPackageBranch
			// 
			// 
			// gridPackageBranch.EmbeddedNavigator
			// 
			this.gridPackageBranch.EmbeddedNavigator.Name = "";
			this.gridPackageBranch.Location = new System.Drawing.Point(64, 24);
			this.gridPackageBranch.MainView = this.gvPSBranch;
			this.gridPackageBranch.Name = "gridPackageBranch";
			this.gridPackageBranch.Size = new System.Drawing.Size(424, 128);
			this.gridPackageBranch.TabIndex = 17;
			this.gridPackageBranch.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																											 this.gvPSBranch});
			// 
			// gvPSBranch
			// 
			this.gvPSBranch.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							  this.colBranchCode,
																							  this.colBranchName});
			this.gvPSBranch.GridControl = this.gridPackageBranch;
			this.gvPSBranch.Name = "gvPSBranch";
			this.gvPSBranch.OptionsBehavior.AllowIncrementalSearch = true;
			this.gvPSBranch.OptionsBehavior.Editable = false;
			this.gvPSBranch.OptionsCustomization.AllowFilter = false;
			this.gvPSBranch.OptionsSelection.MultiSelect = true;
			this.gvPSBranch.OptionsView.ShowGroupPanel = false;
			this.gvPSBranch.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
																									   new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colBranchCode, DevExpress.Data.ColumnSortOrder.Ascending)});
			// 
			// colBranchCode
			// 
			this.colBranchCode.Caption = "Branch";
			this.colBranchCode.FieldName = "strBranchCode";
			this.colBranchCode.Name = "colBranchCode";
			this.colBranchCode.Visible = true;
			this.colBranchCode.VisibleIndex = 0;
			this.colBranchCode.Width = 107;
			// 
			// colBranchName
			// 
			this.colBranchName.Caption = "Branch Name";
			this.colBranchName.FieldName = "strBranchName";
			this.colBranchName.Name = "colBranchName";
			this.colBranchName.Visible = true;
			this.colBranchName.VisibleIndex = 1;
			this.colBranchName.Width = 279;
			// 
			// PackageGroup
			// 
			this.PackageGroup.Controls.Add(this.btn_PacGroup_Add);
			this.PackageGroup.Controls.Add(this.btn_PacGroup_Del);
			this.PackageGroup.Controls.Add(this.groupControl2);
			this.PackageGroup.Controls.Add(this.splitter2);
			this.PackageGroup.ImeMode = System.Windows.Forms.ImeMode.On;
			this.PackageGroup.Location = new System.Drawing.Point(8, 288);
			this.PackageGroup.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.PackageGroup.LookAndFeel.UseDefaultLookAndFeel = false;
			this.PackageGroup.LookAndFeel.UseWindowsXPTheme = false;
			this.PackageGroup.Name = "PackageGroup";
			this.PackageGroup.Size = new System.Drawing.Size(952, 296);
			this.PackageGroup.TabIndex = 100;
			this.PackageGroup.Text = "PACKAGE GROUP ENTRIES SETUP .....";
			// 
			// btn_PacGroup_Add
			// 
			this.btn_PacGroup_Add.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btn_PacGroup_Add.Appearance.Options.UseFont = true;
			this.btn_PacGroup_Add.Appearance.Options.UseTextOptions = true;
			this.btn_PacGroup_Add.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.btn_PacGroup_Add.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
			this.btn_PacGroup_Add.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.btn_PacGroup_Add.ImageIndex = 0;
			this.btn_PacGroup_Add.ImageList = this.imageList1;
			this.btn_PacGroup_Add.ImeMode = System.Windows.Forms.ImeMode.On;
			this.btn_PacGroup_Add.Location = new System.Drawing.Point(8, 24);
			this.btn_PacGroup_Add.Name = "btn_PacGroup_Add";
			this.btn_PacGroup_Add.Size = new System.Drawing.Size(32, 16);
			this.btn_PacGroup_Add.TabIndex = 134;
			this.btn_PacGroup_Add.Click += new System.EventHandler(this.btn_PacGroup_Add_Click);
			// 
			// btn_PacGroup_Del
			// 
			this.btn_PacGroup_Del.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btn_PacGroup_Del.Appearance.Options.UseFont = true;
			this.btn_PacGroup_Del.Appearance.Options.UseTextOptions = true;
			this.btn_PacGroup_Del.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.btn_PacGroup_Del.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
			this.btn_PacGroup_Del.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.btn_PacGroup_Del.ImageIndex = 1;
			this.btn_PacGroup_Del.ImageList = this.imageList1;
			this.btn_PacGroup_Del.Location = new System.Drawing.Point(40, 24);
			this.btn_PacGroup_Del.Name = "btn_PacGroup_Del";
			this.btn_PacGroup_Del.Size = new System.Drawing.Size(32, 16);
			this.btn_PacGroup_Del.TabIndex = 133;
			this.btn_PacGroup_Del.Click += new System.EventHandler(this.btn_PacGroup_Del_Click);
			// 
			// groupControl2
			// 
			this.groupControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.groupControl2.Controls.Add(this.gridControlMd_GroupEntries);
			this.groupControl2.Location = new System.Drawing.Point(0, 40);
			this.groupControl2.Name = "groupControl2";
			this.groupControl2.Size = new System.Drawing.Size(968, 248);
			this.groupControl2.TabIndex = 12;
			this.groupControl2.Text = "groupControl2";
			// 
			// gridControlMd_GroupEntries
			// 
			this.gridControlMd_GroupEntries.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// gridControlMd_GroupEntries.EmbeddedNavigator
			// 
			this.gridControlMd_GroupEntries.EmbeddedNavigator.Name = "";
			this.gridControlMd_GroupEntries.Location = new System.Drawing.Point(0, 0);
			this.gridControlMd_GroupEntries.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.gridControlMd_GroupEntries.LookAndFeel.UseDefaultLookAndFeel = false;
			this.gridControlMd_GroupEntries.MainView = this.gridViewMd_GroupEntries;
			this.gridControlMd_GroupEntries.Name = "gridControlMd_GroupEntries";
			this.gridControlMd_GroupEntries.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																																this.lk_GrpPackageCode});
			this.gridControlMd_GroupEntries.Size = new System.Drawing.Size(968, 248);
			this.gridControlMd_GroupEntries.TabIndex = 12;
			this.gridControlMd_GroupEntries.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																													  this.gridViewMd_GroupEntries});
			// 
			// gridViewMd_GroupEntries
			// 
			this.gridViewMd_GroupEntries.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																										   this.gridColumn44,
																										   this.gridColumn45,
																										   this.gridColumn46});
			this.gridViewMd_GroupEntries.GridControl = this.gridControlMd_GroupEntries;
			this.gridViewMd_GroupEntries.Name = "gridViewMd_GroupEntries";
			this.gridViewMd_GroupEntries.OptionsCustomization.AllowFilter = false;
			this.gridViewMd_GroupEntries.OptionsCustomization.AllowSort = false;
			this.gridViewMd_GroupEntries.OptionsView.ShowGroupPanel = false;
			this.gridViewMd_GroupEntries.LostFocus += new System.EventHandler(this.gridViewMd_GroupEntries_LostFocus);
			// 
			// gridColumn44
			// 
			this.gridColumn44.Caption = "Package Group Code";
			this.gridColumn44.FieldName = "strPackageGroupCode";
			this.gridColumn44.Name = "gridColumn44";
			// 
			// gridColumn45
			// 
			this.gridColumn45.Caption = "Package Code";
			this.gridColumn45.ColumnEdit = this.lk_GrpPackageCode;
			this.gridColumn45.FieldName = "strPackageCode";
			this.gridColumn45.Name = "gridColumn45";
			this.gridColumn45.Visible = true;
			this.gridColumn45.VisibleIndex = 0;
			// 
			// lk_GrpPackageCode
			// 
			this.lk_GrpPackageCode.AutoHeight = false;
			this.lk_GrpPackageCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																										   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lk_GrpPackageCode.Name = "lk_GrpPackageCode";
			// 
			// gridColumn46
			// 
			this.gridColumn46.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn46.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
			this.gridColumn46.Caption = "Quantity";
			this.gridColumn46.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumn46.FieldName = "nQuantity";
			this.gridColumn46.Name = "gridColumn46";
			this.gridColumn46.Visible = true;
			this.gridColumn46.VisibleIndex = 1;
			// 
			// splitter2
			// 
			this.splitter2.BackColor = System.Drawing.SystemColors.Control;
			this.splitter2.Dock = System.Windows.Forms.DockStyle.Right;
			this.splitter2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.splitter2.Location = new System.Drawing.Point(948, 20);
			this.splitter2.Name = "splitter2";
			this.splitter2.Size = new System.Drawing.Size(2, 274);
			this.splitter2.TabIndex = 7;
			this.splitter2.TabStop = false;
			// 
			// GroupCreditPackage
			// 
			this.GroupCreditPackage.Controls.Add(this.btn_CreGroup_Add);
			this.GroupCreditPackage.Controls.Add(this.btn_CreGroup_Del);
			this.GroupCreditPackage.Controls.Add(this.groupControl3);
			this.GroupCreditPackage.Location = new System.Drawing.Point(8, 288);
			this.GroupCreditPackage.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.GroupCreditPackage.LookAndFeel.UseDefaultLookAndFeel = false;
			this.GroupCreditPackage.LookAndFeel.UseWindowsXPTheme = false;
			this.GroupCreditPackage.Name = "GroupCreditPackage";
			this.GroupCreditPackage.Size = new System.Drawing.Size(968, 300);
			this.GroupCreditPackage.TabIndex = 101;
			this.GroupCreditPackage.Text = "EMPLOYEE CREDIT PACKAGE SETUP .....";
			// 
			// btn_CreGroup_Add
			// 
			this.btn_CreGroup_Add.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btn_CreGroup_Add.Appearance.Options.UseFont = true;
			this.btn_CreGroup_Add.Appearance.Options.UseTextOptions = true;
			this.btn_CreGroup_Add.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.btn_CreGroup_Add.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
			this.btn_CreGroup_Add.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.btn_CreGroup_Add.ImageIndex = 0;
			this.btn_CreGroup_Add.ImageList = this.imageList1;
			this.btn_CreGroup_Add.ImeMode = System.Windows.Forms.ImeMode.On;
			this.btn_CreGroup_Add.Location = new System.Drawing.Point(0, 24);
			this.btn_CreGroup_Add.Name = "btn_CreGroup_Add";
			this.btn_CreGroup_Add.Size = new System.Drawing.Size(32, 16);
			this.btn_CreGroup_Add.TabIndex = 136;
			this.btn_CreGroup_Add.Click += new System.EventHandler(this.btn_CreGroup_Add_Click);
			// 
			// btn_CreGroup_Del
			// 
			this.btn_CreGroup_Del.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btn_CreGroup_Del.Appearance.Options.UseFont = true;
			this.btn_CreGroup_Del.Appearance.Options.UseTextOptions = true;
			this.btn_CreGroup_Del.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.btn_CreGroup_Del.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
			this.btn_CreGroup_Del.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.btn_CreGroup_Del.ImageIndex = 1;
			this.btn_CreGroup_Del.ImageList = this.imageList1;
			this.btn_CreGroup_Del.Location = new System.Drawing.Point(32, 24);
			this.btn_CreGroup_Del.Name = "btn_CreGroup_Del";
			this.btn_CreGroup_Del.Size = new System.Drawing.Size(32, 16);
			this.btn_CreGroup_Del.TabIndex = 135;
			this.btn_CreGroup_Del.Click += new System.EventHandler(this.btn_CreGroup_Del_Click);
			// 
			// groupControl3
			// 
			this.groupControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.groupControl3.Controls.Add(this.GridCreditRestric);
			this.groupControl3.Location = new System.Drawing.Point(0, 40);
			this.groupControl3.Name = "groupControl3";
			this.groupControl3.Size = new System.Drawing.Size(944, 256);
			this.groupControl3.TabIndex = 12;
			this.groupControl3.Text = "groupControl3";
			// 
			// GridCreditRestric
			// 
			this.GridCreditRestric.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// GridCreditRestric.EmbeddedNavigator
			// 
			this.GridCreditRestric.EmbeddedNavigator.Name = "";
			gridLevelNode2.RelationName = "Level1";
			this.GridCreditRestric.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
																										gridLevelNode2});
			this.GridCreditRestric.Location = new System.Drawing.Point(0, 0);
			this.GridCreditRestric.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.GridCreditRestric.LookAndFeel.UseDefaultLookAndFeel = false;
			this.GridCreditRestric.MainView = this.gridViewmd_CreditRestric;
			this.GridCreditRestric.Name = "GridCreditRestric";
			this.GridCreditRestric.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																													   this.lk_PackageCode,
																													   this.chk_AllowDiscount});
			this.GridCreditRestric.Size = new System.Drawing.Size(944, 256);
			this.GridCreditRestric.TabIndex = 12;
			this.GridCreditRestric.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																											 this.gridViewmd_CreditRestric});
			// 
			// gridViewmd_CreditRestric
			// 
			this.gridViewmd_CreditRestric.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																											this.gridColumn25,
																											this.gridColumn26,
																											this.gridColumn27});
			this.gridViewmd_CreditRestric.GridControl = this.GridCreditRestric;
			this.gridViewmd_CreditRestric.Name = "gridViewmd_CreditRestric";
			this.gridViewmd_CreditRestric.OptionsCustomization.AllowFilter = false;
			this.gridViewmd_CreditRestric.OptionsCustomization.AllowSort = false;
			this.gridViewmd_CreditRestric.OptionsView.ShowGroupPanel = false;
			this.gridViewmd_CreditRestric.LostFocus += new System.EventHandler(this.gridViewmd_CreditRestric_LostFocus);
			// 
			// gridColumn25
			// 
			this.gridColumn25.FieldName = "strCreditPackageCode";
			this.gridColumn25.Name = "gridColumn25";
			// 
			// gridColumn26
			// 
			this.gridColumn26.Caption = "Package Code";
			this.gridColumn26.ColumnEdit = this.lk_PackageCode;
			this.gridColumn26.FieldName = "strPackageCode";
			this.gridColumn26.Name = "gridColumn26";
			this.gridColumn26.Visible = true;
			this.gridColumn26.VisibleIndex = 0;
			// 
			// lk_PackageCode
			// 
			this.lk_PackageCode.AutoHeight = false;
			this.lk_PackageCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																										new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lk_PackageCode.Name = "lk_PackageCode";
			// 
			// gridColumn27
			// 
			this.gridColumn27.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn27.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
			this.gridColumn27.Caption = "Allow Discount";
			this.gridColumn27.ColumnEdit = this.chk_AllowDiscount;
			this.gridColumn27.FieldName = "fAllowDiscount";
			this.gridColumn27.ImageAlignment = System.Drawing.StringAlignment.Center;
			this.gridColumn27.Name = "gridColumn27";
			this.gridColumn27.Visible = true;
			this.gridColumn27.VisibleIndex = 1;
			// 
			// chk_AllowDiscount
			// 
			this.chk_AllowDiscount.AutoHeight = false;
			this.chk_AllowDiscount.Name = "chk_AllowDiscount";
			// 
			// grpBranch
			// 
			this.grpBranch.Controls.Add(this.btnPacBranch_Del);
			this.grpBranch.Controls.Add(this.btnPacBranch_DelAll);
			this.grpBranch.Controls.Add(this.btnPacBranch_AddAll);
			this.grpBranch.Controls.Add(this.btnPacBranch_Add);
			this.grpBranch.Controls.Add(this.gridPacBranch2);
			this.grpBranch.Controls.Add(this.label6);
			this.grpBranch.Controls.Add(this.gridPacBranch);
			this.grpBranch.Location = new System.Drawing.Point(8, 288);
			this.grpBranch.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.grpBranch.LookAndFeel.UseDefaultLookAndFeel = false;
			this.grpBranch.LookAndFeel.UseWindowsXPTheme = false;
			this.grpBranch.Name = "grpBranch";
			this.grpBranch.Size = new System.Drawing.Size(960, 296);
			this.grpBranch.TabIndex = 102;
			this.grpBranch.Text = "PACKAGE SETUP .....";
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
			// 
			// gridPacBranch2.EmbeddedNavigator
			// 
			this.gridPacBranch2.EmbeddedNavigator.Name = "";
			this.gridPacBranch2.Location = new System.Drawing.Point(536, 24);
			this.gridPacBranch2.MainView = this.gvPacBranch2;
			this.gridPacBranch2.Name = "gridPacBranch2";
			this.gridPacBranch2.Size = new System.Drawing.Size(424, 264);
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
			this.label6.Size = new System.Drawing.Size(56, 34);
			this.label6.TabIndex = 23;
			this.label6.Text = "Package Branch";
			// 
			// gridPacBranch
			// 
			// 
			// gridPacBranch.EmbeddedNavigator
			// 
			this.gridPacBranch.EmbeddedNavigator.Name = "";
			this.gridPacBranch.Location = new System.Drawing.Point(64, 24);
			this.gridPacBranch.MainView = this.gvPacBranch;
			this.gridPacBranch.Name = "gridPacBranch";
			this.gridPacBranch.Size = new System.Drawing.Size(424, 264);
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
			// frmPackage
			// 
			this.AutoScale = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(982, 600);
			this.Controls.Add(this.grpBranch);
			this.Controls.Add(this.GroupCreditPackage);
			this.Controls.Add(this.PackageGroup);
			this.Controls.Add(this.grpPackageService);
			this.Controls.Add(this.grpMDPackageTop);
			this.Controls.Add(this.grpPackageClass);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmPackage";
			this.Text = "frmPackage";
			this.Load += new System.EventHandler(this.frmPackage_Load);
			((System.ComponentModel.ISupportInitialize)(this.grpMDPackageTop)).EndInit();
			this.grpMDPackageTop.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grpCreditPackage)).EndInit();
			this.grpCreditPackage.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
			this.groupControl5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControlMd_CreditPackage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewMd_CreditPackage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.EffCCStartDate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.EffCCEndDate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_CreditCategoryID)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ddlPackageCategory.Properties)).EndInit();
			this.Searchpanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grpPackage)).EndInit();
			this.grpPackage.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
			this.groupControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControlMd_Package)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewMd_Package)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.StartDate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.EndDate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chk_Peak)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chk_StudentPackage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_Category)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chk_GIRO)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chk_Sell)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chk_Peak_1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chk_StuPackage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chk_RestUpgrade)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grpPackageGroup)).EndInit();
			this.grpPackageGroup.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
			this.groupControl4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControlMd_PackageGroup)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewMd_PackageGroup)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_pkGroupCatID)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grpPackageClass)).EndInit();
			this.grpPackageClass.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridPackageClass2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvPackageClass2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridPackageClass)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvPackageClass)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridPcGroupBranch2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvPcGroupBranch2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridPcGroupBranch)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvPcGroupBranch)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grpPackageService)).EndInit();
			this.grpPackageService.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridPackageService2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvPackageService2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridPackageService)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvPackageService)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridPackageBranch2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvPSBranch2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridPackageBranch)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvPSBranch)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PackageGroup)).EndInit();
			this.PackageGroup.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
			this.groupControl2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControlMd_GroupEntries)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewMd_GroupEntries)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_GrpPackageCode)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GroupCreditPackage)).EndInit();
			this.GroupCreditPackage.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
			this.groupControl3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.GridCreditRestric)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewmd_CreditRestric)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_PackageCode)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chk_AllowDiscount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grpBranch)).EndInit();
			this.grpBranch.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridPacBranch2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvPacBranch2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridPacBranch)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvPacBranch)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region PACKAGE

		#region load
		private void LoadPackageGroup()
		{
			string strSQL;
			strSQL = "Select * from tblPackageGroup where (strPackageGroupCode like '%" + txtSearch.Text + "%' or  strDescription like '%" + txtSearch.Text + "%')";

			if (ddlPackageCategory.EditValue.ToString() != "")
				strSQL += " and nCategoryID = '" +  ddlPackageCategory.EditValue.ToString() + "'";
			
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dtPackageGroup = _ds.Tables["table"];
			this.gridControlMd_PackageGroup.DataSource = dtPackageGroup;

			if (dtPackageGroup.Rows.Count > 0)
				LoadPackageGroupEntries();
			
		}
					
		private void LoadCreditPackage()
		{
			string strSQL;
			strSQL = "select * from tblCreditPackage Where tblCreditPackage.nCategoryID = '" +  ddlPackageCategory.EditValue.ToString() + "'and ( strCreditPackageCode like '%" + txtSearch.Text + "%' or  strDescription like '%" + txtSearch.Text + "%')";; 

			
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dtPackageCredit = _ds.Tables["table"];

			this.gridControlMd_CreditPackage.DataSource = dtPackageCredit;

		}

		private void LoadCreditPackageRestric()
		{
			DataRow dr = this.gridViewMd_CreditPackage.GetDataRow(this.gridViewMd_CreditPackage.FocusedRowHandle);

			if (dr != null)
			{
				string strSQL;
				strSQL = "select * from tblCreditPackagerestriction Where strCreditPackageCode = '" + dr["strCreditPackageCode"].ToString() + "'";

				DataSet _ds = new DataSet();
				SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
				dtPackageCreditRestric = _ds.Tables["table"];

				this.GridCreditRestric.DataSource = dtPackageCreditRestric;
			}
		}

		
		private void RefreshCreditPackageRestric()
		{
			UI.ClearDataBinding(GroupCreditPackage.Controls);
		}
		
		#endregion

		#region delete

		private void DeleteCreditPackage() 
		{

			DataRow dr = this.gridViewMd_CreditPackage.GetDataRow(this.gridViewMd_CreditPackage.FocusedRowHandle);
			int output;
			output = 0;
			SqlHelper.ExecuteNonQuery(connection,"del_tblCreditPackage",
				new SqlParameter("@retval",output),
				new SqlParameter("@strCreditPackageCode",dr["strCreditPackageCode"].ToString()));
		}

		private void DeletePackageGroup()
		{
			DataRow dr = this.gridViewMd_PackageGroup.GetDataRow(this.gridViewMd_PackageGroup.FocusedRowHandle);
			int output;
			output = 0;
			SqlHelper.ExecuteNonQuery(connection,"del_tblPackageGroup",
				new SqlParameter("@retval",output),
				new SqlParameter("@strPackageGroupCode",dr["strPackageGroupCode"].ToString()));
		}

		private void DeletePackage()
		{
			DataRow dr = this.gridViewMd_Package.GetDataRow(this.gridViewMd_Package.FocusedRowHandle);
			if ( dr != null)
			{
				DialogResult result = MessageBox.Show(this, "Do you really want to delete record with Branch Code = '" + dr["strPackageCode"].ToString() + "'",
					"Delete?", MessageBoxButtons.YesNo);
				if (result == DialogResult.Yes)
				{
					int output;
					output = 0;
					try
					{
						SqlHelper.ExecuteNonQuery(connection,"del_tblPackage",
							new SqlParameter("@retval",output),
							new SqlParameter("@strPackageCode",dr["strPackageCode"].ToString()));
					}
					catch (Exception ex)
					{
						MessageBox.Show("Error on delete record : " + ex.Message,"Error");
					}


				}
			}
		}

		#endregion

		private void btnPacGroupEntriesUp_Click(object sender, System.EventArgs e)
		{
			LoadPackageGroupEntries();
		}

		

		private void btnPacGroupEntriesDel_Click(object sender, System.EventArgs e)
		{
			DataRow dr = this.gridViewMd_GroupEntries.GetDataRow(this.gridViewMd_GroupEntries.FocusedRowHandle);

			int output;
			output = 0;

			SqlHelper.ExecuteNonQuery(connection,"up_TblPackageGroupEntries",
				new SqlParameter("@retval",output),
				new SqlParameter("@cmd","D"),
				new SqlParameter("@strPackageGroupCode",dr["strPackageGroupCode"].ToString()),
				new SqlParameter("@strPackageCode",dr["strPackageCode"].ToString()),
				new SqlParameter("@nQuantity",1));
			LoadPackageGroupEntries();
		}

	
		private void mdPackageInit()
		{
			string strSQL;

			strSQL = "select * from tblPackage";
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dtPackage = _ds.Tables["table"];
			this.gridControlMd_Package.DataSource = dtPackage;
		}

		private void mdPackageGroupInit()
		{
			string strSQL;

			strSQL = "select * from tblPackageGroup where strPackageGroupCode like '%%' or  strDescription like '%%'";
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			this.gridControlMd_PackageGroup.DataSource = _ds.Tables["table"];

		}
		#endregion

		#region subitem
//		private void mdPackageSubItemInit()
//		{
//			mdPackageBranchInit();
//			mdPackageClassInit();
//			mdPackageServiceInit();
//
//		}
//		private void mdPackageBranchInit()
//		{
//			string strSQL;
//
//			strSQL = "select * from tblBranch";
//			createCheckedListBox(mdPKG_lbxBranch,strSQL,"strBranchName");
//
//		}
//		private void mdPackageClassInit()
//		{
//			string strSQL;
//
//			strSQL = "select * from tblClass";
//			createCheckedListBox(mdPKG_lbxClass,strSQL,"strDescription");
//		}
//
//		private void mdPackageServiceInit()
//		{
//			string strSQL;
//
//			strSQL = "select * from tblService";
//			createCheckedListBox(mdPKG_lbxService,strSQL,"strDescription");
//		}

		#endregion

		private void frmPackage_Load(object sender, System.EventArgs e)
		{
			DataSet _ds = new DataSet();
			string strSQL;

			strSQL = "select * from tblcategory where strDescription in ('Fitness Package','Fitness GIRO','PT Package','SPA Package','SPA Single Treatment','IPL Package','Courses & Events','Others','Spa Credit Package','Spa Credit Account','Fitness Combo Package','SPA Combo Package')";
			comboBind(ddlPackageCategory,strSQL,"strDescription","nCategoryID");

			strSQL = "select * from tblcategory where strDescription in ('Fitness Package','Fitness GIRO','PT Package','SPA Package','SPA Single Treatment','IPL Package','Courses & Events','Others','Spa Credit Account')";
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			DataTable dt = _ds.Tables["table"];
			
			DevExpress.XtraEditors.Controls.LookUpColumnInfo[] col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
			
			col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nCategoryID","Category Id",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription","Description",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
		
			new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(this.lk_Category, dt, col, "strDescription", "nCategoryID", "Category");
		
			new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(this.lk_CreditCategoryID, dt, col, "strDescription", "nCategoryID", "Category");

			strSQL = "select * from tblcategory where strDescription in ('Fitness Combo Package','SPA Combo Package')";
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dt = _ds.Tables["table"];
			
			col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
			
			col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nCategoryID","Category Id",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription","Description",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
		
			new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(this.lk_pkGroupCatID,dt,col,"strDescription","nCategoryID","Category");
			
			strSQL = "select strPackageCode, strDescription from TblPackage";
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dt = _ds.Tables["table"];

			col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
			
			col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strPackageCode","Package Code",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription","Description",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
		
			new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(lk_PackageCode,dt,col,"strDescription","strPackageCode","Package Code");
			new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(lk_GrpPackageCode,dt,col,"strDescription","strPackageCode","Package Code");

			LoadPackage();
		}

	
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

		private void AddAll(GridView gvFrom, GridView gvTo, DataTable tableTo)
		{
			gvFrom.BeginDataUpdate();
			gvTo.BeginDataUpdate();
			DataTable dtTemp = (gvFrom.DataSource as DataView).Table;
			dtTemp.RejectChanges();

			for (int i = dtTemp.Rows.Count - 1; i >= 0; i--)
			{
				DataRow rCopy = gvPcGroupBranch.GetDataRow(i);
				DataRow rNew = tableTo.NewRow();
				rNew.BeginEdit();
				rNew["strPackageCode"] = "www";
				rNew["strBranchCode"] = rCopy["strBranchCode"];
				rNew["strBranchName"] = rCopy["strBranchName"];
				rNew.EndEdit();
				dtBranch.Rows.Add(rNew);

				if (dtTemp.Rows[i].RowState != DataRowState.Deleted)
					dtTemp.Rows[i].Delete();
			}
			gvFrom.EndDataUpdate();
			gvTo.EndDataUpdate();
		}

		private void DeleteAll(GridView gvFrom, GridView gvTo, ref DataTable tableTo)
		{
			gvFrom.BeginDataUpdate();
			gvTo.BeginDataUpdate();
			DataTable dtTemp = (gvFrom.DataSource as DataView).Table;
			dtTemp.RejectChanges();

			for (int i = tableTo.Rows.Count - 1; i >= 0; i--)
			{
				if (tableTo.Rows[i].RowState != DataRowState.Deleted)
					tableTo.Rows[i].Delete();
			}
			gvFrom.EndDataUpdate();
			gvTo.EndDataUpdate();
		}

		private void PackageBranchDisplay()
		{
			grpPackage.Show();
			grpPackageGroup.Hide();
			grpCreditPackage.Hide();
			this.grpBranch.Show();
			this.grpPackageClass.Hide();
			this.grpPackageService.Hide();
			PackageGroup.Hide();
			GroupCreditPackage.Hide();
		}


		private void PackageClassDisplay()
		{
			grpPackage.Show();
			grpPackageGroup.Hide();
			grpCreditPackage.Hide();
			this.grpPackageClass.Show();
			this.grpPackageService.Hide();
			this.grpBranch.Hide();
			PackageGroup.Hide();
			GroupCreditPackage.Hide();
		}

		private void PackageServiceDisplay()
		{
			grpPackage.Show();
			grpPackageGroup.Hide();
			grpCreditPackage.Hide();
			this.grpPackageClass.Hide();
			this.grpPackageService.Show();
			this.grpBranch.Hide();
			PackageGroup.Hide();
			GroupCreditPackage.Hide();
		}

		private void PackageGroupDisplay()
		{
			grpPackage.Hide();
			grpPackageGroup.Show();
			grpCreditPackage.Hide();
			this.grpPackageClass.Hide();
			this.grpPackageService.Hide();
			this.grpBranch.Hide();
			PackageGroup.Show();
			GroupCreditPackage.Hide();
		}

		private void PackageCreditDisplay()
		{
			grpPackage.Hide();
			grpPackageGroup.Hide();
			grpCreditPackage.Show();
			this.grpPackageClass.Hide();
			this.grpPackageService.Hide();
			PackageGroup.Hide();
			GroupCreditPackage.Show();
		}

		private void ddlPackageCategory_SelectedIndexChanged(object sender, System.EventArgs e)
		{		
			if (ddlPackageCategory.Text.ToUpper() == "FITNESS PACKAGE")
			{
				LoadPackage();
				PackageClassDisplay();
				BindPackageClass();
			}
			else if (ddlPackageCategory.Text.ToUpper() == "FITNESS GIRO")
			{
				LoadPackage();
				PackageClassDisplay();
				BindPackageClass();

			}
			else if (ddlPackageCategory.Text.ToUpper() == "PT PACKAGE")
			{
				LoadPackage();
				PackageServiceDisplay();
				BindPackageService();

			}
			else if (ddlPackageCategory.Text.ToUpper() == "SPA PACKAGE")
			{
				LoadPackage();
				PackageServiceDisplay();
				BindPackageService();

			}
			else if (ddlPackageCategory.Text.ToUpper()  == "SPA SINGLE TREATMENT")
			{
				LoadPackage();
				PackageServiceDisplay();
				BindPackageService();

			}
			else if (ddlPackageCategory.Text.ToUpper() == "IPL PACKAGE")
			{
				LoadPackage();
				PackageServiceDisplay();
				BindPackageService();

			}
			else if (ddlPackageCategory.Text.ToUpper() == "COURSES & EVENTS")
			{
				LoadPackage();
				PackageBranchDisplay();
				BindPackageBranch();
			}
			else if (ddlPackageCategory.Text.ToUpper() == "OTHERS")
			{
				LoadPackage();
				PackageBranchDisplay();
				BindPackageBranch();
			}
			else if (ddlPackageCategory.Text.ToUpper() == "SPA CREDIT ACCOUNT")
			{
				LoadCreditPackage();
				PackageCreditDisplay();
				LoadCreditPackageRestric();

			}
			else if (ddlPackageCategory.Text.ToUpper() == "FITNESS COMBINED PACKAGE" || ddlPackageCategory.Text.ToUpper() == "FITNESS COMBO PACKAGE")
			{
				LoadPackageGroup();
				PackageGroupDisplay();
				LoadPackageGroupEntries();

			}
			else if (ddlPackageCategory.Text.ToUpper() == "SPA COMBINED PACKAGE" || ddlPackageCategory.Text.ToUpper() == "SPA COMBO PACKAGE")
			{
				LoadPackageGroup();
				PackageGroupDisplay();
				LoadPackageGroupEntries();

			}

		}

		#endregion

	
		#region Package Class
		private DataTable dtBranch;
		private void BindPackageClass()
		{
			DataSet _ds;
			DataRow dr = this.gridViewMd_Package.GetDataRow(this.gridViewMd_Package.FocusedRowHandle);
				
			string strSQL;
			strSQL = "select strBranchCode, strBranchName from TblBranch Where strBranchCode Not In (Select strBranchCode From TblPackageBranch Where strPackageCode = '" + dr["strPackageCode"].ToString() + "')";
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			gridPcGroupBranch.DataSource = _ds.Tables["table"];
				
			strSQL = "select P.strPackageCode, B.strBranchCode, strBranchName from TblPackageBranch P Inner Join TblBranch B On B.strBranchCode = P.strBranchCode Where P.strPackageCode = '" + dr["strPackageCode"].ToString() + "'";
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dtBranch = _ds.Tables["table"];
			gridPcGroupBranch2.DataSource = dtBranch;
					
			strSQL = "select strClassCode, strDescription from tblClass Where strClassCode Not In (Select strClassCode From TblPackageClass Where strPackageCode = '" + dr["strPackageCode"].ToString() + "')";
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			gridPackageClass.DataSource = _ds.Tables["table"];

			strSQL = "select P.strPackageCode, C.strClassCode, strDescription from tblPackageClass P Inner Join TblClass C On C.strClassCode = P.strClassCode Where P.strPackageCode = '" + dr["strPackageCode"].ToString() + "'";
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dtClass = _ds.Tables["table"];
			gridPackageClass2.DataSource = dtClass;
		}
		
		#region Class Branch		
		private void btn_PGB_Add_Click(object sender, System.EventArgs e)
		{
			DataRow dr = this.gridViewMd_Package.GetDataRow(this.gridViewMd_Package.FocusedRowHandle);

			int[] rowsHandle = this.gvPcGroupBranch.GetSelectedRows();
			if (rowsHandle == null || rowsHandle.Length == 0)
			{
				UI.ShowErrorMessage(this, "Please select at least one row.");
				return;
			}
			
			foreach(int index in rowsHandle)
			{
				DataRow rCopy = gvPcGroupBranch.GetDataRow(index);
				DataRow rNew = dtBranch.NewRow();
				rNew.BeginEdit();
				rNew["strPackageCode"] = dr["strPackageCode"];
				rNew["strBranchCode"] = rCopy["strBranchCode"];
				rNew["strBranchName"] = rCopy["strBranchName"];
				rNew.EndEdit();
				dtBranch.Rows.Add(rNew);
			}

			gvPcGroupBranch.DeleteSelectedRows();
						
			try
			{
				string strSQL = "select strPackageCode, strBranchCode from TblPackageBranch Where strPackageCode = '" + dr["strPackageCode"].ToString() + "'";
				CreateCmdsAndUpdate(strSQL,dtBranch);
			}
			catch (Exception)
			{
				return;
			}

		}
	
		private void btn_PGBAll_Add_Click(object sender, System.EventArgs e)
		{
			gvPcGroupBranch.BeginDataUpdate();
			gvPcGroupBranch2.BeginDataUpdate();

			DataRow dr = this.gridViewMd_Package.GetDataRow(this.gridViewMd_Package.FocusedRowHandle);
			DataTable dtTemp = (gvPcGroupBranch.DataSource as DataView).Table;
			//dtTemp.RejectChanges();
			dtTemp.AcceptChanges();

			for (int i = dtTemp.Rows.Count - 1; i >= 0; i--)
			{
				DataRow rCopy = gvPcGroupBranch.GetDataRow(i);
				DataRow rNew = dtBranch.NewRow();
				rNew.BeginEdit();
				rNew["strPackageCode"] = dr["strPackageCode"];
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

			gvPcGroupBranch.EndDataUpdate();
			gvPcGroupBranch2.EndDataUpdate();

			string strSQL = "select strPackageCode, strBranchCode from TblPackageBranch Where strPackageCode = '" + dr["strPackageCode"].ToString() + "'";
			CreateCmdsAndUpdate(strSQL,dtBranch);
	
		}
	
		private void btn_PGBAll_Del_Click(object sender, System.EventArgs e)
		{
			DataRow dr = this.gridViewMd_Package.GetDataRow(this.gridViewMd_Package.FocusedRowHandle);

			gvPcGroupBranch2.BeginDataUpdate();
			gvPcGroupBranch.BeginDataUpdate();
			DataTable dtTemp = (gvPcGroupBranch.DataSource as DataView).Table;

			for (int i = dtBranch.Rows.Count - 1; i >= 0; i--)
			{
				DataRow rCopy = gvPcGroupBranch2.GetDataRow(i);
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

			gvPcGroupBranch2.EndDataUpdate();
			gvPcGroupBranch.EndDataUpdate();

			string strSQL = "select strPackageCode, strBranchCode from TblPackageBranch Where strPackageCode = '" + dr["strPackageCode"].ToString() + "'";
			CreateCmdsAndUpdate(strSQL,dtBranch);
		}

		private void btn_PGB_Del_Click(object sender, System.EventArgs e)
		{
			DataRow dr = this.gridViewMd_Package.GetDataRow(this.gridViewMd_Package.FocusedRowHandle);

			int[] rowsHandle = gvPcGroupBranch2.GetSelectedRows();
			if (rowsHandle == null || rowsHandle.Length == 0)
			{
				UI.ShowErrorMessage(this, "Please select at least one row.");
				return;
			}
			DataTable dtTemp = (gvPcGroupBranch.DataSource as DataView).Table;
			foreach(int index in rowsHandle)
			{
				DataRow rCopy = gvPcGroupBranch2.GetDataRow(index);
				DataRow rNew = dtTemp.NewRow();
				rNew.BeginEdit();
				rNew["strBranchCode"] = rCopy["strBranchCode"];
				rNew["strBranchName"] = rCopy["strBranchName"];
				rNew.EndEdit();
				dtTemp.Rows.Add(rNew);
			}
			gvPcGroupBranch2.DeleteSelectedRows();

			try
			{
				string strSQL = "select strPackageCode, strBranchCode from TblPackageBranch Where strPackageCode = '" + dr["strPackageCode"].ToString() + "'";
				CreateCmdsAndUpdate(strSQL,dtBranch);
			}
			catch (Exception)
			{
				return;
			}
		}
		#endregion

		#region Class 	
		private void btn_PGC_Add_Click(object sender, System.EventArgs e)
		{
			DataRow dr = this.gridViewMd_Package.GetDataRow(this.gridViewMd_Package.FocusedRowHandle);

			int[] rowsHandle = this.gvPackageClass.GetSelectedRows();
			if (rowsHandle == null || rowsHandle.Length == 0)
			{
				UI.ShowErrorMessage(this, "Please select at least one row.");
				return;
			}
			
			foreach(int index in rowsHandle)
			{
				DataRow rCopy = gvPackageClass.GetDataRow(index);
				DataRow rNew = dtClass.NewRow();
				rNew.BeginEdit();
				rNew["strPackageCode"] = dr["strPackageCode"];
				rNew["strClassCode"] = rCopy["strClassCode"];
				rNew["strDescription"] = rCopy["strDescription"];
				rNew.EndEdit();
				dtClass.Rows.Add(rNew);
			}

			gvPackageClass.DeleteSelectedRows();
						
		
			try
			{
				string strSQL = "select strPackageCode, strClassCode from TblPackageClass Where strPackageCode = '" + dr["strPackageCode"].ToString() + "'";
				CreateCmdsAndUpdate(strSQL,dtClass);
			}
			catch (Exception)
			{
				return;
			}
		}

		private void btn_PGCAll_Add_Click(object sender, System.EventArgs e)
		{
			gvPackageClass.BeginDataUpdate();
			gvPackageClass2.BeginDataUpdate();

			DataRow dr = this.gridViewMd_Package.GetDataRow(this.gridViewMd_Package.FocusedRowHandle);

			DataTable dtTemp = (gvPackageClass.DataSource as DataView).Table;
			//dtTemp.RejectChanges();
			dtTemp.AcceptChanges();

			for (int i = dtTemp.Rows.Count - 1; i >= 0; i--)
			{
				DataRow rCopy = gvPackageClass.GetDataRow(i);
				DataRow rNew = dtClass.NewRow();
				rNew.BeginEdit();
				rNew["strPackageCode"] = dr["strPackageCode"];
				rNew["strClassCode"] = rCopy["strClassCode"];
				rNew["strDescription"] = rCopy["strDescription"];
				rNew.EndEdit();
				dtClass.Rows.Add(rNew);
			}

			for (int i = dtTemp.Rows.Count - 1; i >= 0; i--)
			{
				if (dtTemp.Rows[i].RowState != DataRowState.Deleted)
					dtTemp.Rows[i].Delete();
			}

			gvPackageClass.EndDataUpdate();
			gvPackageClass2.EndDataUpdate();


			string strSQL = "select strPackageCode, strClassCode from TblPackageClass Where strPackageCode = '" + dr["strPackageCode"].ToString() + "'";
			CreateCmdsAndUpdate(strSQL,dtClass);
		}

		private void btn_PGCAll_Del_Click(object sender, System.EventArgs e)
		{
			DataRow dr = this.gridViewMd_Package.GetDataRow(this.gridViewMd_Package.FocusedRowHandle);

			gvPackageClass2.BeginDataUpdate();
			gvPackageClass.BeginDataUpdate();
			DataTable dtTemp = (gvPackageClass.DataSource as DataView).Table;

			for (int i = dtClass.Rows.Count - 1; i >= 0; i--)
			{
				DataRow rCopy = gvPackageClass2.GetDataRow(i);
				DataRow rNew = dtTemp.NewRow();
				rNew.BeginEdit();
				rNew["strClassCode"] = rCopy["strClassCode"];
				rNew["strDescription"] = rCopy["strDescription"];
				rNew.EndEdit();
				dtTemp.Rows.Add(rNew);
			}

			for (int i = dtClass.Rows.Count - 1; i >= 0; i--)
			{
				if (dtClass.Rows[i].RowState != DataRowState.Deleted)
					dtClass.Rows[i].Delete();
			}

			gvPackageClass2.EndDataUpdate();
			gvPackageClass.EndDataUpdate();

			string strSQL = "select strPackageCode, strClassCode from TblPackageClass Where strPackageCode = '" + dr["strPackageCode"].ToString() + "'";
			CreateCmdsAndUpdate(strSQL,dtClass);
		}

		

		private void btn_PGC_Del_Click(object sender, System.EventArgs e)
		{
			DataRow dr = this.gridViewMd_Package.GetDataRow(this.gridViewMd_Package.FocusedRowHandle);

			int[] rowsHandle = gvPackageClass2.GetSelectedRows();
			if (rowsHandle == null || rowsHandle.Length == 0)
			{
				UI.ShowErrorMessage(this, "Please select at least one row.");
				return;
			}

			DataTable dtTemp = (gvPackageClass.DataSource as DataView).Table;
			foreach(int index in rowsHandle)
			{
				DataRow rCopy = gvPackageClass2.GetDataRow(index);
				DataRow rNew = dtTemp.NewRow();
				rNew.BeginEdit();
				rNew["strClassCode"] = rCopy["strClassCode"];
				rNew["strDescription"] = rCopy["strDescription"];
				rNew.EndEdit();
				dtTemp.Rows.Add(rNew);
			}
		
			gvPackageClass2.DeleteSelectedRows();
			try
			{
				string strSQL = "select strPackageCode, strClassCode from TblPackageClass Where strPackageCode = '" + dr["strPackageCode"].ToString() + "'";
				CreateCmdsAndUpdate(strSQL,dtClass);
			
			}
			catch (Exception)
			{
				return;
			}
		}
		#endregion

		#endregion

		#region region Package
		private void LoadPackage()
		{
			//MessageBox.Show(Convert.ToDateTime(string.Format("#01/{0}/{1}#",DateTime.Now.Month,DateTime.Now.Year)).ToString("dd/MM/yyyy"));
						
			string strSQL;
			strSQL = "select * from tblPackage where ( strPackageCode like '%" + txtSearch.Text + "%' or  strDescription like '%" + txtSearch.Text + "%')";
			if (ddlPackageCategory.EditValue.ToString() != "")
			{
				strSQL += " and tblPackage.nCategoryID = '" +  ddlPackageCategory.EditValue + "'";
			}

			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dtPackage = _ds.Tables["table"];
			this.gridControlMd_Package.DataSource = dtPackage;

		}

		private bool FieldCheckingPackage(DataRow dr)
		{
			if ( dr["strPackageCode"].ToString() == "" )
				return false;
	
			if ( dr["nCategoryID"].ToString() == "" )
				return false;
		
			return true;
		}

		private void gridViewMd_Package_LostFocus(object sender, System.EventArgs e)
		{
			DataRow row = this.gridViewMd_Package.GetDataRow(gridViewMd_Package.FocusedRowHandle);
			
			string strSQL = "Select * from tblPackage";
			if (AddNewPackage)
			{
				if( FieldCheckingPackage(row))
				{
					this.gridControlMd_Package.MainView.UpdateCurrentRow();
					try
					{
						CreateCmdsAndUpdate(strSQL,dtPackage);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message ,"Insert Failed");
						dtPackage.RejectChanges();
						return;
					}
					AddNewPackage = false;
				}
			}
			else
			{
				gridViewMd_Package.CloseEditor();
				gridViewMd_Package.UpdateCurrentRow();

				CreateCmdsAndUpdate(strSQL,dtPackage);
			}
		}

		private void gridViewMd_Package_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
			if (ddlPackageCategory.Text.ToUpper() == "FITNESS PACKAGE")
			{
				BindPackageClass();
			}
			else if (ddlPackageCategory.Text.ToUpper() == "FITNESS GIRO")
			{
				BindPackageClass();
			}
			else if (ddlPackageCategory.Text.ToUpper() == "PT PACKAGE")
			{
				BindPackageService();
			}
			else if (ddlPackageCategory.Text.ToUpper() == "SPA PACKAGE")
			{
				BindPackageService();
			}
			else if (ddlPackageCategory.Text.ToUpper()  == "SPA SINGLE TREATMENT")
			{
				BindPackageService();
			}
			else if (ddlPackageCategory.Text.ToUpper() == "IPL PACKAGE")
			{
				BindPackageService();
			}
			else if (ddlPackageCategory.Text.ToUpper() == "COURSES & EVENTS")
			{
				BindPackageBranch();
			}
			else if (ddlPackageCategory.Text.ToUpper() == "OTHERS")
			{
				BindPackageBranch();
			}
		}

		private bool AddNewPackage = false;
		private void btn_PackageAdd_Click(object sender, System.EventArgs e)
		{
			AddNewPackage = true;
			DataRow dr = dtPackage.NewRow();
			dr["nCategoryID"] = ddlPackageCategory.EditValue;
			dtPackage.Rows.Add(dr);
			this.gridControlMd_Package.Refresh();
			this.gridViewMd_Package.FocusedRowHandle = dtPackage.Rows.Count - 1;
		}

		private void btn_PackageDel_Click(object sender, System.EventArgs e)
		{
			DataRow row = this.gridViewMd_Package.GetDataRow(gridViewMd_Package.FocusedRowHandle);
			if (row != null)
			{
				
				if (AddNewPackage)
				{
					AddNewPackage = false;
					gridViewMd_Package.DeleteRow(gridViewMd_Package.FocusedRowHandle);
				}
				else
				{
					int output;
					output = 0;

					DialogResult result = MessageBox.Show(this, "Do you really want to delete record with Branch Code = '" + row["strPackageCode"].ToString() + "'",
						"Delete?", MessageBoxButtons.YesNo);
					if (result == DialogResult.Yes)
					{
						try
						{
							SqlHelper.ExecuteNonQuery(connection,"del_tblPackage",
								new SqlParameter("@retval",output),
								new SqlParameter("@strPackageCode",row["strPackageCode"].ToString()));
						}
						catch(Exception ex)
						{
							dtPackage.RejectChanges();
							MessageBox.Show(ex.Message ,"Delete Process Failed");
							return;
						}
						MessageBox.Show("Record Deleted Successfully","Message");
						LoadPackage();
					}

				}
				
			}
		}

		#endregion

		#region Package Group
		private void gridViewMd_GroupEntries_LostFocus(object sender, System.EventArgs e)
		{
			DataRow row = this.gridViewMd_GroupEntries.GetDataRow(gridViewMd_GroupEntries.FocusedRowHandle);
			
			string strSQL = "Select * from tblPackageGroupEntries Where strPackageGroupCode = '" + row["strPackageGroupCode"].ToString() + "'";
			if (AddNewGroupEntries)
			{
				if( FieldCheckingPackageEntries(row))
				{
					this.gridControlMd_GroupEntries.MainView.UpdateCurrentRow();
					try
					{
						CreateCmdsAndUpdate(strSQL,dtPackageGroupEntries);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message ,"Insert Failed");
						dtPackageGroupEntries.RejectChanges();
						return;
					}
					AddNewGroupEntries = false;
				}
			}
			else
			{
				this.gridViewMd_GroupEntries.CloseEditor();
				gridViewMd_GroupEntries.UpdateCurrentRow();

				CreateCmdsAndUpdate(strSQL,dtPackageGroupEntries);
			}
		}
		
		private bool AddNewGroupEntries = false;
		private void btn_PacGroup_Add_Click(object sender, System.EventArgs e)
		{
			DataRow row = this.gridViewMd_PackageGroup.GetDataRow(gridViewMd_PackageGroup.FocusedRowHandle);
			AddNewGroupEntries = true;
			DataRow dr = dtPackageGroupEntries.NewRow();
			dr["strPackageGroupCode"] = row["strPackageGroupCode"];
			dtPackageGroupEntries.Rows.Add(dr);
			this.gridControlMd_GroupEntries.Refresh();
			this.gridViewMd_GroupEntries.FocusedRowHandle = dtPackageGroupEntries.Rows.Count - 1;
		}

		private void btn_PacGroup_Del_Click(object sender, System.EventArgs e)
		{
			DataRow row = this.gridViewMd_GroupEntries.GetDataRow(gridViewMd_GroupEntries.FocusedRowHandle);
			if (row != null)
			{
				
				if (AddNewGroupEntries)
				{
					AddNewGroupEntries = false;
					gridViewMd_GroupEntries.DeleteRow(gridViewMd_GroupEntries.FocusedRowHandle);
				}
				else
				{

					DialogResult result = MessageBox.Show(this, "Do you really want to delete record with Package Group Code = " + row["strPackageGroupCode"].ToString() + " and Package Code = " + row["strPackageCode"].ToString(),
						"Delete?", MessageBoxButtons.YesNo);
					if (result == DialogResult.Yes)
					{
						try
						{
							SqlHelper.ExecuteNonQuery(connection,"del_tblPackageGroupEntries",
								new SqlParameter("@strPackageCode",row["strPackageCode"].ToString()),
								new SqlParameter("@strPackageGroupCode",row["strPackageGroupCode"].ToString()));
						}
						catch(Exception ex)
						{
							dtPackageGroupEntries.RejectChanges();
							MessageBox.Show(ex.Message ,"Delete Process Failed");
							return;
						}
						MessageBox.Show("Record Deleted Successfully","Message");
						LoadPackageGroupEntries();
					}

				}
				
			}
		}

		private bool FieldCheckingPackageEntries(DataRow dr)
		{
			if (dr["strPackageGroupCode"] == null || dr["strPackageGroupCode"].ToString() == "")
				return false;
		
			if (dr["strPackageCode"] == null || dr["strPackageCode"].ToString() == "")
				return false;

			return true;
		}

		#endregion

	
		#region Service 
		private DataTable dtService;

		private void BindPackageService()
		{
			DataSet _ds;
			DataRow dr = this.gridViewMd_Package.GetDataRow(this.gridViewMd_Package.FocusedRowHandle);
				
			string strSQL;
			strSQL = "select strBranchCode, strBranchName from TblBranch Where strBranchCode Not In (Select strBranchCode From TblPackageBranch Where strPackageCode = '" + dr["strPackageCode"].ToString() + "')";
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			this.gridPackageBranch.DataSource = _ds.Tables["table"];
				
			strSQL = "select P.strPackageCode, B.strBranchCode, strBranchName from TblPackageBranch P Inner Join TblBranch B On B.strBranchCode = P.strBranchCode Where P.strPackageCode = '" + dr["strPackageCode"].ToString() + "'";
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dtBranch = _ds.Tables["table"];
			gridPackageBranch2.DataSource = dtBranch;
					
			strSQL = "select strServiceCode, strDescription from TblService Where strServiceCode Not In (Select strServiceCode From TblPackageService Where strPackageCode = '" + dr["strPackageCode"].ToString() + "')";
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			this.gridPackageService.DataSource = _ds.Tables["table"];

			strSQL = "select P.strPackageCode, S.strServiceCode, strDescription from tblPackageService P Inner Join TblService S On S.strServiceCode = P.strServiceCode Where P.strPackageCode = '" + dr["strPackageCode"].ToString() + "'";
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dtService = _ds.Tables["table"];
			gridPackageService2.DataSource = dtService;
		}

		private void btn_PB_Add_Click(object sender, System.EventArgs e)
		{
			DataRow dr = this.gridViewMd_Package.GetDataRow(this.gridViewMd_Package.FocusedRowHandle);

			int[] rowsHandle = this.gvPSBranch.GetSelectedRows();
			if (rowsHandle == null || rowsHandle.Length == 0)
			{
				UI.ShowErrorMessage(this, "Please select at least one row.");
				return;
			}
			
			foreach(int index in rowsHandle)
			{
				DataRow rCopy = gvPSBranch.GetDataRow(index);
				DataRow rNew = dtBranch.NewRow();
				rNew.BeginEdit();
				rNew["strPackageCode"] = dr["strPackageCode"];
				rNew["strBranchCode"] = rCopy["strBranchCode"];
				rNew["strBranchName"] = rCopy["strBranchName"];
				rNew.EndEdit();
				dtBranch.Rows.Add(rNew);
			}

			gvPSBranch.DeleteSelectedRows();
						
			try
			{
				string strSQL = "select strPackageCode, strBranchCode from TblPackageBranch Where strPackageCode = '" + dr["strPackageCode"].ToString() + "'";
				CreateCmdsAndUpdate(strSQL,dtBranch);
			}
			catch (Exception )
			{
				return;
			}
		}

		private void btn_PBAll_Add_Click(object sender, System.EventArgs e)
		{
			gvPcGroupBranch.BeginDataUpdate();
			gvPcGroupBranch2.BeginDataUpdate();

			DataRow dr = this.gridViewMd_Package.GetDataRow(this.gridViewMd_Package.FocusedRowHandle);
			DataTable dtTemp = (gvPSBranch.DataSource as DataView).Table;
			//dtTemp.RejectChanges();
			dtTemp.AcceptChanges();

			for (int i = dtTemp.Rows.Count - 1; i >= 0; i--)
			{
				DataRow rCopy = gvPSBranch.GetDataRow(i);
				DataRow rNew = dtBranch.NewRow();
				rNew.BeginEdit();
				rNew["strPackageCode"] = dr["strPackageCode"];
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

			gvPSBranch.EndDataUpdate();
			gvPSBranch2.EndDataUpdate();

			string strSQL = "select strPackageCode, strBranchCode from TblPackageBranch Where strPackageCode = '" + dr["strPackageCode"].ToString() + "'";
			CreateCmdsAndUpdate(strSQL,dtBranch);
		
		}

		private void btn_PBAll_Del_Click(object sender, System.EventArgs e)
		{
			DataRow dr = this.gridViewMd_Package.GetDataRow(this.gridViewMd_Package.FocusedRowHandle);

			gvPSBranch2.BeginDataUpdate();
			gvPSBranch.BeginDataUpdate();
			DataTable dtTemp = (gvPSBranch.DataSource as DataView).Table;

			for (int i = dtBranch.Rows.Count - 1; i >= 0; i--)
			{
				DataRow rCopy = gvPSBranch2.GetDataRow(i);
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

			gvPSBranch2.EndDataUpdate();
			gvPSBranch.EndDataUpdate();

			string strSQL = "select strPackageCode, strBranchCode from TblPackageBranch Where strPackageCode = '" + dr["strPackageCode"].ToString() + "'";
			CreateCmdsAndUpdate(strSQL,dtBranch);
		}

		private void btn_PB_Del_Click(object sender, System.EventArgs e)
		{
			DataRow dr = this.gridViewMd_Package.GetDataRow(this.gridViewMd_Package.FocusedRowHandle);

			int[] rowsHandle = gvPSBranch2.GetSelectedRows();
			if (rowsHandle == null || rowsHandle.Length == 0)
			{
				UI.ShowErrorMessage(this, "Please select at least one row.");
				return;
			}
			DataTable dtTemp = (gvPSBranch.DataSource as DataView).Table;
			foreach(int index in rowsHandle)
			{
				DataRow rCopy = gvPSBranch2.GetDataRow(index);
				DataRow rNew = dtTemp.NewRow();
				rNew.BeginEdit();
				rNew["strBranchCode"] = rCopy["strBranchCode"];
				rNew["strBranchName"] = rCopy["strBranchName"];
				rNew.EndEdit();
				dtTemp.Rows.Add(rNew);
			}
			gvPSBranch2.DeleteSelectedRows();

			try
			{
				string strSQL = "select strPackageCode, strBranchCode from TblPackageBranch Where strPackageCode = '" + dr["strPackageCode"].ToString() + "'";
				CreateCmdsAndUpdate(strSQL,dtBranch);
			}
			catch (Exception)
			{
				return;
			}
		}

		private void btn_PS_Add_Click(object sender, System.EventArgs e)
		{
			DataRow dr = this.gridViewMd_Package.GetDataRow(this.gridViewMd_Package.FocusedRowHandle);

			int[] rowsHandle = this.gvPackageService.GetSelectedRows();
			if (rowsHandle == null || rowsHandle.Length == 0)
			{
				UI.ShowErrorMessage(this, "Please select at least one row.");
				return;
			}
			
			foreach(int index in rowsHandle)
			{
				DataRow rCopy = gvPackageService.GetDataRow(index);
				DataRow rNew = dtService.NewRow();
				rNew.BeginEdit();
				rNew["strPackageCode"] = dr["strPackageCode"];
				rNew["strServiceCode"] = rCopy["strServiceCode"];
				rNew["strDescription"] = rCopy["strDescription"];
				rNew.EndEdit();
				dtService.Rows.Add(rNew);
			}

			gvPackageService.DeleteSelectedRows();
						
		
			try
			{
				string strSQL = "select strPackageCode, strServiceCode from TblPackageService Where strPackageCode = '" + dr["strPackageCode"].ToString() + "'";
				CreateCmdsAndUpdate(strSQL,dtService);
			}
			catch (Exception)
			{
				return;
			}
		}

		private void btn_PSAdd_Add_Click(object sender, System.EventArgs e)
		{
			gvPackageService.BeginDataUpdate();
			gvPackageService2.BeginDataUpdate();

			DataRow dr = this.gridViewMd_Package.GetDataRow(this.gridViewMd_Package.FocusedRowHandle);

			DataTable dtTemp = (this.gvPackageService.DataSource as DataView).Table;
			//dtTemp.RejectChanges();
			dtTemp.AcceptChanges();

			for (int i = dtTemp.Rows.Count - 1; i >= 0; i--)
			{
				DataRow rCopy = gvPackageService.GetDataRow(i);
				DataRow rNew = dtService.NewRow();
				rNew.BeginEdit();
				rNew["strPackageCode"] = dr["strPackageCode"];
				rNew["strServiceCode"] = rCopy["strServiceCode"];
				rNew["strDescription"] = rCopy["strDescription"];
				rNew.EndEdit();
				dtService.Rows.Add(rNew);
			}

			for (int i = dtTemp.Rows.Count - 1; i >= 0; i--)
			{
				if (dtTemp.Rows[i].RowState != DataRowState.Deleted)
					dtTemp.Rows[i].Delete();
			}

			gvPackageService.EndDataUpdate();
			gvPackageService2.EndDataUpdate();

			string strSQL = "select strPackageCode, strServiceCode from TblPackageService Where strPackageCode = '" + dr["strPackageCode"].ToString() + "'";
			CreateCmdsAndUpdate(strSQL,dtService);
		}

		private void btn_PS_Del_Click(object sender, System.EventArgs e)
		{
		DataRow dr = this.gridViewMd_Package.GetDataRow(this.gridViewMd_Package.FocusedRowHandle);

			this.gvPackageService2.BeginDataUpdate();
			gvPackageService.BeginDataUpdate();
			DataTable dtTemp = (this.gvPackageService.DataSource as DataView).Table;

			for (int i = dtService.Rows.Count - 1; i >= 0; i--)
			{
				DataRow rCopy = gvPackageService2.GetDataRow(i);
				DataRow rNew = dtTemp.NewRow();
				rNew.BeginEdit();
				rNew["strServiceCode"] = rCopy["strServiceCode"];
				rNew["strDescription"] = rCopy["strDescription"];
				rNew.EndEdit();
				dtTemp.Rows.Add(rNew);
			}

			for (int i = dtService.Rows.Count - 1; i >= 0; i--)
			{
				if (dtService.Rows[i].RowState != DataRowState.Deleted)
					dtService.Rows[i].Delete();
			}

			gvPackageService2.EndDataUpdate();
			gvPackageService.EndDataUpdate();

			string strSQL = "select strPackageCode, strServiceCode from TblPackageService Where strPackageCode = '" + dr["strPackageCode"].ToString() + "'";
			CreateCmdsAndUpdate(strSQL,dtService);
		}

		private void btn_PSAll_Del_Click(object sender, System.EventArgs e)
		{
			DataRow dr = this.gridViewMd_Package.GetDataRow(this.gridViewMd_Package.FocusedRowHandle);

			int[] rowsHandle = gvPackageService2.GetSelectedRows();
			if (rowsHandle == null || rowsHandle.Length == 0)
			{
				UI.ShowErrorMessage(this, "Please select at least one row.");
				return;
			}

			DataTable dtTemp = (gvPackageService.DataSource as DataView).Table;
			foreach(int index in rowsHandle)
			{
				DataRow rCopy = gvPackageService2.GetDataRow(index);
				DataRow rNew = dtTemp.NewRow();
				rNew.BeginEdit();
				rNew["strServiceCode"] = rCopy["strServiceCode"];
				rNew["strDescription"] = rCopy["strDescription"];
				rNew.EndEdit();
				dtTemp.Rows.Add(rNew);
			}
		
			gvPackageService2.DeleteSelectedRows();
			try
			{
				string strSQL = "select strPackageCode, strServiceCode from TblPackageService Where strPackageCode = '" + dr["strPackageCode"].ToString() + "'";
				CreateCmdsAndUpdate(strSQL,dtService);
			
			}
			catch (Exception)
			{
				return;
			}
		}
		#endregion

		#region Credit Package		
		private void gridViewMd_CreditPackage_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
			LoadCreditPackageRestric();
		}

		private bool FieldCheckingPackageCredit(DataRow dr)
		{
			if (dr["strCreditPackageCode"].ToString() == "")
				return false;

			if (dr["nCategoryID"].ToString() == "")
				return false;

			return true;
		}

		private bool FieldCheckingCreditRestric(DataRow dr)
		{
			if (dr["strCreditPackageCode"].ToString() == "")
				return false;

			if (dr["strPackageCode"].ToString() == "")
				return false;

			return true;
		}

		private void gridViewMd_CreditPackage_LostFocus(object sender, System.EventArgs e)
		{
			DataRow row = this.gridViewMd_CreditPackage.GetDataRow(gridViewMd_CreditPackage.FocusedRowHandle);
			
			string strSQL = "Select * from TblCreditPackage Where strCreditPackageCode = '" + row["strCreditPackageCode"].ToString() + "'";
			if (AddNewCredit)
			{
				if( FieldCheckingPackageCredit(row))
				{
					this.gridControlMd_CreditPackage.MainView.UpdateCurrentRow();
					try
					{
						CreateCmdsAndUpdate(strSQL,dtPackageCredit);
					}
					catch (Exception ex)
					{
                        MessageBox.Show(ex.Message ,"Insert Failed");
						dtPackageCredit.RejectChanges();
						return;
					}
					AddNewCredit = false;
				}
			}
			else
			{
				this.gridViewMd_CreditPackage.CloseEditor();
				gridViewMd_CreditPackage.UpdateCurrentRow();

				CreateCmdsAndUpdate(strSQL,dtPackageCredit);
			}
		}

		private void btnCreditPackage_Del_Click(object sender, System.EventArgs e)
		{
				DataRow row = this.gridViewMd_CreditPackage.GetDataRow(gridViewMd_CreditPackage.FocusedRowHandle);

				if (AddNewCredit)
				{
					AddNewCredit = false;
					this.gridViewMd_CreditPackage.DeleteRow(gridViewMd_CreditPackage.FocusedRowHandle);
				}
				else
				{
					int output;
					output = 0;

					DialogResult result = MessageBox.Show(this, "Do you really want to delete record with Package Code = " + row["strCreditPackageCode"].ToString(),
						"Delete?", MessageBoxButtons.YesNo);
					if (result == DialogResult.Yes)
					{
						try
						{
							SqlHelper.ExecuteNonQuery(connection, "del_CreditPackage",
								new SqlParameter("@retval", output),
								new SqlParameter("@strCreditPackageCode", row["strCreditPackageCode"].ToString()));
						}
						catch(Exception ex)
						{
							this.dtPackageCredit.RejectChanges();
							MessageBox.Show(ex.Message ,"Delete Process Failed");
							return;
						}
						MessageBox.Show("Record Deleted Successfully","Message");
						LoadCreditPackage();
					}

				}
				
		
		}
		private bool AddNewCredit = false;
		private void btnCreditPackage_Add_Click(object sender, System.EventArgs e)
		{
			AddNewCredit = true;
			DataRow dr = dtPackageCredit.NewRow();
			dr["nCategoryID"] = ddlPackageCategory.EditValue;
			dtPackageCredit.Rows.Add(dr);
			this.gridControlMd_CreditPackage.Refresh();
			this.gridViewMd_CreditPackage.FocusedRowHandle = dtPackageCredit.Rows.Count - 1;
		}

		#region Credit Group
		private bool AddNewCreditRestric = false;

		private void btn_CreGroup_Add_Click(object sender, System.EventArgs e)
		{
			DataRow row = this.gridViewMd_CreditPackage.GetDataRow(gridViewMd_CreditPackage.FocusedRowHandle);
			AddNewCreditRestric = true;
			DataRow dr = dtPackageCreditRestric.NewRow();
			dr["strCreditPackageCode"] = row["strCreditPackageCode"];
			dtPackageCreditRestric.Rows.Add(dr);
			this.GridCreditRestric.Refresh();
			this.gridViewmd_CreditRestric.FocusedRowHandle = dtPackageCreditRestric.Rows.Count - 1;
		}

		private void btn_CreGroup_Del_Click(object sender, System.EventArgs e)
		{
			DataRow row = this.gridViewmd_CreditRestric.GetDataRow(gridViewmd_CreditRestric.FocusedRowHandle);
			if (row != null)
			{
				
				if (AddNewCreditRestric)
				{
					AddNewCreditRestric = false;
					gridViewmd_CreditRestric.DeleteRow(gridViewmd_CreditRestric.FocusedRowHandle);
				}
				else
				{
					DialogResult result = MessageBox.Show(this, "Do you really want to delete record with Credit Package Code = " + row["strCreditPackageCode"].ToString() + " and Package Code = " + row["strPackageCode"].ToString(),
						"Delete?", MessageBoxButtons.YesNo);
					if (result == DialogResult.Yes)
					{
						try
						{
							SqlHelper.ExecuteNonQuery(connection,"del_CreditPackageRestric",
								new SqlParameter("@strPackageCode",row["strPackageCode"].ToString()),
								new SqlParameter("@strCreditPackageCode",row["strCreditPackageCode"].ToString()));
						}
						catch(Exception ex)
						{
							MessageBox.Show(ex.Message ,"Delete Process Failed");
							dtPackageCreditRestric.RejectChanges();
							return;
						}
						MessageBox.Show("Record Deleted Successfully","Message");
						LoadCreditPackageRestric();
					}

				}
				
			}
		}

		private void gridViewmd_CreditRestric_LostFocus(object sender, System.EventArgs e)
		{
			DataRow row = this.gridViewMd_CreditPackage.GetDataRow(gridViewMd_CreditPackage.FocusedRowHandle);
			DataRow row2 = this.gridViewmd_CreditRestric.GetDataRow(gridViewmd_CreditRestric.FocusedRowHandle);

			string strSQL = "Select * from TblCreditPackageRestriction Where strCreditPackageCode = '" + row["strCreditPackageCode"].ToString() + "'";
			if (AddNewCreditRestric)
			{
				if( FieldCheckingCreditRestric(row2))
				{
					this.GridCreditRestric.MainView.UpdateCurrentRow();
					try
					{
						CreateCmdsAndUpdate(strSQL,dtPackageCreditRestric);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message ,"Insert Failed");
						dtPackageCreditRestric.RejectChanges();
						return;
					}
					AddNewCreditRestric = false;
				}
			}
			else
			{
				this.gridViewmd_CreditRestric.CloseEditor();
				gridViewmd_CreditRestric.UpdateCurrentRow();

				CreateCmdsAndUpdate(strSQL,dtPackageCreditRestric);
			}
		}

		#endregion

		

		#endregion


		#region Package Branch
		private DataTable dtPacBranch;
		private void BindPackageBranch()
		{
			DataSet _ds;
			DataRow dr = this.gridViewMd_Package.GetDataRow(this.gridViewMd_Package.FocusedRowHandle);
			
			if (dr == null)
				return;

			string strSQL;
			strSQL = "select strBranchCode, strBranchName from TblBranch Where strBranchCode Not In (Select strBranchCode From TblPackageBranch Where strPackageCode = '" + dr["strPackageCode"].ToString() + "')";
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			this.gridPacBranch.DataSource = _ds.Tables["table"];
				
			strSQL = "select P.strPackageCode, B.strBranchCode, strBranchName from TblPackageBranch P Inner Join TblBranch B On B.strBranchCode = P.strBranchCode Where P.strPackageCode = '" + dr["strPackageCode"].ToString() + "'";
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dtPacBranch = _ds.Tables["table"];
			gridPacBranch2.DataSource = dtPacBranch;
		}

		private void btnPacBranch_Add_Click(object sender, System.EventArgs e)
		{
			DataRow dr = this.gridViewMd_Package.GetDataRow(this.gridViewMd_Package.FocusedRowHandle);

			int[] rowsHandle = this.gvPacBranch.GetSelectedRows();
			if (rowsHandle == null || rowsHandle.Length == 0)
			{
				UI.ShowErrorMessage(this, "Please select at least one row.");
				return;
			}
			
			foreach(int index in rowsHandle)
			{
				DataRow rCopy = gvPacBranch.GetDataRow(index);
				DataRow rNew = dtPacBranch.NewRow();
				rNew.BeginEdit();
				rNew["strPackageCode"] = dr["strPackageCode"];
				rNew["strBranchCode"] = rCopy["strBranchCode"];
				rNew["strBranchName"] = rCopy["strBranchName"];
				rNew.EndEdit();
				dtPacBranch.Rows.Add(rNew);
			}

			gvPacBranch.DeleteSelectedRows();
						
			try
			{
				string strSQL = "select strPackageCode, strBranchCode from TblPackageBranch Where strPackageCode = '" + dr["strPackageCode"].ToString() + "'";
				CreateCmdsAndUpdate(strSQL,dtPacBranch);
			}
			catch (Exception)
			{
				return;
			}
		}

		private void btnPacBranch_AddAll_Click(object sender, System.EventArgs e)
		{
			gvPacBranch.BeginDataUpdate();
			gvPacBranch2.BeginDataUpdate();

			DataRow dr = this.gridViewMd_Package.GetDataRow(this.gridViewMd_Package.FocusedRowHandle);
			DataTable dtTemp = (gvPacBranch.DataSource as DataView).Table;
			//dtTemp.RejectChanges();
			dtTemp.AcceptChanges();

			for (int i = dtTemp.Rows.Count - 1; i >= 0; i--)
			{
				DataRow rCopy = gvPacBranch.GetDataRow(i);
				DataRow rNew = dtPacBranch.NewRow();
				rNew.BeginEdit();
				rNew["strPackageCode"] = dr["strPackageCode"];
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

			string strSQL = "select strPackageCode, strBranchCode from TblPackageBranch Where strPackageCode = '" + dr["strPackageCode"].ToString() + "'";
			CreateCmdsAndUpdate(strSQL,dtPacBranch);
		}

		private void btnPacBranch_DelAll_Click(object sender, System.EventArgs e)
		{
			DataRow dr = this.gridViewMd_Package.GetDataRow(this.gridViewMd_Package.FocusedRowHandle);

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

			for (int i = dtBranch.Rows.Count - 1; i >= 0; i--)
			{
				if (dtPacBranch.Rows[i].RowState != DataRowState.Deleted)
					dtPacBranch.Rows[i].Delete();
			}

			gvPacBranch2.EndDataUpdate();
			gvPacBranch.EndDataUpdate();

			string strSQL = "select strPackageCode, strBranchCode from TblPackageBranch Where strPackageCode = '" + dr["strPackageCode"].ToString() + "'";
			CreateCmdsAndUpdate(strSQL,dtPacBranch);
		}

		private void btnPacBranch_Del_Click(object sender, System.EventArgs e)
		{
			DataRow dr = this.gridViewMd_Package.GetDataRow(this.gridViewMd_Package.FocusedRowHandle);

			int[] rowsHandle = gvPacBranch2.GetSelectedRows();
			if (rowsHandle == null || rowsHandle.Length == 0)
			{
				UI.ShowErrorMessage(this, "Please select at least one row.");
				return;
			}
			DataTable dtTemp = (gvPacBranch.DataSource as DataView).Table;
			foreach(int index in rowsHandle)
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
				string strSQL = "select strPackageCode, strBranchCode from TblPackageBranch Where strPackageCode = '" + dr["strPackageCode"].ToString() + "'";
				CreateCmdsAndUpdate(strSQL,dtPacBranch);
			}
			catch (Exception)
			{
				return;
			}
		}
	#endregion

		#region Package Group
		private bool AddNewPackageGrp = false;
		private void btnPacGroup_Add_Click(object sender, System.EventArgs e)
		{
			AddNewPackageGrp = true;
			DataRow dr = dtPackageGroup.NewRow();
			dr["nCategoryID"] = ddlPackageCategory.EditValue;
			dtPackageGroup.Rows.Add(dr);
			this.gridControlMd_PackageGroup.Refresh();
			this.gridViewMd_PackageGroup.FocusedRowHandle = dtPackageGroup.Rows.Count - 1;
		}

		private void btnPacGroup_Del_Click(object sender, System.EventArgs e)
		{
			DataRow row = this.gridViewMd_PackageGroup.GetDataRow(gridViewMd_PackageGroup.FocusedRowHandle);
			if (row != null)
			{
				
				if (AddNewPackageGrp)
				{
					AddNewPackageGrp = false;
					gridViewMd_PackageGroup.DeleteRow(gridViewMd_PackageGroup.FocusedRowHandle);
				}
				else
				{
					int output;
					output = 0;

					DialogResult result = MessageBox.Show(this, "Do you really want to delete record with Package Group Code = '" + row["strPackageGroupCode"].ToString() + "'",
						"Delete?", MessageBoxButtons.YesNo);
					if (result == DialogResult.Yes)
					{
						try
						{
							SqlHelper.ExecuteNonQuery(connection,"del_tblPackageGroup",
								new SqlParameter("@retval",output),
								new SqlParameter("@strPackageGroupCode",row["strPackageGroupCode"].ToString()));
						}
						catch(Exception ex)
						{
							dtPackageGroup.RejectChanges();
							MessageBox.Show(ex.Message ,"Delete Process Failed");
							return;
						}
						MessageBox.Show("Record Deleted Successfully","Message");
						LoadPackageGroup();
					}

				}
				
			}
		}

		private void gridViewMd_PackageGroup_LostFocus(object sender, System.EventArgs e)
		{
			DataRow row = this.gridViewMd_PackageGroup.GetDataRow(gridViewMd_PackageGroup.FocusedRowHandle);
			
			string strSQL = "Select * from tblPackageGroup";
			if (AddNewPackageGrp)
			{
				if( FieldCheckingPackageGrp(row))
				{
					this.gridControlMd_PackageGroup.MainView.UpdateCurrentRow();
					try
					{
						CreateCmdsAndUpdate(strSQL,dtPackageGroup);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message ,"Insert Failed");
						dtPackageGroup.RejectChanges();
						return;
					}
					AddNewPackageGrp = false;
				}
			}
			else
			{
				gridViewMd_PackageGroup.CloseEditor();
				gridViewMd_PackageGroup.UpdateCurrentRow();

				CreateCmdsAndUpdate(strSQL,dtPackageGroup);
			}
		}

		private void gridViewMd_PackageGroup_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
			LoadPackageGroupEntries();
		}

		private void LoadPackageGroupEntries()
		{
			gridControlMd_GroupEntries.DataSource = null;

			string strSQL;
			DataRow dr = this.gridViewMd_PackageGroup.GetDataRow(this.gridViewMd_PackageGroup.FocusedRowHandle);
			
			if (dr != null)
			{
				strSQL = "select * from tblPackageGroupEntries Where strPackageGroupCode = '" + dr["strPackageGroupCode"].ToString() + "'";

				DataSet _ds = new DataSet();
				SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
				dtPackageGroupEntries = _ds.Tables["table"];

				gridControlMd_GroupEntries.DataSource = dtPackageGroupEntries;
			}
		}

		private bool FieldCheckingPackageGrp(DataRow dr)
		{
			if (dr["strPackageGroupCode"] == null || dr["strPackageGroupCode"].ToString() == "")
				return false;

			return true;
		}

		#endregion

		private void btn_Search_Click(object sender, System.EventArgs e)
		{
			ddlPackageCategory_SelectedIndexChanged(sender, e);
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
