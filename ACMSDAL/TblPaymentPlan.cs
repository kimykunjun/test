using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace ACMSDAL
{
    public class TblPaymentPlan : DBInteractionBase
    {
        #region Class Member Declarations

        private SqlMoney _mMasterReceiptTotal,
                           _mPaymentAmount,
                           _mOutstandingAmount,
                           _mPaymentPlanAmt,
                           _mPaidAmount,
                           _mAdjustedPaymentPlanAmt;

        private SqlString _strMasterReceiptNo,                 
                            _strPaymentReceiptNo,
                            _strPackageList;

        private SqlInt32 _nInstalmentNo,
                            _nTypeID,
                            _IsDefaulted,
                            _nPaymentPlanID,
                            _nEnforceTotalInstalment;

        private SqlDateTime _dtPaymentDate,
                            _dtDueDate,
                            _dtFinalDueDate,
                            _dtDefaultedDate;

        #endregion

        public TblPaymentPlan()
        {
        }

        public override bool Insert()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_tblPaymentPlan_Insert]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@strReceiptNo", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _strMasterReceiptNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@nInstalmentNo", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _nInstalmentNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@strPaymentReceiptNo", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _strPaymentReceiptNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@mPaymentPlanAmt", SqlDbType.Money, 8, ParameterDirection.Input, true, 19, 4, "", DataRowVersion.Proposed, _mPaymentPlanAmt));
                cmdToExecute.Parameters.Add(new SqlParameter("@mPaidAmount", SqlDbType.Money, 8, ParameterDirection.Input, true, 19, 4, "", DataRowVersion.Proposed, _mPaidAmount));
                cmdToExecute.Parameters.Add(new SqlParameter("@mAdjustedPaymentPlanAmt", SqlDbType.Money, 8, ParameterDirection.Input, true, 19, 4, "", DataRowVersion.Proposed, _mAdjustedPaymentPlanAmt));
                cmdToExecute.Parameters.Add(new SqlParameter("@mOutstandingAmt", SqlDbType.Money, 8, ParameterDirection.Input, true, 19, 4, "", DataRowVersion.Proposed, _mOutstandingAmount));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtPaymentDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, _dtPaymentDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtDueDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, _dtDueDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtFinalDueDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, _dtFinalDueDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@nTypeID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _nTypeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@IsDefaulted", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _IsDefaulted));
	            cmdToExecute.Parameters.Add(new SqlParameter("@dtDefaultedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, _dtDefaultedDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@nPaymentPlanID", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _nPaymentPlanID));
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
                _nPaymentPlanID = (SqlInt32)cmdToExecute.Parameters["@nPaymentPlanID"].Value;
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_tblPaymentPlan_Insert' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TblPaymentPlan::Insert::Error occured.", ex);
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
            cmdToExecute.CommandText = "dbo.[sp_tblPaymentPlan_Update]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@nPaymentPlanID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _nPaymentPlanID));
                cmdToExecute.Parameters.Add(new SqlParameter("@strReceiptNo", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _strMasterReceiptNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@nInstalmentNo", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _nInstalmentNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@strPaymentReceiptNo", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _strPaymentReceiptNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@mPaymentPlanAmt", SqlDbType.Money, 8, ParameterDirection.Input, true, 19, 4, "", DataRowVersion.Proposed, _mPaymentPlanAmt));
                cmdToExecute.Parameters.Add(new SqlParameter("@mPaidAmount", SqlDbType.Money, 8, ParameterDirection.Input, true, 19, 4, "", DataRowVersion.Proposed, _mPaidAmount));
                cmdToExecute.Parameters.Add(new SqlParameter("@mAdjustedPaymentPlanAmt", SqlDbType.Money, 8, ParameterDirection.Input, true, 19, 4, "", DataRowVersion.Proposed, _mAdjustedPaymentPlanAmt));
                cmdToExecute.Parameters.Add(new SqlParameter("@mOutstandingAmt", SqlDbType.Money, 8, ParameterDirection.Input, true, 19, 4, "", DataRowVersion.Proposed, _mOutstandingAmount));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtPaymentDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, _dtPaymentDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtDueDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, _dtDueDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtFinalDueDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, _dtFinalDueDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@nTypeID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _nTypeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@IsDefaulted", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _IsDefaulted));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtDefaultedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, _dtDefaultedDate));                
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
                    throw new Exception("Stored Procedure 'sp_tblPaymentPlan_Update' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TblPaymentPlan::Update::Error occured.", ex);
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
            cmdToExecute.CommandText = "dbo.[sp_tblPaymentPlan_SelectOne]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("tblPaymentPlan");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@nPaymentPlanID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _nPaymentPlanID));
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
                    throw new Exception("Stored Procedure 'sp_tblPaymentPlan_SelectOne' reported the ErrorCode: " + _errorCode);
                }

                if (toReturn.Rows.Count > 0)
                {
                    _nPaymentPlanID = (Int32)toReturn.Rows[0]["nPaymentPlanID"];
                    _strMasterReceiptNo = (string)toReturn.Rows[0]["strReceiptNo"];
                    _nInstalmentNo = toReturn.Rows[0]["nInstalmentNo"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["nInstalmentNo"];
                    _strPaymentReceiptNo = toReturn.Rows[0]["strPaymentReceiptNo"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["strPaymentReceiptNo"];
                    _mPaymentPlanAmt = toReturn.Rows[0]["mPaymentPlanAmt"] == System.DBNull.Value ? SqlMoney.Null : (Decimal)toReturn.Rows[0]["mPaymentPlanAmt"];
                    _mPaidAmount = toReturn.Rows[0]["mPaidAmount"] == System.DBNull.Value ? SqlMoney.Null : (Decimal)toReturn.Rows[0]["mPaidAmount"];
                    _mAdjustedPaymentPlanAmt = toReturn.Rows[0]["mAdjustedPaymentPlanAmt"] == System.DBNull.Value ? SqlMoney.Null : (Decimal)toReturn.Rows[0]["mAdjustedPaymentPlanAmt"];
                    _mOutstandingAmount = toReturn.Rows[0]["mOutstandingAmt"] == System.DBNull.Value ? SqlMoney.Null : (Decimal)toReturn.Rows[0]["mOutstandingAmt"];
                    _dtPaymentDate = toReturn.Rows[0]["dtPaymentDate"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["dtPaymentDate"];
                    _dtDueDate = toReturn.Rows[0]["dtDueDate"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["dtDueDate"];
                    _dtFinalDueDate = toReturn.Rows[0]["dtFinalDueDate"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["dtFinalDueDate"];
                    _nTypeID = toReturn.Rows[0]["nTypeID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["nTypeID"];
                    _IsDefaulted = toReturn.Rows[0]["IsDefaulted"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["IsDefaulted"];
                    _dtDefaultedDate = toReturn.Rows[0]["dtDefaultedDate"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["dtDefaultedDate"];                  
                }
                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TblPaymentPlan::SelectOne::Error occured.", ex);
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

        public override bool Delete()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_tblPaymentPlan_Delete]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@nPaymentPlanID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _nPaymentPlanID));
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
                    throw new Exception("Stored Procedure 'sp_tblPaymentPlan_Delete' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TblPaymentPlan::Delete::Error occured.", ex);
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

        public override DataTable SelectAll()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_tblPaymentPlan_SelectAll]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("tblPaymentPlan");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
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
                    throw new Exception("Stored Procedure 'sp_tblPaymentPlan_SelectAll' reported the ErrorCode: " + _errorCode);
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TblPaymentPlan::SelectAll::Error occured.", ex);
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

        public DataTable GetInhouseInstalmentPaymentPlan()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GetInhouseInstalmentPaymentPlan]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("tblPaymentPlan");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@strReceiptNo", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _strMasterReceiptNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@receiptTotalAmt", SqlDbType.Money, 8, ParameterDirection.Input, false, 19, 4, "", DataRowVersion.Proposed, _mMasterReceiptTotal));
                cmdToExecute.Parameters.Add(new SqlParameter("@paymentAmount", SqlDbType.Money, 8, ParameterDirection.Input, false, 19, 4, "", DataRowVersion.Proposed, _mPaymentAmount));
                cmdToExecute.Parameters.Add(new SqlParameter("@outstandingAmt", SqlDbType.Money, 8, ParameterDirection.Input, false, 19, 4, "", DataRowVersion.Proposed, _mOutstandingAmount));
                cmdToExecute.Parameters.Add(new SqlParameter("@packagesList", SqlDbType.VarChar, 800, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _strPackageList));
                cmdToExecute.Parameters.Add(new SqlParameter("@enforceTotalInstalment", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _nEnforceTotalInstalment));
                cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Open();
                }
                else
                {
                    if (_mainConnectionProvider.IsTransactionPending)
                    {
                        cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                    }
                }

                adapter.Fill(toReturn);
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    throw new Exception("Stored Procedure 'sp_GetInhouseInstalmentPaymentPlan' reported the ErrorCode: " + _errorCode);
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                throw new Exception("TblPaymentPlan::GetInhouseInstalmentPaymentPlan::Error occured." + ex.Message, ex);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
                adapter.Dispose();
            }
        }

        public DataTable GetInhouseAdjustedIPP_PayOS(string strMasterReceiptNo, string strPaymentReceiptNo, decimal PaymentAmount)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GetInhouseAdjustedIPP_PayOS]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("tblInhouseAdjustedIPP_PayOS");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@strReceiptNo", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, strMasterReceiptNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@strPaymentReceiptNo", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, strPaymentReceiptNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@PaymentAmount", SqlDbType.Money, 8, ParameterDirection.Input, false, 19, 4, "", DataRowVersion.Proposed, PaymentAmount));               
                cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Open();
                }
                else
                {
                    if (_mainConnectionProvider.IsTransactionPending)
                    {
                        cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                    }
                }

                adapter.Fill(toReturn);
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    throw new Exception("Stored Procedure 'sp_GetInhouseAdjustedIPP_PayOS' reported the ErrorCode: " + _errorCode);
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                throw new Exception("tblInhouseAdjustedIPP_PayOS::GetInhouseAdjustedIPP_PayOS::Error occured." + ex.Message, ex);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
                adapter.Dispose();
            }
        }

        public DataTable GetInhouseAdjustedIPP_VoidPayOS(string strMasterReceiptNo)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GetInhouseAdjustedIPP_VoidPayOS]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("tblInhouseAdjustedIPP_VoidPayOS");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@strReceiptNo", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, strMasterReceiptNo));               
                cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Open();
                }
                else
                {
                    if (_mainConnectionProvider.IsTransactionPending)
                    {
                        cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                    }
                }

                adapter.Fill(toReturn);
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    throw new Exception("Stored Procedure 'sp_GetInhouseAdjustedIPP_VoidPayOS' reported the ErrorCode: " + _errorCode);
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                throw new Exception("tblInhouseAdjustedIPP_VoidPayOS::GetInhouseAdjustedIPP_VoidPayOS::Error occured." + ex.Message, ex);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
                adapter.Dispose();
            }
        }

        public DataTable GetInhouseIPPByReceiptNo(string strPaymentReceiptNo)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GetInhouseIPPByReceiptNo]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("tblInhouseIPPByReceiptNo");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@strReceiptNo", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, strPaymentReceiptNo));
                //cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Open();
                }
                else
                {
                    if (_mainConnectionProvider.IsTransactionPending)
                    {
                        cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                    }
                }

                adapter.Fill(toReturn);
                //_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                //if (_errorCode != (int)LLBLError.AllOk)
                //{
                    //throw new Exception("Stored Procedure 'sp_GetInhouseIPPByReceiptNo' reported the ErrorCode: " + _errorCode);
                //}

                return toReturn;
            }
            catch (Exception ex)
            {
                throw new Exception("tblInhouseIPPByReceiptNo::GetInhouseIPPByReceiptNo::Error occured." + ex.Message, ex);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
                adapter.Dispose();
            }
        }

        public DataTable GetInhouseIPPOutstandingToOverDueList(string strMembershipID)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GetInhouseIPPOutstandingToOverDueList]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("tblInhouseIPPOutstandingToOverDueList");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@strMembershipID", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, strMembershipID));

                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Open();
                }
                else
                {
                    if (_mainConnectionProvider.IsTransactionPending)
                    {
                        cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                    }
                }

                adapter.Fill(toReturn);           

                return toReturn;
            }
            catch (Exception ex)
            {
                throw new Exception("tblInhouseIPPOutstandingToOverDueList::GetInhouseIPPOutstandingToOverDueList::Error occured." + ex.Message, ex);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
                adapter.Dispose();
            }
        }

        public DataTable GetInhouseIPPReceiptDeposit(string strReceiptNo)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GetInhouseIPPReceiptDeposit]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("tblInhouseIPPReceiptDeposit");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@strReceiptNo", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, strReceiptNo));

                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Open();
                }
                else
                {
                    if (_mainConnectionProvider.IsTransactionPending)
                    {
                        cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                    }
                }

                adapter.Fill(toReturn);

                return toReturn;
            }
            catch (Exception ex)
            {
                throw new Exception("tblInhouseIPPReceiptDeposit::GetInhouseIPPReceiptDeposit::Error occured." + ex.Message, ex);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
                adapter.Dispose();
            }
        }

        public DataTable GetInhouseIPPOSByReceiptNo(string strPaymentReceiptNo)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GetInhouseIPPOSByReceiptNo]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("tblInhouseIPPOSByReceiptNo");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@strReceiptNo", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, strPaymentReceiptNo));
                //cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Open();
                }
                else
                {
                    if (_mainConnectionProvider.IsTransactionPending)
                    {
                        cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                    }
                }

                adapter.Fill(toReturn);
                //_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                //if (_errorCode != (int)LLBLError.AllOk)
                //{
                //throw new Exception("Stored Procedure 'sp_GetInhouseIPPByReceiptNo' reported the ErrorCode: " + _errorCode);
                //}

                return toReturn;
            }
            catch (Exception ex)
            {
                throw new Exception("tblInhouseIPPOSByReceiptNo::GetInhouseIPPOSByReceiptNo::Error occured." + ex.Message, ex);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
                adapter.Dispose();
            }
        }

        public DataTable GetInhouseIPPTotalNOptions(string strMasterReceiptNo, decimal mMasterReceiptTotal, decimal mPaymentAmount,
                                                    decimal mOutstandingAmount, string strPackageList)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GetInhouseIPPTotalNOptions]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("tblIPPTotalNOptions");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@strReceiptNo", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, strMasterReceiptNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@receiptTotalAmt", SqlDbType.Money, 8, ParameterDirection.Input, false, 19, 4, "", DataRowVersion.Proposed, mMasterReceiptTotal));
                cmdToExecute.Parameters.Add(new SqlParameter("@paymentAmount", SqlDbType.Money, 8, ParameterDirection.Input, false, 19, 4, "", DataRowVersion.Proposed, mPaymentAmount));
                cmdToExecute.Parameters.Add(new SqlParameter("@outstandingAmt", SqlDbType.Money, 8, ParameterDirection.Input, false, 19, 4, "", DataRowVersion.Proposed, mOutstandingAmount));
                cmdToExecute.Parameters.Add(new SqlParameter("@packagesList", SqlDbType.VarChar, 800, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, strPackageList));
                //cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Open();
                }
                else
                {
                    if (_mainConnectionProvider.IsTransactionPending)
                    {
                        cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                    }
                }

                adapter.Fill(toReturn);
                //_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                //if (_errorCode != (int)LLBLError.AllOk)
                //{
                //throw new Exception("Stored Procedure 'sp_GetInhouseIPPByReceiptNo' reported the ErrorCode: " + _errorCode);
                //}

                return toReturn;
            }
            catch (Exception ex)
            {
                throw new Exception("tblIPPTotalNOptions::GetInhouseIPPOSByReceiptNo::Error occured." + ex.Message, ex);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
                adapter.Dispose();
            }
        }

        public int GetInhouseResetIPP_VoidPayOS(string strPaymentReceiptNo)
        {
            int nStatus = 0;

            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GetInhouseResetIPP_VoidPayOS]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@strPaymentReceiptNo", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, strPaymentReceiptNo));              
                cmdToExecute.Parameters.Add(new SqlParameter("@nStatus", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, 0));

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
                nStatus = Convert.ToInt32(cmdToExecute.Parameters["@nStatus"].Value);

                return nStatus;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("GetInhouseResetIPP_VoidPayOS::Update::Error occured.", ex);
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

        public int GetInhouseIPP_ONOFF_State()
        {
            int nStatus = 0;

            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GetInhouseIPP_ONOFF_State]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@ONOFF_state", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, 0));

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
                nStatus = Convert.ToInt32(cmdToExecute.Parameters["@ONOFF_state"].Value);

                return nStatus;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("GetInhouseIPP_ONOFF_State::Update::Error occured.", ex);
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

        public bool IPPPrimaryEntry(string strReceiptNo, int nInstalmentNo, string strPaymentReceiptNo, decimal mPaymentPlanAmt,
                                        decimal mPaidAmount, decimal mAdjustedPaymentPlanAmt, decimal mOutstandingAmt,
                                        DateTime dtPaymentDate, DateTime dtDueDate, DateTime dtFinalDueDate, int nPaymentPlanID)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_tblPaymentPlan_PrimaryEntry]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@strReceiptNo", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, strReceiptNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@nInstalmentNo", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, nInstalmentNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@strPaymentReceiptNo", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, strPaymentReceiptNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@mPaymentPlanAmt", SqlDbType.Money, 8, ParameterDirection.Input, true, 19, 4, "", DataRowVersion.Proposed, mPaymentPlanAmt));
                cmdToExecute.Parameters.Add(new SqlParameter("@mPaidAmount", SqlDbType.Money, 8, ParameterDirection.Input, true, 19, 4, "", DataRowVersion.Proposed, mPaidAmount));
                cmdToExecute.Parameters.Add(new SqlParameter("@mAdjustedPaymentPlanAmt", SqlDbType.Money, 8, ParameterDirection.Input, true, 19, 4, "", DataRowVersion.Proposed, mAdjustedPaymentPlanAmt));
                cmdToExecute.Parameters.Add(new SqlParameter("@mOutstandingAmt", SqlDbType.Money, 8, ParameterDirection.Input, true, 19, 4, "", DataRowVersion.Proposed, mOutstandingAmt));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtPaymentDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, dtPaymentDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtDueDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, dtDueDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtFinalDueDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, dtFinalDueDate));            
                cmdToExecute.Parameters.Add(new SqlParameter("@nPaymentPlanID", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, nPaymentPlanID));
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
                _nPaymentPlanID = Convert.ToInt32(cmdToExecute.Parameters["@nPaymentPlanID"].Value);
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_tblPaymentPlan_PrimaryEntry' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TblPaymentPlan::Insert::Error occured.", ex);
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

        public bool IPPSubsequentEntry(string strReceiptNo, int nInstalmentNo, decimal mPaymentPlanAmt,
                                        decimal mPaidAmount, decimal mAdjustedPaymentPlanAmt, decimal mOutstandingAmt,
                                        DateTime dtDueDate, DateTime dtFinalDueDate, int nPaymentPlanID)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_tblPaymentPlan_SubsequentEntry]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@strReceiptNo", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, strReceiptNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@nInstalmentNo", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, nInstalmentNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@mPaymentPlanAmt", SqlDbType.Money, 8, ParameterDirection.Input, true, 19, 4, "", DataRowVersion.Proposed, mPaymentPlanAmt));
                cmdToExecute.Parameters.Add(new SqlParameter("@mPaidAmount", SqlDbType.Money, 8, ParameterDirection.Input, true, 19, 4, "", DataRowVersion.Proposed, mPaidAmount));
                cmdToExecute.Parameters.Add(new SqlParameter("@mAdjustedPaymentPlanAmt", SqlDbType.Money, 8, ParameterDirection.Input, true, 19, 4, "", DataRowVersion.Proposed, mAdjustedPaymentPlanAmt));
                cmdToExecute.Parameters.Add(new SqlParameter("@mOutstandingAmt", SqlDbType.Money, 8, ParameterDirection.Input, true, 19, 4, "", DataRowVersion.Proposed, mOutstandingAmt));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtDueDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, dtDueDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtFinalDueDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, dtFinalDueDate));             
                cmdToExecute.Parameters.Add(new SqlParameter("@nPaymentPlanID", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, nPaymentPlanID));
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
                _nPaymentPlanID = Convert.ToInt32(cmdToExecute.Parameters["@nPaymentPlanID"].Value);
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_tblPaymentPlan_SubsequentEntry' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TblPaymentPlan::Insert::Error occured.", ex);
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

        public bool IPPPrimaryUpdate(int nPaymentPlanID, string strReceiptNo, int nInstalmentNo, string strPaymentReceiptNo,
                                        decimal mPaidAmount, decimal mAdjustedPaymentPlanAmt, decimal mOutstandingAmt,
                                        DateTime dtPaymentDate)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_tblPaymentPlan_PrimaryUpdate]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@nPaymentPlanID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, nPaymentPlanID));
                cmdToExecute.Parameters.Add(new SqlParameter("@strReceiptNo", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, strReceiptNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@nInstalmentNo", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, nInstalmentNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@strPaymentReceiptNo", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, strPaymentReceiptNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@mPaidAmount", SqlDbType.Money, 8, ParameterDirection.Input, true, 19, 4, "", DataRowVersion.Proposed, mPaidAmount));
                cmdToExecute.Parameters.Add(new SqlParameter("@mAdjustedPaymentPlanAmt", SqlDbType.Money, 8, ParameterDirection.Input, true, 19, 4, "", DataRowVersion.Proposed, mAdjustedPaymentPlanAmt));
                cmdToExecute.Parameters.Add(new SqlParameter("@mOutstandingAmt", SqlDbType.Money, 8, ParameterDirection.Input, true, 19, 4, "", DataRowVersion.Proposed, mOutstandingAmt));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtPaymentDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, dtPaymentDate));
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
                    throw new Exception("Stored Procedure 'sp_tblPaymentPlan_PrimaryUpdate' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TblPaymentPlan::Update::Error occured.", ex);
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

        public bool IPPSubsequentUpdate(int nPaymentPlanID, string strReceiptNo, int nInstalmentNo,
                                        decimal mPaidAmount, decimal mAdjustedPaymentPlanAmt, decimal mOutstandingAmt)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_tblPaymentPlan_SubsequentUpdate]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@nPaymentPlanID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, nPaymentPlanID));
                cmdToExecute.Parameters.Add(new SqlParameter("@strReceiptNo", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, strReceiptNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@nInstalmentNo", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, nInstalmentNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@mPaidAmount", SqlDbType.Money, 8, ParameterDirection.Input, true, 19, 4, "", DataRowVersion.Proposed, mPaidAmount));
                cmdToExecute.Parameters.Add(new SqlParameter("@mAdjustedPaymentPlanAmt", SqlDbType.Money, 8, ParameterDirection.Input, true, 19, 4, "", DataRowVersion.Proposed, mAdjustedPaymentPlanAmt));
                cmdToExecute.Parameters.Add(new SqlParameter("@mOutstandingAmt", SqlDbType.Money, 8, ParameterDirection.Input, true, 19, 4, "", DataRowVersion.Proposed, mOutstandingAmt));                
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
                    throw new Exception("Stored Procedure 'sp_tblPaymentPlan_SubsequentUpdate' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TblPaymentPlan::Update::Error occured.", ex);
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

        public decimal GetInhouseIPPNextInstalmentAmount(string strReceiptNo)
        {
            string sqlIPPNextInstalmentAmount = "sp_GetInhouseIPPNextInstalmentAmount";

            object obj = base.ExecuteScalarStoreProc(sqlIPPNextInstalmentAmount, new string[] { "@strReceiptNo" }, new object[] { strReceiptNo });

            if (obj != null)
            {
                decimal mInstalmentAmt = (decimal)((decimal)obj);
                return mInstalmentAmt;
            }
            return 0;
        }

        public string GetInhouseIPPMasterOSReceipt(string strReceiptNo)
        {
            string sqlIPPMasterOSReceipt = "sp_GetInhouseIPPMasterOSReceipt";

            object obj = base.ExecuteScalarStoreProc(sqlIPPMasterOSReceipt, new string[] { "@strReceiptNo" }, new object[] { strReceiptNo });

            if (obj != null)
            {
                string strMasterReceiptNo = (string)((string)obj);
                return strMasterReceiptNo;
            }
            return strReceiptNo;
        }

        public string GetInhouseIPPMasterOSReceiptSimple(string strReceiptNo)
        {
            string sqlIPPMasterOSReceipt = "sp_GetInhouseIPPMasterOSReceiptSimple";

            object obj = base.ExecuteScalarStoreProc(sqlIPPMasterOSReceipt, new string[] { "@strReceiptNo" }, new object[] { strReceiptNo });

            if (obj != null)
            {
                string strMasterReceiptNo = (string)((string)obj);
                return strMasterReceiptNo;
            }
            return strReceiptNo;
        }

        /*public void SaveData(DataTable table)
        {
            base.SaveData(table, "Select * From tblPaymentPlan");
        }*/

        #region Class Property Declarations

        public SqlString StrMasterReceiptNo
        {
            get
            {
                return _strMasterReceiptNo;
            }
            set
            {
                _strMasterReceiptNo = value;
            }
        }

        public SqlString StrPaymentReceiptNo
        {
            get
            {
                return _strPaymentReceiptNo;
            }
            set
            {
                _strPaymentReceiptNo = value;
            }
        }

        public SqlString StrPackageList
        {
            get
            {
                return _strPackageList;
            }
            set
            {
                _strPackageList = value;
            }
        } 

        public SqlMoney MMasterReceiptTotal
        {
            get
            {
                return _mMasterReceiptTotal;
            }
            set
            {
                _mMasterReceiptTotal = value;
            }
        }

        public SqlMoney MPaymentAmount
        {
            get
            {
                return _mPaymentAmount;
            }
            set
            {
                _mPaymentAmount = value;
            }
        }

        public SqlMoney MOutstandingAmount
        {
            get
            {
                return _mOutstandingAmount;
            }
            set
            {
                _mOutstandingAmount = value;
            }
        }

        public SqlMoney MPaymentPlanAmt
        {
            get
            {
                return _mPaymentPlanAmt;
            }
            set
            {
                _mPaymentPlanAmt = value;
            }
        }

        public SqlMoney MPaidAmount
        {
            get
            {
                return _mPaidAmount;
            }
            set
            {
                _mPaidAmount = value;
            }
        }

        public SqlMoney MAdjustedPaymentPlanAmt
        {
            get
            {
                return _mAdjustedPaymentPlanAmt;
            }
            set
            {
                _mAdjustedPaymentPlanAmt = value;
            }
        }

        public SqlInt32 NInstalmentNo
        {
            get
            {
                return _nInstalmentNo;
            }
            set
            {
                _nInstalmentNo = value;
            }
        }

        public SqlInt32 NEnforceTotalInstalment
        {
            get
            {
                return _nEnforceTotalInstalment;
            }
            set
            {
                _nEnforceTotalInstalment = value;
            }
        }

        public SqlInt32 NTypeID
        {
            get
            {
                return _nTypeID;
            }
            set
            {
                _nTypeID = value;
            }
        }

        public SqlInt32 NIsDefaulted
        {
            get
            {
                return _IsDefaulted;
            }
            set
            {
                _IsDefaulted = value;
            }
        }

        public SqlInt32 NPaymentPlanID
        {
            get
            {
                return _nPaymentPlanID;
            }
            set
            {
                _nPaymentPlanID = value;
            }
        }

        public SqlDateTime DtPaymentDate
        {
            get
            {
                return _dtPaymentDate;
            }
            set
            {
                _dtPaymentDate = value;
            }
        }

        public SqlDateTime DtDueDate
        {
            get
            {
                return _dtDueDate;
            }
            set
            {
                _dtDueDate = value;
            }
        }

        public SqlDateTime DtFinalDueDate
        {
            get
            {
                return _dtFinalDueDate;
            }
            set
            {
                _dtFinalDueDate = value;
            }
        }

        public SqlDateTime DtDefaultedDate
        {
            get
            {
                return _dtDefaultedDate;
            }
            set
            {
                _dtDefaultedDate = value;
            }
        }

        #endregion

    }
}
