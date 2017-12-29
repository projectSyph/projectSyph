using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Syph.Core.Contracts;
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
                }
                catch (Exception ex)
                {
                    ConsoleLogger.Print(ex.Message);
                    i--;
                }
            }

            inGame = true;

            ConsoleLogger.Print("", 1000);

            FileLogger battleLogger = new FileLogger();

            while (inGame)
            {
                turn++;

                for (int i = 0; i < p; i++)
                {
                    logger($"{players[i].Name}'s turn: {players[i].Souls} souls");

                    //JUST TESTING!!!
                    ConsoleLogger.Print("Press a key or smth");
                    logger(Console.ReadKey().Key.ToString());
                    players[0].TakeDamage(2000);
                    if (players[i].Souls <= 0)
                    {
                        inGame = false;
                        break;
                    }
                    /////////////////
                }
            }

            ConfirmWriteLog(battleLogger);
        }

        private static void ConfirmWriteLog(FileLogger logger)
        {
            ConsoleLogger.Print($"{Environment.NewLine}Write BattleLog to file? (y/n): ");
            ConsoleKey choice = Console.ReadKey().Key;
            ConsoleLogger.Print(Environment.NewLine);

            if (choice == ConsoleKey.Y)
                logger.WriteLog();
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
