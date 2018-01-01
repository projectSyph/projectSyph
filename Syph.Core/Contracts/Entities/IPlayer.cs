using Syph.Core.Contracts.Entities;
using System.Collections.Generic;

namespace Syph.Core.Contracts
{
    public interface IPlayer : IEntity
    {
        IList<ISpawn> Inventory { get; }

        int ID { get; }

        IList<IPlayer> Team { get; }

        void TakeDamage(int d);

        void Summon(ISpawn spawn);
    }
}
