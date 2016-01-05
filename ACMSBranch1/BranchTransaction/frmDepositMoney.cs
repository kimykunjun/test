using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ACMS.ACMSBranch.BranchTransaction
{
	/// <summary>
	/// Summary description for frmDepositMoney.
	/// </summary>
	public class frmDepositMoney : System.Windows.Forms.Form
	{
		private DevExpress.XtraEditors.GroupControl groupControl1;
		private DevExpress.XtraEditors.TextEdit txtDepositMoney;
		private System.Windows.Forms.Label lblDepositMoney;
		internal DevExpress.XtraEditors.SimpleButton Open;
		internal DevExpress.XtraEditors.SimpleButton Cancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmDepositMoney()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
			this.txtDepositMoney = new DevExpress.XtraEditors.TextEdit();
			this.lblDepositMoney = new System.Windows.Forms.Label();
			this.Open = new DevExpress.XtraEditors.SimpleButton();
			this.Cancel = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
			this.groupControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtDepositMoney.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// groupControl1
			// 
			this.groupControl1.Controls.Add(this.txtDepositMoney);
			this.groupControl1.Controls.Add(this.lblDepositMoney);
			this.groupControl1.Controls.Add(this.Open);
			this.groupControl1.Controls.Add(this.Cancel);
			this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupControl1.Location = new System.Drawing.Point(0, 0);
			this.groupControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
			this.groupControl1.Name = "groupControl1";
			this.groupControl1.ShowCaption = false;
			this.groupControl1.Size = new System.Drawing.Size(292, 109);
			this.groupControl1.TabIndex = 5;
			this.groupControl1.Text = "groupControl1";
			// 
			// txtDepositMoney
			// 
			this.txtDepositMoney.EditValue = "";
			this.txtDepositMoney.Location = new System.Drawing.Point(176, 16);
			this.txtDepositMoney.Name = "txtDepositMoney";
			this.txtDepositMoney.TabIndex = 3;
			// 
			// lblDepositMoney
			// 
			this.lblDepositMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblDepositMoney.Location = new System.Drawing.Point(16, 16);
			this.lblDepositMoney.Name = "lblDepositMoney";
			this.lblDepositMoney.Size = new System.Drawing.Size(152, 23);
			this.lblDepositMoney.TabIndex = 0;
			this.lblDepositMoney.Text = "Money to be deposited";
			// 
			// Open
			// 
			this.Open.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.Open.Appearance.Options.UseFont = true;
			this.Open.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.Open.Location = new System.Drawing.Point(72, 56);
			this.Open.Name = "Open";
			this.Open.Size = new System.Drawing.Size(112, 20);
			this.Open.TabIndex = 5;
			this.Open.Text = "Save to safebox";
			// 
			// Cancel
			// 
			this.Cancel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.Cancel.Appearance.Options.UseFont = true;
			this.Cancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.Cancel.Location = new System.Drawing.Point(200, 56);
			this.Cancel.Name = "Cancel";
			this.Cancel.Size = new System.Drawing.Size(72, 20);
			this.Cancel.TabIndex = 6;
			this.Cancel.Text = "Cancel";
			// 
			// frmDepositMoney
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 109);
			this.Controls.Add(this.groupControl1);
			this.Name = "frmDepositMoney";
			this.Text = "Deposit Money .....";
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
			this.groupControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.txtDepositMoney.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
	}
}
