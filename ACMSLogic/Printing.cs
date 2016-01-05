using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using ACMSDAL;
using System.IO;
using System.Windows.Forms;
using System.Configuration;
namespace ACMSLogic
{
	/// <summary>
	/// Summary description for Printing.
	/// </summary>
	public class Printing
	{
		private StreamWriter myStreamWriter;		
		private StreamReader myStreamReader;
		private Font myTextFont;
		private string myFilePath = "";
		private bool myHasWriteLine;

		public Printing()
		{
			//
			// TODO: Add constructor logic here
			//
            myFilePath = ConfigurationSettings.AppSettings["TempPrintPath"].ToString() + ACMSLogic.User.BranchCode + ACMSLogic.User.EmployeeID + ".txt";
			
			if (File.Exists(myFilePath))
			{
				myStreamWriter = new StreamWriter(myFilePath, false); 
			}
			else
			{
				myStreamWriter = File.CreateText(myFilePath);
			}
		
			//myPrintingDocument = new PrintDocument();
			//Init();
		}

		public Printing(string Type)
		{			//
			// TODO: Add constructor logic here
			//
			
		
			//myPrintingDocument = new PrintDocument();
			//Init();
		}
		public void WriteLine(string text)
		{
			myStreamWriter.WriteLine(text); 
			myHasWriteLine = true;
		}

		private void Print(string filePath)
		{
			myFilePath = filePath;
			Print();
		}

		public void DelFile()
		{
			myStreamWriter.Close();
		
			myStreamReader = new StreamReader(myFilePath);
	
			myStreamReader.Close();
			File.Delete(myFilePath);
		}

		public void Close()
		{

			myStreamWriter.Close();
		}


		public void Print()
		{
			
			if (!myHasWriteLine) return;
			
			myStreamWriter.Close();
		
			myStreamReader = new StreamReader(myFilePath);
			
			try 
			{
				myTextFont = new Font("Arial", 9);
				TextFilePrintDocument pd = new TextFilePrintDocument(myStreamReader);
				//PrintDocument pd = new PrintDocument();

			//	pd.DefaultPageSettings.PaperSize.Height= myTextFont.Height;
//				pd.DefaultPageSettings.PaperSize= new System.Drawing.Printing.PaperSize("PaperA4",76,9000);

				
//				pd.DefaultPageSettings.PaperSize=auto;//new PaperSize("new size", myStreamReader.PageSize.Width, myStreamReader.PageSize.Height);
//				pd.DefaultPageSettings.Margins =auto;//new Margins(pd .PageMargins.Left, myStreamReader.PageMargins.Right, myStreamReader.PageMargins.Top, myStreamReader.PageMargins.Bottom);	
				pd.PrintPage += new PrintPageEventHandler
					(this.pd_PrintPage);
				 
				pd.Print();
			}  
			catch (System.ComponentModel.Win32Exception ex)
			{
				MessageBox.Show(ex.Message);	
			}
			finally 
			{
				myStreamReader.Close();
				File.Delete(myFilePath);		
			}
		}


		public void Print2()
		{
			try 
			{
				myStreamWriter.Close();
				StreamReader streamToPrint = new StreamReader (myFilePath);
				try 
				{
					myTextFont = new Font("Arial", 9);
					TextFilePrintDocument pd = new TextFilePrintDocument(streamToPrint); //Assumes the default printer

					PrintDialog dlg = new PrintDialog() ;
					pd.PrintPage += new PrintPageEventHandler
						(this.pd_PrintPage);
					dlg.Document = pd;

				//	pd.Print();
					
										DialogResult result = dlg.ShowDialog();

					if (result == DialogResult.OK) 
					{
						pd.Print();
					}
				} 
				finally 
				{
				streamToPrint.Close();
				File.Delete(myFilePath);
//
				}
			} 
			catch(Exception ex) 
			{
				MessageBox.Show("An error occurred printing the file - " + ex.Message);
			}
		}
	

