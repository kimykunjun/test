using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ACMS.ACMSPOS2
{
	/// <summary>
	/// Summary description for FormAddItemFreebiesAndDiscount.
	/// </summary>
	public class FormAddItemFreebiesAndDiscount : System.Windows.Forms.Form
	{
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
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;


		public FormAddItemFreebiesAndDiscount(ACMSLogic.POS pos, DataRow row, 
			int nCategoryTypeID)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

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
				myStrProduct_Or_Package_Code, myPOS.StrBranchCode, myPOS.IsStaffPurchase);

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
			this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
			this.gridControl2 = new DevExpress.XtraGrid.GridControl();
			this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
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
			this.xtraTabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
			this.panelControl3.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelControl1
			// 
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
			this.panelControl1.Text = "panelControl1";
			// 
			// txtEdtRefNo
			// 
			this.txtEdtRefNo.EditValue = "";
			this.txtEdtRefNo.Enabled = false;
			this.txtEdtRefNo.Location = new System.Drawing.Point(136, 188);
			this.txtEdtRefNo.Name = "txtEdtRefNo";
			// 
			// txtEdtRefNo.Properties
			// 
			this.txtEdtRefNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
			this.txtEdtRefNo.Properties.Appearance.Options.UseFont = true;
			this.txtEdtRefNo.Properties.MaxLength = 49;
			this.txtEdtRefNo.Size = new System.Drawing.Size(250, 23);
			this.txtEdtRefNo.TabIndex = 38;
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label6.Location = new System.Drawing.Point(10, 188);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(109, 26);
			this.label6.TabIndex = 39;
			this.label6.Text = "Ref No";
			// 
			// calcEdtQty
			// 
			this.calcEdtQty.EditValue = new System.Decimal(new int[] {
																		 0,
																		 0,
																		 0,
																		 0});
			this.calcEdtQty.Location = new System.Drawing.Point(136, 66);
			this.calcEdtQty.Name = "calcEdtQty";
			// 
			// calcEdtQty.Properties
			// 
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
			// 
			// lkpEdtItemFreebiePromotionCode.Properties
			// 
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
			// 
			// lkpEdtDiscount.Properties
			// 
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
			this.Label5.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Label5.Location = new System.Drawing.Point(10, 156);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(80, 26);
			this.Label5.TabIndex = 37;
			this.Label5.Text = "Freebie";
			// 
			// Label4
			// 
			this.Label4.AutoSize = true;
			this.Label4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Label4.Location = new System.Drawing.Point(10, 126);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(93, 26);
			this.Label4.TabIndex = 36;
			this.Label4.Text = "Discount";
			// 
			// txtEdtUnitPrice
			// 
			this.txtEdtUnitPrice.EditValue = "";
			this.txtEdtUnitPrice.Enabled = false;
			this.txtEdtUnitPrice.Location = new System.Drawing.Point(136, 96);
			this.txtEdtUnitPrice.Name = "txtEdtUnitPrice";
			// 
			// txtEdtUnitPrice.Properties
			// 
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
			// 
			// txtEdtDescription.Properties
			// 
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
			// 
			// txtEdtItemCode.Properties
			// 
			this.txtEdtItemCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
			this.txtEdtItemCode.Properties.Appearance.Options.UseFont = true;
			this.txtEdtItemCode.Size = new System.Drawing.Size(250, 23);
			this.txtEdtItemCode.TabIndex = 0;
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Label3.Location = new System.Drawing.Point(10, 96);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(103, 26);
			this.Label3.TabIndex = 31;
			this.Label3.Text = "Unit Price";
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Label2.Location = new System.Drawing.Point(10, 66);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(92, 26);
			this.Label2.TabIndex = 30;
			this.Label2.Text = "Quantity";
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Label1.Location = new System.Drawing.Point(10, 36);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(119, 26);
			this.Label1.TabIndex = 29;
			this.Label1.Text = "Description";
			// 
			// Label41
			// 
			this.Label41.AutoSize = true;
			this.Label41.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Label41.Location = new System.Drawing.Point(10, 6);
			this.Label41.Name = "Label41";
			this.Label41.Size = new System.Drawing.Size(110, 26);
			this.Label41.TabIndex = 28;
			this.Label41.Text = "Item Code";
			// 
			// panelControl2
			// 
			this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.panelControl2.Controls.Add(this.panelControl4);
			this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelControl2.Location = new System.Drawing.Point(0, 216);
			this.panelControl2.Name = "panelControl2";
			this.panelControl2.Size = new System.Drawing.Size(552, 204);
			this.panelControl2.TabIndex = 29;
			this.panelControl2.Text = "panelControl2";
			// 
			// panelControl4
			// 
			this.panelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.panelControl4.Controls.Add(this.xtraTabControl1);
			this.panelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelControl4.Location = new System.Drawing.Point(0, 0);
			this.panelControl4.Name = "panelControl4";
			this.panelControl4.Size = new System.Drawing.Size(552, 204);
			this.panelControl4.TabIndex = 6;
			this.panelControl4.Text = "panelControl4";
			// 
			// xtraTabControl1
			// 
			this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.xtraTabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
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
			this.xtraTabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xtraTabPage1.Name = "xtraTabPage1";
			this.xtraTabPage1.Size = new System.Drawing.Size(546, 178);
			this.xtraTabPage1.Text = "Freebie-Package";
			// 
			// gridControl1
			// 
			this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// gridControl1.EmbeddedNavigator
			// 
			this.gridControl1.EmbeddedNavigator.Name = "";
			this.gridControl1.Location = new System.Drawing.Point(0, 0);
			this.gridControl1.MainView = this.gridView1;
			this.gridControl1.Name = "gridControl1";
			this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																												  this.repositoryItemCheckEdit2});
			this.gridControl1.Size = new System.Drawing.Size(546, 178);
			this.gridControl1.TabIndex = 1;
			this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										this.gridView1});
			// 
			// gridView1
			// 
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn6,
																							 this.gridColumn1,
																							 this.gridColumn2});
			this.gridView1.GridControl = this.gridControl1;
			this.gridView1.Name = "gridView1";
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
			// xtraTabPage2
			// 
			this.xtraTabPage2.Controls.Add(this.gridControl2);
			this.xtraTabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xtraTabPage2.Name = "xtraTabPage2";
			this.xtraTabPage2.Size = new System.Drawing.Size(546, 178);
			this.xtraTabPage2.Text = "Freebie-Product";
			// 
			// gridControl2
			// 
			this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// gridControl2.EmbeddedNavigator
			// 
			this.gridControl2.EmbeddedNavigator.Name = "";
			this.gridControl2.Location = new System.Drawing.Point(0, 0);
			this.gridControl2.MainView = this.gridView2;
			this.gridControl2.Name = "gridControl2";
			this.gridControl2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																												  this.repositoryItemCheckEdit1});
			this.gridControl2.Size = new System.Drawing.Size(546, 178);
			this.gridControl2.TabIndex = 1;
			this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										this.gridView2});
			// 
			// gridView2
			// 
			this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn5,
																							 this.gridColumn3,
																							 this.gridColumn4});
			this.gridView2.GridControl = this.gridControl2;
			this.gridView2.Name = "gridView2";
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
			// panelControl3
			// 
			this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.panelControl3.Controls.Add(this.simpleButtonCancel);
			this.panelControl3.Controls.Add(this.simpleButtonOK);
			this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelControl3.Location = new System.Drawing.Point(0, 420);
			this.panelControl3.Name = "panelControl3";
			this.panelControl3.Size = new System.Drawing.Size(552, 32);
			this.panelControl3.TabIndex = 30;
			this.panelControl3.Text = "panelControl3";
			// 
			// simpleButtonCancel
			// 
			this.simpleButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.simpleButtonCancel.Location = new System.Drawing.Point(468, 5);
			this.simpleButtonCancel.Name = "simpleButtonCancel";
			this.simpleButtonCancel.TabIndex = 1;
			this.simpleButtonCancel.Text = "Cancel";
			// 
			// simpleButtonOK
			// 
			this.simpleButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.simpleButtonOK.Location = new System.Drawing.Point(384, 5);
			this.simpleButtonOK.Name = "simpleButtonOK";
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
			this.xtraTabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
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
				
				// free Product
				if (nPromotionTypeID == 1)
				{
					xtraTabPage2.PageVisible = true;
					xtraTabPage1.PageVisible = false;

					ACMSDAL.TblProduct product = new ACMSDAL.TblProduct();
					DataTable table = product.GetPromotionProductBaseOnPromotionCode(strPromotionCode, myPOS.StrBranchCode);

					if (table != null)
					{
						DataColumn colChecked = new DataColumn("Checked", typeof(bool));
						table.Columns.Add(colChecked);

						foreach (DataRow r in table.Rows)
						{
							r["Checked"] = false;
						}
					}
					gridControl2.DataSource = table;
				}
				else if (nPromotionTypeID == 2)
				{
					//Free Package
					xtraTabPage2.PageVisible = false;
					xtraTabPage1.PageVisible = true;

					ACMSLogic.PackageCode package = new ACMSLogic.PackageCode();
					DataTable table = package.GetPromotionPackageBasePromotionCode(strPromotionCode);
					
					if (table != null)
					{
						DataColumn colChecked = new DataColumn("Checked", typeof(bool));
						table.Columns.Add(colChecked);

						foreach (DataRow r in table.Rows)
						{
							r["Checked"] = false;
						}
					}

					gridControl1.DataSource = table;
				}
			}
		}

		private void simpleButtonOK_Click(object sender, System.EventArgs e)
		{
			myDataRow["strReferenceNo"] = txtEdtRefNo.Text;

			int nPromotionTypeID = -1;

			if (lkpEdtItemFreebiePromotionCode.EditValue != null && lkpEdtItemFreebiePromotionCode.Text.Length > 0)
				nPromotionTypeID = (int)lkpEdtItemFreebiePromotionCode.GetColumnValue("nPromotionTypeID");
				
			if (nPromotionTypeID == -1 && lkpEdtDiscount.EditValue != null && lkpEdtDiscount.Text.Length > 0)
			{
				myPOS.EditItemFreebieAndDiscount(myDataRow, null, "", lkpEdtDiscount.Text, true);
			}
			else if (nPromotionTypeID == 1)
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
					myPOS.EditItemFreebieAndDiscount(myDataRow, rowList, lkpEdtItemFreebiePromotionCode.Text, lkpEdtDiscount.Text, false);
				}
			}
			else
			{
				ACMS.XtraUtils.GridViewUtils.UpdateData(gridView1);

				if (gridControl1.DataSource != null)
				{
					DataRow[] rowList = ((DataTable)gridControl1.DataSource).Select("Checked = true");
						
					if (rowList.Length == 0)
					{
						MessageBox.Show(this, "Please select a package.");
						this.DialogResult = DialogResult.None;
						return;
					}
					myPOS.EditItemFreebieAndDiscount(myDataRow, rowList, lkpEdtItemFreebiePromotionCode.Text, lkpEdtDiscount.Text, true);
				}	
			}
		}

		private void calcEdtQty_EditValueChanged(object sender, System.EventArgs e)
		{
			calcEdtQty.Value = decimal.Round(calcEdtQty.Value, 0);

			if (calcEdtQty.EditValue != null)
				myPOSEntry.NQuantity = ACMS.Convert.ToInt32(calcEdtQty.Value);
		}
	}
}