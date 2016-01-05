using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using ACMS.Utils;
using ACMSDAL;
using ACMSLogic;
using ACMSLogic.Staff;

namespace ACMS
{
	/// <summary>
	/// Summary description for frmNewCV.
	/// </summary>
	public class frmNewCV : System.Windows.Forms.Form
	{
		private int nEmployeeID;
		private int nCaseID;
		private ACMSLogic.Staff.CV myCV;
		private DataSet myDataSet;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label10;
		private DevExpress.XtraEditors.DateEdit dateEdit1;
		private DevExpress.XtraEditors.LookUpEdit lkpEdtBranchCode;
		private DevExpress.XtraEditors.LookUpEdit lkpEdtDeptID;
		private DevExpress.XtraEditors.LookUpEdit lkpEdtCaseType;
		private DevExpress.XtraEditors.MemoEdit mmEdtDetail;
		private DevExpress.XtraEditors.LookUpEdit lkpEdtCategory;
		private System.Windows.Forms.Label label11;
		internal DevExpress.XtraEditors.SimpleButton sbtnSave;
		internal DevExpress.XtraEditors.SimpleButton sbtnCancel;
		private DevExpress.XtraEditors.TextEdit txtSubject;
		private ACMS.ucMemberID ucMemberID1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="nEmployeeID"></param>
		/// <param name="nCaseID">-1 is for New CV</param>
		public frmNewCV(int nEmployeeID, int nCaseID, string terminalBranchID)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			ACMS.XtraUtils.XtraEditors.SetDateEditFormat(this.Controls);
			this.nEmployeeID = nEmployeeID;
			this.nCaseID = nCaseID;
			myCV = new ACMSLogic.Staff.CV();
			ucMemberID1.StrBranchCode = terminalBranchID;

			if (nCaseID == -1)
			{
				myCV.LoadNewCV(terminalBranchID);
				myDataSet = myCV.NewCVDataSet;
			}
			else
			{
				this.Text = "Edit CV";
				myDataSet = myCV.LoadCV(nCaseID);
				txtSubject.Enabled = false;
				dateEdit1.Enabled = false;
				lkpEdtBranchCode.Enabled = false;
				lkpEdtDeptID.Enabled = false;
				ucMemberID1.Enabled = false;
				//lkpEdtMemberID.Enabled = false;
				//mmEdtDetail.Enabled = false;
			}

			Init();
		}
		
		private void Init()
		{
			BindData();

			TblBranch branch = new TblBranch();
			DataTable branchTable = branch.SelectAll();
			new XtraUtils.LookupEditBuilder.BranchCodeLookupEditBuilder(branchTable, lkpEdtBranchCode.Properties);
			
			TblCaseType casetype = new TblCaseType();
			DataTable caseTypeTable = casetype.SelectAll();
			new XtraUtils.LookupEditBuilder.CaseTypeLookupEditBuilder(caseTypeTable, lkpEdtCaseType.Properties);

//			TblMember member = new TblMember();
//			DataTable memberTable = member.SelectAll();
//			new XtraUtils.LookupEditBuilder.MemberIDLookupEditBuilder(memberTable, lkpEdtMemberID.Properties);
			
			TblCaseCategory category = new TblCaseCategory();
			DataTable categoryTable = category.SelectAll();
			new XtraUtils.LookupEditBuilder.CaseCategoryLookupEditBuilder(categoryTable, lkpEdtCategory.Properties);
			
			TblDepartment department = new TblDepartment();
			DataTable deptTable = department.SelectAll();
			new XtraUtils.LookupEditBuilder.DepartmentLookupEditBuilder(deptTable, lkpEdtDeptID.Properties);
		}

