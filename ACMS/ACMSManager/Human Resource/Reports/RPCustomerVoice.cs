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
	/// Summary description for RPCustomerVoice.
	/// </summary>
	public class RPCustomerVoice : System.Windows.Forms.Form
	{
		private string connectionString;
		private SqlConnection connection;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField1;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField2;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private DevExpress.XtraPivotGrid.PivotGridControl GridCVType;
		private DevExpress.XtraEditors.DateEdit DateFrom;
		private System.Windows.Forms.Label DateTo;
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.DateEdit DateRangeTo;
		private DevExpress.XtraPivotGrid.PivotGridControl GridCVCategory;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField4;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField5;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField6;
		private DevExpress.XtraPivotGrid.PivotGridControl GridCVDepartment;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField7;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField8;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField9;
		private DevExpress.XtraPivotGrid.PivotGridControl GridCVTypeCat;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField10;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField11;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField12;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField13;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField14;
		private DevExpress.XtraPivotGrid.PivotGridControl GridCVSpa;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField15;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField16;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField17;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField18;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField19;
		private DevExpress.XtraPivotGrid.PivotGridControl GridCVOffice;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField20;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField21;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField22;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField23;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField24;
		private DevExpress.XtraGrid.GridControl GridCVList;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private DevExpress.XtraEditors.SimpleButton btnReset;
		private int EmployeeId;

		public RPCustomerVoice(int empId)
		{
			//
			// Required for Windows Form Designer support
			//
			EmployeeId = empId;
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
			this.GridCVType = new DevExpress.XtraPivotGrid.PivotGridControl();
			this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField2 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField3 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.DateFrom = new DevExpress.XtraEditors.DateEdit();
			this.DateTo = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.DateRangeTo = new DevExpress.XtraEditors.DateEdit();
			this.GridCVCategory = new DevExpress.XtraPivotGrid.PivotGridControl();
			this.pivotGridField4 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField5 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField6 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.GridCVDepartment = new DevExpress.XtraPivotGrid.PivotGridControl();
			this.pivotGridField7 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField8 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField9 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.GridCVTypeCat = new DevExpress.XtraPivotGrid.PivotGridControl();
			this.pivotGridField10 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField11 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField12 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField13 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField14 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.GridCVSpa = new DevExpress.XtraPivotGrid.PivotGridControl();
			this.pivotGridField15 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField16 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField17 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField18 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField19 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.GridCVOffice = new DevExpress.XtraPivotGrid.PivotGridControl();
			this.pivotGridField20 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField21 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField22 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField23 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField24 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.GridCVList = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.btnReset = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.GridCVType)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DateFrom.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DateRangeTo.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GridCVCategory)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GridCVDepartment)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GridCVTypeCat)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GridCVSpa)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GridCVOffice)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GridCVList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// GridCVType
			// 
			this.GridCVType.Cursor = System.Windows.Forms.Cursors.Default;
			this.GridCVType.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
																							  this.pivotGridField1,
																							  this.pivotGridField2,
																							  this.pivotGridField3});
			this.GridCVType.Location = new System.Drawing.Point(0, 56);
			this.GridCVType.Name = "GridCVType";
			this.GridCVType.OptionsCustomization.AllowDrag = false;
			this.GridCVType.OptionsCustomization.AllowExpand = false;
			this.GridCVType.OptionsCustomization.AllowFilter = false;
			this.GridCVType.OptionsCustomization.AllowSort = false;
			this.GridCVType.OptionsView.ShowDataHeaders = false;
			this.GridCVType.OptionsView.ShowFilterHeaders = false;
			this.GridCVType.Size = new System.Drawing.Size(712, 184);
			this.GridCVType.TabIndex = 0;
			// 
			// pivotGridField1
			// 
			this.pivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
			this.pivotGridField1.AreaIndex = 0;
			this.pivotGridField1.Caption = "Type";
			this.pivotGridField1.FieldName = "strDescription";
			this.pivotGridField1.Name = "pivotGridField1";
			// 
			// pivotGridField2
			// 
			this.pivotGridField2.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
			this.pivotGridField2.AreaIndex = 0;
			this.pivotGridField2.Caption = "Branch";
			this.pivotGridField2.FieldName = "strBranchCode";
			this.pivotGridField2.Name = "pivotGridField2";
			// 
			// pivotGridField3
			// 
			this.pivotGridField3.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
			this.pivotGridField3.AreaIndex = 0;
			this.pivotGridField3.Caption = "Type";
			this.pivotGridField3.FieldName = "nTypeID";
			this.pivotGridField3.Name = "pivotGridField3";
			// 
			// DateFrom
			// 
			this.DateFrom.EditValue = null;
			this.DateFrom.Location = new System.Drawing.Point(40, 8);
			this.DateFrom.Name = "DateFrom";
			// 
			// DateFrom.Properties
			// 
			this.DateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.DateFrom.Size = new System.Drawing.Size(72, 20);
			this.DateFrom.TabIndex = 9;
			// 
			// DateTo
			// 
			this.DateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.DateTo.Location = new System.Drawing.Point(120, 8);
			this.DateTo.Name = "DateTo";
			this.DateTo.Size = new System.Drawing.Size(24, 16);
			this.DateTo.TabIndex = 8;
			this.DateTo.Text = "To";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(0, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 16);
			this.label1.TabIndex = 7;
			this.label1.Text = "From";
			// 
			// DateRangeTo
			// 
			this.DateRangeTo.EditValue = null;
			this.DateRangeTo.Location = new System.Drawing.Point(152, 8);
			this.DateRangeTo.Name = "DateRangeTo";
			// 
			// DateRangeTo.Properties
			// 
			this.DateRangeTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.DateRangeTo.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.DateRangeTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.DateRangeTo.Properties.EditFormat.FormatString = "dd/MM/yyyy";
			this.DateRangeTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.DateRangeTo.Properties.Mask.EditMask = "dd/MM/yyyy";
			this.DateRangeTo.Size = new System.Drawing.Size(72, 20);
			this.DateRangeTo.TabIndex = 6;
			// 
			// GridCVCategory
			// 
			this.GridCVCategory.Cursor = System.Windows.Forms.Cursors.Default;
			this.GridCVCategory.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
																								  this.pivotGridField4,
																								  this.pivotGridField5,
																								  this.pivotGridField6});
			this.GridCVCategory.Location = new System.Drawing.Point(0, 264);
			this.GridCVCategory.Name = "GridCVCategory";
			this.GridCVCategory.OptionsCustomization.AllowDrag = false;
			this.GridCVCategory.OptionsCustomization.AllowExpand = false;
			this.GridCVCategory.OptionsCustomization.AllowFilter = false;
			this.GridCVCategory.OptionsCustomization.AllowSort = false;
			this.GridCVCategory.OptionsView.ShowDataHeaders = false;
			this.GridCVCategory.OptionsView.ShowFilterHeaders = false;
			this.GridCVCategory.Size = new System.Drawing.Size(712, 184);
			this.GridCVCategory.TabIndex = 10;
			// 
			// pivotGridField4
			// 
			this.pivotGridField4.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
			this.pivotGridField4.AreaIndex = 0;
			this.pivotGridField4.Caption = "Category";
			this.pivotGridField4.FieldName = "strDescription";
			this.pivotGridField4.Name = "pivotGridField4";
			// 
			// pivotGridField5
			// 
			this.pivotGridField5.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
			this.pivotGridField5.AreaIndex = 0;
			this.pivotGridField5.Caption = "Branch";
			this.pivotGridField5.FieldName = "strBranchCode";
			this.pivotGridField5.Name = "pivotGridField5";
			// 
			// pivotGridField6
			// 
			this.pivotGridField6.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
			this.pivotGridField6.AreaIndex = 0;
			this.pivotGridField6.Caption = "Category";
			this.pivotGridField6.FieldName = "nCategoryID";
			this.pivotGridField6.Name = "pivotGridField6";
			// 
			// GridCVDepartment
			// 
			this.GridCVDepartment.Cursor = System.Windows.Forms.Cursors.Default;
			this.GridCVDepartment.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
																									this.pivotGridField7,
																									this.pivotGridField8,
																									this.pivotGridField9});
			this.GridCVDepartment.Location = new System.Drawing.Point(0, 472);
			this.GridCVDepartment.Name = "GridCVDepartment";
			this.GridCVDepartment.OptionsCustomization.AllowDrag = false;
			this.GridCVDepartment.OptionsCustomization.AllowExpand = false;
			this.GridCVDepartment.OptionsCustomization.AllowFilter = false;
			this.GridCVDepartment.OptionsCustomization.AllowSort = false;
			this.GridCVDepartment.OptionsView.ShowDataHeaders = false;
			this.GridCVDepartment.OptionsView.ShowFilterHeaders = false;
			this.GridCVDepartment.OptionsView.ShowFilterSeparatorBar = false;
			this.GridCVDepartment.Size = new System.Drawing.Size(712, 184);
			this.GridCVDepartment.TabIndex = 11;
			// 
			// pivotGridField7
			// 
			this.pivotGridField7.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
			this.pivotGridField7.AreaIndex = 0;
			this.pivotGridField7.Caption = "Department";
			this.pivotGridField7.FieldName = "strDescription";
			this.pivotGridField7.Name = "pivotGridField7";
			// 
			// pivotGridField8
			// 
			this.pivotGridField8.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
			this.pivotGridField8.AreaIndex = 0;
			this.pivotGridField8.Caption = "Branch";
			this.pivotGridField8.FieldName = "strBranchCode";
			this.pivotGridField8.Name = "pivotGridField8";
			// 
			// pivotGridField9
			// 
			this.pivotGridField9.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
			this.pivotGridField9.AreaIndex = 0;
			this.pivotGridField9.Caption = "Department";
			this.pivotGridField9.FieldName = "nDepartmentID";
			this.pivotGridField9.Name = "pivotGridField9";
			// 
			// GridCVTypeCat
			// 
			this.GridCVTypeCat.Cursor = System.Windows.Forms.Cursors.Default;
			this.GridCVTypeCat.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
																								 this.pivotGridField10,
																								 this.pivotGridField11,
																								 this.pivotGridField12,
																								 this.pivotGridField13,
																								 this.pivotGridField14});
			this.GridCVTypeCat.Location = new System.Drawing.Point(0, 680);
			this.GridCVTypeCat.Name = "GridCVTypeCat";
			this.GridCVTypeCat.OptionsCustomization.AllowDrag = false;
			this.GridCVTypeCat.OptionsCustomization.AllowExpand = false;
			this.GridCVTypeCat.OptionsCustomization.AllowFilter = false;
			this.GridCVTypeCat.OptionsCustomization.AllowSort = false;
			this.GridCVTypeCat.OptionsView.ShowDataHeaders = false;
			this.GridCVTypeCat.OptionsView.ShowFilterHeaders = false;
			this.GridCVTypeCat.Size = new System.Drawing.Size(712, 184);
			this.GridCVTypeCat.TabIndex = 12;
			// 
			// pivotGridField10
			// 
			this.pivotGridField10.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
			this.pivotGridField10.AreaIndex = 0;
			this.pivotGridField10.Caption = "Type";
			this.pivotGridField10.FieldName = "Type";
			this.pivotGridField10.Name = "pivotGridField10";
			// 
			// pivotGridField11
			// 
			this.pivotGridField11.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
			this.pivotGridField11.AreaIndex = 0;
			this.pivotGridField11.Caption = "Category";
			this.pivotGridField11.FieldName = "Category";
			this.pivotGridField11.Name = "pivotGridField11";
			// 
			// pivotGridField12
			// 
			this.pivotGridField12.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
			this.pivotGridField12.AreaIndex = 2;
			this.pivotGridField12.Caption = "Total";
			this.pivotGridField12.FieldName = "nTypeID";
			this.pivotGridField12.Name = "pivotGridField12";
			this.pivotGridField12.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
			this.pivotGridField12.Width = 50;
			// 
			// pivotGridField13
			// 
			this.pivotGridField13.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
			this.pivotGridField13.AreaIndex = 0;
			this.pivotGridField13.Caption = "Pending";
			this.pivotGridField13.FieldName = "Pending";
			this.pivotGridField13.Name = "pivotGridField13";
			this.pivotGridField13.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
			this.pivotGridField13.Width = 50;
			// 
			// pivotGridField14
			// 
			this.pivotGridField14.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
			this.pivotGridField14.AreaIndex = 1;
			this.pivotGridField14.Caption = "Closed";
			this.pivotGridField14.FieldName = "Closed";
			this.pivotGridField14.Name = "pivotGridField14";
			this.pivotGridField14.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
			this.pivotGridField14.Width = 45;
			// 
			// GridCVSpa
			// 
			this.GridCVSpa.Cursor = System.Windows.Forms.Cursors.Default;
			this.GridCVSpa.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
																							 this.pivotGridField15,
																							 this.pivotGridField16,
																							 this.pivotGridField17,
																							 this.pivotGridField18,
																							 this.pivotGridField19});
			this.GridCVSpa.Location = new System.Drawing.Point(0, 888);
			this.GridCVSpa.Name = "GridCVSpa";
			this.GridCVSpa.OptionsCustomization.AllowDrag = false;
			this.GridCVSpa.OptionsCustomization.AllowExpand = false;
			this.GridCVSpa.OptionsCustomization.AllowFilter = false;
			this.GridCVSpa.OptionsCustomization.AllowSort = false;
			this.GridCVSpa.OptionsView.ShowDataHeaders = false;
			this.GridCVSpa.OptionsView.ShowFilterHeaders = false;
			this.GridCVSpa.Size = new System.Drawing.Size(704, 184);
			this.GridCVSpa.TabIndex = 13;
			// 
			// pivotGridField15
			// 
			this.pivotGridField15.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
			this.pivotGridField15.AreaIndex = 0;
			this.pivotGridField15.Caption = "Type";
			this.pivotGridField15.FieldName = "Type";
			this.pivotGridField15.Name = "pivotGridField15";
			// 
			// pivotGridField16
			// 
			this.pivotGridField16.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
			this.pivotGridField16.AreaIndex = 0;
			this.pivotGridField16.Caption = "Category";
			this.pivotGridField16.FieldName = "Category";
			this.pivotGridField16.Name = "pivotGridField16";
			// 
			// pivotGridField17
			// 
			this.pivotGridField17.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
			this.pivotGridField17.AreaIndex = 2;
			this.pivotGridField17.Caption = "Total";
			this.pivotGridField17.FieldName = "nTypeID";
			this.pivotGridField17.Name = "pivotGridField17";
			this.pivotGridField17.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
			this.pivotGridField17.Width = 50;
			// 
			// pivotGridField18
			// 
			this.pivotGridField18.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
			this.pivotGridField18.AreaIndex = 0;
			this.pivotGridField18.Caption = "Pending";
			this.pivotGridField18.FieldName = "Pending";
			this.pivotGridField18.Name = "pivotGridField18";
			this.pivotGridField18.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
			this.pivotGridField18.Width = 50;
			// 
			// pivotGridField19
			// 
			this.pivotGridField19.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
			this.pivotGridField19.AreaIndex = 1;
			this.pivotGridField19.Caption = "Closed";
			this.pivotGridField19.FieldName = "Closed";
			this.pivotGridField19.Name = "pivotGridField19";
			this.pivotGridField19.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
			this.pivotGridField19.Width = 45;
			// 
			// GridCVOffice
			// 
			this.GridCVOffice.Cursor = System.Windows.Forms.Cursors.Default;
			this.GridCVOffice.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
																								this.pivotGridField20,
																								this.pivotGridField21,
																								this.pivotGridField22,
																								this.pivotGridField23,
																								this.pivotGridField24});
			this.GridCVOffice.Location = new System.Drawing.Point(0, 1096);
			this.GridCVOffice.Name = "GridCVOffice";
			this.GridCVOffice.OptionsCustomization.AllowDrag = false;
			this.GridCVOffice.OptionsCustomization.AllowExpand = false;
			this.GridCVOffice.OptionsCustomization.AllowFilter = false;
			this.GridCVOffice.OptionsCustomization.AllowSort = false;
			this.GridCVOffice.OptionsView.ShowDataHeaders = false;
			this.GridCVOffice.OptionsView.ShowFilterHeaders = false;
			this.GridCVOffice.Size = new System.Drawing.Size(712, 184);
			this.GridCVOffice.TabIndex = 14;
			// 
			// pivotGridField20
			// 
			this.pivotGridField20.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
			this.pivotGridField20.AreaIndex = 0;
			this.pivotGridField20.Caption = "Type";
			this.pivotGridField20.FieldName = "Type";
			this.pivotGridField20.Name = "pivotGridField20";
			// 
			// pivotGridField21
			// 
			this.pivotGridField21.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
			this.pivotGridField21.AreaIndex = 0;
			this.pivotGridField21.Caption = "Category";
			this.pivotGridField21.FieldName = "Category";
			this.pivotGridField21.Name = "pivotGridField21";
			// 
			// pivotGridField22
			// 
			this.pivotGridField22.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
			this.pivotGridField22.AreaIndex = 2;
			this.pivotGridField22.Caption = "Total";
			this.pivotGridField22.FieldName = "nTypeID";
			this.pivotGridField22.Name = "pivotGridField22";
			this.pivotGridField22.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
			this.pivotGridField22.Width = 50;
			// 
			// pivotGridField23
			// 
			this.pivotGridField23.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
			this.pivotGridField23.AreaIndex = 0;
			this.pivotGridField23.Caption = "Pending";
			this.pivotGridField23.FieldName = "Pending";
			this.pivotGridField23.Name = "pivotGridField23";
			this.pivotGridField23.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
			this.pivotGridField23.Width = 50;
			// 
			// pivotGridField24
			// 
			this.pivotGridField24.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
			this.pivotGridField24.AreaIndex = 1;
			this.pivotGridField24.Caption = "Closed";
			this.pivotGridField24.FieldName = "Closed";
			this.pivotGridField24.Name = "pivotGridField24";
			this.pivotGridField24.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
			this.pivotGridField24.Width = 45;
			// 
			// GridCVList
			// 
			// 
			// GridCVList.EmbeddedNavigator
			// 
			this.GridCVList.EmbeddedNavigator.Name = "";
			this.GridCVList.Location = new System.Drawing.Point(0, 1304);
			this.GridCVList.MainView = this.gridView1;
			this.GridCVList.Name = "GridCVList";
			this.GridCVList.Size = new System.Drawing.Size(712, 200);
			this.GridCVList.TabIndex = 15;
			this.GridCVList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																									  this.gridView1});
			// 
			// gridView1
			// 
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn1,
																							 this.gridColumn2,
																							 this.gridColumn3,
																							 this.gridColumn4,
																							 this.gridColumn5,
																							 this.gridColumn6,
																							 this.gridColumn7,
																							 this.gridColumn8,
																							 this.gridColumn9,
																							 this.gridColumn10,
																							 this.gridColumn11});
			this.gridView1.GridControl = this.GridCVList;
			this.gridView1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
			this.gridView1.Name = "gridView1";
			this.gridView1.OptionsBehavior.Editable = false;
			this.gridView1.OptionsCustomization.AllowColumnMoving = false;
			this.gridView1.OptionsCustomization.AllowFilter = false;
			this.gridView1.OptionsCustomization.AllowSort = false;
			this.gridView1.OptionsView.ColumnAutoWidth = false;
			this.gridView1.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "Reference No";
			this.gridColumn1.FieldName = "nCaseID";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 0;
			this.gridColumn1.Width = 80;
			// 
			// gridColumn2
			// 
			this.gridColumn2.Caption = "Date";
			this.gridColumn2.FieldName = "dtDate";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 1;
			this.gridColumn2.Width = 80;
			// 
			// gridColumn3
			// 
			this.gridColumn3.Caption = "Branch";
			this.gridColumn3.FieldName = "strBranchCode";
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 2;
			this.gridColumn3.Width = 80;
			// 
			// gridColumn4
			// 
			this.gridColumn4.Caption = "Department";
			this.gridColumn4.FieldName = "Department";
			this.gridColumn4.Name = "gridColumn4";
			this.gridColumn4.Visible = true;
			this.gridColumn4.VisibleIndex = 3;
			this.gridColumn4.Width = 150;
			// 
			// gridColumn5
			// 
			this.gridColumn5.Caption = "Type";
			this.gridColumn5.FieldName = "Type";
			this.gridColumn5.Name = "gridColumn5";
			this.gridColumn5.Visible = true;
			this.gridColumn5.VisibleIndex = 4;
			this.gridColumn5.Width = 80;
			// 
			// gridColumn6
			// 
			this.gridColumn6.Caption = "Member Id";
			this.gridColumn6.FieldName = "strMembershipId";
			this.gridColumn6.Name = "gridColumn6";
			this.gridColumn6.Visible = true;
			this.gridColumn6.VisibleIndex = 5;
			this.gridColumn6.Width = 100;
			// 
			// gridColumn7
			// 
			this.gridColumn7.Caption = "Member Name";
			this.gridColumn7.FieldName = "strMemberName";
			this.gridColumn7.Name = "gridColumn7";
			this.gridColumn7.Visible = true;
			this.gridColumn7.VisibleIndex = 6;
			this.gridColumn7.Width = 120;
			// 
			// gridColumn8
			// 
			this.gridColumn8.Caption = "Submitted By";
			this.gridColumn8.FieldName = "SubmittedBy";
			this.gridColumn8.Name = "gridColumn8";
			this.gridColumn8.Visible = true;
			this.gridColumn8.VisibleIndex = 7;
			this.gridColumn8.Width = 120;
			// 
			// gridColumn9
			// 
			this.gridColumn9.Caption = "Assigned To";
			this.gridColumn9.FieldName = "AssignedTo";
			this.gridColumn9.Name = "gridColumn9";
			this.gridColumn9.Visible = true;
			this.gridColumn9.VisibleIndex = 8;
			this.gridColumn9.Width = 120;
			// 
			// gridColumn10
			// 
			this.gridColumn10.Caption = "Update Date";
			this.gridColumn10.FieldName = "dtLastEditDate";
			this.gridColumn10.Name = "gridColumn10";
			this.gridColumn10.Visible = true;
			this.gridColumn10.VisibleIndex = 9;
			this.gridColumn10.Width = 100;
			// 
			// gridColumn11
			// 
			this.gridColumn11.Caption = "Status";
			this.gridColumn11.FieldName = "Status";
			this.gridColumn11.Name = "gridColumn11";
			this.gridColumn11.Visible = true;
			this.gridColumn11.VisibleIndex = 10;
			this.gridColumn11.Width = 60;
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.Location = new System.Drawing.Point(0, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(176, 24);
			this.label2.TabIndex = 16;
			this.label2.Text = "Customer Voice - By Type";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label3.Location = new System.Drawing.Point(0, 240);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(200, 24);
			this.label3.TabIndex = 17;
			this.label3.Text = "Customer Voice - By Category";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label4.Location = new System.Drawing.Point(0, 456);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(216, 16);
			this.label4.TabIndex = 18;
			this.label4.Text = "Customer Voice - By Department";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label5.Location = new System.Drawing.Point(0, 656);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(328, 24);
			this.label5.TabIndex = 19;
			this.label5.Text = "Customer Voice - By Type and Category - Fitness";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label6
			// 
			this.label6.BackColor = System.Drawing.Color.Transparent;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label6.Location = new System.Drawing.Point(0, 864);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(304, 24);
			this.label6.TabIndex = 20;
			this.label6.Text = "Customer Voice - By Type and Category - Spa";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label7
			// 
			this.label7.BackColor = System.Drawing.Color.Transparent;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label7.Location = new System.Drawing.Point(0, 1072);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(312, 24);
			this.label7.TabIndex = 21;
			this.label7.Text = "Customer Voice - By Type and Category - Office";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label8
			// 
			this.label8.BackColor = System.Drawing.Color.Transparent;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label8.Location = new System.Drawing.Point(0, 1280);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(72, 24);
			this.label8.TabIndex = 22;
			this.label8.Text = "CV Listing";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnReset
			// 
			this.btnReset.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnReset.Appearance.Options.UseFont = true;
			this.btnReset.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnReset.Location = new System.Drawing.Point(240, 8);
			this.btnReset.LookAndFeel.UseDefaultLookAndFeel = false;
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(72, 16);
			this.btnReset.TabIndex = 216;
			this.btnReset.Text = "Enquiry";
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// RPCustomerVoice
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(736, 581);
			this.Controls.Add(this.btnReset);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.GridCVList);
			this.Controls.Add(this.GridCVOffice);
			this.Controls.Add(this.GridCVSpa);
			this.Controls.Add(this.GridCVTypeCat);
			this.Controls.Add(this.GridCVDepartment);
			this.Controls.Add(this.GridCVCategory);
			this.Controls.Add(this.DateFrom);
			this.Controls.Add(this.DateTo);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.DateRangeTo);
			this.Controls.Add(this.GridCVType);
			this.DockPadding.Bottom = 10;
			this.Name = "RPCustomerVoice";
			this.Text = "Customer Voice";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.RPCustomerVoice_Load);
			((System.ComponentModel.ISupportInitialize)(this.GridCVType)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DateFrom.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DateRangeTo.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GridCVCategory)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GridCVDepartment)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GridCVTypeCat)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GridCVSpa)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GridCVOffice)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GridCVList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void BindReport()
		{
			string strSQL;
			DataSet _ds;

			// Type
			strSQL = "up_get_CustomerVoiceType " + EmployeeId;
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			DataTable dt = _ds.Tables["table"];
			DataView dv = new DataView(dt);

            string str = string.Format("dtDate >= '{0}' And dtDate < '{1}'", string.Format("{0:dd-MMM-yyyy}", Convert.ToDateTime(DateFrom.EditValue)), string.Format("{0:dd-MMM-yyyy}", Convert.ToDateTime(DateRangeTo.EditValue)));
			dv.RowFilter = str;

			GridCVType.DataSource = dv;

		
			// Category
			strSQL = "up_get_CustomerVoiceCategory " + EmployeeId;
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dt = _ds.Tables["table"];
			dv = new DataView(dt);

			//str = string.Format("dtDate >= '{0}' And dtDate < '{1}'",string.Format("{0:yyyy-MM-dd}",Convert.ToDateTime(DateFrom.EditValue)),string.Format("{0:yyyy-MM-dd}",Convert.ToDateTime(DateRangeTo.EditValue)));
			dv.RowFilter = str;

			this.GridCVCategory.DataSource = dv;

			
			// Department
			strSQL = "up_get_CustomerVoiceDepartment " + EmployeeId;
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dt = _ds.Tables["table"];
			dv = new DataView(dt);

			//str = string.Format("dtDate >= '{0}' And dtDate < '{1}'",string.Format("{0:yyyy-MM-dd}",Convert.ToDateTime(DateFrom.EditValue)),string.Format("{0:yyyy-MM-dd}",Convert.ToDateTime(DateRangeTo.EditValue)));
			dv.RowFilter = str;

			this.GridCVDepartment.DataSource = dv;

			// Type Category Fitness
			strSQL = "up_get_CustomerVoiceCatType " + EmployeeId;
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dt = _ds.Tables["table"];
			dv = new DataView(dt);
			
			str = " nSalesCategoryID in (1,3) And ";
            str += string.Format("dtDate >= '{0}' And dtDate < '{1}'", string.Format("{0:dd-MMM-yyyy}", Convert.ToDateTime(DateFrom.EditValue)), string.Format("{0:dd-MMM-yyyy}", Convert.ToDateTime(DateRangeTo.EditValue)));
			
			dv.RowFilter = str;

			this.GridCVTypeCat.DataSource = dv;

//			// Type Category Spa
//			strSQL = "up_get_CustomerVoiceCatType " + EmployeeId;
//			_ds = new DataSet();
//			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
//			dt = _ds.Tables["table"];
//			dv = new DataView(dt);
			DataView dv2 = new DataView(dt);
            
			str = " nSalesCategoryID in (2,4) And ";
            str += string.Format("(dtDate >= '{0}' And dtDate < '{1}')", string.Format("{0:dd-MMM-yyyy}", Convert.ToDateTime(DateFrom.EditValue)), string.Format("{0:dd-MMM-yyyy}", Convert.ToDateTime(DateRangeTo.EditValue)));
								
			dv2.RowFilter = str;

			this.GridCVSpa.DataSource = dv2;

			// Type Category Office
//			strSQL = "up_get_CustomerVoiceCatType " + EmployeeId;
//			_ds = new DataSet();
//			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
//			dt = _ds.Tables["table"];
//			dv = new DataView(dt);
			DataView dv3 = new DataView(dt);

			str = " nSalesCategoryID in (2,4) And ";
            str += string.Format("(dtDate >= '{0}' And dtDate < '{1}')", string.Format("{0:dd-MMM-yyyy}", Convert.ToDateTime(DateFrom.EditValue)), string.Format("{0:dd-MMM-yyyy}", Convert.ToDateTime(DateRangeTo.EditValue)));
            dv3.RowFilter = str;

			this.GridCVOffice.DataSource = dv3;

			//Customer Voice List

			strSQL = "up_get_CustomerVoice " + EmployeeId;
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dt = _ds.Tables["table"];
			dv = new DataView(dt);

            str = string.Format("(dtDate >= '{0}' And dtDate < '{1}')", string.Format("{0:dd-MMM-yyyy}", Convert.ToDateTime(DateFrom.EditValue)), string.Format("{0:dd-MMM-yyyy}", Convert.ToDateTime(DateRangeTo.EditValue)));
            dv.RowFilter = str;

			this.GridCVList.DataSource = dv;

					
		}

		private void RPCustomerVoice_Load(object sender, System.EventArgs e)
		{
			DateFrom.EditValue = string.Format("{0:dd/MM/yyyy}",Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year));

			DateRangeTo.EditValue = DateTime.Today;
			BindReport();
		}

		private void btnReset_Click(object sender, System.EventArgs e)
		{
			BindReport();
		}

		
	}
}
