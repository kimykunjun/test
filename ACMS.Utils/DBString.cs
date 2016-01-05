namespace ACMS
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct DBString
    {
        private object myValue;
        public DBString(DBNull aDBNull)
        {
            this.myValue = aDBNull;
        }
        public DBString(string newValue)
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
        public static implicit operator DBString(string newValue)
        {
            return new DBString(newValue);
        }
        public static implicit operator DBString(DBNull aDBNull)
        {
            return new DBString(aDBNull);
        }
        public static implicit operator string(DBString aDBType)
        {
            return aDBType.myValue.ToString();
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
        public static bool operator ==(DBString aDBType, DBNull aDBNull)
        {
            return (aDBType.myValue == aDBNull);
        }
        public static bool operator !=(DBString aDBType, DBNull aDBNull)
        {
            return (aDBType.myValue != aDBNull);
        }
    }
}

