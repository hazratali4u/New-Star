namespace SAMS.DatabaseLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using System;
    using System.Data;

    public class sp_SelectROLE_DETAIL
    {
        private IDbConnection m_connection;
        private IDbTransaction m_transaction;
        private string sp_Name = " sp_SelectROLE_DETAIL";

        public bool ExecuteQuery()
        {
            try
            {
                IDbCommand command = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_SelectROLE_DETAIL";
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
                command.CommandText = "sp_SelectROLE_DETAIL";
                command.Connection = this.m_connection;
                if (this.m_transaction != null)
                {
                    command.Transaction = this.m_transaction;
                }
                return command.ExecuteReader();
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
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
                command.CommandText = "sp_SelectROLE_DETAIL";
                command.Connection = this.m_connection;
                if (this.m_transaction != null)
                {
                    command.Transaction = this.m_transaction;
                }
                str = command.ExecuteScalar().ToString();
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
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
                command.CommandText = "sp_SelectROLE_DETAIL";
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
                ExceptionPublisher.PublishException(exception);
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

