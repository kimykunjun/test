using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ACMS.ACMSStaff.To_Do_List
{
    public partial class frmPDFviewer : Form
    {
        private string strPath;
        public frmPDFviewer(string paramPath)
        {
            strPath = paramPath;
            InitializeComponent();
        }

        private void frmPDFviewer_Load(object sender, EventArgs e)
        {
            axAcroPDF1.LoadFile(strPath);
        }
    }
}