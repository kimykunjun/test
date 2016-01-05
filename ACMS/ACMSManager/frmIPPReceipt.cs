using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using dal = ACMSDAL;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;

namespace ACMS
{
	/// <summary>
	/// Summary description for frmIPPReceipt.
	/// </summary>
	public class frmIPPReceipt : System.Windows.Forms.Form
	{
		private string connectionString;
		private SqlConnection connection;

		public ACMSLogic.ReceiptPayment myRP;
		private string IPPId;
		private DevExpress.XtraEditors.GroupControl groupHdrIPP;
		private System.Windows.Forms.Label hdrIPP;
		private DevExpress.XtraEditors.GroupControl groupControl1;
		internal DevExpress.XtraEditors.SimpleButton btnCancel;
		internal DevExpress.XtraEditors.SimpleButton btnSave;
		private System.Windows.Forms.ComboBox ddlIPP;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox ddlReceipt;
		private System.Windows.Forms.Label label4;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmIPPReceipt(string Id)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);
			IPPId = Id;
			myRP = new ACMSLogic.ReceiptPayment();
		
			BindData();
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
			this.groupHdrIPP = new DevExpress.XtraEditors.GroupControl();
			this.hdrIPP = new System.Windows.Forms.Label();
			this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
			this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.btnSave = new DevExpress.XtraEditors.SimpleButton();
			this.ddlIPP = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.ddlReceipt = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.groupHdrIPP)).BeginInit();
			this.groupHdrIPP.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
			this.groupControl1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupHdrIPP
			// 
			this.groupHdrIPP.Appearance.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.groupHdrIPP.Appearance.Options.UseBackColor = true;
			this.groupHdrIPP.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.groupHdrIPP.Controls.Add(this.hdrIPP);
			this.groupHdrIPP.Location = new System.Drawing.Point(0, 0);
			this.groupHdrIPP.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.groupHdrIPP.LookAndFeel.UseDefaultLookAndFeel = false;
			this.groupHdrIPP.Name = "groupHdrIPP";
			this.groupHdrIPP.Size = new System.Drawing.Size(320, 32);
			this.groupHdrIPP.TabIndex = 27;
			this.groupHdrIPP.Text = "groupControl1";
			// 
			// hdrIPP
			// 
			this.hdrIPP.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.hdrIPP.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.hdrIPP.Location = new System.Drawing.Point(0, 8);
			this.hdrIPP.Name = "hdrIPP";
			this.hdrIPP.Size = new System.Drawing.Size(320, 23);
			this.hdrIPP.TabIndex = 1;
			this.hdrIPP.Text = "LINK RECEIPT WITH IPP FORM";
			this.hdrIPP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupControl1
			// 
			this.groupControl1.Controls.Add(this.btnCancel);
			this.groupControl1.Controls.Add(this.btnSave);
			this.groupControl1.Controls.Add(this.ddlIPP);
			this.groupControl1.Controls.Add(this.label5);
			this.groupControl1.Controls.Add(this.ddlReceipt);
			this.groupControl1.Controls.Add(this.label4);
			this.groupControl1.Location = new System.Drawing.Point(-8, 32);
			this.groupControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
			this.groupControl1.Name = "groupControl1";
			this.groupControl1.ShowCaption = false;
			this.groupControl1.Size = new System.Drawing.Size(328, 120);
			this.groupControl1.TabIndex = 28;
			this.groupControl1.Text = "groupControl1";
			// 
			// btnCancel
			// 
			this.btnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnCancel.Location = new System.Drawing.Point(232, 80);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(62, 20);
			this.btnCancel.TabIndex = 31;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnSave
			// 
			this.btnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnSave.Location = new System.Drawing.Point(168, 80);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(62, 20);
			this.btnSave.TabIndex = 30;
			this.btnSave.Text = "Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// ddlIPP
			// 
			this.ddlIPP.Location = new System.Drawing.Point(136, 16);
			this.ddlIPP.Name = "ddlIPP";
			this.ddlIPP.Size = new System.Drawing.Size(160, 21);
			this.ddlIPP.TabIndex = 29;
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label5.Location = new System.Drawing.Point(44, 18);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(76, 23);
			this.label5.TabIndex = 28;
			this.label5.Text = "IPP ID";
			// 
			// ddlReceipt
			// 
			this.ddlReceipt.Location = new System.Drawing.Point(136, 42);
			this.ddlReceipt.Name = "ddlReceipt";
			this.ddlReceipt.Size = new System.Drawing.Size(160, 21);
			this.ddlReceipt.TabIndex = 27;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label4.Location = new System.Drawing.Point(44, 48);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(76, 23);
			this.label4.TabIndex = 26;
			this.label4.Text = "Receipt No";
			// 
			// frmIPPReceipt
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(320, 149);
			this.Controls.Add(this.groupControl1);
			this.Controls.Add(this.groupHdrIPP);
			this.Name = "frmIPPReceipt";
			this.Text = "IPP vs Receipt";
			((System.ComponentModel.ISupportInitialize)(this.groupHdrIPP)).EndInit();
			this.groupHdrIPP.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
			this.groupControl1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void BindData()
		{
			dal.TblIPP IPP = new dal.TblIPP();
			DataTable dt = IPP.SelectAll();
			//cbReceipient
			ddlIPP.DataSource = dt;
			ddlIPP.ValueMember = "nIPPID";
		
			if (IPPId != "")
				ddlIPP.SelectedValue = IPPId;

			dal.TblReceiptPayment ReceiptPayment = new dal.TblReceiptPayment();
			dt = ReceiptPayment.SelectAll();
			//cbReceipient
			ddlReceipt.DataSource = dt;
			ddlReceipt.ValueMember = "nPaymentID";
			ddlReceipt.DisplayMember = "strReceiptNo";
		}

		

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			
			//myRP.UpdateIPP(Convert.ToSqlString(ddlIPP.SelectedValue),);
			int output;
			output = 0;

			SqlHelper.ExecuteNonQuery(connection,"sp_tblReceiptPayment_UpdateAllWnIPP_PaymentIDLogic",
				new SqlParameter("@inIPPID", Convert.ToInt32(ddlIPP.SelectedValue)),
				new SqlParameter("@PaymentID", Convert.ToInt32(ddlReceipt.SelectedValue)),
				new SqlParameter("@iErrorCode", output)
				);

			MessageBox.Show("Record Has Been Saved", "Save");
			this.DialogResult = DialogResult.OK;
			this.Dispose();
		}



		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
