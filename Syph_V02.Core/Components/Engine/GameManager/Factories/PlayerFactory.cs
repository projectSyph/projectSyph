using Autofac;
using Syph_V02.Core.Components.Engine.GameManager.Contracts;
using Syph_V02.Core.Models;
using Syph_V02.Core.Models.Contracts;
using System.Collections.Generic;

namespace Syph_V02.Core.Components.Engine.GameManager.Factories
{
    public class PlayerFactory:IPlayerFactory
    {
        //private readonly IComponentContext container;

        //public PlayerFactory(IComponentContext container)
        //{
        //    this.container = container;
        //}

        public IPlayer CreateNewPlayer(string name, int id, IList<ISpawn> spawns)
        {
            return new Player(name, id, spawns);
        }
    }
}
