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
using ACMS.Utils;

namespace ACMS.ACMSManager.MasterData
{
	/// <summary>
	/// Summary description for frmTerminalUser.
	/// </summary>
	public class frmTerminalUser : System.Windows.Forms.Form
	{
		private string connectionString;
		private SqlConnection connection;
		private DevExpress.XtraEditors.GroupControl groupControl2;
		internal DevExpress.XtraEditors.SimpleButton btn_Add;
		internal DevExpress.XtraEditors.SimpleButton btn_Del;
		internal DevExpress.XtraEditors.TextEdit txtSearch;
		internal DevExpress.XtraEditors.SimpleButton btn_Search;
		private System.Windows.Forms.ImageList imageList1;
		private DevExpress.XtraGrid.Columns.GridColumn strTerminalUserCode;
		private DevExpress.XtraGrid.Columns.GridColumn strBranchCode;
		private DevExpress.XtraGrid.Columns.GridColumn nTerminalID;
		private DevExpress.XtraGrid.Columns.GridColumn Status;
		private DevExpress.XtraGrid.GridControl gridControlMd_TerminalUser;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chk_Status;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView_TerminalUser;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_Branch;
		private DevExpress.XtraEditors.GroupControl grpMDTerminalUser;
		private System.ComponentModel.IContainer components;

		public frmTerminalUser()
		{
			InitializeComponent();
			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);
		}

		private void Load_frmTerminalUser(object sender, System.EventArgs e)
		{
			lk_Branch_Init();
			mdTerminalUserInit();
		}

		private DataTable dtTerminalUser;

		private void mdTerminalUserInit()
		{
			string strSQL;
			strSQL = "Select * from tblTerminalUser where strTerminalUserCode like '%" + txtSearch.Text + "%'";
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dtTerminalUser = _ds.Tables["table"];
			gridControlMd_TerminalUser.DataSource = dtTerminalUser;
		}

		private void lk_Branch_Init()
		{
			DataSet _ds = new DataSet();
			string strSQL;
			
			strSQL = "select * from tblBranch";
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			DataTable dt = _ds.Tables["table"];
						
			DevExpress.XtraEditors.Controls.LookUpColumnInfo[] col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
						
			col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strBranchCode","Branch ID",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strBranchName","Branch Name",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
					
			new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(lk_Branch,dt,col,"strBranchName","strBranchCode","Branch");
		}

		private bool CheckClassTypeField(DataRow dr)
		{
			for (int a =0; a< 5; a++)
			{
				if (dr[a].ToString() == "")
					return false;
			}
			return true;
		}

		private void btn_Add_Click(object sender, System.EventArgs e)
		{
			AddNew = true;
			DataRow dr = dtTerminalUser.NewRow();
			dtTerminalUser.Rows.Add(dr);
			this.gridControlMd_TerminalUser.Refresh();
			this.gridView_TerminalUser.FocusedRowHandle = dtTerminalUser.Rows.Count - 1;
			
		}

		private bool AddNew = false;

		private void btn_Del_Click(object sender, System.EventArgs e)
		{
			DataRow row = this.gridView_TerminalUser.GetDataRow(gridView_TerminalUser.FocusedRowHandle);
			if (row != null)
			{
	
				if (AddNew)
				{
					AddNew = false;
					gridView_TerminalUser.DeleteRow(gridView_TerminalUser.FocusedRowHandle);
				}
				else
				{

					DialogResult result = MessageBox.Show(this, "Do you really want to delete record with TerminalUser Code = " + row["strTerminalUserCode"].ToString(),
						"Delete?", MessageBoxButtons.YesNo);
					if (result == DialogResult.Yes)
					{
						try
						{
							SqlHelper.ExecuteNonQuery(connection,"del_TerminalUser",
								new SqlParameter("@strClassCode",row["strTerminalUserCode"].ToString() )
								);
						}
						catch(Exception ex)
						{
							MessageBox.Show(ex.Message ,"Delete Process Failed");
							return;
						}
						MessageBox.Show("Record Deleted Successfully","Message");
					}
					mdTerminalUserInit();
				}
			}
		}

