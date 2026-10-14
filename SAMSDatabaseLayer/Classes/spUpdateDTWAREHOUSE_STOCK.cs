namespace SAMS.DatabaseLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using System;
    using System.Data;

    public class spUpdateDTWAREHOUSE_STOCK
    {
        private IDbConnection m_connection;
        private DateTime m_EXPIRY_DATE;
        private int m_SKU_ID;
        private IDbTransaction m_transaction;
        private decimal m_UNIT_IN_STOCK;
        private long m_WAREHOUSE_ID;
        private long m_WAREHOUSE_STOCK_ID;
        private string sp_Name = " spUpdateDTWAREHOUSE_STOCK";

        public bool ExecuteQuery()
        {
            bool flag;
            try
            {
                IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spUpdateDTWAREHOUSE_STOCK";
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
                cmd.CommandText = "spUpdateDTWAREHOUSE_STOCK";
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
                cmd.CommandText = "spUpdateDTWAREHOUSE_STOCK";
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
                cmd.CommandText = "spUpdateDTWAREHOUSE_STOCK";
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
                this.m_WAREHOUSE_STOCK_ID = Convert.ToInt64(dr["WAREHOUSE_STOCK_ID"]);
                this.m_WAREHOUSE_ID = Convert.ToInt64(dr["WAREHOUSE_ID"]);
                this.m_EXPIRY_DATE = Convert.ToDateTime(dr["EXPIRY_DATE"]);
                this.m_UNIT_IN_STOCK = Convert.ToDecimal(dr["UNIT_IN_STOCK"]);
                this.m_SKU_ID = Convert.ToInt32(dr["SKU_ID"]);
            }
        }

        public void GetParameterCollection(ref IDbCommand cmd)
        {
            IDataParameterCollection parameters = cmd.Parameters;
            IDataParameter parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@WAREHOUSE_STOCK_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
            if (this.m_WAREHOUSE_STOCK_ID == -9223372036854775808L)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_WAREHOUSE_STOCK_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@WAREHOUSE_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
            if (this.m_WAREHOUSE_ID == -9223372036854775808L)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_WAREHOUSE_ID;
            }
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
            parameter.ParameterName = "@UNIT_IN_STOCK";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Decimal);
            if (this.m_UNIT_IN_STOCK == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_UNIT_IN_STOCK;
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

        public decimal UNIT_IN_STOCK
        {
            get
            {
                return this.m_UNIT_IN_STOCK;
            }
            set
            {
                this.m_UNIT_IN_STOCK = value;
            }
        }

        public long WAREHOUSE_ID
        {
            get
            {
                return this.m_WAREHOUSE_ID;
            }
            set
            {
                this.m_WAREHOUSE_ID = value;
            }
        }

        public long WAREHOUSE_STOCK_ID
        {
            get
            {
                return this.m_WAREHOUSE_STOCK_ID;
            }
            set
            {
                this.m_WAREHOUSE_STOCK_ID = value;
            }
        }
    }
}

