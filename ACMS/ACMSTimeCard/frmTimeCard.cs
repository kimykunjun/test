using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using ACMSLogic;
using ACMSLogic.TimeCard;
using ACMS.Utils;

namespace ACMS
{
	public class frmTimeCard : System.Windows.Forms.Form
	{
		private TimeCard myTimeCard;
		internal DevExpress.XtraEditors.SimpleButton sbtnClose;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Label Label41;
		private string strBranchCode;
		#region " Windows Form Designer generated code "
		//Form overrides dispose to clean up the component list.
		protected override void Dispose (bool disposing)
		{
			if (disposing)
			{
				if (!(components == null))
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label lblTimer;
		internal DevExpress.XtraEditors.SimpleButton btnOK;
		private DevExpress.XtraEditors.TextEdit txtEmployeeID;
		private DevExpress.XtraEditors.TextEdit txtPassword;
		internal System.Windows.Forms.Label Label1;
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent ()
		{
			this.components = new System.ComponentModel.Container();
			this.btnOK = new DevExpress.XtraEditors.SimpleButton();
			this.Label1 = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.lblTimer = new System.Windows.Forms.Label();
			this.txtEmployeeID = new DevExpress.XtraEditors.TextEdit();
			this.txtPassword = new DevExpress.XtraEditors.TextEdit();
			this.sbtnClose = new DevExpress.XtraEditors.SimpleButton();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label41 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.txtEmployeeID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.btnOK.Appearance.Options.UseFont = true;
			this.btnOK.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(190, 144);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(72, 20);
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// Label1
			// 
			this.Label1.BackColor = System.Drawing.Color.Red;
			this.Label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.Label1.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Label1.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.Label1.Location = new System.Drawing.Point(0, 0);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(374, 50);
			this.Label1.TabIndex = 4;
			this.Label1.Text = "TIMECARD";
			this.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// lblTimer
			// 
			this.lblTimer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lblTimer.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTimer.Location = new System.Drawing.Point(8, 56);
			this.lblTimer.Name = "lblTimer";
			this.lblTimer.Size = new System.Drawing.Size(358, 23);
			this.lblTimer.TabIndex = 5;
			this.lblTimer.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtEmployeeID
			// 
			this.txtEmployeeID.EditValue = "";
			this.txtEmployeeID.Location = new System.Drawing.Point(154, 88);
			this.txtEmployeeID.Name = "txtEmployeeID";
			// 
			// txtEmployeeID.Properties
			// 
			this.txtEmployeeID.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
			this.txtEmployeeID.Properties.Appearance.Options.UseFont = true;
			this.txtEmployeeID.Size = new System.Drawing.Size(138, 24);
			this.txtEmployeeID.TabIndex = 0;
			this.txtEmployeeID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmployeeID_KeyDown);
			// 
			// txtPassword
			// 
			this.txtPassword.EditValue = "";
			this.txtPassword.Location = new System.Drawing.Point(154, 114);
			this.txtPassword.Name = "txtPassword";
			// 
			// txtPassword.Properties
			// 
			this.txtPassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
			this.txtPassword.Properties.Appearance.Options.UseFont = true;
			this.txtPassword.Properties.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(138, 24);
			this.txtPassword.TabIndex = 1;
			this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
			// 
			// sbtnClose
			// 
			this.sbtnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.sbtnClose.Appearance.Options.UseFont = true;
			this.sbtnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.sbtnClose.Location = new System.Drawing.Point(266, 144);
			this.sbtnClose.Name = "sbtnClose";
			this.sbtnClose.Size = new System.Drawing.Size(72, 20);
			this.sbtnClose.TabIndex = 9;
			this.sbtnClose.Text = "Cancel";
			this.sbtnClose.Click += new System.EventHandler(this.sbtnClose_Click);
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Label2.Location = new System.Drawing.Point(64, 116);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(66, 18);
			this.Label2.TabIndex = 12;
			this.Label2.Text = "Password";
			// 
			// Label41
			// 
			this.Label41.AutoSize = true;
			this.Label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Label41.Location = new System.Drawing.Point(64, 90);
			this.Label41.Name = "Label41";
			this.Label41.Size = new System.Drawing.Size(84, 18);
			this.Label41.TabIndex = 11;
			this.Label41.Text = "Employee ID";
			// 
			// frmTimeCard
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.sbtnClose;
			this.ClientSize = new System.Drawing.Size(374, 170);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.Label41);
			this.Controls.Add(this.sbtnClose);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.txtEmployeeID);
			this.Controls.Add(this.lblTimer);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.btnOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.Name = "frmTimeCard";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ACMS Time Card";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmTimeCard_Closing);
			this.Load += new System.EventHandler(this.frmTimeCard_Load);
			((System.ComponentModel.ISupportInitialize)(this.txtEmployeeID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		
		#endregion

		public frmTimeCard(string strBranchCode) 
		{
			//This call is required by the Windows Form Designer.
			InitializeComponent();
			
			//Add any initialization after the InitializeComponent() call
			lblTimer.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy   hh:mm tt");
			this.strBranchCode = strBranchCode;
			timer1.Interval = 500;
			timer1.Start();
		}
	
		private void frmTimeCard_Load(object sender, System.EventArgs e)
		{
			modInitForms.fTimeCard = this;
			myTimeCard = new TimeCard();
		}
		
		private void frmTimeCard_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			modInitForms.fTimeCard = null;
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			lblTimer.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy   hh:mm tt");
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			int nEmployeeID = -1;
			if (txtEmployeeID.EditValue.ToString().Length == 0)
			{
				UI.ShowErrorMessage(this, "Please enter your Employee ID.");
				txtEmployeeID.Focus();
				DialogResult = DialogResult.None;
				return;
			}
			try 
			{
				nEmployeeID = Convert.ToInt32(txtEmployeeID.EditValue);
			}
			catch
			{
				UI.ShowErrorMessage(this, "Please enter a correct format of Employee ID.", "Error");
				txtEmployeeID.Focus();
				DialogResult = DialogResult.None;
				return;
			}
			if (myTimeCard.ValidatePassword(nEmployeeID, txtPassword.Text))
			{
				if (!myTimeCard.SaveTimeCard(this.strBranchCode, nEmployeeID))
					UI.ShowMessage(this, "Punch In successfully at " +DateTime.Now.ToString("dddd, dd MMMM yyyy   hh:mm tt" +"."));
				else
					UI.ShowMessage(this, "Punch Out successfully at " +DateTime.Now.ToString("dddd, dd MMMM yyyy   hh:mm tt" +"."));
				
				if (modInitForms.fBranch == null)
					Application.Exit();
				else
					this.Close();
			}
			else
			{
				UI.ShowErrorMessage(this, "Please enter a correct username or password.", "Error");
				txtPassword.Focus();
				DialogResult = DialogResult.None;
				return;
			}
		}

		private void sbtnClose_Click(object sender, System.EventArgs e)
		{
			if (modInitForms.fBranch == null)
				Application.Exit();
			else
				this.Close();
		}

		private void txtEmployeeID_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode.ToString()=="Return")
			{
				//to add send key
                txtPassword.Focus();
			}
		}

		private void txtPassword_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            if (e.KeyCode.ToString() == "Return")
			{
				//to add send key
                btnOK_Click(sender, e);
			}
		}

	}
	
}
