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
	/// Summary description for RPComSalesRanking.
	/// </summary>
	public class RPComSalesRanking : System.Windows.Forms.Form
	{
		private string connectionString;
		private SqlConnection connection;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
		private DevExpress.XtraGrid.GridControl gridFitnessPackage;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
		private DevExpress.XtraGrid.Columns.GridColumn Rank;
		private DevExpress.XtraEditors.RadioGroup RGFitnessPackage;
		private DevExpress.XtraGrid.Columns.GridColumn SalesPercentage;
		private DevExpress.XtraGrid.Columns.GridColumn SalesTotal;
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private DevExpress.XtraEditors.RadioGroup RGFitnessProduct;
		private DevExpress.XtraGrid.GridControl gridFitnessProduct;
		private DevExpress.XtraGrid.Views.Grid.GridView gvFitnessProduct;
		private DevExpress.XtraGrid.Columns.GridColumn gvFitnessProductRank;
		private DevExpress.XtraGrid.Columns.GridColumn gvFitnessProductSalesPercentage;
		private DevExpress.XtraGrid.Columns.GridColumn gvFitnessProductTotalSales;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private DevExpress.XtraEditors.RadioGroup RGSpaProduct;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView5;
		private System.Windows.Forms.Label label6;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView7;
		private DevExpress.XtraGrid.GridControl gridSpaProduct;
		private DevExpress.XtraGrid.Views.Grid.GridView gvSpaProduct;
		private DevExpress.XtraGrid.Columns.GridColumn gvSpaProductRank;
		private DevExpress.XtraGrid.Columns.GridColumn gvSpaProductSalesPercentage;
		private DevExpress.XtraGrid.Columns.GridColumn gvSpaProductTotalSales;
		private DevExpress.XtraGrid.GridControl gridPTPackage;
		private DevExpress.XtraGrid.Views.Grid.GridView gvPTPackage;
		private DevExpress.XtraGrid.Columns.GridColumn gvPTPackageRank;
		private DevExpress.XtraGrid.Columns.GridColumn gvPTPackageSalesPercentage;
		private DevExpress.XtraGrid.Columns.GridColumn gvPTPackageTotalSales;
		private DevExpress.XtraEditors.RadioGroup RGPTPackage;
		private System.Windows.Forms.Label label7;
		private DevExpress.XtraEditors.RadioGroup RGIPLService;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView6;
		private System.Windows.Forms.Label label8;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView9;
		private DevExpress.XtraEditors.RadioGroup RGSpaService;
		private DevExpress.XtraGrid.GridControl gridSpaService;
		private DevExpress.XtraGrid.Views.Grid.GridView gvSpaService;
		private DevExpress.XtraGrid.Views.Grid.GridView gvIPLService;
		private DevExpress.XtraGrid.Columns.GridColumn gvSpaServiceRank;
		private DevExpress.XtraGrid.Columns.GridColumn gvSpaServiceSalesPercentage;
		private DevExpress.XtraGrid.Columns.GridColumn gvSpaServiceTotalSales;
		private DevExpress.XtraGrid.GridControl gridIPLService;
		private DevExpress.XtraGrid.Columns.GridColumn gvIPLServiceRank;
		private DevExpress.XtraGrid.Columns.GridColumn gvIPLServiceSalesPercentage;
		private DevExpress.XtraGrid.Columns.GridColumn gvIPLServiceTotalSales;
		private DevExpress.XtraEditors.ComboBoxEdit Month;
		private DevExpress.XtraEditors.ComboBoxEdit Year;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public RPComSalesRanking()
		{
			//
			// Required for Windows Form Designer support
			//
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

		private void BindReport()
		{
			string strSQL;
			DataSet _ds;


			//Fitness Package
			strSQL = "UP_ComSalesRankFitnessPack";
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL));
			
			DataTable dt = _ds.Tables["table"];
			DataView dv = new DataView(dt);
			
			dv.RowFilter = string.Format("dtDate >= #{0}/01/{1}# And dtDate < #{2}/01/{1}#", Month.EditValue, Year.EditValue, Convert.ToInt32(Month.EditValue) + 1);

			this.gridFitnessPackage.DataSource = dv;

			//Fitness Product 
			strSQL = "UP_ComSalesRankFitnessProduct";
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dt = _ds.Tables["table"];
			dv = new DataView(dt);
			
			dv.RowFilter = string.Format("dtDate >= #{0}/01/{1}# And dtDate < #{2}/01/{1}#", Month.EditValue, Year.EditValue, Convert.ToInt32(Month.EditValue) + 1);
			i = 1;
			this.gridFitnessProduct.DataSource = dv;

			//Spa Product 
			strSQL = "UP_ComSalesRankSpaProduct";
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dt = _ds.Tables["table"];
			dv = new DataView(dt);
			
			dv.RowFilter = string.Format("dtDate >= #{0}/01/{1}# And dtDate < #{2}/01/{1}#", Month.EditValue, Year.EditValue, Convert.ToInt32(Month.EditValue) + 1);
			i = 1;
			this.gridSpaProduct.DataSource = dv;

			
			//PT Package
			strSQL = "UP_ComSalesRankPTPackage";
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dt = _ds.Tables["table"];
			dv = new DataView(dt);
			
			dv.RowFilter = string.Format("dtDate >= #{0}/01/{1}# And dtDate < #{2}/01/{1}#", Month.EditValue, Year.EditValue, Convert.ToInt32(Month.EditValue) + 1);
			i = 1;
			this.gridPTPackage.DataSource = dv;

			//Spa Product 
			strSQL = "UP_ComSalesRankSpaPackage";
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dt = _ds.Tables["table"];
			dv = new DataView(dt);
			
			dv.RowFilter = string.Format("dtDate >= #{0}/01/{1}# And dtDate < #{2}/01/{1}#", Month.EditValue, Year.EditValue, Convert.ToInt32(Month.EditValue) + 1);
			i = 1;
			this.gridSpaService.DataSource = dv;
			
			//ILP Package
			strSQL = "UP_ComSalesRankIPLService";
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dt = _ds.Tables["table"];
			dv = new DataView(dt);
			
			dv.RowFilter = string.Format("dtDate >= #{0}/01/{1}# And dtDate < #{2}/01/{1}#", Month.EditValue, Year.EditValue, Convert.ToInt32(Month.EditValue) + 1);
			i = 1;
			this.gridIPLService.DataSource = dv;
			
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.gridFitnessPackage = new DevExpress.XtraGrid.GridControl();
			this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.Rank = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.SalesPercentage = new DevExpress.XtraGrid.Columns.GridColumn();
			this.SalesTotal = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.RGFitnessPackage = new DevExpress.XtraEditors.RadioGroup();
			this.label1 = new System.Windows.Forms.Label();
			this.Year = new DevExpress.XtraEditors.ComboBoxEdit();
			this.Month = new DevExpress.XtraEditors.ComboBoxEdit();
			this.RGFitnessProduct = new DevExpress.XtraEditors.RadioGroup();
			this.gridFitnessProduct = new DevExpress.XtraGrid.GridControl();
			this.gvFitnessProduct = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gvFitnessProductRank = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvFitnessProductSalesPercentage = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvFitnessProductTotalSales = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.RGSpaProduct = new DevExpress.XtraEditors.RadioGroup();
			this.gridSpaProduct = new DevExpress.XtraGrid.GridControl();
			this.gvSpaProduct = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gvSpaProductRank = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvSpaProductSalesPercentage = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvSpaProductTotalSales = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.label6 = new System.Windows.Forms.Label();
			this.RGPTPackage = new DevExpress.XtraEditors.RadioGroup();
			this.gridPTPackage = new DevExpress.XtraGrid.GridControl();
			this.gvPTPackage = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gvPTPackageRank = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvPTPackageSalesPercentage = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvPTPackageTotalSales = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridView7 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.label7 = new System.Windows.Forms.Label();
			this.RGIPLService = new DevExpress.XtraEditors.RadioGroup();
			this.gridIPLService = new DevExpress.XtraGrid.GridControl();
			this.gvIPLService = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gvIPLServiceRank = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvIPLServiceSalesPercentage = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvIPLServiceTotalSales = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridView6 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.label8 = new System.Windows.Forms.Label();
			this.RGSpaService = new DevExpress.XtraEditors.RadioGroup();
			this.gridSpaService = new DevExpress.XtraGrid.GridControl();
			this.gvSpaService = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gvSpaServiceRank = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvSpaServiceSalesPercentage = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvSpaServiceTotalSales = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridView9 = new DevExpress.XtraGrid.Views.Grid.GridView();
			((System.ComponentModel.ISupportInitialize)(this.gridFitnessPackage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.RGFitnessPackage.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Year.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Month.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.RGFitnessProduct.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridFitnessProduct)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvFitnessProduct)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.RGSpaProduct.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridSpaProduct)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvSpaProduct)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.RGPTPackage.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridPTPackage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvPTPackage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView7)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.RGIPLService.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridIPLService)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvIPLService)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView6)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.RGSpaService.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridSpaService)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvSpaService)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView9)).BeginInit();
			this.SuspendLayout();
			// 
			// gridFitnessPackage
			// 
			// 
			// gridFitnessPackage.EmbeddedNavigator
			// 
			this.gridFitnessPackage.EmbeddedNavigator.Name = "";
			this.gridFitnessPackage.Location = new System.Drawing.Point(8, 96);
			this.gridFitnessPackage.MainView = this.gridView2;
			this.gridFitnessPackage.Name = "gridFitnessPackage";
			this.gridFitnessPackage.Size = new System.Drawing.Size(305, 200);
			this.gridFitnessPackage.TabIndex = 0;
			this.gridFitnessPackage.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																											  this.gridView2,
																											  this.gridView1});
			// 
			// gridView2
			// 
			this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.Rank,
																							 this.gridColumn2,
																							 this.gridColumn5,
																							 this.SalesPercentage,
																							 this.SalesTotal});
			this.gridView2.GridControl = this.gridFitnessPackage;
			this.gridView2.Name = "gridView2";
			this.gridView2.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridView2_CustomUnboundColumnData);
			// 
			// Rank
			// 
			this.Rank.Caption = "Rank";
			this.Rank.FieldName = "gridColumn1";
			this.Rank.Name = "Rank";
			this.Rank.SummaryItem.DisplayFormat = "{0}";
			this.Rank.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
			this.Rank.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
			this.Rank.Visible = true;
			this.Rank.VisibleIndex = 0;
			this.Rank.Width = 50;
			// 
			// gridColumn2
			// 
			this.gridColumn2.Caption = "Employee Name";
			this.gridColumn2.FieldName = "strEmployeeName";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 1;
			this.gridColumn2.Width = 54;
			// 
			// gridColumn5
			// 
			this.gridColumn5.Caption = "Branch Code";
			this.gridColumn5.FieldName = "strBranchCode";
			this.gridColumn5.Name = "gridColumn5";
			this.gridColumn5.Visible = true;
			this.gridColumn5.VisibleIndex = 4;
			this.gridColumn5.Width = 72;
			// 
			// SalesPercentage
			// 
			this.SalesPercentage.Caption = "Sales Percentage";
			this.SalesPercentage.FieldName = "SalesPercentage";
			this.SalesPercentage.Name = "SalesPercentage";
			this.SalesPercentage.Visible = true;
			this.SalesPercentage.VisibleIndex = 2;
			this.SalesPercentage.Width = 54;
			// 
			// SalesTotal
			// 
			this.SalesTotal.Caption = "Total Sales";
			this.SalesTotal.FieldName = "TotalSales";
			this.SalesTotal.Name = "SalesTotal";
			this.SalesTotal.Visible = true;
			this.SalesTotal.VisibleIndex = 3;
			this.SalesTotal.Width = 54;
			// 
			// gridView1
			// 
			this.gridView1.GridControl = this.gridFitnessPackage;
			this.gridView1.Name = "gridView1";
			// 
			// RGFitnessPackage
			// 
			this.RGFitnessPackage.EditValue = 0;
			this.RGFitnessPackage.Location = new System.Drawing.Point(8, 64);
			this.RGFitnessPackage.Name = "RGFitnessPackage";
			// 
			// RGFitnessPackage.Properties
			// 
			this.RGFitnessPackage.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.RGFitnessPackage.Properties.Appearance.Options.UseBackColor = true;
			this.RGFitnessPackage.Properties.Columns = 2;
			this.RGFitnessPackage.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
																													 new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Fitness Package Sales By %"),
																													 new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Actual Fitness Package Sales")});
			this.RGFitnessPackage.Size = new System.Drawing.Size(305, 24);
			this.RGFitnessPackage.TabIndex = 1;
			this.RGFitnessPackage.SelectedIndexChanged += new System.EventHandler(this.RGFitnessPackage_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(8, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(304, 24);
			this.label1.TabIndex = 2;
			this.label1.Text = "Ranking of Fitness Package Sales";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
			this.Year.TabIndex = 3;
			this.Year.SelectedIndexChanged += new System.EventHandler(this.Year_SelectedIndexChanged);
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
			this.Month.Size = new System.Drawing.Size(74, 20);
			this.Month.TabIndex = 4;
			this.Month.SelectedIndexChanged += new System.EventHandler(this.Month_SelectedIndexChanged);
			// 
			// RGFitnessProduct
			// 
			this.RGFitnessProduct.EditValue = 0;
			this.RGFitnessProduct.Location = new System.Drawing.Point(320, 64);
			this.RGFitnessProduct.Name = "RGFitnessProduct";
			// 
			// RGFitnessProduct.Properties
			// 
			this.RGFitnessProduct.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.RGFitnessProduct.Properties.Appearance.Options.UseBackColor = true;
			this.RGFitnessProduct.Properties.Columns = 2;
			this.RGFitnessProduct.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
																													 new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Fitness Package Sales By %"),
																													 new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Actual Fitness Package Sales")});
			this.RGFitnessProduct.Size = new System.Drawing.Size(305, 24);
			this.RGFitnessProduct.TabIndex = 6;
			this.RGFitnessProduct.SelectedIndexChanged += new System.EventHandler(this.RGFitnessProduct_SelectedIndexChanged);
			// 
			// gridFitnessProduct
			// 
			// 
			// gridFitnessProduct.EmbeddedNavigator
			// 
			this.gridFitnessProduct.EmbeddedNavigator.Name = "";
			this.gridFitnessProduct.Location = new System.Drawing.Point(320, 96);
			this.gridFitnessProduct.MainView = this.gvFitnessProduct;
			this.gridFitnessProduct.Name = "gridFitnessProduct";
			this.gridFitnessProduct.Size = new System.Drawing.Size(305, 200);
			this.gridFitnessProduct.TabIndex = 5;
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
			this.gvFitnessProduct.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.RPComSalesRanking_CustomUnboundColumnData);
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
			this.gvFitnessProductRank.Width = 50;
			// 
			// gridColumn3
			// 
			this.gridColumn3.Caption = "Employee Name";
			this.gridColumn3.FieldName = "strEmployeeName";
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 1;
			this.gridColumn3.Width = 54;
			// 
			// gridColumn4
			// 
			this.gridColumn4.Caption = "Branch Code";
			this.gridColumn4.FieldName = "strBranchCode";
			this.gridColumn4.Name = "gridColumn4";
			this.gridColumn4.Visible = true;
			this.gridColumn4.VisibleIndex = 4;
			this.gridColumn4.Width = 72;
			// 
			// gvFitnessProductSalesPercentage
			// 
			this.gvFitnessProductSalesPercentage.Caption = "Sales Percentage";
			this.gvFitnessProductSalesPercentage.FieldName = "SalesPercentage";
			this.gvFitnessProductSalesPercentage.Name = "gvFitnessProductSalesPercentage";
			this.gvFitnessProductSalesPercentage.Visible = true;
			this.gvFitnessProductSalesPercentage.VisibleIndex = 2;
			this.gvFitnessProductSalesPercentage.Width = 54;
			// 
			// gvFitnessProductTotalSales
			// 
			this.gvFitnessProductTotalSales.Caption = "Total Sales";
			this.gvFitnessProductTotalSales.FieldName = "TotalSales";
			this.gvFitnessProductTotalSales.Name = "gvFitnessProductTotalSales";
			this.gvFitnessProductTotalSales.Visible = true;
			this.gvFitnessProductTotalSales.VisibleIndex = 3;
			this.gvFitnessProductTotalSales.Width = 54;
			// 
			// gridView4
			// 
			this.gridView4.GridControl = this.gridFitnessProduct;
			this.gridView4.Name = "gridView4";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.Location = new System.Drawing.Point(8, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 23);
			this.label2.TabIndex = 7;
			this.label2.Text = "Month";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label3.Location = new System.Drawing.Point(144, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 23);
			this.label3.TabIndex = 8;
			this.label3.Text = "Year";
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label4.Location = new System.Drawing.Point(320, 40);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(304, 24);
			this.label4.TabIndex = 9;
			this.label4.Text = "Ranking of Fitness Product Sales";
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label5.Location = new System.Drawing.Point(8, 312);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(304, 24);
			this.label5.TabIndex = 12;
			this.label5.Text = "Ranking of Spa Product Sales";
			// 
			// RGSpaProduct
			// 
			this.RGSpaProduct.EditValue = 0;
			this.RGSpaProduct.Location = new System.Drawing.Point(8, 336);
			this.RGSpaProduct.Name = "RGSpaProduct";
			// 
			// RGSpaProduct.Properties
			// 
			this.RGSpaProduct.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.RGSpaProduct.Properties.Appearance.Options.UseBackColor = true;
			this.RGSpaProduct.Properties.Columns = 2;
			this.RGSpaProduct.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
																												 new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Fitness Package Sales By %"),
																												 new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Actual Fitness Package Sales")});
			this.RGSpaProduct.Size = new System.Drawing.Size(305, 24);
			this.RGSpaProduct.TabIndex = 11;
			this.RGSpaProduct.SelectedIndexChanged += new System.EventHandler(this.RGSpaProduct_SelectedIndexChanged);
			// 
			// gridSpaProduct
			// 
			// 
			// gridSpaProduct.EmbeddedNavigator
			// 
			this.gridSpaProduct.EmbeddedNavigator.Name = "";
			this.gridSpaProduct.Location = new System.Drawing.Point(8, 368);
			this.gridSpaProduct.MainView = this.gvSpaProduct;
			this.gridSpaProduct.Name = "gridSpaProduct";
			this.gridSpaProduct.Size = new System.Drawing.Size(305, 200);
			this.gridSpaProduct.TabIndex = 10;
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
			this.gridColumn6.FieldName = "strEmployeeName";
			this.gridColumn6.Name = "gridColumn6";
			this.gridColumn6.Visible = true;
			this.gridColumn6.VisibleIndex = 1;
			this.gridColumn6.Width = 54;
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
			// label6
			// 
			this.label6.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label6.Location = new System.Drawing.Point(320, 312);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(304, 24);
			this.label6.TabIndex = 15;
			this.label6.Text = "Ranking of Personal Trainer Sales";
			// 
			// RGPTPackage
			// 
			this.RGPTPackage.EditValue = 0;
			this.RGPTPackage.Location = new System.Drawing.Point(320, 336);
			this.RGPTPackage.Name = "RGPTPackage";
			// 
			// RGPTPackage.Properties
			// 
			this.RGPTPackage.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.RGPTPackage.Properties.Appearance.Options.UseBackColor = true;
			this.RGPTPackage.Properties.Columns = 2;
			this.RGPTPackage.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
																												new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Fitness Package Sales By %"),
																												new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Actual Fitness Package Sales")});
			this.RGPTPackage.Size = new System.Drawing.Size(305, 24);
			this.RGPTPackage.TabIndex = 14;
			this.RGPTPackage.SelectedIndexChanged += new System.EventHandler(this.RGPTPackage_SelectedIndexChanged);
			// 
			// gridPTPackage
			// 
			// 
			// gridPTPackage.EmbeddedNavigator
			// 
			this.gridPTPackage.EmbeddedNavigator.Name = "";
			this.gridPTPackage.Location = new System.Drawing.Point(320, 368);
			this.gridPTPackage.MainView = this.gvPTPackage;
			this.gridPTPackage.Name = "gridPTPackage";
			this.gridPTPackage.Size = new System.Drawing.Size(305, 200);
			this.gridPTPackage.TabIndex = 13;
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
			this.gvPTPackage.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gvPTPackage_CustomUnboundColumnData);
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
			this.gridColumn11.FieldName = "strEmployeeName";
			this.gridColumn11.Name = "gridColumn11";
			this.gridColumn11.Visible = true;
			this.gridColumn11.VisibleIndex = 1;
			this.gridColumn11.Width = 54;
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
			// label7
			// 
			this.label7.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label7.Location = new System.Drawing.Point(320, 576);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(304, 24);
			this.label7.TabIndex = 21;
			this.label7.Text = "Ranking of Cross Selling Sales";
			// 
			// RGIPLService
			// 
			this.RGIPLService.EditValue = 0;
			this.RGIPLService.Location = new System.Drawing.Point(320, 600);
			this.RGIPLService.Name = "RGIPLService";
			// 
			// RGIPLService.Properties
			// 
			this.RGIPLService.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.RGIPLService.Properties.Appearance.Options.UseBackColor = true;
			this.RGIPLService.Properties.Columns = 2;
			this.RGIPLService.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
																												 new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Fitness Package Sales By %"),
																												 new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Actual Fitness Package Sales")});
			this.RGIPLService.Size = new System.Drawing.Size(305, 24);
			this.RGIPLService.TabIndex = 20;
			this.RGIPLService.SelectedIndexChanged += new System.EventHandler(this.RGIPLService_SelectedIndexChanged);
			// 
			// gridIPLService
			// 
			// 
			// gridIPLService.EmbeddedNavigator
			// 
			this.gridIPLService.EmbeddedNavigator.Name = "";
			this.gridIPLService.Location = new System.Drawing.Point(320, 632);
			this.gridIPLService.MainView = this.gvIPLService;
			this.gridIPLService.Name = "gridIPLService";
			this.gridIPLService.Size = new System.Drawing.Size(305, 200);
			this.gridIPLService.TabIndex = 19;
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
			this.gridColumn8.FieldName = "strEmployeeName";
			this.gridColumn8.Name = "gridColumn8";
			this.gridColumn8.Visible = true;
			this.gridColumn8.VisibleIndex = 1;
			this.gridColumn8.Width = 54;
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
			// label8
			// 
			this.label8.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label8.Location = new System.Drawing.Point(8, 576);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(304, 24);
			this.label8.TabIndex = 18;
			this.label8.Text = "Ranking of Spa Service Sales";
			// 
			// RGSpaService
			// 
			this.RGSpaService.EditValue = 0;
			this.RGSpaService.Location = new System.Drawing.Point(8, 600);
			this.RGSpaService.Name = "RGSpaService";
			// 
			// RGSpaService.Properties
			// 
			this.RGSpaService.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.RGSpaService.Properties.Appearance.Options.UseBackColor = true;
			this.RGSpaService.Properties.Columns = 2;
			this.RGSpaService.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
																												 new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Fitness Package Sales By %"),
																												 new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Actual Fitness Package Sales")});
			this.RGSpaService.Size = new System.Drawing.Size(305, 24);
			this.RGSpaService.TabIndex = 17;
			this.RGSpaService.SelectedIndexChanged += new System.EventHandler(this.RGSpaService_SelectedIndexChanged);
			// 
			// gridSpaService
			// 
			// 
			// gridSpaService.EmbeddedNavigator
			// 
			this.gridSpaService.EmbeddedNavigator.Name = "";
			this.gridSpaService.Location = new System.Drawing.Point(8, 632);
			this.gridSpaService.MainView = this.gvSpaService;
			this.gridSpaService.Name = "gridSpaService";
			this.gridSpaService.Size = new System.Drawing.Size(305, 200);
			this.gridSpaService.TabIndex = 16;
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
			this.gvSpaService.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gvSpaService_CustomUnboundColumnData);
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
			this.gridColumn15.FieldName = "strEmployeeName";
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
			// RPComSalesRanking
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(607, 436);
			this.Controls.Add(this.gridFitnessProduct);
			this.Controls.Add(this.gridSpaProduct);
			this.Controls.Add(this.gridPTPackage);
			this.Controls.Add(this.gridIPLService);
			this.Controls.Add(this.gridSpaService);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.RGIPLService);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.RGSpaService);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.RGPTPackage);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.RGSpaProduct);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.RGFitnessProduct);
			this.Controls.Add(this.Month);
			this.Controls.Add(this.Year);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.RGFitnessPackage);
			this.Controls.Add(this.gridFitnessPackage);
			this.DockPadding.Bottom = 30;
			this.MinimizeBox = false;
			this.Name = "RPComSalesRanking";
			this.Text = "RPComSalesRanking";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.RPComSalesRanking_Load);
			((System.ComponentModel.ISupportInitialize)(this.gridFitnessPackage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.RGFitnessPackage.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Year.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Month.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.RGFitnessProduct.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridFitnessProduct)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvFitnessProduct)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.RGSpaProduct.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridSpaProduct)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvSpaProduct)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.RGPTPackage.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridPTPackage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvPTPackage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView7)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.RGIPLService.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridIPLService)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvIPLService)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView6)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.RGSpaService.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridSpaService)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvSpaService)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView9)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private int i = 1;

		private void RPComSalesRanking_Load(object sender, System.EventArgs e)
		{
			BindCalendar();
			BindReport();
			i = 1;
		}

		private void BindCalendar()
		{
			Year.Properties.Items.Insert(0,new DevExpress.XtraEditors.Controls.ImageComboBoxItem(DateTime.Now.Year - 1,DateTime.Now.Year - 1));
			Year.Properties.Items.Insert(0,new DevExpress.XtraEditors.Controls.ImageComboBoxItem(DateTime.Now.Year,DateTime.Now.Year));

            Year.SelectedIndex = 0;
		}

		private void gridView2_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
		{
			if (e.Column.Name == "Rank")
			{
				e.Value = i;
				i = i + 1;
			}
		}
		
		private void RPComSalesRanking_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
		{
			if (e.Column.Name == "gvFitnessProductRank")
			{
				e.Value = i;
				i = i + 1;
			}
		}

		private void gvSpaProduct_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
		{
		
			if (e.Column.Name == "gvSpaProductRank")
			{
				e.Value = i;
				i = i + 1;
			}

		}

		
		private void gvPTPackage_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
		{
			if (e.Column.Name == "gvPTPackageRank")
			{
				e.Value = i;
				i = i + 1;
			}

		}

		private void gvSpaService_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
		{
			if (e.Column.Name == "gvSpaServiceRank")
			{
				e.Value = i;
				i = i + 1;
			}
		}

		private void gvIPLService_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
		{
			if (e.Column.Name == "gvIPLServiceRank")
			{
				e.Value = i;
				i = i + 1;
			}
		}
	
		private void RGFitnessPackage_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (RGFitnessPackage.SelectedIndex == 0)
			{
				gridView2.Columns.ColumnByName("SalesPercentage").SortOrder =  DevExpress.Data.ColumnSortOrder.Ascending;
			}
			else
			{
				gridView2.Columns.ColumnByName("SalesTotal").SortOrder =  DevExpress.Data.ColumnSortOrder.Ascending;
				
			}
		}

		private void RGFitnessProduct_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (RGFitnessProduct.SelectedIndex == 0)
			{
				gvFitnessProduct.Columns.ColumnByName("gvFitnessProductSalesPercentage").SortOrder =  DevExpress.Data.ColumnSortOrder.Ascending;
			}
			else
			{
				gvFitnessProduct.Columns.ColumnByName("gvFitnessProductTotalSales").SortOrder =  DevExpress.Data.ColumnSortOrder.Ascending;
				
			}
		}

		private void RGSpaProduct_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
			if (RGFitnessProduct.SelectedIndex == 0)
			{
				gvSpaProduct.Columns.ColumnByName("gvSpaProductSalesPercentage").SortOrder =  DevExpress.Data.ColumnSortOrder.Ascending;
			}
			else
			{
				gvSpaProduct.Columns.ColumnByName("gvSpaProductTotalSales").SortOrder =  DevExpress.Data.ColumnSortOrder.Ascending;
				
			}

		}

		private void RGPTPackage_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (RGPTPackage.SelectedIndex == 0)
			{
				gvPTPackage.Columns.ColumnByName("gvPTPackageSalesPercentage").SortOrder =  DevExpress.Data.ColumnSortOrder.Ascending;
			}
			else
			{
				gvPTPackage.Columns.ColumnByName("gvPTPackageTotalSales").SortOrder =  DevExpress.Data.ColumnSortOrder.Ascending;
				
			}

		}
		
		private void RGIPLService_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (RGIPLService.SelectedIndex == 0)
			{
				gvIPLService.Columns.ColumnByName("gvIPLServiceSalesPercentage").SortOrder =  DevExpress.Data.ColumnSortOrder.Ascending;
			}
			else
			{
				this.gvIPLService.Columns.ColumnByName("gvIPLServiceTotalSales").SortOrder =  DevExpress.Data.ColumnSortOrder.Ascending;
			}
		}

		private void RGSpaService_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (RGSpaService.SelectedIndex == 0)
			{
				gvSpaService.Columns.ColumnByName("gvSpaServiceSalesPercentage").SortOrder =  DevExpress.Data.ColumnSortOrder.Ascending;
			}
			else
			{
				gvSpaService.Columns.ColumnByName("gvSpaServiceTotalSales").SortOrder =  DevExpress.Data.ColumnSortOrder.Ascending;
			}
		}

		private void Month_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			BindReport();
		}

		private void Year_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			BindReport();
		}


	



	

	

		

	
	}
}
