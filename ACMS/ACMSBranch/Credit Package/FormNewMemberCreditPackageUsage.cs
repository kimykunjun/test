using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ACMSDAL;
using System.Data;
using DevExpress.XtraEditors.Repository;

namespace ACMS
{
	/// <summary>
	/// Summary description for FormNewMemberCreditPackageUsage.
	/// </summary>
	public class FormNewMemberCreditPackageUsage : System.Windows.Forms.Form
	{
       // private string[] strPackages;
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
		private DevExpress.XtraEditors.SimpleButton simpleButtonOK;
        private DataTable myDataTable;
		private ACMS.XtraUtils.LookupEditBuilder.PackageCodeForCreditPackageLookupEditBuilder myPackageCodeLookupEditBuilder;
		private DevExpress.XtraEditors.LookUpEdit lkpEdtPackageCode;
		private System.Windows.Forms.Label label3;
		private ACMSLogic.PackageCode myPackageCode;
        private int myCreditPackageID;
       // private int nQuantity;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.CheckedComboBoxEdit checkedComboBoxEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn Quantity;
        private RepositoryItemSpinEdit repositoryItemSpinEdit1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormNewMemberCreditPackageUsage(string strMembershipID, int nCreditPackageID)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			myCreditPackageID = nCreditPackageID;
			label3.Text = string.Format("Please select the package you want to use for Member ID : {0} 's Credit Package with ID : {1}", strMembershipID, nCreditPackageID.ToString());
			Init();
		}

		public string[,] StrPackageCode
		{
            
			get 
			{
				//return lkpEdtPackageCode.EditValue.ToString();
                
                DataRow[] rows = myDataTable.Select("Tick = 1");
                string[,] strPackages = new string[rows.Length,2];
                for (int i = 0; i < rows.Length; i++)
                {
                    strPackages[i,0] = rows[i]["strPackageCode"].ToString();
                    strPackages[i,1] = rows[i]["nQuantity"].ToString();
                }
                return strPackages;
			}
		}

