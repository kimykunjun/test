using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using System.Data;
using DevExpress.XtraScheduler.Forms;
using System.IO;
using Do = Acms.Core.Domain;


namespace DevExpress.XtraScheduler.Demos {
	public partial class DateNavigatorModule : DevExpress.XtraScheduler.Demos.TutorialControl {
        private int nEmployee,nDepartment;
        private string strHP;
        private Do.Employee employee;
        private DataRow myEmployeeInfo;
       
		public DateNavigatorModule(int nDepartmentID, int nEmployeeID,string strMobileNo) {
			// This call is required by the Windows Form Designer.
			InitializeComponent();
            nEmployee = nEmployeeID;
            nDepartment = nDepartmentID;
            //strHP = strMobileNo;
			// TODO: Add any initialization after the InitializeComponent call
		}


		public override SchedulerControl PrintingSchedulerControl { get { return schedulerControl; } }

		private void MonthViewModule_Load(object sender, System.EventArgs e) {
            
			chkBoldAppointmentDates.Checked = dateNavigator1.BoldAppointmentDates;
			chkShowTodayButton.Checked = dateNavigator1.ShowTodayButton;
			chkShowWeekNumbers.Checked = dateNavigator1.ShowWeekNumbers;
			cbWeekNumberRule.EditValue = dateNavigator1.WeekNumberRule;
            schedulerControl.Start = DateTime.Today;
			//DemoUtils.FillData(schedulerControl);
            //ACMS.ACMSDataSet.TblDeliveryScheduleDataTable tblSchedule = new ACMS.ACMSDataSet.TblDeliveryScheduleDataTable();
            tblDeliveryScheduleTableAdapter.Fill(this.acmsDataSet1.TblDeliverySchedule, nDepartment);
            schedulerStorage1.RemindersCheckInterval = 3000;           
            schedulerStorage1.ReminderAlert += new ReminderEventHandler(OnReminderAlert);

		}

        private void OnReminderAlert(object sender, ReminderEventArgs e)
        {
             //Add your custom action here. For example, show the Reminders form:    
            myEmployeeInfo = ACMSLogic.Staff.Ultis.EmployeeInfo(System.Convert.ToInt32(e.AlertNotifications[0].ActualAppointment.CustomFields["nEmployeeID"]));
            strHP = myEmployeeInfo["strContactNo"].ToString();
            string strSubject = e.AlertNotifications[0].ActualAppointment.Subject.ToString();          
            StreamWriter SW;
            SW = File.CreateText(@"\\192.168.0.121\c$\Program Files\V-SMS Lite Edition\V-CharonLite\COW\out_going\MyTextFile.txt");
            //SW = File.CreateText(@"C:\MyTextFile.txt");
            SW.WriteLine(strHP + "\t" + strSubject);  
            SW.Close();
            
            RemindersForm form = new RemindersForm((SchedulerStorage)sender);
            form.OnReminderAlert(e);
        }

        private Appointment CreateAppointmentWithReminder()
        {
            // Create a new appointment and set its properties.
            
            Appointment app = new Appointment(DateTime.Today, TimeSpan.FromHours(1));
            app.Subject = "Test appointment";
            app.HasReminder = true;

            return app;
        }

		private void DateNavigatorModule_VisibleChanged(object sender, System.EventArgs e) {
			if (Visible) UpdateCaption();
		}
		void UpdateCaption() {
			//Caption.Text = String.Format("{0}: {1}", "Date", "Type");
		}

		private void chkBoldAppointmentDates_CheckedChanged(object sender, System.EventArgs e) {
			dateNavigator1.BoldAppointmentDates = chkBoldAppointmentDates.Checked;
		}

		private void chkShowTodayButton_CheckedChanged(object sender, System.EventArgs e) {
			dateNavigator1.ShowTodayButton = chkShowTodayButton.Checked;
		}

		private void chkShowWeekNumbers_CheckedChanged(object sender, System.EventArgs e) {
			dateNavigator1.ShowWeekNumbers = chkShowWeekNumbers.Checked;
		}

		private void schedulerControl_ActiveViewChanged(object sender, System.EventArgs e) {
			UpdateCaption();
		}

		private void cbWeekNumberRule_SelectedIndexChanged(object sender, System.EventArgs e) {
			dateNavigator1.WeekNumberRule = (WeekNumberRule)cbWeekNumberRule.EditValue;
		}

        private void schedulerStorage_AppointmentsChanged(object sender, PersistentObjectsEventArgs e)
        {
            tblDeliveryScheduleTableAdapter.Update(acmsDataSet1);
            acmsDataSet1.AcceptChanges();
            
            tblDeliveryScheduleTableAdapter.Fill(this.acmsDataSet1.TblDeliverySchedule, nDepartment);
            
            //tblDeliveryScheduleTableAdapter.Fill(this.acmsDataSet1.TblDeliverySchedule, nDepartment);
        }

        private void schedulerControl_EditAppointmentFormShowing(object sender, AppointmentFormEventArgs e)
        {
            
            // Create a CustomEdit form.
            Appointment apt = e.Appointment;
            // Required to open the recurrence form via context menu.
            bool openRecurrenceForm = apt.IsRecurring && schedulerStorage1.Appointments.IsNewAppointment(apt);
            ACMS.ACMSStaff.To_Do_List.MyCustomEditForm f = new ACMS.ACMSStaff.To_Do_List.MyCustomEditForm((SchedulerControl)sender, apt, openRecurrenceForm, nDepartment, nEmployee);

            // Set the current appointment as an appointment of the CustomEdit form.
            f.SetAppointment(e.Appointment);
            string a = f.controller.Subject.ToString();
            // Show the form modally.
            f.ShowDialog();

            // Return the dialog result.
            e.DialogResult = f.DialogResult;

            // Do this to prevent the standard form from being shown.
            e.Handled = true;
            tblDeliveryScheduleTableAdapter.Fill(acmsDataSet1.TblDeliverySchedule, nDepartment);
            

        }

	}
}
