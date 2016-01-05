using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ACMS.ACMSPOS2
{
	/// <summary>
	/// Summary description for FormBillDiscount.
	/// </summary>
	public class FormBillDiscount : System.Windows.Forms.Form
	{
		private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
		internal System.Windows.Forms.Label Label4;
		private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
		private DevExpress.XtraEditors.SimpleButton simpleButtonOK;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private ACMSLogic.POS myPOS;
		internal System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.LookUpEdit lookUpEdit2;
		private ACMS.XtraUtils.LookupEditBuilder.BillDiscountPromotionCodeLookupEditBuilder myBillDiscountCodeLookupEditBuilder;
		private ACMS.XtraUtils.LookupEditBuilder.BillDepositPromotionCodeLookupEditBuilder myBillDepositCodeLookupEditBuilder;

		public FormBillDiscount(ACMSLogic.POS pos)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			myPOS = pos;
			myBillDiscountCodeLookupEditBuilder = new ACMS.XtraUtils.LookupEditBuilder.BillDiscountPromotionCodeLookupEditBuilder(lookUpEdit1.Properties,
				myPOS.StrMembershipID, myPOS.MNettAmount, myPOS.StrBranchCode, myPOS.NCategoryID, true);

			myBillDepositCodeLookupEditBuilder = new ACMS.XtraUtils.LookupEditBuilder.BillDepositPromotionCodeLookupEditBuilder(lookUpEdit2.Properties,
				myPOS.StrMembershipID,myPOS.NCategoryID);

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
			this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
			this.Label4 = new System.Windows.Forms.Label();
			this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
			this.label1 = new System.Windows.Forms.Label();
			this.lookUpEdit2 = new DevExpress.XtraEditors.LookUpEdit();
			((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lookUpEdit2.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// lookUpEdit1
			// 
			this.lookUpEdit1.EditValue = "";
			this.lookUpEdit1.Location = new System.Drawing.Point(114, 16);
			this.lookUpEdit1.Name = "lookUpEdit1";
			// 
			// lookUpEdit1.Properties
			// 
			this.lookUpEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
			this.lookUpEdit1.Properties.Appearance.Options.UseFont = true;
			this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lookUpEdit1.Size = new System.Drawing.Size(302, 23);
			this.lookUpEdit1.TabIndex = 40;
			// 
			// Label4
			// 
			this.Label4.AutoSize = true;
			this.Label4.Font = new System.Drawing.Font("Tahoma", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Label4.Location = new System.Drawing.Point(10, 14);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(93, 26);
			this.Label4.TabIndex = 39;
			this.Label4.Text = "Discount";
			// 
			// simpleButtonCancel
			// 
			this.simpleButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.simpleButtonCancel.Location = new System.Drawing.Point(240, 91);
			this.simpleButtonCancel.Name = "simpleButtonCancel";
			this.simpleButtonCancel.TabIndex = 42;
			this.simpleButtonCancel.Text = "Cancel";
			// 
			// simpleButtonOK
			// 
			this.simpleButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.simpleButtonOK.Location = new System.Drawing.Point(158, 90);
			this.simpleButtonOK.Name = "simpleButtonOK";
			this.simpleButtonOK.TabIndex = 41;
			this.simpleButtonOK.Text = "OK";
			this.simpleButtonOK.Click += new System.EventHandler(this.simpleButtonOK_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(14, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(82, 26);
			this.label1.TabIndex = 43;
			this.label1.Text = "Deposit";
			// 
			// lookUpEdit2
			// 
			this.lookUpEdit2.EditValue = "";
			this.lookUpEdit2.Location = new System.Drawing.Point(112, 54);
			this.lookUpEdit2.Name = "lookUpEdit2";
			// 
			// lookUpEdit2.Properties
			// 
			this.lookUpEdit2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
			this.lookUpEdit2.Properties.Appearance.Options.UseFont = true;
			this.lookUpEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lookUpEdit2.Size = new System.Drawing.Size(302, 23);
			this.lookUpEdit2.TabIndex = 44;
			// 
			// FormBillDiscount
			// 
			this.AcceptButton = this.simpleButtonOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.simpleButtonCancel;
			this.ClientSize = new System.Drawing.Size(428, 120);
			this.Controls.Add(this.lookUpEdit2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.simpleButtonCancel);
			this.Controls.Add(this.simpleButtonOK);
			this.Controls.Add(this.lookUpEdit1);
			this.Controls.Add(this.Label4);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormBillDiscount";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Bill Discount";
			((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lookUpEdit2.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void simpleButtonOK_Click(object sender, System.EventArgs e)
		{
			if (lookUpEdit1.Text != "") 			
			myPOS.NewBillDiscount(lookUpEdit1.EditValue.ToString());

			if(lookUpEdit2.Text != "")
			myPOS.NewBillDeposit(lookUpEdit2.EditValue.ToString());
		}
	}
}
