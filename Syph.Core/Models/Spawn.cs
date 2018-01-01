using System;
using Syph.Core.Common;
using Syph.Core.Contracts;
using Syph.Core.Engine.Exceptions;

namespace Syph.Core.Models
{
    public abstract class Spawn : Entity, ISpawn
    {
        private double health;
        private double damage;
        private double armour;
        private int energy;
        private SpawnRank rank;

        public Spawn(string name, int souls)
            : base(name, (int)Math.Ceiling(0.2 * souls), EntityType.Spawn)
        {
            if (souls < 0 || souls > 4000) //NEED TO RECHECK FOR EXACT SOULS VALUES
            {
                throw new InvalidSpawnSummonException("You must use between 0 and 4000 souls to summon a Spawn!");
            }

            this.health = 0.4 * souls;
            this.armour = 0.2 * souls;
        }

        public double Health => this.health;

        public double Damage
        {
            get => this.damage;

            protected set => this.damage = value;
        }

        public double Armour => this.armour;

        public int Energy
        {
            get => this.energy;

            protected set => this.energy = value;
        }

        public SpawnRank Rank
        {
            get => this.rank;

            set => this.rank = value;
        }

        public override string ToString()
        {
            return $"{this.rank} {this.Type} {this.Name}";
        }
    }
}
