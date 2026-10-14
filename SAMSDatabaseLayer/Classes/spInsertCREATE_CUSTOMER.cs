namespace SAMS.DatabaseLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using System;
    using System.Data;

    public class spInsertCREATE_CUSTOMER
    {
        private string m_ADDRESS;
        private int m_BUSSINESS_TYPE_ID;
        private int m_CHANNEL_TYPE_ID;
        private IDbConnection m_connection;
        private string m_CONTACT_PERSON;
        private int m_CUSTOMER_ID;
        private string m_CUSTOMER_NAME;
        private string m_CUSTOMER_SHORTNAME;
        private int m_CUSTOMER_TYPE_ID;
        private string m_EMAIL;
        private string m_GST_NO;
        private string m_HOME_TOWN;
        private int m_LOCATION_ID;
        private string m_MARKET;
        private string m_MOBILE_NO;
        private string m_PHONE_NO;
        private string m_ROUTE;
        private DateTime m_TIMESTAMP;
        private IDbTransaction m_transaction;
        private int m_VOLUME_CLASS_ID;
        private string sp_Name = " spInsertCREATE_CUSTOMER";

        public bool ExecuteQuery()
        {
            bool flag;
            try
            {
                IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spInsertCREATE_CUSTOMER";
                cmd.Connection = this.m_connection;
                if (this.m_transaction != null)
                {
                    cmd.Transaction = this.m_transaction;
                }
                this.GetParameterCollection(ref cmd);
                cmd.ExecuteNonQuery();
                this.m_CUSTOMER_ID = (int) ((IDataParameter) cmd.Parameters["@CUSTOMER_ID"]).Value;
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
                cmd.CommandText = "spInsertCREATE_CUSTOMER";
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
                cmd.CommandText = "spInsertCREATE_CUSTOMER";
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
                cmd.CommandText = "spInsertCREATE_CUSTOMER";
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
                this.m_LOCATION_ID = Convert.ToInt32(dr["LOCATION_ID"]);
                this.m_BUSSINESS_TYPE_ID = Convert.ToInt32(dr["BUSSINESS_TYPE_ID"]);
                this.m_CUSTOMER_TYPE_ID = Convert.ToInt32(dr["CUSTOMER_TYPE_ID"]);
                this.m_CHANNEL_TYPE_ID = Convert.ToInt32(dr["CHANNEL_TYPE_ID"]);
                this.m_VOLUME_CLASS_ID = Convert.ToInt32(dr["VOLUME_CLASS_ID"]);
                this.m_CUSTOMER_ID = Convert.ToInt32(dr["CUSTOMER_ID"]);
                this.m_TIMESTAMP = Convert.ToDateTime(dr["TIMESTAMP"]);
                this.m_CUSTOMER_NAME = Convert.ToString(dr["CUSTOMER_NAME"]);
                this.m_CUSTOMER_SHORTNAME = Convert.ToString(dr["CUSTOMER_SHORTNAME"]);
                this.m_CONTACT_PERSON = Convert.ToString(dr["CONTACT_PERSON"]);
                this.m_PHONE_NO = Convert.ToString(dr["PHONE_NO"]);
                this.m_MOBILE_NO = Convert.ToString(dr["MOBILE_NO"]);
                this.m_EMAIL = Convert.ToString(dr["EMAIL"]);
                this.m_GST_NO = Convert.ToString(dr["GST_NO"]);
                this.m_ADDRESS = Convert.ToString(dr["ADDRESS"]);
                this.m_MARKET = Convert.ToString(dr["MARKET"]);
                this.m_ROUTE = Convert.ToString(dr["ROUTE"]);
                this.m_HOME_TOWN = Convert.ToString(dr["HOME_TOWN"]);
            }
        }

        public void GetParameterCollection(ref IDbCommand cmd)
        {
            IDataParameterCollection parameters = cmd.Parameters;
            IDataParameter parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@LOCATION_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_LOCATION_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_LOCATION_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@BUSSINESS_TYPE_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_BUSSINESS_TYPE_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_BUSSINESS_TYPE_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@CUSTOMER_TYPE_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_CUSTOMER_TYPE_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_CUSTOMER_TYPE_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@CHANNEL_TYPE_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_CHANNEL_TYPE_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_CHANNEL_TYPE_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@VOLUME_CLASS_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_VOLUME_CLASS_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_VOLUME_CLASS_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@CUSTOMER_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            parameter.Direction = ParameterDirection.Output;
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@TIMESTAMP";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
            if (this.m_TIMESTAMP == Constants.DateNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_TIMESTAMP;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@CUSTOMER_NAME";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_CUSTOMER_NAME == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_CUSTOMER_NAME;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@CUSTOMER_SHORTNAME";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_CUSTOMER_SHORTNAME == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_CUSTOMER_SHORTNAME;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@CONTACT_PERSON";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_CONTACT_PERSON == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_CONTACT_PERSON;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@PHONE_NO";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_PHONE_NO == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_PHONE_NO;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@MOBILE_NO";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_MOBILE_NO == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_MOBILE_NO;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@EMAIL";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_EMAIL == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_EMAIL;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@GST_NO";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_GST_NO == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_GST_NO;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@ADDRESS";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_ADDRESS == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_ADDRESS;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@MARKET";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_MARKET == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_MARKET;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@ROUTE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_ROUTE == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_ROUTE;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@HOME_TOWN";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_HOME_TOWN == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_HOME_TOWN;
            }
            parameters.Add(parameter);
        }

        public string ADDRESS
        {
            get
            {
                return this.m_ADDRESS;
            }
            set
            {
                this.m_ADDRESS = value;
            }
        }

        public int BUSSINESS_TYPE_ID
        {
            get
            {
                return this.m_BUSSINESS_TYPE_ID;
            }
            set
            {
                this.m_BUSSINESS_TYPE_ID = value;
            }
        }

        public int CHANNEL_TYPE_ID
        {
            get
            {
                return this.m_CHANNEL_TYPE_ID;
            }
            set
            {
                this.m_CHANNEL_TYPE_ID = value;
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

        public string CONTACT_PERSON
        {
            get
            {
                return this.m_CONTACT_PERSON;
            }
            set
            {
                this.m_CONTACT_PERSON = value;
            }
        }

        public int CUSTOMER_ID
        {
            get
            {
                return this.m_CUSTOMER_ID;
            }
        }

        public string CUSTOMER_NAME
        {
            get
            {
                return this.m_CUSTOMER_NAME;
            }
            set
            {
                this.m_CUSTOMER_NAME = value;
            }
        }

        public string CUSTOMER_SHORTNAME
        {
            get
            {
                return this.m_CUSTOMER_SHORTNAME;
            }
            set
            {
                this.m_CUSTOMER_SHORTNAME = value;
            }
        }

        public int CUSTOMER_TYPE_ID
        {
            get
            {
                return this.m_CUSTOMER_TYPE_ID;
            }
            set
            {
                this.m_CUSTOMER_TYPE_ID = value;
            }
        }

        public string EMAIL
        {
            get
            {
                return this.m_EMAIL;
            }
            set
            {
                this.m_EMAIL = value;
            }
        }

        public string GST_NO
        {
            get
            {
                return this.m_GST_NO;
            }
            set
            {
                this.m_GST_NO = value;
            }
        }

        public string HOME_TOWN
        {
            get
            {
                return this.m_HOME_TOWN;
            }
            set
            {
                this.m_HOME_TOWN = value;
            }
        }

        public int LOCATION_ID
        {
            get
            {
                return this.m_LOCATION_ID;
            }
            set
            {
                this.m_LOCATION_ID = value;
            }
        }

        public string MARKET
        {
            get
            {
                return this.m_MARKET;
            }
            set
            {
                this.m_MARKET = value;
            }
        }

        public string MOBILE_NO
        {
            get
            {
                return this.m_MOBILE_NO;
            }
            set
            {
                this.m_MOBILE_NO = value;
            }
        }

        public string PHONE_NO
        {
            get
            {
                return this.m_PHONE_NO;
            }
            set
            {
                this.m_PHONE_NO = value;
            }
        }

        public string ROUTE
        {
            get
            {
                return this.m_ROUTE;
            }
            set
            {
                this.m_ROUTE = value;
            }
        }

        public DateTime TIMESTAMP
        {
            get
            {
                return this.m_TIMESTAMP;
            }
            set
            {
                this.m_TIMESTAMP = value;
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

        public int VOLUME_CLASS_ID
        {
            get
            {
                return this.m_VOLUME_CLASS_ID;
            }
            set
            {
                this.m_VOLUME_CLASS_ID = value;
            }
        }
    }
}

