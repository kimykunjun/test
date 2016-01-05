using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ACMS.ACMSPOS2
{
	/// <summary>
	/// Summary description for FormTopUpCredit.
	/// </summary>
	public class FormTopUpCredit : System.Windows.Forms.Form
	{
		private DevExpress.XtraEditors.PanelControl panelControl1;
		private DevExpress.XtraEditors.PanelControl panelControl2;
		private DevExpress.XtraEditors.PanelControl panelControl3;
		internal DevExpress.XtraGrid.GridControl gridCtrlCreditAccount;
		internal DevExpress.XtraGrid.Views.Grid.GridView GridView11;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn65;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn66;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn67;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn68;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn69;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn70;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn71;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn72;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn73;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn74;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn76;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn77;
		private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
		private DevExpress.XtraEditors.SimpleButton simpleButtonOK;
		private System.Windows.Forms.Label label1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		
		private ACMSLogic.POS myPOS;
		private System.Windows.Forms.Label label2;
		private DevExpress.XtraEditors.TextEdit txtEdtTotalAmt;
		private ACMSLogic.CreditAccount myCreditPackage;
		private DataView myDataTable;

		public FormTopUpCredit(ACMSLogic.POS pos)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			myPOS = pos;
			myCreditPackage = new ACMSLogic.CreditAccount();
			myDataTable = myCreditPackage.GetValidCreditPackage(pos.StrMembershipID);
			
			if (myDataTable != null)
			{
				foreach (DataRow r in myPOS.ReceiptItemsTable.Rows)
				{
					string nCreditPackageID = r["StrCode"].ToString();

					DataRow[] rowstoDelete = myDataTable.Table.Select("nCreditPackageID = " + nCreditPackageID);

					foreach (DataRow r2 in rowstoDelete)
					{
						r2.Delete();
					}
				}
			}

			gridCtrlCreditAccount.DataSource = myDataTable;
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
			this.txtEdtTotalAmt = new DevExpress.XtraEditors.TextEdit();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
			this.gridCtrlCreditAccount = new DevExpress.XtraGrid.GridControl();
			this.GridView11 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.GridColumn65 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumn66 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumn67 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumn68 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumn69 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumn70 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumn71 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumn72 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumn73 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.GridColumn74 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumn76 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumn77 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
			this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
			this.panelControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtEdtTotalAmt.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
			this.panelControl2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridCtrlCreditAccount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GridView11)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
			this.panelControl3.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelControl1
			// 
			this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.panelControl1.Controls.Add(this.txtEdtTotalAmt);
			this.panelControl1.Controls.Add(this.label2);
			this.panelControl1.Controls.Add(this.label1);
			this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelControl1.Location = new System.Drawing.Point(0, 0);
			this.panelControl1.Name = "panelControl1";
			this.panelControl1.Size = new System.Drawing.Size(724, 66);
			this.panelControl1.TabIndex = 0;
			this.panelControl1.Text = "panelControl1";
			// 
			// txtEdtTotalAmt
			// 
			this.txtEdtTotalAmt.EditValue = "";
			this.txtEdtTotalAmt.Location = new System.Drawing.Point(164, 36);
			this.txtEdtTotalAmt.Name = "txtEdtTotalAmt";
			// 
			// txtEdtTotalAmt.Properties
			// 
			this.txtEdtTotalAmt.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
			this.txtEdtTotalAmt.Properties.Appearance.Options.UseFont = true;
			this.txtEdtTotalAmt.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.txtEdtTotalAmt.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.txtEdtTotalAmt.Properties.Mask.EditMask = "c2";
			this.txtEdtTotalAmt.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.txtEdtTotalAmt.Properties.Mask.UseMaskAsDisplayFormat = true;
			this.txtEdtTotalAmt.Properties.MaxLength = 50;
			this.txtEdtTotalAmt.Size = new System.Drawing.Size(218, 23);
			this.txtEdtTotalAmt.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(18, 36);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(138, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Top up Amount :";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(18, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(634, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Please key in amount you want to top up.";
			// 
			// panelControl2
			// 
			this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.panelControl2.Controls.Add(this.gridCtrlCreditAccount);
			this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelControl2.Location = new System.Drawing.Point(0, 66);
			this.panelControl2.Name = "panelControl2";
			this.panelControl2.Size = new System.Drawing.Size(724, 290);
			this.panelControl2.TabIndex = 1;
			this.panelControl2.Text = "panelControl2";
			// 
			// gridCtrlCreditAccount
			// 
			this.gridCtrlCreditAccount.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// gridCtrlCreditAccount.EmbeddedNavigator
			// 
			this.gridCtrlCreditAccount.EmbeddedNavigator.Name = "";
			this.gridCtrlCreditAccount.Location = new System.Drawing.Point(0, 0);
			this.gridCtrlCreditAccount.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.gridCtrlCreditAccount.LookAndFeel.UseDefaultLookAndFeel = false;
			this.gridCtrlCreditAccount.LookAndFeel.UseWindowsXPTheme = false;
			this.gridCtrlCreditAccount.MainView = this.GridView11;
			this.gridCtrlCreditAccount.Name = "gridCtrlCreditAccount";
			this.gridCtrlCreditAccount.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																														   this.repositoryItemCheckEdit2});
			this.gridCtrlCreditAccount.Size = new System.Drawing.Size(724, 290);
			this.gridCtrlCreditAccount.TabIndex = 1;
			this.gridCtrlCreditAccount.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																												 this.GridView11});
			// 
			// GridView11
			// 
			this.GridView11.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							  this.GridColumn65,
																							  this.GridColumn66,
																							  this.GridColumn67,
																							  this.GridColumn68,
																							  this.GridColumn69,
																							  this.GridColumn70,
																							  this.GridColumn71,
																							  this.GridColumn72,
																							  this.GridColumn73,
																							  this.GridColumn74,
																							  this.GridColumn76,
																							  this.GridColumn77});
			this.GridView11.GridControl = this.gridCtrlCreditAccount;
			this.GridView11.Name = "GridView11";
			this.GridView11.OptionsView.ColumnAutoWidth = false;
			this.GridView11.OptionsView.ShowGroupPanel = false;
			// 
			// GridColumn65
			// 
			this.GridColumn65.Caption = "ID";
			this.GridColumn65.FieldName = "nCreditPackageID";
			this.GridColumn65.Name = "GridColumn65";
			this.GridColumn65.OptionsColumn.AllowEdit = false;
			this.GridColumn65.OptionsColumn.AllowFocus = false;
			this.GridColumn65.OptionsColumn.ReadOnly = true;
			this.GridColumn65.OptionsFilter.AllowFilter = false;
			this.GridColumn65.Visible = true;
			this.GridColumn65.VisibleIndex = 0;
			this.GridColumn65.Width = 59;
			// 
			// GridColumn66
			// 
			this.GridColumn66.Caption = "Code";
			this.GridColumn66.FieldName = "strCreditPackageCode";
			this.GridColumn66.Name = "GridColumn66";
			this.GridColumn66.OptionsColumn.AllowEdit = false;
			this.GridColumn66.OptionsColumn.AllowFocus = false;
			this.GridColumn66.OptionsFilter.AllowFilter = false;
			this.GridColumn66.Visible = true;
			this.GridColumn66.VisibleIndex = 1;
			this.GridColumn66.Width = 80;
			// 
			// GridColumn67
			// 
			this.GridColumn67.Caption = "Description";
			this.GridColumn67.Name = "GridColumn67";
			this.GridColumn67.OptionsColumn.AllowEdit = false;
			this.GridColumn67.OptionsColumn.AllowFocus = false;
			this.GridColumn67.OptionsFilter.AllowFilter = false;
			this.GridColumn67.Visible = true;
			this.GridColumn67.VisibleIndex = 2;
			this.GridColumn67.Width = 80;
			// 
			// GridColumn68
			// 
			this.GridColumn68.Caption = "Purchase Date";
			this.GridColumn68.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.GridColumn68.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.GridColumn68.FieldName = "dtPurchaseDate";
			this.GridColumn68.Name = "GridColumn68";
			this.GridColumn68.OptionsColumn.AllowEdit = false;
			this.GridColumn68.OptionsColumn.AllowFocus = false;
			this.GridColumn68.OptionsFilter.AllowFilter = false;
			this.GridColumn68.Visible = true;
			this.GridColumn68.VisibleIndex = 3;
			this.GridColumn68.Width = 88;
			// 
			// GridColumn69
			// 
			this.GridColumn69.Caption = "Receipt No";
			this.GridColumn69.FieldName = "strReceiptNo";
			this.GridColumn69.Name = "GridColumn69";
			this.GridColumn69.OptionsColumn.AllowEdit = false;
			this.GridColumn69.OptionsColumn.AllowFocus = false;
			this.GridColumn69.OptionsFilter.AllowFilter = false;
			this.GridColumn69.Visible = true;
			this.GridColumn69.VisibleIndex = 4;
			this.GridColumn69.Width = 80;
			// 
			// GridColumn70
			// 
			this.GridColumn70.Caption = "Balance";
			this.GridColumn70.FieldName = "Balance";
			this.GridColumn70.Name = "GridColumn70";
			this.GridColumn70.OptionsColumn.AllowEdit = false;
			this.GridColumn70.OptionsColumn.AllowFocus = false;
			this.GridColumn70.OptionsColumn.ReadOnly = true;
			this.GridColumn70.OptionsFilter.AllowFilter = false;
			this.GridColumn70.Visible = true;
			this.GridColumn70.VisibleIndex = 5;
			this.GridColumn70.Width = 80;
			// 
			// GridColumn71
			// 
			this.GridColumn71.Caption = "Start Date";
			this.GridColumn71.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.GridColumn71.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.GridColumn71.FieldName = "dtStartDate";
			this.GridColumn71.Name = "GridColumn71";
			this.GridColumn71.OptionsColumn.AllowEdit = false;
			this.GridColumn71.OptionsColumn.AllowFocus = false;
			this.GridColumn71.OptionsFilter.AllowFilter = false;
			this.GridColumn71.Visible = true;
			this.GridColumn71.VisibleIndex = 6;
			this.GridColumn71.Width = 80;
			// 
			// GridColumn72
			// 
			this.GridColumn72.Caption = "Expiry Date";
			this.GridColumn72.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.GridColumn72.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.GridColumn72.FieldName = "dtExpiryDate";
			this.GridColumn72.Name = "GridColumn72";
			this.GridColumn72.OptionsColumn.AllowEdit = false;
			this.GridColumn72.OptionsColumn.AllowFocus = false;
			this.GridColumn72.OptionsFilter.AllowFilter = false;
			this.GridColumn72.Visible = true;
			this.GridColumn72.VisibleIndex = 7;
			this.GridColumn72.Width = 80;
			// 
			// GridColumn73
			// 
			this.GridColumn73.Caption = "Free Indicator";
			this.GridColumn73.ColumnEdit = this.repositoryItemCheckEdit2;
			this.GridColumn73.FieldName = "fFree";
			this.GridColumn73.Name = "GridColumn73";
			this.GridColumn73.OptionsColumn.AllowEdit = false;
			this.GridColumn73.OptionsColumn.AllowFocus = false;
			this.GridColumn73.OptionsFilter.AllowFilter = false;
			this.GridColumn73.Visible = true;
			this.GridColumn73.VisibleIndex = 8;
			this.GridColumn73.Width = 80;
			// 
			// repositoryItemCheckEdit2
			// 
			this.repositoryItemCheckEdit2.AutoHeight = false;
			this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
			this.repositoryItemCheckEdit2.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
			// 
			// GridColumn74
			// 
			this.GridColumn74.Caption = "Cancelled Indicator";
			this.GridColumn74.Name = "GridColumn74";
			this.GridColumn74.OptionsColumn.AllowEdit = false;
			this.GridColumn74.OptionsColumn.AllowFocus = false;
			this.GridColumn74.OptionsFilter.AllowFilter = false;
			this.GridColumn74.Visible = true;
			this.GridColumn74.VisibleIndex = 9;
			this.GridColumn74.Width = 80;
			// 
			// GridColumn76
			// 
			this.GridColumn76.Caption = "Employee";
			this.GridColumn76.FieldName = "nEmployeeID";
			this.GridColumn76.Name = "GridColumn76";
			this.GridColumn76.OptionsColumn.AllowEdit = false;
			this.GridColumn76.OptionsColumn.AllowFocus = false;
			this.GridColumn76.OptionsFilter.AllowFilter = false;
			this.GridColumn76.Visible = true;
			this.GridColumn76.VisibleIndex = 10;
			this.GridColumn76.Width = 81;
			// 
			// GridColumn77
			// 
			this.GridColumn77.Caption = "Remark";
			this.GridColumn77.FieldName = "strRemarks";
			this.GridColumn77.Name = "GridColumn77";
			this.GridColumn77.OptionsColumn.AllowEdit = false;
			this.GridColumn77.OptionsColumn.AllowFocus = false;
			this.GridColumn77.OptionsFilter.AllowFilter = false;
			this.GridColumn77.Visible = true;
			this.GridColumn77.VisibleIndex = 11;
			this.GridColumn77.Width = 86;
			// 
			// panelControl3
			// 
			this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.panelControl3.Controls.Add(this.simpleButtonCancel);
			this.panelControl3.Controls.Add(this.simpleButtonOK);
			this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelControl3.Location = new System.Drawing.Point(0, 356);
			this.panelControl3.Name = "panelControl3";
			this.panelControl3.Size = new System.Drawing.Size(724, 38);
			this.panelControl3.TabIndex = 2;
			this.panelControl3.Text = "panelControl3";
			// 
			// simpleButtonCancel
			// 
			this.simpleButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.simpleButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.simpleButtonCancel.Location = new System.Drawing.Point(638, 6);
			this.simpleButtonCancel.Name = "simpleButtonCancel";
			this.simpleButtonCancel.TabIndex = 14;
			this.simpleButtonCancel.Text = "Cancel";
			// 
			// simpleButtonOK
			// 
			this.simpleButtonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.simpleButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.simpleButtonOK.Location = new System.Drawing.Point(552, 6);
			this.simpleButtonOK.Name = "simpleButtonOK";
			this.simpleButtonOK.TabIndex = 13;
			this.simpleButtonOK.Text = "OK";
			this.simpleButtonOK.Click += new System.EventHandler(this.simpleButtonOK_Click);
			// 
			// FormTopUpCredit
			// 
			this.AcceptButton = this.simpleButtonOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.simpleButtonCancel;
			this.ClientSize = new System.Drawing.Size(724, 394);
			this.Controls.Add(this.panelControl2);
			this.Controls.Add(this.panelControl3);
			this.Controls.Add(this.panelControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormTopUpCredit";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FormTopUpCredit";
			this.Load += new System.EventHandler(this.FormTopUpCredit_Load);
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
			this.panelControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.txtEdtTotalAmt.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
			this.panelControl2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridCtrlCreditAccount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GridView11)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
			this.panelControl3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void FormTopUpCredit_Load(object sender, System.EventArgs e)
		{
		
		}

		private void calcEdit1_EditValueChanged(object sender, System.EventArgs e)
		{
		
		}

		private void simpleButtonOK_Click(object sender, System.EventArgs e)
		{
			decimal paymentAmt = 0;
			
			DataRow r = GridView11.GetDataRow(GridView11.FocusedRowHandle);

			if (txtEdtTotalAmt.Text.Length > 0 && r != null)
			{
				try
				{
					paymentAmt = ACMS.Convert.ToDecimal(txtEdtTotalAmt.EditValue);
				
					myPOS.NewReceiptEntry(r["nCreditPackageID"].ToString(), -1, 
						string.Format("Top Up Credit Package ID : {0}", r["nCreditPackageID"].ToString()),
						1, paymentAmt, r["strCreditPackageCode"].ToString());

				}
				catch (Exception)
				{
					MessageBox.Show(this, "Invalid Top Up amount.");
					this.DialogResult = DialogResult.None;
					return;	
				}
			}
			else
			{
				MessageBox.Show(this, "Invalid Top Up amount.");
				this.DialogResult = DialogResult.None;
				return;
			}
		}
	}
}
