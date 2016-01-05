namespace DevExpress.XtraScheduler.Demos {
	partial class DateNavigatorModule {
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing) {
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraScheduler.TimeRuler timeRuler3 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler4 = new DevExpress.XtraScheduler.TimeRuler();
            this.panelControl = new DevExpress.XtraEditors.PanelControl();
            this.comboBoxRosterCC = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.cbWeekNumberRule = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.lblWeeksCount = new System.Windows.Forms.Label();
            this.chkShowWeekNumbers = new DevExpress.XtraEditors.CheckEdit();
            this.chkBoldAppointmentDates = new DevExpress.XtraEditors.CheckEdit();
            this.chkShowTodayButton = new DevExpress.XtraEditors.CheckEdit();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.schedulerControl = new DevExpress.XtraScheduler.SchedulerControl();
            this.schedulerStorage1 = new DevExpress.XtraScheduler.SchedulerStorage(this.components);
            this.tblDeliveryScheduleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.acmsDataSet1 = new ACMS.ACMSDataSet();
            this.dateNavigator1 = new DevExpress.XtraScheduler.DateNavigator();
            this.tblDeliveryScheduleTableAdapter = new ACMS.ACMSDataSetTableAdapters.TblDeliveryScheduleTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl)).BeginInit();
            this.panelControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxRosterCC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbWeekNumberRule.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowWeekNumbers.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkBoldAppointmentDates.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowTodayButton.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDeliveryScheduleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acmsDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl
            // 
            this.panelControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.panelControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl.Controls.Add(this.comboBoxRosterCC);
            this.panelControl.Controls.Add(this.label2);
            this.panelControl.Controls.Add(this.cbWeekNumberRule);
            this.panelControl.Controls.Add(this.lblWeeksCount);
            this.panelControl.Controls.Add(this.chkShowWeekNumbers);
            this.panelControl.Controls.Add(this.chkBoldAppointmentDates);
            this.panelControl.Controls.Add(this.chkShowTodayButton);
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl.Location = new System.Drawing.Point(8, 8);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(974, 34);
            this.panelControl.TabIndex = 1;
            // 
            // comboBoxRosterCC
            // 
            this.comboBoxRosterCC.EditValue = 0;
            this.comboBoxRosterCC.Location = new System.Drawing.Point(98, 8);
            this.comboBoxRosterCC.Name = "comboBoxRosterCC";
            this.comboBoxRosterCC.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxRosterCC.Properties.Appearance.Options.UseBackColor = true;
            this.comboBoxRosterCC.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxRosterCC.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("-- Select All --", 0, -1)});
            this.comboBoxRosterCC.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.comboBoxRosterCC.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.comboBoxRosterCC.Size = new System.Drawing.Size(128, 20);
            this.comboBoxRosterCC.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 36;
            this.label2.Text = "Cost Center";
            // 
            // cbWeekNumberRule
            // 
            this.cbWeekNumberRule.EditValue = "";
            this.cbWeekNumberRule.Location = new System.Drawing.Point(949, 7);
            this.cbWeekNumberRule.Name = "cbWeekNumberRule";
            this.cbWeekNumberRule.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbWeekNumberRule.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Default", DevExpress.XtraEditors.Controls.WeekNumberRule.Default, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("FirstDay", DevExpress.XtraEditors.Controls.WeekNumberRule.FirstDay, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("FirstFullWeek", DevExpress.XtraEditors.Controls.WeekNumberRule.FirstFullWeek, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("FirstFourDayWeek", DevExpress.XtraEditors.Controls.WeekNumberRule.FirstFourDayWeek, -1)});
            this.cbWeekNumberRule.Size = new System.Drawing.Size(10, 20);
            this.cbWeekNumberRule.TabIndex = 34;
            this.cbWeekNumberRule.Visible = false;
            this.cbWeekNumberRule.SelectedIndexChanged += new System.EventHandler(this.cbWeekNumberRule_SelectedIndexChanged);
            // 
            // lblWeeksCount
            // 
            this.lblWeeksCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWeeksCount.AutoSize = true;
            this.lblWeeksCount.Location = new System.Drawing.Point(404, 11);
            this.lblWeeksCount.Name = "lblWeeksCount";
            this.lblWeeksCount.Size = new System.Drawing.Size(0, 13);
            this.lblWeeksCount.TabIndex = 32;
            this.lblWeeksCount.Visible = false;
            // 
            // chkShowWeekNumbers
            // 
            this.chkShowWeekNumbers.EditValue = true;
            this.chkShowWeekNumbers.Location = new System.Drawing.Point(933, 8);
            this.chkShowWeekNumbers.Name = "chkShowWeekNumbers";
            this.chkShowWeekNumbers.Properties.Caption = "Show Week Numbers";
            this.chkShowWeekNumbers.Size = new System.Drawing.Size(10, 19);
            this.chkShowWeekNumbers.TabIndex = 1;
            this.chkShowWeekNumbers.Visible = false;
            this.chkShowWeekNumbers.CheckedChanged += new System.EventHandler(this.chkShowWeekNumbers_CheckedChanged);
            // 
            // chkBoldAppointmentDates
            // 
            this.chkBoldAppointmentDates.EditValue = true;
            this.chkBoldAppointmentDates.Location = new System.Drawing.Point(901, 9);
            this.chkBoldAppointmentDates.Name = "chkBoldAppointmentDates";
            this.chkBoldAppointmentDates.Properties.Caption = "Bold Appointment Dates";
            this.chkBoldAppointmentDates.Size = new System.Drawing.Size(10, 19);
            this.chkBoldAppointmentDates.TabIndex = 0;
            this.chkBoldAppointmentDates.Visible = false;
            this.chkBoldAppointmentDates.CheckedChanged += new System.EventHandler(this.chkBoldAppointmentDates_CheckedChanged);
            // 
            // chkShowTodayButton
            // 
            this.chkShowTodayButton.EditValue = true;
            this.chkShowTodayButton.Location = new System.Drawing.Point(917, 9);
            this.chkShowTodayButton.Name = "chkShowTodayButton";
            this.chkShowTodayButton.Properties.Caption = "Show TodayButton";
            this.chkShowTodayButton.Size = new System.Drawing.Size(10, 19);
            this.chkShowTodayButton.TabIndex = 0;
            this.chkShowTodayButton.Visible = false;
            this.chkShowTodayButton.CheckedChanged += new System.EventHandler(this.chkShowTodayButton_CheckedChanged);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl1.Location = new System.Drawing.Point(8, 42);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.splitContainerControl1.Panel1.Controls.Add(this.schedulerControl);
            this.splitContainerControl1.Panel1.Text = "splitContainerControl1_Panel1";
            this.splitContainerControl1.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.splitContainerControl1.Panel2.Controls.Add(this.dateNavigator1);
            this.splitContainerControl1.Panel2.Text = "splitContainerControl1_Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(974, 470);
            this.splitContainerControl1.SplitterPosition = 191;
            this.splitContainerControl1.TabIndex = 4;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // schedulerControl
            // 
            this.schedulerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.schedulerControl.Location = new System.Drawing.Point(0, 0);
            this.schedulerControl.MenuManager = this;
            this.schedulerControl.Name = "schedulerControl";
            this.schedulerControl.Size = new System.Drawing.Size(777, 470);
            this.schedulerControl.Start = new System.DateTime(2008, 4, 11, 0, 0, 0, 0);
            this.schedulerControl.Storage = this.schedulerStorage1;
            this.schedulerControl.TabIndex = 0;
            this.schedulerControl.Text = "schedulerControl";
            this.schedulerControl.Views.DayView.TimeRulers.Add(timeRuler3);
            this.schedulerControl.Views.WorkWeekView.TimeRulers.Add(timeRuler4);
            this.schedulerControl.EditAppointmentFormShowing += new DevExpress.XtraScheduler.AppointmentFormEventHandler(this.schedulerControl_EditAppointmentFormShowing);
            // 
            // schedulerStorage1
            // 
            this.schedulerStorage1.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("strEmployeeID", "strEmployeeID", DevExpress.XtraScheduler.FieldValueType.String));
            this.schedulerStorage1.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("strSO", "strSO", DevExpress.XtraScheduler.FieldValueType.String));
            this.schedulerStorage1.Appointments.DataSource = this.tblDeliveryScheduleBindingSource;
            this.schedulerStorage1.Appointments.Mappings.AllDay = "bAllDay";
            this.schedulerStorage1.Appointments.Mappings.Description = "strDescription";
            this.schedulerStorage1.Appointments.Mappings.End = "dtEnd";
            this.schedulerStorage1.Appointments.Mappings.Label = "nLabel";
            this.schedulerStorage1.Appointments.Mappings.Location = "strLocation";
            this.schedulerStorage1.Appointments.Mappings.RecurrenceInfo = "strRecurrenceInfo";
            this.schedulerStorage1.Appointments.Mappings.ReminderInfo = "strReminderInfo";
            this.schedulerStorage1.Appointments.Mappings.ResourceId = "strResourceID";
            this.schedulerStorage1.Appointments.Mappings.Start = "dtStart";
            this.schedulerStorage1.Appointments.Mappings.Status = "nStatus";
            this.schedulerStorage1.Appointments.Mappings.Subject = "strSubject";
            this.schedulerStorage1.Appointments.Mappings.Type = "nType";
            this.schedulerStorage1.AppointmentsChanged += new DevExpress.XtraScheduler.PersistentObjectsEventHandler(this.schedulerStorage_AppointmentsChanged);
            this.schedulerStorage1.AppointmentsInserted += new DevExpress.XtraScheduler.PersistentObjectsEventHandler(this.schedulerStorage_AppointmentsChanged);
            this.schedulerStorage1.AppointmentsDeleted += new DevExpress.XtraScheduler.PersistentObjectsEventHandler(this.schedulerStorage_AppointmentsChanged);
            // 
            // tblDeliveryScheduleBindingSource
            // 
            this.tblDeliveryScheduleBindingSource.DataMember = "TblDeliverySchedule";
            this.tblDeliveryScheduleBindingSource.DataSource = this.acmsDataSet1;
            // 
            // acmsDataSet1
            // 
            this.acmsDataSet1.DataSetName = "ACMSDataSet";
            this.acmsDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dateNavigator1
            // 
            this.dateNavigator1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateNavigator1.Location = new System.Drawing.Point(0, 0);
            this.dateNavigator1.Name = "dateNavigator1";
            this.dateNavigator1.SchedulerControl = this.schedulerControl;
            this.dateNavigator1.Size = new System.Drawing.Size(191, 470);
            this.dateNavigator1.TabIndex = 4;
            this.dateNavigator1.View = DevExpress.XtraEditors.Controls.DateEditCalendarViewType.MonthInfo;
            // 
            // tblDeliveryScheduleTableAdapter
            // 
            this.tblDeliveryScheduleTableAdapter.ClearBeforeFill = true;
            // 
            // DateNavigatorModule
            // 
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.panelControl);
            this.Name = "DateNavigatorModule";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Size = new System.Drawing.Size(990, 520);
            this.Load += new System.EventHandler(this.MonthViewModule_Load);
            this.VisibleChanged += new System.EventHandler(this.DateNavigatorModule_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl)).EndInit();
            this.panelControl.ResumeLayout(false);
            this.panelControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxRosterCC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbWeekNumberRule.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowWeekNumbers.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkBoldAppointmentDates.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowTodayButton.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDeliveryScheduleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acmsDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private DevExpress.XtraEditors.PanelControl panelControl;
		private DevExpress.XtraEditors.CheckEdit chkBoldAppointmentDates;
		private DevExpress.XtraEditors.CheckEdit chkShowTodayButton;
		private DevExpress.XtraEditors.CheckEdit chkShowWeekNumbers;
		private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraScheduler.DateNavigator dateNavigator1;
		private System.Windows.Forms.Label lblWeeksCount;
		private DevExpress.XtraEditors.ImageComboBoxEdit cbWeekNumberRule;
		private System.ComponentModel.IContainer components = null;
        private ACMS.ACMSDataSet acmsDataSet1;
        private ACMS.ACMSDataSetTableAdapters.TblDeliveryScheduleTableAdapter tblDeliveryScheduleTableAdapter;
        private DevExpress.XtraEditors.ImageComboBoxEdit comboBoxRosterCC;
        private System.Windows.Forms.Label label2;
        private SchedulerControl schedulerControl;
        private System.Windows.Forms.BindingSource tblDeliveryScheduleBindingSource;
        private SchedulerStorage schedulerStorage1;

	}
}
