using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ACMSDAL;

namespace ACMS.ACMSStaff.CV
{
	/// <summary>
	/// Summary description for frmAssignCV.
	/// </summary>
	public class frmAssignCV : System.Windows.Forms.Form
	{
		private DevExpress.XtraEditors.SimpleButton sbtnAssign;
		private DevExpress.XtraEditors.SimpleButton sbtnCancel;
		private DevExpress.XtraEditors.LookUpEdit lkpEdtDeptID;
		private System.Windows.Forms.Label label4;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public int SelectedDepartmentID
		{
			get {return (int)lkpEdtDeptID.EditValue;}
		}

		public frmAssignCV(object nDepartmentID)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			TblDepartment department = new TblDepartment();
			DataTable deptTable = department.SelectAll();
			new XtraUtils.LookupEditBuilder.DepartmentLookupEditBuilder(deptTable, lkpEdtDeptID.Properties);

			lkpEdtDeptID.EditValue = nDepartmentID;
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
			this.sbtnAssign = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.lkpEdtDeptID = new DevExpress.XtraEditors.LookUpEdit();
			this.label4 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtDeptID.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// sbtnAssign
			// 
			this.sbtnAssign.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnAssign.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.sbtnAssign.Location = new System.Drawing.Point(128, 44);
			this.sbtnAssign.Name = "sbtnAssign";
			this.sbtnAssign.TabIndex = 1;
			this.sbtnAssign.Text = "Assign";
			this.sbtnAssign.Click += new System.EventHandler(this.sbtnAssign_Click);
			// 
			// sbtnCancel
			// 
			this.sbtnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.sbtnCancel.Location = new System.Drawing.Point(210, 44);
			this.sbtnCancel.Name = "sbtnCancel";
			this.sbtnCancel.TabIndex = 2;
			this.sbtnCancel.Text = "Cancel";
			// 
			// lkpEdtDeptID
			// 
			this.lkpEdtDeptID.Location = new System.Drawing.Point(90, 12);
			this.lkpEdtDeptID.Name = "lkpEdtDeptID";
			// 
			// lkpEdtDeptID.Properties
			// 
			this.lkpEdtDeptID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkpEdtDeptID.Size = new System.Drawing.Size(194, 20);
			this.lkpEdtDeptID.TabIndex = 0;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(6, 12);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(80, 20);
			this.label4.TabIndex = 22;
			this.label4.Text = "Department ID";
			// 
			// frmAssignCV
			// 
			this.AcceptButton = this.sbtnAssign;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.sbtnCancel;
			this.ClientSize = new System.Drawing.Size(292, 72);
			this.Controls.Add(this.lkpEdtDeptID);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.sbtnCancel);
			this.Controls.Add(this.sbtnAssign);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmAssignCV";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Assign CV";
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtDeptID.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void sbtnAssign_Click(object sender, System.EventArgs e)
		{
			if (lkpEdtDeptID.EditValue == null || lkpEdtDeptID.EditValue.ToString().Length == 0)
			{
				ACMS.Utils.UI.ShowErrorMessage(this, "Please select an Department ID.", "Error");
				lkpEdtDeptID.Focus();
				DialogResult = DialogResult.None;
				return;
			}
			else
				DialogResult = DialogResult.OK;
		}
	}
}
