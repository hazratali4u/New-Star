namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class ControllerPaysical
    {
        public bool DELETEPysicalStock(int p_DISTRIBUTOR_ID, DateTime p_STOCK_DATE, int SKU_ID)
        {
            IDbConnection connection = null;
            bool flag;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spDeletePAYSICAL_STOCK { Connection = connection, DISTRIBUTOR_ID = p_DISTRIBUTOR_ID, SKU_ID = SKU_ID, STOCK_DATE = p_STOCK_DATE }.ExecuteQuery();
                flag = true;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                flag = false;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return flag;
        }

        public string InsertPysicalStock(int p_DISTRIBUTOR_ID, DateTime p_STOCK_DATE, int p_SKU_ID, int p_SQUANTITY, int p_UQUANTITY, decimal p_UNIT_RATE, int p_POST, int PRINCIPAL_ID)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spInsertPAYSICAL_STOCK { Connection = connection, DISTRIBUTOR_ID = p_DISTRIBUTOR_ID, STOCK_DATE = p_STOCK_DATE, SKU_ID = p_SKU_ID, SALEABLE_QUANTITY = p_SQUANTITY, UNSALEABLE_QUANTITY = p_UQUANTITY, UNIT_RATE = p_UNIT_RATE, PRINCIPAL_ID = PRINCIPAL_ID, POST = 0 }.ExecuteQuery();
                message = null;
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

        public DataTable SelectPysicalStock(int p_DISTRIBUTOR_ID, int p_POST, int PRINCIPAL_ID)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectPAYSICAL_STOCK { Connection = connection, DISTRIBUTOR_ID = p_DISTRIBUTOR_ID, PRINCIPAL_ID = PRINCIPAL_ID, POST = 0 }.ExecuteTable();
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

        public void UpdatePysicalStock(int p, DateTime dateTime, int p_3, int p_4, decimal p_5, int p_6, int p_7)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public string UpdatePysicalStock(int p_DISTRIBUTOR_ID, DateTime p_STOCK_DATE, int p_SKU_ID, int p_SQUANTITY, int p_UQUANTITY, decimal p_UNIT_RATE, int p_POST, int PRINCIPAL_ID)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spUpdatePAYSICAL_STOCK { Connection = connection, DISTRIBUTOR_ID = p_DISTRIBUTOR_ID, STOCK_DATE = p_STOCK_DATE, SKU_ID = p_SKU_ID, SALEABLE_QUANTITY = p_SQUANTITY, UNSALEABLE_QUANTITY = p_UQUANTITY, UNIT_RATE = p_UNIT_RATE, PRINCIPAL_ID = PRINCIPAL_ID, POST = 0 }.ExecuteQuery();
                message = null;
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

