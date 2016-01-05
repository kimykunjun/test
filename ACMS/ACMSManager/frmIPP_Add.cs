using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using dal = ACMSDAL;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using ACMSLogic;


namespace ACMS
{
	/// <summary>
	/// Summary description for frmIPP_Add.
	/// </summary>
	public class frmIPP_Add : System.Windows.Forms.Form
	{
		public ACMSLogic.IPP IPPs;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		//private MemberRecord myMemberRecord;
		private System.ComponentModel.Container components = null;
		private string connectionString;
		private DevExpress.XtraEditors.GroupControl groupHdrIPP;
		private DevExpress.XtraEditors.GroupControl grpControlIPP;
		private System.Windows.Forms.Label label1;
		internal DevExpress.XtraEditors.SimpleButton btnSave;
		internal DevExpress.XtraEditors.TextEdit txtCreditCard;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label CreditCard;
		private DevExpress.XtraEditors.SimpleButton btnIPPCancel;
		private System.Windows.Forms.Label label3;
		internal DevExpress.XtraEditors.TextEdit txtMerchantNo;
		private System.Windows.Forms.Label ToolTips;
		private DevExpress.XtraEditors.ImageComboBoxEdit IPPNMonths;
		private SqlConnection connection;

		private DevExpress.XtraEditors.LookUpEdit luedtBank;
		private DevExpress.XtraEditors.LookUpEdit luedtBranch;
		private System.Windows.Forms.Label label6;
		private DevExpress.XtraEditors.DateEdit dateEdit1;
		private ACMS.ucMemberID ucMemberID1;
		private string strTerminalBranchCode;
		
