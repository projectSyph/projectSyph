using Syph_V02.Core.Components.Engine.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syph_V02.Core.Models.Contracts;
using Syph_V02.Core.Models;

namespace Syph_V02.Core.Components.Engine.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreateNewPlayer(string name, int id, IList<IPlayer> team)
        {
            return new Player(name, id, team);
        }
    }
}
