using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.ApplicationBlocks.Data;

//////using Rp = Acms.Core.Repository;
////using Fc = Acms.Core.Factory;
using Do = Acms.Core.Domain;
using ACMSLogic;
using ACMS.Utils;
using ACMS.XtraUtils;
using System.Text.RegularExpressions;

namespace ACMS.ACMSBranch.BranchTransaction
{
	/// <summary>
	/// Summary description for VerifyCloseShift.
	/// </summary>
	public class VerifyCloseShift : DevExpress.XtraEditors.XtraForm
	{
		public DateTime dtDate;
		private Do.Employee employee;
		private Do.TerminalUser terminalUser; 
		User oUser;

		private string connectionString;
		private SqlConnection connection;
		private DevExpress.XtraEditors.GroupControl groupControl1;
		private System.Windows.Forms.Label lblCF;
		private System.Windows.Forms.Label lblCS;
		private DevExpress.XtraEditors.TextEdit txtCS;
		private DevExpress.XtraEditors.TextEdit txtOF;
		private DevExpress.XtraEditors.TextEdit txtDepositMoney;
		private System.Windows.Forms.Label lblDepositMoney;
		private System.Windows.Forms.Label lblOF;
		internal DevExpress.XtraEditors.SimpleButton Cancel;
		internal DevExpress.XtraEditors.SimpleButton btnClose;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private int ShiftID;
		private string strBranchCode;
		private int TerminalID;
		private DevExpress.XtraEditors.TextEdit txtMineralWater;
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.TextEdit txtCF;
		private string ShiftDate;


		#region Initialize Data from Login
		public void initData (ACMSLogic.User User)
		{
			oUser = User;
		}

		public void SetEmployeeRecord(Do.Employee employee)
		{
			this.employee = employee;
		}

		public void SetTerminalUser(Do.TerminalUser terminalUser)
		{
			this.terminalUser = terminalUser;
		}

		#endregion

