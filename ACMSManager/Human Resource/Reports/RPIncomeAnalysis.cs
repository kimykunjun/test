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
using Do = Acms.Core.Domain;
using ACMSLogic;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraPrinting;

namespace ACMS.ACMSManager.Reports
{
	/// <summary>
	/// Summary description for ShowReport.
	/// </summary>
	public class RPIncomeAnalysis : System.Windows.Forms.Form
	{


		private Do.Employee employee;
		private Do.TerminalUser terminalUser; 
		User oUser;
		private string connectionString;
		private SqlConnection connection;
		private DataSet _ds;
		private DataTable dtCurrentMonthSales;
		private DataTable dtPrevTwoSales;
		private DataTable dtPrevTenDaysSales;
		private DataView dvCurrentMonthSales;
		private DataView dvPrevTwoSales;
		private DataView dvPrevTenDaysSales;
		private DevExpress.XtraPivotGrid.PivotGridControl CurrentGridIncomeAnalysis;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField7;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField8;
		private DevExpress.XtraPivotGrid.PivotGridField v2TargetAmount;
		private DevExpress.XtraPivotGrid.PivotGridField TargetPercent;
		private DevExpress.XtraPivotGrid.PivotGridField DayMonthEnd;
		private DevExpress.XtraPivotGrid.PivotGridField DayAvg;
		private DevExpress.XtraPivotGrid.PivotGridField pv2NettAmount;
		private System.Windows.Forms.Label label63;
		private DevExpress.XtraEditors.ImageComboBoxEdit cmbCategory;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Label label2;
		private int EmployeeID;
		private bool isFinishBindInit;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField14;
		private DevExpress.XtraPivotGrid.PivotGridField colTest;
		private System.Windows.Forms.ImageList imageList1;
		private DevExpress.XtraEditors.HyperLinkEdit PRINT1;
		private DevExpress.XtraPrinting.PrintingSystem printingSystem1;
		private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink1;
		private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink2;
		private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink3;
		private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink4;
		private DevExpress.XtraPivotGrid.PivotGridControl PrevGridIncomeAnalysis;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField1;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField3;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField4;
		private DevExpress.XtraPivotGrid.PivotGridField TargetAmt;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField13;
		private DevExpress.XtraPivotGrid.PivotGridField TestTargetAmt;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.HyperLinkEdit hyperLinkEdit2;
		internal DevExpress.XtraEditors.SimpleButton btn_Add;
		internal DevExpress.XtraEditors.SimpleButton btn_Del;
		private DevExpress.XtraPivotGrid.PivotGridControl pvGrandTotal10Days;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField16;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField17;
		private DevExpress.XtraPivotGrid.PivotGridControl ThirdGridIncomeAnalysis;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField11;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField12;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField9;
		private System.Windows.Forms.ComboBox cmbMonth;
		private System.Windows.Forms.Label label4;
        private PivotGridField vTargetAmt;
		private DevExpress.XtraEditors.HyperLinkEdit hyperLinkEdit1;

