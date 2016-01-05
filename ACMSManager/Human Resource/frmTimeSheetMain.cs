using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Do = Acms.Core.Domain;
using ACMSLogic;
using ACMS.Utils;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;
using DevExpress.XtraGrid.Views.Grid;
using ACMSDAL;


namespace ACMS.ACMSManager.Human_Resource
{
	/// <summary>
	/// Summary description for frmTimeSheetMain.
	/// </summary>
	public class frmTimeSheetMain : System.Windows.Forms.Form
	{
		private ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder myLookUpEdit;

		private DataTable dtEmployee;
		private DataView dvEmployee;
		private Timesheet myTimesheet;
		private Do.Employee employee;
		private Do.TerminalUser terminalUser; 
		private User oUser;
		private int myCurrentEmployeeID;
		private SqlConnection connection;

		#region Windows Designer generated variables
		private System.ComponentModel.IContainer components;
		private DevExpress.XtraEditors.GroupControl groupTimeSheet;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label158;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label5;
		private DevExpress.XtraEditors.ImageComboBoxEdit Month;
		private DevExpress.XtraEditors.ImageComboBoxEdit Year;
		private DevExpress.XtraEditors.ImageComboBoxEdit cmbBranch;
		internal DevExpress.XtraGrid.GridControl gridctrTimesheet;
		internal DevExpress.XtraGrid.Columns.GridColumn colTimesheetDate;
		internal DevExpress.XtraGrid.Columns.GridColumn colTimesheetRosterIn;
		internal DevExpress.XtraGrid.Columns.GridColumn colTimesheetRosterOut;
		internal DevExpress.XtraGrid.Columns.GridColumn colTimesheetBranchFirstTimeIn;
		internal DevExpress.XtraGrid.Columns.GridColumn colTimesheetBranchLastTimeOut;
		internal DevExpress.XtraGrid.Columns.GridColumn colTimesheetFirstTimeIn;
		private DevExpress.XtraGrid.Columns.GridColumn colTimesheetLastTimeOut;
		internal DevExpress.XtraGrid.Columns.GridColumn colTimesheetManagerNameIn;
		private DevExpress.XtraGrid.Columns.GridColumn colTimesheetManagerNameOut;
		private DevExpress.XtraGrid.Columns.GridColumn colTimesheetLateness;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
		internal DevExpress.XtraGrid.Views.Grid.GridView gvTimeSheet;
		private DevExpress.XtraEditors.GroupControl groupTimeSheetDetails;
		internal DevExpress.XtraGrid.GridControl gridctrTimeCard;
		internal DevExpress.XtraGrid.Views.Grid.GridView gvTimeCard;
		internal DevExpress.XtraGrid.Columns.GridColumn colTimesheetDetailDate;
		internal DevExpress.XtraGrid.Columns.GridColumn colTimesheetDetailBranch;
		internal DevExpress.XtraGrid.Columns.GridColumn colTimesheetDetailTime;
		internal DevExpress.XtraGrid.Columns.GridColumn colTimesheetDetailRemarks;
		internal DevExpress.XtraGrid.Columns.GridColumn colTimesheetDetailManager;
		private System.Windows.Forms.ImageList imageList1;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
		private DevExpress.XtraGrid.Columns.GridColumn colTimesheetDetailEntryID;
		private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
		private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit repositoryItemTimeEdit1;
		private DevExpress.XtraGrid.Columns.GridColumn colTimesheetDetailEmployeeID;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lkedtBranch2;
		private DevExpress.XtraEditors.ImageComboBoxEdit ddlMember;
		private DevExpress.XtraEditors.SimpleButton sbtnSave;
		private DevExpress.XtraEditors.SimpleButton sbtnEnquiry;
		internal DevExpress.XtraEditors.SimpleButton btnAdd;
		internal DevExpress.XtraEditors.SimpleButton btnDelete;
		internal DevExpress.XtraGrid.Columns.GridColumn colRemark;
		private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
		private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
		private DevExpress.XtraGrid.Columns.GridColumn Rosterid;
		private DevExpress.XtraGrid.Columns.GridColumn colTimesheetTotalLateness;

		#endregion

