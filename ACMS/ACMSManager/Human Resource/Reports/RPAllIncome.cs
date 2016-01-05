using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;
using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using ACMSLogic;
using System.IO;
using DevExpress.XtraPrinting;

namespace ACMS.ACMSManager.Reports
{
	/// <summary>
	/// Summary description for RPAllIncome.
	/// </summary>
	public class RPAllIncome : DevExpress.XtraEditors.XtraForm
	{
		private string BranchParam1,BranchParam2,BranchParam3;
		private string connectionString;
		private SqlConnection connection;
		private System.Windows.Forms.GroupBox groupBox1;
		private DevExpress.XtraGrid.GridControl gridMaster;
		private DevExpress.XtraPrintingLinks.DataGridLink printLink = new DevExpress.XtraPrintingLinks.DataGridLink();
		private DevExpress.XtraGrid.Views.Grid.GridView gridMasterView;
		private DevExpress.XtraGrid.Columns.GridColumn nCategory;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_Category;
		private DevExpress.XtraEditors.SimpleButton btn_View;
		private System.Windows.Forms.Label label3;
		private DevExpress.XtraEditors.SimpleButton btnExport;
		User oUser;
		private DevExpress.XtraEditors.DateEdit dtClickDateTill2;
		private System.Windows.Forms.MonthCalendar dtClickDate;
		private System.Windows.Forms.MonthCalendar dtClickDateTill;
		private DevExpress.XtraEditors.DateEdit dtClickDate1;
		private System.Windows.Forms.MonthCalendar dtDateDay;
		private DevExpress.XtraEditors.SimpleButton btnPrint;
		private DevExpress.XtraPrinting.PrintingSystem printingSystem1;
		private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink1;
		private System.ComponentModel.IContainer components;
        private CheckBox cbAll;
		private string strDate = "";

