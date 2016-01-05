using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;


namespace ACMSDAL
{
    public class TblSchedule : DBInteractionBase
    {

        public void Insert(int _nStatus, int _nLabel, int _nType, DateTime _dtStart, DateTime _dtEnd)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_tblDeliverySchedule_Insert]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.AddWithValue("@nStatus", _nStatus);
                cmdToExecute.Parameters.AddWithValue("@nLabel", _nLabel);
                cmdToExecute.Parameters.AddWithValue("@nType", _nType);
                cmdToExecute.Parameters.AddWithValue("@dtStart", _dtStart);
                cmdToExecute.Parameters.AddWithValue("@dtEnd", _dtEnd);

                
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

                return;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TblReceipt::Insert::Error occured.", ex);
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


    }
}
