using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Syph.Core.Engine;
using Syph.Core.Models;

namespace Syph.Core.Manager
{
    public delegate void LoggerDelegate(string msg);

    public class GameManager
    {
        //TODO

        private static Player[] players;
        private static bool inGame;
        private static IList<string> log;
        private static ulong turn;

        public static void NewGame()
        {
            Console.Clear();

            int p = ValidateChoice("Players: ", 2, 4);
            players = new Player[p];
            log = new List<string>();
            LoggerDelegate logger = new LoggerDelegate(FileLogger.Log);
            turn = 0;

            for (int i = 0; i < p; i++)
            {
                try
                {
                    Console.Write($"Enter Player{i + 1}'s name: ");
                    players[i] = new Player(Console.ReadLine(), i);
                    ConsoleLogger.Print($"Player {players[i].Name} with ID {i} was created");
                }
                catch (Exception ex)
                {
                    ConsoleLogger.Print(ex.Message);
                    i--;
                }
            }

            inGame = true;

            ConsoleLogger.Print("", 1000);

            var battleLogger = new FileLogger();

            while (inGame)
            {
                turn++;

                for (int i = 0; i < p; i++)
                {
                    Console.WriteLine($"{players[i].Name}'s turn: {players[i].Souls} souls");

                    //JUST TESTING!!!
                    Console.WriteLine("Press 1");
                    Console.ReadKey();
                    logger("You are pressing a key");
                    players[0].TakeDamage(4000);
                    if (players[i].Souls <= 0)
                    {
                        inGame = false;
                        break;
                    }
                    /////////////////
                }
            }

            ConsoleLogger.Print($"{Environment.NewLine}Write BattleLog to file? (y/n): ");
            ConsoleKey choice = Console.ReadKey().Key;
            ConsoleLogger.Print(Environment.NewLine);

            if (choice == ConsoleKey.Y)
                battleLogger.WriteLog();
            Console.Clear();
        }

        private static byte ValidateChoice(string str, int lowerLimit = 0, int upperLimit = 4)
        {
            bool valid;
            byte num;

            do
            {
                Console.Write($"{str}");
                valid = byte.TryParse(Console.ReadLine(), out num);

                if ((!valid) || (num < lowerLimit) || (num > upperLimit))
                {
                    valid = false;
                    ConsoleLogger.Print("Invalid choice. Try again!");
                }

            } while (!valid);

            return num;
        }
    }
}
