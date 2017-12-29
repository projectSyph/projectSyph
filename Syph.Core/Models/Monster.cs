using System;
using System.Collections.Generic;
using System.Text;

namespace Syph.Core.Models
{
    //name to be discussed
    public class Monster
    {
        private int health;
        private uint damage;
        private static int cost = 1000;
        private static int maxCount = 5;

        public Monster()
        {
            this.health = 1500;
            this.damage = 450;
        }
        public int Health { get { return this.health; } set { this.health = value; } }
        public uint Damage { get  { return this.damage; } }
        public static int Cost { get { return cost; } }
        public static int MaxCount { get { return maxCount; } }

    }
}