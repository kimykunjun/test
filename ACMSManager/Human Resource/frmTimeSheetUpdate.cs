using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;
using Do = Acms.Core.Domain;
using ACMSLogic;
using ACMS.Utils;

namespace ACMS.ACMSManager.Human_Resource
{
	/// <summary>
	/// Summary description for frmTimeSheetUpdate.
	/// </summary>
	public class frmTimeSheetUpdate : System.Windows.Forms.Form
	{
		private string connectionString;
		private SqlConnection connection;
		//private Do.Employee employee;
		//private Do.TerminalUser terminalUser; 
		//private static User oUser;

		private DevExpress.XtraEditors.SimpleButton btnClose;
		private DevExpress.XtraEditors.SimpleButton btnTimeSheetAdd;
		private DevExpress.XtraEditors.MemoEdit txtRemarks;
		private DevExpress.XtraEditors.TimeEdit txtTime;
		private DevExpress.XtraEditors.DateEdit dtDate;
		private System.Windows.Forms.Label mdPKG_lblStrReceiptDesc;
		private System.Windows.Forms.Label mdPKG_lblStrDescription;
		private System.Windows.Forms.Label mdPKG_lblStrPackageCode;
		private int EmpID;
		private int ManagerID;
		private int EntryID;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmTimeSheetUpdate(int MID,int intEmpID, string strdtDate)
		{

			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);
		
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
			this.btnClose = new DevExpress.XtraEditors.SimpleButton();
			this.btnTimeSheetAdd = new DevExpress.XtraEditors.SimpleButton();
			this.txtRemarks = new DevExpress.XtraEditors.MemoEdit();
			this.txtTime = new DevExpress.XtraEditors.TimeEdit();
			this.dtDate = new DevExpress.XtraEditors.DateEdit();
			this.mdPKG_lblStrReceiptDesc = new System.Windows.Forms.Label();
			this.mdPKG_lblStrDescription = new System.Windows.Forms.Label();
			this.mdPKG_lblStrPackageCode = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.txtRemarks.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtTime.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtDate.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// btnClose
			// 
			this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnClose.Appearance.Options.UseFont = true;
			this.btnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnClose.Location = new System.Drawing.Point(320, 176);
			this.btnClose.Name = "btnClose";
			this.btnClose.TabIndex = 223;
			this.btnClose.Text = "Close";
			// 
			// btnTimeSheetAdd
			// 
			this.btnTimeSheetAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnTimeSheetAdd.Appearance.Options.UseFont = true;
			this.btnTimeSheetAdd.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnTimeSheetAdd.Location = new System.Drawing.Point(240, 176);
			this.btnTimeSheetAdd.Name = "btnTimeSheetAdd";
			this.btnTimeSheetAdd.TabIndex = 222;
			this.btnTimeSheetAdd.Text = "Save";
			this.btnTimeSheetAdd.Click += new System.EventHandler(this.btnTimeSheetAdd_Click);
			// 
			// txtRemarks
			// 
			this.txtRemarks.EditValue = "";
			this.txtRemarks.Location = new System.Drawing.Point(120, 64);
			this.txtRemarks.Name = "txtRemarks";
			// 
			// txtRemarks.Properties
			// 
			this.txtRemarks.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
			this.txtRemarks.Size = new System.Drawing.Size(272, 96);
			this.txtRemarks.TabIndex = 221;
			// 
			// txtTime
			// 
			this.txtTime.EditValue = null;
			this.txtTime.Location = new System.Drawing.Point(120, 40);
			this.txtTime.Name = "txtTime";
			// 
			// txtTime.Properties
			// 
			this.txtTime.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
			this.txtTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											new DevExpress.XtraEditors.Controls.EditorButton()});
			this.txtTime.Properties.DisplayFormat.FormatString = "hh:mm tt";
			this.txtTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.txtTime.Properties.EditFormat.FormatString = "hh:mm tt";
			this.txtTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.txtTime.Properties.Mask.EditMask = "hh:mm tt";
			this.txtTime.Size = new System.Drawing.Size(88, 22);
			this.txtTime.TabIndex = 220;
			// 
			// dtDate
			// 
			this.dtDate.EditValue = null;
			this.dtDate.Enabled = false;
			this.dtDate.Location = new System.Drawing.Point(120, 16);
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
			this.dtDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.dtDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
			this.dtDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.dtDate.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.dtDate.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.dtDate.Properties.Mask.EditMask = "dd/MM/yyyy";
			this.dtDate.Properties.ReadOnly = true;
			this.dtDate.Size = new System.Drawing.Size(88, 22);
			this.dtDate.TabIndex = 219;
			// 
			// mdPKG_lblStrReceiptDesc
			// 
			this.mdPKG_lblStrReceiptDesc.BackColor = System.Drawing.Color.Transparent;
			this.mdPKG_lblStrReceiptDesc.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mdPKG_lblStrReceiptDesc.Location = new System.Drawing.Point(16, 64);
			this.mdPKG_lblStrReceiptDesc.Name = "mdPKG_lblStrReceiptDesc";
			this.mdPKG_lblStrReceiptDesc.Size = new System.Drawing.Size(120, 16);
			this.mdPKG_lblStrReceiptDesc.TabIndex = 218;
			this.mdPKG_lblStrReceiptDesc.Text = "Remarks";
			this.mdPKG_lblStrReceiptDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// mdPKG_lblStrDescription
			// 
			this.mdPKG_lblStrDescription.BackColor = System.Drawing.Color.Transparent;
			this.mdPKG_lblStrDescription.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mdPKG_lblStrDescription.Location = new System.Drawing.Point(16, 40);
			this.mdPKG_lblStrDescription.Name = "mdPKG_lblStrDescription";
			this.mdPKG_lblStrDescription.Size = new System.Drawing.Size(96, 16);
			this.mdPKG_lblStrDescription.TabIndex = 217;
			this.mdPKG_lblStrDescription.Text = "Time";
			this.mdPKG_lblStrDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// mdPKG_lblStrPackageCode
			// 
			this.mdPKG_lblStrPackageCode.BackColor = System.Drawing.Color.Transparent;
			this.mdPKG_lblStrPackageCode.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mdPKG_lblStrPackageCode.Location = new System.Drawing.Point(16, 16);
			this.mdPKG_lblStrPackageCode.Name = "mdPKG_lblStrPackageCode";
			this.mdPKG_lblStrPackageCode.Size = new System.Drawing.Size(96, 16);
			this.mdPKG_lblStrPackageCode.TabIndex = 216;
			this.mdPKG_lblStrPackageCode.Text = "Date";
			this.mdPKG_lblStrPackageCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frmTimeSheetUpdate
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(416, 213);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnTimeSheetAdd);
			this.Controls.Add(this.txtRemarks);
			this.Controls.Add(this.txtTime);
			this.Controls.Add(this.dtDate);
			this.Controls.Add(this.mdPKG_lblStrReceiptDesc);
			this.Controls.Add(this.mdPKG_lblStrDescription);
			this.Controls.Add(this.mdPKG_lblStrPackageCode);
			this.Name = "frmTimeSheetUpdate";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Timesheet Update";
			this.Load += new System.EventHandler(this.frmTimeSheetUpdate_Load);
			((System.ComponentModel.ISupportInitialize)(this.txtRemarks.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtTime.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtDate.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
	
		private void UpdateTimeSheet()
		{
			//DataRow dr = this.gridViewMd_PackageGroup.GetDataRow(this.gridViewMd_PackageGroup.FocusedRowHandle);
			
			string dtTime = string.Format("{0:yyyy-MM-dd}",DateTime.Today.Date) + " " + this.txtTime.Text;
			

			int output;
			output = 0;
			
			SqlHelper.ExecuteNonQuery(connection,"up_tblTimeCard",
				new SqlParameter("@retval",output),
				new SqlParameter("@nEntryId",EntryID),								
				new SqlParameter("@dtTime",string.Format("{0:yyyy-MM-dd hh:mm:ss}", dtTime)),
				new SqlParameter("@strRemarks",this.txtRemarks.EditValue),
				new SqlParameter("@nManagerID",ManagerID)								
				);

				MessageBox.Show("Update Successfully.","Update");
			this.Dispose();

		}


		private void frmTimeSheetUpdate_Load(object sender, System.EventArgs e)
		{
			string strSQL;

			strSQL = "Select top 1 nEntryID, dtTime, strRemarks from TblTimeCard Where Convert(varchar(10),dtDate,101) = '" + string.Format("{0:MM/dd/yyyy}",Convert.ToDateTime(dtDate.EditValue)) + "' And nEmployeeID = " + EmpID + " Order By dtTime desc";
			
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			
			DataTable dt = _ds.Tables["table"];
			EntryID = Convert.ToInt32(dt.Rows[0]["nEntryID"]);
			txtTime.EditValue = dt.Rows[0]["dtTime"];
			this.txtRemarks.EditValue = dt.Rows[0]["strRemarks"].ToString();
					
		}

		private void btnTimeSheetAdd_Click(object sender, System.EventArgs e)
		{
			UpdateTimeSheet();
		}
	
	}
}
