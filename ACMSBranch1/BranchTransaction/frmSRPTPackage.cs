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
	/// Summary description for frmSRPTPackage.
	/// </summary>
	public class frmSRPTPackage : System.Windows.Forms.Form
	{
		private string connectionString;
		private SqlConnection connection;
		private DevExpress.XtraGrid.GridControl gridPTPackage;
		private DevExpress.XtraGrid.Views.Grid.GridView gvPTPackage;
		private DevExpress.XtraGrid.Columns.GridColumn gvPTPackageRank;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
		private DevExpress.XtraGrid.Columns.GridColumn gvPTPackageSalesPercentage;
		private DevExpress.XtraGrid.Columns.GridColumn gvPTPackageTotalSales;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView7;
		private System.Windows.Forms.Label label6;
		private DevExpress.XtraEditors.RadioGroup RGPTPackage;
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

		public frmSRPTPackage()
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
			this.gridPTPackage = new DevExpress.XtraGrid.GridControl();
			this.gvPTPackage = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gvPTPackageRank = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.lk_Employee = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvPTPackageSalesPercentage = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvPTPackageTotalSales = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridView7 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.label6 = new System.Windows.Forms.Label();
			this.RGPTPackage = new DevExpress.XtraEditors.RadioGroup();
			this.label79 = new System.Windows.Forms.Label();
			this.label80 = new System.Windows.Forms.Label();
			this.Month = new DevExpress.XtraEditors.ComboBoxEdit();
			this.Year = new DevExpress.XtraEditors.ComboBoxEdit();
			((System.ComponentModel.ISupportInitialize)(this.gridPTPackage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvPTPackage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_Employee)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView7)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.RGPTPackage.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Month.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Year.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// gridPTPackage
			// 
			this.gridPTPackage.Dock = System.Windows.Forms.DockStyle.Bottom;
			// 
			// gridPTPackage.EmbeddedNavigator
			// 
			this.gridPTPackage.EmbeddedNavigator.Name = "";
			this.gridPTPackage.Location = new System.Drawing.Point(0, 96);
			this.gridPTPackage.MainView = this.gvPTPackage;
			this.gridPTPackage.Name = "gridPTPackage";
			this.gridPTPackage.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																												   this.lk_Employee});
			this.gridPTPackage.Size = new System.Drawing.Size(960, 384);
			this.gridPTPackage.TabIndex = 16;
			this.gridPTPackage.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										 this.gvPTPackage,
																										 this.gridView7});
			// 
			// gvPTPackage
			// 
			this.gvPTPackage.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							   this.gvPTPackageRank,
																							   this.gridColumn11,
																							   this.gridColumn12,
																							   this.gvPTPackageSalesPercentage,
																							   this.gvPTPackageTotalSales});
			this.gvPTPackage.GridControl = this.gridPTPackage;
			this.gvPTPackage.Name = "gvPTPackage";
			this.gvPTPackage.OptionsBehavior.Editable = false;
			this.gvPTPackage.OptionsCustomization.AllowFilter = false;
			this.gvPTPackage.OptionsCustomization.AllowGroup = false;
			this.gvPTPackage.OptionsCustomization.AllowSort = false;
			this.gvPTPackage.OptionsView.ShowGroupPanel = false;
			this.gvPTPackage.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gvPTPackage_CustomUnboundColumnData);
			this.gvPTPackage.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvPTPackage_FocusedRowChanged);
			// 
			// gvPTPackageRank
			// 
			this.gvPTPackageRank.Caption = "Rank";
			this.gvPTPackageRank.FieldName = "gridColumn1";
			this.gvPTPackageRank.Name = "gvPTPackageRank";
			this.gvPTPackageRank.SummaryItem.DisplayFormat = "{0}";
			this.gvPTPackageRank.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
			this.gvPTPackageRank.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
			this.gvPTPackageRank.Visible = true;
			this.gvPTPackageRank.VisibleIndex = 0;
			this.gvPTPackageRank.Width = 50;
			// 
			// gridColumn11
			// 
			this.gridColumn11.Caption = "Employee Name";
			this.gridColumn11.ColumnEdit = this.lk_Employee;
			this.gridColumn11.FieldName = "nSalesPersonID";
			this.gridColumn11.Name = "gridColumn11";
			this.gridColumn11.Visible = true;
			this.gridColumn11.VisibleIndex = 1;
			this.gridColumn11.Width = 54;
			// 
			// lk_Employee
			// 
			this.lk_Employee.AutoHeight = false;
			this.lk_Employee.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																									 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lk_Employee.Name = "lk_Employee";
			// 
			// gridColumn12
			// 
			this.gridColumn12.Caption = "Branch Code";
			this.gridColumn12.FieldName = "strBranchCode";
			this.gridColumn12.Name = "gridColumn12";
			this.gridColumn12.Visible = true;
			this.gridColumn12.VisibleIndex = 4;
			this.gridColumn12.Width = 72;
			// 
			// gvPTPackageSalesPercentage
			// 
			this.gvPTPackageSalesPercentage.Caption = "Sales Percentage";
			this.gvPTPackageSalesPercentage.FieldName = "SalesPercentage";
			this.gvPTPackageSalesPercentage.Name = "gvPTPackageSalesPercentage";
			this.gvPTPackageSalesPercentage.Visible = true;
			this.gvPTPackageSalesPercentage.VisibleIndex = 2;
			this.gvPTPackageSalesPercentage.Width = 54;
			// 
			// gvPTPackageTotalSales
			// 
			this.gvPTPackageTotalSales.Caption = "Total Sales";
			this.gvPTPackageTotalSales.FieldName = "TotalSales";
			this.gvPTPackageTotalSales.Name = "gvPTPackageTotalSales";
			this.gvPTPackageTotalSales.Visible = true;
			this.gvPTPackageTotalSales.VisibleIndex = 3;
			this.gvPTPackageTotalSales.Width = 54;
			// 
			// gridView7
			// 
			this.gridView7.GridControl = this.gridPTPackage;
			this.gridView7.Name = "gridView7";
			// 
			// label6
			// 
			this.label6.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label6.Location = new System.Drawing.Point(0, 40);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(944, 24);
			this.label6.TabIndex = 18;
			this.label6.Text = "Ranking of Personal Trainer Sales";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// RGPTPackage
			// 
			this.RGPTPackage.EditValue = 0;
			this.RGPTPackage.Location = new System.Drawing.Point(0, 64);
			this.RGPTPackage.Name = "RGPTPackage";
			// 
			// RGPTPackage.Properties
			// 
			this.RGPTPackage.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.RGPTPackage.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.RGPTPackage.Properties.Appearance.Options.UseBackColor = true;
			this.RGPTPackage.Properties.Appearance.Options.UseFont = true;
			this.RGPTPackage.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.RGPTPackage.Properties.Columns = 2;
			this.RGPTPackage.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
																												new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Personal Trainer Sales By %"),
																												new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Actual Personal Trainer Sales")});
			this.RGPTPackage.Size = new System.Drawing.Size(496, 32);
			this.RGPTPackage.TabIndex = 17;
			this.RGPTPackage.Click += new System.EventHandler(this.RGPTPackage_Click);
			this.RGPTPackage.SelectedIndexChanged += new System.EventHandler(this.RGPTPackage_SelectedIndexChanged);
			// 
			// label79
			// 
			this.label79.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label79.Location = new System.Drawing.Point(144, 8);
			this.label79.Name = "label79";
			this.label79.Size = new System.Drawing.Size(48, 23);
			this.label79.TabIndex = 35;
			this.label79.Text = "Year";
			// 
			// label80
			// 
			this.label80.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label80.Location = new System.Drawing.Point(8, 8);
			this.label80.Name = "label80";
			this.label80.Size = new System.Drawing.Size(56, 23);
			this.label80.TabIndex = 34;
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
			this.Month.TabIndex = 33;
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
			this.Year.TabIndex = 32;
			this.Year.SelectedIndexChanged += new System.EventHandler(this.Year_SelectedIndexChanged);
			// 
			// frmSRPTPackage
			// 
			this.AutoScale = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(960, 480);
			this.Controls.Add(this.label79);
			this.Controls.Add(this.label80);
			this.Controls.Add(this.Month);
			this.Controls.Add(this.Year);
			this.Controls.Add(this.gridPTPackage);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.RGPTPackage);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmSRPTPackage";
			this.Text = "frmSRPTPackage";
			this.Load += new System.EventHandler(this.frmSRPTPackage_Load);
			((System.ComponentModel.ISupportInitialize)(this.gridPTPackage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvPTPackage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_Employee)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView7)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.RGPTPackage.Properties)).EndInit();
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

			//Fitness Package
			if (IsFinishedInit)
			{
				try
				{
					_ds = new DataSet();
					_ds = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "UP_ComSalesRankPTPackage", 
						new SqlParameter("@Month",Convert.ToInt32(Month.EditValue)),
						new SqlParameter("@Year",Convert.ToInt32(Year.EditValue))
						);
					DTSalesRank = _ds.Tables["table"];
					gridPTPackage.DataSource = DTSalesRank;
					RGPTPackage_SelectedIndexChanged(this,e);
					
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

		private void RGPTPackage_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			i = 1;
			if (RGPTPackage.SelectedIndex == 0)
			{
				gvPTPackage.Columns.ColumnByName("gvPTPackageTotalSales").SortOrder =  DevExpress.Data.ColumnSortOrder.None;
				gvPTPackage.Columns.ColumnByName("gvPTPackageSalesPercentage").SortOrder =  DevExpress.Data.ColumnSortOrder.Descending;
			}
			else
			{
				gvPTPackage.Columns.ColumnByName("gvPTPackageSalesPercentage").SortOrder =  DevExpress.Data.ColumnSortOrder.None;
				gvPTPackage.Columns.ColumnByName("gvPTPackageTotalSales").SortOrder =  DevExpress.Data.ColumnSortOrder.Descending;
				
			}

		}
		
		private void gvPTPackage_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
		{
			this.SuspendLayout();
			i = e.RowHandle+1;
			if (e.Column.Name == "gvPTPackageRank" && i<=gvPTPackage.RowCount)
			{
				e.Value = i;
				i = i + 1;
			}

			if (i>gvPTPackage.RowCount)
			{
				i = 1;
			}
			
			this.ResumeLayout();

		}

		private void frmSRPTPackage_Load(object sender, System.EventArgs e)
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

		private void gvPTPackage_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
		/*	DataRow dr = gvPTPackage.GetDataRow(gvPTPackage.FocusedRowHandle);
			if(dr!=null)
			{
				i = Convert.ToInt32(dr[0]);
			}*/
		}

		private void RGPTPackage_Click(object sender, System.EventArgs e)
		{
			i = 1;
		}




	}
}
