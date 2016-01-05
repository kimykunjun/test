namespace ACMS
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct DBBoolean
    {
        private object myValue;
        public DBBoolean(DBNull aDBNull)
        {
            this.myValue = aDBNull;
        }
        public DBBoolean(bool newValue)
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
        public static implicit operator DBBoolean(bool newValue)
        {
            return new DBBoolean(newValue);
        }
        public static implicit operator DBBoolean(DBNull aDBNull)
        {
            return new DBBoolean(aDBNull);
        }
        public static implicit operator bool(DBBoolean aDBType)
        {
            return ACMS.Convert.ToBoolean(aDBType.myValue);
        }
        public static bool operator ==(DBBoolean aDBType, DBNull aDBNull)
        {
            return (aDBType.myValue == aDBNull);
        }
        public static bool operator !=(DBBoolean aDBType, DBNull aDBNull)
        {
            return (aDBType.myValue != aDBNull);
        }
    }
}

