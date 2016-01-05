using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace ACMSDAL
{
    public class TblCashVoucher : DBInteractionBase
    {
        #region Class Member Declarations
        private SqlInt32 _nCashVoucherID;
        private SqlString _strSN;
        private SqlString _strDescription;
        private SqlString _strDescription2;
        private SqlInt32 _nCreatedByID;
        private SqlDateTime _dtCreatedDate;
        private SqlString _strRedeemedByID;
        private SqlDateTime _dtRedeemedDate;
        private SqlString _strRedeemedBranch;
        private SqlInt32 _nStatusID;
        private SqlDateTime _dtStartDate;
        private SqlDateTime _dtExpiryDate;
        private SqlDateTime _dtPrintedDate;
        private SqlString _strSoldToID;
        private SqlDateTime _dtSoldDate;
        private SqlString _strSoldBranch;
        private SqlMoney _mValue;
        private SqlString _strBranchCode;
        private SqlInt32 _nCashVoucherTypeID;
        private SqlBoolean _fSell;
        private SqlInt32 _nValidDuration;
        private SqlString _strDurationUnit;
        private SqlString _strCategoryIDs;

        #endregion        

        public TblCashVoucher()
        {
            // Nothing for now.
        }
        public override bool Insert()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_tblCashVoucher_Insert]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@sstrSN", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _strSN));
                cmdToExecute.Parameters.Add(new SqlParameter("@sstrDescription", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _strDescription));
                cmdToExecute.Parameters.Add(new SqlParameter("@sstrDescription2", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _strDescription2));
                cmdToExecute.Parameters.Add(new SqlParameter("@inCreatedByID", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _nCreatedByID));
                cmdToExecute.Parameters.Add(new SqlParameter("@inStatusID", SqlDbType.Int, 16, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _nStatusID));
                cmdToExecute.Parameters.Add(new SqlParameter("@dadtStartDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _dtStartDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@dadtExpiryDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _dtExpiryDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@dadtPrintedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _dtPrintedDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@curmValue", SqlDbType.Money, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _mValue));
                cmdToExecute.Parameters.Add(new SqlParameter("@sstrBranchCode", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _strBranchCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@inCashVoucherTypeID", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _nCashVoucherTypeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@bfSell", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _fSell));
                cmdToExecute.Parameters.Add(new SqlParameter("@inValidDuration", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _nValidDuration));
                cmdToExecute.Parameters.Add(new SqlParameter("@sstrDurationUnit", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _strDurationUnit));
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
                    throw new Exception("Stored Procedure 'sp_tblCashVoucher_Insert' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TblCashVoucher::Insert::Error occured.", ex);
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

        public override bool Update()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_tblCashVoucher_Update]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@sstrSN", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _strSN));
                cmdToExecute.Parameters.Add(new SqlParameter("@sstrDescription", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _strDescription));
                cmdToExecute.Parameters.Add(new SqlParameter("@sstrDescription2", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _strDescription2));
                cmdToExecute.Parameters.Add(new SqlParameter("@sstrRedeemedByID", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _strRedeemedByID));
                cmdToExecute.Parameters.Add(new SqlParameter("@dadtRedeemedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _dtRedeemedDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@sstrRedeemedBranch", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _strRedeemedBranch));
                cmdToExecute.Parameters.Add(new SqlParameter("@inStatusID", SqlDbType.Int, 16, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _nStatusID));
                cmdToExecute.Parameters.Add(new SqlParameter("@dadtStartDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _dtStartDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@dadtExpiryDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _dtExpiryDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@dadtPrintedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _dtPrintedDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@sstrSoldToID", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _strSoldToID));
                cmdToExecute.Parameters.Add(new SqlParameter("@dadtSoldDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _dtSoldDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@sstrSoldBranch", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _strSoldBranch));
                cmdToExecute.Parameters.Add(new SqlParameter("@curmValue", SqlDbType.Money, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _mValue));
                cmdToExecute.Parameters.Add(new SqlParameter("@sstrBranchCode", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _strBranchCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@inCashVoucherTypeID", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _nCashVoucherTypeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@bfSell", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _fSell));
                cmdToExecute.Parameters.Add(new SqlParameter("@inValidDuration", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _nValidDuration));
                cmdToExecute.Parameters.Add(new SqlParameter("@sstrDurationUnit", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _strDurationUnit));
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
                    throw new Exception("Stored Procedure 'sp_tblCashVoucher_Update' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TblCashVoucher::Update::Error occured.", ex);
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

        public override bool Delete()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_tblCashVoucher_Delete]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@nCashVoucherID", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _nCashVoucherID));                
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
                    throw new Exception("Stored Procedure 'sp_tblCashVoucher_Delete' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TblCashVoucher::Delete::Error occured.", ex);
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
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_tblCashVoucher_SelectOne]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("tblCashVoucher");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@sstrSN", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _strSN));                
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
                adapter.Fill(toReturn);
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_tblCashVoucher_SelectOne' reported the ErrorCode: " + _errorCode);
                }

                if (toReturn.Rows.Count > 0)
                {                    
                    _nCashVoucherID = toReturn.Rows[0]["nCashVoucherID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["nCashVoucherID"];
                    _strSN = toReturn.Rows[0]["strSN"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["strSN"];
                    _strDescription = toReturn.Rows[0]["strDescription"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["strDescription"];
                    _strDescription2 = toReturn.Rows[0]["strDescription2"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["strDescription2"];
                    _nCreatedByID = toReturn.Rows[0]["nCreatedByID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["nCreatedByID"];
                    _dtCreatedDate = toReturn.Rows[0]["dtCreatedDate"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["dtCreatedDate"];
                    _strRedeemedByID = toReturn.Rows[0]["strRedeemedByID"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["strRedeemedByID"];
                    _dtRedeemedDate = toReturn.Rows[0]["dtRedeemedDate"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["dtRedeemedDate"];
                    _strRedeemedBranch = toReturn.Rows[0]["strRedeemedBranch"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["strRedeemedBranch"];
                    _nStatusID = toReturn.Rows[0]["nStatusID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["nStatusID"];
                    _dtStartDate = toReturn.Rows[0]["dtStartDate"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["dtStartDate"];
                    _dtExpiryDate = toReturn.Rows[0]["dtExpiryDate"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["dtExpiryDate"];
                    _dtPrintedDate = toReturn.Rows[0]["dtPrintedDate"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["dtPrintedDate"];
                    _strSoldToID = toReturn.Rows[0]["strSoldToID"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["strSoldToID"];
                    _dtSoldDate = toReturn.Rows[0]["dtSoldDate"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["dtSoldDate"];
                    _strSoldBranch = toReturn.Rows[0]["strSoldBranch"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["strSoldBranch"];
                    _mValue = toReturn.Rows[0]["mValue"] == System.DBNull.Value ? SqlMoney.Null : (Decimal)toReturn.Rows[0]["mValue"];
                    _strBranchCode = toReturn.Rows[0]["strBranchCode"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["strBranchCode"];
                    _nCashVoucherTypeID = toReturn.Rows[0]["nCashVoucherTypeID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["nCashVoucherTypeID"];
                    _nCashVoucherTypeID = toReturn.Rows[0]["nCashVoucherTypeID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["nCashVoucherTypeID"];
                    _nValidDuration = toReturn.Rows[0]["nValidDuration"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["nValidDuration"];
                    _strDurationUnit = toReturn.Rows[0]["strDurationUnit"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["strDurationUnit"];
                    _fSell = toReturn.Rows[0]["fSell"] == System.DBNull.Value ? SqlBoolean.Null : (bool)toReturn.Rows[0]["fSell"];
                    _strCategoryIDs = toReturn.Rows[0]["strCategoryIDs"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["strCategoryIDs"];
                }
                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TblCashVoucher::SelectOne::Error occured.", ex);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
                adapter.Dispose();
            }
        }
        public void SaveData(DataTable table)
        {
            base.SaveData(table, "Select * from tblCashVoucher");
        }
        public SqlInt32 NCashVoucherID
        {
            get
            {
                return _nCashVoucherID;
            }
            set
            {
                SqlInt32 nCashVoucherIDTmp = (SqlInt32)value;
                if (nCashVoucherIDTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("NCashVoucherID", "NCashVoucherID can't be NULL");
                }
                _nCashVoucherID = value;
            }
        }
        public SqlString StrSN
        {
            get
            {
                return _strSN;
            }
            set
            {
                SqlString strSNTmp = (SqlString)value;
                if (strSNTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("StrSN", "StrSN can't be NULL");
                }
                _strSN = value;
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
                SqlString strDescriptionTmp = (SqlString)value;
                if (strDescriptionTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("StrDescription", "StrDescription can't be NULL");
                }
                _strDescription = value;
            }
        }
        public SqlString StrDescription2
        {
            get
            {
                return _strDescription2;
            }
            set
            {
                SqlString strDescription2Tmp = (SqlString)value;
                if (strDescription2Tmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("StrDescription2", "StrDescription2 can't be NULL");
                }
                _strDescription2 = value;
            }
        }
        public SqlInt32 NCreatedByID
        {
            get
            {
                return _nCreatedByID;
            }
            set
            {
                SqlInt32 nCreatedByIDTmp = (SqlInt32)value;
                if (nCreatedByIDTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("NCreatedByID", "NCreatedByID can't be NULL");
                }
                _nCreatedByID = value;
            }
        }
        public SqlDateTime DtCreatedDate
        {
            get
            {
                return _dtCreatedDate;
            }
            set
            {
                SqlDateTime dtCreatedDateTmp = (SqlDateTime)value;
                if (dtCreatedDateTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("DtCreatedDate", "DtCreatedDate can't be NULL");
                }
                _dtCreatedDate = value;
            }
        }
        public SqlString StrRedeemedByID
        {
            get
            {
                return _strRedeemedByID;
            }
            set
            {                
                _strRedeemedByID = value;
            }
        }
        public SqlDateTime DtRedeemedDate
        {
            get
            {
                return _dtRedeemedDate;
            }
            set
            {                
                _dtRedeemedDate = value;
            }
        }
        public SqlString StrRedeemedBranch
        {
            get
            {
                return _strRedeemedBranch;
            }
            set
            {              
                _strRedeemedBranch = value;
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
                SqlInt32 nStatusIDTmp = (SqlInt32)value;
                if (nStatusIDTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("NStatusID", "NStatusID can't be NULL");
                }
                _nStatusID = value;
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
        public SqlDateTime DtExpiryDate
        {
            get
            {
                return _dtExpiryDate;
            }
            set
            {               
                _dtExpiryDate = value;
            }
        }
        public SqlDateTime DtPrintedDate
        {
            get
            {
                return _dtPrintedDate;
            }
            set
            {
                SqlDateTime dtPrintedDateTmp = (SqlDateTime)value;
                if (dtPrintedDateTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("DtPrintedDate", "DtPrintedDate can't be NULL");
                }
                _dtPrintedDate = value;
            }
        }
        public SqlString StrSoldToID
        {
            get
            {
                return _strSoldToID;
            }
            set
            {               
                _strSoldToID = value;
            }
        }
        public SqlDateTime DtSoldDate
        {
            get
            {
                return _dtSoldDate;
            }
            set
            {               
                _dtSoldDate = value;
            }
        }
        public SqlString StrSoldBranch
        {
            get
            {
                return _strSoldBranch;
            }
            set
            {               
                _strSoldBranch = value;
            }
        }
        public SqlMoney MValue
        {
            get
            {
                return _mValue;
            }
            set
            {
                SqlMoney mValueTmp = (SqlMoney)value;
                if (mValueTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("MValue", "MValue can't be NULL");
                }
                _mValue = value;
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
                if (strBranchCodeTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("StrBranchCode", "StrBranchCode can't be NULL");
                }
                _strBranchCode = value;
            }
        }
        public SqlInt32 NCashVoucherTypeID
        {
            get
            {
                return _nCashVoucherTypeID;
            }
            set
            {
                SqlInt32 nCashVoucherTypeIDTmp = (SqlInt32)value;
                if (nCashVoucherTypeIDTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("NCashVoucherTypeID", "NCashVoucherTypeID can't be NULL");
                }
                _nCashVoucherTypeID = value;
            }
        }
        public SqlBoolean FSell
        {
            get
            {
                return _fSell;
            }
            set
            {
                SqlBoolean fSellTmp = (SqlBoolean)value;
                if (fSellTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("FSell", "FSell can't be NULL");
                }
                _fSell = value;
            }
        }
        public SqlInt32 NValidDuration
        {
            get
            {
                return _nValidDuration;
            }
            set
            {
                SqlInt32 nValidDurationTmp = (SqlInt32)value;
                if (nValidDurationTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("NValidDuration", "NValidDuration can't be NULL");
                }
                _nValidDuration = value;
            }
        }
        public SqlString StrDurationUnit
        {
            get
            {
                return _strDurationUnit;
            }
            set
            {
                SqlBoolean strDurationUnitTmp = (SqlBoolean)value;
                if (strDurationUnitTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("StrDurationUnit", "StrDurationUnit can't be NULL");
                }
                _strDurationUnit = value;
            }
        }

        public SqlString StrCategoryIDs
        {
            get
            {
                return _strCategoryIDs;
            }
            set
            {
                SqlBoolean strCategoryIDsTmp = (SqlBoolean)value;
                if (strCategoryIDsTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("StrCategoryIDs", "StrCategoryIDs can't be NULL");
                }
                _strCategoryIDs = value;
            }
        }
    }
}
