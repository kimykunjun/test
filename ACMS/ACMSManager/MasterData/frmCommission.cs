using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;
using Do = Acms.Core.Domain;
using ACMSLogic;
using System.Data.OleDb;
using ACMS.Utils;
using ACMS.XtraUtils.LookupEditBuilder;

namespace ACMS.ACMSManager.MasterData
{
	/// <summary>
	/// Summary description for frmCommission.
	/// </summary>
	public class frmCommission : System.Windows.Forms.Form
	{
		#region User defined variable
		private ACMS.Utils.Common CommonLookUp;
		private ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder myManager;
		private DataTable dtSalesCommission;
		private DataTable dtSalesCommissionEntries;
		private DataTable dtPTCommission;
		private DataTable dtInstructor;
		private DataTable dtCommission;
		private DataTable dtInstructorCommission;

		private string _mode;
		private string connectionString;
		private SqlConnection connection;
		private Do.Employee employee;
		private Do.TerminalUser terminalUser; 
		private static User oUser;
		#endregion

		#region windows component
		private DevExpress.XtraEditors.GroupControl grpMDCommision;
		private DevExpress.XtraTab.XtraTabControl tabControlCommission;
		private DevExpress.XtraTab.XtraTabPage mdCM_tabSalesCommision;
		private DevExpress.XtraEditors.GroupControl grpSubMDCommissionScheme;
		private DevExpress.XtraEditors.TextEdit mdSC_txtNEmployeeID;
		private DevExpress.XtraGrid.GridControl gridControlMd_SalesCommisionScheme;
		private DevExpress.XtraTab.XtraTabControl tabControlCommissionEntry;
		private DevExpress.XtraTab.XtraTabPage mdCM_tabInstructorCommision;
		private DevExpress.XtraTab.XtraTabPage mdCM_tabPTCommision;
		private DevExpress.XtraGrid.GridControl gridControlMd_PTCommission;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewMd_SalesCommission;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnPT1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnPT2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnPT3;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
		private DevExpress.XtraTab.XtraTabControl tabControlInstructorCommission;
		private DevExpress.XtraTab.XtraTabPage tabPageInstructorType;
		private DevExpress.XtraGrid.GridControl gridControlMd_InstructorType;
		private DevExpress.XtraTab.XtraTabPage tabPageInstructorComm;
		private DevExpress.XtraGrid.GridControl gridControlMd_InstructorCommission;
		private DevExpress.XtraTab.XtraTabPage tabPageInstructorTypeComm;
		private DevExpress.XtraGrid.GridControl gridControlMd_InstructorTypeCommission;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewMdInstructor;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnMdIT1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnMdIT2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnMdIT3;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewMdIC;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnMdIC1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnMdIC2;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewMdITC;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnMdITC1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnMdITC2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnMdITC3;
		private System.Windows.Forms.ImageList imageList1;
		internal DevExpress.XtraEditors.SimpleButton btn_Add;
		internal DevExpress.XtraEditors.SimpleButton btn_Del;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewPTCommission;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox2;
		private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit2;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
		private DevExpress.XtraGrid.GridControl gridControlMd_SalesCommisionSchemeEntries;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewMd_SalesCommissionSchemeEntries;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnMdSCE2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnMdSCE3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnMdSCE4;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnMdSCE5;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnMdSCE6;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnMdSCE7;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnMdSCE8;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnMdSCE9;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnMdSCE10;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnMdSCE11;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnMdSCE12;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnMdSCE13;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnMdSCE14;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnMdSCE15;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnMdSCE16;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnMdSCE17;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnMdSCE18;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnMdSCE19;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnMdSCE20;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnMdSCE21;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
		internal DevExpress.XtraEditors.SimpleButton btn_Add2;
		internal DevExpress.XtraEditors.SimpleButton btn_del2;
		private DevExpress.XtraEditors.GroupControl grpMDPromotionBelow2;
		private DevExpress.XtraEditors.LookUpEdit lkBranch;
		private System.Windows.Forms.Label label3;
		private DevExpress.XtraGrid.GridControl gridCategory;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewCategory;
		private DevExpress.XtraGrid.Columns.GridColumn CategoryID;
		private DevExpress.XtraGrid.Columns.GridColumn Description;
		private DevExpress.XtraGrid.GridControl gridCategory2;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewCategory2;
		private DevExpress.XtraGrid.Columns.GridColumn Description2;
		private DevExpress.XtraGrid.Columns.GridColumn Percentage2;
		private DevExpress.XtraEditors.SimpleButton btnCategory_Add;
		private DevExpress.XtraEditors.SimpleButton btnCategory_Del;
		private DevExpress.XtraEditors.SimpleButton btnCategory_DelAll;
		private DevExpress.XtraEditors.SimpleButton btnCategory_AddAll;
		private DevExpress.XtraGrid.Columns.GridColumn nCategoryID;
		private DevExpress.XtraGrid.Columns.GridColumn nCommGroupID;
		private DevExpress.XtraGrid.Columns.GridColumn strGroupName;
		private DevExpress.XtraGrid.Columns.GridColumn nCalMethod;
		private DevExpress.XtraGrid.Columns.GridColumn mBranchTarget;
		private DevExpress.XtraGrid.Columns.GridColumn fCrossSales;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chk_CrossSales;
		internal DevExpress.XtraEditors.SimpleButton btn_Search;
		private System.Windows.Forms.Panel panelSalesCommission;
		private DevExpress.XtraGrid.Columns.GridColumn dtFrom;
		private DevExpress.XtraEditors.ImageComboBoxEdit cmbYear;
		private System.Windows.Forms.Label label12;
		private DevExpress.XtraGrid.Columns.GridColumn dtTo;
		private DevExpress.XtraTab.XtraTabPage tabMethodOne;
		private DevExpress.XtraTab.XtraTabPage tabMethodTwo;
		private DevExpress.XtraTab.XtraTabPage tabMethodThree;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn26;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn27;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_CalMethod;
		private DevExpress.XtraGrid.GridControl gridTarget;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewTarget;
		private DevExpress.XtraGrid.Columns.GridColumn nIndivTargetFrom;
		private DevExpress.XtraGrid.Columns.GridColumn nIndivTargetTo;
		private DevExpress.XtraGrid.Columns.GridColumn nIndivPercent;
		private DevExpress.XtraGrid.Columns.GridColumn nBranchTargetFrom;
		private DevExpress.XtraGrid.Columns.GridColumn nBranchTargetTo;
		private DevExpress.XtraGrid.Columns.GridColumn nBranchPercent;
		private DevExpress.XtraGrid.Columns.GridColumn nBasePercent;
		private DevExpress.XtraGrid.Columns.GridColumn mBaseAmount;
		private DevExpress.XtraGrid.Columns.GridColumn fCombine;
		internal DevExpress.XtraEditors.SimpleButton btn_Target_Add;
		internal DevExpress.XtraEditors.SimpleButton btn_Target_Del;
		private DevExpress.XtraGrid.GridControl grid2Category2;
		private DevExpress.XtraGrid.GridControl grid2Category;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView2Category2;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView2Category;
		private DevExpress.XtraGrid.GridControl grid3Category2;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView3Category2;
		private DevExpress.XtraGrid.GridControl grid3Category;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView3Category;
		private DevExpress.XtraEditors.SimpleButton btn2Category_Add;
		private DevExpress.XtraEditors.SimpleButton btn2Category_Del;
		private DevExpress.XtraEditors.SimpleButton btn2Category_DelAll;
		private DevExpress.XtraEditors.SimpleButton btn2Category_AddAll;
		private DevExpress.XtraEditors.SimpleButton btn3Category_Add;
		private DevExpress.XtraEditors.SimpleButton btn3Category_DelAll;
		private DevExpress.XtraEditors.SimpleButton btn3Category_AddAll;
		private DevExpress.XtraEditors.GroupControl groupControl2;
		private DevExpress.XtraEditors.GroupControl groupControl3;
		private DevExpress.XtraEditors.SimpleButton btn3Category_Del;
		private DevExpress.XtraGrid.GridControl gridRange;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewRange;
		private DevExpress.XtraGrid.GridControl gridMgr;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewMgr;
		private DevExpress.XtraGrid.Columns.GridColumn mRangeSalesFrom;
		private DevExpress.XtraGrid.Columns.GridColumn mRangeSalesTo;
		private DevExpress.XtraGrid.Columns.GridColumn nRangePercent;
		private DevExpress.XtraGrid.Columns.GridColumn fCombine_Range;
		private DevExpress.XtraGrid.Columns.GridColumn nBranchPercentFrom;
		private DevExpress.XtraGrid.Columns.GridColumn nBranchPercentTo;
		private DevExpress.XtraGrid.Columns.GridColumn nMgrPercent;
		private DevExpress.XtraGrid.Columns.GridColumn dMgrAmt;
		private DevExpress.XtraGrid.Columns.GridColumn fCombine_Mgr;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chk_fCombine;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chk_fCombine_Mgr;
		private DevExpress.XtraGrid.Columns.GridColumn mRangeAmt;
		internal DevExpress.XtraEditors.SimpleButton btn_Range_Del;
		internal DevExpress.XtraEditors.SimpleButton btn_Range_Add;
		internal DevExpress.XtraEditors.SimpleButton btn_Mgr_Del;
		internal DevExpress.XtraEditors.SimpleButton btn_Mgr_add;
		private System.ComponentModel.IContainer components;
		
		#endregion 


