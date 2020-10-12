using System;

namespace HandsOnTest.Business.Exeption
{
    public class HandsOnTestException : Exception
    {
        public HandsOnTestException(string exceptionMessage)
        {
            ExceptionMessage = exceptionMessage;
        }

        public string ExceptionMessage { get; set; }
    }
}
