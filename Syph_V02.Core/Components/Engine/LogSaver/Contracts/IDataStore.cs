using Syph_V02.Core.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syph_V02.Core.Components.Engine.LogSaver.Contracts
{
    public interface IDataStore
    {
        IDictionary<IPlayer, ISpawn> Game { get; }

        IDictionary<string, IPlayer> Players { get; }

        //IDictionary<ITeam, ISpawn> Enemy { get; }

        void AddPlayer(IPlayer player);

        void AddSpawn(ISpawn spawn);

        // void AddEnemy(ISpawn enemy);
    }
}
