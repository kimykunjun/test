using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;
using ACMSDAL;

namespace ACMS.ACMSPOS2
{
	
	/// <summary>
	/// Summary description for FormTender.
	/// </summary>
	public class FormTender : System.Windows.Forms.Form
	{
		private string connectionString;
        private SqlConnection connection;
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
			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"];
            connection = new SqlConnection(connectionString);

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

            if (myPOS.NCategoryID == 38)
            {
                btnIPP.Enabled = false;
                btnOTHERS.Enabled = false;
                btnVoucher.Enabled = false;
                btnCheque.Enabled = false;
                simpleButton2.Enabled = false;
            }
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
            this.btnOTHERS.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOTHERS.Appearance.Options.UseFont = true;
            this.btnOTHERS.Appearance.Options.UseTextOptions = true;
            this.btnOTHERS.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnOTHERS.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.btnOTHERS.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnOTHERS.Location = new System.Drawing.Point(10, 369);
            this.btnOTHERS.Name = "btnOTHERS";
            this.btnOTHERS.Size = new System.Drawing.Size(163, 46);
            this.btnOTHERS.TabIndex = 60;
            this.btnOTHERS.Text = "OTHERS";
            this.btnOTHERS.Click += new System.EventHandler(this.btnOTHERS_Click);
            // 
            // btnCheque
            // 
            this.btnCheque.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheque.Appearance.Options.UseFont = true;
            this.btnCheque.Appearance.Options.UseTextOptions = true;
            this.btnCheque.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnCheque.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.btnCheque.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnCheque.Location = new System.Drawing.Point(10, 309);
            this.btnCheque.Name = "btnCheque";
            this.btnCheque.Size = new System.Drawing.Size(163, 46);
            this.btnCheque.TabIndex = 59;
            this.btnCheque.Text = "CHEQUE";
            this.btnCheque.Click += new System.EventHandler(this.btnCheque_Click);
            // 
            // btnVoucher
            // 
            this.btnVoucher.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoucher.Appearance.Options.UseFont = true;
            this.btnVoucher.Appearance.Options.UseTextOptions = true;
            this.btnVoucher.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnVoucher.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.btnVoucher.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnVoucher.Location = new System.Drawing.Point(10, 249);
            this.btnVoucher.Name = "btnVoucher";
            this.btnVoucher.Size = new System.Drawing.Size(163, 46);
            this.btnVoucher.TabIndex = 58;
            this.btnVoucher.Text = "VOUCHER";
            this.btnVoucher.Click += new System.EventHandler(this.btnVoucher_Click);
            // 
            // btnIPP
            // 
            this.btnIPP.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIPP.Appearance.Options.UseFont = true;
            this.btnIPP.Appearance.Options.UseTextOptions = true;
            this.btnIPP.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnIPP.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.btnIPP.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnIPP.Location = new System.Drawing.Point(10, 189);
            this.btnIPP.Name = "btnIPP";
            this.btnIPP.Size = new System.Drawing.Size(163, 46);
            this.btnIPP.TabIndex = 57;
            this.btnIPP.Text = "IPP";
            this.btnIPP.Click += new System.EventHandler(this.btnIPP_Click);
            // 
            // btnVisa
            // 
            this.btnVisa.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVisa.Appearance.Options.UseFont = true;
            this.btnVisa.Appearance.Options.UseTextOptions = true;
            this.btnVisa.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnVisa.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.btnVisa.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnVisa.Location = new System.Drawing.Point(10, 129);
            this.btnVisa.Name = "btnVisa";
            this.btnVisa.Size = new System.Drawing.Size(163, 46);
            this.btnVisa.TabIndex = 56;
            this.btnVisa.Text = "VISA";
            this.btnVisa.Click += new System.EventHandler(this.btnVisa_Click);
            // 
            // btnNETS
            // 
            this.btnNETS.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNETS.Appearance.Options.UseFont = true;
            this.btnNETS.Appearance.Options.UseTextOptions = true;
            this.btnNETS.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnNETS.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.btnNETS.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnNETS.Location = new System.Drawing.Point(10, 69);
            this.btnNETS.Name = "btnNETS";
            this.btnNETS.Size = new System.Drawing.Size(163, 46);
            this.btnNETS.TabIndex = 55;
            this.btnNETS.Text = "NETS";
            this.btnNETS.Click += new System.EventHandler(this.btnNETS_Click);
            // 
            // btnCash
            // 
            this.btnCash.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCash.Appearance.Options.UseFont = true;
            this.btnCash.Appearance.Options.UseTextOptions = true;
            this.btnCash.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnCash.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.btnCash.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnCash.Location = new System.Drawing.Point(10, 9);
            this.btnCash.Name = "btnCash";
            this.btnCash.Size = new System.Drawing.Size(163, 46);
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
            this.GroupControl2.Location = new System.Drawing.Point(185, 9);
            this.GroupControl2.Name = "GroupControl2";
            this.GroupControl2.Size = new System.Drawing.Size(605, 166);
            this.GroupControl2.TabIndex = 61;
            //this.GroupControl2.Paint += new System.Windows.Forms.PaintEventHandler(this.GroupControl2_Paint);
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
            this.groupControl1.Location = new System.Drawing.Point(377, 32);
            this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(213, 104);
            this.groupControl1.TabIndex = 36;
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label10.Location = new System.Drawing.Point(26, 21);
            this.Label10.Name = "Label10";
            this.Label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Label10.Size = new System.Drawing.Size(168, 29);
            this.Label10.TabIndex = 22;
            this.Label10.Text = "PLEASE PAY";
            // 
            // lblBalance
            // 
            this.lblBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.Location = new System.Drawing.Point(17, 58);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblBalance.Size = new System.Drawing.Size(185, 39);
            this.lblBalance.TabIndex = 20;
            // 
            // lblDiscountAmt
            // 
            this.lblDiscountAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscountAmt.Location = new System.Drawing.Point(170, 53);
            this.lblDiscountAmt.Name = "lblDiscountAmt";
            this.lblDiscountAmt.Size = new System.Drawing.Size(130, 16);
            this.lblDiscountAmt.TabIndex = 35;
            this.lblDiscountAmt.Text = "0";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(86, 51);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(90, 20);
            this.label22.TabIndex = 34;
            this.label22.Text = "Discount:";
            // 
            // lblNettAmt
            // 
            this.lblNettAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNettAmt.Location = new System.Drawing.Point(170, 28);
            this.lblNettAmt.Name = "lblNettAmt";
            this.lblNettAmt.Size = new System.Drawing.Size(130, 18);
            this.lblNettAmt.TabIndex = 33;
            this.lblNettAmt.Text = "0";
            this.lblNettAmt.Click += new System.EventHandler(this.lblNettAmt_Click);
            // 
            // lblGST
            // 
            this.lblGST.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGST.Location = new System.Drawing.Point(170, 78);
            this.lblGST.Name = "lblGST";
            this.lblGST.Size = new System.Drawing.Size(130, 19);
            this.lblGST.TabIndex = 32;
            this.lblGST.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(60, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(119, 20);
            this.label11.TabIndex = 30;
            this.label11.Text = "Nett Amount:";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(120, 76);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(52, 20);
            this.label33.TabIndex = 29;
            this.label33.Text = "GST:";
            // 
            // lblTotalAmt
            // 
            this.lblTotalAmt.AutoSize = true;
            this.lblTotalAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmt.Location = new System.Drawing.Point(170, 104);
            this.lblTotalAmt.Name = "lblTotalAmt";
            this.lblTotalAmt.Size = new System.Drawing.Size(50, 54);
            this.lblTotalAmt.TabIndex = 27;
            this.lblTotalAmt.Text = "0";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label.Location = new System.Drawing.Point(14, 104);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(168, 25);
            this.label.TabIndex = 26;
            this.label.Text = "SALES TOTAL:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 24);
            this.label1.TabIndex = 25;
            // 
            // gridControl1
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
            this.gridControl1.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.gridControl1_EmbeddedNavigator_ButtonClick);
            this.gridControl1.Location = new System.Drawing.Point(187, 217);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(605, 240);
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
            this.btnPrint.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Appearance.Options.UseFont = true;
            this.btnPrint.Appearance.Options.UseTextOptions = true;
            this.btnPrint.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnPrint.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.btnPrint.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnPrint.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnPrint.Location = new System.Drawing.Point(331, 464);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(307, 46);
            this.btnPrint.TabIndex = 63;
            this.btnPrint.Text = "PRINT RECEIPT";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Location = new System.Drawing.Point(727, 180);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(63, 35);
            this.simpleButton1.TabIndex = 64;
            this.simpleButton1.Text = "Delete";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Appearance.Options.UseTextOptions = true;
            this.simpleButton2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.simpleButton2.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.simpleButton2.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.simpleButton2.Location = new System.Drawing.Point(10, 434);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(163, 46);
            this.simpleButton2.TabIndex = 65;
            this.simpleButton2.Text = "GIRO";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // FormTender
            // 
            this.AcceptButton = this.btnPrint;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(857, 542);
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
            this.GroupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
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
                if (myPOS.MOutstandingAmount == 0)
                {
                    DialogResult zeroTender = MessageBox.Show(this, string.Format("Proceed to Tender with zero amount value"), "Warning", MessageBoxButtons.YesNo);

                    if (zeroTender == DialogResult.No)
                    {
                        this.DialogResult = DialogResult.None;
                        return;
                    }
                }                                                  
			}
			# endregion
            //2903 

