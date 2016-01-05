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
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;
using Email = Microsoft.Office.Interop.Outlook;
using DevExpress.XtraGrid.Views.Grid;

namespace ACMS.ACMSStaff.To_Do_List
{
    public partial class MyCustomEditForm : DevExpress.XtraEditors.XtraForm
    {
        // The current appointment to be edited in a form.
        private DevExpress.XtraScheduler.Appointment apt = new DevExpress.XtraScheduler.Appointment();
        SchedulerControl control;       
        bool openRecurrenceForm = false, fNew = false;
        int suspendUpdateCount, nDepartment, nEmp;
        private string strType;
        private int nUni;
        private int npointer = 0;
        private string strChild;
        //private DevExpress.XtraEditors.CheckEdit checkAllDay;

        
        public MyAppointmentFormController controller;
        protected bool IsUpdateSuspended { get { return suspendUpdateCount > 0; } }

        // Set the current appointment.
        public void SetAppointment(DevExpress.XtraScheduler.Appointment newApt)
        {
            apt = newApt;
        }

        public MyCustomEditForm(SchedulerControl control, DevExpress.XtraScheduler.Appointment apt, bool openRecurrenceForm, int nDepartmentID,int nEmployee)
        {
            this.openRecurrenceForm = openRecurrenceForm;
            this.controller = new MyAppointmentFormController(control, apt);
            this.apt = apt;
            this.control = control;
            nDepartment = nDepartmentID;
            nEmp = nEmployee;
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            //this.tblDeliveryScheduleTableAdapter.Fill(this.aCMSDataSet.TblDeliverySchedule, nDepartment);
            UpdateForm();


            //
            // TODO: Add any constructor code after InitializeComponent call
            //

        }


        private void MyCustomEditForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsEmployee.tblEmployee' table. You can move, or remove it, as needed.            
            // TODO: This line of code loads data into the 'aCMSDataSet5.tblAttachment' table. You can move, or remove it, as needed.
            this.aCMSDataSet5.EnforceConstraints = false;
            this.tblAttachmentTableAdapter.Fill(this.aCMSDataSet5.tblAttachment,nUni);
            if (cmbSubject.Text == String.Empty)
            {
                cmbSubject.Text = "=Select One=";
                //this.cmbSubject.Items.Add(new object[] { "=Select=" });
                //this.cmbSubject.Items.Add("=Select=");

            }
            //this.tblWorkFlowTableAdapter.FillBy(this.dsSubject.tblWorkFlow, nDepartment);
            this.tblDeliveryScheduleTableAdapter.Fill(this.aCMSDataSet.TblDeliverySchedule, nDepartment);
            this.tblEmployeeTableAdapter.Fill(this.dsEmployee.tblEmployee, nDepartment);
            if(lkeEmployee.EditValue.ToString() == "0")
            lkeEmployee.EditValue = nEmp;
            // TODO: This line of code loads data into the 'aCMSDataSet2.tblWorkFlow' table. You can move, or remove it, as needed.
            
            
            
          
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            TblSchedule tableSchedule = new TblSchedule();
            tableSchedule.Insert(1, 1, 1, System.Convert.ToDateTime("01/02/2008"), System.Convert.ToDateTime("02/02/2008"));
            tblDeliveryScheduleTableAdapter.Update(aCMSDataSet);
            aCMSDataSet.AcceptChanges();
           
            tblDeliveryScheduleTableAdapter.Fill(aCMSDataSet.TblDeliverySchedule, nDepartment);
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
            AppointmentStatus currentStatus = edLabel.Status;
            AppointmentStatus newStatus = controller.UpdateAppointmentStatus(currentStatus);
            if (newStatus != currentStatus)
                edLabel.Status = newStatus;
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

                //dtStart.Enabled = !controller.AllDay;
                //dtEnd.Enabled = !controller.AllDay;
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
                //int nUni = controller.nUnique
                cmbSubject.Text = controller.Subject;

                edLabel.Status = Appointments.Statuses[controller.StatusId];
                edStatus.Label = Appointments.Labels[controller.LabelId];

                dtStart.DateTime = controller.StartDate;
                dtEnd.DateTime = controller.EndDate;

