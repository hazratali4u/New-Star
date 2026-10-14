namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class ChequeEntryController
    {
        public void DeleteChequeEntry(long p_ChequeProcessId)
        {
            IDbConnection connection = null;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new UspDeleteCheque_Process { Connection = connection, CHEQUE_PROCESS_ID = p_ChequeProcessId }.ExecuteQuery();
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

        public string InsertChequeEntry(int p_distributorId, int p_Principal_id, long p_Customer_Id, string p_Cheque_No, string p_Bank_Name, DateTime p_Cheque_Date, DateTime p_Received_Date, DateTime p_Deposit_Date, DateTime p_Realization_Date, decimal p_Cheque_Amount, int p_Status_Id, DateTime p_Time_Stamp, int p_User_Id, string p_SlipNo, string p_Remarks, long p_AccountHead, int p_SaleManId)
        {
            IDbConnection connection = null;
            string str2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                str2 = new spInsertCHEQUE_PROCESS { 
                    Connection = connection, DISTRIBUTOR_ID = p_distributorId, PRINCIPAL_ID = p_Principal_id, CUSTOMER_ID = p_Customer_Id, CHEQUE_NO = p_Cheque_No, BANK_NAME = p_Bank_Name, CHEQUE_DATE = p_Cheque_Date, RECEIVED_DATE = p_Received_Date, DEPOSIT_DATE = p_Deposit_Date, PROCESS_DATE = p_Realization_Date, CHEQUE_AMOUNT = p_Cheque_Amount, STATUS_ID = p_Status_Id, TIME_STAMP = p_Time_Stamp, USER_ID = p_User_Id, LAST_UPDATED = DateTime.Now, SlipNo = p_SlipNo, 
                    Remarks = p_Remarks, ACCOUNT_HEAD_ID = p_AccountHead, SALEMAN_ID = p_SaleManId
                 }.ExecuteQuery();
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                str2 = "0";
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

        public DataTable InsertChequeEntryInvoice(long p_CHEQUE_PROCESS_ID, long p_Sale_Invoice_id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spInsertCHEQUE_PROCESS_DETAIL { Connection = connection, CHEQUE_PROCESS_ID = p_CHEQUE_PROCESS_ID, SALE_INVOICE_ID = p_Sale_Invoice_id }.ExecuteTable();
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

        public void ProcessCustmerCreditLevel(long p_Customerid, int p_invoiceNo, decimal p_Amount)
        {
            IDbConnection connection = null;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new UspProcessUsedCreditLimit { Connection = connection, typeId = Configuration.DistributorCreditLevel, CustomerId = p_Customerid, InvoiceNo = p_invoiceNo, amount = p_Amount }.ExecuteQuery();
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

        public void RollbackChequeEntry(int p_PRINCIPAL_ID, int p_DISTRIBUTOR_ID, string p_CHEQUE_NO, long p_CHEQUE_PROCESS_ID, long p_VoucherNo)
        {
            IDbConnection connection = null;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new UspRollbackChequeTran { Connection = connection, DISTRIBUTOR_ID = p_DISTRIBUTOR_ID, CHEQUE_PROCESS_ID = p_CHEQUE_PROCESS_ID, CHEQUE_NO = p_CHEQUE_NO, VOUCHER_NO = p_VoucherNo, PRINCIPAL_ID = p_PRINCIPAL_ID }.ExecuteQuery();
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

        public DataTable SelectChequeEntry(string p_FromDate, string p_ToDate, int p_Status_Id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectCHEQUE_ENTRY { Connection = connection, FROMDATE = Convert.ToDateTime(p_FromDate), TODATE = Convert.ToDateTime(p_ToDate), STATUS_ID = p_Status_Id }.ExecuteTable();
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

        public DataTable SelectChequeEntry(int p_Status_Id, DateTime p_ReceivedDate, int p_DISTRIBUTOR_ID, int p_PRINCIPAL_ID, int p_USER_ID)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectCHEQUE_PROCESS { Connection = connection, STATUS_ID = p_Status_Id, RECEIVED_DATE = p_ReceivedDate, USER_ID = p_USER_ID, PRINCIPAL_ID = p_PRINCIPAL_ID, DISTRIBUTOR_ID = p_DISTRIBUTOR_ID }.ExecuteTable();
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

        public DataTable SelectChequeEntryInvoice(long p_CHEQUE_PROCESS_ID, int p_Type_id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new UspChequeInvoice { Connection = connection, CHEQUE_PROCESS_ID = p_CHEQUE_PROCESS_ID, TYEP_ID = p_Type_id }.ExecuteTable();
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

        public void UpdateChequeEntry(long p_CHEQUE_PROCESS_ID, int p_distributorId, int p_PrincipalId, long p_Customer_Id, string p_Cheque_No, string p_Bank_Name, DateTime p_Cheque_Date, DateTime p_Received_Date, DateTime p_Deposit_Date, DateTime p_Realization_Date, decimal p_Cheque_Amount, int p_Status_Id, DateTime p_Time_Stamp, string p_SlipNo, int p_UserId, string p_Remarks, long p_AccountHead, int p_SalemanId)
        {
            IDbConnection connection = null;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spUpdateCHEQUE_PROCESS { 
                    Connection = connection, CHEQUE_PROCESS_ID = p_CHEQUE_PROCESS_ID, DISTRIBUTOR_ID = p_distributorId, CUSTOMER_ID = p_Customer_Id, PRINCIPAL_ID = p_PrincipalId, CHEQUE_NO = p_Cheque_No, BANK_NAME = p_Bank_Name, CHEQUE_DATE = p_Cheque_Date, RECEIVED_DATE = p_Received_Date, DEPOSIT_DATE = p_Deposit_Date, PROCESS_DATE = p_Realization_Date, CHEQUE_AMOUNT = p_Cheque_Amount, STATUS_ID = p_Status_Id, TIME_STAMP = p_Time_Stamp, LAST_UPDATED = DateTime.Now, SlipNo = p_SlipNo, 
                    USER_ID = p_UserId, Remarks = p_Remarks, ACCOUNT_HEAD_ID = p_AccountHead, SALEMAN_ID = p_SalemanId
                 }.ExecuteQuery();
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
    }
}

