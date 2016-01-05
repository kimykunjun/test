using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ACMS
{
	/// <summary>
	/// Summary description for FormNewMemberPackage.
	/// </summary>
	public class FormNewMemberPackage : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private DevExpress.XtraEditors.CheckEdit chkEdtFree;
		private DevExpress.XtraEditors.SimpleButton simpleButton2;
		private DevExpress.XtraEditors.SimpleButton simpleButton1;
		private ACMS.XtraUtils.LookupEditBuilder.PackageCodeLookupEditBuilder myPackageCodeLookupBuilder;
		private ACMS.XtraUtils.LookupEditBuilder.MemberPackageCategoryIDLookupEditBuilder myCategoryIDLookupBuilder;
		private ACMSLogic.PackageCode myPackageCode;
		private string myMembershipID;
		private DataTable myDataTable;
		private ACMSLogic.MemberPackage myMemberPackage;
		private DevExpress.XtraEditors.LookUpEdit lkpEdtPackageCode;
		private DevExpress.XtraEditors.DateEdit dateEdtPurchasedate;
		private DevExpress.XtraEditors.TextEdit txtEdtReceiptNo;
		private DevExpress.XtraEditors.MemoEdit mmEdtRemark;
		private System.Windows.Forms.Label label7;
		private DevExpress.XtraEditors.LookUpEdit lkpEdtCategoryID;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormNewMemberPackage(string membershipID, ACMSLogic.MemberPackage memberPackage)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			myMembershipID = membershipID;
			myMemberPackage = memberPackage;
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			Init();
		}


		public FormNewMemberPackage(string membershipID, ACMSLogic.MemberPackage memberPackage, 
			ACMSLogic.PackageCode packageCode)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			myPackageCode = packageCode;
			myMembershipID = membershipID;
			myMemberPackage = memberPackage;
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			Init();
		}

		private void Init()
		{
			
			if (myPackageCode == null)
				myPackageCode = new ACMSLogic.PackageCode();
			
			InitLookupEdit();
			BindData();
			
		}
		
		private void InitLookupEdit()
		{
			myPackageCodeLookupBuilder = new ACMS.XtraUtils.LookupEditBuilder.PackageCodeLookupEditBuilder(myPackageCode, lkpEdtPackageCode.Properties);
			myCategoryIDLookupBuilder = new ACMS.XtraUtils.LookupEditBuilder.MemberPackageCategoryIDLookupEditBuilder(lkpEdtCategoryID.Properties);
		}

		private void BindData()
		{
			myDataTable =  myMemberPackage.New(false, myMembershipID);
			lkpEdtPackageCode.DataBindings.Clear();
			lkpEdtPackageCode.DataBindings.Add("EditValue", myDataTable, "strPackageCode");
			dateEdtPurchasedate.DataBindings.Clear();
			dateEdtPurchasedate.DataBindings.Add("EditValue", myDataTable, "dtPurchaseDate");
			txtEdtReceiptNo.DataBindings.Clear();
			txtEdtReceiptNo.DataBindings.Add("EditValue", myDataTable, "strReceiptNo");
			mmEdtRemark.DataBindings.Clear();
			mmEdtRemark.DataBindings.Add("EditValue", myDataTable, "strRemarks");
			chkEdtFree.DataBindings.Clear();
			chkEdtFree.DataBindings.Add("EditValue", myDataTable, "fFree");
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
			this.lkpEdtPackageCode = new DevExpress.XtraEditors.LookUpEdit();
			this.dateEdtPurchasedate = new DevExpress.XtraEditors.DateEdit();
			this.txtEdtReceiptNo = new DevExpress.XtraEditors.TextEdit();
			this.chkEdtFree = new DevExpress.XtraEditors.CheckEdit();
			this.mmEdtRemark = new DevExpress.XtraEditors.MemoEdit();
			this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
			this.label7 = new System.Windows.Forms.Label();
			this.lkpEdtCategoryID = new DevExpress.XtraEditors.LookUpEdit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtPackageCode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdtPurchasedate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtEdtReceiptNo.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chkEdtFree.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mmEdtRemark.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtCategoryID.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(14, 30);
			this.label1.Name = "label1";
			this.label1.TabIndex = 0;
			this.label1.Text = "Package Code";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(14, 58);
			this.label2.Name = "label2";
			this.label2.TabIndex = 1;
			this.label2.Text = "Purchase Date";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(14, 86);
			this.label3.Name = "label3";
			this.label3.TabIndex = 2;
			this.label3.Text = "Receipt No";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(14, 114);
			this.label4.Name = "label4";
			this.label4.TabIndex = 3;
			this.label4.Text = "Free";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(14, 142);
			this.label5.Name = "label5";
			this.label5.TabIndex = 4;
			this.label5.Text = "Remark";
			// 
			// lkpEdtPackageCode
			// 
			this.lkpEdtPackageCode.Location = new System.Drawing.Point(130, 32);
			this.lkpEdtPackageCode.Name = "lkpEdtPackageCode";
			// 
			// lkpEdtPackageCode.Properties
			// 
			this.lkpEdtPackageCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkpEdtPackageCode.Size = new System.Drawing.Size(144, 20);
			this.lkpEdtPackageCode.TabIndex = 1;
			// 
			// dateEdtPurchasedate
			// 
			this.dateEdtPurchasedate.EditValue = new System.DateTime(2005, 10, 31, 0, 0, 0, 0);
			this.dateEdtPurchasedate.Location = new System.Drawing.Point(130, 60);
			this.dateEdtPurchasedate.Name = "dateEdtPurchasedate";
			// 
			// dateEdtPurchasedate.Properties
			// 
			this.dateEdtPurchasedate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] 
            {
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dateEdtPurchasedate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.dateEdtPurchasedate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.dateEdtPurchasedate.Size = new System.Drawing.Size(144, 20);
			this.dateEdtPurchasedate.TabIndex = 2;
			// 
			// txtEdtReceiptNo
			// 
			this.txtEdtReceiptNo.EditValue = "textEdit1";
			this.txtEdtReceiptNo.Location = new System.Drawing.Point(130, 86);
			this.txtEdtReceiptNo.Name = "txtEdtReceiptNo";
			this.txtEdtReceiptNo.Size = new System.Drawing.Size(144, 20);
			this.txtEdtReceiptNo.TabIndex = 3;
			// 
			// chkEdtFree
			// 
			this.chkEdtFree.Location = new System.Drawing.Point(132, 114);
			this.chkEdtFree.Name = "chkEdtFree";
			// 
			// chkEdtFree.Properties
			// 
			this.chkEdtFree.Properties.Caption = "Is Free";
			this.chkEdtFree.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
			this.chkEdtFree.Size = new System.Drawing.Size(75, 18);
			this.chkEdtFree.TabIndex = 4;
			// 
			// mmEdtRemark
			// 
			this.mmEdtRemark.EditValue = "memoEdit1";
			this.mmEdtRemark.Location = new System.Drawing.Point(130, 140);
			this.mmEdtRemark.Name = "mmEdtRemark";
			this.mmEdtRemark.Size = new System.Drawing.Size(218, 148);
			this.mmEdtRemark.TabIndex = 5;
			// 
			// simpleButton2
			// 
			this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.simpleButton2.Location = new System.Drawing.Point(272, 298);
			this.simpleButton2.Name = "simpleButton2";
			this.simpleButton2.TabIndex = 7;
			this.simpleButton2.Text = "Cancel";
			this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
			// 
			// simpleButton1
			// 
			this.simpleButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.simpleButton1.Location = new System.Drawing.Point(180, 298);
			this.simpleButton1.Name = "simpleButton1";
			this.simpleButton1.TabIndex = 6;
			this.simpleButton1.Text = "Save";
			this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(14, 2);
			this.label7.Name = "label7";
			this.label7.TabIndex = 34;
			this.label7.Text = "Category ID";
			// 
			// lkpEdtCategoryID
			// 
			this.lkpEdtCategoryID.Location = new System.Drawing.Point(130, 4);
			this.lkpEdtCategoryID.Name = "lkpEdtCategoryID";
			// 
			// lkpEdtCategoryID.Properties
			// 
			this.lkpEdtCategoryID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkpEdtCategoryID.Size = new System.Drawing.Size(144, 20);
			this.lkpEdtCategoryID.TabIndex = 0;
			this.lkpEdtCategoryID.EditValueChanged += new System.EventHandler(this.lkpEdtCategoryID_EditValueChanged);
			// 
			// FormNewMemberPackage
			// 
			this.AcceptButton = this.simpleButton1;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.simpleButton2;
			this.ClientSize = new System.Drawing.Size(360, 332);
			this.Controls.Add(this.lkpEdtCategoryID);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.simpleButton2);
			this.Controls.Add(this.simpleButton1);
			this.Controls.Add(this.mmEdtRemark);
			this.Controls.Add(this.chkEdtFree);
			this.Controls.Add(this.txtEdtReceiptNo);
			this.Controls.Add(this.dateEdtPurchasedate);
			this.Controls.Add(this.lkpEdtPackageCode);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormNewMemberPackage";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "New Member Package";
			this.Load += new System.EventHandler(this.FormNewMemberPackage_Load);
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtPackageCode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdtPurchasedate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtEdtReceiptNo.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chkEdtFree.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mmEdtRemark.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtCategoryID.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void simpleButton2_Click(object sender, System.EventArgs e)
		{
		
		}

		private void simpleButton1_Click(object sender, System.EventArgs e)
		{
			if (lkpEdtCategoryID.Text.Length == 0)
			{
				MessageBox.Show(this, "Please select a Category ID.");
				this.DialogResult = DialogResult.None;
				return;
			}
			else if (lkpEdtPackageCode.Text.Length == 0)
			{
				MessageBox.Show(this, "Please select a Package Code.");
				this.DialogResult = DialogResult.None;
				return;
			}
			else if (mmEdtRemark.Text.Length == 0)
			{
				MessageBox.Show(this, "Remark cannot blank.");
				this.DialogResult = DialogResult.None;
				return;
			}

			this.BindingContext[myDataTable].EndCurrentEdit();

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

		private void lkpEdtCategoryID_EditValueChanged(object sender, System.EventArgs e)
		{
			if (lkpEdtCategoryID.EditValue != null && lkpEdtCategoryID.Text.Length > 0)
			{
				int categoryID = ACMS.Convert.ToInt32(lkpEdtCategoryID.EditValue);
				lkpEdtPackageCode.Properties.Columns.Clear();
				myPackageCodeLookupBuilder = new ACMS.XtraUtils.LookupEditBuilder.PackageCodeLookupEditBuilder(myPackageCode.GetAllValidPackageBaseCategory(categoryID), lkpEdtPackageCode.Properties);
				lkpEdtPackageCode.Enabled = true;			
			}
			else
			{
				lkpEdtPackageCode.Enabled = false;
			}
		}

		private void FormNewMemberPackage_Load(object sender, System.EventArgs e)
		{
			dateEdtPurchasedate.EditValue = DateTime.Now.Date;
		}
	}
}
