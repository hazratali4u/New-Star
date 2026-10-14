namespace SAMS.Common.Util.Bit
{
    using System;

    public class clsMaskUtil
    {
        public const byte OffMask = 0;
        public const byte OnMask = 0xff;

        public static bool CheckByMask(byte pBValue, byte pBMask)
        {
            return ((pBValue & pBMask) == pBMask);
        }

        public static bool CheckByReverseMask(byte pBValue, byte pBReverseMask)
        {
            return ((pBValue | pBReverseMask) == pBReverseMask);
        }
    }
}

