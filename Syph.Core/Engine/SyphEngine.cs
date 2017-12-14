using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Syph.Core.Contracts;

namespace Syph.Core
{
    public sealed class SyphEngine : IEngine
    {
        private static readonly string title = "projectSyph";
        private static readonly string definition = "A project for Telerik Academy";
        private static readonly string mainMenu = "1. New Game\n2. Options\n3. Guide\n\n0. Exit";

        //private static List<string> battleLog;

        private readonly ILogger logger;

        private static readonly SyphEngine engine = new SyphEngine();

        public SyphEngine()
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

        private static void Print(string str) 
        {
            Console.WriteLine(str);
        }

        private static void Print(string str, uint ms) 
        {
            Console.Write($"{str}");
            Thread.Sleep(1000);
            Console.Clear();
        }

        private static void Intro() 
        {
            Print(title, 1000);
            Print(definition, 1000);
        }

        private static void MainMenu()
        {
            Print(mainMenu);

            switch (ValidateChoice("Choice: "))
            {
                case 1: break;
                case 2: break;
                case 3: break;

                case 0: return;
            }
        }

        private static ushort ValidateChoice(string str) 
        {
            bool valid;
            ushort num;

            do
            {
                Console.Write($"{str}");
                valid = ushort.TryParse(Console.ReadLine(), out num);

                if (!valid)
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
    }
}
