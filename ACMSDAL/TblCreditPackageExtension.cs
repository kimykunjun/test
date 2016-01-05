using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace ACMSDAL
{
	public class TblCreditPackageExtension : DBInteractionBase
	{
		#region Class Member Declarations

			private SqlDateTime		_dtNewExpiry, 
                                    _dtStartDate, 
                                    _dtEndDate, 
                                    _dtOldExpiry;

			private SqlInt32		_nStatusID, 
                                    _nReasonID, 
                                    _nReasonIDOld, 
                                    _nEmployeeID, 
                                    _nEmployeeIDOld,
                                    _nCreditPackageID, 
                                    _nCreditPackageIDOld, 
                                    _nExtensionID, 
                                    _nDaysExtended;

			private SqlString		_strRemarks;

		#endregion

		public TblCreditPackageExtension()
		{
		}

		public override bool Insert()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_tblCreditPackageExtension_Insert]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				//cmdToExecute.Parameters.Add(new SqlParameter("@inExtensionID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _nExtensionID));
				cmdToExecute.Parameters.Add(new SqlParameter("@inCreditPackageID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _nCreditPackageID));
				cmdToExecute.Parameters.Add(new SqlParameter("@dadtOldExpiry", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, _dtOldExpiry));
				cmdToExecute.Parameters.Add(new SqlParameter("@dadtNewExpiry", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, _dtNewExpiry));
				cmdToExecute.Parameters.Add(new SqlParameter("@dadtStartDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, _dtStartDate));
				cmdToExecute.Parameters.Add(new SqlParameter("@dadtEndDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, _dtEndDate));
				cmdToExecute.Parameters.Add(new SqlParameter("@inDaysExtended", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _nDaysExtended));
				cmdToExecute.Parameters.Add(new SqlParameter("@inStatusID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _nStatusID));
				cmdToExecute.Parameters.Add(new SqlParameter("@inReasonID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _nReasonID));
				cmdToExecute.Parameters.Add(new SqlParameter("@sstrRemarks", SqlDbType.VarChar, 1000, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _strRemarks));
				cmdToExecute.Parameters.Add(new SqlParameter("@inEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _nEmployeeID));
				cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				if(_mainConnectionIsCreatedLocal)
				{
					_mainConnection.Open();
				}
				else
				{
					if(_mainConnectionProvider.IsTransactionPending)
					{
						cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
					}
				}

				_rowsAffected = cmdToExecute.ExecuteNonQuery();
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					throw new Exception("Stored Procedure 'sp_tblCreditPackageExtension_Insert' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				throw new Exception("TblCreditPackageExtension::Insert::Error occured.", ex);
			}
			finally
			{
				if(_mainConnectionIsCreatedLocal)
				{
					_mainConnection.Close();
				}
				cmdToExecute.Dispose();
			}
		}

		public override bool Update()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_tblCreditPackageExtension_Update]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@inExtensionID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _nExtensionID));
				cmdToExecute.Parameters.Add(new SqlParameter("@inCreditPackageID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _nCreditPackageID));
				cmdToExecute.Parameters.Add(new SqlParameter("@dadtOldExpiry", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, _dtOldExpiry));
				cmdToExecute.Parameters.Add(new SqlParameter("@dadtNewExpiry", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, _dtNewExpiry));
				cmdToExecute.Parameters.Add(new SqlParameter("@dadtStartDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, _dtStartDate));
				cmdToExecute.Parameters.Add(new SqlParameter("@dadtEndDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, _dtEndDate));
				cmdToExecute.Parameters.Add(new SqlParameter("@inDaysExtended", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _nDaysExtended));
				cmdToExecute.Parameters.Add(new SqlParameter("@inStatusID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _nStatusID));
				cmdToExecute.Parameters.Add(new SqlParameter("@inReasonID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _nReasonID));
				cmdToExecute.Parameters.Add(new SqlParameter("@sstrRemarks", SqlDbType.VarChar, 1000, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _strRemarks));
				cmdToExecute.Parameters.Add(new SqlParameter("@inEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _nEmployeeID));
				cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				if(_mainConnectionIsCreatedLocal)
				{
					_mainConnection.Open();
				}
				else
				{
					if(_mainConnectionProvider.IsTransactionPending)
					{
						cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
					}
				}

				_rowsAffected = cmdToExecute.ExecuteNonQuery();
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					throw new Exception("Stored Procedure 'sp_tblCreditPackageExtension_Update' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				throw new Exception("TblCreditPackageExtension::Update::Error occured.", ex);
			}
			finally
			{
				if(_mainConnectionIsCreatedLocal)
				{
					_mainConnection.Close();
				}
				cmdToExecute.Dispose();
			}
		}			
		
		public override bool Delete()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_tblCreditPackageExtension_Delete]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@inExtensionID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _nExtensionID));
				cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				if(_mainConnectionIsCreatedLocal)
				{
					_mainConnection.Open();
				}
				else
				{
					if(_mainConnectionProvider.IsTransactionPending)
					{
						cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
					}
				}

				_rowsAffected = cmdToExecute.ExecuteNonQuery();
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					throw new Exception("Stored Procedure 'sp_tblCreditPackageExtension_Delete' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				throw new Exception("TblCreditPackageExtension::Delete::Error occured.", ex);
			}
			finally
			{
				if(_mainConnectionIsCreatedLocal)
				{
					_mainConnection.Close();
				}
				cmdToExecute.Dispose();
			}
		}

        public bool MemberCreditPackage_ExtensionDelete(int nCreditPackageID, int nExtensionID)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_tblCreditPackageExtension_DeleteByExtensionID]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@nCreditPackageID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, nCreditPackageID));
                cmdToExecute.Parameters.Add(new SqlParameter("@nExtensionID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, nExtensionID));              
                cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                if (_mainConnectionIsCreatedLocal)
                {
                    // Open connection.
                    _mainConnection.Open();
                }
                else
                {
                    if (_mainConnectionProvider.IsTransactionPending)
                    {
                        cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                    }
                }

                // Execute query.
                _rowsAffected = cmdToExecute.ExecuteNonQuery();
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_tblCreditPackageExtension_DeleteByExtensionID' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TblCreditPackageExtension::MemberCreditPackage_ExtensionDelete::Error occured.", ex);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
            }
        }
		
        public override DataTable SelectOne()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_tblCreditPackageExtension_SelectOne]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("tblCreditPackageExtension");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@inExtensionID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _nExtensionID));
				cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				if(_mainConnectionIsCreatedLocal)
				{
					_mainConnection.Open();
				}
				else
				{
					if(_mainConnectionProvider.IsTransactionPending)
					{
						cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
					}
				}

				adapter.Fill(toReturn);
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					throw new Exception("Stored Procedure 'sp_tblCreditPackageExtension_SelectOne' reported the ErrorCode: " + _errorCode);
				}

				if(toReturn.Rows.Count > 0)
				{
					_nExtensionID = (Int32)toReturn.Rows[0]["nExtensionID"];
					_nCreditPackageID = (Int32)toReturn.Rows[0]["nCreditPackageID"];
					_dtOldExpiry = toReturn.Rows[0]["dtOldExpiry"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["dtOldExpiry"];
					_dtNewExpiry = toReturn.Rows[0]["dtNewExpiry"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["dtNewExpiry"];
					_dtStartDate = toReturn.Rows[0]["dtStartDate"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["dtStartDate"];
					_dtEndDate = toReturn.Rows[0]["dtEndDate"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["dtEndDate"];
					_nDaysExtended = toReturn.Rows[0]["nDaysExtended"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["nDaysExtended"];
					_nStatusID = toReturn.Rows[0]["nStatusID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["nStatusID"];
					_nReasonID = (Int32)toReturn.Rows[0]["nReasonID"];
					_strRemarks = toReturn.Rows[0]["strRemarks"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["strRemarks"];
					_nEmployeeID = (Int32)toReturn.Rows[0]["nEmployeeID"];
				}
				return toReturn;
			}
			catch(Exception ex)
			{
				throw new Exception("TblCreditPackageExtension::SelectOne::Error occured.", ex);
			}
			finally
			{
				if(_mainConnectionIsCreatedLocal)
				{
					_mainConnection.Close();
				}
				cmdToExecute.Dispose();
				adapter.Dispose();
			}
		}
        
		public override DataTable SelectAll()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_tblCreditPackageExtension_SelectAll]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("tblCreditPackageExtension");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				if(_mainConnectionIsCreatedLocal)
				{
					_mainConnection.Open();
				}
				else
				{
					if(_mainConnectionProvider.IsTransactionPending)
					{
						cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
					}
				}

				adapter.Fill(toReturn);
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					throw new Exception("Stored Procedure 'sp_tblCreditPackageExtension_SelectAll' reported the ErrorCode: " + _errorCode);
				}

				return toReturn;
			}
			catch(Exception ex)
			{
				throw new Exception("TblCreditPackageExtension::SelectAll::Error occured.", ex);
			}
			finally
			{
				if(_mainConnectionIsCreatedLocal)
				{
					_mainConnection.Close();
				}
				cmdToExecute.Dispose();
				adapter.Dispose();
			}
		}

		public DataTable SelectAllWnCreditPackageIDLogic()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_tblCreditPackageExtension_SelectAllWnCreditPackageIDLogic]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("tblCreditPackageExtension");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@inCreditPackageID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _nCreditPackageID));
				cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				if(_mainConnectionIsCreatedLocal)
				{
					_mainConnection.Open();
				}
				else
				{
					if(_mainConnectionProvider.IsTransactionPending)
					{
						cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
					}
				}

				adapter.Fill(toReturn);
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					throw new Exception("Stored Procedure 'sp_tblCreditPackageExtension_SelectAllWnCreditPackageIDLogic' reported the ErrorCode: " + _errorCode);
				}

				return toReturn;
			}
			catch(Exception ex)
			{
				throw new Exception("TblCreditPackageExtension::SelectAllWnCreditPackageIDLogic::Error occured.", ex);
			}
			finally
			{
				if(_mainConnectionIsCreatedLocal)
				{
					_mainConnection.Close();
				}
				cmdToExecute.Dispose();
				adapter.Dispose();
			}
		}		

		public DataTable SelectAllWnEmployeeIDLogic()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_tblCreditPackageExtension_SelectAllWnEmployeeIDLogic]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("tblCreditPackageExtension");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@inEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _nEmployeeID));
				cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				if(_mainConnectionIsCreatedLocal)
				{
					_mainConnection.Open();
				}
				else
				{
					if(_mainConnectionProvider.IsTransactionPending)
					{
						cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
					}
				}

				adapter.Fill(toReturn);
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					throw new Exception("Stored Procedure 'sp_tblCreditPackageExtension_SelectAllWnEmployeeIDLogic' reported the ErrorCode: " + _errorCode);
				}

				return toReturn;
			}
			catch(Exception ex)
			{
				throw new Exception("TblCreditPackageExtension::SelectAllWnEmployeeIDLogic::Error occured.", ex);
			}
			finally
			{
				if(_mainConnectionIsCreatedLocal)
				{
					_mainConnection.Close();
				}
				cmdToExecute.Dispose();
				adapter.Dispose();
			}
		}

		#region Class Property Declarations

		    public SqlInt32 NExtensionID
		    {
			    get
			    {
				    return _nExtensionID;
			    }
			    set
			    {
				    SqlInt32 nExtensionIDTmp = (SqlInt32)value;
				    if(nExtensionIDTmp.IsNull)
				    {
					    throw new ArgumentOutOfRangeException("NExtensionID", "NExtensionID can't be NULL");
				    }
				    _nExtensionID = value;
			    }
		    }

		    public SqlInt32 NCreditPackageID
		    {
			    get
			    {
				    return _nCreditPackageID;
			    }
			    set
			    {
				    SqlInt32 nCreditPackageIDTmp = (SqlInt32)value;
				    if(nCreditPackageIDTmp.IsNull)
				    {
					    throw new ArgumentOutOfRangeException("NCreditPackageID", "NCreditPackageID can't be NULL");
				    }
				    _nCreditPackageID = value;
			    }
		    }

		    public SqlInt32 NCreditPackageIDOld
		    {
			    get
			    {
				    return _nCreditPackageIDOld;
			    }
			    set
			    {
				    SqlInt32 nCreditPackageIDOldTmp = (SqlInt32)value;
				    if(nCreditPackageIDOldTmp.IsNull)
				    {
					    throw new ArgumentOutOfRangeException("NCreditPackageIDOld", "NCreditPackageIDOld can't be NULL");
				    }
				    _nCreditPackageIDOld = value;
			    }
		    }

		    public SqlDateTime DtOldExpiry
		    {
			    get
			    {
				    return _dtOldExpiry;
			    }
			    set
			    {
				    _dtOldExpiry = value;
			    }
		    }

		    public SqlDateTime DtNewExpiry
		    {
			    get
			    {
				    return _dtNewExpiry;
			    }
			    set
			    {
				    _dtNewExpiry = value;
			    }
		    }

		    public SqlDateTime DtStartDate
		    {
			    get
			    {
				    return _dtStartDate;
			    }
			    set
			    {
				    _dtStartDate = value;
			    }
		    }

		    public SqlDateTime DtEndDate
		    {
			    get
			    {
				    return _dtEndDate;
			    }
			    set
			    {
				    _dtEndDate = value;
			    }
		    }

		    public SqlInt32 NDaysExtended
		    {
			    get
			    {
				    return _nDaysExtended;
			    }
			    set
			    {
				    _nDaysExtended = value;
			    }
		    }

		    public SqlInt32 NStatusID
		    {
			    get
			    {
				    return _nStatusID;
			    }
			    set
			    {
				    _nStatusID = value;
			    }
		    }

		    public SqlInt32 NReasonID
		    {
			    get
			    {
				    return _nReasonID;
			    }
			    set
			    {
				    SqlInt32 nReasonIDTmp = (SqlInt32)value;
				    if(nReasonIDTmp.IsNull)
				    {
					    throw new ArgumentOutOfRangeException("NReasonID", "NReasonID can't be NULL");
				    }
				    _nReasonID = value;
			    }
		    }

		    public SqlInt32 NReasonIDOld
		    {
			    get
			    {
				    return _nReasonIDOld;
			    }
			    set
			    {
				    SqlInt32 nReasonIDOldTmp = (SqlInt32)value;
				    if(nReasonIDOldTmp.IsNull)
				    {
					    throw new ArgumentOutOfRangeException("NReasonIDOld", "NReasonIDOld can't be NULL");
				    }
				    _nReasonIDOld = value;
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

		#endregion
		
	    public DataTable LoadAll()
	    {
            return base.LoadData("SELECT * FROM tblCreditPackageExtension");
	    }

	    public DataTable GetActiveCreditPackageExtension(int nCreditPackageID)
	    {
		    string cmdText = @"SELECT A.*, B.strDescription AS ReasonTypeDescription, C.strEmployeeName 
                                    FROM tblCreditPackageExtension AS A LEFT OUTER JOIN 
	                                        tblPackageExtensionReasonType AS B ON (A.nReasonID = B.nReasonID) LEFT OUTER JOIN 
	                                        tblEmployee AS C ON (A.nEmployeeID = C.nEmployeeID) 
                                    WHERE nCreditPackageID = @nCreditPackageID and A.nStatusID = 0";
            return base.LoadData(cmdText, new string[] { "@nCreditPackageID" }, new object[] { nCreditPackageID });
	    }

	    public bool Cancel(int nxtensionID)
	    {
		    return true;
	    }

        public void SaveData(DataTable CreditPackageExtensionTable)
	    {
            base.SaveData(CreditPackageExtensionTable, "Select nExtensionID,nCreditPackageID,dtOldExpiry,dtNewExpiry,dtStartDate,dtEndDate,nDaysExtended,nStatusID,nReasonID,strRemarks,nEmployeeID,dtCreateDate From tblPackageExtension");
            //base.SaveData(CreditPackageExtensionTable, "SELECT * FROM tblCreditPackageExtension");
		
	    }

	}
}
