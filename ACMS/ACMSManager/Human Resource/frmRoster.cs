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


namespace ACMS.ACMSManager.Human_Resource
{
	/// <summary>
	/// Summary description for frmRoster.
	/// </summary>
	public class frmRoster : System.Windows.Forms.Form
	{
		private Do.Employee employee;
		private Do.TerminalUser terminalUser; 
		User oUser;
		private string _strBranchCode;
		private bool IsEditable;

		private string connectionString;
		private SqlConnection connection;
		private DateTime dtDate;
		private string EmployeeId;
		private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
		private System.Windows.Forms.GroupBox groupBox1;
		private DevExpress.XtraGrid.GridControl gridControlRoster;
		internal DevExpress.XtraEditors.SimpleButton btnDelete;
		internal DevExpress.XtraEditors.SimpleButton btnUpdate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblStartTime;
		private DevExpress.XtraEditors.TimeEdit dtEndTime;
		private DevExpress.XtraEditors.TimeEdit dtStartTime;
		private DevExpress.XtraEditors.SimpleButton btnCancel;
		internal DevExpress.XtraEditors.SimpleButton btnSave;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
		private DevExpress.XtraEditors.GroupControl groupControl1;
		private System.Windows.Forms.Label label2;
		private DevExpress.XtraEditors.ImageComboBoxEdit ddlStatus;
		internal DevExpress.XtraEditors.SimpleButton btnReject;
		internal DevExpress.XtraEditors.SimpleButton btnApprove;
		private DevExpress.XtraGrid.GridControl gridLeaveDetails;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewRoster;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewLeaveDetails;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
		private System.Windows.Forms.Label lblBranch;
		private DevExpress.XtraEditors.ImageComboBoxEdit cbBranch;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cbBranch = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.lblBranch = new System.Windows.Forms.Label();
			this.gridControlRoster = new DevExpress.XtraGrid.GridControl();
			this.gridViewRoster = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
			this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
			this.label1 = new System.Windows.Forms.Label();
			this.lblStartTime = new System.Windows.Forms.Label();
			this.dtEndTime = new DevExpress.XtraEditors.TimeEdit();
			this.dtStartTime = new DevExpress.XtraEditors.TimeEdit();
			this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.btnSave = new DevExpress.XtraEditors.SimpleButton();
			this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
			this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
			this.label2 = new System.Windows.Forms.Label();
			this.ddlStatus = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.btnReject = new DevExpress.XtraEditors.SimpleButton();
			this.btnApprove = new DevExpress.XtraEditors.SimpleButton();
			this.gridLeaveDetails = new DevExpress.XtraGrid.GridControl();
			this.gridViewLeaveDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
			((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
			this.xtraTabControl1.SuspendLayout();
			this.xtraTabPage1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cbBranch.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControlRoster)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewRoster)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtEndTime.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtStartTime.Properties)).BeginInit();
			this.xtraTabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
			this.groupControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ddlStatus.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridLeaveDetails)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewLeaveDetails)).BeginInit();
			this.SuspendLayout();
			// 
			// xtraTabControl1
			// 
			this.xtraTabControl1.AppearancePage.Header.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xtraTabControl1.AppearancePage.Header.Options.UseFont = true;
			this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
			this.xtraTabControl1.Name = "xtraTabControl1";
			this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
			this.xtraTabControl1.Size = new System.Drawing.Size(632, 350);
			this.xtraTabControl1.TabIndex = 32;
			this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
																							this.xtraTabPage1,
																							this.xtraTabPage2});
			this.xtraTabControl1.Text = "xtraTabControl1";
			// 
			// xtraTabPage1
			// 
			this.xtraTabPage1.Controls.Add(this.groupBox1);
			this.xtraTabPage1.Name = "xtraTabPage1";
			this.xtraTabPage1.Size = new System.Drawing.Size(626, 321);
			this.xtraTabPage1.Text = "Roster Details";
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
			this.groupBox1.Controls.Add(this.cbBranch);
			this.groupBox1.Controls.Add(this.lblBranch);
			this.groupBox1.Controls.Add(this.gridControlRoster);
			this.groupBox1.Controls.Add(this.btnDelete);
			this.groupBox1.Controls.Add(this.btnUpdate);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.lblStartTime);
			this.groupBox1.Controls.Add(this.dtEndTime);
			this.groupBox1.Controls.Add(this.dtStartTime);
			this.groupBox1.Controls.Add(this.btnCancel);
			this.groupBox1.Controls.Add(this.btnSave);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(626, 321);
			this.groupBox1.TabIndex = 31;
			this.groupBox1.TabStop = false;
			// 
			// cbBranch
			// 
			this.cbBranch.Location = new System.Drawing.Point(160, 240);
			this.cbBranch.Name = "cbBranch";
			// 
			// cbBranch.Properties
			// 
			this.cbBranch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
			this.cbBranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cbBranch.Size = new System.Drawing.Size(160, 22);
			this.cbBranch.TabIndex = 181;
			// 
			// lblBranch
			// 
			this.lblBranch.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblBranch.Location = new System.Drawing.Point(64, 240);
			this.lblBranch.Name = "lblBranch";
			this.lblBranch.Size = new System.Drawing.Size(56, 16);
			this.lblBranch.TabIndex = 180;
			this.lblBranch.Text = "Branch";
			// 
			// gridControlRoster
			// 
			this.gridControlRoster.Dock = System.Windows.Forms.DockStyle.Top;
			// 
			// gridControlRoster.EmbeddedNavigator
			// 
			this.gridControlRoster.EmbeddedNavigator.Name = "";
			this.gridControlRoster.Location = new System.Drawing.Point(3, 16);
			this.gridControlRoster.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.gridControlRoster.LookAndFeel.UseDefaultLookAndFeel = false;
			this.gridControlRoster.MainView = this.gridViewRoster;
			this.gridControlRoster.Name = "gridControlRoster";
			this.gridControlRoster.Size = new System.Drawing.Size(620, 176);
			this.gridControlRoster.TabIndex = 179;
			this.gridControlRoster.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																											 this.gridViewRoster});
			// 
			// gridViewRoster
			// 
			this.gridViewRoster.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																								  this.gridColumn1,
																								  this.gridColumn14,
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
			// gridColumn1
			// 
			this.gridColumn1.Caption = "Roster ID";
			this.gridColumn1.FieldName = "nRosterID";
			this.gridColumn1.Name = "gridColumn1";
			// 
			// gridColumn14
			// 
			this.gridColumn14.Caption = "Branch";
			this.gridColumn14.FieldName = "strBranchCode";
			this.gridColumn14.Name = "gridColumn14";
			this.gridColumn14.Visible = true;
			this.gridColumn14.VisibleIndex = 0;
			// 
			// gridColumn2
			// 
			this.gridColumn2.Caption = "Date";
			this.gridColumn2.DisplayFormat.FormatString = "dd-MM-yyyy";
			this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.gridColumn2.FieldName = "dtDate";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.Width = 183;
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
			this.gridColumn3.Width = 276;
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
			this.gridColumn4.Width = 320;
			// 
			// btnDelete
			// 
			this.btnDelete.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.btnDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnDelete.Appearance.Options.UseBackColor = true;
			this.btnDelete.Appearance.Options.UseFont = true;
			this.btnDelete.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnDelete.Location = new System.Drawing.Point(448, 280);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(80, 24);
			this.btnDelete.TabIndex = 178;
			this.btnDelete.Text = "Delete";
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnUpdate
			// 
			this.btnUpdate.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.btnUpdate.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnUpdate.Appearance.Options.UseBackColor = true;
			this.btnUpdate.Appearance.Options.UseFont = true;
			this.btnUpdate.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnUpdate.Location = new System.Drawing.Point(360, 280);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(80, 24);
			this.btnUpdate.TabIndex = 177;
			this.btnUpdate.Text = "Update";
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(296, 208);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 16);
			this.label1.TabIndex = 176;
			this.label1.Text = "End Time";
			// 
			// lblStartTime
			// 
			this.lblStartTime.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblStartTime.Location = new System.Drawing.Point(64, 208);
			this.lblStartTime.Name = "lblStartTime";
			this.lblStartTime.Size = new System.Drawing.Size(80, 16);
			this.lblStartTime.TabIndex = 175;
			this.lblStartTime.Text = "Start Time";
			// 
			// dtEndTime
			// 
			this.dtEndTime.EditValue = null;
			this.dtEndTime.Location = new System.Drawing.Point(376, 208);
			this.dtEndTime.Name = "dtEndTime";
			// 
			// dtEndTime.Properties
			// 
			this.dtEndTime.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
			this.dtEndTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											  new DevExpress.XtraEditors.Controls.EditorButton()});
			this.dtEndTime.Properties.DisplayFormat.FormatString = "hh:mm tt";
			this.dtEndTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.dtEndTime.Properties.EditFormat.FormatString = "hh:mm tt";
			this.dtEndTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.dtEndTime.Properties.Mask.EditMask = "hh:mm tt";
			this.dtEndTime.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
			this.dtEndTime.Size = new System.Drawing.Size(96, 22);
			this.dtEndTime.TabIndex = 174;
			// 
			// dtStartTime
			// 
			this.dtStartTime.EditValue = null;
			this.dtStartTime.Location = new System.Drawing.Point(160, 208);
			this.dtStartTime.Name = "dtStartTime";
			// 
			// dtStartTime.Properties
			// 
			this.dtStartTime.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
			this.dtStartTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												new DevExpress.XtraEditors.Controls.EditorButton()});
			this.dtStartTime.Properties.DisplayFormat.FormatString = "hh:mm tt";
			this.dtStartTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.dtStartTime.Properties.EditFormat.FormatString = "hh:mm tt";
			this.dtStartTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.dtStartTime.Properties.Mask.EditMask = "hh:mm tt";
			this.dtStartTime.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
			this.dtStartTime.Size = new System.Drawing.Size(104, 22);
			this.dtStartTime.TabIndex = 173;
			// 
			// btnCancel
			// 
			this.btnCancel.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnCancel.Appearance.Options.UseBackColor = true;
			this.btnCancel.Appearance.Options.UseFont = true;
			this.btnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnCancel.Location = new System.Drawing.Point(536, 280);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 172;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnSave
			// 
			this.btnSave.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnSave.Appearance.Options.UseBackColor = true;
			this.btnSave.Appearance.Options.UseFont = true;
			this.btnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnSave.Location = new System.Drawing.Point(192, 280);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(80, 24);
			this.btnSave.TabIndex = 171;
			this.btnSave.Text = "Save New";
			this.btnSave.Visible = false;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// xtraTabPage2
			// 
			this.xtraTabPage2.Controls.Add(this.groupControl1);
			this.xtraTabPage2.Name = "xtraTabPage2";
			this.xtraTabPage2.Size = new System.Drawing.Size(626, 321);
			this.xtraTabPage2.Text = "Leave Details";
			// 
			// groupControl1
			// 
			this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.groupControl1.Controls.Add(this.label2);
			this.groupControl1.Controls.Add(this.ddlStatus);
			this.groupControl1.Controls.Add(this.btnReject);
			this.groupControl1.Controls.Add(this.btnApprove);
			this.groupControl1.Controls.Add(this.gridLeaveDetails);
			this.groupControl1.Location = new System.Drawing.Point(8, 8);
			this.groupControl1.Name = "groupControl1";
			this.groupControl1.Size = new System.Drawing.Size(616, 304);
			this.groupControl1.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(16, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 23);
			this.label2.TabIndex = 186;
			this.label2.Text = "Status";
			// 
			// ddlStatus
			// 
			this.ddlStatus.Location = new System.Drawing.Point(88, 16);
			this.ddlStatus.Name = "ddlStatus";
			// 
			// ddlStatus.Properties
			// 
			this.ddlStatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
			this.ddlStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.ddlStatus.Properties.Items.AddRange(new object[] {
																	  new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Pending", 0, -1),
																	  new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Approved", 1, -1),
																	  new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Rejected", 2, -1)});
			this.ddlStatus.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.ddlStatus.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.ddlStatus.Size = new System.Drawing.Size(104, 22);
			this.ddlStatus.TabIndex = 185;
			this.ddlStatus.SelectedIndexChanged += new System.EventHandler(this.ddlStatus_SelectedIndexChanged);
			// 
			// btnReject
			// 
			this.btnReject.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnReject.Appearance.Options.UseFont = true;
			this.btnReject.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnReject.Location = new System.Drawing.Point(472, 16);
			this.btnReject.Name = "btnReject";
			this.btnReject.Size = new System.Drawing.Size(80, 24);
			this.btnReject.TabIndex = 184;
			this.btnReject.Text = "Reject";
			this.btnReject.Visible = false;
			this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
			// 
			// btnApprove
			// 
			this.btnApprove.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnApprove.Appearance.Options.UseFont = true;
			this.btnApprove.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnApprove.Location = new System.Drawing.Point(384, 16);
			this.btnApprove.Name = "btnApprove";
			this.btnApprove.Size = new System.Drawing.Size(80, 24);
			this.btnApprove.TabIndex = 183;
			this.btnApprove.Text = "Approve";
			this.btnApprove.Visible = false;
			this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
			// 
			// gridLeaveDetails
			// 
			this.gridLeaveDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
			// 
			// gridLeaveDetails.EmbeddedNavigator
			// 
			this.gridLeaveDetails.EmbeddedNavigator.Name = "";
			this.gridLeaveDetails.Location = new System.Drawing.Point(0, 48);
			this.gridLeaveDetails.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.gridLeaveDetails.LookAndFeel.UseDefaultLookAndFeel = false;
			this.gridLeaveDetails.MainView = this.gridViewLeaveDetails;
			this.gridLeaveDetails.Name = "gridLeaveDetails";
			this.gridLeaveDetails.Size = new System.Drawing.Size(616, 256);
			this.gridLeaveDetails.TabIndex = 180;
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
																										this.gridColumn13,
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
			this.gridColumn5.Caption = "Roster ID";
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
			// 
			// gridColumn8
			// 
			this.gridColumn8.Caption = "Duration";
			this.gridColumn8.FieldName = "Duration";
			this.gridColumn8.Name = "gridColumn8";
			this.gridColumn8.Visible = true;
			this.gridColumn8.VisibleIndex = 2;
			// 
			// gridColumn9
			// 
			this.gridColumn9.Caption = "Time Off";
			this.gridColumn9.FieldName = "fTimeOff";
			this.gridColumn9.Name = "gridColumn9";
			this.gridColumn9.Visible = true;
			this.gridColumn9.VisibleIndex = 3;
			// 
			// gridColumn10
			// 
			this.gridColumn10.Caption = "Leave Status";
			this.gridColumn10.FieldName = "LeaveStatus";
			this.gridColumn10.Name = "gridColumn10";
			this.gridColumn10.Visible = true;
			this.gridColumn10.VisibleIndex = 4;
			// 
			// gridColumn11
			// 
			this.gridColumn11.Caption = "Reason";
			this.gridColumn11.FieldName = "strRemarks";
			this.gridColumn11.Name = "gridColumn11";
			this.gridColumn11.Visible = true;
			this.gridColumn11.VisibleIndex = 5;
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
			this.gridColumn12.VisibleIndex = 6;
			// 
			// frmRoster
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(632, 350);
			this.Controls.Add(this.xtraTabControl1);
			this.Name = "frmRoster";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Roster Details";
			this.Load += new System.EventHandler(this.frmRoster_Load);
			((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
			this.xtraTabControl1.ResumeLayout(false);
			this.xtraTabPage1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.cbBranch.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControlRoster)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewRoster)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtEndTime.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtStartTime.Properties)).EndInit();
			this.xtraTabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
			this.groupControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ddlStatus.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridLeaveDetails)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewLeaveDetails)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
		private void frmRoster_Load(object sender, System.EventArgs e)
		{
			dtStartTime.Text = null;
			dtEndTime.Text = null;
			string strSQL;

			strSQL = "select strBranchCode,strBranchName from tblBranch where nBrStatusID=1";
			comboBind(cbBranch,strSQL,"strBranchName","strBranchCode");
			ddlStatus.SelectedIndex = 0;
			init(EmployeeId,dtDate);
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void init(string empID,DateTime rosterDate)
		{
			IsEditable = false;
			int i,j;
			i = 0;
			j = 0;
			string strSQL;
			strSQL = "select * from tblRoster where dtDate='" + rosterDate.ToString("yyyy-MM-dd") + "' and nEmployeeID='" + empID + "'";
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			if ( _ds.Tables["table"].Rows.Count>=1)
			{
				btnUpdate.Enabled = true;
				btnDelete.Enabled = true;
			}
			else
			{
				btnUpdate.Enabled = false;
				btnDelete.Enabled = false;
			}

			gridControlRoster.DataSource = _ds.Tables["table"];
			cbBranch.DataBindings.Add("EditValue",_ds.Tables["table"],"strBranchCode"); 
			dtStartTime.DataBindings.Add("EditValue",_ds.Tables["table"],"dtStartTime");
			dtEndTime.DataBindings.Add("EditValue",_ds.Tables["table"],"dtEndTime");
			gridViewRoster.FocusedRowHandle = j;

			LoadLeaveDetail();

		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			int output;
			output = 0;

			//Convert.ToDateTime( DateTime.Today ).AddDays(2-2).ToShortDateString();
			if(employee.CanAccess("AM_INSERT_ROSTER",terminalUser.Branch.Id))
			{
				try
				{
					if (dtStartTime.EditValue == null || dtEndTime.EditValue == null)
					{
						MessageBox.Show("Must Key in Start Time and End Time");
					}
					else
					{
						SqlHelper.ExecuteNonQuery(connection,"In_tblRoster",
							new SqlParameter("@retval",output),
							new SqlParameter("@cmd","I"),
							new SqlParameter("@nRosterID",1),
							new SqlParameter("@dtDate",dtDate),
							new SqlParameter("@dtStartTime",Convert.ToDateTime(dtStartTime.Text).ToShortTimeString()),
							new SqlParameter("@dtEndTime",Convert.ToDateTime(dtEndTime.Text).ToShortTimeString()),
							new SqlParameter("@strBranchCode",strBranchCode),
							new SqlParameter("@nEmployeeID",EmployeeId),
							new SqlParameter("@strRemarks",""));
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
			else
			{
				MessageBox.Show("You don't have sufficient right to insert new roster for this staff");
			}

			this.Dispose();		
		}

		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			DataRow dr = this.gridViewRoster.GetDataRow(this.gridViewRoster.FocusedRowHandle);
			
			string strSQL,strSQL1;
			strSQL = "select * from tblTimeCard where dtDate='" + dtDate.ToString("yyyy-MM-dd") + "' and nEmployeeID='" + EmployeeId + "'and Convert(varchar,dtTime,108)='" + Convert.ToDateTime(dtEndTime.Text).ToString("HH:mm:ss") + "'";
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );    
			int rowcount = _ds.Tables["table"].Rows.Count;

            strSQL1 = "select strJobPositionCode from tblEmployee where nEmployeeID=" + EmployeeId;
            DataSet _ds1 = new DataSet();
            SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA", _ds1, new string[] { "table1" }, new SqlParameter("@strSQL", strSQL1));
            string strJobpoition = _ds1.Tables["table1"].Rows[0][0].ToString();

            if (strJobpoition.Trim() == "BRM" || strJobpoition.Trim() == "ABMGR" || strJobpoition.Trim() == "MM" || strJobpoition.Trim() == "SSM")
            {
                if (employee.CanAccess("AM_UPDATE_BMROSTER", terminalUser.Branch.Id) == false)
                {
                    if (dtDate <= DateTime.Today)
                    {
                        MessageBox.Show("You can't edit branch manager roster");
                        return;
                    }
                }
            }

			int output;
			output = 0;

            
			Convert.ToDateTime( DateTime.Today ).AddDays(2-2).ToShortDateString();
			if(employee.CanAccess("AM_UPDATE_TODAYROSTER",terminalUser.Branch.Id)==true && dtDate<=DateTime.Today)	
			{
				if (employee.Id == Convert.ToInt64(EmployeeId)) 
				{
					MessageBox.Show("You can't edit your own today roster");
					return;
				}
			}
			else if(employee.CanAccess("AM_UPDATE_TODAYROSTER",terminalUser.Branch.Id)==false && dtDate==DateTime.Today)		
			{	
				MessageBox.Show("You can't edit today roster");
				return;
			}
			
			if( employee.CanAccess("AM_EDIT_ROSTER_FUTURE_DATE",terminalUser.Branch.Id))
			{
				//if( TimeRangeValidation())
				//{
				if ( TimeCompare())
				{
					if( dtDate>DateTime.Today || rowcount==0)
					{
						if ( dr != null)
						{
							try
							{
								int yy,mm,dd,hh,min,ss;
								yy= Convert.ToDateTime(dtDate).Year;
								mm= Convert.ToDateTime(dtDate).Month;
								dd= Convert.ToDateTime(dtDate).Day;


								hh = Convert.ToDateTime(dtStartTime.EditValue).Hour;
								min = Convert.ToDateTime(dtStartTime.EditValue).Minute;
								ss = Convert.ToDateTime(dtStartTime.EditValue).Second;

								DateTime dt1= new DateTime(yy,mm,dd,hh,min,ss);

								hh = Convert.ToDateTime(dtEndTime.EditValue).Hour;
								min = Convert.ToDateTime(dtEndTime.EditValue).Minute;
								ss = Convert.ToDateTime(dtEndTime.EditValue).Second;
								DateTime dt2= new DateTime(yy,mm,dd,hh,min,ss);
								SqlHelper.ExecuteNonQuery(connection,"In_tblRoster",
									new SqlParameter("@retval",output),
									new SqlParameter("@cmd","U"),
									new SqlParameter("@nRosterID",dr["nRosterID"].ToString()),
									new SqlParameter("@dtDate",dtDate),
									new SqlParameter("@dtStartTime",dt1),
									new SqlParameter("@dtEndTime",dt2),
									new SqlParameter("@strBranchCode",cbBranch.EditValue.ToString()),
									new SqlParameter("@nEmployeeID",EmployeeId),
									new SqlParameter("@strRemarks",""));
							}
							catch (Exception ex)
							{
								MessageBox.Show(ex.Message);
							}
						}
					}
					else
					{
						MessageBox.Show("Not allow to update past roster");
					}
				}//TimeCompare
				else
					MessageBox.Show("Start Time cannot greated than end time.");
				//}
				//else
				//MessageBox.Show("Time Range was overlapped with others record");
			}
			else if( employee.CanAccess("AM_EDIT_ROSTER_WITHOUT_DATE_RESTRICTIONS",terminalUser.Branch.Id))
			{
				//if ( TimeRangeValidation())
				//{
				if ( TimeCompare())
				{
					try
					{
						int yy,mm,dd,hh,min,ss;
						yy= Convert.ToDateTime(dtDate).Year;
						mm= Convert.ToDateTime(dtDate).Month;
						dd= Convert.ToDateTime(dtDate).Day;

						hh = Convert.ToDateTime(dtStartTime.EditValue).Hour;
						min = Convert.ToDateTime(dtStartTime.EditValue).Minute;
						ss = Convert.ToDateTime(dtStartTime.EditValue).Second;

						DateTime dt1= new DateTime(yy,mm,dd,hh,min,ss);

						hh = Convert.ToDateTime(dtEndTime.EditValue).Hour;
						min = Convert.ToDateTime(dtEndTime.EditValue).Minute;
						ss = Convert.ToDateTime(dtEndTime.EditValue).Second;
						DateTime dt2= new DateTime(yy,mm,dd,hh,min,ss);

						SqlHelper.ExecuteNonQuery(connection,"In_tblRoster",
							new SqlParameter("@retval",output),
							new SqlParameter("@cmd","U"),
							new SqlParameter("@nRosterID",dr["nRosterID"].ToString()),
							new SqlParameter("@dtDate",dtDate),
							new SqlParameter("@dtStartTime",dt1),
							new SqlParameter("@dtEndTime",dt2),
							new SqlParameter("@strBranchCode",cbBranch.EditValue.ToString()),
							new SqlParameter("@nEmployeeID",EmployeeId),
							new SqlParameter("@strRemarks",""));
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message);
					}
				}//TimeCompare
				else
					MessageBox.Show("Start Time cannot greated than end time.");

				//}
				//else
				//MessageBox.Show("Time Range was overlapped with others record");
			}
			else
			{
				MessageBox.Show("You don't have sufficient right to update new roster for this staff");
			}
			this.Close();
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			DataRow dr = this.gridViewRoster.GetDataRow(this.gridViewRoster.FocusedRowHandle);
			string strSQL;
			strSQL = "select * from tblTimeCard where dtDate='" + dtDate.ToString("yyyy-MM-dd") + "' and nEmployeeID='" + EmployeeId + "'and convert(varchar,dtTime,108)='" + Convert.ToDateTime(dtEndTime.Text).ToString("HH:mm:ss") + "'";
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );    

			int rowcount = _ds.Tables["table"].Rows.Count;

            string strSQL1 = "select strJobPositionCode from tblEmployee where nEmployeeID=" + EmployeeId;
            DataSet _ds1 = new DataSet();
            SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA", _ds1, new string[] { "table1" }, new SqlParameter("@strSQL", strSQL1));
            string strJobpoition = _ds1.Tables["table1"].Rows[0][0].ToString();

            if (strJobpoition.Trim() == "BRM" || strJobpoition.Trim() == "ABMGR" || strJobpoition.Trim() == "MM" || strJobpoition.Trim() == "SSM")
            {
                if (employee.CanAccess("AM_UPDATE_BMROSTER", terminalUser.Branch.Id) == false)
                {
                    if (dtDate <= DateTime.Today)
                    {
                        MessageBox.Show("You can't edit branch manager roster");
                        return;
                    }                   
                }
            }

			int output;
			output = 0;

			if ( dr != null)
			{
				
				Convert.ToDateTime( DateTime.Today ).AddDays(2-2).ToShortDateString();
				if( employee.CanAccess("AM_DELETE_ROSTER_FUTURE_DATE",terminalUser.Branch.Id ))
				{
					if(dtDate > DateTime.Today && rowcount==0)
					{
						try
						{
							SqlHelper.ExecuteNonQuery(connection,"del_tblRoster",
								new SqlParameter("@retval",output),
								new SqlParameter("@nRosterID",dr["nRosterID"].ToString()));
						}
						catch( Exception ex)
						{
							MessageBox.Show(ex.Message);
						}
					}
					else
					{
						MessageBox.Show("Not allow to delete previous roster");
					}
				}
					
				if( employee.CanAccess("AM_DELETE_ROSTER_WITHOUT_DATE_RESTRICTIONS",terminalUser.Branch.Id ))
				{
					if(dtDate==DateTime.Today && employee.Id==ACMS.Convert.ToInt32(EmployeeId))						
						MessageBox.Show("You don't have sufficient right to delete roster record");			
					else
					{	
						try
						{
							SqlHelper.ExecuteNonQuery(connection,"del_tblRoster",
								new SqlParameter("@retval",output),
								new SqlParameter("@nRosterID",dr["nRosterID"].ToString()));
						}
						catch( Exception ex)
						{
							MessageBox.Show(ex.Message);
						}
					}
				}
				else
				{
					MessageBox.Show("cant delete today roster");
					return;
				}					
					
		this.Dispose();		
	}
			
		
}
		private bool TimeRangeValidation()
		{
			DataSet _ds = new DataSet();

			string strSQL;
			strSQL = "select convert(varchar,dtStartTime,108),* from tblRoster where nEmployeeID='" + EmployeeId.ToString() + "' and convert(varchar,dtDate,111)='" + Convert.ToDateTime(dtDate).ToString("yyyy/MM/dd") + "' and ('" + Convert.ToDateTime(dtStartTime.EditValue).AddSeconds(1).ToString("HH:mm:ss") + "' between convert(varchar,dtStartTime,108) and convert(varchar,dtEndTime,108)";
			strSQL = strSQL + " or '" + Convert.ToDateTime(dtEndTime.EditValue).AddSeconds(-1).ToString("HH:mm:ss") + "' between convert(varchar,dtStartTime,108) and convert(varchar,dtEndTime,108) ) " ;
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			if ( _ds.Tables["table"].Rows.Count > 0 )
			{
				return false;
			}
			else
			{

				return true;
			}
		
		

		}

		private bool TimeCompare()
		{
			if (Convert.ToDateTime(dtStartTime.EditValue)>Convert.ToDateTime(dtEndTime.EditValue))
				return false;
			return true;
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

		private void btnApprove_Click(object sender, System.EventArgs e)
		{
			if (gridViewLeaveDetails.RowCount > 0)
			{
				DataRow dr = this.gridViewLeaveDetails.GetDataRow(this.gridViewLeaveDetails.FocusedRowHandle);

				int output;
				output = 0;

				if( employee.CanAccess("AM_APPROVE_LEAVE",terminalUser.Branch.Id))
				{
					SqlHelper.ExecuteNonQuery(connection,"up_Leave_Approved",
						new SqlParameter("@retval",output),
						new SqlParameter("@LeaveID",dr["nLeaveID"].ToString()),
						new SqlParameter("@nEmployeeID",EmployeeId),
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
			this.Dispose();		
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
					new SqlParameter("@nEmployeeID",EmployeeId),
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

			this.Dispose();	

		}

		private void ddlStatus_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			DataTable dt;
			string strSQL;
			strSQL = "Up_get_LeaveDetailList '" + string.Format("{0:MM/dd/yyyy}",dtDate) + "','" + EmployeeId + "'";
			
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dt = _ds.Tables["table"];
		
			if (ddlStatus.SelectedIndex.ToString() != "") 
			{
				dt.DefaultView.RowFilter = "nStatusID=" + ddlStatus.EditValue;
				this.gridLeaveDetails.DataSource = dt;
			}
		
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

	}
}
