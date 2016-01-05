using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;

//using Rp = Acms.Core.Repository;
//using Fc = Acms.Core.Factory;
using Do = Acms.Core.Domain;
using ACMSLogic;


namespace ACMS.ACMSBranch
{
	/// <summary>
	/// Summary description for frmRoster.
	/// </summary>
	public class frmRoster : System.Windows.Forms.Form
	{
		private Do.Employee employee;
		private Do.TerminalUser terminalUser; 
		User oUser;

		private string connectionString;
		private SqlConnection connection;
		private DateTime dtDate;
		private string EmployeeId;
		private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
		private DevExpress.XtraEditors.GroupControl groupControl1;
		private System.Windows.Forms.Label label2;
		private DevExpress.XtraEditors.ImageComboBoxEdit ddlStatus;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
		private DevExpress.XtraGrid.GridControl gridLoginDetails;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage4;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
		private DevExpress.XtraGrid.GridControl gridAppointment;
		private DevExpress.XtraGrid.GridControl gridControlRoster;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewRoster;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraGrid.GridControl gridLeaveDetails;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewLeaveDetails;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		#region Initialize Data from Login
		public void initData (ACMSLogic.User User)
		{
			oUser = User;
			MemberRecord myMemberRecord = new MemberRecord(oUser.StrBranchCode());
		}

		public void SetEmployeeRecord(Do.Employee employee)
		{
			this.employee = employee;
		}

		public void SetTerminalUser(Do.TerminalUser terminalUser)
		{
			this.terminalUser = terminalUser;
		}

		#endregion

