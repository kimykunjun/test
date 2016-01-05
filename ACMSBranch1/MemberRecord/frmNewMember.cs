using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ACMS.Utils;
using ACMSLogic;

namespace ACMS.ACMSBranch
{
	/// <summary>
	/// Summary description for frmNewMember.
	/// </summary>
	public class frmNewMember : System.Windows.Forms.Form
	{
		private MemberRecord myMemberRecord;
		private ACMSLogic.User myUser;
		private string strTerminalBranchCode;
		private string strMembershipID;
		private DevExpress.XtraEditors.CheckEdit chkedtMember;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.Label Label2;
		private DevExpress.XtraEditors.SimpleButton sbtnSave;
		private DevExpress.XtraEditors.SimpleButton sbtnCancel;
		private DevExpress.XtraEditors.CheckEdit chkedtIsSg;
		internal DevExpress.XtraEditors.TextEdit txtMemberName;
		internal DevExpress.XtraEditors.TextEdit txtNRICFIN;
		private DevExpress.XtraEditors.DateEdit dateedtDOB;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public string StrMembershipID
		{
			get { return strMembershipID; }
			set { strMembershipID = value; }
		}

		public frmNewMember(MemberRecord aMemberRecord, ACMSLogic.User oUser, string aStrTerminalBranchCode)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			ACMS.XtraUtils.XtraEditors.SetDateEditFormat(dateedtDOB);
			myMemberRecord = aMemberRecord;
			myUser = oUser;
			strTerminalBranchCode = aStrTerminalBranchCode;
			strMembershipID = string.Empty;

