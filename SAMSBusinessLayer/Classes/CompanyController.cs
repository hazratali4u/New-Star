namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class CompanyController
    {
        public string InsertDTCompany(bool p_ISCURRENT, bool p_ISDELETED, int p_COMPANY_ID, int p_STATUS, string p_EMAIL_ADDRESS, string p_PHONE, string p_FAX, string p_WEBSITE, string p_COMPANY_NAME, string p_ADDRESS1, string p_ADDRESS2)
        {
            IDbConnection connection = null;
            string str;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                spInsertDTCOMPANY tdtcompany = new spInsertDTCOMPANY {
                    Connection = connection,
                    ISCURRENT = p_ISCURRENT,
                    ISDELETED = p_ISDELETED,
                    COMPANY_ID = p_COMPANY_ID,
                    STATUS = p_STATUS,
                    EMAIL_ADDRESS = p_EMAIL_ADDRESS,
                    PHONE = p_PHONE,
                    FAX = p_FAX,
                    WEBSITE = p_WEBSITE,
                    COMPANY_NAME = p_COMPANY_NAME,
                    ADDRESS1 = p_ADDRESS1,
                    ADDRESS2 = p_ADDRESS2
                };
                tdtcompany.ExecuteQuery();
                str = tdtcompany.COMPANY_ID.ToString();
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

        public DataTable SelectCompany(int p_COMPANY_ID, int p_STATUS)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectCOMPANY { Connection = connection, STATUS = p_STATUS, COMPANY_ID = p_COMPANY_ID, ISCURRENT = true, ISDELETED = false }.ExecuteTable();
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

