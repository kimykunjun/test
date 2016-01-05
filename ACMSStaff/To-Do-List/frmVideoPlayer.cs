using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ACMS.ACMSStaff.To_Do_List
{
    public partial class frmVideoPlayer : Form
    {
        public frmVideoPlayer()
        {
            InitializeComponent();
            axWindowsMediaPlayer1.URL = @"C:\Documents and Settings\dwchiang\My Documents\My Videos\ACMS.avi";
        }
    }
}
