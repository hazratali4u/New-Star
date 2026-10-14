namespace SAMS.Common.Classes
{
    using System;
    using System.Collections;
    using System.Data;

    public class clsDataSetUtil
    {
        private static bool ColumnEqual(object A, object B)
        {
            if ((A == DBNull.Value) && (B == DBNull.Value))
            {
                return true;
            }
            if ((A == DBNull.Value) || (B == DBNull.Value))
            {
                return false;
            }
            return A.Equals(B);
        }

        public static DataTable SelectDistinct(string TableName, DataTable SourceTable, string FieldName, ArrayList SelectedColumn)
        {
            DataTable table = new DataTable(TableName);
            foreach (string str in SelectedColumn)
            {
                table.Columns.Add(str, SourceTable.Columns[str].DataType);
            }
            object a = null;
            foreach (DataRow row in SourceTable.Select("", FieldName))
            {
                if ((a == null) || !ColumnEqual(a, row[FieldName]))
                {
                    a = row[FieldName];
                    DataRow row2 = table.NewRow();
                    foreach (string str in SelectedColumn)
                    {
                        row2[str] = row[str];
                    }
                    table.Rows.Add(row2);
                }
            }
            return table;
        }
    }
}

