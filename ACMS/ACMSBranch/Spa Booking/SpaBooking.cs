using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraScheduler;
using DevExpress.Utils;
using System.Drawing.Drawing2D;
using DevExpress.XtraScheduler.Drawing;


namespace ACMS
{

	/// <summary>
	/// Summary description for SpaBooking.
	/// </summary>
	public class SpaBookingControl : System.Windows.Forms.UserControl
	{
		private DevExpress.XtraScheduler.SchedulerStorage schedulerStorage1;
		private DevExpress.XtraScheduler.DateNavigator dateNavigator1;
		private DevExpress.XtraEditors.SplitterControl splitterControl1;
		private System.ComponentModel.IContainer components;
		private DataSet myDataSet;
		private DataTable myServiceSessionTable;
		private DataTable myEmployeeTable;
		private DevExpress.XtraEditors.PanelControl pnlCtrlScheduler;
		private DevExpress.XtraEditors.PanelControl pnlCtrlTop;
		private string myStrBranchCode = "";
		internal DevExpress.XtraEditors.SimpleButton sBtnForfeit;
		internal DevExpress.XtraEditors.SimpleButton SimpleButton61;
		internal DevExpress.XtraEditors.SimpleButton SimpleButton62;
		internal DevExpress.XtraEditors.SimpleButton SimpleButton63;
		private DevExpress.XtraScheduler.SchedulerControl schedulerControl1;
		private DevExpress.XtraScheduler.UI.ResourcesCheckedListBoxControl resourcesCheckedListBoxControl1;
		internal DevExpress.XtraEditors.SimpleButton sBtnAdd;
		private System.Windows.Forms.ImageList imageList1;
		internal DevExpress.XtraEditors.SimpleButton sBtnSubtract;
		
		private ACMSLogic.SpaBooking mySpaBooking;
		private bool myHaveInit = false;
		private ACMSLogic.Common.SchedulerChangedDelegate mySchedulerChangedEvent;
		private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
		private int myCurrentPageRate = 0;
		internal DevExpress.XtraEditors.SimpleButton sBtnWaitingList;
		private DevExpress.Utils.ToolTipController toolTipController1;
		internal DevExpress.XtraEditors.SimpleButton sBtnRefresh;

		public SpaBookingControl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
			//Init();

		}

		public ACMSLogic.Common.SchedulerChangedDelegate OnSchedulerChanged
		{
			get { return mySchedulerChangedEvent; }
			set 
			{ 
				if (mySchedulerChangedEvent == null)
					mySchedulerChangedEvent = value; 
			}
		}

		public string StrBranchCode
		{
			set { myStrBranchCode = value; }
			get { return myStrBranchCode; }
		}

