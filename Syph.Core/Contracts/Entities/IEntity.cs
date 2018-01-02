using Syph.Core.Common;

namespace Syph.Core.Contracts.Entities
{
    public interface IEntity
    {
        string Name { get; }

        int Souls { get; }
        
        EntityType Type { get; }
    }
}
