namespace SAMS.DatabaseLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using System;
    using System.Data;

    public class spUpdateHHSaleOrderPromotion
    {
        private decimal m_ClaimAmount;
        private IDbConnection m_connection;
        private int m_DEVICE_ID;
        private decimal m_DiscountAmount;
        private double m_DiscountPercent;
        private int m_DISTRIBUTOR_ID;
        private int m_FreeQuantity;
        private string m_FreeSKUCode;
        private int m_FreeSKUId;
        private string m_FreeSKUName;
        private decimal m_GSTAmount;
        private double m_GSTRate;
        private long m_HHSaleOrderDetailId;
        private long m_HHSaleOrderId;
        private int m_HHSaleOrderPromotionId;
        private int m_IMPORT_BATCH_NO;
        private DateTime m_IMPORT_DATE;
        private bool m_IS_ACTIVE;
        private bool m_IsScheme;
        private DateTime m_LASTUPDATE_DATE;
        private int m_PromotionOfferId;
        private decimal m_RetailPriceUnit;
        private long m_SALE_INVOICE_PROMOTION_ID;
        private long m_SALE_ORDER_PROMOTION_ID;
        private DateTime m_TIME_STAMP;
        private decimal m_TradePriceUnit;
        private IDbTransaction m_transaction;
        private string sp_Name = " spUpdateHHSaleOrderPromotion";

        public bool ExecuteQuery()
        {
            bool flag;
            try
            {
                IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spUpdateHHSaleOrderPromotion";
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
                cmd.CommandText = "spUpdateHHSaleOrderPromotion";
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
                cmd.CommandText = "spUpdateHHSaleOrderPromotion";
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
                cmd.CommandText = "spUpdateHHSaleOrderPromotion";
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
                this.m_SALE_INVOICE_PROMOTION_ID = Convert.ToInt64(dr["SALE_INVOICE_PROMOTION_ID"]);
                this.m_HHSaleOrderId = Convert.ToInt64(dr["HHSaleOrderId"]);
                this.m_HHSaleOrderDetailId = Convert.ToInt64(dr["HHSaleOrderDetailId"]);
                this.m_SALE_ORDER_PROMOTION_ID = Convert.ToInt64(dr["SALE_ORDER_PROMOTION_ID"]);
                this.m_IsScheme = Convert.ToBoolean(dr["IsScheme"]);
                this.m_IS_ACTIVE = Convert.ToBoolean(dr["IS_ACTIVE"]);
                this.m_IMPORT_DATE = Convert.ToDateTime(dr["IMPORT_DATE"]);
                this.m_TIME_STAMP = Convert.ToDateTime(dr["TIME_STAMP"]);
                this.m_LASTUPDATE_DATE = Convert.ToDateTime(dr["LASTUPDATE_DATE"]);
                this.m_GSTRate = Convert.ToDouble(dr["GSTRate"]);
                this.m_DiscountPercent = Convert.ToDouble(dr["DiscountPercent"]);
                this.m_IMPORT_BATCH_NO = Convert.ToInt32(dr["IMPORT_BATCH_NO"]);
                this.m_FreeQuantity = Convert.ToInt32(dr["FreeQuantity"]);
                this.m_DEVICE_ID = Convert.ToInt32(dr["DEVICE_ID"]);
                this.m_DISTRIBUTOR_ID = Convert.ToInt32(dr["DISTRIBUTOR_ID"]);
                this.m_HHSaleOrderPromotionId = Convert.ToInt32(dr["HHSaleOrderPromotionId"]);
                this.m_PromotionOfferId = Convert.ToInt32(dr["PromotionOfferId"]);
                this.m_FreeSKUId = Convert.ToInt32(dr["FreeSKUId"]);
                this.m_DiscountAmount = Convert.ToDecimal(dr["DiscountAmount"]);
                this.m_ClaimAmount = Convert.ToDecimal(dr["ClaimAmount"]);
                this.m_TradePriceUnit = Convert.ToDecimal(dr["TradePriceUnit"]);
                this.m_RetailPriceUnit = Convert.ToDecimal(dr["RetailPriceUnit"]);
                this.m_GSTAmount = Convert.ToDecimal(dr["GSTAmount"]);
                this.m_FreeSKUCode = Convert.ToString(dr["FreeSKUCode"]);
                this.m_FreeSKUName = Convert.ToString(dr["FreeSKUName"]);
            }
        }

        public void GetParameterCollection(ref IDbCommand cmd)
        {
            IDataParameterCollection parameters = cmd.Parameters;
            IDataParameter parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@SALE_INVOICE_PROMOTION_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
            if (this.m_SALE_INVOICE_PROMOTION_ID == -9223372036854775808L)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_SALE_INVOICE_PROMOTION_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@HHSaleOrderId";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
            if (this.m_HHSaleOrderId == -9223372036854775808L)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_HHSaleOrderId;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@HHSaleOrderDetailId";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
            if (this.m_HHSaleOrderDetailId == -9223372036854775808L)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_HHSaleOrderDetailId;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@SALE_ORDER_PROMOTION_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
            if (this.m_SALE_ORDER_PROMOTION_ID == -9223372036854775808L)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_SALE_ORDER_PROMOTION_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@IsScheme";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
            parameter.Value = this.m_IsScheme;
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@IS_ACTIVE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
            parameter.Value = this.m_IS_ACTIVE;
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@IMPORT_DATE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
            if (this.m_IMPORT_DATE == Constants.DateNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_IMPORT_DATE;
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
            parameter.ParameterName = "@GSTRate";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Float);
            if (this.m_GSTRate == -3.4028234663852886E+38)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_GSTRate;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@DiscountPercent";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Float);
            if (this.m_DiscountPercent == -3.4028234663852886E+38)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_DiscountPercent;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@IMPORT_BATCH_NO";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_IMPORT_BATCH_NO == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_IMPORT_BATCH_NO;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@FreeQuantity";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_FreeQuantity == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_FreeQuantity;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@DEVICE_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_DEVICE_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_DEVICE_ID;
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
            parameter.ParameterName = "@HHSaleOrderPromotionId";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_HHSaleOrderPromotionId == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_HHSaleOrderPromotionId;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@PromotionOfferId";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_PromotionOfferId == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_PromotionOfferId;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@FreeSKUId";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_FreeSKUId == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_FreeSKUId;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@DiscountAmount";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
            if (this.m_DiscountAmount == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_DiscountAmount;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@ClaimAmount";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
            if (this.m_ClaimAmount == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_ClaimAmount;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@TradePriceUnit";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
            if (this.m_TradePriceUnit == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_TradePriceUnit;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@RetailPriceUnit";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
            if (this.m_RetailPriceUnit == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_RetailPriceUnit;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@GSTAmount";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
            if (this.m_GSTAmount == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_GSTAmount;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@FreeSKUCode";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_FreeSKUCode == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_FreeSKUCode;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@FreeSKUName";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_FreeSKUName == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_FreeSKUName;
            }
            parameters.Add(parameter);
        }

        public decimal ClaimAmount
        {
            get
            {
                return this.m_ClaimAmount;
            }
            set
            {
                this.m_ClaimAmount = value;
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

        public int DEVICE_ID
        {
            get
            {
                return this.m_DEVICE_ID;
            }
            set
            {
                this.m_DEVICE_ID = value;
            }
        }

        public decimal DiscountAmount
        {
            get
            {
                return this.m_DiscountAmount;
            }
            set
            {
                this.m_DiscountAmount = value;
            }
        }

        public double DiscountPercent
        {
            get
            {
                return this.m_DiscountPercent;
            }
            set
            {
                this.m_DiscountPercent = value;
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

        public int FreeQuantity
        {
            get
            {
                return this.m_FreeQuantity;
            }
            set
            {
                this.m_FreeQuantity = value;
            }
        }

        public string FreeSKUCode
        {
            get
            {
                return this.m_FreeSKUCode;
            }
            set
            {
                this.m_FreeSKUCode = value;
            }
        }

        public int FreeSKUId
        {
            get
            {
                return this.m_FreeSKUId;
            }
            set
            {
                this.m_FreeSKUId = value;
            }
        }

        public string FreeSKUName
        {
            get
            {
                return this.m_FreeSKUName;
            }
            set
            {
                this.m_FreeSKUName = value;
            }
        }

        public decimal GSTAmount
        {
            get
            {
                return this.m_GSTAmount;
            }
            set
            {
                this.m_GSTAmount = value;
            }
        }

        public double GSTRate
        {
            get
            {
                return this.m_GSTRate;
            }
            set
            {
                this.m_GSTRate = value;
            }
        }

        public long HHSaleOrderDetailId
        {
            get
            {
                return this.m_HHSaleOrderDetailId;
            }
            set
            {
                this.m_HHSaleOrderDetailId = value;
            }
        }

        public long HHSaleOrderId
        {
            get
            {
                return this.m_HHSaleOrderId;
            }
            set
            {
                this.m_HHSaleOrderId = value;
            }
        }

        public int HHSaleOrderPromotionId
        {
            get
            {
                return this.m_HHSaleOrderPromotionId;
            }
            set
            {
                this.m_HHSaleOrderPromotionId = value;
            }
        }

        public int IMPORT_BATCH_NO
        {
            get
            {
                return this.m_IMPORT_BATCH_NO;
            }
            set
            {
                this.m_IMPORT_BATCH_NO = value;
            }
        }

        public DateTime IMPORT_DATE
        {
            get
            {
                return this.m_IMPORT_DATE;
            }
            set
            {
                this.m_IMPORT_DATE = value;
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

        public bool IsScheme
        {
            get
            {
                return this.m_IsScheme;
            }
            set
            {
                this.m_IsScheme = value;
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

        public int PromotionOfferId
        {
            get
            {
                return this.m_PromotionOfferId;
            }
            set
            {
                this.m_PromotionOfferId = value;
            }
        }

        public decimal RetailPriceUnit
        {
            get
            {
                return this.m_RetailPriceUnit;
            }
            set
            {
                this.m_RetailPriceUnit = value;
            }
        }

        public long SALE_INVOICE_PROMOTION_ID
        {
            get
            {
                return this.m_SALE_INVOICE_PROMOTION_ID;
            }
            set
            {
                this.m_SALE_INVOICE_PROMOTION_ID = value;
            }
        }

        public long SALE_ORDER_PROMOTION_ID
        {
            get
            {
                return this.m_SALE_ORDER_PROMOTION_ID;
            }
            set
            {
                this.m_SALE_ORDER_PROMOTION_ID = value;
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

        public decimal TradePriceUnit
        {
            get
            {
                return this.m_TradePriceUnit;
            }
            set
            {
                this.m_TradePriceUnit = value;
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

