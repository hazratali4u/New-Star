namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class CreateGroupController
    {
        public DataTable GET_Group_ID(int Companyid)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new UspGetGroup_ID { Connection = connection, COMPANY_ID = Companyid }.ExecuteTable();
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

        public DataTable GET_GroupIDviaGroupName(string p_GROUP_NAME)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new UspGetGroup_IDviaGroupName { Connection = connection, GROUP_NAME = p_GROUP_NAME }.ExecuteTable();
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

        public DataTable GET_SKUGroupDetail(int Companyid)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new UspGetGroup_Detail { Connection = connection, COMPANY_ID = Companyid }.ExecuteTable();
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

        public DataTable GET_UniqueGroupName(int p_SKU_GROUP_ID, string p_GROUP_NAME, DateTime p_TIMESTAMP, bool p_ISACTIVE, int p_UserId, int Companyid)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectSKU_GROUP { Connection = connection, SKU_GROUP_ID = p_SKU_GROUP_ID, GROUP_NAME = p_GROUP_NAME, COMPANY_ID = p_UserId, USER_ID = Companyid }.ExecuteTable();
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

        public bool Insert_SKU_GroupDetail(int p_SKU_GROUP_ID, int p_SKU_ID)
        {
            IDbConnection connection = null;
            bool flag2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                flag2 = new spInsertSKU_GROUP_DETAIL { Connection = connection, SKU_GROUP_ID = p_SKU_GROUP_ID, SKU_ID = p_SKU_ID }.ExecuteQuery();
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

        public string Insert_SKUGroup(string p_GROUP_NAME, DateTime p_TIMESTAMP, bool p_ISACTIVE, int p_UserId, int p_PrincipalId, int Companyid)
        {
            IDbConnection connection = null;
            string str;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                spInsertSKU_GROUP tsku_group = new spInsertSKU_GROUP {
                    Connection = connection,
                    GROUP_NAME = p_GROUP_NAME,
                    TIME_STAMP = p_TIMESTAMP,
                    COMPANY_ID = Companyid,
                    USER_ID = p_UserId,
                    LASTUPDATE_DATE = DateTime.Now,
                    PRINCIPAL_ID = p_PrincipalId
                };
                tsku_group.ExecuteQuery();
                str = tsku_group.SKU_GROUP_ID.ToString();
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

        public bool Update_SKU_GroupandGroupDetail(int p_SKU_GROUP_ID, int p_SKU_GROUP_DETAIL_ID, int p_SKU_ID, string p_GROUP_NAME, DateTime p_TIMESTAMP, bool p_ISACTIVE)
        {
            IDbConnection connection = null;
            bool flag2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                flag2 = new UspUpdateGroupandGroupDetail { Connection = connection, SKU_GROUP_ID = p_SKU_GROUP_ID, SKU_GROUP_DETAIL_ID = p_SKU_GROUP_DETAIL_ID, SKU_ID = p_SKU_ID, GROUP_NAME = p_GROUP_NAME, TIMESTAMP = p_TIMESTAMP, ISACTIVE = p_ISACTIVE }.ExecuteQuery();
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

        public bool UpdateSKUinGroup(int p_SKU_GROUP_ID, int p_SKU_ID, string p_GROUP_NAME, bool p_ISACTIVE, int p_PrincipalId)
        {
            IDbConnection connection = null;
            bool flag2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                flag2 = new UspUpdateSKUinGroup { Connection = connection, SKU_GROUP_ID = p_SKU_GROUP_ID, SKU_ID = p_SKU_ID, GROUP_NAME = p_GROUP_NAME, ISACTIVE = p_ISACTIVE, PRINCIPAL_ID = p_PrincipalId }.ExecuteQuery();
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

