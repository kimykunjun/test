using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;
using System.Data.OleDb;

namespace ACMS.ACMSManager.MasterData
{
	/// <summary>
	/// Summary description for frmLeave.
	/// </summary>
	public class frmLeave : System.Windows.Forms.Form
	{
		private string connectionString;
		private SqlConnection connection;
		private DevExpress.XtraEditors.GroupControl grpMDLeaveTop;
		private DevExpress.XtraEditors.GroupControl groupControl1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraEditors.GroupControl groupControl2;
		private DevExpress.XtraGrid.GridControl gridControl1;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		internal DevExpress.XtraEditors.SimpleButton btn_Add;
		internal DevExpress.XtraEditors.SimpleButton btn_Del;
		private System.Windows.Forms.ImageList imageList1;
		internal DevExpress.XtraEditors.SimpleButton btnLeave_Add;
		internal DevExpress.XtraEditors.SimpleButton btnLeave_Del;
		private System.ComponentModel.IContainer components;
		private DataTable dtLeaveType;
		private DataTable dtLeave;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox lk_YearFrom;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox lk_YearTo;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cmbYearFrom;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraTab.XtraTabControl xtraTabWorkYear;
		private DevExpress.XtraTab.XtraTabPage WrkYr1;
		private DevExpress.XtraTab.XtraTabPage WrkYr2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox2;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox3;
		private DevExpress.XtraTab.XtraTabPage WrkYr3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox4;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox5;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox6;
		private DevExpress.XtraTab.XtraTabPage WrkYr4;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox7;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox8;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox9;
		private DevExpress.XtraTab.XtraTabPage WrkYr5;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox10;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox11;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox12;
		private DevExpress.XtraGrid.GridControl gridWrkYr1;
		private DevExpress.XtraGrid.Views.Grid.GridView gridWrkYrView1;
		private DevExpress.XtraGrid.GridControl gridWrkYr2;
		private DevExpress.XtraGrid.Views.Grid.GridView gridWrkYrView2;
		private DevExpress.XtraGrid.GridControl gridWrkYr3;
		private DevExpress.XtraGrid.Views.Grid.GridView gridWrkYrView3;
		private DevExpress.XtraGrid.GridControl gridWrkYr4;
		private DevExpress.XtraGrid.Views.Grid.GridView gridWrkYrView4;
		private DevExpress.XtraGrid.GridControl gridWrkYr5;
		private DevExpress.XtraGrid.Views.Grid.GridView gridWrkYrView5;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
	
