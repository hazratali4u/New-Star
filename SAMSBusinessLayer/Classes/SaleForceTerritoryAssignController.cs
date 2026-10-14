namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class SaleForceTerritoryAssignController
    {
        private static IDbConnection mConnection;

        public static DataTable GetSAMS_OR_DISTRIBUTOR_USERS(string SalesForceType)
        {
            mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
            try
            {
                try
                {
                    mConnection.Open();
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            finally
            {
            }
            if (SalesForceType == "OB")
            {
                DataTable table = new uspSelectSAMS_USERS { Connection = mConnection, USER_TYPE_ID = 50 }.ExecuteTable();
                if ((mConnection != null) && (mConnection.State == ConnectionState.Open))
                {
                    mConnection.Close();
                }
                mConnection = null;
                return table;
            }
            if (SalesForceType == "DM")
            {
                DataTable table2 = new uspSelectDISTRIBUTOR_USER { Connection = mConnection, USER_TYPE_ID = 50 }.ExecuteTable();
                if ((mConnection != null) && (mConnection.State == ConnectionState.Open))
                {
                    mConnection.Close();
                }
                mConnection = null;
                return table2;
            }
            return null;
        }

        public static DataTable GETTerritoryData()
        {
            mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
            try
            {
                try
                {
                    mConnection.Open();
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            finally
            {
            }
            DataTable table = new uspSelectDistributor_Terri_Geo_Hierarchy { Connection = mConnection }.ExecuteTable();
            if ((mConnection != null) && (mConnection.State == ConnectionState.Open))
            {
                mConnection.Close();
            }
            mConnection = null;
            return table;
        }

        public static void SaveTerritory(int USER_ID, int TERRITORY_ID, int DISTRIBUTOR_ID)
        {
            IDbConnection connection = null;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                uspUpdateDistributor_User_Territory territory = new uspUpdateDistributor_User_Territory {
                    Connection = connection,
                    DISTRIBUTOR_ID = DISTRIBUTOR_ID,
                    USER_ID = USER_ID,
                    TERRITORY_ID = TERRITORY_ID
                };
                if (territory.ExecuteScalar() == "0")
                {
                    throw new Exception("0");
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
                connection = null;
            }
        }

        public static int SelectTerritory(int USER_ID, int DISTRIBUTOR_ID)
        {
            int num = -1;
            mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
            try
            {
                try
                {
                    mConnection.Open();
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            finally
            {
            }
            uspSelectDistributor_User_Territory territory = new uspSelectDistributor_User_Territory {
                Connection = mConnection,
                USER_ID = USER_ID,
                DISTRIBUTOR_ID = DISTRIBUTOR_ID
            };
            if (territory.ExecuteScalar() != null)
            {
                num = int.Parse(territory.ExecuteScalar());
                if ((mConnection != null) && (mConnection.State == ConnectionState.Open))
                {
                    mConnection.Close();
                }
                mConnection = null;
                return num;
            }
            if ((mConnection != null) && (mConnection.State == ConnectionState.Open))
            {
                mConnection.Close();
            }
            mConnection = null;
            return -1;
        }

        public static DataTable SelectTerritoryWiseSalesForce(int p_Territory_ID, int p_Distributor_Id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectTerritoryWiseSalesForce { Connection = connection, TERRITORY_ID = p_Territory_ID, DISTRIBUTOR_ID = p_Distributor_Id }.ExecuteTable();
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

