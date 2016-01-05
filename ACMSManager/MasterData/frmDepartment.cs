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
	/// Summary description for frmDepartment.
	/// </summary>
	public class frmDepartment : System.Windows.Forms.Form
	{
		private ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder myManager;

		private string connectionString;
		private SqlConnection connection;
		private DevExpress.XtraEditors.GroupControl grpMDServiceTop;
		private DevExpress.XtraGrid.GridControl gridControl1;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private System.Windows.Forms.ImageList imageList1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox LK_nDepartHead;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
		internal DevExpress.XtraEditors.SimpleButton btn_Add;
		internal DevExpress.XtraEditors.SimpleButton btn_Del;
		private System.ComponentModel.IContainer components;
		private DataTable dtDepartment;

		public frmDepartment()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmDepartment));
			this.grpMDServiceTop = new DevExpress.XtraEditors.GroupControl();
			this.btn_Add = new DevExpress.XtraEditors.SimpleButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.btn_Del = new DevExpress.XtraEditors.SimpleButton();
			this.gridControl1 = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			this.LK_nDepartHead = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
			((System.ComponentModel.ISupportInitialize)(this.grpMDServiceTop)).BeginInit();
			this.grpMDServiceTop.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.LK_nDepartHead)).BeginInit();
			this.SuspendLayout();
			// 
			// grpMDServiceTop
			// 
			this.grpMDServiceTop.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.grpMDServiceTop.Appearance.Options.UseBackColor = true;
			this.grpMDServiceTop.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.grpMDServiceTop.AppearanceCaption.Options.UseFont = true;
			this.grpMDServiceTop.Controls.Add(this.btn_Add);
			this.grpMDServiceTop.Controls.Add(this.btn_Del);
			this.grpMDServiceTop.Controls.Add(this.gridControl1);
			this.grpMDServiceTop.ImeMode = System.Windows.Forms.ImeMode.On;
			this.grpMDServiceTop.Location = new System.Drawing.Point(0, 0);
			this.grpMDServiceTop.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.grpMDServiceTop.LookAndFeel.UseDefaultLookAndFeel = false;
			this.grpMDServiceTop.LookAndFeel.UseWindowsXPTheme = false;
			this.grpMDServiceTop.Name = "grpMDServiceTop";
			this.grpMDServiceTop.Size = new System.Drawing.Size(984, 560);
			this.grpMDServiceTop.TabIndex = 91;
			this.grpMDServiceTop.Text = "Department";
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
			this.btn_Add.TabIndex = 130;
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
			this.btn_Del.TabIndex = 129;
			this.btn_Del.Click += new System.EventHandler(this.btn_Del_Click);
			// 
			// gridControl1
			// 
			this.gridControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
			// 
			// gridControl1.EmbeddedNavigator
			// 
			this.gridControl1.EmbeddedNavigator.Name = "";
			this.gridControl1.Location = new System.Drawing.Point(2, 46);
			this.gridControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.gridControl1.LookAndFeel.UseDefaultLookAndFeel = false;
			this.gridControl1.MainView = this.gridView1;
			this.gridControl1.Name = "gridControl1";
			this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																												  this.LK_nDepartHead,
																												  this.repositoryItemLookUpEdit1});
			this.gridControl1.Size = new System.Drawing.Size(980, 512);
			this.gridControl1.TabIndex = 19;
			this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										this.gridView1});
			// 
			// gridView1
			// 
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn1,
																							 this.gridColumn2,
																							 this.gridColumn3});
			this.gridView1.GridControl = this.gridControl1;
			this.gridView1.Name = "gridView1";
			this.gridView1.OptionsCustomization.AllowFilter = false;
			this.gridView1.OptionsCustomization.AllowSort = false;
			this.gridView1.OptionsView.ShowGroupPanel = false;
			this.gridView1.LostFocus += new System.EventHandler(this.gridView1_LostFocus);
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "Department ID";
			this.gridColumn1.FieldName = "nDepartmentID";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 0;
			this.gridColumn1.Width = 152;
			// 
			// gridColumn2
			// 
			this.gridColumn2.Caption = "Description";
			this.gridColumn2.FieldName = "strDescription";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 1;
			this.gridColumn2.Width = 556;
			// 
			// gridColumn3
			// 
			this.gridColumn3.Caption = "Department Head";
			this.gridColumn3.ColumnEdit = this.repositoryItemLookUpEdit1;
			this.gridColumn3.FieldName = "nDepartHead";
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 2;
			this.gridColumn3.Width = 227;
			// 
			// repositoryItemLookUpEdit1
			// 
			this.repositoryItemLookUpEdit1.AutoHeight = false;
			this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
			// 
			// LK_nDepartHead
			// 
			this.LK_nDepartHead.AutoHeight = false;
			this.LK_nDepartHead.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																										new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.LK_nDepartHead.Name = "LK_nDepartHead";
			// 
			// frmDepartment
			// 
			this.AutoScale = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(1000, 560);
			this.Controls.Add(this.grpMDServiceTop);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmDepartment";
			this.Text = "frmDepartment";
			this.Load += new System.EventHandler(this.frmDepartment_Load);
			((System.ComponentModel.ISupportInitialize)(this.grpMDServiceTop)).EndInit();
			this.grpMDServiceTop.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.LK_nDepartHead)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void init()
		{
					
			DataSet _ds = new DataSet(); 
			string strSQL = "select * from tblEmployee";
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			DataTable dt = _ds.Tables["Table"];

			DevExpress.XtraEditors.Controls.LookUpColumnInfo[] col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
			
			col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nEmployeeID","Employee Id",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strEmployeeName","Employee Name",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
		
			myManager = new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(repositoryItemLookUpEdit1,dt,col,"strEmployeeName","nEmployeeID","Manager");
			BindGrid();
		}


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

		private void frmDepartment_Load(object sender, System.EventArgs e)
		{
			init();
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
		
		private void BindGrid()
		{
			string strSQL= "select * from tblDepartment";
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dtDepartment = _ds.Tables["table"];
			this.gridControl1.DataSource = dtDepartment;
		}

		private bool FieldChecking(DataRow dr)
		{
			if ( dr["nDepartmentID"].ToString() == "" )
					return false;	
		
			return true;
		}

		private void gridView1_LostFocus(object sender, System.EventArgs e)
		{
			DataRow row = this.gridView1.GetDataRow(gridView1.FocusedRowHandle);
			
			string strSQL = "Select * from tblDepartment";
			if (AddNew)
			{
				if( FieldChecking(row))
				{
					gridControl1.MainView.UpdateCurrentRow();
					try
					{
						CreateCmdsAndUpdate(strSQL,dtDepartment);
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
				gridView1.CloseEditor();
				gridView1.UpdateCurrentRow();

				CreateCmdsAndUpdate(strSQL,dtDepartment);
			}
		}
		private bool AddNew = false;
		private void btn_Add_Click(object sender, System.EventArgs e)
		{
			AddNew = true;
			DataRow dr = dtDepartment.NewRow();
			dtDepartment.Rows.Add(dr);
			this.gridControl1.Refresh();
			this.gridView1.FocusedRowHandle = dtDepartment.Rows.Count - 1;
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

					DialogResult result = MessageBox.Show(this, "Do you really want to delete record with Department Id = " + row["nDepartmentID"].ToString(),
						"Delete?", MessageBoxButtons.YesNo);
					if (result == DialogResult.Yes)
					{
						try
						{
							SqlHelper.ExecuteNonQuery(connection,"del_TblDepartment",
								new SqlParameter("@departmentID",row["nDepartmentID"].ToString() )
								);
						}
						catch(Exception ex)
						{
							MessageBox.Show(ex.Message ,"Delete Process Failed");
							return;
						}
						MessageBox.Show("Record Deleted Successfully","Message");
						BindGrid();
					}
				}
				
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

	}

}
