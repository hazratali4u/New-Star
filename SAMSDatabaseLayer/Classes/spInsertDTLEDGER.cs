namespace SAMS.DatabaseLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using System;
    using System.Data;

    public class spInsertDTLEDGER
    {
        private long m_ACCOUNT_HEAD_ID;
        private int m_ACCOUNT_TYPE_ID;
        private string m_CHEQUE_NO;
        private IDbConnection m_connection;
        private decimal m_CREDIT;
        private decimal m_DEBIT;
        private int m_DISTRIBUTOR_ID;
        private string m_INVOICE_NO;
        private bool m_IS_RECEIVED;
        private DateTime m_LEDGER_DATE;
        private long m_LEDGER_ID;
        private int m_PAYMENT_MODE_ID;
        private string m_REMARKS;
        private DateTime m_TIME_STAMP;
        private IDbTransaction m_transaction;
        private int m_TRANSACTION_TYPE_ID;
        private string sp_Name = " spInsertDTLEDGER";

        public bool ExecuteQuery()
        {
            bool flag;
            try
            {
                IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spInsertDTLEDGER";
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
                cmd.CommandText = "spInsertDTLEDGER";
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
                cmd.CommandText = "spInsertDTLEDGER";
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
                cmd.CommandText = "spInsertDTLEDGER";
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
                this.m_ACCOUNT_HEAD_ID = Convert.ToInt64(dr["ACCOUNT_HEAD_ID"]);
                this.m_LEDGER_ID = Convert.ToInt64(dr["LEDGER_ID"]);
                this.m_IS_RECEIVED = Convert.ToBoolean(dr["IS_RECEIVED"]);
                this.m_LEDGER_DATE = Convert.ToDateTime(dr["LEDGER_DATE"]);
                this.m_TIME_STAMP = Convert.ToDateTime(dr["TIME_STAMP"]);
                this.m_ACCOUNT_TYPE_ID = Convert.ToInt32(dr["ACCOUNT_TYPE_ID"]);
                this.m_DISTRIBUTOR_ID = Convert.ToInt32(dr["DISTRIBUTOR_ID"]);
                this.m_PAYMENT_MODE_ID = Convert.ToInt32(dr["PAYMENT_MODE_ID"]);
                this.m_TRANSACTION_TYPE_ID = Convert.ToInt32(dr["TRANSACTION_TYPE_ID"]);
                this.m_DEBIT = Convert.ToDecimal(dr["DEBIT"]);
                this.m_CREDIT = Convert.ToDecimal(dr["CREDIT"]);
                this.m_REMARKS = Convert.ToString(dr["REMARKS"]);
                this.m_CHEQUE_NO = Convert.ToString(dr["CHEQUE_NO"]);
                this.m_INVOICE_NO = Convert.ToString(dr["INVOICE_NO"]);
            }
        }

        public void GetParameterCollection(ref IDbCommand cmd)
        {
            IDataParameterCollection parameters = cmd.Parameters;
            IDataParameter parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
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
            parameter.ParameterName = "@LEDGER_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
            if (this.m_LEDGER_ID == -9223372036854775808L)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_LEDGER_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@IS_RECEIVED";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
            parameter.Value = this.m_IS_RECEIVED;
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@LEDGER_DATE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
            if (this.m_LEDGER_DATE == Constants.DateNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_LEDGER_DATE;
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
            parameter.ParameterName = "@ACCOUNT_TYPE_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_ACCOUNT_TYPE_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_ACCOUNT_TYPE_ID;
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
            parameter.ParameterName = "@PAYMENT_MODE_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_PAYMENT_MODE_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_PAYMENT_MODE_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@TRANSACTION_TYPE_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_TRANSACTION_TYPE_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_TRANSACTION_TYPE_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@DEBIT";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
            if (this.m_DEBIT == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_DEBIT;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@CREDIT";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
            if (this.m_CREDIT == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_CREDIT;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@REMARKS";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_REMARKS == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_REMARKS;
            }
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
            parameter.ParameterName = "@INVOICE_NO";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_INVOICE_NO == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_INVOICE_NO;
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

        public int ACCOUNT_TYPE_ID
        {
            get
            {
                return this.m_ACCOUNT_TYPE_ID;
            }
            set
            {
                this.m_ACCOUNT_TYPE_ID = value;
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

        public decimal CREDIT
        {
            get
            {
                return this.m_CREDIT;
            }
            set
            {
                this.m_CREDIT = value;
            }
        }

        public decimal DEBIT
        {
            get
            {
                return this.m_DEBIT;
            }
            set
            {
                this.m_DEBIT = value;
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

        public string INVOICE_NO
        {
            get
            {
                return this.m_INVOICE_NO;
            }
            set
            {
                this.m_INVOICE_NO = value;
            }
        }

        public bool IS_RECEIVED
        {
            get
            {
                return this.m_IS_RECEIVED;
            }
            set
            {
                this.m_IS_RECEIVED = value;
            }
        }

        public DateTime LEDGER_DATE
        {
            get
            {
                return this.m_LEDGER_DATE;
            }
            set
            {
                this.m_LEDGER_DATE = value;
            }
        }

        public long LEDGER_ID
        {
            get
            {
                return this.m_LEDGER_ID;
            }
            set
            {
                this.m_LEDGER_ID = value;
            }
        }

        public int PAYMENT_MODE_ID
        {
            get
            {
                return this.m_PAYMENT_MODE_ID;
            }
            set
            {
                this.m_PAYMENT_MODE_ID = value;
            }
        }

        public string REMARKS
        {
            get
            {
                return this.m_REMARKS;
            }
            set
            {
                this.m_REMARKS = value;
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

        public int TRANSACTION_TYPE_ID
        {
            get
            {
                return this.m_TRANSACTION_TYPE_ID;
            }
            set
            {
                this.m_TRANSACTION_TYPE_ID = value;
            }
        }
    }
}

