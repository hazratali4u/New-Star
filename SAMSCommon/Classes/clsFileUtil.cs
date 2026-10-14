namespace SAMS.Common.Util.IO
{
    using SAMS.Common.Util.Strings;
    using System;
    using System.IO;
    using System.Runtime.InteropServices;

    public class clsFileUtil
    {
        private clsFileUtil()
        {
        }

        public static string GetDistributorCode(string pStrFileName)
        {
            string str = "";
            int startIndex = 0;
            int index = pStrFileName.IndexOf("_");
            if (index != -1)
            {
                str = pStrFileName.Substring(startIndex, index - startIndex);
            }
            return str;
        }

        public static void GetFileInfo(string pStrFileName, out string pStrPath, out string pStrName)
        {
            pStrName = null;
            pStrPath = null;
            int length = 0;
            length = pStrFileName.LastIndexOf(@"\");
            if (length > 0)
            {
                pStrPath = pStrFileName.Substring(0, length);
            }
            length = ((length >= 0) && ((length + 1) < pStrFileName.Length)) ? (length + 1) : 0;
            pStrName = pStrFileName.Substring(length);
        }

        public static string GetFileName(string pStrFileName)
        {
            return GetFileName(pStrFileName, true);
        }

        public static string GetFileName(string pStrFileName, bool pBWantExtension)
        {
            string pStrName = null;
            string pStrPath = null;
            GetFileInfo(pStrFileName, out pStrPath, out pStrName);
            if (!pBWantExtension)
            {
                int num = 0;
                num = pStrName.LastIndexOf(".");
                if ((num > 0) && ((num + 1) < pStrName.Length))
                {
                    num++;
                    pStrName = pStrName.Substring(0, num - 1);
                }
            }
            return pStrName;
        }

        public static bool IsFullFileName(string pStrFileName)
        {
            string pStrName = null;
            string pStrPath = null;
            GetFileInfo(pStrFileName, out pStrPath, out pStrName);
            return (clsStringUtil.IsEmpty(pStrPath, true) && clsStringUtil.IsEmpty(pStrName, true));
        }

        public static string Read(string pStrFilePath)
        {
            return Read(pStrFilePath, 0x100);
        }

        public static string Read(string pStrFilePath, int pNBufferSize)
        {
            string str = null;
            FileStream stream = null;
            byte[] buffer = new byte[pNBufferSize];
            int pNLength = 0;
            try
            {
                stream = File.OpenRead(pStrFilePath);
                str = "";
                while ((pNLength = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    str = str + clsStringUtil.ToString(buffer, pNLength);
                }
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                    stream = null;
                }
            }
            return str;
        }
    }
}

