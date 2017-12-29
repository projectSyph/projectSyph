using System;

namespace Syph.Core.Engine.Exceptions
{
    public class InvalidEntityNameException : Exception
    {
        public InvalidEntityNameException()
            : base()
        {
        }

        public InvalidEntityNameException(string message)
            : base(message)
        {
        }

        public InvalidEntityNameException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