			chkedtMember.Checked = true;
			dateedtDOB.DateTime = DateTime.Now.Date;
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
			this.chkedtMember = new DevExpress.XtraEditors.CheckEdit();
			this.Label5 = new System.Windows.Forms.Label();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.sbtnSave = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.chkedtIsSg = new DevExpress.XtraEditors.CheckEdit();
			this.txtMemberName = new DevExpress.XtraEditors.TextEdit();
			this.txtNRICFIN = new DevExpress.XtraEditors.TextEdit();
			this.dateedtDOB = new DevExpress.XtraEditors.DateEdit();
			((System.ComponentModel.ISupportInitialize)(this.chkedtMember.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chkedtIsSg.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtMemberName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtNRICFIN.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dateedtDOB.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// chkedtMember
			// 
			this.chkedtMember.Location = new System.Drawing.Point(16, 12);
			this.chkedtMember.Name = "chkedtMember";
			// 
			// chkedtMember.Properties
			// 
			this.chkedtMember.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.chkedtMember.Properties.Appearance.Options.UseFont = true;
			this.chkedtMember.Properties.Caption = "Member";
			this.chkedtMember.Size = new System.Drawing.Size(98, 18);
			this.chkedtMember.TabIndex = 0;
			// 
			// Label5
			// 
			this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Label5.Location = new System.Drawing.Point(16, 110);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(98, 18);
			this.Label5.TabIndex = 57;
			this.Label5.Text = "Date-of-Birth:";
			// 
			// Label4
			// 
			this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Label4.Location = new System.Drawing.Point(16, 84);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(98, 18);
			this.Label4.TabIndex = 56;
			this.Label4.Text = "NRIC/FIN No:";
			// 
			// Label2
			// 
			this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Label2.Location = new System.Drawing.Point(16, 36);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(98, 18);
			this.Label2.TabIndex = 54;
			this.Label2.Text = "Member Name:";
			// 
			// sbtnSave
			// 
			this.sbtnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnSave.Location = new System.Drawing.Point(108, 138);
			this.sbtnSave.Name = "sbtnSave";
			this.sbtnSave.TabIndex = 5;
			this.sbtnSave.Text = "Save";
			this.sbtnSave.Click += new System.EventHandler(this.sbtnSave_Click);
			// 
			// sbtnCancel
			// 
			this.sbtnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.sbtnCancel.Location = new System.Drawing.Point(192, 138);
			this.sbtnCancel.Name = "sbtnCancel";
			this.sbtnCancel.TabIndex = 6;
			this.sbtnCancel.Text = "Cancel";
			this.sbtnCancel.Click += new System.EventHandler(this.sbtnCancel_Click);
			// 
			// chkedtIsSg
			// 
			this.chkedtIsSg.EditValue = true;
			this.chkedtIsSg.Location = new System.Drawing.Point(16, 60);
			this.chkedtIsSg.Name = "chkedtIsSg";
			// 
			// chkedtIsSg.Properties
			// 
			this.chkedtIsSg.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.chkedtIsSg.Properties.Appearance.Options.UseFont = true;
			this.chkedtIsSg.Properties.Caption = "Singaporean";
			this.chkedtIsSg.Size = new System.Drawing.Size(98, 18);
			this.chkedtIsSg.TabIndex = 2;
			// 
			// txtMemberName
			// 
			this.txtMemberName.EditValue = "";
			this.txtMemberName.Location = new System.Drawing.Point(116, 34);
			this.txtMemberName.Name = "txtMemberName";
			// 
			// txtMemberName.Properties
			// 
			this.txtMemberName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtMemberName.Properties.Appearance.Options.UseFont = true;
			this.txtMemberName.Properties.MaxLength = 50;
			this.txtMemberName.Size = new System.Drawing.Size(232, 20);
			this.txtMemberName.TabIndex = 1;
			// 
			// txtNRICFIN
			// 
			this.txtNRICFIN.EditValue = "";
			this.txtNRICFIN.Location = new System.Drawing.Point(116, 82);
			this.txtNRICFIN.Name = "txtNRICFIN";
			// 
			// txtNRICFIN.Properties
			// 
			this.txtNRICFIN.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtNRICFIN.Properties.Appearance.Options.UseFont = true;
			this.txtNRICFIN.Properties.MaxLength = 50;
			this.txtNRICFIN.Size = new System.Drawing.Size(232, 20);
			this.txtNRICFIN.TabIndex = 3;
			// 
			// dateedtDOB
			// 
			this.dateedtDOB.EditValue = new System.DateTime(2006, 1, 1, 0, 0, 0, 0);
			this.dateedtDOB.Location = new System.Drawing.Point(116, 108);
			this.dateedtDOB.Name = "dateedtDOB";
			// 
			// dateedtDOB.Properties
			// 
			this.dateedtDOB.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dateedtDOB.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
			this.dateedtDOB.Size = new System.Drawing.Size(104, 20);
			this.dateedtDOB.TabIndex = 4;
			// 
			// frmNewMember
			// 
			this.AcceptButton = this.sbtnSave;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.sbtnCancel;
			this.ClientSize = new System.Drawing.Size(362, 168);
			this.Controls.Add(this.chkedtIsSg);
			this.Controls.Add(this.txtNRICFIN);
			this.Controls.Add(this.sbtnCancel);
			this.Controls.Add(this.sbtnSave);
			this.Controls.Add(this.dateedtDOB);
			this.Controls.Add(this.Label5);
			this.Controls.Add(this.Label4);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.txtMemberName);
			this.Controls.Add(this.chkedtMember);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmNewMember";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "New Member";
			((System.ComponentModel.ISupportInitialize)(this.chkedtMember.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chkedtIsSg.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtMemberName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtNRICFIN.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dateedtDOB.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void sbtnCancel_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private void sbtnSave_Click(object sender, System.EventArgs e)
		{
			if (txtMemberName.Text.Length == 0)
			{
				UI.ShowErrorMessage(this, "Please fill in Member Name.");
				txtMemberName.Focus();
				DialogResult = DialogResult.None;
				return;
			}
			if (txtNRICFIN.Text.Length == 0)
			{
				UI.ShowErrorMessage(this, "Please fill in NIRC/FIN.");
				txtNRICFIN.Focus();
				DialogResult = DialogResult.None;
				return;
			}

			if (chkedtIsSg.Checked && !MemberRecord.ValidateNRICFormat(txtNRICFIN.Text))
			{
				if (UI.ShowYesNoMessage(this, "NIRC is not in valid format. Do you want enter again?", "Reminder"))
				{
					txtNRICFIN.Focus();
					DialogResult = DialogResult.None;
					return;
				}
			}

			if (chkedtIsSg.Checked)
			{
				if (myMemberRecord.CheckDuplicateNRIC(txtNRICFIN.Text, "") > 0)
				{
					ACMS.Utils.UI.ShowErrorMessage(this, "This NRIC already registed by other person.", "Duplicate NRIC");
					txtNRICFIN.Focus();
					DialogResult = DialogResult.None;
					return;
				}
			}

			if (dateedtDOB.EditValue == null || dateedtDOB.EditValue.ToString().Length == 0)
			{
				ACMS.Utils.UI.ShowErrorMessage(this, "Please enter Date of Birth.");
				dateedtDOB.Focus();
				DialogResult = DialogResult.None;
				return;
			}

			try
			{
				if (chkedtMember.Checked)
				{
					strMembershipID = myMemberRecord.AddNewMember(chkedtMember.Checked, strTerminalBranchCode, txtMemberName.Text, chkedtIsSg.Checked, 
						txtNRICFIN.Text, myUser.NEmployeeID(), dateedtDOB.DateTime, myUser);
				}
				else
				{
					strMembershipID = myMemberRecord.AddNewMember(chkedtMember.Checked, myUser.StrBranchCode(), txtMemberName.Text, chkedtIsSg.Checked,
						txtNRICFIN.Text, myUser.NEmployeeID(), dateedtDOB.DateTime, myUser);
				}
			}
			catch (Exception ex)
			{
				if (ex.InnerException.Message.IndexOf(
					"Violation of PRIMARY KEY constraint 'PK_tblMember'. Cannot insert duplicate key in object 'tblMember") != -1)
				{
					UI.ShowErrorMessage("Duplicate ID found. Please reset membership ID.");
					DialogResult = DialogResult.Cancel;
				}
				else
					throw;
			}
			DialogResult = DialogResult.OK;
		}
	}
}
