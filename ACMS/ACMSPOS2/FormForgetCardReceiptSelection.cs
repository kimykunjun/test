using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;


namespace ACMS.ACMSPOS2
{
	/// <summary>
	/// Summary description for FormNew_EditLocker.
	/// </summary>
	public class FormForgetCardReceiptSelection : System.Windows.Forms.Form
	{
		private DevExpress.XtraEditors.PanelControl pnlCtrlTop;
		private DevExpress.XtraEditors.PanelControl pnlCtrlCenter;
		private DevExpress.XtraEditors.PanelControl pnlCtrlBottom;

		private ACMSLogic.POS myPOS;
		internal DevExpress.XtraGrid.GridControl GridControl11;
		internal DevExpress.XtraGrid.Views.Grid.GridView GridView12;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn75;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn78;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn79;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn80;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn81;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn82;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn83;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn99;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn100;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn265;
		private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
		private DevExpress.XtraEditors.SimpleButton simpleButtonOK;
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraGrid.Columns.GridColumn colSelected;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
		private ACMSLogic.POSHelper myPOSHelper;
		private DataTable myDataTable;		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormForgetCardReceiptSelection(ACMSLogic.POS pos)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			myPOS = pos;
			myPOSHelper = new ACMSLogic.POSHelper(myPOS);
			myDataTable = myPOSHelper.GetDataTable();
			
			Init();
		}

