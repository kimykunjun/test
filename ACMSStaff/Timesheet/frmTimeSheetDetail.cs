using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ACMSDAL;

namespace ACMS.ACMSStaff
{
	/// <summary>
	/// Summary description for frmTimeSheetDetail.
	/// </summary>
	public class frmTimeSheetDetail : System.Windows.Forms.Form
	{
		internal DevExpress.XtraGrid.Columns.GridColumn colTimesheetDetailDate;
		internal DevExpress.XtraGrid.Columns.GridColumn colTimesheetDetailBranch;
		internal DevExpress.XtraGrid.Columns.GridColumn colTimesheetDetailTime;
		internal DevExpress.XtraGrid.Columns.GridColumn colTimesheetDetailRemarks;
		internal DevExpress.XtraGrid.Columns.GridColumn colTimesheetDetailManager;
		private DevExpress.XtraEditors.PanelControl panelControl1;
		private DevExpress.XtraEditors.SimpleButton sbtnClose;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
		private DevExpress.XtraEditors.PanelControl pnTop;
		internal DevExpress.XtraGrid.GridControl gridctrTimeCard;
		internal DevExpress.XtraGrid.Views.Grid.GridView gvTimeCard;
		internal DevExpress.XtraGrid.GridControl gridctrRoster;
		internal DevExpress.XtraGrid.Views.Grid.GridView gvRoster;
		internal System.Windows.Forms.Label lblmnuTimesheet;
		private DevExpress.XtraEditors.PanelControl pnMiddle;
		internal System.Windows.Forms.Label label1;
		internal DevExpress.XtraGrid.Columns.GridColumn colRosterDate;
		private DevExpress.XtraGrid.Columns.GridColumn colRosterStartTime;
		private DevExpress.XtraGrid.Columns.GridColumn colRosterEndTime;
		private DevExpress.XtraGrid.Columns.GridColumn colRosterBranch;
		private DevExpress.XtraGrid.Columns.GridColumn colRosterRemark;
		private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
		private DevExpress.XtraEditors.SimpleButton btnOk;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmTimeSheetDetail(DataTable timesheetTable, DataTable timeCardTable)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			gridctrRoster.DataSource = timesheetTable;
			gridctrTimeCard.DataSource = timeCardTable;
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
			this.gridctrTimeCard = new DevExpress.XtraGrid.GridControl();
			this.gvTimeCard = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colTimesheetDetailDate = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colTimesheetDetailBranch = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colTimesheetDetailTime = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colTimesheetDetailRemarks = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colTimesheetDetailManager = new DevExpress.XtraGrid.Columns.GridColumn();
			this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
			this.sbtnClose = new DevExpress.XtraEditors.SimpleButton();
			this.gridctrRoster = new DevExpress.XtraGrid.GridControl();
			this.gvRoster = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colRosterDate = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colRosterStartTime = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colRosterEndTime = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colRosterBranch = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colRosterRemark = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.pnTop = new DevExpress.XtraEditors.PanelControl();
			this.lblmnuTimesheet = new System.Windows.Forms.Label();
			this.pnMiddle = new DevExpress.XtraEditors.PanelControl();
			this.label1 = new System.Windows.Forms.Label();
			this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
			this.btnOk = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.gridctrTimeCard)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvTimeCard)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
			this.panelControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridctrRoster)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvRoster)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pnTop)).BeginInit();
			this.pnTop.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pnMiddle)).BeginInit();
			this.pnMiddle.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
			this.SuspendLayout();
			// 
			// gridctrTimeCard
			// 
			this.gridctrTimeCard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			// 
			// gridctrTimeCard.EmbeddedNavigator
			// 
			this.gridctrTimeCard.EmbeddedNavigator.Buttons.Append.Visible = false;
			this.gridctrTimeCard.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
			this.gridctrTimeCard.EmbeddedNavigator.Buttons.Edit.Visible = false;
			this.gridctrTimeCard.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
			this.gridctrTimeCard.EmbeddedNavigator.Buttons.Remove.Visible = false;
			this.gridctrTimeCard.EmbeddedNavigator.Name = "";
			this.gridctrTimeCard.Location = new System.Drawing.Point(0, 28);
			this.gridctrTimeCard.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.gridctrTimeCard.LookAndFeel.UseDefaultLookAndFeel = false;
			this.gridctrTimeCard.LookAndFeel.UseWindowsXPTheme = false;
			this.gridctrTimeCard.MainView = this.gvTimeCard;
			this.gridctrTimeCard.Name = "gridctrTimeCard";
			this.gridctrTimeCard.Size = new System.Drawing.Size(740, 290);
			this.gridctrTimeCard.TabIndex = 1;
			this.gridctrTimeCard.UseEmbeddedNavigator = true;
			this.gridctrTimeCard.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										   this.gvTimeCard});
			// 
			// gvTimeCard
			// 
			this.gvTimeCard.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							  this.colTimesheetDetailDate,
																							  this.colTimesheetDetailBranch,
																							  this.colTimesheetDetailTime,
																							  this.colTimesheetDetailRemarks,
																							  this.colTimesheetDetailManager});
			this.gvTimeCard.GridControl = this.gridctrTimeCard;
			this.gvTimeCard.Name = "gvTimeCard";
			this.gvTimeCard.OptionsBehavior.AllowIncrementalSearch = true;
			this.gvTimeCard.OptionsBehavior.Editable = false;
			this.gvTimeCard.OptionsCustomization.AllowFilter = false;
			this.gvTimeCard.OptionsView.ShowGroupPanel = false;
			this.gvTimeCard.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
																									   new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colTimesheetDetailDate, DevExpress.Data.ColumnSortOrder.Ascending)});
			// 
			// colTimesheetDetailDate
			// 
			this.colTimesheetDetailDate.Caption = "Date";
			this.colTimesheetDetailDate.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.colTimesheetDetailDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.colTimesheetDetailDate.FieldName = "dtDate";
			this.colTimesheetDetailDate.Name = "colTimesheetDetailDate";
			this.colTimesheetDetailDate.Visible = true;
			this.colTimesheetDetailDate.VisibleIndex = 0;
			this.colTimesheetDetailDate.Width = 149;
			// 
			// colTimesheetDetailBranch
			// 
			this.colTimesheetDetailBranch.Caption = "Branch";
			this.colTimesheetDetailBranch.FieldName = "strBranchCode";
			this.colTimesheetDetailBranch.Name = "colTimesheetDetailBranch";
			this.colTimesheetDetailBranch.Visible = true;
			this.colTimesheetDetailBranch.VisibleIndex = 1;
			this.colTimesheetDetailBranch.Width = 115;
			// 
			// colTimesheetDetailTime
			// 
			this.colTimesheetDetailTime.Caption = "Time";
			this.colTimesheetDetailTime.DisplayFormat.FormatString = "T";
			this.colTimesheetDetailTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.colTimesheetDetailTime.FieldName = "dtTime";
			this.colTimesheetDetailTime.Name = "colTimesheetDetailTime";
			this.colTimesheetDetailTime.Visible = true;
			this.colTimesheetDetailTime.VisibleIndex = 2;
			this.colTimesheetDetailTime.Width = 91;
			// 
			// colTimesheetDetailRemarks
			// 
			this.colTimesheetDetailRemarks.Caption = "Remarks";
			this.colTimesheetDetailRemarks.FieldName = "strRemarks";
			this.colTimesheetDetailRemarks.Name = "colTimesheetDetailRemarks";
			this.colTimesheetDetailRemarks.Visible = true;
			this.colTimesheetDetailRemarks.VisibleIndex = 3;
			this.colTimesheetDetailRemarks.Width = 395;
			// 
			// colTimesheetDetailManager
			// 
			this.colTimesheetDetailManager.Caption = "Manager";
			this.colTimesheetDetailManager.FieldName = "strEmployeeName";
			this.colTimesheetDetailManager.Name = "colTimesheetDetailManager";
			this.colTimesheetDetailManager.Visible = true;
			this.colTimesheetDetailManager.VisibleIndex = 4;
			this.colTimesheetDetailManager.Width = 217;
			// 
			// panelControl1
			// 
			this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.panelControl1.Controls.Add(this.btnOk);
			this.panelControl1.Controls.Add(this.sbtnClose);
			this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelControl1.Location = new System.Drawing.Point(0, 452);
			this.panelControl1.Name = "panelControl1";
			this.panelControl1.Size = new System.Drawing.Size(740, 30);
			this.panelControl1.TabIndex = 2;
			this.panelControl1.Text = "panelControl1";
			// 
			// sbtnClose
			// 
			this.sbtnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.sbtnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.sbtnClose.Location = new System.Drawing.Point(660, 4);
			this.sbtnClose.Name = "sbtnClose";
			this.sbtnClose.TabIndex = 0;
			this.sbtnClose.Text = "&Close";
			this.sbtnClose.Click += new System.EventHandler(this.sbtnClose_Click);
			// 
			// gridctrRoster
			// 
			this.gridctrRoster.Dock = System.Windows.Forms.DockStyle.Bottom;
			// 
			// gridctrRoster.EmbeddedNavigator
			// 
			this.gridctrRoster.EmbeddedNavigator.Name = "";
			this.gridctrRoster.Location = new System.Drawing.Point(0, 28);
			this.gridctrRoster.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.gridctrRoster.LookAndFeel.UseDefaultLookAndFeel = false;
			this.gridctrRoster.LookAndFeel.UseWindowsXPTheme = false;
			this.gridctrRoster.MainView = this.gvRoster;
			this.gridctrRoster.Name = "gridctrRoster";
			this.gridctrRoster.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																												   this.repositoryItemCheckEdit2,
																												   this.repositoryItemTextEdit1});
			this.gridctrRoster.Size = new System.Drawing.Size(740, 106);
			this.gridctrRoster.TabIndex = 3;
			this.gridctrRoster.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										 this.gvRoster});
			// 
			// gvRoster
			// 
			this.gvRoster.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							this.colRosterDate,
																							this.colRosterStartTime,
																							this.colRosterEndTime,
																							this.colRosterBranch,
																							this.colRosterRemark});
			this.gvRoster.GridControl = this.gridctrRoster;
			this.gvRoster.Name = "gvRoster";
			this.gvRoster.OptionsBehavior.AllowIncrementalSearch = true;
			this.gvRoster.OptionsCustomization.AllowFilter = false;
			this.gvRoster.OptionsView.ShowGroupPanel = false;
			this.gvRoster.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
																									 new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colRosterStartTime, DevExpress.Data.ColumnSortOrder.Ascending)});
			// 
			// colRosterDate
			// 
			this.colRosterDate.Caption = "Date";
			this.colRosterDate.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.colRosterDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.colRosterDate.FieldName = "dtDate";
			this.colRosterDate.Name = "colRosterDate";
			this.colRosterDate.OptionsColumn.AllowEdit = false;
			this.colRosterDate.Visible = true;
			this.colRosterDate.VisibleIndex = 0;
			this.colRosterDate.Width = 128;
			// 
			// colRosterStartTime
			// 
			this.colRosterStartTime.Caption = "Start Time";
			this.colRosterStartTime.DisplayFormat.FormatString = "T";
			this.colRosterStartTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.colRosterStartTime.FieldName = "dtStartTime";
			this.colRosterStartTime.Name = "colRosterStartTime";
			this.colRosterStartTime.OptionsColumn.AllowEdit = false;
			this.colRosterStartTime.Visible = true;
			this.colRosterStartTime.VisibleIndex = 1;
			// 
			// colRosterEndTime
			// 
			this.colRosterEndTime.Caption = "End Time";
			this.colRosterEndTime.DisplayFormat.FormatString = "T";
			this.colRosterEndTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.colRosterEndTime.FieldName = "dtEndTime";
			this.colRosterEndTime.Name = "colRosterEndTime";
			this.colRosterEndTime.OptionsColumn.AllowEdit = false;
			this.colRosterEndTime.Visible = true;
			this.colRosterEndTime.VisibleIndex = 2;
			// 
			// colRosterBranch
			// 
			this.colRosterBranch.Caption = "Branch";
			this.colRosterBranch.FieldName = "strBranchCode";
			this.colRosterBranch.Name = "colRosterBranch";
			this.colRosterBranch.OptionsColumn.AllowEdit = false;
			this.colRosterBranch.Visible = true;
			this.colRosterBranch.VisibleIndex = 3;
			// 
			// colRosterRemark
			// 
			this.colRosterRemark.Caption = "Remark";
			this.colRosterRemark.FieldName = "strRemarks";
			this.colRosterRemark.Name = "colRosterRemark";
			this.colRosterRemark.Visible = true;
			this.colRosterRemark.VisibleIndex = 4;
			// 
			// repositoryItemCheckEdit2
			// 
			this.repositoryItemCheckEdit2.AutoHeight = false;
			this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
			this.repositoryItemCheckEdit2.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
			// 
			// pnTop
			// 
			this.pnTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.pnTop.Controls.Add(this.lblmnuTimesheet);
			this.pnTop.Controls.Add(this.gridctrRoster);
			this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnTop.Location = new System.Drawing.Point(0, 0);
			this.pnTop.Name = "pnTop";
			this.pnTop.Size = new System.Drawing.Size(740, 134);
			this.pnTop.TabIndex = 4;
			this.pnTop.Text = "panelControl2";
			// 
			// lblmnuTimesheet
			// 
			this.lblmnuTimesheet.AutoSize = true;
			this.lblmnuTimesheet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblmnuTimesheet.Location = new System.Drawing.Point(6, 6);
			this.lblmnuTimesheet.Name = "lblmnuTimesheet";
			this.lblmnuTimesheet.Size = new System.Drawing.Size(46, 18);
			this.lblmnuTimesheet.TabIndex = 4;
			this.lblmnuTimesheet.Text = "Roster";
			// 
			// pnMiddle
			// 
			this.pnMiddle.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.pnMiddle.Controls.Add(this.label1);
			this.pnMiddle.Controls.Add(this.gridctrTimeCard);
			this.pnMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnMiddle.Location = new System.Drawing.Point(0, 134);
			this.pnMiddle.Name = "pnMiddle";
			this.pnMiddle.Size = new System.Drawing.Size(740, 318);
			this.pnMiddle.TabIndex = 5;
			this.pnMiddle.Text = "panelControl2";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(4, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(70, 18);
			this.label1.TabIndex = 5;
			this.label1.Text = "Time Card";
			// 
			// repositoryItemTextEdit1
			// 
			this.repositoryItemTextEdit1.AutoHeight = false;
			this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnOk.Location = new System.Drawing.Point(574, 4);
			this.btnOk.Name = "btnOk";
			this.btnOk.TabIndex = 1;
			this.btnOk.Text = "Save";
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// frmTimeSheetDetail
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.sbtnClose;
			this.ClientSize = new System.Drawing.Size(740, 482);
			this.Controls.Add(this.pnMiddle);
			this.Controls.Add(this.pnTop);
			this.Controls.Add(this.panelControl1);
			this.Name = "frmTimeSheetDetail";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Timesheet Detail";
			((System.ComponentModel.ISupportInitialize)(this.gridctrTimeCard)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvTimeCard)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
			this.panelControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridctrRoster)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvRoster)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pnTop)).EndInit();
			this.pnTop.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pnMiddle)).EndInit();
			this.pnMiddle.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void sbtnClose_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private void btnOk_Click(object sender, System.EventArgs e)
		{
			DataRow row = gvRoster.GetDataRow(gvRoster.FocusedRowHandle);
			ACMSDAL.TblRoster myRoster = new TblRoster();
			myRoster.StrRemarks = row["strRemarks"].ToString();
			myRoster.NRosterID = System.Convert.ToInt32(row["nRosterID"]);
			myRoster.Update2();
		}
	}
}
