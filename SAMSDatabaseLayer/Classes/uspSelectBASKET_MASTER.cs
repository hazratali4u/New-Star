namespace SAMS.DatabaseLayer.Classes
{
    using SAMS.DataAccessLayer.Classes;
    using System;
    using System.Data;

    public class uspSelectBASKET_MASTER
    {
        private int m_BASKET_ID;
        private short m_BASKET_ON;
        private IDbConnection m_connection;
        private int m_DISTRIBUTOR_ID;
        private int m_IS_AND;
        private bool m_IS_BASKET;
        private bool m_IS_MULTIPLE;
        private int m_PROMOTION_ID;
        private int m_SCHEME_ID;
        private IDbTransaction m_transaction;
        private string sp_Name = " uspSelectBASKET_MASTER";

        public bool ExecuteQuery()
        {
            bool flag;
            try
            {
                IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "uspSelectBASKET_MASTER";
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
                cmd.CommandText = "uspSelectBASKET_MASTER";
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
                cmd.CommandText = "uspSelectBASKET_MASTER";
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
                cmd.CommandText = "uspSelectBASKET_MASTER";
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
                this.m_IS_BASKET = Convert.ToBoolean(dr["IS_BASKET"]);
                this.m_IS_MULTIPLE = Convert.ToBoolean(dr["IS_MULTIPLE"]);
                this.m_DISTRIBUTOR_ID = Convert.ToInt32(dr["DISTRIBUTOR_ID"]);
                this.m_IS_AND = Convert.ToInt32(dr["IS_AND"]);
                this.m_BASKET_ID = Convert.ToInt32(dr["BASKET_ID"]);
                this.m_PROMOTION_ID = Convert.ToInt32(dr["PROMOTION_ID"]);
                this.m_SCHEME_ID = Convert.ToInt32(dr["SCHEME_ID"]);
                this.m_BASKET_ON = Convert.ToInt16(dr["BASKET_ON"]);
            }
        }

        public void GetParameterCollection(ref IDbCommand cmd)
        {
            IDataParameterCollection parameters = cmd.Parameters;
            IDataParameter parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
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
        }

        public int BASKET_ID
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

        public short BASKET_ON
        {
            get
            {
                return this.m_BASKET_ON;
            }
            set
            {
                this.m_BASKET_ON = value;
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

        public int IS_AND
        {
            get
            {
                return this.m_IS_AND;
            }
            set
            {
                this.m_IS_AND = value;
            }
        }

        public bool IS_BASKET
        {
            get
            {
                return this.m_IS_BASKET;
            }
            set
            {
                this.m_IS_BASKET = value;
            }
        }

        public bool IS_MULTIPLE
        {
            get
            {
                return this.m_IS_MULTIPLE;
            }
            set
            {
                this.m_IS_MULTIPLE = value;
            }
        }

        public int PROMOTION_ID
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