		public frmLeave()
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmLeave));
			DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
			this.grpMDLeaveTop = new DevExpress.XtraEditors.GroupControl();
			this.btn_Add = new DevExpress.XtraEditors.SimpleButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.btn_Del = new DevExpress.XtraEditors.SimpleButton();
			this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
			this.gridControl1 = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
			this.xtraTabWorkYear = new DevExpress.XtraTab.XtraTabControl();
			this.WrkYr1 = new DevExpress.XtraTab.XtraTabPage();
			this.gridWrkYr1 = new DevExpress.XtraGrid.GridControl();
			this.gridWrkYrView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.lk_YearFrom = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.lk_YearTo = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.cmbYearFrom = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.WrkYr2 = new DevExpress.XtraTab.XtraTabPage();
			this.gridWrkYr2 = new DevExpress.XtraGrid.GridControl();
			this.gridWrkYrView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.repositoryItemComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.repositoryItemComboBox3 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.WrkYr3 = new DevExpress.XtraTab.XtraTabPage();
			this.gridWrkYr3 = new DevExpress.XtraGrid.GridControl();
			this.gridWrkYrView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemComboBox4 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.repositoryItemComboBox5 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.repositoryItemComboBox6 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.WrkYr4 = new DevExpress.XtraTab.XtraTabPage();
			this.gridWrkYr4 = new DevExpress.XtraGrid.GridControl();
			this.gridWrkYrView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemComboBox7 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.repositoryItemComboBox8 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.repositoryItemComboBox9 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.WrkYr5 = new DevExpress.XtraTab.XtraTabPage();
			this.gridWrkYr5 = new DevExpress.XtraGrid.GridControl();
			this.gridWrkYrView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemComboBox10 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.repositoryItemComboBox11 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.repositoryItemComboBox12 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.btnLeave_Del = new DevExpress.XtraEditors.SimpleButton();
			this.btnLeave_Add = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.grpMDLeaveTop)).BeginInit();
			this.grpMDLeaveTop.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
			this.groupControl2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
			this.groupControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.xtraTabWorkYear)).BeginInit();
			this.xtraTabWorkYear.SuspendLayout();
			this.WrkYr1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridWrkYr1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridWrkYrView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_YearFrom)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_YearTo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbYearFrom)).BeginInit();
			this.WrkYr2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridWrkYr2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridWrkYrView2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox3)).BeginInit();
			this.WrkYr3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridWrkYr3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridWrkYrView3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox6)).BeginInit();
			this.WrkYr4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridWrkYr4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridWrkYrView4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox7)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox8)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox9)).BeginInit();
			this.WrkYr5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridWrkYr5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridWrkYrView5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox10)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox11)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox12)).BeginInit();
			this.SuspendLayout();
			// 
			// grpMDLeaveTop
			// 
			this.grpMDLeaveTop.Appearance.BackColor = System.Drawing.Color.LightGray;
			this.grpMDLeaveTop.Appearance.Options.UseBackColor = true;
			this.grpMDLeaveTop.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.grpMDLeaveTop.AppearanceCaption.Options.UseFont = true;
			this.grpMDLeaveTop.Controls.Add(this.btn_Add);
			this.grpMDLeaveTop.Controls.Add(this.btn_Del);
			this.grpMDLeaveTop.Controls.Add(this.groupControl2);
			this.grpMDLeaveTop.Controls.Add(this.groupControl1);
			this.grpMDLeaveTop.Controls.Add(this.btnLeave_Del);
			this.grpMDLeaveTop.Controls.Add(this.btnLeave_Add);
			this.grpMDLeaveTop.ImeMode = System.Windows.Forms.ImeMode.On;
			this.grpMDLeaveTop.Location = new System.Drawing.Point(8, 0);
			this.grpMDLeaveTop.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.grpMDLeaveTop.LookAndFeel.UseDefaultLookAndFeel = false;
			this.grpMDLeaveTop.LookAndFeel.UseWindowsXPTheme = false;
			this.grpMDLeaveTop.Name = "grpMDLeaveTop";
			this.grpMDLeaveTop.Size = new System.Drawing.Size(968, 560);
			this.grpMDLeaveTop.TabIndex = 89;
			this.grpMDLeaveTop.Text = "Leave";
			// 
			// btn_Add
			// 
			this.btn_Add.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btn_Add.Appearance.Options.UseFont = true;
			this.btn_Add.Appearance.Options.UseTextOptions = true;
			this.btn_Add.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.btn_Add.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
			this.btn_Add.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.btn_Add.ImageIndex = 0;
			this.btn_Add.ImageList = this.imageList1;
			this.btn_Add.ImeMode = System.Windows.Forms.ImeMode.On;
			this.btn_Add.Location = new System.Drawing.Point(8, 24);
			this.btn_Add.Name = "btn_Add";
			this.btn_Add.Size = new System.Drawing.Size(38, 16);
			this.btn_Add.TabIndex = 132;
			this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
			// 
			// btn_Del
			// 
			this.btn_Del.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btn_Del.Appearance.Options.UseFont = true;
			this.btn_Del.Appearance.Options.UseTextOptions = true;
			this.btn_Del.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.btn_Del.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
			this.btn_Del.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.btn_Del.ImageIndex = 1;
			this.btn_Del.ImageList = this.imageList1;
			this.btn_Del.Location = new System.Drawing.Point(48, 24);
			this.btn_Del.Name = "btn_Del";
			this.btn_Del.Size = new System.Drawing.Size(38, 16);
			this.btn_Del.TabIndex = 131;
			this.btn_Del.Click += new System.EventHandler(this.btn_Del_Click);
			// 
			// groupControl2
			// 
			this.groupControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.groupControl2.Controls.Add(this.gridControl1);
			this.groupControl2.Location = new System.Drawing.Point(8, 48);
			this.groupControl2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.groupControl2.LookAndFeel.UseDefaultLookAndFeel = false;
			this.groupControl2.LookAndFeel.UseWindowsXPTheme = false;
			this.groupControl2.Name = "groupControl2";
			this.groupControl2.Size = new System.Drawing.Size(944, 200);
			this.groupControl2.TabIndex = 23;
			this.groupControl2.Text = "Leave Type";
			// 
			// gridControl1
			// 
			this.gridControl1.Dock = System.Windows.Forms.DockStyle.Top;
			// 
			// gridControl1.EmbeddedNavigator
			// 
			this.gridControl1.EmbeddedNavigator.Name = "";
			gridLevelNode1.RelationName = "Level1";
			this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
																								   gridLevelNode1});
			this.gridControl1.Location = new System.Drawing.Point(0, 0);
			this.gridControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.gridControl1.LookAndFeel.UseDefaultLookAndFeel = false;
			this.gridControl1.MainView = this.gridView1;
			this.gridControl1.Name = "gridControl1";
			this.gridControl1.Size = new System.Drawing.Size(944, 192);
			this.gridControl1.TabIndex = 1;
			this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										this.gridView1});
			// 
			// gridView1
			// 
			this.gridView1.GridControl = this.gridControl1;
			this.gridView1.Name = "gridView1";
			this.gridView1.OptionsCustomization.AllowFilter = false;
			this.gridView1.OptionsCustomization.AllowSort = false;
			this.gridView1.OptionsView.ShowGroupPanel = false;
			this.gridView1.LostFocus += new System.EventHandler(this.gridView1_LostFocus);
			// 
			// groupControl1
			// 
			this.groupControl1.Controls.Add(this.xtraTabWorkYear);
			this.groupControl1.Location = new System.Drawing.Point(8, 272);
			this.groupControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
			this.groupControl1.LookAndFeel.UseWindowsXPTheme = false;
			this.groupControl1.Name = "groupControl1";
			this.groupControl1.Size = new System.Drawing.Size(944, 256);
			this.groupControl1.TabIndex = 21;
			this.groupControl1.Text = "Leave Work Year";
			// 
			// xtraTabWorkYear
			// 
			this.xtraTabWorkYear.Dock = System.Windows.Forms.DockStyle.Left;
			this.xtraTabWorkYear.Location = new System.Drawing.Point(2, 20);
			this.xtraTabWorkYear.Name = "xtraTabWorkYear";
			this.xtraTabWorkYear.SelectedTabPage = this.WrkYr1;
			this.xtraTabWorkYear.Size = new System.Drawing.Size(846, 234);
			this.xtraTabWorkYear.TabIndex = 0;
			this.xtraTabWorkYear.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
																							this.WrkYr1,
																							this.WrkYr2,
																							this.WrkYr3,
																							this.WrkYr4,
																							this.WrkYr5});
			this.xtraTabWorkYear.Text = "LeaveWorkYearControl";
			// 
			// WrkYr1
			// 
			this.WrkYr1.Controls.Add(this.gridWrkYr1);
			this.WrkYr1.Name = "WrkYr1";
			this.WrkYr1.Size = new System.Drawing.Size(840, 208);
			this.WrkYr1.Text = "Group 1";
			// 
			// gridWrkYr1
			// 
			this.gridWrkYr1.Dock = System.Windows.Forms.DockStyle.Top;
			// 
			// gridWrkYr1.EmbeddedNavigator
			// 
			this.gridWrkYr1.EmbeddedNavigator.Name = "";
			this.gridWrkYr1.Location = new System.Drawing.Point(0, 0);
			this.gridWrkYr1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.gridWrkYr1.LookAndFeel.UseDefaultLookAndFeel = false;
			this.gridWrkYr1.MainView = this.gridWrkYrView1;
			this.gridWrkYr1.Name = "gridWrkYr1";
			this.gridWrkYr1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																												this.lk_YearFrom,
																												this.lk_YearTo,
																												this.cmbYearFrom});
			this.gridWrkYr1.Size = new System.Drawing.Size(840, 228);
			this.gridWrkYr1.TabIndex = 21;
			this.gridWrkYr1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																									  this.gridWrkYrView1});
			// 
			// gridWrkYrView1
			// 
			this.gridWrkYrView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																								  this.gridColumn1,
																								  this.gridColumn2,
																								  this.gridColumn3});
			this.gridWrkYrView1.GridControl = this.gridWrkYr1;
			this.gridWrkYrView1.Name = "gridWrkYrView1";
			this.gridWrkYrView1.OptionsCustomization.AllowFilter = false;
			this.gridWrkYrView1.OptionsCustomization.AllowSort = false;
			this.gridWrkYrView1.OptionsView.ShowGroupPanel = false;
			this.gridWrkYrView1.LostFocus += new System.EventHandler(this.gridWrkYrView1_LostFocus);
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "Year From";
			this.gridColumn1.FieldName = "nYearID";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 0;
			// 
			// gridColumn2
			// 
			this.gridColumn2.Caption = "Year To";
			this.gridColumn2.FieldName = "nYearIDTo";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 1;
			// 
			// gridColumn3
			// 
			this.gridColumn3.Caption = "Leave Quantity";
			this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumn3.FieldName = "nLeaveQty";
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 2;
			this.gridColumn3.Width = 749;
			// 
			// lk_YearFrom
			// 
			this.lk_YearFrom.AutoHeight = false;
			this.lk_YearFrom.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																									 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lk_YearFrom.Name = "lk_YearFrom";
			// 
			// lk_YearTo
			// 
			this.lk_YearTo.AutoHeight = false;
			this.lk_YearTo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																								   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lk_YearTo.Items.AddRange(new object[] {
														   "2000",
														   "2001",
														   "2002",
														   "2003",
														   "2004",
														   "2005",
														   "2006",
														   "2007",
														   "2008",
														   "2009",
														   "2010",
														   "2011",
														   "2012",
														   "2013",
														   "2014",
														   "2015",
														   "2016",
														   "2017",
														   "2018",
														   "2019",
														   "2020",
														   "2021",
														   "2022",
														   "2023",
														   "2024",
														   "2025",
														   "2026",
														   "2027",
														   "2028",
														   "2029",
														   "2030"});
			this.lk_YearTo.Name = "lk_YearTo";
			// 
			// cmbYearFrom
			// 
			this.cmbYearFrom.AutoHeight = false;
			this.cmbYearFrom.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																									 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cmbYearFrom.Items.AddRange(new object[] {
															 "2000",
															 "2001",
															 "2002",
															 "2003",
															 "2004",
															 "2005",
															 "2006",
															 "2007",
															 "2008",
															 "2009",
															 "2010",
															 "2011",
															 "2012",
															 "2013",
															 "2014",
															 "2015",
															 "2016",
															 "2017",
															 "2018",
															 "2019",
															 "2020",
															 "2021",
															 "2022",
															 "2023",
															 "2024",
															 "2025",
															 "2026",
															 "2027",
															 "2028",
															 "2029",
															 "2030"});
			this.cmbYearFrom.Name = "cmbYearFrom";
			// 
			// WrkYr2
			// 
			this.WrkYr2.Controls.Add(this.gridWrkYr2);
			this.WrkYr2.Name = "WrkYr2";
			this.WrkYr2.Size = new System.Drawing.Size(840, 208);
			this.WrkYr2.Text = "Group 2";
			// 
			// gridWrkYr2
			// 
			this.gridWrkYr2.Dock = System.Windows.Forms.DockStyle.Top;
			// 
			// gridWrkYr2.EmbeddedNavigator
			// 
			this.gridWrkYr2.EmbeddedNavigator.Name = "";
			this.gridWrkYr2.Location = new System.Drawing.Point(0, 0);
			this.gridWrkYr2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.gridWrkYr2.LookAndFeel.UseDefaultLookAndFeel = false;
			this.gridWrkYr2.MainView = this.gridWrkYrView2;
			this.gridWrkYr2.Name = "gridWrkYr2";
			this.gridWrkYr2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																												this.repositoryItemComboBox1,
																												this.repositoryItemComboBox2,
																												this.repositoryItemComboBox3});
			this.gridWrkYr2.Size = new System.Drawing.Size(840, 208);
			this.gridWrkYr2.TabIndex = 22;
			this.gridWrkYr2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																									  this.gridWrkYrView2});
			// 
			// gridWrkYrView2
			// 
			this.gridWrkYrView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																								  this.gridColumn4,
																								  this.gridColumn5,
																								  this.gridColumn6});
			this.gridWrkYrView2.GridControl = this.gridWrkYr2;
			this.gridWrkYrView2.Name = "gridWrkYrView2";
			this.gridWrkYrView2.OptionsCustomization.AllowFilter = false;
			this.gridWrkYrView2.OptionsCustomization.AllowSort = false;
			this.gridWrkYrView2.OptionsView.ShowGroupPanel = false;
			this.gridWrkYrView2.LostFocus += new System.EventHandler(this.gridWrkYrView2_LostFocus);
			// 
			// gridColumn4
			// 
			this.gridColumn4.Caption = "Year From";
			this.gridColumn4.FieldName = "nYearID";
			this.gridColumn4.Name = "gridColumn4";
			this.gridColumn4.Visible = true;
			this.gridColumn4.VisibleIndex = 0;
			// 
			// gridColumn5
			// 
			this.gridColumn5.Caption = "Year To";
			this.gridColumn5.FieldName = "nYearIDTo";
			this.gridColumn5.Name = "gridColumn5";
			this.gridColumn5.Visible = true;
			this.gridColumn5.VisibleIndex = 1;
			// 
			// gridColumn6
			// 
			this.gridColumn6.Caption = "Leave Quantity";
			this.gridColumn6.FieldName = "nLeaveQty";
			this.gridColumn6.Name = "gridColumn6";
			this.gridColumn6.Visible = true;
			this.gridColumn6.VisibleIndex = 2;
			this.gridColumn6.Width = 749;
			// 
			// repositoryItemComboBox1
			// 
			this.repositoryItemComboBox1.AutoHeight = false;
			this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
			// 
			// repositoryItemComboBox2
			// 
			this.repositoryItemComboBox2.AutoHeight = false;
			this.repositoryItemComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemComboBox2.Items.AddRange(new object[] {
																		 "2000",
																		 "2001",
																		 "2002",
																		 "2003",
																		 "2004",
																		 "2005",
																		 "2006",
																		 "2007",
																		 "2008",
																		 "2009",
																		 "2010",
																		 "2011",
																		 "2012",
																		 "2013",
																		 "2014",
																		 "2015",
																		 "2016",
																		 "2017",
																		 "2018",
																		 "2019",
																		 "2020",
																		 "2021",
																		 "2022",
																		 "2023",
																		 "2024",
																		 "2025",
																		 "2026",
																		 "2027",
																		 "2028",
																		 "2029",
																		 "2030"});
			this.repositoryItemComboBox2.Name = "repositoryItemComboBox2";
			// 
			// repositoryItemComboBox3
			// 
			this.repositoryItemComboBox3.AutoHeight = false;
			this.repositoryItemComboBox3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemComboBox3.Items.AddRange(new object[] {
																		 "2000",
																		 "2001",
																		 "2002",
																		 "2003",
																		 "2004",
																		 "2005",
																		 "2006",
																		 "2007",
																		 "2008",
																		 "2009",
																		 "2010",
																		 "2011",
																		 "2012",
																		 "2013",
																		 "2014",
																		 "2015",
																		 "2016",
																		 "2017",
																		 "2018",
																		 "2019",
																		 "2020",
																		 "2021",
																		 "2022",
																		 "2023",
																		 "2024",
																		 "2025",
																		 "2026",
																		 "2027",
																		 "2028",
																		 "2029",
																		 "2030"});
			this.repositoryItemComboBox3.Name = "repositoryItemComboBox3";
			// 
			// WrkYr3
			// 
			this.WrkYr3.Controls.Add(this.gridWrkYr3);
			this.WrkYr3.Name = "WrkYr3";
			this.WrkYr3.Size = new System.Drawing.Size(840, 208);
			this.WrkYr3.Text = "Group 3";
			// 
			// gridWrkYr3
			// 
			this.gridWrkYr3.Dock = System.Windows.Forms.DockStyle.Top;
			// 
			// gridWrkYr3.EmbeddedNavigator
			// 
			this.gridWrkYr3.EmbeddedNavigator.Name = "";
			this.gridWrkYr3.Location = new System.Drawing.Point(0, 0);
			this.gridWrkYr3.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.gridWrkYr3.LookAndFeel.UseDefaultLookAndFeel = false;
			this.gridWrkYr3.MainView = this.gridWrkYrView3;
			this.gridWrkYr3.Name = "gridWrkYr3";
			this.gridWrkYr3.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																												this.repositoryItemComboBox4,
																												this.repositoryItemComboBox5,
																												this.repositoryItemComboBox6});
			this.gridWrkYr3.Size = new System.Drawing.Size(840, 228);
			this.gridWrkYr3.TabIndex = 22;
			this.gridWrkYr3.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																									  this.gridWrkYrView3});
			// 
			// gridWrkYrView3
			// 
			this.gridWrkYrView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																								  this.gridColumn7,
																								  this.gridColumn8,
																								  this.gridColumn9});
			this.gridWrkYrView3.GridControl = this.gridWrkYr3;
			this.gridWrkYrView3.Name = "gridWrkYrView3";
			this.gridWrkYrView3.OptionsCustomization.AllowFilter = false;
			this.gridWrkYrView3.OptionsCustomization.AllowSort = false;
			this.gridWrkYrView3.OptionsView.ShowGroupPanel = false;
			this.gridWrkYrView3.LostFocus += new System.EventHandler(this.gridWrkYrView3_LostFocus);
			// 
			// gridColumn7
			// 
			this.gridColumn7.Caption = "Year From";
			this.gridColumn7.FieldName = "nYearID";
			this.gridColumn7.Name = "gridColumn7";
			this.gridColumn7.Visible = true;
			this.gridColumn7.VisibleIndex = 0;
			// 
			// gridColumn8
			// 
			this.gridColumn8.Caption = "Year To";
			this.gridColumn8.FieldName = "nYearIDTo";
			this.gridColumn8.Name = "gridColumn8";
			this.gridColumn8.Visible = true;
			this.gridColumn8.VisibleIndex = 1;
			// 
			// gridColumn9
			// 
			this.gridColumn9.Caption = "Leave Quantity";
			this.gridColumn9.FieldName = "nLeaveQty";
			this.gridColumn9.Name = "gridColumn9";
			this.gridColumn9.Visible = true;
			this.gridColumn9.VisibleIndex = 2;
			this.gridColumn9.Width = 749;
			// 
			// repositoryItemComboBox4
			// 
			this.repositoryItemComboBox4.AutoHeight = false;
			this.repositoryItemComboBox4.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemComboBox4.Name = "repositoryItemComboBox4";
			// 
			// repositoryItemComboBox5
			// 
			this.repositoryItemComboBox5.AutoHeight = false;
			this.repositoryItemComboBox5.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemComboBox5.Items.AddRange(new object[] {
																		 "2000",
																		 "2001",
																		 "2002",
																		 "2003",
																		 "2004",
																		 "2005",
																		 "2006",
																		 "2007",
																		 "2008",
																		 "2009",
																		 "2010",
																		 "2011",
																		 "2012",
																		 "2013",
																		 "2014",
																		 "2015",
																		 "2016",
																		 "2017",
																		 "2018",
																		 "2019",
																		 "2020",
																		 "2021",
																		 "2022",
																		 "2023",
																		 "2024",
																		 "2025",
																		 "2026",
																		 "2027",
																		 "2028",
																		 "2029",
																		 "2030"});
			this.repositoryItemComboBox5.Name = "repositoryItemComboBox5";
			// 
			// repositoryItemComboBox6
			// 
			this.repositoryItemComboBox6.AutoHeight = false;
			this.repositoryItemComboBox6.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemComboBox6.Items.AddRange(new object[] {
																		 "2000",
																		 "2001",
																		 "2002",
																		 "2003",
																		 "2004",
																		 "2005",
																		 "2006",
																		 "2007",
																		 "2008",
																		 "2009",
																		 "2010",
																		 "2011",
																		 "2012",
																		 "2013",
																		 "2014",
																		 "2015",
																		 "2016",
																		 "2017",
																		 "2018",
																		 "2019",
																		 "2020",
																		 "2021",
																		 "2022",
																		 "2023",
																		 "2024",
																		 "2025",
																		 "2026",
																		 "2027",
																		 "2028",
																		 "2029",
																		 "2030"});
			this.repositoryItemComboBox6.Name = "repositoryItemComboBox6";
			// 
			// WrkYr4
			// 
			this.WrkYr4.Controls.Add(this.gridWrkYr4);
			this.WrkYr4.Name = "WrkYr4";
			this.WrkYr4.Size = new System.Drawing.Size(840, 208);
			this.WrkYr4.Text = "Group 4";
			// 
			// gridWrkYr4
			// 
			this.gridWrkYr4.Dock = System.Windows.Forms.DockStyle.Top;
			// 
			// gridWrkYr4.EmbeddedNavigator
			// 
			this.gridWrkYr4.EmbeddedNavigator.Name = "";
			this.gridWrkYr4.Location = new System.Drawing.Point(0, 0);
			this.gridWrkYr4.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.gridWrkYr4.LookAndFeel.UseDefaultLookAndFeel = false;
			this.gridWrkYr4.MainView = this.gridWrkYrView4;
			this.gridWrkYr4.Name = "gridWrkYr4";
			this.gridWrkYr4.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																												this.repositoryItemComboBox7,
																												this.repositoryItemComboBox8,
																												this.repositoryItemComboBox9});
			this.gridWrkYr4.Size = new System.Drawing.Size(840, 228);
			this.gridWrkYr4.TabIndex = 22;
			this.gridWrkYr4.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																									  this.gridWrkYrView4});
			// 
			// gridWrkYrView4
			// 
			this.gridWrkYrView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																								  this.gridColumn10,
																								  this.gridColumn11,
																								  this.gridColumn12});
			this.gridWrkYrView4.GridControl = this.gridWrkYr4;
			this.gridWrkYrView4.Name = "gridWrkYrView4";
			this.gridWrkYrView4.OptionsCustomization.AllowFilter = false;
			this.gridWrkYrView4.OptionsCustomization.AllowSort = false;
			this.gridWrkYrView4.OptionsView.ShowGroupPanel = false;
			this.gridWrkYrView4.LostFocus += new System.EventHandler(this.gridWrkYrView4_LostFocus);
			// 
			// gridColumn10
			// 
			this.gridColumn10.Caption = "Year From";
			this.gridColumn10.FieldName = "nYearID";
			this.gridColumn10.Name = "gridColumn10";
			this.gridColumn10.Visible = true;
			this.gridColumn10.VisibleIndex = 0;
			// 
			// gridColumn11
			// 
			this.gridColumn11.Caption = "Year To";
			this.gridColumn11.FieldName = "nYearIDTo";
			this.gridColumn11.Name = "gridColumn11";
			this.gridColumn11.Visible = true;
			this.gridColumn11.VisibleIndex = 1;
			// 
			// gridColumn12
			// 
			this.gridColumn12.Caption = "Leave Quantity";
			this.gridColumn12.FieldName = "nLeaveQty";
			this.gridColumn12.Name = "gridColumn12";
			this.gridColumn12.Visible = true;
			this.gridColumn12.VisibleIndex = 2;
			this.gridColumn12.Width = 749;
			// 
			// repositoryItemComboBox7
			// 
			this.repositoryItemComboBox7.AutoHeight = false;
			this.repositoryItemComboBox7.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemComboBox7.Name = "repositoryItemComboBox7";
			// 
			// repositoryItemComboBox8
			// 
			this.repositoryItemComboBox8.AutoHeight = false;
			this.repositoryItemComboBox8.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemComboBox8.Items.AddRange(new object[] {
																		 "2000",
																		 "2001",
																		 "2002",
																		 "2003",
																		 "2004",
																		 "2005",
																		 "2006",
																		 "2007",
																		 "2008",
																		 "2009",
																		 "2010",
																		 "2011",
																		 "2012",
																		 "2013",
																		 "2014",
																		 "2015",
																		 "2016",
																		 "2017",
																		 "2018",
																		 "2019",
																		 "2020",
																		 "2021",
																		 "2022",
																		 "2023",
																		 "2024",
																		 "2025",
																		 "2026",
																		 "2027",
																		 "2028",
																		 "2029",
																		 "2030"});
			this.repositoryItemComboBox8.Name = "repositoryItemComboBox8";
			// 
			// repositoryItemComboBox9
			// 
			this.repositoryItemComboBox9.AutoHeight = false;
			this.repositoryItemComboBox9.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemComboBox9.Items.AddRange(new object[] {
																		 "2000",
																		 "2001",
																		 "2002",
																		 "2003",
																		 "2004",
																		 "2005",
																		 "2006",
																		 "2007",
																		 "2008",
																		 "2009",
																		 "2010",
																		 "2011",
																		 "2012",
																		 "2013",
																		 "2014",
																		 "2015",
																		 "2016",
																		 "2017",
																		 "2018",
																		 "2019",
																		 "2020",
																		 "2021",
																		 "2022",
																		 "2023",
																		 "2024",
																		 "2025",
																		 "2026",
																		 "2027",
																		 "2028",
																		 "2029",
																		 "2030"});
			this.repositoryItemComboBox9.Name = "repositoryItemComboBox9";
			// 
			// WrkYr5
			// 
			this.WrkYr5.Controls.Add(this.gridWrkYr5);
			this.WrkYr5.Name = "WrkYr5";
			this.WrkYr5.Size = new System.Drawing.Size(840, 208);
			this.WrkYr5.Text = "Group 5";
			// 
			// gridWrkYr5
			// 
			this.gridWrkYr5.Dock = System.Windows.Forms.DockStyle.Top;
			// 
			// gridWrkYr5.EmbeddedNavigator
			// 
			this.gridWrkYr5.EmbeddedNavigator.Name = "";
			this.gridWrkYr5.Location = new System.Drawing.Point(0, 0);
			this.gridWrkYr5.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.gridWrkYr5.LookAndFeel.UseDefaultLookAndFeel = false;
			this.gridWrkYr5.MainView = this.gridWrkYrView5;
			this.gridWrkYr5.Name = "gridWrkYr5";
			this.gridWrkYr5.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																												this.repositoryItemComboBox10,
																												this.repositoryItemComboBox11,
																												this.repositoryItemComboBox12});
			this.gridWrkYr5.Size = new System.Drawing.Size(840, 228);
			this.gridWrkYr5.TabIndex = 22;
			this.gridWrkYr5.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																									  this.gridWrkYrView5});
			// 
			// gridWrkYrView5
			// 
			this.gridWrkYrView5.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																								  this.gridColumn13,
																								  this.gridColumn14,
																								  this.gridColumn15});
			this.gridWrkYrView5.GridControl = this.gridWrkYr5;
			this.gridWrkYrView5.Name = "gridWrkYrView5";
			this.gridWrkYrView5.OptionsCustomization.AllowFilter = false;
			this.gridWrkYrView5.OptionsCustomization.AllowSort = false;
			this.gridWrkYrView5.OptionsView.ShowGroupPanel = false;
			this.gridWrkYrView5.LostFocus += new System.EventHandler(this.gridWrkYrView5_LostFocus);
			// 
			// gridColumn13
			// 
			this.gridColumn13.Caption = "Year From";
			this.gridColumn13.FieldName = "nYearID";
			this.gridColumn13.Name = "gridColumn13";
			this.gridColumn13.Visible = true;
			this.gridColumn13.VisibleIndex = 0;
			// 
			// gridColumn14
			// 
			this.gridColumn14.Caption = "Year To";
			this.gridColumn14.FieldName = "nYearIDTo";
			this.gridColumn14.Name = "gridColumn14";
			this.gridColumn14.Visible = true;
			this.gridColumn14.VisibleIndex = 1;
			// 
			// gridColumn15
			// 
			this.gridColumn15.Caption = "Leave Quantity";
			this.gridColumn15.FieldName = "nLeaveQty";
			this.gridColumn15.Name = "gridColumn15";
			this.gridColumn15.Visible = true;
			this.gridColumn15.VisibleIndex = 2;
			this.gridColumn15.Width = 749;
			// 
			// repositoryItemComboBox10
			// 
			this.repositoryItemComboBox10.AutoHeight = false;
			this.repositoryItemComboBox10.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemComboBox10.Name = "repositoryItemComboBox10";
			// 
			// repositoryItemComboBox11
			// 
			this.repositoryItemComboBox11.AutoHeight = false;
			this.repositoryItemComboBox11.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemComboBox11.Items.AddRange(new object[] {
																		  "2000",
																		  "2001",
																		  "2002",
																		  "2003",
																		  "2004",
																		  "2005",
																		  "2006",
																		  "2007",
																		  "2008",
																		  "2009",
																		  "2010",
																		  "2011",
																		  "2012",
																		  "2013",
																		  "2014",
																		  "2015",
																		  "2016",
																		  "2017",
																		  "2018",
																		  "2019",
																		  "2020",
																		  "2021",
																		  "2022",
																		  "2023",
																		  "2024",
																		  "2025",
																		  "2026",
																		  "2027",
																		  "2028",
																		  "2029",
																		  "2030"});
			this.repositoryItemComboBox11.Name = "repositoryItemComboBox11";
			// 
			// repositoryItemComboBox12
			// 
			this.repositoryItemComboBox12.AutoHeight = false;
			this.repositoryItemComboBox12.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemComboBox12.Items.AddRange(new object[] {
																		  "2000",
																		  "2001",
																		  "2002",
																		  "2003",
																		  "2004",
																		  "2005",
																		  "2006",
																		  "2007",
																		  "2008",
																		  "2009",
																		  "2010",
																		  "2011",
																		  "2012",
																		  "2013",
																		  "2014",
																		  "2015",
																		  "2016",
																		  "2017",
																		  "2018",
																		  "2019",
																		  "2020",
																		  "2021",
																		  "2022",
																		  "2023",
																		  "2024",
																		  "2025",
																		  "2026",
																		  "2027",
																		  "2028",
																		  "2029",
																		  "2030"});
			this.repositoryItemComboBox12.Name = "repositoryItemComboBox12";
			// 
			// btnLeave_Del
			// 
			this.btnLeave_Del.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnLeave_Del.Appearance.Options.UseFont = true;
			this.btnLeave_Del.Appearance.Options.UseTextOptions = true;
			this.btnLeave_Del.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.btnLeave_Del.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
			this.btnLeave_Del.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.btnLeave_Del.ImageIndex = 1;
			this.btnLeave_Del.ImageList = this.imageList1;
			this.btnLeave_Del.Location = new System.Drawing.Point(48, 248);
			this.btnLeave_Del.Name = "btnLeave_Del";
			this.btnLeave_Del.Size = new System.Drawing.Size(38, 16);
			this.btnLeave_Del.TabIndex = 133;
			this.btnLeave_Del.Click += new System.EventHandler(this.btnLeave_Del_Click);
			// 
			// btnLeave_Add
			// 
			this.btnLeave_Add.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnLeave_Add.Appearance.Options.UseFont = true;
			this.btnLeave_Add.Appearance.Options.UseTextOptions = true;
			this.btnLeave_Add.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.btnLeave_Add.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
			this.btnLeave_Add.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.btnLeave_Add.ImageIndex = 0;
			this.btnLeave_Add.ImageList = this.imageList1;
			this.btnLeave_Add.ImeMode = System.Windows.Forms.ImeMode.On;
			this.btnLeave_Add.Location = new System.Drawing.Point(8, 248);
			this.btnLeave_Add.Name = "btnLeave_Add";
			this.btnLeave_Add.Size = new System.Drawing.Size(38, 16);
			this.btnLeave_Add.TabIndex = 134;
			this.btnLeave_Add.Click += new System.EventHandler(this.btnLeave_Add_Click);
			// 
			// frmLeave
			// 
			this.AutoScale = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(984, 535);
			this.Controls.Add(this.grpMDLeaveTop);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmLeave";
			this.Text = "frmLeave";
			this.Load += new System.EventHandler(this.frmLeave_Load);
			((System.ComponentModel.ISupportInitialize)(this.grpMDLeaveTop)).EndInit();
			this.grpMDLeaveTop.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
			this.groupControl2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
			this.groupControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.xtraTabWorkYear)).EndInit();
			this.xtraTabWorkYear.ResumeLayout(false);
			this.WrkYr1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridWrkYr1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridWrkYrView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_YearFrom)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_YearTo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbYearFrom)).EndInit();
			this.WrkYr2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridWrkYr2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridWrkYrView2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox3)).EndInit();
			this.WrkYr3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridWrkYr3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridWrkYrView3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox6)).EndInit();
			this.WrkYr4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridWrkYr4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridWrkYrView4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox7)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox8)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox9)).EndInit();
			this.WrkYr5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridWrkYr5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridWrkYrView5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox10)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox11)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox12)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region init
	
		private void mdLeaveTypeInit()
		{
			string strSQL;
			strSQL = "select * from tblLeaveType";
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dtLeaveType = _ds.Tables["table"];
			gridControl1.DataSource = dtLeaveType;
		}

		private DataTable dtLeave1;
		private DataTable dtLeave2;
		private DataTable dtLeave3;
		private DataTable dtLeave4;
		private DataTable dtLeave5;

		private void mdLeaveWrkYearInit()
		{
			string strSQL;
			DataSet _ds;
			 _ds = new DataSet();
			
			strSQL = "select * from tblLeaveWorkYear where nWrkYrGroupID=1 ";
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dtLeave1 = _ds.Tables["table"];
			gridWrkYr1.DataSource = dtLeave1;

			_ds = new DataSet();
			strSQL = "select * from tblLeaveWorkYear where nWrkYrGroupID=2 ";
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dtLeave2 = _ds.Tables["table"];
			gridWrkYr2.DataSource = dtLeave2;

			_ds = new DataSet();
			strSQL = "select * from tblLeaveWorkYear where nWrkYrGroupID=3 ";
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dtLeave3 = _ds.Tables["table"];
			gridWrkYr3.DataSource = dtLeave3;

			_ds = new DataSet();
			strSQL = "select * from tblLeaveWorkYear where nWrkYrGroupID=4 ";
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dtLeave4 = _ds.Tables["table"];
			gridWrkYr4.DataSource = dtLeave4;

			_ds = new DataSet();
			strSQL = "select * from tblLeaveWorkYear where nWrkYrGroupID=5 ";
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dtLeave5 = _ds.Tables["table"];
			gridWrkYr5.DataSource = dtLeave5;
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
		
		public void CreateCmdsAndUpdate(string mySelectQuery,DataTable myTableName) 
		{
			SqlConnection myConn = new SqlConnection(connectionString);
			SqlDataAdapter myDataAdapter = new SqlDataAdapter();
			myDataAdapter.SelectCommand=new SqlCommand(mySelectQuery, myConn);
			SqlCommandBuilder custCB = new SqlCommandBuilder(myDataAdapter);

			myConn.Open();
			DataSet custDS = new DataSet();
			myDataAdapter.Fill(custDS);

			//code to modify data in dataset here
			myDataAdapter.Update(myTableName);
			myConn.Close();
		}

		#endregion
		

		private void frmLeave_Load(object sender, System.EventArgs e)
		{
			mdLeaveTypeInit();
			mdLeaveWrkYearInit();
		}

		private bool CheckClassTypeField(DataRow dr)
		{
			if (dr["strLeaveCode"].ToString() == "")
				return false;

			return true;
		}
		
		private bool CheckClassField(DataRow dr)
		{
			if (dr["nYearID"].ToString() == "" || dr["nWrkYrGroupID"].ToString()=="" || dr["nLeaveQty"].ToString()=="")
				return false;

			return true;
		}

		private bool AddNew = false;
		private void btn_Add_Click(object sender, System.EventArgs e)
		{
			AddNew = true;
			DataRow dr = dtLeaveType.NewRow();
			dtLeaveType.Rows.Add(dr);
			this.gridControl1.Refresh();
			this.gridView1.FocusedRowHandle = dtLeaveType.Rows.Count - 1;
		}

		private void btn_Del_Click(object sender, System.EventArgs e)
		{
			DataRow row = this.gridView1.GetDataRow(gridView1.FocusedRowHandle);
			if (row != null)
			{
				if (AddNew)
				{
					AddNew = false;
					gridView1.DeleteRow(gridView1.FocusedRowHandle);
				}
				else
				{

					DialogResult result = MessageBox.Show(this, "Do you really want to delete record with Leave Code = " + row["strLeaveCode"].ToString(),
						"Delete?", MessageBoxButtons.YesNo);
					if (result == DialogResult.Yes)
					{
						try
						{
							SqlHelper.ExecuteNonQuery(connection,"del_LeaveType",
								new SqlParameter("@strClassCode",row["strLeaveCode"].ToString() )
								);
						}
						catch(Exception ex)
						{
							MessageBox.Show(ex.Message ,"Delete Process Failed");
							return;
						}
						MessageBox.Show("Record Deleted Successfully","Message");
					}
					mdLeaveTypeInit();
				}
			}
		}
		private bool AddNewLeave;
		private void btnLeave_Add_Click(object sender, System.EventArgs e)
		{
			if (xtraTabWorkYear.SelectedTabPage.Text == "Group 1")
			{
				AddNewLeave = true;
				DataRow dr = dtLeave1.NewRow();
				dtLeave1.Rows.Add(dr);
				this.gridWrkYr1.Refresh();
				this.gridWrkYrView1.FocusedRowHandle = dtLeave1.Rows.Count - 1;
				return;
			}
			else if (xtraTabWorkYear.SelectedTabPage.Text == "Group 2")
			{
				AddNewLeave = true;
				DataRow dr = dtLeave2.NewRow();
				dtLeave2.Rows.Add(dr);
				this.gridWrkYr2.Refresh();
				this.gridWrkYrView2.FocusedRowHandle = dtLeave2.Rows.Count - 1;
				return;
			}
			else if (xtraTabWorkYear.SelectedTabPage.Text == "Group 3")
			{
				AddNewLeave = true;
				DataRow dr = dtLeave3.NewRow();
				dtLeave3.Rows.Add(dr);
				this.gridWrkYr3.Refresh();
				this.gridWrkYrView3.FocusedRowHandle = dtLeave3.Rows.Count - 1;
				return;
			}
			else if (xtraTabWorkYear.SelectedTabPage.Text == "Group 4")
			{
				AddNewLeave = true;
				DataRow dr = dtLeave4.NewRow();
				dtLeave4.Rows.Add(dr);
				this.gridWrkYr4.Refresh();
				this.gridWrkYrView4.FocusedRowHandle = dtLeave4.Rows.Count - 1;
				return;
			}
			else if (xtraTabWorkYear.SelectedTabPage.Text == "Group 5")
			{
				AddNewLeave = true;
				DataRow dr = dtLeave5.NewRow();
				dtLeave5.Rows.Add(dr);
				this.gridWrkYr5.Refresh();
				this.gridWrkYrView5.FocusedRowHandle = dtLeave5.Rows.Count - 1;
				return;
			}
		}

		private void btnLeave_Del_Click(object sender, System.EventArgs e)
		{
			if (xtraTabWorkYear.SelectedTabPage.Text == "Group 1")
			{
				DataRow row = this.gridWrkYrView1.GetDataRow(gridWrkYrView1.FocusedRowHandle);
				if (row != null)
				{
					if (AddNewLeave)
					{
						AddNewLeave = false;
						gridWrkYrView1.DeleteRow(gridWrkYrView1.FocusedRowHandle);
					}
					else
					{

						DialogResult result = MessageBox.Show(this, "Do you really want to delete record with Year = " + row["nYearID"].ToString(),
							"Delete?", MessageBoxButtons.YesNo);
						if (result == DialogResult.Yes)
						{
							try
							{
								SqlHelper.ExecuteNonQuery(connection,"del_LeaveWorkYear",
									new SqlParameter("@nWrkYrGroupID",row["nWrkYrGroupID"].ToString()),
									new SqlParameter("@nYearID",row["nYearID"].ToString())
									);
							}
							catch(Exception ex)
							{
								MessageBox.Show(ex.Message ,"Delete Process Failed");
								return;
							}
							MessageBox.Show("Record Deleted Successfully","Message");
						}
						mdLeaveWrkYearInit();
					}
				}
			}
			else if (xtraTabWorkYear.SelectedTabPage.Text == "Group 2")
			{
				DataRow row = this.gridWrkYrView2.GetDataRow(gridWrkYrView2.FocusedRowHandle);
				if (row != null)
				{
					if (AddNewLeave)
					{
						AddNewLeave = false;
						gridWrkYrView2.DeleteRow(gridWrkYrView2.FocusedRowHandle);
					}
					else
					{

						DialogResult result = MessageBox.Show(this, "Do you really want to delete record with Year = " + row["nYearID"].ToString(),
							"Delete?", MessageBoxButtons.YesNo);
						if (result == DialogResult.Yes)
						{
							try
							{
								SqlHelper.ExecuteNonQuery(connection,"del_LeaveWorkYear",
									new SqlParameter("@nWrkYrGroupID",row["nWrkYrGroupID"].ToString()),
									new SqlParameter("@nYearID",row["nYearID"].ToString())
									);
							}
							catch(Exception ex)
							{
								MessageBox.Show(ex.Message ,"Delete Process Failed");
								return;
							}
							MessageBox.Show("Record Deleted Successfully","Message");
						}
						mdLeaveWrkYearInit();
					}
				}
			}
			else if (xtraTabWorkYear.SelectedTabPage.Text == "Group 3")
			{
				DataRow row = this.gridWrkYrView3.GetDataRow(gridWrkYrView3.FocusedRowHandle);
				if (row != null)
				{
					if (AddNewLeave)
					{
						AddNewLeave = false;
						gridWrkYrView3.DeleteRow(gridWrkYrView3.FocusedRowHandle);
					}
					else
					{

						DialogResult result = MessageBox.Show(this, "Do you really want to delete record with Year = " + row["nYearID"].ToString(),
							"Delete?", MessageBoxButtons.YesNo);
						if (result == DialogResult.Yes)
						{
							try
							{
								SqlHelper.ExecuteNonQuery(connection,"del_LeaveWorkYear",
									new SqlParameter("@nWrkYrGroupID",row["nWrkYrGroupID"].ToString()),
									new SqlParameter("@nYearID",row["nYearID"].ToString())
									);
							}
							catch(Exception ex)
							{
								MessageBox.Show(ex.Message ,"Delete Process Failed");
								return;
							}
							MessageBox.Show("Record Deleted Successfully","Message");
						}
						mdLeaveWrkYearInit();
					}
				}
			}

			else if (xtraTabWorkYear.SelectedTabPage.Text == "Group 4")
			{
				DataRow row = this.gridWrkYrView4.GetDataRow(gridWrkYrView4.FocusedRowHandle);
				if (row != null)
				{
					if (AddNewLeave)
					{
						AddNewLeave = false;
						gridWrkYrView4.DeleteRow(gridWrkYrView4.FocusedRowHandle);
					}
					else
					{

						DialogResult result = MessageBox.Show(this, "Do you really want to delete record with Year = " + row["nYearID"].ToString(),
							"Delete?", MessageBoxButtons.YesNo);
						if (result == DialogResult.Yes)
						{
							try
							{
								SqlHelper.ExecuteNonQuery(connection,"del_LeaveWorkYear",
									new SqlParameter("@nWrkYrGroupID",row["nWrkYrGroupID"].ToString()),
									new SqlParameter("@nYearID",row["nYearID"].ToString())
									);
							}
							catch(Exception ex)
							{
								MessageBox.Show(ex.Message ,"Delete Process Failed");
								return;
							}
							MessageBox.Show("Record Deleted Successfully","Message");
						}
						mdLeaveWrkYearInit();
					}
				}
			}
			else if (xtraTabWorkYear.SelectedTabPage.Text == "Group 5")
			{
				DataRow row = this.gridWrkYrView5.GetDataRow(gridWrkYrView5.FocusedRowHandle);
				if (row != null)
				{
					if (AddNewLeave)
					{
						AddNewLeave = false;
						gridWrkYrView5.DeleteRow(gridWrkYrView5.FocusedRowHandle);
					}
					else
					{

						DialogResult result = MessageBox.Show(this, "Do you really want to delete record with Year = " + row["nYearID"].ToString(),
							"Delete?", MessageBoxButtons.YesNo);
						if (result == DialogResult.Yes)
						{
							try
							{
								SqlHelper.ExecuteNonQuery(connection,"del_LeaveWorkYear",
									new SqlParameter("@nWrkYrGroupID",row["nWrkYrGroupID"].ToString()),
									new SqlParameter("@nYearID",row["nYearID"].ToString())
									);
							}
							catch(Exception ex)
							{
								MessageBox.Show(ex.Message ,"Delete Process Failed");
								return;
							}
							MessageBox.Show("Record Deleted Successfully","Message");
						}
						mdLeaveWrkYearInit();
					}
				}
			}
		}
		private void gridView1_LostFocus(object sender, System.EventArgs e)
		{
			DataRow row = this.gridView1.GetDataRow(gridView1.FocusedRowHandle);
			
			string strSQL = "Select * from TblLeaveType";
			if (AddNew)
			{
				if( CheckClassTypeField(row))
				{
					this.gridControl1.MainView.UpdateCurrentRow();
					try
					{
						CreateCmdsAndUpdate(strSQL,dtLeaveType);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message ,"Delete Process Failed");
						return;
					}
					AddNew = false;
				}
			}
			else
			{
				this.gridView1.CloseEditor();
				gridView1.UpdateCurrentRow();

				CreateCmdsAndUpdate(strSQL,dtLeaveType);
			}
		}

		private void gridWrkYrView1_LostFocus(object sender, System.EventArgs e)
		{
			DataRow row = this.gridWrkYrView1.GetDataRow(gridWrkYrView1.FocusedRowHandle);
			
			string strSQL = "select * from tblLeaveWorkYear where nWrkYrGroupID=1";
			if (AddNewLeave)
			{
				row[0]=1;
				if( CheckClassField(row))
				{
					this.gridWrkYr1.MainView.UpdateCurrentRow();
					try
					{
						CreateCmdsAndUpdate(strSQL,dtLeave1);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message ,"Delete Process Failed");
						return;
					}
					AddNewLeave = false;
				}
			}
			else
			{
				gridWrkYrView1.CloseEditor();
				gridWrkYrView1.UpdateCurrentRow();

				CreateCmdsAndUpdate(strSQL,dtLeave1);
			}
		}


		private void gridWrkYrView2_LostFocus(object sender, System.EventArgs e)
		{
			DataRow row = this.gridWrkYrView2.GetDataRow(gridWrkYrView2.FocusedRowHandle);
			
			string strSQL = "select * from tblLeaveWorkYear where nWrkYrGroupID=2";
			if (AddNewLeave)
			{
				row[0]=2;
				if( CheckClassField(row))
				{
				
					this.gridWrkYr2.MainView.UpdateCurrentRow();
					try
					{
						CreateCmdsAndUpdate(strSQL,dtLeave2);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message ,"Delete Process Failed");
						return;
					}
					AddNewLeave = false;
				}
			}
			else
			{
				gridWrkYrView2.CloseEditor();
				gridWrkYrView2.UpdateCurrentRow();

				CreateCmdsAndUpdate(strSQL,dtLeave2);
			}
		}


		private void gridWrkYrView3_LostFocus(object sender, System.EventArgs e)
		{
			DataRow row = this.gridWrkYrView3.GetDataRow(gridWrkYrView3.FocusedRowHandle);
			
			string strSQL = "select * from tblLeaveWorkYear where nWrkYrGroupID=3";
			if (AddNewLeave)
			{
				row[0]=3;

				if( CheckClassField(row))
				{
					this.gridWrkYr3.MainView.UpdateCurrentRow();
					try
					{
						CreateCmdsAndUpdate(strSQL,dtLeave3);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message ,"Delete Process Failed");
						return;
					}
					AddNewLeave = false;
				}
			}
			else
			{
				gridWrkYrView3.CloseEditor();
				gridWrkYrView3.UpdateCurrentRow();

				CreateCmdsAndUpdate(strSQL,dtLeave3);
			}
		}

		private void gridWrkYrView4_LostFocus(object sender, System.EventArgs e)
		{
			DataRow row = this.gridWrkYrView4.GetDataRow(gridWrkYrView4.FocusedRowHandle);
			
			string strSQL = "select * from tblLeaveWorkYear where nWrkYrGroupID=4";
			if (AddNewLeave)
			{
				row[0]=4;
				
				if( CheckClassField(row))
				{
	
					this.gridWrkYr4.MainView.UpdateCurrentRow();
					try
					{
						CreateCmdsAndUpdate(strSQL,dtLeave4);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message ,"Delete Process Failed");
						return;
					}
					AddNewLeave = false;
				}
			}
			else
			{
				gridWrkYrView4.CloseEditor();
				gridWrkYrView4.UpdateCurrentRow();

				CreateCmdsAndUpdate(strSQL,dtLeave4);
			}
		}

		private void gridWrkYrView5_LostFocus(object sender, System.EventArgs e)
		{
			DataRow row = this.gridWrkYrView5.GetDataRow(gridWrkYrView5.FocusedRowHandle);
			
			string strSQL = "select * from tblLeaveWorkYear where nWrkYrGroupID=5";
			if (AddNewLeave)
			{
				row[0]=5;
				
				if( CheckClassField(row))
				{
				this.gridWrkYr5.MainView.UpdateCurrentRow();
					try
					{
						CreateCmdsAndUpdate(strSQL,dtLeave5);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message ,"Delete Process Failed");
						return;
					}
					AddNewLeave = false;
				}
			}
			else
			{
				gridWrkYrView5.CloseEditor();
				gridWrkYrView5.UpdateCurrentRow();

				CreateCmdsAndUpdate(strSQL,dtLeave5);
			}
		}

		
		}
	}
