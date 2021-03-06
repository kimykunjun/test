using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Configuration;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

//using Rp = Acms.Core.Repository;
//using Fc = Acms.Core.Factory;
using Do = Acms.Core.Domain;
using ACMSLogic;

namespace ACMS.ACMSBranch.BranchTransaction
{
	/// <summary>
	/// Summary description for XtraForm1.
	/// </summary>
	public class LoginOpenShift : DevExpress.XtraEditors.XtraForm
	{
		private Do.Employee employee;
		private Do.TerminalUser terminalUser; 
		User oUser;
		private string connectionString;
		private SqlConnection connection;
		private DevExpress.XtraEditors.GroupControl groupControl1;
		private DevExpress.XtraEditors.MemoEdit strRemarks;
		private System.Windows.Forms.Label lblRemark;
		private DevExpress.XtraEditors.TextEdit txtNumLockerBal;
		private DevExpress.XtraEditors.TextEdit txtMineralWaterBalance;
		private DevExpress.XtraEditors.TextEdit txtCashOpeningFLoat;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblCashOpeningFloat;
		private System.Windows.Forms.Label label2;
		internal DevExpress.XtraEditors.SimpleButton Open;
		private int ShiftID;
		private decimal OpeningFloat;
		private bool OpenShift = false;
        public string strLang = "";
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        public LoginOpenShift(string strLanguage)
		{
			//
			// Required for Windows Form Designer support
			//
            SetLanguage(strLanguage);

            if (strLanguage == "CN")
            InitializeCNComponent();
            else
			InitializeComponent();

			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
        private void SetLanguage(string Languange)
        {
            strLang = Languange;
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
            this.strRemarks = new DevExpress.XtraEditors.MemoEdit();
            this.lblRemark = new System.Windows.Forms.Label();
            this.txtNumLockerBal = new DevExpress.XtraEditors.TextEdit();
            this.txtMineralWaterBalance = new DevExpress.XtraEditors.TextEdit();
            this.txtCashOpeningFLoat = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCashOpeningFloat = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Open = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.strRemarks.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumLockerBal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMineralWaterBalance.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCashOpeningFLoat.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupControl1.Controls.Add(this.strRemarks);
            this.groupControl1.Controls.Add(this.lblRemark);
            this.groupControl1.Controls.Add(this.txtNumLockerBal);
            this.groupControl1.Controls.Add(this.txtMineralWaterBalance);
            this.groupControl1.Controls.Add(this.txtCashOpeningFLoat);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.lblCashOpeningFloat);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.Open);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(408, 244);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "groupControl1";
            // 
            // strRemarks
            // 
            this.strRemarks.EditValue = "";
            this.strRemarks.Location = new System.Drawing.Point(176, 112);
            this.strRemarks.Name = "strRemarks";
            this.strRemarks.Size = new System.Drawing.Size(216, 80);
            this.strRemarks.TabIndex = 7;
            // 
            // lblRemark
            // 
            this.lblRemark.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemark.Location = new System.Drawing.Point(16, 120);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(152, 72);
            this.lblRemark.TabIndex = 6;
            this.lblRemark.Text = "Remark";
            this.lblRemark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNumLockerBal
            // 
            this.txtNumLockerBal.EditValue = 0;
            this.txtNumLockerBal.Location = new System.Drawing.Point(176, 80);
            this.txtNumLockerBal.Name = "txtNumLockerBal";
            this.txtNumLockerBal.Properties.Mask.EditMask = "f0";
            this.txtNumLockerBal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtNumLockerBal.Properties.ReadOnly = true;
            this.txtNumLockerBal.Size = new System.Drawing.Size(100, 20);
            this.txtNumLockerBal.TabIndex = 5;
            // 
            // txtMineralWaterBalance
            // 
            this.txtMineralWaterBalance.EditValue = "0";
            this.txtMineralWaterBalance.Location = new System.Drawing.Point(176, 48);
            this.txtMineralWaterBalance.Name = "txtMineralWaterBalance";
            this.txtMineralWaterBalance.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtMineralWaterBalance.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtMineralWaterBalance.Properties.Mask.EditMask = "n0";
            this.txtMineralWaterBalance.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtMineralWaterBalance.Properties.ReadOnly = true;
            this.txtMineralWaterBalance.Size = new System.Drawing.Size(100, 20);
            this.txtMineralWaterBalance.TabIndex = 4;
            // 
            // txtCashOpeningFLoat
            // 
            this.txtCashOpeningFLoat.EditValue = "0.00";
            this.txtCashOpeningFLoat.Location = new System.Drawing.Point(176, 16);
            this.txtCashOpeningFLoat.Name = "txtCashOpeningFLoat";
            this.txtCashOpeningFLoat.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtCashOpeningFLoat.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtCashOpeningFLoat.Properties.Mask.BeepOnError = true;
            this.txtCashOpeningFLoat.Properties.Mask.EditMask = "[0-9]+\\.[0-9][0-9]";
            this.txtCashOpeningFLoat.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtCashOpeningFLoat.Properties.Mask.ShowPlaceHolders = false;
            this.txtCashOpeningFLoat.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtCashOpeningFLoat.Properties.ReadOnly = true;
            this.txtCashOpeningFLoat.Size = new System.Drawing.Size(100, 20);
            this.txtCashOpeningFLoat.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mineral Water Balance";
            // 
            // lblCashOpeningFloat
            // 
            this.lblCashOpeningFloat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashOpeningFloat.Location = new System.Drawing.Point(16, 16);
            this.lblCashOpeningFloat.Name = "lblCashOpeningFloat";
            this.lblCashOpeningFloat.Size = new System.Drawing.Size(112, 23);
            this.lblCashOpeningFloat.TabIndex = 0;
            this.lblCashOpeningFloat.Text = "Cash Opening Point";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Number of Lock Balance";
            // 
            // Open
            // 
            this.Open.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Open.Appearance.Options.UseFont = true;
            this.Open.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.Open.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Open.Location = new System.Drawing.Point(320, 216);
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(72, 20);
            this.Open.TabIndex = 5;
            this.Open.Text = "Open";
            this.Open.Click += new System.EventHandler(this.Open_Click);
            // 
            // LoginOpenShift
            // 
            this.AcceptButton = this.Open;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(408, 244);
            this.ControlBox = false;
            this.Controls.Add(this.groupControl1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginOpenShift";
            this.Text = "Open Shift";
            this.Load += new System.EventHandler(this.XtraForm1_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.LoginOpenShift_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.strRemarks.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumLockerBal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMineralWaterBalance.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCashOpeningFLoat.Properties)).EndInit();
            this.ResumeLayout(false);

		}
        private void InitializeCNComponent()
        {
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.strRemarks = new DevExpress.XtraEditors.MemoEdit();
            this.lblRemark = new System.Windows.Forms.Label();
            this.txtNumLockerBal = new DevExpress.XtraEditors.TextEdit();
            this.txtMineralWaterBalance = new DevExpress.XtraEditors.TextEdit();
            this.txtCashOpeningFLoat = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCashOpeningFloat = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Open = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.strRemarks.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumLockerBal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMineralWaterBalance.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCashOpeningFLoat.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupControl1.Controls.Add(this.strRemarks);
            this.groupControl1.Controls.Add(this.lblRemark);
            this.groupControl1.Controls.Add(this.txtNumLockerBal);
            this.groupControl1.Controls.Add(this.txtMineralWaterBalance);
            this.groupControl1.Controls.Add(this.txtCashOpeningFLoat);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.lblCashOpeningFloat);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.Open);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(408, 244);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "groupControl1";
            // 
            // strRemarks
            // 
            this.strRemarks.EditValue = "";
            this.strRemarks.Location = new System.Drawing.Point(176, 112);
            this.strRemarks.Name = "strRemarks";
            this.strRemarks.Size = new System.Drawing.Size(216, 80);
            this.strRemarks.TabIndex = 7;
            // 
            // lblRemark
            // 
            this.lblRemark.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemark.Location = new System.Drawing.Point(16, 120);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(152, 72);
            this.lblRemark.TabIndex = 6;
            this.lblRemark.Text = " 注释";
            this.lblRemark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNumLockerBal
            // 
            this.txtNumLockerBal.EditValue = 0;
            this.txtNumLockerBal.Location = new System.Drawing.Point(176, 80);
            this.txtNumLockerBal.Name = "txtNumLockerBal";
            this.txtNumLockerBal.Properties.Mask.EditMask = "f0";
            this.txtNumLockerBal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtNumLockerBal.Properties.ReadOnly = true;
            this.txtNumLockerBal.Size = new System.Drawing.Size(100, 20);
            this.txtNumLockerBal.TabIndex = 5;
            // 
            // txtMineralWaterBalance
            // 
            this.txtMineralWaterBalance.EditValue = "0";
            this.txtMineralWaterBalance.Location = new System.Drawing.Point(176, 48);
            this.txtMineralWaterBalance.Name = "txtMineralWaterBalance";
            this.txtMineralWaterBalance.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtMineralWaterBalance.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtMineralWaterBalance.Properties.Mask.EditMask = "n0";
            this.txtMineralWaterBalance.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtMineralWaterBalance.Properties.ReadOnly = true;
            this.txtMineralWaterBalance.Size = new System.Drawing.Size(100, 20);
            this.txtMineralWaterBalance.TabIndex = 4;
            // 
            // txtCashOpeningFLoat
            // 
            this.txtCashOpeningFLoat.EditValue = "0.00";
            this.txtCashOpeningFLoat.Location = new System.Drawing.Point(176, 16);
            this.txtCashOpeningFLoat.Name = "txtCashOpeningFLoat";
            this.txtCashOpeningFLoat.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtCashOpeningFLoat.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtCashOpeningFLoat.Properties.Mask.BeepOnError = true;
            this.txtCashOpeningFLoat.Properties.Mask.EditMask = "[0-9]+\\.[0-9][0-9]";
            this.txtCashOpeningFLoat.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtCashOpeningFLoat.Properties.Mask.ShowPlaceHolders = false;
            this.txtCashOpeningFLoat.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtCashOpeningFLoat.Properties.ReadOnly = true;
            this.txtCashOpeningFLoat.Size = new System.Drawing.Size(100, 20);
            this.txtCashOpeningFLoat.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mineral Water Balance";
            // 
            // lblCashOpeningFloat
            // 
            this.lblCashOpeningFloat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashOpeningFloat.Location = new System.Drawing.Point(16, 16);
            this.lblCashOpeningFloat.Name = "lblCashOpeningFloat";
            this.lblCashOpeningFloat.Size = new System.Drawing.Size(112, 23);
            this.lblCashOpeningFloat.TabIndex = 0;
            this.lblCashOpeningFloat.Text = "Cash Opening Point";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Number of Lock Balance";
            // 
            // Open
            // 
            this.Open.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Open.Appearance.Options.UseFont = true;
            this.Open.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.Open.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Open.Location = new System.Drawing.Point(320, 216);
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(72, 20);
            this.Open.TabIndex = 5;
            this.Open.Text = "Open";
            this.Open.Click += new System.EventHandler(this.Open_Click);
            // 
            // LoginOpenShift
            // 
            this.AcceptButton = this.Open;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(408, 244);
            this.ControlBox = false;
            this.Controls.Add(this.groupControl1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginOpenShift";
            this.Text = "Open Shift";
            this.Load += new System.EventHandler(this.XtraForm1_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.LoginOpenShift_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.strRemarks.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumLockerBal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMineralWaterBalance.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCashOpeningFLoat.Properties)).EndInit();
            this.ResumeLayout(false);

        }
		#endregion

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

		private void XtraForm1_Load(object sender, System.EventArgs e)
		{
			DataSet _ds = new DataSet();
			DataTable dt;

			string strSQL;
			//strSQL = "select top 1 * from tblshift where strBranchCode = '" + oUser.StrBranchCode() + "' and nTerminalID = " + terminalUser.NTerminalID + " and convert(varchar,dtDate,111)= '" + DateTime.Today.ToString("yyyy/MM/dd") + "' And dtCloseTime is not null order by dtclosetime desc";
            strSQL = "select top 1 * from tblshift where strBranchCode = '" + oUser.StrBranchCode() + 
                        "' and nTerminalID = " + terminalUser.NTerminalID +
                        " and Convert(date,dtDate,101) = CONVERT(date,getdate(),101) And dtCloseTime is not null order by dtclosetime desc";
			SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			dt = _ds.Tables["Table"];
			if (dt.Rows.Count > 0) 
			{
				ShiftID = Convert.ToInt32(dt.Rows[0]["nShiftID"]) + 1;
				OpeningFloat = Convert.ToDecimal(dt.Rows[0]["mClosingFloat"]);
				txtCashOpeningFLoat.Text = dt.Rows[0]["mClosingFloat"].ToString();
			}
			else
			{
				strSQL = "select top 1 * from tblshift where strBranchCode = '" + oUser.StrBranchCode() + "' and nTerminalID = " + terminalUser.NTerminalID + " and dtCloseTime is not null order by dtclosetime desc";
				SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
				dt = _ds.Tables["Table"];
					
				if (dt.Rows.Count > 0)
				{
					ShiftID = 1;
					OpeningFloat = Convert.ToDecimal(dt.Rows[0]["mClosingFloat"]);
					txtCashOpeningFLoat.Text = Convert.ToDecimal(dt.Rows[0]["mClosingFloat"]).ToString();
				}
				else
				{
					ShiftID = 1;
					OpeningFloat = 0;
					txtCashOpeningFLoat.Text = "0.00";
				}
			}
					
			if (txtCashOpeningFLoat.Text.IndexOf(".") == txtCashOpeningFLoat.Text.Length - 1)
				txtCashOpeningFLoat.Text = txtCashOpeningFLoat.Text + "00";

			//strSQL = "Select nQuantity from tblProductInventory Where strBranchCode = '" + oUser.StrBranchCode() + "' and strProductCode = 'MW' ";
            			
			_ds = new DataSet();
			dt = new DataTable();
            SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "dw_sp_SCStockReconItem", _ds, new string[] { "Table" }, new SqlParameter("@BranchCode", oUser.StrBranchCode()), new SqlParameter("@strProductCode", "MW"));

			//SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			
			dt = _ds.Tables["Table"];

			if (dt.Rows.Count > 0)
			{this.txtMineralWaterBalance.Text = dt.Rows[0]["nQty"].ToString();}

			strSQL = "select Count(*) as CountLock from tblLocker Where nStatusID = 0 And strBranchCode = '" + oUser.StrBranchCode() + "'";

			_ds = new DataSet();
			dt = new DataTable();
			SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			
			dt = _ds.Tables["Table"];
			if (dt.Rows.Count > 0)
			{this.txtNumLockerBal.Text = dt.Rows[0]["CountLock"].ToString();}
		}

		private void Open_Click(object sender, System.EventArgs e)
		{
			int output;
			output = 0;


			SqlHelper.ExecuteNonQuery(connection,"In_tblShift",
				new SqlParameter("@retval",output),
				new SqlParameter("@BranchCode",oUser.StrBranchCode()),								
				new SqlParameter("@TerminalID",terminalUser.NTerminalID),
				new SqlParameter("@ShiftID",ShiftID),
				new SqlParameter("@UserID",oUser.NEmployeeID()),
				new SqlParameter("@OpeningFloat",OpeningFloat),
				new SqlParameter("@Remarks",strRemarks.Text)
				);


			DataSet _ds = new DataSet();
			//DataTable dt;
						
			//string strS strSQL = "Select dtDate from tbLShift Where nShiftID = " + ShiftID + " And nTerminalID = " + terminalUser.NTerminalID + " And strBranchCode = '" + oUser.StrBranchCode + "'";
			//
			//			SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			//			
			//			dt = _ds.Tables["Table"];

			SqlHelper.ExecuteNonQuery(connection,"In_tblAudit",
				new SqlParameter("@retval",output),
				new SqlParameter("@ShiftDate",string.Format("{0:dd/MM/yyyy}",DateTime.Today)),
				new SqlParameter("@BranchCode",oUser.StrBranchCode()),
				new SqlParameter("@ShiftID",ShiftID),
				new SqlParameter("@TerminalID",terminalUser.NTerminalID),
				new SqlParameter("@UserID",oUser.NEmployeeID()),
				new SqlParameter("@AuditEntry","Open Shift " + ShiftID)
				);

			OpenShift = true;
			this.Dispose();
		}

	

		private void Cancel_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

        private void LoginOpenShift_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (OpenShift == false)
                Application.Exit();
        }



    }
}

