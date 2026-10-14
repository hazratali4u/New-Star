namespace SAMS.DatabaseLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using System;
    using System.Data;

    public class spUpdateSCHEDULE
    {
        private IDbConnection m_connection;
        private int m_DATA_FROM_DAY;
        private int m_DATA_FROM_MONTH;
        private int m_DATA_TO_DAY;
        private int m_DATA_TO_MONTH;
        private int m_EXECUTION_DAY;
        private int m_EXECUTION_OPTION;
        private DateTime m_EXECUTION_TIME;
        private int m_FREQUENCY_ID;
        private bool m_IS_ACTIVE;
        private DateTime m_LAST_UPDATE_DATE;
        private int m_REPORT_FORMAT_ID;
        private int m_REPORT_ID;
        private string m_SCHEDULE_CODE;
        private int m_SCHEDULE_ID;
        private string m_SCHEDULE_NAME;
        private DateTime m_TIME_STAMP;
        private IDbTransaction m_transaction;
        private int m_USER_ID;
        private string sp_Name = " spUpdateSCHEDULE";

        public bool ExecuteQuery()
        {
            bool flag;
            try
            {
                IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spUpdateSCHEDULE";
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
                cmd.CommandText = "spUpdateSCHEDULE";
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
                cmd.CommandText = "spUpdateSCHEDULE";
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
                cmd.CommandText = "spUpdateSCHEDULE";
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
                this.m_EXECUTION_TIME = Convert.ToDateTime(dr["EXECUTION_TIME"]);
                this.m_TIME_STAMP = Convert.ToDateTime(dr["TIME_STAMP"]);
                this.m_LAST_UPDATE_DATE = Convert.ToDateTime(dr["LAST_UPDATE_DATE"]);
                this.m_REPORT_FORMAT_ID = Convert.ToInt32(dr["REPORT_FORMAT_ID"]);
                this.m_USER_ID = Convert.ToInt32(dr["USER_ID"]);
                this.m_DATA_TO_DAY = Convert.ToInt32(dr["DATA_TO_DAY"]);
                this.m_EXECUTION_OPTION = Convert.ToInt32(dr["EXECUTION_OPTION"]);
                this.m_REPORT_ID = Convert.ToInt32(dr["REPORT_ID"]);
                this.m_DATA_FROM_MONTH = Convert.ToInt32(dr["DATA_FROM_MONTH"]);
                this.m_DATA_FROM_DAY = Convert.ToInt32(dr["DATA_FROM_DAY"]);
                this.m_DATA_TO_MONTH = Convert.ToInt32(dr["DATA_TO_MONTH"]);
                this.m_SCHEDULE_ID = Convert.ToInt32(dr["SCHEDULE_ID"]);
                this.m_FREQUENCY_ID = Convert.ToInt32(dr["FREQUENCY_ID"]);
                this.m_EXECUTION_DAY = Convert.ToInt32(dr["EXECUTION_DAY"]);
                this.m_SCHEDULE_CODE = Convert.ToString(dr["SCHEDULE_CODE"]);
                this.m_SCHEDULE_NAME = Convert.ToString(dr["SCHEDULE_NAME"]);
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
            parameter.ParameterName = "@EXECUTION_TIME";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
            if (this.m_EXECUTION_TIME == Constants.DateNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_EXECUTION_TIME;
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
            parameter.ParameterName = "@REPORT_FORMAT_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_REPORT_FORMAT_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_REPORT_FORMAT_ID;
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
            parameter.ParameterName = "@DATA_TO_DAY";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_DATA_TO_DAY == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_DATA_TO_DAY;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@EXECUTION_OPTION";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_EXECUTION_OPTION == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_EXECUTION_OPTION;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@REPORT_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_REPORT_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_REPORT_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@DATA_FROM_MONTH";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_DATA_FROM_MONTH == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_DATA_FROM_MONTH;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@DATA_FROM_DAY";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_DATA_FROM_DAY == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_DATA_FROM_DAY;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@DATA_TO_MONTH";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_DATA_TO_MONTH == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_DATA_TO_MONTH;
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
            parameter.ParameterName = "@FREQUENCY_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_FREQUENCY_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_FREQUENCY_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@EXECUTION_DAY";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_EXECUTION_DAY == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_EXECUTION_DAY;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@SCHEDULE_CODE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_SCHEDULE_CODE == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_SCHEDULE_CODE;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@SCHEDULE_NAME";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_SCHEDULE_NAME == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_SCHEDULE_NAME;
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

        public int DATA_FROM_DAY
        {
            get
            {
                return this.m_DATA_FROM_DAY;
            }
            set
            {
                this.m_DATA_FROM_DAY = value;
            }
        }

        public int DATA_FROM_MONTH
        {
            get
            {
                return this.m_DATA_FROM_MONTH;
            }
            set
            {
                this.m_DATA_FROM_MONTH = value;
            }
        }

        public int DATA_TO_DAY
        {
            get
            {
                return this.m_DATA_TO_DAY;
            }
            set
            {
                this.m_DATA_TO_DAY = value;
            }
        }

        public int DATA_TO_MONTH
        {
            get
            {
                return this.m_DATA_TO_MONTH;
            }
            set
            {
                this.m_DATA_TO_MONTH = value;
            }
        }

        public int EXECUTION_DAY
        {
            get
            {
                return this.m_EXECUTION_DAY;
            }
            set
            {
                this.m_EXECUTION_DAY = value;
            }
        }

        public int EXECUTION_OPTION
        {
            get
            {
                return this.m_EXECUTION_OPTION;
            }
            set
            {
                this.m_EXECUTION_OPTION = value;
            }
        }

        public DateTime EXECUTION_TIME
        {
            get
            {
                return this.m_EXECUTION_TIME;
            }
            set
            {
                this.m_EXECUTION_TIME = value;
            }
        }

        public int FREQUENCY_ID
        {
            get
            {
                return this.m_FREQUENCY_ID;
            }
            set
            {
                this.m_FREQUENCY_ID = value;
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

        public int REPORT_FORMAT_ID
        {
            get
            {
                return this.m_REPORT_FORMAT_ID;
            }
            set
            {
                this.m_REPORT_FORMAT_ID = value;
            }
        }

        public int REPORT_ID
        {
            get
            {
                return this.m_REPORT_ID;
            }
            set
            {
                this.m_REPORT_ID = value;
            }
        }

        public string SCHEDULE_CODE
        {
            get
            {
                return this.m_SCHEDULE_CODE;
            }
            set
            {
                this.m_SCHEDULE_CODE = value;
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

        public string SCHEDULE_NAME
        {
            get
            {
                return this.m_SCHEDULE_NAME;
            }
            set
            {
                this.m_SCHEDULE_NAME = value;
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