		public void page_write() 
		{
			TblReceiptPayment BJreceipt = new TblReceiptPayment();
			DateTime ReceiptDate = DateTime.Now;
			DataTable tblBJReceipt = BJreceipt.selectBJsales(ReceiptDate);
			DataTable tblSetup = BJreceipt.BJFileSetup();
			string strMachineID = tblSetup.Rows[0]["strMachineID"].ToString();
			string strFile = tblSetup.Rows[0]["nFile"].ToString();
			string strDir = tblSetup.Rows[0]["strDir"].ToString();
			string strVal = string.Empty;
			double sumTotal= 0.00;
			TextWriter tw = new StreamWriter(strDir + strMachineID + "." + strFile);
			for (int i = 0; i < tblBJReceipt.Rows.Count; i++)
			{
				sumTotal = sumTotal + System.Convert.ToDouble(tblBJReceipt.Rows[i][0]);
//				strVal = "0000000"+tblBJReceipt.Rows[i][0].ToString();
//				
//				if(strVal.Length > 11)
//					strVal = Right(strVal, 11);
//					
//				tw.WriteLine(strMachineID + DateTime.Now.ToString("yyyyMMdd")+strVal);
			}
			strVal = "0000000" + sumTotal.ToString("#0.00");
			strVal = Right(strVal, 11);
			tw.WriteLine(strMachineID + DateTime.Now.ToString("yyyyMMdd")+strVal);
			tw.Close();
			int nFileNo = System.Convert.ToInt32(strFile);
			nFileNo = nFileNo + 1;
			strFile = nFileNo.ToString();
			BJreceipt.UpdateFileNo(strFile);		
			//File.Delete(myFilePath);

//			DataView attendedMemberTable = myClassAttendance.GetClassAttendanceView(NClassInstanceID);
//				
//			attendedMemberTable.RowFilter = "nStatusID = 1";
//			for (int i = 0; i < attendedMemberTable.Count; i++)
//			{
//				int j = i + 1;
//			
//				if (j < attendedMemberTable.Count)
//				{
//					strLine = string.Format("--{0}      --{1}", 
//						attendedMemberTable[i]["strMembershipID"].ToString(),
//						attendedMemberTable[j]["strMembershipID"].ToString());
//					myReceiptPrinting.WriteLine(strLine);
//					i = j;
//					// write a line of text to the file
//				
//				}
//			}
		}


		public static string Right(string param, int length)
		{
			string result = param.Substring(param.Length - length, length);
			return result;
		}


		private void pd_PrintPage(object sender, PrintPageEventArgs ev) 
		{
			float linesPerPage = 0;
			float yPos =  0;
			int count = 0;
			float leftMargin = 5;
			float topMargin = 0;
			String line = null;
            
			// Calculate the number of lines per page.
			linesPerPage = (-1 *ev.MarginBounds.Height)  / 
				myTextFont.GetHeight(ev.Graphics) ;

			while (((line = myStreamReader.ReadLine()) != null)) 
			{
				yPos = topMargin + (count * myTextFont.GetHeight(ev.Graphics));
				ev.Graphics.DrawString (line, myTextFont, Brushes.Black, 
					leftMargin, yPos, new StringFormat());
				count++;
			}



			// Iterate over the file, printing each line.
//			while (count < linesPerPage && 
//				((line = myStreamReader.ReadLine()) != null)) 
//			{
//				yPos = topMargin + (count * myTextFont.GetHeight(ev.Graphics));
//				ev.Graphics.DrawString (line, myTextFont, Brushes.Black, 
//					leftMargin, yPos, new StringFormat());
//				count++;
//			}
//
//			// If more lines exist, print another page.
//			if (line != null) 
//				ev.HasMorePages = true;
//			else 
//				ev.HasMorePages = false;
		}

	

//		private void Init()
//		{
//			PrinterSettings printersetting = new PrinterSettings();
//			
//			myPageSetting = new PageSettings();
//			myPageSetting.Margins = new Margins(100, 422, 100, 100);
//			//myPageSetting.PaperSource = 
//		}
	}
}
