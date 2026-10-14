namespace SAMS.DatabaseLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using System;
    using System.Data;

    public class RptOutletWiseSale
    {
        private string m_Catagory_IDs;
        private IDbConnection m_connection;
        private int m_Distributor_ID;
        private DateTime m_FromDate;
        private int m_Principal_ID;
        private DateTime m_ToDate;
        private IDbTransaction m_transaction;
        private string sp_Name = " RptOutletWiseSale";

        public bool ExecuteQuery()
        {
            bool flag;
            try
            {
                IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "RptOutletWiseSale";
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
                cmd.CommandText = "RptOutletWiseSale";
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
                cmd.CommandText = "RptOutletWiseSale";
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
                cmd.CommandText = "RptOutletWiseSale";
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
                this.m_Principal_ID = Convert.ToInt32(dr["Principal_ID"]);
                this.m_Distributor_ID = Convert.ToInt32(dr["Distributor_ID"]);
                this.m_FromDate = Convert.ToDateTime(dr["FromDate"]);
                this.m_ToDate = Convert.ToDateTime(dr["ToDate"]);
                this.m_Catagory_IDs = Convert.ToString(dr["Catagory_IDs"]);
            }
        }

        public void GetParameterCollection(ref IDbCommand cmd)
        {
            IDataParameterCollection parameters = cmd.Parameters;
            IDataParameter parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@Principal_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_Principal_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_Principal_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@Distributor_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_Distributor_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_Distributor_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@FromDate";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
            if (this.m_FromDate == Constants.DateNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_FromDate;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@ToDate";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
            if (this.m_ToDate == Constants.DateNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_ToDate;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@Catagory_IDs";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_Catagory_IDs == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_Catagory_IDs;
            }
            parameters.Add(parameter);
        }

        public string Catagory_IDs
        {
            get
            {
                return this.m_Catagory_IDs;
            }
            set
            {
                this.m_Catagory_IDs = value;
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

        public int Distributor_ID
        {
            get
            {
                return this.m_Distributor_ID;
            }
            set
            {
                this.m_Distributor_ID = value;
            }
        }

        public DateTime FromDate
        {
            get
            {
                return this.m_FromDate;
            }
            set
            {
                this.m_FromDate = value;
            }
        }

        public int Principal_ID
        {
            get
            {
                return this.m_Principal_ID;
            }
            set
            {
                this.m_Principal_ID = value;
            }
        }

        public DateTime ToDate
        {
            get
            {
                return this.m_ToDate;
            }
            set
            {
                this.m_ToDate = value;
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

