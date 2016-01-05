using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraScheduler;
using ACMSDAL;
using DevExpress.XtraScheduler.UI;


namespace ACMS.ACMSStaff.To_Do_List
{
    public partial class MyCustomEditForm : DevExpress.XtraEditors.XtraForm
    {
        // The current appointment to be edited in a form.
        private DevExpress.XtraScheduler.Appointment apt = new DevExpress.XtraScheduler.Appointment();
        SchedulerControl control;       
        bool openRecurrenceForm = false;
        int suspendUpdateCount;
        //private DevExpress.XtraEditors.CheckEdit checkAllDay;


        // Note that the MyAppointmentFormController class is inherited from
        // the AppointmentFormController one to add custom properties.
        // See its declaration at the end of this file.
        MyAppointmentFormController controller;
        protected bool IsUpdateSuspended { get { return suspendUpdateCount > 0; } }

        // Set the current appointment.
        public void SetAppointment(DevExpress.XtraScheduler.Appointment newApt)
        {
            apt = newApt;
        }

        public MyCustomEditForm(SchedulerControl control, DevExpress.XtraScheduler.Appointment apt, bool openRecurrenceForm)
        {
            this.openRecurrenceForm = openRecurrenceForm;
            this.controller = new MyAppointmentFormController(control, apt);
            this.apt = apt;
            this.control = control;
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            UpdateForm();


            //
            // TODO: Add any constructor code after InitializeComponent call
            //

        }


        private void MyCustomEditForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'aCMSDataSet.TblDeliverySchedule' table. You can move, or remove it, as needed.
            this.tblDeliveryScheduleTableAdapter.Fill(this.aCMSDataSet.TblDeliverySchedule);

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            TblSchedule tableSchedule = new TblSchedule();
            tableSchedule.Insert(1, 1, 1, System.Convert.ToDateTime("01/02/2008"), System.Convert.ToDateTime("02/02/2008"));
            tblDeliveryScheduleTableAdapter.Update(aCMSDataSet);
            aCMSDataSet.AcceptChanges();

            tblDeliveryScheduleTableAdapter.Fill(aCMSDataSet.TblDeliverySchedule);
        }
        bool IsIntervalValid()
        {
            DateTime start = dtStart.DateTime + timeStart.Time.TimeOfDay;
            DateTime end = dtEnd.DateTime + timeEnd.Time.TimeOfDay;
            return end >= start;
        }
        protected AppointmentStorage Appointments
        {
            get { return control.Storage.Appointments; }
        }
        private void checkAllDay_CheckedChanged(object sender, System.EventArgs e)
        {
            controller.AllDay = this.checkAllDay.Checked;
            if (!IsUpdateSuspended)
                UpdateAppointmentStatus();

            UpdateIntervalControls();
        }
        void UpdateAppointmentStatus()
        {
            AppointmentStatus currentStatus = edStatus.Status;
            AppointmentStatus newStatus = controller.UpdateAppointmentStatus(currentStatus);
            if (newStatus != currentStatus)
                edStatus.Status = newStatus;
        }
        protected void SuspendUpdate()
        {
            suspendUpdateCount++;
        }
        protected void ResumeUpdate()
        {
            if (suspendUpdateCount > 0)
                suspendUpdateCount--;
        }
        protected virtual void UpdateIntervalControls()
        {
            if (IsUpdateSuspended)
                return;

            SuspendUpdate();
            try
            {
                dtStart.EditValue = controller.StartDate;
                dtEnd.EditValue = controller.EndDate;
                timeStart.EditValue = controller.StartTime;
                timeEnd.EditValue = controller.EndTime;

                dtStart.Enabled = !controller.AllDay;
                dtEnd.Enabled = !controller.AllDay;
                timeStart.Enabled = !controller.AllDay;
                timeEnd.Enabled = !controller.AllDay;

            }
            finally
            {
                ResumeUpdate();
            }
        }
        void UpdateForm()
        {
            SuspendUpdate();
            try
            {
                txSubject.Text = controller.Subject;
                edStatus.Status = Appointments.Statuses[controller.StatusId];
                edLabel.Label = Appointments.Labels[controller.LabelId];

                dtStart.DateTime = controller.StartDate;
                dtEnd.DateTime = controller.EndDate;

                timeStart.Time = DateTime.MinValue.AddTicks(controller.StartTime.Ticks);
                timeEnd.Time = DateTime.MinValue.AddTicks(controller.EndTime.Ticks);
                checkAllDay.Checked = controller.AllDay;

                edStatus.Storage = control.Storage;
                edLabel.Storage = control.Storage;

                txCustomName.Text = controller.strSO;
                txCustomStatus.Text = controller.strEmployeeID;
            }
            finally
            {
                ResumeUpdate();
            }
            UpdateIntervalControls();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!controller.IsConflictResolved())
                return;

