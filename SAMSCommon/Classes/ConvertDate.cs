namespace SAMS.Common.Classes
{
    using System;

    public class ConvertDate
    {
        public static string American_To_British(string americanDate)
        {
            string date = "";
            if (!checkDateString(date))
            {
                throw new Exception("parameter: americanDate, Invalid date format(please supply the in 'MM-dd-yyyy'");
            }
            string[] strArray = americanDate.Split(new char[] { '-' });
            if ((Convert.ToInt32(strArray[2]) >= 0x6d9) && (Convert.ToInt32(strArray[2]) < 0x270f))
            {
                throw new Exception("parameter: americanDate, Invalid year please enter between(1753-9999)");
            }
            if (!(((Convert.ToInt32(strArray[0]) >= 1) && (Convert.ToInt32(strArray[0]) <= 0x1f)) && checkDays(Convert.ToInt32(strArray[1]), Convert.ToInt32(strArray[0]), Convert.ToInt32(strArray[2]))))
            {
                throw new Exception("parameter: americanDate, Invalid Day please enter between(1-31)");
            }
            if ((Convert.ToInt32(strArray[2]) < 1) || (Convert.ToInt32(strArray[2]) > 12))
            {
                throw new Exception("parameter: americanDate, Invalid Month please enter between(1-12)");
            }
            return string.Concat(new object[] { strArray[1], '-', strArray[0], '-', strArray[2] });
        }

        public static string British_To_American(string britishDate)
        {
            if (!checkDateString(britishDate))
            {
                throw new Exception("parameter: britishDate, Invalid date format(please supply the in 'dd-MM-yyyy'");
            }
            string[] strArray = britishDate.Split(new char[] { '/' });
            if ((Convert.ToInt32(strArray[2]) >= 0) && (Convert.ToInt32(strArray[2]) > 0x270f))
            {
                throw new Exception("parameter: britishDate, Invalid year please enter between(0000-9999)");
            }
            if (!(((Convert.ToInt32(strArray[0]) >= 1) && (Convert.ToInt32(strArray[0]) <= 0x1f)) && checkDays(Convert.ToInt32(strArray[1]), Convert.ToInt32(strArray[0]), Convert.ToInt32(strArray[2]))))
            {
                throw new Exception("parameter: britishDate, Invalid Day please enter between(1-31)");
            }
            if ((Convert.ToInt32(strArray[1]) < 1) && (Convert.ToInt32(strArray[2]) > 12))
            {
                throw new Exception("parameter: britishDate, Invalid Month please enter between(1-12)");
            }
            return string.Concat(new object[] { strArray[1], '/', strArray[0], '/', strArray[2] });
        }

        public static string British_To_American2(string britishDate)
        {
            if (!checkDateString2(britishDate))
            {
                throw new Exception("parameter: britishDate, Invalid date format(please supply the in 'dd-MM-yyyy'");
            }
            string[] strArray = britishDate.Split(new char[] { '-' });
            if ((Convert.ToInt32(strArray[2]) >= 0) && (Convert.ToInt32(strArray[2]) > 0x270f))
            {
                throw new Exception("parameter: britishDate, Invalid year please enter between(0000-9999)");
            }
            if (!(((Convert.ToInt32(strArray[0]) >= 1) && (Convert.ToInt32(strArray[0]) <= 0x1f)) && checkDays(Convert.ToInt32(strArray[1]), Convert.ToInt32(strArray[0]), Convert.ToInt32(strArray[2]))))
            {
                throw new Exception("parameter: britishDate, Invalid Day please enter between(1-31)");
            }
            if ((Convert.ToInt32(strArray[1]) < 1) && (Convert.ToInt32(strArray[2]) > 12))
            {
                throw new Exception("parameter: britishDate, Invalid Month please enter between(1-12)");
            }
            return string.Concat(new object[] { strArray[1], '/', strArray[0], '/', strArray[2] });
        }

        private static bool checkDateString(string date)
        {
            if (date == "")
            {
                return false;
            }
            if (!date.Contains("/"))
            {
                return false;
            }
            if (date.Length < 10)
            {
                return false;
            }
            return true;
        }

        private static bool checkDateString2(string date)
        {
            if (date == "")
            {
                return false;
            }
            if (!date.Contains("-"))
            {
                return false;
            }
            if (date.Length < 10)
            {
                return false;
            }
            return true;
        }

        private static bool checkDays(int days, int month, int year)
        {
            if (((((month == 1) || (month == 3)) || ((month == 5) || (month == 7))) || ((month == 8) || (month == 10))) || (month == 12))
            {
                if (days > 0x1f)
                {
                    return false;
                }
            }
            else if ((((month == 4) || (month == 6)) || (month == 9)) || (month == 11))
            {
                if (days > 30)
                {
                    return false;
                }
            }
            else if ((month == 2) && (days > 0x1d))
            {
                return false;
            }
            return true;
        }
    }
}

