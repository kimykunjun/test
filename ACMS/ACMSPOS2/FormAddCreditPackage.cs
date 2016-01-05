using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Configuration;
using ACMSDAL;

namespace ACMS.ACMSPOS2
{
	/// <summary>
	/// Summary description for FormAddCreditPackage.
	/// </summary>
	public class FormAddCreditPackage : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.PanelControl panelControl2;
		private DevExpress.XtraEditors.PanelControl panelControl3;
		private DevExpress.XtraGrid.GridControl gridControl1;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
		private DevExpress.XtraEditors.SimpleButton simpleButtonOK;
		private DevExpress.XtraGrid.Columns.GridColumn colItemCode;
		private DevExpress.XtraGrid.Columns.GridColumn colItemDescription;
		private DevExpress.XtraGrid.Columns.GridColumn colItemPrice;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        internal DevExpress.XtraGrid.Columns.GridColumn gridColumn299;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEditUtilizationSelection;
		private int myCategoryID;
		private ACMSLogic.POSHelper myPOSHelper;
        private DataTable myDataTable;
		private ACMSLogic.POS myPOS;
		private ACMS.XtraUtils.LookupEditBuilder.BankCodeLookupEditBuilder myBankCodeLookupEditBuilder;
		private DevExpress.XtraEditors.PanelControl pnlCtrlCenter;
		private DevExpress.XtraEditors.PanelControl pnlCtrlSearchProduct;
		private System.Windows.Forms.Label label6;
		private DevExpress.XtraEditors.SimpleButton simpleButton1;
		private DevExpress.XtraEditors.TextEdit txtEditSearchWord;
		private DevExpress.XtraGrid.Columns.GridColumn colBrand;
		private DevExpress.XtraGrid.Columns.GridColumn colStyle;
		private DevExpress.XtraGrid.Columns.GridColumn colSize;
		private DevExpress.XtraGrid.Columns.GridColumn colColor;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.PanelControl pnlCtrlBankInfo;
        internal Label lblAmount;
        internal DevExpress.XtraEditors.TextEdit txtCreditCardNo;
        private DateTimePicker dtProrateFrom;
        internal Label lblTotalAmt;
        private DevExpress.XtraEditors.TextEdit txtCardHolder;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private DevExpress.XtraGrid.Columns.GridColumn colStockQty;
		private ACMS.XtraUtils.LookupEditBuilder.BankBranchCodeLookupEditBuilder myBankBranchCodeLookupEditBuilder;
        private string connectionString;
        private SqlConnection connection;

