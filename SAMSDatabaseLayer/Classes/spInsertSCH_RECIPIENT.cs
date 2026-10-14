namespace SAMS.DatabaseLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using System;
    using System.Data;

    public class spInsertSCH_RECIPIENT
    {
        private IDbConnection m_connection;
        private bool m_IS_ACTIVE;
        private DateTime m_LAST_UPDATE_DATE;
        private string m_MESSAGE_SUBJECT;
        private string m_MESSAGE_TEXT;
        private string m_RECIPIENT_BCC;
        private string m_RECIPIENT_CC;
        private string m_RECIPIENT_NAME;
        private string m_RECIPIENT_TO;
        private int m_SCH_RECIPIENT_ID;
        private int m_SCHEDULE_ID;
        private DateTime m_TIME_STAMP;
        private IDbTransaction m_transaction;
        private int m_USER_ID;
        private string sp_Name = " spInsertSCH_RECIPIENT";

        public bool ExecuteQuery()
        {
            bool flag;
            try
            {
                IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spInsertSCH_RECIPIENT";
                cmd.Connection = this.m_connection;
                if (this.m_transaction != null)
                {
                    cmd.Transaction = this.m_transaction;
                }
                this.GetParameterCollection(ref cmd);
                cmd.ExecuteNonQuery();
                this.m_SCH_RECIPIENT_ID = (int) ((IDataParameter) cmd.Parameters["@SCH_RECIPIENT_ID"]).Value;
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
                cmd.CommandText = "spInsertSCH_RECIPIENT";
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
                cmd.CommandText = "spInsertSCH_RECIPIENT";
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
                cmd.CommandText = "spInsertSCH_RECIPIENT";
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
                this.m_TIME_STAMP = Convert.ToDateTime(dr["TIME_STAMP"]);
                this.m_LAST_UPDATE_DATE = Convert.ToDateTime(dr["LAST_UPDATE_DATE"]);
                this.m_SCHEDULE_ID = Convert.ToInt32(dr["SCHEDULE_ID"]);
                this.m_USER_ID = Convert.ToInt32(dr["USER_ID"]);
                this.m_SCH_RECIPIENT_ID = Convert.ToInt32(dr["SCH_RECIPIENT_ID"]);
                this.m_RECIPIENT_BCC = Convert.ToString(dr["RECIPIENT_BCC"]);
                this.m_MESSAGE_TEXT = Convert.ToString(dr["MESSAGE_TEXT"]);
                this.m_MESSAGE_SUBJECT = Convert.ToString(dr["MESSAGE_SUBJECT"]);
                this.m_RECIPIENT_NAME = Convert.ToString(dr["RECIPIENT_NAME"]);
                this.m_RECIPIENT_TO = Convert.ToString(dr["RECIPIENT_TO"]);
                this.m_RECIPIENT_CC = Convert.ToString(dr["RECIPIENT_CC"]);
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
            parameter.ParameterName = "@LAST_UPDATE_DATE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
            if (this.m_LAST_UPDATE_DATE == Constants.DateNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_LAST_UPDATE_DATE;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@SCHEDULE_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_SCHEDULE_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_SCHEDULE_ID;
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
            parameter.ParameterName = "@SCH_RECIPIENT_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            parameter.Direction = ParameterDirection.Output;
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@RECIPIENT_BCC";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_RECIPIENT_BCC == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_RECIPIENT_BCC;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@MESSAGE_TEXT";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_MESSAGE_TEXT == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_MESSAGE_TEXT;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@MESSAGE_SUBJECT";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_MESSAGE_SUBJECT == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_MESSAGE_SUBJECT;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@RECIPIENT_NAME";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_RECIPIENT_NAME == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_RECIPIENT_NAME;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@RECIPIENT_TO";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_RECIPIENT_TO == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_RECIPIENT_TO;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@RECIPIENT_CC";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_RECIPIENT_CC == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_RECIPIENT_CC;
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

        public DateTime LAST_UPDATE_DATE
        {
            get
            {
                return this.m_LAST_UPDATE_DATE;
            }
            set
            {
                this.m_LAST_UPDATE_DATE = value;
            }
        }

        public string MESSAGE_SUBJECT
        {
            get
            {
                return this.m_MESSAGE_SUBJECT;
            }
            set
            {
                this.m_MESSAGE_SUBJECT = value;
            }
        }

        public string MESSAGE_TEXT
        {
            get
            {
                return this.m_MESSAGE_TEXT;
            }
            set
            {
                this.m_MESSAGE_TEXT = value;
            }
        }

        public string RECIPIENT_BCC
        {
            get
            {
                return this.m_RECIPIENT_BCC;
            }
            set
            {
                this.m_RECIPIENT_BCC = value;
            }
        }

        public string RECIPIENT_CC
        {
            get
            {
                return this.m_RECIPIENT_CC;
            }
            set
            {
                this.m_RECIPIENT_CC = value;
            }
        }

        public string RECIPIENT_NAME
        {
            get
            {
                return this.m_RECIPIENT_NAME;
            }
            set
            {
                this.m_RECIPIENT_NAME = value;
            }
        }

        public string RECIPIENT_TO
        {
            get
            {
                return this.m_RECIPIENT_TO;
            }
            set
            {
                this.m_RECIPIENT_TO = value;
            }
        }

        public int SCH_RECIPIENT_ID
        {
            get
            {
                return this.m_SCH_RECIPIENT_ID;
            }
        }

        public int SCHEDULE_ID
        {
            get
            {
                return this.m_SCHEDULE_ID;
            }
            set
            {
                this.m_SCHEDULE_ID = value;
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

