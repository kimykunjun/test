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
	/// Summary description for FormSearchMember.
	/// </summary>
	public class frmSearchMember : System.Windows.Forms.Form
	{
		private string connectionString;
		private SqlConnection connection;

		private string strMembershipID;
		private DevExpress.XtraGrid.GridControl gridControl1;
		private DevExpress.XtraEditors.SimpleButton sbtnOK;
		private DevExpress.XtraEditors.SimpleButton sbtnCancel;
		private DevExpress.XtraGrid.Columns.GridColumn colstrMembershipID;
		private DevExpress.XtraGrid.Columns.GridColumn colstrBranchCode;
		private DevExpress.XtraGrid.Columns.GridColumn colnMembershipNo;
		private DevExpress.XtraGrid.Columns.GridColumn colstrMemberName;
		private DevExpress.XtraGrid.Columns.GridColumn colstrCardName;
		private DevExpress.XtraGrid.Columns.GridColumn colstrNRICFIN;
		private DevExpress.XtraGrid.Columns.GridColumn colfSingaporean;
		private DevExpress.XtraGrid.Columns.GridColumn colfMember;
		private DevExpress.XtraGrid.Columns.GridColumn colfAirCrew;
		private DevExpress.XtraGrid.Columns.GridColumn coldtDOB;
		private DevExpress.XtraGrid.Columns.GridColumn colstrAddress1;
		private DevExpress.XtraGrid.Columns.GridColumn colstrAddress2;
		private DevExpress.XtraGrid.Columns.GridColumn colstrPostalCode;
		private DevExpress.XtraGrid.Columns.GridColumn colstrHomeNo;
		private DevExpress.XtraGrid.Columns.GridColumn colstrOfficeNo;
		private DevExpress.XtraGrid.Columns.GridColumn colstrMobileNo;
		private DevExpress.XtraGrid.Columns.GridColumn colstrPagerNo;
		private DevExpress.XtraGrid.Columns.GridColumn colfSMS;
		private DevExpress.XtraGrid.Columns.GridColumn colfEmail;
		private DevExpress.XtraGrid.Columns.GridColumn colfPostalMail;
		private DevExpress.XtraGrid.Columns.GridColumn colstrEmail;
		private DevExpress.XtraGrid.Columns.GridColumn colstrAltEmail;
		private DevExpress.XtraGrid.Columns.GridColumn colnMediaSourceID;
		private DevExpress.XtraGrid.Columns.GridColumn colstrMediaSource;
		private DevExpress.XtraGrid.Columns.GridColumn colstrCompany;
		private DevExpress.XtraGrid.Columns.GridColumn colstrOccupation;
		private DevExpress.XtraGrid.Columns.GridColumn colnLoyaltyStatusID;
		private DevExpress.XtraGrid.Columns.GridColumn colstrRemarks;
		private DevExpress.XtraGrid.Columns.GridColumn coldtSignupDate;
		private DevExpress.XtraGrid.Columns.GridColumn colstrCreditCardNo;
		private DevExpress.XtraGrid.Columns.GridColumn colstrIntroducerMembershipID;
		private DevExpress.XtraGrid.Columns.GridColumn colnSignupID;
		private DevExpress.XtraGrid.Columns.GridColumn colnCardStatusID;
		private DevExpress.XtraGrid.Columns.GridColumn colstrCardBranchCode;
		private DevExpress.XtraGrid.Columns.GridColumn colfLockerDeposit;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit3;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit4;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit5;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit6;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit7;
		private DevExpress.XtraEditors.PanelControl panelControl1;
		private DevExpress.XtraEditors.PanelControl panelControl2;
		private DevExpress.XtraEditors.TextEdit txtSearchKey;
		private DevExpress.XtraEditors.SimpleButton sbtnSearch;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraEditors.LookUpEdit luedtBranchCode;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public string StrMemberShipID
		{
			get {return strMembershipID;}
		}

		public frmSearchMember(string searchKey,object terminalBranchCode )
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

			new ACMS.XtraUtils.LookupEditBuilder.BranchCodeLookupEditBuilder2(luedtBranchCode.Properties);
			DataTable branchTable = luedtBranchCode.Properties.DataSource as DataTable;
			DataRow rNew = branchTable.NewRow();
			rNew.BeginEdit();
			rNew["strBranchCode"] = DBNull.Value;
			rNew["strBranchName"] = "<<No Filter>>";
			rNew.EndEdit();
			branchTable.Rows.Add(rNew);
			luedtBranchCode.EditValue = terminalBranchCode;
			
			strMembershipID = string.Empty;
			txtSearchKey.Text = searchKey;
			LoadMember();
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
			this.gridControl1 = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colstrMembershipID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colstrBranchCode = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colnMembershipNo = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colstrMemberName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colstrCardName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colstrNRICFIN = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colfSingaporean = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.colfMember = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.colfAirCrew = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemCheckEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.coldtDOB = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colstrAddress1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colstrAddress2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colstrPostalCode = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colstrHomeNo = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colstrOfficeNo = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colstrMobileNo = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colstrPagerNo = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colfSMS = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemCheckEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.colfEmail = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemCheckEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.colfPostalMail = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemCheckEdit6 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.colstrEmail = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colstrAltEmail = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colnMediaSourceID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colstrMediaSource = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colstrCompany = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colstrOccupation = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colnLoyaltyStatusID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colstrRemarks = new DevExpress.XtraGrid.Columns.GridColumn();
			this.coldtSignupDate = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colstrCreditCardNo = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colstrIntroducerMembershipID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colfLockerDeposit = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemCheckEdit7 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.colnSignupID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colnCardStatusID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colstrCardBranchCode = new DevExpress.XtraGrid.Columns.GridColumn();
			this.sbtnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnOK = new DevExpress.XtraEditors.SimpleButton();
			this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
			this.label2 = new System.Windows.Forms.Label();
			this.luedtBranchCode = new DevExpress.XtraEditors.LookUpEdit();
			this.label1 = new System.Windows.Forms.Label();
			this.sbtnSearch = new DevExpress.XtraEditors.SimpleButton();
			this.txtSearchKey = new DevExpress.XtraEditors.TextEdit();
			this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
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
			((System.ComponentModel.ISupportInitialize)(this.luedtBranchCode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtSearchKey.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
			this.panelControl2.SuspendLayout();
			this.SuspendLayout();
			// 
			// gridControl1
			// 
			this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// gridControl1.EmbeddedNavigator
			// 
			this.gridControl1.EmbeddedNavigator.Name = "";
			this.gridControl1.Location = new System.Drawing.Point(0, 46);
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
			this.gridControl1.Size = new System.Drawing.Size(938, 460);
			this.gridControl1.TabIndex = 1;
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
																							 this.colstrMembershipID,
																							 this.colstrBranchCode,
																							 this.colnMembershipNo,
																							 this.colstrMemberName,
																							 this.colstrCardName,
																							 this.colstrNRICFIN,
																							 this.colfSingaporean,
																							 this.colfMember,
																							 this.colfAirCrew,
																							 this.coldtDOB,
																							 this.colstrAddress1,
																							 this.colstrAddress2,
																							 this.colstrPostalCode,
																							 this.colstrHomeNo,
																							 this.colstrOfficeNo,
																							 this.colstrMobileNo,
																							 this.colstrPagerNo,
																							 this.colfSMS,
																							 this.colfEmail,
																							 this.colfPostalMail,
																							 this.colstrEmail,
																							 this.colstrAltEmail,
																							 this.colnMediaSourceID,
																							 this.colstrMediaSource,
																							 this.colstrCompany,
																							 this.colstrOccupation,
																							 this.colnLoyaltyStatusID,
																							 this.colstrRemarks,
																							 this.coldtSignupDate,
																							 this.colstrCreditCardNo,
																							 this.colstrIntroducerMembershipID,
																							 this.colfLockerDeposit,
																							 this.colnSignupID,
																							 this.colnCardStatusID,
																							 this.colstrCardBranchCode});
			this.gridView1.GridControl = this.gridControl1;
			this.gridView1.Name = "gridView1";
			this.gridView1.OptionsBehavior.AllowIncrementalSearch = true;
			this.gridView1.OptionsBehavior.Editable = false;
			this.gridView1.OptionsCustomization.AllowFilter = false;
			this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
			this.gridView1.OptionsView.EnableAppearanceOddRow = true;
			this.gridView1.OptionsView.ShowGroupPanel = false;
			this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
			// 
			// colstrMembershipID
			// 
			this.colstrMembershipID.Caption = "Membership ID";
			this.colstrMembershipID.FieldName = "strMembershipID";
			this.colstrMembershipID.Name = "colstrMembershipID";
			this.colstrMembershipID.Visible = true;
			this.colstrMembershipID.VisibleIndex = 0;
			this.colstrMembershipID.Width = 83;
			// 
			// colstrBranchCode
			// 
			this.colstrBranchCode.Caption = "Branch Code";
			this.colstrBranchCode.FieldName = "strBranchCode";
			this.colstrBranchCode.Name = "colstrBranchCode";
			this.colstrBranchCode.Visible = true;
			this.colstrBranchCode.VisibleIndex = 1;
			this.colstrBranchCode.Width = 73;
			// 
			// colnMembershipNo
			// 
			this.colnMembershipNo.Caption = "Membership No";
			this.colnMembershipNo.FieldName = "nMembershipNo";
			this.colnMembershipNo.Name = "colnMembershipNo";
			// 
			// colstrMemberName
			// 
			this.colstrMemberName.Caption = "Member Name";
			this.colstrMemberName.FieldName = "strMemberName";
			this.colstrMemberName.Name = "colstrMemberName";
			this.colstrMemberName.Visible = true;
			this.colstrMemberName.VisibleIndex = 2;
			this.colstrMemberName.Width = 89;
			// 
			// colstrCardName
			// 
			this.colstrCardName.Caption = "Card Name";
			this.colstrCardName.FieldName = "strCardName";
			this.colstrCardName.Name = "colstrCardName";
			this.colstrCardName.Visible = true;
			this.colstrCardName.VisibleIndex = 3;
			// 
			// colstrNRICFIN
			// 
			this.colstrNRICFIN.Caption = "NRIC/FIN";
			this.colstrNRICFIN.FieldName = "strNRICFIN";
			this.colstrNRICFIN.Name = "colstrNRICFIN";
			this.colstrNRICFIN.Visible = true;
			this.colstrNRICFIN.VisibleIndex = 4;
			this.colstrNRICFIN.Width = 69;
			// 
			// colfSingaporean
			// 
			this.colfSingaporean.Caption = "Singaporean?";
			this.colfSingaporean.ColumnEdit = this.repositoryItemCheckEdit1;
			this.colfSingaporean.FieldName = "fSingaporean";
			this.colfSingaporean.Name = "colfSingaporean";
			// 
			// repositoryItemCheckEdit1
			// 
			this.repositoryItemCheckEdit1.AutoHeight = false;
			this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
			this.repositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
			// 
			// colfMember
			// 
			this.colfMember.Caption = "Member?";
			this.colfMember.ColumnEdit = this.repositoryItemCheckEdit2;
			this.colfMember.FieldName = "fMember";
			this.colfMember.Name = "colfMember";
			this.colfMember.Visible = true;
			this.colfMember.VisibleIndex = 5;
			this.colfMember.Width = 53;
			// 
			// repositoryItemCheckEdit2
			// 
			this.repositoryItemCheckEdit2.AutoHeight = false;
			this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
			this.repositoryItemCheckEdit2.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
			// 
			// colfAirCrew
			// 
			this.colfAirCrew.Caption = "Air Crew?";
			this.colfAirCrew.ColumnEdit = this.repositoryItemCheckEdit3;
			this.colfAirCrew.FieldName = "fAirCrew";
			this.colfAirCrew.Name = "colfAirCrew";
			this.colfAirCrew.Visible = true;
			this.colfAirCrew.VisibleIndex = 6;
			this.colfAirCrew.Width = 56;
			// 
			// repositoryItemCheckEdit3
			// 
			this.repositoryItemCheckEdit3.AutoHeight = false;
			this.repositoryItemCheckEdit3.Name = "repositoryItemCheckEdit3";
			this.repositoryItemCheckEdit3.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
			// 
			// coldtDOB
			// 
			this.coldtDOB.Caption = "DOB";
			this.coldtDOB.FieldName = "dtDOB";
			this.coldtDOB.Name = "coldtDOB";
			this.coldtDOB.Visible = true;
			this.coldtDOB.VisibleIndex = 7;
			this.coldtDOB.Width = 74;
			// 
			// colstrAddress1
			// 
			this.colstrAddress1.Caption = "Address1";
			this.colstrAddress1.FieldName = "strAddress1";
			this.colstrAddress1.Name = "colstrAddress1";
			// 
			// colstrAddress2
			// 
			this.colstrAddress2.Caption = "Address2";
			this.colstrAddress2.FieldName = "strAddress2";
			this.colstrAddress2.Name = "colstrAddress2";
			// 
			// colstrPostalCode
			// 
			this.colstrPostalCode.Caption = "Postal Code";
			this.colstrPostalCode.FieldName = "strPostalCode";
			this.colstrPostalCode.Name = "colstrPostalCode";
			// 
			// colstrHomeNo
			// 
			this.colstrHomeNo.Caption = "Home No";
			this.colstrHomeNo.FieldName = "strHomeNo";
			this.colstrHomeNo.Name = "colstrHomeNo";
			this.colstrHomeNo.Visible = true;
			this.colstrHomeNo.VisibleIndex = 8;
			this.colstrHomeNo.Width = 74;
			// 
			// colstrOfficeNo
			// 
			this.colstrOfficeNo.Caption = "Office No";
			this.colstrOfficeNo.FieldName = "strOfficeNo";
			this.colstrOfficeNo.Name = "colstrOfficeNo";
			// 
			// colstrMobileNo
			// 
			this.colstrMobileNo.Caption = "Mobile No";
			this.colstrMobileNo.FieldName = "strMobileNo";
			this.colstrMobileNo.Name = "colstrMobileNo";
			this.colstrMobileNo.Visible = true;
			this.colstrMobileNo.VisibleIndex = 9;
			this.colstrMobileNo.Width = 74;
			// 
			// colstrPagerNo
			// 
			this.colstrPagerNo.Caption = "Pager No";
			this.colstrPagerNo.FieldName = "strPagerNo";
			this.colstrPagerNo.Name = "colstrPagerNo";
			// 
			// colfSMS
			// 
			this.colfSMS.Caption = "SMS?";
			this.colfSMS.ColumnEdit = this.repositoryItemCheckEdit4;
			this.colfSMS.FieldName = "fSMS";
			this.colfSMS.Name = "colfSMS";
			// 
			// repositoryItemCheckEdit4
			// 
			this.repositoryItemCheckEdit4.AutoHeight = false;
			this.repositoryItemCheckEdit4.Name = "repositoryItemCheckEdit4";
			this.repositoryItemCheckEdit4.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
			// 
			// colfEmail
			// 
			this.colfEmail.Caption = "Email?";
			this.colfEmail.ColumnEdit = this.repositoryItemCheckEdit5;
			this.colfEmail.FieldName = "fEmail";
			this.colfEmail.Name = "colfEmail";
			// 
			// repositoryItemCheckEdit5
			// 
			this.repositoryItemCheckEdit5.AutoHeight = false;
			this.repositoryItemCheckEdit5.Name = "repositoryItemCheckEdit5";
			this.repositoryItemCheckEdit5.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
			// 
			// colfPostalMail
			// 
			this.colfPostalMail.Caption = "Postal Mail?";
			this.colfPostalMail.ColumnEdit = this.repositoryItemCheckEdit6;
			this.colfPostalMail.FieldName = "fPostalMail";
			this.colfPostalMail.Name = "colfPostalMail";
			// 
			// repositoryItemCheckEdit6
			// 
			this.repositoryItemCheckEdit6.AutoHeight = false;
			this.repositoryItemCheckEdit6.Name = "repositoryItemCheckEdit6";
			this.repositoryItemCheckEdit6.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
			// 
			// colstrEmail
			// 
			this.colstrEmail.Caption = "Email";
			this.colstrEmail.FieldName = "strEmail";
			this.colstrEmail.Name = "colstrEmail";
			this.colstrEmail.Visible = true;
			this.colstrEmail.VisibleIndex = 10;
			this.colstrEmail.Width = 109;
			// 
			// colstrAltEmail
			// 
			this.colstrAltEmail.Caption = "Alt Email";
			this.colstrAltEmail.FieldName = "strAltEmail";
			this.colstrAltEmail.Name = "colstrAltEmail";
			// 
			// colnMediaSourceID
			// 
			this.colnMediaSourceID.Caption = "Media Source ID";
			this.colnMediaSourceID.FieldName = "nMediaSourceID";
			this.colnMediaSourceID.Name = "colnMediaSourceID";
			// 
			// colstrMediaSource
			// 
			this.colstrMediaSource.Caption = "Media Source";
			this.colstrMediaSource.FieldName = "strMediaSource";
			this.colstrMediaSource.Name = "colstrMediaSource";
			// 
			// colstrCompany
			// 
			this.colstrCompany.Caption = "Company";
			this.colstrCompany.FieldName = "strCompany";
			this.colstrCompany.Name = "colstrCompany";
			// 
			// colstrOccupation
			// 
			this.colstrOccupation.Caption = "Occupation";
			this.colstrOccupation.FieldName = "strOccupation";
			this.colstrOccupation.Name = "colstrOccupation";
			// 
			// colnLoyaltyStatusID
			// 
			this.colnLoyaltyStatusID.Caption = "Loyalty Status ID";
			this.colnLoyaltyStatusID.FieldName = "nLoyaltyStatusID";
			this.colnLoyaltyStatusID.Name = "colnLoyaltyStatusID";
			// 
			// colstrRemarks
			// 
			this.colstrRemarks.Caption = "Remarks";
			this.colstrRemarks.FieldName = "strRemarks";
			this.colstrRemarks.Name = "colstrRemarks";
			// 
			// coldtSignupDate
			// 
			this.coldtSignupDate.Caption = "Signup Date";
			this.coldtSignupDate.FieldName = "dtSignupDate";
			this.coldtSignupDate.Name = "coldtSignupDate";
			// 
			// colstrCreditCardNo
			// 
			this.colstrCreditCardNo.Caption = "Credit Card No";
			this.colstrCreditCardNo.FieldName = "strCreditCardNo";
			this.colstrCreditCardNo.Name = "colstrCreditCardNo";
			// 
			// colstrIntroducerMembershipID
			// 
			this.colstrIntroducerMembershipID.Caption = "Introducer Membership ID";
			this.colstrIntroducerMembershipID.FieldName = "strIntroducerMembershipID";
			this.colstrIntroducerMembershipID.Name = "colstrIntroducerMembershipID";
			// 
			// colfLockerDeposit
			// 
			this.colfLockerDeposit.Caption = "Locker Deposit";
			this.colfLockerDeposit.ColumnEdit = this.repositoryItemCheckEdit7;
			this.colfLockerDeposit.FieldName = "fLockerDeposit";
			this.colfLockerDeposit.Name = "colfLockerDeposit";
			// 
			// repositoryItemCheckEdit7
			// 
			this.repositoryItemCheckEdit7.AutoHeight = false;
			this.repositoryItemCheckEdit7.Name = "repositoryItemCheckEdit7";
			this.repositoryItemCheckEdit7.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
			// 
			// colnSignupID
			// 
			this.colnSignupID.Caption = "Signup ID";
			this.colnSignupID.FieldName = "nSignupID";
			this.colnSignupID.Name = "colnSignupID";
			// 
			// colnCardStatusID
			// 
			this.colnCardStatusID.Caption = "Card Status ID";
			this.colnCardStatusID.FieldName = "nCardStatusID";
			this.colnCardStatusID.Name = "colnCardStatusID";
			// 
			// colstrCardBranchCode
			// 
			this.colstrCardBranchCode.Caption = "Card Branch Code";
			this.colstrCardBranchCode.FieldName = "strCardBranchCode";
			this.colstrCardBranchCode.Name = "colstrCardBranchCode";
			// 
			// sbtnCancel
			// 
			this.sbtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.sbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.sbtnCancel.Location = new System.Drawing.Point(856, 8);
			this.sbtnCancel.Name = "sbtnCancel";
			this.sbtnCancel.TabIndex = 1;
			this.sbtnCancel.Text = "Cancel";
			this.sbtnCancel.Click += new System.EventHandler(this.sbtnCancel_Click);
			// 
			// sbtnOK
			// 
			this.sbtnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.sbtnOK.Location = new System.Drawing.Point(772, 8);
			this.sbtnOK.Name = "sbtnOK";
			this.sbtnOK.TabIndex = 0;
			this.sbtnOK.Text = "OK";
			this.sbtnOK.Click += new System.EventHandler(this.sbtnOK_Click);
			// 
			// panelControl1
			// 
			this.panelControl1.Controls.Add(this.label2);
			this.panelControl1.Controls.Add(this.luedtBranchCode);
			this.panelControl1.Controls.Add(this.label1);
			this.panelControl1.Controls.Add(this.sbtnSearch);
			this.panelControl1.Controls.Add(this.txtSearchKey);
			this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelControl1.Location = new System.Drawing.Point(0, 0);
			this.panelControl1.Name = "panelControl1";
			this.panelControl1.Size = new System.Drawing.Size(938, 46);
			this.panelControl1.TabIndex = 0;
			this.panelControl1.Text = "panelControl1";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(26, 18);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 18);
			this.label2.TabIndex = 26;
			this.label2.Text = "Name";
			// 
			// luedtBranchCode
			// 
			this.luedtBranchCode.Location = new System.Drawing.Point(296, 16);
			this.luedtBranchCode.Name = "luedtBranchCode";
			// 
			// luedtBranchCode.Properties
			// 
			this.luedtBranchCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.luedtBranchCode.Size = new System.Drawing.Size(126, 20);
			this.luedtBranchCode.TabIndex = 24;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(238, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 18);
			this.label1.TabIndex = 25;
			this.label1.Text = "Branch:";
			// 
			// sbtnSearch
			// 
			this.sbtnSearch.Location = new System.Drawing.Point(438, 16);
			this.sbtnSearch.Name = "sbtnSearch";
			this.sbtnSearch.TabIndex = 1;
			this.sbtnSearch.Text = "Search";
			this.sbtnSearch.Click += new System.EventHandler(this.sbtnSearch_Click);
			// 
			// txtSearchKey
			// 
			this.txtSearchKey.EditValue = "";
			this.txtSearchKey.Location = new System.Drawing.Point(82, 18);
			this.txtSearchKey.Name = "txtSearchKey";
			this.txtSearchKey.Size = new System.Drawing.Size(146, 20);
			this.txtSearchKey.TabIndex = 0;
			// 
			// panelControl2
			// 
			this.panelControl2.Controls.Add(this.sbtnCancel);
			this.panelControl2.Controls.Add(this.sbtnOK);
			this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelControl2.Location = new System.Drawing.Point(0, 506);
			this.panelControl2.Name = "panelControl2";
			this.panelControl2.Size = new System.Drawing.Size(938, 38);
			this.panelControl2.TabIndex = 0;
			this.panelControl2.Text = "panelControl2";
			// 
			// frmSearchMember
			// 
			this.AcceptButton = this.sbtnSearch;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.sbtnCancel;
			this.ClientSize = new System.Drawing.Size(938, 544);
			this.Controls.Add(this.gridControl1);
			this.Controls.Add(this.panelControl2);
			this.Controls.Add(this.panelControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "frmSearchMember";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Search Member";
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
			((System.ComponentModel.ISupportInitialize)(this.luedtBranchCode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtSearchKey.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
			this.panelControl2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void sbtnCancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void sbtnOK_Click(object sender, System.EventArgs e)
		{
			if (gridView1.FocusedRowHandle >= 0)
			{
				strMembershipID = gridView1.GetDataRow(gridView1.FocusedRowHandle)["strMembershipID"].ToString();
				this.DialogResult = DialogResult.OK;
			}
			else
			{
				ACMS.Utils.UI.ShowMessage(this, "Please select a row first.");
			}
		}

		private void sbtnSearch_Click(object sender, System.EventArgs e)
		{
			//gridControl1.DataSource = myMemberRecord.SearchMember(txtSearchKey.Text);
			LoadMember();
		}

		private void LoadMember()
		{
			int er;
			er = 0;
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"pr_tblMember_Search",_ds,new string[] {"table"}, new SqlParameter("@sstrKey", txtSearchKey.Text),new SqlParameter("@iErrorCode", er) );
		
			DataView dv = _ds.Tables["table"].DefaultView;
			
			if (luedtBranchCode.EditValue.ToString() != "")
				dv.RowFilter = "strBranchCode = '" + luedtBranchCode.EditValue.ToString() + "'";
			
			gridControl1.DataSource = _ds.Tables["table"];

		}

		private void gridView1_DoubleClick(object sender, System.EventArgs e)
		{
			DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hitInfo = ACMS.XtraUtils.GridViewUtils.GetGridHitInfo(gridView1);

			if (hitInfo.InRow)
			{
				sbtnOK.PerformClick();
			}
		}
	}
}
