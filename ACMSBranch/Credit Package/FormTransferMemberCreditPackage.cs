using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ACMS
{
	/// <summary>
	/// Summary description for FormTransferMemberCreditPackage.
	/// </summary>
	public class FormTransferMemberCreditPackage : System.Windows.Forms.Form
	{
		private DevExpress.XtraEditors.PanelControl panelControl1;
		private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
		private DevExpress.XtraEditors.MemoEdit memoEdit1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
		private DevExpress.XtraEditors.SimpleButton simpleButtonOK;
		private ACMS.XtraUtils.LookupEditBuilder.MemberIDLookupEditBuilder myMemberIDLookupEditBuilder;
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormTransferMemberCreditPackage(int nCreditPackageID)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

			this.Text = string.Format("Transfer member credit package ID : {0}", nCreditPackageID.ToString());
			
			ACMSLogic.Member member = new ACMSLogic.Member();
			myMemberIDLookupEditBuilder = new ACMS.XtraUtils.LookupEditBuilder.MemberIDLookupEditBuilder(member, lookUpEdit1.Properties);
		
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

		public string StrMembershipID
		{
			get 
			{ 
				if (lookUpEdit1.EditValue != null)
					return lookUpEdit1.EditValue.ToString();
				else
					return "";
			}
		}

		public string Remark
		{
			get
			{
				return memoEdit1.Text;
			}
		}
	

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
			this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
			this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
			this.panelControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// panelControl1
			// 
			this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.panelControl1.Controls.Add(this.simpleButtonCancel);
			this.panelControl1.Controls.Add(this.simpleButtonOK);
			this.panelControl1.Controls.Add(this.label3);
			this.panelControl1.Controls.Add(this.label2);
			this.panelControl1.Controls.Add(this.label1);
			this.panelControl1.Controls.Add(this.memoEdit1);
			this.panelControl1.Controls.Add(this.lookUpEdit1);
			this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelControl1.Location = new System.Drawing.Point(0, 0);
			this.panelControl1.Name = "panelControl1";
			this.panelControl1.Size = new System.Drawing.Size(338, 220);
			this.panelControl1.TabIndex = 0;
			this.panelControl1.Text = "panelControl1";
			// 
			// simpleButtonCancel
			// 
			this.simpleButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.simpleButtonCancel.Location = new System.Drawing.Point(246, 186);
			this.simpleButtonCancel.Name = "simpleButtonCancel";
			this.simpleButtonCancel.TabIndex = 51;
			this.simpleButtonCancel.Text = "Cancel";
			// 
			// simpleButtonOK
			// 
			this.simpleButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.simpleButtonOK.Location = new System.Drawing.Point(156, 186);
			this.simpleButtonOK.Name = "simpleButtonOK";
			this.simpleButtonOK.TabIndex = 50;
			this.simpleButtonOK.Text = "OK";
			this.simpleButtonOK.Click += new System.EventHandler(this.simpleButtonOK_Click);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 76);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 24);
			this.label3.TabIndex = 4;
			this.label3.Text = "Remark";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(68, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "Member ID";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(2, 4);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(260, 30);
			this.label1.TabIndex = 2;
			this.label1.Text = "Please select the member you wish to transfer him/her the credit package.";
			// 
			// memoEdit1
			// 
			this.memoEdit1.EditValue = "";
			this.memoEdit1.Location = new System.Drawing.Point(82, 74);
			this.memoEdit1.Name = "memoEdit1";
			this.memoEdit1.Size = new System.Drawing.Size(242, 96);
			this.memoEdit1.TabIndex = 1;
			// 
			// lookUpEdit1
			// 
			this.lookUpEdit1.Location = new System.Drawing.Point(80, 46);
			this.lookUpEdit1.Name = "lookUpEdit1";
			// 
			// lookUpEdit1.Properties
			// 
			this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lookUpEdit1.Size = new System.Drawing.Size(244, 20);
			this.lookUpEdit1.TabIndex = 0;
			// 
			// FormTransferMemberCreditPackage
			// 
			this.AcceptButton = this.simpleButtonOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.simpleButtonCancel;
			this.ClientSize = new System.Drawing.Size(338, 220);
			this.Controls.Add(this.panelControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormTransferMemberCreditPackage";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FormTransferMemberCreditPackage";
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
			this.panelControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void simpleButtonOK_Click(object sender, System.EventArgs e)
		{
			if (memoEdit1.Text.Length == 0)
			{
				MessageBox.Show("Please write down the remark.");
				this.DialogResult = DialogResult.None;
				return;
			}

			if (lookUpEdit1.Text.Length == 0)
			{
				MessageBox.Show("Please select a member.");
				this.DialogResult = DialogResult.None;
				return;
			}
		}
	}
}

