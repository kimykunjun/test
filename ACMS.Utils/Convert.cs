namespace ACMS
{
    using System;

    public class Convert
    {
        // Methods
        internal Convert()
        {
        }

        public static string BooleanToText(bool TF)
        {
            if (TF)
            {
                return "T";
            }
            return "F";
        }

        public static bool TextToBoolean(object obj)
        {
            if ((obj == null) || (obj == DBNull.Value))
            {
                return false;
            }
            return ((string.Compare(obj.ToString(), "T", true) == 0) || (string.Compare(obj.ToString(), "True", true) == 0));
        }

        public static string ToBahasa(decimal amount)
        {
            string text1 = "";
            long num1 = (long) amount;
            long num2 = 0x38d7ea4c68000;
            long num3 = num1 / num2;
            if (num3 > 0)
            {
                text1 = text1 + ACMS.Convert.ToThousandEnglish((int) num3) + " QUADRILION ";
            }
            num1 = num1 % num2;
            long num4 = 0xe8d4a51000;
            num3 = num1 / num4;
            if (num3 > 0)
            {
                text1 = text1 + ACMS.Convert.ToThousandBahasa((int) num3) + " TRILION ";
            }
            num1 = num1 % num4;
            long num5 = 0x3b9aca00;
            num3 = num1 / num5;
            if (num3 > 0)
            {
                text1 = text1 + ACMS.Convert.ToThousandBahasa((int) num3) + " BILION ";
            }
            num1 = num1 % num5;
            long num6 = 0xf4240;
            num3 = num1 / num6;
            if (num3 > 0)
            {
                text1 = text1 + ACMS.Convert.ToThousandBahasa((int) num3) + " JUTA ";
            }
            num1 = num1 % num6;
            num3 = num1 / ((long) 0x3e8);
            if (num3 > 0)
            {
                text1 = text1 + ACMS.Convert.ToThousandBahasa((int) num3) + " RIBU ";
            }
            num1 = num1 % ((long) 0x3e8);
            if (num1 > 0)
            {
                text1 = text1 + ACMS.Convert.ToThousandBahasa((int) num1) + " ";
            }
            amount -= decimal.Truncate(amount);
            amount *= new decimal(100);
            num3 = (long) amount;
            if (num3 > 0)
            {
                if (text1.Length > 0)
                {
                    text1 = text1 + "DAN SEN " + ACMS.Convert.ToThousandBahasa((int) num3);
                }
                else
                {
                    text1 = text1 + ACMS.Convert.ToThousandBahasa((int) num3) + " SEN";
                }
            }
            if (text1.Length == 0)
            {
                text1 = "KOSONG";
            }
            return (text1.Trim() + " SAHAJA");
        }

        public static bool ToBoolean(object obj)
        {
            if ((obj == null) || (obj == DBNull.Value))
            {
                return false;
            }
            return System.Convert.ToBoolean(obj);
        }

        public static string ToBooleanText(object obj)
        {
            if ((obj == null) || (obj == DBNull.Value))
            {
                return "F";
            }
            return ACMS.Convert.BooleanToText(System.Convert.ToBoolean(obj));
        }

        public static string ToChinese(decimal amount, bool isSimplifiedChinese)
        {
            string text2;
            string text3;
            string text1 = "";
            if (isSimplifiedChinese)
            {
                text2 = "\u4ebf";
                text3 = "\u4e07";
            }
            else
            {
                text2 = "\u5104";
                text3 = "\u842c";
            }
            long num1 = (long) amount;
            long num2 = 0xe8d4a51000;
            long num3 = num1 / num2;
            if (num3 > 0)
            {
                text1 = text1 + ACMS.Convert.ToChineseWan((int) num3, isSimplifiedChinese) + "\u5146";
            }
            num1 = num1 % num2;
            long num4 = 0x5f5e100;
            num3 = num1 / num4;
            if (num3 > 0)
            {
                text1 = text1 + ACMS.Convert.ToChineseWan((int) num3, isSimplifiedChinese) + text2;
            }
            num1 = num1 % num4;
            num3 = num1 / ((long) 0x2710);
            if (num3 > 0)
            {
                text1 = text1 + ACMS.Convert.ToChineseWan((int) num3, isSimplifiedChinese) + text3;
            }
            num1 = num1 % ((long) 0x2710);
            if (num1 > 0)
            {
                text1 = text1 + ACMS.Convert.ToChineseWan((int) num1, isSimplifiedChinese);
            }
            if (text1.Length > 0)
            {
                text1 = text1 + "\u5143";
            }
            amount -= decimal.Truncate(amount);
            amount *= new decimal(100);
            num3 = (long) amount;
            if (num3 > 0)
            {
                long num5 = num3 / ((long) 10);
                if (num5 > 0)
                {
                    text1 = text1 + ACMS.Convert.ToChineseWan((int) num5, isSimplifiedChinese) + "\u89d2";
                }
                num5 = num3 % ((long) 10);
                if (num5 > 0)
                {
                    text1 = text1 + ACMS.Convert.ToChineseWan((int) num5, isSimplifiedChinese) + "\u5206";
                }
            }
            if (text1.Length == 0)
            {
                text1 = "\u96f6\u5143";
            }
            return (text1 + "\u6b63");
        }

        private static string ToChineseWan(int amount, bool isSimplifiedChinese)
        {
            string[] textArray3;
            string[] textArray4 = new string[10] { "\u58f9", "\u8d30", "\u53c1", "\u8086", "\u4f0d", "\u9646", "\u67d2", "\u634c", "\u7396", "\u62fe" } ;
            string[] textArray1 = textArray4;
            string[] textArray5 = new string[10] { "\u58f9", "\u8cb3", "\u53c4", "\u8086", "\u4f0d", "\u9678", "\u67d2", "\u634c", "\u7396", "\u62fe" } ;
            string[] textArray2 = textArray5;
            if (isSimplifiedChinese)
            {
                textArray3 = textArray1;
            }
            else
            {
                textArray3 = textArray2;
            }
            string text1 = "";
            amount = amount % 0x2710;
            int num1 = amount / 0x3e8;
            if (num1 > 0)
            {
                text1 = text1 + textArray3[num1 - 1] + "\u4edf";
            }
            amount = amount % 0x3e8;
            int num2 = amount / 100;
            if (num2 > 0)
            {
                text1 = text1 + textArray3[num2 - 1] + "\u4f70";
            }
            amount = amount % 100;
            int num3 = amount / 10;
            if (num3 == 1)
            {
                if (text1.Length == 0)
                {
                    text1 = text1 + "\u62fe";
                    goto Label_017E;
                }
                text1 = text1 + textArray3[num3 - 1] + "\u62fe";
            }
            else if (num3 > 0)
            {
                text1 = text1 + textArray3[num3 - 1] + "\u62fe";
            }
        Label_017E:
            amount = amount % 10;
            if (amount > 0)
            {
                text1 = text1 + textArray3[amount - 1];
            }
            return text1;
        }

		public static string ToMonth(int monthInNumber)
		{
			if (monthInNumber == 1)
				return "January";
			if (monthInNumber == 2)
				return "February";
			if (monthInNumber == 3)
				return "March";
			if (monthInNumber == 4)
				return "April";
			if (monthInNumber == 5)
				return "May";
			if (monthInNumber == 6)
				return "June";
			if (monthInNumber == 7)
				return "July";
			if (monthInNumber == 8)
				return "August";
			if (monthInNumber == 9)
				return "September";
			if (monthInNumber == 10)
				return "October";
			if (monthInNumber == 11)
				return "November";
			if (monthInNumber == 12)
				return "December";
			return "";
		}

        public static DateTime ToDateTime(object obj)
        {
            if ((obj == null) || (obj == DBNull.Value))
            {
                return DateTime.MinValue;
            }
            return System.Convert.ToDateTime(obj);
        }
		
		public static System.Data.SqlTypes.SqlString ToSqlString(object obj)
		{
			if ((obj == null) || (obj == DBNull.Value))
			{
				return System.Data.SqlTypes.SqlString.Null;
			}
			return obj.ToString();
		}
		
		public static System.Data.SqlTypes.SqlInt32 ToSqlInt32(object obj)
		{
			if ((obj == null) || (obj == DBNull.Value))
			{
				return System.Data.SqlTypes.SqlInt32.Null;
			}
			return ACMS.Convert.ToInt32(obj);
		}

        public static DBBoolean ToDBBoolean(object obj)
        {
            if ((obj == null) || (obj == DBNull.Value))
            {
                return new DBBoolean(DBNull.Value);
            }
            return new DBBoolean(ACMS.Convert.ToBoolean(obj));
        }

        public static DBDateTime ToDBDateTime(object obj)
        {
            if ((obj == null) || (obj == DBNull.Value))
            {
                return new DBDateTime(DBNull.Value);
            }
            return new DBDateTime(ACMS.Convert.ToDateTime(obj));
        }

        public static DBDecimal ToDBDecimal(object obj)
        {
            if ((obj == null) || (obj == DBNull.Value))
            {
                return new DBDecimal(DBNull.Value);
            }
            return new DBDecimal(ACMS.Convert.ToDecimal(obj));
        }

        public static DBInt16 ToDBInt16(object obj)
        {
            if ((obj == null) || (obj == DBNull.Value))
            {
                return new DBInt16(DBNull.Value);
            }
            return new DBInt16(ACMS.Convert.ToInt16(obj));
        }

        public static DBInt32 ToDBInt32(object obj)
        {
            if ((obj == null) || (obj == DBNull.Value))
            {
                return new DBInt32(DBNull.Value);
            }
            return new DBInt32(ACMS.Convert.ToInt32(obj));
        }

        public static DBInt64 ToDBInt64(object obj)
        {
            if ((obj == null) || (obj == DBNull.Value))
            {
                return new DBInt64(DBNull.Value);
            }
            return new DBInt64(ACMS.Convert.ToInt64(obj));
        }

        public static object ToDBObject(DBBoolean aDBType)
        {
            if ((aDBType == null) || !aDBType.HasValue)
            {
                return DBNull.Value;
            }
            bool flag1 = (bool) aDBType;
            return ACMS.Convert.BooleanToText(flag1);
        }

        public static object ToDBObject(DBDateTime aDBType)
        {
            if ((aDBType == null) || !aDBType.HasValue)
            {
                return DBNull.Value;
            }
            return (DateTime) aDBType;
        }

        public static object ToDBObject(DBDecimal aDBType)
        {
            if ((aDBType == 0) || !aDBType.HasValue)
            {
                return DBNull.Value;
            }
            return (decimal) aDBType;
        }

        public static object ToDBObject(DBInt16 aDBType)
        {
            if ((aDBType == 0) || !aDBType.HasValue)
            {
                return DBNull.Value;
            }
            return (short) aDBType;
        }

        public static object ToDBObject(DBInt32 aDBType)
        {
            if ((aDBType == 0) || !aDBType.HasValue)
            {
                return DBNull.Value;
            }
            return (int) aDBType;
        }

        public static object ToDBObject(DBInt64 aDBType)
        {
            if ((aDBType == 0) || !aDBType.HasValue)
            {
                return DBNull.Value;
            }
            return (long) aDBType;
        }

        public static object ToDBObject(DBString aDBType)
        {
            if ((aDBType == null) || !aDBType.HasValue)
            {
                return DBNull.Value;
            }
            return aDBType.ToString();
        }

        public static DBString ToDBString(object obj)
        {
            if ((obj == null) || (obj == DBNull.Value))
            {
                return new DBString(DBNull.Value);
            }
            return new DBString(obj.ToString());
        }


		public static double ToDouble(object obj)
		{
			if (obj == DBNull.Value)
			{
				return 0d;
			}
		
			if (obj is System.Data.SqlTypes.SqlDouble)
			{
				System.Data.SqlTypes.SqlDouble o = (System.Data.SqlTypes.SqlDouble) obj;
				if (o.IsNull)
					return 0d;
				else
					return o.Value;
			}

			return System.Convert.ToDouble(obj);

		}

		public static decimal ToDecimal(object obj)
		{
  
			if (obj == null)
				return 0;
 
			if (obj is System.Data.SqlTypes.SqlDecimal)
			{
				System.Data.SqlTypes.SqlDecimal o = (System.Data.SqlTypes.SqlDecimal) obj;
				if (o.IsNull)
					return 0;
				else
					return o.Value;
			}
			else if (obj is System.Data.SqlTypes.SqlMoney)
			{
				System.Data.SqlTypes.SqlMoney o = (System.Data.SqlTypes.SqlMoney) obj;
				if (o.IsNull)
					return 0;
				else
					return o.Value;
			}
			else if (obj == DBNull.Value)
			{
				return 0;
			}
			return System.Convert.ToDecimal(obj);
		}


        public static string ToEnglish(decimal amount)
        {
            string text1 = "";
            long num1 = (long) amount;
            long num2 = 0x38d7ea4c68000;
            long num3 = num1 / num2;
            if (num3 > 0)
            {
                text1 = text1 + ACMS.Convert.ToThousandEnglish((int) num3) + " QUADRILLION ";
            }
            num1 = num1 % num2;
            long num4 = 0xe8d4a51000;
            num3 = num1 / num4;
            if (num3 > 0)
            {
                text1 = text1 + ACMS.Convert.ToThousandEnglish((int) num3) + " TRILLION ";
            }
            num1 = num1 % num4;
            long num5 = 0x3b9aca00;
            num3 = num1 / num5;
            if (num3 > 0)
            {
                text1 = text1 + ACMS.Convert.ToThousandEnglish((int) num3) + " BILLION ";
            }
            num1 = num1 % num5;
            long num6 = 0xf4240;
            num3 = num1 / num6;
            if (num3 > 0)
            {
                text1 = text1 + ACMS.Convert.ToThousandEnglish((int) num3) + " MILLION ";
            }
            num1 = num1 % num6;
            num3 = num1 / ((long) 0x3e8);
            if (num3 > 0)
            {
                text1 = text1 + ACMS.Convert.ToThousandEnglish((int) num3) + " THOUSAND ";
            }
            num1 = num1 % ((long) 0x3e8);
            if (num1 > 0)
            {
                text1 = text1 + ACMS.Convert.ToThousandEnglish((int) num1) + " ";
            }
            amount -= decimal.Truncate(amount);
            amount *= new decimal(100);
            num3 = (long) amount;
            if (num3 > 0)
            {
                if (text1.Length > 0)
                {
                    text1 = text1 + "AND CENTS " + ACMS.Convert.ToThousandEnglish((int) num3);
                }
                else
                {
                    text1 = text1 + ACMS.Convert.ToThousandEnglish((int) num3) + " CENTS";
                }
            }
            if (text1.Length == 0)
            {
                text1 = "ZERO";
            }
            return (text1.Trim() + " ONLY");
        }

        public static short ToInt16(object obj)
        {
            if ((obj == null) || (obj == DBNull.Value))
            {
                return 0;
            }
            return System.Convert.ToInt16(obj);
        }

        public static int ToInt32(object obj)
        {
			if (obj is System.Data.SqlTypes.SqlInt32)
			{
				System.Data.SqlTypes.SqlInt32 o = (System.Data.SqlTypes.SqlInt32) obj;
				if (o.IsNull)
					return 0;
				else
					return o.Value;
			}else if (obj == DBNull.Value)
            {
                return 0;
            }
            return System.Convert.ToInt32(obj);
        }

        public static long ToInt64(object obj)
        {
            if (obj == DBNull.Value)
            {
                return (long) 0;
            }
            return System.Convert.ToInt64(obj);
        }

        public static sbyte ToSByte(object obj)
        {
            if ((obj == null) || (obj == DBNull.Value))
            {
                return 0;
            }
            return System.Convert.ToSByte(obj);
        }

        private static string ToThousandBahasa(int amount)
        {
            string[] textArray3 = new string[0x13] { 
                "SATU", "DUA", "TIGA", "EMPAT", "LIMA", "ENAM", "TUJUH", "LAPAN", "SEMBILAN", "SEPULUH", "SEBELAS", "DUA BELAS", "TIGA BELAS", "EMPAT BELAS", "LIMA BELAS", "ENAM BELAS", 
                "TUJUH BELAS", "LAPAN BELAS", "SEMBILAN BELAS"
             } ;
            string[] textArray1 = textArray3;
            string[] textArray4 = new string[8] { "DUA PULUH", "TIGA PULUH", "EMPAT PULUH", "LIMA PULUH", "ENAM PULUH", "TUJUH PULUH", "LAPAN PULUH", "SEMBILAN PULUH" } ;
            string[] textArray2 = textArray4;
            string text1 = "";
            amount = amount % 0x3e8;
            int num1 = amount / 100;
            if (num1 > 0)
            {
                text1 = text1 + textArray1[num1 - 1] + " RATUS";
            }
            amount = amount % 100;
            int num2 = amount / 10;
            if (num2 >= 2)
            {
                text1 = text1 + " " + textArray2[num2 - 2];
                int num3 = amount % 10;
                if (num3 > 0)
                {
                    text1 = text1 + " " + textArray1[num3 - 1];
                }
                return text1;
            }
            int num4 = amount % 20;
            if (num4 > 0)
            {
                text1 = text1 + " " + textArray1[num4 - 1];
            }
            return text1;
        }

        private static string ToThousandEnglish(int amount)
        {
            string[] textArray3 = new string[0x13] { 
                "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", 
                "SEVENTEEN", "EIGHTEEN", "NINETEEN"
             } ;
            string[] textArray1 = textArray3;
            string[] textArray4 = new string[8] { "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" } ;
            string[] textArray2 = textArray4;
            string text1 = "";
            amount = amount % 0x3e8;
            int num1 = amount / 100;
            if (num1 > 0)
            {
                text1 = text1 + textArray1[num1 - 1] + " HUNDRED";
            }
            amount = amount % 100;
            int num2 = amount / 10;
            if (num2 >= 2)
            {
                text1 = text1 + " " + textArray2[num2 - 2];
                int num3 = amount % 10;
                if (num3 > 0)
                {
                    text1 = text1 + " " + textArray1[num3 - 1];
                }
                return text1;
            }
            int num4 = amount % 20;
            if (num4 > 0)
            {
                text1 = text1 + " " + textArray1[num4 - 1];
            }
            return text1;
        }

    }
}

