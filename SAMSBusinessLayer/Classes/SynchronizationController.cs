namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;
    using System.IO;
    using System.Net;

    public class SynchronizationController
    {
        public static string Distributor_Activity(string p_DISTRIBUTOR_ID, string p_Activity_ID, string Dis_ActivityID, string p_HTTPIP)
        {
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create("http://" + p_HTTPIP + "/IISHelp/SAMSServer/extra/DistActivityLog.aspx?DistributorID=" + p_DISTRIBUTOR_ID + "&Activity=" + p_Activity_ID + "&Dis_ActivityID=" + Dis_ActivityID);
            try
            {
                HttpWebResponse response = (HttpWebResponse) request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string str = reader.ReadToEnd();
                reader.Close();
                string str3 = str.ToString();
                switch (str3)
                {
                    case null:
                    case "":
                        return "-2";
                }
                char[] separator = "\r".ToCharArray();
                string[] strArray = str3.Split(separator);
                if (int.Parse(Dis_ActivityID) < 0)
                {
                    return Dis_ActivityID;
                }
                if (!strArray[0].Equals(""))
                {
                    int index = strArray[0].IndexOf("Login ID");
                    if (index >= 0)
                    {
                        return strArray[0].Substring(0, index).Trim();
                    }
                }
                else
                {
                    return "-1";
                }
                return "-1";
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                return "-2";
            }
        }

        public static long GetLastLogID(string p_DISTRIBUTOR_ID, string p_HTTPIP)
        {
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create("http://" + p_HTTPIP + "/IISHelp/SAMSServer/Extra/frmMaxLogID.aspx?distributorid=" + p_DISTRIBUTOR_ID);
            try
            {
                HttpWebResponse response = (HttpWebResponse) request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string str = reader.ReadToEnd();
                reader.Close();
                string str3 = str.ToString();
                char[] separator = "\r".ToCharArray();
                string[] strArray = str3.Split(separator);
                if (!strArray[0].Equals(""))
                {
                    return long.Parse(strArray[0]);
                }
                return -1L;
            }
            catch (WebException)
            {
                return -1L;
            }
        }

        public int GetLOGID(int p_DISTRIBUTOR_ID, int p_IS_SUCCESSFUL)
        {
            int num2;
            int num = 0;
            IDbConnection connection = null;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                DataTable table = new uspSelectSERVER_SYNC_LOG { Connection = connection, DISTRIBUTOR_ID = p_DISTRIBUTOR_ID, IS_SUCCESSFUL = Convert.ToBoolean(p_IS_SUCCESSFUL) }.ExecuteTable();
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

        public bool InsertServerSyncLog(int p_Log_ID, int p_DISTRIBUTOR_ID, DateTime p_Log_Date, int p_IS_Successful)
        {
            IDbConnection connection = null;
            bool flag;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                uspInsertSERVER_SYNC_LOG tserver_sync_log = new uspInsertSERVER_SYNC_LOG {
                    Connection = connection,
                    DISTRIBUTOR_ID = p_DISTRIBUTOR_ID,
                    LOG_ID = p_Log_ID,
                    IS_SUCCESSFUL = true
                };
                Convert.ToInt16(tserver_sync_log.IS_SUCCESSFUL);
                tserver_sync_log.LOG_DATE = DateTime.Now;
                tserver_sync_log.ExecuteQuery();
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

        public DataTable SelectTransSyncLog(int p_Dist_Id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectTRANSSYNCLOG { Connection = connection, DISTRIBUTOR_ID = p_Dist_Id }.ExecuteTable();
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

        public static void SendLogFileId(string p_FileName, string p_HTTPIP)
        {
            string str2 = p_FileName.Substring(p_FileName.LastIndexOf(@"\") + 1);
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create("http://" + p_HTTPIP + "/IISHelp/SAMSServer/Extra/frm_ReqToDel.aspx?FileName=" + str2);
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            try
            {
                response = (HttpWebResponse) request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string str = reader.ReadToEnd();
                reader.Close();
                string str4 = str.ToString();
                char[] separator = "\r".ToCharArray();
                string[] strArray = str4.Split(separator);
            }
            catch (WebException)
            {
            }
        }

        public bool UpdateServerSyncLog(int p_Log_ID, int p_DISTRIBUTOR_ID)
        {
            IDbConnection connection = null;
            bool flag;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                uspUpdateSERVER_SYNC_LOG eserver_sync_log = new uspUpdateSERVER_SYNC_LOG {
                    Connection = connection,
                    DISTRIBUTOR_ID = p_DISTRIBUTOR_ID,
                    LOG_ID = p_Log_ID,
                    IS_SUCCESSFUL = true
                };
                Convert.ToInt16(eserver_sync_log.IS_SUCCESSFUL);
                eserver_sync_log.LOG_DATE = DateTime.Now;
                eserver_sync_log.ExecuteQuery();
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

        public bool UpdateTransSyncLog(int p_DISTRIBUTOR_ID, int p_Trans_log_Id, int p_Log_Detail_Id)
        {
            IDbConnection connection = null;
            bool flag;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new uspUpdateTRANS_SYNC_LOG { Connection = connection, DISTRIBUTOR_ID = p_DISTRIBUTOR_ID, TRANS_LOG_ID = p_Trans_log_Id, LOG_DETAIL_ID = p_Log_Detail_Id }.ExecuteQuery();
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
    }
}

