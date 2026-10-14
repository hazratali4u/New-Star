namespace SAMS.DatabaseLayer.Classes
{
    using SAMS.DataAccessLayer.Classes;
    using System;
    using System.Data;

    public class uspHHSelectAppUser
    {
        private IDbConnection m_connection;
        private int m_SALE_FORCE_ID;
        private int m_SALE_FORCE_TYPE_ID;
        private IDbTransaction m_transaction;
        private string sp_Name = " uspHHSelectAppUser";

        public bool ExecuteQuery()
        {
            bool flag;
            try
            {
                IDbCommand command = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "uspHHSelectAppUser";
                command.Connection = this.m_connection;
                if (this.m_transaction != null)
                {
                    command.Transaction = this.m_transaction;
                }
                command.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag;
        }

        public IDataReader ExecuteReader()
        {
            IDataReader reader2;
            try
            {
                IDbCommand command = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "uspHHSelectAppUser";
                command.Connection = this.m_connection;
                if (this.m_transaction != null)
                {
                    command.Transaction = this.m_transaction;
                }
                reader2 = command.ExecuteReader();
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
                IDbCommand command = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "uspHHSelectAppUser";
                command.Connection = this.m_connection;
                if (this.m_transaction != null)
                {
                    command.Transaction = this.m_transaction;
                }
                str = command.ExecuteScalar().ToString();
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
                cmd.CommandText = "uspHHSelectAppUser";
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
            }
        }

        public void GetParameterCollection(ref IDbCommand cmd)
        {
            IDataParameterCollection parameters = cmd.Parameters;
            IDataParameter parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@SALE_FORCE_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_SALE_FORCE_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_SALE_FORCE_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@SALE_FORCE_TYPE_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_SALE_FORCE_TYPE_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_SALE_FORCE_TYPE_ID;
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

        public int SALE_FORCE_ID
        {
            get
            {
                return this.m_SALE_FORCE_ID;
            }
            set
            {
                this.m_SALE_FORCE_ID = value;
            }
        }

        public int SALE_FORCE_TYPE_ID
        {
            get
            {
                return this.m_SALE_FORCE_TYPE_ID;
            }
            set
            {
                this.m_SALE_FORCE_TYPE_ID = value;
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

