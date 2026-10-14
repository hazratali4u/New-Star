namespace SAMS.DatabaseLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using System;
    using System.Data;

    public class spUpdateSKU_TAX
    {
        private IDbConnection m_connection;
        private string m_IP_ADDRESS;
        private DateTime m_LASTUPDATE_DATE;
        private int m_SKU_ID;
        private int m_SKU_TAX_ID;
        private int m_TAX_ID;
        private char m_TAX_ON;
        private float m_TAX_RATE;
        private DateTime m_TIME_STAMP;
        private IDbTransaction m_transaction;
        private int m_USER_ID;
        private string sp_Name = " spUpdateSKU_TAX";

        public bool ExecuteQuery()
        {
            try
            {
                IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spUpdateSKU_TAX";
                cmd.Connection = this.m_connection;
                if (this.m_transaction != null)
                {
                    cmd.Transaction = this.m_transaction;
                }
                this.GetParameterCollection(ref cmd);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IDataReader ExecuteReader()
        {
            try
            {
                IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spUpdateSKU_TAX";
                cmd.Connection = this.m_connection;
                if (this.m_transaction != null)
                {
                    cmd.Transaction = this.m_transaction;
                }
                this.GetParameterCollection(ref cmd);
                return cmd.ExecuteReader();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string ExecuteScalar()
        {
            string str;
            try
            {
                IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spUpdateSKU_TAX";
                cmd.Connection = this.m_connection;
                if (this.m_transaction != null)
                {
                    cmd.Transaction = this.m_transaction;
                }
                this.GetParameterCollection(ref cmd);
                str = cmd.ExecuteScalar().ToString();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return str;
        }

        public DataTable ExecuteTable()
        {
            DataTable table;
            try
            {
                IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spUpdateSKU_TAX";
                cmd.Connection = this.m_connection;
                if (this.m_transaction != null)
                {
                    cmd.Transaction = this.m_transaction;
                }
                this.GetParameterCollection(ref cmd);
                IDbDataAdapter adapter = ProviderFactory.GetAdapter(EnumProviders.SQLClient);
                adapter.SelectCommand = cmd;
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                table = dataSet.Tables[0];
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return table;
        }

        public void GetParameterCollection(ref IDbCommand cmd)
        {
            IDataParameterCollection parameters = cmd.Parameters;
            IDataParameter parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@TAX_ON";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Char);
            if (this.m_TAX_ON == '\0')
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_TAX_ON;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@TIME_STAMP";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
            if (this.m_TIME_STAMP == Constants.DateNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_TIME_STAMP;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@LASTUPDATE_DATE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
            if (this.m_LASTUPDATE_DATE == Constants.DateNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_LASTUPDATE_DATE;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@TAX_RATE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Float);
            if (this.m_TAX_RATE == -2.147484E+09f)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_TAX_RATE;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@USER_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_USER_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_USER_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@SKU_TAX_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_SKU_TAX_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_SKU_TAX_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@SKU_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_SKU_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_SKU_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@TAX_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_TAX_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_TAX_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@IP_ADDRESS";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_IP_ADDRESS == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_IP_ADDRESS;
            }
            parameters.Add(parameter);
        }

        public IDbConnection Connection
        {
            get
            {
                return this.m_connection;
            }
            set
            {
                this.m_connection = value;
            }
        }

        public string IP_ADDRESS
        {
            get
            {
                return this.m_IP_ADDRESS;
            }
            set
            {
                this.m_IP_ADDRESS = value;
            }
        }

        public DateTime LASTUPDATE_DATE
        {
            get
            {
                return this.m_LASTUPDATE_DATE;
            }
            set
            {
                this.m_LASTUPDATE_DATE = value;
            }
        }

        public int SKU_ID
        {
            get
            {
                return this.m_SKU_ID;
            }
            set
            {
                this.m_SKU_ID = value;
            }
        }

        public int SKU_TAX_ID
        {
            get
            {
                return this.m_SKU_TAX_ID;
            }
            set
            {
                this.m_SKU_TAX_ID = value;
            }
        }

        public int TAX_ID
        {
            get
            {
                return this.m_TAX_ID;
            }
            set
            {
                this.m_TAX_ID = value;
            }
        }

        public char TAX_ON
        {
            get
            {
                return this.m_TAX_ON;
            }
            set
            {
                this.m_TAX_ON = value;
            }
        }

        public float TAX_RATE
        {
            get
            {
                return this.m_TAX_RATE;
            }
            set
            {
                this.m_TAX_RATE = value;
            }
        }

        public DateTime TIME_STAMP
        {
            get
            {
                return this.m_TIME_STAMP;
            }
            set
            {
                this.m_TIME_STAMP = value;
            }
        }

        public IDbTransaction Transaction
        {
            get
            {
                return this.m_transaction;
            }
            set
            {
                this.m_transaction = value;
            }
        }

        public int USER_ID
        {
            get
            {
                return this.m_USER_ID;
            }
            set
            {
                this.m_USER_ID = value;
            }
        }
    }
}