            private void Init()
		{
			myPackageCode = new ACMSLogic.PackageCode();
			myPackageCodeLookupEditBuilder = new ACMS.XtraUtils.LookupEditBuilder.PackageCodeForCreditPackageLookupEditBuilder(lkpEdtPackageCode.Properties, myCreditPackageID);
            ACMSDAL.TblPackage sqlPackage = new ACMSDAL.TblPackage();
            myDataTable = sqlPackage.GetValidPackageFromBranchForCreditPackageUsage(ACMSLogic.User.BranchCode, myCreditPackageID);
            DataColumn dc = new DataColumn("Tick",System.Type.GetType("System.Boolean"));
            //DataColumn dc2 = new DataColumn("nQuantity", System.Type.GetType("System.Int32"));
               
            myDataTable.Columns.Add(dc);
           //myDataTable.Columns.Add(dc2);

            gridControl1.DataSource = myDataTable;
          
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
            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewMemberCreditPackageUsage));
            DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
            this.lkpEdtPackageCode = new DevExpress.XtraEditors.LookUpEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Quantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.checkedComboBoxEdit1 = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ((System.ComponentModel.ISupportInitialize)(repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpEdtPackageCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedComboBoxEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // repositoryItemCheckEdit2
            // 
            resources.ApplyResources(repositoryItemCheckEdit2, "repositoryItemCheckEdit2");
            repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // repositoryItemTextEdit1
            // 
            resources.ApplyResources(repositoryItemTextEdit1, "repositoryItemTextEdit1");
            repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // lkpEdtPackageCode
            // 
            resources.ApplyResources(this.lkpEdtPackageCode, "lkpEdtPackageCode");
            this.lkpEdtPackageCode.Name = "lkpEdtPackageCode";
            this.lkpEdtPackageCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("lkpEdtPackageCode.Properties.Buttons"))))});
            this.lkpEdtPackageCode.EditValueChanged += new System.EventHandler(this.lkpEdtPackageCode_EditValueChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.simpleButtonCancel, "simpleButtonCancel");
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            // 
            // simpleButtonOK
            // 
            this.simpleButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.simpleButtonOK, "simpleButtonOK");
            this.simpleButtonOK.Name = "simpleButtonOK";
            this.simpleButtonOK.Click += new System.EventHandler(this.simpleButtonOK_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // gridControl1
            // 
            resources.ApplyResources(this.gridControl1, "gridControl1");
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            repositoryItemCheckEdit2,
            repositoryItemTextEdit1,
            this.repositoryItemSpinEdit1});
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView2});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn1,
            this.Quantity,
            this.gridColumn2,
            this.gridColumn3});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // gridColumn4
            // 
            resources.ApplyResources(this.gridColumn4, "gridColumn4");
            this.gridColumn4.ColumnEdit = repositoryItemCheckEdit2;
            this.gridColumn4.FieldName = "Tick";
            this.gridColumn4.Name = "gridColumn4";
            // 
            // gridColumn1
            // 
            resources.ApplyResources(this.gridColumn1, "gridColumn1");
            this.gridColumn1.FieldName = "strPackageCode";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            // 
            // Quantity
            // 
            resources.ApplyResources(this.Quantity, "Quantity");
            this.Quantity.ColumnEdit = this.repositoryItemSpinEdit1;
            this.Quantity.FieldName = "nQuantity";
            this.Quantity.Name = "Quantity";
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            resources.ApplyResources(this.repositoryItemSpinEdit1, "repositoryItemSpinEdit1");
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemSpinEdit1.IsFloatValue = false;
            this.repositoryItemSpinEdit1.Mask.EditMask = resources.GetString("repositoryItemSpinEdit1.Mask.EditMask");
            this.repositoryItemSpinEdit1.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.repositoryItemSpinEdit1.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            // 
            // gridColumn2
            // 
            resources.ApplyResources(this.gridColumn2, "gridColumn2");
            this.gridColumn2.FieldName = "strDescription";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            // 
            // gridColumn3
            // 
            resources.ApplyResources(this.gridColumn3, "gridColumn3");
            this.gridColumn3.FieldName = "dtValidEnd";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridControl1;
            this.gridView2.Name = "gridView2";
            // 
            // checkedComboBoxEdit1
            // 
            resources.ApplyResources(this.checkedComboBoxEdit1, "checkedComboBoxEdit1");
            this.checkedComboBoxEdit1.Name = "checkedComboBoxEdit1";
            this.checkedComboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("checkedComboBoxEdit1.Properties.Buttons"))))});
            // 
            // FormNewMemberCreditPackageUsage
            // 
            this.AcceptButton = this.simpleButtonOK;
            resources.ApplyResources(this, "$this");
            this.CancelButton = this.simpleButtonCancel;
            this.Controls.Add(this.checkedComboBoxEdit1);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.simpleButtonCancel);
            this.Controls.Add(this.simpleButtonOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lkpEdtPackageCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNewMemberCreditPackageUsage";
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpEdtPackageCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedComboBoxEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void simpleButtonOK_Click(object sender, System.EventArgs e)
		{
            //if (lkpEdtPackageCode.Text.Length == 0)
            //{
            //    MessageBox.Show(this, "Please select a Package Code.");
            //    this.DialogResult = DialogResult.None;
            //    return;
            //}
		}

//		private void lkpEdtCategoryID_EditValueChanged(object sender, System.EventArgs e)
//		{
//			if (lkpEdtCategoryID.EditValue != null && lkpEdtCategoryID.Text.Length > 0)
//			{
//				int categoryID = ACMS.Convert.ToInt32(lkpEdtCategoryID.EditValue);
//				myPackageCodeLookupEditBuilder.Refresh(categoryID);
//				lkpEdtPackageCode.Enabled = true;			
//			}
//			else
//			{
//				lkpEdtPackageCode.Enabled = false;
//			}
//		}
		
		private void lkpEdtPackageCode_EditValueChanged(object sender, System.EventArgs e)
		{
		
		}

      

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //GridEditorItem item = gridView1.GetRow(e.FocusedRowHandle) as GridEditorItem;
            //xtraPropertyGrid1.PropertyGrid.SelectedObject = item.RepositoryItem;
            //gcProperties.Text = item.Name + " Properties:";
        }

      
	}
}
