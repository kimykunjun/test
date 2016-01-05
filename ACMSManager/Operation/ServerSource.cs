using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Runtime.InteropServices;
using System.Configuration;

namespace ACMS.ACMSManager.Operation
{
	/// <summary>
	/// Summary description for ServerSource.
	/// </summary>
	public class ServerSource : System.Windows.Forms.Form
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

		private string strSource; 
		private string connectionString;
		//private SqlConnection connection;
		private DevExpress.XtraEditors.SimpleButton btnPick;
		private DevExpress.XtraEditors.SimpleButton btnCancel;
		private DevExpress.XtraEditors.ListBoxControl lsServer;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public string StrSource
		{
			get {return strSource;}
		}

		public ServerSource()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
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
			this.lsServer = new DevExpress.XtraEditors.ListBoxControl();
			this.btnPick = new DevExpress.XtraEditors.SimpleButton();
			this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.lsServer)).BeginInit();
			this.SuspendLayout();
			// 
			// lsServer
			// 
			this.lsServer.Location = new System.Drawing.Point(0, 0);
			this.lsServer.Name = "lsServer";
			this.lsServer.Size = new System.Drawing.Size(200, 120);
			this.lsServer.TabIndex = 0;
			// 
			// btnPick
			// 
			this.btnPick.Location = new System.Drawing.Point(48, 120);
			this.btnPick.Name = "btnPick";
			this.btnPick.Size = new System.Drawing.Size(48, 16);
			this.btnPick.TabIndex = 1;
			this.btnPick.Text = "Pick";
			this.btnPick.Click += new System.EventHandler(this.btnPick_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(104, 120);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(56, 16);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// ServerSource
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(200, 141);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnPick);
			this.Controls.Add(this.lsServer);
			this.Name = "ServerSource";
			this.Text = "Server List";
			this.Load += new System.EventHandler(this.ServerSource_Load);
			((System.ComponentModel.ISupportInitialize)(this.lsServer)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

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

		private void ServerSource_Load(object sender, System.EventArgs e)
		{
			string[] a = GetServers();
			for (int i = 0; i < a.Length; i ++)
			{
				this.lsServer.Items.Add(a[i].ToString());
			}
        }

		private void btnPick_Click(object sender, System.EventArgs e)
		{
			strSource = lsServer.SelectedItem.ToString();
			
			if (strSource != "")
			{
				this.DialogResult = DialogResult.OK;
			}
		}


	}
}
