using System;
using System.Text;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;
using Do = Acms.Core.Domain;
using ACMSLogic;
using ACMS.Utils;
using System.IO;
using System.Data.OleDb;

namespace ACMS.ACMSManager.Operation
{
	/// <summary>
	/// Summary description for frmRoadShow.
	/// </summary>
	public class frmRoadShow : System.Windows.Forms.Form
	{
		[DllImport("odbc32.dll")]
		private static extern short SQLAllocHandle(short hType, IntPtr inputHandle, out IntPtr outputHandle);
		[DllImport("odbc32.dll")]
		private static extern short SQLSetEnvAttr(IntPtr henv, int attribute, IntPtr valuePtr, int strLength);
		[DllImport("odbc32.dll")]
		private static extern short SQLFreeHandle(short hType, IntPtr handle); 
		[DllImport("odbc32.dll",CharSet=CharSet.Ansi)]
		private static extern short SQLBrowseConnect(IntPtr hconn, StringBuilder inString, 
			short inStringLength, StringBuilder outString, short outStringLength,
			out short outLengthNeeded);

		private const short SQL_HANDLE_ENV = 1;
		private const short SQL_HANDLE_DBC = 2;
		private const int SQL_ATTR_ODBC_VERSION = 200;
		private const int SQL_OV_ODBC3 = 3;
		private const short SQL_SUCCESS = 0;
		
		private const short SQL_NEED_DATA = 99;
		private const short DEFAULT_RESULT_SIZE = 1024;
		private const string SQL_DRIVER_STR = "DRIVER=SQL SERVER";

