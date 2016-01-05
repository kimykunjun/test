///////////////////////////////////////////////////////////////////////////
// Description: Data Access class for the view 'Category'
// Generated by LLBLGen v1.2.1045.38210 Final on: Monday, September 26, 2005, 12:58:07 PM
// Because the Base Class already implements IDispose, this class doesn't.
///////////////////////////////////////////////////////////////////////////
using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace ACMSDAL
{
	/// <summary>
	/// Purpose: Data Access class for the view 'Category'.
	/// </summary>
	public class Category : DBInteractionBase
	{
		#region Class Member Declarations
			private SqlInt32		_nCategoryID, _nSalesCategoryID, _nPOSCategoryID;
			private SqlString		_sales_Category, _pOS_Category, _strDescription;
		#endregion


		/// <summary>
		/// Purpose: Class constructor.
		/// </summary>
		public Category()
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
		///		 <LI>NPOSCategoryID. May be SqlInt32.Null</LI>
		///		 <LI>POS_Category. May be SqlString.Null</LI>
		///		 <LI>NCategoryID</LI>
		///		 <LI>StrDescription. May be SqlString.Null</LI>
		///		 <LI>NSalesCategoryID. May be SqlInt32.Null</LI>
		///		 <LI>Sales_Category. May be SqlString.Null</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ErrorCode</LI>
		/// </UL>
		/// </remarks>
		public override bool Insert()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_Category_Insert]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@inPOSCategoryID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _nPOSCategoryID));
				cmdToExecute.Parameters.Add(new SqlParameter("@sPOS_Category", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _pOS_Category));
				cmdToExecute.Parameters.Add(new SqlParameter("@inCategoryID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _nCategoryID));
				cmdToExecute.Parameters.Add(new SqlParameter("@sstrDescription", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _strDescription));
				cmdToExecute.Parameters.Add(new SqlParameter("@inSalesCategoryID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _nSalesCategoryID));
				cmdToExecute.Parameters.Add(new SqlParameter("@sSales_Category", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _sales_Category));
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
				cmdToExecute.ExecuteNonQuery();
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'sp_Category_Insert' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("Category::Insert::Error occured.", ex);
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
		/// Purpose: SelectAll method. This method will Select all rows from the view.
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
			cmdToExecute.CommandText = "dbo.[sp_Category_SelectAll]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("Category");
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
					throw new Exception("Stored Procedure 'sp_Category_SelectAll' reported the ErrorCode: " + _errorCode);
				}

				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("Category::SelectAll::Error occured.", ex);
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
		public SqlInt32 NPOSCategoryID
		{
			get
			{
				return _nPOSCategoryID;
			}
			set
			{
				_nPOSCategoryID = value;
			}
		}


		public SqlString POS_Category
		{
			get
			{
				return _pOS_Category;
			}
			set
			{
				_pOS_Category = value;
			}
		}


		public SqlInt32 NCategoryID
		{
			get
			{
				return _nCategoryID;
			}
			set
			{
				SqlInt32 nCategoryIDTmp = (SqlInt32)value;
				if(nCategoryIDTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("NCategoryID", "NCategoryID can't be NULL");
				}
				_nCategoryID = value;
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


		public SqlInt32 NSalesCategoryID
		{
			get
			{
				return _nSalesCategoryID;
			}
			set
			{
				_nSalesCategoryID = value;
			}
		}


		public SqlString Sales_Category
		{
			get
			{
				return _sales_Category;
			}
			set
			{
				_sales_Category = value;
			}
		}
		#endregion
	}
}