		public RPIncomeAnalysis(int empID)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RPIncomeAnalysis));
            DevExpress.XtraPivotGrid.PivotGridGroup pivotGridGroup2 = new DevExpress.XtraPivotGrid.PivotGridGroup();
            DevExpress.XtraPivotGrid.PivotGridGroup pivotGridGroup3 = new DevExpress.XtraPivotGrid.PivotGridGroup();
            DevExpress.XtraPivotGrid.PivotGridGroup pivotGridGroup4 = new DevExpress.XtraPivotGrid.PivotGridGroup();
            this.CurrentGridIncomeAnalysis = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.pv2NettAmount = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField7 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField8 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.v2TargetAmount = new DevExpress.XtraPivotGrid.PivotGridField();
            this.TargetPercent = new DevExpress.XtraPivotGrid.PivotGridField();
            this.DayMonthEnd = new DevExpress.XtraPivotGrid.PivotGridField();
            this.DayAvg = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField14 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.colTest = new DevExpress.XtraPivotGrid.PivotGridField();
            this.label63 = new System.Windows.Forms.Label();
            this.cmbCategory = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.PRINT1 = new DevExpress.XtraEditors.HyperLinkEdit();
            this.printingSystem1 = new DevExpress.XtraPrinting.PrintingSystem(this.components);
            this.printableComponentLink1 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
            this.printableComponentLink2 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
            this.printableComponentLink3 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
            this.printableComponentLink4 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
            this.hyperLinkEdit1 = new DevExpress.XtraEditors.HyperLinkEdit();
            this.PrevGridIncomeAnalysis = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField3 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField4 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.vTargetAmt = new DevExpress.XtraPivotGrid.PivotGridField();
            this.TargetAmt = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField13 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.TestTargetAmt = new DevExpress.XtraPivotGrid.PivotGridField();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.hyperLinkEdit2 = new DevExpress.XtraEditors.HyperLinkEdit();
            this.btn_Add = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Del = new DevExpress.XtraEditors.SimpleButton();
            this.pvGrandTotal10Days = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.pivotGridField16 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField17 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.ThirdGridIncomeAnalysis = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.pivotGridField11 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField12 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField9 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentGridIncomeAnalysis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PRINT1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrevGridIncomeAnalysis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pvGrandTotal10Days)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThirdGridIncomeAnalysis)).BeginInit();
            this.SuspendLayout();
            // 
            // CurrentGridIncomeAnalysis
            // 
            this.CurrentGridIncomeAnalysis.Cursor = System.Windows.Forms.Cursors.Default;
            this.CurrentGridIncomeAnalysis.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.pv2NettAmount,
            this.pivotGridField7,
            this.pivotGridField8,
            this.v2TargetAmount,
            this.TargetPercent,
            this.DayMonthEnd,
            this.DayAvg,
            this.pivotGridField14,
            this.colTest});
            this.CurrentGridIncomeAnalysis.Groups.AddRange(new DevExpress.XtraPivotGrid.PivotGridGroup[] {
            pivotGridGroup1});
            this.CurrentGridIncomeAnalysis.Location = new System.Drawing.Point(0, 271);
            this.CurrentGridIncomeAnalysis.Name = "CurrentGridIncomeAnalysis";
            this.CurrentGridIncomeAnalysis.OptionsCustomization.AllowDrag = false;
            this.CurrentGridIncomeAnalysis.OptionsCustomization.AllowExpand = false;
            this.CurrentGridIncomeAnalysis.OptionsDataField.Area = DevExpress.XtraPivotGrid.PivotDataArea.RowArea;
            this.CurrentGridIncomeAnalysis.OptionsDataField.AreaIndex = 1;
            this.CurrentGridIncomeAnalysis.OptionsPrint.UsePrintAppearance = true;
            this.CurrentGridIncomeAnalysis.OptionsView.ShowDataHeaders = false;
            this.CurrentGridIncomeAnalysis.OptionsView.ShowFilterHeaders = false;
            this.CurrentGridIncomeAnalysis.OptionsView.ShowRowGrandTotals = false;
            this.CurrentGridIncomeAnalysis.Size = new System.Drawing.Size(960, 156);
            this.CurrentGridIncomeAnalysis.TabIndex = 1;
            this.CurrentGridIncomeAnalysis.Click += new System.EventHandler(this.CurrentGridIncomeAnalysis_Click);
            this.CurrentGridIncomeAnalysis.CustomSummary += new DevExpress.XtraPivotGrid.PivotGridCustomSummaryEventHandler(this.CurrentGridIncomeAnalysis_CustomSummary);
            // 
            // pv2NettAmount
            // 
            this.pv2NettAmount.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pv2NettAmount.AreaIndex = 0;
            this.pv2NettAmount.Caption = "Branch Sales";
            this.pv2NettAmount.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pv2NettAmount.FieldName = "mNettAmount";
            this.pv2NettAmount.Name = "pv2NettAmount";
            this.pv2NettAmount.TotalCellFormat.FormatString = "f2";
            this.pv2NettAmount.TotalCellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pv2NettAmount.TotalValueFormat.FormatString = "f2";
            this.pv2NettAmount.TotalValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pv2NettAmount.ValueFormat.FormatString = "f2";
            this.pv2NettAmount.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pv2NettAmount.Width = 80;
            // 
            // pivotGridField7
            // 
            this.pivotGridField7.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.pivotGridField7.AreaIndex = 0;
            this.pivotGridField7.Caption = "Branch";
            this.pivotGridField7.FieldName = "strBranchCode";
            this.pivotGridField7.Name = "pivotGridField7";
            this.pivotGridField7.Options.AllowDrag = DevExpress.Utils.DefaultBoolean.False;
            this.pivotGridField7.Options.AllowExpand = DevExpress.Utils.DefaultBoolean.False;
            this.pivotGridField7.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.False;
            this.pivotGridField7.Options.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.pivotGridField7.Width = 80;
            // 
            // pivotGridField8
            // 
            this.pivotGridField8.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pivotGridField8.AreaIndex = 1;
            this.pivotGridField8.Caption = "Branch Sales";
            this.pivotGridField8.FieldName = "mTotalAmount";
            this.pivotGridField8.Name = "pivotGridField8";
            this.pivotGridField8.Visible = false;
            this.pivotGridField8.Width = 80;
            // 
            // v2TargetAmount
            // 
            this.v2TargetAmount.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.v2TargetAmount.AreaIndex = 2;
            this.v2TargetAmount.Caption = "Amount - Target";
            this.v2TargetAmount.Name = "v2TargetAmount";
            this.v2TargetAmount.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Custom;
            this.v2TargetAmount.UnboundFieldName = "pv2TargetAmount";
            this.v2TargetAmount.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            // 
            // TargetPercent
            // 
            this.TargetPercent.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.TargetPercent.AreaIndex = 2;
            this.TargetPercent.Caption = "% of Target";
            this.TargetPercent.CellFormat.FormatString = "p";
            this.TargetPercent.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.TargetPercent.Name = "TargetPercent";
            this.TargetPercent.SummaryDisplayType = DevExpress.Data.PivotGrid.PivotSummaryDisplayType.PercentVariation;
            this.TargetPercent.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Custom;
            this.TargetPercent.TotalCellFormat.FormatString = "p";
            this.TargetPercent.TotalCellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.TargetPercent.TotalValueFormat.FormatString = "p";
            this.TargetPercent.TotalValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.TargetPercent.ValueFormat.FormatString = "p";
            this.TargetPercent.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.TargetPercent.Visible = false;
            // 
            // DayMonthEnd
            // 
            this.DayMonthEnd.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.DayMonthEnd.AreaIndex = 3;
            this.DayMonthEnd.Caption = "Days To Month End";
            this.DayMonthEnd.Name = "DayMonthEnd";
            this.DayMonthEnd.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Min;
            // 
            // DayAvg
            // 
            this.DayAvg.Appearance.ValueTotal.ForeColor = System.Drawing.Color.Black;
            this.DayAvg.Appearance.ValueTotal.Options.UseForeColor = true;
            this.DayAvg.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.DayAvg.AreaIndex = 4;
            this.DayAvg.Caption = "Daily Average";
            this.DayAvg.Name = "DayAvg";
            this.DayAvg.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Custom;
            this.DayAvg.TotalCellFormat.FormatString = "f2";
            this.DayAvg.TotalCellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.DayAvg.TotalValueFormat.FormatString = "f2";
            this.DayAvg.TotalValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.DayAvg.UnboundFieldName = "DailyAvg";
            this.DayAvg.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.DayAvg.ValueFormat.FormatString = "f2";
            this.DayAvg.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            // 
            // pivotGridField14
            // 
            this.pivotGridField14.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField14.AreaIndex = 0;
            this.pivotGridField14.Caption = "Month";
            this.pivotGridField14.FieldName = "dtMonth";
            this.pivotGridField14.Name = "pivotGridField14";
            this.pivotGridField14.Options.AllowDrag = DevExpress.Utils.DefaultBoolean.False;
            this.pivotGridField14.Options.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.pivotGridField14.Width = 80;
            // 
            // colTest
            // 
            this.colTest.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.colTest.AreaIndex = 1;
            this.colTest.Caption = "% of Target";
            this.colTest.CellFormat.FormatString = "P";
            this.colTest.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTest.Name = "colTest";
            this.colTest.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Custom;
            // 
            // label63
            // 
            this.label63.BackColor = System.Drawing.Color.Transparent;
            this.label63.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label63.Location = new System.Drawing.Point(547, 10);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(56, 16);
            this.label63.TabIndex = 36;
            this.label63.Text = "Category";
            // 
            // cmbCategory
            // 
            this.cmbCategory.EditValue = "cbGIROStatus";
            this.cmbCategory.Location = new System.Drawing.Point(608, 8);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbCategory.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cmbCategory.Size = new System.Drawing.Size(200, 20);
            this.cmbCategory.TabIndex = 35;
            this.cmbCategory.SelectedValueChanged += new System.EventHandler(this.cmbCategory_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 253);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 16);
            this.label2.TabIndex = 38;
            this.label2.Text = "Current Month Sales";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            // 
            // PRINT1
            // 
            this.PRINT1.EditValue = "PRINT";
            this.PRINT1.Location = new System.Drawing.Point(168, 432);
            this.PRINT1.Name = "PRINT1";
            this.PRINT1.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.PRINT1.Properties.Appearance.Options.UseBackColor = true;
            this.PRINT1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.PRINT1.Size = new System.Drawing.Size(40, 18);
            this.PRINT1.TabIndex = 139;
            this.PRINT1.OpenLink += new DevExpress.XtraEditors.Controls.OpenLinkEventHandler(this.PRINT1_OpenLink);
            // 
            // printingSystem1
            // 
            this.printingSystem1.Links.AddRange(new object[] {
            this.printableComponentLink1,
            this.printableComponentLink2,
            this.printableComponentLink3,
            this.printableComponentLink4});
            // 
            // printableComponentLink1
            // 
            this.printableComponentLink1.Component = this.CurrentGridIncomeAnalysis;
            this.printableComponentLink1.CustomPaperSize = new System.Drawing.Size(0, 0);
            this.printableComponentLink1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("printableComponentLink1.ImageStream")));
            this.printableComponentLink1.Landscape = true;
            this.printableComponentLink1.Margins = new System.Drawing.Printing.Margins(50, 50, 50, 50);
            this.printableComponentLink1.PageHeaderFooter = new DevExpress.XtraPrinting.PageHeaderFooter(new DevExpress.XtraPrinting.PageHeaderArea(new string[] {
                "\r\nCurrent Month Sales Report",
                "Income Analysis Report",
                "[Date Printed][Time Printed]"}, new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))), DevExpress.XtraPrinting.BrickAlignment.Near), new DevExpress.XtraPrinting.PageFooterArea(new string[] {
                "",
                "",
                "[Page # of Pages #]"}, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134))), DevExpress.XtraPrinting.BrickAlignment.Near));
            this.printableComponentLink1.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.printableComponentLink1.PrintingSystem = this.printingSystem1;
            this.printableComponentLink1.VerticalContentSplitting = DevExpress.XtraPrinting.VerticalContentSplitting.Smart;
            // 
            // printableComponentLink2
            // 
            this.printableComponentLink2.CustomPaperSize = new System.Drawing.Size(0, 0);
            this.printableComponentLink2.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("printableComponentLink2.ImageStream")));
            this.printableComponentLink2.Landscape = true;
            this.printableComponentLink2.Margins = new System.Drawing.Printing.Margins(50, 50, 50, 50);
            this.printableComponentLink2.PageHeaderFooter = new DevExpress.XtraPrinting.PageHeaderFooter(new DevExpress.XtraPrinting.PageHeaderArea(new string[] {
                "Previus Two Month Sales Report",
                "",
                "[Date Printed][Time Printed]"}, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134))), DevExpress.XtraPrinting.BrickAlignment.Near), new DevExpress.XtraPrinting.PageFooterArea(new string[] {
                "",
                "",
                "[Page # of Pages #]"}, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134))), DevExpress.XtraPrinting.BrickAlignment.Near));
            this.printableComponentLink2.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.printableComponentLink2.PrintingSystem = this.printingSystem1;
            this.printableComponentLink2.VerticalContentSplitting = DevExpress.XtraPrinting.VerticalContentSplitting.Smart;
            // 
            // printableComponentLink3
            // 
            this.printableComponentLink3.CustomPaperSize = new System.Drawing.Size(0, 0);
            this.printableComponentLink3.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("printableComponentLink3.ImageStream")));
            this.printableComponentLink3.Landscape = true;
            this.printableComponentLink3.Margins = new System.Drawing.Printing.Margins(50, 50, 50, 50);
            this.printableComponentLink3.PageHeaderFooter = new DevExpress.XtraPrinting.PageHeaderFooter(new DevExpress.XtraPrinting.PageHeaderArea(new string[] {
                "Previous 10 Days Sales Report",
                "",
                "[Date Printed][Time Printed]"}, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134))), DevExpress.XtraPrinting.BrickAlignment.Near), new DevExpress.XtraPrinting.PageFooterArea(new string[] {
                "",
                "",
                "[Page # of Pages #]"}, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134))), DevExpress.XtraPrinting.BrickAlignment.Near));
            this.printableComponentLink3.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.printableComponentLink3.PrintingSystem = this.printingSystem1;
            this.printableComponentLink3.VerticalContentSplitting = DevExpress.XtraPrinting.VerticalContentSplitting.Smart;
            // 
            // printableComponentLink4
            // 
            this.printableComponentLink4.CustomPaperSize = new System.Drawing.Size(0, 0);
            this.printableComponentLink4.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("printableComponentLink4.ImageStream")));
            this.printableComponentLink4.Landscape = true;
            this.printableComponentLink4.Margins = new System.Drawing.Printing.Margins(50, 50, 50, 50);
            this.printableComponentLink4.PageHeaderFooter = new DevExpress.XtraPrinting.PageHeaderFooter(new DevExpress.XtraPrinting.PageHeaderArea(new string[] {
                "Previous 10 Days Sales Report",
                "",
                "[Date Printed][Time Printed]"}, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134))), DevExpress.XtraPrinting.BrickAlignment.Near), new DevExpress.XtraPrinting.PageFooterArea(new string[] {
                "",
                "",
                "[Page # of Pages #]"}, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134))), DevExpress.XtraPrinting.BrickAlignment.Near));
            this.printableComponentLink4.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.printableComponentLink4.PrintingSystem = this.printingSystem1;
            this.printableComponentLink4.VerticalContentSplitting = DevExpress.XtraPrinting.VerticalContentSplitting.Smart;
            // 
            // hyperLinkEdit1
            // 
            this.hyperLinkEdit1.EditValue = "PRINT";
            this.hyperLinkEdit1.Location = new System.Drawing.Point(120, 253);
            this.hyperLinkEdit1.Name = "hyperLinkEdit1";
            this.hyperLinkEdit1.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.hyperLinkEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.hyperLinkEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.hyperLinkEdit1.Size = new System.Drawing.Size(40, 18);
            this.hyperLinkEdit1.TabIndex = 140;
            this.hyperLinkEdit1.OpenLink += new DevExpress.XtraEditors.Controls.OpenLinkEventHandler(this.hyperLinkEdit1_OpenLink);
            // 
            // PrevGridIncomeAnalysis
            // 
            this.PrevGridIncomeAnalysis.AppearancePrint.Cell.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrevGridIncomeAnalysis.AppearancePrint.Cell.Options.UseFont = true;
            this.PrevGridIncomeAnalysis.AppearancePrint.CustomTotalCell.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrevGridIncomeAnalysis.AppearancePrint.CustomTotalCell.Options.UseFont = true;
            this.PrevGridIncomeAnalysis.AppearancePrint.FieldValue.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrevGridIncomeAnalysis.AppearancePrint.FieldValue.Options.UseFont = true;
            this.PrevGridIncomeAnalysis.AppearancePrint.FieldValueGrandTotal.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrevGridIncomeAnalysis.AppearancePrint.FieldValueGrandTotal.Options.UseFont = true;
            this.PrevGridIncomeAnalysis.AppearancePrint.FieldValueTotal.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrevGridIncomeAnalysis.AppearancePrint.FieldValueTotal.Options.UseFont = true;
            this.PrevGridIncomeAnalysis.AppearancePrint.FilterSeparator.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrevGridIncomeAnalysis.AppearancePrint.FilterSeparator.Options.UseFont = true;
            this.PrevGridIncomeAnalysis.AppearancePrint.GrandTotalCell.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrevGridIncomeAnalysis.AppearancePrint.GrandTotalCell.Options.UseFont = true;
            this.PrevGridIncomeAnalysis.AppearancePrint.Lines.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrevGridIncomeAnalysis.AppearancePrint.Lines.Options.UseFont = true;
            this.PrevGridIncomeAnalysis.AppearancePrint.TotalCell.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrevGridIncomeAnalysis.AppearancePrint.TotalCell.Options.UseFont = true;
            this.PrevGridIncomeAnalysis.Cursor = System.Windows.Forms.Cursors.Default;
            this.PrevGridIncomeAnalysis.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.pivotGridField1,
            this.pivotGridField3,
            this.pivotGridField4,
            this.vTargetAmt,
            this.TargetAmt,
            this.pivotGridField13,
            this.TestTargetAmt});
            this.PrevGridIncomeAnalysis.Groups.AddRange(new DevExpress.XtraPivotGrid.PivotGridGroup[] {
            pivotGridGroup2});
            this.PrevGridIncomeAnalysis.Location = new System.Drawing.Point(-8, 450);
            this.PrevGridIncomeAnalysis.Name = "PrevGridIncomeAnalysis";
            this.PrevGridIncomeAnalysis.OptionsBehavior.ApplyBestFitOnFieldDragging = true;
            this.PrevGridIncomeAnalysis.OptionsCustomization.AllowDrag = false;
            this.PrevGridIncomeAnalysis.OptionsCustomization.AllowExpand = false;
            this.PrevGridIncomeAnalysis.OptionsCustomization.AllowHideFields = DevExpress.XtraPivotGrid.AllowHideFieldsType.Never;
            this.PrevGridIncomeAnalysis.OptionsCustomization.AllowSort = false;
            this.PrevGridIncomeAnalysis.OptionsDataField.Area = DevExpress.XtraPivotGrid.PivotDataArea.RowArea;
            this.PrevGridIncomeAnalysis.OptionsDataField.AreaIndex = 1;
            this.PrevGridIncomeAnalysis.OptionsPrint.PrintDataHeaders = DevExpress.Utils.DefaultBoolean.False;
            this.PrevGridIncomeAnalysis.OptionsPrint.PrintFilterHeaders = DevExpress.Utils.DefaultBoolean.False;
            this.PrevGridIncomeAnalysis.OptionsPrint.UsePrintAppearance = true;
            this.PrevGridIncomeAnalysis.OptionsView.ShowDataHeaders = false;
            this.PrevGridIncomeAnalysis.OptionsView.ShowFilterHeaders = false;
            this.PrevGridIncomeAnalysis.OptionsView.ShowFilterSeparatorBar = false;
            this.PrevGridIncomeAnalysis.OptionsView.ShowRowGrandTotals = false;
            this.PrevGridIncomeAnalysis.Size = new System.Drawing.Size(960, 176);
            this.PrevGridIncomeAnalysis.TabIndex = 142;
            // 
            // pivotGridField1
            // 
            this.pivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pivotGridField1.AreaIndex = 0;
            this.pivotGridField1.Caption = "Branch Sales";
            this.pivotGridField1.ExpandedInFieldsGroup = false;
            this.pivotGridField1.FieldName = "mNettAmount";
            this.pivotGridField1.MinWidth = 80;
            this.pivotGridField1.Name = "pivotGridField1";
            this.pivotGridField1.Options.AllowDrag = DevExpress.Utils.DefaultBoolean.False;
            this.pivotGridField1.Options.AllowExpand = DevExpress.Utils.DefaultBoolean.True;
            this.pivotGridField1.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.False;
            this.pivotGridField1.Options.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.pivotGridField1.TotalCellFormat.FormatString = "f2";
            this.pivotGridField1.TotalCellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridField1.TotalValueFormat.FormatString = "f2";
            this.pivotGridField1.TotalValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridField1.ValueFormat.FormatString = "f2";
            this.pivotGridField1.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridField1.Width = 80;
            // 
            // pivotGridField3
            // 
            this.pivotGridField3.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.pivotGridField3.AreaIndex = 0;
            this.pivotGridField3.Caption = "Branch";
            this.pivotGridField3.FieldName = "strBranchCode";
            this.pivotGridField3.MinWidth = 10;
            this.pivotGridField3.Name = "pivotGridField3";
            this.pivotGridField3.Options.AllowDrag = DevExpress.Utils.DefaultBoolean.False;
            this.pivotGridField3.Options.AllowExpand = DevExpress.Utils.DefaultBoolean.True;
            this.pivotGridField3.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.False;
            this.pivotGridField3.Options.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.pivotGridField3.Width = 80;
            // 
            // pivotGridField4
            // 
            this.pivotGridField4.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pivotGridField4.AreaIndex = 1;
            this.pivotGridField4.FieldName = "mTotalAmount";
            this.pivotGridField4.Name = "pivotGridField4";
            this.pivotGridField4.Options.AllowDrag = DevExpress.Utils.DefaultBoolean.False;
            this.pivotGridField4.Options.AllowExpand = DevExpress.Utils.DefaultBoolean.False;
            this.pivotGridField4.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.False;
            this.pivotGridField4.Options.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.pivotGridField4.TotalCellFormat.FormatString = "f2";
            this.pivotGridField4.TotalCellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridField4.TotalValueFormat.FormatString = "f2";
            this.pivotGridField4.TotalValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridField4.ValueFormat.FormatString = "f2";
            this.pivotGridField4.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridField4.Visible = false;
            this.pivotGridField4.Width = 80;
            // 
            // vTargetAmt
            // 
            this.vTargetAmt.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.vTargetAmt.AreaIndex = 1;
            this.vTargetAmt.Caption = "Target Amount";
            this.vTargetAmt.Name = "vTargetAmt";
            this.vTargetAmt.Options.AllowDrag = DevExpress.Utils.DefaultBoolean.False;
            this.vTargetAmt.Options.AllowExpand = DevExpress.Utils.DefaultBoolean.False;
            this.vTargetAmt.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.False;
            this.vTargetAmt.Options.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.vTargetAmt.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Custom;
            this.vTargetAmt.TotalCellFormat.FormatString = "f2";
            this.vTargetAmt.TotalCellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.vTargetAmt.TotalValueFormat.FormatString = "f2";
            this.vTargetAmt.TotalValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.vTargetAmt.UnboundFieldName = "gvTargetAmt";
            this.vTargetAmt.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.vTargetAmt.ValueFormat.FormatString = "f2";
            this.vTargetAmt.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            // 
            // TargetAmt
            // 
            this.TargetAmt.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.TargetAmt.AreaIndex = 2;
            this.TargetAmt.Caption = "Amount > Target";
            this.TargetAmt.Name = "TargetAmt";
            this.TargetAmt.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Custom;
            this.TargetAmt.TotalValueFormat.FormatString = "f2";
            this.TargetAmt.TotalValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.TargetAmt.UnboundFieldName = "TargetAmount";
            this.TargetAmt.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.TargetAmt.ValueFormat.FormatString = "f2";
            this.TargetAmt.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.TargetAmt.Width = 90;
            // 
            // pivotGridField13
            // 
            this.pivotGridField13.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField13.AreaIndex = 0;
            this.pivotGridField13.Caption = "Month";
            this.pivotGridField13.FieldName = "dtMonth";
            this.pivotGridField13.Name = "pivotGridField13";
            this.pivotGridField13.Options.AllowDrag = DevExpress.Utils.DefaultBoolean.False;
            this.pivotGridField13.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.False;
            this.pivotGridField13.Width = 80;
            // 
            // TestTargetAmt
            // 
            this.TestTargetAmt.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.TestTargetAmt.AreaIndex = 1;
            this.TestTargetAmt.FieldName = "TargetAmount";
            this.TestTargetAmt.Name = "TestTargetAmt";
            this.TestTargetAmt.Visible = false;
            this.TestTargetAmt.Width = 90;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(-1, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 16);
            this.label3.TabIndex = 143;
            this.label3.Text = "Previous 10  Days Sales";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 432);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 144;
            this.label1.Text = "Selected Month:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // hyperLinkEdit2
            // 
            this.hyperLinkEdit2.EditValue = "PRINT";
            this.hyperLinkEdit2.Location = new System.Drawing.Point(199, 8);
            this.hyperLinkEdit2.Name = "hyperLinkEdit2";
            this.hyperLinkEdit2.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.hyperLinkEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.hyperLinkEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.hyperLinkEdit2.Size = new System.Drawing.Size(40, 18);
            this.hyperLinkEdit2.TabIndex = 147;
            // 
            // btn_Add
            // 
            this.btn_Add.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Add.Appearance.Options.UseFont = true;
            this.btn_Add.Appearance.Options.UseTextOptions = true;
            this.btn_Add.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btn_Add.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.btn_Add.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btn_Add.ImageIndex = 0;
            this.btn_Add.ImageList = this.imageList1;
            this.btn_Add.ImeMode = System.Windows.Forms.ImeMode.On;
            this.btn_Add.Location = new System.Drawing.Point(135, 8);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(32, 16);
            this.btn_Add.TabIndex = 146;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Del
            // 
            this.btn_Del.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Del.Appearance.Options.UseFont = true;
            this.btn_Del.Appearance.Options.UseTextOptions = true;
            this.btn_Del.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btn_Del.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.btn_Del.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btn_Del.ImageIndex = 1;
            this.btn_Del.ImageList = this.imageList1;
            this.btn_Del.Location = new System.Drawing.Point(168, 8);
            this.btn_Del.Name = "btn_Del";
            this.btn_Del.Size = new System.Drawing.Size(24, 16);
            this.btn_Del.TabIndex = 145;
            this.btn_Del.Click += new System.EventHandler(this.btn_Del_Click);
            // 
            // pvGrandTotal10Days
            // 
            this.pvGrandTotal10Days.Cursor = System.Windows.Forms.Cursors.Default;
            this.pvGrandTotal10Days.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.pivotGridField16,
            this.pivotGridField17});
            this.pvGrandTotal10Days.Groups.AddRange(new DevExpress.XtraPivotGrid.PivotGridGroup[] {
            pivotGridGroup3});
            this.pvGrandTotal10Days.Location = new System.Drawing.Point(0, 32);
            this.pvGrandTotal10Days.Name = "pvGrandTotal10Days";
            this.pvGrandTotal10Days.OptionsCustomization.AllowDrag = false;
            this.pvGrandTotal10Days.OptionsCustomization.AllowExpand = false;
            this.pvGrandTotal10Days.OptionsCustomization.AllowSort = false;
            this.pvGrandTotal10Days.OptionsDataField.Area = DevExpress.XtraPivotGrid.PivotDataArea.RowArea;
            this.pvGrandTotal10Days.OptionsDataField.AreaIndex = 1;
            this.pvGrandTotal10Days.OptionsView.ShowDataHeaders = false;
            this.pvGrandTotal10Days.OptionsView.ShowFilterHeaders = false;
            this.pvGrandTotal10Days.OptionsView.ShowRowGrandTotals = false;
            this.pvGrandTotal10Days.Size = new System.Drawing.Size(960, 200);
            this.pvGrandTotal10Days.TabIndex = 150;
            // 
            // pivotGridField16
            // 
            this.pivotGridField16.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pivotGridField16.AreaIndex = 0;
            this.pivotGridField16.Caption = "Nett Amount";
            this.pivotGridField16.FieldName = "mNettAmount";
            this.pivotGridField16.Name = "pivotGridField16";
            // 
            // pivotGridField17
            // 
            this.pivotGridField17.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.pivotGridField17.AreaIndex = 0;
            this.pivotGridField17.Caption = "Branch";
            this.pivotGridField17.FieldName = "strBranchCode";
            this.pivotGridField17.Name = "pivotGridField17";
            this.pivotGridField17.Options.AllowDrag = DevExpress.Utils.DefaultBoolean.False;
            this.pivotGridField17.Options.AllowExpand = DevExpress.Utils.DefaultBoolean.False;
            this.pivotGridField17.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.False;
            this.pivotGridField17.Options.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // ThirdGridIncomeAnalysis
            // 
            this.ThirdGridIncomeAnalysis.Cursor = System.Windows.Forms.Cursors.Default;
            this.ThirdGridIncomeAnalysis.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.pivotGridField11,
            this.pivotGridField12,
            this.pivotGridField9});
            this.ThirdGridIncomeAnalysis.Groups.AddRange(new DevExpress.XtraPivotGrid.PivotGridGroup[] {
            pivotGridGroup4});
            this.ThirdGridIncomeAnalysis.Location = new System.Drawing.Point(0, 27);
            this.ThirdGridIncomeAnalysis.Name = "ThirdGridIncomeAnalysis";
            this.ThirdGridIncomeAnalysis.OptionsCustomization.AllowDrag = false;
            this.ThirdGridIncomeAnalysis.OptionsCustomization.AllowExpand = false;
            this.ThirdGridIncomeAnalysis.OptionsCustomization.AllowSort = false;
            this.ThirdGridIncomeAnalysis.OptionsDataField.Area = DevExpress.XtraPivotGrid.PivotDataArea.RowArea;
            this.ThirdGridIncomeAnalysis.OptionsDataField.AreaIndex = 1;
            this.ThirdGridIncomeAnalysis.OptionsView.ShowDataHeaders = false;
            this.ThirdGridIncomeAnalysis.OptionsView.ShowFilterHeaders = false;
            this.ThirdGridIncomeAnalysis.OptionsView.ShowRowGrandTotals = false;
            this.ThirdGridIncomeAnalysis.Size = new System.Drawing.Size(960, 224);
            this.ThirdGridIncomeAnalysis.TabIndex = 151;
            // 
            // pivotGridField11
            // 
            this.pivotGridField11.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pivotGridField11.AreaIndex = 0;
            this.pivotGridField11.Caption = "Nett Amount";
            this.pivotGridField11.FieldName = "mNettAmount";
            this.pivotGridField11.Name = "pivotGridField11";
            this.pivotGridField11.Width = 90;
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
            this.pivotGridField12.Width = 90;
            // 
            // pivotGridField9
            // 
            this.pivotGridField9.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField9.AreaIndex = 0;
            this.pivotGridField9.Caption = "Date";
            this.pivotGridField9.FieldName = "dtDate";
            this.pivotGridField9.Name = "pivotGridField9";
            this.pivotGridField9.Options.AllowDrag = DevExpress.Utils.DefaultBoolean.False;
            this.pivotGridField9.Options.AllowExpand = DevExpress.Utils.DefaultBoolean.False;
            this.pivotGridField9.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.False;
            this.pivotGridField9.Options.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.pivotGridField9.ValueFormat.FormatString = "d";
            this.pivotGridField9.ValueFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.pivotGridField9.Width = 80;
            // 
            // cmbMonth
            // 
            this.cmbMonth.Items.AddRange(new object[] {
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
            this.cmbMonth.Location = new System.Drawing.Point(440, 5);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(104, 21);
            this.cmbMonth.TabIndex = 152;
            this.cmbMonth.Text = "-Select Month-";
            this.cmbMonth.SelectedIndexChanged += new System.EventHandler(this.cmbMonth_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(392, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 153;
            this.label4.Text = "Month";
            // 
            // RPIncomeAnalysis
            // 
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(994, 688);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbMonth);
            this.Controls.Add(this.hyperLinkEdit2);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.btn_Del);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PrevGridIncomeAnalysis);
            this.Controls.Add(this.hyperLinkEdit1);
            this.Controls.Add(this.PRINT1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label63);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.CurrentGridIncomeAnalysis);
            this.Controls.Add(this.ThirdGridIncomeAnalysis);
            this.Controls.Add(this.pvGrandTotal10Days);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RPIncomeAnalysis";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 50);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Income Analysis Report";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ShowReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CurrentGridIncomeAnalysis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PRINT1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrevGridIncomeAnalysis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pvGrandTotal10Days)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThirdGridIncomeAnalysis)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region Initialize Data from Login
		public void initData (ACMSLogic.User User)
		{
			oUser = User;
			MemberRecord myMemberRecord = new MemberRecord(oUser.StrBranchCode());
		}

		public void SetEmployeeRecord(Do.Employee employee)
		{
			this.employee = employee;
		}

		public void SetTerminalUser(Do.TerminalUser terminalUser)
		{
			this.terminalUser = terminalUser;
		}

		#endregion

		private void ShowReport_Load(object sender, System.EventArgs e)
		{
			pvGrandTotal10Days.Hide();
			isFinishBindInit = false;
			BindCategory();
			isFinishBindInit = true;
			BindReport();
		}
	
		private void BindReport()
		{
			if (!isFinishBindInit)
				return;

			if (cmbCategory.EditValue == null)
			{
				PrevGridIncomeAnalysis.DataSource = null;
				CurrentGridIncomeAnalysis.DataSource = null;
				ThirdGridIncomeAnalysis.DataSource = null;
				return;
			}
			//if (cmbCategory.EditValue.ToString() == "999")
			//{
				// current month sales
				SqlCommand myCmd1 = new SqlCommand("up_get_AnalysisAmtCurrMonth", connection);
				myCmd1.CommandType = CommandType.StoredProcedure;
				myCmd1.Parameters.Add("@empID", EmployeeID);
				myCmd1.Parameters.Add("@nSalesCategoryID", Convert.ToInt32(cmbCategory.EditValue));
				SqlDataAdapter CurrentMonthSalesDA = new SqlDataAdapter(myCmd1); 
				_ds = new DataSet();
				CurrentMonthSalesDA.Fill(_ds, "Sales2"); 
				dtCurrentMonthSales = _ds.Tables["Sales2"];
				//dtCurrentMonthSales.Select( "nReportGroupID='" + cmbCategory.EditValue.ToString() + "'");
				try
				{
					CurrentGridIncomeAnalysis.DataSource = dtCurrentMonthSales;
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
				// first previous two month sales

			SqlCommand myCmd = new SqlCommand("up_get_AnalysisAmtPrevTwoMonths", connection);
			myCmd.CommandType = CommandType.StoredProcedure;
			myCmd.Parameters.Add("@empID", EmployeeID);
			myCmd.Parameters.Add("@nSalesCategoryID", Convert.ToInt32(cmbCategory.EditValue));
			myCmd.Parameters.Add("@nMonth", Convert.ToInt32(DateTime.Now.Month));
			SqlDataAdapter PrevTwoSalesDA = new SqlDataAdapter(myCmd); 
			_ds = new DataSet();
			PrevTwoSalesDA.Fill(_ds, "Sales1"); 
			dtPrevTwoSales = _ds.Tables["Sales1"];
			PrevGridIncomeAnalysis.DataSource = dtPrevTwoSales;


				// previous 10 days sales
				SqlCommand myCmd2 = new SqlCommand("up_get_AnalysisAmtPrev10Days", connection);
				myCmd2.CommandType = CommandType.StoredProcedure;
				myCmd2.Parameters.Add("@empID", EmployeeID);
				myCmd2.Parameters.Add("@nSalesCategoryID", Convert.ToInt32(cmbCategory.EditValue));
				SqlDataAdapter PrevTenDaysSalesDA = new SqlDataAdapter(myCmd2); 
				_ds = new DataSet();
				PrevTenDaysSalesDA.Fill(_ds, "Sales2"); 
				dtPrevTenDaysSales = _ds.Tables["Sales2"];
				ThirdGridIncomeAnalysis.DataSource = dtPrevTenDaysSales;
				pvGrandTotal10Days.DataSource = dtPrevTenDaysSales;
			//}
//			else
//			{
//				dvCurrentMonthSales = new DataView(dtCurrentMonthSales);
//				dvPrevTwoSales = new DataView(dtPrevTwoSales);
//				dvPrevTenDaysSales = new DataView(dtPrevTenDaysSales);
//
//				dvCurrentMonthSales.RowFilter = "nSalesCategoryID='" + cmbCategory.EditValue.ToString() + "'";
//				dvPrevTwoSales.RowFilter = "nSalesCategoryID='" + cmbCategory.EditValue.ToString() + "'";
//				dvPrevTenDaysSales.RowFilter = "nSalesCategoryID='" + cmbCategory.EditValue.ToString() + "'";
//
//				CurrentGridIncomeAnalysis.DataSource = dvCurrentMonthSales;
//				PrevGridIncomeAnalysis.DataSource = dvPrevTwoSales;
//				ThirdGridIncomeAnalysis.DataSource = dvPrevTenDaysSales;
//				pvGrandTotal10Days.DataSource = dvPrevTenDaysSales;
//			}

		}
	
		private void cmbCategory_SelectedValueChanged(object sender, System.EventArgs e)
		{
			BindReport();
		}

		private void BindCategory()
		{
			bool ViewAll = false;
			isFinishBindInit = false;
			string strSQL = ""; 
			
			if(employee.HasRight("AM_VIEW_INCOME_ANALYSIS_VIEW_ALL_REPORT"))
			{
				strSQL = "up_get_CategoryFilter";
				//ViewAll = true;
			}
			else
			{
				strSQL = "up_get_CategoryByRight " + oUser.NEmployeeID();
				//ViewAll = true;
			}
			comboBind(cmbCategory, strSQL, "strDescription", "nReportGroupID", true);

			if (ViewAll == true)
				cmbCategory.Properties.Items.Insert(0,new DevExpress.XtraEditors.Controls.ImageComboBoxItem("- View All -",999,-1));

			cmbCategory.SelectedIndex = 0;
			isFinishBindInit = true;

		}

		private void comboBind(DevExpress.XtraEditors.ImageComboBoxEdit control,string strSQL,string display,string strValue,bool fNum)
		{
		

			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox properties = control.Properties;
			properties.Items.BeginUpdate();
			properties.Items.Clear();

			try 
			{
				foreach(DataRow dr in _ds.Tables["Table"].Rows)
				{
					//Initialize each item with the display text, value and image index
					properties.Items.Add( new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr[display].ToString(), dr[strValue],-1));
				}
			}
			finally 
			{
				properties.Items.EndUpdate();
			}
			//Select the first item
			control.SelectedIndex = 0;
		}

		private void CurrentGridIncomeAnalysis_CustomSummary(object sender, DevExpress.XtraPivotGrid.PivotGridCustomSummaryEventArgs e)
		{
			
			if (e.DataField != colTest && e.DataField != v2TargetAmount && e.DataField != DayAvg) return;
		
			
			decimal TotalAmount = 0;
			decimal txtTargetAmount = 0;
			int daysMonthEnd = 0;
			// Get the record set corresponding to the current cell.
			PivotDrillDownDataSource ds = e.CreateDrillDownDataSource();
			// Iterate through the records and count the orders.

			for(int i = 0; i < ds.RowCount; i++) 
			{
				PivotDrillDownDataRow row = ds[i];
				// Get the order's total sum.

				if (row["TargetAmount"] == null)
					txtTargetAmount = 0;
				else
					txtTargetAmount = (decimal)row["TargetAmount"];

				daysMonthEnd = (int)row["DaysMonthEnd"];

				TotalAmount += (decimal)row["mNettAmount"];
		
			}
	
			if(ds.RowCount > 0) 
			{
				if(e.DataField == v2TargetAmount) 
				{
					e.CustomValue = txtTargetAmount - TotalAmount;
				}
				else if (e.DataField == DayAvg)
				{
					if (daysMonthEnd == 0)
						e.CustomValue = 0;
					else
						e.CustomValue = (txtTargetAmount - TotalAmount)/daysMonthEnd;
				}
				else
				{
					if (txtTargetAmount == 0)
						e.CustomValue = 1;
					else
						e.CustomValue = TotalAmount/txtTargetAmount;
				}
			}
		}

		private void btn_Add_Click(object sender, System.EventArgs e)
		{
			ThirdGridIncomeAnalysis.Show();
			pvGrandTotal10Days.Hide();
		}

		private void btn_Del_Click(object sender, System.EventArgs e)
		{
			pvGrandTotal10Days.Show();
			ThirdGridIncomeAnalysis.Hide();
		}

		private void PrevGridIncomeAnalysis_CustomSummary(object sender, DevExpress.XtraPivotGrid.PivotGridCustomSummaryEventArgs e)
		{
			if (e.DataField != vTargetAmt && e.DataField != TargetAmt) return;
				
			decimal TotalAmount = 0;
			decimal txtTargetAmount = 0;
			// Get the record set corresponding to the current cell.
			PivotDrillDownDataSource ds = e.CreateDrillDownDataSource();
			// Iterate through the records and count the orders.
			for(int i = 0; i < ds.RowCount; i++) 
			{
				PivotDrillDownDataRow row = ds[i];
		
				if (row["TargetAmount"] == null)
					txtTargetAmount = 0;
				else
					txtTargetAmount = (decimal)row["TargetAmount"];

				TotalAmount += (decimal)row["mNettAmount"];
			}

			if(e.DataField == TargetAmt) 
			{
				e.CustomValue = txtTargetAmount - TotalAmount;
			}
			else
			{
				e.CustomValue = txtTargetAmount;
			}



		}

		private void PRINT1_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
		{
			printableComponentLink2.CreateDocument();
            printableComponentLink2.PrintingSystem.PreviewFormEx.AutoScale = true;
			printableComponentLink2.PrintingSystem.Print();

		}

		private void hyperLinkEdit1_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
		{
			printableComponentLink1.CreateDocument();
            printableComponentLink1.PrintingSystem.PreviewFormEx.AutoScale = true;
			printableComponentLink1.PrintingSystem.Print();
		
		}

		private void hyperLinkEdit2_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
		{
			if ( !ThirdGridIncomeAnalysis.Visible )
			{
				printableComponentLink3.CreateDocument();
                printableComponentLink3.PrintingSystem.PreviewFormEx.AutoScale = true;
				printableComponentLink3.PrintingSystem.Print();
			}
			else
			{
				printableComponentLink4.CreateDocument();
                printableComponentLink4.PrintingSystem.PreviewFormEx.AutoScale = true;
				printableComponentLink4.PrintingSystem.Print();
			}
		}

		private void btn_Add_Click_1(object sender, System.EventArgs e)
		{
			ThirdGridIncomeAnalysis.Show();
			pvGrandTotal10Days.Hide();
		}

		private void CurrentGridIncomeAnalysis_Click(object sender, System.EventArgs e)
		{
		
		}

		private void cmbMonth_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SqlCommand myCmd = new SqlCommand("up_get_AnalysisAmtPrevTwoMonths", connection);
			myCmd.CommandType = CommandType.StoredProcedure;
			myCmd.Parameters.AddWithValue("@empID", EmployeeID);
            myCmd.Parameters.AddWithValue("@nSalesCategoryID", Convert.ToInt32(cmbCategory.EditValue));
            myCmd.Parameters.AddWithValue("@nMonth", Convert.ToInt32(cmbMonth.SelectedItem.ToString()));
			SqlDataAdapter PrevTwoSalesDA = new SqlDataAdapter(myCmd); 
			_ds = new DataSet();
			PrevTwoSalesDA.Fill(_ds, "Sales1"); 
			dtPrevTwoSales = _ds.Tables["Sales1"];
			PrevGridIncomeAnalysis.DataSource = dtPrevTwoSales;
		}

		private void label1_Click(object sender, System.EventArgs e)
		{
		
		}

	}
}









