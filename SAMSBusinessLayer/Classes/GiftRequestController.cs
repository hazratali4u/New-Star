namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class GiftRequestController
    {
        public double CalculateLoyaltyPoints(int p_TLP_PERSON_ID, DateTime p_DATE_FROM, DateTime p_DATE_TO)
        {
            IDbConnection connection = null;
            double num;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                uspLoyatyPointsCalculateFromTo to = new uspLoyatyPointsCalculateFromTo {
                    Connection = connection,
                    TLP_PERSON_ID = p_TLP_PERSON_ID,
                    DATE_FROM = p_DATE_FROM,
                    DATE_TO = p_DATE_TO
                };
                to.ExecuteQuery();
                num = Convert.ToDouble(to.TOTAL_POINTS);
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                num = -1.0;
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

        public string DeleteGiftRequest(int p_GiftRequest_Id)
        {
            IDbConnection connection = null;
            string str;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spDeleteGIFT_REQUEST { Connection = connection, GIFT_REQUEST_ID = p_GiftRequest_Id }.ExecuteQuery();
                str = "Record Deleted";
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

        public int InsertGiftRequest(int p_DISTRIBUTOR_ID, int p_TLP_PERSON_ID, DateTime p_REQUEST_DATE, DateTime p_UPTO_DATE, decimal p_UPTO_DATE_POINTS, decimal p_GIFT_POINTS, decimal p_BALANCE_POINTS, int p_REQUEST_STATUS, bool p_IS_DELETED, DataTable dtGiftRequestDetail)
        {
            IDbConnection conn = null;
            IDbTransaction transaction = null;
            int num;
            try
            {
                conn = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                conn.Open();
                transaction = ProviderFactory.GetTransaction(conn);
                spInsertGIFT_REQUEST tgift_request = new spInsertGIFT_REQUEST {
                    Connection = conn,
                    Transaction = transaction,
                    TLP_PERSON_ID = p_TLP_PERSON_ID,
                    REQUEST_DATE = p_REQUEST_DATE,
                    UPTO_DATE = p_UPTO_DATE,
                    UPTO_DATE_POINTS = p_UPTO_DATE_POINTS,
                    GIFT_POINTS = p_GIFT_POINTS,
                    BALANCE_POINTS = p_BALANCE_POINTS,
                    REQUEST_STATUS = p_REQUEST_STATUS,
                    IS_DELETED = p_IS_DELETED,
                    DISTRIBUTOR_ID = p_DISTRIBUTOR_ID,
                    USER_ID = Configuration.UserID,
                    IS_ACTIVE = true,
                    TIME_STAMP = DateTime.Now,
                    LASTUPDATE_DATE = DateTime.Now
                };
                tgift_request.ExecuteQuery();
                spInsertGIFT_REQUEST_DETAIL tgift_request_detail = new spInsertGIFT_REQUEST_DETAIL {
                    Connection = conn,
                    Transaction = transaction
                };
                foreach (DataRow row in dtGiftRequestDetail.Rows)
                {
                    tgift_request_detail.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                    tgift_request_detail.GIFT_REQUEST_ID = tgift_request.GIFT_REQUEST_ID;
                    tgift_request_detail.GIFT_ID = Convert.ToInt32(row["GIFT_ID"]);
                    tgift_request_detail.GIFT_POINTS = Convert.ToDecimal(row["GIFT_POINTS"]);
                    tgift_request_detail.GIFT_STATUS = Convert.ToInt32(row["GIFT_STATUS"]);
                    tgift_request_detail.QUANTITY = Convert.ToInt32(row["QUANTITY"]);
                    tgift_request_detail.TOTAL_GIFT_POINTS = Convert.ToInt32(row["TOTAL_GIFT_POINTS"]);
                    tgift_request_detail.ExecuteQuery();
                }
                new uspUpdateTLPPersonPoints { Connection = conn, Transaction = transaction, TLP_PERSON_ID = p_TLP_PERSON_ID, BALANCE_POINTS = p_BALANCE_POINTS, USED_POINTS = p_GIFT_POINTS }.ExecuteQuery();
                transaction.Commit();
                num = tgift_request.GIFT_REQUEST_ID;
            }
            catch (Exception exception)
            {
                transaction.Rollback();
                ExceptionPublisher.PublishException(exception);
                num = -1;
            }
            finally
            {
                if ((conn != null) && (conn.State == ConnectionState.Open))
                {
                    conn.Close();
                }
            }
            return num;
        }

        public DataTable SelectAllGiftRequest()
        {
            return this.SelectGiftRequest(-2147483648, Configuration.DistributorId, -2147483648, Constants.DateNullValue, Constants.DateNullValue, -79228162514264337593543950335M, -79228162514264337593543950335M, -79228162514264337593543950335M, -2147483648, false);
        }

        public DataTable SelectGiftDetailRequestById(int p_DISTRIBUTOR_ID, int p_GIFT_REQUEST_ID)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectGIFT_REQUEST_DETAILInfo { Connection = connection, DISTRIBUTOR_ID = p_DISTRIBUTOR_ID, GIFT_REQUEST_ID = p_GIFT_REQUEST_ID }.ExecuteTable();
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

        public DataTable SelectGiftRequest(int p_GIFT_REQUEST_ID, int p_DISTRIBUTOR_ID, int p_TLP_PERSON_ID, DateTime p_REQUEST_DATE, DateTime p_UPTO_DATE, decimal p_UPTO_DATE_POINTS, decimal p_GIFT_POINTS, decimal p_BALANCE_POINTS, int p_REQUEST_STATUS, bool p_IS_DELETED)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectGIFT_REQUEST { Connection = connection, GIFT_REQUEST_ID = p_GIFT_REQUEST_ID, TLP_PERSON_ID = p_TLP_PERSON_ID, REQUEST_DATE = p_REQUEST_DATE, UPTO_DATE = p_UPTO_DATE, UPTO_DATE_POINTS = p_UPTO_DATE_POINTS, GIFT_POINTS = p_GIFT_POINTS, BALANCE_POINTS = p_BALANCE_POINTS, REQUEST_STATUS = p_REQUEST_STATUS, IS_DELETED = p_IS_DELETED, DISTRIBUTOR_ID = p_DISTRIBUTOR_ID, USER_ID = -2147483648, IS_ACTIVE = true, TIME_STAMP = Constants.DateNullValue, LASTUPDATE_DATE = Constants.DateNullValue }.ExecuteTable();
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

        public DataTable SelectGiftRequestById(int p_GIFT_REQUEST_ID)
        {
            return this.SelectGiftRequest(p_GIFT_REQUEST_ID, Configuration.DistributorId, -2147483648, Constants.DateNullValue, Constants.DateNullValue, -79228162514264337593543950335M, -79228162514264337593543950335M, -79228162514264337593543950335M, -2147483648, false);
        }

        public DataTable SelectGiftRequestByTLPPersonId(int p_TLP_PERSON_ID)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectGIFT_REQUESTByTLPPersonId { Connection = connection, TLP_PERSON_ID = p_TLP_PERSON_ID }.ExecuteTable();
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

        public DataTable SelectGiftRequestDetail(int p_GIFT_REQUEST_DETAIL_ID, int p_DISTRIBUTOR_ID, int p_GIFT_REQUEST_ID, int p_GIFT_ID, decimal p_GIFT_POINTS, int p_GIFT_STATUS, int p_QUANTITY)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectGIFT_REQUEST_DETAIL { Connection = connection, GIFT_REQUEST_DETAIL_ID = p_GIFT_REQUEST_DETAIL_ID, DISTRIBUTOR_ID = p_DISTRIBUTOR_ID, GIFT_REQUEST_ID = p_GIFT_REQUEST_ID, GIFT_ID = p_GIFT_ID, GIFT_POINTS = p_GIFT_POINTS, GIFT_STATUS = p_GIFT_STATUS, QUANTITY = p_QUANTITY }.ExecuteTable();
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

        public void UpdateGiftRequest(int p_GIFT_REQUEST_ID, int p_DISTRIBUTOR_ID, int p_TLP_PERSON_ID, DateTime p_REQUEST_DATE, DateTime p_UPTO_DATE, decimal p_UPTO_DATE_POINTS, decimal p_GIFT_POINTS, decimal p_BALANCE_POINTS, int p_REQUEST_STATUS, bool p_IS_DELETED)
        {
            IDbConnection connection = null;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spUpdateGIFT_REQUEST { Connection = connection, GIFT_REQUEST_ID = p_GIFT_REQUEST_ID, TLP_PERSON_ID = p_TLP_PERSON_ID, REQUEST_DATE = p_REQUEST_DATE, UPTO_DATE = p_UPTO_DATE, UPTO_DATE_POINTS = p_UPTO_DATE_POINTS, GIFT_POINTS = p_GIFT_POINTS, BALANCE_POINTS = p_BALANCE_POINTS, REQUEST_STATUS = p_REQUEST_STATUS, IS_DELETED = p_IS_DELETED, DISTRIBUTOR_ID = p_DISTRIBUTOR_ID, USER_ID = Configuration.UserID, IS_ACTIVE = true, TIME_STAMP = DateTime.Now, LASTUPDATE_DATE = DateTime.Now }.ExecuteQuery();
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
        }

        public bool UpdateGiftRequestStatus(int p_GIFT_REQUEST_ID, int p_REQUEST_STATUS, DataTable dtGiftRequestDetail)
        {
            IDbConnection conn = null;
            IDbTransaction transaction = null;
            try
            {
                conn = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                conn.Open();
                transaction = ProviderFactory.GetTransaction(conn);
                new uspUpdateGIFT_REQUEST_STATUS { Connection = conn, Transaction = transaction, GIFT_REQUEST_ID = p_GIFT_REQUEST_ID, REQUEST_STATUS = p_REQUEST_STATUS, DISTRIBUTOR_ID = Configuration.DistributorId, USER_ID = Configuration.UserID, LASTUPDATE_DATE = DateTime.Now }.ExecuteQuery();
                uspUpdateGIFT_REQUEST_DETAIL_STATUS egift_request_detail_status = new uspUpdateGIFT_REQUEST_DETAIL_STATUS {
                    Connection = conn,
                    Transaction = transaction,
                    GIFT_REQUEST_ID = p_GIFT_REQUEST_ID,
                    DISTRIBUTOR_ID = Configuration.DistributorId
                };
                if (p_REQUEST_STATUS == 2)
                {
                    egift_request_detail_status.REQUEST_STATUS = p_REQUEST_STATUS;
                    egift_request_detail_status.GIFT_REQUEST_DETAIL_ID = -2147483648;
                    egift_request_detail_status.ExecuteQuery();
                }
                else
                {
                    foreach (DataRow row in dtGiftRequestDetail.Rows)
                    {
                        egift_request_detail_status.GIFT_REQUEST_DETAIL_ID = Convert.ToInt32(row["GIFT_REQUEST_DETAIL_ID"]);
                        if (Convert.ToBoolean(row["SELECTED"]))
                        {
                            egift_request_detail_status.REQUEST_STATUS = p_REQUEST_STATUS;
                        }
                        else
                        {
                            egift_request_detail_status.REQUEST_STATUS = 2;
                        }
                        egift_request_detail_status.ExecuteQuery();
                    }
                }
                transaction.Commit();
                return true;
            }
            catch (Exception exception)
            {
                transaction.Rollback();
                ExceptionPublisher.PublishException(exception);
            }
            finally
            {
                if ((conn != null) && (conn.State == ConnectionState.Open))
                {
                    conn.Close();
                }
            }
            return false;
        }
    }
}

