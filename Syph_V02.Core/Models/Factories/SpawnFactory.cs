using Syph_V02.Core.Models.Contracts;
using Syph_V02.Core.Models.Spawns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syph_V02.Core.Models.Factories
{
    public class SpawnFactory: ISpawnFactory
    {
        public  ISpawn CreateJuniorSpawn(string name, int souls)
        {
            return new JuniorSpawn(name, souls);
        }

        public  ISpawn CreateRegularSpawn(string name, int souls)
        {
            return new RegularSpawn(name, souls);
        }

        public  ISpawn CreateSeniorSpawn(string name, int souls)
        {
            return new SeniorSpawn(name, souls);
        }
    }
}
