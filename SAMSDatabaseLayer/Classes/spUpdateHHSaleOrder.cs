namespace SAMS.DatabaseLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using System;
    using System.Data;

    public class spUpdateHHSaleOrder
    {
        private IDbConnection m_connection;
        private long m_CustomerId;
        private int m_DeliveryManId;
        private int m_DEVICE_ID;
        private int m_DISTRIBUTOR_ID;
        private DateTime m_DocumentDate;
        private decimal m_GSTAmount;
        private long m_HHSaleOrderId;
        private int m_IMPORT_BATCH_NO;
        private DateTime m_IMPORT_DATE;
        private bool m_IS_ACTIVE;
        private bool m_IsDeleted;
        private DateTime m_LASTUPDATE_DATE;
        private int m_LEGEND_ID;
        private int m_ORDER_TYPE_ID;
        private int m_ORDERBOOKER_ID;
        private long m_SALE_INVOICE_MASTER_ID;
        private long m_SALE_ORDER_MASTER_ID;
        private string m_SaleOrderNumber;
        private decimal m_SchDiscountAmount;
        private int m_StatusId;
        private decimal m_StdDiscountAmount;
        private DateTime m_TIME_STAMP;
        private decimal m_TotalAmount;
        private decimal m_TotalClaimAmount;
        private decimal m_TotalNetAmount;
        private IDbTransaction m_transaction;
        private string sp_Name = " spUpdateHHSaleOrder";

        public bool ExecuteQuery()
        {
            bool flag;
            try
            {
                IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spUpdateHHSaleOrder";
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
                cmd.CommandText = "spUpdateHHSaleOrder";
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
                cmd.CommandText = "spUpdateHHSaleOrder";
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
                cmd.CommandText = "spUpdateHHSaleOrder";
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
                this.m_SALE_INVOICE_MASTER_ID = Convert.ToInt64(dr["SALE_INVOICE_MASTER_ID"]);
                this.m_HHSaleOrderId = Convert.ToInt64(dr["HHSaleOrderId"]);
                this.m_CustomerId = Convert.ToInt64(dr["CustomerId"]);
                this.m_SALE_ORDER_MASTER_ID = Convert.ToInt64(dr["SALE_ORDER_MASTER_ID"]);
                this.m_IsDeleted = Convert.ToBoolean(dr["IsDeleted"]);
                this.m_IS_ACTIVE = Convert.ToBoolean(dr["IS_ACTIVE"]);
                this.m_LASTUPDATE_DATE = Convert.ToDateTime(dr["LASTUPDATE_DATE"]);
                this.m_DocumentDate = Convert.ToDateTime(dr["DocumentDate"]);
                this.m_IMPORT_DATE = Convert.ToDateTime(dr["IMPORT_DATE"]);
                this.m_TIME_STAMP = Convert.ToDateTime(dr["TIME_STAMP"]);
                this.m_DISTRIBUTOR_ID = Convert.ToInt32(dr["DISTRIBUTOR_ID"]);
                this.m_IMPORT_BATCH_NO = Convert.ToInt32(dr["IMPORT_BATCH_NO"]);
                this.m_ORDER_TYPE_ID = Convert.ToInt32(dr["ORDER_TYPE_ID"]);
                this.m_LEGEND_ID = Convert.ToInt32(dr["LEGEND_ID"]);
                this.m_DEVICE_ID = Convert.ToInt32(dr["DEVICE_ID"]);
                this.m_DeliveryManId = Convert.ToInt32(dr["DeliveryManId"]);
                this.m_StatusId = Convert.ToInt32(dr["StatusId"]);
                this.m_ORDERBOOKER_ID = Convert.ToInt32(dr["ORDERBOOKER_ID"]);
                this.m_TotalClaimAmount = Convert.ToDecimal(dr["TotalClaimAmount"]);
                this.m_GSTAmount = Convert.ToDecimal(dr["GSTAmount"]);
                this.m_TotalNetAmount = Convert.ToDecimal(dr["TotalNetAmount"]);
                this.m_TotalAmount = Convert.ToDecimal(dr["TotalAmount"]);
                this.m_SchDiscountAmount = Convert.ToDecimal(dr["SchDiscountAmount"]);
                this.m_StdDiscountAmount = Convert.ToDecimal(dr["StdDiscountAmount"]);
                this.m_SaleOrderNumber = Convert.ToString(dr["SaleOrderNumber"]);
            }
        }

        public void GetParameterCollection(ref IDbCommand cmd)
        {
            IDataParameterCollection parameters = cmd.Parameters;
            IDataParameter parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@SALE_INVOICE_MASTER_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
            if (this.m_SALE_INVOICE_MASTER_ID == -9223372036854775808L)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_SALE_INVOICE_MASTER_ID;
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
            parameter.ParameterName = "@CustomerId";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
            if (this.m_CustomerId == -9223372036854775808L)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_CustomerId;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@SALE_ORDER_MASTER_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
            if (this.m_SALE_ORDER_MASTER_ID == -9223372036854775808L)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_SALE_ORDER_MASTER_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@IsDeleted";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
            parameter.Value = this.m_IsDeleted;
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@IS_ACTIVE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
            parameter.Value = this.m_IS_ACTIVE;
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
            parameter.ParameterName = "@DocumentDate";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
            if (this.m_DocumentDate == Constants.DateNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_DocumentDate;
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
            parameter.ParameterName = "@ORDER_TYPE_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_ORDER_TYPE_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_ORDER_TYPE_ID;
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
            parameter.ParameterName = "@DeliveryManId";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_DeliveryManId == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_DeliveryManId;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@StatusId";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_StatusId == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_StatusId;
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
            parameter.ParameterName = "@TotalClaimAmount";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
            if (this.m_TotalClaimAmount == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_TotalClaimAmount;
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
            parameter.ParameterName = "@TotalNetAmount";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
            if (this.m_TotalNetAmount == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_TotalNetAmount;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@TotalAmount";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
            if (this.m_TotalAmount == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_TotalAmount;
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
            parameter.ParameterName = "@SaleOrderNumber";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.NVarChar);
            if (this.m_SaleOrderNumber == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_SaleOrderNumber;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@SaleOrderNumber";
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

        public long CustomerId
        {
            get
            {
                return this.m_CustomerId;
            }
            set
            {
                this.m_CustomerId = value;
            }
        }

        public int DeliveryManId
        {
            get
            {
                return this.m_DeliveryManId;
            }
            set
            {
                this.m_DeliveryManId = value;
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

        public DateTime DocumentDate
        {
            get
            {
                return this.m_DocumentDate;
            }
            set
            {
                this.m_DocumentDate = value;
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

        public bool IsDeleted
        {
            get
            {
                return this.m_IsDeleted;
            }
            set
            {
                this.m_IsDeleted = value;
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

        public int ORDER_TYPE_ID
        {
            get
            {
                return this.m_ORDER_TYPE_ID;
            }
            set
            {
                this.m_ORDER_TYPE_ID = value;
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

        public long SALE_INVOICE_MASTER_ID
        {
            get
            {
                return this.m_SALE_INVOICE_MASTER_ID;
            }
            set
            {
                this.m_SALE_INVOICE_MASTER_ID = value;
            }
        }

        public long SALE_ORDER_MASTER_ID
        {
            get
            {
                return this.m_SALE_ORDER_MASTER_ID;
            }
            set
            {
                this.m_SALE_ORDER_MASTER_ID = value;
            }
        }

        public string SaleOrderNumber
        {
            get
            {
                return this.m_SaleOrderNumber;
            }
            set
            {
                this.m_SaleOrderNumber = value;
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

        public int StatusId
        {
            get
            {
                return this.m_StatusId;
            }
            set
            {
                this.m_StatusId = value;
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

        public decimal TotalAmount
        {
            get
            {
                return this.m_TotalAmount;
            }
            set
            {
                this.m_TotalAmount = value;
            }
        }

        public decimal TotalClaimAmount
        {
            get
            {
                return this.m_TotalClaimAmount;
            }
            set
            {
                this.m_TotalClaimAmount = value;
            }
        }

        public decimal TotalNetAmount
        {
            get
            {
                return this.m_TotalNetAmount;
            }
            set
            {
                this.m_TotalNetAmount = value;
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

