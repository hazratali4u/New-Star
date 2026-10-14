namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class LedgerController
    {
        public bool Add_Voucher(int p_Distributor_id, int p_PRINCIPAL_ID, string p_VOUCHER_NO, int p_VOUCHER_TYPE_ID, DateTime p_VOUCHER_DATE, int p_PAYMENT_MODE, string p_PayeesName, string p_Remarks, DateTime ChequeDate, string ChequeNo, DataTable dtVoucherDetail, int p_UserId)
        {
            IDbConnection conn = null;
            IDbTransaction transaction = null;
            try
            {
                conn = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                conn.Open();
                transaction = ProviderFactory.GetTransaction(conn);
                new spDeleteGL_MASTER { Connection = conn, Transaction = transaction, DISTRIBUTOR_ID = p_Distributor_id, VOUCHER_TYPE_ID = p_VOUCHER_TYPE_ID, VOUCHER_NO = p_VOUCHER_NO }.ExecuteQuery();
                spInsertGL_MASTER tgl_master = new spInsertGL_MASTER {
                    Connection = conn,
                    Transaction = transaction
                };
                if (dtVoucherDetail.Rows.Count > 0)
                {
                    tgl_master.DISTRIBUTOR_ID = p_Distributor_id;
                    tgl_master.PRINCIPAL_ID = p_PRINCIPAL_ID;
                    tgl_master.VOUCHER_TYPE_ID = p_VOUCHER_TYPE_ID;
                    tgl_master.VOUCHER_NO = p_VOUCHER_NO;
                    tgl_master.VOUCHER_DATE = p_VOUCHER_DATE;
                    tgl_master.PAYMENT_MODE = p_PAYMENT_MODE;
                    tgl_master.CHEQUE_DATE = ChequeDate;
                    tgl_master.CHEQUE_NO = ChequeNo;
                    tgl_master.PAYEES_NAME = p_PayeesName;
                    tgl_master.REMARKS = p_Remarks;
                    tgl_master.TIME_STAMP = DateTime.Now;
                    tgl_master.USER_ID = p_UserId;
                    tgl_master.IS_POSTED = false;
                    tgl_master.IS_DELETED = false;
                    tgl_master.ExecuteQuery();
                    spInsertGL_DETAIL tgl_detail = new spInsertGL_DETAIL {
                        Connection = conn,
                        Transaction = transaction
                    };
                    foreach (DataRow row in dtVoucherDetail.Rows)
                    {
                        tgl_detail.DISTRIBUTOR_ID = p_Distributor_id;
                        tgl_detail.PRINCIPAL_ID = p_PRINCIPAL_ID;
                        tgl_detail.VOUCHER_TYPE_ID = p_VOUCHER_TYPE_ID;
                        tgl_detail.VOUCHER_NO = p_VOUCHER_NO;
                        tgl_detail.ACCOUNT_HEAD_ID = long.Parse(row["ACCOUNT_HEAD_ID"].ToString());
                        tgl_detail.DEBIT = decimal.Parse(row["DEBIT"].ToString());
                        tgl_detail.CREDIT = decimal.Parse(row["CREDIT"].ToString());
                        tgl_detail.GL_REMARKS = row["REMARKS"].ToString();
                        tgl_detail.IS_DELETED = false;
                        tgl_detail.ExecuteQuery();
                    }
                    transaction.Commit();
                    return true;
                }
            }
            catch (Exception exception)
            {
                transaction.Rollback();
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

        public void DeleteCashBankTransction(int p_DistributorId, int p_Document_Type, long p_Voucher_no, long Document_no, decimal TotalAmount)
        {
            IDbConnection connection = null;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new UspDELETEBankCashDetail { Connection = connection, Distributor_id = p_DistributorId, Document_Type_Id = p_Document_Type, VOUCHER_NO = p_Voucher_no, DOCUMENT_NO = Document_no, AMOUNT = TotalAmount }.ExecuteQuery();
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
            }
        }

        public void DeleteVoucher(int p_VOUCHER_TYPE_ID, long p_VOUCHER_NO, int p_Distributor_Id)
        {
            IDbConnection connection = null;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spDeleteLEDGER { Connection = connection, DISTRIBUTOR_ID = p_Distributor_Id, VOUCHER_NO = p_VOUCHER_NO, VOUCHER_TYPE_ID = p_VOUCHER_TYPE_ID }.ExecuteQuery();
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
            }
        }

        public void DeleteWareHouseLedger(int p_DistributorId, int p_Document_Type, long p_Voucher_no, long Document_no, decimal TotalAmount)
        {
            IDbConnection connection = null;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new UspDELETEwareHouseLedger { Connection = connection, Distributor_id = p_DistributorId, Document_Type_Id = p_Document_Type, VOUCHER_NO = p_Voucher_no, AMOUNT = TotalAmount }.ExecuteQuery();
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
            }
        }

        public void PostingCash_Bank_Account(long p_LedgerId, int p_VOUCHER_TYPE_ID, long p_VOUCHER_NO, long p_ACCOUNT_HEAD_ID, int p_Distributor_Id, decimal p_Debit, decimal p_Credit, DateTime p_Ledger_Date, string p_Remarks, DateTime p_TimeStamp, int p_Customer_ID, int p_Principal, string p_Cheque_NO, int p_UserId, long p_Document_Id, int p_DocumentTypeId, string SlipNo, DateTime p_ChequeDate)
        {
            IDbConnection connection = null;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spInsertLEDGER { 
                    Connection = connection, ACCOUNT_HEAD_ID = p_ACCOUNT_HEAD_ID, DISTRIBUTOR_ID = p_Distributor_Id, VOUCHER_NO = p_VOUCHER_NO, VOUCHER_TYPE_ID = p_VOUCHER_TYPE_ID, DEBIT = p_Debit, CREDIT = p_Credit, LEDGER_DATE = p_Ledger_Date, DOCUMENT_NO = p_Document_Id, DOCUMENT_TYPE_ID = p_DocumentTypeId, REMARKS = p_Remarks, TIME_STAMP = p_TimeStamp, CUSTOMER_ID = p_Customer_ID, PRINCIPAL_ID = p_Principal, CHEQUE_NO = p_Cheque_NO.ToString(), USER_ID = p_UserId, 
                    SLIP_NO = SlipNo, CHQUE_DATE = p_ChequeDate, POSTING = 0, IS_DELETED = 0
                 }.ExecuteQuery();
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
            }
        }

        public void PostingCash_Bank_Account(int p_VOUCHER_TYPE_ID, long p_VOUCHER_NO, long p_ACCOUNT_HEAD_ID, int p_Distributor_Id, decimal p_Debit, decimal p_Credit, DateTime p_Ledger_Date, string p_Remarks, DateTime p_TimeStamp, int p_Customer_ID, int p_Principal, string p_Cheque_NO, int p_UserId, long p_Document_Id, int p_DocumentTypeId, string SlipNo, DateTime p_ChequeDate, int p_PaymentMode, string p_PayeesName)
        {
            IDbConnection connection = null;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spInsertLEDGER { 
                    Connection = connection, ACCOUNT_HEAD_ID = p_ACCOUNT_HEAD_ID, DISTRIBUTOR_ID = p_Distributor_Id, VOUCHER_NO = p_VOUCHER_NO, VOUCHER_TYPE_ID = p_VOUCHER_TYPE_ID, DEBIT = p_Debit, CREDIT = p_Credit, LEDGER_DATE = p_Ledger_Date, DOCUMENT_NO = p_Document_Id, DOCUMENT_TYPE_ID = p_DocumentTypeId, REMARKS = p_Remarks, TIME_STAMP = p_TimeStamp, CUSTOMER_ID = p_Customer_ID, PRINCIPAL_ID = p_Principal, CHEQUE_NO = p_Cheque_NO, USER_ID = p_UserId, 
                    SLIP_NO = SlipNo, CHQUE_DATE = p_ChequeDate, PAYMENT_MODE = p_PaymentMode, PAYEE_NAME = p_PayeesName, POSTING = 0, IS_DELETED = 0
                 }.ExecuteQuery();
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
            }
        }

        public void PostingInvoiceAccount(int p_VoucherType, long p_VoucherNo, long p_ACCOUNT_HEAD_ID, int p_Distributor_Id, decimal p_Debit, decimal p_Credit, DateTime p_Ledger_Date, string p_Remarks, DateTime p_TimeStamp, int p_PRINCIPAL_ID, int p_CUSTOMER_ID, long p_DOCUMENT_NO, int p_DOCUMENT_TYPE_ID, int p_UserId, IDbTransaction mTransaction, IDbConnection mConnection, int p_Paymode, string p_PayeesName)
        {
            try
            {
                new spInsertLEDGER { 
                    Connection = mConnection, Transaction = mTransaction, VOUCHER_TYPE_ID = p_VoucherType, VOUCHER_NO = p_VoucherNo, ACCOUNT_HEAD_ID = p_ACCOUNT_HEAD_ID, DISTRIBUTOR_ID = p_Distributor_Id, DEBIT = p_Debit, CREDIT = p_Credit, LEDGER_DATE = p_Ledger_Date, REMARKS = p_Remarks, TIME_STAMP = p_TimeStamp, PRINCIPAL_ID = p_PRINCIPAL_ID, CUSTOMER_ID = p_CUSTOMER_ID, DOCUMENT_TYPE_ID = p_DOCUMENT_TYPE_ID, DOCUMENT_NO = p_DOCUMENT_NO, USER_ID = p_UserId, 
                    PAYMENT_MODE = p_Paymode, PAYEE_NAME = p_PayeesName, IS_DELETED = 0
                 }.ExecuteQuery();
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
            }
        }

        public void PostingPurchasAccount(int p_VoucherType, long p_Voucher_no, long p_ACCOUNT_HEAD_ID, int p_Distributor_Id, decimal p_Debit, decimal p_Credit, DateTime p_Ledger_Date, string p_Remarks, DateTime p_TimeStamp, int p_PRINCIPAL_ID, long p_DOCUMENT_NO, int p_DOCUMENT_TYPE_ID, int p_UserId, IDbTransaction mTransaction, IDbConnection mConnection)
        {
            try
            {
                new spInsertLEDGER { 
                    Connection = mConnection, Transaction = mTransaction, VOUCHER_TYPE_ID = p_VoucherType, VOUCHER_NO = p_Voucher_no, ACCOUNT_HEAD_ID = p_ACCOUNT_HEAD_ID, DISTRIBUTOR_ID = p_Distributor_Id, DEBIT = p_Debit, CREDIT = p_Credit, LEDGER_DATE = p_Ledger_Date, REMARKS = p_Remarks, TIME_STAMP = p_TimeStamp, PRINCIPAL_ID = p_PRINCIPAL_ID, DOCUMENT_TYPE_ID = p_DOCUMENT_TYPE_ID, DOCUMENT_NO = p_DOCUMENT_NO, USER_ID = p_UserId, POSTING = 0, 
                    IS_DELETED = 0
                 }.ExecuteQuery();
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
            }
        }

        public void PostSelectVoucher(int p_DistributorId, string p_Voucher_no, int p_Voucher_type_Id, int p_TypeId, DateTime p_VoucherDate)
        {
            IDbConnection connection = null;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new UspPostSelectVoucher { Connection = connection, DISTRIBUTOR_ID = p_DistributorId, VOUCHER_NO = p_Voucher_no, VOUCHER_TYPE_ID = p_Voucher_type_Id, VOUCHER_DATE = p_VoucherDate, TYPE_ID = p_TypeId }.ExecuteQuery();
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
            }
        }

        public DataTable SelectBankCashTransction(int p_Distributor_Id, int p_Account_Head_Id, int p_DocumentType_id, DateTime FDate, DateTime TDate)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new UspSelectBankCashDetail { Connection = connection, Distributor_id = p_Distributor_Id, Account_Head_id = p_Account_Head_Id, Document_Type_Id = p_DocumentType_id, From_Date = DateTime.Parse(FDate.ToShortDateString() + " 00:00:00"), To_Date = DateTime.Parse(TDate.ToShortDateString() + " 23:59:59") }.ExecuteTable();
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

        public DataTable SelectClaimDetail(int p_Distributor_Id, int p_ClaimType_id, DateTime FDate, DateTime TDate)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new UspSelectClaimDetail { Connection = connection, Distributor_id = p_Distributor_Id, Claim_Type_Id = p_ClaimType_id, From_Date = DateTime.Parse(FDate.ToShortDateString() + " 00:00:00"), To_Date = DateTime.Parse(TDate.ToShortDateString() + " 23:59:59") }.ExecuteTable();
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

        public string SelectLedgerMaxDocumentId(int p_Document_id, int p_DistributorId)
        {
            IDbConnection connection = null;
            string str;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                UspSelectMaxDocumentNo no = new UspSelectMaxDocumentNo {
                    Connection = connection,
                    Document_TypeId = p_Document_id,
                    Distributor_id = p_DistributorId
                };
                str = no.ExecuteTable().Rows[0][0].ToString();
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

        public DataTable SelectLedgerView(DateTime p_Fromdate, DateTime p_ToDate, int p_Distributor_id, int p_Account_Type_id, long p_Account_Head_id, int p_Principal_Id, int p_Customer_id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new UspLedgerView { Connection = connection, fromdate = p_Fromdate, todate = p_ToDate, Distributor_id = p_Distributor_id, Account_type = p_Account_Type_id, Account_head_id = p_Account_Head_id, CustomerId = p_Customer_id, Principal = p_Principal_Id }.ExecuteTable();
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

        public string SelectMaxVoucherId(int p_Document_id, int p_DistributorId, DateTime mDate)
        {
            IDbConnection connection = null;
            string str2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                UspSelectMaxVoucherNo no = new UspSelectMaxVoucherNo {
                    Connection = connection,
                    Document_TypeId = p_Document_id,
                    Distributor_id = p_DistributorId,
                    Month = mDate
                };
                string str = no.ExecuteTable().Rows[0][0].ToString();
                if (str.Length == 1)
                {
                    if (mDate.Month.ToString().Length == 1)
                    {
                        str = "0" + mDate.Month.ToString() + mDate.Year.ToString().Substring(2, 2) + "-000" + str;
                    }
                    else
                    {
                        str = mDate.Month.ToString() + mDate.Year.ToString().Substring(2, 2) + "-000" + str;
                    }
                }
                else if (str.Length == 2)
                {
                    if (mDate.Month.ToString().Length == 1)
                    {
                        str = str = "0" + mDate.Month.ToString() + mDate.Year.ToString().Substring(2, 2) + "-00" + str;
                    }
                    else
                    {
                        str = mDate.Month.ToString() + mDate.Year.ToString().Substring(2, 2) + "-00" + str;
                    }
                }
                else if (str.Length == 3)
                {
                    if (mDate.Month.ToString().Length == 1)
                    {
                        str = "0" + mDate.Month.ToString() + mDate.Year.ToString().Substring(2, 2) + "-0" + str;
                    }
                    else
                    {
                        str = mDate.Month.ToString() + mDate.Year.ToString().Substring(2, 2) + "-0" + str;
                    }
                }
                else if (mDate.Month.ToString().Length == 1)
                {
                    str = "0" + mDate.Month.ToString() + mDate.Year.ToString().Substring(2, 2) + "-" + str;
                }
                else
                {
                    str = mDate.Month.ToString() + mDate.Year.ToString().Substring(2, 2) + "-" + str;
                }
                str2 = str;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                str2 = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return str2;
        }

        public DataTable SelectPendingInvoice(int p_DistributorId, int Principal_id, DateTime From_Date, DateTime To_date, long p_Account_Head_Id)
        {
            IDbConnection connection = null;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                UspSelectLedgerDetail detail = new UspSelectLedgerDetail {
                    Connection = connection,
                    DISTRIBUTOR_ID = p_DistributorId,
                    PRINCIPAL_ID = Principal_id,
                    FROM_DATE = From_Date,
                    TO_DATE = To_date,
                    ACCOUNT_HEAD_ID = p_Account_Head_Id
                };
                return detail.ExecuteTable();
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                return null;
            }
        }

        public DataTable SelectUnPostLedger(string p_Voucher_id, int p_DistributorId, int p_VoucherType)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectVoucher { Connection = connection, VOUCHER_NO = p_Voucher_id, DISTRIBUTOR_ID = p_DistributorId, VOUCHER_TYPE_ID = p_VoucherType }.ExecuteTable();
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

        public DataTable SelectUnPostVoucherNo(int p_VoucherType_id, int p_DistributorId, bool p_IS_POST, DateTime p_FROM_DATE, DateTime p_TO_DATE)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new UspSelectVoucherNo { Connection = connection, VOUCHER_TYPE_ID = p_VoucherType_id, DISTRIBUTOR_ID = p_DistributorId, IS_POST = p_IS_POST, FROM_DATE = p_FROM_DATE, TO_DATE = p_TO_DATE }.ExecuteTable();
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

        public DataTable SelectVoucherDetail(int p_Distributor_id, string p_VoucherNo, int p_VoucherTypeId)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectGL_DETAIL { Connection = connection, DISTRIBUTOR_ID = p_Distributor_id, VOUCHER_NO = p_VoucherNo, VOUCHER_TYPE_ID = p_VoucherTypeId, IS_DELETED = false }.ExecuteTable();
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

        public DataTable SelectVoucherNo(DateTime p_Voucherdate, int p_Distributor_id, int p_VoucherTypeId, int p_UserId, string p_VoucherNo)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectGL_MASTER { Connection = connection, VOUCHER_DATE = p_Voucherdate, DISTRIBUTOR_ID = p_Distributor_id, USER_ID = p_UserId, VOUCHER_TYPE_ID = p_VoucherTypeId, VOUCHER_NO = p_VoucherNo, IS_POSTED = true, IS_DELETED = false }.ExecuteTable();
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

        public void UpdateSaleInvoice(long p_SaleInvoice_ID, int p_Distributor_Id, decimal p_Current_Amount)
        {
            IDbConnection connection = null;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spUpdateSALE_INVOICE_MASTER { Connection = connection, DISTRIBUTOR_ID = p_Distributor_Id, SALE_INVOICE_ID = p_SaleInvoice_ID, CURRENT_CREDIT_AMOUNT = p_Current_Amount, IS_DELETED = false }.ExecuteQuery();
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
            }
        }
    }
}

