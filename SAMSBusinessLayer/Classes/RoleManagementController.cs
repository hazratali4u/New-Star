namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class RoleManagementController
    {
        public DataTable GetAssignUnAssignModule(int p_ROLE_ID, int p_MODULE_PARENT_ID, int p_MODULE_ID, int p_TYPE)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new UspGetModules { Connection = connection, MODULE_ID = p_MODULE_ID, MODULE_PARENT_ID = p_MODULE_PARENT_ID, ROLE_ID = p_ROLE_ID, TYPE = p_TYPE }.ExecuteTable();
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

        public bool InsertRoleDetail(int p_ROLE_ID, int p_MODULE_ID, int p_Unassign)
        {
            IDbConnection connection = null;
            bool flag2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                flag2 = new spInsertROLE_DETAIL { Connection = connection, ROLE_ID = p_ROLE_ID, MODULE_ID = p_MODULE_ID, Unassign = p_Unassign }.ExecuteQuery();
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

        public bool InsertRoleMaster(string p_ROLE_NAME, DateTime p_TIME_STAMP, DateTime p_LASTUPDATE_DATE, bool p_IS_ACTIVE)
        {
            IDbConnection connection = null;
            bool flag2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                flag2 = new spInsertROLE_MASTER { Connection = connection, ROLE_NAME = p_ROLE_NAME, TIME_STAMP = p_TIME_STAMP, LASTUPDATE_DATE = p_LASTUPDATE_DATE }.ExecuteQuery();
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

        public DataTable SelectModule(int p_MODULE_ID, string p_MODULE_DESCRIPTION, int p_MODULE_PARENT_ID, int p_MODULE_TYPE_ID, DateTime p_TIME_STAMP, bool p_IS_ACTIVE)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectMODULE { Connection = connection, MODULE_ID = p_MODULE_ID, MODULE_PARENT_ID = p_MODULE_PARENT_ID, MODULE_TYPE_ID = p_MODULE_TYPE_ID, MODULE_DESCRIPTION = p_MODULE_DESCRIPTION, IS_ACTIVE = p_IS_ACTIVE, TIME_STAMP = p_TIME_STAMP }.ExecuteTable();
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

        public DataTable SelectRoleMaster(int p_Role_ID, string p_ROLE_NAME, DateTime p_TIME_STAMP, DateTime p_LASTUPDATE_DATE, bool p_IS_ACTIVE)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectROLE_MASTER { Connection = connection, ROLE_ID = p_Role_ID, ROLE_NAME = p_ROLE_NAME, TIME_STAMP = p_TIME_STAMP, LASTUPDATE_DATE = p_LASTUPDATE_DATE }.ExecuteTable();
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

        public DataTable SelectRoleWiseModule(int p_Role_id, int p_typeId, int p_LayerTypeId)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new GetAssingUserModule { Connection = connection, RoleId = p_Role_id, typeId = p_typeId, LayerTypeId = p_LayerTypeId }.ExecuteTable();
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
    }
}

