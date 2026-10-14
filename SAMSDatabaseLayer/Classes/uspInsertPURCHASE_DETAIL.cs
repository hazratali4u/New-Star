namespace SAMS.DatabaseLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using System;
    using System.Data;

    public class uspInsertPURCHASE_DETAIL
    {
        private decimal m_AMOUNT;
        private string m_BATCH_NUMBER;
        private IDbConnection m_connection;
        private int m_DISTRIBUTOR_ID;
        private DateTime m_EXPIRY_DATE;
        private decimal m_FREE_AMOUNT;
        private string m_FREE_BATCH_NUMBER;
        private DateTime m_FREE_EXPIRY_DATE;
        private decimal m_FREE_PRICE;
        private int m_FREE_QUANTITY;
        private int m_FREE_SKU_ID;
        private float m_FREE_TAX_RATE;
        private decimal m_FREE_TAX_VALUE;
        private decimal m_PRICE;
        private long m_PURCHASE_DETAIL_ID;
        private long m_PURCHASE_MASTER_ID;
        private int m_QUANTITY;
        private int m_SKU_ID;
        private float m_TAX_RATE;
        private decimal m_TAX_VALUE;
        private IDbTransaction m_transaction;
        private string sp_Name = " uspInsertPURCHASE_DETAIL";

        public bool ExecuteQuery()
        {
            bool flag;
            try
            {
                IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "uspInsertPURCHASE_DETAIL";
                cmd.Connection = this.m_connection;
                if (this.m_transaction != null)
                {
                    cmd.Transaction = this.m_transaction;
                }
                this.GetParameterCollection(ref cmd);
                cmd.ExecuteNonQuery();
                this.m_PURCHASE_DETAIL_ID = (long) ((IDataParameter) cmd.Parameters["@PURCHASE_DETAIL_ID"]).Value;
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
                cmd.CommandText = "uspInsertPURCHASE_DETAIL";
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
                cmd.CommandText = "uspInsertPURCHASE_DETAIL";
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
                cmd.CommandText = "uspInsertPURCHASE_DETAIL";
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
                this.m_PURCHASE_MASTER_ID = Convert.ToInt64(dr["PURCHASE_MASTER_ID"]);
                this.m_PURCHASE_DETAIL_ID = Convert.ToInt64(dr["PURCHASE_DETAIL_ID"]);
                this.m_EXPIRY_DATE = Convert.ToDateTime(dr["EXPIRY_DATE"]);
                this.m_FREE_EXPIRY_DATE = Convert.ToDateTime(dr["FREE_EXPIRY_DATE"]);
                this.m_TAX_RATE = float.Parse(dr["TAX_RATE"].ToString());
                this.m_FREE_TAX_RATE = float.Parse(dr["FREE_TAX_RATE"].ToString());
                this.m_QUANTITY = Convert.ToInt32(dr["QUANTITY"]);
                this.m_FREE_QUANTITY = Convert.ToInt32(dr["FREE_QUANTITY"]);
                this.m_DISTRIBUTOR_ID = Convert.ToInt32(dr["DISTRIBUTOR_ID"]);
                this.m_SKU_ID = Convert.ToInt32(dr["SKU_ID"]);
                this.m_FREE_SKU_ID = Convert.ToInt32(dr["FREE_SKU_ID"]);
                this.m_FREE_PRICE = Convert.ToDecimal(dr["FREE_PRICE"]);
                this.m_TAX_VALUE = Convert.ToDecimal(dr["TAX_VALUE"]);
                this.m_FREE_TAX_VALUE = Convert.ToDecimal(dr["FREE_TAX_VALUE"]);
                this.m_AMOUNT = Convert.ToDecimal(dr["AMOUNT"]);
                this.m_FREE_AMOUNT = Convert.ToDecimal(dr["FREE_AMOUNT"]);
                this.m_PRICE = Convert.ToDecimal(dr["PRICE"]);
                this.m_BATCH_NUMBER = Convert.ToString(dr["BATCH_NUMBER"]);
                this.m_FREE_BATCH_NUMBER = Convert.ToString(dr["FREE_BATCH_NUMBER"]);
            }
        }

        public void GetParameterCollection(ref IDbCommand cmd)
        {
            IDataParameterCollection parameters = cmd.Parameters;
            IDataParameter parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@PURCHASE_MASTER_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
            if (this.m_PURCHASE_MASTER_ID == -9223372036854775808L)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_PURCHASE_MASTER_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@PURCHASE_DETAIL_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
            parameter.Direction = ParameterDirection.Output;
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@EXPIRY_DATE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
            if (this.m_EXPIRY_DATE == Constants.DateNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_EXPIRY_DATE;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@FREE_EXPIRY_DATE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
            if (this.m_FREE_EXPIRY_DATE == Constants.DateNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_FREE_EXPIRY_DATE;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@TAX_RATE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Float);
            if (this.m_TAX_RATE == float.MinValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_TAX_RATE;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@FREE_TAX_RATE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Float);
            if (this.m_FREE_TAX_RATE == float.MinValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_FREE_TAX_RATE;
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
            parameter.ParameterName = "@FREE_QUANTITY";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_FREE_QUANTITY == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_FREE_QUANTITY;
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
            parameter.ParameterName = "@FREE_SKU_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_FREE_SKU_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_FREE_SKU_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@FREE_PRICE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
            if (this.m_FREE_PRICE == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_FREE_PRICE;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@TAX_VALUE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
            if (this.m_TAX_VALUE == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_TAX_VALUE;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@FREE_TAX_VALUE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
            if (this.m_FREE_TAX_VALUE == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_FREE_TAX_VALUE;
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
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@FREE_AMOUNT";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
            if (this.m_FREE_AMOUNT == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_FREE_AMOUNT;
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
            parameter.ParameterName = "@BATCH_NUMBER";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_BATCH_NUMBER == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_BATCH_NUMBER;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@FREE_BATCH_NUMBER";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_FREE_BATCH_NUMBER == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_FREE_BATCH_NUMBER;
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

        public string BATCH_NUMBER
        {
            get
            {
                return this.m_BATCH_NUMBER;
            }
            set
            {
                this.m_BATCH_NUMBER = value;
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

        public DateTime EXPIRY_DATE
        {
            get
            {
                return this.m_EXPIRY_DATE;
            }
            set
            {
                this.m_EXPIRY_DATE = value;
            }
        }

        public decimal FREE_AMOUNT
        {
            get
            {
                return this.m_FREE_AMOUNT;
            }
            set
            {
                this.m_FREE_AMOUNT = value;
            }
        }

        public string FREE_BATCH_NUMBER
        {
            get
            {
                return this.m_FREE_BATCH_NUMBER;
            }
            set
            {
                this.m_FREE_BATCH_NUMBER = value;
            }
        }

        public DateTime FREE_EXPIRY_DATE
        {
            get
            {
                return this.m_FREE_EXPIRY_DATE;
            }
            set
            {
                this.m_FREE_EXPIRY_DATE = value;
            }
        }

        public decimal FREE_PRICE
        {
            get
            {
                return this.m_FREE_PRICE;
            }
            set
            {
                this.m_FREE_PRICE = value;
            }
        }

        public int FREE_QUANTITY
        {
            get
            {
                return this.m_FREE_QUANTITY;
            }
            set
            {
                this.m_FREE_QUANTITY = value;
            }
        }

        public int FREE_SKU_ID
        {
            get
            {
                return this.m_FREE_SKU_ID;
            }
            set
            {
                this.m_FREE_SKU_ID = value;
            }
        }

        public float FREE_TAX_RATE
        {
            get
            {
                return this.m_FREE_TAX_RATE;
            }
            set
            {
                this.m_FREE_TAX_RATE = value;
            }
        }

        public decimal FREE_TAX_VALUE
        {
            get
            {
                return this.m_FREE_TAX_VALUE;
            }
            set
            {
                this.m_FREE_TAX_VALUE = value;
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

        public long PURCHASE_DETAIL_ID
        {
            get
            {
                return this.m_PURCHASE_DETAIL_ID;
            }
        }

        public long PURCHASE_MASTER_ID
        {
            get
            {
                return this.m_PURCHASE_MASTER_ID;
            }
            set
            {
                this.m_PURCHASE_MASTER_ID = value;
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

        public float TAX_RATE
        {
            get
            {
                return this.m_TAX_RATE;
            }
            set
            {
                this.m_TAX_RATE = value;
            }
        }

        public decimal TAX_VALUE
        {
            get
            {
                return this.m_TAX_VALUE;
            }
            set
            {
                this.m_TAX_VALUE = value;
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

