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
	/// Summary description for RPStaffReport.
	/// </summary>
	public class RPStaffReport : System.Windows.Forms.Form
	{
		private string connectionString;
		private SqlConnection connection;
		private DevExpress.XtraPivotGrid.PivotGridControl gridStaffPerformance;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField1;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField2;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField3;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField4;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private DevExpress.XtraEditors.LookUpEdit luedtRPStaffSalesPerfmEmpID;
		private DevExpress.XtraEditors.LookUpEdit luedtRPStaffSalesPerfmCategory;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private DevExpress.XtraEditors.ImageComboBoxEdit cmbMonthFrm;
		private DevExpress.XtraEditors.ImageComboBoxEdit cmbMonthTo;
		private DevExpress.XtraEditors.SimpleButton sbtnReset;
		private DevExpress.XtraEditors.SimpleButton btnReset;
		private DevExpress.XtraEditors.ImageComboBoxEdit cmbYearFrm;
		private DevExpress.XtraEditors.ImageComboBoxEdit cmbYearTo;
		private int EmployeeID;


		public RPStaffReport(int empID)
		{
			//
			// Required for Windows Form Designer support
			//
			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);
			EmployeeID = empID;
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
			this.gridStaffPerformance = new DevExpress.XtraPivotGrid.PivotGridControl();
			this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField2 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField3 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField4 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.luedtRPStaffSalesPerfmEmpID = new DevExpress.XtraEditors.LookUpEdit();
			this.luedtRPStaffSalesPerfmCategory = new DevExpress.XtraEditors.LookUpEdit();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.cmbMonthFrm = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.cmbMonthTo = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.sbtnReset = new DevExpress.XtraEditors.SimpleButton();
			this.btnReset = new DevExpress.XtraEditors.SimpleButton();
			this.cmbYearFrm = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.cmbYearTo = new DevExpress.XtraEditors.ImageComboBoxEdit();
			((System.ComponentModel.ISupportInitialize)(this.gridStaffPerformance)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.luedtRPStaffSalesPerfmEmpID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.luedtRPStaffSalesPerfmCategory.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbMonthFrm.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbMonthTo.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbYearFrm.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbYearTo.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// gridStaffPerformance
			// 
			this.gridStaffPerformance.Cursor = System.Windows.Forms.Cursors.Default;
			this.gridStaffPerformance.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.gridStaffPerformance.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
																										this.pivotGridField1,
																										this.pivotGridField2,
																										this.pivotGridField3,
																										this.pivotGridField4});
			this.gridStaffPerformance.Location = new System.Drawing.Point(0, 62);
			this.gridStaffPerformance.Name = "gridStaffPerformance";
			this.gridStaffPerformance.OptionsCustomization.AllowDrag = false;
			this.gridStaffPerformance.OptionsCustomization.AllowExpand = false;
			this.gridStaffPerformance.OptionsCustomization.AllowFilter = false;
			this.gridStaffPerformance.OptionsCustomization.AllowSort = false;
			this.gridStaffPerformance.OptionsView.ShowDataHeaders = false;
			this.gridStaffPerformance.OptionsView.ShowFilterHeaders = false;
			this.gridStaffPerformance.Size = new System.Drawing.Size(976, 400);
			this.gridStaffPerformance.TabIndex = 0;
			// 
			// pivotGridField1
			// 
			this.pivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
			this.pivotGridField1.AreaIndex = 0;
			this.pivotGridField1.Caption = "Year";
			this.pivotGridField1.FieldName = "dtDate";
			this.pivotGridField1.GroupInterval = DevExpress.XtraPivotGrid.PivotGroupInterval.DateYear;
			this.pivotGridField1.Name = "pivotGridField1";
			// 
			// pivotGridField2
			// 
			this.pivotGridField2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
			this.pivotGridField2.AreaIndex = 1;
			this.pivotGridField2.Caption = "Month";
			this.pivotGridField2.FieldName = "dtDate";
			this.pivotGridField2.GroupInterval = DevExpress.XtraPivotGrid.PivotGroupInterval.DateMonth;
			this.pivotGridField2.Name = "pivotGridField2";
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
			this.pivotGridField4.AreaIndex = 0;
			this.pivotGridField4.Caption = "Amount";
			this.pivotGridField4.FieldName = "mNettAmount";
			this.pivotGridField4.Name = "pivotGridField4";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(8, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "Category";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.Location = new System.Drawing.Point(240, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 16);
			this.label2.TabIndex = 4;
			this.label2.Text = "Staff";
			// 
			// luedtRPStaffSalesPerfmEmpID
			// 
			this.luedtRPStaffSalesPerfmEmpID.EditValue = "";
			this.luedtRPStaffSalesPerfmEmpID.Location = new System.Drawing.Point(288, 32);
			this.luedtRPStaffSalesPerfmEmpID.Name = "luedtRPStaffSalesPerfmEmpID";
			// 
			// luedtRPStaffSalesPerfmEmpID.Properties
			// 
			this.luedtRPStaffSalesPerfmEmpID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																																new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.luedtRPStaffSalesPerfmEmpID.Size = new System.Drawing.Size(168, 22);
			this.luedtRPStaffSalesPerfmEmpID.TabIndex = 43;
			// 
			// luedtRPStaffSalesPerfmCategory
			// 
			this.luedtRPStaffSalesPerfmCategory.EditValue = "";
			this.luedtRPStaffSalesPerfmCategory.Location = new System.Drawing.Point(80, 32);
			this.luedtRPStaffSalesPerfmCategory.Name = "luedtRPStaffSalesPerfmCategory";
			// 
			// luedtRPStaffSalesPerfmCategory.Properties
			// 
			this.luedtRPStaffSalesPerfmCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																																   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.luedtRPStaffSalesPerfmCategory.Size = new System.Drawing.Size(152, 22);
			this.luedtRPStaffSalesPerfmCategory.TabIndex = 44;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label3.Location = new System.Drawing.Point(8, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 23);
			this.label3.TabIndex = 45;
			this.label3.Text = "Year";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label4.Location = new System.Drawing.Point(296, 8);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 23);
			this.label4.TabIndex = 46;
			this.label4.Text = "Year";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label5.Location = new System.Drawing.Point(112, 8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(48, 23);
			this.label5.TabIndex = 47;
			this.label5.Text = "Month";
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label6.Location = new System.Drawing.Point(400, 8);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(48, 23);
			this.label6.TabIndex = 48;
			this.label6.Text = "Month";
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label7.Location = new System.Drawing.Point(256, 8);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(24, 23);
			this.label7.TabIndex = 53;
			this.label7.Text = "To";
			// 
			// cmbMonthFrm
			// 
			this.cmbMonthFrm.EditValue = 1;
			this.cmbMonthFrm.Location = new System.Drawing.Point(160, 8);
			this.cmbMonthFrm.Name = "cmbMonthFrm";
			// 
			// cmbMonthFrm.Properties
			// 
			this.cmbMonthFrm.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cmbMonthFrm.Properties.Items.AddRange(new object[] {
																		new DevExpress.XtraEditors.Controls.ImageComboBoxItem("January", 1, -1),
																		new DevExpress.XtraEditors.Controls.ImageComboBoxItem("February", 2, -1),
																		new DevExpress.XtraEditors.Controls.ImageComboBoxItem("March", 3, -1),
																		new DevExpress.XtraEditors.Controls.ImageComboBoxItem("April", 4, -1),
																		new DevExpress.XtraEditors.Controls.ImageComboBoxItem("May", 5, -1),
																		new DevExpress.XtraEditors.Controls.ImageComboBoxItem("June", 6, -1),
																		new DevExpress.XtraEditors.Controls.ImageComboBoxItem("July", 7, -1),
																		new DevExpress.XtraEditors.Controls.ImageComboBoxItem("August", 8, -1),
																		new DevExpress.XtraEditors.Controls.ImageComboBoxItem("September", 9, -1),
																		new DevExpress.XtraEditors.Controls.ImageComboBoxItem("October", 10, -1),
																		new DevExpress.XtraEditors.Controls.ImageComboBoxItem("November", 11, -1),
																		new DevExpress.XtraEditors.Controls.ImageComboBoxItem("December", 12, -1)});
			this.cmbMonthFrm.Size = new System.Drawing.Size(80, 22);
			this.cmbMonthFrm.TabIndex = 56;
			// 
			// cmbMonthTo
			// 
			this.cmbMonthTo.EditValue = 1;
			this.cmbMonthTo.Location = new System.Drawing.Point(448, 8);
			this.cmbMonthTo.Name = "cmbMonthTo";
			// 
			// cmbMonthTo.Properties
			// 
			this.cmbMonthTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cmbMonthTo.Properties.Items.AddRange(new object[] {
																	   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("January", 1, -1),
																	   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("February", 2, -1),
																	   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("March", 3, -1),
																	   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("April", 4, -1),
																	   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("May", 5, -1),
																	   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("June", 6, -1),
																	   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("July", 7, -1),
																	   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("August", 8, -1),
																	   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("September", 9, -1),
																	   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("October", 10, -1),
																	   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("November", 11, -1),
																	   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("December", 12, -1)});
			this.cmbMonthTo.Size = new System.Drawing.Size(88, 22);
			this.cmbMonthTo.TabIndex = 57;
			// 
			// sbtnReset
			// 
			this.sbtnReset.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.sbtnReset.Appearance.Options.UseFont = true;
			this.sbtnReset.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnReset.Location = new System.Drawing.Point(464, 32);
			this.sbtnReset.LookAndFeel.UseDefaultLookAndFeel = false;
			this.sbtnReset.Name = "sbtnReset";
			this.sbtnReset.Size = new System.Drawing.Size(56, 16);
			this.sbtnReset.TabIndex = 195;
			this.sbtnReset.Text = "Enquiry";
			this.sbtnReset.Click += new System.EventHandler(this.sbtnReset_Click);
			// 
			// btnReset
			// 
			this.btnReset.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnReset.Appearance.Options.UseFont = true;
			this.btnReset.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnReset.Location = new System.Drawing.Point(528, 32);
			this.btnReset.LookAndFeel.UseDefaultLookAndFeel = false;
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(56, 16);
			this.btnReset.TabIndex = 196;
			this.btnReset.Text = "Reset";
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// cmbYearFrm
			// 
			this.cmbYearFrm.Location = new System.Drawing.Point(48, 8);
			this.cmbYearFrm.Name = "cmbYearFrm";
			// 
			// cmbYearFrm.Properties
			// 
			this.cmbYearFrm.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cmbYearFrm.Size = new System.Drawing.Size(64, 22);
			this.cmbYearFrm.TabIndex = 197;
			// 
			// cmbYearTo
			// 
			this.cmbYearTo.Location = new System.Drawing.Point(336, 8);
			this.cmbYearTo.Name = "cmbYearTo";
			// 
			// cmbYearTo.Properties
			// 
			this.cmbYearTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cmbYearTo.Size = new System.Drawing.Size(64, 22);
			this.cmbYearTo.TabIndex = 198;
			// 
			// RPStaffReport
			// 
			this.AutoScale = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(976, 462);
			this.Controls.Add(this.cmbYearTo);
			this.Controls.Add(this.cmbYearFrm);
			this.Controls.Add(this.btnReset);
			this.Controls.Add(this.sbtnReset);
			this.Controls.Add(this.cmbMonthTo);
			this.Controls.Add(this.cmbMonthFrm);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.luedtRPStaffSalesPerfmCategory);
			this.Controls.Add(this.luedtRPStaffSalesPerfmEmpID);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.gridStaffPerformance);
			this.Name = "RPStaffReport";
			this.Text = "Staff Sales Performance";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.RPStaffReport_Load);
			((System.ComponentModel.ISupportInitialize)(this.gridStaffPerformance)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.luedtRPStaffSalesPerfmEmpID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.luedtRPStaffSalesPerfmCategory.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbMonthFrm.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbMonthTo.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbYearFrm.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbYearTo.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

	
		
		private void LoadReport()
		{
				string strSQL;
				DataSet _ds;

				// Total sales Collection
				strSQL = "up_Get_StaffSalesPerformance " + EmployeeID;
				_ds = new DataSet();
				SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
				DataTable dt = _ds.Tables["table"];
				DataView dv = new DataView(dt);
				
				string str = "(smonth>=" + cmbMonthFrm.EditValue + " and smonth<=" + cmbMonthTo.EditValue;
				str += ") and (syear>=" + cmbYearFrm.EditValue + " and syear<=" + cmbYearTo.EditValue + ")";

				if (luedtRPStaffSalesPerfmCategory.EditValue != null && luedtRPStaffSalesPerfmCategory.EditValue.ToString() != "")
					str += " And nCategoryID = '" + luedtRPStaffSalesPerfmCategory.EditValue + "'";

				if (luedtRPStaffSalesPerfmEmpID.EditValue != null && luedtRPStaffSalesPerfmEmpID.EditValue.ToString() != "")
					str += " And nSalesPersonID = '" + luedtRPStaffSalesPerfmEmpID.EditValue + "'";

				dv.RowFilter = str;

				this.gridStaffPerformance.DataSource = dv;
	
		}

		private void sbtnReset_Click(object sender, System.EventArgs e)
		{
			LoadReport();
		}

		private void btnReset_Click(object sender, System.EventArgs e)
		{
			cmbMonthFrm.EditValue = 1;
			this.cmbMonthTo.EditValue = DateTime.Today.Month;
			luedtRPStaffSalesPerfmCategory.EditValue = null;
			luedtRPStaffSalesPerfmEmpID.EditValue = null;
			LoadReport();
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
		

		private void RPStaffReport_Load(object sender, System.EventArgs e)
		{	
			DataSet _ds = new DataSet();
						
			string strSQL = "Select distinct year(dtDate) as Year From tblReceipt Order by year(dtDate) desc";

			comboBind(this.cmbYearFrm, strSQL, "Year", "Year", true);
			cmbYearFrm.SelectedIndex = 0;

			comboBind(this.cmbYearTo, strSQL, "Year", "Year", true);
			cmbYearTo.SelectedIndex = 0;

			this.cmbMonthTo.EditValue = DateTime.Today.Month;

			_ds = new DataSet();
			DevExpress.XtraEditors.Controls.LookUpColumnInfo[] col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];

			new ACMS.XtraUtils.LookupEditBuilder.EmployeeIDLookupEditBuilder(luedtRPStaffSalesPerfmEmpID.Properties);

			strSQL = "select * from tblCategory Where nCategoryID In (1,3,5,6,11,12)";
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			DataTable dt = _ds.Tables["table"];

			col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nCategoryID","Id",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription","Description",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(this.luedtRPStaffSalesPerfmCategory.Properties, dt, col, "strDescription", "nCategoryID", "Category");

			LoadReport();
		}

	


	}
}


