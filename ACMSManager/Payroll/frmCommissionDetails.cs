using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;
using Do = Acms.Core.Domain;
using ACMSLogic;

namespace ACMS.ACMSManager.Payroll
{
	/// <summary>
	/// Summary description for frmCommissionDetails.
	/// </summary>
	
	public class frmCommissionDetails : System.Windows.Forms.Form
	{
		private DataTable dt1;
		private DataTable dt2;
		private DataTable dt3;

		private string connectionString;
		private SqlConnection connection;
		//private Do.Employee employee;
		//private Do.TerminalUser terminalUser; 
		//private static User oUser;
		public DevExpress.XtraGrid.GridControl gridControl1;
		public DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		public DevExpress.XtraGrid.GridControl gridControl2;
		public DevExpress.XtraGrid.Views.Grid.GridView gridView2;
		public DevExpress.XtraGrid.GridControl gridControl3;
		public DevExpress.XtraGrid.Views.Grid.GridView gridView3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_nCommGroup;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DataTable dtSalesComm
		{
			get
			{
				return dt2;
			}
			set
			{
				dt2 = value;
			}
		}

		public DataTable dtPTServiceComm
		{
			get
			{
				return dt3;
			}
			set
			{
				dt3 = value;
			}
		}

		public DataTable dtSPAServiceComm
		{
			get
			{
				return dt1;
			}
			set
			{
				dt1 = value;
			}
		}

