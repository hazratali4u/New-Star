namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class CreateCustomerController
    {
        public bool InsertCustomer(string p_CUSTOMER_NAME, string p_CUSTOMER_SHORTNAME, string p_CONTACT_PERSON, string p_PHONE_NO, string p_MOBILE_NO, string p_EMAIL, int p_LOCATION_ID, string p_GST_NO, string p_ADDRESS, string p_MARKET, string p_ROUTE, string p_HOME_TOWN, int p_BUSSINESS_TYPE_ID, int p_CUSTOMER_TYPE_ID, int p_CHANNEL_TYPE_ID, int p_VOLUME_CLASS_ID, DateTime p_TIMESTAMP)
        {
            IDbConnection connection = null;
            bool flag2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                flag2 = new spInsertCREATE_CUSTOMER { 
                    Connection = connection, CUSTOMER_NAME = p_CUSTOMER_NAME, CUSTOMER_SHORTNAME = p_CUSTOMER_SHORTNAME, CONTACT_PERSON = p_CONTACT_PERSON, PHONE_NO = p_PHONE_NO, MOBILE_NO = p_MOBILE_NO, EMAIL = p_EMAIL, LOCATION_ID = p_LOCATION_ID, GST_NO = p_GST_NO, ADDRESS = p_ADDRESS, MARKET = p_MARKET, ROUTE = p_ROUTE, HOME_TOWN = p_HOME_TOWN, BUSSINESS_TYPE_ID = p_BUSSINESS_TYPE_ID, CUSTOMER_TYPE_ID = p_CUSTOMER_TYPE_ID, CHANNEL_TYPE_ID = p_CHANNEL_TYPE_ID, 
                    VOLUME_CLASS_ID = p_VOLUME_CLASS_ID, TIMESTAMP = p_TIMESTAMP
                 }.ExecuteQuery();
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                flag2 = false;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return flag2;
        }

        public DataTable SelectCustomer(int p_CUSTOMER_ID, string p_CUSTOMER_NAME, string p_CUSTOMER_SHORTNAME, string p_CONTACT_PERSON, string p_PHONE_NO, string p_MOBILE_NO, string p_EMAIL, int p_LOCATION_ID, string p_GST_NO, string p_ADDRESS, string p_MARKET, string p_ROUTE, string p_HOME_TOWN, int p_BUSSINESS_TYPE_ID, int p_CUSTOMER_TYPE_ID, int p_CHANNEL_TYPE_ID, int p_VOLUME_CLASS_ID, DateTime p_TIMESTAMP)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectCREATE_CUSTOMER { 
                    Connection = connection, CUSTOMER_ID = p_CUSTOMER_ID, CUSTOMER_NAME = p_CUSTOMER_NAME, CUSTOMER_SHORTNAME = p_CUSTOMER_SHORTNAME, CONTACT_PERSON = p_CONTACT_PERSON, PHONE_NO = p_PHONE_NO, MOBILE_NO = p_MOBILE_NO, EMAIL = p_EMAIL, LOCATION_ID = p_LOCATION_ID, GST_NO = p_GST_NO, ADDRESS = p_ADDRESS, MARKET = p_MARKET, ROUTE = p_ROUTE, HOME_TOWN = p_HOME_TOWN, BUSSINESS_TYPE_ID = p_BUSSINESS_TYPE_ID, CUSTOMER_TYPE_ID = p_CUSTOMER_TYPE_ID, 
                    CHANNEL_TYPE_ID = p_CHANNEL_TYPE_ID, VOLUME_CLASS_ID = p_VOLUME_CLASS_ID, TIMESTAMP = p_TIMESTAMP
                 }.ExecuteTable();
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

        public bool UpdateCustomer(int p_CUSTOMER_ID, string p_CUSTOMER_NAME, string p_CUSTOMER_SHORTNAME, string p_CONTACT_PERSON, string p_PHONE_NO, string p_MOBILE_NO, string p_EMAIL, int p_LOCATION_ID, string p_GST_NO, string p_ADDRESS, string p_MARKET, string p_ROUTE, string p_HOME_TOWN, int p_BUSSINESS_TYPE_ID, int p_CUSTOMER_TYPE_ID, int p_CHANNEL_TYPE_ID, int p_VOLUME_CLASS_ID, DateTime p_TIMESTAMP)
        {
            IDbConnection connection = null;
            bool flag2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                flag2 = new spUpdateCREATE_CUSTOMER { 
                    Connection = connection, CUSTOMER_ID = p_CUSTOMER_ID, CUSTOMER_NAME = p_CUSTOMER_NAME, CUSTOMER_SHORTNAME = p_CUSTOMER_SHORTNAME, CONTACT_PERSON = p_CONTACT_PERSON, PHONE_NO = p_PHONE_NO, MOBILE_NO = p_MOBILE_NO, EMAIL = p_EMAIL, LOCATION_ID = p_LOCATION_ID, GST_NO = p_GST_NO, ADDRESS = p_ADDRESS, MARKET = p_MARKET, ROUTE = p_ROUTE, HOME_TOWN = p_HOME_TOWN, BUSSINESS_TYPE_ID = p_BUSSINESS_TYPE_ID, CUSTOMER_TYPE_ID = p_CUSTOMER_TYPE_ID, 
                    CHANNEL_TYPE_ID = p_CHANNEL_TYPE_ID, VOLUME_CLASS_ID = p_VOLUME_CLASS_ID, TIMESTAMP = p_TIMESTAMP
                 }.ExecuteQuery();
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                flag2 = false;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return flag2;
        }
    }
}

