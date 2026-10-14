namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class ControllerDistributorType
    {
        public string InsertDistributorType(string I_TYPECODE, string I_TYPENAME, bool I_ISDELETED)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                spInsertDISTRIBUTOR_TYPE tdistributor_type = new spInsertDISTRIBUTOR_TYPE {
                    Connection = connection,
                    TYPECODE = I_TYPECODE,
                    TYPENAME = I_TYPENAME,
                    ISDELETED = false
                };
                tdistributor_type.ExecuteQuery();
                message = tdistributor_type.DISTRIBUTOR_TYPE_ID.ToString();
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

        public string InsertSkuPrice_PS(int typeid, int distributor_type_Id, int Sku_id, decimal SkuPrice, string p_packsize, string p_articaleno)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new UspUpdateSku_Price_PS { Connection = connection, type = typeid, Distributor_type_Id = distributor_type_Id, Sku_ID = Sku_id, Price = SkuPrice, packSize = p_packsize, articaleno = p_articaleno }.ExecuteQuery();
                message = "Record Update";
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

        public DataTable SelectDistributorPSPrice(int Distributortype_Id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                table2 = new UspSelectDistributor_SkuPrice { Connection = connection, DISTRIBUTOR_TYPE_ID = Distributortype_Id, SKU_ID = -2147483648, ISCURRETN = 1 }.ExecuteTable();
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

        public DataTable SelectDistributorPSPrice(int Distributortype_Id, int p_Iscurrent, int p_sku_id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                table2 = new UspSelectDistributor_SkuPrice { Connection = connection, DISTRIBUTOR_TYPE_ID = Distributortype_Id, ISCURRETN = p_Iscurrent, SKU_ID = p_sku_id }.ExecuteTable();
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

        public DataTable SelectDistributorType(int p_Distributor_Type_ID)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectDISTRIBUTOR_TYPE { Connection = connection, DISTRIBUTOR_TYPE_ID = p_Distributor_Type_ID, ISDELETED = 0, TYPECODE = null, TYPENAME = null }.ExecuteTable();
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

        public DataTable SelectDistributorType(string DTypeCode)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                table2 = new spSelectDISTRIBUTOR_TYPE { Connection = connection, DISTRIBUTOR_TYPE_ID = -2147483648, TYPECODE = DTypeCode, TYPENAME = null, ISDELETED = 0 }.ExecuteTable();
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

        public string UpdateDistributorType(int U_typeId, string U_TYPECODE, string U_TYPENAME, bool U_ISDELETED)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                spUpdateDISTRIBUTOR_TYPE edistributor_type = new spUpdateDISTRIBUTOR_TYPE {
                    Connection = connection,
                    DISTRIBUTOR_TYPE_ID = U_typeId,
                    TYPECODE = U_TYPECODE,
                    TYPENAME = U_TYPENAME,
                    ISDELETED = U_ISDELETED
                };
                edistributor_type.ExecuteQuery();
                message = edistributor_type.DISTRIBUTOR_TYPE_ID.ToString();
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

        public string updateSkuPrice_PS(int typeid, int distributor_type_Id, int Sku_id, decimal SkuPrice, string p_packsize, string p_articaleno, int p_SKUPRICE_PS_ID)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new UspUpdateSku_Price_PS { Connection = connection, type = typeid, Distributor_type_Id = distributor_type_Id, Sku_ID = Sku_id, Price = SkuPrice, packSize = p_packsize, articaleno = p_articaleno, SKUPRICE_PS_ID = p_SKUPRICE_PS_ID }.ExecuteQuery();
                message = "Record Update";
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

