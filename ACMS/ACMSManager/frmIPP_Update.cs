using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using dal = ACMSDAL;
using System.Data;

namespace ACMS
{
	/// <summary>
	/// Summary description for frmIPP_Update.
	/// </summary>
	public class frmIPP_Update : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.Label label14;
		internal System.Windows.Forms.Label label15;
		internal System.Windows.Forms.Label label16;
		internal System.Windows.Forms.Label label17;
		internal System.Windows.Forms.Label label18;
		internal System.Windows.Forms.Label label19;
		internal DevExpress.XtraEditors.SimpleButton btnSave;
		internal DevExpress.XtraEditors.SimpleButton btnCancel;
		internal DevExpress.XtraEditors.TextEdit txtnMonths;
		private System.Windows.Forms.ComboBox ddlBank;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label CreditCard;
		public ACMSLogic.IPP IPPs;
		private int Id;
		internal DevExpress.XtraEditors.TextEdit CCNo;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmIPP_Update(int IPPId)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			Id = IPPId;
			IPPs = new ACMSLogic.IPP();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			this.label14 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.btnSave = new DevExpress.XtraEditors.SimpleButton();
			this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.txtnMonths = new DevExpress.XtraEditors.TextEdit();
			this.ddlBank = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.CreditCard = new System.Windows.Forms.Label();
			this.CCNo = new DevExpress.XtraEditors.TextEdit();
			((System.ComponentModel.ISupportInitialize)(this.txtnMonths.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.CCNo.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label14.Location = new System.Drawing.Point(8, 128);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(0, 18);
			this.label14.TabIndex = 58;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label15.Location = new System.Drawing.Point(8, 144);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(0, 18);
			this.label15.TabIndex = 57;
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label16.Location = new System.Drawing.Point(8, 104);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(0, 18);
			this.label16.TabIndex = 56;
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label17.Location = new System.Drawing.Point(8, 80);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(0, 18);
			this.label17.TabIndex = 55;
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label18.Location = new System.Drawing.Point(8, 56);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(0, 18);
			this.label18.TabIndex = 54;
			this.label18.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label19.Location = new System.Drawing.Point(8, 32);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(0, 18);
			this.label19.TabIndex = 53;
			// 
			// btnSave
			// 
			this.btnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnSave.Location = new System.Drawing.Point(88, 120);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(72, 18);
			this.btnSave.TabIndex = 84;
			this.btnSave.Text = "Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnCancel.Location = new System.Drawing.Point(176, 120);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(72, 18);
			this.btnCancel.TabIndex = 85;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// txtnMonths
			// 
			this.txtnMonths.EditValue = "";
			this.txtnMonths.Location = new System.Drawing.Point(168, 72);
			this.txtnMonths.Name = "txtnMonths";
			// 
			// txtnMonths.Properties
			// 
			this.txtnMonths.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtnMonths.Properties.Appearance.Options.UseFont = true;
			this.txtnMonths.Properties.MaxLength = 19;
			this.txtnMonths.Size = new System.Drawing.Size(240, 22);
			this.txtnMonths.TabIndex = 93;
			// 
			// ddlBank
			// 
			this.ddlBank.Location = new System.Drawing.Point(168, 24);
			this.ddlBank.Name = "ddlBank";
			this.ddlBank.Size = new System.Drawing.Size(240, 21);
			this.ddlBank.TabIndex = 89;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label4.Location = new System.Drawing.Point(24, 24);
			this.label4.Name = "label4";
			this.label4.TabIndex = 88;
			this.label4.Text = "Bank Code";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.Location = new System.Drawing.Point(24, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(120, 23);
			this.label2.TabIndex = 87;
			this.label2.Text = "Number of Months";
			// 
			// CreditCard
			// 
			this.CreditCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.CreditCard.Location = new System.Drawing.Point(24, 48);
			this.CreditCard.Name = "CreditCard";
			this.CreditCard.TabIndex = 86;
			this.CreditCard.Text = "Credit Card No";
			// 
			// CCNo
			// 
			this.CCNo.EditValue = "";
			this.CCNo.Location = new System.Drawing.Point(168, 48);
			this.CCNo.Name = "CCNo";
			// 
			// CCNo.Properties
			// 
			this.CCNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.CCNo.Properties.Appearance.Options.UseFont = true;
			this.CCNo.Properties.MaxLength = 19;
			this.CCNo.Size = new System.Drawing.Size(240, 22);
			this.CCNo.TabIndex = 94;
			// 
			// frmIPP_Update
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(488, 166);
			this.Controls.Add(this.CCNo);
			this.Controls.Add(this.txtnMonths);
			this.Controls.Add(this.ddlBank);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.CreditCard);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.label16);
			this.Controls.Add(this.label17);
			this.Controls.Add(this.label18);
			this.Controls.Add(this.label19);
			this.Name = "frmIPP_Update";
			this.Text = "Update IPP";
			this.Load += new System.EventHandler(this.frmIPP_Update_Load);
			((System.ComponentModel.ISupportInitialize)(this.txtnMonths.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.CCNo.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void frmIPP_Update_Load(object sender, System.EventArgs e)
		{
			dal.TblBank bnk = new dal.TblBank();
			DataTable dt = bnk.SelectAll();
			//cbReceipient
			ddlBank.DataSource = dt;
			ddlBank.ValueMember = "strBankCode";


			dal.TblIPP IP = new dal.TblIPP();
			IP.NIPPID = Id;
			dt = IP.SelectOne();
			
			ddlBank.SelectedValue = dt.Rows[0]["strBankCode"];
			CCNo.Text = dt.Rows[0]["strCreditCardNo"].ToString();
			txtnMonths.Text = dt.Rows[0]["nMonths"].ToString();
			


		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			
			IPPs.UpdateOne(Id,ddlBank.SelectedValue.ToString(),CCNo.Text.ToString(),Convert.ToInt32(txtnMonths.Text));
			MessageBox.Show("Record Has Been Saved", "Save");
			this.DialogResult = DialogResult.OK;
			this.Close();
			
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		
	}
}
