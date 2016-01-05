using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace ACMS.Utils
{
	/// <summary>
	/// Summary description for WriteParcoFile.
	/// </summary>
	public class WriteParcoFile
	{
		public WriteParcoFile()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void WriteToFile(string path)
		{
			StreamWriter sw;
			sw = File.CreateText(path);
			FillHeaderLine();
			sw.WriteLine(HeaderLine);

			foreach(DataRow dr in PaymentRecord.Rows)
			{
				FillDetailsLine(dr);
				sw.WriteLine(DetailLine);
			}

			FillTrailerLine();
			sw.WriteLine(TrailerLine);

			sw.Flush();
			sw.Close();
	
		}

		private string HeaderLine;
		private string TrailerLine;
		private string DetailLine;

		private DataRow _terminal;
		public DataRow TerminalRecord
		{
			get
			{
				return _terminal;
			}
			set
			{
				_terminal = value;
			}
		}

     
		private DataRow _company;
		public DataRow CompanyRecord
		{
			get
			{
				return _company;
			}
			set
			{
				_company = value;
			}
		}


		private DataTable _payment;
		public DataTable PaymentRecord
		{
			get
			{
				return _payment;
			}
			set
			{
				_payment = value;
			}
		}


		private DataRow _shift;
		public DataRow ShiftRecord
		{
			get
			{
				return _shift;
			}
			set
			{
				_shift = value;
			}
		}


		private string FillHeaderLine()
		{
			if(ShiftRecord != null && CompanyRecord!= null && TerminalRecord!=null)
			{
				HeaderLine = "1|OPENED|" + CompanyRecord["nParcoShopNo"].ToString() + "|" + TerminalRecord["nTerminalID"].ToString() + "|";
				HeaderLine += ShiftRecord["nFirstReceiptNo"].ToString() + "|" + CompanyRecord["nParcoTranfileNo"].ToString() + "|";
				HeaderLine += Convert.ToDateTime(ShiftRecord["dtDate"]).ToString("yyyyMMdd") + "|" + Convert.ToDateTime(ShiftRecord["dtOpenTime"]).ToString("hh:mm:ss") + "|";
				HeaderLine += ShiftRecord["nOpenShiftStaffID"].ToString() + "|" + Convert.ToDateTime(ShiftRecord["dtDate"]).ToString("yyyyMMdd");
			}
			return HeaderLine;
		}
		
		private void FillDetailsLine(DataRow dr)
		{
			DetailLine = "\n";
			DetailLine += "101|" + dr["strReceiptNo"].ToString() + "|" + dr["nShiftID"].ToString() + "|" + Convert.ToDateTime(dr["dtDate"]).ToString("yyyymmdd") + "|" + Convert.ToDateTime(dr["dtOpenTime"]).ToString("hh:mm:ss") + "|" + dr["nOpenShiftStaffID"].ToString() + "|||||||N";
			DetailLine += Environment.NewLine;
			DetailLine += "111|" + "ABC|1.000|" +dr["mNettAmount"].ToString() + "|" + dr["mNettAmount"].ToString() + "||G||||||" + dr["mNettAmount"].ToString();
			DetailLine += "\n";
			DetailLine += "121|" + dr["mTotalAmount"].ToString() + "|0.00|0.00|0.00|" + dr["mGSTAmount"].ToString() +"|E|N||0.00";
			DetailLine += "\n";
			DetailLine += "131|T|" + dr["strPaymentGroupCode"].ToString() + "|SGD|001.0000000|" + dr["mNettAmount"].ToString() + "|||" + dr["mNettAmount"].ToString();
			DetailLine += "\n";
			DetailLine += "141|G|" + dr["mGSTAmount"].ToString();
			

		}
		private void FillTrailerLine()
		{
			if(ShiftRecord != null && CompanyRecord!= null && TerminalRecord!=null)
			{

				TrailerLine = "1|CLOSED|" + CompanyRecord["nParcoShopNo"].ToString() + "|" + TerminalRecord["nTerminalID"].ToString() + "|";
				TrailerLine += ShiftRecord["nLastReceiptNo"].ToString() + "|" + CompanyRecord["nParcoTranfileNo"].ToString() + "|";
				TrailerLine += Convert.ToDateTime(ShiftRecord["dtDate"]).ToString("yyyyMMdd") + "|" + Convert.ToDateTime(ShiftRecord["dtOpenTime"]).ToString("hh:mm:ss") + "|";
				TrailerLine += ShiftRecord["nOpenShiftStaffID"].ToString() + "|" + Convert.ToDateTime(ShiftRecord["dtDate"]).ToString("yyyyMMdd");
			}

		}
		
	}
}