		public RPAllIncome()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		
			connectionString =	(string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);
			oUser = new ACMSLogic.User();
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RPAllIncome));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbAll = new System.Windows.Forms.CheckBox();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.dtDateDay = new System.Windows.Forms.MonthCalendar();
            this.dtClickDateTill = new System.Windows.Forms.MonthCalendar();
            this.dtClickDate = new System.Windows.Forms.MonthCalendar();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_View = new DevExpress.XtraEditors.SimpleButton();
            this.dtClickDateTill2 = new DevExpress.XtraEditors.DateEdit();
            this.dtClickDate1 = new DevExpress.XtraEditors.DateEdit();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.gridMaster = new DevExpress.XtraGrid.GridControl();
            this.gridMasterView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.nCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lk_Category = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.printingSystem1 = new DevExpress.XtraPrinting.PrintingSystem(this.components);
            this.printableComponentLink1 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtClickDateTill2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtClickDateTill2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtClickDate1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtClickDate1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMasterView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_Category)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbAll);
            this.groupBox1.Controls.Add(this.dtDateDay);
            this.groupBox1.Controls.Add(this.dtClickDateTill);
            this.groupBox1.Controls.Add(this.dtClickDate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btn_View);
            this.groupBox1.Controls.Add(this.dtClickDateTill2);
            this.groupBox1.Controls.Add(this.dtClickDate1);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(768, 160);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // cbAll
            // 
            this.cbAll.AutoSize = true;
            this.cbAll.Location = new System.Drawing.Point(648, 117);
            this.cbAll.Name = "cbAll";
            this.cbAll.Size = new System.Drawing.Size(37, 17);
            this.cbAll.TabIndex = 12;
            this.cbAll.Text = "All";
            this.cbAll.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(622, 181);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(96, 23);
            this.btnPrint.TabIndex = 11;
            this.btnPrint.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // dtDateDay
            // 
            this.dtDateDay.Location = new System.Drawing.Point(497, 7);
            this.dtDateDay.Name = "dtDateDay";
            this.dtDateDay.TabIndex = 10;
            this.dtDateDay.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.dtDateDay_DateSelected);
            this.dtDateDay.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.dtDateDay_DateChanged);
            // 
            // dtClickDateTill
            // 
            this.dtClickDateTill.Location = new System.Drawing.Point(266, 8);
            this.dtClickDateTill.Name = "dtClickDateTill";
            this.dtClickDateTill.TabIndex = 9;
            // 
            // dtClickDate
            // 
            this.dtClickDate.Location = new System.Drawing.Point(6, 8);
            this.dtClickDate.Name = "dtClickDate";
            this.dtClickDate.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(206, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 22);
            this.label3.TabIndex = 7;
            this.label3.Text = "TO";
            // 
            // btn_View
            // 
            this.btn_View.Location = new System.Drawing.Point(233, 112);
            this.btn_View.Name = "btn_View";
            this.btn_View.Size = new System.Drawing.Size(32, 23);
            this.btn_View.TabIndex = 6;
            this.btn_View.Text = "View";
            this.btn_View.Click += new System.EventHandler(this.btn_View_Click);
            // 
            // dtClickDateTill2
            // 
            this.dtClickDateTill2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtClickDateTill2.EditValue = null;
            this.dtClickDateTill2.Location = new System.Drawing.Point(280, 66);
            this.dtClickDateTill2.Name = "dtClickDateTill2";
            this.dtClickDateTill2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.dtClickDateTill2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtClickDateTill2.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtClickDateTill2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtClickDateTill2.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtClickDateTill2.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtClickDateTill2.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtClickDateTill2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtClickDateTill2.Size = new System.Drawing.Size(108, 22);
            this.dtClickDateTill2.TabIndex = 4;
            // 
            // dtClickDate1
            // 
            this.dtClickDate1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtClickDate1.EditValue = null;
            this.dtClickDate1.Location = new System.Drawing.Point(48, 34);
            this.dtClickDate1.Name = "dtClickDate1";
            this.dtClickDate1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.dtClickDate1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtClickDate1.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtClickDate1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtClickDate1.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtClickDate1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtClickDate1.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtClickDate1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtClickDate1.Size = new System.Drawing.Size(108, 22);
            this.dtClickDate1.TabIndex = 1;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(525, 181);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(96, 23);
            this.btnExport.TabIndex = 7;
            this.btnExport.Text = "Export To Excel";
            this.btnExport.Visible = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // gridMaster
            // 
            this.gridMaster.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            gridLevelNode2.RelationName = "Level1";
            this.gridMaster.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            this.gridMaster.Location = new System.Drawing.Point(0, 168);
            this.gridMaster.MainView = this.gridMasterView;
            this.gridMaster.Name = "gridMaster";
            this.gridMaster.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lk_Category});
            this.gridMaster.Size = new System.Drawing.Size(784, 352);
            this.gridMaster.TabIndex = 5;
            this.gridMaster.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridMasterView});
            this.gridMaster.DoubleClick += new System.EventHandler(this.gridMaster_DoubleClick);
            // 
            // gridMasterView
            // 
            this.gridMasterView.ActiveFilterEnabled = false;
            this.gridMasterView.Appearance.GroupPanel.BackColor = System.Drawing.Color.White;
            this.gridMasterView.Appearance.GroupPanel.BorderColor = System.Drawing.Color.White;
            this.gridMasterView.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.gridMasterView.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gridMasterView.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridMasterView.Appearance.GroupPanel.Options.UseBorderColor = true;
            this.gridMasterView.Appearance.GroupPanel.Options.UseFont = true;
            this.gridMasterView.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridMasterView.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridMasterView.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridMasterView.AppearancePrint.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridMasterView.AppearancePrint.HeaderPanel.Options.UseForeColor = true;
            this.gridMasterView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.gridMasterView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.nCategory});
            this.gridMasterView.GridControl = this.gridMaster;
            this.gridMasterView.GroupPanelText = "hELLO";
            this.gridMasterView.Name = "gridMasterView";
            this.gridMasterView.OptionsBehavior.Editable = false;
            this.gridMasterView.OptionsCustomization.AllowFilter = false;
            this.gridMasterView.OptionsCustomization.AllowSort = false;
            this.gridMasterView.OptionsPrint.PrintGroupFooter = false;
            this.gridMasterView.OptionsPrint.UsePrintStyles = true;
            this.gridMasterView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridMasterView.OptionsView.ShowFooter = true;
            // 
            // nCategory
            // 
            this.nCategory.Caption = "Category";
            this.nCategory.FieldName = "strReportGroup";
            this.nCategory.Name = "nCategory";
            this.nCategory.Visible = true;
            this.nCategory.VisibleIndex = 0;
            this.nCategory.Width = 100;
            // 
            // lk_Category
            // 
            this.lk_Category.AutoHeight = false;
            this.lk_Category.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lk_Category.Name = "lk_Category";
            // 
            // printingSystem1
            // 
            this.printingSystem1.Links.AddRange(new object[] {
            this.printableComponentLink1});
            // 
            // printableComponentLink1
            // 
            this.printableComponentLink1.Component = this.gridMaster;
            this.printableComponentLink1.CustomPaperSize = new System.Drawing.Size(0, 0);
            this.printableComponentLink1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("printableComponentLink1.ImageStream")));
            this.printableComponentLink1.Landscape = true;
            this.printableComponentLink1.Margins = new System.Drawing.Printing.Margins(50, 50, 50, 50);
            this.printableComponentLink1.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.printableComponentLink1.PrintingSystem = this.printingSystem1;
            this.printableComponentLink1.VerticalContentSplitting = DevExpress.XtraPrinting.VerticalContentSplitting.Smart;
            // 
            // RPAllIncome
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(784, 512);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.gridMaster);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RPAllIncome";
            this.Text = "RPAllIncome";
            this.Load += new System.EventHandler(this.RPAllIncome_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtClickDateTill2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtClickDateTill2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtClickDate1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtClickDate1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMasterView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_Category)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
	
			private void RPAllIncome_Load(object sender, System.EventArgs e)
		{
			init();
			DayDataBind();
			if(oUser.NRightsLevelID() == 1005 || oUser.NRightsLevelID() == 1006 || 
				oUser.NRightsLevelID() == 9000 || oUser.NRightsLevelID() == 9999)
				btnExport.Visible = true;
		}
	
		private void init()
		{
			//dtClickDate.DateTime=DateTime.Today;
			//dtClickDateTill.DateTime=DateTime.Today;
		
			DataSet _ds = new DataSet(); 
			string strSQL = "select strBranchCode from tblBranch where nBrStatusID=1 order by strBranchCode";
		
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			DataTable dt = _ds.Tables["Table"];

			DevExpress.XtraGrid.Columns.GridColumn column;
			
			gridMasterView.Columns.ColumnByName("nCategory").VisibleIndex=0;
			int i=1;
			foreach(DataRow r in dt.Rows)
			{
				column=gridMasterView.Columns.AddField(r["strBranchCode"].ToString()) ;
				column.Visible =true;
				column.DisplayFormat.FormatType = FormatType.Numeric;
				column.DisplayFormat.FormatString = "#,##0.00;(#,##0.00)";
				i=i+1;
				BranchParam1= BranchParam1 + "SUM(X.[" +r["strBranchCode"].ToString()+"_Raw]) AS [" +r["strBranchCode"].ToString()+"],";
				
				BranchParam2=BranchParam2 +	"CASE WHEN I.strBranchCode = '"
					+r["strBranchCode"].ToString() +"' THEN I.Amount ELSE NULL END AS ["+r["strBranchCode"].ToString()+"_Raw],"; 

				BranchParam3= BranchParam3 + "ISNULL(SUM(X.[" +
					r["strBranchCode"].ToString()+"_Raw]),0)+";
			
				column.SummaryItem.FieldName = r["strBranchCode"].ToString();
				column.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
				//column.SummaryItem.DisplayFormat = "{0:#.#0}";
				column.SummaryItem.DisplayFormat = "{0:#,##0.#0}";
			}
			BranchParam1=BranchParam1.Substring(0,BranchParam1.Length-1);
			BranchParam2=BranchParam2.Substring(0,BranchParam2.Length-1);
			BranchParam3=BranchParam3.Substring(0,BranchParam3.Length-1)+ " AS Total";
	
			column=gridMasterView.Columns.AddField("Total") ;
			column.Visible =true;
			column.DisplayFormat.FormatType = FormatType.Numeric;
			//column.DisplayFormat.FormatString = "#.00;(#.00)";
			column.DisplayFormat.FormatString = "#,##0.00;(#,##0.00)";

			gridMasterView.OptionsView.ShowFooter = true;
			column.SummaryItem.FieldName = "Total";
			column.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
			//column.SummaryItem.DisplayFormat="{0:#.#0}";
			column.SummaryItem.DisplayFormat="{0:#,##0.#0}";			
			

		}

		private DataTable BuildCrossQuery(DateTime dtStartDate,DateTime dtEndDate)
		{
            //if (cbAll.Checked)
            //{
            //    DataSet _ds = new DataSet();
            //    string strSQL = "SELECT X.strReportGroup," + BranchParam1 + "," +
            //        BranchParam3 + " FROM (SELECT " + BranchParam2;
            //    strSQL += " ,I.strReportGroup FROM ( ";
            //    strSQL += " select B.strBranchCode,D.strReportGroup,round(cast((sum(mAmount)/(1+ dTaxRate)) as money),2) as Amount ";
            //    strSQL += " from tblreceiptpayment A left join tblreceipt B on A.strReceiptno = b.strReceiptno ";
            //    strSQL += " inner join TblTax C on B.nTaxId=C.nTaxId ";
            //    strSQL += " left join tblcategory D on B.nCategoryID=D.nCategoryID ";
            //    strSQL += " where b.Fvoid=0 and ";
            //    strSQL += " B.dtDate between convert(datetime,'" + dtStartDate + "',103) and convert(datetime,'" + dtEndDate + "',103) ";

            //    strSQL += " group By D.strReportGroup,B.strBranchCode,dTaxRate ";
            //    strSQL += " )I)X GROUP BY X.strReportGroup";

            //    strSQL += " ORDER BY X.strReportGroup";

            //    SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA", _ds, new
            //        string[] { "Table" }, new SqlParameter("@strSQL", strSQL));
            //    DataTable dt = _ds.Tables["Table"];
            //    return dt;
            //}
            //else
            //{
            //    DataSet _ds = new DataSet();
            //    string strSQL = "SELECT X.strReportGroup," + BranchParam1 + "," +
            //        BranchParam3 + " FROM (SELECT " + BranchParam2;
            //    strSQL += " ,I.strReportGroup FROM ( ";
            //    strSQL += " select B.strBranchCode,D.strReportGroup,round(cast((sum(mAmount)/(1+ dTaxRate)) as money),2) as Amount ";
            //    strSQL += " from tblreceiptpayment A left join tblreceipt B on A.strReceiptno = b.strReceiptno ";
            //    strSQL += " inner join TblTax C on B.nTaxId=C.nTaxId ";
            //    strSQL += " left join tblcategory D on B.nCategoryID=D.nCategoryID ";
            //    strSQL += " where b.Fvoid=0 and B.strMembershipID  like '[a-z]%' and";
            //    strSQL += " B.dtDate between convert(datetime,'" + dtStartDate + "',103) and convert(datetime,'" + dtEndDate + "',103) ";

            //    strSQL += " group By D.strReportGroup,B.strBranchCode,dTaxRate ";
            //    strSQL += " )I)X GROUP BY X.strReportGroup";

            //    strSQL += " ORDER BY X.strReportGroup";

            //    SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA", _ds, new
            //        string[] { "Table" }, new SqlParameter("@strSQL", strSQL));
            //    DataTable dt = _ds.Tables["Table"];
            //    return dt;
            //}
            // AllIncomeListing
            string strSQL;
            DataSet _ds = new DataSet();
            strSQL = "sp_RPTNewAllIncomeListing '" + string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(dtStartDate)) + "','" + string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(dtEndDate)) + "'";

            SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA", _ds, new
                 string[] { "Table" }, new SqlParameter("@strSQL", strSQL));
            DataTable dt = _ds.Tables["Table"];
            return dt; 

		}

	
		private void DataBind()
		{
			try
			{	
				gridMaster.DataSource= BuildCrossQuery(dtClickDate.SelectionStart,dtClickDateTill.SelectionStart);
				strDate = "between " + dtClickDate.SelectionStart.ToShortDateString().ToString()+ " and " + dtClickDateTill.SelectionStart.ToShortDateString().ToString();
				gridMasterView.GroupPanelText = "All Income Report for Date " + strDate;
				
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
		private void DayDataBind()
		{
			try
			{	
				strDate = dtDateDay.SelectionStart.ToShortDateString().ToString();
				gridMaster.DataSource= BuildCrossQuery(dtDateDay.SelectionStart,dtDateDay.SelectionStart);
				gridMasterView.GroupPanelText = "All Income Report for Date " + strDate;
				
			
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void btn_View_Click(object sender, System.EventArgs e)
		{
			if (DateTime.Compare(dtClickDate.SelectionStart,dtClickDateTill.SelectionStart)>0)
			{
				MessageBox.Show("Invalid Dates.");
				return;
			}
			
			if (BranchParam1.Length==0 || BranchParam2.Length==0)
			{
				return;
			}
			else
			{
				gridMaster.DataSource=""   ;
				DataBind();
				gridMaster.RefreshDataSource();
			}
		}

		private void btnExport_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog oFDlg = new OpenFileDialog();
			oFDlg.Filter = "Excel Files (*.xls)|*.xls";
			oFDlg.CheckFileExists = false;	

            try
            {
                if (oFDlg.ShowDialog() == DialogResult.OK)
                {
                    string strDir = oFDlg.FileName;
                    gridMaster.MainView.ExportToXls(strDir);
                }

            }
            catch { }
		}

		private void dtDateDay_DateSelected(object sender, System.Windows.Forms.DateRangeEventArgs e)
		{
		DayDataBind();
		}

		protected Image ClipboardImage 
		{
			get 
			{
				IDataObject iData = Clipboard.GetDataObject();
				if(iData == null) return null;

				if(iData.GetDataPresent(DataFormats.Bitmap))
					return (Image)iData.GetData(DataFormats.Bitmap);
				return null;
			}
			set { Clipboard.SetDataObject(value); }
		}

		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			PageHeaderFooter ph = printableComponentLink1.PageHeaderFooter as PageHeaderFooter;
			ph.Header.Content.Clear();
			ph.Header.Content.AddRange(new string[]{"All Income Report for Date " + strDate,"",""});
			printableComponentLink1.CreateDocument(printingSystem1);
			printingSystem1.PreviewFormEx.AutoScale = true;
            printingSystem1.PreviewFormEx.ForeColor = System.Drawing.Color.Black;
            printingSystem1.PreviewFormEx.Owner = this;
            printingSystem1.PreviewFormEx.PrintingSystem.Print();
//
//			printableComponentLink1.CreateDocument();
//			printableComponentLink1.PrintingSystem.PreviewForm.AutoScale = true;
//			printableComponentLink1.PrintingSystem.Print();

//			Cursor currentCursor = Cursor.Current;
//			Cursor.Current = Cursors.WaitCursor;
//
//			BrickGraphics gr = printingSystem1.Graph;
//			SendKeys.SendWait("^{PRTSC}");
//			Image img = ClipboardImage;
//			printingSystem1.Begin();
//			gr.Modifier = BrickModifier.Detail;
//			RectangleF r = new RectangleF(new PointF(0, 0), gr.ClientPageSize);
//			gr.DrawEmptyBrick(new RectangleF(0, 0, 100, 100));
//			
//			if(img != null) 
//			{
////				if(!autoWidth)
//				r = new RectangleF(0, 0, 870, 610);
//				CustomBrick brick = gr.DrawImage(img, r, BorderSide.None, Color.Transparent);	   
//				brick.Separable = true;
//			}
//			else 
//				MessageBox.Show("Image is null...");
//			
//			gr.Font = new Font("Arial", 8, FontStyle.Underline);
//			gr.Modifier = BrickModifier.MarginalFooter;
//			
//			gr.BackColor = Color.Transparent;
//			r = new RectangleF(0, 0, 0, gr.Font.Height);
//			
//			PageInfoBrick pibrick = gr.DrawPageInfo(PageInfo.Number, "XtraPrintingSystem by Developer Express inc.", Color.Blue, r, BorderSide.None);
//			pibrick.Url = "www.devexpress.com";
//			pibrick.Hint = pibrick.Url;
//			pibrick.Alignment = BrickAlignment.Far;
//			pibrick.AutoWidth = true;
//
//			printingSystem1.End();
////			if(closeCount == 0) 
////			{
////				printSystem1.PreviewForm.Closed += new EventHandler(ClosePreview);
////				closeCount++;
////			}
//			//printingSystem1.PreviewForm.Show();
//			
//			printingSystem1.PreviewForm.Activate();
//			printingSystem1.PreviewForm.PrintingSystem.PageSettings.Landscape = true;
//			printingSystem1.PreviewForm.PrintingSystem.Print();
//
//			Cursor.Current = currentCursor;
		
		}

		private void groupBox1_Enter(object sender, System.EventArgs e)
		{
		
		}

        private void gridMaster_DoubleClick(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi =
            gridMasterView.CalcHitInfo((sender as System.Windows.Forms.Control).PointToClient(System.Windows.Forms.Control.MousePosition));
            DataRow FocusRow;
            if (hi.RowHandle >= 0)
            {
                int nCategory = 99;
                FocusRow = gridMasterView.GetDataRow(hi.RowHandle);
                if (FocusRow.ItemArray[0].ToString() == "Fitness Package")
                    nCategory = 1;
                else if (FocusRow.ItemArray[0].ToString() == "Spa Package")
                    nCategory = 2;
                else if (FocusRow.ItemArray[0].ToString() == "Fitness Product")
                    nCategory = 3;
                else if (FocusRow.ItemArray[0].ToString() == "Spa Product")
                    nCategory = 4;
                else if (FocusRow.ItemArray[0].ToString() == "PT Package")
                    nCategory = 5;
                ACMS.ACMSManager.Human_Resource.Reports.RPAllIncomeDetail frm = new ACMS.ACMSManager.Human_Resource.Reports.RPAllIncomeDetail(FocusRow.ItemArray[0].ToString(), nCategory, dtDateDay.SelectionStart, oUser.NEmployeeID());
                frm.Show();
                //ACMS.ACMSStaff.WorkFlow.MyCustomEditForm frm = new ACMS.ACMSStaff.WorkFlow.MyCustomEditForm((int)FocusRow.ItemArray[0], nDepartment);
                //frm.Show();
            }        
        }

        private void dtDateDay_DateChanged(object sender, DateRangeEventArgs e)
        {

        }


	}

}

