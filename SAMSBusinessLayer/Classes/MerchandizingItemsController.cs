namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class MerchandizingItemsController
    {
        public static bool InsertMerchandizingItems(string p_MI_Code, string p_MI_Name, string p_MI_Desc, int p_MI_Type, decimal p_MI_Point, string p_Ip_Address)
        {
            IDbConnection connection = null;
            bool flag;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spInsertMerchandizing_Items { Connection = connection, IP_ADDRESS = p_Ip_Address, IS_ACTIVE = true, MI_CODE = p_MI_Code, MI_DESC = p_MI_Desc, MI_NAME = p_MI_Name, MI_TYPE = p_MI_Type, MI_POINT = p_MI_Point, TIME_STAMP = DateTime.Now, USER_ID = Configuration.UserID }.ExecuteQuery();
                flag = true;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                flag = false;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return flag;
        }

        public static bool InsertMerchandizingItemsAssignment(int p_Distributor_ID, int p_Distributor_Type_ID, string p_Ip_Address, long p_Merchandizing_ItemID, int p_Quantity)
        {
            IDbConnection connection = null;
            bool flag;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spInsertMerchandizing_Items_Assignment { Connection = connection, DISTRIBUTOR_ID = p_Distributor_ID, DISTRIBUTOR_TYPE_ID = p_Distributor_Type_ID, IP_ADDDRESS = p_Ip_Address, IS_ACTIVE = true, MI_ID = p_Merchandizing_ItemID, QUANTITY = p_Quantity, TIME_STAMP = DateTime.Now, USER_ID = Configuration.UserID }.ExecuteQuery();
                flag = true;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                flag = false;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return flag;
        }

        public static DataTable SelectAllMerchandizingItems()
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectMerchandizing_Items { Connection = connection, IP_ADDRESS = null, IS_ACTIVE = 1, MI_CODE = null, MI_DESC = null, MI_ID = -9223372036854775808L, MI_NAME = null, MI_TYPE = -2147483648, MI_POINT = -79228162514264337593543950335M, TIME_STAMP = Constants.DateNullValue, USER_ID = -2147483648 }.ExecuteTable();
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

        public static DataTable SelectAllMerchandizingItemsAssignment()
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectMerchandizing_Items_Assignment { Connection = connection, DISTRIBUTOR_ID = -2147483648, DISTRIBUTOR_TYPE_ID = -2147483648, IP_ADDDRESS = null, IS_ACTIVE = 1, MI_ID = -9223372036854775808L, MIA_ID = -9223372036854775808L, QUANTITY = -2147483648, TIME_STAMP = Constants.DateNullValue, USER_ID = -2147483648 }.ExecuteTable();
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

        public static DataTable SelectAllTLPGiftItems()
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectMerchandizing_Items { Connection = connection, IP_ADDRESS = null, IS_ACTIVE = 1, MI_CODE = null, MI_DESC = null, MI_ID = -9223372036854775808L, MI_NAME = null, MI_TYPE = 1, MI_POINT = -79228162514264337593543950335M, TIME_STAMP = Constants.DateNullValue, USER_ID = -2147483648 }.ExecuteTable();
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

        public static DataTable SelectMerchandizingItem(long p_Merchandizing_ItemID)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectMerchandizing_Items { Connection = connection, IP_ADDRESS = null, MI_TYPE = -2147483648, MI_POINT = -79228162514264337593543950335M, IS_ACTIVE = 1, MI_CODE = null, MI_DESC = null, MI_ID = p_Merchandizing_ItemID, MI_NAME = null, TIME_STAMP = Constants.DateNullValue, USER_ID = -2147483648 }.ExecuteTable();
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

        public static bool UpdateMerchandizingItems(string p_MI_Code, string p_MI_Name, string p_MI_Desc, long p_MI_ID, int p_MI_Type, decimal p_MI_Point, string p_Ip_Address)
        {
            IDbConnection connection = null;
            bool flag;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spUpdateMerchandizing_Items { Connection = connection, IP_ADDRESS = p_Ip_Address, IS_ACTIVE = true, MI_CODE = p_MI_Code, MI_DESC = p_MI_Desc, MI_NAME = p_MI_Name, MI_TYPE = p_MI_Type, MI_POINT = p_MI_Point, TIME_STAMP = Constants.DateNullValue, USER_ID = -2147483648, MI_ID = p_MI_ID }.ExecuteQuery();
                flag = true;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                flag = false;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return flag;
        }

        public static bool UpdateMerchandizingItemsAssignment(long p_Merchandizing_Item_AssignmentID, int p_Distributor_ID, int p_Distributor_Type_ID, long p_Merchandizing_ItemID, string p_Ip_Address, int p_Quantity)
        {
            IDbConnection connection = null;
            bool flag;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spUpdateMerchandizing_Items_Assignment { Connection = connection, DISTRIBUTOR_ID = p_Distributor_ID, DISTRIBUTOR_TYPE_ID = p_Distributor_Type_ID, IP_ADDDRESS = p_Ip_Address, IS_ACTIVE = true, MI_ID = p_Merchandizing_ItemID, MIA_ID = p_Merchandizing_Item_AssignmentID, QUANTITY = p_Quantity, TIME_STAMP = Constants.DateNullValue, USER_ID = -2147483648 }.ExecuteQuery();
                flag = true;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                flag = false;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return flag;
        }
    }
}

