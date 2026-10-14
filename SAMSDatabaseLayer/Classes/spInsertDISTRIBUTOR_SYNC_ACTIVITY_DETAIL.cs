namespace SAMS.DatabaseLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using System;
    using System.Data;

    public class spInsertDISTRIBUTOR_SYNC_ACTIVITY_DETAIL
    {
        private int m_ACTIVITY_ID;
        private IDbConnection m_connection;
        private int m_DISTRIBUTOR_SYNC_ACTIVITY_DETAIL_ID;
        private int m_DISTRIBUTOR_SYNC_ACTIVITY_ID;
        private DateTime m_TIME_STAMP;
        private IDbTransaction m_transaction;
        private string sp_Name = " spInsertDISTRIBUTOR_SYNC_ACTIVITY_DETAIL";

        public bool ExecuteQuery()
        {
            bool flag;
            try
            {
                IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spInsertDISTRIBUTOR_SYNC_ACTIVITY_DETAIL";
                cmd.Connection = this.m_connection;
                if (this.m_transaction != null)
                {
                    cmd.Transaction = this.m_transaction;
                }
                this.GetParameterCollection(ref cmd);
                cmd.ExecuteNonQuery();
                this.m_DISTRIBUTOR_SYNC_ACTIVITY_DETAIL_ID = (int) ((IDataParameter) cmd.Parameters["@DISTRIBUTOR_SYNC_ACTIVITY_DETAIL_ID"]).Value;
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
                IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spInsertDISTRIBUTOR_SYNC_ACTIVITY_DETAIL";
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
                cmd.CommandText = "spInsertDISTRIBUTOR_SYNC_ACTIVITY_DETAIL";
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
                cmd.CommandText = "spInsertDISTRIBUTOR_SYNC_ACTIVITY_DETAIL";
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
                this.m_TIME_STAMP = Convert.ToDateTime(dr["TIME_STAMP"]);
                this.m_DISTRIBUTOR_SYNC_ACTIVITY_ID = Convert.ToInt32(dr["DISTRIBUTOR_SYNC_ACTIVITY_ID"]);
                this.m_ACTIVITY_ID = Convert.ToInt32(dr["ACTIVITY_ID"]);
                this.m_DISTRIBUTOR_SYNC_ACTIVITY_DETAIL_ID = Convert.ToInt32(dr["DISTRIBUTOR_SYNC_ACTIVITY_DETAIL_ID"]);
            }
        }

        public void GetParameterCollection(ref IDbCommand cmd)
        {
            IDataParameterCollection parameters = cmd.Parameters;
            IDataParameter parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
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
            parameter.ParameterName = "@DISTRIBUTOR_SYNC_ACTIVITY_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_DISTRIBUTOR_SYNC_ACTIVITY_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_DISTRIBUTOR_SYNC_ACTIVITY_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@ACTIVITY_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_ACTIVITY_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_ACTIVITY_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@DISTRIBUTOR_SYNC_ACTIVITY_DETAIL_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            parameter.Direction = ParameterDirection.Output;
            parameters.Add(parameter);
        }

        public int ACTIVITY_ID
        {
            get
            {
                return this.m_ACTIVITY_ID;
            }
            set
            {
                this.m_ACTIVITY_ID = value;
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

        public int DISTRIBUTOR_SYNC_ACTIVITY_DETAIL_ID
        {
            get
            {
                return this.m_DISTRIBUTOR_SYNC_ACTIVITY_DETAIL_ID;
            }
        }

        public int DISTRIBUTOR_SYNC_ACTIVITY_ID
        {
            get
            {
                return this.m_DISTRIBUTOR_SYNC_ACTIVITY_ID;
            }
            set
            {
                this.m_DISTRIBUTOR_SYNC_ACTIVITY_ID = value;
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
    }
}

