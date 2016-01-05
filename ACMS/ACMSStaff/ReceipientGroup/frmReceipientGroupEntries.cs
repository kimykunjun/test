using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ACMS.Utils;
using ACMSLogic;
using ACMSDAL;

namespace ACMS.ACMSStaff.ReceipientGroup
{
	/// <summary>
	/// Summary description for frmNewReceipientGroup.
	/// </summary>
	public class frmReceipientGroupEntries : System.Windows.Forms.Form
	{
		private int nMemoGroupID;

		private System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.SimpleButton sbtnSave;
		private DevExpress.XtraEditors.SimpleButton sbtnCancel;
		private DevExpress.XtraEditors.LookUpEdit lkpEdtStaffID;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="nMemoGroupID"></param>
		public frmReceipientGroupEntries(int nMemoGroupID)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			this.nMemoGroupID = nMemoGroupID;

			TblEmployee employee = new TblEmployee();
			DataTable empTable = employee.SelectAll();
			new XtraUtils.LookupEditBuilder.EmployeeIDLookupEditBuilder(lkpEdtStaffID.Properties);
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
            this.sbtnSave = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.lkpEdtStaffID = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpEdtStaffID.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(20, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Employee ID:";
            // 
            // sbtnSave
            // 
            this.sbtnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.sbtnSave.Location = new System.Drawing.Point(120, 44);
            this.sbtnSave.Name = "sbtnSave";
            this.sbtnSave.Size = new System.Drawing.Size(75, 23);
            this.sbtnSave.TabIndex = 1;
            this.sbtnSave.Text = "Save";
            this.sbtnSave.Click += new System.EventHandler(this.sbtnSave_Click);
            // 
            // sbtnCancel
            // 
            this.sbtnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.sbtnCancel.Location = new System.Drawing.Point(202, 44);
            this.sbtnCancel.Name = "sbtnCancel";
            this.sbtnCancel.Size = new System.Drawing.Size(75, 23);
            this.sbtnCancel.TabIndex = 2;
            this.sbtnCancel.Text = "Cancel";
            // 
            // lkpEdtStaffID
            // 
            this.lkpEdtStaffID.Location = new System.Drawing.Point(96, 12);
            this.lkpEdtStaffID.Name = "lkpEdtStaffID";
            this.lkpEdtStaffID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpEdtStaffID.Size = new System.Drawing.Size(180, 20);
            this.lkpEdtStaffID.TabIndex = 0;
            // 
            // frmReceipientGroupEntries
            // 
            this.AcceptButton = this.sbtnSave;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.sbtnCancel;
            this.ClientSize = new System.Drawing.Size(284, 76);
            this.Controls.Add(this.lkpEdtStaffID);
            this.Controls.Add(this.sbtnSave);
            this.Controls.Add(this.sbtnCancel);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReceipientGroupEntries";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Receipient Group Entries";
            ((System.ComponentModel.ISupportInitialize)(this.lkpEdtStaffID.Properties)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void sbtnSave_Click(object sender, System.EventArgs e)
		{
			if (lkpEdtStaffID.EditValue == null)
			{
				UI.ShowErrorMessage("Please select an Employee ID.");
				lkpEdtStaffID.Focus();
				DialogResult = DialogResult.None;
				return;
			}			

			ACMSLogic.Staff.ReceipientGroup myReceipientGroup = new ACMSLogic.Staff.ReceipientGroup();
			if (!myReceipientGroup.NewReceipientGroupEntries(nMemoGroupID, Convert.ToInt32(lkpEdtStaffID.EditValue)))
				DialogResult = DialogResult.None;
			else
				DialogResult = DialogResult.OK;
		}
	}
}
