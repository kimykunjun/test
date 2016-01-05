using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;

namespace ACMS.ACMSManager.Reports
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class RPStockSalon : System.Windows.Forms.Form
	{
		private ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder myLookUpEdit;
		private DataTable dt;
		private DataSet _ds;
		private DataView dv;
		private string strSQL;
		private string connectionString;
		private SqlConnection connection;

		private DevExpress.XtraEditors.DateEdit DateFrom;
		private System.Windows.Forms.Label DateTo;
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.DateEdit DateRangeTo;
		private System.Windows.Forms.Label label2;
		private DevExpress.XtraEditors.LookUpEdit lkedtEmployee;
		private DevExpress.XtraPivotGrid.PivotGridControl GridStockRequest;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField1;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField2;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField3;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField4;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField5;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField6;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField7;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField8;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField9;
		private DevExpress.XtraEditors.PanelControl panelControl1;
		private DevExpress.XtraEditors.LookUpEdit lkedtProductType;
		private System.Windows.Forms.Label label8;
		private DevExpress.XtraEditors.LookUpEdit lkedtBrandCode;
		private System.Windows.Forms.Label label7;
		internal DevExpress.XtraEditors.SimpleButton btnReset;
		internal DevExpress.XtraEditors.SimpleButton btnSearch;
		private System.Windows.Forms.Label label5;
		private DevExpress.XtraEditors.TextEdit txtStyleDesc;
		private System.Windows.Forms.Label label4;
		private DevExpress.XtraEditors.TextEdit txtStyleCode;
		private System.Windows.Forms.Label label3;
		private DevExpress.XtraEditors.TextEdit txtItemDesc;
		private System.Windows.Forms.Label label6;
		private DevExpress.XtraEditors.TextEdit txtItemCode;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public RPStockSalon()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);
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
			this.DateFrom = new DevExpress.XtraEditors.DateEdit();
			this.DateTo = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.DateRangeTo = new DevExpress.XtraEditors.DateEdit();
			this.label2 = new System.Windows.Forms.Label();
			this.lkedtEmployee = new DevExpress.XtraEditors.LookUpEdit();
			this.GridStockRequest = new DevExpress.XtraPivotGrid.PivotGridControl();
			this.pivotGridField6 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField8 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField9 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField3 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField2 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField4 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField5 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField7 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
			this.lkedtProductType = new DevExpress.XtraEditors.LookUpEdit();
			this.label8 = new System.Windows.Forms.Label();
			this.lkedtBrandCode = new DevExpress.XtraEditors.LookUpEdit();
			this.label7 = new System.Windows.Forms.Label();
			this.btnReset = new DevExpress.XtraEditors.SimpleButton();
			this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
			this.label5 = new System.Windows.Forms.Label();
			this.txtStyleDesc = new DevExpress.XtraEditors.TextEdit();
			this.label4 = new System.Windows.Forms.Label();
			this.txtStyleCode = new DevExpress.XtraEditors.TextEdit();
			this.label3 = new System.Windows.Forms.Label();
			this.txtItemDesc = new DevExpress.XtraEditors.TextEdit();
			this.label6 = new System.Windows.Forms.Label();
			this.txtItemCode = new DevExpress.XtraEditors.TextEdit();
			((System.ComponentModel.ISupportInitialize)(this.DateFrom.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DateRangeTo.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkedtEmployee.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GridStockRequest)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
			this.panelControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lkedtProductType.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkedtBrandCode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtStyleDesc.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtStyleCode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtItemDesc.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtItemCode.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// DateFrom
			// 
			this.DateFrom.EditValue = new System.DateTime(2006, 8, 21, 1, 50, 21, 359);
			this.DateFrom.Location = new System.Drawing.Point(56, 8);
			this.DateFrom.Name = "DateFrom";
			// 
			// DateFrom.Properties
			// 
			this.DateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.DateFrom.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.DateFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.DateFrom.Properties.EditFormat.FormatString = "dd/MM/yyyy";
			this.DateFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.DateFrom.Properties.Mask.EditMask = "dd/MM/yyyy";
			this.DateFrom.TabIndex = 13;
			this.DateFrom.EditValueChanged += new System.EventHandler(this.DateFrom_EditValueChanged);
			// 
			// DateTo
			// 
			this.DateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.DateTo.Location = new System.Drawing.Point(200, 8);
			this.DateTo.Name = "DateTo";
			this.DateTo.Size = new System.Drawing.Size(24, 16);
			this.DateTo.TabIndex = 12;
			this.DateTo.Text = "To";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 16);
			this.label1.TabIndex = 11;
			this.label1.Text = "From";
			// 
			// DateRangeTo
			// 
			this.DateRangeTo.EditValue = new System.DateTime(2006, 8, 21, 1, 50, 31, 328);
			this.DateRangeTo.Location = new System.Drawing.Point(232, 8);
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
			this.DateRangeTo.TabIndex = 10;
			this.DateRangeTo.EditValueChanged += new System.EventHandler(this.DateRangeTo_EditValueChanged);
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.Location = new System.Drawing.Point(360, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 16);
			this.label2.TabIndex = 14;
			this.label2.Text = "Employee";
			// 
			// lkedtEmployee
			// 
			this.lkedtEmployee.EditValue = "";
			this.lkedtEmployee.Location = new System.Drawing.Point(440, 8);
			this.lkedtEmployee.Name = "lkedtEmployee";
			// 
			// lkedtEmployee.Properties
			// 
			this.lkedtEmployee.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkedtEmployee.Size = new System.Drawing.Size(184, 20);
			this.lkedtEmployee.TabIndex = 15;
			this.lkedtEmployee.EditValueChanged += new System.EventHandler(this.lkedtEmployee_EditValueChanged);
			// 
			// GridStockRequest
			// 
			this.GridStockRequest.Cursor = System.Windows.Forms.Cursors.Default;
			this.GridStockRequest.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
																									this.pivotGridField6,
																									this.pivotGridField1,
																									this.pivotGridField8,
																									this.pivotGridField9,
																									this.pivotGridField3,
																									this.pivotGridField2,
																									this.pivotGridField4,
																									this.pivotGridField5,
																									this.pivotGridField7});
			this.GridStockRequest.Location = new System.Drawing.Point(0, 120);
			this.GridStockRequest.Name = "GridStockRequest";
			this.GridStockRequest.OptionsCustomization.AllowDrag = false;
			this.GridStockRequest.OptionsCustomization.AllowExpand = false;
			this.GridStockRequest.OptionsCustomization.AllowFilter = false;
			this.GridStockRequest.OptionsCustomization.AllowSort = false;
			this.GridStockRequest.OptionsView.ShowDataHeaders = false;
			this.GridStockRequest.OptionsView.ShowFilterHeaders = false;
			this.GridStockRequest.Size = new System.Drawing.Size(974, 424);
			this.GridStockRequest.TabIndex = 63;
			// 
			// pivotGridField6
			// 
			this.pivotGridField6.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
			this.pivotGridField6.AreaIndex = 0;
			this.pivotGridField6.Caption = "Branch";
			this.pivotGridField6.FieldName = "strBranchCode";
			this.pivotGridField6.Name = "pivotGridField6";
			// 
			// pivotGridField1
			// 
			this.pivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
			this.pivotGridField1.AreaIndex = 0;
			this.pivotGridField1.Caption = "Item Code";
			this.pivotGridField1.FieldName = "strProductCode";
			this.pivotGridField1.Name = "pivotGridField1";
			this.pivotGridField1.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.True;
			// 
			// pivotGridField8
			// 
			this.pivotGridField8.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
			this.pivotGridField8.AreaIndex = 5;
			this.pivotGridField8.Caption = "Item Desc";
			this.pivotGridField8.FieldName = "ProductDesc";
			this.pivotGridField8.Name = "pivotGridField8";
			this.pivotGridField8.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.True;
			// 
			// pivotGridField9
			// 
			this.pivotGridField9.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
			this.pivotGridField9.AreaIndex = 6;
			this.pivotGridField9.Caption = "Product Type";
			this.pivotGridField9.FieldName = "nProductTypeID";
			this.pivotGridField9.Name = "pivotGridField9";
			// 
			// pivotGridField3
			// 
			this.pivotGridField3.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
			this.pivotGridField3.AreaIndex = 2;
			this.pivotGridField3.Caption = "Style Code";
			this.pivotGridField3.FieldName = "strStyleCode";
			this.pivotGridField3.Name = "pivotGridField3";
			this.pivotGridField3.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.True;
			// 
			// pivotGridField2
			// 
			this.pivotGridField2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
			this.pivotGridField2.AreaIndex = 1;
			this.pivotGridField2.Caption = "Brand";
			this.pivotGridField2.FieldName = "strBrandCode";
			this.pivotGridField2.Name = "pivotGridField2";
			// 
			// pivotGridField4
			// 
			this.pivotGridField4.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
			this.pivotGridField4.AreaIndex = 3;
			this.pivotGridField4.Caption = "Color";
			this.pivotGridField4.FieldName = "strColorCode";
			this.pivotGridField4.Name = "pivotGridField4";
			this.pivotGridField4.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.True;
			// 
			// pivotGridField5
			// 
			this.pivotGridField5.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
			this.pivotGridField5.AreaIndex = 4;
			this.pivotGridField5.Caption = "Size";
			this.pivotGridField5.FieldName = "strSizeCode";
			this.pivotGridField5.Name = "pivotGridField5";
			this.pivotGridField5.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.True;
			// 
			// pivotGridField7
			// 
			this.pivotGridField7.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
			this.pivotGridField7.AreaIndex = 0;
			this.pivotGridField7.Caption = "Quantity";
			this.pivotGridField7.FieldName = "nQuantity";
			this.pivotGridField7.Name = "pivotGridField7";
			// 
			// panelControl1
			// 
			this.panelControl1.Controls.Add(this.lkedtProductType);
			this.panelControl1.Controls.Add(this.label8);
			this.panelControl1.Controls.Add(this.lkedtBrandCode);
			this.panelControl1.Controls.Add(this.label7);
			this.panelControl1.Controls.Add(this.btnReset);
			this.panelControl1.Controls.Add(this.btnSearch);
			this.panelControl1.Controls.Add(this.label5);
			this.panelControl1.Controls.Add(this.txtStyleDesc);
			this.panelControl1.Controls.Add(this.label4);
			this.panelControl1.Controls.Add(this.txtStyleCode);
			this.panelControl1.Controls.Add(this.label3);
			this.panelControl1.Controls.Add(this.txtItemDesc);
			this.panelControl1.Controls.Add(this.label6);
			this.panelControl1.Controls.Add(this.txtItemCode);
			this.panelControl1.Location = new System.Drawing.Point(8, 40);
			this.panelControl1.Name = "panelControl1";
			this.panelControl1.Size = new System.Drawing.Size(960, 72);
			this.panelControl1.TabIndex = 64;
			this.panelControl1.Text = "panelControl1";
			// 
			// lkedtProductType
			// 
			this.lkedtProductType.EditValue = "";
			this.lkedtProductType.Location = new System.Drawing.Point(360, 40);
			this.lkedtProductType.Name = "lkedtProductType";
			// 
			// lkedtProductType.Properties
			// 
			this.lkedtProductType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkedtProductType.Size = new System.Drawing.Size(136, 20);
			this.lkedtProductType.TabIndex = 76;
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label8.Location = new System.Drawing.Point(264, 40);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(88, 16);
			this.label8.TabIndex = 75;
			this.label8.Text = "Product Type";
			// 
			// lkedtBrandCode
			// 
			this.lkedtBrandCode.EditValue = "";
			this.lkedtBrandCode.Location = new System.Drawing.Point(96, 40);
			this.lkedtBrandCode.Name = "lkedtBrandCode";
			// 
			// lkedtBrandCode.Properties
			// 
			this.lkedtBrandCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkedtBrandCode.Size = new System.Drawing.Size(136, 20);
			this.lkedtBrandCode.TabIndex = 74;
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label7.Location = new System.Drawing.Point(8, 40);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(80, 16);
			this.label7.TabIndex = 73;
			this.label7.Text = "Brand Code";
			// 
			// btnReset
			// 
			this.btnReset.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnReset.Location = new System.Drawing.Point(696, 40);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(72, 20);
			this.btnReset.TabIndex = 72;
			this.btnReset.Text = "Reset";
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// btnSearch
			// 
			this.btnSearch.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnSearch.Location = new System.Drawing.Point(616, 40);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(72, 20);
			this.btnSearch.TabIndex = 71;
			this.btnSearch.Text = "Search";
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.Location = new System.Drawing.Point(544, 8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(72, 16);
			this.label5.TabIndex = 70;
			this.label5.Text = "Style Desc";
			// 
			// txtStyleDesc
			// 
			this.txtStyleDesc.EditValue = "";
			this.txtStyleDesc.Location = new System.Drawing.Point(624, 8);
			this.txtStyleDesc.Name = "txtStyleDesc";
			this.txtStyleDesc.Size = new System.Drawing.Size(144, 20);
			this.txtStyleDesc.TabIndex = 69;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.Location = new System.Drawing.Point(376, 8);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(80, 16);
			this.label4.TabIndex = 68;
			this.label4.Text = "Style Code";
			// 
			// txtStyleCode
			// 
			this.txtStyleCode.EditValue = "";
			this.txtStyleCode.Location = new System.Drawing.Point(456, 8);
			this.txtStyleCode.Name = "txtStyleCode";
			this.txtStyleCode.Size = new System.Drawing.Size(80, 20);
			this.txtStyleCode.TabIndex = 67;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(160, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 16);
			this.label3.TabIndex = 66;
			this.label3.Text = "Item Desc";
			// 
			// txtItemDesc
			// 
			this.txtItemDesc.EditValue = "";
			this.txtItemDesc.Location = new System.Drawing.Point(232, 8);
			this.txtItemDesc.Name = "txtItemDesc";
			this.txtItemDesc.Size = new System.Drawing.Size(136, 20);
			this.txtItemDesc.TabIndex = 65;
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label6.Location = new System.Drawing.Point(8, 8);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(72, 16);
			this.label6.TabIndex = 64;
			this.label6.Text = "Item Code";
			// 
			// txtItemCode
			// 
			this.txtItemCode.EditValue = "";
			this.txtItemCode.Location = new System.Drawing.Point(80, 8);
			this.txtItemCode.Name = "txtItemCode";
			this.txtItemCode.Size = new System.Drawing.Size(80, 20);
			this.txtItemCode.TabIndex = 63;
			// 
			// RPStockSalon
			// 
			this.AutoScale = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(974, 548);
			this.Controls.Add(this.panelControl1);
			this.Controls.Add(this.GridStockRequest);
			this.Controls.Add(this.lkedtEmployee);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.DateFrom);
			this.Controls.Add(this.DateTo);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.DateRangeTo);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "RPStockSalon";
			this.Text = "Stock Inventory - Salon Use";
			this.Load += new System.EventHandler(this.RPStockSalon_Load);
			((System.ComponentModel.ISupportInitialize)(this.DateFrom.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DateRangeTo.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkedtEmployee.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GridStockRequest)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
			this.panelControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lkedtProductType.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkedtBrandCode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtStyleDesc.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtStyleCode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtItemDesc.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtItemCode.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region common
		private string ConvertToDateTime(object target)
		{
			if (target.ToString() == "" )
				return null;
			else
				return Convert.ToDateTime(target).ToString();
		}

		private int ConvertToInt(object target)
		{
			if (target.ToString() == "" )
				return 0;
			else
				return Convert.ToInt32(target);
		}
		
		#endregion

		private void LoadEmployeeList()
		{
			_ds = new DataSet(); 
			strSQL = "select nEmployeeID, strEmployeeName from tblEmployee where fSalesPerson=1";
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			dt = _ds.Tables["Table"];
			DevExpress.XtraEditors.Controls.LookUpColumnInfo[] col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
			col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nEmployeeID","Employee ID",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strEmployeeName","Name",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			myLookUpEdit = new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(lkedtEmployee.Properties,dt,col,"strEmployeeName","nEmployeeID","Stock");

		}
		
		private void LoadBrandCodeList()
		{
			_ds = new DataSet(); 
			strSQL = "select strBrandCode, strDescription from tblBrand";
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			dt = _ds.Tables["Table"];
			DevExpress.XtraEditors.Controls.LookUpColumnInfo[] col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
			col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strBrandCode","Branch Code",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription","Description",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			myLookUpEdit = new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(lkedtBrandCode.Properties,dt,col,"strDescription","strBrandCode","Stock");
		}

		private void LoadProductTypeList()
		{
			_ds = new DataSet(); 
			strSQL = "select nProductTypeID, strDescription from tblProductType";
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			dt = _ds.Tables["Table"];
			DevExpress.XtraEditors.Controls.LookUpColumnInfo[] col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
			col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nProductTypeID","Branch Code",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription","Description",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			myLookUpEdit = new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(lkedtProductType.Properties,dt,col,"strDescription","nProductTypeID","Stock");
		}

		private void GetDataFromDB()
		{
			strSQL = "select * from SV_tblSalonUse_WithDesc where nEmployeeID='" + lkedtEmployee.EditValue.ToString() + "' and dtDate between '" + Convert.ToDateTime(DateFrom.EditValue).ToString("MM/dd/yyyy") + "' and '" + Convert.ToDateTime(DateRangeTo.EditValue).ToString("MM/dd/yyy") + "'";
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds, new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dt = _ds.Tables["table"];
			dv = new DataView(dt);
			GridStockRequest.DataSource = dv;
		}

		private void FilterRecord()
		{
			string str;
			str = "nEmployeeID='" + lkedtEmployee.EditValue.ToString() + "'";
			
			if (this.txtItemCode.EditValue.ToString() != "")
				str += "And strProductCode like '%" + txtItemCode.EditValue + "%'";
	
			if (this.txtItemDesc.EditValue.ToString() != "")
				str += " And ProductDesc like '%" + txtItemDesc.EditValue + "%'";
				
			if (this.txtStyleCode.EditValue.ToString() != "")
				str += " And strStyleCode like '%" + txtStyleCode.EditValue + "%'";
	
			if (this.txtStyleDesc.EditValue.ToString() != "")
				str += " And StyleDesc like '%" + this.txtStyleDesc.EditValue + "%'";
			//lkedtBrandCode
			if (this.lkedtBrandCode.EditValue.ToString() != "")
				str += " And strBrandCode like '%" + this.lkedtBrandCode.EditValue + "%'";

			//lkedtProductType
			if (this.lkedtProductType.EditValue.ToString() != "")
				str += " And nProductTypeID like '%" + this.lkedtProductType.EditValue + "%'";

			
			dv.RowFilter = str;
			GridStockRequest.DataSource = dv;

		}

		private void RPStockSalon_Load(object sender, System.EventArgs e)
		{
			LoadEmployeeList();
			LoadBrandCodeList();
			LoadProductTypeList();
			GetDataFromDB();
		}

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			FilterRecord();		
		}

		private void DateFrom_EditValueChanged(object sender, System.EventArgs e)
		{
			GetDataFromDB();		
		}

		private void DateRangeTo_EditValueChanged(object sender, System.EventArgs e)
		{
			GetDataFromDB();
		}

		private void lkedtEmployee_EditValueChanged(object sender, System.EventArgs e)
		{
			GetDataFromDB();
		}

		private void btnReset_Click(object sender, System.EventArgs e)
		{
			txtItemCode.EditValue = "";
			txtItemDesc.EditValue = "";
			txtStyleCode.EditValue = "";
			txtStyleDesc.EditValue = "";
			lkedtBrandCode.EditValue = "";
			lkedtProductType.EditValue = "";
			GetDataFromDB();
			
			
		}

	}
}
