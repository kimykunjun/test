using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ACMS.Utils;
using ACMSLogic;

namespace ACMS.ACMSBranch
{
	/// <summary>
	/// Summary description for frmResetMembershipID.
	/// </summary>
	public class frmBlockMembershipID : System.Windows.Forms.Form
	{
		int currentLastMemberID, currentLastNonMemberID;
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.SpinEdit spinedtLastNonMemberID;
		private DevExpress.XtraEditors.SpinEdit spinedtLastMemberID;
		private DevExpress.XtraEditors.SimpleButton sbtnCancel;
		private DevExpress.XtraEditors.SimpleButton sbtnOK;
		private DevExpress.XtraEditors.GroupControl groupControl1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private DevExpress.XtraEditors.LookUpEdit luedtBranchCode;
		private DevExpress.XtraEditors.GroupControl groupControl2;
		private DevExpress.XtraEditors.TextEdit txtLastNonMemberID;
		private System.Windows.Forms.Label label3;
		private DevExpress.XtraEditors.TextEdit txtLastMemberID;
		private System.Windows.Forms.Label label5;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public int NumberOfNonMemberID
		{
			get {return Convert.ToInt32(spinedtLastNonMemberID.Value);}
		}

		public int NumberOfMemberID
		{
			get {return Convert.ToInt32(spinedtLastMemberID.Value);}
		}

		public object StrBranchCode
		{
			get {return luedtBranchCode.EditValue;}
		}

		public frmBlockMembershipID(string terminalBranchCode)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			new ACMS.XtraUtils.LookupEditBuilder.BranchCodeLookupEditBuilder2(luedtBranchCode.Properties);
			luedtBranchCode.EditValue = terminalBranchCode;

