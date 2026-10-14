namespace SAMS.Common.Util.Strings
{
    using System;
    using System.Collections;
    using System.Text;

    public class clsStringUtil
    {
        private const bool TRIM_REQUIRED = false;

        public static int GetTokenCount(string pStrSource, string pStrDelimiter)
        {
            return GetTokens(pStrSource, pStrDelimiter).Length;
        }

        public static string[] GetTokens(string pStrSource, string pStrDelimiter)
        {
            ArrayList list = new ArrayList();
            string str = null;
            string pStrValue = null;
            int length = -1;
            pStrValue = pStrSource;
            if (!IsEmpty(pStrValue))
            {
                do
                {
                    length = pStrValue.IndexOf(pStrDelimiter, 0);
                    if (length > -1)
                    {
                        str = pStrValue.Substring(0, length);
                        list.Add(str);
                        pStrValue = pStrValue.Substring(length + pStrDelimiter.Length);
                    }
                }
                while (length > -1);
            }
            list.Add(pStrValue);
            return (string[]) list.ToArray(typeof(string));
        }

        public static bool IsEmpty(string pStrValue)
        {
            return IsEmpty(pStrValue, false);
        }

        public static bool IsEmpty(string pStrValue, bool pBTrimRequired)
        {
            return ((pStrValue == null) || (pBTrimRequired ? (pStrValue.Trim() == "") : (pStrValue == "")));
        }

        public static string Substring(string pStrSource, int pNStartIndex)
        {
            return Substring(pStrSource, pNStartIndex, pStrSource.Length);
        }

        public static string Substring(string pStrSource, int pNStartIndex, int pNLength)
        {
            string str = "";
            if (pNStartIndex >= pStrSource.Length)
            {
                return str;
            }
            if ((pNStartIndex + pNLength) <= pStrSource.Length)
            {
                return pStrSource.Substring(pNStartIndex, pNLength);
            }
            return pStrSource.Substring(pNStartIndex, pStrSource.Length - pNStartIndex);
        }

        public static byte[] ToByteArray(string pStrToConvert)
        {
            return ToByteArray(pStrToConvert, Encoding.Default);
        }

        public static byte[] ToByteArray(string pStrToConvert, Encoding pObjEncoding)
        {
            return pObjEncoding.GetBytes(pStrToConvert);
        }

        public static string ToDefaultString(string pStrValue, string pStrDefaultValue)
        {
            return ToDefaultString(pStrValue, pStrDefaultValue, false);
        }

        public static string ToDefaultString(string pStrValue, string pStrDefaultValue, bool pBTrimRequired)
        {
            string str = pBTrimRequired ? pStrDefaultValue.Trim() : pStrDefaultValue;
            if (!IsEmpty(pStrValue, pBTrimRequired))
            {
                str = pBTrimRequired ? pStrValue.Trim() : pStrValue;
            }
            return str;
        }

        public static string ToRepeatedString(char pCRepeatValue, long pLngRepetition)
        {
            return ToRepeatedString(pCRepeatValue.ToString(), pLngRepetition);
        }

        public static string ToRepeatedString(string pStrRepeatValue, long pLngRepetition)
        {
            string str = "";
            for (long i = 0L; i < pLngRepetition; i += 1L)
            {
                str = str + pStrRepeatValue;
            }
            return str;
        }

        public static string ToString(byte[] pBytArray)
        {
            return ToString(pBytArray, Encoding.Default);
        }

        public static string ToString(string pStrValue)
        {
            return ToString(pStrValue, false);
        }

        public static string ToString(string pStrValue, bool pBTrimRequired)
        {
            return ToDefaultString(pStrValue, string.Empty, pBTrimRequired);
        }

        public static string ToString(byte[] pBytArray, int pNLength)
        {
            return ToString(pBytArray, pNLength, Encoding.Default);
        }

        public static string ToString(byte[] pBytArray, Encoding pObjEncoding)
        {
            return ToString(pBytArray, pBytArray.Length, pObjEncoding);
        }

        public static string ToString(byte[] pBytArray, int pNLength, Encoding pObjEncoding)
        {
            int count = (pNLength <= pBytArray.Length) ? pNLength : pBytArray.Length;
            count = (pNLength < 0) ? 0 : pNLength;
            return pObjEncoding.GetString(pBytArray, 0, count);
        }

        public static string[] ToStringArray(byte[][] pBytNumbers)
        {
            string[] strArray = new string[pBytNumbers.Length];
            for (int i = 0; i < pBytNumbers.Length; i++)
            {
                strArray[i] = ToString(pBytNumbers[i]);
            }
            return strArray;
        }
    }
}

