namespace SAMS.DatabaseLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using System;
    using System.Data;

    public class spSelectASSIGNMENTS
    {
        private DateTime m_ASSIGN_DATE;
        private string m_ASSIGN_LOCATION_CODE;
        private int m_ASSIGN_LOCATION_ID;
        private string m_ASSIGN_LOCATION_NAME;
        private int m_ASSIGN_TO_ID;
        private string m_ASSIGN_TYPE;
        private int m_ASSIGNMENTS_ID;
        private IDbConnection m_connection;
        private string m_IP_ADDRESS;
        private int m_IS_ACCTIVE;
        private IDbTransaction m_transaction;
        private int m_USER_ID;
        private string sp_Name = " spSelectASSIGNMENTS";

        public bool ExecuteQuery()
        {
            bool flag;
            try
            {
                IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spSelectASSIGNMENTS";
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
                cmd.CommandText = "spSelectASSIGNMENTS";
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
                cmd.CommandText = "spSelectASSIGNMENTS";
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
                cmd.CommandText = "spSelectASSIGNMENTS";
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
                this.m_ASSIGN_DATE = Convert.ToDateTime(dr["ASSIGN_DATE"]);
                this.m_USER_ID = Convert.ToInt32(dr["USER_ID"]);
                this.m_IS_ACCTIVE = Convert.ToInt32(dr["IS_ACCTIVE"]);
                this.m_ASSIGNMENTS_ID = Convert.ToInt32(dr["ASSIGNMENTS_ID"]);
                this.m_ASSIGN_TO_ID = Convert.ToInt32(dr["ASSIGN_TO_ID"]);
                this.m_ASSIGN_LOCATION_ID = Convert.ToInt32(dr["ASSIGN_LOCATION_ID"]);
                this.m_IP_ADDRESS = Convert.ToString(dr["IP_ADDRESS"]);
                this.m_ASSIGN_LOCATION_CODE = Convert.ToString(dr["ASSIGN_LOCATION_CODE"]);
                this.m_ASSIGN_LOCATION_NAME = Convert.ToString(dr["ASSIGN_LOCATION_NAME"]);
                this.m_ASSIGN_TYPE = Convert.ToString(dr["ASSIGN_TYPE"]);
            }
        }

        public void GetParameterCollection(ref IDbCommand cmd)
        {
            IDataParameterCollection parameters = cmd.Parameters;
            IDataParameter parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@ASSIGN_DATE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
            if (this.m_ASSIGN_DATE == Constants.DateNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_ASSIGN_DATE;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@USER_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_USER_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_USER_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@IS_ACCTIVE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_IS_ACCTIVE == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_IS_ACCTIVE;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@ASSIGNMENTS_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_ASSIGNMENTS_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_ASSIGNMENTS_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@ASSIGN_TO_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_ASSIGN_TO_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_ASSIGN_TO_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@ASSIGN_LOCATION_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_ASSIGN_LOCATION_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_ASSIGN_LOCATION_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@IP_ADDRESS";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_IP_ADDRESS == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_IP_ADDRESS;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@ASSIGN_LOCATION_CODE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_ASSIGN_LOCATION_CODE == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_ASSIGN_LOCATION_CODE;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@ASSIGN_LOCATION_NAME";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_ASSIGN_LOCATION_NAME == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_ASSIGN_LOCATION_NAME;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@ASSIGN_TYPE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_ASSIGN_TYPE == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_ASSIGN_TYPE;
            }
            parameters.Add(parameter);
        }

        public DateTime ASSIGN_DATE
        {
            get
            {
                return this.m_ASSIGN_DATE;
            }
            set
            {
                this.m_ASSIGN_DATE = value;
            }
        }

        public string ASSIGN_LOCATION_CODE
        {
            get
            {
                return this.m_ASSIGN_LOCATION_CODE;
            }
            set
            {
                this.m_ASSIGN_LOCATION_CODE = value;
            }
        }

        public int ASSIGN_LOCATION_ID
        {
            get
            {
                return this.m_ASSIGN_LOCATION_ID;
            }
            set
            {
                this.m_ASSIGN_LOCATION_ID = value;
            }
        }

        public string ASSIGN_LOCATION_NAME
        {
            get
            {
                return this.m_ASSIGN_LOCATION_NAME;
            }
            set
            {
                this.m_ASSIGN_LOCATION_NAME = value;
            }
        }

        public int ASSIGN_TO_ID
        {
            get
            {
                return this.m_ASSIGN_TO_ID;
            }
            set
            {
                this.m_ASSIGN_TO_ID = value;
            }
        }

        public string ASSIGN_TYPE
        {
            get
            {
                return this.m_ASSIGN_TYPE;
            }
            set
            {
                this.m_ASSIGN_TYPE = value;
            }
        }

        public int ASSIGNMENTS_ID
        {
            get
            {
                return this.m_ASSIGNMENTS_ID;
            }
            set
            {
                this.m_ASSIGNMENTS_ID = value;
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

        public string IP_ADDRESS
        {
            get
            {
                return this.m_IP_ADDRESS;
            }
            set
            {
                this.m_IP_ADDRESS = value;
            }
        }

        public int IS_ACCTIVE
        {
            get
            {
                return this.m_IS_ACCTIVE;
            }
            set
            {
                this.m_IS_ACCTIVE = value;
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

        public int USER_ID
        {
            get
            {
                return this.m_USER_ID;
            }
            set
            {
                this.m_USER_ID = value;
            }
        }
    }
}

