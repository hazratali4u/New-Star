namespace SAMS.DatabaseLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using System;
    using System.Data;

    public class spInsertDTSKU_PRICES
    {
        private IDbConnection m_connection;
        private DateTime m_DATE_EFFECTED;
        private DateTime m_DATE_EXPIRE;
        private decimal m_DISTRIBUTOR_PRICE;
        private string m_IP_ADDRESS;
        private int m_ISCURRENT;
        private DateTime m_LASTUPDATE_DATE;
        private decimal m_RETAIL_PRICE;
        private int m_SKU_ID;
        private int m_SKU_PRICE_ID;
        private decimal m_TAX_PRICE;
        private DateTime m_TIME_STAMP;
        private decimal m_TRADE_PRICE;
        private IDbTransaction m_transaction;
        private int m_UOM_ID;
        private string sp_Name = " spInsertDTSKU_PRICES";

        public bool ExecuteQuery()
        {
            try
            {
                IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spInsertDTSKU_PRICES";
                cmd.Connection = this.m_connection;
                if (this.m_transaction != null)
                {
                    cmd.Transaction = this.m_transaction;
                }
                this.GetParameterCollection(ref cmd);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception exception)
            {
                if (!exception.Message.StartsWith("Violation of PRIMARY KEY constraint"))
                {
                    throw exception;
                }
                return false;
            }
        }

        public IDataReader ExecuteReader()
        {
            IDataReader reader2;
            try
            {
                IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spInsertDTSKU_PRICES";
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
                cmd.CommandText = "spInsertDTSKU_PRICES";
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
                cmd.CommandText = "spInsertDTSKU_PRICES";
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
                this.m_DATE_EXPIRE = Convert.ToDateTime(dr["DATE_EXPIRE"]);
                this.m_TIME_STAMP = Convert.ToDateTime(dr["TIME_STAMP"]);
                this.m_LASTUPDATE_DATE = Convert.ToDateTime(dr["LASTUPDATE_DATE"]);
                this.m_DATE_EFFECTED = Convert.ToDateTime(dr["DATE_EFFECTED"]);
                this.m_SKU_PRICE_ID = Convert.ToInt32(dr["SKU_PRICE_ID"]);
                this.m_SKU_ID = Convert.ToInt32(dr["SKU_ID"]);
                this.m_UOM_ID = Convert.ToInt32(dr["UOM_ID"]);
                this.m_ISCURRENT = Convert.ToInt32(dr["ISCURRENT"]);
                this.m_TAX_PRICE = Convert.ToDecimal(dr["TAX_PRICE"]);
                this.m_DISTRIBUTOR_PRICE = Convert.ToDecimal(dr["DISTRIBUTOR_PRICE"]);
                this.m_TRADE_PRICE = Convert.ToDecimal(dr["TRADE_PRICE"]);
                this.m_RETAIL_PRICE = Convert.ToDecimal(dr["RETAIL_PRICE"]);
                this.m_IP_ADDRESS = Convert.ToString(dr["IP_ADDRESS"]);
            }
        }

        public void GetParameterCollection(ref IDbCommand cmd)
        {
            IDataParameterCollection parameters = cmd.Parameters;
            IDataParameter parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@DATE_EXPIRE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
            if (this.m_DATE_EXPIRE == Constants.DateNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_DATE_EXPIRE;
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
            parameter.ParameterName = "@DATE_EFFECTED";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
            if (this.m_DATE_EFFECTED == Constants.DateNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_DATE_EFFECTED;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@SKU_PRICE_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_SKU_PRICE_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_SKU_PRICE_ID;
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
            parameter.ParameterName = "@UOM_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_UOM_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_UOM_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@ISCURRENT";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_ISCURRENT == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_ISCURRENT;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@TAX_PRICE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
            if (this.m_TAX_PRICE == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_TAX_PRICE;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@DISTRIBUTOR_PRICE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
            if (this.m_DISTRIBUTOR_PRICE == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_DISTRIBUTOR_PRICE;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@TRADE_PRICE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
            if (this.m_TRADE_PRICE == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_TRADE_PRICE;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@RETAIL_PRICE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
            if (this.m_RETAIL_PRICE == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_RETAIL_PRICE;
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

        public DateTime DATE_EFFECTED
        {
            get
            {
                return this.m_DATE_EFFECTED;
            }
            set
            {
                this.m_DATE_EFFECTED = value;
            }
        }

        public DateTime DATE_EXPIRE
        {
            get
            {
                return this.m_DATE_EXPIRE;
            }
            set
            {
                this.m_DATE_EXPIRE = value;
            }
        }

        public decimal DISTRIBUTOR_PRICE
        {
            get
            {
                return this.m_DISTRIBUTOR_PRICE;
            }
            set
            {
                this.m_DISTRIBUTOR_PRICE = value;
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

        public int ISCURRENT
        {
            get
            {
                return this.m_ISCURRENT;
            }
            set
            {
                this.m_ISCURRENT = value;
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

        public decimal RETAIL_PRICE
        {
            get
            {
                return this.m_RETAIL_PRICE;
            }
            set
            {
                this.m_RETAIL_PRICE = value;
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

        public int SKU_PRICE_ID
        {
            get
            {
                return this.m_SKU_PRICE_ID;
            }
            set
            {
                this.m_SKU_PRICE_ID = value;
            }
        }

        public decimal TAX_PRICE
        {
            get
            {
                return this.m_TAX_PRICE;
            }
            set
            {
                this.m_TAX_PRICE = value;
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

        public decimal TRADE_PRICE
        {
            get
            {
                return this.m_TRADE_PRICE;
            }
            set
            {
                this.m_TRADE_PRICE = value;
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

        public int UOM_ID
        {
            get
            {
                return this.m_UOM_ID;
            }
            set
            {
                this.m_UOM_ID = value;
            }
        }
    }
}

