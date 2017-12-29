using Syph.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Syph.Core.Models
{
    class JuniorSpawn : Spawn
    {
        public JuniorSpawn(string name, int souls) 
            : base(name, souls)
        {
            this.Rank = SpawnRank.Junior;
        }
    }
}
