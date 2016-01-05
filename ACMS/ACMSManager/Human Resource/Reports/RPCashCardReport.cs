using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;

namespace ACMS.ACMSManager.Human_Resource.Reports
{
    public partial class RPCashCardReport : Form
    {
        private string connectionString;
        private SqlConnection connection;
        public RPCashCardReport(int empID)
        {
            connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"];
            connection = new SqlConnection(connectionString);            
            InitializeComponent();
            BindInit();
        }

        private void BindCBMonth(ComboBox cb)
        {
            cb.Items.Clear();
            cb.Items.Add(new KeyValuePair<string,string>("January", "1"));
            cb.Items.Add(new KeyValuePair<string, string>("February", "2"));
            cb.Items.Add(new KeyValuePair<string, string>("March", "3"));
            cb.Items.Add(new KeyValuePair<string, string>("April", "4"));
            cb.Items.Add(new KeyValuePair<string, string>("May", "5"));
            cb.Items.Add(new KeyValuePair<string, string>("June", "6"));
            cb.Items.Add(new KeyValuePair<string, string>("July", "7"));
            cb.Items.Add(new KeyValuePair<string, string>("August", "8"));
            cb.Items.Add(new KeyValuePair<string, string>("September", "9"));
            cb.Items.Add(new KeyValuePair<string, string>("October", "10"));
            cb.Items.Add(new KeyValuePair<string, string>("November", "11"));
            cb.Items.Add(new KeyValuePair<string, string>("December", "12"));             
        }

        private void BindInit()
        {
            string strSQL = "Select distinct YEAR(dtTimeStamp) as sYear from tblCashCard ";
            
            comboBind(Year, strSQL, "sYear", "sYear", true);
            
            Year.SelectedIndex = 0;

            if (Year.SelectedIndex == -1)
                this.Year.Properties.Items.Insert(0, new DevExpress.XtraEditors.Controls.ImageComboBoxItem(DateTime.Today.Year.ToString(), ""));
            Year.SelectedIndex = 0;

            comboBind(ToYear, strSQL, "sYear", "sYear", true);
            ToYear.SelectedIndex = 0;

            if (ToYear.SelectedIndex == -1)
                this.ToYear.Properties.Items.Insert(0, new DevExpress.XtraEditors.Controls.ImageComboBoxItem(DateTime.Today.Year.ToString(), ""));
            ToYear.SelectedIndex = 0;

            dMonth.SelectedIndex = DateTime.Today.Month - 1;
            ToMonth.SelectedIndex = DateTime.Today.Month - 1;

            strSQL = "Select distinct strSN as strSN from tblCashCard ";
            comboBind(cbSN, strSQL, "strSN", "strSN", true);
            this.cbSN.Properties.Items.Insert(0, new DevExpress.XtraEditors.Controls.ImageComboBoxItem("All", ""));
            cbSN.SelectedIndex = 0;

            strSQL = "Select distinct strCAN as strCAN from tblCashCard ";
            comboBind(cbCAN, strSQL, "strCAN", "strCAN", true);
            this.cbCAN.Properties.Items.Insert(0, new DevExpress.XtraEditors.Controls.ImageComboBoxItem("All", ""));
            cbCAN.SelectedIndex = 0;
        }

        private void comboBind(DevExpress.XtraEditors.ImageComboBoxEdit control, string strSQL, string display, string strValue, bool fNum)
        {
              
            DataSet _ds = new DataSet();
            SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA", _ds, new string[] { "Table" }, new SqlParameter("@strSQL", strSQL));
            DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox properties = control.Properties;
            properties.Items.BeginUpdate();
            properties.Items.Clear();

            try
            {
                foreach (DataRow dr in _ds.Tables["Table"].Rows)
                {
                    //Initialize each item with the display text, value and image index
                    properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr[display].ToString(), dr[strValue], -1));
                }
            }
            finally
            {
                properties.Items.EndUpdate();
            }
            //Select the first item
            control.SelectedIndex = 0;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            //progressBarControl1.Visible = false; 

            string strSQL;

            string fromDateString, toDateString;
            string sSN, sCAN;
            if (cbSN.SelectedIndex == 0)
                sSN = "%";
            else
                sSN = cbSN.Text;

