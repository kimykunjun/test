using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ACMSDAL;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;


namespace ACMS.ACMSPOS2
{
	/// <summary>
	/// Summary description for frmIPP_Add.
	/// </summary>
	public class frmIPP_Add : System.Windows.Forms.Form
	{
		private ACMSLogic.POS myPOS;
		private ACMS.XtraUtils.LookupEditBuilder.BankCodeLookupEditBuilder myBankCodeLookupEditBuilder;
		private ACMS.XtraUtils.LookupEditBuilder.MonthOfInstallmentLookupEditBuilder myMonthOfInstallmentLookupEditBuilder;
		private ACMS.XtraUtils.LookupEditBuilder.BankIPPMerchantLookupEditBuilder myBankIPPMerchantLookupEditBuilder;


		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private DevExpress.XtraEditors.GroupControl groupHdrIPP;
		private System.Windows.Forms.Label hdrIPP;
		private DevExpress.XtraEditors.GroupControl grpControlIPP;
		internal DevExpress.XtraEditors.SimpleButton btnSave;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
		private DevExpress.XtraEditors.SimpleButton btnIPPCancel;
		private System.Windows.Forms.Label label3;
		internal DevExpress.XtraEditors.TextEdit txtCreditCard;
		private System.Windows.Forms.Label CreditCard;
		private DevExpress.XtraEditors.LookUpEdit lkpEdtMonthOfInstallment;
		private DevExpress.XtraEditors.LookUpEdit lkpEdtBankCode;
		private DevExpress.XtraEditors.LookUpEdit lkpEdtMerchantNo;
		
		public frmIPP_Add(ACMSLogic.POS pos)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			myPOS = pos;

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

			InitLookupEdit();
		}

