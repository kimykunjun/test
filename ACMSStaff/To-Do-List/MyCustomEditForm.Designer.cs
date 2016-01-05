namespace ACMS.ACMSStaff.To_Do_List
{
    partial class MyCustomEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyCustomEditForm));
            this.timeEnd = new DevExpress.XtraEditors.TimeEdit();
            this.timeStart = new DevExpress.XtraEditors.TimeEdit();
            this.dtEnd = new DevExpress.XtraEditors.DateEdit();
            this.dtStart = new DevExpress.XtraEditors.DateEdit();
            this.txCustomStatus = new DevExpress.XtraEditors.TextEdit();
            this.txCustomName = new DevExpress.XtraEditors.TextEdit();
            this.lblCustomStatus = new System.Windows.Forms.Label();
            this.lblCustomName = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.lblLabel = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.edStatus = new DevExpress.XtraScheduler.UI.AppointmentStatusEdit();
            this.edLabel = new DevExpress.XtraScheduler.UI.AppointmentLabelEdit();
            this.txSubject = new DevExpress.XtraEditors.TextEdit();
            this.lblSubject = new System.Windows.Forms.Label();
            this.btnReccurrence = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.checkAllDay = new DevExpress.XtraEditors.CheckEdit();
            this.tblDeliveryScheduleTableAdapter = new ACMS.ACMSDataSetTableAdapters.TblDeliveryScheduleTableAdapter();
            this.aCMSDataSet = new ACMS.ACMSDataSet();
            this.tblDeliveryScheduleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.appointmentStatusEdit1 = new DevExpress.XtraScheduler.UI.AppointmentStatusEdit();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.lookUpEdit4 = new DevExpress.XtraEditors.LookUpEdit();
            this.label40 = new System.Windows.Forms.Label();
            this.lookUpEdit3 = new DevExpress.XtraEditors.LookUpEdit();
            this.label39 = new System.Windows.Forms.Label();
            this.lookUpEdit2 = new DevExpress.XtraEditors.LookUpEdit();
            this.label38 = new System.Windows.Forms.Label();
            this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
            this.label28 = new System.Windows.Forms.Label();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.memoEdit2 = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.timeEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txCustomStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txCustomName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edLabel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txSubject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkAllDay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aCMSDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDeliveryScheduleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentStatusEdit1.Properties)).BeginInit();
            this.xtraTabPage3.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timeEnd
            // 
            this.timeEnd.EditValue = new System.DateTime(2006, 3, 28, 0, 0, 0, 0);
            this.timeEnd.Location = new System.Drawing.Point(212, 81);
            this.timeEnd.Name = "timeEnd";
            this.timeEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.timeEnd.Size = new System.Drawing.Size(80, 20);
            this.timeEnd.TabIndex = 22;
            this.timeEnd.EditValueChanged += new System.EventHandler(this.timeEnd_EditValueChanged);
            // 
            // timeStart
            // 
            this.timeStart.EditValue = new System.DateTime(2006, 3, 28, 0, 0, 0, 0);
            this.timeStart.Location = new System.Drawing.Point(212, 57);
            this.timeStart.Name = "timeStart";
            this.timeStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.timeStart.Size = new System.Drawing.Size(80, 20);
            this.timeStart.TabIndex = 19;
            this.timeStart.EditValueChanged += new System.EventHandler(this.timeStart_EditValueChanged);
            // 
            // dtEnd
            // 
            this.dtEnd.EditValue = new System.DateTime(2005, 11, 25, 0, 0, 0, 0);
            this.dtEnd.Location = new System.Drawing.Point(100, 81);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtEnd.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtEnd.Size = new System.Drawing.Size(96, 20);
            this.dtEnd.TabIndex = 20;
            this.dtEnd.EditValueChanged += new System.EventHandler(this.dtEnd_EditValueChanged);
            // 
            // dtStart
            // 
            this.dtStart.EditValue = new System.DateTime(2005, 11, 25, 0, 0, 0, 0);
            this.dtStart.Location = new System.Drawing.Point(100, 57);
            this.dtStart.Name = "dtStart";
            this.dtStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtStart.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtStart.Size = new System.Drawing.Size(96, 20);
            this.dtStart.TabIndex = 18;
            this.dtStart.EditValueChanged += new System.EventHandler(this.dtStart_EditValueChanged);
            // 
            // txCustomStatus
            // 
            this.txCustomStatus.EditValue = "";
            this.txCustomStatus.Location = new System.Drawing.Point(440, 84);
            this.txCustomStatus.Name = "txCustomStatus";
            this.txCustomStatus.Size = new System.Drawing.Size(192, 20);
            this.txCustomStatus.TabIndex = 26;
            this.txCustomStatus.EditValueChanged += new System.EventHandler(this.txCustomStatus_EditValueChanged);
            // 
            // txCustomName
            // 
            this.txCustomName.EditValue = "";
            this.txCustomName.Location = new System.Drawing.Point(440, 60);
            this.txCustomName.Name = "txCustomName";
            this.txCustomName.Size = new System.Drawing.Size(192, 20);
            this.txCustomName.TabIndex = 25;
            this.txCustomName.EditValueChanged += new System.EventHandler(this.txCustomName_EditValueChanged);
            // 
            // lblCustomStatus
            // 
            this.lblCustomStatus.Location = new System.Drawing.Point(352, 84);
            this.lblCustomStatus.Name = "lblCustomStatus";
            this.lblCustomStatus.Size = new System.Drawing.Size(80, 19);
            this.lblCustomStatus.TabIndex = 35;
            this.lblCustomStatus.Text = "Remark :";
            this.lblCustomStatus.Click += new System.EventHandler(this.lblCustomStatus_Click);
            // 
            // lblCustomName
            // 
            this.lblCustomName.Location = new System.Drawing.Point(352, 60);
            this.lblCustomName.Name = "lblCustomName";
            this.lblCustomName.Size = new System.Drawing.Size(80, 19);
            this.lblCustomName.TabIndex = 34;
            this.lblCustomName.Text = "Description :";
            this.lblCustomName.Click += new System.EventHandler(this.lblCustomName_Click);
            // 
            // lblEnd
            // 
            this.lblEnd.Location = new System.Drawing.Point(12, 82);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(48, 18);
            this.lblEnd.TabIndex = 33;
            this.lblEnd.Text = "End:";
            this.lblEnd.Click += new System.EventHandler(this.lblEnd_Click);
            // 
            // lblStart
            // 
            this.lblStart.Location = new System.Drawing.Point(12, 58);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(56, 18);
            this.lblStart.TabIndex = 32;
            this.lblStart.Text = "Start:";
            this.lblStart.Click += new System.EventHandler(this.lblStart_Click);
            // 
            // lblLabel
            // 
            this.lblLabel.Location = new System.Drawing.Point(352, 34);
            this.lblLabel.Name = "lblLabel";
            this.lblLabel.Size = new System.Drawing.Size(83, 19);
            this.lblLabel.TabIndex = 30;
            this.lblLabel.Text = "In Charged By :";
            this.lblLabel.Click += new System.EventHandler(this.lblLabel_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(352, 4);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(48, 18);
            this.lblStatus.TabIndex = 27;
            this.lblStatus.Text = "Status:";
            this.lblStatus.Click += new System.EventHandler(this.lblStatus_Click);
            // 
            // edStatus
            // 
            this.edStatus.Location = new System.Drawing.Point(440, 4);
            this.edStatus.Name = "edStatus";
            this.edStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edStatus.Size = new System.Drawing.Size(192, 20);
            this.edStatus.TabIndex = 23;
            this.edStatus.SelectedIndexChanged += new System.EventHandler(this.edStatus_SelectedIndexChanged);
            // 
            // edLabel
            // 
            this.edLabel.Location = new System.Drawing.Point(473, 129);
            this.edLabel.Name = "edLabel";
            this.edLabel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edLabel.Size = new System.Drawing.Size(192, 20);
            this.edLabel.TabIndex = 24;
            this.edLabel.Visible = false;
            this.edLabel.SelectedIndexChanged += new System.EventHandler(this.edLabel_SelectedIndexChanged);
            // 
            // txSubject
            // 
            this.txSubject.EditValue = "";
            this.txSubject.Location = new System.Drawing.Point(100, 6);
            this.txSubject.Name = "txSubject";
            this.txSubject.Size = new System.Drawing.Size(192, 20);
            this.txSubject.TabIndex = 17;
            this.txSubject.EditValueChanged += new System.EventHandler(this.txSubject_EditValueChanged);
            // 
            // lblSubject
            // 
            this.lblSubject.Location = new System.Drawing.Point(12, 7);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(48, 18);
            this.lblSubject.TabIndex = 21;
            this.lblSubject.Text = "Subject:";
            this.lblSubject.Click += new System.EventHandler(this.lblSubject_Click);
            // 
            // btnReccurrence
            // 
            this.btnReccurrence.Location = new System.Drawing.Point(387, 122);
            this.btnReccurrence.Name = "btnReccurrence";
            this.btnReccurrence.Size = new System.Drawing.Size(80, 27);
            this.btnReccurrence.TabIndex = 31;
            this.btnReccurrence.Text = "Recurrence";
            this.btnReccurrence.Click += new System.EventHandler(this.btnReccurrence_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(292, 122);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 27);
            this.btnCancel.TabIndex = 29;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(195, 122);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 27);
            this.btnOK.TabIndex = 28;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // checkAllDay
            // 
            this.checkAllDay.Location = new System.Drawing.Point(100, 108);
            this.checkAllDay.Name = "checkAllDay";
            this.checkAllDay.Properties.Caption = "All day";
            this.checkAllDay.Size = new System.Drawing.Size(75, 19);
            this.checkAllDay.TabIndex = 36;
            this.checkAllDay.CheckedChanged += new System.EventHandler(this.checkAllDay_CheckedChanged_1);
            // 
            // tblDeliveryScheduleTableAdapter
            // 
            this.tblDeliveryScheduleTableAdapter.ClearBeforeFill = true;
            // 
            // aCMSDataSet
            // 
            this.aCMSDataSet.DataSetName = "ACMSDataSet";
            this.aCMSDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblDeliveryScheduleBindingSource
            // 
            this.tblDeliveryScheduleBindingSource.DataMember = "TblDeliverySchedule";
            this.tblDeliveryScheduleBindingSource.DataSource = this.aCMSDataSet;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 18);
            this.label1.TabIndex = 37;
            this.label1.Text = "Task :";
            // 
            // appointmentStatusEdit1
            // 
            this.appointmentStatusEdit1.Location = new System.Drawing.Point(4, 129);
            this.appointmentStatusEdit1.Name = "appointmentStatusEdit1";
            this.appointmentStatusEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.appointmentStatusEdit1.Size = new System.Drawing.Size(192, 20);
            this.appointmentStatusEdit1.TabIndex = 38;
            this.appointmentStatusEdit1.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Previous Road Show Cost",
            "Prepare Payment for Suppier"});
            this.comboBox1.Location = new System.Drawing.Point(100, 31);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(192, 21);
            this.comboBox1.TabIndex = 39;
            this.comboBox1.Text = "Previous Road Show Cost";
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Controls.Add(this.label2);
            this.xtraTabPage3.Controls.Add(this.button1);
            this.xtraTabPage3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.xtraTabPage3.Image = ((System.Drawing.Image)(resources.GetObject("xtraTabPage3.Image")));
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(724, 267);
            this.xtraTabPage3.Text = "Video";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(391, 34);
            this.label2.TabIndex = 34;
            this.label2.Text = "Demo Video to show you step by step";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(27, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(179, 42);
            this.button1.TabIndex = 0;
            this.button1.Text = "Play";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.lookUpEdit4);
            this.xtraTabPage2.Controls.Add(this.label40);
            this.xtraTabPage2.Controls.Add(this.lookUpEdit3);
            this.xtraTabPage2.Controls.Add(this.label39);
            this.xtraTabPage2.Controls.Add(this.lookUpEdit2);
            this.xtraTabPage2.Controls.Add(this.label38);
            this.xtraTabPage2.Controls.Add(this.lookUpEdit1);
            this.xtraTabPage2.Controls.Add(this.label28);
            this.xtraTabPage2.Image = ((System.Drawing.Image)(resources.GetObject("xtraTabPage2.Image")));
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(724, 267);
            this.xtraTabPage2.Text = "Attachment";
            // 
            // lookUpEdit4
            // 
            this.lookUpEdit4.Location = new System.Drawing.Point(100, 39);
            this.lookUpEdit4.Name = "lookUpEdit4";
            this.lookUpEdit4.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit4.Size = new System.Drawing.Size(139, 20);
            this.lookUpEdit4.TabIndex = 7;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(19, 43);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(63, 13);
            this.label40.TabIndex = 6;
            this.label40.Text = "Attachment";
            // 
            // lookUpEdit3
            // 
            this.lookUpEdit3.Location = new System.Drawing.Point(100, 70);
            this.lookUpEdit3.Name = "lookUpEdit3";
            this.lookUpEdit3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit3.Size = new System.Drawing.Size(139, 20);
            this.lookUpEdit3.TabIndex = 5;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(19, 77);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(63, 13);
            this.label39.TabIndex = 4;
            this.label39.Text = "Attachment";
            // 
            // lookUpEdit2
            // 
            this.lookUpEdit2.Location = new System.Drawing.Point(100, 106);
            this.lookUpEdit2.Name = "lookUpEdit2";
            this.lookUpEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit2.Size = new System.Drawing.Size(139, 20);
            this.lookUpEdit2.TabIndex = 3;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(19, 110);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(63, 13);
            this.label38.TabIndex = 2;
            this.label38.Text = "Attachment";
            // 
            // lookUpEdit1
            // 
            this.lookUpEdit1.Location = new System.Drawing.Point(100, 10);
            this.lookUpEdit1.Name = "lookUpEdit1";
            this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit1.Size = new System.Drawing.Size(139, 20);
            this.lookUpEdit1.TabIndex = 1;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(19, 14);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(63, 13);
            this.label28.TabIndex = 0;
            this.label28.Text = "Attachment";
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.memoEdit2);
            this.xtraTabPage1.Controls.Add(this.labelControl1);
            this.xtraTabPage1.Image = ((System.Drawing.Image)(resources.GetObject("xtraTabPage1.Image")));
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(724, 267);
            this.xtraTabPage1.Text = "Detail";
            // 
            // memoEdit2
            // 
            this.memoEdit2.EditValue = "";
            this.memoEdit2.Location = new System.Drawing.Point(10, 33);
            this.memoEdit2.Name = "memoEdit2";
            this.memoEdit2.Size = new System.Drawing.Size(706, 231);
            this.memoEdit2.TabIndex = 6;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 8);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(53, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Description";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Location = new System.Drawing.Point(15, 164);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(733, 308);
            this.xtraTabControl1.TabIndex = 40;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3});
            this.xtraTabControl1.Text = "xtraTabControl1";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Toh Yew Sin",
            "Zar",
            "Elaine"});
            this.comboBox2.Location = new System.Drawing.Point(440, 33);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(192, 21);
            this.comboBox2.TabIndex = 41;
            this.comboBox2.Text = "Toh Yew Sin";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // MyCustomEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 513);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.appointmentStatusEdit1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkAllDay);
            this.Controls.Add(this.timeEnd);
            this.Controls.Add(this.timeStart);
            this.Controls.Add(this.dtEnd);
            this.Controls.Add(this.dtStart);
            this.Controls.Add(this.txCustomStatus);
            this.Controls.Add(this.txCustomName);
            this.Controls.Add(this.lblCustomStatus);
            this.Controls.Add(this.lblCustomName);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.lblLabel);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.edStatus);
            this.Controls.Add(this.edLabel);
            this.Controls.Add(this.txSubject);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.btnReccurrence);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "MyCustomEditForm";
            this.Text = "XtraForm1";
            this.Load += new System.EventHandler(this.MyCustomEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.timeEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txCustomStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txCustomName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edLabel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txSubject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkAllDay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aCMSDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDeliveryScheduleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentStatusEdit1.Properties)).EndInit();
            this.xtraTabPage3.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TimeEdit timeEnd;
        private DevExpress.XtraEditors.TimeEdit timeStart;
        private DevExpress.XtraEditors.DateEdit dtEnd;
        private DevExpress.XtraEditors.DateEdit dtStart;
        private DevExpress.XtraEditors.TextEdit txCustomStatus;
        private DevExpress.XtraEditors.TextEdit txCustomName;
        private System.Windows.Forms.Label lblCustomStatus;
        private System.Windows.Forms.Label lblCustomName;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Label lblLabel;
        private System.Windows.Forms.Label lblStatus;
        private DevExpress.XtraScheduler.UI.AppointmentStatusEdit edStatus;
        private DevExpress.XtraScheduler.UI.AppointmentLabelEdit edLabel;
        private DevExpress.XtraEditors.TextEdit txSubject;
        private System.Windows.Forms.Label lblSubject;
        private DevExpress.XtraEditors.SimpleButton btnReccurrence;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.CheckEdit checkAllDay;
        private ACMS.ACMSDataSetTableAdapters.TblDeliveryScheduleTableAdapter tblDeliveryScheduleTableAdapter;
        private ACMSDataSet aCMSDataSet;
        private System.Windows.Forms.BindingSource tblDeliveryScheduleBindingSource;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraScheduler.UI.AppointmentStatusEdit appointmentStatusEdit1;
        private System.Windows.Forms.ComboBox comboBox1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit4;
        private System.Windows.Forms.Label label40;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit3;
        private System.Windows.Forms.Label label39;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit2;
        private System.Windows.Forms.Label label38;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
        private System.Windows.Forms.Label label28;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.MemoEdit memoEdit2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}