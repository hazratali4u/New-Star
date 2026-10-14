namespace SAMS.DatabaseLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using System;
    using System.Data;

    public class spInsertHHSaleOrderDetail
    {
        private decimal m_Amount;
        private string m_BatchNumber;
        private IDbConnection m_connection;
        private int m_DEVICE_ID;
        private int m_DISTRIBUTOR_ID;
        private decimal m_GSTAmount;
        private string m_GSTOn;
        private double m_GSTRate;
        private long m_HHSaleOrderDetailId;
        private long m_HHSaleOrderId;
        private int m_IMPORT_BATCH_NO;
        private DateTime m_IMPORT_DATE;
        private bool m_IS_ACTIVE;
        private DateTime m_LASTUPDATE_DATE;
        private decimal m_NetAmount;
        private int m_QuantityUnit;
        private decimal m_RetailPriceUnit;
        private long m_SALE_INVOICE_DETAIL_ID;
        private long m_SALE_ORDER_DETAIL_ID;
        private decimal m_SchDiscountAmount;
        private double m_SchDiscountPercent;
        private string m_SKUCode;
        private int m_SKUId;
        private string m_SKUName;
        private decimal m_StdDiscountAmount;
        private double m_StdDiscountPercent;
        private decimal m_TaxPriceUnit;
        private DateTime m_TIME_STAMP;
        private decimal m_TradePriceUnit;
        private IDbTransaction m_transaction;
        private string sp_Name = " spInsertHHSaleOrderDetail";

        public bool ExecuteQuery()
        {
            bool flag;
            try
            {
                IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spInsertHHSaleOrderDetail";
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
                cmd.CommandText = "spInsertHHSaleOrderDetail";
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
                cmd.CommandText = "spInsertHHSaleOrderDetail";
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
                cmd.CommandText = "spInsertHHSaleOrderDetail";
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
                this.m_SALE_INVOICE_DETAIL_ID = Convert.ToInt64(dr["SALE_INVOICE_DETAIL_ID"]);
                this.m_HHSaleOrderDetailId = Convert.ToInt64(dr["HHSaleOrderDetailId"]);
                this.m_HHSaleOrderId = Convert.ToInt64(dr["HHSaleOrderId"]);
                this.m_SALE_ORDER_DETAIL_ID = Convert.ToInt64(dr["SALE_ORDER_DETAIL_ID"]);
                this.m_IS_ACTIVE = Convert.ToBoolean(dr["IS_ACTIVE"]);
                this.m_GSTOn = Convert.ToString(dr["GSTOn"]);
                this.m_IMPORT_DATE = Convert.ToDateTime(dr["IMPORT_DATE"]);
                this.m_TIME_STAMP = Convert.ToDateTime(dr["TIME_STAMP"]);
                this.m_LASTUPDATE_DATE = Convert.ToDateTime(dr["LASTUPDATE_DATE"]);
                this.m_GSTRate = Convert.ToDouble(dr["GSTRate"]);
                this.m_StdDiscountPercent = Convert.ToDouble(dr["StdDiscountPercent"]);
                this.m_SchDiscountPercent = Convert.ToDouble(dr["SchDiscountPercent"]);
                this.m_DISTRIBUTOR_ID = Convert.ToInt32(dr["DISTRIBUTOR_ID"]);
                this.m_IMPORT_BATCH_NO = Convert.ToInt32(dr["IMPORT_BATCH_NO"]);
                this.m_SKUId = Convert.ToInt32(dr["SKUId"]);
                this.m_QuantityUnit = Convert.ToInt32(dr["QuantityUnit"]);
                this.m_DEVICE_ID = Convert.ToInt32(dr["DEVICE_ID"]);
                this.m_SchDiscountAmount = Convert.ToDecimal(dr["SchDiscountAmount"]);
                this.m_GSTAmount = Convert.ToDecimal(dr["GSTAmount"]);
                this.m_Amount = Convert.ToDecimal(dr["Amount"]);
                this.m_NetAmount = Convert.ToDecimal(dr["NetAmount"]);
                this.m_StdDiscountAmount = Convert.ToDecimal(dr["StdDiscountAmount"]);
                this.m_TradePriceUnit = Convert.ToDecimal(dr["TradePriceUnit"]);
                this.m_RetailPriceUnit = Convert.ToDecimal(dr["RetailPriceUnit"]);
                this.m_TaxPriceUnit = Convert.ToDecimal(dr["TaxPriceUnit"]);
                this.m_SKUCode = Convert.ToString(dr["SKUCode"]);
                this.m_SKUName = Convert.ToString(dr["SKUName"]);
                this.m_BatchNumber = Convert.ToString(dr["BatchNumber"]);
            }
        }

        public void GetParameterCollection(ref IDbCommand cmd)
        {
            IDataParameterCollection parameters = cmd.Parameters;
            IDataParameter parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@SALE_INVOICE_DETAIL_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
            if (this.m_SALE_INVOICE_DETAIL_ID == -9223372036854775808L)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_SALE_INVOICE_DETAIL_ID;
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
            parameter.ParameterName = "@SALE_ORDER_DETAIL_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
            if (this.m_SALE_ORDER_DETAIL_ID == -9223372036854775808L)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_SALE_ORDER_DETAIL_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@IS_ACTIVE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
            parameter.Value = this.m_IS_ACTIVE;
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@GSTOn";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Char);
            if (this.m_GSTOn == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_GSTOn;
            }
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
            parameter.ParameterName = "@StdDiscountPercent";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Float);
            if (this.m_StdDiscountPercent == -3.4028234663852886E+38)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_StdDiscountPercent;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@SchDiscountPercent";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Float);
            if (this.m_SchDiscountPercent == -3.4028234663852886E+38)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_SchDiscountPercent;
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
            parameter.ParameterName = "@SKUId";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_SKUId == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_SKUId;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@QuantityUnit";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_QuantityUnit == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_QuantityUnit;
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
            parameter.ParameterName = "@SchDiscountAmount";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
            if (this.m_SchDiscountAmount == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_SchDiscountAmount;
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
            parameter.ParameterName = "@Amount";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
            if (this.m_Amount == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_Amount;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@NetAmount";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
            if (this.m_NetAmount == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_NetAmount;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@StdDiscountAmount";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
            if (this.m_StdDiscountAmount == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_StdDiscountAmount;
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
            parameter.ParameterName = "@TaxPriceUnit";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
            if (this.m_TaxPriceUnit == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_TaxPriceUnit;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@SKUCode";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_SKUCode == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_SKUCode;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@SKUName";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_SKUName == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_SKUName;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@BatchNumber";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_BatchNumber == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_BatchNumber;
            }
            parameters.Add(parameter);
        }

        public decimal Amount
        {
            get
            {
                return this.m_Amount;
            }
            set
            {
                this.m_Amount = value;
            }
        }

        public string BatchNumber
        {
            get
            {
                return this.m_BatchNumber;
            }
            set
            {
                this.m_BatchNumber = value;
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

        public string GSTOn
        {
            get
            {
                return this.m_GSTOn;
            }
            set
            {
                this.m_GSTOn = value;
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

        public decimal NetAmount
        {
            get
            {
                return this.m_NetAmount;
            }
            set
            {
                this.m_NetAmount = value;
            }
        }

        public int QuantityUnit
        {
            get
            {
                return this.m_QuantityUnit;
            }
            set
            {
                this.m_QuantityUnit = value;
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

        public long SALE_INVOICE_DETAIL_ID
        {
            get
            {
                return this.m_SALE_INVOICE_DETAIL_ID;
            }
            set
            {
                this.m_SALE_INVOICE_DETAIL_ID = value;
            }
        }

        public long SALE_ORDER_DETAIL_ID
        {
            get
            {
                return this.m_SALE_ORDER_DETAIL_ID;
            }
            set
            {
                this.m_SALE_ORDER_DETAIL_ID = value;
            }
        }

        public decimal SchDiscountAmount
        {
            get
            {
                return this.m_SchDiscountAmount;
            }
            set
            {
                this.m_SchDiscountAmount = value;
            }
        }

        public double SchDiscountPercent
        {
            get
            {
                return this.m_SchDiscountPercent;
            }
            set
            {
                this.m_SchDiscountPercent = value;
            }
        }

        public string SKUCode
        {
            get
            {
                return this.m_SKUCode;
            }
            set
            {
                this.m_SKUCode = value;
            }
        }

        public int SKUId
        {
            get
            {
                return this.m_SKUId;
            }
            set
            {
                this.m_SKUId = value;
            }
        }

        public string SKUName
        {
            get
            {
                return this.m_SKUName;
            }
            set
            {
                this.m_SKUName = value;
            }
        }

        public decimal StdDiscountAmount
        {
            get
            {
                return this.m_StdDiscountAmount;
            }
            set
            {
                this.m_StdDiscountAmount = value;
            }
        }

        public double StdDiscountPercent
        {
            get
            {
                return this.m_StdDiscountPercent;
            }
            set
            {
                this.m_StdDiscountPercent = value;
            }
        }

        public decimal TaxPriceUnit
        {
            get
            {
                return this.m_TaxPriceUnit;
            }
            set
            {
                this.m_TaxPriceUnit = value;
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

