namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class ApprovalHierarchyController
    {
        public string InsertApprovalHierarchy(int p_Claim_Type_Id, int p_First_Approval, int p_Second_Approval, int p_Third_Approval, int p_Forth_Approval, string p_Ip_Address, int p_User_Id, int p_Distributor_Id)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spInsertAPPROVAL_HIERARCHY { Connection = connection, CLAIM_TYPE_ID = p_Claim_Type_Id, FIRST_APPROVAL = p_First_Approval, SECOND_APPROVAL = p_Second_Approval, THIRD_APPROVAL = p_Third_Approval, FOURTH_APPROVAL = p_Forth_Approval, LASTUPDATE_DATE = DateTime.Now, TIME_STAMP = DateTime.Now, IP_ADDRESS = p_Ip_Address, USER_ID = p_User_Id, DISTRIBUTOR_ID = p_Distributor_Id }.ExecuteQuery();
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

        public DataTable SelectApprovalHierarchy(int p_Approval_Hierarchy_Id, int p_Claim_Type_Id, int p_First_Approval, int p_Second_Approval, int p_Third_Approval, int p_Forth_Approval, string p_Ip_Address, int p_User_Id, int p_Distributor_Id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectAPPROVAL_HIERARCHY { Connection = connection, APPROVAL_HIERARCHY_ID = p_Approval_Hierarchy_Id, CLAIM_TYPE_ID = p_Claim_Type_Id, FIRST_APPROVAL = p_First_Approval, SECOND_APPROVAL = p_Second_Approval, THIRD_APPROVAL = p_Third_Approval, FOURTH_APPROVAL = p_Forth_Approval, LASTUPDATE_DATE = Constants.DateNullValue, TIME_STAMP = Constants.DateNullValue, IP_ADDRESS = p_Ip_Address, USER_ID = p_User_Id, DISTRIBUTOR_ID = p_Distributor_Id }.ExecuteTable();
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

        public string UpdateApprovalHierarchy(int p_Approval_Hierarchy_Id, int p_Claim_Type_Id, int p_First_Approval, int p_Second_Approval, int p_Third_Approval, int p_Forth_Approval, string p_Ip_Address, int p_User_Id, int p_Distributor_Id)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spUpdateAPPROVAL_HIERARCHY { Connection = connection, APPROVAL_HIERARCHY_ID = p_Approval_Hierarchy_Id, CLAIM_TYPE_ID = p_Claim_Type_Id, FIRST_APPROVAL = p_First_Approval, SECOND_APPROVAL = p_Second_Approval, THIRD_APPROVAL = p_Third_Approval, FOURTH_APPROVAL = p_Forth_Approval, LASTUPDATE_DATE = DateTime.Now, TIME_STAMP = DateTime.Now, IP_ADDRESS = p_Ip_Address, USER_ID = p_User_Id, DISTRIBUTOR_ID = p_Distributor_Id }.ExecuteQuery();
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

        public DataTable UspSelectApprovalHierarchyInfo(int p_Approval_Hierarchy_Id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectAPPROVAL_HIERARCHY_INFO { Connection = connection, APPROVAL_HIERARCHY_ID = p_Approval_Hierarchy_Id }.ExecuteTable();
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

        public string UspUpdateApprovalHierarchy(int p_Approval_Hierarchy_Id, int p_Claim_Type_Id, int p_First_Approval, int p_Second_Approval, int p_Third_Approval, int p_Forth_Approval, string p_Ip_Address, int p_User_Id, int p_Distributor_Id)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new uspUpdateAPPROVAL_HIERARCHY { Connection = connection, APPROVAL_HIERARCHY_ID = p_Approval_Hierarchy_Id, CLAIM_TYPE_ID = p_Claim_Type_Id, FIRST_APPROVAL = p_First_Approval, SECOND_APPROVAL = p_Second_Approval, THIRD_APPROVAL = p_Third_Approval, FOURTH_APPROVAL = p_Forth_Approval, LASTUPDATE_DATE = DateTime.Now, TIME_STAMP = DateTime.Now, IP_ADDRESS = p_Ip_Address, USER_ID = p_User_Id, DISTRIBUTOR_ID = p_Distributor_Id }.ExecuteQuery();
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

