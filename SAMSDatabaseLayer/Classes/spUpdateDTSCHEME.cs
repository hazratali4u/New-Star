namespace SAMS.DatabaseLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using System;
    using System.Data;

    public class spUpdateDTSCHEME
    {
        private IDbConnection m_connection;
        private int m_DISTRIBUTOR_ID;
        private string m_SCHEME_CODE;
        private DateTime m_SCHEME_DATE;
        private string m_SCHEME_DESC;
        private int m_SCHEME_ID;
        private IDbTransaction m_transaction;
        private string sp_Name = " spUpdateDTSCHEME";

        public bool ExecuteQuery()
        {
            bool flag;
            try
            {
                IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spUpdateDTSCHEME";
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
                cmd.CommandText = "spUpdateDTSCHEME";
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
                cmd.CommandText = "spUpdateDTSCHEME";
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
                cmd.CommandText = "spUpdateDTSCHEME";
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
                this.m_SCHEME_DATE = Convert.ToDateTime(dr["SCHEME_DATE"]);
                this.m_SCHEME_ID = Convert.ToInt32(dr["SCHEME_ID"]);
                this.m_DISTRIBUTOR_ID = Convert.ToInt32(dr["DISTRIBUTOR_ID"]);
                this.m_SCHEME_CODE = Convert.ToString(dr["SCHEME_CODE"]);
                this.m_SCHEME_DESC = Convert.ToString(dr["SCHEME_DESC"]);
            }
        }

        public void GetParameterCollection(ref IDbCommand cmd)
        {
            IDataParameterCollection parameters = cmd.Parameters;
            IDataParameter parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@SCHEME_DATE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
            if (this.m_SCHEME_DATE == Constants.DateNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_SCHEME_DATE;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@SCHEME_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_SCHEME_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_SCHEME_ID;
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
            parameter.ParameterName = "@SCHEME_CODE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_SCHEME_CODE == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_SCHEME_CODE;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@SCHEME_DESC";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_SCHEME_DESC == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_SCHEME_DESC;
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

        public string SCHEME_CODE
        {
            get
            {
                return this.m_SCHEME_CODE;
            }
            set
            {
                this.m_SCHEME_CODE = value;
            }
        }

        public DateTime SCHEME_DATE
        {
            get
            {
                return this.m_SCHEME_DATE;
            }
            set
            {
                this.m_SCHEME_DATE = value;
            }
        }

        public string SCHEME_DESC
        {
            get
            {
                return this.m_SCHEME_DESC;
            }
            set
            {
                this.m_SCHEME_DESC = value;
            }
        }

        public int SCHEME_ID
        {
            get
            {
                return this.m_SCHEME_ID;
            }
            set
            {
                this.m_SCHEME_ID = value;
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

