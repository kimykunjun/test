using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ACMS.ACMSPOS2
{
	
	/// <summary>
	/// Summary description for FormTender.
	/// </summary>
	public class FormTender : System.Windows.Forms.Form
	{
		internal DevExpress.XtraEditors.SimpleButton btnOTHERS;
		internal DevExpress.XtraEditors.SimpleButton btnCheque;
		internal DevExpress.XtraEditors.SimpleButton btnVoucher;
		internal DevExpress.XtraEditors.SimpleButton btnIPP;
		internal DevExpress.XtraEditors.SimpleButton btnVisa;
		internal DevExpress.XtraEditors.SimpleButton btnNETS;
		internal DevExpress.XtraEditors.SimpleButton btnCash;
		internal DevExpress.XtraEditors.GroupControl GroupControl2;
		internal System.Windows.Forms.Label lblNettAmt;
		internal System.Windows.Forms.Label lblGST;
		internal System.Windows.Forms.Label lblTotalAmt;
		internal System.Windows.Forms.Label label1;
		internal System.Windows.Forms.Label lblDiscountAmt;
		private DevExpress.XtraGrid.GridControl gridControl1;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraGrid.Columns.GridColumn colPaymentCode;
		private DevExpress.XtraGrid.Columns.GridColumn colAmount;
		private DevExpress.XtraGrid.Columns.GridColumn colstrReferenceNo;
		internal DevExpress.XtraEditors.GroupControl groupControl1;
		internal System.Windows.Forms.Label lblBalance;
		internal System.Windows.Forms.Label Label10;
		internal DevExpress.XtraEditors.SimpleButton btnPrint;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		internal System.Windows.Forms.Label label22;
		internal System.Windows.Forms.Label label11;
		internal System.Windows.Forms.Label label33;
		internal System.Windows.Forms.Label label;
		private DevExpress.XtraEditors.SimpleButton simpleButton1;
		internal DevExpress.XtraEditors.SimpleButton simpleButton2;
		private ACMSLogic.POS myPOS;

		public FormTender(ACMSLogic.POS pos)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			myPOS = pos;
			Init();
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
			gridControl1.DataSource = myPOS.ReceiptPaymentTable;
			lblBalance.DataBindings.Clear();
			lblDiscountAmt.DataBindings.Clear();
			lblGST.DataBindings.Clear();
			lblNettAmt.DataBindings.Clear();
			lblTotalAmt.DataBindings.Clear();

			lblBalance.DataBindings.Add("Text", myPOS.ReceiptMasterTable, "mOutstandingAmount");
			lblDiscountAmt.DataBindings.Add("Text", myPOS.ReceiptMasterTable, "DiscountAmt");
			lblGST.DataBindings.Add("Text", myPOS.ReceiptMasterTable, "mGSTAmount");
			lblNettAmt.DataBindings.Add("Text", myPOS.ReceiptMasterTable, "mNettAmount");
			lblTotalAmt.DataBindings.Add("Text", myPOS.ReceiptMasterTable, "mTotalAmount");
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnOTHERS = new DevExpress.XtraEditors.SimpleButton();
			this.btnCheque = new DevExpress.XtraEditors.SimpleButton();
			this.btnVoucher = new DevExpress.XtraEditors.SimpleButton();
			this.btnIPP = new DevExpress.XtraEditors.SimpleButton();
			this.btnVisa = new DevExpress.XtraEditors.SimpleButton();
			this.btnNETS = new DevExpress.XtraEditors.SimpleButton();
			this.btnCash = new DevExpress.XtraEditors.SimpleButton();
			this.GroupControl2 = new DevExpress.XtraEditors.GroupControl();
			this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
			this.Label10 = new System.Windows.Forms.Label();
			this.lblBalance = new System.Windows.Forms.Label();
			this.lblDiscountAmt = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.lblNettAmt = new System.Windows.Forms.Label();
			this.lblGST = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label33 = new System.Windows.Forms.Label();
			this.lblTotalAmt = new System.Windows.Forms.Label();
			this.label = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.gridControl1 = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colPaymentCode = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colstrReferenceNo = new DevExpress.XtraGrid.Columns.GridColumn();
			this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.GroupControl2)).BeginInit();
			this.GroupControl2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
			this.groupControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// btnOTHERS
			// 
			this.btnOTHERS.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnOTHERS.Appearance.Options.UseFont = true;
			this.btnOTHERS.Appearance.Options.UseTextOptions = true;
			this.btnOTHERS.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.btnOTHERS.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
			this.btnOTHERS.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.btnOTHERS.Location = new System.Drawing.Point(8, 320);
			this.btnOTHERS.Name = "btnOTHERS";
			this.btnOTHERS.Size = new System.Drawing.Size(136, 40);
			this.btnOTHERS.TabIndex = 60;
			this.btnOTHERS.Text = "OTHERS";
			this.btnOTHERS.Click += new System.EventHandler(this.btnOTHERS_Click);
			// 
			// btnCheque
			// 
			this.btnCheque.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnCheque.Appearance.Options.UseFont = true;
			this.btnCheque.Appearance.Options.UseTextOptions = true;
			this.btnCheque.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.btnCheque.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
			this.btnCheque.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.btnCheque.Location = new System.Drawing.Point(8, 268);
			this.btnCheque.Name = "btnCheque";
			this.btnCheque.Size = new System.Drawing.Size(136, 40);
			this.btnCheque.TabIndex = 59;
			this.btnCheque.Text = "CHEQUE";
			this.btnCheque.Click += new System.EventHandler(this.btnCheque_Click);
			// 
			// btnVoucher
			// 
			this.btnVoucher.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnVoucher.Appearance.Options.UseFont = true;
			this.btnVoucher.Appearance.Options.UseTextOptions = true;
			this.btnVoucher.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.btnVoucher.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
			this.btnVoucher.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.btnVoucher.Location = new System.Drawing.Point(8, 216);
			this.btnVoucher.Name = "btnVoucher";
			this.btnVoucher.Size = new System.Drawing.Size(136, 40);
			this.btnVoucher.TabIndex = 58;
			this.btnVoucher.Text = "VOUCHER";
			this.btnVoucher.Click += new System.EventHandler(this.btnVoucher_Click);
			// 
			// btnIPP
			// 
			this.btnIPP.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnIPP.Appearance.Options.UseFont = true;
			this.btnIPP.Appearance.Options.UseTextOptions = true;
			this.btnIPP.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.btnIPP.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
			this.btnIPP.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.btnIPP.Location = new System.Drawing.Point(8, 164);
			this.btnIPP.Name = "btnIPP";
			this.btnIPP.Size = new System.Drawing.Size(136, 40);
			this.btnIPP.TabIndex = 57;
			this.btnIPP.Text = "IPP";
			this.btnIPP.Click += new System.EventHandler(this.btnIPP_Click);
			// 
			// btnVisa
			// 
			this.btnVisa.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnVisa.Appearance.Options.UseFont = true;
			this.btnVisa.Appearance.Options.UseTextOptions = true;
			this.btnVisa.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.btnVisa.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
			this.btnVisa.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.btnVisa.Location = new System.Drawing.Point(8, 112);
			this.btnVisa.Name = "btnVisa";
			this.btnVisa.Size = new System.Drawing.Size(136, 40);
			this.btnVisa.TabIndex = 56;
			this.btnVisa.Text = "VISA";
			this.btnVisa.Click += new System.EventHandler(this.btnVisa_Click);
			// 
			// btnNETS
			// 
			this.btnNETS.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnNETS.Appearance.Options.UseFont = true;
			this.btnNETS.Appearance.Options.UseTextOptions = true;
			this.btnNETS.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.btnNETS.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
			this.btnNETS.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.btnNETS.Location = new System.Drawing.Point(8, 60);
			this.btnNETS.Name = "btnNETS";
			this.btnNETS.Size = new System.Drawing.Size(136, 40);
			this.btnNETS.TabIndex = 55;
			this.btnNETS.Text = "NETS";
			this.btnNETS.Click += new System.EventHandler(this.btnNETS_Click);
			// 
			// btnCash
			// 
			this.btnCash.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnCash.Appearance.Options.UseFont = true;
			this.btnCash.Appearance.Options.UseTextOptions = true;
			this.btnCash.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.btnCash.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
			this.btnCash.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.btnCash.Location = new System.Drawing.Point(8, 8);
			this.btnCash.Name = "btnCash";
			this.btnCash.Size = new System.Drawing.Size(136, 40);
			this.btnCash.TabIndex = 54;
			this.btnCash.Text = "CASH";
			this.btnCash.Click += new System.EventHandler(this.btnCash_Click);
			// 
			// GroupControl2
			// 
			this.GroupControl2.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.GroupControl2.Appearance.BorderColor = System.Drawing.Color.Black;
			this.GroupControl2.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
			this.GroupControl2.Appearance.Options.UseBackColor = true;
			this.GroupControl2.Appearance.Options.UseBorderColor = true;
			this.GroupControl2.Appearance.Options.UseForeColor = true;
			this.GroupControl2.Controls.Add(this.groupControl1);
			this.GroupControl2.Controls.Add(this.lblDiscountAmt);
			this.GroupControl2.Controls.Add(this.label22);
			this.GroupControl2.Controls.Add(this.lblNettAmt);
			this.GroupControl2.Controls.Add(this.lblGST);
			this.GroupControl2.Controls.Add(this.label11);
			this.GroupControl2.Controls.Add(this.label33);
			this.GroupControl2.Controls.Add(this.lblTotalAmt);
			this.GroupControl2.Controls.Add(this.label);
			this.GroupControl2.Controls.Add(this.label1);
			this.GroupControl2.Location = new System.Drawing.Point(154, 8);
			this.GroupControl2.Name = "GroupControl2";
			this.GroupControl2.Size = new System.Drawing.Size(504, 144);
			this.GroupControl2.TabIndex = 61;
			this.GroupControl2.Paint += new System.Windows.Forms.PaintEventHandler(this.GroupControl2_Paint);
			// 
			// groupControl1
			// 
			this.groupControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.groupControl1.Appearance.BorderColor = System.Drawing.Color.Black;
			this.groupControl1.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
			this.groupControl1.Appearance.Options.UseBackColor = true;
			this.groupControl1.Appearance.Options.UseBorderColor = true;
			this.groupControl1.Appearance.Options.UseForeColor = true;
			this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.groupControl1.Controls.Add(this.Label10);
			this.groupControl1.Controls.Add(this.lblBalance);
			this.groupControl1.Location = new System.Drawing.Point(314, 28);
			this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
			this.groupControl1.LookAndFeel.UseWindowsXPTheme = false;
			this.groupControl1.Name = "groupControl1";
			this.groupControl1.Size = new System.Drawing.Size(178, 90);
			this.groupControl1.TabIndex = 36;
			// 
			// Label10
			// 
			this.Label10.AutoSize = true;
			this.Label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Label10.Location = new System.Drawing.Point(22, 18);
			this.Label10.Name = "Label10";
			this.Label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.Label10.Size = new System.Drawing.Size(131, 25);
			this.Label10.TabIndex = 22;
			this.Label10.Text = "PLEASE PAY";
			// 
			// lblBalance
			// 
			this.lblBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblBalance.Location = new System.Drawing.Point(14, 50);
			this.lblBalance.Name = "lblBalance";
			this.lblBalance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.lblBalance.Size = new System.Drawing.Size(154, 34);
			this.lblBalance.TabIndex = 20;
			// 
			// lblDiscountAmt
			// 
			this.lblDiscountAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblDiscountAmt.Location = new System.Drawing.Point(142, 46);
			this.lblDiscountAmt.Name = "lblDiscountAmt";
			this.lblDiscountAmt.Size = new System.Drawing.Size(108, 14);
			this.lblDiscountAmt.TabIndex = 35;
			this.lblDiscountAmt.Text = "0";
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label22.Location = new System.Drawing.Point(72, 44);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(65, 19);
			this.label22.TabIndex = 34;
			this.label22.Text = "Discount:";
			// 
			// lblNettAmt
			// 
			this.lblNettAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblNettAmt.Location = new System.Drawing.Point(142, 24);
			this.lblNettAmt.Name = "lblNettAmt";
			this.lblNettAmt.Size = new System.Drawing.Size(108, 16);
			this.lblNettAmt.TabIndex = 33;
			this.lblNettAmt.Text = "0";
			this.lblNettAmt.Click += new System.EventHandler(this.lblNettAmt_Click);
			// 
			// lblGST
			// 
			this.lblGST.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblGST.Location = new System.Drawing.Point(142, 68);
			this.lblGST.Name = "lblGST";
			this.lblGST.Size = new System.Drawing.Size(108, 16);
			this.lblGST.TabIndex = 32;
			this.lblGST.Text = "0";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label11.Location = new System.Drawing.Point(50, 22);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(88, 19);
			this.label11.TabIndex = 30;
			this.label11.Text = "Nett Amount:";
			// 
			// label33
			// 
			this.label33.AutoSize = true;
			this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label33.Location = new System.Drawing.Point(100, 66);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(38, 19);
			this.label33.TabIndex = 29;
			this.label33.Text = "GST:";
			// 
			// lblTotalAmt
			// 
			this.lblTotalAmt.AutoSize = true;
			this.lblTotalAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTotalAmt.Location = new System.Drawing.Point(142, 90);
			this.lblTotalAmt.Name = "lblTotalAmt";
			this.lblTotalAmt.Size = new System.Drawing.Size(35, 45);
			this.lblTotalAmt.TabIndex = 27;
			this.lblTotalAmt.Text = "0";
			// 
			// label
			// 
			this.label.AutoSize = true;
			this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label.Location = new System.Drawing.Point(12, 90);
			this.label.Name = "label";
			this.label.Size = new System.Drawing.Size(125, 22);
			this.label.TabIndex = 26;
			this.label.Text = "SALES TOTAL:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(8, 128);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(0, 20);
			this.label1.TabIndex = 25;
			// 
			// gridControl1
			// 
			// 
			// gridControl1.EmbeddedNavigator
			// 
			this.gridControl1.EmbeddedNavigator.Buttons.Append.Visible = false;
			this.gridControl1.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
			this.gridControl1.EmbeddedNavigator.Buttons.Edit.Visible = false;
			this.gridControl1.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
			this.gridControl1.EmbeddedNavigator.Buttons.First.Visible = false;
			this.gridControl1.EmbeddedNavigator.Buttons.Last.Visible = false;
			this.gridControl1.EmbeddedNavigator.Buttons.Next.Visible = false;
			this.gridControl1.EmbeddedNavigator.Buttons.NextPage.Visible = false;
			this.gridControl1.EmbeddedNavigator.Buttons.Prev.Visible = false;
			this.gridControl1.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
			this.gridControl1.EmbeddedNavigator.Name = "";
			this.gridControl1.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.gridControl1_EmbeddedNavigator_ButtonClick);
			this.gridControl1.Location = new System.Drawing.Point(156, 188);
			this.gridControl1.MainView = this.gridView1;
			this.gridControl1.Name = "gridControl1";
			this.gridControl1.Size = new System.Drawing.Size(504, 208);
			this.gridControl1.TabIndex = 62;
			this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										this.gridView1});
			// 
			// gridView1
			// 
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.colPaymentCode,
																							 this.colAmount,
																							 this.colstrReferenceNo});
			this.gridView1.GridControl = this.gridControl1;
			this.gridView1.Name = "gridView1";
			this.gridView1.OptionsView.ShowFooter = true;
			this.gridView1.OptionsView.ShowGroupPanel = false;
			// 
			// colPaymentCode
			// 
			this.colPaymentCode.Caption = "Payment Code";
			this.colPaymentCode.FieldName = "strPaymentCode";
			this.colPaymentCode.Name = "colPaymentCode";
			this.colPaymentCode.OptionsColumn.AllowEdit = false;
			this.colPaymentCode.Visible = true;
			this.colPaymentCode.VisibleIndex = 0;
			// 
			// colAmount
			// 
			this.colAmount.Caption = "Amount";
			this.colAmount.FieldName = "mAmount";
			this.colAmount.Name = "colAmount";
			this.colAmount.OptionsColumn.AllowEdit = false;
			this.colAmount.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
			this.colAmount.Visible = true;
			this.colAmount.VisibleIndex = 1;
			// 
			// colstrReferenceNo
			// 
			this.colstrReferenceNo.Caption = "Reference No";
			this.colstrReferenceNo.FieldName = "strReferenceNo";
			this.colstrReferenceNo.Name = "colstrReferenceNo";
			this.colstrReferenceNo.OptionsColumn.AllowEdit = false;
			this.colstrReferenceNo.Visible = true;
			this.colstrReferenceNo.VisibleIndex = 2;
			// 
			// btnPrint
			// 
			this.btnPrint.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnPrint.Appearance.Options.UseFont = true;
			this.btnPrint.Appearance.Options.UseTextOptions = true;
			this.btnPrint.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.btnPrint.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
			this.btnPrint.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.btnPrint.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnPrint.Location = new System.Drawing.Point(276, 402);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new System.Drawing.Size(256, 40);
			this.btnPrint.TabIndex = 63;
			this.btnPrint.Text = "PRINT RECEIPT";
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			// 
			// simpleButton1
			// 
			this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.simpleButton1.Appearance.Options.UseFont = true;
			this.simpleButton1.Location = new System.Drawing.Point(606, 156);
			this.simpleButton1.Name = "simpleButton1";
			this.simpleButton1.Size = new System.Drawing.Size(52, 30);
			this.simpleButton1.TabIndex = 64;
			this.simpleButton1.Text = "Delete";
			this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
			// 
			// simpleButton2
			// 
			this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.simpleButton2.Appearance.Options.UseFont = true;
			this.simpleButton2.Appearance.Options.UseTextOptions = true;
			this.simpleButton2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.simpleButton2.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
			this.simpleButton2.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.simpleButton2.Location = new System.Drawing.Point(8, 376);
			this.simpleButton2.Name = "simpleButton2";
			this.simpleButton2.Size = new System.Drawing.Size(136, 40);
			this.simpleButton2.TabIndex = 65;
			this.simpleButton2.Text = "GIRO";
			this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
			// 
			// FormTender
			// 
			this.AcceptButton = this.btnPrint;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(664, 446);
			this.Controls.Add(this.simpleButton2);
			this.Controls.Add(this.simpleButton1);
			this.Controls.Add(this.btnPrint);
			this.Controls.Add(this.gridControl1);
			this.Controls.Add(this.GroupControl2);
			this.Controls.Add(this.btnOTHERS);
			this.Controls.Add(this.btnCheque);
			this.Controls.Add(this.btnVoucher);
			this.Controls.Add(this.btnIPP);
			this.Controls.Add(this.btnVisa);
			this.Controls.Add(this.btnNETS);
			this.Controls.Add(this.btnCash);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormTender";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Tender";
			this.Load += new System.EventHandler(this.FormTender_Load);
			((System.ComponentModel.ISupportInitialize)(this.GroupControl2)).EndInit();
			this.GroupControl2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
			this.groupControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void btnCash_Click(object sender, System.EventArgs e)
		{
			MakePayment(PaymentGroupCode.CASH);
		}

		private void btnNETS_Click(object sender, System.EventArgs e)
		{
			MakePayment(PaymentGroupCode.NETS);
		}

		private void btnVisa_Click(object sender, System.EventArgs e)
		{
			MakePayment(PaymentGroupCode.VISA);
		}

		private void btnIPP_Click(object sender, System.EventArgs e)
		{
			MakePayment(PaymentGroupCode.IPP);
		}

		private void btnVoucher_Click(object sender, System.EventArgs e)
		{
			MakePayment(PaymentGroupCode.VOUCHER);
		}

		private void btnCheque_Click(object sender, System.EventArgs e)
		{
			MakePayment(PaymentGroupCode.CHEQUE);
		}

		private void btnOTHERS_Click(object sender, System.EventArgs e)
		{
			MakePayment(PaymentGroupCode.OTHERS);
		}

		
		private void MakePayment(string paymentGroupCode)
		{
			FormMakePayment frm = new FormMakePayment(myPOS, paymentGroupCode);
 			frm.ShowDialog(this);
		}

		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			#region dyiwei
			if (myPOS.MOutstandingAmount == myPOS.MTotalAmount)
			{
				DialogResult zeroTender = MessageBox.Show(this, string.Format("Proceed to Tender with zero amount value"),"Warning", MessageBoxButtons.YesNo);

				if (zeroTender == DialogResult.No)
				{
					return;
				}

			}
			# endregion
			
			if (myPOS.MOutstandingAmount > 0)
			{
				DialogResult yes = MessageBox.Show(this, string.Format("This receipt still have outstanding amount : ${0}, do you really want to tender?", myPOS.MOutstandingAmount.ToString()), 
					"Warning", MessageBoxButtons.YesNo);

				if (yes == DialogResult.No)
				{
					this.DialogResult = DialogResult.None;
					return;
				}
			}
			else if (myPOS.MOutstandingAmount < 0)
			{
				if (myPOS.NCategoryID != 15 &&
					myPOS.NCategoryID != 17)
				{
					MessageBox.Show(this, "Invalid Outstanding amount. This may be caused by amount been paid is more than outstand amount");
					this.DialogResult = DialogResult.None;
					return;
				}
			}
			else if (myPOS.ReceiptItemsTable.Rows.Count == 0)
			{
				MessageBox.Show(this, "No items in Receipt.");
				this.DialogResult = DialogResult.None;
				return;
			}
		}

		private void gridControl1_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
		{
			myPOS.RecalculateAll();
		}

		private void simpleButton1_Click(object sender, System.EventArgs e)
		{
			ACMS.XtraUtils.GridViewUtils.UpdateData(gridView1);

			DataRow r = gridView1.GetDataRow(gridView1.FocusedRowHandle);

			if (r != null)
			{
				string strPaymentCode = r["strPaymentCode"].ToString();

				r.Delete();
				
				DataRow[] rowToDelete = myPOS.PaymentTypeTable.Select("PaymentType = '"+strPaymentCode+"'", "", DataViewRowState.CurrentRows);
				
				if (rowToDelete.Length > 0)
					rowToDelete[0].Delete();
				
				myPOS.RecalculateAll();
			}
		}

		private void FormTender_Load(object sender, System.EventArgs e)
		{
		
		}

		private void lblNettAmt_Click(object sender, System.EventArgs e)
		{
		
		}

		private void GroupControl2_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		
		}

		private void simpleButton2_Click(object sender, System.EventArgs e)
		{
			MakePayment(PaymentGroupCode.IPP);
		}
	}

	public class PaymentGroupCode
	{
		public static string CASH = "CASH";
		public static string CHEQUE = "CHEQUE";
		public static string IPP = "IPP";
		public static string NETS = "NETS";
		public static string OTHERS = "OTHERS";
		public static string VISA = "VISA";
		public static string VOUCHER = "VOUCHER";
	}
}