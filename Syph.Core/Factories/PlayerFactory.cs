using Syph.Core.Contracts;
using Syph.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Syph.Core.Factories
{
    public class PlayerFactory
    {
        public static IPlayer CreateNewPlayer(string name, int id)
        {
            return new Player(name, id, new List<IPlayer>());
        }
    }
}
