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
	/// Summary description for RPNewMember.
	/// </summary>
	public class RPNewMember : System.Windows.Forms.Form
	{
		private string connectionString;
		private SqlConnection connection;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label3;
		private DevExpress.XtraEditors.LookUpEdit luedtRPStaffSalesPerfmCategory;
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraPivotGrid.PivotGridControl gridStaffPerformance;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField3;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField4;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField1;
		private DevExpress.XtraEditors.DateEdit dateEdit1;
		private DevExpress.XtraEditors.DateEdit dateEdit2;
		internal DevExpress.XtraEditors.SimpleButton btnReset;
		internal DevExpress.XtraEditors.SimpleButton btnSearch;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public RPNewMember()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);
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
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.luedtRPStaffSalesPerfmCategory = new DevExpress.XtraEditors.LookUpEdit();
			this.label1 = new System.Windows.Forms.Label();
			this.gridStaffPerformance = new DevExpress.XtraPivotGrid.PivotGridControl();
			this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField3 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField4 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
			this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
			this.btnReset = new DevExpress.XtraEditors.SimpleButton();
			this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.luedtRPStaffSalesPerfmCategory.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridStaffPerformance)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label7.Location = new System.Drawing.Point(136, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(24, 23);
			this.label7.TabIndex = 67;
			this.label7.Text = "To";
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label6.Location = new System.Drawing.Point(168, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(40, 23);
			this.label6.TabIndex = 64;
			this.label6.Text = "Date";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label3.Location = new System.Drawing.Point(0, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(40, 23);
			this.label3.TabIndex = 61;
			this.label3.Text = "Date";
			// 
			// luedtRPStaffSalesPerfmCategory
			// 
			this.luedtRPStaffSalesPerfmCategory.EditValue = "";
			this.luedtRPStaffSalesPerfmCategory.Location = new System.Drawing.Point(360, 0);
			this.luedtRPStaffSalesPerfmCategory.Name = "luedtRPStaffSalesPerfmCategory";
			// 
			// luedtRPStaffSalesPerfmCategory.Properties
			// 
			this.luedtRPStaffSalesPerfmCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																																   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.luedtRPStaffSalesPerfmCategory.Size = new System.Drawing.Size(128, 20);
			this.luedtRPStaffSalesPerfmCategory.TabIndex = 60;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(296, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 23);
			this.label1.TabIndex = 57;
			this.label1.Text = "Category";
			// 
			// gridStaffPerformance
			// 
			this.gridStaffPerformance.Cursor = System.Windows.Forms.Cursors.Default;
			this.gridStaffPerformance.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.gridStaffPerformance.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
																										this.pivotGridField1,
																										this.pivotGridField3,
																										this.pivotGridField4});
			this.gridStaffPerformance.Location = new System.Drawing.Point(0, 30);
			this.gridStaffPerformance.Name = "gridStaffPerformance";
			this.gridStaffPerformance.OptionsCustomization.AllowDrag = false;
			this.gridStaffPerformance.OptionsCustomization.AllowExpand = false;
			this.gridStaffPerformance.OptionsCustomization.AllowFilter = false;
			this.gridStaffPerformance.OptionsCustomization.AllowSort = false;
			this.gridStaffPerformance.OptionsView.ShowDataHeaders = false;
			this.gridStaffPerformance.OptionsView.ShowFilterHeaders = false;
			this.gridStaffPerformance.Size = new System.Drawing.Size(976, 432);
			this.gridStaffPerformance.TabIndex = 56;
			// 
			// pivotGridField1
			// 
			this.pivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
			this.pivotGridField1.AreaIndex = 0;
			this.pivotGridField1.Caption = "Date";
			this.pivotGridField1.CellFormat.FormatString = "d/MM/yyyy";
			this.pivotGridField1.CellFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.pivotGridField1.FieldName = "dtDate";
			this.pivotGridField1.GroupInterval = DevExpress.XtraPivotGrid.PivotGroupInterval.Date;
			this.pivotGridField1.Name = "pivotGridField1";
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
			this.pivotGridField4.FieldName = "nQuantity";
			this.pivotGridField4.Name = "pivotGridField4";
			// 
			// dateEdit1
			// 
			this.dateEdit1.EditValue = null;
			this.dateEdit1.Location = new System.Drawing.Point(40, 0);
			this.dateEdit1.Name = "dateEdit1";
			// 
			// dateEdit1.Properties
			// 
			this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dateEdit1.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.dateEdit1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.dateEdit1.Properties.EditFormat.FormatString = "dd/MM/yyyy";
			this.dateEdit1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.dateEdit1.Properties.Mask.EditMask = "dd/MM/yyyy";
			this.dateEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
			this.dateEdit1.Size = new System.Drawing.Size(88, 20);
			this.dateEdit1.TabIndex = 68;
			// 
			// dateEdit2
			// 
			this.dateEdit2.EditValue = null;
			this.dateEdit2.Location = new System.Drawing.Point(208, 0);
			this.dateEdit2.Name = "dateEdit2";
			// 
			// dateEdit2.Properties
			// 
			this.dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dateEdit2.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.dateEdit2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.dateEdit2.Properties.EditFormat.FormatString = "dd/MM/yyyy";
			this.dateEdit2.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.dateEdit2.Properties.Mask.EditMask = "dd/MM/yyyy";
			this.dateEdit2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
			this.dateEdit2.Size = new System.Drawing.Size(80, 20);
			this.dateEdit2.TabIndex = 69;
			// 
			// btnReset
			// 
			this.btnReset.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnReset.Location = new System.Drawing.Point(560, 0);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(56, 20);
			this.btnReset.TabIndex = 71;
			this.btnReset.Text = "Reset";
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// btnSearch
			// 
			this.btnSearch.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnSearch.Location = new System.Drawing.Point(496, 0);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(56, 20);
			this.btnSearch.TabIndex = 70;
			this.btnSearch.Text = "Search";
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// RPNewMember
			// 
			this.AutoScale = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(976, 462);
			this.Controls.Add(this.btnReset);
			this.Controls.Add(this.btnSearch);
			this.Controls.Add(this.dateEdit2);
			this.Controls.Add(this.dateEdit1);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.luedtRPStaffSalesPerfmCategory);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.gridStaffPerformance);
			this.Name = "RPNewMember";
			this.Text = "New Member SignUp";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.RPNewMember_Load);
			((System.ComponentModel.ISupportInitialize)(this.luedtRPStaffSalesPerfmCategory.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridStaffPerformance)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion


		private void LoadReport()
		{
			string strSQL;
			DataSet _ds;

			
				// Total sales Collection
				strSQL = "up_Get_NewMemberSales " + luedtRPStaffSalesPerfmCategory.EditValue;
				_ds = new DataSet();
				SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
				DataTable dt = _ds.Tables["table"];
				DataView dv = new DataView(dt);
			
				string str = string.Format("dtDate >= '{0}' And dtDate < '{1}'",string.Format("{0:MM/dd/yyyy}",Convert.ToDateTime(dateEdit1.EditValue)),string.Format("{0:MM/dd/yyyy}",Convert.ToDateTime(dateEdit2.EditValue)));

				if (luedtRPStaffSalesPerfmCategory.EditValue != null && luedtRPStaffSalesPerfmCategory.EditValue.ToString() != "")
					str += " And nCategoryID = '" + luedtRPStaffSalesPerfmCategory.EditValue + "'";
			

				dv.RowFilter = str;

				this.gridStaffPerformance.DataSource = dv;
		
		
		}

		private void RPNewMember_Load(object sender, System.EventArgs e)
		{
			//new ACMS.XtraUtils.LookupEditBuilder.EmployeeIDLookupEditBuilder(luedtRPStaffSalesPerfmEmpID.Properties);
			new ACMS.XtraUtils.LookupEditBuilder.CategoryIDLookupEditBuilder(luedtRPStaffSalesPerfmCategory.Properties);

			LoadReport();
		}


		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			LoadReport();
		}

		private void btnReset_Click(object sender, System.EventArgs e)
		{
			dateEdit1.EditValue = string.Format("{0:dd/MM/yyyy}",Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year));

			dateEdit2.EditValue = DateTime.Today;

			luedtRPStaffSalesPerfmCategory.EditValue = null;

			LoadReport();
		}

	}
}
