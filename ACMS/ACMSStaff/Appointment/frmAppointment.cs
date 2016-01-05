using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ACMS.Utils;

namespace ACMS.ACMSStaff.Appointment
    
{
	/// <summary>
	/// Summary description for frmAppointment.
	/// </summary>
	public class frmAppointment : System.Windows.Forms.Form
	{
		private int nEmployeeID;
		private int nAppointmentID;

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.Label label6;
		private DevExpress.XtraEditors.SimpleButton sbtnSave;
		private DevExpress.XtraEditors.SimpleButton sbtnCancel;
        private DevExpress.XtraEditors.DateEdit dateedtDate;
        private DevExpress.XtraEditors.LookUpEdit luedtContact;
		private DevExpress.XtraEditors.MemoEdit memoedtRemark;
        private DevExpress.XtraEditors.TextEdit txtBranchCode;
        internal Label label7;
        //private Telerik.WinControls.RadThemeManager radThemeManager1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        
		public DateTime StartDateTime;
        private DevExpress.XtraEditors.DateEdit dateedtEndTime;
        private DevExpress.XtraEditors.DateEdit dateedtStartTime;
        private RadioButton rbNew;
        private RadioButton rbExisting;
        private ucMemberID ucMemberID1;
        private Label label4;
        public DateTime EndDateTime;

		public DateTime Date
		{
			set { dateedtDate.EditValue = value; }
		}

        public DateTime StartTime
        {
           // set { Convert.ToDateTime(dateedtStartTime.Text); } 
			set { dateedtStartTime.EditValue = value; }
        }

        public DateTime EndTime
        {
            //set { Convert.ToDateTime(dateedtEndTime.Text); } 
			set { dateedtEndTime.EditValue = value; }
        }

		
        public string BranchCode
		{
			set { txtBranchCode.EditValue = value; }
		}
        

		public int ContactID
		{ 
			set { luedtContact.EditValue = value; }
		}

		public string Remark
		{
			set { memoedtRemark.EditValue = value; }
        }
        public string strMembership
        {
            set { ucMemberID1.EditValue = value; }
        }

        public frmAppointment(int nEmployeeID, int nAppointmentID, string strBranchCode, int nContactID)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            ACMS.XtraUtils.XtraEditors.SetDateEditFormat(dateedtDate);
            this.nEmployeeID = nEmployeeID;
            this.nAppointmentID = nAppointmentID;
            this.BranchCode = strBranchCode;
            txtBranchCode.Text = strBranchCode;
            if (nContactID > 0)
             {
                 ucMemberID1.Visible = false;
                 luedtContact.Visible = true;
                 lblContact.Text = "New Lead";
                 rbExisting.Checked = false;
                 rbNew.Checked = true; 
             }
            else
             {
                 ucMemberID1.Visible = true;
                 luedtContact.Visible = false;
                 lblContact.Text = "Existing Member";
                 rbExisting.Checked = true;
                 rbNew.Checked = false; 
             }

            if (nAppointmentID < 0)
                this.Text = string.Format(this.Text, "New");
            else
                this.Text = string.Format(this.Text, "Edit") + " - ID: " + nAppointmentID;

