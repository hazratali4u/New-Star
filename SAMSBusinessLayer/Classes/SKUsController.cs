namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class SKUsController
    {
        public int GetSKU_ID(string p_SKU_Code)
        {
            int num2;
            int num = 0;
            IDbConnection connection = null;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                DataTable table = new uspSelectSkusByCode { Connection = connection, SKU_Code = p_SKU_Code }.ExecuteTable();
                if (table.Rows.Count > 0)
                {
                    num = int.Parse(table.Rows[0]["SKU_ID"].ToString());
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

        public decimal GetSkuGst(int p_SKU_id, int p_dist_id)
        {
            decimal num2;
            IDbConnection connection = null;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                object obj2 = new uspSelectDistributorSkuGst { Connection = connection, distributor_id = p_dist_id, sku_id = p_SKU_id }.ExecuteScalar();
                if (obj2 != null)
                {
                    return decimal.Parse(obj2.ToString());
                }
                num2 = 0M;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                num2 = 0M;
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

        public string InsertSKUS(bool p_IsExempted, bool p_IsActive, char p_Gst_On, int p_Company_Id, int p_Division_Id, int p_Category_Id, int p_Brand_Id, int p_Variant_Id, decimal p_GST_Rate_Reg, decimal p_GST_Rate_Unreg, short p_Units_In_Case, string p_Sku_Code, string p_Sku_Name, string p_Ip_Address, string p_packSize, int p_UserId, int Companyid)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                spInsertSKUS tskus = new spInsertSKUS {
                    Connection = connection,
                    PRINCIPAL_ID = p_Company_Id,
                    ISEXEMPTED = p_IsExempted,
                    ISACTIVE = p_IsActive,
                    GST_ON = p_Gst_On,
                    COMPANY_ID = Companyid,
                    DIVISION_ID = p_Division_Id,
                    BRAND_ID = p_Brand_Id,
                    CATEGORY_ID = p_Category_Id
                };
                if (!p_IsExempted)
                {
                    tskus.GST_RATE_REG = p_GST_Rate_Reg;
                    tskus.GST_RATE_UNREG = p_GST_Rate_Unreg;
                }
                else
                {
                    tskus.GST_RATE_REG = 0M;
                    tskus.GST_RATE_UNREG = 0M;
                }
                tskus.UNITS_IN_CASE = p_Units_In_Case;
                tskus.SKU_NAME = p_Sku_Name;
                tskus.SKU_CODE = p_Sku_Code;
                tskus.TIME_STAMP = DateTime.Now;
                tskus.LASTUPDATE_DATE = DateTime.Now;
                tskus.IP_ADDRESS = p_Ip_Address;
                tskus.PACKSIZE = p_packSize;
                tskus.USER_ID = p_UserId;
                tskus.ExecuteQuery();
                message = tskus.SKU_ID.ToString();
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

        public DataTable SelectSKUPrices(int p_Sku_Id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectSKU_PRICES { Connection = connection, SKU_ID = p_Sku_Id, DISTRIBUTOR_PRICE = -79228162514264337593543950335M, LASTUPDATE_DATE = Constants.DateNullValue, RETAIL_PRICE = -79228162514264337593543950335M, SKU_PRICE_ID = -2147483648, TAX_PRICE = -79228162514264337593543950335M, TIME_STAMP = Constants.DateNullValue, TRADE_PRICE = -79228162514264337593543950335M, UOM_ID = -2147483648 }.ExecuteTable();
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


        public string UpdateSKUS(bool p_IsExempted, bool p_IsActive, char p_Gst_On, int p_Company_Id, int p_Division_Id, int p_Category_Id, int p_Brand_Id, int p_Variant_Id, decimal p_GST_Rate_Reg, decimal p_GST_Rate_Unreg, short p_Units_In_Case, int p_Sku_Id, string p_Sku_Code, string p_Sku_Name, string p_Ip_Address, string p_packSize, int p_UserId, int CompanyId)
        {
            IDbConnection connection = null;
            string str;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                spUpdateSKUS eskus = new spUpdateSKUS {
                    Connection = connection,
                    ISEXEMPTED = p_IsExempted,
                    ISACTIVE = p_IsActive,
                    GST_ON = p_Gst_On,
                    COMPANY_ID = CompanyId,
                    PRINCIPAL_ID = p_Company_Id,
                    DIVISION_ID = p_Division_Id,
                    BRAND_ID = p_Brand_Id,
                    CATEGORY_ID = p_Category_Id
                };
                if (!p_IsExempted)
                {
                    eskus.GST_RATE_REG = p_GST_Rate_Reg;
                    eskus.GST_RATE_UNREG = p_GST_Rate_Unreg;
                }
                else
                {
                    eskus.GST_RATE_REG = 0M;
                    eskus.GST_RATE_UNREG = 0M;
                }
                eskus.UNITS_IN_CASE = p_Units_In_Case;
                eskus.SKU_ID = p_Sku_Id;
                eskus.SKU_NAME = p_Sku_Name;
                eskus.SKU_CODE = p_Sku_Code;
                eskus.TIME_STAMP = DateTime.Now;
                eskus.LASTUPDATE_DATE = DateTime.Now;
                eskus.IP_ADDRESS = p_Ip_Address;
                eskus.PACKSIZE = p_packSize;
                eskus.USER_ID = p_UserId;
                eskus.ExecuteQuery();
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

