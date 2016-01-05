using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ACMS
{
	/// <summary>
	/// Summary description for FormCancelClassAttendance.
	/// </summary>
	public class FormDeleteMemberCreditPackage : System.Windows.Forms.Form
	{
		private DevExpress.XtraEditors.PanelControl panelControl1;
		private System.Windows.Forms.Label label2;
		private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
		private DevExpress.XtraEditors.SimpleButton simpleButtonOK;
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.MemoEdit memoEdit1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormDeleteMemberCreditPackage(int nMemberCreditPackageID, string strMemberName)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

			label1.Text = string.Format("Do you really want to delete" + "\n Member Credit Package ID :{0}, Member Name : {1}", 
				nMemberCreditPackageID.ToString(), strMemberName);
		}

		public string Remark
		{
			get {return memoEdit1.Text;}
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
			this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
			this.label2 = new System.Windows.Forms.Label();
			this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
			this.label1 = new System.Windows.Forms.Label();
			this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
			this.panelControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// panelControl1
			// 
			this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.panelControl1.Controls.Add(this.label2);
			this.panelControl1.Controls.Add(this.simpleButtonCancel);
			this.panelControl1.Controls.Add(this.simpleButtonOK);
			this.panelControl1.Controls.Add(this.label1);
			this.panelControl1.Controls.Add(this.memoEdit1);
			this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelControl1.Location = new System.Drawing.Point(0, 0);
			this.panelControl1.Name = "panelControl1";
			this.panelControl1.Size = new System.Drawing.Size(368, 262);
			this.panelControl1.TabIndex = 0;
			this.panelControl1.Text = "panelControl1";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(13, 86);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(309, 18);
			this.label2.TabIndex = 48;
			this.label2.Text = "Please write down the remark if you really want to delete it.";
			// 
			// simpleButtonCancel
			// 
			this.simpleButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.simpleButtonCancel.Location = new System.Drawing.Point(207, 228);
			this.simpleButtonCancel.Name = "simpleButtonCancel";
			this.simpleButtonCancel.TabIndex = 47;
			this.simpleButtonCancel.Text = "Cancel";
			// 
			// simpleButtonOK
			// 
			this.simpleButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.simpleButtonOK.Location = new System.Drawing.Point(103, 228);
			this.simpleButtonOK.Name = "simpleButtonOK";
			this.simpleButtonOK.TabIndex = 46;
			this.simpleButtonOK.Text = "OK";
			this.simpleButtonOK.Click += new System.EventHandler(this.simpleButtonOK_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(13, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(340, 46);
			this.label1.TabIndex = 45;
			this.label1.Text = "Do you really want to delete this service session?";
			// 
			// memoEdit1
			// 
			this.memoEdit1.EditValue = "";
			this.memoEdit1.Location = new System.Drawing.Point(13, 108);
			this.memoEdit1.Name = "memoEdit1";
			// 
			// memoEdit1.Properties
			// 
			this.memoEdit1.Properties.MaxLength = 250;
			this.memoEdit1.Size = new System.Drawing.Size(342, 114);
			this.memoEdit1.TabIndex = 44;
			// 
			// FormDeleteMemberCreditPackage
			// 
			this.AcceptButton = this.simpleButtonOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.simpleButtonCancel;
			this.ClientSize = new System.Drawing.Size(368, 262);
			this.Controls.Add(this.panelControl1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormDeleteMemberCreditPackage";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Delete Member\'s Credit Package";
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
			this.panelControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void simpleButtonOK_Click(object sender, System.EventArgs e)
		{
			if (memoEdit1.Text.Length == 0)
			{	
				MessageBox.Show("Please write down the remark why you want to cancel this class attendance.");
				this.DialogResult = DialogResult.None;
			}
			else
			{
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}
	}
}
