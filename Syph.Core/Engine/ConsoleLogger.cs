using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Syph.Core.Contracts;

namespace Syph.Core.Engine
{
    public class ConsoleLogger : ILogger
    {
        //TODO

        public static void Print(string str)
        {
            Console.WriteLine(str);
        }

        public static void Print(string str, uint ms)
        {
            Console.Write($"{str}");
            Thread.Sleep(1000);
            Console.Clear();
        }
    }
}
