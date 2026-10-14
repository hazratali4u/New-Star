namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class ControllerCustomerCreditLimit
    {
        public void AdjustCreditLimitWithCashReceived(decimal Adjusted_amount, long Customer_id, int level_id, long Sku_level_id)
        {
            IDbConnection connection = null;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new uspAdjustCreditLimit { Connection = connection, ADJUSTED_AMOUNT = Adjusted_amount, CUSTOMER_ID = Customer_id, LEVEL_ID = level_id, SKU_LEVEL_ID = Sku_level_id }.ExecuteQuery();
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

        public DataTable GetCategorycreditLimit(long p_Customer_Id, int p_Company_Id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectCategory_Credit_Limit { COMPANY_ID = p_Company_Id, CUSTOMER_ID = p_Customer_Id, Connection = connection }.ExecuteTable();
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

        public DataTable GetCreditLimit(long p_Customer_Id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectCompany_Credit_Limit { Connection = connection, CUSTOMER_ID = p_Customer_Id }.ExecuteTable();
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

        public DataTable GetCreditLimitOfCustomers(int Credit_level)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                uspGetCreditInfoOfCustomers customers = new uspGetCreditInfoOfCustomers {
                    Connection = connection,
                    CREDIT_LEVEL = Credit_level
                };
                DataTable table = new DataTable();
                table2 = customers.ExecuteTable();
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

        public void InsertCategoryCreditLimit(decimal p_Allowed_Limit, long p_Customer_Id, long p_Sku_Category_Id, long p_Sku_Company_Id, decimal p_Used_Limit)
        {
            IDbConnection connection = null;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spInsertSKU_CATEGORY_CREDIT_LIMIT { Connection = connection, ALLOWED_LIMIT = p_Allowed_Limit, CUSTOMER_ID = p_Customer_Id, IS_ACTIVE = true, SKU_CATEGORY_ID = p_Sku_Category_Id, SKU_COMPANY_ID = p_Sku_Company_Id, TIME_STAMP = DateTime.Now, USED_LIMIT = p_Used_Limit }.ExecuteQuery();
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

        public void InsertCompanyCreditLimit(long p_Customer_Id, long p_Sku_Company_Id, decimal p_Allowed_Credit_Limit, decimal p_Used_Limit, int p_days)
        {
            IDbConnection connection = null;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spInsertSKU_COMPANY_CREDIT_LIMIT { ALLOWED_CREDIT_LIMIT = p_Allowed_Credit_Limit, Connection = connection, CUSTOMER_ID = p_Customer_Id, IS_ACTIVE = true, SKU_COMPANY_ID = p_Sku_Company_Id, TIME_STAMP = DateTime.Now, USED_LIMIT = p_Used_Limit, CREDITFORDAYS = p_days }.ExecuteQuery();
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

        public void UpdateCategoryCreditLimit(long p_Sku_Category_Credit_Limit_Id, decimal p_Allowed_Limit, long p_Customer_Id)
        {
            IDbConnection connection = null;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spUpdateSKU_CATEGORY_CREDIT_LIMIT { Connection = connection, SKU_CATEGORY_CREDIT_LIMIT_ID = p_Sku_Category_Credit_Limit_Id, ALLOWED_LIMIT = p_Allowed_Limit, CUSTOMER_ID = p_Customer_Id, IS_ACTIVE = true, SKU_CATEGORY_ID = -9223372036854775808L, SKU_COMPANY_ID = -9223372036854775808L, TIME_STAMP = Constants.DateNullValue, USED_LIMIT = -79228162514264337593543950335M }.ExecuteQuery();
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

        public void UpdateCategoryCreditLimit(long p_Sku_Category_Credit_Limit_Id, decimal p_Allowed_Limit, long p_Customer_Id, decimal p_Used_Limit)
        {
            IDbConnection connection = null;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spUpdateSKU_CATEGORY_CREDIT_LIMIT { Connection = connection, SKU_CATEGORY_CREDIT_LIMIT_ID = p_Sku_Category_Credit_Limit_Id, ALLOWED_LIMIT = p_Allowed_Limit, CUSTOMER_ID = p_Customer_Id, IS_ACTIVE = true, SKU_CATEGORY_ID = -9223372036854775808L, SKU_COMPANY_ID = -9223372036854775808L, TIME_STAMP = Constants.DateNullValue, USED_LIMIT = p_Used_Limit }.ExecuteQuery();
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

        public void UpdateCompanyCreditLimit(long p_Sku_Company_Credit_Limit_Id, long p_Customer_Id, decimal p_Allowed_Credit_Limit, decimal p_Used_Limit)
        {
            IDbConnection connection = null;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spUpdateSKU_COMPANY_CREDIT_LIMIT { SKU_COMPANY_CREDIT_LIMIT_ID = p_Sku_Company_Credit_Limit_Id, ALLOWED_CREDIT_LIMIT = p_Allowed_Credit_Limit, Connection = connection, CUSTOMER_ID = p_Customer_Id, IS_ACTIVE = true, SKU_COMPANY_ID = -9223372036854775808L, TIME_STAMP = Constants.DateNullValue, USED_LIMIT = p_Used_Limit }.ExecuteQuery();
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

        public void UpdateCompanyCreditLimit(long p_Sku_Company_Credit_Limit_Id, long p_Customer_Id, decimal p_Allowed_Credit_Limit, int p_days)
        {
            IDbConnection connection = null;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spUpdateSKU_COMPANY_CREDIT_LIMIT { SKU_COMPANY_CREDIT_LIMIT_ID = p_Sku_Company_Credit_Limit_Id, ALLOWED_CREDIT_LIMIT = p_Allowed_Credit_Limit, Connection = connection, CUSTOMER_ID = p_Customer_Id, IS_ACTIVE = true, SKU_COMPANY_ID = -9223372036854775808L, TIME_STAMP = Constants.DateNullValue, USED_LIMIT = -79228162514264337593543950335M, CREDITFORDAYS = p_days }.ExecuteQuery();
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

