namespace SAMS.DataAccessLayer.Classes
{
    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.Odbc;
    using System.Data.OleDb;
    using System.Data.SqlClient;

    public class ProviderFactory
    {
        private ProviderFactory()
        {
        }

        public static IDbDataAdapter GetAdapter(EnumProviders provider)
        {
            switch (provider)
            {
                case EnumProviders.ODBC:
                    return new OdbcDataAdapter();

                case EnumProviders.SQLClient:
                    return new SqlDataAdapter();

                case EnumProviders.OLEDB:
                    return new OleDbDataAdapter();
            }
            return null;
        }

        public static IDbCommand GetCommand(EnumProviders provider)
        {
            switch (provider)
            {
                case EnumProviders.ODBC:
                    return new OdbcCommand();

                case EnumProviders.SQLClient:
                    return new SqlCommand();

                case EnumProviders.OLEDB:
                    return new OleDbCommand();
            }
            return null;
        }

        public static IDbCommand GetCommand(string strCmdText, CommandType cmdType, int cmdTimeout, ParamStruct[] ParameterArray, EnumProviders provider)
        {
            IDbCommand command = GetCommand(provider);
            if (ParameterArray != null)
            {
                for (short i = 0; i <= (ParameterArray.Length - 1); i = (short) (i + 1))
                {
                    ParamStruct struct2 = ParameterArray[i];
                    IDbDataParameter parameter = GetParameter(struct2.ParamName, struct2.direction, struct2.value, struct2.DataType, struct2.sourceColumn, struct2.size, provider);
                    command.Parameters.Add(parameter);
                }
            }
            command.CommandType = cmdType;
            command.CommandText = strCmdText;
            return command;
        }

        public static object GetCommandBuilder(EnumProviders provider)
        {
            switch (provider)
            {
                case EnumProviders.ODBC:
                    return new OdbcCommandBuilder();

                case EnumProviders.SQLClient:
                    return new SqlCommandBuilder();

                case EnumProviders.OLEDB:
                    return new OleDbCommandBuilder();
            }
            return null;
        }

        public static IDbConnection GetConnection(EnumProviders provider)
        {
            switch (provider)
            {
                case EnumProviders.ODBC:
                    return new OdbcConnection();

                case EnumProviders.SQLClient:
                    return new SqlConnection();

                case EnumProviders.OLEDB:
                    return new OleDbConnection();
            }
            return null;
        }

        public static IDbConnection GetConnection(string strConnString, EnumProviders provider)
        {
            IDbConnection connection = GetConnection(provider);
            if (strConnString == "")
            {
                strConnString = GetConnectionString;
            }
            strConnString = strConnString + ";App=" + provider.ToString() + " Provider";
            connection.ConnectionString = strConnString;
            return connection;
        }

        public static DbType GetDBType(EnumProviders provider, EnumDBTypes type)
        {
            switch (provider)
            {
                case EnumProviders.ODBC:
                    return DbType.Binary;

                case EnumProviders.SQLClient:
                    if (type != EnumDBTypes.BigInt)
                    {
                        if (type == EnumDBTypes.Bit)
                        {
                            return DbType.Boolean;
                        }
                        if (type != EnumDBTypes.Char)
                        {
                            if (type == EnumDBTypes.DateTime)
                            {
                                return DbType.DateTime;
                            }
                            if (type == EnumDBTypes.Decimal)
                            {
                                return DbType.Decimal;
                            }
                            if (type == EnumDBTypes.Float)
                            {
                                return DbType.Single;
                            }
                            if (type == EnumDBTypes.Int)
                            {
                                return DbType.Int32;
                            }
                            if (type == EnumDBTypes.Money)
                            {
                                return DbType.Decimal;
                            }
                            if (type == EnumDBTypes.NChar)
                            {
                                return DbType.String;
                            }
                            if (type == EnumDBTypes.NVarChar)
                            {
                                return DbType.String;
                            }
                            if (type == EnumDBTypes.SmallInt)
                            {
                                return DbType.Int16;
                            }
                            if (type == EnumDBTypes.TinyInt)
                            {
                                return DbType.Byte;
                            }
                            if (type == EnumDBTypes.UniqueIdentifier)
                            {
                                return DbType.String;
                            }
                            if (type == EnumDBTypes.VarChar)
                            {
                                return DbType.String;
                            }
                        }
                        return DbType.String;
                    }
                    return DbType.Int64;

                case EnumProviders.OLEDB:
                    return DbType.UInt64;
            }
            return DbType.UInt64;
        }

        public static IDbDataParameter GetParameter(EnumProviders provider)
        {
            switch (provider)
            {
                case EnumProviders.ODBC:
                    return new OdbcParameter();

                case EnumProviders.SQLClient:
                    return new SqlParameter();

                case EnumProviders.OLEDB:
                    return new OleDbParameter();
            }
            return null;
        }

        public static IDbDataParameter GetParameter(string paramName, ParameterDirection paramDirection, object paramValue, DbType paramtype, string sourceColumn, short size, EnumProviders provider)
        {
            IDbDataParameter parameter = GetParameter(provider);
            parameter.ParameterName = paramName;
            parameter.DbType = paramtype;
            if (size > 0)
            {
                parameter.Size = size;
            }
            if (paramValue != null)
            {
                parameter.Value = paramValue;
            }
            parameter.Direction = paramDirection;
            if (!(sourceColumn == ""))
            {
                parameter.SourceColumn = sourceColumn;
            }
            return parameter;
        }

        public static IDbTransaction GetTransaction(IDbConnection conn)
        {
            return conn.BeginTransaction();
        }

        public static IDbTransaction GetTransaction(IDbConnection conn, IsolationLevel transisolationLevel)
        {
            return conn.BeginTransaction(transisolationLevel);
        }

        public static string GetConnectionString
        {
            get
            {
                return ConfigurationSettings.AppSettings.Get("ConnectionString");
            }
        }

        public static EnumProviders GetProvider
        {
            get
            {
                return EnumProviders.SQLClient;
            }
        }
    }
}

