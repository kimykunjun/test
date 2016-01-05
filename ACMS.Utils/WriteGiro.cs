using System;

namespace ACMS.Utils
{
	/// <summary>
	/// Summary description for WriteGiro.
	/// </summary>
	public class WriteGiro
	{
		public WriteGiro()
		{
			
		}

		public string PadValue(string strTxt,int strLength,string space)
		{
			strTxt = strTxt.Trim().Replace("'","");
			if (strTxt.Trim().Length == 0)
			{
				return strTxt.PadRight(strLength);
			}
			else
			{
				if (strTxt.Trim().Length != strLength)
				{
					string tmpstring;
					tmpstring = "";
					int i;
					if (space == "")
					{
						for(i = 0;i<strLength - strTxt.Trim().Length; i++)
						{
							tmpstring = tmpstring + "";
						}
						return strTxt.Trim() + tmpstring;

					}
					else
					{
						string Leading;
						Leading = "";
						for(i = 0;i<strLength - strTxt.Trim().Length;i++)
						{
						     Leading += space.Replace("_","");
						}
						return Leading + strTxt.Trim();
					}

					}
				else
				{
					return strTxt;
				}
			}
		}

	
//		Case dtypeitem.type_string
//		strtxt = strtxt.Trim.Replace("'", "-")
//		If strtxt.Trim.Length = 0 Then
//paddvalue = strtxt.PadRight(stlength, Chr(32))
//Else
//	If strtxt.Trim.Length <> stlength Then
//								Dim tmpstring As String
//												Dim i As Integer
//															tmpstring = ""
//		For i = 0 To stlength - strtxt.Trim.Length - 1
//		tmpstring = tmpstring & " "
//		Next
//			paddvalue = strtxt.Trim & tmpstring
//			Else
//				paddvalue = strtxt
//				End If
//					End If
	}
}
