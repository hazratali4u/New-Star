namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class SAMSettingController
    {
        public DataTable SelectLocationType(int p_REF_ID, string p_SHORT_NAME, string p_DESCRIPTION, int p_PARENT_REF_ID, bool p_IS_ACTIVE, DateTime p_TIME_STAMP)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectSAMS_SETTING { Connection = connection, REF_ID = p_REF_ID, SHORT_NAME = p_SHORT_NAME, DESCRIPTION = p_DESCRIPTION, PARENT_REF_ID = p_PARENT_REF_ID, IS_ACTIVE = p_IS_ACTIVE, TIME_STAMP = p_TIME_STAMP }.ExecuteTable();
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

