using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ACMS.Utils;

namespace ACMS.ACMSStaff.Contacts
{
	/// <summary>
	/// Summary description for frmContacts.
	/// </summary>
	public class frmContacts : System.Windows.Forms.Form
	{
		private int nEmployeeID;
		private int nContactID;
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.TextEdit txtContactPerson;
		private DevExpress.XtraEditors.TextEdit txtOrganization;
		private System.Windows.Forms.Label label2;
		private DevExpress.XtraEditors.TextEdit txtMobileNo;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private DevExpress.XtraEditors.TextEdit txtOfficeNo;
		private DevExpress.XtraEditors.TextEdit txtEmail;
		private System.Windows.Forms.Label label5;
		private DevExpress.XtraEditors.TextEdit txtFax;
		private System.Windows.Forms.Label label6;
		private DevExpress.XtraEditors.TextEdit txtAddress;
		private System.Windows.Forms.Label label7;
		private DevExpress.XtraEditors.SimpleButton sbtnSave;
		private DevExpress.XtraEditors.SimpleButton sbtnCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public string ContactPerson
		{
			set {txtContactPerson.Text = value;}
		}

		public string Organization
		{
			set {txtOrganization.Text = value;}
		}

		public string OfficeNo
		{
			set {txtOfficeNo.Text = value;}
		}

		public string MobileNo
		{
			set {txtMobileNo.Text = value;}
		}

		public string Fax
		{
			set {txtFax.Text = value;}
		}

		public string Email
		{
			set {txtEmail.Text = value;}
		}

		public string Address
		{
			set {txtAddress.Text = value;}
		}

		public frmContacts(int nEmployeeID, int nContactID)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			this.nEmployeeID = nEmployeeID;
			this.nContactID = nContactID;