		private void txtSearch_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btn_Search_Click(sender,e);
			}
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmTerminalUser));
			this.gridView_TerminalUser = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.strTerminalUserCode = new DevExpress.XtraGrid.Columns.GridColumn();
			this.strBranchCode = new DevExpress.XtraGrid.Columns.GridColumn();
			this.lk_Branch = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			this.nTerminalID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.Status = new DevExpress.XtraGrid.Columns.GridColumn();
			this.chk_Status = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.gridControlMd_TerminalUser = new DevExpress.XtraGrid.GridControl();
			this.grpMDTerminalUser = new DevExpress.XtraEditors.GroupControl();
			this.btn_Add = new DevExpress.XtraEditors.SimpleButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.btn_Del = new DevExpress.XtraEditors.SimpleButton();
			this.txtSearch = new DevExpress.XtraEditors.TextEdit();
			this.btn_Search = new DevExpress.XtraEditors.SimpleButton();
			this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
			((System.ComponentModel.ISupportInitialize)(this.gridView_TerminalUser)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_Branch)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chk_Status)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControlMd_TerminalUser)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grpMDTerminalUser)).BeginInit();
			this.grpMDTerminalUser.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
			this.groupControl2.SuspendLayout();
			this.SuspendLayout();
			// 
			// gridView_TerminalUser
			// 
			this.gridView_TerminalUser.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																										 this.strTerminalUserCode,
																										 this.strBranchCode,
																										 this.nTerminalID,
																										 this.Status});
			this.gridView_TerminalUser.GridControl = this.gridControlMd_TerminalUser;
			this.gridView_TerminalUser.Name = "gridView_TerminalUser";
			this.gridView_TerminalUser.OptionsCustomization.AllowColumnMoving = false;
			this.gridView_TerminalUser.OptionsCustomization.AllowFilter = false;
			this.gridView_TerminalUser.OptionsCustomization.AllowSort = false;
			this.gridView_TerminalUser.OptionsView.ShowGroupPanel = false;
			this.gridView_TerminalUser.LostFocus += new System.EventHandler(this.gridView_TerminalUser_LostFocus);
			// 
			// strTerminalUserCode
			// 
			this.strTerminalUserCode.Caption = "Terminal User";
			this.strTerminalUserCode.FieldName = "strTerminalUserCode";
			this.strTerminalUserCode.Name = "strTerminalUserCode";
			this.strTerminalUserCode.Visible = true;
			this.strTerminalUserCode.VisibleIndex = 0;
			this.strTerminalUserCode.Width = 356;
			// 
			// strBranchCode
			// 
			this.strBranchCode.Caption = "Branch";
			this.strBranchCode.ColumnEdit = this.lk_Branch;
			this.strBranchCode.FieldName = "strBranchCode";
			this.strBranchCode.Name = "strBranchCode";
			this.strBranchCode.Visible = true;
			this.strBranchCode.VisibleIndex = 1;
			this.strBranchCode.Width = 209;
			// 
			// lk_Branch
			// 
			this.lk_Branch.AutoHeight = false;
			this.lk_Branch.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																								   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lk_Branch.Name = "lk_Branch";
			// 
			// nTerminalID
			// 
			this.nTerminalID.Caption = "TerminalID";
			this.nTerminalID.FieldName = "nTerminalID";
			this.nTerminalID.Name = "nTerminalID";
			this.nTerminalID.Visible = true;
			this.nTerminalID.VisibleIndex = 2;
			this.nTerminalID.Width = 202;
			// 
			// Status
			// 
			this.Status.Caption = "Status";
			this.Status.ColumnEdit = this.chk_Status;
			this.Status.FieldName = "Status";
			this.Status.Name = "Status";
			this.Status.Visible = true;
			this.Status.VisibleIndex = 3;
			this.Status.Width = 80;
			// 
			// chk_Status
			// 
			this.chk_Status.AutoHeight = false;
			this.chk_Status.Name = "chk_Status";
			// 
			// gridControlMd_TerminalUser
			// 
			this.gridControlMd_TerminalUser.Dock = System.Windows.Forms.DockStyle.Top;
			// 
			// gridControlMd_TerminalUser.EmbeddedNavigator
			// 
			this.gridControlMd_TerminalUser.EmbeddedNavigator.Name = "";
			this.gridControlMd_TerminalUser.Location = new System.Drawing.Point(0, 0);
			this.gridControlMd_TerminalUser.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.gridControlMd_TerminalUser.LookAndFeel.UseDefaultLookAndFeel = false;
			this.gridControlMd_TerminalUser.MainView = this.gridView_TerminalUser;
			this.gridControlMd_TerminalUser.Name = "gridControlMd_TerminalUser";
			this.gridControlMd_TerminalUser.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																																this.chk_Status,
																																this.lk_Branch});
			this.gridControlMd_TerminalUser.Size = new System.Drawing.Size(720, 380);
			this.gridControlMd_TerminalUser.TabIndex = 126;
			this.gridControlMd_TerminalUser.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																													  this.gridView_TerminalUser});
			// 
			// grpMDTerminalUser
			// 
			this.grpMDTerminalUser.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.grpMDTerminalUser.Appearance.Options.UseBackColor = true;
			this.grpMDTerminalUser.Controls.Add(this.btn_Add);
			this.grpMDTerminalUser.Controls.Add(this.btn_Del);
			this.grpMDTerminalUser.Controls.Add(this.txtSearch);
			this.grpMDTerminalUser.Controls.Add(this.btn_Search);
			this.grpMDTerminalUser.Controls.Add(this.groupControl2);
			this.grpMDTerminalUser.ImeMode = System.Windows.Forms.ImeMode.On;
			this.grpMDTerminalUser.Location = new System.Drawing.Point(8, 0);
			this.grpMDTerminalUser.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.grpMDTerminalUser.LookAndFeel.UseDefaultLookAndFeel = false;
			this.grpMDTerminalUser.LookAndFeel.UseWindowsXPTheme = false;
			this.grpMDTerminalUser.Name = "grpMDTerminalUser";
			this.grpMDTerminalUser.Size = new System.Drawing.Size(736, 448);
			this.grpMDTerminalUser.TabIndex = 35;
			this.grpMDTerminalUser.Text = "Terminal User";
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
			// txtSearch
			// 
			this.txtSearch.EditValue = "";
			this.txtSearch.Location = new System.Drawing.Point(448, 24);
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
			// btn_Search
			// 
			this.btn_Search.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.btn_Search.Appearance.Options.UseFont = true;
			this.btn_Search.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btn_Search.Location = new System.Drawing.Point(640, 24);
			this.btn_Search.Name = "btn_Search";
			this.btn_Search.Size = new System.Drawing.Size(56, 20);
			this.btn_Search.TabIndex = 137;
			this.btn_Search.Text = "Search";
			this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
			// 
			// groupControl2
			// 
			this.groupControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.groupControl2.Controls.Add(this.gridControlMd_TerminalUser);
			this.groupControl2.Location = new System.Drawing.Point(8, 48);
			this.groupControl2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.groupControl2.LookAndFeel.UseDefaultLookAndFeel = false;
			this.groupControl2.LookAndFeel.UseWindowsXPTheme = false;
			this.groupControl2.Name = "groupControl2";
			this.groupControl2.Size = new System.Drawing.Size(720, 384);
			this.groupControl2.TabIndex = 128;
			this.groupControl2.Text = "Terminal ID ";
			// 
			// frmTerminalUser
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(744, 464);
			this.Controls.Add(this.grpMDTerminalUser);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmTerminalUser";
			this.Text = "frmTerminalUser";
			this.Load += new System.EventHandler(this.Load_frmTerminalUser);
			((System.ComponentModel.ISupportInitialize)(this.gridView_TerminalUser)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_Branch)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chk_Status)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControlMd_TerminalUser)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grpMDTerminalUser)).EndInit();
			this.grpMDTerminalUser.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
			this.groupControl2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btn_Search_Click(object sender, System.EventArgs e)
		{
			mdTerminalUserInit();	
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

		private void gridView_TerminalUser_LostFocus(object sender, System.EventArgs e)
		{
			DataRow row = this.gridView_TerminalUser.GetDataRow(gridView_TerminalUser.FocusedRowHandle);
			
			string strSQL = "Select * from tblTerminalUser";
			if (AddNew)
			{
				if( CheckClassTypeField(row))
				{
					gridView_TerminalUser.UpdateCurrentRow();
					try
					{
						CreateCmdsAndUpdate(strSQL,dtTerminalUser);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message ,"Insert Failed");
						return;
					}
								
					AddNew = false;
				}
			}
			else
			{
				this.gridView_TerminalUser.CloseEditor();
				gridView_TerminalUser.UpdateCurrentRow();
				CreateCmdsAndUpdate(strSQL,dtTerminalUser);
			}
		}

	}
}
