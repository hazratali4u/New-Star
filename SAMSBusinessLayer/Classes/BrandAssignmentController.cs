namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class BrandAssignmentController
    {
        public DataTable GetAssignedUnassigned(int p_USER_ID, int p_BRAND_ID, int p_PRINCIPAL_ID, int p_TYPE)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new UspGetAssignedUnassignedBrand { Connection = connection, USER_ID = p_USER_ID, BRAND_ID = p_BRAND_ID, PRINCIPAL_ID = p_PRINCIPAL_ID, TYPE = p_TYPE }.ExecuteTable();
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

        public bool InsertBrandAssignment(int p_USER_ID, int p_PRINCIPAL_ID, int p_DIVISION_ID, int p_CATAGORY_ID, int p_BRAND_ID, int p_DISTRIBUTOR_ID, int p_UPDATE)
        {
            IDbConnection connection = null;
            bool flag2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                flag2 = new UspInsertandUpdateBrand_Assignment { Connection = connection, USER_ID = p_USER_ID, PRINCIPAL_ID = p_PRINCIPAL_ID, DIVISION_ID = p_DIVISION_ID, CATAGORY_ID = p_CATAGORY_ID, BRAND_ID = p_BRAND_ID, DISTRIBUTOR_ID = p_DISTRIBUTOR_ID, UPDATE = p_UPDATE }.ExecuteQuery();
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

