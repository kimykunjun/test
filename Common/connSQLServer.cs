using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
//using System.Data;
using System.Data.SqlClient;

namespace ACMS
{
	
	
	public class ConnectionString
	{
		
		string connstring;
		private string userId;
		private string password;
		private string dataSource;
		private string dataBase;
		
		public ConnectionString() {
			DataSet ds = new DataSet();
			ds.ReadXml("../connectionstring.xml");
			userId = System.Convert.ToString(ds.Tables[0].Rows[0][0]);
			password = System.Convert.ToString(ds.Tables[0].Rows[0][1]);
			dataSource = System.Convert.ToString(ds.Tables[0].Rows[0][2]);
			dataBase = System.Convert.ToString(ds.Tables[0].Rows[0][3]);
		}
		
		public string getConnstring()
		{
			connstring = "server=" + dataSource + ";uid=" + userId + ";pwd=" + password + ";database=" + dataBase;
			return connstring;
		}
		
		public string getUID()
		{
			return userId;
		}
		
		public string getPwd()
		{
			return password;
		}
		
		public string getdatasource()
		{
			return dataSource;
		}
	}
	
	
}
