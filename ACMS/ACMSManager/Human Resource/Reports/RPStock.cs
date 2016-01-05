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
	/// Summary description for RPStock.
	/// </summary>
	public class RPStock : System.Windows.Forms.Form
	{
		private string connectionString;
		private SqlConnection connection;
		private DevExpress.XtraPivotGrid.PivotGridControl GridStockRequest;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField1;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField2;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField3;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField4;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField5;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField6;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField7;
		private DevExpress.XtraEditors.DateEdit DateFrom;
		private System.Windows.Forms.Label DateTo;
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.DateEdit DateRangeTo;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField8;
		private DevExpress.XtraEditors.TextEdit txtItemCode;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private DevExpress.XtraEditors.TextEdit txtItemDesc;
		private System.Windows.Forms.Label label4;
		private DevExpress.XtraEditors.TextEdit txtStyleCode;
		private System.Windows.Forms.Label label5;
		private DevExpress.XtraEditors.TextEdit txtStyleDesc;
		internal DevExpress.XtraEditors.SimpleButton btnSearch;
		internal DevExpress.XtraEditors.SimpleButton btnReset;
		private int EmployeeID;

		public RPStock(int empID)
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
			this.GridStockRequest = new DevExpress.XtraPivotGrid.PivotGridControl();
			this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField2 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField3 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField4 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField5 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField6 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField7 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField8 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.DateFrom = new DevExpress.XtraEditors.DateEdit();
			this.DateTo = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.DateRangeTo = new DevExpress.XtraEditors.DateEdit();
			this.txtItemCode = new DevExpress.XtraEditors.TextEdit();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtItemDesc = new DevExpress.XtraEditors.TextEdit();
			this.label4 = new System.Windows.Forms.Label();
			this.txtStyleCode = new DevExpress.XtraEditors.TextEdit();
			this.label5 = new System.Windows.Forms.Label();
			this.txtStyleDesc = new DevExpress.XtraEditors.TextEdit();
			this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
			this.btnReset = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.GridStockRequest)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DateFrom.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DateRangeTo.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtItemCode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtItemDesc.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtStyleCode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtStyleDesc.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// GridStockRequest
			// 
			this.GridStockRequest.Cursor = System.Windows.Forms.Cursors.Default;
			this.GridStockRequest.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
																									this.pivotGridField1,
																									this.pivotGridField2,
																									this.pivotGridField3,
																									this.pivotGridField4,
																									this.pivotGridField5,
																									this.pivotGridField6,
																									this.pivotGridField7,
																									this.pivotGridField8});
			this.GridStockRequest.Location = new System.Drawing.Point(0, 48);
			this.GridStockRequest.Name = "GridStockRequest";
			this.GridStockRequest.OptionsCustomization.AllowDrag = false;
			this.GridStockRequest.OptionsCustomization.AllowExpand = false;
			this.GridStockRequest.OptionsCustomization.AllowFilter = false;
			this.GridStockRequest.OptionsCustomization.AllowSort = false;
			this.GridStockRequest.OptionsView.ShowDataHeaders = false;
			this.GridStockRequest.OptionsView.ShowFilterHeaders = false;
			this.GridStockRequest.Size = new System.Drawing.Size(776, 336);
			this.GridStockRequest.TabIndex = 0;
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
			// pivotGridField2
			// 
			this.pivotGridField2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
			this.pivotGridField2.AreaIndex = 1;
			this.pivotGridField2.Caption = "Brand";
			this.pivotGridField2.FieldName = "strBrandCode";
			this.pivotGridField2.Name = "pivotGridField2";
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
			// pivotGridField6
			// 
			this.pivotGridField6.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
			this.pivotGridField6.AreaIndex = 0;
			this.pivotGridField6.Caption = "Branch";
			this.pivotGridField6.FieldName = "strBranchCodeFrom";
			this.pivotGridField6.Name = "pivotGridField6";
			// 
			// pivotGridField7
			// 
			this.pivotGridField7.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
			this.pivotGridField7.AreaIndex = 0;
			this.pivotGridField7.Caption = "Quantity";
			this.pivotGridField7.FieldName = "nQuantity";
			this.pivotGridField7.Name = "pivotGridField7";
			// 
			// pivotGridField8
			// 
			this.pivotGridField8.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
			this.pivotGridField8.AreaIndex = 5;
			this.pivotGridField8.Caption = "Item Desc";
			this.pivotGridField8.FieldName = "strDescription";
			this.pivotGridField8.Name = "pivotGridField8";
			this.pivotGridField8.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.True;
			// 
			// DateFrom
			// 
			this.DateFrom.EditValue = null;
			this.DateFrom.Location = new System.Drawing.Point(40, 0);
			this.DateFrom.Name = "DateFrom";
			// 
			// DateFrom.Properties
			// 
			this.DateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.DateFrom.Size = new System.Drawing.Size(80, 20);
			this.DateFrom.TabIndex = 9;
			// 
			// DateTo
			// 
			this.DateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.DateTo.Location = new System.Drawing.Point(128, 0);
			this.DateTo.Name = "DateTo";
			this.DateTo.Size = new System.Drawing.Size(24, 16);
			this.DateTo.TabIndex = 8;
			this.DateTo.Text = "To";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 16);
			this.label1.TabIndex = 7;
			this.label1.Text = "From";
			// 
			// DateRangeTo
			// 
			this.DateRangeTo.EditValue = null;
			this.DateRangeTo.Location = new System.Drawing.Point(160, 0);
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
			this.DateRangeTo.Size = new System.Drawing.Size(88, 20);
			this.DateRangeTo.TabIndex = 6;
			// 
			// txtItemCode
			// 
			this.txtItemCode.EditValue = "";
			this.txtItemCode.Location = new System.Drawing.Point(72, 24);
			this.txtItemCode.Name = "txtItemCode";
			this.txtItemCode.Size = new System.Drawing.Size(56, 20);
			this.txtItemCode.TabIndex = 10;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.Location = new System.Drawing.Point(0, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 11;
			this.label2.Text = "Item Code";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label3.Location = new System.Drawing.Point(136, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 16);
			this.label3.TabIndex = 13;
			this.label3.Text = "Item Desc";
			// 
			// txtItemDesc
			// 
			this.txtItemDesc.EditValue = "";
			this.txtItemDesc.Location = new System.Drawing.Point(208, 24);
			this.txtItemDesc.Name = "txtItemDesc";
			this.txtItemDesc.Size = new System.Drawing.Size(56, 20);
			this.txtItemDesc.TabIndex = 12;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label4.Location = new System.Drawing.Point(272, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 16);
			this.label4.TabIndex = 15;
			this.label4.Text = "Style Code";
			// 
			// txtStyleCode
			// 
			this.txtStyleCode.EditValue = "";
			this.txtStyleCode.Location = new System.Drawing.Point(344, 24);
			this.txtStyleCode.Name = "txtStyleCode";
			this.txtStyleCode.Size = new System.Drawing.Size(56, 20);
			this.txtStyleCode.TabIndex = 14;
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label5.Location = new System.Drawing.Point(400, 24);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(72, 16);
			this.label5.TabIndex = 17;
			this.label5.Text = "Style Desc";
			// 
			// txtStyleDesc
			// 
			this.txtStyleDesc.EditValue = "";
			this.txtStyleDesc.Location = new System.Drawing.Point(472, 24);
			this.txtStyleDesc.Name = "txtStyleDesc";
			this.txtStyleDesc.Size = new System.Drawing.Size(56, 20);
			this.txtStyleDesc.TabIndex = 16;
			// 
			// btnSearch
			// 
			this.btnSearch.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnSearch.Location = new System.Drawing.Point(536, 24);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(56, 20);
			this.btnSearch.TabIndex = 55;
			this.btnSearch.Text = "Search";
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// btnReset
			// 
			this.btnReset.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnReset.Location = new System.Drawing.Point(600, 24);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(56, 20);
			this.btnReset.TabIndex = 56;
			this.btnReset.Text = "Reset";
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// RPStock
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(808, 453);
			this.Controls.Add(this.btnReset);
			this.Controls.Add(this.btnSearch);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtStyleDesc);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtStyleCode);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtItemDesc);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtItemCode);
			this.Controls.Add(this.DateFrom);
			this.Controls.Add(this.DateTo);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.DateRangeTo);
			this.Controls.Add(this.GridStockRequest);
			this.Name = "RPStock";
			this.Text = "Stock Report";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.RPStock_Load);
			((System.ComponentModel.ISupportInitialize)(this.GridStockRequest)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DateFrom.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DateRangeTo.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtItemCode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtItemDesc.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtStyleCode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtStyleDesc.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		
		private void RPStock_Load(object sender, System.EventArgs e)
		{
			DateFrom.EditValue = string.Format("{0:dd/MM/yyyy}",Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year));

			DateRangeTo.EditValue = DateTime.Today;
			BindReport();
		}

		private void BindReport()
		{
			string strSQL;
			DataSet _ds;

			// first previous two month sales
			strSQL = "up_get_StockRequestList " + EmployeeID;
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds, new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			DataTable dt = _ds.Tables["table"];
			DataView dv = new DataView(dt);

			string str = string.Format("dtDate >= '{0}' And dtDate < '{1}'",string.Format("{0:MM/dd/yyyy}",Convert.ToDateTime(DateFrom.EditValue)),string.Format("{0:MM/dd/yyyy}",Convert.ToDateTime(DateRangeTo.EditValue)));
			
			
			if (this.txtItemCode.EditValue.ToString() != "")
				str += " And strProductCode like '%" + txtItemCode.EditValue + "%'";
	
			if (this.txtItemDesc.EditValue.ToString() != "")
				str += " And strDescription like '%" + txtItemDesc.EditValue + "%'";
				
			if (this.txtStyleCode.EditValue.ToString() != "")
				str += " And strStyleCode like '%" + txtStyleCode.EditValue + "%'";
	
			if (this.txtStyleDesc.EditValue.ToString() != "")
				str += " And StyleDesc like '%" + this.txtStyleDesc.EditValue + "%'";

			
			dv.RowFilter = str;

			this.GridStockRequest.DataSource = dv;
		}

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			BindReport();
		}

		private void btnReset_Click(object sender, System.EventArgs e)
		{
			DateFrom.EditValue = string.Format("{0:dd/MM/yyyy}",Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year));

			DateRangeTo.EditValue = DateTime.Today;

			this.txtItemCode.EditValue = "";
			this.txtItemDesc.EditValue = "";
			this.txtStyleCode.EditValue = "";
			this.txtStyleDesc.EditValue = "";
			BindReport();
											   
		}

	}
}