			currentLastNonMemberID = 0;
			currentLastMemberID = 0;
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
			this.spinedtLastNonMemberID = new DevExpress.XtraEditors.SpinEdit();
			this.spinedtLastMemberID = new DevExpress.XtraEditors.SpinEdit();
			this.sbtnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnOK = new DevExpress.XtraEditors.SimpleButton();
			this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
			this.luedtBranchCode = new DevExpress.XtraEditors.LookUpEdit();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
			this.txtLastNonMemberID = new DevExpress.XtraEditors.TextEdit();
			this.label3 = new System.Windows.Forms.Label();
			this.txtLastMemberID = new DevExpress.XtraEditors.TextEdit();
			this.label5 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.spinedtLastNonMemberID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.spinedtLastMemberID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
			this.groupControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.luedtBranchCode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
			this.groupControl2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtLastNonMemberID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtLastMemberID.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 44);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(204, 18);
			this.label1.TabIndex = 0;
			this.label1.Text = "Number of Non-Member ids to block ID:";
			// 
			// spinedtLastNonMemberID
			// 
			this.spinedtLastNonMemberID.EditValue = new System.Decimal(new int[] {
																					 0,
																					 0,
																					 0,
																					 0});
			this.spinedtLastNonMemberID.Location = new System.Drawing.Point(212, 42);
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
			this.spinedtLastMemberID.Location = new System.Drawing.Point(212, 42);
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
			this.spinedtLastMemberID.TabIndex = 1;
			// 
			// sbtnCancel
			// 
			this.sbtnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.sbtnCancel.Location = new System.Drawing.Point(170, 168);
			this.sbtnCancel.Name = "sbtnCancel";
			this.sbtnCancel.TabIndex = 3;
			this.sbtnCancel.Text = "Cancel";
			// 
			// sbtnOK
			// 
			this.sbtnOK.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.sbtnOK.Location = new System.Drawing.Point(76, 168);
			this.sbtnOK.Name = "sbtnOK";
			this.sbtnOK.TabIndex = 2;
			this.sbtnOK.Text = "OK";
			this.sbtnOK.Click += new System.EventHandler(this.sbtnOK_Click);
			// 
			// groupControl1
			// 
			this.groupControl1.Controls.Add(this.txtLastMemberID);
			this.groupControl1.Controls.Add(this.label5);
			this.groupControl1.Controls.Add(this.luedtBranchCode);
			this.groupControl1.Controls.Add(this.label4);
			this.groupControl1.Controls.Add(this.label2);
			this.groupControl1.Controls.Add(this.spinedtLastMemberID);
			this.groupControl1.Location = new System.Drawing.Point(6, 76);
			this.groupControl1.Name = "groupControl1";
			this.groupControl1.Size = new System.Drawing.Size(298, 88);
			this.groupControl1.TabIndex = 1;
			this.groupControl1.Text = "Member";
			// 
			// luedtBranchCode
			// 
			this.luedtBranchCode.Location = new System.Drawing.Point(212, 64);
			this.luedtBranchCode.Name = "luedtBranchCode";
			// 
			// luedtBranchCode.Properties
			// 
			this.luedtBranchCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.luedtBranchCode.Size = new System.Drawing.Size(80, 20);
			this.luedtBranchCode.TabIndex = 2;
			this.luedtBranchCode.EditValueChanged += new System.EventHandler(this.luedtBranchCode_EditValueChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(6, 66);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(78, 18);
			this.label4.TabIndex = 5;
			this.label4.Text = "Branch:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 44);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(204, 18);
			this.label2.TabIndex = 4;
			this.label2.Text = "Number of Member ids to block ID:";
			// 
			// groupControl2
			// 
			this.groupControl2.Controls.Add(this.txtLastNonMemberID);
			this.groupControl2.Controls.Add(this.label3);
			this.groupControl2.Controls.Add(this.spinedtLastNonMemberID);
			this.groupControl2.Controls.Add(this.label1);
			this.groupControl2.Location = new System.Drawing.Point(4, 4);
			this.groupControl2.Name = "groupControl2";
			this.groupControl2.Size = new System.Drawing.Size(300, 68);
			this.groupControl2.TabIndex = 0;
			this.groupControl2.Text = "Non-member";
			// 
			// txtLastNonMemberID
			// 
			this.txtLastNonMemberID.EditValue = "";
			this.txtLastNonMemberID.Location = new System.Drawing.Point(212, 20);
			this.txtLastNonMemberID.Name = "txtLastNonMemberID";
			// 
			// txtLastNonMemberID.Properties
			// 
			this.txtLastNonMemberID.Properties.ReadOnly = true;
			this.txtLastNonMemberID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txtLastNonMemberID.Size = new System.Drawing.Size(64, 20);
			this.txtLastNonMemberID.TabIndex = 0;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(6, 22);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(154, 18);
			this.label3.TabIndex = 11;
			this.label3.Text = "Current Last Non-Member ID:";
			// 
			// txtLastMemberID
			// 
			this.txtLastMemberID.EditValue = "";
			this.txtLastMemberID.Location = new System.Drawing.Point(212, 20);
			this.txtLastMemberID.Name = "txtLastMemberID";
			// 
			// txtLastMemberID.Properties
			// 
			this.txtLastMemberID.Properties.ReadOnly = true;
			this.txtLastMemberID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txtLastMemberID.Size = new System.Drawing.Size(64, 20);
			this.txtLastMemberID.TabIndex = 0;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(6, 22);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(154, 18);
			this.label5.TabIndex = 12;
			this.label5.Text = "Current Last Member ID:";
			// 
			// frmBlockMembershipID
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.sbtnCancel;
			this.ClientSize = new System.Drawing.Size(306, 194);
			this.Controls.Add(this.groupControl2);
			this.Controls.Add(this.groupControl1);
			this.Controls.Add(this.sbtnCancel);
			this.Controls.Add(this.sbtnOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmBlockMembershipID";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Block Membership ID";
			((System.ComponentModel.ISupportInitialize)(this.spinedtLastNonMemberID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.spinedtLastMemberID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
			this.groupControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.luedtBranchCode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
			this.groupControl2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.txtLastNonMemberID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtLastMemberID.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void sbtnOK_Click(object sender, System.EventArgs e)
		{
			if (spinedtLastMemberID.Value >= 1 && luedtBranchCode.EditValue.ToString().Length == 0)
			{
				UI.ShowErrorMessage(this, "Please specify a Branch Code.");
				luedtBranchCode.Focus();
				DialogResult = DialogResult.None;
				return;
			}

			int lastMemberID = ACMS.Convert.ToInt32(spinedtLastMemberID.EditValue);
			int lastNonMemberID = ACMS.Convert.ToInt32(spinedtLastNonMemberID.EditValue);
			if (lastMemberID > 0 || lastNonMemberID > 0)
			{
				string message = "";
				if (lastMemberID > 0)
				{
					message = "New last member ID will be increase " +(lastMemberID + currentLastMemberID) +". ";
				}
				if (lastNonMemberID > 0)
				{
					message += "New last non-member ID will be increase " +(lastNonMemberID + currentLastNonMemberID) +". ";
				}
				message += "Are you sure you want to commit change?";
				if (ACMS.Utils.UI.ShowYesNoMessage(this, message))
					DialogResult = DialogResult.OK;
				else
					DialogResult = DialogResult.Cancel;
			}
		}

		private void luedtBranchCode_EditValueChanged(object sender, System.EventArgs e)
		{
			MemberRecord.CurrentLastMembershipID(luedtBranchCode.EditValue.ToString(), ref currentLastNonMemberID, 
				ref currentLastMemberID);
			txtLastMemberID.EditValue = currentLastMemberID;
			txtLastNonMemberID.EditValue = currentLastNonMemberID;
		}
	}
}
