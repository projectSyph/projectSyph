using Syph.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Syph.Core.Models
{
    public class SeniorSpawn : Spawn
    {
        public SeniorSpawn(string name, int souls) 
            : base(name, souls)
        {
            this.Rank = SpawnRank.Senior;
        }
    }
}
