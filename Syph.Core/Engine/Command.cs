﻿using Syph.Core.Common;
using Syph.Core.Contracts;
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
        private List<string> parameters;

        public Command(string input)
        {
            this.Parameters = new List<string>();
            this.TranslateInput(input);
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

        public List<string> Parameters
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

        public string InvalidReason { get; private set; }

        public bool IsValid(IList<IPlayer> alivePlayers, IPlayer player)
        {
            switch (this.Name)
            {
                case "help":
                    return true;
                case "summon":
                    if (this.Parameters.Count != 2)
                    {//TODO
                        this.InvalidReason = "summon requires two parameters";
                        return false;
                    }
                    throw new NotImplementedException();
                case "inventory":
                    if (this.Parameters.Count != 1)
                    {
                        this.InvalidReason = "you need to specify a player name";
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
                    throw new NotImplementedException();
                case "sacrifice":
                    if (this.Parameters.Count != 2)
                    {
                        this.InvalidReason = "sacrifice requires two parameters";
                        return false;
                    }
                    string monsterType = Parameters[0];
                    SpawnRank rank;
                    if (!(Enum.TryParse(monsterType, true, out rank) && Enum.IsDefined(typeof(SpawnRank), rank)))
                    {
                        this.InvalidReason = $"{monsterType} is not a valid monster type";
                        return false;
                    }
                    string monsterName = Parameters[1];
                    if (!player.Inventory.Any((ISpawn monster) => monster.Rank == rank && monster.Name == monsterName))
                    {
                        this.InvalidReason = $"you don't have a monster named {monsterName} of rank {rank}";
                        return false;
                    }
                    return true;
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

        private void TranslateInput(string input)
        {
            string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length == 0)
            {
                this.Name = string.Empty;
            }
            else
            {
                this.Name = tokens[0];
            }
            if (tokens.Length > 1)
            {
                for (int i = 1; i < tokens.Length; i++)
                {
                    Parameters.Add(tokens[i]);
                }
            }
        }
    }
}