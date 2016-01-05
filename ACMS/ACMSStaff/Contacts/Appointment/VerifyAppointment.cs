using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ACMS
{
	/// <summary>
	/// Summary description for VerifyAppointment.
	/// </summary>
	public class VerifyAppointment : System.Windows.Forms.Form
	{
		private DevExpress.XtraEditors.PanelControl panelControl1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.TextEdit textEditPW;
		private DevExpress.XtraEditors.TextEdit textEditUserID;
		private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
        private DevExpress.XtraEditors.SimpleButton simpleButtonOK;

		private ACMS.XtraUtils.LookupEditBuilder.EmployeeIDLookupEditBuilder myEmployeeIDLookupEditBuilder;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public VerifyAppointment()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//			
		}

		public int VerifierID
		{
			get { return ACMS.Convert.ToInt32(textEditUserID.Text); } 
		}

		public string Password
		{
			get 
			{
				if (textEditPW.EditValue != null)
					return textEditPW.EditValue.ToString();
				else 
					return "";
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textEditPW = new DevExpress.XtraEditors.TextEdit();
            this.textEditUserID = new DevExpress.XtraEditors.TextEdit();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPW.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditUserID.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.textEditPW);
            this.panelControl1.Controls.Add(this.textEditUserID);
            this.panelControl1.Controls.Add(this.simpleButtonCancel);
            this.panelControl1.Controls.Add(this.simpleButtonOK);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(328, 141);
            this.panelControl1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 23);
            this.label2.TabIndex = 42;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 23);
            this.label1.TabIndex = 41;
            this.label1.Text = "Verifier ID";
            // 
            // textEditPW
            // 
            this.textEditPW.EditValue = "";
            this.textEditPW.Location = new System.Drawing.Point(142, 50);
            this.textEditPW.Name = "textEditPW";
            this.textEditPW.Properties.PasswordChar = '*';
            this.textEditPW.Size = new System.Drawing.Size(156, 20);
            this.textEditPW.TabIndex = 1;
            // 
            // textEditUserID
            // 
            this.textEditUserID.EditValue = "";
            this.textEditUserID.Location = new System.Drawing.Point(142, 18);
            this.textEditUserID.Name = "textEditUserID";
            this.textEditUserID.Size = new System.Drawing.Size(156, 20);
            this.textEditUserID.TabIndex = 0;
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.simpleButtonCancel.Location = new System.Drawing.Point(174, 90);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonCancel.TabIndex = 38;
            this.simpleButtonCancel.Text = "Cancel";
            // 
            // simpleButtonOK
            // 
            this.simpleButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.simpleButtonOK.Location = new System.Drawing.Point(70, 90);
            this.simpleButtonOK.Name = "simpleButtonOK";
            this.simpleButtonOK.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonOK.TabIndex = 37;
            this.simpleButtonOK.Text = "OK";
            this.simpleButtonOK.Click += new System.EventHandler(this.simpleButtonOK_Click);
            // 
            // VerifyAppointment
            // 
            this.AcceptButton = this.simpleButtonOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.simpleButtonCancel;
            this.ClientSize = new System.Drawing.Size(328, 141);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VerifyAppointment";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Verify Appointment";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEditPW.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditUserID.Properties)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void simpleButtonOK_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
