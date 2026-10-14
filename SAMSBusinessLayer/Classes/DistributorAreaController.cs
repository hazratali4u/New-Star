namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class DistributorAreaController
    {
        public long GetAreaID(int p_Distributor_Id, string p_Area_Code)
        {
            IDbConnection connection = null;
            long num;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                DataTable table = new spSelectDISTRIBUTOR_AREA { Connection = connection, AREA_CODE = p_Area_Code, AREA_ID = -9223372036854775808L, AREA_NAME = null, DISTRIBUTOR_ID = p_Distributor_Id, LASTUPDATE_DATE = Constants.DateNullValue, TIME_STAMP = Constants.DateNullValue }.ExecuteTable();
                if (table.Rows.Count > 0)
                {
                    return long.Parse(table.Rows[0]["AREA_ID"].ToString());
                }
                num = 0L;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                num = 0L;
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

        public bool insertDisct_Area(long p_Area_Id, bool p_IsActive, int p_Distributor_Id, int p_Territory_Id, string p_Area_Name, string p_Area_Code)
        {
            IDbConnection connection = null;
            bool flag2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                flag2 = new spInsertDISTRIBUTOR_AREA { Connection = connection, AREA_ID = p_Area_Id, AREA_CODE = p_Area_Code, AREA_NAME = p_Area_Name, DISTRIBUTOR_ID = p_Distributor_Id, LASTUPDATE_DATE = DateTime.Today, TIME_STAMP = DateTime.Today, TOWN_ID = p_Territory_Id, IS_ACTIVE = p_IsActive }.ExecuteQuery();
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

        public DataTable SelectAreaByTown(string strTown, int p_Distributor_Id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectTownArea { Connection = connection, TERRITORIES = strTown, DISTRIBUTOR_ID = p_Distributor_Id }.ExecuteTable();
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

        public DataTable SelectCust_Area(long p_Area_Id, int p_Distributor_Id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectCustAreaProximity { Connection = connection, AREA_ID = p_Area_Id, DISTRIBUTOR_ID = p_Distributor_Id }.ExecuteTable();
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

        public DataTable SelectCust_By_Type_Area(long p_Area_Id, int p_Distributor_Id, string strCustomerTypes)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectCustByTypeArea { Connection = connection, AREA_ID = p_Area_Id, DISTRIBUTOR_ID = p_Distributor_Id, CUSTOMER_TYPES = strCustomerTypes }.ExecuteTable();
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

        public DataTable SelectCust_By_Type_Area(string strAreas, int p_Distributor_Id, string strCustomerTypes)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectCustomerByTypeArea { Connection = connection, AREA_ID = strAreas, DISTRIBUTOR_ID = p_Distributor_Id, CUSTOMER_TYPES = strCustomerTypes }.ExecuteTable();
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

        public DataTable SelectDist_Area(long p_Area_Id, DateTime p_Time_Stamp, DateTime p_LastUpdate_Date, int p_Distributor_Id, int p_Territory_Id, string p_Area_Name, string p_Area_Code)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectDISTRIBUTOR_AREA { Connection = connection, AREA_CODE = p_Area_Code, AREA_ID = p_Area_Id, AREA_NAME = p_Area_Name, DISTRIBUTOR_ID = p_Distributor_Id, LASTUPDATE_DATE = p_LastUpdate_Date, TOWN_ID = p_Territory_Id }.ExecuteTable();
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

        public DataTable SelectDistALL_Area(long p_Area_Id, DateTime p_Time_Stamp, DateTime p_LastUpdate_Date, int p_Distributor_Id, int p_Territory_Id, string p_Area_Name, string p_Area_Code)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectAllDISTRIBUTOR_AREA { Connection = connection, AREA_CODE = p_Area_Code, AREA_ID = p_Area_Id, AREA_NAME = p_Area_Name, DISTRIBUTOR_ID = p_Distributor_Id, LASTUPDATE_DATE = p_LastUpdate_Date, TOWN_ID = p_Territory_Id }.ExecuteTable();
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

        public DataTable SelectDistributorArea(int p_Distributor_Id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectDISTRIBUTOR_AREA { Connection = connection, AREA_CODE = null, AREA_ID = -9223372036854775808L, AREA_NAME = null, DISTRIBUTOR_ID = p_Distributor_Id, LASTUPDATE_DATE = Constants.DateNullValue }.ExecuteTable();
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

        public bool UpdateDisct_Area(long p_Area_Id, bool p_IsActive, DateTime p_Time_Stamp, DateTime p_LastUpdate_Date, int p_Distributor_Id, int p_Territory_Id, string p_Area_Name, string p_Area_Code)
        {
            IDbConnection connection = null;
            bool flag2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                flag2 = new spUpdateDISTRIBUTOR_AREA { Connection = connection, AREA_ID = p_Area_Id, AREA_CODE = p_Area_Code, AREA_NAME = p_Area_Name, DISTRIBUTOR_ID = p_Distributor_Id, LASTUPDATE_DATE = p_LastUpdate_Date, TOWN_ID = p_Territory_Id, IS_ACTIVE = p_IsActive }.ExecuteQuery();
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