		public VerifyCloseShift(int SID, string BranchCode, int nTerminalID, string dtDate)
		{
			//
			// Required for Windows Form Designer support
			//
			ShiftID = SID;
			ShiftDate = dtDate;
			TerminalID = nTerminalID;
			strBranchCode = BranchCode;

			InitializeComponent();
			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);
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
			this.txtCF = new DevExpress.XtraEditors.TextEdit();
			this.txtMineralWater = new DevExpress.XtraEditors.TextEdit();
			this.label1 = new System.Windows.Forms.Label();
			this.btnClose = new DevExpress.XtraEditors.SimpleButton();
			this.lblCF = new System.Windows.Forms.Label();
			this.lblCS = new System.Windows.Forms.Label();
			this.txtCS = new DevExpress.XtraEditors.TextEdit();
			this.txtOF = new DevExpress.XtraEditors.TextEdit();
			this.txtDepositMoney = new DevExpress.XtraEditors.TextEdit();
			this.lblDepositMoney = new System.Windows.Forms.Label();
			this.lblOF = new System.Windows.Forms.Label();
			this.Cancel = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
			this.groupControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtCF.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtMineralWater.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCS.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtOF.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDepositMoney.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// groupControl1
			// 
			this.groupControl1.Controls.Add(this.txtCF);
			this.groupControl1.Controls.Add(this.txtMineralWater);
			this.groupControl1.Controls.Add(this.label1);
			this.groupControl1.Controls.Add(this.btnClose);
			this.groupControl1.Controls.Add(this.lblCF);
			this.groupControl1.Controls.Add(this.lblCS);
			this.groupControl1.Controls.Add(this.txtCS);
			this.groupControl1.Controls.Add(this.txtOF);
			this.groupControl1.Controls.Add(this.txtDepositMoney);
			this.groupControl1.Controls.Add(this.lblDepositMoney);
			this.groupControl1.Controls.Add(this.lblOF);
			this.groupControl1.Controls.Add(this.Cancel);
			this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupControl1.Location = new System.Drawing.Point(0, 0);
			this.groupControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
			this.groupControl1.Name = "groupControl1";
			this.groupControl1.ShowCaption = false;
			this.groupControl1.Size = new System.Drawing.Size(368, 227);
			this.groupControl1.TabIndex = 5;
			this.groupControl1.Text = "groupControl1";
			// 
			// txtCF
			// 
			this.txtCF.EditValue = "";
			this.txtCF.Location = new System.Drawing.Point(176, 144);
			this.txtCF.Name = "txtCF";
			// 
			// txtCF.Properties
			// 
			this.txtCF.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.txtCF.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.txtCF.Properties.Mask.BeepOnError = true;
			this.txtCF.Properties.Mask.EditMask = "[0-9]+\\.[0-9][0-9]";
			this.txtCF.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
			this.txtCF.Properties.Mask.ShowPlaceHolders = false;
			this.txtCF.Properties.Mask.UseMaskAsDisplayFormat = true;
			this.txtCF.Properties.ReadOnly = true;
			this.txtCF.Size = new System.Drawing.Size(136, 20);
			this.txtCF.TabIndex = 14;
			// 
			// txtMineralWater
			// 
			this.txtMineralWater.EditValue = "";
			this.txtMineralWater.Enabled = false;
			this.txtMineralWater.Location = new System.Drawing.Point(176, 16);
			this.txtMineralWater.Name = "txtMineralWater";
			// 
			// txtMineralWater.Properties
			// 
			this.txtMineralWater.Properties.DisplayFormat.FormatString = "f0";
			this.txtMineralWater.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.txtMineralWater.Properties.EditFormat.FormatString = "f0";
			this.txtMineralWater.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.txtMineralWater.Properties.Mask.EditMask = "f0";
			this.txtMineralWater.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.txtMineralWater.Properties.NullText = "0";
			this.txtMineralWater.Properties.ReadOnly = true;
			this.txtMineralWater.Size = new System.Drawing.Size(136, 20);
			this.txtMineralWater.TabIndex = 13;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(152, 23);
			this.label1.TabIndex = 12;
			this.label1.Text = "Mineral Water Balance";
			// 
			// btnClose
			// 
			this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.btnClose.Appearance.Options.UseFont = true;
			this.btnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnClose.Location = new System.Drawing.Point(56, 184);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(112, 20);
			this.btnClose.TabIndex = 11;
			this.btnClose.Text = "Close Shift";
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// lblCF
			// 
			this.lblCF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblCF.Location = new System.Drawing.Point(16, 144);
			this.lblCF.Name = "lblCF";
			this.lblCF.Size = new System.Drawing.Size(144, 16);
			this.lblCF.TabIndex = 9;
			this.lblCF.Text = "Closing Float";
			// 
			// lblCS
			// 
			this.lblCS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblCS.Location = new System.Drawing.Point(16, 112);
			this.lblCS.Name = "lblCS";
			this.lblCS.Size = new System.Drawing.Size(144, 16);
			this.lblCS.TabIndex = 8;
			this.lblCS.Text = "Total Cash Sales";
			// 
			// txtCS
			// 
			this.txtCS.EditValue = "0.00";
			this.txtCS.Location = new System.Drawing.Point(176, 112);
			this.txtCS.Name = "txtCS";
			// 
			// txtCS.Properties
			// 
			this.txtCS.Properties.DisplayFormat.FormatString = "#.00";
			this.txtCS.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.txtCS.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.txtCS.Properties.Mask.EditMask = "f2";
			this.txtCS.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.txtCS.Properties.Mask.UseMaskAsDisplayFormat = true;
			this.txtCS.Properties.ReadOnly = true;
			this.txtCS.Size = new System.Drawing.Size(136, 20);
			this.txtCS.TabIndex = 7;
			// 
			// txtOF
			// 
			this.txtOF.EditValue = "0.00";
			this.txtOF.Location = new System.Drawing.Point(176, 80);
			this.txtOF.Name = "txtOF";
			// 
			// txtOF.Properties
			// 
			this.txtOF.Properties.DisplayFormat.FormatString = "#.00";
			this.txtOF.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.txtOF.Properties.EditFormat.FormatString = "#.00";
			this.txtOF.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.txtOF.Properties.Mask.EditMask = "f2";
			this.txtOF.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.txtOF.Properties.Mask.UseMaskAsDisplayFormat = true;
			this.txtOF.Properties.ReadOnly = true;
			this.txtOF.Size = new System.Drawing.Size(136, 20);
			this.txtOF.TabIndex = 5;
			// 
			// txtDepositMoney
			// 
			this.txtDepositMoney.CausesValidation = false;
			this.txtDepositMoney.EditValue = "";
			this.txtDepositMoney.Location = new System.Drawing.Point(176, 48);
			this.txtDepositMoney.Name = "txtDepositMoney";
			// 
			// txtDepositMoney.Properties
			// 
			this.txtDepositMoney.Properties.DisplayFormat.FormatString = "\\d+\\.[0-9]\\d";
			this.txtDepositMoney.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.txtDepositMoney.Properties.EditFormat.FormatString = "\\d+\\.[0-9]\\d";
			this.txtDepositMoney.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.txtDepositMoney.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Strong;
			this.txtDepositMoney.Properties.Mask.EditMask = "\\d+\\.[0-9]\\d";
			this.txtDepositMoney.Properties.Mask.IgnoreMaskBlank = false;
			this.txtDepositMoney.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
			this.txtDepositMoney.Properties.Mask.ShowPlaceHolders = false;
			this.txtDepositMoney.Properties.Mask.UseMaskAsDisplayFormat = true;
			this.txtDepositMoney.Properties.NullText = "0";
			this.txtDepositMoney.Size = new System.Drawing.Size(136, 20);
			this.txtDepositMoney.TabIndex = 3;
			this.txtDepositMoney.EditValueChanged += new System.EventHandler(this.txtDepositMoney_EditValueChanged);
			this.txtDepositMoney.Leave += new System.EventHandler(this.txtDepositMoney_Leave);
			this.txtDepositMoney.MouseLeave += new System.EventHandler(this.txtDepositMoney_MouseLeave);
			// 
			// lblDepositMoney
			// 
			this.lblDepositMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblDepositMoney.Location = new System.Drawing.Point(16, 48);
			this.lblDepositMoney.Name = "lblDepositMoney";
			this.lblDepositMoney.Size = new System.Drawing.Size(152, 23);
			this.lblDepositMoney.TabIndex = 0;
			this.lblDepositMoney.Text = "Money to be deposited";
			// 
			// lblOF
			// 
			this.lblOF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblOF.Location = new System.Drawing.Point(16, 80);
			this.lblOF.Name = "lblOF";
			this.lblOF.Size = new System.Drawing.Size(144, 16);
			this.lblOF.TabIndex = 2;
			this.lblOF.Text = "Opening Float";
			// 
			// Cancel
			// 
			this.Cancel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.Cancel.Appearance.Options.UseFont = true;
			this.Cancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.Cancel.Location = new System.Drawing.Point(176, 184);
			this.Cancel.Name = "Cancel";
			this.Cancel.Size = new System.Drawing.Size(96, 20);
			this.Cancel.TabIndex = 6;
			this.Cancel.Text = "Cancel";
			this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
			// 
			// VerifyCloseShift
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(368, 227);
			this.Controls.Add(this.groupControl1);
			this.Name = "VerifyCloseShift";
			this.Text = "Close Shift";
			this.Load += new System.EventHandler(this.VerifyCloseShift_Load);
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
			this.groupControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.txtCF.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtMineralWater.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCS.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtOF.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDepositMoney.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion



