namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class GeoHierarchyController
    {
        public string InsertHierarchy(int p_Parent_Geo_Id, string p_Geo_Code, string p_Geo_Name, bool p_Is_Current, bool p_Is_Deleted, int p_Status, int p_Company_Id, int p_Geo_Type_Id, int p_User_Id, int p_Distributor_Id, string p_Ip_Address)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                spInsertGEO_HIERARCHY tgeo_hierarchy = new spInsertGEO_HIERARCHY {
                    Connection = connection,
                    PARENT_GEO_ID = p_Parent_Geo_Id,
                    GEO_CODE = p_Geo_Code,
                    GEO_NAME = p_Geo_Name,
                    ISCURRENT = p_Is_Current,
                    ISDELETED = p_Is_Deleted,
                    STATUS = p_Status,
                    COMPANY_ID = p_Company_Id,
                    GEO_TYPE_ID = p_Geo_Type_Id,
                    USER_ID = p_User_Id,
                    TIME_STAMP = DateTime.Now,
                    LASTUPDATE_DATE = DateTime.Now,
                    DISTRIBUTOR_ID = p_Distributor_Id,
                    IP_ADDRESS = p_Ip_Address
                };
                if (tgeo_hierarchy.ExecuteQuery())
                {
                    return "Record Inserted";
                }
                message = "Record Inserted";
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

        public DataTable SelectAssignTown(int p_PARAENT_ID, int p_DISTRIBUTOR_ID, int TypeId)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new UspGetAssignTown { Connection = connection, PARENT_ID = p_PARAENT_ID, DISTRIBUTOR_ID = p_DISTRIBUTOR_ID, TYPE = TypeId }.ExecuteTable();
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

        public DataTable SelectDistributorHierachyWithType(int typeid, int Locationtype, string TownId)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new UspSelectView_GeoHIERARCHY { Connection = connection, type = typeid, Paraid = Locationtype, ZoneId = -2147483648, TerritoryId = -2147483648, TownId = TownId }.ExecuteTable();
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

        public DataTable SelectGeoHierarchy(int p_DISTRIBUTOR_ID)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectDistributor_TOWN { Connection = connection, DISTRIBUTOR_ID = p_DISTRIBUTOR_ID }.ExecuteTable();
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

        public DataTable SelectGeoHierarchy(int p_geo_id, int p_DISTRIBUTOR_ID, int p_PARENT_GEO_ID, string p_GEO_CODE, string p_GEO_NAME, bool p_Is_Deleted, int p_STATUS, int p_GEO_TYPE_ID, int p_USER_ID, DateTime p_TIME_STAMP, DateTime p_LASTUPDATE_DATE, int Companyid)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                spSelectGEO_HIERARCHY tgeo_hierarchy = new spSelectGEO_HIERARCHY {
                    Connection = connection,
                    GEO_ID = p_geo_id,
                    PARENT_GEO_ID = p_PARENT_GEO_ID,
                    GEO_CODE = p_GEO_CODE,
                    GEO_NAME = p_GEO_NAME,
                    COMPANY_ID = Companyid,
                    ISCURRENT = -2147483648
                };
                if (p_Is_Deleted)
                {
                    tgeo_hierarchy.ISDELETED = 1;
                }
                else
                {
                    tgeo_hierarchy.ISDELETED = 0;
                }
                tgeo_hierarchy.STATUS = p_STATUS;
                tgeo_hierarchy.COMPANY_ID = Companyid;
                tgeo_hierarchy.GEO_TYPE_ID = p_GEO_TYPE_ID;
                tgeo_hierarchy.USER_ID = -2147483648;
                tgeo_hierarchy.TIME_STAMP = Constants.DateNullValue;
                tgeo_hierarchy.LASTUPDATE_DATE = Constants.DateNullValue;
                tgeo_hierarchy.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                tgeo_hierarchy.IP_ADDRESS = null;
                table2 = tgeo_hierarchy.ExecuteTable();
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

        public DataTable SelectGeoHierarchyData(int p_Brand_id, int p_sku_type_id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new UspGetDataGeohierarchy { Connection = connection, Brand_id = p_Brand_id, SKU_Hie_type_id = p_sku_type_id }.ExecuteTable();
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

        public string UpdateHierarchy(int p_Geo_Id, int p_Parent_Geo_Id, string p_Geo_Code, string p_Geo_Name, bool p_Is_Current, bool p_Is_Deleted, int p_Status, int p_Company_Id, int p_Geo_Type_Id, int p_User_Id, int p_Distributor_Id, string p_Ip_Address)
        {
            IDbConnection connection = null;
            string str;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spUpdateGEO_HIERARCHY { Connection = connection, GEO_ID = p_Geo_Id, PARENT_GEO_ID = p_Parent_Geo_Id, GEO_CODE = p_Geo_Code, GEO_NAME = p_Geo_Name, ISCURRENT = p_Is_Current, ISDELETED = p_Is_Deleted, STATUS = p_Status, COMPANY_ID = p_Company_Id, GEO_TYPE_ID = p_Geo_Type_Id, USER_ID = p_User_Id, TIME_STAMP = DateTime.Now, LASTUPDATE_DATE = DateTime.Now, DISTRIBUTOR_ID = p_Distributor_Id, IP_ADDRESS = p_Ip_Address }.ExecuteQuery();
                str = "Record Updated";
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                str = "Record Updated";
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