			if (nContactID < 0)
				this.Text = string.Format(this.Text, "New");
			else
				this.Text = string.Format(this.Text, "Edit") +" - ID: " +nContactID;
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
			this.txtContactPerson = new DevExpress.XtraEditors.TextEdit();
			this.txtOrganization = new DevExpress.XtraEditors.TextEdit();
			this.label2 = new System.Windows.Forms.Label();
			this.txtMobileNo = new DevExpress.XtraEditors.TextEdit();
			this.label3 = new System.Windows.Forms.Label();
			this.txtOfficeNo = new DevExpress.XtraEditors.TextEdit();
			this.label4 = new System.Windows.Forms.Label();
			this.txtEmail = new DevExpress.XtraEditors.TextEdit();
			this.label5 = new System.Windows.Forms.Label();
			this.txtFax = new DevExpress.XtraEditors.TextEdit();
			this.label6 = new System.Windows.Forms.Label();
			this.txtAddress = new DevExpress.XtraEditors.TextEdit();
			this.label7 = new System.Windows.Forms.Label();
			this.sbtnSave = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnCancel = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.txtContactPerson.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtOrganization.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtMobileNo.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtOfficeNo.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtFax.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(90, 18);
			this.label1.TabIndex = 0;
			this.label1.Text = "Contact Person:";
			// 
			// txtContactPerson
			// 
			this.txtContactPerson.EditValue = "";
			this.txtContactPerson.Location = new System.Drawing.Point(106, 10);
			this.txtContactPerson.Name = "txtContactPerson";
			// 
			// txtContactPerson.Properties
			// 
			this.txtContactPerson.Properties.MaxLength = 50;
			this.txtContactPerson.Size = new System.Drawing.Size(280, 20);
			this.txtContactPerson.TabIndex = 0;
			// 
			// txtOrganization
			// 
			this.txtOrganization.EditValue = "";
			this.txtOrganization.Location = new System.Drawing.Point(106, 38);
			this.txtOrganization.Name = "txtOrganization";
			// 
			// txtOrganization.Properties
			// 
			this.txtOrganization.Properties.MaxLength = 50;
			this.txtOrganization.Size = new System.Drawing.Size(280, 20);
			this.txtOrganization.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(90, 18);
			this.label2.TabIndex = 2;
			this.label2.Text = "Organization:";
			// 
			// txtMobileNo
			// 
			this.txtMobileNo.EditValue = "";
			this.txtMobileNo.Location = new System.Drawing.Point(106, 66);
			this.txtMobileNo.Name = "txtMobileNo";
			// 
			// txtMobileNo.Properties
			// 
			this.txtMobileNo.Properties.MaxLength = 50;
			this.txtMobileNo.Size = new System.Drawing.Size(280, 20);
			this.txtMobileNo.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 68);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(90, 18);
			this.label3.TabIndex = 4;
			this.label3.Text = "Mobile Number:";
			// 
			// txtOfficeNo
			// 
			this.txtOfficeNo.EditValue = "";
			this.txtOfficeNo.Location = new System.Drawing.Point(106, 94);
			this.txtOfficeNo.Name = "txtOfficeNo";
			// 
			// txtOfficeNo.Properties
			// 
			this.txtOfficeNo.Properties.MaxLength = 50;
			this.txtOfficeNo.Size = new System.Drawing.Size(280, 20);
			this.txtOfficeNo.TabIndex = 3;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(12, 96);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(90, 18);
			this.label4.TabIndex = 6;
			this.label4.Text = "Office Number:";
			// 
			// txtEmail
			// 
			this.txtEmail.EditValue = "";
			this.txtEmail.Location = new System.Drawing.Point(106, 122);
			this.txtEmail.Name = "txtEmail";
			// 
			// txtEmail.Properties
			// 
			this.txtEmail.Properties.MaxLength = 50;
			this.txtEmail.Size = new System.Drawing.Size(280, 20);
			this.txtEmail.TabIndex = 4;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(12, 124);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(90, 18);
			this.label5.TabIndex = 8;
			this.label5.Text = "Email:";
			// 
			// txtFax
			// 
			this.txtFax.EditValue = "";
			this.txtFax.Location = new System.Drawing.Point(106, 150);
			this.txtFax.Name = "txtFax";
			// 
			// txtFax.Properties
			// 
			this.txtFax.Properties.MaxLength = 50;
			this.txtFax.Size = new System.Drawing.Size(280, 20);
			this.txtFax.TabIndex = 5;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(12, 152);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(90, 18);
			this.label6.TabIndex = 10;
			this.label6.Text = "Fax:";
			// 
			// txtAddress
			// 
			this.txtAddress.EditValue = "";
			this.txtAddress.Location = new System.Drawing.Point(106, 178);
			this.txtAddress.Name = "txtAddress";
			// 
			// txtAddress.Properties
			// 
			this.txtAddress.Properties.MaxLength = 255;
			this.txtAddress.Size = new System.Drawing.Size(280, 20);
			this.txtAddress.TabIndex = 6;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(12, 180);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(90, 18);
			this.label7.TabIndex = 12;
			this.label7.Text = "Address:";
			// 
			// sbtnSave
			// 
			this.sbtnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.sbtnSave.Location = new System.Drawing.Point(240, 208);
			this.sbtnSave.Name = "sbtnSave";
			this.sbtnSave.TabIndex = 7;
			this.sbtnSave.Text = "Save";
			this.sbtnSave.Click += new System.EventHandler(this.sbtnSave_Click);
			// 
			// sbtnCancel
			// 
			this.sbtnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.sbtnCancel.Location = new System.Drawing.Point(322, 208);
			this.sbtnCancel.Name = "sbtnCancel";
			this.sbtnCancel.TabIndex = 8;
			this.sbtnCancel.Text = "Cancel";
			// 
			// frmContacts
			// 
			this.AcceptButton = this.sbtnSave;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.sbtnCancel;
			this.ClientSize = new System.Drawing.Size(404, 238);
			this.Controls.Add(this.sbtnSave);
			this.Controls.Add(this.sbtnCancel);
			this.Controls.Add(this.txtAddress);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.txtFax);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txtEmail);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtOfficeNo);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtMobileNo);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtOrganization);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtContactPerson);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmContacts";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "{0} Contact";
			((System.ComponentModel.ISupportInitialize)(this.txtContactPerson.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtOrganization.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtMobileNo.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtOfficeNo.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtFax.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).EndInit();
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
			ACMSLogic.Staff.Contacts myContact = new ACMSLogic.Staff.Contacts();
			// New
			if (nContactID < 0)
			{
				myContact.NewContact(nEmployeeID, txtContactPerson.Text, txtOrganization.Text, txtOfficeNo.Text,
					txtMobileNo.Text, txtFax.Text, txtEmail.Text, txtAddress.Text);
				DialogResult = DialogResult.OK;
			}
			else
			{
				myContact.EditContact(nContactID, nEmployeeID, txtContactPerson.Text, txtOrganization.Text, txtOfficeNo.Text,
					txtMobileNo.Text, txtFax.Text, txtEmail.Text, txtAddress.Text);
				DialogResult = DialogResult.OK;
			}
		}

		private bool ValidateBeforeSave()
		{
			if (txtContactPerson.Text.Length == 0)
			{
				UI.ShowErrorMessage("Please enter an Contact person name.");
				txtContactPerson.Focus();
				return false;
			}
			else if (txtOrganization.Text.Length == 0)
			{
				UI.ShowErrorMessage("Please enter an Organization.");
				txtOrganization.Focus();
				return false;
			}
			else if (txtOfficeNo.Text.Length == 0)
			{
				UI.ShowErrorMessage("Please enter an office phone no.");
				txtOfficeNo.Focus();
				return false;
			}
			else if (txtEmail.Text.Length == 0)
			{
				UI.ShowErrorMessage("Please enter an Email address.");
				txtEmail.Focus();
				return false;
			}
			return true;
		}
	}
}
