using System;

namespace Acms.Core.Domain
{
	/// <summary>
	/// Summary description for Id.
	/// </summary>
	public class Id
	{
		private string _stringId1;
		private string _stringId2;

		public Id() {}

		public Id(string stringId1, string stringId2) 
		{
			this._stringId1 = stringId1;
			this._stringId2 = stringId2;
		}

		public string StringId1
		{
			set{_stringId1 = value;}
			get{return _stringId1;}
		}

		public string StringId2
		{
			set{_stringId2 = value;}
			get{return _stringId2;}
		}
		
		public override bool Equals(object obj)
		{
			return base.Equals (obj);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode ();
		}


	
	}
}
