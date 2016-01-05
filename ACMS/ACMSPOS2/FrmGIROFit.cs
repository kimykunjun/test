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
		internal System.Windows.Forms.Label label5;
		private DevExpress.XtraEditors.TextEdit txtCardHolder;
		private System.Windows.Forms.DateTimePicker dtProrateFrom;
        private System.Windows.Forms.DateTimePicker dtProrateTo;
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
            this.Label41.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label41.Location = new System.Drawing.Point(8, 8);
            this.Label41.Name = "Label41";
            this.Label41.Size = new System.Drawing.Size(114, 23);
            this.Label41.TabIndex = 29;
            this.Label41.Text = "EDDA Ref :";
            // 
            // txtCardHolder
            // 
            this.txtCardHolder.EditValue = "";
            this.txtCardHolder.Location = new System.Drawing.Point(176, 8);
            this.txtCardHolder.Name = "txtCardHolder";
            this.txtCardHolder.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtCardHolder.Properties.Appearance.Options.UseFont = true;
            this.txtCardHolder.Size = new System.Drawing.Size(328, 23);
            this.txtCardHolder.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 23);
            this.label1.TabIndex = 31;
            this.label1.Text = "Bank Acc No :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 23);
            this.label2.TabIndex = 33;
            this.label2.Text = "From:";
            // 
            // dtProrateFrom
            // 
            this.dtProrateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtProrateFrom.Location = new System.Drawing.Point(206, 89);
            this.dtProrateFrom.Name = "dtProrateFrom";
            this.dtProrateFrom.Size = new System.Drawing.Size(128, 20);
            this.dtProrateFrom.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 23);
            this.label3.TabIndex = 35;
            this.label3.Text = "To:";
            this.label3.Visible = false;
            // 
            // dtProrateTo
            // 
            this.dtProrateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtProrateTo.Location = new System.Drawing.Point(206, 121);
            this.dtProrateTo.Name = "dtProrateTo";
            this.dtProrateTo.Size = new System.Drawing.Size(128, 20);
            this.dtProrateTo.TabIndex = 36;
            this.dtProrateTo.Visible = false;
            this.dtProrateTo.ValueChanged += new System.EventHandler(this.dtProrateTo_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 23);
            this.label5.TabIndex = 39;
            this.label5.Text = "Total Amount:";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.Location = new System.Drawing.Point(161, 141);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(22, 23);
            this.lbl2.TabIndex = 40;
            this.lbl2.Text = "$";
            this.lbl2.Click += new System.EventHandler(this.lbl2_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(259, 176);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 42;
            this.btnCancel.Text = "Cancel";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(176, 176);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
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
            this.txtCreditCardNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreditCardNo.Properties.Appearance.Options.UseFont = true;
            this.txtCreditCardNo.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtCreditCardNo.Properties.MaxLength = 19;
            this.txtCreditCardNo.Size = new System.Drawing.Size(168, 20);
            this.txtCreditCardNo.TabIndex = 43;
            // 
            // GIROpkg
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(522, 217);
            this.Controls.Add(this.txtCreditCardNo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Label41);
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
            this.PerformLayout();

		}
		#endregion

		private void GIROpkg_Load(object sender, System.EventArgs e)
		{
		
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{

            if (ValidateGIRODate())//2504
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

                switch (myCategoryID)
                {
                    case 2:
                        mBasePrice = 128M;
                        mProRateTotal = (2 * mBasePrice);
                        strCode = "GIRO(fit)";
                        strDesc = "GIRO Fitness";
                        break;


                    case 34:
                        mBasePrice = 118M;
                        mProRateTotal = (2 * mBasePrice);
                        strCode = "GIRO(spa)";
                        strDesc = "GIRO Spa";
                        break;                    
                }                

                lbl2.Text = "$" + mProRateTotal.ToString();
                myPOS.dtPackageStart = dtFrom;
                myPOS.NewReceiptEntry(strCode, -1, strDesc, 1, mProRateTotal, strRefNo, strCardHolder, strTypeCard, strCreditCardNo);
                
                ///2504
               // ACMSPOS2.FormAddCreditPackage form = new ACMS.ACMSPOS2.FormAddCreditPackage(myPOS);
               //  form.ShowDialog(this);
                ////
                
                if (myCategoryID == 34)
                {
                    DataTable myTblspapacakge = myPOSHelper.SearchOnePackageCode(strCode);
                    if (myTblspapacakge != null)
                    {
                        if (myTblspapacakge.Rows.Count > 0)
                        {
                            DataRow dr = myTblspapacakge.Rows[0];

                            if (dr["strFreePkgCode"].ToString() != string.Empty)
                            {
                                myPOS.EditItemFreebieAndDiscount(dr["strFreePkgCode"].ToString());
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(" Unable to retrieve member package table. ");
                    }
                }
            }
		}

        private bool ValidateGIRODate()
        {
            bool bResult = true;
            
            if (dtProrateFrom.Value.Day != 1 && dtProrateFrom.Value.Day != 16)
            {
                bResult = false;
                MessageBox.Show(" Please select the date either 1st or 16th of the month ");
            }
           
            return bResult;
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
