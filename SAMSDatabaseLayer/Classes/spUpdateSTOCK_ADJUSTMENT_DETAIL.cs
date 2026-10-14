namespace SAMS.DatabaseLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using System;
    using System.Data;

    public class spUpdateSTOCK_ADJUSTMENT_DETAIL
    {
        private decimal m_AMOUNT;
        private IDbConnection m_connection;
        private int m_IS_ACTIVE;
        private DateTime m_LAST_UPDATEDATE;
        private decimal m_PRICE;
        private int m_QUANTITY;
        private int m_SKU_ID;
        private long m_STOCK_ADJUSTMENT_DETAIL_ID;
        private int m_STOCK_ADJUSTMENT_ID;
        private DateTime m_TIME_STAMP;
        private IDbTransaction m_transaction;
        private int m_USER_ID;
        private string sp_Name = " spUpdateSTOCK_ADJUSTMENT_DETAIL";

        public bool ExecuteQuery()
        {
            bool flag;
            try
            {
                IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spUpdateSTOCK_ADJUSTMENT_DETAIL";
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
                cmd.CommandText = "spUpdateSTOCK_ADJUSTMENT_DETAIL";
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
                cmd.CommandText = "spUpdateSTOCK_ADJUSTMENT_DETAIL";
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
                cmd.CommandText = "spUpdateSTOCK_ADJUSTMENT_DETAIL";
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
                this.m_STOCK_ADJUSTMENT_DETAIL_ID = Convert.ToInt64(dr["STOCK_ADJUSTMENT_DETAIL_ID"]);
                this.m_TIME_STAMP = Convert.ToDateTime(dr["TIME_STAMP"]);
                this.m_LAST_UPDATEDATE = Convert.ToDateTime(dr["LAST_UPDATEDATE"]);
                this.m_USER_ID = Convert.ToInt32(dr["USER_ID"]);
                this.m_IS_ACTIVE = Convert.ToInt32(dr["IS_ACTIVE"]);
                this.m_STOCK_ADJUSTMENT_ID = Convert.ToInt32(dr["STOCK_ADJUSTMENT_ID"]);
                this.m_SKU_ID = Convert.ToInt32(dr["SKU_ID"]);
                this.m_QUANTITY = Convert.ToInt32(dr["QUANTITY"]);
                this.m_PRICE = Convert.ToDecimal(dr["PRICE"]);
                this.m_AMOUNT = Convert.ToDecimal(dr["AMOUNT"]);
            }
        }

        public void GetParameterCollection(ref IDbCommand cmd)
        {
            IDataParameterCollection parameters = cmd.Parameters;
            IDataParameter parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@STOCK_ADJUSTMENT_DETAIL_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
            if (this.m_STOCK_ADJUSTMENT_DETAIL_ID == -9223372036854775808L)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_STOCK_ADJUSTMENT_DETAIL_ID;
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
            parameter.ParameterName = "@LAST_UPDATEDATE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
            if (this.m_LAST_UPDATEDATE == Constants.DateNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_LAST_UPDATEDATE;
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
            parameter.ParameterName = "@IS_ACTIVE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_IS_ACTIVE == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_IS_ACTIVE;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@STOCK_ADJUSTMENT_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_STOCK_ADJUSTMENT_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_STOCK_ADJUSTMENT_ID;
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
            parameter.ParameterName = "@PRICE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
            if (this.m_PRICE == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_PRICE;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@AMOUNT";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
            if (this.m_AMOUNT == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_AMOUNT;
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

        public int IS_ACTIVE
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

        public DateTime LAST_UPDATEDATE
        {
            get
            {
                return this.m_LAST_UPDATEDATE;
            }
            set
            {
                this.m_LAST_UPDATEDATE = value;
            }
        }

        public decimal PRICE
        {
            get
            {
                return this.m_PRICE;
            }
            set
            {
                this.m_PRICE = value;
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

        public long STOCK_ADJUSTMENT_DETAIL_ID
        {
            get
            {
                return this.m_STOCK_ADJUSTMENT_DETAIL_ID;
            }
            set
            {
                this.m_STOCK_ADJUSTMENT_DETAIL_ID = value;
            }
        }

        public int STOCK_ADJUSTMENT_ID
        {
            get
            {
                return this.m_STOCK_ADJUSTMENT_ID;
            }
            set
            {
                this.m_STOCK_ADJUSTMENT_ID = value;
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

