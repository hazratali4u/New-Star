namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class LegendController
    {
        public string DeleteLegend(int p_Legend_Id)
        {
            IDbConnection connection = null;
            string str;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spDeleteLEGEND { Connection = connection, LEGEND_ID = p_Legend_Id }.ExecuteQuery();
                str = "Record Deleted";
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

        public string InsertLegend(bool p_Is_Active, DateTime p_Time_Stamp, int p_User_Id, int p_Legend_Type_Id, string p_Legend_Description, string p_Legend_Name)
        {
            IDbConnection connection = null;
            string str;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                spInsertLEGEND tlegend = new spInsertLEGEND {
                    Connection = connection,
                    LEGEND_NAME = p_Legend_Name,
                    LEGEND_TYPE_ID = p_Legend_Type_Id,
                    LEGEND_DESCRIPTION = p_Legend_Description,
                    USER_ID = p_User_Id,
                    IS_ACTIVE = p_Is_Active,
                    TIMESTAMP = p_Time_Stamp,
                    LAST_UPDATE_DATE = Constants.DateNullValue
                };
                tlegend.ExecuteQuery();
                str = tlegend.LEGEND_ID.ToString();
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

        public DataTable SelectLegend(int p_Legend_Id, bool p_Is_Active, DateTime p_Time_Stamp, DateTime p_Lastupdate_Date, int p_User_Id, int p_Legend_Type_Id, string p_Legend_Description, string p_Legend_Name)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectLEGEND { Connection = connection, LEGEND_ID = p_Legend_Id, LEGEND_NAME = p_Legend_Name, LEGEND_TYPE_ID = p_Legend_Type_Id, LEGEND_DESCRIPTION = p_Legend_Description, USER_ID = p_User_Id, IS_ACTIVE = p_Is_Active, TIMESTAMP = Constants.DateNullValue, LAST_UPDATE_DATE = Constants.DateNullValue }.ExecuteTable();
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

        public DataTable SelectLegendInfo(int p_Legend_Id, bool p_Is_Active, DateTime p_Time_Stamp, DateTime p_Lastupdate_Date, int p_User_Id, int p_Legend_Type_Id, string p_Legend_Description, string p_Legend_Name)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectLEGENDInfo { Connection = connection, LEGEND_ID = p_Legend_Id, LEGEND_NAME = p_Legend_Name, LEGEND_TYPE_ID = p_Legend_Type_Id, LEGEND_DESCRIPTION = p_Legend_Description, USER_ID = p_User_Id, IS_ACTIVE = p_Is_Active, TIMESTAMP = Constants.DateNullValue, LAST_UPDATE_DATE = Constants.DateNullValue }.ExecuteTable();
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

        public DataTable SelectLegends(int p_Legend_Type_Id)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectLEGEND { Connection = connection, LEGEND_ID = -2147483648, LEGEND_TYPE_ID = p_Legend_Type_Id, USER_ID = -2147483648, IS_ACTIVE = true, TIMESTAMP = Constants.DateNullValue, LAST_UPDATE_DATE = Constants.DateNullValue }.ExecuteTable();
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

        public string UpdateLegend(int p_Legend_Id, bool p_Is_Active, DateTime p_Time_Stamp, int p_User_Id, int p_Legend_Type_Id, DateTime p_Lastupdate_Date, string p_Legend_Description, string p_Legend_Name)
        {
            IDbConnection connection = null;
            string str;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                spUpdateLEGEND elegend = new spUpdateLEGEND {
                    Connection = connection,
                    LEGEND_ID = p_Legend_Id,
                    LEGEND_NAME = p_Legend_Name,
                    LEGEND_TYPE_ID = p_Legend_Type_Id,
                    LEGEND_DESCRIPTION = p_Legend_Description,
                    USER_ID = p_User_Id,
                    IS_ACTIVE = p_Is_Active,
                    TIMESTAMP = p_Time_Stamp,
                    LAST_UPDATE_DATE = p_Lastupdate_Date
                };
                elegend.ExecuteQuery();
                str = elegend.LEGEND_ID.ToString();
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

