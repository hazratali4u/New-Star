namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Collections;
    using System.Data;

    public class OrderEntryController
    {
        public bool Add_Invoice(int p_Distributor_id, int p_TOWN_ID, long p_AREA_ID, int p_PRINCIPAL_ID, long p_SOLD_TO, long p_SHIP_TO, int p_ORDERBOOKER_ID, int p_DELIVERYMAN_ID, long p_Orderid, decimal p_TOTAL_AMOUNT, decimal p_EXTRA_DISCOUNT_AMOUNT, decimal p_STANDARD_DISCOUNT_AMOUNT, decimal p_GST_AMOUNT, decimal p_TOTAL_NET_AMOUNT, decimal p_SCHEME_AMOUNT, int InvoiceTypeId, DataTable dtOrderDetail, DataTable dtFreeSKU, int p_UserId, decimal p_CashReceived, DateTime p_DocumentDate, decimal p_TSTAmount, decimal p_SEDAmount, decimal p_HALF_SCHEME)
        {
            IDbConnection conn = null;
            IDbTransaction mTransaction = null;
            try
            {
                conn = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                conn.Open();
                mTransaction = ProviderFactory.GetTransaction(conn);
                spInsertSALE_INVOICE_MASTER tsale_invoice_master = new spInsertSALE_INVOICE_MASTER {
                    Connection = conn,
                    Transaction = mTransaction
                };
                if (dtOrderDetail.Rows.Count > 0)
                {
                    tsale_invoice_master.DISTRIBUTOR_ID = p_Distributor_id;
                    tsale_invoice_master.PRINCIPAL_ID = p_PRINCIPAL_ID;
                    tsale_invoice_master.AREA_ID = p_AREA_ID;
                    tsale_invoice_master.DELIVERYMAN_ID = p_DELIVERYMAN_ID;
                    tsale_invoice_master.ORDERBOOKER_ID = p_ORDERBOOKER_ID;
                    tsale_invoice_master.DOCUMENT_DATE = p_DocumentDate;
                    tsale_invoice_master.SOLD_TO = p_SOLD_TO;
                    tsale_invoice_master.TOTAL_AMOUNT = p_TOTAL_AMOUNT;
                    tsale_invoice_master.EXTRA_DISCOUNT_AMOUNT = p_EXTRA_DISCOUNT_AMOUNT;
                    tsale_invoice_master.STANDARD_DISCOUNT_AMOUNT = p_STANDARD_DISCOUNT_AMOUNT;
                    tsale_invoice_master.GST_AMOUNT = p_GST_AMOUNT;
                    tsale_invoice_master.SCHEME_AMOUNT = p_SCHEME_AMOUNT;
                    tsale_invoice_master.IS_DELETED = false;
                    tsale_invoice_master.TOTAL_NET_AMOUNT = p_TOTAL_NET_AMOUNT;
                    if (InvoiceTypeId == 0xd7)
                    {
                        tsale_invoice_master.CREDIT_AMOUNT = p_TOTAL_NET_AMOUNT - p_CashReceived;
                        tsale_invoice_master.CURRENT_CREDIT_AMOUNT = p_TOTAL_NET_AMOUNT - p_CashReceived;
                    }
                    else
                    {
                        tsale_invoice_master.CREDIT_AMOUNT = 0M;
                        tsale_invoice_master.CURRENT_CREDIT_AMOUNT = 0M;
                    }
                    tsale_invoice_master.TOWN_ID = p_TOWN_ID;
                    tsale_invoice_master.USER_ID = p_UserId;
                    tsale_invoice_master.SALE_ORDER_ID = p_Orderid;
                    tsale_invoice_master.TST_AMOUNT = p_TSTAmount;
                    tsale_invoice_master.SED_AMOUNT = p_SEDAmount;
                    tsale_invoice_master.HALF_SCHEME = p_HALF_SCHEME;
                    tsale_invoice_master.TIME_STAMP = DateTime.Now;
                    tsale_invoice_master.LASTUPDATE_DATE = DateTime.Now;
                    tsale_invoice_master.IS_DELETED = false;
                    tsale_invoice_master.POSTING = 0;
                    tsale_invoice_master.ExecuteQuery();
                    spInsertSALE_INVOICE_DETAIL tsale_invoice_detail = new spInsertSALE_INVOICE_DETAIL {
                        Connection = conn,
                        Transaction = mTransaction
                    };
                    foreach (DataRow row in dtOrderDetail.Rows)
                    {
                        tsale_invoice_detail.SALE_INVOICE_ID = tsale_invoice_master.SALE_INVOICE_ID;
                        tsale_invoice_detail.DISTRIBUTOR_ID = p_Distributor_id;
                        tsale_invoice_detail.SKU_ID = int.Parse(row["SKU_ID"].ToString());
                        tsale_invoice_detail.BATCH_NO = row["BATCH_NO"].ToString();
                        tsale_invoice_detail.QUANTITY_UNIT = int.Parse(row["QUANTITY_UNIT"].ToString());
                        tsale_invoice_detail.UNIT_PRICE = decimal.Parse(row["UNIT_PRICE"].ToString());
                        tsale_invoice_detail.GST_RATE = float.Parse(row["GST_RATE"].ToString());
                        tsale_invoice_detail.AMOUNT = decimal.Parse(row["AMOUNT"].ToString());
                        tsale_invoice_detail.EXTRA_DISCOUNT = decimal.Parse(row["EXTRA_DISCOUNT"].ToString());
                        tsale_invoice_detail.STANDARD_DISCOUNT = decimal.Parse(row["STANDARD_DISCOUNT"].ToString());
                        tsale_invoice_detail.GST_AMOUNT = decimal.Parse(row["GST_AMOUNT"].ToString());
                        tsale_invoice_detail.NET_AMOUNT = decimal.Parse(row["NET_AMOUNT"].ToString());
                        tsale_invoice_detail.IS_DELETED = false;
                        tsale_invoice_detail.TIME_STAMP = p_DocumentDate;
                        tsale_invoice_detail.ExecuteQuery();
                        UspProcessStockRegister register = new UspProcessStockRegister {
                            Connection = conn,
                            Transaction = mTransaction,
                            TYPE_ID = 13,
                            DISTRIBUTOR_ID = p_Distributor_id,
                            STOCK_DATE = p_DocumentDate,
                            SKU_ID = tsale_invoice_detail.SKU_ID,
                            BATCHNO = tsale_invoice_detail.BATCH_NO,
                            STOCK_QTY = tsale_invoice_detail.QUANTITY_UNIT,
                            FREE_QTY = 0
                        };
                        register.ExecuteQuery();
                    }
                    foreach (DataRow row2 in dtFreeSKU.Rows)
                    {
                        spInsertSALE_INVOICE_PROMOTION tsale_invoice_promotion = new spInsertSALE_INVOICE_PROMOTION {
                            Connection = conn,
                            Transaction = mTransaction,
                            BASKET_DETAIL_ID = int.Parse(row2["BASKET_DETAIL_ID"].ToString()),
                            BASKET_ID = int.Parse(row2["BASKET_ID"].ToString()),
                            DISTRIBUTOR_ID = p_Distributor_id,
                            GST_AMOUNT = decimal.Parse(row2["GST_AMOUNT"].ToString()),
                            GST_RATE = float.Parse(row2["GST_RATE"].ToString()),
                            PROMOTION_ID = int.Parse(row2["PROMOTION_ID"].ToString()),
                            PROMOTION_OFFER_ID = int.Parse(row2["PROMOTION_OFFER_ID"].ToString()),
                            QUANTITY = int.Parse(row2["Quantity"].ToString()),
                            SKU_ID = int.Parse(row2["SKU_ID"].ToString()),
                            UNIT_PRICE = decimal.Parse(row2["UNIT_PRICE"].ToString()),
                            TST_AMOUNT = 0M,
                            SED_AMOUNT = 0M,
                            SALE_INVOICE_ID = tsale_invoice_master.SALE_INVOICE_ID,
                            AMOUNT = decimal.Parse(row2["AMOUNT"].ToString())
                        };
                        tsale_invoice_promotion.ExecuteQuery();
                        new UspProcessStockRegister { Connection = conn, Transaction = mTransaction, TYPE_ID = 13, DISTRIBUTOR_ID = p_Distributor_id, STOCK_DATE = p_DocumentDate, SKU_ID = tsale_invoice_promotion.SKU_ID, BATCHNO = "N/A", STOCK_QTY = 0, FREE_QTY = tsale_invoice_promotion.QUANTITY }.ExecuteQuery();
                    }
                    LedgerController controller = new LedgerController();
                    Configuration.GetAccountHead();
                    DataTable table = new DistributorController().SelectDistributor(p_Distributor_id);
                    string s = controller.SelectLedgerMaxDocumentId(0x10, p_Distributor_id);
                    if (int.Parse(table.Rows[0]["SUBZONE_ID"].ToString()) == 3)
                    {
                        controller.PostingInvoiceAccount(0x10, long.Parse(s), long.Parse(Configuration.SaleAccount), p_Distributor_id, 0M, p_TOTAL_AMOUNT, tsale_invoice_master.DOCUMENT_DATE, "Gross Sale Value", DateTime.Now, p_PRINCIPAL_ID, int.Parse(p_SOLD_TO.ToString()), tsale_invoice_master.SALE_INVOICE_ID, 13, p_UserId, mTransaction, conn, 0x18, p_DELIVERYMAN_ID.ToString());
                        if (p_STANDARD_DISCOUNT_AMOUNT > 0M)
                        {
                            controller.PostingInvoiceAccount(0x10, long.Parse(s), long.Parse(Configuration.SaleDiscount), p_Distributor_id, p_STANDARD_DISCOUNT_AMOUNT, 0M, tsale_invoice_master.DOCUMENT_DATE, "Commision/Discount", DateTime.Now, p_PRINCIPAL_ID, int.Parse(p_SOLD_TO.ToString()), tsale_invoice_master.SALE_INVOICE_ID, 13, p_UserId, mTransaction, conn, 0x18, p_DELIVERYMAN_ID.ToString());
                        }
                        if (p_EXTRA_DISCOUNT_AMOUNT > 0M)
                        {
                            controller.PostingInvoiceAccount(0x10, long.Parse(s), long.Parse(Configuration.SaleScheme), p_Distributor_id, p_EXTRA_DISCOUNT_AMOUNT, 0M, tsale_invoice_master.DOCUMENT_DATE, "Extra Discount", DateTime.Now, p_PRINCIPAL_ID, int.Parse(p_SOLD_TO.ToString()), tsale_invoice_master.SALE_INVOICE_ID, 13, p_UserId, mTransaction, conn, 0x18, p_DELIVERYMAN_ID.ToString());
                        }
                        if (p_GST_AMOUNT > 0M)
                        {
                            controller.PostingInvoiceAccount(0x10, long.Parse(s), long.Parse(Configuration.GSTAccount), p_Distributor_id, 0M, p_GST_AMOUNT, tsale_invoice_master.DOCUMENT_DATE, "Sales Tax", DateTime.Now, p_PRINCIPAL_ID, int.Parse(p_SOLD_TO.ToString()), tsale_invoice_master.SALE_INVOICE_ID, 13, p_UserId, mTransaction, conn, 0x18, p_DELIVERYMAN_ID.ToString());
                        }
                        controller.PostingInvoiceAccount(0x10, long.Parse(s), long.Parse(Configuration.AccountReceivable), p_Distributor_id, p_TOTAL_NET_AMOUNT, 0M, tsale_invoice_master.DOCUMENT_DATE, "Credit Sale Default", DateTime.Now, p_PRINCIPAL_ID, int.Parse(p_SOLD_TO.ToString()), tsale_invoice_master.SALE_INVOICE_ID, 13, p_UserId, mTransaction, conn, 0x18, p_DELIVERYMAN_ID.ToString());
                    }
                    else if (InvoiceTypeId == 0xd7)
                    {
                        controller.PostingInvoiceAccount(0x10, long.Parse(s), long.Parse(Configuration.AccountReceivable), p_Distributor_id, p_TOTAL_NET_AMOUNT - p_CashReceived, 0M, tsale_invoice_master.DOCUMENT_DATE, "Credit Sale Default", DateTime.Now, p_PRINCIPAL_ID, int.Parse(p_SOLD_TO.ToString()), tsale_invoice_master.SALE_INVOICE_ID, 13, p_UserId, mTransaction, conn, 0x18, p_DELIVERYMAN_ID.ToString());
                        controller.PostingInvoiceAccount(0x10, long.Parse(s), long.Parse(Configuration.SaleAccount), p_Distributor_id, 0M, p_TOTAL_NET_AMOUNT - p_CashReceived, tsale_invoice_master.DOCUMENT_DATE, "Credit Sale Default", DateTime.Now, p_PRINCIPAL_ID, int.Parse(p_SOLD_TO.ToString()), tsale_invoice_master.SALE_INVOICE_ID, 13, p_UserId, mTransaction, conn, 0x18, p_DELIVERYMAN_ID.ToString());
                    }
                    new spUpdateSALE_ORDER_MASTER { Connection = conn, Transaction = mTransaction, DISTRIBUTOR_ID = p_Distributor_id, SALE_ORDER_ID = p_Orderid, STATUS_ID = 0x70 }.ExecuteQuery();
                    mTransaction.Commit();
                    return true;
                }
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                return false;
            }
            finally
            {
                if ((conn != null) && (conn.State == ConnectionState.Open))
                {
                    conn.Close();
                }
            }
            return true;
        }

        public bool Add_Order(int p_Distributor_id, int p_TOWN_ID, long p_AREA_ID, int p_PRINCIPAL_ID, long p_SOLD_TO, long p_SHIP_TO, int p_ORDERBOOKER_ID, int p_DELIVERYMAN_ID, int p_OrderTypeId, decimal p_TOTAL_AMOUNT, decimal p_EXTRA_DISCOUNT_AMOUNT, decimal p_STANDARD_DISCOUNT_AMOUNT, decimal p_GST_AMOUNT, decimal p_TOTAL_NET_AMOUNT, decimal p_SCHEME_AMOUNT, int p_STATUS_ID, DataTable dtOrderDetail, DataTable dtFreeSKU, int p_UserId, DateTime p_Document_Date, decimal p_SEDAmount, decimal p_TSTAmount, decimal p_HALF_SCHEME)
        {
            IDbConnection conn = null;
            IDbTransaction transaction = null;
            try
            {
                conn = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                conn.Open();
                transaction = ProviderFactory.GetTransaction(conn);
                spInsertSALE_ORDER_MASTER tsale_order_master = new spInsertSALE_ORDER_MASTER {
                    Connection = conn,
                    Transaction = transaction
                };
                if (dtOrderDetail.Rows.Count > 0)
                {
                    tsale_order_master.DISTRIBUTOR_ID = p_Distributor_id;
                    tsale_order_master.PRINCIPAL_ID = p_PRINCIPAL_ID;
                    tsale_order_master.AREA_ID = p_AREA_ID;
                    tsale_order_master.DELIVERYMAN_ID = p_DELIVERYMAN_ID;
                    tsale_order_master.ORDERBOOKER_ID = p_ORDERBOOKER_ID;
                    tsale_order_master.DOCUMENT_DATE = p_Document_Date;
                    tsale_order_master.SHIP_TO = p_SHIP_TO;
                    tsale_order_master.SOLD_TO = p_SOLD_TO;
                    tsale_order_master.TOTAL_AMOUNT = p_TOTAL_AMOUNT;
                    tsale_order_master.EXTRA_DISCOUNT_AMOUNT = p_EXTRA_DISCOUNT_AMOUNT;
                    tsale_order_master.STANDARD_DISCOUNT_AMOUNT = p_STANDARD_DISCOUNT_AMOUNT;
                    tsale_order_master.GST_AMOUNT = p_GST_AMOUNT;
                    tsale_order_master.SCHEME_AMOUNT = p_SCHEME_AMOUNT;
                    tsale_order_master.TOTAL_NET_AMOUNT = p_TOTAL_NET_AMOUNT;
                    tsale_order_master.TOWN_ID = p_TOWN_ID;
                    tsale_order_master.STATUS_ID = p_STATUS_ID;
                    tsale_order_master.USER_ID = p_UserId;
                    tsale_order_master.TST_AMOUNT = p_TSTAmount;
                    tsale_order_master.SED_AMOUNT = p_SEDAmount;
                    tsale_order_master.HALF_SCHEME = p_HALF_SCHEME;
                    tsale_order_master.ORDER_TYPE_ID = p_OrderTypeId;
                    tsale_order_master.TIME_STAMP = DateTime.Now;
                    tsale_order_master.LASTUPDATE_DATE = DateTime.Now;
                    tsale_order_master.ExecuteQuery();
                    spInsertSALE_ORDER_DETAIL tsale_order_detail = new spInsertSALE_ORDER_DETAIL {
                        Connection = conn,
                        Transaction = transaction
                    };
                    foreach (DataRow row in dtOrderDetail.Rows)
                    {
                        tsale_order_detail.SALE_ORDER_ID = tsale_order_master.SALE_ORDER_ID;
                        tsale_order_detail.DISTRIBUTOR_ID = p_Distributor_id;
                        tsale_order_detail.SKU_ID = int.Parse(row["SKU_ID"].ToString());
                        tsale_order_detail.BATCH_NO = row["BATCH_NO"].ToString();
                        tsale_order_detail.QUANTITY_UNIT = int.Parse(row["QUANTITY_UNIT"].ToString());
                        tsale_order_detail.UNIT_PRICE = decimal.Parse(row["UNIT_PRICE"].ToString());
                        tsale_order_detail.GST_RATE = float.Parse(row["GST_RATE"].ToString());
                        tsale_order_detail.AMOUNT = decimal.Parse(row["AMOUNT"].ToString());
                        tsale_order_detail.EXTRA_DISCOUNT = decimal.Parse(row["EXTRA_DISCOUNT"].ToString());
                        tsale_order_detail.STANDARD_DISCOUNT = decimal.Parse(row["STANDARD_DISCOUNT"].ToString());
                        tsale_order_detail.GST_AMOUNT = decimal.Parse(row["GST_AMOUNT"].ToString());
                        tsale_order_detail.TST_AMOUNT = 0M;
                        tsale_order_detail.SED_AMOUNT = 0M;
                        tsale_order_detail.NET_AMOUNT = decimal.Parse(row["NET_AMOUNT"].ToString());
                        tsale_order_detail.IS_DELETED = false;
                        tsale_order_detail.TIME_STAMP = p_Document_Date;
                        tsale_order_detail.ExecuteQuery();
                    }
                    foreach (DataRow row2 in dtFreeSKU.Rows)
                    {
                        new spInsertSALE_ORDER_PROMOTION { Connection = conn, Transaction = transaction, BASKET_DETAIL_ID = int.Parse(row2["BASKET_DETAIL_ID"].ToString()), BASKET_ID = int.Parse(row2["BASKET_ID"].ToString()), DISTRIBUTOR_ID = p_Distributor_id, GST_AMOUNT = decimal.Parse(row2["GST_AMOUNT"].ToString()), GST_RATE = float.Parse(row2["GST_RATE"].ToString()), PROMOTION_ID = int.Parse(row2["PROMOTION_ID"].ToString()), PROMOTION_OFFER_ID = int.Parse(row2["PROMOTION_OFFER_ID"].ToString()), QUANTITY = int.Parse(row2["Quantity"].ToString()), SKU_ID = int.Parse(row2["SKU_ID"].ToString()), UNIT_PRICE = decimal.Parse(row2["UNIT_PRICE"].ToString()), SALE_ORDER_ID = tsale_order_master.SALE_ORDER_ID, AMOUNT = decimal.Parse(row2["AMOUNT"].ToString()), TST_AMOUNT = 0M, SED_AMOUNT = 0M }.ExecuteQuery();
                    }
                    transaction.Commit();
                    return true;
                }
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                return false;
            }
            finally
            {
                if ((conn != null) && (conn.State == ConnectionState.Open))
                {
                    conn.Close();
                }
            }
            return true;
        }

        public bool Add_SaleReturn(int p_Distributor_id, int p_TOWN_ID, long p_AREA_ID, int p_PRINCIPAL_ID, long p_SOLD_TO, long p_SHIP_TO, int p_ORDERBOOKER_ID, int p_DELIVERYMAN_ID, long p_Orderid, decimal p_TOTAL_AMOUNT, decimal p_EXTRA_DISCOUNT_AMOUNT, decimal p_STANDARD_DISCOUNT_AMOUNT, decimal p_GST_AMOUNT, decimal p_TOTAL_NET_AMOUNT, decimal p_SCHEME_AMOUNT, int InvoiceTypeId, DataTable dtOrderDetail, DataTable dtFreeSKU, int p_UserId, DateTime p_DocumentDate, decimal p_TstAmount, decimal p_SEDAmount)
        {
            IDbConnection conn = null;
            IDbTransaction transaction = null;
            try
            {
                conn = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                conn.Open();
                transaction = ProviderFactory.GetTransaction(conn);
                spInsertSALES_RETURN_MASTER tsales_return_master = new spInsertSALES_RETURN_MASTER {
                    Connection = conn,
                    Transaction = transaction
                };
                if (dtOrderDetail.Rows.Count > 0)
                {
                    tsales_return_master.DISTRIBUTOR_ID = p_Distributor_id;
                    tsales_return_master.PRINCIPAL_ID = p_PRINCIPAL_ID;
                    tsales_return_master.AREA_ID = int.Parse(p_AREA_ID.ToString());
                    tsales_return_master.DELIVERYMAN_ID = p_DELIVERYMAN_ID;
                    tsales_return_master.ORDERBOOKER_ID = p_ORDERBOOKER_ID;
                    tsales_return_master.DOCUMENT_DATE = p_DocumentDate;
                    tsales_return_master.CUSTOMER_ID = p_SOLD_TO;
                    tsales_return_master.TOTAL_AMOUNT = p_TOTAL_AMOUNT;
                    tsales_return_master.EXTRA_DISCOUNT_AMOUNT = p_EXTRA_DISCOUNT_AMOUNT;
                    tsales_return_master.STANDARD_DISCOUNT_AMOUNT = p_STANDARD_DISCOUNT_AMOUNT;
                    tsales_return_master.GST_AMOUNT = p_GST_AMOUNT;
                    tsales_return_master.TOTAL_NET_AMOUNT = p_TOTAL_NET_AMOUNT;
                    tsales_return_master.TOWN_ID = p_TOWN_ID;
                    tsales_return_master.TIME_STAMP = DateTime.Now;
                    tsales_return_master.LASTUPDATE_DATE = DateTime.Now;
                    tsales_return_master.TST_AMOUNT = p_TstAmount;
                    tsales_return_master.SED_AMOUNT = decimal.Parse(InvoiceTypeId.ToString());
                    tsales_return_master.IS_DELETED = false;
                    tsales_return_master.POSTING = 0;
                    tsales_return_master.ExecuteQuery();
                    spInsertSALES_RETURN_DETAIL tsales_return_detail = new spInsertSALES_RETURN_DETAIL {
                        Connection = conn,
                        Transaction = transaction
                    };
                    foreach (DataRow row in dtOrderDetail.Rows)
                    {
                        tsales_return_detail.SALES_RETURN_ID = tsales_return_master.SALES_RETURN_ID;
                        tsales_return_detail.DISTRIBUTOR_ID = p_Distributor_id;
                        tsales_return_detail.SKU_ID = int.Parse(row["SKU_ID"].ToString());
                        tsales_return_detail.BATCH_NO = row["BATCH_NO"].ToString();
                        tsales_return_detail.QUANTITY_UNIT = int.Parse(row["QUANTITY_UNIT"].ToString());
                        tsales_return_detail.UNIT_PRICE = decimal.Parse(row["UNIT_PRICE"].ToString());
                        tsales_return_detail.GST_RATE = float.Parse(row["GST_RATE"].ToString());
                        tsales_return_detail.AMOUNT = decimal.Parse(row["AMOUNT"].ToString());
                        tsales_return_detail.EXTRA_DISCOUNT = decimal.Parse(row["EXTRA_DISCOUNT"].ToString());
                        tsales_return_detail.STANDARD_DISCOUNT = decimal.Parse(row["STANDARD_DISCOUNT"].ToString());
                        tsales_return_detail.GST_AMOUNT = decimal.Parse(row["GST_AMOUNT"].ToString());
                        tsales_return_detail.SED_AMOUNT = decimal.Parse(InvoiceTypeId.ToString());
                        tsales_return_detail.NET_AMOUNT = decimal.Parse(row["NET_AMOUNT"].ToString());
                        tsales_return_detail.TIME_STAMP = p_DocumentDate;
                        tsales_return_detail.ExecuteQuery();
                        new UspProcessStockRegister { Connection = conn, Transaction = transaction, TYPE_ID = InvoiceTypeId, DISTRIBUTOR_ID = p_Distributor_id, STOCK_DATE = p_DocumentDate, SKU_ID = tsales_return_detail.SKU_ID, BATCHNO = tsales_return_detail.BATCH_NO, STOCK_QTY = tsales_return_detail.QUANTITY_UNIT, FREE_QTY = 0 }.ExecuteQuery();
                    }
                    transaction.Commit();
                    return true;
                }
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                transaction.Rollback();
                return false;
            }
            finally
            {
                if ((conn != null) && (conn.State == ConnectionState.Open))
                {
                    conn.Close();
                }
            }
            return true;
        }

        public DataTable ChkDupID(int p_MID)
        {
            IDbConnection connection = null;
            DataTable table;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table = new spChkDuplicateManual_invoice_id { Connection = connection, SALE_INVOICE_ID = p_MID }.ExecuteTable();
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                table = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return table;
        }

        public DataTable ConvertOrder_to_Invoice(int p_Distributor_Id, long p_Customer_Id, int p_Principal_Id, long p_SaleOrder_Id, DateTime p_Document_Date, decimal p_GrossSale, decimal p_Discount, decimal p_scheme, decimal p_GstAmt, decimal p_Net_Amount, int p_OrderStatus, int p_OrderTypeId, int p_UserId, string p_PayeesName)
        {
            IDbTransaction mTransaction = null;
            IDbConnection conn = null;
            DataTable table3;
            try
            {
                conn = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                conn.Open();
                UspConvertOrdertoInvoice invoice = new UspConvertOrdertoInvoice();
                mTransaction = ProviderFactory.GetTransaction(conn);
                invoice.Connection = conn;
                invoice.Transaction = mTransaction;
                invoice.DISTRIBUTOR_ID = p_Distributor_Id;
                invoice.PRINCIPAL_ID = p_Principal_Id;
                invoice.CUSTOMER_ID = p_Customer_Id;
                invoice.DOCUMENT_DATE = p_Document_Date;
                invoice.SALE_ORDER_ID = p_SaleOrder_Id;
                if (p_OrderTypeId == 0xd7)
                {
                    invoice.NET_AMOUNT = p_Net_Amount;
                }
                else
                {
                    invoice.NET_AMOUNT = 0M;
                }
                invoice.ORDER_STATUS = p_OrderStatus;
                DataTable table = invoice.ExecuteTable();
                if (table.Columns.Count > 1)
                {
                    mTransaction.Rollback();
                    return table;
                }
                LedgerController controller = new LedgerController();
                Configuration.GetAccountHead();
                DataTable table2 = new DistributorController().SelectDistributor(p_Distributor_Id);
                string s = controller.SelectLedgerMaxDocumentId(0x10, p_Distributor_Id);
                if (int.Parse(table2.Rows[0]["SUBZONE_ID"].ToString()) == 3)
                {
                    controller.PostingInvoiceAccount(0x10, long.Parse(s), long.Parse(Configuration.SaleAccount), p_Distributor_Id, 0M, p_GrossSale, p_Document_Date, "Gross Sale Value", DateTime.Now, p_Principal_Id, int.Parse(p_Customer_Id.ToString()), long.Parse(table.Rows[0][0].ToString()), 13, p_UserId, mTransaction, conn, 0x18, p_PayeesName);
                    if (p_Discount > 0M)
                    {
                        controller.PostingInvoiceAccount(0x10, long.Parse(s), long.Parse(Configuration.SaleDiscount), p_Distributor_Id, p_Discount, 0M, p_Document_Date, "Standard Discount", DateTime.Now, p_Principal_Id, int.Parse(p_Customer_Id.ToString()), long.Parse(table.Rows[0][0].ToString()), 13, p_UserId, mTransaction, conn, 0x18, p_PayeesName);
                    }
                    if (p_scheme > 0M)
                    {
                        controller.PostingInvoiceAccount(0x10, long.Parse(s), long.Parse(Configuration.SaleScheme), p_Distributor_Id, p_scheme, 0M, p_Document_Date, "Extra Discount", DateTime.Now, p_Principal_Id, int.Parse(p_Customer_Id.ToString()), long.Parse(table.Rows[0][0].ToString()), 13, p_UserId, mTransaction, conn, 0x18, p_PayeesName);
                    }
                    if (p_GstAmt > 0M)
                    {
                        controller.PostingInvoiceAccount(0x10, long.Parse(s), long.Parse(Configuration.GSTAccount), p_Distributor_Id, 0M, p_GstAmt, p_Document_Date, "GST Tax", DateTime.Now, p_Principal_Id, int.Parse(p_Customer_Id.ToString()), long.Parse(table.Rows[0][0].ToString()), 13, p_UserId, mTransaction, conn, 0x18, p_PayeesName);
                    }
                    controller.PostingInvoiceAccount(0x10, long.Parse(s), long.Parse(Configuration.AccountReceivable), p_Distributor_Id, p_Net_Amount, 0M, p_Document_Date, "Recevieable from Customer", DateTime.Now, p_Principal_Id, int.Parse(p_Customer_Id.ToString()), long.Parse(table.Rows[0][0].ToString()), 13, p_UserId, mTransaction, conn, 0x18, p_PayeesName);
                }
                else if (p_OrderTypeId == 0xd7)
                {
                    controller.PostingInvoiceAccount(0x10, long.Parse(s), long.Parse(Configuration.AccountReceivable), p_Distributor_Id, p_Net_Amount, 0M, p_Document_Date, "Credit Sale Default", DateTime.Now, p_Principal_Id, int.Parse(p_Customer_Id.ToString()), long.Parse(table.Rows[0][0].ToString()), 13, p_UserId, mTransaction, conn, 0x18, p_PayeesName);
                    controller.PostingInvoiceAccount(0x10, long.Parse(s), long.Parse(Configuration.SaleAccount), p_Distributor_Id, 0M, p_Net_Amount, p_Document_Date, "Credit Sale Default", DateTime.Now, p_Principal_Id, int.Parse(p_Customer_Id.ToString()), long.Parse(table.Rows[0][0].ToString()), 13, p_UserId, mTransaction, conn, 0x18, p_PayeesName);
                }
                mTransaction.Commit();
                table3 = table;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                table3 = null;
            }
            finally
            {
                if ((conn != null) && (conn.State == ConnectionState.Open))
                {
                    conn.Close();
                }
            }
            return table3;
        }

        public bool DeleteFreeSKUFromInvoice(int p_Distributor_Id, long p_Invoice_Id, long p_SalePromotionId, int p_SKU_id, int p_Qty)
        {
            IDbConnection connection = null;
            bool flag;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new UspDeleteFreeSKUOut { Connection = connection, Distributor_id = p_Distributor_Id, InvoiceNo = p_Invoice_Id, SALE_INVOICE_PROMOTION_ID = p_SalePromotionId, SKU_id = p_SKU_id, Qty = p_Qty }.ExecuteQuery();
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

        public bool ExistsInGroup(int p_Sku_Grp_Detail_Id, int p_Sku_Grp_Id, int p_Sku_Id)
        {
            IDbConnection connection = null;
            bool flag;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                spSelectSKU_GROUP_DETAIL tsku_group_detail = new spSelectSKU_GROUP_DETAIL {
                    Connection = connection,
                    SKU_GROUP_DETAIL_ID = p_Sku_Grp_Detail_Id,
                    SKU_GROUP_ID = p_Sku_Grp_Id,
                    SKU_ID = p_Sku_Id
                };
                if (tsku_group_detail.ExecuteTable().Rows.Count > 0)
                {
                    return true;
                }
                flag = false;
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

        public DataTable GetMaxSID()
        {
            IDbConnection connection = null;
            DataTable table;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table = new spGetMaxSALE_INVOICE_MASTER { Connection = connection }.ExecuteTable();
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                table = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return table;
        }

        public DataTable GetOrderClosingStock(int p_DISTRIBUTOR_ID, int p_SKU_ID)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspGetOrderClosingStock { Connection = connection, DISTRIBUTOR_ID = p_DISTRIBUTOR_ID, SKU_ID = p_SKU_ID }.ExecuteTable();
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

        public ArrayList GetPromotionOffers(PromotionCollections_Controller pc, int p_CustomerVoldClass, int p_CustomerId, DataTable p_OrderDetail, bool p_IsScheme)
        {
            int num = 0;
            DataRow row = null;
            PromoOffersCol_Controller controller = new PromoOffersCol_Controller();
            ArrayList list = new ArrayList();
            while (num < pc.Count)
            {
                bool flag = false;
                bool flag2 = false;
                DataTable table = new DataTable();
                table.Columns.Add("GroupId", typeof(long));
                int num2 = 0;
                while (num2 < pc.Get_PCol(num).ObjPromotionCustTypeCol_Cntrl.Count)
                {
                    if (pc.Get_PCol(num).ObjPromotionCustTypeCol_Cntrl.Get(num2).Customer_Type_ID == p_CustomerId)
                    {
                        flag = true;
                        break;
                    }
                    num2++;
                }
                num2 = 0;
                while (num2 < pc.Get_PCol(num).ObjPromotionVolClassCol_Cntrl.Count)
                {
                    if (pc.Get_PCol(num).ObjPromotionVolClassCol_Cntrl.Get(num2).Customer_VolClass_ID == p_CustomerVoldClass)
                    {
                        flag2 = true;
                        break;
                    }
                    num2++;
                }
                if (flag && flag2)
                {
                    for (int i = 0; i < p_OrderDetail.Rows.Count; i++)
                    {
                        row = p_OrderDetail.Rows[i];
                        BasketCollection_Controller controller2 = pc.Get_PCol(num).ObjBasketCol_Cntrl;
                        for (int j = 0; j < controller2.Count; j++)
                        {
                            bool flag3 = false;
                            decimal num5 = 0M;
                            int num6 = 0;
                            BasketDetailCollection_Controller controller3 = controller2.Get(j).ObjBasketDtlCol_Cntrlr;
                            for (num2 = 0; num2 < controller3.Count; num2++)
                            {
                                PromotionOfferColl_Controller controller4;
                                PromoOffers_Collection s_s;
                                int num7;
                                if (controller3.Get(num2).SKU_ID > 0)
                                {
                                    if (controller3.Get(num2).SKU_ID == int.Parse(row["SKU_ID"].ToString()))
                                    {
                                        if (controller2.Get(j).Basket_On == 0x53)
                                        {
                                            num5 = decimal.Parse(row["Amount"].ToString());
                                        }
                                        else if (controller2.Get(j).Basket_On == 0x52)
                                        {
                                            num5 = decimal.Parse(row["QUANTITY_UNIT"].ToString());
                                        }
                                        if ((num5 >= controller3.Get(num2).Min_Val) && ((num5 <= controller3.Get(num2).Max_Val) || (controller3.Get(num2).Max_Val == 0M)))
                                        {
                                            controller4 = controller3.Get(num2).ObjPromotionOfferCol_Cntrl;
                                            s_s = new PromoOffers_Collection();
                                            if ((num5 > controller3.Get(num2).Multiple_Of) && (controller3.Get(num2).Multiple_Of > 0))
                                            {
                                                num7 = Convert.ToInt32(Math.Floor(Convert.ToDouble((decimal) (num5 / controller3.Get(num2).Multiple_Of))));
                                                s_s.Quantity = controller4.Get(num2).Quantity * num7;
                                                s_s.Offer_Value = controller4.Get(num2).Offer_Value * num7;
                                            }
                                            else
                                            {
                                                s_s.Quantity = controller4.Get(num2).Quantity;
                                                s_s.Offer_Value = controller4.Get(num2).Offer_Value;
                                            }
                                            s_s.SKU_ID = int.Parse(row["SKU_ID"].ToString());
                                            s_s.Group_ID = -2147483648;
                                            s_s.Promotion_ID = int.Parse(controller4.Get(num2).Promotion_ID.ToString());
                                            s_s.Scheme_ID = controller4.Get(num2).Scheme_ID;
                                            s_s.Basket_ID = controller4.Get(num2).Basket_ID;
                                            s_s.BasketDetail_ID = controller4.Get(num2).BasketDetail_ID;
                                            s_s.Free_SKU_ID = controller4.Get(num2).SKU_ID;
                                            s_s.Discount = controller4.Get(num2).Discount;
                                            s_s.Is_And = pc.Get_PCol(num).Is_Scheme;
                                            list.Add(s_s);
                                        }
                                    }
                                }
                                else if (controller3.Get(num2).SKUGroup_ID > 0)
                                {
                                    SKUGroupController controller5 = new SKUGroupController();
                                    foreach (DataRow row2 in table.Rows)
                                    {
                                        if (row2[0].ToString() == controller3.Get(num2).SKUGroup_ID.ToString())
                                        {
                                            flag3 = true;
                                        }
                                    }
                                    if (!flag3)
                                    {
                                        num5 = 0M;
                                        num6 = 0;
                                        if (controller2.Get(j).Basket_On == 0x53)
                                        {
                                            foreach (DataRow row3 in p_OrderDetail.Rows)
                                            {
                                                if (this.ExistsInGroup(-2147483648, controller3.Get(num2).SKUGroup_ID, int.Parse(row3["SKU_ID"].ToString())))
                                                {
                                                    num5 += decimal.Parse(row3["AMOUNT"].ToString());
                                                    num6++;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            foreach (DataRow row3 in p_OrderDetail.Rows)
                                            {
                                                if (this.ExistsInGroup(-2147483648, controller3.Get(num2).SKUGroup_ID, int.Parse(row3["SKU_ID"].ToString())))
                                                {
                                                    num5 += decimal.Parse(row3["QUANTITY_UNIT"].ToString());
                                                    num6++;
                                                }
                                            }
                                        }
                                        if ((num5 >= controller3.Get(num2).Min_Val) && ((num5 <= controller3.Get(num2).Max_Val) || (controller3.Get(num2).Max_Val == 0M)))
                                        {
                                            controller4 = controller3.Get(num2).ObjPromotionOfferCol_Cntrl;
                                            s_s = new PromoOffers_Collection();
                                            if ((num5 > controller3.Get(num2).Multiple_Of) && (controller3.Get(num2).Multiple_Of > 0))
                                            {
                                                num7 = Convert.ToInt32(Math.Floor(Convert.ToDouble((decimal) (num5 / controller3.Get(num2).Multiple_Of))));
                                                s_s.Quantity = controller4.Get(num2).Quantity * num7;
                                                s_s.Offer_Value = (controller4.Get(num2).Offer_Value * num7) / num6;
                                            }
                                            else
                                            {
                                                s_s.Quantity = controller4.Get(num2).Quantity;
                                                s_s.Offer_Value = controller4.Get(num2).Offer_Value / num6;
                                            }
                                            s_s.SKU_ID = controller3.Get(num2).SKU_ID;
                                            s_s.Group_ID = controller3.Get(num2).SKUGroup_ID;
                                            s_s.Promotion_ID = int.Parse(controller4.Get(num2).Promotion_ID.ToString());
                                            s_s.Scheme_ID = controller4.Get(num2).Scheme_ID;
                                            s_s.Basket_ID = controller4.Get(num2).Basket_ID;
                                            s_s.BasketDetail_ID = controller4.Get(num2).BasketDetail_ID;
                                            s_s.Free_SKU_ID = controller4.Get(num2).SKU_ID;
                                            s_s.Discount = controller4.Get(num2).Discount;
                                            s_s.Is_And = pc.Get_PCol(num).Is_Scheme;
                                            list.Add(s_s);
                                            DataRow row4 = table.NewRow();
                                            row4[0] = s_s.Group_ID.ToString();
                                            table.Rows.Add(row4);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                num++;
            }
            return list;
        }

        public bool InsertFreeSKU(int p_Distributor_id, long p_SaleInvoiceId, int p_sku_ID, int p_QUANTITY, decimal p_UNIT_PRICE, decimal p_AMOUNT, float p_GST_RATE, decimal p_GST_AMOUNT, DateTime p_DocumentDate, decimal p_TstAmount, decimal p_SedAmount)
        {
            IDbConnection connection = null;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                spInsertManualSALE_INVOICE_PROMOTION lsale_invoice_promotion = new spInsertManualSALE_INVOICE_PROMOTION {
                    Connection = connection,
                    BASKET_DETAIL_ID = -1,
                    BASKET_ID = -1,
                    DISTRIBUTOR_ID = p_Distributor_id,
                    GST_AMOUNT = p_GST_AMOUNT,
                    GST_RATE = p_GST_RATE,
                    PROMOTION_ID = -1,
                    PROMOTION_OFFER_ID = -1,
                    QUANTITY = p_QUANTITY,
                    SKU_ID = p_sku_ID,
                    UNIT_PRICE = p_UNIT_PRICE,
                    SALE_INVOICE_ID = p_SaleInvoiceId,
                    AMOUNT = p_AMOUNT,
                    SED_AMOUNT = p_SedAmount,
                    TST_AMOUNT = p_TstAmount
                };
                lsale_invoice_promotion.ExecuteQuery();
                new UspProcessStockRegister { Connection = connection, TYPE_ID = 13, DISTRIBUTOR_ID = p_Distributor_id, STOCK_DATE = p_DocumentDate, SKU_ID = lsale_invoice_promotion.SKU_ID, BATCHNO = "N/A", STOCK_QTY = 0, FREE_QTY = p_QUANTITY }.ExecuteQuery();
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

        public PromotionCollections_Controller LoadSchemes(int p_DistId, int Princpal_Id, DateTime pCurrentDate)
        {
            IDbConnection connection = null;
            PromotionCollections_Controller controller2;
            DataControl control = new DataControl();
            PromotionCollections_Controller controller = new PromotionCollections_Controller();
            DataTable table2 = null;
            DataTable table3 = null;
            DataTable table4 = null;
            DataTable table5 = null;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectPROMOTIONS { Connection = connection, DISTRIBUTOR_ID = p_DistId, PROMOTION_TYPE = Princpal_Id, IS_ACTIVE = true, START_DATE = DateTime.Parse(pCurrentDate.ToShortDateString() + " 00:00:00"), END_DATE = DateTime.Parse(pCurrentDate.ToShortDateString() + " 23:59:59") }.ExecuteTable();
                for (int i = 0; i <= (table2.Rows.Count - 1); i++)
                {
                    Promotion_Collection n_s = new Promotion_Collection {
                        ObjBasketCol_Cntrl = new BasketCollection_Controller(),
                        ObjPromotionCustTypeCol_Cntrl = new PromotionCustTypeColl_Controller(),
                        ObjPromotionForCol_Cntrl = new PromotionForCollection_Controller(),
                        ObjPromotionVolClassCol_Cntrl = new PromotionCustVolclassColl_Controller(),
                        Dist_ID = int.Parse(table2.Rows[i]["Distributor_ID"].ToString()),
                        Promotion_Code = table2.Rows[i]["PROMOTION_CODE"].ToString(),
                        Promotion_Date = DateTime.Parse(table2.Rows[i]["Promo_Date"].ToString()),
                        Promotion_Desc = table2.Rows[i]["Promotion_Description"].ToString(),
                        Promotion_ID = long.Parse(table2.Rows[i]["Promotion_ID"].ToString())
                    };
                    if (table2.Rows[i]["Promotion_Selection"].ToString() != "")
                    {
                        n_s.Promotion_Selection = int.Parse(table2.Rows[i]["Promotion_Selection"].ToString());
                    }
                    else
                    {
                        n_s.Promotion_Selection = -1;
                    }
                    if (table2.Rows[i]["Promotion_Type"].ToString() != "")
                    {
                        n_s.Promotion_Type = int.Parse(table2.Rows[i]["Promotion_Type"].ToString());
                    }
                    else
                    {
                        n_s.Promotion_Type = -1;
                    }
                    n_s.Scheme_ID = int.Parse(table2.Rows[i]["Scheme_ID"].ToString());
                    n_s.Start_Date = DateTime.Parse(table2.Rows[i]["Start_Date"].ToString());
                    n_s.End_Date = DateTime.Parse(table2.Rows[i]["End_Date"].ToString());
                    n_s.Claimable = bool.Parse(table2.Rows[i]["Claimable"].ToString());
                    n_s.Is_Scheme = bool.Parse(table2.Rows[i]["IS_SCHEME"].ToString());
                    table3 = new uspSelectBASKET_MASTER_dt { Connection = connection, DISTRIBUTOR_ID = n_s.Dist_ID, SCHEME_ID = Convert.ToInt32(n_s.Scheme_ID), PROMOTION_ID = Convert.ToInt32(n_s.Promotion_ID) }.ExecuteTable();
                    int num2 = 0;
                    while (num2 <= (table3.Rows.Count - 1))
                    {
                        Basket_Collection t_s = new Basket_Collection {
                            ObjBasketDtlCol_Cntrlr = new BasketDetailCollection_Controller(),
                            Basket_ID = long.Parse(table3.Rows[num2]["Basket_ID"].ToString()),
                            Basket_On = int.Parse(table3.Rows[num2]["Basket_On"].ToString())
                        };
                        if (table3.Rows[num2]["Basket_Selection"].ToString() != "")
                        {
                            t_s.Basket_Selection = int.Parse(table3.Rows[num2]["Basket_Selection"].ToString());
                        }
                        else
                        {
                            t_s.Basket_Selection = 0;
                        }
                        t_s.Dist_ID = int.Parse(table3.Rows[num2]["Distributor_ID"].ToString());
                        t_s.Is_And = bool.Parse(table3.Rows[num2]["IS_AND"].ToString());
                        t_s.Is_Basket = bool.Parse(table3.Rows[num2]["IS_Basket"].ToString());
                        t_s.Is_Multiple = bool.Parse(table3.Rows[num2]["IS_Multiple"].ToString());
                        t_s.Promotion_ID = long.Parse(table3.Rows[num2]["Promotion_ID"].ToString());
                        t_s.Scheme_ID = int.Parse(table2.Rows[i]["Scheme_ID"].ToString());
                        table4 = new uspSelectBASKET_DETAIL_dt { Connection = connection, BASKET_ID = Convert.ToInt32(t_s.Basket_ID), DISTRIBUTOR_ID = t_s.Dist_ID, SCHEME_ID = Convert.ToInt32(n_s.Scheme_ID), PROMOTION_ID = Convert.ToInt32(n_s.Promotion_ID) }.ExecuteTable();
                        for (int j = 0; j <= (table4.Rows.Count - 1); j++)
                        {
                            Basket_Detail_Collection l_s = new Basket_Detail_Collection {
                                ObjPromotionOfferCol_Cntrl = new PromotionOfferColl_Controller(),
                                Basket_ID = long.Parse(table4.Rows[j]["Basket_ID"].ToString()),
                                BasketDetail_ID = long.Parse(table4.Rows[j]["Basket_Detail_ID"].ToString()),
                                Dist_ID = int.Parse(table4.Rows[j]["Distributor_ID"].ToString()),
                                Max_Val = decimal.Parse(table4.Rows[j]["Max_Val"].ToString()),
                                Min_Val = decimal.Parse(table4.Rows[j]["Min_Val"].ToString()),
                                Multiple_Of = int.Parse(control.chkNull(table4.Rows[j]["Multiple_of"].ToString())),
                                Promotion_ID = long.Parse(table4.Rows[j]["Promotion_ID"].ToString()),
                                Scheme_ID = int.Parse(table4.Rows[j]["Scheme_ID"].ToString()),
                                SKU_ID = int.Parse(control.chkNull(table4.Rows[j]["SKU_ID"].ToString())),
                                SKUBrand_ID = int.Parse(control.chkNull(table4.Rows[j]["Brand_ID"].ToString())),
                                SKUCatg_ID = int.Parse(control.chkNull(table4.Rows[j]["Category_ID"].ToString())),
                                SKUDiv_ID = int.Parse(control.chkNull(table4.Rows[j]["Division_ID"].ToString())),
                                SKUGroup_ID = int.Parse(control.chkNull(table4.Rows[j]["SKU_Group_ID"].ToString())),
                                SKUProductLine_ID = int.Parse(control.chkNull(table4.Rows[j]["Variant_ID"].ToString())),
                                UOM_ID = int.Parse(control.chkNull(table4.Rows[j]["UOM_ID"].ToString())),
                                SKUCompany_ID = int.Parse(control.chkNull(table4.Rows[j]["Company_ID"].ToString()))
                            };
                            t_s.ObjBasketDtlCol_Cntrlr.Add(l_s);
                            uspSelectPROMOTION_OFFER_dt _dt3 = new uspSelectPROMOTION_OFFER_dt {
                                Connection = connection,
                                BASKET_ID = Convert.ToInt32(t_s.Basket_ID),
                                DISTRIBUTOR_ID = t_s.Dist_ID,
                                SCHEME_ID = Convert.ToInt32(n_s.Scheme_ID),
                                PROMOTION_ID = Convert.ToInt32(n_s.Promotion_ID),
                                BASKET_DETAIL_ID = Convert.ToInt32(l_s.BasketDetail_ID)
                            };
                            table5 = null;
                            table5 = _dt3.ExecuteTable();
                            for (int k = 0; k <= (table5.Rows.Count - 1); k++)
                            {
                                string s = table5.Rows[k]["Discount"].ToString();
                                string str2 = table5.Rows[k]["Offer_Value"].ToString();
                                string str3 = table5.Rows[k]["Quantity"].ToString();
                                switch (s)
                                {
                                    case "":
                                    case null:
                                        s = "0";
                                        break;
                                }
                                if ((str2 == "") || (str2 == null))
                                {
                                    str2 = "0";
                                }
                                if ((str3 == "") || (str3 == null))
                                {
                                    str3 = "0";
                                }
                                PromotionOffer_Collection r_s = new PromotionOffer_Collection {
                                    Basket_ID = long.Parse(table5.Rows[k]["Basket_ID"].ToString()),
                                    BasketDetail_ID = long.Parse(table5.Rows[k]["Basket_Detail_ID"].ToString()),
                                    Discount = float.Parse(s),
                                    Dist_ID = int.Parse(table5.Rows[k]["Distributor_ID"].ToString()),
                                    Is_And = bool.Parse(table5.Rows[k]["Is_And"].ToString()),
                                    Offer_Value = decimal.Parse(str2),
                                    Promotion_ID = long.Parse(table5.Rows[k]["Promotion_ID"].ToString()),
                                    Promotion_Offer_ID = long.Parse(table5.Rows[k]["Promotion_Offer_ID"].ToString()),
                                    Quantity = int.Parse(str3),
                                    Scheme_ID = int.Parse(table5.Rows[k]["Scheme_ID"].ToString()),
                                    SKU_ID = int.Parse(control.chkNull(table5.Rows[k]["SKU_ID"].ToString())),
                                    UOM_ID = int.Parse(control.chkNull(table5.Rows[k]["UOM_ID"].ToString()))
                                };
                                l_s.ObjPromotionOfferCol_Cntrl.Add(r_s);
                            }
                        }
                        n_s.ObjBasketCol_Cntrl.Add(t_s);
                        num2++;
                    }
                    table3 = null;
                    table3 = new uspSelectPROMOTION_FOR_dt { Connection = connection, PROMOTION_FOR_ID = -9223372036854775808L, DISTRIBUTOR_ID = n_s.Dist_ID, ASSIGNED_DISTRIBUTOR_ID = Configuration.DistributorId, SCHEME_ID = Convert.ToInt32(n_s.Scheme_ID), PROMOTION_ID = Convert.ToInt32(n_s.Promotion_ID) }.ExecuteTable();
                    num2 = 0;
                    while (num2 <= (table3.Rows.Count - 1))
                    {
                        PromotionFor_Collection r_s2 = new PromotionFor_Collection {
                            Dist_ID = int.Parse(table3.Rows[num2]["Distributor_ID"].ToString()),
                            Assigned_Dist_ID = int.Parse(table3.Rows[num2]["Assigned_Distributor_ID"].ToString()),
                            Promotion_For_ID = long.Parse(table3.Rows[num2]["Promotion_For_ID"].ToString()),
                            Promotion_ID = long.Parse(table3.Rows[num2]["Promotion_ID"].ToString()),
                            Scheme_ID = int.Parse(table3.Rows[num2]["Scheme_ID"].ToString())
                        };
                        n_s.ObjPromotionForCol_Cntrl.Add(r_s2);
                        num2++;
                    }
                    table3 = null;
                    table3 = new spSelectPROMOTION_CUSTOMER_VOLUMECLASS { Connection = connection, DISTRIBUTOR_ID = n_s.Dist_ID, SCHEME_ID = Convert.ToInt32(n_s.Scheme_ID), PROMOTION_ID = Convert.ToInt32(n_s.Promotion_ID) }.ExecuteTable();
                    num2 = 0;
                    while (num2 <= (table3.Rows.Count - 1))
                    {
                        PromotionCustomerVolClass_Collection s_s = new PromotionCustomerVolClass_Collection {
                            Dist_ID = int.Parse(table3.Rows[num2]["Distributor_ID"].ToString()),
                            Promotion_ID = long.Parse(table3.Rows[num2]["Promotion_ID"].ToString()),
                            Scheme_ID = int.Parse(table3.Rows[num2]["Scheme_ID"].ToString()),
                            Customer_VolClass_ID = int.Parse(table3.Rows[num2]["CUSTOMER_VOLUMECLASS_ID"].ToString())
                        };
                        n_s.ObjPromotionVolClassCol_Cntrl.Add(s_s);
                        num2++;
                    }
                    table3 = null;
                    table3 = new uspSelectPROMOTION_CUSTOMER_TYPE_dt { Connection = connection, DISTRIBUTOR_ID = n_s.Dist_ID, SCHEME_ID = Convert.ToInt32(n_s.Scheme_ID), PROMOTION_ID = Convert.ToInt32(n_s.Promotion_ID) }.ExecuteTable();
                    for (num2 = 0; num2 <= (table3.Rows.Count - 1); num2++)
                    {
                        PromotionCustomerType_Collection e_s = new PromotionCustomerType_Collection {
                            Dist_ID = int.Parse(table3.Rows[num2]["Distributor_ID"].ToString()),
                            Customer_Type_ID = int.Parse(table3.Rows[num2]["Customer_Type_ID"].ToString()),
                            Promotion_Cust_Type_ID = long.Parse(table3.Rows[num2]["Promotion_Customer_Type_ID"].ToString()),
                            Promotion_ID = long.Parse(table3.Rows[num2]["Promotion_ID"].ToString()),
                            Scheme_ID = int.Parse(table3.Rows[num2]["Scheme_ID"].ToString())
                        };
                        n_s.ObjPromotionCustTypeCol_Cntrl.Add(e_s);
                    }
                    controller.Add_PCol(n_s);
                }
                controller2 = controller;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                controller2 = null;
            }
            finally
            {
                if ((connection != null) && (connection.State != ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return controller2;
        }

        public bool OpeningCredit(int p_Distributor_id, int p_TOWN_ID, long p_AREA_ID, DateTime p_DocumentDate, int p_PRINCIPAL_ID, long p_SOLD_TO, long p_SHIP_TO, int p_ORDERBOOKER_ID, int p_DELIVERYMAN_ID, decimal p_TOTAL_NET_AMOUNT, int p_UserId, int p_MANUAL_INVOICE_ID)
        {
            IDbConnection conn = null;
            IDbTransaction mTransaction = null;
            bool flag;
            try
            {
                conn = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                conn.Open();
                mTransaction = ProviderFactory.GetTransaction(conn);
                spInsertSALE_INVOICE_MASTER tsale_invoice_master = new spInsertSALE_INVOICE_MASTER {
                    Connection = conn,
                    Transaction = mTransaction,
                    DISTRIBUTOR_ID = p_Distributor_id,
                    PRINCIPAL_ID = p_PRINCIPAL_ID,
                    AREA_ID = p_AREA_ID,
                    DELIVERYMAN_ID = p_DELIVERYMAN_ID,
                    ORDERBOOKER_ID = p_ORDERBOOKER_ID,
                    DOCUMENT_DATE = p_DocumentDate,
                    SOLD_TO = p_SOLD_TO,
                    TOTAL_NET_AMOUNT = p_TOTAL_NET_AMOUNT,
                    CREDIT_AMOUNT = p_TOTAL_NET_AMOUNT,
                    CURRENT_CREDIT_AMOUNT = p_TOTAL_NET_AMOUNT,
                    TOWN_ID = p_TOWN_ID,
                    USER_ID = p_UserId,
                    SALE_ORDER_ID = -1L,
                    TIME_STAMP = DateTime.Now,
                    LASTUPDATE_DATE = DateTime.Now,
                    IS_DELETED = false,
                    MANUAL_INVOICE_ID = p_MANUAL_INVOICE_ID
                };
                tsale_invoice_master.ExecuteQuery();
                LedgerController controller = new LedgerController();
                Configuration.GetAccountHead();
                string s = controller.SelectLedgerMaxDocumentId(0x10, p_Distributor_id);
                controller.PostingInvoiceAccount(0x10, long.Parse(s), long.Parse(Configuration.AccountReceivable), p_Distributor_id, p_TOTAL_NET_AMOUNT, 0M, tsale_invoice_master.DOCUMENT_DATE, "Cash Sale Default", DateTime.Now, p_PRINCIPAL_ID, int.Parse(p_SOLD_TO.ToString()), tsale_invoice_master.SALE_INVOICE_ID, 13, p_UserId, mTransaction, conn, 0x18, p_DELIVERYMAN_ID.ToString());
                controller.PostingInvoiceAccount(0x10, long.Parse(s), long.Parse(Configuration.SaleAccount), p_Distributor_id, 0M, p_TOTAL_NET_AMOUNT, tsale_invoice_master.DOCUMENT_DATE, "Cash Sale Default", DateTime.Now, p_PRINCIPAL_ID, int.Parse(p_SOLD_TO.ToString()), tsale_invoice_master.SALE_INVOICE_ID, 13, p_UserId, mTransaction, conn, 0x18, p_DELIVERYMAN_ID.ToString());
                mTransaction.Commit();
                flag = true;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                flag = false;
            }
            finally
            {
                if ((conn != null) && (conn.State == ConnectionState.Open))
                {
                    conn.Close();
                }
            }
            return flag;
        }

        public bool PostTranspoterExp(int p_Distributor_id, long p_SaleInvoiceId, int p_Transport_ID, string p_Bilty_no, string p_DilveryChallan, decimal p_Exp)
        {
            IDbConnection connection = null;
            bool flag;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                flag = new spInsertDTINVOICE_BILLTY_DETAIL { Connection = connection, DISTRIBUTOR_ID = p_Distributor_id, SALE_INVOICE_NO = p_SaleInvoiceId, TRANSPOTER_NO = p_Transport_ID, BILTY_NO = p_Bilty_no, DELIVERY_CHALLAN_NO = p_DilveryChallan, TOTAL_EXPENCESS = p_Exp }.ExecuteQuery();
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

        public DataTable SelectInvoicePromotion(int p_Distributor_Id, long p_SaleInvoice_Id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectSALE_INVOICE_PROMOTION { Connection = connection, DISTRIBUTOR_ID = p_Distributor_Id, SALE_INVOICE_ID = p_SaleInvoice_Id }.ExecuteTable();
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

        public DataTable SelectLegend()
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectLEGEND { Connection = connection, LEGEND_ID = -2147483648, LEGEND_TYPE_ID = -2147483648, TIMESTAMP = Constants.DateNullValue, LAST_UPDATE_DATE = Constants.DateNullValue, LEGEND_DESCRIPTION = null, LEGEND_NAME = null, IS_ACTIVE = true, USER_ID = -2147483648 }.ExecuteTable();
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

        public DataTable SelectOrderDetail(int p_Distributor_Id, long p_SaleOrder_Id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectSALE_ORDER_DETAIL { Connection = connection, DISTRIBUTOR_ID = p_Distributor_Id, SALE_ORDER_ID = p_SaleOrder_Id, IS_DELETED = false }.ExecuteTable();
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

        public DataTable SelectOrderPromotion(int p_Distributor_Id, long p_SaleOrder_Id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectSALE_ORDER_PROMOTION { Connection = connection, DISTRIBUTOR_ID = p_Distributor_Id, SALE_ORDER_ID = p_SaleOrder_Id }.ExecuteTable();
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

        public DataTable SelectPendingOrder(int p_Distributor_Id, int p_Area_Id, int p_Principal_Id, int p_Order_Booker, int p_DeliveryMan_Id, int p_OrderStatus, int p_Ordertype, int p_UserId, DateTime P_DOCUMENT_DATE)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new UspSelectPendingOrder { Connection = connection, DISTRIBUTOR_ID = p_Distributor_Id, AREA_ID = p_Area_Id, ORDERBOOKER_ID = p_Order_Booker, DELIVERYMAN_ID = p_DeliveryMan_Id, USER_ID = p_UserId, PRINCIPAL_ID = p_Principal_Id, STATUS_ID = p_OrderStatus, ORDER_TYPE_ID = p_Ordertype, DOCUMENT_DATE = P_DOCUMENT_DATE }.ExecuteTable();
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

        public DataTable SelectRollBackDocument(int p_Distributor_Id, int p_Principal_Id, int p_Order_Booker, int p_TypeId, DateTime p_DocumentDate)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new UspSelectRollBackDocument { Connection = connection, DISTRIBUTOR_ID = p_Distributor_Id, DOCUMENT_TYPE = p_TypeId, PRINCIPAL_ID = p_Principal_Id, ORDERBOOKER_ID = p_Order_Booker, DOCUMENT_DATE = p_DocumentDate }.ExecuteTable();
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

        public DataTable SelectTranspoter()
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectTRANSPOTER { Connection = connection }.ExecuteTable();
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

        public DataTable SelectTranspoterInvoice(int p_Distributor_id, long p_CustomerId, int p_type)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new UspSelectTranspoterInvoice { Connection = connection, DISTRIBUTOR_ID = p_Distributor_id, CUSTOMER_ID = p_CustomerId, TypeId = p_type }.ExecuteTable();
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

        public bool UpdateRollBackDocument(long p_DocumentId, int p_Type_Id, int p_LegendId)
        {
            IDbConnection connection = null;
            bool flag;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new UspRollBackDocument { Connection = connection, DOCUMENT_ID = p_DocumentId, DOCUMENT_TYPE = p_Type_Id, LEGEND_ID = p_LegendId }.ExecuteQuery();
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

