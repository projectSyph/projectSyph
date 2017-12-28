using Syph.Core.Common;
using Syph.Core.Contracts;

namespace Syph.Core.Models
{
    public abstract class Spawn : Entity, ISpawn
    {
        private double health;
        private double damage;
        private double armour;
        private int energy;
        private int souls;
        private SpawnRank rank;

        public Spawn(string name, int souls)
            : base(name, EntityType.Spawn)
        {

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

        public int Souls => throw new System.NotImplementedException();

        public SpawnRank Rank => throw new System.NotImplementedException();
    }
}
