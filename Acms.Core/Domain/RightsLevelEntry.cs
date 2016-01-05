using System;

namespace Acms.Core.Domain
{
	/// <summary>
	/// Summary description for EmployeeBranchRights.
	/// </summary>
	public class RightsLevelEntry
	{
		protected Right _right;
		protected RightsLevel _rightslevel;

		public RightsLevelEntry()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public RightsLevelEntry(Right right, RightsLevel rightslevel)
		{
			this._right = right;
			this._rightslevel = rightslevel;
		}

		public virtual Right Right
		{
			set{_right = value;}
			get{return _right;}
		}

		public  virtual RightsLevel RightsLevel
		{
			set{_rightslevel = value;}
			get{return _rightslevel;}
		}
	}
}
