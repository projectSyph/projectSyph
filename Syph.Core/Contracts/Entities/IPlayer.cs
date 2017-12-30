using Syph.Core.Contracts.Entities;
using System.Collections.Generic;

namespace Syph.Core.Contracts
{
    public interface IPlayer : IEntity
    {
        IList<ISpawn> Inventory { get; }

        int Souls { get; }

        int ID { get; }

        IList<IPlayer> Team { get; }
    }
}
