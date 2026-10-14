namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Collections;
    using System.Data;

    public class TransferDocumentControl
    {
        public static IDbConnection mConnection;
        public static ArrayList sale_transfer = new ArrayList();
        public static ArrayList sale_transfer_details = new ArrayList();
        private long SaleTransferID;

        public static DataTable GetAllSKUS(int DistributorID)
        {
            mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
            try
            {
                try
                {
                    mConnection.Open();
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            finally
            {
            }
            DataTable table = new uspSelect_SKU_Dist_Wise1 { Connection = mConnection, Dist_ID = DistributorID }.ExecuteTable();
            if ((mConnection != null) && (mConnection.State == ConnectionState.Open))
            {
                mConnection.Close();
            }
            mConnection = null;
            return table;
        }

        public static DataTable GetBatches(long SaleInvoiceID)
        {
            mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
            try
            {
                try
                {
                    mConnection.Open();
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            finally
            {
            }
            DataTable table = new uspSelectSALE_INVOICE_DETAILS1 { Connection = mConnection, SALE_INVOICE_ID = SaleInvoiceID }.ExecuteTable();
            if ((mConnection != null) && (mConnection.State == ConnectionState.Open))
            {
                mConnection.Close();
            }
            mConnection = null;
            return table;
        }

        public static DataTable GetCustomerSALE_ORDER_And_INVOICE(long CustomerID)
        {
            mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
            try
            {
                try
                {
                    mConnection.Open();
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            finally
            {
            }
            DataTable table = new uspSelectSALE_INVOICE_MASTERS { Connection = mConnection, SOLD_TO = CustomerID }.ExecuteTable();
            if ((mConnection != null) && (mConnection.State == ConnectionState.Open))
            {
                mConnection.Close();
            }
            mConnection = null;
            return table;
        }

        public static DataTable GetSaleInvoiceDetailInfo(long SaleInvoiceID, string batch_no, int skuID)
        {
            mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
            try
            {
                try
                {
                    mConnection.Open();
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            finally
            {
            }
            DataTable table = new uspSelectSALE_INVOICE_DETAIL2 { Connection = mConnection, SALE_INVOICE_ID = SaleInvoiceID, BATCH_NO = batch_no, SKU_ID = skuID }.ExecuteTable();
            if ((mConnection != null) && (mConnection.State == ConnectionState.Open))
            {
                mConnection.Close();
            }
            mConnection = null;
            return table;
        }

        public static DataTable GetSKUS(long SALE_INVOICE_ID, int DistributorID)
        {
            mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
            try
            {
                try
                {
                    mConnection.Open();
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            finally
            {
            }
            DataTable table = new uspSelectSALE_INVOICE_DETAILS { Connection = mConnection, SALE_INVOICE_ID = SALE_INVOICE_ID, DISTRIBUTOR_ID = DistributorID }.ExecuteTable();
            if ((mConnection != null) && (mConnection.State == ConnectionState.Open))
            {
                mConnection.Close();
            }
            mConnection = null;
            return table;
        }

        public static bool Is_SaleInvoiceID_And_BatchNoExists(long SaleInvoiceID, string BatchNo, int skuID)
        {
            mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
            try
            {
                try
                {
                    mConnection.Open();
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            finally
            {
            }
            DataTable table = new uspSelectSALE_TRANSFER_DETAIL { Connection = mConnection, SALE_INVOICE_ID = SaleInvoiceID, BATCH_NO = BatchNo, SKU_ID = skuID }.ExecuteTable();
            if ((mConnection != null) && (mConnection.State == ConnectionState.Open))
            {
                mConnection.Close();
            }
            mConnection = null;
            if (table.Rows.Count > 0)
            {
                return true;
            }
            if ((sale_transfer.Count > 0) && (sale_transfer_details.Count > 0))
            {
                for (int i = 0; (i < sale_transfer.Count) && (i < sale_transfer_details.Count); i++)
                {
                    if ((((spInsertSALE_TRANSFER) sale_transfer[i]).SALE_INVOICE_ID == SaleInvoiceID) && (((spInsertSALE_TRANSFER_DETAIL) sale_transfer_details[i]).BATCH_NO == BatchNo))
                    {
                        return true;
                    }
                }
                return false;
            }
            return false;
        }

        public static void Save()
        {
            mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
            try
            {
                try
                {
                    mConnection.Open();
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            finally
            {
            }
            for (int i = 0; (i < sale_transfer.Count) && (i < sale_transfer_details.Count); i++)
            {
                ((spInsertSALE_TRANSFER) sale_transfer[i]).Connection = mConnection;
                long num2 = ((spInsertSALE_TRANSFER) sale_transfer[i]).ExecuteQuery();
                ((spInsertSALE_TRANSFER_DETAIL) sale_transfer_details[i]).Connection = mConnection;
                ((spInsertSALE_TRANSFER_DETAIL) sale_transfer_details[i]).SALE_TRANSFER_ID = num2;
                ((spInsertSALE_TRANSFER_DETAIL) sale_transfer_details[i]).ExecuteQuery();
            }
            if ((mConnection != null) && (mConnection.State == ConnectionState.Open))
            {
                mConnection.Close();
            }
            mConnection = null;
            sale_transfer = null;
            sale_transfer = new ArrayList();
            sale_transfer_details = null;
            sale_transfer_details = new ArrayList();
        }

        public static void Save_SaleTransfer(long SaleInvoiceID, long CustomerID)
        {
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
            try
            {
                try
                {
                    mConnection.Open();
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            finally
            {
            }
            DataTable table = new spSelectSALE_INVOICE_MASTER { 
                Connection = mConnection, SALE_INVOICE_ID = SaleInvoiceID, SALE_ORDER_ID = -9223372036854775808L, SHIP_TO = -9223372036854775808L, SHIPMENT_DATE = Constants.DateNullValue, SOLD_TO = -9223372036854775808L, STANDARD_DISCOUNT_AMOUNT = -79228162514264337593543950335M, TERRITORY_ID = -2147483648, TIME_STAMP = Constants.DateNullValue, TOTAL_AMOUNT = -79228162514264337593543950335M, TOTAL_CLAIM_AMOUNT = -79228162514264337593543950335M, TOTAL_NET_AMOUNT = -79228162514264337593543950335M, ORDERBOOKER_ID = -2147483648, DELIVERYMAN_ID = -2147483648, LASTUPDATE_DATE = Constants.DateNullValue, GST_AMOUNT = -79228162514264337593543950335M, 
                AREA_ID = -9223372036854775808L, EXTRA_DISCOUNT_AMOUNT = -79228162514264337593543950335M, DOCUMENT_DATE = Constants.DateNullValue, DISTRIBUTOR_ID = -2147483648
             }.ExecuteTable();
            if (table.Rows.Count > 0)
            {
                num = int.Parse(table.Rows[0]["TERRITORY_ID"].ToString());
                num3 = int.Parse(table.Rows[0]["ORDERBOOKER_ID"].ToString());
                num2 = int.Parse(table.Rows[0]["DELIVERYMAN_ID"].ToString());
            }
            if ((mConnection != null) && (mConnection.State == ConnectionState.Open))
            {
                mConnection.Close();
            }
            mConnection = null;
            spInsertSALE_TRANSFER tsale_transfer = new spInsertSALE_TRANSFER {
                CUSTOMER_ID = CustomerID,
                DELIVERYMAN_ID = num2,
                DOCUMENT_DATE = DateTime.Now,
                ORDERBOOKER_ID = num3,
                SALE_INVOICE_ID = SaleInvoiceID,
                TERRITORY_ID = num,
                TIME_STAMP = DateTime.Now
            };
            sale_transfer.Add(tsale_transfer);
        }

        public static void Save_SaleTransferDetail(long SaleInvoiceDetailID, int SKU, int ReplacedSKU, int quantity, string batch_no, string replaced_batch_no)
        {
            spInsertSALE_TRANSFER_DETAIL tsale_transfer_detail = new spInsertSALE_TRANSFER_DETAIL {
                SKU_ID = SKU,
                SALE_INVOICE_DETAIL_ID = SaleInvoiceDetailID,
                REPLACED_SKU_ID = ReplacedSKU,
                QUANTITY_UNIT = quantity,
                BATCH_NO = batch_no,
                REPLACED_BATCH_NO = replaced_batch_no
            };
            sale_transfer_details.Add(tsale_transfer_detail);
        }
    }
}

