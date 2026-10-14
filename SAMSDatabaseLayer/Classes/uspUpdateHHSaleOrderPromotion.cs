namespace SAMS.DatabaseLayer.Classes
{
    using SAMS.DataAccessLayer.Classes;
    using System;
    using System.Data;

    public class uspUpdateHHSaleOrderPromotion
    {
        private IDbConnection m_connection;
        private long m_HHSaleOrderPromotionId;
        private int m_IMPORT_BATCH_NO;
        private long m_SALE_INVOICE_PROMOTION_ID;
        private long m_SALE_ORDER_PROMOTION_ID;
        private IDbTransaction m_transaction;
        private string sp_Name = " uspUpdateHHSaleOrderPromotion";

        public bool ExecuteQuery()
        {
            bool flag;
            try
            {
                IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "uspUpdateHHSaleOrderPromotion";
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
                cmd.CommandText = "uspUpdateHHSaleOrderPromotion";
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
                cmd.CommandText = "uspUpdateHHSaleOrderPromotion";
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
                cmd.CommandText = "uspUpdateHHSaleOrderPromotion";
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
                this.m_HHSaleOrderPromotionId = Convert.ToInt64(dr["HHSaleOrderPromotionId"]);
                this.m_SALE_ORDER_PROMOTION_ID = Convert.ToInt64(dr["SALE_ORDER_PROMOTION_ID"]);
                this.m_SALE_INVOICE_PROMOTION_ID = Convert.ToInt64(dr["SALE_INVOICE_PROMOTION_ID"]);
                this.m_IMPORT_BATCH_NO = Convert.ToInt32(dr["IMPORT_BATCH_NO"]);
            }
        }

        public void GetParameterCollection(ref IDbCommand cmd)
        {
            IDataParameterCollection parameters = cmd.Parameters;
            IDataParameter parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@HHSaleOrderPromotionId";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
            if (this.m_HHSaleOrderPromotionId == -9223372036854775808L)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_HHSaleOrderPromotionId;
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

        public long HHSaleOrderPromotionId
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

