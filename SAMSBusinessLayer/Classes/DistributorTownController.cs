namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class DistributorTownController
    {
        public string DeletedDistributorTown(int p_Distributor_Id, int p_Town_Id)
        {
            IDbConnection connection = null;
            string str;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spDeleteDISTRIBUTOR_TOWN { Connection = connection, DISTRIBUTOR_ID = p_Distributor_Id, TOWN_ID = p_Town_Id }.ExecuteQuery();
                str = "Record Deleted.";
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

        public string InsertDistributorTown(int p_Distributor_Id, int p_Town_Id, bool p_Is_Active, int p_AREA_Id, string p_Ip_Address, int p_UserId)
        {
            IDbConnection connection = null;
            string str;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spInsertDISTRIBUTOR_TOWN { Connection = connection, DISTRIBUTOR_ID = p_Distributor_Id, TOWN_ID = p_Town_Id, IS_ACTIVE = p_Is_Active, USER_ID = p_UserId, TIME_STAMP = DateTime.Now, LASTUPDATE_DATE = DateTime.Now, IP_ADDRESS = p_Ip_Address }.ExecuteQuery();
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

        public DataTable SelectDistributorTownInfo(int p_Distributor_Id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectDistTown { Connection = connection, DISTRIBUTOR_ID = p_Distributor_Id }.ExecuteTable();
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

        public string UpdateDistributorTown(int p_Distributor_Id, int p_Town_Id, bool p_Is_Active, int p_User_Id, string p_Ip_Address)
        {
            IDbConnection connection = null;
            string str;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spUpdateDISTRIBUTOR_TOWN { Connection = connection, DISTRIBUTOR_ID = p_Distributor_Id, TOWN_ID = p_Town_Id, IS_ACTIVE = p_Is_Active, USER_ID = p_User_Id, TIME_STAMP = DateTime.Now, LASTUPDATE_DATE = DateTime.Now, IP_ADDRESS = p_Ip_Address }.ExecuteQuery();
                str = "Record Updated.";
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

