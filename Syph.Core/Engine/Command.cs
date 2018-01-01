using Syph.Core.Common;
using Syph.Core.Contracts;
using Syph.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Syph.Core.Engine
{
    public class Command : ICommand
    {
        private const char SplitBySpace = ' ';
        private string name;
        private IList<string> parameters;
        private string invalidReason;

        public Command(string input)
        {
            this.parameters = new List<string>();
            this.TranslateInput(input.ToLower());
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                this.name = value.ToLower();
            }
        }

        public IList<string> Parameters
        {
            get
            {
                return this.parameters;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("List of strings cannot be null.");
                }

                this.parameters = value;
            }
        }

        public string InvalidReason { get => this.invalidReason; private set => this.invalidReason = value; }

        public static ICommand ReadCommand()
        {
            ConsoleLogger.PrintNoNewLine("Enter command: ");
            string playerInputLine = Console.ReadLine();

            return new Command(playerInputLine);
        }

        private void TranslateInput(string input)
        {
            string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (tokens.Length == 0)
            {
                this.name = string.Empty;
            }
            else
            {
                this.name = tokens[0];
            }
            if (tokens.Length > 1)
            {
                for (int i = 1; i < tokens.Length; i++)
                {
                    Parameters.Add(tokens[i]);
                }
            }
        }

        public bool IsValid(IList<IPlayer> alivePlayers, IPlayer player)
        {
            string monsterType = string.Empty, monsterName = string.Empty;
            switch (this.name)
            {
                case "help":
                    return true;
                case "summon":                    
                    if (!CheckParameterCount(3)) { return false; }

                    monsterType = Parameters[0];
                    if (!CheckMonsterType(monsterType)) { return false; }

                    monsterName = Parameters[1];
                    if (!Entity.IsValidName(monsterName)) { this.InvalidReason = Entity.InvalidEntityName; }

                    return true;
                case "inventory":
                    if (!CheckParameterCount(1))
                    {
                        return false;
                    }
                    string playerName = Parameters[0];
                    if (!alivePlayers.Any((p) => p.Name == playerName))
                    {
                        this.InvalidReason = $"{playerName} is not a valid player name";
                        return false;
                    }
                    return true;
                case "attack":
                    if (!CheckParameterCount(5))
                    {
                        return false;
                    }

                    string opponentName = Parameters[0];
                    if (!alivePlayers.Any((p) => p.Name == opponentName))
                    {
                        this.InvalidReason = $"{opponentName} is not a valid player name";
                        return false;
                    }
                    if (player.Name == opponentName)
                    {
                        this.InvalidReason = $"you can't attack yourself";
                        return false;
                    }
                    IPlayer opponent = alivePlayers.First((p) => p.Name == opponentName);
                    if (player.Team == opponent.Team)
                    {
                        this.InvalidReason = $"you can't attack a team member";
                        return false;
                    }
                    string opMonsterType = Parameters[1]; // opponent
                    string opMonsterName = Parameters[2];
                    string myMonsterType = Parameters[3];
                    string myMonsterName = Parameters[4];

                    if (!CheckMonsterType(opMonsterType))                            return false;
                    if (!CheckMonsterExists(opMonsterName, opMonsterType, opponent)) return false;
                    if (!CheckMonsterType(myMonsterType))                            return false;
                    if (!CheckMonsterExists(myMonsterName, myMonsterType, player))   return false;

                    /*
                    //oppo monster type 
                    string opponentMonsterType = Parameters[1];
                    SpawnRank opponentMonsterRank;
                    if (!(Enum.TryParse(opponentMonsterType, true, out opponentMonsterRank) && Enum.IsDefined(typeof(SpawnRank), opponentMonsterRank)))
                    {
                        this.InvalidReason = $"{opponentMonsterType} is not a valid monster type";
                        return false;
                    }

                    //oppo monster type and name
                    string opponentMonsterName = Parameters[2];
                    if (!opponent.Inventory.Any((ISpawn monster) => monster.Rank == opponentMonsterRank && monster.Name == opponentMonsterName))
                    {
                        this.InvalidReason = $"you don't have a monster named {opponentMonsterName} of rank {opponentMonsterRank}";
                        return false;
                    }

                    //my monster type
                    string myMonsterType = Parameters[3];
                    SpawnRank myMonsterRank;
                    if (!(Enum.TryParse(myMonsterType, true, out myMonsterRank) && Enum.IsDefined(typeof(SpawnRank), myMonsterRank)))
                    {
                        this.InvalidReason = $"{myMonsterType} is not a valid monster type";
                        return false;
                    }
                    //my monster type and name
                    string myMonsterName = Parameters[4];
                    if (!player.Inventory.Any((ISpawn monster) => monster.Rank == myMonsterRank && monster.Name == myMonsterName))
                    {
                        this.InvalidReason = $"you don't have a monster named {myMonsterName} of rank {myMonsterRank}";
                        return false;
                    }
                    */
                    return true;
                case "sacrifice":
                    {
                        if (!CheckParameterCount(2))                               return false;
                        monsterType = Parameters[0];
                        monsterName = Parameters[1];
                        if (!CheckMonsterType(monsterType))                        return false;
                        if (!CheckMonsterExists(monsterName, monsterType, player)) return false;
                        return true;
                    }
                case "surrender":
                    return true;
                case "":
                    this.InvalidReason = "command must not be empty";
                    return false;
                default:
                    this.InvalidReason = "command not recognised";
                    return false;
            }
        }

        private bool CheckMonsterType(string type)
        {
            SpawnRank rank;
            if (!(Enum.TryParse(type, true, out rank) && Enum.IsDefined(typeof(SpawnRank), rank)))
            {
                this.InvalidReason = $"{type} is not a valid monster type";
                return false;
            }
            return true;
        }

        private bool CheckMonsterExists(string name, string type, IPlayer player)
        {
            SpawnRank rank = (SpawnRank)Enum.Parse(typeof(SpawnRank), type);
            if (!player.Inventory.Any((ISpawn monster) => monster.Rank == rank && monster.Name == name))
            {
                this.InvalidReason = $"{player.Name} doesn't have a monster named {name} of rank {rank}";
                return false;
            }
            return true;
        }

        private bool CheckParameterCount(int count)
        {
            if (this.Parameters.Count != count)
            {
                this.InvalidReason = $"{this.Name} requires {count} parameters";
                return false;
            }
            return true;
        }
    }
}