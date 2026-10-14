namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class PromotionForAllController
    {
        public string DeletePromotionCust()
        {
            try
            {
                return "";
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                return exception.Message;
            }
        }

        public string DeletePromotionCustType()
        {
            try
            {
                return "";
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                return exception.Message;
            }
        }

        public string DeletePromotionDist()
        {
            try
            {
                return "";
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                return exception.Message;
            }
        }

        public string InsertPromotionCustType(long p_PROMOTION_ID, int p_DISTRIBUTOR_ID, int p_SCHEME_ID, int p_CUSTOMER_TYPE_ID)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                spInsertPROMOTION_CUSTOMER_TYPE tpromotion_customer_type = new spInsertPROMOTION_CUSTOMER_TYPE {
                    Connection = connection,
                    PROMOTION_ID = p_PROMOTION_ID,
                    DISTRIBUTOR_ID = p_DISTRIBUTOR_ID,
                    SCHEME_ID = p_SCHEME_ID,
                    CUSTOMER_TYPE_ID = p_CUSTOMER_TYPE_ID
                };
                tpromotion_customer_type.ExecuteQuery();
                message = tpromotion_customer_type.PROMOTION_CUSTOMER_TYPE_ID.ToString();
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

        public string InsertPromotionDist(long p_Promotion_ID, int p_Scheme_ID, int p_Dist_ID, int p_Assigned_Dist_ID)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                spInsertPROMOTION_FOR tpromotion_for = new spInsertPROMOTION_FOR {
                    Connection = connection,
                    PROMOTION_ID = p_Promotion_ID,
                    DISTRIBUTOR_ID = p_Dist_ID,
                    SCHEME_ID = p_Scheme_ID,
                    ASSIGNED_DISTRIBUTOR_ID = p_Assigned_Dist_ID
                };
                tpromotion_for.ExecuteQuery();
                message = tpromotion_for.PROMOTION_FOR_ID.ToString();
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

        public string InsertPromotionVolClass(long p_Promotion_ID, int p_Scheme_ID, int p_Dist_ID, int p_Customer_ID)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                spInsertPROMOTION_CUSTOMER_VOLUMECLASS tpromotion_customer_volumeclass = new spInsertPROMOTION_CUSTOMER_VOLUMECLASS {
                    Connection = connection,
                    SCHEME_ID = p_Scheme_ID,
                    PROMOTION_ID = p_Promotion_ID,
                    DISTRIBUTOR_ID = p_Dist_ID,
                    CUSTOMER_VOLUMECLASS_ID = p_Customer_ID
                };
                tpromotion_customer_volumeclass.ExecuteQuery();
                message = tpromotion_customer_volumeclass.PROMOTION_VOLUMECLASS_ID.ToString();
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

        public DataTable SelectPromotionCust(long p_Promotion_For_ID, long p_Promotion_ID, int p_Scheme_ID, int p_Dist_ID, int p_Customer_ID)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectPROMOTION_FOR_CUSTOMER { Connection = connection, PROMOTION_FOR_ID = p_Promotion_For_ID, PROMOTION_ID = p_Promotion_ID, DISTRIBUTOR_ID = p_Dist_ID, SCHEME_ID = p_Scheme_ID, CUSTOMER_ID = p_Customer_ID }.ExecuteTable();
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

        public DataTable SelectPromotionCustType(long p_PROMOTION_CUSTOMER_TYPE_ID, long p_PROMOTION_ID, int p_DISTRIBUTOR_ID, int p_SCHEME_ID, int p_CUSTOMER_TYPE_ID)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectPROMOTION_CUSTOMER_TYPE { Connection = connection, PROMOTION_CUSTOMER_TYPE_ID = p_PROMOTION_CUSTOMER_TYPE_ID, PROMOTION_ID = p_PROMOTION_ID, DISTRIBUTOR_ID = p_DISTRIBUTOR_ID, SCHEME_ID = p_SCHEME_ID, CUSTOMER_TYPE_ID = p_CUSTOMER_TYPE_ID }.ExecuteTable();
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

        public DataTable SelectPromotionDist(long p_Promotion_For_ID, long p_Promotion_ID, int p_Scheme_ID, int p_Dist_ID, int p_Assigned_Dist_ID)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectPROMOTION_FOR { Connection = connection, PROMOTION_FOR_ID = p_Promotion_For_ID, PROMOTION_ID = p_Promotion_ID, DISTRIBUTOR_ID = p_Dist_ID, SCHEME_ID = p_Scheme_ID, ASSIGNED_DISTRIBUTOR_ID = p_Assigned_Dist_ID }.ExecuteTable();
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

        public string UpdatePromotionCust(long p_Promotion_For_ID, long p_Promotion_ID, int p_Scheme_ID, int p_Dist_ID, int p_Customer_ID)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spUpdatePROMOTION_FOR_CUSTOMER { Connection = connection, PROMOTION_FOR_ID = p_Promotion_For_ID, PROMOTION_ID = p_Promotion_ID, DISTRIBUTOR_ID = p_Dist_ID, SCHEME_ID = p_Scheme_ID, CUSTOMER_ID = p_Customer_ID }.ExecuteQuery();
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

        public string UpdatePromotionCustType(long p_PROMOTION_CUSTOMER_TYPE_ID, long p_PROMOTION_ID, int p_DISTRIBUTOR_ID, int p_SCHEME_ID, int p_CUSTOMER_TYPE_ID)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spUpdatePROMOTION_CUSTOMER_TYPE { Connection = connection, PROMOTION_CUSTOMER_TYPE_ID = p_PROMOTION_CUSTOMER_TYPE_ID, PROMOTION_ID = p_PROMOTION_ID, DISTRIBUTOR_ID = p_DISTRIBUTOR_ID, SCHEME_ID = p_SCHEME_ID, CUSTOMER_TYPE_ID = p_CUSTOMER_TYPE_ID }.ExecuteQuery();
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

        public string UpdatePromotionDist(long p_Promotion_For_ID, long p_Promotion_ID, int p_Scheme_ID, int p_Dist_ID, int p_Assigned_Dist_ID)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spUpdatePROMOTION_FOR { Connection = connection, PROMOTION_FOR_ID = p_Promotion_For_ID, PROMOTION_ID = p_Promotion_ID, DISTRIBUTOR_ID = p_Dist_ID, SCHEME_ID = p_Scheme_ID, ASSIGNED_DISTRIBUTOR_ID = p_Assigned_Dist_ID }.ExecuteQuery();
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

