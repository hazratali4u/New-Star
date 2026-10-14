namespace SAMS.DatabaseLayer.Classes
{
    using SAMS.DataAccessLayer.Classes;
    using System;
    using System.Data;

    public class uspSelectPriceInfo
    {
        private int m_BRAND_ID;
        private int m_CATEGORY_ID;
        private IDbConnection m_connection;
        private int m_DIVISION_ID;
        private int m_PRODUCTLINE_ID;
        private IDbTransaction m_transaction;
        private string sp_Name = " uspSelectPriceInfo";

        public bool ExecuteQuery()
        {
            try
            {
                IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "uspSelectPriceInfo";
                cmd.Connection = this.m_connection;
                this.GetParameterCollection(ref cmd);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IDataReader ExecuteReader()
        {
            try
            {
                IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "uspSelectPriceInfo";
                cmd.Connection = this.m_connection;
                this.GetParameterCollection(ref cmd);
                return cmd.ExecuteReader();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string ExecuteScalar()
        {
            string str;
            try
            {
                IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "uspSelectPriceInfo";
                cmd.Connection = this.m_connection;
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
                cmd.CommandText = "uspSelectPriceInfo";
                cmd.Connection = this.m_connection;
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
                DataRow row = (DataRow) dr[0];
                this.m_BRAND_ID = Convert.ToInt32(row["BRAND_ID"]);
                this.m_DIVISION_ID = Convert.ToInt32(row["DIVISION_ID"]);
                this.m_CATEGORY_ID = Convert.ToInt32(row["CATEGORY_ID"]);
                this.m_PRODUCTLINE_ID = Convert.ToInt32(row["PRODUCTLINE_ID"]);
            }
        }

        public void GetParameterCollection(ref IDbCommand cmd)
        {
            IDataParameterCollection parameters = cmd.Parameters;
            IDataParameter parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
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
            parameter.ParameterName = "@PRODUCTLINE_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_PRODUCTLINE_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_PRODUCTLINE_ID;
            }
            parameters.Add(parameter);
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

        public int PRODUCTLINE_ID
        {
            get
            {
                return this.m_PRODUCTLINE_ID;
            }
            set
            {
                this.m_PRODUCTLINE_ID = value;
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

