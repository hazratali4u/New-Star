namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class ControllerWarehouse
    {
        public string InsertWarehouse(string I_Warehouse_code, string I_Warehouse_name, string I_Warehouse_Address, string I_Contact_Person, string I_Contact_Phone, int I_User_Id, string I_IPAddress, bool I_Isdeleted, int I_virtual)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                spInsertWAREHOUSES twarehouses = new spInsertWAREHOUSES {
                    Connection = connection,
                    WAREHOUSE_CODE = I_Warehouse_code,
                    WAREHOUSE_NAME = I_Warehouse_name,
                    WHAREHOUSE_ADDRESS = I_Warehouse_Address,
                    CONTACT_PERSON = I_Contact_Person,
                    CONTACT_PHONE = I_Contact_Phone,
                    TIME_STAMP = DateTime.Now,
                    LASTUPDATE_DATE = DateTime.Now,
                    USER_ID = I_User_Id,
                    IPAddress = I_IPAddress,
                    ISDELETED = I_Isdeleted,
                    IS_VIRTUAL = I_virtual
                };
                twarehouses.ExecuteQuery();
                message = twarehouses.WAREHOUSE_ID.ToString();
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                message = exception.Message;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return message;
        }

        public DataTable Select_Warehouse(string WarehouseCode)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                table2 = new spSelectWAREHOUSES { Connection = connection, WAREHOUSE_ID = -9223372036854775808L, WAREHOUSE_CODE = WarehouseCode, WAREHOUSE_NAME = null, WHAREHOUSE_ADDRESS = null, CONTACT_PERSON = null, CONTACT_PHONE = null, ISDELETED = false, IS_VIRTUAL = -2147483648, USER_ID = -2147483648, TIME_STAMP = Constants.DateNullValue, LASTUPDATE_DATE = Constants.DateNullValue, IPAddress = null }.ExecuteTable();
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

        public DataTable SelectRegion()
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                table2 = new spSelecttmpRegion { Connection = connection, RegionCode = null, RegionName = null, CheckDistributor = false }.ExecuteTable();
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

        public string updateWarehouse(long I_WareHouse_Id, string I_Warehouse_code, string I_Warehouse_name, string I_Warehouse_Address, string I_Contact_Person, string I_Contact_Phone, int I_User_Id, string I_IPAddress, bool I_Isdeleted, int I_virtual)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spUpdateWAREHOUSES { Connection = connection, WAREHOUSE_ID = I_WareHouse_Id, WAREHOUSE_CODE = I_Warehouse_code, WAREHOUSE_NAME = I_Warehouse_name, WHAREHOUSE_ADDRESS = I_Warehouse_Address, CONTACT_PERSON = I_Contact_Person, CONTACT_PHONE = I_Contact_Phone, TIME_STAMP = DateTime.Now, LASTUPDATE_DATE = DateTime.Now, USER_ID = I_User_Id, IPAddress = I_IPAddress, ISDELETED = I_Isdeleted, IS_VIRTUAL = I_virtual }.ExecuteQuery();
                message = "Record Update";
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                message = exception.Message;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return message;
        }
    }
}

