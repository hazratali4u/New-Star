namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class ControllerAssignLocations
    {
        public string InsertAssignLocation(int p_ASSIGN_TO_ID, int p_ASSIGN_LOCATION_ID, string p_ASSIGN_LOCATION_CODE, string p_ASSIGN_LOCATION_NAME, string p_ASSIGN_TYPE, string I_IPAddress)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                spInsertWAREHOUSES twarehouses = new spInsertWAREHOUSES();
                spInsertASSIGNMENTS tassignments = new spInsertASSIGNMENTS {
                    Connection = connection,
                    ASSIGN_TO_ID = p_ASSIGN_TO_ID,
                    ASSIGN_LOCATION_ID = p_ASSIGN_LOCATION_ID,
                    ASSIGN_LOCATION_CODE = p_ASSIGN_LOCATION_CODE,
                    ASSIGN_LOCATION_NAME = p_ASSIGN_LOCATION_NAME,
                    ASSIGN_TYPE = p_ASSIGN_TYPE,
                    IP_ADDRESS = I_IPAddress,
                    USER_ID = Configuration.UserID,
                    IS_ACCTIVE = true,
                    ASSIGN_DATE = DateTime.Now
                };
                tassignments.ExecuteQuery();
                message = tassignments.ASSIGN_LOCATION_ID.ToString();
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

        public DataTable Select_AssignLocationCustomer(int p_Type, int p_Assig_to, int Areaid, int RouteId)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                table2 = new UspSelectUnAssignLocationCustomer { Connection = connection, type = p_Type, Assign = p_Assig_to, AreaId = Areaid, Route = RouteId }.ExecuteTable();
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

        public DataTable Select_UnAssignLocation(int p_Type, int p_Assig_to)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                table2 = new UspSelectUnAssignLocation { Connection = connection, type = p_Type, Assign = p_Assig_to }.ExecuteTable();
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

        public DataTable SelectAssignedCustomer(int p_TLPPersonId)
        {
            return this.Select_AssignLocationCustomer(1, p_TLPPersonId, -2147483648, -2147483648);
        }

        public string UpdateAssignLocation(int AssignLocationId)
        {
            IDbConnection connection = null;
            string message;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                spUpdateASSIGNMENTS eassignments = new spUpdateASSIGNMENTS {
                    Connection = connection,
                    ASSIGNMENTS_ID = AssignLocationId,
                    ASSIGN_TO_ID = -2147483648,
                    ASSIGN_LOCATION_ID = -2147483648,
                    ASSIGN_LOCATION_CODE = null,
                    ASSIGN_LOCATION_NAME = null,
                    ASSIGN_TYPE = null,
                    IP_ADDRESS = null,
                    USER_ID = Configuration.UserID,
                    IS_ACCTIVE = false,
                    ASSIGN_DATE = DateTime.Now
                };
                eassignments.ExecuteQuery();
                message = eassignments.ASSIGN_LOCATION_ID.ToString();
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

