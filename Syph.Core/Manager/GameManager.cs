using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Syph.Core.Engine;
using Syph.Core.Models;

namespace Syph.Core.Manager
{
    public class GameManager
    {
        //TODO

        private static Player[] players;
        private static bool inGame;
        private static IList<string> log;

        public static void NewGame()
        {
            Console.Clear();

            int p = ValidateChoice("Players: ", 2, 4);
            players = new Player[p];
            log = new List<string>();

            for (int i = 0; i < p; i++)
            {
                try
                {
                    Console.Write(i);
                    players[i] = new Player(Console.ReadLine());
                }
                catch
                {
                    i--;
                }
            }
            inGame = true;

            Console.Clear();

            var logger = new FileLogger();

            while (inGame)
            {
                for (int i = 0; i < p; i++)
                {
                    Console.WriteLine($"{players[i].Name}'s turn: {players[i].Souls} souls");
                    var a = Console.ReadKey();
                    if (a.Key == ConsoleKey.A)
                    {
                        players[i].TakeDamage(4000);
                        logger.Log($"{players[i].Name} takes 4000 damage");
                    }
                    else if (a.Key == ConsoleKey.W)
                    {
                        players[i].TakeDamage(-3000);
                        logger.Log($"{players[i].Name} heals");
                    }
                    if (players[i].Souls <= 0)
                    {
                        inGame = false;
                        logger.Log($"{players[i].Name} is dead{Environment.NewLine}Game Over");
                        break;
                    }
                }
            }

            logger.WriteLog();
            ConsoleLogger.Print("", 2000);
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
