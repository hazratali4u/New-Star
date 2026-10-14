namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class TransferSku
    {
        public string InsertTransferDetail(long I_TRANSFER_ID, string p_BATCH_NO, int I_SKU_ID, string I_SKU_Code, string I_SKU_NAME, decimal I_QUANTITY)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                spInsertTRANSFER_DETAIL ttransfer_detail = new spInsertTRANSFER_DETAIL {
                    Connection = connection
                };
                connection.Open();
                ttransfer_detail.TRANSFER_MASTER_ID = I_TRANSFER_ID;
                ttransfer_detail.BATCH_NO = p_BATCH_NO;
                ttransfer_detail.SKU_ID = I_SKU_ID;
                ttransfer_detail.SKU_Code = I_SKU_Code;
                ttransfer_detail.SKU_NAME = I_SKU_NAME;
                ttransfer_detail.QUANTITY = I_QUANTITY;
                ttransfer_detail.RCV_QTY = -79228162514264337593543950335M;
                ttransfer_detail.ISS_QTY = -79228162514264337593543950335M;
                ttransfer_detail.ExecuteQuery();
                message = ttransfer_detail.TRANSCTION_DETAIL_ID.ToString();
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

        public string InsertTransMaster(long I_TRANSFER_FROM, string I_TRANSFER_FROMNAME, long I_TRANSFER_TO, string I_TRANSFER_TONAME, int I_USER_ID, DateTime p_TransferDate, long p_documentno)
        {
            IDbConnection connection = null;
            string str;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                spInsertTRANSFER_MASTER ttransfer_master = new spInsertTRANSFER_MASTER {
                    Connection = connection
                };
                connection.Open();
                ttransfer_master.TRANSFER_DATE = DateTime.Now.Date;
                ttransfer_master.TRANSFER_FROM = I_TRANSFER_FROM;
                ttransfer_master.TRANSFER_FROMNAME = I_TRANSFER_FROMNAME;
                ttransfer_master.TRANSFER_TO = I_TRANSFER_TO;
                ttransfer_master.TRANSFER_TONAME = I_TRANSFER_TONAME;
                ttransfer_master.USER_ID = I_USER_ID;
                ttransfer_master.IS_ISSUE = 0;
                ttransfer_master.IS_RECEIVED = 0;
                ttransfer_master.IS_ACTIVE = true;
                ttransfer_master.DOCUMENT_NO = p_documentno;
                ttransfer_master.TIME_STAMP = DateTime.Now.Date;
                ttransfer_master.RECEVID_DATE = DateTime.Now.Date;
                ttransfer_master.ISSUE_DATE = DateTime.Now.Date;
                ttransfer_master.ExecuteQuery();
                str = ttransfer_master.TRANSFER_MASTER_ID.ToString();
            }
            catch (Exception)
            {
                str = "Record Update";
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

        public DataTable Select_BatchStockQty(int Warehouse_Id, int Sku_Id, string p_batchno)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                table2 = new UspSelectWarehouseStock_Qty01 { Connection = connection, Batchno = p_batchno, WarehouseID = Warehouse_Id, sku_id = Sku_Id }.ExecuteTable();
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

        public DataTable Select_PurchaseMaster(int p_type, int p_Warehouse, int P_PURCHASE_MASTER_ID, decimal p_qty)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                table2 = new UspPROCESSReturnPickSlipMaster { Connection = connection, type = p_type, Warehouse_id = p_Warehouse, PURCHASE_MASTER_ID = P_PURCHASE_MASTER_ID }.ExecuteTable();
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

        public DataTable Select_TransferDetail(long transfer_Id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                table2 = new spSelectTRANSFER_DETAIL { Connection = connection, TRANSCTION_DETAIL_ID = -9223372036854775808L, TRANSFER_MASTER_ID = transfer_Id, BATCH_NO = null, SKU_ID = -2147483648, SKU_Code = null, SKU_NAME = null, QUANTITY = -79228162514264337593543950335M, ISS_QTY = -79228162514264337593543950335M, RCV_QTY = -79228162514264337593543950335M }.ExecuteTable();
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

        public DataTable Select_TransferMaster(int SKU_Received, int SKU_Issue, long fromWarehouse, long towarehouse)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                table2 = new spSelectTRANSFER_MASTER { Connection = connection, TRANSFER_MASTER_ID = -9223372036854775808L, DOCUMENT_NO = -9223372036854775808L, TRANSFER_DATE = Constants.DateNullValue, TRANSFER_FROM = fromWarehouse, TRANSFER_FROMNAME = null, TRANSFER_TO = towarehouse, TRANSFER_TONAME = null, USER_ID = -2147483648, IS_RECEIVED = SKU_Received, IS_ISSUE = SKU_Issue, IS_ACTIVE = true, ISSUE_DATE = Constants.DateNullValue, RECEVID_DATE = Constants.DateNullValue, TIME_STAMP = Constants.DateNullValue }.ExecuteTable();
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

        public DataTable Select_WareHouseStockDetail(int Warehouse_Id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                table2 = new UspSelectWarehouseStock_Detail { Connection = connection, WarehouseID = Warehouse_Id }.ExecuteTable();
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

        public DataTable Select_WareHouseStockQty(int Warehouse_Id, int Sku_Id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                table2 = new UspSelectWarehouseStock_Qty { Connection = connection, WarehouseID = Warehouse_Id, sku_id = Sku_Id }.ExecuteTable();
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

        public string updateTransferMaster(long TransferId, int Is_Issue, int Is_received)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spUpdateTRANSFER_MASTER { Connection = connection, TRANSFER_MASTER_ID = TransferId, TRANSFER_DATE = Constants.DateNullValue, TRANSFER_FROM = -9223372036854775808L, TRANSFER_FROMNAME = null, TRANSFER_TO = -9223372036854775808L, TRANSFER_TONAME = null, USER_ID = -2147483648, IS_ISSUE = Is_Issue, IS_RECEIVED = Is_received, IS_ACTIVE = true, DOCUMENT_NO = -9223372036854775808L, TIME_STAMP = DateTime.Now.Date, RECEVID_DATE = Constants.DateNullValue, ISSUE_DATE = DateTime.Now.Date }.ExecuteQuery();
                message = "Stock Update for Transfer No. " + TransferId.ToString();
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

        public string updateTrnasferDetail(long I_TRANSFER_ID, decimal I_IssQty, decimal I_RcvQty)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                spUpdateTRANSFER_DETAIL etransfer_detail = new spUpdateTRANSFER_DETAIL {
                    Connection = connection
                };
                connection.Open();
                etransfer_detail.TRANSCTION_DETAIL_ID = I_TRANSFER_ID;
                etransfer_detail.TRANSFER_MASTER_ID = -9223372036854775808L;
                etransfer_detail.BATCH_NO = null;
                etransfer_detail.SKU_ID = -2147483648;
                etransfer_detail.SKU_Code = null;
                etransfer_detail.SKU_NAME = null;
                etransfer_detail.QUANTITY = -79228162514264337593543950335M;
                etransfer_detail.RCV_QTY = I_RcvQty;
                etransfer_detail.ISS_QTY = I_IssQty;
                etransfer_detail.ExecuteQuery();
                message = "Update Record";
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

        public string UpdateWarehouseStock(int type, long Warehouse_Id, int Sku_Id, decimal Qty)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spUpdateWAREHOUSE_STOCK { Connection = connection, type = type, Warehouse_Id = Warehouse_Id, Sku_ID = Sku_Id, qty = Qty }.ExecuteQuery();
                message = "Record Update";
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

        public string UpdateWarehouseStockNew(int type, long Warehouse_Id, string Batchno, int Sku_Id, decimal Qty)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new UspUpdateWAREHOUSE_STOCK01 { Connection = connection, type = type, Warehouse_Id = Warehouse_Id, Batchno = Batchno, Sku_ID = Sku_Id, qty = Qty }.ExecuteQuery();
                message = "Record Update";
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

