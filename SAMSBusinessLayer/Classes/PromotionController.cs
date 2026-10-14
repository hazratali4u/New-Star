namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class PromotionController
    {
        public string Active_UnActivePromotion(int p_type, long p_Promtion_Id, bool p_Is_Active)
        {
            IDbConnection connection = null;
            string str;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new uspSelectPROMOTIONS01 { Connection = connection, type = p_type, PROMOTION_ID = p_Promtion_Id, IS_ACTIVE = p_Is_Active }.ExecuteTable();
                str = "Record Save";
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

        public string DeletePromotion()
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

        public DataTable GetBasketDetailForBasket(int Basket_ID)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspGetBasketPromotion01 { BasketId = Basket_ID, Connection = connection }.ExecuteTable();
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

        public DataTable GetBasketDetailForSlab(int Basket_ID)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new USPGETSLABPROMOTION { Connection = connection, BasketId_ID = Basket_ID }.ExecuteTable();
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

        public DataTable GetBasketMaster(long PromotionId)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectBASKET_MASTER01 { Connection = connection, BASKET_ID = -9223372036854775808L, SCHEME_ID = -2147483648, DISTRIBUTOR_ID = Configuration.DistributorId, PROMOTION_ID = PromotionId }.ExecuteTable();
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

        public DataTable GetDistributorHierarchy(int pDistributorId)
        {
            IDbConnection connection = null;
            DataTable table2;
            DataTable table = new DataTable();
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                usp_GetDistributorHierarchy hierarchy = new usp_GetDistributorHierarchy {
                    Connection = connection,
                    DistributorId = pDistributorId
                };
                hierarchy.ExecuteTable();
                table2 = hierarchy.ExecuteTable();
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

        public DataTable GetPromotionCustomerType(long p_promotionId)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectPROMOTION_CUSTOMER_TYPE { Connection = connection, CUSTOMER_TYPE_ID = -2147483648, DISTRIBUTOR_ID = Configuration.DistributorId, PROMOTION_CUSTOMER_TYPE_ID = -9223372036854775808L, PROMOTION_ID = p_promotionId, SCHEME_ID = -2147483648 }.ExecuteTable();
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

        public DataTable GetPromotionCustomerVolumeClass(long p_promotionId)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectPROMOTION_CUSTOMER_VOLUMECLASS { Connection = connection, PROMOTION_ID = p_promotionId }.ExecuteTable();
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

        public DataTable GetPromotionDistributors(long p_promotionId)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectPROMOTION_FOR { ASSIGNED_DISTRIBUTOR_ID = -2147483648, Connection = connection, DISTRIBUTOR_ID = Configuration.DistributorId, PROMOTION_FOR_ID = -9223372036854775808L, PROMOTION_ID = p_promotionId, SCHEME_ID = -2147483648 }.ExecuteTable();
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

        public string InsertPromotion(int p_Scheme_Id, int p_Distributor_Id, string p_Pro_Code, string p_Pro_Description, DateTime p_Promo_Date, bool p_Claimable, DateTime p_Start_Date, DateTime p_End_Date, bool p_Is_Active, int p_Promotion_Type, int p_Promotion_Selection, bool p_Is_Scheme)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                spInsertPROMOTION tpromotion = new spInsertPROMOTION {
                    Connection = connection,
                    SCHEME_ID = p_Scheme_Id,
                    DISTRIBUTOR_ID = p_Distributor_Id,
                    PROMOTION_CODE = p_Pro_Code,
                    PROMOTION_DESCRIPTION = p_Pro_Description,
                    PROMO_DATE = p_Promo_Date,
                    CLAIMABLE = p_Claimable,
                    START_DATE = p_Start_Date,
                    END_DATE = p_End_Date,
                    IS_ACTIVE = p_Is_Active,
                    PROMOTION_TYPE = p_Promotion_Type,
                    PROMOTION_SELECTION = p_Promotion_Selection,
                    IS_SCHEME = p_Is_Scheme
                };
                tpromotion.ExecuteQuery();
                message = tpromotion.PROMOTION_ID.ToString();
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

        public string InsertPromotion(int p_Scheme_Id, int p_Distributor_Id, string p_Pro_Code, string p_Pro_Description, DateTime p_Promo_Date, bool p_Claimable, DateTime p_Start_Date, DateTime p_End_Date, bool p_Is_Active, int p_Promotion_Type, int p_Promotion_Selection, bool p_Is_Scheme, bool p_Promotion_For, int p_UserId)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                spInsertPROMOTION tpromotion = new spInsertPROMOTION {
                    Connection = connection,
                    SCHEME_ID = p_Scheme_Id,
                    DISTRIBUTOR_ID = p_Distributor_Id,
                    PROMOTION_CODE = p_Pro_Code,
                    PROMOTION_DESCRIPTION = p_Pro_Description,
                    PROMO_DATE = p_Promo_Date,
                    CLAIMABLE = p_Claimable,
                    START_DATE = DateTime.Parse(p_Start_Date.ToShortDateString() + " 00:00:00"),
                    END_DATE = DateTime.Parse(p_End_Date.ToShortDateString() + " 23:59:59"),
                    IS_ACTIVE = p_Is_Active,
                    PROMOTION_TYPE = p_Promotion_Type,
                    PROMOTION_SELECTION = p_Promotion_Selection,
                    IS_SCHEME = p_Is_Scheme,
                    PROMOTION_FOR = p_Promotion_For,
                    USER_ID = p_UserId
                };
                tpromotion.ExecuteQuery();
                message = tpromotion.PROMOTION_ID.ToString();
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

        public DataTable SelectAllActivePromotions(int p_Distributor_Id, int p_Scheme_Id, DateTime StartDate, DateTime EndDate, bool IsActive)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectPROMOTIONS { Connection = connection, DISTRIBUTOR_ID = p_Distributor_Id, SCHEME_ID = p_Scheme_Id, START_DATE = StartDate, END_DATE = EndDate, IS_ACTIVE = IsActive }.ExecuteTable();
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

        public DataTable SelectAllPromotions(int p_type, long p_Promtion_Id, bool p_Is_Active)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectPROMOTIONS01 { Connection = connection, type = p_type, PROMOTION_ID = p_Promtion_Id, IS_ACTIVE = p_Is_Active }.ExecuteTable();
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
        
        public DataTable SelectPromotion(long p_Promotion_Id, int p_Scheme_Id, int p_Distributor_Id, string p_Pro_Code, string p_Pro_Description, DateTime p_Promo_Date, bool p_Claimable, DateTime p_Start_Date, DateTime p_End_Date, bool p_Is_Active, int p_Promotion_Type, int p_Promotion_Selection)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectPROMOTION { Connection = connection, PROMOTION_ID = p_Promotion_Id, SCHEME_ID = p_Scheme_Id, DISTRIBUTOR_ID = p_Distributor_Id, PROMOTION_CODE = p_Pro_Code, PROMOTION_DESCRIPTION = p_Pro_Description, PROMO_DATE = p_Promo_Date, CLAIMABLE = p_Claimable, START_DATE = p_Start_Date, END_DATE = p_End_Date, IS_ACTIVE = p_Is_Active, PROMOTION_TYPE = p_Promotion_Type, PROMOTION_SELECTION = p_Promotion_Selection }.ExecuteTable();
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

        public DataTable SelectPromotionWithSchemeInfo(int p_Distributor_Id, int p_Promotion_Id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new SAMS.BusinessLayer.Classes.uspSelectPromotionWithSchemes { Connection = connection, PROMOTION_ID = p_Promotion_Id, DISTRIBUTOR_ID = p_Distributor_Id }.ExecuteTable();
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

        public DataTable SelectSchemeID()
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectSchemeID { Connection = connection }.ExecuteTable();
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

        public DataTable SelectTerrAreaID(int pTerritoryID)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                uspSelectTerrArea area = new uspSelectTerrArea();
                DataTable table = new DataTable();
                area.Connection = connection;
                area.TERRITORY_ID = pTerritoryID;
                table2 = area.ExecuteTable();
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

        public string UpdatePromotion(long p_Promotion_Id, int p_Scheme_Id, int p_Distributor_Id, string p_Pro_Code, string p_Pro_Description, DateTime p_Promo_Date, bool p_Claimable, DateTime p_Start_Date, DateTime p_End_Date, bool p_Is_Active, int p_Promotion_Type, int p_Promotion_Selection)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spUpdatePROMOTION { Connection = connection, PROMOTION_ID = p_Promotion_Id, SCHEME_ID = p_Scheme_Id, DISTRIBUTOR_ID = p_Distributor_Id, PROMOTION_CODE = p_Pro_Code, PROMOTION_DESCRIPTION = p_Pro_Description, PROMO_DATE = p_Promo_Date, CLAIMABLE = p_Claimable, START_DATE = p_Start_Date, END_DATE = p_End_Date, IS_ACTIVE = p_Is_Active, PROMOTION_TYPE = p_Promotion_Type, PROMOTION_SELECTION = p_Promotion_Selection }.ExecuteQuery();
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

