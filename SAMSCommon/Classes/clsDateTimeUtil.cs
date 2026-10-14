namespace SAMS.Common.Util.Date
{
    using SAMS.Common.Util.Bit;
    using System;
    using System.Globalization;

    public class clsDateTimeUtil
    {
        public const char CHR_FULL_DATE_TIME_FORMAT = 'F';
        protected static byte DAYS_PER_MONTH = 30;
        protected static byte DAYS_PER_WEEK = 7;
        protected static short DAYS_PER_YEAR = 0x16d;
        protected static string FULL_DATE_TIME_FORMAT = "yyyy-MM-dd HH:mm:ss";
        public const string FULL_DATE_TIME_FORMAT_IMPORT = "yyyyMMddHHmmss";
        public const string STR_DB_LONG_DATE_FORMAT = "yyy/MM/dd hh:mm:ss.fff";
        public const string STR_DB_SHORT_DATE_FORMAT = "MM/dd/yyyy";
        public const string STR_STD_DATE_FORMAT = "dd-MMM-yyyy";

        public static DateTime Add(DateTime pDtmSource, DateTime pDtmDestination, DateTimeResolution pEnmResolution)
        {
            DateTime time = pDtmDestination;
            if (clsMaskUtil.CheckByMask((byte) pEnmResolution, 0x10))
            {
                time = time.AddYears(pDtmSource.Year);
            }
            if (clsMaskUtil.CheckByMask((byte) pEnmResolution, 0x20))
            {
                time = time.AddMonths(pDtmSource.Month);
            }
            if (clsMaskUtil.CheckByMask((byte) pEnmResolution, 0x80))
            {
                time = time.AddDays((double) pDtmSource.Day);
            }
            if (clsMaskUtil.CheckByMask((byte) pEnmResolution, 8))
            {
                time = time.AddHours((double) pDtmSource.Hour);
            }
            if (clsMaskUtil.CheckByMask((byte) pEnmResolution, 4))
            {
                time = time.AddMinutes((double) pDtmSource.Minute);
            }
            if (clsMaskUtil.CheckByMask((byte) pEnmResolution, 2))
            {
                time = time.AddSeconds((double) pDtmSource.Second);
            }
            if (clsMaskUtil.CheckByMask((byte) pEnmResolution, 1))
            {
                time = time.AddMilliseconds((double) pDtmSource.Second);
            }
            return time;
        }

        public static DateTime Add(DateTime pDtmSource, int pNValue, DateTimeResolution pEnmResolution)
        {
            DateTime time = pDtmSource;
            if (clsMaskUtil.CheckByMask((byte) pEnmResolution, 0x10))
            {
                time = time.AddYears(pNValue);
            }
            if (clsMaskUtil.CheckByMask((byte) pEnmResolution, 0x20))
            {
                time = time.AddMonths(pNValue);
            }
            if (clsMaskUtil.CheckByMask((byte) pEnmResolution, 0x80))
            {
                time = time.AddDays((double) pNValue);
            }
            if (clsMaskUtil.CheckByMask((byte) pEnmResolution, 0x40))
            {
                time = time.AddDays((double) (pNValue * 7));
            }
            if (clsMaskUtil.CheckByMask((byte) pEnmResolution, 8))
            {
                time = time.AddHours((double) pNValue);
            }
            if (clsMaskUtil.CheckByMask((byte) pEnmResolution, 4))
            {
                time = time.AddMinutes((double) pNValue);
            }
            if (clsMaskUtil.CheckByMask((byte) pEnmResolution, 2))
            {
                time = time.AddSeconds((double) pNValue);
            }
            if (clsMaskUtil.CheckByMask((byte) pEnmResolution, 1))
            {
                time = time.AddMilliseconds((double) pNValue);
            }
            return time;
        }

        public static DateTime AddWeeks(DateTime pDtmSource, int pNWeek)
        {
            return pDtmSource.AddDays((double) (pNWeek * 7));
        }

        public static DateTime DayDateTimeOfMonth(int pNDay, DateTime pDtmMonth)
        {
            return new DateTime(pDtmMonth.Year, pDtmMonth.Month, pNDay);
        }

        public static DateTime FirstDayDateTimeOfMonth(DateTime pDtmMonth)
        {
            return DayDateTimeOfMonth(1, pDtmMonth);
        }

        public static double GetPeriodByResolution(TimeSpan pTspSource, DateTimeResolution pEnmResolution)
        {
            double num = -1.0;
            DateTimeResolution resolution = pEnmResolution;
            if (resolution <= DateTimeResolution.Year)
            {
                switch (resolution)
                {
                    case DateTimeResolution.MilliSecond:
                        return pTspSource.TotalMilliseconds;

                    case DateTimeResolution.Second:
                        return pTspSource.TotalSeconds;

                    case (DateTimeResolution.Second | DateTimeResolution.MilliSecond):
                        return num;

                    case DateTimeResolution.Minute:
                        return pTspSource.TotalMinutes;

                    case DateTimeResolution.Hour:
                        return pTspSource.TotalHours;

                    case DateTimeResolution.Year:
                        return (pTspSource.TotalDays / ((double) DaysPerYear));
                }
                return num;
            }
            switch (resolution)
            {
                case DateTimeResolution.Month:
                    return (pTspSource.TotalDays / ((double) DaysPerMonth));

                case DateTimeResolution.Week:
                    return (pTspSource.TotalDays / ((double) DaysPerWeek));

                case DateTimeResolution.Day:
                    return pTspSource.TotalDays;
            }
            return num;
        }

        public static bool IsValid(string pStrDate)
        {
            return IsValid(pStrDate, null, DateTimeStyles.None);
        }

        public static bool IsValid(string pStrDate, IFormatProvider pObjFormatProvider)
        {
            return IsValid(pStrDate, pObjFormatProvider, DateTimeStyles.None);
        }

        public static bool IsValid(string pStrDate, IFormatProvider pObjFormatProvider, DateTimeStyles pObjDateTimeStyle)
        {
            bool flag = true;
            try
            {
                if (pObjFormatProvider == null)
                {
                    DateTime.Parse(pStrDate);
                    return flag;
                }
                DateTime.Parse(pStrDate, pObjFormatProvider, pObjDateTimeStyle);
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public static DateTime ParseExact(string pStrDateTime, string pstrFormat, string pStrFormatPattern)
        {
            DateTimeFormatInfo provider = new DateTimeFormatInfo {
                FullDateTimePattern = pStrFormatPattern
            };
            return DateTime.ParseExact(pStrDateTime, pstrFormat ?? "", provider);
        }
        
        public static DateTime ParseFullDateTimeImport(string pStrDateTime)
        {
            return ParseExact(pStrDateTime, "yyyyMMddHHmmss", FullDateTimeFormat);
        }

        public static DateTime ToDateTime(object pObjDateTime)
        {
            DateTime nullDateTime = NullDateTime;
            try
            {
                nullDateTime = (DateTime) pObjDateTime;
                return ToDateTime(pObjDateTime.ToString());
            }
            catch
            {
                return NullDateTime;
            }
        }

        public static DateTime ToDateTime(string pStrDateTime)
        {
            DateTime nullDateTime = NullDateTime;
            try
            {
                return DateTime.Parse(pStrDateTime);
            }
            catch
            {
                return NullDateTime;
            }
        }

        public static string ToFullDateTimeString(DateTime pDtmSource)
        {
            return ToFullDateTimeString(pDtmSource, 'F', FullDateTimeFormat);
        }

        public static string ToFullDateTimeString(DateTime pDtmSource, char pChrFormat, string pStrFormatPattern)
        {
            DateTimeFormatInfo provider = new DateTimeFormatInfo {
                FullDateTimePattern = pStrFormatPattern
            };
            return pDtmSource.ToString(pChrFormat.ToString(), provider);
        }

        public static string ToLongDateTimeFormat(DateTime pDtmValue)
        {
            return pDtmValue.ToString("yyy/MM/dd hh:mm:ss.fff");
        }

        public static string ToShortDateTimeFormat(DateTime pDtmValue)
        {
            return pDtmValue.ToString("MM/dd/yyyy");
        }

        public static string ToStandardDateFormat(DateTime pDtmValue)
        {
            return pDtmValue.ToString("dd-MMM-yyyy");
        }

        public static byte DaysPerMonth
        {
            get
            {
                return DAYS_PER_MONTH;
            }
            set
            {
                DAYS_PER_MONTH = value;
            }
        }

        public static byte DaysPerWeek
        {
            get
            {
                return DAYS_PER_WEEK;
            }
            set
            {
                DAYS_PER_WEEK = value;
            }
        }

        public static short DaysPerYear
        {
            get
            {
                return DAYS_PER_YEAR;
            }
            set
            {
                DAYS_PER_YEAR = value;
            }
        }

        public static DateTime FirstDayDateTimeOfCurrentMonth
        {
            get
            {
                return DayDateTimeOfMonth(1, DateTime.Now);
            }
        }

        public static string FullDateTimeFormat
        {
            get
            {
                return FULL_DATE_TIME_FORMAT;
            }
            set
            {
                FULL_DATE_TIME_FORMAT = value;
            }
        }

        public static DateTime NullDateTime
        {
            get
            {
                return new DateTime(0x76c, 1, 1, 0, 0, 0, 0);
            }
        }
    }
}

