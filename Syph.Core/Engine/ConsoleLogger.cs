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

        public static void PrintNoNewLine(string msg)
        {
            Console.Write(msg);
        }

        public static void Print(string msg, uint ms)
        {
            Console.Write($"{msg}");
            Thread.Sleep(1000);
            Console.Clear();
        }

        public static void PrintTextFile(params string[] filenames)
        {
            foreach (var file in filenames)
            {
                if (!File.Exists($"./../content/{file}.txt"))
                {
                    throw new ArgumentException("File doesnt exist");
                }

                string text = File.ReadAllText($"./../content/{file}.txt");

                Print(text);
            }
        }

        public static void PrintTextFile(bool clear, params string[] filenames)
        {
            if (clear)
            {
                Console.Clear();
            }

            foreach (var file in filenames)
            {
                if (!File.Exists($"./../content/{file}.txt"))
                {
                    throw new ArgumentException("File doesnt exist");
                }

                string text = File.ReadAllText($"./../content/{file}.txt");

                Print(text);
            }
        }

        public static void PrintReturnToMenu()
        {
            Print("\nPress any key to go back to Main Menu..");
            Console.ReadKey();
            Console.Clear();
            PrintTextFile("logo", "menu");
        }
    }
}
