using System;

namespace Syph.Core.Engine.Exceptions
{
    public class InvalidEntityName : Exception
    {
        public InvalidEntityName()
            : base()
        {
        }

        public InvalidEntityName(string message)
            : base(message)
        {
        }

        public InvalidEntityName(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
