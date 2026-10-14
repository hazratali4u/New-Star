namespace SAMS.DatabaseLayer.Classes
{
    using SAMS.DataAccessLayer.Classes;
    using System;
    using System.Data;

    public class uspSelectSALE_ORDER_MASTER_dt
    {
        private long m_AREA_ID;
        private IDbConnection m_connection;
        private int m_DELIVERYMAN_ID;
        private int m_DISTRIBUTOR_ID;
        private decimal m_EXTRA_DISCOUNT_AMOUNT;
        private decimal m_GST_AMOUNT;
        private int m_ORDERBOOKER_ID;
        private long m_SALE_ORDER_ID;
        private long m_SHIP_TO;
        private long m_SOLD_TO;
        private decimal m_STANDARD_DISCOUNT_AMOUNT;
        private int m_STATUS_ID;
        private int m_TERRITORY_ID;
        private decimal m_TOTAL_AMOUNT;
        private char m_TOTAL_CLAIM_AMOUNT;
        private decimal m_TOTAL_NET_AMOUNT;
        private IDbTransaction m_transaction;
        private string sp_Name = " uspSelectSALE_ORDER_MASTER_dt";

        public bool ExecuteQuery()
        {
            bool flag;
            try
            {
                IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "uspSelectSALE_ORDER_MASTER_dt";
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
                cmd.CommandText = "uspSelectSALE_ORDER_MASTER_dt";
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
                cmd.CommandText = "uspSelectSALE_ORDER_MASTER_dt";
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
                cmd.CommandText = "uspSelectSALE_ORDER_MASTER_dt";
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
                this.m_SHIP_TO = Convert.ToInt64(dr["SHIP_TO"]);
                this.m_SALE_ORDER_ID = Convert.ToInt64(dr["SALE_ORDER_ID"]);
                this.m_AREA_ID = Convert.ToInt64(dr["AREA_ID"]);
                this.m_SOLD_TO = Convert.ToInt64(dr["SOLD_TO"]);
                this.m_TOTAL_CLAIM_AMOUNT = Convert.ToChar(dr["TOTAL_CLAIM_AMOUNT"]);
                this.m_DELIVERYMAN_ID = Convert.ToInt32(dr["DELIVERYMAN_ID"]);
                this.m_STATUS_ID = Convert.ToInt32(dr["STATUS_ID"]);
                this.m_DISTRIBUTOR_ID = Convert.ToInt32(dr["DISTRIBUTOR_ID"]);
                this.m_TERRITORY_ID = Convert.ToInt32(dr["TERRITORY_ID"]);
                this.m_ORDERBOOKER_ID = Convert.ToInt32(dr["ORDERBOOKER_ID"]);
                this.m_STANDARD_DISCOUNT_AMOUNT = Convert.ToDecimal(dr["STANDARD_DISCOUNT_AMOUNT"]);
                this.m_GST_AMOUNT = Convert.ToDecimal(dr["GST_AMOUNT"]);
                this.m_TOTAL_AMOUNT = Convert.ToDecimal(dr["TOTAL_AMOUNT"]);
                this.m_TOTAL_NET_AMOUNT = Convert.ToDecimal(dr["TOTAL_NET_AMOUNT"]);
                this.m_EXTRA_DISCOUNT_AMOUNT = Convert.ToDecimal(dr["EXTRA_DISCOUNT_AMOUNT"]);
            }
        }

        public void GetParameterCollection(ref IDbCommand cmd)
        {
            IDataParameterCollection parameters = cmd.Parameters;
            IDataParameter parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@SHIP_TO";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
            if (this.m_SHIP_TO == -9223372036854775808L)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_SHIP_TO;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@SALE_ORDER_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
            if (this.m_SALE_ORDER_ID == -9223372036854775808L)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_SALE_ORDER_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@AREA_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
            if (this.m_AREA_ID == -9223372036854775808L)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_AREA_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@SOLD_TO";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
            if (this.m_SOLD_TO == -9223372036854775808L)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_SOLD_TO;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@TOTAL_CLAIM_AMOUNT";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Char);
            if (this.m_TOTAL_CLAIM_AMOUNT == '\0')
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_TOTAL_CLAIM_AMOUNT;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@DELIVERYMAN_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_DELIVERYMAN_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_DELIVERYMAN_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@STATUS_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_STATUS_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_STATUS_ID;
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
            parameter.ParameterName = "@TERRITORY_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_TERRITORY_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_TERRITORY_ID;
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
            parameter.ParameterName = "@STANDARD_DISCOUNT_AMOUNT";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
            if (this.m_STANDARD_DISCOUNT_AMOUNT == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_STANDARD_DISCOUNT_AMOUNT;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@GST_AMOUNT";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
            if (this.m_GST_AMOUNT == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_GST_AMOUNT;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@TOTAL_AMOUNT";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
            if (this.m_TOTAL_AMOUNT == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_TOTAL_AMOUNT;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@TOTAL_NET_AMOUNT";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
            if (this.m_TOTAL_NET_AMOUNT == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_TOTAL_NET_AMOUNT;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@EXTRA_DISCOUNT_AMOUNT";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
            if (this.m_EXTRA_DISCOUNT_AMOUNT == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_EXTRA_DISCOUNT_AMOUNT;
            }
            parameters.Add(parameter);
        }

        public long AREA_ID
        {
            get
            {
                return this.m_AREA_ID;
            }
            set
            {
                this.m_AREA_ID = value;
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

        public int DELIVERYMAN_ID
        {
            get
            {
                return this.m_DELIVERYMAN_ID;
            }
            set
            {
                this.m_DELIVERYMAN_ID = value;
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

        public decimal EXTRA_DISCOUNT_AMOUNT
        {
            get
            {
                return this.m_EXTRA_DISCOUNT_AMOUNT;
            }
            set
            {
                this.m_EXTRA_DISCOUNT_AMOUNT = value;
            }
        }

        public decimal GST_AMOUNT
        {
            get
            {
                return this.m_GST_AMOUNT;
            }
            set
            {
                this.m_GST_AMOUNT = value;
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

        public long SALE_ORDER_ID
        {
            get
            {
                return this.m_SALE_ORDER_ID;
            }
            set
            {
                this.m_SALE_ORDER_ID = value;
            }
        }

        public long SHIP_TO
        {
            get
            {
                return this.m_SHIP_TO;
            }
            set
            {
                this.m_SHIP_TO = value;
            }
        }

        public long SOLD_TO
        {
            get
            {
                return this.m_SOLD_TO;
            }
            set
            {
                this.m_SOLD_TO = value;
            }
        }

        public decimal STANDARD_DISCOUNT_AMOUNT
        {
            get
            {
                return this.m_STANDARD_DISCOUNT_AMOUNT;
            }
            set
            {
                this.m_STANDARD_DISCOUNT_AMOUNT = value;
            }
        }

        public int STATUS_ID
        {
            get
            {
                return this.m_STATUS_ID;
            }
            set
            {
                this.m_STATUS_ID = value;
            }
        }

        public int TERRITORY_ID
        {
            get
            {
                return this.m_TERRITORY_ID;
            }
            set
            {
                this.m_TERRITORY_ID = value;
            }
        }

        public decimal TOTAL_AMOUNT
        {
            get
            {
                return this.m_TOTAL_AMOUNT;
            }
            set
            {
                this.m_TOTAL_AMOUNT = value;
            }
        }

        public char TOTAL_CLAIM_AMOUNT
        {
            get
            {
                return this.m_TOTAL_CLAIM_AMOUNT;
            }
            set
            {
                this.m_TOTAL_CLAIM_AMOUNT = value;
            }
        }

        public decimal TOTAL_NET_AMOUNT
        {
            get
            {
                return this.m_TOTAL_NET_AMOUNT;
            }
            set
            {
                this.m_TOTAL_NET_AMOUNT = value;
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

