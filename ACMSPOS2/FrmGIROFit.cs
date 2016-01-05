using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ACMS.ACMSPOS2
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class GIROpkg : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.Label Label41;
		internal System.Windows.Forms.Label label1;
		internal System.Windows.Forms.Label label2;
		internal System.Windows.Forms.Label label3;
		internal System.Windows.Forms.Label label4;
		internal System.Windows.Forms.Label label5;
		private DevExpress.XtraEditors.TextEdit txtCardHolder;
		private System.Windows.Forms.DateTimePicker dtProrateFrom;
		private System.Windows.Forms.DateTimePicker dtProrateTo;
		private System.Windows.Forms.DateTimePicker dtCardExpiry;
		private DevExpress.XtraEditors.SimpleButton btnCancel;
		private DevExpress.XtraEditors.SimpleButton btnOK;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private int myCategoryID;
		private ACMSLogic.POSHelper myPOSHelper;
		private DataTable myDataTable;
		internal System.Windows.Forms.Label lblTotal;
		internal System.Windows.Forms.Label lbl2;
		internal DevExpress.XtraEditors.TextEdit txtCreditCardNo;
		private ACMSLogic.POS myPOS;

		public GIROpkg(ACMSLogic.POS pos)
		{
			//public FormPayOutstanding(ACMSLogic.POS pos)
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			myPOS = pos;
			myDataTable = new DataTable();
			myCategoryID = myPOS.NCategoryID;
			myPOSHelper= new ACMSLogic.POSHelper(myPOS);
			
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
			this.Label41 = new System.Windows.Forms.Label();
			this.txtCardHolder = new DevExpress.XtraEditors.TextEdit();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.dtProrateFrom = new System.Windows.Forms.DateTimePicker();
			this.label3 = new System.Windows.Forms.Label();
			this.dtProrateTo = new System.Windows.Forms.DateTimePicker();
			this.label4 = new System.Windows.Forms.Label();
			this.dtCardExpiry = new System.Windows.Forms.DateTimePicker();
			this.label5 = new System.Windows.Forms.Label();
			this.lbl2 = new System.Windows.Forms.Label();
			this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.btnOK = new DevExpress.XtraEditors.SimpleButton();
			this.txtCreditCardNo = new DevExpress.XtraEditors.TextEdit();
			((System.ComponentModel.ISupportInitialize)(this.txtCardHolder.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCreditCardNo.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// Label41
			// 
			this.Label41.AutoSize = true;
			this.Label41.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Label41.Location = new System.Drawing.Point(8, 8);
			this.Label41.Name = "Label41";
			this.Label41.Size = new System.Drawing.Size(136, 26);
			this.Label41.TabIndex = 29;
			this.Label41.Text = "Card Holder :";
			// 
			// txtCardHolder
			// 
			this.txtCardHolder.EditValue = "";
			this.txtCardHolder.Location = new System.Drawing.Point(176, 8);
			this.txtCardHolder.Name = "txtCardHolder";
			// 
			// txtCardHolder.Properties
			// 
			this.txtCardHolder.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
			this.txtCardHolder.Properties.Appearance.Options.UseFont = true;
			this.txtCardHolder.Size = new System.Drawing.Size(328, 23);
			this.txtCardHolder.TabIndex = 30;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(8, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(163, 26);
			this.label1.TabIndex = 31;
			this.label1.Text = "Credit Card No :";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(10, 122);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(65, 26);
			this.label2.TabIndex = 33;
			this.label2.Text = "From:";
			// 
			// dtProrateFrom
			// 
			this.dtProrateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtProrateFrom.Location = new System.Drawing.Point(208, 128);
			this.dtProrateFrom.Name = "dtProrateFrom";
			this.dtProrateFrom.Size = new System.Drawing.Size(128, 20);
			this.dtProrateFrom.TabIndex = 34;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(10, 157);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(38, 26);
			this.label3.TabIndex = 35;
			this.label3.Text = "To:";
			// 
			// dtProrateTo
			// 
			this.dtProrateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtProrateTo.Location = new System.Drawing.Point(208, 160);
			this.dtProrateTo.Name = "dtProrateTo";
			this.dtProrateTo.Size = new System.Drawing.Size(128, 20);
			this.dtProrateTo.TabIndex = 36;
			this.dtProrateTo.ValueChanged += new System.EventHandler(this.dtProrateTo_ValueChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.Location = new System.Drawing.Point(8, 88);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(192, 26);
			this.label4.TabIndex = 37;
			this.label4.Text = "Credit Card Expiry:";
			// 
			// dtCardExpiry
			// 
			this.dtCardExpiry.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtCardExpiry.Location = new System.Drawing.Point(208, 92);
			this.dtCardExpiry.Name = "dtCardExpiry";
			this.dtCardExpiry.Size = new System.Drawing.Size(128, 20);
			this.dtCardExpiry.TabIndex = 38;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.Location = new System.Drawing.Point(9, 193);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(147, 26);
			this.label5.TabIndex = 39;
			this.label5.Text = "Total Amount:";
			// 
			// lbl2
			// 
			this.lbl2.AutoSize = true;
			this.lbl2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbl2.Location = new System.Drawing.Point(168, 192);
			this.lbl2.Name = "lbl2";
			this.lbl2.Size = new System.Drawing.Size(19, 26);
			this.lbl2.TabIndex = 40;
			this.lbl2.Text = "$";
			this.lbl2.Click += new System.EventHandler(this.lbl2_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(264, 240);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 42;
			this.btnCancel.Text = "Cancel";
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(184, 240);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 41;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// txtCreditCardNo
			// 
			this.txtCreditCardNo.AllowDrop = true;
			this.txtCreditCardNo.EditValue = "";
			this.txtCreditCardNo.Location = new System.Drawing.Point(184, 48);
			this.txtCreditCardNo.Name = "txtCreditCardNo";
			// 
			// txtCreditCardNo.Properties
			// 
			this.txtCreditCardNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtCreditCardNo.Properties.Appearance.Options.UseFont = true;
			this.txtCreditCardNo.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.txtCreditCardNo.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.txtCreditCardNo.Properties.Mask.BeepOnError = true;
			this.txtCreditCardNo.Properties.Mask.EditMask = "\\d{4}-\\d{4}-\\d{4}-\\d{4}";
			this.txtCreditCardNo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular;
			this.txtCreditCardNo.Properties.Mask.SaveLiteral = false;
			this.txtCreditCardNo.Properties.Mask.UseMaskAsDisplayFormat = true;
			this.txtCreditCardNo.Properties.MaxLength = 19;
			this.txtCreditCardNo.Size = new System.Drawing.Size(168, 20);
			this.txtCreditCardNo.TabIndex = 43;
			// 
			// GIROpkg
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(522, 272);
			this.Controls.Add(this.txtCreditCardNo);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.lbl2);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.Label41);
			this.Controls.Add(this.dtCardExpiry);
			this.Controls.Add(this.dtProrateTo);
			this.Controls.Add(this.dtProrateFrom);
			this.Controls.Add(this.txtCardHolder);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "GIROpkg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "GIRO Fitness pkg";
			this.Load += new System.EventHandler(this.GIROpkg_Load);
			((System.ComponentModel.ISupportInitialize)(this.txtCardHolder.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCreditCardNo.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void GIROpkg_Load(object sender, System.EventArgs e)
		{
		
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if (dtProrateTo.Value.Day == 15 ||dtProrateTo.Value.Day == DateTime.DaysInMonth(dtProrateTo.Value.Year,dtProrateTo.Value.Month) ||dtProrateTo.Value.Day == 1 || dtProrateTo.Value.Day == 16)
			{
				decimal mBasePrice = 118;
				TimeSpan ProRateDays = dtProrateTo.Value - dtProrateFrom.Value;
				int ProDiff = ACMS.Convert.ToInt32(Math.Round(ProRateDays.TotalDays + 1,0).ToString());
				decimal ProdateRate = ACMS.Convert.ToDecimal(ProDiff)/ACMS.Convert.ToDecimal(DateTime.DaysInMonth(dtProrateTo.Value.Year,dtProrateTo.Value.Month));
				decimal ProrateTotal;

				if (dtProrateFrom.Value.Day == 1 || dtProrateTo.Value.Day == 16)
					ProrateTotal = (2 * mBasePrice);
				else
					ProrateTotal = 2 * mBasePrice + Math.Round(mBasePrice * ProdateRate,2);

				lbl2.Text = "$" + ProrateTotal;
				string strTypeCard = "";
				//myPOS.dtPackageStart is changed to dtProrateTo as expired date should count on To
				myPOS.dtPackageStart = dtProrateFrom.Value;
				myPOS.NProrateDays = ProDiff;
				myPOS.NewReceiptEntry("GIRO(fit)",-1, "GIRO FItness",1, ProrateTotal, "",txtCardHolder.Text,strTypeCard,txtCreditCardNo.Text,dtCardExpiry.Value);
			
			}
			else
			{
				MessageBox.Show(" Please select the date either 15th or end of the month ");
				return;
			}
		
			
					
		}

		private void lbl2_Click(object sender, System.EventArgs e)
		{
		
		}

		private void dtProrateTo_ValueChanged(object sender, System.EventArgs e)
		{
//			if (dtProrateTo.Value.Day == 15 ||dtProrateTo.Value.Day == DateTime.DaysInMonth(dtProrateTo.Value.Year,dtProrateTo.Value.Month) ||dtProrateTo.Value.Day == 1 || dtProrateTo.Value.Day == 16)
//			{
				decimal mBasePrice = 118;
				TimeSpan ProRateDays = dtProrateTo.Value - dtProrateFrom.Value;
				int ProDiff = ACMS.Convert.ToInt32(Math.Round(ProRateDays.TotalDays + 1,0).ToString());
				decimal ProdateRate = ACMS.Convert.ToDecimal(ProDiff)/ACMS.Convert.ToDecimal(DateTime.DaysInMonth(dtProrateTo.Value.Year,dtProrateTo.Value.Month));
				decimal ProrateTotal;

				if (dtProrateTo.Value.Day == 1 || dtProrateTo.Value.Day == 16)
					ProrateTotal = (2 * mBasePrice);
				else
					ProrateTotal = 2 * mBasePrice + Math.Round(mBasePrice * ProdateRate,2);

				lbl2.Text = "$" + ProrateTotal;
//			}
//			else
//			{
//			MessageBox.Show(" Please select the date either 15th or end of the month ");
//				return;
//			}
		}

		
	}
}
