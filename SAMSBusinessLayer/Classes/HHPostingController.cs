namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class HHPostingController
    {
        public DataTable GetOrders(int p_OrderBookerID, int p_AreaID)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new UspGetSaleOrderforPosting { Connection = connection, AREA_ID = p_AreaID, ORDERBOOKER_ID = p_OrderBookerID }.ExecuteTable();
            }
            catch (Exception exception)
            {
                exception.ToString();
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

        public bool InsertSaleOrderMaster(int p_HHSaleOrderId, int p_OrderBookerID, int p_DELIVERYMAN_ID, int p_Order_Type_ID, int p_UserID)
        {
            IDbConnection conn = null;
            IDbTransaction transaction = null;
            bool flag2;
            try
            {
                conn = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                conn.Open();
                transaction = ProviderFactory.GetTransaction(conn);
                SAMS.DatabaseLayer.Classes.UspPostingHHOrder order = new SAMS.DatabaseLayer.Classes.UspPostingHHOrder {
                    Connection = conn,
                    Transaction = transaction,
                    HHSaleOrderId = p_HHSaleOrderId,
                    ORDERBOOKER_ID = p_OrderBookerID,
                    DELIVERYMAN_ID = p_DELIVERYMAN_ID,
                    ORDER_TYPE_ID = p_Order_Type_ID,
                    UserID = p_UserID
                };
                if (order.ExecuteQuery())
                {
                    transaction.Commit();
                    return true;
                }
                transaction.Rollback();
                flag2 = false;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                transaction.Rollback();
                exception.ToString();
                flag2 = false;
            }
            finally
            {
                if ((conn != null) && (conn.State == ConnectionState.Open))
                {
                    conn.Close();
                }
            }
            return flag2;
        }

        public DataTable SelectDistributorSalesForce(int p_Distributor_Id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectDISTRIBUTORSalesForce { Connection = connection, DISTRIBUTOR_ID = p_Distributor_Id }.ExecuteTable();
            }
            catch (Exception exception)
            {
                exception.ToString();
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

