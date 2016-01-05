using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.ApplicationBlocks.Data;
using ACMS.XtraUtils.LookupEditBuilder;
using System.Configuration;
using DevExpress.XtraPivotGrid;

namespace ACMS.ACMSManager.Reports
{
	/// <summary>
	/// Summary description for RPPromotionAnalysis.
	/// </summary>
	public class RPPromotionAnalysis : DevExpress.XtraEditors.XtraForm
	{
		private string connectionString;
		private SqlConnection connection;
		private DevExpress.XtraEditors.SimpleButton btnReset;
		private DevExpress.XtraEditors.SimpleButton sbtnReset;
		private DevExpress.XtraEditors.LookUpEdit lkBranch;
		private DevExpress.XtraEditors.LookUpEdit lkPromotion;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField1;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField2;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField5;
		private DevExpress.XtraPivotGrid.PivotGridControl gvPromotionAnalysis;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private DevExpress.XtraEditors.DateEdit DateFrom;
		private DevExpress.XtraEditors.DateEdit DateRangeTo;
		private int EmployeeID;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField6;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField3;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField4;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField7;
		private ACMS.Utils.Common myCommon;

		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public RPPromotionAnalysis(int empID)
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
			this.gvPromotionAnalysis = new DevExpress.XtraPivotGrid.PivotGridControl();
			this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField2 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField5 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField6 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField3 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField4 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField7 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.btnReset = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnReset = new DevExpress.XtraEditors.SimpleButton();
			this.lkBranch = new DevExpress.XtraEditors.LookUpEdit();
			this.lkPromotion = new DevExpress.XtraEditors.LookUpEdit();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.DateFrom = new DevExpress.XtraEditors.DateEdit();
			this.DateRangeTo = new DevExpress.XtraEditors.DateEdit();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.gvPromotionAnalysis)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkBranch.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkPromotion.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DateFrom.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DateRangeTo.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// gvPromotionAnalysis
			// 
			this.gvPromotionAnalysis.Cursor = System.Windows.Forms.Cursors.Default;
			this.gvPromotionAnalysis.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
																									   this.pivotGridField1,
																									   this.pivotGridField2,
																									   this.pivotGridField5,
																									   this.pivotGridField6,
																									   this.pivotGridField3,
																									   this.pivotGridField4,
																									   this.pivotGridField7});
			this.gvPromotionAnalysis.Location = new System.Drawing.Point(8, 40);
			this.gvPromotionAnalysis.Name = "gvPromotionAnalysis";
			this.gvPromotionAnalysis.OptionsCustomization.AllowDrag = false;
			this.gvPromotionAnalysis.OptionsCustomization.AllowFilter = false;
			this.gvPromotionAnalysis.OptionsCustomization.AllowSort = false;
			this.gvPromotionAnalysis.OptionsView.ShowDataHeaders = false;
			this.gvPromotionAnalysis.OptionsView.ShowFilterHeaders = false;
			this.gvPromotionAnalysis.Size = new System.Drawing.Size(960, 440);
			this.gvPromotionAnalysis.TabIndex = 0;
			this.gvPromotionAnalysis.CellDoubleClick += new DevExpress.XtraPivotGrid.PivotCellEventHandler(this.gvPromotionAnalysis_CellDoubleClick);
			// 
			// pivotGridField1
			// 
			this.pivotGridField1.Appearance.Header.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.pivotGridField1.Appearance.Header.Options.UseBackColor = true;
			this.pivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
			this.pivotGridField1.AreaIndex = 3;
			this.pivotGridField1.Caption = "Code";
			this.pivotGridField1.FieldName = "strPromotionCode";
			this.pivotGridField1.Name = "pivotGridField1";
			// 
			// pivotGridField2
			// 
			this.pivotGridField2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
			this.pivotGridField2.AreaIndex = 2;
			this.pivotGridField2.Caption = "Description";
			this.pivotGridField2.ExpandedInFieldsGroup = false;
			this.pivotGridField2.FieldName = "strDescription";
			this.pivotGridField2.Name = "pivotGridField2";
			this.pivotGridField2.Options.AllowExpand = DevExpress.Utils.DefaultBoolean.False;
			this.pivotGridField2.Width = 180;
			// 
			// pivotGridField5
			// 
			this.pivotGridField5.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
			this.pivotGridField5.AreaIndex = 0;
			this.pivotGridField5.Caption = "Branch Code";
			this.pivotGridField5.FieldName = "strBranchCode";
			this.pivotGridField5.Name = "pivotGridField5";
			this.pivotGridField5.Width = 70;
			// 
			// pivotGridField6
			// 
			this.pivotGridField6.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
			this.pivotGridField6.AreaIndex = 0;
			this.pivotGridField6.FieldName = "Amount";
			this.pivotGridField6.Name = "pivotGridField6";
			this.pivotGridField6.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
			// 
			// pivotGridField3
			// 
			this.pivotGridField3.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.RowArea;
			this.pivotGridField3.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
			this.pivotGridField3.AreaIndex = 4;
			this.pivotGridField3.CellFormat.FormatString = "{yyyy-MM-dd}";
			this.pivotGridField3.FieldName = "dtDate";
			this.pivotGridField3.GrandTotalText = "Date";
			this.pivotGridField3.Name = "pivotGridField3";
			this.pivotGridField3.Options.ShowInCustomizationForm = false;
			this.pivotGridField3.ValueFormat.FormatString = "MM/dd/yyyy";
			this.pivotGridField3.ValueFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.pivotGridField3.Width = 80;
			// 
			// pivotGridField4
			// 
			this.pivotGridField4.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
			this.pivotGridField4.AreaIndex = 0;
			this.pivotGridField4.Caption = "Valid Start";
			this.pivotGridField4.CellFormat.FormatString = "dd/MM/yyyy";
			this.pivotGridField4.CellFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.pivotGridField4.ExpandedInFieldsGroup = false;
			this.pivotGridField4.FieldName = "dtValidStart";
			this.pivotGridField4.Name = "pivotGridField4";
			this.pivotGridField4.Options.AllowExpand = DevExpress.Utils.DefaultBoolean.False;
			this.pivotGridField4.ValueFormat.FormatString = "MM/dd/yyyy";
			this.pivotGridField4.ValueFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.pivotGridField4.Width = 80;
			// 
			// pivotGridField7
			// 
			this.pivotGridField7.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
			this.pivotGridField7.AreaIndex = 1;
			this.pivotGridField7.Caption = "Valid End";
			this.pivotGridField7.CellFormat.FormatString = "d";
			this.pivotGridField7.CellFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.pivotGridField7.ExpandedInFieldsGroup = false;
			this.pivotGridField7.FieldName = "dtValidEnd";
			this.pivotGridField7.Name = "pivotGridField7";
			this.pivotGridField7.Options.AllowExpand = DevExpress.Utils.DefaultBoolean.False;
			this.pivotGridField7.ValueFormat.FormatString = "MM/dd/yyyy";
			this.pivotGridField7.ValueFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.pivotGridField7.Width = 80;
			// 
			// btnReset
			// 
			this.btnReset.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnReset.Appearance.Options.UseFont = true;
			this.btnReset.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnReset.Location = new System.Drawing.Point(752, 8);
			this.btnReset.LookAndFeel.UseDefaultLookAndFeel = false;
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(48, 16);
			this.btnReset.TabIndex = 198;
			this.btnReset.Text = "Reset";
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// sbtnReset
			// 
			this.sbtnReset.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.sbtnReset.Appearance.Options.UseFont = true;
			this.sbtnReset.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnReset.Location = new System.Drawing.Point(696, 8);
			this.sbtnReset.LookAndFeel.UseDefaultLookAndFeel = false;
			this.sbtnReset.Name = "sbtnReset";
			this.sbtnReset.Size = new System.Drawing.Size(48, 16);
			this.sbtnReset.TabIndex = 192;
			this.sbtnReset.Text = "Enquiry";
			this.sbtnReset.Click += new System.EventHandler(this.sbtnReset_Click);
			// 
			// lkBranch
			// 
			this.lkBranch.Location = new System.Drawing.Point(416, 8);
			this.lkBranch.Name = "lkBranch";
			// 
			// lkBranch.Properties
			// 
			this.lkBranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkBranch.Size = new System.Drawing.Size(96, 22);
			this.lkBranch.TabIndex = 191;
			// 
			// lkPromotion
			// 
			this.lkPromotion.Location = new System.Drawing.Point(592, 8);
			this.lkPromotion.Name = "lkPromotion";
			// 
			// lkPromotion.Properties
			// 
			this.lkPromotion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkPromotion.Size = new System.Drawing.Size(96, 22);
			this.lkPromotion.TabIndex = 190;
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label6.Location = new System.Drawing.Point(520, 8);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(72, 16);
			this.label6.TabIndex = 189;
			this.label6.Text = "Promotion Code";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.Location = new System.Drawing.Point(360, 8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(56, 16);
			this.label5.TabIndex = 188;
			this.label5.Text = "Branch";
			// 
			// DateFrom
			// 
			this.DateFrom.EditValue = null;
			this.DateFrom.Location = new System.Drawing.Point(88, 8);
			this.DateFrom.Name = "DateFrom";
			// 
			// DateFrom.Properties
			// 
			this.DateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.DateFrom.Size = new System.Drawing.Size(88, 22);
			this.DateFrom.TabIndex = 199;
			// 
			// DateRangeTo
			// 
			this.DateRangeTo.EditValue = null;
			this.DateRangeTo.Location = new System.Drawing.Point(248, 8);
			this.DateRangeTo.Name = "DateRangeTo";
			// 
			// DateRangeTo.Properties
			// 
			this.DateRangeTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.DateRangeTo.Size = new System.Drawing.Size(100, 22);
			this.DateRangeTo.TabIndex = 200;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 16);
			this.label1.TabIndex = 201;
			this.label1.Text = "Date From";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(184, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 16);
			this.label2.TabIndex = 202;
			this.label2.Text = "Date To";
			// 
			// RPPromotionAnalysis
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(984, 533);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.DateRangeTo);
			this.Controls.Add(this.DateFrom);
			this.Controls.Add(this.btnReset);
			this.Controls.Add(this.sbtnReset);
			this.Controls.Add(this.lkBranch);
			this.Controls.Add(this.lkPromotion);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.gvPromotionAnalysis);
			this.Name = "RPPromotionAnalysis";
			this.Text = "Promotion Analysis";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.RPPromotionAnalysis_Load);
			((System.ComponentModel.ISupportInitialize)(this.gvPromotionAnalysis)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkBranch.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkPromotion.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DateFrom.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DateRangeTo.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void RPPromotionAnalysis_Load(object sender, System.EventArgs e)
		{
			DateFrom.EditValue = string.Format("{0:dd/MM/yyyy}",Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year));

			DateRangeTo.EditValue = DateTime.Today;
			InitLoad();
			BindReport();
		}

		private void InitLoad()
		{
			DataSet _ds;
			DataTable dt; 
			myCommon = new ACMS.Utils.Common();

			dt = myCommon.ExecuteQuery("Select strBranchCode,strBranchName from tblBranch Where strBranchCode In (Select strBranchCode from tblemployeebranchrights Where nEmployeeId = " + EmployeeID + ")");
			new ManagerBranchCodeLookupEditBuilder(dt, this.lkBranch.Properties);

			_ds = new DataSet();
			string strSQL = "select strPromotionCode, strDescription from tblPromotion";
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dt = _ds.Tables["table"];

			DevExpress.XtraEditors.Controls.LookUpColumnInfo[] col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
			
			col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strPromotionCode","Promotion Code",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription","Description",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
		
			new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(this.lkPromotion.Properties,dt,col,"strDescription","strPromotionCode","Promotion Code");


		}

		private void BindReport()
		{
			string strSQL;
			DataSet _ds;

            // first previous two month sales
			strSQL = "Up_Get_PromotionAnalysis " + EmployeeID;
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			DataTable dt = _ds.Tables["table"];
			DataView dv = new DataView(dt);

			//dv.RowFilter = string.Format("dDate >= #{0}# And dtDate < #{1}#",string.Format("{0:dd/MM/yyyy}",Convert.ToDateTime(DateFrom.EditValue)),string.Format("{0:dd/MM/yyyy}",Convert.ToDateTime(DateRangeTo.EditValue)));
			string str = "";

			if (lkBranch.EditValue != null && lkBranch.EditValue.ToString() != "")
				str = " strBranchCode = '" + lkBranch.EditValue.ToString() + "' And ";

			if (lkPromotion.EditValue != null && lkPromotion.EditValue.ToString() != "")
				str += " Amount = '" + lkPromotion.EditValue.ToString() + "' And ";

			str += string.Format("(dtDate >= '{0}' And dtDate <= '{1}')",string.Format("{0:yyyy-MM-dd 00:00:00.000}",Convert.ToDateTime(DateFrom.EditValue)),string.Format("{0:yyyy-MM-dd 00:00:00.000}",Convert.ToDateTime(DateRangeTo.EditValue)));
		
			
			dv.RowFilter = str;
			
			

			gvPromotionAnalysis.DataSource = dv;
			gvPromotionAnalysis.Fields["strPromotionCode"].CollapseAll();


		}

		private void gvPromotionAnalysis_CellDoubleClick(object sender, DevExpress.XtraPivotGrid.PivotCellEventArgs e)
		{
			Form form = new Form();
			form.Text = "Records";
			// Place a DataGrid control on the form.
			DataGrid grid = new DataGrid();
			grid.Parent = form;
			grid.Dock = DockStyle.Fill;
			// Get the recrd set associated with the current cell and bind it to the grid.
			grid.DataSource = e.CreateDrillDownDataSource();
			form.Bounds = new Rectangle(100, 100, 500, 400);
			// Display the form.
			form.ShowDialog();
			form.Dispose();

		}

	

		private void btnReset_Click(object sender, System.EventArgs e)
		{
			DateFrom.EditValue = string.Format("{0:dd/MM/yyyy}",Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year));

			DateRangeTo.EditValue = DateTime.Today;
			lkBranch.EditValue = null;
			lkPromotion.EditValue = null;
			BindReport();
		}

		private void sbtnReset_Click(object sender, System.EventArgs e)
		{
			BindReport();
		}
	}
}












