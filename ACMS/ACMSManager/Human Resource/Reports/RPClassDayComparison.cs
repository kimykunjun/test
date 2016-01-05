using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;


namespace ACMS.ACMSManager.Human_Resource.Reports
{
    public partial class RPClassDayComparison : DevExpress.XtraEditors.XtraForm
    {
        public RPClassDayComparison()
        {
            InitializeComponent();
        }

        private void RPClassDayComparison_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'aCMSDataSet4.tblClass' table. You can move, or remove it, as needed.
            this.tblClassTableAdapter.Fill(this.aCMSDataSet4.tblClass);

        }

        private void dtDate1_DateSelected(object sender, DateRangeEventArgs e)
        {
            this.tblClassInstanceTableAdapter.Fill(this.dsClassInstance.tblClassInstance, lkedtClassType.EditValue.ToString(), dtDate1.SelectionStart);
        }

        private void dtDate2_DateSelected(object sender, DateRangeEventArgs e)
        {
            this.tblClassInstanceTableAdapter1.Fill(this.dcClassIns.tblClassInstance, lkedtClassType.EditValue.ToString(),dtDate2.SelectionStart);
        }

        private void gridMaster_DoubleClick(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi =
                  gridMasterView.CalcHitInfo((sender as System.Windows.Forms.Control).PointToClient(System.Windows.Forms.Control.MousePosition));
            DataRow FocusRow;
            if (hi.RowHandle >= 0)
            {
                FocusRow = gridMasterView.GetDataRow(hi.RowHandle);
                int nClassSchedule = (int)FocusRow.ItemArray[10];
                DateTime dtClass = (DateTime)FocusRow.ItemArray[1];
                string nDay = dtClass.DayOfWeek.ToString();
                ACMSManager.Reports.RPClassDetail frm = new ACMSManager.Reports.RPClassDetail(nClassSchedule, nDay, dtClass);
                frm.Show();
            }
            else if (gridMasterView.FocusedRowHandle >= 0)
            {
                FocusRow = gridMasterView.GetDataRow(gridMasterView.FocusedRowHandle);
                int nClassSchedule = (int)FocusRow.ItemArray[10];
                DateTime dtClass = (DateTime)FocusRow.ItemArray[1];
                string nDay = dtClass.DayOfWeek.ToString();
                ACMSManager.Reports.RPClassDetail frm = new ACMSManager.Reports.RPClassDetail(nClassSchedule, nDay, dtClass);
                frm.Show();
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
                int nClassSchedule = (int)FocusRow.ItemArray[10];
                DateTime dtClass = (DateTime)FocusRow.ItemArray[1];
                string nDay = dtClass.DayOfWeek.ToString();
                ACMSManager.Reports.RPClassDetail frm = new ACMSManager.Reports.RPClassDetail(nClassSchedule, nDay, dtClass);
                frm.Show();
            }
            else if (gridView1.FocusedRowHandle >= 0)
            {
                FocusRow = gridView1.GetDataRow(gridMasterView.FocusedRowHandle);
                int nClassSchedule = (int)FocusRow.ItemArray[10];
                DateTime dtClass = (DateTime)FocusRow.ItemArray[1];
                string nDay = dtClass.DayOfWeek.ToString();
                ACMSManager.Reports.RPClassDetail frm = new ACMSManager.Reports.RPClassDetail(nClassSchedule, nDay, dtClass);
                frm.Show();
            }
        }
    }
}