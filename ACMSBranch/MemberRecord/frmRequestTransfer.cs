using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ACMS.Utils;
using ACMS.XtraUtils;

namespace ACMS.ACMSBranch
{
	/// <summary>
	/// Summary description for frmRequestTransfer.
	/// </summary>
	public class frmRequestTransfer : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.SimpleButton sbtnCancel;
		private DevExpress.XtraEditors.SimpleButton sbtnOK;
		private DevExpress.XtraEditors.LookUpEdit luedtDestinationBranch;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public string DestinationBranch
		{
			get {return luedtDestinationBranch.EditValue.ToString();}
		}

		public frmRequestTransfer()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			new XtraUtils.LookupEditBuilder.BranchCodeLookupEditBuilder2(luedtDestinationBranch.Properties);
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
			this.luedtDestinationBranch = new DevExpress.XtraEditors.LookUpEdit();
			this.sbtnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnOK = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.luedtDestinationBranch.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(10, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Destination Branch:";
			// 
			// luedtDestinationBranch
			// 
			this.luedtDestinationBranch.Location = new System.Drawing.Point(116, 8);
			this.luedtDestinationBranch.Name = "luedtDestinationBranch";
			// 
			// luedtDestinationBranch.Properties
			// 
			this.luedtDestinationBranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																														   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.luedtDestinationBranch.Size = new System.Drawing.Size(168, 20);
			this.luedtDestinationBranch.TabIndex = 1;
			// 
			// sbtnCancel
			// 
			this.sbtnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.sbtnCancel.Location = new System.Drawing.Point(158, 38);
			this.sbtnCancel.Name = "sbtnCancel";
			this.sbtnCancel.TabIndex = 6;
			this.sbtnCancel.Text = "Cancel";
			// 
			// sbtnOK
			// 
			this.sbtnOK.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.sbtnOK.Location = new System.Drawing.Point(64, 38);
			this.sbtnOK.Name = "sbtnOK";
			this.sbtnOK.TabIndex = 5;
			this.sbtnOK.Text = "OK";
			this.sbtnOK.Click += new System.EventHandler(this.sbtnOK_Click);
			// 
			// frmRequestTransfer
			// 
			this.AcceptButton = this.sbtnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.sbtnCancel;
			this.ClientSize = new System.Drawing.Size(292, 68);
			this.Controls.Add(this.sbtnCancel);
			this.Controls.Add(this.sbtnOK);
			this.Controls.Add(this.luedtDestinationBranch);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmRequestTransfer";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Request Transfer";
			((System.ComponentModel.ISupportInitialize)(this.luedtDestinationBranch.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void sbtnOK_Click(object sender, System.EventArgs e)
		{
			if (luedtDestinationBranch.EditValue == null || luedtDestinationBranch.EditValue.ToString().Length == 0)
			{
				UI.ShowErrorMessage(this, "Please select a Destination Branch.");
				luedtDestinationBranch.Focus();
				DialogResult = DialogResult.None;
				return;
			}
		}
	}
}
