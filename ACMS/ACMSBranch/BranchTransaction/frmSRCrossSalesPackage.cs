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

namespace ACMS.ACMSBranch.BranchTransaction
{
	/// <summary>
	/// Summary description for frmSRCrossSalesPackage.
	/// </summary>
	public class frmSRCrossSalesPackage : System.Windows.Forms.Form
	{
		private string connectionString;
		private SqlConnection connection;
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.RadioGroup RGCrossSalesPackage;
		private DevExpress.XtraGrid.GridControl gridCrossSalesPackage;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
		private DevExpress.XtraGrid.Columns.GridColumn SalesPercentage;
		private DevExpress.XtraGrid.Columns.GridColumn SalesTotal;
		
		private System.Windows.Forms.Label label79;
		private System.Windows.Forms.Label label80;
		private DevExpress.XtraEditors.ComboBoxEdit Month;
		private DevExpress.XtraEditors.ComboBoxEdit Year;
		private DevExpress.XtraGrid.Columns.GridColumn Rank;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private bool IsFinishedInit = false;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_Employee;
        private Button button1;
		private DataTable DTSalesRank;

		public frmSRCrossSalesPackage()
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
            this.label1 = new System.Windows.Forms.Label();
            this.RGCrossSalesPackage = new DevExpress.XtraEditors.RadioGroup();
            this.gridCrossSalesPackage = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Rank = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lk_Employee = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SalesPercentage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SalesTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label79 = new System.Windows.Forms.Label();
            this.label80 = new System.Windows.Forms.Label();
            this.Month = new DevExpress.XtraEditors.ComboBoxEdit();
            this.Year = new DevExpress.XtraEditors.ComboBoxEdit();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.RGCrossSalesPackage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCrossSalesPackage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_Employee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Month.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Year.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Gray;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(952, 24);
            this.label1.TabIndex = 11;
            this.label1.Text = "Ranking of Cross Selling Sales";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RGCrossSalesPackage
            // 
            this.RGCrossSalesPackage.EditValue = 0;
            this.RGCrossSalesPackage.Location = new System.Drawing.Point(0, 64);
            this.RGCrossSalesPackage.Name = "RGCrossSalesPackage";
            this.RGCrossSalesPackage.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.RGCrossSalesPackage.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RGCrossSalesPackage.Properties.Appearance.Options.UseBackColor = true;
            this.RGCrossSalesPackage.Properties.Appearance.Options.UseFont = true;
            this.RGCrossSalesPackage.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.RGCrossSalesPackage.Properties.Columns = 2;
            this.RGCrossSalesPackage.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Cross Selling Sales By %"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Actual Cross Selling Sales")});
            this.RGCrossSalesPackage.Size = new System.Drawing.Size(496, 32);
            this.RGCrossSalesPackage.TabIndex = 10;
            this.RGCrossSalesPackage.EditValueChanged += new System.EventHandler(this.RGCrossSalesPackage_EditValueChanged);
            this.RGCrossSalesPackage.Click += new System.EventHandler(this.RGCrossSalesPackage_Click);
            // 
            // gridCrossSalesPackage
            // 
            this.gridCrossSalesPackage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridCrossSalesPackage.Location = new System.Drawing.Point(0, 96);
            this.gridCrossSalesPackage.MainView = this.gridView2;
            this.gridCrossSalesPackage.Name = "gridCrossSalesPackage";
            this.gridCrossSalesPackage.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lk_Employee});
            this.gridCrossSalesPackage.Size = new System.Drawing.Size(960, 384);
            this.gridCrossSalesPackage.TabIndex = 9;
            this.gridCrossSalesPackage.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Rank,
            this.gridColumn2,
            this.gridColumn5,
            this.SalesPercentage,
            this.SalesTotal});
            this.gridView2.GridControl = this.gridCrossSalesPackage;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsCustomization.AllowFilter = false;
            this.gridView2.OptionsCustomization.AllowGroup = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridView2_CustomUnboundColumnData);
            // 
            // Rank
            // 
            this.Rank.Caption = "Rank";
            this.Rank.FieldName = "Rank";
            this.Rank.Name = "Rank";
            this.Rank.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.Rank.Visible = true;
            this.Rank.VisibleIndex = 0;
            this.Rank.Width = 33;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Employee Name";
            this.gridColumn2.ColumnEdit = this.lk_Employee;
            this.gridColumn2.FieldName = "nSalesPersonID";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 85;
            // 
            // lk_Employee
            // 
            this.lk_Employee.AutoHeight = false;
            this.lk_Employee.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lk_Employee.Name = "lk_Employee";
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Branch Code";
            this.gridColumn5.FieldName = "strBranchCode";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 70;
            // 
            // SalesPercentage
            // 
            this.SalesPercentage.Caption = "Sales Percentage";
            this.SalesPercentage.FieldName = "SalesPercentage";
            this.SalesPercentage.Name = "SalesPercentage";
            this.SalesPercentage.Visible = true;
            this.SalesPercentage.VisibleIndex = 2;
            this.SalesPercentage.Width = 92;
            // 
            // SalesTotal
            // 
            this.SalesTotal.Caption = "Total Sales";
            this.SalesTotal.FieldName = "TotalSales";
            this.SalesTotal.Name = "SalesTotal";
            this.SalesTotal.Visible = true;
            this.SalesTotal.VisibleIndex = 3;
            this.SalesTotal.Width = 61;
            // 
            // label79
            // 
            this.label79.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label79.Location = new System.Drawing.Point(144, 8);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(48, 23);
            this.label79.TabIndex = 23;
            this.label79.Text = "Year";
            // 
            // label80
            // 
            this.label80.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label80.Location = new System.Drawing.Point(8, 8);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(56, 23);
            this.label80.TabIndex = 22;
            this.label80.Text = "Month";
            // 
            // Month
            // 
            this.Month.EditValue = "1";
            this.Month.Location = new System.Drawing.Point(64, 8);
            this.Month.Name = "Month";
            this.Month.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Month.Properties.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.Month.Size = new System.Drawing.Size(72, 20);
            this.Month.TabIndex = 21;
            this.Month.SelectedIndexChanged += new System.EventHandler(this.Month_SelectedIndexChanged);
            // 
            // Year
            // 
            this.Year.EditValue = "";
            this.Year.Location = new System.Drawing.Point(192, 8);
            this.Year.Name = "Year";
            this.Year.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Year.Size = new System.Drawing.Size(96, 20);
            this.Year.TabIndex = 20;
            this.Year.SelectedIndexChanged += new System.EventHandler(this.Year_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(491, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 24;
            this.button1.Text = "Print";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmSRCrossSalesPackage
            // 
            this.ClientSize = new System.Drawing.Size(960, 480);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label79);
            this.Controls.Add(this.label80);
            this.Controls.Add(this.Month);
            this.Controls.Add(this.Year);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RGCrossSalesPackage);
            this.Controls.Add(this.gridCrossSalesPackage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSRCrossSalesPackage";
            this.Text = "frmSRCrossSalesPackage";
            this.Load += new System.EventHandler(this.frmSRCrossSalesPackage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RGCrossSalesPackage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCrossSalesPackage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_Employee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Month.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Year.Properties)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private int i = 0;
		private void BindReport(System.EventArgs e)
		{
			i = 1;
			DataSet _ds;

			//Cross Selling
			if (IsFinishedInit)
			{
				try
				{
					_ds = new DataSet();
                    _ds = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "UP_ComSalesRankCrossSalesPack", 
						new SqlParameter("@Month",Convert.ToInt32(Month.EditValue)),
						new SqlParameter("@Year",Convert.ToInt32(Year.EditValue))
					);
					DTSalesRank = _ds.Tables["table"];
					gridCrossSalesPackage.DataSource = DTSalesRank;
					RGCrossSalesPackage_EditValueChanged(this,e);
				}
				catch(Exception ex)
                {
					MessageBox.Show(ex.ToString());
				}
			}
			
		}

		private void RefreshGrid()
		{
			DataView dv;
			dv = new DataView(DTSalesRank);
			dv.RowFilter = string.Format("sMonth={0} And sYear={1}", Month.EditValue, Year.EditValue);
			gridCrossSalesPackage.DataSource = dv;
		}
		private void BindCalendar()
		{
			Year.Properties.Items.Insert(0,new DevExpress.XtraEditors.Controls.ImageComboBoxItem(DateTime.Now.Year - 1,DateTime.Now.Year - 1));
			Year.Properties.Items.Insert(0,new DevExpress.XtraEditors.Controls.ImageComboBoxItem(DateTime.Now.Year,DateTime.Now.Year));

			Year.SelectedIndex = 0;
		}
		private void Month_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			BindReport(e);
		}

		private void Year_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			BindReport(e);
		}

		private void gridView2_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
		{
			this.SuspendLayout();
			i = e.RowHandle+1;
			if (e.Column.Name == "Rank" && i<=gridView2.RowCount)
			{
				e.Value = i;
				i = i + 1;
			}

			if( i>gridView2.RowCount)
			{
				i = 1;
			}
			this.ResumeLayout();
		}

		private void frmSRCrossSalesPackage_Load(object sender, System.EventArgs e)
		{
			BindCalendar();
			string strSQL = "select month(current_timestamp) cmonth,year(current_timestamp) cyear";
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			DataTable dt = _ds.Tables["table"];
			IsFinishedInit = true;
			foreach( DataRow dr in dt.Rows)
			{
				Month.EditValue = dr[0];
				Year.EditValue = dr[1];
			}
			load_EmployeeList();
		}

		private void load_EmployeeList()
		{
			DataSet _ds = new DataSet();
			string strSQL;

			strSQL = "select nEmployeeID, strEmployeeName from TblEmployee where nStatusID=1 and fSalesPerson=1";
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			DataTable dt = _ds.Tables["table"];
			
			DevExpress.XtraEditors.Controls.LookUpColumnInfo[] col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
			
			col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nEmployeeID","ID",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strEmployeeName","Employee Name",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);

			//new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(this.luedtItemPromotion.Properties, dt, col, "strDescription", "strPromotionCode", "Promotion");

			new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(this.lk_Employee.Properties,dt,col,"strEmployeeName","nEmployeeID","Employee Name");		

		}

		private void RGCrossSalesPackage_EditValueChanged(object sender, System.EventArgs e)
		{

			i = 1;
			if (RGCrossSalesPackage.SelectedIndex == 0)
			{
				gridView2.Columns.ColumnByName("SalesTotal").SortOrder =  DevExpress.Data.ColumnSortOrder.None;
				gridView2.Columns.ColumnByName("SalesPercentage").SortOrder =  DevExpress.Data.ColumnSortOrder.Descending;
			}
			else
			{
				gridView2.Columns.ColumnByName("SalesPercentage").SortOrder =  DevExpress.Data.ColumnSortOrder.None;
				gridView2.Columns.ColumnByName("SalesTotal").SortOrder =  DevExpress.Data.ColumnSortOrder.Descending;
			}
		}

		private void RGCrossSalesPackage_Click(object sender, System.EventArgs e)
		{
			i = 1;
		}

        private void button1_Click(object sender, EventArgs e)
        {
            gridCrossSalesPackage.Print();
        }

	}
}
