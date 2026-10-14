namespace SAMS.DatabaseLayer.Classes
{
    using SAMS.DataAccessLayer.Classes;
    using System;
    using System.Data;

    public class uspInsertSKU_PRICE_PS_ForAllDistributorTypes
    {
        private IDbConnection m_connection;
        private IDbTransaction m_transaction;
        private string sp_Name = " uspInsertSKU_PRICE_PS_ForAllDistributorTypes";

        public bool ExecuteQuery()
        {
            bool flag;
            try
            {
                IDbCommand command = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "uspInsertSKU_PRICE_PS_ForAllDistributorTypes";
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
                command.CommandText = "uspInsertSKU_PRICE_PS_ForAllDistributorTypes";
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
                command.CommandText = "uspInsertSKU_PRICE_PS_ForAllDistributorTypes";
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
                command.CommandText = "uspInsertSKU_PRICE_PS_ForAllDistributorTypes";
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

