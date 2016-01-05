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
	/// Summary description for AllIncomeAnalysis.
	/// </summary>
	public class AllIncomeAnalysis : System.Windows.Forms.Form
	{
		private string connectionString;
		private SqlConnection connection;
		private DevExpress.XtraPivotGrid.PivotGridControl GridAllIncome;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label DateTo;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField1;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField2;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField3;
		private DevExpress.XtraEditors.DateEdit DateRangeTo;
		private DevExpress.XtraEditors.DateEdit DateFrom;
		private System.ComponentModel.IContainer components;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField10;
		private System.Windows.Forms.Label label3;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField11;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField12;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField9;
		private DevExpress.XtraPivotGrid.PivotGridControl PrevTenDaysIncomeAnalysis;
		private int EmployeeID;
		private DevExpress.XtraPrinting.PrintingSystem printingSystem1;
		private DevExpress.XtraEditors.HyperLinkEdit PRINT1;
		private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink1;
		private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink2;
		private DevExpress.XtraEditors.HyperLinkEdit PRINT2;
        private PivotGridField pivotGridField4;
		private bool isFinishBindInit = false;

		public AllIncomeAnalysis(int empID)
		{
			//
			// Required for Windows Form Designer support
			//
			EmployeeID = empID;
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraPivotGrid.PivotGridGroup pivotGridGroup1 = new DevExpress.XtraPivotGrid.PivotGridGroup();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AllIncomeAnalysis));
            this.pivotGridField10 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.GridAllIncome = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField2 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField3 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.DateRangeTo = new DevExpress.XtraEditors.DateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.DateTo = new System.Windows.Forms.Label();
            this.DateFrom = new DevExpress.XtraEditors.DateEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.PrevTenDaysIncomeAnalysis = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.pivotGridField11 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField12 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField9 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.printingSystem1 = new DevExpress.XtraPrinting.PrintingSystem(this.components);
            this.printableComponentLink1 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
            this.printableComponentLink2 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
            this.PRINT1 = new DevExpress.XtraEditors.HyperLinkEdit();
            this.PRINT2 = new DevExpress.XtraEditors.HyperLinkEdit();
            this.pivotGridField4 = new DevExpress.XtraPivotGrid.PivotGridField();
            ((System.ComponentModel.ISupportInitialize)(this.GridAllIncome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateRangeTo.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateRangeTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateFrom.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrevTenDaysIncomeAnalysis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PRINT1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PRINT2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pivotGridField10
            // 
            this.pivotGridField10.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField10.AreaIndex = 0;
            this.pivotGridField10.Caption = "Category";
            this.pivotGridField10.FieldName = "strDescription";
            this.pivotGridField10.Name = "pivotGridField10";
            this.pivotGridField10.Width = 120;
            // 
            // GridAllIncome
            // 
            this.GridAllIncome.Cursor = System.Windows.Forms.Cursors.Default;
            this.GridAllIncome.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.pivotGridField1,
            this.pivotGridField2,
            this.pivotGridField3,
            this.pivotGridField4});
            this.GridAllIncome.Location = new System.Drawing.Point(0, 40);
            this.GridAllIncome.Name = "GridAllIncome";
            this.GridAllIncome.OptionsView.ShowDataHeaders = false;
            this.GridAllIncome.OptionsView.ShowFilterHeaders = false;
            this.GridAllIncome.Size = new System.Drawing.Size(960, 288);
            this.GridAllIncome.TabIndex = 0;
            // 
            // pivotGridField1
            // 
            this.pivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.pivotGridField1.AreaIndex = 0;
            this.pivotGridField1.Caption = "Branch";
            this.pivotGridField1.FieldName = "strBranchCode";
            this.pivotGridField1.Name = "pivotGridField1";
            this.pivotGridField1.Options.AllowDrag = DevExpress.Utils.DefaultBoolean.False;
            this.pivotGridField1.Options.AllowExpand = DevExpress.Utils.DefaultBoolean.False;
            this.pivotGridField1.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.False;
            this.pivotGridField1.Options.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // pivotGridField2
            // 
            this.pivotGridField2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField2.AreaIndex = 0;
            this.pivotGridField2.Caption = "Category";
            this.pivotGridField2.FieldName = "strDescription";
            this.pivotGridField2.Name = "pivotGridField2";
            this.pivotGridField2.Width = 120;
            // 
            // pivotGridField3
            // 
            this.pivotGridField3.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pivotGridField3.AreaIndex = 0;
            this.pivotGridField3.Caption = "Nett Amount";
            this.pivotGridField3.FieldName = "mNettAmount";
            this.pivotGridField3.Name = "pivotGridField3";
            // 
            // DateRangeTo
            // 
            this.DateRangeTo.EditValue = null;
            this.DateRangeTo.Location = new System.Drawing.Point(216, 8);
            this.DateRangeTo.Name = "DateRangeTo";
            this.DateRangeTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateRangeTo.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.DateRangeTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.DateRangeTo.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.DateRangeTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.DateRangeTo.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.DateRangeTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.DateRangeTo.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.DateRangeTo.Size = new System.Drawing.Size(100, 20);
            this.DateRangeTo.TabIndex = 2;
            this.DateRangeTo.EditValueChanged += new System.EventHandler(this.DateRangeTo_EditValueChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "From";
            // 
            // DateTo
            // 
            this.DateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateTo.Location = new System.Drawing.Point(176, 8);
            this.DateTo.Name = "DateTo";
            this.DateTo.Size = new System.Drawing.Size(24, 16);
            this.DateTo.TabIndex = 4;
            this.DateTo.Text = "To";
            // 
            // DateFrom
            // 
            this.DateFrom.EditValue = null;
            this.DateFrom.Location = new System.Drawing.Point(48, 8);
            this.DateFrom.Name = "DateFrom";
            this.DateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateFrom.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.DateFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.DateFrom.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.DateFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.DateFrom.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.DateFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.DateFrom.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.DateFrom.Size = new System.Drawing.Size(100, 20);
            this.DateFrom.TabIndex = 5;
            this.DateFrom.EditValueChanged += new System.EventHandler(this.DateFrom_EditValueChanged);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 336);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 24);
            this.label3.TabIndex = 41;
            this.label3.Text = "Previous 10  Days Sales";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PrevTenDaysIncomeAnalysis
            // 
            this.PrevTenDaysIncomeAnalysis.Cursor = System.Windows.Forms.Cursors.Default;
            this.PrevTenDaysIncomeAnalysis.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.pivotGridField11,
            this.pivotGridField10,
            this.pivotGridField12,
            this.pivotGridField9});
            pivotGridGroup1.Fields.Add(this.pivotGridField10);
            pivotGridGroup1.Hierarchy = null;
            this.PrevTenDaysIncomeAnalysis.Groups.AddRange(new DevExpress.XtraPivotGrid.PivotGridGroup[] {
            pivotGridGroup1});
            this.PrevTenDaysIncomeAnalysis.Location = new System.Drawing.Point(0, 360);
            this.PrevTenDaysIncomeAnalysis.Name = "PrevTenDaysIncomeAnalysis";
            this.PrevTenDaysIncomeAnalysis.OptionsCustomization.AllowDrag = false;
            this.PrevTenDaysIncomeAnalysis.OptionsCustomization.AllowExpand = false;
            this.PrevTenDaysIncomeAnalysis.OptionsCustomization.AllowSort = false;
            this.PrevTenDaysIncomeAnalysis.OptionsDataField.Area = DevExpress.XtraPivotGrid.PivotDataArea.RowArea;
            this.PrevTenDaysIncomeAnalysis.OptionsDataField.AreaIndex = 1;
            this.PrevTenDaysIncomeAnalysis.OptionsView.ShowDataHeaders = false;
            this.PrevTenDaysIncomeAnalysis.OptionsView.ShowFilterHeaders = false;
            this.PrevTenDaysIncomeAnalysis.OptionsView.ShowRowGrandTotals = false;
            this.PrevTenDaysIncomeAnalysis.Size = new System.Drawing.Size(960, 200);
            this.PrevTenDaysIncomeAnalysis.TabIndex = 40;
            // 
            // pivotGridField11
            // 
            this.pivotGridField11.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pivotGridField11.AreaIndex = 0;
            this.pivotGridField11.Caption = "Nett Amount";
            this.pivotGridField11.FieldName = "SalesAmount";
            this.pivotGridField11.Name = "pivotGridField11";
            // 
            // pivotGridField12
            // 
            this.pivotGridField12.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.pivotGridField12.AreaIndex = 0;
            this.pivotGridField12.Caption = "Branch";
            this.pivotGridField12.FieldName = "strBranchCode";
            this.pivotGridField12.Name = "pivotGridField12";
            this.pivotGridField12.Options.AllowDrag = DevExpress.Utils.DefaultBoolean.False;
            this.pivotGridField12.Options.AllowExpand = DevExpress.Utils.DefaultBoolean.False;
            this.pivotGridField12.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.False;
            this.pivotGridField12.Options.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // pivotGridField9
            // 
            this.pivotGridField9.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField9.AreaIndex = 1;
            this.pivotGridField9.Caption = "Date";
            this.pivotGridField9.FieldName = "dtDate";
            this.pivotGridField9.Name = "pivotGridField9";
            this.pivotGridField9.Options.AllowDrag = DevExpress.Utils.DefaultBoolean.False;
            this.pivotGridField9.Options.AllowExpand = DevExpress.Utils.DefaultBoolean.False;
            this.pivotGridField9.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.False;
            this.pivotGridField9.Options.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.pivotGridField9.ValueFormat.FormatString = "d";
            this.pivotGridField9.ValueFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            // 
            // printingSystem1
            // 
            this.printingSystem1.Links.AddRange(new object[] {
            this.printableComponentLink1,
            this.printableComponentLink2});
            // 
            // printableComponentLink1
            // 
            this.printableComponentLink1.Component = this.GridAllIncome;
            this.printableComponentLink1.CustomPaperSize = new System.Drawing.Size(0, 0);
            this.printableComponentLink1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("printableComponentLink1.ImageStream")));
            this.printableComponentLink1.PageHeaderFooter = new DevExpress.XtraPrinting.PageHeaderFooter(new DevExpress.XtraPrinting.PageHeaderArea(new string[] {
                "All Income Analysis Report",
                "",
                "[Date Printed] [Time Printed]"}, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134))), DevExpress.XtraPrinting.BrickAlignment.Near), new DevExpress.XtraPrinting.PageFooterArea(new string[] {
                "",
                "",
                "[Page # of Pages #]"}, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134))), DevExpress.XtraPrinting.BrickAlignment.Near));
            this.printableComponentLink1.PrintingSystem = this.printingSystem1;
            this.printableComponentLink1.VerticalContentSplitting = DevExpress.XtraPrinting.VerticalContentSplitting.Smart;
            // 
            // printableComponentLink2
            // 
            this.printableComponentLink2.Component = this.PrevTenDaysIncomeAnalysis;
            this.printableComponentLink2.CustomPaperSize = new System.Drawing.Size(0, 0);
            this.printableComponentLink2.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("printableComponentLink2.ImageStream")));
            this.printableComponentLink2.PageHeaderFooter = new DevExpress.XtraPrinting.PageHeaderFooter(new DevExpress.XtraPrinting.PageHeaderArea(new string[] {
                "All Income Analysis Report - Previous 10 Days Sales",
                "",
                "[Date Printed] [Time Printed]"}, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134))), DevExpress.XtraPrinting.BrickAlignment.Near), new DevExpress.XtraPrinting.PageFooterArea(new string[] {
                "",
                "",
                "[Page # of Pages #]"}, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134))), DevExpress.XtraPrinting.BrickAlignment.Near));
            this.printableComponentLink2.PrintingSystem = this.printingSystem1;
            this.printableComponentLink2.VerticalContentSplitting = DevExpress.XtraPrinting.VerticalContentSplitting.Smart;
            // 
            // PRINT1
            // 
            this.PRINT1.EditValue = "PRINT";
            this.PRINT1.Location = new System.Drawing.Point(328, 8);
            this.PRINT1.Name = "PRINT1";
            this.PRINT1.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.PRINT1.Properties.Appearance.Options.UseBackColor = true;
            this.PRINT1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.PRINT1.Size = new System.Drawing.Size(40, 18);
            this.PRINT1.TabIndex = 140;
            this.PRINT1.OpenLink += new DevExpress.XtraEditors.Controls.OpenLinkEventHandler(this.PRINT1_OpenLink);
            // 
            // PRINT2
            // 
            this.PRINT2.EditValue = "PRINT";
            this.PRINT2.Location = new System.Drawing.Point(168, 336);
            this.PRINT2.Name = "PRINT2";
            this.PRINT2.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.PRINT2.Properties.Appearance.Options.UseBackColor = true;
            this.PRINT2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.PRINT2.Size = new System.Drawing.Size(40, 18);
            this.PRINT2.TabIndex = 141;
            this.PRINT2.OpenLink += new DevExpress.XtraEditors.Controls.OpenLinkEventHandler(this.PRINT2_OpenLink);
            // 
            // pivotGridField4
            // 
            this.pivotGridField4.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField4.AreaIndex = 1;
            this.pivotGridField4.Name = "pivotGridField4";
            // 
            // AllIncomeAnalysis
            // 
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(767, 173);
            this.Controls.Add(this.PRINT2);
            this.Controls.Add(this.PRINT1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PrevTenDaysIncomeAnalysis);
            this.Controls.Add(this.DateFrom);
            this.Controls.Add(this.DateTo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DateRangeTo);
            this.Controls.Add(this.GridAllIncome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AllIncomeAnalysis";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "All Income Analysis";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AllIncomeAnalysis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridAllIncome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateRangeTo.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateRangeTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateFrom.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrevTenDaysIncomeAnalysis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PRINT1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PRINT2.Properties)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void AllIncomeAnalysis_Load(object sender, System.EventArgs e)
		{
			DateFrom.EditValue = DateTime.Today;//string.Format("{0:dd/MM/yyyy}",Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year));
			isFinishBindInit = false;
			DateRangeTo.EditValue = DateTime.Today;
			isFinishBindInit = true;
			BindReport();
		}

		private void BindReport()
		{
			if (!isFinishBindInit)
				return;

			string strSQL;
			DataSet _ds;

			// first previous two month sales
			strSQL = "up_get_AllIncomeAnalysis " + EmployeeID + ",'" + string.Format("{0:yyyy-MM-dd}",Convert.ToDateTime(DateFrom.EditValue)) + "','" + string.Format("{0:yyyy-MM-dd}",Convert.ToDateTime(DateRangeTo.EditValue)) + "'";
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			GridAllIncome.DataSource = _ds.Tables["table"];

			strSQL = "up_get_AllAnalysisAmtPrev10Days " + EmployeeID;
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			DataTable dt = _ds.Tables["table"];
			PrevTenDaysIncomeAnalysis.DataSource = _ds.Tables["table"];
			
		}

		private void DateFrom_EditValueChanged(object sender, System.EventArgs e)
		{
				BindReport();
		}

		private void DateRangeTo_EditValueChanged(object sender, System.EventArgs e)
		{
			BindReport();
		}

		private void PRINT1_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
		{
			printableComponentLink1.CreateDocument();
			printableComponentLink1.PrintingSystem.Print();
		}

		private void PRINT2_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
		{
			printableComponentLink2.CreateDocument();
			printableComponentLink2.PrintingSystem.Print();
		}

	

		
	}
}
