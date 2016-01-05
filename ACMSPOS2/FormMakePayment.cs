using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ACMS.ACMSPOS2
{
	/// <summary>
	/// Summary description for FormMakePayment.
	/// </summary>
	public class FormMakePayment : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.Label label5;
		internal System.Windows.Forms.Label label2;
		internal System.Windows.Forms.Label label1;
		internal System.Windows.Forms.Label label3;
		private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
		private DevExpress.XtraEditors.SimpleButton simpleButtonOK;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private ACMSLogic.POS myPOS;
		private ACMS.XtraUtils.LookupEditBuilder.PaymentGroupCodeLookupEditBuilder myPaymentGroupCodeLookupBuilder;
		internal DevExpress.XtraEditors.LookUpEdit lkpEdtPayment;
		private DevExpress.XtraEditors.TextEdit txtEdtPaymentAmt;
		private DevExpress.XtraEditors.TextEdit txtEdtRefNo;
		internal DevExpress.XtraEditors.LookUpEdit lkpEdtPaymentGroup;
		private ACMS.XtraUtils.LookupEditBuilder.PaymentCodeLookupEditBuilder myPaymentCodeLookupBuilder;
		internal System.Windows.Forms.Label label4;
		internal DevExpress.XtraEditors.LookUpEdit lkpEdtIPP;
		private string myPaymentGroupCode;
		private ACMS.XtraUtils.LookupEditBuilder.IPPLookupEditBuilder myIPPLookupEditBuilder;

		public FormMakePayment(ACMSLogic.POS pos, string paymentGroupCode)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			myPOS = pos;
			myPaymentGroupCodeLookupBuilder = new ACMS.XtraUtils.LookupEditBuilder.PaymentGroupCodeLookupEditBuilder(lkpEdtPaymentGroup.Properties);
			myPaymentCodeLookupBuilder = new ACMS.XtraUtils.LookupEditBuilder.PaymentCodeLookupEditBuilder(lkpEdtPayment.Properties, paymentGroupCode);
			myPaymentGroupCode = paymentGroupCode;

			if (myPaymentGroupCode == PaymentGroupCode.IPP)
			{
				lkpEdtPayment.Enabled = false;
				myIPPLookupEditBuilder = new ACMS.XtraUtils.LookupEditBuilder.IPPLookupEditBuilder(lkpEdtIPP.Properties, 
					myPOS.StrBranchCode, myPOS.StrMembershipID);

				DataTable ippLookupEditTable = myIPPLookupEditBuilder.GetDataTable();

				DataRow[] ippRowInPayment = pos.ReceiptPaymentTable.Select("nIPPID is Not Null", "", DataViewRowState.CurrentRows);

				if (ippRowInPayment.Length > 0)
				{
					foreach (DataRow r in ippRowInPayment)
					{
						DataRow[] rowsToRemove = ippLookupEditTable.Select("nIPPID = " + r["nIPPID"].ToString());
						
						foreach (DataRow removeRow in rowsToRemove)
						{
							removeRow.Delete();
						}
					}
				}
				//ippLookupEditTable.Select("nIPPID = "
			}
			else if (myPaymentGroupCode == PaymentGroupCode.CASH ||
				myPaymentGroupCode == PaymentGroupCode.NETS)
			{
				label5.Visible = false;
				txtEdtRefNo.Visible = false;
//				decimal remainder = myPOS.MTotalAmount % ACMS.Convert.ToDecimal(0.05);
//				myPOS.MTotalAmount = myPOS.MTotalAmount - remainder;
//				txtEdtPaymentAmt.EditValue = myPOS.MTotalAmount.ToString();
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
			this.label5 = new System.Windows.Forms.Label();
			this.lkpEdtPayment = new DevExpress.XtraEditors.LookUpEdit();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtEdtPaymentAmt = new DevExpress.XtraEditors.TextEdit();
			this.txtEdtRefNo = new DevExpress.XtraEditors.TextEdit();
			this.lkpEdtPaymentGroup = new DevExpress.XtraEditors.LookUpEdit();
			this.label3 = new System.Windows.Forms.Label();
			this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
			this.label4 = new System.Windows.Forms.Label();
			this.lkpEdtIPP = new DevExpress.XtraEditors.LookUpEdit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtPayment.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtEdtPaymentAmt.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtEdtRefNo.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtPaymentGroup.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtIPP.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label5.Location = new System.Drawing.Point(10, 90);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(124, 23);
			this.label5.TabIndex = 38;
			this.label5.Text = "Reference Code :";
			// 
			// lkpEdtPayment
			// 
			this.lkpEdtPayment.EditValue = "";
			this.lkpEdtPayment.Location = new System.Drawing.Point(136, 38);
			this.lkpEdtPayment.Name = "lkpEdtPayment";
			// 
			// lkpEdtPayment.Properties
			// 
			this.lkpEdtPayment.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
			this.lkpEdtPayment.Properties.Appearance.Options.UseFont = true;
			this.lkpEdtPayment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkpEdtPayment.Size = new System.Drawing.Size(218, 23);
			this.lkpEdtPayment.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.Location = new System.Drawing.Point(10, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(124, 23);
			this.label2.TabIndex = 34;
			this.label2.Text = "Payment Amount :";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(10, 38);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(124, 23);
			this.label1.TabIndex = 4;
			this.label1.Text = "Payment Mode :";
			// 
			// txtEdtPaymentAmt
			// 
			this.txtEdtPaymentAmt.EditValue = "";
			this.txtEdtPaymentAmt.Location = new System.Drawing.Point(136, 64);
			this.txtEdtPaymentAmt.Name = "txtEdtPaymentAmt";
			// 
			// txtEdtPaymentAmt.Properties
			// 
			this.txtEdtPaymentAmt.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
			this.txtEdtPaymentAmt.Properties.Appearance.Options.UseFont = true;
			this.txtEdtPaymentAmt.Properties.DisplayFormat.FormatString = "c2";
			this.txtEdtPaymentAmt.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.txtEdtPaymentAmt.Properties.EditFormat.FormatString = "c2";
			this.txtEdtPaymentAmt.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.txtEdtPaymentAmt.Properties.Mask.EditMask = "c2";
			this.txtEdtPaymentAmt.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.txtEdtPaymentAmt.Properties.Mask.UseMaskAsDisplayFormat = true;
			this.txtEdtPaymentAmt.Properties.MaxLength = 50;
			this.txtEdtPaymentAmt.Size = new System.Drawing.Size(218, 23);
			this.txtEdtPaymentAmt.TabIndex = 0;
			// 
			// txtEdtRefNo
			// 
			this.txtEdtRefNo.EditValue = "";
			this.txtEdtRefNo.Location = new System.Drawing.Point(136, 90);
			this.txtEdtRefNo.Name = "txtEdtRefNo";
			// 
			// txtEdtRefNo.Properties
			// 
			this.txtEdtRefNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
			this.txtEdtRefNo.Properties.Appearance.Options.UseFont = true;
			this.txtEdtRefNo.Properties.MaxLength = 50;
			this.txtEdtRefNo.Size = new System.Drawing.Size(218, 23);
			this.txtEdtRefNo.TabIndex = 1;
			// 
			// lkpEdtPaymentGroup
			// 
			this.lkpEdtPaymentGroup.EditValue = "";
			this.lkpEdtPaymentGroup.Enabled = false;
			this.lkpEdtPaymentGroup.Location = new System.Drawing.Point(136, -16);
			this.lkpEdtPaymentGroup.Name = "lkpEdtPaymentGroup";
			// 
			// lkpEdtPaymentGroup.Properties
			// 
			this.lkpEdtPaymentGroup.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
			this.lkpEdtPaymentGroup.Properties.Appearance.Options.UseFont = true;
			this.lkpEdtPaymentGroup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkpEdtPaymentGroup.Size = new System.Drawing.Size(218, 23);
			this.lkpEdtPaymentGroup.TabIndex = 3;
			this.lkpEdtPaymentGroup.Visible = false;
			this.lkpEdtPaymentGroup.EditValueChanged += new System.EventHandler(this.lkpEdtPaymentGroup_EditValueChanged);
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label3.Location = new System.Drawing.Point(10, -16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(124, 23);
			this.label3.TabIndex = 41;
			this.label3.Text = "Payment Group :";
			this.label3.Visible = false;
			// 
			// simpleButtonCancel
			// 
			this.simpleButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.simpleButtonCancel.Location = new System.Drawing.Point(278, 122);
			this.simpleButtonCancel.Name = "simpleButtonCancel";
			this.simpleButtonCancel.TabIndex = 6;
			this.simpleButtonCancel.Text = "Cancel";
			// 
			// simpleButtonOK
			// 
			this.simpleButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.simpleButtonOK.Location = new System.Drawing.Point(192, 122);
			this.simpleButtonOK.Name = "simpleButtonOK";
			this.simpleButtonOK.TabIndex = 5;
			this.simpleButtonOK.Text = "OK";
			this.simpleButtonOK.Click += new System.EventHandler(this.simpleButtonOK_Click);
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label4.Location = new System.Drawing.Point(10, 12);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(124, 23);
			this.label4.TabIndex = 43;
			this.label4.Text = "IPP ID :";
			// 
			// lkpEdtIPP
			// 
			this.lkpEdtIPP.EditValue = "";
			this.lkpEdtIPP.Enabled = false;
			this.lkpEdtIPP.Location = new System.Drawing.Point(136, 12);
			this.lkpEdtIPP.Name = "lkpEdtIPP";
			// 
			// lkpEdtIPP.Properties
			// 
			this.lkpEdtIPP.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
			this.lkpEdtIPP.Properties.Appearance.Options.UseFont = true;
			this.lkpEdtIPP.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkpEdtIPP.Size = new System.Drawing.Size(218, 23);
			this.lkpEdtIPP.TabIndex = 4;
			this.lkpEdtIPP.EditValueChanged += new System.EventHandler(this.lkpEdtIPP_EditValueChanged);
			// 
			// FormMakePayment
			// 
			this.AcceptButton = this.simpleButtonOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.simpleButtonCancel;
			this.ClientSize = new System.Drawing.Size(368, 154);
			this.Controls.Add(this.lkpEdtIPP);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.simpleButtonCancel);
			this.Controls.Add(this.simpleButtonOK);
			this.Controls.Add(this.lkpEdtPaymentGroup);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtEdtRefNo);
			this.Controls.Add(this.txtEdtPaymentAmt);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.lkpEdtPayment);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormMakePayment";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Make Payment";
			this.Load += new System.EventHandler(this.FormMakePayment_Load);
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtPayment.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtEdtPaymentAmt.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtEdtRefNo.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtPaymentGroup.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtIPP.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void simpleButtonOK_Click(object sender, System.EventArgs e)
		{
			decimal paymentAmt = 0;

			if (lkpEdtPayment.EditValue.ToString() == "")
			{
				MessageBox.Show(this, "Please select the payment mode.");
				this.DialogResult = DialogResult.None;
				return;
			}
			else if (txtEdtPaymentAmt.Text.Length == 0)
			{
				MessageBox.Show(this, "Please enter payment amount.");
				this.DialogResult = DialogResult.None;
				return;
			}
			else if (lkpEdtPaymentGroup.EditValue.ToString() == ACMSPOS2.PaymentGroupCode.IPP &&
				lkpEdtIPP.EditValue.ToString().Trim() == "")
			{
				MessageBox.Show(this, "Please select an IPP ID.");
				this.DialogResult = DialogResult.None;
				return;
			}
			else if (lkpEdtPaymentGroup.EditValue.ToString() == ACMSPOS2.PaymentGroupCode.IPP && 
				txtEdtRefNo.Text.Trim()== "")
			{
				MessageBox.Show(this, "Please Enter Reference No.");
				this.DialogResult = DialogResult.None;
				return;
			}
			else if ((lkpEdtPaymentGroup.EditValue.ToString() == ACMSPOS2.PaymentGroupCode.CHEQUE || 
				lkpEdtPaymentGroup.EditValue.ToString()== ACMSPOS2.PaymentGroupCode.VOUCHER ) &&
				txtEdtRefNo.Text == "")
			{
				MessageBox.Show(this, "Please enter reference code.");
				this.DialogResult = DialogResult.None;
				return;
			}
			else if (txtEdtPaymentAmt.Text.Length > 0)
			{
				try
				{
					paymentAmt = ACMS.Convert.ToDecimal(txtEdtPaymentAmt.EditValue);
				}
				catch (Exception)
				{
					MessageBox.Show(this, "Invalid payment amount.");
					this.DialogResult = DialogResult.None;
					return;	
				}
			}
			
			int ipp = 0;
			if (lkpEdtIPP.EditValue.ToString().Length > 0)
				ipp = ACMS.Convert.ToInt32(lkpEdtIPP.EditValue);
	
			myPOS.NewReceiptPayment(lkpEdtPayment.EditValue.ToString(), paymentAmt, ipp, txtEdtRefNo.Text);

		}

		private void lkpEdtPaymentGroup_EditValueChanged(object sender, System.EventArgs e)
		{
			if (lkpEdtPayment.EditValue != null &&
				myPaymentCodeLookupBuilder != null && 
				lkpEdtPaymentGroup.EditValue != null &&
				myPaymentGroupCodeLookupBuilder != null && 
				lkpEdtPaymentGroup.EditValue.ToString() != "")
			{
				myPaymentCodeLookupBuilder.Refresh(lkpEdtPaymentGroup.EditValue.ToString());	
				if (((DataTable)lkpEdtPayment.Properties.DataSource).Rows.Count == 1)
				{
					lkpEdtPayment.ItemIndex = 0;
					lkpEdtPayment.Properties.ForceInitialize();
				}

				lkpEdtIPP.Visible = lkpEdtPaymentGroup.EditValue.ToString() == ACMSPOS2.PaymentGroupCode.IPP;
				lkpEdtIPP.Enabled = lkpEdtIPP.Visible;
				label4.Visible = lkpEdtIPP.Visible;	
				myPaymentGroupCode = lkpEdtPaymentGroup.Text;
			}

			if (myIPPLookupEditBuilder != null && lkpEdtIPP.Text.Length > 0)
			{
				string cmdText = "Select A.strIPP From tblBank A Inner Join tblIPP B on A.strBankCode = B.strBankCode " + 
					" Where B.nIPPID = @nIPPID ";
			
				int ippID = ACMS.Convert.ToInt32(lkpEdtIPP.Text);
				ACMSDAL.TblIPP sqlIPP = new ACMSDAL.TblIPP();
				DataTable table = sqlIPP.LoadData(cmdText, new string[]{"@nIPPID"}, new object[]{ippID});
				if (table.Rows.Count > 0)
				{
					lkpEdtPayment.EditValue = table.Rows[0]["strIPP"];
				}
			}
		}

		private void FormMakePayment_Load(object sender, System.EventArgs e)
		{
			lkpEdtPaymentGroup.EditValue = myPaymentGroupCode;
			
			if (lkpEdtPayment.Text == "")
				lkpEdtPayment.ItemIndex = 0;

			
			decimal outStandingAmt = myPOS.MOutstandingAmount;
			decimal remainder;
			if(lkpEdtPayment.Text=="CASH")
			{
				remainder = myPOS.MTotalAmount % ACMS.Convert.ToDecimal(0.05);
				myPOS.MTotalAmount = myPOS.MTotalAmount - remainder;
				txtEdtPaymentAmt.EditValue = myPOS.MTotalAmount.ToString();
			}
			else
				txtEdtPaymentAmt.EditValue = outStandingAmt;

			txtEdtPaymentAmt.SelectAll();

		}

		private void lkpEdtIPP_EditValueChanged(object sender, System.EventArgs e)
		{
			if (myIPPLookupEditBuilder != null && lkpEdtIPP.Text.Length > 0)
			{
				string cmdText = "Select A.strIPP From tblBank A Inner Join tblIPP B on A.strBankCode = B.strBankCode " + 
								" Where B.nIPPID = @nIPPID ";
			
				int ippID = ACMS.Convert.ToInt32(lkpEdtIPP.EditValue);
				ACMSDAL.TblIPP sqlIPP = new ACMSDAL.TblIPP();
				DataTable table = sqlIPP.LoadData(cmdText, new string[]{"@nIPPID"}, new object[]{ippID});
				if (table.Rows.Count > 0)
				{
					lkpEdtPayment.EditValue = table.Rows[0]["strIPP"];
				}
			}
		}	
	}
}
