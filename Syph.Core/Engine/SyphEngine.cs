using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Syph.Core.Contracts;
using Syph.Core.Engine;

namespace Syph.Core
{
    public sealed class SyphEngine : IEngine
    {
        private static readonly string title = "projectSyph";
        private static readonly string definition = "A project for Telerik Academy";
        private static readonly string mainMenu = "1. New Game\n2. Guide\n3. Credits\n\n0. Exit";

        //private static List<string> battleLog;

        private readonly ILogger logger;

        private static readonly SyphEngine engine = new SyphEngine();

        private SyphEngine()
        {

        }

        public static SyphEngine Instance 
        {
            get
            {
                return engine;
            }
        }

        public void Start()
        {
            //Intro();
            MainMenu();
        }

        private static void Intro() 
        {
            ConsoleLogger.Print(title, 1000);
            ConsoleLogger.Print(definition, 1000);
        }

        private static void MainMenu()
        {

            ConsoleLogger.Print(mainMenu);

            switch (ValidateChoice("Choice: "))
            {
                case 1: break;
                case 2: Guide(); break;
                case 3: Credits(); break;

                case 0: return;
            }
        }

        private static byte ValidateChoice(string str) 
        {
            bool valid;
            byte num;

            do
            {
                Console.Write($"{str}");
                valid = byte.TryParse(Console.ReadLine(), out num);

                if (!valid || num > 3)
                {
                    Console.WriteLine("Invalid choice. Try again!");
                    Thread.Sleep(1000);
                    Console.Clear();
                    MainMenu();
                    break;
                }

            } while (!valid);

            return num;
        }

        public static void Guide()
        {
            string credits = File.ReadAllText("./../content/guide.txt");

            Console.Clear();
            Console.WriteLine(credits);
            Console.WriteLine("\nPress any key to go back to Main Menu..");
            Console.ReadKey();
            Console.Clear();

            MainMenu();
        }

        public static void Credits()
        {
            string credits = File.ReadAllText("./../content/credits.txt");

            Console.Clear();
            Console.WriteLine(credits);
            Console.WriteLine("\nPress any key to go back to Main Menu..");
            Console.ReadKey();
            Console.Clear();

            MainMenu();
        }
    }
}