		private void Init()
		{
			foreach (DataRow row in myPOS.ReceiptItemsTable.Rows)
			{
				string strReceiptNoToRefund = row["strCode"].ToString();
				
				DataRow[] rowToDelete = myDataTable.Select(string.Format("strReceiptNo = '{0}' ", strReceiptNoToRefund), "", DataViewRowState.CurrentRows);
				
				if (rowToDelete.Length > 0)
				{
					rowToDelete[0].Delete();
				}
			}

			DataColumn colSelected = new DataColumn("fSelected", typeof(bool));
			myDataTable.Columns.Add(colSelected);
			GridControl11.DataSource = myDataTable;
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
			this.pnlCtrlTop = new DevExpress.XtraEditors.PanelControl();
			this.label1 = new System.Windows.Forms.Label();
			this.pnlCtrlCenter = new DevExpress.XtraEditors.PanelControl();
			this.GridControl11 = new DevExpress.XtraGrid.GridControl();
			this.GridView12 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colSelected = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.GridColumn75 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumn78 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumn79 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumn80 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumn81 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumn82 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumn83 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumn99 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumn100 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn265 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.pnlCtrlBottom = new DevExpress.XtraEditors.PanelControl();
			this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.pnlCtrlTop)).BeginInit();
			this.pnlCtrlTop.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pnlCtrlCenter)).BeginInit();
			this.pnlCtrlCenter.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.GridControl11)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GridView12)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pnlCtrlBottom)).BeginInit();
			this.pnlCtrlBottom.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlCtrlTop
			// 
			this.pnlCtrlTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.pnlCtrlTop.Controls.Add(this.label1);
			this.pnlCtrlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlCtrlTop.Location = new System.Drawing.Point(0, 0);
			this.pnlCtrlTop.Name = "pnlCtrlTop";
			this.pnlCtrlTop.Size = new System.Drawing.Size(758, 46);
			this.pnlCtrlTop.TabIndex = 0;
			this.pnlCtrlTop.Text = "panelControl1";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(14, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(574, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Please select a forget card receipt that you want to refund.";
			// 
			// pnlCtrlCenter
			// 
			this.pnlCtrlCenter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.pnlCtrlCenter.Controls.Add(this.GridControl11);
			this.pnlCtrlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlCtrlCenter.Location = new System.Drawing.Point(0, 46);
			this.pnlCtrlCenter.Name = "pnlCtrlCenter";
			this.pnlCtrlCenter.Size = new System.Drawing.Size(758, 162);
			this.pnlCtrlCenter.TabIndex = 1;
			this.pnlCtrlCenter.Text = "panelControl2";
			// 
			// GridControl11
			// 
			this.GridControl11.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// GridControl11.EmbeddedNavigator
			// 
			this.GridControl11.EmbeddedNavigator.Name = "";
			this.GridControl11.Location = new System.Drawing.Point(0, 0);
			this.GridControl11.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.GridControl11.LookAndFeel.UseDefaultLookAndFeel = false;
			this.GridControl11.LookAndFeel.UseWindowsXPTheme = false;
			this.GridControl11.MainView = this.GridView12;
			this.GridControl11.Name = "GridControl11";
			this.GridControl11.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																												   this.repositoryItemCheckEdit1});
			this.GridControl11.Size = new System.Drawing.Size(758, 162);
			this.GridControl11.TabIndex = 8;
			this.GridControl11.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										 this.GridView12});
			// 
			// GridView12
			// 
			this.GridView12.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							  this.colSelected,
																							  this.GridColumn75,
																							  this.GridColumn78,
																							  this.GridColumn79,
																							  this.GridColumn80,
																							  this.GridColumn81,
																							  this.GridColumn82,
																							  this.GridColumn83,
																							  this.GridColumn99,
																							  this.GridColumn100,
																							  this.gridColumn265});
			this.GridView12.GridControl = this.GridControl11;
			this.GridView12.Name = "GridView12";
			this.GridView12.OptionsView.ShowGroupPanel = false;
			this.GridView12.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
																									   new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.GridColumn75, DevExpress.Data.ColumnSortOrder.Ascending)});
			// 
			// colSelected
			// 
			this.colSelected.ColumnEdit = this.repositoryItemCheckEdit1;
			this.colSelected.FieldName = "fSelected";
			this.colSelected.Name = "colSelected";
			this.colSelected.Visible = true;
			this.colSelected.VisibleIndex = 0;
			this.colSelected.Width = 31;
			// 
			// repositoryItemCheckEdit1
			// 
			this.repositoryItemCheckEdit1.AutoHeight = false;
			this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
			this.repositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
			// 
			// GridColumn75
			// 
			this.GridColumn75.Caption = "Date";
			this.GridColumn75.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.GridColumn75.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.GridColumn75.FieldName = "dtDate";
			this.GridColumn75.Name = "GridColumn75";
			this.GridColumn75.OptionsColumn.AllowEdit = false;
			this.GridColumn75.OptionsFilter.AllowFilter = false;
			this.GridColumn75.Visible = true;
			this.GridColumn75.VisibleIndex = 1;
			this.GridColumn75.Width = 69;
			// 
			// GridColumn78
			// 
			this.GridColumn78.Caption = "Receipt No";
			this.GridColumn78.FieldName = "strReceiptNo";
			this.GridColumn78.Name = "GridColumn78";
			this.GridColumn78.OptionsColumn.AllowEdit = false;
			this.GridColumn78.OptionsFilter.AllowFilter = false;
			this.GridColumn78.Visible = true;
			this.GridColumn78.VisibleIndex = 2;
			this.GridColumn78.Width = 69;
			// 
			// GridColumn79
			// 
			this.GridColumn79.Caption = "Category";
			this.GridColumn79.FieldName = "CategoryDescription";
			this.GridColumn79.Name = "GridColumn79";
			this.GridColumn79.OptionsColumn.AllowEdit = false;
			this.GridColumn79.OptionsFilter.AllowFilter = false;
			this.GridColumn79.Visible = true;
			this.GridColumn79.VisibleIndex = 3;
			this.GridColumn79.Width = 69;
			// 
			// GridColumn80
			// 
			this.GridColumn80.Caption = "Nett";
			this.GridColumn80.DisplayFormat.FormatString = "n2";
			this.GridColumn80.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.GridColumn80.FieldName = "mNettAmount";
			this.GridColumn80.Name = "GridColumn80";
			this.GridColumn80.OptionsColumn.AllowEdit = false;
			this.GridColumn80.OptionsFilter.AllowFilter = false;
			this.GridColumn80.Visible = true;
			this.GridColumn80.VisibleIndex = 4;
			this.GridColumn80.Width = 69;
			// 
			// GridColumn81
			// 
			this.GridColumn81.Caption = "GST";
			this.GridColumn81.DisplayFormat.FormatString = "n2";
			this.GridColumn81.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.GridColumn81.FieldName = "mGSTAmount";
			this.GridColumn81.Name = "GridColumn81";
			this.GridColumn81.OptionsColumn.AllowEdit = false;
			this.GridColumn81.OptionsFilter.AllowFilter = false;
			this.GridColumn81.Visible = true;
			this.GridColumn81.VisibleIndex = 5;
			this.GridColumn81.Width = 69;
			// 
			// GridColumn82
			// 
			this.GridColumn82.Caption = "Total";
			this.GridColumn82.DisplayFormat.FormatString = "n2";
			this.GridColumn82.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.GridColumn82.FieldName = "mTotalAmount";
			this.GridColumn82.Name = "GridColumn82";
			this.GridColumn82.OptionsColumn.AllowEdit = false;
			this.GridColumn82.OptionsFilter.AllowFilter = false;
			this.GridColumn82.Visible = true;
			this.GridColumn82.VisibleIndex = 6;
			this.GridColumn82.Width = 69;
			// 
			// GridColumn83
			// 
			this.GridColumn83.Caption = "O/S Amount";
			this.GridColumn83.DisplayFormat.FormatString = "n2";
			this.GridColumn83.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.GridColumn83.FieldName = "mOutstandingAmount";
			this.GridColumn83.Name = "GridColumn83";
			this.GridColumn83.OptionsColumn.AllowEdit = false;
			this.GridColumn83.OptionsFilter.AllowFilter = false;
			this.GridColumn83.Visible = true;
			this.GridColumn83.VisibleIndex = 8;
			this.GridColumn83.Width = 86;
			// 
			// GridColumn99
			// 
			this.GridColumn99.Caption = "Salesperson";
			this.GridColumn99.FieldName = "SalesPersonName";
			this.GridColumn99.Name = "GridColumn99";
			this.GridColumn99.OptionsColumn.AllowEdit = false;
			this.GridColumn99.OptionsFilter.AllowFilter = false;
			this.GridColumn99.Visible = true;
			this.GridColumn99.VisibleIndex = 9;
			this.GridColumn99.Width = 70;
			// 
			// GridColumn100
			// 
			this.GridColumn100.Caption = "Void Flag";
			this.GridColumn100.FieldName = "fVoid";
			this.GridColumn100.Name = "GridColumn100";
			this.GridColumn100.OptionsColumn.AllowEdit = false;
			this.GridColumn100.OptionsFilter.AllowFilter = false;
			this.GridColumn100.Visible = true;
			this.GridColumn100.VisibleIndex = 10;
			this.GridColumn100.Width = 57;
			// 
			// gridColumn265
			// 
			this.gridColumn265.Caption = "Total Amount";
			this.gridColumn265.DisplayFormat.FormatString = "n2";
			this.gridColumn265.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumn265.FieldName = "mTotalAmount";
			this.gridColumn265.Name = "gridColumn265";
			this.gridColumn265.OptionsColumn.AllowEdit = false;
			this.gridColumn265.OptionsFilter.AllowFilter = false;
			this.gridColumn265.Visible = true;
			this.gridColumn265.VisibleIndex = 7;
			this.gridColumn265.Width = 79;
			// 
			// pnlCtrlBottom
			// 
			this.pnlCtrlBottom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.pnlCtrlBottom.Controls.Add(this.simpleButtonCancel);
			this.pnlCtrlBottom.Controls.Add(this.simpleButtonOK);
			this.pnlCtrlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlCtrlBottom.Location = new System.Drawing.Point(0, 208);
			this.pnlCtrlBottom.Name = "pnlCtrlBottom";
			this.pnlCtrlBottom.Size = new System.Drawing.Size(758, 48);
			this.pnlCtrlBottom.TabIndex = 2;
			this.pnlCtrlBottom.Text = "panelControl3";
			// 
			// simpleButtonCancel
			// 
			this.simpleButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.simpleButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.simpleButtonCancel.Location = new System.Drawing.Point(670, 14);
			this.simpleButtonCancel.Name = "simpleButtonCancel";
			this.simpleButtonCancel.TabIndex = 12;
			this.simpleButtonCancel.Text = "Cancel";
			// 
			// simpleButtonOK
			// 
			this.simpleButtonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.simpleButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.simpleButtonOK.Location = new System.Drawing.Point(584, 14);
			this.simpleButtonOK.Name = "simpleButtonOK";
			this.simpleButtonOK.TabIndex = 11;
			this.simpleButtonOK.Text = "OK";
			this.simpleButtonOK.Click += new System.EventHandler(this.simpleButtonOK_Click);
			// 
			// FormForgetCardReceiptSelection
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(758, 256);
			this.Controls.Add(this.pnlCtrlCenter);
			this.Controls.Add(this.pnlCtrlTop);
			this.Controls.Add(this.pnlCtrlBottom);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormForgetCardReceiptSelection";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Forget Card Receipt";
			((System.ComponentModel.ISupportInitialize)(this.pnlCtrlTop)).EndInit();
			this.pnlCtrlTop.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pnlCtrlCenter)).EndInit();
			this.pnlCtrlCenter.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.GridControl11)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GridView12)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pnlCtrlBottom)).EndInit();
			this.pnlCtrlBottom.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void simpleButtonOK_Click(object sender, System.EventArgs e)
		{
			DataRow [] selectedRows = myDataTable.Select("fSelected = true", "", DataViewRowState.CurrentRows);

			if (selectedRows.Length == 0)
			{
				MessageBox.Show(this, "Please select a forget card receipt that you want to refund.", "Warning");
				this.DialogResult = DialogResult.None;
				return;
			}
			
			foreach (DataRow row in selectedRows)
			{
				myPOS.NewReceiptEntry(row["strReceiptNo"].ToString(), -1,
					string.Format("Forget Card Refund - Receipt No : {0}", row["strReceiptNo"].ToString()), 
					1, -ACMS.Convert.ToDecimal(row["mNettAmount"]), DateTime.Today.Date.ToString("yyyy/MM/dd"));
			}

			myPOS.POSForgetCardAction = ACMSLogic.POS.ForgetCardAction.Refund;
		}
	}
}