		private void btnClose_Click(object sender, System.EventArgs e)
		{
			int output;
			//string strSQL;
			bool MineralSales = true;

//			DataSet _ds = new DataSet();
//			strSQL = "select Count(*) as MineralCount from tblreceipt where ncategoryid=21 And nShiftID = " + ShiftID + " And strBranchCode = '" + oUser.StrBranchCode() + "' And nTerminalID = " + terminalUser.NTerminalID + " And Convert(varchar(10),dtdate,111) = '" + ShiftDate + "'" ;
//					
//			SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
//			
//			DataTable dtMW = _ds.Tables["Table"];
//				
//			if (dtMW.Rows[0][0].ToString() == "0")
//			{
//				DialogResult result = MessageBox.Show(this, "There is no sales for mineral water.Would you like to continue?",
//					"Empty Mineral Water Transaction Found on Sales", MessageBoxButtons.YesNo);
//				if (result == DialogResult.No)
//					MineralSales = false;
//			}


			if (MineralSales == true)
			{
				output = 0;

				SqlHelper.ExecuteNonQuery(connection,"up_ShiftDeposit",
					new SqlParameter("@retval",output),
					new SqlParameter("@Amount",this.txtDepositMoney.Text),								
					new SqlParameter("@UserID",oUser.NEmployeeID()),								
					new SqlParameter("@ShiftID",ShiftID),
					new SqlParameter("@BranchCode",strBranchCode),
					new SqlParameter("@TerminalID",TerminalID),
					new SqlParameter("@dtDate",ShiftDate)
					);

				ACMS.ACMSBranch.BranchTransaction.frmVerifyEmployee myform;
				myform = new ACMS.ACMSBranch.BranchTransaction.frmVerifyEmployee(ShiftID,terminalUser.NTerminalID,oUser.StrBranchCode(),txtCF.Text,ShiftDate);
				myform.ShowDialog();
			}

			this.Dispose();
		
		}

