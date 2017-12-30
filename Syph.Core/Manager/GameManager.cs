﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Syph.Core.Engine;
using Syph.Core.Models;
using Syph.Core.Contracts;
using System.Linq;

namespace Syph.Core.Manager
{

    public class GameManager
    {

        private static bool inGame;
        private static IList<string> log;
        private static ulong turn;

        public static void NewGame()
        {
            Console.Clear();

            log = new List<string>();
            turn = 0;

            int playerCount = ValidateChoice("Players: ", 2, 4);
            int teamCount = 0;
            int playersPerTeam = 0;
            switch (playerCount)
            {
                case 2:
                case 4:
                    teamCount = 2;
                    break;
                case 3:
                    teamCount = 3;
                    break;
            }
            playersPerTeam = playerCount / teamCount;
            List<List<Player>> teams = new List<List<Player>>();
            //TODO
            //Dictionary<char, List<Player>> teams = new Dictionary<char, List<Player>>();
            for (int teamIndex = 0; teamIndex < teamCount; teamIndex++)
            {
                teams.Add(new List<Player>());

                for (int i = 0; i < playersPerTeam; i++)
                {
                    try
                    {
                        Console.Write($"Team {teamIndex}, enter player {i + 1}'s name: ");
                        teams[teamIndex].Add(new Player(Console.ReadLine(), teams[teamIndex]));
                        ConsoleLogger.Print($"Player {teams[teamIndex][i].Name} was created");
                    }
                    catch (Exception ex)
                    {
                        ConsoleLogger.Print(ex.Message);
                        i--;
                    }
                }
            }
            // players ordered by their turn, e.g. A1, B1, C1, A2, B2, ...
            List<Player> turnOrder = new List<Player>();
            for (int playerInd = 0; playerInd < playersPerTeam; playerInd++)
            {
                for (int teamInd = 0; teamInd < teamCount; teamInd++)
                {
                    turnOrder.Add(teams[teamInd][playerInd]);
                }
            }


            inGame = true;

            ConsoleLogger.Print("", 1000);

            var battleLogger = new FileLogger();

            while (inGame)
            {
                turn++;

                foreach (var player in turnOrder)
                {
                    if (!inGame)
                    {
                        break;
                    }
                    battleLogger.Log($"{player.Name}'s turn: {player.Souls} souls");
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
                                battleLogger.Log($"Player {player.Name} has surrendered.");

                                player.Team.Remove(player);
                                stillPlayerTurn = false;

                                IEnumerable<List<Player>> nonEmptyTeams = teams.Where((team) => team.Count > 0);
                                inGame = nonEmptyTeams.Count() > 1;
                                break;

                            case "attack":
                                string opponentName = command.Parameters[0];
                                string opponentMonsterType = command.Parameters[1];
                                string opponentMonsterID = command.Parameters[2];
                                string myMonsterType = command.Parameters[3];
                                string myMonsterID = command.Parameters[4];
                                throw new NotImplementedException();
                                break;
                            case "summon":
                                throw new NotImplementedException();
                                break;
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
                    else
                    {
                        battleLogger.Log("Unrecognised command. Please try again");
                        i--;
                    }
                    //////////////////////////////////////////////////////////////////////////
                }
                */
            }

            ConsoleLogger.Print($"{Environment.NewLine}Game Over." +
                                $"{Environment.NewLine}Write BattleLog to file? (y/n): ");
            ConsoleKey choice = Console.ReadKey().Key;
            ConsoleLogger.Print(Environment.NewLine);

            if (choice == ConsoleKey.Y)
                battleLogger.WriteLog();
            Console.Clear();
        }
        private static ICommand ReadCommand()
        {
            ConsoleLogger.PrintNoNewLine("Enter command: ");
            string playerInputLine = Console.ReadLine();
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
