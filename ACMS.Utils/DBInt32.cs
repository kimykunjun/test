namespace ACMS
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct DBInt32
    {
        private object myValue;
        public DBInt32(DBNull aDBNull)
        {
            this.myValue = aDBNull;
        }
        public DBInt32(int newValue)
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
        public static implicit operator DBInt32(int newValue)
        {
            return new DBInt32(newValue);
        }
        public static implicit operator DBInt32(DBNull aDBNull)
        {
            return new DBInt32(aDBNull);
        }
        public static implicit operator int(DBInt32 aDBType)
        {
            return ACMS.Convert.ToInt32(aDBType.myValue);
        }
        public static bool operator ==(DBInt32 aDBType, DBNull aDBNull)
        {
            return (aDBType.myValue == aDBNull);
        }
        public static bool operator !=(DBInt32 aDBType, DBNull aDBNull)
        {
            return (aDBType.myValue != aDBNull);
        }
    }
}

