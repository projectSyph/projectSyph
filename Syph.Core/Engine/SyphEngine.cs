using System;
using Syph.Core.Contracts;
using Syph.Core.Engine;
using Syph.Core.Manager;

namespace Syph.Core
{
    public sealed class SyphEngine : IEngine
    {
        private const string title = "projectSyph";
        private const string definition = "A project for Telerik Academy";
        private const string mainMenu = "1. New Game\n2. Guide\n3. Credits\n4. About\n\n0. Exit";

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

            switch (ValidateChoice("Choice: ", mainMenu))
            {
                case 1:
                    GameManager.NewGame();                    
                    break;
                case 2:
                    ConsoleLogger.PrintTextFile("guide");
                    break;
                case 3:
                    ConsoleLogger.PrintTextFile("credits");
                    break;
                case 4:
                    ConsoleLogger.PrintTextFile("about");
                    break;

                case 0:
                    return;
            }

            MainMenu();
        }

        private static byte ValidateChoice(string str, string backup, int lowerLimit = 0, int upperLimit = 4) 
        {
            bool valid;
            byte num;

            do
            {
                Console.Write($"{str}");
                valid = byte.TryParse(Console.ReadLine(), out num);

                
                if ((!valid))
                {
                    ConsoleLogger.Print("Invalid choice. Try again!", 1000);
                    Console.WriteLine(backup);
                }
                else if ((num < lowerLimit) || (num > upperLimit))
                {
                    ConsoleLogger.Print("Invalid choice. Try again!", 1000);
                    MainMenu();
                    break;
                }

            } while (!valid);

            return num;
        }
    }
}
