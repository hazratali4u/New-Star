namespace SAMS.DatabaseLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using System;
    using System.Data;

    public class uspUpdatePURCHASE_MASTER
    {
        private int m_BILL_TO;
        private IDbConnection m_connection;
        private int m_DISTRIBUTOR_ID;
        private DateTime m_DOCUMENT_DATE;
        private string m_ORDER_NUMBER;
        private long m_PARENT_ID;
        private int m_SHIP_TO;
        private int m_SOLD_FROM;
        private int m_SOLD_TO;
        private int m_SOLD_TYPE;
        private int m_STATUS_ID;
        private DateTime m_TIME_STAMP;
        private decimal m_TOTAL_AMOUNT;
        private decimal m_TOTAL_GST_AMOUNT;
        private decimal m_TOTAL_NET_AMOUNT;
        private IDbTransaction m_transaction;
        private int m_TYPE_ID;
        private string sp_Name = " uspUpdatePURCHASE_MASTER";

        public bool ExecuteQuery()
        {
            bool flag;
            try
            {
                IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "uspUpdatePURCHASE_MASTER";
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
                cmd.CommandText = "uspUpdatePURCHASE_MASTER";
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
                cmd.CommandText = "uspUpdatePURCHASE_MASTER";
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
                cmd.CommandText = "uspUpdatePURCHASE_MASTER";
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
                this.m_PARENT_ID = Convert.ToInt64(dr["PARENT_ID"]);
                this.m_DOCUMENT_DATE = Convert.ToDateTime(dr["DOCUMENT_DATE"]);
                this.m_TIME_STAMP = Convert.ToDateTime(dr["TIME_STAMP"]);
                this.m_SOLD_FROM = Convert.ToInt32(dr["SOLD_FROM"]);
                this.m_SOLD_TYPE = Convert.ToInt32(dr["SOLD_TYPE"]);
                this.m_SHIP_TO = Convert.ToInt32(dr["SHIP_TO"]);
                this.m_TYPE_ID = Convert.ToInt32(dr["TYPE_ID"]);
                this.m_STATUS_ID = Convert.ToInt32(dr["STATUS_ID"]);
                this.m_DISTRIBUTOR_ID = Convert.ToInt32(dr["DISTRIBUTOR_ID"]);
                this.m_SOLD_TO = Convert.ToInt32(dr["SOLD_TO"]);
                this.m_BILL_TO = Convert.ToInt32(dr["BILL_TO"]);
                this.m_TOTAL_AMOUNT = Convert.ToDecimal(dr["TOTAL_AMOUNT"]);
                this.m_TOTAL_NET_AMOUNT = Convert.ToDecimal(dr["TOTAL_NET_AMOUNT"]);
                this.m_TOTAL_GST_AMOUNT = Convert.ToDecimal(dr["TOTAL_GST_AMOUNT"]);
                this.m_ORDER_NUMBER = Convert.ToString(dr["ORDER_NUMBER"]);
            }
        }

        public void GetParameterCollection(ref IDbCommand cmd)
        {
            IDataParameterCollection parameters = cmd.Parameters;
            IDataParameter parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@PARENT_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
            if (this.m_PARENT_ID == -9223372036854775808L)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_PARENT_ID;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@DOCUMENT_DATE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
            if (this.m_DOCUMENT_DATE == Constants.DateNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_DOCUMENT_DATE;
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
            parameter.ParameterName = "@SOLD_FROM";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_SOLD_FROM == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_SOLD_FROM;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@SOLD_TYPE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_SOLD_TYPE == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_SOLD_TYPE;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@SHIP_TO";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_SHIP_TO == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_SHIP_TO;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@TYPE_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_TYPE_ID == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_TYPE_ID;
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
            parameter.ParameterName = "@SOLD_TO";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_SOLD_TO == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_SOLD_TO;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@BILL_TO";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_BILL_TO == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_BILL_TO;
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
            parameter.ParameterName = "@TOTAL_GST_AMOUNT";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
            if (this.m_TOTAL_GST_AMOUNT == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_TOTAL_GST_AMOUNT;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@ORDER_NUMBER";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (this.m_ORDER_NUMBER == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_ORDER_NUMBER;
            }
            parameters.Add(parameter);
        }

        public int BILL_TO
        {
            get
            {
                return this.m_BILL_TO;
            }
            set
            {
                this.m_BILL_TO = value;
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

        public DateTime DOCUMENT_DATE
        {
            get
            {
                return this.m_DOCUMENT_DATE;
            }
            set
            {
                this.m_DOCUMENT_DATE = value;
            }
        }

        public string ORDER_NUMBER
        {
            get
            {
                return this.m_ORDER_NUMBER;
            }
            set
            {
                this.m_ORDER_NUMBER = value;
            }
        }

        public long PARENT_ID
        {
            get
            {
                return this.m_PARENT_ID;
            }
            set
            {
                this.m_PARENT_ID = value;
            }
        }

        public int SHIP_TO
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

        public int SOLD_FROM
        {
            get
            {
                return this.m_SOLD_FROM;
            }
            set
            {
                this.m_SOLD_FROM = value;
            }
        }

        public int SOLD_TO
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

        public int SOLD_TYPE
        {
            get
            {
                return this.m_SOLD_TYPE;
            }
            set
            {
                this.m_SOLD_TYPE = value;
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

        public decimal TOTAL_GST_AMOUNT
        {
            get
            {
                return this.m_TOTAL_GST_AMOUNT;
            }
            set
            {
                this.m_TOTAL_GST_AMOUNT = value;
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

        public int TYPE_ID
        {
            get
            {
                return this.m_TYPE_ID;
            }
            set
            {
                this.m_TYPE_ID = value;
            }
        }
    }
}

