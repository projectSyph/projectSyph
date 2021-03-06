﻿using System;
using System.Collections.Generic;
using System.Text;
using Syph.Core.Contracts;
using System.Text.RegularExpressions;
using Syph.Core.Common;
using Syph.Core.Engine.Exceptions;
using Syph.Core.Manager;
using Syph.Core.Engine;
using System.Linq;

namespace Syph.Core.Models
{
    public delegate void PlayerJoin();

    public class Player : Entity, IPlayer
    {
        private IList<ISpawn> playerInventory;
        private Dictionary<SpawnRank, int> spawns;
        private IList<IPlayer> team;
        private int id;
        private bool isAlive;

        public Player(string name, int id, IList<IPlayer> team)
            : base(name, 8000, EntityType.Player)
        {
            this.id = id;
            this.team = team;
            this.playerInventory = new List<ISpawn>();
            this.isAlive = true;
            this.PlayerJoin += new PlayerJoin(WelcomeUser);

            this.spawns = new Dictionary<SpawnRank, int>
            {
                { SpawnRank.Junior, 7},
                { SpawnRank.Regular, 5},
                { SpawnRank.Senior, 3}
            };

            PlayerJoin();
        }

        public IList<ISpawn> Inventory => this.playerInventory;

        public int ID => this.id;

        public bool IsAlive => this.isAlive;

        public IList<IPlayer> Team => this.team;

        event PlayerJoin PlayerJoin;

        public void WelcomeUser()
        {
            FileLogger.Log($"Player {this.Name} with ID {this.id} entered the game.");
        }

        public void TakeDamage(int d)
        {
            this.Souls -= d;

            FileLogger.Log($" -- Player {this.Name} takes {d} damage");

            if (this.Souls <= 0)
            {
                Die();
            }
        }

        public void Die()
        {
            FileLogger.Log($" -- Player {this.Name} died.");

            this.isAlive = false;
        }

        public void Surrender()
        {
            FileLogger.Log($" -- Player {this.Name} surrendered.");

            this.isAlive = false;
        }

        public void Summon(ISpawn spawn)
        {
            if (this.spawns[spawn.Rank] <= 0)
            {
                throw new SpawnInventoryFullException("A Player cannot have more than 7 Junior, 5 Regular or 3 Senior Spawns!");
            }

            this.playerInventory.Add(spawn);

            this.spawns[spawn.Rank]--;

            FileLogger.Log($" -- Player {this.Name} has summoned {spawn.Rank} {spawn.Type} {spawn.Name}!");
        }

        public void ListInventory()
        {
            if (this.Inventory.Count == 0)
            {
                Console.WriteLine($"Player {this.Name}'s inventory is empty!");
                return;
            }

            ConsoleLogger.Print($"Player {this.Name}'s inventory:");
            foreach (ISpawn spawn in Inventory.OrderBy(x => x.Rank))
            {
                ConsoleLogger.Print($" - {spawn.Stats()}");
            }
        }
    }
}
