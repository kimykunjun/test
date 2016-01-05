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
	public class FormTopUpSingleTreatment : System.Windows.Forms.Form
	{
		private DevExpress.XtraEditors.PanelControl pnlCtrlTop;
		private DevExpress.XtraEditors.PanelControl pnlCtrlCenter;
		private DevExpress.XtraEditors.PanelControl pnlCtrlBottom;
		private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
		private DevExpress.XtraEditors.SimpleButton simpleButtonOK;
		internal DevExpress.XtraGrid.GridControl GridControl6;
		internal DevExpress.XtraGrid.Views.Grid.GridView GridView7;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn28;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn30;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn31;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn34;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn45;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn46;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn49;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private ACMSLogic.POS myPOS;
		private DataTable myDataTable;

		public FormTopUpSingleTreatment(ACMSLogic.POS pos)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			myPOS = pos;

			ACMSDAL.TblMemberPackage sqlMemberPackage = new ACMSDAL.TblMemberPackage();
            myDataTable = sqlMemberPackage.GetActiveMemberPackageForSpaSingleTreatment(myPOS.StrMembershipID);
            string strPackageCode = myDataTable.Rows[0]["strPackageCode"].ToString();
            ACMSLogic.MemberPackage.CalculateMemberPackageBalance(strPackageCode,myPOS.StrMembershipID, myDataTable);
			myDataTable.DefaultView.RowFilter = "Balance > 0 ";
			GridControl6.DataSource = myDataTable.DefaultView;
		}
		
		public string StrPackageCode
		{
			get 
			{
				DataRow row = GridView7.GetDataRow(GridView7.FocusedRowHandle);
				if (row != null)
				{
					return row["strPackageCode"].ToString();
				}
				else
					return "";
			}
		}

		public int NPackageID
		{
			get 
			{
				DataRow row = GridView7.GetDataRow(GridView7.FocusedRowHandle);
				if (row != null)
				{
					return ACMS.Convert.ToInt32(row["NPackageID"]);
				}
				else
					return 0;
			}
		}

		public decimal PackageBaseUnitPrice
		{
			get
			{
				DataRow row = GridView7.GetDataRow(GridView7.FocusedRowHandle);
				if (row != null)
				{
					return ACMS.Convert.ToDecimal(row["mBaseUnitPrice"]);
				}
				else
					return 0;
			}
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
			this.pnlCtrlCenter = new DevExpress.XtraEditors.PanelControl();
			this.GridControl6 = new DevExpress.XtraGrid.GridControl();
			this.GridView7 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.GridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumn30 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumn31 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumn34 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumn45 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.GridColumn46 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumn49 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.pnlCtrlBottom = new DevExpress.XtraEditors.PanelControl();
			this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.pnlCtrlTop)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pnlCtrlCenter)).BeginInit();
			this.pnlCtrlCenter.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.GridControl6)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GridView7)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pnlCtrlBottom)).BeginInit();
			this.pnlCtrlBottom.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlCtrlTop
			// 
			this.pnlCtrlTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.pnlCtrlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlCtrlTop.Location = new System.Drawing.Point(0, 0);
			this.pnlCtrlTop.Name = "pnlCtrlTop";
			this.pnlCtrlTop.Size = new System.Drawing.Size(612, 22);
			this.pnlCtrlTop.TabIndex = 0;
			this.pnlCtrlTop.Text = "panelControl1";
			// 
			// pnlCtrlCenter
			// 
			this.pnlCtrlCenter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.pnlCtrlCenter.Controls.Add(this.GridControl6);
			this.pnlCtrlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlCtrlCenter.Location = new System.Drawing.Point(0, 22);
			this.pnlCtrlCenter.Name = "pnlCtrlCenter";
			this.pnlCtrlCenter.Size = new System.Drawing.Size(612, 176);
			this.pnlCtrlCenter.TabIndex = 1;
			this.pnlCtrlCenter.Text = "panelControl2";
			// 
			// GridControl6
			// 
			this.GridControl6.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// GridControl6.EmbeddedNavigator
			// 
			this.GridControl6.EmbeddedNavigator.Name = "";
			this.GridControl6.Location = new System.Drawing.Point(0, 0);
			this.GridControl6.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.GridControl6.LookAndFeel.UseDefaultLookAndFeel = false;
			this.GridControl6.LookAndFeel.UseWindowsXPTheme = false;
			this.GridControl6.MainView = this.GridView7;
			this.GridControl6.Name = "GridControl6";
			this.GridControl6.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																												  this.repositoryItemCheckEdit1});
			this.GridControl6.Size = new System.Drawing.Size(612, 176);
			this.GridControl6.TabIndex = 8;
			this.GridControl6.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										this.GridView7});
			// 
			// GridView7
			// 
			this.GridView7.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.GridColumn28,
																							 this.GridColumn30,
																							 this.GridColumn31,
																							 this.GridColumn34,
																							 this.GridColumn45,
																							 this.GridColumn46,
																							 this.GridColumn49});
			this.GridView7.GridControl = this.GridControl6;
			this.GridView7.Name = "GridView7";
			this.GridView7.OptionsView.ColumnAutoWidth = false;
			this.GridView7.OptionsView.ShowGroupPanel = false;
			this.GridView7.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.GridView7_CustomColumnDisplayText);
			this.GridView7.DoubleClick += new System.EventHandler(this.GridView7_DoubleClick);
			// 
			// GridColumn28
			// 
			this.GridColumn28.Caption = "Package ID";
			this.GridColumn28.FieldName = "nPackageID";
			this.GridColumn28.Name = "GridColumn28";
			this.GridColumn28.OptionsColumn.AllowEdit = false;
			this.GridColumn28.OptionsColumn.AllowFocus = false;
			this.GridColumn28.OptionsFilter.AllowFilter = false;
			this.GridColumn28.Visible = true;
			this.GridColumn28.VisibleIndex = 0;
			this.GridColumn28.Width = 69;
			// 
			// GridColumn30
			// 
			this.GridColumn30.Caption = "Package Code";
			this.GridColumn30.FieldName = "strPackageCode";
			this.GridColumn30.Name = "GridColumn30";
			this.GridColumn30.OptionsColumn.AllowEdit = false;
			this.GridColumn30.OptionsColumn.AllowFocus = false;
			this.GridColumn30.OptionsFilter.AllowFilter = false;
			this.GridColumn30.Visible = true;
			this.GridColumn30.VisibleIndex = 1;
			this.GridColumn30.Width = 90;
			// 
			// GridColumn31
			// 
			this.GridColumn31.Caption = "Package Description";
			this.GridColumn31.FieldName = "strDescription";
			this.GridColumn31.Name = "GridColumn31";
			this.GridColumn31.OptionsColumn.AllowEdit = false;
			this.GridColumn31.OptionsColumn.AllowFocus = false;
			this.GridColumn31.OptionsFilter.AllowFilter = false;
			this.GridColumn31.Visible = true;
			this.GridColumn31.VisibleIndex = 2;
			this.GridColumn31.Width = 108;
			// 
			// GridColumn34
			// 
			this.GridColumn34.Caption = "Balance";
			this.GridColumn34.FieldName = "Balance";
			this.GridColumn34.Name = "GridColumn34";
			this.GridColumn34.OptionsColumn.AllowEdit = false;
			this.GridColumn34.OptionsColumn.AllowFocus = false;
			this.GridColumn34.OptionsFilter.AllowFilter = false;
			this.GridColumn34.Visible = true;
			this.GridColumn34.VisibleIndex = 3;
			this.GridColumn34.Width = 74;
			// 
			// GridColumn45
			// 
			this.GridColumn45.Caption = "Free Indicator";
			this.GridColumn45.ColumnEdit = this.repositoryItemCheckEdit1;
			this.GridColumn45.FieldName = "fFree";
			this.GridColumn45.Name = "GridColumn45";
			this.GridColumn45.OptionsColumn.AllowEdit = false;
			this.GridColumn45.OptionsColumn.AllowFocus = false;
			this.GridColumn45.OptionsFilter.AllowFilter = false;
			this.GridColumn45.Visible = true;
			this.GridColumn45.VisibleIndex = 4;
			this.GridColumn45.Width = 84;
			// 
			// repositoryItemCheckEdit1
			// 
			this.repositoryItemCheckEdit1.AutoHeight = false;
			this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
			this.repositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
			// 
			// GridColumn46
			// 
			this.GridColumn46.Caption = "Status";
			this.GridColumn46.FieldName = "nStatusID";
			this.GridColumn46.Name = "GridColumn46";
			this.GridColumn46.OptionsColumn.AllowEdit = false;
			this.GridColumn46.OptionsColumn.AllowFocus = false;
			this.GridColumn46.OptionsFilter.AllowFilter = false;
			this.GridColumn46.Visible = true;
			this.GridColumn46.VisibleIndex = 5;
			this.GridColumn46.Width = 100;
			// 
			// GridColumn49
			// 
			this.GridColumn49.Caption = "Remark";
			this.GridColumn49.FieldName = "strRemarks";
			this.GridColumn49.Name = "GridColumn49";
			this.GridColumn49.OptionsColumn.AllowEdit = false;
			this.GridColumn49.OptionsColumn.AllowFocus = false;
			this.GridColumn49.OptionsFilter.AllowFilter = false;
			this.GridColumn49.Visible = true;
			this.GridColumn49.VisibleIndex = 6;
			this.GridColumn49.Width = 64;
			// 
			// pnlCtrlBottom
			// 
			this.pnlCtrlBottom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.pnlCtrlBottom.Controls.Add(this.simpleButtonCancel);
			this.pnlCtrlBottom.Controls.Add(this.simpleButtonOK);
			this.pnlCtrlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlCtrlBottom.Location = new System.Drawing.Point(0, 198);
			this.pnlCtrlBottom.Name = "pnlCtrlBottom";
			this.pnlCtrlBottom.Size = new System.Drawing.Size(612, 58);
			this.pnlCtrlBottom.TabIndex = 2;
			this.pnlCtrlBottom.Text = "panelControl3";
			// 
			// simpleButtonCancel
			// 
			this.simpleButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.simpleButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.simpleButtonCancel.Location = new System.Drawing.Point(520, 20);
			this.simpleButtonCancel.Name = "simpleButtonCancel";
			this.simpleButtonCancel.TabIndex = 16;
			this.simpleButtonCancel.Text = "Cancel";
			// 
			// simpleButtonOK
			// 
			this.simpleButtonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.simpleButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.simpleButtonOK.Location = new System.Drawing.Point(434, 20);
			this.simpleButtonOK.Name = "simpleButtonOK";
			this.simpleButtonOK.TabIndex = 15;
			this.simpleButtonOK.Text = "OK";
			this.simpleButtonOK.Click += new System.EventHandler(this.simpleButtonOK_Click);
			// 
			// FormTopUpSingleTreatment
			// 
			this.AcceptButton = this.simpleButtonOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.simpleButtonCancel;
			this.ClientSize = new System.Drawing.Size(612, 256);
			this.Controls.Add(this.pnlCtrlCenter);
			this.Controls.Add(this.pnlCtrlTop);
			this.Controls.Add(this.pnlCtrlBottom);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormTopUpSingleTreatment";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Top Up Single Treatment";
			((System.ComponentModel.ISupportInitialize)(this.pnlCtrlTop)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pnlCtrlCenter)).EndInit();
			this.pnlCtrlCenter.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.GridControl6)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GridView7)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pnlCtrlBottom)).EndInit();
			this.pnlCtrlBottom.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void simpleButtonOK_Click(object sender, System.EventArgs e)
		{
			DataRow r = GridView7.GetDataRow(GridView7.FocusedRowHandle);

			if (r != null)
			{
				ACMS.ACMSPOS2.FormGetService frm = new FormGetService(StrPackageCode);
				DialogResult result = frm.ShowDialog(this);
			
				if (result == DialogResult.OK)
				{
					decimal unitPrice = frm.BasePrice - PackageBaseUnitPrice;

					if (unitPrice < 0) unitPrice = 0;

					myPOS.NewReceiptEntry(frm.StrServiceCode, -1, "Top Up Single Treatment For Member Package : " + NPackageID.ToString(), 
						1, unitPrice, NPackageID.ToString());
				
					this.Close();
				}
				else
				{
					this.DialogResult = DialogResult.None;
					return;
				}
			}
		}

		private void GridView7_DoubleClick(object sender, System.EventArgs e)
		{
			simpleButtonOK.PerformClick();
		}

		private void GridView7_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
		{
			ACMS.XtraUtils.GridViewUtils.TblMemberPackage_CustomColumnDisplayText(e);
		}
	}
}
