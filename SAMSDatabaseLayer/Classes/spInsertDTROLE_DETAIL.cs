namespace SAMS.DatabaseLayer.Classes
{
    using SAMS.DataAccessLayer.Classes;
    using System;
    using System.Data;

    public class spInsertDTROLE_DETAIL
    {
        private bool m_CAN_ADD;
        private bool m_CAN_DELETE;
        private bool m_CAN_UPDATE;
        private bool m_CAN_VIEW;
        private IDbConnection m_connection;
        private int m_MODULE_ID;
        private int m_ROLE_DETAIL_ID;
        private int m_ROLE_ID;
        private IDbTransaction m_transaction;
        private string sp_Name = " spInsertDTROLE_DETAIL";

        public bool ExecuteQuery()
        {
            try
            {
                IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spInsertDTROLE_DETAIL";
                cmd.Connection = this.m_connection;
                if (this.m_transaction != null)
                {
                    cmd.Transaction = this.m_transaction;
                }
                this.GetParameterCollection(ref cmd);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception exception)
            {
                if (!exception.Message.StartsWith("Violation of PRIMARY KEY constraint"))
                {
                    throw exception;
                }
                return false;
            }
        }

        public IDataReader ExecuteReader()
        {
            IDataReader reader2;
            try
            {
                IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spInsertDTROLE_DETAIL";
                cmd.Connection = this.m_connection;
                if (this.m_transaction != null)
                {
                    cmd.Transaction = this.m_transaction;
                }
                this.GetParameterCollection(ref cmd);
                reader2 = cmd.ExecuteReader();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return reader2;
        }

        public string ExecuteScalar()
        {
            string str;
            try
            {
                IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spInsertDTROLE_DETAIL";
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
                cmd.CommandText = "spInsertDTROLE_DETAIL";
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

        public void FirstReader(IDataReader dr)
        {
            if (dr.Read())
            {
                this.m_CAN_DELETE = Convert.ToBoolean(dr["CAN_DELETE"]);
                this.m_CAN_VIEW = Convert.ToBoolean(dr["CAN_VIEW"]);
                this.m_CAN_ADD = Convert.ToBoolean(dr["CAN_ADD"]);
                this.m_CAN_UPDATE = Convert.ToBoolean(dr["CAN_UPDATE"]);
                this.m_ROLE_ID = Convert.ToInt32(dr["ROLE_ID"]);
                this.m_MODULE_ID = Convert.ToInt32(dr["MODULE_ID"]);
                this.m_ROLE_DETAIL_ID = Convert.ToInt32(dr["ROLE_DETAIL_ID"]);
            }
        }

        public void GetParameterCollection(ref IDbCommand cmd)
        {
            IDataParameterCollection parameters = cmd.Parameters;
            IDataParameter parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@CAN_DELETE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
            parameter.Value = this.m_CAN_DELETE;
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@CAN_VIEW";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
            parameter.Value = this.m_CAN_VIEW;
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@CAN_ADD";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
            parameter.Value = this.m_CAN_ADD;
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@CAN_UPDATE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
            parameter.Value = this.m_CAN_UPDATE;
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@ROLE_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_ROLE_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_ROLE_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@MODULE_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_MODULE_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_MODULE_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@ROLE_DETAIL_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_ROLE_DETAIL_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_ROLE_DETAIL_ID;
            }
            parameters.Add(parameter);
        }

        public bool CAN_ADD
        {
            get
            {
                return this.m_CAN_ADD;
            }
            set
            {
                this.m_CAN_ADD = value;
            }
        }

        public bool CAN_DELETE
        {
            get
            {
                return this.m_CAN_DELETE;
            }
            set
            {
                this.m_CAN_DELETE = value;
            }
        }

        public bool CAN_UPDATE
        {
            get
            {
                return this.m_CAN_UPDATE;
            }
            set
            {
                this.m_CAN_UPDATE = value;
            }
        }

        public bool CAN_VIEW
        {
            get
            {
                return this.m_CAN_VIEW;
            }
            set
            {
                this.m_CAN_VIEW = value;
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

        public int MODULE_ID
        {
            get
            {
                return this.m_MODULE_ID;
            }
            set
            {
                this.m_MODULE_ID = value;
            }
        }

        public int ROLE_DETAIL_ID
        {
            get
            {
                return this.m_ROLE_DETAIL_ID;
            }
            set
            {
                this.m_ROLE_DETAIL_ID = value;
            }
        }

        public int ROLE_ID
        {
            get
            {
                return this.m_ROLE_ID;
            }
            set
            {
                this.m_ROLE_ID = value;
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
    }
}

