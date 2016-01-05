using System;
using System.Windows.Forms;
using ACMS.Utils;
using ACMSDAL;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace ACMS.ACMSStaff.Contacts
{
	/// <summary>
	/// Summary description for frmContacts.
	/// </summary>
	public class frmContacts : System.Windows.Forms.Form
	{

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtContactPerson = new DevExpress.XtraEditors.TextEdit();
            this.txtMobileNo = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.sbtnSave = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.txtBranchCode = new DevExpress.XtraEditors.TextEdit();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.luedtMediaSource = new DevExpress.XtraEditors.LookUpEdit();
            this.luedtMediaSourceCategory = new DevExpress.XtraEditors.LookUpEdit();
            this.label47 = new System.Windows.Forms.Label();
            this.txtNRICFIN = new DevExpress.XtraEditors.TextEdit();
            this.dateedtDOB = new DevExpress.XtraEditors.DateEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMediaSource = new DevExpress.XtraEditors.TextEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.luedtAssigntoStaff = new DevExpress.XtraEditors.LookUpEdit();
            this.rtxtRemarks = new DevExpress.XtraEditors.MemoEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cbPhoneCall = new System.Windows.Forms.CheckBox();
            this.cbSMS = new System.Windows.Forms.CheckBox();
            this.cbEmail = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.rbDNCYes = new System.Windows.Forms.RadioButton();
            this.rbDNCNo = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.gbAppt = new System.Windows.Forms.GroupBox();
            this.luedtServedBy = new DevExpress.XtraEditors.LookUpEdit();
            this.label17 = new System.Windows.Forms.Label();
            this.dateedtEndTime = new DevExpress.XtraEditors.DateEdit();
            this.dateedtStartTime = new DevExpress.XtraEditors.DateEdit();
            this.dateedtDate = new DevExpress.XtraEditors.DateEdit();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.chkMakeAppt = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtContactPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMobileNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBranchCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luedtMediaSource.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luedtMediaSourceCategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNRICFIN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateedtDOB.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateedtDOB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMediaSource.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luedtAssigntoStaff.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtRemarks.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.gbAppt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.luedtServedBy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateedtEndTime.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateedtEndTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateedtStartTime.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateedtStartTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateedtDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateedtDate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 18);
            this.label1.TabIndex = 214;
            this.label1.Text = "Contact Person:";
            // 
            // txtContactPerson
            // 
            this.txtContactPerson.EditValue = "";
            this.txtContactPerson.Location = new System.Drawing.Point(121, 15);
            this.txtContactPerson.Name = "txtContactPerson";
            this.txtContactPerson.Properties.MaxLength = 50;
            this.txtContactPerson.Size = new System.Drawing.Size(442, 20);
            this.txtContactPerson.TabIndex = 0;
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.EditValue = "";
            this.txtMobileNo.Location = new System.Drawing.Point(121, 67);
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Properties.MaxLength = 50;
            this.txtMobileNo.Size = new System.Drawing.Size(148, 20);
            this.txtMobileNo.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 18);
            this.label2.TabIndex = 220;
            this.label2.Text = "Contact No:";
            // 
            // txtEmail
            // 
            this.txtEmail.EditValue = "";
            this.txtEmail.Location = new System.Drawing.Point(121, 93);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Properties.Appearance.BackColor = System.Drawing.Color.LightYellow;
            this.txtEmail.Properties.Appearance.Options.UseBackColor = true;
            this.txtEmail.Properties.MaxLength = 50;
            this.txtEmail.Size = new System.Drawing.Size(280, 20);
            this.txtEmail.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(10, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 18);
            this.label3.TabIndex = 241;
            this.label3.Text = "Email Address:";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(10, 308);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 18);
            this.label5.TabIndex = 228;
            this.label5.Text = "Remarks:";
            // 
            // sbtnSave
            // 
            this.sbtnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.sbtnSave.Location = new System.Drawing.Point(121, 581);
            this.sbtnSave.Name = "sbtnSave";
            this.sbtnSave.Size = new System.Drawing.Size(75, 23);
            this.sbtnSave.TabIndex = 17;
            this.sbtnSave.Text = "Save";
            this.sbtnSave.Click += new System.EventHandler(this.sbtnSave_Click);
            // 
            // sbtnCancel
            // 
            this.sbtnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.sbtnCancel.Location = new System.Drawing.Point(202, 581);
            this.sbtnCancel.Name = "sbtnCancel";
            this.sbtnCancel.Size = new System.Drawing.Size(75, 23);
            this.sbtnCancel.TabIndex = 18;
            this.sbtnCancel.Text = "Cancel";
            // 
            // txtBranchCode
            // 
            this.txtBranchCode.EditValue = "";
            this.txtBranchCode.Enabled = false;
            this.txtBranchCode.Location = new System.Drawing.Point(121, 227);
            this.txtBranchCode.Name = "txtBranchCode";
            this.txtBranchCode.Properties.MaxLength = 50;
            this.txtBranchCode.Size = new System.Drawing.Size(100, 20);
            this.txtBranchCode.TabIndex = 12;
            // 
            // rbFemale
            // 
            this.rbFemale.AutoSize = true;
            this.rbFemale.Location = new System.Drawing.Point(55, 4);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(59, 17);
            this.rbFemale.TabIndex = 5;
            this.rbFemale.Text = "Female";
            this.rbFemale.UseVisualStyleBackColor = true;
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Location = new System.Drawing.Point(1, 4);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(48, 17);
            this.rbMale.TabIndex = 4;
            this.rbMale.Text = "Male";
            this.rbMale.UseVisualStyleBackColor = true;
            // 
            // luedtMediaSource
            // 
            this.luedtMediaSource.EditValue = "";
            this.luedtMediaSource.Location = new System.Drawing.Point(242, 252);
            this.luedtMediaSource.Name = "luedtMediaSource";
            this.luedtMediaSource.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luedtMediaSource.Properties.PopupWidth = 200;
            this.luedtMediaSource.Size = new System.Drawing.Size(120, 20);
            this.luedtMediaSource.TabIndex = 13;
            // 
            // luedtMediaSourceCategory
            // 
            this.luedtMediaSourceCategory.EditValue = "";
            this.luedtMediaSourceCategory.Location = new System.Drawing.Point(121, 252);
            this.luedtMediaSourceCategory.Name = "luedtMediaSourceCategory";
            this.luedtMediaSourceCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luedtMediaSourceCategory.Properties.PopupWidth = 200;
            this.luedtMediaSourceCategory.Size = new System.Drawing.Size(120, 20);
            this.luedtMediaSourceCategory.TabIndex = 13;
            this.luedtMediaSourceCategory.EditValueChanged += new System.EventHandler(this.luedtMediaSourceCategory_EditValueChanged);
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label47.Location = new System.Drawing.Point(10, 256);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(73, 13);
            this.label47.TabIndex = 107;
            this.label47.Text = "Media Source";
            // 
            // txtNRICFIN
            // 
            this.txtNRICFIN.EditValue = "";
            this.txtNRICFIN.Location = new System.Drawing.Point(121, 41);
            this.txtNRICFIN.Name = "txtNRICFIN";
            this.txtNRICFIN.Properties.Appearance.BackColor = System.Drawing.Color.LightYellow;
            this.txtNRICFIN.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNRICFIN.Properties.Appearance.Options.UseBackColor = true;
            this.txtNRICFIN.Properties.Appearance.Options.UseFont = true;
            this.txtNRICFIN.Properties.MaxLength = 50;
            this.txtNRICFIN.Size = new System.Drawing.Size(280, 20);
            this.txtNRICFIN.TabIndex = 1;
            // 
            // dateedtDOB
            // 
            this.dateedtDOB.EditValue = null;
            this.dateedtDOB.Location = new System.Drawing.Point(121, 202);
            this.dateedtDOB.Name = "dateedtDOB";
            this.dateedtDOB.Properties.Appearance.BackColor = System.Drawing.Color.LightYellow;
            this.dateedtDOB.Properties.Appearance.Options.UseBackColor = true;
            this.dateedtDOB.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateedtDOB.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dateedtDOB.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateedtDOB.Size = new System.Drawing.Size(98, 20);
            this.dateedtDOB.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 18);
            this.label4.TabIndex = 105;
            this.label4.Text = "Date-of-Birth:";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 18);
            this.label6.TabIndex = 104;
            this.label6.Text = "NRIC/FIN No:";
            // 
            // txtMediaSource
            // 
            this.txtMediaSource.EditValue = "";
            this.txtMediaSource.Location = new System.Drawing.Point(247, 252);
            this.txtMediaSource.Name = "txtMediaSource";
            this.txtMediaSource.Properties.MaxLength = 50;
            this.txtMediaSource.Size = new System.Drawing.Size(154, 20);
            this.txtMediaSource.TabIndex = 108;
            this.txtMediaSource.Visible = false;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 229);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 18);
            this.label7.TabIndex = 109;
            this.label7.Text = "Branch Code :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label8.Location = new System.Drawing.Point(10, 283);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 110;
            this.label8.Text = "Assign to Staff";
            // 
            // luedtAssigntoStaff
            // 
            this.luedtAssigntoStaff.EditValue = "";
            this.luedtAssigntoStaff.Location = new System.Drawing.Point(121, 279);
            this.luedtAssigntoStaff.Name = "luedtAssigntoStaff";
            this.luedtAssigntoStaff.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luedtAssigntoStaff.Properties.PopupWidth = 200;
            this.luedtAssigntoStaff.Size = new System.Drawing.Size(280, 20);
            this.luedtAssigntoStaff.TabIndex = 14;
            // 
            // rtxtRemarks
            // 
            this.rtxtRemarks.EditValue = "";
            this.rtxtRemarks.Location = new System.Drawing.Point(121, 305);
            this.rtxtRemarks.Name = "rtxtRemarks";
            this.rtxtRemarks.Properties.Appearance.BackColor = System.Drawing.Color.LightYellow;
            this.rtxtRemarks.Properties.Appearance.Options.UseBackColor = true;
            this.rtxtRemarks.Properties.MaxLength = 1000;
            this.rtxtRemarks.Size = new System.Drawing.Size(442, 93);
            this.rtxtRemarks.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label9.Location = new System.Drawing.Point(12, 411);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 112;
            this.label9.Text = "Status :";
            // 
            // cbStatus
            // 
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            "Active",
            "InActive"});
            this.cbStatus.Location = new System.Drawing.Point(121, 406);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(121, 21);
            this.cbStatus.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(10, 121);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 18);
            this.label10.TabIndex = 114;
            this.label10.Text = "Gender:";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(10, 148);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(112, 18);
            this.label11.TabIndex = 115;
            this.label11.Text = "Media Preference:";
            // 
            // cbPhoneCall
            // 
            this.cbPhoneCall.AutoSize = true;
            this.cbPhoneCall.Location = new System.Drawing.Point(121, 147);
            this.cbPhoneCall.Name = "cbPhoneCall";
            this.cbPhoneCall.Size = new System.Drawing.Size(77, 17);
            this.cbPhoneCall.TabIndex = 6;
            this.cbPhoneCall.Text = "Phone Call";
            this.cbPhoneCall.UseVisualStyleBackColor = true;
            // 
            // cbSMS
            // 
            this.cbSMS.AutoSize = true;
            this.cbSMS.Location = new System.Drawing.Point(204, 147);
            this.cbSMS.Name = "cbSMS";
            this.cbSMS.Size = new System.Drawing.Size(49, 17);
            this.cbSMS.TabIndex = 7;
            this.cbSMS.Text = "SMS";
            this.cbSMS.UseVisualStyleBackColor = true;
            // 
            // cbEmail
            // 
            this.cbEmail.AutoSize = true;
            this.cbEmail.Location = new System.Drawing.Point(257, 147);
            this.cbEmail.Name = "cbEmail";
            this.cbEmail.Size = new System.Drawing.Size(51, 17);
            this.cbEmail.TabIndex = 8;
            this.cbEmail.Text = "Email";
            this.cbEmail.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label12.Location = new System.Drawing.Point(10, 175);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(96, 18);
            this.label12.TabIndex = 119;
            this.label12.Text = "DNC Registrant?:";
            // 
            // rbDNCYes
            // 
            this.rbDNCYes.AutoSize = true;
            this.rbDNCYes.Location = new System.Drawing.Point(3, 3);
            this.rbDNCYes.Name = "rbDNCYes";
            this.rbDNCYes.Size = new System.Drawing.Size(43, 17);
            this.rbDNCYes.TabIndex = 9;
            this.rbDNCYes.Text = "Yes";
            this.rbDNCYes.UseVisualStyleBackColor = true;
            // 
            // rbDNCNo
            // 
            this.rbDNCNo.AutoSize = true;
            this.rbDNCNo.Location = new System.Drawing.Point(57, 3);
            this.rbDNCNo.Name = "rbDNCNo";
            this.rbDNCNo.Size = new System.Drawing.Size(39, 17);
            this.rbDNCNo.TabIndex = 10;
            this.rbDNCNo.TabStop = true;
            this.rbDNCNo.Text = "No";
            this.rbDNCNo.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbDNCYes);
            this.panel1.Controls.Add(this.rbDNCNo);
            this.panel1.Location = new System.Drawing.Point(121, 171);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(148, 22);
            this.panel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbFemale);
            this.panel2.Controls.Add(this.rbMale);
            this.panel2.Location = new System.Drawing.Point(121, 114);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 24);
            this.panel2.TabIndex = 4;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(273, 70);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(270, 18);
            this.label13.TabIndex = 124;
            this.label13.Text = "(eg. 81234567, 63366822)";
            // 
            // gbAppt
            // 
            this.gbAppt.Controls.Add(this.luedtServedBy);
            this.gbAppt.Controls.Add(this.label17);
            this.gbAppt.Controls.Add(this.dateedtEndTime);
            this.gbAppt.Controls.Add(this.dateedtStartTime);
            this.gbAppt.Controls.Add(this.dateedtDate);
            this.gbAppt.Controls.Add(this.label14);
            this.gbAppt.Controls.Add(this.label15);
            this.gbAppt.Controls.Add(this.label16);
            this.gbAppt.Location = new System.Drawing.Point(15, 454);
            this.gbAppt.Name = "gbAppt";
            this.gbAppt.Size = new System.Drawing.Size(548, 121);
            this.gbAppt.TabIndex = 248;
            this.gbAppt.TabStop = false;
            this.gbAppt.Visible = false;
            // 
            // luedtServedBy
            // 
            this.luedtServedBy.EditValue = "";
            this.luedtServedBy.Location = new System.Drawing.Point(222, 95);
            this.luedtServedBy.Name = "luedtServedBy";
            this.luedtServedBy.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luedtServedBy.Properties.PopupWidth = 200;
            this.luedtServedBy.Size = new System.Drawing.Size(280, 20);
            this.luedtServedBy.TabIndex = 254;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label17.Location = new System.Drawing.Point(106, 98);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 13);
            this.label17.TabIndex = 255;
            this.label17.Text = "Served By";
            // 
            // dateedtEndTime
            // 
            this.dateedtEndTime.EditValue = new System.DateTime(2013, 1, 1, 13, 0, 0, 0);
            this.dateedtEndTime.Location = new System.Drawing.Point(222, 69);
            this.dateedtEndTime.Name = "dateedtEndTime";
            this.dateedtEndTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null)});
            this.dateedtEndTime.Properties.DisplayFormat.FormatString = "hh:mm tt";
            this.dateedtEndTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateedtEndTime.Properties.EditFormat.FormatString = "hh:mm tt";
            this.dateedtEndTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateedtEndTime.Properties.Mask.EditMask = "hh:mm tt";
            this.dateedtEndTime.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dateedtEndTime.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateedtEndTime.Size = new System.Drawing.Size(100, 20);
            this.dateedtEndTime.TabIndex = 253;
            // 
            // dateedtStartTime
            // 
            this.dateedtStartTime.EditValue = new System.DateTime(2013, 1, 1, 13, 0, 0, 0);
            this.dateedtStartTime.Location = new System.Drawing.Point(222, 41);
            this.dateedtStartTime.Name = "dateedtStartTime";
            this.dateedtStartTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null)});
            this.dateedtStartTime.Properties.DisplayFormat.FormatString = "hh:mm tt";
            this.dateedtStartTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateedtStartTime.Properties.EditFormat.FormatString = "hh:mm tt";
            this.dateedtStartTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateedtStartTime.Properties.Mask.EditMask = "hh:mm tt";
            this.dateedtStartTime.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dateedtStartTime.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateedtStartTime.Size = new System.Drawing.Size(100, 20);
            this.dateedtStartTime.TabIndex = 252;
            // 
            // dateedtDate
            // 
            this.dateedtDate.EditValue = new System.DateTime(2006, 1, 28, 0, 0, 0, 0);
            this.dateedtDate.Location = new System.Drawing.Point(222, 13);
            this.dateedtDate.Name = "dateedtDate";
            this.dateedtDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateedtDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dateedtDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateedtDate.Size = new System.Drawing.Size(152, 20);
            this.dateedtDate.TabIndex = 249;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(106, 71);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 18);
            this.label14.TabIndex = 251;
            this.label14.Text = "End time:";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(106, 43);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 18);
            this.label15.TabIndex = 250;
            this.label15.Text = "Start time:";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(106, 15);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(100, 18);
            this.label16.TabIndex = 248;
            this.label16.Text = "Date:";
            // 
            // chkMakeAppt
            // 
            this.chkMakeAppt.AutoSize = true;
            this.chkMakeAppt.Location = new System.Drawing.Point(16, 441);
            this.chkMakeAppt.Name = "chkMakeAppt";
            this.chkMakeAppt.Size = new System.Drawing.Size(115, 17);
            this.chkMakeAppt.TabIndex = 249;
            this.chkMakeAppt.Text = "Make Appointment";
            this.chkMakeAppt.UseVisualStyleBackColor = true;
            this.chkMakeAppt.CheckedChanged += new System.EventHandler(this.chkMakeAppt_CheckedChanged);
            // 
            // frmContacts
            // 
            this.AcceptButton = this.sbtnSave;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.sbtnCancel;
            this.ClientSize = new System.Drawing.Size(571, 610);
            this.Controls.Add(this.chkMakeAppt);
            this.Controls.Add(this.gbAppt);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cbEmail);
            this.Controls.Add(this.cbSMS);
            this.Controls.Add(this.cbPhoneCall);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.rtxtRemarks);
            this.Controls.Add(this.luedtAssigntoStaff);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtMediaSource);
            this.Controls.Add(this.luedtMediaSource);
            this.Controls.Add(this.luedtMediaSourceCategory);
            this.Controls.Add(this.label47);
            this.Controls.Add(this.txtNRICFIN);
            this.Controls.Add(this.dateedtDOB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtBranchCode);
            this.Controls.Add(this.sbtnSave);
            this.Controls.Add(this.sbtnCancel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMobileNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtContactPerson);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmContacts";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "{0} Call List";
            this.Load += new System.EventHandler(this.frmContacts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtContactPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMobileNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBranchCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luedtMediaSource.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luedtMediaSourceCategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNRICFIN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateedtDOB.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateedtDOB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMediaSource.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luedtAssigntoStaff.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtRemarks.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.gbAppt.ResumeLayout(false);
            this.gbAppt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.luedtServedBy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateedtEndTime.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateedtEndTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateedtStartTime.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateedtStartTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateedtDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateedtDate.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

		private int nEmployeeID;
        private int nContactID;
        private string strBranchCode;
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.TextEdit txtContactPerson;
		private DevExpress.XtraEditors.TextEdit txtMobileNo;
		private System.Windows.Forms.Label label2;
		private DevExpress.XtraEditors.TextEdit txtEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
		private DevExpress.XtraEditors.SimpleButton sbtnSave;
        private DevExpress.XtraEditors.SimpleButton sbtnCancel;
        private DevExpress.XtraEditors.TextEdit txtBranchCode;
        private RadioButton rbFemale;
        private RadioButton rbMale;
        private DevExpress.XtraEditors.LookUpEdit luedtMediaSource;
        private DevExpress.XtraEditors.LookUpEdit luedtMediaSourceCategory;
        internal Label label47;
        internal DevExpress.XtraEditors.TextEdit txtNRICFIN;
        private DevExpress.XtraEditors.DateEdit dateedtDOB;
        internal Label label4;
        internal Label label6;
        private DevExpress.XtraEditors.TextEdit txtMediaSource;
        private ACMS.XtraUtils.LookupEditBuilder.MediaSourceLookupEditBuilder myMediaSourceLookupBuilder;
        private ACMS.XtraUtils.LookupEditBuilder.MediaSourceCategoryLookupEditBuilder myMediaSourceCategoryLookupBuilder;
        //private ACMS.XtraUtils.LookupEditBuilder.EmployeeIDLookupEditBuilder myAssigntoStaffLookupBuilder;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        internal Label label7;
        //private string strgender;
        internal Label label8;
        private DevExpress.XtraEditors.LookUpEdit luedtAssigntoStaff;
        private DevExpress.XtraEditors.MemoEdit rtxtRemarks;
        internal Label label9;
        private ComboBox cbStatus;
        //private int inMediaSource;
        //private int nStatus;
        //private int nStatusActiveID;
        //private int nStatusInActiveID;
        private Label label10;
        private Label label11;
        private CheckBox cbPhoneCall;
        private CheckBox cbSMS;
        private CheckBox cbEmail;
        private Label label12;
        private RadioButton rbDNCYes;
        private RadioButton rbDNCNo;
        private Panel panel1;
        private Panel panel2;
        private Label label13;
        private GroupBox gbAppt;
        private DevExpress.XtraEditors.DateEdit dateedtEndTime;
        private DevExpress.XtraEditors.DateEdit dateedtStartTime;
        private DevExpress.XtraEditors.DateEdit dateedtDate;
        private Label label14;
        private Label label15;
        private Label label16;
        private CheckBox chkMakeAppt;
        private DevExpress.XtraEditors.LookUpEdit luedtServedBy;
        internal Label label17;
        private string strStatus;

        private void frmContacts_Load(object sender, EventArgs e)
        {            
            //myMediaSourceLookupBuilder = new ACMS.XtraUtils.LookupEditBuilder.MediaSourceLookupEditBuilder(
            //   luedtMediaSource.Properties, "");
            myMediaSourceCategoryLookupBuilder = new ACMS.XtraUtils.LookupEditBuilder.MediaSourceCategoryLookupEditBuilder(
                luedtMediaSourceCategory.Properties);

            new XtraUtils.LookupEditBuilder.EmployeeIDLookupEditBuilder(luedtAssigntoStaff.Properties);
            new XtraUtils.LookupEditBuilder.EmployeeIDLookupEditBuilder(luedtServedBy.Properties);
        }

        public frmContacts(int nEmployeeID, int nContactID, string strBranchCode, bool bDisableDNC)
		{
			InitializeComponent();
            
            this.nEmployeeID = nEmployeeID;
            this.strBranchCode = strBranchCode;
			this.nContactID = nContactID;
            txtBranchCode.Text = strBranchCode;
            //dateedtDOB.DateTime = DateTime.Now.Date;
            dateedtDate.DateTime = DateTime.Now.Date;
            luedtAssigntoStaff.EditValue = nEmployeeID;
            
            /*if (nStatusInActiveID == 0)
            {
                cbStatus.Text = "InActive";
            }
            else
            {
                cbStatus.Text = "Active";
            }*/

            if (nContactID < 0)
            {
                this.Text = string.Format(this.Text, "New");
                cbStatus.Text = "Active";
                cbStatus.Enabled = false;

                strStatus = "New";
                rbDNCYes.Enabled = true;
                rbDNCNo.Enabled = true;
            }
            else
            {
                this.Text = string.Format(this.Text, "Edit") + " - ID: " + nContactID;
                strStatus = "Edit";

                cbStatus.Enabled = true;
                rbDNCYes.Enabled = bDisableDNC;
                rbDNCNo.Enabled = bDisableDNC;
            }
		}

		protected override void Dispose(bool disposing)
		{
			if(disposing)
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}		

		private void sbtnSave_Click(object sender, System.EventArgs e)
		{
            //bool isSuccess = false; // return value
            int myContactId = 0;
            string strContactName = txtContactPerson.Text.ToString().Trim();
            string strNRICFIN = txtNRICFIN.Text.ToString().Trim().ToUpper();
            string strMobileNo = txtMobileNo.Text.ToString().Trim();
            string strEmail = txtEmail.Text.ToString().Trim();
            string strGender = "";
            Nullable<DateTime> dtDOB = null;  //DateTime?
            int nMediaSourceID = -1;
            string strBranchCode = txtBranchCode.Text.ToString().Trim();
            string strRemarks = rtxtRemarks.Text.ToString().Trim();
            bool fPhoneCall = false;
            bool fSMS = false;
            bool fEmail = false;
            int fDNC = -1;
            string nEntryBy = nEmployeeID.ToString();
            int nStatus;

            ACMSLogic.Staff.Contacts myContact = new ACMSLogic.Staff.Contacts();

            if (rbMale.Checked)
            {
                strGender = "M";
            }
            else if (rbFemale.Checked)
            {
                strGender = "F";
            }

            if (cbStatus.Text == "Active")
            {
                nStatus = 1;
            }
            else
            {
                nStatus = 0;
            }

            #region Validation
            if (strContactName.Length == 0)
            {
                UI.ShowErrorMessage(this, "Contact person is required.", "Error");

                //txtContactPerson.Focus();
                DialogResult = DialogResult.None;

                return;
            }

            if (strNRICFIN.Length != 0)
            {
                if (!IsSingaporeNric_S(strNRICFIN) && !IsSingaporeNric_T(strNRICFIN) && !IsFinValid(strNRICFIN))
                {
                    UI.ShowErrorMessage(this, "Invalid NRIC/FIN.", "Error");
                    //luedtMediaSource.Focus();

                    DialogResult = DialogResult.None;

                    return;
                }

                //if (strStatus == "New")
                //{
                //    if (myContact.CheckDupNRIC(strNRICFIN))
                //    {
                //        UI.ShowErrorMessage(this, "NRIC/FIN already exists in Lead Management System or Members' database.", "Error");

                //        DialogResult = DialogResult.None;

                //        return;
                //    }
                //}
            }

            if (strMobileNo.Length == 0)
            {
                UI.ShowErrorMessage(this, "Mobile No. is required.", "Error");

                //txtMobileNo.Focus();
                DialogResult = DialogResult.None;

                return;
            }

            //Mobile No invalid
            if (!IsMobileNoValid(strMobileNo))
            {
                UI.ShowErrorMessage(this, "Invalid Mobile No.", "Error");
                //luedtMediaSource.Focus();

                DialogResult = DialogResult.None;

                return;
            }

            //if (strStatus == "New")
            //{
            //    if (myContact.CheckDupMobileNo(strMobileNo))
            //    {
            //        UI.ShowErrorMessage(this, "Mobile No already exists in system.", "Error");

            //        DialogResult = DialogResult.None;

            //        return;
            //    }
            //}            

            //Email Address invalid
            if (strEmail.Length != 0)
            {
                if (!IsEmailValid(strEmail))
                {
                    UI.ShowErrorMessage(this, "Invalid Email Address.", "Error");
                    //luedtMediaSource.Focus();

                    DialogResult = DialogResult.None;

                    return;
                }
            }

            if (rbMale.Checked == false && rbFemale.Checked == false)
            {
                UI.ShowErrorMessage(this, "Gender is required.", "Error");

                DialogResult = DialogResult.None;

                return;
            }

            if (cbPhoneCall.Checked == false && cbSMS.Checked == false && cbEmail.Checked == false)
            {
                UI.ShowErrorMessage(this, "Media preference is required.", "Error");

                DialogResult = DialogResult.None;

                return;
            }

            //if (rbDNCYes.Checked == false && rbDNCNo.Checked == false)
            //{
            //    UI.ShowErrorMessage(this, "DNC status is required.", "Error");

            //    DialogResult = DialogResult.None;

            //    return;
            //}

            if (luedtMediaSourceCategory.Text.Length == 0 || luedtMediaSource.Text.Length == 0)
            {
                UI.ShowErrorMessage(this, "Media Source is required.", "Error");
                //luedtMediaSource.Focus();

                DialogResult = DialogResult.None;

                return;
            }

            if (luedtAssigntoStaff.Text.Length == 0)
            {
                UI.ShowErrorMessage(this, "Please assign this new contact to a staff.", "Error");
                //luedtMediaSource.Focus();

                DialogResult = DialogResult.None;

                return;
            }
            if (chkMakeAppt.Checked) // Save Appointment
            {
                if (luedtServedBy.EditValue == "")
                {
                    UI.ShowErrorMessage(this, "Please assign this new contact serve by which staff.", "Error");
                    return;
                }
            }
            #endregion            

            if (cbPhoneCall.Checked == true)
            {
                fPhoneCall = true;
            }

            if (cbSMS.Checked == true)
            {
                fSMS = true;
            }

            if (cbEmail.Checked == true)
            {
                fEmail = true;
            }

            if (rbDNCYes.Checked == true)            
                fDNC = 1;

            if (rbDNCNo.Checked == true)            
                fDNC = 0;

            nEmployeeID = Convert.ToInt32(luedtAssigntoStaff.EditValue);
            nMediaSourceID = Convert.ToInt32(luedtMediaSource.EditValue);

            if (dateedtDOB.Text.Length != 0) 
            {
                dtDOB = dateedtDOB.DateTime;
            }

			if (nContactID < 0)
			{
                TblContacts myContacts = new TblContacts();

                myContacts.AddNewLead(ref myContactId, strContactName, strNRICFIN, strMobileNo, strEmail,
                                           strGender, dtDOB, nMediaSourceID, nEmployeeID,
                                           strBranchCode, strRemarks, fPhoneCall, fSMS,
                                           fEmail, fDNC, nEntryBy); 
                
                if (myContactId > 0)
                {
                    try
                    {                       
                        SendConfirmation(myContactId.ToString().Trim(), strContactName.Trim(), strEmail.Trim(), ref myContacts);                                               
                    }
                    catch (Exception ex) 
                    { 
                    }

                }
                
                DialogResult = DialogResult.OK;
			}
			else
			{
                TblContacts myContacts = new TblContacts();

                myContacts.UpdateLead(nContactID, strContactName, strNRICFIN, strMobileNo, strEmail,
                                        strGender, dtDOB, nMediaSourceID, nEmployeeID,
                                        strBranchCode, strRemarks, Convert.ToBoolean(nStatus), fPhoneCall, fSMS,
                                        fEmail, fDNC, nEntryBy);

				DialogResult = DialogResult.OK;
                myContactId = nContactID;
			}

            if (chkMakeAppt.Checked) // Save Appointment
            {
                ACMSLogic.Staff.Appointment myAppointment = new ACMSLogic.Staff.Appointment();
                DateTime StartDateTime = Convert.ToDateTime(dateedtStartTime.Text);
                DateTime EndDateTime = Convert.ToDateTime(dateedtEndTime.Text);
                int nServedBy = Convert.ToInt32(luedtServedBy.EditValue);

                myAppointment.NewAppoinment(nEmployeeID, dateedtDate.DateTime, StartDateTime,
                   EndDateTime, "", txtBranchCode.Text, myContactId, "", "", nServedBy);                                
            }
		}

        protected void SendConfirmation(string nContactId, string strContactName, string strEmail, ref TblContacts myContacts)
        {
            int nEdmId = 122;
            string tmp_strEncryptionKey = "";
            string tmp_strSubject = "";
            string tmp_strContent = "";
            string tmp_strSender = "";
            Random rnd = new Random();       

            DateTime dtToday = DateTime.Today;
            string dtExpiryDate = String.Format("{0:MMM d, yyyy}", dtToday.AddMonths(1));

            //Blast the email consent to the leads if email is not null
            if (strEmail.Trim() != "" && IsEmailValid(strEmail))
            {                   
                DataTable dtEdmContent = new DataTable();

                dtEdmContent = myContacts.GetLeadConfirmationEmail();

                if (dtEdmContent.Rows.Count > 0)
                {
                    foreach (DataRow rs in dtEdmContent.Rows)
                    {
                        tmp_strSender = rs["strSender"].ToString().Trim();
                        tmp_strSubject = rs["strSubject"].ToString().Trim();
                        tmp_strContent = rs["strContent"].ToString().Trim();
                    }
                }

                dtEdmContent.Dispose();
                //nEdmId = myContacts.CreateNewEdm(tmp_strSender, tmp_strSubject, tmp_strContent, 1, 9, "L"); //Insert Into DB

                string tmp_strMembershipID = nContactId.ToString();
                string tmp_strMemberName = strContactName;
                //Generate random order number 1-5
                int tmp_nOrder = GetRandomOrderNo(rnd);
                string tmp_strDate = GetToday();

                //Generate Encryption Key, status = 0
                tmp_strEncryptionKey = GetEncryptionKey(nEdmId, tmp_strMembershipID, strEmail.Trim(), tmp_strDate);

                //Need to check if email has been sent - from logs     
                if (!IsDuplicatedSubmission(tmp_strMembershipID,
                                                    strEmail.Trim(),
                                                    nEdmId,
                                                    tmp_strEncryptionKey))
                {
                    //Send Email
                    SendEDM(nContactId, strContactName.ToUpper(), dtExpiryDate, strEmail,
                                tmp_strSender, tmp_strSubject, tmp_strContent, nEdmId.ToString(),
                                tmp_strEncryptionKey);

                    InsertEmailSendingLog(strEmail.Trim(), nEdmId,
                                                    tmp_strMembershipID, tmp_strMemberName,
                                                    tmp_strDate, tmp_strEncryptionKey,
                                                    "L");
                }

            }                        
        }
        protected bool IsDuplicatedSubmission(string strMembershipID, string strRecipient, int nEdmId, string strEncryptionKey)
        {
            bool rval = false;

            string connectionString = (string)ConfigurationSettings.AppSettings["AmoreMySQLConnStr"];
            MySqlConnection myConn = new MySqlConnection(connectionString);

            if (myConn.State == ConnectionState.Closed)
            {
                myConn.Open();
            }

            try
            {
                string mysql_DuplicateCheck = @"SELECT strRecipient FROM tbledm_logs 
                                            WHERE nEdmId = @p_nEdmId 
                                                    AND strRecipient = @p_strRecipient 
                                                    AND strMembershipID = @p_strMembershipID
                                                    AND strEncryptionKey = @p_strEncryptionKey;";

                MySqlCommand cmd_DuplicateCheck = myConn.CreateCommand();
                cmd_DuplicateCheck.CommandText = mysql_DuplicateCheck;
                cmd_DuplicateCheck.CommandType = CommandType.Text;

                cmd_DuplicateCheck.Parameters.Add(new MySqlParameter("@p_nEdmId", nEdmId));
                cmd_DuplicateCheck.Parameters.Add(new MySqlParameter("@p_strRecipient", strRecipient));
                cmd_DuplicateCheck.Parameters.Add(new MySqlParameter("@p_strMembershipID", strMembershipID));
                cmd_DuplicateCheck.Parameters.Add(new MySqlParameter("@p_strEncryptionKey", strEncryptionKey));

                MySqlDataReader dr_DuplicateCheck = cmd_DuplicateCheck.ExecuteReader();

                if (dr_DuplicateCheck.HasRows)
                {
                    rval = true;

                    //--Response.Write("--> Error : Duplicate Record Found.... <br>");
                }
                dr_DuplicateCheck.Close();

            }
            catch (Exception ex)
            {
                rval = true;

                //--Response.Write(ex.Message);
            }

            myConn.Close();

            return rval;
        }

        protected void InsertEmailSendingLog(string strRecipient, int nEdmId, string strMembershipID, string strMemberName,
                                            string strDate, string strEncryptionKey, string strTargetGroup)
        {
            string connectionString = (string)ConfigurationSettings.AppSettings["AmoreMySQLConnStr"];
            MySqlConnection myConn = new MySqlConnection(connectionString);

            if (myConn.State == ConnectionState.Closed)
            {
                myConn.Open();
            }

            try
            {
                string mysql_InsEmailSendingLog = @"INSERT INTO tbledm_logs (strRecipient, nEdmId, strMembershipID, strMemberName, 
                                                                         strDate, strEncryptionKey, dtConsentExpiry, strTargetGroup, nStatus)
						                                    VALUES (@p_strRecipient, @p_nEdmId, @p_strMembershipID, @p_strMemberName, 
                                                                         @p_strDate, @p_strEncryptionKey, DATE_ADD(NOW(), INTERVAL 1 MONTH), @p_strTargetGroup, 1);";

                MySqlCommand cmd_InsEmailSendingLog = myConn.CreateCommand();
                cmd_InsEmailSendingLog.CommandText = mysql_InsEmailSendingLog;
                cmd_InsEmailSendingLog.CommandType = CommandType.Text;

                cmd_InsEmailSendingLog.Parameters.Add(new MySqlParameter("@p_strRecipient", strRecipient));
                cmd_InsEmailSendingLog.Parameters.Add(new MySqlParameter("@p_nEdmId", nEdmId));
                cmd_InsEmailSendingLog.Parameters.Add(new MySqlParameter("@p_strMembershipID", strMembershipID));
                cmd_InsEmailSendingLog.Parameters.Add(new MySqlParameter("@p_strMemberName", strMemberName));
                cmd_InsEmailSendingLog.Parameters.Add(new MySqlParameter("@p_strDate", strDate));
                cmd_InsEmailSendingLog.Parameters.Add(new MySqlParameter("@p_strEncryptionKey", strEncryptionKey));
                cmd_InsEmailSendingLog.Parameters.Add(new MySqlParameter("@p_strTargetGroup", strTargetGroup));

                cmd_InsEmailSendingLog.ExecuteNonQuery();

                //--Response.Write("--> Inserted Email Log for " + strRecipient + ".... <br>");

            }
            catch (Exception ex)
            {
                //--Response.Write(ex.Message);
            }

            myConn.Close();

        }
       
        protected string GetToday()
        {
            string Today = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            return Today;
        }
        protected int GetRandomOrderNo(Random rnd)
        {
            int rval = 0;

            try
            {
                rval = Convert.ToInt32(rnd.Next(10000000).ToString());
            }
            catch { }

            return rval;
        }
        protected bool SendEDM(string strMembershipID, string strMemberName, string dtExpiryDate, string strEmail,
                                string strSender, string strSubject, string strContent, string strEdmId, string strEncryptedKey)
        {
            bool rval = false;

            string edm_local = "";
            string unsub_local = "";

            edm_local = "http://web.amorefitness.com/amorecss/lead/consentForm.aspx?";
            unsub_local = "http://web.amorefitness.com/amorecss/lead/unsubForm.aspx?";

            try
            {
                SmtpClient mySmtpClient = new SmtpClient("192.168.0.106");

                // set smtp-client with basicAuthentication
                mySmtpClient.UseDefaultCredentials = false;
                System.Net.NetworkCredential basicAuthenticationInfo = new System.Net.NetworkCredential("info", "amore!123");
                mySmtpClient.Credentials = basicAuthenticationInfo;

                // add from,to mailaddresses                
                MailAddress from = new MailAddress(strSender, "INFO");
                MailAddress to = new MailAddress(strEmail, strMemberName);
                MailMessage myMail = new System.Net.Mail.MailMessage(from, to);

                // add ReplyTo
                MailAddress replyto = new MailAddress(strSender);
                myMail.ReplyTo = replyto;

                // set subject and encoding
                myMail.Subject = strSubject;
                myMail.SubjectEncoding = System.Text.Encoding.UTF8;

                // set body-message and encoding
                string strMailContent = strContent;

                strMailContent = strMailContent.Replace("\"", "'");
                strMailContent = strMailContent.Replace("#strMembershipID#", strMembershipID.ToUpper());
                strMailContent = strMailContent.Replace("#strMemberName#", strMemberName.ToUpper());
                strMailContent = strMailContent.Replace("#dtExpiryDate#", dtExpiryDate);
                strMailContent = strMailContent.Replace("#EDM_LOCAL#", edm_local + "id=" + strEdmId + "&contid=" + strMembershipID + "&ref=" + strEncryptedKey);
                strMailContent = strMailContent.Replace("#UNSUB_LOCAL#", unsub_local + "id=" + strEdmId + "&contid=" + strMembershipID + "&ref=" + strEncryptedKey);

                myMail.Body = strMailContent;
                myMail.BodyEncoding = System.Text.Encoding.UTF8;
                // text or html
                myMail.IsBodyHtml = true;

                mySmtpClient.Send(myMail);

                rval = true;

            }
            catch (SmtpException ex)
            {
                rval = false;

                throw new ApplicationException
                  ("SmtpException has occured: " + ex.Message);
            }
            catch (Exception ex)
            {
                rval = false;

                throw ex;
            }

            return rval;
        }
               
        protected string GetEncryptionKey(int nEdmId, string strMembershipID, string strEmail, string strToday)
        {
            string hash = "";

            //string source = "1-4857-stevenkong@amorefitness.com" + Today;
            string source = nEdmId.ToString() + "-" + strMembershipID.Trim() + "-" + strEmail.Trim() + "-" + strToday.Trim();

            using (MD5 md5Hash = MD5.Create())
            {
                hash = GetMd5Hash(md5Hash, source);
            }
            return hash;
        }

        #region HashingMD5

        public static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash. 
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes 
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data  
            // and format each one as a hexadecimal string. 
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string. 
            return sBuilder.ToString();
        }

        // Verify a hash against a string. 
        public static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input. 
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region DataValidation               
        protected bool IsEmailValid(string strEmail)
        {
            bool rval = false;

            Regex emailRegex = new Regex(@"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$");

            if (emailRegex.IsMatch(strEmail))
            {
                rval = true;
            }

            return rval;
        }

        protected bool IsMobileNoValid(string strMobileNo)
        {
            bool rval = false;

            Regex mobileRegex = new Regex(@"^[689]\d{7}$");

            if (mobileRegex.IsMatch(strMobileNo))
            {
                rval = true;
            }

            return rval;
        }

        protected bool IsSingaporeNric_S(string nric)
        {
            bool rval = false;

            try
            {
                int sumNric;
                string alphaNric;

                if (!(nric[0].ToString() == "S"))
                {
                    throw new Exception("-1");
                }

                if (!(nric.Length == 9))
                {
                    throw new Exception("-2");
                }

                //Test Sample: S9344600C            
                sumNric = (Convert.ToInt32(nric[1].ToString()) * 2) +
                          (Convert.ToInt32(nric[2].ToString()) * 7) +
                          (Convert.ToInt32(nric[3].ToString()) * 6) +
                          (Convert.ToInt32(nric[4].ToString()) * 5) +
                          (Convert.ToInt32(nric[5].ToString()) * 4) +
                          (Convert.ToInt32(nric[6].ToString()) * 3) +
                          (Convert.ToInt32(nric[7].ToString()) * 2);

                int alphaCode = 11 - (sumNric % 11);

                switch (alphaCode)
                {
                    case 1:
                        alphaNric = "A";
                        break;
                    case 2:
                        alphaNric = "B";
                        break;
                    case 3:
                        alphaNric = "C";
                        break;
                    case 4:
                        alphaNric = "D";
                        break;
                    case 5:
                        alphaNric = "E";
                        break;
                    case 6:
                        alphaNric = "F";
                        break;
                    case 7:
                        alphaNric = "G";
                        break;
                    case 8:
                        alphaNric = "H";
                        break;
                    case 9:
                        alphaNric = "I";
                        break;
                    case 10:
                        alphaNric = "Z";
                        break;
                    case 11:
                        alphaNric = "J";
                        break;
                    default:
                        return false;
                }

                if (!(alphaNric == nric[8].ToString()))
                {
                    throw new Exception("-3");
                }
                rval = true;
            }
            catch (Exception ex)
            {
                rval = false;
            }

            return rval;
        }

        protected bool IsSingaporeNric_T(string nric)
        {
            bool rval = false;

            try
            {
                int sumNric;
                string alphaNric;

                if (!(nric[0].ToString() == "T"))
                {
                    throw new Exception("-1");
                }

                if (!(nric.Length == 9))
                {
                    throw new Exception("-2");
                }

                sumNric = (Convert.ToInt32(nric[1].ToString()) * 2) +
                          (Convert.ToInt32(nric[2].ToString()) * 7) +
                          (Convert.ToInt32(nric[3].ToString()) * 6) +
                          (Convert.ToInt32(nric[4].ToString()) * 5) +
                          (Convert.ToInt32(nric[5].ToString()) * 4) +
                          (Convert.ToInt32(nric[6].ToString()) * 3) +
                          (Convert.ToInt32(nric[7].ToString()) * 2);

                int alphaCode = 11 - (sumNric % 11);

                switch (alphaCode)
                {
                    case 1:
                        alphaNric = "H";
                        break;
                    case 2:
                        alphaNric = "I";
                        break;
                    case 3:
                        alphaNric = "Z";
                        break;
                    case 4:
                        alphaNric = "J";
                        break;
                    case 5:
                        alphaNric = "A";
                        break;
                    case 6:
                        alphaNric = "B";
                        break;
                    case 7:
                        alphaNric = "C";
                        break;
                    case 8:
                        alphaNric = "D";
                        break;
                    case 9:
                        alphaNric = "E";
                        break;
                    case 10:
                        alphaNric = "F";
                        break;
                    case 11:
                        alphaNric = "G";
                        break;
                    default:
                        return false;
                }

                if (!(alphaNric == nric[8].ToString()))
                {
                    throw new Exception("-3");
                }
                rval = true;
            }
            catch (Exception ex)
            {
                rval = false;
            }

            return rval;
        }

        private static readonly int[] Multiples = { 2, 7, 6, 5, 4, 3, 2 };

        public static bool IsNricValid(string nric)
        {
            if (string.IsNullOrEmpty(nric))
            {
                return false;
            }

            //	check length
            if (nric.Length != 9)
            {
                return false;
            }

            int total = 0
                , count = 0
                , numericNric;
            char first = nric[0]
                , last = nric[nric.Length - 1];

            if (first != 'S' && first != 'T')
            {
                return false;
            }

            if (!int.TryParse(nric.Substring(1, nric.Length - 2), out numericNric))
            {
                return false;
            }

            while (numericNric != 0)
            {
                total += numericNric % 10 * Multiples[Multiples.Length - (1 + count++)];

                numericNric /= 10;
            }

            char[] outputs;
            if (first == 'S')
            {
                outputs = new char[] { 'J', 'Z', 'I', 'H', 'G', 'F', 'E', 'D', 'C', 'B', 'A' };
            }
            else
            {
                outputs = new char[] { 'G', 'F', 'E', 'D', 'C', 'B', 'A', 'J', 'Z', 'I', 'H' };
            }

            return last == outputs[total % 11];

        }

        public static bool IsFinValid(string fin)
        {
            if (string.IsNullOrEmpty(fin))
            {
                return false;
            }

            //	check length
            if (fin.Length != 9)
            {
                return false;
            }

            int total = 0
                , count = 0
                , numericNric;
            char first = fin[0]
                , last = fin[fin.Length - 1];

            if (first != 'F' && first != 'G')
            {
                return false;
            }

            if (!int.TryParse(fin.Substring(1, fin.Length - 2), out numericNric))
            {
                return false;
            }

            while (numericNric != 0)
            {
                total += numericNric % 10 * Multiples[Multiples.Length - (1 + count++)];

                numericNric /= 10;
            }

            char[] outputs;
            if (first == 'F')
            {
                outputs = new char[] { 'X', 'W', 'U', 'T', 'R', 'Q', 'P', 'N', 'M', 'L', 'K' };
            }
            else
            {
                outputs = new char[] { 'R', 'Q', 'P', 'N', 'M', 'L', 'K', 'X', 'W', 'U', 'T' };
            }

            return last == outputs[total % 11];
        }

        #endregion
        	

        public string ContactPerson
        {
            set 
            { 
                txtContactPerson.Text = value; 
            }
        }

        public string MobileNo
        {
            set 
            { 
                txtMobileNo.Text = value; 
            }
        }

        public string Nric
        {
            set 
            { 
                txtNRICFIN.Text = value; 
            }
        }

        public string Email
        {
            set 
            { 
                txtEmail.Text = value; 
            }
        }

        public string Remarks
        {
            set 
            { 
                rtxtRemarks.Text = value; 
            }
        }

        public string BranchCode
        {
            set
            { 
                txtBranchCode.Text = value; 
            }
        }

        public DateTime DateOfBirth
        {
            set 
            { 
                dateedtDOB.EditValue = value; 
            }
        }

        public int NStatusActive
        {
            set 
            { 
                cbStatus.Text = "Active"; 
            }
        }

        public int NStatusInActive
        {
            set 
            { 
                cbStatus.Text = "InActive"; 
            }
        }

        public int MediaSourceID
        {
            set 
            { 
                luedtMediaSource.EditValue = value; 
            }
        }

        public string MediaSourceCategory
        {
            set
            {
                luedtMediaSourceCategory.EditValue = value;
            }
        }

        public bool IsGenderFemale
        {
            set 
            { 
                rbFemale.Checked = value; 
            }
        }

        public bool IsGenderMale
        {
            set 
            { 
                rbMale.Checked = value; 
            }
        }

        public bool IsPhoneCall
        {
            set
            {
                cbPhoneCall.Checked = value;
            }
        }

        public bool IsSMS
        {
            set
            {
                cbSMS.Checked = value;
            }
        }

        public bool IsEmail
        {
            set
            {
                cbEmail.Checked = value;
            }
        }

        public bool IsDNCYes
        {            
            set
            {
                rbDNCYes.Checked = value;
            }
        }

        public bool IsDNCNo
        {
            set
            {
                rbDNCNo.Checked = value;
            }
        }

        private void luedtMediaSourceCategory_EditValueChanged(object sender, System.EventArgs e)
        {
            //SetMediaSource();
            myMediaSourceLookupBuilder = new ACMS.XtraUtils.LookupEditBuilder.MediaSourceLookupEditBuilder(
                luedtMediaSource.Properties, luedtMediaSourceCategory.EditValue.ToString());            
        }

        private void chkMakeAppt_CheckedChanged(object sender, EventArgs e)
        {
            gbAppt.Visible = chkMakeAppt.Checked;
        }
       
	}
}
