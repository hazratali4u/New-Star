namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class LocationController
    {
        public bool InsertLocation(string p_LOCATION_NAME, string p_LOCATION_SHORT_NAME, string p_PHONE_NO, string p_MOBILE_NO, string p_FAX_NO, string p_EMAIL, DateTime p_OPENING_DATE, DateTime p_CLOSING_DATE, string p_REGISTRATION_NO, string p_ADDRESS, int p_TOWN_ID, bool p_INPUT_ACTIVE, bool p_OUTPUT_ACTIVE, int p_LOCATION_TYPE_ID, string p_CONTACT_PERSON)
        {
            IDbConnection connection = null;
            bool flag2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                flag2 = new spInsertLOCATION { Connection = connection, LOCATION_NAME = p_LOCATION_NAME, LOCATION_SHORT_NAME = p_LOCATION_SHORT_NAME, PHONE_NO = p_PHONE_NO, MOBILE_NO = p_MOBILE_NO, FAX_NO = p_FAX_NO, EMAIL = p_EMAIL, OPENING_DATE = p_OPENING_DATE, CLOSING_DATE = p_CLOSING_DATE, REGISTRATION_NO = p_REGISTRATION_NO, ADDRESS = p_ADDRESS, TOWN_ID = p_TOWN_ID, INPUT_ACTIVE = p_INPUT_ACTIVE, OUTPUT_ACTIVE = p_OUTPUT_ACTIVE, LOCATION_TYPE_ID = p_LOCATION_TYPE_ID, CONTACT_PERSON = p_CONTACT_PERSON }.ExecuteQuery();
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

        public DataTable Select_Location(int p_LOCATION_ID, string p_LOCATION_NAME, string p_LOCATION_SHORT_NAME, string p_PHONE_NO, string p_MOBILE_NO, string p_FAX_NO, string p_EMAIL, DateTime p_OPENING_DATE, DateTime p_CLOSING_DATE, string p_REGISTRATION_NO, string p_ADDRESS, int p_TOWN_ID, bool p_INPUT_ACTIVE, bool p_OUTPUT_ACTIVE, int p_LOCATION_TYPE_ID, string p_CONTACT_PERSON)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectLOCATION { 
                    Connection = connection, LOCATION_ID = p_LOCATION_ID, LOCATION_NAME = p_LOCATION_NAME, LOCATION_SHORT_NAME = p_LOCATION_SHORT_NAME, PHONE_NO = p_PHONE_NO, MOBILE_NO = p_MOBILE_NO, FAX_NO = p_FAX_NO, EMAIL = p_EMAIL, OPENING_DATE = p_OPENING_DATE, CLOSING_DATE = p_CLOSING_DATE, REGISTRATION_NO = p_REGISTRATION_NO, ADDRESS = p_ADDRESS, TOWN_ID = p_TOWN_ID, INPUT_ACTIVE = p_INPUT_ACTIVE, OUTPUT_ACTIVE = p_OUTPUT_ACTIVE, LOCATION_TYPE_ID = p_LOCATION_TYPE_ID, 
                    CONTACT_PERSON = p_CONTACT_PERSON
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

        public bool UpdateLocation(int p_LOCATION_ID, string p_LOCATION_NAME, string p_LOCATION_SHORT_NAME, string p_PHONE_NO, string p_MOBILE_NO, string p_FAX_NO, string p_EMAIL, DateTime p_OPENING_DATE, DateTime p_CLOSING_DATE, string p_REGISTRATION_NO, string p_ADDRESS, int p_TOWN_ID, bool p_INPUT_ACTIVE, bool p_OUTPUT_ACTIVE, int p_LOCATION_TYPE_ID, string p_CONTACT_PERSON)
        {
            IDbConnection connection = null;
            bool flag2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                flag2 = new spUpdateLOCATION { 
                    Connection = connection, LOCATION_ID = p_LOCATION_ID, LOCATION_NAME = p_LOCATION_NAME, LOCATION_SHORT_NAME = p_LOCATION_SHORT_NAME, PHONE_NO = p_PHONE_NO, MOBILE_NO = p_MOBILE_NO, FAX_NO = p_FAX_NO, EMAIL = p_EMAIL, OPENING_DATE = p_OPENING_DATE, CLOSING_DATE = p_CLOSING_DATE, REGISTRATION_NO = p_REGISTRATION_NO, ADDRESS = p_ADDRESS, TOWN_ID = p_TOWN_ID, INPUT_ACTIVE = p_INPUT_ACTIVE, OUTPUT_ACTIVE = p_OUTPUT_ACTIVE, LOCATION_TYPE_ID = p_LOCATION_TYPE_ID, 
                    CONTACT_PERSON = p_CONTACT_PERSON
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

