﻿///////////////////////////////////////////////////////////////////////////
// Description: Data Access class for the table 'tblTimeCard'
// Generated by LLBLGen v1.21.2003.712 Final on: 2005年12月17日, 20:14:17
// Because the Base Class already implements IDispose, this class doesn't.
///////////////////////////////////////////////////////////////////////////
using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace ACMSDAL
{
	/// <summary>
	/// Purpose: Data Access class for the table 'tblTimeCard'.
	/// </summary>
	public class TblTimeCard : DBInteractionBase
	{
		#region Class Member Declarations
			private SqlString		_strBranchCode, _strBranchCodeOld, _strRemarks;
			private SqlDateTime		_dtLastEditDate, _dtDate, _dtTime;
			private SqlInt32		_nManagerID, _nManagerIDOld, _nEmployeeID, _nEmployeeIDOld, _nEntryID;
		#endregion


		/// <summary>
		/// Purpose: Class constructor.
		/// </summary>
		public TblTimeCard()
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
		///		 <LI>DtDate. May be SqlDateTime.Null</LI>
		///		 <LI>DtTime. May be SqlDateTime.Null</LI>
		///		 <LI>StrBranchCode</LI>
		///		 <LI>NEmployeeID</LI>
		///		 <LI>StrRemarks. May be SqlString.Null</LI>
		///		 <LI>DtLastEditDate. May be SqlDateTime.Null</LI>
		///		 <LI>NManagerID. May be SqlInt32.Null</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>NEntryID</LI>
		///		 <LI>ErrorCode</LI>
		/// </UL>
		/// </remarks>
		public override bool Insert()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_tblTimeCard_Insert]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@dadtDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, _dtDate));
				cmdToExecute.Parameters.Add(new SqlParameter("@dadtTime", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, _dtTime));
				cmdToExecute.Parameters.Add(new SqlParameter("@sstrBranchCode", SqlDbType.Char, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _strBranchCode));
				cmdToExecute.Parameters.Add(new SqlParameter("@inEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _nEmployeeID));
				cmdToExecute.Parameters.Add(new SqlParameter("@sstrRemarks", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _strRemarks));
				cmdToExecute.Parameters.Add(new SqlParameter("@dadtLastEditDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, _dtLastEditDate));
				cmdToExecute.Parameters.Add(new SqlParameter("@inManagerID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _nManagerID));
				cmdToExecute.Parameters.Add(new SqlParameter("@inEntryID", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _nEntryID));
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
				_nEntryID = (SqlInt32)cmdToExecute.Parameters["@inEntryID"].Value;
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'sp_tblTimeCard_Insert' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("TblTimeCard::Insert::Error occured.", ex);
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
		///		 <LI>NEntryID</LI>
		///		 <LI>DtDate. May be SqlDateTime.Null</LI>
		///		 <LI>DtTime. May be SqlDateTime.Null</LI>
		///		 <LI>StrBranchCode</LI>
		///		 <LI>NEmployeeID</LI>
		///		 <LI>StrRemarks. May be SqlString.Null</LI>
		///		 <LI>DtLastEditDate. May be SqlDateTime.Null</LI>
		///		 <LI>NManagerID. May be SqlInt32.Null</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ErrorCode</LI>
		/// </UL>
		/// </remarks>
		public override bool Update()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_tblTimeCard_Update]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@inEntryID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _nEntryID));
				cmdToExecute.Parameters.Add(new SqlParameter("@dadtDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, _dtDate));
				cmdToExecute.Parameters.Add(new SqlParameter("@dadtTime", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, _dtTime));
				cmdToExecute.Parameters.Add(new SqlParameter("@sstrBranchCode", SqlDbType.Char, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _strBranchCode));
				cmdToExecute.Parameters.Add(new SqlParameter("@inEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _nEmployeeID));
				cmdToExecute.Parameters.Add(new SqlParameter("@sstrRemarks", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _strRemarks));
				cmdToExecute.Parameters.Add(new SqlParameter("@dadtLastEditDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, _dtLastEditDate));
				cmdToExecute.Parameters.Add(new SqlParameter("@inManagerID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _nManagerID));
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
					throw new Exception("Stored Procedure 'sp_tblTimeCard_Update' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("TblTimeCard::Update::Error occured.", ex);
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
		/// Purpose: Update method for updating one or more rows using the Foreign Key 'strBranchCode.
		/// This method will Update one or more existing rows in the database. It will reset the field 'strBranchCode' in
		/// all rows which have as value for this field the value as set in property 'StrBranchCodeOld' to 
		/// the value as set in property 'StrBranchCode'.
		/// </summary>
		/// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>StrBranchCode</LI>
		///		 <LI>StrBranchCodeOld</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ErrorCode</LI>
		/// </UL>
		/// </remarks>
		public bool UpdateAllWstrBranchCodeLogic()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_tblTimeCard_UpdateAllWstrBranchCodeLogic]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@sstrBranchCode", SqlDbType.Char, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _strBranchCode));
				cmdToExecute.Parameters.Add(new SqlParameter("@sstrBranchCodeOld", SqlDbType.Char, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _strBranchCodeOld));
				cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 2, ParameterDirection.Output, true, 0, 0, "", DataRowVersion.Proposed, _errorCode));

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
					throw new Exception("Stored Procedure 'sp_tblTimeCard_UpdateAllWstrBranchCodeLogic' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("TblTimeCard::UpdateAllWstrBranchCodeLogic::Error occured.", ex);
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
		/// Purpose: Update method for updating one or more rows using the Foreign Key 'nEmployeeID.
		/// This method will Update one or more existing rows in the database. It will reset the field 'nEmployeeID' in
		/// all rows which have as value for this field the value as set in property 'NEmployeeIDOld' to 
		/// the value as set in property 'NEmployeeID'.
		/// </summary>
		/// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>NEmployeeID</LI>
		///		 <LI>NEmployeeIDOld</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ErrorCode</LI>
		/// </UL>
		/// </remarks>
		public bool UpdateAllWnEmployeeIDLogic()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_tblTimeCard_UpdateAllWnEmployeeIDLogic]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@inEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _nEmployeeID));
				cmdToExecute.Parameters.Add(new SqlParameter("@inEmployeeIDOld", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _nEmployeeIDOld));
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
					throw new Exception("Stored Procedure 'sp_tblTimeCard_UpdateAllWnEmployeeIDLogic' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("TblTimeCard::UpdateAllWnEmployeeIDLogic::Error occured.", ex);
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
		/// Purpose: Update method for updating one or more rows using the Foreign Key 'nManagerID.
		/// This method will Update one or more existing rows in the database. It will reset the field 'nManagerID' in
		/// all rows which have as value for this field the value as set in property 'NManagerIDOld' to 
		/// the value as set in property 'NManagerID'.
		/// </summary>
		/// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>NManagerID. May be SqlInt32.Null</LI>
		///		 <LI>NManagerIDOld. May be SqlInt32.Null</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ErrorCode</LI>
		/// </UL>
		/// </remarks>
		public bool UpdateAllWnManagerIDLogic()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_tblTimeCard_UpdateAllWnManagerIDLogic]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@inManagerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _nManagerID));
				cmdToExecute.Parameters.Add(new SqlParameter("@inManagerIDOld", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _nManagerIDOld));
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
					throw new Exception("Stored Procedure 'sp_tblTimeCard_UpdateAllWnManagerIDLogic' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("TblTimeCard::UpdateAllWnManagerIDLogic::Error occured.", ex);
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
		///		 <LI>NEntryID</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ErrorCode</LI>
		/// </UL>
		/// </remarks>
		public override bool Delete()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_tblTimeCard_Delete]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@inEntryID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _nEntryID));
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
					throw new Exception("Stored Procedure 'sp_tblTimeCard_Delete' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("TblTimeCard::Delete::Error occured.", ex);
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
		/// Purpose: Delete method for a foreign key. This method will Delete one or more rows from the database, based on the Foreign Key 'strBranchCode'
		/// </summary>
		/// <returns>True if succeeded, false otherwise. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>StrBranchCode</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ErrorCode</LI>
		/// </UL>
		/// </remarks>
		public bool DeleteAllWstrBranchCodeLogic()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_tblTimeCard_DeleteAllWstrBranchCodeLogic]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@sstrBranchCode", SqlDbType.Char, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _strBranchCode));
				cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 2, ParameterDirection.Output, true, 0, 0, "", DataRowVersion.Proposed, _errorCode));

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
					throw new Exception("Stored Procedure 'sp_tblTimeCard_DeleteAllWstrBranchCodeLogic' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("TblTimeCard::DeleteAllWstrBranchCodeLogic::Error occured.", ex);
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
		/// Purpose: Delete method for a foreign key. This method will Delete one or more rows from the database, based on the Foreign Key 'nEmployeeID'
		/// </summary>
		/// <returns>True if succeeded, false otherwise. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>NEmployeeID</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ErrorCode</LI>
		/// </UL>
		/// </remarks>
		public bool DeleteAllWnEmployeeIDLogic()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_tblTimeCard_DeleteAllWnEmployeeIDLogic]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@inEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _nEmployeeID));
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
					throw new Exception("Stored Procedure 'sp_tblTimeCard_DeleteAllWnEmployeeIDLogic' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("TblTimeCard::DeleteAllWnEmployeeIDLogic::Error occured.", ex);
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
		/// Purpose: Delete method for a foreign key. This method will Delete one or more rows from the database, based on the Foreign Key 'nManagerID'
		/// </summary>
		/// <returns>True if succeeded, false otherwise. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>NManagerID. May be SqlInt32.Null</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ErrorCode</LI>
		/// </UL>
		/// </remarks>
		public bool DeleteAllWnManagerIDLogic()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_tblTimeCard_DeleteAllWnManagerIDLogic]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@inManagerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _nManagerID));
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
					throw new Exception("Stored Procedure 'sp_tblTimeCard_DeleteAllWnManagerIDLogic' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("TblTimeCard::DeleteAllWnManagerIDLogic::Error occured.", ex);
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
		///		 <LI>NEntryID</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ErrorCode</LI>
		///		 <LI>NEntryID</LI>
		///		 <LI>DtDate</LI>
		///		 <LI>DtTime</LI>
		///		 <LI>StrBranchCode</LI>
		///		 <LI>NEmployeeID</LI>
		///		 <LI>StrRemarks</LI>
		///		 <LI>DtLastEditDate</LI>
		///		 <LI>NManagerID</LI>
		/// </UL>
		/// Will fill all properties corresponding with a field in the table with the value of the row selected.
		/// </remarks>
		public override DataTable SelectOne()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_tblTimeCard_SelectOne]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("tblTimeCard");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@inEntryID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _nEntryID));
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
					throw new Exception("Stored Procedure 'sp_tblTimeCard_SelectOne' reported the ErrorCode: " + _errorCode);
				}

				if(toReturn.Rows.Count > 0)
				{
					_nEntryID = (Int32)toReturn.Rows[0]["nEntryID"];
					_dtDate = toReturn.Rows[0]["dtDate"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["dtDate"];
					_dtTime = toReturn.Rows[0]["dtTime"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["dtTime"];
					_strBranchCode = (string)toReturn.Rows[0]["strBranchCode"];
					_nEmployeeID = (Int32)toReturn.Rows[0]["nEmployeeID"];
					_strRemarks = toReturn.Rows[0]["strRemarks"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["strRemarks"];
					_dtLastEditDate = toReturn.Rows[0]["dtLastEditDate"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["dtLastEditDate"];
					_nManagerID = toReturn.Rows[0]["nManagerID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["nManagerID"];
				}
				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("TblTimeCard::SelectOne::Error occured.", ex);
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
			cmdToExecute.CommandText = "dbo.[sp_tblTimeCard_SelectAll]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("tblTimeCard");
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
					throw new Exception("Stored Procedure 'sp_tblTimeCard_SelectAll' reported the ErrorCode: " + _errorCode);
				}

				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("TblTimeCard::SelectAll::Error occured.", ex);
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
		/// Purpose: Select method for a foreign key. This method will Select one or more rows from the database, based on the Foreign Key 'strBranchCode'
		/// </summary>
		/// <returns>DataTable object if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>StrBranchCode</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ErrorCode</LI>
		/// </UL>
		/// </remarks>
		public DataTable SelectAllWstrBranchCodeLogic()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_tblTimeCard_SelectAllWstrBranchCodeLogic]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("tblTimeCard");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@sstrBranchCode", SqlDbType.Char, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _strBranchCode));
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
					throw new Exception("Stored Procedure 'sp_tblTimeCard_SelectAllWstrBranchCodeLogic' reported the ErrorCode: " + _errorCode);
				}

				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("TblTimeCard::SelectAllWstrBranchCodeLogic::Error occured.", ex);
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
		/// Purpose: Select method for a foreign key. This method will Select one or more rows from the database, based on the Foreign Key 'nEmployeeID'
		/// </summary>
		/// <returns>DataTable object if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>NEmployeeID</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ErrorCode</LI>
		/// </UL>
		/// </remarks>
		public DataTable SelectAllWnEmployeeIDLogic()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_tblTimeCard_SelectAllWnEmployeeIDLogic]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("tblTimeCard");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@inEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _nEmployeeID));
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
					throw new Exception("Stored Procedure 'sp_tblTimeCard_SelectAllWnEmployeeIDLogic' reported the ErrorCode: " + _errorCode);
				}

				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("TblTimeCard::SelectAllWnEmployeeIDLogic::Error occured.", ex);
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
		/// Purpose: Select method for a foreign key. This method will Select one or more rows from the database, based on the Foreign Key 'nManagerID'
		/// </summary>
		/// <returns>DataTable object if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>NManagerID. May be SqlInt32.Null</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ErrorCode</LI>
		/// </UL>
		/// </remarks>
		public DataTable SelectAllWnManagerIDLogic()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_tblTimeCard_SelectAllWnManagerIDLogic]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("tblTimeCard");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@inManagerID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _nManagerID));
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
					throw new Exception("Stored Procedure 'sp_tblTimeCard_SelectAllWnManagerIDLogic' reported the ErrorCode: " + _errorCode);
				}

				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("TblTimeCard::SelectAllWnManagerIDLogic::Error occured.", ex);
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
		public SqlInt32 NEntryID
		{
			get
			{
				return _nEntryID;
			}
			set
			{
				SqlInt32 nEntryIDTmp = (SqlInt32)value;
				if(nEntryIDTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("NEntryID", "NEntryID can't be NULL");
				}
				_nEntryID = value;
			}
		}


		public SqlDateTime DtDate
		{
			get
			{
				return _dtDate;
			}
			set
			{
				_dtDate = value;
			}
		}


		public SqlDateTime DtTime
		{
			get
			{
				return _dtTime;
			}
			set
			{
				_dtTime = value;
			}
		}


		public SqlString StrBranchCode
		{
			get
			{
				return _strBranchCode;
			}
			set
			{
				SqlString strBranchCodeTmp = (SqlString)value;
				if(strBranchCodeTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("StrBranchCode", "StrBranchCode can't be NULL");
				}
				_strBranchCode = value;
			}
		}
		public SqlString StrBranchCodeOld
		{
			get
			{
				return _strBranchCodeOld;
			}
			set
			{
				SqlString strBranchCodeOldTmp = (SqlString)value;
				if(strBranchCodeOldTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("StrBranchCodeOld", "StrBranchCodeOld can't be NULL");
				}
				_strBranchCodeOld = value;
			}
		}


		public SqlInt32 NEmployeeID
		{
			get
			{
				return _nEmployeeID;
			}
			set
			{
				SqlInt32 nEmployeeIDTmp = (SqlInt32)value;
				if(nEmployeeIDTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("NEmployeeID", "NEmployeeID can't be NULL");
				}
				_nEmployeeID = value;
			}
		}
		public SqlInt32 NEmployeeIDOld
		{
			get
			{
				return _nEmployeeIDOld;
			}
			set
			{
				SqlInt32 nEmployeeIDOldTmp = (SqlInt32)value;
				if(nEmployeeIDOldTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("NEmployeeIDOld", "NEmployeeIDOld can't be NULL");
				}
				_nEmployeeIDOld = value;
			}
		}


		public SqlString StrRemarks
		{
			get
			{
				return _strRemarks;
			}
			set
			{
				_strRemarks = value;
			}
		}


		public SqlDateTime DtLastEditDate
		{
			get
			{
				return _dtLastEditDate;
			}
			set
			{
				_dtLastEditDate = value;
			}
		}


		public SqlInt32 NManagerID
		{
			get
			{
				return _nManagerID;
			}
			set
			{
				_nManagerID = value;
			}
		}
		public SqlInt32 NManagerIDOld
		{
			get
			{
				return _nManagerIDOld;
			}
			set
			{
				_nManagerIDOld = value;
			}
		}
		#endregion

		#region ChauChon
		public new void SaveData(DataTable table, string cmdtxt)
		{
			base.SaveData(table, cmdtxt); 
		}
		#endregion
	}
}