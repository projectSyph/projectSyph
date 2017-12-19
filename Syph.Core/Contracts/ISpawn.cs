using System;
using System.Collections.Generic;
using System.Text;

namespace Syph.Core.Contracts
{
    public interface ISpawn
    {
        int Health { get; }

        int Demage { get; }

        int Armour { get; }

        int Souls { get; }

        int DepleteArmour { set; }

        int DepleteHealth { set; }

        int DepleteSouls { set; }
    }
}
