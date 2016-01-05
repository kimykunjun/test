using System;
using System.Security;
using System.Data; 
using System.Data.SqlClient;
using ACMSDAL;


namespace ACMS.Utils
{
	/// <summary>
	/// Summary description for Common.
	/// </summary>
	public class Common : DBInteractionBase
	{
		public Common()
		{
			//
			// TODO: Add constructor logic here
			//
		}


		public DataTable ExecuteQuery(string commandText, params object[] parameters) 
		{
			return ExecuteQuery((parameters == null || parameters.Length == 0) ? CommandType.Text : CommandType.StoredProcedure, commandText, "", parameters); 
		}
		//OoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOo 
		
		public DataTable ExecuteQuery(CommandType commandType, string commandText) 
		{
			return ExecuteQuery(commandType, commandText, ""); 
		} 
		//OoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOo 
		public DataTable ExecuteQuery(CommandType commandType, string commandText, string tableName, params object[] parameters) 
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText =commandText;
			
					

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			if (commandType.Equals(CommandType.TableDirect)) 
			{
				cmdToExecute.CommandText = "Select * From " + commandText; 
				cmdToExecute.CommandType = CommandType.Text; 
			} 
			else 
			{ 
				cmdToExecute.CommandType = commandType; 
			} 
			if 
				(commandType.Equals(CommandType.StoredProcedure) && parameters != null && parameters.Length > 0) 
				{ //pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache) 
				SqlParameter[] commandParameters = GetSpParameterSet(cmdToExecute); 
				//assign the provided values to these parameters based on parameter order 
				AssignParameterValues(commandParameters, parameters);	
			}





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


			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);
			DataTable dt = new DataTable(); 
			if (tableName != "") 
				dt.TableName = tableName; 
			try 
			{ 
				adapter.Fill(dt); 
				return dt; 
		//	_errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

//				if(_errorCode != (int)LLBLError.AllOk)
//				{
//					// Throw error.
//					throw new Exception("Stored Procedure 'sp_tblIPP_SelectAll' reported the ErrorCode: " + _errorCode);
//				}
			} 
			catch (Exception e) 
			{ 
				throw new Exception(e.Message + " " + cmdToExecute.CommandText); 
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

		public void ExecuteNonQuery(string commandText, params object[] parameters) 
			{ 
				ExecuteNonQuery((parameters == null || parameters.Length == 0) ? CommandType.Text : CommandType.StoredProcedure, commandText, parameters); 
			} 

			//OoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOo 
		public void ExecuteNonQuery(CommandType commandType, string commandText, params object[] parameters) 
			{

			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = commandText;
			

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

				if (commandType.Equals(CommandType.StoredProcedure) && parameters != null && parameters.Length > 0) 
				{ //pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache) 
					SqlParameter[] commandParameters = GetSpParameterSet(cmdToExecute); 
					//assign the provided values to these parameters based on parameter order 
					AssignParameterValues(commandParameters, parameters);
				} 
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

				cmdToExecute.ExecuteNonQuery(); 
//				_errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;
//
//				if(_errorCode != (int)LLBLError.AllOk)
//				{
//					// Throw error.
//					throw new Exception("Stored Procedure 'sp_tblIPP_UpdateOne' reported the ErrorCode: " + _errorCode);
//				}
				return;
			} 
			catch (Exception e) 
			{ 
				throw new Exception(e.Message + " " + cmdToExecute.CommandText); 
			} 
			finally 
			{ 
				if(_mainConnectionIsCreatedLocal)
				{
					// Close connection.
					_mainConnection.Close();
				}
				cmdToExecute.Dispose(); 
			} 
		}
		//OoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOo //oOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoO //OoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOo 
		public void Insert(string tableName, string[] column, object[] value) 
		{ //check the number of elements 
			if (column.Length != value.Length) 
				throw new Exception("The number of Columns and Values doesn't match."); 
			//building sql statement 
			string sql = "Insert Into " + tableName; 
			string c = ""; 
			string v = ""; 
			int i; 
			for (i=0; i < column.Length; i++) 
			{ 
				c += "[" + column[i] + "], ";
				v += "@" + column[i] + ", "; 
			} 
			sql += " (" + c.Substring(0, c.Length - 2) + ") values (" + v.Substring(0, v.Length - 2) + ")"; 

			//create connection and command to execute the sql statement 
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = sql;
			//cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			for (i=0; i < column.Length; i++) 
				cmdToExecute.Parameters.Add(new SqlParameter("@" + column[i], (value[i]==null) ? DBNull.Value : value[i])); 
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

				cmdToExecute.ExecuteNonQuery(); 
//				_errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;
//
//				if(_errorCode != (int)LLBLError.AllOk)
//				{
//					// Throw error.
//					throw new Exception("Stored Procedure 'sp_tblIPP_UpdateOne' reported the ErrorCode: " + _errorCode);
//				}
				return;
				
			} 
			catch (Exception e) 
			{ 
				throw new Exception(e.Message + " " + cmdToExecute.CommandText); 
			} 
			finally 
			{ 
				if(_mainConnectionIsCreatedLocal)
				{
					// Close connection.
					_mainConnection.Close();
				}
				cmdToExecute.Dispose();
			} 
		} //OoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOo //oOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoO //OoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOo 
		public void Insert(string tableName, string[] column, string query) 
		{ 
			string sql = "Insert Into " + tableName + " ("; 
			for (int i=0; i < column.Length; i++) 
				sql += column[i] + ", "; 
			sql = sql.Substring(0, sql.Length - 2) + ") " + query; 
			ExecuteNonQuery(CommandType.Text, sql); 
		}
		//OoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOo //oOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoO 
	

	//OoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOo 
		public void Update(string tableName, string[] column, object[] value, string criteria) 
		{ 
		//check the number of elements 
		if (column.Length != value.Length) 
		throw new Exception("The number of Columns and Values doesn't match."); 
		//building sql statement 
		string sql = "Update " + tableName + " Set "; 
		int i; 
		for (i=0; i < column.Length; i++) 
		sql += "[" + column[i] + "] = @" + column[i] + ", "; 
		sql = sql.Substring(0, sql.Length - 2); 
		if (criteria != null && criteria != "") 
		sql += " Where " + criteria; 
		//create connection and command to execute the sql statement 

			//create connection and command to execute the sql statement 
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = sql;
			//cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;


		for (i=0; i < column.Length; i++) 
		cmdToExecute.Parameters.Add(new SqlParameter("@" + column[i], (value[i]==null) ? DBNull.Value : value[i])); 

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

			cmdToExecute.ExecuteNonQuery(); 
//			_errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;
//
//			if(_errorCode != (int)LLBLError.AllOk)
//			{
//				// Throw error.
//				throw new Exception("Stored Procedure 'sp_tblIPP_UpdateOne' reported the ErrorCode: " + _errorCode);
//			}
			return;
		} 
		catch (Exception e) 
		{ 
		throw new Exception(e.Message + " " + cmdToExecute.CommandText); 
		} 
		finally 
		{ 
			if(_mainConnectionIsCreatedLocal)
			{
				// Close connection.
				_mainConnection.Close();
			}
			cmdToExecute.Dispose();
		}
		} 
	//OoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOo //oOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoO //OoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOo 
	public void Delete(string tableName, string criteria) 
	{ 
	string sql = "Delete From " + tableName; 
	if (criteria != null && criteria != "") 
	sql += " Where " + criteria; ExecuteNonQuery(CommandType.Text, sql); 
	} 

	//OoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOo //oOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoO //OoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOoOo 

	private SqlParameter[] GetSpParameterSet(SqlCommand cmdToExecute) 
	{
		SqlCommandBuilder.DeriveParameters(cmdToExecute); 
		cmdToExecute.Parameters.RemoveAt(0); 
		//this is return value 
		SqlParameter[] discoveredParameters = new SqlParameter[cmdToExecute.Parameters.Count]; 
		cmdToExecute.Parameters.CopyTo(discoveredParameters, 0); 
		return discoveredParameters; 
		} 
		private void AssignParameterValues(SqlParameter[] commandParameters, object[] parameterValues) 
		{ 
		if ((commandParameters == null) || (parameterValues == null)) 
		{ 
		//do nothing if we get no data 
		return; 
		} 
		// we must have the same number of values as we pave parameters to put them in 
		if (commandParameters.Length != parameterValues.Length) 
		{ 
		throw new ArgumentException("Parameter count does not match Parameter Value count."); 
		} 
		//iterate through the SqlParameters, assigning the values from the corresponding xposition in the 
		//value array 
		for (int i = 0, j = commandParameters.Length; i < j; i++) 
		{ commandParameters[i].Value = (parameterValues[i] == null) ? DBNull.Value : parameterValues[i]; 
		} 
	} 


	//********** Private Function ********** 

	} 
}



