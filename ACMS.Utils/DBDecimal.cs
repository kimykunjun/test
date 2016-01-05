namespace ACMS
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct DBDecimal
    {
        private object myValue;
        public DBDecimal(DBNull aDBNull)
        {
            this.myValue = aDBNull;
        }
        public DBDecimal(decimal newValue)
        {
            this.myValue = newValue;
        }
        public bool HasValue
        {
            get
            {
                return (this.myValue != DBNull.Value);
            }
        }
        public override string ToString()
        {
            return this.myValue.ToString();
        }
        public override bool Equals(object obj)
        {
            if (!this.HasValue)
            {
                return ((obj == null) || (obj == DBNull.Value));
            }
            return (this.myValue.ToString() == obj.ToString());
        }
        public override int GetHashCode()
        {
            return this.myValue.GetHashCode();
        }
        public static implicit operator DBDecimal(decimal newValue)
        {
            return new DBDecimal(newValue);
        }
        public static implicit operator DBDecimal(DBNull aDBNull)
        {
            return new DBDecimal(aDBNull);
        }
        public static implicit operator decimal(DBDecimal aDBDecimal)
        {
            return ACMS.Convert.ToDecimal(aDBDecimal.myValue);
        }
        public static bool operator ==(DBDecimal aDBType, DBNull aDBNull)
        {
            return (aDBType.myValue == aDBNull);
        }
        public static bool operator !=(DBDecimal aDBType, DBNull aDBNull)
        {
            return (aDBType.myValue != aDBNull);
        }
    }
}

