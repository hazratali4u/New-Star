namespace SAMS.Common.Classes
{
    using System;

    public class DataControl
    {
        public static decimal chkDecimalNull(string p_Val)
        {
            if ((p_Val == "") || (p_Val == null))
            {
                return -79228162514264337593543950335M;
            }
            return decimal.Parse(p_Val);
        }

        public static int chkIntNull(string p_Val)
        {
            if ((p_Val == "") || (p_Val == null))
            {
                return -2147483648;
            }
            return int.Parse(p_Val);
        }

        public string chkNull(string p_Val)
        {
            if ((p_Val == "") || (p_Val == null))
            {
                return (p_Val = "-1");
            }
            return p_Val;
        }

        public string chkNull_0(string p_Val)
        {
            if ((p_Val == "") || (p_Val == null))
            {
                return (p_Val = "0");
            }
            return p_Val;
        }

        public static string chkNull_Zero(string p_Val)
        {
            if ((p_Val == "") || (p_Val == null))
            {
                return (p_Val = "0");
            }
            return p_Val;
        }

        public static string getControlID(string p_ClientID)
        {
            int startIndex = p_ClientID.IndexOf("ctl") + 3;
            int index = p_ClientID.IndexOf("_lBtn");
            int num3 = int.Parse(p_ClientID.Substring(startIndex, index - startIndex)) - 2;
            return num3.ToString();
        }

        public static string getTextControlID(string p_ClientID)
        {
            int startIndex = p_ClientID.IndexOf("ctl") + 3;
            int index = p_ClientID.IndexOf("_txt");
            int num3 = int.Parse(p_ClientID.Substring(startIndex, index - startIndex)) - 2;
            return num3.ToString();
        }

        public static string getTextControlName(string p_ClientID)
        {
            int startIndex = p_ClientID.IndexOf("txt") + 3;
            int index = p_ClientID.IndexOf("Price");
            return p_ClientID.Substring(startIndex, index - startIndex);
        }

        public static void refreshData(string p_ClientID)
        {
        }
    }
}

