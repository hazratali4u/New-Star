namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class SKUPriceDetailController
    {
        public bool InsertSKUPriceDetail(int p_CUSTOMER_ID, int p_SKUNAME_ID, decimal p_TRADE_PRICE, decimal p_RETAIL_PRICE, decimal p_PURCHASE_PRICE)
        {
            IDbConnection connection = null;
            bool flag2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                flag2 = new spInsertSKU_PRICE_DETAIL { Connection = connection, CUSTOMER_ID = p_CUSTOMER_ID, SKUNAME_ID = p_SKUNAME_ID, TRADE_PRICE = p_TRADE_PRICE, RETAIL_PRICE = p_RETAIL_PRICE, PURCHASE_PRICE = p_PURCHASE_PRICE }.ExecuteQuery();
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                flag2 = false;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return flag2;
        }

        public DataTable LoadGrid()
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new UspSKU_PRICE_DETAIL_GridData { Connection = connection }.ExecuteTable();
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

        public DataTable SelectData(int p_SKU_PRICEDETAIL_ID, int p_CUSTOMER_ID, int p_SKUNAME_ID, decimal p_TRADE_PRICE, decimal p_RETAIL_PRICE, decimal p_PURCHASE_PRICE)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectSKU_PRICE_DETAIL { Connection = connection, SKU_PRICEDETAIL_ID = p_SKU_PRICEDETAIL_ID, CUSTOMER_ID = p_CUSTOMER_ID, SKUNAME_ID = p_SKUNAME_ID, TRADE_PRICE = p_TRADE_PRICE, RETAIL_PRICE = p_RETAIL_PRICE, PURCHASE_PRICE = p_PURCHASE_PRICE }.ExecuteTable();
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

        public DataTable SelectDataPrice(int p_Principal_Id, int p_Division_ID, int p_Category_ID, int p_Brand_id, int p_Var_Id, int p_User_Id, int p_sku_id, int p_Type_id, DateTime p_ClosedDate)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new UspSelectSKUPriceList { Connection = connection, COMPANY_ID = p_Principal_Id, DIVISION_ID = p_Division_ID, CATEGORY_ID = p_Category_ID, BRAND_ID = p_Brand_id, VAR_ID = p_Var_Id, SKU_ID = p_sku_id, TYPEID = p_Type_id, USER_ID = p_User_Id, DAYCLOSED = p_ClosedDate }.ExecuteTable();
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

        public bool UpdateSKUPriceDetail(int p_SKU_PRICEDETAIL_ID, int p_CUSTOMER_ID, int p_SKUNAME_ID, decimal p_TRADE_PRICE, decimal p_RETAIL_PRICE, decimal p_PURCHASE_PRICE)
        {
            IDbConnection connection = null;
            bool flag2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                flag2 = new spUpdateSKU_PRICE_DETAIL { Connection = connection, SKU_PRICEDETAIL_ID = p_SKU_PRICEDETAIL_ID, CUSTOMER_ID = p_CUSTOMER_ID, SKUNAME_ID = p_SKUNAME_ID, TRADE_PRICE = p_TRADE_PRICE, RETAIL_PRICE = p_RETAIL_PRICE, PURCHASE_PRICE = p_PURCHASE_PRICE }.ExecuteQuery();
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                flag2 = false;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return flag2;
        }
    }
}

