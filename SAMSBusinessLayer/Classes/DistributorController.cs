namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class DistributorController
    {
        public string DeletedDistributor(int p_Distributor_Id)
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

        public string DeleteDistributor_User(int p_Distributor_Id, int p_User_Id)
        {
            IDbConnection connection = null;
            string str;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spDeleteDISTRIBUTOR_USER { Connection = connection, DISTRIBUTOR_ID = p_Distributor_Id, USER_ID = p_User_Id }.ExecuteQuery();
                str = p_User_Id.ToString();
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

        public DataTable getAssignedDistributor(int p_USER_ID)
        {
            DataTable table2;
            DataTable table = new DataTable();
            IDbConnection connection = null;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new UspSelectDistributorData { Connection = connection, USER_ID = p_USER_ID }.ExecuteTable();
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

        public DataTable GetBreadCrumb(int p_MODULE_ID)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spGetBreadCrumb { Connection = connection, MODULE_ID = p_MODULE_ID }.ExecuteTable();
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

        public int GetDist_ID(string p_Distributor_Code)
        {
            int num2;
            int num = 0;
            IDbConnection connection = null;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                DataTable table = new uspSelectDISTRIBUTOR { 
                    Connection = connection, DIST_CLASS_ID = -2147483648, TIME_STAMP = Constants.DateNullValue, LASTUPDATE_DATE = Constants.DateNullValue, DIVISION_ID = -2147483648, USER_ID = -2147483648, REGION_ID = -2147483648, ZONE_ID = -2147483648, SUBZONE_ID = -2147483648, CONTACT_PERSON = null, CONTACT_NUMBER = null, GST_NUMBER = null, PASSWORD = null, ADDRESS1 = null, ADDRESS2 = null, DISTRIBUTOR_ID = -2147483648, 
                    DISTRIBUTOR_CODE = p_Distributor_Code, DISTRIBUTOR_NAME = null, IP_ADDRESS = null
                 }.ExecuteTable();
                if (table.Rows.Count > 0)
                {
                    num = int.Parse(table.Rows[0]["Distributor_ID"].ToString());
                }
                num2 = num;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                num2 = 0;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return num2;
        }

        public static int GetDistributorID(string DistributorCode)
        {
            int num2;
            int num = 0;
            IDbConnection connection = null;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                DataTable table = new uspSelectDistributor_ID { Connection = connection, DISTRIBUTOR_CODE = DistributorCode }.ExecuteTable();
                if (table.Rows.Count > 0)
                {
                    num = int.Parse(table.Rows[0][0].ToString());
                }
                num2 = num;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                num2 = 0;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return num2;
        }

        public DataTable GetDistributors(int p_distributorType, int p_RegionId, int p_ZoneId)
        {
            DataTable table2;
            DataTable table = new DataTable();
            IDbConnection connection = null;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspGetDistributor { Connection = connection, DistributorType = p_distributorType, RegionId = p_RegionId, ZoneId = p_ZoneId }.ExecuteTable();
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

        public DataTable GetDistributors(string p_distributorType, int p_RegionId, int p_ZoneId)
        {
            DataTable table2;
            DataTable table = new DataTable();
            IDbConnection connection = null;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspGetDistributor01 { Connection = connection, DistributorType = p_distributorType, RegionId = p_RegionId, ZoneId = p_ZoneId }.ExecuteTable();
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

        public DataTable GetDistributorsTown(int p_distributorType, int p_RegionId, int p_TownId)
        {
            DataTable table2;
            DataTable table = new DataTable();
            IDbConnection connection = null;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspGetDistributorTwonWise { Connection = connection, DistributorType = p_distributorType, RegionId = p_RegionId, ZoneId = p_TownId }.ExecuteTable();
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

        public DataTable GetUserRole(int p_UserID)
        {
            DataTable table2;
            DataTable table = new DataTable();
            IDbConnection connection = null;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectSAMS_USER { Connection = connection, USER_ID = p_UserID }.ExecuteTable();
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

        public string InsertDistributor(int p_Company, int p_Dist_Class_Id, bool p_IsDeleted, DateTime p_Time_Stamp, DateTime p_LastUpdate_Date, int p_Division_Id, int p_User_Id, int p_Region_Id, int p_Zone_Id, int p_SubZone_Id, string p_Contact_Person, string p_Contact_Number, string p_Gst_Number, string p_Password, string p_Address1, string p_Address2, string p_Distributor_Code, string p_Distributor_Name, string p_Ip_Address, bool p_Is_Registered, int p_CREDIT_LEVEL, int p_UserId)
        {
            IDbConnection connection = null;
            string str;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                spInsertDISTRIBUTOR tdistributor = new spInsertDISTRIBUTOR {
                    Connection = connection,
                    COMPANY_ID = p_Company,
                    USER_ID = p_UserId,
                    DIST_CLASS_ID = p_Dist_Class_Id,
                    TIME_STAMP = p_Time_Stamp,
                    LASTUPDATE_DATE = p_LastUpdate_Date,
                    DIVISION_ID = p_Division_Id,
                    REGION_ID = p_Region_Id,
                    ZONE_ID = p_Zone_Id,
                    SUBZONE_ID = p_SubZone_Id,
                    CREDIT_LEVEL = p_CREDIT_LEVEL,
                    CONTACT_PERSON = p_Contact_Person,
                    CONTACT_NUMBER = p_Contact_Number,
                    GST_NUMBER = p_Gst_Number,
                    PASSWORD = p_Password,
                    ADDRESS1 = p_Address1,
                    ADDRESS2 = p_Address2,
                    DISTRIBUTOR_CODE = p_Distributor_Code,
                    DISTRIBUTOR_NAME = p_Distributor_Name,                    
                    IP_ADDRESS = p_Ip_Address,
                    ISDELETED = p_IsDeleted,
                    IS_REGISTERED = p_Is_Registered
                };
                tdistributor.ExecuteQuery();
                str = tdistributor.DISTRIBUTOR_ID.ToString();
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

        public string InsertDistributor_User(bool p_Is_Deleted, bool p_Is_Distributor_Login, bool p_Is_Ppc_Login, bool p_Is_Active, DateTime p_Time_Stamp, DateTime p_Lastupdate_Date, int p_User_Type_Id, long p_Town_Id, int p_C_User_Id, int p_Region_Id, int p_Zone_Id, int p_Subzone_Id, int p_Distributor_Id, int p_Division_Id, int p_Role_Id, string p_Email_Address, string p_Address1, string p_Address2, string p_Login_Id, string p_Password, string p_Fax, string p_Mobile, string p_User_Code, string p_User_Name, string p_Phone, long p_Route_Id)
        {
            IDbConnection connection = null;
            string str;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                spInsertDISTRIBUTOR_USER tdistributor_user = new spInsertDISTRIBUTOR_USER {
                    Connection = connection,
                    ADDRESS1 = p_Address1,
                    ADDRESS2 = p_Address2,
                    DISTRIBUTOR_ID = p_Distributor_Id,
                    EMAIL = p_Email_Address,
                    IS_ACTIVE = p_Is_Active,
                    LASTUPDATE_DATE = p_Lastupdate_Date,
                    LOGIN_ID = p_Login_Id,
                    MOBILE = p_Mobile,
                    PASSWORD = p_Password,
                    PHONE = p_Phone,
                    ROLE_ID = p_Role_Id,
                    TIME_STAMP = p_Time_Stamp,
                    USER_CODE = p_User_Code,
                    USER_NAME = p_User_Name,
                    USER_TYPE_ID = p_User_Type_Id
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

        public string InsertDistributorUserCompany(int p_Distributor_Id, int p_SALESFORCE_TYPE, int p_SALESFORCE_ID, int p_COMPANY_ID, DateTime p_TIME_STAMP, bool p_IS_ACTIVE)
        {
            IDbConnection connection = null;
            string str;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spInsertSALESFORCE_COMPANY { Connection = connection, DISTRIBUTOR_ID = p_Distributor_Id, SALESFORCE_TYPE = p_SALESFORCE_TYPE, SALESFORCE_ID = p_SALESFORCE_ID, COMPANY_ID = p_COMPANY_ID, TIME_STAMP = p_TIME_STAMP, IS_ACTIVE = p_IS_ACTIVE }.ExecuteQuery();
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

        public string InsertDistributorUserTerritory(DateTime p_Time_Stamp, DateTime p_Lastupdate_Date, int p_User_Id, int p_Territory_Id, int p_Distributor_Id)
        {
            IDbConnection connection = null;
            string str;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spInsertDISTRIBUTOR_USER_TERRITORY { Connection = connection, DISTRIBUTOR_ID = p_Distributor_Id, LASTUPDATE_DATE = p_Lastupdate_Date, TERRITORY_ID = p_Territory_Id, USER_ID = p_User_Id, TIME_STAMP = p_Time_Stamp }.ExecuteQuery();
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

        public DataTable InsertDTDistributor(int p_Dist_Class_Id, bool p_IsDeleted, int p_Division_Id, int p_User_Id, int p_Region_Id, int p_Zone_Id, int p_SubZone_Id, string p_Contact_Person, string p_Contact_Number, string p_Gst_Number, string p_Password, string p_Address1, string p_Address2, int p_Distributor_Id, string p_Distributor_Code, string p_Distributor_Name, string p_Ip_Address, bool p_Is_Registered)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spInsertDTDISTRIBUTOR { 
                    Connection = connection, DIST_CLASS_ID = p_Dist_Class_Id, ISDELETED = p_IsDeleted, TIME_STAMP = Constants.DateNullValue, LASTUPDATE_DATE = Constants.DateNullValue, DIVISION_ID = p_Division_Id, USER_ID = p_User_Id, REGION_ID = p_Region_Id, ZONE_ID = p_Zone_Id, SUBZONE_ID = p_SubZone_Id, CONTACT_PERSON = p_Contact_Person, CONTACT_NUMBER = p_Contact_Number, GST_NUMBER = p_Gst_Number, PASSWORD = p_Password, ADDRESS1 = p_Address1, ADDRESS2 = p_Address2, 
                    DISTRIBUTOR_ID = p_Distributor_Id, DISTRIBUTOR_CODE = p_Distributor_Code, DISTRIBUTOR_NAME = p_Distributor_Name, IP_ADDRESS = p_Ip_Address, IS_REGISTERED = p_Is_Registered
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

        public DataTable MaxDayClose(int p_Distributor_ID)
        {
            DataTable table2;
            DataTable table = new DataTable();
            IDbConnection connection = null;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new UspSelectMaxDayCloseDistributor { Connection = connection, DISTRIBUTOR_ID = p_Distributor_ID }.ExecuteTable();
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

        public DataTable SelectDistributor(int p_Distributor_Id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectDISTRIBUTOR { 
                    Connection = connection, DIST_CLASS_ID = -2147483648, ISDELETED = false, TIME_STAMP = Constants.DateNullValue, LASTUPDATE_DATE = Constants.DateNullValue, DIVISION_ID = -2147483648, USER_ID = -2147483648, REGION_ID = -2147483648, ZONE_ID = -2147483648, SUBZONE_ID = -2147483648, CONTACT_PERSON = null, CONTACT_NUMBER = null, GST_NUMBER = null, PASSWORD = null, ADDRESS1 = null, ADDRESS2 = null, 
                    DISTRIBUTOR_ID = p_Distributor_Id, DISTRIBUTOR_CODE = null, DISTRIBUTOR_NAME = null, IP_ADDRESS = null
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

        public DataTable SelectDistributor(int p_Distributor_Id, int p_distributor_type, int p_Company_Id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectDISTRIBUTOR { 
                    Connection = connection, DIST_CLASS_ID = -2147483648, ISDELETED = false, TIME_STAMP = Constants.DateNullValue, LASTUPDATE_DATE = Constants.DateNullValue, DIVISION_ID = -2147483648, USER_ID = -2147483648, REGION_ID = -2147483648, ZONE_ID = -2147483648, SUBZONE_ID = p_distributor_type, CONTACT_PERSON = null, CONTACT_NUMBER = null, GST_NUMBER = null, PASSWORD = null, ADDRESS1 = null, ADDRESS2 = null, 
                    DISTRIBUTOR_ID = p_Distributor_Id, DISTRIBUTOR_CODE = null, DISTRIBUTOR_NAME = null, IP_ADDRESS = null, IS_REGISTERED = true, COMPANY_ID = p_Company_Id
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

        public DataTable SelectDistributor(int p_Dist_Class_Id, int p_IsDeleted, int p_Division_Id, int p_User_Id, int p_Region_Id, int p_Zone_Id, int p_SubZone_Id, string p_Contact_Person, string p_Contact_Number, string p_Gst_Number, string p_Password, string p_Address1, string p_Address2, int p_Distributor_Id, string p_Distributor_Code, string p_Distributor_Name)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectDISTRIBUTOR { 
                    Connection = connection, DIST_CLASS_ID = p_Dist_Class_Id, ISDELETED = true, TIME_STAMP = Constants.DateNullValue, LASTUPDATE_DATE = Constants.DateNullValue, DIVISION_ID = p_Division_Id, USER_ID = p_User_Id, REGION_ID = p_Region_Id, ZONE_ID = p_Zone_Id, SUBZONE_ID = p_SubZone_Id, CONTACT_PERSON = p_Contact_Person, CONTACT_NUMBER = p_Contact_Number, GST_NUMBER = p_Gst_Number, PASSWORD = p_Password, ADDRESS1 = p_Address1, ADDRESS2 = p_Address2, 
                    DISTRIBUTOR_ID = p_Distributor_Id, DISTRIBUTOR_CODE = p_Distributor_Code, DISTRIBUTOR_NAME = p_Distributor_Name, IP_ADDRESS = null, CREDIT_LEVEL = -2147483648, IS_REGISTERED = true
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

        public DataTable SelectDistributor(int p_Dist_Class_Id, int p_IsDeleted, int p_Division_Id, int p_User_Id, int p_Region_Id, int p_Zone_Id, int p_SubZone_Id, string p_Contact_Person, string p_Contact_Number, string p_Gst_Number, string p_Password, string p_Address1, string p_Address2, int p_Distributor_Id, string p_Distributor_Code, string p_Distributor_Name, int p_Is_Registered)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectDISTRIBUTOR { 
                    Connection = connection, DIST_CLASS_ID = p_Dist_Class_Id, ISDELETED = p_IsDeleted, TIME_STAMP = Constants.DateNullValue, LASTUPDATE_DATE = Constants.DateNullValue, DIVISION_ID = p_Division_Id, USER_ID = p_User_Id, REGION_ID = p_Region_Id, ZONE_ID = p_Zone_Id, CREDIT_LEVEL = -2147483648, SUBZONE_ID = p_SubZone_Id, CONTACT_PERSON = p_Contact_Person, CONTACT_NUMBER = p_Contact_Number, GST_NUMBER = p_Gst_Number, PASSWORD = p_Password, ADDRESS1 = p_Address1, 
                    ADDRESS2 = p_Address2, DISTRIBUTOR_ID = p_Distributor_Id, DISTRIBUTOR_CODE = p_Distributor_Code, DISTRIBUTOR_NAME = p_Distributor_Name, IP_ADDRESS = null, IS_REGISTERED = p_Is_Registered
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

        public DataTable SelectDistributor_User(bool p_Is_Deleted, bool p_Is_Active, DateTime p_Time_Stamp, DateTime p_Lastupdate_Date, int p_User_Type_Id, long p_Town_Id, int p_C_User_Id, int p_Region_Id, int p_Zone_Id, int p_Subzone_Id, int p_Distributor_Id, int p_Division_Id, int p_Role_Id, string p_Email_Address, string p_Address1, string p_Address2, string p_Login_Id, string p_Password, string p_Fax, string p_Mobile, string p_User_Code, string p_User_Name, string p_Phone, int p_User_Id, long p_Route_Id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                spSelectDISTRIBUTOR_USER tdistributor_user = new spSelectDISTRIBUTOR_USER {
                    Connection = connection,
                    ADDRESS1 = p_Address1,
                    ADDRESS2 = p_Address2,
                    DISTRIBUTOR_ID = p_Distributor_Id,
                    EMAIL = p_Email_Address,
                    IS_ACTIVE = p_Is_Active,
                    LASTUPDATE_DATE = p_Lastupdate_Date,
                    LOGIN_ID = p_Login_Id,
                    MOBILE = p_Mobile,
                    PASSWORD = p_Password,
                    PHONE = p_Phone,
                    ROLE_ID = p_Role_Id,
                    TIME_STAMP = p_Time_Stamp,
                    USER_CODE = p_User_Code,
                    USER_ID = p_User_Id,
                    USER_NAME = p_User_Name,
                    USER_TYPE_ID = p_User_Type_Id
                };
                DataTable table = new DataTable();
                table2 = tdistributor_user.ExecuteTable();
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

        public DataTable SelectDistributor_User_Territory(DateTime p_Time_Stamp, DateTime p_Lastupdate_Date, int p_User_Id, int p_Territory_Id, int p_Distributor_Id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                spSelectDISTRIBUTOR_USER_TERRITORY tdistributor_user_territory = new spSelectDISTRIBUTOR_USER_TERRITORY {
                    Connection = connection,
                    DISTRIBUTOR_ID = p_Distributor_Id,
                    LASTUPDATE_DATE = p_Lastupdate_Date,
                    TERRITORY_ID = p_Territory_Id,
                    TIME_STAMP = p_Time_Stamp,
                    USER_ID = p_User_Id
                };
                DataTable table = new DataTable();
                table2 = tdistributor_user_territory.ExecuteTable();
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

        public static DataTable SelectDistributorCode()
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectDistributor_Code { Connection = connection }.ExecuteTable();
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

        public static DataTable SelectDistributorCode(string p_Address1, string p_Address2, string p_ContactNumber, string p_ContactPerson, int p_Distributor_Class_Id, string p_Distributor_Code, int p_Distributor_Id, string p_Distributor_Name, int p_Division_Id, string p_gst_Number, string p_ip_Address, int p_Is_Registered, int p_IsDeleted, DateTime p_LastUpdateDate, string p_password, int p_Region_Id, int p_SubZoneId, DateTime p_time_Stamp, int p_User_id, int p_ZoneId)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectDistributor_Code { 
                    Connection = connection, ADDRESS1 = p_Address1, ADDRESS2 = p_Address2, CONTACT_NUMBER = p_ContactNumber, CONTACT_PERSON = p_ContactPerson, DIST_CLASS_ID = p_Distributor_Class_Id, DISTRIBUTOR_CODE = p_Distributor_Code, DISTRIBUTOR_ID = p_Distributor_Id, DISTRIBUTOR_NAME = p_Distributor_Name, DIVISION_ID = p_Division_Id, GST_NUMBER = p_gst_Number, IP_ADDRESS = p_ip_Address, ISDELETED = p_IsDeleted, LASTUPDATE_DATE = p_LastUpdateDate, PASSWORD = p_password, REGION_ID = p_Region_Id, 
                    SUBZONE_ID = p_SubZoneId, TIME_STAMP = p_time_Stamp, USER_ID = p_User_id, ZONE_ID = p_ZoneId, IS_REGISTERED = p_Is_Registered
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

        public DataTable SelectDistributorInfo(int p_Distributor_ID, int p_User_Id, int Companyid)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectDistributorInfo { Connection = connection, DISTRIBUTOR_ID = p_Distributor_ID, USER_ID = p_User_Id, COMPANY_ID = Companyid }.ExecuteTable();
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

        public DataTable SelectDistributorInfo(int p_Distributor_ID, int p_User_Id, int p_DistributorType, int Companyid)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectDistributorInfo { Connection = connection, DISTRIBUTOR_ID = p_Distributor_ID, USER_ID = p_User_Id, DISTRIBUTOR_TYPE = p_DistributorType, COMPANY_ID = Companyid }.ExecuteTable();
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

        public DataTable SelectDistributorTypeInfo(int p_DistributorType_ID)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectDISTRIBUTOR_TYPE { Connection = connection, DISTRIBUTOR_TYPE_ID = p_DistributorType_ID }.ExecuteTable();
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

        public DataTable SelectDistributorUserCompany(int p_type, int p_Distributor_Id, int p_SALESFORCE_ID)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectSALESFORCE_COMPANY { Connection = connection, type = p_type, DISTRIBUTOR_ID = p_Distributor_Id, SALESFORCE_ID = p_SALESFORCE_ID }.ExecuteTable();
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

        public DataTable SelectDistributorWithType(int p_Dist_Class_Id, int p_IsDeleted, int p_Division_Id, int p_User_Id, int p_Region_Id, int p_Zone_Id, int p_SubZone_Id, string p_Contact_Person, string p_Contact_Number, string p_Gst_Number, string p_Password, string p_Address1, string p_Address2, int p_Distributor_Id, string p_Distributor_Code, string p_Distributor_Name, int p_Is_Registered)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectDISTRIBUTORWITHTYPE { 
                    Connection = connection, DIST_CLASS_ID = p_Dist_Class_Id, ISDELETED = false, TIME_STAMP = Constants.DateNullValue, LASTUPDATE_DATE = Constants.DateNullValue, DIVISION_ID = p_Division_Id, USER_ID = p_User_Id, REGION_ID = p_Region_Id, ZONE_ID = p_Zone_Id, SUBZONE_ID = p_SubZone_Id, CONTACT_PERSON = p_Contact_Person, CONTACT_NUMBER = p_Contact_Number, GST_NUMBER = p_Gst_Number, PASSWORD = p_Password, ADDRESS1 = p_Address1, ADDRESS2 = p_Address2, 
                    DISTRIBUTOR_ID = p_Distributor_Id, DISTRIBUTOR_CODE = p_Distributor_Code, DISTRIBUTOR_NAME = p_Distributor_Name, IP_ADDRESS = null, IS_REGISTERED = p_Is_Registered
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

        public DataTable SelectDTDistributor(int p_Dist_Class_Id, int p_IsDeleted, int p_Division_Id, int p_User_Id, int p_Region_Id, int p_Zone_Id, int p_SubZone_Id, string p_Contact_Person, string p_Contact_Number, string p_Gst_Number, string p_Password, string p_Address1, string p_Address2, int p_Distributor_Id, string p_Distributor_Code, string p_Distributor_Name, string p_Ip_Address)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectDISTRIBUTOR { 
                    Connection = connection, DIST_CLASS_ID = p_Dist_Class_Id, TIME_STAMP = Constants.DateNullValue, LASTUPDATE_DATE = Constants.DateNullValue, DIVISION_ID = p_Division_Id, USER_ID = p_User_Id, REGION_ID = p_Region_Id, ZONE_ID = p_Zone_Id, SUBZONE_ID = p_SubZone_Id, CONTACT_PERSON = p_Contact_Person, CONTACT_NUMBER = p_Contact_Number, GST_NUMBER = p_Gst_Number, PASSWORD = p_Password, ADDRESS1 = p_Address1, ADDRESS2 = p_Address2, DISTRIBUTOR_ID = p_Distributor_Id, 
                    DISTRIBUTOR_CODE = p_Distributor_Code, DISTRIBUTOR_NAME = p_Distributor_Name, IP_ADDRESS = p_Ip_Address, CREDIT_LEVEL = -2147483648
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

        public DataTable SelectRole_Master(DateTime p_Time_Stamp, DateTime p_Lastupdate_Date, int p_Role_Id, string p_Role_Name, string p_Ip_Address)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                spSelectROLE_MASTER trole_master = new spSelectROLE_MASTER {
                    Connection = connection,
                    LASTUPDATE_DATE = p_Lastupdate_Date,
                    ROLE_ID = p_Role_Id,
                    TIME_STAMP = p_Time_Stamp,
                    ROLE_NAME = p_Role_Name
                };
                DataTable table = new DataTable();
                table2 = trole_master.ExecuteTable();
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

        public static DataTable SelectTranspoter()
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectTRANSPOTER { Connection = connection }.ExecuteTable();
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

        public DataTable SelectUser_Role_Info(int p_Distributor_Id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                uspSelectUserRoleInfo info = new uspSelectUserRoleInfo {
                    Connection = connection,
                    DISTRIBUTOR_ID = p_Distributor_Id
                };
                DataTable table = new DataTable();
                table2 = info.ExecuteTable();
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

        public string UpdateDistributor(int p_CompanyId, int p_Dist_Class_Id, bool p_IsDeleted, DateTime p_Time_Stamp, DateTime p_LastUpdate_Date, int p_Division_Id, int p_User_Id, int p_Region_Id, int p_Zone_Id, int p_SubZone_Id, string p_Contact_Person, string p_Contact_Number, string p_Gst_Number, string p_Password, string p_Address1, string p_Address2, int p_Distributor_Id, string p_Distributor_Code, string p_Distributor_Name, string p_Ip_Address, bool p_Is_Registered, int p_CREDIT_LEVEL, int p_UserId)
        {
            IDbConnection connection = null;
            string str;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spUpdateDISTRIBUTOR { 
                    Connection = connection, COMPANY_ID = p_CompanyId, DIST_CLASS_ID = p_Dist_Class_Id, TIME_STAMP = p_Time_Stamp, LASTUPDATE_DATE = p_LastUpdate_Date, DIVISION_ID = p_Division_Id, USER_ID = p_User_Id, REGION_ID = p_Region_Id, ZONE_ID = p_Zone_Id, SUBZONE_ID = p_SubZone_Id, CREDIT_LEVEL = p_CREDIT_LEVEL, CONTACT_PERSON = p_Contact_Person, CONTACT_NUMBER = p_Contact_Number, GST_NUMBER = p_Gst_Number, PASSWORD = p_Password, ADDRESS1 = p_Address1, 
                    ADDRESS2 = p_Address2, DISTRIBUTOR_ID = p_Distributor_Id, DISTRIBUTOR_CODE = p_Distributor_Code, DISTRIBUTOR_NAME = p_Distributor_Name, IP_ADDRESS = p_Ip_Address, IS_REGISTERED = p_Is_Registered, ISDELETED = p_IsDeleted
                 }.ExecuteQuery();
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

        public string UpdateDistributor_User(bool p_Is_Ppc_Login, bool p_Is_Distributor_Login, bool p_Is_Active, bool p_Is_Deleted, DateTime p_Time_Stamp, DateTime p_Lastupdate_Date, int p_User_Type_Id, long p_Town_Id, int p_C_User_Id, int p_Region_Id, int p_Zone_Id, int p_Subzone_Id, int p_Distributor_Id, int p_Division_Id, int p_Role_Id, string p_Email_Address, string p_Address1, string p_Address2, string p_Login_Id, string p_Password, string p_Fax, string p_Mobile, string p_User_Code, string p_User_Name, string p_Phone, int p_User_Id, long p_Route_Id)
        {
            IDbConnection connection = null;
            string str;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spUpdateDISTRIBUTOR_USER { 
                    Connection = connection, ADDRESS1 = p_Address1, ADDRESS2 = p_Address2, DISTRIBUTOR_ID = p_Distributor_Id, EMAIL = p_Email_Address, IS_ACTIVE = p_Is_Active, LASTUPDATE_DATE = p_Lastupdate_Date, LOGIN_ID = p_Login_Id, MOBILE = p_Mobile, PASSWORD = p_Password, PHONE = p_Phone, ROLE_ID = p_Role_Id, TIME_STAMP = p_Time_Stamp, USER_CODE = p_User_Code, USER_ID = p_User_Id, USER_NAME = p_User_Name, 
                    USER_TYPE_ID = p_User_Type_Id
                 }.ExecuteQuery();
                str = p_User_Id.ToString();
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

        public string UpdateDistributor_User_Territory(DateTime p_Time_Stamp, DateTime p_Lastupdate_Date, int p_User_Id, int p_Territory_Id, int p_Distributor_Id)
        {
            IDbConnection connection = null;
            string str;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spUpdateDISTRIBUTOR_USER_TERRITORY { Connection = connection, DISTRIBUTOR_ID = p_Distributor_Id, LASTUPDATE_DATE = p_Lastupdate_Date, TERRITORY_ID = p_Territory_Id, TIME_STAMP = p_Time_Stamp, USER_ID = p_User_Id }.ExecuteQuery();
                str = p_User_Id.ToString();
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

        public string UpdateSalesForceType(int p_SalesForceId, int p_SalesForceTypeId)
        {
            IDbConnection connection = null;
            string str;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new uspUpdateSALES_FORCE_TYPE { Connection = connection, SALES_FORCE_ID = p_SalesForceId, SALES_FORCE_TYPE = p_SalesForceTypeId }.ExecuteQuery();
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
    }
}