		private void InitLookupEdit()
		{
			myBankCodeLookupEditBuilder = new 
				ACMS.XtraUtils.LookupEditBuilder.BankCodeLookupEditBuilder(lkpEdtBankCode.Properties);
			
			myMonthOfInstallmentLookupEditBuilder = new ACMS.XtraUtils.LookupEditBuilder.MonthOfInstallmentLookupEditBuilder(lkpEdtMonthOfInstallment.Properties, 
				"");
			myBankIPPMerchantLookupEditBuilder = new ACMS.XtraUtils.LookupEditBuilder.BankIPPMerchantLookupEditBuilder(lkpEdtMerchantNo.Properties, 
				"", "", 0);

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
			this.groupHdrIPP = new DevExpress.XtraEditors.GroupControl();
			this.hdrIPP = new System.Windows.Forms.Label();
			this.grpControlIPP = new DevExpress.XtraEditors.GroupControl();
			this.lkpEdtMerchantNo = new DevExpress.XtraEditors.LookUpEdit();
			this.label3 = new System.Windows.Forms.Label();
			this.txtCreditCard = new DevExpress.XtraEditors.TextEdit();
			this.CreditCard = new System.Windows.Forms.Label();
			this.lkpEdtMonthOfInstallment = new DevExpress.XtraEditors.LookUpEdit();
			this.lkpEdtBankCode = new DevExpress.XtraEditors.LookUpEdit();
			this.btnIPPCancel = new DevExpress.XtraEditors.SimpleButton();
			this.btnSave = new DevExpress.XtraEditors.SimpleButton();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.groupHdrIPP)).BeginInit();
			this.groupHdrIPP.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grpControlIPP)).BeginInit();
			this.grpControlIPP.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtMerchantNo.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCreditCard.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtMonthOfInstallment.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtBankCode.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// groupHdrIPP
			// 
			this.groupHdrIPP.Appearance.BackColor = System.Drawing.Color.LightGray;
			this.groupHdrIPP.Appearance.Options.UseBackColor = true;
			this.groupHdrIPP.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.groupHdrIPP.Controls.Add(this.hdrIPP);
			this.groupHdrIPP.Location = new System.Drawing.Point(0, -1);
			this.groupHdrIPP.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.groupHdrIPP.LookAndFeel.UseDefaultLookAndFeel = false;
			this.groupHdrIPP.Name = "groupHdrIPP";
			this.groupHdrIPP.Size = new System.Drawing.Size(472, 32);
			this.groupHdrIPP.TabIndex = 26;
			this.groupHdrIPP.Text = "groupControl1";
			// 
			// hdrIPP
			// 
			this.hdrIPP.BackColor = System.Drawing.Color.Silver;
			this.hdrIPP.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.hdrIPP.Location = new System.Drawing.Point(0, 8);
			this.hdrIPP.Name = "hdrIPP";
			this.hdrIPP.Size = new System.Drawing.Size(464, 23);
			this.hdrIPP.TabIndex = 1;
			this.hdrIPP.Text = "IPP DETAILS FORM";
			this.hdrIPP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// grpControlIPP
			// 
			this.grpControlIPP.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.grpControlIPP.Controls.Add(this.lkpEdtMerchantNo);
			this.grpControlIPP.Controls.Add(this.label3);
			this.grpControlIPP.Controls.Add(this.txtCreditCard);
			this.grpControlIPP.Controls.Add(this.CreditCard);
			this.grpControlIPP.Controls.Add(this.lkpEdtMonthOfInstallment);
			this.grpControlIPP.Controls.Add(this.lkpEdtBankCode);
			this.grpControlIPP.Controls.Add(this.btnIPPCancel);
			this.grpControlIPP.Controls.Add(this.btnSave);
			this.grpControlIPP.Controls.Add(this.label4);
			this.grpControlIPP.Controls.Add(this.label2);
			this.grpControlIPP.Location = new System.Drawing.Point(0, 32);
			this.grpControlIPP.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.grpControlIPP.LookAndFeel.UseDefaultLookAndFeel = false;
			this.grpControlIPP.Name = "grpControlIPP";
			this.grpControlIPP.ShowCaption = false;
			this.grpControlIPP.Size = new System.Drawing.Size(472, 216);
			this.grpControlIPP.TabIndex = 27;
			this.grpControlIPP.Text = "groupControl1";
			// 
			// lkpEdtMerchantNo
			// 
			this.lkpEdtMerchantNo.Location = new System.Drawing.Point(152, 80);
			this.lkpEdtMerchantNo.Name = "lkpEdtMerchantNo";
			// 
			// lkpEdtMerchantNo.Properties
			// 
			this.lkpEdtMerchantNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkpEdtMerchantNo.Properties.NullText = "";
			this.lkpEdtMerchantNo.Size = new System.Drawing.Size(168, 20);
			this.lkpEdtMerchantNo.TabIndex = 4;
			this.lkpEdtMerchantNo.Visible = false;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(32, 80);
			this.label3.Name = "label3";
			this.label3.TabIndex = 171;
			this.label3.Text = "Merchant No";
			this.label3.Visible = false;
			// 
			// txtCreditCard
			// 
			this.txtCreditCard.AllowDrop = true;
			this.txtCreditCard.EditValue = "";
			this.txtCreditCard.Location = new System.Drawing.Point(152, 56);
			this.txtCreditCard.Name = "txtCreditCard";
			// 
			// txtCreditCard.Properties
			// 
			this.txtCreditCard.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtCreditCard.Properties.Appearance.Options.UseFont = true;
			this.txtCreditCard.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.txtCreditCard.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.txtCreditCard.Properties.Mask.BeepOnError = true;
			this.txtCreditCard.Properties.Mask.EditMask = "\\d{4}-\\d{4}-\\d{4}-\\d{4}";
			this.txtCreditCard.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular;
			this.txtCreditCard.Properties.Mask.SaveLiteral = false;
			this.txtCreditCard.Properties.Mask.UseMaskAsDisplayFormat = true;
			this.txtCreditCard.Properties.MaxLength = 19;
			this.txtCreditCard.Size = new System.Drawing.Size(168, 20);
			this.txtCreditCard.TabIndex = 5;
			// 
			// CreditCard
			// 
			this.CreditCard.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.CreditCard.Location = new System.Drawing.Point(32, 56);
			this.CreditCard.Name = "CreditCard";
			this.CreditCard.TabIndex = 169;
			this.CreditCard.Text = "Credit Card No";
			// 
			// lkpEdtMonthOfInstallment
			// 
			this.lkpEdtMonthOfInstallment.Location = new System.Drawing.Point(152, 32);
			this.lkpEdtMonthOfInstallment.Name = "lkpEdtMonthOfInstallment";
			// 
			// lkpEdtMonthOfInstallment.Properties
			// 
			this.lkpEdtMonthOfInstallment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																															 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkpEdtMonthOfInstallment.Properties.NullText = "";
			this.lkpEdtMonthOfInstallment.Size = new System.Drawing.Size(168, 20);
			this.lkpEdtMonthOfInstallment.TabIndex = 3;
			this.lkpEdtMonthOfInstallment.EditValueChanged += new System.EventHandler(this.lkpEdtMonthOfInstallment_EditValueChanged);
			// 
			// lkpEdtBankCode
			// 
			this.lkpEdtBankCode.Location = new System.Drawing.Point(152, 8);
			this.lkpEdtBankCode.Name = "lkpEdtBankCode";
			// 
			// lkpEdtBankCode.Properties
			// 
			this.lkpEdtBankCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkpEdtBankCode.Properties.NullText = "";
			this.lkpEdtBankCode.Size = new System.Drawing.Size(168, 20);
			this.lkpEdtBankCode.TabIndex = 1;
			this.lkpEdtBankCode.EditValueChanged += new System.EventHandler(this.lkpEdtBankCode_EditValueChanged);
			// 
			// btnIPPCancel
			// 
			this.btnIPPCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnIPPCancel.Location = new System.Drawing.Point(248, 112);
			this.btnIPPCancel.Name = "btnIPPCancel";
			this.btnIPPCancel.TabIndex = 7;
			this.btnIPPCancel.Text = "Cancel";
			// 
			// btnSave
			// 
			this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSave.Location = new System.Drawing.Point(160, 112);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(80, 24);
			this.btnSave.TabIndex = 6;
			this.btnSave.Text = "OK";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.Location = new System.Drawing.Point(32, 8);
			this.label4.Name = "label4";
			this.label4.TabIndex = 28;
			this.label4.Text = "Bank Code";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(32, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(120, 16);
			this.label2.TabIndex = 27;
			this.label2.Text = "Number of Months";
			// 
			// frmIPP_Add
			// 
			this.AcceptButton = this.btnSave;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnIPPCancel;
			this.ClientSize = new System.Drawing.Size(352, 182);
			this.Controls.Add(this.grpControlIPP);
			this.Controls.Add(this.groupHdrIPP);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmIPP_Add";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Add IPP";
			this.Load += new System.EventHandler(this.frmIPP_Add_Load);
			((System.ComponentModel.ISupportInitialize)(this.groupHdrIPP)).EndInit();
			this.groupHdrIPP.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grpControlIPP)).EndInit();
			this.grpControlIPP.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtMerchantNo.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCreditCard.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtMonthOfInstallment.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtBankCode.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void frmIPP_Add_Load(object sender, System.EventArgs e)
		{

		}

		private void lkpEdtBankCode_EditValueChanged(object sender, System.EventArgs e)
		{
			string strBankCode = lkpEdtBankCode.Text;
			string strBranchCode = myPOS.StrBranchCode;

			myMonthOfInstallmentLookupEditBuilder.Refresh(strBankCode);

			if (lkpEdtMonthOfInstallment.EditValue != null)
			{
				myBankIPPMerchantLookupEditBuilder.Refresh(strBankCode, 
					strBranchCode, ACMS.Convert.ToInt32(lkpEdtMonthOfInstallment.EditValue));

				if (myBankIPPMerchantLookupEditBuilder.MerchantNoTable.Rows.Count > 0)
					lkpEdtMerchantNo.EditValue = myBankIPPMerchantLookupEditBuilder.MerchantNoTable.Rows[0]["strMerchantNo"];
			}
		}

		private void lkpEdtMonthOfInstallment_EditValueChanged(object sender, System.EventArgs e)
		{
			string strBankCode = lkpEdtBankCode.Text;
			string strBranchCode = myPOS.StrBranchCode;

			if (lkpEdtMonthOfInstallment.EditValue != null)
			{
				myBankIPPMerchantLookupEditBuilder.Refresh(strBankCode, 
					strBranchCode, ACMS.Convert.ToInt32(lkpEdtMonthOfInstallment.EditValue));

				if (myBankIPPMerchantLookupEditBuilder.MerchantNoTable.Rows.Count > 0)
					lkpEdtMerchantNo.EditValue = myBankIPPMerchantLookupEditBuilder.MerchantNoTable.Rows[0]["strMerchantNo"];
			}
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			if (lkpEdtBankCode.Text.Length == 0)
			{
				MessageBox.Show(this, "Please Select a Bank Code.");
				this.DialogResult = DialogResult.None;
				lkpEdtBankCode.Focus();
				return;
			}
			else if (lkpEdtMerchantNo.EditValue == null || 
				lkpEdtMerchantNo.EditValue.ToString().Length == 0)
			{
				MessageBox.Show(this, "No Have Merchant No");
				this.DialogResult = DialogResult.None;
				//lkpEdtMerchantNo.Focus();
				return;
			}
			else if (lkpEdtMonthOfInstallment.Text.Length == 0)
			{
				MessageBox.Show(this, "Please Select a Months of installment.");
				this.DialogResult = DialogResult.None;
				lkpEdtMonthOfInstallment.Focus();
				return;
			}
			else if (txtCreditCard.EditValue.ToString().Length == 0)
			{
				MessageBox.Show(this, "Invalid credit card no.");
				this.DialogResult = DialogResult.None;
				txtCreditCard.Focus();
				return;
			}

			string strBankCode = lkpEdtBankCode.Text;
			string strMerchantNo = lkpEdtMerchantNo.EditValue.ToString();
			int nMonths = ACMS.Convert.ToInt32(lkpEdtMonthOfInstallment.EditValue);
			string strCreditCardNo = txtCreditCard.EditValue.ToString();

			myPOS.AddNewIPP(strBankCode, nMonths, strCreditCardNo, strMerchantNo); 		
		}
	}
}
