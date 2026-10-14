namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class SAMSUserController
    {
        public bool DeleteUserAssignment(int UserId, int DistributorTypeid, int DistributorId, int Companyid)
        {
            IDbConnection connection = null;
            bool flag2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                flag2 = new spDeleteDISTRIBUTOR_ASSIGNMENT { Connection = connection, USER_ID = UserId, DISTRIBUTOR_TYPE = DistributorTypeid, DISTRIBUTOR_ID = DistributorId, COMPANY_ID = Companyid }.ExecuteQuery();
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

        public string InsertSlashUser(int User_Id, int p_CompanyId, int p_DistributorId, string p_LoginId, string p_Password, int p_RoleId)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                spInsertSAMS_USER tsams_user = new spInsertSAMS_USER {
                    Connection = connection,
                    USER_ID = User_Id,
                    DISTRIBUTOR_ID = p_DistributorId,
                    COMPANY_ID = p_CompanyId,
                    LOGIN_ID = p_LoginId,
                    PASSWORD = p_Password,
                    ROLE_ID = p_RoleId,
                    LASTUPDATE_DATE = DateTime.Today
                };
                tsams_user.ExecuteQuery();
                message = tsams_user.USER_ID.ToString();
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

        public bool InsertUserAssignment(int UserId, int DistributorTypeid, int DistributorId, int Companyid)
        {
            IDbConnection connection = null;
            bool flag2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                flag2 = new spInsertDISTRIBUTOR_ASSIGNMENT { Connection = connection, USER_ID = UserId, DISTRIBUTOR_TYPE = DistributorTypeid, DISTRIBUTOR_ID = DistributorId, COMPANY_ID = Companyid }.ExecuteQuery();
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

        public DataTable SelectMaxDayClose(int UserId, int Distributor_id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectMaxDayClose { Connection = connection, USER_ID = UserId, DISTRIBUTOR_ID = Distributor_id }.ExecuteTable();
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

        public DataTable SelectSlashUser(int p_User_ID)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectSAMS_USER { Connection = connection, USER_ID = p_User_ID, IS_ACTIVE = true }.ExecuteTable();
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

        public DataTable SelectSlashUser(string p_LoginId, string p_Password)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectSAMS_USER { Connection = connection, LOGIN_ID = p_LoginId, PASSWORD = p_Password, IS_ACTIVE = true }.ExecuteTable();
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

        public DataTable SelectUserAssignment(int UserId, int DistributorTypeid, int TypeiD, int Companyid)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new UspSelectUnAssignDistributor { Connection = connection, USER_ID = UserId, DISTRIBUTOR_TYPE = DistributorTypeid, TYPE_ID = TypeiD, COMPANY_ID = Companyid }.ExecuteTable();
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

        public string UpdateSlashUser(int p_UserId, int p_CompanyId, string p_LoginId, string p_Password, int p_RoleId, bool p_IsActive, int p_DistributorID)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spUpdateSAMS_USER { Connection = connection, USER_ID = p_UserId, DISTRIBUTOR_ID = p_DistributorID, COMPANY_ID = p_CompanyId, LOGIN_ID = p_LoginId, PASSWORD = p_Password, ROLE_ID = p_RoleId, IS_ACTIVE = p_IsActive, LASTUPDATE_DATE = DateTime.Today }.ExecuteQuery();
                message = "Record Updated";
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

        public bool UspDayClose(DateTime p_DayClose, int Distributor_id, int UserId)
        {
            IDbConnection conn = null;
            IDbTransaction transaction = null;
            bool flag2;
            try
            {
                conn = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                conn.Open();
                transaction = ProviderFactory.GetTransaction(conn);
                bool flag = new UspDayClosing { Connection = conn, Transaction = transaction, DAYCLOSE = p_DayClose, DISTRIBUTOR_ID = Distributor_id, USER_ID = UserId }.ExecuteQuery();
                if (flag)
                {
                    transaction.Commit();
                }
                else
                {
                    transaction.Rollback();
                }
                flag2 = flag;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                flag2 = false;
            }
            finally
            {
                if ((conn != null) && (conn.State == ConnectionState.Open))
                {
                    conn.Close();
                }
            }
            return flag2;
        }
    }
}

