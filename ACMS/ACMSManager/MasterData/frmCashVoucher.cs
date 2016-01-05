using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;
using System.Data.OleDb;
using ACMSLogic;
using ACMS.XtraUtils.LookupEditBuilder;

namespace ACMS.ACMSManager.MasterData
{   
    public partial class frmCashVoucher : System.Windows.Forms.Form
    {
        private ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder myManager;
        private ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder myManager2;
        private DataTable dtCashVoucher;
        private string _mode;
        private string connectionString;
        private SqlConnection connection;
        DataTable table = new DataTable();               

        public frmCashVoucher()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //

            connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"];
            connection = new SqlConnection(connectionString);

            table.Columns.Add("strSN", typeof(string));
            table.Columns.Add("strDescription", typeof(string));
            table.Columns.Add("strDescription2", typeof(string));
            table.Columns.Add("dtStartDate", typeof(string));
            table.Columns.Add("dtExpiryDate", typeof(string));
            table.Columns.Add("mValue", typeof(string));
            table.Columns.Add("strBranchCode", typeof(string));
            table.Columns.Add("nTerminalID", typeof(string));
            table.Columns.Add("nCashVoucherType", typeof(string));
            table.Columns.Add("fSell", typeof(string));
            table.Columns.Add("nValidDuration", typeof(string));
            table.Columns.Add("strDurationUnit", typeof(string));
        }       

