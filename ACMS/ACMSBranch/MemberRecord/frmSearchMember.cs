using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ACMSLogic;

namespace ACMS.ACMSBranch
{
	/// <summary>
	/// Summary description for FormSearchMember.
	/// </summary>
	public class frmSearchMember : System.Windows.Forms.Form
	{
        private string strNRICID;
		private string strMembershipID;
		private string mySearchKey;
		private object myBranchCode;
		private ACMSLogic.MemberRecord.SearchMemberType mySearchMemberType;
        private int nPage;
        private int iSearching;
		private MemberRecord myMemberRecord;
		private DataTable mySearchTable;

		#region Windows Designer Generated Variables
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
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.LookUpEdit luedtBranchCode;
		private System.Windows.Forms.Label label2;
		private DevExpress.XtraEditors.ComboBoxEdit cbfMember;
		private DevExpress.XtraEditors.SimpleButton sbtnPrevious;
		private DevExpress.XtraEditors.SimpleButton sbtnNext;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		#endregion

		public string StrMemberShipID
		{
			get {return strMembershipID;}
        }
        public string StrNRICID
        {
            get { return strNRICID; }
        }

        public frmSearchMember(MemberRecord aMemberRecord, DataTable initTable, string searchKey, object terminalBranchCode, int iSearch)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			myMemberRecord = aMemberRecord;
			gridControl1.DataSource = initTable;//myMemberRecord.SearchMember(searchKey);
            strMembershipID = string.Empty;
            strNRICID = string.Empty;
			txtSearchKey.Text = searchKey;

			new ACMS.XtraUtils.LookupEditBuilder.BranchCodeLookupEditBuilder2(luedtBranchCode.Properties);
			DataTable branchTable = luedtBranchCode.Properties.DataSource as DataTable;
			DataRow rNew = branchTable.NewRow();
			rNew.BeginEdit();
			rNew["strBranchCode"] = DBNull.Value;
			rNew["strBranchName"] = "<<No Filter>>";
			rNew.EndEdit();
			branchTable.Rows.Add(rNew);

			luedtBranchCode.EditValue = terminalBranchCode;
			nPage = 1;
			mySearchKey = searchKey;
			myBranchCode = terminalBranchCode;
			mySearchMemberType = ACMSLogic.MemberRecord.SearchMemberType.AllMember;
            if (iSearch == 1)
            {
                mySearchMemberType = ACMSLogic.MemberRecord.SearchMemberType.NonMember;
                cbfMember.Text = "NonMember";
            }
			mySearchTable = initTable;
            //0805
         
