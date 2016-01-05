using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ACMS.ACMSPOS2
{
	/// <summary>
	/// Summary description for FormUpgradePackage.
	/// </summary>
	public class FormUpgradePackage : System.Windows.Forms.Form
	{
		private DevExpress.XtraEditors.SplitterControl splitterControl1;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn28;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn30;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn31;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn32;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn33;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn34;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn35;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn44;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn45;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn49;
		private DevExpress.XtraEditors.PanelControl panelControlTop;
		private DevExpress.XtraEditors.PanelControl panelControlMemberPackage;
		private DevExpress.XtraEditors.PanelControl panelControlPackage;
		internal DevExpress.XtraGrid.GridControl GridControlMemberPackage;
		private DevExpress.XtraGrid.GridControl gridControlPackage;
		private DevExpress.XtraGrid.Columns.GridColumn colItemDescription;
		private DevExpress.XtraGrid.Columns.GridColumn colItemPrice;
		internal DevExpress.XtraGrid.Views.Grid.GridView gridViewMemberPackage;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewPackage;
		private DevExpress.XtraGrid.Columns.GridColumn colPackageCode;
		private System.Windows.Forms.Label label1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private	ACMSLogic.CreditAccount myCreditAccount;
		private ACMSLogic.POS myPOS;
		private ACMSLogic.MemberPackage myMemberPackage;
		private DevExpress.XtraGrid.Columns.GridColumn colChecked;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
		private ACMSLogic.PackageCode myPackage;
		private DevExpress.XtraGrid.GridControl GridControlMemberCredit;
		internal DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		internal DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		internal DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		internal DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
		internal DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
		internal DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit4;
		private System.Windows.Forms.Label label2;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
		private DevExpress.XtraEditors.PanelControl panelControl1;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewMemberCredit;
		private DevExpress.XtraGrid.GridControl gridControlCredit;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit3;
		private DevExpress.XtraEditors.SimpleButton simpleButtonOK1;
		private DevExpress.XtraEditors.SimpleButton simpleButton2;
		private DataView myDataView;

		public FormUpgradePackage(ACMSLogic.POS pos)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

			
			comboBoxEdit1.Properties.Items.AddRange(new string [] {"Normal Package", "Credit Package"});			
			myPOS = pos;
			myMemberPackage = new ACMSLogic.MemberPackage();
			myPackage = new ACMSLogic.PackageCode();
			myCreditAccount = new ACMSLogic.CreditAccount();
			Init();
		}


		private void Init()
		{
			myDataView = myMemberPackage.GetActive_n_NonFreeMemberPackage_For_POS_Calculation(myPOS.StrMembershipID);
			GridControlMemberPackage.DataSource = myDataView;
			//GridControlMemberPackage.Hide();
			myCreditAccount.Refresh(myPOS.StrMembershipID);
			GridControlMemberCredit.DataSource = myCreditAccount.Table;
			
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
			DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
			DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
			this.panelControlTop = new DevExpress.XtraEditors.PanelControl();
			this.label1 = new System.Windows.Forms.Label();
			this.panelControlMemberPackage = new DevExpress.XtraEditors.PanelControl();
			this.GridControlMemberPackage = new DevExpress.XtraGrid.GridControl();
			this.gridViewMemberPackage = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.GridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumn30 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumn31 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumn32 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumn33 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumn34 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumn35 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumn44 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumn45 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.GridColumn49 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridControlMemberCredit = new DevExpress.XtraGrid.GridControl();
			this.gridViewMemberCredit = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemCheckEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
			this.panelControlPackage = new DevExpress.XtraEditors.PanelControl();
			this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButtonOK1 = new DevExpress.XtraEditors.SimpleButton();
			this.gridControlPackage = new DevExpress.XtraGrid.GridControl();
			this.gridViewPackage = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colPackageCode = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colItemDescription = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colItemPrice = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colChecked = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.gridControlCredit = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemCheckEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.label2 = new System.Windows.Forms.Label();
			this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
			this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
			((System.ComponentModel.ISupportInitialize)(this.panelControlTop)).BeginInit();
			this.panelControlTop.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.panelControlMemberPackage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GridControlMemberPackage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewMemberPackage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GridControlMemberCredit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewMemberCredit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControlPackage)).BeginInit();
			this.panelControlPackage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControlPackage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewPackage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControlCredit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
			this.panelControl1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelControlTop
			// 
			this.panelControlTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.panelControlTop.Controls.Add(this.label1);
			this.panelControlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelControlTop.Location = new System.Drawing.Point(0, 4);
			this.panelControlTop.Name = "panelControlTop";
			this.panelControlTop.Size = new System.Drawing.Size(864, 38);
			this.panelControlTop.TabIndex = 0;
			this.panelControlTop.Text = "panelControl1";
			this.panelControlTop.Paint += new System.Windows.Forms.PaintEventHandler(this.panelControlTop_Paint);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(286, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Upgrade Package";
			// 
			// panelControlMemberPackage
			// 
			this.panelControlMemberPackage.AutoScroll = true;
			this.panelControlMemberPackage.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.panelControlMemberPackage.Location = new System.Drawing.Point(0, 0);
			this.panelControlMemberPackage.Name = "panelControlMemberPackage";
			this.panelControlMemberPackage.Size = new System.Drawing.Size(864, 220);
			this.panelControlMemberPackage.TabIndex = 1;
			this.panelControlMemberPackage.Text = "panelControl2";
			// 
			// GridControlMemberPackage
			// 
			// 
			// GridControlMemberPackage.EmbeddedNavigator
			// 
			this.GridControlMemberPackage.EmbeddedNavigator.Name = "";
			this.GridControlMemberPackage.Location = new System.Drawing.Point(0, -4);
			this.GridControlMemberPackage.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.GridControlMemberPackage.LookAndFeel.UseDefaultLookAndFeel = false;
			this.GridControlMemberPackage.LookAndFeel.UseWindowsXPTheme = false;
			this.GridControlMemberPackage.MainView = this.gridViewMemberPackage;
			this.GridControlMemberPackage.Name = "GridControlMemberPackage";
			this.GridControlMemberPackage.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																															  this.repositoryItemCheckEdit1});
			this.GridControlMemberPackage.Size = new System.Drawing.Size(864, 288);
			this.GridControlMemberPackage.TabIndex = 8;
			this.GridControlMemberPackage.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																													this.gridViewMemberPackage});
			this.GridControlMemberPackage.Click += new System.EventHandler(this.GridControlMemberPackage_Click);
			// 
			// gridViewMemberPackage
			// 
			this.gridViewMemberPackage.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																										 this.GridColumn28,
																										 this.GridColumn30,
																										 this.GridColumn31,
																										 this.GridColumn32,
																										 this.GridColumn33,
																										 this.GridColumn34,
																										 this.GridColumn35,
																										 this.GridColumn44,
																										 this.GridColumn45,
																										 this.GridColumn49});
			this.gridViewMemberPackage.GridControl = this.GridControlMemberPackage;
			this.gridViewMemberPackage.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
			this.gridViewMemberPackage.Name = "gridViewMemberPackage";
			this.gridViewMemberPackage.OptionsView.ColumnAutoWidth = false;
			this.gridViewMemberPackage.OptionsView.ShowGroupPanel = false;
			this.gridViewMemberPackage.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridViewMemberPackage_CustomColumnDisplayText);
			this.gridViewMemberPackage.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewMemberPackage_FocusedRowChanged);
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
			// GridColumn32
			// 
			this.GridColumn32.Caption = "Purchase Date";
			this.GridColumn32.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.GridColumn32.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.GridColumn32.FieldName = "dtPurchaseDate";
			this.GridColumn32.Name = "GridColumn32";
			this.GridColumn32.OptionsColumn.AllowEdit = false;
			this.GridColumn32.OptionsColumn.AllowFocus = false;
			this.GridColumn32.OptionsFilter.AllowFilter = false;
			this.GridColumn32.Width = 84;
			// 
			// GridColumn33
			// 
			this.GridColumn33.Caption = "Receipt No";
			this.GridColumn33.FieldName = "strReceiptNo";
			this.GridColumn33.Name = "GridColumn33";
			this.GridColumn33.OptionsColumn.AllowEdit = false;
			this.GridColumn33.OptionsColumn.AllowFocus = false;
			this.GridColumn33.OptionsFilter.AllowFilter = false;
			this.GridColumn33.Visible = true;
			this.GridColumn33.VisibleIndex = 3;
			this.GridColumn33.Width = 82;
			// 
			// GridColumn34
			// 
			this.GridColumn34.Caption = "Balance";
			this.GridColumn34.FieldName = "Balance";
			this.GridColumn34.Name = "GridColumn34";
			this.GridColumn34.OptionsColumn.AllowEdit = false;
			this.GridColumn34.OptionsColumn.AllowFocus = false;
			this.GridColumn34.OptionsFilter.AllowFilter = false;
			this.GridColumn34.Width = 84;
			// 
			// GridColumn35
			// 
			this.GridColumn35.Caption = "Start Date";
			this.GridColumn35.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.GridColumn35.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.GridColumn35.FieldName = "dtStartDate";
			this.GridColumn35.Name = "GridColumn35";
			this.GridColumn35.OptionsColumn.AllowEdit = false;
			this.GridColumn35.OptionsColumn.AllowFocus = false;
			this.GridColumn35.OptionsFilter.AllowFilter = false;
			this.GridColumn35.Visible = true;
			this.GridColumn35.VisibleIndex = 4;
			this.GridColumn35.Width = 73;
			// 
			// GridColumn44
			// 
			this.GridColumn44.Caption = "Expiry Date";
			this.GridColumn44.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.GridColumn44.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.GridColumn44.FieldName = "dtExpiryDate";
			this.GridColumn44.Name = "GridColumn44";
			this.GridColumn44.OptionsColumn.AllowEdit = false;
			this.GridColumn44.OptionsColumn.AllowFocus = false;
			this.GridColumn44.OptionsFilter.AllowFilter = false;
			this.GridColumn44.Visible = true;
			this.GridColumn44.VisibleIndex = 5;
			this.GridColumn44.Width = 104;
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
			this.GridColumn45.VisibleIndex = 6;
			this.GridColumn45.Width = 110;
			// 
			// repositoryItemCheckEdit1
			// 
			this.repositoryItemCheckEdit1.AutoHeight = false;
			this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
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
			this.GridColumn49.VisibleIndex = 7;
			this.GridColumn49.Width = 218;
			// 
			// GridControlMemberCredit
			// 
			this.GridControlMemberCredit.Dock = System.Windows.Forms.DockStyle.Top;
			// 
			// GridControlMemberCredit.EmbeddedNavigator
			// 
			this.GridControlMemberCredit.EmbeddedNavigator.Name = "";
			this.GridControlMemberCredit.Location = new System.Drawing.Point(0, 0);
			this.GridControlMemberCredit.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.GridControlMemberCredit.LookAndFeel.UseDefaultLookAndFeel = false;
			this.GridControlMemberCredit.LookAndFeel.UseWindowsXPTheme = false;
			this.GridControlMemberCredit.MainView = this.gridViewMemberCredit;
			this.GridControlMemberCredit.Name = "GridControlMemberCredit";
			this.GridControlMemberCredit.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																															 this.repositoryItemCheckEdit4});
			this.GridControlMemberCredit.Size = new System.Drawing.Size(864, 288);
			this.GridControlMemberCredit.TabIndex = 9;
			this.GridControlMemberCredit.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																												   this.gridViewMemberCredit});
			this.GridControlMemberCredit.Click += new System.EventHandler(this.GridControlMemberCredit_Click);
			// 
			// gridViewMemberCredit
			// 
			this.gridViewMemberCredit.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																										this.gridColumn2,
																										this.gridColumn1,
																										this.gridColumn3,
																										this.gridColumn4,
																										this.gridColumn5,
																										this.gridColumn6,
																										this.gridColumn7,
																										this.gridColumn8,
																										this.gridColumn9,
																										this.gridColumn10,
																										this.gridColumn12,
																										this.gridColumn11});
			this.gridViewMemberCredit.GridControl = this.GridControlMemberCredit;
			this.gridViewMemberCredit.Name = "gridViewMemberCredit";
			this.gridViewMemberCredit.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
																												 new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn1, DevExpress.Data.ColumnSortOrder.Descending)});
			this.gridViewMemberCredit.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewMemberCredit_FocusedRowChanged);
			// 
			// gridColumn2
			// 
			this.gridColumn2.Caption = "Code";
			this.gridColumn2.FieldName = "strCreditPackageCode";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.OptionsColumn.AllowEdit = false;
			this.gridColumn2.OptionsColumn.AllowFocus = false;
			this.gridColumn2.OptionsColumn.ReadOnly = true;
			this.gridColumn2.OptionsFilter.AllowFilter = false;
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 1;
			this.gridColumn2.Width = 68;
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "Credit Package";
			this.gridColumn1.FieldName = "nCreditPackageID";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.OptionsColumn.AllowEdit = false;
			this.gridColumn1.OptionsColumn.AllowFocus = false;
			this.gridColumn1.OptionsColumn.ReadOnly = true;
			this.gridColumn1.OptionsFilter.AllowFilter = false;
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 0;
			this.gridColumn1.Width = 79;
			// 
			// gridColumn3
			// 
			this.gridColumn3.Caption = "Description";
			this.gridColumn3.FieldName = "strDesciption";
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.OptionsColumn.AllowEdit = false;
			this.gridColumn3.OptionsColumn.AllowFocus = false;
			this.gridColumn3.OptionsColumn.ReadOnly = true;
			this.gridColumn3.OptionsFilter.AllowFilter = false;
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 2;
			this.gridColumn3.Width = 68;
			// 
			// gridColumn4
			// 
			this.gridColumn4.Caption = "Date";
			this.gridColumn4.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.gridColumn4.FieldName = "dtPurchaseDate";
			this.gridColumn4.Name = "gridColumn4";
			this.gridColumn4.Visible = true;
			this.gridColumn4.VisibleIndex = 3;
			this.gridColumn4.Width = 68;
			// 
			// gridColumn5
			// 
			this.gridColumn5.Caption = "Receipt #";
			this.gridColumn5.FieldName = "strReceiptNo";
			this.gridColumn5.Name = "gridColumn5";
			this.gridColumn5.OptionsColumn.AllowEdit = false;
			this.gridColumn5.OptionsColumn.AllowFocus = false;
			this.gridColumn5.OptionsColumn.ReadOnly = true;
			this.gridColumn5.OptionsFilter.AllowFilter = false;
			this.gridColumn5.Visible = true;
			this.gridColumn5.VisibleIndex = 4;
			this.gridColumn5.Width = 68;
			// 
			// gridColumn6
			// 
			this.gridColumn6.Caption = "Balance";
			this.gridColumn6.DisplayFormat.FormatString = "n2";
			this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumn6.FieldName = "Balance";
			this.gridColumn6.Name = "gridColumn6";
			this.gridColumn6.Visible = true;
			this.gridColumn6.VisibleIndex = 5;
			this.gridColumn6.Width = 68;
			// 
			// gridColumn7
			// 
			this.gridColumn7.Caption = "Start Date";
			this.gridColumn7.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.gridColumn7.FieldName = "dtStartDate";
			this.gridColumn7.Name = "gridColumn7";
			this.gridColumn7.OptionsColumn.AllowEdit = false;
			this.gridColumn7.OptionsColumn.AllowFocus = false;
			this.gridColumn7.OptionsColumn.ReadOnly = true;
			this.gridColumn7.OptionsFilter.AllowFilter = false;
			this.gridColumn7.Visible = true;
			this.gridColumn7.VisibleIndex = 6;
			this.gridColumn7.Width = 68;
			// 
			// gridColumn8
			// 
			this.gridColumn8.Caption = "Expiry Date";
			this.gridColumn8.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.gridColumn8.FieldName = "dtExpiryDate";
			this.gridColumn8.Name = "gridColumn8";
			this.gridColumn8.OptionsColumn.AllowEdit = false;
			this.gridColumn8.OptionsColumn.AllowFocus = false;
			this.gridColumn8.OptionsColumn.ReadOnly = true;
			this.gridColumn8.OptionsFilter.AllowFilter = false;
			this.gridColumn8.Visible = true;
			this.gridColumn8.VisibleIndex = 7;
			this.gridColumn8.Width = 68;
			// 
			// gridColumn9
			// 
			this.gridColumn9.Caption = "Free";
			this.gridColumn9.ColumnEdit = this.repositoryItemCheckEdit4;
			this.gridColumn9.FieldName = "fFree";
			this.gridColumn9.Name = "gridColumn9";
			this.gridColumn9.OptionsColumn.AllowEdit = false;
			this.gridColumn9.OptionsColumn.AllowFocus = false;
			this.gridColumn9.OptionsColumn.ReadOnly = true;
			this.gridColumn9.OptionsFilter.AllowFilter = false;
			this.gridColumn9.Visible = true;
			this.gridColumn9.VisibleIndex = 8;
			this.gridColumn9.Width = 68;
			// 
			// repositoryItemCheckEdit4
			// 
			this.repositoryItemCheckEdit4.AutoHeight = false;
			this.repositoryItemCheckEdit4.Name = "repositoryItemCheckEdit4";
			// 
			// gridColumn10
			// 
			this.gridColumn10.Caption = "Status";
			this.gridColumn10.FieldName = "nStatusID";
			this.gridColumn10.Name = "gridColumn10";
			this.gridColumn10.OptionsColumn.AllowEdit = false;
			this.gridColumn10.OptionsColumn.AllowFocus = false;
			this.gridColumn10.OptionsColumn.ReadOnly = true;
			this.gridColumn10.OptionsFilter.AllowFilter = false;
			this.gridColumn10.Visible = true;
			this.gridColumn10.VisibleIndex = 9;
			this.gridColumn10.Width = 68;
			// 
			// gridColumn12
			// 
			this.gridColumn12.Caption = "Employee";
			this.gridColumn12.FieldName = "strEmployeeName";
			this.gridColumn12.Name = "gridColumn12";
			this.gridColumn12.OptionsColumn.AllowEdit = false;
			this.gridColumn12.OptionsColumn.AllowFocus = false;
			this.gridColumn12.OptionsColumn.ReadOnly = true;
			this.gridColumn12.OptionsFilter.AllowFilter = false;
			this.gridColumn12.Visible = true;
			this.gridColumn12.VisibleIndex = 10;
			this.gridColumn12.Width = 68;
			// 
			// gridColumn11
			// 
			this.gridColumn11.Caption = "Remarks";
			this.gridColumn11.FieldName = "strRemarks";
			this.gridColumn11.Name = "gridColumn11";
			this.gridColumn11.OptionsColumn.AllowEdit = false;
			this.gridColumn11.OptionsColumn.AllowFocus = false;
			this.gridColumn11.OptionsFilter.AllowFilter = false;
			this.gridColumn11.Visible = true;
			this.gridColumn11.VisibleIndex = 11;
			// 
			// splitterControl1
			// 
			this.splitterControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitterControl1.Location = new System.Drawing.Point(0, 0);
			this.splitterControl1.Name = "splitterControl1";
			this.splitterControl1.Size = new System.Drawing.Size(864, 4);
			this.splitterControl1.TabIndex = 2;
			this.splitterControl1.TabStop = false;
			// 
			// panelControlPackage
			// 
			this.panelControlPackage.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.panelControlPackage.Controls.Add(this.simpleButton2);
			this.panelControlPackage.Controls.Add(this.simpleButtonOK1);
			this.panelControlPackage.Controls.Add(this.GridControlMemberPackage);
			this.panelControlPackage.Controls.Add(this.GridControlMemberCredit);
			this.panelControlPackage.Controls.Add(this.gridControlPackage);
			this.panelControlPackage.Controls.Add(this.gridControlCredit);
			this.panelControlPackage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelControlPackage.Location = new System.Drawing.Point(0, 42);
			this.panelControlPackage.Name = "panelControlPackage";
			this.panelControlPackage.Size = new System.Drawing.Size(864, 530);
			this.panelControlPackage.TabIndex = 4;
			this.panelControlPackage.Text = "panelControl4";
			// 
			// simpleButton2
			// 
			this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.simpleButton2.Location = new System.Drawing.Point(778, 502);
			this.simpleButton2.Name = "simpleButton2";
			this.simpleButton2.TabIndex = 12;
			this.simpleButton2.Text = "Cancel";
			// 
			// simpleButtonOK1
			// 
			this.simpleButtonOK1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.simpleButtonOK1.Location = new System.Drawing.Point(692, 504);
			this.simpleButtonOK1.Name = "simpleButtonOK1";
			this.simpleButtonOK1.TabIndex = 11;
			this.simpleButtonOK1.Text = "OK";
			this.simpleButtonOK1.Click += new System.EventHandler(this.simpleButtonOK1_Click);
			// 
			// gridControlPackage
			// 
			// 
			// gridControlPackage.EmbeddedNavigator
			// 
			this.gridControlPackage.EmbeddedNavigator.Name = "";
			gridLevelNode1.RelationName = "Level1";
			this.gridControlPackage.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
																										 gridLevelNode1});
			this.gridControlPackage.Location = new System.Drawing.Point(0, 288);
			this.gridControlPackage.MainView = this.gridViewPackage;
			this.gridControlPackage.Name = "gridControlPackage";
			this.gridControlPackage.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																														this.repositoryItemCheckEdit2});
			this.gridControlPackage.Size = new System.Drawing.Size(864, 202);
			this.gridControlPackage.TabIndex = 3;
			this.gridControlPackage.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																											  this.gridViewPackage});
			this.gridControlPackage.Click += new System.EventHandler(this.gridControlPackage_Click);
			// 
			// gridViewPackage
			// 
			this.gridViewPackage.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																								   this.colPackageCode,
																								   this.colItemDescription,
																								   this.colItemPrice,
																								   this.colChecked});
			this.gridViewPackage.GridControl = this.gridControlPackage;
			this.gridViewPackage.Name = "gridViewPackage";
			// 
			// colPackageCode
			// 
			this.colPackageCode.Caption = "Package Code";
			this.colPackageCode.FieldName = "strPackageCode";
			this.colPackageCode.Name = "colPackageCode";
			this.colPackageCode.OptionsColumn.AllowEdit = false;
			this.colPackageCode.OptionsFilter.AllowFilter = false;
			this.colPackageCode.Visible = true;
			this.colPackageCode.VisibleIndex = 1;
			this.colPackageCode.Width = 221;
			// 
			// colItemDescription
			// 
			this.colItemDescription.Caption = "Description";
			this.colItemDescription.FieldName = "strDescription";
			this.colItemDescription.Name = "colItemDescription";
			this.colItemDescription.OptionsColumn.AllowEdit = false;
			this.colItemDescription.OptionsFilter.AllowFilter = false;
			this.colItemDescription.Visible = true;
			this.colItemDescription.VisibleIndex = 2;
			this.colItemDescription.Width = 276;
			// 
			// colItemPrice
			// 
			this.colItemPrice.Caption = "Unit Price";
			this.colItemPrice.FieldName = "mListPrice";
			this.colItemPrice.Name = "colItemPrice";
			this.colItemPrice.OptionsColumn.AllowEdit = false;
			this.colItemPrice.OptionsFilter.AllowFilter = false;
			this.colItemPrice.Visible = true;
			this.colItemPrice.VisibleIndex = 3;
			this.colItemPrice.Width = 285;
			// 
			// colChecked
			// 
			this.colChecked.ColumnEdit = this.repositoryItemCheckEdit2;
			this.colChecked.FieldName = "Checked";
			this.colChecked.Name = "colChecked";
			this.colChecked.Visible = true;
			this.colChecked.VisibleIndex = 0;
			this.colChecked.Width = 52;
			// 
			// repositoryItemCheckEdit2
			// 
			this.repositoryItemCheckEdit2.AutoHeight = false;
			this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
			this.repositoryItemCheckEdit2.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
			this.repositoryItemCheckEdit2.ValueGrayed = "";
			// 
			// gridControlCredit
			// 
			// 
			// gridControlCredit.EmbeddedNavigator
			// 
			this.gridControlCredit.EmbeddedNavigator.Name = "";
			gridLevelNode2.RelationName = "Level1";
			this.gridControlCredit.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
																										gridLevelNode2});
			this.gridControlCredit.Location = new System.Drawing.Point(0, 288);
			this.gridControlCredit.MainView = this.gridView1;
			this.gridControlCredit.Name = "gridControlCredit";
			this.gridControlCredit.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																													   this.repositoryItemCheckEdit3});
			this.gridControlCredit.Size = new System.Drawing.Size(864, 206);
			this.gridControlCredit.TabIndex = 10;
			this.gridControlCredit.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																											 this.gridView1});
			// 
			// gridView1
			// 
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn13,
																							 this.gridColumn14,
																							 this.gridColumn15,
																							 this.gridColumn16});
			this.gridView1.GridControl = this.gridControlCredit;
			this.gridView1.Name = "gridView1";
			// 
			// gridColumn13
			// 
			this.gridColumn13.Caption = "CreditPackage Code";
			this.gridColumn13.FieldName = "strCreditPackageCode";
			this.gridColumn13.Name = "gridColumn13";
			this.gridColumn13.OptionsColumn.AllowEdit = false;
			this.gridColumn13.OptionsFilter.AllowFilter = false;
			this.gridColumn13.Visible = true;
			this.gridColumn13.VisibleIndex = 0;
			this.gridColumn13.Width = 221;
			// 
			// gridColumn14
			// 
			this.gridColumn14.Caption = "Description";
			this.gridColumn14.FieldName = "strDescription";
			this.gridColumn14.Name = "gridColumn14";
			this.gridColumn14.OptionsColumn.AllowEdit = false;
			this.gridColumn14.OptionsFilter.AllowFilter = false;
			this.gridColumn14.Visible = true;
			this.gridColumn14.VisibleIndex = 1;
			this.gridColumn14.Width = 276;
			// 
			// gridColumn15
			// 
			this.gridColumn15.Caption = "Unit Price";
			this.gridColumn15.FieldName = "mListPrice";
			this.gridColumn15.Name = "gridColumn15";
			this.gridColumn15.OptionsColumn.AllowEdit = false;
			this.gridColumn15.OptionsFilter.AllowFilter = false;
			this.gridColumn15.Visible = true;
			this.gridColumn15.VisibleIndex = 2;
			this.gridColumn15.Width = 285;
			// 
			// gridColumn16
			// 
			this.gridColumn16.ColumnEdit = this.repositoryItemCheckEdit3;
			this.gridColumn16.FieldName = "Checked";
			this.gridColumn16.Name = "gridColumn16";
			this.gridColumn16.Width = 52;
			// 
			// repositoryItemCheckEdit3
			// 
			this.repositoryItemCheckEdit3.AutoHeight = false;
			this.repositoryItemCheckEdit3.Name = "repositoryItemCheckEdit3";
			this.repositoryItemCheckEdit3.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
			this.repositoryItemCheckEdit3.ValueGrayed = "";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(10, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 16);
			this.label2.TabIndex = 11;
			this.label2.Text = "Upgrade Type :";
			this.label2.Click += new System.EventHandler(this.label2_Click);
			// 
			// comboBoxEdit1
			// 
			this.comboBoxEdit1.EditValue = "Normal Package";
			this.comboBoxEdit1.Location = new System.Drawing.Point(98, 14);
			this.comboBoxEdit1.Name = "comboBoxEdit1";
			// 
			// comboBoxEdit1.Properties
			// 
			this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit1.TabIndex = 12;
			this.comboBoxEdit1.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit1_SelectedIndexChanged);
			// 
			// panelControl1
			// 
			this.panelControl1.Controls.Add(this.label2);
			this.panelControl1.Controls.Add(this.comboBoxEdit1);
			this.panelControl1.Location = new System.Drawing.Point(-6, 0);
			this.panelControl1.Name = "panelControl1";
			this.panelControl1.Size = new System.Drawing.Size(864, 42);
			this.panelControl1.TabIndex = 5;
			this.panelControl1.Text = "panelControl1";
			this.panelControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.panelControl1_Paint);
			// 
			// FormUpgradePackage
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(864, 572);
			this.Controls.Add(this.panelControl1);
			this.Controls.Add(this.panelControlPackage);
			this.Controls.Add(this.panelControlTop);
			this.Controls.Add(this.panelControlMemberPackage);
			this.Controls.Add(this.splitterControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormUpgradePackage";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Upgrade Selection";
			this.Load += new System.EventHandler(this.FormUpgradePackage_Load);
			((System.ComponentModel.ISupportInitialize)(this.panelControlTop)).EndInit();
			this.panelControlTop.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.panelControlMemberPackage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GridControlMemberPackage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewMemberPackage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GridControlMemberCredit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewMemberCredit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControlPackage)).EndInit();
			this.panelControlPackage.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControlPackage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewPackage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControlCredit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
			this.panelControl1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void gridViewMemberPackage_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
			DataRow r = gridViewMemberPackage.GetDataRow(gridViewMemberPackage.FocusedRowHandle);

			if (r != null)
			{
				string strPackageCode = r["strPackageCode"].ToString(); 
				DataTable table = myPackage.GetAllValidUpgradablePackageBaseOldPackage(strPackageCode);

				if (!table.Columns.Contains("Checked"))
				{
					DataColumn colChecked = new DataColumn("Checked", typeof(bool));
					table.Columns.Add(colChecked);
				}

				gridControlPackage.DataSource = table;
				
			}
		}

		private void simpleButtonOK_Click(object sender, System.EventArgs e)
		{
			ACMS.XtraUtils.GridViewUtils.UpdateData(gridViewPackage);
			ACMS.XtraUtils.GridViewUtils.UpdateData(gridViewMemberPackage);

			DataRow r = gridViewMemberPackage.GetDataRow(gridViewMemberPackage.FocusedRowHandle);
			
			if (r != null)
			{
				DataRow[] rowToAdd = ((DataTable)gridControlPackage.DataSource).Select("Checked = true ");
				myPOS.NewReceiptEntryForUpgrade(rowToAdd, r);
			}
		}

		private void gridViewMemberPackage_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
		{
			if (e.Column.FieldName == "Balance")
			{
				if (ACMS.Convert.ToInt32(myDataView.Table.Rows[e.ListSourceRowIndex]["FNew"])== 1 &&
					ACMS.Convert.ToInt32(myDataView.Table.Rows[e.ListSourceRowIndex]["Balance"]) == 0)
				{
					e.DisplayText = "New";
				}
			}
		}

		private void GridControlMemberCredit_Click(object sender, System.EventArgs e)
		{
		
		}

		private void FormUpgradePackage_Load(object sender, System.EventArgs e)
		{
		
		}

		private void label2_Click(object sender, System.EventArgs e)
		{
		
		}

		private void GridControlMemberPackage_Click(object sender, System.EventArgs e)
		{
		
		}

		private void panelControl1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		
		}

		private void gridControlPackage_Click(object sender, System.EventArgs e)
		{
		
		}

		private void panelControlTop_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		
		}

		private void comboBoxEdit1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string a = comboBoxEdit1.SelectedText;
			if (comboBoxEdit1.SelectedText == "Normal Package")
			{
				myDataView = myMemberPackage.GetActive_n_NonFreeMemberPackage_For_POS_Calculation(myPOS.StrMembershipID);
				GridControlMemberPackage.DataSource = myDataView;
				GridControlMemberPackage.Show();
				GridControlMemberCredit.Hide();
				GridControlMemberPackage.Focus();
				gridControlCredit.Hide();
				gridControlPackage.Show();
				//this.gridViewMemberPackage.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.comboBoxEdit1_SelectedIndexChanged);
				

			}
			else 
			{
				myCreditAccount.Refresh(myPOS.StrMembershipID);
				GridControlMemberCredit.DataSource = myCreditAccount.Table;
				GridControlMemberPackage.Hide();
				GridControlMemberCredit.Show();
				gridControlCredit.Show();
				gridControlPackage.Hide();
				//this.gridViewMemberCredit.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.comboBoxEdit1_SelectedIndexChanged);
				//gridViewMemberCredit.FocusedRowChanged;
			}
		}

		private void gridViewMemberCredit_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
			DataRow r = gridViewMemberCredit.GetDataRow(gridViewMemberCredit.FocusedRowHandle);

			if (r != null)
			{
				string strPackageCode = r[2].ToString();
				string a = r[4].ToString();
				string aq1= r[7].ToString();
				
				decimal ListPrice = ACMS.Convert.ToDecimal(r["Balance"]);
				DataTable table = myPackage.GetUpgradeCreditPackageList(strPackageCode);
				if (!table.Columns.Contains("Checked"))
				{
					DataColumn colChecked = new DataColumn("Checked", typeof(bool));
					table.Columns.Add(colChecked);
				}

				gridControlCredit.DataSource = table;
				table.DefaultView.RowFilter = "mListPrice >" + ListPrice;
				//				mListPrice
			}
		
		}

		private void simpleButtonOK1_Click(object sender, System.EventArgs e)
		{			
			if (comboBoxEdit1.SelectedIndex==0)
			{
				ACMS.XtraUtils.GridViewUtils.UpdateData(gridViewPackage);
				ACMS.XtraUtils.GridViewUtils.UpdateData(gridViewMemberPackage);

				DataRow r = gridViewMemberPackage.GetDataRow(gridViewMemberPackage.FocusedRowHandle);
			
				if (r != null)
				{
					DataRow[] rowToAdd = ((DataTable)gridControlPackage.DataSource).Select("Checked = true ");
					myPOS.NoCredit=0;
					myPOS.NewReceiptEntryForUpgrade(rowToAdd, r);
				}
				return;
			}
			else if (comboBoxEdit1.SelectedIndex==1)
			{
				ACMS.XtraUtils.GridViewUtils.UpdateData(gridView1);
				ACMS.XtraUtils.GridViewUtils.UpdateData(gridViewMemberCredit);
				DataRow r = gridViewMemberCredit.GetDataRow(gridViewMemberCredit.FocusedRowHandle);
			
				if (r != null)
				{
					int nCredit = ACMS.Convert.ToInt32(r["nCreditPackageID"]);
					//later to delete which credit package after tender
					myPOS.NoCredit = nCredit;
					DataRow rowToAdd = gridView1.GetDataRow(gridView1.FocusedRowHandle);
					myPOS.NewReceiptEntryForCreditUpgrade(rowToAdd,r);
				}
			}
		}

	
	}
}
