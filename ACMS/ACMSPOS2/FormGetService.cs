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
	public class FormGetService : System.Windows.Forms.Form
	{
		private DevExpress.XtraEditors.PanelControl pnlCtrlTop;
		private DevExpress.XtraEditors.PanelControl pnlCtrlCenter;
		private DevExpress.XtraEditors.PanelControl pnlCtrlBottom;
		internal DevExpress.XtraGrid.GridControl GridControl6;
		internal DevExpress.XtraGrid.Views.Grid.GridView GridView7;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
		private DevExpress.XtraEditors.SimpleButton simpleButtonOK;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormGetService(string strPackageCode)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

			ACMSDAL.TblService sqlService = new ACMSDAL.TblService();
			string sqlCmd = "Select A.* From tblService A inner join tblPackageService B on " + 
				" A.strServiceCode = B.strServiceCode Where " + 
				" B.strPackageCode = @strPackageCode ";
			
			GridControl6.DataSource = sqlService.LoadData(sqlCmd, new string[] {"@strPackageCode"}, new object[] {strPackageCode});
		}

		public decimal BasePrice
		{
			get 
			{
				DataRow row = GridView7.GetDataRow(GridView7.FocusedRowHandle);
				if (row != null)
				{
					return ACMS.Convert.ToDecimal(row["mBasePrice"]);
				}
				else
					return 0;
			}
		}

		public string StrServiceCode
		{
			get 
			{
				DataRow row = GridView7.GetDataRow(GridView7.FocusedRowHandle);
				if (row != null)
				{
					return row["strServiceCode"].ToString();
				}
				else
					return "";
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
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
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
			this.pnlCtrlTop.Size = new System.Drawing.Size(580, 26);
			this.pnlCtrlTop.TabIndex = 0;
			this.pnlCtrlTop.Text = "panelControl1";
			// 
			// pnlCtrlCenter
			// 
			this.pnlCtrlCenter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.pnlCtrlCenter.Controls.Add(this.GridControl6);
			this.pnlCtrlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlCtrlCenter.Location = new System.Drawing.Point(0, 26);
			this.pnlCtrlCenter.Name = "pnlCtrlCenter";
			this.pnlCtrlCenter.Size = new System.Drawing.Size(580, 168);
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
			this.GridControl6.Size = new System.Drawing.Size(580, 168);
			this.GridControl6.TabIndex = 9;
			this.GridControl6.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										this.GridView7});
			// 
			// GridView7
			// 
			this.GridView7.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn1,
																							 this.gridColumn2,
																							 this.gridColumn3,
																							 this.gridColumn4});
			this.GridView7.GridControl = this.GridControl6;
			this.GridView7.Name = "GridView7";
			this.GridView7.OptionsView.ColumnAutoWidth = false;
			this.GridView7.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "Service Code";
			this.gridColumn1.FieldName = "strServiceCode";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.OptionsColumn.AllowEdit = false;
			this.gridColumn1.OptionsFilter.AllowAutoFilter = false;
			this.gridColumn1.OptionsFilter.AllowFilter = false;
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 0;
			this.gridColumn1.Width = 85;
			// 
			// gridColumn2
			// 
			this.gridColumn2.Caption = "Description";
			this.gridColumn2.FieldName = "strDescription";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.OptionsColumn.AllowEdit = false;
			this.gridColumn2.OptionsFilter.AllowAutoFilter = false;
			this.gridColumn2.OptionsFilter.AllowFilter = false;
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 1;
			this.gridColumn2.Width = 161;
			// 
			// gridColumn3
			// 
			this.gridColumn3.Caption = "Duration";
			this.gridColumn3.FieldName = "nDuration";
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.OptionsColumn.AllowEdit = false;
			this.gridColumn3.OptionsFilter.AllowAutoFilter = false;
			this.gridColumn3.OptionsFilter.AllowFilter = false;
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 2;
			this.gridColumn3.Width = 141;
			// 
			// gridColumn4
			// 
			this.gridColumn4.Caption = "Price";
			this.gridColumn4.DisplayFormat.FormatString = "n2";
			this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumn4.FieldName = "mBasePrice";
			this.gridColumn4.Name = "gridColumn4";
			this.gridColumn4.OptionsColumn.AllowEdit = false;
			this.gridColumn4.OptionsFilter.AllowAutoFilter = false;
			this.gridColumn4.OptionsFilter.AllowFilter = false;
			this.gridColumn4.Visible = true;
			this.gridColumn4.VisibleIndex = 3;
			this.gridColumn4.Width = 169;
			// 
			// repositoryItemCheckEdit1
			// 
			this.repositoryItemCheckEdit1.AutoHeight = false;
			this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
			this.repositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
			// 
			// pnlCtrlBottom
			// 
			this.pnlCtrlBottom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.pnlCtrlBottom.Controls.Add(this.simpleButtonCancel);
			this.pnlCtrlBottom.Controls.Add(this.simpleButtonOK);
			this.pnlCtrlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlCtrlBottom.Location = new System.Drawing.Point(0, 194);
			this.pnlCtrlBottom.Name = "pnlCtrlBottom";
			this.pnlCtrlBottom.Size = new System.Drawing.Size(580, 50);
			this.pnlCtrlBottom.TabIndex = 2;
			this.pnlCtrlBottom.Text = "panelControl3";
			// 
			// simpleButtonCancel
			// 
			this.simpleButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.simpleButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.simpleButtonCancel.Location = new System.Drawing.Point(482, 14);
			this.simpleButtonCancel.Name = "simpleButtonCancel";
			this.simpleButtonCancel.TabIndex = 18;
			this.simpleButtonCancel.Text = "Cancel";
			// 
			// simpleButtonOK
			// 
			this.simpleButtonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.simpleButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.simpleButtonOK.Location = new System.Drawing.Point(396, 14);
			this.simpleButtonOK.Name = "simpleButtonOK";
			this.simpleButtonOK.TabIndex = 17;
			this.simpleButtonOK.Text = "OK";
			// 
			// FormGetService
			// 
			this.AcceptButton = this.simpleButtonOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.simpleButtonCancel;
			this.ClientSize = new System.Drawing.Size(580, 244);
			this.Controls.Add(this.pnlCtrlCenter);
			this.Controls.Add(this.pnlCtrlTop);
			this.Controls.Add(this.pnlCtrlBottom);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormGetService";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Select a service to top up";
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
	}
}
