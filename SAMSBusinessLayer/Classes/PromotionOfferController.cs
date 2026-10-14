namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class PromotionOfferController
    {
        public string DeletePromotionOffer()
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

        public string InsertPromotionOffer(long p_Basket_ID, long p_Promotion_ID, int p_Scheme_ID, int p_Dist_ID, long p_BasketDetail_ID, int p_Quantity, decimal p_Offer_Value, float p_Discount, bool p_Is_And, int p_SKU_ID, int p_UOM_ID)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                spInsertPROMOTION_OFFER tpromotion_offer = new spInsertPROMOTION_OFFER {
                    Connection = connection,
                    IS_AND = p_Is_And,
                    DISCOUNT = p_Discount,
                    QUANTITY = p_Quantity,
                    SKU_ID = p_SKU_ID,
                    UOM_ID = p_UOM_ID,
                    SCHEME_ID = p_Scheme_ID,
                    DISTRIBUTOR_ID = p_Dist_ID,
                    BASKET_DETAIL_ID = p_BasketDetail_ID,
                    BASKET_ID = p_Basket_ID,
                    PROMOTION_ID = p_Promotion_ID,
                    OFFER_VALUE = p_Offer_Value
                };
                tpromotion_offer.ExecuteQuery();
                message = tpromotion_offer.PROMOTION_OFFER_ID.ToString();
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

        public DataTable SelectPromotionOffer(int p_Promotion_Offer_ID)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectPROMOTION_OFFERInfo { Connection = connection, PROMOTION_OFFER_ID = p_Promotion_Offer_ID }.ExecuteTable();
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

        public DataTable SelectPromotionOffer(int p_Promotion_Offer_ID, int p_Basket_ID, int p_Promotion_ID, int p_Scheme_ID, int p_Dist_ID, int p_BasketDetail_ID, int p_Quantity, decimal p_Offer_Value, float p_Discount, bool p_Is_And, int p_SKU_ID, int p_UOM_ID)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectPROMOTION_OFFER { Connection = connection, IS_AND = p_Is_And, DISCOUNT = p_Discount, QUANTITY = p_Quantity, SKU_ID = p_SKU_ID, UOM_ID = p_UOM_ID, SCHEME_ID = p_Scheme_ID, DISTRIBUTOR_ID = p_Dist_ID, BASKET_DETAIL_ID = p_BasketDetail_ID, PROMOTION_OFFER_ID = p_Promotion_Offer_ID, BASKET_ID = p_Basket_ID, PROMOTION_ID = p_Promotion_ID, OFFER_VALUE = p_Offer_Value }.ExecuteTable();
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

        public string UpdatePromotionOffer(int p_Promotion_Offer_ID, int p_Basket_ID, int p_Promotion_ID, int p_Scheme_ID, int p_Dist_ID, int p_BasketDetail_ID, int p_Quantity, decimal p_Offer_Value, float p_Discount, bool p_Is_And, int p_SKU_ID, int p_UOM_ID)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spUpdatePROMOTION_OFFER { Connection = connection, IS_AND = p_Is_And, DISCOUNT = p_Discount, QUANTITY = p_Quantity, SKU_ID = p_SKU_ID, UOM_ID = p_UOM_ID, SCHEME_ID = p_Scheme_ID, DISTRIBUTOR_ID = p_Dist_ID, BASKET_DETAIL_ID = p_BasketDetail_ID, PROMOTION_OFFER_ID = p_Promotion_Offer_ID, BASKET_ID = p_Basket_ID, PROMOTION_ID = p_Promotion_ID, OFFER_VALUE = p_Offer_Value }.ExecuteQuery();
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

