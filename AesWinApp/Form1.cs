using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;

namespace AesWinApp
{
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtLicenseNo;

		
		public Form1()
		{
			InitializeComponent();
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.button3 = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.button4 = new System.Windows.Forms.Button();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.button5 = new System.Windows.Forms.Button();
			this.txtLicenseNo = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(16, 168);
			this.textBox1.MaxLength = 8;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(352, 20);
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(16, 208);
			this.textBox2.MaxLength = 0;
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(352, 20);
			this.textBox2.TabIndex = 1;
			this.textBox2.Text = "";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(16, 256);
			this.textBox3.MaxLength = 0;
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(352, 20);
			this.textBox3.TabIndex = 2;
			this.textBox3.Text = "";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(384, 176);
			this.button1.Name = "button1";
			this.button1.TabIndex = 4;
			this.button1.Text = "encipher ->";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(384, 224);
			this.button2.Name = "button2";
			this.button2.TabIndex = 5;
			this.button2.Text = "decipher ->";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 152);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 16);
			this.label1.TabIndex = 6;
			this.label1.Text = "plaintext";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 192);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 16);
			this.label2.TabIndex = 7;
			this.label2.Text = "ciphertext";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 232);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(88, 16);
			this.label3.TabIndex = 8;
			this.label3.Text = "deciphered text";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(16, 32);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(352, 20);
			this.textBox4.TabIndex = 9;
			this.textBox4.Text = "";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(384, 32);
			this.button3.Name = "button3";
			this.button3.TabIndex = 10;
			this.button3.Text = "Generate";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 16);
			this.label4.TabIndex = 11;
			this.label4.Text = "Random";
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(96, 80);
			this.button4.Name = "button4";
			this.button4.TabIndex = 12;
			this.button4.Text = "Build";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(16, 112);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(352, 20);
			this.textBox5.TabIndex = 13;
			this.textBox5.Text = "";
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(384, 112);
			this.button5.Name = "button5";
			this.button5.TabIndex = 14;
			this.button5.Text = "Populate";
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// txtLicenseNo
			// 
			this.txtLicenseNo.Location = new System.Drawing.Point(16, 80);
			this.txtLicenseNo.Name = "txtLicenseNo";
			this.txtLicenseNo.Size = new System.Drawing.Size(64, 20);
			this.txtLicenseNo.TabIndex = 15;
			this.txtLicenseNo.Text = "1";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 64);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 16);
			this.label5.TabIndex = 16;
			this.label5.Text = "No of Licenses";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(480, 310);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtLicenseNo);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.textBox5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.textBox4);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label3);
			this.Name = "Form1";
			this.Text = "Advanced Encryption Standard For AIMS";
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}


		private void button1_Click(object sender, System.EventArgs e)
		{
		string  plainText  = textBox1.Text.ToString();// original plaintext
		string  cipherText = "";                 // encrypted text
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

		cipherText =rKey.Encrypt(plainText);
			textBox2.Text=cipherText;

		plainText =rKey.Decrypt(cipherText);
		
	}
 
	// Make sure we got decryption working correctly.
	}

		private void button2_Click(object sender, System.EventArgs e)
		{
		string  plainText  = " ";// original plaintext
		string  cipherText = textBox2.Text.ToString();               // encrypted text
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
			textBox3.Text=plainText;

		}
 
	}
		private int des_license(string cipherText)
		{
			string  plainText1  = " ";// original plaintext
			string  plainText2  = " ";// original plaintext
			//string  cipherText = textBox2.Text.ToString();               // encrypted text
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
				plainText1 =rKey.Decrypt(cipherText);

			}

			return Convert.ToInt32(plainText1);
		}

		private int RandomNumber(int min, int max)
		{
			Random random = new Random();
			return random.Next(min, max); 
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			
			Randomize RdPassword = new Randomize();
			textBox4.Text=RdPassword.Generate(27).ToString();

			//int num = random.Next(1000);
			//textBox4.Text=num.ToString();
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
			textBox5.Text=TransferLic(textBox4.Text);
		}

		private string TransferLic(string strLicense)
		{
			string uChar= "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			string sMatch=sLeft(strLicense,1);
			string Result=" ";
			string intlicense;
			string Buylicense="";
			
			intlicense=txtLicenseNo.Text;

			for (int i = 0;i <= (intlicense.Length)-1;i++)
			{
				Buylicense=Buylicense+ConvertDigit(Convert.ToInt32(Mid(intlicense,i,1)));
			}

			for (int i = 0;i <= (uChar.Length -1);i++)
			{
				if (sMatch.ToUpper()== Mid(uChar,i,1))
				{
					//MessageBox.Show(i.ToString());
					Result=Mid(strLicense,0,i)+ Buylicense.ToString()+Mid(strLicense,(i + Buylicense.Length),(strLicense.Length-(i+Buylicense.Length)));
				
				}
			}
			return Result + intlicense.Length.ToString();
		}


		private string ReceiveLic(string strLicense)
		{
			string uChar= "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			string sMatch=sLeft(strLicense,1);
			string Result=" ";
			string intlicense;
			string Buylicense="";
			
			intlicense=txtLicenseNo.Text;

			for (int i = 0;i <= (uChar.Length -1);i++)
			{
				if (sMatch.ToUpper()== Mid(uChar,i,1))
				{
					//MessageBox.Show(i.ToString());
					Result=Mid(strLicense,0,i)+ Buylicense.ToString()+Mid(strLicense,(i + Buylicense.Length),(strLicense.Length-(i+Buylicense.Length)));
				
				}
			}
			
			for (int i = 0;i <= (intlicense.Length)-1;i++)
			{
				Buylicense=Buylicense+ConvertDigit(Convert.ToInt32(Mid(intlicense,i,1)));
			}

			return Result;
		}

		private string ConvertDigit(int LicenseNo)
		{
			switch(LicenseNo)
			{
				case 0 :	return "h";
				case 1 :	return "e";
				case 2 :	return "a";
				case 3 :	return "d";
				case 4 :	return "s";
				case 5 :	return "t";
				case 6 :	return "A";
				case 7 :	return "r";
				case 8 :	return "T";
				case 9 :	return "S";
			}

				return "z";
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

		private void button5_Click(object sender, System.EventArgs e)
		{
		textBox1.Text=textBox5.Text;	
		}

		public static string sLeft(string param, int length)
		{
			//we start at 0 since we want to get the characters starting from the
			//left and with the specified lenght and assign it to a variable
			string result = param.Substring(0, length);
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




//
//		public string GetPassword()
//		{
//			StringBuilder builder = new StringBuilder();
//			builder.Append(RandomString(4, true));
//			builder.Append(RandomInt(1000, 9999));
//			builder.Append(RandomString(2, false));
//			return builder.ToString();
//		}

	}  // class Form1
}  // ns AesDemoWinApp