            new XtraUtils.LookupEditBuilder.ContactsLookupEditBuilder(luedtContact.Properties, nEmployeeID);
            dateedtDate.DateTime = DateTime.Today;

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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblContact = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dateedtDate = new DevExpress.XtraEditors.DateEdit();
            this.luedtContact = new DevExpress.XtraEditors.LookUpEdit();
            this.memoedtRemark = new DevExpress.XtraEditors.MemoEdit();
            this.sbtnSave = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.txtBranchCode = new DevExpress.XtraEditors.TextEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.dateedtEndTime = new DevExpress.XtraEditors.DateEdit();
            this.dateedtStartTime = new DevExpress.XtraEditors.DateEdit();
            this.rbNew = new System.Windows.Forms.RadioButton();
            this.rbExisting = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.ucMemberID1 = new ACMS.ucMemberID();
            ((System.ComponentModel.ISupportInitialize)(this.dateedtDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateedtDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luedtContact.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoedtRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBranchCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateedtEndTime.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateedtEndTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateedtStartTime.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateedtStartTime.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(20, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(20, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Start time:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(20, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "End time:";
            // 
            // lblContact
            // 
            this.lblContact.Location = new System.Drawing.Point(20, 129);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(100, 18);
            this.lblContact.TabIndex = 4;
            this.lblContact.Text = "Contact:";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(20, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 18);
            this.label6.TabIndex = 5;
            this.label6.Text = "Remark:";
            // 
            // dateedtDate
            // 
            this.dateedtDate.EditValue = new System.DateTime(2006, 1, 28, 0, 0, 0, 0);
            this.dateedtDate.Location = new System.Drawing.Point(136, 12);
            this.dateedtDate.Name = "dateedtDate";
            this.dateedtDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateedtDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dateedtDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateedtDate.Size = new System.Drawing.Size(152, 20);
            this.dateedtDate.TabIndex = 0;
            // 
            // luedtContact
            // 
            this.luedtContact.Location = new System.Drawing.Point(136, 126);
            this.luedtContact.Name = "luedtContact";
            this.luedtContact.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luedtContact.Size = new System.Drawing.Size(152, 20);
            this.luedtContact.TabIndex = 4;
            // 
            // memoedtRemark
            // 
            this.memoedtRemark.EditValue = "";
            this.memoedtRemark.Location = new System.Drawing.Point(136, 193);
            this.memoedtRemark.Name = "memoedtRemark";
            this.memoedtRemark.Properties.MaxLength = 1000;
            this.memoedtRemark.Size = new System.Drawing.Size(436, 184);
            this.memoedtRemark.TabIndex = 5;
            // 
            // sbtnSave
            // 
            this.sbtnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnSave.Location = new System.Drawing.Point(415, 396);
            this.sbtnSave.Name = "sbtnSave";
            this.sbtnSave.Size = new System.Drawing.Size(75, 23);
            this.sbtnSave.TabIndex = 6;
            this.sbtnSave.Text = "Save";
            this.sbtnSave.Click += new System.EventHandler(this.sbtnSave_Click);
            // 
            // sbtnCancel
            // 
            this.sbtnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.sbtnCancel.Location = new System.Drawing.Point(497, 396);
            this.sbtnCancel.Name = "sbtnCancel";
            this.sbtnCancel.Size = new System.Drawing.Size(75, 23);
            this.sbtnCancel.TabIndex = 8;
            this.sbtnCancel.Text = "Cancel";
            // 
            // txtBranchCode
            // 
            this.txtBranchCode.EditValue = "";
            this.txtBranchCode.Enabled = false;
            this.txtBranchCode.Location = new System.Drawing.Point(136, 162);
            this.txtBranchCode.Name = "txtBranchCode";
            this.txtBranchCode.Properties.MaxLength = 50;
            this.txtBranchCode.Size = new System.Drawing.Size(100, 20);
            this.txtBranchCode.TabIndex = 110;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(18, 164);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 18);
            this.label7.TabIndex = 111;
            this.label7.Text = "Branch Code :";
            // 
            // dateedtEndTime
            // 
            this.dateedtEndTime.EditValue = new System.DateTime(2013, 1, 1, 13, 0, 0, 0);
            this.dateedtEndTime.Location = new System.Drawing.Point(136, 68);
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
            this.dateedtEndTime.TabIndex = 113;
            // 
            // dateedtStartTime
            // 
            this.dateedtStartTime.EditValue = new System.DateTime(2013, 1, 1, 13, 0, 0, 0);
            this.dateedtStartTime.Location = new System.Drawing.Point(136, 40);
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
            this.dateedtStartTime.TabIndex = 112;
            // 
            // rbNew
            // 
            this.rbNew.AutoSize = true;
            this.rbNew.Checked = true;
            this.rbNew.Location = new System.Drawing.Point(136, 103);
            this.rbNew.Name = "rbNew";
            this.rbNew.Size = new System.Drawing.Size(74, 17);
            this.rbNew.TabIndex = 115;
            this.rbNew.TabStop = true;
            this.rbNew.Text = "New Lead";
            this.rbNew.UseVisualStyleBackColor = true;
            this.rbNew.CheckedChanged += new System.EventHandler(this.rbNew_CheckedChanged);
            // 
            // rbExisting
            // 
            this.rbExisting.AutoSize = true;
            this.rbExisting.Location = new System.Drawing.Point(225, 103);
            this.rbExisting.Name = "rbExisting";
            this.rbExisting.Size = new System.Drawing.Size(102, 17);
            this.rbExisting.TabIndex = 114;
            this.rbExisting.Text = "Existing Member";
            this.rbExisting.UseVisualStyleBackColor = true;
            this.rbExisting.CheckedChanged += new System.EventHandler(this.rbExisting_CheckedChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(20, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 18);
            this.label4.TabIndex = 118;
            this.label4.Text = "Type :";
            // 
            // ucMemberID1
            // 
            this.ucMemberID1.EditValue = "";
            this.ucMemberID1.EditValueChanged = null;
            this.ucMemberID1.Location = new System.Drawing.Point(136, 126);
            this.ucMemberID1.Name = "ucMemberID1";
            this.ucMemberID1.Size = new System.Drawing.Size(184, 20);
            this.ucMemberID1.StrBranchCode = null;
            this.ucMemberID1.TabIndex = 117;
            // 
            // frmAppointment
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(584, 431);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ucMemberID1);
            this.Controls.Add(this.rbNew);
            this.Controls.Add(this.rbExisting);
            this.Controls.Add(this.dateedtEndTime);
            this.Controls.Add(this.dateedtStartTime);
            this.Controls.Add(this.txtBranchCode);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.sbtnSave);
            this.Controls.Add(this.sbtnCancel);
            this.Controls.Add(this.memoedtRemark);
            this.Controls.Add(this.luedtContact);
            this.Controls.Add(this.dateedtDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblContact);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAppointment";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "{0} Appointment";
            this.Load += new System.EventHandler(this.frmAppointment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dateedtDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateedtDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luedtContact.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoedtRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBranchCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateedtEndTime.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateedtEndTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateedtStartTime.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateedtStartTime.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void sbtnSave_Click(object sender, System.EventArgs e)
		{
			if (!ValidateBeforeSave())
			{
				DialogResult = DialogResult.None;
				return;
			}
			ACMSLogic.Staff.Appointment myAppointment = new ACMSLogic.Staff.Appointment();
			// New

            StartDateTime = Convert.ToDateTime(dateedtStartTime.Text);
            EndDateTime = Convert.ToDateTime(dateedtEndTime.Text);
            
            string strMembershipID;
            int intContact;
            intContact = 0;
            strMembershipID = "";
            if (rbExisting.Checked )
            {
                strMembershipID = ucMemberID1.EditValue.ToString();
            }
            else
            {
                intContact = Convert.ToInt32(luedtContact.EditValue);
            }

            if (nAppointmentID < 0)
            {
                myAppointment.NewAppoinment(nEmployeeID, dateedtDate.DateTime, StartDateTime,
                   EndDateTime, "", txtBranchCode.Text, intContact, memoedtRemark.Text, strMembershipID);
                DialogResult = DialogResult.OK;
            }
            else
          
			{
                myAppointment.EditAppointment(nAppointmentID, nEmployeeID, dateedtDate.DateTime, StartDateTime,
                    EndDateTime, "", txtBranchCode.Text, intContact, memoedtRemark.Text, 1, strMembershipID);
				DialogResult = DialogResult.OK;
			}
		}
        
		private bool ValidateBeforeSave()
		{ 

            if (rbExisting.Checked )
            {
                if (ucMemberID1.ToString() == "")
                {
                    UI.ShowErrorMessage(this, "Please select a Exising Member.");
                    ucMemberID1.Focus();
                    return false;
                }
            }

            if (rbNew.Checked)
            {
                if (luedtContact.EditValue == null)
                {
                    UI.ShowErrorMessage(this, "Please select a Call List.");
                    luedtContact.Focus();
                    return false;
                }
            }

			return true;
		}


        private void frmAppointment_Load(object sender, EventArgs e)
        {

            ucMemberID1.StrBranchCode = txtBranchCode.Text;
          
        }

        private void rbNew_CheckedChanged(object sender, EventArgs e)
        {

            ucMemberID1.Visible = false;
            luedtContact.Visible = true;
            lblContact.Text = "New Lead";
        }

        private void rbExisting_CheckedChanged(object sender, EventArgs e)
        {

            ucMemberID1.Visible = true;
            luedtContact.Visible = false;
            lblContact.Text = "Existing Member";
        }




	}
}
