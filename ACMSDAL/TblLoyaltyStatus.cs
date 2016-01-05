///////////////////////////////////////////////////////////////////////////
// Description: Data Access class for the table 'tblLoyaltyStatus'
// Generated by LLBLGen v1.21.2003.712 Final on: 2005年12月17日, 20:14:08
// Because the Base Class already implements IDispose, this class doesn't.
///////////////////////////////////////////////////////////////////////////
using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace ACMSDAL
{
	/// <summary>
	/// Purpose: Data Access class for the table 'tblLoyaltyStatus'.
	/// </summary>
	public class TblLoyaltyStatus : DBInteractionBase
	{
		#region Class Member Declarations
			private SqlInt32		_nDiscountCategoryID, _nDiscountCategoryIDOld, _nLoyaltyStatusID;
			private SqlString		_strDescription;
		#endregion


		/// <summary>
		/// Purpose: Class constructor.
		/// </summary>
		public TblLoyaltyStatus()
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
		///		 <LI>NLoyaltyStatusID</LI>
		///		 <LI>StrDescription. May be SqlString.Null</LI>
		///		 <LI>NDiscountCategoryID</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ErrorCode</LI>
		/// </UL>
		/// </remarks>
		public override bool Insert()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_tblLoyaltyStatus_Insert]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@inLoyaltyStatusID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _nLoyaltyStatusID));
				cmdToExecute.Parameters.Add(new SqlParameter("@sstrDescription", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _strDescription));
				cmdToExecute.Parameters.Add(new SqlParameter("@inDiscountCategoryID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _nDiscountCategoryID));
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
					throw new Exception("Stored Procedure 'sp_tblLoyaltyStatus_Insert' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("TblLoyaltyStatus::Insert::Error occured.", ex);
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
		///		 <LI>NLoyaltyStatusID</LI>
		///		 <LI>StrDescription. May be SqlString.Null</LI>
		///		 <LI>NDiscountCategoryID</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ErrorCode</LI>
		/// </UL>
		/// </remarks>
		public override bool Update()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_tblLoyaltyStatus_Update]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@inLoyaltyStatusID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _nLoyaltyStatusID));
				cmdToExecute.Parameters.Add(new SqlParameter("@sstrDescription", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _strDescription));
				cmdToExecute.Parameters.Add(new SqlParameter("@inDiscountCategoryID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _nDiscountCategoryID));
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
					throw new Exception("Stored Procedure 'sp_tblLoyaltyStatus_Update' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("TblLoyaltyStatus::Update::Error occured.", ex);
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
		/// Purpose: Update method for updating one or more rows using the Foreign Key 'nDiscountCategoryID.
		/// This method will Update one or more existing rows in the database. It will reset the field 'nDiscountCategoryID' in
		/// all rows which have as value for this field the value as set in property 'NDiscountCategoryIDOld' to 
		/// the value as set in property 'NDiscountCategoryID'.
		/// </summary>
		/// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>NDiscountCategoryID</LI>
		///		 <LI>NDiscountCategoryIDOld</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ErrorCode</LI>
		/// </UL>
		/// </remarks>
		public bool UpdateAllWnDiscountCategoryIDLogic()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_tblLoyaltyStatus_UpdateAllWnDiscountCategoryIDLogic]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@inDiscountCategoryID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _nDiscountCategoryID));
				cmdToExecute.Parameters.Add(new SqlParameter("@inDiscountCategoryIDOld", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _nDiscountCategoryIDOld));
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
					throw new Exception("Stored Procedure 'sp_tblLoyaltyStatus_UpdateAllWnDiscountCategoryIDLogic' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("TblLoyaltyStatus::UpdateAllWnDiscountCategoryIDLogic::Error occured.", ex);
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
		///		 <LI>NLoyaltyStatusID</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ErrorCode</LI>
		/// </UL>
		/// </remarks>
		public override bool Delete()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_tblLoyaltyStatus_Delete]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@inLoyaltyStatusID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _nLoyaltyStatusID));
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
					throw new Exception("Stored Procedure 'sp_tblLoyaltyStatus_Delete' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("TblLoyaltyStatus::Delete::Error occured.", ex);
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
		/// Purpose: Delete method for a foreign key. This method will Delete one or more rows from the database, based on the Foreign Key 'nDiscountCategoryID'
		/// </summary>
		/// <returns>True if succeeded, false otherwise. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>NDiscountCategoryID</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ErrorCode</LI>
		/// </UL>
		/// </remarks>
		public bool DeleteAllWnDiscountCategoryIDLogic()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_tblLoyaltyStatus_DeleteAllWnDiscountCategoryIDLogic]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@inDiscountCategoryID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _nDiscountCategoryID));
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
					throw new Exception("Stored Procedure 'sp_tblLoyaltyStatus_DeleteAllWnDiscountCategoryIDLogic' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("TblLoyaltyStatus::DeleteAllWnDiscountCategoryIDLogic::Error occured.", ex);
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
		///		 <LI>NLoyaltyStatusID</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ErrorCode</LI>
		///		 <LI>NLoyaltyStatusID</LI>
		///		 <LI>StrDescription</LI>
		///		 <LI>NDiscountCategoryID</LI>
		/// </UL>
		/// Will fill all properties corresponding with a field in the table with the value of the row selected.
		/// </remarks>
		public override DataTable SelectOne()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_tblLoyaltyStatus_SelectOne]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("tblLoyaltyStatus");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@inLoyaltyStatusID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _nLoyaltyStatusID));
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
					throw new Exception("Stored Procedure 'sp_tblLoyaltyStatus_SelectOne' reported the ErrorCode: " + _errorCode);
				}

				if(toReturn.Rows.Count > 0)
				{
					_nLoyaltyStatusID = (Int32)toReturn.Rows[0]["nLoyaltyStatusID"];
					_strDescription = toReturn.Rows[0]["strDescription"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["strDescription"];
					_nDiscountCategoryID = (Int32)toReturn.Rows[0]["nDiscountCategoryID"];
				}
				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("TblLoyaltyStatus::SelectOne::Error occured.", ex);
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
			cmdToExecute.CommandText = "dbo.[sp_tblLoyaltyStatus_SelectAll]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("tblLoyaltyStatus");
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
					throw new Exception("Stored Procedure 'sp_tblLoyaltyStatus_SelectAll' reported the ErrorCode: " + _errorCode);
				}

				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("TblLoyaltyStatus::SelectAll::Error occured.", ex);
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
		/// Purpose: Select method for a foreign key. This method will Select one or more rows from the database, based on the Foreign Key 'nDiscountCategoryID'
		/// </summary>
		/// <returns>DataTable object if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>NDiscountCategoryID</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ErrorCode</LI>
		/// </UL>
		/// </remarks>
		public DataTable SelectAllWnDiscountCategoryIDLogic()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_tblLoyaltyStatus_SelectAllWnDiscountCategoryIDLogic]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("tblLoyaltyStatus");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@inDiscountCategoryID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _nDiscountCategoryID));
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
					throw new Exception("Stored Procedure 'sp_tblLoyaltyStatus_SelectAllWnDiscountCategoryIDLogic' reported the ErrorCode: " + _errorCode);
				}

				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("TblLoyaltyStatus::SelectAllWnDiscountCategoryIDLogic::Error occured.", ex);
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
		public SqlInt32 NLoyaltyStatusID
		{
			get
			{
				return _nLoyaltyStatusID;
			}
			set
			{
				SqlInt32 nLoyaltyStatusIDTmp = (SqlInt32)value;
				if(nLoyaltyStatusIDTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("NLoyaltyStatusID", "NLoyaltyStatusID can't be NULL");
				}
				_nLoyaltyStatusID = value;
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


		public SqlInt32 NDiscountCategoryID
		{
			get
			{
				return _nDiscountCategoryID;
			}
			set
			{
				SqlInt32 nDiscountCategoryIDTmp = (SqlInt32)value;
				if(nDiscountCategoryIDTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("NDiscountCategoryID", "NDiscountCategoryID can't be NULL");
				}
				_nDiscountCategoryID = value;
			}
		}
		public SqlInt32 NDiscountCategoryIDOld
		{
			get
			{
				return _nDiscountCategoryIDOld;
			}
			set
			{
				SqlInt32 nDiscountCategoryIDOldTmp = (SqlInt32)value;
				if(nDiscountCategoryIDOldTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("NDiscountCategoryIDOld", "NDiscountCategoryIDOld can't be NULL");
				}
				_nDiscountCategoryIDOld = value;
			}
		}
		#endregion
	}
}
