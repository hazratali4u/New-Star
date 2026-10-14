namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class CreateUserController
    {
        public bool ChangePassword(int p_USER_ID, string p_PASSWORD, bool p_IS_ACTIVE)
        {
            IDbConnection connection = null;
            bool flag2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                flag2 = new UspChangePassword { Connection = connection, USER_ID = p_USER_ID, PASSWORD = p_PASSWORD, IS_ACTIVE = p_IS_ACTIVE }.ExecuteQuery();
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

        public bool Distributor_User(int p_DISTRIBUTOR_ID, string p_NICK_NAME, string p_USER_NAME, string p_PHONE, string p_FAX, string p_MOBILE, string p_EMAIL, string p_ADDRESS1, string p_ADDRESS2, string p_LOGIN_ID, string p_PASSWORD, int p_DESIGNATION_ID, bool p_IsActive, DateTime p_TIME_STAMP, DateTime p_LASTUPDATE_DATE, int p_ROLE_ID, int p_UserType_ID)
        {
            IDbConnection connection = null;
            bool flag2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                flag2 = new spInsertDISTRIBUTOR_USER { Connection = connection, DISTRIBUTOR_ID = p_DISTRIBUTOR_ID, USER_NAME = p_USER_NAME, PHONE = p_PHONE, USER_TYPE_ID = p_UserType_ID, EMAIL = p_EMAIL, ADDRESS1 = p_ADDRESS1, ADDRESS2 = p_ADDRESS2, LOGIN_ID = p_LOGIN_ID, PASSWORD = p_PASSWORD, TIME_STAMP = p_TIME_STAMP, LASTUPDATE_DATE = p_LASTUPDATE_DATE, ROLE_ID = p_ROLE_ID }.ExecuteQuery();
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

        public DataTable SelectDistributor_User_Login(int p_USER_ID, int p_DISTRIBUTOR_ID, string p_NICK_NAME, string p_USER_NAME, string p_PHONE, string p_FAX, string p_MOBILE, string p_EMAIL, string p_ADDRESS1, string p_ADDRESS2, string p_LOGIN_ID, string p_PASSWORD, int p_DESIGNATION_ID, bool p_IsActive, DateTime p_TIME_STAMP, DateTime p_LASTUPDATE_DATE, int p_ROLE_ID)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectDISTRIBUTOR_USER { Connection = connection, USER_ID = p_USER_ID, DISTRIBUTOR_ID = p_DISTRIBUTOR_ID, USER_NAME = p_USER_NAME, PHONE = p_PHONE, MOBILE = p_MOBILE, EMAIL = p_EMAIL, ADDRESS1 = p_ADDRESS1, ADDRESS2 = p_ADDRESS2, LOGIN_ID = p_LOGIN_ID, PASSWORD = p_PASSWORD, IS_ACTIVE = p_IsActive, TIME_STAMP = p_TIME_STAMP, LASTUPDATE_DATE = p_LASTUPDATE_DATE, ROLE_ID = p_ROLE_ID }.ExecuteTable();
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

        public bool UpdateDistributor_User(int p_USER_ID, int p_DISTRIBUTOR_ID, string p_NICK_NAME, string p_USER_NAME, string p_PHONE, string p_FAX, string p_MOBILE, string p_EMAIL, string p_ADDRESS1, string p_ADDRESS2, string p_LOGIN_ID, string p_PASSWORD, int p_DESIGNATION_ID, bool p_IS_ACTIVE, DateTime p_TIME_STAMP, DateTime p_LASTUPDATE_DATE, int p_ROLE_ID, int p_USERTYPE_ID)
        {
            IDbConnection connection = null;
            bool flag2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                flag2 = new spUpdateDISTRIBUTOR_USER { Connection = connection, USER_ID = p_USER_ID, DISTRIBUTOR_ID = p_DISTRIBUTOR_ID, USER_NAME = p_USER_NAME, PHONE = p_PHONE, MOBILE = p_MOBILE, ADDRESS1 = p_ADDRESS1, ADDRESS2 = p_ADDRESS2, IS_ACTIVE = p_IS_ACTIVE, TIME_STAMP = p_TIME_STAMP, LASTUPDATE_DATE = p_LASTUPDATE_DATE }.ExecuteQuery();
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

