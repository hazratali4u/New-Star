namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class LoyaltyPointsController
    {
        public static IDbConnection mConnection;

        public static void DeleteLoyaltyPoint(long loyalty_point_id)
        {
            mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
            try
            {
                mConnection.Open();
                new spUpdateLOYALTY_POINTS { Connection = mConnection, AMOUNT = -79228162514264337593543950335M, START_DATE = Constants.DateNullValue, END_DATE = Constants.DateNullValue, IS_ACTIVE = false, LASTUPDATE_DATE = Constants.DateNullValue, LOYALTY_POINT_ID = loyalty_point_id, REDEMPTION_PERIOD = -2147483648, REDEMPTION_TIME = -2147483648, SKU_ID = -2147483648, TIME_STAMP = Constants.DateNullValue }.ExecuteQuery();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                if ((mConnection != null) && (mConnection.State == ConnectionState.Open))
                {
                    mConnection.Close();
                }
                mConnection = null;
            }
        }

        public static bool DeleteLPForCustomerByLPId(int p_LoyaltyPointId)
        {
            IDbConnection connection = null;
            bool flag;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new uspDeleteLOYALTY_FOR_CUSTOMER_By_LPId { Connection = connection, LOYALTY_POINT_ID = p_LoyaltyPointId }.ExecuteQuery();
                flag = true;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                flag = false;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return flag;
        }

        public DataTable GetAllLoyalty_Points()
        {
            DataTable table2;
            mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
            try
            {
                mConnection.Open();
                table2 = new spSelectLOYALTY_POINTS { Connection = mConnection, TLPCODE = null, TLPNAME = null, START_DATE = Constants.DateNullValue, END_DATE = Constants.DateNullValue, IS_ACTIVE = true, LASTUPDATE_DATE = Constants.DateNullValue, LOYALTY_POINT_ID = -9223372036854775808L, AMOUNT = -79228162514264337593543950335M, REDEMPTION_PERIOD = -2147483648, REDEMPTION_TIME = -2147483648, SKU_ID = -2147483648, TIME_STAMP = Constants.DateNullValue }.ExecuteTable();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                if ((mConnection != null) && (mConnection.State == ConnectionState.Open))
                {
                    mConnection.Close();
                }
                mConnection = null;
            }
            return table2;
        }

        public DataTable GetAllLTlpPerson()
        {
            DataTable table2;
            mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
            try
            {
                mConnection.Open();
                table2 = new uspSelectTLP_PERSONInfo { Connection = mConnection, IS_ACTIVE = true }.ExecuteTable();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                if ((mConnection != null) && (mConnection.State == ConnectionState.Open))
                {
                    mConnection.Close();
                }
                mConnection = null;
            }
            return table2;
        }

        public static long InsertDistributor(int LoyalpointId, int Distributorid)
        {
            long num;
            mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
            try
            {
                mConnection.Open();
                spInsertLOYALTYPOINT_DISTRIBUTOR tloyaltypoint_distributor = new spInsertLOYALTYPOINT_DISTRIBUTOR {
                    Connection = mConnection,
                    LOYALTYPOINT_ID = LoyalpointId,
                    DISTRIBUTOR_ID = Distributorid,
                    TIME_STAMP = DateTime.Now.Date
                };
                tloyaltypoint_distributor.ExecuteQuery();
                num = tloyaltypoint_distributor.LOYALTYPOINT_DISTRIBUTOR_ID;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                if ((mConnection != null) && (mConnection.State == ConnectionState.Open))
                {
                    mConnection.Close();
                }
                mConnection = null;
            }
            return num;
        }

        public static long InsertLoyalty_Points(string p_TLPCODE, string p_TLPNAME, int sku_id, int customer_type_id, int Amount, int redemption_time, int redemption_period, DateTime start_date, DateTime end_date, bool IsBouns)
        {
            long num;
            mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
            try
            {
                mConnection.Open();
                spInsertLOYALTY_POINTS tloyalty_points = new spInsertLOYALTY_POINTS {
                    Connection = mConnection,
                    TLPCODE = p_TLPCODE,
                    TLPNAME = p_TLPNAME,
                    START_DATE = start_date,
                    END_DATE = end_date,
                    IS_ACTIVE = true,
                    LASTUPDATE_DATE = DateTime.Now,
                    AMOUNT = Amount,
                    REDEMPTION_PERIOD = redemption_period,
                    REDEMPTION_TIME = redemption_time,
                    SKU_ID = sku_id,
                    TIME_STAMP = DateTime.Now,
                    ISBOUNS = IsBouns
                };
                tloyalty_points.ExecuteQuery();
                num = tloyalty_points.LOYALTY_POINT_ID;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                if ((mConnection != null) && (mConnection.State == ConnectionState.Open))
                {
                    mConnection.Close();
                }
                mConnection = null;
            }
            return num;
        }

        public static bool InsertLoyaltyPointsForCustomer(long p_LoyaltyPointId, int p_DistributorId, long p_TownId, long p_AreaId, long p_RouteId, long p_CustomerId)
        {
            IDbConnection connection = null;
            bool flag;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spInsertLOYALTY_FOR_CUSTOMER { Connection = connection, DISTRIBUTOR_ID = p_DistributorId, LOYALTY_POINT_ID = p_LoyaltyPointId, TOWN_ID = p_TownId, AREA_ID = p_AreaId, ROUTE_ID = p_RouteId, CUSTOMER_ID = p_CustomerId }.ExecuteQuery();
                flag = true;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                flag = false;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return flag;
        }

        public static long InsertTlpPerson(string p_code, string p_name, DateTime p_date, string p_nic, decimal p_balance_point)
        {
            long num;
            mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
            try
            {
                mConnection.Open();
                spInsertTLP_PERSON ttlp_person = new spInsertTLP_PERSON {
                    Connection = mConnection,
                    TLP_PERSON_CODE = p_code,
                    TLP_PERSON_NAME = p_name,
                    DATE_OF_REGISTRATION = p_date,
                    NIC = p_nic,
                    TOTAL_POINT = p_balance_point,
                    USED_POINT = 0M,
                    REDEMPTED_POINT = 0M,
                    BALANCE_POINT = p_balance_point,
                    IS_ACTIVE = true,
                    TIME_STAMP = DateTime.Now.Date,
                    USER_ID = Configuration.UserID,
                    LASTUPDATE_DATE = DateTime.Now.Date
                };
                ttlp_person.ExecuteQuery();
                num = ttlp_person.TLP_PERSON_ID;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                if ((mConnection != null) && (mConnection.State == ConnectionState.Open))
                {
                    mConnection.Close();
                }
                mConnection = null;
            }
            return num;
        }

        public static long InsertTlpPersonCustomer(int p_CustomerId, long p_TlpPersonId)
        {
            long num;
            mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
            try
            {
                mConnection.Open();
                spInsertCUSTOMER_TLP_PERSON tcustomer_tlp_person = new spInsertCUSTOMER_TLP_PERSON {
                    Connection = mConnection,
                    CUSTOMER_ID = p_CustomerId,
                    TLP_PERSON_ID = p_TlpPersonId,
                    USER_ID = Configuration.UserID,
                    IS_ACTIVE = true,
                    LASTUPDATE_DATE = DateTime.Now.Date,
                    TIME_STAMP = DateTime.Now.Date
                };
                tcustomer_tlp_person.ExecuteQuery();
                num = tcustomer_tlp_person.CUSTOMER_TLP_PERSON_ID;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                if ((mConnection != null) && (mConnection.State == ConnectionState.Open))
                {
                    mConnection.Close();
                }
                mConnection = null;
            }
            return num;
        }

        public DataTable SelectAreaByLoyaltyPoints(int p_LoyaltyPointId)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectAreaByLoyaltyPoint { Connection = connection, LOYALTY_POINT_ID = p_LoyaltyPointId }.ExecuteTable();
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

        public DataTable SelectCustomerByLoyaltyPoints(int p_LoyaltyPointId)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectCustomerByLoyaltyPoint { Connection = connection, LOYALTY_POINT_ID = p_LoyaltyPointId }.ExecuteTable();
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

        public DataTable SelectRouteByLoyaltyPoints(int p_LoyaltyPointId)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectRouteByLoyaltyPoint { Connection = connection, LOYALTY_POINT_ID = p_LoyaltyPointId }.ExecuteTable();
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

        public DataTable SelectTownByLoyaltyPoints(int p_LoyaltyPointId)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectTownByLoyaltyPoint { Connection = connection, LOYALTY_POINT_ID = p_LoyaltyPointId }.ExecuteTable();
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

        public static void UpdateLoyalty_Points(long lpoint_id, int sku_id, int Amount, int redemption_time, int redemption_period, DateTime start_date, DateTime end_date, bool IsBouns)
        {
            mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
            try
            {
                mConnection.Open();
                new spUpdateLOYALTY_POINTS { Connection = mConnection, START_DATE = start_date, END_DATE = end_date, LASTUPDATE_DATE = DateTime.Now, LOYALTY_POINT_ID = lpoint_id, AMOUNT = Amount, REDEMPTION_PERIOD = redemption_period, REDEMPTION_TIME = redemption_time, SKU_ID = sku_id, ISBOUNS = IsBouns, TIME_STAMP = Constants.DateNullValue, IS_ACTIVE = true }.ExecuteQuery();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                if ((mConnection != null) && (mConnection.State == ConnectionState.Open))
                {
                    mConnection.Close();
                }
                mConnection = null;
            }
        }

        public static long UpdateTlpPerson(long p_id, string p_code, string p_name, DateTime p_date, string p_nic, bool p_Active)
        {
            long num;
            mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
            try
            {
                mConnection.Open();
                spUpdateTLP_PERSON etlp_person = new spUpdateTLP_PERSON {
                    Connection = mConnection,
                    TLP_PERSON_ID = p_id,
                    TLP_PERSON_CODE = p_code,
                    TLP_PERSON_NAME = p_name,
                    DATE_OF_REGISTRATION = p_date,
                    NIC = p_nic,
                    TOTAL_POINT = -79228162514264337593543950335M,
                    USED_POINT = -79228162514264337593543950335M,
                    REDEMPTED_POINT = -79228162514264337593543950335M,
                    BALANCE_POINT = -79228162514264337593543950335M,
                    IS_ACTIVE = p_Active,
                    TIME_STAMP = DateTime.Now.Date,
                    USER_ID = Configuration.UserID,
                    LASTUPDATE_DATE = DateTime.Now.Date
                };
                etlp_person.ExecuteQuery();
                num = etlp_person.TLP_PERSON_ID;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                if ((mConnection != null) && (mConnection.State == ConnectionState.Open))
                {
                    mConnection.Close();
                }
                mConnection = null;
            }
            return num;
        }
    }
}

