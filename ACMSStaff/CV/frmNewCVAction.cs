using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ACMSDAL;
using ACMSLogic;
using ACMSLogic.Staff;
using ACMS.Utils;

namespace ACMS.CV
{
	/// <summary>
	/// Summary description for frmEditCV.
	/// </summary>
	public class frmNewCVAction : System.Windows.Forms.Form
	{
		private ACMSLogic.Staff.CV myCV;
		private int nCaseID;
		private int nEmployeeID;
		private DataSet myCVActionDataSet;
		private DataSet myCVCaseDataSet;
		internal DevExpress.XtraEditors.SimpleButton sbtnCancel;
		internal DevExpress.XtraEditors.SimpleButton sbtnSave;
		private DevExpress.XtraEditors.MemoEdit mmEdtDetail;
		private DevExpress.XtraEditors.LookUpEdit lkpEdtMode;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.LookUpEdit lkpEdtStatus;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public string CaseStatus
		{
			get 
			{
				if (ACMS.Convert.ToInt32(lkpEdtStatus.EditValue) == 0)
					return "New";
				else if (ACMS.Convert.ToInt32(lkpEdtStatus.EditValue) == 1)
					return "Pending";
				else
					return "Closed";
			}
		}

		public frmNewCVAction(int nEmployeeID, int nCaseID)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			this.nCaseID = nCaseID;
			this.nEmployeeID = nEmployeeID;
			myCV = new ACMSLogic.Staff.CV();
			myCVActionDataSet = myCV.LoadNewCVAction();
			myCVCaseDataSet = myCV.LoadCV(nCaseID);
			BindData();
			TblCaseMode mode = new TblCaseMode();
			DataTable modeTable = mode.SelectAll();
			new XtraUtils.LookupEditBuilder.CaseModeLookupEditBuilder(modeTable, lkpEdtMode.Properties);

			new XtraUtils.LookupEditBuilder.CVStatusLookupEditBuilder(lkpEdtStatus.Properties);
		}

		private void BindData()
		{
			lkpEdtMode.DataBindings.Clear();
			lkpEdtStatus.DataBindings.Clear();
			mmEdtDetail.DataBindings.Clear();
			
			lkpEdtMode.DataBindings.Add("EditValue", myCVActionDataSet.Tables[0], "nModeID");
			lkpEdtStatus.DataBindings.Add("EditValue", myCVCaseDataSet.Tables[0], "nStatusID");
			mmEdtDetail.DataBindings.Add("EditValue", myCVActionDataSet.Tables[0], "strActionDetails");
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
			this.sbtnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnSave = new DevExpress.XtraEditors.SimpleButton();
			this.mmEdtDetail = new DevExpress.XtraEditors.MemoEdit();
			this.lkpEdtMode = new DevExpress.XtraEditors.LookUpEdit();
			this.label10 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.lkpEdtStatus = new DevExpress.XtraEditors.LookUpEdit();
			((System.ComponentModel.ISupportInitialize)(this.mmEdtDetail.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtMode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtStatus.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// sbtnCancel
			// 
			this.sbtnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.sbtnCancel.Location = new System.Drawing.Point(244, 184);
			this.sbtnCancel.Name = "sbtnCancel";
			this.sbtnCancel.Size = new System.Drawing.Size(72, 20);
			this.sbtnCancel.TabIndex = 4;
			this.sbtnCancel.Text = "Cancel";
			// 
			// sbtnSave
			// 
			this.sbtnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.sbtnSave.Location = new System.Drawing.Point(164, 184);
			this.sbtnSave.Name = "sbtnSave";
			this.sbtnSave.Size = new System.Drawing.Size(72, 20);
			this.sbtnSave.TabIndex = 3;
			this.sbtnSave.Text = "Save";
			this.sbtnSave.Click += new System.EventHandler(this.sbtnSave_Click);
			// 
			// mmEdtDetail
			// 
			this.mmEdtDetail.EditValue = "";
			this.mmEdtDetail.Location = new System.Drawing.Point(80, 70);
			this.mmEdtDetail.Name = "mmEdtDetail";
			// 
			// mmEdtDetail.Properties
			// 
			this.mmEdtDetail.Properties.MaxLength = 1000;
			this.mmEdtDetail.Size = new System.Drawing.Size(236, 102);
			this.mmEdtDetail.TabIndex = 2;
			// 
			// lkpEdtMode
			// 
			this.lkpEdtMode.Location = new System.Drawing.Point(80, 10);
			this.lkpEdtMode.Name = "lkpEdtMode";
			// 
			// lkpEdtMode.Properties
			// 
			this.lkpEdtMode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkpEdtMode.Size = new System.Drawing.Size(236, 20);
			this.lkpEdtMode.TabIndex = 0;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(14, 70);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(54, 30);
			this.label10.TabIndex = 37;
			this.label10.Text = "Action Taken";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(14, 40);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(54, 20);
			this.label8.TabIndex = 36;
			this.label8.Text = "Status";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(14, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(54, 20);
			this.label1.TabIndex = 40;
			this.label1.Text = "Mode";
			// 
			// lkpEdtStatus
			// 
			this.lkpEdtStatus.Location = new System.Drawing.Point(80, 40);
			this.lkpEdtStatus.Name = "lkpEdtStatus";
			// 
			// lkpEdtStatus.Properties
			// 
			this.lkpEdtStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkpEdtStatus.Size = new System.Drawing.Size(236, 20);
			this.lkpEdtStatus.TabIndex = 1;
			// 
			// frmNewCVAction
			// 
			this.AcceptButton = this.sbtnSave;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.sbtnCancel;
			this.ClientSize = new System.Drawing.Size(328, 216);
			this.Controls.Add(this.lkpEdtStatus);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.mmEdtDetail);
			this.Controls.Add(this.lkpEdtMode);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.sbtnCancel);
			this.Controls.Add(this.sbtnSave);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmNewCVAction";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "New CV Action";
			((System.ComponentModel.ISupportInitialize)(this.mmEdtDetail.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtMode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtStatus.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void sbtnSave_Click(object sender, System.EventArgs e)
		{
			if (lkpEdtMode.EditValue == null || ACMS.Convert.ToInt32(lkpEdtMode.EditValue) == -1)
			{
				UI.ShowErrorMessage(this, "Please fill in Mode first.", "Error");
				lkpEdtMode.Focus();
				DialogResult = DialogResult.None;
				return;
			}
			this.BindingContext[myCVActionDataSet.Tables[0]].EndCurrentEdit();
			this.BindingContext[myCVCaseDataSet.Tables[0]].EndCurrentEdit();
			myCVActionDataSet.Tables[0].Rows[0]["nActionByID"] = nEmployeeID;
			myCVActionDataSet.Tables[0].Rows[0]["dtDate"] = DateTime.Now;
			myCVActionDataSet.Tables[0].Rows[0]["nCaseID"] = nCaseID;
			myCVCaseDataSet.Tables[0].Rows[0]["nEmployeeID"] = nEmployeeID;
			myCVCaseDataSet.Tables[0].Rows[0]["dtLastEditDate"] = DateTime.Now;
			myCV.SaveNewCVAction(myCVActionDataSet, nCaseID, myCVCaseDataSet);

			DialogResult = DialogResult.OK;
		}
	}
}
