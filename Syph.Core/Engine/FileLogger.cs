using Syph.Core.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Syph.Core.Engine
{
    class FileLogger : ILogger
    {
        private string location;

        FileLogger(string location)
        {
            this.location = location;
        }

        public void Print(string message)
        {
            File.WriteAllText(this.location, message);
        }

        public string Read()
        {
            throw new NotImplementedException();
        }
    }
}
