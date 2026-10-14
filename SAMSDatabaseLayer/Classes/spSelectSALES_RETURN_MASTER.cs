namespace SAMS.DatabaseLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using System;
    using System.Data;

    public class spSelectSALES_RETURN_MASTER
    {
        private IDbConnection m_connection;
        private long m_CUSTOMER_ID;
        private int m_DISTRIBUTOR_ID;
        private DateTime m_DOCUMENT_DATE;
        private decimal m_EXTRA_DISCOUNT_AMOUNT;
        private decimal m_GST_AMOUNT;
        private DateTime m_LASTUPDATE_DATE;
        private long m_SALE_INVOICE_ID;
        private long m_SALES_RETURN_ID;
        private decimal m_STANDARD_DISCOUNT_AMOUNT;
        private DateTime m_TIME_STAMP;
        private decimal m_TOTAL_AMOUNT;
        private decimal m_TOTAL_CLAIM_AMOUNT;
        private decimal m_TOTAL_NET_AMOUNT;
        private IDbTransaction m_transaction;
        private string sp_Name = " spSelectSALES_RETURN_MASTER";

        public bool ExecuteQuery()
        {
            bool flag;
            try
            {
                IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spSelectSALES_RETURN_MASTER";
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
                cmd.CommandText = "spSelectSALES_RETURN_MASTER";
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
                cmd.CommandText = "spSelectSALES_RETURN_MASTER";
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
                cmd.CommandText = "spSelectSALES_RETURN_MASTER";
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
                this.m_SALES_RETURN_ID = Convert.ToInt64(dr["SALES_RETURN_ID"]);
                this.m_CUSTOMER_ID = Convert.ToInt64(dr["CUSTOMER_ID"]);
                this.m_SALE_INVOICE_ID = Convert.ToInt64(dr["SALE_INVOICE_ID"]);
                this.m_DOCUMENT_DATE = Convert.ToDateTime(dr["DOCUMENT_DATE"]);
                this.m_TIME_STAMP = Convert.ToDateTime(dr["TIME_STAMP"]);
                this.m_LASTUPDATE_DATE = Convert.ToDateTime(dr["LASTUPDATE_DATE"]);
                this.m_DISTRIBUTOR_ID = Convert.ToInt32(dr["DISTRIBUTOR_ID"]);
                this.m_STANDARD_DISCOUNT_AMOUNT = Convert.ToDecimal(dr["STANDARD_DISCOUNT_AMOUNT"]);
                this.m_TOTAL_CLAIM_AMOUNT = Convert.ToDecimal(dr["TOTAL_CLAIM_AMOUNT"]);
                this.m_GST_AMOUNT = Convert.ToDecimal(dr["GST_AMOUNT"]);
                this.m_TOTAL_AMOUNT = Convert.ToDecimal(dr["TOTAL_AMOUNT"]);
                this.m_TOTAL_NET_AMOUNT = Convert.ToDecimal(dr["TOTAL_NET_AMOUNT"]);
                this.m_EXTRA_DISCOUNT_AMOUNT = Convert.ToDecimal(dr["EXTRA_DISCOUNT_AMOUNT"]);
            }
        }

        public void GetParameterCollection(ref IDbCommand cmd)
        {
            IDataParameterCollection parameters = cmd.Parameters;
            IDataParameter parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@SALES_RETURN_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
            if (this.m_SALES_RETURN_ID == -9223372036854775808L)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_SALES_RETURN_ID;
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
            parameter.ParameterName = "@SALE_INVOICE_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
            if (this.m_SALE_INVOICE_ID == -9223372036854775808L)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_SALE_INVOICE_ID;
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
            parameter.ParameterName = "@STANDARD_DISCOUNT_AMOUNT";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
            if (this.m_STANDARD_DISCOUNT_AMOUNT == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_STANDARD_DISCOUNT_AMOUNT;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@TOTAL_CLAIM_AMOUNT";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
            if (this.m_TOTAL_CLAIM_AMOUNT == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_TOTAL_CLAIM_AMOUNT;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@GST_AMOUNT";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
            if (this.m_GST_AMOUNT == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_GST_AMOUNT;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@TOTAL_AMOUNT";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
            if (this.m_TOTAL_AMOUNT == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_TOTAL_AMOUNT;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@TOTAL_NET_AMOUNT";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
            if (this.m_TOTAL_NET_AMOUNT == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_TOTAL_NET_AMOUNT;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@EXTRA_DISCOUNT_AMOUNT";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
            if (this.m_EXTRA_DISCOUNT_AMOUNT == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_EXTRA_DISCOUNT_AMOUNT;
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

        public decimal EXTRA_DISCOUNT_AMOUNT
        {
            get
            {
                return this.m_EXTRA_DISCOUNT_AMOUNT;
            }
            set
            {
                this.m_EXTRA_DISCOUNT_AMOUNT = value;
            }
        }

        public decimal GST_AMOUNT
        {
            get
            {
                return this.m_GST_AMOUNT;
            }
            set
            {
                this.m_GST_AMOUNT = value;
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

        public long SALE_INVOICE_ID
        {
            get
            {
                return this.m_SALE_INVOICE_ID;
            }
            set
            {
                this.m_SALE_INVOICE_ID = value;
            }
        }

        public long SALES_RETURN_ID
        {
            get
            {
                return this.m_SALES_RETURN_ID;
            }
            set
            {
                this.m_SALES_RETURN_ID = value;
            }
        }

        public decimal STANDARD_DISCOUNT_AMOUNT
        {
            get
            {
                return this.m_STANDARD_DISCOUNT_AMOUNT;
            }
            set
            {
                this.m_STANDARD_DISCOUNT_AMOUNT = value;
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

        public decimal TOTAL_AMOUNT
        {
            get
            {
                return this.m_TOTAL_AMOUNT;
            }
            set
            {
                this.m_TOTAL_AMOUNT = value;
            }
        }

        public decimal TOTAL_CLAIM_AMOUNT
        {
            get
            {
                return this.m_TOTAL_CLAIM_AMOUNT;
            }
            set
            {
                this.m_TOTAL_CLAIM_AMOUNT = value;
            }
        }

        public decimal TOTAL_NET_AMOUNT
        {
            get
            {
                return this.m_TOTAL_NET_AMOUNT;
            }
            set
            {
                this.m_TOTAL_NET_AMOUNT = value;
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

