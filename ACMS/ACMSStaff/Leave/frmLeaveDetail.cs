using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ACMS.Utils;
using ACMSDAL;
using ACMSLogic;
using ACMSLogic.Staff;

namespace ACMS.ACMSStaff.Leave
{
	/// <summary>
	/// Summary description for frmLeaveDetail.
	/// </summary>
	public class frmLeaveDetail : System.Windows.Forms.Form
	{
		public string LeaveType
		{
			set {txtLeaveType.EditValue = value;}
		}
	
		public DateTime StartDate
		{
			set {dateedtStart.DateTime = value;}
		}

		public DateTime StartTime
		{
			set {timeedtStart.Time = value;}
		}

		public DateTime EndTime
		{
			set {timeedtEnd.Time = value;}
		}

		public string Status
		{
			set {txtStatus.EditValue = value;}
		}

		public string ApprovingManager
		{
			set {txtApprovingManager.EditValue = value;}
		}

		public string Reason
		{
			set {memoedtReason.EditValue = value;}
		}

		public bool IsHalfDay
		{
			set {chkedtIsHalfDay.EditValue = value;}
		}

		public bool ShowIsHalfDay
		{
			set {chkedtIsHalfDay.Visible = value;}
		}

		public bool EnableTime
		{
			set {groupctrTime.Enabled = value;}
		}

