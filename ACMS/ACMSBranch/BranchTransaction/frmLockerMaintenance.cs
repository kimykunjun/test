using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;
using Do = Acms.Core.Domain;
using ACMSLogic;
using ACMS.Utils;

namespace ACMS.ACMSBranch.BranchTransaction
{
	/// <summary>
	/// Summary description for frmLockerMaintenance.
	/// </summary>
	public class frmLockerMaintenance : System.Windows.Forms.Form
	{
		private static int LockerRowFocus;
		private static int CurrentLockerRowFocus;
		private string connectionString;
		private SqlConnection connection;
		private static Do.Employee employee;
		private static Do.TerminalUser terminalUser; 
		private static User oUser;
		internal DevExpress.XtraEditors.GroupControl groupLockerMaintenanceEntry;
		internal DevExpress.XtraEditors.SimpleButton btnChangeExpiryDate;
		internal DevExpress.XtraEditors.SimpleButton btnTransfer;
		private DevExpress.XtraEditors.ImageComboBoxEdit cmbLockerStatus;
		internal DevExpress.XtraEditors.SimpleButton btnUnBlock;
		internal DevExpress.XtraEditors.SimpleButton btnBlock;
		internal DevExpress.XtraGrid.GridControl gridLocker;
		internal DevExpress.XtraGrid.Views.Grid.GridView GridViewLocker;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn239;
		private DevExpress.XtraEditors.Repository.RepositoryItemMRUEdit repositoryItemMRUEdit1;
		private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
		private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit2;
		private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
		internal DevExpress.XtraGrid.Columns.GridColumn nLockerNo;
		internal DevExpress.XtraGrid.Columns.GridColumn strMembershipID;
		private DevExpress.XtraGrid.Columns.GridColumn strRemarks;
		private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit3;
		private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
		internal DevExpress.XtraEditors.GroupControl groupMemberRecordAudit;
		internal DevExpress.XtraEditors.GroupControl GroupControl7;
		internal DevExpress.XtraGrid.Views.Grid.GridView gvAuditTrail;
		internal DevExpress.XtraGrid.Columns.GridColumn gcATDate;
		internal DevExpress.XtraGrid.Columns.GridColumn gcATActionString;
		internal DevExpress.XtraGrid.Columns.GridColumn gcATActionBYID;
		private DevExpress.XtraGrid.Columns.GridColumn gcATActionBy;
		internal DevExpress.XtraGrid.GridControl gcAudit;
		private DevExpress.XtraGrid.Columns.GridColumn dtExpiry;
		private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit3;
		private ACMS.ACMSBranch.BranchTransaction.frmTransferLocker myTMForm; 


