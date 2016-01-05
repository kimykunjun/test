using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ACMSDAL;


namespace ACMS
{
	/// <summary>
	/// Summary description for frmIPP_Send.
	/// </summary>
	public class frmIPP_Send : System.Windows.Forms.Form
	{
		public string IPPId;
		ACMSLogic.IPP IPPs;
		internal DevExpress.XtraEditors.SimpleButton btnSave;
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.DateEdit SentDate;
		internal DevExpress.XtraEditors.SimpleButton simpleButton1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmIPP_Send(string Id)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

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
			this.btnSave = new DevExpress.XtraEditors.SimpleButton();
			this.label1 = new System.Windows.Forms.Label();
			this.SentDate = new DevExpress.XtraEditors.DateEdit();
			this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.SentDate.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// btnSave
			// 
			this.btnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnSave.Location = new System.Drawing.Point(72, 56);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(62, 20);
			this.btnSave.TabIndex = 24;
			this.btnSave.Text = "Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(40, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 16);
			this.label1.TabIndex = 23;
			this.label1.Text = "Date Sent";
			// 
			// SentDate
			// 
			this.SentDate.EditValue = new System.DateTime(2006, 5, 19, 0, 0, 0, 0);
			this.SentDate.Location = new System.Drawing.Point(120, 24);
			this.SentDate.Name = "SentDate";
			// 
			// SentDate.Properties
			// 
			this.SentDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.SentDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.SentDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.SentDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
			this.SentDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.SentDate.Properties.Mask.EditMask = "dd/MM/yyyy";
			this.SentDate.Size = new System.Drawing.Size(136, 20);
			this.SentDate.TabIndex = 22;
			// 
			// simpleButton1
			// 
			this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.simpleButton1.Location = new System.Drawing.Point(144, 56);
			this.simpleButton1.Name = "simpleButton1";
			this.simpleButton1.Size = new System.Drawing.Size(62, 20);
			this.simpleButton1.TabIndex = 25;
			this.simpleButton1.Text = "Cancel";
			this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
			// 
			// frmIPP_Send
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(288, 101);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.SentDate);
			this.Controls.Add(this.simpleButton1);
			this.Name = "frmIPP_Send";
			this.Text = "Send IPP";
			this.Load += new System.EventHandler(this.frmIPP_Send_Load);
			((System.ComponentModel.ISupportInitialize)(this.SentDate.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			
			IPPs.UpdateIPPSend(Convert.ToDateTime(SentDate.EditValue),Convert.ToInt32(IPPId));
			
			MessageBox.Show("Record Has Been Saved", "Save");
			this.DialogResult = DialogResult.OK;
		}

		private void simpleButton1_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void frmIPP_Send_Load(object sender, System.EventArgs e)
		{
			SentDate.EditValue = DateTime.Today.Date;
		
		}

	
	
	}
}
