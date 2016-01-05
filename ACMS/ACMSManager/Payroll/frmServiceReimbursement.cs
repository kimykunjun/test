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
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using System.Data.Common;



namespace ACMS.ACMSManager.Payroll
{
	/// <summary>
	/// Summary description for frmServiceReimbursement.
	/// </summary>
	public class frmServiceReimbursement : System.Windows.Forms.Form
	{
		private SqlDataAdapter adapter; 
		private string connectionString;
		private SqlConnection connection;
		//private Do.Employee employee;
		//private Do.TerminalUser terminalUser; 
		//private static User oUser;
		public DataTable sr;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraGrid.GridControl gcMon;
		private DevExpress.XtraEditors.RadioGroup radioGroupType;
		private DevExpress.XtraGrid.Columns.GridColumn fee1a;
		private DevExpress.XtraGrid.Columns.GridColumn fee1b;
		private DevExpress.XtraGrid.Columns.GridColumn ClassID1;
		private DevExpress.XtraGrid.Columns.GridColumn Transfer1;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_Employee;
		private DevExpress.XtraEditors.SimpleButton btn_Save;
		private DevExpress.XtraEditors.SimpleButton btn_Cancel;
		private DevExpress.XtraGrid.Columns.GridColumn Transfer2;
		private DevExpress.XtraGrid.Columns.GridColumn strBranchCode;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private int nEmployeeno, nPayrollID;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
		private DevExpress.XtraGrid.Columns.GridColumn strDescription;
		private System.Windows.Forms.ImageList imageList1;
		internal DevExpress.XtraEditors.SimpleButton btn_Bottom_Del;
		internal DevExpress.XtraEditors.SimpleButton btn_Bottom_Add;
		private DevExpress.XtraGrid.GridControl grid_ExtraFees;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView_ExtraFees;
		private DevExpress.XtraGrid.Columns.GridColumn Branch;
		private DevExpress.XtraGrid.Columns.GridColumn dtDate;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_Branch;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
		private System.ComponentModel.IContainer components;

		public frmServiceReimbursement(int n_Employeeno,int n_PayrollID)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			connectionString = (string)System.Configuration.ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);
			nEmployeeno=n_Employeeno;
			nPayrollID=n_PayrollID;
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

