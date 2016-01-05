using System;

namespace ACMS.ACMSBranch.StockRequest
{
	/// <summary>
	/// Summary description for SearchProduct.
	/// </summary>
	public class SearchProduct
	{
		private string strProductCode;

		public SearchProduct(string strProductCode)
		{
			this.strProductCode=strProductCode;
		}

		public string StrProductCode
		{
			set{strProductCode=value;}
			get{return strProductCode;}
		}
	}
}
