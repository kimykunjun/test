using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;

////using Rp = Acms.Core.Repository;
////using Fc = Acms.Core.Factory;
using Do = Acms.Core.Domain;
using ACMSLogic;


namespace ACMS.ACMSBranch.BranchTransaction
{
	/// <summary>
	/// Summary description for frmPaymentCode.
	/// </summary>
	public class frmPaymentCode : System.Windows.Forms.Form
	{
		private Do.Employee employee;
		private Do.TerminalUser terminalUser; 
		User oUser;

		private string connectionString;
		private SqlConnection connection;
		private DevExpress.XtraEditors.TextEdit txtReceiptNo;
		private System.Windows.Forms.Label lblDepositMoney;
		internal DevExpress.XtraEditors.SimpleButton Cancel;
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.ImageComboBoxEdit cmbPaymentMode;
		internal DevExpress.XtraEditors.SimpleButton btnSave;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label2;
		internal DevExpress.XtraEditors.TextEdit txtCreditCard;
		private string ReceiptID;
		private System.Windows.Forms.TextBox txtMode;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtMode1;
		internal DevExpress.XtraEditors.TextEdit txtCreditCard1;
		private System.Windows.Forms.Label label5;
		private DevExpress.XtraEditors.ImageComboBoxEdit cmbPaymentMode1;
		private System.Windows.Forms.Label label6;
		private string PaymentCode;
		private double ExactAmount;

