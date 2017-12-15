using System;
using System.Collections.Generic;
using System.Text;
using Syph.Core.Contracts;

namespace Syph.Core.Engine
{
    class ConsoleLogger : ILogger
    {
        //TODO

        public void Print(string message)
        {
            Console.WriteLine(message);
        }

        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
