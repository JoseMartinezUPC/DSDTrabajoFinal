using System;

namespace Domain.Core
{
    public class GuiaException : Exception
    {
        public GuiaException()
        { }

        public GuiaException(string message)
            : base(message)
        { }

        public GuiaException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