                timeStart.Time = DateTime.MinValue.AddTicks(controller.StartTime.Ticks);
                timeEnd.Time = DateTime.MinValue.AddTicks(controller.EndTime.Ticks);
                checkAllDay.Checked = controller.AllDay;

                edLabel.Storage = control.Storage;
                edStatus.Storage = control.Storage;
                checkCampaign.Checked = controller.fCampaign;
                txtDetail.Text = controller.strDetail;
                //txCustomStatus.Text = controller.strEmployeeID;
                if (controller.nUnique == 0)
                {
                    controller.nUnique = System.Convert.ToInt32(tblDeliveryScheduleTableAdapter.GetUniqueID()) + 1;
                    checkAllDay.Checked = true;
                    checkCampaign.Checked = false;
                    fNew = true;
                    edStatus.SelectedIndex = 0;
                    edLabel.SelectedIndex = 0;
                }
                nUni = controller.nUnique;
                lkeEmployee.EditValue = controller.nEmployeeID;
               
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
            int nWorkFlow = 0;
            controller.Subject = cmbSubject.Text;
            controller.SetStatus(edLabel.Status);
            controller.SetLabel(edStatus.Label);
            controller.AllDay = this.checkAllDay.Checked;
            controller.StartDate = this.dtStart.DateTime.Date;
            controller.StartTime = this.timeStart.Time.TimeOfDay;
            controller.EndDate = this.dtEnd.DateTime.Date;
            controller.EndTime= this.timeEnd.Time.TimeOfDay;
            controller.strDetail = txtDetail.Text;
            controller.nEmployeeID = System.Convert.ToInt32(lkeEmployee.EditValue);
            controller.HasReminder = this.checkSMS.Checked;
            controller.ReminderTimeBeforeStart = TimeSpan.FromSeconds(10);
            controller.fCampaign = this.checkCampaign.Checked;
            if (cmbSubject.SelectedValue != null)
            {
                nWorkFlow = System.Convert.ToInt32(cmbSubject.SelectedValue.ToString());
                controller.nWorkFlowID = nWorkFlow;
            }
            int Output;
            if (fNew && this.checkCampaign.Checked && cmbSubject.SelectedValue != null && int.TryParse(cmbSubject.SelectedValue.ToString(), out Output) == true)
            {
                GetChild(System.Convert.ToInt32(cmbSubject.SelectedValue));
                InsertSubTask(strChild.Substring(0, strChild.Length - 1), dtStart.DateTime.Date, dtEnd.DateTime.Date);
            }
       
            // Save all changes made to the appointment edited in a form.
            
            controller.ApplyChanges();
        }

        private void InsertSubTask(string strSubTask, DateTime dtStartDate, DateTime dtEndDate)
        {
            string[] arrSubTask = strSubTask.Split(',');
            int nSubTask;
            for (int p = 0; p < arrSubTask.Length; p++)
            {
                nSubTask = System.Convert.ToInt32(arrSubTask[p]);
                tblDeliveryScheduleTableAdapter.Insert_TblDeliverySchedule_SubTask(nSubTask, dtStartDate, dtEndDate);
                tblDeliveryScheduleTableAdapter.Fill(aCMSDataSet.TblDeliverySchedule, nDepartment);
                UpdateForm();
            }
        }
        private DataTable GetChild(int Parent)
        {
            int[] ChildNodes = new int[100], MultiNodes = new int[100];
            this.tblWorkFlowTableAdapter1.Fill(this.dsTask.tblWorkFlow, Parent);
            DataTable tblChild = this.dsTask.tblWorkFlow;
            if (tblChild.Rows.Count > 0)
            {
                for (int i = 0; i <= tblChild.Rows.Count - 1; i++)
                {
                    ChildNodes[i] = System.Convert.ToInt32(tblChild.Rows[i][0]);
                    strChild = strChild + ChildNodes[i].ToString() + ",";
                }
            }
            SplitChild(strChild);
            return tblChild;
        }

        private void SplitChild(string strChildren)
        {
            npointer++;
            string[] strChars = strChildren.Substring(0, strChildren.Length - 1).Split(',');
            if (npointer < strChars.Length + 1)
            {
                GetChild(System.Convert.ToInt32(strChars[npointer - 1]));
            }
           
            //npointer=+1;
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
           
        }

