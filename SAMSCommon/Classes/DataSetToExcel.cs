namespace SAMS.Common.Classes
{
    using System;
    using System.Data;
    using System.IO;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class DataSetToExcel
    {
        public void Convert(DataSet ds, HttpResponse response)
        {
            response.Clear();
            response.Charset = "";
            response.ContentType = "application/vnd.ms-excel";
            StringWriter writer = new StringWriter();
            HtmlTextWriter writer2 = new HtmlTextWriter(writer);
            DataGrid grid = new DataGrid {
                DataSource = ds.Tables[0]
            };
            grid.DataBind();
            grid.RenderControl(writer2);
            response.Write(writer.ToString());
            response.End();
        }

        public static void exportToExcel(DataSet source, string fileName, string TableName)
        {
            StreamWriter writer = new StreamWriter(fileName);
            int num = 0;
            int num2 = 1;
            writer.Write("<xml version>\r\n<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"\r\n xmlns:o=\"urn:schemas-microsoft-com:office:office\"\r\n xmlns:x=\"urn:schemas-    microsoft-com:office:excel\"\r\n xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\">\r\n <Styles>\r\n <Style ss:ID=\"Default\" ss:Name=\"Normal\">\r\n <Alignment ss:Vertical=\"Bottom\"/>\r\n <Borders/>\r\n <Font/>\r\n <Interior/>\r\n <NumberFormat/>\r\n <Protection/>\r\n </Style>\r\n <Style ss:ID=\"BoldColumn\">\r\n <Font x:Family=\"Swiss\" ss:Bold=\"1\"/>\r\n </Style>\r\n <Style     ss:ID=\"StringLiteral\">\r\n <NumberFormat ss:Format=\"@\"/>\r\n </Style>\r\n <Style ss:ID=\"Decimal\">\r\n <NumberFormat ss:Format=\"0.0000\"/>\r\n </Style>\r\n <Style ss:ID=\"Integer\">\r\n <NumberFormat ss:Format=\"0\"/>\r\n </Style>\r\n <Style ss:ID=\"DateLiteral\">\r\n <NumberFormat ss:Format=\"mm/dd/yyyy;@\"/>\r\n </Style>\r\n </Styles>\r\n ");
            writer.Write("<Worksheet ss:Name=\"Sheet" + num2 + "\">");
            writer.Write("<Table>");
            writer.Write("<Row>");
            for (int i = 0; i < source.Tables[TableName].Columns.Count; i++)
            {
                writer.Write("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">");
                writer.Write(source.Tables[TableName].Columns[i].ColumnName);
                writer.Write("</Data></Cell>");
            }
            writer.Write("</Row>");
            foreach (DataRow row in source.Tables[TableName].Rows)
            {
                num++;
                if (num == 0xfa00)
                {
                    num = 0;
                    num2++;
                    writer.Write("</Table>");
                    writer.Write(" </Worksheet>");
                    writer.Write("<Worksheet ss:Name=\"Sheet" + num2 + "\">");
                    writer.Write("<Table>");
                }
                writer.Write("<Row>");
                for (int j = 0; j < source.Tables[TableName].Columns.Count; j++)
                {
                    Type type = row[j].GetType();
                    switch (type.ToString())
                    {
                        case "System.String":
                        {
                            string str = row[j].ToString().Trim().Replace("&", "&").Replace(">", ">").Replace("<", "<");
                            writer.Write("<Cell ss:StyleID=\"StringLiteral\"><Data ss:Type=\"String\">");
                            writer.Write(str);
                            writer.Write("</Data></Cell>");
                            break;
                        }
                        case "System.DateTime":
                        {
                            int num5;
                            DateTime time = (DateTime) row[j];
                            string str2 = "";
                            str2 = time.Year.ToString() + "-" + ((time.Month < 10) ? ("0" + time.Month.ToString()) : time.Month.ToString()) + "-" + ((time.Day < 10) ? ("0" + time.Day.ToString()) : time.Day.ToString()) + "T" + ((time.Hour < 10) ? ("0" + time.Hour.ToString()) : time.Hour.ToString()) + ":" + ((time.Minute < 10) ? ("0" + time.Minute.ToString()) : time.Minute.ToString()) + ":" + ((time.Second < 10) ? ("0" + (num5 = time.Second).ToString()) : (num5 = time.Second).ToString()) + ".000";
                            writer.Write("<Cell ss:StyleID=\"DateLiteral\"><Data ss:Type=\"DateTime\">");
                            writer.Write(str2);
                            writer.Write("</Data></Cell>");
                            break;
                        }
                        case "System.Boolean":
                            writer.Write("<Cell ss:StyleID=\"StringLiteral\"><Data ss:Type=\"String\">");
                            writer.Write(row[j].ToString());
                            writer.Write("</Data></Cell>");
                            break;

                        case "System.Int16":
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            writer.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"Number\">");
                            writer.Write(row[j].ToString());
                            writer.Write("</Data></Cell>");
                            break;

                        case "System.Decimal":
                        case "System.Double":
                            writer.Write("<Cell ss:StyleID=\"Decimal\"><Data ss:Type=\"Number\">");
                            writer.Write(row[j].ToString());
                            writer.Write("</Data></Cell>");
                            break;

                        case "System.DBNull":
                            writer.Write("<Cell ss:StyleID=\"StringLiteral\"><Data ss:Type=\"String\">");
                            writer.Write("");
                            writer.Write("</Data></Cell>");
                            break;

                        default:
                            throw new Exception(type.ToString() + " not handled.");
                    }
                }
                writer.Write("</Row>");
            }
            writer.Write("</Table>");
            writer.Write(" </Worksheet>");
            writer.Write("</Workbook>");
            writer.Close();
        }

        public static string GetWriteableValue(object o)
        {
            if (o == null)
            {
                return "";
            }
            if (o.ToString().IndexOf(",") == -1)
            {
                return o.ToString();
            }
            return ("\"" + o.ToString() + "\"");
        }

        public static void ProduceCSV(DataTable dt, string fileName, bool WriteHeader)
        {
            int num;
            StreamWriter writer = new StreamWriter(fileName);
            if (WriteHeader)
            {
                string[] strArray = new string[dt.Columns.Count];
                num = 0;
                while (num < dt.Columns.Count)
                {
                    strArray[num] = dt.Columns[num].ColumnName;
                    strArray[num] = GetWriteableValue(strArray[num]);
                    num++;
                }
                writer.WriteLine(string.Join(",", strArray));
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string[] strArray2 = new string[dt.Columns.Count];
                for (num = 0; num < dt.Columns.Count; num++)
                {
                    object o = dt.Rows[i][num];
                    strArray2[num] = GetWriteableValue(o);
                }
                writer.WriteLine(string.Join(",", strArray2));
            }
            writer.Close();
        }
    }
}

