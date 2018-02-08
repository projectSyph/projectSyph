using System.Collections.Generic;
using Syph_V02.Core.Components.Commands.Contracts;
using Syph_V02.Core.Components.Engine.LogSaver.Contracts;
using Syph_V02.Core.Components.Engine.GameManager.Contracts;
using Syph_V02.Core.Models.Contracts;
using System;
using Syph_V02.Core.Components.Engine;
using System.Linq;

namespace Syph_V02.Core.Components.Commands
{
    public class StartNewGame : ICommand
    {
        private readonly IDataStore data;      
        private readonly IPlayerFactory playerFactory;
        private readonly Constants constants;

        public StartNewGame(IDataStore data,  IPlayerFactory playerFactory, Constants constants)
        {
            this.data = data;           
            this.playerFactory = playerFactory;
            this.constants = constants;
        }

        public string Execute(IList<string> parameters)
        {
            var newGame = parameters[0];

            //TODO: Inport parameters and use them
            Console.Write("Player Name: ");
            var playerName = Console.ReadLine();
            var id = 1;
            var spawns = new List<ISpawn>();

            if (this.data.Game.Any(x => x.Key.Name == playerName))
            {
                return string.Format(this.constants.PlayerFailsToBelAdded, playerName);
            }

            var player = this.playerFactory.CreateNewPlayer(playerName, id, spawns);
            data.AddPlayer(player);

            return string.Format(this.constants.PlayerSuccessfullAdded, playerName);
        }
    }
}
