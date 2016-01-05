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
using ACMS.Utils;

namespace ACMS.ACMSManager.Human_Resource
{
	/// <summary>
	/// Summary description for frmOvertimeMain.
	/// </summary>
	public class frmOvertimeMain : System.Windows.Forms.Form
	{
		private string connectionString;
		private SqlConnection connection;
		private static Do.Employee employee;
		private static Do.TerminalUser terminalUser; 
		private static User oUser;
		private DevExpress.XtraEditors.GroupControl groupOverTime;
		private DevExpress.XtraEditors.ImageComboBoxEdit OvertimeStatus;
		private System.Windows.Forms.Label label151;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewOverTime;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn69;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn62;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn63;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn64;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn65;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn54;
		internal DevExpress.XtraEditors.SimpleButton btnReject;
		internal DevExpress.XtraEditors.SimpleButton btnApprove;
		private System.Windows.Forms.Label label25;
		private DevExpress.XtraEditors.GroupControl groupControl1;
		private DevExpress.XtraEditors.ImageComboBoxEdit prevToMonth;
		private DevExpress.XtraEditors.ImageComboBoxEdit prevFromMonth;
		internal DevExpress.XtraEditors.SimpleButton btnPrevGo;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private DevExpress.XtraEditors.ImageComboBoxEdit prevToYear;
		private DevExpress.XtraEditors.ImageComboBoxEdit prevFromYear;
		internal DevExpress.XtraEditors.SimpleButton btnViewAll;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
		private DevExpress.XtraEditors.ImageComboBoxEdit cmbBranch;
		private DevExpress.XtraGrid.GridControl gridOverTime;
        internal DevExpress.XtraEditors.SimpleButton btnClear;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmOvertimeMain()
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
            this.groupOverTime = new DevExpress.XtraEditors.GroupControl();
            this.btnViewAll = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.prevToMonth = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.prevFromMonth = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.btnPrevGo = new DevExpress.XtraEditors.SimpleButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.prevToYear = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.prevFromYear = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.cmbBranch = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.label25 = new System.Windows.Forms.Label();
            this.OvertimeStatus = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.label151 = new System.Windows.Forms.Label();
            this.gridOverTime = new DevExpress.XtraGrid.GridControl();
            this.gridViewOverTime = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn69 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn62 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn63 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn64 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn65 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn54 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnApprove = new DevExpress.XtraEditors.SimpleButton();
            this.btnReject = new DevExpress.XtraEditors.SimpleButton();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupOverTime)).BeginInit();
            this.groupOverTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prevToMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prevFromMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prevToYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prevFromYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBranch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OvertimeStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridOverTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOverTime)).BeginInit();
            this.SuspendLayout();
            // 
            // groupOverTime
            // 
            this.groupOverTime.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.groupOverTime.Appearance.Options.UseBackColor = true;
            this.groupOverTime.Controls.Add(this.btnClear);
            this.groupOverTime.Controls.Add(this.btnViewAll);
            this.groupOverTime.Controls.Add(this.groupControl1);
            this.groupOverTime.Controls.Add(this.cmbBranch);
            this.groupOverTime.Controls.Add(this.label25);
            this.groupOverTime.Controls.Add(this.OvertimeStatus);
            this.groupOverTime.Controls.Add(this.label151);
            this.groupOverTime.Controls.Add(this.gridOverTime);
            this.groupOverTime.Controls.Add(this.btnApprove);
            this.groupOverTime.Controls.Add(this.btnReject);
            this.groupOverTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupOverTime.Location = new System.Drawing.Point(0, 0);
            this.groupOverTime.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupOverTime.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupOverTime.Name = "groupOverTime";
            this.groupOverTime.Size = new System.Drawing.Size(992, 568);
            this.groupOverTime.TabIndex = 27;
            this.groupOverTime.Text = "OverTime";
            // 
            // btnViewAll
            // 
            this.btnViewAll.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewAll.Appearance.Options.UseFont = true;
            this.btnViewAll.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnViewAll.Location = new System.Drawing.Point(464, 88);
            this.btnViewAll.Name = "btnViewAll";
            this.btnViewAll.Size = new System.Drawing.Size(72, 20);
            this.btnViewAll.TabIndex = 182;
            this.btnViewAll.Text = "View All";
            this.btnViewAll.Click += new System.EventHandler(this.btnViewAll_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.prevToMonth);
            this.groupControl1.Controls.Add(this.prevFromMonth);
            this.groupControl1.Controls.Add(this.btnPrevGo);
            this.groupControl1.Controls.Add(this.label5);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Controls.Add(this.prevToYear);
            this.groupControl1.Controls.Add(this.prevFromYear);
            this.groupControl1.Location = new System.Drawing.Point(16, 32);
            this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(560, 48);
            this.groupControl1.TabIndex = 181;
            // 
            // prevToMonth
            // 
            this.prevToMonth.Location = new System.Drawing.Point(272, 16);
            this.prevToMonth.Name = "prevToMonth";
            this.prevToMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.prevToMonth.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
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
            this.prevToMonth.Size = new System.Drawing.Size(72, 20);
            this.prevToMonth.TabIndex = 56;
            // 
            // prevFromMonth
            // 
            this.prevFromMonth.Location = new System.Drawing.Point(64, 16);
            this.prevFromMonth.Name = "prevFromMonth";
            this.prevFromMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.prevFromMonth.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
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
            this.prevFromMonth.Size = new System.Drawing.Size(72, 20);
            this.prevFromMonth.TabIndex = 55;
            // 
            // btnPrevGo
            // 
            this.btnPrevGo.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevGo.Appearance.Options.UseFont = true;
            this.btnPrevGo.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnPrevGo.Location = new System.Drawing.Point(448, 16);
            this.btnPrevGo.Name = "btnPrevGo";
            this.btnPrevGo.Size = new System.Drawing.Size(72, 20);
            this.btnPrevGo.TabIndex = 54;
            this.btnPrevGo.Text = "Go";
            this.btnPrevGo.Click += new System.EventHandler(this.btnPrevGo_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(240, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 16);
            this.label5.TabIndex = 53;
            this.label5.Text = "To";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 52;
            this.label4.Text = "From";
            // 
            // prevToYear
            // 
            this.prevToYear.EditValue = "cbGIROStatus";
            this.prevToYear.Location = new System.Drawing.Point(352, 16);
            this.prevToYear.Name = "prevToYear";
            this.prevToYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.prevToYear.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.prevToYear.Size = new System.Drawing.Size(80, 20);
            this.prevToYear.TabIndex = 51;
            // 
            // prevFromYear
            // 
            this.prevFromYear.EditValue = "cbGIROStatus";
            this.prevFromYear.Location = new System.Drawing.Point(144, 16);
            this.prevFromYear.Name = "prevFromYear";
            this.prevFromYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.prevFromYear.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.prevFromYear.Size = new System.Drawing.Size(72, 20);
            this.prevFromYear.TabIndex = 50;
            // 
            // cmbBranch
            // 
            this.cmbBranch.Location = new System.Drawing.Point(288, 88);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbBranch.Size = new System.Drawing.Size(120, 20);
            this.cmbBranch.TabIndex = 179;
            this.cmbBranch.SelectedValueChanged += new System.EventHandler(this.cmbBranch_SelectedValueChanged);
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(224, 88);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(56, 16);
            this.label25.TabIndex = 174;
            this.label25.Text = "Branch";
            // 
            // OvertimeStatus
            // 
            this.OvertimeStatus.EditValue = 0;
            this.OvertimeStatus.Location = new System.Drawing.Point(80, 88);
            this.OvertimeStatus.Name = "OvertimeStatus";
            this.OvertimeStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.OvertimeStatus.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Pending", 0, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Approved", 1, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Rejected", 2, -1)});
            this.OvertimeStatus.Size = new System.Drawing.Size(128, 20);
            this.OvertimeStatus.TabIndex = 124;
            this.OvertimeStatus.SelectedValueChanged += new System.EventHandler(this.OvertimeStatus_SelectedValueChanged);
            // 
            // label151
            // 
            this.label151.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label151.ForeColor = System.Drawing.Color.Black;
            this.label151.Location = new System.Drawing.Point(24, 88);
            this.label151.Name = "label151";
            this.label151.Size = new System.Drawing.Size(56, 16);
            this.label151.TabIndex = 19;
            this.label151.Text = "Status";
            // 
            // gridOverTime
            // 
            this.gridOverTime.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridOverTime.Location = new System.Drawing.Point(2, 118);
            this.gridOverTime.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridOverTime.MainView = this.gridViewOverTime;
            this.gridOverTime.Name = "gridOverTime";
            this.gridOverTime.Size = new System.Drawing.Size(988, 448);
            this.gridOverTime.TabIndex = 12;
            this.gridOverTime.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewOverTime});
            // 
            // gridViewOverTime
            // 
            this.gridViewOverTime.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn69,
            this.gridColumn62,
            this.gridColumn63,
            this.gridColumn64,
            this.gridColumn65,
            this.gridColumn5,
            this.gridColumn54,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.gridViewOverTime.GridControl = this.gridOverTime;
            this.gridViewOverTime.Name = "gridViewOverTime";
            this.gridViewOverTime.OptionsBehavior.Editable = false;
            this.gridViewOverTime.OptionsCustomization.AllowFilter = false;
            this.gridViewOverTime.OptionsCustomization.AllowSort = false;
            this.gridViewOverTime.OptionsView.ColumnAutoWidth = false;
            this.gridViewOverTime.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn69
            // 
            this.gridColumn69.Caption = "Date";
            this.gridColumn69.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gridColumn69.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn69.FieldName = "dtDate";
            this.gridColumn69.GroupFormat.FormatString = "dd/MM/yyyy";
            this.gridColumn69.GroupFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn69.Name = "gridColumn69";
            this.gridColumn69.Visible = true;
            this.gridColumn69.VisibleIndex = 0;
            this.gridColumn69.Width = 74;
            // 
            // gridColumn62
            // 
            this.gridColumn62.Caption = "Employee Id";
            this.gridColumn62.FieldName = "nEmployeeID";
            this.gridColumn62.Name = "gridColumn62";
            this.gridColumn62.Visible = true;
            this.gridColumn62.VisibleIndex = 1;
            this.gridColumn62.Width = 84;
            // 
            // gridColumn63
            // 
            this.gridColumn63.Caption = "Name";
            this.gridColumn63.FieldName = "strEmployeeName";
            this.gridColumn63.Name = "gridColumn63";
            this.gridColumn63.Visible = true;
            this.gridColumn63.VisibleIndex = 2;
            this.gridColumn63.Width = 148;
            // 
            // gridColumn64
            // 
            this.gridColumn64.Caption = "Start Time";
            this.gridColumn64.DisplayFormat.FormatString = "hh:mm:ss tt";
            this.gridColumn64.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn64.FieldName = "dtStartTime";
            this.gridColumn64.GroupFormat.FormatString = "hh:mm:ss tt";
            this.gridColumn64.GroupFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn64.Name = "gridColumn64";
            this.gridColumn64.Visible = true;
            this.gridColumn64.VisibleIndex = 3;
            this.gridColumn64.Width = 74;
            // 
            // gridColumn65
            // 
            this.gridColumn65.Caption = "End Time";
            this.gridColumn65.DisplayFormat.FormatString = "hh:mm:ss tt";
            this.gridColumn65.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn65.FieldName = "dtEndTime";
            this.gridColumn65.GroupFormat.FormatString = "hh:mm:ss tt";
            this.gridColumn65.GroupFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn65.Name = "gridColumn65";
            this.gridColumn65.Visible = true;
            this.gridColumn65.VisibleIndex = 4;
            this.gridColumn65.Width = 78;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Hours";
            this.gridColumn5.FieldName = "nHours";
            this.gridColumn5.GroupFormat.FormatString = "f";
            this.gridColumn5.GroupFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            // 
            // gridColumn54
            // 
            this.gridColumn54.Caption = "gridColumn54";
            this.gridColumn54.FieldName = "nOverTimeId";
            this.gridColumn54.Name = "gridColumn54";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Charging To ( 0-Time Off, 1-Overtime Pay)";
            this.gridColumn1.FieldName = "nChargingID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 6;
            this.gridColumn1.Width = 236;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Reason";
            this.gridColumn2.FieldName = "strReason";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 7;
            this.gridColumn2.Width = 109;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Approving Manager";
            this.gridColumn3.FieldName = "strApprovingManager";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 8;
            this.gridColumn3.Width = 106;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Status";
            this.gridColumn4.FieldName = "OvertimeStatus";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 9;
            this.gridColumn4.Width = 81;
            // 
            // btnApprove
            // 
            this.btnApprove.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.btnApprove.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApprove.Appearance.Options.UseBackColor = true;
            this.btnApprove.Appearance.Options.UseFont = true;
            this.btnApprove.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnApprove.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnApprove.Location = new System.Drawing.Point(544, 88);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(72, 20);
            this.btnApprove.TabIndex = 123;
            this.btnApprove.Text = "Approve";
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnReject
            // 
            this.btnReject.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.btnReject.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReject.Appearance.Options.UseBackColor = true;
            this.btnReject.Appearance.Options.UseFont = true;
            this.btnReject.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnReject.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnReject.Location = new System.Drawing.Point(624, 88);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(72, 20);
            this.btnReject.TabIndex = 124;
            this.btnReject.Text = "Reject";
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // btnClear
            // 
            this.btnClear.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Appearance.Options.UseFont = true;
            this.btnClear.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnClear.Location = new System.Drawing.Point(702, 88);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(112, 20);
            this.btnClear.TabIndex = 183;
            this.btnClear.Text = "Clear OT Balance";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frmOvertimeMain
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(992, 568);
            this.Controls.Add(this.groupOverTime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmOvertimeMain";
            this.Text = "frmOvertimeMain";
            this.Load += new System.EventHandler(this.frmOvertimeMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupOverTime)).EndInit();
            this.groupOverTime.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.prevToMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prevFromMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prevToYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prevFromYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBranch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OvertimeStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridOverTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOverTime)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		# region Overtime

		
		private string status;
		private void LoadOvertime()
		{
			DataSet _ds = new DataSet();
			string strSQL,sql;

			sql = "";
			strSQL = "Up_get_Overtime '" + oUser.NEmployeeID() + "' ,'" + cmbBranch.EditValue.ToString()+ "'";
						
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			DataTable dt = _ds.Tables["Table"];
			DataView dv = new DataView(dt);

			DateTime thisMonth,NextMonth;

			thisMonth=new DateTime(ACMS.Convert.ToDBInt32(prevFromYear.EditValue),ACMS.Convert.ToDBInt32(prevFromMonth.EditValue),1,0,0,0,1);
			NextMonth=new DateTime(ACMS.Convert.ToDBInt32(prevToYear.EditValue),ACMS.Convert.ToDBInt32(prevToMonth.EditValue),1,0,0,0,1);

			NextMonth=NextMonth.AddMonths(1);

			if (status =="first") return;

			sql = "dtStartTime >= '" + thisMonth.ToLongDateString() + "' And dtStartTime < '"+ NextMonth.ToShortDateString() +"'";
			sql += "And nStatusID = " + OvertimeStatus.EditValue;

			if (status != "ViewAll"  && cmbBranch.EditValue.ToString()!="")
			{
				sql += " And strBranchCode = '" + cmbBranch.EditValue + "'";
			}
			
			dv.RowFilter = sql;
			gridOverTime.DataSource = dv;
			
		}

        private void ClearOTBalance()
        {          
			string strSQL,sql;
			sql = "";
            strSQL = "sp_tblOverTime_MonthlyClear";

            SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, strSQL);
        }


		private void btnApprove_Click(object sender, System.EventArgs e)
		{	
			
			if (gridViewOverTime.RowCount > 0)
			{
				DataRow dr = this.gridViewOverTime.GetDataRow(this.gridViewOverTime.FocusedRowHandle);
				if ( dr != null)
				{
					frmApprovedOvertime myOT = new frmApprovedOvertime(ConvertToInt(dr["nOverTimeId"]),ConvertToInt(oUser.NEmployeeID()));
					myOT.ShowDialog();
					//myOT.Dispose();
				}
					
				
				LoadOvertime();
			}
		}

		private void btnReject_Click(object sender, System.EventArgs e)
		{
			if (gridViewOverTime.RowCount > 0)
			{
				DataRow dr = this.gridViewOverTime.GetDataRow(this.gridViewOverTime.FocusedRowHandle);
			
				int output;
				output = 0;

				SqlHelper.ExecuteNonQuery(connection,"up_tblOverTime_dw",
					new SqlParameter("@retval",output),
					new SqlParameter("@nOverTimeId",dr["nOverTimeId"].ToString()),								
					new SqlParameter("@Status",2)
					);

				LoadOvertime();

			}
		}

		private void OvertimeStatus_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			LoadOvertime();
		}

		# endregion

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
		
		private void comboBind(DevExpress.XtraEditors.ImageComboBoxEdit control,string strSQL,string display,string strValue)
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
					properties.Items.Add( new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr[display].ToString(), dr[strValue].ToString(),-1));
				}
			}
			finally 
			{
				properties.Items.EndUpdate();
			}
			//Select the first item
			control.SelectedIndex = 0;
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
		

		#endregion

		#region security
		public void initData (ACMSLogic.User User)
		{
			oUser = User;
			MemberRecord myMemberRecord = new MemberRecord(oUser.StrBranchCode());
		}

		public void SetEmployeeRecord(Do.Employee emp)
		{
			employee = emp;
		}

		public void SetTerminalUser(Do.TerminalUser tu)
		{
			terminalUser = tu;

		}

		#endregion


		private void frmOvertimeMain_Load(object sender, System.EventArgs e)
		{
			//string strSQL = "select distinct Year(dtDate) as strYear from TblOvertime";

			//comboBind(prevFromYear, strSQL, "strYear", "strYear", true);
			//comboBind(prevToYear, strSQL, "strYear", "strYear", true);
			LoadYear(prevFromYear);
			LoadYear(prevToYear);

			prevFromYear.EditValue = DateTime.Now.Year;
			prevToYear.EditValue = DateTime.Now.Year;
			//prevFromMonth.EditValue = DateTime.Now.Month - 3;
            prevFromMonth.EditValue = DateTime.Now.Month;
			prevToMonth.EditValue = DateTime.Now.Month;

            //if (prevToMonth.EditValue.ToString()== "1")
            //{
            //    this.prevFromMonth.EditValue = DateTime.Now.Month;
            //}

			status="first";

			BindBranch();
			LoadOvertime();
			status="cont";

		
		}

		private void LoadYear(DevExpress.XtraEditors.ImageComboBoxEdit control)
		{
			DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox properties = control.Properties;
			properties.Items.BeginUpdate();
			properties.Items.Clear();

			try 
			{
				for (int i=1999; i<=2999; i++)
				{
					//Initialize each item with the display text, value and image index
					properties.Items.Add( new DevExpress.XtraEditors.Controls.ImageComboBoxItem(i.ToString(), i,-1));
				}
			}
			finally 
			{
				properties.Items.EndUpdate();
			}
			//Select the first item
			control.SelectedIndex = 0;
			
		}

		private void btnPrevGo_Click(object sender, System.EventArgs e)
		{
			LoadOvertime();
		}

		private void OvertimeStatus_SelectedValueChanged(object sender, System.EventArgs e)
		{
			if (OvertimeStatus.EditValue.ToString() != "0")
			{
				//btnApprove.Visible = false;
				//btnReject.Visible = false;
			}
			else
			{
				btnApprove.Visible = true;
				btnReject.Visible = true;
			}
			LoadOvertime();
	
		}

		private void BindBranch()
		{
			ACMSLogic.User oUser = new User();
			string strSQL = "Select strBranchCode,strBranchName from TblBranch Where nBrStatusID =1 and strBranchCode In (Select strBranchCode from tblemployeebranchrights Where nEmployeeId = " + oUser.NEmployeeID() + ")";
			comboBind(cmbBranch, strSQL, "strBranchName", "strBranchCode", true);
			cmbBranch.Properties.Items.Insert(0,new DevExpress.XtraEditors.Controls.ImageComboBoxItem("- Please Select -",""));
			cmbBranch.SelectedIndex = 0;
		}		

		private void btnViewAll_Click(object sender, System.EventArgs e)
		{
			status = "ViewAll";
			cmbBranch.EditValue = "";
			LoadOvertime();

		}

		private void cmbBranch_SelectedValueChanged(object sender, System.EventArgs e)
		{
			LoadOvertime();
		
		}

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearOTBalance();
            MessageBox.Show("You have successfully Clear All Branches unUsed OT");
        }
	
	}
}
