using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ACMS.XtraUtils.LookupEditBuilder;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;

namespace ACMS.ACMSManager.Reports
{
	/// <summary>
	/// Summary description for RPLeave.
	/// </summary>
	public class RPLeave : System.Windows.Forms.Form
	{
		private string connectionString;
		private SqlConnection connection;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private DevExpress.XtraEditors.SimpleButton sbtnReset;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
		private DevExpress.XtraEditors.LookUpEdit lkBranch;
		private DevExpress.XtraEditors.LookUpEdit lkEmployee;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private DevExpress.XtraEditors.ImageComboBoxEdit cmbLeaveType;
		private DevExpress.XtraEditors.ImageComboBoxEdit cmbLeaveStatus;
		private DevExpress.XtraEditors.ImageComboBoxEdit cmbStatus;
		private ACMS.Utils.Common myCommon;
		private int EmployeeId;
		private DevExpress.XtraEditors.ImageComboBoxEdit Year;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.ImageComboBoxEdit ToYear;
		private DevExpress.XtraEditors.ImageComboBoxEdit ToMonth;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private DevExpress.XtraEditors.ImageComboBoxEdit dMonth;
		private DevExpress.XtraGrid.GridControl gdLeaveReport;
		private bool isFinishBind = false;
		private DevExpress.XtraEditors.SimpleButton btnReset;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public RPLeave(int empId)
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
			this.gdLeaveReport = new DevExpress.XtraGrid.GridControl();
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
			this.lkBranch = new DevExpress.XtraEditors.LookUpEdit();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.sbtnReset = new DevExpress.XtraEditors.SimpleButton();
			this.lkEmployee = new DevExpress.XtraEditors.LookUpEdit();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.cmbLeaveType = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.cmbLeaveStatus = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.cmbStatus = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.Year = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.dMonth = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.ToYear = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.ToMonth = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.btnReset = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.gdLeaveReport)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkBranch.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkEmployee.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbLeaveType.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbLeaveStatus.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbStatus.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Year.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dMonth.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ToYear.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ToMonth.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// gdLeaveReport
			// 
			this.gdLeaveReport.Dock = System.Windows.Forms.DockStyle.Bottom;
			// 
			// gdLeaveReport.EmbeddedNavigator
			// 
			this.gdLeaveReport.EmbeddedNavigator.Name = "";
			this.gdLeaveReport.Location = new System.Drawing.Point(0, 94);
			this.gdLeaveReport.MainView = this.gridView1;
			this.gdLeaveReport.Name = "gdLeaveReport";
			this.gdLeaveReport.Size = new System.Drawing.Size(976, 368);
			this.gdLeaveReport.TabIndex = 0;
			this.gdLeaveReport.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
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
																							 this.gridColumn9});
			this.gridView1.GridControl = this.gdLeaveReport;
			this.gridView1.Name = "gridView1";
			this.gridView1.OptionsBehavior.Editable = false;
			this.gridView1.OptionsCustomization.AllowColumnMoving = false;
			this.gridView1.OptionsCustomization.AllowFilter = false;
			this.gridView1.OptionsCustomization.AllowSort = false;
			this.gridView1.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "Branch";
			this.gridColumn1.FieldName = "strBranchCode";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 0;
			this.gridColumn1.Width = 80;
			// 
			// gridColumn2
			// 
			this.gridColumn2.Caption = "ID";
			this.gridColumn2.FieldName = "nEmployeeID";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 1;
			this.gridColumn2.Width = 51;
			// 
			// gridColumn3
			// 
			this.gridColumn3.Caption = "Name";
			this.gridColumn3.FieldName = "strEmployeeName";
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 2;
			this.gridColumn3.Width = 130;
			// 
			// gridColumn4
			// 
			this.gridColumn4.Caption = "Year";
			this.gridColumn4.FieldName = "dYear";
			this.gridColumn4.Name = "gridColumn4";
			this.gridColumn4.Visible = true;
			this.gridColumn4.VisibleIndex = 3;
			this.gridColumn4.Width = 78;
			// 
			// gridColumn5
			// 
			this.gridColumn5.Caption = "Month";
			this.gridColumn5.FieldName = "MonDesc";
			this.gridColumn5.Name = "gridColumn5";
			this.gridColumn5.Visible = true;
			this.gridColumn5.VisibleIndex = 4;
			this.gridColumn5.Width = 120;
			// 
			// gridColumn6
			// 
			this.gridColumn6.Caption = "Leave Type";
			this.gridColumn6.FieldName = "strDescription";
			this.gridColumn6.Name = "gridColumn6";
			this.gridColumn6.Visible = true;
			this.gridColumn6.VisibleIndex = 5;
			this.gridColumn6.Width = 150;
			// 
			// gridColumn7
			// 
			this.gridColumn7.Caption = "Status 1";
			this.gridColumn7.FieldName = "PAID";
			this.gridColumn7.Name = "gridColumn7";
			this.gridColumn7.Visible = true;
			this.gridColumn7.VisibleIndex = 6;
			this.gridColumn7.Width = 110;
			// 
			// gridColumn8
			// 
			this.gridColumn8.Caption = "Status 2";
			this.gridColumn8.FieldName = "Status";
			this.gridColumn8.Name = "gridColumn8";
			this.gridColumn8.Visible = true;
			this.gridColumn8.VisibleIndex = 7;
			this.gridColumn8.Width = 110;
			// 
			// gridColumn9
			// 
			this.gridColumn9.Caption = "Total";
			this.gridColumn9.FieldName = "LeaveQty";
			this.gridColumn9.Name = "gridColumn9";
			this.gridColumn9.Visible = true;
			this.gridColumn9.VisibleIndex = 8;
			this.gridColumn9.Width = 130;
			// 
			// lkBranch
			// 
			this.lkBranch.Location = new System.Drawing.Point(488, 0);
			this.lkBranch.Name = "lkBranch";
			// 
			// lkBranch.Properties
			// 
			this.lkBranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkBranch.Size = new System.Drawing.Size(64, 20);
			this.lkBranch.TabIndex = 188;
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label6.Location = new System.Drawing.Point(552, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(72, 23);
			this.label6.TabIndex = 187;
			this.label6.Text = "Employee";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.Location = new System.Drawing.Point(432, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(56, 23);
			this.label5.TabIndex = 186;
			this.label5.Text = "Branch";
			// 
			// sbtnReset
			// 
			this.sbtnReset.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.sbtnReset.Appearance.Options.UseFont = true;
			this.sbtnReset.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnReset.Location = new System.Drawing.Point(704, 0);
			this.sbtnReset.LookAndFeel.UseDefaultLookAndFeel = false;
			this.sbtnReset.Name = "sbtnReset";
			this.sbtnReset.Size = new System.Drawing.Size(56, 16);
			this.sbtnReset.TabIndex = 194;
			this.sbtnReset.Text = "Enquiry";
			this.sbtnReset.Click += new System.EventHandler(this.sbtnReset_Click);
			// 
			// lkEmployee
			// 
			this.lkEmployee.Location = new System.Drawing.Point(624, 0);
			this.lkEmployee.Name = "lkEmployee";
			// 
			// lkEmployee.Properties
			// 
			this.lkEmployee.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkEmployee.Size = new System.Drawing.Size(72, 20);
			this.lkEmployee.TabIndex = 193;
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label7.Location = new System.Drawing.Point(8, 24);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(88, 16);
			this.label7.TabIndex = 198;
			this.label7.Text = "Leave Type";
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label8.Location = new System.Drawing.Point(192, 24);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(88, 16);
			this.label8.TabIndex = 199;
			this.label8.Text = "Leave Status";
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label9.Location = new System.Drawing.Point(368, 24);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(56, 16);
			this.label9.TabIndex = 200;
			this.label9.Text = "Status";
			// 
			// label10
			// 
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label10.Location = new System.Drawing.Point(208, 0);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(24, 16);
			this.label10.TabIndex = 201;
			this.label10.Text = "To";
			// 
			// cmbLeaveType
			// 
			this.cmbLeaveType.Location = new System.Drawing.Point(96, 24);
			this.cmbLeaveType.Name = "cmbLeaveType";
			// 
			// cmbLeaveType.Properties
			// 
			this.cmbLeaveType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cmbLeaveType.Size = new System.Drawing.Size(88, 20);
			this.cmbLeaveType.TabIndex = 204;
			this.cmbLeaveType.SelectedValueChanged += new System.EventHandler(this.cmbLeaveType_SelectedValueChanged);
			// 
			// cmbLeaveStatus
			// 
			this.cmbLeaveStatus.EditValue = 0;
			this.cmbLeaveStatus.Location = new System.Drawing.Point(288, 24);
			this.cmbLeaveStatus.Name = "cmbLeaveStatus";
			// 
			// cmbLeaveStatus.Properties
			// 
			this.cmbLeaveStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cmbLeaveStatus.Properties.Items.AddRange(new object[] {
																		   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Paid", 0, -1),
																		   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Unpaid", 1, -1)});
			this.cmbLeaveStatus.Size = new System.Drawing.Size(72, 20);
			this.cmbLeaveStatus.TabIndex = 205;
			this.cmbLeaveStatus.SelectedValueChanged += new System.EventHandler(this.cmbLeaveStatus_SelectedValueChanged);
			// 
			// cmbStatus
			// 
			this.cmbStatus.EditValue = 0;
			this.cmbStatus.Location = new System.Drawing.Point(432, 24);
			this.cmbStatus.Name = "cmbStatus";
			// 
			// cmbStatus.Properties
			// 
			this.cmbStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cmbStatus.Properties.Items.AddRange(new object[] {
																	  new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Pending Approval", 0, -1),
																	  new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Approved", 1, -1),
																	  new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Rejected", 2, -1),
																	  new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Cancelled", 3, -1)});
			this.cmbStatus.Size = new System.Drawing.Size(120, 20);
			this.cmbStatus.TabIndex = 206;
			this.cmbStatus.SelectedValueChanged += new System.EventHandler(this.cmbStatus_SelectedValueChanged);
			// 
			// Year
			// 
			this.Year.Location = new System.Drawing.Point(160, 0);
			this.Year.Name = "Year";
			// 
			// Year.Properties
			// 
			this.Year.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																										 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.Year.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.Year.Size = new System.Drawing.Size(48, 20);
			this.Year.TabIndex = 210;
			// 
			// dMonth
			// 
			this.dMonth.EditValue = 1;
			this.dMonth.Location = new System.Drawing.Point(56, 0);
			this.dMonth.Name = "dMonth";
			// 
			// dMonth.Properties
			// 
			this.dMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																										   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dMonth.Properties.Items.AddRange(new object[] {
																   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("January", 1, -1),
																   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("February", 2, -1),
																   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("March", 3, -1),
																   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("April", 4, -1),
																   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("May", 5, -1),
																   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("June", 6, -1),
																   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("July", 7, -1),
																   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("August", 8, -1),
																   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("September", 9, -1),
																   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("October", 10, -1),
																   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("November", 11, -1),
																   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("December", 12, -1)});
			this.dMonth.Size = new System.Drawing.Size(64, 20);
			this.dMonth.TabIndex = 209;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(8, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 16);
			this.label2.TabIndex = 208;
			this.label2.Text = "Month";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(120, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 16);
			this.label1.TabIndex = 207;
			this.label1.Text = "Year";
			// 
			// ToYear
			// 
			this.ToYear.Location = new System.Drawing.Point(384, 0);
			this.ToYear.Name = "ToYear";
			// 
			// ToYear.Properties
			// 
			this.ToYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																										   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.ToYear.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.ToYear.Size = new System.Drawing.Size(48, 20);
			this.ToYear.TabIndex = 214;
			// 
			// ToMonth
			// 
			this.ToMonth.EditValue = 1;
			this.ToMonth.Location = new System.Drawing.Point(280, 0);
			this.ToMonth.Name = "ToMonth";
			// 
			// ToMonth.Properties
			// 
			this.ToMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.ToMonth.Properties.Items.AddRange(new object[] {
																	new DevExpress.XtraEditors.Controls.ImageComboBoxItem("January", 1, -1),
																	new DevExpress.XtraEditors.Controls.ImageComboBoxItem("February", 2, -1),
																	new DevExpress.XtraEditors.Controls.ImageComboBoxItem("March", 3, -1),
																	new DevExpress.XtraEditors.Controls.ImageComboBoxItem("April", 4, -1),
																	new DevExpress.XtraEditors.Controls.ImageComboBoxItem("May", 5, -1),
																	new DevExpress.XtraEditors.Controls.ImageComboBoxItem("June", 6, -1),
																	new DevExpress.XtraEditors.Controls.ImageComboBoxItem("July", 7, -1),
																	new DevExpress.XtraEditors.Controls.ImageComboBoxItem("August", 8, -1),
																	new DevExpress.XtraEditors.Controls.ImageComboBoxItem("September", 9, -1),
																	new DevExpress.XtraEditors.Controls.ImageComboBoxItem("October", 10, -1),
																	new DevExpress.XtraEditors.Controls.ImageComboBoxItem("November", 11, -1),
																	new DevExpress.XtraEditors.Controls.ImageComboBoxItem("December", 12, -1)});
			this.ToMonth.Size = new System.Drawing.Size(64, 20);
			this.ToMonth.TabIndex = 213;
			// 
			// label11
			// 
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label11.Location = new System.Drawing.Point(232, 0);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(48, 16);
			this.label11.TabIndex = 212;
			this.label11.Text = "Month";
			// 
			// label12
			// 
			this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label12.Location = new System.Drawing.Point(344, 0);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(40, 16);
			this.label12.TabIndex = 211;
			this.label12.Text = "Year";
			// 
			// btnReset
			// 
			this.btnReset.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnReset.Appearance.Options.UseFont = true;
			this.btnReset.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnReset.Location = new System.Drawing.Point(560, 24);
			this.btnReset.LookAndFeel.UseDefaultLookAndFeel = false;
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(72, 16);
			this.btnReset.TabIndex = 215;
			this.btnReset.Text = "Reset";
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// RPLeave
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(976, 462);
			this.Controls.Add(this.btnReset);
			this.Controls.Add(this.ToYear);
			this.Controls.Add(this.ToMonth);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.Year);
			this.Controls.Add(this.dMonth);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cmbStatus);
			this.Controls.Add(this.cmbLeaveStatus);
			this.Controls.Add(this.cmbLeaveType);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.sbtnReset);
			this.Controls.Add(this.lkEmployee);
			this.Controls.Add(this.lkBranch);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.gdLeaveReport);
			this.Name = "RPLeave";
			this.Text = "Leave";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.RPLeave_Load);
			((System.ComponentModel.ISupportInitialize)(this.gdLeaveReport)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkBranch.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkEmployee.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbLeaveType.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbLeaveStatus.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbStatus.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Year.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dMonth.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ToYear.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ToMonth.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void RPLeave_Load(object sender, System.EventArgs e)
		{
			isFinishBind = false;
			ToMonth.SelectedIndex = 11;
			BindInit();
			isFinishBind = true;
			LoadReport();
		}

		private void BindInit()
		{
			myCommon = new ACMS.Utils.Common();
			DataTable dt; 
			dt = myCommon.ExecuteQuery("Select strBranchCode,strBranchName from tblBranch Where strBranchCode In (Select strBranchCode from tblemployeebranchrights Where nEmployeeId = " + EmployeeId + ")");
			new ManagerBranchCodeLookupEditBuilder(dt, this.lkBranch.Properties);

			dt = myCommon.ExecuteQuery("Select nEmployeeID, strEmployeeName from tblEmployee");
			new ManagerEmployeeIDLookupEditBuilder(dt, this.lkEmployee.Properties);

			string strSQL = "Select strLeaveCode, strDescription from tblLeaveType order by strLeaveCode";

			comboBind(cmbLeaveType, strSQL, "strLeaveCode", "strDescription", true);
			this.cmbLeaveType.Properties.Items.Insert(0,new DevExpress.XtraEditors.Controls.ImageComboBoxItem("- Please Select -",""));
			cmbLeaveType.SelectedIndex = 0;

			strSQL = "Select distinct nYearID from tblLeave order by nYearID desc";

			comboBind(Year, strSQL, "nYearID", "nYearID", true);
			Year.SelectedIndex = 0;
			if (Year.SelectedIndex == -1)
				this.Year.Properties.Items.Insert(0,new DevExpress.XtraEditors.Controls.ImageComboBoxItem(DateTime.Today.Year.ToString(),""));
			Year.SelectedIndex = 0;
					

			comboBind(ToYear, strSQL, "nYearID", "nYearID", true);
			ToYear.SelectedIndex = 0;
			if (ToYear.SelectedIndex == -1)
				this.ToYear.Properties.Items.Insert(0,new DevExpress.XtraEditors.Controls.ImageComboBoxItem(DateTime.Today.Year.ToString(),""));
			ToYear.SelectedIndex = 0;
					
		}
		
		private void LoadReport()
		{
			if (!isFinishBind)
				return;
			//up_LeaveReport
			SqlCommand myCmd = new SqlCommand("up_LeaveQuantityReport", connection);
			myCmd.CommandType = CommandType.StoredProcedure;
			myCmd.Parameters.Add("@YearNo", Year.EditValue); 
			myCmd.Parameters.Add("@YearNo2", ToYear.EditValue); 
			myCmd.Parameters.Add("@Month", dMonth.EditValue); 
			myCmd.Parameters.Add("@Month2", ToMonth.EditValue); 
			myCmd.Parameters.Add("@Paid", cmbLeaveStatus.EditValue); 
			myCmd.Parameters.Add("@StatusID", cmbStatus.EditValue); 

			if (this.cmbLeaveType.EditValue != null && cmbLeaveType.EditValue.ToString() != "")
				myCmd.Parameters.Add("@LeaveCode", cmbLeaveType.EditValue); 

            if (lkEmployee.EditValue != null && lkEmployee.EditValue.ToString() != "")
				myCmd.Parameters.Add("@nEmployeeID", lkEmployee.EditValue); 

			if (lkBranch.EditValue != null && lkBranch.EditValue.ToString() != "")
				myCmd.Parameters.Add("@strBranchCode", lkBranch.EditValue); 

			SqlDataAdapter adpLeave = new SqlDataAdapter(myCmd); 

			//connection.Open(); 

			DataSet _ds = new DataSet("Leave"); 
			adpLeave.Fill(_ds, "Leave"); 

			gdLeaveReport.DataSource = _ds.Tables["Leave"];

		}

		private void comboBind(DevExpress.XtraEditors.ImageComboBoxEdit control,string strSQL,string display,string strValue,bool fNum)
		{
		
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox properties = control.Properties;
			properties.Items.BeginUpdate();
			properties.Items.Clear();

			try 
			{
				foreach(DataRow dr in _ds.Tables["Table"].Rows)
				{
					//Initialize each item with the display text, value and image index
					properties.Items.Add( new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr[display].ToString(), dr[strValue],-1));
				}
			}
			finally 
			{
				properties.Items.EndUpdate();
			}
			//Select the first item
			control.SelectedIndex = 0;
		}

		private void sbtnReset_Click(object sender, System.EventArgs e)
		{
				LoadReport();
		}

		private void btnReset_Click(object sender, System.EventArgs e)
		{
			lkBranch.EditValue = null;
			lkEmployee.EditValue = null;
			dMonth.SelectedIndex = 0;
			Year.SelectedIndex = 0;
			ToMonth.SelectedIndex = 11;
			ToYear.SelectedIndex = 0;
			cmbLeaveType.SelectedIndex = 0;
			cmbLeaveStatus.SelectedIndex = 0;
			cmbStatus.SelectedIndex = 0;
			LoadReport();
		}

		private void cmbLeaveType_SelectedValueChanged(object sender, System.EventArgs e)
		{
			LoadReport();
		}

		private void cmbLeaveStatus_SelectedValueChanged(object sender, System.EventArgs e)
		{
			LoadReport();
		}

		private void cmbStatus_SelectedValueChanged(object sender, System.EventArgs e)
		{
			LoadReport();
		}

	}
}
