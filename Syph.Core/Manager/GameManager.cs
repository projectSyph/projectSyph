using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Syph.Core.Contracts;
using Syph.Core.Engine;
using Syph.Core.Models;

namespace Syph.Core.Manager
{
    public static class GameManager
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
            IList<IList<IPlayer>> teams = new List<IList<IPlayer>>();
            //TODO
            //Dictionary<char, List<Player>> teams = new Dictionary<char, List<Player>>();
            for (int teamIndex = 0; teamIndex < teamCount; teamIndex++)
            {
                teams.Add(new List<IPlayer>());

                for (int i = 0; i < playersPerTeam; i++)
                {
                    try
                    {
                        Console.Write($"Team {teamIndex}, enter player {i + 1}'s name: ");
                        teams[teamIndex].Add(new Player(Console.ReadLine(), i, teams[teamIndex]));
                    }
                    catch (Exception ex)
                    {
                        ConsoleLogger.Print(ex.Message);
                        i--;
                    }
                }
            }
            // players ordered by their turn, e.g. A1, B1, C1, A2, B2, ...
            IList<IPlayer> alivePlayers = new List<IPlayer>();
            for (int playerInd = 0; playerInd < playersPerTeam; playerInd++)
            {
                for (int teamInd = 0; teamInd < teamCount; teamInd++)
                {
                    alivePlayers.Add(teams[teamInd][playerInd]);
                }
            }

            FileLogger.Log("-------------------");

            inGame = true;

            ConsoleLogger.Print("", 1000);

            while (inGame)
            {
                turn++;

                foreach (var player in alivePlayers)
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
                            commandIsValid = command.IsValid(alivePlayers, player);
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
                                FileLogger.Log($"Player {player.Name} has surrendered.");

                                player.Team.Remove(player);
                                alivePlayers.Remove(player);
                                stillPlayerTurn = false;

                                IEnumerable<IList<IPlayer>> nonEmptyTeams = teams.Where((team) => team.Count > 0);
                                inGame = nonEmptyTeams.Count() > 1;
                                break;

                            case "attack":
                                string opponentName = command.Parameters[0];
                                string opponentMonsterType = command.Parameters[1];
                                string opponentMonsterID = command.Parameters[2];
                                string myMonsterType = command.Parameters[3];
                                string myMonsterID = command.Parameters[4];
                                throw new NotImplementedException();
                            case "summon":
                                throw new NotImplementedException();
                            default:
                                //return string.Format(InvalidCommand, command.Name);
                                throw new NotImplementedException();
                        }
                    }
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
