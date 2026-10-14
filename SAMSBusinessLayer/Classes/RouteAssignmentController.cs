namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class RouteAssignmentController
    {
        public bool DeleteAssignedRoute(int p_ROUTE_ASSIGNMENT_ID)
        {
            IDbConnection connection = null;
            bool flag2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                flag2 = new spDeleteROUTE_ASSIGNMENT { Connection = connection, ROUTE_ASSIGNMENT_ID = p_ROUTE_ASSIGNMENT_ID }.ExecuteQuery();
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

        public bool InsertRouteAssignment(int p_USER_ID, DateTime p_TIME_STAMP, int p_DISTRIBUTOR_ID, int p_REGION_ID, int p_ZONE_ID, int p_TERRITORY_ID, int p_TOWN_ID, int p_ROUTE_ID, int p_LOCATION_ID)
        {
            IDbConnection connection = null;
            bool flag2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                flag2 = new spInsertROUTE_ASSIGNMENT { Connection = connection, USER_ID = p_USER_ID, TIME_STAMP = p_TIME_STAMP, DISTRIBUTOR_ID = p_DISTRIBUTOR_ID, REGION_ID = p_REGION_ID, ZONE_ID = p_ZONE_ID, TERRITORY_ID = p_TERRITORY_ID, TOWN_ID = p_TOWN_ID, ROUTE_ID = p_ROUTE_ID, LOCATION_ID = p_LOCATION_ID }.ExecuteQuery();
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

        public DataTable SelectAssingUnAssingRoute(int p_UserId, int p_PARENT_GEO_ID, int Selecttype)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new UspGetAssignedUnassignedRoute { Connection = connection, USER_ID = p_UserId, TYPE_ID = p_PARENT_GEO_ID, TYPE = Selecttype }.ExecuteTable();
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