			ToggleButton();
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
            this.sbtnNext = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnPrevious = new DevExpress.XtraEditors.SimpleButton();
            this.cbfMember = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.luedtBranchCode = new DevExpress.XtraEditors.LookUpEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.cbfMember.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luedtBranchCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchKey.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridControl1.Location = new System.Drawing.Point(0, 40);
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
            this.gridControl1.Size = new System.Drawing.Size(938, 470);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView1.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView1.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridView1.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridView1.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gridView1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView1.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.gridView1.Appearance.Empty.Options.UseBackColor = true;
            this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridView1.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridView1.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView1.Appearance.EvenRow.Options.UseBorderColor = true;
            this.gridView1.Appearance.EvenRow.Options.UseForeColor = true;
            this.gridView1.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridView1.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridView1.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gridView1.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gridView1.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gridView1.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView1.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView1.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(114)))), ((int)(((byte)(113)))));
            this.gridView1.Appearance.FixedLine.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(192)))), ((int)(((byte)(157)))));
            this.gridView1.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(219)))), ((int)(((byte)(188)))));
            this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView1.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView1.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridView1.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridView1.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView1.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView1.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            this.gridView1.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView1.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView1.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView1.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
            this.gridView1.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
            this.gridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseBorderColor = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView1.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridView1.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridView1.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.Options.UseBorderColor = true;
            this.gridView1.Appearance.OddRow.Options.UseForeColor = true;
            this.gridView1.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(252)))), ((int)(((byte)(247)))));
            this.gridView1.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.gridView1.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.gridView1.Appearance.Preview.Options.UseBackColor = true;
            this.gridView1.Appearance.Preview.Options.UseFont = true;
            this.gridView1.Appearance.Preview.Options.UseForeColor = true;
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridView1.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.Options.UseForeColor = true;
            this.gridView1.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView1.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.gridView1.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(215)))), ((int)(((byte)(188)))));
            this.gridView1.Appearance.SelectedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
            this.gridView1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.Options.UseBorderColor = true;
            this.gridView1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gridView1.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
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
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // colstrMembershipID
            // 
            this.colstrMembershipID.Caption = "Membership ID";
            this.colstrMembershipID.FieldName = "strMembershipID";
            this.colstrMembershipID.Name = "colstrMembershipID";
            this.colstrMembershipID.Visible = true;
            this.colstrMembershipID.VisibleIndex = 0;
            this.colstrMembershipID.Width = 96;
            // 
            // colstrBranchCode
            // 
            this.colstrBranchCode.Caption = "Branch Code";
            this.colstrBranchCode.FieldName = "strBranchCode";
            this.colstrBranchCode.Name = "colstrBranchCode";
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
            this.colstrMemberName.VisibleIndex = 1;
            this.colstrMemberName.Width = 153;
            // 
            // colstrCardName
            // 
            this.colstrCardName.Caption = "Card Name";
            this.colstrCardName.FieldName = "strCardName";
            this.colstrCardName.Name = "colstrCardName";
            this.colstrCardName.Visible = true;
            this.colstrCardName.VisibleIndex = 2;
            this.colstrCardName.Width = 85;
            // 
            // colstrNRICFIN
            // 
            this.colstrNRICFIN.Caption = "NRIC/FIN";
            this.colstrNRICFIN.FieldName = "strNRICFIN";
            this.colstrNRICFIN.Name = "colstrNRICFIN";
            this.colstrNRICFIN.Visible = true;
            this.colstrNRICFIN.VisibleIndex = 3;
            this.colstrNRICFIN.Width = 78;
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
            this.colfMember.VisibleIndex = 4;
            this.colfMember.Width = 51;
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
            this.colfAirCrew.VisibleIndex = 5;
            this.colfAirCrew.Width = 55;
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
            this.coldtDOB.VisibleIndex = 6;
            this.coldtDOB.Width = 86;
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
            this.colstrHomeNo.VisibleIndex = 7;
            this.colstrHomeNo.Width = 86;
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
            this.colstrMobileNo.VisibleIndex = 8;
            this.colstrMobileNo.Width = 86;
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
            this.colfPostalMail.Caption = "DNC?";
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
            this.colstrEmail.VisibleIndex = 9;
            this.colstrEmail.Width = 148;
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
            this.sbtnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.sbtnCancel.Location = new System.Drawing.Point(848, 2);
            this.sbtnCancel.Name = "sbtnCancel";
            this.sbtnCancel.Size = new System.Drawing.Size(75, 23);
            this.sbtnCancel.TabIndex = 1;
            this.sbtnCancel.Text = "Cancel";
            this.sbtnCancel.Click += new System.EventHandler(this.sbtnCancel_Click);
            // 
            // sbtnOK
            // 
            this.sbtnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtnOK.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnOK.Location = new System.Drawing.Point(764, 2);
            this.sbtnOK.Name = "sbtnOK";
            this.sbtnOK.Size = new System.Drawing.Size(75, 23);
            this.sbtnOK.TabIndex = 0;
            this.sbtnOK.Text = "OK";
            this.sbtnOK.Click += new System.EventHandler(this.sbtnOK_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.sbtnNext);
            this.panelControl1.Controls.Add(this.sbtnPrevious);
            this.panelControl1.Controls.Add(this.cbfMember);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.luedtBranchCode);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.label33);
            this.panelControl1.Controls.Add(this.sbtnSearch);
            this.panelControl1.Controls.Add(this.txtSearchKey);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(938, 40);
            this.panelControl1.TabIndex = 0;
            // 
            // sbtnNext
            // 
            this.sbtnNext.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnNext.Location = new System.Drawing.Point(850, 8);
            this.sbtnNext.Name = "sbtnNext";
            this.sbtnNext.Size = new System.Drawing.Size(75, 23);
            this.sbtnNext.TabIndex = 21;
            this.sbtnNext.Text = "&Next";
            this.sbtnNext.Click += new System.EventHandler(this.sbtnNext_Click);
            // 
            // sbtnPrevious
            // 
            this.sbtnPrevious.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnPrevious.Location = new System.Drawing.Point(768, 8);
            this.sbtnPrevious.Name = "sbtnPrevious";
            this.sbtnPrevious.Size = new System.Drawing.Size(75, 23);
            this.sbtnPrevious.TabIndex = 20;
            this.sbtnPrevious.Text = "&Previous";
            this.sbtnPrevious.Click += new System.EventHandler(this.sbtnPrevious_Click);
            // 
            // cbfMember
            // 
            this.cbfMember.EditValue = "All";
            this.cbfMember.Location = new System.Drawing.Point(444, 10);
            this.cbfMember.Name = "cbfMember";
            this.cbfMember.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbfMember.Properties.Items.AddRange(new object[] {
            "All",
            "Member Only",
            "Non-Member"});
            this.cbfMember.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbfMember.Size = new System.Drawing.Size(100, 20);
            this.cbfMember.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(392, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 18);
            this.label2.TabIndex = 19;
            this.label2.Text = "Member:";
            // 
            // luedtBranchCode
            // 
            this.luedtBranchCode.Location = new System.Drawing.Point(262, 10);
            this.luedtBranchCode.Name = "luedtBranchCode";
            this.luedtBranchCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luedtBranchCode.Size = new System.Drawing.Size(126, 20);
            this.luedtBranchCode.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(214, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 18);
            this.label1.TabIndex = 17;
            this.label1.Text = "Branch:";
            // 
            // label33
            // 
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(14, 12);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(50, 18);
            this.label33.TabIndex = 16;
            this.label33.Text = "Search:";
            // 
            // sbtnSearch
            // 
            this.sbtnSearch.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnSearch.Location = new System.Drawing.Point(556, 8);
            this.sbtnSearch.Name = "sbtnSearch";
            this.sbtnSearch.Size = new System.Drawing.Size(75, 23);
            this.sbtnSearch.TabIndex = 3;
            this.sbtnSearch.Text = "&Search";
            this.sbtnSearch.Click += new System.EventHandler(this.sbtnSearch_Click);
            // 
            // txtSearchKey
            // 
            this.txtSearchKey.EditValue = "";
            this.txtSearchKey.Location = new System.Drawing.Point(64, 10);
            this.txtSearchKey.Name = "txtSearchKey";
            this.txtSearchKey.Size = new System.Drawing.Size(146, 20);
            this.txtSearchKey.TabIndex = 0;
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.sbtnCancel);
            this.panelControl2.Controls.Add(this.sbtnOK);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 510);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(938, 34);
            this.panelControl2.TabIndex = 2;
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
            ((System.ComponentModel.ISupportInitialize)(this.cbfMember.Properties)).EndInit();
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
                strNRICID = gridView1.GetDataRow(gridView1.FocusedRowHandle)["strNRICFIN"].ToString();
				this.DialogResult = DialogResult.OK;
			}
			else
			{
				ACMS.Utils.UI.ShowMessage(this, "Please select a row first.");
				DialogResult = DialogResult.None;
			}
		}

		private void sbtnSearch_Click(object sender, System.EventArgs e)
		{
			mySearchKey = txtSearchKey.Text;
			myBranchCode = luedtBranchCode.EditValue;
            if (iSearching == 1)
            {
                mySearchMemberType = (ACMSLogic.MemberRecord.SearchMemberType)cbfMember.SelectedIndex;
            }
            else
			mySearchMemberType = (ACMSLogic.MemberRecord.SearchMemberType)cbfMember.SelectedIndex;
			Search(1);
		}

		///<summary>
		/// Refactored from sbtnSearch_Click
		///</summary>
		private void Search(int nPaged)
		{
			Cursor saveCursor = Cursor.Current;
			Cursor.Current = Cursors.WaitCursor;
			try
			{
				mySearchTable = myMemberRecord.SearchMember(mySearchKey, myBranchCode, mySearchMemberType, nPaged);
				gridControl1.DataSource = mySearchTable;
			}
			finally
			{
				Cursor.Current = Cursors.WaitCursor;
			}
			ToggleButton();
		}

		///<summary>
		/// Refactored from Search
		///</summary>
		private void ToggleButton()
		{
			if (nPage > 1)
				sbtnPrevious.Enabled = true;
			else
				sbtnPrevious.Enabled = false;
			if (mySearchTable.Rows.Count > 0 && Convert.ToInt32(mySearchTable.Rows[0]["MoreRecords"]) > 0)
				sbtnNext.Enabled = true;
			else
				sbtnNext.Enabled = false;
		}

		private void gridView1_DoubleClick(object sender, System.EventArgs e)
		{
			DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hitInfo = ACMS.XtraUtils.GridViewUtils.GetGridHitInfo(gridView1);

			if (hitInfo.InRow)
			{
				sbtnOK.PerformClick();
			}
		}

		private void sbtnNext_Click(object sender, System.EventArgs e)
		{
			nPage++;
			Search(nPage);
		}

		private void sbtnPrevious_Click(object sender, System.EventArgs e)
		{
			nPage--;
			Search(nPage);
		}
	}
}