		public frmTimeSheetMain()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmTimeSheetMain));
			this.groupTimeSheet = new DevExpress.XtraEditors.GroupControl();
			this.sbtnSave = new DevExpress.XtraEditors.SimpleButton();
			this.ddlMember = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
			this.gridctrTimesheet = new DevExpress.XtraGrid.GridControl();
			this.gvTimeSheet = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colTimesheetDate = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colTimesheetRosterIn = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colTimesheetRosterOut = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colTimesheetBranchFirstTimeIn = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colTimesheetBranchLastTimeOut = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colTimesheetFirstTimeIn = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colTimesheetLastTimeOut = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colTimesheetManagerNameIn = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colTimesheetManagerNameOut = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colTimesheetLateness = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.colTimesheetTotalLateness = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
			this.Rosterid = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
			this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
			this.groupTimeSheetDetails = new DevExpress.XtraEditors.GroupControl();
			this.gridctrTimeCard = new DevExpress.XtraGrid.GridControl();
			this.gvTimeCard = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colTimesheetDetailBranch = new DevExpress.XtraGrid.Columns.GridColumn();
			this.lkedtBranch2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			this.colTimesheetDetailDate = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colTimesheetDetailTime = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemTimeEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
			this.colTimesheetDetailRemarks = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colTimesheetDetailManager = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colTimesheetDetailEntryID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colTimesheetDetailEmployeeID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
			this.sbtnEnquiry = new DevExpress.XtraEditors.SimpleButton();
			this.cmbBranch = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.label1 = new System.Windows.Forms.Label();
			this.Month = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.Year = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.label158 = new System.Windows.Forms.Label();
			this.label25 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.groupTimeSheet)).BeginInit();
			this.groupTimeSheet.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ddlMember.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridctrTimesheet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvTimeSheet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupTimeSheetDetails)).BeginInit();
			this.groupTimeSheetDetails.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridctrTimeCard)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvTimeCard)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkedtBranch2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbBranch.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Month.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Year.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// groupTimeSheet
			// 
			this.groupTimeSheet.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.groupTimeSheet.Appearance.Options.UseBackColor = true;
			this.groupTimeSheet.Controls.Add(this.sbtnSave);
			this.groupTimeSheet.Controls.Add(this.ddlMember);
			this.groupTimeSheet.Controls.Add(this.btnAdd);
			this.groupTimeSheet.Controls.Add(this.btnDelete);
			this.groupTimeSheet.Controls.Add(this.gridctrTimesheet);
			this.groupTimeSheet.Controls.Add(this.groupTimeSheetDetails);
			this.groupTimeSheet.Controls.Add(this.sbtnEnquiry);
			this.groupTimeSheet.Controls.Add(this.cmbBranch);
			this.groupTimeSheet.Controls.Add(this.label1);
			this.groupTimeSheet.Controls.Add(this.Month);
			this.groupTimeSheet.Controls.Add(this.Year);
			this.groupTimeSheet.Controls.Add(this.label158);
			this.groupTimeSheet.Controls.Add(this.label25);
			this.groupTimeSheet.Controls.Add(this.label5);
			this.groupTimeSheet.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupTimeSheet.Location = new System.Drawing.Point(0, 0);
			this.groupTimeSheet.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.groupTimeSheet.LookAndFeel.UseDefaultLookAndFeel = false;
			this.groupTimeSheet.LookAndFeel.UseWindowsXPTheme = false;
			this.groupTimeSheet.Name = "groupTimeSheet";
			this.groupTimeSheet.Size = new System.Drawing.Size(920, 584);
			this.groupTimeSheet.TabIndex = 28;
			this.groupTimeSheet.Text = "Timesheet";
			// 
			// sbtnSave
			// 
			this.sbtnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.sbtnSave.Enabled = false;
			this.sbtnSave.Location = new System.Drawing.Point(80, 320);
			this.sbtnSave.Name = "sbtnSave";
			this.sbtnSave.TabIndex = 182;
			this.sbtnSave.Text = "Save";
			this.sbtnSave.Click += new System.EventHandler(this.sbtnSave_Click);
			// 
			// ddlMember
			// 
			this.ddlMember.Location = new System.Drawing.Point(568, 32);
			this.ddlMember.Name = "ddlMember";
			// 
			// ddlMember.Properties
			// 
			this.ddlMember.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
			this.ddlMember.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.ddlMember.Size = new System.Drawing.Size(176, 22);
			this.ddlMember.TabIndex = 181;
			// 
			// btnAdd
			// 
			this.btnAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnAdd.Appearance.Options.UseFont = true;
			this.btnAdd.Appearance.Options.UseTextOptions = true;
			this.btnAdd.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.btnAdd.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
			this.btnAdd.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.btnAdd.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.btnAdd.ImageIndex = 0;
			this.btnAdd.ImageList = this.imageList1;
			this.btnAdd.ImeMode = System.Windows.Forms.ImeMode.On;
			this.btnAdd.Location = new System.Drawing.Point(8, 320);
			this.btnAdd.LookAndFeel.UseDefaultLookAndFeel = false;
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(30, 24);
			this.btnAdd.TabIndex = 180;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
			// 
			// btnDelete
			// 
			this.btnDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnDelete.Appearance.Options.UseFont = true;
			this.btnDelete.Appearance.Options.UseTextOptions = true;
			this.btnDelete.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.btnDelete.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
			this.btnDelete.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.btnDelete.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.btnDelete.ImageIndex = 1;
			this.btnDelete.ImageList = this.imageList1;
			this.btnDelete.Location = new System.Drawing.Point(40, 320);
			this.btnDelete.LookAndFeel.UseDefaultLookAndFeel = false;
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(30, 24);
			this.btnDelete.TabIndex = 179;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// gridctrTimesheet
			// 
			this.gridctrTimesheet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			// 
			// gridctrTimesheet.EmbeddedNavigator
			// 
			this.gridctrTimesheet.EmbeddedNavigator.Name = "";
			this.gridctrTimesheet.Location = new System.Drawing.Point(-8, 56);
			this.gridctrTimesheet.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.gridctrTimesheet.LookAndFeel.UseDefaultLookAndFeel = false;
			this.gridctrTimesheet.LookAndFeel.UseWindowsXPTheme = false;
			this.gridctrTimesheet.MainView = this.gvTimeSheet;
			this.gridctrTimesheet.Name = "gridctrTimesheet";
			this.gridctrTimesheet.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																													  this.repositoryItemCheckEdit2,
																													  this.repositoryItemTextEdit1,
																													  this.repositoryItemSpinEdit1});
			this.gridctrTimesheet.Size = new System.Drawing.Size(920, 248);
			this.gridctrTimesheet.TabIndex = 178;
			this.gridctrTimesheet.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																											this.gvTimeSheet});
			// 
			// gvTimeSheet
			// 
			this.gvTimeSheet.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							   this.colTimesheetDate,
																							   this.colTimesheetRosterIn,
																							   this.colTimesheetRosterOut,
																							   this.colTimesheetBranchFirstTimeIn,
																							   this.colTimesheetBranchLastTimeOut,
																							   this.colTimesheetFirstTimeIn,
																							   this.colTimesheetLastTimeOut,
																							   this.colTimesheetManagerNameIn,
																							   this.colTimesheetManagerNameOut,
																							   this.colTimesheetLateness,
																							   this.colTimesheetTotalLateness,
																							   this.colRemark,
																							   this.Rosterid});
			this.gvTimeSheet.GridControl = this.gridctrTimesheet;
			this.gvTimeSheet.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
			this.gvTimeSheet.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
																								 new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "nLateness", this.colTimesheetTotalLateness, "Total")});
			this.gvTimeSheet.Name = "gvTimeSheet";
			this.gvTimeSheet.OptionsBehavior.AllowIncrementalSearch = true;
			this.gvTimeSheet.OptionsCustomization.AllowFilter = false;
			this.gvTimeSheet.OptionsView.EnableAppearanceOddRow = true;
			this.gvTimeSheet.OptionsView.ShowFooter = true;
			this.gvTimeSheet.OptionsView.ShowGroupPanel = false;
			this.gvTimeSheet.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
																										new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colTimesheetDate, DevExpress.Data.ColumnSortOrder.Descending)});
			this.gvTimeSheet.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridViewTimeSheet_RowStyle);
			this.gvTimeSheet.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvTimeSheet_FocusedRowChanged);
			// 
			// colTimesheetDate
			// 
			this.colTimesheetDate.Caption = "Date";
			this.colTimesheetDate.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.colTimesheetDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.colTimesheetDate.FieldName = "dtDate";
			this.colTimesheetDate.Name = "colTimesheetDate";
			this.colTimesheetDate.OptionsColumn.AllowEdit = false;
			this.colTimesheetDate.Visible = true;
			this.colTimesheetDate.VisibleIndex = 0;
			this.colTimesheetDate.Width = 100;
			// 
			// colTimesheetRosterIn
			// 
			this.colTimesheetRosterIn.Caption = "Roster In";
			this.colTimesheetRosterIn.DisplayFormat.FormatString = "hh:mm tt";
			this.colTimesheetRosterIn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.colTimesheetRosterIn.FieldName = "Expected Start Time";
			this.colTimesheetRosterIn.Name = "colTimesheetRosterIn";
			this.colTimesheetRosterIn.OptionsColumn.AllowEdit = false;
			this.colTimesheetRosterIn.Visible = true;
			this.colTimesheetRosterIn.VisibleIndex = 1;
			this.colTimesheetRosterIn.Width = 65;
			// 
			// colTimesheetRosterOut
			// 
			this.colTimesheetRosterOut.Caption = "Roster Out";
			this.colTimesheetRosterOut.DisplayFormat.FormatString = "hh:mm tt";
			this.colTimesheetRosterOut.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.colTimesheetRosterOut.FieldName = "Expected End Time";
			this.colTimesheetRosterOut.Name = "colTimesheetRosterOut";
			this.colTimesheetRosterOut.OptionsColumn.AllowEdit = false;
			this.colTimesheetRosterOut.Visible = true;
			this.colTimesheetRosterOut.VisibleIndex = 2;
			this.colTimesheetRosterOut.Width = 65;
			// 
			// colTimesheetBranchFirstTimeIn
			// 
			this.colTimesheetBranchFirstTimeIn.Caption = "Branch of First Time In";
			this.colTimesheetBranchFirstTimeIn.FieldName = "strBranchCodeIn";
			this.colTimesheetBranchFirstTimeIn.Name = "colTimesheetBranchFirstTimeIn";
			this.colTimesheetBranchFirstTimeIn.Width = 65;
			// 
			// colTimesheetBranchLastTimeOut
			// 
			this.colTimesheetBranchLastTimeOut.Caption = "Branch of Last Time Out";
			this.colTimesheetBranchLastTimeOut.FieldName = "strBranchCodeOut";
			this.colTimesheetBranchLastTimeOut.Name = "colTimesheetBranchLastTimeOut";
			this.colTimesheetBranchLastTimeOut.Width = 65;
			// 
			// colTimesheetFirstTimeIn
			// 
			this.colTimesheetFirstTimeIn.Caption = "Time (In)";
			this.colTimesheetFirstTimeIn.DisplayFormat.FormatString = "hh:mm tt";
			this.colTimesheetFirstTimeIn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.colTimesheetFirstTimeIn.FieldName = "First Time In";
			this.colTimesheetFirstTimeIn.Name = "colTimesheetFirstTimeIn";
			this.colTimesheetFirstTimeIn.OptionsColumn.AllowEdit = false;
			this.colTimesheetFirstTimeIn.Visible = true;
			this.colTimesheetFirstTimeIn.VisibleIndex = 3;
			this.colTimesheetFirstTimeIn.Width = 65;
			// 
			// colTimesheetLastTimeOut
			// 
			this.colTimesheetLastTimeOut.Caption = "Time (Out)";
			this.colTimesheetLastTimeOut.DisplayFormat.FormatString = "hh:mm tt";
			this.colTimesheetLastTimeOut.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.colTimesheetLastTimeOut.FieldName = "Last Time Out";
			this.colTimesheetLastTimeOut.Name = "colTimesheetLastTimeOut";
			this.colTimesheetLastTimeOut.OptionsColumn.AllowEdit = false;
			this.colTimesheetLastTimeOut.Visible = true;
			this.colTimesheetLastTimeOut.VisibleIndex = 4;
			this.colTimesheetLastTimeOut.Width = 65;
			// 
			// colTimesheetManagerNameIn
			// 
			this.colTimesheetManagerNameIn.Caption = "Edit (In)";
			this.colTimesheetManagerNameIn.FieldName = "strManagerNameIn";
			this.colTimesheetManagerNameIn.Name = "colTimesheetManagerNameIn";
			this.colTimesheetManagerNameIn.OptionsColumn.AllowEdit = false;
			this.colTimesheetManagerNameIn.Visible = true;
			this.colTimesheetManagerNameIn.VisibleIndex = 5;
			// 
			// colTimesheetManagerNameOut
			// 
			this.colTimesheetManagerNameOut.Caption = "Edit (Out)";
			this.colTimesheetManagerNameOut.FieldName = "strManagerNameOut";
			this.colTimesheetManagerNameOut.Name = "colTimesheetManagerNameOut";
			this.colTimesheetManagerNameOut.OptionsColumn.AllowEdit = false;
			this.colTimesheetManagerNameOut.Visible = true;
			this.colTimesheetManagerNameOut.VisibleIndex = 6;
			// 
			// colTimesheetLateness
			// 
			this.colTimesheetLateness.Caption = "Lateness";
			this.colTimesheetLateness.ColumnEdit = this.repositoryItemCheckEdit2;
			this.colTimesheetLateness.FieldName = "fLateness";
			this.colTimesheetLateness.Name = "colTimesheetLateness";
			this.colTimesheetLateness.Width = 59;
			// 
			// repositoryItemCheckEdit2
			// 
			this.repositoryItemCheckEdit2.AutoHeight = false;
			this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
			this.repositoryItemCheckEdit2.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
			// 
			// colTimesheetTotalLateness
			// 
			this.colTimesheetTotalLateness.Caption = "Total Lateness";
			this.colTimesheetTotalLateness.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.colTimesheetTotalLateness.FieldName = "nLateness";
			this.colTimesheetTotalLateness.Name = "colTimesheetTotalLateness";
			this.colTimesheetTotalLateness.OptionsColumn.AllowEdit = false;
			this.colTimesheetTotalLateness.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
			this.colTimesheetTotalLateness.Visible = true;
			this.colTimesheetTotalLateness.VisibleIndex = 7;
			this.colTimesheetTotalLateness.Width = 65;
			// 
			// colRemark
			// 
			this.colRemark.Caption = "Remark";
			this.colRemark.FieldName = "strRemarks";
			this.colRemark.Name = "colRemark";
			this.colRemark.Visible = true;
			this.colRemark.VisibleIndex = 8;
			this.colRemark.Width = 324;
			// 
			// Rosterid
			// 
			this.Rosterid.Caption = "rosterID";
			this.Rosterid.FieldName = "nRosterID";
			this.Rosterid.Name = "Rosterid";
			// 
			// repositoryItemTextEdit1
			// 
			this.repositoryItemTextEdit1.AutoHeight = false;
			this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
			// 
			// repositoryItemSpinEdit1
			// 
			this.repositoryItemSpinEdit1.AutoHeight = false;
			this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												 new DevExpress.XtraEditors.Controls.EditorButton()});
			this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
			// 
			// groupTimeSheetDetails
			// 
			this.groupTimeSheetDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupTimeSheetDetails.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.groupTimeSheetDetails.Appearance.Options.UseBackColor = true;
			this.groupTimeSheetDetails.Controls.Add(this.gridctrTimeCard);
			this.groupTimeSheetDetails.Location = new System.Drawing.Point(8, 344);
			this.groupTimeSheetDetails.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.groupTimeSheetDetails.LookAndFeel.UseDefaultLookAndFeel = false;
			this.groupTimeSheetDetails.Name = "groupTimeSheetDetails";
			this.groupTimeSheetDetails.Size = new System.Drawing.Size(904, 232);
			this.groupTimeSheetDetails.TabIndex = 177;
			this.groupTimeSheetDetails.Text = "Timesheet Details";
			// 
			// gridctrTimeCard
			// 
			this.gridctrTimeCard.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// gridctrTimeCard.EmbeddedNavigator
			// 
			this.gridctrTimeCard.EmbeddedNavigator.Buttons.Append.Visible = false;
			this.gridctrTimeCard.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
			this.gridctrTimeCard.EmbeddedNavigator.Buttons.Edit.Visible = false;
			this.gridctrTimeCard.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
			this.gridctrTimeCard.EmbeddedNavigator.Buttons.Remove.Visible = false;
			this.gridctrTimeCard.EmbeddedNavigator.Name = "";
			this.gridctrTimeCard.Location = new System.Drawing.Point(4, 18);
			this.gridctrTimeCard.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.gridctrTimeCard.LookAndFeel.UseDefaultLookAndFeel = false;
			this.gridctrTimeCard.LookAndFeel.UseWindowsXPTheme = false;
			this.gridctrTimeCard.MainView = this.gvTimeCard;
			this.gridctrTimeCard.Name = "gridctrTimeCard";
			this.gridctrTimeCard.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																													 this.repositoryItemLookUpEdit1,
																													 this.repositoryItemButtonEdit1,
																													 this.repositoryItemTimeEdit1,
																													 this.lkedtBranch2});
			this.gridctrTimeCard.Size = new System.Drawing.Size(896, 210);
			this.gridctrTimeCard.TabIndex = 2;
			this.gridctrTimeCard.UseEmbeddedNavigator = true;
			this.gridctrTimeCard.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										   this.gvTimeCard});
			// 
			// gvTimeCard
			// 
			this.gvTimeCard.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							  this.colTimesheetDetailBranch,
																							  this.colTimesheetDetailDate,
																							  this.colTimesheetDetailTime,
																							  this.colTimesheetDetailRemarks,
																							  this.colTimesheetDetailManager,
																							  this.colTimesheetDetailEntryID,
																							  this.colTimesheetDetailEmployeeID});
			this.gvTimeCard.GridControl = this.gridctrTimeCard;
			this.gvTimeCard.Name = "gvTimeCard";
			this.gvTimeCard.OptionsBehavior.AllowIncrementalSearch = true;
			this.gvTimeCard.OptionsBehavior.AutoSelectAllInEditor = false;
			this.gvTimeCard.OptionsCustomization.AllowFilter = false;
			this.gvTimeCard.OptionsCustomization.AllowSort = false;
			this.gvTimeCard.OptionsView.ShowGroupPanel = false;
			this.gvTimeCard.LostFocus += new System.EventHandler(this.gvTimeCard_LostFocus);
			this.gvTimeCard.DataSourceChanged += new System.EventHandler(this.gvTimeCard_DataSourceChanged);
			// 
			// colTimesheetDetailBranch
			// 
			this.colTimesheetDetailBranch.Caption = "Branch";
			this.colTimesheetDetailBranch.ColumnEdit = this.lkedtBranch2;
			this.colTimesheetDetailBranch.FieldName = "strBranchCode";
			this.colTimesheetDetailBranch.Name = "colTimesheetDetailBranch";
			this.colTimesheetDetailBranch.Visible = true;
			this.colTimesheetDetailBranch.VisibleIndex = 0;
			this.colTimesheetDetailBranch.Width = 109;
			// 
			// lkedtBranch2
			// 
			this.lkedtBranch2.AutoHeight = false;
			this.lkedtBranch2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																									  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkedtBranch2.Name = "lkedtBranch2";
			// 
			// colTimesheetDetailDate
			// 
			this.colTimesheetDetailDate.Caption = "Date";
			this.colTimesheetDetailDate.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.colTimesheetDetailDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.colTimesheetDetailDate.FieldName = "dtDate";
			this.colTimesheetDetailDate.Name = "colTimesheetDetailDate";
			this.colTimesheetDetailDate.Width = 149;
			// 
			// colTimesheetDetailTime
			// 
			this.colTimesheetDetailTime.Caption = "Time";
			this.colTimesheetDetailTime.ColumnEdit = this.repositoryItemTimeEdit1;
			this.colTimesheetDetailTime.DisplayFormat.FormatString = "hh:mm tt";
			this.colTimesheetDetailTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.colTimesheetDetailTime.FieldName = "dtTime";
			this.colTimesheetDetailTime.Name = "colTimesheetDetailTime";
			this.colTimesheetDetailTime.Visible = true;
			this.colTimesheetDetailTime.VisibleIndex = 1;
			this.colTimesheetDetailTime.Width = 104;
			// 
			// repositoryItemTimeEdit1
			// 
			this.repositoryItemTimeEdit1.AutoHeight = false;
			this.repositoryItemTimeEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												 new DevExpress.XtraEditors.Controls.EditorButton()});
			this.repositoryItemTimeEdit1.EditFormat.FormatString = "hh:mm tt";
			this.repositoryItemTimeEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.repositoryItemTimeEdit1.Mask.EditMask = "hh:mm tt";
			this.repositoryItemTimeEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
			this.repositoryItemTimeEdit1.Name = "repositoryItemTimeEdit1";
			// 
			// colTimesheetDetailRemarks
			// 
			this.colTimesheetDetailRemarks.Caption = "Remarks";
			this.colTimesheetDetailRemarks.FieldName = "strRemarks";
			this.colTimesheetDetailRemarks.Name = "colTimesheetDetailRemarks";
			this.colTimesheetDetailRemarks.Visible = true;
			this.colTimesheetDetailRemarks.VisibleIndex = 2;
			this.colTimesheetDetailRemarks.Width = 456;
			// 
			// colTimesheetDetailManager
			// 
			this.colTimesheetDetailManager.Caption = "Manager";
			this.colTimesheetDetailManager.FieldName = "nManagerID";
			this.colTimesheetDetailManager.Name = "colTimesheetDetailManager";
			this.colTimesheetDetailManager.OptionsColumn.AllowEdit = false;
			this.colTimesheetDetailManager.Visible = true;
			this.colTimesheetDetailManager.VisibleIndex = 3;
			this.colTimesheetDetailManager.Width = 254;
			// 
			// colTimesheetDetailEntryID
			// 
			this.colTimesheetDetailEntryID.Caption = "Entry ID";
			this.colTimesheetDetailEntryID.FieldName = "nEntryID";
			this.colTimesheetDetailEntryID.Name = "colTimesheetDetailEntryID";
			// 
			// colTimesheetDetailEmployeeID
			// 
			this.colTimesheetDetailEmployeeID.Caption = "Employee ID";
			this.colTimesheetDetailEmployeeID.FieldName = "nEmployeeID";
			this.colTimesheetDetailEmployeeID.Name = "colTimesheetDetailEmployeeID";
			// 
			// repositoryItemLookUpEdit1
			// 
			this.repositoryItemLookUpEdit1.AutoHeight = false;
			this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
			// 
			// repositoryItemButtonEdit1
			// 
			this.repositoryItemButtonEdit1.AutoHeight = false;
			this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												   new DevExpress.XtraEditors.Controls.EditorButton()});
			this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
			// 
			// sbtnEnquiry
			// 
			this.sbtnEnquiry.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.sbtnEnquiry.Appearance.Options.UseFont = true;
			this.sbtnEnquiry.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnEnquiry.Location = new System.Drawing.Point(752, 32);
			this.sbtnEnquiry.LookAndFeel.UseDefaultLookAndFeel = false;
			this.sbtnEnquiry.Name = "sbtnEnquiry";
			this.sbtnEnquiry.TabIndex = 176;
			this.sbtnEnquiry.Text = "Enquiry";
			this.sbtnEnquiry.Click += new System.EventHandler(this.sbtnEnquiry_Click);
			// 
			// cmbBranch
			// 
			this.cmbBranch.Location = new System.Drawing.Point(104, 32);
			this.cmbBranch.Name = "cmbBranch";
			// 
			// cmbBranch.Properties
			// 
			this.cmbBranch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
			this.cmbBranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cmbBranch.Size = new System.Drawing.Size(120, 22);
			this.cmbBranch.TabIndex = 173;
			this.cmbBranch.SelectedValueChanged += new System.EventHandler(this.cmbBranch_SelectedValueChanged);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(360, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 22);
			this.label1.TabIndex = 58;
			this.label1.Text = "Year";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// Month
			// 
			this.Month.EditValue = 1;
			this.Month.Location = new System.Drawing.Point(272, 32);
			this.Month.Name = "Month";
			// 
			// Month.Properties
			// 
			this.Month.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
			this.Month.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																										  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.Month.Properties.Items.AddRange(new object[] {
																  new DevExpress.XtraEditors.Controls.ImageComboBoxItem("January", 1, -1),
																  new DevExpress.XtraEditors.Controls.ImageComboBoxItem("February", 2, -1),
																  new DevExpress.XtraEditors.Controls.ImageComboBoxItem("March", 3, -1),
																  new DevExpress.XtraEditors.Controls.ImageComboBoxItem("April", 4, -1),
																  new DevExpress.XtraEditors.Controls.ImageComboBoxItem("May", 5, -1),
																  new DevExpress.XtraEditors.Controls.ImageComboBoxItem("June", 6, -1),
																  new DevExpress.XtraEditors.Controls.ImageComboBoxItem("July", 7, -1),
																  new DevExpress.XtraEditors.Controls.ImageComboBoxItem("August", 8, -1),
																  new DevExpress.XtraEditors.Controls.ImageComboBoxItem("September", 9, -1),
																  new DevExpress.XtraEditors.Controls.ImageComboBoxItem("October", 10, -1),
																  new DevExpress.XtraEditors.Controls.ImageComboBoxItem("November", 11, -1),
																  new DevExpress.XtraEditors.Controls.ImageComboBoxItem("December", 12, -1)});
			this.Month.Size = new System.Drawing.Size(72, 22);
			this.Month.TabIndex = 57;
			// 
			// Year
			// 
			this.Year.Location = new System.Drawing.Point(392, 32);
			this.Year.Name = "Year";
			// 
			// Year.Properties
			// 
			this.Year.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
			this.Year.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																										 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.Year.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.Year.Size = new System.Drawing.Size(72, 22);
			this.Year.TabIndex = 56;
			// 
			// label158
			// 
			this.label158.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label158.ForeColor = System.Drawing.Color.Black;
			this.label158.Location = new System.Drawing.Point(232, 32);
			this.label158.Name = "label158";
			this.label158.Size = new System.Drawing.Size(40, 22);
			this.label158.TabIndex = 23;
			this.label158.Text = "Month";
			this.label158.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label25
			// 
			this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label25.ForeColor = System.Drawing.Color.Black;
			this.label25.Location = new System.Drawing.Point(8, 32);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(96, 22);
			this.label25.TabIndex = 19;
			this.label25.Text = "Filter by Branch";
			this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.Location = new System.Drawing.Point(472, 32);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(96, 22);
			this.label5.TabIndex = 169;
			this.label5.Text = "Employee Name";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frmTimeSheetMain
			// 
			this.AutoScale = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(920, 584);
			this.Controls.Add(this.groupTimeSheet);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmTimeSheetMain";
			this.Text = "frmTimeSheetMain";
			this.Load += new System.EventHandler(this.frmTimeSheetMain_Load);
			this.Leave += new System.EventHandler(this.frmTimeSheetMain_Leave);
			((System.ComponentModel.ISupportInitialize)(this.groupTimeSheet)).EndInit();
			this.groupTimeSheet.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ddlMember.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridctrTimesheet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvTimeSheet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupTimeSheetDetails)).EndInit();
			this.groupTimeSheetDetails.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridctrTimeCard)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvTimeCard)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkedtBranch2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbBranch.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Month.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Year.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region security
		public void initData (ACMSLogic.User User)
		{
			oUser = User;
			MemberRecord myMemberRecord = new MemberRecord(oUser.StrBranchCode());
		}

		public void SetEmployeeRecord(Do.Employee emp)
		{
			employee = emp;
		}

		public void SetTerminalUser(Do.TerminalUser tu)
		{
			terminalUser = tu;
		}
		
		#endregion

		# region Initializing Data
		private void frmTimeSheetMain_Load(object sender, System.EventArgs e)
		{
			connection = new SqlConnection(SqlHelperUtils.connectionString);
			BindCalendar();
			BindEmployee();
			BindBranch();
			myTimesheet = new Timesheet(employee.Id);
			myTimesheet.OnDetailTableChangedUpdate = new Timesheet.DetailTableChangedUpdate(SetsbtnSaveState);
		}
		private void BindEmployee()
		{
			string sql = "Select nEmployeeID, strEmployeeName, strJobPositionCode, strBranchCode, dtEmployeeStartDate from "
				+"tblEmployee where nstatusID=1 order by strEmployeeName";
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, 
				new SqlParameter("@strSQL", sql) );
			dtEmployee = _ds.Tables["table"];
			comboBind(ddlMember,sql,"strEmployeeName","nEmployeeID",true);
			ddlMember.Properties.Items.Insert(0,new DevExpress.XtraEditors.Controls.ImageComboBoxItem("- Please Select -",0,-1));

			if (ddlMember.Properties.Items.Count > 0)
				ddlMember.SelectedIndex = 0;
		}
		private void BindCalendar()
		{
			string strSQL = "select distinct Year(dtDate) as strYear from tblRoster order by Year(dtDate) desc";

			comboBind(Year, strSQL, "strYear", "strYear", true);

			if (Year.SelectedItem == null)
			{
				Year.Properties.Items.Insert(0,new DevExpress.XtraEditors.Controls.ImageComboBoxItem(
					DateTime.Today.Year.ToString(),DateTime.Today.Year.ToString()));
				if (Year.Properties.Items.Count > 0)
					Year.SelectedIndex = 0;
			}

			this.Month.EditValue = DateTime.Now.Month;
		}

		private void BindBranch()
		{
			string strSQL = "Select strBranchCode,strBranchName from TblBranch Where nBrStatusID =1 and strBranchCode In ("
				+"Select strBranchCode from tblemployeebranchrights Where nEmployeeId = " + employee.Id + ")";

			comboBind(cmbBranch, strSQL, "strBranchName", "strBranchCode", true);
			cmbBranch.Properties.Items.Insert(0,new DevExpress.XtraEditors.Controls.ImageComboBoxItem("- Please Select -",""));
			cmbBranch.SelectedIndex = 0;

			//lkedtBranch2
			strSQL = "Select strBranchCode,strBranchName from TblBranch Where nBrStatusID =1";
			DataSet _ds = new DataSet(); 
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, 
				new SqlParameter("@strSQL", strSQL) );
			DataTable dt = _ds.Tables["Table"];
			DevExpress.XtraEditors.Controls.LookUpColumnInfo[] col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
			col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strBranchCode","Branch Code",15,
				DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strBranchName","Description",15,
				DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			myLookUpEdit = new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(lkedtBranch2,dt,col,"strBranchCode",
				"strBranchCode","Branch");
		}

		private void comboBind(DevExpress.XtraEditors.ImageComboBoxEdit control,string strSQL,string display,string strValue,
			bool fNum)
		{
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, 
				new SqlParameter("@strSQL", strSQL) );
			DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox properties = control.Properties;
			properties.Items.BeginUpdate();
			properties.Items.Clear();

			try 
			{
				foreach(DataRow dr in _ds.Tables["Table"].Rows)
				{
					//Initialize each item with the display text, value and image index
					properties.Items.Add( new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr[display].ToString(), 
						dr[strValue],-1));
				}
			}
			finally 
			{
				properties.Items.EndUpdate();
			}
			//Select the first item
			if (control.Properties.Items.Count > 0)
				control.SelectedIndex = 0;
		}

		private void cmbBranch_SelectedValueChanged(object sender, System.EventArgs e)
		{
			if ( cmbBranch.EditValue.ToString() != "" )
			{
				dvEmployee = new DataView(dtEmployee);
				dvEmployee.RowFilter = "strBranchCode='" + cmbBranch.EditValue.ToString() + "'";
		

				DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox properties = ddlMember.Properties;
				properties.Items.BeginUpdate();
				properties.Items.Clear();

				try 
				{
					foreach(DataRowView dr in dvEmployee)
					{
						//Initialize each item with the display text, value and image index
						properties.Items.Add( new DevExpress.XtraEditors.Controls.ImageComboBoxItem(
							dr["strEmployeeName"].ToString(), dr["nEmployeeID"],-1));
					}
				}
				finally 
				{
					properties.Items.EndUpdate();
				}
				ddlMember.Properties.Items.Insert(0,new DevExpress.XtraEditors.Controls.ImageComboBoxItem("- Please Select -", 0,
					-1));
				ddlMember.SelectedIndex = 0;
			}
			//LoadTimeSheet();
		}

