using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ACMS.ACMSLogin
{
	/// <summary>
	/// Summary description for frmException.
	/// </summary>
	public class frmException : System.Windows.Forms.Form
	{
		private DevExpress.XtraEditors.PanelControl panelControl1;
		private DevExpress.XtraEditors.MemoEdit memoEditError;
		private DevExpress.XtraEditors.PanelControl panelControl2;
		private System.Windows.Forms.Label lblErrorMessage;
		private DevExpress.XtraEditors.PictureEdit pictureEdit1;
		private DevExpress.XtraEditors.SimpleButton sbtnClose;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmException(string msg, string allMsg)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			lblErrorMessage.Text = msg;
			memoEditError.EditValue = allMsg;
			memoEditError.SelectionLength = 0;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmException));
			this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
			this.lblErrorMessage = new System.Windows.Forms.Label();
			this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
			this.memoEditError = new DevExpress.XtraEditors.MemoEdit();
			this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
			this.sbtnClose = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
			this.panelControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.memoEditError.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
			this.panelControl2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelControl1
			// 
			this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.panelControl1.Controls.Add(this.lblErrorMessage);
			this.panelControl1.Controls.Add(this.pictureEdit1);
			this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelControl1.Location = new System.Drawing.Point(0, 0);
			this.panelControl1.Name = "panelControl1";
			this.panelControl1.Size = new System.Drawing.Size(598, 56);
			this.panelControl1.TabIndex = 2;
			this.panelControl1.Text = "panelControl1";
			// 
			// lblErrorMessage
			// 
			this.lblErrorMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lblErrorMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblErrorMessage.Location = new System.Drawing.Point(84, 4);
			this.lblErrorMessage.Name = "lblErrorMessage";
			this.lblErrorMessage.Size = new System.Drawing.Size(500, 48);
			this.lblErrorMessage.TabIndex = 1;
			// 
			// pictureEdit1
			// 
			this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
			this.pictureEdit1.Location = new System.Drawing.Point(32, 10);
			this.pictureEdit1.Name = "pictureEdit1";
			// 
			// pictureEdit1.Properties
			// 
			this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.pictureEdit1.Properties.ReadOnly = true;
			this.pictureEdit1.Size = new System.Drawing.Size(35, 35);
			this.pictureEdit1.TabIndex = 0;
			// 
			// memoEditError
			// 
			this.memoEditError.Dock = System.Windows.Forms.DockStyle.Fill;
			this.memoEditError.EditValue = "";
			this.memoEditError.Location = new System.Drawing.Point(0, 56);
			this.memoEditError.Name = "memoEditError";
			// 
			// memoEditError.Properties
			// 
			this.memoEditError.Properties.ReadOnly = true;
			this.memoEditError.Size = new System.Drawing.Size(598, 164);
			this.memoEditError.TabIndex = 1;
			// 
			// panelControl2
			// 
			this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.panelControl2.Controls.Add(this.sbtnClose);
			this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelControl2.Location = new System.Drawing.Point(0, 220);
			this.panelControl2.Name = "panelControl2";
			this.panelControl2.Size = new System.Drawing.Size(598, 38);
			this.panelControl2.TabIndex = 0;
			this.panelControl2.Text = "panelControl2";
			this.panelControl2.Click += new System.EventHandler(this.sbtnClose_Click);
			// 
			// sbtnClose
			// 
			this.sbtnClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.sbtnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
			this.sbtnClose.Appearance.Options.UseFont = true;
			this.sbtnClose.Location = new System.Drawing.Point(260, 8);
			this.sbtnClose.Name = "sbtnClose";
			this.sbtnClose.Size = new System.Drawing.Size(83, 23);
			this.sbtnClose.TabIndex = 2;
			this.sbtnClose.Text = "&Close";
			this.sbtnClose.Click += new System.EventHandler(this.sbtnClose_Click);
			// 
			// frmException
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(598, 258);
			this.Controls.Add(this.memoEditError);
			this.Controls.Add(this.panelControl2);
			this.Controls.Add(this.panelControl1);
			this.MinimizeBox = false;
			this.Name = "frmException";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ACMS Application Error";
			this.TopMost = true;
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
			this.panelControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.memoEditError.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
			this.panelControl2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void sbtnClose_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.OK;
		}
	}
}
