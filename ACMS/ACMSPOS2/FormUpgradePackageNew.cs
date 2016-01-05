using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace ACMS.ACMSPOS2
{
    /// <summary>
    /// Summary description for FormUpgradePackage.
    /// </summary>
    public class FormUpgradePackageNew : System.Windows.Forms.Form
    {
        private string connectionString;
        private SqlConnection connection;
        DataTable dtCombo = new DataTable();
        DataSet _ds = new DataSet();
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        internal DevExpress.XtraGrid.Columns.GridColumn GridColumn28;
        internal DevExpress.XtraGrid.Columns.GridColumn GridColumn30;
        internal DevExpress.XtraGrid.Columns.GridColumn GridColumn31;
        internal DevExpress.XtraGrid.Columns.GridColumn GridColumn32;
        internal DevExpress.XtraGrid.Columns.GridColumn GridColumn33;
        internal DevExpress.XtraGrid.Columns.GridColumn GridColumn34;
        internal DevExpress.XtraGrid.Columns.GridColumn GridColumn35;
        internal DevExpress.XtraGrid.Columns.GridColumn GridColumn44;
        internal DevExpress.XtraGrid.Columns.GridColumn GridColumn45;
        internal DevExpress.XtraGrid.Columns.GridColumn GridColumn49;
        private DevExpress.XtraEditors.PanelControl panelControlMemberPackage;
        private DevExpress.XtraEditors.PanelControl panelControlPackage;
        private DevExpress.XtraGrid.GridControl GridControlMemberPackage;
        internal DevExpress.XtraGrid.Views.Grid.GridView gridViewMemberPackage;
        private IContainer components;
        private ACMSLogic.CreditAccount myCreditAccount;
        private ACMSLogic.POS myPOS;
        private ACMSLogic.MemberPackage myMemberPackage;
        private ACMSLogic.PackageCode myPackage;
        private DevExpress.XtraEditors.SimpleButton simpleButtonOK1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraGrid.Columns.GridColumn GridColumn50;
        internal DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colChecked;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private ToolTip toolTip1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DataView myDataView;

        public FormUpgradePackageNew(ACMSLogic.POS pos)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //            		

            myPOS = pos;
            myMemberPackage = new ACMSLogic.MemberPackage();
            myPackage = new ACMSLogic.PackageCode();
            myCreditAccount = new ACMSLogic.CreditAccount();
            connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"];
            connection = new SqlConnection(connectionString);
            Init();

        }


        private void Init()
        {
            myDataView = myMemberPackage.GetActive_n_NonFreeMemberPackage_For_POS_Calculation_New(myPOS);

            myCreditAccount.RefreshForConvert(myPOS.StrMembershipID, myPOS.NCategoryID, myPOS.ReceiptItemsTable);
            DeleteUntouchSameCreditPackage(myPOS);
            MergeNormalCreditPackage();            

            if (myPOS.NCategoryID == 4 || myPOS.NCategoryID == 5 || myPOS.NCategoryID == 6 || myPOS.NCategoryID == 7 || myPOS.NCategoryID == 9 || myPOS.NCategoryID == 36 || myPOS.NCategoryID == 37)
            {
                SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "sp_GetSpaComboPkgForConversion", _ds, new string[] { "Table" }, new SqlParameter("@strMembershipID", myPOS.StrMembershipID));
                dtCombo = _ds.Tables["table"];
                if (dtCombo.Rows.Count > 0)
                {
                    MergeNormalComboPackage();
                }
            }

            dtCombo.Dispose();
            myDataView.Table.DefaultView.RowFilter = " UsageBalAmt > 0 ";

            GridControlMemberPackage.DataSource = myDataView;
        }

        private void DeleteUntouchSameCreditPackage(ACMSLogic.POS myPOS)
        {
            if (myCreditAccount.Table != null)
            {
                foreach (DataRow drCredit in myCreditAccount.Table.Rows)
                {
                    DataRow[] foundRow = myPOS.ReceiptItemsTable.Select("strCode = '" + drCredit["strCreditPackageCode"] + "'");

                    if (foundRow.Length > 0 && drCredit["strBalNew"] == "New")
                    {
                        drCredit.Delete();
                    }
                }
                myCreditAccount.Table.AcceptChanges();
            }            
        }

        private void MergeNormalCreditPackage()
        {
            if (myCreditAccount.Table != null)
            {
                foreach (DataRow drCredit in myCreditAccount.Table.Rows)
                {
                    DataRow drNormal = myDataView.Table.DefaultView.Table.NewRow();
                    drNormal["strPackageType"] = drCredit["strPackageType"];
                    drNormal["nPackageID"] = drCredit["nCreditPackageID"];
                    drNormal["strDescription"] = drCredit["strDescription"];
                    drNormal["strMembershipID"] = drCredit["strMembershipID"];
                    drNormal["strPackageCode"] = drCredit["strCreditPackageCode"];
                    drNormal["dtPurchaseDate"] = drCredit["dtPurchaseDate"];
                    drNormal["dtStartDate"] = drCredit["dtStartDate"];
                    drNormal["dtExpiryDate"] = drCredit["dtExpiryDate"];
                    drNormal["fFree"] = drCredit["fFree"];
                    drNormal["strReceiptNo"] = drCredit["strReceiptNo"];
                    drNormal["nStatusID"] = drCredit["nStatusID"];
                    drNormal["nEmployeeID"] = drCredit["nEmployeeID"];
                    drNormal["strRemarks"] = drCredit["strRemarks"];
                    drNormal["dtLastEdit"] = drCredit["dtLastEditDate"];
                    drNormal["PaidAmt"] = 0;
                    drNormal["Balance"] = drCredit["Balance"];
                    drNormal["nBalance"] = drCredit["Balance"];
                    drNormal["nAdjust"] = 0;
                    drNormal["strUpgradeFrom"] = drCredit["strUpgradeFrom"];
                    drNormal["nCategoryID"] = drCredit["nCategoryID"];
                    drNormal["UsageBalAmt"] = drCredit["Balance"];
                    drNormal["nMaxSession"] = 8888;
                    drNormal["nFreeSession"] = 0;
                    drNormal["UsedSession"] = 0;
                    drNormal["strBalNew"] = drCredit["strBalNew"];
                    drNormal["nFreeUtil"] = drCredit["nFreeUtil"];
                    drNormal["mFreeUtil"] = drCredit["mFreeUtil"];
                    drNormal["strCalculation"] = drCredit["strCalculation"];
                    myDataView.Table.Rows.Add(drNormal);
                }
            }
        }

        private void MergeNormalComboPackage()
        {
            foreach (DataRow drCombo in dtCombo.Rows)
            {
                DataSet _ds2 = new DataSet();
                string strSQL = "Select dbo.GetReceiptOutstandingAmount('" + drCombo["strReceiptNo"].ToString() + "') as mOutStandingAmount ";
                SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA", _ds2, new string[] { "Table" }, new SqlParameter("@strSQL", strSQL));

                if (Convert.ToDouble(_ds2.Tables["table"].Rows[0]["mOutStandingAmount"]) <= 0.10)
                {                   
                    DataRow drNormal = myDataView.Table.DefaultView.Table.NewRow();
                    drNormal["strPackageType"] = drCombo["strPackageType"];
                    drNormal["nPackageID"] = drCombo["nEntryID"];
                    drNormal["strDescription"] = drCombo["strDescription"];
                    drNormal["strMembershipID"] = drCombo["strMembershipID"];
                    drNormal["strPackageCode"] = drCombo["strPackageGroupCode"];
                    drNormal["dtPurchaseDate"] = drCombo["dtDate"];
                    drNormal["dtStartDate"] = drCombo["dtStartDate"];
                    drNormal["dtExpiryDate"] = drCombo["dtExpiryDate"];
                    drNormal["fFree"] = 0;
                    drNormal["strReceiptNo"] = drCombo["strReceiptNo"];
                    drNormal["nStatusID"] = 0;
                    drNormal["nEmployeeID"] = drCombo["nEmployeeID"];
                    drNormal["strRemarks"] = "";
                    drNormal["dtLastEdit"] = drCombo["dtLastEditDate"];
                    drNormal["PaidAmt"] = 0;
                    drNormal["Balance"] = drCombo["Balance"];
                    drNormal["nBalance"] = drCombo["Balance"];
                    drNormal["nAdjust"] = 0;
                    drNormal["nCategoryID"] = drCombo["nCategoryID"];
                    drNormal["UsageBalAmt"] = drCombo["Balance"];
                    drNormal["nMaxSession"] = 8888;
                    drNormal["nFreeSession"] = 0;
                    drNormal["UsedSession"] = 0;
                    drNormal["strBalNew"] = "New";
                    drNormal["nFreeUtil"] = 0;
                    drNormal["mFreeUtil"] = 0;
                    myDataView.Table.Rows.Add(drNormal);
                }
                _ds.Dispose();
            }
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
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.panelControlMemberPackage = new DevExpress.XtraEditors.PanelControl();
            this.GridControlMemberPackage = new DevExpress.XtraGrid.GridControl();
            this.gridViewMemberPackage = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn30 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn31 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn32 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn33 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn35 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn44 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn45 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn50 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn49 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn34 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colChecked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.panelControlPackage = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonOK1 = new DevExpress.XtraEditors.SimpleButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlMemberPackage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlMemberPackage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMemberPackage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlPackage)).BeginInit();
            this.panelControlPackage.SuspendLayout();
            this.SuspendLayout();
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            this.repositoryItemCheckEdit2.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.repositoryItemCheckEdit2.ValueGrayed = "";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // panelControlMemberPackage
            // 
            this.panelControlMemberPackage.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControlMemberPackage.Location = new System.Drawing.Point(0, 0);
            this.panelControlMemberPackage.Name = "panelControlMemberPackage";
            this.panelControlMemberPackage.Size = new System.Drawing.Size(864, 220);
            this.panelControlMemberPackage.TabIndex = 1;
            // 
            // GridControlMemberPackage
            // 
            this.GridControlMemberPackage.Location = new System.Drawing.Point(-2, 13);
            this.GridControlMemberPackage.LookAndFeel.UseDefaultLookAndFeel = false;
            this.GridControlMemberPackage.MainView = this.gridViewMemberPackage;
            this.GridControlMemberPackage.Name = "GridControlMemberPackage";
            this.GridControlMemberPackage.Size = new System.Drawing.Size(818, 229);
            this.GridControlMemberPackage.TabIndex = 8;
            this.GridControlMemberPackage.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMemberPackage});
            this.GridControlMemberPackage.Click += new System.EventHandler(this.GridControlMemberPackage_Click);
            // 
            // gridViewMemberPackage
            // 
            this.gridViewMemberPackage.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.GridColumn28,
            this.GridColumn30,
            this.GridColumn31,
            this.GridColumn32,
            this.GridColumn33,
            this.GridColumn35,
            this.GridColumn44,
            this.GridColumn45,
            this.GridColumn50,
            this.GridColumn49,
            this.gridColumn14,
            this.GridColumn34,
            this.gridColumn13,
            this.colChecked,
            this.gridColumn2});
            this.gridViewMemberPackage.GridControl = this.GridControlMemberPackage;
            this.gridViewMemberPackage.GroupFormat = "";
            this.gridViewMemberPackage.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridViewMemberPackage.Name = "gridViewMemberPackage";
            this.gridViewMemberPackage.OptionsCustomization.AllowGroup = false;
            this.gridViewMemberPackage.OptionsCustomization.AllowSort = false;
            this.gridViewMemberPackage.OptionsView.ColumnAutoWidth = false;
            this.gridViewMemberPackage.OptionsView.ShowGroupPanel = false;
            this.gridViewMemberPackage.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewMemberPackage_FocusedRowChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Type";
            this.gridColumn1.FieldName = "strPackageType";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 100;
            // 
            // GridColumn28
            // 
            this.GridColumn28.Caption = "Package ID";
            this.GridColumn28.FieldName = "nPackageID";
            this.GridColumn28.Name = "GridColumn28";
            this.GridColumn28.OptionsColumn.AllowEdit = false;
            this.GridColumn28.OptionsColumn.AllowFocus = false;
            this.GridColumn28.OptionsFilter.AllowFilter = false;
            this.GridColumn28.Visible = true;
            this.GridColumn28.VisibleIndex = 2;
            this.GridColumn28.Width = 80;
            // 
            // GridColumn30
            // 
            this.GridColumn30.Caption = "Package Code";
            this.GridColumn30.FieldName = "strPackageCode";
            this.GridColumn30.Name = "GridColumn30";
            this.GridColumn30.OptionsColumn.AllowEdit = false;
            this.GridColumn30.OptionsColumn.AllowFocus = false;
            this.GridColumn30.OptionsFilter.AllowFilter = false;
            this.GridColumn30.Visible = true;
            this.GridColumn30.VisibleIndex = 3;
            this.GridColumn30.Width = 90;
            // 
            // GridColumn31
            // 
            this.GridColumn31.Caption = "Package Description";
            this.GridColumn31.FieldName = "strDescription";
            this.GridColumn31.Name = "GridColumn31";
            this.GridColumn31.OptionsColumn.AllowEdit = false;
            this.GridColumn31.OptionsColumn.AllowFocus = false;
            this.GridColumn31.OptionsFilter.AllowFilter = false;
            this.GridColumn31.Visible = true;
            this.GridColumn31.VisibleIndex = 4;
            this.GridColumn31.Width = 280;
            // 
            // GridColumn32
            // 
            this.GridColumn32.Caption = "Purchase Date";
            this.GridColumn32.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.GridColumn32.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.GridColumn32.FieldName = "dtPurchaseDate";
            this.GridColumn32.Name = "GridColumn32";
            this.GridColumn32.OptionsColumn.AllowEdit = false;
            this.GridColumn32.OptionsColumn.AllowFocus = false;
            this.GridColumn32.OptionsFilter.AllowFilter = false;
            this.GridColumn32.Width = 84;
            // 
            // GridColumn33
            // 
            this.GridColumn33.Caption = "Receipt No";
            this.GridColumn33.FieldName = "strReceiptNo";
            this.GridColumn33.Name = "GridColumn33";
            this.GridColumn33.OptionsColumn.AllowEdit = false;
            this.GridColumn33.OptionsColumn.AllowFocus = false;
            this.GridColumn33.OptionsFilter.AllowFilter = false;
            this.GridColumn33.Width = 82;
            // 
            // GridColumn35
            // 
            this.GridColumn35.Caption = "Start Date";
            this.GridColumn35.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.GridColumn35.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.GridColumn35.FieldName = "dtStartDate";
            this.GridColumn35.Name = "GridColumn35";
            this.GridColumn35.OptionsColumn.AllowEdit = false;
            this.GridColumn35.OptionsColumn.AllowFocus = false;
            this.GridColumn35.OptionsFilter.AllowFilter = false;
            this.GridColumn35.Width = 73;
            // 
            // GridColumn44
            // 
            this.GridColumn44.Caption = "Expiry Date";
            this.GridColumn44.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.GridColumn44.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.GridColumn44.FieldName = "dtExpiryDate";
            this.GridColumn44.Name = "GridColumn44";
            this.GridColumn44.OptionsColumn.AllowEdit = false;
            this.GridColumn44.OptionsColumn.AllowFocus = false;
            this.GridColumn44.OptionsFilter.AllowFilter = false;
            this.GridColumn44.Width = 104;
            // 
            // GridColumn45
            // 
            this.GridColumn45.Caption = "Free Indicator";
            this.GridColumn45.ColumnEdit = this.repositoryItemCheckEdit1;
            this.GridColumn45.FieldName = "fFree";
            this.GridColumn45.Name = "GridColumn45";
            this.GridColumn45.OptionsColumn.AllowEdit = false;
            this.GridColumn45.OptionsColumn.AllowFocus = false;
            this.GridColumn45.OptionsFilter.AllowFilter = false;
            this.GridColumn45.Width = 110;
            // 
            // GridColumn50
            // 
            this.GridColumn50.Caption = "Usage Balance Amount";
            this.GridColumn50.DisplayFormat.FormatString = "{0:C}";
            this.GridColumn50.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.GridColumn50.FieldName = "UsageBalAmt";
            this.GridColumn50.Name = "GridColumn50";
            this.GridColumn50.OptionsColumn.AllowEdit = false;
            this.GridColumn50.OptionsColumn.AllowFocus = false;
            this.GridColumn50.OptionsFilter.AllowFilter = false;
            this.GridColumn50.Visible = true;
            this.GridColumn50.VisibleIndex = 5;
            this.GridColumn50.Width = 134;
            // 
            // GridColumn49
            // 
            this.GridColumn49.Caption = "Remark";
            this.GridColumn49.FieldName = "strRemarks";
            this.GridColumn49.Name = "GridColumn49";
            this.GridColumn49.OptionsColumn.AllowEdit = false;
            this.GridColumn49.OptionsColumn.AllowFocus = false;
            this.GridColumn49.OptionsFilter.AllowFilter = false;
            this.GridColumn49.Visible = true;
            this.GridColumn49.VisibleIndex = 6;
            this.GridColumn49.Width = 70;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Paid Amount";
            this.gridColumn14.DisplayFormat.FormatString = "{0:C}";
            this.gridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn14.FieldName = "PaidAmt";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsColumn.AllowFocus = false;
            this.gridColumn14.OptionsFilter.AllowFilter = false;
            this.gridColumn14.Width = 90;
            // 
            // GridColumn34
            // 
            this.GridColumn34.Caption = "Balance";
            this.GridColumn34.FieldName = "strBalNew";
            this.GridColumn34.Name = "GridColumn34";
            this.GridColumn34.OptionsColumn.AllowEdit = false;
            this.GridColumn34.OptionsColumn.AllowFocus = false;
            this.GridColumn34.OptionsFilter.AllowFilter = false;
            this.GridColumn34.Visible = true;
            this.GridColumn34.VisibleIndex = 7;
            this.GridColumn34.Width = 60;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Unit Price";
            this.gridColumn13.DisplayFormat.FormatString = "{0:C}";
            this.gridColumn13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn13.FieldName = "mBaseUnitPrice";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowFocus = false;
            this.gridColumn13.OptionsFilter.AllowFilter = false;
            this.gridColumn13.Width = 57;
            // 
            // colChecked
            // 
            this.colChecked.ColumnEdit = this.repositoryItemCheckEdit2;
            this.colChecked.FieldName = "Checked";
            this.colChecked.Name = "colChecked";
            this.colChecked.Visible = true;
            this.colChecked.VisibleIndex = 0;
            this.colChecked.Width = 34;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Calculation";
            this.gridColumn2.FieldName = "strCalculation";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 8;
            // 
            // splitterControl1
            // 
            this.splitterControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterControl1.Location = new System.Drawing.Point(0, 0);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(979, 6);
            this.splitterControl1.TabIndex = 2;
            this.splitterControl1.TabStop = false;
            // 
            // panelControlPackage
            // 
            this.panelControlPackage.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControlPackage.Controls.Add(this.simpleButton2);
            this.panelControlPackage.Controls.Add(this.simpleButtonOK1);
            this.panelControlPackage.Controls.Add(this.GridControlMemberPackage);
            this.panelControlPackage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlPackage.Location = new System.Drawing.Point(0, 6);
            this.panelControlPackage.Name = "panelControlPackage";
            this.panelControlPackage.Size = new System.Drawing.Size(979, 316);
            this.panelControlPackage.TabIndex = 4;
            // 
            // simpleButton2
            // 
            this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.simpleButton2.Location = new System.Drawing.Point(644, 247);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 23);
            this.simpleButton2.TabIndex = 12;
            this.simpleButton2.Text = "Cancel";
            // 
            // simpleButtonOK1
            // 
            this.simpleButtonOK1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.simpleButtonOK1.Location = new System.Drawing.Point(557, 247);
            this.simpleButtonOK1.Name = "simpleButtonOK1";
            this.simpleButtonOK1.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonOK1.TabIndex = 11;
            this.simpleButtonOK1.Text = "OK";
            this.simpleButtonOK1.Click += new System.EventHandler(this.simpleButtonOK_Click);
            // 
            // FormUpgradePackageNew
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(979, 322);
            this.Controls.Add(this.panelControlPackage);
            this.Controls.Add(this.panelControlMemberPackage);
            this.Controls.Add(this.splitterControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormUpgradePackageNew";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Upgrade Selection";
            this.Load += new System.EventHandler(this.FormUpgradePackage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlMemberPackage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlMemberPackage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMemberPackage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlPackage)).EndInit();
            this.panelControlPackage.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        //private void gridViewMemberPackage_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        //{
        //    DataRow r = gridViewMemberPackage.GetDataRow(gridViewMemberPackage.FocusedRowHandle);

        //    if (r != null)
        //    {
        //        string strPackageCode = r["strPackageCode"].ToString();
        //        DataTable table = myPackage.GetAllValidUpgradablePackageBaseOldPackage(strPackageCode);

        //        if (!table.Columns.Contains("Checked"))
        //        {
        //            DataColumn colChecked = new DataColumn("Checked", typeof(bool));
        //            table.Columns.Add(colChecked);
        //        }

        //    }
        //}

        private void simpleButtonOK_Click(object sender, System.EventArgs e)
        {
            ACMS.XtraUtils.GridViewUtils.UpdateData(gridViewMemberPackage);

            DataRow[] rowToAdd = ((DataView)gridViewMemberPackage.DataSource).Table.Select("Checked = true ");
            if (rowToAdd.GetUpperBound(0) > -1)
            {
                if (Convert.ToDouble(((DataView)gridViewMemberPackage.DataSource).Table.Compute("SUM(UsageBalAmt)", "Checked = true ")) > Convert.ToDouble(myPOS.ReceiptMasterTable.Rows[0]["mNettAmount"]) + Convert.ToDouble(myPOS.ReceiptMasterTable.Rows[0]["mUpgradeAmount"]))
                {
                    myPOS.WantToUpgradeMemberPackageTable.Rows.Clear();
                    MessageBox.Show(this, "Total Usage Balance cannot greater than Nett Amount.");
                    this.DialogResult = DialogResult.None;
                    return;
                }
                
                if ((Convert.ToDouble(myPOS.ReceiptMasterTable.Rows[0]["nCategoryID"]) == 1 || Convert.ToDouble(myPOS.ReceiptMasterTable.Rows[0]["nCategoryID"]) == 3 || Convert.ToDouble(myPOS.ReceiptMasterTable.Rows[0]["nCategoryID"]) == 4 || Convert.ToDouble(myPOS.ReceiptMasterTable.Rows[0]["nCategoryID"]) == 5 || Convert.ToDouble(myPOS.ReceiptMasterTable.Rows[0]["nCategoryID"]) == 6 || Convert.ToDouble(myPOS.ReceiptMasterTable.Rows[0]["nCategoryID"]) == 7 || (Convert.ToDouble(myPOS.ReceiptMasterTable.Rows[0]["nCategoryID"]) == 36) || (Convert.ToDouble(myPOS.ReceiptMasterTable.Rows[0]["nCategoryID"]) == 37)))
                {
                    myPOS.IsNeedMinTopUp = true;                    
                    if (rowToAdd.GetUpperBound(0) >= 0)
                    {
                        if (rowToAdd[0]["strBalNew"].ToString() == "New")
                            myPOS.IsNeedMinTopUp = false;
                    }                                                               
                }
                double mDepositAmount = 0;

                if (myPOS.ReceiptMasterTable.Rows[0]["strParentReceiptNo"].ToString() != "")
                {
                    DataSet _ds = new DataSet();
                    DataTable _dt;
                    string cmdText = "Select mTotalAmount from tblReceipt where strReceiptNo=@strReceiptNo ";
                    SqlHelper.FillDataset(connection, CommandType.Text, cmdText, _ds, new string[] { "Table" }, new SqlParameter("@strReceiptNo", myPOS.ReceiptMasterTable.Rows[0]["strParentReceiptNo"].ToString()));

                    _dt = _ds.Tables["Table"];
                    mDepositAmount = Convert.ToDouble(_dt.Rows[0]["mTotalAmount"]);
                    _dt.Dispose();
                    _ds.Dispose();
                }
                if (((Convert.ToDouble(myPOS.ReceiptMasterTable.Rows[0]["mNettAmount"]) + Convert.ToDouble(myPOS.ReceiptMasterTable.Rows[0]["mUpgradeAmount"]) - Convert.ToDouble(((DataView)gridViewMemberPackage.DataSource).Table.Compute("SUM(UsageBalAmt)", "Checked = true "))) * 1.07) + mDepositAmount < 500 && (Convert.ToDouble(myPOS.ReceiptMasterTable.Rows[0]["nCategoryID"]) == 1 || Convert.ToDouble(myPOS.ReceiptMasterTable.Rows[0]["nCategoryID"]) == 3 || Convert.ToDouble(myPOS.ReceiptMasterTable.Rows[0]["nCategoryID"]) == 4 || Convert.ToDouble(myPOS.ReceiptMasterTable.Rows[0]["nCategoryID"]) == 5 || Convert.ToDouble(myPOS.ReceiptMasterTable.Rows[0]["nCategoryID"]) == 6 || Convert.ToDouble(myPOS.ReceiptMasterTable.Rows[0]["nCategoryID"]) == 7 || (Convert.ToDouble(myPOS.ReceiptMasterTable.Rows[0]["nCategoryID"]) == 36) || (Convert.ToDouble(myPOS.ReceiptMasterTable.Rows[0]["nCategoryID"]) == 37)))
                {                    
                    bool needToCheck = true;
                    
                    if (rowToAdd.GetUpperBound(0) >= 0)
                    {
                        if (rowToAdd[0]["strBalNew"].ToString() == "New")
                            needToCheck = false;
                    }
                    else
                    {
                        if (Convert.ToDouble(myPOS.ReceiptMasterTable.Rows[0]["mNettAmount"]) + Convert.ToDouble(myPOS.ReceiptMasterTable.Rows[0]["mUpgradeAmount"]) - Convert.ToDouble(((DataView)gridViewMemberPackage.DataSource).Table.Compute("SUM(UsageBalAmt)", "Checked = true AND (strBalNew<>'New' OR (strBalNew='New' AND strUpgradeFrom<>'')) ")) >= 500)
                            needToCheck = false;
                    }
                    
                    if (needToCheck)
                    {
                        myPOS.WantToUpgradeMemberPackageTable.Rows.Clear();
                        MessageBox.Show(this, "Bill total must be at least 500.");
                        this.DialogResult = DialogResult.None;
                        return;
                    }
                }
                myPOS.NewReceiptEntryForUpgrade2(rowToAdd, "");
            }
            else
            {
                myPOS.WantToUpgradeMemberPackageTable.Rows.Clear();
            }
        }

        //private void gridViewMemberPackage_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        //{
        //    if (e.Column.FieldName == "Balance")
        //    {
        //        if (ACMS.Convert.ToInt32(myDataView.Table.Rows[e.ListSourceRowIndex]["FNew"])== 1)
        //        {
        //            e.DisplayText = "New";
        //        }
        //    }
        //}

        private void GridControlMemberCredit_Click(object sender, System.EventArgs e)
        {

        }

        private void FormUpgradePackage_Load(object sender, System.EventArgs e)
        {

        }

        private void label2_Click(object sender, System.EventArgs e)
        {

        }

        private void GridControlMemberPackage_Click(object sender, System.EventArgs e)
        {

        }

        private void panelControl1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }

        private void gridControlPackage_Click(object sender, System.EventArgs e)
        {

        }

        private void panelControlTop_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //myDataView = myMemberPackage.GetActive_n_NonFreeMemberPackage_For_POS_Calculation_New(myPOS.StrMembershipID);pID);
            //GridControlMemberPackage.DataSource = myDataView;
            Init();
            GridControlMemberPackage.Show();
            GridControlMemberPackage.Focus();

        }

        //Added By TBBC on 15 September 2015 
        private void gridViewMemberPackage_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow row = gridViewMemberPackage.GetDataRow(gridViewMemberPackage.FocusedRowHandle);
            if (row != null)
            {
                string selectedValueKey = System.Convert.ToString(row["PromoDis"]);
                if (selectedValueKey == "100%FULL")
                {
                    string message = "You cannot upgrade package " + row["nPackageID"] + " first if you want to upgrade only one package! Please choose only 50% Discount Package first or both packages together!!!";
                    //You can upgrade only 50% Discount Package if you choose only one package!
                    string caption = "Upgrading from existing package to new package";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;
                    // Displays the MessageBox.


                    result = MessageBox.Show(message, caption, buttons);

                    if (result == System.Windows.Forms.DialogResult.OK)
                    {

                    }
                }
            }

        }


        //private void gridViewMemberCredit_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        //{
        //    DataRow r = gridViewMemberCredit.GetDataRow(gridViewMemberCredit.FocusedRowHandle);

        //    if (r != null)
        //    {
        //        string strPackageCode = r[2].ToString();
        //        string a = r[4].ToString();
        //        string aq1= r[7].ToString();

        //        decimal ListPrice = ACMS.Convert.ToDecimal(r["Balance"]);
        //        DataTable table = myPackage.GetUpgradeCreditPackageList(strPackageCode);
        //        if (!table.Columns.Contains("Checked"))
        //        {
        //            DataColumn colChecked = new DataColumn("Checked", typeof(bool));
        //            table.Columns.Add(colChecked);
        //        }

        //        //gridControlCredit.DataSource = table;
        //        table.DefaultView.RowFilter = "mListPrice >" + ListPrice;
        //        //				mListPrice
        //    }

        //}	
    }
}