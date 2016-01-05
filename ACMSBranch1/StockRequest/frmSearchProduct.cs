using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ACMSLogic;
using ACMS.Utils;

namespace ACMS.ACMSBranch.StockRequest
{
	/// <summary>
	/// Summary description for frmSearchProduct.
	/// </summary>
	public class frmSearchProduct : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraGrid.GridControl gridControl1;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
		private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
		private DevExpress.XtraEditors.SimpleButton simpleButton1;
		private DevExpress.XtraEditors.SimpleButton simpleButton2;
		private DevExpress.XtraEditors.SimpleButton simpleButton3;
		private DevExpress.XtraEditors.TextEdit txtSearchProduct;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private string strBranchCode;
		private System.Windows.Forms.Label label2;
		private DevExpress.XtraEditors.TextEdit txtSearchProductDesc;
		private System.Windows.Forms.Label label3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraEditors.TextEdit txtSearchStyle;

		private ArrayList searchProducts;

		public frmSearchProduct(string strBranchCode)
		{
			this.strBranchCode = strBranchCode;
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			this.txtSearchProduct = new DevExpress.XtraEditors.TextEdit();
			this.gridControl1 = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
			this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
			this.label2 = new System.Windows.Forms.Label();
			this.txtSearchProductDesc = new DevExpress.XtraEditors.TextEdit();
			this.txtSearchStyle = new DevExpress.XtraEditors.TextEdit();
			this.label3 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.txtSearchProduct.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtSearchProductDesc.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtSearchStyle.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Product Code";
			// 
			// txtSearchProduct
			// 
			this.txtSearchProduct.EditValue = "";
			this.txtSearchProduct.Location = new System.Drawing.Point(88, 40);
			this.txtSearchProduct.Name = "txtSearchProduct";
			this.txtSearchProduct.Size = new System.Drawing.Size(144, 20);
			this.txtSearchProduct.TabIndex = 2;
			this.txtSearchProduct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SerachProduct);
			// 
			// gridControl1
			// 
			// 
			// gridControl1.EmbeddedNavigator
			// 
			this.gridControl1.EmbeddedNavigator.Name = "";
			this.gridControl1.Location = new System.Drawing.Point(0, 80);
			this.gridControl1.MainView = this.gridView1;
			this.gridControl1.Name = "gridControl1";
			this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																												  this.repositoryItemLookUpEdit1,
																												  this.repositoryItemTextEdit1});
			this.gridControl1.Size = new System.Drawing.Size(512, 312);
			this.gridControl1.TabIndex = 7;
			this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										this.gridView1});
			// 
			// gridView1
			// 
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn1,
																							 this.gridColumn4,
																							 this.gridColumn2,
																							 this.gridColumn3});
			this.gridView1.GridControl = this.gridControl1;
			this.gridView1.Name = "gridView1";
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "Select";
			this.gridColumn1.FieldName = "choose";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 0;
			this.gridColumn1.Width = 60;
			// 
			// gridColumn4
			// 
			this.gridColumn4.Caption = "Style Code";
			this.gridColumn4.FieldName = "strStyleCode";
			this.gridColumn4.Name = "gridColumn4";
			this.gridColumn4.Visible = true;
			this.gridColumn4.VisibleIndex = 1;
			this.gridColumn4.Width = 81;
			// 
			// gridColumn2
			// 
			this.gridColumn2.Caption = "ProductCode";
			this.gridColumn2.FieldName = "strItemCode";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 2;
			this.gridColumn2.Width = 130;
			// 
			// gridColumn3
			// 
			this.gridColumn3.Caption = "Product Description";
			this.gridColumn3.FieldName = "strDescription";
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 3;
			this.gridColumn3.Width = 224;
			// 
			// repositoryItemLookUpEdit1
			// 
			this.repositoryItemLookUpEdit1.AutoHeight = false;
			this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
			this.repositoryItemLookUpEdit1.NullText = "Select Product";
			// 
			// repositoryItemTextEdit1
			// 
			this.repositoryItemTextEdit1.AutoHeight = false;
			this.repositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
			// 
			// simpleButton1
			// 
			this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.simpleButton1.Location = new System.Drawing.Point(352, 400);
			this.simpleButton1.Name = "simpleButton1";
			this.simpleButton1.TabIndex = 5;
			this.simpleButton1.Text = "OK";
			this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
			// 
			// simpleButton2
			// 
			this.simpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.simpleButton2.Location = new System.Drawing.Point(432, 400);
			this.simpleButton2.Name = "simpleButton2";
			this.simpleButton2.TabIndex = 6;
			this.simpleButton2.Text = "Cancel";
			this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
			// 
			// simpleButton3
			// 
			this.simpleButton3.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.simpleButton3.Location = new System.Drawing.Point(424, 8);
			this.simpleButton3.Name = "simpleButton3";
			this.simpleButton3.TabIndex = 4;
			this.simpleButton3.Text = "Search";
			this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(240, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 23);
			this.label2.TabIndex = 64;
			this.label2.Text = "Description";
			// 
			// txtSearchProductDesc
			// 
			this.txtSearchProductDesc.EditValue = "";
			this.txtSearchProductDesc.Location = new System.Drawing.Point(304, 40);
			this.txtSearchProductDesc.Name = "txtSearchProductDesc";
			this.txtSearchProductDesc.Size = new System.Drawing.Size(200, 20);
			this.txtSearchProductDesc.TabIndex = 3;
			this.txtSearchProductDesc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SerachProduct);
			// 
			// txtSearchStyle
			// 
			this.txtSearchStyle.EditValue = "";
			this.txtSearchStyle.Location = new System.Drawing.Point(88, 8);
			this.txtSearchStyle.Name = "txtSearchStyle";
			this.txtSearchStyle.Size = new System.Drawing.Size(144, 20);
			this.txtSearchStyle.TabIndex = 1;
			this.txtSearchStyle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SerachProduct);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 23);
			this.label3.TabIndex = 66;
			this.label3.Text = "Style Code";
			// 
			// frmSearchProduct
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(530, 431);
			this.Controls.Add(this.txtSearchStyle);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtSearchProductDesc);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.simpleButton3);
			this.Controls.Add(this.simpleButton2);
			this.Controls.Add(this.simpleButton1);
			this.Controls.Add(this.gridControl1);
			this.Controls.Add(this.txtSearchProduct);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmSearchProduct";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Search Product";
			((System.ComponentModel.ISupportInitialize)(this.txtSearchProduct.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtSearchProductDesc.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtSearchStyle.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void simpleButton3_Click(object sender, System.EventArgs e)
		{
			ACMSLogic.StockRequest.StockRequest stockRequest = new ACMSLogic.StockRequest.StockRequest();
			this.gridControl1.DataSource = stockRequest.SearchProduct(this.txtSearchStyle.Text,this.txtSearchProduct.Text,this.txtSearchProductDesc.Text,this.strBranchCode);

		}

		private void SerachProduct(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			ACMSLogic.StockRequest.StockRequest stockRequest = new ACMSLogic.StockRequest.StockRequest();
			this.gridControl1.DataSource = stockRequest.SearchProduct(this.txtSearchStyle.Text,this.txtSearchProduct.Text,this.txtSearchProductDesc.Text,this.strBranchCode);

		}

		
		public ArrayList SearchProducts
		{
			set{searchProducts=value;}
			get{return searchProducts;}
		}

		private void simpleButton1_Click(object sender, System.EventArgs e)
		{
			searchProducts = new ArrayList();
			DevExpress.XtraGrid.Columns.GridColumn col1 = gridView1.Columns.ColumnByFieldName("choose");
			DevExpress.XtraGrid.Columns.GridColumn col2 = gridView1.Columns.ColumnByFieldName("strItemCode");

			for(int i=0;i<this.gridView1.DataRowCount;i++)
			{

				object cellValue1 = gridView1.GetRowCellValue(i, col1);
				object cellValue2 = gridView1.GetRowCellValue(i, col2);

				bool select = Convert.ToDBBoolean(cellValue1);
				if(select)
				{
					SearchProduct sp = new SearchProduct(cellValue2.ToString());

					searchProducts.Add(sp);
				}
			}
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void simpleButton2_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		
	}
}
