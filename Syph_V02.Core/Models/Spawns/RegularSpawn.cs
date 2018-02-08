using Syph_V02.Core.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syph_V02.Core.Models.Spawns
{
    public class RegularSpawn : ISpawn
    {
        private string name;
        private int souls;

        public RegularSpawn(string name, int souls)
        {
            this.name = name;
            this.souls = souls;
        }
    }
}
