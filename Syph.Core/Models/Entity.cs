using Syph.Core.Common;
using Syph.Core.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Syph.Core.Models
{
    public abstract class Entity : IEntity
    {
        private string name;
        private EntityType type;

        public Entity(string name, EntityType type)
        {
            if (name.Length < 2 || name.Length > 25)
                { throw new ArgumentException("Entity name can't be less than 2 or more than 25 symbols long!"); }

            this.name = name;
            this.type = type;
        }

        public string Name => this.name;

        public EntityType Type => this.type;
    }
}
