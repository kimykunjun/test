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
using Email = Microsoft.Office.Interop.Outlook;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;


namespace ACMS.ACMSStaff.WorkFlow
{
    public partial class MyCustomEditForm : DevExpress.XtraEditors.XtraForm
    {
        // The current appointment to be edited in a form.
        private DevExpress.XtraScheduler.Appointment apt = new DevExpress.XtraScheduler.Appointment();
        SchedulerControl control;       
        bool openRecurrenceForm = false;
        int suspendUpdateCount;
        int nID,nDepartment;
        private string strType;
        private int nUniqueID;
        private DataTable tblBinding;
        //private DevExpress.XtraEditors.CheckEdit checkAllDay;


        //MyAppointmentFormController controller;
        protected bool IsUpdateSuspended { get { return suspendUpdateCount > 0; } }

        // Set the current appointment.
        public void SetAppointment(DevExpress.XtraScheduler.Appointment newApt)
        {
            apt = newApt;
        }

        public MyCustomEditForm(int nUniqueID, int nDepartmentID)
        {
        
            //
            // Required for Windows Form Designer support
            nID = nUniqueID;
            InitializeComponent();            
            nDepartment = nDepartmentID;

            //
            // TODO: Add any constructor code after InitializeComponent call
            //

        }


        private void MyCustomEditForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'aCMSDataSet5.tblAttachment' table. You can move, or remove it, as needed.
            this.aCMSDataSet5.EnforceConstraints = false;
            this.tblAttachmentTableAdapter.Fill(this.aCMSDataSet5.tblAttachment, nID);
            this.tblDeliveryScheduleTableAdapter.FillBy(this.aCMSDataSet.TblDeliverySchedule, nID);
            tblBinding = this.aCMSDataSet.TblDeliverySchedule;
            this.tblEmployeeTableAdapter.Fill(this.dsEmployee.tblEmployee, nDepartment);
            UpdateForm();
          
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
            //controller.AllDay = this.checkAllDay.Checked;
            //if (!IsUpdateSuspended)
            //    UpdateAppointmentStatus();

            //UpdateIntervalControls();
        }
        void UpdateAppointmentStatus()
        {
            //AppointmentStatus currentStatus = edStatus.Status;
            //AppointmentStatus newStatus = controller.UpdateAppointmentStatus(currentStatus);
            //if (newStatus != currentStatus)
            //    edStatus.Status = newStatus;
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
                cmbSubject.Text = tblBinding.Rows[0]["strSubject"].ToString();

                int nSubject = System.Convert.ToInt32(tblBinding.Rows[0]["nStatus"]);              
               
               
                int nLabel = System.Convert.ToInt32(tblBinding.Rows[0]["nLabel"]);
                //string strLabel = "";
                //if (nLabel == 0)
                //    strLabel = "Important";
                //else if (nLabel == 1)
                //    strLabel = "Urgent";
                //else if (nLabel == 2)
                //    strLabel = "Priority";
                cmbType.SelectedIndex = nLabel;
                cmbStatus.SelectedIndex = nSubject;


                lkeEmployee.EditValue = System.Convert.ToInt32(tblBinding.Rows[0]["nEmployeeID"]);
                //if (System.Convert.ToBoolean(tblBinding.Rows[0]["bAllDay"])== true)
                checkAllDay.Checked = System.Convert.ToBoolean(tblBinding.Rows[0]["bAllDay"]); 
                //checkSMS = System.Convert.ToBoolean(tblBinding.Rows[0]["bAllDay"]);
                txtDetail.Text = tblBinding.Rows[0]["strDetail"].ToString();
            }
            finally
            {
                ResumeUpdate();
            }
            UpdateIntervalControls();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.tblDeliveryScheduleTableAdapter.Update(this.aCMSDataSet.TblDeliverySchedule);
            this.aCMSDataSet.AcceptChanges();
            this.tblDeliveryScheduleTableAdapter.FillBy(this.aCMSDataSet.TblDeliverySchedule, nID);  
            //this.tblDeliveryScheduleTableAdapter.FillBy(this.aCMSDataSet.TblDeliverySchedule, nID);  
            //tblDeliveryScheduleTableAdapter.Fill(aCMSDataSet.TblDeliverySchedule);


            //if (!controller.IsConflictResolved())
            //    return;

            //controller.Subject = cmbSubject.Text;
            //controller.SetStatus(edStatus.Status);
            //controller.SetLabel(edLabel.Label);
            //controller.AllDay = this.checkAllDay.Checked;
            //controller.StartDate = this.dtStart.DateTime.Date;
            //controller.StartTime = this.timeStart.Time.TimeOfDay;
            //controller.EndDate = this.dtEnd.DateTime.Date;
            //controller.EndTime= this.timeEnd.Time.TimeOfDay;
            //controller.strSO = txCustomName.Text;
            //controller.strEmployeeID = txCustomStatus.Text;

