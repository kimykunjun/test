using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using ACMSLogic;

namespace ACMS.ACMSPOS2
{
	/// <summary>
	/// Summary description for FormLockerAction.
	/// </summary>
	public class FormPaymentPlan : System.Windows.Forms.Form
    {
		/// <summary>
		/// Required designer variable.
		/// </summary>
        private ACMS.XtraUtils.LookupEditBuilder.InhouseIPPTotalNOptionsLookupEditBuilder myInhouseIPPTotalNOptionsLookupEditBuilder;
        private System.ComponentModel.Container components = null;
        internal DevExpress.XtraEditors.LookUpEdit lkpEdtTotalInstalment;
        internal Label label4;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
        private DevExpress.XtraEditors.SimpleButton simpleButtonOK;
		private ACMSLogic.POS myPOS;
        private string frmMasterReceiptNo;
        private decimal frmMasterReceiptTotal;
        private decimal frmPaymentAmount;
        private decimal frmOutstandingAmount;
        private string frmPackageList;

        public FormPaymentPlan(ACMSLogic.POS pos, string strMasterReceiptNo, decimal mMasterReceiptTotal, decimal mPaymentAmount,
                                                    decimal mOutstandingAmount, string strPackageList)
		{
			InitializeComponent();

			myPOS = pos;

            frmMasterReceiptNo = strMasterReceiptNo;
            frmMasterReceiptTotal = mMasterReceiptTotal;
            frmPaymentAmount = mPaymentAmount;
            frmOutstandingAmount = mOutstandingAmount;
            frmPackageList = strPackageList;

            Init();

            
		}

        private void Init()
        {
            myInhouseIPPTotalNOptionsLookupEditBuilder
                = new ACMS.XtraUtils.LookupEditBuilder.InhouseIPPTotalNOptionsLookupEditBuilder(lkpEdtTotalInstalment.Properties,
                                                                                                    frmMasterReceiptNo,
                                                                                                    frmMasterReceiptTotal,
                                                                                                    frmPaymentAmount,
                                                                                                    frmOutstandingAmount,
                                                                                                    frmPackageList);           
        }

        public string NTotalInstalment
        {
            get { return lkpEdtTotalInstalment.EditValue.ToString(); }
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
            this.lkpEdtTotalInstalment = new DevExpress.XtraEditors.LookUpEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.lkpEdtTotalInstalment.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lkpEdtTotalInstalment
            // 
            this.lkpEdtTotalInstalment.EditValue = "";
            this.lkpEdtTotalInstalment.Location = new System.Drawing.Point(166, 13);
            this.lkpEdtTotalInstalment.Name = "lkpEdtTotalInstalment";
            this.lkpEdtTotalInstalment.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lkpEdtTotalInstalment.Properties.Appearance.Options.UseFont = true;
            this.lkpEdtTotalInstalment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpEdtTotalInstalment.Size = new System.Drawing.Size(129, 23);
            this.lkpEdtTotalInstalment.TabIndex = 44;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(12, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 23);
            this.label4.TabIndex = 45;
            this.label4.Text = "Total Instalments  :";
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.simpleButtonCancel.Location = new System.Drawing.Point(220, 50);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonCancel.TabIndex = 47;
            this.simpleButtonCancel.Text = "Cancel";
            this.simpleButtonCancel.Click += new System.EventHandler(this.simpleButtonCancel_Click);
            // 
            // simpleButtonOK
            // 
            this.simpleButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.simpleButtonOK.Location = new System.Drawing.Point(134, 50);
            this.simpleButtonOK.Name = "simpleButtonOK";
            this.simpleButtonOK.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonOK.TabIndex = 46;
            this.simpleButtonOK.Text = "OK";
            this.simpleButtonOK.Click += new System.EventHandler(this.simpleButtonOK_Click);
            // 
            // FormPaymentPlan
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(324, 87);
            this.Controls.Add(this.simpleButtonCancel);
            this.Controls.Add(this.simpleButtonOK);
            this.Controls.Add(this.lkpEdtTotalInstalment);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPaymentPlan";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment Plan Options";
            ((System.ComponentModel.ISupportInitialize)(this.lkpEdtTotalInstalment.Properties)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        private void simpleButtonOK_Click(object sender, EventArgs e)
        {

            if (lkpEdtTotalInstalment.Text.ToString() == "")
            {
                MessageBox.Show(this, "Please select total instalment desired.");
                this.DialogResult = DialogResult.None;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                return;
            }
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            return;
        }

		
	}
}
