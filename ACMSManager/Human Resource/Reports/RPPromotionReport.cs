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
	/// Summary description for PromotionReport.
	/// </summary>
	public class RPPromotionReport : System.Windows.Forms.Form
	{
		private string connectionString;
		private SqlConnection connection;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.DateEdit DateRangeTo;
		private DevExpress.XtraEditors.DateEdit DateFrom;
		private DevExpress.XtraPivotGrid.PivotGridControl GridPromotion;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField1;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField3;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField4;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private int EmployeeID;


		public RPPromotionReport(int empID)
		{
			//
			// Required for Windows Form Designer support
			//
			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);
			EmployeeID = empID;
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
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.DateRangeTo = new DevExpress.XtraEditors.DateEdit();
			this.DateFrom = new DevExpress.XtraEditors.DateEdit();
			this.GridPromotion = new DevExpress.XtraPivotGrid.PivotGridControl();
			this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField3 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField4 = new DevExpress.XtraPivotGrid.PivotGridField();
			((System.ComponentModel.ISupportInitialize)(this.DateRangeTo.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DateFrom.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GridPromotion)).BeginInit();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.Location = new System.Drawing.Point(144, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(24, 23);
			this.label2.TabIndex = 9;
			this.label2.Text = "To";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(0, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 23);
			this.label1.TabIndex = 8;
			this.label1.Text = "From";
			// 
			// DateRangeTo
			// 
			this.DateRangeTo.EditValue = null;
			this.DateRangeTo.Location = new System.Drawing.Point(168, 8);
			this.DateRangeTo.Name = "DateRangeTo";
			// 
			// DateRangeTo.Properties
			// 
			this.DateRangeTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.DateRangeTo.TabIndex = 7;
			this.DateRangeTo.EditValueChanged += new System.EventHandler(this.DateRangeTo_EditValueChanged);
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
			this.DateFrom.TabIndex = 6;
			this.DateFrom.EditValueChanged += new System.EventHandler(this.DateFrom_EditValueChanged);
			// 
			// GridPromotion
			// 
			this.GridPromotion.Cursor = System.Windows.Forms.Cursors.Default;
			this.GridPromotion.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
																								 this.pivotGridField1,
																								 this.pivotGridField3,
																								 this.pivotGridField4});
			this.GridPromotion.Location = new System.Drawing.Point(0, 32);
			this.GridPromotion.Name = "GridPromotion";
			this.GridPromotion.OptionsCustomization.AllowDrag = false;
			this.GridPromotion.OptionsCustomization.AllowExpand = false;
			this.GridPromotion.OptionsCustomization.AllowFilter = false;
			this.GridPromotion.OptionsCustomization.AllowSort = false;
			this.GridPromotion.OptionsView.ShowDataHeaders = false;
			this.GridPromotion.OptionsView.ShowFilterHeaders = false;
			this.GridPromotion.Size = new System.Drawing.Size(784, 336);
			this.GridPromotion.TabIndex = 5;
			// 
			// pivotGridField1
			// 
			this.pivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
			this.pivotGridField1.AreaIndex = 0;
			this.pivotGridField1.Caption = "Branch";
			this.pivotGridField1.FieldName = "strBranchCode";
			this.pivotGridField1.Name = "pivotGridField1";
			// 
			// pivotGridField3
			// 
			this.pivotGridField3.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
			this.pivotGridField3.AreaIndex = 0;
			this.pivotGridField3.Caption = "Description";
			this.pivotGridField3.FieldName = "strDescription";
			this.pivotGridField3.Name = "pivotGridField3";
			// 
			// pivotGridField4
			// 
			this.pivotGridField4.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
			this.pivotGridField4.AreaIndex = 0;
			this.pivotGridField4.Caption = "Total";
			this.pivotGridField4.FieldName = "nVoucherTypeID";
			this.pivotGridField4.Name = "pivotGridField4";
			this.pivotGridField4.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
			// 
			// RPPromotionReport
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(792, 453);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.DateRangeTo);
			this.Controls.Add(this.DateFrom);
			this.Controls.Add(this.GridPromotion);
			this.Name = "RPPromotionReport";
			this.Text = "Promotions Report";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.PromotionReport_Load);
			((System.ComponentModel.ISupportInitialize)(this.DateRangeTo.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DateFrom.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GridPromotion)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void PromotionReport_Load(object sender, System.EventArgs e)
		{
			DateFrom.EditValue = string.Format("{0:dd/MM/yyyy}",Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year));

			DateRangeTo.EditValue = DateTime.Today;
			LoadReport();
		}
		private void LoadReport()
		{
			string strSQL;
			DataSet _ds;

			// Total sales Collection
			strSQL = "Up_Get_VoucherPromotion " + EmployeeID;
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			DataTable dt = _ds.Tables["table"];
			DataView dv = new DataView(dt);

			string str = string.Format("dtDate >= '{0}' And dtDate < '{1}'",string.Format("{0:MM/dd/yyyy}",Convert.ToDateTime(DateFrom.EditValue)),string.Format("{0:MM/dd/yyyy}",Convert.ToDateTime(DateRangeTo.EditValue)));
			dv.RowFilter = str;

			this.GridPromotion.DataSource = dv;
		
		}

		private void DateFrom_EditValueChanged(object sender, System.EventArgs e)
		{
			LoadReport();
		}

		private void DateRangeTo_EditValueChanged(object sender, System.EventArgs e)
		{
			LoadReport();
		}
	}
}
