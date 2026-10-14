namespace SAMS.Common.Classes
{
    using System;
    using System.IO;
    using System.Text;

    public class ExceptionPublisher
    {
        public static void PublishException(Exception exception)
        {
            try
            {
                string fldLogFileFolder = Constants.fldLogFileFolder;
                switch (fldLogFileFolder)
                {
                    case null:
                    case "":
                        throw new Exception("");
                }
                StringBuilder builder = new StringBuilder();
                builder.AppendFormat("{0}{1}: {2}", Environment.NewLine, "Machine Name:", Environment.MachineName.ToString());
                builder.AppendFormat("{0}{1}: {2}", Environment.NewLine, "User Name   :", Environment.UserName.ToString());
                builder.AppendFormat("{0}{1}: {2}", Environment.NewLine, "OS Version  :", Environment.OSVersion.ToString());
                builder.AppendFormat("{0}{1}: {2}", Environment.NewLine, "Date Time   :", DateTime.Now.ToString("dd MMM yy hh:mm:ss"));
                string path = fldLogFileFolder + "SAMSErrorLog" + DateTime.Today.ToString("yyyyMMdd") + ".log";
                builder.AppendFormat("{0}Exception Information:{0}{1}", Environment.NewLine, exception.ToString());
                builder.AppendFormat("{0}{1}: {2}", Environment.NewLine, "", "----------------------------------");
                using (FileStream stream = File.Open(path, FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        writer.Write(builder.ToString());
                    }
                }
            }
            catch (Exception exception2)
            {
                throw new SAMSUserException("Error YE-1201 has occurred. Please contact System Administrator to resolve the issue.", exception2);
            }
        }

        public static void PublishExceptionforSync(Exception exception, string ExpDetail)
        {
            try
            {
                string fldLogFileFolder = Constants.fldLogFileFolder;
                switch (fldLogFileFolder)
                {
                    case null:
                    case "":
                        throw new Exception("");
                }
                StringBuilder builder = new StringBuilder();
                builder.AppendFormat("{0}{1}: {2}", Environment.NewLine, "Machine Name:", Environment.MachineName.ToString());
                builder.AppendFormat("{0}{1}: {2}", Environment.NewLine, "User Name   :", Environment.UserName.ToString());
                builder.AppendFormat("{0}{1}: {2}", Environment.NewLine, "OS Version  :", Environment.OSVersion.ToString());
                builder.AppendFormat("{0}{1}: {2}", Environment.NewLine, "Date Time   :", DateTime.Now.ToString("dd MMM yy hh:mm:ss"));
                string path = fldLogFileFolder + "SAMSErrorLog" + DateTime.Today.ToString("yyyyMMdd") + ".log";
                builder.AppendFormat("{0}Exception Information:{0}{1}", Environment.NewLine, exception.ToString());
                builder.AppendFormat("{0}{1}: {2}", Environment.NewLine, "", "----------------------------------");
                builder.AppendFormat("{0}{1}: {2}", Environment.NewLine, "Exp Detail ", ExpDetail);
                using (FileStream stream = File.Open(path, FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        writer.Write(builder.ToString());
                    }
                }
            }
            catch (Exception exception2)
            {
                throw new SAMSUserException("Error YE-1201 has occurred. Please contact System Administrator to resolve the issue.", exception2);
            }
        }
    }
}

