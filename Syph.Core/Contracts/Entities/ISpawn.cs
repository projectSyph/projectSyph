using Syph.Core.Common;
using Syph.Core.Contracts.Entities;

namespace Syph.Core.Contracts
{
    public interface ISpawn : IEntity
    {
        double Health { get; }

        double Damage { get; }

        double Armour { get; }

        int Energy { get; }

        SpawnRank Rank { get; }
    }
}
