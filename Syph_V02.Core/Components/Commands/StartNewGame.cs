using System.Collections.Generic;
using Syph_V02.Core.Components.Commands.Contracts;
using Syph_V02.Core.Components.Engine.LogSaver.Contracts;
using Syph_V02.Core.Components.Engine.GameManager.Contracts;
using Syph_V02.Core.Models.Contracts;

namespace Syph_V02.Core.Components.Commands
{
    public class StartNewGame : ICommand
    {
        private readonly IDataStore data;
       
        private readonly IPlayerFactory playerFactory;

        public StartNewGame(IDataStore data,  IPlayerFactory playerFactory)
        {
            this.data = data;           
            this.playerFactory = playerFactory;
        }

        public string Execute(IList<string> parameters)
        {
            var newGame = parameters[0];

            //Functionality test
            var player = this.playerFactory.CreateNewPlayer("Pesho", 1, new List<ISpawn>());
            data.AddPlayer(player);

            return string.Empty;
        }
    }
}
