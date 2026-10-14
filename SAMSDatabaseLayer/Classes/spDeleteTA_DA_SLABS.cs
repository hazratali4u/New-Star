namespace SAMS.DatabaseLayer.Classes
{
    using SAMS.DataAccessLayer.Classes;
    using System;
    using System.Data;

    public class spDeleteTA_DA_SLABS
    {
        private IDbConnection m_connection;
        private int m_TA_DA_SLAB_ID;
        private IDbTransaction m_transaction;
        private string sp_Name = " spDeleteTA_DA_SLABS";

        public bool ExecuteQuery()
        {
            try
            {
                IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spDeleteTA_DA_SLABS";
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
                cmd.CommandText = "spDeleteTA_DA_SLABS";
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
                cmd.CommandText = "spDeleteTA_DA_SLABS";
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
                cmd.CommandText = "spDeleteTA_DA_SLABS";
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
            parameter.ParameterName = "@TA_DA_SLAB_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_TA_DA_SLAB_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_TA_DA_SLAB_ID;
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

        public int TA_DA_SLAB_ID
        {
            get
            {
                return this.m_TA_DA_SLAB_ID;
            }
            set
            {
                this.m_TA_DA_SLAB_ID = value;
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

