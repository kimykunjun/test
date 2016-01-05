using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace ACMS.Utils
{
	/// <summary>
	/// Summary description for SqlHelperUtils.
	/// </summary>
	public class SqlHelperUtils
	{
		public static string connectionString = ConfigurationSettings.AppSettings["Main.ConnectionString"];
		public static SqlParameter paramErrorCode = new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, new Int32());

		private SqlHelperUtils()
		{
		}

		private static SqlConnection GetConnection(string connString)
		{
			SqlConnection connection = new SqlConnection(connectionString);
			connection.Open();

			return connection;
		}

		public static string ToSingleQuoteString(string aStr)
		{
			return aStr.Replace("'", "''");
		}

		public static void ExecuteNonQuerySP(string spName, params SqlParameter[] commandParameters)
		{
			SqlConnection con = new SqlConnection(SqlHelperUtils.connectionString);

			try
			{
				con.Open();
				SqlHelper.ExecuteNonQuery(con, spName, commandParameters);
			}
			finally
			{
				con.Close();
				con.Dispose();
			}
		}

		public static DataTable ExecuteDataTableSP(string spName, params SqlParameter[] commandParameters)
		{
			return ExecuteDatasetSP(spName, commandParameters).Tables[0];
		}

		public static DataSet ExecuteDatasetSP(string spName, params SqlParameter[] commandParameters)
		{
			// SqlConnection that will be used to execute the sql commands
			SqlConnection connection = null;

			try
			{
				try
				{
					connection = GetConnection(connectionString);
				}
				catch
				{
					throw;
				}

				// DataSet that will hold the returned results
				DataSet ds;
			
				// Call ExecuteDataset static method of SqlHelper class that returns a Dataset
				ds = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, commandParameters);
						
				return ds;
			}
			catch//(Exception ex)
			{
				throw;
			}
			finally
			{
				if(connection != null)
					connection.Dispose();
			}
		}

		public static DataTable ExecuteDataTableText(string cmdtxt, params SqlParameter[] commandParameters)
		{
			return ExecuteDatasetText(cmdtxt, commandParameters).Tables[0];
		}

		public static DataSet ExecuteDatasetText(string cmdtxt, params SqlParameter[] commandParameters)
		{
			// SqlConnection that will be used to execute the sql commands
			SqlConnection connection = null;

			try
			{
				try
				{
					connection = GetConnection(connectionString);
				}
				catch
				{
					throw;
				}

				// DataSet that will hold the returned results
				DataSet ds;
			
				// Call ExecuteDataset static method of SqlHelper class that returns a Dataset
				ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, cmdtxt, commandParameters);
						
				return ds;
			}
			catch//(Exception ex)
			{
				throw;
			}
			finally
			{
				if(connection != null)
					connection.Dispose();
			}
		}

	
		public static void BuildCommandObjects(string conString, string cmdtxt, ref SqlCommand insertCmd, ref SqlCommand updateCmd, ref SqlCommand deleteCmd)
		{
			if ((conString == null) || (conString.Trim().Length == 0)) throw new ArgumentNullException( "conString" );
			if ((cmdtxt == null) || (cmdtxt.Length == 0)) throw new ArgumentNullException( "cmdtxt" );

			try
			{
				using (SqlConnection sqlConnection = new SqlConnection(conString))
				{
					using (SqlDataAdapter dataAdapter = new SqlDataAdapter(cmdtxt, sqlConnection))
					{
						using (SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(dataAdapter))
						{
							insertCmd = cmdBuilder.GetInsertCommand();
							updateCmd = cmdBuilder.GetUpdateCommand();
							deleteCmd = cmdBuilder.GetDeleteCommand();
						}
					}
				}
			}
			catch //(Exception ex)
			{
				throw;// new MyException(string.Format("Building command objects for table {0} failed", tableName), ex);
			}
		}

		/// <summary>
		/// Update DataSet with transaction support for ONE table only.
		/// </summary>
		/// <param name="ds"></param>
		/// <param name="cmdtxt"></param>
		public static void UpdateDataSetSingleTableWithTransaction(DataSet ds, string cmdtxt)
		{
			SqlCommand insertCommand = new SqlCommand();
			SqlCommand updateCommand = new SqlCommand();
			SqlCommand deleteCommand = new SqlCommand();
			BuildCommandObjects(connectionString, cmdtxt, ref insertCommand, ref updateCommand, ref deleteCommand);
			SqlConnection conn = null;

			try
			{
				try
				{
					conn = GetConnection(connectionString);
				}
				catch
				{
					throw;
				}
				insertCommand.Connection = conn;
				updateCommand.Connection = conn;
				deleteCommand.Connection = conn;
				SqlHelper.ExecuteScalar(conn, CommandType.Text, "BEGIN TRAN");
				// Update the data source with the DataSet changes
				SqlHelper.UpdateDataset(insertCommand, deleteCommand, updateCommand, ds, ds.Tables[0].TableName);
				SqlHelper.ExecuteScalar(conn, CommandType.Text, "COMMIT TRAN");
			}
			catch//(Exception ex)
			{
				try
				{
					SqlHelper.ExecuteScalar(conn, CommandType.Text, "ROLLBACK TRAN");
				}
				catch {}
				throw;
			}
			finally
			{
				if(conn != null)
					conn.Dispose();
			}
		}

		public static void UpdateDataSetTwoTableWithTransaction(DataSet ds, string cmdtxt1, DataSet ds2, string cmdtxt2)
		{
			SqlCommand insertCommand = new SqlCommand();
			SqlCommand updateCommand = new SqlCommand();
			SqlCommand deleteCommand = new SqlCommand();
			BuildCommandObjects(connectionString, cmdtxt1, ref insertCommand, ref updateCommand, ref deleteCommand);
			SqlCommand insertCommand2 = new SqlCommand();
			SqlCommand updateCommand2 = new SqlCommand();
			SqlCommand deleteCommand2 = new SqlCommand();
			BuildCommandObjects(connectionString, cmdtxt2, ref insertCommand2, ref updateCommand2, ref deleteCommand2);
			SqlConnection conn = null;

			try
			{
				try
				{
					conn = GetConnection(connectionString);
				}
				catch
				{
					throw;
				}
				insertCommand.Connection = conn;
				updateCommand.Connection = conn;
				deleteCommand.Connection = conn;
				insertCommand2.Connection = conn;
				updateCommand2.Connection = conn;
				deleteCommand2.Connection = conn;
				SqlHelper.ExecuteScalar(conn, CommandType.Text, "BEGIN TRAN");
				// Update the data source with the DataSet changes
				SqlHelper.UpdateDataset(insertCommand, deleteCommand, updateCommand, ds, ds.Tables[0].TableName);
				SqlHelper.UpdateDataset(insertCommand2, deleteCommand2, updateCommand2, ds2, ds2.Tables[0].TableName);
				SqlHelper.ExecuteScalar(conn, CommandType.Text, "COMMIT TRAN");
			}
			catch//(Exception ex)
			{
				try
				{
					SqlHelper.ExecuteScalar(conn, CommandType.Text, "ROLLBACK TRAN");
				}
				catch {}
				throw;
			}
			finally
			{
				if(conn != null)
					conn.Dispose();
			}
		}
	}
}
