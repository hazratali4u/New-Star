namespace SAMS.BusinessLayer.Classes
{
    using SAMS.Common.Classes;
    using SAMS.DataAccessLayer.Classes;
    using SAMS.DatabaseLayer.Classes;
    using System;
    using System.Data;

    public class SETTINGS_TABLE_Controller
    {
        public string GetAutoAccountCode(string p_code, int p_type, long p_value)
        {
            IDbConnection connection = null;
            string str2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                uspSelectSETTINGS_TABLE01 tsettings_table = new uspSelectSETTINGS_TABLE01 {
                    Connection = connection,
                    Code = p_code,
                    type = p_type,
                    value = p_value
                };
                string str = (long.Parse(tsettings_table.ExecuteTable().Rows[0]["VALUE"].ToString()) + 1L).ToString();
                if (str.Length == 1)
                {
                    str = "000" + str;
                }
                else if (str.Length == 2)
                {
                    str = "00" + str;
                }
                else if (str.Length == 1)
                {
                    str = "0" + str;
                }
                str2 = str;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                str2 = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return str2;
        }

        public string GetAutoCode(string p_code, int p_type, long p_value)
        {
            IDbConnection connection = null;
            string str2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                uspSelectSETTINGS_TABLE01 tsettings_table = new uspSelectSETTINGS_TABLE01 {
                    Connection = connection,
                    Code = p_code,
                    type = p_type,
                    value = p_value
                };
                string str = (long.Parse(tsettings_table.ExecuteTable().Rows[0]["VALUE"].ToString()) + 1L).ToString();
                if (str.Length == 1)
                {
                    str = "00" + str;
                }
                else if (str.Length == 2)
                {
                    str = "0" + str;
                }
                else
                {
                    str = str;
                }
                str2 = p_code + str;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                str2 = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return str2;
        }

        public long GetAutoCustomerCode(string p_code, int p_type, long p_value)
        {
            IDbConnection connection = null;
            long num;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                uspSelectSETTINGS_TABLE01 tsettings_table = new uspSelectSETTINGS_TABLE01 {
                    Connection = connection,
                    Code = p_code,
                    type = p_type,
                    value = p_value
                };
                num = long.Parse(tsettings_table.ExecuteTable().Rows[0]["VALUE"].ToString()) + 1L;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                num = -1L;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return num;
        }

        public long GetAutoNumber(string p_code, int p_type, long p_value)
        {
            IDbConnection connection = null;
            long num2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                uspSelectSETTINGS_TABLE01 tsettings_table = new uspSelectSETTINGS_TABLE01 {
                    Connection = connection,
                    Code = p_code,
                    type = p_type,
                    value = p_value
                };
                int num = int.Parse(tsettings_table.ExecuteTable().Rows[0]["VALUE"].ToString()) + 1;
                num2 = num;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                num2 = -1L;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return num2;
        }

        public string GetAutoOrderNo(string p_code, int p_type, long p_value)
        {
            IDbConnection connection = null;
            string str2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                uspSelectSETTINGS_TABLE01 tsettings_table = new uspSelectSETTINGS_TABLE01 {
                    Connection = connection,
                    Code = p_code,
                    type = p_type,
                    value = p_value
                };
                string str = (long.Parse(tsettings_table.ExecuteTable().Rows[0]["VALUE"].ToString()) + 1L).ToString();
                str2 = p_code + "-" + str;
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                str2 = null;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return str2;
        }

        public string InsertTmpData(int SoldTo, int sku_id, decimal Amount, int qty)
        {
            IDbConnection connection = null;
            string str;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                new spInsertTmpPromotion { Connection = connection, SoldToId = SoldTo, SKU_ID = sku_id, Amount = Amount, Qty = qty }.ExecuteQuery();
                str = "Record Save";
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

        public DataTable Select_SETTINGS_TABLE(string p_TableName, string FeildName, int DistributorId)
        {
            IDbConnection connection = null;
            DataTable table2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                table2 = new uspSelectSETTINGS_TABLE { Connection = connection, TableName = p_TableName, FieldName = FeildName, DistributorId = DistributorId }.ExecuteTable();
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

        public bool Update_SETTINGS_TABLE(string code, string desc, int id, long val)
        {
            IDbConnection connection = null;
            bool flag2;
            try
            {
                connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                connection.Open();
                flag2 = new spUpdateSETTINGS_TABLE { Connection = connection, CODE = code, DESC = desc, SETTING_ID = id, VALUE = val }.ExecuteQuery();
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
                flag2 = false;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
            return flag2;
        }
    }
}

