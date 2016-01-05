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
	/// Summary description for frmSRFitnessProduct.
	/// </summary>
	public class frmSRFitnessProduct : System.Windows.Forms.Form
	{
		private string connectionString;
		private SqlConnection connection;

		private System.Windows.Forms.Label label79;
		private System.Windows.Forms.Label label80;
		private DevExpress.XtraEditors.ComboBoxEdit Month;
		private DevExpress.XtraEditors.ComboBoxEdit Year;
		private DevExpress.XtraGrid.GridControl gridFitnessProduct;
		private DevExpress.XtraGrid.Views.Grid.GridView gvFitnessProduct;
		private DevExpress.XtraGrid.Columns.GridColumn gvFitnessProductRank;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraGrid.Columns.GridColumn gvFitnessProductSalesPercentage;
		private DevExpress.XtraGrid.Columns.GridColumn gvFitnessProductTotalSales;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
		private System.Windows.Forms.Label label4;
		private DevExpress.XtraEditors.RadioGroup RGFitnessProduct;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private bool IsFinishedInit = false;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_Employee;
		private DataTable DTSalesRank;


		public frmSRFitnessProduct()
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
			this.label79 = new System.Windows.Forms.Label();
			this.label80 = new System.Windows.Forms.Label();
			this.Month = new DevExpress.XtraEditors.ComboBoxEdit();
			this.Year = new DevExpress.XtraEditors.ComboBoxEdit();
			this.gridFitnessProduct = new DevExpress.XtraGrid.GridControl();
			this.gvFitnessProduct = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gvFitnessProductRank = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.lk_Employee = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvFitnessProductSalesPercentage = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvFitnessProductTotalSales = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.label4 = new System.Windows.Forms.Label();
			this.RGFitnessProduct = new DevExpress.XtraEditors.RadioGroup();
			((System.ComponentModel.ISupportInitialize)(this.Month.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Year.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridFitnessProduct)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvFitnessProduct)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_Employee)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.RGFitnessProduct.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// label79
			// 
			this.label79.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label79.Location = new System.Drawing.Point(144, 8);
			this.label79.Name = "label79";
			this.label79.Size = new System.Drawing.Size(48, 23);
			this.label79.TabIndex = 27;
			this.label79.Text = "Year";
			// 
			// label80
			// 
			this.label80.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label80.Location = new System.Drawing.Point(8, 8);
			this.label80.Name = "label80";
			this.label80.Size = new System.Drawing.Size(56, 23);
			this.label80.TabIndex = 26;
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
			this.Month.TabIndex = 25;
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
			this.Year.TabIndex = 24;
			this.Year.SelectedIndexChanged += new System.EventHandler(this.Year_SelectedIndexChanged);
			// 
			// gridFitnessProduct
			// 
			this.gridFitnessProduct.Dock = System.Windows.Forms.DockStyle.Bottom;
			// 
			// gridFitnessProduct.EmbeddedNavigator
			// 
			this.gridFitnessProduct.EmbeddedNavigator.Name = "";
			this.gridFitnessProduct.Location = new System.Drawing.Point(0, 96);
			this.gridFitnessProduct.MainView = this.gvFitnessProduct;
			this.gridFitnessProduct.Name = "gridFitnessProduct";
			this.gridFitnessProduct.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																														this.lk_Employee});
			this.gridFitnessProduct.Size = new System.Drawing.Size(960, 384);
			this.gridFitnessProduct.TabIndex = 28;
			this.gridFitnessProduct.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																											  this.gvFitnessProduct,
																											  this.gridView4});
			// 
			// gvFitnessProduct
			// 
			this.gvFitnessProduct.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																									this.gvFitnessProductRank,
																									this.gridColumn3,
																									this.gridColumn4,
																									this.gvFitnessProductSalesPercentage,
																									this.gvFitnessProductTotalSales});
			this.gvFitnessProduct.GridControl = this.gridFitnessProduct;
			this.gvFitnessProduct.Name = "gvFitnessProduct";
			this.gvFitnessProduct.OptionsBehavior.Editable = false;
			this.gvFitnessProduct.OptionsCustomization.AllowFilter = false;
			this.gvFitnessProduct.OptionsCustomization.AllowGroup = false;
			this.gvFitnessProduct.OptionsCustomization.AllowSort = false;
			this.gvFitnessProduct.OptionsView.ShowGroupPanel = false;
			this.gvFitnessProduct.FocusedColumnChanged += new DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventHandler(this.gvFitnessProduct_FocusedColumnChanged);
			this.gvFitnessProduct.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gvFitnessProduct_CustomUnboundColumnData);
			// 
			// gvFitnessProductRank
			// 
			this.gvFitnessProductRank.Caption = "Rank";
			this.gvFitnessProductRank.FieldName = "gridColumn1";
			this.gvFitnessProductRank.Name = "gvFitnessProductRank";
			this.gvFitnessProductRank.SummaryItem.DisplayFormat = "{0}";
			this.gvFitnessProductRank.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
			this.gvFitnessProductRank.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
			this.gvFitnessProductRank.Visible = true;
			this.gvFitnessProductRank.VisibleIndex = 0;
			this.gvFitnessProductRank.Width = 33;
			// 
			// gridColumn3
			// 
			this.gridColumn3.Caption = "Employee Name";
			this.gridColumn3.ColumnEdit = this.lk_Employee;
			this.gridColumn3.FieldName = "nSalesPersonID";
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 1;
			this.gridColumn3.Width = 85;
			// 
			// lk_Employee
			// 
			this.lk_Employee.AutoHeight = false;
			this.lk_Employee.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																									 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lk_Employee.Name = "lk_Employee";
			// 
			// gridColumn4
			// 
			this.gridColumn4.Caption = "Branch Code";
			this.gridColumn4.FieldName = "strBranchCode";
			this.gridColumn4.Name = "gridColumn4";
			this.gridColumn4.Visible = true;
			this.gridColumn4.VisibleIndex = 4;
			this.gridColumn4.Width = 70;
			// 
			// gvFitnessProductSalesPercentage
			// 
			this.gvFitnessProductSalesPercentage.Caption = "Sales Percentage";
			this.gvFitnessProductSalesPercentage.FieldName = "SalesPercentage";
			this.gvFitnessProductSalesPercentage.Name = "gvFitnessProductSalesPercentage";
			this.gvFitnessProductSalesPercentage.Visible = true;
			this.gvFitnessProductSalesPercentage.VisibleIndex = 2;
			this.gvFitnessProductSalesPercentage.Width = 92;
			// 
			// gvFitnessProductTotalSales
			// 
			this.gvFitnessProductTotalSales.Caption = "Total Sales";
			this.gvFitnessProductTotalSales.FieldName = "TotalSales";
			this.gvFitnessProductTotalSales.Name = "gvFitnessProductTotalSales";
			this.gvFitnessProductTotalSales.Visible = true;
			this.gvFitnessProductTotalSales.VisibleIndex = 3;
			this.gvFitnessProductTotalSales.Width = 61;
			// 
			// gridView4
			// 
			this.gridView4.GridControl = this.gridFitnessProduct;
			this.gridView4.Name = "gridView4";
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label4.ForeColor = System.Drawing.Color.Black;
			this.label4.Location = new System.Drawing.Point(0, 40);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(944, 24);
			this.label4.TabIndex = 30;
			this.label4.Text = "Ranking of Fitness Product Sales";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// RGFitnessProduct
			// 
			this.RGFitnessProduct.EditValue = 0;
			this.RGFitnessProduct.Location = new System.Drawing.Point(0, 64);
			this.RGFitnessProduct.Name = "RGFitnessProduct";
			// 
			// RGFitnessProduct.Properties
			// 
			this.RGFitnessProduct.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.RGFitnessProduct.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.RGFitnessProduct.Properties.Appearance.Options.UseBackColor = true;
			this.RGFitnessProduct.Properties.Appearance.Options.UseFont = true;
			this.RGFitnessProduct.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.RGFitnessProduct.Properties.Columns = 2;
			this.RGFitnessProduct.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
																													 new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Fitness Product Sales By %"),
																													 new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Actual Fitness Product Sales")});
			this.RGFitnessProduct.Size = new System.Drawing.Size(496, 32);
			this.RGFitnessProduct.TabIndex = 29;
			this.RGFitnessProduct.Click += new System.EventHandler(this.RGFitnessProduct_Click);
			this.RGFitnessProduct.EditValueChanged += new System.EventHandler(this.RGFitnessProduct_EditValueChanged);
			// 
			// frmSRFitnessProduct
			// 
			this.AutoScale = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(960, 480);
			this.Controls.Add(this.gridFitnessProduct);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.RGFitnessProduct);
			this.Controls.Add(this.label79);
			this.Controls.Add(this.label80);
			this.Controls.Add(this.Month);
			this.Controls.Add(this.Year);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmSRFitnessProduct";
			this.Text = "frmSRFitnessProduct";
			this.Load += new System.EventHandler(this.frmSRFitnessProduct_Load);
			((System.ComponentModel.ISupportInitialize)(this.Month.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Year.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridFitnessProduct)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvFitnessProduct)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_Employee)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.RGFitnessProduct.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private int i = 1;

		private void BindReport(System.EventArgs e)
		{
			i = 1;
			DataSet _ds;

			//Fitness Package
			if (IsFinishedInit)
			{
				try
				{
					_ds = new DataSet();
					_ds = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "UP_ComSalesRankFitnessProduct", 
						new SqlParameter("@Month",Convert.ToInt32(Month.EditValue)),
						new SqlParameter("@Year",Convert.ToInt32(Year.EditValue))
						);
					DTSalesRank = _ds.Tables["table"];
					gridFitnessProduct.DataSource = DTSalesRank;

					RGFitnessProduct_EditValueChanged(this,e);
					
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

		
		private void frmSRFitnessProduct_Load(object sender, System.EventArgs e)
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



		private void RGFitnessProduct_EditValueChanged(object sender, System.EventArgs e)
		{
			i = 1;
			if (RGFitnessProduct.SelectedIndex == 0)
			{
				gvFitnessProduct.Columns.ColumnByName("gvFitnessProductTotalSales").SortOrder =  DevExpress.Data.ColumnSortOrder.None;
				i=1;
				gvFitnessProduct.Columns.ColumnByName("gvFitnessProductSalesPercentage").SortOrder =  DevExpress.Data.ColumnSortOrder.Descending;
			}
			else
			{
				gvFitnessProduct.Columns.ColumnByName("gvFitnessProductSalesPercentage").SortOrder =  DevExpress.Data.ColumnSortOrder.None;
				i=1;
				gvFitnessProduct.Columns.ColumnByName("gvFitnessProductTotalSales").SortOrder =  DevExpress.Data.ColumnSortOrder.Descending;
				
			}
			
		
		}

		private void gvFitnessProduct_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
		{
			i = 1;
		}

		private void RGFitnessProduct_Click(object sender, System.EventArgs e)
		{
			i = 1;
		}

		private void gvFitnessProduct_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
		{
			this.SuspendLayout();
			i = e.RowHandle+1;
			if (e.Column.Name == "gvFitnessProductRank" && i<=gvFitnessProduct.RowCount)
			{
				e.Value = i;
				i = i + 1;
			}

			if (i>gvFitnessProduct.RowCount)
			{
				i = 1;
			}
			this.ResumeLayout();
		}





	}
}
