using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ACMS
{
	/// <summary>
	/// Summary description for FormTransferMemberPackage.
	/// </summary>
	public class FormTransferMemberPackage : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private DevExpress.XtraEditors.MemoEdit memoEdit1;
		private System.Windows.Forms.Label labelHeader;
		private DevExpress.XtraEditors.SimpleButton simpleButton2;
		private DevExpress.XtraEditors.SimpleButton simpleButton1;
		private ACMSLogic.MemberPackage myMemberPackage;
		private string myCurrMemberID;
		private int myPackageID;
		private DevExpress.XtraEditors.LookUpEdit lkpEdtNewMemberID;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormTransferMemberPackage(ACMSLogic.MemberPackage memberPackage, string strCurrMemberID, int packageID)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			myCurrMemberID = strCurrMemberID;
			myPackageID = packageID;
			myMemberPackage = memberPackage;
			labelHeader.Text = string.Format("Transfer PackageID = {0} of Member {1}.", packageID, strCurrMemberID);
			Init();
		}
		
		private void Init()
		{
			ACMSLogic.Member member = new ACMSLogic.Member();

			new ACMS.XtraUtils.LookupEditBuilder.MemberIDLookupEditBuilder(member, lkpEdtNewMemberID.Properties);
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
			this.lkpEdtNewMemberID = new DevExpress.XtraEditors.LookUpEdit();
			this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
			this.labelHeader = new System.Windows.Forms.Label();
			this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtNewMemberID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 48);
			this.label1.Name = "label1";
			this.label1.TabIndex = 0;
			this.label1.Text = "New Member ID";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 80);
			this.label2.Name = "label2";
			this.label2.TabIndex = 1;
			this.label2.Text = "Remarks";
			// 
			// lkpEdtNewMemberID
			// 
			this.lkpEdtNewMemberID.EditValue = "";
			this.lkpEdtNewMemberID.Location = new System.Drawing.Point(128, 48);
			this.lkpEdtNewMemberID.Name = "lkpEdtNewMemberID";
			// 
			// lkpEdtNewMemberID.Properties
			// 
			this.lkpEdtNewMemberID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkpEdtNewMemberID.Size = new System.Drawing.Size(192, 20);
			this.lkpEdtNewMemberID.TabIndex = 2;
			// 
			// memoEdit1
			// 
			this.memoEdit1.EditValue = "";
			this.memoEdit1.Location = new System.Drawing.Point(128, 80);
			this.memoEdit1.Name = "memoEdit1";
			// 
			// memoEdit1.Properties
			// 
			this.memoEdit1.Properties.MaxLength = 255;
			this.memoEdit1.Size = new System.Drawing.Size(192, 176);
			this.memoEdit1.TabIndex = 3;
			// 
			// labelHeader
			// 
			this.labelHeader.Location = new System.Drawing.Point(8, 8);
			this.labelHeader.Name = "labelHeader";
			this.labelHeader.Size = new System.Drawing.Size(320, 23);
			this.labelHeader.TabIndex = 4;
			this.labelHeader.Text = "label3";
			// 
			// simpleButton2
			// 
			this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.simpleButton2.Location = new System.Drawing.Point(246, 264);
			this.simpleButton2.Name = "simpleButton2";
			this.simpleButton2.TabIndex = 48;
			this.simpleButton2.Text = "Cancel";
			// 
			// simpleButton1
			// 
			this.simpleButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.simpleButton1.Location = new System.Drawing.Point(158, 264);
			this.simpleButton1.Name = "simpleButton1";
			this.simpleButton1.TabIndex = 47;
			this.simpleButton1.Text = "Save";
			this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
			// 
			// FormTransferMemberPackage
			// 
			this.AcceptButton = this.simpleButton1;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.simpleButton2;
			this.ClientSize = new System.Drawing.Size(330, 296);
			this.Controls.Add(this.simpleButton2);
			this.Controls.Add(this.simpleButton1);
			this.Controls.Add(this.labelHeader);
			this.Controls.Add(this.memoEdit1);
			this.Controls.Add(this.lkpEdtNewMemberID);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormTransferMemberPackage";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Transfer Member Package";
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtNewMemberID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void simpleButton1_Click(object sender, System.EventArgs e)
		{
			if (myCurrMemberID == lkpEdtNewMemberID.Text)
			{
				MessageBox.Show(this, "Invalid Transfer. Please select other member ID");
				this.DialogResult = DialogResult.None;
				return;
			}

			if (memoEdit1.Text.Length == 0)
			{
				MessageBox.Show(this, "Please fill in the remark field.");
				this.DialogResult = DialogResult.None;
				return;
			}

			try
			{
				myMemberPackage.TransferMemberPackage(myPackageID, myCurrMemberID, lkpEdtNewMemberID.Text, memoEdit1.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
