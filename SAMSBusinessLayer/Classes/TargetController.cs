namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class TargetController
    {
        public bool CalculateTargetsAchieved(DateTime p_TargetMonth, DateTime p_Today, int p_Distributor_Id)
        {
            IDbConnection connection = null;
            bool flag;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new uspCalculateTargetsAchieved { Connection = connection, TARGET_MONTH = p_TargetMonth, TODAY = p_Today, DISTRIBUTOR_ID = p_Distributor_Id }.ExecuteQuery();
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

        public string InsertTarget(int p_DistributorId, DateTime p_TargetMonth, int p_TargetForTypeId, int p_TargetForId, int p_SKUId, decimal p_SKUUnitPrice, int p_Qty, int p_PrincipalId, int p_UserId)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spInsertTARGET { Connection = connection, DISTRIBUTOR_ID = p_DistributorId, TARGET_MONTH = p_TargetMonth, TARGET_FOR_TYPE_ID = p_TargetForTypeId, TARGET_FOR_ID = p_TargetForId, SKU_ID = p_SKUId, UNIT_PRICE = p_SKUUnitPrice, QUANTITY = p_Qty, USER_ID = p_UserId, PRINCIPAL_ID = p_PrincipalId, IS_ACTIVE = true }.ExecuteQuery();
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

        public DataTable SelectTarget(DateTime p_TargetMonth, int p_Target_For_Type_Id, int p_Target_For_Id, int p_Distributor_Id, int p_PrincipalId)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectTARGETInfo { Connection = connection, TARGET_MONTH = p_TargetMonth, TARGET_FOR_TYPE_ID = p_Target_For_Type_Id, TARGET_FOR_ID = p_Target_For_Id, DISTRIBUTOR_ID = p_Distributor_Id, PRINCIPAL_ID = p_PrincipalId }.ExecuteTable();
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

        public string UpdateTarget(long p_TargetId, int p_Distributor, decimal p_SKUUnitPrice, int p_Qty, bool p_IS_ACTIVE)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spUpdateTARGET { Connection = connection, TARGET_ID = p_TargetId, DISTRIBUTOR_ID = p_Distributor, TARGET_MONTH = Constants.DateNullValue, TARGET_FOR_TYPE_ID = -2147483648, TARGET_FOR_ID = -9223372036854775808L, SKU_ID = -9223372036854775808L, UNIT_PRICE = p_SKUUnitPrice, QUANTITY = p_Qty, IS_ACTIVE = p_IS_ACTIVE }.ExecuteQuery();
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

