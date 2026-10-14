namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class SYNC_LOGController
    {
        public static int Dist_Sync_Act_ID;

        public bool CheckBeforeExists(int Dis_ActivityID, int ActivityID)
        {
            IDbConnection connection = null;
            bool flag;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                spProcessDistLog_Activity activity = new spProcessDistLog_Activity {
                    Connection = connection,
                    Type = 1,
                    DIST_ACTIVITYID = -2147483648,
                    DIST_ACT_ID = Dis_ActivityID,
                    ACTIVITY_ID = ActivityID
                };
                if (activity.ExecuteTable().Rows.Count > 0)
                {
                    return false;
                }
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

        public int GetExistsMaxId(int Distributor_id, int ActivityID)
        {
            IDbConnection connection = null;
            int num2;
            int num = 0;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                DataTable table = new spProcessDistLog_Activity { Connection = connection, Type = 3, DIST_ACTIVITYID = -2147483648, DIST_ACT_ID = Distributor_id, ACTIVITY_ID = ActivityID }.ExecuteTable();
                if (table.Rows.Count > 0)
                {
                    num = int.Parse(table.Rows[0][0].ToString());
                }
                num2 = num;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                num2 = num;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return num2;
        }

        public static int GetMaxSynLogID(int p_DistributorID)
        {
            int num2;
            int num = 0;
            IDbConnection connection = null;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                DataTable table = new uspMaxSyncLogID { Connection = connection, DISTRIBUTOR_ID = p_DistributorID }.ExecuteTable();
                if (table.Rows.Count > 0)
                {
                    num = int.Parse(table.Rows[0][0].ToString());
                }
                num2 = num;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                num2 = 0;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return num2;
        }

        public static int GetMaxSynLogID(int p_DistributorID, bool p_Is_Successful)
        {
            int num2;
            int num = 0;
            IDbConnection connection = null;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                DataTable table = new uspSelectSERVER_SYNC_LOG { Connection = connection, DISTRIBUTOR_ID = p_DistributorID, IS_SUCCESSFUL = p_Is_Successful }.ExecuteTable();
                if (table.Rows.Count > 0)
                {
                    num = int.Parse(table.Rows[0][0].ToString());
                }
                else
                {
                    num = -1;
                }
                num2 = num;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                num2 = 0;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return num2;
        }

        public int GetSync_Log_Id(int p_Distributor_Id)
        {
            IDbConnection connection = null;
            int num;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                spSelectSYNC_LOG tsync_log = new spSelectSYNC_LOG {
                    Connection = connection,
                    SYNC_LOG_ID = -2147483648,
                    DISTRIBUTOR_ID = p_Distributor_Id,
                    LOG_DATE = Constants.DateNullValue,
                    IS_CLOSED = false
                };
                DataRow row = tsync_log.ExecuteTable().Rows[0];
                num = int.Parse(row[0].ToString());
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                throw exception;
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

        public DateTime GetSync_UnClosedDate(int p_Distributor_Id)
        {
            IDbConnection connection = null;
            DateTime time;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                spSelectSYNC_LOG tsync_log = new spSelectSYNC_LOG {
                    Connection = connection,
                    SYNC_LOG_ID = -2147483648,
                    DISTRIBUTOR_ID = p_Distributor_Id,
                    LOG_DATE = Constants.DateNullValue,
                    IS_CLOSED = false
                };
                DataRow row = tsync_log.ExecuteTable().Rows[0];
                time = DateTime.Parse(row[2].ToString());
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                throw exception;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return time;
        }

        public static bool InsertDistSyncActivity(int p_DistributorID, bool p_Is_Successful)
        {
            IDbConnection connection = null;
            bool flag;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                spInsertDISTRIBUTOR_SYNC_ACTIVITY tdistributor_sync_activity = new spInsertDISTRIBUTOR_SYNC_ACTIVITY {
                    Connection = connection,
                    DISTRIBUTOR_ID = p_DistributorID,
                    IS_SUCCESSFUL = p_Is_Successful,
                    TIME_STAMP = DateTime.Now
                };
                tdistributor_sync_activity.ExecuteQuery();
                Dist_Sync_Act_ID = tdistributor_sync_activity.DISTRIBUTOR_SYNC_ACTIVITY_ID;
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

        public static bool InsertDistSyncActivityDetail(int Dist_Sync_Act_ID, int p_Activity_Id)
        {
            IDbConnection connection = null;
            bool flag;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spInsertDISTRIBUTOR_SYNC_ACTIVITY_DETAIL { Connection = connection, ACTIVITY_ID = p_Activity_Id, DISTRIBUTOR_SYNC_ACTIVITY_ID = Dist_Sync_Act_ID, TIME_STAMP = DateTime.Now }.ExecuteQuery();
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

        public string InsertServer_Sync_Log(int p_Log_Id, int p_Dist_Id, bool p_Is_Successful)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spInsertSERVER_SYNC_LOG { Connection = connection, IS_SUCCESSFUL = p_Is_Successful, LOG_ID = p_Log_Id, DISTRIBUTOR_ID = p_Dist_Id, LOG_DATE = DateTime.Now }.ExecuteQuery();
                message = "Record Inserted";
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

        public string InsertSYNC_LOG(int p_Sync_Log_Id, bool p_Is_Closed, DateTime p_Log_Date, int p_Distributor_Id)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spInsertSYNC_LOG { Connection = connection, SYNC_LOG_ID = p_Sync_Log_Id, IS_CLOSED = p_Is_Closed, LOG_DATE = p_Log_Date, DISTRIBUTOR_ID = p_Distributor_Id }.ExecuteQuery();
                message = "Record Inserted";
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

        public string InsertTrans_Sync_Log(int p_Trans_Log_Id, long p_Log_Detail_Id, int p_Dist_Id)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spInsertTRANS_SYNC_LOG { Connection = connection, TRANS_LOG_ID = p_Trans_Log_Id, LOG_DETAIL_ID = p_Log_Detail_Id, DISTRIBUTOR_ID = p_Dist_Id }.ExecuteQuery();
                message = "Record Inserted";
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

        public DataTable SelectSYNC_LOG_ForClosing(DateTime p_Log_Date, int p_Distributor_Id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                uspSelectSync_LogForClosing closing = new uspSelectSync_LogForClosing {
                    Connection = connection,
                    LOG_DATE = p_Log_Date,
                    DISTRIBUTOR_ID = p_Distributor_Id
                };
                DataTable table = new DataTable();
                table2 = closing.ExecuteTable();
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

        public bool SetDisActivityDetail(long Dis_ActivityID, long ActivityID)
        {
            IDbConnection connection = null;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spDISTACTIVIESDETAIL { Connection = connection, DIST_ACT_ID = Dis_ActivityID, ACTIVITY_ID = ActivityID, DATE_TIME = DateTime.Now.ToString() }.ExecuteQuery();
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                return false;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return true;
        }

        public int SetDistActivityMaster(string DistributorID, long Activity)
        {
            int num = -1;
            IDbConnection connection = null;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                spDISTACTIVIES pdistactivies = new spDISTACTIVIES {
                    Connection = connection,
                    DISTRIBUTOR_ID = DistributorID,
                    ACTIVITY = Activity,
                    DATE_TIME = DateTime.Now
                };
                num = short.Parse(pdistactivies.ExecuteTable().Rows[0][0].ToString());
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                return 0;
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

        public bool UpdateDisActivityMaster(int DIST_ACTIVITYID)
        {
            IDbConnection connection = null;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spProcessDistLog_Activity { Connection = connection, Type = 2, DIST_ACTIVITYID = DIST_ACTIVITYID, DIST_ACT_ID = -2147483648, ACTIVITY_ID = -2147483648 }.ExecuteQuery();
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                return false;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return true;
        }

        public static bool UpdateDistSyncActivity(int p_Dist_Sync_Act_ID, int p_DistributorID, bool p_Is_Successful)
        {
            IDbConnection connection = null;
            bool flag;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spUpdateDISTRIBUTOR_SYNC_ACTIVITY { Connection = connection, DISTRIBUTOR_ID = p_DistributorID, IS_SUCCESSFUL = p_Is_Successful, DISTRIBUTOR_SYNC_ACTIVITY_ID = p_Dist_Sync_Act_ID, TIME_STAMP = DateTime.Now }.ExecuteQuery();
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

        public string UpdateSYNC_LOG(bool p_Is_Closed, DateTime p_Log_Date, int p_Distributor_Id, int p_Sync_Log_Id)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                message = this.UpdateSYNC_LOG(p_Is_Closed, p_Log_Date, p_Distributor_Id, p_Sync_Log_Id, connection, null);
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

        public string UpdateSYNC_LOG(bool p_Is_Closed, DateTime p_Log_Date, int p_Distributor_Id, int p_Sync_Log_Id, IDbConnection p_Connection, IDbTransaction p_Transaction)
        {
            try
            {
                spUpdateSYNC_LOG esync_log = new spUpdateSYNC_LOG {
                    Connection = p_Connection,
                    Transaction = p_Transaction,
                    IS_CLOSED = p_Is_Closed,
                    LOG_DATE = p_Log_Date,
                    DISTRIBUTOR_ID = p_Distributor_Id,
                    SYNC_LOG_ID = p_Sync_Log_Id
                };
                esync_log.ExecuteQuery();
                return esync_log.SYNC_LOG_ID.ToString();
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                return exception.Message;
            }
        }
    }
}

