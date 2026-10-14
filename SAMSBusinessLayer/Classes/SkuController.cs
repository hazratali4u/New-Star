namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class SkuController
    {
        public string InsertSKU_PRICES(int p_Distributor_Id, int p_Sku_Id, int p_Uom_Id, decimal p_Distributor_Discount, decimal p_Tax_Price, decimal p_Distributor_Price, decimal p_Trade_Price, decimal p_Retail_Price, DateTime p_date_effected, decimal p_SED_Tax)
        {
            IDbConnection connection = null;
            string str;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new UspProcessSKU_Prices { Connection = connection, DISTRIBUTOR_ID = p_Distributor_Id, DISTRIBUTOR_PRICE = p_Distributor_Price, SKU_ID = p_Sku_Id, RETAIL_PRICE = p_Retail_Price, TAX_PRICE = p_Tax_Price, TRADE_PRICE = p_Trade_Price, DISTRIBUTOR_DISCOUNT = p_Distributor_Discount, TIME_STAMP = DateTime.Now, LASTUPDATE_DATE = DateTime.Now, DATE_EFFECTED = p_date_effected, SED_TAX = p_SED_Tax }.ExecuteQuery();
                str = "Record Inserted";
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

        public DataTable SelectSKU_Prices(int p_Sku_Price_Id, int p_Uom_Id, decimal p_Tax_Price, decimal p_Distributor_Price, decimal p_Trade_Price, decimal p_Retail_Price, int p_Sku_Id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectSKU_PRICES { Connection = connection, SKU_PRICE_ID = p_Sku_Price_Id, UOM_ID = p_Uom_Id, TAX_PRICE = p_Tax_Price, DISTRIBUTOR_PRICE = p_Distributor_Price, TRADE_PRICE = p_Trade_Price, RETAIL_PRICE = p_Retail_Price, SKU_ID = p_Sku_Id, LASTUPDATE_DATE = Constants.DateNullValue, TIME_STAMP = Constants.DateNullValue, IP_ADDRESS = null }.ExecuteTable();
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

        public static DataTable SelectSKU_Prices(int p_Sku_Price_Id, int p_Sku_Id, decimal p_Distributor_Price, decimal p_Trade_Price, decimal p_Retail_Price, decimal p_Tax_Price, int p_UomId, DateTime p_Time_Stamp, DateTime p_LastUpdateDate, string p_Ip_Address, int p_IsCurrent, DateTime p_Date_Effected, DateTime p_Date_Expire)
        {
            IDbConnection connection = null;
            DataTable table;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table = new spSelectSKU_PRICES { Connection = connection, UOM_ID = p_UomId, TRADE_PRICE = p_Trade_Price, TIME_STAMP = p_Time_Stamp, TAX_PRICE = p_Tax_Price, SKU_PRICE_ID = p_Sku_Price_Id, SKU_ID = p_Sku_Id, RETAIL_PRICE = p_Retail_Price, LASTUPDATE_DATE = p_LastUpdateDate, ISCURRENT = p_IsCurrent, IP_ADDRESS = p_Ip_Address, DISTRIBUTOR_PRICE = p_Distributor_Price, DATE_EXPIRE = p_Date_Expire, DATE_EFFECTED = p_Date_Effected }.ExecuteTable();
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

        public DataTable SelectSKU_PRICES(DateTime p_Time_Stamp, DateTime p_LastUpdate_Date, int p_Sku_Price_Id, int p_Sku_Id, int p_Uom_Id, decimal p_Tax_Price, decimal p_Distributor_Price, decimal p_Trade_Price, decimal p_Retail_Price)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectSKU_PRICES { Connection = connection, DISTRIBUTOR_PRICE = p_Distributor_Price, LASTUPDATE_DATE = p_LastUpdate_Date, SKU_ID = p_Sku_Id, SKU_PRICE_ID = p_Sku_Price_Id, TIME_STAMP = p_Time_Stamp, RETAIL_PRICE = p_Retail_Price, TAX_PRICE = p_Tax_Price, TRADE_PRICE = p_Trade_Price, UOM_ID = p_Uom_Id, IP_ADDRESS = null }.ExecuteTable();
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

        public DataTable SelectSKuCurrentPrice(int p_Uom_id, int p_Company_id, int p_Division_Id, int p_Brand_Id, int p_Category_Id, int variant_Id, int p_Iscurrent, int p_sku_id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectskuPriceInfo { Connection = connection, UOM_ID = p_Uom_id, COMPANY_ID = p_Company_id, DIVISION_ID = p_Division_Id, BRAND_ID = p_Brand_Id, CATEGORY_ID = p_Category_Id, VARIANT_ID = variant_Id, ISACTIVE = true, ISCURRENT = p_Iscurrent, SKU_Id = p_sku_id }.ExecuteTable();
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

        public DataTable SelectSkuData(int p_SKU_Id, int Companyid)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectSKUS { Connection = connection, SKU_ID = p_SKU_Id, COMPANY_ID = Companyid }.ExecuteTable();
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

        public DataTable SelectSkuInfo(int Companyid)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectSkuInfo { Connection = connection, Company_id = Companyid }.ExecuteTable();
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

        public DataTable SelectSkuInfo(int p_company_id, int p_division_id, int p_category_id, int p_brand_id, int Companyid)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectSkuInfo { brand_id = p_brand_id, category_id = p_category_id, Principal_id = p_company_id, Connection = connection, division_id = p_division_id, Company_id = Companyid }.ExecuteTable();
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

        public DataTable SelectUOMs(int p_UOM_Id, string p_UOM_Desc)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectUOMS { Connection = connection, UOM_ID = p_UOM_Id, UOM_DESC = p_UOM_Desc, TIME_STAMP = Constants.DateNullValue, STATUS = -2147483648 }.ExecuteTable();
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

        public string UpdateSKU_PRICES(DateTime p_Time_Stamp, DateTime p_LastUpdate_Date, int p_Sku_Price_Id, int p_Sku_Id, int p_Uom_Id, decimal p_Tax_Price, decimal p_Distributor_Price, decimal p_Trade_Price, decimal p_Retail_Price, string p_Ip_Address)
        {
            IDbConnection connection = null;
            string str;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spUpdateSKU_PRICES { Connection = connection, DISTRIBUTOR_PRICE = p_Distributor_Price, LASTUPDATE_DATE = p_LastUpdate_Date, SKU_ID = p_Sku_Id, SKU_PRICE_ID = p_Sku_Price_Id, TIME_STAMP = p_Time_Stamp, RETAIL_PRICE = p_Retail_Price, TAX_PRICE = p_Tax_Price, TRADE_PRICE = p_Trade_Price, UOM_ID = p_Uom_Id, IP_ADDRESS = p_Ip_Address }.ExecuteQuery();
                str = "Record Updated";
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

        public string UpdateSKU_PRICES_Status()
        {
            IDbConnection connection = null;
            string str;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new usp_UpdateSKUPrices_Status { Connection = connection }.ExecuteQuery();
                str = "Record Inserted";
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

        public string UpdateSKU_PRICES_Status(IDbTransaction mTransaction)
        {
            try
            {
                new usp_UpdateSKUPrices_Status { Connection = mTransaction.Connection, Transaction = mTransaction }.ExecuteQuery();
                return "Record Inserted";
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                return null;
            }
        }
    }
}

