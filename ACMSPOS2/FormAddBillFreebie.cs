using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ACMS.ACMSPOS2
{
	/// <summary>
	/// Summary description for FormAddItemFreebieAndDiscount.
	/// </summary>
	public class FormAddBillFreebie : System.Windows.Forms.Form
	{
		private DevExpress.XtraEditors.LookUpEdit lkpEdtPromotionCode;
		private System.Windows.Forms.Label label1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private ACMS.XtraUtils.LookupEditBuilder.BillFreebiePromotionCodeLookupEditBuilder myFreebiePromotionCodeLookupBuilder;
		private DevExpress.XtraEditors.PanelControl panelControl1;
		private DevExpress.XtraEditors.PanelControl panelControl2;
		private DevExpress.XtraEditors.PanelControl panelControl3;
		private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
		private DevExpress.XtraGrid.GridControl gridControl1;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraGrid.GridControl gridControl2;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
		private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
		private DevExpress.XtraEditors.SimpleButton simpleButtonOK;
		private ACMSLogic.POS myPOS;

		public FormAddBillFreebie(ACMSLogic.POS pos)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			myPOS = pos;
			myFreebiePromotionCodeLookupBuilder = new ACMS.XtraUtils.LookupEditBuilder.BillFreebiePromotionCodeLookupEditBuilder(lkpEdtPromotionCode.Properties,
				myPOS.StrMembershipID, myPOS.MNettAmount, myPOS.StrBranchCode, myPOS.NCategoryID, true);
			
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
			this.lkpEdtPromotionCode = new DevExpress.XtraEditors.LookUpEdit();
			this.label1 = new System.Windows.Forms.Label();
			this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
			this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
			this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
			this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
			this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
			this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
			this.gridControl1 = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
			this.gridControl2 = new DevExpress.XtraGrid.GridControl();
			this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtPromotionCode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
			this.panelControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
			this.panelControl2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
			this.panelControl3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
			this.xtraTabControl1.SuspendLayout();
			this.xtraTabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
			this.xtraTabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
			this.SuspendLayout();
			// 
			// lkpEdtPromotionCode
			// 
			this.lkpEdtPromotionCode.EditValue = "";
			this.lkpEdtPromotionCode.Location = new System.Drawing.Point(136, 10);
			this.lkpEdtPromotionCode.Name = "lkpEdtPromotionCode";
			// 
			// lkpEdtPromotionCode.Properties
			// 
			this.lkpEdtPromotionCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																														new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkpEdtPromotionCode.Size = new System.Drawing.Size(274, 20);
			this.lkpEdtPromotionCode.TabIndex = 0;
			this.lkpEdtPromotionCode.EditValueChanged += new System.EventHandler(this.lkpEdtPromotionCode_EditValueChanged);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(10, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(106, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Promotion Code";
			// 
			// panelControl1
			// 
			this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.panelControl1.Controls.Add(this.label1);
			this.panelControl1.Controls.Add(this.lkpEdtPromotionCode);
			this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelControl1.Location = new System.Drawing.Point(0, 0);
			this.panelControl1.Name = "panelControl1";
			this.panelControl1.Size = new System.Drawing.Size(442, 46);
			this.panelControl1.TabIndex = 3;
			this.panelControl1.Text = "panelControl1";
			// 
			// panelControl2
			// 
			this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.panelControl2.Controls.Add(this.simpleButtonCancel);
			this.panelControl2.Controls.Add(this.simpleButtonOK);
			this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelControl2.Location = new System.Drawing.Point(0, 256);
			this.panelControl2.Name = "panelControl2";
			this.panelControl2.Size = new System.Drawing.Size(442, 42);
			this.panelControl2.TabIndex = 4;
			this.panelControl2.Text = "panelControl2";
			// 
			// simpleButtonCancel
			// 
			this.simpleButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.simpleButtonCancel.Location = new System.Drawing.Point(360, 10);
			this.simpleButtonCancel.Name = "simpleButtonCancel";
			this.simpleButtonCancel.TabIndex = 12;
			this.simpleButtonCancel.Text = "Cancel";
			// 
			// simpleButtonOK
			// 
			this.simpleButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.simpleButtonOK.Location = new System.Drawing.Point(276, 10);
			this.simpleButtonOK.Name = "simpleButtonOK";
			this.simpleButtonOK.TabIndex = 11;
			this.simpleButtonOK.Text = "OK";
			this.simpleButtonOK.Click += new System.EventHandler(this.simpleButtonOK_Click);
			// 
			// panelControl3
			// 
			this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.panelControl3.Controls.Add(this.xtraTabControl1);
			this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelControl3.Location = new System.Drawing.Point(0, 46);
			this.panelControl3.Name = "panelControl3";
			this.panelControl3.Size = new System.Drawing.Size(442, 210);
			this.panelControl3.TabIndex = 5;
			this.panelControl3.Text = "panelControl3";
			// 
			// xtraTabControl1
			// 
			this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.xtraTabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
			this.xtraTabControl1.Name = "xtraTabControl1";
			this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
			this.xtraTabControl1.Size = new System.Drawing.Size(442, 210);
			this.xtraTabControl1.TabIndex = 3;
			this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
																							this.xtraTabPage1,
																							this.xtraTabPage2});
			this.xtraTabControl1.Text = "xtraTabControl1";
			// 
			// xtraTabPage1
			// 
			this.xtraTabPage1.Controls.Add(this.gridControl1);
			this.xtraTabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xtraTabPage1.Name = "xtraTabPage1";
			this.xtraTabPage1.Size = new System.Drawing.Size(436, 184);
			this.xtraTabPage1.Text = "Freebie-Package";
			// 
			// gridControl1
			// 
			this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// gridControl1.EmbeddedNavigator
			// 
			this.gridControl1.EmbeddedNavigator.Name = "";
			this.gridControl1.Location = new System.Drawing.Point(0, 0);
			this.gridControl1.MainView = this.gridView1;
			this.gridControl1.Name = "gridControl1";
			this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																												  this.repositoryItemCheckEdit2});
			this.gridControl1.Size = new System.Drawing.Size(436, 184);
			this.gridControl1.TabIndex = 0;
			this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										this.gridView1});
			// 
			// gridView1
			// 
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn6,
																							 this.gridColumn1,
																							 this.gridColumn2});
			this.gridView1.GridControl = this.gridControl1;
			this.gridView1.Name = "gridView1";
			// 
			// gridColumn6
			// 
			this.gridColumn6.ColumnEdit = this.repositoryItemCheckEdit2;
			this.gridColumn6.FieldName = "Checked";
			this.gridColumn6.Name = "gridColumn6";
			this.gridColumn6.Visible = true;
			this.gridColumn6.VisibleIndex = 0;
			this.gridColumn6.Width = 36;
			// 
			// repositoryItemCheckEdit2
			// 
			this.repositoryItemCheckEdit2.AutoHeight = false;
			this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
			this.repositoryItemCheckEdit2.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "Package Code";
			this.gridColumn1.FieldName = "strPackageCode";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.OptionsColumn.AllowEdit = false;
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 1;
			this.gridColumn1.Width = 126;
			// 
			// gridColumn2
			// 
			this.gridColumn2.Caption = "Package Description";
			this.gridColumn2.FieldName = "strDescription";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.OptionsColumn.AllowEdit = false;
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 2;
			this.gridColumn2.Width = 260;
			// 
			// xtraTabPage2
			// 
			this.xtraTabPage2.Controls.Add(this.gridControl2);
			this.xtraTabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xtraTabPage2.Name = "xtraTabPage2";
			this.xtraTabPage2.Size = new System.Drawing.Size(436, 184);
			this.xtraTabPage2.Text = "Freebie-Product";
			// 
			// gridControl2
			// 
			this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// gridControl2.EmbeddedNavigator
			// 
			this.gridControl2.EmbeddedNavigator.Name = "";
			this.gridControl2.Location = new System.Drawing.Point(0, 0);
			this.gridControl2.MainView = this.gridView2;
			this.gridControl2.Name = "gridControl2";
			this.gridControl2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																												  this.repositoryItemCheckEdit1});
			this.gridControl2.Size = new System.Drawing.Size(436, 184);
			this.gridControl2.TabIndex = 0;
			this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										this.gridView2});
			// 
			// gridView2
			// 
			this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn5,
																							 this.gridColumn3,
																							 this.gridColumn4});
			this.gridView2.GridControl = this.gridControl2;
			this.gridView2.Name = "gridView2";
			// 
			// gridColumn5
			// 
			this.gridColumn5.ColumnEdit = this.repositoryItemCheckEdit1;
			this.gridColumn5.FieldName = "Checked";
			this.gridColumn5.Name = "gridColumn5";
			this.gridColumn5.Visible = true;
			this.gridColumn5.VisibleIndex = 0;
			this.gridColumn5.Width = 36;
			// 
			// repositoryItemCheckEdit1
			// 
			this.repositoryItemCheckEdit1.AutoHeight = false;
			this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
			this.repositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
			// 
			// gridColumn3
			// 
			this.gridColumn3.Caption = "Product Code";
			this.gridColumn3.FieldName = "strProductCode";
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.OptionsColumn.AllowEdit = false;
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 1;
			this.gridColumn3.Width = 115;
			// 
			// gridColumn4
			// 
			this.gridColumn4.Caption = "Product Description";
			this.gridColumn4.FieldName = "strDescription";
			this.gridColumn4.Name = "gridColumn4";
			this.gridColumn4.OptionsColumn.AllowEdit = false;
			this.gridColumn4.Visible = true;
			this.gridColumn4.VisibleIndex = 2;
			this.gridColumn4.Width = 271;
			// 
			// FormAddBillFreebie
			// 
			this.AcceptButton = this.simpleButtonOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.simpleButtonCancel;
			this.ClientSize = new System.Drawing.Size(442, 298);
			this.Controls.Add(this.panelControl3);
			this.Controls.Add(this.panelControl2);
			this.Controls.Add(this.panelControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormAddBillFreebie";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Add Bill Freebies";
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtPromotionCode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
			this.panelControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
			this.panelControl2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
			this.panelControl3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
			this.xtraTabControl1.ResumeLayout(false);
			this.xtraTabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
			this.xtraTabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void lkpEdtPromotionCode_EditValueChanged(object sender, System.EventArgs e)
		{
			if (lkpEdtPromotionCode.EditValue != null &&
				lkpEdtPromotionCode.Text != "")
			{
				string strPromotionCode = lkpEdtPromotionCode.EditValue.ToString();

				int nPromotionTypeID = (int)lkpEdtPromotionCode.GetColumnValue("nPromotionTypeID");
				
				// free Product
				if (nPromotionTypeID == 1)
				{
					xtraTabPage2.PageVisible = true;
					xtraTabPage1.PageVisible = false;

					ACMSDAL.TblProduct product = new ACMSDAL.TblProduct();
					DataTable table = product.GetPromotionProductBaseOnPromotionCode(strPromotionCode, myPOS.StrBranchCode);

					if (table != null)
					{
						DataColumn colChecked = new DataColumn("Checked", typeof(bool));
						table.Columns.Add(colChecked);

						foreach (DataRow r in table.Rows)
						{
							r["Checked"] = false;
						}
					}
					gridControl2.DataSource = table;
				}
				else if (nPromotionTypeID == 2)
				{
					//Free Package
					xtraTabPage2.PageVisible = false;
					xtraTabPage1.PageVisible = true;

					ACMSLogic.PackageCode package = new ACMSLogic.PackageCode();
					DataTable table = package.GetPromotionPackageBasePromotionCode(strPromotionCode);
					
					if (table != null)
					{
						DataColumn colChecked = new DataColumn("Checked", typeof(bool));
						table.Columns.Add(colChecked);

						foreach (DataRow r in table.Rows)
						{
							r["Checked"] = false;
						}
					}

					gridControl1.DataSource = table;
				}
			}
		}

		private void simpleButtonOK_Click(object sender, System.EventArgs e)
		{
			if (lkpEdtPromotionCode.EditValue == null || lkpEdtPromotionCode.Text == "") return;

			int nPromotionTypeID = (int)lkpEdtPromotionCode.GetColumnValue("nPromotionTypeID");
				
			if (lkpEdtPromotionCode.EditValue != null)
			{
				// free Product
				if (nPromotionTypeID == 1)
				{
					ACMS.XtraUtils.GridViewUtils.UpdateData(gridView2);
					if (gridControl2.DataSource != null)
					{
						DataRow[]  rowList = ((DataTable)gridControl2.DataSource).Select("Checked = true");

						if (rowList.Length > 0)
							myPOS.NewBillReceiptFreebies(rowList, lkpEdtPromotionCode.EditValue.ToString(), false);
					}
				}
				else
				{
					ACMS.XtraUtils.GridViewUtils.UpdateData(gridView1);

					if (gridControl1.DataSource != null)
					{
						DataRow[] rowList = ((DataTable)gridControl1.DataSource).Select("Checked = true");

						if (rowList.Length > 0)
							myPOS.NewBillReceiptFreebies(rowList, lkpEdtPromotionCode.EditValue.ToString(), true);
					}
				}
			}
		}
	}
}