        private void cmbSubject_SelectedValueChanged(object sender, EventArgs e)
        {
            int Output;
            if (cmbSubject.SelectedValue != null && int.TryParse(cmbSubject.SelectedValue.ToString(), out Output) == true)
            {
                //this.tblWorkFlowTableAdapter1.Fill(this.dsTask.tblWorkFlow, (int)cmbSubject.SelectedValue);
                //cmbTask.DataSource = dsTask.tblWorkFlow;

            }
        }

        private void cmbSubject_Click(object sender, EventArgs e)
        {
            this.tblWorkFlowTableAdapter.FillBy(this.dsSubject.tblWorkFlow,nDepartment);
            //cmbSubject.Text = controller.Subject;
        }

        private void cmbSubject_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           // this.tblWorkFlowTableAdapter.Fill(this.dsSubject.tblWorkFlow);
        }         

       
        

      

        private void cmbAttach_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Words (*.doc)|*.doc|PdF (*.pdf)|*.pdf|Excel (*.xls)|*.xls|OutLook (*.msg)|*.msg|Video (*.avi)|*.avi";
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                if ((openFileDialog1.OpenFile()) != null)
                {
                    if (openFileDialog1.FileName.Length > 255)
                    {
                        ACMS.Utils.UI.ShowErrorMessage(this, "The file name character is larger than 255. Please "
                            + "select a file less or equal to 255 character.");
                        // sbtnBeforePhoto.Focus();
                        return;
                    }
                    cmbAttach.Text = openFileDialog1.FileName.ToString();
                   
                }
            } 
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            string strAttachType = cmbAttach.Text.Substring(cmbAttach.Text.Length - 3, 3);
            strType = "";
            if (strAttachType == "pdf")
                strType = "PDF";
            else if (strAttachType == "xls")
                strType = "EXCEL";
            else if (strAttachType == "doc")
                strType = "WORD";
            else if (strAttachType == "msg")
                strType = "OUTLOOK";
            else if (strAttachType == "avi")
                strType = "VIDEO";

            this.tblAttachmentTableAdapter.Insert(nUni, DateTime.Now, strType, cmbAttach.Text);
            this.tblAttachmentTableAdapter.Fill(this.aCMSDataSet5.tblAttachment, nUni);

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi =
            gridView1.CalcHitInfo((sender as System.Windows.Forms.Control).PointToClient(System.Windows.Forms.Control.MousePosition));
            DataRow FocusRow;
            if (hi.RowHandle >= 0)
            {
                FocusRow = gridView1.GetDataRow(hi.RowHandle);
                string strType = FocusRow.ItemArray[3].ToString();
                string strPath = FocusRow.ItemArray[4].ToString();
                if (strType == "OUTLOOK")
                {
                    try
                    {
                        Email.Application oApp = new Email.Application();
                        Email._MailItem oMailItem = (Email._MailItem)oApp.CreateItemFromTemplate(strPath, Type.Missing);
                        //oMailItem.Subject = "abc";

                        oMailItem.Display(false);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (strType == "WORD")
                {
                    try
                    {
                        Word.Application wordApp;
                        Word.Document doc;
                        wordApp = new Word.ApplicationClass();
                        wordApp.Visible = true;
                        object fileName = strPath;
                        object missing = Type.Missing;
                        object fReadOnly = false;
                        doc = wordApp.Documents.Open(ref fileName,
                            ref missing, ref fReadOnly, ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing, ref missing, ref missing);
                        //doc.Activate();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (strType == "EXCEL")
                {
                    try
                    {
                        Excel.ApplicationClass oExcel = new Excel.ApplicationClass();
                        Excel.Workbook workBook = oExcel.Workbooks.Open(strPath, 0, true, 5, null, null, true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, null, null);
                        //Excel.Worksheet ws = (Excel.Worksheet)oExcel.ActiveSheet;
                        //ws.Activate();
                        //ws.get_Range("A1", "IV65536").Font.Size = 8;
                        oExcel.Visible = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (strType == "PDF")
                {
                    ACMS.ACMSStaff.To_Do_List.frmPDFviewer frm = new frmPDFviewer(strPath);
                    frm.Show();
                }
                else if (strType == "VIDEO")
                {
                    frmVideoPlayer frmPlayer = new frmVideoPlayer(strPath);
                    frmPlayer.Show();
                }
            }
            else if (gridView1.FocusedRowHandle >= 0)
            {
                FocusRow = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                string strType = FocusRow.ItemArray[3].ToString();
                string strPath = FocusRow.ItemArray[4].ToString();
                //ACMS.ACMSStaff.WorkFlow.MyCustomEditForm frm = new ACMS.ACMSStaff.WorkFlow.MyCustomEditForm((int)FocusRow.ItemArray[0], oUser.NDepartmentID());
                //frm.Show();
            }
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi =
         gridView1.CalcHitInfo((sender as System.Windows.Forms.Control).PointToClient(System.Windows.Forms.Control.MousePosition));
            DataRow FocusRow;
            if (hi.RowHandle >= 0)
            {
                FocusRow = gridView1.GetDataRow(hi.RowHandle);
                int nAttachment = System.Convert.ToInt32(FocusRow.ItemArray[0]);
                this.tblAttachmentTableAdapter.DeleteQuery(nAttachment);
            }
            else if (gridView1.FocusedRowHandle >= 0)
            {
                FocusRow = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                int nAttachment = System.Convert.ToInt32(FocusRow.ItemArray[0]);
                this.tblAttachmentTableAdapter.DeleteQuery(nAttachment);
            }
            this.tblAttachmentTableAdapter.Fill(this.aCMSDataSet5.tblAttachment, nUni);
        }

       
    }
    public class MyAppointmentFormController : AppointmentFormController {
            
        public string strDetail { get { return (String)EditedAppointmentCopy.CustomFields["strDetail"]; } set { EditedAppointmentCopy.CustomFields["strDetail"] = value; } }
        public int nEmployeeID { get { return System.Convert.ToInt32(EditedAppointmentCopy.CustomFields["nEmployeeID"]); } set { EditedAppointmentCopy.CustomFields["nEmployeeID"] = value; } }
        public int nUnique { get { return System.Convert.ToInt32(EditedAppointmentCopy.CustomFields["UniqueID"]); } set { EditedAppointmentCopy.CustomFields["UniqueID"] = value; } }
        public int nWorkFlowID { get { return System.Convert.ToInt32(EditedAppointmentCopy.CustomFields["nWorkFlowID"]); } set { EditedAppointmentCopy.CustomFields["nWorkFlowID"] = value; } }
        public bool fCampaign { get { return System.Convert.ToBoolean(EditedAppointmentCopy.CustomFields["fCampaign"]); } set { EditedAppointmentCopy.CustomFields["fCampaign"] = value; } }

        string SourcestrDetail { get { return (String)SourceAppointment.CustomFields["strDetail"]; } set { SourceAppointment.CustomFields["strDetail"] = value; } }
        int SourcestrEmployeeID { get { return System.Convert.ToInt32(SourceAppointment.CustomFields["nEmployeeID"]); } set { SourceAppointment.CustomFields["nEmployeeID"] = value; } }
        int SourceUnique { get { return System.Convert.ToInt32(SourceAppointment.CustomFields["UniqueID"]); } set { SourceAppointment.CustomFields["UniqueID"] = value; } }
        int SourceWorkFlowID { get { return System.Convert.ToInt32(SourceAppointment.CustomFields["nWorkFlowID"]); } set { SourceAppointment.CustomFields["nWorkFlowID"] = value; } }
        bool SourceCampaign { get { return System.Convert.ToBoolean(SourceAppointment.CustomFields["fCampaign"]); } set { SourceAppointment.CustomFields["fCampaign"] = value; } }

        public MyAppointmentFormController(SchedulerControl control, DevExpress.XtraScheduler.Appointment apt)
            : base(control, apt)
        {
		}

		public override bool IsAppointmentChanged() {
			if(base.IsAppointmentChanged())
				return true;
            return SourcestrDetail != strDetail ||
                SourcestrEmployeeID != nEmployeeID ||
                SourceUnique != nUnique ||
                SourceWorkFlowID != nWorkFlowID ||
                SourceCampaign != fCampaign;
		}

		protected override void ApplyCustomFieldsValues() 
        {
            SourcestrDetail = strDetail;
            SourcestrEmployeeID = nEmployeeID;
            SourceUnique = nUnique;
            SourceWorkFlowID = nWorkFlowID;
            SourceCampaign = fCampaign;
		}
	}

}