		private string connectionString;
		private SqlConnection connection;
		private static Do.Employee employee;
		private static Do.TerminalUser terminalUser;
		private static User oUser;
		private DevExpress.XtraEditors.GroupControl groupControl1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private DevExpress.XtraTab.XtraTabControl xtraTabControl3;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
		internal DevExpress.XtraEditors.SimpleButton btnExport;
		private System.Windows.Forms.Label label40;
		internal DevExpress.XtraEditors.SimpleButton btnBrowse;
		private DevExpress.XtraEditors.TextEdit FilePath;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage4;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		internal DevExpress.XtraEditors.SimpleButton btnReplicate;
		private DevExpress.XtraEditors.TextEdit txtSourceServer;
		private DevExpress.XtraEditors.DateEdit dtDate;
		internal DevExpress.XtraEditors.SimpleButton btnTargetServer;
		private DevExpress.XtraEditors.TextEdit txtTargetServer;
		internal DevExpress.XtraEditors.SimpleButton btnSourceServer;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmRoadShow()
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
			this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
			this.xtraTabControl3 = new DevExpress.XtraTab.XtraTabControl();
			this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
			this.btnExport = new DevExpress.XtraEditors.SimpleButton();
			this.label40 = new System.Windows.Forms.Label();
			this.btnBrowse = new DevExpress.XtraEditors.SimpleButton();
			this.FilePath = new DevExpress.XtraEditors.TextEdit();
			this.xtraTabPage4 = new DevExpress.XtraTab.XtraTabPage();
			this.btnReplicate = new DevExpress.XtraEditors.SimpleButton();
			this.label3 = new System.Windows.Forms.Label();
			this.dtDate = new DevExpress.XtraEditors.DateEdit();
			this.btnTargetServer = new DevExpress.XtraEditors.SimpleButton();
			this.txtTargetServer = new DevExpress.XtraEditors.TextEdit();
			this.label2 = new System.Windows.Forms.Label();
			this.btnSourceServer = new DevExpress.XtraEditors.SimpleButton();
			this.txtSourceServer = new DevExpress.XtraEditors.TextEdit();
			this.label1 = new System.Windows.Forms.Label();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
			this.groupControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.xtraTabControl3)).BeginInit();
			this.xtraTabControl3.SuspendLayout();
			this.xtraTabPage3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.FilePath.Properties)).BeginInit();
			this.xtraTabPage4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dtDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtTargetServer.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtSourceServer.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// groupControl1
			// 
			this.groupControl1.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.groupControl1.Appearance.Options.UseBackColor = true;
			this.groupControl1.Controls.Add(this.xtraTabControl3);
			this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupControl1.Location = new System.Drawing.Point(0, 0);
			this.groupControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
			this.groupControl1.Name = "groupControl1";
			this.groupControl1.Size = new System.Drawing.Size(912, 525);
			this.groupControl1.TabIndex = 124;
			this.groupControl1.Text = "Road Show";
			// 
			// xtraTabControl3
			// 
			this.xtraTabControl3.Location = new System.Drawing.Point(8, 48);
			this.xtraTabControl3.Name = "xtraTabControl3";
			this.xtraTabControl3.SelectedTabPage = this.xtraTabPage3;
			this.xtraTabControl3.Size = new System.Drawing.Size(720, 300);
			this.xtraTabControl3.TabIndex = 119;
			this.xtraTabControl3.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
																							this.xtraTabPage3,
																							this.xtraTabPage4});
			this.xtraTabControl3.Text = "xtraTabControl3";
			// 
			// xtraTabPage3
			// 
			this.xtraTabPage3.Controls.Add(this.btnExport);
			this.xtraTabPage3.Controls.Add(this.label40);
			this.xtraTabPage3.Controls.Add(this.btnBrowse);
			this.xtraTabPage3.Controls.Add(this.FilePath);
			this.xtraTabPage3.Name = "xtraTabPage3";
			this.xtraTabPage3.Size = new System.Drawing.Size(711, 270);
			this.xtraTabPage3.Text = "Export Roadshow Data";
			// 
			// btnExport
			// 
			this.btnExport.Appearance.BackColor = System.Drawing.Color.LightGray;
			this.btnExport.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.btnExport.Appearance.Options.UseBackColor = true;
			this.btnExport.Appearance.Options.UseFont = true;
			this.btnExport.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnExport.Location = new System.Drawing.Point(224, 96);
			this.btnExport.Name = "btnExport";
			this.btnExport.Size = new System.Drawing.Size(144, 20);
			this.btnExport.TabIndex = 14;
			this.btnExport.Text = "Export";
			this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
			// 
			// label40
			// 
			this.label40.Location = new System.Drawing.Point(96, 56);
			this.label40.Name = "label40";
			this.label40.Size = new System.Drawing.Size(112, 23);
			this.label40.TabIndex = 13;
			this.label40.Text = "Target BackUp";
			// 
			// btnBrowse
			// 
			this.btnBrowse.Appearance.BackColor = System.Drawing.Color.LightGray;
			this.btnBrowse.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.btnBrowse.Appearance.Options.UseBackColor = true;
			this.btnBrowse.Appearance.Options.UseFont = true;
			this.btnBrowse.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnBrowse.Location = new System.Drawing.Point(520, 56);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(80, 20);
			this.btnBrowse.TabIndex = 12;
			this.btnBrowse.Text = "Browse";
			this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// FilePath
			// 
			this.FilePath.EditValue = "";
			this.FilePath.Location = new System.Drawing.Point(224, 56);
			this.FilePath.Name = "FilePath";
			this.FilePath.Size = new System.Drawing.Size(288, 20);
			this.FilePath.TabIndex = 0;
			// 
			// xtraTabPage4
			// 
			this.xtraTabPage4.Controls.Add(this.btnReplicate);
			this.xtraTabPage4.Controls.Add(this.label3);
			this.xtraTabPage4.Controls.Add(this.dtDate);
			this.xtraTabPage4.Controls.Add(this.btnTargetServer);
			this.xtraTabPage4.Controls.Add(this.txtTargetServer);
			this.xtraTabPage4.Controls.Add(this.label2);
			this.xtraTabPage4.Controls.Add(this.btnSourceServer);
			this.xtraTabPage4.Controls.Add(this.txtSourceServer);
			this.xtraTabPage4.Controls.Add(this.label1);
			this.xtraTabPage4.Name = "xtraTabPage4";
			this.xtraTabPage4.Size = new System.Drawing.Size(716, 274);
			this.xtraTabPage4.Text = "Replicate Roadshow Data";
			// 
			// btnReplicate
			// 
			this.btnReplicate.Appearance.BackColor = System.Drawing.Color.LightGray;
			this.btnReplicate.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.btnReplicate.Appearance.Options.UseBackColor = true;
			this.btnReplicate.Appearance.Options.UseFont = true;
			this.btnReplicate.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnReplicate.Location = new System.Drawing.Point(200, 144);
			this.btnReplicate.Name = "btnReplicate";
			this.btnReplicate.Size = new System.Drawing.Size(144, 20);
			this.btnReplicate.TabIndex = 22;
			this.btnReplicate.Text = "Replicate";
			this.btnReplicate.Click += new System.EventHandler(this.btnReplicate_Click);
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label3.Location = new System.Drawing.Point(88, 96);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 23);
			this.label3.TabIndex = 21;
			this.label3.Text = "Date";
			// 
			// dtDate
			// 
			this.dtDate.EditValue = null;
			this.dtDate.Location = new System.Drawing.Point(200, 96);
			this.dtDate.Name = "dtDate";
			// 
			// dtDate.Properties
			// 
			this.dtDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																										   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dtDate.Size = new System.Drawing.Size(136, 20);
			this.dtDate.TabIndex = 20;
			// 
			// btnTargetServer
			// 
			this.btnTargetServer.Appearance.BackColor = System.Drawing.Color.LightGray;
			this.btnTargetServer.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.btnTargetServer.Appearance.Options.UseBackColor = true;
			this.btnTargetServer.Appearance.Options.UseFont = true;
			this.btnTargetServer.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnTargetServer.Location = new System.Drawing.Point(496, 64);
			this.btnTargetServer.Name = "btnTargetServer";
			this.btnTargetServer.Size = new System.Drawing.Size(80, 20);
			this.btnTargetServer.TabIndex = 19;
			this.btnTargetServer.Text = "Browse";
			this.btnTargetServer.Click += new System.EventHandler(this.btnTargetServer_Click);
			// 
			// txtTargetServer
			// 
			this.txtTargetServer.EditValue = "";
			this.txtTargetServer.Location = new System.Drawing.Point(200, 64);
			this.txtTargetServer.Name = "txtTargetServer";
			this.txtTargetServer.Size = new System.Drawing.Size(288, 20);
			this.txtTargetServer.TabIndex = 18;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.Location = new System.Drawing.Point(88, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(96, 23);
			this.label2.TabIndex = 17;
			this.label2.Text = "Target Server";
			// 
			// btnSourceServer
			// 
			this.btnSourceServer.Appearance.BackColor = System.Drawing.Color.LightGray;
			this.btnSourceServer.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.btnSourceServer.Appearance.Options.UseBackColor = true;
			this.btnSourceServer.Appearance.Options.UseFont = true;
			this.btnSourceServer.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnSourceServer.Location = new System.Drawing.Point(496, 32);
			this.btnSourceServer.Name = "btnSourceServer";
			this.btnSourceServer.Size = new System.Drawing.Size(80, 20);
			this.btnSourceServer.TabIndex = 16;
			this.btnSourceServer.Text = "Browse";
			this.btnSourceServer.Click += new System.EventHandler(this.simpleButton1_Click);
			// 
			// txtSourceServer
			// 
			this.txtSourceServer.EditValue = "";
			this.txtSourceServer.Location = new System.Drawing.Point(200, 32);
			this.txtSourceServer.Name = "txtSourceServer";
			this.txtSourceServer.Size = new System.Drawing.Size(288, 20);
			this.txtSourceServer.TabIndex = 15;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(88, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(112, 23);
			this.label1.TabIndex = 14;
			this.label1.Text = "Source Server";
			// 
			// frmRoadShow
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(912, 525);
			this.ControlBox = false;
			this.Controls.Add(this.groupControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmRoadShow";
			this.Text = "frmRoadShow";
			this.Load += new System.EventHandler(this.frmRoadShow_Load);
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
			this.groupControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.xtraTabControl3)).EndInit();
			this.xtraTabControl3.ResumeLayout(false);
			this.xtraTabPage3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.FilePath.Properties)).EndInit();
			this.xtraTabPage4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dtDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtTargetServer.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtSourceServer.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region security
		public void initData (ACMSLogic.User User)
		{
			oUser = User;
			MemberRecord myMemberRecord = new MemberRecord(oUser.StrBranchCode());
		}

		public void SetEmployeeRecord(Do.Employee emp)
		{
			employee = emp;
		}

		public void SetTerminalUser(Do.TerminalUser tu)
		{
			terminalUser = tu;

		}

		
		#endregion

		public static string[] GetServers()
		{
			string[] retval = null;
			string txt = string.Empty;
			IntPtr henv = IntPtr.Zero;
			IntPtr hconn = IntPtr.Zero;
			StringBuilder inString = new StringBuilder(SQL_DRIVER_STR);
			StringBuilder outString = new StringBuilder(DEFAULT_RESULT_SIZE);
			short inStringLength = (short) inString.Length;
			short lenNeeded = 0;

			try
			{
				if (SQL_SUCCESS == SQLAllocHandle(SQL_HANDLE_ENV, henv, out henv))
				{
					if (SQL_SUCCESS == SQLSetEnvAttr(henv,SQL_ATTR_ODBC_VERSION,(IntPtr)SQL_OV_ODBC3,0))
					{
						if (SQL_SUCCESS == SQLAllocHandle(SQL_HANDLE_DBC, henv, out hconn))
						{
							if (SQL_NEED_DATA ==  SQLBrowseConnect(hconn, inString, inStringLength, outString, 
								DEFAULT_RESULT_SIZE, out lenNeeded))
							{
								if (DEFAULT_RESULT_SIZE < lenNeeded)
								{
									outString.Capacity = lenNeeded;
									if (SQL_NEED_DATA != SQLBrowseConnect(hconn, inString, inStringLength, outString, 
										lenNeeded,out lenNeeded))
									{
										throw new ApplicationException("Unabled to aquire SQL Servers from ODBC driver.");
									}	
								}
								txt = outString.ToString();
								int start = txt.IndexOf("{") + 1;
								int len = txt.IndexOf("}") - start;
								if ((start > 0) && (len > 0))
								{
									txt = txt.Substring(start,len);
								}
								else
								{
									txt = string.Empty;
								}
							}						
						}
					}
				}
			}
			catch (Exception ex)
			{
				//Throw away any error if we are not in debug mode
#if (DEBUG)
				MessageBox.Show(ex.Message,"Acquire SQL Servier List Error");
#endif 
				txt = string.Empty;
			}
			finally
			{
				if (hconn != IntPtr.Zero)
				{
					SQLFreeHandle(SQL_HANDLE_DBC,hconn);
				}
				if (henv != IntPtr.Zero)
				{
					SQLFreeHandle(SQL_HANDLE_ENV,hconn);
				}
			}
	
			if (txt.Length > 0)
			{
				retval = txt.Split(",".ToCharArray());
			}

			return retval;
		}


		private void btnReplicate_Click(object sender, System.EventArgs e)
		{
			string MemberNo = "";
			string OrigMember = "";

			if (txtSourceServer.EditValue.ToString() == "")
			{
				MessageBox.Show("Please select server source.","Source Server");
				return;
			}
			if (txtTargetServer.EditValue.ToString() == "")
			{
				MessageBox.Show("Please select server target.","Target Server");
				return;
			}
			if (dtDate.EditValue == null || dtDate.EditValue.ToString() == "")
			{
				MessageBox.Show("Please select the date.","Date");
				return;
			}

			string sql = "Select nBeforeBlocknMembershipID, nMembershipNo from tblBranch Where strBranchCode = '" + oUser.StrBranchCode() + "'";
			
			DataSet _ds = new DataSet();

			SqlHelper.FillDataset(connection,CommandType.Text,sql,_ds,new string[] {"table"}, new SqlParameter("@sstrKey", sql));
			DataTable dt = _ds.Tables["table"];
			
			MemberNo = dt.Rows[0]["nMembershipNo"].ToString();
			OrigMember = dt.Rows[0]["nBeforeBlocknMembershipID"].ToString();

			if (OrigMember == "")
			{
				MessageBox.Show("Original Member Id cannot be null.","Member Id");
				return;
			}

			if (MemberNo == "")
			{
				MessageBox.Show("Member Id cannot be null.","Member Id");
				return;
			}

			string sqlConn = connectionString;

			string strReplace = sqlConn.Substring(sqlConn.IndexOf("initial catalog") + 16,sqlConn.IndexOf("UID") - (sqlConn.IndexOf("initial catalog") + 17));
			string SourceTable = "";
			string TargetTable = "";

			SourceTable = txtSourceServer.EditValue.ToString().Replace("(","").Replace(")","");
			TargetTable = txtTargetServer.EditValue.ToString().Replace("(","").Replace(")","");

			if (SourceTable != "local")
				SourceTable = "[" + SourceTable + "]" + "." + strReplace + ".dbo";
			else
				SourceTable = strReplace + ".dbo";

			if (TargetTable != "local")
				TargetTable = "[" + TargetTable + "]" + "." + strReplace + ".dbo";
			else
				TargetTable = strReplace + ".dbo";
		
			SqlConnection sqlcon = new SqlConnection(connectionString);
			sqlcon.Open();

			SqlTransaction trans = sqlcon.BeginTransaction();

			try
			{
		
				SqlHelper.ExecuteNonQuery(trans,"sp_RoadShowSynchronize",
					new SqlParameter("@BranchCode",oUser.StrBranchCode()), 
					new SqlParameter("@SourceTable",SourceTable ), 
					new SqlParameter("@TargetTable",TargetTable ), 
					new SqlParameter("@Date",this.dtDate.DateTime.ToString("yyyy-MM-dd").ToString() ), 
					new SqlParameter("@FirstNo",OrigMember ), 
					new SqlParameter("@LastNo",MemberNo));
			}
			catch(Exception ex)
			{
				trans.Rollback();
				sqlcon.Close();
				MessageBox.Show(ex.Message ,"Replication Failed");
				return;
			}
			trans.Commit();
			sqlcon.Close();
			MessageBox.Show("Data Replicated." ,"Replication");
			
		}

		private void frmRoadShow_Load(object sender, System.EventArgs e)
		{
			GetServers();
		}

		public DataTable GetUserDatabaseList()
		{
			//data source=localhost;initial catalog=ACMS_0706;UID=sa;PWD=sa
			string sqlConn = connectionString;
		
			int a = sqlConn.IndexOf("initial catalog");
			int c = sqlConn.IndexOf("UID");
			int b = sqlConn.IndexOf("UID") - a;
				
			string str = sqlConn.Substring(22 + 16,48 - 39);
			string strReplace = sqlConn.Substring(sqlConn.IndexOf("initial catalog") + 16,sqlConn.IndexOf("UID") - (sqlConn.IndexOf("initial catalog") + 17));
			
			sqlConn = sqlConn.Replace(strReplace,"localhost");

			DataTable table2;
			SqlConnection connection1 = new SqlConnection(sqlConn);

			try
			{
				connection1.Open();
				SqlCommand command1 = new SqlCommand("SELECT Name FROM master.dbo.sysdatabases WHERE name NOT IN ('master', 'model', 'msdb', 'tempdb')", connection1);
				SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
				DataTable table1 = new DataTable();
				adapter1.Fill(table1);
				table2 = table1;
			}
			catch (SqlException)
			{
//				DataError.HandleSqlException(exception1);
				table2 = null;
			}
			finally
			{
				connection1.Close();
				connection1.Dispose();
			}
			return table2;
		}

		private void simpleButton1_Click(object sender, System.EventArgs e)
		{
			ServerSource myForm = new ServerSource();
			if (DialogResult.OK == myForm.ShowDialog(this))
			{
				txtSourceServer.EditValue = myForm.StrSource;
			}
			myForm.Dispose();

		}

		private void btnTargetServer_Click(object sender, System.EventArgs e)
		{
			ServerSource myForm = new ServerSource();
			if (DialogResult.OK == myForm.ShowDialog(this))
			{
				txtTargetServer.EditValue = myForm.StrSource;
			}
			myForm.Dispose();

		}

		private void btnBrowse_Click(object sender, System.EventArgs e)
		{
			folderBrowserDialog1.ShowDialog();
			FilePath.Text = folderBrowserDialog1.SelectedPath;
			FilePath.Text += @"\ACMS_Back_db.mdf";
		}

		private void btnExport_Click(object sender, System.EventArgs e)
		{
			string sqlConn = connectionString;

			string DB = sqlConn.Substring(sqlConn.IndexOf("initial catalog") + 16,sqlConn.IndexOf("UID") - (sqlConn.IndexOf("initial catalog") + 17));

			string strSQL;
			DataSet _ds;

			strSQL = "select * from master.dbo.sysdevices where phyname = '" + FilePath.Text + "'";
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			
			int index=FilePath.Text.LastIndexOf(@"\"); 

			string FileName = FilePath.Text.Substring(index,FilePath.Text.Length - index);

			object obj = new object[] {FileName, FilePath.Text};
			int output;
			output = 0;

			try
			{
				connection.Open();
				SqlCommand myCmd = new SqlCommand("up_BackUpDatabase", connection);
				myCmd.CommandType = CommandType.StoredProcedure;
				myCmd.CommandTimeout = 300000;
		
				myCmd.Parameters.Add("@retval", output); 
				myCmd.Parameters.Add("@BackUpTo", FilePath.Text); 
				myCmd.Parameters.Add("@DB", DB);
			
				myCmd.ExecuteNonQuery();
				connection.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Info");
			}
			
		}

	}
}




