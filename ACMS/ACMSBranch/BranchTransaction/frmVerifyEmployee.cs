using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.ApplicationBlocks.Data;

namespace ACMS.ACMSBranch.BranchTransaction
{
	/// <summary>
	/// Summary description for frmDepositMoney.
	/// </summary>
	public class frmVerifyEmployee : System.Windows.Forms.Form
	{
		private string connectionString;
		private SqlConnection connection;
		private DevExpress.XtraEditors.GroupControl groupControl1;
		private System.Windows.Forms.Label lblDepositMoney;
		internal DevExpress.XtraEditors.SimpleButton Cancel;
		private DevExpress.XtraEditors.TextEdit txtEmployeeId;
		internal DevExpress.XtraEditors.SimpleButton btnSave;
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.TextEdit txtPassword;
		private int ShiftID;
		private int TerminalId;
		private string BranchCode;
		private string Amount;
		private string ShiftDate;


		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmVerifyEmployee(int SID,int TID,string BCode,string Amt,string dtDate)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);
			ShiftID = SID;
			TerminalId = TID;
			BranchCode = BCode;
			Amount = Amt;
			ShiftDate = dtDate;
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
			this.txtPassword = new DevExpress.XtraEditors.TextEdit();
			this.label1 = new System.Windows.Forms.Label();
			this.txtEmployeeId = new DevExpress.XtraEditors.TextEdit();
			this.lblDepositMoney = new System.Windows.Forms.Label();
			this.btnSave = new DevExpress.XtraEditors.SimpleButton();
			this.Cancel = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
			this.groupControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtEmployeeId.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// groupControl1
			// 
			this.groupControl1.Controls.Add(this.txtPassword);
			this.groupControl1.Controls.Add(this.label1);
			this.groupControl1.Controls.Add(this.txtEmployeeId);
			this.groupControl1.Controls.Add(this.lblDepositMoney);
			this.groupControl1.Controls.Add(this.btnSave);
			this.groupControl1.Controls.Add(this.Cancel);
			this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupControl1.Location = new System.Drawing.Point(0, 0);
			this.groupControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
			this.groupControl1.Name = "groupControl1";
			this.groupControl1.ShowCaption = false;
			this.groupControl1.Size = new System.Drawing.Size(336, 141);
			this.groupControl1.TabIndex = 5;
			this.groupControl1.Text = "groupControl1";
			// 
			// txtPassword
			// 
			this.txtPassword.EditValue = "";
			this.txtPassword.Location = new System.Drawing.Point(152, 48);
			this.txtPassword.Name = "txtPassword";
			// 
			// txtPassword.Properties
			// 
			this.txtPassword.Properties.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(104, 20);
			this.txtPassword.TabIndex = 4;
			this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PwKeyDown);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(48, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 23);
			this.label1.TabIndex = 7;
			this.label1.Text = "Password";
			// 
			// txtEmployeeId
			// 
			this.txtEmployeeId.EditValue = "";
			this.txtEmployeeId.Location = new System.Drawing.Point(152, 16);
			this.txtEmployeeId.Name = "txtEmployeeId";
			this.txtEmployeeId.Size = new System.Drawing.Size(104, 20);
			this.txtEmployeeId.TabIndex = 3;
			// 
			// lblDepositMoney
			// 
			this.lblDepositMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblDepositMoney.Location = new System.Drawing.Point(48, 16);
			this.lblDepositMoney.Name = "lblDepositMoney";
			this.lblDepositMoney.Size = new System.Drawing.Size(104, 23);
			this.lblDepositMoney.TabIndex = 0;
			this.lblDepositMoney.Text = "Employee Id";
			// 
			// btnSave
			// 
			this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.btnSave.Appearance.Options.UseFont = true;
			this.btnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnSave.Location = new System.Drawing.Point(64, 88);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(88, 20);
			this.btnSave.TabIndex = 5;
			this.btnSave.Text = "OK";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// Cancel
			// 
			this.Cancel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.Cancel.Appearance.Options.UseFont = true;
			this.Cancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.Cancel.Location = new System.Drawing.Point(168, 88);
			this.Cancel.Name = "Cancel";
			this.Cancel.Size = new System.Drawing.Size(72, 20);
			this.Cancel.TabIndex = 6;
			this.Cancel.Text = "Cancel";
			this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
			// 
			// frmVerifyEmployee
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(336, 141);
			this.Controls.Add(this.groupControl1);
			this.Name = "frmVerifyEmployee";
			this.Text = "Shift Verification";
			this.Enter += new System.EventHandler(this.btnSave_Click);
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
			this.groupControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtEmployeeId.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			DataSet _ds = new DataSet();
			DataTable dt;

			string strSQL = "Select * from tblEmployee Where nStatusID=1 and nEmployeeID = " + txtEmployeeId.Text + " And strPassword = '" + txtPassword.Text + "'";
			
			SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			dt = _ds.Tables["Table"];

			if (dt.Rows.Count > 0)
			{
				Save();
				MessageBox.Show("Shift Closed. " + string.Format("{0:hh:MM:ss tt}",DateTime.Now),"");
				this.Dispose();
				PrintShift();
			}
			else
			{
				MessageBox.Show("Verification Failed!","Shift Verification");
			}
			this.Dispose();
		}

		private void Save()
		{
            int output;
			output = 0;

			SqlHelper.ExecuteNonQuery(connection,"up_VerifyShift",
				new SqlParameter("@retval",output),
				new SqlParameter("@UserID",txtEmployeeId.Text),								
				new SqlParameter("@Amount",Amount),								
				new SqlParameter("@ShiftID",ShiftID),
				new SqlParameter("@BranchCode",BranchCode),
				new SqlParameter("@TerminalID",TerminalId),
				new SqlParameter("@dtDate",ShiftDate)
				);

			DataSet _ds = new DataSet();
			DataTable dt;
						
			string strSQL = "Select dtDate from tbLShift Where nShiftID = " + ShiftID;

			SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			
			dt = _ds.Tables["Table"];

			SqlHelper.ExecuteNonQuery(connection,"In_tblAudit",
				new SqlParameter("@retval",output),
				new SqlParameter("@ShiftDate",string.Format("{0:dd/MM/yyyy}",Convert.ToDateTime(ShiftDate))),
				new SqlParameter("@BranchCode",BranchCode),
				new SqlParameter("@ShiftID",ShiftID),
				new SqlParameter("@TerminalID",TerminalId),
				new SqlParameter("@UserID",txtEmployeeId.Text),
				new SqlParameter("@AuditEntry","Close Shift " + ShiftID)
				);

		}
        private void PrintShift()
        {
            string strSQL;
            DataSet _ds;
            _ds = new DataSet();
            ACMS.ACMSBranch.BranchTransaction.rptShiftSettlement myRpt = new ACMS.ACMSBranch.BranchTransaction.rptShiftSettlement();
            strSQL = "select * from sv_shift_settlement where nTerminalID=" + TerminalId + " and strBranchCode='" + BranchCode + "' and nShiftID='" + ShiftID + "' and convert(varchar,dtDate,111)= '" + string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(ShiftDate)) + "'";

            SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA", _ds, new string[] { "Table" }, new SqlParameter("@strSQL", strSQL));

            myRpt.DataSource = _ds.Tables["table"];
            myRpt.fBranch.DataBindings.Add("Text", _ds.Tables["table"], "strBranchName");
            myRpt.fPaymentMode.DataBindings.Add("Text", _ds.Tables["table"], "Payment Mode");
            myRpt.fAmount.DataBindings.Add("Text", _ds.Tables["table"], "Amount", "{0:$0.00}");
            myRpt.fClosingStaff.DataBindings.Add("Text", _ds.Tables["table"], "close_shift_name");
            myRpt.fVerifyStaff.DataBindings.Add("Text", _ds.Tables["table"], "verify_name");
            myRpt.fDate.DataBindings.Add("Text", _ds.Tables["table"], "dtDate", "{0:dd-MM-yyyy}");
            myRpt.fTime.DataBindings.Add("Text", _ds.Tables["table"], "dtCloseTime", "{0:hh:mm tt}");
            myRpt.fTitle.DataBindings.Add("Text", _ds.Tables["table"], "SHIFT_DESC");
            //myRpt.fTotTrans.DataBindings.Add("Text", _ds.Tables["table"], "total_receipt");
            myRpt.fTotTrans.Text = _ds.Tables["table"].Compute("SUM(total_receipt)", "").ToString();

            DataSet _ds3;
            _ds3 = new DataSet();
            strSQL = "SELECT ISNULL(SUM(dbo.tblReceiptPayment.mAmount) ,0) AS void_amt, COUNT(dbo.tblReceiptPayment.mAmount) AS total_void " +
                    "FROM         dbo.tblShift LEFT OUTER JOIN " +
                                          "dbo.tblReceipt ON dbo.tblReceipt.nShiftID = dbo.tblShift.nShiftID AND CONVERT(varchar, dbo.tblReceipt.dtDate, 103) = CONVERT(varchar, dbo.tblShift.dtDate, 103) AND " +
                                          "dbo.tblReceipt.nTerminalID = dbo.tblShift.nTerminalID AND dbo.tblReceipt.strBranchCode = dbo.tblShift.strBranchCode LEFT OUTER JOIN " +
                                          "dbo.tblReceiptPayment ON dbo.tblReceiptPayment.strReceiptNo = dbo.tblReceipt.strReceiptNo " +
                    "WHERE     (dbo.tblReceipt.fVoid = 1) " +
                    "and dbo.tblShift.strBranchCode='" + BranchCode + "' and dbo.tblShift.nShiftID=" + ShiftID + " and convert(varchar,dbo.tblShift.dtDate,111)= '" + string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(ShiftDate)) + "' AND dbo.tblShift.nTerminalID = " + TerminalId;
            SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA", _ds3, new string[] { "Table" }, new SqlParameter("@strSQL", strSQL));
            myRpt.fVoidAmt.Text = String.Format("{0:$0.00}", _ds3.Tables["table"].Rows[0]["void_amt"]);
            myRpt.fNoVoid.Text = _ds3.Tables["table"].Rows[0]["total_void"].ToString();
            _ds3.Dispose();

            _ds3 = new DataSet();
            strSQL = "SELECT dbo.GetBranchDiscount('" + BranchCode + "'," + ShiftID + ",'" + string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(ShiftDate)) + "'," + TerminalId + ") AS total_discount";
            SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA", _ds3, new string[] { "Table" }, new SqlParameter("@strSQL", strSQL));
            myRpt.fTotDisc.Text = String.Format("{0:$0.00}", _ds3.Tables["table"].Rows[0]["total_discount"]);
            _ds3.Dispose();

            _ds3 = new DataSet();
            strSQL = "select * from sv_shift_settlement_freebie where nTerminalID='" + TerminalId + "' and strBranchCode='" + BranchCode + "' and nShiftID='" + ShiftID + "' and convert(varchar,dtDate,111)='" + string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(ShiftDate)) + "'";
            SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA", _ds3, new string[] { "Table" }, new SqlParameter("@strSQL", strSQL));

            myRpt.fFreebie.Text = "FREEBIES GIVEN:";
            foreach (DataRow dr2 in _ds3.Tables["Table"].Rows)
            {
                myRpt.fFreebie.Text += "\n" + dr2["strDescription"].ToString();
                myRpt.fFreebieQty.Text += "\n" + dr2["qty"].ToString();
            }

            DataSet _ds1, _ds2;
            _ds1 = new DataSet();
            _ds2 = new DataSet();
            //strSQL = "Select isnull(nQuantity,0) as nQuantity from tblProductInventory Where strBranchCode = '" + BranchCode + "' and strProductCode = 'MW' ";
            SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "dw_sp_SCStockReconItem", _ds1, new string[] { "Table" }, new SqlParameter("@BranchCode", BranchCode), new SqlParameter("@strProductCode", "MW"));
            //SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA", _ds1, new string[] { "Table" }, new SqlParameter("@strSQL", strSQL));
            myRpt.fMWBalance.DataBindings.Add("Text", _ds1.Tables["Table"], "nQty", "{0:0}");
            if (_ds1.Tables[0].Rows.Count == 0)
            {
                strSQL = "Select 0 as nQuantity";
                SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA", _ds1, new string[] { "Table" }, new SqlParameter("@strSQL", strSQL));

            }
            strSQL = "select Count(*) as CountLock from tblLocker Where nStatusID = 0 And strBranchCode = '" + BranchCode + "'";
            SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA", _ds2, new string[] { "Table" }, new SqlParameter("@strSQL", strSQL));
            myRpt.fLCKBalance.DataBindings.Add("Text", _ds2.Tables["table"], "CountLock", "{0:0}");

            myRpt.Print();
        }
		private void Cancel_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

		private void PwKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btnSave_Click(this,e);
			}
		}



			
	}
}
