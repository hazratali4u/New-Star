namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class AccountHeadController
    {
        public string InsertAccountHead(int p_Company_id, bool p_Is_Active, DateTime p_Time_Stamp, int p_Distributor_Id, int p_Account_Type_Id, long p_Account_Parent_id, string p_Account_Name, string p_Account_Code)
        {
            IDbConnection connection = null;
            string str;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                spInsertACCOUNT_HEAD taccount_head = new spInsertACCOUNT_HEAD {
                    Connection = connection,
                    COMPANY_ID = p_Company_id,
                    DISTRIBUTOR_ID = p_Distributor_Id,
                    ACCOUNT_TYPE_ID = p_Account_Type_Id,
                    ACCOUNT_PARENT_ID = p_Account_Parent_id,
                    ACCOUNT_NAME = p_Account_Name,
                    ACCOUNT_CODE = p_Account_Code,
                    IS_ACTIVE = p_Is_Active,
                    TIME_STAMP = p_Time_Stamp
                };
                taccount_head.ExecuteQuery();
                str = taccount_head.ACCOUNT_HEAD_ID.ToString();
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

        public DataTable SelectAccountHead(int p_Account_Type_Id, long p_Account_ParentId)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectACCOUNT_HEAD { Connection = connection, DISTRIBUTOR_ID = -2147483648, ACCOUNT_HEAD_ID = -9223372036854775808L, ACCOUNT_PARENT_ID = p_Account_ParentId, COMPANY_ID = -9223372036854775808L, ACCOUNT_TYPE_ID = p_Account_Type_Id, IS_ACTIVE = true, TIME_STAMP = Constants.DateNullValue, LASTUPDATE_DATE = Constants.DateNullValue }.ExecuteTable();
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

        public DataTable SelectAccountHead(int p_CompnayId, int p_Account_Head, int p_Account_Type_Id, int p_Account_ParentId)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new UspSelectAccountHead { Connection = connection, COMPANY_ID = p_CompnayId, ACCOUNT_TYPE_ID = p_Account_Type_Id, ACCOUNT_PARENT_ID = p_Account_ParentId, ACCOUNT_HEAD_ID = p_Account_Head }.ExecuteTable();
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

        public DataTable SelectAccountHeadInfo(long p_Account_Head_Id, long p_Customer_Id, bool p_Is_Active, DateTime p_Time_Stamp, DateTime p_Lastupdate_Date, int p_Distributor_Id, int p_Account_Type_Id, decimal p_Balance, string p_Account_Name)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectACCOUNT_HEAD { Connection = connection, ACCOUNT_HEAD_ID = p_Account_Head_Id, ACCOUNT_NAME = p_Account_Name, ACCOUNT_TYPE_ID = p_Account_Type_Id, BALANCE = p_Balance, CUSTOMER_ID = p_Customer_Id, DISTRIBUTOR_ID = p_Distributor_Id, IS_ACTIVE = p_Is_Active, TIME_STAMP = Constants.DateNullValue, LASTUPDATE_DATE = Constants.DateNullValue }.ExecuteTable();
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

        public DataTable SelectClaimHead(int p_Account_Type_Id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new GetClaimHead { Connection = connection, SUB_TYPE_ID = p_Account_Type_Id }.ExecuteTable();
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

        public string UpdateAccountHead(long p_Account_Head_Id, long p_Company_Id, bool p_Is_Active, DateTime p_Time_Stamp, int p_Distributor_Id, int p_Account_Type_Id, long p_Account_ParentId, string p_Account_Name, string p_Account_Code)
        {
            IDbConnection connection = null;
            string str;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                spUpdateACCOUNT_HEAD eaccount_head = new spUpdateACCOUNT_HEAD {
                    Connection = connection,
                    ACCOUNT_HEAD_ID = p_Account_Head_Id,
                    ACCOUNT_NAME = p_Account_Name,
                    ACCOUNT_CODE = p_Account_Code,
                    ACCOUNT_TYPE_ID = p_Account_Type_Id,
                    DISTRIBUTOR_ID = p_Distributor_Id,
                    COMPANY_ID = p_Company_Id,
                    ACCOUNT_PARENT_ID = p_Account_ParentId,
                    IS_ACTIVE = p_Is_Active,
                    TIME_STAMP = p_Time_Stamp,
                    LASTUPDATE_DATE = p_Time_Stamp
                };
                eaccount_head.ExecuteQuery();
                str = eaccount_head.ACCOUNT_HEAD_ID.ToString();
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

