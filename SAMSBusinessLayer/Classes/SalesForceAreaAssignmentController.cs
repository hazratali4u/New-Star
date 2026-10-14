namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class SalesForceAreaAssignmentController
    {
        public bool DeleteSalesForceArea(DataTable dt)
        {
            IDbConnection conn = null;
            IDbTransaction transaction = null;
            bool flag;
            try
            {
                conn = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                conn.Open();
                transaction = ProviderFactory.GetTransaction(conn);
                spDeleteSALES_FORCE_AREA_ASSIGNMENT esales_force_area_assignment = new spDeleteSALES_FORCE_AREA_ASSIGNMENT {
                    Connection = conn,
                    Transaction = transaction
                };
                foreach (DataRow row in dt.Rows)
                {
                    esales_force_area_assignment.AREA_ASSIGNMENT_ID = long.Parse(row["AREA_ASSIGNMENT_ID"].ToString());
                    esales_force_area_assignment.ExecuteQuery();
                }
                transaction.Commit();
                flag = true;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                transaction.Rollback();
                flag = false;
            }
            finally
            {
                if ((conn != null) && (conn.State == ConnectionState.Open))
                {
                    conn.Close();
                }
            }
            return flag;
        }

        public bool InsertSalesForceAreaAssignment(long p_AREA_ID, long p_ROUTE_ID, bool p_IS_ACTIVE, DateTime p_TIME_STAMP, DateTime p_LASTUPDATE_DATE, int p_SALES_FORCE_TYPE, int p_SALES_FORCE_ID)
        {
            IDbConnection connection = null;
            bool flag2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                bool flag = new spInsertSALES_FORCE_AREA_ASSIGNMENT { Connection = connection, IS_ACTIVE = p_IS_ACTIVE, AREA_ID = p_AREA_ID, ROUTE_ID = p_ROUTE_ID, SALES_FORCE_ID = p_SALES_FORCE_ID, SALES_FORCE_TYPE = p_SALES_FORCE_TYPE, TIME_STAMP = p_TIME_STAMP, LASTUPDATE_DATE = p_LASTUPDATE_DATE }.ExecuteQuery();
                flag2 = true;
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

        public DataTable SelectSalesForceAreaAssignment(long p_AREA_ASSIGNMENT_ID, long p_AREA_ID, long p_ROUTE_ID, bool p_IS_ACTIVE, DateTime p_TIME_STAMP, DateTime p_LASTUPDATE_DATE, int p_SALES_FORCE_TYPE, int p_SALES_FORCE_ID)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectSALES_FORCE_AREA_ASSIGNMENT { Connection = connection, AREA_ASSIGNMENT_ID = p_AREA_ASSIGNMENT_ID, IS_ACTIVE = p_IS_ACTIVE, AREA_ID = p_AREA_ID, ROUTE_ID = p_ROUTE_ID, SALES_FORCE_ID = p_SALES_FORCE_ID, SALES_FORCE_TYPE = p_SALES_FORCE_TYPE, TIME_STAMP = p_TIME_STAMP, LASTUPDATE_DATE = p_LASTUPDATE_DATE }.ExecuteTable();
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

        public DataTable SelectUnassignedRoutes(int dist_id, long area_id, int sales_force_id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectUnassignedRoutes { Connection = connection, distributor_id = dist_id, area_id = area_id, sales_force_id = sales_force_id }.ExecuteTable();
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

