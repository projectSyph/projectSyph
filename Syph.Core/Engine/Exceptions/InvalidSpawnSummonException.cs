using System;

namespace Syph.Core.Engine.Exceptions
{
    public class InvalidSpawnSummonException : Exception
    {
        public InvalidSpawnSummonException()
            : base()
        {
        }

        public InvalidSpawnSummonException(string message)
            : base(message)
        {
        }

        public InvalidSpawnSummonException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
