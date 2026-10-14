namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class DistributorUserController
    {
        public string InsertDistributor_User(string p_NIC, bool p_Is_Active, DateTime p_Time_Stamp, DateTime p_Lastupdate_Date, int p_User_Type_Id, int p_Distributor_Id, int p_Role_Id, string p_Email_Address, string p_Address1, string p_Address2, string p_Login_Id, string p_Password, string p_Mobile, string p_User_Code, string p_User_Name, string p_Phone)
        {
            IDbConnection connection = null;
            string str;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                spInsertDISTRIBUTOR_USER tdistributor_user = new spInsertDISTRIBUTOR_USER {
                    Connection = connection,
                    //USER_CODE = p_User_Code,
                    //USER_NAME = p_User_Name,
                    //NIC_NO = p_NIC,
                    //ADDRESS1 = p_Address1,
                    //ADDRESS2 = p_Address2,
                    //DISTRIBUTOR_ID = p_Distributor_Id,
                    //EMAIL = p_Email_Address,
                    //LASTUPDATE_DATE = p_Lastupdate_Date,
                    //LOGIN_ID = p_Login_Id,
                    //MOBILE = p_Mobile,
                    //PASSWORD = p_Password,
                    //PHONE = p_Phone,
                    //ROLE_ID = p_Role_Id,
                    //TIME_STAMP = p_Time_Stamp,
                    //USER_NAME = p_User_Name,
                    //USER_TYPE_ID = p_User_Type_Id,
                    //IS_ACTIVE = p_Is_Active
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

        public DataTable SelectDistributorUser(int p_Type, int p_Distributor_Id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectDISTRIBUTOR_USERInfo { Connection = connection, TYPE = p_Type, DISTRIBUTOR_ID = p_Distributor_Id }.ExecuteTable();
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
    }
}

