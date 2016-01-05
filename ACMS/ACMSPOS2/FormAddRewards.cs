using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ACMS.ACMSPOS2
{
	/// <summary>
	/// Summary description for FormAddRewards.
	/// </summary>
	public class FormAddRewards : System.Windows.Forms.Form
	{
		private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
		private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
		private DevExpress.XtraEditors.SimpleButton simpleButtonOK;
		internal System.Windows.Forms.Label Label4;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private ACMSLogic.POS myPOS;
		private ACMS.XtraUtils.LookupEditBuilder.RewardCodeLookupEditBuilder myRewardCodeLookupBuilder;

		public FormAddRewards(ACMSLogic.POS pos)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			myPOS = pos;
			ACMSDAL.TblCategory category = new ACMSDAL.TblCategory();
			category.NCategoryID = pos.NCategoryID;
			category.SelectOne();

			myRewardCodeLookupBuilder = new ACMS.XtraUtils.LookupEditBuilder.RewardCodeLookupEditBuilder(lookUpEdit1.Properties, 
				myPOS.StrBranchCode, ACMS.Convert.ToInt32(category.NSalesCategoryID));
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
			this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
			this.Label4 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// lookUpEdit1
			// 
			this.lookUpEdit1.EditValue = "";
			this.lookUpEdit1.Location = new System.Drawing.Point(94, 14);
			this.lookUpEdit1.Name = "lookUpEdit1";
			// 
			// lookUpEdit1.Properties
			// 
			this.lookUpEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
			this.lookUpEdit1.Properties.Appearance.Options.UseFont = true;
			this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lookUpEdit1.Size = new System.Drawing.Size(296, 23);
			this.lookUpEdit1.TabIndex = 0;
			// 
			// simpleButtonCancel
			// 
			this.simpleButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.simpleButtonCancel.Location = new System.Drawing.Point(218, 44);
			this.simpleButtonCancel.Name = "simpleButtonCancel";
			this.simpleButtonCancel.TabIndex = 14;
			this.simpleButtonCancel.Text = "Cancel";
			// 
			// simpleButtonOK
			// 
			this.simpleButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.simpleButtonOK.Location = new System.Drawing.Point(134, 44);
			this.simpleButtonOK.Name = "simpleButtonOK";
			this.simpleButtonOK.TabIndex = 13;
			this.simpleButtonOK.Text = "OK";
			this.simpleButtonOK.Click += new System.EventHandler(this.simpleButtonOK_Click);
			// 
			// Label4
			// 
			this.Label4.AutoSize = true;
			this.Label4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Label4.Location = new System.Drawing.Point(10, 12);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(83, 26);
			this.Label4.TabIndex = 40;
			this.Label4.Text = "Reward";
			// 
			// FormAddRewards
			// 
			this.AcceptButton = this.simpleButtonOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.simpleButtonCancel;
			this.ClientSize = new System.Drawing.Size(398, 72);
			this.Controls.Add(this.Label4);
			this.Controls.Add(this.simpleButtonCancel);
			this.Controls.Add(this.simpleButtonOK);
			this.Controls.Add(this.lookUpEdit1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormAddRewards";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Add Reward";
			((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void simpleButtonOK_Click(object sender, System.EventArgs e)
		{
			if (lookUpEdit1.EditValue == null || lookUpEdit1.Text == "") return;

			myPOS.StrRewardsCode = lookUpEdit1.EditValue.ToString();
		}
	}
}
