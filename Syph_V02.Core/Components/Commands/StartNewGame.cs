using System.Collections.Generic;
using Syph_V02.Core.Components.Commands.Contracts;
using Syph_V02.Core.Components.Engine.LogSaver.Contracts;
using Syph_V02.Core.Components.Engine.GameManager.Contracts;
using Syph_V02.Core.Models.Contracts;
using System;
using Syph_V02.Core.Components.Engine;
using System.Linq;
using Syph_V02.Core.Components.Engine.Contracts;
using System.Text;

namespace Syph_V02.Core.Components.Commands
{
    public class StartNewGame : ICommand
    {
        private readonly IDataStore data;
        private readonly IPlayerFactory playerFactory;
        private readonly Constants constants;
        private readonly IRenderer renderer;
        private readonly IGameManager gameManager;

        public StartNewGame
            (
            IDataStore data,
            IPlayerFactory playerFactory,
            Constants constants,
            IRenderer renderer,
            IGameManager gameManager
            )
        {
            this.data = data;
            this.playerFactory = playerFactory;
            this.constants = constants;
            this.renderer = renderer;
            this.gameManager = gameManager;
        }

        public string Execute(IList<string> parameters)
        {
            int playersCount = 2;
            bool parsed = false;

            while (!parsed)
            {
                this.renderer.SameLineOutput("Number of players: ");
                parsed = int.TryParse(this.renderer.LineReader(), out playersCount);

                if (!parsed || (playersCount < 2 || playersCount > 4))
                {
                    this.renderer.Output("Please, enter a number between 2 and 4!");
                    parsed = false;
                }
            }

            var resultBuilder = new StringBuilder();

            for (int i = 0; i < playersCount; i++)
            {
                renderer.SameLineOutput(string.Format(this.constants.PlayerNamePrompt, i + 1));

                var playerName = renderer.LineReader();

                if (this.data.Players.Any(x => x.Key == playerName))
                {
                    var error = string.Format(this.constants.PlayerFailsToBelAdded, playerName);

                    renderer.Output(error);
                    resultBuilder.AppendLine(error);

                    i--;
                    continue;
                }

                var id = i;
                var team = new List<IPlayer>();

                var player = this.playerFactory.CreateNewPlayer(playerName, id, team);
                data.AddPlayer(player);

                var msg = string.Format(this.constants.PlayerSuccessfullAdded, playerName);

                renderer.Output(msg);
                resultBuilder.AppendLine(msg);
            }

            //DEMO VERSION BATTLE INITIALIZER 
            //RETURNS -> DISPLAYS -> DO BATTLE ACTIONS
            //TO MANY THING FOR THIS VARIABLE !!
            var battleResults = gameManager.ExecuteBattle();

            return resultBuilder.AppendLine(battleResults).ToString();
        }
    }
}
