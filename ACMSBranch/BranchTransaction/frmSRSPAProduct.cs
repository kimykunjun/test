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
	/// Summary description for frmSRSPAProduct.
	/// </summary>
	public class frmSRSPAProduct : System.Windows.Forms.Form
	{
		private string connectionString;
		private SqlConnection connection;
		private DevExpress.XtraGrid.GridControl gridSpaProduct;
		private DevExpress.XtraGrid.Views.Grid.GridView gvSpaProduct;
		private DevExpress.XtraGrid.Columns.GridColumn gvSpaProductRank;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
		private DevExpress.XtraGrid.Columns.GridColumn gvSpaProductSalesPercentage;
		private DevExpress.XtraGrid.Columns.GridColumn gvSpaProductTotalSales;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView5;
		private System.Windows.Forms.Label label5;
		private DevExpress.XtraEditors.RadioGroup RGSpaProduct;
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

		public frmSRSPAProduct()
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
			this.gridSpaProduct = new DevExpress.XtraGrid.GridControl();
			this.gvSpaProduct = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gvSpaProductRank = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.lk_Employee = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvSpaProductSalesPercentage = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvSpaProductTotalSales = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.label5 = new System.Windows.Forms.Label();
			this.RGSpaProduct = new DevExpress.XtraEditors.RadioGroup();
			this.label79 = new System.Windows.Forms.Label();
			this.label80 = new System.Windows.Forms.Label();
			this.Month = new DevExpress.XtraEditors.ComboBoxEdit();
			this.Year = new DevExpress.XtraEditors.ComboBoxEdit();
			((System.ComponentModel.ISupportInitialize)(this.gridSpaProduct)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvSpaProduct)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_Employee)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.RGSpaProduct.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Month.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Year.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// gridSpaProduct
			// 
			this.gridSpaProduct.Dock = System.Windows.Forms.DockStyle.Bottom;
			// 
			// gridSpaProduct.EmbeddedNavigator
			// 
			this.gridSpaProduct.EmbeddedNavigator.Name = "";
			this.gridSpaProduct.Location = new System.Drawing.Point(0, 88);
			this.gridSpaProduct.MainView = this.gvSpaProduct;
			this.gridSpaProduct.Name = "gridSpaProduct";
			this.gridSpaProduct.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																													this.lk_Employee});
			this.gridSpaProduct.Size = new System.Drawing.Size(960, 392);
			this.gridSpaProduct.TabIndex = 13;
			this.gridSpaProduct.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										  this.gvSpaProduct,
																										  this.gridView5});
			// 
			// gvSpaProduct
			// 
			this.gvSpaProduct.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																								this.gvSpaProductRank,
																								this.gridColumn6,
																								this.gridColumn7,
																								this.gvSpaProductSalesPercentage,
																								this.gvSpaProductTotalSales});
			this.gvSpaProduct.GridControl = this.gridSpaProduct;
			this.gvSpaProduct.Name = "gvSpaProduct";
			this.gvSpaProduct.OptionsBehavior.Editable = false;
			this.gvSpaProduct.OptionsCustomization.AllowFilter = false;
			this.gvSpaProduct.OptionsCustomization.AllowSort = false;
			this.gvSpaProduct.OptionsView.ShowGroupPanel = false;
			this.gvSpaProduct.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gvSpaProduct_CustomUnboundColumnData);
			// 
			// gvSpaProductRank
			// 
			this.gvSpaProductRank.Caption = "Rank";
			this.gvSpaProductRank.FieldName = "gridColumn1";
			this.gvSpaProductRank.Name = "gvSpaProductRank";
			this.gvSpaProductRank.SummaryItem.DisplayFormat = "{0}";
			this.gvSpaProductRank.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
			this.gvSpaProductRank.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
			this.gvSpaProductRank.Visible = true;
			this.gvSpaProductRank.VisibleIndex = 0;
			this.gvSpaProductRank.Width = 50;
			// 
			// gridColumn6
			// 
			this.gridColumn6.Caption = "Employee Name";
			this.gridColumn6.ColumnEdit = this.lk_Employee;
			this.gridColumn6.FieldName = "nSalesPersonID";
			this.gridColumn6.Name = "gridColumn6";
			this.gridColumn6.Visible = true;
			this.gridColumn6.VisibleIndex = 1;
			this.gridColumn6.Width = 54;
			// 
			// lk_Employee
			// 
			this.lk_Employee.AutoHeight = false;
			this.lk_Employee.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																									 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lk_Employee.Name = "lk_Employee";
			// 
			// gridColumn7
			// 
			this.gridColumn7.Caption = "Branch Code";
			this.gridColumn7.FieldName = "strBranchCode";
			this.gridColumn7.Name = "gridColumn7";
			this.gridColumn7.Visible = true;
			this.gridColumn7.VisibleIndex = 4;
			this.gridColumn7.Width = 72;
			// 
			// gvSpaProductSalesPercentage
			// 
			this.gvSpaProductSalesPercentage.Caption = "Sales Percentage";
			this.gvSpaProductSalesPercentage.FieldName = "SalesPercentage";
			this.gvSpaProductSalesPercentage.Name = "gvSpaProductSalesPercentage";
			this.gvSpaProductSalesPercentage.Visible = true;
			this.gvSpaProductSalesPercentage.VisibleIndex = 2;
			this.gvSpaProductSalesPercentage.Width = 54;
			// 
			// gvSpaProductTotalSales
			// 
			this.gvSpaProductTotalSales.Caption = "Total Sales";
			this.gvSpaProductTotalSales.FieldName = "TotalSales";
			this.gvSpaProductTotalSales.Name = "gvSpaProductTotalSales";
			this.gvSpaProductTotalSales.Visible = true;
			this.gvSpaProductTotalSales.VisibleIndex = 3;
			this.gvSpaProductTotalSales.Width = 54;
			// 
			// gridView5
			// 
			this.gridView5.GridControl = this.gridSpaProduct;
			this.gridView5.Name = "gridView5";
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.Color.Gray;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label5.Location = new System.Drawing.Point(0, 40);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(960, 24);
			this.label5.TabIndex = 15;
			this.label5.Text = "Ranking of Spa Product Sales";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// RGSpaProduct
			// 
			this.RGSpaProduct.EditValue = 0;
			this.RGSpaProduct.Location = new System.Drawing.Point(0, 64);
			this.RGSpaProduct.Name = "RGSpaProduct";
			// 
			// RGSpaProduct.Properties
			// 
			this.RGSpaProduct.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.RGSpaProduct.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.RGSpaProduct.Properties.Appearance.Options.UseBackColor = true;
			this.RGSpaProduct.Properties.Appearance.Options.UseFont = true;
			this.RGSpaProduct.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.RGSpaProduct.Properties.Columns = 2;
			this.RGSpaProduct.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
																												 new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Spa Product Sales By %"),
																												 new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Actual Spa Product Sales")});
			this.RGSpaProduct.Size = new System.Drawing.Size(440, 24);
			this.RGSpaProduct.TabIndex = 14;
			this.RGSpaProduct.Click += new System.EventHandler(this.RGSpaProduct_Click);
			this.RGSpaProduct.SelectedIndexChanged += new System.EventHandler(this.RGSpaProduct_SelectedIndexChanged);
			// 
			// label79
			// 
			this.label79.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label79.Location = new System.Drawing.Point(144, 8);
			this.label79.Name = "label79";
			this.label79.Size = new System.Drawing.Size(48, 23);
			this.label79.TabIndex = 39;
			this.label79.Text = "Year";
			// 
			// label80
			// 
			this.label80.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label80.Location = new System.Drawing.Point(8, 8);
			this.label80.Name = "label80";
			this.label80.Size = new System.Drawing.Size(56, 23);
			this.label80.TabIndex = 38;
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
			this.Month.TabIndex = 37;
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
			this.Year.TabIndex = 36;
			this.Year.SelectedIndexChanged += new System.EventHandler(this.Year_SelectedIndexChanged);
			// 
			// frmSRSPAProduct
			// 
			this.AutoScale = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(960, 480);
			this.Controls.Add(this.label79);
			this.Controls.Add(this.label80);
			this.Controls.Add(this.Month);
			this.Controls.Add(this.Year);
			this.Controls.Add(this.gridSpaProduct);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.RGSpaProduct);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmSRSPAProduct";
			this.Text = "frmSRSPAProduct";
			this.Load += new System.EventHandler(this.frmSRSPAProduct_Load);
			((System.ComponentModel.ISupportInitialize)(this.gridSpaProduct)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvSpaProduct)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_Employee)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.RGSpaProduct.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Month.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Year.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private int i = 1;

		private void BindReport(System.EventArgs e)
		{
			i = 1;
			DataSet _ds;

			if (IsFinishedInit)
			{
				try
				{
					_ds = new DataSet();
					_ds = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "UP_ComSalesRankSpaProduct", 
						new SqlParameter("@Month",Convert.ToInt32(Month.EditValue)),
						new SqlParameter("@Year",Convert.ToInt32(Year.EditValue))
						);
					DTSalesRank = _ds.Tables["table"];
					gridSpaProduct.DataSource = DTSalesRank;
					RGSpaProduct_SelectedIndexChanged(this,e);
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

		private void gvSpaProduct_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
		{
			this.SuspendLayout();
			i = e.RowHandle+1;
			if (e.Column.Name == "gvSpaProductRank" && i<=gvSpaProduct.RowCount)
			{
				e.Value = i;
				i = i + 1;
			}

			if ( i>gvSpaProduct.RowCount )
			{
				i =1;
			}
			this.ResumeLayout();
		}

		private void RGSpaProduct_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			i = 1;
			if (RGSpaProduct.SelectedIndex == 0)
			{
				gvSpaProduct.Columns.ColumnByName("gvSpaProductTotalSales").SortOrder =  DevExpress.Data.ColumnSortOrder.None;
				gvSpaProduct.Columns.ColumnByName("gvSpaProductSalesPercentage").SortOrder =  DevExpress.Data.ColumnSortOrder.Descending;
			}
			else
			{
				gvSpaProduct.Columns.ColumnByName("gvSpaProductSalesPercentage").SortOrder =  DevExpress.Data.ColumnSortOrder.None;
				gvSpaProduct.Columns.ColumnByName("gvSpaProductTotalSales").SortOrder =  DevExpress.Data.ColumnSortOrder.Descending;
			
			}
		}

		private void frmSRSPAProduct_Load(object sender, System.EventArgs e)
		{
			BindCalendar();
			string strSQL = "select month(current_timestamp) cmonth,year(current_timestamp) cyear";
			DataSet _ds = new DataSet();
			IsFinishedInit=true;
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			DataTable dt = _ds.Tables["table"];

			foreach( DataRow dr in dt.Rows)
			{
				Month.EditValue = dr[0];
				Year.EditValue = dr[1];
			}

			load_EmployeeList();
			BindReport(e);
			i = 1;
		
		}

		private void RGSpaProduct_Click(object sender, System.EventArgs e)
		{
			i = 1;
		}

	}
}
