using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ACMS
{
	/// <summary>
	/// Summary description for FormUpdateClassAttendance.
	/// </summary>
	public class FormUpdateClassAttendance : System.Windows.Forms.Form
	{
		private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
		private DevExpress.XtraEditors.SimpleButton simpleButtonOK;
		private DevExpress.XtraEditors.LookUpEdit lkpEdtPackageID;
		private System.Windows.Forms.Label label5;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		
		private ACMS.XtraUtils.LookupEditBuilder.MemberPackageIDLookupEditBuilder myMemberPackageIDLookupEditBuilder;
		private string myMembershipID;

        public FormUpdateClassAttendance(string membershipID, DateTime dtAttendedDate)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            myMembershipID = membershipID;
            myMemberPackageIDLookupEditBuilder = new ACMS.XtraUtils.LookupEditBuilder.MemberPackageIDLookupEditBuilder(lkpEdtPackageID.Properties, myMembershipID, false, dtAttendedDate);
        }

		public int PackageID
		{
			get { return ACMS.Convert.ToInt32(lkpEdtPackageID.EditValue);}
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
			this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
			this.lkpEdtPackageID = new DevExpress.XtraEditors.LookUpEdit();
			this.label5 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtPackageID.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// simpleButtonCancel
			// 
			this.simpleButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.simpleButtonCancel.Location = new System.Drawing.Point(192, 48);
			this.simpleButtonCancel.Name = "simpleButtonCancel";
			this.simpleButtonCancel.TabIndex = 55;
			this.simpleButtonCancel.Text = "Cancel";
			// 
			// simpleButtonOK
			// 
			this.simpleButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.simpleButtonOK.Location = new System.Drawing.Point(96, 48);
			this.simpleButtonOK.Name = "simpleButtonOK";
			this.simpleButtonOK.TabIndex = 54;
			this.simpleButtonOK.Text = "OK";
			this.simpleButtonOK.Click += new System.EventHandler(this.simpleButtonOK_Click);
			// 
			// lkpEdtPackageID
			// 
			this.lkpEdtPackageID.EditValue = "";
			this.lkpEdtPackageID.Location = new System.Drawing.Point(104, 8);
			this.lkpEdtPackageID.Name = "lkpEdtPackageID";
			// 
			// lkpEdtPackageID.Properties
			// 
			this.lkpEdtPackageID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkpEdtPackageID.Size = new System.Drawing.Size(202, 20);
			this.lkpEdtPackageID.TabIndex = 64;
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.Location = new System.Drawing.Point(24, 8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(72, 23);
			this.label5.TabIndex = 65;
			this.label5.Text = "Package ID";
			// 
			// FormUpdateClassAttendance
			// 
			this.AcceptButton = this.simpleButtonOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.simpleButtonCancel;
			this.ClientSize = new System.Drawing.Size(360, 78);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.lkpEdtPackageID);
			this.Controls.Add(this.simpleButtonCancel);
			this.Controls.Add(this.simpleButtonOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormUpdateClassAttendance";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Change Package";
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtPackageID.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void simpleButtonOK_Click(object sender, System.EventArgs e)
		{
			if (lkpEdtPackageID.Text == "")
			{
				MessageBox.Show(this, "Please select a Package ID.");
				this.DialogResult = DialogResult.None;
				return;
			}
		}
	}
}
