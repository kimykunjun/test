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
	/// Summary description for RPPromotionSalesPkg.
	/// </summary>
	public class RPPromotionSalesPkg : System.Windows.Forms.Form
	{
		private string connectionString;
        private SqlConnection connection;
        private System.Windows.Forms.Label label7;
		private DevExpress.XtraEditors.LookUpEdit luedtRPStaffSalesPerfmCategory;
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField1;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField3;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField4;
		private DevExpress.XtraPivotGrid.PivotGridControl gridPromotionPackage;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField2;
		private bool isFinishBindInit = false;
		private int EmployeeId;
		private DevExpress.XtraEditors.SimpleButton btnReset;
		private DevExpress.XtraEditors.SimpleButton sbtnReset;
        private MonthCalendar dateEdit1;
        private MonthCalendar dateEdit2;
        private MonthCalendar dateEdit3;


		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public RPPromotionSalesPkg(int empId)
		{
			//
			// Required for Windows Form Designer support
			//
			EmployeeId = empId;
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
            this.luedtRPStaffSalesPerfmCategory = new DevExpress.XtraEditors.LookUpEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.gridPromotionPackage = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField2 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField3 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField4 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.btnReset = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnReset = new DevExpress.XtraEditors.SimpleButton();
            this.dateEdit1 = new System.Windows.Forms.MonthCalendar();
            this.dateEdit2 = new System.Windows.Forms.MonthCalendar();
            this.dateEdit3 = new System.Windows.Forms.MonthCalendar();
            ((System.ComponentModel.ISupportInitialize)(this.luedtRPStaffSalesPerfmCategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPromotionPackage)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(427, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 21);
            this.label7.TabIndex = 75;
            this.label7.Text = "To";
            // 
            // luedtRPStaffSalesPerfmCategory
            // 
            this.luedtRPStaffSalesPerfmCategory.EditValue = "";
            this.luedtRPStaffSalesPerfmCategory.Location = new System.Drawing.Point(0, 35);
            this.luedtRPStaffSalesPerfmCategory.Name = "luedtRPStaffSalesPerfmCategory";
            this.luedtRPStaffSalesPerfmCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luedtRPStaffSalesPerfmCategory.Size = new System.Drawing.Size(152, 20);
            this.luedtRPStaffSalesPerfmCategory.TabIndex = 72;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(-3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 23);
            this.label1.TabIndex = 71;
            this.label1.Text = "Category";
            // 
            // gridPromotionPackage
            // 
            this.gridPromotionPackage.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridPromotionPackage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridPromotionPackage.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.pivotGridField1,
            this.pivotGridField2,
            this.pivotGridField3,
            this.pivotGridField4});
            this.gridPromotionPackage.Location = new System.Drawing.Point(0, 148);
            this.gridPromotionPackage.Name = "gridPromotionPackage";
            this.gridPromotionPackage.OptionsCustomization.AllowDrag = false;
            this.gridPromotionPackage.OptionsCustomization.AllowExpand = false;
            this.gridPromotionPackage.OptionsCustomization.AllowFilter = false;
            this.gridPromotionPackage.OptionsView.ShowColumnHeaders = false;
            this.gridPromotionPackage.OptionsView.ShowDataHeaders = false;
            this.gridPromotionPackage.OptionsView.ShowFilterHeaders = false;
            this.gridPromotionPackage.Size = new System.Drawing.Size(976, 378);
            this.gridPromotionPackage.TabIndex = 70;
            this.gridPromotionPackage.Click += new System.EventHandler(this.gridPromotionPackage_Click);
            // 
            // pivotGridField1
            // 
            this.pivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField1.AreaIndex = 0;
            this.pivotGridField1.Caption = "Package Code";
            this.pivotGridField1.CellFormat.FormatString = "d/MM/yyyy";
            this.pivotGridField1.CellFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.pivotGridField1.FieldName = "strCode";
            this.pivotGridField1.Name = "pivotGridField1";
            this.pivotGridField1.SortBySummaryInfo.Field = this.pivotGridField4;
            this.pivotGridField1.SortOrder = DevExpress.XtraPivotGrid.PivotSortOrder.Descending;
            this.pivotGridField1.Width = 90;
            // 
            // pivotGridField2
            // 
            this.pivotGridField2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField2.AreaIndex = 1;
            this.pivotGridField2.Caption = "Description";
            this.pivotGridField2.FieldName = "strDescription";
            this.pivotGridField2.MinWidth = 40;
            this.pivotGridField2.Name = "pivotGridField2";
            this.pivotGridField2.SortBySummaryInfo.Field = this.pivotGridField4;
            this.pivotGridField2.Width = 90;
            // 
            // pivotGridField3
            // 
            this.pivotGridField3.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.pivotGridField3.AreaIndex = 0;
            this.pivotGridField3.Caption = "Branch";
            this.pivotGridField3.FieldName = "strBranchCode";
            this.pivotGridField3.Name = "pivotGridField3";
            this.pivotGridField3.SortBySummaryInfo.Field = this.pivotGridField4;
            this.pivotGridField3.Width = 75;
            // 
            // pivotGridField4
            // 
            this.pivotGridField4.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pivotGridField4.AreaIndex = 0;
            this.pivotGridField4.Caption = "Amount";
            this.pivotGridField4.FieldName = "nQuantity";
            this.pivotGridField4.Name = "pivotGridField4";
            this.pivotGridField4.Options.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.pivotGridField4.SortMode = DevExpress.XtraPivotGrid.PivotSortMode.Value;
            this.pivotGridField4.SortOrder = DevExpress.XtraPivotGrid.PivotSortOrder.Descending;
            this.pivotGridField4.Width = 90;
            // 
            // btnReset
            // 
            this.btnReset.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Appearance.Options.UseFont = true;
            this.btnReset.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnReset.Location = new System.Drawing.Point(842, 9);
            this.btnReset.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(48, 16);
            this.btnReset.TabIndex = 199;
            this.btnReset.Text = "Reset";
            this.btnReset.Visible = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // sbtnReset
            // 
            this.sbtnReset.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbtnReset.Appearance.Options.UseFont = true;
            this.sbtnReset.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnReset.Location = new System.Drawing.Point(406, 64);
            this.sbtnReset.LookAndFeel.UseDefaultLookAndFeel = false;
            this.sbtnReset.Name = "sbtnReset";
            this.sbtnReset.Size = new System.Drawing.Size(70, 30);
            this.sbtnReset.TabIndex = 200;
            this.sbtnReset.Text = "Enquiry";
            this.sbtnReset.Click += new System.EventHandler(this.sbtnReset_Click);
            // 
            // dateEdit1
            // 
            this.dateEdit1.Location = new System.Drawing.Point(207, -2);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.TabIndex = 201;
            // 
            // dateEdit2
            // 
            this.dateEdit2.Location = new System.Drawing.Point(502, -2);
            this.dateEdit2.Name = "dateEdit2";
            this.dateEdit2.TabIndex = 202;
            // 
            // dateEdit3
            // 
            this.dateEdit3.Location = new System.Drawing.Point(735, -2);
            this.dateEdit3.Name = "dateEdit3";
            this.dateEdit3.TabIndex = 203;
            this.dateEdit3.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.dateEdit3_DateSelected);
            // 
            // RPPromotionSalesPkg
            // 
            this.ClientSize = new System.Drawing.Size(976, 526);
            this.Controls.Add(this.dateEdit3);
            this.Controls.Add(this.dateEdit2);
            this.Controls.Add(this.dateEdit1);
            this.Controls.Add(this.sbtnReset);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.luedtRPStaffSalesPerfmCategory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridPromotionPackage);
            this.Name = "RPPromotionSalesPkg";
            this.Text = "Promotion Package Sales Analysis";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RPPromotionSalesPkg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.luedtRPStaffSalesPerfmCategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPromotionPackage)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void LoadReport()
		{
			if (!isFinishBindInit)
				return;

			string strSQL;
			DataSet _ds;
			
				// Total sales Collection
            strSQL = "up_Get_PromotionPackageSalesAnalysis " + EmployeeId + ",'" + dateEdit1.SelectionStart + "','" + dateEdit2.SelectionStart + "'";
				_ds = new DataSet();
				SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
				DataTable dt = _ds.Tables["table"];
				DataView dv = new DataView(dt);

                string str = "(dtdate>='" + string.Format("{0:yyyy-MM-dd}", dateEdit1.SelectionStart) + "' and dtdate<='" + string.Format("{0:yyyy-MM-dd}", dateEdit2.SelectionStart) + "')";
			
				if (luedtRPStaffSalesPerfmCategory.EditValue != null && luedtRPStaffSalesPerfmCategory.EditValue.ToString() != "")
					str += " And nCategoryID = '" + luedtRPStaffSalesPerfmCategory.EditValue + "'";
			
				dv.RowFilter = str;

				this.gridPromotionPackage.DataSource = dv;
		
		
		}

        private void LoadDayReport()
        {
            if (!isFinishBindInit)
                return;

            string strSQL;
            DataSet _ds;

            // Total sales Collection
            strSQL = "up_Get_PromotionPackageSalesAnalysis " + EmployeeId + ",'" + dateEdit3.SelectionStart + "','" + dateEdit3.SelectionStart + "'";
            _ds = new DataSet();
            SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA", _ds, new string[] { "table" }, new SqlParameter("@strSQL", strSQL));
            DataTable dt = _ds.Tables["table"];
            DataView dv = new DataView(dt);

            string str = "(dtdate>='" + string.Format("{0:yyyy-MM-dd}", dateEdit3.SelectionStart) + "' and dtdate<='" + string.Format("{0:yyyy-MM-dd}", dateEdit3.SelectionStart) + "')";

            if (luedtRPStaffSalesPerfmCategory.EditValue != null && luedtRPStaffSalesPerfmCategory.EditValue.ToString() != "")
                str += " And nCategoryID = '" + luedtRPStaffSalesPerfmCategory.EditValue + "'";

            dv.RowFilter = str;

            this.gridPromotionPackage.DataSource = dv;


        }
		private void RPPromotionSalesPkg_Load(object sender, System.EventArgs e)
		{

			new ACMS.XtraUtils.LookupEditBuilder.CategoryIDLookupEditBuilder(luedtRPStaffSalesPerfmCategory.Properties);
			isFinishBindInit = false;
            dateEdit1.SelectionStart = DateTime.Today;//string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year));
			isFinishBindInit = false;
            dateEdit2.SelectionStart = DateTime.Today;
			isFinishBindInit = true;
			LoadReport();
		
		}

		private void sbtnReset_Click(object sender, System.EventArgs e)
		{
			LoadReport();
		}

		private void btnReset_Click(object sender, System.EventArgs e)
		{
            dateEdit1.SelectionStart = DateTime.Today;//string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year));
            dateEdit2.SelectionStart = DateTime.Today;
			luedtRPStaffSalesPerfmCategory.EditValue = null;
			LoadReport();
		}

        private void gridPromotionPackage_Click(object sender, EventArgs e)
        {

        }

        private void dateEdit3_DateSelected(object sender, DateRangeEventArgs e)
        {
            LoadDayReport();
        }

	


	}
}
