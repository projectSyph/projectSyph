using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Syph.Core.Contracts;
using Syph.Core.Engine;
using Syph.Core.Models;

namespace Syph.Core.Manager
{
    public static class GameManager
    {
        //TODO

        private static Player[] players;
        private static bool inGame;
        private static IList<string> log;
        private static ulong turn;

        public static void NewGame()
        {
            Console.Clear();

            int p = ValidateChoice("Number of players: ", 2, 4);
            players = new Player[p];
            log = new List<string>();
            turn = 0;

            for (int i = 0; i < p; i++)
            {
                try
                {
                    ConsoleLogger.Print($"Enter Player {i + 1}'s name: ");
                    players[i] = new Player(Console.ReadLine(), i);
                }
                catch (Exception ex)
                {
                    ConsoleLogger.Print(ex.Message);
                    i--;
                }
            }

            FileLogger.Log("-------------------");

            inGame = true;

            ConsoleLogger.Print("", 1000);

            while (inGame)
            {
                turn++;

                for (int i = 0; i < p; i++)
                {
                    FileLogger.Log($"{players[i].Name}'s turn: {players[i].Souls} souls");

                    //JUST TESTING!!!
                    ConsoleLogger.Print("Press a key or smth");
                    FileLogger.Log(Console.ReadKey().Key.ToString());
                    players[0].TakeDamage(2000);
                    if (players[i].Souls <= 0)
                    {
                        inGame = false;
                        break;
                    }
                    /////////////////
                }
            }

            ConfirmWriteLog();
        }

        private static void ConfirmWriteLog()
        {
            while (true)
            {
                ConsoleLogger.Print($"{Environment.NewLine}Write BattleLog to file? (Yes/No): ");
                string choice = Console.ReadLine().ToLower();

                switch (choice)
                {
                    case "yes":
                    case "y":
                        FileLogger.WriteLog();
                        Console.Clear();
                        return;

                    case "no":
                    case "n":
                        FileLogger.Clear();
                        Console.Clear();
                        return;

                    default:
                        ConsoleLogger.Print("Invalid choice. Try again!");
                        break;
                }
            }
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
