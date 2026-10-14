namespace SAMS.DatabaseLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using System;
    using System.Data;

    public class UspInsertSKU_HIERARCHY
    {
        private string m_Brand_Check;
        private IDbConnection m_connection;
        private bool m_IS_ACTIVE;
        private DateTime m_LASTUPDATE_DATE;
        private int m_PARENT_SKU_HIE_ID;
        private int m_PRINCIPAL_ID;
        private string m_SKU_HIE_CODE;
        private int m_SKU_HIE_ID;
        private string m_SKU_HIE_NAME;
        private int m_SKU_HIE_TYPE_ID;
        private DateTime m_TIME_STAMP;
        private IDbTransaction m_transaction;
        private int m_USER_ID;
        private string sp_Name = " UspInsertSKU_HIERARCHY";

        public bool ExecuteQuery()
        {
            bool flag;
            try
            {
                IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UspInsertSKU_HIERARCHY";
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
                cmd.CommandText = "UspInsertSKU_HIERARCHY";
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
                cmd.CommandText = "UspInsertSKU_HIERARCHY";
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
                cmd.CommandText = "UspInsertSKU_HIERARCHY";
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
                this.m_SKU_HIE_ID = Convert.ToInt32(dr["SKU_HIE_ID"]);
                this.m_PARENT_SKU_HIE_ID = Convert.ToInt32(dr["PARENT_SKU_HIE_ID"]);
                this.m_SKU_HIE_TYPE_ID = Convert.ToInt32(dr["SKU_HIE_TYPE_ID"]);
                this.m_USER_ID = Convert.ToInt32(dr["USER_ID"]);
                this.m_PRINCIPAL_ID = Convert.ToInt32(dr["PRINCIPAL_ID"]);
                this.m_TIME_STAMP = Convert.ToDateTime(dr["TIME_STAMP"]);
                this.m_LASTUPDATE_DATE = Convert.ToDateTime(dr["LASTUPDATE_DATE"]);
                this.m_IS_ACTIVE = Convert.ToBoolean(dr["IS_ACTIVE"]);
                this.m_SKU_HIE_CODE = Convert.ToString(dr["SKU_HIE_CODE"]);
                this.m_SKU_HIE_NAME = Convert.ToString(dr["SKU_HIE_NAME"]);
                this.m_Brand_Check = Convert.ToString(dr["Brand_Check"]);
            }
        }

        public void GetParameterCollection(ref IDbCommand cmd)
        {
            IDataParameterCollection parameters = cmd.Parameters;
            IDataParameter parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@SKU_HIE_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_SKU_HIE_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_SKU_HIE_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@PARENT_SKU_HIE_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_PARENT_SKU_HIE_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_PARENT_SKU_HIE_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@SKU_HIE_TYPE_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_SKU_HIE_TYPE_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_SKU_HIE_TYPE_ID;
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
            parameter.ParameterName = "@PRINCIPAL_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_PRINCIPAL_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_PRINCIPAL_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
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
            parameter.ParameterName = "@LASTUPDATE_DATE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
            if (this.m_LASTUPDATE_DATE == Constants.DateNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_LASTUPDATE_DATE;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@IS_ACTIVE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
            parameter.Value = this.m_IS_ACTIVE;
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@SKU_HIE_CODE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_SKU_HIE_CODE == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_SKU_HIE_CODE;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@SKU_HIE_NAME";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_SKU_HIE_NAME == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_SKU_HIE_NAME;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@Brand_Check";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_Brand_Check == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_Brand_Check;
            }
            parameters.Add(parameter);
        }

        public string Brand_Check
        {
            get
            {
                return this.m_Brand_Check;
            }
            set
            {
                this.m_Brand_Check = value;
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

        public bool IS_ACTIVE
        {
            get
            {
                return this.m_IS_ACTIVE;
            }
            set
            {
                this.m_IS_ACTIVE = value;
            }
        }

        public DateTime LASTUPDATE_DATE
        {
            get
            {
                return this.m_LASTUPDATE_DATE;
            }
            set
            {
                this.m_LASTUPDATE_DATE = value;
            }
        }

        public int PARENT_SKU_HIE_ID
        {
            get
            {
                return this.m_PARENT_SKU_HIE_ID;
            }
            set
            {
                this.m_PARENT_SKU_HIE_ID = value;
            }
        }

        public int PRINCIPAL_ID
        {
            get
            {
                return this.m_PRINCIPAL_ID;
            }
            set
            {
                this.m_PRINCIPAL_ID = value;
            }
        }

        public string SKU_HIE_CODE
        {
            get
            {
                return this.m_SKU_HIE_CODE;
            }
            set
            {
                this.m_SKU_HIE_CODE = value;
            }
        }

        public int SKU_HIE_ID
        {
            get
            {
                return this.m_SKU_HIE_ID;
            }
            set
            {
                this.m_SKU_HIE_ID = value;
            }
        }

        public string SKU_HIE_NAME
        {
            get
            {
                return this.m_SKU_HIE_NAME;
            }
            set
            {
                this.m_SKU_HIE_NAME = value;
            }
        }

        public int SKU_HIE_TYPE_ID
        {
            get
            {
                return this.m_SKU_HIE_TYPE_ID;
            }
            set
            {
                this.m_SKU_HIE_TYPE_ID = value;
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

