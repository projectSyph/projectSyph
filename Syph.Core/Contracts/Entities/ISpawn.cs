using Syph.Core.Contracts.Entities;

namespace Syph.Core.Contracts
{
    public interface ISpawn : IEntity
    {
        int Health { get; }

        int Demage { get; }

        int Armour { get; }

        int Souls { get; }
    }
}
