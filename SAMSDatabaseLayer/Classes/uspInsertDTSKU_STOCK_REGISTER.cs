namespace SAMS.DatabaseLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using System;
    using System.Data;

    public class uspInsertDTSKU_STOCK_REGISTER
    {
        private int m_CLOSING_STOCK;
        private IDbConnection m_connection;
        private int m_DAMAGED_STOCK;
        private int m_DAMAGED_STOCK_RETURN;
        private int m_DISPOSED;
        private int m_DISTRIBUTOR_ID;
        private int m_EXCESS;
        private int m_FREE_STOCK;
        private int m_INITIAL;
        private int m_OPENING_STOCK;
        private int m_PURCHASE_RETURN;
        private int m_PURCHASED;
        private decimal m_RateDifference;
        private decimal m_RETAIL_PRICE;
        private int m_SALE_RETURN;
        private int m_SALED;
        private int m_SHORT;
        private int m_SKU_ID;
        private DateTime m_STOCK_DATE;
        private decimal m_TAX_PRICE;
        private decimal m_TRADE_PRICE;
        private IDbTransaction m_transaction;
        private string sp_Name = " uspInsertDTSKU_STOCK_REGISTER";

        public bool ExecuteQuery()
        {
            bool flag;
            try
            {
                IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "uspInsertDTSKU_STOCK_REGISTER";
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
                cmd.CommandText = "uspInsertDTSKU_STOCK_REGISTER";
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
                cmd.CommandText = "uspInsertDTSKU_STOCK_REGISTER";
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
                cmd.CommandText = "uspInsertDTSKU_STOCK_REGISTER";
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
                this.m_STOCK_DATE = Convert.ToDateTime(dr["STOCK_DATE"]);
                this.m_SHORT = Convert.ToInt32(dr["SHORT"]);
                this.m_EXCESS = Convert.ToInt32(dr["EXCESS"]);
                this.m_INITIAL = Convert.ToInt32(dr["INITIAL"]);
                this.m_SALE_RETURN = Convert.ToInt32(dr["SALE_RETURN"]);
                this.m_FREE_STOCK = Convert.ToInt32(dr["FREE_STOCK"]);
                this.m_DISPOSED = Convert.ToInt32(dr["DISPOSED"]);
                this.m_SALED = Convert.ToInt32(dr["SALED"]);
                this.m_PURCHASE_RETURN = Convert.ToInt32(dr["PURCHASE_RETURN"]);
                this.m_PURCHASED = Convert.ToInt32(dr["PURCHASED"]);
                this.m_DAMAGED_STOCK = Convert.ToInt32(dr["DAMAGED_STOCK"]);
                this.m_DAMAGED_STOCK_RETURN = Convert.ToInt32(dr["DAMAGED_STOCK_RETURN"]);
                this.m_CLOSING_STOCK = Convert.ToInt32(dr["CLOSING_STOCK"]);
                this.m_SKU_ID = Convert.ToInt32(dr["SKU_ID"]);
                this.m_DISTRIBUTOR_ID = Convert.ToInt32(dr["DISTRIBUTOR_ID"]);
                this.m_OPENING_STOCK = Convert.ToInt32(dr["OPENING_STOCK"]);
                this.m_RateDifference = Convert.ToDecimal(dr["RateDifference"]);
                this.m_TRADE_PRICE = Convert.ToDecimal(dr["TRADE_PRICE"]);
                this.m_RETAIL_PRICE = Convert.ToDecimal(dr["RETAIL_PRICE"]);
                this.m_TAX_PRICE = Convert.ToDecimal(dr["TAX_PRICE"]);
            }
        }

        public void GetParameterCollection(ref IDbCommand cmd)
        {
            IDataParameterCollection parameters = cmd.Parameters;
            IDataParameter parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@STOCK_DATE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
            if (this.m_STOCK_DATE == Constants.DateNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_STOCK_DATE;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@SHORT";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_SHORT == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_SHORT;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@EXCESS";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_EXCESS == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_EXCESS;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@INITIAL";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_INITIAL == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_INITIAL;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@SALE_RETURN";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_SALE_RETURN == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_SALE_RETURN;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@FREE_STOCK";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_FREE_STOCK == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_FREE_STOCK;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@DISPOSED";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_DISPOSED == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_DISPOSED;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@SALED";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_SALED == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_SALED;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@PURCHASE_RETURN";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_PURCHASE_RETURN == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_PURCHASE_RETURN;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@PURCHASED";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_PURCHASED == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_PURCHASED;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@DAMAGED_STOCK";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_DAMAGED_STOCK == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_DAMAGED_STOCK;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@DAMAGED_STOCK_RETURN";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_DAMAGED_STOCK_RETURN == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_DAMAGED_STOCK_RETURN;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@CLOSING_STOCK";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_CLOSING_STOCK == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_CLOSING_STOCK;
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
            parameter.ParameterName = "@OPENING_STOCK";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_OPENING_STOCK == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_OPENING_STOCK;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@RateDifference";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
            if (this.m_RateDifference == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_RateDifference;
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
        }

        public int CLOSING_STOCK
        {
            get
            {
                return this.m_CLOSING_STOCK;
            }
            set
            {
                this.m_CLOSING_STOCK = value;
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

        public int DAMAGED_STOCK
        {
            get
            {
                return this.m_DAMAGED_STOCK;
            }
            set
            {
                this.m_DAMAGED_STOCK = value;
            }
        }

        public int DAMAGED_STOCK_RETURN
        {
            get
            {
                return this.m_DAMAGED_STOCK_RETURN;
            }
            set
            {
                this.m_DAMAGED_STOCK_RETURN = value;
            }
        }

        public int DISPOSED
        {
            get
            {
                return this.m_DISPOSED;
            }
            set
            {
                this.m_DISPOSED = value;
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

        public int EXCESS
        {
            get
            {
                return this.m_EXCESS;
            }
            set
            {
                this.m_EXCESS = value;
            }
        }

        public int FREE_STOCK
        {
            get
            {
                return this.m_FREE_STOCK;
            }
            set
            {
                this.m_FREE_STOCK = value;
            }
        }

        public int INITIAL
        {
            get
            {
                return this.m_INITIAL;
            }
            set
            {
                this.m_INITIAL = value;
            }
        }

        public int OPENING_STOCK
        {
            get
            {
                return this.m_OPENING_STOCK;
            }
            set
            {
                this.m_OPENING_STOCK = value;
            }
        }

        public int PURCHASE_RETURN
        {
            get
            {
                return this.m_PURCHASE_RETURN;
            }
            set
            {
                this.m_PURCHASE_RETURN = value;
            }
        }

        public int PURCHASED
        {
            get
            {
                return this.m_PURCHASED;
            }
            set
            {
                this.m_PURCHASED = value;
            }
        }

        public decimal RateDifference
        {
            get
            {
                return this.m_RateDifference;
            }
            set
            {
                this.m_RateDifference = value;
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

        public int SALE_RETURN
        {
            get
            {
                return this.m_SALE_RETURN;
            }
            set
            {
                this.m_SALE_RETURN = value;
            }
        }

        public int SALED
        {
            get
            {
                return this.m_SALED;
            }
            set
            {
                this.m_SALED = value;
            }
        }

        public int SHORT
        {
            get
            {
                return this.m_SHORT;
            }
            set
            {
                this.m_SHORT = value;
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

        public DateTime STOCK_DATE
        {
            get
            {
                return this.m_STOCK_DATE;
            }
            set
            {
                this.m_STOCK_DATE = value;
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
    }
}

