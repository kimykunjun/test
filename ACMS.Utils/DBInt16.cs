namespace ACMS
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct DBInt16
    {
        private object myValue;
        public DBInt16(DBNull aDBNull)
        {
            this.myValue = aDBNull;
        }
        public DBInt16(short newValue)
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
        public static implicit operator DBInt16(short newValue)
        {
            return new DBInt16(newValue);
        }
        public static implicit operator DBInt16(DBNull aDBNull)
        {
            return new DBInt16(aDBNull);
        }
        public static implicit operator short(DBInt16 aDBType)
        {
            return ACMS.Convert.ToInt16(aDBType.myValue);
        }
        public static bool operator ==(DBInt16 aDBType, DBNull aDBNull)
        {
            return (aDBType.myValue == aDBNull);
        }
        public static bool operator !=(DBInt16 aDBType, DBNull aDBNull)
        {
            return (aDBType.myValue != aDBNull);
        }
    }
}

