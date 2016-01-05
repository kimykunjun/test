using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ACMSLogic.Staff;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;

namespace ACMS.ACMSManager.Reports
{
	/// <summary>
	/// Summary description for RPCommission.
	/// </summary>
	public class RPCommission : System.Windows.Forms.Form
	{
		private DataSet _ds;
		private string strSQL;
		private DataTable dt;
		private ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder myLookUpEdit;

		private string connectionString;
		private SqlConnection connection;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private DevExpress.XtraGrid.GridControl gridControl2;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
		private DevExpress.XtraEditors.ImageComboBoxEdit cmYear;
		private DevExpress.XtraEditors.ImageComboBoxEdit cmMonth;
		private DevExpress.XtraEditors.SimpleButton sbtnEnquiry;
		private DevExpress.XtraGrid.GridControl gcSalesCommission;
		private DevExpress.XtraTab.XtraTabControl tabRPCommission;
		private DevExpress.XtraEditors.LookUpEdit lkedtEmployee;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public RPCommission()
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
			this.tabRPCommission = new DevExpress.XtraTab.XtraTabControl();
			this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
			this.gcSalesCommission = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
			this.gridControl2 = new DevExpress.XtraGrid.GridControl();
			this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.cmYear = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.cmMonth = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.label3 = new System.Windows.Forms.Label();
			this.sbtnEnquiry = new DevExpress.XtraEditors.SimpleButton();
			this.lkedtEmployee = new DevExpress.XtraEditors.LookUpEdit();
			((System.ComponentModel.ISupportInitialize)(this.tabRPCommission)).BeginInit();
			this.tabRPCommission.SuspendLayout();
			this.xtraTabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gcSalesCommission)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			this.xtraTabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmYear.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmMonth.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkedtEmployee.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// tabRPCommission
			// 
			this.tabRPCommission.Location = new System.Drawing.Point(6, 40);
			this.tabRPCommission.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.tabRPCommission.LookAndFeel.UseDefaultLookAndFeel = false;
			this.tabRPCommission.Name = "tabRPCommission";
			this.tabRPCommission.SelectedTabPage = this.xtraTabPage1;
			this.tabRPCommission.Size = new System.Drawing.Size(960, 424);
			this.tabRPCommission.TabIndex = 1;
			this.tabRPCommission.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
																							this.xtraTabPage1,
																							this.xtraTabPage2});
			this.tabRPCommission.Text = "xtraTabControl1";
			// 
			// xtraTabPage1
			// 
			this.xtraTabPage1.Controls.Add(this.gcSalesCommission);
			this.xtraTabPage1.Name = "xtraTabPage1";
			this.xtraTabPage1.Size = new System.Drawing.Size(954, 398);
			this.xtraTabPage1.Text = "Sales Commission";
			// 
			// gcSalesCommission
			// 
			this.gcSalesCommission.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// gcSalesCommission.EmbeddedNavigator
			// 
			this.gcSalesCommission.EmbeddedNavigator.Name = "";
			this.gcSalesCommission.Location = new System.Drawing.Point(0, 0);
			this.gcSalesCommission.MainView = this.gridView1;
			this.gcSalesCommission.Name = "gcSalesCommission";
			this.gcSalesCommission.Size = new System.Drawing.Size(954, 398);
			this.gcSalesCommission.TabIndex = 1;
			this.gcSalesCommission.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																											 this.gridView1});
			// 
			// gridView1
			// 
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn1,
																							 this.gridColumn2});
			this.gridView1.GridControl = this.gcSalesCommission;
			this.gridView1.Name = "gridView1";
			this.gridView1.OptionsBehavior.Editable = false;
			this.gridView1.OptionsCustomization.AllowFilter = false;
			this.gridView1.OptionsCustomization.AllowSort = false;
			this.gridView1.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "Commission Code";
			this.gridColumn1.FieldName = "strCommission";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 0;
			// 
			// gridColumn2
			// 
			this.gridColumn2.Caption = "Amount";
			this.gridColumn2.FieldName = "mTotalCommission";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 1;
			// 
			// xtraTabPage2
			// 
			this.xtraTabPage2.Controls.Add(this.gridControl2);
			this.xtraTabPage2.Name = "xtraTabPage2";
			this.xtraTabPage2.Size = new System.Drawing.Size(954, 398);
			this.xtraTabPage2.Text = "Service Commission";
			// 
			// gridControl2
			// 
			this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// gridControl2.EmbeddedNavigator
			// 
			this.gridControl2.EmbeddedNavigator.Name = "";
			this.gridControl2.Location = new System.Drawing.Point(0, 0);
			this.gridControl2.MainView = this.gridView2;
			this.gridControl2.Name = "gridControl2";
			this.gridControl2.Size = new System.Drawing.Size(954, 398);
			this.gridControl2.TabIndex = 2;
			this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										this.gridView2});
			// 
			// gridView2
			// 
			this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn8,
																							 this.gridColumn10,
																							 this.gridColumn12,
																							 this.gridColumn13,
																							 this.gridColumn14});
			this.gridView2.GridControl = this.gridControl2;
			this.gridView2.Name = "gridView2";
			this.gridView2.OptionsBehavior.Editable = false;
			this.gridView2.OptionsCustomization.AllowFilter = false;
			this.gridView2.OptionsCustomization.AllowSort = false;
			this.gridView2.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn8
			// 
			this.gridColumn8.Caption = "Date";
			this.gridColumn8.FieldName = "dtDate";
			this.gridColumn8.Name = "gridColumn8";
			this.gridColumn8.Visible = true;
			this.gridColumn8.VisibleIndex = 0;
			this.gridColumn8.Width = 85;
			// 
			// gridColumn10
			// 
			this.gridColumn10.Caption = "Branch";
			this.gridColumn10.FieldName = "strBranchCode";
			this.gridColumn10.Name = "gridColumn10";
			this.gridColumn10.Visible = true;
			this.gridColumn10.VisibleIndex = 1;
			this.gridColumn10.Width = 89;
			// 
			// gridColumn12
			// 
			this.gridColumn12.Caption = "Service Code";
			this.gridColumn12.FieldName = "strServiceCode";
			this.gridColumn12.Name = "gridColumn12";
			this.gridColumn12.Visible = true;
			this.gridColumn12.VisibleIndex = 2;
			this.gridColumn12.Width = 90;
			// 
			// gridColumn13
			// 
			this.gridColumn13.Caption = "Service Description";
			this.gridColumn13.FieldName = "strDescription";
			this.gridColumn13.Name = "gridColumn13";
			this.gridColumn13.Visible = true;
			this.gridColumn13.VisibleIndex = 3;
			this.gridColumn13.Width = 93;
			// 
			// gridColumn14
			// 
			this.gridColumn14.Caption = "Commission Amount";
			this.gridColumn14.FieldName = "mCommission";
			this.gridColumn14.Name = "gridColumn14";
			this.gridColumn14.Visible = true;
			this.gridColumn14.VisibleIndex = 4;
			this.gridColumn14.Width = 78;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(16, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "Year";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(208, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "Month";
			// 
			// cmYear
			// 
			this.cmYear.Location = new System.Drawing.Point(80, 8);
			this.cmYear.Name = "cmYear";
			// 
			// cmYear.Properties
			// 
			this.cmYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																										   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cmYear.Properties.Items.AddRange(new object[] {
																   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("2010", 2010, -1),
																   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("2011", 2011, -1),
																   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("2012", 2012, -1),
																   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("2013", 2013, -1)});
			this.cmYear.TabIndex = 4;
			// 
			// cmMonth
			// 
			this.cmMonth.Location = new System.Drawing.Point(272, 8);
			this.cmMonth.Name = "cmMonth";
			// 
			// cmMonth.Properties
			// 
			this.cmMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cmMonth.Properties.Items.AddRange(new object[] {
																	new DevExpress.XtraEditors.Controls.ImageComboBoxItem("1", 1, -1),
																	new DevExpress.XtraEditors.Controls.ImageComboBoxItem("2", 2, -1),
																	new DevExpress.XtraEditors.Controls.ImageComboBoxItem("3", 3, -1),
																	new DevExpress.XtraEditors.Controls.ImageComboBoxItem("4", 4, -1),
																	new DevExpress.XtraEditors.Controls.ImageComboBoxItem("5", 5, -1),
																	new DevExpress.XtraEditors.Controls.ImageComboBoxItem("6", 6, -1),
																	new DevExpress.XtraEditors.Controls.ImageComboBoxItem("7", 7, -1),
																	new DevExpress.XtraEditors.Controls.ImageComboBoxItem("8", 8, -1),
																	new DevExpress.XtraEditors.Controls.ImageComboBoxItem("9", 9, -1),
																	new DevExpress.XtraEditors.Controls.ImageComboBoxItem("10", 10, -1),
																	new DevExpress.XtraEditors.Controls.ImageComboBoxItem("11", 11, -1),
																	new DevExpress.XtraEditors.Controls.ImageComboBoxItem("12", 12, -1)});
			this.cmMonth.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(400, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 23);
			this.label3.TabIndex = 6;
			this.label3.Text = "Employee";
			// 
			// sbtnEnquiry
			// 
			this.sbtnEnquiry.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.sbtnEnquiry.Appearance.Options.UseFont = true;
			this.sbtnEnquiry.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnEnquiry.Location = new System.Drawing.Point(672, 8);
			this.sbtnEnquiry.Name = "sbtnEnquiry";
			this.sbtnEnquiry.TabIndex = 8;
			this.sbtnEnquiry.Text = "Enquiry";
			this.sbtnEnquiry.Click += new System.EventHandler(this.sbtnEnquiry_Click);
			// 
			// lkedtEmployee
			// 
			this.lkedtEmployee.EditValue = "";
			this.lkedtEmployee.Location = new System.Drawing.Point(472, 8);
			this.lkedtEmployee.Name = "lkedtEmployee";
			// 
			// lkedtEmployee.Properties
			// 
			this.lkedtEmployee.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkedtEmployee.Size = new System.Drawing.Size(184, 20);
			this.lkedtEmployee.TabIndex = 16;
			// 
			// RPCommission
			// 
			this.AutoScale = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(978, 472);
			this.Controls.Add(this.lkedtEmployee);
			this.Controls.Add(this.sbtnEnquiry);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cmMonth);
			this.Controls.Add(this.cmYear);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tabRPCommission);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "RPCommission";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.Text = "Commission";
			this.Load += new System.EventHandler(this.RPCommission_Load);
			((System.ComponentModel.ISupportInitialize)(this.tabRPCommission)).EndInit();
			this.tabRPCommission.ResumeLayout(false);
			this.xtraTabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gcSalesCommission)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			this.xtraTabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmYear.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmMonth.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkedtEmployee.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void RPCommission_Load(object sender, System.EventArgs e)
		{
			LoadEmployeeList();
		}

		private void GetSalesCommDataFromDB()
		{
			string strSQL;
			DataSet _ds;
			_ds = new DataSet();

			strSQL="select nPayrollID,nEmployeeID,strCommissionCode,mTotalCommission from tblPayrollSalesCommDetails where nPayrollID in (select nPayrollID from tblPayroll where nyear='" + cmYear.EditValue.ToString() + "' and nmonth='" + cmMonth.EditValue.ToString() + "' and nEmployeeID='" + lkedtEmployee.EditValue.ToString() + "')";
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			gcSalesCommission.DataSource = _ds.Tables["table"];
			
		}

		private void GetServiceCommDataFromDB()
		{
			string strSQL;
			DataSet _ds;
			_ds = new DataSet();

			strSQL="select nPayrollID,nEmployeeID,dtDate,strBranchCode,strServiceCode,mCommission from sv_tblPayrollServiceCommDetails where nPayrollID in (select nPayrollID from tblPayroll where nyear='" + cmYear.EditValue.ToString() + "' and nmonth='" + cmMonth.EditValue.ToString() + "' and nEmployeeID='" + lkedtEmployee.EditValue.ToString() + "')";
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			gcSalesCommission.DataSource = _ds.Tables["table"];
			
		}

		private void LoadEmployeeList()
		{
			_ds = new DataSet(); 
			strSQL = "select nEmployeeID, strEmployeeName from tblEmployee";
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			dt = _ds.Tables["Table"];
			DevExpress.XtraEditors.Controls.LookUpColumnInfo[] col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
			col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nEmployeeID","Employee ID",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strEmployeeName","Name",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			myLookUpEdit = new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(lkedtEmployee.Properties,dt,col,"strEmployeeName","nEmployeeID","Stock");

		}

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
		
		private void sbtnEnquiry_Click(object sender, System.EventArgs e)
		{
			if ( tabRPCommission.SelectedTabPageIndex==0)
			{
				GetSalesCommDataFromDB();
				
			}
			else
			{
				GetServiceCommDataFromDB();
			}

		}

		#endregion


	}
}
