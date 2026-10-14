namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class DistributorRouteController
    {
        public string DeleteDistributorRoute(long p_ROUTE_ID, int p_DISTRIBUTOR_ID)
        {
            IDbConnection connection = null;
            string str;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spDeleteDISTRIBUTOR_ROUTE { Connection = connection, DISTRIBUTOR_ID = p_DISTRIBUTOR_ID, ROUTE_ID = p_ROUTE_ID }.ExecuteQuery();
                str = "Record Deleted";
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

        public string InsertDistributorRoute(long p_ROUTE_ID, int p_DISTRIBUTOR_ID, int p_TOWN_ID, long p_AREA_ID, string p_ROUTE_CODE, string p_ROUTE_NAME, bool P_IS_ACTIVE)
        {
            IDbConnection connection = null;
            string str;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spInsertDISTRIBUTOR_ROUTE { Connection = connection, DISTRIBUTOR_ID = p_DISTRIBUTOR_ID, AREA_ID = p_AREA_ID, ROUTE_ID = p_ROUTE_ID, TOWN_ID = p_TOWN_ID, ROUTE_CODE = p_ROUTE_CODE, ROUTE_NAME = p_ROUTE_NAME, IS_ACTIVE = P_IS_ACTIVE, TIME_STAMP = DateTime.Today, LASTUPDATE_DATE = DateTime.Today }.ExecuteQuery();
                str = "Record Inserted";
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

        public DataTable SelectDistributorRoute(long p_ROUTE_ID, int p_DISTRIBUTOR_ID, int p_TOWN_ID, long p_AREA_ID)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectDISTRIBUTOR_ROUTE { Connection = connection, DISTRIBUTOR_ID = p_DISTRIBUTOR_ID, AREA_ID = p_AREA_ID, TOWN_ID = p_TOWN_ID, ROUTE_ID = p_ROUTE_ID, IS_ACTIVE = true }.ExecuteTable();
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

        public DataTable SelectDistributorRouteInfo(int p_Distributor_Id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectDISTRIBUTOR_ROUTE_INFO { Connection = connection, DISTRIBUTOR_ID = p_Distributor_Id }.ExecuteTable();
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

        public DataTable SelectRouteByArea(string strArea, int p_Distributor_Id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectAreaRoute { Connection = connection, AREAS = strArea, DISTRIBUTOR_ID = p_Distributor_Id }.ExecuteTable();
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

        public string UpdateDistributorRoute(long p_ROUTE_ID, int p_DISTRIBUTOR_ID, int p_TOWNID, long p_AREA_ID, string p_ROUTE_CODE, string p_ROUTE_NAME, bool p_IsActive)
        {
            IDbConnection connection = null;
            string str;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spUpdateDISTRIBUTOR_ROUTE { Connection = connection, ROUTE_ID = p_ROUTE_ID, DISTRIBUTOR_ID = p_DISTRIBUTOR_ID, AREA_ID = p_AREA_ID, TOWN_ID = p_TOWNID, LASTUPDATE_DATE = DateTime.Today, ROUTE_CODE = p_ROUTE_CODE, ROUTE_NAME = p_ROUTE_NAME, IS_ACTIVE = p_IsActive }.ExecuteQuery();
                str = "Record Updated";
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

