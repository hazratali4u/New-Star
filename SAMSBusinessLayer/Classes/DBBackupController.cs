namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class DBBackupController
    {
        public bool DeleteDBBackup(int p_DBBackup_Id, bool IsDeleteRecord)
        {
            IDbConnection connection = null;
            bool flag;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                if (IsDeleteRecord)
                {
                    new spDeleteDB_BACKUP { Connection = connection, DB_BACKUP_ID = p_DBBackup_Id }.ExecuteQuery();
                }
                else
                {
                    new spUpdateDB_BACKUP { Connection = connection, DB_BACKUP_ID = p_DBBackup_Id, BACKUP_FILENAME = null, CLOSING_DATE = Constants.DateNullValue, IS_DELETED = true, IS_ACTIVE = true, TIME_STAMP = Constants.DateNullValue, USER_ID = Configuration.UserID, LASTUPDATE_DATE = DateTime.Now }.ExecuteQuery();
                }
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

        public string InsertDBBackup(string p_DBBackupFileName, DateTime p_ClosingDate)
        {
            IDbConnection connection = null;
            string str;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                spInsertDB_BACKUP tdb_backup = new spInsertDB_BACKUP {
                    Connection = connection,
                    BACKUP_FILENAME = p_DBBackupFileName,
                    CLOSING_DATE = p_ClosingDate,
                    IS_DELETED = false,
                    IS_ACTIVE = true,
                    TIME_STAMP = DateTime.Now,
                    USER_ID = Configuration.UserID,
                    LASTUPDATE_DATE = Constants.DateNullValue
                };
                tdb_backup.ExecuteQuery();
                str = tdb_backup.DB_BACKUP_ID.ToString();
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

        public DataTable SelectDBBackup(int p_DBBackup_Id, string p_DBBackupFileName, DateTime p_ClosingDate, bool p_IsDeleted)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new spSelectDB_BACKUP { Connection = connection, DB_BACKUP_ID = p_DBBackup_Id, BACKUP_FILENAME = p_DBBackupFileName, CLOSING_DATE = p_ClosingDate, IS_DELETED = p_IsDeleted, IS_ACTIVE = true, TIME_STAMP = Constants.DateNullValue, USER_ID = -2147483648, LASTUPDATE_DATE = Constants.DateNullValue }.ExecuteTable();
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

        public string UpdateDBBackup(int p_DBBackup_Id, string p_DBBackupFileName, DateTime p_ClosingDate, bool p_IsDeleted)
        {
            IDbConnection connection = null;
            string str;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                spUpdateDB_BACKUP edb_backup = new spUpdateDB_BACKUP {
                    Connection = connection,
                    DB_BACKUP_ID = p_DBBackup_Id,
                    BACKUP_FILENAME = p_DBBackupFileName,
                    CLOSING_DATE = p_ClosingDate,
                    IS_DELETED = p_IsDeleted,
                    IS_ACTIVE = true,
                    TIME_STAMP = Constants.DateNullValue,
                    USER_ID = Configuration.UserID,
                    LASTUPDATE_DATE = DateTime.Now
                };
                edb_backup.ExecuteQuery();
                str = edb_backup.DB_BACKUP_ID.ToString();
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

