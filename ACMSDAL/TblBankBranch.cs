///////////////////////////////////////////////////////////////////////////
// Description: Data Access class for the table 'tblBankBranch'
// Generated by LLBLGen v1.21.2003.712 Final on: 2005年12月17日, 20:14:04
// Because the Base Class already implements IDispose, this class doesn't.
///////////////////////////////////////////////////////////////////////////
using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace ACMSDAL
{
	/// <summary>
	/// Purpose: Data Access class for the table 'tblBankBranch'.
	/// </summary>
	public class TblBankBranch : DBInteractionBase
	{
		#region Class Member Declarations
			private SqlString		_strDescription, _strBankCode, _strBankBranchCode;
		#endregion


		/// <summary>
		/// Purpose: Class constructor.
		/// </summary>
		public TblBankBranch()
		{
			// Nothing for now.
		}


		/// <summary>
		/// Purpose: Insert method. This method will insert one new row into the database.
		/// </summary>
		/// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>StrBankBranchCode</LI>
		///		 <LI>StrBankCode</LI>
		///		 <LI>StrDescription. May be SqlString.Null</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ErrorCode</LI>
		/// </UL>
		/// </remarks>
		public override bool Insert()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_tblBankBranch_Insert]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@sstrBankBranchCode", SqlDbType.Char, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _strBankBranchCode));
				cmdToExecute.Parameters.Add(new SqlParameter("@sstrBankCode", SqlDbType.Char, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _strBankCode));
				cmdToExecute.Parameters.Add(new SqlParameter("@sstrDescription", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _strDescription));
				cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

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
				_rowsAffected = cmdToExecute.ExecuteNonQuery();
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'sp_tblBankBranch_Insert' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("TblBankBranch::Insert::Error occured.", ex);
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


		/// <summary>
		/// Purpose: Update method. This method will Update one existing row in the database.
		/// </summary>
		/// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>StrBankBranchCode</LI>
		///		 <LI>StrBankCode</LI>
		///		 <LI>StrDescription. May be SqlString.Null</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ErrorCode</LI>
		/// </UL>
		/// </remarks>
		public override bool Update()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_tblBankBranch_Update]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@sstrBankBranchCode", SqlDbType.Char, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _strBankBranchCode));
				cmdToExecute.Parameters.Add(new SqlParameter("@sstrBankCode", SqlDbType.Char, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _strBankCode));
				cmdToExecute.Parameters.Add(new SqlParameter("@sstrDescription", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _strDescription));
				cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

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
				_rowsAffected = cmdToExecute.ExecuteNonQuery();
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'sp_tblBankBranch_Update' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("TblBankBranch::Update::Error occured.", ex);
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


		/// <summary>
		/// Purpose: Delete method. This method will Delete one existing row in the database, based on the Primary Key.
		/// </summary>
		/// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>StrBankBranchCode</LI>
		///		 <LI>StrBankCode</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ErrorCode</LI>
		/// </UL>
		/// </remarks>
		public override bool Delete()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_tblBankBranch_Delete]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@sstrBankBranchCode", SqlDbType.Char, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _strBankBranchCode));
				cmdToExecute.Parameters.Add(new SqlParameter("@sstrBankCode", SqlDbType.Char, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _strBankCode));
				cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

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
				_rowsAffected = cmdToExecute.ExecuteNonQuery();
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'sp_tblBankBranch_Delete' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("TblBankBranch::Delete::Error occured.", ex);
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


		/// <summary>
		/// Purpose: Delete method using PK field 'strBankBranchCode'. This method will 
		/// delete one or more rows from the database, based on the Primary Key field 'strBankBranchCode'.
		/// </summary>
		/// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>StrBankBranchCode</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ErrorCode</LI>
		/// </UL>
		/// </remarks>
		public bool DeleteAllWstrBankBranchCodeLogic()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_tblBankBranch_DeleteAllWstrBankBranchCodeLogic]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@sstrBankBranchCode", SqlDbType.Char, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _strBankBranchCode));
				cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 0, 0, "", DataRowVersion.Proposed, _errorCode));

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
				_rowsAffected = cmdToExecute.ExecuteNonQuery();
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'sp_tblBankBranch_DeleteAllWstrBankBranchCodeLogic' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("TblBankBranch::DeleteAllWstrBankBranchCodeLogic::Error occured.", ex);
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


		/// <summary>
		/// Purpose: Delete method using PK field 'strBankCode'. This method will 
		/// delete one or more rows from the database, based on the Primary Key field 'strBankCode'.
		/// </summary>
		/// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>StrBankCode</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ErrorCode</LI>
		/// </UL>
		/// </remarks>
		public bool DeleteAllWstrBankCodeLogic()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_tblBankBranch_DeleteAllWstrBankCodeLogic]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@sstrBankCode", SqlDbType.Char, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _strBankCode));
				cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 0, 0, "", DataRowVersion.Proposed, _errorCode));

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
				_rowsAffected = cmdToExecute.ExecuteNonQuery();
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'sp_tblBankBranch_DeleteAllWstrBankCodeLogic' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("TblBankBranch::DeleteAllWstrBankCodeLogic::Error occured.", ex);
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


		/// <summary>
		/// Purpose: Select method. This method will Select one existing row from the database, based on the Primary Key.
		/// </summary>
		/// <returns>DataTable object if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>StrBankBranchCode</LI>
		///		 <LI>StrBankCode</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ErrorCode</LI>
		///		 <LI>StrBankBranchCode</LI>
		///		 <LI>StrBankCode</LI>
		///		 <LI>StrDescription</LI>
		/// </UL>
		/// Will fill all properties corresponding with a field in the table with the value of the row selected.
		/// </remarks>
		public override DataTable SelectOne()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_tblBankBranch_SelectOne]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("tblBankBranch");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@sstrBankBranchCode", SqlDbType.Char, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _strBankBranchCode));
				cmdToExecute.Parameters.Add(new SqlParameter("@sstrBankCode", SqlDbType.Char, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _strBankCode));
				cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

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
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'sp_tblBankBranch_SelectOne' reported the ErrorCode: " + _errorCode);
				}

				if(toReturn.Rows.Count > 0)
				{
					_strBankBranchCode = (string)toReturn.Rows[0]["strBankBranchCode"];
					_strBankCode = (string)toReturn.Rows[0]["strBankCode"];
					_strDescription = toReturn.Rows[0]["strDescription"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["strDescription"];
				}
				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("TblBankBranch::SelectOne::Error occured.", ex);
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


		/// <summary>
		/// Purpose: SelectAll method. This method will Select all rows from the table.
		/// </summary>
		/// <returns>DataTable object if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ErrorCode</LI>
		/// </UL>
		/// </remarks>
		public override DataTable SelectAll()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_tblBankBranch_SelectAll]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("tblBankBranch");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

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
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'sp_tblBankBranch_SelectAll' reported the ErrorCode: " + _errorCode);
				}

				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("TblBankBranch::SelectAll::Error occured.", ex);
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


		/// <summary>
		/// Purpose: Select method for a foreign key. This method will Select one or more rows from the database, based on the Foreign Key 'strBankCode'
		/// </summary>
		/// <returns>DataTable object if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>StrBankCode</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ErrorCode</LI>
		/// </UL>
		/// </remarks>
		public DataTable SelectAllWstrBankCodeLogic()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_tblBankBranch_SelectAllWstrBankCodeLogic]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("tblBankBranch");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@sstrBankCode", SqlDbType.Char, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _strBankCode));
				cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 0, 0, "", DataRowVersion.Proposed, _errorCode));

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
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'sp_tblBankBranch_SelectAllWstrBankCodeLogic' reported the ErrorCode: " + _errorCode);
				}

				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("TblBankBranch::SelectAllWstrBankCodeLogic::Error occured.", ex);
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


		#region Class Property Declarations
		public SqlString StrBankBranchCode
		{
			get
			{
				return _strBankBranchCode;
			}
			set
			{
				SqlString strBankBranchCodeTmp = (SqlString)value;
				if(strBankBranchCodeTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("StrBankBranchCode", "StrBankBranchCode can't be NULL");
				}
				_strBankBranchCode = value;
			}
		}


		public SqlString StrBankCode
		{
			get
			{
				return _strBankCode;
			}
			set
			{
				SqlString strBankCodeTmp = (SqlString)value;
				if(strBankCodeTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("StrBankCode", "StrBankCode can't be NULL");
				}
				_strBankCode = value;
			}
		}


		public SqlString StrDescription
		{
			get
			{
				return _strDescription;
			}
			set
			{
				_strDescription = value;
			}
		}
		#endregion
	}
}
