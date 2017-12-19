using System;
using System.Collections.Generic;
using System.Text;
using Syph.Core.Contracts;

namespace Syph.Core.Models
{
    class Player : IPlayer
    {
        private ISpawn[][] playerInventory = new ISpawn[][]
        {
            new ISpawn[3], //Senior
            new ISpawn[5], //Regular
            new ISpawn[7]  //Junior
        };

        private string name;

        private uint souls;

        public Player(string name)
        {
            //ADD VALIDATIONS
            this.name = name;

            this.souls = 8000;
        }

        public ISpawn[][] Inventory
        {
            get { return this.playerInventory; }

            set { this.playerInventory = value; }
        }

        public uint Souls
        {
            get { return this.souls; }
        }
    }
}
