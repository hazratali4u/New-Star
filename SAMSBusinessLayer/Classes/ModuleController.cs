namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class ModuleController
    {
        public int GetModuleId(int p_Module_Id_From, int p_Module_Id_To, int p_Module_Type_Id)
        {
            IDbConnection connection = null;
            int num;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                uspGETMODULE_ID pgetmodule_id = new uspGETMODULE_ID {
                    Connection = connection,
                    MODULE_ID_FROM = p_Module_Id_From,
                    MODULE_ID_TO = p_Module_Id_To,
                    MODULE_TYPE_ID = p_Module_Type_Id
                };
                pgetmodule_id.ExecuteQuery();
                num = pgetmodule_id.MODULE_ID;
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

        public string InsertModule(int p_Module_Id, string p_Module_Name, int p_Module_Type_Id)
        {
            IDbConnection connection = null;
            string str;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                spInsertMODULES tmodules = new spInsertMODULES {
                    Connection = connection,
                    MODULE_ID = p_Module_Id,
                    MODULE_NAME = p_Module_Name,
                    MODULE_TYPE_ID = p_Module_Type_Id
                };
                tmodules.ExecuteQuery();
                str = tmodules.MODULE_ID.ToString();
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

        public DataTable SelectModule(int p_Module_Id_From, int p_Module_Id_To, int p_Module_Type_Id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectMODULES { Connection = connection, MODULE_ID_FROM = p_Module_Id_From, MODULE_ID_TO = p_Module_Id_To, MODULE_TYPE_ID = p_Module_Type_Id }.ExecuteTable();
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

        public DataTable SelectModule(int p_Module_Id, string p_Module_Name, int p_Module_Type_Id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectMODULES { Connection = connection, MODULE_ID = p_Module_Id, MODULE_NAME = p_Module_Name, MODULE_TYPE_ID = p_Module_Type_Id }.ExecuteTable();
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

        public DataTable SelectModules(int p_Module_Type_Id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectMODULES { Connection = connection, MODULE_ID = -2147483648, MODULE_NAME = null, MODULE_TYPE_ID = p_Module_Type_Id }.ExecuteTable();
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

        public string UpdateModule(int p_Module_Id, string p_Module_Name, int p_Module_Type_Id)
        {
            IDbConnection connection = null;
            string str;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                spUpdateMODULES emodules = new spUpdateMODULES {
                    Connection = connection,
                    MODULE_ID = p_Module_Id,
                    MODULE_NAME = p_Module_Name,
                    MODULE_TYPE_ID = p_Module_Type_Id
                };
                emodules.ExecuteQuery();
                str = emodules.MODULE_ID.ToString();
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
    }
}

