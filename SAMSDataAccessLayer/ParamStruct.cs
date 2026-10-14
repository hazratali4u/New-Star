namespace SAMS.DataAccessLayer.Classes
{
    using System;
    using System.Data;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct ParamStruct
    {
        public string ParamName;
        public DbType DataType;
        public object value;
        public ParameterDirection direction;
        public string sourceColumn;
        public short size;
    }
}

