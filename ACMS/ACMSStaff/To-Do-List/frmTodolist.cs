using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraScheduler.Demos;


namespace ACMS.ACMSStaff.To_Do_List
{
    public partial class frmTodolist : DevExpress.XtraEditors.XtraForm
    {
        public frmTodolist()
        {
            InitializeComponent();
            //DateNavigatorModule uc1 = new DateNavigatorModule();
            //groupControl1.Controls.Add(uc1);

        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    public class SchedulerAppearanceMenu 
    {
        
    }
}