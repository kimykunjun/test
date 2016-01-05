using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace ACMSDAL
{
	public class DBAccess : ACMSDAL.DBInteractionBase
	{
		internal DBAccess()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	
		internal DataTable Query(string cmdText)
		{
			return base.LoadData(cmdText);
		}
	
		public new static DataTable LoadData(string cmdText)
		{
			DBAccess access = null;
			try
			{
				access = new DBAccess();
				return access.Query(cmdText);
			}
			finally
			{
				if (access != null)
					access.Dispose();
			}
		}
	}

	/// <summary>
	/// Summary description for Common.
	/// </summary>
	public class Common : DBInteractionBase
	{
		public Common()
		{
		}

		public DataTable SelectDataTable(SqlCommand cmdToExecute)
		{
			DataSet myDataSet = new DataSet();
			this.SelectDataSet(cmdToExecute, myDataSet);
			return myDataSet.Tables[0];
		}

		public DataSet SelectDataSet(SqlCommand cmdToExecute)
		{
			DataSet myDataSet = new DataSet();
			this.SelectDataSet(cmdToExecute, myDataSet);
			return myDataSet;
		}

		public DataSet SelectDataSet(SqlCommand cmdToExecute, DataSet toReturn)
		{
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				if(_mainConnectionIsCreatedLocal)
				{
					// Open connection.
					_mainConnection.Open();
				}
				else
				{
					if(_mainConnectionProvider.IsTransactionPending)
					{
						cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
					}
				}

				// Execute query.
				adapter.Fill(toReturn);
				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("Common::Select::Error occured.", ex);
			}
			finally
			{
				if(_mainConnectionIsCreatedLocal)
				{
					// Close connection.
					_mainConnection.Close();
				}
				cmdToExecute.Dispose();
				adapter.Dispose();
			}
		}
	}
}
