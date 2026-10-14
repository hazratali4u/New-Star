namespace SAMS.DatabaseLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using System;
    using System.Data;

    public class UspCustomerLedger
    {
        private IDbConnection m_connection;
        private int m_customer_id = -2147483648;
        private int m_Distributor_id = -2147483648;
        private DateTime m_From_Date = Constants.DateNullValue;
        private int m_principal_id = -2147483648;
        private DateTime m_To_Date = Constants.DateNullValue;
        private IDbTransaction m_transaction;
        private string sp_Name = "UspCustomerLedger";

        public bool ExecuteQuery()
        {
            bool flag;
            try
            {
                IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UspCustomerLedger";
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
                cmd.CommandText = "UspCustomerLedger";
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
                cmd.CommandText = "UspCustomerLedger";
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
                cmd.CommandText = "UspCustomerLedger";
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
                this.m_Distributor_id = Convert.ToInt32(dr["Distributor_id"]);
                this.m_principal_id = Convert.ToInt32(dr["principal_id"]);
                this.m_customer_id = Convert.ToInt32(dr["customer_id"]);
                this.m_From_Date = Convert.ToDateTime(dr["From_Date"]);
                this.m_To_Date = Convert.ToDateTime(dr["To_Date"]);
            }
        }

        public void GetParameterCollection(ref IDbCommand cmd)
        {
            IDataParameterCollection parameters = cmd.Parameters;
            IDataParameter parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@Distributor_id";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_Distributor_id == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_Distributor_id;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@principal_id";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_principal_id == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_principal_id;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@customer_id";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_customer_id == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_customer_id;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@From_Date";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
            if (this.m_From_Date == Constants.DateNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_From_Date;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@To_Date";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
            if (this.m_To_Date == Constants.DateNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_To_Date;
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

        public int customer_id
        {
            get
            {
                return this.m_customer_id;
            }
            set
            {
                this.m_customer_id = value;
            }
        }

        public int Distributor_id
        {
            get
            {
                return this.m_Distributor_id;
            }
            set
            {
                this.m_Distributor_id = value;
            }
        }

        public DateTime From_Date
        {
            get
            {
                return this.m_From_Date;
            }
            set
            {
                this.m_From_Date = value;
            }
        }

        public int principal_id
        {
            get
            {
                return this.m_principal_id;
            }
            set
            {
                this.m_principal_id = value;
            }
        }

        public DateTime To_Date
        {
            get
            {
                return this.m_To_Date;
            }
            set
            {
                this.m_To_Date = value;
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

