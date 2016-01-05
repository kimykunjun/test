using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;
using DevExpress.XtraGrid.Views.Grid;

//using Rp = Acms.Core.Repository;
//using Fc = Acms.Core.Factory;
using Do = Acms.Core.Domain;
using ACMSLogic;

namespace ACMS.ACMSManager.Human_Resource
{
	/// <summary>
	/// Summary description for frmRosterDetail.
	/// </summary>
	public class frmLeave : System.Windows.Forms.Form
	{
		private static Do.Employee employee;
		private static Do.TerminalUser terminalUser; 
		private static User oUser;
		private string _strBranchCode;

		private string connectionString;
		private SqlConnection connection;

		private DevExpress.XtraEditors.GroupControl groupControl2;
		private DevExpress.XtraEditors.ImageComboBoxEdit prevToMonth;
		private DevExpress.XtraEditors.ImageComboBoxEdit prevFromMonth;
		internal DevExpress.XtraEditors.SimpleButton btnPrevGo;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private DevExpress.XtraEditors.ImageComboBoxEdit prevToYear;
		private DevExpress.XtraEditors.ImageComboBoxEdit prevFromYear;
		private DevExpress.XtraEditors.GroupControl groupControl1;
		private DevExpress.XtraGrid.GridControl gridLeaveDetails;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewLeaveDetails;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
		internal DevExpress.XtraEditors.SimpleButton btnReject;
		internal DevExpress.XtraEditors.SimpleButton btnApprove;
		internal DevExpress.XtraEditors.SimpleButton btnViewAll;
		private DevExpress.XtraEditors.ImageComboBoxEdit cmbBranch;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label2;
		private DevExpress.XtraEditors.ImageComboBoxEdit ddlStatus;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraGrid.Columns.GridColumn appliedDate;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chk_TimeOff;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraGrid.Columns.GridColumn unPaid;
		internal DevExpress.XtraEditors.SimpleButton btn_Cancel;
		internal DevExpress.XtraEditors.SimpleButton btn_Convert;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmLeave()
		{
			//
			// Required for Windows Form Designer support
			//
			
			InitializeComponent();
			
			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);
			
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
			this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
			this.prevToMonth = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.prevFromMonth = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.btnPrevGo = new DevExpress.XtraEditors.SimpleButton();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.prevToYear = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.prevFromYear = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
			this.btn_Convert = new DevExpress.XtraEditors.SimpleButton();
			this.btn_Cancel = new DevExpress.XtraEditors.SimpleButton();
			this.gridLeaveDetails = new DevExpress.XtraGrid.GridControl();
			this.gridViewLeaveDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.unPaid = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.chk_TimeOff = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.appliedDate = new DevExpress.XtraGrid.Columns.GridColumn();
			this.btnReject = new DevExpress.XtraEditors.SimpleButton();
			this.btnApprove = new DevExpress.XtraEditors.SimpleButton();
			this.btnViewAll = new DevExpress.XtraEditors.SimpleButton();
			this.cmbBranch = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.label25 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.ddlStatus = new DevExpress.XtraEditors.ImageComboBoxEdit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
			this.groupControl2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.prevToMonth.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.prevFromMonth.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.prevToYear.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.prevFromYear.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
			this.groupControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridLeaveDetails)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewLeaveDetails)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chk_TimeOff)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbBranch.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ddlStatus.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// groupControl2
			// 
			this.groupControl2.Controls.Add(this.prevToMonth);
			this.groupControl2.Controls.Add(this.prevFromMonth);
			this.groupControl2.Controls.Add(this.btnPrevGo);
			this.groupControl2.Controls.Add(this.label5);
			this.groupControl2.Controls.Add(this.label4);
			this.groupControl2.Controls.Add(this.prevToYear);
			this.groupControl2.Controls.Add(this.prevFromYear);
			this.groupControl2.Location = new System.Drawing.Point(16, 32);
			this.groupControl2.LookAndFeel.UseDefaultLookAndFeel = false;
			this.groupControl2.LookAndFeel.UseWindowsXPTheme = false;
			this.groupControl2.Name = "groupControl2";
			this.groupControl2.Size = new System.Drawing.Size(560, 48);
			this.groupControl2.TabIndex = 191;
			// 
			// prevToMonth
			// 
			this.prevToMonth.Location = new System.Drawing.Point(272, 16);
			this.prevToMonth.Name = "prevToMonth";
			// 
			// prevToMonth.Properties
			// 
			this.prevToMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.prevToMonth.Properties.Items.AddRange(new object[] {
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
			// 
			// prevFromMonth.Properties
			// 
			this.prevFromMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.prevFromMonth.Properties.Items.AddRange(new object[] {
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
			this.btnPrevGo.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
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
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.Location = new System.Drawing.Point(240, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(24, 16);
			this.label5.TabIndex = 53;
			this.label5.Text = "To";
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
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
			// 
			// prevToYear.Properties
			// 
			this.prevToYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.prevToYear.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.prevToYear.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.prevToYear.Size = new System.Drawing.Size(80, 20);
			this.prevToYear.TabIndex = 51;
			// 
			// prevFromYear
			// 
			this.prevFromYear.EditValue = "cbGIROStatus";
			this.prevFromYear.Location = new System.Drawing.Point(144, 16);
			this.prevFromYear.Name = "prevFromYear";
			// 
			// prevFromYear.Properties
			// 
			this.prevFromYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.prevFromYear.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.prevFromYear.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.prevFromYear.Size = new System.Drawing.Size(72, 20);
			this.prevFromYear.TabIndex = 50;
			// 
			// groupControl1
			// 
			this.groupControl1.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.groupControl1.Appearance.Options.UseBackColor = true;
			this.groupControl1.Controls.Add(this.btn_Convert);
			this.groupControl1.Controls.Add(this.btn_Cancel);
			this.groupControl1.Controls.Add(this.gridLeaveDetails);
			this.groupControl1.Controls.Add(this.btnReject);
			this.groupControl1.Controls.Add(this.btnApprove);
			this.groupControl1.Controls.Add(this.btnViewAll);
			this.groupControl1.Controls.Add(this.cmbBranch);
			this.groupControl1.Controls.Add(this.label25);
			this.groupControl1.Controls.Add(this.label2);
			this.groupControl1.Controls.Add(this.ddlStatus);
			this.groupControl1.Controls.Add(this.groupControl2);
			this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupControl1.Location = new System.Drawing.Point(0, 0);
			this.groupControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
			this.groupControl1.Name = "groupControl1";
			this.groupControl1.Size = new System.Drawing.Size(992, 568);
			this.groupControl1.TabIndex = 198;
			this.groupControl1.Text = "Leave Details";
			this.groupControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupControl1_Paint);
			// 
			// btn_Convert
			// 
			this.btn_Convert.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btn_Convert.Appearance.Options.UseFont = true;
			this.btn_Convert.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btn_Convert.Location = new System.Drawing.Point(784, 88);
			this.btn_Convert.Name = "btn_Convert";
			this.btn_Convert.Size = new System.Drawing.Size(72, 20);
			this.btn_Convert.TabIndex = 207;
			this.btn_Convert.Text = "Convert";
			this.btn_Convert.Click += new System.EventHandler(this.btn_Convert_Click);
			// 
			// btn_Cancel
			// 
			this.btn_Cancel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btn_Cancel.Appearance.Options.UseFont = true;
			this.btn_Cancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btn_Cancel.Location = new System.Drawing.Point(704, 88);
			this.btn_Cancel.Name = "btn_Cancel";
			this.btn_Cancel.Size = new System.Drawing.Size(72, 20);
			this.btn_Cancel.TabIndex = 206;
			this.btn_Cancel.Text = "Cancel";
			this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
			// 
			// gridLeaveDetails
			// 
			this.gridLeaveDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
			// 
			// gridLeaveDetails.EmbeddedNavigator
			// 
			this.gridLeaveDetails.EmbeddedNavigator.Name = "";
			this.gridLeaveDetails.Location = new System.Drawing.Point(4, 116);
			this.gridLeaveDetails.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.gridLeaveDetails.LookAndFeel.UseDefaultLookAndFeel = false;
			this.gridLeaveDetails.MainView = this.gridViewLeaveDetails;
			this.gridLeaveDetails.Name = "gridLeaveDetails";
			this.gridLeaveDetails.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																													  this.chk_TimeOff});
			this.gridLeaveDetails.Size = new System.Drawing.Size(984, 448);
			this.gridLeaveDetails.TabIndex = 205;
			this.gridLeaveDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																											this.gridViewLeaveDetails});
			// 
			// gridViewLeaveDetails
			// 
			this.gridViewLeaveDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																										this.gridColumn3,
																										this.gridColumn1,
																										this.gridColumn2,
																										this.gridColumn5,
																										this.gridColumn4,
																										this.gridColumn6,
																										this.gridColumn7,
																										this.gridColumn8,
																										this.unPaid,
																										this.gridColumn9,
																										this.gridColumn10,
																										this.gridColumn11,
																										this.gridColumn13,
																										this.gridColumn12,
																										this.appliedDate});
			this.gridViewLeaveDetails.GridControl = this.gridLeaveDetails;
			this.gridViewLeaveDetails.Name = "gridViewLeaveDetails";
			this.gridViewLeaveDetails.OptionsBehavior.Editable = false;
			this.gridViewLeaveDetails.OptionsCustomization.AllowFilter = false;
			this.gridViewLeaveDetails.OptionsCustomization.AllowSort = false;
			this.gridViewLeaveDetails.OptionsView.ColumnAutoWidth = false;
			this.gridViewLeaveDetails.OptionsView.ShowGroupPanel = false;
			this.gridViewLeaveDetails.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridViewLeaveDetails_RowStyle);
			// 
			// gridColumn3
			// 
			this.gridColumn3.Caption = "Date";
			this.gridColumn3.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.gridColumn3.FieldName = "dtStartTime";
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 0;
			this.gridColumn3.Width = 69;
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "ID";
			this.gridColumn1.FieldName = "nEmployeeID";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 1;
			this.gridColumn1.Width = 53;
			// 
			// gridColumn2
			// 
			this.gridColumn2.Caption = "Name";
			this.gridColumn2.FieldName = "strEmployeeName";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 2;
			this.gridColumn2.Width = 173;
			// 
			// gridColumn5
			// 
			this.gridColumn5.Caption = "Roster ID";
			this.gridColumn5.FieldName = "nLeaveID";
			this.gridColumn5.Name = "gridColumn5";
			// 
			// gridColumn4
			// 
			this.gridColumn4.Caption = "Type";
			this.gridColumn4.FieldName = "LeaveType";
			this.gridColumn4.Name = "gridColumn4";
			this.gridColumn4.Visible = true;
			this.gridColumn4.VisibleIndex = 3;
			// 
			// gridColumn6
			// 
			this.gridColumn6.Caption = "Start Time";
			this.gridColumn6.DisplayFormat.FormatString = "hh:mm:ss tt";
			this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.gridColumn6.FieldName = "dtStartTime";
			this.gridColumn6.Name = "gridColumn6";
			this.gridColumn6.Visible = true;
			this.gridColumn6.VisibleIndex = 4;
			this.gridColumn6.Width = 88;
			// 
			// gridColumn7
			// 
			this.gridColumn7.Caption = "End Time";
			this.gridColumn7.DisplayFormat.FormatString = "hh:mm:ss tt";
			this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.gridColumn7.FieldName = "dtEndTime";
			this.gridColumn7.Name = "gridColumn7";
			this.gridColumn7.Visible = true;
			this.gridColumn7.VisibleIndex = 5;
			this.gridColumn7.Width = 87;
			// 
			// gridColumn8
			// 
			this.gridColumn8.Caption = "Duration";
			this.gridColumn8.FieldName = "Duration";
			this.gridColumn8.Name = "gridColumn8";
			this.gridColumn8.Visible = true;
			this.gridColumn8.VisibleIndex = 6;
			this.gridColumn8.Width = 78;
			// 
			// unPaid
			// 
			this.unPaid.Caption = "UnPaid";
			this.unPaid.FieldName = "unPaid";
			this.unPaid.Name = "unPaid";
			this.unPaid.Visible = true;
			this.unPaid.VisibleIndex = 7;
			// 
			// gridColumn9
			// 
			this.gridColumn9.Caption = "Time Off";
			this.gridColumn9.ColumnEdit = this.chk_TimeOff;
			this.gridColumn9.FieldName = "fTimeOff";
			this.gridColumn9.Name = "gridColumn9";
			this.gridColumn9.Visible = true;
			this.gridColumn9.VisibleIndex = 8;
			this.gridColumn9.Width = 60;
			// 
			// chk_TimeOff
			// 
			this.chk_TimeOff.AutoHeight = false;
			this.chk_TimeOff.Name = "chk_TimeOff";
			// 
			// gridColumn10
			// 
			this.gridColumn10.Caption = "Status";
			this.gridColumn10.FieldName = "LeaveStatus";
			this.gridColumn10.Name = "gridColumn10";
			this.gridColumn10.Visible = true;
			this.gridColumn10.VisibleIndex = 9;
			this.gridColumn10.Width = 85;
			// 
			// gridColumn11
			// 
			this.gridColumn11.Caption = "Reason";
			this.gridColumn11.FieldName = "strRemarks";
			this.gridColumn11.Name = "gridColumn11";
			this.gridColumn11.Visible = true;
			this.gridColumn11.VisibleIndex = 10;
			this.gridColumn11.Width = 137;
			// 
			// gridColumn13
			// 
			this.gridColumn13.Caption = "gridColumn13";
			this.gridColumn13.FieldName = "nStatusID";
			this.gridColumn13.Name = "gridColumn13";
			// 
			// gridColumn12
			// 
			this.gridColumn12.Caption = "Approving Manager";
			this.gridColumn12.FieldName = "ApprovedManager";
			this.gridColumn12.Name = "gridColumn12";
			this.gridColumn12.Visible = true;
			this.gridColumn12.VisibleIndex = 11;
			this.gridColumn12.Width = 125;
			// 
			// appliedDate
			// 
			this.appliedDate.Caption = "Date Request";
			this.appliedDate.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.appliedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.appliedDate.FieldName = "dtDate";
			this.appliedDate.Name = "appliedDate";
			this.appliedDate.Visible = true;
			this.appliedDate.VisibleIndex = 12;
			// 
			// btnReject
			// 
			this.btnReject.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnReject.Appearance.Options.UseFont = true;
			this.btnReject.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnReject.Location = new System.Drawing.Point(624, 88);
			this.btnReject.Name = "btnReject";
			this.btnReject.Size = new System.Drawing.Size(72, 20);
			this.btnReject.TabIndex = 204;
			this.btnReject.Text = "Reject";
			this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
			// 
			// btnApprove
			// 
			this.btnApprove.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnApprove.Appearance.Options.UseFont = true;
			this.btnApprove.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnApprove.Location = new System.Drawing.Point(544, 88);
			this.btnApprove.Name = "btnApprove";
			this.btnApprove.Size = new System.Drawing.Size(72, 20);
			this.btnApprove.TabIndex = 203;
			this.btnApprove.Text = "Approve";
			this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
			// 
			// btnViewAll
			// 
			this.btnViewAll.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnViewAll.Appearance.Options.UseFont = true;
			this.btnViewAll.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnViewAll.Location = new System.Drawing.Point(464, 88);
			this.btnViewAll.Name = "btnViewAll";
			this.btnViewAll.Size = new System.Drawing.Size(72, 20);
			this.btnViewAll.TabIndex = 202;
			this.btnViewAll.Text = "View All";
			this.btnViewAll.Click += new System.EventHandler(this.btnViewAll_Click);
			// 
			// cmbBranch
			// 
			this.cmbBranch.Location = new System.Drawing.Point(288, 88);
			this.cmbBranch.Name = "cmbBranch";
			// 
			// cmbBranch.Properties
			// 
			this.cmbBranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cmbBranch.Size = new System.Drawing.Size(120, 20);
			this.cmbBranch.TabIndex = 201;
			this.cmbBranch.SelectedValueChanged += new System.EventHandler(this.cmbBranch_SelectedValueChanged);
			// 
			// label25
			// 
			this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label25.ForeColor = System.Drawing.Color.Black;
			this.label25.Location = new System.Drawing.Point(224, 88);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(56, 16);
			this.label25.TabIndex = 200;
			this.label25.Text = "Branch";
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(24, 88);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 23);
			this.label2.TabIndex = 199;
			this.label2.Text = "Status";
			// 
			// ddlStatus
			// 
			this.ddlStatus.EditValue = 0;
			this.ddlStatus.Location = new System.Drawing.Point(80, 88);
			this.ddlStatus.Name = "ddlStatus";
			// 
			// ddlStatus.Properties
			// 
			this.ddlStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.ddlStatus.Properties.Items.AddRange(new object[] {
																	  new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Pending", 0, -1),
																	  new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Approved", 1, -1),
																	  new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Rejected", 2, -1)});
			this.ddlStatus.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.ddlStatus.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.ddlStatus.Size = new System.Drawing.Size(112, 20);
			this.ddlStatus.TabIndex = 198;
			this.ddlStatus.SelectedIndexChanged += new System.EventHandler(this.ddlStatus_SelectedIndexChanged_1);
			this.ddlStatus.SelectedValueChanged += new System.EventHandler(this.ddlStatus_SelectedIndexChanged);
			// 
			// frmLeave
			// 
			this.AutoScale = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(992, 568);
			this.Controls.Add(this.groupControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmLeave";
			this.Text = "Leave detail";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmLeave_Load);
			((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
			this.groupControl2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.prevToMonth.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.prevFromMonth.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.prevToYear.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.prevFromYear.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
			this.groupControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridLeaveDetails)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewLeaveDetails)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chk_TimeOff)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbBranch.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ddlStatus.Properties)).EndInit();
			this.ResumeLayout(false);

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

		# region Leave
		private string status;
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

		private void LoadLeaveDetail()
		{
			User oUser = new User();
			//Up_get_LeaveDetailList
			DataTable dt;
			string strSQL;
			strSQL = "Up_get_LeaveDetails'" + oUser.NEmployeeID() + "','" + cmbBranch.EditValue.ToString()+ "'";
			
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dt = _ds.Tables["table"];

			DataView dv = new DataView(dt);
			string sql = "";
			//string sql = " (MM >= " + this.prevFromMonth.EditValue + " And YY >=" + this.prevFromYear.EditValue  + ") And (MM <= " + this.prevToMonth.EditValue + " And YY <=" + this.prevToYear.EditValue  + ")"; 			
		
			DateTime thisMonth,NextMonth;

			thisMonth=new DateTime(ACMS.Convert.ToDBInt32(prevFromYear.EditValue),ACMS.Convert.ToDBInt32(prevFromMonth.EditValue),1,0,0,0,1);
			NextMonth=new DateTime(ACMS.Convert.ToDBInt32(prevToYear.EditValue),ACMS.Convert.ToDBInt32(prevToMonth.EditValue),1,0,0,0,1);
			
			NextMonth=NextMonth.AddMonths(1);


			sql = "dtStartTime >= '" + thisMonth.ToLongDateString() + "' And dtStartTime < '"+ NextMonth.ToShortDateString() +"'";
			sql += "And nStatusID = " + ddlStatus.EditValue;

			if (status != "ViewAll")
			{
		//		sql = string.Format("dtStartTime >= #{1}-{0}-01# And dtStartTime < #{3}-{2}-01#", Convert.ToInt32(prevFromMonth.EditValue).ToString("0#"), prevFromYear.Text, (Convert.ToInt32(prevToMonth.EditValue)+1).ToString("0#"), prevToYear.Text);
				if (cmbBranch.EditValue != null && cmbBranch.EditValue.ToString() != "")
				sql += " And strBranchCode = '" + cmbBranch.EditValue + "'";
			}
			dv.RowFilter = sql;

            this.gridLeaveDetails.DataSource = dv;
			status = "";
		}

		private void BindBranch()
		{
			ACMSLogic.User oUser = new User();
			string strSQL = "Select strBranchCode,strBranchName from TblBranch Where strBranchCode In (Select strBranchCode from tblemployeebranchrights Where nEmployeeId = " + oUser.NEmployeeID() + ")";
			comboBind(cmbBranch, strSQL, "strBranchName", "strBranchCode", true);
			cmbBranch.Properties.Items.Insert(0,new DevExpress.XtraEditors.Controls.ImageComboBoxItem("- Please Select -",""));
			cmbBranch.SelectedIndex = 0;
		}

		private void btnApprove_Click(object sender, System.EventArgs e)
		{
			if (gridViewLeaveDetails.RowCount > 0)
			{
				DataRow dr = this.gridViewLeaveDetails.GetDataRow(this.gridViewLeaveDetails.FocusedRowHandle);

				int output;
				output = 0;

				if( employee.CanAccess("AM_APPROVE_LEAVE",terminalUser.Branch.Id))
				{
					//ACMSLogic.Staff.Leave StaffLeave= new ACMSLogic.Staff.Leave();

					//double nStaffYear=StaffLeave.GetActual_AnnualBalance(ACMS.Convert.ToDBInt32(dr["nEmployeeID"]),ACMS.Convert.ToInt32(dr["nYearID"]),ACMS.Convert.ToDBDateTime(dr["dtStartTime"]));

					SqlHelper.ExecuteNonQuery(connection,"up_Leave_Approved",
						new SqlParameter("@retval",output),
						new SqlParameter("@LeaveID",dr["nLeaveID"].ToString()),
						new SqlParameter("@nEmployeeID",dr["nEmployeeID"].ToString()),
						new SqlParameter("@ApprovedManagerID",oUser.NEmployeeID())
						);
				}
				else
				{	
					MessageBox.Show("You don't have sufficient right to delete roster record");
				}
			}
			else
			{
				MessageBox.Show("Please select a leave to be approved.");
			}
			//this.Dispose();		
			LoadLeaveDetail();
		}

		private void btnReject_Click(object sender, System.EventArgs e)
		{
		
			if (gridViewLeaveDetails.RowCount > 0)
			{
				DataRow dr = this.gridViewLeaveDetails.GetDataRow(this.gridViewLeaveDetails.FocusedRowHandle);

				int output;
				output = 0;
				
				if( employee.CanAccess("AM_REJECT_LEAVE",terminalUser.Branch.Id))
				{
					SqlHelper.ExecuteNonQuery(connection,"up_Leave_Rejected",
						new SqlParameter("@retval",output),
						new SqlParameter("@LeaveID",dr["nLeaveID"].ToString()),
						new SqlParameter("@nEmployeeID",dr["nEmployeeID"].ToString()),
						new SqlParameter("@ApprovedManagerID",oUser.NEmployeeID())
						);
					
				}
				else
				{	
					MessageBox.Show("You don't have sufficient right to delete roster record");
				}
			}
			else
			{
				MessageBox.Show("Please select a leave to be rejected.");
			}

			//this.Dispose();	
			LoadLeaveDetail();

		}

		private void ddlStatus_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (ddlStatus.EditValue.ToString() != "0")
			{
				btnApprove.Visible = false;
				btnReject.Visible = true;
			}
			else
			{
				btnApprove.Visible = true;
				btnReject.Visible = true;
			}

			LoadLeaveDetail();
		
		}
		private void cmbBranch_SelectedValueChanged(object sender, System.EventArgs e)
		{
			LoadLeaveDetail();
		}

		private void btnViewAll_Click(object sender, System.EventArgs e)
		{
			status = "ViewAll";
			LoadLeaveDetail();
		}

		private void btnPrevGo_Click(object sender, System.EventArgs e)
		{
			LoadLeaveDetail();
		}

		private void frmLeave_Load(object sender, System.EventArgs e)
		{
			btn_Cancel.Visible=false;
			btn_Convert.Visible=false;

			LoadYear(prevFromYear);
			LoadYear(prevToYear);

			prevFromYear.EditValue = DateTime.Now.Year;
			prevToYear.EditValue = DateTime.Now.Year;

			this.prevFromMonth.EditValue = DateTime.Now.Month;
			this.prevToMonth.EditValue = DateTime.Now.Month;

            //if (prevToMonth.EditValue.ToString()== "1")
            //{
            //    this.prevFromMonth.EditValue = DateTime.Now.Month;
            //}


			BindBranch();
			LoadLeaveDetail();
		}

		private void gridViewLeaveDetails_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
		{
			GridView view = sender as GridView;

			if(e.RowHandle >= 0) 
			{
				DataRow r = view.GetDataRow(e.RowHandle);
				if(r != null && ACMS.Convert.ToDecimal(r["UnPaid"])>0) 
				{
					e.Appearance.ForeColor = Color.Red;
				}
			}
		}

		# endregion

		public string strBranchCode
		{
			get
			{
				return _strBranchCode;
			}
			set
			{
				_strBranchCode = value;
			}
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

	
		private void btn_Convert_Click(object sender, System.EventArgs e)
		{
			
			if (gridViewLeaveDetails.RowCount > 0)
			{
				DataRow dr = this.gridViewLeaveDetails.GetDataRow(this.gridViewLeaveDetails.FocusedRowHandle);

				int output;
				output = 0;

				if( employee.CanAccess("AM_CONVERT_LEAVE",terminalUser.Branch.Id))
				{
					//ACMSLogic.Staff.Leave StaffLeave= new ACMSLogic.Staff.Leave();

					//double nStaffYear=StaffLeave.GetActual_AnnualBalance(ACMS.Convert.ToDBInt32(dr["nEmployeeID"]),ACMS.Convert.ToInt32(dr["nYearID"]),ACMS.Convert.ToDBDateTime(dr["dtStartTime"]));
					if (ACMS.Convert.ToDecimal(dr["UnPaid"])>0 && dr["LeaveType"].ToString()=="ANNUAL LEAVE") 
					{
						SqlHelper.ExecuteNonQuery(connection,"up_Leave_Convert",
							new SqlParameter("@retval",output),
							new SqlParameter("@LeaveID",dr["nLeaveID"].ToString()),
							new SqlParameter("@nEmployeeID",dr["nEmployeeID"].ToString()),
							new SqlParameter("@ApprovedManagerID",oUser.NEmployeeID())
							);
					}
					else
					{
						MessageBox.Show("This record cannot be converted.");
					}
				}
				else
				{	
					MessageBox.Show("You don't have sufficient right on this event");
				}
			}
			else
			{
				MessageBox.Show("Please select a record to be convert.");
			}
			//this.Dispose();		
			LoadLeaveDetail();
		}

		private void ddlStatus_SelectedIndexChanged_1(object sender, System.EventArgs e)
		{
			if (ddlStatus.Text=="Approved")
			{
				btn_Cancel.Visible=true;
				btn_Convert.Visible=true;
			}
		}

		private void btn_Cancel_Click(object sender, System.EventArgs e)
		{
			if (gridViewLeaveDetails.RowCount > 0)
			{
				DataRow dr = this.gridViewLeaveDetails.GetDataRow(this.gridViewLeaveDetails.FocusedRowHandle);

				int output;
				output = 0;

				if( employee.CanAccess("AM_CANCEL_LEAVE",terminalUser.Branch.Id))
				{
					//ACMSLogic.Staff.Leave StaffLeave= new ACMSLogic.Staff.Leave();

					//double nStaffYear=StaffLeave.GetActual_AnnualBalance(ACMS.Convert.ToDBInt32(dr["nEmployeeID"]),ACMS.Convert.ToInt32(dr["nYearID"]),ACMS.Convert.ToDBDateTime(dr["dtStartTime"]));

					SqlHelper.ExecuteNonQuery(connection,"up_Leave_Cancel",
						new SqlParameter("@retval",output),
						new SqlParameter("@LeaveID",dr["nLeaveID"].ToString()),
						new SqlParameter("@nEmployeeID",dr["nEmployeeID"].ToString()),
						new SqlParameter("@ApprovedManagerID",oUser.NEmployeeID())
						);
				}
				else
				{	
					MessageBox.Show("You don't have sufficient right on this event");
				}
			}
			else
			{
				MessageBox.Show("Please select a record to be cancelled.");
			}
			//this.Dispose();		
			LoadLeaveDetail();

		}

		private void groupControl1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		
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
	}
}