		public frmCommissionDetails()
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
			this.gridControl1 = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridControl2 = new DevExpress.XtraGrid.GridControl();
			this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridControl3 = new DevExpress.XtraGrid.GridControl();
			this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.lk_nCommGroup = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_nCommGroup)).BeginInit();
			this.SuspendLayout();
			// 
			// gridControl1
			// 
			// 
			// gridControl1.EmbeddedNavigator
			// 
			this.gridControl1.EmbeddedNavigator.Name = "";
			this.gridControl1.Location = new System.Drawing.Point(0, 32);
			this.gridControl1.MainView = this.gridView1;
			this.gridControl1.Name = "gridControl1";
			this.gridControl1.Size = new System.Drawing.Size(616, 120);
			this.gridControl1.TabIndex = 1;
			this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										this.gridView1});
			// 
			// gridView1
			// 
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn1,
																							 this.gridColumn2,
																							 this.gridColumn3,
																							 this.gridColumn15,
																							 this.gridColumn4});
			this.gridView1.GridControl = this.gridControl1;
			this.gridView1.Name = "gridView1";
			this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
			this.gridView1.OptionsCustomization.AllowFilter = false;
			this.gridView1.OptionsCustomization.AllowGroup = false;
			this.gridView1.OptionsView.ColumnAutoWidth = false;
			this.gridView1.OptionsView.ShowGroupPanel = false;
			this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "Date";
			this.gridColumn1.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.gridColumn1.FieldName = "dtDate";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.OptionsColumn.AllowEdit = false;
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 0;
			this.gridColumn1.Width = 77;
			// 
			// gridColumn2
			// 
			this.gridColumn2.Caption = "Branch";
			this.gridColumn2.DisplayFormat.FormatString = "strBranchCode";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.OptionsColumn.AllowEdit = false;
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 1;
			this.gridColumn2.Width = 92;
			// 
			// gridColumn3
			// 
			this.gridColumn3.Caption = "Membership ID";
			this.gridColumn3.FieldName = "nMembershipID";
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.OptionsColumn.AllowEdit = false;
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 2;
			this.gridColumn3.Width = 106;
			// 
			// gridColumn15
			// 
			this.gridColumn15.Caption = "Transaction Code";
			this.gridColumn15.FieldName = "strServiceCode";
			this.gridColumn15.Name = "gridColumn15";
			this.gridColumn15.OptionsColumn.AllowEdit = false;
			this.gridColumn15.Visible = true;
			this.gridColumn15.VisibleIndex = 3;
			this.gridColumn15.Width = 135;
			// 
			// gridColumn4
			// 
			this.gridColumn4.AppearanceCell.BackColor = System.Drawing.SystemColors.Control;
			this.gridColumn4.AppearanceCell.Options.UseBackColor = true;
			this.gridColumn4.AppearanceHeader.BackColor = System.Drawing.SystemColors.Control;
			this.gridColumn4.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.gridColumn4.AppearanceHeader.Options.UseBackColor = true;
			this.gridColumn4.AppearanceHeader.Options.UseFont = true;
			this.gridColumn4.Caption = "Commission";
			this.gridColumn4.DisplayFormat.FormatString = "f2";
			this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.gridColumn4.FieldName = "mCommission";
			this.gridColumn4.Name = "gridColumn4";
			this.gridColumn4.Visible = true;
			this.gridColumn4.VisibleIndex = 4;
			this.gridColumn4.Width = 190;
			// 
			// gridControl2
			// 
			// 
			// gridControl2.EmbeddedNavigator
			// 
			this.gridControl2.EmbeddedNavigator.Name = "";
			this.gridControl2.Location = new System.Drawing.Point(0, 184);
			this.gridControl2.MainView = this.gridView2;
			this.gridControl2.Name = "gridControl2";
			this.gridControl2.Size = new System.Drawing.Size(616, 136);
			this.gridControl2.TabIndex = 2;
			this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										this.gridView2});
			// 
			// gridView2
			// 
			this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn8,
																							 this.gridColumn5,
																							 this.gridColumn6,
																							 this.gridColumn16,
																							 this.gridColumn7});
			this.gridView2.GridControl = this.gridControl2;
			this.gridView2.Name = "gridView2";
			this.gridView2.OptionsBehavior.AutoExpandAllGroups = true;
			this.gridView2.OptionsCustomization.AllowFilter = false;
			this.gridView2.OptionsCustomization.AllowGroup = false;
			this.gridView2.OptionsView.ColumnAutoWidth = false;
			this.gridView2.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn8
			// 
			this.gridColumn8.Caption = "Date";
			this.gridColumn8.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.gridColumn8.FieldName = "dtDate";
			this.gridColumn8.Name = "gridColumn8";
			this.gridColumn8.OptionsColumn.AllowEdit = false;
			this.gridColumn8.Visible = true;
			this.gridColumn8.VisibleIndex = 0;
			this.gridColumn8.Width = 80;
			// 
			// gridColumn5
			// 
			this.gridColumn5.Caption = "Branch";
			this.gridColumn5.FieldName = "strBranchCode";
			this.gridColumn5.Name = "gridColumn5";
			this.gridColumn5.OptionsColumn.AllowEdit = false;
			this.gridColumn5.Visible = true;
			this.gridColumn5.VisibleIndex = 1;
			this.gridColumn5.Width = 96;
			// 
			// gridColumn6
			// 
			this.gridColumn6.Caption = "Membership ID";
			this.gridColumn6.FieldName = "strMembershipID";
			this.gridColumn6.Name = "gridColumn6";
			this.gridColumn6.OptionsColumn.AllowEdit = false;
			this.gridColumn6.Visible = true;
			this.gridColumn6.VisibleIndex = 2;
			this.gridColumn6.Width = 98;
			// 
			// gridColumn16
			// 
			this.gridColumn16.Caption = "Transaction Code";
			this.gridColumn16.FieldName = "strServiceCode";
			this.gridColumn16.Name = "gridColumn16";
			this.gridColumn16.OptionsColumn.AllowEdit = false;
			this.gridColumn16.Visible = true;
			this.gridColumn16.VisibleIndex = 3;
			this.gridColumn16.Width = 135;
			// 
			// gridColumn7
			// 
			this.gridColumn7.AppearanceCell.BackColor = System.Drawing.SystemColors.Control;
			this.gridColumn7.AppearanceCell.Options.UseBackColor = true;
			this.gridColumn7.AppearanceHeader.BackColor = System.Drawing.SystemColors.Control;
			this.gridColumn7.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.gridColumn7.AppearanceHeader.Options.UseBackColor = true;
			this.gridColumn7.AppearanceHeader.Options.UseFont = true;
			this.gridColumn7.Caption = "Commission";
			this.gridColumn7.FieldName = "mCommission";
			this.gridColumn7.Name = "gridColumn7";
			this.gridColumn7.Visible = true;
			this.gridColumn7.VisibleIndex = 4;
			this.gridColumn7.Width = 190;
			// 
			// gridControl3
			// 
			// 
			// gridControl3.EmbeddedNavigator
			// 
			this.gridControl3.EmbeddedNavigator.Name = "";
			this.gridControl3.Location = new System.Drawing.Point(0, 349);
			this.gridControl3.MainView = this.gridView3;
			this.gridControl3.Name = "gridControl3";
			this.gridControl3.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																												  this.lk_nCommGroup});
			this.gridControl3.Size = new System.Drawing.Size(616, 136);
			this.gridControl3.TabIndex = 3;
			this.gridControl3.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										this.gridView3});
			// 
			// gridView3
			// 
			this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn9,
																							 this.gridColumn14,
																							 this.gridColumn10,
																							 this.gridColumn11});
			this.gridView3.GridControl = this.gridControl3;
			this.gridView3.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
			this.gridView3.Name = "gridView3";
			this.gridView3.OptionsBehavior.AutoExpandAllGroups = true;
			this.gridView3.OptionsCustomization.AllowFilter = false;
			this.gridView3.OptionsCustomization.AllowGroup = false;
			this.gridView3.OptionsView.ColumnAutoWidth = false;
			this.gridView3.OptionsView.ShowGroupPanel = false;
			this.gridView3.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView3_CellValueChanged);
			// 
			// gridColumn9
			// 
			this.gridColumn9.Caption = "Commission Code";
			this.gridColumn9.ColumnEdit = this.lk_nCommGroup;
			this.gridColumn9.FieldName = "strCommissionCode";
			this.gridColumn9.Name = "gridColumn9";
			this.gridColumn9.OptionsColumn.AllowEdit = false;
			this.gridColumn9.Visible = true;
			this.gridColumn9.VisibleIndex = 0;
			this.gridColumn9.Width = 304;
			// 
			// lk_nCommGroup
			// 
			this.lk_nCommGroup.AutoHeight = false;
			this.lk_nCommGroup.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																									   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lk_nCommGroup.Name = "lk_nCommGroup";
			// 
			// gridColumn14
			// 
			this.gridColumn14.AppearanceCell.BackColor = System.Drawing.SystemColors.Control;
			this.gridColumn14.AppearanceCell.Options.UseBackColor = true;
			this.gridColumn14.AppearanceHeader.BackColor = System.Drawing.SystemColors.Control;
			this.gridColumn14.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.gridColumn14.AppearanceHeader.Options.UseBackColor = true;
			this.gridColumn14.AppearanceHeader.Options.UseFont = true;
			this.gridColumn14.Caption = "Total Commission";
			this.gridColumn14.DisplayFormat.FormatString = "f2";
			this.gridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.gridColumn14.FieldName = "mTotalCommission";
			this.gridColumn14.Name = "gridColumn14";
			this.gridColumn14.Visible = true;
			this.gridColumn14.VisibleIndex = 1;
			this.gridColumn14.Width = 294;
			// 
			// gridColumn10
			// 
			this.gridColumn10.Caption = "gridColumn10";
			this.gridColumn10.FieldName = "nPayrollID";
			this.gridColumn10.Name = "gridColumn10";
			// 
			// gridColumn11
			// 
			this.gridColumn11.Caption = "gridColumn11";
			this.gridColumn11.FieldName = "nEmployeeID";
			this.gridColumn11.Name = "gridColumn11";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(8, 160);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(224, 23);
			this.label1.TabIndex = 4;
			this.label1.Text = "SPA Service Commission";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(8, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(224, 23);
			this.label2.TabIndex = 5;
			this.label2.Text = "PT Service Commission";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(8, 328);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(224, 23);
			this.label3.TabIndex = 6;
			this.label3.Text = "Sales Commission";
			// 
			// frmCommissionDetails
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(632, 485);
			this.Controls.Add(this.gridControl2);
			this.Controls.Add(this.gridControl3);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.gridControl1);
			this.MaximizeBox = false;
			this.Name = "frmCommissionDetails";
			this.Text = "Employee Commission";
			this.Load += new System.EventHandler(this.frmCommissionDetails_Load);
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_nCommGroup)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
		{
			//int output;
			if ( e.Column.Name == "mCommission")
			{
				DataRow drDetl = gridView1.GetDataRow(gridView1.FocusedRowHandle);
/*				SqlHelper.ExecuteNonQuery(connection,"UP_tblPayrollPTServiceCommDetails",
					new SqlParameter("@RET_VAL",output),
					new SqlParameter("@CMD","U"),
					new SqlParameter("@nPayrollID",nPayrollID),
					new SqlParameter("@nEmployeeID",Convert.ToInt32(drDetl["nEmplyeeID"])),
					new SqlParameter("@dtDate",Convert.ToDateTime(drDetl["dtDate"])),
					new SqlParameter("@strBranchCode",drDetl["strBranchCode"].ToString()),
					new SqlParameter("@strServiceCode",drDetl["strServiceCode"].ToString()),
					new SqlParameter("@mCommission",Convert.ToDecimal(drDetl["mCommission"]))
					);
*/
			}
		}

		private void gridView3_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
		{
			DataRow drDetl = gridView3.GetDataRow(e.RowHandle);
			int output=0;
			if ( drDetl != null)
			{
				SqlHelper.ExecuteNonQuery(connection,"UP_tblPayrollSalesCommDetails",
					new SqlParameter("@RET_VAL",output),
					new SqlParameter("@CMD","U"),
					new SqlParameter("@nPayrollID",drDetl["nPayrollID"]),
					new SqlParameter("@nEmployeeID",drDetl["nEmployeeID"]),
					new SqlParameter("@strSalesCategory",drDetl["strSalesCategory"]),
					new SqlParameter("@mTotalCommission",Convert.ToDecimal(drDetl["mTotalCommission"]))
					);

				SqlHelper.ExecuteNonQuery(connection,"UP_TblPayrollEntriesComm",
					new SqlParameter("@nPayrollID",drDetl["nPayrollID"]),
					new SqlParameter("@nPayrollID",drDetl["nEmployeeID"])
					);
			}
/*			DatarRow drDetl = gridView1.GetDataRow(gridView1.FocusedRowHandle);
			SqlHelper.ExecuteNonQuery(connection,"UP_tblPayrollSPAServiceCommDetails",
				new SqlParameter("@RET_VAL",output),
				new SqlParameter("@CMD","U"),
				new SqlParameter("@nPayrollID",nPayrollID),
				new SqlParameter("@nEmployeeID",Convert.ToInt32(drDetl["nEmplyeeID"])),
				new SqlParameter("@dtDate",ConvertToDateTime(drDetl["dtDate"])),
				new SqlParameter("@strBranchCode",drDetl["strBranchCode"].ToString()),
				new SqlParameter("@strServiceCode",drDetl["strServiceCode"].ToString()),
				new SqlParameter("@mCommission",Convert.ToDecimal(drDetl["mCommission"]))
				);
				*/
		}

		private void frmCommissionDetails_Load(object sender, System.EventArgs e)
		{
			DataSet _ds = new DataSet(); 
			string strSQL = "select distinct nCommGroupID,strGroupName from tblcommgroup order by nCommGroupID";
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			DataTable dt = _ds.Tables["Table"];

			DevExpress.XtraEditors.Controls.LookUpColumnInfo[] col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
			
			col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nCommGroupID","Commission ID",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strGroupName","strGroupName",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
		
			new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(this.lk_nCommGroup,dt,col,"strGroupName","nCommGroupID","Commission Type");

			gridControl1.DataSource = dtPTServiceComm;
			gridControl2.DataSource = dtSPAServiceComm;
			gridControl3.DataSource = dtSalesComm;
		
		}

	
	}
}
