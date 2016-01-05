namespace ACMS
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct DBDateTime
    {
        private object myValue;
        public DBDateTime(DBNull aDBNull)
        {
            this.myValue = aDBNull;
        }
        public DBDateTime(DateTime newValue)
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
        public static implicit operator DBDateTime(DateTime newValue)
        {
            return new DBDateTime(newValue);
        }
        public static implicit operator DBDateTime(DBNull aDBNull)
        {
            return new DBDateTime(aDBNull);
        }
        public static implicit operator DateTime(DBDateTime aDBType)
        {
            return ACMS.Convert.ToDateTime(aDBType.myValue);
        }
        public static bool operator ==(DBDateTime aDBType, DBNull aDBNull)
        {
            return (aDBType.myValue == aDBNull);
        }
        public static bool operator !=(DBDateTime aDBType, DBNull aDBNull)
        {
            return (aDBType.myValue != aDBNull);
        }
    }
}

