using System.Collections.Generic;
using Syph_V02.Core.Components.Engine.LogSaver.Contracts;
using Syph_V02.Core.Models.Contracts;

namespace Syph_V02.Core.Components.Engine.LogSaver
{
    public class DataStore : IDataStore
    {
        private readonly IDictionary<IPlayer, ISpawn> game;

        public DataStore()
        {
            this.game = new Dictionary<IPlayer, ISpawn>();
        }

        public IDictionary<IPlayer, ISpawn> Game
        {
            get
            {
                return new Dictionary<IPlayer, ISpawn>(this.game);
            }
        }

        public void AddPlayer(IPlayer player)
        {
            System.Console.WriteLine("PLAYER ADDED");
        }

        public void AddSpawn(ISpawn spawn)
        {
            System.Console.WriteLine("SPAWN ADDED");
        }
    }
}
