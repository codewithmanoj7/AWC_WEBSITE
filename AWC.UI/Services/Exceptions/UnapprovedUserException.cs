﻿namespace AWC.UI.Services.Exceptions
{
    public class UnapprovedUserException : ApplicationException
    {
        public UnapprovedUserException() : base()
        {

        }

        public UnapprovedUserException(string message) : base(message)
        {

        }
    }
}
