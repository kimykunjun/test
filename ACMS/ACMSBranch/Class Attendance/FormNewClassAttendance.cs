using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ACMS
{
	/// <summary>
	/// Summary description for FormNewClassAttendance.
	/// </summary>
	public class FormNewClassAttendanceInClassAttendanceModule : System.Windows.Forms.Form
	{
		private DevExpress.XtraEditors.PanelControl panelControl1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private DevExpress.XtraEditors.LookUpEdit lkpEdtMemberPackage;
		private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
		private DevExpress.XtraEditors.SimpleButton simpleButtonOK;
		private ACMS.XtraUtils.LookupEditBuilder.MemberPackageLookupEditBuilder2 myMemberPackageLookupEditBuilder;
		//private ACMSDAL.TblMember myMember;
		//private DataTable myMemberIDDataTable;
		private DevExpress.XtraEditors.CheckEdit checkEditForgetCard;
		private string myMembershipID = "";
		private int myPackageID = -1;
		private bool myIsNeedToVerifyMemberPackageLater = true;
		private ACMS.ucMemberID ucMemberID1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormNewClassAttendanceInClassAttendanceModule(bool isGym)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			if (!isGym)
				this.Text = "New Class Attendance";
			else
				this.Text = "New Gym Attendance";
			
			ucMemberID1.StrBranchCode = ACMSLogic.User.BranchCode;
			ucMemberID1.EditValueChanged += new ACMSLogic.Common.EditValueChangedDelegate(UcMemberEditValueChanged);
//			myMember = new ACMSDAL.TblMember();
//			myMemberIDDataTable = myMember.GetMember();
			Init();
			
		}

		public FormNewClassAttendanceInClassAttendanceModule(string membershipID, bool isGym)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			if (!isGym)
				this.Text = "New Class Attendance";
			else
				this.Text = "New Gym Attendance";
						
						//			myMember = new ACMSDAL.TblMember();
//			myMemberIDDataTable = myMember.GetMember();
			ucMemberID1.StrBranchCode = ACMSLogic.User.BranchCode;
			ucMemberID1.EditValueChanged += new ACMSLogic.Common.EditValueChangedDelegate(UcMemberEditValueChanged);
			Init();
			myMembershipID = membershipID;
		}

		public string MembershipID
		{
			get 
			{ 
				if (ucMemberID1 != null)
					return ucMemberID1.EditValue.ToString();
				else
					return "";
			}
		}

		public bool IsNeedToVerifyMemberPackage
		{
			get { return myIsNeedToVerifyMemberPackageLater;}	
		}

		public int MemberPackageID
		{
			get 
			{ 
				if (lkpEdtMemberPackage.Text != "")	
					return ACMS.Convert.ToInt32(lkpEdtMemberPackage.EditValue);
				else
					return myPackageID;
			}
		}

		public bool Refunded
		{
			get { return !checkEditForgetCard.Checked; }
		}

		private void Init()
		{
			myMemberPackageLookupEditBuilder = new ACMS.XtraUtils.LookupEditBuilder.MemberPackageLookupEditBuilder2(lkpEdtMemberPackage.Properties, false, "");
			//myMemberIDLookupEditBuilder = new ACMS.XtraUtils.LookupEditBuilder.MemberIDLookupEditBuilder2(lkpEdtMemberID.Properties, "");
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.checkEditForgetCard = new DevExpress.XtraEditors.CheckEdit();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
            this.lkpEdtMemberPackage = new DevExpress.XtraEditors.LookUpEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ucMemberID1 = new ACMS.ucMemberID();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditForgetCard.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpEdtMemberPackage.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.ucMemberID1);
            this.panelControl1.Controls.Add(this.checkEditForgetCard);
            this.panelControl1.Controls.Add(this.simpleButtonCancel);
            this.panelControl1.Controls.Add(this.simpleButtonOK);
            this.panelControl1.Controls.Add(this.lkpEdtMemberPackage);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(360, 148);
            this.panelControl1.TabIndex = 0;
            // 
            // checkEditForgetCard
            // 
            this.checkEditForgetCard.Location = new System.Drawing.Point(134, 74);
            this.checkEditForgetCard.Name = "checkEditForgetCard";
            this.checkEditForgetCard.Properties.Caption = "Forget Card?";
            this.checkEditForgetCard.Size = new System.Drawing.Size(124, 19);
            this.checkEditForgetCard.TabIndex = 43;
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.simpleButtonCancel.Location = new System.Drawing.Point(192, 116);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonCancel.TabIndex = 42;
            this.simpleButtonCancel.Text = "Cancel";
            // 
            // simpleButtonOK
            // 
            this.simpleButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.simpleButtonOK.Location = new System.Drawing.Point(88, 116);
            this.simpleButtonOK.Name = "simpleButtonOK";
            this.simpleButtonOK.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonOK.TabIndex = 41;
            this.simpleButtonOK.Text = "OK";
            this.simpleButtonOK.Click += new System.EventHandler(this.simpleButtonOK_Click);
            // 
            // lkpEdtMemberPackage
            // 
            this.lkpEdtMemberPackage.Location = new System.Drawing.Point(136, 42);
            this.lkpEdtMemberPackage.Name = "lkpEdtMemberPackage";
            this.lkpEdtMemberPackage.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpEdtMemberPackage.Size = new System.Drawing.Size(204, 20);
            this.lkpEdtMemberPackage.TabIndex = 3;
            this.lkpEdtMemberPackage.EditValueChanged += new System.EventHandler(this.lkpEdtMemberPackage_EditValueChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Member Package";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Member ID";
            // 
            // ucMemberID1
            // 
            this.ucMemberID1.EditValue = "";
            this.ucMemberID1.EditValueChanged = null;
            this.ucMemberID1.Location = new System.Drawing.Point(134, 10);
            this.ucMemberID1.Name = "ucMemberID1";
            this.ucMemberID1.Size = new System.Drawing.Size(182, 20);
            this.ucMemberID1.StrBranchCode = null;
            this.ucMemberID1.TabIndex = 44;
            this.ucMemberID1.Load += new System.EventHandler(this.ucMemberID1_Load);
            // 
            // FormNewClassAttendanceInClassAttendanceModule
            // 
            this.AcceptButton = this.simpleButtonOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.simpleButtonCancel;
            this.ClientSize = new System.Drawing.Size(360, 148);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNewClassAttendanceInClassAttendanceModule";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Class Attendance";
            this.Load += new System.EventHandler(this.FormNewClassAttendanceInClassAttendanceModule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkEditForgetCard.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpEdtMemberPackage.Properties)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void UcMemberEditValueChanged(string strMembershipID)
		{
			myMemberPackageLookupEditBuilder.Refresh(strMembershipID);
		}

		private void simpleButtonOK_Click(object sender, System.EventArgs e)
		{
			if (lkpEdtMemberPackage.Text.Length == 0 || MembershipID.Length == 0)
			{

				DialogResult result = MessageBox.Show("No package was selected. Do you still want to mark it? \n " + 
					"(An unlinked record will be create if you click yes) ", "Warning", MessageBoxButtons.YesNo);
				
				if (result == DialogResult.Yes)
				{
					ACMSLogic.MemberPackage.CreateUnlinkedMemberPackage(MembershipID, ref myPackageID);
					myIsNeedToVerifyMemberPackageLater = false;
					return;
				}
				else
				{
					this.DialogResult = DialogResult.None;
					return;
				}
			}
		}

		private void FormNewClassAttendanceInClassAttendanceModule_Load(object sender, System.EventArgs e)
		{
			//ucMemberID1.Focus();
			if (myMembershipID != "")
			{	
				ucMemberID1.EditValue = myMembershipID;
				myMemberPackageLookupEditBuilder.Refresh(myMembershipID);                
			}
			ucMemberID1.Focus();
		}

		private void lkpEdtMemberPackage_EditValueChanged(object sender, System.EventArgs e)
		{
		
		}

		private void ucMemberID1_Load(object sender, System.EventArgs e)
		{
		
		}
	}
}
