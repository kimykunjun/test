using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ACMS
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class FormNewCreditPackage : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private ACMS.XtraUtils.LookupEditBuilder.CategoryIDForCreditPackageLookupEditBuilder myCategoryIDLookupBuilder;
		private ACMS.XtraUtils.LookupEditBuilder.CreditPackageLookupEditBuilder myCreditPackageLookupEdit;
		private ACMS.XtraUtils.LookupEditBuilder.ReceiptNoLookupEditBuilder myReceiptNoLookupEditBuilder;
		private DevExpress.XtraEditors.DateEdit dtEdtPurchaseDate;
		private DevExpress.XtraEditors.CheckEdit chkEdtFree;
		private System.Windows.Forms.Label label2;
		private DevExpress.XtraEditors.LookUpEdit lkpEdtCategoryID;
		private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
		private DevExpress.XtraEditors.SimpleButton simpleButtonOK;
		private DataTable myDataTable;
		private ACMSLogic.CreditAccount myCreditAccount;
		private string myStrMembershipID;
		private DevExpress.XtraEditors.LookUpEdit lkpEdtCreditPackageCode;
		private DevExpress.XtraEditors.LookUpEdit lkpEdtReceiptNo;
		private System.Windows.Forms.Label label5;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormNewCreditPackage(ACMSLogic.CreditAccount creditAccount, string strMembershipID)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			myCreditAccount = creditAccount;
			myStrMembershipID = strMembershipID;
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
			this.chkEdtFree = new DevExpress.XtraEditors.CheckEdit();
			this.label4 = new System.Windows.Forms.Label();
			this.dtEdtPurchaseDate = new DevExpress.XtraEditors.DateEdit();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.lkpEdtCreditPackageCode = new DevExpress.XtraEditors.LookUpEdit();
			this.label2 = new System.Windows.Forms.Label();
			this.lkpEdtCategoryID = new DevExpress.XtraEditors.LookUpEdit();
			this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
			this.lkpEdtReceiptNo = new DevExpress.XtraEditors.LookUpEdit();
			this.label5 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.chkEdtFree.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtEdtPurchaseDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtCreditPackageCode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtCategoryID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtReceiptNo.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// chkEdtFree
			// 
			this.chkEdtFree.Location = new System.Drawing.Point(132, 130);
			this.chkEdtFree.Name = "chkEdtFree";
			// 
			// chkEdtFree.Properties
			// 
			this.chkEdtFree.Properties.Caption = "";
			this.chkEdtFree.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
			this.chkEdtFree.Size = new System.Drawing.Size(20, 18);
			this.chkEdtFree.TabIndex = 6;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 96);
			this.label4.Name = "label4";
			this.label4.TabIndex = 22;
			this.label4.Text = "Receipt";
			// 
			// dtEdtPurchaseDate
			// 
			this.dtEdtPurchaseDate.EditValue = new System.DateTime(2005, 10, 10, 0, 0, 0, 0);
			this.dtEdtPurchaseDate.Location = new System.Drawing.Point(130, 66);
			this.dtEdtPurchaseDate.Name = "dtEdtPurchaseDate";
			// 
			// dtEdtPurchaseDate.Properties
			// 
			this.dtEdtPurchaseDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dtEdtPurchaseDate.Size = new System.Drawing.Size(224, 20);
			this.dtEdtPurchaseDate.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 66);
			this.label1.Name = "label1";
			this.label1.TabIndex = 20;
			this.label1.Text = "Purchase Date";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 36);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(112, 23);
			this.label3.TabIndex = 19;
			this.label3.Text = "Credit Package Code";
			// 
			// lkpEdtCreditPackageCode
			// 
			this.lkpEdtCreditPackageCode.EditValue = "";
			this.lkpEdtCreditPackageCode.Location = new System.Drawing.Point(130, 36);
			this.lkpEdtCreditPackageCode.Name = "lkpEdtCreditPackageCode";
			// 
			// lkpEdtCreditPackageCode.Properties
			// 
			this.lkpEdtCreditPackageCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																															new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkpEdtCreditPackageCode.Properties.NullText = "";
			this.lkpEdtCreditPackageCode.Size = new System.Drawing.Size(224, 20);
			this.lkpEdtCreditPackageCode.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 6);
			this.label2.Name = "label2";
			this.label2.TabIndex = 17;
			this.label2.Text = "Category";
			// 
			// lkpEdtCategoryID
			// 
			this.lkpEdtCategoryID.EditValue = "";
			this.lkpEdtCategoryID.Location = new System.Drawing.Point(130, 8);
			this.lkpEdtCategoryID.Name = "lkpEdtCategoryID";
			// 
			// lkpEdtCategoryID.Properties
			// 
			this.lkpEdtCategoryID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkpEdtCategoryID.Size = new System.Drawing.Size(224, 20);
			this.lkpEdtCategoryID.TabIndex = 1;
			this.lkpEdtCategoryID.EditValueChanged += new System.EventHandler(this.lkpEdtCategoryID_EditValueChanged);
			// 
			// simpleButtonCancel
			// 
			this.simpleButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.simpleButtonCancel.Location = new System.Drawing.Point(194, 174);
			this.simpleButtonCancel.Name = "simpleButtonCancel";
			this.simpleButtonCancel.TabIndex = 8;
			this.simpleButtonCancel.Text = "Cancel";
			// 
			// simpleButtonOK
			// 
			this.simpleButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.simpleButtonOK.Location = new System.Drawing.Point(98, 174);
			this.simpleButtonOK.Name = "simpleButtonOK";
			this.simpleButtonOK.TabIndex = 7;
			this.simpleButtonOK.Text = "OK";
			this.simpleButtonOK.Click += new System.EventHandler(this.simpleButtonOK_Click);
			// 
			// lkpEdtReceiptNo
			// 
			this.lkpEdtReceiptNo.EditValue = "";
			this.lkpEdtReceiptNo.Location = new System.Drawing.Point(130, 96);
			this.lkpEdtReceiptNo.Name = "lkpEdtReceiptNo";
			// 
			// lkpEdtReceiptNo.Properties
			// 
			this.lkpEdtReceiptNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkpEdtReceiptNo.Size = new System.Drawing.Size(224, 20);
			this.lkpEdtReceiptNo.TabIndex = 4;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 128);
			this.label5.Name = "label5";
			this.label5.TabIndex = 25;
			this.label5.Text = "Free";
			// 
			// FormNewCreditPackage
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(368, 210);
			this.Controls.Add(this.lkpEdtReceiptNo);
			this.Controls.Add(this.simpleButtonCancel);
			this.Controls.Add(this.simpleButtonOK);
			this.Controls.Add(this.lkpEdtCategoryID);
			this.Controls.Add(this.lkpEdtCreditPackageCode);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.chkEdtFree);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.dtEdtPurchaseDate);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormNewCreditPackage";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "New Credit Package";
			this.Load += new System.EventHandler(this.FormNewCreditPackage_Load);
			((System.ComponentModel.ISupportInitialize)(this.chkEdtFree.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtEdtPurchaseDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtCreditPackageCode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtCategoryID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtReceiptNo.Properties)).EndInit();
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
			myCategoryIDLookupBuilder = new ACMS.XtraUtils.LookupEditBuilder.CategoryIDForCreditPackageLookupEditBuilder(lkpEdtCategoryID.Properties);
			myCreditPackageLookupEdit = new ACMS.XtraUtils.LookupEditBuilder.CreditPackageLookupEditBuilder(lkpEdtCreditPackageCode.Properties);
			myReceiptNoLookupEditBuilder = new ACMS.XtraUtils.LookupEditBuilder.ReceiptNoLookupEditBuilder(lkpEdtReceiptNo.Properties);
		}

		private void BindData()
		{
			myDataTable = myCreditAccount.New();
			lkpEdtCreditPackageCode.DataBindings.Clear();
			lkpEdtCreditPackageCode.DataBindings.Add("EditValue", myDataTable, "strCreditPackageCode");
			dtEdtPurchaseDate.DataBindings.Clear();
			dtEdtPurchaseDate.DataBindings.Add("EditValue", myDataTable, "dtPurchaseDate");
			lkpEdtReceiptNo.DataBindings.Clear();
			lkpEdtReceiptNo.DataBindings.Add("EditValue", myDataTable, "strReceiptNo");
			chkEdtFree.DataBindings.Clear();
			chkEdtFree.DataBindings.Add("EditValue", myDataTable, "fFree");

			myDataTable.Rows[0]["strMembershipID"] = myStrMembershipID;
		}

		private void simpleButtonOK_Click(object sender, System.EventArgs e)
		{
			if (lkpEdtCreditPackageCode.Text.Length == 0)
			{
				MessageBox.Show(this, "Please Select a Credit Package Code.");
				this.DialogResult = DialogResult.None;
				return;
			}

			this.BindingContext[myDataTable].EndCurrentEdit();

			try
			{
				myCreditAccount.Save(myDataTable);
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
			if (lkpEdtCategoryID.EditValue != null)
			{
				int nCategoryID = ACMS.Convert.ToInt32(lkpEdtCategoryID.EditValue);
				myCreditPackageLookupEdit.Refresh(nCategoryID);
			}
		}

		private void FormNewCreditPackage_Load(object sender, System.EventArgs e)
		{
			chkEdtFree.Checked = true; 
			dtEdtPurchaseDate.EditValue = DateTime.Today.Date;
		}
	}
}
