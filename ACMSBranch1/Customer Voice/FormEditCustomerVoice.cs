using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using ACMSDAL;

namespace ACMS
{
	/// <summary>
	/// Summary description for FormNewCustomerVoice.
	/// </summary>
	public class FormEditCustomerVoice : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label10;
		private DevExpress.XtraEditors.TextEdit textEdit1;
		private DevExpress.XtraEditors.LookUpEdit lkpEdtCaseType;
		private DevExpress.XtraEditors.MemoEdit mmEdtDetail;
		internal DevExpress.XtraEditors.SimpleButton SimpleButton56;
		internal DevExpress.XtraEditors.SimpleButton simpleButton1;
		private ACMSLogic.CustomerVoice myCV;
		private DevExpress.XtraEditors.LookUpEdit lkpEdtCategory;
		private System.Windows.Forms.Label label11;
		private DataTable myDataTable;
		private DevExpress.XtraEditors.DateEdit dtEdtDate;
		private int myNCaseID;
		private DevExpress.XtraEditors.TextEdit txtEdtMembershipID;
		private DevExpress.XtraEditors.TextEdit txtEdtDeptID;
		private DevExpress.XtraEditors.TextEdit txtEdtBranchCode;
		private DevExpress.XtraEditors.TextEdit txtEdtDeptAssignedID;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormEditCustomerVoice(ACMSLogic.CustomerVoice cv, int nCaseID)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			myNCaseID = nCaseID;
			myCV = cv;

