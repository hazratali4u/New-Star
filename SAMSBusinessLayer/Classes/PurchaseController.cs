namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class PurchaseController
    {
        private Configuration ConfigClass;
        private IDbConnection mConnection;
        private IDbTransaction mTransaction;

        public bool InsertPurchaseDocument(int p_DISTRIBUTOR_ID, string p_ORDER_NUMBER, int p_TYPE_ID, DateTime p_DOCUMENT_DATE, int p_SOLD_TO, int p_SOLD_FROM, decimal p_TOTAL_AMOUNT, bool p_IS_DELETE, DataTable dtPurchaseDetail, int p_Posting, string p_BuiltyNo, int p_UserId, int p_PrincipalId)
        {
            bool flag;
            try
            {
                this.mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                this.mConnection.Open();
                this.mTransaction = ProviderFactory.GetTransaction(this.mConnection);
                spInsertPURCHASE_MASTER tpurchase_master = new spInsertPURCHASE_MASTER {
                    Connection = this.mConnection,
                    Transaction = this.mTransaction,
                    DISTRIBUTOR_ID = p_DISTRIBUTOR_ID,
                    TYPE_ID = p_TYPE_ID,
                    ORDER_NUMBER = p_ORDER_NUMBER,
                    SOLD_FROM = p_SOLD_FROM,
                    DOCUMENT_DATE = p_DOCUMENT_DATE,
                    SOLD_TO = p_SOLD_TO,
                    TOTAL_AMOUNT = p_TOTAL_AMOUNT,
                    USER_ID = p_UserId,
                    TIME_STAMP = DateTime.Now,
                    LAST_UPDATE = DateTime.Now,
                    POSTING = p_Posting,
                    BUILTY_NO = p_BuiltyNo
                };
                tpurchase_master.ExecuteQuery();
                spInsertPURCHASE_DETAIL tpurchase_detail = new spInsertPURCHASE_DETAIL {
                    Connection = this.mConnection,
                    Transaction = this.mTransaction
                };
                foreach (DataRow row in dtPurchaseDetail.Rows)
                {
                    tpurchase_detail.PURCHASE_MASTER_ID = tpurchase_master.PURCHASE_MASTER_ID;
                    tpurchase_detail.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                    tpurchase_detail.SKU_ID = int.Parse(row["SKU_ID"].ToString());
                    tpurchase_detail.BATCH_NO = row["BATCH_NO"].ToString();
                    tpurchase_detail.PRICE = decimal.Parse(row["PRICE"].ToString());
                    tpurchase_detail.QUANTITY = int.Parse(row["QUANTITY"].ToString());
                    tpurchase_detail.FREE_SKU = int.Parse(row["FREE_SKU"].ToString());
                    tpurchase_detail.AMOUNT = decimal.Parse(row["AMOUNT"].ToString());
                    tpurchase_detail.TYPE_ID = tpurchase_master.TYPE_ID;
                    tpurchase_detail.TIME_STAMP = p_DOCUMENT_DATE;
                    tpurchase_detail.ExecuteQuery();
                    new UspProcessStockRegister { Connection = this.mConnection, Transaction = this.mTransaction, PRINCIPAL_ID = p_PrincipalId, TYPE_ID = tpurchase_master.TYPE_ID, DISTRIBUTOR_ID = tpurchase_master.DISTRIBUTOR_ID, STOCK_DATE = tpurchase_master.DOCUMENT_DATE, SKU_ID = tpurchase_detail.SKU_ID, STOCK_QTY = tpurchase_detail.QUANTITY, FREE_QTY = tpurchase_detail.FREE_SKU, BATCHNO = tpurchase_detail.BATCH_NO }.ExecuteQuery();
                }
                this.mTransaction.Commit();
                flag = true;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                this.mTransaction.Rollback();
                flag = false;
            }
            finally
            {
                if ((this.mConnection != null) && (this.mConnection.State == ConnectionState.Open))
                {
                    this.mConnection.Close();
                }
            }
            return flag;
        }

        public bool PostPendingDocument(long p_PURCHASE_MASTER_ID, int p_Type_Id, int p_Distributor_Id, int p_Posting)
        {
            bool flag;
            try
            {
                this.mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                this.mConnection.Open();
                new spUpdatePURCHASE_MASTER { Connection = this.mConnection, PURCHASE_MASTER_ID = p_PURCHASE_MASTER_ID, DISTRIBUTOR_ID = p_Distributor_Id, TYPE_ID = p_Type_Id, POSTING = p_Posting }.ExecuteQuery();
                flag = true;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                flag = false;
            }
            finally
            {
                if ((this.mConnection != null) && (this.mConnection.State == ConnectionState.Open))
                {
                    this.mConnection.Close();
                }
            }
            return flag;
        }

        public DataTable SelectPrivousePurchaseDetail(int p_DISTRIBUTOR_ID, long p_PURCHASE_MASTER_ID, IDbConnection PConnection, IDbTransaction PTransaction)
        {
            try
            {
                spSelectPURCHASE_DETAIL tpurchase_detail = new spSelectPURCHASE_DETAIL {
                    Connection = PConnection,
                    Transaction = PTransaction,
                    DISTRIBUTOR_ID = p_DISTRIBUTOR_ID,
                    PURCHASE_MASTER_ID = p_PURCHASE_MASTER_ID
                };
                return tpurchase_detail.ExecuteTable();
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                return null;
            }
        }

        public DataTable SelectPurchaseDetail(int p_DISTRIBUTOR_ID, long p_PURCHASE_MASTER_ID)
        {
            DataTable table2;
            try
            {
                this.mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                this.mConnection.Open();
                table2 = new spSelectPURCHASE_DETAIL { Connection = this.mConnection, DISTRIBUTOR_ID = p_DISTRIBUTOR_ID, PURCHASE_MASTER_ID = p_PURCHASE_MASTER_ID }.ExecuteTable();
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                table2 = null;
            }
            finally
            {
                if ((this.mConnection != null) && (this.mConnection.State == ConnectionState.Open))
                {
                    this.mConnection.Close();
                }
            }
            return table2;
        }

        public DataTable SelectPurchaseDocumentNo(int p_TYPE_ID, int p_DISTRIBUTOR_ID, long p_PURCHASE_MASTER_ID, int p_User_Id, int p_Posting)
        {
            DataTable table2;
            try
            {
                this.mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                this.mConnection.Open();
                table2 = new spSelectPURCHASE_MASTER { Connection = this.mConnection, DISTRIBUTOR_ID = p_DISTRIBUTOR_ID, TYPE_ID = p_TYPE_ID, PURCHASE_MASTER_ID = p_PURCHASE_MASTER_ID, USER_ID = p_User_Id, POSTING = p_Posting }.ExecuteTable();
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                table2 = null;
            }
            finally
            {
                if ((this.mConnection != null) && (this.mConnection.State == ConnectionState.Open))
                {
                    this.mConnection.Close();
                }
            }
            return table2;
        }

        public DataTable SelectPurchaseDocumentNo(int p_TYPE_ID, int p_DISTRIBUTOR_ID, long p_PURCHASE_MASTER_ID, int p_User_Id, int p_Posting, int p_SOLD_TO)
        {
            DataTable table2;
            try
            {
                this.mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                this.mConnection.Open();
                table2 = new spSelectPURCHASE_MASTER { Connection = this.mConnection, DISTRIBUTOR_ID = p_DISTRIBUTOR_ID, TYPE_ID = p_TYPE_ID, PURCHASE_MASTER_ID = p_PURCHASE_MASTER_ID, USER_ID = p_User_Id, POSTING = p_Posting, SOLD_TO = p_SOLD_TO }.ExecuteTable();
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                table2 = null;
            }
            finally
            {
                if ((this.mConnection != null) && (this.mConnection.State == ConnectionState.Open))
                {
                    this.mConnection.Close();
                }
            }
            return table2;
        }

        public DataTable SelectSKUClosingStock(int p_DISTRIBUTOR_ID, int p_SKU_ID, string p_BatchNo)
        {
            DataTable table2;
            try
            {
                this.mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                this.mConnection.Open();
                table2 = new UspProcessStockRegister { Connection = this.mConnection, TYPE_ID = 12, DISTRIBUTOR_ID = p_DISTRIBUTOR_ID, SKU_ID = p_SKU_ID, BATCHNO = "N/A" }.ExecuteTable();
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                table2 = null;
            }
            finally
            {
                if ((this.mConnection != null) && (this.mConnection.State == ConnectionState.Open))
                {
                    this.mConnection.Close();
                }
            }
            return table2;
        }

        public DataTable SelectTransferOut(long p_PURCHASE_MASTER_ID)
        {
            DataTable table2;
            try
            {
                this.mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                this.mConnection.Open();
                table2 = new UspSelectUnPostTransferOut { Connection = this.mConnection, PURCHASE_MASTER_ID = p_PURCHASE_MASTER_ID }.ExecuteTable();
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                table2 = null;
            }
            finally
            {
                if ((this.mConnection != null) && (this.mConnection.State == ConnectionState.Open))
                {
                    this.mConnection.Close();
                }
            }
            return table2;
        }

        public bool UpdatePurchaseDocument(long p_PURCHASE_MASTER_ID, int p_DISTRIBUTOR_ID, string p_ORDER_NUMBER, int p_TYPE_ID, DateTime p_DOCUMENT_DATE, int p_SOLD_TO, int p_SOLD_FROM, decimal p_TOTAL_AMOUNT, bool p_IS_DELETE, DataTable dtPurchaseDetail, int p_Posting, string p_BuiltyNo, int p_UserId, int p_Principal)
        {
            bool flag;
            try
            {
                this.mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                this.mConnection.Open();
                this.mTransaction = ProviderFactory.GetTransaction(this.mConnection);
                spUpdatePURCHASE_MASTER epurchase_master = new spUpdatePURCHASE_MASTER {
                    Connection = this.mConnection,
                    Transaction = this.mTransaction,
                    PURCHASE_MASTER_ID = p_PURCHASE_MASTER_ID,
                    DISTRIBUTOR_ID = p_DISTRIBUTOR_ID,
                    TYPE_ID = p_TYPE_ID,
                    ORDER_NUMBER = p_ORDER_NUMBER,
                    SOLD_FROM = p_SOLD_FROM,
                    DOCUMENT_DATE = p_DOCUMENT_DATE,
                    SOLD_TO = p_SOLD_TO,
                    TOTAL_AMOUNT = p_TOTAL_AMOUNT,
                    USER_ID = p_UserId,
                    LAST_UPDATE = DateTime.Now,
                    POSTING = p_Posting,
                    BUILTY_NO = p_BuiltyNo
                };
                epurchase_master.ExecuteQuery();
                DataTable table = this.SelectPrivousePurchaseDetail(p_DISTRIBUTOR_ID, p_PURCHASE_MASTER_ID, this.mConnection, this.mTransaction);
                foreach (DataRow row in table.Rows)
                {
                    new UspUpdatePurchaseDetailStock { Connection = this.mConnection, Transaction = this.mTransaction, TYPEID = p_TYPE_ID, DISTRIBUTOR_ID = p_DISTRIBUTOR_ID, PURCHASE_DETAIL_ID = long.Parse(row["PURCHASE_DETAIL_ID"].ToString()), PURCHASE_MASTER_ID = p_PURCHASE_MASTER_ID, BATCH_NO = row["BATCH_NO"].ToString().Trim(), SKU_ID = int.Parse(row["SKU_ID"].ToString()) }.ExecuteQuery();
                }
                spInsertPURCHASE_DETAIL tpurchase_detail = new spInsertPURCHASE_DETAIL {
                    Connection = this.mConnection,
                    Transaction = this.mTransaction
                };
                foreach (DataRow row in dtPurchaseDetail.Rows)
                {
                    tpurchase_detail.PURCHASE_MASTER_ID = epurchase_master.PURCHASE_MASTER_ID;
                    tpurchase_detail.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                    tpurchase_detail.SKU_ID = int.Parse(row["SKU_ID"].ToString());
                    tpurchase_detail.BATCH_NO = row["BATCH_NO"].ToString();
                    tpurchase_detail.PRICE = decimal.Parse(row["PRICE"].ToString());
                    tpurchase_detail.QUANTITY = int.Parse(row["QUANTITY"].ToString());
                    tpurchase_detail.FREE_SKU = int.Parse(row["FREE_SKU"].ToString());
                    tpurchase_detail.AMOUNT = decimal.Parse(row["AMOUNT"].ToString());
                    tpurchase_detail.TYPE_ID = epurchase_master.TYPE_ID;
                    tpurchase_detail.TIME_STAMP = p_DOCUMENT_DATE;
                    tpurchase_detail.ExecuteQuery();
                    new UspProcessStockRegister { Connection = this.mConnection, Transaction = this.mTransaction, PRINCIPAL_ID = p_Principal, TYPE_ID = epurchase_master.TYPE_ID, DISTRIBUTOR_ID = epurchase_master.DISTRIBUTOR_ID, STOCK_DATE = epurchase_master.DOCUMENT_DATE, SKU_ID = tpurchase_detail.SKU_ID, STOCK_QTY = tpurchase_detail.QUANTITY, FREE_QTY = tpurchase_detail.FREE_SKU, BATCHNO = tpurchase_detail.BATCH_NO }.ExecuteQuery();
                }
                this.mTransaction.Commit();
                flag = true;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                this.mTransaction.Rollback();
                flag = false;
            }
            finally
            {
                if ((this.mConnection != null) && (this.mConnection.State == ConnectionState.Open))
                {
                    this.mConnection.Close();
                }
            }
            return flag;
        }
    }
}

