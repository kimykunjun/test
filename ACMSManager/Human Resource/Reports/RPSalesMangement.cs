using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Microsoft.ApplicationBlocks.Data;
using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;

namespace ACMS.ACMSManager.Reports
{

	/// <summary>
	/// Summary description for RPSalesMangement.
	/// </summary>
	public class RPSalesMangement : DevExpress.XtraEditors.XtraForm
	{
		private string connectionString;
		private SqlConnection connection;
		private DevExpress.XtraGrid.GridControl gridMaster;
		private DevExpress.XtraGrid.Views.Grid.GridView gridMasterView;
		private DevExpress.XtraGrid.GridControl gridChild;
		private DevExpress.XtraGrid.Views.Grid.GridView gridChildView;
		private DevExpress.XtraGrid.Columns.GridColumn dtDate;
		private DevExpress.XtraGrid.Columns.GridColumn nCategory;
		private DevExpress.XtraEditors.DateEdit dtClickDate;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
			lk_Category;
		private System.Windows.Forms.Label label1;
		private string BranchParam1="";
		private string BranchParam2="";
		private string BranchParam3="";
		private System.Windows.Forms.GroupBox groupBox1;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public RPSalesMangement()
		{
			//
			// Required for Windows Form Designer support
			//
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
			DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
			this.gridMaster = new DevExpress.XtraGrid.GridControl();
			this.gridMasterView = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.nCategory = new DevExpress.XtraGrid.Columns.GridColumn();
			this.lk_Category = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			this.dtClickDate = new DevExpress.XtraEditors.DateEdit();
			this.gridChild = new DevExpress.XtraGrid.GridControl();
			this.gridChildView = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.dtDate = new DevExpress.XtraGrid.Columns.GridColumn();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			((System.ComponentModel.ISupportInitialize)(this.gridMaster)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridMasterView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_Category)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtClickDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridChild)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridChildView)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// gridMaster
			// 
			// 
			// gridMaster.EmbeddedNavigator
			// 
			this.gridMaster.EmbeddedNavigator.Name = "";
			gridLevelNode1.RelationName = "Level1";
			this.gridMaster.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
																								 gridLevelNode1});
			this.gridMaster.Location = new System.Drawing.Point(0, 32);
			this.gridMaster.MainView = this.gridMasterView;
			this.gridMaster.Name = "gridMaster";
			this.gridMaster.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																												this.lk_Category});
			this.gridMaster.Size = new System.Drawing.Size(840, 224);
			this.gridMaster.TabIndex = 0;
			this.gridMaster.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																									  this.gridMasterView});
			// 
			// gridMasterView
			// 
			this.gridMasterView.ActiveFilterEnabled = false;
			this.gridMasterView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
			this.gridMasterView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																								  this.nCategory});
			this.gridMasterView.GridControl = this.gridMaster;
			this.gridMasterView.Name = "gridMasterView";
			this.gridMasterView.OptionsBehavior.Editable = false;
			this.gridMasterView.OptionsCustomization.AllowFilter = false;
			this.gridMasterView.OptionsCustomization.AllowSort = false;
			this.gridMasterView.OptionsView.ShowFilterPanel = false;
			this.gridMasterView.OptionsView.ShowGroupPanel = false;
			this.gridMasterView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.View_Childlist);
			// 
			// nCategory
			// 
			this.nCategory.Caption = "Category";
			this.nCategory.FieldName = "strReportGroup";
			this.nCategory.Name = "nCategory";
			this.nCategory.Visible = true;
			this.nCategory.VisibleIndex = 0;
			// 
			// lk_Category
			// 
			this.lk_Category.AutoHeight = false;
			this.lk_Category.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																									 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lk_Category.Name = "lk_Category";
			// 
			// dtClickDate
			// 
			this.dtClickDate.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.dtClickDate.EditValue = null;
			this.dtClickDate.Location = new System.Drawing.Point(60, 11);
			this.dtClickDate.Name = "dtClickDate";
			// 
			// dtClickDate.Properties
			// 
			this.dtClickDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
			this.dtClickDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dtClickDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.dtClickDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.dtClickDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
			this.dtClickDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.dtClickDate.Properties.Mask.EditMask = "dd/MM/yyyy";
			this.dtClickDate.Size = new System.Drawing.Size(108, 22);
			this.dtClickDate.TabIndex = 1;
			this.dtClickDate.EditValueChanged += new System.EventHandler(this.dtClickDate_EditValueChanged);
			// 
			// gridChild
			// 
			this.gridChild.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			// 
			// gridChild.EmbeddedNavigator
			// 
			this.gridChild.EmbeddedNavigator.Name = "";
			this.gridChild.Location = new System.Drawing.Point(0, 272);
			this.gridChild.MainView = this.gridChildView;
			this.gridChild.Name = "gridChild";
			this.gridChild.Size = new System.Drawing.Size(840, 264);
			this.gridChild.TabIndex = 2;
			this.gridChild.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																									 this.gridChildView});
			// 
			// gridChildView
			// 
			this.gridChildView.ActiveFilterEnabled = false;
			this.gridChildView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
			this.gridChildView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																								 this.dtDate});
			this.gridChildView.GridControl = this.gridChild;
			this.gridChildView.Name = "gridChildView";
			this.gridChildView.OptionsBehavior.Editable = false;
			this.gridChildView.OptionsCustomization.AllowFilter = false;
			this.gridChildView.OptionsCustomization.AllowSort = false;
			this.gridChildView.OptionsView.ShowFilterPanel = false;
			this.gridChildView.OptionsView.ShowGroupPanel = false;
			// 
			// dtDate
			// 
			this.dtDate.Caption = "Date";
			this.dtDate.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.dtDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.dtDate.FieldName = "dtDate";
			this.dtDate.Name = "dtDate";
			this.dtDate.Visible = true;
			this.dtDate.VisibleIndex = 0;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 22);
			this.label1.TabIndex = 3;
			this.label1.Text = "Date";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.dtClickDate);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(8, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(176, 32);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			// 
			// RPSalesMangement
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(840, 536);
			this.Controls.Add(this.gridChild);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.gridMaster);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "RPSalesMangement";
			this.Text = "RPSalesMangement";
			this.Load += new System.EventHandler(this.RPSalesMangement_Load);
			((System.ComponentModel.ISupportInitialize)(this.gridMaster)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridMasterView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_Category)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtClickDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridChild)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridChildView)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void RPSalesMangement_Load(object sender, System.EventArgs e)
		{
			
			connectionString =
				(string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);
			BindCategory();
			init();
			DataBind(DateTime.Today);

		}

		private void init()
		{
			dtClickDate.DateTime=DateTime.Today;
		
			DataSet _ds = new DataSet(); 
			string strSQL = "select strBranchCode from tblBranch where nBrStatusID=1 order by strBranchCode";
		
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			DataTable dt = _ds.Tables["Table"];

			DevExpress.XtraGrid.Columns.GridColumn column;
			DevExpress.XtraGrid.Columns.GridColumn column1;
			
			gridMasterView.Columns.ColumnByName("nCategory").VisibleIndex=0;
			int i=1;
			foreach(DataRow r in dt.Rows)
			{
				column=gridMasterView.Columns.AddField(r["strBranchCode"].ToString()) ;
				column.Visible =true;
				column.DisplayFormat.FormatType = FormatType.Numeric;
				column.DisplayFormat.FormatString = "#.00;[#.0]";

				column1=gridChildView.Columns.AddField(r["strBranchCode"].ToString());
				column1.Visible =true; 
				column1.DisplayFormat.FormatType = FormatType.Numeric;
				column1.DisplayFormat.FormatString ="#.00;[#.0]";

				i=i+1;
				BranchParam1= BranchParam1 + "SUM(X.[" +r["strBranchCode"].ToString()+"_Raw]) AS [" +r["strBranchCode"].ToString()+"],";
				
				BranchParam2=BranchParam2 +	"CASE WHEN I.strBranchCode = '"
					+r["strBranchCode"].ToString() +"' THEN I.Amount ELSE NULL END AS ["+r["strBranchCode"].ToString()+"_Raw],"; 

																BranchParam3= BranchParam3 + "ISNULL(SUM(X.[" +
																	r["strBranchCode"].ToString()+"_Raw]),0)+";
				
			
				//gridMasterView.Columns.ColumnByFieldName(r["strBranchCode"].ToString()).DisplayFormat="#.00".ToString();
			}
			BranchParam1=BranchParam1.Substring(0,BranchParam1.Length-1);
			BranchParam2=BranchParam2.Substring(0,BranchParam2.Length-1);
			BranchParam3=BranchParam3.Substring(0,BranchParam3.Length-1)+ " AS Total";
	
			column=gridMasterView.Columns.AddField("Total") ;
			column.Visible =true;
			column.DisplayFormat.FormatType = FormatType.Numeric;
			column.DisplayFormat.FormatString = "#.00;[#.0]";

			gridMasterView.OptionsView.ShowFooter = true;
			column.SummaryItem.FieldName = "Total";
			column.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
			column.SummaryItem.DisplayFormat="{0:#.##}";

			column1=gridChildView.Columns.AddField("Total");
			column1.Visible =true; 
			column1.DisplayFormat.FormatType = FormatType.Numeric;
			column1.DisplayFormat.FormatString ="#.00;[#.0]";

			gridChildView.OptionsView.ShowFooter = true;
			column1.SummaryItem.FieldName = "Total";
			column1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
			column1.SummaryItem.DisplayFormat ="{0:#.##}";

			//GridSummaryItem item1 = gridMasterView.GroupSummary.Add();
			//item1.FieldName = "Total";
			//item1.SummaryType = DevExpress.Data.SummaryItemType.Sum;
			//item1.Tag = 1;
			//item1.DisplayFormat = "Sum = {0:c2}";
			//item1.v


		}

		private DataTable BuildCrossQuery(DateTime dtStartDate,int nViewDays, string
			strCategoryFilter)
		{
			DateTime dtEndDate;
			int nDays;

			dtEndDate=dtStartDate.AddDays(nViewDays*-1);
			nDays=nViewDays;

			DataSet _ds = new DataSet(); 
			string strSQL = "SELECT X.dtDate, X.strReportGroup," + BranchParam1 + "," +
				BranchParam3+ " FROM (SELECT I.dtDate," + BranchParam2 ; 
			strSQL	+= " ,I.strReportGroup FROM ( ";
			strSQL	+= " select B.dtDate,B.strBranchCode,D.strReportGroup,(sum(mAmount)/(1+ dTaxRate))as Amount ";
            strSQL	+= " from tblreceiptpayment A left join tblreceipt B on A.strReceiptno = b.strReceiptno ";
			strSQL	+= " inner join TblTax C on B.nTaxId=C.nTaxId ";
			strSQL	+= " left join tblcategory D on B.nCategoryID=D.nCategoryID "; 
			strSQL	+= " where b.Fvoid=0 and ";
			strSQL  += " B.dtDate between convert(datetime,'" + dtEndDate +"',103) and convert(datetime,'" + dtStartDate+ "',103) ";
			
			if (strCategoryFilter !="All" && strCategoryFilter !="Nil")
				{
				  strSQL  += "and D.strReportGroup='"+ strCategoryFilter+ "'"; 
				}
			//DATEDIFF(day, B.dtDate,'"+ dtEndDate.ToShortDateString() + "')<=" + nDays;

			strSQL	+= " group By D.strReportGroup,B.strBranchCode,B.dtDate,dTaxRate ";
			//strSQL	+= " Having(D.nSalesCategoryID<=4 or B.nCategoryID>=14) ";
			strSQL	+= " )I)X GROUP BY X.dtDate,X.strReportGroup";
			
			if (strCategoryFilter !="All" && strCategoryFilter !="Nil")
			{
				strSQL	+= " ORDER BY X.dtDate desc,X.strReportGroup";
			}
			else
			{
				strSQL	+= " ORDER BY X.dtDate,X.strReportGroup";
			}

		
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new
				string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			DataTable dt = _ds.Tables["Table"];
			return dt;
		}

		private void BindCategory()
		{
			DataSet _ds = new DataSet(); 
			string strSQL = "select nCategoryID,strDescription from tblCategory";
		
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new
				string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			DataTable dt = _ds.Tables["Table"];
	
			DevExpress.XtraEditors.Controls.LookUpColumnInfo[] col = new
				DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
			col[0] = new
				DevExpress.XtraEditors.Controls.LookUpColumnInfo("nCategoryID","CategoryId",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
															 col[1] = new
																 DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription","Category",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			new
				ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(lk_Category,dt,col,"strDescription","nCategoryID","Category");
			
		}

		private void DataBind(DateTime SelectDate)
		{
			try
			{
				//	_ds = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure,	"up_get_AllSalesManagement",
				//			new SqlParameter("@startDate", SqlDbType.DateTime, 8,ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, SelectDate),
																																  //			new SqlParameter("@Days", SqlDbType.Int, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, 1));
				//	gridMaster.DataSource = _ds.Tables["table"];
				
				gridMaster.DataSource= BuildCrossQuery(dtClickDate.DateTime,0,"All");
				//				gridChild.DataSource =BuildCrossQuery(dtClickDate.DateTime,30);

				//				MessageBox.Show(_ds.Tables["table"].Rows.Count.ToString());
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void dtClickDate_EditValueChanged(object sender, System.EventArgs e)
		{
			if (BranchParam1.Length==0 || BranchParam2.Length==0)
			{
				return;
			}
			else
			{
				DataBind(dtClickDate.DateTime);
				gridMaster.DataSource=""   ;
				gridMaster.RefreshDataSource();

				Load_Childview();

			}
		}

		private void View_Childlist(object sender,
			DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
			Load_Childview();
		}

		private void Load_Childview()
		{
			try
			{
				DataRow dr =
					this.gridMasterView.GetDataRow(this.gridMasterView.FocusedRowHandle);
			
				if (dr["strReportGroup"]==null)
				{
					gridChild.DataSource =BuildCrossQuery(dtClickDate.DateTime,0,"Nil");
					return;
				}
				else
				{
					gridChild.DataSource
						=BuildCrossQuery(dtClickDate.DateTime,30,dr["strReportGroup"].ToString());
				}
			}
			catch(Exception ex)
			{
				gridChild.DataSource =BuildCrossQuery(dtClickDate.DateTime,0,"Nil");
			}
		}

	}
}

