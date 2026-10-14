namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class SchemeController
    {
        public string DeleteScheme()
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

        public string InsertScheme(int p_Distributor_Id, string p_Scheme_Code, string p_Scheme_Desc, DateTime p_Scheme_Date)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                spInsertSCHEME tscheme = new spInsertSCHEME {
                    Connection = connection,
                    DISTRIBUTOR_ID = p_Distributor_Id,
                    SCHEME_CODE = p_Scheme_Code,
                    SCHEME_DESC = p_Scheme_Desc,
                    SCHEME_DATE = p_Scheme_Date
                };
                tscheme.ExecuteQuery();
                message = tscheme.SCHEME_ID.ToString();
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

        public DataTable SelectPromotion(string P_start, string P_end, int P_UserId, bool p_PActive)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectPromotionsScheme { Connection = connection, FromDate = DateTime.Parse(P_start), To_Date = DateTime.Parse(P_end), USER_ID = P_UserId, IS_ACTIVE = p_PActive }.ExecuteTable();
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

        public DataTable SelectScheme(int p_Scheme_Id, int p_Distributor_Id, string p_Scheme_Code, string p_Scheme_Desc, DateTime p_Scheme_Date)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectSCHEME { Connection = connection, SCHEME_ID = p_Scheme_Id, DISTRIBUTOR_ID = p_Distributor_Id, SCHEME_CODE = p_Scheme_Code, SCHEME_DESC = p_Scheme_Desc, SCHEME_DATE = p_Scheme_Date }.ExecuteTable();
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

        public string UpdateScheme(int p_Scheme_Id, int p_Distributor_Id, string p_Scheme_Code, string p_Scheme_Desc, DateTime p_Scheme_Date)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spUpdateSCHEME { Connection = connection, SCHEME_ID = p_Scheme_Id, DISTRIBUTOR_ID = p_Distributor_Id, SCHEME_CODE = p_Scheme_Code, SCHEME_DESC = p_Scheme_Desc, SCHEME_DATE = p_Scheme_Date }.ExecuteQuery();
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

