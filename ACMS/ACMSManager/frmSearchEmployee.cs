using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;


namespace ACMS.ACMSManager
{
	/// <summary>
	/// Summary description for frmSearchEmployee.
	/// </summary>
	public class frmSearchEmployee : System.Windows.Forms.Form
	{
		private string connectionString;
		private SqlConnection connection;
		private string strEmployeeID;
		private string strBranchCode;
		private DevExpress.XtraEditors.PanelControl panelControl2;
		private DevExpress.XtraEditors.SimpleButton sbtnCancel;
		private DevExpress.XtraEditors.SimpleButton sbtnOK;
		private DevExpress.XtraEditors.GroupControl groupControl1;
		private DevExpress.XtraGrid.GridControl gridControl1;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;

		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit3;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit4;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit5;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit6;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit7;
		private DevExpress.XtraEditors.PanelControl panelControl1;
		private DevExpress.XtraEditors.SimpleButton sbtnSearch;
		private DevExpress.XtraEditors.TextEdit txtSearchKey;
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private string searchKey;
		public string StrEmployeeID
		{
			get {return strEmployeeID;}
		}

		public string StrBranchCode
		{
			get {return strBranchCode;}
		}

		public frmSearchEmployee(string sk,string sb)
		{
			//
			// Required for Windows Form Designer support
			//
			searchKey = sk;
			InitializeComponent();
			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);
			txtSearchKey.EditValue = searchKey;
			strBranchCode = sb;

			
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public frmSearchEmployee(string sk)
		{
			//
			// Required for Windows Form Designer support
			//
			searchKey = sk;
			InitializeComponent();
			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);
			txtSearchKey.EditValue = searchKey;
			
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
			this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
			this.sbtnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnOK = new DevExpress.XtraEditors.SimpleButton();
			this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
			this.gridControl1 = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.repositoryItemCheckEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.repositoryItemCheckEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.repositoryItemCheckEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.repositoryItemCheckEdit6 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.repositoryItemCheckEdit7 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
			this.label1 = new System.Windows.Forms.Label();
			this.sbtnSearch = new DevExpress.XtraEditors.SimpleButton();
			this.txtSearchKey = new DevExpress.XtraEditors.TextEdit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
			this.panelControl2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
			this.groupControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit6)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit7)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
			this.panelControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtSearchKey.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// panelControl2
			// 
			this.panelControl2.Controls.Add(this.sbtnCancel);
			this.panelControl2.Controls.Add(this.sbtnOK);
			this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelControl2.Location = new System.Drawing.Point(0, 463);
			this.panelControl2.Name = "panelControl2";
			this.panelControl2.Size = new System.Drawing.Size(936, 38);
			this.panelControl2.TabIndex = 3;
			this.panelControl2.Text = "panelControl2";
			// 
			// sbtnCancel
			// 
			this.sbtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.sbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.sbtnCancel.Location = new System.Drawing.Point(854, 8);
			this.sbtnCancel.Name = "sbtnCancel";
			this.sbtnCancel.TabIndex = 1;
			this.sbtnCancel.Text = "Cancel";
			this.sbtnCancel.Click += new System.EventHandler(this.sbtnCancel_Click);
			// 
			// sbtnOK
			// 
			this.sbtnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.sbtnOK.Location = new System.Drawing.Point(770, 8);
			this.sbtnOK.Name = "sbtnOK";
			this.sbtnOK.TabIndex = 0;
			this.sbtnOK.Text = "OK";
			this.sbtnOK.Click += new System.EventHandler(this.sbtnOK_Click);
			// 
			// groupControl1
			// 
			this.groupControl1.Controls.Add(this.gridControl1);
			this.groupControl1.Location = new System.Drawing.Point(0, 40);
			this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
			this.groupControl1.Name = "groupControl1";
			this.groupControl1.Size = new System.Drawing.Size(936, 424);
			this.groupControl1.TabIndex = 4;
			// 
			// gridControl1
			// 
			this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// gridControl1.EmbeddedNavigator
			// 
			this.gridControl1.EmbeddedNavigator.Name = "";
			this.gridControl1.Location = new System.Drawing.Point(4, 18);
			this.gridControl1.MainView = this.gridView1;
			this.gridControl1.Name = "gridControl1";
			this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																												  this.repositoryItemCheckEdit1,
																												  this.repositoryItemCheckEdit2,
																												  this.repositoryItemCheckEdit3,
																												  this.repositoryItemCheckEdit4,
																												  this.repositoryItemCheckEdit5,
																												  this.repositoryItemCheckEdit6,
																												  this.repositoryItemCheckEdit7});
			this.gridControl1.Size = new System.Drawing.Size(928, 402);
			this.gridControl1.TabIndex = 2;
			this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										this.gridView1});
			// 
			// gridView1
			// 
			this.gridView1.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(236)), ((System.Byte)(232)), ((System.Byte)(201)));
			this.gridView1.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((System.Byte)(236)), ((System.Byte)(232)), ((System.Byte)(201)));
			this.gridView1.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black;
			this.gridView1.Appearance.ColumnFilterButton.Options.UseBackColor = true;
			this.gridView1.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
			this.gridView1.Appearance.ColumnFilterButton.Options.UseForeColor = true;
			this.gridView1.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(221)), ((System.Byte)(231)), ((System.Byte)(234)));
			this.gridView1.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((System.Byte)(221)), ((System.Byte)(231)), ((System.Byte)(234)));
			this.gridView1.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
			this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
			this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
			this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
			this.gridView1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(236)), ((System.Byte)(232)), ((System.Byte)(201)));
			this.gridView1.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
			this.gridView1.Appearance.Empty.Options.UseBackColor = true;
			this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(221)), ((System.Byte)(231)), ((System.Byte)(234)));
			this.gridView1.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((System.Byte)(221)), ((System.Byte)(231)), ((System.Byte)(234)));
			this.gridView1.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
			this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
			this.gridView1.Appearance.EvenRow.Options.UseBorderColor = true;
			this.gridView1.Appearance.EvenRow.Options.UseForeColor = true;
			this.gridView1.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(216)), ((System.Byte)(209)), ((System.Byte)(179)));
			this.gridView1.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((System.Byte)(216)), ((System.Byte)(209)), ((System.Byte)(179)));
			this.gridView1.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
			this.gridView1.Appearance.FilterCloseButton.Options.UseBackColor = true;
			this.gridView1.Appearance.FilterCloseButton.Options.UseBorderColor = true;
			this.gridView1.Appearance.FilterCloseButton.Options.UseForeColor = true;
			this.gridView1.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(236)), ((System.Byte)(232)), ((System.Byte)(201)));
			this.gridView1.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
			this.gridView1.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
			this.gridView1.Appearance.FilterPanel.Options.UseBackColor = true;
			this.gridView1.Appearance.FilterPanel.Options.UseForeColor = true;
			this.gridView1.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(122)), ((System.Byte)(114)), ((System.Byte)(113)));
			this.gridView1.Appearance.FixedLine.Options.UseBackColor = true;
			this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
			this.gridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
			this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
			this.gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
			this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(192)), ((System.Byte)(157)));
			this.gridView1.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((System.Byte)(226)), ((System.Byte)(219)), ((System.Byte)(188)));
			this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
			this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
			this.gridView1.Appearance.FocusedRow.Options.UseBorderColor = true;
			this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
			this.gridView1.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(216)), ((System.Byte)(209)), ((System.Byte)(170)));
			this.gridView1.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((System.Byte)(216)), ((System.Byte)(209)), ((System.Byte)(170)));
			this.gridView1.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
			this.gridView1.Appearance.FooterPanel.Options.UseBackColor = true;
			this.gridView1.Appearance.FooterPanel.Options.UseBorderColor = true;
			this.gridView1.Appearance.FooterPanel.Options.UseForeColor = true;
			this.gridView1.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(216)), ((System.Byte)(209)), ((System.Byte)(179)));
			this.gridView1.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((System.Byte)(216)), ((System.Byte)(209)), ((System.Byte)(179)));
			this.gridView1.Appearance.GroupButton.Options.UseBackColor = true;
			this.gridView1.Appearance.GroupButton.Options.UseBorderColor = true;
			this.gridView1.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(236)), ((System.Byte)(232)), ((System.Byte)(201)));
			this.gridView1.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((System.Byte)(236)), ((System.Byte)(232)), ((System.Byte)(201)));
			this.gridView1.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
			this.gridView1.Appearance.GroupFooter.Options.UseBackColor = true;
			this.gridView1.Appearance.GroupFooter.Options.UseBorderColor = true;
			this.gridView1.Appearance.GroupFooter.Options.UseForeColor = true;
			this.gridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(246)), ((System.Byte)(242)), ((System.Byte)(213)));
			this.gridView1.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
			this.gridView1.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
			this.gridView1.Appearance.GroupPanel.Options.UseBackColor = true;
			this.gridView1.Appearance.GroupPanel.Options.UseForeColor = true;
			this.gridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(236)), ((System.Byte)(232)), ((System.Byte)(201)));
			this.gridView1.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((System.Byte)(236)), ((System.Byte)(232)), ((System.Byte)(201)));
			this.gridView1.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
			this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
			this.gridView1.Appearance.GroupRow.Options.UseBorderColor = true;
			this.gridView1.Appearance.GroupRow.Options.UseForeColor = true;
			this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(216)), ((System.Byte)(209)), ((System.Byte)(170)));
			this.gridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((System.Byte)(216)), ((System.Byte)(209)), ((System.Byte)(170)));
			this.gridView1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
			this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
			this.gridView1.Appearance.HeaderPanel.Options.UseBorderColor = true;
			this.gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
			this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(237)), ((System.Byte)(230)), ((System.Byte)(203)));
			this.gridView1.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((System.Byte)(237)), ((System.Byte)(230)), ((System.Byte)(203)));
			this.gridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
			this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
			this.gridView1.Appearance.HideSelectionRow.Options.UseBorderColor = true;
			this.gridView1.Appearance.HideSelectionRow.Options.UseForeColor = true;
			this.gridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(216)), ((System.Byte)(209)), ((System.Byte)(170)));
			this.gridView1.Appearance.HorzLine.Options.UseBackColor = true;
			this.gridView1.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(242)), ((System.Byte)(244)), ((System.Byte)(236)));
			this.gridView1.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((System.Byte)(242)), ((System.Byte)(244)), ((System.Byte)(236)));
			this.gridView1.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
			this.gridView1.Appearance.OddRow.Options.UseBackColor = true;
			this.gridView1.Appearance.OddRow.Options.UseBorderColor = true;
			this.gridView1.Appearance.OddRow.Options.UseForeColor = true;
			this.gridView1.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(251)), ((System.Byte)(252)), ((System.Byte)(247)));
			this.gridView1.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
			this.gridView1.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(148)), ((System.Byte)(148)), ((System.Byte)(148)));
			this.gridView1.Appearance.Preview.Options.UseBackColor = true;
			this.gridView1.Appearance.Preview.Options.UseFont = true;
			this.gridView1.Appearance.Preview.Options.UseForeColor = true;
			this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(242)), ((System.Byte)(244)), ((System.Byte)(236)));
			this.gridView1.Appearance.Row.ForeColor = System.Drawing.Color.Black;
			this.gridView1.Appearance.Row.Options.UseBackColor = true;
			this.gridView1.Appearance.Row.Options.UseForeColor = true;
			this.gridView1.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(236)), ((System.Byte)(232)), ((System.Byte)(201)));
			this.gridView1.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
			this.gridView1.Appearance.RowSeparator.Options.UseBackColor = true;
			this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(221)), ((System.Byte)(215)), ((System.Byte)(188)));
			this.gridView1.Appearance.SelectedRow.BorderColor = System.Drawing.Color.FromArgb(((System.Byte)(237)), ((System.Byte)(230)), ((System.Byte)(203)));
			this.gridView1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
			this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
			this.gridView1.Appearance.SelectedRow.Options.UseBorderColor = true;
			this.gridView1.Appearance.SelectedRow.Options.UseForeColor = true;
			this.gridView1.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
			this.gridView1.Appearance.TopNewRow.Options.UseBackColor = true;
			this.gridView1.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(216)), ((System.Byte)(209)), ((System.Byte)(170)));
			this.gridView1.Appearance.VertLine.Options.UseBackColor = true;
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn1,
																							 this.gridColumn2,
																							 this.gridColumn3,
																							 this.gridColumn4,
																							 this.gridColumn5});
			this.gridView1.GridControl = this.gridControl1;
			this.gridView1.Name = "gridView1";
			this.gridView1.OptionsBehavior.AllowIncrementalSearch = true;
			this.gridView1.OptionsBehavior.Editable = false;
			this.gridView1.OptionsCustomization.AllowColumnMoving = false;
			this.gridView1.OptionsCustomization.AllowFilter = false;
			this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
			this.gridView1.OptionsView.EnableAppearanceOddRow = true;
			this.gridView1.OptionsView.ShowGroupPanel = false;
			this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "Employee Id";
			this.gridColumn1.FieldName = "nEmployeeID";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 0;
			// 
			// gridColumn2
			// 
			this.gridColumn2.Caption = "Employee Name";
			this.gridColumn2.FieldName = "strEmployeeName";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 1;
			// 
			// gridColumn3
			// 
			this.gridColumn3.Caption = "Job Position";
			this.gridColumn3.FieldName = "strJobPositionCode";
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 2;
			// 
			// gridColumn4
			// 
			this.gridColumn4.Caption = "Branch";
			this.gridColumn4.FieldName = "strBranchCode";
			this.gridColumn4.Name = "gridColumn4";
			this.gridColumn4.Visible = true;
			this.gridColumn4.VisibleIndex = 3;
			// 
			// gridColumn5
			// 
			this.gridColumn5.Caption = "Start Date";
			this.gridColumn5.DisplayFormat.FormatString = "{0:dd/MM/yyyy}";
			this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.gridColumn5.FieldName = "dtEmployeeStartDate";
			this.gridColumn5.Name = "gridColumn5";
			this.gridColumn5.Visible = true;
			this.gridColumn5.VisibleIndex = 4;
			// 
			// repositoryItemCheckEdit1
			// 
			this.repositoryItemCheckEdit1.AutoHeight = false;
			this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
			this.repositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
			// 
			// repositoryItemCheckEdit2
			// 
			this.repositoryItemCheckEdit2.AutoHeight = false;
			this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
			this.repositoryItemCheckEdit2.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
			// 
			// repositoryItemCheckEdit3
			// 
			this.repositoryItemCheckEdit3.AutoHeight = false;
			this.repositoryItemCheckEdit3.Name = "repositoryItemCheckEdit3";
			this.repositoryItemCheckEdit3.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
			// 
			// repositoryItemCheckEdit4
			// 
			this.repositoryItemCheckEdit4.AutoHeight = false;
			this.repositoryItemCheckEdit4.Name = "repositoryItemCheckEdit4";
			this.repositoryItemCheckEdit4.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
			// 
			// repositoryItemCheckEdit5
			// 
			this.repositoryItemCheckEdit5.AutoHeight = false;
			this.repositoryItemCheckEdit5.Name = "repositoryItemCheckEdit5";
			this.repositoryItemCheckEdit5.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
			// 
			// repositoryItemCheckEdit6
			// 
			this.repositoryItemCheckEdit6.AutoHeight = false;
			this.repositoryItemCheckEdit6.Name = "repositoryItemCheckEdit6";
			this.repositoryItemCheckEdit6.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
			// 
			// repositoryItemCheckEdit7
			// 
			this.repositoryItemCheckEdit7.AutoHeight = false;
			this.repositoryItemCheckEdit7.Name = "repositoryItemCheckEdit7";
			this.repositoryItemCheckEdit7.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
			// 
			// panelControl1
			// 
			this.panelControl1.Controls.Add(this.label1);
			this.panelControl1.Controls.Add(this.sbtnSearch);
			this.panelControl1.Controls.Add(this.txtSearchKey);
			this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelControl1.Location = new System.Drawing.Point(0, 0);
			this.panelControl1.Name = "panelControl1";
			this.panelControl1.Size = new System.Drawing.Size(936, 48);
			this.panelControl1.TabIndex = 5;
			this.panelControl1.Text = "panelControl1";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(120, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "Employee Id / Name";
			// 
			// sbtnSearch
			// 
			this.sbtnSearch.Location = new System.Drawing.Point(296, 16);
			this.sbtnSearch.Name = "sbtnSearch";
			this.sbtnSearch.TabIndex = 1;
			this.sbtnSearch.Text = "Search";
			this.sbtnSearch.Click += new System.EventHandler(this.sbtnSearch_Click);
			// 
			// txtSearchKey
			// 
			this.txtSearchKey.EditValue = "";
			this.txtSearchKey.Location = new System.Drawing.Point(144, 16);
			this.txtSearchKey.Name = "txtSearchKey";
			this.txtSearchKey.Size = new System.Drawing.Size(146, 20);
			this.txtSearchKey.TabIndex = 0;
			// 
			// frmSearchEmployee
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(936, 501);
			this.Controls.Add(this.panelControl1);
			this.Controls.Add(this.groupControl1);
			this.Controls.Add(this.panelControl2);
			this.Name = "frmSearchEmployee";
			this.Text = "Search Employee";
			this.Load += new System.EventHandler(this.frmSearchEmployee_Load);
			((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
			this.panelControl2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
			this.groupControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit6)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit7)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
			this.panelControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.txtSearchKey.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void LoadEmployee()
		{
			string sql = "Select nEmployeeID, strEmployeeName, strJobPositionCode, strBranchCode, dtEmployeeStartDate from tblEmployee";
			
			if (StrBranchCode=="")
			{
				if (txtSearchKey.EditValue.ToString() != "")
					sql += " Where strEmployeeName like '%" + txtSearchKey.EditValue + "%' Or nEmployeeID like '%" + txtSearchKey.EditValue + "%'";
			}
			else
			{
				sql += " Where strBranchCode='" + StrBranchCode + "'";
				if (txtSearchKey.EditValue.ToString() != "")
					sql += " and strEmployeeName like '%" + txtSearchKey.EditValue + "%' Or nEmployeeID like '%" + txtSearchKey.EditValue + "%'";
			}
				
		
			DataSet _ds = new DataSet();

			SqlHelper.FillDataset(connection,CommandType.Text,sql,_ds,new string[] {"table"}, new SqlParameter("@sstrKey", searchKey));
			DataTable dt = _ds.Tables["table"];
			DataView dv = new DataView(dt);

//			if (txtSearchKey.EditValue.ToString() != "")
//				dv.RowFilter = " strEmployeeName like '% " + txtSearchKey.EditValue + "%'";

			gridControl1.DataSource = dv;

			strEmployeeID = string.Empty;
			
		}
		private void sbtnCancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void sbtnOK_Click(object sender, System.EventArgs e)
		{
			if (gridView1.FocusedRowHandle >= 0)
			{
				strEmployeeID = gridView1.GetDataRow(gridView1.FocusedRowHandle)["nEmployeeID"].ToString();
				this.DialogResult = DialogResult.OK;
			}
			else
			{
				ACMS.Utils.UI.ShowMessage(this, "Please select a row first.");
			}
		}

		private void sbtnSearch_Click(object sender, System.EventArgs e)
		{
				LoadEmployee();
		}

		private void gridView1_DoubleClick(object sender, System.EventArgs e)
		{
			DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hitInfo = ACMS.XtraUtils.GridViewUtils.GetGridHitInfo(gridView1);

			if (hitInfo.InRow)
			{
				sbtnOK.PerformClick();
			}
		}

		private void frmSearchEmployee_Load(object sender, System.EventArgs e)
		{
			LoadEmployee();
		}
	}
}
