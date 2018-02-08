using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syph_V02.Core.Models.Contracts
{
    public interface IPlayer
    {
        IList<ISpawn> Inventory { get; }

        int ID { get; }

        bool IsAlive { get; }

        IList<ISpawn> Team { get; }

        void TakeDamage(int d);

        void Die();

        void Surrender();

        void Summon(ISpawn spawn);

        void ListInventory();
    }
}
