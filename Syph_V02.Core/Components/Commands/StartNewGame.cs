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
            IGameManager newGameManager
            )
        {
            this.data = data;           
            this.playerFactory = playerFactory;
            this.constants = constants;
            this.renderer = renderer;
            this.gameManager = newGameManager;
        }

        public string Execute(IList<string> parameters)
        {
            //var newGame = parameters[0];

            this.renderer.SameLineOutput("Number of players: ");

            var playersCount = int.Parse(this.renderer.LineReader());

            var resultBuilder = new StringBuilder();

            for (int i = 0; i < playersCount; i++)
            {
                renderer.SameLineOutput(string.Format(this.constants.PlayerNamePrompt, i + 1));
               
                var playerName = renderer.LineReader();
                var id = i; // TODO: This option is not use in demo version, IMPLEMENT IN FUTURE!!
                var team = new List<IPlayer>();

                if (this.data.Players.Any(x => x.Key == playerName))
                {
                    var msg = string.Format(this.constants.PlayerFailsToBelAdded, playerName);

                    renderer.Output(msg);
                    resultBuilder.AppendLine(msg);

                    i--;                   
                }
                else
                {
                    var player = this.playerFactory.CreateNewPlayer(playerName, id, team);
                    data.AddPlayer(player);

                    var msg = string.Format(this.constants.PlayerSuccessfullAdded, playerName);

                    renderer.Output(msg);
                    resultBuilder.AppendLine(msg);
                    
                }
                             
            }

            //DEMO VERSION BATTLE INITIALIZER 
            //RETURNS -> DISPLAYS -> DO BATTLE ACTIONS
            //TO MANY THING FOR THIS VARIABLE !!
            var battleResults = gameManager.ExecuteBattle();

            return resultBuilder.AppendLine(battleResults).ToString();
            
        }
    }
}