		public frmLockerMaintenance()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);

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
			this.groupLockerMaintenanceEntry = new DevExpress.XtraEditors.GroupControl();
			this.btnChangeExpiryDate = new DevExpress.XtraEditors.SimpleButton();
			this.btnTransfer = new DevExpress.XtraEditors.SimpleButton();
			this.cmbLockerStatus = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.btnUnBlock = new DevExpress.XtraEditors.SimpleButton();
			this.btnBlock = new DevExpress.XtraEditors.SimpleButton();
			this.gridLocker = new DevExpress.XtraGrid.GridControl();
			this.GridViewLocker = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.nLockerNo = new DevExpress.XtraGrid.Columns.GridColumn();
			this.strMembershipID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.dtExpiry = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemDateEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
			this.GridColumn239 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.strRemarks = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemMemoEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
			this.repositoryItemMRUEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMRUEdit();
			this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
			this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
			this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
			this.repositoryItemDateEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
			this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			this.groupMemberRecordAudit = new DevExpress.XtraEditors.GroupControl();
			this.GroupControl7 = new DevExpress.XtraEditors.GroupControl();
			this.gcAudit = new DevExpress.XtraGrid.GridControl();
			this.gvAuditTrail = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gcATDate = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gcATActionString = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gcATActionBYID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gcATActionBy = new DevExpress.XtraGrid.Columns.GridColumn();
			((System.ComponentModel.ISupportInitialize)(this.groupLockerMaintenanceEntry)).BeginInit();
			this.groupLockerMaintenanceEntry.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbLockerStatus.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridLocker)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GridViewLocker)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemMRUEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupMemberRecordAudit)).BeginInit();
			this.groupMemberRecordAudit.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.GroupControl7)).BeginInit();
			this.GroupControl7.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gcAudit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvAuditTrail)).BeginInit();
			this.SuspendLayout();
			// 
			// groupLockerMaintenanceEntry
			// 
			this.groupLockerMaintenanceEntry.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.groupLockerMaintenanceEntry.Appearance.Options.UseBackColor = true;
			this.groupLockerMaintenanceEntry.Controls.Add(this.btnChangeExpiryDate);
			this.groupLockerMaintenanceEntry.Controls.Add(this.btnTransfer);
			this.groupLockerMaintenanceEntry.Controls.Add(this.cmbLockerStatus);
			this.groupLockerMaintenanceEntry.Controls.Add(this.btnUnBlock);
			this.groupLockerMaintenanceEntry.Controls.Add(this.btnBlock);
			this.groupLockerMaintenanceEntry.Controls.Add(this.gridLocker);
			this.groupLockerMaintenanceEntry.Location = new System.Drawing.Point(8, 0);
			this.groupLockerMaintenanceEntry.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.groupLockerMaintenanceEntry.LookAndFeel.UseDefaultLookAndFeel = false;
			this.groupLockerMaintenanceEntry.LookAndFeel.UseWindowsXPTheme = false;
			this.groupLockerMaintenanceEntry.Name = "groupLockerMaintenanceEntry";
			this.groupLockerMaintenanceEntry.Size = new System.Drawing.Size(984, 352);
			this.groupLockerMaintenanceEntry.TabIndex = 2;
			this.groupLockerMaintenanceEntry.Text = "LOCKER MAINTENANCE";
			// 
			// btnChangeExpiryDate
			// 
			this.btnChangeExpiryDate.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnChangeExpiryDate.Appearance.Options.UseFont = true;
			this.btnChangeExpiryDate.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnChangeExpiryDate.Location = new System.Drawing.Point(416, 32);
			this.btnChangeExpiryDate.Name = "btnChangeExpiryDate";
			this.btnChangeExpiryDate.Size = new System.Drawing.Size(136, 20);
			this.btnChangeExpiryDate.TabIndex = 10;
			this.btnChangeExpiryDate.Text = "Change Expiry Date";
			this.btnChangeExpiryDate.Visible = false;
			this.btnChangeExpiryDate.Click += new System.EventHandler(this.btnChangeExpiryDate_Click);
			// 
			// btnTransfer
			// 
			this.btnTransfer.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnTransfer.Appearance.Options.UseFont = true;
			this.btnTransfer.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnTransfer.Location = new System.Drawing.Point(336, 32);
			this.btnTransfer.Name = "btnTransfer";
			this.btnTransfer.Size = new System.Drawing.Size(68, 20);
			this.btnTransfer.TabIndex = 9;
			this.btnTransfer.Text = "Transfer";
			this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
			// 
			// cmbLockerStatus
			// 
			this.cmbLockerStatus.EditValue = "imageComboBoxEdit1";
			this.cmbLockerStatus.Location = new System.Drawing.Point(16, 32);
			this.cmbLockerStatus.Name = "cmbLockerStatus";
			// 
			// cmbLockerStatus.Properties
			// 
			this.cmbLockerStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cmbLockerStatus.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.cmbLockerStatus.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.cmbLockerStatus.Properties.EditFormat.FormatString = "dd/MM/yyyy";
			this.cmbLockerStatus.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.cmbLockerStatus.Size = new System.Drawing.Size(148, 20);
			this.cmbLockerStatus.TabIndex = 8;
			this.cmbLockerStatus.SelectedIndexChanged += new System.EventHandler(this.cmbLockerStatus_SelectedIndexChanged);
			// 
			// btnUnBlock
			// 
			this.btnUnBlock.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnUnBlock.Appearance.Options.UseFont = true;
			this.btnUnBlock.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnUnBlock.Location = new System.Drawing.Point(256, 32);
			this.btnUnBlock.Name = "btnUnBlock";
			this.btnUnBlock.Size = new System.Drawing.Size(68, 20);
			this.btnUnBlock.TabIndex = 7;
			this.btnUnBlock.Text = "Un-Block";
			this.btnUnBlock.Click += new System.EventHandler(this.btnUnBlock_Click);
			// 
			// btnBlock
			// 
			this.btnBlock.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnBlock.Appearance.Options.UseFont = true;
			this.btnBlock.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnBlock.Location = new System.Drawing.Point(176, 32);
			this.btnBlock.Name = "btnBlock";
			this.btnBlock.Size = new System.Drawing.Size(68, 20);
			this.btnBlock.TabIndex = 6;
			this.btnBlock.Text = "Block";
			this.btnBlock.Click += new System.EventHandler(this.btnBlock_Click);
			// 
			// gridLocker
			// 
			this.gridLocker.Dock = System.Windows.Forms.DockStyle.Bottom;
			// 
			// gridLocker.EmbeddedNavigator
			// 
			this.gridLocker.EmbeddedNavigator.Name = "";
			this.gridLocker.Location = new System.Drawing.Point(2, 62);
			this.gridLocker.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.gridLocker.LookAndFeel.UseDefaultLookAndFeel = false;
			this.gridLocker.LookAndFeel.UseWindowsXPTheme = false;
			this.gridLocker.MainView = this.GridViewLocker;
			this.gridLocker.Name = "gridLocker";
			this.gridLocker.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																												this.repositoryItemMRUEdit1,
																												this.repositoryItemMemoEdit1,
																												this.repositoryItemMemoEdit2,
																												this.repositoryItemDateEdit1,
																												this.repositoryItemMemoEdit3,
																												this.repositoryItemDateEdit2,
																												this.repositoryItemLookUpEdit1,
																												this.repositoryItemDateEdit3});
			this.gridLocker.Size = new System.Drawing.Size(980, 288);
			this.gridLocker.TabIndex = 5;
			this.gridLocker.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																									  this.GridViewLocker});
			// 
			// GridViewLocker
			// 
			this.GridViewLocker.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																								  this.nLockerNo,
																								  this.strMembershipID,
																								  this.dtExpiry,
																								  this.GridColumn239,
																								  this.strRemarks});
			this.GridViewLocker.GridControl = this.gridLocker;
			this.GridViewLocker.Name = "GridViewLocker";
			this.GridViewLocker.OptionsCustomization.AllowFilter = false;
			this.GridViewLocker.OptionsCustomization.AllowGroup = false;
			this.GridViewLocker.OptionsCustomization.AllowSort = false;
			this.GridViewLocker.OptionsView.ShowGroupPanel = false;
			this.GridViewLocker.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.GridViewLocker_CellValueChanged);
			this.GridViewLocker.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GridViewLocker_FocusedRowChanged);
			// 
			// nLockerNo
			// 
			this.nLockerNo.Caption = "Locker No";
			this.nLockerNo.FieldName = "nLockerNo";
			this.nLockerNo.Name = "nLockerNo";
			this.nLockerNo.OptionsColumn.AllowEdit = false;
			this.nLockerNo.Visible = true;
			this.nLockerNo.VisibleIndex = 0;
			this.nLockerNo.Width = 146;
			// 
			// strMembershipID
			// 
			this.strMembershipID.Caption = "Membership ID";
			this.strMembershipID.FieldName = "strMembershipID";
			this.strMembershipID.Name = "strMembershipID";
			this.strMembershipID.OptionsColumn.AllowEdit = false;
			this.strMembershipID.Visible = true;
			this.strMembershipID.VisibleIndex = 1;
			this.strMembershipID.Width = 196;
			// 
			// dtExpiry
			// 
			this.dtExpiry.AppearanceCell.BackColor = System.Drawing.SystemColors.Control;
			this.dtExpiry.AppearanceCell.Options.UseBackColor = true;
			this.dtExpiry.Caption = "Expiry Date";
			this.dtExpiry.ColumnEdit = this.repositoryItemDateEdit3;
			this.dtExpiry.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.dtExpiry.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.dtExpiry.FieldName = "dtExpiry";
			this.dtExpiry.Name = "dtExpiry";
			this.dtExpiry.Visible = true;
			this.dtExpiry.VisibleIndex = 2;
			// 
			// repositoryItemDateEdit3
			// 
			this.repositoryItemDateEdit3.AutoHeight = false;
			this.repositoryItemDateEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemDateEdit3.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.repositoryItemDateEdit3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.repositoryItemDateEdit3.EditFormat.FormatString = "dd/MM/yyyy";
			this.repositoryItemDateEdit3.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.repositoryItemDateEdit3.Mask.EditMask = "dd/MM/yyyy";
			this.repositoryItemDateEdit3.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
			this.repositoryItemDateEdit3.Name = "repositoryItemDateEdit3";
			// 
			// GridColumn239
			// 
			this.GridColumn239.AppearanceCell.BackColor = System.Drawing.Color.White;
			this.GridColumn239.AppearanceCell.Options.UseBackColor = true;
			this.GridColumn239.Caption = "Status";
			this.GridColumn239.FieldName = "Status";
			this.GridColumn239.Name = "GridColumn239";
			this.GridColumn239.OptionsColumn.AllowEdit = false;
			this.GridColumn239.Width = 193;
			// 
			// strRemarks
			// 
			this.strRemarks.AppearanceCell.BackColor = System.Drawing.SystemColors.Control;
			this.strRemarks.AppearanceCell.Options.UseBackColor = true;
			this.strRemarks.Caption = "Remark";
			this.strRemarks.ColumnEdit = this.repositoryItemMemoEdit3;
			this.strRemarks.FieldName = "strRemarks";
			this.strRemarks.Name = "strRemarks";
			this.strRemarks.Visible = true;
			this.strRemarks.VisibleIndex = 3;
			this.strRemarks.Width = 273;
			// 
			// repositoryItemMemoEdit3
			// 
			this.repositoryItemMemoEdit3.Name = "repositoryItemMemoEdit3";
			// 
			// repositoryItemMRUEdit1
			// 
			this.repositoryItemMRUEdit1.AutoHeight = false;
			this.repositoryItemMRUEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemMRUEdit1.Name = "repositoryItemMRUEdit1";
			// 
			// repositoryItemMemoEdit1
			// 
			this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
			// 
			// repositoryItemMemoEdit2
			// 
			this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";
			// 
			// repositoryItemDateEdit1
			// 
			this.repositoryItemDateEdit1.AutoHeight = false;
			this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
			// 
			// repositoryItemDateEdit2
			// 
			this.repositoryItemDateEdit2.AutoHeight = false;
			this.repositoryItemDateEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemDateEdit2.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.repositoryItemDateEdit2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.repositoryItemDateEdit2.EditFormat.FormatString = "dd/MM/yyyy";
			this.repositoryItemDateEdit2.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.repositoryItemDateEdit2.Mask.EditMask = "dd/MM/yyyy";
			this.repositoryItemDateEdit2.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
			this.repositoryItemDateEdit2.Name = "repositoryItemDateEdit2";
			// 
			// repositoryItemLookUpEdit1
			// 
			this.repositoryItemLookUpEdit1.AutoHeight = false;
			this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
			// 
			// groupMemberRecordAudit
			// 
			this.groupMemberRecordAudit.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.groupMemberRecordAudit.Appearance.Options.UseBackColor = true;
			this.groupMemberRecordAudit.Controls.Add(this.GroupControl7);
			this.groupMemberRecordAudit.Location = new System.Drawing.Point(8, 360);
			this.groupMemberRecordAudit.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.groupMemberRecordAudit.LookAndFeel.UseDefaultLookAndFeel = false;
			this.groupMemberRecordAudit.LookAndFeel.UseWindowsXPTheme = false;
			this.groupMemberRecordAudit.Name = "groupMemberRecordAudit";
			this.groupMemberRecordAudit.Size = new System.Drawing.Size(984, 200);
			this.groupMemberRecordAudit.TabIndex = 8;
			this.groupMemberRecordAudit.Text = "AUDIT TRAIL";
			// 
			// GroupControl7
			// 
			this.GroupControl7.Controls.Add(this.gcAudit);
			this.GroupControl7.Dock = System.Windows.Forms.DockStyle.Fill;
			this.GroupControl7.Location = new System.Drawing.Point(2, 20);
			this.GroupControl7.Name = "GroupControl7";
			this.GroupControl7.ShowCaption = false;
			this.GroupControl7.Size = new System.Drawing.Size(980, 178);
			this.GroupControl7.TabIndex = 0;
			this.GroupControl7.Text = "GroupControl1";
			// 
			// gcAudit
			// 
			this.gcAudit.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// gcAudit.EmbeddedNavigator
			// 
			this.gcAudit.EmbeddedNavigator.Name = "";
			this.gcAudit.Location = new System.Drawing.Point(4, 4);
			this.gcAudit.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.gcAudit.LookAndFeel.UseDefaultLookAndFeel = false;
			this.gcAudit.LookAndFeel.UseWindowsXPTheme = false;
			this.gcAudit.MainView = this.gvAuditTrail;
			this.gcAudit.Name = "gcAudit";
			this.gcAudit.Size = new System.Drawing.Size(972, 170);
			this.gcAudit.TabIndex = 5;
			this.gcAudit.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																								   this.gvAuditTrail});
			// 
			// gvAuditTrail
			// 
			this.gvAuditTrail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																								this.gcATDate,
																								this.gcATActionString,
																								this.gcATActionBYID,
																								this.gcATActionBy});
			this.gvAuditTrail.GridControl = this.gcAudit;
			this.gvAuditTrail.Name = "gvAuditTrail";
			this.gvAuditTrail.OptionsBehavior.AllowIncrementalSearch = true;
			this.gvAuditTrail.OptionsBehavior.Editable = false;
			this.gvAuditTrail.OptionsCustomization.AllowFilter = false;
			this.gvAuditTrail.OptionsView.ShowGroupPanel = false;
			this.gvAuditTrail.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
																										 new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gcATDate, DevExpress.Data.ColumnSortOrder.Descending)});
			// 
			// gcATDate
			// 
			this.gcATDate.Caption = "Date";
			this.gcATDate.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.gcATDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.gcATDate.FieldName = "dtDate";
			this.gcATDate.Name = "gcATDate";
			this.gcATDate.Visible = true;
			this.gcATDate.VisibleIndex = 0;
			this.gcATDate.Width = 121;
			// 
			// gcATActionString
			// 
			this.gcATActionString.Caption = "Action String";
			this.gcATActionString.FieldName = "strAuditEntry";
			this.gcATActionString.Name = "gcATActionString";
			this.gcATActionString.Visible = true;
			this.gcATActionString.VisibleIndex = 1;
			this.gcATActionString.Width = 489;
			// 
			// gcATActionBYID
			// 
			this.gcATActionBYID.Caption = "Action By ID";
			this.gcATActionBYID.FieldName = "nEmployeeID";
			this.gcATActionBYID.Name = "gcATActionBYID";
			this.gcATActionBYID.Visible = true;
			this.gcATActionBYID.VisibleIndex = 2;
			this.gcATActionBYID.Width = 114;
			// 
			// gcATActionBy
			// 
			this.gcATActionBy.Caption = "Action By";
			this.gcATActionBy.FieldName = "strEmployeeName";
			this.gcATActionBy.Name = "gcATActionBy";
			this.gcATActionBy.Visible = true;
			this.gcATActionBy.VisibleIndex = 3;
			this.gcATActionBy.Width = 235;
			// 
			// frmLockerMaintenance
			// 
			this.AutoScale = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(999, 560);
			this.Controls.Add(this.groupMemberRecordAudit);
			this.Controls.Add(this.groupLockerMaintenanceEntry);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmLockerMaintenance";
			this.Text = "frmLockerMaintenance";
			this.Load += new System.EventHandler(this.frmLockerMaintenance_Load);
			((System.ComponentModel.ISupportInitialize)(this.groupLockerMaintenanceEntry)).EndInit();
			this.groupLockerMaintenanceEntry.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.cmbLockerStatus.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridLocker)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GridViewLocker)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemMRUEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupMemberRecordAudit)).EndInit();
			this.groupMemberRecordAudit.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.GroupControl7)).EndInit();
			this.GroupControl7.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gcAudit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvAuditTrail)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void frmLockerMaintenance_Load(object sender, System.EventArgs e)
		{
			LockerRowFocus = 0;
			BindLockerStatus();
			initLockerMaintenance();
	
		}

		#region Locker Maintenance

		public enum LockerStatusEnum
		{
			All = 0,
			Occupied = 1,
			Available = 2,
			Expired_within_a_week = 3,
			Expired = 4
		}


		private void BindLockerStatus()
		{
			DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox properties = cmbLockerStatus.Properties;
			properties.Items.BeginUpdate();
			properties.Items.Clear();
		
			//	properties.Items.Add( new DevExpress.XtraEditors.Controls.ImageComboBoxItem("All",0));
			try 
			{
				foreach(int s in Enum.GetValues(typeof(LockerStatusEnum)))
				{
					//Initialize each item with the display text, value and image index
					properties.Items.Add( new DevExpress.XtraEditors.Controls.ImageComboBoxItem(Enum.GetName(typeof(LockerStatusEnum),s).Replace("_"," "),s.ToString()));
				}
			}
			finally 
			{
				properties.Items.EndUpdate();
			}
			//Select the first item
			cmbLockerStatus.SelectedIndex = 0;
		}

		private void initLockerMaintenance()
		{
				
			DataSet _ds = new DataSet();
						
			if (cmbLockerStatus.SelectedItem.ToString() != "")
			{
				LockerStatusEnum selectedStatus = (LockerStatusEnum)Enum.Parse(typeof(LockerStatusEnum),cmbLockerStatus.SelectedItem.ToString().Replace(" ","_")); 
				string i;
				i = selectedStatus.ToString().Replace("_"," ");
			}
		
			string strSQL = "up_get_Locker '" + oUser.StrBranchCode().ToString() + "'";

			if (cmbLockerStatus.EditValue.ToString() != "")
			{
				strSQL += "," + cmbLockerStatus.EditValue;
			}

			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			
			this.gridLocker.DataSource = _ds.Tables["table"];

		}

		private void cmbLockerStatus_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(cmbLockerStatus.EditValue.ToString()=="0")
			{
				DataRow dr;
				dr = GridViewLocker.GetDataRow(GridViewLocker.FocusedRowHandle);
				if( dr != null)
				{
					if(dr["Status"].ToString() != "Occupied")
					{
						//btnBlock.Enabled = false;
						//btnUnBlock.Enabled = true;
						btnTransfer.Enabled = true;
					}
					else
					{
						btnTransfer.Enabled = false;
					}
				}

			}
			if(cmbLockerStatus.EditValue.ToString()=="1")
			{
				//btnBlock.Enabled = false;
				//btnUnBlock.Enabled = true;
				btnTransfer.Enabled = true;
			}
			else 
			{
				//btnBlock.Enabled = true;
				//btnUnBlock.Enabled = false;
				btnTransfer.Enabled = false;
			}
			initLockerMaintenance();
		}

		private void btnBlock_Click(object sender, System.EventArgs e)
		{
		
			if (this.GridViewLocker.RowCount > 0)
			{
				employee.RightsLevel.Id = 39;
				if (employee.HasRight("AB_BLOCK_LOCKER"))
				{
					DataRow dr = this.GridViewLocker.GetDataRow(this.GridViewLocker.FocusedRowHandle);
			
					int output;
					output = 0;

					SqlHelper.ExecuteNonQuery(connection,"Up_TblLockerStatus",
						new SqlParameter("@retval",output),
						new SqlParameter("@StatusID",2),
						new SqlParameter("@strRemarks","Blocked"),
						new SqlParameter("@LockerNo",dr["nLockerNo"].ToString()),								
						new SqlParameter("@BranchCode",oUser.StrBranchCode()),
						new SqlParameter("@nEmployeeID",oUser.NEmployeeID())
						);

					initLockerMaintenance();
				}
				else
				{
					UI.ShowErrorMessage(this, "You don't have right to block locker.", "Error");
				}
				
			}

		}

		private void btnUnBlock_Click(object sender, System.EventArgs e)
		{
			if (GridViewLocker.RowCount > 0)
			{
				employee.RightsLevel.Id = 40;
				if (employee.HasRight("AB_UNBLOCK_LOCKER"))
				{
					DataRow dr = this.GridViewLocker.GetDataRow(this.GridViewLocker.FocusedRowHandle);
			
					int output;
					output = 0;
			
					SqlHelper.ExecuteNonQuery(connection,"Up_TblLockerStatus",
						new SqlParameter("@retval",output),
						new SqlParameter("@StatusID","0"),
						new SqlParameter("@strRemarks","Unblocked"),
						new SqlParameter("@LockerNo",dr["nLockerNo"].ToString()),								
						new SqlParameter("@BranchCode",oUser.StrBranchCode()),
						new SqlParameter("@nEmployeeID",oUser.NEmployeeID())
						);

					initLockerMaintenance();
				}
				else
				{
					UI.ShowErrorMessage(this, "You don't have right to unblock locker.", "Error");
				}

			}
		}

		private void btnTransfer_Click(object sender, System.EventArgs e)
		{
			if (GridViewLocker.RowCount > 0)
			{
                DataRow dr = GridViewLocker.GetDataRow(this.GridViewLocker.FocusedRowHandle);
				
				ACMSLogic.User oUser = new User();
				myTMForm = new ACMS.ACMSBranch.BranchTransaction.frmTransferLocker(Convert.ToInt32(dr["nLockerNo"]),dr["strMembershipID"].ToString(),oUser.StrBranchCode());
				myTMForm.initData(oUser);
				myTMForm.ShowDialog();
				myTMForm.Dispose();
				initLockerMaintenance();
			}		
		}

		#endregion

		#region common
		private string ConvertToDateTime(object target)
		{
			if (target.ToString() == "" )
				return null;
			else
				return Convert.ToDateTime(target).ToString();
		}

		private int ConvertToInt(object target)
		{
			if (target.ToString() == "" )
				return 0;
			else
				return Convert.ToInt32(target);
		}
		
		private void comboBind(DevExpress.XtraEditors.ImageComboBoxEdit control,string strSQL,string display,string strValue)
		{
		
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox properties = control.Properties;
			properties.Items.BeginUpdate();
			properties.Items.Clear();

			try 
			{
				foreach(DataRow dr in _ds.Tables["Table"].Rows)
				{
					//Initialize each item with the display text, value and image index
					properties.Items.Add( new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr[display].ToString(), dr[strValue].ToString(),-1));
				}
			}
			finally 
			{
				properties.Items.EndUpdate();
			}
			//Select the first item
			control.SelectedIndex = 0;
		}

		private void comboBind(DevExpress.XtraEditors.ImageComboBoxEdit control,string strSQL,string display,string strValue,bool fNum)
		{
		
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox properties = control.Properties;
			properties.Items.BeginUpdate();
			properties.Items.Clear();

			try 
			{
				foreach(DataRow dr in _ds.Tables["Table"].Rows)
				{
					//Initialize each item with the display text, value and image index
					properties.Items.Add( new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr[display].ToString(), dr[strValue],-1));
				}
			}
			finally 
			{
				properties.Items.EndUpdate();
			}
			//Select the first item
			control.SelectedIndex = 0;
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

		private void btnChangeExpiryDate_Click(object sender, System.EventArgs e)
		{
			if (this.GridViewLocker.RowCount > 0)
			{
				employee.RightsLevel.Id = 39;
				if (employee.HasRight("AB_CHANGE_LOCKER_EXPIRYDATE"))
				{
					DataRow dr = this.GridViewLocker.GetDataRow(this.GridViewLocker.FocusedRowHandle);
			
					int output;
					output = 0;

					SqlHelper.ExecuteNonQuery(connection,"Up_TblLockerExpiryDate",
						new SqlParameter("@retval",output),
						new SqlParameter("@dtExpiry",ConvertToDateTime(dr[2])),
						new SqlParameter("@strRemarks",""),
						new SqlParameter("@LockerNo",dr["nLockerNo"].ToString()),								
						new SqlParameter("@BranchCode",oUser.StrBranchCode())
						);

					initLockerMaintenance();
				}
				else
				{
					UI.ShowErrorMessage(this, "You don't have right to change locker expiry date.", "Error");
				}
				
			}

		
		}

		private void GridViewLocker_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
			string strSQL;
			DataSet _ds;
			DataRow dr;
			dr = GridViewLocker.GetDataRow(GridViewLocker.FocusedRowHandle);
			if( dr != null)
			{
				if(dr["Status"].ToString() == "Occupied")
				{
					btnTransfer.Enabled = true;
				}
				else
				{
					btnTransfer.Enabled = false;
				}
				_ds = new DataSet();
				strSQL="select Top 10 A.*,E.strEmployeeName from tblAudit A join tblEmployee E on A.nEmployeeID=E.nEmployeeID where nAuditTypeID=10";
				SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
				gcAudit.DataSource = _ds.Tables["table"];

			}

		}

		private void GridViewLocker_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
		{
			if ( e.Column.Name=="dtExpiry")
			{
				GridViewLocker.RefreshRow(e.RowHandle);

				CurrentLockerRowFocus = GridViewLocker.FocusedRowHandle;
			
				if (this.GridViewLocker.RowCount > 0)
				{
						
					if (employee.HasRight("AB_CHANGE_LOCKER_EXPIRYDATE"))
					{

						int output;
						output = 0;

						SqlHelper.ExecuteNonQuery(connection,"Up_TblLockerExpiryDate",
							new SqlParameter("@retval",output),
							new SqlParameter("@dtExpiry",GridViewLocker.GetRowCellValue(e.RowHandle,"dtExpiry").ToString()),
							new SqlParameter("@strRemarks",GridViewLocker.GetRowCellValue(e.RowHandle,"strRemarks").ToString()),
							new SqlParameter("@LockerNo",GridViewLocker.GetRowCellValue(e.RowHandle,"nLockerNo").ToString()),								
							new SqlParameter("@BranchCode",oUser.StrBranchCode()),
							new SqlParameter("@strMembershipID",GridViewLocker.GetRowCellValue(e.RowHandle,"strMembershipID").ToString()),
							new SqlParameter("@nEmployeeID",oUser.NEmployeeID())
							);
					}
					else
					{
						UI.ShowErrorMessage(this, "You don't have right to change locker expiry date.", "Error");
					}
					LockerRowFocus = this.GridViewLocker.FocusedRowHandle;
					this.GridViewLocker.FocusedRowHandle = CurrentLockerRowFocus;

				}
			}

			if ( e.Column.Name=="strRemarks")
			{

				CurrentLockerRowFocus = GridViewLocker.FocusedRowHandle;
			
				if (this.GridViewLocker.RowCount > 0)
				{
						int output;
						output = 0;

						SqlHelper.ExecuteNonQuery(connection,"Up_TblLockerRemark",
							new SqlParameter("@retval",output),
							new SqlParameter("@strRemarks",GridViewLocker.GetRowCellValue(e.RowHandle,"strRemarks").ToString()),
							new SqlParameter("@LockerNo",GridViewLocker.GetRowCellValue(e.RowHandle,"nLockerNo").ToString()),								
							new SqlParameter("@BranchCode",oUser.StrBranchCode())
							);

					LockerRowFocus = this.GridViewLocker.FocusedRowHandle;
					this.GridViewLocker.FocusedRowHandle = CurrentLockerRowFocus;

				}
			}

		
		}



	}
}
