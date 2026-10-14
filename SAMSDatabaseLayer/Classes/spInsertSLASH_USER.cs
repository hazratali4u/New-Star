namespace SAMS.DatabaseLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using System;
    using System.Data;

    public class spInsertSLASH_USER
    {
        private string m_ADDRESS1;
        private string m_ADDRESS2;
        private int m_C_USER_ID;
        private IDbConnection m_connection;
        private int m_DESIGNATION_ID;
        private int m_DISTRIBUTOR_ID;
        private string m_EMAIL_ADDRESS;
        private string m_FAX;
        private string m_IP_ADDRESS;
        private bool m_IS_ACTIVE;
        private bool m_IS_DEFAULT;
        private bool m_IS_DELETED;
        private bool m_IS_DISTRIBUTOR_LOGIN;
        private bool m_IS_PPC_LOGIN;
        private bool m_IS_SERVER_LOGIN;
        private DateTime m_LASTUPDATE_DATE;
        private string m_LOGIN_ID;
        private string m_MOBILE;
        private string m_PASSWORD;
        private string m_PHONE;
        private int m_REGION_ID;
        private int m_ROLE_ID;
        private int m_TERRITORY_ID;
        private DateTime m_TIME_STAMP;
        private int m_TOWN_ID;
        private IDbTransaction m_transaction;
        private string m_USER_CODE;
        private int m_USER_ID;
        private string m_USER_NAME;
        private int m_USER_TYPE_ID;
        private int m_ZONE_ID;
        private string sp_Name = " spInsertSLASH_USER";

        public bool ExecuteQuery()
        {
            bool flag;
            try
            {
                IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spInsertSLASH_USER";
                cmd.Connection = this.m_connection;
                if (this.m_transaction != null)
                {
                    cmd.Transaction = this.m_transaction;
                }
                this.GetParameterCollection(ref cmd);
                cmd.ExecuteNonQuery();
                this.m_USER_ID = (int) ((IDataParameter) cmd.Parameters["@USER_ID"]).Value;
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
                cmd.CommandText = "spInsertSLASH_USER";
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
                cmd.CommandText = "spInsertSLASH_USER";
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
                cmd.CommandText = "spInsertSLASH_USER";
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
                this.m_IS_ACTIVE = Convert.ToBoolean(dr["IS_ACTIVE"]);
                this.m_IS_DELETED = Convert.ToBoolean(dr["IS_DELETED"]);
                this.m_IS_DEFAULT = Convert.ToBoolean(dr["IS_DEFAULT"]);
                this.m_IS_SERVER_LOGIN = Convert.ToBoolean(dr["IS_SERVER_LOGIN"]);
                this.m_IS_DISTRIBUTOR_LOGIN = Convert.ToBoolean(dr["IS_DISTRIBUTOR_LOGIN"]);
                this.m_IS_PPC_LOGIN = Convert.ToBoolean(dr["IS_PPC_LOGIN"]);
                this.m_TIME_STAMP = Convert.ToDateTime(dr["TIME_STAMP"]);
                this.m_LASTUPDATE_DATE = Convert.ToDateTime(dr["LASTUPDATE_DATE"]);
                this.m_USER_ID = Convert.ToInt32(dr["USER_ID"]);
                this.m_USER_TYPE_ID = Convert.ToInt32(dr["USER_TYPE_ID"]);
                this.m_TOWN_ID = Convert.ToInt32(dr["TOWN_ID"]);
                this.m_C_USER_ID = Convert.ToInt32(dr["C_USER_ID"]);
                this.m_REGION_ID = Convert.ToInt32(dr["REGION_ID"]);
                this.m_ZONE_ID = Convert.ToInt32(dr["ZONE_ID"]);
                this.m_TERRITORY_ID = Convert.ToInt32(dr["TERRITORY_ID"]);
                this.m_DISTRIBUTOR_ID = Convert.ToInt32(dr["DISTRIBUTOR_ID"]);
                this.m_DESIGNATION_ID = Convert.ToInt32(dr["DESIGNATION_ID"]);
                this.m_ROLE_ID = Convert.ToInt32(dr["ROLE_ID"]);
                this.m_EMAIL_ADDRESS = Convert.ToString(dr["EMAIL_ADDRESS"]);
                this.m_IP_ADDRESS = Convert.ToString(dr["IP_ADDRESS"]);
                this.m_ADDRESS2 = Convert.ToString(dr["ADDRESS2"]);
                this.m_LOGIN_ID = Convert.ToString(dr["LOGIN_ID"]);
                this.m_PASSWORD = Convert.ToString(dr["PASSWORD"]);
                this.m_FAX = Convert.ToString(dr["FAX"]);
                this.m_MOBILE = Convert.ToString(dr["MOBILE"]);
                this.m_ADDRESS1 = Convert.ToString(dr["ADDRESS1"]);
                this.m_USER_CODE = Convert.ToString(dr["USER_CODE"]);
                this.m_USER_NAME = Convert.ToString(dr["USER_NAME"]);
                this.m_PHONE = Convert.ToString(dr["PHONE"]);
            }
        }

        public void GetParameterCollection(ref IDbCommand cmd)
        {
            IDataParameterCollection parameters = cmd.Parameters;
            IDataParameter parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@IS_ACTIVE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
            parameter.Value = this.m_IS_ACTIVE;
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@IS_DELETED";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
            parameter.Value = this.m_IS_DELETED;
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@IS_DEFAULT";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
            parameter.Value = this.m_IS_DEFAULT;
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@IS_SERVER_LOGIN";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
            parameter.Value = this.m_IS_SERVER_LOGIN;
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@IS_DISTRIBUTOR_LOGIN";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
            parameter.Value = this.m_IS_DISTRIBUTOR_LOGIN;
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@IS_PPC_LOGIN";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
            parameter.Value = this.m_IS_PPC_LOGIN;
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
            parameter.ParameterName = "@USER_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            parameter.Direction = ParameterDirection.Output;
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@USER_TYPE_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_USER_TYPE_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_USER_TYPE_ID;
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
            parameter.ParameterName = "@C_USER_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_C_USER_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_C_USER_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@REGION_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_REGION_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_REGION_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@ZONE_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_ZONE_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_ZONE_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@TERRITORY_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_TERRITORY_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_TERRITORY_ID;
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
            parameter.ParameterName = "@DESIGNATION_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_DESIGNATION_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_DESIGNATION_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
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
            parameter.ParameterName = "@EMAIL_ADDRESS";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_EMAIL_ADDRESS == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_EMAIL_ADDRESS;
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
            parameter.ParameterName = "@ADDRESS2";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_ADDRESS2 == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_ADDRESS2;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@LOGIN_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_LOGIN_ID == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_LOGIN_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@PASSWORD";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_PASSWORD == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_PASSWORD;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@FAX";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_FAX == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_FAX;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@MOBILE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_MOBILE == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_MOBILE;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@ADDRESS1";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_ADDRESS1 == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_ADDRESS1;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@USER_CODE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_USER_CODE == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_USER_CODE;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@USER_NAME";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_USER_NAME == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_USER_NAME;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@PHONE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_PHONE == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_PHONE;
            }
            parameters.Add(parameter);
        }

        public string ADDRESS1
        {
            get
            {
                return this.m_ADDRESS1;
            }
            set
            {
                this.m_ADDRESS1 = value;
            }
        }

        public string ADDRESS2
        {
            get
            {
                return this.m_ADDRESS2;
            }
            set
            {
                this.m_ADDRESS2 = value;
            }
        }

        public int C_USER_ID
        {
            get
            {
                return this.m_C_USER_ID;
            }
            set
            {
                this.m_C_USER_ID = value;
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

        public int DESIGNATION_ID
        {
            get
            {
                return this.m_DESIGNATION_ID;
            }
            set
            {
                this.m_DESIGNATION_ID = value;
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

        public string EMAIL_ADDRESS
        {
            get
            {
                return this.m_EMAIL_ADDRESS;
            }
            set
            {
                this.m_EMAIL_ADDRESS = value;
            }
        }

        public string FAX
        {
            get
            {
                return this.m_FAX;
            }
            set
            {
                this.m_FAX = value;
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

        public bool IS_DEFAULT
        {
            get
            {
                return this.m_IS_DEFAULT;
            }
            set
            {
                this.m_IS_DEFAULT = value;
            }
        }

        public bool IS_DELETED
        {
            get
            {
                return this.m_IS_DELETED;
            }
            set
            {
                this.m_IS_DELETED = value;
            }
        }

        public bool IS_DISTRIBUTOR_LOGIN
        {
            get
            {
                return this.m_IS_DISTRIBUTOR_LOGIN;
            }
            set
            {
                this.m_IS_DISTRIBUTOR_LOGIN = value;
            }
        }

        public bool IS_PPC_LOGIN
        {
            get
            {
                return this.m_IS_PPC_LOGIN;
            }
            set
            {
                this.m_IS_PPC_LOGIN = value;
            }
        }

        public bool IS_SERVER_LOGIN
        {
            get
            {
                return this.m_IS_SERVER_LOGIN;
            }
            set
            {
                this.m_IS_SERVER_LOGIN = value;
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

        public string LOGIN_ID
        {
            get
            {
                return this.m_LOGIN_ID;
            }
            set
            {
                this.m_LOGIN_ID = value;
            }
        }

        public string MOBILE
        {
            get
            {
                return this.m_MOBILE;
            }
            set
            {
                this.m_MOBILE = value;
            }
        }

        public string PASSWORD
        {
            get
            {
                return this.m_PASSWORD;
            }
            set
            {
                this.m_PASSWORD = value;
            }
        }

        public string PHONE
        {
            get
            {
                return this.m_PHONE;
            }
            set
            {
                this.m_PHONE = value;
            }
        }

        public int REGION_ID
        {
            get
            {
                return this.m_REGION_ID;
            }
            set
            {
                this.m_REGION_ID = value;
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

        public int TERRITORY_ID
        {
            get
            {
                return this.m_TERRITORY_ID;
            }
            set
            {
                this.m_TERRITORY_ID = value;
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

        public string USER_CODE
        {
            get
            {
                return this.m_USER_CODE;
            }
            set
            {
                this.m_USER_CODE = value;
            }
        }

        public int USER_ID
        {
            get
            {
                return this.m_USER_ID;
            }
        }

        public string USER_NAME
        {
            get
            {
                return this.m_USER_NAME;
            }
            set
            {
                this.m_USER_NAME = value;
            }
        }

        public int USER_TYPE_ID
        {
            get
            {
                return this.m_USER_TYPE_ID;
            }
            set
            {
                this.m_USER_TYPE_ID = value;
            }
        }

        public int ZONE_ID
        {
            get
            {
                return this.m_ZONE_ID;
            }
            set
            {
                this.m_ZONE_ID = value;
            }
        }
    }
}

