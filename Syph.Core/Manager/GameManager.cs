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
        private static ulong turn;

        public static void NewGame()
        {
            Console.Clear();

            
            int p = ValidateChoice("Players: ", 2, 4);
            players = new Player[p];
            log = new List<string>();
            turn = 0;

            for (int i = 0; i < p; i++)
            {
                try
                {
                    Console.Write($"Enter Player{i + 1}'s name: ");
                    players[i] = new Player(Console.ReadLine());
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
                    battleLogger.Log($"{players[i].Name}'s turn: {players[i].Souls} souls");

                    //THIS IS JUST FOR TESTING. IT IS NOT TO BE INCLUDED IN THE FINAL RELEASE
                    string command = Console.ReadLine().ToLower().Trim();
                    if (command == "summon")
                    {
                        if (players[i].Souls >= Monster.Cost)
                        {
                            if (players[i].Monsters.Count < Monster.MaxCount)
                            {
                                players[i].Monsters.Add(new Monster());
                                players[i].Souls -= Monster.Cost;
                                battleLogger.Log("You have summoned a monster");
                            }
                            else
                            {
                                battleLogger.Log($"You can't have more than {Monster.MaxCount} monsters");
                            }
                        }
                        else
                        {
                            battleLogger.Log($"You need at least {Monster.Cost} souls to summon a monster");
                        }
                    }
                    else if (command == "surrender")
                    {
                        battleLogger.Log("You have surrendered. Game Over");
                        inGame = false;
                        break;
                    }
                    else
                    {
                        battleLogger.Log("Unrecognised command. Please try again");
                        i--;
                    }
                    //////////////////////////////////////////////////////////////////////////
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
