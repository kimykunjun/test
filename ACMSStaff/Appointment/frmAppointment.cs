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
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private DevExpress.XtraEditors.SimpleButton sbtnSave;
		private DevExpress.XtraEditors.SimpleButton sbtnCancel;
		private DevExpress.XtraEditors.DateEdit dateedtDate;
		private DevExpress.XtraEditors.DateEdit dateedtEndTime;
		private DevExpress.XtraEditors.DateEdit dateedtStartTime;
		private DevExpress.XtraEditors.TextEdit txtOrganization;
		private DevExpress.XtraEditors.LookUpEdit luedtContact;
		private DevExpress.XtraEditors.LookUpEdit luedtAppointmetType;
		private DevExpress.XtraEditors.MemoEdit memoedtRemark;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DateTime Date
		{
			set { dateedtDate.EditValue = value; }
		}

		public DateTime StartTime
		{ 
			set { dateedtStartTime.EditValue = value; }
		}

		public DateTime EndTime
		{
			set { dateedtEndTime.EditValue = value; }
		}

		public string Organization
		{
			set { txtOrganization.EditValue = value; }
		}

		public int AppointmetnType
		{
			set { luedtAppointmetType.EditValue = value; }
		}

		public int ContactID
		{ 
			set { luedtContact.EditValue = value; }
		}

		public string Remark
		{
			set { memoedtRemark.EditValue = value; }
		}

		public frmAppointment(int nEmployeeID, int nAppointmentID)
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

			if (nAppointmentID < 0)
				this.Text = string.Format(this.Text, "New");
			else
				this.Text = string.Format(this.Text, "Edit") +" - ID: " +nAppointmentID;

			new XtraUtils.LookupEditBuilder.ContactsLookupEditBuilder(luedtContact.Properties, nEmployeeID);
			new XtraUtils.LookupEditBuilder.AppointmentTypeLookupEditBuilder(luedtAppointmetType.Properties);

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
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.dateedtDate = new DevExpress.XtraEditors.DateEdit();
			this.dateedtEndTime = new DevExpress.XtraEditors.DateEdit();
			this.dateedtStartTime = new DevExpress.XtraEditors.DateEdit();
			this.txtOrganization = new DevExpress.XtraEditors.TextEdit();
			this.luedtContact = new DevExpress.XtraEditors.LookUpEdit();
			this.luedtAppointmetType = new DevExpress.XtraEditors.LookUpEdit();
			this.label7 = new System.Windows.Forms.Label();
			this.memoedtRemark = new DevExpress.XtraEditors.MemoEdit();
			this.sbtnSave = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnCancel = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.dateedtDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dateedtEndTime.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dateedtStartTime.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtOrganization.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.luedtContact.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.luedtAppointmetType.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.memoedtRemark.Properties)).BeginInit();
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
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(20, 98);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 44);
			this.label4.TabIndex = 3;
			this.label4.Text = "Organization / Place of appoinment:";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(20, 180);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(78, 18);
			this.label5.TabIndex = 4;
			this.label5.Text = "Contact:";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(20, 208);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(78, 18);
			this.label6.TabIndex = 5;
			this.label6.Text = "Remark:";
			// 
			// dateedtDate
			// 
			this.dateedtDate.EditValue = new System.DateTime(2006, 1, 28, 0, 0, 0, 0);
			this.dateedtDate.Location = new System.Drawing.Point(120, 12);
			this.dateedtDate.Name = "dateedtDate";
			// 
			// dateedtDate.Properties
			// 
			this.dateedtDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dateedtDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
			this.dateedtDate.Size = new System.Drawing.Size(152, 20);
			this.dateedtDate.TabIndex = 0;
			// 
			// dateedtEndTime
			// 
			this.dateedtEndTime.EditValue = new System.DateTime(2006, 1, 1, 0, 0, 0, 0);
			this.dateedtEndTime.Location = new System.Drawing.Point(120, 68);
			this.dateedtEndTime.Name = "dateedtEndTime";
			// 
			// dateedtEndTime.Properties
			// 
			this.dateedtEndTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, null)});
			this.dateedtEndTime.Properties.DisplayFormat.FormatString = "hh:mm tt";
			this.dateedtEndTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.dateedtEndTime.Properties.EditFormat.FormatString = "hh:mm tt";
			this.dateedtEndTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.dateedtEndTime.Properties.Mask.EditMask = "hh:mm tt";
			this.dateedtEndTime.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
			this.dateedtEndTime.TabIndex = 2;
			// 
			// dateedtStartTime
			// 
			this.dateedtStartTime.EditValue = new System.DateTime(2006, 1, 1, 0, 0, 0, 0);
			this.dateedtStartTime.Location = new System.Drawing.Point(120, 40);
			this.dateedtStartTime.Name = "dateedtStartTime";
			// 
			// dateedtStartTime.Properties
			// 
			this.dateedtStartTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, null)});
			this.dateedtStartTime.Properties.DisplayFormat.FormatString = "hh:mm tt";
			this.dateedtStartTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.dateedtStartTime.Properties.EditFormat.FormatString = "hh:mm tt";
			this.dateedtStartTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.dateedtStartTime.Properties.Mask.EditMask = "hh:mm tt";
			this.dateedtStartTime.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
			this.dateedtStartTime.TabIndex = 1;
			// 
			// txtOrganization
			// 
			this.txtOrganization.EditValue = "";
			this.txtOrganization.Location = new System.Drawing.Point(120, 98);
			this.txtOrganization.Name = "txtOrganization";
			// 
			// txtOrganization.Properties
			// 
			this.txtOrganization.Properties.MaxLength = 50;
			this.txtOrganization.Size = new System.Drawing.Size(330, 20);
			this.txtOrganization.TabIndex = 3;
			// 
			// luedtContact
			// 
			this.luedtContact.Location = new System.Drawing.Point(120, 178);
			this.luedtContact.Name = "luedtContact";
			// 
			// luedtContact.Properties
			// 
			this.luedtContact.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.luedtContact.Size = new System.Drawing.Size(152, 20);
			this.luedtContact.TabIndex = 5;
			// 
			// luedtAppointmetType
			// 
			this.luedtAppointmetType.Location = new System.Drawing.Point(120, 150);
			this.luedtAppointmetType.Name = "luedtAppointmetType";
			// 
			// luedtAppointmetType.Properties
			// 
			this.luedtAppointmetType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																														new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.luedtAppointmetType.Size = new System.Drawing.Size(152, 20);
			this.luedtAppointmetType.TabIndex = 4;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(20, 152);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(100, 18);
			this.label7.TabIndex = 39;
			this.label7.Text = "Appointment Type:";
			// 
			// memoedtRemark
			// 
			this.memoedtRemark.EditValue = "";
			this.memoedtRemark.Location = new System.Drawing.Point(120, 208);
			this.memoedtRemark.Name = "memoedtRemark";
			// 
			// memoedtRemark.Properties
			// 
			this.memoedtRemark.Properties.MaxLength = 50;
			this.memoedtRemark.Size = new System.Drawing.Size(330, 106);
			this.memoedtRemark.TabIndex = 6;
			// 
			// sbtnSave
			// 
			this.sbtnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnSave.Location = new System.Drawing.Point(306, 324);
			this.sbtnSave.Name = "sbtnSave";
			this.sbtnSave.TabIndex = 7;
			this.sbtnSave.Text = "Save";
			this.sbtnSave.Click += new System.EventHandler(this.sbtnSave_Click);
			// 
			// sbtnCancel
			// 
			this.sbtnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.sbtnCancel.Location = new System.Drawing.Point(388, 324);
			this.sbtnCancel.Name = "sbtnCancel";
			this.sbtnCancel.TabIndex = 8;
			this.sbtnCancel.Text = "Cancel";
			// 
			// frmAppointment
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(470, 354);
			this.Controls.Add(this.sbtnSave);
			this.Controls.Add(this.sbtnCancel);
			this.Controls.Add(this.memoedtRemark);
			this.Controls.Add(this.luedtAppointmetType);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.luedtContact);
			this.Controls.Add(this.txtOrganization);
			this.Controls.Add(this.dateedtEndTime);
			this.Controls.Add(this.dateedtStartTime);
			this.Controls.Add(this.dateedtDate);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
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
			((System.ComponentModel.ISupportInitialize)(this.dateedtDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dateedtEndTime.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dateedtStartTime.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtOrganization.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.luedtContact.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.luedtAppointmetType.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.memoedtRemark.Properties)).EndInit();
			this.ResumeLayout(false);

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
			if (nAppointmentID < 0)
			{
				myAppointment.NewAppoinment(nEmployeeID, dateedtDate.DateTime, dateedtStartTime.DateTime,
					dateedtEndTime.DateTime, txtOrganization.Text, Convert.ToInt32(luedtAppointmetType.EditValue),
					Convert.ToInt32(luedtContact.EditValue), memoedtRemark.Text);
				DialogResult = DialogResult.OK;
			}
			else
			{
				myAppointment.EditAppointment(nAppointmentID, dateedtDate.DateTime, dateedtStartTime.DateTime,
					dateedtEndTime.DateTime, txtOrganization.Text, Convert.ToInt32(luedtAppointmetType.EditValue),
					Convert.ToInt32(luedtContact.EditValue), memoedtRemark.Text);
				DialogResult = DialogResult.OK;
			}
		}

		private bool ValidateBeforeSave()
		{
			if (txtOrganization.Text.Length == 0)
			{
				UI.ShowErrorMessage("Please enter an Organization.");
				txtOrganization.Focus();
				return false;
			}
			else if (luedtAppointmetType.EditValue == null)
			{
				UI.ShowErrorMessage("Please select an Appointment Type.");
				luedtAppointmetType.Focus();
				return false;
			}
			else if (luedtContact.EditValue == null)
			{
				UI.ShowErrorMessage(this, "Please select a contact.");
				luedtContact.Focus();
				return false;
			}
			return true;
		}
	}
}
