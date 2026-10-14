namespace SAMS.DatabaseLayer.Classes
{
    using SAMS.DataAccessLayer.Classes;
    using System;
    using System.Data;

    public class spInsertROLE_DETAIL
    {
        private IDbConnection m_connection;
        private int m_MODULE_ID;
        private int m_ROLE_DETAIL_ID;
        private int m_ROLE_ID;
        private IDbTransaction m_transaction;
        private int m_Unassign;
        private string sp_Name = " spInsertROLE_DETAIL";

        public bool ExecuteQuery()
        {
            bool flag;
            try
            {
                IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spInsertROLE_DETAIL";
                cmd.Connection = this.m_connection;
                if (this.m_transaction != null)
                {
                    cmd.Transaction = this.m_transaction;
                }
                this.GetParameterCollection(ref cmd);
                cmd.ExecuteNonQuery();
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
                cmd.CommandText = "spInsertROLE_DETAIL";
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
                cmd.CommandText = "spInsertROLE_DETAIL";
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
                cmd.CommandText = "spInsertROLE_DETAIL";
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
                this.m_ROLE_ID = Convert.ToInt32(dr["ROLE_ID"]);
                this.m_MODULE_ID = Convert.ToInt32(dr["MODULE_ID"]);
                this.m_ROLE_DETAIL_ID = Convert.ToInt32(dr["ROLE_DETAIL_ID"]);
            }
        }

        public void GetParameterCollection(ref IDbCommand cmd)
        {
            try
            {
                IDataParameterCollection parameters = cmd.Parameters;
                IDataParameter parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
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
                parameter.ParameterName = "@Unassign";
                parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
                if (this.m_Unassign == -2147483648)
                {
                    parameter.Value = DBNull.Value;
                }
                else
                {
                    parameter.Value = this.m_Unassign;
                }
                parameters.Add(parameter);
            }
            catch (Exception)
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

        public int Unassign
        {
            get
            {
                return this.m_Unassign;
            }
            set
            {
                this.m_Unassign = value;
            }
        }
    }
}

