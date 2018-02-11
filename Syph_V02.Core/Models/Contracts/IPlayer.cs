using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syph_V02.Core.Models.Contracts
{
    public interface IPlayer
    {
        string Name { get; }

        int ID { get; }

        int Souls { get; }

        bool IsAlive { get; }

        IList<ISpawn> Inventory { get; }
        
        IList<IPlayer> Team { get; }

        void TakeDamage(int d);

        void Die();

        void Surrender();

        void Summon(ISpawn spawn);

        void ListInventory();
    }
}
