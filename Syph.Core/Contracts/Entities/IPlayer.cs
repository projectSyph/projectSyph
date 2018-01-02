using Syph.Core.Contracts.Entities;
using System.Collections.Generic;

namespace Syph.Core.Contracts
{
    public interface IPlayer : IEntity
    {
        IList<ISpawn> Inventory { get; }

        int ID { get; }

        bool IsAlive { get; }

        IList<IPlayer> Team { get; }

        void TakeDamage(int d);

        void Die();

        void Surrender();

        void Summon(ISpawn spawn);

        void ListInventory();
    }
}
