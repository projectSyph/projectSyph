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


        /// <summary>
        /// Chofexx can print multiple files if it's neaded
        /// </summary>
        /// <param name="filenames"></param>
        public static void PrintTextFile(params string[] filenames)
        {
            foreach (var file in filenames)
            {
                if (!File.Exists($"./../content/{file}.txt"))
                {
                    throw new ArgumentException("File doesnt exist");
                }

                string credits = File.ReadAllText($"./../content/{file}.txt");

                //Console.Clear(); Chofexx- It,s messing up with logo printing
                Console.WriteLine(credits);
            }
          
            //Console.WriteLine("\nPress any key to go back to Main Menu..");
            //Console.ReadKey();
            //Console.Clear();
        }

        /// <summary>
        /// Print return to main menu - NOTE: can we use Print(str,uint) method ?
        /// </summary>
        public static void PrintReturnToMenu()
        {
            Console.WriteLine("\nPress any key to go back to Main Menu..");
            Console.ReadKey();
            Console.Clear();
            ConsoleLogger.PrintTextFile("menu");
        }

       
    }
}
