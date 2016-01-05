using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;
using System.Data.OleDb;

namespace ACMS.ACMSManager.MasterData
{
	/// <summary>
	/// Summary description for frmPromotionItem.
	/// </summary>
	public class frmPromotionItem : DevExpress.XtraEditors.XtraForm
	{
		private string connectionString;
		private SqlConnection connection;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraEditors.GroupControl grpMDClass;
		internal DevExpress.XtraEditors.SimpleButton btn_Add;
		internal DevExpress.XtraEditors.SimpleButton btn_Del;
		private DevExpress.XtraEditors.GroupControl groupControl2;
		private System.Windows.Forms.ImageList imageList1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_PromotionCode;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewMd_ItemPromotion;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox lk_CategoryIDs;
		private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox lk_CategoryID;
		private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox lk_GroupID;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_Code;
		private DevExpress.XtraGrid.GridControl gridControlMd_ItemPromotion;
		private System.ComponentModel.IContainer components;
		internal DevExpress.XtraEditors.TextEdit txtSearch;
		internal DevExpress.XtraEditors.SimpleButton btn_Search;
		private DevExpress.XtraEditors.GroupControl grpMDItemPromotion;
		private DataTable dtItemPromotion;

		public frmPromotionItem()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);

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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmPromotionItem));
			this.gridViewMd_ItemPromotion = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.lk_CategoryID = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.lk_GroupID = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridControlMd_ItemPromotion = new DevExpress.XtraGrid.GridControl();
			this.lk_PromotionCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			this.lk_CategoryIDs = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.lk_Code = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			this.grpMDClass = new DevExpress.XtraEditors.GroupControl();
			this.grpMDItemPromotion = new DevExpress.XtraEditors.GroupControl();
			this.btn_Del = new DevExpress.XtraEditors.SimpleButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.btn_Add = new DevExpress.XtraEditors.SimpleButton();
			this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
			this.btn_Search = new DevExpress.XtraEditors.SimpleButton();
			this.txtSearch = new DevExpress.XtraEditors.TextEdit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewMd_ItemPromotion)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_CategoryID)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_GroupID)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControlMd_ItemPromotion)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_PromotionCode)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_CategoryIDs)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_Code)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grpMDClass)).BeginInit();
			this.grpMDClass.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grpMDItemPromotion)).BeginInit();
			this.grpMDItemPromotion.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
			this.groupControl2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// gridViewMd_ItemPromotion
			// 
			this.gridViewMd_ItemPromotion.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																											this.gridColumn3,
																											this.gridColumn4,
																											this.gridColumn1,
																											this.gridColumn2});
			this.gridViewMd_ItemPromotion.GridControl = this.gridControlMd_ItemPromotion;
			this.gridViewMd_ItemPromotion.Name = "gridViewMd_ItemPromotion";
			this.gridViewMd_ItemPromotion.OptionsBehavior.Editable = false;
			this.gridViewMd_ItemPromotion.OptionsCustomization.AllowColumnMoving = false;
			this.gridViewMd_ItemPromotion.OptionsCustomization.AllowFilter = false;
			this.gridViewMd_ItemPromotion.OptionsCustomization.AllowSort = false;
			this.gridViewMd_ItemPromotion.OptionsView.ShowGroupPanel = false;
			this.gridViewMd_ItemPromotion.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridViewMd_ItemPromotion_CellValueChanged);
			this.gridViewMd_ItemPromotion.DoubleClick += new System.EventHandler(this.gridViewMd_ItemPromotion_DoubleClick);
			this.gridViewMd_ItemPromotion.LostFocus += new System.EventHandler(this.gridViewMd_ItemPromotion_LostFocus);
			// 
			// gridColumn3
			// 
			this.gridColumn3.Caption = "Promotion Code";
			this.gridColumn3.FieldName = "strPromotionCode";
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 0;
			// 
			// gridColumn4
			// 
			this.gridColumn4.Caption = "Category Type";
			this.gridColumn4.ColumnEdit = this.lk_CategoryID;
			this.gridColumn4.FieldName = "nCategoryTypeID";
			this.gridColumn4.Name = "gridColumn4";
			this.gridColumn4.Visible = true;
			this.gridColumn4.VisibleIndex = 1;
			// 
			// lk_CategoryID
			// 
			this.lk_CategoryID.AutoHeight = false;
			this.lk_CategoryID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																									   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lk_CategoryID.Items.AddRange(new object[] {
															   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Item or Product", 1, -1),
															   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Package", 2, -1),
															   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Package Group", 3, -1),
															   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Credit Package", 4, -1)});
			this.lk_CategoryID.Name = "lk_CategoryID";
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "Group";
			this.gridColumn1.ColumnEdit = this.lk_GroupID;
			this.gridColumn1.FieldName = "nGroupID";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 2;
			// 
			// lk_GroupID
			// 
			this.lk_GroupID.AutoHeight = false;
			this.lk_GroupID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																									new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lk_GroupID.Items.AddRange(new object[] {
															new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Item", 0, -1),
															new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Group", 1, -1)});
			this.lk_GroupID.Name = "lk_GroupID";
			// 
			// gridColumn2
			// 
			this.gridColumn2.Caption = "Code";
			this.gridColumn2.FieldName = "strCode";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 3;
			// 
			// gridControlMd_ItemPromotion
			// 
			this.gridControlMd_ItemPromotion.Dock = System.Windows.Forms.DockStyle.Top;
			// 
			// gridControlMd_ItemPromotion.EmbeddedNavigator
			// 
			this.gridControlMd_ItemPromotion.EmbeddedNavigator.Name = "";
			this.gridControlMd_ItemPromotion.Location = new System.Drawing.Point(0, 0);
			this.gridControlMd_ItemPromotion.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.gridControlMd_ItemPromotion.LookAndFeel.UseDefaultLookAndFeel = false;
			this.gridControlMd_ItemPromotion.MainView = this.gridViewMd_ItemPromotion;
			this.gridControlMd_ItemPromotion.Name = "gridControlMd_ItemPromotion";
			this.gridControlMd_ItemPromotion.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																																 this.lk_PromotionCode,
																																 this.lk_CategoryIDs,
																																 this.lk_CategoryID,
																																 this.lk_GroupID,
																																 this.lk_Code});
			this.gridControlMd_ItemPromotion.Size = new System.Drawing.Size(976, 444);
			this.gridControlMd_ItemPromotion.TabIndex = 126;
			this.gridControlMd_ItemPromotion.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																													   this.gridViewMd_ItemPromotion});
			// 
			// lk_PromotionCode
			// 
			this.lk_PromotionCode.AutoHeight = false;
			this.lk_PromotionCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																										  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lk_PromotionCode.Name = "lk_PromotionCode";
			// 
			// lk_CategoryIDs
			// 
			this.lk_CategoryIDs.AutoHeight = false;
			this.lk_CategoryIDs.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																										new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lk_CategoryIDs.Name = "lk_CategoryIDs";
			// 
			// lk_Code
			// 
			this.lk_Code.AutoHeight = false;
			this.lk_Code.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																								 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lk_Code.Name = "lk_Code";
			// 
			// grpMDClass
			// 
			this.grpMDClass.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.grpMDClass.Appearance.Options.UseBackColor = true;
			this.grpMDClass.Controls.Add(this.grpMDItemPromotion);
			this.grpMDClass.ImeMode = System.Windows.Forms.ImeMode.On;
			this.grpMDClass.Location = new System.Drawing.Point(-5, -26);
			this.grpMDClass.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.grpMDClass.LookAndFeel.UseDefaultLookAndFeel = false;
			this.grpMDClass.LookAndFeel.UseWindowsXPTheme = false;
			this.grpMDClass.Name = "grpMDClass";
			this.grpMDClass.Size = new System.Drawing.Size(1021, 560);
			this.grpMDClass.TabIndex = 34;
			this.grpMDClass.Text = "Class";
			// 
			// grpMDItemPromotion
			// 
			this.grpMDItemPromotion.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.grpMDItemPromotion.Appearance.Options.UseBackColor = true;
			this.grpMDItemPromotion.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.grpMDItemPromotion.AppearanceCaption.Options.UseFont = true;
			this.grpMDItemPromotion.Controls.Add(this.btn_Del);
			this.grpMDItemPromotion.Controls.Add(this.btn_Add);
			this.grpMDItemPromotion.Controls.Add(this.groupControl2);
			this.grpMDItemPromotion.Controls.Add(this.btn_Search);
			this.grpMDItemPromotion.Controls.Add(this.txtSearch);
			this.grpMDItemPromotion.ImeMode = System.Windows.Forms.ImeMode.On;
			this.grpMDItemPromotion.Location = new System.Drawing.Point(8, 24);
			this.grpMDItemPromotion.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.grpMDItemPromotion.LookAndFeel.UseDefaultLookAndFeel = false;
			this.grpMDItemPromotion.LookAndFeel.UseWindowsXPTheme = false;
			this.grpMDItemPromotion.Name = "grpMDItemPromotion";
			this.grpMDItemPromotion.Size = new System.Drawing.Size(1000, 504);
			this.grpMDItemPromotion.TabIndex = 138;
			this.grpMDItemPromotion.Text = "Item Promotion";
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
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
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
			// groupControl2
			// 
			this.groupControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.groupControl2.Controls.Add(this.gridControlMd_ItemPromotion);
			this.groupControl2.Location = new System.Drawing.Point(8, 48);
			this.groupControl2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.groupControl2.LookAndFeel.UseDefaultLookAndFeel = false;
			this.groupControl2.LookAndFeel.UseWindowsXPTheme = false;
			this.groupControl2.Name = "groupControl2";
			this.groupControl2.Size = new System.Drawing.Size(976, 448);
			this.groupControl2.TabIndex = 128;
			this.groupControl2.Text = "Promotion Item";
			// 
			// btn_Search
			// 
			this.btn_Search.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.btn_Search.Appearance.Options.UseFont = true;
			this.btn_Search.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btn_Search.Location = new System.Drawing.Point(912, 24);
			this.btn_Search.Name = "btn_Search";
			this.btn_Search.Size = new System.Drawing.Size(56, 20);
			this.btn_Search.TabIndex = 137;
			this.btn_Search.Text = "Search";
			this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
			// 
			// txtSearch
			// 
			this.txtSearch.EditValue = "";
			this.txtSearch.Location = new System.Drawing.Point(720, 24);
			this.txtSearch.Name = "txtSearch";
			// 
			// txtSearch.Properties
			// 
			this.txtSearch.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtSearch.Properties.Appearance.Options.UseFont = true;
			this.txtSearch.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.txtSearch.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.txtSearch.Size = new System.Drawing.Size(176, 20);
			this.txtSearch.TabIndex = 136;
			this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
			// 
			// frmPromotionItem
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(1000, 509);
			this.Controls.Add(this.grpMDClass);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmPromotionItem";
			this.Text = "Promotion Item";
			this.Load += new System.EventHandler(this.frmPromotionItem_Load);
			((System.ComponentModel.ISupportInitialize)(this.gridViewMd_ItemPromotion)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_CategoryID)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_GroupID)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControlMd_ItemPromotion)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_PromotionCode)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_CategoryIDs)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_Code)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grpMDClass)).EndInit();
			this.grpMDClass.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grpMDItemPromotion)).EndInit();
			this.grpMDItemPromotion.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
			this.groupControl2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void gridViewMd_ItemPromotion_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
		{
			if (e.Column.FieldName == "nCategoryTypeID")
				BindCode(e.Value.ToString(),gridViewMd_ItemPromotion.GetRowCellValue(e.RowHandle, gridViewMd_ItemPromotion.Columns[2]).ToString());
			else if (e.Column.FieldName == "nGroupID")
				BindCode(gridViewMd_ItemPromotion.GetRowCellValue(e.RowHandle, gridViewMd_ItemPromotion.Columns["nCategoryTypeID"]).ToString(),e.Value.ToString());

		}
			
		private void frmPromotionItem_Load(object sender, System.EventArgs e)
		{
			DataSet _ds = new DataSet();
			string strSQL;

			strSQL = "select strPromotionCode, strDescription from TblPromotion";
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			DataTable dt = _ds.Tables["table"];
			
			DevExpress.XtraEditors.Controls.LookUpColumnInfo[] col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
			
			col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strPromotionCode","Code",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription","Description",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
		
			new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(this.lk_PromotionCode, dt, col, "strDescription", "strPromotionCode", "Promotion");
		
			BindGrid();
			DataRow row = this.gridViewMd_ItemPromotion.GetDataRow(gridViewMd_ItemPromotion.FocusedRowHandle);
			BindCode(row["nCategoryTypeID"].ToString(),row["nGroupID"].ToString());
		}

		private void BindGrid()
		{
			string strSQL = "select * from tblItemPromotion where strPromotionCode like '%" + txtSearch.Text + "%'";

			DataSet _ds = new DataSet();
					
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dtItemPromotion = _ds.Tables["table"];
			gridControlMd_ItemPromotion.DataSource = dtItemPromotion;	
		}

		private void BindCode(string CatID, string GroupID)
		{
			DataSet _ds = new DataSet();
			string strSQL;
			DevExpress.XtraEditors.Controls.LookUpColumnInfo[] col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
			lk_Code.DataSource = "";

			if (CatID == "1" && GroupID == "0")
			{
				strSQL = "select strProductCode as strCode, strDescription from TblProduct";
				SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
				DataTable dt = _ds.Tables["table"];
						
				col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strCode","Code",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
				col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription","Description",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
				new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(this.lk_Code, dt, col, "strDescription", "strCode", "Product");
			}
			else if (CatID == "1" && GroupID == "1")
			{
				strSQL = "select nProductTypeID as strCode, strDescription from TblProductType";
				SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
				DataTable dt = _ds.Tables["table"];
			
				col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strCode","Product Type",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
				col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription","Description",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
				new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(this.lk_Code, dt, col, "strDescription", "strCode", "Product Type");
			}
			else if (CatID == "2" && GroupID == "0")
			{
				strSQL = "select strPackageCode as strCode, strDescription From tblPackage";
				SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
				DataTable dt = _ds.Tables["table"];
			
				col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strCode","Code",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
				col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription","Description",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
				new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(this.lk_Code, dt, col, "strDescription", "strCode", "Package");
			}
			else if (CatID == "2" && GroupID == "1")
			{
				strSQL = "select nCategoryID as strCode, strDescription From tblCategory";
				SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
				DataTable dt = _ds.Tables["table"];
			
				col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strCode","Code",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
				col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription","Description",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
				new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(this.lk_Code, dt, col, "strDescription", "strCode", "Package");
			}
			else if (CatID == "3" && GroupID == "0")
			{
				strSQL = "select strPackageGroupCode as strCode, strDescription From tblpackagegroup";
				SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
				DataTable dt = _ds.Tables["table"];
			
				col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strCode","Code",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
				col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription","Description",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
				new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(this.lk_Code, dt, col, "strDescription", "strCode", "Package Group");
			}
			else if (CatID == "3" && GroupID == "1")
			{
				strSQL = "select distinct tblpackagegroup.ncategoryid as strCode, tblpackagegroup.strDescription from tblpackagegroup Inner Join TblCategory On TblCategory.nCategoryID = TblPackageGroup.nCategoryID";
				SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
				DataTable dt = _ds.Tables["table"];
			
				col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strCode","Id",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
				col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription","Description",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
				new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(this.lk_Code, dt, col, "strDescription", "strCode", "Category");
			}
			else if (CatID == "4" && GroupID == "0")
			{
				strSQL = "select strCreditPackageCode as strCode, strDescription from tblcreditpackage";
				SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
				DataTable dt = _ds.Tables["table"];
			
				col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strCode","Code",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
				col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription","Description",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
				new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(this.lk_Code, dt, col, "strDescription", "strCode", "Credit Package");
			}
			else if (CatID == "4" && GroupID == "1")
			{
				strSQL = "select distinct tblCreditPackage.ncategoryid as strCode, tblCreditPackage.strDescription from tblCreditPackage Inner Join TblCategory On TblCategory.nCategoryID = tblCreditPackage.nCategoryID";
				SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
				DataTable dt = _ds.Tables["table"];
			
				col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strCode","Id",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
				col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription","Description",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
				new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(this.lk_Code, dt, col, "strDescription", "strCode", "Category");
			}
		}
		private bool AddNewItemPromotion = false;
		private void btn_Add_Click(object sender, System.EventArgs e)
		{
//			AddNewItemPromotion = true;
//			DataRow dr = dtItemPromotion.NewRow();
//			dtItemPromotion.Rows.Add(dr);
//			this.gridControlMd_ItemPromotion.Refresh();
//			this.gridViewMd_ItemPromotion.FocusedRowHandle = dtItemPromotion.Rows.Count - 1;

			frmItem_Add myform;
			myform = new frmItem_Add();
			myform.ShowDialog();
			BindGrid();
		}

		private void btn_Del_Click(object sender, System.EventArgs e)
		{
			DataRow row = this.gridViewMd_ItemPromotion.GetDataRow(gridViewMd_ItemPromotion.FocusedRowHandle);
			if (row != null)
			{
	
				if (AddNewItemPromotion)
				{
					AddNewItemPromotion = false;
					gridViewMd_ItemPromotion.DeleteRow(gridViewMd_ItemPromotion.FocusedRowHandle);
				}
				else
				{

					DialogResult result = MessageBox.Show(this, "Do you really want to delete record with Promotion Code= " + row["strPromotionCode"].ToString(),
						"Delete?", MessageBoxButtons.YesNo);
					if (result == DialogResult.Yes)
					{
						try
						{
							SqlHelper.ExecuteNonQuery(connection,"Del_TblItemPromotion",
								new SqlParameter("@Code",row["strPromotionCode"].ToString() )
								);
						}
						catch(Exception ex)
						{
							MessageBox.Show(ex.Message ,"Delete Process Failed");
							return;
						}
						MessageBox.Show("Record Deleted.","Message");
						BindGrid();
					}
					
				}
			}
		}
		
		private bool FieldChecking(DataRow dr)
		{
			if (dr["strPromotionCode"] == null || dr["strPromotionCode"].ToString() == "")
				return false;
			if (dr["nCategoryTypeID"] == null || dr["nCategoryTypeID"].ToString() == "")
				return false;
			if (dr["nGroupID"] == null || dr["nGroupID"].ToString() == "")
				return false;
			if (dr["strCode"] == null || dr["strCode"].ToString() == "")
				return false;

			return true;
		}

		private void gridViewMd_ItemPromotion_LostFocus(object sender, System.EventArgs e)
		{
			DataRow row = this.gridViewMd_ItemPromotion.GetDataRow(gridViewMd_ItemPromotion.FocusedRowHandle);
			
			string strSQL = "Select * from TblItemPromotion";
			if (AddNewItemPromotion)
			{
				if( FieldChecking(row))
				{
					this.gridControlMd_ItemPromotion.MainView.UpdateCurrentRow();
					try
					{
						CreateCmdsAndUpdate(strSQL,dtItemPromotion);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message ,"Delete Process Failed");
						return;
					}
					AddNewItemPromotion = false;
				}
			}
			else
			{
				gridViewMd_ItemPromotion.CloseEditor();
				gridViewMd_ItemPromotion.UpdateCurrentRow();

				CreateCmdsAndUpdate(strSQL,dtItemPromotion);
			}
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

		private void gridViewMd_ItemPromotion_DoubleClick(object sender, System.EventArgs e)
		{
			DataRow row = this.gridViewMd_ItemPromotion.GetDataRow(gridViewMd_ItemPromotion.FocusedRowHandle);

			frmItem_Edit myform;
			myform = new frmItem_Edit(row["strPromotionCode"].ToString(),row["strCode"].ToString());
			myform.ShowDialog();
			BindGrid();
		}

		private void btn_Search_Click(object sender, System.EventArgs e)
		{
			BindGrid();
		}

		private void txtSearch_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btn_Search_Click(sender,e);
			}
		}


	}
}