		private void VerifyCloseShift_Load(object sender, System.EventArgs e)
		{
			DataSet _ds;
			DataTable dt;
			string strSQL;
			
			_ds = new DataSet();

		//	strSQL = "select Count(*) as MineralCount from tblreceipt where ncategoryid=21 And nShiftID = " + ShiftID + " And strBranchCode = '" + oUser.StrBranchCode() + "' And nTerminalID = " + terminalUser.NTerminalID + " And Convert(varchar(10),dtdate,111) = '" + ShiftDate + "'" ;
			strSQL = "Select nQuantity from tblProductInventory Where strBranchCode = '" + oUser.StrBranchCode() + "' and strProductCode = 'MW' ";
			SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			
			dt = _ds.Tables["Table"];
			if (dt.Rows.Count > 0)
                this.txtMineralWater.Text = dt.Rows[0]["nQuantity"].ToString();
			else
				this.txtMineralWater.Text = "0";

			_ds = new DataSet();

			strSQL = "Select isnull(mOpeningFloat,0) as mOpeningFloat,isnull(mDepositedFloat,0) as mDepositedFloat from tbLShift Where nShiftID = " + ShiftID + " And strBranchCode = '" + oUser.StrBranchCode() + "' And nTerminalID = " + terminalUser.NTerminalID + " And Convert(varchar(10),dtdate,111) = '" + ShiftDate + "'" ;

			SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			
			dt = _ds.Tables["Table"];

			this.txtOF.Text = dt.Rows[0]["mOpeningFloat"].ToString();
			this.txtDepositMoney.Text = dt.Rows[0]["mDepositedFloat"].ToString();

			if (txtDepositMoney.Text.IndexOf(".") == txtDepositMoney.Text.Length - 1)
				txtDepositMoney.Text = txtDepositMoney.Text + "00";

			strSQL = "Select isnull(Amount,0) as TotalAmount From sv_shift_settlement Where [Payment Mode]='CASH' And nShiftID = " + ShiftID + " And strBranchCode = '" + terminalUser.Branch.Id + "' And nTerminalID = " + terminalUser.NTerminalID + " And Convert(varchar(10),dtdate,111) = '" + ShiftDate + "'" ;
			
			_ds = new DataSet();
			dt = new DataTable();

			SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			
			dt = _ds.Tables["Table"];

			this.txtCS.Text = dt.Rows[0]["TotalAmount"].ToString();
			
			if (txtOF.Text == "")
				txtOF.Text = "0.00";

			if (txtCS.Text == "")
				txtCS.Text = "0.00";

			if (txtDepositMoney.Text == "")
				txtDepositMoney.Text = "0.00";

			decimal OF = Convert.ToDecimal(txtOF.Text);
			decimal CS = Convert.ToDecimal(txtCS.Text);
			decimal DM = Convert.ToDecimal(txtDepositMoney.Text);
			decimal Total;

			//txtOF.Text = txtOF.Text + txtCS.Text - txtDepositMoney.Text;
			Total = OF + CS - DM; 
			this.txtCF.Text = Total.ToString();

			if (txtCF.Text.IndexOf(".") == txtCF.Text.Length - 1)
				txtCF.Text = txtCF.Text + "00";
		}