		private DevExpress.XtraEditors.MemoEdit memoedtReason;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private DevExpress.XtraEditors.DateEdit dateedtStart;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private DevExpress.XtraEditors.TextEdit txtLeaveType;
		private DevExpress.XtraEditors.TextEdit txtStatus;
		private System.Windows.Forms.Label label6;
		private DevExpress.XtraEditors.TextEdit txtApprovingManager;
		private DevExpress.XtraEditors.SimpleButton sbtnOK;
		private DevExpress.XtraEditors.GroupControl groupctrTime;
		private DevExpress.XtraEditors.TimeEdit timeedtEnd;
		private System.Windows.Forms.Label label2;
		private DevExpress.XtraEditors.TimeEdit timeedtStart;
		private System.Windows.Forms.Label label7;
		private DevExpress.XtraEditors.CheckEdit chkedtIsHalfDay;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmLeaveDetail()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			ACMS.XtraUtils.XtraEditors.SetDateEditFormat(this.Controls);
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
			this.memoedtReason = new DevExpress.XtraEditors.MemoEdit();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.dateedtStart = new DevExpress.XtraEditors.DateEdit();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtLeaveType = new DevExpress.XtraEditors.TextEdit();
			this.txtApprovingManager = new DevExpress.XtraEditors.TextEdit();
			this.txtStatus = new DevExpress.XtraEditors.TextEdit();
			this.label6 = new System.Windows.Forms.Label();
			this.sbtnOK = new DevExpress.XtraEditors.SimpleButton();
			this.groupctrTime = new DevExpress.XtraEditors.GroupControl();
			this.timeedtEnd = new DevExpress.XtraEditors.TimeEdit();
			this.label2 = new System.Windows.Forms.Label();
			this.timeedtStart = new DevExpress.XtraEditors.TimeEdit();
			this.label7 = new System.Windows.Forms.Label();
			this.chkedtIsHalfDay = new DevExpress.XtraEditors.CheckEdit();
			((System.ComponentModel.ISupportInitialize)(this.memoedtReason.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dateedtStart.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtLeaveType.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtApprovingManager.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtStatus.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupctrTime)).BeginInit();
			this.groupctrTime.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.timeedtEnd.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.timeedtStart.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chkedtIsHalfDay.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// memoedtReason
			// 
			this.memoedtReason.EditValue = "";
			this.memoedtReason.Location = new System.Drawing.Point(132, 190);
			this.memoedtReason.Name = "memoedtReason";
			// 
			// memoedtReason.Properties
			// 
			this.memoedtReason.Properties.ReadOnly = true;
			this.memoedtReason.Size = new System.Drawing.Size(224, 138);
			this.memoedtReason.TabIndex = 6;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(20, 192);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 20);
			this.label5.TabIndex = 39;
			this.label5.Text = "Reason";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(20, 166);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(106, 20);
			this.label4.TabIndex = 38;
			this.label4.Text = "Approving Manager";
			// 
			// dateedtStart
			// 
			this.dateedtStart.EditValue = null;
			this.dateedtStart.Location = new System.Drawing.Point(132, 34);
			this.dateedtStart.Name = "dateedtStart";
			// 
			// dateedtStart.Properties
			// 
			this.dateedtStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dateedtStart.Properties.ReadOnly = true;
			this.dateedtStart.Size = new System.Drawing.Size(132, 20);
			this.dateedtStart.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(20, 36);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 20);
			this.label1.TabIndex = 36;
			this.label1.Text = "Date";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(20, 10);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 20);
			this.label3.TabIndex = 35;
			this.label3.Text = "Leave Type";
			// 
			// txtLeaveType
			// 
			this.txtLeaveType.EditValue = "";
			this.txtLeaveType.Location = new System.Drawing.Point(132, 8);
			this.txtLeaveType.Name = "txtLeaveType";
			// 
			// txtLeaveType.Properties
			// 
			this.txtLeaveType.Properties.ReadOnly = true;
			this.txtLeaveType.Size = new System.Drawing.Size(224, 20);
			this.txtLeaveType.TabIndex = 0;
			// 
			// txtApprovingManager
			// 
			this.txtApprovingManager.EditValue = "";
			this.txtApprovingManager.Location = new System.Drawing.Point(132, 164);
			this.txtApprovingManager.Name = "txtApprovingManager";
			// 
			// txtApprovingManager.Properties
			// 
			this.txtApprovingManager.Properties.ReadOnly = true;
			this.txtApprovingManager.Size = new System.Drawing.Size(224, 20);
			this.txtApprovingManager.TabIndex = 5;
			// 
			// txtStatus
			// 
			this.txtStatus.EditValue = "";
			this.txtStatus.Location = new System.Drawing.Point(132, 138);
			this.txtStatus.Name = "txtStatus";
			// 
			// txtStatus.Properties
			// 
			this.txtStatus.Properties.ReadOnly = true;
			this.txtStatus.Size = new System.Drawing.Size(224, 20);
			this.txtStatus.TabIndex = 4;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(20, 140);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 20);
			this.label6.TabIndex = 42;
			this.label6.Text = "Status";
			// 
			// sbtnOK
			// 
			this.sbtnOK.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.sbtnOK.Location = new System.Drawing.Point(284, 334);
			this.sbtnOK.Name = "sbtnOK";
			this.sbtnOK.Size = new System.Drawing.Size(72, 20);
			this.sbtnOK.TabIndex = 7;
			this.sbtnOK.Text = "OK";
			// 
			// groupctrTime
			// 
			this.groupctrTime.Controls.Add(this.timeedtEnd);
			this.groupctrTime.Controls.Add(this.label2);
			this.groupctrTime.Controls.Add(this.timeedtStart);
			this.groupctrTime.Controls.Add(this.label7);
			this.groupctrTime.Location = new System.Drawing.Point(16, 62);
			this.groupctrTime.Name = "groupctrTime";
			this.groupctrTime.Size = new System.Drawing.Size(340, 72);
			this.groupctrTime.TabIndex = 3;
			this.groupctrTime.Text = "Time Off";
			// 
			// timeedtEnd
			// 
			this.timeedtEnd.EditValue = new System.DateTime(2006, 3, 19, 0, 0, 0, 0);
			this.timeedtEnd.Location = new System.Drawing.Point(118, 46);
			this.timeedtEnd.Name = "timeedtEnd";
			// 
			// timeedtEnd.Properties
			// 
			this.timeedtEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											   new DevExpress.XtraEditors.Controls.EditorButton()});
			this.timeedtEnd.Properties.Mask.EditMask = "hh:mm tt";
			this.timeedtEnd.Properties.ReadOnly = true;
			this.timeedtEnd.Size = new System.Drawing.Size(88, 20);
			this.timeedtEnd.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 18);
			this.label2.TabIndex = 28;
			this.label2.Text = "End Time";
			// 
			// timeedtStart
			// 
			this.timeedtStart.EditValue = new System.DateTime(2006, 3, 19, 0, 0, 0, 0);
			this.timeedtStart.Location = new System.Drawing.Point(118, 20);
			this.timeedtStart.Name = "timeedtStart";
			// 
			// timeedtStart.Properties
			// 
			this.timeedtStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												 new DevExpress.XtraEditors.Controls.EditorButton()});
			this.timeedtStart.Properties.Mask.EditMask = "hh:mm tt";
			this.timeedtStart.Properties.ReadOnly = true;
			this.timeedtStart.Size = new System.Drawing.Size(88, 20);
			this.timeedtStart.TabIndex = 0;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(6, 22);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(100, 20);
			this.label7.TabIndex = 17;
			this.label7.Text = "Start Time";
			// 
			// chkedtIsHalfDay
			// 
			this.chkedtIsHalfDay.Location = new System.Drawing.Point(20, 62);
			this.chkedtIsHalfDay.Name = "chkedtIsHalfDay";
			// 
			// chkedtIsHalfDay.Properties
			// 
			this.chkedtIsHalfDay.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.chkedtIsHalfDay.Properties.Appearance.Options.UseBackColor = true;
			this.chkedtIsHalfDay.Properties.Caption = "Half Day Leave";
			this.chkedtIsHalfDay.Properties.ReadOnly = true;
			this.chkedtIsHalfDay.Size = new System.Drawing.Size(110, 18);
			this.chkedtIsHalfDay.TabIndex = 2;
			this.chkedtIsHalfDay.CheckedChanged += new System.EventHandler(this.chkedtIsHalfDay_EditValueChanged);
			// 
			// frmLeaveDetail
			// 
			this.AcceptButton = this.sbtnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.sbtnOK;
			this.ClientSize = new System.Drawing.Size(376, 360);
			this.Controls.Add(this.chkedtIsHalfDay);
			this.Controls.Add(this.sbtnOK);
			this.Controls.Add(this.txtStatus);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txtApprovingManager);
			this.Controls.Add(this.txtLeaveType);
			this.Controls.Add(this.memoedtReason);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.dateedtStart);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.groupctrTime);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmLeaveDetail";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Leave Detail";
			((System.ComponentModel.ISupportInitialize)(this.memoedtReason.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dateedtStart.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtLeaveType.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtApprovingManager.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtStatus.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupctrTime)).EndInit();
			this.groupctrTime.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.timeedtEnd.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.timeedtStart.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chkedtIsHalfDay.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void chkedtIsHalfDay_EditValueChanged(object sender, System.EventArgs e)
		{
			if (chkedtIsHalfDay.Checked)
			{
				groupctrTime.Enabled = true;
			}
			else
			{
				groupctrTime.Enabled = false;
			}
		}
	}
}
