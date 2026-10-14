namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class SLASHCodesController
    {
        public string DeleteSlashCodes(long p_RefID)
        {
            try
            {
                return "";
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                return exception.Message;
            }
        }

        public int GetRef_ID(string p_SlashCode, int p_Parent_Ref_ID)
        {
            DataTable table = this.SelectSlashCodes(-2147483648, p_SlashCode, p_Parent_Ref_ID, null, -2147483648, true);
            if (table.Rows.Count > 0)
            {
                return int.Parse(table.Rows[0]["REF_ID"].ToString());
            }
            return 0;
        }

        public string GetSLASH_DESC(int Ref_ID, int p_Parent_Ref_ID)
        {
            DataTable table = this.SelectSlashCodes(Ref_ID, null, p_Parent_Ref_ID, null, -2147483648, true);
            if (table.Rows.Count > 0)
            {
                return table.Rows[0]["SLASH_DESC"].ToString();
            }
            return null;
        }

        public string InsertSlashCodes(string p_SlashCode, int p_Parent_Ref_ID, string p_SlashDesc, int p_Status, bool p_IsActive)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spInsertSLASH_CODES { Connection = connection, PARENT_REF_ID = p_Parent_Ref_ID, SLASH_CODE = p_SlashCode, SLASH_DESC = p_SlashDesc, TIME_STAMP = DateTime.Now, STATUS = p_Status, IS_ACTIVE = p_IsActive }.ExecuteQuery();
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

        public DataTable SelectDTSlashCodes(int p_RefID, string p_SlashCode, int p_Parent_Ref_ID, string p_SlashDesc, int p_Status, bool p_IsActive)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectSLASH_CODES { Connection = connection, PARENT_REF_ID = p_Parent_Ref_ID, SLASH_CODE = p_SlashCode, SLASH_DESC = p_SlashDesc, TIME_STAMP = Constants.DateNullValue, STATUS = p_Status, REF_ID = p_RefID, IS_ACTIVE = p_IsActive }.ExecuteTable();
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

        public DataTable SelectSlashCodes(int p_RefID, string p_SlashCode, int p_Parent_Ref_ID, string p_SlashDesc, int p_Status, bool p_IsActive)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectSLASH_CODES { Connection = connection, PARENT_REF_ID = p_Parent_Ref_ID, SLASH_CODE = p_SlashCode, SLASH_DESC = p_SlashDesc, TIME_STAMP = Constants.DateNullValue, STATUS = p_Status, REF_ID = p_RefID, IS_ACTIVE = p_IsActive }.ExecuteTable();
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

        public string UpdateSlashCodes(int p_RefID, string p_SlashCode, int p_Parent_Ref_ID, string p_SlashDesc, int p_Status, bool p_IsActive, DateTime p_Time_Stamp)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spUpdateSLASH_CODES { Connection = connection, REF_ID = p_RefID, PARENT_REF_ID = p_Parent_Ref_ID, SLASH_CODE = p_SlashCode, SLASH_DESC = p_SlashDesc, TIME_STAMP = p_Time_Stamp, STATUS = p_Status, IS_ACTIVE = p_IsActive }.ExecuteQuery();
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

