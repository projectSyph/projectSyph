using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Syph.Core.Contracts;
using Syph.Core.Engine;
using Syph.Core.Factories;
using Syph.Core.Models;

namespace Syph.Core.Manager
{
    public static class GameManager
    {
        private static bool inGame;
        private static ulong turn;

        public static void NewGame()
        {
            Console.Clear();
            
            turn = 0;

            int playerCount = ValidateChoice("Players: ", 2, 4);
            int teamCount = 0;
            int playersPerTeam = 0;

            switch (playerCount)
            {
                case 2: case 4:
                    teamCount = 2;
                    break;
                case 3:
                    teamCount = 3;
                    break;
            }

            playersPerTeam = playerCount / teamCount;
            Dictionary<byte, List<IPlayer>> teams = new Dictionary<byte, List<IPlayer>>();

            for (byte teamIndex = 0; teamIndex < teamCount; teamIndex++)
            {
                teams.Add(teamIndex, new List<IPlayer>());

                for (byte i = 0; i < playersPerTeam; i++)
                {
                    try
                    {
                        ConsoleLogger.Print($"Enter Team {teamIndex + 1} Player {i + 1}'s name: ");
                        teams[teamIndex].Add(new Player(Console.ReadLine(), i, teams[teamIndex]));
                    }
                    catch (Exception ex)
                    {
                        ConsoleLogger.Print(ex.Message);
                        i--;
                    }
                }
            }
            
            IList<IPlayer> playersInGame = new List<IPlayer>();
            for (byte playerIndex = 0; playerIndex < playersPerTeam; playerIndex++)
            {
                for (byte teamInd = 0; teamInd < teamCount; teamInd++)
                {
                    playersInGame.Add(teams[teamInd][playerIndex]);
                }
            }

            FileLogger.Log("-------------------");

            inGame = true;

            ConsoleLogger.Print("", 1000);

            while (inGame)
            {
                turn++;

                foreach (var player in playersInGame)
                {
                    if (!inGame)
                    {
                        break;
                    }
                    if (!player.IsAlive)
                    {
                        continue;
                    }

                    FileLogger.Log($"{player.Name}'s turn: {player.Souls} souls");
                    bool stillPlayerTurn = true;

                    while (stillPlayerTurn)
                    {
                        ICommand command;
                        bool commandIsValid;

                        do
                        {
                            command = Command.ReadCommand();
                            commandIsValid = command.IsValid(playersInGame, player);
                            if (!commandIsValid)
                            {
                                ConsoleLogger.Print($"Invalid command: {command.InvalidReason}. Try again! ");
                            }
                        } while (!commandIsValid);
                        
                        switch (command.Name)
                        {
                            case "help":
                                ConsoleLogger.PrintTextFile("help");
                                break;

                            case "surrender":
                                player.Team.Remove(player);

                                player.Surrender();

                                stillPlayerTurn = false;
                                
                                int nonEmptyTeams = teams.Keys.Where(team => teams[team].Count > 0).Count();
                                inGame = nonEmptyTeams > 1;

                                break;

                            case "attack":
                                string opponentName = command.Parameters[0];
                                string opponentMonsterType = command.Parameters[1];
                                string opponentMonsterID = command.Parameters[2];
                                string myMonsterType = command.Parameters[3];
                                string myMonsterID = command.Parameters[4];

                                //STILL NOT IMPLEMENTED
                                throw new NotImplementedException();

                            case "summon":
                                string monsterType = command.Parameters[0];
                                string monsterName = command.Parameters[1];
                                int soulOffering = int.Parse(command.Parameters[2]);

                                switch (monsterType)
                                {
                                    case "junior":
                                        player.Summon(SpawnFactory.CreateJuniorSpawn(monsterName, soulOffering));
                                        break;

                                    case "regular":
                                        player.Summon(SpawnFactory.CreateRegularSpawn(monsterName, soulOffering));
                                        break;

                                    case "senior":
                                        player.Summon(SpawnFactory.CreateSeniorSpawn(monsterName, soulOffering));
                                        break;
                                }

                                stillPlayerTurn = false;
                                break;

                            default:
                                //STILL NOT IMPLEMENTED
                                throw new NotImplementedException();
                        }
                    }
                }
            }

            FileLogger.ConfirmWriteLog();
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
