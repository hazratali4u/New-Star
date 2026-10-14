namespace SAMS.DatabaseLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using System;
    using System.Data;

    public class spInsertSALE_INVOICE_TLP
    {
        private decimal m_AMOUNT;
        private IDbConnection m_connection;
        private int m_CUSTOMER_ID;
        private long m_CUSTOMER_TLP_PERSON_ID;
        private int m_DISTRIBUTOR_ID;
        private bool m_IS_ACTIVE;
        private DateTime m_LASTUPDATE_DATE;
        private decimal m_POINTS;
        private int m_QUANTITY;
        private int m_SALE_INVOICE_ID;
        private long m_SALE_INVOICE_TLP_ID;
        private int m_SKU_ID;
        private DateTime m_TIME_STAMP;
        private long m_TLP_PERSON_ID;
        private IDbTransaction m_transaction;
        private int m_USER_ID;
        private string sp_Name = " spInsertSALE_INVOICE_TLP";

        public bool ExecuteQuery()
        {
            bool flag;
            try
            {
                IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spInsertSALE_INVOICE_TLP";
                cmd.Connection = this.m_connection;
                if (this.m_transaction != null)
                {
                    cmd.Transaction = this.m_transaction;
                }
                this.GetParameterCollection(ref cmd);
                cmd.ExecuteNonQuery();
                this.m_SALE_INVOICE_TLP_ID = (long) ((IDataParameter) cmd.Parameters["@SALE_INVOICE_TLP_ID"]).Value;
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
                cmd.CommandText = "spInsertSALE_INVOICE_TLP";
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
                cmd.CommandText = "spInsertSALE_INVOICE_TLP";
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
                cmd.CommandText = "spInsertSALE_INVOICE_TLP";
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
                this.m_TLP_PERSON_ID = Convert.ToInt64(dr["TLP_PERSON_ID"]);
                this.m_CUSTOMER_TLP_PERSON_ID = Convert.ToInt64(dr["CUSTOMER_TLP_PERSON_ID"]);
                this.m_SALE_INVOICE_TLP_ID = Convert.ToInt64(dr["SALE_INVOICE_TLP_ID"]);
                this.m_IS_ACTIVE = Convert.ToBoolean(dr["IS_ACTIVE"]);
                this.m_TIME_STAMP = Convert.ToDateTime(dr["TIME_STAMP"]);
                this.m_LASTUPDATE_DATE = Convert.ToDateTime(dr["LASTUPDATE_DATE"]);
                this.m_AMOUNT = Convert.ToDecimal(dr["AMOUNT"]);
                this.m_POINTS = Convert.ToDecimal(dr["POINTS"]);
                this.m_SKU_ID = Convert.ToInt32(dr["SKU_ID"]);
                this.m_QUANTITY = Convert.ToInt32(dr["QUANTITY"]);
                this.m_USER_ID = Convert.ToInt32(dr["USER_ID"]);
                this.m_DISTRIBUTOR_ID = Convert.ToInt32(dr["DISTRIBUTOR_ID"]);
                this.m_CUSTOMER_ID = Convert.ToInt32(dr["CUSTOMER_ID"]);
                this.m_SALE_INVOICE_ID = Convert.ToInt32(dr["SALE_INVOICE_ID"]);
            }
        }

        public void GetParameterCollection(ref IDbCommand cmd)
        {
            IDataParameterCollection parameters = cmd.Parameters;
            IDataParameter parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@TLP_PERSON_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
            if (this.m_TLP_PERSON_ID == -9223372036854775808L)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_TLP_PERSON_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@CUSTOMER_TLP_PERSON_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
            if (this.m_CUSTOMER_TLP_PERSON_ID == -9223372036854775808L)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_CUSTOMER_TLP_PERSON_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@SALE_INVOICE_TLP_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
            parameter.Direction = ParameterDirection.Output;
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
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
            parameter.ParameterName = "@AMOUNT";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Decimal);
            if (this.m_AMOUNT == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_AMOUNT;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@POINTS";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Decimal);
            if (this.m_POINTS == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_POINTS;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@SKU_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_SKU_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_SKU_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@QUANTITY";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_QUANTITY == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_QUANTITY;
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
            parameter.ParameterName = "@SALE_INVOICE_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_SALE_INVOICE_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_SALE_INVOICE_ID;
            }
            parameters.Add(parameter);
        }

        public decimal AMOUNT
        {
            get
            {
                return this.m_AMOUNT;
            }
            set
            {
                this.m_AMOUNT = value;
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

        public long CUSTOMER_TLP_PERSON_ID
        {
            get
            {
                return this.m_CUSTOMER_TLP_PERSON_ID;
            }
            set
            {
                this.m_CUSTOMER_TLP_PERSON_ID = value;
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

        public decimal POINTS
        {
            get
            {
                return this.m_POINTS;
            }
            set
            {
                this.m_POINTS = value;
            }
        }

        public int QUANTITY
        {
            get
            {
                return this.m_QUANTITY;
            }
            set
            {
                this.m_QUANTITY = value;
            }
        }

        public int SALE_INVOICE_ID
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

        public long SALE_INVOICE_TLP_ID
        {
            get
            {
                return this.m_SALE_INVOICE_TLP_ID;
            }
        }

        public int SKU_ID
        {
            get
            {
                return this.m_SKU_ID;
            }
            set
            {
                this.m_SKU_ID = value;
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

        public long TLP_PERSON_ID
        {
            get
            {
                return this.m_TLP_PERSON_ID;
            }
            set
            {
                this.m_TLP_PERSON_ID = value;
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

