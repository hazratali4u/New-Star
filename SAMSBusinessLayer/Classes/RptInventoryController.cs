namespace SAMS.BusinessLayer.Classes
{
    using SAMS.BusinessLayer.Reports;
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class RptInventoryController
    {
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

        public DataSet SelectPrincipalStockReconcilation(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date, int p_USER_ID, int p_UOM_ID, int p_PRICE_TYPE)
        {
            IDbConnection connection = null;
            DataSet set;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                uspRptSelectStockRegister register = new uspRptSelectStockRegister();
                DsReport report = new DsReport();
                register.Connection = connection;
                register.distributor_id = p_Distributor_ID;
                register.Company_Id = p_Principal_Id;
                register.DateFrom = p_FromDate;
                register.dateto = p_To_Date;
                register.USER_ID = p_USER_ID;
                register.UOM_ID = p_UOM_ID;
                register.PRICE_TYPE = p_PRICE_TYPE;
                DataTable table = register.ExecuteTable();
                foreach (DataRow row in table.Rows)
                {
                    report.Tables["StockRegister"].ImportRow(row);
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

        public DataSet SelectPurchaseTransferStock(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date, int p_TypeId, int p_RATE_TYPE)
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
                if (p_ReportType == 0)
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
                        report.Tables["rptStockValuationSummary"].ImportRow(row);
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

