#region =============== Class file overview ====================
/****************************************************
 * Description			: To manipulate the Access Rights.
 * Created Date			: 03-Jan-2007
 * Modified Date		: 03-Jan-2007
 * Last Modified Date	: 
 * Created By			: Albert Sun
 ****************************************************/
#endregion
#region =============== Class Header ====================
using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
#endregion

namespace ACMSDAL
{
	/// <summary>
	/// Summary description for vwRights.
	/// </summary>
	public class vwRights : DBInteractionBase
	{
		#region =============== Class Local Properties ===============
		private SqlInt32 _nRightLevelID, _nRightsID, _nEmployeeID;
		private SqlString _strFunctionName;
		#endregion

		#region =============== Class Properties ===============
		public SqlInt32 nRightLevelID
		{
			get
			{
				return _nRightLevelID;
			}
			set
			{
				_nRightLevelID = value;
			}
		}

		public SqlInt32 nRightsID
		{
			get
			{
				return _nRightsID;
			}
			set
			{
				_nRightsID = value;
			}
		}

		public SqlInt32 nEmployeeID
		{
			get
			{
				return _nEmployeeID;
			}
			set
			{
				_nEmployeeID = value;
			}
		}

		public SqlString strFunctionName
		{
			get
			{
				return _strFunctionName;
			}
			set
			{
				_strFunctionName = value;
			}
		}
		#endregion

		#region =============== Class Function and Methods ===============
		/// <summary>
		/// Class constructor which set blank values to the local variable.
		/// </summary>
		public vwRights()
		{
			this._nRightLevelID = 0;
			this._nRightsID = 0;
			this._nEmployeeID = 0;
			this._strFunctionName = "";
		}

		/// <summary>
		/// Reterive the Rights from the database and return the user has rights or not.
		/// Require parameters : Function Name and Employee ID.
		/// 1 - User Has Rights
		/// 0 - No Access
		/// </summary>
		/// <returns>Boolean value True, 1, or False, 0.</returns>
		public bool GetRights()
		{
			SqlCommand cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_GetRights]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			DataTable dtReturn = new DataTable("vwRights");
			SqlDataAdapter adExecute = new SqlDataAdapter(cmdToExecute);

			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@nEmployeeID",SqlDbType.Int,4,ParameterDirection.Input,false,10,0,"",DataRowVersion.Proposed,_nEmployeeID));
				cmdToExecute.Parameters.Add(new SqlParameter("@strFuncName",SqlDbType.VarChar,100,ParameterDirection.Input,false,0,0,"",DataRowVersion.Proposed,_strFunctionName));

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

				adExecute.Fill(dtReturn);

				if(dtReturn.Rows.Count>0)
					return true;
				else
					return false;
			}
			catch(Exception ex)
			{
				throw new Exception("vwRights::GetRights", ex);
			}
			finally
			{
				if(_mainConnectionIsCreatedLocal)
				{
					// Close connection.
					_mainConnection.Close();
				}
				cmdToExecute.Dispose();
				adExecute.Dispose();
			}
		}
		#endregion

	}
}
