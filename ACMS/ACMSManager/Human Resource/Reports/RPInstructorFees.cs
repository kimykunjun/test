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
	/// Summary description for RPInstructorFees.
	/// </summary>
	public class RPInstructorFees : System.Windows.Forms.Form
	{
		private string connectionString;
		private SqlConnection connection;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField1;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField2;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField3;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField4;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField5;
		private DevExpress.XtraPivotGrid.PivotGridControl GridInstructorFee;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField6;
		private System.Windows.Forms.Label label1;
		private int EmployeeID;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public RPInstructorFees(int empID)
		{
			//
			// Required for Windows Form Designer support
			//
			EmployeeID = empID;
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
			DevExpress.XtraPivotGrid.PivotGridCustomTotal pivotGridCustomTotal1 = new DevExpress.XtraPivotGrid.PivotGridCustomTotal();
			DevExpress.XtraPivotGrid.PivotGridGroup pivotGridGroup1 = new DevExpress.XtraPivotGrid.PivotGridGroup();
			this.pivotGridField6 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.GridInstructorFee = new DevExpress.XtraPivotGrid.PivotGridControl();
			this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField2 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField3 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField4 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField5 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.GridInstructorFee)).BeginInit();
			this.SuspendLayout();
			// 
			// pivotGridField6
			// 
			this.pivotGridField6.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
			this.pivotGridField6.AreaIndex = 2;
			this.pivotGridField6.Caption = "Standing Inst. Fees";
			this.pivotGridField6.CustomTotals.AddRange(new DevExpress.XtraPivotGrid.PivotGridCustomTotal[] {
																											   pivotGridCustomTotal1});
			this.pivotGridField6.FieldName = "mStandinInstructorFees";
			this.pivotGridField6.Name = "pivotGridField6";
			this.pivotGridField6.TotalsVisibility = DevExpress.XtraPivotGrid.PivotTotalsVisibility.CustomTotals;
			this.pivotGridField6.Width = 110;
			// 
			// GridInstructorFee
			// 
			this.GridInstructorFee.Cursor = System.Windows.Forms.Cursors.Default;
			this.GridInstructorFee.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
																									 this.pivotGridField1,
																									 this.pivotGridField2,
																									 this.pivotGridField3,
																									 this.pivotGridField4,
																									 this.pivotGridField5,
																									 this.pivotGridField6});
			pivotGridGroup1.Fields.Add(this.pivotGridField6);
			this.GridInstructorFee.Groups.AddRange(new DevExpress.XtraPivotGrid.PivotGridGroup[] {
																									 pivotGridGroup1});
			this.GridInstructorFee.Location = new System.Drawing.Point(8, 24);
			this.GridInstructorFee.Name = "GridInstructorFee";
			this.GridInstructorFee.OptionsCustomization.AllowDrag = false;
			this.GridInstructorFee.OptionsCustomization.AllowExpand = false;
			this.GridInstructorFee.OptionsCustomization.AllowFilter = false;
			this.GridInstructorFee.OptionsCustomization.AllowSort = false;
			this.GridInstructorFee.OptionsView.ShowDataHeaders = false;
			this.GridInstructorFee.OptionsView.ShowFilterHeaders = false;
			this.GridInstructorFee.OptionsView.ShowRowTotals = false;
			this.GridInstructorFee.OptionsView.ShowTotalsForSingleValues = true;
			this.GridInstructorFee.Size = new System.Drawing.Size(760, 376);
			this.GridInstructorFee.TabIndex = 0;
			// 
			// pivotGridField1
			// 
			this.pivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
			this.pivotGridField1.AreaIndex = 1;
			this.pivotGridField1.Caption = "Instructor Id";
			this.pivotGridField1.FieldName = "InstructorId";
			this.pivotGridField1.Name = "pivotGridField1";
			// 
			// pivotGridField2
			// 
			this.pivotGridField2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
			this.pivotGridField2.AreaIndex = 0;
			this.pivotGridField2.Caption = "Instructor Name";
			this.pivotGridField2.FieldName = "strEmployeeName";
			this.pivotGridField2.Name = "pivotGridField2";
			this.pivotGridField2.Width = 150;
			// 
			// pivotGridField3
			// 
			this.pivotGridField3.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
			this.pivotGridField3.AreaIndex = 0;
			this.pivotGridField3.Caption = "Branch";
			this.pivotGridField3.FieldName = "strBranchCode";
			this.pivotGridField3.Name = "pivotGridField3";
			// 
			// pivotGridField4
			// 
			this.pivotGridField4.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
			this.pivotGridField4.AreaIndex = 1;
			this.pivotGridField4.Caption = "# of Class";
			this.pivotGridField4.FieldName = "strBranchCode";
			this.pivotGridField4.Name = "pivotGridField4";
			this.pivotGridField4.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
			this.pivotGridField4.Width = 80;
			// 
			// pivotGridField5
			// 
			this.pivotGridField5.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
			this.pivotGridField5.AreaIndex = 0;
			this.pivotGridField5.Caption = "Total Fee";
			this.pivotGridField5.FieldName = "mInstructorFees";
			this.pivotGridField5.Name = "pivotGridField5";
			this.pivotGridField5.Width = 80;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(8, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(160, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "Instructor Fees";
			// 
			// RPInstructorFees
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(792, 461);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.GridInstructorFee);
			this.Name = "RPInstructorFees";
			this.Text = "Instructors Fee Summary Report";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.RPInstructorFees_Load);
			((System.ComponentModel.ISupportInitialize)(this.GridInstructorFee)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void RPInstructorFees_Load(object sender, System.EventArgs e)
		{
			BindReport();
		}
		
		private void BindReport()
		{
			string strSQL;
			DataSet _ds;
					
			strSQL = "Select nPermanentInstructorID as InstructorId,strEmployeeName, mStandinInstructorFees, mInstructorFees, TblClassInstance.strBranchCode, TblClassInstance.dtDate From TblClassInstance Inner Join TblEmployee On TblEmployee.nEmployeeID = nPermanentInstructorID Where TblClassInstance.strBranchCode In (select strBranchCode From tblEmployeeBranchRights Where nEmployeeID = " + EmployeeID + ")";
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			DataTable dt = _ds.Tables["table"];
			DataView dv = new DataView(dt);


			this.GridInstructorFee.DataSource = dv;
		}
	}
}