            bool HasCashMode = false;
            decimal remainder;
            decimal receiptAmt_temp;
            decimal paymentAmount = 0;
            decimal receiptTotalAmt = 0;
            decimal outstandingAmt = 0;
            decimal DepositAmount = 0;
            string ONOFF_State = "";

            TblPaymentPlan myPaymentPlan = new TblPaymentPlan();
            ONOFF_State = myPaymentPlan.GetInhouseIPP_ONOFF_State().ToString();
            
            if (gridView1.RowCount == 0)
            {
                MessageBox.Show(this, "Please Key In at least 1 payment code.");
                this.DialogResult = DialogResult.None;
                return;
            }

            if (myPOS.NCategoryID == 1 || myPOS.NCategoryID == 3 || myPOS.NCategoryID == 4 || myPOS.NCategoryID == 5 ||
                myPOS.NCategoryID == 6 || myPOS.NCategoryID == 7 || myPOS.NCategoryID == 8 || myPOS.NCategoryID == 9 || 
                myPOS.NCategoryID == 14 || myPOS.NCategoryID == 36 || myPOS.NCategoryID == 37)
            {
                //decimal paymentAmount = 0;
                //decimal receiptTotalAmt = 0;
                //decimal outstandingAmt = 0;
                decimal mininum1stPayment = 0;
                decimal percentageControl = Convert.ToDecimal(0.3);

                if (ONOFF_State == "1")
                {
                    percentageControl = Convert.ToDecimal(0.4);
                }

                //Get ReceiptMasterTable's Total Amount
                receiptTotalAmt = ACMS.Convert.ToDecimal(myPOS.ReceiptMasterTable.Rows[0]["mTotalAmount"]);

                //Get Outstanding Amount
                outstandingAmt = ACMS.Convert.ToDecimal(myPOS.ReceiptMasterTable.Rows[0]["mOutstandingAmount"]);

                //Get Payment Amount
                if (myPOS.ReceiptPaymentTable != null &&
                    myPOS.ReceiptPaymentTable.Rows.Count > 0)
                {
                    foreach (DataRow r in myPOS.ReceiptPaymentTable.Rows)
                    {
                        paymentAmount += ACMS.Convert.ToDecimal(r["mAmount"]);

                        if (r["strPaymentCode"].ToString() == "CASH")
                        {
                            HasCashMode = true;
                        }
                    }
                }

                //Fixing Deposit
                if (myPOS.StrDeposit != null || myPOS.StrDeposit != "")
                {
                    try
                    {
                        TblReceipt DepositReceipt = new TblReceipt();
                        DepositReceipt.StrReceiptNo = myPOS.StrDeposit;
                        DataTable tblDeposit = DepositReceipt.SelectOne();
                        DepositAmount = (decimal)(DepositReceipt.MTotalAmount.IsNull ? 0 : DepositReceipt.MTotalAmount.Value);

                        //paymentAmount += DepositAmount;
                    }
                    catch { }
                }

                if (HasCashMode)
                {                    
                    remainder = myPOS.MTotalAmount % ACMS.Convert.ToDecimal(0.05);

                    receiptAmt_temp = myPOS.MTotalAmount - remainder;

                    if (receiptAmt_temp == paymentAmount)
                    {
                        receiptTotalAmt = receiptAmt_temp;

                        outstandingAmt = 0;                        
                    }
                }

                

                //if (myPOS.StrParentReceiptNo != DBNull.Value || myPOS.StrParentReceiptNo != "") 
                //{ 
                    //Deposit

                //}
                //else
                //{
                    try
                    {
                        //Derek Instalment Plan                    
                        //If ReceiptMaster Total < 300 - full payment is required - include Joining Fees and GST
                        if ((receiptTotalAmt + DepositAmount) < 300 && ONOFF_State == "1")
                        {
                            if (receiptTotalAmt > paymentAmount)
                            {
                                MessageBox.Show("Full payment is required for bill total less than SGD 300.");
                                this.DialogResult = DialogResult.None;
                                return;
                            }
                        }

                        //1st instalment must be 40% of the total
                        mininum1stPayment = (decimal.Ceiling(percentageControl * (receiptTotalAmt + DepositAmount) * 10) / 10); //percentageControl * receiptTotalAmt;

                        if ((paymentAmount + DepositAmount) < mininum1stPayment)
                        {
                            MessageBox.Show("Need to pay at least $" + string.Format("{0:0,0.00}", mininum1stPayment) + 
                                                " (" + (Convert.ToInt32(percentageControl * 100)).ToString() + "%) of bill total (before deposit offset).\n\n" +
                                                "Please pay another $" + string.Format("{0:0,0.00}", mininum1stPayment - (paymentAmount + DepositAmount)));
                            this.DialogResult = DialogResult.None;
                            return;                
                        }

                        //Derek Instalment Plan                     
                        if (outstandingAmt > 0)
                        {
                            //Check If Total Payment Amount is round figures
                            //Else Reject
                            /*if (paymentAmount != (Convert.ToInt32(paymentAmount * 100) / 100))
                            {
                                if (decimal.Ceiling(paymentAmount) <= receiptTotalAmt)
                                {
                                    MessageBox.Show("Please pay well rounded amount of $ " + decimal.Ceiling(paymentAmount).ToString() + ", as you still have outstanding.");
                                    this.DialogResult = DialogResult.None;
                                    return;
                                }
                                else
                                {
                                    MessageBox.Show("Please full amount of $ " + receiptTotalAmt.ToString());
                                    this.DialogResult = DialogResult.None;
                                    return;
                                }
                            
                            }*/

                            if (ONOFF_State == "1")
                            {
                                string strPackageCodeList = "";
                                int mytotalInstalment = 0;

                                foreach (DataRow r in myPOS.ReceiptItemsTable.Rows)
                                {
                                    strPackageCodeList += r["strCode"].ToString() + ",";
                                }

                                //Work Out the instalment plan
                                //Params: paymentAmount, receiptTotalAmt, outstandingAmt
                                //Update myPOS.PaymentPlanTable
                                //TblPaymentPlan myPaymentPlan = new TblPaymentPlan();  //GetInhouseIPP_ONOFF_State

                                //frmMasterReceiptNo = strMasterReceiptNo;
                                //frmMasterReceiptTotal = mMasterReceiptTotal;
                                //frmPaymentAmount = mPaymentAmount;
                                //frmOutstandingAmount = mOutstandingAmount;
                                //frmPackageList = strPackageList;

                                DataTable dtIPPTotalNOptions = myPaymentPlan.GetInhouseIPPTotalNOptions("", (receiptTotalAmt + DepositAmount), paymentAmount,
                                                                                                        outstandingAmt, strPackageCodeList);

                                if (dtIPPTotalNOptions.Rows.Count > 1)
                                {

                                    FormPaymentPlan frm = new FormPaymentPlan(myPOS, "", (receiptTotalAmt + DepositAmount), paymentAmount,
                                                                                outstandingAmt, strPackageCodeList);
                                    DialogResult result = frm.ShowDialog();

                                    if (result == DialogResult.OK)
                                    {
                                        mytotalInstalment = Convert.ToInt32(frm.NTotalInstalment.ToString());
                                    }
                                    else
                                    {
                                        this.DialogResult = DialogResult.None;
                                        return;
                                    }
                                }
                                else if (dtIPPTotalNOptions.Rows.Count == 1)
                                {
                                    mytotalInstalment = Convert.ToInt32(dtIPPTotalNOptions.Rows[0]["nInstalmentNo"]);
                                }

                                myPaymentPlan.StrMasterReceiptNo = "";
                                myPaymentPlan.MMasterReceiptTotal = (receiptTotalAmt + DepositAmount);
                                myPaymentPlan.MOutstandingAmount = outstandingAmt;
                                myPaymentPlan.MPaymentAmount = paymentAmount;
                                myPaymentPlan.StrPackageList = strPackageCodeList;
                                myPaymentPlan.NEnforceTotalInstalment = mytotalInstalment;

                                myPOS.myPaymentPlanTable = myPaymentPlan.GetInhouseInstalmentPaymentPlan();
                            }
                        }

                        //Payment Tab to highlight receipt that have instalment plan - light blue
                        //Temporary suspension of the usage of the purchased package under the receipt if the due date of the "last instalment" is missed
                        //Packages under the receipt will be fully nullified (expired) if the final due dates (any instalments)

                        myPOS.MTotalAmount = receiptTotalAmt;
                        myPOS.MOutstandingAmount = outstandingAmt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error Occur: Outstanding Payment - New Inhouse Instalment Payment Plan. " + ex.Message);
                        this.DialogResult = DialogResult.None;
                        return;
                    }                    

            }
            else if (myPOS.NCategoryID == 0)
            {
                //Derek Instalment Plan
                //#Get Total Payment Here
                //#Check If Pay Outstanding Category = Yes; Cat = 0
                //#Get strCode Receipt No as 1st Reference ReceiptNo
                //#Get Master receipt and match it from tblPaymentPlan 
                //#If Receipt Found In Payment Plan Table
                //#Get the Next Instalment Amount
                //#If Next Instalment Amount = 0 then abort and return error
                //#Check If the Payment Amount >= the next instalment amount                
                //#If Yes => Update the tblPaymentPlan DataTable and save later
                //#Else Return;
                //#Else (Master Receipt Not Found In Payment Plan Table)
                //#Proceed to normal flow
                try
                {                   
                    decimal subsequentInstalmentAmt = 0;

                    string strParentReceiptNo = myPOS.ReceiptItemsTable.Rows[0]["strCode"].ToString();
                    string strMasterReceiptNo = "";

                    //Get ReceiptMasterTable's Total Amount
                    receiptTotalAmt = ACMS.Convert.ToDecimal(myPOS.ReceiptMasterTable.Rows[0]["mTotalAmount"]);

                    //Get Outstanding Amount
                    outstandingAmt = ACMS.Convert.ToDecimal(myPOS.ReceiptMasterTable.Rows[0]["mOutstandingAmount"]);

                    //Get Payment Amount
                    if (myPOS.ReceiptPaymentTable != null &&
                        myPOS.ReceiptPaymentTable.Rows.Count > 0)
                    {
                        foreach (DataRow r in myPOS.ReceiptPaymentTable.Rows)
                        {
                            paymentAmount += ACMS.Convert.ToDecimal(r["mAmount"]);

                            if (r["strPaymentCode"].ToString() == "CASH")
                            {
                                HasCashMode = true;
                            }
                        }
                    }

                    if (HasCashMode)
                    {
                        remainder = myPOS.MTotalAmount % ACMS.Convert.ToDecimal(0.05);

                        receiptAmt_temp = myPOS.MTotalAmount - remainder;

                        if (receiptAmt_temp == paymentAmount)
                        {
                            receiptTotalAmt = receiptAmt_temp;

                            outstandingAmt = 0;
                        }
                    }

                    if (myPOS.StrParentReceiptNo != DBNull.Value || myPOS.StrParentReceiptNo != "") { }
                    else
                    {
                        if (outstandingAmt > 0)
                        {
                            
                        }

                        //1st instalment must be 100% of the total
                        //TblPaymentPlan myPaymentPlan = new TblPaymentPlan();

                        if (ONOFF_State == "1")
                        {
                            //Get Master Receipt No
                            strMasterReceiptNo = myPaymentPlan.GetInhouseIPPMasterOSReceipt(strParentReceiptNo);
                            //Get Next Instalment Amount
                            subsequentInstalmentAmt = myPaymentPlan.GetInhouseIPPNextInstalmentAmount(strMasterReceiptNo);

                            if (subsequentInstalmentAmt > 0)
                            {
                                if (paymentAmount < subsequentInstalmentAmt)
                                {
                                    if (paymentAmount == receiptTotalAmt)
                                    {
                                        myPOS.myPaymentPlanTable = myPaymentPlan.GetInhouseAdjustedIPP_PayOS(strMasterReceiptNo, "", paymentAmount);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Need to pay at least 100% of the subsequent instalment amount of SGD " + subsequentInstalmentAmt);
                                        this.DialogResult = DialogResult.None;
                                        return;
                                    }
                                }
                                else
                                {
                                    //Work Out the New instalment plan
                                    //Params: paymentAmount, receiptTotalAmt, outstandingAmt
                                    //Update myPOS.PaymentPlanTable                        
                                    myPOS.myPaymentPlanTable = myPaymentPlan.GetInhouseAdjustedIPP_PayOS(strMasterReceiptNo, "", paymentAmount);

                                }
                            }
                            else
                            {
                                //Proceed to normal flow
                                //No Inhouse Instalment Payment Plan
                            }
                        }
                    }

                    myPOS.MTotalAmount = receiptTotalAmt;
                    myPOS.MOutstandingAmount = outstandingAmt;
                }
                catch
                {
                    MessageBox.Show("Error Occur: Outstanding Payment - Subsequent Inhouse IPP Payment");
                    this.DialogResult = DialogResult.None;
                    return;
                }                
            }
            else
            {
                try
                {
                    //Get ReceiptMasterTable's Total Amount
                    receiptTotalAmt = ACMS.Convert.ToDecimal(myPOS.ReceiptMasterTable.Rows[0]["mTotalAmount"]);

                    //Get Outstanding Amount
                    outstandingAmt = ACMS.Convert.ToDecimal(myPOS.ReceiptMasterTable.Rows[0]["mOutstandingAmount"]);

                    //Get Payment Amount
                    if (myPOS.ReceiptPaymentTable != null &&
                        myPOS.ReceiptPaymentTable.Rows.Count > 0)
                    {
                        foreach (DataRow r in myPOS.ReceiptPaymentTable.Rows)
                        {
                            paymentAmount += ACMS.Convert.ToDecimal(r["mAmount"]);

                            if (r["strPaymentCode"].ToString() == "CASH")
                            {
                                HasCashMode = true;
                            }
                        }
                    }

                    if (HasCashMode)
                    {
                        remainder = myPOS.MTotalAmount % ACMS.Convert.ToDecimal(0.05);

                        receiptAmt_temp = myPOS.MTotalAmount - remainder;

                        if (receiptAmt_temp == paymentAmount)
                        {
                            receiptTotalAmt = receiptAmt_temp;

                            outstandingAmt = 0;
                        }
                    }
                    myPOS.MTotalAmount = receiptTotalAmt;
                    myPOS.MOutstandingAmount = outstandingAmt;
                }
                catch 
                {
                    MessageBox.Show("Error Occur: Other Categories, No IHP");
                    this.DialogResult = DialogResult.None;
                    return;
                }

            }

