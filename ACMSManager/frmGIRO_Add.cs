using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using ACMS.XtraUtils.LookupEditBuilder;

namespace ACMS
{
	/// <summary>
	/// Summary description for frmGIRO_Add.
	/// </summary>
	public class frmGIRO_Add : System.Windows.Forms.Form
	{
		private int nEmployeeID;
		internal DevExpress.XtraEditors.SimpleButton btnSave;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label CreditCard;
		private System.Windows.Forms.Label label1;
		private ACMS.Utils.Common myCommon;
		internal DevExpress.XtraEditors.SimpleButton btnClose;
		internal DevExpress.XtraEditors.TextEdit AccountNo;
		private System.Windows.Forms.Label label6;
		private DevExpress.XtraEditors.LookUpEdit luedtBankBranch;
		private DevExpress.XtraEditors.LookUpEdit luedtBank;
		private DevExpress.XtraEditors.LookUpEdit luedtPackage;
		private DevExpress.XtraEditors.LookUpEdit luedtBranch;
		private ACMS.ucMemberID ucMemberID1;
		private System.Windows.Forms.Label ToolTips;
		private DevExpress.XtraEditors.MemoEdit strRemarks;
		private System.Windows.Forms.Label lblRemark;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmGIRO_Add(int nEmployeeID, string aTerminalBranchCode)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			myCommon = new ACMS.Utils.Common();
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			this.nEmployeeID = nEmployeeID;
			ucMemberID1.StrBranchCode = aTerminalBranchCode;

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
			this.btnSave = new DevExpress.XtraEditors.SimpleButton();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.CreditCard = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btnClose = new DevExpress.XtraEditors.SimpleButton();
			this.AccountNo = new DevExpress.XtraEditors.TextEdit();
			this.label6 = new System.Windows.Forms.Label();
			this.luedtBankBranch = new DevExpress.XtraEditors.LookUpEdit();
			this.luedtBank = new DevExpress.XtraEditors.LookUpEdit();
			this.luedtPackage = new DevExpress.XtraEditors.LookUpEdit();
			this.luedtBranch = new DevExpress.XtraEditors.LookUpEdit();
			this.ucMemberID1 = new ACMS.ucMemberID();
			this.ToolTips = new System.Windows.Forms.Label();
			this.strRemarks = new DevExpress.XtraEditors.MemoEdit();
			this.lblRemark = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.AccountNo.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.luedtBankBranch.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.luedtBank.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.luedtPackage.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.luedtBranch.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.strRemarks.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// btnSave
			// 
			this.btnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnSave.Location = new System.Drawing.Point(112, 264);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(72, 20);
			this.btnSave.TabIndex = 31;
			this.btnSave.Text = "Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label5.Location = new System.Drawing.Point(40, 24);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(116, 23);
			this.label5.TabIndex = 27;
			this.label5.Text = "Member";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label4.Location = new System.Drawing.Point(40, 96);
			this.label4.Name = "label4";
			this.label4.TabIndex = 25;
			this.label4.Text = "Bank Code";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.Location = new System.Drawing.Point(40, 144);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(120, 23);
			this.label2.TabIndex = 24;
			this.label2.Text = "Account Number";
			// 
			// CreditCard
			// 
			this.CreditCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.CreditCard.Location = new System.Drawing.Point(40, 120);
			this.CreditCard.Name = "CreditCard";
			this.CreditCard.Size = new System.Drawing.Size(112, 23);
			this.CreditCard.TabIndex = 23;
			this.CreditCard.Text = "Bank Branch Code";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(40, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(120, 23);
			this.label1.TabIndex = 34;
			this.label1.Text = "Package Code";
			// 
			// btnClose
			// 
			this.btnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnClose.Location = new System.Drawing.Point(232, 264);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(72, 20);
			this.btnClose.TabIndex = 35;
			this.btnClose.Text = "Close";
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// AccountNo
			// 
			this.AccountNo.AllowDrop = true;
			this.AccountNo.EditValue = "";
			this.AccountNo.Location = new System.Drawing.Point(184, 144);
			this.AccountNo.Name = "AccountNo";
			// 
			// AccountNo.Properties
			// 
			this.AccountNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.AccountNo.Properties.Appearance.Options.UseFont = true;
			this.AccountNo.Properties.MaxLength = 11;
			this.AccountNo.Size = new System.Drawing.Size(240, 22);
			this.AccountNo.TabIndex = 36;
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label6.Location = new System.Drawing.Point(40, 72);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(112, 23);
			this.label6.TabIndex = 37;
			this.label6.Text = "Branch Code";
			// 
			// luedtBankBranch
			// 
			this.luedtBankBranch.Location = new System.Drawing.Point(184, 120);
			this.luedtBankBranch.Name = "luedtBankBranch";
			// 
			// luedtBankBranch.Properties
			// 
			this.luedtBankBranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.luedtBankBranch.Size = new System.Drawing.Size(240, 22);
			this.luedtBankBranch.TabIndex = 142;
			// 
			// luedtBank
			// 
			this.luedtBank.Location = new System.Drawing.Point(184, 96);
			this.luedtBank.Name = "luedtBank";
			// 
			// luedtBank.Properties
			// 
			this.luedtBank.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.luedtBank.Size = new System.Drawing.Size(240, 22);
			this.luedtBank.TabIndex = 141;
			// 
			// luedtPackage
			// 
			this.luedtPackage.Location = new System.Drawing.Point(184, 48);
			this.luedtPackage.Name = "luedtPackage";
			// 
			// luedtPackage.Properties
			// 
			this.luedtPackage.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.luedtPackage.Size = new System.Drawing.Size(240, 22);
			this.luedtPackage.TabIndex = 140;
			// 
			// luedtBranch
			// 
			this.luedtBranch.Location = new System.Drawing.Point(184, 72);
			this.luedtBranch.Name = "luedtBranch";
			// 
			// luedtBranch.Properties
			// 
			this.luedtBranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.luedtBranch.Size = new System.Drawing.Size(240, 22);
			this.luedtBranch.TabIndex = 139;
			// 
			// ucMemberID1
			// 
			this.ucMemberID1.EditValue = "";
			this.ucMemberID1.EditValueChanged = null;
			this.ucMemberID1.Location = new System.Drawing.Point(184, 24);
			this.ucMemberID1.Name = "ucMemberID1";
			this.ucMemberID1.Size = new System.Drawing.Size(240, 20);
			this.ucMemberID1.StrBranchCode = null;
			this.ucMemberID1.TabIndex = 166;
			// 
			// ToolTips
			// 
			this.ToolTips.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ToolTips.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.ToolTips.Location = new System.Drawing.Point(184, 8);
			this.ToolTips.Name = "ToolTips";
			this.ToolTips.Size = new System.Drawing.Size(184, 16);
			this.ToolTips.TabIndex = 167;
			this.ToolTips.Text = "Use Member Search Tools for Input";
			this.ToolTips.Visible = false;
			// 
			// strRemarks
			// 
			this.strRemarks.EditValue = "";
			this.strRemarks.Location = new System.Drawing.Point(184, 168);
			this.strRemarks.Name = "strRemarks";
			// 
			// strRemarks.Properties
			// 
			this.strRemarks.Properties.MaxLength = 50;
			this.strRemarks.Size = new System.Drawing.Size(240, 80);
			this.strRemarks.TabIndex = 169;
			// 
			// lblRemark
			// 
			this.lblRemark.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblRemark.Location = new System.Drawing.Point(40, 176);
			this.lblRemark.Name = "lblRemark";
			this.lblRemark.Size = new System.Drawing.Size(128, 72);
			this.lblRemark.TabIndex = 168;
			this.lblRemark.Text = "Remarks";
			this.lblRemark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frmGIRO_Add
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(472, 307);
			this.Controls.Add(this.strRemarks);
			this.Controls.Add(this.lblRemark);
			this.Controls.Add(this.ucMemberID1);
			this.Controls.Add(this.ToolTips);
			this.Controls.Add(this.luedtBankBranch);
			this.Controls.Add(this.luedtBank);
			this.Controls.Add(this.luedtPackage);
			this.Controls.Add(this.luedtBranch);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.AccountNo);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.CreditCard);
			this.Name = "frmGIRO_Add";
			this.Text = "New Giro";
			this.Load += new System.EventHandler(this.frmGIRO_Add_Load);
			((System.ComponentModel.ISupportInitialize)(this.AccountNo.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.luedtBankBranch.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.luedtBank.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.luedtPackage.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.luedtBranch.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.strRemarks.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			string bankbranch = (luedtBankBranch.EditValue != null ? luedtBankBranch.EditValue.ToString() : "");

			string[] col = {"strMembershipID","strPackageCode","strBankCode","strBankBranchCode","strAccountNo","strBranchCode","nStatusID","nEmployeeID","strRemarks"};
			object[] val = {ucMemberID1.EditValue.ToString(),luedtPackage.EditValue.ToString(),luedtBank.EditValue.ToString(),bankbranch,AccountNo.Text,luedtBranch.EditValue.ToString(),1,nEmployeeID.ToString(),this.strRemarks.EditValue.ToString()};

			myCommon.Insert("TblGIRO",col,val);
			this.Close();
		}

		private void frmGIRO_Add_Load(object sender, System.EventArgs e)
		{
			DataTable dt;
//			dt = myCommon.ExecuteQuery("up_get_Membercmb");
//			new ManagerMemberIDLookupEditBuilder(dt, luedtMemberID.Properties);

			dt = myCommon.ExecuteQuery("Select * from tblBank");
			new ManagerBankLookupEditBuilder(dt, luedtBank.Properties);

			dt = myCommon.ExecuteQuery("Select * from tblBankBranch");
			new ManagerBankBranchLookupEditBuilder(dt, luedtBankBranch.Properties);

			dt = myCommon.ExecuteQuery("Select strBranchCode,strBranchName from tblBranch");
			new ManagerBranchCodeLookupEditBuilder(dt, luedtBranch.Properties);

			dt = myCommon.ExecuteQuery("Select strPackageCode,strDescription from tblPackage");
			new ManagerPackageLookupEditBuilder(dt, luedtPackage.Properties);
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}