		private void BindData()
		{
			txtSubject.DataBindings.Clear();
			dateEdit1.DataBindings.Clear();
			lkpEdtBranchCode.DataBindings.Clear();
			lkpEdtCaseType.DataBindings.Clear();
			lkpEdtDeptID.DataBindings.Clear();
			ucMemberID1.DataBindings.Clear();
			//lkpEdtMemberID.DataBindings.Clear();
			mmEdtDetail.DataBindings.Clear();
			lkpEdtCategory.DataBindings.Clear();
			
			lkpEdtCategory.DataBindings.Add("EditValue", myDataSet.Tables[0], "nCategoryID");
			txtSubject.DataBindings.Add("EditValue", myDataSet.Tables[0], "strSubject");
			dateEdit1.DataBindings.Add("EditValue", myDataSet.Tables[0], "dtDate");
			lkpEdtBranchCode.DataBindings.Add("EditValue", myDataSet.Tables[0], "strBranchCode");
			lkpEdtCaseType.DataBindings.Add("EditValue", myDataSet.Tables[0], "nTypeID");
			lkpEdtDeptID.DataBindings.Add("EditValue", myDataSet.Tables[0], "nDepartmentID");
			ucMemberID1.DataBindings.Add("EditValue", myDataSet.Tables[0], "strMembershipID");
			//lkpEdtMemberID.DataBindings.Add("EditValue", myDataSet.Tables[0], "strMembershipID");
			mmEdtDetail.DataBindings.Add("EditValue", myDataSet.Tables[0], "strDetails");
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
			this.label10 = new System.Windows.Forms.Label();
			this.txtSubject = new DevExpress.XtraEditors.TextEdit();
			this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
			this.lkpEdtBranchCode = new DevExpress.XtraEditors.LookUpEdit();
			this.lkpEdtDeptID = new DevExpress.XtraEditors.LookUpEdit();
			this.lkpEdtCaseType = new DevExpress.XtraEditors.LookUpEdit();
			this.mmEdtDetail = new DevExpress.XtraEditors.MemoEdit();
			this.sbtnSave = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.lkpEdtCategory = new DevExpress.XtraEditors.LookUpEdit();
			this.label11 = new System.Windows.Forms.Label();
			this.ucMemberID1 = new ACMS.ucMemberID();
			((System.ComponentModel.ISupportInitialize)(this.txtSubject.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtBranchCode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtDeptID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtCaseType.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mmEdtDetail.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtCategory.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(18, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Subject";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(18, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 20);
			this.label2.TabIndex = 1;
			this.label2.Text = "Date";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(18, 68);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 20);
			this.label3.TabIndex = 2;
			this.label3.Text = "Branch Code";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(18, 96);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 20);
			this.label4.TabIndex = 3;
			this.label4.Text = "Department ID";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(18, 152);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 20);
			this.label5.TabIndex = 4;
			this.label5.Text = "CVF Type";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(18, 182);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 20);
			this.label6.TabIndex = 5;
			this.label6.Text = "Membership ID";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(18, 212);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(100, 20);
			this.label10.TabIndex = 9;
			this.label10.Text = "Detail";
			// 
			// txtSubject
			// 
			this.txtSubject.EditValue = "";
			this.txtSubject.Location = new System.Drawing.Point(142, 10);
			this.txtSubject.Name = "txtSubject";
			// 
			// txtSubject.Properties
			// 
			this.txtSubject.Properties.MaxLength = 255;
			this.txtSubject.Size = new System.Drawing.Size(236, 20);
			this.txtSubject.TabIndex = 0;
			// 
			// dateEdit1
			// 
			this.dateEdit1.EditValue = new System.DateTime(2005, 10, 21, 0, 0, 0, 0);
			this.dateEdit1.Location = new System.Drawing.Point(142, 38);
			this.dateEdit1.Name = "dateEdit1";
			// 
			// dateEdit1.Properties
			// 
			this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dateEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
			this.dateEdit1.Size = new System.Drawing.Size(236, 20);
			this.dateEdit1.TabIndex = 1;
			// 
			// lkpEdtBranchCode
			// 
			this.lkpEdtBranchCode.Location = new System.Drawing.Point(142, 66);
			this.lkpEdtBranchCode.Name = "lkpEdtBranchCode";
			// 
			// lkpEdtBranchCode.Properties
			// 
			this.lkpEdtBranchCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkpEdtBranchCode.Size = new System.Drawing.Size(236, 20);
			this.lkpEdtBranchCode.TabIndex = 2;
			// 
			// lkpEdtDeptID
			// 
			this.lkpEdtDeptID.Location = new System.Drawing.Point(142, 94);
			this.lkpEdtDeptID.Name = "lkpEdtDeptID";
			// 
			// lkpEdtDeptID.Properties
			// 
			this.lkpEdtDeptID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkpEdtDeptID.Size = new System.Drawing.Size(236, 20);
			this.lkpEdtDeptID.TabIndex = 3;
			// 
			// lkpEdtCaseType
			// 
			this.lkpEdtCaseType.Location = new System.Drawing.Point(142, 150);
			this.lkpEdtCaseType.Name = "lkpEdtCaseType";
			// 
			// lkpEdtCaseType.Properties
			// 
			this.lkpEdtCaseType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkpEdtCaseType.Size = new System.Drawing.Size(236, 20);
			this.lkpEdtCaseType.TabIndex = 5;
			// 
			// mmEdtDetail
			// 
			this.mmEdtDetail.EditValue = "";
			this.mmEdtDetail.Location = new System.Drawing.Point(142, 212);
			this.mmEdtDetail.Name = "mmEdtDetail";
			// 
			// mmEdtDetail.Properties
			// 
			this.mmEdtDetail.Properties.MaxLength = 1000;
			this.mmEdtDetail.Size = new System.Drawing.Size(236, 102);
			this.mmEdtDetail.TabIndex = 7;
			// 
			// sbtnSave
			// 
			this.sbtnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.sbtnSave.Location = new System.Drawing.Point(226, 322);
			this.sbtnSave.Name = "sbtnSave";
			this.sbtnSave.Size = new System.Drawing.Size(72, 20);
			this.sbtnSave.TabIndex = 8;
			this.sbtnSave.Text = "Save";
			this.sbtnSave.Click += new System.EventHandler(this.sbtnSave_Click);
			// 
			// sbtnCancel
			// 
			this.sbtnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.sbtnCancel.Location = new System.Drawing.Point(306, 322);
			this.sbtnCancel.Name = "sbtnCancel";
			this.sbtnCancel.Size = new System.Drawing.Size(72, 20);
			this.sbtnCancel.TabIndex = 9;
			this.sbtnCancel.Text = "Cancel";
			// 
			// lkpEdtCategory
			// 
			this.lkpEdtCategory.Location = new System.Drawing.Point(142, 122);
			this.lkpEdtCategory.Name = "lkpEdtCategory";
			// 
			// lkpEdtCategory.Properties
			// 
			this.lkpEdtCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkpEdtCategory.Size = new System.Drawing.Size(236, 20);
			this.lkpEdtCategory.TabIndex = 4;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(18, 124);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(100, 20);
			this.label11.TabIndex = 28;
			this.label11.Text = "Case Category";
			// 
			// ucMemberID1
			// 
			this.ucMemberID1.EditValue = "";
			this.ucMemberID1.EditValueChanged = null;
			this.ucMemberID1.Location = new System.Drawing.Point(142, 182);
			this.ucMemberID1.Name = "ucMemberID1";
			this.ucMemberID1.Size = new System.Drawing.Size(240, 20);
			this.ucMemberID1.StrBranchCode = null;
			this.ucMemberID1.TabIndex = 6;
			// 
			// frmNewCV
			// 
			this.AcceptButton = this.sbtnSave;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.sbtnCancel;
			this.ClientSize = new System.Drawing.Size(394, 352);
			this.Controls.Add(this.ucMemberID1);
			this.Controls.Add(this.lkpEdtCategory);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.sbtnCancel);
			this.Controls.Add(this.sbtnSave);
			this.Controls.Add(this.mmEdtDetail);
			this.Controls.Add(this.lkpEdtCaseType);
			this.Controls.Add(this.lkpEdtDeptID);
			this.Controls.Add(this.lkpEdtBranchCode);
			this.Controls.Add(this.dateEdit1);
			this.Controls.Add(this.txtSubject);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmNewCV";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "New Customer Voice";
			((System.ComponentModel.ISupportInitialize)(this.txtSubject.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtBranchCode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtDeptID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtCaseType.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mmEdtDetail.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtCategory.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void sbtnSave_Click(object sender, System.EventArgs e)
		{
			this.BindingContext[myDataSet.Tables[0]].EndCurrentEdit();
			if (!ValidateBeforeSave())
			{
				DialogResult = DialogResult.None;
				return;
			}

			myDataSet.Tables[0].Rows[0]["nEmployeeID"] = nEmployeeID;
			myDataSet.Tables[0].Rows[0]["nSubmittedByID"] = nEmployeeID;
			myDataSet.Tables[0].Rows[0]["dtLastEditDate"] = DateTime.Now;
			if (Convert.ToInt32(myDataSet.Tables[0].Rows[0]["nCategoryID"]) == 1)
				myDataSet.Tables[0].Rows[0]["nStaffID"] = nEmployeeID;
			else
				myDataSet.Tables[0].Rows[0]["nStaffID"] = DBNull.Value;

			try 
			{
				if (nCaseID == -1)
				{
					myDataSet.Tables[0].Rows[0]["nSubmittedByID"] = nEmployeeID;
					myDataSet.Tables[0].Rows[0]["nStatusID"] = CVStatusID.New;
					myCV.SaveNewCV();
				}
				else
				{
					myCV.SaveCV(nCaseID, myDataSet);
				}
			}
			catch (SqlException ex)
			{
				if (ex.Message.IndexOf("INSERT statement conflicted with COLUMN FOREIGN KEY constraint 'FK_tblCase_tblMember'.") >= 0)
				{
					UI.ShowErrorMessage(this, "Member ID not exist. Please type again.");
					ucMemberID1.Focus();
					DialogResult = DialogResult.None;
				}	
				else
					throw;
			}
		}

		private bool ValidateBeforeSave()
		{
			if (txtSubject.Text.Length == 0)
			{
				UI.ShowErrorMessage(this, "Please enter a subject.");
				txtSubject.Focus();
				return false;
			}
			else if (dateEdit1.EditValue == null)
			{
				UI.ShowErrorMessage(this, "Please enter a date.");
				dateEdit1.Focus();
				return false;
			}
			else if (lkpEdtBranchCode.EditValue.ToString().Length == 0)
			{
				UI.ShowErrorMessage(this, "Please select a Branch Code.");
				lkpEdtBranchCode.Focus();
				return false;
			}
			else if (Convert.ToInt32(lkpEdtDeptID.EditValue) == -1)
			{
				UI.ShowErrorMessage(this, "Please select a Department.");
				lkpEdtBranchCode.Focus();
				return false;
			}
			else if (Convert.ToInt32(lkpEdtCategory.EditValue) == -1)
			{
				UI.ShowErrorMessage(this, "Please select a Case Category.");
				lkpEdtCategory.Focus();
				return false;
			}
			else if (Convert.ToInt32(lkpEdtCaseType.EditValue) == -1)
			{
				UI.ShowErrorMessage(this, "Please select a Case Type.");
				lkpEdtCaseType.Focus();
				return false;
			}
			else if (ucMemberID1.EditValue.ToString().Length == 0)
			{
				UI.ShowErrorMessage(this, "Please select a Membership Id.");
				ucMemberID1.Focus();
				return false;
			}
			else if (mmEdtDetail.Text.Length == 0)
			{
				UI.ShowErrorMessage(this, "Please enter Detail.");
				mmEdtDetail.Focus();
				return false;
			}

			return true;
		}
	}
}