		public frmCommission()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmCommission));
			this.grpMDCommision = new DevExpress.XtraEditors.GroupControl();
			this.tabControlCommission = new DevExpress.XtraTab.XtraTabControl();
			this.mdCM_tabSalesCommision = new DevExpress.XtraTab.XtraTabPage();
			this.grpSubMDCommissionScheme = new DevExpress.XtraEditors.GroupControl();
			this.gridControlMd_SalesCommisionScheme = new DevExpress.XtraGrid.GridControl();
			this.gridViewMd_SalesCommission = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.nCommGroupID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.strGroupName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.nCalMethod = new DevExpress.XtraGrid.Columns.GridColumn();
			this.lk_CalMethod = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			this.mBranchTarget = new DevExpress.XtraGrid.Columns.GridColumn();
			this.fCrossSales = new DevExpress.XtraGrid.Columns.GridColumn();
			this.chk_CrossSales = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.dtFrom = new DevExpress.XtraGrid.Columns.GridColumn();
			this.dtTo = new DevExpress.XtraGrid.Columns.GridColumn();
			this.mdSC_txtNEmployeeID = new DevExpress.XtraEditors.TextEdit();
			this.tabControlCommissionEntry = new DevExpress.XtraTab.XtraTabControl();
			this.tabMethodOne = new DevExpress.XtraTab.XtraTabPage();
			this.btn_Target_Add = new DevExpress.XtraEditors.SimpleButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.btn_Target_Del = new DevExpress.XtraEditors.SimpleButton();
			this.grpMDPromotionBelow2 = new DevExpress.XtraEditors.GroupControl();
			this.gridCategory2 = new DevExpress.XtraGrid.GridControl();
			this.gridViewCategory2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.nCategoryID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.Description2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.Percentage2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridCategory = new DevExpress.XtraGrid.GridControl();
			this.gridViewCategory = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.CategoryID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.Description = new DevExpress.XtraGrid.Columns.GridColumn();
			this.btnCategory_Add = new DevExpress.XtraEditors.SimpleButton();
			this.btnCategory_Del = new DevExpress.XtraEditors.SimpleButton();
			this.btnCategory_DelAll = new DevExpress.XtraEditors.SimpleButton();
			this.btnCategory_AddAll = new DevExpress.XtraEditors.SimpleButton();
			this.gridTarget = new DevExpress.XtraGrid.GridControl();
			this.gridViewTarget = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.nIndivTargetFrom = new DevExpress.XtraGrid.Columns.GridColumn();
			this.nIndivTargetTo = new DevExpress.XtraGrid.Columns.GridColumn();
			this.nIndivPercent = new DevExpress.XtraGrid.Columns.GridColumn();
			this.nBranchTargetFrom = new DevExpress.XtraGrid.Columns.GridColumn();
			this.nBranchTargetTo = new DevExpress.XtraGrid.Columns.GridColumn();
			this.nBranchPercent = new DevExpress.XtraGrid.Columns.GridColumn();
			this.nBasePercent = new DevExpress.XtraGrid.Columns.GridColumn();
			this.mBaseAmount = new DevExpress.XtraGrid.Columns.GridColumn();
			this.fCombine = new DevExpress.XtraGrid.Columns.GridColumn();
			this.tabMethodTwo = new DevExpress.XtraTab.XtraTabPage();
			this.btn_Range_Del = new DevExpress.XtraEditors.SimpleButton();
			this.gridRange = new DevExpress.XtraGrid.GridControl();
			this.gridViewRange = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.mRangeSalesFrom = new DevExpress.XtraGrid.Columns.GridColumn();
			this.mRangeSalesTo = new DevExpress.XtraGrid.Columns.GridColumn();
			this.nRangePercent = new DevExpress.XtraGrid.Columns.GridColumn();
			this.mRangeAmt = new DevExpress.XtraGrid.Columns.GridColumn();
			this.fCombine_Range = new DevExpress.XtraGrid.Columns.GridColumn();
			this.chk_fCombine = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.btn_Range_Add = new DevExpress.XtraEditors.SimpleButton();
			this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
			this.grid2Category2 = new DevExpress.XtraGrid.GridControl();
			this.gridView2Category2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.grid2Category = new DevExpress.XtraGrid.GridControl();
			this.gridView2Category = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.btn2Category_Add = new DevExpress.XtraEditors.SimpleButton();
			this.btn2Category_Del = new DevExpress.XtraEditors.SimpleButton();
			this.btn2Category_DelAll = new DevExpress.XtraEditors.SimpleButton();
			this.btn2Category_AddAll = new DevExpress.XtraEditors.SimpleButton();
			this.tabMethodThree = new DevExpress.XtraTab.XtraTabPage();
			this.btn_Mgr_Del = new DevExpress.XtraEditors.SimpleButton();
			this.gridMgr = new DevExpress.XtraGrid.GridControl();
			this.gridViewMgr = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.nBranchPercentFrom = new DevExpress.XtraGrid.Columns.GridColumn();
			this.nBranchPercentTo = new DevExpress.XtraGrid.Columns.GridColumn();
			this.nMgrPercent = new DevExpress.XtraGrid.Columns.GridColumn();
			this.dMgrAmt = new DevExpress.XtraGrid.Columns.GridColumn();
			this.fCombine_Mgr = new DevExpress.XtraGrid.Columns.GridColumn();
			this.chk_fCombine_Mgr = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.btn_Mgr_add = new DevExpress.XtraEditors.SimpleButton();
			this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
			this.grid3Category2 = new DevExpress.XtraGrid.GridControl();
			this.gridView3Category2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.grid3Category = new DevExpress.XtraGrid.GridControl();
			this.gridView3Category = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.btn3Category_Add = new DevExpress.XtraEditors.SimpleButton();
			this.btn3Category_Del = new DevExpress.XtraEditors.SimpleButton();
			this.btn3Category_DelAll = new DevExpress.XtraEditors.SimpleButton();
			this.btn3Category_AddAll = new DevExpress.XtraEditors.SimpleButton();
			this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
			this.btn_Add2 = new DevExpress.XtraEditors.SimpleButton();
			this.btn_del2 = new DevExpress.XtraEditors.SimpleButton();
			this.gridControlMd_SalesCommisionSchemeEntries = new DevExpress.XtraGrid.GridControl();
			this.gridViewMd_SalesCommissionSchemeEntries = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumnMdSCE2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumnMdSCE3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumnMdSCE4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumnMdSCE5 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumnMdSCE6 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumnMdSCE7 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumnMdSCE8 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumnMdSCE9 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumnMdSCE10 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumnMdSCE11 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumnMdSCE12 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumnMdSCE13 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumnMdSCE14 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumnMdSCE15 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumnMdSCE16 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumnMdSCE17 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumnMdSCE18 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumnMdSCE19 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumnMdSCE20 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumnMdSCE21 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.mdCM_tabInstructorCommision = new DevExpress.XtraTab.XtraTabPage();
			this.tabControlInstructorCommission = new DevExpress.XtraTab.XtraTabControl();
			this.tabPageInstructorType = new DevExpress.XtraTab.XtraTabPage();
			this.gridControlMd_InstructorType = new DevExpress.XtraGrid.GridControl();
			this.gridViewMdInstructor = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumnMdIT1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumnMdIT2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumnMdIT3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
			this.repositoryItemComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.tabPageInstructorComm = new DevExpress.XtraTab.XtraTabPage();
			this.gridControlMd_InstructorCommission = new DevExpress.XtraGrid.GridControl();
			this.gridViewMdIC = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumnMdIC1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumnMdIC2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.tabPageInstructorTypeComm = new DevExpress.XtraTab.XtraTabPage();
			this.gridControlMd_InstructorTypeCommission = new DevExpress.XtraGrid.GridControl();
			this.gridViewMdITC = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumnMdITC1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			this.gridColumnMdITC2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			this.gridColumnMdITC3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.mdCM_tabPTCommision = new DevExpress.XtraTab.XtraTabPage();
			this.gridControlMd_PTCommission = new DevExpress.XtraGrid.GridControl();
			this.gridViewPTCommission = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumnPT1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumnPT2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumnPT3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.btn_Add = new DevExpress.XtraEditors.SimpleButton();
			this.btn_Del = new DevExpress.XtraEditors.SimpleButton();
			this.panelSalesCommission = new System.Windows.Forms.Panel();
			this.cmbYear = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.label12 = new System.Windows.Forms.Label();
			this.lkBranch = new DevExpress.XtraEditors.LookUpEdit();
			this.label3 = new System.Windows.Forms.Label();
			this.btn_Search = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.grpMDCommision)).BeginInit();
			this.grpMDCommision.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tabControlCommission)).BeginInit();
			this.tabControlCommission.SuspendLayout();
			this.mdCM_tabSalesCommision.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grpSubMDCommissionScheme)).BeginInit();
			this.grpSubMDCommissionScheme.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControlMd_SalesCommisionScheme)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewMd_SalesCommission)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_CalMethod)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chk_CrossSales)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mdSC_txtNEmployeeID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tabControlCommissionEntry)).BeginInit();
			this.tabControlCommissionEntry.SuspendLayout();
			this.tabMethodOne.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grpMDPromotionBelow2)).BeginInit();
			this.grpMDPromotionBelow2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridCategory2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewCategory2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridCategory)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewCategory)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridTarget)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewTarget)).BeginInit();
			this.tabMethodTwo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridRange)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewRange)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chk_fCombine)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
			this.groupControl2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grid2Category2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2Category2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grid2Category)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2Category)).BeginInit();
			this.tabMethodThree.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridMgr)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewMgr)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chk_fCombine_Mgr)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
			this.groupControl3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grid3Category2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView3Category2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grid3Category)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView3Category)).BeginInit();
			this.xtraTabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControlMd_SalesCommisionSchemeEntries)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewMd_SalesCommissionSchemeEntries)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
			this.mdCM_tabInstructorCommision.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tabControlInstructorCommission)).BeginInit();
			this.tabControlInstructorCommission.SuspendLayout();
			this.tabPageInstructorType.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControlMd_InstructorType)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewMdInstructor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).BeginInit();
			this.tabPageInstructorComm.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControlMd_InstructorCommission)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewMdIC)).BeginInit();
			this.tabPageInstructorTypeComm.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControlMd_InstructorTypeCommission)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewMdITC)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).BeginInit();
			this.mdCM_tabPTCommision.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControlMd_PTCommission)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewPTCommission)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
			this.panelSalesCommission.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbYear.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkBranch.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// grpMDCommision
			// 
			this.grpMDCommision.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.grpMDCommision.Appearance.Options.UseBackColor = true;
			this.grpMDCommision.Controls.Add(this.tabControlCommission);
			this.grpMDCommision.Controls.Add(this.btn_Add);
			this.grpMDCommision.Controls.Add(this.btn_Del);
			this.grpMDCommision.Controls.Add(this.panelSalesCommission);
			this.grpMDCommision.Location = new System.Drawing.Point(8, 0);
			this.grpMDCommision.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.grpMDCommision.LookAndFeel.UseDefaultLookAndFeel = false;
			this.grpMDCommision.LookAndFeel.UseWindowsXPTheme = false;
			this.grpMDCommision.Name = "grpMDCommision";
			this.grpMDCommision.Size = new System.Drawing.Size(980, 560);
			this.grpMDCommision.TabIndex = 17;
			this.grpMDCommision.Text = "Commision";
			// 
			// tabControlCommission
			// 
			this.tabControlCommission.AppearancePage.Header.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tabControlCommission.AppearancePage.Header.Options.UseFont = true;
			this.tabControlCommission.Location = new System.Drawing.Point(8, 48);
			this.tabControlCommission.LookAndFeel.SkinName = "Coffee";
			this.tabControlCommission.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.tabControlCommission.LookAndFeel.UseWindowsXPTheme = false;
			this.tabControlCommission.Name = "tabControlCommission";
			this.tabControlCommission.SelectedTabPage = this.mdCM_tabSalesCommision;
			this.tabControlCommission.Size = new System.Drawing.Size(960, 512);
			this.tabControlCommission.TabIndex = 13;
			this.tabControlCommission.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
																								 this.mdCM_tabSalesCommision,
																								 this.mdCM_tabInstructorCommision,
																								 this.mdCM_tabPTCommision});
			this.tabControlCommission.Text = "xtraTabControl2";
			this.tabControlCommission.Click += new System.EventHandler(this.tabControlCommission_Click);
			this.tabControlCommission.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.tabControlCommission_SelectedPageChanged);
			// 
			// mdCM_tabSalesCommision
			// 
			this.mdCM_tabSalesCommision.Appearance.PageClient.BackColor = System.Drawing.SystemColors.Control;
			this.mdCM_tabSalesCommision.Appearance.PageClient.Options.UseBackColor = true;
			this.mdCM_tabSalesCommision.Controls.Add(this.grpSubMDCommissionScheme);
			this.mdCM_tabSalesCommision.Controls.Add(this.tabControlCommissionEntry);
			this.mdCM_tabSalesCommision.Name = "mdCM_tabSalesCommision";
			this.mdCM_tabSalesCommision.Size = new System.Drawing.Size(954, 483);
			this.mdCM_tabSalesCommision.Text = "Sales Commission";
			// 
			// grpSubMDCommissionScheme
			// 
			this.grpSubMDCommissionScheme.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.grpSubMDCommissionScheme.Controls.Add(this.gridControlMd_SalesCommisionScheme);
			this.grpSubMDCommissionScheme.Controls.Add(this.mdSC_txtNEmployeeID);
			this.grpSubMDCommissionScheme.Dock = System.Windows.Forms.DockStyle.Top;
			this.grpSubMDCommissionScheme.Location = new System.Drawing.Point(0, 0);
			this.grpSubMDCommissionScheme.Name = "grpSubMDCommissionScheme";
			this.grpSubMDCommissionScheme.Size = new System.Drawing.Size(954, 136);
			this.grpSubMDCommissionScheme.TabIndex = 101;
			this.grpSubMDCommissionScheme.Text = "groupControl4";
			// 
			// gridControlMd_SalesCommisionScheme
			// 
			this.gridControlMd_SalesCommisionScheme.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// gridControlMd_SalesCommisionScheme.EmbeddedNavigator
			// 
			this.gridControlMd_SalesCommisionScheme.EmbeddedNavigator.Name = "";
			this.gridControlMd_SalesCommisionScheme.Location = new System.Drawing.Point(0, 0);
			this.gridControlMd_SalesCommisionScheme.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.gridControlMd_SalesCommisionScheme.MainView = this.gridViewMd_SalesCommission;
			this.gridControlMd_SalesCommisionScheme.Name = "gridControlMd_SalesCommisionScheme";
			this.gridControlMd_SalesCommisionScheme.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																																		this.chk_CrossSales,
																																		this.lk_CalMethod});
			this.gridControlMd_SalesCommisionScheme.Size = new System.Drawing.Size(954, 136);
			this.gridControlMd_SalesCommisionScheme.TabIndex = 101;
			this.gridControlMd_SalesCommisionScheme.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																															  this.gridViewMd_SalesCommission});
			// 
			// gridViewMd_SalesCommission
			// 
			this.gridViewMd_SalesCommission.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																											  this.nCommGroupID,
																											  this.strGroupName,
																											  this.nCalMethod,
																											  this.mBranchTarget,
																											  this.fCrossSales,
																											  this.dtFrom,
																											  this.dtTo});
			this.gridViewMd_SalesCommission.GridControl = this.gridControlMd_SalesCommisionScheme;
			this.gridViewMd_SalesCommission.Name = "gridViewMd_SalesCommission";
			this.gridViewMd_SalesCommission.OptionsCustomization.AllowFilter = false;
			this.gridViewMd_SalesCommission.OptionsCustomization.AllowSort = false;
			this.gridViewMd_SalesCommission.OptionsView.ShowGroupPanel = false;
			this.gridViewMd_SalesCommission.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewMd_SalesCommission_FocusedRowChanged);
			this.gridViewMd_SalesCommission.LostFocus += new System.EventHandler(this.gridViewMd_SalesCommission_LostFocus);
			// 
			// nCommGroupID
			// 
			this.nCommGroupID.Caption = "CommGroupID";
			this.nCommGroupID.FieldName = "nCommGroupID";
			this.nCommGroupID.Name = "nCommGroupID";
			this.nCommGroupID.Visible = true;
			this.nCommGroupID.VisibleIndex = 0;
			this.nCommGroupID.Width = 134;
			// 
			// strGroupName
			// 
			this.strGroupName.Caption = "GroupName";
			this.strGroupName.FieldName = "strGroupName";
			this.strGroupName.Name = "strGroupName";
			this.strGroupName.Visible = true;
			this.strGroupName.VisibleIndex = 1;
			this.strGroupName.Width = 203;
			// 
			// nCalMethod
			// 
			this.nCalMethod.Caption = "Method";
			this.nCalMethod.ColumnEdit = this.lk_CalMethod;
			this.nCalMethod.FieldName = "nCalMethod";
			this.nCalMethod.Name = "nCalMethod";
			this.nCalMethod.Visible = true;
			this.nCalMethod.VisibleIndex = 2;
			this.nCalMethod.Width = 120;
			// 
			// lk_CalMethod
			// 
			this.lk_CalMethod.AutoHeight = false;
			this.lk_CalMethod.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																									  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lk_CalMethod.Name = "lk_CalMethod";
			// 
			// mBranchTarget
			// 
			this.mBranchTarget.Caption = "Branch Target $";
			this.mBranchTarget.FieldName = "mBranchTarget";
			this.mBranchTarget.Name = "mBranchTarget";
			this.mBranchTarget.Visible = true;
			this.mBranchTarget.VisibleIndex = 3;
			this.mBranchTarget.Width = 153;
			// 
			// fCrossSales
			// 
			this.fCrossSales.Caption = "Cross Sales";
			this.fCrossSales.ColumnEdit = this.chk_CrossSales;
			this.fCrossSales.FieldName = "fCrossSales";
			this.fCrossSales.Name = "fCrossSales";
			this.fCrossSales.Visible = true;
			this.fCrossSales.VisibleIndex = 6;
			this.fCrossSales.Width = 73;
			// 
			// chk_CrossSales
			// 
			this.chk_CrossSales.AutoHeight = false;
			this.chk_CrossSales.Name = "chk_CrossSales";
			// 
			// dtFrom
			// 
			this.dtFrom.Caption = "From";
			this.dtFrom.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.dtFrom.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.dtFrom.FieldName = "dtFrom";
			this.dtFrom.Name = "dtFrom";
			this.dtFrom.Visible = true;
			this.dtFrom.VisibleIndex = 4;
			this.dtFrom.Width = 130;
			// 
			// dtTo
			// 
			this.dtTo.Caption = "Till";
			this.dtTo.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.dtTo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.dtTo.FieldName = "dtTo";
			this.dtTo.Name = "dtTo";
			this.dtTo.Visible = true;
			this.dtTo.VisibleIndex = 5;
			this.dtTo.Width = 127;
			// 
			// mdSC_txtNEmployeeID
			// 
			this.mdSC_txtNEmployeeID.EditValue = "";
			this.mdSC_txtNEmployeeID.ImeMode = System.Windows.Forms.ImeMode.On;
			this.mdSC_txtNEmployeeID.Location = new System.Drawing.Point(552, 168);
			this.mdSC_txtNEmployeeID.Name = "mdSC_txtNEmployeeID";
			// 
			// mdSC_txtNEmployeeID.Properties
			// 
			this.mdSC_txtNEmployeeID.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mdSC_txtNEmployeeID.Properties.Appearance.Options.UseFont = true;
			this.mdSC_txtNEmployeeID.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.mdSC_txtNEmployeeID.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.mdSC_txtNEmployeeID.Size = new System.Drawing.Size(32, 20);
			this.mdSC_txtNEmployeeID.TabIndex = 111;
			// 
			// tabControlCommissionEntry
			// 
			this.tabControlCommissionEntry.AppearancePage.Header.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tabControlCommissionEntry.AppearancePage.Header.Options.UseFont = true;
			this.tabControlCommissionEntry.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.tabControlCommissionEntry.Location = new System.Drawing.Point(0, 139);
			this.tabControlCommissionEntry.LookAndFeel.SkinName = "Coffee";
			this.tabControlCommissionEntry.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.tabControlCommissionEntry.LookAndFeel.UseWindowsXPTheme = false;
			this.tabControlCommissionEntry.Name = "tabControlCommissionEntry";
			this.tabControlCommissionEntry.SelectedTabPage = this.tabMethodOne;
			this.tabControlCommissionEntry.Size = new System.Drawing.Size(954, 344);
			this.tabControlCommissionEntry.TabIndex = 94;
			this.tabControlCommissionEntry.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
																									  this.tabMethodOne,
																									  this.tabMethodTwo,
																									  this.tabMethodThree,
																									  this.xtraTabPage1});
			this.tabControlCommissionEntry.Text = "xtraTabControl2";
			// 
			// tabMethodOne
			// 
			this.tabMethodOne.Controls.Add(this.btn_Target_Add);
			this.tabMethodOne.Controls.Add(this.btn_Target_Del);
			this.tabMethodOne.Controls.Add(this.grpMDPromotionBelow2);
			this.tabMethodOne.Controls.Add(this.gridTarget);
			this.tabMethodOne.Name = "tabMethodOne";
			this.tabMethodOne.Size = new System.Drawing.Size(948, 315);
			this.tabMethodOne.Text = "Method One";
			// 
			// btn_Target_Add
			// 
			this.btn_Target_Add.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btn_Target_Add.Appearance.Options.UseFont = true;
			this.btn_Target_Add.Appearance.Options.UseTextOptions = true;
			this.btn_Target_Add.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.btn_Target_Add.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
			this.btn_Target_Add.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.btn_Target_Add.ImageIndex = 0;
			this.btn_Target_Add.ImageList = this.imageList1;
			this.btn_Target_Add.ImeMode = System.Windows.Forms.ImeMode.On;
			this.btn_Target_Add.Location = new System.Drawing.Point(8, 176);
			this.btn_Target_Add.Name = "btn_Target_Add";
			this.btn_Target_Add.Size = new System.Drawing.Size(38, 16);
			this.btn_Target_Add.TabIndex = 136;
			this.btn_Target_Add.Click += new System.EventHandler(this.btn_Target_Add_Click);
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
			// 
			// btn_Target_Del
			// 
			this.btn_Target_Del.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btn_Target_Del.Appearance.Options.UseFont = true;
			this.btn_Target_Del.Appearance.Options.UseTextOptions = true;
			this.btn_Target_Del.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.btn_Target_Del.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
			this.btn_Target_Del.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.btn_Target_Del.ImageIndex = 1;
			this.btn_Target_Del.ImageList = this.imageList1;
			this.btn_Target_Del.Location = new System.Drawing.Point(48, 176);
			this.btn_Target_Del.Name = "btn_Target_Del";
			this.btn_Target_Del.Size = new System.Drawing.Size(38, 16);
			this.btn_Target_Del.TabIndex = 135;
			this.btn_Target_Del.Click += new System.EventHandler(this.btn_Target_Del_Click);
			// 
			// grpMDPromotionBelow2
			// 
			this.grpMDPromotionBelow2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.grpMDPromotionBelow2.Controls.Add(this.gridCategory2);
			this.grpMDPromotionBelow2.Controls.Add(this.gridCategory);
			this.grpMDPromotionBelow2.Controls.Add(this.btnCategory_Add);
			this.grpMDPromotionBelow2.Controls.Add(this.btnCategory_Del);
			this.grpMDPromotionBelow2.Controls.Add(this.btnCategory_DelAll);
			this.grpMDPromotionBelow2.Controls.Add(this.btnCategory_AddAll);
			this.grpMDPromotionBelow2.Location = new System.Drawing.Point(0, 8);
			this.grpMDPromotionBelow2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.grpMDPromotionBelow2.LookAndFeel.UseDefaultLookAndFeel = false;
			this.grpMDPromotionBelow2.Name = "grpMDPromotionBelow2";
			this.grpMDPromotionBelow2.ShowCaption = false;
			this.grpMDPromotionBelow2.Size = new System.Drawing.Size(896, 160);
			this.grpMDPromotionBelow2.TabIndex = 7;
			this.grpMDPromotionBelow2.Text = "groupControl1";
			// 
			// gridCategory2
			// 
			// 
			// gridCategory2.EmbeddedNavigator
			// 
			this.gridCategory2.EmbeddedNavigator.Name = "";
			this.gridCategory2.Location = new System.Drawing.Point(480, 8);
			this.gridCategory2.MainView = this.gridViewCategory2;
			this.gridCategory2.Name = "gridCategory2";
			this.gridCategory2.Size = new System.Drawing.Size(376, 144);
			this.gridCategory2.TabIndex = 29;
			this.gridCategory2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										 this.gridViewCategory2});
			// 
			// gridViewCategory2
			// 
			this.gridViewCategory2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																									 this.nCategoryID,
																									 this.Description2,
																									 this.Percentage2});
			this.gridViewCategory2.GridControl = this.gridCategory2;
			this.gridViewCategory2.Name = "gridViewCategory2";
			this.gridViewCategory2.OptionsBehavior.AllowIncrementalSearch = true;
			this.gridViewCategory2.OptionsCustomization.AllowFilter = false;
			this.gridViewCategory2.OptionsSelection.MultiSelect = true;
			this.gridViewCategory2.OptionsView.ShowGroupPanel = false;
			this.gridViewCategory2.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
																											  new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.nCategoryID, DevExpress.Data.ColumnSortOrder.Ascending)});
			this.gridViewCategory2.SynchronizeClones = false;
			this.gridViewCategory2.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.Update_Pecentage);
			this.gridViewCategory2.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridTarget_FocusedRowChanged);
			// 
			// nCategoryID
			// 
			this.nCategoryID.Caption = "CategoryID";
			this.nCategoryID.FieldName = "nCategoryID";
			this.nCategoryID.Name = "nCategoryID";
			this.nCategoryID.OptionsColumn.AllowEdit = false;
			this.nCategoryID.Visible = true;
			this.nCategoryID.VisibleIndex = 0;
			this.nCategoryID.Width = 102;
			// 
			// Description2
			// 
			this.Description2.Caption = "Description";
			this.Description2.FieldName = "strDescription";
			this.Description2.Name = "Description2";
			this.Description2.OptionsColumn.AllowEdit = false;
			this.Description2.Visible = true;
			this.Description2.VisibleIndex = 1;
			this.Description2.Width = 181;
			// 
			// Percentage2
			// 
			this.Percentage2.Caption = "%";
			this.Percentage2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.Percentage2.FieldName = "Percentage";
			this.Percentage2.Name = "Percentage2";
			this.Percentage2.Visible = true;
			this.Percentage2.VisibleIndex = 2;
			this.Percentage2.Width = 79;
			// 
			// gridCategory
			// 
			// 
			// gridCategory.EmbeddedNavigator
			// 
			this.gridCategory.EmbeddedNavigator.Name = "";
			this.gridCategory.Location = new System.Drawing.Point(8, 8);
			this.gridCategory.MainView = this.gridViewCategory;
			this.gridCategory.Name = "gridCategory";
			this.gridCategory.Size = new System.Drawing.Size(376, 144);
			this.gridCategory.TabIndex = 24;
			this.gridCategory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										this.gridViewCategory});
			// 
			// gridViewCategory
			// 
			this.gridViewCategory.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																									this.CategoryID,
																									this.Description});
			this.gridViewCategory.GridControl = this.gridCategory;
			this.gridViewCategory.Name = "gridViewCategory";
			this.gridViewCategory.OptionsBehavior.AllowIncrementalSearch = true;
			this.gridViewCategory.OptionsBehavior.Editable = false;
			this.gridViewCategory.OptionsCustomization.AllowFilter = false;
			this.gridViewCategory.OptionsSelection.MultiSelect = true;
			this.gridViewCategory.OptionsView.ShowGroupPanel = false;
			this.gridViewCategory.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
																											 new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.CategoryID, DevExpress.Data.ColumnSortOrder.Ascending)});
			// 
			// CategoryID
			// 
			this.CategoryID.Caption = "CategoryID";
			this.CategoryID.FieldName = "nCategoryID";
			this.CategoryID.Name = "CategoryID";
			this.CategoryID.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.CategoryID.Visible = true;
			this.CategoryID.VisibleIndex = 0;
			this.CategoryID.Width = 100;
			// 
			// Description
			// 
			this.Description.Caption = "Description";
			this.Description.FieldName = "strDescription";
			this.Description.Name = "Description";
			this.Description.Visible = true;
			this.Description.VisibleIndex = 1;
			this.Description.Width = 262;
			// 
			// btnCategory_Add
			// 
			this.btnCategory_Add.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnCategory_Add.Location = new System.Drawing.Point(416, 16);
			this.btnCategory_Add.Name = "btnCategory_Add";
			this.btnCategory_Add.Size = new System.Drawing.Size(32, 24);
			this.btnCategory_Add.TabIndex = 25;
			this.btnCategory_Add.Text = ">";
			this.btnCategory_Add.Click += new System.EventHandler(this.btnCategory_Add_Click);
			// 
			// btnCategory_Del
			// 
			this.btnCategory_Del.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnCategory_Del.Location = new System.Drawing.Point(416, 112);
			this.btnCategory_Del.Name = "btnCategory_Del";
			this.btnCategory_Del.Size = new System.Drawing.Size(32, 24);
			this.btnCategory_Del.TabIndex = 28;
			this.btnCategory_Del.Text = "<";
			this.btnCategory_Del.Click += new System.EventHandler(this.btnCategory_Del_Click);
			// 
			// btnCategory_DelAll
			// 
			this.btnCategory_DelAll.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnCategory_DelAll.Location = new System.Drawing.Point(416, 48);
			this.btnCategory_DelAll.Name = "btnCategory_DelAll";
			this.btnCategory_DelAll.Size = new System.Drawing.Size(32, 24);
			this.btnCategory_DelAll.TabIndex = 27;
			this.btnCategory_DelAll.Text = "<<";
			this.btnCategory_DelAll.Click += new System.EventHandler(this.btnCategory_DelAll_Click);
			// 
			// btnCategory_AddAll
			// 
			this.btnCategory_AddAll.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnCategory_AddAll.Location = new System.Drawing.Point(416, 80);
			this.btnCategory_AddAll.Name = "btnCategory_AddAll";
			this.btnCategory_AddAll.Size = new System.Drawing.Size(32, 24);
			this.btnCategory_AddAll.TabIndex = 26;
			this.btnCategory_AddAll.Text = ">>";
			this.btnCategory_AddAll.Click += new System.EventHandler(this.btnCategory_AddAll_Click);
			// 
			// gridTarget
			// 
			// 
			// gridTarget.EmbeddedNavigator
			// 
			this.gridTarget.EmbeddedNavigator.Name = "";
			this.gridTarget.Location = new System.Drawing.Point(8, 192);
			this.gridTarget.MainView = this.gridViewTarget;
			this.gridTarget.Name = "gridTarget";
			this.gridTarget.Size = new System.Drawing.Size(888, 120);
			this.gridTarget.TabIndex = 25;
			this.gridTarget.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																									  this.gridViewTarget});
			// 
			// gridViewTarget
			// 
			this.gridViewTarget.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																								  this.nIndivTargetFrom,
																								  this.nIndivTargetTo,
																								  this.nIndivPercent,
																								  this.nBranchTargetFrom,
																								  this.nBranchTargetTo,
																								  this.nBranchPercent,
																								  this.nBasePercent,
																								  this.mBaseAmount,
																								  this.fCombine});
			this.gridViewTarget.GridControl = this.gridTarget;
			this.gridViewTarget.Name = "gridViewTarget";
			this.gridViewTarget.OptionsBehavior.AllowIncrementalSearch = true;
			this.gridViewTarget.OptionsCustomization.AllowFilter = false;
			this.gridViewTarget.OptionsSelection.MultiSelect = true;
			this.gridViewTarget.OptionsView.ShowGroupPanel = false;
			this.gridViewTarget.LostFocus += new System.EventHandler(this.gridViewTarget_LostFocus);
			// 
			// nIndivTargetFrom
			// 
			this.nIndivTargetFrom.Caption = "Individual From";
			this.nIndivTargetFrom.FieldName = "nIndivTargetFrom";
			this.nIndivTargetFrom.Name = "nIndivTargetFrom";
			this.nIndivTargetFrom.Visible = true;
			this.nIndivTargetFrom.VisibleIndex = 0;
			this.nIndivTargetFrom.Width = 117;
			// 
			// nIndivTargetTo
			// 
			this.nIndivTargetTo.Caption = "Individual To";
			this.nIndivTargetTo.FieldName = "nIndivTargetTo";
			this.nIndivTargetTo.Name = "nIndivTargetTo";
			this.nIndivTargetTo.Visible = true;
			this.nIndivTargetTo.VisibleIndex = 1;
			this.nIndivTargetTo.Width = 114;
			// 
			// nIndivPercent
			// 
			this.nIndivPercent.Caption = "Reward %";
			this.nIndivPercent.FieldName = "nIndivPercent";
			this.nIndivPercent.Name = "nIndivPercent";
			this.nIndivPercent.Visible = true;
			this.nIndivPercent.VisibleIndex = 2;
			this.nIndivPercent.Width = 105;
			// 
			// nBranchTargetFrom
			// 
			this.nBranchTargetFrom.Caption = "Branch From";
			this.nBranchTargetFrom.FieldName = "nBranchTargetFrom";
			this.nBranchTargetFrom.Name = "nBranchTargetFrom";
			this.nBranchTargetFrom.Visible = true;
			this.nBranchTargetFrom.VisibleIndex = 3;
			this.nBranchTargetFrom.Width = 103;
			// 
			// nBranchTargetTo
			// 
			this.nBranchTargetTo.Caption = "Branch To";
			this.nBranchTargetTo.FieldName = "nBranchTargetTo";
			this.nBranchTargetTo.Name = "nBranchTargetTo";
			this.nBranchTargetTo.Visible = true;
			this.nBranchTargetTo.VisibleIndex = 4;
			this.nBranchTargetTo.Width = 113;
			// 
			// nBranchPercent
			// 
			this.nBranchPercent.Caption = "+ Branch %";
			this.nBranchPercent.FieldName = "nBranchPercent";
			this.nBranchPercent.Name = "nBranchPercent";
			this.nBranchPercent.Visible = true;
			this.nBranchPercent.VisibleIndex = 5;
			this.nBranchPercent.Width = 82;
			// 
			// nBasePercent
			// 
			this.nBasePercent.Caption = "Min %";
			this.nBasePercent.FieldName = "nBasePercent";
			this.nBasePercent.Name = "nBasePercent";
			this.nBasePercent.Visible = true;
			this.nBasePercent.VisibleIndex = 6;
			this.nBasePercent.Width = 82;
			// 
			// mBaseAmount
			// 
			this.mBaseAmount.Caption = "Min Amount";
			this.mBaseAmount.FieldName = "mBaseAmount";
			this.mBaseAmount.Name = "mBaseAmount";
			this.mBaseAmount.Visible = true;
			this.mBaseAmount.VisibleIndex = 7;
			this.mBaseAmount.Width = 103;
			// 
			// fCombine
			// 
			this.fCombine.Caption = "Both";
			this.fCombine.FieldName = "fCombine";
			this.fCombine.Name = "fCombine";
			this.fCombine.Visible = true;
			this.fCombine.VisibleIndex = 8;
			this.fCombine.Width = 55;
			// 
			// tabMethodTwo
			// 
			this.tabMethodTwo.Controls.Add(this.btn_Range_Del);
			this.tabMethodTwo.Controls.Add(this.gridRange);
			this.tabMethodTwo.Controls.Add(this.btn_Range_Add);
			this.tabMethodTwo.Controls.Add(this.groupControl2);
			this.tabMethodTwo.Name = "tabMethodTwo";
			this.tabMethodTwo.Size = new System.Drawing.Size(948, 315);
			this.tabMethodTwo.Text = "Method Two";
			// 
			// btn_Range_Del
			// 
			this.btn_Range_Del.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btn_Range_Del.Appearance.Options.UseFont = true;
			this.btn_Range_Del.Appearance.Options.UseTextOptions = true;
			this.btn_Range_Del.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.btn_Range_Del.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
			this.btn_Range_Del.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.btn_Range_Del.ImageIndex = 1;
			this.btn_Range_Del.ImageList = this.imageList1;
			this.btn_Range_Del.Location = new System.Drawing.Point(48, 168);
			this.btn_Range_Del.Name = "btn_Range_Del";
			this.btn_Range_Del.Size = new System.Drawing.Size(38, 20);
			this.btn_Range_Del.TabIndex = 139;
			this.btn_Range_Del.Click += new System.EventHandler(this.btn_Range_Del_Click);
			// 
			// gridRange
			// 
			// 
			// gridRange.EmbeddedNavigator
			// 
			this.gridRange.EmbeddedNavigator.Name = "";
			this.gridRange.Location = new System.Drawing.Point(8, 192);
			this.gridRange.MainView = this.gridViewRange;
			this.gridRange.Name = "gridRange";
			this.gridRange.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																											   this.chk_fCombine});
			this.gridRange.Size = new System.Drawing.Size(888, 120);
			this.gridRange.TabIndex = 137;
			this.gridRange.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																									 this.gridViewRange});
			// 
			// gridViewRange
			// 
			this.gridViewRange.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																								 this.mRangeSalesFrom,
																								 this.mRangeSalesTo,
																								 this.nRangePercent,
																								 this.mRangeAmt,
																								 this.fCombine_Range});
			this.gridViewRange.GridControl = this.gridRange;
			this.gridViewRange.Name = "gridViewRange";
			this.gridViewRange.OptionsBehavior.AllowIncrementalSearch = true;
			this.gridViewRange.OptionsCustomization.AllowFilter = false;
			this.gridViewRange.OptionsSelection.MultiSelect = true;
			this.gridViewRange.OptionsView.ShowGroupPanel = false;
			this.gridViewRange.LostFocus += new System.EventHandler(this.gridViewRange_LostFocus);
			// 
			// mRangeSalesFrom
			// 
			this.mRangeSalesFrom.Caption = "Sales From $";
			this.mRangeSalesFrom.FieldName = "mRangeSalesFrom";
			this.mRangeSalesFrom.Name = "mRangeSalesFrom";
			this.mRangeSalesFrom.Visible = true;
			this.mRangeSalesFrom.VisibleIndex = 0;
			this.mRangeSalesFrom.Width = 195;
			// 
			// mRangeSalesTo
			// 
			this.mRangeSalesTo.Caption = "Sales To $";
			this.mRangeSalesTo.FieldName = "mRangeSalesTo";
			this.mRangeSalesTo.Name = "mRangeSalesTo";
			this.mRangeSalesTo.Visible = true;
			this.mRangeSalesTo.VisibleIndex = 1;
			this.mRangeSalesTo.Width = 190;
			// 
			// nRangePercent
			// 
			this.nRangePercent.Caption = "Reward % ";
			this.nRangePercent.FieldName = "nRangePercent";
			this.nRangePercent.Name = "nRangePercent";
			this.nRangePercent.Visible = true;
			this.nRangePercent.VisibleIndex = 2;
			this.nRangePercent.Width = 175;
			// 
			// mRangeAmt
			// 
			this.mRangeAmt.Caption = "Reward Amount";
			this.mRangeAmt.FieldName = "mRangeAmt";
			this.mRangeAmt.Name = "mRangeAmt";
			this.mRangeAmt.Visible = true;
			this.mRangeAmt.VisibleIndex = 3;
			this.mRangeAmt.Width = 222;
			// 
			// fCombine_Range
			// 
			this.fCombine_Range.Caption = "Both";
			this.fCombine_Range.ColumnEdit = this.chk_fCombine;
			this.fCombine_Range.FieldName = "fCombine ";
			this.fCombine_Range.Name = "fCombine_Range";
			this.fCombine_Range.Visible = true;
			this.fCombine_Range.VisibleIndex = 4;
			this.fCombine_Range.Width = 92;
			// 
			// chk_fCombine
			// 
			this.chk_fCombine.AutoHeight = false;
			this.chk_fCombine.Name = "chk_fCombine";
			// 
			// btn_Range_Add
			// 
			this.btn_Range_Add.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btn_Range_Add.Appearance.Options.UseFont = true;
			this.btn_Range_Add.Appearance.Options.UseTextOptions = true;
			this.btn_Range_Add.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.btn_Range_Add.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
			this.btn_Range_Add.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.btn_Range_Add.ImageIndex = 0;
			this.btn_Range_Add.ImageList = this.imageList1;
			this.btn_Range_Add.ImeMode = System.Windows.Forms.ImeMode.On;
			this.btn_Range_Add.Location = new System.Drawing.Point(8, 168);
			this.btn_Range_Add.Name = "btn_Range_Add";
			this.btn_Range_Add.Size = new System.Drawing.Size(38, 20);
			this.btn_Range_Add.TabIndex = 140;
			this.btn_Range_Add.Click += new System.EventHandler(this.btn_Range_Add_Click);
			// 
			// groupControl2
			// 
			this.groupControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.groupControl2.Controls.Add(this.grid2Category2);
			this.groupControl2.Controls.Add(this.grid2Category);
			this.groupControl2.Controls.Add(this.btn2Category_Add);
			this.groupControl2.Controls.Add(this.btn2Category_Del);
			this.groupControl2.Controls.Add(this.btn2Category_DelAll);
			this.groupControl2.Controls.Add(this.btn2Category_AddAll);
			this.groupControl2.Location = new System.Drawing.Point(0, 8);
			this.groupControl2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.groupControl2.LookAndFeel.UseDefaultLookAndFeel = false;
			this.groupControl2.Name = "groupControl2";
			this.groupControl2.ShowCaption = false;
			this.groupControl2.Size = new System.Drawing.Size(896, 160);
			this.groupControl2.TabIndex = 8;
			this.groupControl2.Text = "groupControl1";
			// 
			// grid2Category2
			// 
			// 
			// grid2Category2.EmbeddedNavigator
			// 
			this.grid2Category2.EmbeddedNavigator.Name = "";
			this.grid2Category2.Location = new System.Drawing.Point(456, 8);
			this.grid2Category2.MainView = this.gridView2Category2;
			this.grid2Category2.Name = "grid2Category2";
			this.grid2Category2.Size = new System.Drawing.Size(376, 144);
			this.grid2Category2.TabIndex = 29;
			this.grid2Category2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										  this.gridView2Category2});
			// 
			// gridView2Category2
			// 
			this.gridView2Category2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																									  this.gridColumn18,
																									  this.gridColumn19});
			this.gridView2Category2.GridControl = this.grid2Category2;
			this.gridView2Category2.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
			this.gridView2Category2.Name = "gridView2Category2";
			this.gridView2Category2.OptionsBehavior.AllowIncrementalSearch = true;
			this.gridView2Category2.OptionsCustomization.AllowFilter = false;
			this.gridView2Category2.OptionsSelection.MultiSelect = true;
			this.gridView2Category2.OptionsView.ShowGroupPanel = false;
			this.gridView2Category2.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
																											   new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn18, DevExpress.Data.ColumnSortOrder.Ascending)});
			this.gridView2Category2.SynchronizeClones = false;
			this.gridView2Category2.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridRange_FocusedRowChanged);
			// 
			// gridColumn18
			// 
			this.gridColumn18.Caption = "CategoryID";
			this.gridColumn18.FieldName = "nCategoryID";
			this.gridColumn18.Name = "gridColumn18";
			this.gridColumn18.OptionsColumn.AllowEdit = false;
			this.gridColumn18.Visible = true;
			this.gridColumn18.VisibleIndex = 0;
			this.gridColumn18.Width = 78;
			// 
			// gridColumn19
			// 
			this.gridColumn19.Caption = "Description";
			this.gridColumn19.FieldName = "strDescription";
			this.gridColumn19.Name = "gridColumn19";
			this.gridColumn19.OptionsColumn.AllowEdit = false;
			this.gridColumn19.Visible = true;
			this.gridColumn19.VisibleIndex = 1;
			this.gridColumn19.Width = 171;
			// 
			// grid2Category
			// 
			// 
			// grid2Category.EmbeddedNavigator
			// 
			this.grid2Category.EmbeddedNavigator.Name = "";
			this.grid2Category.Location = new System.Drawing.Point(8, 8);
			this.grid2Category.MainView = this.gridView2Category;
			this.grid2Category.Name = "grid2Category";
			this.grid2Category.Size = new System.Drawing.Size(360, 144);
			this.grid2Category.TabIndex = 24;
			this.grid2Category.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										 this.gridView2Category});
			// 
			// gridView2Category
			// 
			this.gridView2Category.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																									 this.gridColumn21,
																									 this.gridColumn22});
			this.gridView2Category.GridControl = this.grid2Category;
			this.gridView2Category.Name = "gridView2Category";
			this.gridView2Category.OptionsBehavior.AllowIncrementalSearch = true;
			this.gridView2Category.OptionsBehavior.Editable = false;
			this.gridView2Category.OptionsCustomization.AllowFilter = false;
			this.gridView2Category.OptionsSelection.MultiSelect = true;
			this.gridView2Category.OptionsView.ShowGroupPanel = false;
			this.gridView2Category.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
																											  new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn21, DevExpress.Data.ColumnSortOrder.Ascending)});
			// 
			// gridColumn21
			// 
			this.gridColumn21.Caption = "CategoryID";
			this.gridColumn21.FieldName = "nCategoryID";
			this.gridColumn21.Name = "gridColumn21";
			this.gridColumn21.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn21.Visible = true;
			this.gridColumn21.VisibleIndex = 0;
			this.gridColumn21.Width = 78;
			// 
			// gridColumn22
			// 
			this.gridColumn22.Caption = "Description";
			this.gridColumn22.FieldName = "strDescription";
			this.gridColumn22.Name = "gridColumn22";
			this.gridColumn22.Visible = true;
			this.gridColumn22.VisibleIndex = 1;
			this.gridColumn22.Width = 268;
			// 
			// btn2Category_Add
			// 
			this.btn2Category_Add.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btn2Category_Add.Location = new System.Drawing.Point(392, 16);
			this.btn2Category_Add.Name = "btn2Category_Add";
			this.btn2Category_Add.Size = new System.Drawing.Size(32, 24);
			this.btn2Category_Add.TabIndex = 25;
			this.btn2Category_Add.Text = ">";
			this.btn2Category_Add.Click += new System.EventHandler(this.btn2Category_Add_Click);
			// 
			// btn2Category_Del
			// 
			this.btn2Category_Del.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btn2Category_Del.Location = new System.Drawing.Point(392, 112);
			this.btn2Category_Del.Name = "btn2Category_Del";
			this.btn2Category_Del.Size = new System.Drawing.Size(32, 24);
			this.btn2Category_Del.TabIndex = 28;
			this.btn2Category_Del.Text = "<";
			this.btn2Category_Del.Click += new System.EventHandler(this.btn2Category_Del_Click);
			// 
			// btn2Category_DelAll
			// 
			this.btn2Category_DelAll.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btn2Category_DelAll.Location = new System.Drawing.Point(392, 48);
			this.btn2Category_DelAll.Name = "btn2Category_DelAll";
			this.btn2Category_DelAll.Size = new System.Drawing.Size(32, 24);
			this.btn2Category_DelAll.TabIndex = 27;
			this.btn2Category_DelAll.Text = "<<";
			this.btn2Category_DelAll.Click += new System.EventHandler(this.btn2Category_DelAll_Click);
			// 
			// btn2Category_AddAll
			// 
			this.btn2Category_AddAll.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btn2Category_AddAll.Location = new System.Drawing.Point(392, 80);
			this.btn2Category_AddAll.Name = "btn2Category_AddAll";
			this.btn2Category_AddAll.Size = new System.Drawing.Size(32, 24);
			this.btn2Category_AddAll.TabIndex = 26;
			this.btn2Category_AddAll.Text = ">>";
			this.btn2Category_AddAll.Click += new System.EventHandler(this.btn2Category_AddAll_Click);
			// 
			// tabMethodThree
			// 
			this.tabMethodThree.Controls.Add(this.btn_Mgr_Del);
			this.tabMethodThree.Controls.Add(this.gridMgr);
			this.tabMethodThree.Controls.Add(this.btn_Mgr_add);
			this.tabMethodThree.Controls.Add(this.groupControl3);
			this.tabMethodThree.Name = "tabMethodThree";
			this.tabMethodThree.Size = new System.Drawing.Size(948, 315);
			this.tabMethodThree.Text = "Method Three";
			// 
			// btn_Mgr_Del
			// 
			this.btn_Mgr_Del.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btn_Mgr_Del.Appearance.Options.UseFont = true;
			this.btn_Mgr_Del.Appearance.Options.UseTextOptions = true;
			this.btn_Mgr_Del.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.btn_Mgr_Del.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
			this.btn_Mgr_Del.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.btn_Mgr_Del.ImageIndex = 1;
			this.btn_Mgr_Del.ImageList = this.imageList1;
			this.btn_Mgr_Del.Location = new System.Drawing.Point(48, 160);
			this.btn_Mgr_Del.Name = "btn_Mgr_Del";
			this.btn_Mgr_Del.Size = new System.Drawing.Size(38, 20);
			this.btn_Mgr_Del.TabIndex = 139;
			this.btn_Mgr_Del.Click += new System.EventHandler(this.btn_Mgr_Del_Click);
			// 
			// gridMgr
			// 
			// 
			// gridMgr.EmbeddedNavigator
			// 
			this.gridMgr.EmbeddedNavigator.Name = "";
			this.gridMgr.Location = new System.Drawing.Point(8, 184);
			this.gridMgr.MainView = this.gridViewMgr;
			this.gridMgr.Name = "gridMgr";
			this.gridMgr.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																											 this.chk_fCombine_Mgr});
			this.gridMgr.Size = new System.Drawing.Size(888, 120);
			this.gridMgr.TabIndex = 137;
			this.gridMgr.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																								   this.gridViewMgr});
			// 
			// gridViewMgr
			// 
			this.gridViewMgr.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							   this.nBranchPercentFrom,
																							   this.nBranchPercentTo,
																							   this.nMgrPercent,
																							   this.dMgrAmt,
																							   this.fCombine_Mgr});
			this.gridViewMgr.GridControl = this.gridMgr;
			this.gridViewMgr.Name = "gridViewMgr";
			this.gridViewMgr.OptionsBehavior.AllowIncrementalSearch = true;
			this.gridViewMgr.OptionsCustomization.AllowFilter = false;
			this.gridViewMgr.OptionsSelection.MultiSelect = true;
			this.gridViewMgr.OptionsView.ShowGroupPanel = false;
			this.gridViewMgr.LostFocus += new System.EventHandler(this.gridViewMgr_LostFocus);
			// 
			// nBranchPercentFrom
			// 
			this.nBranchPercentFrom.Caption = "Branch From %";
			this.nBranchPercentFrom.FieldName = "nBranchPercentFrom";
			this.nBranchPercentFrom.Name = "nBranchPercentFrom";
			this.nBranchPercentFrom.Visible = true;
			this.nBranchPercentFrom.VisibleIndex = 0;
			this.nBranchPercentFrom.Width = 117;
			// 
			// nBranchPercentTo
			// 
			this.nBranchPercentTo.Caption = "Branch To %";
			this.nBranchPercentTo.FieldName = "nBranchPercentTo";
			this.nBranchPercentTo.Name = "nBranchPercentTo";
			this.nBranchPercentTo.Visible = true;
			this.nBranchPercentTo.VisibleIndex = 1;
			this.nBranchPercentTo.Width = 114;
			// 
			// nMgrPercent
			// 
			this.nMgrPercent.Caption = "Reward %";
			this.nMgrPercent.FieldName = "nMgrPercent";
			this.nMgrPercent.Name = "nMgrPercent";
			this.nMgrPercent.Visible = true;
			this.nMgrPercent.VisibleIndex = 2;
			this.nMgrPercent.Width = 105;
			// 
			// dMgrAmt
			// 
			this.dMgrAmt.Caption = "Min. Amount";
			this.dMgrAmt.FieldName = "dMgrAmt";
			this.dMgrAmt.Name = "dMgrAmt";
			this.dMgrAmt.Visible = true;
			this.dMgrAmt.VisibleIndex = 3;
			this.dMgrAmt.Width = 103;
			// 
			// fCombine_Mgr
			// 
			this.fCombine_Mgr.Caption = "Both";
			this.fCombine_Mgr.ColumnEdit = this.chk_fCombine_Mgr;
			this.fCombine_Mgr.FieldName = "fCombine";
			this.fCombine_Mgr.Name = "fCombine_Mgr";
			this.fCombine_Mgr.Visible = true;
			this.fCombine_Mgr.VisibleIndex = 4;
			this.fCombine_Mgr.Width = 113;
			// 
			// chk_fCombine_Mgr
			// 
			this.chk_fCombine_Mgr.AutoHeight = false;
			this.chk_fCombine_Mgr.Name = "chk_fCombine_Mgr";
			// 
			// btn_Mgr_add
			// 
			this.btn_Mgr_add.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btn_Mgr_add.Appearance.Options.UseFont = true;
			this.btn_Mgr_add.Appearance.Options.UseTextOptions = true;
			this.btn_Mgr_add.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.btn_Mgr_add.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
			this.btn_Mgr_add.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.btn_Mgr_add.ImageIndex = 0;
			this.btn_Mgr_add.ImageList = this.imageList1;
			this.btn_Mgr_add.ImeMode = System.Windows.Forms.ImeMode.On;
			this.btn_Mgr_add.Location = new System.Drawing.Point(8, 160);
			this.btn_Mgr_add.Name = "btn_Mgr_add";
			this.btn_Mgr_add.Size = new System.Drawing.Size(38, 20);
			this.btn_Mgr_add.TabIndex = 140;
			this.btn_Mgr_add.Click += new System.EventHandler(this.btn_Mgr_add_Click);
			// 
			// groupControl3
			// 
			this.groupControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.groupControl3.Controls.Add(this.grid3Category2);
			this.groupControl3.Controls.Add(this.grid3Category);
			this.groupControl3.Controls.Add(this.btn3Category_Add);
			this.groupControl3.Controls.Add(this.btn3Category_Del);
			this.groupControl3.Controls.Add(this.btn3Category_DelAll);
			this.groupControl3.Controls.Add(this.btn3Category_AddAll);
			this.groupControl3.Location = new System.Drawing.Point(0, 8);
			this.groupControl3.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.groupControl3.LookAndFeel.UseDefaultLookAndFeel = false;
			this.groupControl3.Name = "groupControl3";
			this.groupControl3.ShowCaption = false;
			this.groupControl3.Size = new System.Drawing.Size(896, 152);
			this.groupControl3.TabIndex = 8;
			this.groupControl3.Text = "groupControl1";
			// 
			// grid3Category2
			// 
			// 
			// grid3Category2.EmbeddedNavigator
			// 
			this.grid3Category2.EmbeddedNavigator.Name = "";
			this.grid3Category2.Location = new System.Drawing.Point(456, 8);
			this.grid3Category2.MainView = this.gridView3Category2;
			this.grid3Category2.Name = "grid3Category2";
			this.grid3Category2.Size = new System.Drawing.Size(376, 136);
			this.grid3Category2.TabIndex = 29;
			this.grid3Category2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										  this.gridView3Category2});
			// 
			// gridView3Category2
			// 
			this.gridView3Category2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																									  this.gridColumn23,
																									  this.gridColumn24,
																									  this.gridColumn25});
			this.gridView3Category2.GridControl = this.grid3Category2;
			this.gridView3Category2.Name = "gridView3Category2";
			this.gridView3Category2.OptionsBehavior.AllowIncrementalSearch = true;
			this.gridView3Category2.OptionsCustomization.AllowFilter = false;
			this.gridView3Category2.OptionsSelection.MultiSelect = true;
			this.gridView3Category2.OptionsView.ShowGroupPanel = false;
			this.gridView3Category2.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
																											   new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn23, DevExpress.Data.ColumnSortOrder.Ascending)});
			this.gridView3Category2.SynchronizeClones = false;
			this.gridView3Category2.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridManager_FocusedRowChanged);
			// 
			// gridColumn23
			// 
			this.gridColumn23.Caption = "CategoryID";
			this.gridColumn23.FieldName = "nCategoryID";
			this.gridColumn23.Name = "gridColumn23";
			this.gridColumn23.OptionsColumn.AllowEdit = false;
			this.gridColumn23.Visible = true;
			this.gridColumn23.VisibleIndex = 0;
			this.gridColumn23.Width = 78;
			// 
			// gridColumn24
			// 
			this.gridColumn24.Caption = "Description";
			this.gridColumn24.FieldName = "strDescription";
			this.gridColumn24.Name = "gridColumn24";
			this.gridColumn24.OptionsColumn.AllowEdit = false;
			this.gridColumn24.Visible = true;
			this.gridColumn24.VisibleIndex = 1;
			this.gridColumn24.Width = 171;
			// 
			// gridColumn25
			// 
			this.gridColumn25.Caption = "%";
			this.gridColumn25.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumn25.FieldName = "Percentage";
			this.gridColumn25.Name = "gridColumn25";
			this.gridColumn25.Width = 73;
			// 
			// grid3Category
			// 
			// 
			// grid3Category.EmbeddedNavigator
			// 
			this.grid3Category.EmbeddedNavigator.Name = "";
			this.grid3Category.Location = new System.Drawing.Point(8, 8);
			this.grid3Category.MainView = this.gridView3Category;
			this.grid3Category.Name = "grid3Category";
			this.grid3Category.Size = new System.Drawing.Size(360, 136);
			this.grid3Category.TabIndex = 24;
			this.grid3Category.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										 this.gridView3Category});
			// 
			// gridView3Category
			// 
			this.gridView3Category.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																									 this.gridColumn26,
																									 this.gridColumn27});
			this.gridView3Category.GridControl = this.grid3Category;
			this.gridView3Category.Name = "gridView3Category";
			this.gridView3Category.OptionsBehavior.AllowIncrementalSearch = true;
			this.gridView3Category.OptionsBehavior.Editable = false;
			this.gridView3Category.OptionsCustomization.AllowFilter = false;
			this.gridView3Category.OptionsSelection.MultiSelect = true;
			this.gridView3Category.OptionsView.ShowGroupPanel = false;
			this.gridView3Category.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
																											  new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn26, DevExpress.Data.ColumnSortOrder.Ascending)});
			// 
			// gridColumn26
			// 
			this.gridColumn26.Caption = "CategoryID";
			this.gridColumn26.FieldName = "nCategoryID";
			this.gridColumn26.Name = "gridColumn26";
			this.gridColumn26.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn26.Visible = true;
			this.gridColumn26.VisibleIndex = 0;
			this.gridColumn26.Width = 78;
			// 
			// gridColumn27
			// 
			this.gridColumn27.Caption = "Description";
			this.gridColumn27.FieldName = "strDescription";
			this.gridColumn27.Name = "gridColumn27";
			this.gridColumn27.Visible = true;
			this.gridColumn27.VisibleIndex = 1;
			this.gridColumn27.Width = 268;
			// 
			// btn3Category_Add
			// 
			this.btn3Category_Add.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btn3Category_Add.Location = new System.Drawing.Point(392, 16);
			this.btn3Category_Add.Name = "btn3Category_Add";
			this.btn3Category_Add.Size = new System.Drawing.Size(32, 24);
			this.btn3Category_Add.TabIndex = 25;
			this.btn3Category_Add.Text = ">";
			this.btn3Category_Add.Click += new System.EventHandler(this.btn3Category_Add_Click);
			// 
			// btn3Category_Del
			// 
			this.btn3Category_Del.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btn3Category_Del.Location = new System.Drawing.Point(392, 112);
			this.btn3Category_Del.Name = "btn3Category_Del";
			this.btn3Category_Del.Size = new System.Drawing.Size(32, 24);
			this.btn3Category_Del.TabIndex = 28;
			this.btn3Category_Del.Text = "<";
			this.btn3Category_Del.Click += new System.EventHandler(this.btn3Category_Del_Click);
			// 
			// btn3Category_DelAll
			// 
			this.btn3Category_DelAll.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btn3Category_DelAll.Location = new System.Drawing.Point(392, 48);
			this.btn3Category_DelAll.Name = "btn3Category_DelAll";
			this.btn3Category_DelAll.Size = new System.Drawing.Size(32, 24);
			this.btn3Category_DelAll.TabIndex = 27;
			this.btn3Category_DelAll.Text = "<<";
			this.btn3Category_DelAll.Click += new System.EventHandler(this.btn3Category_DelAll_Click);
			// 
			// btn3Category_AddAll
			// 
			this.btn3Category_AddAll.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btn3Category_AddAll.Location = new System.Drawing.Point(392, 80);
			this.btn3Category_AddAll.Name = "btn3Category_AddAll";
			this.btn3Category_AddAll.Size = new System.Drawing.Size(32, 24);
			this.btn3Category_AddAll.TabIndex = 26;
			this.btn3Category_AddAll.Text = ">>";
			this.btn3Category_AddAll.Click += new System.EventHandler(this.btn3Category_AddAll_Click);
			// 
			// xtraTabPage1
			// 
			this.xtraTabPage1.Controls.Add(this.btn_Add2);
			this.xtraTabPage1.Controls.Add(this.btn_del2);
			this.xtraTabPage1.Controls.Add(this.gridControlMd_SalesCommisionSchemeEntries);
			this.xtraTabPage1.Name = "xtraTabPage1";
			this.xtraTabPage1.PageEnabled = false;
			this.xtraTabPage1.PageVisible = false;
			this.xtraTabPage1.Size = new System.Drawing.Size(948, 315);
			this.xtraTabPage1.Text = "xtraTabPage1";
			// 
			// btn_Add2
			// 
			this.btn_Add2.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btn_Add2.Appearance.Options.UseFont = true;
			this.btn_Add2.Appearance.Options.UseTextOptions = true;
			this.btn_Add2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.btn_Add2.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
			this.btn_Add2.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.btn_Add2.ImageIndex = 0;
			this.btn_Add2.ImageList = this.imageList1;
			this.btn_Add2.ImeMode = System.Windows.Forms.ImeMode.On;
			this.btn_Add2.Location = new System.Drawing.Point(0, 8);
			this.btn_Add2.Name = "btn_Add2";
			this.btn_Add2.Size = new System.Drawing.Size(38, 20);
			this.btn_Add2.TabIndex = 138;
			// 
			// btn_del2
			// 
			this.btn_del2.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btn_del2.Appearance.Options.UseFont = true;
			this.btn_del2.Appearance.Options.UseTextOptions = true;
			this.btn_del2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.btn_del2.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
			this.btn_del2.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.btn_del2.ImageIndex = 1;
			this.btn_del2.ImageList = this.imageList1;
			this.btn_del2.Location = new System.Drawing.Point(40, 8);
			this.btn_del2.Name = "btn_del2";
			this.btn_del2.Size = new System.Drawing.Size(38, 20);
			this.btn_del2.TabIndex = 137;
			// 
			// gridControlMd_SalesCommisionSchemeEntries
			// 
			this.gridControlMd_SalesCommisionSchemeEntries.Dock = System.Windows.Forms.DockStyle.Bottom;
			// 
			// gridControlMd_SalesCommisionSchemeEntries.EmbeddedNavigator
			// 
			this.gridControlMd_SalesCommisionSchemeEntries.EmbeddedNavigator.Name = "";
			this.gridControlMd_SalesCommisionSchemeEntries.Location = new System.Drawing.Point(0, 131);
			this.gridControlMd_SalesCommisionSchemeEntries.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.gridControlMd_SalesCommisionSchemeEntries.LookAndFeel.UseWindowsXPTheme = false;
			this.gridControlMd_SalesCommisionSchemeEntries.MainView = this.gridViewMd_SalesCommissionSchemeEntries;
			this.gridControlMd_SalesCommisionSchemeEntries.Name = "gridControlMd_SalesCommisionSchemeEntries";
			this.gridControlMd_SalesCommisionSchemeEntries.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																																			   this.repositoryItemComboBox1});
			this.gridControlMd_SalesCommisionSchemeEntries.Size = new System.Drawing.Size(948, 184);
			this.gridControlMd_SalesCommisionSchemeEntries.TabIndex = 96;
			this.gridControlMd_SalesCommisionSchemeEntries.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																																	 this.gridViewMd_SalesCommissionSchemeEntries});
			// 
			// gridViewMd_SalesCommissionSchemeEntries
			// 
			this.gridViewMd_SalesCommissionSchemeEntries.Appearance.FocusedRow.BackColor = System.Drawing.Color.White;
			this.gridViewMd_SalesCommissionSchemeEntries.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																														   this.gridColumn17,
																														   this.gridColumnMdSCE2,
																														   this.gridColumnMdSCE3,
																														   this.gridColumnMdSCE4,
																														   this.gridColumnMdSCE5,
																														   this.gridColumnMdSCE6,
																														   this.gridColumnMdSCE7,
																														   this.gridColumnMdSCE8,
																														   this.gridColumnMdSCE9,
																														   this.gridColumnMdSCE10,
																														   this.gridColumnMdSCE11,
																														   this.gridColumnMdSCE12,
																														   this.gridColumnMdSCE13,
																														   this.gridColumnMdSCE14,
																														   this.gridColumnMdSCE15,
																														   this.gridColumnMdSCE16,
																														   this.gridColumnMdSCE17,
																														   this.gridColumnMdSCE18,
																														   this.gridColumnMdSCE19,
																														   this.gridColumnMdSCE20,
																														   this.gridColumnMdSCE21,
																														   this.gridColumn1,
																														   this.gridColumn2,
																														   this.gridColumn3,
																														   this.gridColumn4,
																														   this.gridColumn5,
																														   this.gridColumn6,
																														   this.gridColumn7,
																														   this.gridColumn8,
																														   this.gridColumn9,
																														   this.gridColumn10,
																														   this.gridColumn11,
																														   this.gridColumn12,
																														   this.gridColumn13,
																														   this.gridColumn14,
																														   this.gridColumn15,
																														   this.gridColumn16});
			this.gridViewMd_SalesCommissionSchemeEntries.GridControl = this.gridControlMd_SalesCommisionSchemeEntries;
			this.gridViewMd_SalesCommissionSchemeEntries.Name = "gridViewMd_SalesCommissionSchemeEntries";
			this.gridViewMd_SalesCommissionSchemeEntries.OptionsCustomization.AllowFilter = false;
			this.gridViewMd_SalesCommissionSchemeEntries.OptionsCustomization.AllowSort = false;
			this.gridViewMd_SalesCommissionSchemeEntries.OptionsView.ColumnAutoWidth = false;
			this.gridViewMd_SalesCommissionSchemeEntries.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn17
			// 
			this.gridColumn17.Caption = "Priority ID";
			this.gridColumn17.FieldName = "nPriorityID";
			this.gridColumn17.Name = "gridColumn17";
			this.gridColumn17.Visible = true;
			this.gridColumn17.VisibleIndex = 0;
			// 
			// gridColumnMdSCE2
			// 
			this.gridColumnMdSCE2.AppearanceCell.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.gridColumnMdSCE2.AppearanceCell.Options.UseBackColor = true;
			this.gridColumnMdSCE2.Caption = "Fitness Pkg %";
			this.gridColumnMdSCE2.DisplayFormat.FormatString = "f";
			this.gridColumnMdSCE2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumnMdSCE2.FieldName = "nFitnessPackageBranchTargetPercent";
			this.gridColumnMdSCE2.MinWidth = 30;
			this.gridColumnMdSCE2.Name = "gridColumnMdSCE2";
			this.gridColumnMdSCE2.Visible = true;
			this.gridColumnMdSCE2.VisibleIndex = 1;
			this.gridColumnMdSCE2.Width = 80;
			// 
			// gridColumnMdSCE3
			// 
			this.gridColumnMdSCE3.AppearanceCell.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.gridColumnMdSCE3.AppearanceCell.Options.UseBackColor = true;
			this.gridColumnMdSCE3.Caption = "Fitness Prod %";
			this.gridColumnMdSCE3.DisplayFormat.FormatString = "f";
			this.gridColumnMdSCE3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumnMdSCE3.FieldName = "nFitnessProductBranchTargetPercent";
			this.gridColumnMdSCE3.MinWidth = 30;
			this.gridColumnMdSCE3.Name = "gridColumnMdSCE3";
			this.gridColumnMdSCE3.Visible = true;
			this.gridColumnMdSCE3.VisibleIndex = 2;
			this.gridColumnMdSCE3.Width = 80;
			// 
			// gridColumnMdSCE4
			// 
			this.gridColumnMdSCE4.AppearanceCell.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.gridColumnMdSCE4.AppearanceCell.Options.UseBackColor = true;
			this.gridColumnMdSCE4.Caption = "SPA Pkg %";
			this.gridColumnMdSCE4.DisplayFormat.FormatString = "f";
			this.gridColumnMdSCE4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumnMdSCE4.FieldName = "nSPAPackageBranchTargetPercent";
			this.gridColumnMdSCE4.MinWidth = 30;
			this.gridColumnMdSCE4.Name = "gridColumnMdSCE4";
			this.gridColumnMdSCE4.Visible = true;
			this.gridColumnMdSCE4.VisibleIndex = 3;
			this.gridColumnMdSCE4.Width = 80;
			// 
			// gridColumnMdSCE5
			// 
			this.gridColumnMdSCE5.AppearanceCell.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.gridColumnMdSCE5.AppearanceCell.Options.UseBackColor = true;
			this.gridColumnMdSCE5.Caption = "SPA Prod %";
			this.gridColumnMdSCE5.DisplayFormat.FormatString = "f";
			this.gridColumnMdSCE5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumnMdSCE5.FieldName = "nSPAProductBranchTargetPercent";
			this.gridColumnMdSCE5.Name = "gridColumnMdSCE5";
			this.gridColumnMdSCE5.Visible = true;
			this.gridColumnMdSCE5.VisibleIndex = 4;
			this.gridColumnMdSCE5.Width = 80;
			// 
			// gridColumnMdSCE6
			// 
			this.gridColumnMdSCE6.AppearanceCell.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.gridColumnMdSCE6.AppearanceCell.Options.UseBackColor = true;
			this.gridColumnMdSCE6.Caption = "PT Pkg %";
			this.gridColumnMdSCE6.DisplayFormat.FormatString = "f";
			this.gridColumnMdSCE6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumnMdSCE6.FieldName = "nPTPackageBranchTargetPercent";
			this.gridColumnMdSCE6.Name = "gridColumnMdSCE6";
			this.gridColumnMdSCE6.Visible = true;
			this.gridColumnMdSCE6.VisibleIndex = 5;
			this.gridColumnMdSCE6.Width = 60;
			// 
			// gridColumnMdSCE7
			// 
			this.gridColumnMdSCE7.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.gridColumnMdSCE7.AppearanceCell.Options.UseBackColor = true;
			this.gridColumnMdSCE7.Caption = "Fitness Pkg %";
			this.gridColumnMdSCE7.DisplayFormat.FormatString = "f";
			this.gridColumnMdSCE7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumnMdSCE7.FieldName = "nFitnessPackageIndTargetPercent";
			this.gridColumnMdSCE7.Name = "gridColumnMdSCE7";
			this.gridColumnMdSCE7.Visible = true;
			this.gridColumnMdSCE7.VisibleIndex = 6;
			this.gridColumnMdSCE7.Width = 80;
			// 
			// gridColumnMdSCE8
			// 
			this.gridColumnMdSCE8.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.gridColumnMdSCE8.AppearanceCell.Options.UseBackColor = true;
			this.gridColumnMdSCE8.Caption = "Fitness Prod %";
			this.gridColumnMdSCE8.DisplayFormat.FormatString = "f";
			this.gridColumnMdSCE8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumnMdSCE8.FieldName = "nFitnessProductIndTargetPercent";
			this.gridColumnMdSCE8.Name = "gridColumnMdSCE8";
			this.gridColumnMdSCE8.Visible = true;
			this.gridColumnMdSCE8.VisibleIndex = 7;
			this.gridColumnMdSCE8.Width = 80;
			// 
			// gridColumnMdSCE9
			// 
			this.gridColumnMdSCE9.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.gridColumnMdSCE9.AppearanceCell.Options.UseBackColor = true;
			this.gridColumnMdSCE9.Caption = "SPA Pkg %";
			this.gridColumnMdSCE9.DisplayFormat.FormatString = "f";
			this.gridColumnMdSCE9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumnMdSCE9.FieldName = "nSPAPackageIndTargetPercent";
			this.gridColumnMdSCE9.Name = "gridColumnMdSCE9";
			this.gridColumnMdSCE9.Visible = true;
			this.gridColumnMdSCE9.VisibleIndex = 8;
			this.gridColumnMdSCE9.Width = 80;
			// 
			// gridColumnMdSCE10
			// 
			this.gridColumnMdSCE10.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.gridColumnMdSCE10.AppearanceCell.Options.UseBackColor = true;
			this.gridColumnMdSCE10.Caption = "SPA Prod %";
			this.gridColumnMdSCE10.DisplayFormat.FormatString = "f";
			this.gridColumnMdSCE10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumnMdSCE10.FieldName = "nSPAProductIndTargetPercent";
			this.gridColumnMdSCE10.Name = "gridColumnMdSCE10";
			this.gridColumnMdSCE10.Visible = true;
			this.gridColumnMdSCE10.VisibleIndex = 9;
			this.gridColumnMdSCE10.Width = 80;
			// 
			// gridColumnMdSCE11
			// 
			this.gridColumnMdSCE11.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.gridColumnMdSCE11.AppearanceCell.Options.UseBackColor = true;
			this.gridColumnMdSCE11.Caption = "PT Pkg %";
			this.gridColumnMdSCE11.DisplayFormat.FormatString = "f";
			this.gridColumnMdSCE11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumnMdSCE11.FieldName = "nPTPackageIndTargetPercent";
			this.gridColumnMdSCE11.Name = "gridColumnMdSCE11";
			this.gridColumnMdSCE11.Visible = true;
			this.gridColumnMdSCE11.VisibleIndex = 10;
			this.gridColumnMdSCE11.Width = 80;
			// 
			// gridColumnMdSCE12
			// 
			this.gridColumnMdSCE12.AppearanceCell.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.gridColumnMdSCE12.AppearanceCell.Options.UseBackColor = true;
			this.gridColumnMdSCE12.Caption = "Fitness Pkg Excess";
			this.gridColumnMdSCE12.DisplayFormat.FormatString = "f2";
			this.gridColumnMdSCE12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumnMdSCE12.FieldName = "nFitnessPackageBranchExcess";
			this.gridColumnMdSCE12.Name = "gridColumnMdSCE12";
			this.gridColumnMdSCE12.Visible = true;
			this.gridColumnMdSCE12.VisibleIndex = 11;
			this.gridColumnMdSCE12.Width = 100;
			// 
			// gridColumnMdSCE13
			// 
			this.gridColumnMdSCE13.AppearanceCell.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.gridColumnMdSCE13.AppearanceCell.Options.UseBackColor = true;
			this.gridColumnMdSCE13.Caption = "Fitness Prod Excess";
			this.gridColumnMdSCE13.DisplayFormat.FormatString = "f2";
			this.gridColumnMdSCE13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumnMdSCE13.FieldName = "nFitnessProductBranchExcess";
			this.gridColumnMdSCE13.Name = "gridColumnMdSCE13";
			this.gridColumnMdSCE13.Visible = true;
			this.gridColumnMdSCE13.VisibleIndex = 12;
			this.gridColumnMdSCE13.Width = 100;
			// 
			// gridColumnMdSCE14
			// 
			this.gridColumnMdSCE14.AppearanceCell.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.gridColumnMdSCE14.AppearanceCell.Options.UseBackColor = true;
			this.gridColumnMdSCE14.Caption = "SPA Pkg Excess";
			this.gridColumnMdSCE14.DisplayFormat.FormatString = "f2";
			this.gridColumnMdSCE14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumnMdSCE14.FieldName = "nSpaPackageBranchExcess";
			this.gridColumnMdSCE14.Name = "gridColumnMdSCE14";
			this.gridColumnMdSCE14.Visible = true;
			this.gridColumnMdSCE14.VisibleIndex = 13;
			this.gridColumnMdSCE14.Width = 90;
			// 
			// gridColumnMdSCE15
			// 
			this.gridColumnMdSCE15.AppearanceCell.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.gridColumnMdSCE15.AppearanceCell.Options.UseBackColor = true;
			this.gridColumnMdSCE15.Caption = "SPA Prod Excess";
			this.gridColumnMdSCE15.DisplayFormat.FormatString = "f2";
			this.gridColumnMdSCE15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumnMdSCE15.FieldName = "nSpaProductBranchExcess";
			this.gridColumnMdSCE15.Name = "gridColumnMdSCE15";
			this.gridColumnMdSCE15.Visible = true;
			this.gridColumnMdSCE15.VisibleIndex = 14;
			this.gridColumnMdSCE15.Width = 90;
			// 
			// gridColumnMdSCE16
			// 
			this.gridColumnMdSCE16.AppearanceCell.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.gridColumnMdSCE16.AppearanceCell.Options.UseBackColor = true;
			this.gridColumnMdSCE16.Caption = "PT Pkg Excess";
			this.gridColumnMdSCE16.DisplayFormat.FormatString = "f2";
			this.gridColumnMdSCE16.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumnMdSCE16.FieldName = "nPTPackageBranchExcess";
			this.gridColumnMdSCE16.Name = "gridColumnMdSCE16";
			this.gridColumnMdSCE16.Visible = true;
			this.gridColumnMdSCE16.VisibleIndex = 15;
			this.gridColumnMdSCE16.Width = 90;
			// 
			// gridColumnMdSCE17
			// 
			this.gridColumnMdSCE17.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.gridColumnMdSCE17.AppearanceCell.Options.UseBackColor = true;
			this.gridColumnMdSCE17.Caption = "Fitness Pkg Excess";
			this.gridColumnMdSCE17.DisplayFormat.FormatString = "f2";
			this.gridColumnMdSCE17.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumnMdSCE17.FieldName = "nFitnessPackageIndExcess";
			this.gridColumnMdSCE17.Name = "gridColumnMdSCE17";
			this.gridColumnMdSCE17.Visible = true;
			this.gridColumnMdSCE17.VisibleIndex = 16;
			this.gridColumnMdSCE17.Width = 100;
			// 
			// gridColumnMdSCE18
			// 
			this.gridColumnMdSCE18.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.gridColumnMdSCE18.AppearanceCell.Options.UseBackColor = true;
			this.gridColumnMdSCE18.Caption = "Fitness Prod Excess";
			this.gridColumnMdSCE18.DisplayFormat.FormatString = "f2";
			this.gridColumnMdSCE18.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumnMdSCE18.FieldName = "nFitnessProductIndExcess";
			this.gridColumnMdSCE18.Name = "gridColumnMdSCE18";
			this.gridColumnMdSCE18.Visible = true;
			this.gridColumnMdSCE18.VisibleIndex = 17;
			this.gridColumnMdSCE18.Width = 90;
			// 
			// gridColumnMdSCE19
			// 
			this.gridColumnMdSCE19.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.gridColumnMdSCE19.AppearanceCell.Options.UseBackColor = true;
			this.gridColumnMdSCE19.Caption = "SPA Pkg Excess";
			this.gridColumnMdSCE19.DisplayFormat.FormatString = "f2";
			this.gridColumnMdSCE19.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumnMdSCE19.FieldName = "nSPAPackageIndExcess";
			this.gridColumnMdSCE19.Name = "gridColumnMdSCE19";
			this.gridColumnMdSCE19.Visible = true;
			this.gridColumnMdSCE19.VisibleIndex = 18;
			this.gridColumnMdSCE19.Width = 90;
			// 
			// gridColumnMdSCE20
			// 
			this.gridColumnMdSCE20.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.gridColumnMdSCE20.AppearanceCell.Options.UseBackColor = true;
			this.gridColumnMdSCE20.Caption = "SPA Prod Excess";
			this.gridColumnMdSCE20.DisplayFormat.FormatString = "f2";
			this.gridColumnMdSCE20.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumnMdSCE20.FieldName = "nSPAProductIndExcess";
			this.gridColumnMdSCE20.Name = "gridColumnMdSCE20";
			this.gridColumnMdSCE20.Visible = true;
			this.gridColumnMdSCE20.VisibleIndex = 19;
			this.gridColumnMdSCE20.Width = 90;
			// 
			// gridColumnMdSCE21
			// 
			this.gridColumnMdSCE21.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.gridColumnMdSCE21.AppearanceCell.Options.UseBackColor = true;
			this.gridColumnMdSCE21.Caption = "PT Pkg Excess";
			this.gridColumnMdSCE21.DisplayFormat.FormatString = "f2";
			this.gridColumnMdSCE21.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumnMdSCE21.FieldName = "nPTPackageIndExcess";
			this.gridColumnMdSCE21.Name = "gridColumnMdSCE21";
			this.gridColumnMdSCE21.Visible = true;
			this.gridColumnMdSCE21.VisibleIndex = 20;
			this.gridColumnMdSCE21.Width = 90;
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "Fitness Pkg Branch Comm %";
			this.gridColumn1.DisplayFormat.FormatString = "f";
			this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumn1.FieldName = "nFitnessPackageBranchPercentComm";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 21;
			this.gridColumn1.Width = 150;
			// 
			// gridColumn2
			// 
			this.gridColumn2.Caption = "Fitness Prod Branch Comm %";
			this.gridColumn2.DisplayFormat.FormatString = "f";
			this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumn2.FieldName = "nFitnessProductBranchPercentComm";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 22;
			this.gridColumn2.Width = 150;
			// 
			// gridColumn3
			// 
			this.gridColumn3.Caption = "SPA Pkg Branch Comm %";
			this.gridColumn3.DisplayFormat.FormatString = "f";
			this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumn3.FieldName = "nSpaPackageBranchPercentComm";
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 23;
			this.gridColumn3.Width = 150;
			// 
			// gridColumn4
			// 
			this.gridColumn4.Caption = "SPA Prod Branch Comm %";
			this.gridColumn4.DisplayFormat.FormatString = "f";
			this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumn4.FieldName = "nSpaProductBranchPercentComm";
			this.gridColumn4.Name = "gridColumn4";
			this.gridColumn4.Visible = true;
			this.gridColumn4.VisibleIndex = 24;
			this.gridColumn4.Width = 150;
			// 
			// gridColumn5
			// 
			this.gridColumn5.Caption = "PT Pkg Branch Comm %";
			this.gridColumn5.DisplayFormat.FormatString = "f";
			this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumn5.FieldName = "nPTPackageBranchPercentComm";
			this.gridColumn5.Name = "gridColumn5";
			this.gridColumn5.Visible = true;
			this.gridColumn5.VisibleIndex = 25;
			this.gridColumn5.Width = 150;
			// 
			// gridColumn6
			// 
			this.gridColumn6.Caption = "Fitness Pkg Branch Shared Comm %";
			this.gridColumn6.DisplayFormat.FormatString = "f";
			this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumn6.FieldName = "nFitnessPackageBranchPercentSharedComm";
			this.gridColumn6.Name = "gridColumn6";
			this.gridColumn6.Visible = true;
			this.gridColumn6.VisibleIndex = 26;
			this.gridColumn6.Width = 130;
			// 
			// gridColumn7
			// 
			this.gridColumn7.Caption = "Fitness Prod Branch Shared Comm %";
			this.gridColumn7.DisplayFormat.FormatString = "f";
			this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumn7.FieldName = "nFitnessProductBranchPercentSharedComm";
			this.gridColumn7.Name = "gridColumn7";
			this.gridColumn7.Visible = true;
			this.gridColumn7.VisibleIndex = 27;
			this.gridColumn7.Width = 130;
			// 
			// gridColumn8
			// 
			this.gridColumn8.Caption = "SPA Pkg Branch Shared Comm %";
			this.gridColumn8.DisplayFormat.FormatString = "f";
			this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumn8.FieldName = "nSpaPackageBranchPercentSharedComm";
			this.gridColumn8.Name = "gridColumn8";
			this.gridColumn8.Visible = true;
			this.gridColumn8.VisibleIndex = 28;
			this.gridColumn8.Width = 130;
			// 
			// gridColumn9
			// 
			this.gridColumn9.Caption = "SPA Prod Branch Shared Comm %";
			this.gridColumn9.DisplayFormat.FormatString = "f";
			this.gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumn9.FieldName = "nSpaProductBranchPercentSharedComm";
			this.gridColumn9.Name = "gridColumn9";
			this.gridColumn9.Visible = true;
			this.gridColumn9.VisibleIndex = 29;
			this.gridColumn9.Width = 130;
			// 
			// gridColumn10
			// 
			this.gridColumn10.Caption = "PT Pkg Branch Shared Comm %";
			this.gridColumn10.DisplayFormat.FormatString = "f";
			this.gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumn10.FieldName = "nPTPackageBranchPercentSharedComm";
			this.gridColumn10.Name = "gridColumn10";
			this.gridColumn10.Visible = true;
			this.gridColumn10.VisibleIndex = 30;
			this.gridColumn10.Width = 130;
			// 
			// gridColumn11
			// 
			this.gridColumn11.Caption = "Fitness Pkg Branch Individual Comm %";
			this.gridColumn11.DisplayFormat.FormatString = "f";
			this.gridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumn11.FieldName = "nFitnessPackageIndPercentComm";
			this.gridColumn11.Name = "gridColumn11";
			this.gridColumn11.Visible = true;
			this.gridColumn11.VisibleIndex = 31;
			this.gridColumn11.Width = 140;
			// 
			// gridColumn12
			// 
			this.gridColumn12.Caption = "Fitness Prod Branch Individual Comm %";
			this.gridColumn12.DisplayFormat.FormatString = "f";
			this.gridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumn12.FieldName = "nFitnessProductIndPercentComm";
			this.gridColumn12.Name = "gridColumn12";
			this.gridColumn12.Visible = true;
			this.gridColumn12.VisibleIndex = 32;
			this.gridColumn12.Width = 140;
			// 
			// gridColumn13
			// 
			this.gridColumn13.Caption = "SPA Pkg Branch Individual Comm %";
			this.gridColumn13.DisplayFormat.FormatString = "f";
			this.gridColumn13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumn13.FieldName = "nSpaPackageIndPercentComm";
			this.gridColumn13.Name = "gridColumn13";
			this.gridColumn13.Visible = true;
			this.gridColumn13.VisibleIndex = 33;
			this.gridColumn13.Width = 140;
			// 
			// gridColumn14
			// 
			this.gridColumn14.Caption = "SPA Prod Branch Individual Comm %";
			this.gridColumn14.DisplayFormat.FormatString = "f";
			this.gridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumn14.FieldName = "nSpaProductIndPercentComm";
			this.gridColumn14.Name = "gridColumn14";
			this.gridColumn14.Visible = true;
			this.gridColumn14.VisibleIndex = 34;
			this.gridColumn14.Width = 140;
			// 
			// gridColumn15
			// 
			this.gridColumn15.Caption = "PT Pkg Branch Individual Comm %";
			this.gridColumn15.DisplayFormat.FormatString = "f";
			this.gridColumn15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumn15.FieldName = "nPTPackageIndPercentComm";
			this.gridColumn15.Name = "gridColumn15";
			this.gridColumn15.Visible = true;
			this.gridColumn15.VisibleIndex = 35;
			this.gridColumn15.Width = 140;
			// 
			// gridColumn16
			// 
			this.gridColumn16.Caption = "Commission Amount";
			this.gridColumn16.DisplayFormat.FormatString = "f2";
			this.gridColumn16.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.gridColumn16.FieldName = "mCommissionAmount";
			this.gridColumn16.Name = "gridColumn16";
			this.gridColumn16.Visible = true;
			this.gridColumn16.VisibleIndex = 36;
			// 
			// repositoryItemComboBox1
			// 
			this.repositoryItemComboBox1.AutoHeight = false;
			this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemComboBox1.DisplayFormat.FormatString = "f";
			this.repositoryItemComboBox1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.repositoryItemComboBox1.EditFormat.FormatString = "f";
			this.repositoryItemComboBox1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.repositoryItemComboBox1.Items.AddRange(new object[] {
																		 "1",
																		 "2",
																		 "3",
																		 "4",
																		 "5"});
			this.repositoryItemComboBox1.Mask.EditMask = "f";
			this.repositoryItemComboBox1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
			// 
			// mdCM_tabInstructorCommision
			// 
			this.mdCM_tabInstructorCommision.Controls.Add(this.tabControlInstructorCommission);
			this.mdCM_tabInstructorCommision.Name = "mdCM_tabInstructorCommision";
			this.mdCM_tabInstructorCommision.Size = new System.Drawing.Size(954, 483);
			this.mdCM_tabInstructorCommision.Text = "Instructor Commission";
			// 
			// tabControlInstructorCommission
			// 
			this.tabControlInstructorCommission.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.tabControlInstructorCommission.Appearance.Options.UseBackColor = true;
			this.tabControlInstructorCommission.AppearancePage.Header.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tabControlInstructorCommission.AppearancePage.Header.Options.UseFont = true;
			this.tabControlInstructorCommission.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlInstructorCommission.Location = new System.Drawing.Point(0, 0);
			this.tabControlInstructorCommission.LookAndFeel.SkinName = "Coffee";
			this.tabControlInstructorCommission.LookAndFeel.UseWindowsXPTheme = false;
			this.tabControlInstructorCommission.Name = "tabControlInstructorCommission";
			this.tabControlInstructorCommission.SelectedTabPage = this.tabPageInstructorType;
			this.tabControlInstructorCommission.Size = new System.Drawing.Size(954, 483);
			this.tabControlInstructorCommission.TabIndex = 1;
			this.tabControlInstructorCommission.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
																										   this.tabPageInstructorType,
																										   this.tabPageInstructorComm,
																										   this.tabPageInstructorTypeComm});
			this.tabControlInstructorCommission.Text = "xtraTabControl2";
			this.tabControlInstructorCommission.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.tabControlInstructorCommission_SelectedPageChanged);
			// 
			// tabPageInstructorType
			// 
			this.tabPageInstructorType.Controls.Add(this.gridControlMd_InstructorType);
			this.tabPageInstructorType.Name = "tabPageInstructorType";
			this.tabPageInstructorType.Size = new System.Drawing.Size(948, 442);
			this.tabPageInstructorType.Text = "Instructor Type";
			// 
			// gridControlMd_InstructorType
			// 
			this.gridControlMd_InstructorType.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// gridControlMd_InstructorType.EmbeddedNavigator
			// 
			this.gridControlMd_InstructorType.EmbeddedNavigator.Name = "";
			this.gridControlMd_InstructorType.Location = new System.Drawing.Point(0, 0);
			this.gridControlMd_InstructorType.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.gridControlMd_InstructorType.LookAndFeel.UseWindowsXPTheme = false;
			this.gridControlMd_InstructorType.MainView = this.gridViewMdInstructor;
			this.gridControlMd_InstructorType.Name = "gridControlMd_InstructorType";
			this.gridControlMd_InstructorType.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																																  this.repositoryItemComboBox2,
																																  this.repositoryItemImageComboBox1});
			this.gridControlMd_InstructorType.Size = new System.Drawing.Size(948, 442);
			this.gridControlMd_InstructorType.TabIndex = 15;
			this.gridControlMd_InstructorType.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																														this.gridViewMdInstructor});
			// 
			// gridViewMdInstructor
			// 
			this.gridViewMdInstructor.ActiveFilterEnabled = false;
			this.gridViewMdInstructor.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																										this.gridColumnMdIT1,
																										this.gridColumnMdIT2,
																										this.gridColumnMdIT3});
			this.gridViewMdInstructor.GridControl = this.gridControlMd_InstructorType;
			this.gridViewMdInstructor.Name = "gridViewMdInstructor";
			this.gridViewMdInstructor.OptionsCustomization.AllowFilter = false;
			this.gridViewMdInstructor.OptionsCustomization.AllowSort = false;
			this.gridViewMdInstructor.OptionsView.ShowGroupPanel = false;
			this.gridViewMdInstructor.LostFocus += new System.EventHandler(this.gridViewMdInstructor_LostFocus);
			// 
			// gridColumnMdIT1
			// 
			this.gridColumnMdIT1.Caption = "Instructor Type";
			this.gridColumnMdIT1.FieldName = "nInstructorTypeID";
			this.gridColumnMdIT1.Name = "gridColumnMdIT1";
			this.gridColumnMdIT1.Visible = true;
			this.gridColumnMdIT1.VisibleIndex = 0;
			// 
			// gridColumnMdIT2
			// 
			this.gridColumnMdIT2.Caption = "Name";
			this.gridColumnMdIT2.FieldName = "strDescription";
			this.gridColumnMdIT2.MinWidth = 40;
			this.gridColumnMdIT2.Name = "gridColumnMdIT2";
			this.gridColumnMdIT2.Visible = true;
			this.gridColumnMdIT2.VisibleIndex = 2;
			// 
			// gridColumnMdIT3
			// 
			this.gridColumnMdIT3.Caption = "Bonus Type ID";
			this.gridColumnMdIT3.ColumnEdit = this.repositoryItemImageComboBox1;
			this.gridColumnMdIT3.FieldName = "nBonusTypeID";
			this.gridColumnMdIT3.Name = "gridColumnMdIT3";
			this.gridColumnMdIT3.Visible = true;
			this.gridColumnMdIT3.VisibleIndex = 1;
			// 
			// repositoryItemImageComboBox1
			// 
			this.repositoryItemImageComboBox1.AutoHeight = false;
			this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemImageComboBox1.Items.AddRange(new object[] {
																			  new DevExpress.XtraEditors.Controls.ImageComboBoxItem("No Bonus", 0, -1),
																			  new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Extra for All Permenant Class", 1, -1),
																			  new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Extra for All Class Taught", 2, -1)});
			this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
			// 
			// repositoryItemComboBox2
			// 
			this.repositoryItemComboBox2.AutoHeight = false;
			this.repositoryItemComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemComboBox2.Name = "repositoryItemComboBox2";
			// 
			// tabPageInstructorComm
			// 
			this.tabPageInstructorComm.Controls.Add(this.gridControlMd_InstructorCommission);
			this.tabPageInstructorComm.Name = "tabPageInstructorComm";
			this.tabPageInstructorComm.Size = new System.Drawing.Size(948, 442);
			this.tabPageInstructorComm.Text = "Commission";
			// 
			// gridControlMd_InstructorCommission
			// 
			this.gridControlMd_InstructorCommission.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// gridControlMd_InstructorCommission.EmbeddedNavigator
			// 
			this.gridControlMd_InstructorCommission.EmbeddedNavigator.Name = "";
			this.gridControlMd_InstructorCommission.Location = new System.Drawing.Point(0, 0);
			this.gridControlMd_InstructorCommission.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.gridControlMd_InstructorCommission.LookAndFeel.UseWindowsXPTheme = false;
			this.gridControlMd_InstructorCommission.MainView = this.gridViewMdIC;
			this.gridControlMd_InstructorCommission.Name = "gridControlMd_InstructorCommission";
			this.gridControlMd_InstructorCommission.Size = new System.Drawing.Size(948, 442);
			this.gridControlMd_InstructorCommission.TabIndex = 14;
			this.gridControlMd_InstructorCommission.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																															  this.gridViewMdIC});
			// 
			// gridViewMdIC
			// 
			this.gridViewMdIC.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																								this.gridColumnMdIC1,
																								this.gridColumnMdIC2});
			this.gridViewMdIC.GridControl = this.gridControlMd_InstructorCommission;
			this.gridViewMdIC.Name = "gridViewMdIC";
			this.gridViewMdIC.OptionsCustomization.AllowFilter = false;
			this.gridViewMdIC.OptionsCustomization.AllowSort = false;
			this.gridViewMdIC.OptionsView.ShowGroupPanel = false;
			this.gridViewMdIC.LostFocus += new System.EventHandler(this.gridViewMdIC_LostFocus);
			// 
			// gridColumnMdIC1
			// 
			this.gridColumnMdIC1.Caption = "Commission Code";
			this.gridColumnMdIC1.FieldName = "nCommissionTypeID";
			this.gridColumnMdIC1.Name = "gridColumnMdIC1";
			this.gridColumnMdIC1.Visible = true;
			this.gridColumnMdIC1.VisibleIndex = 0;
			// 
			// gridColumnMdIC2
			// 
			this.gridColumnMdIC2.Caption = "Description";
			this.gridColumnMdIC2.FieldName = "strDescription";
			this.gridColumnMdIC2.Name = "gridColumnMdIC2";
			this.gridColumnMdIC2.Visible = true;
			this.gridColumnMdIC2.VisibleIndex = 1;
			// 
			// tabPageInstructorTypeComm
			// 
			this.tabPageInstructorTypeComm.Appearance.PageClient.BackColor = System.Drawing.SystemColors.Control;
			this.tabPageInstructorTypeComm.Appearance.PageClient.Options.UseBackColor = true;
			this.tabPageInstructorTypeComm.Controls.Add(this.gridControlMd_InstructorTypeCommission);
			this.tabPageInstructorTypeComm.Name = "tabPageInstructorTypeComm";
			this.tabPageInstructorTypeComm.Size = new System.Drawing.Size(948, 442);
			this.tabPageInstructorTypeComm.Text = "Instructor Type Commission";
			// 
			// gridControlMd_InstructorTypeCommission
			// 
			this.gridControlMd_InstructorTypeCommission.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// gridControlMd_InstructorTypeCommission.EmbeddedNavigator
			// 
			this.gridControlMd_InstructorTypeCommission.EmbeddedNavigator.Name = "";
			this.gridControlMd_InstructorTypeCommission.Location = new System.Drawing.Point(0, 0);
			this.gridControlMd_InstructorTypeCommission.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.gridControlMd_InstructorTypeCommission.LookAndFeel.UseWindowsXPTheme = false;
			this.gridControlMd_InstructorTypeCommission.MainView = this.gridViewMdITC;
			this.gridControlMd_InstructorTypeCommission.Name = "gridControlMd_InstructorTypeCommission";
			this.gridControlMd_InstructorTypeCommission.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																																			this.repositoryItemLookUpEdit1,
																																			this.repositoryItemLookUpEdit2});
			this.gridControlMd_InstructorTypeCommission.Size = new System.Drawing.Size(948, 442);
			this.gridControlMd_InstructorTypeCommission.TabIndex = 14;
			this.gridControlMd_InstructorTypeCommission.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																																  this.gridViewMdITC});
			// 
			// gridViewMdITC
			// 
			this.gridViewMdITC.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																								 this.gridColumnMdITC1,
																								 this.gridColumnMdITC2,
																								 this.gridColumnMdITC3});
			this.gridViewMdITC.GridControl = this.gridControlMd_InstructorTypeCommission;
			this.gridViewMdITC.Name = "gridViewMdITC";
			this.gridViewMdITC.OptionsCustomization.AllowFilter = false;
			this.gridViewMdITC.OptionsCustomization.AllowSort = false;
			this.gridViewMdITC.OptionsView.ShowGroupPanel = false;
			this.gridViewMdITC.LostFocus += new System.EventHandler(this.gridViewMdITC_LostFocus);
			// 
			// gridColumnMdITC1
			// 
			this.gridColumnMdITC1.Caption = "Instructor Type";
			this.gridColumnMdITC1.ColumnEdit = this.repositoryItemLookUpEdit1;
			this.gridColumnMdITC1.FieldName = "nInstructorTypeID";
			this.gridColumnMdITC1.Name = "gridColumnMdITC1";
			this.gridColumnMdITC1.Visible = true;
			this.gridColumnMdITC1.VisibleIndex = 0;
			// 
			// repositoryItemLookUpEdit1
			// 
			this.repositoryItemLookUpEdit1.AutoHeight = false;
			this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
			// 
			// gridColumnMdITC2
			// 
			this.gridColumnMdITC2.Caption = "Commission Type";
			this.gridColumnMdITC2.ColumnEdit = this.repositoryItemLookUpEdit2;
			this.gridColumnMdITC2.FieldName = "nCommissionTypeID";
			this.gridColumnMdITC2.Name = "gridColumnMdITC2";
			this.gridColumnMdITC2.Visible = true;
			this.gridColumnMdITC2.VisibleIndex = 1;
			// 
			// repositoryItemLookUpEdit2
			// 
			this.repositoryItemLookUpEdit2.AutoHeight = false;
			this.repositoryItemLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemLookUpEdit2.Name = "repositoryItemLookUpEdit2";
			// 
			// gridColumnMdITC3
			// 
			this.gridColumnMdITC3.Caption = "Commission Amount";
			this.gridColumnMdITC3.FieldName = "mCommissionAmount";
			this.gridColumnMdITC3.Name = "gridColumnMdITC3";
			this.gridColumnMdITC3.Visible = true;
			this.gridColumnMdITC3.VisibleIndex = 2;
			// 
			// mdCM_tabPTCommision
			// 
			this.mdCM_tabPTCommision.Controls.Add(this.gridControlMd_PTCommission);
			this.mdCM_tabPTCommision.Name = "mdCM_tabPTCommision";
			this.mdCM_tabPTCommision.Size = new System.Drawing.Size(954, 483);
			this.mdCM_tabPTCommision.Text = "PT Commission";
			// 
			// gridControlMd_PTCommission
			// 
			this.gridControlMd_PTCommission.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// gridControlMd_PTCommission.EmbeddedNavigator
			// 
			this.gridControlMd_PTCommission.EmbeddedNavigator.Name = "";
			this.gridControlMd_PTCommission.Location = new System.Drawing.Point(0, 0);
			this.gridControlMd_PTCommission.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.gridControlMd_PTCommission.LookAndFeel.UseWindowsXPTheme = false;
			this.gridControlMd_PTCommission.MainView = this.gridViewPTCommission;
			this.gridControlMd_PTCommission.Name = "gridControlMd_PTCommission";
			this.gridControlMd_PTCommission.Size = new System.Drawing.Size(954, 483);
			this.gridControlMd_PTCommission.TabIndex = 15;
			this.gridControlMd_PTCommission.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																													  this.gridViewPTCommission,
																													  this.gridView2});
			// 
			// gridViewPTCommission
			// 
			this.gridViewPTCommission.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																										this.gridColumnPT1,
																										this.gridColumnPT2,
																										this.gridColumnPT3});
			this.gridViewPTCommission.GridControl = this.gridControlMd_PTCommission;
			this.gridViewPTCommission.Name = "gridViewPTCommission";
			this.gridViewPTCommission.OptionsCustomization.AllowFilter = false;
			this.gridViewPTCommission.OptionsCustomization.AllowSort = false;
			this.gridViewPTCommission.OptionsView.ShowGroupPanel = false;
			this.gridViewPTCommission.LostFocus += new System.EventHandler(this.gridViewPTCommission_LostFocus);
			// 
			// gridColumnPT1
			// 
			this.gridColumnPT1.Caption = "Lower Limit";
			this.gridColumnPT1.DisplayFormat.FormatString = "f2";
			this.gridColumnPT1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumnPT1.FieldName = "nLowerLimit";
			this.gridColumnPT1.Name = "gridColumnPT1";
			this.gridColumnPT1.Visible = true;
			this.gridColumnPT1.VisibleIndex = 0;
			// 
			// gridColumnPT2
			// 
			this.gridColumnPT2.Caption = "Upper Limit";
			this.gridColumnPT2.DisplayFormat.FormatString = "f2";
			this.gridColumnPT2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumnPT2.FieldName = "nUpperLimit";
			this.gridColumnPT2.Name = "gridColumnPT2";
			this.gridColumnPT2.Visible = true;
			this.gridColumnPT2.VisibleIndex = 1;
			// 
			// gridColumnPT3
			// 
			this.gridColumnPT3.Caption = "Service Commission";
			this.gridColumnPT3.DisplayFormat.FormatString = "f2";
			this.gridColumnPT3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumnPT3.FieldName = "mServiceCommission";
			this.gridColumnPT3.Name = "gridColumnPT3";
			this.gridColumnPT3.Visible = true;
			this.gridColumnPT3.VisibleIndex = 2;
			// 
			// gridView2
			// 
			this.gridView2.GridControl = this.gridControlMd_PTCommission;
			this.gridView2.Name = "gridView2";
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
			this.btn_Add.Location = new System.Drawing.Point(16, 24);
			this.btn_Add.Name = "btn_Add";
			this.btn_Add.Size = new System.Drawing.Size(38, 16);
			this.btn_Add.TabIndex = 134;
			this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
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
			this.btn_Del.Location = new System.Drawing.Point(56, 24);
			this.btn_Del.Name = "btn_Del";
			this.btn_Del.Size = new System.Drawing.Size(38, 16);
			this.btn_Del.TabIndex = 133;
			this.btn_Del.Click += new System.EventHandler(this.btn_Del_Click);
			// 
			// panelSalesCommission
			// 
			this.panelSalesCommission.BackColor = System.Drawing.Color.Transparent;
			this.panelSalesCommission.Controls.Add(this.cmbYear);
			this.panelSalesCommission.Controls.Add(this.label12);
			this.panelSalesCommission.Controls.Add(this.lkBranch);
			this.panelSalesCommission.Controls.Add(this.label3);
			this.panelSalesCommission.Controls.Add(this.btn_Search);
			this.panelSalesCommission.Location = new System.Drawing.Point(176, 16);
			this.panelSalesCommission.Name = "panelSalesCommission";
			this.panelSalesCommission.Size = new System.Drawing.Size(792, 32);
			this.panelSalesCommission.TabIndex = 220;
			// 
			// cmbYear
			// 
			this.cmbYear.Location = new System.Drawing.Point(640, 8);
			this.cmbYear.Name = "cmbYear";
			// 
			// cmbYear.Properties
			// 
			this.cmbYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cmbYear.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.cmbYear.Size = new System.Drawing.Size(48, 20);
			this.cmbYear.TabIndex = 221;
			// 
			// label12
			// 
			this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label12.Location = new System.Drawing.Point(600, 12);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(40, 16);
			this.label12.TabIndex = 220;
			this.label12.Text = "Year";
			// 
			// lkBranch
			// 
			this.lkBranch.Location = new System.Drawing.Point(472, 8);
			this.lkBranch.Name = "lkBranch";
			// 
			// lkBranch.Properties
			// 
			this.lkBranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkBranch.Size = new System.Drawing.Size(112, 20);
			this.lkBranch.TabIndex = 149;
			this.lkBranch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Branch_KeyDown);
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(392, 12);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 16);
			this.label3.TabIndex = 148;
			this.label3.Text = "Branch";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btn_Search
			// 
			this.btn_Search.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.btn_Search.Appearance.Options.UseFont = true;
			this.btn_Search.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btn_Search.Location = new System.Drawing.Point(712, 8);
			this.btn_Search.Name = "btn_Search";
			this.btn_Search.Size = new System.Drawing.Size(56, 20);
			this.btn_Search.TabIndex = 219;
			this.btn_Search.Text = "Search";
			this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
			// 
			// frmCommission
			// 
			this.AutoScale = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(1000, 560);
			this.Controls.Add(this.grpMDCommision);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmCommission";
			this.Text = "frmCommission";
			this.Load += new System.EventHandler(this.frmCommission_Load);
			((System.ComponentModel.ISupportInitialize)(this.grpMDCommision)).EndInit();
			this.grpMDCommision.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.tabControlCommission)).EndInit();
			this.tabControlCommission.ResumeLayout(false);
			this.mdCM_tabSalesCommision.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grpSubMDCommissionScheme)).EndInit();
			this.grpSubMDCommissionScheme.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControlMd_SalesCommisionScheme)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewMd_SalesCommission)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_CalMethod)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chk_CrossSales)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mdSC_txtNEmployeeID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tabControlCommissionEntry)).EndInit();
			this.tabControlCommissionEntry.ResumeLayout(false);
			this.tabMethodOne.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grpMDPromotionBelow2)).EndInit();
			this.grpMDPromotionBelow2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridCategory2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewCategory2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridCategory)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewCategory)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridTarget)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewTarget)).EndInit();
			this.tabMethodTwo.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridRange)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewRange)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chk_fCombine)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
			this.groupControl2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grid2Category2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2Category2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid2Category)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2Category)).EndInit();
			this.tabMethodThree.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridMgr)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewMgr)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chk_fCombine_Mgr)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
			this.groupControl3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grid3Category2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView3Category2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid3Category)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView3Category)).EndInit();
			this.xtraTabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControlMd_SalesCommisionSchemeEntries)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewMd_SalesCommissionSchemeEntries)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
			this.mdCM_tabInstructorCommision.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.tabControlInstructorCommission)).EndInit();
			this.tabControlInstructorCommission.ResumeLayout(false);
			this.tabPageInstructorType.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControlMd_InstructorType)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewMdInstructor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).EndInit();
			this.tabPageInstructorComm.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControlMd_InstructorCommission)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewMdIC)).EndInit();
			this.tabPageInstructorTypeComm.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControlMd_InstructorTypeCommission)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewMdITC)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).EndInit();
			this.mdCM_tabPTCommision.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControlMd_PTCommission)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewPTCommission)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
			this.panelSalesCommission.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.cmbYear.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkBranch.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion


		private void frmCommission_Load(object sender, System.EventArgs e)
		{
			if (tabControlCommission.SelectedTabPage.Text == "Sales Commission")
			{
				Set_SalesCommissionInit();
				mdSalesCommissionInit();
			}
		}


		private void Set_SalesCommissionInit()
		{			
			lkBranch.Text=oUser.StrBranchCode();

			string strSQL = "Select strBranchCode,strBranchName from tblBranch";
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			new ManagerBranchCodeLookupEditBuilder(_ds.Tables["table"], lkBranch.Properties);

			strSQL = "select distinct year(dtfrom) as nYear from tblcommgroup";

			comboBind(cmbYear, strSQL, "nYear", "nYear", true);
				
			cmbYear.SelectedIndex = 0;
			if (cmbYear.SelectedIndex == -1)
				this.cmbYear.Properties.Items.Insert(0,new DevExpress.XtraEditors.Controls.ImageComboBoxItem(DateTime.Today.Year.ToString(),""));
			cmbYear.SelectedIndex = 0;
		
			lk_CalMethod_Init();
		}

		#region Commission Init
		
		private void mdSalesCommissionInit()
		{
			string strSQL="select * from tblcommgroup where strBranchCode='" + lkBranch.Text + "' and (year(dtfrom) ='"+ cmbYear.Text +"' or year(dtTo) ='"+ cmbYear.Text + "')";
			DataSet _ds = new DataSet();
	
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dtSalesCommission = _ds.Tables["table"];
			this.gridControlMd_SalesCommisionScheme.DataSource = dtSalesCommission;
		}

		private void lk_CalMethod_Init()
		{
			DataSet _ds = new DataSet();
			string strSQL;
			
			strSQL = "select * from tblCommCalculation";
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			DataTable dt = _ds.Tables["table"];
						
			DevExpress.XtraEditors.Controls.LookUpColumnInfo[] col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
						
			col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nCalMethod","Method ID",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription","Description",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
					
			new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(lk_CalMethod,dt,col,"strDescription","nCalMethod","Method");
		}

		private void mdSalesCommissionEntriesInit(string sc)
		{
			string strSQL = "select * from tblCommissionSchemeEntries where strCommissionCode='" + sc + "'";
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dtSalesCommissionEntries = _ds.Tables["table"];
			gridControlMd_SalesCommisionSchemeEntries.DataSource = dtSalesCommissionEntries;
		}

		private void mdInstructorTypeInit()
		{
			string strSQL = "select * from tblInstructorType";
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dtInstructor = _ds.Tables["table"];
			gridControlMd_InstructorType.DataSource =dtInstructor;
			
		}
		private void mdInstructorCommissionInit()
		{
			string strSQL;
			DataSet _ds;
			strSQL = "select * from tblInstructorCommission";
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dtCommission=_ds.Tables["table"];
			gridControlMd_InstructorCommission.DataSource = dtCommission;

			
		}
		private void mdInstructorTypeCommissionInit()
		{
			DataTable dt;
			DataSet _ds;

			_ds = new DataSet(); 
			string strSQL = "select * from tblInstructorCommission";
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			dt = _ds.Tables["Table"];
			DevExpress.XtraEditors.Controls.LookUpColumnInfo[] col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
			col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nCommissionTypeID","Commission Type ID",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription","Description",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			myManager = new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(repositoryItemLookUpEdit2,dt,col,"strDescription","nCommissionTypeID","Manager");

			_ds = new DataSet(); 
			strSQL = "select * from tblInstructorType";
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			dt = _ds.Tables["Table"];
			DevExpress.XtraEditors.Controls.LookUpColumnInfo[] col1 = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
			col1[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nInstructorTypeID","Instructor Type ID",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			col1[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription","Description",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			myManager = new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(repositoryItemLookUpEdit1,dt,col1,"strDescription","nInstructorTypeID","Manager");

			
			strSQL = "select A.*,B.strDescription as strITDescription, C.strDescription as strCommDescription from tblInstructorTypeCommission A join tblInstructorType B on A.nInstructorTypeID=B.nInstructorTypeID join tblInstructorCommission C on A.nCommissionTypeID=C.nCommissionTypeID";
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dtInstructorCommission=_ds.Tables["table"];
			gridControlMd_InstructorTypeCommission.DataSource = dtInstructorCommission;
	
		
		}

		private void mdPTCommissionInit()
		{
			string strSQL = "select * from tblPTCommLevel";
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dtPTCommission = _ds.Tables["table"];
			gridControlMd_PTCommission.DataSource = dtPTCommission;
		}

			
		#endregion

		#region common
		public void CreateCmdsAndUpdate(string mySelectQuery,DataTable myTableName) 
		{
			try
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
			catch(Exception e)
			{
				
				return;
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

		#region security
		public void initData (ACMSLogic.User User)
		{
			oUser = User;
			MemberRecord myMemberRecord = new MemberRecord(oUser.StrBranchCode());
		}

		public void SetEmployeeRecord(Do.Employee employee)
		{
			this.employee = employee;
		}

		public void SetTerminalUser(Do.TerminalUser terminalUser)
		{
			this.terminalUser = terminalUser;

		}

		
		#endregion


		public string fMode
		{
			get
			{
				return _mode;
			}
			set
			{
				_mode = value;
			}
		}

		private void tabControlCommission_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
		{
			
			if (tabControlCommission.SelectedTabPage.Text == "Sales Commission")
			{
				mdSalesCommissionInit();
			}
			else if (tabControlCommission.SelectedTabPage.Text == "Instructor Commission")
			{
				if(tabControlInstructorCommission.SelectedTabPage.Text == "Instructor Type")
				{
					mdInstructorTypeInit();
				}
				else if(tabControlInstructorCommission.SelectedTabPage.Text == "Commission")
				{
					mdInstructorCommissionInit();
				}
				else if(tabControlInstructorCommission.SelectedTabPage.Text == "Instructor Type Commission")
				{
					mdInstructorTypeCommissionInit();
				}
			}
			else if (tabControlCommission.SelectedTabPage.Text == "PT Commission")
			{
				mdPTCommissionInit();
			}
		}

		private void tabControlInstructorCommission_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
		{
			if(tabControlInstructorCommission.SelectedTabPage.Text == "Instructor Type")
			{
				mdInstructorTypeInit();
			}
			else if(tabControlInstructorCommission.SelectedTabPage.Text == "Commission")
			{
				mdInstructorCommissionInit();
			}
			else if(tabControlInstructorCommission.SelectedTabPage.Text == "Instructor Type Commission")
			{
				mdInstructorTypeCommissionInit();
			}
		}

		private void btn_Add_Click(object sender, System.EventArgs e)
		{
			fMode = "I";
			DataRow dr;
			if (tabControlCommission.SelectedTabPage.Text == "Sales Commission")
			{
				dr = dtSalesCommission.NewRow();
				dtSalesCommission.Rows.Add(dr);
				gridControlMd_SalesCommisionScheme.Refresh();
				gridViewMd_SalesCommission.FocusedRowHandle = dtSalesCommission.Rows.Count - 1;
			}
			else if (tabControlCommission.SelectedTabPage.Text == "Instructor Commission")
			{
				if(tabControlInstructorCommission.SelectedTabPage.Text == "Instructor Type")
				{
					dr = dtInstructor.NewRow();
					dtInstructor.Rows.Add(dr);
					gridControlMd_InstructorType.Refresh();
					this.gridViewMdIC.FocusedRowHandle = dtInstructor.Rows.Count - 1;

				}
				else if(tabControlInstructorCommission.SelectedTabPage.Text == "Commission")
				{
					dr = dtCommission.NewRow();
					dtCommission.Rows.Add(dr);
					gridControlMd_InstructorCommission.Refresh();
					gridViewMdIC.FocusedRowHandle = dtCommission.Rows.Count - 1;

				}
				else if(tabControlInstructorCommission.SelectedTabPage.Text == "Instructor Type Commission")
				{
					dr = dtInstructorCommission.NewRow();
					dtInstructorCommission.Rows.Add(dr);
					gridControlMd_InstructorTypeCommission.Refresh();
					gridViewMdITC.FocusedRowHandle = dtInstructorCommission.Rows.Count - 1;
				}
			}
			else if (tabControlCommission.SelectedTabPage.Text == "PT Commission")
			{
				dr = dtPTCommission.NewRow();
				dtPTCommission.Rows.Add(dr);
				gridControlMd_PTCommission.Refresh();
				gridViewPTCommission.FocusedRowHandle = dtPTCommission.Rows.Count - 1;
			}
		}

		private bool FieldChecking(DataRow dr)
		{
			if (tabControlCommission.SelectedTabPage.Text == "Sales Commission")
			{		
				for (int a =0; a< dr.Table.Columns.Count; a++)
				{
					if (dr[a].ToString() == "")
					return false;
				}
					
			}
			else if (tabControlCommission.SelectedTabPage.Text == "Instructor Commission")
			{
				if(tabControlInstructorCommission.SelectedTabPage.Text == "Instructor Type")
				{
					if( dr["nInstructorTypeID"].ToString() == "")
					{
						MessageBox.Show("Instructor Type ID cannot be blank.");
						return false;
					}

				}
				else if(tabControlInstructorCommission.SelectedTabPage.Text == "Commission")
				{
					if ( dr["nCommissionTypeID"].ToString() == "")
					{
						MessageBox.Show("Commission Type ID cannot be blank.");
						return false;
					}

				}
				else if(tabControlInstructorCommission.SelectedTabPage.Text == "Instructor Type Commission")
				{
					if(dr["nCommissionTypeID"] .ToString() == "")
					{
						MessageBox.Show("Commission Type ID cannot be blank.");
						return false;
					}
					else if(dr["nInstructorTypeID"].ToString() == "")
					{
						MessageBox.Show("Instructor Type ID cannot be blank.");
						return false;
					}
				}
			}
			else if (tabControlCommission.SelectedTabPage.Text == "PT Commission")
			{
				if(dr["nLowerLimit"] .ToString() == "")
				{
					MessageBox.Show("Lower Limit cannot be blank.");
					return false;
				}
				else if(dr["nUppperLimit"].ToString() == "")
				{
					MessageBox.Show("Upper Limit cannot be blank");
					return false;
				}
			}
			return true;
		}

		private void btn_Del_Click(object sender, System.EventArgs e)
		{
					fMode = "D";
					
					if (tabControlCommission.SelectedTabPage.Text == "Sales Commission")
					{
						gridViewMd_SalesCommission.DeleteRow(gridViewMd_SalesCommission.FocusedRowHandle);
					}
					else if (tabControlCommission.SelectedTabPage.Text == "Instructor Commission")
					{
						if(tabControlInstructorCommission.SelectedTabPage.Text == "Instructor Type")
						{
							gridViewMdInstructor.DeleteRow(gridViewMdInstructor.FocusedRowHandle);
						}
						else if(tabControlInstructorCommission.SelectedTabPage.Text == "Commission")
						{
							gridViewMdIC.DeleteRow(gridViewMdIC.FocusedRowHandle);
						}
						else if(tabControlInstructorCommission.SelectedTabPage.Text == "Instructor Type Commission")
						{
							gridViewMdITC.DeleteRow(gridViewMdITC.FocusedRowHandle);
						}
					}
					else if (tabControlCommission.SelectedTabPage.Text == "PT Commission")
					{
						gridViewPTCommission.DeleteRow(gridViewPTCommission.FocusedRowHandle);
					}
				}

		private void ProcessDelete()
		{
			DataRow row;
			int output;
			
			try
			{
				if (tabControlCommission.SelectedTabPage.Text == "Sales Commission")
				{
					row = gridViewMd_SalesCommission.GetDataRow(gridViewMd_SalesCommission.FocusedRowHandle);
					if (row != null)
					{
						DialogResult result = MessageBox.Show(this, "Do you really want to delete record with Commission Code= '" + row["strCommissionCode"].ToString() + "'",
							"Delete?", MessageBoxButtons.YesNo);
						if (result == DialogResult.Yes)
						{
							output = 0;
							fMode="D";
							SqlHelper.ExecuteNonQuery(connection,"up_tblCommissionScheme",
								new SqlParameter("@RET_VAL",output),
								new SqlParameter("@cmd","D"),
								new SqlParameter("@strCommissionCode",row["strCommissionCode"].ToString() ),
								new SqlParameter("@strDescription",null ),
								new SqlParameter("@dtLastEditDate",null ),
								new SqlParameter("@nEmployeeID",null )
								);
							MessageBox.Show("Record Delete Succesfully","Info");
							mdSalesCommissionInit();
							fMode="N";
						}
					}
				}
				else if (tabControlCommission.SelectedTabPage.Text == "Instructor Commission")
				{
					if(tabControlInstructorCommission.SelectedTabPage.Text == "Instructor Type")
					{
						output = 0;

						row = gridViewMdInstructor.GetDataRow(gridViewMdInstructor.FocusedRowHandle);
						if (row != null)
						{
							DialogResult result = MessageBox.Show(this, "Do you really want to delete record with Instructor type code= '" + row["nInstructorTypeID"].ToString() + "'",
								"Delete?", MessageBoxButtons.YesNo);
							if (result == DialogResult.Yes)
							{

								SqlHelper.ExecuteNonQuery(connection,"up_tblInstructorType",
									new SqlParameter("@RET_VAL",output),
									new SqlParameter("@cmd","D"),
									new SqlParameter("@nInstructorTypeID",row["nInstructorTypeID"] ),
									new SqlParameter("@strDescription",null ),
									new SqlParameter("@nBonusTyoeID",null )
									);
								MessageBox.Show("Record Delete Succesfully","Info");
								mdInstructorTypeInit();
							}
						}
					}
					else if(tabControlInstructorCommission.SelectedTabPage.Text == "Commission")
					{
						output = 0;
						row = gridViewMdIC.GetDataRow(gridViewMdIC.FocusedRowHandle);
						if (row != null)
						{
							DialogResult result = MessageBox.Show(this, "Do you really want to delete record with Commission Code= '" + row["nCommissionTypeID"].ToString() + "'",
								"Delete?", MessageBoxButtons.YesNo);
							if (result == DialogResult.Yes)
							{

								SqlHelper.ExecuteNonQuery(connection,"up_tblInstructorCommission",
									new SqlParameter("@RET_VAL",output),
									new SqlParameter("@cmd","D"),
									new SqlParameter("@nCommissionTypeID",row["nCommissionTypeID"] ),
									new SqlParameter("@strDescription",null)
									);
								MessageBox.Show("Record Delete Succesfully","Info");
								mdInstructorCommissionInit();
							}
						}
					}
					else if(tabControlInstructorCommission.SelectedTabPage.Text == "Instructor Type Commission")
					{
						output = 0;
						row = gridViewMdITC.GetDataRow(gridViewMdITC.FocusedRowHandle);
						if (row != null)
						{
							DialogResult result = MessageBox.Show(this, "Do you really want to delete record with Commission Code= '" + row["nCommissionID"].ToString() + "'",
								"Delete?", MessageBoxButtons.YesNo);
							if (result == DialogResult.Yes)
							{

								SqlHelper.ExecuteNonQuery(connection,"up_tblInstructorCommission",
									new SqlParameter("@RET_VAL",output),
									new SqlParameter("@cmd","D"),
									new SqlParameter("@nInstructorTypeID",row["nInstructorTypeID"] ),
									new SqlParameter("@nCommissionTypeID",row["nCommissionTypeID"] ),
									new SqlParameter("@strDescription",null)
									);
								MessageBox.Show("Record Delete Succesfully","Info");
								mdInstructorTypeCommissionInit();
							}
						}
                            							
					}
				}
				else if (tabControlCommission.SelectedTabPage.Text == "PT Commission")
				{
					row = gridViewPTCommission.GetDataRow(gridViewPTCommission.FocusedRowHandle);
					if (row != null)
					{
						DialogResult result = MessageBox.Show(this, "Do you really want to delete record with Lower Limit= '" + row["nLowerLimit"].ToString() + "' and Upper Limit='" + row["nUpperLimit"].ToString() + "'",
							"Delete?", MessageBoxButtons.YesNo);
						if (result == DialogResult.Yes)
						{

							output = 0;
							SqlHelper.ExecuteNonQuery(connection,"UP_tblPTCommLevel",
								new SqlParameter("@RET_VAL",output),
								new SqlParameter("@cmd","D"),
								new SqlParameter("@nLowerLimit",row["nLowerLimit"] ),
								new SqlParameter("@nUpperLimit",row["nUpperLimit"] ),
								new SqlParameter("@mServiceCommission",row["mServiceCommission"] )
																				   );
							MessageBox.Show("Record Delete Succesfully","Info");
							mdPTCommissionInit();
						}
					}
				}
				
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message ,"Delete Process Failed");
				return;
			}

		}

		private void ProcessDeleteSalesCommEntries()
		{
			int output;
			output = 0;
			DataRow row;

			try
			{
				row = gridViewMd_SalesCommissionSchemeEntries.GetDataRow(gridViewMd_SalesCommissionSchemeEntries.FocusedRowHandle);
				if (row != null)
				{
					DialogResult result = MessageBox.Show(this, "Do you really want to delete this line of record?",
						"Delete?", MessageBoxButtons.YesNo);
					if (result == DialogResult.Yes)
					{
						SqlHelper.ExecuteNonQuery(connection,"up_del_tblCommissionSchemeEntries",
							new SqlParameter("@RET_VAL",output),
							new SqlParameter("@cmd","D"),
							new SqlParameter("@strCommissionCode",row["strCommissionCode"].ToString() ),
							new SqlParameter("@nPriorityID",Convert.ToInt32(row["nPriorityID"]) )
							);
						MessageBox.Show("Delete Record Successfully.","Info");
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message ,"Delete Process Failed");
				return;
			}
			mdSalesCommissionEntriesInit(row["strCommissionCode"].ToString());
			grpSubMDCommissionScheme.Enabled = true;
			fMode = "N";
		}

		private void gridViewMd_SalesCommission_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
			DataRow dr = gridViewMd_SalesCommission.GetDataRow(gridViewMd_SalesCommission.FocusedRowHandle);
			if ( dr!=null )
			{
				LoadCategory();
				tabCommissionSetting();
			}
		}
		
		private DataTable dtCategory;
		private DataTable dtCategory2;
		private DataTable dtCategory3;


		private void LoadCategory()
		{
			DataSet _ds;
			DataRow dr = this.gridViewMd_SalesCommission.GetDataRow(this.gridViewMd_SalesCommission.FocusedRowHandle);
			
			if (dr == null)
				return;

			string strSQL;

			strSQL ="Select nCategoryID ,strDescription from tblCategory where ";
			strSQL += "nCategoryID  not in (select nCategoryID from tblCommSubGroup "; 
			strSQL += "where strBranchCode='" + lkBranch.Text.ToString() + "' and fkGrpID='" + dr["PkGrpID"].ToString() + "') ";
			
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			
			if (dr["nCalMethod"].ToString() == "1")
				this.gridCategory.DataSource = _ds.Tables["table"];
			else if (dr["nCalMethod"].ToString() == "2")
				this.grid2Category.DataSource = _ds.Tables["table"];
			else if (dr["nCalMethod"].ToString() == "3")
				this.grid3Category.DataSource = _ds.Tables["table"];
		
			strSQL =  " Select A.nCommGroupID, A.nCategoryID, B.strDescription ,isnull(nCatPercent,0)as Percentage, strBranchCode, fkGrpID from tblcommsubgroup A"; 
			strSQL += " left join tblcategory B on A.nCategoryID=B.nCategoryID";
			strSQL += " where strBranchCode='" + lkBranch.Text.ToString() + "' and fkGrpID='" + dr["pkGrpID"].ToString() + "'";
			strSQL += " and  A.nCategoryID  in (Select nCategoryID from tblcategory)";
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );

			if (dr["nCalMethod"].ToString() == "1")
			{
				dtCategory = _ds.Tables["table"];
				gridCategory2.DataSource = dtCategory;
			}
			else if (dr["nCalMethod"].ToString() == "2")
			{
				dtCategory2 = _ds.Tables["table"];
				grid2Category2.DataSource = dtCategory2;
			}
			else if (dr["nCalMethod"].ToString() == "3")
			{
				dtCategory3 = _ds.Tables["table"];
				grid3Category2.DataSource = dtCategory3;
			}
		}

		private void btnCategory_Add_Click(object sender, System.EventArgs e)
		{
			DataRow dr = gridViewMd_SalesCommission.GetDataRow(gridViewMd_SalesCommission.FocusedRowHandle);

			int[] rowsHandle = this.gridViewCategory.GetSelectedRows();
			if (rowsHandle == null || rowsHandle.Length == 0)
			{
				UI.ShowErrorMessage(this, "Please select at least one row.");
				return;
			}
			
			foreach(int index in rowsHandle)
			{
				DataRow rCopy = gridViewCategory.GetDataRow(index);
				DataRow rNew = dtCategory.NewRow();
				rNew.BeginEdit();

				rNew["fkGrpID"] =dr["pkGrpID"];
				rNew["nCategoryID"] = rCopy["nCategoryID"];
				rNew["strDescription"] = rCopy["strDescription"];
				rNew["Percentage"] =0;
				rNew["nCommGroupID"] =dr["nCommGroupID"];
				rNew["strBranchCode"]=lkBranch.Text;
				
				rNew.EndEdit();
				dtCategory.Rows.Add(rNew);
			}
				gridViewCategory.DeleteSelectedRows();		

			try
			{
				string strSQL = "Select fkGrpID,nCommGroupID,nCategoryID,strBranchCode from tblCommSubGroup Where fkGrpID= '" + dr["pkGrpID"].ToString() + "'";
				CreateCmdsAndUpdate(strSQL,dtCategory);
			}
			catch (Exception)
			{
				return;
			}
		}

		private void btnCategory_DelAll_Click(object sender, System.EventArgs e)
		{
			DataRow dr = gridViewMd_SalesCommission.GetDataRow(gridViewMd_SalesCommission.FocusedRowHandle);

			gridViewCategory.BeginDataUpdate();
			gridViewCategory2.BeginDataUpdate();
			DataTable dtTemp = (gridViewCategory.DataSource as DataView).Table;

			for (int i = dtCategory.Rows.Count - 1; i >= 0; i--)
			{
				DataRow rCopy = gridViewCategory2.GetDataRow(i);
				DataRow rNew = dtTemp.NewRow();
				rNew.BeginEdit();
				rNew["nCategoryID"] = rCopy["nCategoryID"];
				rNew["strDescription"] = rCopy["strDescription"];
				dtTemp.Rows.Add(rNew);
			}

			for (int i = dtCategory.Rows.Count - 1; i >= 0; i--)
			{
				if (dtCategory.Rows[i].RowState != DataRowState.Deleted)
					dtCategory.Rows[i].Delete();
			}
			gridViewCategory2.EndDataUpdate();
			gridViewCategory.EndDataUpdate();

			string strSQL = "Select nCommGroupID,nCategoryID,fkGrpID from tblCommSubGroup Where fkGrpID= '" + dr["pkGrpID"].ToString() + "'";
			CreateCmdsAndUpdate(strSQL,dtCategory);
		}

		private void btnCategory_AddAll_Click(object sender, System.EventArgs e)
		{
			gridViewCategory.BeginDataUpdate();
			gridViewCategory2.BeginDataUpdate();

			DataRow dr = gridViewMd_SalesCommission.GetDataRow(gridViewMd_SalesCommission.FocusedRowHandle);
			DataTable dtTemp = (gridViewCategory.DataSource as DataView).Table;
			//dtTemp.RejectChanges();
			dtTemp.AcceptChanges();

			for (int i = dtTemp.Rows.Count - 1; i >= 0; i--)
			{
				DataRow rCopy = gridViewCategory.GetDataRow(i);
				DataRow rNew = dtCategory.NewRow();
				rNew.BeginEdit();
				rNew["fkGrpID"] =dr["pkGrpID"];
				rNew["nCategoryID"] = rCopy["nCategoryID"];
				rNew["strDescription"] = rCopy["strDescription"];
				rNew["Percentage"] =0;
				rNew["nCommGroupID"] =dr["nCommGroupID"];
				rNew["strBranchCode"]=lkBranch.Text;
				rNew.EndEdit();
				dtCategory.Rows.Add(rNew);
			}

			for (int i = dtTemp.Rows.Count - 1; i >= 0; i--)
			{
				if (dtTemp.Rows[i].RowState != DataRowState.Deleted)
					dtTemp.Rows[i].Delete();
			}
			gridViewCategory.EndDataUpdate();
			gridViewCategory2.EndDataUpdate();

			string strSQL = "Select fkGrpID,nCommGroupID,nCategoryID,strBranchCode from tblCommSubGroup Where fkGrpID= '" + dr["pkGrpID"].ToString() + "'";
			CreateCmdsAndUpdate(strSQL,dtCategory);
		}

		private void btnCategory_Del_Click(object sender, System.EventArgs e)
		{
			DataRow dr = gridViewMd_SalesCommission.GetDataRow(gridViewMd_SalesCommission.FocusedRowHandle);

			int[] rowsHandle = gridViewCategory2.GetSelectedRows();
			if (rowsHandle == null || rowsHandle.Length == 0)
			{
				UI.ShowErrorMessage(this, "Please select at least one row.");
				return;
			}
			DataTable dtTemp = (gridViewCategory.DataSource as DataView).Table;
			foreach(int index in rowsHandle)
			{
				DataRow rCopy = gridViewCategory2.GetDataRow(index);
				DataRow rNew = dtTemp.NewRow();
				rNew.BeginEdit();
			//	rNew["fkGrpID"] =dr["pkGrpID"];
				rNew["nCategoryID"] = rCopy["nCategoryID"];
				rNew["strDescription"] = rCopy["strDescription"];
				rNew.EndEdit();
				dtTemp.Rows.Add(rNew);
			}
			gridViewCategory2.DeleteSelectedRows();

			try
			{
				string strSQL = "Select nCommGroupID,nCategoryID,fkGrpID from tblCommSubGroup Where fkGrpID= '" + dr["pkGrpID"].ToString() + "'";
				CreateCmdsAndUpdate(strSQL,dtCategory);
			}
			catch (Exception)
			{
				return;
			}
		}

		private void btn_Add2_Click(object sender, System.EventArgs e)
		{
			fMode = "I";
			DataRow dr,row;
			row = gridViewMd_SalesCommission.GetDataRow(gridViewMd_SalesCommission.FocusedRowHandle);
			if ( row != null)
			{
				if (tabControlCommission.SelectedTabPage.Text == "Sales Commission")
				{
					dr = dtSalesCommissionEntries.NewRow();
					dr["strCommissionCode"] = row["strCommissionCode"];
					dtSalesCommissionEntries.Rows.Add(dr);
					this.gridControlMd_SalesCommisionSchemeEntries.Refresh();
					this.gridViewMd_SalesCommissionSchemeEntries.FocusedRowHandle = dtSalesCommissionEntries.Rows.Count - 1;
				}
			}

		}

		private void btn_del2_Click(object sender, System.EventArgs e)
		{
			if (fMode=="I")
			{
				fMode = "D";
				gridViewMd_SalesCommissionSchemeEntries.DeleteRow(gridViewMd_SalesCommissionSchemeEntries.FocusedRowHandle);
			}
			else
			{
				ProcessDeleteSalesCommEntries();
			}
		}

		#region Lost Focus
		private void gridViewMd_SalesCommissionSchemeEntries_LostFocus(object sender, System.EventArgs e)
		{
			
			DataRow row = this.gridViewMd_SalesCommissionSchemeEntries.GetDataRow(gridViewMd_SalesCommissionSchemeEntries.FocusedRowHandle);
			string strSQL = "Select * from tblCommissionSchemeEntries";
			if (fMode=="I")
			{
				if( FieldChecking(row))
				{
					gridControlMd_SalesCommisionSchemeEntries.MainView.UpdateCurrentRow();
					try
					{
						CreateCmdsAndUpdate(strSQL,dtSalesCommissionEntries);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message ,"Insert Failed");
						return;
					}
					fMode = "U";
				}
			}
			else
			{
				gridViewMd_SalesCommissionSchemeEntries.CloseEditor();
				gridViewMd_SalesCommissionSchemeEntries.UpdateCurrentRow();
				CreateCmdsAndUpdate(strSQL,dtSalesCommissionEntries);
			}
		
		}

		private void gridViewMd_SalesCommission_LostFocus(object sender, System.EventArgs e)
		{
			DataRow row = gridViewMd_SalesCommission.GetDataRow(gridViewMd_SalesCommission.FocusedRowHandle);
			
			string strSQL = "Select * from tblCommGroup";
			if (fMode=="I")
			{
				if( FieldChecking(row))
				{
					//row["nMonth"]=cmbMonth.EditValue;

					//row["nYear"]=cmbYear.Text;

					row["strBranchCode"]=lkBranch.Text;
					
					gridControlMd_SalesCommisionScheme.MainView.UpdateCurrentRow();
					try
					{
						CreateCmdsAndUpdate(strSQL,dtSalesCommission);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message ,"Insert Failed");
						return;
					}
					fMode = "U";
				}
			}
			else
			{
				gridViewMd_SalesCommission.CloseEditor();
				gridViewMd_SalesCommission.UpdateCurrentRow();
				CreateCmdsAndUpdate(strSQL,dtSalesCommission);
			}
		}

		private void gridViewMdInstructor_LostFocus(object sender, System.EventArgs e)
		{
			DataRow row = gridViewMdInstructor.GetDataRow(gridViewMdInstructor.FocusedRowHandle);
			
			string strSQL = "Select * from tblInstructorType";
			if (fMode=="I")
			{
				if( FieldChecking(row))
				{
					gridControlMd_InstructorType.MainView.UpdateCurrentRow();
					try
					{
						CreateCmdsAndUpdate(strSQL,dtInstructor);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message ,"Insert Failed");
						return;
					}
					fMode = "U";
				}
			}
			else
			{
				gridViewMdInstructor.CloseEditor();
				gridViewMdInstructor.UpdateCurrentRow();
				CreateCmdsAndUpdate(strSQL,dtInstructor);
			}

		
		}

		private void gridViewMdIC_LostFocus(object sender, System.EventArgs e)
		{
			DataRow row = gridViewMdIC.GetDataRow(gridViewMdIC.FocusedRowHandle);
			
			string strSQL = "Select * from tblInstructorCommission";
			if (fMode=="I")
			{
				if( FieldChecking(row))
				{
					gridControlMd_InstructorCommission.MainView.UpdateCurrentRow();
					try
					{
						CreateCmdsAndUpdate(strSQL,dtCommission);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message ,"Insert Failed");
						return;
					}
					fMode = "U";
				}
			}
			else
			{
				gridViewMdIC.CloseEditor();
				gridViewMdIC.UpdateCurrentRow();
				CreateCmdsAndUpdate(strSQL,dtCommission);
			}


		
		}

		private void gridViewMdITC_LostFocus(object sender, System.EventArgs e)
		{
			DataRow row = gridViewMdITC.GetDataRow(gridViewMdITC.FocusedRowHandle);
			
			string strSQL = "Select * from tblInstructorTypeCommission";
			if (fMode=="I")
			{
				if( FieldChecking(row))
				{
					gridControlMd_InstructorTypeCommission.MainView.UpdateCurrentRow();
					try
					{
						CreateCmdsAndUpdate(strSQL,dtInstructorCommission);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message ,"Insert Failed");
						return;
					}
					fMode = "U";
				}
			}
			else
			{
				gridViewMdITC.CloseEditor();
				gridViewMdITC.UpdateCurrentRow();
				CreateCmdsAndUpdate(strSQL,dtInstructorCommission);
			}


		
		}

		private void gridViewPTCommission_LostFocus(object sender, System.EventArgs e)
		{
			DataRow row = gridViewPTCommission.GetDataRow(gridViewPTCommission.FocusedRowHandle);
			
			string strSQL = "Select * from tblPTCommLevel";
			if (fMode=="I")
			{
				if( FieldChecking(row))
				{
					gridControlMd_PTCommission.MainView.UpdateCurrentRow();
					try
					{
						CreateCmdsAndUpdate(strSQL,dtPTCommission);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message ,"Insert Failed");
						return;
					}
					fMode = "U";
				}
			}
			else
			{
				gridViewPTCommission.CloseEditor();
				gridViewPTCommission.UpdateCurrentRow();
				CreateCmdsAndUpdate(strSQL,dtPTCommission);
			}
		
		}
		#endregion

		private void btn_Search_Click(object sender, System.EventArgs e)
		{
			mdSalesCommissionInit();
			LoadCategory();
		}

		private void tabCommissionSetting()
		{
			DataRow dr = gridViewMd_SalesCommission.GetDataRow(gridViewMd_SalesCommission.FocusedRowHandle);
			
			try
			{
				switch(dr["nCalMethod"].ToString() )
				{
					case "1":
					{
						tabMethodOne.PageVisible=true;
						tabMethodTwo.PageVisible=false;
						tabMethodThree.PageVisible=false;
						break;
					}

					case "2":
					{
						tabMethodOne.PageVisible=false;
						tabMethodTwo.PageVisible=true;
						tabMethodThree.PageVisible=false;
						break;
					}
					case "3":
					{
						tabMethodOne.PageVisible=false;
						tabMethodTwo.PageVisible=false;
						tabMethodThree.PageVisible=true;
						break;
					}
					
					default:
					{
						tabMethodOne.PageVisible=false;
						tabMethodOne.PageVisible=false;
						tabMethodOne.PageVisible=false;
						break;
					}
				}
			}
			catch(Exception)
			{
				return;
			}
		}

		private void tabControlCommission_Click(object sender, System.EventArgs e)
		{

			if (tabControlCommission.SelectedTabPage.Text == "Sales Commission")
			{		
					tabCommissionSetting();
					panelSalesCommission.Visible=true;
			}
			else	
			{ 	
					panelSalesCommission.Visible=false;
			}
		}

			
		private void Update_Pecentage(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
		{
			DataRow br = gridViewCategory2.GetDataRow(gridViewCategory2.FocusedRowHandle);

			try
			{
				SqlHelper.ExecuteNonQuery(connection,"Up_CommissionSubGroup",
					new SqlParameter("@nCommGroupID",br["nCommGroupID"].ToString()),
					new SqlParameter("@nCategoryID",br["nCategoryID"].ToString()),
					new SqlParameter("@fkGrpID",br["fkGrpID"].ToString()),
					new SqlParameter("@nCatPercent",br["Percentage"].ToString()));
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message ,"Percentage could not be updated");
				return;
			}
			
		}
	
	
		private void gridTarget_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
			DataRow dr = gridViewCategory2.GetDataRow(gridViewCategory2.FocusedRowHandle);
			if ( dr!=null )
			{
				Load_MethodOne(dr["fkGrpID"],dr["nCategoryID"]);
			}
		}

		private void gridRange_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
			DataRow dr = gridView2Category2.GetDataRow(gridView2Category2.FocusedRowHandle);
			if ( dr!=null )
			{
				Load_MethodTwo(dr["fkGrpID"],dr["nCategoryID"]);
			}
		}

		private void gridManager_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
			DataRow dr = gridView3Category2.GetDataRow(gridView3Category2.FocusedRowHandle);
			if ( dr!=null )
			{
				Load_MethodThree(dr["fkGrpID"],dr["nCategoryID"]);
			}
		}



		private DataTable dtTarget;
		private DataTable dtRange;
		private DataTable dtMgr;

		private void Load_MethodOne(object GrpID , object CategoryID)
		{
			string strSQL="Select * from tblCommTarget where fkGrpID=" + GrpID + " and strCategoryID="+ CategoryID +"" ;
			DataSet _ds = new DataSet();
	
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dtTarget = _ds.Tables["table"];
			this.gridTarget.DataSource = dtTarget;
		}
		
		private void Load_MethodTwo(object GrpID , object CategoryID)
		{
			string strSQL="Select * from tblCommRange where fkGrpID=" + GrpID + " and strCategoryID="+ CategoryID +"" ;
			DataSet _ds = new DataSet();
	
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dtRange = _ds.Tables["table"];
			this.gridRange.DataSource = dtRange;
		}

		private void Load_MethodThree(object GrpID , object CategoryID)
		{
			string strSQL="Select * from tblCommMgr where fkGrpID=" + GrpID + " ";//and strCategoryID="+ CategoryID +"
			DataSet _ds = new DataSet();
	
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dtMgr = _ds.Tables["table"];
			this.gridMgr.DataSource = dtMgr;
		}

		private void btn_Target_Add_Click(object sender, System.EventArgs e)
		{
			DataRow dr = gridViewTarget.GetDataRow(gridViewTarget.FocusedRowHandle);
			
			dr = dtTarget.NewRow();
			dtTarget.Rows.Add(dr);
			gridTarget.Refresh();
			gridViewTarget.FocusedRowHandle = dtTarget.Rows.Count - 1;
		
		}

		private void btn_Target_Del_Click(object sender, System.EventArgs e)
		{
			gridViewTarget.DeleteRow(gridViewTarget.FocusedRowHandle);
		}
		private void gridViewTarget_LostFocus(object sender, System.EventArgs e)
		{
			DataRow MainRow = gridViewCategory2.GetDataRow(gridViewCategory2.FocusedRowHandle);
			
			DataRow row = gridViewTarget.GetDataRow(gridViewTarget.FocusedRowHandle);
			
			string strSQL = "Select * from tblCommTarget";
			
			row["fkGrpID"]=MainRow["fkGrpID"];
			row["strCategoryID"]=MainRow["nCategoryID"];

			if( FieldChecking(row))
			{
				gridTarget.MainView.UpdateCurrentRow();
				try
				{
					CreateCmdsAndUpdate(strSQL,dtTarget);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message ,"Insert Failed");
					return;
				}
				fMode = "U";
			}
			
			else
			{
				gridViewTarget.CloseEditor();
				gridViewTarget.UpdateCurrentRow();
				CreateCmdsAndUpdate(strSQL,dtTarget);
			}
		}

		private void btn2Category_Add_Click(object sender, System.EventArgs e)
		{
			DataRow dr = gridViewMd_SalesCommission.GetDataRow(gridViewMd_SalesCommission.FocusedRowHandle);

			int[] rowsHandle = this.gridView2Category.GetSelectedRows();
			if (rowsHandle == null || rowsHandle.Length == 0)
			{
				UI.ShowErrorMessage(this, "Please select at least one row.");
				return;
			}
			
			foreach(int index in rowsHandle)
			{
				DataRow rCopy = gridView2Category.GetDataRow(index);
				DataRow rNew = dtCategory2.NewRow();
				rNew.BeginEdit();

				rNew["fkGrpID"] =dr["pkGrpID"];
				rNew["nCategoryID"] = rCopy["nCategoryID"];
				rNew["strDescription"] = rCopy["strDescription"];
				rNew["nCommGroupID"] =dr["nCommGroupID"];
				rNew["strBranchCode"]=lkBranch.Text;
				
				rNew.EndEdit();
				dtCategory2.Rows.Add(rNew);
			}
			gridView2Category.DeleteSelectedRows();		

			try
			{
				string strSQL = "Select fkGrpID,nCommGroupID,nCategoryID,strBranchCode from tblCommSubGroup Where fkGrpID= '" + dr["pkGrpID"].ToString() + "'";
				CreateCmdsAndUpdate(strSQL,dtCategory2);
			}
			catch (Exception)
			{
				return;
			}

		}

		private void btn3Category_Add_Click(object sender, System.EventArgs e)
		{
			DataRow dr = gridViewMd_SalesCommission.GetDataRow(gridViewMd_SalesCommission.FocusedRowHandle);

			int[] rowsHandle = this.gridView3Category.GetSelectedRows();
			if (rowsHandle == null || rowsHandle.Length == 0)
			{
				UI.ShowErrorMessage(this, "Please select at least one row.");
				return;
			}
			
			foreach(int index in rowsHandle)
			{
				DataRow rCopy = gridView3Category.GetDataRow(index);
				DataRow rNew = dtCategory3.NewRow();
				rNew.BeginEdit();

				rNew["fkGrpID"] =dr["pkGrpID"];
				rNew["nCategoryID"] = rCopy["nCategoryID"];
				rNew["strDescription"] = rCopy["strDescription"];
				rNew["nCommGroupID"] =dr["nCommGroupID"];
				rNew["strBranchCode"]=lkBranch.Text;
				
				rNew.EndEdit();
				dtCategory3.Rows.Add(rNew);
			}
			gridView3Category.DeleteSelectedRows();		

			try
			{
				string strSQL = "Select fkGrpID,nCommGroupID,nCategoryID,strBranchCode from tblCommSubGroup Where fkGrpID= '" + dr["pkGrpID"].ToString() + "'";
				CreateCmdsAndUpdate(strSQL,dtCategory3);
			}
			catch (Exception)
			{
				return;
			}
		
		}

		private void btn2Category_AddAll_Click(object sender, System.EventArgs e)
		{
			gridView2Category.BeginDataUpdate();
			gridView2Category2.BeginDataUpdate();

			DataRow dr = gridViewMd_SalesCommission.GetDataRow(gridViewMd_SalesCommission.FocusedRowHandle);
			DataTable dtTemp = (gridView2Category.DataSource as DataView).Table;
			//dtTemp.RejectChanges();
			dtTemp.AcceptChanges();

			for (int i = dtTemp.Rows.Count - 1; i >= 0; i--)
			{
				DataRow rCopy = gridView2Category.GetDataRow(i);
				DataRow rNew = dtCategory2.NewRow();
				rNew.BeginEdit();
				rNew["fkGrpID"] =dr["pkGrpID"];
				rNew["nCategoryID"] = rCopy["nCategoryID"];
				rNew["strDescription"] = rCopy["strDescription"];
				rNew["Percentage"] =0;
				rNew["nCommGroupID"] =dr["nCommGroupID"];
				rNew["strBranchCode"]=lkBranch.Text;
				rNew.EndEdit();
				dtCategory2.Rows.Add(rNew);
			}

			for (int i = dtTemp.Rows.Count - 1; i >= 0; i--)
			{
				if (dtTemp.Rows[i].RowState != DataRowState.Deleted)
					dtTemp.Rows[i].Delete();
			}
			gridView2Category.EndDataUpdate();
			gridView2Category2.EndDataUpdate();

			string strSQL = "Select fkGrpID,nCommGroupID,nCategoryID,strBranchCode from tblCommSubGroup Where fkGrpID= '" + dr["pkGrpID"].ToString() + "'";
			CreateCmdsAndUpdate(strSQL,dtCategory2);
		}

		private void btn3Category_AddAll_Click(object sender, System.EventArgs e)
		{
			gridView3Category.BeginDataUpdate();
			gridView3Category2.BeginDataUpdate();

			DataRow dr = gridViewMd_SalesCommission.GetDataRow(gridViewMd_SalesCommission.FocusedRowHandle);
			DataTable dtTemp = (gridView3Category.DataSource as DataView).Table;
			//dtTemp.RejectChanges();
			dtTemp.AcceptChanges();

			for (int i = dtTemp.Rows.Count - 1; i >= 0; i--)
			{
				DataRow rCopy = gridView3Category.GetDataRow(i);
				DataRow rNew = dtCategory3.NewRow();
				rNew.BeginEdit();
				rNew["fkGrpID"] =dr["pkGrpID"];
				rNew["nCategoryID"] = rCopy["nCategoryID"];
				rNew["strDescription"] = rCopy["strDescription"];
				rNew["Percentage"] =0;
				rNew["nCommGroupID"] =dr["nCommGroupID"];
				rNew["strBranchCode"]=lkBranch.Text;
				rNew.EndEdit();
				dtCategory3.Rows.Add(rNew);
			}

			for (int i = dtTemp.Rows.Count - 1; i >= 0; i--)
			{
				if (dtTemp.Rows[i].RowState != DataRowState.Deleted)
					dtTemp.Rows[i].Delete();
			}
			gridView3Category.EndDataUpdate();
			gridView3Category2.EndDataUpdate();

			string strSQL = "Select fkGrpID,nCommGroupID,nCategoryID,strBranchCode from tblCommSubGroup Where fkGrpID= '" + dr["pkGrpID"].ToString() + "'";
			CreateCmdsAndUpdate(strSQL,dtCategory3);
		}
        
		private void Branch_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			mdSalesCommissionInit();
			LoadCategory();
		}

		private void btn2Category_Del_Click(object sender, System.EventArgs e)
		{
			DataRow dr = gridViewMd_SalesCommission.GetDataRow(gridViewMd_SalesCommission.FocusedRowHandle);

			int[] rowsHandle = gridView2Category2.GetSelectedRows();
			if (rowsHandle == null || rowsHandle.Length == 0)
			{
				UI.ShowErrorMessage(this, "Please select at least one row.");
				return;
			}
			DataTable dtTemp = (gridView2Category.DataSource as DataView).Table;
			foreach(int index in rowsHandle)
			{
				DataRow rCopy = gridView2Category2.GetDataRow(index);
				DataRow rNew = dtTemp.NewRow();
				rNew.BeginEdit();
				//	rNew["fkGrpID"] =dr["pkGrpID"];
				rNew["nCategoryID"] = rCopy["nCategoryID"];
				rNew["strDescription"] = rCopy["strDescription"];
				rNew.EndEdit();
				dtTemp.Rows.Add(rNew);
			}
			gridView2Category2.DeleteSelectedRows();

			try
			{
				string strSQL = "Select nCommGroupID,nCategoryID,fkGrpID from tblCommSubGroup Where fkGrpID= '" + dr["pkGrpID"].ToString() + "'";
				CreateCmdsAndUpdate(strSQL,dtCategory2);
			}
			catch (Exception)
			{
				return;
			}
		}

		private void btn3Category_Del_Click(object sender, System.EventArgs e)
		{
			DataRow dr = gridViewMd_SalesCommission.GetDataRow(gridViewMd_SalesCommission.FocusedRowHandle);

			int[] rowsHandle = gridView3Category2.GetSelectedRows();
			if (rowsHandle == null || rowsHandle.Length == 0)
			{
				UI.ShowErrorMessage(this, "Please select at least one row.");
				return;
			}
			DataTable dtTemp = (gridView3Category.DataSource as DataView).Table;
			foreach(int index in rowsHandle)
			{
				DataRow rCopy = gridView3Category2.GetDataRow(index);
				DataRow rNew = dtTemp.NewRow();
				rNew.BeginEdit();
				//	rNew["fkGrpID"] =dr["pkGrpID"];
				rNew["nCategoryID"] = rCopy["nCategoryID"];
				rNew["strDescription"] = rCopy["strDescription"];
				rNew.EndEdit();
				dtTemp.Rows.Add(rNew);
			}
			gridView3Category2.DeleteSelectedRows();

			try
			{
				string strSQL = "Select nCommGroupID,nCategoryID,fkGrpID from tblCommSubGroup Where fkGrpID= '" + dr["pkGrpID"].ToString() + "'";
				CreateCmdsAndUpdate(strSQL,dtCategory3);
			}
			catch (Exception)
			{
				return;
			}
		}

		private void btn2Category_DelAll_Click(object sender, System.EventArgs e)
		{
			DataRow dr = gridViewMd_SalesCommission.GetDataRow(gridViewMd_SalesCommission.FocusedRowHandle);

			gridView2Category.BeginDataUpdate();
			gridView2Category2.BeginDataUpdate();
			DataTable dtTemp = (gridView2Category.DataSource as DataView).Table;

			for (int i = dtCategory2.Rows.Count - 1; i >= 0; i--)
			{
				DataRow rCopy = gridView2Category2.GetDataRow(i);
				DataRow rNew = dtTemp.NewRow();
				rNew.BeginEdit();
				rNew["nCategoryID"] = rCopy["nCategoryID"];
				rNew["strDescription"] = rCopy["strDescription"];
				dtTemp.Rows.Add(rNew);
			}

			for (int i = dtCategory2.Rows.Count - 1; i >= 0; i--)
			{
				if (dtCategory2.Rows[i].RowState != DataRowState.Deleted)
					dtCategory2.Rows[i].Delete();
			}
			gridView2Category2.EndDataUpdate();
			gridView2Category.EndDataUpdate();

			string strSQL = "Select nCommGroupID,nCategoryID,fkGrpID from tblCommSubGroup Where fkGrpID= '" + dr["pkGrpID"].ToString() + "'";
			CreateCmdsAndUpdate(strSQL,dtCategory2);

		}

		private void btn3Category_DelAll_Click(object sender, System.EventArgs e)
		{
			DataRow dr = gridViewMd_SalesCommission.GetDataRow(gridViewMd_SalesCommission.FocusedRowHandle);

			gridView3Category.BeginDataUpdate();
			gridView3Category2.BeginDataUpdate();
			DataTable dtTemp = (gridView3Category.DataSource as DataView).Table;

			for (int i = dtCategory3.Rows.Count - 1; i >= 0; i--)
			{
				DataRow rCopy = gridView3Category2.GetDataRow(i);
				DataRow rNew = dtTemp.NewRow();
				rNew.BeginEdit();
				rNew["nCategoryID"] = rCopy["nCategoryID"];
				rNew["strDescription"] = rCopy["strDescription"];
				dtTemp.Rows.Add(rNew);
			}

			for (int i = dtCategory3.Rows.Count - 1; i >= 0; i--)
			{
				if (dtCategory3.Rows[i].RowState != DataRowState.Deleted)
					dtCategory3.Rows[i].Delete();
			}
			gridView3Category2.EndDataUpdate();
			gridView3Category.EndDataUpdate();

			string strSQL = "Select nCommGroupID,nCategoryID,fkGrpID from tblCommSubGroup Where fkGrpID= '" + dr["pkGrpID"].ToString() + "'";
			CreateCmdsAndUpdate(strSQL,dtCategory3);

		}

		private void btn_Range_Add_Click(object sender, System.EventArgs e)
		{
			DataRow dr = gridViewRange.GetDataRow(gridViewRange.FocusedRowHandle);
			
			dr = dtRange.NewRow();
			dtRange.Rows.Add(dr);
			gridRange.Refresh();
			gridViewRange.FocusedRowHandle = dtRange.Rows.Count - 1;
		}

		private void btn_Mgr_add_Click(object sender, System.EventArgs e)
		{
			DataRow dr = gridViewMgr.GetDataRow(gridViewMgr.FocusedRowHandle);
			
			dr = dtMgr.NewRow();
			dtMgr.Rows.Add(dr);
			gridMgr.Refresh();
			gridViewMgr.FocusedRowHandle = dtMgr.Rows.Count - 1;
		}

		private void btn_Mgr_Del_Click(object sender, System.EventArgs e)
		{
			gridViewMgr.DeleteRow(gridViewMgr.FocusedRowHandle);
		}

		private void btn_Range_Del_Click(object sender, System.EventArgs e)
		{
			gridViewRange.DeleteRow(gridViewRange.FocusedRowHandle);
		}

		private void gridViewRange_LostFocus(object sender, System.EventArgs e)
		{
			DataRow MainRow = gridView2Category2.GetDataRow(gridView2Category2.FocusedRowHandle);
			
			DataRow row = gridViewRange.GetDataRow(gridViewRange.FocusedRowHandle);
			
			string strSQL = "Select * from tblCommRange";
			
			row["fkGrpID"]=MainRow["fkGrpID"];
			row["strCategoryID"]=MainRow["nCategoryID"];

			if( FieldChecking(row))
			{
				gridRange.MainView.UpdateCurrentRow();
				try
				{
					CreateCmdsAndUpdate(strSQL,dtRange);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message ,"Insert Failed");
					return;
				}
				fMode = "U";
			}
			
			else
			{
				gridViewRange.CloseEditor();
				gridViewRange.UpdateCurrentRow();
				CreateCmdsAndUpdate(strSQL,dtRange);
			}
		}

		private void gridViewMgr_LostFocus(object sender, System.EventArgs e)
		{
			DataRow MainRow = gridView3Category2.GetDataRow(gridView3Category2.FocusedRowHandle);
			
			DataRow row = gridViewMgr.GetDataRow(gridViewMgr.FocusedRowHandle);
			
			string strSQL = "Select * from tblCommMgr";
			
			row["fkGrpID"]=MainRow["fkGrpID"];
//			row["strCategoryID"]=MainRow["nCategoryID"];

			if( FieldChecking(row))
			{
				gridMgr.MainView.UpdateCurrentRow();
				try
				{
					CreateCmdsAndUpdate(strSQL,dtMgr);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message ,"Insert Failed");
					return;
				}
				fMode = "U";
			}
			
			else
			{
				gridViewMgr.CloseEditor();
				gridViewMgr.UpdateCurrentRow();
				CreateCmdsAndUpdate(strSQL,dtMgr);
			}
		}

		}

}
