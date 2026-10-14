namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class SlabsController
    {
        public string DeleteSlabs(int p_TADASlabsId)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spDeleteTA_DA_SLABS { Connection = connection, TA_DA_SLAB_ID = p_TADASlabsId }.ExecuteQuery();
                message = "Record Deleted";
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

        public string InsertSlabs(int p_DesignatioinId, string p_SlabName, decimal p_LCA, decimal p_LOS, decimal p_OS, decimal p_FARE, decimal p_Maintenence, decimal p_Holiday)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spInsertTA_DA_SLABS { Connection = connection, DESIGNATION_ID = p_DesignatioinId, SLAB_NAME = p_SlabName, LCA = p_LCA, LOS = p_LOS, OS = p_OS, FARE = p_FARE, MAINTENENCE = p_Maintenence, HOLIDAY = p_Holiday }.ExecuteQuery();
                message = "Record Inserted";
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

        public DataTable SelectSlabs(int p_TADASlabsId, int p_DesignatioinId, string p_SlabName, decimal p_LCA, decimal p_LOS, decimal p_OS, decimal p_FARE, decimal p_Maintenence, decimal p_Holiday)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectTA_DA_SLABS { Connection = connection, TA_DA_SLAB_ID = p_TADASlabsId, DESIGNATION_ID = p_DesignatioinId, SLAB_NAME = p_SlabName, LCA = p_LCA, LOS = p_LOS, OS = p_OS, FARE = p_FARE, MAINTENENCE = p_Maintenence, HOLIDAY = p_Holiday }.ExecuteTable();
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

        public DataTable SelectSlabsInfo(int p_TADASlabsId)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectTADASlabInfo { Connection = connection, TA_DA_SLAB_ID = p_TADASlabsId }.ExecuteTable();
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

        public string UpdateSlabs(int p_TADASlabsId, int p_DesignatioinId, string p_SlabName, decimal p_LCA, decimal p_LOS, decimal p_OS, decimal p_FARE, decimal p_Maintenence, decimal p_Holiday)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spUpdateTA_DA_SLABS { Connection = connection, TA_DA_SLAB_ID = p_TADASlabsId, DESIGNATION_ID = p_DesignatioinId, SLAB_NAME = p_SlabName, LCA = p_LCA, LOS = p_LOS, OS = p_OS, FARE = p_FARE, MAINTENENCE = p_Maintenence, HOLIDAY = p_Holiday }.ExecuteQuery();
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
    }
}

