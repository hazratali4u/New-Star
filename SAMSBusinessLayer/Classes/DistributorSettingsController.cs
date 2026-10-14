namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class DistributorSettingsController
    {
        public string DeletedDistributorSettings(string p_Distributor_Id)
        {
            IDbConnection connection = null;
            string str;
            try
            {
                str = "";
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

        public string InsertDistributor_Settings(int p_Distributor_Id, short p_Transfer_Time, bool IsGstPaid_By_Dist, bool IsTp_Update, bool IsRp_Update, bool IsTaxPrice_Update, bool p_Can_Add_New_To, bool Can_Disable_Server_To)
        {
            IDbConnection connection = null;
            string str;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                uspInsertDISTRIBUTOR_SETTINGS tdistributor_settings = new uspInsertDISTRIBUTOR_SETTINGS {
                    Connection = connection,
                    CAN_ADD_NEW_TO = p_Can_Add_New_To,
                    CAN_DISABLE_SERVER_TO = Can_Disable_Server_To,
                    DISTRIBUTOR_ID = p_Distributor_Id,
                    ISGST_PAID_BY_DIST = IsGstPaid_By_Dist,
                    ISRP_UPDATE = IsRp_Update,
                    ISTAXPRICE_UPDATE = IsTaxPrice_Update,
                    ISTP_UPDATE = IsTp_Update,
                    TRANSFER_TIME = p_Transfer_Time
                };
                tdistributor_settings.ExecuteQuery();
                str = tdistributor_settings.DISTRIBUTOR_SETTINGS_ID.ToString();
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

        public string InsertDistributorSettings(int p_Distributor_Id, short p_Transfer_Time, bool p_Is_GST_Paid_By_Dist, bool p_Is_TP_Update, bool p_Is_RP_Update, bool p_Is_TaxPrice_Update, bool p_Can_Add_New, bool p_Can_Disable_Server_To)
        {
            IDbConnection connection = null;
            string str;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spInsertDISTRIBUTOR_SETTINGS { Connection = connection, DISTRIBUTOR_ID = p_Distributor_Id, TRANSFER_TIME = p_Transfer_Time, ISGST_PAID_BY_DIST = p_Is_GST_Paid_By_Dist, ISTP_UPDATE = p_Is_TP_Update, ISRP_UPDATE = p_Is_RP_Update, ISTAXPRICE_UPDATE = p_Is_TaxPrice_Update, CAN_ADD_NEW_TO = p_Can_Add_New, CAN_DISABLE_SERVER_TO = p_Can_Disable_Server_To }.ExecuteQuery();
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

        public string InsertDTDistributorSettings(int p_Distributor_Id, short p_Transfer_Time, bool p_Is_GST_Paid_By_Dist, bool p_Is_TP_Update, bool p_Is_RP_Update, bool p_Is_TaxPrice_Update, bool p_Can_Add_New, bool p_Can_Disable_Server_To, int p_Distributor_Settings_Id)
        {
            IDbConnection connection = null;
            string str;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spInsertDTDISTRIBUTOR_SETTINGS { Connection = connection, DISTRIBUTOR_SETTINGS_ID = p_Distributor_Settings_Id, DISTRIBUTOR_ID = p_Distributor_Id, TRANSFER_TIME = p_Transfer_Time, ISGST_PAID_BY_DIST = p_Is_GST_Paid_By_Dist, ISTP_UPDATE = p_Is_TP_Update, ISRP_UPDATE = p_Is_RP_Update, ISTAXPRICE_UPDATE = p_Is_TaxPrice_Update, CAN_ADD_NEW_TO = p_Can_Add_New, CAN_DISABLE_SERVER_TO = p_Can_Disable_Server_To }.ExecuteQuery();
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

        public DataTable SelectDistributorSettings(int p_Distributor_Id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectDISTRIBUTOR_SETTINGS { Connection = connection, DISTRIBUTOR_ID = p_Distributor_Id }.ExecuteTable();
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

        public DataTable SelectDistributorSettings(int p_Distributor_Settings_Id, int p_Distributor_Id, short p_Transfer_Time, bool p_Is_GST_Paid_By_Dist, bool p_Is_TP_Update, bool p_Is_RP_Update, bool p_Is_TaxPrice_Update, bool p_Can_Add_New, bool p_Can_Disable_Server_To)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectDISTRIBUTOR_SETTINGS { Connection = connection, DISTRIBUTOR_SETTINGS_ID = p_Distributor_Settings_Id, DISTRIBUTOR_ID = p_Distributor_Id, TRANSFER_TIME = p_Transfer_Time, ISGST_PAID_BY_DIST = p_Is_GST_Paid_By_Dist, ISTP_UPDATE = p_Is_TP_Update, ISRP_UPDATE = p_Is_RP_Update, ISTAXPRICE_UPDATE = p_Is_TaxPrice_Update, CAN_ADD_NEW_TO = p_Can_Add_New, CAN_DISABLE_SERVER_TO = p_Can_Disable_Server_To }.ExecuteTable();
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

        public DataTable SelectDTDistributorSettings(int p_Distributor_Settings_Id, int p_Distributor_Id, short p_Transfer_Time, bool p_Is_GST_Paid_By_Dist, bool p_Is_TP_Update, bool p_Is_RP_Update, bool p_Is_TaxPrice_Update, bool p_Can_Add_New, bool p_Can_Disable_Server_To)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectDTDISTRIBUTOR_SETTINGS { Connection = connection, DISTRIBUTOR_SETTINGS_ID = p_Distributor_Settings_Id, DISTRIBUTOR_ID = p_Distributor_Id, TRANSFER_TIME = p_Transfer_Time, ISGST_PAID_BY_DIST = p_Is_GST_Paid_By_Dist, ISTP_UPDATE = p_Is_TP_Update, ISRP_UPDATE = p_Is_RP_Update, ISTAXPRICE_UPDATE = p_Is_TaxPrice_Update, CAN_ADD_NEW_TO = p_Can_Add_New, CAN_DISABLE_SERVER_TO = p_Can_Disable_Server_To }.ExecuteTable();
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

        public string UpdateDistributorSettings(int p_Distributor_Settings_Id, int p_Distributor_Id, short p_Transfer_Time, bool p_Is_GST_Paid_By_Dist, bool p_Is_TP_Update, bool p_Is_RP_Update, bool p_Is_TaxPrice_Update, bool p_Can_Add_New, bool p_Can_Disable_Server_To)
        {
            IDbConnection connection = null;
            string str;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spUpdateDISTRIBUTOR_SETTINGS { Connection = connection, DISTRIBUTOR_SETTINGS_ID = p_Distributor_Settings_Id, DISTRIBUTOR_ID = p_Distributor_Id, TRANSFER_TIME = p_Transfer_Time, ISGST_PAID_BY_DIST = p_Is_GST_Paid_By_Dist, ISTP_UPDATE = p_Is_TP_Update, ISRP_UPDATE = p_Is_RP_Update, ISTAXPRICE_UPDATE = p_Is_TaxPrice_Update, CAN_ADD_NEW_TO = p_Can_Add_New, CAN_DISABLE_SERVER_TO = p_Can_Disable_Server_To }.ExecuteQuery();
                str = "Record Updated.";
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
    }
}