            if (myPOS.MOutstandingAmount > 0) //if (outstandingAmt > 0) 
			{                                   
                
				DialogResult yes = MessageBox.Show(this, string.Format("This receipt still have outstanding amount : ${0}, do you really want to tender?", myPOS.MOutstandingAmount.ToString()), 
					"Warning", MessageBoxButtons.YesNo);

				if (yes == DialogResult.No)
				{
					this.DialogResult = DialogResult.None;
					return;
				}

                if (myPOS.NCategoryID == 11 || myPOS.NCategoryID == 12)
                {
                    MessageBox.Show(this, "Products are not allow outstanding payment anymore. Please use Deposit Function");
                    this.DialogResult = DialogResult.None;
                    return;
                } 
                else if (myPOS.NCategoryID == 18 || myPOS.NCategoryID == 19)
                {
                    MessageBox.Show(this, "Top Ups are not allow outstanding payment.");
                    this.DialogResult = DialogResult.None;
                    return;
                }
                else if (myPOS.NCategoryID == 2 || myPOS.NCategoryID == 34 || myPOS.NCategoryID == 35)
                {
                    MessageBox.Show(this, "Giros are not allow outstanding payment.");
                    this.DialogResult = DialogResult.None;
                    return;
                }
                else if (myPOS.NCategoryID == 38)
                {
                    MessageBox.Show(this, "Cash Voucher are not allow outstanding payment.");
                    this.DialogResult = DialogResult.None;
                    return;
                }
                else if (myPOS.NCategoryID == 15)
                {
                    MessageBox.Show(this, "Locker Rental are not allow outstanding payment.");
                    this.DialogResult = DialogResult.None;
                    return;
                }
                else if (myPOS.NCategoryID == 17)
                {
                    MessageBox.Show(this, "Forget Card are not allow outstanding payment.");
                    this.DialogResult = DialogResult.None;
                    return;
                }
                else if (myPOS.NCategoryID == 20)
                {
                    MessageBox.Show(this, "Lost Card are not allow outstanding payment.");
                    this.DialogResult = DialogResult.None;
                    return;
                }
                else if (myPOS.NCategoryID == 21)
                {
                    MessageBox.Show(this, "Mineral Water are not allow outstanding payment.");
                    this.DialogResult = DialogResult.None;
                    return;
                }
                else if (myPOS.NCategoryID == 23)
                {
                    MessageBox.Show(this, "Others are not allow outstanding payment.");
                    this.DialogResult = DialogResult.None;
                    return;
                }
                else if (myPOS.NCategoryID == 24)
                {
                    MessageBox.Show(this, "Deposit are not allow outstanding payment.");
                    this.DialogResult = DialogResult.None;
                    return;
                }
			}
            else if (myPOS.MOutstandingAmount < 0) //else if (outstandingAmt < 0) //
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