            controller.Subject = txSubject.Text;
            controller.SetStatus(edStatus.Status);
            controller.SetLabel(edLabel.Label);
            controller.AllDay = this.checkAllDay.Checked;
            controller.StartDate = this.dtStart.DateTime.Date;
            controller.StartTime = this.timeStart.Time.TimeOfDay;
            controller.EndDate = this.dtEnd.DateTime.Date;
            controller.EndTime= this.timeEnd.Time.TimeOfDay;
            controller.strSO = txCustomName.Text;
            controller.strEmployeeID = txCustomStatus.Text;

            // Save all changes made to the appointment edited in a form.
            controller.ApplyChanges();
        }

        private void timeStart_EditValueChanged(object sender, EventArgs e)
        {
            if (!IsUpdateSuspended)
                controller.StartTime = timeStart.Time.TimeOfDay;
            UpdateIntervalControls();
        }

        private void dtEnd_EditValueChanged(object sender, EventArgs e)
        {
            if (IsUpdateSuspended) return;
            if (IsIntervalValid())
                controller.EndDate = dtEnd.DateTime;
            else
                dtEnd.EditValue = controller.EndDate;
        }

        private void dtStart_EditValueChanged(object sender, EventArgs e)
        {
            if (!IsUpdateSuspended)
                controller.StartDate = dtStart.DateTime;
            UpdateIntervalControls();
        }

        private void txCustomStatus_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txCustomName_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void lblCustomStatus_Click(object sender, EventArgs e)
        {

        }

        private void lblCustomName_Click(object sender, EventArgs e)
        {

        }

        private void lblEnd_Click(object sender, EventArgs e)
        {

        }

        private void lblStart_Click(object sender, EventArgs e)
        {

        }

        private void lblLabel_Click(object sender, EventArgs e)
        {

        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void edStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void edLabel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txSubject_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void lblSubject_Click(object sender, EventArgs e)
        {

        }

        private void btnReccurrence_Click(object sender, EventArgs e)
        {
            OnRecurrenceButton();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void timeEnd_EditValueChanged(object sender, EventArgs e)
        {
            if (IsUpdateSuspended) return;
            if (IsIntervalValid())
                controller.EndTime = timeEnd.Time.TimeOfDay;
            else
                timeEnd.EditValue = controller.EndTime;
        }
        void OnRecurrenceButton()
        {
            ShowRecurrenceForm();
        }

        void ShowRecurrenceForm()
        {

            if (!control.SupportsRecurrence)
                return;

            // Prepare to edit appointment's recurrence.
            DevExpress.XtraScheduler.Appointment editedAptCopy = controller.EditedAppointmentCopy;
            DevExpress.XtraScheduler.Appointment editedPattern = controller.EditedPattern;
            DevExpress.XtraScheduler.Appointment patternCopy = controller.PrepareToRecurrenceEdit();

            AppointmentRecurrenceForm dlg = new AppointmentRecurrenceForm(patternCopy, control.OptionsView.FirstDayOfWeek);

            // Required for skins support.
            dlg.LookAndFeel.ParentLookAndFeel = this.LookAndFeel.ParentLookAndFeel;

            DialogResult result = dlg.ShowDialog(this);
            dlg.Dispose();

            if (result == DialogResult.Abort)
                controller.RemoveRecurrence();
            else
                if (result == DialogResult.OK)
                {
                    controller.ApplyRecurrence(patternCopy);
                    if (controller.EditedAppointmentCopy != editedAptCopy)
                        UpdateForm();
                }
            UpdateIntervalControls();
        }
        private void checkAllDay_CheckedChanged_1(object sender, EventArgs e)
        {
            controller.AllDay = this.checkAllDay.Checked;
            if (!IsUpdateSuspended)
                UpdateAppointmentStatus();

            UpdateIntervalControls();
        }

        private void MyCustomEditForm_Activated(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmVideoPlayer frmPlayer = new frmVideoPlayer();
            frmPlayer.Show();
        }
    }
    public class MyAppointmentFormController : AppointmentFormController {

        public string strSO { get { return (String)EditedAppointmentCopy.CustomFields["strSO"]; } set { EditedAppointmentCopy.CustomFields["strSO"] = value; } }
        public string strEmployeeID { get { return (String)EditedAppointmentCopy.CustomFields["strEmployeeID"]; } set { EditedAppointmentCopy.CustomFields["strEmployeeID"] = value; } }

        string SourcestrSO { get { return (String)SourceAppointment.CustomFields["strSO"]; } set { SourceAppointment.CustomFields["strSO"] = value; } }
        string SourcestrEmployeeID { get { return (String)SourceAppointment.CustomFields["strEmployeeID"]; } set { SourceAppointment.CustomFields["strEmployeeID"] = value; } }

        public MyAppointmentFormController(SchedulerControl control, DevExpress.XtraScheduler.Appointment apt)
            : base(control, apt)
        {
		}

		public override bool IsAppointmentChanged() {
			if(base.IsAppointmentChanged())
				return true;
            return SourcestrSO != strSO ||
                SourcestrEmployeeID != strEmployeeID;
		}

		protected override void ApplyCustomFieldsValues() {
            SourcestrSO = strSO;
            SourcestrEmployeeID = strEmployeeID;
		}
	}

}