using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;


namespace ACMS
{
	/// <summary>
	/// Summary description for frmIPP_Received.
	/// </summary>
	public class frmIPP_Received : System.Windows.Forms.Form
	{
		private string connectionString;
		private SqlConnection connection;
		private string IPPId;
		ACMSLogic.IPP IPPs;
		private System.Windows.Forms.Label label1;
		internal DevExpress.XtraEditors.SimpleButton btnSave;
		internal DevExpress.XtraEditors.SimpleButton simpleButton1;
		private DevExpress.XtraEditors.DateEdit ReceivedDate;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmIPP_Received(string Id)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);

			IPPId = Id;
			IPPs = new ACMSLogic.IPP();
            
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
			this.label1 = new System.Windows.Forms.Label();
			this.btnSave = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
			this.ReceivedDate = new DevExpress.XtraEditors.DateEdit();
			((System.ComponentModel.ISupportInitialize)(this.ReceivedDate.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(24, 16);
			this.label1.Name = "label1";
			this.label1.TabIndex = 31;
			this.label1.Text = "Date Received";
			// 
			// btnSave
			// 
			this.btnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnSave.Location = new System.Drawing.Point(80, 56);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(62, 20);
			this.btnSave.TabIndex = 32;
			this.btnSave.Text = "Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// simpleButton1
			// 
			this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.simpleButton1.Location = new System.Drawing.Point(152, 56);
			this.simpleButton1.Name = "simpleButton1";
			this.simpleButton1.Size = new System.Drawing.Size(62, 20);
			this.simpleButton1.TabIndex = 33;
			this.simpleButton1.Text = "Close";
			this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
			// 
			// ReceivedDate
			// 
			this.ReceivedDate.EditValue = new System.DateTime(2006, 5, 5, 0, 0, 0, 0);
			this.ReceivedDate.Location = new System.Drawing.Point(136, 16);
			this.ReceivedDate.Name = "ReceivedDate";
			// 
			// ReceivedDate.Properties
			// 
			this.ReceivedDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
			this.ReceivedDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.ReceivedDate.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.ReceivedDate.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.ReceivedDate.Size = new System.Drawing.Size(144, 22);
			this.ReceivedDate.TabIndex = 30;
			// 
			// frmIPP_Received
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(320, 93);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.simpleButton1);
			this.Controls.Add(this.ReceivedDate);
			this.Name = "frmIPP_Received";
			this.Text = "IPP Received";
			this.Load += new System.EventHandler(this.frmIPP_Received_Load);
			((System.ComponentModel.ISupportInitialize)(this.ReceivedDate.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			//IPPs.UpdateIPPReceived(Convert.ToDateTime(ReceivedDate.Text),Convert.ToInt32(this.Status.Text),Convert.ToInt32(IPPId));	
			int output;
			output = 0;

			SqlHelper.ExecuteNonQuery(connection,"sp_tblIPP_UpdateReceivedMembershipIDLogic",
				new SqlParameter("@nIPPID", Convert.ToInt32(IPPId)),
				new SqlParameter("@dtReceivedDate",string.Format("{0:yyyy-MM-dd HH:mm:ss}",Convert.ToDateTime(ReceivedDate.EditValue))),
				new SqlParameter("@nIPPStatus", 2),
				new SqlParameter("@iErrorCode", output)
				);

			MessageBox.Show("Record Has Been Saved", "Save");
			this.DialogResult = DialogResult.OK;		
		}

		private void frmIPP_Received_Load(object sender, System.EventArgs e)
		{
		
		}

		private void simpleButton1_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