		public FormAddCreditPackage(ACMSLogic.POS pos)
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
			myPOS = pos;
			myDataTable = new DataTable();
			myCategoryID = myPOS.NCategoryID;
			myPOSHelper= new ACMSLogic.POSHelper(myPOS);
			Init();
		}


		public void Init()
		{
			pnlCtrlBankInfo.Visible = false;
			pnlCtrlSearchProduct.Visible = false;

            if (myCategoryID == 1)
			{
				this.Text = "Purchase a Fitness Package.";
				label1.Text = "Please choose a Fitness Package in the following list.";
				
				colItemCode.FieldName = "strPackageCode";
				colItemDescription.FieldName = "strDescription";
				colItemPrice.FieldName = "mListPrice";
				myDataTable = myPOSHelper.GetDataTable();
				gridControl1.DataSource = myDataTable;
                simpleButton2.Visible = true;
			}
			else if (myCategoryID == 2)
			{
				this.Text = "Purchase a Fitness GIRO Package.";
				label1.Text = "Please choose a Fitness GIRO Package in the following list.";
				
				colItemCode.FieldName = "strPackageCode";
				colItemDescription.FieldName = "strDescription";
				colItemPrice.FieldName = "mListPrice";
				myDataTable = myPOSHelper.GetDataTable();
                gridControl1.DataSource = myDataTable;
                simpleButton2.Visible = true;
                pnlCtrlBankInfo.Visible = true;

			}
			else if (myCategoryID == 3)
			{
				this.Text = "Purchase a PT Package.";
				label1.Text = "Please choose a PT Package in the following list.";
				
				colItemCode.FieldName = "strPackageCode";
				colItemDescription.FieldName = "strDescription";
				colItemPrice.FieldName = "mListPrice";
				myDataTable = myPOSHelper.GetDataTable();
				gridControl1.DataSource = myDataTable;
			}
			else if (myCategoryID == 4)
			{
				this.Text = "Purchase a Spa Single Treatment.";
				label1.Text = "Please choose a Spa Single Treatment in the following list.";
				
				colItemCode.FieldName = "strPackageCode";
				colItemDescription.FieldName = "strDescription";
				colItemPrice.FieldName = "mListPrice";
				myDataTable = myPOSHelper.GetDataTable();
				gridControl1.DataSource = myDataTable;
			}
			else if (myCategoryID == 5)
			{
				this.Text = "Purchase a Spa Package.";
				label1.Text = "Please choose a Spa Package in the following list.";
				
				colItemCode.FieldName = "strPackageCode";
				colItemDescription.FieldName = "strDescription";
				colItemPrice.FieldName = "mListPrice";
				myDataTable = myPOSHelper.GetDataTable();
				gridControl1.DataSource = myDataTable;
			}
			else if (myCategoryID == 6)
			{
				this.Text = "Purchase a IPL Package.";
				label1.Text = "Please choose a IPL Package in the following list.";
				
				colItemCode.FieldName = "strPackageCode";
				colItemDescription.FieldName = "strDescription";
				colItemPrice.FieldName = "mListPrice";
				myDataTable = myPOSHelper.GetDataTable();
				gridControl1.DataSource = myDataTable;
			}
			else if (myCategoryID == 7)
			{
				this.Text = "Purchase a Spa Credit Package.";
				label1.Text = "Please choose a Spa credit package in the following list.";
				
				colItemCode.FieldName = "strCreditPackageCode";
				colItemDescription.FieldName = "strDescription";
				colItemPrice.FieldName = "mListPrice";
				myDataTable = myPOSHelper.GetDataTable();
				gridControl1.DataSource = myDataTable;
			}
			else if (myCategoryID == 8)
			{
				this.Text = "Purchase a Fitness Combined Package.";
				label1.Text = "Please choose a Fitness Combined Package in the following list.";
				
				colItemCode.FieldName = "strPackageGroupCode";
				colItemDescription.FieldName = "strDescription";
				colItemPrice.FieldName = "mListPrice";
				myDataTable = myPOSHelper.GetDataTable();
				gridControl1.DataSource = myDataTable;
			}
			else if (myCategoryID == 9)
			{
				this.Text = "Purchase a Spa Combined Package.";
				label1.Text = "Please choose a Spa Combined Package in the following list.";
				
				colItemCode.FieldName = "strPackageGroupCode";
				colItemDescription.FieldName = "strDescription";
				colItemPrice.FieldName = "mListPrice";
				myDataTable = myPOSHelper.GetDataTable();
				gridControl1.DataSource = myDataTable;
			}
			else if (myCategoryID == 11)
			{
				this.Text = "Purchase a Fitness Product.";
				label1.Text = "Please choose a fitness product in the following list.";
				
				colBrand.Visible = true;
				colStyle.Visible = true;
				colSize.Visible = true;
				colColor.Visible = true;
				colItemCode.FieldName = "strProductCode";
				colItemDescription.FieldName = "strDescription";
				colItemPrice.FieldName = "mBaseUnitPrice";
				myDataTable = myPOSHelper.GetDataTable();
				gridControl1.DataSource = myDataTable;
				pnlCtrlSearchProduct.Visible = true;
			}
			else if (myCategoryID == 12)
			{
				this.Text = "Purchase a SPA Product.";
				label1.Text = "Please choose a spa product in the following list.";
				colBrand.Visible = true;
				colStyle.Visible = true;
				colSize.Visible = true;
				colColor.Visible = true;
				colItemCode.FieldName = "strProductCode";
				colItemDescription.FieldName = "strDescription";
				colItemPrice.FieldName = "mBaseUnitPrice";
				myDataTable = myPOSHelper.GetDataTable();
				gridControl1.DataSource = myDataTable;
				pnlCtrlSearchProduct.Visible = true;
			}
            //else if (myCategoryID == 13)
            //{
            //    this.Text = "Purchase a Amore Holistic Credit Package.";
            //    label1.Text = "Please choose an Amore Holistic Credit package in the following list.";

            //    colItemCode.FieldName = "strCreditPackageCode";
            //    colItemDescription.FieldName = "strDescription";
            //    colItemPrice.FieldName = "mListPrice";
            //    myDataTable = myPOSHelper.GetDataTable();
            //    gridControl1.DataSource = myDataTable;
            //}
            else if (myCategoryID == 36)
            {
                this.Text = "Purchase a Holistic Fitness Package.";
                label1.Text = "Please choose an Holistic Fitness package in the following list.";

                colItemCode.FieldName = "strCreditPackageCode";
                colItemDescription.FieldName = "strDescription";
                colItemPrice.FieldName = "mListPrice";
                myDataTable = myPOSHelper.GetDataTable();
                gridControl1.DataSource = myDataTable;
            }
            else if (myCategoryID == 37)
            {
                this.Text = "Purchase a Holistic Spa Package.";
                label1.Text = "Please choose an Holistic Spa package in the following list.";

                colItemCode.FieldName = "strCreditPackageCode";
                colItemDescription.FieldName = "strDescription";
                colItemPrice.FieldName = "mListPrice";
                myDataTable = myPOSHelper.GetDataTable();
                gridControl1.DataSource = myDataTable;
            }
			else if (myCategoryID == 5)
			{
				this.Text = "Purchase a Spa Package.";
				label1.Text = "Please choose a Spa Package in the following list.";
				
				colItemCode.FieldName = "strPackageCode";
				colItemDescription.FieldName = "strDescription";
				colItemPrice.FieldName = "mListPrice";
				myDataTable = myPOSHelper.GetDataTable();
				gridControl1.DataSource = myDataTable;
			}
			else if (myCategoryID == 14)
			{
				this.Text = "Purchase Courses and Events.";
				label1.Text = "Please choose a Courses/Events in the following list.";
				
				colItemCode.FieldName = "strPackageCode";
				colItemDescription.FieldName = "strDescription";
				colItemPrice.FieldName = "mListPrice";
				myDataTable = myPOSHelper.GetDataTable();
				gridControl1.DataSource = myDataTable;
			}
			else if (myCategoryID == 23 || myCategoryID == 24)
			{
				this.Text = "Purchase Others";
				label1.Text = "Please choose a record in the following list.";
				
				colItemCode.FieldName = "strPackageCode";
				colItemDescription.FieldName = "strDescription";
				colItemPrice.FieldName = "mListPrice";
				myDataTable = myPOSHelper.GetDataTable();
				gridControl1.DataSource = myDataTable;
			}
            else if (myCategoryID == 38)
            {
                this.Text = "Purchase Cash Voucher";
                label1.Text = "Please choose a Cash Voucher in the following list.";
                colBrand.Visible = false;
                colStyle.Visible = false;
                colSize.Visible = false;
                colColor.Visible = false;
                pnlCtrlSearchProduct.Visible = true;
                colItemCode.FieldName = "strSN";
                colItemDescription.FieldName = "strDescription";
                colItemPrice.FieldName = "mValue";

                myDataTable = myPOSHelper.GetDataTable();
                gridControl1.DataSource = myDataTable;
            }
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
            this.repositoryItemCheckEditUtilizationSelection = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn299 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlCtrlCenter = new DevExpress.XtraEditors.PanelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItemDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItemPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBrand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStyle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSize = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colColor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStockQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlCtrlBankInfo = new DevExpress.XtraEditors.PanelControl();
            this.lblAmount = new System.Windows.Forms.Label();
            this.txtCreditCardNo = new DevExpress.XtraEditors.TextEdit();
            this.dtProrateFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTotalAmt = new System.Windows.Forms.Label();
            this.txtCardHolder = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.pnlCtrlSearchProduct = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEditSearchWord = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCtrlCenter)).BeginInit();
            this.pnlCtrlCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditUtilizationSelection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCtrlBankInfo)).BeginInit();
            this.pnlCtrlBankInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreditCardNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCardHolder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCtrlSearchProduct)).BeginInit();
            this.pnlCtrlSearchProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEditSearchWord.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(18, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(516, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // pnlCtrlCenter
            // 
            this.pnlCtrlCenter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlCtrlCenter.Controls.Add(this.gridControl1);
            this.pnlCtrlCenter.Controls.Add(this.pnlCtrlBankInfo);
            this.pnlCtrlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCtrlCenter.Location = new System.Drawing.Point(0, 72);
            this.pnlCtrlCenter.Name = "pnlCtrlCenter";
            this.pnlCtrlCenter.Size = new System.Drawing.Size(840, 355);
            this.pnlCtrlCenter.TabIndex = 2;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {            
            this.repositoryItemCheckEditUtilizationSelection});
            this.gridControl1.Size = new System.Drawing.Size(840, 205);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn299,
            this.colItemCode,
            this.colItemDescription,
            this.colItemPrice,
            this.colBrand,
            this.colStyle,
            this.colSize,
            this.colColor,
            this.colStockQty});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // gridColumn299
            // 
            this.gridColumn299.Caption = "Utl";
            this.gridColumn299.ColumnEdit = this.repositoryItemCheckEditUtilizationSelection;
            this.gridColumn299.FieldName = "UtlCheck";
            this.gridColumn299.Name = "gridColumn299";
            this.gridColumn299.OptionsColumn.ShowCaption = false;
            this.gridColumn299.Visible = true;
            this.gridColumn299.VisibleIndex = 0;
            this.gridColumn299.Width = 25;
            // 
            // repositoryItemCheckEditUtilizationSelection
            // 
            this.repositoryItemCheckEditUtilizationSelection.AutoHeight = false;
            this.repositoryItemCheckEditUtilizationSelection.Name = "repositoryItemCheckEditUtilizationSelection";
            // 
            // colItemCode
            // 
            this.colItemCode.Caption = "Item Code";
            this.colItemCode.Name = "colItemCode";
            this.colItemCode.OptionsColumn.AllowEdit = false;
            this.colItemCode.OptionsFilter.AllowFilter = false;
            this.colItemCode.Visible = true;
            this.colItemCode.VisibleIndex = 0;
            this.colItemCode.Width = 117;
            // 
            // colItemDescription
            // 
            this.colItemDescription.Caption = "Item Description";
            this.colItemDescription.Name = "colItemDescription";
            this.colItemDescription.OptionsColumn.AllowEdit = false;
            this.colItemDescription.OptionsFilter.AllowFilter = false;
            this.colItemDescription.Visible = true;
            this.colItemDescription.VisibleIndex = 1;
            this.colItemDescription.Width = 180;
            // 
            // colItemPrice
            // 
            this.colItemPrice.Caption = "Item Price";
            this.colItemPrice.Name = "colItemPrice";
            this.colItemPrice.OptionsColumn.AllowEdit = false;
            this.colItemPrice.OptionsFilter.AllowFilter = false;
            this.colItemPrice.Visible = true;
            this.colItemPrice.VisibleIndex = 2;
            this.colItemPrice.Width = 133;
            // 
            // colBrand
            // 
            this.colBrand.Caption = "Brand";
            this.colBrand.FieldName = "BrandDesc";
            this.colBrand.Name = "colBrand";
            this.colBrand.OptionsColumn.AllowEdit = false;
            this.colBrand.OptionsColumn.ShowInCustomizationForm = false;
            this.colBrand.OptionsFilter.AllowFilter = false;
            this.colBrand.Width = 74;
            // 
            // colStyle
            // 
            this.colStyle.Caption = "Style";
            this.colStyle.FieldName = "StyleDesc";
            this.colStyle.Name = "colStyle";
            this.colStyle.OptionsColumn.AllowEdit = false;
            this.colStyle.OptionsColumn.ShowInCustomizationForm = false;
            this.colStyle.OptionsFilter.AllowFilter = false;
            this.colStyle.Width = 74;
            // 
            // colSize
            // 
            this.colSize.Caption = "Size";
            this.colSize.FieldName = "SizeDesc";
            this.colSize.Name = "colSize";
            this.colSize.OptionsColumn.AllowEdit = false;
            this.colSize.OptionsColumn.ShowInCustomizationForm = false;
            this.colSize.OptionsFilter.AllowFilter = false;
            this.colSize.Width = 74;
            // 
            // colColor
            // 
            this.colColor.Caption = "Color";
            this.colColor.FieldName = "ColorDesc";
            this.colColor.Name = "colColor";
            this.colColor.OptionsColumn.AllowEdit = false;
            this.colColor.OptionsColumn.ShowInCustomizationForm = false;
            this.colColor.OptionsFilter.AllowFilter = false;
            this.colColor.Width = 74;
            // 
            // colStockQty
            // 
            this.colStockQty.Caption = "Stock Qty";
            this.colStockQty.FieldName = "nQty";
            this.colStockQty.Name = "colStockQty";
            this.colStockQty.Visible = true;
            this.colStockQty.VisibleIndex = 3;
            // 
            // pnlCtrlBankInfo
            // 
            this.pnlCtrlBankInfo.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlCtrlBankInfo.Controls.Add(this.lblAmount);
            this.pnlCtrlBankInfo.Controls.Add(this.txtCreditCardNo);
            this.pnlCtrlBankInfo.Controls.Add(this.dtProrateFrom);
            this.pnlCtrlBankInfo.Controls.Add(this.lblTotalAmt);
            this.pnlCtrlBankInfo.Controls.Add(this.txtCardHolder);
            this.pnlCtrlBankInfo.Controls.Add(this.label5);
            this.pnlCtrlBankInfo.Controls.Add(this.label4);
            this.pnlCtrlBankInfo.Controls.Add(this.label3);
            this.pnlCtrlBankInfo.Controls.Add(this.label2);
            this.pnlCtrlBankInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCtrlBankInfo.Location = new System.Drawing.Point(0, 205);
            this.pnlCtrlBankInfo.Name = "pnlCtrlBankInfo";
            this.pnlCtrlBankInfo.Size = new System.Drawing.Size(840, 150);
            this.pnlCtrlBankInfo.TabIndex = 3;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(156, 115);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(22, 23);
            this.lblAmount.TabIndex = 48;
            this.lblAmount.Text = "$";
            // 
            // txtCreditCardNo
            // 
            this.txtCreditCardNo.AllowDrop = true;
            this.txtCreditCardNo.EditValue = "";
            this.txtCreditCardNo.Location = new System.Drawing.Point(105, 59);
            this.txtCreditCardNo.Name = "txtCreditCardNo";
            this.txtCreditCardNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreditCardNo.Properties.Appearance.Options.UseFont = true;
            this.txtCreditCardNo.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtCreditCardNo.Properties.MaxLength = 19;
            this.txtCreditCardNo.Size = new System.Drawing.Size(168, 22);
            this.txtCreditCardNo.TabIndex = 45;
            // 
            // dtProrateFrom
            // 
            this.dtProrateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtProrateFrom.Location = new System.Drawing.Point(105, 85);
            this.dtProrateFrom.Name = "dtProrateFrom";
            this.dtProrateFrom.Size = new System.Drawing.Size(128, 20);
            this.dtProrateFrom.TabIndex = 46;
            // 
            // lblTotalAmt
            // 
            this.lblTotalAmt.AutoSize = true;
            this.lblTotalAmt.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmt.Location = new System.Drawing.Point(3, 115);
            this.lblTotalAmt.Name = "lblTotalAmt";
            this.lblTotalAmt.Size = new System.Drawing.Size(147, 23);
            this.lblTotalAmt.TabIndex = 47;
            this.lblTotalAmt.Text = "Total Amount:";
            // 
            // txtCardHolder
            // 
            this.txtCardHolder.EditValue = "";
            this.txtCardHolder.Location = new System.Drawing.Point(105, 30);
            this.txtCardHolder.Name = "txtCardHolder";
            this.txtCardHolder.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtCardHolder.Properties.Appearance.Options.UseFont = true;
            this.txtCardHolder.Size = new System.Drawing.Size(328, 23);
            this.txtCardHolder.TabIndex = 44;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(4, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(192, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "Giro Information";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(4, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Date :";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(4, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Bank Acct No :";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(4, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "EDDA Ref :";
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.simpleButtonCancel);
            this.panelControl2.Controls.Add(this.simpleButtonOK);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 427);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(840, 40);
            this.panelControl2.TabIndex = 3;
            this.panelControl2.Paint += new System.Windows.Forms.PaintEventHandler(this.panelControl2_Paint);
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.simpleButtonCancel.Location = new System.Drawing.Point(750, 10);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonCancel.TabIndex = 10;
            this.simpleButtonCancel.Text = "Cancel";
            // 
            // simpleButtonOK
            // 
            this.simpleButtonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.simpleButtonOK.Location = new System.Drawing.Point(664, 10);
            this.simpleButtonOK.Name = "simpleButtonOK";
            this.simpleButtonOK.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonOK.TabIndex = 9;
            this.simpleButtonOK.Text = "OK";
            this.simpleButtonOK.Click += new System.EventHandler(this.simpleButtonOK_Click);
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.label1);
            this.panelControl3.Controls.Add(this.simpleButton2);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(0, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(840, 36);
            this.panelControl3.TabIndex = 4;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(554, 4);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 23);
            this.simpleButton2.TabIndex = 3;
            this.simpleButton2.Text = "Book Session";
            this.simpleButton2.Visible = false;
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // pnlCtrlSearchProduct
            // 
            this.pnlCtrlSearchProduct.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlCtrlSearchProduct.Controls.Add(this.simpleButton1);
            this.pnlCtrlSearchProduct.Controls.Add(this.label6);
            this.pnlCtrlSearchProduct.Controls.Add(this.txtEditSearchWord);
            this.pnlCtrlSearchProduct.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCtrlSearchProduct.Location = new System.Drawing.Point(0, 36);
            this.pnlCtrlSearchProduct.Name = "pnlCtrlSearchProduct";
            this.pnlCtrlSearchProduct.Size = new System.Drawing.Size(840, 36);
            this.pnlCtrlSearchProduct.TabIndex = 5;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(316, 6);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "Search";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(16, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "Search Product:";
            // 
            // txtEditSearchWord
            // 
            this.txtEditSearchWord.EditValue = "";
            this.txtEditSearchWord.Location = new System.Drawing.Point(130, 6);
            this.txtEditSearchWord.Name = "txtEditSearchWord";
            this.txtEditSearchWord.Properties.MaxLength = 25;
            this.txtEditSearchWord.Size = new System.Drawing.Size(180, 20);
            this.txtEditSearchWord.TabIndex = 0;
            this.txtEditSearchWord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEditSearchWord_KeyDown);
            // 
            // FormAddCreditPackage
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.simpleButtonCancel;
            this.ClientSize = new System.Drawing.Size(840, 467);
            this.Controls.Add(this.pnlCtrlCenter);
            this.Controls.Add(this.pnlCtrlSearchProduct);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddCreditPackage";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Credit Package";
            this.Load += new System.EventHandler(this.FormAddCreditPackage_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormAddCreditPackage_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pnlCtrlCenter)).EndInit();
            this.pnlCtrlCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditUtilizationSelection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCtrlBankInfo)).EndInit();
            this.pnlCtrlBankInfo.ResumeLayout(false);
            this.pnlCtrlBankInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreditCardNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCardHolder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlCtrlSearchProduct)).EndInit();
            this.pnlCtrlSearchProduct.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtEditSearchWord.Properties)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void simpleButtonOK_Click(object sender, System.EventArgs e)
		{
			DataRow r = gridView1.GetDataRow(gridView1.FocusedRowHandle);
  
			if (r != null)
			{                
                ACMSDAL.TblMemberPackage sqlCalcAnyOS1 = new ACMSDAL.TblMemberPackage();
                decimal dOutAmount = sqlCalcAnyOS1.OutstandingAmount(myPOS.StrMembershipID);

                if (myPOS.ReceiptMasterTable.Rows[0]["nCategoryID"].ToString() == "9")
                {
                    if (myPOS.ReceiptItemsTable.Select("strCode='" + r["strPackageGroupCode"].ToString() + "'").Length > 0)
                    {
                        MessageBox.Show(this, r["strPackageGroupCode"].ToString() + " already selected!", "Warning");
                        return;
                    }
                }                

                if (dOutAmount > 0)
                {
                    DialogResult result1 = MessageBox.Show(this, myPOS.ReceiptMasterTable.Rows[0]["strMemberName"] + " has Outstanding amount of " + (string.Format("{0:C}", dOutAmount)) + "\nDo you want to continue?", "Warning",
                        MessageBoxButtons.YesNo);

                    if (result1 == DialogResult.No)
                        return;
                }

                if (myCategoryID == 4)
                { 
                    //2106                    
                    TblMember sqlMember = new TblMember();
                    if (sqlMember.MembershipThisMonthBirtdayForUtilised(myPOS.StrMembershipID))
                    {
     
                        DialogResult result1 = MessageBox.Show("Member is having birthday this months and having 50% discount. Do you want to utilies?", "Warning",
                            MessageBoxButtons.YesNo);

                        if (result1 == DialogResult.Yes)
                        {

                            myPOS.NewBillDiscount("120046SSD");
                            myPOS.NewReceiptEntry(r["strPackageCode"].ToString(),
                           -1, r["strDescription"].ToString(),
                        1, (ACMS.Convert.ToDecimal(r["mListPrice"])), "");


                        }
                        else
                        {
                            myPOS.NewReceiptEntry(r["strPackageCode"].ToString(),
                            -1, r["strDescription"].ToString(),
                            1, ACMS.Convert.ToDecimal(r["mListPrice"]), "");

                        }
                    }
                    else
                    {
                        myPOS.NewReceiptEntry(r["strPackageCode"].ToString(),
                        -1, r["strDescription"].ToString(),
                        1, ACMS.Convert.ToDecimal(r["mListPrice"]), "");

                    }

                }
                // END TEST

				if (myCategoryID == 1 || myCategoryID == 3 ||// myCategoryID == 4 || 
					myCategoryID == 6 || myCategoryID == 14 ||
					myCategoryID == 23)
				{
					myPOS.NewReceiptEntry(r["strPackageCode"].ToString(),
						-1, r["strDescription"].ToString(),
						1, ACMS.Convert.ToDecimal(r["mListPrice"]), "");
				}
                else if (myCategoryID == 5)
                {
                    myPOS.NewReceiptEntry(r["strPackageCode"].ToString(), -1, r["strDescription"].ToString(), 1, ACMS.Convert.ToDecimal(r["mListPrice"]), "");                    
                    DataTable myTblspapacakge = myPOSHelper.SearchOnePackageCode(r["strPackageCode"].ToString());
                    
                    if (myTblspapacakge.Rows[0]["strFreePkgCode"].ToString() != string.Empty)
                    {                     
                       // ACMSLogic.POSEntries myEntry = new ACMSLogic.POSEntries(r);
                        myPOS.EditItemFreebieAndDiscount(myTblspapacakge.Rows[0]["strFreePkgCode"].ToString());
                    }
                    
                }
                else if (myCategoryID == 2)
                {


                    decimal mBasePrice = 0M;
                    decimal mProRateTotal = 0M;
                    string strTypeCard = string.Empty;
                    string strCode = string.Empty;
                    string strDesc = string.Empty;
                    string strCardHolder = txtCardHolder.Text.Trim();
                    string strCreditCardNo = txtCreditCardNo.Text.Trim();
                    string strRefNo = string.Empty;
                    DateTime dtFrom = dtProrateFrom.Value;

                    mBasePrice = ACMS.Convert.ToDecimal(r["mListPrice"]);
                    mProRateTotal = (2 * mBasePrice);
                    strCode = r["strPackageCode"].ToString();
                    strDesc = r["strDescription"].ToString();
                    lblAmount.Text = "$" + mProRateTotal.ToString();
                    myPOS.dtPackageStart = dtFrom;
                 if (dtProrateFrom.Value.Day != 1 && dtProrateFrom.Value.Day != 16)
                  {
                  MessageBox.Show(" Please select the date either 1st or 16th of the month ");
                  this.DialogResult = DialogResult.None;
                  return;
                  }

                 {
                   myPOS.NewReceiptEntry(strCode, -1, strDesc, 1, mProRateTotal, strRefNo, strCardHolder, strTypeCard, strCreditCardNo);
                 }
        

                }
                else if (myCategoryID == 7 || myCategoryID == 36 || myCategoryID == 37)
                {
                    myPOS.NewReceiptEntry(r["strCreditPackageCode"].ToString(),
                        -1, r["strDescription"].ToString(),
                        1, ACMS.Convert.ToDecimal(r["mListPrice"]), "");
                }
                else if (myCategoryID == 38)
                {
                    myPOS.NewReceiptEntry(r["strSN"].ToString(),
                        -1, r["strDescription"].ToString(),
                        1, ACMS.Convert.ToDecimal(r["mValue"]), "");
                }
                else if (myCategoryID == 8 || myCategoryID == 9)
                {
                    myPOS.NewReceiptEntry(r["strPackageGroupCode"].ToString(),
                        -1, r["strDescription"].ToString(),
                        1, ACMS.Convert.ToDecimal(r["mListPrice"]), "");
                }
                else if (myCategoryID == 11 || myCategoryID == 12)
                {                    
                    myPOS.NewReceiptEntry(r["strProductCode"].ToString(),
                        -1, r["strDescription"].ToString(),
                        1, ACMS.Convert.ToDecimal(r["mBaseUnitPrice"]), "");
                }
			}
		}

		private void gridView1_DoubleClick(object sender, System.EventArgs e)
		{
			simpleButtonOK.PerformClick();
		}

		private void simpleButton1_Click(object sender, System.EventArgs e)
		{
			myDataTable = myPOSHelper.SearchProductCode(txtEditSearchWord.Text);
			gridControl1.DataSource = myDataTable;
		}

		private void txtEditSearchWord_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == System.Windows.Forms.Keys.Enter)
			{
				simpleButton1.PerformClick();
				e.Handled =true;
			}
		}

		private void FormAddCreditPackage_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == System.Windows.Forms.Keys.Enter) 
			{
				if (txtEditSearchWord.ContainsFocus)
				{
					simpleButton1.PerformClick();
					e.Handled = true;
				}
				else
				{
					simpleButtonOK.PerformClick();
					e.Handled = true;
					this.Close();
				}
			}
		}

		private void simpleButton2_Click(object sender, System.EventArgs e)
		{
			Attendance Attend = new Attendance();
				Attend.Show();
		}

        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void FormAddCreditPackage_Load(object sender, EventArgs e)
        {

        }
	}
}
