using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;
using DevExpress.XtraPivotGrid;

namespace ACMS.ACMSManager.Reports
{
	/// <summary>
	/// Summary description for RPInstructorDetails.
	/// </summary>
	public class RPInstructorDetails : System.Windows.Forms.Form
	{
		private string connectionString;
		private SqlConnection connection;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField1;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField2;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField3;
		private DevExpress.XtraPivotGrid.PivotGridControl GridRPInstructor;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField4;
		private System.Windows.Forms.Label label1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public RPInstructorDetails()
		{
			//
			// Required for Windows Form Designer support
			//
			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);
			InitializeComponent();

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
			this.GridRPInstructor = new DevExpress.XtraPivotGrid.PivotGridControl();
			this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField2 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField3 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField4 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.GridRPInstructor)).BeginInit();
			this.SuspendLayout();
			// 
			// GridRPInstructor
			// 
			this.GridRPInstructor.Cursor = System.Windows.Forms.Cursors.Default;
			this.GridRPInstructor.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
																									this.pivotGridField1,
																									this.pivotGridField2,
																									this.pivotGridField3,
																									this.pivotGridField4});
			this.GridRPInstructor.Location = new System.Drawing.Point(8, 32);
			this.GridRPInstructor.Name = "GridRPInstructor";
			this.GridRPInstructor.OptionsCustomization.AllowDrag = false;
			this.GridRPInstructor.OptionsCustomization.AllowExpand = false;
			this.GridRPInstructor.OptionsCustomization.AllowFilter = false;
			this.GridRPInstructor.OptionsCustomization.AllowSort = false;
			this.GridRPInstructor.OptionsView.ShowDataHeaders = false;
			this.GridRPInstructor.OptionsView.ShowFilterHeaders = false;
			this.GridRPInstructor.Size = new System.Drawing.Size(760, 360);
			this.GridRPInstructor.TabIndex = 0;
			// 
			// pivotGridField1
			// 
			this.pivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
			this.pivotGridField1.AreaIndex = 0;
			this.pivotGridField1.Caption = "Date";
			this.pivotGridField1.FieldName = "dtDate";
			this.pivotGridField1.GroupInterval = DevExpress.XtraPivotGrid.PivotGroupInterval.DateDayOfWeek;
			this.pivotGridField1.Name = "pivotGridField1";
			// 
			// pivotGridField2
			// 
			this.pivotGridField2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
			this.pivotGridField2.AreaIndex = 1;
			this.pivotGridField2.Caption = "Time";
			this.pivotGridField2.FieldName = "dtStartTime";
			this.pivotGridField2.Name = "pivotGridField2";
			this.pivotGridField2.ValueFormat.FormatString = "HH:mm:ss";
			this.pivotGridField2.ValueFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			// 
			// pivotGridField3
			// 
			this.pivotGridField3.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
			this.pivotGridField3.AreaIndex = 0;
			this.pivotGridField3.FieldName = "dtDate";
			this.pivotGridField3.GroupInterval = DevExpress.XtraPivotGrid.PivotGroupInterval.DateWeekOfMonth;
			this.pivotGridField3.Name = "pivotGridField3";
			// 
			// pivotGridField4
			// 
			this.pivotGridField4.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
			this.pivotGridField4.AreaIndex = 0;
			this.pivotGridField4.Caption = "Fees";
			this.pivotGridField4.FieldName = "mInstructorFees";
			this.pivotGridField4.Name = "pivotGridField4";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(160, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Instructor Details";
			// 
			// RPInstructorDetails
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(784, 461);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.GridRPInstructor);
			this.Name = "RPInstructorDetails";
			this.Text = "Instructor Details";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.RPInstructorDetails_Load);
			((System.ComponentModel.ISupportInitialize)(this.GridRPInstructor)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void RPInstructorDetails_Load(object sender, System.EventArgs e)
		{
			BindReport();
		}

		private void BindReport()
		{
			string strSQL;
			DataSet _ds;

			// first previous two month sales
			strSQL = "Select * from TblClassInstance";
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds, new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			DataTable dt = _ds.Tables["table"];
			DataView dv = new DataView(dt);

			this.GridRPInstructor.DataSource = dv;
		}
		
	}
}


