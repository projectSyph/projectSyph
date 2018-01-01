using System;
using Syph.Core.Common;
using Syph.Core.Contracts;
using Syph.Core.Engine.Exceptions;

namespace Syph.Core.Models
{
    public abstract class Spawn : Entity, ISpawn
    {
        private SpawnStats stats;
        private SpawnRank rank;

        public Spawn(string name, int souls)
            : base(name, (int)Math.Ceiling(0.2 * souls), EntityType.Spawn)
        {
            if (souls < 0 || souls > 4000) //NEED TO RECHECK FOR EXACT SOULS VALUES
            {
                throw new InvalidSpawnSummonException("You must use between 0 and 4000 souls to summon a Spawn!");
            }

            this.stats.health = 0.4 * souls;
            this.stats.armour = 0.2 * souls;
        }

        public double Health => this.stats.health;

        public double Armour => this.stats.armour;

        public double Damage
        {
            get => this.stats.damage;

            protected set => this.stats.damage = value;
        }

        public int Energy
        {
            get => this.stats.energy;

            protected set => this.stats.energy = value;
        }

        public SpawnRank Rank
        {
            get => this.rank;

            protected set => this.rank = value;
        }

        public override string ToString()
        {
            return $"{this.rank} {this.Type} {this.Name}";
        }

        public string Stats()
        {
            return $"{this.ToString()}: {this.stats.ToString()}";
        }
    }
}
