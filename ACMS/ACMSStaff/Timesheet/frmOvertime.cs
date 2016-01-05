using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Do = Acms.Core.Domain;
using ACMS.Utils;
using ACMSLogic;

namespace ACMS.ACMSStaff.Timesheet
{
	/// <summary>
	/// Summary description for frmOvertime.
	/// </summary>
	public class frmOvertime : System.Windows.Forms.Form
	{
		private Do.Employee employee;
		private DataRow rEmployeeInfo;
		private ACMSLogic.Staff.Timesheet timesheet;
		private DevExpress.XtraEditors.DateEdit dateedtDate;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label5;
		private DevExpress.XtraEditors.TextEdit txtReason;
		private DevExpress.XtraEditors.SimpleButton sbtnSave;
		private DevExpress.XtraEditors.SimpleButton sbtnCancel;
		private DevExpress.XtraEditors.TimeEdit timeedtStartTime;
		private DevExpress.XtraEditors.TimeEdit timeedtEndTime;
        private CheckBox chkPH;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmOvertime(Do.Employee employee, ACMSLogic.Staff.Timesheet timesheet, DataRow aEmployeeInfo)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			ACMS.XtraUtils.XtraEditors.SetDateEditFormat(this.Controls);
			this.employee = employee;
			this.timesheet = timesheet;
			this.rEmployeeInfo = aEmployeeInfo;
			dateedtDate.DateTime = DateTime.Now;
			//new XtraUtils.LookupEditBuilder.EmployeeIDLookupEditBuilder(luedtApprovingManager.Properties, true);
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
            this.dateedtDate = new DevExpress.XtraEditors.DateEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtReason = new DevExpress.XtraEditors.TextEdit();
            this.sbtnSave = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.timeedtStartTime = new DevExpress.XtraEditors.TimeEdit();
            this.timeedtEndTime = new DevExpress.XtraEditors.TimeEdit();
            this.chkPH = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dateedtDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateedtDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReason.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeedtStartTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeedtEndTime.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dateedtDate
            // 
            this.dateedtDate.EditValue = new System.DateTime(2006, 1, 28, 0, 0, 0, 0);
            this.dateedtDate.Location = new System.Drawing.Point(82, 8);
            this.dateedtDate.Name = "dateedtDate";
            this.dateedtDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateedtDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dateedtDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateedtDate.Size = new System.Drawing.Size(152, 20);
            this.dateedtDate.TabIndex = 0;
            this.dateedtDate.EditValueChanged += new System.EventHandler(this.dateedtDate_EditValueChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 18);
            this.label3.TabIndex = 39;
            this.label3.Text = "End time:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 18);
            this.label2.TabIndex = 38;
            this.label2.Text = "Start time:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 18);
            this.label1.TabIndex = 37;
            this.label1.Text = "Date:";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 18);
            this.label5.TabIndex = 46;
            this.label5.Text = "Reason:";
            // 
            // txtReason
            // 
            this.txtReason.EditValue = "";
            this.txtReason.Location = new System.Drawing.Point(82, 92);
            this.txtReason.Name = "txtReason";
            this.txtReason.Properties.MaxLength = 50;
            this.txtReason.Size = new System.Drawing.Size(314, 20);
            this.txtReason.TabIndex = 3;
            // 
            // sbtnSave
            // 
            this.sbtnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.sbtnSave.Location = new System.Drawing.Point(240, 118);
            this.sbtnSave.Name = "sbtnSave";
            this.sbtnSave.Size = new System.Drawing.Size(75, 23);
            this.sbtnSave.TabIndex = 4;
            this.sbtnSave.Text = "Save";
            this.sbtnSave.Click += new System.EventHandler(this.sbtnSave_Click);
            // 
            // sbtnCancel
            // 
            this.sbtnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.sbtnCancel.Location = new System.Drawing.Point(322, 118);
            this.sbtnCancel.Name = "sbtnCancel";
            this.sbtnCancel.Size = new System.Drawing.Size(75, 23);
            this.sbtnCancel.TabIndex = 5;
            this.sbtnCancel.Text = "Cancel";
            this.sbtnCancel.Click += new System.EventHandler(this.sbtnCancel_Click);
            // 
            // timeedtStartTime
            // 
            this.timeedtStartTime.EditValue = new System.DateTime(2006, 4, 11, 0, 0, 0, 0);
            this.timeedtStartTime.Location = new System.Drawing.Point(82, 36);
            this.timeedtStartTime.Name = "timeedtStartTime";
            this.timeedtStartTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.timeedtStartTime.Properties.Mask.EditMask = "hh:mm tt";
            this.timeedtStartTime.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.timeedtStartTime.Size = new System.Drawing.Size(100, 20);
            this.timeedtStartTime.TabIndex = 1;
            // 
            // timeedtEndTime
            // 
            this.timeedtEndTime.EditValue = new System.DateTime(2006, 4, 11, 0, 0, 0, 0);
            this.timeedtEndTime.Location = new System.Drawing.Point(82, 64);
            this.timeedtEndTime.Name = "timeedtEndTime";
            this.timeedtEndTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.timeedtEndTime.Properties.Mask.EditMask = "hh:mm tt";
            this.timeedtEndTime.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.timeedtEndTime.Size = new System.Drawing.Size(100, 20);
            this.timeedtEndTime.TabIndex = 2;
            // 
            // chkPH
            // 
            this.chkPH.AutoSize = true;
            this.chkPH.Location = new System.Drawing.Point(266, 11);
            this.chkPH.Name = "chkPH";
            this.chkPH.Size = new System.Drawing.Size(93, 17);
            this.chkPH.TabIndex = 47;
            this.chkPH.Text = "Public Holiday";
            this.chkPH.UseVisualStyleBackColor = true;
            this.chkPH.CheckedChanged += new System.EventHandler(this.chkPH_CheckedChanged);
            // 
            // frmOvertime
            // 
            this.AcceptButton = this.sbtnSave;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.sbtnCancel;
            this.ClientSize = new System.Drawing.Size(402, 146);
            this.Controls.Add(this.chkPH);
            this.Controls.Add(this.timeedtEndTime);
            this.Controls.Add(this.timeedtStartTime);
            this.Controls.Add(this.sbtnSave);
            this.Controls.Add(this.sbtnCancel);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateedtDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOvertime";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Apply Overtime";
            ((System.ComponentModel.ISupportInitialize)(this.dateedtDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateedtDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReason.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeedtStartTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeedtEndTime.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void sbtnSave_Click(object sender, System.EventArgs e)
		{
            if (chkPH.Checked == false)
            {
                if (txtReason.EditValue.ToString().Length == 0)
                {
                    UI.ShowErrorMessage("Please enter a reason.");
                    txtReason.Focus();
                    DialogResult = DialogResult.None;
                    return;
                }

                TimeSpan spanCheck = timeedtEndTime.Time - timeedtStartTime.Time;
                if (spanCheck.TotalHours <= 0.1 || spanCheck.TotalHours > 23.59)
                {
                    UI.ShowErrorMessage("Please specify correct start time and end time range.");
                    timeedtStartTime.Focus();
                    DialogResult = DialogResult.None;
                    return;
                }

                TimeSpan span = timeedtEndTime.Time - timeedtStartTime.Time;
                timesheet.ApplyOvertime(employee.Id, dateedtDate.DateTime, timeedtStartTime.Time, timeedtEndTime.Time,
                    span.TotalHours, txtReason.Text);
                DialogResult = DialogResult.OK;
            }
            else
            {
                timesheet.ApplyPH(employee.Id, dateedtDate.DateTime,txtReason.Text);
                DialogResult = DialogResult.OK;
            }
		}

		private void sbtnCancel_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private void dateedtDate_EditValueChanged(object sender, System.EventArgs e)
		{
			timeedtStartTime.Time = dateedtDate.DateTime.Date;
			timeedtEndTime.Time = dateedtDate.DateTime.Date;
		}

        private void chkPH_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPH.Checked)
            {
                //dateedtDate.Enabled = false;
                timeedtStartTime.Enabled = false;
                timeedtEndTime.Enabled = false;
                
            }
        }
	}
}
