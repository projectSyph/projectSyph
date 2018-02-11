using System.Collections.Generic;
using Syph_V02.Core.Components.Engine.LogSaver.Contracts;
using Syph_V02.Core.Models.Contracts;

namespace Syph_V02.Core.Components.Engine.LogSaver
{
    public class DataStore : IDataStore
    {
        private readonly IDictionary<IPlayer, ISpawn> game;
        private readonly IDictionary<string,IPlayer> players;

        public DataStore()
        {
            this.game = new Dictionary<IPlayer, ISpawn>();
            this.players = new Dictionary<string, IPlayer>();
        }

        public IDictionary<IPlayer, ISpawn> Game
        {
            get
            {
                return new Dictionary<IPlayer, ISpawn>(this.game);
            }
        }

        public IDictionary<string,IPlayer> Players
        {
            get
            {
                return new Dictionary<string,IPlayer>(this.players);
            }
        }

        public void AddPlayer(IPlayer player)
        {
            this.players.Add(player.Name, player);
        }

        public void AddSpawn(ISpawn spawn)
        {
            System.Console.WriteLine("SPAWN ADDED");
        }
    }
}
