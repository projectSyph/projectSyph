using System;
using System.IO;
using System.Threading;

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

        public static void PrintTextFile(string filename)
        {
            if (!File.Exists($"./../content/{filename}.txt"))
            {
                throw new ArgumentException("file doesnt exist");
            }

            string credits = File.ReadAllText($"./../content/{filename}.txt");

            Console.Clear();
            Console.WriteLine(credits);
            Console.WriteLine("\nPress any key to go back to Main Menu..");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
