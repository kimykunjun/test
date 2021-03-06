///////////////////////////////////////////////////////////////////////////
// Description: Data Access class for the table 'tblUOBBooking'
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
	/// Purpose: Data Access class for the table 'tblUOBBooking'.
	/// </summary>
	public class TblUOBBooking : DBInteractionBase
	{
		#region Class Member Declarations
			private SqlString		_strBranchCode;
			private SqlInt32		_nWeekEndOffPeak, _nWeekEndPeak, _nWeekDayOffPeak, _nWeekDayPeak;
		#endregion


		/// <summary>
		/// Purpose: Class constructor.
		/// </summary>
		public TblUOBBooking()
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
		///		 <LI>StrBranchCode</LI>
		///		 <LI>NWeekDayOffPeak. May be SqlInt32.Null</LI>
		///		 <LI>NWeekDayPeak. May be SqlInt32.Null</LI>
		///		 <LI>NWeekEndOffPeak. May be SqlInt32.Null</LI>
		///		 <LI>NWeekEndPeak. May be SqlInt32.Null</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ErrorCode</LI>
		/// </UL>
		/// </remarks>
		public override bool Insert()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_tblUOBBooking_Insert]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@sstrBranchCode", SqlDbType.Char, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _strBranchCode));
				cmdToExecute.Parameters.Add(new SqlParameter("@inWeekDayOffPeak", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _nWeekDayOffPeak));
				cmdToExecute.Parameters.Add(new SqlParameter("@inWeekDayPeak", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _nWeekDayPeak));
				cmdToExecute.Parameters.Add(new SqlParameter("@inWeekEndOffPeak", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _nWeekEndOffPeak));
				cmdToExecute.Parameters.Add(new SqlParameter("@inWeekEndPeak", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _nWeekEndPeak));
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
					throw new Exception("Stored Procedure 'sp_tblUOBBooking_Insert' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("TblUOBBooking::Insert::Error occured.", ex);
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
		///		 <LI>StrBranchCode</LI>
		///		 <LI>NWeekDayOffPeak. May be SqlInt32.Null</LI>
		///		 <LI>NWeekDayPeak. May be SqlInt32.Null</LI>
		///		 <LI>NWeekEndOffPeak. May be SqlInt32.Null</LI>
		///		 <LI>NWeekEndPeak. May be SqlInt32.Null</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ErrorCode</LI>
		/// </UL>
		/// </remarks>
		public override bool Update()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_tblUOBBooking_Update]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@sstrBranchCode", SqlDbType.Char, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _strBranchCode));
				cmdToExecute.Parameters.Add(new SqlParameter("@inWeekDayOffPeak", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _nWeekDayOffPeak));
				cmdToExecute.Parameters.Add(new SqlParameter("@inWeekDayPeak", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _nWeekDayPeak));
				cmdToExecute.Parameters.Add(new SqlParameter("@inWeekEndOffPeak", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _nWeekEndOffPeak));
				cmdToExecute.Parameters.Add(new SqlParameter("@inWeekEndPeak", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _nWeekEndPeak));
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
					throw new Exception("Stored Procedure 'sp_tblUOBBooking_Update' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("TblUOBBooking::Update::Error occured.", ex);
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
		///		 <LI>StrBranchCode</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ErrorCode</LI>
		/// </UL>
		/// </remarks>
		public override bool Delete()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_tblUOBBooking_Delete]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@sstrBranchCode", SqlDbType.Char, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _strBranchCode));
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
					throw new Exception("Stored Procedure 'sp_tblUOBBooking_Delete' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("TblUOBBooking::Delete::Error occured.", ex);
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
		///		 <LI>StrBranchCode</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ErrorCode</LI>
		///		 <LI>StrBranchCode</LI>
		///		 <LI>NWeekDayOffPeak</LI>
		///		 <LI>NWeekDayPeak</LI>
		///		 <LI>NWeekEndOffPeak</LI>
		///		 <LI>NWeekEndPeak</LI>
		/// </UL>
		/// Will fill all properties corresponding with a field in the table with the value of the row selected.
		/// </remarks>
		public override DataTable SelectOne()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_tblUOBBooking_SelectOne]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("tblUOBBooking");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@sstrBranchCode", SqlDbType.Char, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _strBranchCode));
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
					throw new Exception("Stored Procedure 'sp_tblUOBBooking_SelectOne' reported the ErrorCode: " + _errorCode);
				}

				if(toReturn.Rows.Count > 0)
				{
					_strBranchCode = (string)toReturn.Rows[0]["strBranchCode"];
					_nWeekDayOffPeak = toReturn.Rows[0]["nWeekDayOffPeak"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["nWeekDayOffPeak"];
					_nWeekDayPeak = toReturn.Rows[0]["nWeekDayPeak"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["nWeekDayPeak"];
					_nWeekEndOffPeak = toReturn.Rows[0]["nWeekEndOffPeak"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["nWeekEndOffPeak"];
					_nWeekEndPeak = toReturn.Rows[0]["nWeekEndPeak"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["nWeekEndPeak"];
				}
				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("TblUOBBooking::SelectOne::Error occured.", ex);
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
			cmdToExecute.CommandText = "dbo.[sp_tblUOBBooking_SelectAll]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("tblUOBBooking");
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
					throw new Exception("Stored Procedure 'sp_tblUOBBooking_SelectAll' reported the ErrorCode: " + _errorCode);
				}

				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("TblUOBBooking::SelectAll::Error occured.", ex);
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


		public SqlInt32 NWeekDayOffPeak
		{
			get
			{
				return _nWeekDayOffPeak;
			}
			set
			{
				_nWeekDayOffPeak = value;
			}
		}


		public SqlInt32 NWeekDayPeak
		{
			get
			{
				return _nWeekDayPeak;
			}
			set
			{
				_nWeekDayPeak = value;
			}
		}


		public SqlInt32 NWeekEndOffPeak
		{
			get
			{
				return _nWeekEndOffPeak;
			}
			set
			{
				_nWeekEndOffPeak = value;
			}
		}


		public SqlInt32 NWeekEndPeak
		{
			get
			{
				return _nWeekEndPeak;
			}
			set
			{
				_nWeekEndPeak = value;
			}
		}
		#endregion
	}
}
