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
	/// Summary description for frmSRIPLService.
	/// </summary>
	public class frmSRIPLService : System.Windows.Forms.Form
	{
		private string connectionString;
		private SqlConnection connection;
		private System.Windows.Forms.Label label79;
		private System.Windows.Forms.Label label80;
		private DevExpress.XtraEditors.ComboBoxEdit Month;
		private DevExpress.XtraEditors.ComboBoxEdit Year;
		private DevExpress.XtraGrid.GridControl gridIPLService;
		private DevExpress.XtraGrid.Views.Grid.GridView gvIPLService;
		private DevExpress.XtraGrid.Columns.GridColumn gvIPLServiceRank;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
		private DevExpress.XtraGrid.Columns.GridColumn gvIPLServiceSalesPercentage;
		private DevExpress.XtraGrid.Columns.GridColumn gvIPLServiceTotalSales;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView6;
		private System.Windows.Forms.Label label7;
		private DevExpress.XtraEditors.RadioGroup RGIPLService;
		private bool IsFinishedInit = false;
		private DataTable DTSalesRank;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_Employee;
        private Button button1;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmSRIPLService()
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
            this.gridIPLService = new DevExpress.XtraGrid.GridControl();
            this.gvIPLService = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gvIPLServiceRank = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lk_Employee = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvIPLServiceSalesPercentage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvIPLServiceTotalSales = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView6 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label7 = new System.Windows.Forms.Label();
            this.RGIPLService = new DevExpress.XtraEditors.RadioGroup();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Month.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Year.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridIPLService)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvIPLService)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_Employee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGIPLService.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label79
            // 
            this.label79.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label79.Location = new System.Drawing.Point(144, 8);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(48, 23);
            this.label79.TabIndex = 31;
            this.label79.Text = "Year";
            // 
            // label80
            // 
            this.label80.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label80.Location = new System.Drawing.Point(8, 8);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(56, 23);
            this.label80.TabIndex = 30;
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
            this.Month.TabIndex = 29;
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
            this.Year.TabIndex = 28;
            this.Year.SelectedIndexChanged += new System.EventHandler(this.Year_SelectedIndexChanged);
            // 
            // gridIPLService
            // 
            this.gridIPLService.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridIPLService.Location = new System.Drawing.Point(0, 96);
            this.gridIPLService.MainView = this.gvIPLService;
            this.gridIPLService.Name = "gridIPLService";
            this.gridIPLService.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lk_Employee});
            this.gridIPLService.Size = new System.Drawing.Size(960, 384);
            this.gridIPLService.TabIndex = 32;
            this.gridIPLService.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvIPLService,
            this.gridView6});
            // 
            // gvIPLService
            // 
            this.gvIPLService.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gvIPLServiceRank,
            this.gridColumn8,
            this.gridColumn9,
            this.gvIPLServiceSalesPercentage,
            this.gvIPLServiceTotalSales});
            this.gvIPLService.GridControl = this.gridIPLService;
            this.gvIPLService.Name = "gvIPLService";
            this.gvIPLService.OptionsBehavior.Editable = false;
            this.gvIPLService.OptionsCustomization.AllowFilter = false;
            this.gvIPLService.OptionsCustomization.AllowGroup = false;
            this.gvIPLService.OptionsCustomization.AllowSort = false;
            this.gvIPLService.OptionsView.ShowGroupPanel = false;
            this.gvIPLService.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gvIPLService_CustomUnboundColumnData);
            // 
            // gvIPLServiceRank
            // 
            this.gvIPLServiceRank.Caption = "Rank";
            this.gvIPLServiceRank.FieldName = "gridColumn1";
            this.gvIPLServiceRank.Name = "gvIPLServiceRank";
            this.gvIPLServiceRank.SummaryItem.DisplayFormat = "{0}";
            this.gvIPLServiceRank.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.gvIPLServiceRank.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.gvIPLServiceRank.Visible = true;
            this.gvIPLServiceRank.VisibleIndex = 0;
            this.gvIPLServiceRank.Width = 50;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Employee Name";
            this.gridColumn8.ColumnEdit = this.lk_Employee;
            this.gridColumn8.FieldName = "nSalesPersonID";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 1;
            this.gridColumn8.Width = 54;
            // 
            // lk_Employee
            // 
            this.lk_Employee.AutoHeight = false;
            this.lk_Employee.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lk_Employee.Name = "lk_Employee";
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Branch Code";
            this.gridColumn9.FieldName = "strBranchCode";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 4;
            this.gridColumn9.Width = 72;
            // 
            // gvIPLServiceSalesPercentage
            // 
            this.gvIPLServiceSalesPercentage.Caption = "Sales Percentage";
            this.gvIPLServiceSalesPercentage.FieldName = "SalesPercentage";
            this.gvIPLServiceSalesPercentage.Name = "gvIPLServiceSalesPercentage";
            this.gvIPLServiceSalesPercentage.Visible = true;
            this.gvIPLServiceSalesPercentage.VisibleIndex = 2;
            this.gvIPLServiceSalesPercentage.Width = 54;
            // 
            // gvIPLServiceTotalSales
            // 
            this.gvIPLServiceTotalSales.Caption = "Total Sales";
            this.gvIPLServiceTotalSales.FieldName = "TotalSales";
            this.gvIPLServiceTotalSales.Name = "gvIPLServiceTotalSales";
            this.gvIPLServiceTotalSales.Visible = true;
            this.gvIPLServiceTotalSales.VisibleIndex = 3;
            this.gvIPLServiceTotalSales.Width = 54;
            // 
            // gridView6
            // 
            this.gridView6.GridControl = this.gridIPLService;
            this.gridView6.Name = "gridView6";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(0, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(936, 24);
            this.label7.TabIndex = 34;
            this.label7.Text = "Ranking of IPL Service Sales";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RGIPLService
            // 
            this.RGIPLService.EditValue = 0;
            this.RGIPLService.Location = new System.Drawing.Point(0, 64);
            this.RGIPLService.Name = "RGIPLService";
            this.RGIPLService.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.RGIPLService.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RGIPLService.Properties.Appearance.Options.UseBackColor = true;
            this.RGIPLService.Properties.Appearance.Options.UseFont = true;
            this.RGIPLService.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.RGIPLService.Properties.Columns = 2;
            this.RGIPLService.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "IPL Sales By %"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Actual IPL Sales")});
            this.RGIPLService.Size = new System.Drawing.Size(496, 32);
            this.RGIPLService.TabIndex = 33;
            this.RGIPLService.SelectedIndexChanged += new System.EventHandler(this.RGIPLService_SelectedIndexChanged);
            this.RGIPLService.Click += new System.EventHandler(this.RGIPLService_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(468, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 35;
            this.button1.Text = "Print";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmSRIPLService
            // 
            this.ClientSize = new System.Drawing.Size(960, 480);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gridIPLService);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.RGIPLService);
            this.Controls.Add(this.label79);
            this.Controls.Add(this.label80);
            this.Controls.Add(this.Month);
            this.Controls.Add(this.Year);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSRIPLService";
            this.Text = "frmSRIPLService";
            this.Load += new System.EventHandler(this.frmSRIPLService_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Month.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Year.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridIPLService)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvIPLService)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_Employee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGIPLService.Properties)).EndInit();
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
					_ds = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "UP_ComSalesRankIPLService", 
						new SqlParameter("@Month",Convert.ToInt32(Month.EditValue)),
						new SqlParameter("@Year",Convert.ToInt32(Year.EditValue))
						);
					DTSalesRank = _ds.Tables["table"];
					gridIPLService.DataSource = DTSalesRank;

					RGIPLService_SelectedIndexChanged(this,e);
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

		private void RGIPLService_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			i = 1;
			if (RGIPLService.SelectedIndex == 0)
			{
				this.gvIPLService.Columns.ColumnByName("gvIPLServiceTotalSales").SortOrder =  DevExpress.Data.ColumnSortOrder.None;
				gvIPLService.Columns.ColumnByName("gvIPLServiceSalesPercentage").SortOrder =  DevExpress.Data.ColumnSortOrder.Descending;
			}
			else
			{
				gvIPLService.Columns.ColumnByName("gvIPLServiceSalesPercentage").SortOrder =  DevExpress.Data.ColumnSortOrder.None;
				this.gvIPLService.Columns.ColumnByName("gvIPLServiceTotalSales").SortOrder =  DevExpress.Data.ColumnSortOrder.Descending;
			}
		}

		private void gvIPLService_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
		{
			this.SuspendLayout();
			i = e.RowHandle+1;
			if (e.Column.Name == "gvIPLServiceRank" && i<=gvIPLService.RowCount)
			{
				e.Value = i;
				i = i + 1;
			}

			if (i>gvIPLService.RowCount)
			{
				i = 1;
			}
			this.ResumeLayout();
		}

		private void frmSRIPLService_Load(object sender, System.EventArgs e)
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

		private void RGIPLService_Click(object sender, System.EventArgs e)
		{
			i = 1;
		}

        private void button1_Click(object sender, EventArgs e)
        {
            gridIPLService.Print();
        }
	
	}
}
