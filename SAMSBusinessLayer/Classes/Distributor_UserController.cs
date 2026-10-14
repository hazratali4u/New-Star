namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class Distributor_UserController
    {
        public string InsertDistributor_User(int p_CompanyId, string p_NIC, bool p_Is_Active, DateTime p_Time_Stamp, DateTime p_Lastupdate_Date, int p_User_Type_Id, int p_Distributor_Id, int p_Role_Id, string p_Email_Address, string p_Address1, string p_Address2, string p_Login_Id, string p_Password, string p_Mobile, string p_User_Code, string p_User_Name, string p_Phone)
        {
            IDbConnection connection = null;
            string str;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                spInsertDISTRIBUTOR_USER tdistributor_user = new spInsertDISTRIBUTOR_USER {
                    Connection = connection,
                    COMPANY_ID = p_CompanyId,
                    USER_CODE = p_User_Code,
                    USER_NAME = p_User_Name,
                    NIC_NO = p_NIC,
                    ADDRESS1 = p_Address1,
                    ADDRESS2 = p_Address2,
                    DISTRIBUTOR_ID = p_Distributor_Id,
                    EMAIL = p_Email_Address,
                    LASTUPDATE_DATE = p_Lastupdate_Date,
                    LOGIN_ID = p_Login_Id,
                    MOBILE = p_Mobile,
                    PASSWORD = p_Password,
                    PHONE = p_Phone,
                    ROLE_ID = p_Role_Id,
                    TIME_STAMP = p_Time_Stamp,
                    DATE_JOIN = p_Time_Stamp,
                    USER_TYPE_ID = p_User_Type_Id,
                    IS_ACTIVE = p_Is_Active
                };
                tdistributor_user.ExecuteQuery();
                str = tdistributor_user.USER_ID.ToString();
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

        public bool InsertSalesForceArea(int p_Distributor_Id, int p_SaleForce_Id, int p_Area_Id)
        {
            IDbConnection connection = null;
            bool flag2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                flag2 = new spInsertSALEFORCE_AREA_ASSIGNMENT { Connection = connection, DISTRIBUTOR_ID = p_Distributor_Id, SALEFORCE_ID = p_SaleForce_Id, AREA_ID = p_Area_Id, TIME_STAMP = DateTime.Now }.ExecuteQuery();
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

        public bool InsertSalesForcePrincipal(int p_Distributor_Id, int p_SaleForce_Id, int p_Principal_Id)
        {
            IDbConnection connection = null;
            bool flag2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                flag2 = new spInsertSALEFORCE_PRINCIPAL_ASSIGNMENT { Connection = connection, DISTRIBUTOR_ID = p_Distributor_Id, SALEFORCE_ID = p_SaleForce_Id, PRINCIPAL_ID = p_Principal_Id, TIME_STAMP = DateTime.Now }.ExecuteQuery();
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

        public void InsertSalesForceShortage(int p_Distributor_Id, int p_Principal_id, int p_SaleForce_Id, decimal p_Amount, DateTime p_DocumentDate, string p_Remarks)
        {
            IDbConnection connection = null;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spInsertSALE_FORCE_SHORTAGE { Connection = connection, LOCATION_ID = p_Distributor_Id, SALE_FORCE_ID = p_SaleForce_Id, PRINCIPAL_ID = p_Principal_id, DOCUMENT_DATE = p_DocumentDate, AMOUNT = p_Amount, TIME_STAMP = DateTime.Now, REMARKS = p_Remarks }.ExecuteQuery();
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

        public DataTable SelectDistributorSalesForce(int p_Distributor_Id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectDISTRIBUTORSalesForce { Connection = connection, DISTRIBUTOR_ID = p_Distributor_Id }.ExecuteTable();
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

        public DataTable SelectDistributorSalesForceType(int p_Distributor_ID, int p_USER_TYPE_ID)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectDISTRIBUTOR_USER { Connection = connection, DISTRIBUTOR_ID = p_Distributor_ID, USER_TYPE_ID = p_USER_TYPE_ID }.ExecuteTable();
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

        public DataTable SelectDistributorUser(string LOGIN_ID, string PASSWORD)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectDISTRIBUTOR_USER { Connection = connection, LOGIN_ID = LOGIN_ID, PASSWORD = PASSWORD }.ExecuteTable();
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

        public DataTable SelectDistributorUser(int p_Type, int p_Distributor_Id, int Companyid)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectDISTRIBUTOR_USERInfo { Connection = connection, TYPE = p_Type, DISTRIBUTOR_ID = p_Distributor_Id, COMPANY_ID = Companyid }.ExecuteTable();
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

        public DataTable SelectRollBackInvoiceSaleForce(int p_Type, int p_Principal, int p_Distributor)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectRolebackSaleForce { Connection = connection, DISTRIBUTOR_ID = p_Distributor, PRINCIPAL_ID = p_Principal, DOCUMENT_TYPE = p_Type }.ExecuteTable();
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

        public DataTable SelectSaleForceAssignedArea(int p_Distributor_Id, int Area_Id, int Companyid)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectSP_DM_AssignAreaInfo { Connection = connection, DISTRIBUTOR_ID = p_Distributor_Id, COMPANY_ID = Companyid, AREA_ID = Area_Id }.ExecuteTable();
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

        public DataTable SelectSaleForceAssignedArea(int p_Type, int p_Distributor_Id, int Area_Id, int Companyid)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectSaleForce_AssignAreaInfo { Connection = connection, TYPE = p_Type, DISTRIBUTOR_ID = p_Distributor_Id, COMPANY_ID = Companyid, AREA_ID = Area_Id }.ExecuteTable();
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

        public DataTable SelectSalesForceArea(int p_Distributor_Id, int p_SaleForce_Id, long p_Area_Id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectSALEFORCE_AREA_ASSIGNMENT { Connection = connection, DISTRIBUTOR_ID = p_Distributor_Id, SALEFORCE_ID = p_SaleForce_Id, AREA_ID = p_Area_Id }.ExecuteTable();
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

        public DataTable SelectSalesForcePrincipal(int p_Distributor_Id, int p_SaleForce_Id, int p_Principal_Id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectSALEFORCE_PRINCIPAL_ASSIGNMENT { Connection = connection, DISTRIBUTOR_ID = p_Distributor_Id, SALEFORCE_ID = p_SaleForce_Id, PRINCIPAL_ID = p_Principal_Id }.ExecuteTable();
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

        public DataTable SelectSalesForceShortage(int p_Distributor_Id, int p_SaleForce_Id, int p_Principal_Id, DateTime p_DocumentDate)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectSALE_FORCE_SHORTAGE { Connection = connection, LOCATION_ID = p_Distributor_Id, SALE_FORCE_ID = p_SaleForce_Id, PRINCIPAL_ID = p_Principal_Id, DOCUMENT_DATE = p_DocumentDate, TIME_STAMP = Constants.DateNullValue, SALE_FORCE_SHORT_ID = -2147483648, REMARKS = null }.ExecuteTable();
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

        public string UpdateDistributor_User(int UserId, int p_CompanyId, string p_NIC, bool p_Is_Active, DateTime p_Time_Stamp, DateTime p_Lastupdate_Date, int p_User_Type_Id, int p_Distributor_Id, int p_Role_Id, string p_Email_Address, string p_Address1, string p_Address2, string p_Login_Id, string p_Password, string p_Mobile, string p_User_Code, string p_User_Name, string p_Phone)
        {
            IDbConnection connection = null;
            string str;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                spUpdateDISTRIBUTOR_USER edistributor_user = new spUpdateDISTRIBUTOR_USER {
                    USER_ID = UserId,
                    Connection = connection,
                    COMPANY_ID = p_CompanyId,
                    USER_CODE = p_User_Code,
                    USER_NAME = p_User_Name,
                    NIC_NO = p_NIC,
                    ADDRESS1 = p_Address1,
                    ADDRESS2 = p_Address2,
                    DISTRIBUTOR_ID = p_Distributor_Id,
                    EMAIL = p_Email_Address,
                    LASTUPDATE_DATE = p_Lastupdate_Date,
                    LOGIN_ID = p_Login_Id,
                    MOBILE = p_Mobile,
                    PASSWORD = p_Password,
                    PHONE = p_Phone,
                    ROLE_ID = p_Role_Id,
                    DATE_JOIN = p_Time_Stamp,
                    TIME_STAMP = p_Time_Stamp,                    
                    USER_TYPE_ID = p_User_Type_Id,
                    IS_ACTIVE = p_Is_Active
                };
                edistributor_user.ExecuteQuery();
                str = edistributor_user.USER_ID.ToString();
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

        public bool UpdateSalesForceArea(int p_Distributor_Id, int p_SaleForce_Id)
        {
            IDbConnection connection = null;
            bool flag2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                flag2 = new spUpdateSALEFORCE_AREA_ASSIGNMENT { Connection = connection, DISTRIBUTOR_ID = p_Distributor_Id, SALEFORCE_ID = p_SaleForce_Id }.ExecuteQuery();
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

        public bool UpdateSalesForcePrincipal(int p_Distributor_Id, int p_SaleForce_Id)
        {
            IDbConnection connection = null;
            bool flag2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                flag2 = new spUpdateSALEFORCE_PRINCIPAL_ASSIGNMENT { Connection = connection, DISTRIBUTOR_ID = p_Distributor_Id, SALEFORCE_ID = p_SaleForce_Id }.ExecuteQuery();
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

        public void UpdateSalesForceShortage(int p_ShortId, int p_Distributor_Id, int p_Principal_id, int p_SaleForce_Id, decimal p_Amount, DateTime p_DocumentDate, string p_Remarks)
        {
            IDbConnection connection = null;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spUpdateSALE_FORCE_SHORTAGE { Connection = connection, SALE_FORCE_SHORT_ID = p_ShortId, LOCATION_ID = p_Distributor_Id, SALE_FORCE_ID = p_SaleForce_Id, PRINCIPAL_ID = p_Principal_id, DOCUMENT_DATE = p_DocumentDate, TIME_STAMP = DateTime.Now, REMARKS = p_Remarks, AMOUNT = p_Amount }.ExecuteQuery();
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

