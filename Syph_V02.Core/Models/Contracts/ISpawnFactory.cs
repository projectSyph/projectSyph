using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syph_V02.Core.Models.Contracts
{
    public interface ISpawnFactory
    {
        ISpawn CreateJuniorSpawn(string name, int souls);

        ISpawn CreateRegularSpawn(string name, int souls);

        ISpawn CreateSeniorSpawn(string name, int souls);
       
    }
}
