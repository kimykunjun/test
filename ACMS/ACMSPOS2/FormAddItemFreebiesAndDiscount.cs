using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading;

namespace ACMS.ACMSPOS2
{
	/// <summary>
	/// Summary description for FormAddItemFreebiesAndDiscount.
	/// </summary>
	public class FormAddItemFreebiesAndDiscount : System.Windows.Forms.Form
	{
        private string connectionString;
        private SqlConnection connection;
		private DevExpress.XtraEditors.PanelControl panelControl1;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Label Label41;
		private DevExpress.XtraEditors.PanelControl panelControl2;
		private DevExpress.XtraEditors.PanelControl panelControl3;
		private DevExpress.XtraEditors.PanelControl panelControl4;
		private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
		private DevExpress.XtraGrid.GridControl gridControl1;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraGrid.GridControl gridControl2;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
		private DevExpress.XtraEditors.SimpleButton simpleButtonOK;
		
		private ACMS.XtraUtils.LookupEditBuilder.ItemFreebiePromotionCodeLookupEditBuilder myItemFreebiePromotionCodeLookupBuilder;
		private ACMS.XtraUtils.LookupEditBuilder.ItemDiscountPromotionCodeLookupEditBuilder myItemDiscountPromotionCodeLookupBuilder;
		private DevExpress.XtraEditors.LookUpEdit lkpEdtItemFreebiePromotionCode;
		private ACMSLogic.POS myPOS;
		private string myStrProduct_Or_Package_Code;
		private int myCategoryTypeID;
		private DevExpress.XtraEditors.TextEdit txtEdtUnitPrice;
		private DevExpress.XtraEditors.TextEdit txtEdtDescription;
		private DevExpress.XtraEditors.TextEdit txtEdtItemCode;
		private DataRow myDataRow;
		private DevExpress.XtraEditors.CalcEdit calcEdtQty;
		private DevExpress.XtraEditors.LookUpEdit lkpEdtDiscount;
		private ACMSLogic.POSEntries myPOSEntry;
		internal System.Windows.Forms.Label label6;
		private DevExpress.XtraEditors.TextEdit txtEdtRefNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private bool myIsFinishLoadStockRecon = false;
        private fmProgress m_fmProgress = null;
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;


		public FormAddItemFreebiesAndDiscount(ACMSLogic.POS pos, DataRow row, 
			int nCategoryTypeID,bool bLoadStockRecon)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"];
            connection = new SqlConnection(connectionString);


            if (!myIsFinishLoadStockRecon)
            {
                myIsFinishLoadStockRecon = bLoadStockRecon;
            }
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			myDataRow = row;
			myPOS = pos;
			myCategoryTypeID = nCategoryTypeID;
			myStrProduct_Or_Package_Code = myDataRow["strCode"].ToString();
			myPOSEntry = new ACMSLogic.POSEntries(myDataRow);

			Init();
			myItemFreebiePromotionCodeLookupBuilder = 
				new ACMS.XtraUtils.LookupEditBuilder.ItemFreebiePromotionCodeLookupEditBuilder(lkpEdtItemFreebiePromotionCode.Properties, 
				myPOS.StrMembershipID, myPOS.MNettAmount, myCategoryTypeID, myPOS.NCategoryID,
                myStrProduct_Or_Package_Code, myPOS.StrBranchCode, myPOS.IsStaffPurchase, myPOS.StrReceiptNo);

			myItemDiscountPromotionCodeLookupBuilder = 
				new ACMS.XtraUtils.LookupEditBuilder.ItemDiscountPromotionCodeLookupEditBuilder(lkpEdtDiscount.Properties,
				myPOS.StrMembershipID, myPOS.MNettAmount, myCategoryTypeID, myPOS.NCategoryID,
                myStrProduct_Or_Package_Code, myPOS.StrBranchCode, myPOS.IsStaffPurchase);
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

