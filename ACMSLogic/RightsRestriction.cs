#region =============== Class file overview ====================
/****************************************************
 * Description			: To manipulate the Access Rights.
 * Created Date			: 03-Jan-2007
 * Modified Date		: 03-Jan-2007
 * Last Modified Date	: 
 * Created By			: Albert Sun
 ****************************************************/
#endregion
#region =============== Class Header ===============
using System;
using System.Data;
using System.Data.SqlClient;
using ACMSDAL;
#endregion

namespace ACMSLogic
{
	/// <summary>
	/// Summary description for RightsRestriction.
	/// </summary>
	public class RightsRestriction
	{
		#region =============== Class Local Variables ===============
		private ACMSDAL.vwRights mRights;
		#endregion
		
		#region =============== Class Functions and Methods ===============
		public RightsRestriction()
		{
			Init();
		}

		private void Init()
		{
			mRights = new vwRights();
		}

		public bool GetRights(int nEmployeeID, string strFunctionID)
		{
			mRights.nEmployeeID = nEmployeeID;
			mRights.strFunctionName = strFunctionID;

			return mRights.GetRights();
		}
		#endregion
	}
}