		private void Cancel_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

		private void btnVerify_Click(object sender, System.EventArgs e)
		{
		
			ACMS.ACMSBranch.BranchTransaction.frmVerifyEmployee myform;
			myform = new ACMS.ACMSBranch.BranchTransaction.frmVerifyEmployee(ShiftID,terminalUser.NTerminalID,oUser.StrBranchCode(),txtCF.Text,ShiftDate);
			myform.ShowDialog();


		/*	int output;
			output = 0;

			SqlHelper.ExecuteNonQuery(connection,"up_VerifyShift",
				new SqlParameter("@Amount",output),
				new SqlParameter("@UserID",oUser.NEmployeeID()),								
				new SqlParameter("@Amount",this.txtCF.Text),								
				new SqlParameter("@ShiftID",ShiftID)
				);

			DataSet _ds = new DataSet();
			DataTable dt;
						
			string strSQL = "Select dtDate from tbLShift Where nShiftID = " + ShiftID;

			SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			
			dt = _ds.Tables["Table"];

			SqlHelper.ExecuteNonQuery(connection,"In_tblAudit",
				new SqlParameter("@retval",output),
				new SqlParameter("@ShiftDate",dt.Rows[0]["dtDate"].ToString()),
				new SqlParameter("@BranchCode",oUser.StrBranchCode()),
				new SqlParameter("@ShiftID",ShiftID),
				new SqlParameter("@TerminalID",terminalUser.NTerminalID),
				new SqlParameter("@UserID",oUser.NEmployeeID()),
				new SqlParameter("@AuditEntry","Close Shift " + ShiftID)
				);
*/
			this.Dispose();
		}

		private void txtDepositMoney_EditValueChanged(object sender, System.EventArgs e)
		{
			decimal txtDM;
		decimal OF = Convert.ToDecimal(txtOF.Text);
			decimal CS = Convert.ToDecimal(txtCS.Text);

			if (txtDepositMoney.Text.IndexOf(".") == txtDepositMoney.Text.Length - 1)
				txtDepositMoney.Text = txtDepositMoney.Text + "00";


			if (txtDepositMoney.Text == "")
				txtDM = 0;
			else
				txtDM = Convert.ToDecimal(txtDepositMoney.Text);

			decimal DM = Convert.ToDecimal(txtDM);
			decimal Total;

			//txtOF.Text = txtOF.Text + txtCS.Text - txtDepositMoney.Text;
			Total = OF + CS - DM; 
			
			if (Total < 0)
				Total = 0;

			this.txtCF.Text = Total.ToString();
			int i = txtCF.Text.IndexOf(".");
			if (txtCF.Text.IndexOf(".") == txtCF.Text.Length - 1)
				txtCF.Text = txtCF.Text + "00";
		}

		private void txtDepositMoney_MouseLeave(object sender, System.EventArgs e)
		{
	
		}

		private void txtDepositMoney_Leave(object sender, System.EventArgs e)
		{
			string Deposit = txtDepositMoney.Text;
			Deposit = Deposit + "0000";
			if (txtDepositMoney.Text.IndexOf(".") == txtDepositMoney.Text.Length - 1)
				txtDepositMoney.Text = txtDepositMoney.Text + "0000";
		}
	}
}

