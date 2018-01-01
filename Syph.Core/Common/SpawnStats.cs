using Syph.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Syph.Core.Common
{
    public struct SpawnStats
    {
        public double health;
        public double armour;
        public double damage;
        public int energy;

        public SpawnStats(double health, double armour, double damage, int energy)
            : this()
        {
            this.health = health;
            this.armour = armour;
            this.damage = damage;
            this.energy = energy;
        }

        public override string ToString()
        {
            return $"Health: {this.health} | Armour: {this.armour} | Damage: {this.damage} | Energy: {this.energy}";
        }
    }
}
