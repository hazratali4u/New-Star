namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class CustomerProximityController
    {
        public string InsertCustomerProximity(long p_Customer_Id, int p_Distributor_Id, int p_Sequence_Number)
        {
            IDbConnection connection = null;
            string str;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                spInsertCUSTOMER_PROXIMITY tcustomer_proximity = new spInsertCUSTOMER_PROXIMITY {
                    Connection = connection,
                    CUSTOMER_ID = p_Customer_Id,
                    DISTRIBUTOR_ID = p_Distributor_Id,
                    SEQUENCE_NUMBER = p_Sequence_Number
                };
                tcustomer_proximity.ExecuteQuery();
                str = tcustomer_proximity.PROXIMITY_ID.ToString();
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

        public DataTable SelectCustomerProximity(long p_Customer_Id, long p_Proximity_Id, int p_Distributor_Id, int p_Sequence_Number)
        {
            IDbConnection connection = null;
            DataTable table;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table = new spSelectCUSTOMER_PROXIMITY { Connection = connection, CUSTOMER_ID = p_Customer_Id, DISTRIBUTOR_ID = p_Distributor_Id, PROXIMITY_ID = p_Proximity_Id, SEQUENCE_NUMBER = p_Sequence_Number }.ExecuteTable();
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                table = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return table;
        }

        public DataTable SelectCustomerProxRoute(int p_Distributor_Id, int p_Route_Id)
        {
            IDbConnection connection = null;
            DataTable table;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table = new uspSelectCUSTOMER_PROX_ROUTE { Connection = connection, DISTRIBUTOR_ID = p_Distributor_Id, ROUTE_ID = p_Route_Id }.ExecuteTable();
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                table = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return table;
        }

        public string UpdateCustomerProximity(long p_Customer_Id, long p_Proximity_Id, int p_Distributor_Id, int p_Sequence_Number)
        {
            IDbConnection connection = null;
            string str;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spUpdateCUSTOMER_PROXIMITY { Connection = connection, CUSTOMER_ID = p_Customer_Id, DISTRIBUTOR_ID = p_Distributor_Id, PROXIMITY_ID = p_Proximity_Id, SEQUENCE_NUMBER = p_Sequence_Number }.ExecuteQuery();
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