			Init();
		}
		
		private void Init()
		{
			BindData();

			TblCaseType casetype = new TblCaseType();
			DataTable caseTypeTable = casetype.SelectAll();
			new XtraUtils.LookupEditBuilder.CaseTypeLookupEditBuilder(caseTypeTable, lkpEdtCaseType.Properties);
			
			TblCaseCategory category = new TblCaseCategory();
			DataTable categoryTable = category.SelectAll();
			new XtraUtils.LookupEditBuilder.CaseCategoryLookupEditBuilder(categoryTable, lkpEdtCategory.Properties);
			
		}

		private void BindData()
		{
			myDataTable = myCV.Edit(myNCaseID);
			textEdit1.DataBindings.Clear();
			dtEdtDate.DataBindings.Clear();
			txtEdtBranchCode.DataBindings.Clear();
			lkpEdtCaseType.DataBindings.Clear();
			txtEdtDeptAssignedID.DataBindings.Clear();
			txtEdtDeptID.DataBindings.Clear();
			txtEdtMembershipID.DataBindings.Clear();
//			lkpEdtStatusID.DataBindings.Clear();
//			lkpEdtSumittedBy.DataBindings.Clear();
			mmEdtDetail.DataBindings.Clear();
			lkpEdtCategory.DataBindings.Clear();
			
			lkpEdtCategory.DataBindings.Add("EditValue", myDataTable, "nCategoryID");
			textEdit1.DataBindings.Add("EditValue", myDataTable, "strSubject");
			dtEdtDate.DataBindings.Add("EditValue", myDataTable, "dtDate");
			txtEdtBranchCode.DataBindings.Add("EditValue", myDataTable, "strBranchCode");
			lkpEdtCaseType.DataBindings.Add("EditValue", myDataTable, "nTypeID");
			txtEdtDeptAssignedID.DataBindings.Add("EditValue", myDataTable, "nDepartmentAssignedID");
			txtEdtDeptID.DataBindings.Add("EditValue", myDataTable, "nDepartmentID");
			txtEdtMembershipID.DataBindings.Add("EditValue", myDataTable, "strMembershipID");
			mmEdtDetail.DataBindings.Add("EditValue", myDataTable, "strDetails");
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
			this.label8 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
			this.lkpEdtCaseType = new DevExpress.XtraEditors.LookUpEdit();
			this.mmEdtDetail = new DevExpress.XtraEditors.MemoEdit();
			this.SimpleButton56 = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
			this.lkpEdtCategory = new DevExpress.XtraEditors.LookUpEdit();
			this.label11 = new System.Windows.Forms.Label();
			this.dtEdtDate = new DevExpress.XtraEditors.DateEdit();
			this.txtEdtMembershipID = new DevExpress.XtraEditors.TextEdit();
			this.txtEdtDeptID = new DevExpress.XtraEditors.TextEdit();
			this.txtEdtBranchCode = new DevExpress.XtraEditors.TextEdit();
			this.txtEdtDeptAssignedID = new DevExpress.XtraEditors.TextEdit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtCaseType.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mmEdtDetail.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtCategory.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtEdtDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtEdtMembershipID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtEdtDeptID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtEdtBranchCode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtEdtDeptAssignedID.Properties)).BeginInit();
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
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
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
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label5.Location = new System.Drawing.Point(18, 152);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 20);
			this.label5.TabIndex = 4;
			this.label5.Text = "Case Type";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(18, 182);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 20);
			this.label6.TabIndex = 5;
			this.label6.Text = "Membership ID";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(18, 210);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(100, 20);
			this.label8.TabIndex = 7;
			this.label8.Text = "Dept. Assigned ID";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(18, 240);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(100, 20);
			this.label10.TabIndex = 9;
			this.label10.Text = "Detail";
			// 
			// textEdit1
			// 
			this.textEdit1.EditValue = "";
			this.textEdit1.Enabled = false;
			this.textEdit1.Location = new System.Drawing.Point(142, 10);
			this.textEdit1.Name = "textEdit1";
			// 
			// textEdit1.Properties
			// 
			this.textEdit1.Properties.ReadOnly = true;
			this.textEdit1.Size = new System.Drawing.Size(236, 20);
			this.textEdit1.TabIndex = 0;
			// 
			// lkpEdtCaseType
			// 
			this.lkpEdtCaseType.EditValue = "";
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
			this.mmEdtDetail.Enabled = false;
			this.mmEdtDetail.Location = new System.Drawing.Point(142, 240);
			this.mmEdtDetail.Name = "mmEdtDetail";
			// 
			// mmEdtDetail.Properties
			// 
			this.mmEdtDetail.Properties.ReadOnly = true;
			this.mmEdtDetail.Size = new System.Drawing.Size(236, 102);
			this.mmEdtDetail.TabIndex = 8;
			// 
			// SimpleButton56
			// 
			this.SimpleButton56.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.SimpleButton56.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.SimpleButton56.Location = new System.Drawing.Point(222, 352);
			this.SimpleButton56.Name = "SimpleButton56";
			this.SimpleButton56.Size = new System.Drawing.Size(72, 20);
			this.SimpleButton56.TabIndex = 9;
			this.SimpleButton56.Text = "Save";
			this.SimpleButton56.Click += new System.EventHandler(this.SimpleButton56_Click);
			// 
			// simpleButton1
			// 
			this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.simpleButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.simpleButton1.Location = new System.Drawing.Point(302, 352);
			this.simpleButton1.Name = "simpleButton1";
			this.simpleButton1.Size = new System.Drawing.Size(72, 20);
			this.simpleButton1.TabIndex = 10;
			this.simpleButton1.Text = "Cancel";
			// 
			// lkpEdtCategory
			// 
			this.lkpEdtCategory.EditValue = "";
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
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label11.Location = new System.Drawing.Point(18, 124);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(100, 20);
			this.label11.TabIndex = 28;
			this.label11.Text = "Case Category";
			// 
			// dtEdtDate
			// 
			this.dtEdtDate.EditValue = new System.DateTime(2005, 10, 31, 0, 0, 0, 0);
			this.dtEdtDate.Location = new System.Drawing.Point(142, 38);
			this.dtEdtDate.Name = "dtEdtDate";
			// 
			// dtEdtDate.Properties
			// 
			this.dtEdtDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dtEdtDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.dtEdtDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.dtEdtDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
			this.dtEdtDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.dtEdtDate.Properties.Mask.EditMask = "";
			this.dtEdtDate.Properties.ReadOnly = true;
			this.dtEdtDate.Size = new System.Drawing.Size(236, 20);
			this.dtEdtDate.TabIndex = 1;
			// 
			// txtEdtMembershipID
			// 
			this.txtEdtMembershipID.EditValue = "";
			this.txtEdtMembershipID.Enabled = false;
			this.txtEdtMembershipID.Location = new System.Drawing.Point(142, 182);
			this.txtEdtMembershipID.Name = "txtEdtMembershipID";
			this.txtEdtMembershipID.Size = new System.Drawing.Size(236, 20);
			this.txtEdtMembershipID.TabIndex = 6;
			// 
			// txtEdtDeptID
			// 
			this.txtEdtDeptID.EditValue = "";
			this.txtEdtDeptID.Enabled = false;
			this.txtEdtDeptID.Location = new System.Drawing.Point(142, 96);
			this.txtEdtDeptID.Name = "txtEdtDeptID";
			this.txtEdtDeptID.Size = new System.Drawing.Size(236, 20);
			this.txtEdtDeptID.TabIndex = 3;
			// 
			// txtEdtBranchCode
			// 
			this.txtEdtBranchCode.EditValue = "";
			this.txtEdtBranchCode.Enabled = false;
			this.txtEdtBranchCode.Location = new System.Drawing.Point(142, 68);
			this.txtEdtBranchCode.Name = "txtEdtBranchCode";
			this.txtEdtBranchCode.Size = new System.Drawing.Size(236, 20);
			this.txtEdtBranchCode.TabIndex = 2;
			// 
			// txtEdtDeptAssignedID
			// 
			this.txtEdtDeptAssignedID.EditValue = "";
			this.txtEdtDeptAssignedID.Enabled = false;
			this.txtEdtDeptAssignedID.Location = new System.Drawing.Point(142, 210);
			this.txtEdtDeptAssignedID.Name = "txtEdtDeptAssignedID";
			this.txtEdtDeptAssignedID.Size = new System.Drawing.Size(236, 20);
			this.txtEdtDeptAssignedID.TabIndex = 7;
			// 
			// FormEditCustomerVoice
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(390, 380);
			this.Controls.Add(this.txtEdtDeptAssignedID);
			this.Controls.Add(this.txtEdtBranchCode);
			this.Controls.Add(this.txtEdtDeptID);
			this.Controls.Add(this.txtEdtMembershipID);
			this.Controls.Add(this.dtEdtDate);
			this.Controls.Add(this.lkpEdtCategory);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.simpleButton1);
			this.Controls.Add(this.SimpleButton56);
			this.Controls.Add(this.mmEdtDetail);
			this.Controls.Add(this.lkpEdtCaseType);
			this.Controls.Add(this.textEdit1);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormEditCustomerVoice";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit Customer Voice";
			((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtCaseType.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mmEdtDetail.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtCategory.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtEdtDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtEdtMembershipID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtEdtDeptID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtEdtBranchCode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtEdtDeptAssignedID.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void SimpleButton56_Click(object sender, System.EventArgs e)
		{
			this.BindingContext[myDataTable].EndCurrentEdit();

			try
			{
				myCV.Save(myDataTable);
			}
			catch(System.Data.DataException ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				this.Close();
			}
		}
	}
}