		public frmPaymentCode(string RID)
		{
			//
			// Required for Windows Form Designer support
			//
			ReceiptID = RID;
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
			this.txtReceiptNo = new DevExpress.XtraEditors.TextEdit();
			this.lblDepositMoney = new System.Windows.Forms.Label();
			this.btnSave = new DevExpress.XtraEditors.SimpleButton();
			this.Cancel = new DevExpress.XtraEditors.SimpleButton();
			this.label1 = new System.Windows.Forms.Label();
			this.cmbPaymentMode = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.label2 = new System.Windows.Forms.Label();
			this.txtCreditCard = new DevExpress.XtraEditors.TextEdit();
			this.txtMode = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtMode1 = new System.Windows.Forms.TextBox();
			this.txtCreditCard1 = new DevExpress.XtraEditors.TextEdit();
			this.label5 = new System.Windows.Forms.Label();
			this.cmbPaymentMode1 = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.label6 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.txtReceiptNo.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbPaymentMode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCreditCard.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCreditCard1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbPaymentMode1.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// txtReceiptNo
			// 
			this.txtReceiptNo.EditValue = "";
			this.txtReceiptNo.Enabled = false;
			this.txtReceiptNo.Location = new System.Drawing.Point(168, 16);
			this.txtReceiptNo.Name = "txtReceiptNo";
			// 
			// txtReceiptNo.Properties
			// 
			this.txtReceiptNo.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
			this.txtReceiptNo.Properties.ReadOnly = true;
			this.txtReceiptNo.Size = new System.Drawing.Size(168, 20);
			this.txtReceiptNo.TabIndex = 8;
			// 
			// lblDepositMoney
			// 
			this.lblDepositMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblDepositMoney.Location = new System.Drawing.Point(32, 16);
			this.lblDepositMoney.Name = "lblDepositMoney";
			this.lblDepositMoney.Size = new System.Drawing.Size(112, 23);
			this.lblDepositMoney.TabIndex = 7;
			this.lblDepositMoney.Text = "Receipt No :";
			// 
			// btnSave
			// 
			this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.btnSave.Appearance.Options.UseFont = true;
			this.btnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnSave.Location = new System.Drawing.Point(168, 248);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(80, 20);
			this.btnSave.TabIndex = 9;
			this.btnSave.Text = "Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// Cancel
			// 
			this.Cancel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.Cancel.Appearance.Options.UseFont = true;
			this.Cancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.Cancel.Location = new System.Drawing.Point(256, 248);
			this.Cancel.Name = "Cancel";
			this.Cancel.Size = new System.Drawing.Size(80, 20);
			this.Cancel.TabIndex = 10;
			this.Cancel.Text = "Cancel";
			this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(32, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(112, 23);
			this.label1.TabIndex = 11;
			this.label1.Text = "Payment Mode : ";
			// 
			// cmbPaymentMode
			// 
			this.cmbPaymentMode.Location = new System.Drawing.Point(168, 48);
			this.cmbPaymentMode.Name = "cmbPaymentMode";
			// 
			// cmbPaymentMode.Properties
			// 
			this.cmbPaymentMode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cmbPaymentMode.Size = new System.Drawing.Size(168, 20);
			this.cmbPaymentMode.TabIndex = 12;
			this.cmbPaymentMode.EditValueChanged += new System.EventHandler(this.cmbPaymentMode_EditValueChanged);
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(32, 80);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(112, 23);
			this.label2.TabIndex = 13;
			this.label2.Text = "Credit Card No. :";
			// 
			// txtCreditCard
			// 
			this.txtCreditCard.AllowDrop = true;
			this.txtCreditCard.EditValue = "____-____-____-____";
			this.txtCreditCard.Enabled = false;
			this.txtCreditCard.Location = new System.Drawing.Point(168, 80);
			this.txtCreditCard.Name = "txtCreditCard";
			// 
			// txtCreditCard.Properties
			// 
			this.txtCreditCard.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtCreditCard.Properties.Appearance.Options.UseFont = true;
			this.txtCreditCard.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.txtCreditCard.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.txtCreditCard.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.txtCreditCard.Properties.Mask.EditMask = "\\d{4}-\\d{4}-\\d{4}-\\d{4}";
			this.txtCreditCard.Properties.Mask.IgnoreMaskBlank = false;
			this.txtCreditCard.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular;
			this.txtCreditCard.Properties.MaxLength = 19;
			this.txtCreditCard.Size = new System.Drawing.Size(168, 20);
			this.txtCreditCard.TabIndex = 15;
			// 
			// txtMode
			// 
			this.txtMode.Location = new System.Drawing.Point(168, 112);
			this.txtMode.Name = "txtMode";
			this.txtMode.Size = new System.Drawing.Size(168, 20);
			this.txtMode.TabIndex = 16;
			this.txtMode.Text = "";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(34, 112);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 23);
			this.label3.TabIndex = 17;
			this.label3.Text = "Amount :";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.Location = new System.Drawing.Point(32, 208);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 23);
			this.label4.TabIndex = 23;
			this.label4.Text = "Amount :";
			// 
			// txtMode1
			// 
			this.txtMode1.Location = new System.Drawing.Point(168, 208);
			this.txtMode1.Name = "txtMode1";
			this.txtMode1.Size = new System.Drawing.Size(168, 20);
			this.txtMode1.TabIndex = 22;
			this.txtMode1.Text = "";
			this.txtMode1.TextChanged += new System.EventHandler(this.txtMode1_TextChanged);
			// 
			// txtCreditCard1
			// 
			this.txtCreditCard1.AllowDrop = true;
			this.txtCreditCard1.EditValue = "____-____-____-____";
			this.txtCreditCard1.Enabled = false;
			this.txtCreditCard1.Location = new System.Drawing.Point(168, 176);
			this.txtCreditCard1.Name = "txtCreditCard1";
			// 
			// txtCreditCard1.Properties
			// 
			this.txtCreditCard1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtCreditCard1.Properties.Appearance.Options.UseFont = true;
			this.txtCreditCard1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.txtCreditCard1.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.txtCreditCard1.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.txtCreditCard1.Properties.Mask.EditMask = "\\d{4}-\\d{4}-\\d{4}-\\d{4}";
			this.txtCreditCard1.Properties.Mask.IgnoreMaskBlank = false;
			this.txtCreditCard1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular;
			this.txtCreditCard1.Properties.MaxLength = 19;
			this.txtCreditCard1.Size = new System.Drawing.Size(168, 20);
			this.txtCreditCard1.TabIndex = 21;
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.Location = new System.Drawing.Point(32, 176);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(112, 23);
			this.label5.TabIndex = 20;
			this.label5.Text = "Credit Card No. :";
			// 
			// cmbPaymentMode1
			// 
			this.cmbPaymentMode1.Location = new System.Drawing.Point(168, 144);
			this.cmbPaymentMode1.Name = "cmbPaymentMode1";
			// 
			// cmbPaymentMode1.Properties
			// 
			this.cmbPaymentMode1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cmbPaymentMode1.Size = new System.Drawing.Size(168, 20);
			this.cmbPaymentMode1.TabIndex = 19;
			this.cmbPaymentMode1.EditValueChanged += new System.EventHandler(this.cmbPaymentMode1_EditValueChanged);
			this.cmbPaymentMode1.Click += new System.EventHandler(this.cmbPaymentMode1_Click);
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label6.Location = new System.Drawing.Point(32, 144);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(112, 23);
			this.label6.TabIndex = 18;
			this.label6.Text = "Payment Mode : ";
			// 
			// frmPaymentCode
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(432, 278);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtMode1);
			this.Controls.Add(this.txtCreditCard1);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.cmbPaymentMode1);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtMode);
			this.Controls.Add(this.txtCreditCard);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cmbPaymentMode);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtReceiptNo);
			this.Controls.Add(this.lblDepositMoney);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.Cancel);
			this.Name = "frmPaymentCode";
			this.Text = "Edit Payment Code";
			this.Load += new System.EventHandler(this.frmPaymentCode_Load);
			((System.ComponentModel.ISupportInitialize)(this.txtReceiptNo.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbPaymentMode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCreditCard.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCreditCard1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbPaymentMode1.Properties)).EndInit();
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

		private void btnSave_Click(object sender, System.EventArgs e)
		{			
			if (cmbPaymentMode.EditValue.ToString() != PaymentCode)
			{
				DialogResult result1 = MessageBox.Show(this, "Confirm change payment mode? ", "Confirm", 
					MessageBoxButtons.YesNo);
				if (result1 == DialogResult.Yes)
				{
					Save();
				}
			}
			else
			{
				Save();
			}
			

		}

		private void Save()
		{
			int output;
			output = 0;
			
			string CC = txtCreditCard.EditValue.ToString().Replace("____-____-____-____","");

			if (txtCreditCard.Enabled == true && CC == "")
			{
				MessageBox.Show("Credit Card No. required.","Details");
				return;
			}	
	
			if (txtMode1.Text == "")
			{
				SqlHelper.ExecuteNonQuery(connection,"Up_Get_PaymentCode",
					new SqlParameter("@retval",output),
					new SqlParameter("@PaymentCode",cmbPaymentMode.EditValue),
					new SqlParameter("@ReferenceNo",CC),
					new SqlParameter("@ReceiptID",ReceiptID),
					new SqlParameter("@Amount",txtMode.Text));	
				}
			else 
			{
					SqlHelper.ExecuteNonQuery(connection,"Up_Get_PaymentCode2",
						new SqlParameter("@retval",output),
						new SqlParameter("@PaymentCode",cmbPaymentMode.EditValue),
						new SqlParameter("@ReferenceNo",CC),
						new SqlParameter("@ReceiptID",ReceiptID),
						new SqlParameter("@Amount",txtMode.Text),
						new SqlParameter("@Amount1",txtMode1.Text),
					    new SqlParameter("@PaymentCode1",cmbPaymentMode1.EditValue));	
			}
		

			this.Dispose();
		}

		private void frmPaymentCode_Load(object sender, System.EventArgs e)
		{
			this.txtReceiptNo.Text = ReceiptID;

			string strSQL;

			strSQL = "Select strPaymentCode From TblPayment Where strPaymentGroupCode <> 'IPP'";
			comboBind(cmbPaymentMode, strSQL, "strPaymentCode", "strPaymentCode");
			cmbPaymentMode.Properties.Items.Insert(0,new DevExpress.XtraEditors.Controls.ImageComboBoxItem("- Please Select -",""));
				
			strSQL = "Select strPaymentCode From TblPayment Where strPaymentGroupCode <> 'IPP'";
			comboBind(cmbPaymentMode1, strSQL, "strPaymentCode", "strPaymentCode");
			cmbPaymentMode1.Properties.Items.Insert(0,new DevExpress.XtraEditors.Controls.ImageComboBoxItem("- Please Select -",""));
			
			strSQL = "Select * From TblReceiptPayment Where strReceiptNo = '" + ReceiptID + "'";
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			DataTable dt = _ds.Tables["Table"];
			cmbPaymentMode.EditValue = dt.Rows[0]["strPaymentCode"].ToString();
			cmbPaymentMode1.EditValue = dt.Rows[0]["strPaymentCode"].ToString();
			PaymentCode = dt.Rows[0]["strPaymentCode"].ToString();
			txtCreditCard.EditValue = (dt.Rows[0]["strReferenceNo"].ToString()== "" ? "____-____-____-____" : dt.Rows[0]["strReferenceNo"].ToString());
			ExactAmount = System.Convert.ToDouble(dt.Rows[0]["mAmount"].ToString());
			txtMode.Text = ExactAmount.ToString();

		}

		private void comboBind(DevExpress.XtraEditors.ImageComboBoxEdit control,string strSQL,string display,string strValue)
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
					properties.Items.Add( new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr[display].ToString(), dr[strValue].ToString(),-1));
				}
			}
			finally 
			{
				properties.Items.EndUpdate();
			}
			//Select the first item
			control.SelectedIndex = 0;
		}

		private void Cancel_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

		private void cmbPaymentMode_EditValueChanged(object sender, System.EventArgs e)
		{
			DataSet _ds = new DataSet();
			string strSQL;
			if (cmbPaymentMode.EditValue.ToString() == "")
				return;

			strSQL = "Select strPaymentGroupCode, strPaymentCode From TblPayment Where strPaymentCode = '" + cmbPaymentMode.EditValue + "'";
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			DataTable dt = _ds.Tables["Table"];

			if (dt.Rows[0]["strPaymentGroupCode"].ToString() == "VISA")
			{txtCreditCard.Enabled = true;}	
			else
			{
				txtCreditCard.EditValue = "____-____-____-____";
				txtCreditCard.Enabled = false;	
			}
		}

		private void txtMode1_TextChanged(object sender, System.EventArgs e)
		{				
			 double Amount2 = ExactAmount - System.Convert.ToDouble(txtMode1.Text);
		txtMode.Text = Amount2.ToString();
		}

		private void cmbPaymentMode1_EditValueChanged(object sender, System.EventArgs e)
		{
			DataSet _ds = new DataSet();
			string strSQL;
			if (cmbPaymentMode1.EditValue.ToString() == "")
				return;

			strSQL = "Select strPaymentGroupCode, strPaymentCode From TblPayment Where strPaymentCode = '" + cmbPaymentMode1.EditValue + "'";
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			DataTable dt = _ds.Tables["Table"];

			if (dt.Rows[0]["strPaymentGroupCode"].ToString() == "VISA")
			{txtCreditCard1.Enabled = true;}	
			else
			{
				txtCreditCard1.EditValue = "____-____-____-____";
				txtCreditCard1.Enabled = false;	
			}
		}

		private void cmbPaymentMode1_Click(object sender, System.EventArgs e)
		{
		
		}


	}
}