            if (cbCAN.SelectedIndex == 0)
                sCAN = "%";
            else
                sCAN = cbCAN.Text;

            fromDateString = Year.EditValue.ToString() + "-" + dMonth.EditValue.ToString() + "-01";
            toDateString = ToYear.EditValue.ToString() + "-" + ToMonth.EditValue.ToString() + "-" + DateTime.DaysInMonth(Convert.ToInt32(ToYear.EditValue.ToString()), Convert.ToInt32(ToMonth.EditValue.ToString())).ToString() + " 23:59:59";

            //strSQL = "select strImportBy,Bal,strSN,strCAN,RecNo,strTransType,convert(varchar, dtTimeStamp, 103) as dtDate,ltrim(right(convert(varchar, dtTimeStamp, 100),7)) as dtTime,PurAmt,strMerchant from tblCashCard where dtTimeStamp between '" + fromDateString + "' and '" + toDateString + "' and strSN like '" + sSN + "' and strCAN like '" + sCAN + "' order by dtTimeStamp desc";
            strSQL = "select strImportBy,Bal,strSN,strCAN,RecNo,strTransType,convert(varchar, dtTimeStamp, 103) as dtDate,convert(varchar, dtTimeStamp, 114) as dtTime,PurAmt,strMerchant from tblCashCard where dtTimeStamp between '" + fromDateString + "' and '" + toDateString + "' and strSN like '" + sSN + "' and strCAN like '" + sCAN + "' order by dtTimeStamp desc";

            SqlCommand myCmd = new SqlCommand(strSQL, connection);
            myCmd.CommandType = CommandType.Text;
            SqlDataAdapter adpCashCard = new SqlDataAdapter(myCmd);
            DataSet _ds = new DataSet("Cash Card Usage Report");
            adpCashCard.Fill(_ds, "Cash Card Usage Report");

            gridCashCardUsage.DataSource = _ds.Tables["Cash Card Usage Report"];
            gridCashCardUsage.Refresh();
            _ds.Dispose();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string strSQL, path = "";
            DataSet _ds;

            string fromDateString, toDateString;
            string sSN, sCAN;
            if (cbSN.SelectedIndex == 0)
                sSN = "%";
            else
                sSN = cbSN.Text;

            if (cbCAN.SelectedIndex == 0)
                sCAN = "%";
            else
                sCAN = cbCAN.Text;

            fromDateString = Year.EditValue.ToString() + "-" + dMonth.EditValue.ToString() + "-01";
            toDateString = ToYear.EditValue.ToString() + "-" + ToMonth.EditValue.ToString() + "-" + DateTime.DaysInMonth(Convert.ToInt32(ToYear.EditValue.ToString()), Convert.ToInt32(ToMonth.EditValue.ToString())).ToString() + " 23:59:59";
            strSQL = "select strImportBy,Bal,strSN,strCAN,RecNo,strTransType,convert(varchar, dtTimeStamp, 103) as dtDate,ltrim(right(convert(varchar, dtTimeStamp, 100),7)) as dtTime,PurAmt,strMerchant from tblCashCard where dtTimeStamp between '" + fromDateString + "' and '" + toDateString + "' and strSN like '" + sSN + "' and strCAN like '" + sCAN + "'";

            _ds = new DataSet();
            SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA", _ds, new string[] { "table" }, new SqlParameter("@strSQL", strSQL));
            gridExcel.DataSource = _ds.Tables["table"];

            SaveFileDialog fDialog = new SaveFileDialog();
            fDialog.Title = "Choose location to save your excel file";
            fDialog.DefaultExt = "xls";
            string exportPath = (string)ConfigurationSettings.AppSettings["CashCardExportPath"].ToString();
            fDialog.InitialDirectory = @exportPath;
            fDialog.FileName = "Cash Card Usage Report";
            fDialog.Filter = "Excel files (*.xls)|*.xls";
            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                path = fDialog.FileName.ToString();
                gridExcel.MainView.ExportToXls(path);
                MessageBox.Show("File had been exported");
            }

            //path = (string)ConfigurationSettings.AppSettings["CashCardExportPath"] + "Cash Card Usage Report.xls";


        }        
    }    
}
