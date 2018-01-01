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
        private const string hint = "Use F11 for Full-Screen mode";

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
            ConsoleLogger.Print(hint, 2000);
        }

        private static void MainMenu()
        {
            while (true)
            {
                ConsoleLogger.PrintTextFile(true, "logo", "menu");

                switch (ValidateMainMenuChoice("Choice: "))
                {
                    case 1:
                        GameManager.NewGame();
                        break;
                    case 2:
                        ConsoleLogger.PrintTextFile(true, "guide");
                        ConsoleLogger.PrintReturnToMenu();
                        break;
                    case 3:
                        ConsoleLogger.PrintTextFile(true, "credits");
                        ConsoleLogger.PrintReturnToMenu();
                        break;
                    case 4:
                        ConsoleLogger.PrintTextFile(true, "about");
                        ConsoleLogger.PrintReturnToMenu();
                        break;

                    case 0:
                        return;
                }
            }
        }

        private static byte ValidateMainMenuChoice(string str, int lowerLimit = 0, int upperLimit = 4)
        {
            bool valid;
            byte num;

            do
            {
                Console.Write($"{str}");
                valid = byte.TryParse(Console.ReadLine(), out num);

                if ((!valid) || (num < lowerLimit) || (num > upperLimit))
                {
                    ConsoleLogger.Print("Invalid choice. Try again!", 1000);
                    ConsoleLogger.PrintTextFile("logo", "menu");
                }
            } while (!valid);

            return num;
        }
    }
}
