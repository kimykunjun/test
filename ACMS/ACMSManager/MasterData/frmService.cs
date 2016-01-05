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
	/// Summary description for frmService.
	/// </summary>
	public class frmService : System.Windows.Forms.Form
	{
				private ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder myManager;
		private DataTable dtService;
		private string _mode;
		private string connectionString;
		private SqlConnection connection;
		private DevExpress.XtraEditors.GroupControl grpMDServiceTop;
		private DevExpress.XtraGrid.GridControl gridControlMd_Service;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewMdService;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnSV1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnSV2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnSV3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnSV4;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnSV5;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnSV6;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnSV7;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnSV8;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnSV9;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnSV10;
		private System.Windows.Forms.ImageList imageList1;
		internal DevExpress.XtraEditors.SimpleButton btn_Add;
		internal DevExpress.XtraEditors.SimpleButton btn_Del;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
		private System.Windows.Forms.Panel Searchpanel;
		internal DevExpress.XtraEditors.TextEdit txtSearch;
		internal DevExpress.XtraEditors.SimpleButton btn_Search;
		private System.ComponentModel.IContainer components;

		public frmService()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmService));
			this.grpMDServiceTop = new DevExpress.XtraEditors.GroupControl();
			this.Searchpanel = new System.Windows.Forms.Panel();
			this.btn_Search = new DevExpress.XtraEditors.SimpleButton();
			this.txtSearch = new DevExpress.XtraEditors.TextEdit();
			this.btn_Add = new DevExpress.XtraEditors.SimpleButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.btn_Del = new DevExpress.XtraEditors.SimpleButton();
			this.gridControlMd_Service = new DevExpress.XtraGrid.GridControl();
			this.gridViewMdService = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumnSV1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumnSV2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumnSV3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumnSV4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumnSV5 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumnSV6 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumnSV7 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumnSV8 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumnSV9 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			this.gridColumnSV10 = new DevExpress.XtraGrid.Columns.GridColumn();
			((System.ComponentModel.ISupportInitialize)(this.grpMDServiceTop)).BeginInit();
			this.grpMDServiceTop.SuspendLayout();
			this.Searchpanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControlMd_Service)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewMdService)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
			this.SuspendLayout();
			// 
			// grpMDServiceTop
			// 
			this.grpMDServiceTop.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.grpMDServiceTop.Appearance.Options.UseBackColor = true;
			this.grpMDServiceTop.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.grpMDServiceTop.AppearanceCaption.Options.UseFont = true;
			this.grpMDServiceTop.Controls.Add(this.Searchpanel);
			this.grpMDServiceTop.Controls.Add(this.btn_Add);
			this.grpMDServiceTop.Controls.Add(this.btn_Del);
			this.grpMDServiceTop.Controls.Add(this.gridControlMd_Service);
			this.grpMDServiceTop.ImeMode = System.Windows.Forms.ImeMode.On;
			this.grpMDServiceTop.Location = new System.Drawing.Point(8, 0);
			this.grpMDServiceTop.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.grpMDServiceTop.LookAndFeel.UseDefaultLookAndFeel = false;
			this.grpMDServiceTop.LookAndFeel.UseWindowsXPTheme = false;
			this.grpMDServiceTop.Name = "grpMDServiceTop";
			this.grpMDServiceTop.Size = new System.Drawing.Size(980, 560);
			this.grpMDServiceTop.TabIndex = 90;
			this.grpMDServiceTop.Text = "Service";
			// 
			// Searchpanel
			// 
			this.Searchpanel.Controls.Add(this.btn_Search);
			this.Searchpanel.Controls.Add(this.txtSearch);
			this.Searchpanel.Location = new System.Drawing.Point(512, 24);
			this.Searchpanel.Name = "Searchpanel";
			this.Searchpanel.Size = new System.Drawing.Size(464, 24);
			this.Searchpanel.TabIndex = 152;
			// 
			// btn_Search
			// 
			this.btn_Search.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.btn_Search.Appearance.Options.UseFont = true;
			this.btn_Search.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btn_Search.Location = new System.Drawing.Point(392, 0);
			this.btn_Search.Name = "btn_Search";
			this.btn_Search.Size = new System.Drawing.Size(56, 20);
			this.btn_Search.TabIndex = 137;
			this.btn_Search.Text = "Search";
			this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
			// 
			// txtSearch
			// 
			this.txtSearch.EditValue = "";
			this.txtSearch.ImeMode = System.Windows.Forms.ImeMode.On;
			this.txtSearch.Location = new System.Drawing.Point(232, 0);
			this.txtSearch.Name = "txtSearch";
			// 
			// txtSearch.Properties
			// 
			this.txtSearch.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtSearch.Properties.Appearance.Options.UseFont = true;
			this.txtSearch.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.txtSearch.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.txtSearch.Size = new System.Drawing.Size(152, 20);
			this.txtSearch.TabIndex = 136;
			this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
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
			this.btn_Add.Location = new System.Drawing.Point(8, 32);
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
			this.btn_Del.Location = new System.Drawing.Point(48, 32);
			this.btn_Del.Name = "btn_Del";
			this.btn_Del.Size = new System.Drawing.Size(38, 16);
			this.btn_Del.TabIndex = 131;
			this.btn_Del.Click += new System.EventHandler(this.btn_Del_Click);
			// 
			// gridControlMd_Service
			// 
			this.gridControlMd_Service.Dock = System.Windows.Forms.DockStyle.Bottom;
			// 
			// gridControlMd_Service.EmbeddedNavigator
			// 
			this.gridControlMd_Service.EmbeddedNavigator.Name = "";
			this.gridControlMd_Service.Location = new System.Drawing.Point(2, 54);
			this.gridControlMd_Service.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.gridControlMd_Service.LookAndFeel.UseDefaultLookAndFeel = false;
			this.gridControlMd_Service.MainView = this.gridViewMdService;
			this.gridControlMd_Service.Name = "gridControlMd_Service";
			this.gridControlMd_Service.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																														   this.repositoryItemLookUpEdit1});
			this.gridControlMd_Service.Size = new System.Drawing.Size(976, 504);
			this.gridControlMd_Service.TabIndex = 19;
			this.gridControlMd_Service.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																												 this.gridViewMdService});
			// 
			// gridViewMdService
			// 
			this.gridViewMdService.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																									 this.gridColumnSV1,
																									 this.gridColumnSV2,
																									 this.gridColumnSV3,
																									 this.gridColumnSV4,
																									 this.gridColumnSV5,
																									 this.gridColumnSV6,
																									 this.gridColumnSV7,
																									 this.gridColumnSV8,
																									 this.gridColumnSV9,
																									 this.gridColumnSV10});
			this.gridViewMdService.GridControl = this.gridControlMd_Service;
			this.gridViewMdService.Name = "gridViewMdService";
			this.gridViewMdService.OptionsCustomization.AllowFilter = false;
			this.gridViewMdService.OptionsCustomization.AllowSort = false;
			this.gridViewMdService.OptionsView.ShowGroupPanel = false;
			this.gridViewMdService.LostFocus += new System.EventHandler(this.gridViewMdService_LostFocus);
			// 
			// gridColumnSV1
			// 
			this.gridColumnSV1.Caption = "Service Code";
			this.gridColumnSV1.FieldName = "strServiceCode";
			this.gridColumnSV1.Name = "gridColumnSV1";
			this.gridColumnSV1.Visible = true;
			this.gridColumnSV1.VisibleIndex = 0;
			this.gridColumnSV1.Width = 93;
			// 
			// gridColumnSV2
			// 
			this.gridColumnSV2.Caption = "Description";
			this.gridColumnSV2.FieldName = "strDescription";
			this.gridColumnSV2.Name = "gridColumnSV2";
			this.gridColumnSV2.Visible = true;
			this.gridColumnSV2.VisibleIndex = 1;
			this.gridColumnSV2.Width = 93;
			// 
			// gridColumnSV3
			// 
			this.gridColumnSV3.Caption = "Duration";
			this.gridColumnSV3.FieldName = "nDuration";
			this.gridColumnSV3.Name = "gridColumnSV3";
			this.gridColumnSV3.Visible = true;
			this.gridColumnSV3.VisibleIndex = 2;
			this.gridColumnSV3.Width = 93;
			// 
			// gridColumnSV4
			// 
			this.gridColumnSV4.Caption = "Comm Level 1";
			this.gridColumnSV4.FieldName = "mServiceCommission1";
			this.gridColumnSV4.Name = "gridColumnSV4";
			this.gridColumnSV4.Visible = true;
			this.gridColumnSV4.VisibleIndex = 3;
			this.gridColumnSV4.Width = 93;
			// 
			// gridColumnSV5
			// 
			this.gridColumnSV5.Caption = "Comm Level 2";
			this.gridColumnSV5.FieldName = "mServiceCommission2";
			this.gridColumnSV5.Name = "gridColumnSV5";
			this.gridColumnSV5.Visible = true;
			this.gridColumnSV5.VisibleIndex = 4;
			this.gridColumnSV5.Width = 93;
			// 
			// gridColumnSV6
			// 
			this.gridColumnSV6.Caption = "Comm Level 3";
			this.gridColumnSV6.FieldName = "mServiceCommission3";
			this.gridColumnSV6.Name = "gridColumnSV6";
			this.gridColumnSV6.Visible = true;
			this.gridColumnSV6.VisibleIndex = 5;
			this.gridColumnSV6.Width = 93;
			// 
			// gridColumnSV7
			// 
			this.gridColumnSV7.Caption = "Comm Level 4";
			this.gridColumnSV7.FieldName = "mServiceCommission4";
			this.gridColumnSV7.Name = "gridColumnSV7";
			this.gridColumnSV7.Visible = true;
			this.gridColumnSV7.VisibleIndex = 6;
			this.gridColumnSV7.Width = 93;
			// 
			// gridColumnSV8
			// 
			this.gridColumnSV8.Caption = "Comm Level 5";
			this.gridColumnSV8.FieldName = "mServiceCommission5";
			this.gridColumnSV8.Name = "gridColumnSV8";
			this.gridColumnSV8.Visible = true;
			this.gridColumnSV8.VisibleIndex = 7;
			this.gridColumnSV8.Width = 102;
			// 
			// gridColumnSV9
			// 
			this.gridColumnSV9.Caption = "Service Type";
			this.gridColumnSV9.ColumnEdit = this.repositoryItemLookUpEdit1;
			this.gridColumnSV9.FieldName = "nServiceTypeID";
			this.gridColumnSV9.Name = "gridColumnSV9";
			this.gridColumnSV9.Visible = true;
			this.gridColumnSV9.VisibleIndex = 8;
			this.gridColumnSV9.Width = 94;
			// 
			// repositoryItemLookUpEdit1
			// 
			this.repositoryItemLookUpEdit1.AutoHeight = false;
			this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
			// 
			// gridColumnSV10
			// 
			this.gridColumnSV10.Caption = "Base Price";
			this.gridColumnSV10.FieldName = "mBasePrice";
			this.gridColumnSV10.Name = "gridColumnSV10";
			this.gridColumnSV10.Visible = true;
			this.gridColumnSV10.VisibleIndex = 9;
			this.gridColumnSV10.Width = 88;
			// 
			// frmService
			// 
			this.AutoScale = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(1000, 560);
			this.Controls.Add(this.grpMDServiceTop);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmService";
			this.Text = "frmService";
			this.Load += new System.EventHandler(this.frmService_Load);
			((System.ComponentModel.ISupportInitialize)(this.grpMDServiceTop)).EndInit();
			this.grpMDServiceTop.ResumeLayout(false);
			this.Searchpanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControlMd_Service)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewMdService)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region init
		private void mdServiceInit()
		{
			fMode="N";
			string strSQL;
			
			//strSQL = "select * from tblServiceType";
			//comboBind(mdSV_cbNServiceTypeID,strSQL,"strDescription","nServiceTypeID",true);

			DataTable dt;
			DataSet _ds;

			_ds = new DataSet(); 
			strSQL = "select * from tblServiceType";
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			dt = _ds.Tables["Table"];
			DevExpress.XtraEditors.Controls.LookUpColumnInfo[] col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
			col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nServiceTypeID","Service Type ID",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription","Description",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			myManager = new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(repositoryItemLookUpEdit1,dt,col,"strDescription","nServiceTypeID","Manager");


			strSQL = "select A.*,B.strDescription as ServiceTypeName from tblService A inner join tblServiceType B on A.nServiceTypeID=B.nServiceTypeID";
			strSQL += " and (A.strServiceCode like '%" + txtSearch.Text + "%' or  A.strDescription like '%" + txtSearch.Text + "%')";
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dtService=_ds.Tables["table"];
			this.gridControlMd_Service.DataSource = dtService;
		}
		#endregion

		#region logic
		private void btn_Del_Click(object sender, System.EventArgs e)
		{
			int output;
			output = 0;
			DataRow row = gridViewMdService.GetDataRow(gridViewMdService.FocusedRowHandle);
			if (row != null)
			{
				DialogResult result = MessageBox.Show(this, "Do you really want to delete record with Service Code = '" + row["strServiceCode"].ToString() + "'",
					"Delete?", MessageBoxButtons.YesNo);
				if (result == DialogResult.Yes)
				{
					try
					{

						SqlHelper.ExecuteNonQuery(connection,"up_tblService",
							new SqlParameter("@RET_VAL",output),
							new SqlParameter("@cmd","D"),
							new SqlParameter("@strServiceCode",row["strServiceCode"].ToString() ),
							new SqlParameter("@strDescription",row["strDescription"].ToString() ),
							new SqlParameter("@nDuration",null ),
							new SqlParameter("@mServiceCommission1",null ),
							new SqlParameter("@mServiceCommission2",null ),
							new SqlParameter("@mServiceCommission3",null ),
							new SqlParameter("@mServiceCommission4",null ),
							new SqlParameter("@mServiceCommission5",null ),
							new SqlParameter("@nServiceTypeID",null ),
							new SqlParameter("@mBasePrice",null )
							);
						MessageBox.Show("Record Deleted.","Info");
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message,"Error");
					}
				}
			}

			mdServiceInit();
	
		}


		#endregion

		private bool FieldChecking(DataRow dr)
		{
			if ( dr["strServiceCode"].ToString() == "")
			{
				MessageBox.Show("Service Code is empty","Info");
				return false;
			}

			if ( dr["nServiceTypeID"].ToString() == "")
			{
				MessageBox.Show("Service Type Code is empty","Info");
				return false;
			}
			return true;

		}
		
		#region common
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

		
		private void btn_Add_Click(object sender, System.EventArgs e)
		{
			fMode = "I";
			DataRow dr = dtService.NewRow();
			dtService.Rows.Add(dr);
			this.gridControlMd_Service.Refresh();
			this.gridViewMdService.FocusedRowHandle = dtService.Rows.Count - 1;
		}

		private void frmService_Load(object sender, System.EventArgs e)
		{
			mdServiceInit();
		
		}

		private void gridViewMdService_LostFocus(object sender, System.EventArgs e)
		{
			DataRow row = this.gridViewMdService.GetDataRow(gridViewMdService.FocusedRowHandle);
			
			string strSQL = "Select * from tblService";
			if (fMode=="I")
			{
				if( FieldChecking(row))
				{
					gridControlMd_Service.MainView.UpdateCurrentRow();
					try
					{
						CreateCmdsAndUpdate(strSQL,dtService);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message ,"Insert Failed");
						return;
					}
					fMode = "N";
				}
			}
			else
			{
				gridViewMdService.CloseEditor();
				gridViewMdService.UpdateCurrentRow();
				CreateCmdsAndUpdate(strSQL,dtService);
			}
		}

		private void btn_Search_Click(object sender, System.EventArgs e)
		{
			mdServiceInit();
		}

		private void txtSearch_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btn_Search_Click(sender,e);
			}
		}

		public string fMode
		{
			get
			{
				return _mode;
			}
			set
			{
				_mode = value;
			}
		}

	}
}