		public DataTable dtServiceReim
		{
			get
			{
				return sr;
			}
			set
			{
				sr = value;
			}
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmServiceReimbursement));
			this.gcMon = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.strBranchCode = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.fee1a = new DevExpress.XtraGrid.Columns.GridColumn();
			this.fee1b = new DevExpress.XtraGrid.Columns.GridColumn();
			this.Transfer1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.lk_Employee = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			this.Transfer2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.ClassID1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.radioGroupType = new DevExpress.XtraEditors.RadioGroup();
			this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
			this.btn_Cancel = new DevExpress.XtraEditors.SimpleButton();
			this.grid_ExtraFees = new DevExpress.XtraGrid.GridControl();
			this.gridView_ExtraFees = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.Branch = new DevExpress.XtraGrid.Columns.GridColumn();
			this.lk_Branch = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			this.dtDate = new DevExpress.XtraGrid.Columns.GridColumn();
			this.strDescription = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.btn_Bottom_Del = new DevExpress.XtraEditors.SimpleButton();
			this.btn_Bottom_Add = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.gcMon)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_Employee)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.radioGroupType.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grid_ExtraFees)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView_ExtraFees)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_Branch)).BeginInit();
			this.SuspendLayout();
			// 
			// gcMon
			// 
			// 
			// gcMon.EmbeddedNavigator
			// 
			this.gcMon.EmbeddedNavigator.Name = "";
			this.gcMon.Location = new System.Drawing.Point(16, 56);
			this.gcMon.MainView = this.gridView1;
			this.gcMon.Name = "gcMon";
			this.gcMon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																										   this.lk_Employee});
			this.gcMon.Size = new System.Drawing.Size(616, 320);
			this.gcMon.TabIndex = 0;
			this.gcMon.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																								 this.gridView1});
			// 
			// gridView1
			// 
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.strBranchCode,
																							 this.gridColumn1,
																							 this.gridColumn2,
																							 this.gridColumn3,
																							 this.gridColumn4,
																							 this.fee1a,
																							 this.fee1b,
																							 this.Transfer1,
																							 this.Transfer2,
																							 this.ClassID1});
			this.gridView1.GridControl = this.gcMon;
			this.gridView1.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
			this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
																							   new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CUSTOM", this.fee1a, "f2"),
																							   new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total", this.fee1b, "f2")});
			this.gridView1.Name = "gridView1";
			this.gridView1.OptionsCustomization.AllowFilter = false;
			this.gridView1.OptionsView.ColumnAutoWidth = false;
			this.gridView1.OptionsView.ShowFooter = true;
			this.gridView1.OptionsView.ShowGroupPanel = false;
			this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
			// 
			// strBranchCode
			// 
			this.strBranchCode.Caption = "Branch";
			this.strBranchCode.FieldName = "strBranchcode";
			this.strBranchCode.Name = "strBranchCode";
			this.strBranchCode.OptionsColumn.AllowEdit = false;
			this.strBranchCode.Visible = true;
			this.strBranchCode.VisibleIndex = 0;
			this.strBranchCode.Width = 59;
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "Date";
			this.gridColumn1.FieldName = "dtDate";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.OptionsColumn.AllowEdit = false;
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 1;
			// 
			// gridColumn2
			// 
			this.gridColumn2.Caption = "Time";
			this.gridColumn2.DisplayFormat.FormatString = "hh:mm";
			this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.gridColumn2.FieldName = "dtStartTime";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.OptionsColumn.AllowEdit = false;
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 2;
			// 
			// gridColumn3
			// 
			this.gridColumn3.Caption = "Class";
			this.gridColumn3.FieldName = "strClassCode";
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.OptionsColumn.AllowEdit = false;
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 3;
			this.gridColumn3.Width = 72;
			// 
			// gridColumn4
			// 
			this.gridColumn4.Caption = "Attendees";
			this.gridColumn4.FieldName = "nAttendees";
			this.gridColumn4.Name = "gridColumn4";
			this.gridColumn4.OptionsColumn.AllowEdit = false;
			this.gridColumn4.Visible = true;
			this.gridColumn4.VisibleIndex = 4;
			// 
			// fee1a
			// 
			this.fee1a.AppearanceCell.BackColor = System.Drawing.SystemColors.Control;
			this.fee1a.AppearanceCell.Options.UseBackColor = true;
			this.fee1a.AppearanceHeader.BackColor = System.Drawing.SystemColors.Control;
			this.fee1a.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.fee1a.AppearanceHeader.Options.UseBackColor = true;
			this.fee1a.AppearanceHeader.Options.UseFont = true;
			this.fee1a.Caption = "Fees";
			this.fee1a.DisplayFormat.FormatString = "f2";
			this.fee1a.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.fee1a.FieldName = "mInstructorFees";
			this.fee1a.Name = "fee1a";
			this.fee1a.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
			this.fee1a.Visible = true;
			this.fee1a.VisibleIndex = 5;
			this.fee1a.Width = 90;
			// 
			// fee1b
			// 
			this.fee1b.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.fee1b.AppearanceHeader.Options.UseFont = true;
			this.fee1b.Caption = "Fees";
			this.fee1b.FieldName = "mStandinInstructorFees";
			this.fee1b.Name = "fee1b";
			this.fee1b.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
			this.fee1b.Width = 90;
			// 
			// Transfer1
			// 
			this.Transfer1.Caption = "Transfer To ";
			this.Transfer1.ColumnEdit = this.lk_Employee;
			this.Transfer1.FieldName = "nActualInstructorID";
			this.Transfer1.Name = "Transfer1";
			this.Transfer1.Visible = true;
			this.Transfer1.VisibleIndex = 6;
			this.Transfer1.Width = 150;
			// 
			// lk_Employee
			// 
			this.lk_Employee.AutoHeight = false;
			this.lk_Employee.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																									 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lk_Employee.Name = "lk_Employee";
			// 
			// Transfer2
			// 
			this.Transfer2.Caption = "Transfer To";
			this.Transfer2.ColumnEdit = this.lk_Employee;
			this.Transfer2.FieldName = "nStandinInstructorID";
			this.Transfer2.Name = "Transfer2";
			this.Transfer2.Width = 150;
			// 
			// ClassID1
			// 
			this.ClassID1.Caption = "Class Id";
			this.ClassID1.FieldName = "nClassInstanceID";
			this.ClassID1.Name = "ClassID1";
			// 
			// radioGroupType
			// 
			this.radioGroupType.EditValue = "A";
			this.radioGroupType.Location = new System.Drawing.Point(24, 8);
			this.radioGroupType.Name = "radioGroupType";
			// 
			// radioGroupType.Properties
			// 
			this.radioGroupType.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.radioGroupType.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.radioGroupType.Properties.Appearance.Options.UseBackColor = true;
			this.radioGroupType.Properties.Appearance.Options.UseFont = true;
			this.radioGroupType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.radioGroupType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
																												   new DevExpress.XtraEditors.Controls.RadioGroupItem("A", "Actual Fees"),
																												   new DevExpress.XtraEditors.Controls.RadioGroupItem("S", "Standing Fees")});
			this.radioGroupType.Size = new System.Drawing.Size(312, 32);
			this.radioGroupType.TabIndex = 7;
			this.radioGroupType.SelectedIndexChanged += new System.EventHandler(this.radioGroupType_SelectedIndexChanged);
			// 
			// btn_Save
			// 
			this.btn_Save.ImageIndex = 0;
			this.btn_Save.Location = new System.Drawing.Point(480, 16);
			this.btn_Save.Name = "btn_Save";
			this.btn_Save.Size = new System.Drawing.Size(112, 23);
			this.btn_Save.TabIndex = 14;
			this.btn_Save.Text = "Save Changes";
			this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
			// 
			// btn_Cancel
			// 
			this.btn_Cancel.Location = new System.Drawing.Point(528, 504);
			this.btn_Cancel.Name = "btn_Cancel";
			this.btn_Cancel.Size = new System.Drawing.Size(104, 23);
			this.btn_Cancel.TabIndex = 17;
			this.btn_Cancel.Text = "Close";
			this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
			// 
			// grid_ExtraFees
			// 
			// 
			// grid_ExtraFees.EmbeddedNavigator
			// 
			this.grid_ExtraFees.EmbeddedNavigator.Name = "";
			this.grid_ExtraFees.Location = new System.Drawing.Point(16, 400);
			this.grid_ExtraFees.MainView = this.gridView_ExtraFees;
			this.grid_ExtraFees.Name = "grid_ExtraFees";
			this.grid_ExtraFees.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																													this.lk_Branch});
			this.grid_ExtraFees.Size = new System.Drawing.Size(616, 96);
			this.grid_ExtraFees.TabIndex = 18;
			this.grid_ExtraFees.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										  this.gridView_ExtraFees});
			// 
			// gridView_ExtraFees
			// 
			this.gridView_ExtraFees.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																									  this.Branch,
																									  this.dtDate,
																									  this.strDescription,
																									  this.gridColumn10,
																									  this.gridColumn5,
																									  this.gridColumn6});
			this.gridView_ExtraFees.GridControl = this.grid_ExtraFees;
			this.gridView_ExtraFees.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
			this.gridView_ExtraFees.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
																										new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CUSTOM", this.gridColumn10, "f2")});
			this.gridView_ExtraFees.Name = "gridView_ExtraFees";
			this.gridView_ExtraFees.OptionsCustomization.AllowFilter = false;
			this.gridView_ExtraFees.OptionsNavigation.AutoFocusNewRow = true;
			this.gridView_ExtraFees.OptionsView.ColumnAutoWidth = false;
			this.gridView_ExtraFees.OptionsView.ShowFooter = true;
			this.gridView_ExtraFees.OptionsView.ShowGroupPanel = false;
			this.gridView_ExtraFees.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grid_ExtraFees_Changed);
			// 
			// Branch
			// 
			this.Branch.Caption = "Branch";
			this.Branch.ColumnEdit = this.lk_Branch;
			this.Branch.FieldName = "strBranchCode";
			this.Branch.Name = "Branch";
			this.Branch.OptionsColumn.AllowEdit = false;
			this.Branch.Visible = true;
			this.Branch.VisibleIndex = 0;
			this.Branch.Width = 59;
			// 
			// lk_Branch
			// 
			this.lk_Branch.AutoHeight = false;
			this.lk_Branch.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																								   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lk_Branch.Name = "lk_Branch";
			// 
			// dtDate
			// 
			this.dtDate.Caption = "Date";
			this.dtDate.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.dtDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.dtDate.FieldName = "dtDate";
			this.dtDate.Name = "dtDate";
			this.dtDate.OptionsColumn.AllowEdit = false;
			this.dtDate.Visible = true;
			this.dtDate.VisibleIndex = 1;
			// 
			// strDescription
			// 
			this.strDescription.Caption = "Description";
			this.strDescription.FieldName = "strDescription";
			this.strDescription.Name = "strDescription";
			this.strDescription.Visible = true;
			this.strDescription.VisibleIndex = 2;
			this.strDescription.Width = 374;
			// 
			// gridColumn10
			// 
			this.gridColumn10.AppearanceCell.BackColor = System.Drawing.SystemColors.Control;
			this.gridColumn10.AppearanceCell.Options.UseBackColor = true;
			this.gridColumn10.AppearanceHeader.BackColor = System.Drawing.SystemColors.Control;
			this.gridColumn10.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.gridColumn10.AppearanceHeader.Options.UseBackColor = true;
			this.gridColumn10.AppearanceHeader.Options.UseFont = true;
			this.gridColumn10.Caption = "Fees";
			this.gridColumn10.DisplayFormat.FormatString = "f2";
			this.gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.gridColumn10.FieldName = "mExtraFees";
			this.gridColumn10.Name = "gridColumn10";
			this.gridColumn10.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
			this.gridColumn10.Visible = true;
			this.gridColumn10.VisibleIndex = 3;
			this.gridColumn10.Width = 90;
			// 
			// gridColumn5
			// 
			this.gridColumn5.Caption = "EmployeeNo";
			this.gridColumn5.FieldName = "nEmployeeNo";
			this.gridColumn5.Name = "gridColumn5";
			this.gridColumn5.OptionsColumn.AllowEdit = false;
			// 
			// gridColumn6
			// 
			this.gridColumn6.Caption = "PayRollId";
			this.gridColumn6.FieldName = "nPayRollId";
			this.gridColumn6.Name = "gridColumn6";
			this.gridColumn6.OptionsColumn.AllowEdit = false;
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
			// 
			// btn_Bottom_Del
			// 
			this.btn_Bottom_Del.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btn_Bottom_Del.Appearance.Options.UseFont = true;
			this.btn_Bottom_Del.Appearance.Options.UseTextOptions = true;
			this.btn_Bottom_Del.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.btn_Bottom_Del.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
			this.btn_Bottom_Del.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.btn_Bottom_Del.ImageIndex = 1;
			this.btn_Bottom_Del.ImageList = this.imageList1;
			this.btn_Bottom_Del.Location = new System.Drawing.Point(56, 384);
			this.btn_Bottom_Del.Name = "btn_Bottom_Del";
			this.btn_Bottom_Del.Size = new System.Drawing.Size(38, 16);
			this.btn_Bottom_Del.TabIndex = 124;
			this.btn_Bottom_Del.Click += new System.EventHandler(this.btn_Bottom_Del_Click);
			// 
			// btn_Bottom_Add
			// 
			this.btn_Bottom_Add.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btn_Bottom_Add.Appearance.Options.UseFont = true;
			this.btn_Bottom_Add.Appearance.Options.UseTextOptions = true;
			this.btn_Bottom_Add.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.btn_Bottom_Add.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
			this.btn_Bottom_Add.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.btn_Bottom_Add.ImageIndex = 0;
			this.btn_Bottom_Add.ImageList = this.imageList1;
			this.btn_Bottom_Add.Location = new System.Drawing.Point(16, 384);
			this.btn_Bottom_Add.Name = "btn_Bottom_Add";
			this.btn_Bottom_Add.Size = new System.Drawing.Size(38, 16);
			this.btn_Bottom_Add.TabIndex = 125;
			this.btn_Bottom_Add.Click += new System.EventHandler(this.btn_Bottom_Add_Click);
			// 
			// frmServiceReimbursement
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(650, 528);
			this.Controls.Add(this.btn_Bottom_Del);
			this.Controls.Add(this.btn_Bottom_Add);
			this.Controls.Add(this.grid_ExtraFees);
			this.Controls.Add(this.btn_Cancel);
			this.Controls.Add(this.btn_Save);
			this.Controls.Add(this.radioGroupType);
			this.Controls.Add(this.gcMon);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmServiceReimbursement";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Service Reimbursement";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.frmServiceReimbursement_Load);
			((System.ComponentModel.ISupportInitialize)(this.gcMon)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_Employee)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.radioGroupType.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid_ExtraFees)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView_ExtraFees)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_Branch)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
		
		private void init()
		{
			if ( radioGroupType.SelectedIndex == 0)
			{
				this.gridView1.Columns[5].Visible = true;
				this.gridView1.Columns[6].Visible = false;
				this.gridView1.Columns[7].Visible = true;
				this.gridView1.Columns[8].Visible = false;
				
				string strFilter,strSort;
				//Mon
				DataView dv1 = new DataView(dtServiceReim);
				strSort ="strBranchcode,dtdate";
				strFilter =  "nActualInstructorID='"+nEmployeeno+"'";
				dv1.Sort=strSort;
				//dv1.RowFilter = strFilter;
				
				
				gcMon.DataSource = dv1; 


			}
			else if ( radioGroupType.SelectedIndex == 1)
			{
				this.gridView1.Columns[5].Visible = false;
				this.gridView1.Columns[6].Visible = true;
				this.gridView1.Columns[7].Visible = false;
				this.gridView1.Columns[8].Visible = true;
				
				string strFilter,strSort;
				//Mon
				DataView dv1b = new DataView(dtServiceReim);
				strSort ="strBranchcode,dtdate";
				strFilter = "nStandinInstructorID='"+nEmployeeno+"'";

				dv1b.Sort=strSort;
				dv1b.RowFilter = strFilter;
				gcMon.DataSource = dv1b;				
			}

			init_ExtraFees();
	
		}
		private void frmServiceReimbursement_Load(object sender, System.EventArgs e)
		{
			init();
			load_EmployeeList();
			load_BranchList();
			btn_Save.Enabled=false;
			
			//DevExpress.XtraEditors.Repository.RepositoryItemComboBox properties = cmb_day.Properties;
			//properties.Items.AddRange(new string [] {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"});
			//Select the first item
			//cmb_day.SelectedIndex = 0;
			//Disable editing
			//properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

		}

		private void radioGroupType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			init();
		
		}

		private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
		{
			btn_Save.Enabled=true;	
		}


		private void load_EmployeeList()
		{
			DataSet _ds = new DataSet();
			string strSQL;

			strSQL = "select nEmployeeID, strEmployeeName from TblEmployee where nStatusID=1 and fInstructor=1";
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			DataTable dt = _ds.Tables["table"];
			
			DevExpress.XtraEditors.Controls.LookUpColumnInfo[] col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
			
			col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nEmployeeID","ID",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strEmployeeName","Employee Name",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);

			//new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(this.luedtItemPromotion.Properties, dt, col, "strDescription", "strPromotionCode", "Promotion");

			new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(this.lk_Employee,dt,col,"strEmployeeName","nEmployeeID","Employee Name");		

		}

		private void load_BranchList()
		{
			DataSet _ds = new DataSet();
			string strSQL;

			strSQL = "select strBranchCode, strBranchName from TblBranch where nBrStatusID=1 ";
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			DataTable dt = _ds.Tables["table"];
			
			DevExpress.XtraEditors.Controls.LookUpColumnInfo[] col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
			
			col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strBranchCode","Branch",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strBranchName","Description",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);

			//new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(this.luedtItemPromotion.Properties, dt, col, "strBranchName", "strPromotionCode", "Promotion");

			new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(this.lk_Branch,dt,col,"strBranchCode","strBranchCode","Branch");		

		}


		private void btn_Save_Click(object sender, System.EventArgs e)
		{
			string strSQL="Select * from tblSvsReimbursement"; 
			CreateCmdsAndUpdate(strSQL,dtExtraFees);
			GridView_Change();

			this.Dispose();
		}

		public void CreateCmdsAndUpdate(string mySelectQuery,DataTable myTableName) 
		{
			SqlConnection myConn = new SqlConnection(connectionString);
			SqlDataAdapter myDataAdapter = new SqlDataAdapter();
			myDataAdapter.SelectCommand=new SqlCommand(mySelectQuery, myConn);
			SqlCommandBuilder custCB = new SqlCommandBuilder(myDataAdapter);

			myConn.Open();
			DataSet custDS = new DataSet();
			myDataAdapter.Fill(custDS);

			//code to modify data in dataset here
			myDataAdapter.Update(myTableName);
			myConn.Close();
		}

		private void GridView_Change()
		{
			try
			{
				for (int i=0;i<=gridView1.RowCount;i++)
				{
					DataRow drDetl = gridView1.GetDataRow(i);
					if ( drDetl != null)
					{
						if ( radioGroupType.SelectedIndex == 0)		
						{
							SqlHelper.ExecuteNonQuery(connection,"up_Payr_InstructorFees",
								new SqlParameter("@nClassInstanceID",drDetl["nClassInstanceID"]),
								new SqlParameter("@mInstructorFees",Convert.ToDecimal(drDetl["mInstructorFees"])),
								new SqlParameter("@nActualInstructorID",Convert.ToInt32(drDetl["nActualInstructorID"])),
								new SqlParameter("@Year",Convert.ToInt32(drDetl["PYear"])),
								new SqlParameter("@Year",Convert.ToInt32(drDetl["PMonth"])),
								new SqlParameter("@PayRollID",nPayrollID)
								);
						}
						else if ( radioGroupType.SelectedIndex == 1)
						{
							SqlHelper.ExecuteNonQuery(connection,"up_Payr_StandingInstructorFees",
								new SqlParameter("@nClassInstanceID",drDetl["nClassInstanceID"]),
								new SqlParameter("@mStandinInstructorFees",Convert.ToDecimal(drDetl["mStandinInstructorFees"])),
								new SqlParameter("@nStandinInstructorID",Convert.ToInt32(drDetl["nStandinInstructorID"])),
								new SqlParameter("@Year",Convert.ToInt32(drDetl["PYear"])),
								new SqlParameter("@Year",Convert.ToInt32(drDetl["PMonth"])),
								new SqlParameter("@PayRollID",nPayrollID)
								);
						}
						gridView1.RefreshData();
						}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

	
		private void btn_Cancel_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

		private DataTable dtExtraFees;

		private void init_ExtraFees()
		{
			DataRow row = this.gridView_ExtraFees.GetDataRow(gridView_ExtraFees.FocusedRowHandle);

			DataSet _ds = new DataSet(); 
			adapter = new SqlDataAdapter();

			string strSQL = "Select * from tblSvsReimbursement where nPayRollId=" + nPayrollID + " and nEmployeeNo ="+ nEmployeeno  ;
			
			adapter.SelectCommand = new SqlCommand(strSQL, connection);
			adapter.Fill(_ds);
			DataTable dt = _ds.Tables["Table"];

			//SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			
			dtExtraFees = _ds.Tables["table"];
			grid_ExtraFees.DataSource= dtExtraFees;
		}

		private void btn_Bottom_Add_Click(object sender, System.EventArgs e)
		{
	//		AddNew = true;
			DataRow dr = dtExtraFees.NewRow();
			dtExtraFees.Rows.Add(dr);

			this.gridView_ExtraFees.SetRowCellValue(dtExtraFees.Rows.Count - 1, gridView_ExtraFees.Columns["dtDate"], DateTime.Today);	
			this.gridView_ExtraFees.SetRowCellValue(dtExtraFees.Rows.Count - 1, gridView_ExtraFees.Columns["strBranchCode"], "HQ");	
			this.gridView_ExtraFees.SetRowCellValue(dtExtraFees.Rows.Count - 1, gridView_ExtraFees.Columns["nEmployeeNo"], nEmployeeno);	
			this.gridView_ExtraFees.SetRowCellValue(dtExtraFees.Rows.Count - 1, gridView_ExtraFees.Columns["nPayRollId"], nPayrollID);	

	
			this.grid_ExtraFees.Refresh();
			this.gridView_ExtraFees.FocusedRowHandle = dtExtraFees.Rows.Count - 1;		
		}	

		private void btn_Bottom_Del_Click(object sender, System.EventArgs e)
		{
			this.gridView_ExtraFees.DeleteRow(gridView_ExtraFees.FocusedRowHandle);
				
		}

		private void grid_ExtraFees_Changed(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
		{
			btn_Save.Enabled=true;
		}

	}
			
	}

