namespace SAMS.DatabaseLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using System;
    using System.Data;

    public class spSelectLOCATION
    {
        private string m_ADDRESS;
        private DateTime m_CLOSING_DATE;
        private IDbConnection m_connection;
        private string m_CONTACT_PERSON;
        private string m_EMAIL;
        private string m_FAX_NO;
        private bool m_INPUT_ACTIVE;
        private int m_LOCATION_ID;
        private string m_LOCATION_NAME;
        private string m_LOCATION_SHORT_NAME;
        private int m_LOCATION_TYPE_ID;
        private string m_MOBILE_NO;
        private DateTime m_OPENING_DATE;
        private bool m_OUTPUT_ACTIVE;
        private string m_PHONE_NO;
        private string m_REGISTRATION_NO;
        private int m_TOWN_ID;
        private IDbTransaction m_transaction;
        private string sp_Name = " spSelectLOCATION";

        public bool ExecuteQuery()
        {
            bool flag;
            try
            {
                IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spSelectLOCATION";
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
                cmd.CommandText = "spSelectLOCATION";
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
                cmd.CommandText = "spSelectLOCATION";
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
                cmd.CommandText = "spSelectLOCATION";
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
                this.m_TOWN_ID = Convert.ToInt32(dr["TOWN_ID"]);
                this.m_LOCATION_TYPE_ID = Convert.ToInt32(dr["LOCATION_TYPE_ID"]);
                this.m_OPENING_DATE = Convert.ToDateTime(dr["OPENING_DATE"]);
                this.m_CLOSING_DATE = Convert.ToDateTime(dr["CLOSING_DATE"]);
                this.m_INPUT_ACTIVE = Convert.ToBoolean(dr["INPUT_ACTIVE"]);
                this.m_OUTPUT_ACTIVE = Convert.ToBoolean(dr["OUTPUT_ACTIVE"]);
                this.m_LOCATION_NAME = Convert.ToString(dr["LOCATION_NAME"]);
                this.m_LOCATION_SHORT_NAME = Convert.ToString(dr["LOCATION_SHORT_NAME"]);
                this.m_PHONE_NO = Convert.ToString(dr["PHONE_NO"]);
                this.m_MOBILE_NO = Convert.ToString(dr["MOBILE_NO"]);
                this.m_FAX_NO = Convert.ToString(dr["FAX_NO"]);
                this.m_EMAIL = Convert.ToString(dr["EMAIL"]);
                this.m_REGISTRATION_NO = Convert.ToString(dr["REGISTRATION_NO"]);
                this.m_ADDRESS = Convert.ToString(dr["ADDRESS"]);
                this.m_CONTACT_PERSON = Convert.ToString(dr["CONTACT_PERSON"]);
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
            parameter.ParameterName = "@TOWN_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_TOWN_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_TOWN_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@LOCATION_TYPE_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_LOCATION_TYPE_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_LOCATION_TYPE_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@OPENING_DATE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
            if (this.m_OPENING_DATE == Constants.DateNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_OPENING_DATE;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@CLOSING_DATE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
            if (this.m_CLOSING_DATE == Constants.DateNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_CLOSING_DATE;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@INPUT_ACTIVE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
            parameter.Value = this.m_INPUT_ACTIVE;
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@OUTPUT_ACTIVE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
            parameter.Value = this.m_OUTPUT_ACTIVE;
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@LOCATION_NAME";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_LOCATION_NAME == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_LOCATION_NAME;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@LOCATION_SHORT_NAME";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_LOCATION_SHORT_NAME == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_LOCATION_SHORT_NAME;
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
            parameter.ParameterName = "@FAX_NO";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_FAX_NO == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_FAX_NO;
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
            parameter.ParameterName = "@REGISTRATION_NO";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_REGISTRATION_NO == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_REGISTRATION_NO;
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

        public DateTime CLOSING_DATE
        {
            get
            {
                return this.m_CLOSING_DATE;
            }
            set
            {
                this.m_CLOSING_DATE = value;
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

        public string FAX_NO
        {
            get
            {
                return this.m_FAX_NO;
            }
            set
            {
                this.m_FAX_NO = value;
            }
        }

        public bool INPUT_ACTIVE
        {
            get
            {
                return this.m_INPUT_ACTIVE;
            }
            set
            {
                this.m_INPUT_ACTIVE = value;
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

        public string LOCATION_NAME
        {
            get
            {
                return this.m_LOCATION_NAME;
            }
            set
            {
                this.m_LOCATION_NAME = value;
            }
        }

        public string LOCATION_SHORT_NAME
        {
            get
            {
                return this.m_LOCATION_SHORT_NAME;
            }
            set
            {
                this.m_LOCATION_SHORT_NAME = value;
            }
        }

        public int LOCATION_TYPE_ID
        {
            get
            {
                return this.m_LOCATION_TYPE_ID;
            }
            set
            {
                this.m_LOCATION_TYPE_ID = value;
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

        public DateTime OPENING_DATE
        {
            get
            {
                return this.m_OPENING_DATE;
            }
            set
            {
                this.m_OPENING_DATE = value;
            }
        }

        public bool OUTPUT_ACTIVE
        {
            get
            {
                return this.m_OUTPUT_ACTIVE;
            }
            set
            {
                this.m_OUTPUT_ACTIVE = value;
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

        public string REGISTRATION_NO
        {
            get
            {
                return this.m_REGISTRATION_NO;
            }
            set
            {
                this.m_REGISTRATION_NO = value;
            }
        }

        public int TOWN_ID
        {
            get
            {
                return this.m_TOWN_ID;
            }
            set
            {
                this.m_TOWN_ID = value;
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

