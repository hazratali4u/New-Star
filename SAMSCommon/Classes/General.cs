namespace SAMS.Common.Classes
{
    using FtpLib;
    using System;
    using System.Collections;
    using System.Windows.Forms;

    public class General
    {
        public static bool DeleteFileFtp(string UserID, string Password, string FtpHost, string FTPPath)
        {
            bool flag;
            try
            {
                FTPFactory factory = new FTPFactory();
                factory.setDebug(true);
                factory.setRemoteHost(FtpHost);
                if (UserID != "Null")
                {
                    factory.setRemoteUser(UserID);
                }
                if (Password != "Null")
                {
                    factory.setRemotePass(Password);
                    factory.login();
                }
                factory.chdir(FTPPath);
                string[] strArray = factory.getFileList("*.dat");
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (!strArray[i].ToString().Trim().Equals(""))
                    {
                        factory.deleteRemoteFile(strArray[i].ToString());
                    }
                }
                flag = true;
            }
            catch
            {
                throw;
            }
            return flag;
        }

        public static bool DownloadFileFromFtp(string UserID, string Password, string FtpHost, string FTPPath, string FileName, string SaveLocation)
        {
            bool flag2;
            try
            {
                bool flag = false;
                FTPFactory factory = new FTPFactory();
                factory.setDebug(true);
                factory.setRemoteHost(FtpHost);
                if (UserID != "Null")
                {
                    factory.setRemoteUser(UserID);
                    factory.setRemotePass(Password);
                    factory.login();
                }
                factory.chdir(FTPPath);
                string[] strArray = factory.getFileList("*.*");
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (strArray[i].Equals(FileName + "\r"))
                    {
                        factory.download(strArray[i].ToString(), SaveLocation + strArray[i].ToString());
                        flag = true;
                    }
                }
                if (flag)
                {
                    return true;
                }
                flag2 = false;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag2;
        }

        public static bool DownloadFolderFromFtp(string UserID, string Password, string FtpHost, string FTPPath, string SaveLocation)
        {
            bool flag;
            try
            {
                FTPFactory factory = new FTPFactory();
                factory.setDebug(true);
                factory.setRemoteHost(FtpHost);
                factory.setRemoteUser(UserID);
                factory.setRemotePass(Password);
                factory.login();
                factory.chdir(FTPPath);
                string[] strArray = factory.getFileList("*.*");
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (!strArray[i].Equals(""))
                    {
                        factory.download(strArray[i].ToString(), SaveLocation + strArray[i].ToString());
                    }
                }
                flag = true;
            }
            catch
            {
                throw;
            }
            return flag;
        }

        public static bool DownloadSelectedFileFromFtp(string UserID, string Password, string FtpHost, string FTPPath, string SaveLocation, string[] mExceptionFiles)
        {
            bool flag;
            try
            {
                FTPFactory factory = new FTPFactory();
                factory.setDebug(true);
                factory.setRemoteHost(FtpHost);
                factory.setRemoteUser(UserID);
                factory.setRemotePass(Password);
                ArrayList list = new ArrayList(2);
                for (int i = 0; i < mExceptionFiles.Length; i++)
                {
                    list.Add(mExceptionFiles[i].ToString().Trim());
                }
                factory.login();
                factory.chdir(FTPPath);
                string[] strArray = factory.getFileList("*.*");
                for (int j = 0; j < strArray.Length; j++)
                {
                    if (list.Contains(strArray[j].ToString().Trim()) && !strArray[j].ToString().Trim().Equals(""))
                    {
                        factory.download(strArray[j].ToString(), SaveLocation + strArray[j].ToString());
                    }
                }
                flag = true;
            }
            catch
            {
                throw;
            }
            return flag;
        }

        public static bool DownloadTXTFilesFromFtp(string UserID, string Password, string FtpHost, string FTPPath, string SaveLocation, string FileExtention)
        {
            bool flag;
            try
            {
                FTPFactory factory = new FTPFactory();
                factory.setDebug(true);
                factory.setRemoteHost(FtpHost);
                if (UserID != "Null")
                {
                    factory.setRemoteUser(UserID);
                }
                if (Password != "Null")
                {
                    factory.setRemotePass(Password);
                    factory.login();
                }
                factory.chdir(FTPPath);
                string[] strArray = factory.getFileList("");
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (!strArray[i].ToString().Trim().Equals(""))
                    {
                        factory.download(strArray[i].ToString(), SaveLocation + strArray[i].ToString());
                    }
                }
                flag = true;
            }
            catch
            {
                throw;
            }
            return flag;
        }

        public static bool DownloadUnSelectedFileFromFtp(string UserID, string Password, string FtpHost, string FTPPath, string SaveLocation)
        {
            bool flag;
            try
            {
                FTPFactory factory = new FTPFactory();
                factory.setDebug(true);
                factory.setRemoteHost(FtpHost);
                if (UserID != "Null")
                {
                    factory.setRemoteUser(UserID);
                }
                if (Password != "Null")
                {
                    factory.setRemotePass(Password);
                    factory.login();
                }
                factory.chdir(FTPPath);
                string[] strArray = factory.getFileList("*.dat");
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (!strArray[i].ToString().Trim().Equals(""))
                    {
                        factory.download(strArray[i].ToString(), SaveLocation + strArray[i].ToString());
                    }
                }
                flag = true;
            }
            catch
            {
                throw;
            }
            return flag;
        }

        public static bool DownloadUnSelectedFileFromFtp(string UserID, string Password, string FtpHost, string FTPPath, string SaveLocation, string[] mExceptionFiles)
        {
            bool flag;
            try
            {
                FTPFactory factory = new FTPFactory();
                factory.setDebug(true);
                factory.setRemoteHost(FtpHost);
                if (UserID != "Null")
                {
                    factory.setRemoteUser(UserID);
                }
                if (Password != "Null")
                {
                    factory.setRemotePass(Password);
                    factory.login();
                }
                factory.chdir(FTPPath);
                ArrayList list = new ArrayList(2);
                for (int i = 0; i < mExceptionFiles.Length; i++)
                {
                    list.Add(mExceptionFiles[i].ToString().Trim());
                }
                string[] strArray = factory.getFileList("*.dat");
                for (int j = 0; j < strArray.Length; j++)
                {
                    if (!list.Contains(strArray[j].ToString().Trim()) && !strArray[j].ToString().Trim().Equals(""))
                    {
                        factory.download(strArray[j].ToString(), SaveLocation + strArray[j].ToString());
                    }
                }
                flag = true;
            }
            catch
            {
                throw;
            }
            return flag;
        }

        public static string ReplaceSymbols(string p_FormattedString)
        {
            try
            {
                p_FormattedString = p_FormattedString.Replace("%APPPATH%", Configuration.GetAppInstallationPath());
                p_FormattedString = p_FormattedString.Replace("%SERVERFTPPATH%", Configuration.ServerFTPpath);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return p_FormattedString;
        }

        public static void ShowErrorMessage(string errMsg)
        {
            MessageBox.Show(errMsg, "SAMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static bool UploadFileFtp(string UserID, string Password, string FtpHost, string FTPPath, string LogFileName)
        {
            bool flag;
            try
            {
                FTPFactory factory = new FTPFactory();
                factory.setDebug(true);
                factory.setRemoteHost(FtpHost);
                if (UserID != "Null")
                {
                    factory.setRemoteUser(UserID);
                    factory.setRemotePass(Password);
                    factory.login();
                }
                factory.chdir(FTPPath);
                factory.upload(LogFileName, true);
                flag = true;
            }
            catch
            {
                throw;
            }
            return flag;
        }
    }
}

