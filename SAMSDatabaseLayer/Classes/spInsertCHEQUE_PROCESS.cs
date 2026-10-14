namespace SAMS.DatabaseLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using System;
    using System.Data;

    public class spInsertCHEQUE_PROCESS
    {
        private long m_ACCOUNT_HEAD_ID;
        private string m_BANK_NAME;
        private decimal m_CHEQUE_AMOUNT;
        private DateTime m_CHEQUE_DATE;
        private string m_CHEQUE_NO;
        private long m_CHEQUE_PROCESS_ID;
        private IDbConnection m_connection;
        private long m_CUSTOMER_ID;
        private DateTime m_DEPOSIT_DATE;
        private int m_DISTRIBUTOR_ID;
        private DateTime m_LAST_UPDATED;
        private int m_PRINCIPAL_ID;
        private DateTime m_PROCESS_DATE;
        private DateTime m_RECEIVED_DATE;
        private string m_Remarks;
        private int m_SALEMAN_ID;
        private string m_SlipNo;
        private int m_STATUS_ID;
        private DateTime m_TIME_STAMP;
        private IDbTransaction m_transaction;
        private int m_USER_ID;
        private string sp_Name = " spInsertCHEQUE_PROCESS";

        public string ExecuteQuery()
        {
            string str;
            try
            {
                IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spInsertCHEQUE_PROCESS";
                cmd.Connection = this.m_connection;
                if (this.m_transaction != null)
                {
                    cmd.Transaction = this.m_transaction;
                }
                this.GetParameterCollection(ref cmd);
                cmd.ExecuteNonQuery();
                this.m_CHEQUE_PROCESS_ID = (long) ((IDataParameter) cmd.Parameters["@CHEQUE_PROCESS_ID"]).Value;
                str = this.m_CHEQUE_PROCESS_ID.ToString();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return str;
        }

        public IDataReader ExecuteReader()
        {
            IDataReader reader2;
            try
            {
                IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spInsertCHEQUE_PROCESS";
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
                cmd.CommandText = "spInsertCHEQUE_PROCESS";
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
                cmd.CommandText = "spInsertCHEQUE_PROCESS";
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
                this.m_DISTRIBUTOR_ID = Convert.ToInt32(dr["DISTRIBUTOR_ID"]);
                this.m_PRINCIPAL_ID = Convert.ToInt32(dr["PRINCIPAL_ID"]);
                this.m_STATUS_ID = Convert.ToInt32(dr["STATUS_ID"]);
                this.m_USER_ID = Convert.ToInt32(dr["USER_ID"]);
                this.m_SALEMAN_ID = Convert.ToInt32(dr["SALEMAN_ID"]);
                this.m_CHEQUE_AMOUNT = Convert.ToDecimal(dr["CHEQUE_AMOUNT"]);
                this.m_CHEQUE_DATE = Convert.ToDateTime(dr["CHEQUE_DATE"]);
                this.m_RECEIVED_DATE = Convert.ToDateTime(dr["RECEIVED_DATE"]);
                this.m_DEPOSIT_DATE = Convert.ToDateTime(dr["DEPOSIT_DATE"]);
                this.m_PROCESS_DATE = Convert.ToDateTime(dr["PROCESS_DATE"]);
                this.m_TIME_STAMP = Convert.ToDateTime(dr["TIME_STAMP"]);
                this.m_LAST_UPDATED = Convert.ToDateTime(dr["LAST_UPDATED"]);
                this.m_CUSTOMER_ID = Convert.ToInt64(dr["CUSTOMER_ID"]);
                this.m_ACCOUNT_HEAD_ID = Convert.ToInt64(dr["ACCOUNT_HEAD_ID"]);
                this.m_CHEQUE_PROCESS_ID = Convert.ToInt64(dr["CHEQUE_PROCESS_ID"]);
                this.m_CHEQUE_NO = Convert.ToString(dr["CHEQUE_NO"]);
                this.m_BANK_NAME = Convert.ToString(dr["BANK_NAME"]);
                this.m_SlipNo = Convert.ToString(dr["SlipNo"]);
                this.m_Remarks = Convert.ToString(dr["Remarks"]);
            }
        }

        public void GetParameterCollection(ref IDbCommand cmd)
        {
            IDataParameterCollection parameters = cmd.Parameters;
            IDataParameter parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
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
            parameter.ParameterName = "@STATUS_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_STATUS_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_STATUS_ID;
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
            parameter.ParameterName = "@SALEMAN_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_SALEMAN_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_SALEMAN_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@CHEQUE_AMOUNT";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
            if (this.m_CHEQUE_AMOUNT == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_CHEQUE_AMOUNT;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@CHEQUE_DATE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
            if (this.m_CHEQUE_DATE == Constants.DateNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_CHEQUE_DATE;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@RECEIVED_DATE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
            if (this.m_RECEIVED_DATE == Constants.DateNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_RECEIVED_DATE;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@DEPOSIT_DATE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
            if (this.m_DEPOSIT_DATE == Constants.DateNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_DEPOSIT_DATE;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@PROCESS_DATE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
            if (this.m_PROCESS_DATE == Constants.DateNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_PROCESS_DATE;
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
            parameter.ParameterName = "@LAST_UPDATED";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
            if (this.m_LAST_UPDATED == Constants.DateNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_LAST_UPDATED;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@CUSTOMER_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
            if (this.m_CUSTOMER_ID == -9223372036854775808L)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_CUSTOMER_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@ACCOUNT_HEAD_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
            if (this.m_ACCOUNT_HEAD_ID == -9223372036854775808L)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_ACCOUNT_HEAD_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@CHEQUE_PROCESS_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
            parameter.Direction = ParameterDirection.Output;
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@CHEQUE_NO";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_CHEQUE_NO == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_CHEQUE_NO;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@BANK_NAME";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_BANK_NAME == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_BANK_NAME;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@SlipNo";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_SlipNo == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_SlipNo;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@Remarks";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_Remarks == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_Remarks;
            }
            parameters.Add(parameter);
        }

        public long ACCOUNT_HEAD_ID
        {
            get
            {
                return this.m_ACCOUNT_HEAD_ID;
            }
            set
            {
                this.m_ACCOUNT_HEAD_ID = value;
            }
        }

        public string BANK_NAME
        {
            get
            {
                return this.m_BANK_NAME;
            }
            set
            {
                this.m_BANK_NAME = value;
            }
        }

        public decimal CHEQUE_AMOUNT
        {
            get
            {
                return this.m_CHEQUE_AMOUNT;
            }
            set
            {
                this.m_CHEQUE_AMOUNT = value;
            }
        }

        public DateTime CHEQUE_DATE
        {
            get
            {
                return this.m_CHEQUE_DATE;
            }
            set
            {
                this.m_CHEQUE_DATE = value;
            }
        }

        public string CHEQUE_NO
        {
            get
            {
                return this.m_CHEQUE_NO;
            }
            set
            {
                this.m_CHEQUE_NO = value;
            }
        }

        public long CHEQUE_PROCESS_ID
        {
            get
            {
                return this.m_CHEQUE_PROCESS_ID;
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

        public long CUSTOMER_ID
        {
            get
            {
                return this.m_CUSTOMER_ID;
            }
            set
            {
                this.m_CUSTOMER_ID = value;
            }
        }

        public DateTime DEPOSIT_DATE
        {
            get
            {
                return this.m_DEPOSIT_DATE;
            }
            set
            {
                this.m_DEPOSIT_DATE = value;
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

        public DateTime LAST_UPDATED
        {
            get
            {
                return this.m_LAST_UPDATED;
            }
            set
            {
                this.m_LAST_UPDATED = value;
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

        public DateTime PROCESS_DATE
        {
            get
            {
                return this.m_PROCESS_DATE;
            }
            set
            {
                this.m_PROCESS_DATE = value;
            }
        }

        public DateTime RECEIVED_DATE
        {
            get
            {
                return this.m_RECEIVED_DATE;
            }
            set
            {
                this.m_RECEIVED_DATE = value;
            }
        }

        public string Remarks
        {
            get
            {
                return this.m_Remarks;
            }
            set
            {
                this.m_Remarks = value;
            }
        }

        public int SALEMAN_ID
        {
            get
            {
                return this.m_SALEMAN_ID;
            }
            set
            {
                this.m_SALEMAN_ID = value;
            }
        }

        public string SlipNo
        {
            get
            {
                return this.m_SlipNo;
            }
            set
            {
                this.m_SlipNo = value;
            }
        }

        public int STATUS_ID
        {
            get
            {
                return this.m_STATUS_ID;
            }
            set
            {
                this.m_STATUS_ID = value;
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

