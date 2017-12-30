using Syph.Core.Common;
using Syph.Core.Contracts.Entities;
using Syph.Core.Engine.Exceptions;

namespace Syph.Core.Models
{
    public abstract class Entity : IEntity
    {
        private string name;
        private EntityType type;
        public static readonly string invalidEntityName = "Entity name can't be less than 2 or more than 25 symbols long!";

        public Entity(string name, EntityType type)
        {
            if (!IsValidName(name))
            {
                throw new InvalidEntityNameException(invalidEntityName);
            }

            this.name = name;
            this.type = type;
        }

        public string Name => this.name;

        public EntityType Type => this.type;

        public static bool IsValidName(string name)
        {
            if (name.Length < 2 || name.Length > 25) return false;
            return true;
        }
    }
}