		public frmRoster(string empID,string ndtDate)
		{
			//
			// Required for Windows Form Designer support
			//
			EmployeeId = empID;
			InitializeComponent();
			dtDate = Convert.ToDateTime(ndtDate);
			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);
			init(empID);

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
			this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
			this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
			this.gridControlRoster = new DevExpress.XtraGrid.GridControl();
			this.gridViewRoster = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
			this.gridLeaveDetails = new DevExpress.XtraGrid.GridControl();
			this.gridViewLeaveDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
			this.label2 = new System.Windows.Forms.Label();
			this.ddlStatus = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
			this.gridLoginDetails = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.xtraTabPage4 = new DevExpress.XtraTab.XtraTabPage();
			this.gridAppointment = new DevExpress.XtraGrid.GridControl();
			this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
			((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
			this.xtraTabControl1.SuspendLayout();
			this.xtraTabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControlRoster)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewRoster)).BeginInit();
			this.xtraTabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridLeaveDetails)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewLeaveDetails)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
			this.groupControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ddlStatus.Properties)).BeginInit();
			this.xtraTabPage3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridLoginDetails)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			this.xtraTabPage4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridAppointment)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
			this.SuspendLayout();
			// 
			// xtraTabControl1
			// 
			this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
			this.xtraTabControl1.Name = "xtraTabControl1";
			this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
			this.xtraTabControl1.Size = new System.Drawing.Size(688, 334);
			this.xtraTabControl1.TabIndex = 32;
			this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
																							this.xtraTabPage1,
																							this.xtraTabPage2,
																							this.xtraTabPage3,
																							this.xtraTabPage4});
			this.xtraTabControl1.Text = "xtraTabControl1";
			this.xtraTabControl1.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtraTabControl1_SelectedPageChanged);
			// 
			// xtraTabPage1
			// 
			this.xtraTabPage1.Controls.Add(this.gridControlRoster);
			this.xtraTabPage1.Name = "xtraTabPage1";
			this.xtraTabPage1.Size = new System.Drawing.Size(682, 308);
			this.xtraTabPage1.Text = "Roster Details";
			// 
			// gridControlRoster
			// 
			this.gridControlRoster.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// gridControlRoster.EmbeddedNavigator
			// 
			this.gridControlRoster.EmbeddedNavigator.Name = "";
			this.gridControlRoster.Location = new System.Drawing.Point(0, 0);
			this.gridControlRoster.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.gridControlRoster.LookAndFeel.UseDefaultLookAndFeel = false;
			this.gridControlRoster.MainView = this.gridViewRoster;
			this.gridControlRoster.Name = "gridControlRoster";
			this.gridControlRoster.Size = new System.Drawing.Size(682, 308);
			this.gridControlRoster.TabIndex = 180;
			this.gridControlRoster.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																											 this.gridViewRoster});
			// 
			// gridViewRoster
			// 
			this.gridViewRoster.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																								  this.gridColumn13,
																								  this.gridColumn1,
																								  this.gridColumn2,
																								  this.gridColumn3,
																								  this.gridColumn4});
			this.gridViewRoster.GridControl = this.gridControlRoster;
			this.gridViewRoster.Name = "gridViewRoster";
			this.gridViewRoster.OptionsBehavior.Editable = false;
			this.gridViewRoster.OptionsCustomization.AllowFilter = false;
			this.gridViewRoster.OptionsCustomization.AllowSort = false;
			this.gridViewRoster.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn13
			// 
			this.gridColumn13.Caption = "Branch";
			this.gridColumn13.FieldName = "strBranchCode";
			this.gridColumn13.Name = "gridColumn13";
			this.gridColumn13.Visible = true;
			this.gridColumn13.VisibleIndex = 0;
			this.gridColumn13.Width = 82;
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "Roster ID";
			this.gridColumn1.FieldName = "nRosterID";
			this.gridColumn1.Name = "gridColumn1";
			// 
			// gridColumn2
			// 
			this.gridColumn2.Caption = "Date";
			this.gridColumn2.FieldName = "dtDate";
			this.gridColumn2.Name = "gridColumn2";
			// 
			// gridColumn3
			// 
			this.gridColumn3.Caption = "Start Time";
			this.gridColumn3.DisplayFormat.FormatString = "hh:mm tt";
			this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.gridColumn3.FieldName = "dtStartTime";
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 1;
			this.gridColumn3.Width = 291;
			// 
			// gridColumn4
			// 
			this.gridColumn4.Caption = "End Time";
			this.gridColumn4.DisplayFormat.FormatString = "hh:mm tt";
			this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.gridColumn4.FieldName = "dtEndTime";
			this.gridColumn4.Name = "gridColumn4";
			this.gridColumn4.Visible = true;
			this.gridColumn4.VisibleIndex = 2;
			this.gridColumn4.Width = 295;
			// 
			// xtraTabPage2
			// 
			this.xtraTabPage2.Controls.Add(this.gridLeaveDetails);
			this.xtraTabPage2.Controls.Add(this.groupControl1);
			this.xtraTabPage2.Name = "xtraTabPage2";
			this.xtraTabPage2.Size = new System.Drawing.Size(682, 308);
			this.xtraTabPage2.Text = "Leave Details";
			// 
			// gridLeaveDetails
			// 
			this.gridLeaveDetails.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// gridLeaveDetails.EmbeddedNavigator
			// 
			this.gridLeaveDetails.EmbeddedNavigator.Name = "";
			this.gridLeaveDetails.Location = new System.Drawing.Point(0, 0);
			this.gridLeaveDetails.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.gridLeaveDetails.LookAndFeel.UseDefaultLookAndFeel = false;
			this.gridLeaveDetails.MainView = this.gridViewLeaveDetails;
			this.gridLeaveDetails.Name = "gridLeaveDetails";
			this.gridLeaveDetails.Size = new System.Drawing.Size(682, 308);
			this.gridLeaveDetails.TabIndex = 181;
			this.gridLeaveDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																											this.gridViewLeaveDetails});
			// 
			// gridViewLeaveDetails
			// 
			this.gridViewLeaveDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																										this.gridColumn5,
																										this.gridColumn6,
																										this.gridColumn7,
																										this.gridColumn8,
																										this.gridColumn9,
																										this.gridColumn10,
																										this.gridColumn11,
																										this.gridColumn12});
			this.gridViewLeaveDetails.GridControl = this.gridLeaveDetails;
			this.gridViewLeaveDetails.Name = "gridViewLeaveDetails";
			this.gridViewLeaveDetails.OptionsBehavior.Editable = false;
			this.gridViewLeaveDetails.OptionsCustomization.AllowFilter = false;
			this.gridViewLeaveDetails.OptionsCustomization.AllowSort = false;
			this.gridViewLeaveDetails.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn5
			// 
			this.gridColumn5.Caption = "Leave ID";
			this.gridColumn5.FieldName = "nLeaveID";
			this.gridColumn5.Name = "gridColumn5";
			// 
			// gridColumn6
			// 
			this.gridColumn6.Caption = "Start Time";
			this.gridColumn6.DisplayFormat.FormatString = "hh:mm tt";
			this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.gridColumn6.FieldName = "dtStartTime";
			this.gridColumn6.Name = "gridColumn6";
			this.gridColumn6.Visible = true;
			this.gridColumn6.VisibleIndex = 0;
			this.gridColumn6.Width = 65;
			// 
			// gridColumn7
			// 
			this.gridColumn7.Caption = "End Time";
			this.gridColumn7.DisplayFormat.FormatString = "hh:mm tt";
			this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.gridColumn7.FieldName = "dtEndTime";
			this.gridColumn7.Name = "gridColumn7";
			this.gridColumn7.Visible = true;
			this.gridColumn7.VisibleIndex = 1;
			this.gridColumn7.Width = 65;
			// 
			// gridColumn8
			// 
			this.gridColumn8.Caption = "Duration";
			this.gridColumn8.FieldName = "Duration";
			this.gridColumn8.Name = "gridColumn8";
			this.gridColumn8.Visible = true;
			this.gridColumn8.VisibleIndex = 2;
			this.gridColumn8.Width = 64;
			// 
			// gridColumn9
			// 
			this.gridColumn9.Caption = "Time Off";
			this.gridColumn9.FieldName = "fTimeOff";
			this.gridColumn9.Name = "gridColumn9";
			this.gridColumn9.Visible = true;
			this.gridColumn9.VisibleIndex = 3;
			this.gridColumn9.Width = 57;
			// 
			// gridColumn10
			// 
			this.gridColumn10.Caption = "Leave Status";
			this.gridColumn10.FieldName = "LeaveStatus";
			this.gridColumn10.Name = "gridColumn10";
			this.gridColumn10.Visible = true;
			this.gridColumn10.VisibleIndex = 4;
			this.gridColumn10.Width = 76;
			// 
			// gridColumn11
			// 
			this.gridColumn11.Caption = "Reason";
			this.gridColumn11.FieldName = "strRemarks";
			this.gridColumn11.Name = "gridColumn11";
			this.gridColumn11.Visible = true;
			this.gridColumn11.VisibleIndex = 5;
			this.gridColumn11.Width = 104;
			// 
			// gridColumn12
			// 
			this.gridColumn12.Caption = "Approving Manager";
			this.gridColumn12.FieldName = "ApprovedManager";
			this.gridColumn12.Name = "gridColumn12";
			this.gridColumn12.Visible = true;
			this.gridColumn12.VisibleIndex = 6;
			this.gridColumn12.Width = 232;
			// 
			// groupControl1
			// 
			this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.groupControl1.Controls.Add(this.label2);
			this.groupControl1.Controls.Add(this.ddlStatus);
			this.groupControl1.Location = new System.Drawing.Point(8, 0);
			this.groupControl1.Name = "groupControl1";
			this.groupControl1.Size = new System.Drawing.Size(600, 40);
			this.groupControl1.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(16, 10);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 23);
			this.label2.TabIndex = 186;
			this.label2.Text = "Status";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ddlStatus
			// 
			this.ddlStatus.EditValue = 0;
			this.ddlStatus.Location = new System.Drawing.Point(80, 12);
			this.ddlStatus.Name = "ddlStatus";
			// 
			// ddlStatus.Properties
			// 
			this.ddlStatus.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ddlStatus.Properties.Appearance.Options.UseFont = true;
			this.ddlStatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.ddlStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.ddlStatus.Properties.Items.AddRange(new object[] {
																	  new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Pending", 0, -1),
																	  new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Approved", 1, -1),
																	  new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Rejected", 2, -1)});
			this.ddlStatus.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.ddlStatus.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.ddlStatus.Size = new System.Drawing.Size(152, 22);
			this.ddlStatus.TabIndex = 185;
			// 
			// xtraTabPage3
			// 
			this.xtraTabPage3.Controls.Add(this.gridLoginDetails);
			this.xtraTabPage3.Name = "xtraTabPage3";
			this.xtraTabPage3.Size = new System.Drawing.Size(682, 308);
			this.xtraTabPage3.Text = "Login Details";
			// 
			// gridLoginDetails
			// 
			this.gridLoginDetails.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// gridLoginDetails.EmbeddedNavigator
			// 
			this.gridLoginDetails.EmbeddedNavigator.Name = "";
			this.gridLoginDetails.Location = new System.Drawing.Point(0, 0);
			this.gridLoginDetails.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.gridLoginDetails.LookAndFeel.UseDefaultLookAndFeel = false;
			this.gridLoginDetails.MainView = this.gridView1;
			this.gridLoginDetails.Name = "gridLoginDetails";
			this.gridLoginDetails.Size = new System.Drawing.Size(682, 308);
			this.gridLoginDetails.TabIndex = 180;
			this.gridLoginDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																											this.gridView1});
			// 
			// gridView1
			// 
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn14,
																							 this.gridColumn15});
			this.gridView1.GridControl = this.gridLoginDetails;
			this.gridView1.Name = "gridView1";
			this.gridView1.OptionsBehavior.Editable = false;
			this.gridView1.OptionsCustomization.AllowFilter = false;
			this.gridView1.OptionsCustomization.AllowSort = false;
			this.gridView1.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn14
			// 
			this.gridColumn14.Caption = "Branch Code";
			this.gridColumn14.FieldName = "strBranchCode";
			this.gridColumn14.Name = "gridColumn14";
			this.gridColumn14.Visible = true;
			this.gridColumn14.VisibleIndex = 0;
			// 
			// gridColumn15
			// 
			this.gridColumn15.Caption = "Time";
			this.gridColumn15.DisplayFormat.FormatString = "hh:mm tt";
			this.gridColumn15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.gridColumn15.FieldName = "dtTime";
			this.gridColumn15.Name = "gridColumn15";
			this.gridColumn15.Visible = true;
			this.gridColumn15.VisibleIndex = 1;
			// 
			// xtraTabPage4
			// 
			this.xtraTabPage4.Controls.Add(this.gridAppointment);
			this.xtraTabPage4.Name = "xtraTabPage4";
			this.xtraTabPage4.Size = new System.Drawing.Size(682, 308);
			this.xtraTabPage4.Text = "Appointment";
			// 
			// gridAppointment
			// 
			this.gridAppointment.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// gridAppointment.EmbeddedNavigator
			// 
			this.gridAppointment.EmbeddedNavigator.Name = "";
			this.gridAppointment.Location = new System.Drawing.Point(0, 0);
			this.gridAppointment.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.gridAppointment.LookAndFeel.UseDefaultLookAndFeel = false;
			this.gridAppointment.MainView = this.gridView2;
			this.gridAppointment.Name = "gridAppointment";
			this.gridAppointment.Size = new System.Drawing.Size(682, 308);
			this.gridAppointment.TabIndex = 181;
			this.gridAppointment.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										   this.gridView2});
			// 
			// gridView2
			// 
			this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn16,
																							 this.gridColumn17,
																							 this.gridColumn18,
																							 this.gridColumn19,
																							 this.gridColumn20});
			this.gridView2.GridControl = this.gridAppointment;
			this.gridView2.Name = "gridView2";
			this.gridView2.OptionsBehavior.Editable = false;
			this.gridView2.OptionsCustomization.AllowFilter = false;
			this.gridView2.OptionsCustomization.AllowSort = false;
			this.gridView2.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn16
			// 
			this.gridColumn16.Caption = "Start Time";
			this.gridColumn16.DisplayFormat.FormatString = "hh:mm tt";
			this.gridColumn16.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.gridColumn16.FieldName = "dtStartTime";
			this.gridColumn16.Name = "gridColumn16";
			this.gridColumn16.Visible = true;
			this.gridColumn16.VisibleIndex = 0;
			this.gridColumn16.Width = 76;
			// 
			// gridColumn17
			// 
			this.gridColumn17.Caption = "End Time";
			this.gridColumn17.DisplayFormat.FormatString = "hh:mm tt";
			this.gridColumn17.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.gridColumn17.FieldName = "dtEndTime";
			this.gridColumn17.Name = "gridColumn17";
			this.gridColumn17.Visible = true;
			this.gridColumn17.VisibleIndex = 1;
			this.gridColumn17.Width = 79;
			// 
			// gridColumn18
			// 
			this.gridColumn18.Caption = "Type";
			this.gridColumn18.FieldName = "Type";
			this.gridColumn18.Name = "gridColumn18";
			this.gridColumn18.Visible = true;
			this.gridColumn18.VisibleIndex = 2;
			this.gridColumn18.Width = 130;
			// 
			// gridColumn19
			// 
			this.gridColumn19.Caption = "Organization";
			this.gridColumn19.FieldName = "strOrganization";
			this.gridColumn19.Name = "gridColumn19";
			this.gridColumn19.Visible = true;
			this.gridColumn19.VisibleIndex = 3;
			this.gridColumn19.Width = 100;
			// 
			// gridColumn20
			// 
			this.gridColumn20.Caption = "Remarks";
			this.gridColumn20.FieldName = "strRemarks";
			this.gridColumn20.Name = "gridColumn20";
			this.gridColumn20.Visible = true;
			this.gridColumn20.VisibleIndex = 4;
			this.gridColumn20.Width = 278;
			// 
			// frmRoster
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(688, 334);
			this.Controls.Add(this.xtraTabControl1);
			this.Name = "frmRoster";
			this.Text = "Roster Details";
			((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
			this.xtraTabControl1.ResumeLayout(false);
			this.xtraTabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControlRoster)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewRoster)).EndInit();
			this.xtraTabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridLeaveDetails)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewLeaveDetails)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
			this.groupControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ddlStatus.Properties)).EndInit();
			this.xtraTabPage3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridLoginDetails)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			this.xtraTabPage4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridAppointment)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void btnIPPCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void init(string empID)
		{
			string strSQL;
			strSQL = "select * from tblRoster where nEmployeeID='" + empID + "'and dtDate ='" + string.Format("{0:yyyy-MM-dd}",dtDate) + "'";

			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			
/*
			DataTable dt = new DataTable();
			dt.Columns.Add("nRosterID");
			dt.Columns.Add("dtDate");
			dt.Columns.Add("dtStartTime");
			dt.Columns.Add("dtEndTime");
					

			DataRow dr2;
			int i,j;
			i = 0;
			j = 0;
			foreach (DataRow dr in _ds.Tables["table"].Rows)
			{
				dr2 = dt.NewRow();
				dr2["nRosterID"] = dr["nRosterID"];
				dr2["dtDate"] = string.Format("{0:d MMM yyyy}",dr["dtDate"]);
				dr2["dtStartTime"] = string.Format("{0:T}",dr["dtStartTime"]);
				dr2["dtEndTime"] = string.Format("{0:T}",dr["dtEndTime"]);
				dt.Rows.Add(dr2);
				i ++;
				if (Convert.ToDateTime(dr["dtDate"]).ToString("yyyy-MM-dd") == dtDate.ToString("yyyy-MM-dd"))
				{j = i - 1;}
			}
			*/
			gridControlRoster.DataSource = _ds.Tables["table"];

			//gridViewRoster.FocusedRowHandle = j;
			

			LoadLeaveDetail();
			LoadLoginDetail();
			

		}

	
		# region Leave

		
		private void LoadLeaveDetail()
		{
			//Up_get_LeaveDetailList
			DataTable dt;
			string strSQL;
			strSQL = "Up_get_LeaveDetailList '" + string.Format("{0:MM/dd/yyyy}",dtDate) + "','" + EmployeeId + "'";
			
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dt = _ds.Tables["table"];

			this.gridLeaveDetails.DataSource = dt;

		}

	
		# endregion

		# region LoginDetails

		private void LoadLoginDetail()
		{
			//Up_get_LeaveDetailList
			DataTable dt;
			string strSQL;
			//strSQL = "up_get_LoginDetails '" + EmployeeId + "'";
			strSQL = "Select strBranchCode, dtTime From tblTimeCard Where nEmployeeID ='" + EmployeeId + "' and dtDate='" + string.Format("{0:MM/dd/yyyy}",dtDate) + "'";
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dt = _ds.Tables["table"];

			this.gridLoginDetails.DataSource = dt;

		}
	
		# endregion

		#region Appointment

		private void LoadAppointment()
		{
			//Up_get_Appointment
			DataTable dt;
			string strSQL;
			strSQL = "Up_Get_AppointmentList '" + EmployeeId + "','" + string.Format("{0:MM/dd/yyyy}",dtDate) + "','" + oUser.StrBranchCode() + "'";
			
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dt = _ds.Tables["table"];

			this.gridAppointment.DataSource = dt;

		}
	

		#endregion

		private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
		{
			if (xtraTabControl1.SelectedTabPage.Text == "Appointment")
			{
				LoadAppointment();
			}
		}


	}
}
