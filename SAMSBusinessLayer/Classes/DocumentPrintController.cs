namespace SAMS.BusinessLayer.Classes
{
    using SAMS.BusinessLayer.Reports;
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class DocumentPrintController
    {
        public DataSet BankDepositSlipDetail(int p_Principal_ID, int p_Distributor_ID, DateTime p_Fromdate, DateTime p_ToDate, int p_Account_Head_Id)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                DsReport report = new DsReport();
                DataTable table = new UspRptBankDepositSlip { Connection = connection, PRINCIPAL_ID = p_Principal_ID, DISTRIBUTOR_ID = p_Distributor_ID, FromDate = p_Fromdate, ToDate = p_ToDate, ACCOUNT_HEAD_ID = p_Account_Head_Id }.ExecuteTable();
                foreach (DataRow row in table.Rows)
                {
                    report.Tables["BankDepositSlipDetail"].ImportRow(row);
                }
                set = report;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataSet BookingSupplyMonitoring(int p_Principal_ID, int p_Distributor_ID, int p_OrderBookerID, DateTime p_Fromdate, DateTime p_ToDate)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                DsReport report = new DsReport();
                DataTable table = new RptBookingSupplyMonitoringOrder { Connection = connection, PRINCIPAL_ID = p_Principal_ID, DISTRIBUTOR_ID = p_Distributor_ID, ORDERBOOKER_ID = p_OrderBookerID, FROM_DATE = p_Fromdate, TO_DATE = p_ToDate }.ExecuteTable();
                DataTable table2 = new RptBookingSupplyMonitoringInvoice { Connection = connection, PRINCIPAL_ID = p_Principal_ID, DISTRIBUTOR_ID = p_Distributor_ID, ORDERBOOKER_ID = p_OrderBookerID, FROM_DATE = p_Fromdate, TO_DATE = p_ToDate }.ExecuteTable();
                foreach (DataRow row in table.Rows)
                {
                    report.Tables["BookingSupplyMonitoring"].ImportRow(row);
                }
                int num = 0;
                int count = table.Rows.Count;
                int num3 = table2.Rows.Count;
                if (count > num3)
                {
                    num = num3;
                }
                else
                {
                    num = count;
                }
                for (int i = 0; i < num; i++)
                {
                    report.Tables["BookingSupplyMonitoring"].Rows[i]["SupplyValue"] = Convert.ToDecimal(table2.Rows[i]["SupplyValue"].ToString());
                    report.Tables["BookingSupplyMonitoring"].Rows[i]["ExecutedOrders"] = Convert.ToInt32(table2.Rows[i]["ExecutedOrders"].ToString());
                }
                set = report;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataSet BookingVsExecution(int p_Principal_ID, int p_Distributor_ID, int p_OrderBookerID, int p_DELIVERYMAN_ID, DateTime p_Fromdate, DateTime p_ToDate)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                DsReport report = new DsReport();
                DataTable table = new RptOrderVsExecution { Connection = connection, PRINCIPAL_ID = p_Principal_ID, DISTRIBUTOR_ID = p_Distributor_ID, ORDERBOOKER_ID = p_OrderBookerID, DELIVERYMAN_ID = p_DELIVERYMAN_ID, FROM_DATE = p_Fromdate, TO_DATE = p_ToDate }.ExecuteTable();
                foreach (DataRow row in table.Rows)
                {
                    report.Tables["BookingSupplyMonitoring"].ImportRow(row);
                }
                set = report;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataSet CustomerClaim_Slip(int p_Principal_ID, int p_DistributorId, int p_CustomerId, DateTime p_From_Date, DateTime p_ToDate, int p_PaymentMode)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                DsReport report = new DsReport();
                DataTable table = new UspPrintClaimSlip { Connection = connection, principal_id = p_Principal_ID, Distributor_id = p_DistributorId, customer_id = p_CustomerId, From_Date = p_From_Date, To_Date = p_ToDate, Payment_Mode = p_PaymentMode }.ExecuteTable();
                foreach (DataRow row in table.Rows)
                {
                    report.Tables["RptClaimSlipDetail"].ImportRow(row);
                }
                set = report;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataSet CustomerLedger_View(int p_Principal_ID, int p_DistributorId, int p_CustomerId, DateTime p_From_Date, DateTime p_ToDate)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                DsReport report = new DsReport();
                DataTable table = new UspCustomerLedger { Connection = connection, principal_id = p_Principal_ID, Distributor_id = p_DistributorId, customer_id = p_CustomerId, From_Date = p_From_Date, To_Date = p_ToDate }.ExecuteTable();
                foreach (DataRow row in table.Rows)
                {
                    report.Tables["RptCustomerLedgerView"].ImportRow(row);
                }
                set = report;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataSet GeneralLedger_View(int p_Principal_ID, long p_Account_Head_ID, int p_DistributorId, DateTime p_From_Date, DateTime p_ToDate, int p_Posted)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                DsReport report = new DsReport();
                DataTable table = new UspLedgerReport { Connection = connection, PRINCIPAL_ID = p_Principal_ID, DISTRIBUTOR_ID = p_DistributorId, ACCOUNT_HEAD_ID = p_Account_Head_ID, FROM_DATE = p_From_Date, TO_DATE = p_ToDate, POSTED = p_Posted }.ExecuteTable();
                foreach (DataRow row in table.Rows)
                {
                    report.Tables["RptLedgerView"].ImportRow(row);
                }
                set = report;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataSet GetCreditAgingReport(int P_DistributorType, int P_PrincipalId, int P_DistributorId, int p_UserId, int p_Type, DateTime p_Document_Date)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                DsReport report = new DsReport();
                DataTable table = new UspCreditAgintReport { Connection = connection, DISTRIBUTOR_ID = P_DistributorId, DISTRIBUTOR_TYPE_ID = P_DistributorType, TYPE_ID = p_Type, PRINCIPAL_ID = P_PrincipalId, USER_ID = p_UserId, DOCUMENT_DATE = p_Document_Date }.ExecuteTable();
                foreach (DataRow row in table.Rows)
                {
                    report.Tables["RptCreditAgingReport"].ImportRow(row);
                }
                set = report;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataSet GetCustomerClassfication(int P_PrincipalId, int P_DistributorId, DateTime p_FromDate, DateTime p_ToDate, string p_QueryAnalysis, int p_ChannelType_id, int p_devision_id, int p_Category_id, int p_Brand_Id, int p_SKU_id)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                DsReport report = new DsReport();
                DataTable table = new UspShowCustomerClassificationReport { Connection = connection, DISTRIBUTOR_ID = P_DistributorId, PRINCIPAL_ID = P_PrincipalId, FROM_DATE = p_FromDate, TO_DATE = p_ToDate, String = p_QueryAnalysis, CHANNEL_TYPE_ID = p_ChannelType_id, Division = p_devision_id, Category = p_Category_id, Brand = p_Brand_Id, SKU_ID = p_SKU_id }.ExecuteTable();
                foreach (DataRow row in table.Rows)
                {
                    report.Tables["RptCustomerClassfication"].ImportRow(row);
                }
                set = report;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataSet GetCustomerClassficationDetail(int P_PrincipalId, int P_DistributorId, DateTime p_FromDate, DateTime p_ToDate, string p_QueryAnalysis, int p_ChannelType_id, int p_devision_id, int p_Category_id, int p_Brand_Id, int p_SKU_id)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                DsReport report = new DsReport();
                DataTable table = new UspShowCustomerClassificationReport { Connection = connection, DISTRIBUTOR_ID = P_DistributorId, PRINCIPAL_ID = P_PrincipalId, FROM_DATE = p_FromDate, TO_DATE = p_ToDate, String = p_QueryAnalysis, CHANNEL_TYPE_ID = p_ChannelType_id, Division = p_devision_id, Category = p_Category_id, Brand = p_Brand_Id, SKU_ID = p_SKU_id }.ExecuteTable();
                foreach (DataRow row in table.Rows)
                {
                    report.Tables["RptCustomerClassificationDetail"].ImportRow(row);
                }
                set = report;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataSet GetDistributorReconcilation(int P_DistributorType, int P_PrincipalId, int P_DistributorId, DateTime P_frmDate, DateTime P_toDate, int p_UserId)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                DsReport report = new DsReport();
                DataTable table = new UspSelectDistributorWiseSale { Connection = connection, LocationType = P_DistributorType, DistributorId = P_DistributorId, PrincipalId = P_PrincipalId, FROM_DATE = P_frmDate, TO_DATE = P_toDate, USER_ID = p_UserId }.ExecuteTable();
                foreach (DataRow row in table.Rows)
                {
                    report.Tables["DistributorReconcilation"].ImportRow(row);
                }
                set = report;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataSet GetRegionSaleDetail(int P_DistributorType, int P_PrincipalId, int P_ZoneId, int P_DistributorId, DateTime P_frmDate, DateTime P_toDate, int P_Category, int P_Type, int P_ReportType, int p_UserId)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                DsReport report = new DsReport();
                DataTable table = new uspRegionWiseSales { Connection = connection, CATEGORY_ID = P_Category, distributor_id = P_DistributorId, Distributor_type = P_DistributorType, Zone_id = P_ZoneId, FROM_DATE = P_frmDate, TO_DATE = P_toDate, Type = P_Type, ReportType = P_ReportType, PrincipalId = P_PrincipalId, user_id = p_UserId }.ExecuteTable();
                foreach (DataRow row in table.Rows)
                {
                    report.Tables["RegionWiseSales"].ImportRow(row);
                }
                set = report;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataSet LoadPass(int p_Principal_ID, DateTime p_Fromdate, int p_OrderBookerId)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                DsReport2 report = new DsReport2();
                DataTable table = new UspPrintDSR { Connection = connection, PRINCIPAL_ID = p_Principal_ID, DATE = p_Fromdate, SALEMAN_ID = p_OrderBookerId, DISTRIBUTOR_ID = 0 }.ExecuteTable();
                foreach (DataRow row in table.Rows)
                {
                    report.Tables["RptPrintDSR"].ImportRow(row);
                }
                set = report;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataSet LoadPassCredit(int p_Principal_ID, DateTime p_Fromdate, int p_OrderBookerId)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                DsReport2 report = new DsReport2();
                DataTable table = new RptLoadPassCredit { Connection = connection, PRINCIPAL_ID = p_Principal_ID, RECEIVED_DATE = p_Fromdate, SALEMAN_ID = p_OrderBookerId }.ExecuteTable();
                foreach (DataRow row in table.Rows)
                {
                    report.Tables["RptLoadCreditDetail"].ImportRow(row);
                }
                set = report;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataTable LoadPassSummary(int p_Principal_ID, DateTime p_Fromdate, int p_OrderBookerId)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                DsReport2 report = new DsReport2();
                table2 = new UspGetCurrentLoadSum { Connection = connection, PRINCIPAL_ID = p_Principal_ID, RECEIVED_DATE = p_Fromdate, SALEMAN_ID = p_OrderBookerId }.ExecuteTable();
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

        public DataSet OrderBookerSheet(int p_Principal_ID, int p_Distributor_ID, DateTime p_Fromdate, DateTime p_ToDate, int p_OrderBookerId, int p_User_Id)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                DsReport report = new DsReport();
                DataTable table = new UspOrderBookerSheet { Connection = connection, PRINCIPAL_ID = p_Principal_ID, DISTRIBUTOR_ID = p_Distributor_ID, FROM_DATE = p_Fromdate, TO_DATE = p_ToDate, ORDERBOOKER_ID = p_OrderBookerId, USER_ID = p_User_Id }.ExecuteTable();
                foreach (DataRow row in table.Rows)
                {
                    report.Tables["RptOrderBookerSheet"].ImportRow(row);
                }
                set = report;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataSet OutletWiseSale(int p_Principal_ID, int p_Distributor_ID, DateTime p_StartDate, DateTime p_EndDate, string p_CatagoryIDS)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                DsReport report = new DsReport();
                DataTable table = new RptOutletWiseSale { Connection = connection, Principal_ID = p_Principal_ID, Distributor_ID = p_Distributor_ID, FromDate = p_StartDate, ToDate = p_EndDate, Catagory_IDs = p_CatagoryIDS }.ExecuteTable();
                foreach (DataRow row in table.Rows)
                {
                    report.Tables["OutletWiseSale"].ImportRow(row);
                }
                set = report;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataSet PhysicalStockTaking(int p_Principal_ID, int p_Distributor_ID, DateTime p_Date)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                DsReport report = new DsReport();
                DataTable table = new RptPhysicalStockTaking { Connection = connection, PRINCIPAL_ID = p_Principal_ID, DISTRIBUTOR_ID = p_Distributor_ID, Date = p_Date }.ExecuteTable();
                foreach (DataRow row in table.Rows)
                {
                    report.Tables["PhysicalStockTaking"].ImportRow(row);
                }
                set = report;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataSet PhysicalStockTakingValueWise(int p_Principal_ID, int p_Distributor_ID, DateTime p_Date, int p_UserId)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                DsReport report = new DsReport();
                DataTable table = new RptPhysicalStockTakingSummary { Connection = connection, PRINCIPAL_ID = p_Principal_ID, DISTRIBUTOR_ID = p_Distributor_ID, Date = p_Date, USER_ID = p_UserId }.ExecuteTable();
                foreach (DataRow row in table.Rows)
                {
                    report.Tables["RptPhysicalStockValue"].ImportRow(row);
                }
                set = report;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataSet PriceList(int p_Principal_ID, int p_Catagory_ID, int p_DistributorId)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                DsReport report = new DsReport();
                DataTable table = new rptPriceList { Connection = connection, PRINCIPAL_ID = p_Principal_ID, CATEGORY_ID = p_Catagory_ID, DISTRIBUTOR_ID = p_DistributorId }.ExecuteTable();
                foreach (DataRow row in table.Rows)
                {
                    report.Tables["PriceList"].ImportRow(row);
                }
                set = report;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataSet PrincipalWiseSale(int p_Principal_ID, int p_Distributor_ID, DateTime p_StartDate, DateTime p_EndDate, string p_CatagoryIDS, int p_ReportType)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                DsReport report = new DsReport();
                DataTable table = new UspPrincipalWiseExp { Connection = connection, PRINCIPAL_ID = p_Principal_ID, DISTRIBUTOR_ID = p_Distributor_ID, FROM_DATE = p_StartDate, TO_DATE = p_EndDate, ACCOUNT_IDs = p_CatagoryIDS, TYPE_ID = p_ReportType }.ExecuteTable();
                foreach (DataRow row in table.Rows)
                {
                    report.Tables["RptPrincipalWiseExp"].ImportRow(row);
                }
                set = report;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataSet PromotionDetail(int p_Principal_ID, int p_Distributor_ID, DateTime p_StartDate, DateTime p_EndDate, int p_PromotionType)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                DsReport report = new DsReport();
                DataTable table = new RptPromotionReport { Connection = connection, Principal_ID = p_Principal_ID, Distributor_ID = p_Distributor_ID, START_DATE = p_StartDate, END_DATE = p_EndDate, ISACTIVE = Convert.ToBoolean(p_PromotionType) }.ExecuteTable();
                foreach (DataRow row in table.Rows)
                {
                    report.Tables["PromotionReport"].ImportRow(row);
                }
                set = report;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataSet SelectBillCustomerDetail(int p_Principal_ID, string p_Customer_Id, string p_DistributorId, DateTime p_From_Date, DateTime p_ToDate, byte p_showAll)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                DsReport report = new DsReport();
                DataTable table = new UspBillWiseCustomerReport { Connection = connection, PRINCIPAL_ID = p_Principal_ID, DISTRIBUTOR_ID = p_DistributorId, CUSTOMER_ID = p_Customer_Id, FROM_DATE = p_From_Date, TO_DATE = p_ToDate, ShowAll = p_showAll }.ExecuteTable();
                foreach (DataRow row in table.Rows)
                {
                    report.Tables["RptBillCustomerReport"].ImportRow(row);
                }
                set = report;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataSet SelectBusinessAnalysis(int p_Distributor_ID, DateTime p_FromDate, DateTime p_ToDate, int p_UserId)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                UspBusinessAnalysisReport report = new UspBusinessAnalysisReport();
                DsReport report2 = new DsReport();
                report.Connection = connection;
                report.DISTRIBUTOR_ID = p_Distributor_ID;
                report.FROM_DATE = p_FromDate;
                report.TO_DATE = p_ToDate;
                report.UserId = p_UserId;
                DataTable table = report.ExecuteTable();
                foreach (DataRow row in table.Rows)
                {
                    report2.Tables["RptBusiness_Anaysis Report"].ImportRow(row);
                }
                set = report2;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataSet SelectClaimReport(int p_Principal_ID, int p_DistributorId, DateTime p_From_Date, DateTime p_ToDate, int ClaimType)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                DsReport report = new DsReport();
                DataTable table = new UspClaimDetailReport { Connection = connection, PRINCIPAL_ID = p_Principal_ID, DISTRIBUTOR_ID = p_DistributorId, CLAIM_TYPE = ClaimType, FROM_DATE = p_From_Date, TO_DATE = p_ToDate }.ExecuteTable();
                foreach (DataRow row in table.Rows)
                {
                    report.Tables["RptClaimManagmentReport"].ImportRow(row);
                }
                set = report;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataSet SelectCustomerCreditCeiling(int p_Distributor_ID, int p_Principal_Id, int p_UserId)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                UspCreditLimitReport report = new UspCreditLimitReport();
                DsReport report2 = new DsReport();
                report.Connection = connection;
                report.DISTRIBUTOR_ID = p_Distributor_ID;
                report.PRINCIPAL_ID = p_Principal_Id;
                report.userid = p_UserId;
                DataTable table = report.ExecuteTable();
                foreach (DataRow row in table.Rows)
                {
                    report2.Tables["RptCustomerWiseCreditSelling"].ImportRow(row);
                }
                set = report2;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataSet SelectCustomerCreditReport(int p_Distributor_ID, int p_Principal_Id, int p_Area_id, int p_CustomerId, int p_ChannelType_Id, int p_Status_id, DateTime p_FromDate, DateTime p_To_Date, int p_UserId, int p_ReportFilter)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                UspChequeDetailReport report = new UspChequeDetailReport();
                DsReport report2 = new DsReport();
                report.Connection = connection;
                report.DISTRIBUTOR_ID = p_Distributor_ID;
                report.PRINCIPAL_ID = p_Principal_Id;
                report.FROM_DATE = p_FromDate;
                report.TO_DATE = p_To_Date;
                report.AREA_ID = p_Area_id;
                report.CHANNEL_TYPE_ID = p_ChannelType_Id;
                report.CUSTOMER_ID = p_CustomerId;
                report.STATUS_ID = p_Status_id;
                report.ReportType = p_ReportFilter;
                DataTable table = report.ExecuteTable();
                foreach (DataRow row in table.Rows)
                {
                    report2.Tables["RptChequeDetail"].ImportRow(row);
                }
                set = report2;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataSet SelectCustomerDSRProDuctWise(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date, int User_Id, int p_AreaId, int ChannelTypeId, int TypeId, int p_SalesForce_Id)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                RptCustomerDSRProductWise wise = new RptCustomerDSRProductWise();
                DsReport report = new DsReport();
                wise.Connection = connection;
                wise.DISTRIBUTOR_ID = p_Distributor_ID;
                wise.PRINCIPAL_ID = p_Principal_Id;
                wise.FROM_DATE = p_FromDate;
                wise.TO_DATE = p_To_Date;
                wise.USER_ID = User_Id;
                wise.AREA_ID = p_AreaId;
                wise.CHANNEL_TYPE_ID = ChannelTypeId;
                wise.TYPE_ID = TypeId;
                wise.DELIVERYMAN_ID = p_SalesForce_Id;
                DataTable table = wise.ExecuteTable();
                foreach (DataRow row in table.Rows)
                {
                    report.Tables["RptCustomerProductDSR"].ImportRow(row);
                }
                set = report;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataSet SelectCustomerDSRValueWise(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date, int User_Id, int p_AreaId, int ChannelTypeId, bool p_IS_REGISTERED, int p_SaleForceId)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                UspPrintCustomerDSR rdsr = new UspPrintCustomerDSR();
                DsReport report = new DsReport();
                rdsr.Connection = connection;
                rdsr.DISTRIBUTOR_ID = p_Distributor_ID;
                rdsr.PRINCIPAL_ID = p_Principal_Id;
                rdsr.FROM_DATE = p_FromDate;
                rdsr.TO_DATE = p_To_Date;
                rdsr.USER_ID = User_Id;
                rdsr.AREA_ID = p_AreaId;
                rdsr.DELIVERYMAN_ID = p_SaleForceId;
                if (p_IS_REGISTERED)
                {
                    rdsr.IS_REGISTERED = 1;
                }
                else
                {
                    rdsr.IS_REGISTERED = -2147483648;
                }
                rdsr.CHANNEL_TYPE_ID = ChannelTypeId;
                DataTable table = rdsr.ExecuteTable();
                foreach (DataRow row in table.Rows)
                {
                    report.Tables["CUSTOMER_TRANSCTIONDETAIL"].ImportRow(row);
                }
                set = report;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataSet SelectCustomerMonthlySales(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date, int Category_Id, int p_AreaId, int ChannelTypeId, int TypeId)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                UspCustomerMonthlySales sales = new UspCustomerMonthlySales();
                DsReport report = new DsReport();
                sales.Connection = connection;
                sales.Distributor_id = p_Distributor_ID;
                sales.Principal_id = p_Principal_Id;
                sales.From_date = p_FromDate;
                sales.To_Date = p_To_Date;
                sales.Area_id = p_AreaId;
                sales.ChanneltypeId = ChannelTypeId;
                sales.Type_Id = TypeId;
                sales.Category_id = Category_Id;
                DataTable table = sales.ExecuteTable();
                foreach (DataRow row in table.Rows)
                {
                    report.Tables["CustomerMonthlySales"].ImportRow(row);
                }
                set = report;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataSet SelectCustomerSaleReport(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date, int User_Id, int p_AreaId, int ChannelTypeId, bool p_IS_REGISTERED, int p_SaleForceId)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                UspCustomerSaleReport report = new UspCustomerSaleReport();
                DsReport2 report2 = new DsReport2();
                report.Connection = connection;
                report.DISTRIBUTOR_ID = p_Distributor_ID;
                report.PRINCIPAL_ID = p_Principal_Id;
                report.FROM_DATE = p_FromDate;
                report.TO_DATE = p_To_Date;
                report.AREA_ID = p_AreaId;
                report.CHANNEL_TYPE_ID = ChannelTypeId;
                report.SALEFORCE_ID = p_SaleForceId;
                DataTable table = report.ExecuteTable();
                foreach (DataRow row in table.Rows)
                {
                    report2.Tables["RptCustomerSaleReport"].ImportRow(row);
                }
                set = report2;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataSet SelectDailyBankDeposit(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date, int p_UserId)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                UspDailyBankDeposit deposit = new UspDailyBankDeposit();
                DsReport report = new DsReport();
                deposit.Connection = connection;
                deposit.DISTRIBUTOR_ID = p_Distributor_ID;
                deposit.PRINCIPAL_ID = p_Principal_Id;
                deposit.FROM_DATE = p_FromDate;
                deposit.TO_DATE = p_To_Date;
                deposit.USER_ID = p_UserId;
                DataTable table = deposit.ExecuteTable();
                foreach (DataRow row in table.Rows)
                {
                    report.Tables["RptDailyBankDeposit"].ImportRow(row);
                }
                set = report;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataSet SelectDailyUpdateSales(int p_Principal_ID, int p_Distributor_ID, DateTime p_dateTime, int p_Region, int p_Zone, int p_Territory_Id, int p_Type)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                DsReport report = new DsReport();
                DataTable table = new UspDailySaleUpdate { Connection = connection, PRINCIPAL_ID = p_Principal_ID, DISTRIBUTOR_ID = p_Distributor_ID, TARGET_DATE = p_dateTime, Region_Id = p_Region, Zone_Id = p_Zone, Territory_Id = p_Territory_Id, TYPE_ID = p_Type }.ExecuteTable();
                foreach (DataRow row in table.Rows)
                {
                    report.Tables["RptDailySalesUpdated"].ImportRow(row);
                }
                set = report;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataSet SelectDocumentforPrint(int p_Distributor_ID, int p_Areaid, int p_Principal_Id, DateTime FromDocNo, DateTime ToDocNo, int DocumentTypeId, long p_DOCUMENT_ID, int p_PRINTTYPE)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                UspDocumentPrinting printing = new UspDocumentPrinting();
                DsReport report = new DsReport();
                printing.Connection = connection;
                printing.DISTRIBTOR_ID = p_Distributor_ID;
                printing.AREA_ID = p_Areaid;
                printing.PRINCIPAL_ID = p_Principal_Id;
                printing.FROM_DATE = FromDocNo;
                printing.TO_DATE = ToDocNo;
                printing.TYPE_ID = DocumentTypeId;
                printing.DOCUMENT_ID = p_DOCUMENT_ID;
                printing.PRINTTYPE = p_PRINTTYPE;
                DataTable table = printing.ExecuteTable();
                foreach (DataRow row in table.Rows)
                {
                    report.Tables["SALE_DOCUMENTPRINT"].ImportRow(row);
                }
                DataTable table2 = new uspPrintSALE_ORDER_PROMOTION { Connection = connection, DISTRIBTOR_ID = p_Distributor_ID, AREA_ID = p_Areaid, PRINCIPAL_ID = p_Principal_Id, FROM_DATE = FromDocNo, TO_DATE = ToDocNo, TYPE_ID = DocumentTypeId }.ExecuteTable();
                foreach (DataRow row in table2.Rows)
                {
                    report.Tables["SALE_PROMOTIONPRINT"].ImportRow(row);
                }
                set = report;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataTable SelectDocumentforView(int p_Distributor_ID, int p_Areaid, int p_Principal_Id, DateTime FromDocNo, DateTime ToDocNo, int DocumentTypeId)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                UspDocumentView view = new UspDocumentView();
                DsReport report = new DsReport();
                view.Connection = connection;
                view.DISTRIBTOR_ID = p_Distributor_ID;
                view.AREA_ID = p_Areaid;
                view.PRINCIPAL_ID = p_Principal_Id;
                view.FROM_DATE = FromDocNo;
                view.TO_DATE = ToDocNo;
                view.TYPE_ID = DocumentTypeId;
                table2 = view.ExecuteTable();
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

        public DataSet SelectOrderBookerCreditAging(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, int p_USER_ID, int p_OrderBookerId, int p_Days, int p_Option)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                UspOrderBookerCreditAging aging = new UspOrderBookerCreditAging();
                DsReport report = new DsReport();
                aging.Connection = connection;
                aging.DISTRIBUTOR_ID = p_Distributor_ID;
                aging.PRINCIPAL_ID = p_Principal_Id;
                aging.Credit_date = p_FromDate;
                aging.USER_ID = p_USER_ID;
                aging.ORDERBOOKER_ID = p_OrderBookerId;
                aging.DAYS = p_Days;
                aging.TYPE_ID = p_Option;
                DataTable table = aging.ExecuteTable();
                foreach (DataRow row in table.Rows)
                {
                    report.Tables["RptCreditAgingOrderbooker"].ImportRow(row);
                }
                set = report;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataSet SelectOrderBookerDSR(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date, int p_UserId)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                UspPrintOrderBookerDSR rdsr = new UspPrintOrderBookerDSR();
                DsReport report = new DsReport();
                rdsr.Connection = connection;
                rdsr.DISTRIBUTOR_ID = p_Distributor_ID;
                rdsr.PRINCIPAL_ID = p_Principal_Id;
                rdsr.FROM_DATE = p_FromDate;
                rdsr.TO_DATE = p_To_Date;
                rdsr.USER_ID = p_UserId;
                DataTable table = rdsr.ExecuteTable();
                foreach (DataRow row in table.Rows)
                {
                    report.Tables["SALEPERSON_TRANSCTIONDETAIL"].ImportRow(row);
                }
                set = report;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataSet SelectOrderBookerDSRProDuctWise(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date, int User_Id)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                RptOrderBookerDSRProductWise wise = new RptOrderBookerDSRProductWise();
                DsReport report = new DsReport();
                wise.Connection = connection;
                wise.DISTRIBUTOR_ID = p_Distributor_ID;
                wise.PRINCIPAL_ID = p_Principal_Id;
                wise.FROM_DATE = p_FromDate;
                wise.TO_DATE = p_To_Date;
                wise.USER_ID = User_Id;
                DataTable table = wise.ExecuteTable();
                foreach (DataRow row in table.Rows)
                {
                    report.Tables["RptSaleReportProductWise"].ImportRow(row);
                }
                set = report;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataSet SelectOrderVSExcusion(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date, int p_Type)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                UspSelectOrderVSExceusion exceusion = new UspSelectOrderVSExceusion();
                DsReport report = new DsReport();
                exceusion.Connection = connection;
                exceusion.DISTRIBUTOR_ID = p_Distributor_ID;
                exceusion.PRINCIPAL_ID = p_Principal_Id;
                exceusion.FROM_DATE = p_FromDate;
                exceusion.TO_DATE = p_To_Date;
                exceusion.REPORTTYPE = p_Type;
                DataTable table = exceusion.ExecuteTable();
                foreach (DataRow row in table.Rows)
                {
                    report.Tables["RptOrderExcustionSummary"].ImportRow(row);
                }
                set = report;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataSet SelectPartystatment(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                UspPartyStatement statement = new UspPartyStatement();
                DsReport report = new DsReport();
                statement.Connection = connection;
                statement.DISTRIBUTOR_ID = p_Distributor_ID;
                statement.PRINCIPAL_ID = p_Principal_Id;
                statement.FROM_DATE = p_FromDate;
                statement.TO_DATE = p_To_Date;
                DataTable table = statement.ExecuteTable();
                foreach (DataRow row in table.Rows)
                {
                    report.Tables["RptCustomerStatment"].ImportRow(row);
                }
                set = report;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataSet SelectPaymentReceived(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                UspSelectPartyStatment statment = new UspSelectPartyStatment();
                DsReport report = new DsReport();
                statment.Connection = connection;
                statment.DISTRIBUTOR_ID = p_Distributor_ID;
                statment.PRINCIPAL_ID = p_Principal_Id;
                statment.FROM_DATE = p_FromDate;
                statment.TO_DATE = p_To_Date;
                DataTable table = statment.ExecuteTable();
                foreach (DataRow row in table.Rows)
                {
                    report.Tables["RptPaymentReceied"].ImportRow(row);
                }
                set = report;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataSet SelectPetyCashStatment(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date, int p_USER_ID)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                RptPetyCashStatment statment = new RptPetyCashStatment();
                DsReport report = new DsReport();
                statment.Connection = connection;
                statment.DISTRIBUTOR_ID = p_Distributor_ID;
                statment.PRINCIPAL_ID = p_Principal_Id;
                statment.FROM_DATE = p_FromDate;
                statment.TO_DATE = p_To_Date;
                statment.USER_ID = p_USER_ID;
                DataTable table = statment.ExecuteTable();
                foreach (DataRow row in table.Rows)
                {
                    report.Tables["dbo_PetyCashSummary"].ImportRow(row);
                }
                set = report;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataSet SelectPetyCashSummary(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date, int p_USER_ID)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                UspRptPettyCashSummery summery = new UspRptPettyCashSummery();
                DsReport report = new DsReport();
                summery.Connection = connection;
                summery.DistributorId = p_Distributor_ID;
                summery.FromDate = p_FromDate;
                summery.ToDate = p_To_Date;
                summery.USER_ID = p_USER_ID;
                DataTable table = summery.ExecuteTable();
                foreach (DataRow row in table.Rows)
                {
                    report.Tables["PettyCashSummery"].ImportRow(row);
                }
                set = report;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataSet SelectPrincipalCreditDetail(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date, int p_USER_ID, int p_SortType, int p_OrderBookerId, int p_SalePersonId)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                UspRptCreditSummary summary = new UspRptCreditSummary();
                DsReport report = new DsReport();
                summary.Connection = connection;
                summary.DISTRIBUTOR_ID = p_Distributor_ID;
                summary.PRINCIPAL_ID = p_Principal_Id;
                summary.FROM_DATE = p_FromDate;
                summary.TO_DATE = p_To_Date;
                summary.USER_ID = p_USER_ID;
                summary.ORDERBOOKER_ID = p_OrderBookerId;
                summary.SALE_PERSON = p_SalePersonId;
                DataView view = new DataView(summary.ExecuteTable());
                if (p_SortType == 0)
                {
                    view.Sort = "CUSTOMER_NAME";
                }
                else
                {
                    view.Sort = "LEDGER_DATE";
                }
                DataTable table = view.ToTable();
                foreach (DataRow row in table.Rows)
                {
                    report.Tables["RptCreditSummary"].ImportRow(row);
                }
                set = report;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataSet SelectPrincipalWiseCustomer(int p_Distributor_ID, int p_Areaid, int p_ChannelType_Id, int p_TownId, bool IsRegister)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                UspSelectPrincipalWiseCustomer customer = new UspSelectPrincipalWiseCustomer();
                DsReport report = new DsReport();
                customer.Connection = connection;
                customer.DISTRIBUTOR_ID = p_Distributor_ID;
                customer.AREA_ID = p_Areaid;
                customer.TOWN_ID = p_TownId;
                customer.CHANNEL_TYPE_ID = p_ChannelType_Id;
                if (IsRegister)
                {
                    customer.ROUTE_ID = 1;
                }
                else
                {
                    customer.ROUTE_ID = 0;
                }
                DataTable table = customer.ExecuteTable();
                foreach (DataRow row in table.Rows)
                {
                    report.Tables["ViewPrincipalWise_Customer"].ImportRow(row);
                }
                set = report;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataSet SelectPurchaseDocument(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date, int p_TypeId)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                GetPurchasedocument purchasedocument = new GetPurchasedocument();
                DsReport report = new DsReport();
                purchasedocument.Connection = connection;
                purchasedocument.DISTRIBUTOR_ID = p_Distributor_ID;
                purchasedocument.PRINCIPAL_ID = p_Principal_Id;
                purchasedocument.FROM_DATE = p_FromDate;
                purchasedocument.TO_DATE = p_To_Date;
                purchasedocument.TYPE_ID = p_TypeId;
                DataTable table = purchasedocument.ExecuteTable();
                foreach (DataRow row in table.Rows)
                {
                    report.Tables["RptPurchaseDocument"].ImportRow(row);
                }
                set = report;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataSet SelectPurchaseTransferStock(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date, int p_TypeId)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                UspDailyPurchaseTransfer transfer = new UspDailyPurchaseTransfer();
                DsReport report = new DsReport();
                transfer.Connection = connection;
                transfer.DISTRIBUTOR_ID = p_Distributor_ID;
                transfer.TYPEID = p_TypeId;
                transfer.PRINCIPAL_ID = p_Principal_Id;
                transfer.FROM_DATE = p_FromDate;
                transfer.TO_DATE = p_To_Date;
                DataTable table = transfer.ExecuteTable();
                foreach (DataRow row in table.Rows)
                {
                    report.Tables["DailyPurchaseTransferReport"].ImportRow(row);
                }
                set = report;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataTable SelectReportTitle(int p_Distributor_ID)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new UspSelectReportTitile { Connection = connection, DISTRIBUTOR_ID = p_Distributor_ID }.ExecuteTable();
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

        public DataSet SelectRptGrossProfit(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                UspGrossProfitReport report = new UspGrossProfitReport();
                DsReport2 report2 = new DsReport2();
                report.Connection = connection;
                report.DISTRIBUTOR_ID = p_Distributor_ID;
                report.PRINCIPAL_ID = p_Principal_Id;
                report.FROM_DATE = p_FromDate;
                report.TO_DATE = p_To_Date;
                DataTable table = report.ExecuteTable();
                foreach (DataRow row in table.Rows)
                {
                    report2.Tables["GrossPrifitReport"].ImportRow(row);
                }
                set = report2;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataSet SelectSalePersonDSR(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date, int p_UserId)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                UspPrintSaleForceDSR edsr = new UspPrintSaleForceDSR();
                DsReport report = new DsReport();
                edsr.Connection = connection;
                edsr.DISTRIBUTOR_ID = p_Distributor_ID;
                edsr.PRINCIPAL_ID = p_Principal_Id;
                edsr.FROM_DATE = p_FromDate;
                edsr.TO_DATE = p_To_Date;
                edsr.USER_ID = p_UserId;
                DataTable table = edsr.ExecuteTable();
                foreach (DataRow row in table.Rows)
                {
                    report.Tables["SALEPERSON_TRANSCTIONDETAIL"].ImportRow(row);
                }
                set = report;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataSet SelectSalePersonDSRProDuctWise(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date, int User_Id)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                RptSalePersonDSRProductWise wise = new RptSalePersonDSRProductWise();
                DsReport report = new DsReport();
                wise.Connection = connection;
                wise.DISTRIBUTOR_ID = p_Distributor_ID;
                wise.PRINCIPAL_ID = p_Principal_Id;
                wise.FROM_DATE = p_FromDate;
                wise.TO_DATE = p_To_Date;
                wise.USER_ID = User_Id;
                DataTable table = wise.ExecuteTable();
                foreach (DataRow row in table.Rows)
                {
                    report.Tables["RptSaleReportProductWise"].ImportRow(row);
                }
                set = report;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataSet SelectStockValuation(DateTime p_StockDate, int p_Distributor_ID, int p_Principal_ID, int p_USER_ID, int p_ReportType)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                uspGetStockValuation valuation = new uspGetStockValuation();
                DsReport2 report = new DsReport2();
                valuation.Connection = connection;
                valuation.STOCK_DATE = p_StockDate;
                valuation.DISTRIBUTOR_ID = p_Distributor_ID;
                valuation.PRINCIPAL_ID = p_Principal_ID;
                valuation.USER_ID = p_USER_ID;
                valuation.TYPE = p_ReportType;
                DataTable table = valuation.ExecuteTable();
                if ((p_ReportType == 0) && (p_Distributor_ID == -2147483648))
                {
                    foreach (DataRow row in table.Rows)
                    {
                        report.Tables["uspGetStockValuation"].ImportRow(row);
                    }
                }
                else if ((p_ReportType == 0) && (p_Distributor_ID != -2147483648))
                {
                    foreach (DataRow row in table.Rows)
                    {
                        report.Tables["rptStockValuationDetail"].ImportRow(row);
                    }
                }
                else
                {
                    foreach (DataRow row in table.Rows)
                    {
                        report.Tables["uspGetStockValuation"].ImportRow(row);
                    }
                }
                set = report;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataSet SelectTownWiseSales(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date, int p_Type)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                UspTownWiseSaleReport report = new UspTownWiseSaleReport();
                DsReport report2 = new DsReport();
                report.Connection = connection;
                report.DISTRIBUTOR_ID = p_Distributor_ID;
                report.PRINCIPAL_ID = p_Principal_Id;
                report.FROM_DATE = p_FromDate;
                report.TO_DATE = p_To_Date;
                report.TYPE_ID = p_Type;
                DataTable table = report.ExecuteTable();
                foreach (DataRow row in table.Rows)
                {
                    report2.Tables["RptTownSalesReport"].ImportRow(row);
                }
                set = report2;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataSet SelectTradeChannelSale(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date, int User_Id, int p_AreaId, int p_SalesForce_Id)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                UspTradeChannelSale sale = new UspTradeChannelSale();
                DsReport report = new DsReport();
                sale.Connection = connection;
                sale.DISTRIBUTOR_ID = p_Distributor_ID;
                sale.PRINCIPAL_ID = p_Principal_Id;
                sale.FROM_DATE = p_FromDate;
                sale.TO_DATE = p_To_Date;
                sale.UserId = User_Id;
                sale.AreaId = p_AreaId;
                sale.DeliveryManId = p_SalesForce_Id;
                sale.OrderBookerId = -2147483648;
                DataTable table = sale.ExecuteTable();
                foreach (DataRow row in table.Rows)
                {
                    report.Tables["RptTradeChannelSaleDetail"].ImportRow(row);
                }
                set = report;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataSet SelectUnpostVoucherForPrint(int p_Distributor_ID, string p_VoucherNo, int p_Voucher_Type)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                LedgerController controller = new LedgerController();
                DsReport report = new DsReport();
                DataTable table = controller.SelectUnPostLedger(p_VoucherNo, p_Distributor_ID, p_Voucher_Type);
                foreach (DataRow row in table.Rows)
                {
                    report.Tables["RptVoucherView"].ImportRow(row);
                }
                set = report;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataSet SelectValueReconcilation(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date, int p_UserId)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                UspRptValueReconcilation reconcilation = new UspRptValueReconcilation();
                DsReport report = new DsReport();
                reconcilation.Connection = connection;
                reconcilation.DISTRIBUTOR_ID = p_Distributor_ID;
                reconcilation.PRINCIPAL_ID = p_Principal_Id;
                reconcilation.FROM_DATE = p_FromDate;
                reconcilation.TO_DATE = p_To_Date;
                reconcilation.USER_ID = p_UserId;
                DataTable table = reconcilation.ExecuteTable();
                foreach (DataRow row in table.Rows)
                {
                    report.Tables["RptRegionWise_Reconciliation"].ImportRow(row);
                }
                set = report;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataSet SelectVolumeSale(int p_Principal_ID, int p_Distributor_ID, DateTime p_dateTime, int p_OrderBooker_ID)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                DsReport report = new DsReport();
                DataTable table = new uspSaleVolmeRpt { Connection = connection, PRINCIPAL_ID = p_Principal_ID, DISTRIBUTOR_ID = p_Distributor_ID, TODAY_DATE = p_dateTime, ORDERBOOKER_ID = p_OrderBooker_ID }.ExecuteTable();
                table.Columns.Add("Avg%");
                table.Columns.Add("Balance Target");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    decimal num2 = 0M;
                    int num3 = 0;
                    if (Convert.ToInt32(table.Rows[i]["Monthly Target"]) == 0)
                    {
                        num2 = 0M;
                    }
                    else
                    {
                        num2 = (Convert.ToDecimal(table.Rows[i]["Cumm Sales"]) / Convert.ToDecimal(table.Rows[i]["Monthly Target"])) * 100M;
                    }
                    table.Rows[i]["Avg%"] = Convert.ToString(num2);
                    num3 = Convert.ToInt32(table.Rows[i]["Monthly Target"]) - Convert.ToInt32(table.Rows[i]["Cumm Sales"]);
                    table.Rows[i]["Balance Target"] = Convert.ToString(num3);
                }
                foreach (DataRow row in table.Rows)
                {
                    report.Tables["VolumeSale"].ImportRow(row);
                }
                set = report;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataSet SKUWiseBookingVsExecution(int p_Principal_ID, int p_Distributor_ID, int p_OrderBookerID, int p_DELIVERYMAN_ID, DateTime p_Fromdate, DateTime p_ToDate, int p_REPORT_TYPE)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                DsReport2 report = new DsReport2();
                DataTable table = new RptSKUWiseBookingVsExecution { Connection = connection, PRINCIPAL_ID = p_Principal_ID, DISTRIBUTOR_ID = p_Distributor_ID, ORDERBOOKER_ID = p_OrderBookerID, DELIVERYMAN_ID = p_DELIVERYMAN_ID, FROM_DATE = p_Fromdate, TO_DATE = p_ToDate, REPORT_TYPE = p_REPORT_TYPE }.ExecuteTable();
                foreach (DataRow row in table.Rows)
                {
                    report.Tables["RptSKUWiseBookingVsExecution"].ImportRow(row);
                }
                set = report;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataSet TransferIn(int p_Principal_ID, int p_Distributor_ID, DateTime p_FromTime, DateTime p_ToDate, string p_TransferType, int p_type)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                DsReport report = new DsReport();
                DataTable table = new UspTransferInrpt { Connection = connection, PRINCIPAL_ID = p_Principal_ID, DISTRIBUTOR_ID = p_Distributor_ID, FromDate = p_FromTime, ToDate = p_ToDate, TransferType = p_TransferType, ReportType = p_type }.ExecuteTable();
                foreach (DataRow row in table.Rows)
                {
                    report.Tables["TransferIn"].ImportRow(row);
                }
                set = report;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }

        public DataSet TransferInOutValue(int p_Principal_ID, int p_Distributor_ID, DateTime p_FromTime, DateTime p_ToDate, string p_TransferType, int p_type)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                DsReport report = new DsReport();
                DataTable table = new UspTransferInOutValue { Connection = connection, PRINCIPAL_ID = p_Principal_ID, DISTRIBUTOR_ID = p_Distributor_ID, FromDate = p_FromTime, ToDate = p_ToDate, TransferType = p_TransferType, ReportType = p_type }.ExecuteTable();
                foreach (DataRow row in table.Rows)
                {
                    report.Tables["RptTransferInOutValueWise"].ImportRow(row);
                }
                set = report;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set;
        }
    }
}

