namespace SAMS.DatabaseLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using System;
    using System.Data;

    public class spInsertUSER_ATTENDANCE
    {
        private DateTime m_ATTENDANCE_DATE;
        private int m_ATTENDANCE_FOR;
        private long m_ATTENDANCE_ID;
        private int m_ATTENDANCE_MARKED_BY;
        private IDbConnection m_connection;
        private int m_DISTRIBUTOR_ID;
        private bool m_HOLIDAY;
        private bool m_IS_PRESENT;
        private bool m_L_C_A;
        private bool m_L_O_S;
        private decimal m_MAINTENANCE;
        private decimal m_MILEAGE;
        private bool m_O_S;
        private DateTime m_TIME_IN;
        private DateTime m_TIME_OUT;
        private IDbTransaction m_transaction;
        private string sp_Name = " spInsertUSER_ATTENDANCE";

        public bool ExecuteQuery()
        {
            try
            {
                IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spInsertUSER_ATTENDANCE";
                cmd.Connection = this.m_connection;
                this.GetParameterCollection(ref cmd);
                cmd.ExecuteNonQuery();
                this.m_ATTENDANCE_ID = (long) ((IDataParameter) cmd.Parameters["@ATTENDANCE_ID"]).Value;
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
                cmd.CommandText = "spInsertUSER_ATTENDANCE";
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
                cmd.CommandText = "spInsertUSER_ATTENDANCE";
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
                cmd.CommandText = "spInsertUSER_ATTENDANCE";
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
                this.m_ATTENDANCE_ID = Convert.ToInt64(row["ATTENDANCE_ID"]);
                this.m_O_S = Convert.ToBoolean(row["O_S"]);
                this.m_HOLIDAY = Convert.ToBoolean(row["HOLIDAY"]);
                this.m_IS_PRESENT = Convert.ToBoolean(row["IS_PRESENT"]);
                this.m_L_C_A = Convert.ToBoolean(row["L_C_A"]);
                this.m_L_O_S = Convert.ToBoolean(row["L_O_S"]);
                this.m_ATTENDANCE_DATE = Convert.ToDateTime(row["ATTENDANCE_DATE"]);
                this.m_TIME_IN = Convert.ToDateTime(row["TIME_IN"]);
                this.m_TIME_OUT = Convert.ToDateTime(row["TIME_OUT"]);
                this.m_MAINTENANCE = Convert.ToDecimal(row["MAINTENANCE"]);
                this.m_DISTRIBUTOR_ID = Convert.ToInt32(row["DISTRIBUTOR_ID"]);
                this.m_ATTENDANCE_MARKED_BY = Convert.ToInt32(row["ATTENDANCE_MARKED_BY"]);
                this.m_ATTENDANCE_FOR = Convert.ToInt32(row["ATTENDANCE_FOR"]);
                this.m_MILEAGE = Convert.ToDecimal(row["MILEAGE"]);
            }
        }

        public void GetParameterCollection(ref IDbCommand cmd)
        {
            IDataParameterCollection parameters = cmd.Parameters;
            IDataParameter parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@ATTENDANCE_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
            parameter.Direction = ParameterDirection.Output;
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@O_S";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
            parameter.Value = this.m_O_S;
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@HOLIDAY";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
            parameter.Value = this.m_HOLIDAY;
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@IS_PRESENT";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
            parameter.Value = this.m_IS_PRESENT;
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@L_C_A";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
            parameter.Value = this.m_L_C_A;
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@L_O_S";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
            parameter.Value = this.m_L_O_S;
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@ATTENDANCE_DATE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
            if (this.m_ATTENDANCE_DATE == Constants.DateNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_ATTENDANCE_DATE;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@TIME_IN";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
            if (this.m_TIME_IN == Constants.DateNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_TIME_IN;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@TIME_OUT";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
            if (this.m_TIME_OUT == Constants.DateNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_TIME_OUT;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@MAINTENANCE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Decimal);
            if (this.m_MAINTENANCE == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_MAINTENANCE;
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
            parameter.ParameterName = "@ATTENDANCE_MARKED_BY";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_ATTENDANCE_MARKED_BY == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_ATTENDANCE_MARKED_BY;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@ATTENDANCE_FOR";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (this.m_ATTENDANCE_FOR == -2147483648)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_ATTENDANCE_FOR;
            }
            parameters.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@MILEAGE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Decimal);
            if (this.m_MILEAGE == -79228162514264337593543950335M)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = this.m_MILEAGE;
            }
            parameters.Add(parameter);
        }

        public DateTime ATTENDANCE_DATE
        {
            get
            {
                return this.m_ATTENDANCE_DATE;
            }
            set
            {
                this.m_ATTENDANCE_DATE = value;
            }
        }

        public int ATTENDANCE_FOR
        {
            get
            {
                return this.m_ATTENDANCE_FOR;
            }
            set
            {
                this.m_ATTENDANCE_FOR = value;
            }
        }

        public long ATTENDANCE_ID
        {
            get
            {
                return this.m_ATTENDANCE_ID;
            }
            set
            {
                this.m_ATTENDANCE_ID = value;
            }
        }

        public int ATTENDANCE_MARKED_BY
        {
            get
            {
                return this.m_ATTENDANCE_MARKED_BY;
            }
            set
            {
                this.m_ATTENDANCE_MARKED_BY = value;
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

        public bool HOLIDAY
        {
            get
            {
                return this.m_HOLIDAY;
            }
            set
            {
                this.m_HOLIDAY = value;
            }
        }

        public bool IS_PRESENT
        {
            get
            {
                return this.m_IS_PRESENT;
            }
            set
            {
                this.m_IS_PRESENT = value;
            }
        }

        public bool L_C_A
        {
            get
            {
                return this.m_L_C_A;
            }
            set
            {
                this.m_L_C_A = value;
            }
        }

        public bool L_O_S
        {
            get
            {
                return this.m_L_O_S;
            }
            set
            {
                this.m_L_O_S = value;
            }
        }

        public decimal MAINTENANCE
        {
            get
            {
                return this.m_MAINTENANCE;
            }
            set
            {
                this.m_MAINTENANCE = value;
            }
        }

        public decimal MILEAGE
        {
            get
            {
                return this.m_MILEAGE;
            }
            set
            {
                this.m_MILEAGE = value;
            }
        }

        public bool O_S
        {
            get
            {
                return this.m_O_S;
            }
            set
            {
                this.m_O_S = value;
            }
        }

        public DateTime TIME_IN
        {
            get
            {
                return this.m_TIME_IN;
            }
            set
            {
                this.m_TIME_IN = value;
            }
        }

        public DateTime TIME_OUT
        {
            get
            {
                return this.m_TIME_OUT;
            }
            set
            {
                this.m_TIME_OUT = value;
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

