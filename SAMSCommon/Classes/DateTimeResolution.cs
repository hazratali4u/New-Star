namespace SAMS.Common.Util.Date
{
    using System;

    public enum DateTimeResolution
    {
        Day = 0x80,
        Hour = 8,
        MilliSecond = 1,
        Minute = 4,
        Month = 0x20,
        Second = 2,
        Week = 0x40,
        Year = 0x10
    }
}

