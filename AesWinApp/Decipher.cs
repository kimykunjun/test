using System;

namespace AesWinApp
{
	/// <summary>
	/// Summary description for Decipher.
	/// </summary>
	public class Decipher
	{
		public Decipher()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public int Decipher_License(string CipherLicense)
		{
			string Decryptlvl1;
			int  Decryptlvl2;
						
			Decryptlvl1=DecryptLevel(CipherLicense);
			Decryptlvl2=ReceiveLic(Decryptlvl1);

			return Decryptlvl2;
			//
			// TODO: Add constructor logic here
			//
		}

		private string DecryptLevel(string  cipherText)
		{
			string  plainText  = " ";// original plaintext
			string  passPhrase = "Pas5pr@se";        // can be any string
			string  initVector = "@1B2c3D4e5F6g7H8"; // must be 16 bytes
 
			// Before encrypting data, we will append plain text to a random
			// salt value, which will be between 4 and 8 bytes long (implicitly
			// used defaults).
			EnhancedCipher rKey =	new EnhancedCipher(passPhrase, initVector);
 
			// Encrypt the same plain text data 10 time (using the same key,
			// initialization vector, etc) and see the resulting cipher text;
			// encrypted values will be different.
			for (int i=0; i<10; i++)
			{
				plainText =rKey.Decrypt(cipherText);

			}

			return plainText;
		}

		private int ReceiveLic(string strLicense)
		{
			string uChar= "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			string sMatch=sLeft(strLicense,1);
			string intlicense="";
			string Buylicense="";
			
			//intlicense=txtLicenseNo.Text;

			for (int i = 0;i <= (uChar.Length -1);i++)
			{
				if (sMatch.ToUpper()== Mid(uChar,i,1))
				{
					intlicense=Mid(strLicense,i,Convert.ToInt16(sRight(strLicense,1)));
					break ;
				}
			}
			
			for (int i = 0;i <= (intlicense.Length)-1;i++)
			{
				Buylicense=Buylicense+ConvertString(Mid(intlicense,i,1).ToString());
			}

			return Convert.ToInt32(Buylicense);
		}



		private int ConvertString(string LicenseNo)
		{
			switch(LicenseNo)
			{
				case "h"	:	return 0;
				case "e"	:	return 1;
				case "a"	:	return 2;
				case "d"	:	return 3;
				case "s"	:	return 4;
				case "t"	:	return 5;
				case "A"	:	return 6;
				case "r"	:	return 7;
				case "T"	:	return 8;
				case "S"	:	return 9;
			}

			return 0;
		}

		
		public static string sLeft(string param, int length)
		{
			//we start at 0 since we want to get the characters starting from the
			//left and with the specified lenght and assign it to a variable
			string result = param.Substring(0, length);
			//return the result of the operation
			return result;
		}


		public static string sRight(string param, int length)
		{
			//start at the index based on the lenght of the sting minus
			//the specified lenght and assign it a variable
			string result = param.Substring(param.Length - length, length);
			//return the result of the operation
			return result;
		}

		public static string Mid(string param,int startIndex, int length)
		{
			//start at the specified index in the string ang get N number of
			//characters depending on the lenght and assign it to a variable
			string result = param.Substring(startIndex, length);
			//return the result of the operation
			return result;
		}


		public static string Mid(string param,int startIndex)
		{
			//start at the specified index and return all characters after it
			//and assign it to a variable
			string result = param.Substring(startIndex);
			//return the result of the operation
			return result;
		}
	}

}