		public frmIPP_Add(ACMSLogic.IPP Ipp, string aTerminalBranchCode)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);
			IPPs = Ipp;
			strTerminalBranchCode = aTerminalBranchCode;

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			ucMemberID1.StrBranchCode = aTerminalBranchCode;
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
			this.groupHdrIPP = new DevExpress.XtraEditors.GroupControl();
			this.grpControlIPP = new DevExpress.XtraEditors.GroupControl();
			this.ucMemberID1 = new ACMS.ucMemberID();
			this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
			this.label6 = new System.Windows.Forms.Label();
			this.luedtBranch = new DevExpress.XtraEditors.LookUpEdit();
			this.luedtBank = new DevExpress.XtraEditors.LookUpEdit();
			this.IPPNMonths = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.ToolTips = new System.Windows.Forms.Label();
			this.txtMerchantNo = new DevExpress.XtraEditors.TextEdit();
			this.label3 = new System.Windows.Forms.Label();
			this.btnIPPCancel = new DevExpress.XtraEditors.SimpleButton();
			this.label1 = new System.Windows.Forms.Label();
			this.btnSave = new DevExpress.XtraEditors.SimpleButton();
			this.txtCreditCard = new DevExpress.XtraEditors.TextEdit();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.CreditCard = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.groupHdrIPP)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grpControlIPP)).BeginInit();
			this.grpControlIPP.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.luedtBranch.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.luedtBank.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.IPPNMonths.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtMerchantNo.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCreditCard.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// groupHdrIPP
			// 
			this.groupHdrIPP.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.groupHdrIPP.Appearance.Options.UseBackColor = true;
			this.groupHdrIPP.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.groupHdrIPP.Location = new System.Drawing.Point(0, -1);
			this.groupHdrIPP.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.groupHdrIPP.LookAndFeel.UseDefaultLookAndFeel = false;
			this.groupHdrIPP.Name = "groupHdrIPP";
			this.groupHdrIPP.Size = new System.Drawing.Size(472, 8);
			this.groupHdrIPP.TabIndex = 26;
			this.groupHdrIPP.Text = "groupControl1";
			// 
			// grpControlIPP
			// 
			this.grpControlIPP.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.grpControlIPP.Controls.Add(this.ucMemberID1);
			this.grpControlIPP.Controls.Add(this.dateEdit1);
			this.grpControlIPP.Controls.Add(this.label6);
			this.grpControlIPP.Controls.Add(this.luedtBranch);
			this.grpControlIPP.Controls.Add(this.luedtBank);
			this.grpControlIPP.Controls.Add(this.IPPNMonths);
			this.grpControlIPP.Controls.Add(this.ToolTips);
			this.grpControlIPP.Controls.Add(this.txtMerchantNo);
			this.grpControlIPP.Controls.Add(this.label3);
			this.grpControlIPP.Controls.Add(this.btnIPPCancel);
			this.grpControlIPP.Controls.Add(this.label1);
			this.grpControlIPP.Controls.Add(this.btnSave);
			this.grpControlIPP.Controls.Add(this.txtCreditCard);
			this.grpControlIPP.Controls.Add(this.label5);
			this.grpControlIPP.Controls.Add(this.label4);
			this.grpControlIPP.Controls.Add(this.label2);
			this.grpControlIPP.Controls.Add(this.CreditCard);
			this.grpControlIPP.Location = new System.Drawing.Point(0, 0);
			this.grpControlIPP.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.grpControlIPP.LookAndFeel.UseDefaultLookAndFeel = false;
			this.grpControlIPP.Name = "grpControlIPP";
			this.grpControlIPP.ShowCaption = false;
			this.grpControlIPP.Size = new System.Drawing.Size(472, 264);
			this.grpControlIPP.TabIndex = 0;
			this.grpControlIPP.Text = "groupControl1";
			// 
			// ucMemberID1
			// 
			this.ucMemberID1.EditValue = "";
			this.ucMemberID1.EditValueChanged = null;
			this.ucMemberID1.Location = new System.Drawing.Point(216, 24);
			this.ucMemberID1.Name = "ucMemberID1";
			this.ucMemberID1.Size = new System.Drawing.Size(182, 20);
			this.ucMemberID1.StrBranchCode = null;
			this.ucMemberID1.TabIndex = 168;
			// 
			// dateEdit1
			// 
			this.dateEdit1.EditValue = null;
			this.dateEdit1.Location = new System.Drawing.Point(216, 176);
			this.dateEdit1.Name = "dateEdit1";
			// 
			// dateEdit1.Properties
			// 
			this.dateEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
			this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dateEdit1.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.dateEdit1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.dateEdit1.Properties.EditFormat.FormatString = "dd/MM/yyyy";
			this.dateEdit1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.dateEdit1.Properties.Mask.EditMask = "dd/MM/yyyy";
			this.dateEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
			this.dateEdit1.Size = new System.Drawing.Size(128, 22);
			this.dateEdit1.TabIndex = 167;
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label6.Location = new System.Drawing.Point(32, 176);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(120, 16);
			this.label6.TabIndex = 166;
			this.label6.Text = "Created Date";
			// 
			// luedtBranch
			// 
			this.luedtBranch.Location = new System.Drawing.Point(216, 72);
			this.luedtBranch.Name = "luedtBranch";
			// 
			// luedtBranch.Properties
			// 
			this.luedtBranch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
			this.luedtBranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.luedtBranch.Size = new System.Drawing.Size(168, 22);
			this.luedtBranch.TabIndex = 2;
			this.luedtBranch.EditValueChanged += new System.EventHandler(this.luedtBranch_EditValueChanged);
			// 
			// luedtBank
			// 
			this.luedtBank.Location = new System.Drawing.Point(216, 48);
			this.luedtBank.Name = "luedtBank";
			// 
			// luedtBank.Properties
			// 
			this.luedtBank.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
			this.luedtBank.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.luedtBank.Size = new System.Drawing.Size(168, 22);
			this.luedtBank.TabIndex = 1;
			this.luedtBank.EditValueChanged += new System.EventHandler(this.luedtBank_EditValueChanged);
			// 
			// IPPNMonths
			// 
			this.IPPNMonths.Location = new System.Drawing.Point(216, 144);
			this.IPPNMonths.Name = "IPPNMonths";
			// 
			// IPPNMonths.Properties
			// 
			this.IPPNMonths.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
			this.IPPNMonths.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.IPPNMonths.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.IPPNMonths.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.IPPNMonths.Size = new System.Drawing.Size(168, 22);
			this.IPPNMonths.TabIndex = 5;
			// 
			// ToolTips
			// 
			this.ToolTips.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ToolTips.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.ToolTips.Location = new System.Drawing.Point(216, 8);
			this.ToolTips.Name = "ToolTips";
			this.ToolTips.Size = new System.Drawing.Size(184, 16);
			this.ToolTips.TabIndex = 165;
			this.ToolTips.Text = "Use Member Search Tools for Input";
			this.ToolTips.Visible = false;
			// 
			// txtMerchantNo
			// 
			this.txtMerchantNo.AllowDrop = true;
			this.txtMerchantNo.EditValue = "";
			this.txtMerchantNo.Enabled = false;
			this.txtMerchantNo.Location = new System.Drawing.Point(216, 96);
			this.txtMerchantNo.Name = "txtMerchantNo";
			// 
			// txtMerchantNo.Properties
			// 
			this.txtMerchantNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtMerchantNo.Properties.Appearance.Options.UseFont = true;
			this.txtMerchantNo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
			this.txtMerchantNo.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.txtMerchantNo.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.txtMerchantNo.Properties.MaxLength = 19;
			this.txtMerchantNo.Properties.ReadOnly = true;
			this.txtMerchantNo.Size = new System.Drawing.Size(168, 22);
			this.txtMerchantNo.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(32, 96);
			this.label3.Name = "label3";
			this.label3.TabIndex = 163;
			this.label3.Text = "Merchant No";
			// 
			// btnIPPCancel
			// 
			this.btnIPPCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnIPPCancel.Location = new System.Drawing.Point(384, 208);
			this.btnIPPCancel.Name = "btnIPPCancel";
			this.btnIPPCancel.TabIndex = 7;
			this.btnIPPCancel.Text = "Cancel";
			this.btnIPPCancel.Click += new System.EventHandler(this.btnIPPCancel_Click);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(32, 72);
			this.label1.Name = "label1";
			this.label1.TabIndex = 34;
			this.label1.Text = "Branch Code";
			// 
			// btnSave
			// 
			this.btnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnSave.Location = new System.Drawing.Point(296, 208);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(80, 24);
			this.btnSave.TabIndex = 6;
			this.btnSave.Text = "Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// txtCreditCard
			// 
			this.txtCreditCard.AllowDrop = true;
			this.txtCreditCard.EditValue = "____-____-____-____";
			this.txtCreditCard.Location = new System.Drawing.Point(216, 120);
			this.txtCreditCard.Name = "txtCreditCard";
			// 
			// txtCreditCard.Properties
			// 
			this.txtCreditCard.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtCreditCard.Properties.Appearance.Options.UseFont = true;
			this.txtCreditCard.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
			this.txtCreditCard.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.txtCreditCard.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.txtCreditCard.Properties.Mask.EditMask = "\\d{4}-\\d{4}-\\d{4}-\\d{4}";
			this.txtCreditCard.Properties.Mask.IgnoreMaskBlank = false;
			this.txtCreditCard.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular;
			this.txtCreditCard.Properties.MaxLength = 19;
			this.txtCreditCard.Size = new System.Drawing.Size(168, 22);
			this.txtCreditCard.TabIndex = 4;
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.Location = new System.Drawing.Point(32, 24);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(104, 23);
			this.label5.TabIndex = 30;
			this.label5.Text = "Member ID";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.Location = new System.Drawing.Point(32, 48);
			this.label4.Name = "label4";
			this.label4.TabIndex = 28;
			this.label4.Text = "Bank Code";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(32, 144);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(120, 16);
			this.label2.TabIndex = 27;
			this.label2.Text = "Number of Months";
			// 
			// CreditCard
			// 
			this.CreditCard.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.CreditCard.Location = new System.Drawing.Point(32, 120);
			this.CreditCard.Name = "CreditCard";
			this.CreditCard.TabIndex = 26;
			this.CreditCard.Text = "Credit Card No";
			// 
			// frmIPP_Add
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(472, 238);
			this.Controls.Add(this.grpControlIPP);
			this.Controls.Add(this.groupHdrIPP);
			this.Name = "frmIPP_Add";
			this.Text = "IPP Details";
			this.Load += new System.EventHandler(this.frmIPP_Add_Load);
			((System.ComponentModel.ISupportInitialize)(this.groupHdrIPP)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grpControlIPP)).EndInit();
			this.grpControlIPP.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.luedtBranch.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.luedtBank.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.IPPNMonths.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtMerchantNo.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCreditCard.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void frmIPP_Add_Load(object sender, System.EventArgs e)
		{
			string strSQL;

			strSQL="select * from tblBank";
			DataTable dt = new ACMS.Utils.Common().ExecuteQuery(strSQL);
			new ACMS.XtraUtils.LookupEditBuilder.ManagerBankLookupEditBuilder(dt, luedtBank.Properties);

			
			strSQL="select * from tblBranch";
			dt = new ACMS.Utils.Common().ExecuteQuery(strSQL);
			new ACMS.XtraUtils.LookupEditBuilder.ManagerBranchCodeLookupEditBuilder(dt, luedtBranch.Properties);

			dateEdit1.EditValue = DateTime.Now.Date;
	
		}


		private void btnSave_Click(object sender, System.EventArgs e)
		{
			int output;
			output = 0;
			int nMonths;

			if (ucMemberID1.EditValue.ToString().Length == 0)
			{
				MessageBox.Show("Membership Id is required.");
				ucMemberID1.Focus();
				return;
			}

            if (this.IPPNMonths.EditValue.ToString() == "")
				nMonths = Convert.ToInt32(null);
			else
				nMonths = Convert.ToInt32(this.IPPNMonths.EditValue);

			if (luedtBank.EditValue == null)
			{
				MessageBox.Show("Please select a Bank.");
				luedtBank.Focus();
				return;
			}

			if (luedtBranch.EditValue == null)
			{
				MessageBox.Show("Please select a Branch.");
				luedtBranch.Focus();
				return;
			}

			try 
			{
				SqlHelper.ExecuteNonQuery(connection,"up_tblIPP",
					new SqlParameter("@RET_VAL",output),
					new SqlParameter("@cmd","I"),
					new SqlParameter("@nIPPID",null),
					new SqlParameter("@strMembershipID",ucMemberID1.EditValue.ToString()),
					new SqlParameter("@dtDate",Convert.ToDateTime(dateEdit1.EditValue) ),
					new SqlParameter("@strBranchCode",luedtBranch.EditValue.ToString() ),
					new SqlParameter("@strBankCode",luedtBank.EditValue.ToString() ),
					new SqlParameter("@nMonths",nMonths),
					new SqlParameter("@strCreditCardNo",this.txtCreditCard.Text.Replace("-","") ),
					new SqlParameter("@strMerchantNo",this.txtMerchantNo.Text ),
					new SqlParameter("@dtSentDate",null ),
					new SqlParameter("@dtReceivedDate",null),
					new SqlParameter("@nIPPStatus",Convert.ToInt32("0") )
					
				
					);
			}
			catch (SqlException ex)
			{
				if (ex.Message.IndexOf("FK_tblIPP_tblMember") >= 0)
				{
					MessageBox.Show("Please enter a correct Member ID.");
					ucMemberID1.Focus();
					return;
				}
			}
			
			this.Close();
		}

		private void btnSave_Click_1(object sender, System.EventArgs e)
		{
			MessageBox.Show("Record Has Been Saved", "Save");
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void btnIPPCancel_Click(object sender, System.EventArgs e)
		{
			this.Dispose(true);
		}


		private void LoadMerchantNo()
		{
			string strSQL;
			DataSet _ds;

			txtMerchantNo.EditValue = "";
			IPPNMonths.Properties.Items.Clear();

			try
			{
				if ((luedtBank.EditValue != null || luedtBank.EditValue.ToString().Length != 0) && (luedtBranch.EditValue != null || luedtBranch.EditValue.ToString().Length != 0))
				{
					strSQL="select * from tblBanklPPMerchant Where strBankCode = '" + luedtBank.EditValue + "' And strBranchCode = '" + luedtBranch.EditValue + "'";
					_ds = new DataSet();
					SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
					//cbReceipient
					DataTable dt =_ds.Tables["table"];
					if (dt.Rows.Count > 0)
						txtMerchantNo.EditValue = dt.Rows[0]["strMerchantNo"].ToString();



					strSQL = "Select distinct nMonth from tblBanklPPMerchant Where strBankCode = '" + luedtBank.EditValue + "' And strBranchCode = '" + luedtBranch.EditValue + "'";

					comboBind(IPPNMonths, strSQL, "nMonth", "nMonth", true);
					IPPNMonths.Properties.Items.Insert(0,new DevExpress.XtraEditors.Controls.ImageComboBoxItem("- Please Select -",""));
					IPPNMonths.SelectedIndex = 0;
				}
			}
			catch 
			{}
		}

		private void comboBind(DevExpress.XtraEditors.ImageComboBoxEdit control,string strSQL,string display,string strValue,bool fNum)
		{
		
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox properties = control.Properties;
			properties.Items.BeginUpdate();
			properties.Items.Clear();

			try 
			{
				foreach(DataRow dr in _ds.Tables["Table"].Rows)
				{
					//Initialize each item with the display text, value and image index
					properties.Items.Add( new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr[display].ToString(), dr[strValue],-1));
				}
			}
			finally 
			{
				properties.Items.EndUpdate();
			}
			//Select the first item
			control.SelectedIndex = 0;
		}

		private void luedtBranch_EditValueChanged(object sender, System.EventArgs e)
		{
			LoadMerchantNo();
		}

		private void luedtBank_EditValueChanged(object sender, System.EventArgs e)
		{
			LoadMerchantNo();
		}
	}
}
