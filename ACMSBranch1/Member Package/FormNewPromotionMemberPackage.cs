using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ACMS
{
	/// <summary>
	/// Summary description for FormNewPromotionMemberPackage.
	/// </summary>
	public class FormNewPromotionMemberPackage : System.Windows.Forms.Form
	{
		private DevExpress.XtraEditors.SimpleButton simpleButton2;
		private DevExpress.XtraEditors.SimpleButton simpleButton1;
		private DevExpress.XtraEditors.LookUpEdit lkpEdtPackageCode;
		private System.Windows.Forms.Label label1;
		private ACMS.XtraUtils.LookupEditBuilder.PackageCodeBasePromotionLookupEditBuilder myPackageCodeLookupBuilder;
		private ACMS.XtraUtils.LookupEditBuilder.PromotionCodeForMemberPackageLookupEditBuilder myPromotionCodeLookupBuilder;		
		private string myMembershipID;
		private DataTable myDataTable;
		private ACMSLogic.MemberPackage myMemberPackage;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label6;
		private DevExpress.XtraEditors.TextEdit txtEdtVoucherNo;
		private DevExpress.XtraEditors.LookUpEdit lkpEdtPromotionNo;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormNewPromotionMemberPackage(string strMembershipID, ACMSLogic.MemberPackage memberPackage)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			myMembershipID = strMembershipID;
			myMemberPackage = memberPackage;
			Init();
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
			this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
			this.lkpEdtPackageCode = new DevExpress.XtraEditors.LookUpEdit();
			this.label1 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.lkpEdtPromotionNo = new DevExpress.XtraEditors.LookUpEdit();
			this.txtEdtVoucherNo = new DevExpress.XtraEditors.TextEdit();
			this.label6 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtPackageCode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtPromotionNo.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtEdtVoucherNo.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// simpleButton2
			// 
			this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.simpleButton2.Location = new System.Drawing.Point(186, 102);
			this.simpleButton2.Name = "simpleButton2";
			this.simpleButton2.TabIndex = 8;
			this.simpleButton2.Text = "Cancel";
			// 
			// simpleButton1
			// 
			this.simpleButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.simpleButton1.Location = new System.Drawing.Point(98, 102);
			this.simpleButton1.Name = "simpleButton1";
			this.simpleButton1.TabIndex = 7;
			this.simpleButton1.Text = "Save";
			this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
			// 
			// lkpEdtPackageCode
			// 
			this.lkpEdtPackageCode.Location = new System.Drawing.Point(118, 36);
			this.lkpEdtPackageCode.Name = "lkpEdtPackageCode";
			// 
			// lkpEdtPackageCode.Properties
			// 
			this.lkpEdtPackageCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkpEdtPackageCode.Size = new System.Drawing.Size(144, 20);
			this.lkpEdtPackageCode.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(14, 36);
			this.label1.Name = "label1";
			this.label1.TabIndex = 34;
			this.label1.Text = "Package Code";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(14, 8);
			this.label4.Name = "label4";
			this.label4.TabIndex = 52;
			this.label4.Text = "Promotion No";
			// 
			// lkpEdtPromotionNo
			// 
			this.lkpEdtPromotionNo.EditValue = "";
			this.lkpEdtPromotionNo.Location = new System.Drawing.Point(118, 8);
			this.lkpEdtPromotionNo.Name = "lkpEdtPromotionNo";
			// 
			// lkpEdtPromotionNo.Properties
			// 
			this.lkpEdtPromotionNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkpEdtPromotionNo.Size = new System.Drawing.Size(144, 20);
			this.lkpEdtPromotionNo.TabIndex = 4;
			this.lkpEdtPromotionNo.EditValueChanged += new System.EventHandler(this.lkpEdtPromotionNo_EditValueChanged);
			// 
			// txtEdtVoucherNo
			// 
			this.txtEdtVoucherNo.EditValue = "";
			this.txtEdtVoucherNo.Location = new System.Drawing.Point(118, 62);
			this.txtEdtVoucherNo.Name = "txtEdtVoucherNo";
			this.txtEdtVoucherNo.Size = new System.Drawing.Size(144, 20);
			this.txtEdtVoucherNo.TabIndex = 5;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(14, 64);
			this.label6.Name = "label6";
			this.label6.TabIndex = 55;
			this.label6.Text = "Voucher No";
			// 
			// FormNewPromotionMemberPackage
			// 
			this.AcceptButton = this.simpleButton1;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.simpleButton2;
			this.ClientSize = new System.Drawing.Size(274, 138);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txtEdtVoucherNo);
			this.Controls.Add(this.lkpEdtPromotionNo);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.simpleButton2);
			this.Controls.Add(this.simpleButton1);
			this.Controls.Add(this.lkpEdtPackageCode);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormNewPromotionMemberPackage";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "New Promotion Member Package";
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtPackageCode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtPromotionNo.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtEdtVoucherNo.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
		
		private void Init()
		{
			InitLookupEdit();
			BindData();
		}
		
		private void InitLookupEdit()
		{
			myPromotionCodeLookupBuilder = new ACMS.XtraUtils.LookupEditBuilder.PromotionCodeForMemberPackageLookupEditBuilder(lkpEdtPromotionNo.Properties, 
				myMembershipID, ACMSLogic.User.BranchCode);

			myPackageCodeLookupBuilder = new ACMS.XtraUtils.LookupEditBuilder.PackageCodeBasePromotionLookupEditBuilder(lkpEdtPackageCode.Properties, "");
		}

		private void BindData()
		{
			myDataTable =  myMemberPackage.New(true, myMembershipID);
			lkpEdtPackageCode.DataBindings.Clear();
			lkpEdtPackageCode.DataBindings.Add("EditValue", myDataTable, "strPackageCode");
			lkpEdtPromotionNo.DataBindings.Clear();
			lkpEdtPromotionNo.DataBindings.Add("EditValue", myDataTable, "strPromotionCode");
			txtEdtVoucherNo.DataBindings.Clear();
			txtEdtVoucherNo.DataBindings.Add("EditValue", myDataTable, "strVoucherNumber");
		}

		private void simpleButton1_Click(object sender, System.EventArgs e)
		{
			if (lkpEdtPromotionNo.Text.Length == 0)
			{
				MessageBox.Show(this, "Please select a Promotion No.");
				this.DialogResult = DialogResult.None;
				return;
			}
			else if (lkpEdtPackageCode.Text.Length == 0)
			{
				MessageBox.Show(this, "Please select a Package Code.");
				this.DialogResult = DialogResult.None;
				return;
			}

			if (txtEdtVoucherNo.Text.Length == 0)
			{
				MessageBox.Show(this, "Please enter the voucher no.");
				txtEdtVoucherNo.Focus();
				this.DialogResult = DialogResult.None;
				return;
			}

			this.BindingContext[myDataTable].EndCurrentEdit();
			
//			ACMSDAL.TblPackage sqlPackage = new ACMSDAL.TblPackage();
//			sqlPackage.StrPackageCode = lkpEdtPackageCode.ToString();
//			sqlPackage.SelectOne();
//			myDataTable.Rows[0]["nCategoryID"] = ACMS.Convert.ToInt32(sqlPackage.NCategoryID);

			try
			{
				myMemberPackage.Save(myDataTable);
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

		private void lkpEdtPromotionNo_EditValueChanged(object sender, System.EventArgs e)
		{
			if (myPromotionCodeLookupBuilder != null)
			{
				if (lkpEdtPromotionNo.EditValue != null)
					myPackageCodeLookupBuilder.Refresh(lkpEdtPromotionNo.EditValue.ToString());
				else
					myPackageCodeLookupBuilder.Refresh("");
			}
		}
	}
}
