using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Syph.Core.Contracts;

namespace Syph.Core.Engine
{
    public static class ConsoleLogger
    {
        public static void Print(string msg)
        {
            Console.WriteLine(msg);
        }

        public static void Print(string msg, uint ms)
        {
            Console.Write($"{msg}");
            Thread.Sleep(1000);
            Console.Clear();
        }

        public static void PrintAndWrite(string msg, IList<string> collection)
        {
            Console.WriteLine(msg);
            collection.Add($"{DateTime.Now.ToString("HH:mm:ss")} : {msg}");
        }
    }
}
