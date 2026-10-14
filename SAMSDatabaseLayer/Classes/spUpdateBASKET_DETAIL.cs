namespace SAMS.DatabaseLayer.Classes
{
    using SAMS.DataAccessLayer.Classes;
    using System;
    using System.Data;

    public class spUpdateBASKET_DETAIL
    {
        private long m_BASKET_DETAIL_ID;
        private long m_BASKET_ID;
        private int m_BRAND_ID;
        private int m_CATEGORY_ID;
        private int m_COMPANY_ID;
        private IDbConnection m_connection;
        private int m_DISTRIBUTOR_ID;
        private int m_DIVISION_ID;
        private decimal m_MAX_VAL;
        private decimal m_MIN_VAL;
        private int m_MULTIPLE_OF;
        private long m_PROMOTION_ID;
        private int m_SCHEME_ID;
        private int m_SKU_GROUP_ID;
        private int m_SKU_ID;
        private IDbTransaction m_transaction;
        private int m_UOM_ID;
        private int m_VARIANT_ID;
        private string sp_Name = " spUpdateBASKET_DETAIL";

        public bool ExecuteQuery()
        {
            bool flag;
            try
            {
                IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spUpdateBASKET_DETAIL";
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
                cmd.CommandText = "spUpdateBASKET_DETAIL";
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
                cmd.CommandText = "spUpdateBASKET_DETAIL";
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
                cmd.CommandText = "spUpdateBASKET_DETAIL";
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
                this.m_BASKET_DETAIL_ID = Convert.ToInt64(dr["BASKET_DETAIL_ID"]);
                this.m_BASKET_ID = Convert.ToInt64(dr["BASKET_ID"]);
                this.m_PROMOTION_ID = Convert.ToInt64(dr["PROMOTION_ID"]);
                this.m_SKU_GROUP_ID = Convert.ToInt32(dr["SKU_GROUP_ID"]);
                this.m_UOM_ID = Convert.ToInt32(dr["UOM_ID"]);
                this.m_BRAND_ID = Convert.ToInt32(dr["BRAND_ID"]);
                this.m_VARIANT_ID = Convert.ToInt32(dr["VARIANT_ID"]);
                this.m_SKU_ID = Convert.ToInt32(dr["SKU_ID"]);
                this.m_COMPANY_ID = Convert.ToInt32(dr["COMPANY_ID"]);
                this.m_DIVISION_ID = Convert.ToInt32(dr["DIVISION_ID"]);
                this.m_CATEGORY_ID = Convert.ToInt32(dr["CATEGORY_ID"]);
                this.m_SCHEME_ID = Convert.ToInt32(dr["SCHEME_ID"]);
                this.m_DISTRIBUTOR_ID = Convert.ToInt32(dr["DISTRIBUTOR_ID"]);
                this.m_MULTIPLE_OF = Convert.ToInt32(dr["MULTIPLE_OF"]);
                this.m_MIN_VAL = Convert.ToDecimal(dr["MIN_VAL"]);
                this.m_MAX_VAL = Convert.ToDecimal(dr["MAX_VAL"]);
            }
        }

        public void GetParameterCollection(ref IDbCommand cmd)
        {
            IDataParameterCollection parameters = cmd.Parameters;
            IDataParameter parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@BASKET_DETAIL_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
            if (this.m_BASKET_DETAIL_ID == -9223372036854775808L)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_BASKET_DETAIL_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@BASKET_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
            if (this.m_BASKET_ID == -9223372036854775808L)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_BASKET_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@PROMOTION_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
            if (this.m_PROMOTION_ID == -9223372036854775808L)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_PROMOTION_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@SKU_GROUP_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_SKU_GROUP_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_SKU_GROUP_ID;
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
            parameter.ParameterName = "@BRAND_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_BRAND_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_BRAND_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@VARIANT_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_VARIANT_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_VARIANT_ID;
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
            parameter.ParameterName = "@DIVISION_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_DIVISION_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_DIVISION_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@CATEGORY_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_CATEGORY_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_CATEGORY_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@SCHEME_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_SCHEME_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_SCHEME_ID;
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
            parameter.ParameterName = "@MULTIPLE_OF";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_MULTIPLE_OF == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_MULTIPLE_OF;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@MIN_VAL";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
            if (this.m_MIN_VAL == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_MIN_VAL;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@MAX_VAL";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
            if (this.m_MAX_VAL == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_MAX_VAL;
            }
            parameters.Add(parameter);
        }

        public long BASKET_DETAIL_ID
        {
            get
            {
                return this.m_BASKET_DETAIL_ID;
            }
            set
            {
                this.m_BASKET_DETAIL_ID = value;
            }
        }

        public long BASKET_ID
        {
            get
            {
                return this.m_BASKET_ID;
            }
            set
            {
                this.m_BASKET_ID = value;
            }
        }

        public int BRAND_ID
        {
            get
            {
                return this.m_BRAND_ID;
            }
            set
            {
                this.m_BRAND_ID = value;
            }
        }

        public int CATEGORY_ID
        {
            get
            {
                return this.m_CATEGORY_ID;
            }
            set
            {
                this.m_CATEGORY_ID = value;
            }
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

        public int DIVISION_ID
        {
            get
            {
                return this.m_DIVISION_ID;
            }
            set
            {
                this.m_DIVISION_ID = value;
            }
        }

        public decimal MAX_VAL
        {
            get
            {
                return this.m_MAX_VAL;
            }
            set
            {
                this.m_MAX_VAL = value;
            }
        }

        public decimal MIN_VAL
        {
            get
            {
                return this.m_MIN_VAL;
            }
            set
            {
                this.m_MIN_VAL = value;
            }
        }

        public int MULTIPLE_OF
        {
            get
            {
                return this.m_MULTIPLE_OF;
            }
            set
            {
                this.m_MULTIPLE_OF = value;
            }
        }

        public long PROMOTION_ID
        {
            get
            {
                return this.m_PROMOTION_ID;
            }
            set
            {
                this.m_PROMOTION_ID = value;
            }
        }

        public int SCHEME_ID
        {
            get
            {
                return this.m_SCHEME_ID;
            }
            set
            {
                this.m_SCHEME_ID = value;
            }
        }

        public int SKU_GROUP_ID
        {
            get
            {
                return this.m_SKU_GROUP_ID;
            }
            set
            {
                this.m_SKU_GROUP_ID = value;
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

        public int VARIANT_ID
        {
            get
            {
                return this.m_VARIANT_ID;
            }
            set
            {
                this.m_VARIANT_ID = value;
            }
        }
    }
}

