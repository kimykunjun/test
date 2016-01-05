namespace ACMS
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct DBInt64
    {
        private object myValue;
        public DBInt64(DBNull aDBNull)
        {
            this.myValue = aDBNull;
        }
        public DBInt64(long newValue)
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
        public static implicit operator DBInt64(long newValue)
        {
            return new DBInt64(newValue);
        }
        public static implicit operator DBInt64(DBNull aDBNull)
        {
            return new DBInt64(aDBNull);
        }
        public static implicit operator long(DBInt64 aDBType)
        {
            return ACMS.Convert.ToInt64(aDBType.myValue);
        }
        public static bool operator ==(DBInt64 aDBType, DBNull aDBNull)
        {
            return (aDBType.myValue == aDBNull);
        }
        public static bool operator !=(DBInt64 aDBType, DBNull aDBNull)
        {
            return (aDBType.myValue != aDBNull);
        }
    }
}

