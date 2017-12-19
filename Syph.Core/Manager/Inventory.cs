using System;
using System.Collections.Generic;
using System.Text;
using Syph.Core.Contracts;

namespace Syph.Core.Manager
{
    public class Inventory : IInventory
    {
        private ISpawn[][] playerInventory = new ISpawn[][]
        {
            new ISpawn[3],
            new ISpawn[5],
            new ISpawn[7]
        };

        public ISpawn[][] PlayerInventory
        {
            get { return this.playerInventory; }

            set { this.playerInventory = value; }
        }
    }
}
