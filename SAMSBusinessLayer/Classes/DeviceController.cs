namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class DeviceController
    {
        public void AllocateDevice(int p_DeviceId, int p_SalesForceId, int p_SequenceId)
        {
            IDbConnection connection = null;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                DataTable table = this.SelectCurrentDeviceAllocation(p_DeviceId);
                if ((table != null) && (table.Rows.Count > 0))
                {
                    int num = Convert.ToInt32(table.Rows[0]["DEVICE_ALLOCATION_ID"]);
                    new spUpdateDEVICE_ALLOCATION { Connection = connection, DEVICE_ALLOCATION_ID = num, DEVICE_ID = -2147483648, ORDERBOOKER_ID = -2147483648, ALLOC_FROM = Constants.DateNullValue, ALLOC_TO = DateTime.Now.Date, SEQUENCE_ID = p_SequenceId, IS_CURRENT = false, DISTRIBUTOR_ID = -2147483648, USER_ID = Configuration.UserID, TIME_STAMP = Constants.DateNullValue, LASTUPDATE_DATE = DateTime.Now, IS_ACTIVE = true }.ExecuteQuery();
                }
                new spInsertDEVICE_ALLOCATION { Connection = connection, DEVICE_ID = p_DeviceId, ORDERBOOKER_ID = p_SalesForceId, ALLOC_FROM = DateTime.Now.Date, ALLOC_TO = Constants.DateNullValue, SEQUENCE_ID = p_SequenceId, IS_CURRENT = true, DISTRIBUTOR_ID = Configuration.DistributorId, USER_ID = Configuration.UserID, TIME_STAMP = DateTime.Now, LASTUPDATE_DATE = DateTime.Now, IS_ACTIVE = true }.ExecuteQuery();
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
        }

        public string DeleteDevice(int p_Device_Id)
        {
            IDbConnection connection = null;
            string str;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spDeleteDEVICE { Connection = connection, DEVICE_ID = p_Device_Id }.ExecuteQuery();
                str = "Record Deleted";
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                str = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return str;
        }

        public int InsertDevice(string p_Device_Code, string p_Device_Prefix, string p_Device_Name, string p_Machine_No, DateTime p_Registered_On, int p_Distributor_Id)
        {
            IDbConnection connection = null;
            int num;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                spInsertDEVICE tdevice = new spInsertDEVICE {
                    Connection = connection,
                    DEVICE_CODE = p_Device_Code,
                    DEVICE_NAME = p_Device_Name,
                    DEVICE_PREFIX = p_Device_Prefix,
                    MACHINE_NO = p_Machine_No,
                    REGISTERED_ON = p_Registered_On,
                    DISTRIBUTOR_ID = p_Distributor_Id,
                    SEQUENCE_ID = 0,
                    USER_ID = Configuration.UserID,
                    IS_ACTIVE = true,
                    TIME_STAMP = DateTime.Now,
                    LASTUPDATE_DATE = DateTime.Now
                };
                tdevice.ExecuteQuery();
                num = tdevice.DEVICE_ID;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                num = -1;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return num;
        }

        public DataTable SelectAllDevice()
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectDEVICEInfo { Connection = connection, DEVICE_ID = -2147483648, DEVICE_CODE = null, DEVICE_NAME = null, MACHINE_NO = null, REGISTERED_ON = Constants.DateNullValue, DISTRIBUTOR_ID = Configuration.DistributorId }.ExecuteTable();
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                table2 = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return table2;
        }

        public DataTable SelectCurrentDeviceAllocation(int p_Device_Id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectDEVICEALLOCATIONCurrentInfo { Connection = connection, DEVICE_ID = p_Device_Id }.ExecuteTable();
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                table2 = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return table2;
        }

        public DataTable SelectDevice(int p_Device_Id, string p_Device_Code, string p_Device_Name, string p_Machine_No, DateTime p_Registered_On, int p_Distributor_Id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectDEVICEInfo { Connection = connection, DEVICE_ID = p_Device_Id, DEVICE_CODE = p_Device_Code, DEVICE_NAME = p_Device_Name, MACHINE_NO = p_Machine_No, REGISTERED_ON = p_Registered_On, DISTRIBUTOR_ID = p_Distributor_Id }.ExecuteTable();
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                table2 = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return table2;
        }

        public DataTable SelectDeviceAllocation(int p_Device_Id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectDEVICEALLOCATIONInfo { Connection = connection, DEVICE_ID = p_Device_Id }.ExecuteTable();
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                table2 = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return table2;
        }

        public void UpdateDevice(int p_Device_Id, string p_Device_Prefix, string p_Device_Name)
        {
            IDbConnection connection = null;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spUpdateDEVICE { Connection = connection, DEVICE_ID = p_Device_Id, DEVICE_CODE = null, DEVICE_PREFIX = p_Device_Prefix, DEVICE_NAME = p_Device_Name, MACHINE_NO = null, REGISTERED_ON = Constants.DateNullValue, SEQUENCE_ID = -2147483648, DISTRIBUTOR_ID = -2147483648, USER_ID = Configuration.UserID, IS_ACTIVE = true, TIME_STAMP = Constants.DateNullValue, LASTUPDATE_DATE = DateTime.Now }.ExecuteQuery();
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
        }

        public void UpdateDeviceSequenceId(int p_Device_Id, int p_SequenceId)
        {
            IDbConnection connection = null;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spUpdateDEVICE { Connection = connection, DEVICE_ID = p_Device_Id, DEVICE_CODE = null, DEVICE_PREFIX = null, DEVICE_NAME = null, MACHINE_NO = null, REGISTERED_ON = Constants.DateNullValue, SEQUENCE_ID = p_SequenceId, DISTRIBUTOR_ID = -2147483648, USER_ID = Configuration.UserID, IS_ACTIVE = true, TIME_STAMP = Constants.DateNullValue, LASTUPDATE_DATE = DateTime.Now }.ExecuteQuery();
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
        }
    }
}

