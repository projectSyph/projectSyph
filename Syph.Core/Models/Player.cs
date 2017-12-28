using System;
using System.Collections.Generic;
using System.Text;
using Syph.Core.Contracts;
using System.Text.RegularExpressions;
using Syph.Core.Common;

namespace Syph.Core.Models
{
    class Player : Entity, IPlayer
    {
        private string name;
        private int souls;
        private IList<ISpawn> playerInventory;
        private int juniors;
        private int regulars;
        private int seniors;
        private int id;

        public Player(string name, int id)
            : base(name, EntityType.Player)
        {
            this.name = name;

            this.souls = 8000;

            this.id = id;

            this.playerInventory = new List<ISpawn>();

            this.juniors = 0;
            this.regulars = 0;
            this.seniors = 0;
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
    }
}
