using System;

namespace Syph.Core.Engine.Exceptions
{
    public class SpawnInventoryFullException : Exception
    {
        public SpawnInventoryFullException()
            : base()
        {
        }

        public SpawnInventoryFullException(string message)
            : base(message)
        {
        }

        public SpawnInventoryFullException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
