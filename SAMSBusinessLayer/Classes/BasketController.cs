namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class BasketController
    {
        public string DeleteBasket()
        {
            try
            {
                return "";
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                return exception.Message;
            }
        }

        public string DeleteBasketDetail()
        {
            try
            {
                return "";
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                return exception.Message;
            }
        }

        public string InsertBasket(long p_Promotion_ID, int p_Scheme_ID, int p_Dist_ID, bool p_Is_Basket, bool p_Is_And, bool p_Is_Multiple, int p_Basket_On, int p_Basket_Selection)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                spInsertBASKET_MASTER tbasket_master = new spInsertBASKET_MASTER {
                    Connection = connection,
                    PROMOTION_ID = p_Promotion_ID,
                    SCHEME_ID = p_Scheme_ID,
                    DISTRIBUTOR_ID = p_Dist_ID,
                    IS_BASKET = p_Is_Basket,
                    IS_AND = p_Is_And,
                    IS_MULTIPLE = p_Is_Multiple,
                    BASKET_ON = p_Basket_On,
                    BASKET_SELECTION = p_Basket_Selection
                };
                tbasket_master.ExecuteQuery();
                message = tbasket_master.BASKET_ID.ToString();
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

        public string InsertBasketDetail(long p_Basket_ID, long p_Promotion_ID, int p_Scheme_ID, int p_Dist_ID, decimal p_Min_Val, decimal p_Max_Val, int p_Multiple_Of, int p_SKU_ID, int p_SKUBrand_ID, int p_SKUDiv_ID, int p_SKUCatg_ID, int p_SKUVariant_ID, int p_SKUGroup_ID, int p_UOM_ID, int p_CompanyID)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                spInsertBASKET_DETAIL tbasket_detail = new spInsertBASKET_DETAIL {
                    Connection = connection,
                    DISTRIBUTOR_ID = p_Dist_ID,
                    BASKET_ID = p_Basket_ID,
                    PROMOTION_ID = p_Promotion_ID,
                    CATEGORY_ID = p_SKUCatg_ID,
                    SKU_GROUP_ID = p_SKUGroup_ID,
                    UOM_ID = p_UOM_ID,
                    DIVISION_ID = p_SKUDiv_ID,
                    VARIANT_ID = p_SKUVariant_ID,
                    COMPANY_ID = p_CompanyID,
                    BRAND_ID = p_SKUBrand_ID,
                    SCHEME_ID = p_Scheme_ID,
                    MULTIPLE_OF = p_Multiple_Of,
                    SKU_ID = p_SKU_ID,
                    MIN_VAL = p_Min_Val,
                    MAX_VAL = p_Max_Val
                };
                tbasket_detail.ExecuteQuery();
                message = tbasket_detail.BASKET_DETAIL_ID.ToString();
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

        public DataTable SelectBasket(long p_Basket_ID, long p_Promotion_ID, int p_Scheme_ID, int p_Dist_ID, bool p_Is_Basket, bool p_Is_And, bool p_Is_Multiple, int p_Basket_On, int p_Basket_Selection)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectBASKET_MASTER { Connection = connection, BASKET_ID = p_Basket_ID, PROMOTION_ID = p_Promotion_ID, SCHEME_ID = p_Scheme_ID, DISTRIBUTOR_ID = p_Dist_ID, IS_BASKET = p_Is_Basket, IS_AND = p_Is_And, IS_MULTIPLE = p_Is_Multiple, BASKET_ON = p_Basket_On, BASKET_SELECTION = p_Basket_Selection }.ExecuteTable();
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

        public DataTable SelectBasketDetail(long p_BasketDetail_ID, long p_Basket_ID, long p_Promotion_ID, int p_Scheme_ID, int p_Dist_ID, decimal p_Min_Val, decimal p_Max_Val, int p_Multiple_Of, int p_SKU_ID, int p_SKUBrand_ID, int p_SKUDiv_ID, int p_SKUCatg_ID, int p_SKUVariant_ID, int p_SKUGroup_ID, int p_UOM_ID, int p_SKUCompany_ID)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spUpdateBASKET_DETAIL { 
                    Connection = connection, BASKET_DETAIL_ID = p_BasketDetail_ID, DISTRIBUTOR_ID = p_Dist_ID, BASKET_ID = p_Basket_ID, PROMOTION_ID = p_Promotion_ID, CATEGORY_ID = p_SKUCatg_ID, SKU_GROUP_ID = p_SKUGroup_ID, UOM_ID = p_UOM_ID, DIVISION_ID = p_SKUDiv_ID, VARIANT_ID = p_SKUVariant_ID, BRAND_ID = p_SKUBrand_ID, SCHEME_ID = p_Scheme_ID, MULTIPLE_OF = p_Multiple_Of, SKU_ID = p_SKU_ID, MIN_VAL = p_Min_Val, MAX_VAL = p_Max_Val, 
                    COMPANY_ID = p_SKUCompany_ID
                 }.ExecuteTable();
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

        public string UpdateBasket(long p_Basket_ID, long p_Promotion_ID, int p_Scheme_ID, int p_Dist_ID, bool p_Is_Basket, bool p_Is_And, bool p_Is_Multiple, int p_Basket_On, int p_Basket_Selection)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                new spUpdateBASKET_MASTER { Connection = connection, BASKET_ID = p_Basket_ID, PROMOTION_ID = p_Promotion_ID, SCHEME_ID = p_Scheme_ID, DISTRIBUTOR_ID = p_Dist_ID, IS_BASKET = p_Is_Basket, IS_AND = p_Is_And, IS_MULTIPLE = p_Is_Multiple, BASKET_ON = p_Basket_On, BASKET_SELECTION = p_Basket_Selection }.ExecuteQuery();
                message = "Record Updated";
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

        public string UpdateBasketDetail(long p_BasketDetail_ID, long p_Basket_ID, long p_Promotion_ID, int p_Scheme_ID, int p_Dist_ID, decimal p_Min_Val, decimal p_Max_Val, int p_Multiple_Of, int p_SKU_ID, int p_SKUBrand_ID, int p_SKUDiv_ID, int p_SKUCatg_ID, int p_SKUVariant_ID, int p_SKUGroup_ID, int p_UOM_ID, int p_SKUCompany_ID)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                new spUpdateBASKET_DETAIL { 
                    Connection = connection, BASKET_DETAIL_ID = p_BasketDetail_ID, DISTRIBUTOR_ID = p_Dist_ID, BASKET_ID = p_Basket_ID, PROMOTION_ID = p_Promotion_ID, CATEGORY_ID = p_SKUCatg_ID, SKU_GROUP_ID = p_SKUGroup_ID, UOM_ID = p_UOM_ID, DIVISION_ID = p_SKUDiv_ID, BRAND_ID = p_SKUBrand_ID, SCHEME_ID = p_Scheme_ID, MULTIPLE_OF = p_Multiple_Of, SKU_ID = p_SKU_ID, VARIANT_ID = p_SKUVariant_ID, MIN_VAL = p_Min_Val, MAX_VAL = p_Max_Val, 
                    COMPANY_ID = p_SKUCompany_ID
                 }.ExecuteQuery();
                message = "Record Updated";
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