            #region jackie
            //  if (myPOS.MOutstandingAmount == 0)|| (!myPOS.StrFreebieCode.HasValue)

            //2704
            if (myPOS.MOutstandingAmount == 0) //if (outstandingAmt == 0) 
            {
                if (myPOS.NCategoryID == 38)
                {
                    foreach (DataRow r in myPOS.ReceiptItemsTable.Rows)
                    {
                        string strSQL = "Select * from tblCashVoucher where fsell=1 and nstatusid<>0 and strSN='"+r["strCode"]+"' ";
                        DataSet _ds = new DataSet();
                        SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA", _ds, new string[] { "table" }, new SqlParameter("@strSQL", strSQL));
                        if (_ds.Tables["table"].Rows.Count > 0)
                        {
                            MessageBox.Show(this, "Cash Voucher selected ( " +r["strCode"]+ " ) already sold.");
                            this.DialogResult = DialogResult.None;
                            return;
                        }
                    }                    
                }
                if (myPOS.NCategoryID != 35)//23 others Extent GIRO no freebiz
                {
                    if (!myPOS.StrFreebieCode.HasValue)
                    {
                        string strSQL = "Select distinct A.* from tblPromotion A, tblMember B, tblLoyaltyStatus C, tblPromotionBranch D, tblPromotionReceiptSalesCategory E, tblSalesCategory sc where A.FItemDiscount = 0 AND  A.mMinimumAmount <= " + (myPOS.MTotalAmount.ToString() == "" ? "0" : myPOS.MTotalAmount.ToString()) + " And A.nApprovedStatusID = 1 AND  ( A.nPromotionTypeID = 1 or A.nPromotionTypeID = 2) AND  A.dtValidStart <= convert(varchar(10),getdate(),120) AND A.dtValidEnd >= convert(varchar(10),getdate(),120) AND  ((A.nDiscountCategoryID = C.nDiscountCategoryID AND B.nLoyaltyStatusID = C.nLoyaltyStatusID) or A.nDiscountCategoryID =0) AND D.strPromotionCode = A.strPromotionCode and D.strBranchCode = '" + myPOS.StrBranchCode + "' AND E.strPromotionCode = A.strPromotionCode AND  B.StrMembershipID = '" + myPOS.StrMembershipID + "' AND E.nSalesCategoryID = sc.nSalesCategoryID AND sc.nSalesCategoryID = " + myPOS.NCategoryID;
                        DataSet _ds = new DataSet();
                        SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA", _ds, new string[] { "table" }, new SqlParameter("@strSQL", strSQL));
                        if (_ds.Tables["table"].Rows.Count > 0)
                        {
                            DialogResult result1 = MessageBox.Show(this, "Freebie is empty. Do you want to add it now? ", "Warning",MessageBoxButtons.YesNo);

                            if (result1 == DialogResult.Yes)
                            {
                                ACMSPOS2.FormAddBillFreebie frm = new ACMS.ACMSPOS2.FormAddBillFreebie(myPOS,true);
                                frm.ShowDialog(this);
                            }
                        }
                        _ds.Dispose();                        
                    }
                }
            }
            # endregion

            //myPOS.MTotalAmount = receiptTotalAmt;
            //myPOS.MOutstandingAmount = outstandingAmt;
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

		/*private void GroupControl2_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		
		}*/

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