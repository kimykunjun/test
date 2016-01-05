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
        private IContainer components;
        private ACMS.Dataset.DSPromotion dSPromotion;
        private BindingSource tblReceiptPromotionBindingSource;
        private ACMS.Dataset.DSPromotionTableAdapters.tblReceiptPromotionTableAdapter tblReceiptPromotionTableAdapter;
        private DevExpress.XtraGrid.GridControl GridPromotion;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraGrid.Columns.GridColumn MembershipID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
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
            this.components = new System.ComponentModel.Container();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DateRangeTo = new DevExpress.XtraEditors.DateEdit();
            this.DateFrom = new DevExpress.XtraEditors.DateEdit();
            this.dSPromotion = new ACMS.Dataset.DSPromotion();
            this.tblReceiptPromotionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblReceiptPromotionTableAdapter = new ACMS.Dataset.DSPromotionTableAdapters.tblReceiptPromotionTableAdapter();
            this.GridPromotion = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.MembershipID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DateRangeTo.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateRangeTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateFrom.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSPromotion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblReceiptPromotionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridPromotion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(144, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 23);
            this.label2.TabIndex = 9;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(0, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 23);
            this.label1.TabIndex = 8;
            this.label1.Text = "From";
            // 
            // DateRangeTo
            // 
            this.DateRangeTo.EditValue = null;
            this.DateRangeTo.Location = new System.Drawing.Point(174, 8);
            this.DateRangeTo.Name = "DateRangeTo";
            this.DateRangeTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateRangeTo.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.DateRangeTo.Size = new System.Drawing.Size(97, 20);
            this.DateRangeTo.TabIndex = 7;
            this.DateRangeTo.EditValueChanged += new System.EventHandler(this.DateRangeTo_EditValueChanged);
            // 
            // DateFrom
            // 
            this.DateFrom.EditValue = null;
            this.DateFrom.Location = new System.Drawing.Point(40, 8);
            this.DateFrom.Name = "DateFrom";
            this.DateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateFrom.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.DateFrom.Size = new System.Drawing.Size(100, 20);
            this.DateFrom.TabIndex = 6;
            this.DateFrom.EditValueChanged += new System.EventHandler(this.DateFrom_EditValueChanged);
            // 
            // dSPromotion
            // 
            this.dSPromotion.DataSetName = "DSPromotion";
            this.dSPromotion.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblReceiptPromotionTableAdapter
            // 
            this.tblReceiptPromotionTableAdapter.ClearBeforeFill = true;
            // 
            // GridPromotion
            // 
            this.GridPromotion.DataSource = this.tblReceiptPromotionBindingSource;
            this.GridPromotion.Location = new System.Drawing.Point(3, 58);
            this.GridPromotion.MainView = this.gridView1;
            this.GridPromotion.Name = "GridPromotion";
            this.GridPromotion.Size = new System.Drawing.Size(787, 391);
            this.GridPromotion.TabIndex = 10;
            this.GridPromotion.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView2});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.MembershipID,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7});
            this.gridView1.GridControl = this.GridPromotion;
            this.gridView1.Name = "gridView1";
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.GridPromotion;
            this.gridView2.Name = "gridView2";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Date";
            this.gridColumn1.FieldName = "dtDate";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Receipt";
            this.gridColumn2.FieldName = "strReceiptNo";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(302, 5);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 11;
            this.simpleButton1.Text = "Generate";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // MembershipID
            // 
            this.MembershipID.Caption = "Membership ID";
            this.MembershipID.FieldName = "strMembershipID";
            this.MembershipID.Name = "MembershipID";
            this.MembershipID.Visible = true;
            this.MembershipID.VisibleIndex = 2;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Description";
            this.gridColumn3.FieldName = "strPromotion";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Sales Person";
            this.gridColumn4.FieldName = "strEmployeeName";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Type";
            this.gridColumn5.FieldName = "strType";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Paid";
            this.gridColumn6.FieldName = "Paid";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Discount";
            this.gridColumn7.FieldName = "Discount";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 7;
            // 
            // RPPromotionReport
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 453);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.GridPromotion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DateRangeTo);
            this.Controls.Add(this.DateFrom);
            this.Name = "RPPromotionReport";
            this.Text = "Promotions Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PromotionReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DateRangeTo.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateRangeTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateFrom.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSPromotion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblReceiptPromotionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridPromotion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void PromotionReport_Load(object sender, System.EventArgs e)
		{
            // TODO: This line of code loads data into the 'dSPromotion.tblReceiptPromotion' table. You can move, or remove it, as needed.
            
			DateFrom.EditValue = string.Format("{0:dd/MM/yyyy}",Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year));

			DateRangeTo.EditValue = DateTime.Today;			
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


            this.tblReceiptPromotionTableAdapter.Fill(this.dSPromotion.tblReceiptPromotion, Convert.ToDateTime(DateRangeTo.EditValue), Convert.ToDateTime(DateFrom.EditValue));
           this.GridPromotion.DataSource = this.dSPromotion.tblReceiptPromotion;
		
		}

		private void DateFrom_EditValueChanged(object sender, System.EventArgs e)
		{
			//LoadReport();
		}

		private void DateRangeTo_EditValueChanged(object sender, System.EventArgs e)
		{
			//LoadReport();
		}

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            LoadReport();
        }
	}
}
