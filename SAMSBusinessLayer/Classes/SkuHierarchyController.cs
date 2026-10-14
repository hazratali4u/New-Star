namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class SkuHierarchyController
    {
        public void DeleteAssignBrand(int p_companyId, int p_UserId)
        {
            IDbConnection connection = null;
            try
            {
                try
                {
                    connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                    connection.Open();
                    new spDeleteBRAND_ASSIGNMENT { Connection = connection, PRINCIPAL_ID = p_companyId, USER_ID = p_UserId }.ExecuteQuery();
                }
                catch (Exception exception)
                {
                    ExceptionPublisher.PublishException(exception);
                }
            }
            finally
            {
            }
        }

        public string DeleteHierarchy(int p_Sku_Hie_Id)
        {
            IDbConnection connection = null;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spDeleteSKU_HIERARCHY { Connection = connection, SKU_HIE_ID = p_Sku_Hie_Id }.ExecuteQuery();
                return "Record Deleted";
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                return exception.Message;
            }
        }

        public int GetHieID(string p_Sku_Hie_Code, int Companyid)
        {
            int num2;
            int num = 0;
            IDbConnection connection = null;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                DataTable table = new spSelectSKU_HIERARCHY { Connection = connection, SKU_HIE_TYPE_ID = -2147483648, SKU_HIE_ID = -2147483648, PARENT_SKU_HIE_ID = -2147483648, SKU_HIE_CODE = p_Sku_Hie_Code, SKU_HIE_NAME = null, TIME_STAMP = Constants.DateNullValue, LASTUPDATE_DATE = Constants.DateNullValue, IP_ADDRESS = null, COMPANY_ID = Companyid }.ExecuteTable();
                if (table.Rows.Count > 0)
                {
                    num = int.Parse(table.Rows[0]["SKU_HIE_ID"].ToString());
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

        public void InsertAssignBrand(int p_companyId, int p_UserId)
        {
            IDbConnection connection = null;
            try
            {
                try
                {
                    connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                    connection.Open();
                    new spInsertBRAND_ASSIGNMENT { Connection = connection, PRINCIPAL_ID = p_companyId, USER_ID = p_UserId }.ExecuteQuery();
                }
                catch (Exception exception)
                {
                    ExceptionPublisher.PublishException(exception);
                }
            }
            finally
            {
            }
        }

        public string InsertHierarchy(int p_Sku_Type_Id, int p_Parent_Sku_Hie_Id, string p_Sku_Hie_Code, string p_Sku_Hie_Name, string p_Ip_Address, bool p_Is_Active, int Companyid)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spInsertSKU_HIERARCHY { Connection = connection, SKU_HIE_TYPE_ID = p_Sku_Type_Id, PARENT_SKU_HIE_ID = p_Parent_Sku_Hie_Id, SKU_HIE_CODE = p_Sku_Hie_Code, SKU_HIE_NAME = p_Sku_Hie_Name, TIME_STAMP = DateTime.Now, LASTUPDATE_DATE = DateTime.Now, IP_ADDRESS = p_Ip_Address, IS_ACTIVE = p_Is_Active, COMPANY_ID = Companyid, IS_MANUALDISCOUNT = false }.ExecuteQuery();
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

        public string InsertHierarchy(int p_Sku_Type_Id, int p_Parent_Sku_Hie_Id, string p_Sku_Hie_Code, string p_Sku_Hie_Name, string p_Ip_Address, bool p_Is_Active, int Companyid, bool p_IsManualDiscount)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spInsertSKU_HIERARCHY { Connection = connection, SKU_HIE_TYPE_ID = p_Sku_Type_Id, PARENT_SKU_HIE_ID = p_Parent_Sku_Hie_Id, SKU_HIE_CODE = p_Sku_Hie_Code, SKU_HIE_NAME = p_Sku_Hie_Name, TIME_STAMP = DateTime.Now, LASTUPDATE_DATE = DateTime.Now, IP_ADDRESS = p_Ip_Address, IS_ACTIVE = p_Is_Active, COMPANY_ID = Companyid, IS_MANUALDISCOUNT = p_IsManualDiscount }.ExecuteQuery();
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

        public DataTable SelectBrandAssignment(int p_type, int p_UserId)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                UspGetBrandAssignment assignment = new UspGetBrandAssignment {
                    Connection = connection,
                    TYPE_ID = p_type,
                    USER_ID = p_UserId
                };
                DataTable table = new DataTable();
                table2 = assignment.ExecuteTable();
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

        public DataTable SelectDTSkuHierarchy(int p_Sku_Type_Id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                spSelectSKU_HIERARCHY tsku_hierarchy = new spSelectSKU_HIERARCHY {
                    Connection = connection,
                    SKU_HIE_TYPE_ID = p_Sku_Type_Id
                };
                DataTable table = new DataTable();
                table2 = tsku_hierarchy.ExecuteTable();
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

        public DataTable SelectDTSkuHierarchy(int p_Sku_Type_Id, int p_Parent_Sku_Hie_Id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectSKU_HIERARCHY { Connection = connection, SKU_HIE_TYPE_ID = p_Sku_Type_Id, PARENT_SKU_HIE_ID = p_Parent_Sku_Hie_Id }.ExecuteTable();
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

        public DataTable SelectDTSkuHierarchy01(int p_type, int p_company, int p_division, int p_category, int p_brand, int Companyid)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                UspSelectView_SKUHIERARCHY w_skuhierarchy = new UspSelectView_SKUHIERARCHY {
                    Connection = connection,
                    type = p_type,
                    Company_id = p_company,
                    Division_id = p_division,
                    Category_Id = p_category,
                    Brand_Id = p_brand,
                    MCompany_id = Companyid
                };
                DataTable table = new DataTable();
                table2 = w_skuhierarchy.ExecuteTable();
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

        public DataTable SelectSkuHierarchy(int p_Sku_Type_Hie_Id, int Companyid)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectSKU_HIERARCHY { Connection = connection, SKU_HIE_TYPE_ID = p_Sku_Type_Hie_Id, COMPANY_ID = Companyid }.ExecuteTable();
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

        public DataTable SelectSkuHierarchy(int p_Sku_Type_Id, int p_Parent_Sku_Hie_Id, int Companyid)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectSKU_HIERARCHY { Connection = connection, SKU_HIE_TYPE_ID = p_Sku_Type_Id, PARENT_SKU_HIE_ID = p_Parent_Sku_Hie_Id, COMPANY_ID = Companyid }.ExecuteTable();
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

        public DataTable SelectSkuHierarchy(string p_Sku_Hie_Id, int p_Sku_Type_Id, int Companyid)
        {
            IDbConnection connection = null;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                spSelectSKU_HIERARCHY tsku_hierarchy = new spSelectSKU_HIERARCHY {
                    Connection = connection,
                    SKU_HIE_TYPE_ID = p_Sku_Type_Id,
                    SKU_HIE_ID = int.Parse(p_Sku_Hie_Id),
                    COMPANY_ID = Companyid
                };
                return tsku_hierarchy.ExecuteTable();
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                return null;
            }
        }

        public DataTable SelectSkuHierarchy(int p_Sku_Type_Id, int p_Sku_Hie_Id, int p_Parent_Sku_Hie_Id, string p_Sku_Hie_Code, string p_Sku_Hie_Name, bool p_Is_Active, int Companyid)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectSKU_HIERARCHY { Connection = connection, SKU_HIE_TYPE_ID = p_Sku_Type_Id, SKU_HIE_ID = p_Sku_Hie_Id, PARENT_SKU_HIE_ID = p_Parent_Sku_Hie_Id, SKU_HIE_CODE = p_Sku_Hie_Code, SKU_HIE_NAME = p_Sku_Hie_Name, TIME_STAMP = Constants.DateNullValue, LASTUPDATE_DATE = Constants.DateNullValue, IP_ADDRESS = null, IS_ACTIVE = p_Is_Active, COMPANY_ID = Companyid }.ExecuteTable();
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

        public DataTable SelectSkuHierarchyInfo(int p_Sku_Hie_Id, int p_Sku_Type_Id, int Companyid)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectSKU_HIERARCHY_INFO { Connection = connection, SKU_HIE_ID = p_Sku_Hie_Id, SKU_HIE_TYPE_ID = p_Sku_Type_Id, COMPANY_ID = Companyid }.ExecuteTable();
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

        public DataTable SelectSkuHierarchyView(int p_type, int CompanyId)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new UspSelectView_SKUHIERARCHY { Connection = connection, MCompany_id = CompanyId, type = p_type }.ExecuteTable();
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

        public string UpdateHierarchy(int p_Sku_Type_Id, int p_Sku_Hie_Id, int p_Parent_Sku_Hie_Id, string p_Sku_Hie_Code, string p_Sku_Hie_Name, string p_Ip_Address, bool p_Is_Active, int Companyid)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spUpdateSKU_HIERARCHY { Connection = connection, SKU_HIE_TYPE_ID = p_Sku_Type_Id, SKU_HIE_ID = p_Sku_Hie_Id, PARENT_SKU_HIE_ID = p_Parent_Sku_Hie_Id, SKU_HIE_CODE = p_Sku_Hie_Code, SKU_HIE_NAME = p_Sku_Hie_Name, TIME_STAMP = DateTime.Now, LASTUPDATE_DATE = DateTime.Now, IP_ADDRESS = p_Ip_Address, IS_ACTIVE = p_Is_Active, COMPANY_ID = Companyid, IS_MANUALDISCOUNT = false }.ExecuteQuery();
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

        public string UpdateHierarchy(int p_Sku_Type_Id, int p_Sku_Hie_Id, int p_Parent_Sku_Hie_Id, string p_Sku_Hie_Code, string p_Sku_Hie_Name, string p_Ip_Address, bool p_Is_Active, int Companyid, bool p_IsManualDiscount)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spUpdateSKU_HIERARCHY { Connection = connection, SKU_HIE_TYPE_ID = p_Sku_Type_Id, SKU_HIE_ID = p_Sku_Hie_Id, PARENT_SKU_HIE_ID = p_Parent_Sku_Hie_Id, SKU_HIE_CODE = p_Sku_Hie_Code, SKU_HIE_NAME = p_Sku_Hie_Name, TIME_STAMP = DateTime.Now, LASTUPDATE_DATE = DateTime.Now, IP_ADDRESS = p_Ip_Address, IS_ACTIVE = p_Is_Active, COMPANY_ID = Companyid, IS_MANUALDISCOUNT = p_IsManualDiscount }.ExecuteQuery();
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

