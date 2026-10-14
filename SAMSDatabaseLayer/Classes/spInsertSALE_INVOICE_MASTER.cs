namespace SAMS.DatabaseLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using System;
    using System.Data;

    public class spInsertSALE_INVOICE_MASTER
    {
        private long m_AREA_ID;
        private IDbConnection m_connection;
        private decimal m_CREDIT_AMOUNT;
        private decimal m_CURRENT_CREDIT_AMOUNT;
        private int m_DELIVERYMAN_ID;
        private int m_DISTRIBUTOR_ID;
        private DateTime m_DOCUMENT_DATE;
        private decimal m_EXTRA_DISCOUNT_AMOUNT;
        private decimal m_GST_AMOUNT;
        private decimal m_HALF_SCHEME;
        private bool m_IS_DELETED;
        private DateTime m_LASTUPDATE_DATE;
        private int m_LEGEND_ID;
        private int m_MANUAL_INVOICE_ID;
        private int m_ORDERBOOKER_ID;
        private byte m_POSTING;
        private int m_PRINCIPAL_ID;
        private long m_SALE_INVOICE_ID;
        private long m_SALE_ORDER_ID;
        private decimal m_SCHEME_AMOUNT;
        private decimal m_SED_AMOUNT;
        private long m_SOLD_TO;
        private decimal m_STANDARD_DISCOUNT_AMOUNT;
        private DateTime m_TIME_STAMP;
        private decimal m_TOTAL_AMOUNT;
        private decimal m_TOTAL_NET_AMOUNT;
        private int m_TOWN_ID;
        private IDbTransaction m_transaction;
        private decimal m_TST_AMOUNT;
        private int m_USER_ID;
        private string sp_Name = " spInsertSALE_INVOICE_MASTER";

        public bool ExecuteQuery()
        {
            bool flag;
            try
            {
                IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spInsertSALE_INVOICE_MASTER";
                cmd.Connection = this.m_connection;
                if (this.m_transaction != null)
                {
                    cmd.Transaction = this.m_transaction;
                }
                this.GetParameterCollection(ref cmd);
                cmd.ExecuteNonQuery();
                this.m_SALE_INVOICE_ID = (long) ((IDataParameter) cmd.Parameters["@SALE_INVOICE_ID"]).Value;
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
                cmd.CommandText = "spInsertSALE_INVOICE_MASTER";
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
                cmd.CommandText = "spInsertSALE_INVOICE_MASTER";
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
                cmd.CommandText = "spInsertSALE_INVOICE_MASTER";
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
                this.m_TOWN_ID = Convert.ToInt32(dr["TOWN_ID"]);
                this.m_PRINCIPAL_ID = Convert.ToInt32(dr["PRINCIPAL_ID"]);
                this.m_ORDERBOOKER_ID = Convert.ToInt32(dr["ORDERBOOKER_ID"]);
                this.m_DELIVERYMAN_ID = Convert.ToInt32(dr["DELIVERYMAN_ID"]);
                this.m_LEGEND_ID = Convert.ToInt32(dr["LEGEND_ID"]);
                this.m_USER_ID = Convert.ToInt32(dr["USER_ID"]);
                this.m_TOTAL_AMOUNT = Convert.ToDecimal(dr["TOTAL_AMOUNT"]);
                this.m_TOTAL_NET_AMOUNT = Convert.ToDecimal(dr["TOTAL_NET_AMOUNT"]);
                this.m_EXTRA_DISCOUNT_AMOUNT = Convert.ToDecimal(dr["EXTRA_DISCOUNT_AMOUNT"]);
                this.m_STANDARD_DISCOUNT_AMOUNT = Convert.ToDecimal(dr["STANDARD_DISCOUNT_AMOUNT"]);
                this.m_GST_AMOUNT = Convert.ToDecimal(dr["GST_AMOUNT"]);
                this.m_SCHEME_AMOUNT = Convert.ToDecimal(dr["SCHEME_AMOUNT"]);
                this.m_CURRENT_CREDIT_AMOUNT = Convert.ToDecimal(dr["CURRENT_CREDIT_AMOUNT"]);
                this.m_CREDIT_AMOUNT = Convert.ToDecimal(dr["CREDIT_AMOUNT"]);
                this.m_TST_AMOUNT = Convert.ToDecimal(dr["TST_AMOUNT"]);
                this.m_SED_AMOUNT = Convert.ToDecimal(dr["SED_AMOUNT"]);
                this.m_HALF_SCHEME = Convert.ToDecimal(dr["HALF_SCHEME"]);
                this.m_DOCUMENT_DATE = Convert.ToDateTime(dr["DOCUMENT_DATE"]);
                this.m_TIME_STAMP = Convert.ToDateTime(dr["TIME_STAMP"]);
                this.m_LASTUPDATE_DATE = Convert.ToDateTime(dr["LASTUPDATE_DATE"]);
                this.m_IS_DELETED = Convert.ToBoolean(dr["IS_DELETED"]);
                this.m_AREA_ID = Convert.ToInt64(dr["AREA_ID"]);
                this.m_SOLD_TO = Convert.ToInt64(dr["SOLD_TO"]);
                this.m_SALE_ORDER_ID = Convert.ToInt64(dr["SALE_ORDER_ID"]);
                this.m_SALE_INVOICE_ID = Convert.ToInt64(dr["SALE_INVOICE_ID"]);
                this.m_MANUAL_INVOICE_ID = Convert.ToInt32(dr["MANUAL_INVOICE_ID"]);
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
            parameter.ParameterName = "@ORDERBOOKER_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_ORDERBOOKER_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_ORDERBOOKER_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@DELIVERYMAN_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_DELIVERYMAN_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_DELIVERYMAN_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@LEGEND_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_LEGEND_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_LEGEND_ID;
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
            parameter.ParameterName = "@SCHEME_AMOUNT";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
            if (this.m_SCHEME_AMOUNT == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_SCHEME_AMOUNT;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@CURRENT_CREDIT_AMOUNT";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
            if (this.m_CURRENT_CREDIT_AMOUNT == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_CURRENT_CREDIT_AMOUNT;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@CREDIT_AMOUNT";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
            if (this.m_CREDIT_AMOUNT == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_CREDIT_AMOUNT;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@TST_AMOUNT";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
            if (this.m_TST_AMOUNT == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_TST_AMOUNT;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@SED_AMOUNT";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
            if (this.m_SED_AMOUNT == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_SED_AMOUNT;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@HALF_SCHEME";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
            if (this.m_HALF_SCHEME == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_HALF_SCHEME;
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
            parameter.ParameterName = "@IS_DELETED";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
            parameter.Value = this.m_IS_DELETED;
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@AREA_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
            if (this.m_AREA_ID == -9223372036854775808L)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_AREA_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@SOLD_TO";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
            if (this.m_SOLD_TO == -9223372036854775808L)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_SOLD_TO;
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
            parameter.ParameterName = "@SALE_INVOICE_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
            parameter.Direction = ParameterDirection.Output;
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@MANUAL_INVOICE_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
            if (this.m_MANUAL_INVOICE_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_MANUAL_INVOICE_ID;
            }
            parameters.Add(parameter);
        }

        public long AREA_ID
        {
            get
            {
                return this.m_AREA_ID;
            }
            set
            {
                this.m_AREA_ID = value;
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

        public decimal CREDIT_AMOUNT
        {
            get
            {
                return this.m_CREDIT_AMOUNT;
            }
            set
            {
                this.m_CREDIT_AMOUNT = value;
            }
        }

        public decimal CURRENT_CREDIT_AMOUNT
        {
            get
            {
                return this.m_CURRENT_CREDIT_AMOUNT;
            }
            set
            {
                this.m_CURRENT_CREDIT_AMOUNT = value;
            }
        }

        public int DELIVERYMAN_ID
        {
            get
            {
                return this.m_DELIVERYMAN_ID;
            }
            set
            {
                this.m_DELIVERYMAN_ID = value;
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

        public decimal HALF_SCHEME
        {
            get
            {
                return this.m_HALF_SCHEME;
            }
            set
            {
                this.m_HALF_SCHEME = value;
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

        public int LEGEND_ID
        {
            get
            {
                return this.m_LEGEND_ID;
            }
            set
            {
                this.m_LEGEND_ID = value;
            }
        }

        public int MANUAL_INVOICE_ID
        {
            get
            {
                return this.m_MANUAL_INVOICE_ID;
            }
            set
            {
                this.m_MANUAL_INVOICE_ID = value;
            }
        }

        public int ORDERBOOKER_ID
        {
            get
            {
                return this.m_ORDERBOOKER_ID;
            }
            set
            {
                this.m_ORDERBOOKER_ID = value;
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

        public long SALE_INVOICE_ID
        {
            get
            {
                return this.m_SALE_INVOICE_ID;
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

        public decimal SCHEME_AMOUNT
        {
            get
            {
                return this.m_SCHEME_AMOUNT;
            }
            set
            {
                this.m_SCHEME_AMOUNT = value;
            }
        }

        public decimal SED_AMOUNT
        {
            get
            {
                return this.m_SED_AMOUNT;
            }
            set
            {
                this.m_SED_AMOUNT = value;
            }
        }

        public long SOLD_TO
        {
            get
            {
                return this.m_SOLD_TO;
            }
            set
            {
                this.m_SOLD_TO = value;
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

        public decimal TST_AMOUNT
        {
            get
            {
                return this.m_TST_AMOUNT;
            }
            set
            {
                this.m_TST_AMOUNT = value;
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