            //// Save all changes made to the appointment edited in a form.
            //controller.ApplyChanges();
            this.Close();
        }

        private void timeStart_EditValueChanged(object sender, EventArgs e)
        {
            //if (!IsUpdateSuspended)
            //    controller.StartTime = timeStart.Time.TimeOfDay;
            //UpdateIntervalControls();
        }

        private void dtEnd_EditValueChanged(object sender, EventArgs e)
        {
            //if (IsUpdateSuspended) return;
            //if (IsIntervalValid())
            //    controller.EndDate = dtEnd.DateTime;
            //else
            //    dtEnd.EditValue = controller.EndDate;
        }

        private void dtStart_EditValueChanged(object sender, EventArgs e)
        {
            //if (!IsUpdateSuspended)
            //    controller.StartDate = dtStart.DateTime;
            //UpdateIntervalControls();
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
            //OnRecurrenceButton();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void timeEnd_EditValueChanged(object sender, EventArgs e)
        {
            //if (IsUpdateSuspended) return;
            //if (IsIntervalValid())
            //    controller.EndTime = timeEnd.Time.TimeOfDay;
            //else
            //    timeEnd.EditValue = controller.EndTime;
        }
        //void OnRecurrenceButton()
        //{
        //    ShowRecurrenceForm();
        //}

        //void ShowRecurrenceForm()
        //{

        //    if (!control.SupportsRecurrence)
        //        return;

        //    // Prepare to edit appointment's recurrence.
        //    DevExpress.XtraScheduler.Appointment editedAptCopy = controller.EditedAppointmentCopy;
        //    DevExpress.XtraScheduler.Appointment editedPattern = controller.EditedPattern;
        //    DevExpress.XtraScheduler.Appointment patternCopy = controller.PrepareToRecurrenceEdit();

        //    AppointmentRecurrenceForm dlg = new AppointmentRecurrenceForm(patternCopy, control.OptionsView.FirstDayOfWeek);

        //    // Required for skins support.
        //    dlg.LookAndFeel.ParentLookAndFeel = this.LookAndFeel.ParentLookAndFeel;

        //    DialogResult result = dlg.ShowDialog(this);
        //    dlg.Dispose();

        //    if (result == DialogResult.Abort)
        //        controller.RemoveRecurrence();
        //    else
        //        if (result == DialogResult.OK)
        //        {
        //            controller.ApplyRecurrence(patternCopy);
        //            if (controller.EditedAppointmentCopy != editedAptCopy)
        //                UpdateForm();
        //        }
        //    UpdateIntervalControls();
        //}
        //private void checkAllDay_CheckedChanged_1(object sender, EventArgs e)
        //{
        //    controller.AllDay = this.checkAllDay.Checked;
        //    if (!IsUpdateSuspended)
        //        UpdateAppointmentStatus();

        //    UpdateIntervalControls();
        //}

        //private void MyCustomEditForm_Activated(object sender, EventArgs e)
        //{

        //}

        private void button1_Click(object sender, EventArgs e)
        {
            //frmVideoPlayer frmPlayer = new frmVideoPlayer();
            //frmPlayer.Show();
        }

        private void cmbSubject_SelectedValueChanged(object sender, EventArgs e)
        {
            //int Output;
            //if (cmbSubject.SelectedValue != null && int.TryParse(cmbSubject.SelectedValue.ToString(), out Output) == true)
            //{
            //    this.tblWorkFlowTableAdapter1.Fill(this.dsTask.tblWorkFlow, (int)cmbSubject.SelectedValue);
            //    cmbTask.DataSource = dsTask.tblWorkFlow;

            //}
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
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

            this.tblAttachmentTableAdapter.Insert(nID, DateTime.Now, strType, cmbAttach.Text);
            this.tblAttachmentTableAdapter.Fill(this.aCMSDataSet5.tblAttachment, nID);
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
                    ACMS.ACMSStaff.To_Do_List.frmPDFviewer frm = new ACMS.ACMSStaff.To_Do_List.frmPDFviewer(strPath);
                    frm.Show();
                }
                else if (strType == "VIDEO")
                {
                    ACMS.ACMSStaff.To_Do_List.frmVideoPlayer frmPlayer = new ACMS.ACMSStaff.To_Do_List.frmVideoPlayer(strPath);
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
            else if(gridView1.FocusedRowHandle >= 0)
            {
                FocusRow = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                int nAttachment = System.Convert.ToInt32(FocusRow.ItemArray[0]);
                this.tblAttachmentTableAdapter.DeleteQuery(nAttachment);

            }
            this.tblAttachmentTableAdapter.Fill(this.aCMSDataSet5.tblAttachment, nUniqueID);
        }
    }
    //public class MyAppointmentFormController : AppointmentFormController {

    //    public string strSO { get { return (String)EditedAppointmentCopy.CustomFields["strSO"]; } set { EditedAppointmentCopy.CustomFields["strSO"] = value; } }
    //    public string strEmployeeID { get { return (String)EditedAppointmentCopy.CustomFields["strEmployeeID"]; } set { EditedAppointmentCopy.CustomFields["strEmployeeID"] = value; } }

    //    string SourcestrSO { get { return (String)SourceAppointment.CustomFields["strSO"]; } set { SourceAppointment.CustomFields["strSO"] = value; } }
    //    string SourcestrEmployeeID { get { return (String)SourceAppointment.CustomFields["strEmployeeID"]; } set { SourceAppointment.CustomFields["strEmployeeID"] = value; } }

    //    public MyAppointmentFormController(SchedulerControl control, DevExpress.XtraScheduler.Appointment apt)
    //        : base(control, apt)
    //    {
    //    }

    //    public override bool IsAppointmentChanged() {
    //        if(base.IsAppointmentChanged())
    //            return true;
    //        return SourcestrSO != strSO ||
    //            SourcestrEmployeeID != strEmployeeID;
    //    }

    //    protected override void ApplyCustomFieldsValues() {
    //        SourcestrSO = strSO;
    //        SourcestrEmployeeID = strEmployeeID;
    //    }
    //}

}