//		private void ddlMember_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
//		{
//			if ( e.KeyChar == 13  )
//			{
//				DataSet _ds = new DataSet();
//				DataTable dt;
//
//				string sql = "Select nEmployeeID, strEmployeeName from tblEmployee";
//			
//				if (ddlMember.EditValue.ToString() != "")
//					sql += " Where strEmployeeName like '%" + ddlMember.EditValue + "%' Or nEmployeeID like '%" 
//						+ ddlMember.EditValue + "%'";
//
//				SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, 
//					new SqlParameter("@strSQL", sql) );
//				dt = _ds.Tables["Table"];
//				
//				if (dt.Rows.Count == 1)
//				{
//					myCurrentEmployeeID = Convert.ToInt32(dt.Rows[0]["nEmployeeID"]);
//					LoadTimeSheet();
//				}
//				else if (dt.Rows.Count > 1)
//				{
////					EmployeeSrcID = "";
//					ACMS.ACMSManager.frmSearchEmployee myForm = new ACMS.ACMSManager.frmSearchEmployee(
//						ddlMember.EditValue.ToString(),cmbBranch.EditValue.ToString());
//					if (DialogResult.OK == myForm.ShowDialog(this))
//					{
//						ddlMember.EditValue = myForm.StrEmployeeID;
//						LoadTimeSheet();
//					}
//					myForm.Dispose();
//				}
//			}
//		}
		# endregion 

		#region Load TimeSheet Data
		private void LoadTimeSheet()
		{
			myCurrentEmployeeID = ACMS.Convert.ToInt32(ddlMember.EditValue);
			myTimesheet.ListTimesheetWithLateness(ACMS.Convert.ToInt32(ddlMember.EditValue), cmbBranch.EditValue.ToString(), 
				(ACMSLogic.Staff.Month)Month.SelectedIndex, Convert.ToInt32(Year.EditValue));
			gridctrTimesheet.DataSource = myTimesheet.MasterTable;

		}

		private void ListTimesheetDetail()
		{
			if (gvTimeSheet.FocusedRowHandle < 0)
				return;

			DataRow row = gvTimeSheet.GetDataRow(gvTimeSheet.FocusedRowHandle);
			DateTime date = ACMS.Convert.ToDateTime(row["dtDate"]);
			
			myTimesheet.ListTimesheetDetail(ACMS.Convert.ToInt32(ddlMember.EditValue),cmbBranch.EditValue.ToString(), 
				date.Date, date.Date.AddDays(1));
			gridctrTimeCard.DataSource = myTimesheet.DetailTable;
			
		}
		#endregion

		private void SetsbtnSaveState()
		{
			if (!sbtnSave.Enabled)
				sbtnSave.Enabled = true;
		}

		private void gridViewTimeSheet_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
		{
			GridView view = sender as GridView;

			if(e.RowHandle >= 0) 
			{
				DataRow r = view.GetDataRow(e.RowHandle);
				if(r != null && ACMS.Convert.ToBoolean(r["fLateness"])) 
				{
					e.Appearance.ForeColor = Color.Red;
				}
                if (r != null && r["Expected End Time"].ToString() == string.Empty)
                {
                    e.Appearance.ForeColor = Color.Red;
                }
			}
		}

		private void EndEdit()
		{
			gridctrTimeCard.MainView.CloseEditor();
			gridctrTimeCard.MainView.UpdateCurrentRow();
			gridctrTimesheet.MainView.CloseEditor();
			gridctrTimesheet.MainView.UpdateCurrentRow();
		}

		private void sbtnEnquiry_Click(object sender, System.EventArgs e)
		{
			EndEdit();
			if (sbtnSave.Enabled && UI.ShowYesNoMessage(this, "Do you want to save changes?"))
			{
				sbtnSave.PerformClick();
			}
			LoadTimeSheet();
			ListTimesheetDetail();
			sbtnSave.Enabled = false;
		}

		private void gvTimeSheet_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
			UpdateTimeSheetRecord(gvTimeSheet.GetDataRow(gvTimeSheet.FocusedRowHandle));
			AskSave();
			ListTimesheetDetail();
		}

		private void UpdateTimeSheetRecord(DataRow CurrRosterRow)
		{			
			
			TblRoster myRoster = new TblRoster();	
			myRoster.NRosterID = ACMS.Convert.ToInt32(CurrRosterRow["nRosterID"]);
			myRoster.StrRemarks = CurrRosterRow["strRemarks"].ToString();
			myRoster.Update2();
		}
		private void AskSave()
		{
			EndEdit();
			if (sbtnSave.Enabled && UI.ShowYesNoMessage(this, "Do you want to save TimeSheet changes?"))
			{
				sbtnSave.PerformClick();
			}
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			if(employee.Id.ToString()==myCurrentEmployeeID.ToString())
			{
				MessageBox.Show("OMG!!!Are you trying to change your own timesheet?? From now on 1 minute lateness will be 5 dollar.");
				return;
			}
			EndEdit();
			DataRow rMaster = gvTimeSheet.GetDataRow(gvTimeSheet.FocusedRowHandle);
			if (rMaster != null)
				myTimesheet.AddNewRow(employee.Id, myCurrentEmployeeID, Convert.ToDateTime(rMaster["dtDate"]));
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			EndEdit();
			if (gvTimeCard.FocusedRowHandle >= 0)
			{
				gvTimeCard.DeleteRow(gvTimeCard.FocusedRowHandle);
			}
		}

		private void gvTimeCard_DataSourceChanged(object sender, System.EventArgs e)
		{
			sbtnSave.Enabled = false;
		}

		private void sbtnSave_Click(object sender, System.EventArgs e)
		{
			if(employee.Id.ToString()==myCurrentEmployeeID.ToString())
			{
				MessageBox.Show("OMG!!!Are you still trying to change your own timesheet again and again?? From now on 1 minute lateness will be 10 dollar.");
				return;
			}

			EndEdit();

			for(int i = 0; i < gvTimeCard.RowCount; i++)
			{
				if (gvTimeCard.GetRowCellValue(i, colTimesheetDetailBranch).ToString().Length == 0)
				{
					UI.ShowErrorMessage(this, "Branch is not allow empty. Save failed.");
					return;
				}

				if (gvTimeCard.GetRowCellValue(i, colTimesheetDetailTime).ToString().Length == 0)
				{
					UI.ShowErrorMessage(this, "Time is not allow empty. Save failed.");
					return;
				}
			}

			myTimesheet.Save();
			sbtnSave.Enabled = false;

			sbtnEnquiry_Click(sender, e);
		}

		private void gvTimeCard_LostFocus(object sender, System.EventArgs e)
		{
			EndEdit();
		}

		private void frmTimeSheetMain_Leave(object sender, System.EventArgs e)
		{
			AskSave();
		}
	}
}
