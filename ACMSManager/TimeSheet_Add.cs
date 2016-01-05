using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.Data;

namespace ACMS
{
	/// <summary>
	/// Summary description for TimeSheet_Add.
	/// </summary>
	public class TimeSheet_Add : System.Windows.Forms.Form
	{
		private string connectionString;
		private SqlConnection connection;
		private DevExpress.XtraEditors.DateEdit dtDate;
		private System.Windows.Forms.Label mdPKG_lblStrReceiptDesc;
		private System.Windows.Forms.Label mdPKG_lblStrDescription;
		private System.Windows.Forms.Label mdPKG_lblStrPackageCode;
		private DevExpress.XtraEditors.TimeEdit txtTime;
		private DevExpress.XtraEditors.MemoEdit txtRemarks;
		private string BranchCode; 
		private int EmpID;
		private int ManagerID;
		private DevExpress.XtraEditors.SimpleButton btnTimeSheetAdd;
		private DevExpress.XtraEditors.SimpleButton btnClose;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public TimeSheet_Add(int MID, string strBranchCode,int intEmpID,string strdtDate)
		{

			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			
			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);
		
			BranchCode = strBranchCode;
			EmpID = intEmpID;
			ManagerID = MID;
			dtDate.EditValue = strdtDate;
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
			this.dtDate = new DevExpress.XtraEditors.DateEdit();
			this.mdPKG_lblStrReceiptDesc = new System.Windows.Forms.Label();
			this.mdPKG_lblStrDescription = new System.Windows.Forms.Label();
			this.mdPKG_lblStrPackageCode = new System.Windows.Forms.Label();
			this.txtTime = new DevExpress.XtraEditors.TimeEdit();
			this.txtRemarks = new DevExpress.XtraEditors.MemoEdit();
			this.btnTimeSheetAdd = new DevExpress.XtraEditors.SimpleButton();
			this.btnClose = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.dtDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtTime.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtRemarks.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// dtDate
			// 
			this.dtDate.EditValue = null;
			this.dtDate.Enabled = false;
			this.dtDate.Location = new System.Drawing.Point(120, 24);
			this.dtDate.Name = "dtDate";
			// 
			// dtDate.Properties
			// 
			this.dtDate.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
			this.dtDate.Properties.Appearance.Options.UseForeColor = true;
			this.dtDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
			this.dtDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																										   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dtDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.dtDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.dtDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
			this.dtDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.dtDate.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.dtDate.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.dtDate.Properties.ReadOnly = true;
			this.dtDate.Size = new System.Drawing.Size(88, 22);
			this.dtDate.TabIndex = 203;
			// 
			// mdPKG_lblStrReceiptDesc
			// 
			this.mdPKG_lblStrReceiptDesc.BackColor = System.Drawing.Color.Transparent;
			this.mdPKG_lblStrReceiptDesc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mdPKG_lblStrReceiptDesc.Location = new System.Drawing.Point(16, 72);
			this.mdPKG_lblStrReceiptDesc.Name = "mdPKG_lblStrReceiptDesc";
			this.mdPKG_lblStrReceiptDesc.Size = new System.Drawing.Size(120, 16);
			this.mdPKG_lblStrReceiptDesc.TabIndex = 198;
			this.mdPKG_lblStrReceiptDesc.Text = "Remarks";
			this.mdPKG_lblStrReceiptDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// mdPKG_lblStrDescription
			// 
			this.mdPKG_lblStrDescription.BackColor = System.Drawing.Color.Transparent;
			this.mdPKG_lblStrDescription.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mdPKG_lblStrDescription.Location = new System.Drawing.Point(16, 48);
			this.mdPKG_lblStrDescription.Name = "mdPKG_lblStrDescription";
			this.mdPKG_lblStrDescription.Size = new System.Drawing.Size(96, 16);
			this.mdPKG_lblStrDescription.TabIndex = 197;
			this.mdPKG_lblStrDescription.Text = "Time";
			this.mdPKG_lblStrDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// mdPKG_lblStrPackageCode
			// 
			this.mdPKG_lblStrPackageCode.BackColor = System.Drawing.Color.Transparent;
			this.mdPKG_lblStrPackageCode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mdPKG_lblStrPackageCode.Location = new System.Drawing.Point(16, 24);
			this.mdPKG_lblStrPackageCode.Name = "mdPKG_lblStrPackageCode";
			this.mdPKG_lblStrPackageCode.Size = new System.Drawing.Size(96, 16);
			this.mdPKG_lblStrPackageCode.TabIndex = 196;
			this.mdPKG_lblStrPackageCode.Text = "Date";
			this.mdPKG_lblStrPackageCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtTime
			// 
			this.txtTime.EditValue = new System.DateTime(2006, 1, 14, 0, 0, 0, 0);
			this.txtTime.Location = new System.Drawing.Point(120, 48);
			this.txtTime.Name = "txtTime";
			// 
			// txtTime.Properties
			// 
			this.txtTime.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
			this.txtTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											new DevExpress.XtraEditors.Controls.EditorButton()});
			this.txtTime.Size = new System.Drawing.Size(88, 22);
			this.txtTime.TabIndex = 212;
			// 
			// txtRemarks
			// 
			this.txtRemarks.EditValue = "";
			this.txtRemarks.Location = new System.Drawing.Point(120, 72);
			this.txtRemarks.Name = "txtRemarks";
			// 
			// txtRemarks.Properties
			// 
			this.txtRemarks.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
			this.txtRemarks.Size = new System.Drawing.Size(272, 96);
			this.txtRemarks.TabIndex = 213;
			// 
			// btnTimeSheetAdd
			// 
			this.btnTimeSheetAdd.Location = new System.Drawing.Point(120, 192);
			this.btnTimeSheetAdd.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
			this.btnTimeSheetAdd.Name = "btnTimeSheetAdd";
			this.btnTimeSheetAdd.TabIndex = 216;
			this.btnTimeSheetAdd.Text = "Save";
			this.btnTimeSheetAdd.Click += new System.EventHandler(this.btnTimeSheetAdd_Click);
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(216, 192);
			this.btnClose.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
			this.btnClose.Name = "btnClose";
			this.btnClose.TabIndex = 217;
			this.btnClose.Text = "Close";
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// TimeSheet_Add
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(440, 230);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnTimeSheetAdd);
			this.Controls.Add(this.txtRemarks);
			this.Controls.Add(this.txtTime);
			this.Controls.Add(this.dtDate);
			this.Controls.Add(this.mdPKG_lblStrReceiptDesc);
			this.Controls.Add(this.mdPKG_lblStrDescription);
			this.Controls.Add(this.mdPKG_lblStrPackageCode);
			this.Name = "TimeSheet_Add";
			this.Text = "Time Sheet";
			this.Load += new System.EventHandler(this.TimeSheet_Add_Load);
			((System.ComponentModel.ISupportInitialize)(this.dtDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtTime.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtRemarks.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void TimeSheet_Add_Load(object sender, System.EventArgs e)
		{
		
		}

		private void btnTimeSheetAdd_Click(object sender, System.EventArgs e)
		{
			int output;
			output = 0;

			if (this.txtRemarks.EditValue.ToString() == "")
			{
				MessageBox.Show("Remarks","Remarks is required.");
			}
			else
			{
				string dtTime = string.Format("{0:yyyy-MM-dd}",DateTime.Today.Date) + " " + this.txtTime.Text;

				SqlHelper.ExecuteNonQuery(connection,"In_tblTimeCard",
					new SqlParameter("@retval",output),
					new SqlParameter("@tDate",string.Format("{0:yyyy-MM-dd}",Convert.ToDateTime(dtDate.EditValue))),								
					new SqlParameter("@dtTime",string.Format("{0:yyyy-MM-dd hh:mm:ss}", dtTime)),
					new SqlParameter("@strBranchCode",BranchCode),
					new SqlParameter("@nEmployeeID",EmpID),
					new SqlParameter("@strRemarks",this.txtRemarks.EditValue.ToString()),
					new SqlParameter("@nManagerID",ManagerID)								
					);
			}
			
			this.Dispose();

		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}
	}
}








