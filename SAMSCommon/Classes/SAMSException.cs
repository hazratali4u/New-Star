namespace SAMS.Common.Classes
{
    using System;

    public class SAMSException : Exception
    {
        public SAMSException(string Message, Exception InnerException) : base(Message, InnerException)
        {
        }
    }
}

