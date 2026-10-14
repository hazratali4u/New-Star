namespace SAMS.DatabaseLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using System;
    using System.Data;

    public class spInsertSKU_PRICES
    {
        private int m_COMPANY_ID = -2147483648;
        private IDbConnection m_connection;
        private DateTime m_DATE_EFFECTED = Constants.DateNullValue;
        private decimal m_DISTRIBUTOR_DISCOUNT;
        private decimal m_DISTRIBUTOR_PRICE;
        private int m_ISCURRENT = -2147483648;
        private DateTime m_LASTUPDATE_DATE = Constants.DateNullValue;
        private decimal m_RETAIL_PRICE;
        private int m_SKU_ID = -2147483648;
        private int m_SKU_PRICE_ID = -2147483648;
        private decimal m_TAX_PRICE;
        private DateTime m_TIME_STAMP = Constants.DateNullValue;
        private decimal m_TRADE_PRICE;
        private IDbTransaction m_transaction;
        private int m_UOM_ID = -2147483648;
        private string sp_Name = " spInsertSKU_PRICES";

        public spInsertSKU_PRICES()
        {
            this.DISTRIBUTOR_DISCOUNT = -79228162514264337593543950335M;
            this.TAX_PRICE = -79228162514264337593543950335M;
            this.DISTRIBUTOR_PRICE = -79228162514264337593543950335M;
            this.TRADE_PRICE = -79228162514264337593543950335M;
            this.RETAIL_PRICE = -79228162514264337593543950335M;
        }

        public bool ExecuteQuery()
        {
            bool flag;
            try
            {
                IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spInsertSKU_PRICES";
                cmd.Connection = this.m_connection;
                if (this.m_transaction != null)
                {
                    cmd.Transaction = this.m_transaction;
                }
                this.GetParameterCollection(ref cmd);
                cmd.ExecuteNonQuery();
                this.m_SKU_PRICE_ID = (int) ((IDataParameter) cmd.Parameters["@SKU_PRICE_ID"]).Value;
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
                cmd.CommandText = "spInsertSKU_PRICES";
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
                cmd.CommandText = "spInsertSKU_PRICES";
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
                cmd.CommandText = "spInsertSKU_PRICES";
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
                this.m_TIME_STAMP = Convert.ToDateTime(dr["TIME_STAMP"]);
                this.m_LASTUPDATE_DATE = Convert.ToDateTime(dr["LASTUPDATE_DATE"]);
                this.m_DATE_EFFECTED = Convert.ToDateTime(dr["DATE_EFFECTED"]);
                this.m_UOM_ID = Convert.ToInt32(dr["UOM_ID"]);
                this.m_SKU_PRICE_ID = Convert.ToInt32(dr["SKU_PRICE_ID"]);
                this.m_COMPANY_ID = Convert.ToInt32(dr["COMPANY_ID"]);
                this.m_SKU_ID = Convert.ToInt32(dr["SKU_ID"]);
                this.m_ISCURRENT = Convert.ToInt32(dr["ISCURRENT"]);
                this.m_DISTRIBUTOR_DISCOUNT = Convert.ToDecimal(dr["DISTRIBUTOR_DISCOUNT"]);
                this.m_TAX_PRICE = Convert.ToDecimal(dr["TAX_PRICE"]);
                this.m_DISTRIBUTOR_PRICE = Convert.ToDecimal(dr["DISTRIBUTOR_PRICE"]);
                this.m_TRADE_PRICE = Convert.ToDecimal(dr["TRADE_PRICE"]);
                this.m_RETAIL_PRICE = Convert.ToDecimal(dr["RETAIL_PRICE"]);
            }
        }

        public void GetParameterCollection(ref IDbCommand cmd)
        {
            IDataParameterCollection parameters = cmd.Parameters;
            IDataParameter parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
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
            parameter.ParameterName = "@SKU_PRICE_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            parameter.Direction = ParameterDirection.Output;
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@COMPANY_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_COMPANY_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_COMPANY_ID;
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
            parameter.ParameterName = "@DISTRIBUTOR_DISCOUNT";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
            if (this.m_DISTRIBUTOR_DISCOUNT == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_DISTRIBUTOR_DISCOUNT;
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
        }

        public int COMPANY_ID
        {
            get
            {
                return this.m_COMPANY_ID;
            }
            set
            {
                this.m_COMPANY_ID = value;
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

        public decimal DISTRIBUTOR_DISCOUNT
        {
            get
            {
                return this.m_DISTRIBUTOR_DISCOUNT;
            }
            set
            {
                this.m_DISTRIBUTOR_DISCOUNT = value;
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

