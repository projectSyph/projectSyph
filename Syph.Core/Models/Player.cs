using System;
using System.Collections.Generic;
using System.Text;
using Syph.Core.Contracts;
using System.Text.RegularExpressions;
using Syph.Core.Common;
using Syph.Core.Engine.Exceptions;

namespace Syph.Core.Models
{
    class Player : Entity, IPlayer
    {
        private int souls;
        private IList<ISpawn> playerInventory;
        private Dictionary<SpawnRank, int> spawns;
        private int id;

        public Player(string name, int id)
            : base(name, EntityType.Player)
        {
            this.souls = 8000;

            this.id = id;

            this.playerInventory = new List<ISpawn>();

            this.spawns = new Dictionary<SpawnRank, int>
            {
                { SpawnRank.Junior, 7},
                { SpawnRank.Regular, 5},
                { SpawnRank.Senior, 3}
            };
        }

        public IList<ISpawn> Inventory
        {
            get => this.playerInventory;
        }

        public int Souls => this.souls;

        public int ID => this.id;

        public void TakeDamage(int d)
        {
            this.souls -= d;
        }

        public void Summon(ISpawn spawn)
        {
            if (this.spawns[spawn.Rank] <= 0)
            {
                throw new SpawnInventoryFullException("A Player cannot have more than 7 Junior, 5 Regular or 3 Senior Spawns!");
            }

            this.playerInventory.Add(spawn);

            this.spawns[spawn.Rank]--;
        }
    }
}
