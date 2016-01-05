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
	/// Summary description for AccountsReport.
	/// </summary>
	public class RPAccountsReport : System.Windows.Forms.Form
	{
		private string connectionString;
		private SqlConnection connection;
		private DevExpress.XtraGrid.GridControl gridIPPNotSent;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn strBankCode;
		private DevExpress.XtraGrid.Columns.GridColumn nMonths;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private DevExpress.XtraEditors.ImageComboBoxEdit cmbIPPStatus;
		private System.Windows.Forms.Label label3;
		private DevExpress.XtraGrid.GridControl gridIPPNotCol;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
		private int EmployeeID;
		private bool isFinishBind = false;
		 


		public RPAccountsReport(int empID)
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
			this.gridIPPNotSent = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.strBankCode = new DevExpress.XtraGrid.Columns.GridColumn();
			this.nMonths = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.cmbIPPStatus = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.label3 = new System.Windows.Forms.Label();
			this.gridIPPNotCol = new DevExpress.XtraGrid.GridControl();
			this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
			((System.ComponentModel.ISupportInitialize)(this.gridIPPNotSent)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbIPPStatus.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridIPPNotCol)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
			this.SuspendLayout();
			// 
			// gridIPPNotSent
			// 
			// 
			// gridIPPNotSent.EmbeddedNavigator
			// 
			this.gridIPPNotSent.EmbeddedNavigator.Name = "";
			this.gridIPPNotSent.Location = new System.Drawing.Point(0, 48);
			this.gridIPPNotSent.MainView = this.gridView1;
			this.gridIPPNotSent.Name = "gridIPPNotSent";
			this.gridIPPNotSent.Size = new System.Drawing.Size(728, 184);
			this.gridIPPNotSent.TabIndex = 0;
			this.gridIPPNotSent.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										  this.gridView1});
			// 
			// gridView1
			// 
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn1,
																							 this.strBankCode,
																							 this.nMonths,
																							 this.gridColumn2,
																							 this.gridColumn3,
																							 this.gridColumn4,
																							 this.gridColumn5});
			this.gridView1.GridControl = this.gridIPPNotSent;
			this.gridView1.Name = "gridView1";
			this.gridView1.OptionsBehavior.Editable = false;
			this.gridView1.OptionsCustomization.AllowColumnMoving = false;
			this.gridView1.OptionsCustomization.AllowFilter = false;
			this.gridView1.OptionsCustomization.AllowSort = false;
			this.gridView1.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "IPP";
			this.gridColumn1.FieldName = "nIPPID";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 0;
			// 
			// strBankCode
			// 
			this.strBankCode.Caption = "Bank Code";
			this.strBankCode.FieldName = "strBankCode";
			this.strBankCode.Name = "strBankCode";
			this.strBankCode.Visible = true;
			this.strBankCode.VisibleIndex = 1;
			// 
			// nMonths
			// 
			this.nMonths.Caption = "No. of Months";
			this.nMonths.FieldName = "nMonths";
			this.nMonths.Name = "nMonths";
			this.nMonths.Visible = true;
			this.nMonths.VisibleIndex = 2;
			// 
			// gridColumn2
			// 
			this.gridColumn2.Caption = "Rate";
			this.gridColumn2.FieldName = "Rate";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 3;
			// 
			// gridColumn3
			// 
			this.gridColumn3.Caption = "Amount";
			this.gridColumn3.FieldName = "Amount";
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 4;
			// 
			// gridColumn4
			// 
			this.gridColumn4.Caption = "Interest";
			this.gridColumn4.FieldName = "Interest";
			this.gridColumn4.Name = "gridColumn4";
			this.gridColumn4.Visible = true;
			this.gridColumn4.VisibleIndex = 5;
			// 
			// gridColumn5
			// 
			this.gridColumn5.Caption = "Nett";
			this.gridColumn5.FieldName = "Nett";
			this.gridColumn5.Name = "gridColumn5";
			this.gridColumn5.Visible = true;
			this.gridColumn5.VisibleIndex = 6;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(-8, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(120, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "IPP Not Yet Sent";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.Location = new System.Drawing.Point(0, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "IPP Status";
			// 
			// cmbIPPStatus
			// 
			this.cmbIPPStatus.Location = new System.Drawing.Point(80, 8);
			this.cmbIPPStatus.Name = "cmbIPPStatus";
			// 
			// cmbIPPStatus.Properties
			// 
			this.cmbIPPStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cmbIPPStatus.Size = new System.Drawing.Size(112, 20);
			this.cmbIPPStatus.TabIndex = 4;
			this.cmbIPPStatus.SelectedValueChanged += new System.EventHandler(this.cmbIPPStatus_SelectedValueChanged);
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label3.Location = new System.Drawing.Point(-8, 240);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(144, 16);
			this.label3.TabIndex = 6;
			this.label3.Text = "IPP Not Yet Collected";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// gridIPPNotCol
			// 
			// 
			// gridIPPNotCol.EmbeddedNavigator
			// 
			this.gridIPPNotCol.EmbeddedNavigator.Name = "";
			this.gridIPPNotCol.Location = new System.Drawing.Point(0, 256);
			this.gridIPPNotCol.MainView = this.gridView2;
			this.gridIPPNotCol.Name = "gridIPPNotCol";
			this.gridIPPNotCol.Size = new System.Drawing.Size(728, 200);
			this.gridIPPNotCol.TabIndex = 5;
			this.gridIPPNotCol.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										 this.gridView2});
			// 
			// gridView2
			// 
			this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn7,
																							 this.gridColumn8,
																							 this.gridColumn9,
																							 this.gridColumn10,
																							 this.gridColumn11,
																							 this.gridColumn12,
																							 this.gridColumn13,
																							 this.gridColumn14});
			this.gridView2.GridControl = this.gridIPPNotCol;
			this.gridView2.Name = "gridView2";
			this.gridView2.OptionsBehavior.Editable = false;
			this.gridView2.OptionsCustomization.AllowColumnMoving = false;
			this.gridView2.OptionsCustomization.AllowFilter = false;
			this.gridView2.OptionsCustomization.AllowSort = false;
			this.gridView2.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn7
			// 
			this.gridColumn7.Caption = "IPP";
			this.gridColumn7.FieldName = "nIPPID";
			this.gridColumn7.Name = "gridColumn7";
			this.gridColumn7.Visible = true;
			this.gridColumn7.VisibleIndex = 0;
			// 
			// gridColumn8
			// 
			this.gridColumn8.Caption = "Bank Code";
			this.gridColumn8.FieldName = "strBankCode";
			this.gridColumn8.Name = "gridColumn8";
			this.gridColumn8.Visible = true;
			this.gridColumn8.VisibleIndex = 1;
			// 
			// gridColumn9
			// 
			this.gridColumn9.Caption = "No. of Months";
			this.gridColumn9.FieldName = "nMonths";
			this.gridColumn9.Name = "gridColumn9";
			this.gridColumn9.Visible = true;
			this.gridColumn9.VisibleIndex = 2;
			// 
			// gridColumn10
			// 
			this.gridColumn10.Caption = "Rate";
			this.gridColumn10.FieldName = "Rate";
			this.gridColumn10.Name = "gridColumn10";
			this.gridColumn10.Visible = true;
			this.gridColumn10.VisibleIndex = 3;
			// 
			// gridColumn11
			// 
			this.gridColumn11.Caption = "Amount";
			this.gridColumn11.FieldName = "Amount";
			this.gridColumn11.Name = "gridColumn11";
			this.gridColumn11.Visible = true;
			this.gridColumn11.VisibleIndex = 4;
			// 
			// gridColumn12
			// 
			this.gridColumn12.Caption = "Interest";
			this.gridColumn12.FieldName = "Interest";
			this.gridColumn12.Name = "gridColumn12";
			this.gridColumn12.Visible = true;
			this.gridColumn12.VisibleIndex = 5;
			// 
			// gridColumn13
			// 
			this.gridColumn13.Caption = "Nett";
			this.gridColumn13.FieldName = "Nett";
			this.gridColumn13.Name = "gridColumn13";
			this.gridColumn13.Visible = true;
			this.gridColumn13.VisibleIndex = 6;
			// 
			// gridColumn14
			// 
			this.gridColumn14.Caption = "Sent Date";
			this.gridColumn14.FieldName = "SentDate";
			this.gridColumn14.Name = "gridColumn14";
			this.gridColumn14.Visible = true;
			this.gridColumn14.VisibleIndex = 7;
			// 
			// RPAccountsReport
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(767, 485);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.gridIPPNotCol);
			this.Controls.Add(this.cmbIPPStatus);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.gridIPPNotSent);
			this.DockPadding.Bottom = 10;
			this.Name = "RPAccountsReport";
			this.Text = "Account Report";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.AccountsReport_Load);
			((System.ComponentModel.ISupportInitialize)(this.gridIPPNotSent)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbIPPStatus.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridIPPNotCol)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void cmbIPPStatus_SelectedValueChanged(object sender, System.EventArgs e)
		{
			LoadReport();
		}

		
        
		public void LoadReport()
		{
			if (!isFinishBind)
				return;

			string strSQL;
			DataSet _ds;

			//IPP Not Sent
			strSQL = "up_get_IPPReport " + EmployeeID;
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			DataTable dt = _ds.Tables["table"];
			DataView dv = new DataView(dt);

			dv.RowFilter = "SentDate is null";

			if (cmbIPPStatus.EditValue.ToString() != "")
				dv.RowFilter = " nIPPStatus = " + cmbIPPStatus.EditValue + " And SentDate is null";

			this.gridIPPNotSent.DataSource = dv;

			//IPP Not Sent
//			strSQL = "up_get_IPPReport " + EmployeeID;
//			_ds = new DataSet();
//			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
//			dt = _ds.Tables["table"];
			DataView dv2 = new DataView(dt);

			dv2.RowFilter = "SentDate is not null";

			if (cmbIPPStatus.EditValue.ToString() != "")
				dv.RowFilter = " nIPPStatus = " + cmbIPPStatus.EditValue + " And SentDate is not null";

			this.gridIPPNotCol.DataSource = dv2;
		}

		public enum IPPStatusEnum
		{
			New = 0,
			Sent = 1,
			Received = 2
			
		}

		private void BindIPPStatus()
		{
			DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox properties = cmbIPPStatus.Properties;
			properties.Items.BeginUpdate();
			properties.Items.Clear();
		
			try 
			{
			
				foreach(int s in Enum.GetValues(typeof(IPPStatusEnum)))
				{
					//Initialize each item with the display text, value and image index
					properties.Items.Add( new DevExpress.XtraEditors.Controls.ImageComboBoxItem(Enum.GetName(typeof(IPPStatusEnum),s),s.ToString()));
				}
			}
			finally 
			{
				properties.Items.EndUpdate();
			}
			//Select the first item
			this.cmbIPPStatus.SelectedIndex = 0;
		}

		private void AccountsReport_Load(object sender, System.EventArgs e)
		{
			isFinishBind = false;
			BindIPPStatus();
		    this.cmbIPPStatus.Properties.Items.Insert(0,new DevExpress.XtraEditors.Controls.ImageComboBoxItem("- Please Select -",""));
			cmbIPPStatus.SelectedIndex = 0;
			isFinishBind = true;
			LoadReport();
		}

	
	}
}
