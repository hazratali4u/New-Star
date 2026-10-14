namespace SAMS.Common.Classes
{
    using System;
    using System.Collections;
    using System.Text.RegularExpressions;

    public class NumberCaseInsensitiveComparer : CaseInsensitiveComparer
    {
        public int Compare(object x, object y)
        {
            try
            {
                if ((((x is string) && this.IsWholeNumber((string) x)) && (y is string)) && this.IsWholeNumber((string) y))
                {
                    return base.Compare(Convert.ToInt32(x), Convert.ToInt32(y));
                }
                return base.Compare(x, y);
            }
            catch (Exception exception)
            {
                ExceptionPublisher.PublishException(exception);
            }
            return -1;
        }

        private bool IsWholeNumber(string strNumber)
        {
            Regex regex = new Regex("[^0-9]");
            return !regex.IsMatch(strNumber);
        }
    }
}

