using Syph_V02.Core.Models.Contracts;

using System.Collections.Generic;

namespace Syph_V02.Core.Components.Engine.Contracts
{
    public interface IPlayerFactory
    {
        IPlayer CreateNewPlayer(string name, int id, IList<IPlayer> team);
    }
}
