using System;
using System.Collections.Generic;
using System.Text;
using Syph.Core.Contracts;
using System.Text.RegularExpressions;
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

        // FIXME  switch back to 3 types of monsters, use interface
        private List<Monster> monsters = new List<Monster>();

        private string name;

        private int souls;

        public Player(string name)
        {
            //ADD VALIDATIONS
            if (string.IsNullOrEmpty(name) || name.Length < 4 || name.Length>15 )
            {
                throw new ArgumentException("Name of player is invalid");
            }
            this.name = name;

            this.Souls = 8000;
        }

        //FIXME switch back from temp Monsters property to Inventory property
        public ISpawn[][] Inventory
        {
            get { return this.playerInventory; }

            set { this.playerInventory = value; }
        }

        public List<Monster> Monsters { get { return this.monsters; } }

        public string Name { get { return this.name; } }
        public int Souls
        {
            get { return this.souls; }
            set { this.souls = value; }
        }

        public void TakeDamage(int d)
        {
            this.Souls -= d;
        }
    }
}
