namespace SAMS.DatabaseLayer.Classes
{
    using SAMS.DataAccessLayer.Classes;
    using System;
    using System.Data;

    public class uspSelectPROMOTION
    {
        private bool m_CLAIMABLE;
        private IDbConnection m_connection;
        private int m_DISTRIBUTOR_ID;
        private DateTime m_END_DATE;
        private bool m_IS_ACTIVE;
        private DateTime m_PROMO_DATE;
        private string m_PROMOTION_CODE;
        private string m_PROMOTION_DESCRIPTION;
        private int m_PROMOTION_ID;
        private int m_PROMOTION_SELECTION;
        private int m_PROMOTION_TYPE;
        private int m_SCHEME_ID;
        private DateTime m_START_DATE;
        private IDbTransaction m_transaction;
        private string sp_Name = " uspSelectPROMOTION";

        public bool ExecuteQuery()
        {
            bool flag;
            try
            {
                IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "uspSelectPROMOTION";
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
                cmd.CommandText = "uspSelectPROMOTION";
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
                cmd.CommandText = "uspSelectPROMOTION";
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
                cmd.CommandText = "uspSelectPROMOTION";
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
                this.m_CLAIMABLE = Convert.ToBoolean(dr["CLAIMABLE"]);
                this.m_IS_ACTIVE = Convert.ToBoolean(dr["IS_ACTIVE"]);
                this.m_PROMO_DATE = Convert.ToDateTime(dr["PROMO_DATE"]);
                this.m_START_DATE = Convert.ToDateTime(dr["START_DATE"]);
                this.m_END_DATE = Convert.ToDateTime(dr["END_DATE"]);
                this.m_PROMOTION_TYPE = Convert.ToInt32(dr["PROMOTION_TYPE"]);
                this.m_PROMOTION_SELECTION = Convert.ToInt32(dr["PROMOTION_SELECTION"]);
                this.m_PROMOTION_ID = Convert.ToInt32(dr["PROMOTION_ID"]);
                this.m_SCHEME_ID = Convert.ToInt32(dr["SCHEME_ID"]);
                this.m_DISTRIBUTOR_ID = Convert.ToInt32(dr["DISTRIBUTOR_ID"]);
                this.m_PROMOTION_CODE = Convert.ToString(dr["PROMOTION_CODE"]);
                this.m_PROMOTION_DESCRIPTION = Convert.ToString(dr["PROMOTION_DESCRIPTION"]);
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

        public bool CLAIMABLE
        {
            get
            {
                return this.m_CLAIMABLE;
            }
            set
            {
                this.m_CLAIMABLE = value;
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

        public DateTime END_DATE
        {
            get
            {
                return this.m_END_DATE;
            }
            set
            {
                this.m_END_DATE = value;
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

        public DateTime PROMO_DATE
        {
            get
            {
                return this.m_PROMO_DATE;
            }
            set
            {
                this.m_PROMO_DATE = value;
            }
        }

        public string PROMOTION_CODE
        {
            get
            {
                return this.m_PROMOTION_CODE;
            }
            set
            {
                this.m_PROMOTION_CODE = value;
            }
        }

        public string PROMOTION_DESCRIPTION
        {
            get
            {
                return this.m_PROMOTION_DESCRIPTION;
            }
            set
            {
                this.m_PROMOTION_DESCRIPTION = value;
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

        public int PROMOTION_SELECTION
        {
            get
            {
                return this.m_PROMOTION_SELECTION;
            }
            set
            {
                this.m_PROMOTION_SELECTION = value;
            }
        }

        public int PROMOTION_TYPE
        {
            get
            {
                return this.m_PROMOTION_TYPE;
            }
            set
            {
                this.m_PROMOTION_TYPE = value;
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

        public DateTime START_DATE
        {
            get
            {
                return this.m_START_DATE;
            }
            set
            {
                this.m_START_DATE = value;
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