        #region init
        private void mdCashVoucherInit()
        {
            fMode = "N";
            string strSQL;

            //strSQL = "select * from tblServiceType";
            //comboBind(mdSV_cbNServiceTypeID,strSQL,"strDescription","nServiceTypeID",true);

            DataTable dt;
            DataSet _ds;

            _ds = new DataSet();
            strSQL = "select * from tblCashVoucherType";
            SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA", _ds, new string[] { "Table" }, new SqlParameter("@strSQL", strSQL));
            dt = _ds.Tables["Table"];
            DevExpress.XtraEditors.Controls.LookUpColumnInfo[] col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
            col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nCashVoucherTypeID", "Cash Voucher Type", 15, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None);
            col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strCashVoucherType", "Description", 15, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None);
            myManager = new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(repositoryItemLookUpEdit1, dt, col, "strCashVoucherType", "nCashVoucherTypeID", "Manager");
                       

            _ds = new DataSet();
                      
            strSQL = "select strBranchCode from tblBranch";
            SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA", _ds, new string[] { "table" }, new SqlParameter("@strSQL", strSQL));
            dt = _ds.Tables["table"];

            DevExpress.XtraEditors.Controls.LookUpColumnInfo[] col2 = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[1];

            col2[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strBranchCode", "Branch Code", 15, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None);

            new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(lk_BranchCode, dt, col2, "strBranchCode", "strBranchCode", "Branch Code");
            
            strSQL = "select * from tblCashVoucher  ";
            strSQL += " where (strSN like '%" + txtSearch.Text + "%' or strSN like '%" + txtSearch.Text + "%')";
            _ds = new DataSet();
            SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA", _ds, new string[] { "table" }, new SqlParameter("@strSQL", strSQL));
            dtCashVoucher = _ds.Tables["table"];
            this.gridControlMd_CashVoucher.DataSource = dtCashVoucher;
        }
        #endregion

        #region logic
        private void btn_Del_Click(object sender, System.EventArgs e)
        {
            int output;
            output = 0;
            DataRow row = gridViewMdCashVoucher.GetDataRow(gridViewMdCashVoucher.FocusedRowHandle);
            if (row != null)
            {
                DialogResult result = MessageBox.Show(this, "Do you really want to delete record with SN = '" + row["strSN"].ToString() + "'",
                    "Delete?", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {

                        SqlHelper.ExecuteNonQuery(connection, "sp_tblCashVoucher_Delete",
                            new SqlParameter("@inCashVoucherID", row["nCashVoucherID"]),
                            new SqlParameter("@iErrorCode", output));                            
                            
                        MessageBox.Show("Record Deleted.", "Info");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                    }
                }
            }

            mdCashVoucherInit();

        }


        #endregion

        private bool FieldChecking(DataRow dr)
        {
            if (dr["strSN"].ToString() == "")
            {
                MessageBox.Show("SN is empty", "Info");
                return false;
            }

            //if (dr["nCashVoucherTypeID"].ToString() == "")
            //{
            //    MessageBox.Show("Service Type Code is empty", "Info");
            //    return false;
            //}
            return true;

        }

        #region common
        public void CreateCmdsAndUpdate(string mySelectQuery, DataTable myTableName)
        {
            SqlConnection myConn = new SqlConnection(connectionString);
            SqlDataAdapter myDataAdapter = new SqlDataAdapter();
            myDataAdapter.SelectCommand = new SqlCommand(mySelectQuery, myConn);
            SqlCommandBuilder custCB = new SqlCommandBuilder(myDataAdapter);

            myConn.Open();
            DataSet custDS = new DataSet();
            myDataAdapter.Fill(custDS);

            //code to modify data in dataset here            
            myDataAdapter.Update(myTableName);
            myConn.Close();
        }

        private string ConvertToDateTime(object target)
        {
            if (target.ToString() == "")
                return null;
            else
                return Convert.ToDateTime(target).ToString();
        }

        private int ConvertToInt(object target)
        {
            if (target.ToString() == "")
                return 0;
            else
                return Convert.ToInt32(target);
        }

        private void comboBind(DevExpress.XtraEditors.ImageComboBoxEdit control, string strSQL, string display, string strValue)
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
                    properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr[display].ToString(), dr[strValue].ToString(), -1));
                }
            }
            finally
            {
                properties.Items.EndUpdate();
            }
            //Select the first item
            control.SelectedIndex = 0;
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

        #endregion


        private void btn_Add_Click(object sender, System.EventArgs e)
        {
            fMode = "I";
            DataRow dr = dtCashVoucher.NewRow();
            dtCashVoucher.Rows.Add(dr);
            this.gridControlMd_CashVoucher.Refresh();
            this.gridViewMdCashVoucher.FocusedRowHandle = dtCashVoucher.Rows.Count - 1;
        }

        private void frmCashVoucher_Load(object sender, System.EventArgs e)
        {
            mdCashVoucherInit();

        }

        private void gridViewMdCashVoucher_LostFocus(object sender, System.EventArgs e)
        {
            DataRow row = this.gridViewMdCashVoucher.GetDataRow(gridViewMdCashVoucher.FocusedRowHandle);

            string strSQL = "Select * from tblCashVoucher";
            if (fMode == "I")
            {
                if (FieldChecking(row))
                {
                    gridControlMd_CashVoucher.MainView.UpdateCurrentRow();
                    try
                    {
                        CreateCmdsAndUpdate(strSQL, dtCashVoucher);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Insert Failed");
                        return;
                    }
                    fMode = "N";
                }
            }
            else
            {
                gridViewMdCashVoucher.CloseEditor();
                gridViewMdCashVoucher.UpdateCurrentRow();
                CreateCmdsAndUpdate(strSQL, dtCashVoucher);
            }
        }

        private void btn_Search_Click(object sender, System.EventArgs e)
        {
            mdCashVoucherInit();
        }

        private void txtSearch_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Search_Click(sender, e);
            }
        }

        public string fMode
        {
            get
            {
                return _mode;
            }
            set
            {
                _mode = value;
            }
        }

        private void pbSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Title = "Open File to import";
            fDialog.Filter = "Scard Files|*.*";
            fDialog.InitialDirectory = @"C:\";
            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = fDialog.FileName.ToString();
            }
        }

        private void btnCashVoucherImport_Click(object sender, EventArgs e)
        {
            try
            {
                string strSN = "", strDescription = "", strDescription2 = "", dtStartDate = "", dtExpiryDate = "", nTerminalID="";
                string mValue = "", strBranchCode = "", nCashVoucherType = "", nValidDuration="", strDurationUnit="", fSell = "";                       

                if (VerifyFile())
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        strSN = dr["strSN"].ToString(); 
                        strDescription = dr["strDescription"].ToString(); 
                        strDescription2 = dr["strDescription2"].ToString();
                        dtStartDate = dr["dtStartDate"].ToString();
                        dtExpiryDate = dr["dtExpiryDate"].ToString(); 
                        mValue =  dr["mValue"].ToString(); 
                        strBranchCode =  dr["strBranchCode"].ToString();
                        nTerminalID = dr["nTerminalID"].ToString(); 
                        nCashVoucherType  = dr["nCashVoucherType"].ToString(); 
                        nValidDuration= dr["nValidDuration"].ToString(); 
                        strDurationUnit= dr["strDurationUnit"].ToString();
                        fSell = dr["fSell"].ToString();

                        int output = 0;
                        
                        SqlHelper.ExecuteNonQuery(connection, "sp_tblCashVoucher_Insert",                            
                            new SqlParameter("@sstrSN", strSN),
                            new SqlParameter("@sstrDescription", strDescription),
                            new SqlParameter("@sstrDescription2", strDescription2),
                            new SqlParameter("@inCreatedByID", 0),
                            new SqlParameter("@inStatusID", Convert.ToInt16(0)),
                            new SqlParameter("@dadtStartDate", DBNull.Value),
                            new SqlParameter("@dadtExpiryDate", DBNull.Value),
                            new SqlParameter("@dadtPrintedDate", DBNull.Value),
                            new SqlParameter("@curmValue", Convert.ToDouble(mValue)),
                            new SqlParameter("@sstrBranchCode", strBranchCode),
                            new SqlParameter("@inTerminalID", Convert.ToInt16(nTerminalID)),
                            new SqlParameter("@inCashVoucherTypeID", Convert.ToInt16(nCashVoucherType)),
                            new SqlParameter("@bfSell", Convert.ToInt16(fSell)),
                            new SqlParameter("@nValidDuration", Convert.ToInt16(nValidDuration)),
                            new SqlParameter("@strDurationUnit", strDurationUnit),
                            new SqlParameter("@iErrorCode", output));                           
	
                    }
                    mdCashVoucherInit();
                    MessageBox.Show(this, "Import successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }

        private bool VerifyFile()
        {
            if (txtFilePath.Text != "")
            {
                
                string connString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1;TypeGuessRows=0;ImportMixedTypes=Text\"", txtFilePath.Text);
                using (OleDbConnection dbConn = new OleDbConnection(connString))
                {
                    using (OleDbCommand cmd = new OleDbCommand(@"SELECT * FROM [Sheet1$]", dbConn))
                    {
                        dbConn.Open();
                        
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            table.Rows.Clear();
                            DataRow row;
                            int i = 2;
                            while (reader.Read())
                            {
                                if (reader[0].ToString() != "" && reader[1].ToString() != "" && reader[5].ToString() != "" && reader[6].ToString() != "" &&
                                    reader[7].ToString() != "" && reader[8].ToString() != "" && reader[9].ToString() != "" && reader[10].ToString() != "" && reader[11].ToString() != "")
                                {                                    
                                    row = table.NewRow();
                                    row["strSN"] = reader[0].ToString();
                                    row["strDescription"] = reader[1].ToString();
                                    row["strDescription2"] = reader[2].ToString() == "" ? "" : reader[2].ToString();
                                    row["dtStartDate"] = reader[3].ToString();
                                    row["dtExpiryDate"] = reader[4].ToString();
                                    row["mValue"] = reader[5].ToString();
                                    row["strBranchCode"] = reader[6].ToString();
                                    row["nTerminalID"] = reader[7].ToString();
                                    row["nCashVoucherType"] = reader[8].ToString();
                                    row["nValidDuration"] = reader[9].ToString();
                                    row["strDurationUnit"] = reader[10].ToString();
                                    row["fSell"] = reader[11].ToString();
                                    table.Rows.Add(row);
                                    i++;
                                }
                                else
                                {
                                    MessageBox.Show(this, "Wrong File format.\nCheck line #" + i.ToString());
                                    return false;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "Please select a file to import");
                return false;
            }
            return true;
        }
           
           

    }
}