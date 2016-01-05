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
	/// Summary description for frmSRSPAPackage.
	/// </summary>
	public class frmSRSPAPackage : System.Windows.Forms.Form
	{
		private string connectionString;
		private SqlConnection connection;
		private DevExpress.XtraGrid.GridControl gridSpaService;
		private DevExpress.XtraGrid.Views.Grid.GridView gvSpaService;
		private DevExpress.XtraGrid.Columns.GridColumn gvSpaServiceRank;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
		private DevExpress.XtraGrid.Columns.GridColumn gvSpaServiceSalesPercentage;
		private DevExpress.XtraGrid.Columns.GridColumn gvSpaServiceTotalSales;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView9;
		private System.Windows.Forms.Label label8;
		private DevExpress.XtraEditors.RadioGroup RGSpaService;
		private System.Windows.Forms.Label label79;
		private System.Windows.Forms.Label label80;
		private DevExpress.XtraEditors.ComboBoxEdit Month;
		private DevExpress.XtraEditors.ComboBoxEdit Year;
		private bool IsFinishedInit = false;
		private DataTable DTSalesRank;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_Employee;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmSRSPAPackage()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);


			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			this.gridSpaService = new DevExpress.XtraGrid.GridControl();
			this.gvSpaService = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gvSpaServiceRank = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvSpaServiceSalesPercentage = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvSpaServiceTotalSales = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridView9 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.label8 = new System.Windows.Forms.Label();
			this.RGSpaService = new DevExpress.XtraEditors.RadioGroup();
			this.label79 = new System.Windows.Forms.Label();
			this.label80 = new System.Windows.Forms.Label();
			this.Month = new DevExpress.XtraEditors.ComboBoxEdit();
			this.Year = new DevExpress.XtraEditors.ComboBoxEdit();
			this.lk_Employee = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			((System.ComponentModel.ISupportInitialize)(this.gridSpaService)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvSpaService)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView9)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.RGSpaService.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Month.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Year.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_Employee)).BeginInit();
			this.SuspendLayout();
			// 
			// gridSpaService
			// 
			this.gridSpaService.Dock = System.Windows.Forms.DockStyle.Bottom;
			// 
			// gridSpaService.EmbeddedNavigator
			// 
			this.gridSpaService.EmbeddedNavigator.Name = "";
			this.gridSpaService.Location = new System.Drawing.Point(0, 88);
			this.gridSpaService.MainView = this.gvSpaService;
			this.gridSpaService.Name = "gridSpaService";
			this.gridSpaService.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																													this.lk_Employee});
			this.gridSpaService.Size = new System.Drawing.Size(960, 392);
			this.gridSpaService.TabIndex = 19;
			this.gridSpaService.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										  this.gvSpaService,
																										  this.gridView9});
			// 
			// gvSpaService
			// 
			this.gvSpaService.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																								this.gvSpaServiceRank,
																								this.gridColumn15,
																								this.gridColumn16,
																								this.gvSpaServiceSalesPercentage,
																								this.gvSpaServiceTotalSales});
			this.gvSpaService.GridControl = this.gridSpaService;
			this.gvSpaService.Name = "gvSpaService";
			this.gvSpaService.OptionsBehavior.Editable = false;
			this.gvSpaService.OptionsCustomization.AllowFilter = false;
			this.gvSpaService.OptionsCustomization.AllowGroup = false;
			this.gvSpaService.OptionsCustomization.AllowSort = false;
			this.gvSpaService.OptionsView.ShowGroupPanel = false;
			this.gvSpaService.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gvSpaService_CustomUnboundColumnData);
			this.gvSpaService.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvSpaService_FocusedRowChanged);
			// 
			// gvSpaServiceRank
			// 
			this.gvSpaServiceRank.Caption = "Rank";
			this.gvSpaServiceRank.FieldName = "gridColumn1";
			this.gvSpaServiceRank.Name = "gvSpaServiceRank";
			this.gvSpaServiceRank.SummaryItem.DisplayFormat = "{0}";
			this.gvSpaServiceRank.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
			this.gvSpaServiceRank.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
			this.gvSpaServiceRank.Visible = true;
			this.gvSpaServiceRank.VisibleIndex = 0;
			this.gvSpaServiceRank.Width = 50;
			// 
			// gridColumn15
			// 
			this.gridColumn15.Caption = "Employee Name";
			this.gridColumn15.ColumnEdit = this.lk_Employee;
			this.gridColumn15.FieldName = "nSalesPersonID";
			this.gridColumn15.Name = "gridColumn15";
			this.gridColumn15.Visible = true;
			this.gridColumn15.VisibleIndex = 1;
			this.gridColumn15.Width = 54;
			// 
			// gridColumn16
			// 
			this.gridColumn16.Caption = "Branch Code";
			this.gridColumn16.FieldName = "strBranchCode";
			this.gridColumn16.Name = "gridColumn16";
			this.gridColumn16.Visible = true;
			this.gridColumn16.VisibleIndex = 4;
			this.gridColumn16.Width = 72;
			// 
			// gvSpaServiceSalesPercentage
			// 
			this.gvSpaServiceSalesPercentage.Caption = "Sales Percentage";
			this.gvSpaServiceSalesPercentage.FieldName = "SalesPercentage";
			this.gvSpaServiceSalesPercentage.Name = "gvSpaServiceSalesPercentage";
			this.gvSpaServiceSalesPercentage.Visible = true;
			this.gvSpaServiceSalesPercentage.VisibleIndex = 2;
			this.gvSpaServiceSalesPercentage.Width = 54;
			// 
			// gvSpaServiceTotalSales
			// 
			this.gvSpaServiceTotalSales.Caption = "Total Sales";
			this.gvSpaServiceTotalSales.FieldName = "TotalSales";
			this.gvSpaServiceTotalSales.Name = "gvSpaServiceTotalSales";
			this.gvSpaServiceTotalSales.Visible = true;
			this.gvSpaServiceTotalSales.VisibleIndex = 3;
			this.gvSpaServiceTotalSales.Width = 54;
			// 
			// gridView9
			// 
			this.gridView9.GridControl = this.gridSpaService;
			this.gridView9.Name = "gridView9";
			// 
			// label8
			// 
			this.label8.BackColor = System.Drawing.Color.Gray;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label8.Location = new System.Drawing.Point(0, 40);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(944, 24);
			this.label8.TabIndex = 21;
			this.label8.Text = "Ranking of Spa Service Sales";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// RGSpaService
			// 
			this.RGSpaService.EditValue = 0;
			this.RGSpaService.Location = new System.Drawing.Point(0, 64);
			this.RGSpaService.Name = "RGSpaService";
			// 
			// RGSpaService.Properties
			// 
			this.RGSpaService.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.RGSpaService.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.RGSpaService.Properties.Appearance.Options.UseBackColor = true;
			this.RGSpaService.Properties.Appearance.Options.UseFont = true;
			this.RGSpaService.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.RGSpaService.Properties.Columns = 2;
			this.RGSpaService.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
																												 new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Spa Service Sales By %"),
																												 new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Actual Spa Service Sales")});
			this.RGSpaService.Size = new System.Drawing.Size(448, 24);
			this.RGSpaService.TabIndex = 20;
			this.RGSpaService.Click += new System.EventHandler(this.RGSpaService_Click);
			this.RGSpaService.SelectedIndexChanged += new System.EventHandler(this.RGSpaService_SelectedIndexChanged);
			// 
			// label79
			// 
			this.label79.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label79.Location = new System.Drawing.Point(144, 8);
			this.label79.Name = "label79";
			this.label79.Size = new System.Drawing.Size(48, 23);
			this.label79.TabIndex = 43;
			this.label79.Text = "Year";
			// 
			// label80
			// 
			this.label80.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label80.Location = new System.Drawing.Point(8, 8);
			this.label80.Name = "label80";
			this.label80.Size = new System.Drawing.Size(56, 23);
			this.label80.TabIndex = 42;
			this.label80.Text = "Month";
			// 
			// Month
			// 
			this.Month.EditValue = "1";
			this.Month.Location = new System.Drawing.Point(64, 8);
			this.Month.Name = "Month";
			// 
			// Month.Properties
			// 
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
			this.Month.TabIndex = 41;
			this.Month.SelectedIndexChanged += new System.EventHandler(this.Month_SelectedIndexChanged);
			// 
			// Year
			// 
			this.Year.EditValue = "";
			this.Year.Location = new System.Drawing.Point(192, 8);
			this.Year.Name = "Year";
			// 
			// Year.Properties
			// 
			this.Year.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																										 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.Year.Size = new System.Drawing.Size(96, 20);
			this.Year.TabIndex = 40;
			this.Year.SelectedIndexChanged += new System.EventHandler(this.Year_SelectedIndexChanged);
			// 
			// lk_Employee
			// 
			this.lk_Employee.AutoHeight = false;
			this.lk_Employee.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																									 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lk_Employee.Name = "lk_Employee";
			// 
			// frmSRSPAPackage
			// 
			this.AutoScale = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(960, 480);
			this.Controls.Add(this.label79);
			this.Controls.Add(this.label80);
			this.Controls.Add(this.Month);
			this.Controls.Add(this.Year);
			this.Controls.Add(this.gridSpaService);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.RGSpaService);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmSRSPAPackage";
			this.Text = "frmSRSPAPackage";
			this.Load += new System.EventHandler(this.frmSRSPAPackage_Load);
			((System.ComponentModel.ISupportInitialize)(this.gridSpaService)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvSpaService)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView9)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.RGSpaService.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Month.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Year.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_Employee)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
		private int i = 1;

		private void BindReport(System.EventArgs e)
		{
			i = 1;
			DataSet _ds;

			//Spa Package
			if (IsFinishedInit)
			{
				try
				{
					_ds = new DataSet();
					_ds = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "UP_ComSalesRankSpaPackage", 
						new SqlParameter("@Month",Convert.ToInt32(Month.EditValue)),
						new SqlParameter("@Year",Convert.ToInt32(Year.EditValue))
						);
					DTSalesRank = _ds.Tables["table"];
					gridSpaService.DataSource = DTSalesRank;
					RGSpaService_SelectedIndexChanged(this,e);
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.ToString());
				}
			}
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

		private void gvSpaService_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
		{
			this.SuspendLayout();
			i = e.RowHandle+1;
			if (e.Column.Name == "gvSpaServiceRank" && i<=gvSpaService.RowCount)
			{
				e.Value = i;
				i = i + 1;
			}

			if ( i>gvSpaService.RowCount)
			{
				i = 1;
			}

			this.ResumeLayout();
		}

		private void RGSpaService_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			i = 1;
			if (RGSpaService.SelectedIndex == 0)
			{
				gvSpaService.Columns.ColumnByName("gvSpaServiceTotalSales").SortOrder =  DevExpress.Data.ColumnSortOrder.None;
				gvSpaService.Columns.ColumnByName("gvSpaServiceSalesPercentage").SortOrder =  DevExpress.Data.ColumnSortOrder.Descending;
			}
			else
			{
				gvSpaService.Columns.ColumnByName("gvSpaServiceSalesPercentage").SortOrder =  DevExpress.Data.ColumnSortOrder.None;
				gvSpaService.Columns.ColumnByName("gvSpaServiceTotalSales").SortOrder =  DevExpress.Data.ColumnSortOrder.Descending;
			}
		}

		private void frmSRSPAPackage_Load(object sender, System.EventArgs e)
		{
			BindCalendar();
			string strSQL = "select month(current_timestamp) cmonth,year(current_timestamp) cyear";
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			DataTable dt = _ds.Tables["table"];
			IsFinishedInit=true;
			foreach( DataRow dr in dt.Rows)
			{
				Month.EditValue = dr[0];
				Year.EditValue = dr[1];
			}

			load_EmployeeList();

			i = 1;
		}

		private void gvSpaService_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{/*
			DataRow dr = gvSpaService.GetDataRow(gvSpaService.FocusedRowHandle);
			if(dr!=null)
			{
				i = Convert.ToInt32(dr["gridColumn1"]);
			}
			*/
		}

		private void RGSpaService_Click(object sender, System.EventArgs e)
		{
			i = 1;
		}




	}
}
