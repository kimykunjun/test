using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ACMS.Utils;
using ACMSLogic;

namespace ACMS.ACMSStaff
{
	/// <summary>
	/// Summary description for frmChangePassword.
	/// </summary>
	public class frmChangePassword : System.Windows.Forms.Form
	{
		private DataRow myEmployeeInfo;
		private int nEmployeeID;

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private DevExpress.XtraEditors.TextEdit txtCurrentPassword;
		internal DevExpress.XtraEditors.SimpleButton sbtnClose;
		internal DevExpress.XtraEditors.SimpleButton sbtnOK;
		private DevExpress.XtraEditors.TextEdit txtNewPassword;
		private DevExpress.XtraEditors.TextEdit txtConfirmNewPassword;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmChangePassword(int nEmployeeID)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			this.nEmployeeID = nEmployeeID;
			myEmployeeInfo = ACMSLogic.Staff.Ultis.EmployeeInfo(nEmployeeID);
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtCurrentPassword = new DevExpress.XtraEditors.TextEdit();
			this.txtNewPassword = new DevExpress.XtraEditors.TextEdit();
			this.txtConfirmNewPassword = new DevExpress.XtraEditors.TextEdit();
			this.sbtnClose = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnOK = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.txtCurrentPassword.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtNewPassword.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtConfirmNewPassword.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(126, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Current Password:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 36);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(126, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "New Password:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(126, 23);
			this.label3.TabIndex = 2;
			this.label3.Text = "Confirm New Password:";
			// 
			// txtCurrentPassword
			// 
			this.txtCurrentPassword.EditValue = "";
			this.txtCurrentPassword.Location = new System.Drawing.Point(144, 6);
			this.txtCurrentPassword.Name = "txtCurrentPassword";
			// 
			// txtCurrentPassword.Properties
			// 
			this.txtCurrentPassword.Properties.MaxLength = 50;
			this.txtCurrentPassword.Properties.PasswordChar = '*';
			this.txtCurrentPassword.Size = new System.Drawing.Size(248, 20);
			this.txtCurrentPassword.TabIndex = 3;
			// 
			// txtNewPassword
			// 
			this.txtNewPassword.EditValue = "";
			this.txtNewPassword.Location = new System.Drawing.Point(144, 34);
			this.txtNewPassword.Name = "txtNewPassword";
			// 
			// txtNewPassword.Properties
			// 
			this.txtNewPassword.Properties.MaxLength = 50;
			this.txtNewPassword.Properties.PasswordChar = '*';
			this.txtNewPassword.Size = new System.Drawing.Size(248, 20);
			this.txtNewPassword.TabIndex = 4;
			// 
			// txtConfirmNewPassword
			// 
			this.txtConfirmNewPassword.EditValue = "";
			this.txtConfirmNewPassword.Location = new System.Drawing.Point(144, 62);
			this.txtConfirmNewPassword.Name = "txtConfirmNewPassword";
			// 
			// txtConfirmNewPassword.Properties
			// 
			this.txtConfirmNewPassword.Properties.MaxLength = 50;
			this.txtConfirmNewPassword.Properties.PasswordChar = '*';
			this.txtConfirmNewPassword.Size = new System.Drawing.Size(248, 20);
			this.txtConfirmNewPassword.TabIndex = 5;
			// 
			// sbtnClose
			// 
			this.sbtnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.sbtnClose.Location = new System.Drawing.Point(326, 92);
			this.sbtnClose.Name = "sbtnClose";
			this.sbtnClose.Size = new System.Drawing.Size(72, 20);
			this.sbtnClose.TabIndex = 11;
			this.sbtnClose.Text = "Cancel";
			// 
			// sbtnOK
			// 
			this.sbtnOK.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.sbtnOK.Location = new System.Drawing.Point(250, 92);
			this.sbtnOK.Name = "sbtnOK";
			this.sbtnOK.Size = new System.Drawing.Size(72, 20);
			this.sbtnOK.TabIndex = 10;
			this.sbtnOK.Text = "OK";
			this.sbtnOK.Click += new System.EventHandler(this.sbtnOK_Click);
			// 
			// frmChangePassword
			// 
			this.AcceptButton = this.sbtnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.sbtnClose;
			this.ClientSize = new System.Drawing.Size(406, 120);
			this.Controls.Add(this.sbtnClose);
			this.Controls.Add(this.sbtnOK);
			this.Controls.Add(this.txtConfirmNewPassword);
			this.Controls.Add(this.txtNewPassword);
			this.Controls.Add(this.txtCurrentPassword);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmChangePassword";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Change Password";
			((System.ComponentModel.ISupportInitialize)(this.txtCurrentPassword.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtNewPassword.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtConfirmNewPassword.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void sbtnOK_Click(object sender, System.EventArgs e)
		{
			if (txtNewPassword.EditValue.ToString() != txtConfirmNewPassword.EditValue.ToString())
			{
				UI.ShowErrorMessage("New password and confirm new password is not match. Please enter again.");
				txtNewPassword.Focus();
				DialogResult = DialogResult.None;
				return;
			}

			if (string.Compare(myEmployeeInfo["strPassword"].ToString(), txtCurrentPassword.EditValue.ToString(), true) != 0)
			{
				UI.ShowErrorMessage("Current password is not match. Please enter again.");
				txtCurrentPassword.Focus();
				DialogResult = DialogResult.None;
				return;
			}

			ACMSLogic.Staff.Ultis.ChangePassword(nEmployeeID, txtNewPassword.EditValue.ToString());

			UI.ShowMessage("Password change successfully.");
		}
	}
}