		public ACMSLogic.SpaBooking SpaBooking
		{
			set 
			{ 
				if (!myHaveInit)
					mySpaBooking = value; 
			}
			get { return mySpaBooking; }
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			DevExpress.XtraScheduler.TimeRuler timeRuler1 = new DevExpress.XtraScheduler.TimeRuler();
			DevExpress.XtraScheduler.TimeRuler timeRuler2 = new DevExpress.XtraScheduler.TimeRuler();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(SpaBookingControl));
			this.schedulerStorage1 = new DevExpress.XtraScheduler.SchedulerStorage(this.components);
			this.dateNavigator1 = new DevExpress.XtraScheduler.DateNavigator();
			this.schedulerControl1 = new DevExpress.XtraScheduler.SchedulerControl();
			this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
			this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
			this.pnlCtrlScheduler = new DevExpress.XtraEditors.PanelControl();
			this.pnlCtrlTop = new DevExpress.XtraEditors.PanelControl();
			this.sBtnRefresh = new DevExpress.XtraEditors.SimpleButton();
			this.sBtnWaitingList = new DevExpress.XtraEditors.SimpleButton();
			this.sBtnSubtract = new DevExpress.XtraEditors.SimpleButton();
			this.sBtnForfeit = new DevExpress.XtraEditors.SimpleButton();
			this.SimpleButton61 = new DevExpress.XtraEditors.SimpleButton();
			this.SimpleButton62 = new DevExpress.XtraEditors.SimpleButton();
			this.SimpleButton63 = new DevExpress.XtraEditors.SimpleButton();
			this.sBtnAdd = new DevExpress.XtraEditors.SimpleButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.resourcesCheckedListBoxControl1 = new DevExpress.XtraScheduler.UI.ResourcesCheckedListBoxControl();
			this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
			((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dateNavigator1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pnlCtrlScheduler)).BeginInit();
			this.pnlCtrlScheduler.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pnlCtrlTop)).BeginInit();
			this.pnlCtrlTop.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.resourcesCheckedListBoxControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
			this.splitContainerControl1.SuspendLayout();
			this.SuspendLayout();
			// 
			// schedulerStorage1
			// 
			this.schedulerStorage1.Appointments.DataMember = "tblServiceSession";
			this.schedulerStorage1.Appointments.Mappings.Description = "strRemarks";
			this.schedulerStorage1.Appointments.Mappings.End = "dtEndTime";
			this.schedulerStorage1.Appointments.Mappings.ResourceId = "nServiceEmployeeID";
			this.schedulerStorage1.Appointments.Mappings.Start = "dtStartTime";
			this.schedulerStorage1.Appointments.Mappings.Status = "nStatusID";
			this.schedulerStorage1.Appointments.Mappings.Subject = "strServiceCode";
			this.schedulerStorage1.AppointmentsInserted += new DevExpress.XtraScheduler.PersistentObjectsEventHandler(this.schedulerStorage1_AppointmentsChanged);
			this.schedulerStorage1.AppointmentsDeleted += new DevExpress.XtraScheduler.PersistentObjectsEventHandler(this.schedulerStorage1_AppointmentsChanged);
			this.schedulerStorage1.AppointmentsChanged += new DevExpress.XtraScheduler.PersistentObjectsEventHandler(this.schedulerStorage1_AppointmentsChanged);
			// 
			// dateNavigator1
			// 
			this.dateNavigator1.AppearanceCalendar.Font = new System.Drawing.Font("Tahoma", 8F);
			this.dateNavigator1.AppearanceCalendar.Options.UseFont = true;
			this.dateNavigator1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dateNavigator1.Location = new System.Drawing.Point(0, 0);
			this.dateNavigator1.Name = "dateNavigator1";
			this.dateNavigator1.SchedulerControl = this.schedulerControl1;
			this.dateNavigator1.ShowWeekNumbers = false;
			this.dateNavigator1.Size = new System.Drawing.Size(142, 296);
			this.dateNavigator1.TabIndex = 1;
			this.dateNavigator1.DoubleClick += new System.EventHandler(this.dateNavigator1_EditDateModified);
			// 
			// schedulerControl1
			// 
			this.schedulerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.schedulerControl1.Location = new System.Drawing.Point(0, 0);
			this.schedulerControl1.Name = "schedulerControl1";
			this.schedulerControl1.OptionsCustomization.AllowAppointmentConflicts = DevExpress.XtraScheduler.AppointmentConflictsMode.Forbidden;
			this.schedulerControl1.OptionsCustomization.AllowAppointmentCopy = DevExpress.XtraScheduler.UsedAppointmentType.None;
			this.schedulerControl1.OptionsCustomization.AllowAppointmentDelete = DevExpress.XtraScheduler.UsedAppointmentType.None;
			this.schedulerControl1.OptionsCustomization.AllowAppointmentDrag = DevExpress.XtraScheduler.UsedAppointmentType.None;
			this.schedulerControl1.OptionsCustomization.AllowAppointmentDragBetweenResources = DevExpress.XtraScheduler.UsedAppointmentType.None;
			this.schedulerControl1.OptionsCustomization.AllowAppointmentMultiSelect = false;
			this.schedulerControl1.OptionsCustomization.AllowInplaceEditor = DevExpress.XtraScheduler.UsedAppointmentType.None;
			this.schedulerControl1.OptionsView.ToolTipVisibility = DevExpress.XtraScheduler.ToolTipVisibility.Always;
			this.schedulerControl1.Size = new System.Drawing.Size(684, 372);
			this.schedulerControl1.Start = new System.DateTime(2006, 4, 22, 0, 0, 0, 0);
			this.schedulerControl1.Storage = this.schedulerStorage1;
			this.schedulerControl1.TabIndex = 0;
			this.schedulerControl1.Text = "schedulerControl1";
			this.schedulerControl1.ToolTipController = this.toolTipController1;
			this.schedulerControl1.Views.DayView.Appearance.HeaderCaption.Font = new System.Drawing.Font("Tahoma", 10F);
			this.schedulerControl1.Views.DayView.Appearance.HeaderCaption.Options.UseFont = true;
			this.schedulerControl1.Views.DayView.TimeRulers.AddRange(new DevExpress.XtraScheduler.TimeRuler[] {
																												  timeRuler1});
			this.schedulerControl1.Views.DayView.TimeScale = System.TimeSpan.Parse("00:15:00");
			this.schedulerControl1.Views.DayView.VisibleTime.Duration = System.TimeSpan.Parse("1.00:00:00");
			this.schedulerControl1.Views.DayView.WorkTime.Duration = System.TimeSpan.Parse("09:00:00");
			this.schedulerControl1.Views.WorkWeekView.TimeRulers.AddRange(new DevExpress.XtraScheduler.TimeRuler[] {
																													   timeRuler2});
			this.schedulerControl1.Views.WorkWeekView.VisibleTime.Duration = System.TimeSpan.Parse("1.00:00:00");
			this.schedulerControl1.Views.WorkWeekView.WorkTime.Duration = System.TimeSpan.Parse("09:00:00");
			this.schedulerControl1.SelectionChanged += new System.EventHandler(this.schedulerControl1_SelectionChanged);
			this.schedulerControl1.CustomDrawAppointmentBackground += new DevExpress.XtraScheduler.CustomDrawObjectEventHandler(this.schedulerControl1_CustomDrawAppointmentBackground);
			this.schedulerControl1.CustomDrawResourceHeader += new DevExpress.XtraScheduler.CustomDrawObjectEventHandler(this.schedulerControl1_CustomDrawResourceHeader);
			this.schedulerControl1.EditAppointmentFormShowing += new DevExpress.XtraScheduler.AppointmentFormEventHandler(this.schedulerControl1_EditAppointmentFormShowing_1);
			// 
			// toolTipController1
			// 
			this.toolTipController1.ShowShadow = false;
			this.toolTipController1.BeforeShow += new DevExpress.Utils.ToolTipControllerBeforeShowEventHandler(this.toolTipController1_BeforeShow);
			// 
			// splitterControl1
			// 
			this.splitterControl1.Dock = System.Windows.Forms.DockStyle.Right;
			this.splitterControl1.Location = new System.Drawing.Point(684, 0);
			this.splitterControl1.Name = "splitterControl1";
			this.splitterControl1.Size = new System.Drawing.Size(4, 408);
			this.splitterControl1.TabIndex = 2;
			this.splitterControl1.TabStop = false;
			// 
			// pnlCtrlScheduler
			// 
			this.pnlCtrlScheduler.AutoScroll = true;
			this.pnlCtrlScheduler.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.pnlCtrlScheduler.Controls.Add(this.schedulerControl1);
			this.pnlCtrlScheduler.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlCtrlScheduler.Location = new System.Drawing.Point(0, 36);
			this.pnlCtrlScheduler.Name = "pnlCtrlScheduler";
			this.pnlCtrlScheduler.Size = new System.Drawing.Size(684, 372);
			this.pnlCtrlScheduler.TabIndex = 4;
			this.pnlCtrlScheduler.Text = "panelControl2";
			// 
			// pnlCtrlTop
			// 
			this.pnlCtrlTop.Appearance.BackColor = System.Drawing.Color.White;
			this.pnlCtrlTop.Appearance.ForeColor = System.Drawing.Color.Transparent;
			this.pnlCtrlTop.Appearance.Options.UseBackColor = true;
			this.pnlCtrlTop.Appearance.Options.UseForeColor = true;
			this.pnlCtrlTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.pnlCtrlTop.Controls.Add(this.sBtnRefresh);
			this.pnlCtrlTop.Controls.Add(this.sBtnWaitingList);
			this.pnlCtrlTop.Controls.Add(this.sBtnSubtract);
			this.pnlCtrlTop.Controls.Add(this.sBtnForfeit);
			this.pnlCtrlTop.Controls.Add(this.SimpleButton61);
			this.pnlCtrlTop.Controls.Add(this.SimpleButton62);
			this.pnlCtrlTop.Controls.Add(this.SimpleButton63);
			this.pnlCtrlTop.Controls.Add(this.sBtnAdd);
			this.pnlCtrlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlCtrlTop.Location = new System.Drawing.Point(0, 0);
			this.pnlCtrlTop.Name = "pnlCtrlTop";
			this.pnlCtrlTop.Size = new System.Drawing.Size(684, 36);
			this.pnlCtrlTop.TabIndex = 5;
			this.pnlCtrlTop.Text = "panelControl2";
			// 
			// sBtnRefresh
			// 
			this.sBtnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.sBtnRefresh.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.sBtnRefresh.Appearance.Options.UseFont = true;
			this.sBtnRefresh.Location = new System.Drawing.Point(538, 8);
			this.sBtnRefresh.Name = "sBtnRefresh";
			this.sBtnRefresh.Size = new System.Drawing.Size(82, 24);
			this.sBtnRefresh.TabIndex = 57;
			this.sBtnRefresh.Text = "Refresh";
			this.sBtnRefresh.Click += new System.EventHandler(this.sBtnRefresh_Click);
			// 
			// sBtnWaitingList
			// 
			this.sBtnWaitingList.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.sBtnWaitingList.Appearance.Options.UseFont = true;
			this.sBtnWaitingList.Location = new System.Drawing.Point(276, 8);
			this.sBtnWaitingList.Name = "sBtnWaitingList";
			this.sBtnWaitingList.Size = new System.Drawing.Size(82, 20);
			this.sBtnWaitingList.TabIndex = 56;
			this.sBtnWaitingList.Text = "Waiting List";
			this.sBtnWaitingList.Click += new System.EventHandler(this.sBtnWaitingList_Click);
			// 
			// sBtnSubtract
			// 
			this.sBtnSubtract.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.sBtnSubtract.Appearance.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.sBtnSubtract.Appearance.Options.UseFont = true;
			this.sBtnSubtract.Appearance.Options.UseTextOptions = true;
			this.sBtnSubtract.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.sBtnSubtract.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
			this.sBtnSubtract.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.sBtnSubtract.ImageIndex = 1;
			this.sBtnSubtract.Location = new System.Drawing.Point(654, 8);
			this.sBtnSubtract.Name = "sBtnSubtract";
			this.sBtnSubtract.Size = new System.Drawing.Size(28, 25);
			this.sBtnSubtract.TabIndex = 54;
			this.sBtnSubtract.Text = ">>";
			this.sBtnSubtract.Click += new System.EventHandler(this.sBtnSubtract_Click);
			// 
			// sBtnForfeit
			// 
			this.sBtnForfeit.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.sBtnForfeit.Appearance.Options.UseFont = true;
			this.sBtnForfeit.Location = new System.Drawing.Point(126, 8);
			this.sBtnForfeit.Name = "sBtnForfeit";
			this.sBtnForfeit.Size = new System.Drawing.Size(54, 20);
			this.sBtnForfeit.TabIndex = 15;
			this.sBtnForfeit.Text = "Forfeit";
			this.sBtnForfeit.Click += new System.EventHandler(this.sBtnForfeit_Click);
			// 
			// SimpleButton61
			// 
			this.SimpleButton61.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.SimpleButton61.Appearance.Options.UseFont = true;
			this.SimpleButton61.Location = new System.Drawing.Point(184, 8);
			this.SimpleButton61.Name = "SimpleButton61";
			this.SimpleButton61.Size = new System.Drawing.Size(88, 20);
			this.SimpleButton61.TabIndex = 14;
			this.SimpleButton61.Text = "Mark Service";
			this.SimpleButton61.Click += new System.EventHandler(this.SimpleButton61_Click);
			// 
			// SimpleButton62
			// 
			this.SimpleButton62.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.SimpleButton62.Appearance.Options.UseFont = true;
			this.SimpleButton62.Location = new System.Drawing.Point(64, 8);
			this.SimpleButton62.Name = "SimpleButton62";
			this.SimpleButton62.Size = new System.Drawing.Size(58, 20);
			this.SimpleButton62.TabIndex = 13;
			this.SimpleButton62.Text = "Delete";
			this.SimpleButton62.Click += new System.EventHandler(this.SimpleButton62_Click);
			// 
			// SimpleButton63
			// 
			this.SimpleButton63.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.SimpleButton63.Appearance.Options.UseFont = true;
			this.SimpleButton63.Location = new System.Drawing.Point(10, 8);
			this.SimpleButton63.Name = "SimpleButton63";
			this.SimpleButton63.Size = new System.Drawing.Size(50, 20);
			this.SimpleButton63.TabIndex = 12;
			this.SimpleButton63.Text = "New";
			this.SimpleButton63.Click += new System.EventHandler(this.SimpleButton63_Click);
			// 
			// sBtnAdd
			// 
			this.sBtnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.sBtnAdd.Appearance.Font = new System.Drawing.Font("Verdana", 8F);
			this.sBtnAdd.Appearance.Options.UseFont = true;
			this.sBtnAdd.Appearance.Options.UseTextOptions = true;
			this.sBtnAdd.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.sBtnAdd.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
			this.sBtnAdd.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.sBtnAdd.ImageIndex = 0;
			this.sBtnAdd.Location = new System.Drawing.Point(624, 8);
			this.sBtnAdd.Name = "sBtnAdd";
			this.sBtnAdd.Size = new System.Drawing.Size(28, 25);
			this.sBtnAdd.TabIndex = 55;
			this.sBtnAdd.Text = "<<";
			this.sBtnAdd.Click += new System.EventHandler(this.sBtnAdd_Click);
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
			// 
			// resourcesCheckedListBoxControl1
			// 
			this.resourcesCheckedListBoxControl1.CheckOnClick = true;
			this.resourcesCheckedListBoxControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.resourcesCheckedListBoxControl1.Location = new System.Drawing.Point(0, 0);
			this.resourcesCheckedListBoxControl1.Name = "resourcesCheckedListBoxControl1";
			this.resourcesCheckedListBoxControl1.SchedulerControl = this.schedulerControl1;
			this.resourcesCheckedListBoxControl1.Size = new System.Drawing.Size(142, 92);
			this.resourcesCheckedListBoxControl1.TabIndex = 6;
			// 
			// splitContainerControl1
			// 
			this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Right;
			this.splitContainerControl1.Horizontal = false;
			this.splitContainerControl1.Location = new System.Drawing.Point(688, 0);
			this.splitContainerControl1.Name = "splitContainerControl1";
			this.splitContainerControl1.Panel1.Controls.Add(this.resourcesCheckedListBoxControl1);
			this.splitContainerControl1.Panel1.Text = "splitContainerControl1_Panel1";
			this.splitContainerControl1.Panel2.Controls.Add(this.dateNavigator1);
			this.splitContainerControl1.Panel2.Text = "splitContainerControl1_Panel2";
			this.splitContainerControl1.Size = new System.Drawing.Size(150, 408);
			this.splitContainerControl1.TabIndex = 57;
			this.splitContainerControl1.Text = "splitContainerControl1";
			// 
			// SpaBookingControl
			// 
			this.Controls.Add(this.pnlCtrlScheduler);
			this.Controls.Add(this.pnlCtrlTop);
			this.Controls.Add(this.splitterControl1);
			this.Controls.Add(this.splitContainerControl1);
			this.Name = "SpaBookingControl";
			this.Size = new System.Drawing.Size(838, 408);
			((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dateNavigator1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pnlCtrlScheduler)).EndInit();
			this.pnlCtrlScheduler.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pnlCtrlTop)).EndInit();
			this.pnlCtrlTop.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.resourcesCheckedListBoxControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
			this.splitContainerControl1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion


		public void Init(bool isInternalCall)
		{
			try
			{
				if (myHaveInit && !isInternalCall) return;

				int index = myCurrentPageRate * 5;

				myHaveInit = true;

				if (mySpaBooking == null)
					mySpaBooking = new ACMSLogic.SpaBooking();

				myServiceSessionTable = mySpaBooking.GetCurrentBranchServiceSession();
				myServiceSessionTable.TableName = "tblServiceSession";
				
				
				ACMSDAL.TblEmployee sqlEmployee = new ACMSDAL.TblEmployee();
				
				myEmployeeTable = sqlEmployee.GetTherapistForSpaBooking(ACMSLogic.User.BranchCode, dateNavigator1.DateTime.Date, index, index + 5);
				myEmployeeTable.TableName = "tblEmployee";

				myDataSet = new DataSet("DS");
				myDataSet.Tables.Add(myServiceSessionTable);
				myDataSet.Tables.Add(myEmployeeTable);

				DataRelation relation = new DataRelation("ServiceSession_Therapist_Relation", 
					myServiceSessionTable.Columns["nServiceEmployeeID"], 
					myEmployeeTable.Columns["nEmployeeID"], false);

				myDataSet.Relations.Add(relation);

				schedulerStorage1.Appointments.DataMember = "tblServiceSession";
				schedulerStorage1.Appointments.DataSource = myDataSet;
				schedulerStorage1.Appointments.Mappings.Description = "strRemarks";
				schedulerStorage1.Appointments.Mappings.End = "dtEndTime";
				schedulerStorage1.Appointments.Mappings.ResourceId = "nServiceEmployeeID";
				schedulerStorage1.Appointments.Mappings.Start = "dtStartTime";
				schedulerStorage1.Appointments.Mappings.Status = "nStatusID";
				schedulerStorage1.Appointments.Mappings.Subject = "strMembershipID";
			
				schedulerStorage1.Resources.DataMember = "tblEmployee";
				schedulerStorage1.Resources.DataSource = myDataSet;
				schedulerStorage1.Resources.Mappings.Caption = "strEmployeeName";
				schedulerStorage1.Resources.Mappings.Id = "nEmployeeID";

				schedulerControl1.GroupType = DevExpress.XtraScheduler.SchedulerGroupType.Resource;			
					
				if (!isInternalCall)
					schedulerControl1.Start = DateTime.Today;
				
				schedulerControl1.DayView.WorkTime = 
					new DevExpress.XtraScheduler.TimeOfDayInterval(TimeSpan.FromHours(9.00), TimeSpan.FromHours(23.00));
				schedulerControl1.DayView.ShowWorkTimeOnly = true;
				schedulerControl1.DayView.TimeRulers[0].ShowMinutes = true;
				schedulerControl1.DayView.TimeScale = TimeSpan.FromMinutes(15.00);
							
			}
			catch 
			{}
		}

		private void schedulerStorage1_AppointmentsChanged(object sender, DevExpress.XtraScheduler.PersistentObjectsEventArgs e)
		{
			myDataSet.AcceptChanges();
		}

		private void schedulerControl1_EditAppointmentFormShowing_1(object sender, DevExpress.XtraScheduler.AppointmentFormEventArgs e)
		{
			if (schedulerStorage1.Resources.Items.Count > 0)
			{
				try
				{
					FormNewSpaBooking frmNewSpaBooking = new FormNewSpaBooking(mySpaBooking, false, e.Appointment);
				
					e.DialogResult = frmNewSpaBooking.ShowDialog(this);

					if (e.DialogResult == DialogResult.OK)
					{
						Init(true);
					}
				
				}
				catch (Exception ex)
				{
					MessageBox.Show(this, ex.Message);
				}
				finally
				{
					e.Handled = true;
				}
			}
			else
			{
				e.Handled=true;
			}
		}

		private void sBtnAdd_Click(object sender, System.EventArgs e)
		{
			if (myCurrentPageRate <= 0) return;

			myCurrentPageRate -= 1;
			Init(true);
		}

		private void sBtnSubtract_Click(object sender, System.EventArgs e)
		{
//			if (schedulerControl1.DayView.TimeScale.Minutes == 15) return;
//			schedulerControl1.DayView.TimeScale = schedulerControl1.DayView.TimeScale - TimeSpan.FromMinutes(15);
			
			if (myEmployeeTable.Rows.Count == 5)
			{
				myCurrentPageRate += 1;
				Init(true);
			}
		}

		private void schedulerControl1_SelectionChanged(object sender, System.EventArgs e)
		{
			if (mySpaBooking != null)
			{
				if (schedulerControl1.SelectedAppointments.Count == 1)
				{
					DevExpress.XtraScheduler.Appointment appointment = 
						schedulerControl1.SelectedAppointments[0];

					DataRowView rowView = (DataRowView) appointment.GetRow(schedulerControl1.Storage);

					//fire Event
					if (mySchedulerChangedEvent != null)
					{
						mySchedulerChangedEvent(rowView.Row);
					}
				}
				else
				{
					if (mySchedulerChangedEvent != null)
					{
						mySchedulerChangedEvent(null);
					}
				}
			}	
			else
			{
				if (mySchedulerChangedEvent != null)
				{
					mySchedulerChangedEvent(null);
				}
			}
		}

		private void schedulerControl1_CustomDrawAppointmentBackground(object sender, DevExpress.XtraScheduler.CustomDrawObjectEventArgs e)
		{
			DevExpress.XtraScheduler.Drawing.AppointmentViewInfo aptViewInfo = e.ObjectInfo as AppointmentViewInfo;
			
			if (aptViewInfo != null) 
			{
				AppearanceObject app =  aptViewInfo.Appearance;
				
				DevExpress.XtraScheduler.Appointment appointment = 
					aptViewInfo.Appointment;

				DataRowView rowView = (DataRowView) appointment.GetRow(schedulerControl1.Storage);
				
				if (rowView != null)
				{
					DataRow row = rowView.Row;

					if (ACMS.Convert.ToInt32(row["nStatusID"]) == 2)
					{
						app.BackColor = Color.Aqua;		
						app.DrawBackground(e.Cache, e.Bounds);
					}
					else if (ACMS.Convert.ToInt32(row["nStatusID"]) == 5)
					{
						app.BackColor = Color.Yellow;		
						app.DrawBackground(e.Cache, e.Bounds);
					}

					
					if (ACMS.Convert.ToInt32(row["nStatusID"]) == 2 ||
						ACMS.Convert.ToInt32(row["nStatusID"]) == 5)
					{
//						
//
//						DevExpress.Utils.AppearanceObject app2 = new DevExpress.Utils.AppearanceObject();
//						Rectangle rect1 = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
//						
//						System.Drawing.StringFormat strFormat = new StringFormat();
//						strFormat.Alignment = StringAlignment.Near;
//						
//						app2.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
//						app2.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
//						
//						System.Drawing.FontStyle fs = new FontStyle();
//						fs |= FontStyle.Bold;
//						fs |= FontStyle.Underline;
//
//						app2.Font = new Font(app2.Font.FontFamily, app2.Font.Size, fs);
//						app2.DrawString(e.Cache, 
//							"M'ID:" + row["strMembershipID"].ToString() + ", S'Code: " + aptViewInfo.DisplayText, 
//							rect1, strFormat);
//
//						app.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
//						app.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
//
//						Rectangle rect2 = new Rectangle(e.Bounds.X, e.Bounds.Y + 5, e.Bounds.Width, e.Bounds.Height + 5);
//
//						app.DrawString(e.Cache, aptViewInfo.DisplayDescription, rect2, app.TextOptions.GetStringFormat());
//						
//						
						e.Handled = true;

					}
				}
			}			
		}

		private void SimpleButton63_Click(object sender, System.EventArgs e)
		{
			if (schedulerControl1.SelectedAppointments.Count == 0)
			{
				schedulerControl1.CreateNewAppointment();
			}
		}

		private void SimpleButton62_Click(object sender, System.EventArgs e)
		{
			if (schedulerControl1.SelectedAppointments.Count > 0)
			{
				if (schedulerControl1.SelectedAppointments.Count == 1)
				{
					DataRowView rowView = (DataRowView) schedulerControl1.SelectedAppointments[0].GetRow(schedulerControl1.Storage);
					DataRow row = rowView.Row;

					DialogResult result = MessageBox.Show(this, "Do you really want to delete the record with Member ID = '" + row["strMembershipID"].ToString() + "' and Service Code= '" + row["strServiceCode"].ToString() + "'",
						"Delete?", MessageBoxButtons.YesNo);

					if (result == DialogResult.Yes)
					{
						try
						{
							if (mySpaBooking.DeleteBooking(ACMS.Convert.ToInt32(row["nSessionID"])))
							{
								MessageBox.Show(this, "Record is successful deleted"); 
							}
							Init(true);
						}
						catch (Exception ex)
						{
							MessageBox.Show(ex.Message);
						}
					}
				}
				else
				{
					DialogResult result = MessageBox.Show(this, "You have selected more than 1 record, are you really want to delete it?",
						"Delete?", MessageBoxButtons.YesNo);
					
					if (result == DialogResult.Yes)
					{
						try
						{
							foreach (DevExpress.XtraScheduler.Appointment app in 
								schedulerControl1.SelectedAppointments)
							{
								DataRowView rowView = (DataRowView) app.GetRow(schedulerControl1.Storage);
								DataRow row = rowView.Row;

								mySpaBooking.DeleteBooking(ACMS.Convert.ToInt32(row["nSessionID"]));
							
							}
						}
						catch (Exception ex)
						{
							MessageBox.Show(ex.Message);
						}
						finally
						{
							Init(true);
						}
					}
				}
			}
		}

		private void sBtnForfeit_Click(object sender, System.EventArgs e)
		{
			if (schedulerControl1.SelectedAppointments.Count > 0)
			{
				if (schedulerControl1.SelectedAppointments.Count == 1)
				{
					DataRowView rowView = (DataRowView) schedulerControl1.SelectedAppointments[0].GetRow(schedulerControl1.Storage);
					DataRow row = rowView.Row;

					DialogResult result = MessageBox.Show(this, "Do you really want to forferit the record with Member ID = '" + row["strMembershipID"].ToString() + "' and Service Code= '" + row["strServiceCode"].ToString() + "'",
						"Forfeit?", MessageBoxButtons.YesNo);

					if (result == DialogResult.Yes)
					{
						try
						{
							if (mySpaBooking.ForfeitBooking(ACMS.Convert.ToInt32(row["nSessionID"])))
							{
								MessageBox.Show(this, "Record is successful forfeited"); 
							}
							Init(true);
						}
						catch (Exception ex)
						{
							MessageBox.Show(ex.Message);
						}
						
					}
				}
				else
				{
					DialogResult result = MessageBox.Show(this, "You have selected more than 1 record, are you really want to forfeit it?",
						"Forfeit?", MessageBoxButtons.YesNo);
					
					if (result == DialogResult.Yes)
					{
						try
						{
							foreach (DevExpress.XtraScheduler.Appointment app in 
								schedulerControl1.SelectedAppointments)
							{
								DataRowView rowView = (DataRowView) app.GetRow(schedulerControl1.Storage);
								DataRow row = rowView.Row;

								mySpaBooking.ForfeitBooking(ACMS.Convert.ToInt32(row["nSessionID"]));
							
							}
						}
						catch (Exception ex)
						{
							MessageBox.Show(ex.Message);
						}
						finally
						{
							Init(true);
						}
					}
				}
			}		
		}

		private void SimpleButton61_Click(object sender, System.EventArgs e)
		{
			if (schedulerControl1.SelectedAppointments.Count > 0)
			{
				DataRowView rowView = (DataRowView) schedulerControl1.SelectedAppointments[0].GetRow(schedulerControl1.Storage);
				DataRow r = rowView.Row;

				if (r != null)
				{
					try
					{
						int nServiceSessionID = ACMS.Convert.ToInt32(r["nSessionID"]);
						string membershipID = r["strMembershipID"].ToString();
						string serviceSessionBranchCode = r["strBranchCode"].ToString();

						FormMarkService frm = new FormMarkService(mySpaBooking, nServiceSessionID, membershipID, 
							serviceSessionBranchCode);
						DialogResult result = frm.ShowDialog(this);
						
						if (result == DialogResult.OK)
						{
							Init(true);	
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message);
					}
				}
			}
		}


		private void dateNavigator1_EditDateModified(object sender, System.EventArgs e)
		{
			myCurrentPageRate = 0;
			Init(true);
		}

		private void sBtnWaitingList_Click(object sender, System.EventArgs e)
		{
			FormNewSpaBooking waitingListfrm = new FormNewSpaBooking(mySpaBooking, true);
			if (schedulerControl1.SelectedInterval != null)
				waitingListfrm.DtStartTime = schedulerControl1.SelectedInterval.Start;
			DialogResult result = waitingListfrm.ShowDialog(this);

			if (result == DialogResult.OK)
			{
				Init(true);
			}
		}

		private void toolTipController1_BeforeShow(object sender, DevExpress.Utils.ToolTipControllerShowEventArgs e)
		{
			
			if (e.SelectedObject is DevExpress.XtraScheduler.Appointment)
			{
				DevExpress.XtraScheduler.Appointment appointment = 
					(DevExpress.XtraScheduler.Appointment)e.SelectedObject;
				
				if (appointment != null)
				{
					DataRowView rowView = (DataRowView) appointment.GetRow(schedulerControl1.Storage);

					if (rowView != null)
					{
						e.Title = rowView["strServiceCode"].ToString() + " " + rowView["strMemberName"].ToString();
						e.ToolTip = "Tel No: " + rowView["strMobileNo"].ToString() + " \n Remark: " + rowView["strRemarks"].ToString();
					}
				}
			}
		}

		private void sBtnRefresh_Click(object sender, System.EventArgs e)
		{
			Init(true);
		}

		private void schedulerControl1_CustomDrawResourceHeader(object sender, DevExpress.XtraScheduler.CustomDrawObjectEventArgs e)
		{
			DevExpress.XtraScheduler.Drawing.ResourceHeader resourceHeader = e.ObjectInfo as ResourceHeader;
			
			if (resourceHeader != null)
			{
				DataRowView rowView = (DataRowView)resourceHeader.Resource.GetRow(schedulerControl1.Storage);
				if (rowView != null)
				{
					string dtstartTime = ACMS.Convert.ToDateTime(rowView["dtStartTime"]).ToString("T");
					string dtEndTime = ACMS.Convert.ToDateTime(rowView["dtEndTime"]).ToString("T");
					
					string strCaption = resourceHeader.Resource.Caption + "\n" + dtstartTime + " -- " + dtEndTime;
                    AppearanceObject appObj = resourceHeader.Appearance.Selection;
					appObj.Font = new Font(appObj.Font.FontFamily.Name, 7); 
					appObj.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
					appObj.BackColor = Color.White;		
					appObj.DrawBackground(e.Graphics, e.Cache, e.Bounds, false);
					appObj.DrawString(e.Cache, strCaption, e.Bounds);

					e.Handled = true;
				}	
			}
		}
	}
}
