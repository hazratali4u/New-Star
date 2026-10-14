namespace SAMS.DatabaseLayer.Classes
{
    using SAMS.DataAccessLayer.Classes;
    using System;
    using System.Data;

    public class spUpdateDTDISTRIBUTOR_SETTINGS
    {
        private bool m_CAN_ADD_NEW_TO;
        private bool m_CAN_DISABLE_SERVER_TO;
        private IDbConnection m_connection;
        private int m_DISTRIBUTOR_ID;
        private int m_DISTRIBUTOR_SETTINGS_ID;
        private bool m_ISGST_PAID_BY_DIST;
        private bool m_ISRP_UPDATE;
        private bool m_ISTAXPRICE_UPDATE;
        private bool m_ISTP_UPDATE;
        private IDbTransaction m_transaction;
        private short m_TRANSFER_TIME;
        private string sp_Name = " spUpdateDTDISTRIBUTOR_SETTINGS";

        public bool ExecuteQuery()
        {
            try
            {
                IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spUpdateDTDISTRIBUTOR_SETTINGS";
                cmd.Connection = this.m_connection;
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
                cmd.CommandText = "spUpdateDTDISTRIBUTOR_SETTINGS";
                cmd.Connection = this.m_connection;
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
                cmd.CommandText = "spUpdateDTDISTRIBUTOR_SETTINGS";
                cmd.Connection = this.m_connection;
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
                cmd.CommandText = "spUpdateDTDISTRIBUTOR_SETTINGS";
                cmd.Connection = this.m_connection;
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
            parameter.ParameterName = "@ISTAXPRICE_UPDATE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
            parameter.Value = this.m_ISTAXPRICE_UPDATE;
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@CAN_ADD_NEW_TO";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
            parameter.Value = this.m_CAN_ADD_NEW_TO;
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@CAN_DISABLE_SERVER_TO";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
            parameter.Value = this.m_CAN_DISABLE_SERVER_TO;
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@ISGST_PAID_BY_DIST";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
            parameter.Value = this.m_ISGST_PAID_BY_DIST;
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@ISTP_UPDATE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
            parameter.Value = this.m_ISTP_UPDATE;
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@ISRP_UPDATE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
            parameter.Value = this.m_ISRP_UPDATE;
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@DISTRIBUTOR_SETTINGS_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_DISTRIBUTOR_SETTINGS_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_DISTRIBUTOR_SETTINGS_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@DISTRIBUTOR_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_DISTRIBUTOR_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_DISTRIBUTOR_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@TRANSFER_TIME";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.SmallInt);
            if (this.m_TRANSFER_TIME == -32768)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_TRANSFER_TIME;
            }
            parameters.Add(parameter);
        }

        public bool CAN_ADD_NEW_TO
        {
            get
            {
                return this.m_CAN_ADD_NEW_TO;
            }
            set
            {
                this.m_CAN_ADD_NEW_TO = value;
            }
        }

        public bool CAN_DISABLE_SERVER_TO
        {
            get
            {
                return this.m_CAN_DISABLE_SERVER_TO;
            }
            set
            {
                this.m_CAN_DISABLE_SERVER_TO = value;
            }
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

        public int DISTRIBUTOR_ID
        {
            get
            {
                return this.m_DISTRIBUTOR_ID;
            }
            set
            {
                this.m_DISTRIBUTOR_ID = value;
            }
        }

        public int DISTRIBUTOR_SETTINGS_ID
        {
            get
            {
                return this.m_DISTRIBUTOR_SETTINGS_ID;
            }
            set
            {
                this.m_DISTRIBUTOR_SETTINGS_ID = value;
            }
        }

        public bool ISGST_PAID_BY_DIST
        {
            get
            {
                return this.m_ISGST_PAID_BY_DIST;
            }
            set
            {
                this.m_ISGST_PAID_BY_DIST = value;
            }
        }

        public bool ISRP_UPDATE
        {
            get
            {
                return this.m_ISRP_UPDATE;
            }
            set
            {
                this.m_ISRP_UPDATE = value;
            }
        }

        public bool ISTAXPRICE_UPDATE
        {
            get
            {
                return this.m_ISTAXPRICE_UPDATE;
            }
            set
            {
                this.m_ISTAXPRICE_UPDATE = value;
            }
        }

        public bool ISTP_UPDATE
        {
            get
            {
                return this.m_ISTP_UPDATE;
            }
            set
            {
                this.m_ISTP_UPDATE = value;
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

        public short TRANSFER_TIME
        {
            get
            {
                return this.m_TRANSFER_TIME;
            }
            set
            {
                this.m_TRANSFER_TIME = value;
            }
        }
    }
}

