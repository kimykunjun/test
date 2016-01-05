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
	/// Summary description for frmSalesTarget.
	/// </summary>
	public class frmSalesTarget : System.Windows.Forms.Form
	{

        #region windows control

        private string connectionString;
        private SqlConnection connection;
        private DevExpress.XtraEditors.GroupControl grpSalesRank;
        private DevExpress.XtraEditors.GroupControl grpCommMSE;
        private DevExpress.XtraEditors.GroupControl grpCommSpaConsult;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gridControlMd_SalesTarget;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewMd_SalesTarget;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPKG1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPKG2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPKG3;
        internal DevExpress.XtraEditors.SimpleButton btn_AddMSE;
        internal DevExpress.XtraEditors.SimpleButton btn_DelMSE;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit de_nYear;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit strDesc;
        private System.ComponentModel.IContainer components;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraGrid.GridControl gridControlMd_CommSpaConsult;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewMd_CommSpaConsult;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPG1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPG2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPG3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPG4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPG5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPG6;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_pkGroupCatID;
        private DevExpress.XtraEditors.GroupControl grpCommProductTherapist;
        internal DevExpress.XtraEditors.SimpleButton btn_AddProductTherapist;
        internal DevExpress.XtraEditors.SimpleButton btn_DelProductTherapist;
        private DevExpress.XtraEditors.GroupControl groupControl5;
        private DevExpress.XtraGrid.GridControl gridControlMd_CommProductTherapist;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewMd_CommProductTherapist;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPT1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPT2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPT3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPT4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPT5;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit EffCCStartDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPT6;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit EffCCEndDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_CreditCategoryID;
        internal DevExpress.XtraEditors.SimpleButton btn_AddSpaConsult;
        internal DevExpress.XtraEditors.SimpleButton btn_DelSpaConsult;
        private Label label31;
        private DevExpress.XtraEditors.ImageComboBoxEdit ddlSalesRank;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_SalesRank;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPKG4;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit tedit_Commission;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPKG5;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit tedit_strType;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit tedit_strCommID;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit tedit_strDesc;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit tedit_strBranch;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit tedit_mTargetFrom;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPKG6;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit tedit_mTargetTo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPKG7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPKG8;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit de_nMonth;
        private DevExpress.XtraGrid.Views.Card.CardView cardView1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit tedit_SC_strCommID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPG7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPG8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPG9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPKG9;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit tedit_nYear;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit tedit_nMonth;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPG10;
        private DevExpress.XtraEditors.GroupControl grpCommPT;
        internal DevExpress.XtraEditors.SimpleButton btn_AddPT;
        internal DevExpress.XtraEditors.SimpleButton btn_DelPT;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraGrid.GridControl gridControlMd_CommPT;
        private GridView gridViewMd_CommPT;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCommPT1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCommPT2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCommPT3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCommPT4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCommPT5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCommPT6;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCommPT7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCommPT8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCommPT9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCommPT10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCommPT11;
        private DevExpress.XtraEditors.GroupControl grpCommCST;
        internal DevExpress.XtraEditors.SimpleButton btn_AddCST;
        internal DevExpress.XtraEditors.SimpleButton btn_DelCST;
        private DevExpress.XtraEditors.GroupControl groupControl6;
        private DevExpress.XtraGrid.GridControl gridControlMd_CommCST;
        private GridView gridViewMd_CommCST;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCST1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCST2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCST3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCST4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCST5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCST6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCST7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCST8;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCST9;
        private ImageList imageList1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_Position3;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_BranchCode0;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_Position0;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_Position1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_BranchCode1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_BranchCode3;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_Position4;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_BranchCode4;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_Position2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_BranchCode2;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox chk_Month0;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox chk_Month3;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox chk_Month1;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox chk_Month2;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox chk_Month4;
        private DevExpress.XtraEditors.GroupControl grpCommMerge;
        internal DevExpress.XtraEditors.SimpleButton btn_AddMerge;
        internal DevExpress.XtraEditors.SimpleButton btn_DelMerge;
        private DevExpress.XtraEditors.GroupControl groupControl7;
        private DevExpress.XtraGrid.GridControl gridControlMd_CommMerge;
        private GridView gridViewMd_CommMerge;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnM3;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_BranchCode5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnM7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnM8;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox chk_Month5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnM1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_Position5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnM2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnM4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnM5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnM6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnM9;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit5;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit6;
        private GridView gridView1;
        private Label label1;
        private GroupBox groupBox1;
        private ComboBox combo_DuplicateYearFrom;
        private ComboBox combo_DuplicateBranchFrom;
        private Label label2;
        private GroupBox groupBox2;
        private Label label3;
        private ComboBox combo_DuplicateYearTo;
        private Label label4;
        private ComboBox combo_DuplicateBranchTo;
        private Button btn_Duplicate;
        private GroupBox groupBoxCommMSE;
        private DataTable dtSalesTarget;
        #endregion

        public frmSalesTarget()
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
            load = "0"; //ddlSalesRank
            LoadBranchSalesTarget();
            LoadDuplicate();
            
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalesTarget));
            this.grpSalesRank = new DevExpress.XtraEditors.GroupControl();
            this.groupBoxCommMSE = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.combo_DuplicateYearTo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.combo_DuplicateBranchTo = new System.Windows.Forms.ComboBox();
            this.btn_Duplicate = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.combo_DuplicateYearFrom = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.combo_DuplicateBranchFrom = new System.Windows.Forms.ComboBox();
            this.label31 = new System.Windows.Forms.Label();
            this.ddlSalesRank = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.grpCommPT = new DevExpress.XtraEditors.GroupControl();
            this.btn_AddPT = new DevExpress.XtraEditors.SimpleButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btn_DelPT = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.gridControlMd_CommPT = new DevExpress.XtraGrid.GridControl();
            this.gridViewMd_CommPT = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnCommPT8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lk_BranchCode3 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumnCommPT9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCommPT10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chk_Month3 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gridColumnCommPT1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lk_Position3 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumnCommPT2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCommPT3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCommPT4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCommPT5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCommPT6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCommPT7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCommPT11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.repositoryItemDateEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.grpCommProductTherapist = new DevExpress.XtraEditors.GroupControl();
            this.btn_AddProductTherapist = new DevExpress.XtraEditors.SimpleButton();
            this.btn_DelProductTherapist = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
            this.gridControlMd_CommProductTherapist = new DevExpress.XtraGrid.GridControl();
            this.gridViewMd_CommProductTherapist = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnPT2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lk_BranchCode2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumnPT4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPT3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chk_Month2 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gridColumnPT1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lk_Position2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumnPT5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPT6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lk_CreditCategoryID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.EffCCStartDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.EffCCEndDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.grpCommCST = new DevExpress.XtraEditors.GroupControl();
            this.btn_AddCST = new DevExpress.XtraEditors.SimpleButton();
            this.btn_DelCST = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl6 = new DevExpress.XtraEditors.GroupControl();
            this.gridControlMd_CommCST = new DevExpress.XtraGrid.GridControl();
            this.gridViewMd_CommCST = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnCST3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lk_BranchCode4 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumnCST7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCST8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chk_Month4 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gridColumnCST1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lk_Position4 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumnCST2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCST4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCST5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCST6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCST9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemDateEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.repositoryItemDateEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.grpCommMerge = new DevExpress.XtraEditors.GroupControl();
            this.btn_AddMerge = new DevExpress.XtraEditors.SimpleButton();
            this.btn_DelMerge = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl7 = new DevExpress.XtraEditors.GroupControl();
            this.gridControlMd_CommMerge = new DevExpress.XtraGrid.GridControl();
            this.gridViewMd_CommMerge = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnM3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lk_BranchCode5 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumnM7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnM8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chk_Month5 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gridColumnM1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lk_Position5 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumnM2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnM4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnM5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnM6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnM9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemDateEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.repositoryItemDateEdit6 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grpCommMSE = new DevExpress.XtraEditors.GroupControl();
            this.btn_AddMSE = new DevExpress.XtraEditors.SimpleButton();
            this.btn_DelMSE = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gridControlMd_SalesTarget = new DevExpress.XtraGrid.GridControl();
            this.gridViewMd_SalesTarget = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnPKG3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lk_BranchCode0 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumnPKG7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tedit_nYear = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumnPKG8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chk_Month0 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gridColumnPKG1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lk_Position0 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumnPKG2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tedit_strDesc = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumnPKG4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tedit_Commission = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumnPKG5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tedit_mTargetFrom = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumnPKG6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tedit_mTargetTo = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumnPKG9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.de_nYear = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.strDesc = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.lk_SalesRank = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.tedit_strType = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.tedit_strCommID = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.tedit_strBranch = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.de_nMonth = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.tedit_nMonth = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.cardView1 = new DevExpress.XtraGrid.Views.Card.CardView();
            this.grpCommSpaConsult = new DevExpress.XtraEditors.GroupControl();
            this.btn_AddSpaConsult = new DevExpress.XtraEditors.SimpleButton();
            this.btn_DelSpaConsult = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.gridControlMd_CommSpaConsult = new DevExpress.XtraGrid.GridControl();
            this.gridViewMd_CommSpaConsult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnPG3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lk_BranchCode1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumnPG7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPG8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chk_Month1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gridColumnPG1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lk_Position1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumnPG2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPG4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPG9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPG5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPG6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPG10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lk_pkGroupCatID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.tedit_SC_strCommID = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grpSalesRank)).BeginInit();
            this.grpSalesRank.SuspendLayout();
            this.groupBoxCommMSE.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSalesRank.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpCommPT)).BeginInit();
            this.grpCommPT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMd_CommPT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMd_CommPT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_BranchCode3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_Month3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_Position3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpCommProductTherapist)).BeginInit();
            this.grpCommProductTherapist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
            this.groupControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMd_CommProductTherapist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMd_CommProductTherapist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_BranchCode2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_Month2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_Position2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_CreditCategoryID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EffCCStartDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EffCCStartDate.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EffCCEndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EffCCEndDate.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpCommCST)).BeginInit();
            this.grpCommCST.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl6)).BeginInit();
            this.groupControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMd_CommCST)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMd_CommCST)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_BranchCode4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_Month4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_Position4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit3.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit4.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpCommMerge)).BeginInit();
            this.grpCommMerge.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl7)).BeginInit();
            this.groupControl7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMd_CommMerge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMd_CommMerge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_BranchCode5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_Month5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_Position5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit5.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit6.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpCommMSE)).BeginInit();
            this.grpCommMSE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMd_SalesTarget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMd_SalesTarget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_BranchCode0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tedit_nYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_Month0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_Position0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tedit_strDesc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tedit_Commission)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tedit_mTargetFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tedit_mTargetTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_nYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_nYear.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.strDesc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.strDesc.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_SalesRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tedit_strType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tedit_strCommID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tedit_strBranch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_nMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_nMonth.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tedit_nMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpCommSpaConsult)).BeginInit();
            this.grpCommSpaConsult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMd_CommSpaConsult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMd_CommSpaConsult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_BranchCode1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_Month1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_Position1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_pkGroupCatID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tedit_SC_strCommID)).BeginInit();
            this.SuspendLayout();
            // 
            // grpSalesRank
            // 
            this.grpSalesRank.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.grpSalesRank.Appearance.Options.UseBackColor = true;
            this.grpSalesRank.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSalesRank.AppearanceCaption.Options.UseFont = true;
            this.grpSalesRank.Controls.Add(this.groupBoxCommMSE);
            this.grpSalesRank.Controls.Add(this.label31);
            this.grpSalesRank.Controls.Add(this.ddlSalesRank);
            this.grpSalesRank.Controls.Add(this.grpCommPT);
            this.grpSalesRank.Controls.Add(this.grpCommProductTherapist);
            this.grpSalesRank.Controls.Add(this.grpCommCST);
            this.grpSalesRank.Controls.Add(this.grpCommMerge);
            this.grpSalesRank.Controls.Add(this.grpCommMSE);
            this.grpSalesRank.Controls.Add(this.grpCommSpaConsult);
            this.grpSalesRank.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grpSalesRank.Location = new System.Drawing.Point(8, 2);
            this.grpSalesRank.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.grpSalesRank.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grpSalesRank.Name = "grpSalesRank";
            this.grpSalesRank.Size = new System.Drawing.Size(968, 455);
            this.grpSalesRank.TabIndex = 93;
            this.grpSalesRank.Text = "MASTER FILE";
            // 
            // groupBoxCommMSE
            // 
            this.groupBoxCommMSE.BackColor = System.Drawing.SystemColors.Control;
            this.groupBoxCommMSE.Controls.Add(this.groupBox2);
            this.groupBoxCommMSE.Controls.Add(this.btn_Duplicate);
            this.groupBoxCommMSE.Controls.Add(this.groupBox1);
            this.groupBoxCommMSE.Location = new System.Drawing.Point(248, 291);
            this.groupBoxCommMSE.Name = "groupBoxCommMSE";
            this.groupBoxCommMSE.Size = new System.Drawing.Size(444, 151);
            this.groupBoxCommMSE.TabIndex = 140;
            this.groupBoxCommMSE.TabStop = false;
            this.groupBoxCommMSE.Text = "Duplicate Records";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.combo_DuplicateYearTo);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.combo_DuplicateBranchTo);
            this.groupBox2.Location = new System.Drawing.Point(236, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(192, 79);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "To";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Branch :";
            // 
            // combo_DuplicateYearTo
            // 
            this.combo_DuplicateYearTo.FormattingEnabled = true;
            this.combo_DuplicateYearTo.Location = new System.Drawing.Point(64, 47);
            this.combo_DuplicateYearTo.Name = "combo_DuplicateYearTo";
            this.combo_DuplicateYearTo.Size = new System.Drawing.Size(121, 21);
            this.combo_DuplicateYearTo.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Year :";
            // 
            // combo_DuplicateBranchTo
            // 
            this.combo_DuplicateBranchTo.FormattingEnabled = true;
            this.combo_DuplicateBranchTo.Location = new System.Drawing.Point(65, 19);
            this.combo_DuplicateBranchTo.Name = "combo_DuplicateBranchTo";
            this.combo_DuplicateBranchTo.Size = new System.Drawing.Size(121, 21);
            this.combo_DuplicateBranchTo.TabIndex = 2;
            // 
            // btn_Duplicate
            // 
            this.btn_Duplicate.Location = new System.Drawing.Point(191, 112);
            this.btn_Duplicate.Name = "btn_Duplicate";
            this.btn_Duplicate.Size = new System.Drawing.Size(75, 23);
            this.btn_Duplicate.TabIndex = 6;
            this.btn_Duplicate.Text = "Duplicate";
            this.btn_Duplicate.UseVisualStyleBackColor = true;
            this.btn_Duplicate.Click += new System.EventHandler(this.btn_Duplicate_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.combo_DuplicateYearFrom);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.combo_DuplicateBranchFrom);
            this.groupBox1.Location = new System.Drawing.Point(18, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(192, 79);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "From";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Branch :";
            // 
            // combo_DuplicateYearFrom
            // 
            this.combo_DuplicateYearFrom.FormattingEnabled = true;
            this.combo_DuplicateYearFrom.Location = new System.Drawing.Point(64, 50);
            this.combo_DuplicateYearFrom.Name = "combo_DuplicateYearFrom";
            this.combo_DuplicateYearFrom.Size = new System.Drawing.Size(121, 21);
            this.combo_DuplicateYearFrom.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Year :";
            // 
            // combo_DuplicateBranchFrom
            // 
            this.combo_DuplicateBranchFrom.FormattingEnabled = true;
            this.combo_DuplicateBranchFrom.Location = new System.Drawing.Point(64, 20);
            this.combo_DuplicateBranchFrom.Name = "combo_DuplicateBranchFrom";
            this.combo_DuplicateBranchFrom.Size = new System.Drawing.Size(121, 21);
            this.combo_DuplicateBranchFrom.TabIndex = 2;
            // 
            // label31
            // 
            this.label31.BackColor = System.Drawing.Color.Transparent;
            this.label31.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(8, 24);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(136, 16);
            this.label31.TabIndex = 116;
            this.label31.Text = "Sales Rank";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ddlSalesRank
            // 
            this.ddlSalesRank.EditValue = 0;
            this.ddlSalesRank.Location = new System.Drawing.Point(144, 24);
            this.ddlSalesRank.Name = "ddlSalesRank";
            this.ddlSalesRank.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlSalesRank.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Fitness Package/Product", 0, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Spa Package/IPL Service", 1, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Spa Product", 2, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("PT Service", 3, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Cross Selling", 4, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Merge", 5, -1)});
            this.ddlSalesRank.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.ddlSalesRank.Properties.SmallImages = "";
            this.ddlSalesRank.Size = new System.Drawing.Size(176, 20);
            this.ddlSalesRank.TabIndex = 19;
            this.ddlSalesRank.SelectedIndexChanged += new System.EventHandler(this.ddlSalesRank_SelectedIndexChanged);
            // 
            // grpCommPT
            // 
            this.grpCommPT.Controls.Add(this.btn_AddPT);
            this.grpCommPT.Controls.Add(this.btn_DelPT);
            this.grpCommPT.Controls.Add(this.groupControl3);
            this.grpCommPT.Location = new System.Drawing.Point(4, 48);
            this.grpCommPT.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.grpCommPT.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grpCommPT.Name = "grpCommPT";
            this.grpCommPT.Size = new System.Drawing.Size(960, 237);
            this.grpCommPT.TabIndex = 137;
            this.grpCommPT.Text = "Sales Target";
            this.grpCommPT.Visible = false;
            // 
            // btn_AddPT
            // 
            this.btn_AddPT.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddPT.Appearance.Options.UseFont = true;
            this.btn_AddPT.Appearance.Options.UseTextOptions = true;
            this.btn_AddPT.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btn_AddPT.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.btn_AddPT.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btn_AddPT.ImageIndex = 0;
            this.btn_AddPT.ImageList = this.imageList1;
            this.btn_AddPT.ImeMode = System.Windows.Forms.ImeMode.On;
            this.btn_AddPT.Location = new System.Drawing.Point(8, 24);
            this.btn_AddPT.Name = "btn_AddPT";
            this.btn_AddPT.Size = new System.Drawing.Size(38, 16);
            this.btn_AddPT.TabIndex = 136;
            this.btn_AddPT.Click += new System.EventHandler(this.btn_AddPT_Click);
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
            // btn_DelPT
            // 
            this.btn_DelPT.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DelPT.Appearance.Options.UseFont = true;
            this.btn_DelPT.Appearance.Options.UseTextOptions = true;
            this.btn_DelPT.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btn_DelPT.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.btn_DelPT.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btn_DelPT.ImageIndex = 1;
            this.btn_DelPT.ImageList = this.imageList1;
            this.btn_DelPT.Location = new System.Drawing.Point(48, 24);
            this.btn_DelPT.Name = "btn_DelPT";
            this.btn_DelPT.Size = new System.Drawing.Size(38, 16);
            this.btn_DelPT.TabIndex = 135;
            this.btn_DelPT.Click += new System.EventHandler(this.btn_DelPT_Click);
            // 
            // groupControl3
            // 
            this.groupControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl3.Controls.Add(this.gridControlMd_CommPT);
            this.groupControl3.Location = new System.Drawing.Point(0, 40);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(952, 192);
            this.groupControl3.TabIndex = 2;
            this.groupControl3.Text = "groupControl3";
            // 
            // gridControlMd_CommPT
            // 
            this.gridControlMd_CommPT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlMd_CommPT.Location = new System.Drawing.Point(0, 0);
            this.gridControlMd_CommPT.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControlMd_CommPT.MainView = this.gridViewMd_CommPT;
            this.gridControlMd_CommPT.Name = "gridControlMd_CommPT";
            this.gridControlMd_CommPT.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1,
            this.repositoryItemDateEdit1,
            this.repositoryItemDateEdit2,
            this.lk_Position3,
            this.lk_BranchCode3,
            this.chk_Month3});
            this.gridControlMd_CommPT.Size = new System.Drawing.Size(952, 192);
            this.gridControlMd_CommPT.TabIndex = 2;
            this.gridControlMd_CommPT.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMd_CommPT});
            // 
            // gridViewMd_CommPT
            // 
            this.gridViewMd_CommPT.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnCommPT8,
            this.gridColumnCommPT9,
            this.gridColumnCommPT10,
            this.gridColumnCommPT1,
            this.gridColumnCommPT2,
            this.gridColumnCommPT3,
            this.gridColumnCommPT4,
            this.gridColumnCommPT5,
            this.gridColumnCommPT6,
            this.gridColumnCommPT7,
            this.gridColumnCommPT11});
            this.gridViewMd_CommPT.GridControl = this.gridControlMd_CommPT;
            this.gridViewMd_CommPT.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridViewMd_CommPT.Name = "gridViewMd_CommPT";
            this.gridViewMd_CommPT.OptionsView.ColumnAutoWidth = false;
            this.gridViewMd_CommPT.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            this.gridViewMd_CommPT.OptionsView.ShowGroupPanel = false;
            this.gridViewMd_CommPT.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridViewMd_CommPT.LostFocus += new System.EventHandler(this.gridViewMd_CommPT_LostFocus);
            // 
            // gridColumnCommPT8
            // 
            this.gridColumnCommPT8.Caption = "Branch";
            this.gridColumnCommPT8.ColumnEdit = this.lk_BranchCode3;
            this.gridColumnCommPT8.FieldName = "strBranchCode";
            this.gridColumnCommPT8.Name = "gridColumnCommPT8";
            this.gridColumnCommPT8.Visible = true;
            this.gridColumnCommPT8.VisibleIndex = 0;
            this.gridColumnCommPT8.Width = 90;
            // 
            // lk_BranchCode3
            // 
            this.lk_BranchCode3.AutoHeight = false;
            this.lk_BranchCode3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lk_BranchCode3.Name = "lk_BranchCode3";
            // 
            // gridColumnCommPT9
            // 
            this.gridColumnCommPT9.Caption = "Year";
            this.gridColumnCommPT9.FieldName = "nYear";
            this.gridColumnCommPT9.Name = "gridColumnCommPT9";
            this.gridColumnCommPT9.Visible = true;
            this.gridColumnCommPT9.VisibleIndex = 1;
            this.gridColumnCommPT9.Width = 90;
            // 
            // gridColumnCommPT10
            // 
            this.gridColumnCommPT10.Caption = "Month";
            this.gridColumnCommPT10.ColumnEdit = this.chk_Month3;
            this.gridColumnCommPT10.FieldName = "nMonth";
            this.gridColumnCommPT10.Name = "gridColumnCommPT10";
            this.gridColumnCommPT10.Visible = true;
            this.gridColumnCommPT10.VisibleIndex = 2;
            this.gridColumnCommPT10.Width = 90;
            // 
            // chk_Month3
            // 
            this.chk_Month3.AutoHeight = false;
            this.chk_Month3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.chk_Month3.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.chk_Month3.Name = "chk_Month3";
            // 
            // gridColumnCommPT1
            // 
            this.gridColumnCommPT1.Caption = "Position";
            this.gridColumnCommPT1.ColumnEdit = this.lk_Position3;
            this.gridColumnCommPT1.FieldName = "strCommID";
            this.gridColumnCommPT1.Name = "gridColumnCommPT1";
            this.gridColumnCommPT1.Visible = true;
            this.gridColumnCommPT1.VisibleIndex = 3;
            this.gridColumnCommPT1.Width = 90;
            // 
            // lk_Position3
            // 
            this.lk_Position3.AutoHeight = false;
            this.lk_Position3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lk_Position3.Name = "lk_Position3";
            // 
            // gridColumnCommPT2
            // 
            this.gridColumnCommPT2.Caption = "Description";
            this.gridColumnCommPT2.FieldName = "strDesc";
            this.gridColumnCommPT2.Name = "gridColumnCommPT2";
            this.gridColumnCommPT2.OptionsFilter.AllowFilter = false;
            this.gridColumnCommPT2.Visible = true;
            this.gridColumnCommPT2.VisibleIndex = 4;
            this.gridColumnCommPT2.Width = 90;
            // 
            // gridColumnCommPT3
            // 
            this.gridColumnCommPT3.Caption = "PT Session From";
            this.gridColumnCommPT3.FieldName = "nPTSessionFrom";
            this.gridColumnCommPT3.Name = "gridColumnCommPT3";
            this.gridColumnCommPT3.OptionsFilter.AllowFilter = false;
            this.gridColumnCommPT3.Visible = true;
            this.gridColumnCommPT3.VisibleIndex = 5;
            this.gridColumnCommPT3.Width = 90;
            // 
            // gridColumnCommPT4
            // 
            this.gridColumnCommPT4.Caption = "PT Session To";
            this.gridColumnCommPT4.FieldName = "nPTSessionTo";
            this.gridColumnCommPT4.Name = "gridColumnCommPT4";
            this.gridColumnCommPT4.OptionsFilter.AllowFilter = false;
            this.gridColumnCommPT4.Visible = true;
            this.gridColumnCommPT4.VisibleIndex = 6;
            this.gridColumnCommPT4.Width = 90;
            // 
            // gridColumnCommPT5
            // 
            this.gridColumnCommPT5.Caption = "PT Comm";
            this.gridColumnCommPT5.FieldName = "nPTComm";
            this.gridColumnCommPT5.Name = "gridColumnCommPT5";
            this.gridColumnCommPT5.OptionsFilter.AllowFilter = false;
            this.gridColumnCommPT5.Visible = true;
            this.gridColumnCommPT5.VisibleIndex = 7;
            this.gridColumnCommPT5.Width = 90;
            // 
            // gridColumnCommPT6
            // 
            this.gridColumnCommPT6.Caption = "Target From";
            this.gridColumnCommPT6.FieldName = "mTargetFrom";
            this.gridColumnCommPT6.Name = "gridColumnCommPT6";
            this.gridColumnCommPT6.OptionsFilter.AllowFilter = false;
            this.gridColumnCommPT6.Visible = true;
            this.gridColumnCommPT6.VisibleIndex = 8;
            this.gridColumnCommPT6.Width = 90;
            // 
            // gridColumnCommPT7
            // 
            this.gridColumnCommPT7.Caption = "Target To";
            this.gridColumnCommPT7.FieldName = "mTargetTo";
            this.gridColumnCommPT7.Name = "gridColumnCommPT7";
            this.gridColumnCommPT7.OptionsFilter.AllowFilter = false;
            this.gridColumnCommPT7.Visible = true;
            this.gridColumnCommPT7.VisibleIndex = 9;
            this.gridColumnCommPT7.Width = 90;
            // 
            // gridColumnCommPT11
            // 
            this.gridColumnCommPT11.Caption = "CommPTID";
            this.gridColumnCommPT11.FieldName = "nCommPTID";
            this.gridColumnCommPT11.Name = "gridColumnCommPT11";
            this.gridColumnCommPT11.OptionsFilter.AllowFilter = false;
            this.gridColumnCommPT11.Width = 64;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            this.repositoryItemDateEdit1.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // repositoryItemDateEdit2
            // 
            this.repositoryItemDateEdit2.AutoHeight = false;
            this.repositoryItemDateEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit2.Name = "repositoryItemDateEdit2";
            this.repositoryItemDateEdit2.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // grpCommProductTherapist
            // 
            this.grpCommProductTherapist.Controls.Add(this.btn_AddProductTherapist);
            this.grpCommProductTherapist.Controls.Add(this.btn_DelProductTherapist);
            this.grpCommProductTherapist.Controls.Add(this.groupControl5);
            this.grpCommProductTherapist.Location = new System.Drawing.Point(4, 48);
            this.grpCommProductTherapist.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.grpCommProductTherapist.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grpCommProductTherapist.Name = "grpCommProductTherapist";
            this.grpCommProductTherapist.Size = new System.Drawing.Size(960, 237);
            this.grpCommProductTherapist.TabIndex = 121;
            this.grpCommProductTherapist.Text = "Sales Target";
            this.grpCommProductTherapist.Visible = false;
            // 
            // btn_AddProductTherapist
            // 
            this.btn_AddProductTherapist.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddProductTherapist.Appearance.Options.UseFont = true;
            this.btn_AddProductTherapist.Appearance.Options.UseTextOptions = true;
            this.btn_AddProductTherapist.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btn_AddProductTherapist.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.btn_AddProductTherapist.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btn_AddProductTherapist.ImageIndex = 0;
            this.btn_AddProductTherapist.ImageList = this.imageList1;
            this.btn_AddProductTherapist.ImeMode = System.Windows.Forms.ImeMode.On;
            this.btn_AddProductTherapist.Location = new System.Drawing.Point(8, 24);
            this.btn_AddProductTherapist.Name = "btn_AddProductTherapist";
            this.btn_AddProductTherapist.Size = new System.Drawing.Size(38, 16);
            this.btn_AddProductTherapist.TabIndex = 136;
            this.btn_AddProductTherapist.Click += new System.EventHandler(this.btn_AddProductTherapist_Click);
            // 
            // btn_DelProductTherapist
            // 
            this.btn_DelProductTherapist.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DelProductTherapist.Appearance.Options.UseFont = true;
            this.btn_DelProductTherapist.Appearance.Options.UseTextOptions = true;
            this.btn_DelProductTherapist.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btn_DelProductTherapist.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.btn_DelProductTherapist.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btn_DelProductTherapist.ImageIndex = 1;
            this.btn_DelProductTherapist.ImageList = this.imageList1;
            this.btn_DelProductTherapist.Location = new System.Drawing.Point(48, 24);
            this.btn_DelProductTherapist.Name = "btn_DelProductTherapist";
            this.btn_DelProductTherapist.Size = new System.Drawing.Size(38, 16);
            this.btn_DelProductTherapist.TabIndex = 135;
            this.btn_DelProductTherapist.Click += new System.EventHandler(this.btn_DelProductTherapist_Click);
            // 
            // groupControl5
            // 
            this.groupControl5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl5.Controls.Add(this.gridControlMd_CommProductTherapist);
            this.groupControl5.Location = new System.Drawing.Point(0, 40);
            this.groupControl5.Name = "groupControl5";
            this.groupControl5.Size = new System.Drawing.Size(952, 192);
            this.groupControl5.TabIndex = 2;
            this.groupControl5.Text = "groupControl5";
            // 
            // gridControlMd_CommProductTherapist
            // 
            this.gridControlMd_CommProductTherapist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlMd_CommProductTherapist.Location = new System.Drawing.Point(0, 0);
            this.gridControlMd_CommProductTherapist.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControlMd_CommProductTherapist.MainView = this.gridViewMd_CommProductTherapist;
            this.gridControlMd_CommProductTherapist.Name = "gridControlMd_CommProductTherapist";
            this.gridControlMd_CommProductTherapist.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lk_CreditCategoryID,
            this.EffCCStartDate,
            this.EffCCEndDate,
            this.lk_Position2,
            this.lk_BranchCode2,
            this.chk_Month2});
            this.gridControlMd_CommProductTherapist.Size = new System.Drawing.Size(952, 192);
            this.gridControlMd_CommProductTherapist.TabIndex = 2;
            this.gridControlMd_CommProductTherapist.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMd_CommProductTherapist});
            // 
            // gridViewMd_CommProductTherapist
            // 
            this.gridViewMd_CommProductTherapist.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnPT2,
            this.gridColumnPT4,
            this.gridColumnPT3,
            this.gridColumnPT1,
            this.gridColumnPT5,
            this.gridColumnPT6});
            this.gridViewMd_CommProductTherapist.GridControl = this.gridControlMd_CommProductTherapist;
            this.gridViewMd_CommProductTherapist.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridViewMd_CommProductTherapist.Name = "gridViewMd_CommProductTherapist";
            this.gridViewMd_CommProductTherapist.OptionsView.ColumnAutoWidth = false;
            this.gridViewMd_CommProductTherapist.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            this.gridViewMd_CommProductTherapist.OptionsView.ShowGroupPanel = false;
            this.gridViewMd_CommProductTherapist.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridViewMd_CommProductTherapist.LostFocus += new System.EventHandler(this.gridViewMd_CommProductTherapist_LostFocus);
            // 
            // gridColumnPT2
            // 
            this.gridColumnPT2.Caption = "Branch";
            this.gridColumnPT2.ColumnEdit = this.lk_BranchCode2;
            this.gridColumnPT2.FieldName = "strBranchCode";
            this.gridColumnPT2.Name = "gridColumnPT2";
            this.gridColumnPT2.Visible = true;
            this.gridColumnPT2.VisibleIndex = 0;
            this.gridColumnPT2.Width = 90;
            // 
            // lk_BranchCode2
            // 
            this.lk_BranchCode2.AutoHeight = false;
            this.lk_BranchCode2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lk_BranchCode2.Name = "lk_BranchCode2";
            // 
            // gridColumnPT4
            // 
            this.gridColumnPT4.Caption = "Year";
            this.gridColumnPT4.FieldName = "nYear";
            this.gridColumnPT4.Name = "gridColumnPT4";
            this.gridColumnPT4.Visible = true;
            this.gridColumnPT4.VisibleIndex = 1;
            this.gridColumnPT4.Width = 90;
            // 
            // gridColumnPT3
            // 
            this.gridColumnPT3.Caption = "Month";
            this.gridColumnPT3.ColumnEdit = this.chk_Month2;
            this.gridColumnPT3.FieldName = "nMonth";
            this.gridColumnPT3.Name = "gridColumnPT3";
            this.gridColumnPT3.Visible = true;
            this.gridColumnPT3.VisibleIndex = 2;
            this.gridColumnPT3.Width = 90;
            // 
            // chk_Month2
            // 
            this.chk_Month2.AutoHeight = false;
            this.chk_Month2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.chk_Month2.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.chk_Month2.Name = "chk_Month2";
            // 
            // gridColumnPT1
            // 
            this.gridColumnPT1.Caption = "Position";
            this.gridColumnPT1.ColumnEdit = this.lk_Position2;
            this.gridColumnPT1.FieldName = "strPosition";
            this.gridColumnPT1.Name = "gridColumnPT1";
            this.gridColumnPT1.Visible = true;
            this.gridColumnPT1.VisibleIndex = 3;
            this.gridColumnPT1.Width = 90;
            // 
            // lk_Position2
            // 
            this.lk_Position2.AutoHeight = false;
            this.lk_Position2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lk_Position2.Name = "lk_Position2";
            // 
            // gridColumnPT5
            // 
            this.gridColumnPT5.Caption = "Product Target";
            this.gridColumnPT5.FieldName = "mProductTarget";
            this.gridColumnPT5.Name = "gridColumnPT5";
            this.gridColumnPT5.OptionsFilter.AllowFilter = false;
            this.gridColumnPT5.Visible = true;
            this.gridColumnPT5.VisibleIndex = 4;
            this.gridColumnPT5.Width = 90;
            // 
            // gridColumnPT6
            // 
            this.gridColumnPT6.Caption = "Product Therapist ID";
            this.gridColumnPT6.FieldName = "nCommProductTherapistID";
            this.gridColumnPT6.Name = "gridColumnPT6";
            this.gridColumnPT6.OptionsFilter.AllowFilter = false;
            this.gridColumnPT6.Width = 111;
            // 
            // lk_CreditCategoryID
            // 
            this.lk_CreditCategoryID.AutoHeight = false;
            this.lk_CreditCategoryID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lk_CreditCategoryID.Name = "lk_CreditCategoryID";
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
            // EffCCEndDate
            // 
            this.EffCCEndDate.AutoHeight = false;
            this.EffCCEndDate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.EffCCEndDate.Name = "EffCCEndDate";
            this.EffCCEndDate.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // grpCommCST
            // 
            this.grpCommCST.Controls.Add(this.btn_AddCST);
            this.grpCommCST.Controls.Add(this.btn_DelCST);
            this.grpCommCST.Controls.Add(this.groupControl6);
            this.grpCommCST.Location = new System.Drawing.Point(4, 48);
            this.grpCommCST.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.grpCommCST.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grpCommCST.Name = "grpCommCST";
            this.grpCommCST.Size = new System.Drawing.Size(960, 237);
            this.grpCommCST.TabIndex = 138;
            this.grpCommCST.Text = "Sales Target";
            this.grpCommCST.Visible = false;
            // 
            // btn_AddCST
            // 
            this.btn_AddCST.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddCST.Appearance.Options.UseFont = true;
            this.btn_AddCST.Appearance.Options.UseTextOptions = true;
            this.btn_AddCST.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btn_AddCST.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.btn_AddCST.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btn_AddCST.ImageIndex = 0;
            this.btn_AddCST.ImageList = this.imageList1;
            this.btn_AddCST.ImeMode = System.Windows.Forms.ImeMode.On;
            this.btn_AddCST.Location = new System.Drawing.Point(8, 24);
            this.btn_AddCST.Name = "btn_AddCST";
            this.btn_AddCST.Size = new System.Drawing.Size(38, 16);
            this.btn_AddCST.TabIndex = 136;
            this.btn_AddCST.Click += new System.EventHandler(this.btn_AddCST_Click);
            // 
            // btn_DelCST
            // 
            this.btn_DelCST.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DelCST.Appearance.Options.UseFont = true;
            this.btn_DelCST.Appearance.Options.UseTextOptions = true;
            this.btn_DelCST.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btn_DelCST.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.btn_DelCST.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btn_DelCST.ImageIndex = 1;
            this.btn_DelCST.ImageList = this.imageList1;
            this.btn_DelCST.Location = new System.Drawing.Point(48, 24);
            this.btn_DelCST.Name = "btn_DelCST";
            this.btn_DelCST.Size = new System.Drawing.Size(38, 16);
            this.btn_DelCST.TabIndex = 135;
            this.btn_DelCST.Click += new System.EventHandler(this.btn_DelCST_Click);
            // 
            // groupControl6
            // 
            this.groupControl6.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl6.Controls.Add(this.gridControlMd_CommCST);
            this.groupControl6.Location = new System.Drawing.Point(0, 40);
            this.groupControl6.Name = "groupControl6";
            this.groupControl6.Size = new System.Drawing.Size(952, 192);
            this.groupControl6.TabIndex = 2;
            this.groupControl6.Text = "groupControl6";
            // 
            // gridControlMd_CommCST
            // 
            this.gridControlMd_CommCST.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlMd_CommCST.Location = new System.Drawing.Point(0, 0);
            this.gridControlMd_CommCST.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControlMd_CommCST.MainView = this.gridViewMd_CommCST;
            this.gridControlMd_CommCST.Name = "gridControlMd_CommCST";
            this.gridControlMd_CommCST.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit2,
            this.repositoryItemDateEdit3,
            this.repositoryItemDateEdit4,
            this.lk_Position4,
            this.lk_BranchCode4,
            this.chk_Month4});
            this.gridControlMd_CommCST.Size = new System.Drawing.Size(952, 192);
            this.gridControlMd_CommCST.TabIndex = 2;
            this.gridControlMd_CommCST.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMd_CommCST});
            // 
            // gridViewMd_CommCST
            // 
            this.gridViewMd_CommCST.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnCST3,
            this.gridColumnCST7,
            this.gridColumnCST8,
            this.gridColumnCST1,
            this.gridColumnCST2,
            this.gridColumnCST4,
            this.gridColumnCST5,
            this.gridColumnCST6,
            this.gridColumnCST9});
            this.gridViewMd_CommCST.GridControl = this.gridControlMd_CommCST;
            this.gridViewMd_CommCST.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridViewMd_CommCST.Name = "gridViewMd_CommCST";
            this.gridViewMd_CommCST.OptionsView.ColumnAutoWidth = false;
            this.gridViewMd_CommCST.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            this.gridViewMd_CommCST.OptionsView.ShowGroupPanel = false;
            this.gridViewMd_CommCST.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridViewMd_CommCST.LostFocus += new System.EventHandler(this.gridViewMd_CommCST_LostFocus);
            // 
            // gridColumnCST3
            // 
            this.gridColumnCST3.Caption = "Branch";
            this.gridColumnCST3.ColumnEdit = this.lk_BranchCode4;
            this.gridColumnCST3.FieldName = "strBranch";
            this.gridColumnCST3.Name = "gridColumnCST3";
            this.gridColumnCST3.Visible = true;
            this.gridColumnCST3.VisibleIndex = 0;
            this.gridColumnCST3.Width = 90;
            // 
            // lk_BranchCode4
            // 
            this.lk_BranchCode4.AutoHeight = false;
            this.lk_BranchCode4.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lk_BranchCode4.Name = "lk_BranchCode4";
            // 
            // gridColumnCST7
            // 
            this.gridColumnCST7.Caption = "Year";
            this.gridColumnCST7.FieldName = "nYear";
            this.gridColumnCST7.Name = "gridColumnCST7";
            this.gridColumnCST7.Visible = true;
            this.gridColumnCST7.VisibleIndex = 1;
            this.gridColumnCST7.Width = 90;
            // 
            // gridColumnCST8
            // 
            this.gridColumnCST8.Caption = "Month";
            this.gridColumnCST8.ColumnEdit = this.chk_Month4;
            this.gridColumnCST8.FieldName = "nMonth";
            this.gridColumnCST8.Name = "gridColumnCST8";
            this.gridColumnCST8.Visible = true;
            this.gridColumnCST8.VisibleIndex = 2;
            this.gridColumnCST8.Width = 90;
            // 
            // chk_Month4
            // 
            this.chk_Month4.AutoHeight = false;
            this.chk_Month4.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.chk_Month4.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.chk_Month4.Name = "chk_Month4";
            // 
            // gridColumnCST1
            // 
            this.gridColumnCST1.Caption = "Position";
            this.gridColumnCST1.ColumnEdit = this.lk_Position4;
            this.gridColumnCST1.FieldName = "strCommID";
            this.gridColumnCST1.Name = "gridColumnCST1";
            this.gridColumnCST1.Visible = true;
            this.gridColumnCST1.VisibleIndex = 3;
            this.gridColumnCST1.Width = 90;
            // 
            // lk_Position4
            // 
            this.lk_Position4.AutoHeight = false;
            this.lk_Position4.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lk_Position4.Name = "lk_Position4";
            // 
            // gridColumnCST2
            // 
            this.gridColumnCST2.Caption = "Description";
            this.gridColumnCST2.FieldName = "strDesc";
            this.gridColumnCST2.Name = "gridColumnCST2";
            this.gridColumnCST2.OptionsFilter.AllowFilter = false;
            this.gridColumnCST2.Visible = true;
            this.gridColumnCST2.VisibleIndex = 4;
            this.gridColumnCST2.Width = 90;
            // 
            // gridColumnCST4
            // 
            this.gridColumnCST4.Caption = "Commission";
            this.gridColumnCST4.FieldName = "nCommision";
            this.gridColumnCST4.Name = "gridColumnCST4";
            this.gridColumnCST4.OptionsFilter.AllowFilter = false;
            this.gridColumnCST4.Visible = true;
            this.gridColumnCST4.VisibleIndex = 5;
            this.gridColumnCST4.Width = 90;
            // 
            // gridColumnCST5
            // 
            this.gridColumnCST5.Caption = "Target From";
            this.gridColumnCST5.FieldName = "mTargetFrom";
            this.gridColumnCST5.Name = "gridColumnCST5";
            this.gridColumnCST5.OptionsFilter.AllowFilter = false;
            this.gridColumnCST5.Visible = true;
            this.gridColumnCST5.VisibleIndex = 6;
            this.gridColumnCST5.Width = 90;
            // 
            // gridColumnCST6
            // 
            this.gridColumnCST6.Caption = "Target To";
            this.gridColumnCST6.FieldName = "mTargetTo";
            this.gridColumnCST6.Name = "gridColumnCST6";
            this.gridColumnCST6.OptionsFilter.AllowFilter = false;
            this.gridColumnCST6.Visible = true;
            this.gridColumnCST6.VisibleIndex = 7;
            this.gridColumnCST6.Width = 90;
            // 
            // gridColumnCST9
            // 
            this.gridColumnCST9.Caption = "CommCST";
            this.gridColumnCST9.FieldName = "nCommCST";
            this.gridColumnCST9.Name = "gridColumnCST9";
            this.gridColumnCST9.OptionsFilter.AllowFilter = false;
            this.gridColumnCST9.Width = 60;
            // 
            // repositoryItemLookUpEdit2
            // 
            this.repositoryItemLookUpEdit2.AutoHeight = false;
            this.repositoryItemLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit2.Name = "repositoryItemLookUpEdit2";
            // 
            // repositoryItemDateEdit3
            // 
            this.repositoryItemDateEdit3.AutoHeight = false;
            this.repositoryItemDateEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit3.Name = "repositoryItemDateEdit3";
            this.repositoryItemDateEdit3.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // repositoryItemDateEdit4
            // 
            this.repositoryItemDateEdit4.AutoHeight = false;
            this.repositoryItemDateEdit4.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit4.Name = "repositoryItemDateEdit4";
            this.repositoryItemDateEdit4.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // grpCommMerge
            // 
            this.grpCommMerge.Controls.Add(this.btn_AddMerge);
            this.grpCommMerge.Controls.Add(this.btn_DelMerge);
            this.grpCommMerge.Controls.Add(this.groupControl7);
            this.grpCommMerge.Location = new System.Drawing.Point(4, 48);
            this.grpCommMerge.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.grpCommMerge.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grpCommMerge.Name = "grpCommMerge";
            this.grpCommMerge.Size = new System.Drawing.Size(960, 237);
            this.grpCommMerge.TabIndex = 139;
            this.grpCommMerge.Text = "Sales Target";
            this.grpCommMerge.Visible = false;
            // 
            // btn_AddMerge
            // 
            this.btn_AddMerge.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddMerge.Appearance.Options.UseFont = true;
            this.btn_AddMerge.Appearance.Options.UseTextOptions = true;
            this.btn_AddMerge.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btn_AddMerge.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.btn_AddMerge.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btn_AddMerge.ImageIndex = 0;
            this.btn_AddMerge.ImageList = this.imageList1;
            this.btn_AddMerge.ImeMode = System.Windows.Forms.ImeMode.On;
            this.btn_AddMerge.Location = new System.Drawing.Point(8, 24);
            this.btn_AddMerge.Name = "btn_AddMerge";
            this.btn_AddMerge.Size = new System.Drawing.Size(38, 16);
            this.btn_AddMerge.TabIndex = 136;
            this.btn_AddMerge.Click += new System.EventHandler(this.btn_AddMerge_Click);
            // 
            // btn_DelMerge
            // 
            this.btn_DelMerge.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DelMerge.Appearance.Options.UseFont = true;
            this.btn_DelMerge.Appearance.Options.UseTextOptions = true;
            this.btn_DelMerge.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btn_DelMerge.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.btn_DelMerge.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btn_DelMerge.ImageIndex = 1;
            this.btn_DelMerge.ImageList = this.imageList1;
            this.btn_DelMerge.Location = new System.Drawing.Point(48, 24);
            this.btn_DelMerge.Name = "btn_DelMerge";
            this.btn_DelMerge.Size = new System.Drawing.Size(38, 16);
            this.btn_DelMerge.TabIndex = 135;
            this.btn_DelMerge.Click += new System.EventHandler(this.btn_DelMerge_Click);
            // 
            // groupControl7
            // 
            this.groupControl7.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl7.Controls.Add(this.gridControlMd_CommMerge);
            this.groupControl7.Location = new System.Drawing.Point(0, 40);
            this.groupControl7.Name = "groupControl7";
            this.groupControl7.Size = new System.Drawing.Size(952, 192);
            this.groupControl7.TabIndex = 2;
            this.groupControl7.Text = "groupControl7";
            // 
            // gridControlMd_CommMerge
            // 
            this.gridControlMd_CommMerge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlMd_CommMerge.Location = new System.Drawing.Point(0, 0);
            this.gridControlMd_CommMerge.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControlMd_CommMerge.MainView = this.gridViewMd_CommMerge;
            this.gridControlMd_CommMerge.Name = "gridControlMd_CommMerge";
            this.gridControlMd_CommMerge.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit3,
            this.repositoryItemDateEdit5,
            this.repositoryItemDateEdit6,
            this.lk_BranchCode5,
            this.lk_Position5,
            this.chk_Month5});
            this.gridControlMd_CommMerge.Size = new System.Drawing.Size(952, 192);
            this.gridControlMd_CommMerge.TabIndex = 2;
            this.gridControlMd_CommMerge.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMd_CommMerge,
            this.gridView1});
            // 
            // gridViewMd_CommMerge
            // 
            this.gridViewMd_CommMerge.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnM3,
            this.gridColumnM7,
            this.gridColumnM8,
            this.gridColumnM1,
            this.gridColumnM2,
            this.gridColumnM4,
            this.gridColumnM5,
            this.gridColumnM6,
            this.gridColumnM9});
            this.gridViewMd_CommMerge.GridControl = this.gridControlMd_CommMerge;
            this.gridViewMd_CommMerge.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridViewMd_CommMerge.Name = "gridViewMd_CommMerge";
            this.gridViewMd_CommMerge.OptionsView.ColumnAutoWidth = false;
            this.gridViewMd_CommMerge.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            this.gridViewMd_CommMerge.OptionsView.ShowGroupPanel = false;
            this.gridViewMd_CommMerge.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridViewMd_CommMerge.LostFocus += new System.EventHandler(this.gridViewMd_CommMerge_LostFocus);
            // 
            // gridColumnM3
            // 
            this.gridColumnM3.Caption = "Branch";
            this.gridColumnM3.ColumnEdit = this.lk_BranchCode5;
            this.gridColumnM3.FieldName = "strBranch";
            this.gridColumnM3.Name = "gridColumnM3";
            this.gridColumnM3.Visible = true;
            this.gridColumnM3.VisibleIndex = 0;
            this.gridColumnM3.Width = 90;
            // 
            // lk_BranchCode5
            // 
            this.lk_BranchCode5.AutoHeight = false;
            this.lk_BranchCode5.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lk_BranchCode5.Name = "lk_BranchCode5";
            // 
            // gridColumnM7
            // 
            this.gridColumnM7.Caption = "Year";
            this.gridColumnM7.FieldName = "nYear";
            this.gridColumnM7.Name = "gridColumnM7";
            this.gridColumnM7.Visible = true;
            this.gridColumnM7.VisibleIndex = 1;
            this.gridColumnM7.Width = 90;
            // 
            // gridColumnM8
            // 
            this.gridColumnM8.Caption = "Month";
            this.gridColumnM8.ColumnEdit = this.chk_Month5;
            this.gridColumnM8.FieldName = "nMonth";
            this.gridColumnM8.Name = "gridColumnM8";
            this.gridColumnM8.Visible = true;
            this.gridColumnM8.VisibleIndex = 2;
            this.gridColumnM8.Width = 90;
            // 
            // chk_Month5
            // 
            this.chk_Month5.AutoHeight = false;
            this.chk_Month5.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.chk_Month5.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.chk_Month5.Name = "chk_Month5";
            // 
            // gridColumnM1
            // 
            this.gridColumnM1.Caption = "Position";
            this.gridColumnM1.ColumnEdit = this.lk_Position5;
            this.gridColumnM1.FieldName = "strCommID";
            this.gridColumnM1.Name = "gridColumnM1";
            this.gridColumnM1.Visible = true;
            this.gridColumnM1.VisibleIndex = 3;
            this.gridColumnM1.Width = 90;
            // 
            // lk_Position5
            // 
            this.lk_Position5.AutoHeight = false;
            this.lk_Position5.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lk_Position5.Name = "lk_Position5";
            // 
            // gridColumnM2
            // 
            this.gridColumnM2.Caption = "Description";
            this.gridColumnM2.FieldName = "strDesc";
            this.gridColumnM2.Name = "gridColumnM2";
            this.gridColumnM2.OptionsFilter.AllowFilter = false;
            this.gridColumnM2.Visible = true;
            this.gridColumnM2.VisibleIndex = 4;
            this.gridColumnM2.Width = 90;
            // 
            // gridColumnM4
            // 
            this.gridColumnM4.Caption = "Commission";
            this.gridColumnM4.FieldName = "nCommision";
            this.gridColumnM4.Name = "gridColumnM4";
            this.gridColumnM4.OptionsFilter.AllowFilter = false;
            this.gridColumnM4.Visible = true;
            this.gridColumnM4.VisibleIndex = 5;
            this.gridColumnM4.Width = 90;
            // 
            // gridColumnM5
            // 
            this.gridColumnM5.Caption = "Target From";
            this.gridColumnM5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnM5.FieldName = "mTargetFrom";
            this.gridColumnM5.Name = "gridColumnM5";
            this.gridColumnM5.OptionsFilter.AllowFilter = false;
            this.gridColumnM5.Visible = true;
            this.gridColumnM5.VisibleIndex = 6;
            this.gridColumnM5.Width = 90;
            // 
            // gridColumnM6
            // 
            this.gridColumnM6.Caption = "Target To";
            this.gridColumnM6.FieldName = "mTargetTo";
            this.gridColumnM6.Name = "gridColumnM6";
            this.gridColumnM6.OptionsFilter.AllowFilter = false;
            this.gridColumnM6.Visible = true;
            this.gridColumnM6.VisibleIndex = 7;
            this.gridColumnM6.Width = 90;
            // 
            // gridColumnM9
            // 
            this.gridColumnM9.Caption = "CommMerge";
            this.gridColumnM9.FieldName = "nCommMerge";
            this.gridColumnM9.Name = "gridColumnM9";
            this.gridColumnM9.OptionsFilter.AllowFilter = false;
            this.gridColumnM9.Width = 71;
            // 
            // repositoryItemLookUpEdit3
            // 
            this.repositoryItemLookUpEdit3.AutoHeight = false;
            this.repositoryItemLookUpEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit3.Name = "repositoryItemLookUpEdit3";
            // 
            // repositoryItemDateEdit5
            // 
            this.repositoryItemDateEdit5.AutoHeight = false;
            this.repositoryItemDateEdit5.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit5.Name = "repositoryItemDateEdit5";
            this.repositoryItemDateEdit5.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // repositoryItemDateEdit6
            // 
            this.repositoryItemDateEdit6.AutoHeight = false;
            this.repositoryItemDateEdit6.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit6.Name = "repositoryItemDateEdit6";
            this.repositoryItemDateEdit6.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControlMd_CommMerge;
            this.gridView1.Name = "gridView1";
            // 
            // grpCommMSE
            // 
            this.grpCommMSE.Controls.Add(this.btn_AddMSE);
            this.grpCommMSE.Controls.Add(this.btn_DelMSE);
            this.grpCommMSE.Controls.Add(this.groupControl1);
            this.grpCommMSE.Location = new System.Drawing.Point(4, 48);
            this.grpCommMSE.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.grpCommMSE.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grpCommMSE.Name = "grpCommMSE";
            this.grpCommMSE.Size = new System.Drawing.Size(960, 237);
            this.grpCommMSE.TabIndex = 118;
            this.grpCommMSE.Text = "Sales Target";
            this.grpCommMSE.Visible = false;
            // 
            // btn_AddMSE
            // 
            this.btn_AddMSE.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddMSE.Appearance.Options.UseFont = true;
            this.btn_AddMSE.Appearance.Options.UseTextOptions = true;
            this.btn_AddMSE.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btn_AddMSE.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.btn_AddMSE.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btn_AddMSE.ImageIndex = 0;
            this.btn_AddMSE.ImageList = this.imageList1;
            this.btn_AddMSE.ImeMode = System.Windows.Forms.ImeMode.On;
            this.btn_AddMSE.Location = new System.Drawing.Point(8, 24);
            this.btn_AddMSE.Name = "btn_AddMSE";
            this.btn_AddMSE.Size = new System.Drawing.Size(38, 16);
            this.btn_AddMSE.TabIndex = 132;
            this.btn_AddMSE.Click += new System.EventHandler(this.btn_AddMSE_Click);
            // 
            // btn_DelMSE
            // 
            this.btn_DelMSE.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DelMSE.Appearance.Options.UseFont = true;
            this.btn_DelMSE.Appearance.Options.UseTextOptions = true;
            this.btn_DelMSE.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btn_DelMSE.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.btn_DelMSE.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btn_DelMSE.ImageIndex = 1;
            this.btn_DelMSE.ImageList = this.imageList1;
            this.btn_DelMSE.Location = new System.Drawing.Point(48, 24);
            this.btn_DelMSE.Name = "btn_DelMSE";
            this.btn_DelMSE.Size = new System.Drawing.Size(38, 16);
            this.btn_DelMSE.TabIndex = 131;
            this.btn_DelMSE.Click += new System.EventHandler(this.btn_DelMSE_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl1.Controls.Add(this.gridControlMd_SalesTarget);
            this.groupControl1.Location = new System.Drawing.Point(0, 40);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(952, 192);
            this.groupControl1.TabIndex = 121;
            // 
            // gridControlMd_SalesTarget
            // 
            this.gridControlMd_SalesTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlMd_SalesTarget.Location = new System.Drawing.Point(0, 0);
            this.gridControlMd_SalesTarget.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControlMd_SalesTarget.MainView = this.gridViewMd_SalesTarget;
            this.gridControlMd_SalesTarget.Name = "gridControlMd_SalesTarget";
            this.gridControlMd_SalesTarget.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.de_nYear,
            this.strDesc,
            this.lk_SalesRank,
            this.tedit_Commission,
            this.tedit_strType,
            this.tedit_strCommID,
            this.tedit_strDesc,
            this.tedit_strBranch,
            this.tedit_mTargetFrom,
            this.tedit_mTargetTo,
            this.de_nMonth,
            this.tedit_nYear,
            this.tedit_nMonth,
            this.lk_BranchCode0,
            this.lk_Position0,
            this.chk_Month0});
            this.gridControlMd_SalesTarget.Size = new System.Drawing.Size(952, 192);
            this.gridControlMd_SalesTarget.TabIndex = 2;
            this.gridControlMd_SalesTarget.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMd_SalesTarget,
            this.cardView1});
            // 
            // gridViewMd_SalesTarget
            // 
            this.gridViewMd_SalesTarget.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.White;
            this.gridViewMd_SalesTarget.Appearance.ColumnFilterButton.BackColor2 = System.Drawing.Color.White;
            this.gridViewMd_SalesTarget.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.White;
            this.gridViewMd_SalesTarget.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridViewMd_SalesTarget.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gridViewMd_SalesTarget.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnPKG3,
            this.gridColumnPKG7,
            this.gridColumnPKG8,
            this.gridColumnPKG1,
            this.gridColumnPKG2,
            this.gridColumnPKG4,
            this.gridColumnPKG5,
            this.gridColumnPKG6,
            this.gridColumnPKG9});
            this.gridViewMd_SalesTarget.GridControl = this.gridControlMd_SalesTarget;
            this.gridViewMd_SalesTarget.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridViewMd_SalesTarget.Name = "gridViewMd_SalesTarget";
            this.gridViewMd_SalesTarget.OptionsView.ColumnAutoWidth = false;
            this.gridViewMd_SalesTarget.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            this.gridViewMd_SalesTarget.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridViewMd_SalesTarget.OptionsView.ShowGroupPanel = false;
            this.gridViewMd_SalesTarget.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridViewMd_SalesTarget.LostFocus += new System.EventHandler(this.gridViewMd_SalesTarget_LostFocus);
            // 
            // gridColumnPKG3
            // 
            this.gridColumnPKG3.Caption = "Branch";
            this.gridColumnPKG3.ColumnEdit = this.lk_BranchCode0;
            this.gridColumnPKG3.FieldName = "strBranch";
            this.gridColumnPKG3.Name = "gridColumnPKG3";
            this.gridColumnPKG3.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumnPKG3.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumnPKG3.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.List;
            this.gridColumnPKG3.Visible = true;
            this.gridColumnPKG3.VisibleIndex = 0;
            this.gridColumnPKG3.Width = 90;
            // 
            // lk_BranchCode0
            // 
            this.lk_BranchCode0.AutoHeight = false;
            this.lk_BranchCode0.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lk_BranchCode0.Name = "lk_BranchCode0";
            // 
            // gridColumnPKG7
            // 
            this.gridColumnPKG7.Caption = "Year";
            this.gridColumnPKG7.ColumnEdit = this.tedit_nYear;
            this.gridColumnPKG7.FieldName = "nYear";
            this.gridColumnPKG7.Name = "gridColumnPKG7";
            this.gridColumnPKG7.Visible = true;
            this.gridColumnPKG7.VisibleIndex = 1;
            this.gridColumnPKG7.Width = 90;
            // 
            // tedit_nYear
            // 
            this.tedit_nYear.AutoHeight = false;
            this.tedit_nYear.Name = "tedit_nYear";
            // 
            // gridColumnPKG8
            // 
            this.gridColumnPKG8.Caption = "Month";
            this.gridColumnPKG8.ColumnEdit = this.chk_Month0;
            this.gridColumnPKG8.FieldName = "nMonth";
            this.gridColumnPKG8.Name = "gridColumnPKG8";
            this.gridColumnPKG8.Visible = true;
            this.gridColumnPKG8.VisibleIndex = 2;
            this.gridColumnPKG8.Width = 90;
            // 
            // chk_Month0
            // 
            this.chk_Month0.AutoHeight = false;
            this.chk_Month0.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.chk_Month0.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.chk_Month0.Name = "chk_Month0";
            // 
            // gridColumnPKG1
            // 
            this.gridColumnPKG1.Caption = "Position";
            this.gridColumnPKG1.ColumnEdit = this.lk_Position0;
            this.gridColumnPKG1.FieldName = "strCommID";
            this.gridColumnPKG1.Name = "gridColumnPKG1";
            this.gridColumnPKG1.Visible = true;
            this.gridColumnPKG1.VisibleIndex = 3;
            this.gridColumnPKG1.Width = 90;
            // 
            // lk_Position0
            // 
            this.lk_Position0.AutoHeight = false;
            this.lk_Position0.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lk_Position0.Name = "lk_Position0";
            // 
            // gridColumnPKG2
            // 
            this.gridColumnPKG2.Caption = "Description";
            this.gridColumnPKG2.ColumnEdit = this.tedit_strDesc;
            this.gridColumnPKG2.FieldName = "strDesc";
            this.gridColumnPKG2.Name = "gridColumnPKG2";
            this.gridColumnPKG2.OptionsFilter.AllowFilter = false;
            this.gridColumnPKG2.Visible = true;
            this.gridColumnPKG2.VisibleIndex = 4;
            this.gridColumnPKG2.Width = 90;
            // 
            // tedit_strDesc
            // 
            this.tedit_strDesc.AutoHeight = false;
            this.tedit_strDesc.Name = "tedit_strDesc";
            // 
            // gridColumnPKG4
            // 
            this.gridColumnPKG4.Caption = "Commission";
            this.gridColumnPKG4.ColumnEdit = this.tedit_Commission;
            this.gridColumnPKG4.FieldName = "nCommision";
            this.gridColumnPKG4.Name = "gridColumnPKG4";
            this.gridColumnPKG4.OptionsFilter.AllowFilter = false;
            this.gridColumnPKG4.Visible = true;
            this.gridColumnPKG4.VisibleIndex = 5;
            this.gridColumnPKG4.Width = 90;
            // 
            // tedit_Commission
            // 
            this.tedit_Commission.AutoHeight = false;
            this.tedit_Commission.MaxLength = 50;
            this.tedit_Commission.Name = "tedit_Commission";
            // 
            // gridColumnPKG5
            // 
            this.gridColumnPKG5.Caption = "Target From";
            this.gridColumnPKG5.ColumnEdit = this.tedit_mTargetFrom;
            this.gridColumnPKG5.FieldName = "mTargetFrom";
            this.gridColumnPKG5.Name = "gridColumnPKG5";
            this.gridColumnPKG5.OptionsFilter.AllowFilter = false;
            this.gridColumnPKG5.Visible = true;
            this.gridColumnPKG5.VisibleIndex = 6;
            this.gridColumnPKG5.Width = 90;
            // 
            // tedit_mTargetFrom
            // 
            this.tedit_mTargetFrom.AutoHeight = false;
            this.tedit_mTargetFrom.Name = "tedit_mTargetFrom";
            // 
            // gridColumnPKG6
            // 
            this.gridColumnPKG6.Caption = "Target To";
            this.gridColumnPKG6.ColumnEdit = this.tedit_mTargetTo;
            this.gridColumnPKG6.FieldName = "mTargetTo";
            this.gridColumnPKG6.Name = "gridColumnPKG6";
            this.gridColumnPKG6.OptionsFilter.AllowFilter = false;
            this.gridColumnPKG6.Visible = true;
            this.gridColumnPKG6.VisibleIndex = 7;
            this.gridColumnPKG6.Width = 90;
            // 
            // tedit_mTargetTo
            // 
            this.tedit_mTargetTo.AutoHeight = false;
            this.tedit_mTargetTo.Name = "tedit_mTargetTo";
            // 
            // gridColumnPKG9
            // 
            this.gridColumnPKG9.Caption = "CommMSEID";
            this.gridColumnPKG9.FieldName = "nCommMSEID";
            this.gridColumnPKG9.Name = "gridColumnPKG9";
            this.gridColumnPKG9.OptionsFilter.AllowFilter = false;
            this.gridColumnPKG9.Width = 72;
            // 
            // de_nYear
            // 
            this.de_nYear.AutoHeight = false;
            this.de_nYear.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.de_nYear.Name = "de_nYear";
            this.de_nYear.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // strDesc
            // 
            this.strDesc.AutoHeight = false;
            this.strDesc.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.strDesc.Name = "strDesc";
            this.strDesc.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // lk_SalesRank
            // 
            this.lk_SalesRank.AutoHeight = false;
            this.lk_SalesRank.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lk_SalesRank.Name = "lk_SalesRank";
            // 
            // tedit_strType
            // 
            this.tedit_strType.AutoHeight = false;
            this.tedit_strType.MaxLength = 50;
            this.tedit_strType.Name = "tedit_strType";
            // 
            // tedit_strCommID
            // 
            this.tedit_strCommID.AutoHeight = false;
            this.tedit_strCommID.Name = "tedit_strCommID";
            // 
            // tedit_strBranch
            // 
            this.tedit_strBranch.AutoHeight = false;
            this.tedit_strBranch.Name = "tedit_strBranch";
            // 
            // de_nMonth
            // 
            this.de_nMonth.AutoHeight = false;
            this.de_nMonth.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.de_nMonth.Name = "de_nMonth";
            this.de_nMonth.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // tedit_nMonth
            // 
            this.tedit_nMonth.AutoHeight = false;
            this.tedit_nMonth.Name = "tedit_nMonth";
            // 
            // cardView1
            // 
            this.cardView1.FocusedCardTopFieldIndex = 0;
            this.cardView1.GridControl = this.gridControlMd_SalesTarget;
            this.cardView1.Name = "cardView1";
            // 
            // grpCommSpaConsult
            // 
            this.grpCommSpaConsult.Controls.Add(this.btn_AddSpaConsult);
            this.grpCommSpaConsult.Controls.Add(this.btn_DelSpaConsult);
            this.grpCommSpaConsult.Controls.Add(this.groupControl4);
            this.grpCommSpaConsult.Location = new System.Drawing.Point(4, 48);
            this.grpCommSpaConsult.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.grpCommSpaConsult.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grpCommSpaConsult.Name = "grpCommSpaConsult";
            this.grpCommSpaConsult.Size = new System.Drawing.Size(960, 237);
            this.grpCommSpaConsult.TabIndex = 119;
            this.grpCommSpaConsult.Text = "Sales Target";
            this.grpCommSpaConsult.Visible = false;
            // 
            // btn_AddSpaConsult
            // 
            this.btn_AddSpaConsult.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddSpaConsult.Appearance.Options.UseFont = true;
            this.btn_AddSpaConsult.Appearance.Options.UseTextOptions = true;
            this.btn_AddSpaConsult.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btn_AddSpaConsult.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.btn_AddSpaConsult.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btn_AddSpaConsult.ImageIndex = 0;
            this.btn_AddSpaConsult.ImageList = this.imageList1;
            this.btn_AddSpaConsult.ImeMode = System.Windows.Forms.ImeMode.On;
            this.btn_AddSpaConsult.Location = new System.Drawing.Point(8, 24);
            this.btn_AddSpaConsult.Name = "btn_AddSpaConsult";
            this.btn_AddSpaConsult.Size = new System.Drawing.Size(38, 16);
            this.btn_AddSpaConsult.TabIndex = 134;
            this.btn_AddSpaConsult.Click += new System.EventHandler(this.btn_AddSpaConsult_Click);
            // 
            // btn_DelSpaConsult
            // 
            this.btn_DelSpaConsult.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DelSpaConsult.Appearance.Options.UseFont = true;
            this.btn_DelSpaConsult.Appearance.Options.UseTextOptions = true;
            this.btn_DelSpaConsult.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btn_DelSpaConsult.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.btn_DelSpaConsult.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btn_DelSpaConsult.ImageIndex = 1;
            this.btn_DelSpaConsult.ImageList = this.imageList1;
            this.btn_DelSpaConsult.Location = new System.Drawing.Point(48, 24);
            this.btn_DelSpaConsult.Name = "btn_DelSpaConsult";
            this.btn_DelSpaConsult.Size = new System.Drawing.Size(38, 16);
            this.btn_DelSpaConsult.TabIndex = 133;
            this.btn_DelSpaConsult.Click += new System.EventHandler(this.btn_DelSpaConsult_Click);
            // 
            // groupControl4
            // 
            this.groupControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl4.Controls.Add(this.gridControlMd_CommSpaConsult);
            this.groupControl4.Location = new System.Drawing.Point(0, 40);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(952, 192);
            this.groupControl4.TabIndex = 2;
            // 
            // gridControlMd_CommSpaConsult
            // 
            this.gridControlMd_CommSpaConsult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlMd_CommSpaConsult.Location = new System.Drawing.Point(0, 0);
            this.gridControlMd_CommSpaConsult.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControlMd_CommSpaConsult.MainView = this.gridViewMd_CommSpaConsult;
            this.gridControlMd_CommSpaConsult.Name = "gridControlMd_CommSpaConsult";
            this.gridControlMd_CommSpaConsult.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lk_pkGroupCatID,
            this.tedit_SC_strCommID,
            this.lk_Position1,
            this.lk_BranchCode1,
            this.chk_Month1});
            this.gridControlMd_CommSpaConsult.Size = new System.Drawing.Size(952, 192);
            this.gridControlMd_CommSpaConsult.TabIndex = 2;
            this.gridControlMd_CommSpaConsult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMd_CommSpaConsult});
            // 
            // gridViewMd_CommSpaConsult
            // 
            this.gridViewMd_CommSpaConsult.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnPG3,
            this.gridColumnPG7,
            this.gridColumnPG8,
            this.gridColumnPG1,
            this.gridColumnPG2,
            this.gridColumnPG4,
            this.gridColumnPG9,
            this.gridColumnPG5,
            this.gridColumnPG6,
            this.gridColumnPG10});
            this.gridViewMd_CommSpaConsult.GridControl = this.gridControlMd_CommSpaConsult;
            this.gridViewMd_CommSpaConsult.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridViewMd_CommSpaConsult.Name = "gridViewMd_CommSpaConsult";
            this.gridViewMd_CommSpaConsult.OptionsView.ColumnAutoWidth = false;
            this.gridViewMd_CommSpaConsult.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            this.gridViewMd_CommSpaConsult.OptionsView.ShowGroupPanel = false;
            this.gridViewMd_CommSpaConsult.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridViewMd_CommSpaConsult.LostFocus += new System.EventHandler(this.gridViewMd_CommSpaConsult_LostFocus);
            // 
            // gridColumnPG3
            // 
            this.gridColumnPG3.Caption = "Branch";
            this.gridColumnPG3.ColumnEdit = this.lk_BranchCode1;
            this.gridColumnPG3.FieldName = "strBranch";
            this.gridColumnPG3.Name = "gridColumnPG3";
            this.gridColumnPG3.Visible = true;
            this.gridColumnPG3.VisibleIndex = 0;
            this.gridColumnPG3.Width = 90;
            // 
            // lk_BranchCode1
            // 
            this.lk_BranchCode1.AutoHeight = false;
            this.lk_BranchCode1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lk_BranchCode1.Name = "lk_BranchCode1";
            // 
            // gridColumnPG7
            // 
            this.gridColumnPG7.Caption = "Year";
            this.gridColumnPG7.FieldName = "nYear";
            this.gridColumnPG7.Name = "gridColumnPG7";
            this.gridColumnPG7.Visible = true;
            this.gridColumnPG7.VisibleIndex = 1;
            this.gridColumnPG7.Width = 90;
            // 
            // gridColumnPG8
            // 
            this.gridColumnPG8.Caption = "Month";
            this.gridColumnPG8.ColumnEdit = this.chk_Month1;
            this.gridColumnPG8.FieldName = "nMonth";
            this.gridColumnPG8.Name = "gridColumnPG8";
            this.gridColumnPG8.Visible = true;
            this.gridColumnPG8.VisibleIndex = 2;
            this.gridColumnPG8.Width = 90;
            // 
            // chk_Month1
            // 
            this.chk_Month1.AutoHeight = false;
            this.chk_Month1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.chk_Month1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.chk_Month1.Name = "chk_Month1";
            // 
            // gridColumnPG1
            // 
            this.gridColumnPG1.Caption = "Position";
            this.gridColumnPG1.ColumnEdit = this.lk_Position1;
            this.gridColumnPG1.FieldName = "strCommID";
            this.gridColumnPG1.Name = "gridColumnPG1";
            this.gridColumnPG1.Visible = true;
            this.gridColumnPG1.VisibleIndex = 3;
            this.gridColumnPG1.Width = 90;
            // 
            // lk_Position1
            // 
            this.lk_Position1.AutoHeight = false;
            this.lk_Position1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lk_Position1.Name = "lk_Position1";
            // 
            // gridColumnPG2
            // 
            this.gridColumnPG2.Caption = "Description";
            this.gridColumnPG2.FieldName = "strDesc";
            this.gridColumnPG2.Name = "gridColumnPG2";
            this.gridColumnPG2.OptionsFilter.AllowFilter = false;
            this.gridColumnPG2.Visible = true;
            this.gridColumnPG2.VisibleIndex = 4;
            this.gridColumnPG2.Width = 90;
            // 
            // gridColumnPG4
            // 
            this.gridColumnPG4.Caption = "Product Comm";
            this.gridColumnPG4.FieldName = "nProductComm";
            this.gridColumnPG4.Name = "gridColumnPG4";
            this.gridColumnPG4.OptionsFilter.AllowFilter = false;
            this.gridColumnPG4.Visible = true;
            this.gridColumnPG4.VisibleIndex = 5;
            this.gridColumnPG4.Width = 90;
            // 
            // gridColumnPG9
            // 
            this.gridColumnPG9.Caption = "Target From";
            this.gridColumnPG9.FieldName = "mPackageTargetFrom";
            this.gridColumnPG9.Name = "gridColumnPG9";
            this.gridColumnPG9.OptionsFilter.AllowFilter = false;
            this.gridColumnPG9.Visible = true;
            this.gridColumnPG9.VisibleIndex = 6;
            this.gridColumnPG9.Width = 90;
            // 
            // gridColumnPG5
            // 
            this.gridColumnPG5.Caption = "Target To";
            this.gridColumnPG5.FieldName = "mPackageTargetTo";
            this.gridColumnPG5.Name = "gridColumnPG5";
            this.gridColumnPG5.OptionsFilter.AllowFilter = false;
            this.gridColumnPG5.Visible = true;
            this.gridColumnPG5.VisibleIndex = 7;
            this.gridColumnPG5.Width = 90;
            // 
            // gridColumnPG6
            // 
            this.gridColumnPG6.Caption = "Package Comm";
            this.gridColumnPG6.FieldName = "nPackageComm";
            this.gridColumnPG6.Name = "gridColumnPG6";
            this.gridColumnPG6.OptionsFilter.AllowFilter = false;
            this.gridColumnPG6.Visible = true;
            this.gridColumnPG6.VisibleIndex = 8;
            this.gridColumnPG6.Width = 90;
            // 
            // gridColumnPG10
            // 
            this.gridColumnPG10.Caption = "SpaConsultID";
            this.gridColumnPG10.FieldName = "nCommSpaConsultID";
            this.gridColumnPG10.Name = "gridColumnPG10";
            this.gridColumnPG10.OptionsFilter.AllowFilter = false;
            this.gridColumnPG10.Width = 77;
            // 
            // lk_pkGroupCatID
            // 
            this.lk_pkGroupCatID.AutoHeight = false;
            this.lk_pkGroupCatID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lk_pkGroupCatID.Name = "lk_pkGroupCatID";
            // 
            // tedit_SC_strCommID
            // 
            this.tedit_SC_strCommID.AutoHeight = false;
            this.tedit_SC_strCommID.Name = "tedit_SC_strCommID";
            // 
            // frmSalesTarget
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(982, 635);
            this.Controls.Add(this.grpSalesRank);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSalesTarget";
            this.Text = "frmSalesTarget";
            ((System.ComponentModel.ISupportInitialize)(this.grpSalesRank)).EndInit();
            this.grpSalesRank.ResumeLayout(false);
            this.groupBoxCommMSE.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSalesRank.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpCommPT)).EndInit();
            this.grpCommPT.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMd_CommPT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMd_CommPT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_BranchCode3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_Month3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_Position3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpCommProductTherapist)).EndInit();
            this.grpCommProductTherapist.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
            this.groupControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMd_CommProductTherapist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMd_CommProductTherapist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_BranchCode2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_Month2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_Position2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_CreditCategoryID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EffCCStartDate.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EffCCStartDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EffCCEndDate.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EffCCEndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpCommCST)).EndInit();
            this.grpCommCST.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl6)).EndInit();
            this.groupControl6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMd_CommCST)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMd_CommCST)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_BranchCode4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_Month4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_Position4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit3.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit4.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpCommMerge)).EndInit();
            this.grpCommMerge.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl7)).EndInit();
            this.groupControl7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMd_CommMerge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMd_CommMerge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_BranchCode5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_Month5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_Position5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit5.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit6.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpCommMSE)).EndInit();
            this.grpCommMSE.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMd_SalesTarget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMd_SalesTarget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_BranchCode0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tedit_nYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_Month0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_Position0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tedit_strDesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tedit_Commission)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tedit_mTargetFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tedit_mTargetTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_nYear.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_nYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.strDesc.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.strDesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_SalesRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tedit_strType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tedit_strCommID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tedit_strBranch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_nMonth.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.de_nMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tedit_nMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpCommSpaConsult)).EndInit();
            this.grpCommSpaConsult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMd_CommSpaConsult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMd_CommSpaConsult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_BranchCode1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_Month1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_Position1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_pkGroupCatID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tedit_SC_strCommID)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
              
        #region Select/Load

        string load = "";
        string strSQL;
        private void ddlSalesRank_SelectedIndexChanged(object sender, EventArgs e)
        {
            load = ddlSalesRank.SelectedIndex.ToString();
            LoadBranchSalesTarget();            
        }

        private void LoadBranchSalesTarget()
        {
            DataTable dt;
            DataSet ds;

            ds = new DataSet();

            strSQL = "select RTRIM(strJobPositionCode) as strJobPositionCode from tblJobPosition";
            SqlHelper.FillDataset(connection, CommandType.Text, strSQL, ds, new string[] { "table" });
            dt = ds.Tables["table"];

            DevExpress.XtraEditors.Controls.LookUpColumnInfo[] col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[1];

            col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strJobPositionCode", "Position", 15, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.Ascending);

            new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(lk_Position0, dt, col, "strJobPositionCode", "strJobPositionCode", "Position");
            new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(lk_Position1, dt, col, "strJobPositionCode", "strJobPositionCode", "Position");
            new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(lk_Position2, dt, col, "strJobPositionCode", "strJobPositionCode", "Position");
            new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(lk_Position3, dt, col, "strJobPositionCode", "strJobPositionCode", "Position");
            new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(lk_Position4, dt, col, "strJobPositionCode", "strJobPositionCode", "Position");
            new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(lk_Position5, dt, col, "strJobPositionCode", "strJobPositionCode", "Position");

            ds = new DataSet();

            strSQL = "select strBranchCode from tblBranch";
            SqlHelper.FillDataset(connection, CommandType.Text, strSQL, ds, new string[] { "table" });
            dt = ds.Tables["table"];

            DevExpress.XtraEditors.Controls.LookUpColumnInfo[] col2 = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[1];

            col2[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strBranchCode", "Branch", 15, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.Ascending);

            new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(lk_BranchCode0, dt, col2, "strBranchCode", "strBranchCode", "Branch Code");
            new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(lk_BranchCode1, dt, col2, "strBranchCode", "strBranchCode", "Branch Code");
            new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(lk_BranchCode2, dt, col2, "strBranchCode", "strBranchCode", "Branch Code");
            new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(lk_BranchCode3, dt, col2, "strBranchCode", "strBranchCode", "Branch Code");
            new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(lk_BranchCode4, dt, col2, "strBranchCode", "strBranchCode", "Branch Code");
            new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(lk_BranchCode5, dt, col2, "strBranchCode", "strBranchCode", "Branch Code");

            if (load == "0")
            {
                strSQL = "select * from tblCommMSE";
                grpCommMSE.Visible = true;
                grpCommSpaConsult.Visible = false;
                grpCommProductTherapist.Visible = false;
                grpCommPT.Visible = false;
                grpCommCST.Visible = false;
                grpCommMerge.Visible = false;
                
                DataSet _ds = new DataSet();
                dtSalesTarget = new DataTable();
                SqlHelper.FillDataset(connection, CommandType.Text, strSQL, _ds, new string[] { "table" });
                dtSalesTarget = _ds.Tables["table"];                
                this.gridControlMd_SalesTarget.DataSource = dtSalesTarget;
            }
            else if (load == "1")
            {
                strSQL = "select * from tblCommSpaConsult";
                grpCommMSE.Visible = false;
                grpCommSpaConsult.Visible = true;
                grpCommProductTherapist.Visible = false;
                grpCommPT.Visible = false;
                grpCommCST.Visible = false;
                grpCommMerge.Visible = false;
                DataSet _ds = new DataSet();
                SqlHelper.FillDataset(connection, CommandType.Text, strSQL, _ds, new string[] { "table" });
                dtSalesTarget = _ds.Tables["table"];
                this.gridControlMd_CommSpaConsult.DataSource = dtSalesTarget;
            }
            else if (load == "2")
            {
                strSQL = "select * from tblCommProductTherapist";
                grpCommMSE.Visible = false;
                grpCommSpaConsult.Visible = false;
                grpCommProductTherapist.Visible = true;
                grpCommPT.Visible = false;
                grpCommCST.Visible = false;
                grpCommMerge.Visible = false;
                DataSet _ds = new DataSet();
                SqlHelper.FillDataset(connection, CommandType.Text, strSQL, _ds, new string[] { "table" });
                dtSalesTarget = _ds.Tables["table"];
                this.gridControlMd_CommProductTherapist.DataSource = dtSalesTarget;
            }
            else if (load == "3")
            {
                strSQL = "select * from tblCommPT";               
                grpCommMSE.Visible = false;
                grpCommSpaConsult.Visible = false;
                grpCommProductTherapist.Visible = false;
                grpCommPT.Visible = true;
                grpCommCST.Visible = false;
                grpCommMerge.Visible = false;
                DataSet _ds = new DataSet();
                SqlHelper.FillDataset(connection, CommandType.Text, strSQL, _ds, new string[] { "table" });
                dtSalesTarget = _ds.Tables["table"];
                this.gridControlMd_CommPT.DataSource = dtSalesTarget;
            }
            else if (load == "4")
            {
                strSQL = "select * from tblCommCST";
                grpCommMSE.Visible = false;
                grpCommSpaConsult.Visible = false;
                grpCommProductTherapist.Visible = false;
                grpCommPT.Visible = false;
                grpCommCST.Visible = true;
                grpCommMerge.Visible = false;
                DataSet _ds = new DataSet();
                SqlHelper.FillDataset(connection, CommandType.Text, strSQL, _ds, new string[] { "table" });
                dtSalesTarget = _ds.Tables["table"];
                this.gridControlMd_CommCST.DataSource = dtSalesTarget;

            }
            else if (load == "5")
            {
                strSQL = "select * from tblCommMerge";
                grpCommMSE.Visible = false;
                grpCommSpaConsult.Visible = false;
                grpCommProductTherapist.Visible = false;
                grpCommPT.Visible = false;
                grpCommCST.Visible = false;
                grpCommMerge.Visible = true;
                DataSet _ds = new DataSet();
                SqlHelper.FillDataset(connection, CommandType.Text, strSQL, _ds, new string[] { "table" });
                dtSalesTarget = _ds.Tables["table"];
                this.gridControlMd_CommMerge.DataSource = dtSalesTarget;

               
            }
        }

        #endregion

        #region CommMSE

        private bool AddNew = false;

        private void btn_AddMSE_Click(object sender, EventArgs e)
        {

            AddNew = true;
            DataRow dr = dtSalesTarget.NewRow();
            dtSalesTarget.Rows.Add(dr);
            this.gridControlMd_SalesTarget.Refresh();
            this.gridViewMd_SalesTarget.FocusedRowHandle = dtSalesTarget.Rows.Count - 1;
        }

        private void gridViewMd_SalesTarget_LostFocus(object sender, EventArgs e)
        {
            DataRow row = this.gridViewMd_SalesTarget.GetDataRow(gridViewMd_SalesTarget.FocusedRowHandle);

            string strSQL = "Select * from tblCommMSE";
            if (AddNew)
            {
                if (MSEFieldChecking(row))
                {
                    this.gridControlMd_SalesTarget.MainView.UpdateCurrentRow();
                    try
                    {
                        CreateCmdsAndUpdate(strSQL, dtSalesTarget);
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
                gridViewMd_SalesTarget.CloseEditor();
                gridViewMd_SalesTarget.UpdateCurrentRow();

                CreateCmdsAndUpdate(strSQL, dtSalesTarget);
            }
        }

        private bool MSEFieldChecking(DataRow dr)
        {//prevent empty cell when editing
            if (dr["strCommID"].ToString() == "")
                return false;

            if (dr["strBranch"].ToString() == "")
                return false;

            return true;
        }

        private void btn_DelMSE_Click(object sender, EventArgs e)
        {
            DataRow row = this.gridViewMd_SalesTarget.GetDataRow(gridViewMd_SalesTarget.FocusedRowHandle);
            if (row != null)
            {
                if (AddNew)
                {
                    AddNew = false;
                    gridViewMd_SalesTarget.DeleteRow(gridViewMd_SalesTarget.FocusedRowHandle);
                }
                else
                {

                    DialogResult result = MessageBox.Show(this, "Do you really want to delete this record? ",
                        "Delete?", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            SqlHelper.ExecuteNonQuery(connection, "del_CommMSE",
                                new SqlParameter("@nCommMSEID", row["nCommMSEID"].ToString())
                            );
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Delete Process Failed");
                            return;
                        }
                        MessageBox.Show("Record Deleted Successfully", "Message");
                        LoadBranchSalesTarget();
                    }
                }

            }
        }

        #endregion

        #region CommSpaConsult

        private void btn_AddSpaConsult_Click(object sender, EventArgs e)
        {
            AddNew = true;
            DataRow dr = dtSalesTarget.NewRow();

            dtSalesTarget.Rows.Add(dr);
            this.gridControlMd_CommSpaConsult.Refresh();
            this.gridViewMd_CommSpaConsult.FocusedRowHandle = dtSalesTarget.Rows.Count - 1;
        }

        private void gridViewMd_CommSpaConsult_LostFocus(object sender, EventArgs e)
        {
            DataRow row = this.gridViewMd_CommSpaConsult.GetDataRow(gridViewMd_CommSpaConsult.FocusedRowHandle);

            string strSQL = "Select * from tblCommSpaConsult";
            if (AddNew)
            {
                if (SpaConsultFieldChecking(row))
                {
                    this.gridControlMd_CommSpaConsult.MainView.UpdateCurrentRow();
                    try
                    {
                        CreateCmdsAndUpdate(strSQL, dtSalesTarget);
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
                gridViewMd_CommSpaConsult.CloseEditor();
                gridViewMd_CommSpaConsult.UpdateCurrentRow();

                CreateCmdsAndUpdate(strSQL, dtSalesTarget);
            }
        }

        private bool SpaConsultFieldChecking(DataRow dr)
        {//prevent empty cell when editing
            if (dr["nCommSpaConsultID"].ToString() == "")
                return false;

            return true;
        }

        private void btn_DelSpaConsult_Click(object sender, EventArgs e)
        {
            DataRow row = this.gridViewMd_CommSpaConsult.GetDataRow(gridViewMd_CommSpaConsult.FocusedRowHandle);
            if (row != null)
            {
                if (AddNew)
                {
                    AddNew = false;
                    gridViewMd_CommSpaConsult.DeleteRow(gridViewMd_CommSpaConsult.FocusedRowHandle);
                }
                else
                {

                    DialogResult result = MessageBox.Show(this, "Do you really want to delete this record? ",
                        "Delete?", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            SqlHelper.ExecuteNonQuery(connection, "del_CommSpaConsult",
                                new SqlParameter("@nCommSpaConsultID", row["nCommSpaConsultID"].ToString())
                            );
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Delete Process Failed");
                            return;
                        }
                        MessageBox.Show("Record Deleted Successfully", "Message");
                        LoadBranchSalesTarget();
                    }
                }

            }
        }

        #endregion

        #region CommProductTherapist

        private void btn_AddProductTherapist_Click(object sender, EventArgs e)
        {
            AddNew = true;
            DataRow dr = dtSalesTarget.NewRow();

            dtSalesTarget.Rows.Add(dr);
            this.gridControlMd_CommProductTherapist.Refresh();
            this.gridViewMd_CommProductTherapist.FocusedRowHandle = dtSalesTarget.Rows.Count - 1;
        }

        private void gridViewMd_CommProductTherapist_LostFocus(object sender, EventArgs e)
        {
            DataRow row = this.gridViewMd_CommProductTherapist.GetDataRow(gridViewMd_CommProductTherapist.FocusedRowHandle);

            string strSQL = "Select * from tblCommProductTherapist";
            if (AddNew)
            {
                if (ProductTherapistFieldChecking(row))
                {
                    this.gridControlMd_CommProductTherapist.MainView.UpdateCurrentRow();
                    try
                    {
                        CreateCmdsAndUpdate(strSQL, dtSalesTarget);
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
                gridViewMd_CommProductTherapist.CloseEditor();
                gridViewMd_CommProductTherapist.UpdateCurrentRow();

                CreateCmdsAndUpdate(strSQL, dtSalesTarget);
            }
        }

        private bool ProductTherapistFieldChecking(DataRow dr)
        {//prevent empty cell when editing
            if (dr["nCommProductTherapistID"].ToString() == "")
                return false;

            return true;
        }

        private void btn_DelProductTherapist_Click(object sender, EventArgs e)
        {
            DataRow row = this.gridViewMd_CommProductTherapist.GetDataRow(gridViewMd_CommProductTherapist.FocusedRowHandle);
            if (row != null)
            {
                if (AddNew)
                {
                    AddNew = false;
                    gridViewMd_CommProductTherapist.DeleteRow(gridViewMd_CommProductTherapist.FocusedRowHandle);
                }
                else
                {

                    DialogResult result = MessageBox.Show(this, "Do you really want to delete this record? ",
                        "Delete?", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            SqlHelper.ExecuteNonQuery(connection, "del_CommProductTherapist",
                                new SqlParameter("@nCommProductTherapistID", row["nCommProductTherapistID"].ToString())
                            );
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Delete Process Failed");
                            return;
                        }
                        MessageBox.Show("Record Deleted Successfully", "Message");
                        LoadBranchSalesTarget();
                    }
                }

            }
        }

        #endregion

        #region CommPT

        private void btn_AddPT_Click(object sender, EventArgs e)
        {
            AddNew = true;
            DataRow dr = dtSalesTarget.NewRow();

            dtSalesTarget.Rows.Add(dr);
            this.gridControlMd_CommPT.Refresh();
            this.gridViewMd_CommPT.FocusedRowHandle = dtSalesTarget.Rows.Count - 1;
        }

        private void gridViewMd_CommPT_LostFocus(object sender, EventArgs e)
        {
            DataRow row = this.gridViewMd_CommPT.GetDataRow(gridViewMd_CommPT.FocusedRowHandle);

            string strSQL = "Select * from tblCommPT";
            if (AddNew)
            {
                if (PTFieldChecking(row))
                {
                    this.gridControlMd_CommPT.MainView.UpdateCurrentRow();
                    try
                    {
                        CreateCmdsAndUpdate(strSQL, dtSalesTarget);
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
                gridViewMd_CommPT.CloseEditor();
                gridViewMd_CommPT.UpdateCurrentRow();

                CreateCmdsAndUpdate(strSQL, dtSalesTarget);
            }
        }

        private bool PTFieldChecking(DataRow dr)
        {//prevent empty cell when editing
            if (dr["nCommPTID"].ToString() == "")
                return false;

            return true;
        }

        private void btn_DelPT_Click(object sender, EventArgs e)
        {
            DataRow row = this.gridViewMd_CommPT.GetDataRow(gridViewMd_CommPT.FocusedRowHandle);
            if (row != null)
            {
                if (AddNew)
                {
                    AddNew = false;
                    gridViewMd_CommPT.DeleteRow(gridViewMd_CommPT.FocusedRowHandle);
                }
                else
                {

                    DialogResult result = MessageBox.Show(this, "Do you really want to delete this record? ",
                        "Delete?", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            SqlHelper.ExecuteNonQuery(connection, "del_CommPT",
                                new SqlParameter("@nCommPTID", row["nCommPTID"].ToString())
                            );
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Delete Process Failed");
                            return;
                        }
                        MessageBox.Show("Record Deleted Successfully", "Message");
                        LoadBranchSalesTarget();
                    }
                }

            }
        }

        #endregion

        #region CommCST

        private void btn_AddCST_Click(object sender, EventArgs e)
        {
            AddNew = true;
            DataRow dr = dtSalesTarget.NewRow();

            dtSalesTarget.Rows.Add(dr);
            this.gridControlMd_CommCST.Refresh();
            this.gridViewMd_CommCST.FocusedRowHandle = dtSalesTarget.Rows.Count - 1;
        }

        private void gridViewMd_CommCST_LostFocus(object sender, EventArgs e)
        {
            DataRow row = this.gridViewMd_CommCST.GetDataRow(gridViewMd_CommCST.FocusedRowHandle);

            string strSQL = "Select * from tblCommCST";
            if (AddNew)
            {                
                if (CSTFieldChecking(row))
                {
                    this.gridControlMd_CommCST.MainView.UpdateCurrentRow();
                    try
                    {
                        CreateCmdsAndUpdate(strSQL, dtSalesTarget);
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
                gridViewMd_CommCST.CloseEditor();
                gridViewMd_CommCST.UpdateCurrentRow();

                CreateCmdsAndUpdate(strSQL, dtSalesTarget);
            }
        }

        private bool CSTFieldChecking(DataRow dr)
        {//prevent empty cell when editing
            if (dr["strCommID"].ToString() == "")    
                return false;
             if (dr["strBranch"].ToString() == "")
                return false;

                return true;

        }

        private void btn_DelCST_Click(object sender, EventArgs e)
        {
            DataRow row = this.gridViewMd_CommCST.GetDataRow(gridViewMd_CommCST.FocusedRowHandle);
            if (row != null)
            {
                if (AddNew)
                {
                    AddNew = false;
                    gridViewMd_CommCST.DeleteRow(gridViewMd_CommCST.FocusedRowHandle);
                }
                else
                {

                    DialogResult result = MessageBox.Show(this, "Do you really want to delete this record? ",
                        "Delete?", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            SqlHelper.ExecuteNonQuery(connection, "del_CommCST",
                                new SqlParameter("@nCommCST", row["nCommCST"].ToString())
                            );
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Delete Process Failed");
                            return;
                        }
                        MessageBox.Show("Record Deleted Successfully", "Message");
                        LoadBranchSalesTarget();
                    }
                }

            }
        }

        #endregion

        #region CommMerge

        private void btn_AddMerge_Click(object sender, EventArgs e)
        {
            AddNew = true;
            DataRow dr = dtSalesTarget.NewRow();

            dtSalesTarget.Rows.Add(dr);
            this.gridControlMd_CommMerge.Refresh();
            this.gridViewMd_CommMerge.FocusedRowHandle = dtSalesTarget.Rows.Count - 1;
        }

        private void gridViewMd_CommMerge_LostFocus(object sender, EventArgs e)
        {
            DataRow row = this.gridViewMd_CommMerge.GetDataRow(gridViewMd_CommMerge.FocusedRowHandle);

            string strSQL = "Select * from tblCommMerge";
            if (AddNew)
            {
                if (MergeFieldChecking(row))
                {
                    this.gridControlMd_CommMerge.MainView.UpdateCurrentRow();
                    try
                    {
                        CreateCmdsAndUpdate(strSQL, dtSalesTarget);
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
                gridViewMd_CommMerge.CloseEditor();
                gridViewMd_CommMerge.UpdateCurrentRow();

                CreateCmdsAndUpdate(strSQL, dtSalesTarget);
            }
        }

        private bool MergeFieldChecking(DataRow dr)
        {//prevent empty cell when editing
            if (dr["strCommID"].ToString() == "")
                return false;
            if (dr["strBranch"].ToString() == "")
                return false;

            return true;
        }

        private void btn_DelMerge_Click(object sender, EventArgs e)
        {
            DataRow row = this.gridViewMd_CommMerge.GetDataRow(gridViewMd_CommMerge.FocusedRowHandle);
            if (row != null)
            {
                if (AddNew)
                {
                    AddNew = false;
                    gridViewMd_CommMerge.DeleteRow(gridViewMd_CommMerge.FocusedRowHandle);
                }
                else
                {

                    DialogResult result = MessageBox.Show(this, "Do you really want to delete this record? ",
                        "Delete?", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            SqlHelper.ExecuteNonQuery(connection, "del_CommMerge",
                                new SqlParameter("@nCommMerge", row["nCommMerge"].ToString())
                            );
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Delete Process Failed");
                            return;
                        }
                        MessageBox.Show("Record Deleted Successfully", "Message");
                        LoadBranchSalesTarget();
                    }
                }

            }
        }

        #endregion



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
                myTableName.AcceptChanges();
                myConn.Close();
            }

        private void LoadDuplicate()
        {
            SqlConnection dubConn = new SqlConnection(connectionString);
            SqlCommand sql = new SqlCommand("select strBranchCode from tblBranch order by strBranchCode", dubConn);
            
            dubConn.Open();
            SqlDataReader sqlReader = sql.ExecuteReader();

             while (sqlReader.Read())
             {
               combo_DuplicateBranchFrom.Items.Add(sqlReader["strBranchCode"].ToString());
               combo_DuplicateBranchTo.Items.Add(sqlReader["strBranchCode"].ToString());
             }
             dubConn.Close();

             sqlReader.Close();

             int nYearNow=DateTime.Now.Year;
             combo_DuplicateYearFrom.Items.Clear();
             for (int y=nYearNow-2;y<=nYearNow+2;y++)
             {
                 combo_DuplicateYearFrom.Items.Add(y.ToString());
                 combo_DuplicateYearTo.Items.Add(y.ToString());
             }

             combo_DuplicateBranchFrom.SelectedIndex = 0;
             combo_DuplicateBranchTo.SelectedIndex = 0;
             combo_DuplicateYearFrom.SelectedIndex = 0;
             combo_DuplicateYearTo.SelectedIndex = 0;

        }

        private void btn_Duplicate_Click(object sender, EventArgs e)
        {
            string nGetBranch, nSetBranch;
            int nGetYear, nSetYear;

            nGetBranch = combo_DuplicateBranchFrom.SelectedItem.ToString();
            nSetBranch = combo_DuplicateBranchTo.SelectedItem.ToString();
            nGetYear = int.Parse(combo_DuplicateYearFrom.SelectedItem.ToString());
            nSetYear = int.Parse(combo_DuplicateYearTo.SelectedItem.ToString());

            if (nGetBranch == nSetBranch && nGetYear == nSetYear) {
                DialogResult errorResult = MessageBox.Show("Unable to duplicate same branch and year");
                }
            else{
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to duplicate? \nDuplicate From: " + nGetBranch + " (" + nGetYear + ")\nDuplicate To: " + nSetBranch + " (" + nSetYear + ")", "Duplicate", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
               
            }
            else if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    if (load == "0")
                    {
                        SqlHelper.ExecuteNonQuery(connection, "sp_duplicate_tblCommMSE",
                        new SqlParameter("@nGetBranch", nGetBranch),
                        new SqlParameter("@nGetYear", nGetYear),
                        new SqlParameter("@nSetBranch", nSetBranch),
                        new SqlParameter("@nSetYear", nSetYear)
                        );
                    }
                    else if (load == "1")
                    {
                        SqlHelper.ExecuteNonQuery(connection, "sp_duplicate_tblCommSpaConsult",
                        new SqlParameter("@nGetBranch", nGetBranch),
                        new SqlParameter("@nGetYear", nGetYear),
                        new SqlParameter("@nSetBranch", nSetBranch),
                        new SqlParameter("@nSetYear", nSetYear)
                        );
                    }
                    else if (load == "2")
                    {
                        SqlHelper.ExecuteNonQuery(connection, "sp_duplicate_tblCommProductTherapist",
                        new SqlParameter("@nGetBranch", nGetBranch),
                        new SqlParameter("@nGetYear", nGetYear),
                        new SqlParameter("@nSetBranch", nSetBranch),
                        new SqlParameter("@nSetYear", nSetYear)
                        );
                    }
                    else if (load == "3")
                    {
                        SqlHelper.ExecuteNonQuery(connection, "sp_duplicate_tblCommPT",
                        new SqlParameter("@nGetBranch", nGetBranch),
                        new SqlParameter("@nGetYear", nGetYear),
                        new SqlParameter("@nSetBranch", nSetBranch),
                        new SqlParameter("@nSetYear", nSetYear)
                        );
                    }
                    else if (load == "4")
                    {
                        SqlHelper.ExecuteNonQuery(connection, "sp_duplicate_tblCommCST",
                        new SqlParameter("@nGetBranch", nGetBranch),
                        new SqlParameter("@nGetYear", nGetYear),
                        new SqlParameter("@nSetBranch", nSetBranch),
                        new SqlParameter("@nSetYear", nSetYear)
                        );
                    }
                    if (load == "5")
                    {
                        SqlHelper.ExecuteNonQuery(connection, "sp_duplicate_tblCommMerge",
                        new SqlParameter("@nGetBranch", nGetBranch),
                        new SqlParameter("@nGetYear", nGetYear),
                        new SqlParameter("@nSetBranch", nSetBranch),
                        new SqlParameter("@nSetYear", nSetYear)
                        );
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Insert Process Failed");
                    return;
                }
                MessageBox.Show("Record Inserted Successfully", "Message");
            }
            }
        }
     
    }
}
