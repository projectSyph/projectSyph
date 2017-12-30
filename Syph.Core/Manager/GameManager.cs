using System;
using System.Collections.Generic;
using Syph.Core.Contracts;
using Syph.Core.Engine;
using Syph.Core.Models;
using Syph.Core.Factories;

namespace Syph.Core.Manager
{
    public static class GameManager
    {
        //TODO

        private static IList<IPlayer> players;
        private static bool inGame;
        private static IList<string> log;
        private static ulong turn;

        public static void NewGame()
        {
            Console.Clear();

            ///////
            int p = ValidateChoice("Players: ", 2, 3); // FIXME add 2 vs 2 mode
            players = new List<IPlayer>();
            ///////

            log = new List<string>();
            turn = 0;

            for (int i = 0; i < p; i++)
            {
                try
                {
                    ConsoleLogger.Print($"Enter Player {i + 1}'s name: ");
                    players.Add(PlayerFactory.CreateNewPlayer(Console.ReadLine(), i));
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

                foreach (var player in players)
                {
                    if (!inGame)
                    {
                        break;
                    }

                    FileLogger.Log($"{player.Name}'s turn: {player.Souls} souls");
                    bool stillPlayerTurn = true;

                    while (stillPlayerTurn)
                    {
                        ICommand command;
                        bool commandIsValid;
                        do
                        {
                            command = ReadCommand();
                            commandIsValid = command.IsValid();
                            if (!commandIsValid)
                            {
                                ConsoleLogger.Print($"Invalid command: {command.InvalidReason}. Try again! ");
                            }
                        } while (!commandIsValid);

                        //ProcessCommand(command);
                        switch (command.Name)
                        {
                            case "help":
                                ConsoleLogger.PrintTextFile("help");
                                break;

                            case "surrender":
                                if (players.Count== 2)
                                {
                                    inGame = false;
                                    stillPlayerTurn = false;
                                    FileLogger.Log($"Player {player.Name} has surrendered.");
                                }
                                else if (players.Count== 3)
                                {
                                    stillPlayerTurn = false;
                                    FileLogger.Log($"Player {player.Name} has surrendered.");
                                    players.Remove(player);
                                }
                                break;

                            case "attack":
                                string opponentName = command.Parameters[0];
                                string opponentMonsterType = command.Parameters[1];
                                string opponentMonsterID = command.Parameters[2];
                                string myMonsterType = command.Parameters[3];
                                string myMonsterID = command.Parameters[4];
                                throw new NotImplementedException();
                                //break;
                            case "summon":
                                throw new NotImplementedException();
                                //break;
                            default:
                                //return string.Format(InvalidCommand, command.Name);
                                throw new NotImplementedException();
                        }

                    }

                }
                /*
                {
                    //THIS IS JUST FOR TESTING. IT IS NOT TO BE INCLUDED IN THE FINAL RELEASE
                    string command = Console.ReadLine().ToLower().Trim();
                    if (command == "summon")
                    {
                        if (player.Souls >= Monster.Cost)
                        {
                            if (player.Monsters.Count < Monster.MaxCount)
                            {
                                player.Monsters.Add(new Monster());
                                player.Souls -= Monster.Cost;
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
<<<<<<< HEAD
                    /////////////////
=======
                    else
                    {
                        battleLogger.Log("Unrecognised command. Please try again");
                        i--;
                    }
                    //////////////////////////////////////////////////////////////////////////
>>>>>>> master
                }
                */
            }

            FileLogger.ConfirmWriteLog();
        }

        //Put this in its class
        private static ICommand ReadCommand()
        {
            ConsoleLogger.PrintNoNewLine("Enter command: ");
            string playerInputLine = Console.ReadLine().ToLower();
            Command currentCommand = new Command(playerInputLine);
            return currentCommand;
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
