using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ACMSLogic;

namespace ACMS.ACMSBranch
{
	/// <summary>
	/// Summary description for frmResetMembershipID.
	/// </summary>
	public class frmResetMembershipID : System.Windows.Forms.Form
	{
		private int currentLastMemberID, currentLastNonMemberID;
		private string strBranchCode;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private DevExpress.XtraEditors.SpinEdit spinedtLastNonMemberID;
		private DevExpress.XtraEditors.SpinEdit spinedtLastMemberID;
		private DevExpress.XtraEditors.SimpleButton sbtnCancel;
		private DevExpress.XtraEditors.SimpleButton sbtnOK;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private DevExpress.XtraEditors.TextEdit txtLastNonMemberID;
		private DevExpress.XtraEditors.TextEdit txtLastMemberID;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public int LastNonMemberID
		{
			get {return Convert.ToInt32(spinedtLastNonMemberID.Value);}
		}

		public int LastMemberID
		{
			get {return Convert.ToInt32(spinedtLastMemberID.Value);}
		}

		public frmResetMembershipID(string terminalBranchCode)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			currentLastNonMemberID = 0;
			currentLastMemberID = 0;
			strBranchCode = terminalBranchCode;
			MemberRecord.CurrentLastMembershipID(terminalBranchCode, ref currentLastNonMemberID, ref currentLastMemberID);
			txtLastMemberID.EditValue = currentLastMemberID;
			txtLastNonMemberID.EditValue = currentLastNonMemberID;
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
			this.spinedtLastNonMemberID = new DevExpress.XtraEditors.SpinEdit();
			this.spinedtLastMemberID = new DevExpress.XtraEditors.SpinEdit();
			this.sbtnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnOK = new DevExpress.XtraEditors.SimpleButton();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtLastNonMemberID = new DevExpress.XtraEditors.TextEdit();
			this.txtLastMemberID = new DevExpress.XtraEditors.TextEdit();
			((System.ComponentModel.ISupportInitialize)(this.spinedtLastNonMemberID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.spinedtLastMemberID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtLastNonMemberID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtLastMemberID.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(10, 30);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(162, 18);
			this.label1.TabIndex = 0;
			this.label1.Text = "Reset Last Non-Member ID To:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(10, 78);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(138, 18);
			this.label2.TabIndex = 1;
			this.label2.Text = "Reset Last Member ID To:";
			// 
			// spinedtLastNonMemberID
			// 
			this.spinedtLastNonMemberID.EditValue = new System.Decimal(new int[] {
																					 0,
																					 0,
																					 0,
																					 0});
			this.spinedtLastNonMemberID.Location = new System.Drawing.Point(174, 28);
			this.spinedtLastNonMemberID.Name = "spinedtLastNonMemberID";
			// 
			// spinedtLastNonMemberID.Properties
			// 
			this.spinedtLastNonMemberID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																														   new DevExpress.XtraEditors.Controls.EditorButton()});
			this.spinedtLastNonMemberID.Properties.IsFloatValue = false;
			this.spinedtLastNonMemberID.Properties.Mask.EditMask = "N00";
			this.spinedtLastNonMemberID.Properties.NullText = "0";
			this.spinedtLastNonMemberID.Size = new System.Drawing.Size(80, 20);
			this.spinedtLastNonMemberID.TabIndex = 1;
			// 
			// spinedtLastMemberID
			// 
			this.spinedtLastMemberID.EditValue = new System.Decimal(new int[] {
																				  0,
																				  0,
																				  0,
																				  0});
			this.spinedtLastMemberID.Location = new System.Drawing.Point(174, 76);
			this.spinedtLastMemberID.Name = "spinedtLastMemberID";
			// 
			// spinedtLastMemberID.Properties
			// 
			this.spinedtLastMemberID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																														new DevExpress.XtraEditors.Controls.EditorButton()});
			this.spinedtLastMemberID.Properties.IsFloatValue = false;
			this.spinedtLastMemberID.Properties.Mask.EditMask = "N00";
			this.spinedtLastMemberID.Properties.NullText = "0";
			this.spinedtLastMemberID.Size = new System.Drawing.Size(80, 20);
			this.spinedtLastMemberID.TabIndex = 3;
			// 
			// sbtnCancel
			// 
			this.sbtnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.sbtnCancel.Location = new System.Drawing.Point(142, 102);
			this.sbtnCancel.Name = "sbtnCancel";
			this.sbtnCancel.TabIndex = 5;
			this.sbtnCancel.Text = "Cancel";
			// 
			// sbtnOK
			// 
			this.sbtnOK.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.sbtnOK.Location = new System.Drawing.Point(48, 102);
			this.sbtnOK.Name = "sbtnOK";
			this.sbtnOK.TabIndex = 4;
			this.sbtnOK.Text = "OK";
			this.sbtnOK.Click += new System.EventHandler(this.sbtnOK_Click);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(10, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(154, 18);
			this.label3.TabIndex = 9;
			this.label3.Text = "Current Last Non-Member ID:";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(10, 56);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(154, 18);
			this.label4.TabIndex = 10;
			this.label4.Text = "Current Last Member ID:";
			// 
			// txtLastNonMemberID
			// 
			this.txtLastNonMemberID.EditValue = "";
			this.txtLastNonMemberID.Location = new System.Drawing.Point(174, 6);
			this.txtLastNonMemberID.Name = "txtLastNonMemberID";
			// 
			// txtLastNonMemberID.Properties
			// 
			this.txtLastNonMemberID.Properties.ReadOnly = true;
			this.txtLastNonMemberID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txtLastNonMemberID.Size = new System.Drawing.Size(64, 20);
			this.txtLastNonMemberID.TabIndex = 0;
			// 
			// txtLastMemberID
			// 
			this.txtLastMemberID.EditValue = "";
			this.txtLastMemberID.Location = new System.Drawing.Point(174, 54);
			this.txtLastMemberID.Name = "txtLastMemberID";
			// 
			// txtLastMemberID.Properties
			// 
			this.txtLastMemberID.Properties.ReadOnly = true;
			this.txtLastMemberID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txtLastMemberID.Size = new System.Drawing.Size(64, 20);
			this.txtLastMemberID.TabIndex = 2;
			// 
			// frmResetMembershipID
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.sbtnCancel;
			this.ClientSize = new System.Drawing.Size(262, 128);
			this.Controls.Add(this.txtLastMemberID);
			this.Controls.Add(this.txtLastNonMemberID);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.sbtnCancel);
			this.Controls.Add(this.sbtnOK);
			this.Controls.Add(this.spinedtLastMemberID);
			this.Controls.Add(this.spinedtLastNonMemberID);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmResetMembershipID";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Reset Membership ID";
			((System.ComponentModel.ISupportInitialize)(this.spinedtLastNonMemberID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.spinedtLastMemberID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtLastNonMemberID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtLastMemberID.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void sbtnOK_Click(object sender, System.EventArgs e)
		{
			int lastMemberID = ACMS.Convert.ToInt32(spinedtLastMemberID.EditValue);
			int lastNonMemberID = ACMS.Convert.ToInt32(spinedtLastNonMemberID.EditValue);
			if (lastMemberID > 0 || lastNonMemberID > 0)
			{
				if (lastNonMemberID > 0 && MemberRecord.MembershipIDExist("NMC" +(lastNonMemberID + 1)))
				{
					if (!ACMS.Utils.UI.ShowYesNoMessage(this, "The non membership ID already exist for this number. Are you sure you "
						+"want continue?"))
					{
						DialogResult = DialogResult.None;
						return;
					}
				}
				if (lastMemberID > 0 && MemberRecord.MembershipIDExist(strBranchCode.Trim() +(lastMemberID + 1)))
				{
					if (!ACMS.Utils.UI.ShowYesNoMessage(this, "The membership ID will already for this number. Are you sure you "
						+"want continue?"))
					{
						DialogResult = DialogResult.None;
						return;
					}
				}

				string message = "";
				if (lastMemberID > 0)
				{
					message = "New last member ID will be " +lastMemberID +". ";
				}
				if (lastNonMemberID > 0)
				{
					message += "New last non-member ID will be " +lastNonMemberID +". ";
				}
				message += "Are you sure you want to commit change?";
				if (ACMS.Utils.UI.ShowYesNoMessage(this, message))
					DialogResult = DialogResult.OK;
				else
					DialogResult = DialogResult.Cancel;
			}
		}

	}
}
