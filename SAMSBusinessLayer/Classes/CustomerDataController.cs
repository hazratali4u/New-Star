namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;
    using System.IO;

    public class CustomerDataController
    {
        private IDbConnection mConnection;
        private IDbTransaction mTransaction;

        public bool CommitTransaction()
        {
            if (this.Transaction != null)
            {
                this.Transaction.Commit();
                this.Connection.Close();
                return true;
            }
            return false;
        }

        public bool CustomerShifting(int p_fromDistributor_Id, int p_toDistributor, int p_fromArea_Id, int p_to_area_id, int p_Rout_id)
        {
            IDbConnection connection = null;
            bool flag;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new UspCustomerShifting { Connection = connection, FROM_DISTRIBUTOR_ID = p_fromDistributor_Id, FROM_AREA_ID = p_fromArea_Id, TO_DISTRIBUTOR_ID = p_toDistributor, TO_AREA_ID = p_to_area_id, ROUTE_ID = p_Rout_id }.ExecuteQuery();
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

        public bool ImportCustomer(int p_TownId, int p_DistributorId, string pFileName)
        {
            IDbConnection conn = null;
            FileStream stream = null;
            StreamReader reader = null;
            IDbTransaction transaction = null;
            bool flag;
            conn = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
            conn.Open();
            transaction = ProviderFactory.GetTransaction(conn);
            stream = new FileStream(pFileName, FileMode.Open);
            reader = new StreamReader(stream);
            string str = "";
            try
            {
                while ((str = reader.ReadLine()) != null)
                {
                    string[] strArray = str.Split(Constants.File_Delimiter);
                    new spInsertCUSTOMER { 
                        Connection = conn, Transaction = transaction, CUSTOMER_ID = long.Parse(strArray[0].ToString()), DISTRIBUTOR_ID = p_DistributorId, CUSTOMER_CODE = strArray[1].ToString(), CUSTOMER_NAME = strArray[2].ToString(), ADDRESS = strArray[3].ToString(), CONTACT_PERSON = strArray[4].ToString(), CONTACT_NUMBER = strArray[5].ToString(), IS_GST_REGISTERED = false, GST_NUMBER = null, IS_ACTIVE = true, REGDATE = DateTime.Now, TIME_STAMP = DateTime.Now, LASTUPDATE_DATE = DateTime.Now, TOWN_ID = p_TownId, 
                        AREA_ID = int.Parse(strArray[6].ToString()), ROUTE_ID = int.Parse(strArray[7].ToString()), CHANNEL_TYPE_ID = int.Parse(strArray[8].ToString()), BUSINESS_TYPE_ID = int.Parse(strArray[9].ToString()), PROMOTION_CLASS = int.Parse(strArray[10].ToString())
                     }.ExecuteQuery();
                }
                transaction.Commit();
                flag = true;
            }
            catch (Exception exception)
            {
                transaction.Rollback();
                reader.Close();
                conn.Close();
                ExceptionPublisher.PublishException(exception);
                flag = false;
            }
            finally
            {
                reader.Close();
                conn.Close();
            }
            return flag;
        }

        public bool ImportCustomerAssignment(int p_TownId, int p_DistributorId, string pFileName, int p_Principal_Id)
        {
            IDbConnection conn = null;
            FileStream stream = null;
            StreamReader reader = null;
            IDbTransaction transaction = null;
            bool flag;
            try
            {
                conn = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                conn.Open();
                transaction = ProviderFactory.GetTransaction(conn);
                stream = new FileStream(pFileName, FileMode.Open);
                reader = new StreamReader(stream);
                string str = "";
                while ((str = reader.ReadLine()) != null)
                {
                    string[] strArray = str.Split(Constants.File_Delimiter);
                    DataTable table = new spSelectCUSTOMER { Connection = conn, Transaction = transaction, CUSTOMER_CODE = strArray[0].ToString(), IS_ACTIVE = true }.ExecuteTable();
                    if (table.Rows.Count > 0)
                    {
                        new spInsertCUSTOMER_PRINCIPAL_CREDITLIMIT { Connection = conn, Transaction = transaction, CUSTOMER_ID = long.Parse(table.Rows[0]["Customer_Id"].ToString()), DISTRIBUTOR_ID = p_DistributorId, PRINCIPAL_ID = p_Principal_Id, TIME_STAMP = DateTime.Now }.ExecuteQuery();
                    }
                }
                transaction.Commit();
                flag = true;
            }
            catch (Exception exception)
            {
                transaction.Rollback();
                reader.Close();
                conn.Close();
                ExceptionPublisher.PublishException(exception);
                flag = false;
            }
            finally
            {
                reader.Close();
                conn.Close();
            }
            return flag;
        }

        public bool ImportMarket(int p_TownId, int p_DistributorId, string pFileName, int p_UserId)
        {
            IDbConnection conn = null;
            FileStream stream = null;
            StreamReader reader = null;
            IDbTransaction transaction = null;
            bool flag;
            try
            {
                conn = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                conn.Open();
                transaction = ProviderFactory.GetTransaction(conn);
                stream = new FileStream(pFileName, FileMode.Open);
                reader = new StreamReader(stream);
                string str = "";
                while ((str = reader.ReadLine()) != null)
                {
                    string[] strArray = str.Split(Constants.File_Delimiter);
                    new spInsertDISTRIBUTOR_ROUTE { Transaction = transaction, Connection = conn, DISTRIBUTOR_ID = p_DistributorId, AREA_ID = int.Parse(strArray[0].ToString()), ROUTE_ID = long.Parse(strArray[1].ToString()), ROUTE_CODE = strArray[2].ToString(), ROUTE_NAME = strArray[3].ToString(), TOWN_ID = p_TownId, LASTUPDATE_DATE = DateTime.Now, TIME_STAMP = DateTime.Now, IS_ACTIVE = true }.ExecuteQuery();
                }
                transaction.Commit();
                flag = true;
            }
            catch (Exception exception)
            {
                transaction.Rollback();
                reader.Close();
                conn.Close();
                ExceptionPublisher.PublishException(exception);
                flag = false;
            }
            finally
            {
                reader.Close();
                conn.Close();
            }
            return flag;
        }

        public bool ImportRoute(int p_TownId, int p_DistributorId, string pFileName, int p_UserId)
        {
            IDbConnection connection = null;
            FileStream stream = null;
            StreamReader reader = null;
            bool flag;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                stream = new FileStream(pFileName, FileMode.Open);
                reader = new StreamReader(stream);
                string str = "";
                while ((str = reader.ReadLine()) != null)
                {
                    string[] strArray = str.Split(Constants.File_Delimiter);
                    new spInsertDISTRIBUTOR_AREA { Connection = connection, DISTRIBUTOR_ID = p_DistributorId, AREA_ID = int.Parse(strArray[0].ToString()), AREA_CODE = strArray[1].ToString(), AREA_NAME = strArray[2].ToString(), TOWN_ID = p_TownId, TIME_STAMP = DateTime.Now, LASTUPDATE_DATE = DateTime.Now, IS_ACTIVE = true }.ExecuteQuery();
                }
                flag = true;
            }
            catch (Exception exception)
            {
                reader.Close();
                connection.Close();
                ExceptionPublisher.PublishException(exception);
                flag = false;
            }
            finally
            {
                reader.Close();
                connection.Close();
            }
            return flag;
        }

        public bool ImportSKUPrices(int p_DistributorId, string pFileName, int p_Principal_Id)
        {
            IDbConnection conn = null;
            FileStream stream = null;
            StreamReader reader = null;
            IDbTransaction transaction = null;
            bool flag;
            try
            {
                conn = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                conn.Open();
                transaction = ProviderFactory.GetTransaction(conn);
                stream = new FileStream(pFileName, FileMode.Open);
                reader = new StreamReader(stream);
                string str = "";
                while ((str = reader.ReadLine()) != null)
                {
                    string[] strArray = str.Split(Constants.File_Delimiter);
                    DataTable table = new spSelectSKUS { Connection = conn, Transaction = transaction, SKU_CODE = strArray[0].ToString(), ISACTIVE = true }.ExecuteTable();
                    if (table.Rows.Count > 0)
                    {
                        new UspProcessSKU_Prices { Connection = conn, Transaction = transaction, SKU_ID = int.Parse(table.Rows[0]["SKU_Id"].ToString()), DISTRIBUTOR_ID = p_DistributorId, DISTRIBUTOR_PRICE = decimal.Parse(strArray[1].ToString()), TRADE_PRICE = decimal.Parse(strArray[2].ToString()), RETAIL_PRICE = decimal.Parse(strArray[3].ToString()), DISTRIBUTOR_DISCOUNT = decimal.Parse(strArray[4].ToString()), TAX_PRICE = decimal.Parse(strArray[5].ToString()), SED_TAX = decimal.Parse(strArray[6].ToString()), DATE_EFFECTED = DateTime.Parse(strArray[7].ToString()), LASTUPDATE_DATE = DateTime.Now, TIME_STAMP = DateTime.Now }.ExecuteQuery();
                    }
                }
                transaction.Commit();
                flag = true;
            }
            catch (Exception exception)
            {
                transaction.Rollback();
                reader.Close();
                conn.Close();
                ExceptionPublisher.PublishException(exception);
                flag = false;
            }
            finally
            {
                reader.Close();
                conn.Close();
            }
            return flag;
        }

        public string InsertCustomer(long p_Customer_Id, bool p_Is_Gst_Registered, bool p_Is_Active, int p_Channel_Type_Id, int p_Volume_Class_Id, int p_Business_Type_Id, int p_Area_Id, int p_Route_Id, int p_Town_Id, int p_Distributor_Id, string p_Gst_Number, string p_Contact_Person, string p_Contact_Number, string p_Email_Address, string p_Customer_Code, string p_Customer_Name, string p_Address, DateTime p_RegDate)
        {
            IDbConnection connection = null;
            string str;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spInsertCUSTOMER { 
                    Connection = connection, CUSTOMER_ID = p_Customer_Id, ADDRESS = p_Address, AREA_ID = p_Area_Id, BUSINESS_TYPE_ID = p_Business_Type_Id, CHANNEL_TYPE_ID = p_Channel_Type_Id, CONTACT_NUMBER = p_Contact_Number, CONTACT_PERSON = p_Contact_Person, CUSTOMER_CODE = p_Customer_Code, CUSTOMER_NAME = p_Customer_Name, EMAIL_ADDRESS = p_Email_Address, GST_NUMBER = p_Gst_Number, IS_GST_REGISTERED = p_Is_Gst_Registered, TOWN_ID = p_Town_Id, PROMOTION_CLASS = p_Volume_Class_Id, DISTRIBUTOR_ID = p_Distributor_Id, 
                     ROUTE_ID = p_Route_Id, IS_ACTIVE = p_Is_Active, TIME_STAMP = DateTime.Now, LASTUPDATE_DATE = DateTime.Now, REGDATE = p_RegDate
                 }.ExecuteQuery();
                str = "Record Updated Customer Code " + p_Customer_Code;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                str = "Some Error Update Record";
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

        public bool InsertCustomerCreditLimit(int p_Distributor_Id, long p_Customer_Id, int p_Principal, decimal p_CreditLimit, int p_CreditDays)
        {
            IDbConnection connection = null;
            bool flag;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spInsertCUSTOMER_PRINCIPAL_CREDITLIMIT { Connection = connection, DISTRIBUTOR_ID = p_Distributor_Id, CUSTOMER_ID = p_Customer_Id, PRINCIPAL_ID = p_Principal, CREDITLIMIT_VALUE = p_CreditLimit, TIME_STAMP = DateTime.Today, CREDIT_DAYS = p_CreditDays }.ExecuteQuery();
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

        public bool IsUniqueCode(string p_Customer_Code)
        {
            IDbConnection connection = null;
            bool flag;
            try
            {
                spSelectCUSTOMER tcustomer = new spSelectCUSTOMER();
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                tcustomer.Connection = connection;
                tcustomer.CUSTOMER_CODE = p_Customer_Code;
                if (tcustomer.ExecuteTable().Rows.Count > 0)
                {
                    return false;
                }
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

        public bool OpenTransaction()
        {
            try
            {
                this.Connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                this.Connection.Open();
                this.Transaction = ProviderFactory.GetTransaction(this.Connection);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RollbackTransaction()
        {
            if (this.Transaction != null)
            {
                this.Transaction.Rollback();
                this.Connection.Close();
                return true;
            }
            return false;
        }

        public DataTable RptSelectCustomer(int p_User_Id, int p_DistributorId, string p_FIELDNAME, string p_PARAMETERNAME)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new UspRptSelectCUSTOMER { Connection = connection, FEILDNAME = p_FIELDNAME, PARAMETER = p_PARAMETERNAME, USER_ID = p_User_Id, DISTRIBUTOR_ID = p_DistributorId }.ExecuteTable();
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

        public DataTable SelectAllCustomer(int p_Distributor_Id, int p_Area, int p_Route)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                spSelectCUSTOMER tcustomer = new spSelectCUSTOMER {
                    Connection = connection,
                    DISTRIBUTOR_ID = p_Distributor_Id,
                    AREA_ID = p_Area,
                    ROUTE_ID = p_Route
                };
                table2 = new DataView(tcustomer.ExecuteTable()) { Sort = "CUSTOMER_NAME" }.ToTable();
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

        public DataTable SelectAllPrincipalCustomer(int p_Distributor_Id, int p_Area, int p_Route, int p_PrincipalId)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                UspSelectAllPRINCIPALCUSTOMER lprincipalcustomer = new UspSelectAllPRINCIPALCUSTOMER {
                    Connection = connection,
                    DISTRIBUTOR_ID = p_Distributor_Id,
                    AREA_ID = p_Area,
                    ROUTE_ID = p_Route,
                    PRINCIPAL_ID = p_PrincipalId
                };
                table2 = new DataView(lprincipalcustomer.ExecuteTable()) { Sort = "CUSTOMER_NAME" }.ToTable();
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

        public DataTable SelectCreditPendingInvoice(int p_Distributor_Id, int p_PRINCIPAL, long p_CUSTOMER_ID, int P_AREA_ID)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new UspSelectPendingCreditInvoice { Connection = connection, PRINCIPAL_ID = p_PRINCIPAL, DISTRIBUTOR_ID = p_Distributor_Id, CUSTOMER_ID = p_CUSTOMER_ID, AREA_ID = P_AREA_ID }.ExecuteTable();
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

        public DataTable SelectCustomerByCode(string p_Customer_Code)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectCUSTOMER { Connection = connection, CUSTOMER_CODE = p_Customer_Code }.ExecuteTable();
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

        public DataTable SelectCustomerByRoute(string strRoutes, string strCustomerTypes, int p_Distributor_Id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectRouteCustomer { Connection = connection, ROUTES = strRoutes, CUSTOMER_TYPES = strCustomerTypes, DISTRIBUTOR_ID = p_Distributor_Id }.ExecuteTable();
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

        public DataTable SelectCustomerCreditBalance(long p_Customer_Id, int p_Principal_Id, int p_Distributor_id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                Configuration.GetAccountHead();
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new UspSelectCustomerBalance { Connection = connection, CUSTOMER_ID = p_Customer_Id, PRINCIPAL_ID = p_Principal_Id, DISTRIBUTOR_ID = p_Distributor_id, ACCOUNT_HEAD_ID = long.Parse(Configuration.AccountReceivable) }.ExecuteTable();
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

        public DataTable SelectCustomerCreditLimit(int p_Distributor_Id, long p_CustomerId, int p_Principal_Id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectCUSTOMER_PRINCIPAL_CREDITLIMIT { Connection = connection, DISTRIBUTOR_ID = p_Distributor_Id, CUSTOMER_ID = p_CustomerId, PRINCIPAL_ID = p_Principal_Id }.ExecuteTable();
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

        public DataTable SelectCustomerData(int p_Distributor_Id, int p_Town_id, int p_Area_Id, int p_Route_Id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectCUSTOMER { Connection = connection, DISTRIBUTOR_ID = p_Distributor_Id, AREA_ID = p_Area_Id, ROUTE_ID = p_Route_Id, TOWN_ID = p_Town_id }.ExecuteTable();
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

        public DataTable SelectCustomerInfo(int p_Distributor_Id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectCustomerDataInfo { Connection = connection, DISTRIBUTOR_ID = p_Distributor_Id }.ExecuteTable();
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

        public DataTable SelectCustomersData(int AreaId)
        {
            DataTable table;
            try
            {
                this.mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                this.mConnection.Open();
                table = new spSelectCUSTOMER { Connection = this.mConnection, AREA_ID = AreaId, IS_ACTIVE = true }.ExecuteTable();
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                table = null;
            }
            finally
            {
                if ((this.mConnection != null) && (this.mConnection.State == ConnectionState.Open))
                {
                    this.mConnection.Close();
                }
            }
            return table;
        }

        public DataTable SelectDistGeoArea(int p_Distributor_Id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectDISTRIBUTOR_AREA { Connection = connection, DISTRIBUTOR_ID = p_Distributor_Id }.ExecuteTable();
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

        public DataTable SelectDistGeoArea(int p_Distributor_Id, int p_Town_ID)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectDISTRIBUTOR_AREA { Connection = connection, DISTRIBUTOR_ID = p_Distributor_Id, TOWN_ID = p_Town_ID }.ExecuteTable();
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

        public DataTable SelectDistGeoTown(int p_Distributor_Id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectDIST_GEO_TOWN { Connection = connection, DISTRIBUTOR_ID = p_Distributor_Id }.ExecuteTable();
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

        public DataTable SelectOpeningCredit(int p_Distributor_Id, DateTime p_DOCUMENT_DATE)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new UspSelectOpCredit { Connection = connection, DISTRIBUTOR_ID = p_Distributor_Id, DOCUMENT_DATE = p_DOCUMENT_DATE }.ExecuteTable();
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

        public DataSet SelectPivateTableExcelFile(int p_DISTRIBUTOR_ID, int p_PRINCIPAL_ID, DateTime P_FromDate, DateTime p_ToDate, int p_UserId)
        {
            IDbConnection connection = null;
            DataSet set2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                set2 = new UspfinalsaleDetailView { Connection = connection, DISTRIBUTOR_ID = p_DISTRIBUTOR_ID, PRINCIPAL_ID = p_PRINCIPAL_ID, FROM_DATE = P_FromDate, TO_DATE = p_ToDate, TOWN_ID = p_UserId }.ExecuteTable();
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                set2 = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return set2;
        }

        public DataTable SelectPrincipalCustomer(int p_Distributor_Id, int p_PrincipalId, DateTime p_document_date)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                UspSelectInvoiceBuiltyInfo info = new UspSelectInvoiceBuiltyInfo {
                    Connection = connection,
                    DISTRIBUTOR_ID = p_Distributor_Id,
                    PRINCIPAL_ID = p_PrincipalId,
                    Document_date = p_document_date,
                    CUSTOMER_ID = -9223372036854775808L                    
                };
                table2 = new DataView(info.ExecuteTable()) { Sort = "CUSTOMER_NAME" }.ToTable();
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

        public DataTable SelectPrincipalCustomer(int p_Distributor_Id, int p_Area, int p_Route, int p_PrincipalId)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                UspSelectPRINCIPALCUSTOMER tprincipalcustomer = new UspSelectPRINCIPALCUSTOMER {
                    Connection = connection,
                    DISTRIBUTOR_ID = p_Distributor_Id,
                    AREA_ID = p_Area,
                    ROUTE_ID = p_Route,
                    PRINCIPAL_ID = p_PrincipalId
                };
                table2 = new DataView(tprincipalcustomer.ExecuteTable()) { Sort = "CUSTOMER_NAME" }.ToTable();
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

        public DataTable SelectPrincipalCustomerOpBalance(int p_Distributor_Id, int p_CustomerId, DateTime p_fromDate, int p_PrincipalId)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new UspCustomerOpBalance { Connection = connection, Distributor_id = p_Distributor_Id, principal_id = p_PrincipalId, From_Date = p_fromDate, customer_id = p_CustomerId }.ExecuteTable();
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

        public string UpdateCustomer(long p_Customer_Id, bool p_Is_Gst_Registered, bool p_Is_Active, int p_Channel_Type_Id, int p_Volume_Class_Id, int p_Business_Type_Id, int p_Area_Id, int p_Route_Id, int p_Town_Id, int p_Distributor_Id, string p_Gst_Number, string p_Contact_Person, string p_Contact_Number, string p_Email_Address, string p_Customer_Code, string p_Customer_Name, string p_Address, DateTime p_RegDate)
        {
            IDbConnection connection = null;
            string str;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spUpdateCUSTOMER { 
                    Connection = connection, CUSTOMER_ID = p_Customer_Id, ADDRESS = p_Address, AREA_ID = p_Area_Id, BUSINESS_TYPE_ID = p_Business_Type_Id, CHANNEL_TYPE_ID = p_Channel_Type_Id, CONTACT_NUMBER = p_Contact_Number, CONTACT_PERSON = p_Contact_Person, CUSTOMER_CODE = p_Customer_Code, CUSTOMER_NAME = p_Customer_Name, EMAIL_ADDRESS = p_Email_Address, GST_NUMBER = p_Gst_Number, REGDATE = p_RegDate, IS_GST_REGISTERED = p_Is_Gst_Registered, TOWN_ID = p_Town_Id, 
                    ROUTE_ID = p_Route_Id, PROMOTION_CLASS = p_Volume_Class_Id, DISTRIBUTOR_ID = p_Distributor_Id, IS_ACTIVE = p_Is_Active, TIME_STAMP = DateTime.Now, LASTUPDATE_DATE = DateTime.Now
                 }.ExecuteQuery();
                str = "Record Updated Customer Code " + p_Customer_Code;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                str = "Some error Update Record";
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

        public bool UpdateCustomerCreditLimit(int p_Distributor_Id, long p_Customer_Id, int p_Principal, decimal p_CreditLimit)
        {
            IDbConnection connection = null;
            bool flag;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spUpdateCUSTOMER_PRINCIPAL_CREDITLIMIT { Connection = connection, DISTRIBUTOR_ID = p_Distributor_Id, CUSTOMER_ID = p_Customer_Id, PRINCIPAL_ID = p_Principal, CREDITLIMIT_VALUE = p_CreditLimit }.ExecuteQuery();
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

        public DataTable UspSelectCustomer(int p_Distributor_Id, string p_FIELDNAME, string p_PARAMETERNAME)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new UspSelectCUSTOMER { Connection = connection, FEILDNAME = p_FIELDNAME, PARAMETER = p_PARAMETERNAME, DISTRIBUTOR_ID = p_Distributor_Id }.ExecuteTable();
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

        public IDbConnection Connection
        {
            get
            {
                return this.mConnection;
            }
            set
            {
                this.mConnection = value;
            }
        }

        public IDbTransaction Transaction
        {
            get
            {
                return this.mTransaction;
            }
            set
            {
                this.mTransaction = value;
            }
        }
    }
}

