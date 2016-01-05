using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
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
	/// Summary description for frmAppointment.
	/// </summary>
	public class frmAppointment : DevExpress.XtraEditors.XtraForm
	{
		private static Do.Employee employee;
		private static Do.TerminalUser terminalUser; 
		private static User oUser;
		private string _strBranchCode;

		private string connectionString;
		private SqlConnection connection;

		internal DevExpress.XtraEditors.SimpleButton btnViewAll;
		private DevExpress.XtraEditors.ImageComboBoxEdit cmbBranch;
		private System.Windows.Forms.Label label25;
		private DevExpress.XtraEditors.GroupControl groupControl2;
		private DevExpress.XtraEditors.ImageComboBoxEdit prevToMonth;
		private DevExpress.XtraEditors.ImageComboBoxEdit prevFromMonth;
		internal DevExpress.XtraEditors.SimpleButton btnPrevGo;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private DevExpress.XtraEditors.ImageComboBoxEdit prevToYear;
		private DevExpress.XtraEditors.ImageComboBoxEdit prevFromYear;
		private System.Windows.Forms.Label label2;
		private DevExpress.XtraEditors.ImageComboBoxEdit ddlStatus;
		private DevExpress.XtraGrid.GridControl gridLeaveDetails;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewLeaveDetails;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraEditors.GroupControl groupControl3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private bool isFinishBind = false;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmAppointment()
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
            this.btnViewAll = new DevExpress.XtraEditors.SimpleButton();
            this.cmbBranch = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.label25 = new System.Windows.Forms.Label();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.prevToMonth = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.prevFromMonth = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.btnPrevGo = new DevExpress.XtraEditors.SimpleButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.prevToYear = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.prevFromYear = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.ddlStatus = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.gridLeaveDetails = new DevExpress.XtraGrid.GridControl();
            this.gridViewLeaveDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBranch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prevToMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prevFromMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prevToYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prevFromYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLeaveDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLeaveDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnViewAll
            // 
            this.btnViewAll.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewAll.Appearance.Options.UseFont = true;
            this.btnViewAll.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnViewAll.Location = new System.Drawing.Point(557, 82);
            this.btnViewAll.Name = "btnViewAll";
            this.btnViewAll.Size = new System.Drawing.Size(86, 23);
            this.btnViewAll.TabIndex = 201;
            this.btnViewAll.Text = "View All";
            this.btnViewAll.Click += new System.EventHandler(this.btnViewAll_Click);
            // 
            // cmbBranch
            // 
            this.cmbBranch.Location = new System.Drawing.Point(326, 82);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.cmbBranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbBranch.Size = new System.Drawing.Size(192, 24);
            this.cmbBranch.TabIndex = 200;
            this.cmbBranch.SelectedValueChanged += new System.EventHandler(this.cmbBranch_SelectedValueChanged);
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(259, 82);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(67, 19);
            this.label25.TabIndex = 199;
            this.label25.Text = "Branch";
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
            this.groupControl2.Location = new System.Drawing.Point(19, 27);
            this.groupControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(672, 46);
            this.groupControl2.TabIndex = 198;
            // 
            // prevToMonth
            // 
            this.prevToMonth.Location = new System.Drawing.Point(326, 18);
            this.prevToMonth.Name = "prevToMonth";
            this.prevToMonth.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
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
            this.prevToMonth.Size = new System.Drawing.Size(87, 24);
            this.prevToMonth.TabIndex = 56;
            // 
            // prevFromMonth
            // 
            this.prevFromMonth.Location = new System.Drawing.Point(77, 18);
            this.prevFromMonth.Name = "prevFromMonth";
            this.prevFromMonth.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
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
            this.prevFromMonth.Size = new System.Drawing.Size(86, 24);
            this.prevFromMonth.TabIndex = 55;
            // 
            // btnPrevGo
            // 
            this.btnPrevGo.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevGo.Appearance.Options.UseFont = true;
            this.btnPrevGo.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnPrevGo.Location = new System.Drawing.Point(538, 18);
            this.btnPrevGo.Name = "btnPrevGo";
            this.btnPrevGo.Size = new System.Drawing.Size(86, 23);
            this.btnPrevGo.TabIndex = 54;
            this.btnPrevGo.Text = "Go";
            this.btnPrevGo.Click += new System.EventHandler(this.btnPrevGo_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(288, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 19);
            this.label5.TabIndex = 53;
            this.label5.Text = "To";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 19);
            this.label4.TabIndex = 52;
            this.label4.Text = "From";
            // 
            // prevToYear
            // 
            this.prevToYear.EditValue = "cbGIROStatus";
            this.prevToYear.Location = new System.Drawing.Point(422, 18);
            this.prevToYear.Name = "prevToYear";
            this.prevToYear.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.prevToYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.prevToYear.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.prevToYear.Size = new System.Drawing.Size(96, 24);
            this.prevToYear.TabIndex = 51;
            // 
            // prevFromYear
            // 
            this.prevFromYear.EditValue = "cbGIROStatus";
            this.prevFromYear.Location = new System.Drawing.Point(173, 18);
            this.prevFromYear.Name = "prevFromYear";
            this.prevFromYear.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.prevFromYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.prevFromYear.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.prevFromYear.Size = new System.Drawing.Size(86, 24);
            this.prevFromYear.TabIndex = 50;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 27);
            this.label2.TabIndex = 197;
            this.label2.Text = "Remarks";
            // 
            // ddlStatus
            // 
            this.ddlStatus.EditValue = 0;
            this.ddlStatus.Location = new System.Drawing.Point(106, 82);
            this.ddlStatus.Name = "ddlStatus";
            this.ddlStatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.ddlStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlStatus.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Active", 0, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Deleted", 1, -1)});
            this.ddlStatus.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.ddlStatus.Size = new System.Drawing.Size(134, 24);
            this.ddlStatus.TabIndex = 196;
            this.ddlStatus.SelectedIndexChanged += new System.EventHandler(this.ddlStatus_SelectedIndexChanged);
            // 
            // gridLeaveDetails
            // 
            this.gridLeaveDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridLeaveDetails.Location = new System.Drawing.Point(2, 36);
            this.gridLeaveDetails.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridLeaveDetails.MainView = this.gridViewLeaveDetails;
            this.gridLeaveDetails.Name = "gridLeaveDetails";
            this.gridLeaveDetails.Size = new System.Drawing.Size(988, 530);
            this.gridLeaveDetails.TabIndex = 180;
            this.gridLeaveDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewLeaveDetails});
            // 
            // gridViewLeaveDetails
            // 
            this.gridViewLeaveDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn6,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn5,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11});
            this.gridViewLeaveDetails.GridControl = this.gridLeaveDetails;
            this.gridViewLeaveDetails.Name = "gridViewLeaveDetails";
            this.gridViewLeaveDetails.OptionsBehavior.Editable = false;
            this.gridViewLeaveDetails.OptionsCustomization.AllowFilter = false;
            this.gridViewLeaveDetails.OptionsCustomization.AllowSort = false;
            this.gridViewLeaveDetails.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Date";
            this.gridColumn6.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn6.FieldName = "dtDate";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            this.gridColumn6.Width = 97;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Employee Id";
            this.gridColumn1.FieldName = "nEmployeeID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 110;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Name";
            this.gridColumn2.FieldName = "strEmployeeName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 150;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Roster ID";
            this.gridColumn5.FieldName = "nAppointmentId";
            this.gridColumn5.Name = "gridColumn5";
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Start Time";
            this.gridColumn7.DisplayFormat.FormatString = "hh:mm:ss tt";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn7.FieldName = "dtStartTime";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 3;
            this.gridColumn7.Width = 150;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "End Time";
            this.gridColumn8.DisplayFormat.FormatString = "hh:mm:ss tt";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn8.FieldName = "dtEndTime";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 4;
            this.gridColumn8.Width = 150;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Appointment Type";
            this.gridColumn9.FieldName = "ApptType";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 5;
            this.gridColumn9.Width = 158;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Remarks";
            this.gridColumn10.FieldName = "ApptStatus";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 6;
            this.gridColumn10.Width = 152;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "nStatus";
            this.gridColumn11.FieldName = "nStatus";
            this.gridColumn11.Name = "gridColumn11";
            // 
            // groupControl3
            // 
            this.groupControl3.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.groupControl3.Appearance.Options.UseBackColor = true;
            this.groupControl3.Controls.Add(this.groupControl2);
            this.groupControl3.Controls.Add(this.label25);
            this.groupControl3.Controls.Add(this.btnViewAll);
            this.groupControl3.Controls.Add(this.label2);
            this.groupControl3.Controls.Add(this.ddlStatus);
            this.groupControl3.Controls.Add(this.cmbBranch);
            this.groupControl3.Controls.Add(this.gridLeaveDetails);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(0, 0);
            this.groupControl3.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupControl3.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(992, 568);
            this.groupControl3.TabIndex = 205;
            this.groupControl3.Text = "Appointment Details";
            // 
            // frmAppointment
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
            this.ClientSize = new System.Drawing.Size(992, 568);
            this.Controls.Add(this.groupControl3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAppointment";
            this.Text = "Appointment";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmAppointment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbBranch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.prevToMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prevFromMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prevToYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prevFromYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLeaveDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLeaveDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
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

		# region Appointment
		private string status;
		private void LoadAppointmentDetail()
		{
			if (!isFinishBind)
				return;
					
			User oUser = new User();
			//Up_get_LeaveDetailList
			DataTable dt;
			string strSQL;
			strSQL = "up_get_HRAppointmentList'" + oUser.NEmployeeID() + "'";
			
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dt = _ds.Tables["table"];
					
			DataView dv = new DataView(dt);
			string sql = "";
			
			DateTime thisMonth,NextMonth;
			
			thisMonth=new DateTime(ACMS.Convert.ToDBInt32(prevFromYear.EditValue),ACMS.Convert.ToDBInt32(prevFromMonth.EditValue),1,0,0,0,1);
			NextMonth=new DateTime(ACMS.Convert.ToDBInt32(prevToYear.EditValue),ACMS.Convert.ToDBInt32(prevToMonth.EditValue),1,0,0,0,1);

			NextMonth=NextMonth.AddMonths(1);

			sql = "dtStartTime >= '" + thisMonth.ToLongDateString() + "' And dtStartTime < '"+ NextMonth.ToShortDateString() +"'";
			sql += "And nStatus = " + ddlStatus.EditValue;

			if (status != "ViewAll")
			{
			//	sql = string.Format("dtConvertedDate >= #{1}-{0}-01# And dtConvertedDate < #{3}-{2}-01#", Convert.ToInt32(prevFromMonth.EditValue).ToString("0#"), prevFromYear.SelectedItem.ToString(), (Convert.ToInt32(prevToMonth.EditValue) + 1).ToString("0#"), prevToYear.SelectedItem.ToString());
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
			LoadAppointmentDetail();
		
		}
		
		private void cmbBranch_SelectedValueChanged(object sender, System.EventArgs e)
		{
			LoadAppointmentDetail();
		}

		private void btnViewAll_Click(object sender, System.EventArgs e)
		{
			status = "ViewAll";
			cmbBranch.SelectedIndex = 0;
			LoadAppointmentDetail();
		}

		private void btnPrevGo_Click(object sender, System.EventArgs e)
		{
			LoadAppointmentDetail();
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

		private void frmAppointment_Load(object sender, System.EventArgs e)
		{
			LoadYear(prevFromYear);
			LoadYear(prevToYear);

			prevFromYear.EditValue = DateTime.Now.Year;
			prevToYear.EditValue = DateTime.Now.Year;
//					
//			string strSQL = "select distinct Year(dtDate) as strYear from TblAppointment order by Year(dtDate) desc";
//
//			comboBind(prevFromYear, strSQL, "strYear", "strYear", true);
//			comboBind(prevToYear, strSQL, "strYear", "strYear", true);
//						
//			prevFromYear.SelectedIndex = 0;
//			prevToYear.SelectedIndex = 0;
//
//			if (prevFromYear.SelectedIndex == -1)
//			{
//				this.prevFromYear.Properties.Items.Insert(0,new DevExpress.XtraEditors.Controls.ImageComboBoxItem(DateTime.Today.Year.ToString(),""));
//				this.prevFromYear.EditValue = DateTime.Today.Year;
//				prevFromYear.SelectedIndex = 0;
//			}
//				
//			if (prevToYear.SelectedIndex == -1)
//			{
//				this.prevToYear.Properties.Items.Insert(0,new DevExpress.XtraEditors.Controls.ImageComboBoxItem(DateTime.Today.Year.ToString(),""));
//				this.prevToYear.EditValue = DateTime.Today.Year;
//				prevToYear.SelectedIndex = 0;
//			}
//		
//			this.prevFromYear.EditValue = DateTime.Today.Year;
//			this.prevToYear.EditValue = DateTime.Today.Year;

			this.prevFromMonth.EditValue = DateTime.Now.Month - 3;
		
			this.prevToMonth.EditValue = DateTime.Now.Month;

			if (prevToMonth.EditValue.ToString()== "1")
			{
					this.prevFromMonth.EditValue = DateTime.Now.Month;
			}
		
			BindBranch();
			isFinishBind = true;
			LoadAppointmentDetail();
		}


		# endregion
	

		#region common

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

