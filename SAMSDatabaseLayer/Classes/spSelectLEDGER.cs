namespace SAMS.DatabaseLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using System;
    using System.Data;

    public class spSelectLEDGER
    {
        private long m_ACCOUNT_HEAD_ID;
        private string m_CHEQUE_NO;
        private DateTime m_CHQUE_DATE;
        private IDbConnection m_connection;
        private decimal m_CREDIT;
        private int m_CUSTOMER_ID = -2147483648;
        private decimal m_DEBIT;
        private int m_DISTRIBUTOR_ID = -2147483648;
        private long m_DOCUMENT_NO;
        private int m_DOCUMENT_TYPE_ID = -2147483648;
        private DateTime m_LEDGER_DATE;
        private long m_LEDGER_ID;
        private byte m_POSTING;
        private int m_PRINCIPAL_ID = -2147483648;
        private string m_REMARKS;
        private string m_SLIP_NO;
        private DateTime m_TIME_STAMP;
        private IDbTransaction m_transaction;
        private int m_USER_ID = -2147483648;
        private long m_VOUCHER_NO;
        private int m_VOUCHER_TYPE_ID = -2147483648;
        private string sp_Name = " spSelectLEDGER";

        public spSelectLEDGER()
        {
            this.DEBIT = -79228162514264337593543950335M;
            this.CREDIT = -79228162514264337593543950335M;
            this.m_LEDGER_DATE = Constants.DateNullValue;
            this.m_TIME_STAMP = Constants.DateNullValue;
            this.m_CHQUE_DATE = Constants.DateNullValue;
            this.m_LEDGER_ID = -9223372036854775808L;
            this.m_ACCOUNT_HEAD_ID = -9223372036854775808L;
            this.m_VOUCHER_NO = -9223372036854775808L;
            this.m_DOCUMENT_NO = -9223372036854775808L;
            this.m_REMARKS = null;
            this.m_CHEQUE_NO = null;
            this.m_SLIP_NO = null;
        }

        public bool ExecuteQuery()
        {
            bool flag;
            try
            {
                IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spSelectLEDGER";
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
                cmd.CommandText = "spSelectLEDGER";
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
                cmd.CommandText = "spSelectLEDGER";
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
                cmd.CommandText = "spSelectLEDGER";
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
                this.m_POSTING = Convert.ToByte(dr["POSTING"]);
                this.m_DISTRIBUTOR_ID = Convert.ToInt32(dr["DISTRIBUTOR_ID"]);
                this.m_VOUCHER_TYPE_ID = Convert.ToInt32(dr["VOUCHER_TYPE_ID"]);
                this.m_PRINCIPAL_ID = Convert.ToInt32(dr["PRINCIPAL_ID"]);
                this.m_CUSTOMER_ID = Convert.ToInt32(dr["CUSTOMER_ID"]);
                this.m_DOCUMENT_TYPE_ID = Convert.ToInt32(dr["DOCUMENT_TYPE_ID"]);
                this.m_USER_ID = Convert.ToInt32(dr["USER_ID"]);
                this.m_DEBIT = Convert.ToDecimal(dr["DEBIT"]);
                this.m_CREDIT = Convert.ToDecimal(dr["CREDIT"]);
                this.m_LEDGER_DATE = Convert.ToDateTime(dr["LEDGER_DATE"]);
                this.m_TIME_STAMP = Convert.ToDateTime(dr["TIME_STAMP"]);
                this.m_CHQUE_DATE = Convert.ToDateTime(dr["CHQUE_DATE"]);
                this.m_LEDGER_ID = Convert.ToInt64(dr["LEDGER_ID"]);
                this.m_ACCOUNT_HEAD_ID = Convert.ToInt64(dr["ACCOUNT_HEAD_ID"]);
                this.m_VOUCHER_NO = Convert.ToInt64(dr["VOUCHER_NO"]);
                this.m_DOCUMENT_NO = Convert.ToInt64(dr["DOCUMENT_NO"]);
                this.m_REMARKS = Convert.ToString(dr["REMARKS"]);
                this.m_CHEQUE_NO = Convert.ToString(dr["CHEQUE_NO"]);
                this.m_SLIP_NO = Convert.ToString(dr["SLIP_NO"]);
            }
        }

        public void GetParameterCollection(ref IDbCommand cmd)
        {
            IDataParameterCollection parameters = cmd.Parameters;
            IDataParameter parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@POSTING";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.TinyInt);
            if (this.m_POSTING == 0)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_POSTING;
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
            parameter.ParameterName = "@VOUCHER_TYPE_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_VOUCHER_TYPE_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_VOUCHER_TYPE_ID;
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
            parameter.ParameterName = "@CUSTOMER_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_CUSTOMER_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_CUSTOMER_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@DOCUMENT_TYPE_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_DOCUMENT_TYPE_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_DOCUMENT_TYPE_ID;
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
            parameter.ParameterName = "@CHQUE_DATE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
            if (this.m_CHQUE_DATE == Constants.DateNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_CHQUE_DATE;
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
            parameter.ParameterName = "@VOUCHER_NO";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
            if (this.m_VOUCHER_NO == -9223372036854775808L)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_VOUCHER_NO;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@DOCUMENT_NO";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
            if (this.m_DOCUMENT_NO == -9223372036854775808L)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_DOCUMENT_NO;
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
            parameter.ParameterName = "@SLIP_NO";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_SLIP_NO == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_SLIP_NO;
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

        public DateTime CHQUE_DATE
        {
            get
            {
                return this.m_CHQUE_DATE;
            }
            set
            {
                this.m_CHQUE_DATE = value;
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

        public int CUSTOMER_ID
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

        public long DOCUMENT_NO
        {
            get
            {
                return this.m_DOCUMENT_NO;
            }
            set
            {
                this.m_DOCUMENT_NO = value;
            }
        }

        public int DOCUMENT_TYPE_ID
        {
            get
            {
                return this.m_DOCUMENT_TYPE_ID;
            }
            set
            {
                this.m_DOCUMENT_TYPE_ID = value;
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

        public byte POSTING
        {
            get
            {
                return this.m_POSTING;
            }
            set
            {
                this.m_POSTING = value;
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

        public string SLIP_NO
        {
            get
            {
                return this.m_SLIP_NO;
            }
            set
            {
                this.m_SLIP_NO = value;
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

        public long VOUCHER_NO
        {
            get
            {
                return this.m_VOUCHER_NO;
            }
            set
            {
                this.m_VOUCHER_NO = value;
            }
        }

        public int VOUCHER_TYPE_ID
        {
            get
            {
                return this.m_VOUCHER_TYPE_ID;
            }
            set
            {
                this.m_VOUCHER_TYPE_ID = value;
            }
        }
    }
}

