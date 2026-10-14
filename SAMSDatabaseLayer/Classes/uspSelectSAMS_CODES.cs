namespace SAMS.DatabaseLayer.Classes
{
    using SAMS.DataAccessLayer.Classes;
    using System;
    using System.Data;

    public class uspSelectSAMS_CODES
    {
        private IDbConnection m_connection;
        private IDbTransaction m_transaction;
        private string sp_Name = " uspSelectSAMS_CODES";

        public bool ExecuteQuery()
        {
            try
            {
                IDbCommand command = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "uspSelectSAMS_CODES";
                command.Connection = this.m_connection;
                if (this.m_transaction != null)
                {
                    command.Transaction = this.m_transaction;
                }
                command.ExecuteNonQuery();
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
                IDbCommand command = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "uspSelectSAMS_CODES";
                command.Connection = this.m_connection;
                if (this.m_transaction != null)
                {
                    command.Transaction = this.m_transaction;
                }
                return command.ExecuteReader();
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
                IDbCommand command = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "uspSelectSAMS_CODES";
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
                IDbCommand command = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "uspSelectSAMS_CODES";
                command.Connection = this.m_connection;
                if (this.m_transaction != null)
                {
                    command.Transaction = this.m_transaction;
                }
                IDbDataAdapter adapter = ProviderFactory.GetAdapter(EnumProviders.SQLClient);
                adapter.SelectCommand = command;
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