		private void Init()
		{
			txtEdtItemCode.Text = myDataRow["strCode"].ToString();
			txtEdtDescription.Text = myDataRow["strDescription"].ToString();
			txtEdtUnitPrice.Text = myDataRow["mUnitPrice"].ToString();
			calcEdtQty.Value = ACMS.Convert.ToDecimal(myDataRow["nQuantity"]);
			txtEdtRefNo.Text = myDataRow["strReferenceNo"].ToString();
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtEdtRefNo = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.calcEdtQty = new DevExpress.XtraEditors.CalcEdit();
            this.lkpEdtItemFreebiePromotionCode = new DevExpress.XtraEditors.LookUpEdit();
            this.lkpEdtDiscount = new DevExpress.XtraEditors.LookUpEdit();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtEdtUnitPrice = new DevExpress.XtraEditors.TextEdit();
            this.txtEdtDescription = new DevExpress.XtraEditors.TextEdit();
            this.txtEdtItemCode = new DevExpress.XtraEditors.TextEdit();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label41 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdtRefNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcEdtQty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpEdtItemFreebiePromotionCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpEdtDiscount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdtUnitPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdtItemCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.txtEdtRefNo);
            this.panelControl1.Controls.Add(this.label6);
            this.panelControl1.Controls.Add(this.calcEdtQty);
            this.panelControl1.Controls.Add(this.lkpEdtItemFreebiePromotionCode);
            this.panelControl1.Controls.Add(this.lkpEdtDiscount);
            this.panelControl1.Controls.Add(this.Label5);
            this.panelControl1.Controls.Add(this.Label4);
            this.panelControl1.Controls.Add(this.txtEdtUnitPrice);
            this.panelControl1.Controls.Add(this.txtEdtDescription);
            this.panelControl1.Controls.Add(this.txtEdtItemCode);
            this.panelControl1.Controls.Add(this.Label3);
            this.panelControl1.Controls.Add(this.Label2);
            this.panelControl1.Controls.Add(this.Label1);
            this.panelControl1.Controls.Add(this.Label41);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(552, 216);
            this.panelControl1.TabIndex = 28;
            // 
            // txtEdtRefNo
            // 
            this.txtEdtRefNo.EditValue = "";
            this.txtEdtRefNo.Location = new System.Drawing.Point(136, 188);
            this.txtEdtRefNo.Name = "txtEdtRefNo";
            this.txtEdtRefNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtEdtRefNo.Properties.Appearance.Options.UseFont = true;
            this.txtEdtRefNo.Properties.MaxLength = 49;
            this.txtEdtRefNo.Size = new System.Drawing.Size(250, 23);
            this.txtEdtRefNo.TabIndex = 38;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 26);
            this.label6.TabIndex = 39;
            this.label6.Text = "Ref No";
            // 
            // calcEdtQty
            // 
            this.calcEdtQty.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.calcEdtQty.Location = new System.Drawing.Point(136, 66);
            this.calcEdtQty.Name = "calcEdtQty";
            this.calcEdtQty.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.calcEdtQty.Properties.Appearance.Options.UseFont = true;
            this.calcEdtQty.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.calcEdtQty.Size = new System.Drawing.Size(250, 23);
            this.calcEdtQty.TabIndex = 2;
            this.calcEdtQty.EditValueChanged += new System.EventHandler(this.calcEdtQty_EditValueChanged);
            // 
            // lkpEdtItemFreebiePromotionCode
            // 
            this.lkpEdtItemFreebiePromotionCode.EditValue = "";
            this.lkpEdtItemFreebiePromotionCode.Location = new System.Drawing.Point(136, 156);
            this.lkpEdtItemFreebiePromotionCode.Name = "lkpEdtItemFreebiePromotionCode";
            this.lkpEdtItemFreebiePromotionCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lkpEdtItemFreebiePromotionCode.Properties.Appearance.Options.UseFont = true;
            this.lkpEdtItemFreebiePromotionCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpEdtItemFreebiePromotionCode.Size = new System.Drawing.Size(250, 23);
            this.lkpEdtItemFreebiePromotionCode.TabIndex = 5;
            this.lkpEdtItemFreebiePromotionCode.EditValueChanged += new System.EventHandler(this.lkpEdtItemFreebiePromotionCode_EditValueChanged);
            // 
            // lkpEdtDiscount
            // 
            this.lkpEdtDiscount.EditValue = "";
            this.lkpEdtDiscount.Location = new System.Drawing.Point(136, 126);
            this.lkpEdtDiscount.Name = "lkpEdtDiscount";
            this.lkpEdtDiscount.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lkpEdtDiscount.Properties.Appearance.Options.UseFont = true;
            this.lkpEdtDiscount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpEdtDiscount.Size = new System.Drawing.Size(250, 23);
            this.lkpEdtDiscount.TabIndex = 4;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(10, 156);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(80, 23);
            this.Label5.TabIndex = 37;
            this.Label5.Text = "Freebie";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(10, 126);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(94, 23);
            this.Label4.TabIndex = 36;
            this.Label4.Text = "Discount";
            // 
            // txtEdtUnitPrice
            // 
            this.txtEdtUnitPrice.EditValue = "";
            this.txtEdtUnitPrice.Enabled = false;
            this.txtEdtUnitPrice.Location = new System.Drawing.Point(136, 96);
            this.txtEdtUnitPrice.Name = "txtEdtUnitPrice";
            this.txtEdtUnitPrice.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtEdtUnitPrice.Properties.Appearance.Options.UseFont = true;
            this.txtEdtUnitPrice.Size = new System.Drawing.Size(250, 23);
            this.txtEdtUnitPrice.TabIndex = 3;
            // 
            // txtEdtDescription
            // 
            this.txtEdtDescription.EditValue = "";
            this.txtEdtDescription.Enabled = false;
            this.txtEdtDescription.Location = new System.Drawing.Point(136, 36);
            this.txtEdtDescription.Name = "txtEdtDescription";
            this.txtEdtDescription.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtEdtDescription.Properties.Appearance.Options.UseFont = true;
            this.txtEdtDescription.Properties.MaxLength = 250;
            this.txtEdtDescription.Size = new System.Drawing.Size(250, 23);
            this.txtEdtDescription.TabIndex = 1;
            // 
            // txtEdtItemCode
            // 
            this.txtEdtItemCode.EditValue = "";
            this.txtEdtItemCode.Enabled = false;
            this.txtEdtItemCode.Location = new System.Drawing.Point(136, 6);
            this.txtEdtItemCode.Name = "txtEdtItemCode";
            this.txtEdtItemCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtEdtItemCode.Properties.Appearance.Options.UseFont = true;
            this.txtEdtItemCode.Size = new System.Drawing.Size(250, 23);
            this.txtEdtItemCode.TabIndex = 0;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(10, 96);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(103, 23);
            this.Label3.TabIndex = 31;
            this.Label3.Text = "Unit Price";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(10, 66);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(93, 23);
            this.Label2.TabIndex = 30;
            this.Label2.Text = "Quantity";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(10, 36);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(119, 23);
            this.Label1.TabIndex = 29;
            this.Label1.Text = "Description";
            // 
            // Label41
            // 
            this.Label41.AutoSize = true;
            this.Label41.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label41.Location = new System.Drawing.Point(10, 6);
            this.Label41.Name = "Label41";
            this.Label41.Size = new System.Drawing.Size(110, 23);
            this.Label41.TabIndex = 28;
            this.Label41.Text = "Item Code";
            // 
            // panelControl2
            // 
            this.panelControl2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.panelControl4);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 216);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(552, 204);
            this.panelControl2.TabIndex = 29;
            // 
            // panelControl4
            // 
            this.panelControl4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.panelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl4.Controls.Add(this.xtraTabControl1);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl4.Location = new System.Drawing.Point(0, 0);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(552, 204);
            this.panelControl4.TabIndex = 6;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(552, 204);
            this.xtraTabControl1.TabIndex = 3;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            this.xtraTabControl1.Text = "xtraTabControl1";
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.gridControl1);
            this.xtraTabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(543, 173);
            this.xtraTabPage1.Text = "Freebie-Package";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Name = "";
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit2,
            this.repositoryItemTextEdit2});
            this.gridControl1.Size = new System.Drawing.Size(543, 173);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn6,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn8});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.LostFocus += new System.EventHandler(this.gridView1_LostFocus);
            // 
            // gridColumn6
            // 
            this.gridColumn6.ColumnEdit = this.repositoryItemCheckEdit2;
            this.gridColumn6.FieldName = "Checked";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            this.gridColumn6.Width = 36;
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            this.repositoryItemCheckEdit2.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Package Code";
            this.gridColumn1.FieldName = "strPackageCode";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 126;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Package Description";
            this.gridColumn2.FieldName = "strDescription";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 260;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Quantity";
            this.gridColumn8.ColumnEdit = this.repositoryItemTextEdit2;
            this.gridColumn8.FieldName = "nQuantity";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsFilter.AllowFilter = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 3;
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.gridControl2);
            this.xtraTabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(543, 173);
            this.xtraTabPage2.Text = "Freebie-Product";
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.EmbeddedNavigator.Name = "";
            this.gridControl2.Location = new System.Drawing.Point(0, 0);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemTextEdit1});
            this.gridControl2.Size = new System.Drawing.Size(543, 173);
            this.gridControl2.TabIndex = 1;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn7});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.LostFocus += new System.EventHandler(this.gridView2_LostFocus);
            // 
            // gridColumn5
            // 
            this.gridColumn5.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gridColumn5.FieldName = "Checked";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            this.gridColumn5.Width = 36;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Product Code";
            this.gridColumn3.FieldName = "strProductCode";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 115;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Product Description";
            this.gridColumn4.FieldName = "strDescription";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 271;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Quantity";
            this.gridColumn7.ColumnEdit = this.repositoryItemTextEdit1;
            this.gridColumn7.FieldName = "nQuantity";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsFilter.AllowFilter = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 3;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // panelControl3
            // 
            this.panelControl3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.simpleButtonCancel);
            this.panelControl3.Controls.Add(this.simpleButtonOK);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(0, 420);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(552, 32);
            this.panelControl3.TabIndex = 30;
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.simpleButtonCancel.Location = new System.Drawing.Point(468, 5);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonCancel.TabIndex = 1;
            this.simpleButtonCancel.Text = "Cancel";
            // 
            // simpleButtonOK
            // 
            this.simpleButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.simpleButtonOK.Location = new System.Drawing.Point(384, 5);
            this.simpleButtonOK.Name = "simpleButtonOK";
            this.simpleButtonOK.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonOK.TabIndex = 0;
            this.simpleButtonOK.Text = "OK";
            this.simpleButtonOK.Click += new System.EventHandler(this.simpleButtonOK_Click);
            // 
            // FormAddItemFreebiesAndDiscount
            // 
            this.AcceptButton = this.simpleButtonOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.simpleButtonCancel;
            this.ClientSize = new System.Drawing.Size(552, 452);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddItemFreebiesAndDiscount";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Item";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdtRefNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcEdtQty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpEdtItemFreebiePromotionCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpEdtDiscount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdtUnitPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdtItemCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void lkpEdtItemFreebiePromotionCode_EditValueChanged(object sender, System.EventArgs e)
		{
			if (lkpEdtItemFreebiePromotionCode.EditValue != null &&
				lkpEdtItemFreebiePromotionCode.Text != "")
			{
				string strPromotionCode = lkpEdtItemFreebiePromotionCode.EditValue.ToString();

				int nPromotionTypeID = (int)lkpEdtItemFreebiePromotionCode.GetColumnValue("nPromotionTypeID");
				
				
				{
					
					ACMSDAL.TblProduct product = new ACMSDAL.TblProduct();
					DataTable table = product.GetPromotionProductBaseOnPromotionCode(strPromotionCode, myPOS.StrBranchCode);

					if (table != null)
					{
						DataColumn colChecked = new DataColumn("Checked", typeof(bool));
						table.Columns.Add(colChecked);

                        DataColumn colQty = new DataColumn("nQuantity", typeof(int));
                        table.Columns.Add(colQty);

						foreach (DataRow r in table.Rows)
						{
							r["Checked"] = false;
                            r["nQuantity"] = 1;
						}
					}
					gridControl2.DataSource = table;
				
					
					ACMSLogic.PackageCode package = new ACMSLogic.PackageCode();
					DataTable table2 = package.GetPromotionPackageBasePromotionCode(strPromotionCode);
					
					if (table2 != null)
					{
						DataColumn colChecked = new DataColumn("Checked", typeof(bool));
						table2.Columns.Add(colChecked);

                        DataColumn colQty = new DataColumn("nQuantity", typeof(int));
                        table2.Columns.Add(colQty);

						foreach (DataRow r in table2.Rows)
						{
							r["Checked"] = false;
                            r["nQuantity"] = 1;
						}
					}

					gridControl1.DataSource = table2;
				}
			}
		}

		
		
		
		
		
		
		
		private void simpleButtonOK_Click(object sender, System.EventArgs e)
		{
            ValidatePackageQty();
            
			myDataRow["strReferenceNo"] = txtEdtRefNo.Text;

			int nPromotionTypeID = -1;

			if (lkpEdtItemFreebiePromotionCode.EditValue != null && lkpEdtItemFreebiePromotionCode.Text.Length > 0)
				nPromotionTypeID = (int)lkpEdtItemFreebiePromotionCode.GetColumnValue("nPromotionTypeID");
				
			if (nPromotionTypeID == -1 && lkpEdtDiscount.EditValue != null && lkpEdtDiscount.Text.Length > 0)
			{
				myPOS.EditItemFreebieAndDiscount(myDataRow, null, "", lkpEdtDiscount.Text, true);
			}
			//else
             if (nPromotionTypeID == 1)
			{
				// free Product
				ACMS.XtraUtils.GridViewUtils.UpdateData(gridView2);
				if (gridControl2.DataSource != null)
				{
					DataRow[]  rowList = ((DataTable)gridControl2.DataSource).Select("Checked = true");

                    if (rowList.Length == 0)
                    {
                        MessageBox.Show(this, "Please select a product.");
                        this.DialogResult = DialogResult.None;
                        return;
                    }
                    else
                    {

                        if (!myIsFinishLoadStockRecon)
                        {
                            connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"];
                            connection = new SqlConnection(connectionString);

                            // StartProgressBar

                            BackgroundWorker bw = new BackgroundWorker();
                            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
                            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);

                            m_fmProgress = new fmProgress();
                            bw.RunWorkerAsync();
                            m_fmProgress.ShowDialog(this);
                            m_fmProgress = null;

                            //StartProgressBar 
                            myIsFinishLoadStockRecon = true;
                        }

                        myPOS.EditItemFreebieAndDiscount(myDataRow, rowList, lkpEdtItemFreebiePromotionCode.Text, lkpEdtDiscount.Text, false);
                    }
				}
			}
            ValidateFreebieQty();

			{
				ACMS.XtraUtils.GridViewUtils.UpdateData(gridView1);

				if (gridControl1.DataSource != null)
				{
					DataRow[] rowList = ((DataTable)gridControl1.DataSource).Select("Checked = true");

                    myPOS.EditItemFreebieAndDiscount(myDataRow, rowList, lkpEdtItemFreebiePromotionCode.Text, lkpEdtDiscount.Text, true);
                    
				}	
			}
		}



        #region Synchronous BackgroundWorker Thread


        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            // Do some long running task...
            int iCount = 100;// new Random().Next(20, 50);
            for (int i = 0; i < iCount; i++)
            {
                // The Work to be performed...
                Thread.Sleep(100);

                m_fmProgress.lblDescription.Invoke(
                    (MethodInvoker)delegate()
                    {
                        m_fmProgress.lblDescription.Text = "Please Wait! Loading Stock Balance..... " + i.ToString() + "% of " + iCount.ToString() + '%';
                        m_fmProgress.progressBar1.Value = Convert.ToInt32(i * (100.0 / iCount));
                    }
                );

                if (m_fmProgress.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

          //  SqlHelper.ExecuteNonQuery(connection, "dw_sp_SCStockRecon");

            // Hide the Progress Form
            if (m_fmProgress != null)
            {
                m_fmProgress.Hide();
                m_fmProgress = null;
            }

            // Check to see if an error occured in the 
            // background process.
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
                return;
            }

            // Check to see if the background process was cancelled.
            if (e.Cancelled)
            {
                MessageBox.Show("Processing cancelled.");
                return;
            }

            // Everything completed normally.
            // process the response using e.Result
            //   MessageBox.Show("Processing is complete.");
        }

        #endregion

		private void calcEdtQty_EditValueChanged(object sender, System.EventArgs e)
		{
			calcEdtQty.Value = decimal.Round(calcEdtQty.Value, 0);

			if (calcEdtQty.EditValue != null)
				myPOSEntry.NQuantity = ACMS.Convert.ToInt32(calcEdtQty.Value);
		}

        private void gridView1_LostFocus(object sender, EventArgs e)
        {
            ValidatePackageQty();
        }

        private void gridView2_LostFocus(object sender, EventArgs e)
        {
            ValidateFreebieQty();
        }

        private void ValidateFreebieQty()
        {
            if (lkpEdtItemFreebiePromotionCode.EditValue != null &&
                lkpEdtItemFreebiePromotionCode.Text != "")
            {
                DataRow row = this.gridView2.GetDataRow(gridView2.FocusedRowHandle);
                string strPromotionCode = lkpEdtItemFreebiePromotionCode.EditValue.ToString();
                if (row != null)
                {
                    if (row["nQuantity"] != DBNull.Value)
                    {
                        string strSQL = "SELECT ISNULL(nMaxQty,1) as nMaxQty from tblPromotionFreebie where strPromotionCode='" + strPromotionCode + "' and strItemCode='" + row["strProductCode"] + "' ";
                        DataSet _ds = new DataSet();
                        SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA", _ds, new string[] { "table" }, new SqlParameter("@strSQL", strSQL));
                        if (_ds.Tables["table"].Rows.Count > 0)
                        {
                            if (Convert.ToInt16(row["nQuantity"]) > Convert.ToInt16(_ds.Tables["table"].Rows[0]["nMaxQty"]))
                            {
                                row["nQuantity"] = 1;
                                MessageBox.Show(this, "Quantity entered greater than maximum quantity ( " + _ds.Tables["table"].Rows[0]["nMaxQty"].ToString() + " ) allowed", "Warning", MessageBoxButtons.OK);
                                return;
                            }
                        }

                        strSQL = "SELECT nQty from tblSCStockRecon where strProductCode='" + row["strProductCode"] + "' AND strBranchCode='" + myPOS.StrBranchCode + "' ";
                        _ds = new DataSet();
                        SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA", _ds, new string[] { "table" }, new SqlParameter("@strSQL", strSQL));
                        if (_ds.Tables["table"].Rows.Count > 0)
                        {
                            if (Convert.ToInt16(row["nQuantity"]) > Convert.ToInt16(_ds.Tables["table"].Rows[0]["nQty"]))
                            {                                
                                MessageBox.Show(this, "Quantity entered greater than stock quantity ( " + _ds.Tables["table"].Rows[0]["nQty"].ToString() + " )", "Warning", MessageBoxButtons.OK);
                                return;
                            }
                        }
                        _ds.Dispose();
                    }
                }
            }            
        }

        private void ValidatePackageQty()
        {
            if (lkpEdtItemFreebiePromotionCode.EditValue != null &&
                lkpEdtItemFreebiePromotionCode.Text != "")
            {
                DataRow row = this.gridView1.GetDataRow(gridView1.FocusedRowHandle);
                string strPromotionCode = lkpEdtItemFreebiePromotionCode.EditValue.ToString();

                if (row != null)
                {
                    if (row["nQuantity"] != DBNull.Value)
                    {
                        string strSQL = "SELECT ISNULL(nMaxQty,1) as nMaxQty from tblPromotionPackage where strPromotionCode='" + strPromotionCode + "' and strPackageCode='" + row["strPackageCode"] + "' ";
                        DataSet _ds = new DataSet();
                        SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA", _ds, new string[] { "table" }, new SqlParameter("@strSQL", strSQL));
                        if (_ds.Tables["table"].Rows.Count > 0)
                        {
                            if (Convert.ToInt16(row["nQuantity"]) > Convert.ToInt16(_ds.Tables["table"].Rows[0]["nMaxQty"]))
                            {
                                row["nQuantity"] = 1;
                                MessageBox.Show(this, "Quantity entered greater than maximum quantity ( " + _ds.Tables["table"].Rows[0]["nMaxQty"].ToString() + " ) allowed", "Warning", MessageBoxButtons.OK);
                                return;
                            }
                        }
                        _ds.Dispose();
                    }
                }
            }            
        }
	}
}
