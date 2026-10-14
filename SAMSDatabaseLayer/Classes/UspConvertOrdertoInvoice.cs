namespace SAMS.DatabaseLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using System;
    using System.Data;

    public class UspConvertOrdertoInvoice
    {
        private IDbConnection m_connection;
        private long m_CUSTOMER_ID;
        private int m_DISTRIBUTOR_ID = -2147483648;
        private DateTime m_DOCUMENT_DATE;
        private int m_DOCUMENT_TYPE_ID = -2147483648;
        private decimal m_NET_AMOUNT;
        private int m_ORDER_STATUS = -2147483648;
        private int m_PRINCIPAL_ID = -2147483648;
        private long m_SALE_ORDER_ID;
        private IDbTransaction m_transaction;
        private int m_USER_ID = -2147483648;
        private string sp_Name = " UspConvertOrdertoInvoice";

        public UspConvertOrdertoInvoice()
        {
            this.NET_AMOUNT = -79228162514264337593543950335M;
            this.m_DOCUMENT_DATE = Constants.DateNullValue;
            this.m_SALE_ORDER_ID = -9223372036854775808L;
            this.m_CUSTOMER_ID = -9223372036854775808L;
        }

        public bool ExecuteQuery()
        {
            bool flag;
            try
            {
                IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UspConvertOrdertoInvoice";
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
                cmd.CommandText = "UspConvertOrdertoInvoice";
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
                cmd.CommandText = "UspConvertOrdertoInvoice";
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
                cmd.CommandText = "UspConvertOrdertoInvoice";
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
                this.m_ORDER_STATUS = Convert.ToInt32(dr["ORDER_STATUS"]);
                this.m_PRINCIPAL_ID = Convert.ToInt32(dr["PRINCIPAL_ID"]);
                this.m_DOCUMENT_TYPE_ID = Convert.ToInt32(dr["DOCUMENT_TYPE_ID"]);
                this.m_USER_ID = Convert.ToInt32(dr["USER_ID"]);
                this.m_NET_AMOUNT = Convert.ToDecimal(dr["NET_AMOUNT"]);
                this.m_DOCUMENT_DATE = Convert.ToDateTime(dr["DOCUMENT_DATE"]);
                this.m_SALE_ORDER_ID = Convert.ToInt64(dr["SALE_ORDER_ID"]);
                this.m_CUSTOMER_ID = Convert.ToInt64(dr["CUSTOMER_ID"]);
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
            parameter.ParameterName = "@ORDER_STATUS";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_ORDER_STATUS == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_ORDER_STATUS;
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
            parameter.ParameterName = "@NET_AMOUNT";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
            if (this.m_NET_AMOUNT == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_NET_AMOUNT;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@DOCUMENT_DATE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
            if (this.m_DOCUMENT_DATE == Constants.DateNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_DOCUMENT_DATE;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@SALE_ORDER_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
            if (this.m_SALE_ORDER_ID == -9223372036854775808L)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_SALE_ORDER_ID;
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

        public DateTime DOCUMENT_DATE
        {
            get
            {
                return this.m_DOCUMENT_DATE;
            }
            set
            {
                this.m_DOCUMENT_DATE = value;
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

        public decimal NET_AMOUNT
        {
            get
            {
                return this.m_NET_AMOUNT;
            }
            set
            {
                this.m_NET_AMOUNT = value;
            }
        }

        public int ORDER_STATUS
        {
            get
            {
                return this.m_ORDER_STATUS;
            }
            set
            {
                this.m_ORDER_STATUS = value;
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

        public long SALE_ORDER_ID
        {
            get
            {
                return this.m_SALE_ORDER_ID;
            }
            set
            {
                this.m_SALE_ORDER_ID = value;
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

