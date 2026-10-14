namespace SAMS.Common.Classes
{
    using System;

    public class SAMSUserException : Exception
    {
        public SAMSUserException(string Message, Exception InnerException) : base(Message, InnerException)
        {
        }
    }
}

