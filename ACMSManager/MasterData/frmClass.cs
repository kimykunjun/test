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
	/// Summary description for frmClass.
	/// </summary>
	public class frmClass : System.Windows.Forms.Form
	{
		private string connectionString;
		private SqlConnection connection;
		private DevExpress.XtraEditors.GroupControl grpMDClass;
		private DevExpress.XtraEditors.GroupControl groupControl1;
		private DevExpress.XtraGrid.GridControl gridControlMD_Class;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewMd_Class;
		private DevExpress.XtraEditors.GroupControl groupControl2;
		private DevExpress.XtraGrid.GridControl gridControlMd_ClassType;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewMd_ClassType;
		internal DevExpress.XtraEditors.SimpleButton btn_Add;
		internal DevExpress.XtraEditors.SimpleButton btn_Del;
		private System.Windows.Forms.ImageList imageList1;
		internal DevExpress.XtraEditors.SimpleButton btnClass_Add;
		internal DevExpress.XtraEditors.SimpleButton btnClass_Del;
		private System.ComponentModel.IContainer components;
		private DataTable dtClassType;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_RPClassType;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DataTable dtClass;

		public frmClass()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmClass));
			this.grpMDClass = new DevExpress.XtraEditors.GroupControl();
			this.btnClass_Add = new DevExpress.XtraEditors.SimpleButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.btnClass_Del = new DevExpress.XtraEditors.SimpleButton();
			this.btn_Add = new DevExpress.XtraEditors.SimpleButton();
			this.btn_Del = new DevExpress.XtraEditors.SimpleButton();
			this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
			this.gridControlMd_ClassType = new DevExpress.XtraGrid.GridControl();
			this.gridViewMd_ClassType = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
			this.gridControlMD_Class = new DevExpress.XtraGrid.GridControl();
			this.gridViewMd_Class = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.lk_RPClassType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			((System.ComponentModel.ISupportInitialize)(this.grpMDClass)).BeginInit();
			this.grpMDClass.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
			this.groupControl2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControlMd_ClassType)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewMd_ClassType)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
			this.groupControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControlMD_Class)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewMd_Class)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_RPClassType)).BeginInit();
			this.SuspendLayout();
			// 
			// grpMDClass
			// 
			this.grpMDClass.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.grpMDClass.Appearance.Options.UseBackColor = true;
			this.grpMDClass.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.grpMDClass.Controls.Add(this.btnClass_Add);
			this.grpMDClass.Controls.Add(this.btnClass_Del);
			this.grpMDClass.Controls.Add(this.btn_Add);
			this.grpMDClass.Controls.Add(this.btn_Del);
			this.grpMDClass.Controls.Add(this.groupControl2);
			this.grpMDClass.Controls.Add(this.groupControl1);
			this.grpMDClass.ImeMode = System.Windows.Forms.ImeMode.On;
			this.grpMDClass.Location = new System.Drawing.Point(8, 0);
			this.grpMDClass.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.grpMDClass.LookAndFeel.UseDefaultLookAndFeel = false;
			this.grpMDClass.LookAndFeel.UseWindowsXPTheme = false;
			this.grpMDClass.Name = "grpMDClass";
			this.grpMDClass.Size = new System.Drawing.Size(970, 560);
			this.grpMDClass.TabIndex = 33;
			this.grpMDClass.Text = "Class";
			// 
			// btnClass_Add
			// 
			this.btnClass_Add.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnClass_Add.Appearance.Options.UseFont = true;
			this.btnClass_Add.Appearance.Options.UseTextOptions = true;
			this.btnClass_Add.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.btnClass_Add.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
			this.btnClass_Add.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.btnClass_Add.ImageIndex = 0;
			this.btnClass_Add.ImageList = this.imageList1;
			this.btnClass_Add.ImeMode = System.Windows.Forms.ImeMode.On;
			this.btnClass_Add.Location = new System.Drawing.Point(8, 272);
			this.btnClass_Add.Name = "btnClass_Add";
			this.btnClass_Add.Size = new System.Drawing.Size(38, 16);
			this.btnClass_Add.TabIndex = 134;
			this.btnClass_Add.Click += new System.EventHandler(this.btnClass_Add_Click);
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
			// 
			// btnClass_Del
			// 
			this.btnClass_Del.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnClass_Del.Appearance.Options.UseFont = true;
			this.btnClass_Del.Appearance.Options.UseTextOptions = true;
			this.btnClass_Del.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.btnClass_Del.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
			this.btnClass_Del.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.btnClass_Del.ImageIndex = 1;
			this.btnClass_Del.ImageList = this.imageList1;
			this.btnClass_Del.Location = new System.Drawing.Point(48, 272);
			this.btnClass_Del.Name = "btnClass_Del";
			this.btnClass_Del.Size = new System.Drawing.Size(38, 16);
			this.btnClass_Del.TabIndex = 133;
			this.btnClass_Del.Click += new System.EventHandler(this.btnClass_Del_Click);
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
			this.groupControl2.Controls.Add(this.gridControlMd_ClassType);
			this.groupControl2.Location = new System.Drawing.Point(0, 48);
			this.groupControl2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.groupControl2.LookAndFeel.UseDefaultLookAndFeel = false;
			this.groupControl2.LookAndFeel.UseWindowsXPTheme = false;
			this.groupControl2.Name = "groupControl2";
			this.groupControl2.Size = new System.Drawing.Size(968, 216);
			this.groupControl2.TabIndex = 128;
			this.groupControl2.Text = "Class Type";
			// 
			// gridControlMd_ClassType
			// 
			this.gridControlMd_ClassType.Dock = System.Windows.Forms.DockStyle.Top;
			// 
			// gridControlMd_ClassType.EmbeddedNavigator
			// 
			this.gridControlMd_ClassType.EmbeddedNavigator.Name = "";
			this.gridControlMd_ClassType.Location = new System.Drawing.Point(2, 20);
			this.gridControlMd_ClassType.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.gridControlMd_ClassType.LookAndFeel.UseDefaultLookAndFeel = false;
			this.gridControlMd_ClassType.MainView = this.gridViewMd_ClassType;
			this.gridControlMd_ClassType.Name = "gridControlMd_ClassType";
			this.gridControlMd_ClassType.Size = new System.Drawing.Size(964, 194);
			this.gridControlMd_ClassType.TabIndex = 126;
			this.gridControlMd_ClassType.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																												   this.gridViewMd_ClassType});
			// 
			// gridViewMd_ClassType
			// 
			this.gridViewMd_ClassType.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																										this.gridColumn3,
																										this.gridColumn4});
			this.gridViewMd_ClassType.GridControl = this.gridControlMd_ClassType;
			this.gridViewMd_ClassType.Name = "gridViewMd_ClassType";
			this.gridViewMd_ClassType.OptionsCustomization.AllowColumnMoving = false;
			this.gridViewMd_ClassType.OptionsCustomization.AllowFilter = false;
			this.gridViewMd_ClassType.OptionsCustomization.AllowSort = false;
			this.gridViewMd_ClassType.OptionsView.ShowGroupPanel = false;
			this.gridViewMd_ClassType.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewMd_ClassType_FocusedRowChanged);
			this.gridViewMd_ClassType.LostFocus += new System.EventHandler(this.gridViewMd_ClassType_LostFocus);
			// 
			// gridColumn3
			// 
			this.gridColumn3.Caption = "Class Type Id";
			this.gridColumn3.FieldName = "nClassTypeID";
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 0;
			// 
			// gridColumn4
			// 
			this.gridColumn4.Caption = "Description";
			this.gridColumn4.FieldName = "strDescription";
			this.gridColumn4.Name = "gridColumn4";
			this.gridColumn4.Visible = true;
			this.gridColumn4.VisibleIndex = 1;
			// 
			// groupControl1
			// 
			this.groupControl1.Controls.Add(this.gridControlMD_Class);
			this.groupControl1.Location = new System.Drawing.Point(0, 296);
			this.groupControl1.LookAndFeel.SkinName = "The Asphalt World";
			this.groupControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
			this.groupControl1.LookAndFeel.UseWindowsXPTheme = false;
			this.groupControl1.Name = "groupControl1";
			this.groupControl1.Size = new System.Drawing.Size(968, 256);
			this.groupControl1.TabIndex = 127;
			this.groupControl1.Text = "Class";
			// 
			// gridControlMD_Class
			// 
			this.gridControlMD_Class.Dock = System.Windows.Forms.DockStyle.Top;
			// 
			// gridControlMD_Class.EmbeddedNavigator
			// 
			this.gridControlMD_Class.EmbeddedNavigator.Name = "";
			this.gridControlMD_Class.Location = new System.Drawing.Point(2, 20);
			this.gridControlMD_Class.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.gridControlMD_Class.LookAndFeel.UseDefaultLookAndFeel = false;
			this.gridControlMD_Class.MainView = this.gridViewMd_Class;
			this.gridControlMD_Class.Name = "gridControlMD_Class";
			this.gridControlMD_Class.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																														 this.lk_RPClassType});
			this.gridControlMD_Class.Size = new System.Drawing.Size(964, 250);
			this.gridControlMD_Class.TabIndex = 127;
			this.gridControlMD_Class.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																											   this.gridViewMd_Class});
			// 
			// gridViewMd_Class
			// 
			this.gridViewMd_Class.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																									this.gridColumn1,
																									this.gridColumn2});
			this.gridViewMd_Class.GridControl = this.gridControlMD_Class;
			this.gridViewMd_Class.Name = "gridViewMd_Class";
			this.gridViewMd_Class.OptionsCustomization.AllowFilter = false;
			this.gridViewMd_Class.OptionsCustomization.AllowSort = false;
			this.gridViewMd_Class.OptionsView.ShowGroupPanel = false;
			this.gridViewMd_Class.LostFocus += new System.EventHandler(this.gridViewMd_Class_LostFocus);
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "Class Code";
			this.gridColumn1.FieldName = "strClassCode";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 0;
			// 
			// gridColumn2
			// 
			this.gridColumn2.Caption = "Description";
			this.gridColumn2.FieldName = "strDescription";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 1;
			// 
			// lk_RPClassType
			// 
			this.lk_RPClassType.AutoHeight = false;
			this.lk_RPClassType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																										new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lk_RPClassType.Name = "lk_RPClassType";
			// 
			// frmClass
			// 
			this.AutoScale = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(990, 560);
			this.Controls.Add(this.grpMDClass);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmClass";
			this.Text = "frmClass";
			this.Load += new System.EventHandler(this.frmClass_Load);
			((System.ComponentModel.ISupportInitialize)(this.grpMDClass)).EndInit();
			this.grpMDClass.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
			this.groupControl2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControlMd_ClassType)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewMd_ClassType)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
			this.groupControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControlMD_Class)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewMd_Class)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_RPClassType)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region class
	
		private void mdClassInit()
		{
			DataRow row = this.gridViewMd_ClassType.GetDataRow(gridViewMd_ClassType.FocusedRowHandle);
				
			if (row == null)
					return;

			string strSQL = "select * from tblClass Where nClassTypeID=" + Convert.ToInt32(row["nClassTypeID"]);

			DataSet _ds = new DataSet();
					
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dtClass = _ds.Tables["table"];
			gridControlMD_Class.DataSource = dtClass;	
		
		}

		private void mdClassTypeInit()
		{
			string strSQL = "select * from tblClassType";
			DataSet _ds = new DataSet();
			
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
		    dtClassType = _ds.Tables["Table"];

			gridControlMd_ClassType.DataSource = dtClassType;
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

	
		private bool FieldChecking(DataRow dr)
		{
			if (dr["nClassTypeID"].ToString() == "")
				return false;
			return true;
		}

		private bool FieldClassChecking(DataRow dr)
		{
			if (dr["strClassCode"].ToString() == "")
				return false;

			return true;
		}

		private void frmClass_Load(object sender, System.EventArgs e)
		{
			mdClassTypeInit();
		
		}

		private void gridViewMd_ClassType_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
			mdClassInit();
		}

		private bool AddNewType = false;
		private void btn_Add_Click(object sender, System.EventArgs e)
		{
			AddNewType = true;
			DataRow dr = dtClassType.NewRow();
			dtClassType.Rows.Add(dr);
			this.gridControlMd_ClassType.Refresh();
			this.gridViewMd_ClassType.FocusedRowHandle = dtClassType.Rows.Count - 1;
		}

		private void btn_Del_Click(object sender, System.EventArgs e)
		{
			DataRow row = this.gridViewMd_ClassType.GetDataRow(gridViewMd_ClassType.FocusedRowHandle);
			if (row != null)
			{
	
				if (AddNewType)
				{
					AddNew = false;
					gridViewMd_ClassType.DeleteRow(gridViewMd_ClassType.FocusedRowHandle);
				}
				else
				{

					DialogResult result = MessageBox.Show(this, "Do you really want to delete record with Class Type Id= " + row["nClassTypeID"].ToString(),
						"Delete?", MessageBoxButtons.YesNo);
					if (result == DialogResult.Yes)
					{
						try
						{
							SqlHelper.ExecuteNonQuery(connection,"del_tblClassType",
								new SqlParameter("@nClassTypeId",row["nClassTypeID"].ToString() )
								);
						}
						catch(Exception ex)
						{
							MessageBox.Show(ex.Message ,"Delete Process Failed");
							return;
						}
						MessageBox.Show("Record Deleted.","Message");
						mdClassTypeInit();
						mdClassInit();
					}
					
				}
			}
		}

		private void gridViewMd_ClassType_LostFocus(object sender, System.EventArgs e)
		{
			DataRow row = this.gridViewMd_ClassType.GetDataRow(gridViewMd_ClassType.FocusedRowHandle);
			
			string strSQL = "Select * from TblClassType";
			if (AddNewType)
			{
				if( FieldChecking(row))
				{
					this.gridControlMd_ClassType.MainView.UpdateCurrentRow();
					try
					{
						CreateCmdsAndUpdate(strSQL,dtClassType);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message ,"Delete Process Failed");
						return;
					}
					AddNewType = false;
				}
			}
			else
			{
				gridViewMd_ClassType.CloseEditor();
				gridViewMd_ClassType.UpdateCurrentRow();

				CreateCmdsAndUpdate(strSQL,dtClassType);
			}
		}
		private bool AddNew = false;

		private void btnClass_Add_Click(object sender, System.EventArgs e)
		{
			DataRow row = this.gridViewMd_ClassType.GetDataRow(gridViewMd_ClassType.FocusedRowHandle);

			AddNew = true;
			DataRow dr = dtClass.NewRow();
			dr["nClassTypeID"] = row["nClassTypeID"].ToString();
			dtClass.Rows.Add(dr);
            this.gridControlMD_Class.Refresh();
			this.gridViewMd_Class.FocusedRowHandle = dtClass.Rows.Count - 1;
		}

		private void btnClass_Del_Click(object sender, System.EventArgs e)
		{
			DataRow row = this.gridViewMd_Class.GetDataRow(gridViewMd_Class.FocusedRowHandle);
			if (row != null)
			{
	
				if (AddNew)
				{
					AddNew = false;
					gridViewMd_Class.DeleteRow(gridViewMd_Class.FocusedRowHandle);
				}
				else
				{

					DialogResult result = MessageBox.Show(this, "Do you really want to delete record with Class Code = " + row["strClassCode"].ToString(),
						"Delete?", MessageBoxButtons.YesNo);
					if (result == DialogResult.Yes)
					{
						try
						{
							SqlHelper.ExecuteNonQuery(connection,"del_tblClass",
								new SqlParameter("@strClassCode",row["strClassCode"].ToString() )
								);
						}
						catch(Exception ex)
						{
							MessageBox.Show(ex.Message ,"Delete Process Failed");
							return;
						}
						MessageBox.Show("Record Deleted Successfully","Message");
					}
					mdClassTypeInit();
					mdClassInit();
				}
			}
		}

	
	
		private void gridViewMd_Class_LostFocus(object sender, System.EventArgs e)
		{
            DataRow row = this.gridViewMd_Class.GetDataRow(gridViewMd_Class.FocusedRowHandle);
			
			string strSQL = "Select * from TblClass";
			if (AddNew)
			{
				if( FieldClassChecking(row))
				{
					this.gridControlMD_Class.MainView.UpdateCurrentRow();
					try
					{
						CreateCmdsAndUpdate(strSQL,dtClass);
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
				gridViewMd_Class.CloseEditor();
				gridViewMd_Class.UpdateCurrentRow();

				CreateCmdsAndUpdate(strSQL,dtClass);
			}
		}
	}
}
