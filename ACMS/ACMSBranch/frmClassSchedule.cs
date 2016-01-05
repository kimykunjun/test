using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;


namespace ACMS.ACMSManager
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmClassSchedule : System.Windows.Forms.Form
	{
		private string connectionString;
		private SqlConnection connection;

		private DevExpress.XtraEditors.GroupControl groupControl1;
		private DevExpress.XtraEditors.SimpleButton btnClassScheduleCancel;
		private DevExpress.XtraEditors.SimpleButton btnClassScheduleUpdate;
		private DevExpress.XtraEditors.PanelControl panelControlFlagBox;
		private System.Windows.Forms.Label labelBranch;
		private DevExpress.XtraEditors.TextEdit textEditMaxNo;
		private DevExpress.XtraEditors.CheckEdit checkEditFUOB;
		private DevExpress.XtraEditors.CheckEdit checkEditFReserve;
		private DevExpress.XtraEditors.CheckEdit checkEditFFree;
        private System.Windows.Forms.Label labelPeak;
		private System.Windows.Forms.Label labelInstructor;
		private System.Windows.Forms.Label labelHallNumber;
		private System.Windows.Forms.Label labelClassName;
		private System.Windows.Forms.Label labelEndTime;
		private System.Windows.Forms.Label labelStartTime;
		private System.Windows.Forms.Label labelDay;
		private System.Windows.Forms.Label labelClassLimit;
		private DevExpress.XtraEditors.ImageComboBoxEdit comboBoxBranch;
		private DevExpress.XtraEditors.ImageComboBoxEdit comboBoxHallNumber;
        private DevExpress.XtraEditors.ImageComboBoxEdit comboBoxPeak;
		private DevExpress.XtraEditors.ImageComboBoxEdit comboBoxInstructor;
		private DevExpress.XtraEditors.ImageComboBoxEdit comboBoxClassName;
		private DevExpress.XtraEditors.ImageComboBoxEdit comboBoxDay;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private char cmd;
		private DevExpress.XtraEditors.CheckEdit checkEditFAllowStudet;
		private DevExpress.XtraEditors.ImageComboBoxEdit comboBoxCommisionType;
		private System.Windows.Forms.Label labelCommission;
		private DevExpress.XtraEditors.SimpleButton btnClassScheduleDelete;
		private DevExpress.XtraEditors.TimeEdit dateEditStartTime;
		private DevExpress.XtraEditors.TimeEdit dateEditEndTime;
		private DevExpress.XtraEditors.TextEdit txtClassScheduleID;
        private Label labelPeriod;
        private DateEdit dtStart;
        private Label label1;
        private DateEdit dtEnd;
        private CheckEdit checkNoEnd;
	
		public char command
		{
			get
			{
				return cmd;
			}
			set
			{
				cmd = value;
			}
		}


		private DataTable _cs;
		public DataTable ClassSchedule
		{
			get
			{
				return _cs;
			}
			set
			{
				_cs = value;
			}
		}


		public frmClassSchedule(char cmd) //DataTable dtClassSchedule)
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
			init();
			this.command = cmd;

		}

		public frmClassSchedule(DataTable dtClassSchedule)
		{
			InitializeComponent();
			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);
			init();

			//this.command = cmd;
			this.ClassSchedule = dtClassSchedule;
			//if (cmd=='N')
			//{
			bind();
			//}
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.checkNoEnd = new DevExpress.XtraEditors.CheckEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.dtEnd = new DevExpress.XtraEditors.DateEdit();
            this.labelPeriod = new System.Windows.Forms.Label();
            this.dtStart = new DevExpress.XtraEditors.DateEdit();
            this.dateEditEndTime = new DevExpress.XtraEditors.TimeEdit();
            this.dateEditStartTime = new DevExpress.XtraEditors.TimeEdit();
            this.btnClassScheduleDelete = new DevExpress.XtraEditors.SimpleButton();
            this.labelCommission = new System.Windows.Forms.Label();
            this.comboBoxCommisionType = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.comboBoxInstructor = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.comboBoxHallNumber = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.comboBoxClassName = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.comboBoxDay = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.comboBoxBranch = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.btnClassScheduleCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnClassScheduleUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.panelControlFlagBox = new DevExpress.XtraEditors.PanelControl();
            this.checkEditFAllowStudet = new DevExpress.XtraEditors.CheckEdit();
            this.checkEditFUOB = new DevExpress.XtraEditors.CheckEdit();
            this.checkEditFReserve = new DevExpress.XtraEditors.CheckEdit();
            this.checkEditFFree = new DevExpress.XtraEditors.CheckEdit();
            this.labelPeak = new System.Windows.Forms.Label();
            this.comboBoxPeak = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.txtClassScheduleID = new DevExpress.XtraEditors.TextEdit();
            this.labelInstructor = new System.Windows.Forms.Label();
            this.labelHallNumber = new System.Windows.Forms.Label();
            this.labelClassName = new System.Windows.Forms.Label();
            this.labelEndTime = new System.Windows.Forms.Label();
            this.labelStartTime = new System.Windows.Forms.Label();
            this.labelDay = new System.Windows.Forms.Label();
            this.labelBranch = new System.Windows.Forms.Label();
            this.labelClassLimit = new System.Windows.Forms.Label();
            this.textEditMaxNo = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkNoEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEndTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStartTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxCommisionType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxInstructor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxHallNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxClassName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxDay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxBranch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlFlagBox)).BeginInit();
            this.panelControlFlagBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditFAllowStudet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditFUOB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditFReserve.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditFFree.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxPeak.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClassScheduleID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditMaxNo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl1.Controls.Add(this.checkNoEnd);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.dtEnd);
            this.groupControl1.Controls.Add(this.labelPeriod);
            this.groupControl1.Controls.Add(this.dtStart);
            this.groupControl1.Controls.Add(this.dateEditEndTime);
            this.groupControl1.Controls.Add(this.dateEditStartTime);
            this.groupControl1.Controls.Add(this.btnClassScheduleDelete);
            this.groupControl1.Controls.Add(this.labelCommission);
            this.groupControl1.Controls.Add(this.comboBoxCommisionType);
            this.groupControl1.Controls.Add(this.comboBoxInstructor);
            this.groupControl1.Controls.Add(this.comboBoxHallNumber);
            this.groupControl1.Controls.Add(this.comboBoxClassName);
            this.groupControl1.Controls.Add(this.comboBoxDay);
            this.groupControl1.Controls.Add(this.comboBoxBranch);
            this.groupControl1.Controls.Add(this.btnClassScheduleCancel);
            this.groupControl1.Controls.Add(this.btnClassScheduleUpdate);
            this.groupControl1.Controls.Add(this.panelControlFlagBox);
            this.groupControl1.Controls.Add(this.labelInstructor);
            this.groupControl1.Controls.Add(this.labelHallNumber);
            this.groupControl1.Controls.Add(this.labelClassName);
            this.groupControl1.Controls.Add(this.labelEndTime);
            this.groupControl1.Controls.Add(this.labelStartTime);
            this.groupControl1.Controls.Add(this.labelDay);
            this.groupControl1.Controls.Add(this.labelBranch);
            this.groupControl1.Controls.Add(this.labelClassLimit);
            this.groupControl1.Controls.Add(this.textEditMaxNo);
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(560, 240);
            this.groupControl1.TabIndex = 53;
            this.groupControl1.Text = "Class Schedule Information .....";
            // 
            // checkNoEnd
            // 
            this.checkNoEnd.Location = new System.Drawing.Point(414, 13);
            this.checkNoEnd.Name = "checkNoEnd";
            this.checkNoEnd.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkNoEnd.Properties.Appearance.Options.UseFont = true;
            this.checkNoEnd.Properties.Caption = "No End";
            this.checkNoEnd.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.checkNoEnd.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.checkNoEnd.Size = new System.Drawing.Size(84, 21);
            this.checkNoEnd.TabIndex = 99;
            this.checkNoEnd.CheckedChanged += new System.EventHandler(this.checkNoEnd_CheckedChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(252, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 18);
            this.label1.TabIndex = 98;
            this.label1.Text = "to";
            // 
            // dtEnd
            // 
            this.dtEnd.EditValue = null;
            this.dtEnd.Location = new System.Drawing.Point(304, 13);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtEnd.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtEnd.Size = new System.Drawing.Size(104, 20);
            this.dtEnd.TabIndex = 97;
            // 
            // labelPeriod
            // 
            this.labelPeriod.BackColor = System.Drawing.SystemColors.Control;
            this.labelPeriod.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPeriod.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelPeriod.Location = new System.Drawing.Point(16, 15);
            this.labelPeriod.Name = "labelPeriod";
            this.labelPeriod.Size = new System.Drawing.Size(104, 16);
            this.labelPeriod.TabIndex = 96;
            this.labelPeriod.Text = "Period";
            // 
            // dtStart
            // 
            this.dtStart.EditValue = null;
            this.dtStart.Location = new System.Drawing.Point(128, 13);
            this.dtStart.Name = "dtStart";
            this.dtStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtStart.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtStart.Size = new System.Drawing.Size(104, 20);
            this.dtStart.TabIndex = 95;
            // 
            // dateEditEndTime
            // 
            this.dateEditEndTime.EditValue = null;
            this.dateEditEndTime.Location = new System.Drawing.Point(408, 60);
            this.dateEditEndTime.Name = "dateEditEndTime";
            this.dateEditEndTime.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dateEditEndTime.Properties.Appearance.Options.UseBackColor = true;
            this.dateEditEndTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEditEndTime.Properties.DisplayFormat.FormatString = "hh:mm:ss tt";
            this.dateEditEndTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dateEditEndTime.Size = new System.Drawing.Size(96, 20);
            this.dateEditEndTime.TabIndex = 94;
            // 
            // dateEditStartTime
            // 
            this.dateEditStartTime.EditValue = null;
            this.dateEditStartTime.Location = new System.Drawing.Point(128, 61);
            this.dateEditStartTime.Name = "dateEditStartTime";
            this.dateEditStartTime.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dateEditStartTime.Properties.Appearance.Options.UseBackColor = true;
            this.dateEditStartTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEditStartTime.Properties.DisplayFormat.FormatString = "hh:mm:ss tt";
            this.dateEditStartTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dateEditStartTime.Size = new System.Drawing.Size(104, 20);
            this.dateEditStartTime.TabIndex = 93;
            // 
            // btnClassScheduleDelete
            // 
            this.btnClassScheduleDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClassScheduleDelete.Appearance.Options.UseFont = true;
            this.btnClassScheduleDelete.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnClassScheduleDelete.Location = new System.Drawing.Point(96, 213);
            this.btnClassScheduleDelete.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnClassScheduleDelete.Name = "btnClassScheduleDelete";
            this.btnClassScheduleDelete.Size = new System.Drawing.Size(75, 23);
            this.btnClassScheduleDelete.TabIndex = 92;
            this.btnClassScheduleDelete.Text = "Delete";
            this.btnClassScheduleDelete.Click += new System.EventHandler(this.btnClassScheduleDelete_Click);
            // 
            // labelCommission
            // 
            this.labelCommission.BackColor = System.Drawing.SystemColors.Control;
            this.labelCommission.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCommission.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelCommission.Location = new System.Drawing.Point(16, 181);
            this.labelCommission.Name = "labelCommission";
            this.labelCommission.Size = new System.Drawing.Size(120, 16);
            this.labelCommission.TabIndex = 91;
            this.labelCommission.Text = "Commission Type";
            // 
            // comboBoxCommisionType
            // 
            this.comboBoxCommisionType.EditValue = "imageComboBoxEdit1";
            this.comboBoxCommisionType.Location = new System.Drawing.Point(144, 181);
            this.comboBoxCommisionType.Name = "comboBoxCommisionType";
            this.comboBoxCommisionType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxCommisionType.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.comboBoxCommisionType.Size = new System.Drawing.Size(120, 20);
            this.comboBoxCommisionType.TabIndex = 90;
            // 
            // comboBoxInstructor
            // 
            this.comboBoxInstructor.EditValue = "comboBoxInstructor";
            this.comboBoxInstructor.Location = new System.Drawing.Point(128, 157);
            this.comboBoxInstructor.Name = "comboBoxInstructor";
            this.comboBoxInstructor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxInstructor.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.comboBoxInstructor.Size = new System.Drawing.Size(136, 20);
            this.comboBoxInstructor.TabIndex = 87;
            // 
            // comboBoxHallNumber
            // 
            this.comboBoxHallNumber.EditValue = "1";
            this.comboBoxHallNumber.Location = new System.Drawing.Point(128, 133);
            this.comboBoxHallNumber.Name = "comboBoxHallNumber";
            this.comboBoxHallNumber.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.comboBoxHallNumber.Properties.Appearance.Options.UseBackColor = true;
            this.comboBoxHallNumber.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxHallNumber.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Hall 1", 1, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Hall 2", 2, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Hall 3", 3, -1)});
            this.comboBoxHallNumber.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.comboBoxHallNumber.Size = new System.Drawing.Size(136, 20);
            this.comboBoxHallNumber.TabIndex = 86;
            // 
            // comboBoxClassName
            // 
            this.comboBoxClassName.EditValue = "imageComboBoxEdit1";
            this.comboBoxClassName.Location = new System.Drawing.Point(128, 109);
            this.comboBoxClassName.Name = "comboBoxClassName";
            this.comboBoxClassName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxClassName.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.comboBoxClassName.Size = new System.Drawing.Size(136, 20);
            this.comboBoxClassName.TabIndex = 85;
            // 
            // comboBoxDay
            // 
            this.comboBoxDay.EditValue = "imageComboBoxEdit1";
            this.comboBoxDay.Location = new System.Drawing.Point(128, 37);
            this.comboBoxDay.Name = "comboBoxDay";
            this.comboBoxDay.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.comboBoxDay.Properties.Appearance.Options.UseBackColor = true;
            this.comboBoxDay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxDay.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("SUNDAY", 0, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("MONDAY", 1, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("TUESDAY", 2, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("WEDNERSDAY", 3, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("THURSDAY", 4, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("FRIDAY", 5, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("SATURDAY", 6, -1)});
            this.comboBoxDay.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.comboBoxDay.Size = new System.Drawing.Size(104, 20);
            this.comboBoxDay.TabIndex = 84;
            // 
            // comboBoxBranch
            // 
            this.comboBoxBranch.EditValue = "imageComboBoxEdit1";
            this.comboBoxBranch.Location = new System.Drawing.Point(128, 85);
            this.comboBoxBranch.Name = "comboBoxBranch";
            this.comboBoxBranch.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.comboBoxBranch.Properties.Appearance.Options.UseBackColor = true;
            this.comboBoxBranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxBranch.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.comboBoxBranch.Size = new System.Drawing.Size(136, 20);
            this.comboBoxBranch.TabIndex = 83;
            // 
            // btnClassScheduleCancel
            // 
            this.btnClassScheduleCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClassScheduleCancel.Appearance.Options.UseFont = true;
            this.btnClassScheduleCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnClassScheduleCancel.Location = new System.Drawing.Point(176, 213);
            this.btnClassScheduleCancel.Name = "btnClassScheduleCancel";
            this.btnClassScheduleCancel.Size = new System.Drawing.Size(75, 23);
            this.btnClassScheduleCancel.TabIndex = 82;
            this.btnClassScheduleCancel.Text = "Cancel";
            this.btnClassScheduleCancel.Click += new System.EventHandler(this.btnClassScheduleCancel_Click);
            // 
            // btnClassScheduleUpdate
            // 
            this.btnClassScheduleUpdate.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClassScheduleUpdate.Appearance.Options.UseFont = true;
            this.btnClassScheduleUpdate.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnClassScheduleUpdate.Location = new System.Drawing.Point(16, 213);
            this.btnClassScheduleUpdate.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnClassScheduleUpdate.Name = "btnClassScheduleUpdate";
            this.btnClassScheduleUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnClassScheduleUpdate.TabIndex = 81;
            this.btnClassScheduleUpdate.Text = "Save";
            this.btnClassScheduleUpdate.Click += new System.EventHandler(this.btnClassScheduleUpdate_Click);
            // 
            // panelControlFlagBox
            // 
            this.panelControlFlagBox.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelControlFlagBox.Appearance.Options.UseBackColor = true;
            this.panelControlFlagBox.Controls.Add(this.checkEditFAllowStudet);
            this.panelControlFlagBox.Controls.Add(this.checkEditFUOB);
            this.panelControlFlagBox.Controls.Add(this.checkEditFReserve);
            this.panelControlFlagBox.Controls.Add(this.checkEditFFree);
            this.panelControlFlagBox.Controls.Add(this.labelPeak);
            this.panelControlFlagBox.Controls.Add(this.comboBoxPeak);
            this.panelControlFlagBox.Controls.Add(this.txtClassScheduleID);
            this.panelControlFlagBox.Location = new System.Drawing.Point(304, 84);
            this.panelControlFlagBox.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.panelControlFlagBox.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControlFlagBox.Name = "panelControlFlagBox";
            this.panelControlFlagBox.Size = new System.Drawing.Size(248, 152);
            this.panelControlFlagBox.TabIndex = 78;
            // 
            // checkEditFAllowStudet
            // 
            this.checkEditFAllowStudet.Location = new System.Drawing.Point(14, 114);
            this.checkEditFAllowStudet.Name = "checkEditFAllowStudet";
            this.checkEditFAllowStudet.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkEditFAllowStudet.Properties.Appearance.Options.UseFont = true;
            this.checkEditFAllowStudet.Properties.Caption = "If allow student on Peak Hour";
            this.checkEditFAllowStudet.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.checkEditFAllowStudet.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.checkEditFAllowStudet.Size = new System.Drawing.Size(224, 21);
            this.checkEditFAllowStudet.TabIndex = 53;
            // 
            // checkEditFUOB
            // 
            this.checkEditFUOB.Location = new System.Drawing.Point(13, 89);
            this.checkEditFUOB.Name = "checkEditFUOB";
            this.checkEditFUOB.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkEditFUOB.Properties.Appearance.Options.UseFont = true;
            this.checkEditFUOB.Properties.Caption = "If allow UOB booking";
            this.checkEditFUOB.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.checkEditFUOB.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.checkEditFUOB.Size = new System.Drawing.Size(201, 21);
            this.checkEditFUOB.TabIndex = 52;
            // 
            // checkEditFReserve
            // 
            this.checkEditFReserve.Location = new System.Drawing.Point(13, 65);
            this.checkEditFReserve.Name = "checkEditFReserve";
            this.checkEditFReserve.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkEditFReserve.Properties.Appearance.Options.UseFont = true;
            this.checkEditFReserve.Properties.Caption = "If requires reservation";
            this.checkEditFReserve.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.checkEditFReserve.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.checkEditFReserve.Size = new System.Drawing.Size(201, 21);
            this.checkEditFReserve.TabIndex = 51;
            // 
            // checkEditFFree
            // 
            this.checkEditFFree.Location = new System.Drawing.Point(13, 41);
            this.checkEditFFree.Name = "checkEditFFree";
            this.checkEditFFree.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkEditFFree.Properties.Appearance.Options.UseFont = true;
            this.checkEditFFree.Properties.Caption = "If a free class";
            this.checkEditFFree.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.checkEditFFree.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.checkEditFFree.Size = new System.Drawing.Size(201, 21);
            this.checkEditFFree.TabIndex = 50;
            // 
            // labelPeak
            // 
            this.labelPeak.BackColor = System.Drawing.SystemColors.Control;
            this.labelPeak.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPeak.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelPeak.Location = new System.Drawing.Point(13, 17);
            this.labelPeak.Name = "labelPeak";
            this.labelPeak.Size = new System.Drawing.Size(100, 16);
            this.labelPeak.TabIndex = 49;
            this.labelPeak.Text = "Peak Period? ";
            // 
            // comboBoxPeak
            // 
            this.comboBoxPeak.EditValue = "-1";
            this.comboBoxPeak.Location = new System.Drawing.Point(113, 17);
            this.comboBoxPeak.Name = "comboBoxPeak";
            this.comboBoxPeak.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.comboBoxPeak.Properties.Appearance.Options.UseBackColor = true;
            this.comboBoxPeak.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxPeak.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Normal", -1, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Peak", 1, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Non Peak", 0, -1)});
            this.comboBoxPeak.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.comboBoxPeak.Size = new System.Drawing.Size(86, 20);
            this.comboBoxPeak.TabIndex = 49;
            // 
            // txtClassScheduleID
            // 
            this.txtClassScheduleID.EditValue = "0";
            this.txtClassScheduleID.Location = new System.Drawing.Point(72, 56);
            this.txtClassScheduleID.Name = "txtClassScheduleID";
            this.txtClassScheduleID.Size = new System.Drawing.Size(160, 20);
            this.txtClassScheduleID.TabIndex = 95;
            this.txtClassScheduleID.Visible = false;
            // 
            // labelInstructor
            // 
            this.labelInstructor.BackColor = System.Drawing.SystemColors.Control;
            this.labelInstructor.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInstructor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelInstructor.Location = new System.Drawing.Point(16, 157);
            this.labelInstructor.Name = "labelInstructor";
            this.labelInstructor.Size = new System.Drawing.Size(104, 16);
            this.labelInstructor.TabIndex = 77;
            this.labelInstructor.Text = "Instructor ";
            // 
            // labelHallNumber
            // 
            this.labelHallNumber.BackColor = System.Drawing.SystemColors.Control;
            this.labelHallNumber.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHallNumber.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelHallNumber.Location = new System.Drawing.Point(16, 133);
            this.labelHallNumber.Name = "labelHallNumber";
            this.labelHallNumber.Size = new System.Drawing.Size(104, 16);
            this.labelHallNumber.TabIndex = 76;
            this.labelHallNumber.Text = "Hall Number";
            // 
            // labelClassName
            // 
            this.labelClassName.BackColor = System.Drawing.SystemColors.Control;
            this.labelClassName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClassName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelClassName.Location = new System.Drawing.Point(16, 109);
            this.labelClassName.Name = "labelClassName";
            this.labelClassName.Size = new System.Drawing.Size(104, 16);
            this.labelClassName.TabIndex = 75;
            this.labelClassName.Text = "Class Name";
            // 
            // labelEndTime
            // 
            this.labelEndTime.BackColor = System.Drawing.SystemColors.Control;
            this.labelEndTime.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEndTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelEndTime.Location = new System.Drawing.Point(304, 60);
            this.labelEndTime.Name = "labelEndTime";
            this.labelEndTime.Size = new System.Drawing.Size(104, 16);
            this.labelEndTime.TabIndex = 74;
            this.labelEndTime.Text = "End Time";
            // 
            // labelStartTime
            // 
            this.labelStartTime.BackColor = System.Drawing.SystemColors.Control;
            this.labelStartTime.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStartTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelStartTime.Location = new System.Drawing.Point(16, 61);
            this.labelStartTime.Name = "labelStartTime";
            this.labelStartTime.Size = new System.Drawing.Size(104, 16);
            this.labelStartTime.TabIndex = 73;
            this.labelStartTime.Text = "Start Time";
            // 
            // labelDay
            // 
            this.labelDay.BackColor = System.Drawing.SystemColors.Control;
            this.labelDay.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDay.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelDay.Location = new System.Drawing.Point(16, 37);
            this.labelDay.Name = "labelDay";
            this.labelDay.Size = new System.Drawing.Size(104, 16);
            this.labelDay.TabIndex = 72;
            this.labelDay.Text = "Day";
            // 
            // labelBranch
            // 
            this.labelBranch.BackColor = System.Drawing.SystemColors.Control;
            this.labelBranch.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBranch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelBranch.Location = new System.Drawing.Point(16, 85);
            this.labelBranch.Name = "labelBranch";
            this.labelBranch.Size = new System.Drawing.Size(96, 16);
            this.labelBranch.TabIndex = 71;
            this.labelBranch.Text = "Branch";
            // 
            // labelClassLimit
            // 
            this.labelClassLimit.BackColor = System.Drawing.SystemColors.Control;
            this.labelClassLimit.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClassLimit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelClassLimit.Location = new System.Drawing.Point(304, 36);
            this.labelClassLimit.Name = "labelClassLimit";
            this.labelClassLimit.Size = new System.Drawing.Size(96, 16);
            this.labelClassLimit.TabIndex = 80;
            this.labelClassLimit.Text = "Class Limit";
            // 
            // textEditMaxNo
            // 
            this.textEditMaxNo.EditValue = "0";
            this.textEditMaxNo.Location = new System.Drawing.Point(408, 36);
            this.textEditMaxNo.Name = "textEditMaxNo";
            this.textEditMaxNo.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.textEditMaxNo.Properties.Mask.EditMask = "f";
            this.textEditMaxNo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textEditMaxNo.Size = new System.Drawing.Size(96, 20);
            this.textEditMaxNo.TabIndex = 79;
            // 
            // frmClassSchedule
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(1, 4);
            this.ClientSize = new System.Drawing.Size(562, 247);
            this.Controls.Add(this.groupControl1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Document, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmClassSchedule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Class Schedule Information";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkNoEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEndTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStartTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxCommisionType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxInstructor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxHallNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxClassName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxDay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxBranch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlFlagBox)).EndInit();
            this.panelControlFlagBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkEditFAllowStudet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditFUOB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditFReserve.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditFFree.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxPeak.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClassScheduleID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditMaxNo.Properties)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void btnClassScheduleCancel_Click(object sender, System.EventArgs e)
		{
			this.Dispose(true);
		}

		
		private void init()
		{
			string strSQL;

			strSQL = "select * from tblBranch where nBrStatusID=1";
			comboBind(comboBoxBranch,strSQL,"strBranchName","strBranchCode");

			strSQL = "select * from tblClass";
			comboBind(comboBoxClassName,strSQL,"strDescription","strClassCode");

			strSQL = "select * from tblEmployee where nStatusID = 1 and (fInstructor=1 or fPtInstructor=1) Order By strEmployeeName";
			comboBind(comboBoxInstructor,strSQL,"strEmployeeName","nEmployeeID",true);

			strSQL = "select * from tblInstructorCommission";
			comboBind(comboBoxCommisionType,strSQL,"strDescription","nCommissionTypeID",true);

			
		}


		private void bind()
		{
			//MessageBox.Show(this.ClassSchedule.Rows[1].ToString());
			this.comboBoxBranch.DataBindings.Add("EditValue",this.ClassSchedule,"strBranchCode");
			this.comboBoxDay.DataBindings.Add("EditValue",this.ClassSchedule,"nDay");
			this.dateEditStartTime.DataBindings.Add("EditValue",this.ClassSchedule,"dtStartTime");
			this.dateEditEndTime.DataBindings.Add("EditValue",this.ClassSchedule,"dtEndTime");
			this.comboBoxClassName.DataBindings.Add("EditValue",this.ClassSchedule,"strClassCode");
			this.comboBoxHallNumber.DataBindings.Add("EditValue",this.ClassSchedule,"nHallNo");
            this.comboBoxPeak.DataBindings.Add("EditValue", this.ClassSchedule, "fPeak");
			this.comboBoxInstructor.DataBindings.Add("EditValue",this.ClassSchedule,"nInstructorID");
			this.checkEditFFree.DataBindings.Add("EditValue",this.ClassSchedule,"fFree");			
			this.checkEditFReserve.DataBindings.Add("EditValue",this.ClassSchedule,"fReservation");
			this.checkEditFUOB.DataBindings.Add("EditValue",this.ClassSchedule,"fAllowUOBBooking");
			this.textEditMaxNo.DataBindings.Add("EditValue",this.ClassSchedule,"nMaxNo");
			this.txtClassScheduleID.DataBindings.Add("EditValue",this.ClassSchedule,"nClassScheduleID");
            
            this.dtStart.DataBindings.Add("EditValue", this.ClassSchedule, "dtStartDate");
            this.dtEnd.DataBindings.Add("EditValue", this.ClassSchedule, "dtEndDate");
            if (ClassSchedule.Rows[0]["dtEndDate"] == DBNull.Value)
                checkNoEnd.Checked = true;
		}

		private void btnClassScheduleUpdate_Click(object sender, System.EventArgs e)
		{
			int output;
			output = 0;

			if ( this.command == 'I')
			{
				SqlHelper.ExecuteNonQuery(connection,"UP_tblClassSchedule",
					new SqlParameter("@RET_VAL",output),
					new SqlParameter("@cmd","I"),
					new SqlParameter("@strBranchCode",this.comboBoxBranch.EditValue.ToString() ),
					new SqlParameter("@nDay",Convert.ToInt32(this.comboBoxDay.EditValue) ),
					new SqlParameter("@dtStartTime",Convert.ToDateTime(this.dateEditStartTime.EditValue).ToString("hh:mm:ss tt") ),
					new SqlParameter("@dtEndTime",Convert.ToDateTime(this.dateEditEndTime.EditValue).ToString("hh:mm:ss tt") ),
					new SqlParameter("@strClassCode",this.comboBoxClassName.EditValue.ToString() ),
					new SqlParameter("@nHallNo",Convert.ToInt32(this.comboBoxHallNumber.EditValue) ),
					new SqlParameter("@nInstructorID",Convert.ToInt32(this.comboBoxInstructor.EditValue) ),
					new SqlParameter("@fFree",Convert.ToBoolean(this.checkEditFFree.EditValue) ),
					new SqlParameter("@fPeak",Convert.ToInt32(this.comboBoxPeak.EditValue) ),
					new SqlParameter("@fAllowStudentOnPeak",Convert.ToBoolean(this.checkEditFAllowStudet.EditValue) ),
					new SqlParameter("@fReservation",Convert.ToBoolean(this.checkEditFReserve.EditValue) ),
					new SqlParameter("@nMaxNo",Convert.ToInt32(this.textEditMaxNo.EditValue) ),
					new SqlParameter("@fAllowUOBBooking",Convert.ToBoolean(this.checkEditFUOB.EditValue) ),
					new SqlParameter("@nCommissionTypeID",1 ),
                    new SqlParameter("@dtStartDate", Convert.ToDateTime(this.dtStart.EditValue)),
                    new SqlParameter("@dtEndDate", (checkNoEnd.EditValue.ToString() == "True") ? SqlDateTime.Null : Convert.ToDateTime(this.dtEnd.EditValue)),
					new SqlParameter("@nClassScheduleID",0)

					);
			}
			else
			{
                /* ======Updated by Albert======Fthis.btnClassScheduleUpdate.Click += new System.EventHandler(this.btnClassScheduleUpdate_Click);
                 * 
                 * To update the class, need nClassScheduleID.
                 * And convert all the start and end time values to formatted string.
                 * */
				foreach(DataRow dr in this.ClassSchedule.Rows)
					txtClassScheduleID.EditValue = dr["nClassScheduleID"];

				SqlHelper.ExecuteNonQuery(connection,"UP_tblClassSchedule",
					new SqlParameter("@RET_VAL",output),
					new SqlParameter("@cmd","U"),
					new SqlParameter("@strBranchCode",this.comboBoxBranch.EditValue.ToString() ),
					new SqlParameter("@nDay",Convert.ToInt32(this.comboBoxDay.EditValue) ),
					new SqlParameter("@dtStartTime",Convert.ToDateTime(this.dateEditStartTime.EditValue).ToString("hh:mm:ss tt") ),
					new SqlParameter("@dtEndTime",Convert.ToDateTime(this.dateEditEndTime.EditValue).ToString("hh:mm:ss tt") ),
					new SqlParameter("@strClassCode",this.comboBoxClassName.EditValue.ToString() ),
					new SqlParameter("@nHallNo",Convert.ToInt32(this.comboBoxHallNumber.EditValue) ),
					new SqlParameter("@nInstructorID",Convert.ToInt32(this.comboBoxInstructor.EditValue) ),
					new SqlParameter("@fFree",Convert.ToBoolean(this.checkEditFFree.EditValue) ),
                    new SqlParameter("@fPeak",Convert.ToInt32(this.comboBoxPeak.EditValue)),
					new SqlParameter("@fAllowStudentOnPeak",Convert.ToBoolean(this.checkEditFAllowStudet.EditValue) ),
					new SqlParameter("@fReservation",Convert.ToBoolean(this.checkEditFReserve.EditValue) ),
					new SqlParameter("@nMaxNo",Convert.ToInt32(this.textEditMaxNo.EditValue) ),
					new SqlParameter("@fAllowUOBBooking",Convert.ToBoolean(this.checkEditFUOB.EditValue) ),
					new SqlParameter("@nCommissionTypeID",1 ),
                    new SqlParameter("@dtStartDate", Convert.ToDateTime(this.dtStart.EditValue)),
                    new SqlParameter("@dtEndDate", (checkNoEnd.EditValue.ToString()=="True") ? SqlDateTime.Null : Convert.ToDateTime(this.dtEnd.EditValue)),
					new SqlParameter("@nClassScheduleID", Convert.ToInt32(this.txtClassScheduleID.EditValue))
                     
					);
			}
			System.DayOfWeek dayOfWeek = ACMSLogic.ClassAttendance.ConvertNDayToDayOfWeek(Convert.ToInt32(this.comboBoxDay.EditValue));

			//ACMSLogic.ClassAttendance.CreateClassInstance(dayOfWeek);

			this.Dispose(true);
			
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

        private void btnClassScheduleDelete_Click(object sender, System.EventArgs e)
        {
            int output;
            output = 0;

            foreach (DataRow dr in this.ClassSchedule.Rows)
                txtClassScheduleID.EditValue = dr["nClassScheduleID"];

            SqlHelper.ExecuteNonQuery(connection, "UP_tblClassSchedule",
                new SqlParameter("@RET_VAL", output),
                new SqlParameter("@cmd", "D"),
                new SqlParameter("@strBranchCode", this.comboBoxBranch.EditValue.ToString()),
                new SqlParameter("@nDay", Convert.ToInt32(this.comboBoxDay.EditValue)),
                new SqlParameter("@dtStartTime", Convert.ToDateTime(this.dateEditStartTime.EditValue)),
                new SqlParameter("@dtEndTime", Convert.ToDateTime(this.dateEditEndTime.EditValue)),
                new SqlParameter("@strClassCode", this.comboBoxClassName.EditValue.ToString()),
                new SqlParameter("@nHallNo", Convert.ToInt32(this.comboBoxHallNumber.EditValue)),
                new SqlParameter("@nInstructorID", Convert.ToInt32(this.comboBoxInstructor.EditValue)),
                new SqlParameter("@fFree", Convert.ToBoolean(this.checkEditFFree.EditValue)),
                new SqlParameter("@fPeak", Convert.ToInt32(this.comboBoxPeak.EditValue)),
                new SqlParameter("@fAllowStudentOnPeak", Convert.ToBoolean(this.checkEditFAllowStudet.EditValue)),
                new SqlParameter("@fReservation", Convert.ToBoolean(this.checkEditFReserve.EditValue)),
                new SqlParameter("@nMaxNo", Convert.ToInt32(this.textEditMaxNo.EditValue)),
                new SqlParameter("@fAllowUOBBooking", Convert.ToBoolean(this.checkEditFUOB.EditValue)),
                new SqlParameter("@nCommissionTypeID", 1),
                new SqlParameter("@dtStartDate", Convert.ToDateTime(this.dtStart.EditValue)),
                new SqlParameter("@dtEndDate", (checkNoEnd.EditValue.ToString() == "True") ? SqlDateTime.Null : Convert.ToDateTime(this.dtEnd.EditValue)),
                new SqlParameter("@nClassScheduleID", Convert.ToInt32(this.txtClassScheduleID.EditValue))
                );




            this.Dispose(true);

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

        private void checkNoEnd_CheckedChanged(object sender, EventArgs e)
        {
            if (checkNoEnd.Checked)
                dtEnd.Enabled = false;
            else
                dtEnd.Enabled = true;
        }

    }
}
