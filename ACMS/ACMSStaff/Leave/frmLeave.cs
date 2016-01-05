using System;
using System.Data;
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
	/// Summary description for frmNewLeave.
	/// </summary>
	public class frmLeave : DevExpress.XtraEditors.XtraForm
	{
		public object LeaveType
		{
			set {luedtLeaveType.EditValue = value;}
		}
	
		public DateTime StartDate
		{
			set {dateedtDate.DateTime = value;}
		}

		public DateTime StartTime
		{
			set {timeedtStart.Time = value;}
		}

		public DateTime EndTime
		{
			set {timeedtEnd.Time = value;}
		}

		public string Reason
		{
			set {memoedtReason.EditValue = value;}
		}

		public bool IsHalfDay
		{
			set {chkedtIsHalfDay.Checked = value;}
		}

		public bool ShowIsHalfDay
		{
			set {chkedtIsHalfDay.Visible = value;}
		}

		public bool EnableTime
		{
			set {groupctrTime.Enabled = value;}
		}

		private int nLeaveID;
		private int nEmployeeID;
		private ACMSLogic.Staff.Leave myLeave;
		private DataRow myEmployeeInfo;

		private DevExpress.XtraEditors.LookUpEdit luedtLeaveType;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label5;
		private DevExpress.XtraEditors.SimpleButton sbtnCancel;
		private DevExpress.XtraEditors.SimpleButton sbtnSave;
		private DevExpress.XtraEditors.MemoEdit memoedtReason;
		private DevExpress.XtraEditors.TimeEdit timeedtEnd;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private DevExpress.XtraEditors.TimeEdit timeedtStart;
		private DevExpress.XtraEditors.GroupControl groupctrTime;
		private DevExpress.XtraEditors.DateEdit dateedtDate;
		private DevExpress.XtraEditors.CheckEdit chkedtIsHalfDay;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmLeave(int nLeaveID, int nEmployeeID, DataRow employeeInfo)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			ACMS.XtraUtils.XtraEditors.SetDateEditFormat(this.Controls);
			this.nLeaveID = nLeaveID;
			this.nEmployeeID = nEmployeeID;
			myLeave = new ACMSLogic.Staff.Leave();
			myEmployeeInfo = employeeInfo;

			if (nLeaveID < 0)
			{
				this.Text = "Apply Leave";
				luedtLeaveType.Enabled = true;
			}
			else
			{
				this.Text = "Edit Leave";
				luedtLeaveType.Enabled = false;
			}

            new XtraUtils.LookupEditBuilder.LeaveCodeLookupEditBuilder(nEmployeeID,luedtLeaveType.Properties);

			DataTable leaveTypeTable = luedtLeaveType.Properties.DataSource as DataTable;

			if (!ACMS.Convert.ToBoolean(myEmployeeInfo["fMaternityLeave"]))
			{
				DataRow[] rows = leaveTypeTable.Select("strLeaveCode = 'MTL' OR strLeaveCode = 'MT3'");
				foreach (DataRow row in rows)
				{
					row.Delete();
				}
			}

			if (!ACMS.Convert.ToBoolean(myEmployeeInfo["fChildCareLeave"]))
			{
				DataRow[] rows = leaveTypeTable.Select("strLeaveCode = 'CHD'");
				foreach (DataRow row in rows)
				{
					row.Delete();
				}
			}

			leaveTypeTable.AcceptChanges();
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
            this.luedtLeaveType = new DevExpress.XtraEditors.LookUpEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateedtDate = new DevExpress.XtraEditors.DateEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.memoedtReason = new DevExpress.XtraEditors.MemoEdit();
            this.sbtnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnSave = new DevExpress.XtraEditors.SimpleButton();
            this.timeedtEnd = new DevExpress.XtraEditors.TimeEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.timeedtStart = new DevExpress.XtraEditors.TimeEdit();
            this.groupctrTime = new DevExpress.XtraEditors.GroupControl();
            this.chkedtIsHalfDay = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.luedtLeaveType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateedtDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateedtDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoedtReason.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeedtEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeedtStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupctrTime)).BeginInit();
            this.groupctrTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkedtIsHalfDay.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // luedtLeaveType
            // 
            this.luedtLeaveType.Location = new System.Drawing.Point(124, 8);
            this.luedtLeaveType.Name = "luedtLeaveType";
            this.luedtLeaveType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luedtLeaveType.Size = new System.Drawing.Size(224, 20);
            this.luedtLeaveType.TabIndex = 0;
            this.luedtLeaveType.EditValueChanged += new System.EventHandler(this.luedtLeaveType_EditValueChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Leave Type";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Start Time";
            // 
            // dateedtDate
            // 
            this.dateedtDate.EditValue = null;
            this.dateedtDate.Location = new System.Drawing.Point(124, 34);
            this.dateedtDate.Name = "dateedtDate";
            this.dateedtDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateedtDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dateedtDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateedtDate.Size = new System.Drawing.Size(132, 20);
            this.dateedtDate.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.TabIndex = 24;
            this.label5.Text = "Reason";
            // 
            // memoedtReason
            // 
            this.memoedtReason.EditValue = "";
            this.memoedtReason.Location = new System.Drawing.Point(124, 138);
            this.memoedtReason.Name = "memoedtReason";
            this.memoedtReason.Properties.MaxLength = 255;
            this.memoedtReason.Size = new System.Drawing.Size(224, 138);
            this.memoedtReason.TabIndex = 4;
            // 
            // sbtnCancel
            // 
            this.sbtnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.sbtnCancel.Location = new System.Drawing.Point(278, 284);
            this.sbtnCancel.Name = "sbtnCancel";
            this.sbtnCancel.Size = new System.Drawing.Size(72, 20);
            this.sbtnCancel.TabIndex = 6;
            this.sbtnCancel.Text = "Cancel";
            // 
            // sbtnSave
            // 
            this.sbtnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.sbtnSave.Location = new System.Drawing.Point(198, 284);
            this.sbtnSave.Name = "sbtnSave";
            this.sbtnSave.Size = new System.Drawing.Size(72, 20);
            this.sbtnSave.TabIndex = 5;
            this.sbtnSave.Text = "Save";
            this.sbtnSave.Click += new System.EventHandler(this.sbtnSave_Click);
            // 
            // timeedtEnd
            // 
            this.timeedtEnd.EditValue = new System.DateTime(2006, 3, 19, 0, 0, 0, 0);
            this.timeedtEnd.Location = new System.Drawing.Point(118, 46);
            this.timeedtEnd.Name = "timeedtEnd";
            this.timeedtEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.timeedtEnd.Properties.Mask.EditMask = "hh:mm tt";
            this.timeedtEnd.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
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
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.TabIndex = 29;
            this.label4.Text = "Date";
            // 
            // timeedtStart
            // 
            this.timeedtStart.EditValue = new System.DateTime(2006, 3, 19, 0, 0, 0, 0);
            this.timeedtStart.Location = new System.Drawing.Point(118, 20);
            this.timeedtStart.Name = "timeedtStart";
            this.timeedtStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.timeedtStart.Properties.Mask.EditMask = "hh:mm tt";
            this.timeedtStart.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.timeedtStart.Size = new System.Drawing.Size(88, 20);
            this.timeedtStart.TabIndex = 0;
            // 
            // groupctrTime
            // 
            this.groupctrTime.Controls.Add(this.timeedtEnd);
            this.groupctrTime.Controls.Add(this.label2);
            this.groupctrTime.Controls.Add(this.timeedtStart);
            this.groupctrTime.Controls.Add(this.label1);
            this.groupctrTime.Location = new System.Drawing.Point(6, 62);
            this.groupctrTime.Name = "groupctrTime";
            this.groupctrTime.Size = new System.Drawing.Size(348, 72);
            this.groupctrTime.TabIndex = 3;
            this.groupctrTime.Text = "Time Off";
            // 
            // chkedtIsHalfDay
            // 
            this.chkedtIsHalfDay.EditValue = true;
            this.chkedtIsHalfDay.Location = new System.Drawing.Point(12, 62);
            this.chkedtIsHalfDay.Name = "chkedtIsHalfDay";
            this.chkedtIsHalfDay.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.chkedtIsHalfDay.Properties.Appearance.Options.UseBackColor = true;
            this.chkedtIsHalfDay.Properties.Caption = "Half Day Leave";
            this.chkedtIsHalfDay.Size = new System.Drawing.Size(110, 19);
            this.chkedtIsHalfDay.TabIndex = 2;
            this.chkedtIsHalfDay.CheckedChanged += new System.EventHandler(this.chkedtIsHalfDay_CheckedChanged);
            // 
            // frmLeave
            // 
            this.AcceptButton = this.sbtnSave;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.CancelButton = this.sbtnCancel;
            this.ClientSize = new System.Drawing.Size(358, 312);
            this.Controls.Add(this.chkedtIsHalfDay);
            this.Controls.Add(this.groupctrTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.sbtnCancel);
            this.Controls.Add(this.sbtnSave);
            this.Controls.Add(this.memoedtReason);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateedtDate);
            this.Controls.Add(this.luedtLeaveType);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLeave";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Apply New Leave";
            ((System.ComponentModel.ISupportInitialize)(this.luedtLeaveType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateedtDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateedtDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoedtReason.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeedtEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeedtStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupctrTime)).EndInit();
            this.groupctrTime.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkedtIsHalfDay.Properties)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void sbtnSave_Click(object sender, System.EventArgs e)
		{
			if (luedtLeaveType.EditValue == null || luedtLeaveType.EditValue.ToString().Length == 0)
			{
				UI.ShowErrorMessage("Please select a Leave Code.");
				luedtLeaveType.Focus();
				DialogResult = DialogResult.None;
				return;
			}
			if (dateedtDate.EditValue == null)
			{
				UI.ShowErrorMessage("Please select a date.");
				dateedtDate.Focus();
				DialogResult = DialogResult.None;
				return;
			}
			if (memoedtReason.EditValue.ToString().Length == 0)
			{
				UI.ShowErrorMessage("Please provide a reason.");
				memoedtReason.Focus();
				DialogResult = DialogResult.None;
				return;
			}
			if (timeedtStart.Time > timeedtEnd.Time)
			{
				UI.ShowErrorMessage("Please select a correct time range.");
				timeedtStart.Focus();
				DialogResult = DialogResult.None;
				return;
			}

			if (dateedtDate.DateTime < DateTime.Now.AddMonths(-3))
			{
				UI.ShowErrorMessage("! You can apply maximum three months pass from today only.");
				dateedtDate.Focus();
				DialogResult = DialogResult.None;
				return;
			}

			if (string.Compare(luedtLeaveType.EditValue.ToString(), "OFF", true) == 0)
			{
				DateTime startTime = dateedtDate.DateTime.AddHours(timeedtStart.Time.Hour).AddMinutes(timeedtStart.Time.Minute);
				DateTime endTime = dateedtDate.DateTime.AddHours(timeedtEnd.Time.Hour).AddMinutes(timeedtEnd.Time.Minute);

				TimeSpan span = endTime - startTime;

				if (span.TotalHours > 5.0)
				{
					UI.ShowErrorMessage(this, "You are allow to apply maximum 5 hours time off per day only.");
					timeedtStart.Focus();
					DialogResult = DialogResult.None;
					return;
				}
				else if (span.TotalHours <= 0.0)
				{
					UI.ShowErrorMessage(this, "Please select a correct time off range.");
					timeedtStart.Focus();
					DialogResult = DialogResult.None;
					return;
				}
			}
			else
			{
				if (chkedtIsHalfDay.Checked)
				{
					TimeSpan span = dateedtDate.DateTime.AddHours(timeedtEnd.Time.Hour).AddMinutes(timeedtEnd.Time.Minute) -
						dateedtDate.DateTime.AddHours(timeedtStart.Time.Hour).AddMinutes(timeedtStart.Time.Minute);

					if (span.TotalHours > 5.0)
					{
						UI.ShowErrorMessage(this, "You are allow to apply maximum 5 hours half day leave only.");
						timeedtStart.Focus();
						DialogResult = DialogResult.None;
						return;
					}
					else if (span.TotalHours <= 0.0)
					{
						UI.ShowErrorMessage(this, "Please select a correct time off range.");
						timeedtStart.Focus();
						DialogResult = DialogResult.None;
						return;
					}
				}
			}

			DateTime startDate, endDate;
			if (string.Compare(luedtLeaveType.EditValue.ToString(), "OFF", true) == 0)
			{
				startDate = dateedtDate.DateTime.AddHours(timeedtStart.Time.Hour).AddMinutes(timeedtStart.Time.Minute);
				endDate = dateedtDate.DateTime.AddHours(timeedtEnd.Time.Hour).AddMinutes(timeedtEnd.Time.Minute);
			}
			else
			{
				if (chkedtIsHalfDay.Checked)
				{
					startDate = dateedtDate.DateTime.AddHours(timeedtStart.Time.Hour).AddMinutes(timeedtStart.Time.Minute);
					endDate = dateedtDate.DateTime.AddHours(timeedtEnd.Time.Hour).AddMinutes(timeedtEnd.Time.Minute);
				}
				else
				{
					startDate = dateedtDate.DateTime;
					endDate = dateedtDate.DateTime;
				}
			}

            if (string.Compare(luedtLeaveType.EditValue.ToString(), "PH", true) == 0)
            {
                if (myLeave.ValidatePH(nEmployeeID, startDate) == false)
                {
                    MessageBox.Show("Please Apply Public Holiday Claim, Balance is Zero");
                    return;
                }
            }

			if (string.Compare(luedtLeaveType.EditValue.ToString(), "AL", true) == 0)
			{
				if (nLeaveID < 0)
				{
					myLeave.ApplyAnnualLeave(nEmployeeID, "AL", memoedtReason.EditValue.ToString(), !chkedtIsHalfDay.Checked, 
						startDate, endDate);
				}
				else
				{
					myLeave.UpdateAnnualLeave(nLeaveID, nEmployeeID, "AL", memoedtReason.EditValue.ToString(), 
						!chkedtIsHalfDay.Checked, startDate, endDate);
				}
			}
			else if (string.Compare(luedtLeaveType.EditValue.ToString(), "OFF", true) == 0)
			{
				try
				{
					if (nLeaveID < 0)
					{
						myLeave.ApplyTimeOff(nEmployeeID, memoedtReason.EditValue.ToString(), myEmployeeInfo, startDate, endDate);
					}
					else
					{
						myLeave.UpdateTimeOff(nLeaveID, nEmployeeID, memoedtReason.EditValue.ToString(), myEmployeeInfo, startDate, 
							endDate);
					}
				}
				catch (Exception ex)
				{
					if (ex.Message == "Not enough time off balance.")
						UI.ShowErrorMessage(this, ex.Message);
					else
						throw;
				}
			}
			else
			{
				try
				{
					if (nLeaveID < 0)
					{
						myLeave.ApplyMiscLeave(nEmployeeID, myEmployeeInfo, luedtLeaveType.EditValue.ToString(), 
							memoedtReason.EditValue.ToString(), !chkedtIsHalfDay.Checked, startDate, endDate, true);
					}
					else
					{
						myLeave.UpdateMiscLeave(nLeaveID, nEmployeeID, myEmployeeInfo, luedtLeaveType.EditValue.ToString(), 
							memoedtReason.EditValue.ToString(), !chkedtIsHalfDay.Checked, startDate, endDate, true);
					}
				}
				catch (Exception ex)
				{
					
					if (ex.Message == "Not enough Misc Balance" && luedtLeaveType.EditValue.ToString()=="ML")
					{
						if (UI.ShowYesNoMessage(this, ex.Message +" Take Unpaid Medical Leave?"))
						{
							if (nLeaveID < 0)
							{
								myLeave.ApplyMiscLeave(nEmployeeID, myEmployeeInfo, luedtLeaveType.EditValue.ToString(), 
									memoedtReason.EditValue.ToString(), !chkedtIsHalfDay.Checked, startDate, endDate, false);
							}
							else
							{
								myLeave.UpdateMiscLeave(nLeaveID, nEmployeeID, myEmployeeInfo, luedtLeaveType.EditValue.ToString(), 
									memoedtReason.EditValue.ToString(), !chkedtIsHalfDay.Checked, startDate, endDate, false);
							}
						}
					}
					else if (ex.Message == "Not enough Misc Balance" )
					{
						UI.ShowMessage("No more balance for this Leave Type.");
						return;
					}
					
					else
						return;
				}
			}
		}

		private void luedtLeaveType_EditValueChanged(object sender, System.EventArgs e)
		{
			if (luedtLeaveType.EditValue != null && 
				string.Compare(luedtLeaveType.EditValue.ToString(), "OFF", true) == 0)
			{
				chkedtIsHalfDay.Visible = false;
				chkedtIsHalfDay.Checked = true;
				groupctrTime.Enabled = true;
			}
			else if (luedtLeaveType.EditValue.ToString() == "ML" ||luedtLeaveType.EditValue.ToString() == "HPL" )
			{
				chkedtIsHalfDay.Visible = false;
				chkedtIsHalfDay.Checked = false;
				groupctrTime.Enabled = false;
			}		

			else
			{
				chkedtIsHalfDay.Visible = true;
				chkedtIsHalfDay.Checked = false;
				groupctrTime.Enabled = false;
			}
		}

		private void chkedtIsHalfDay_CheckedChanged(object sender, System.EventArgs e)
		{
			if (chkedtIsHalfDay.Checked)
				groupctrTime.Enabled = true;
			else
				groupctrTime.Enabled = false;
		}
	}
}

