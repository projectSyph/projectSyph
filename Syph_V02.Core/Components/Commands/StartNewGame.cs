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
        private readonly IGameManager newGameManager;

        public StartNewGame(IDataStore data,
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
            this.newGameManager = newGameManager;
            ;
        }

        public string Execute(IList<string> parameters)
        {
            var newGame = parameters[0];

            var playersCount = int.Parse(parameters[1]);

            var resultBuilder = new StringBuilder();

            for (int i = 1; i <= playersCount; i++)
            {
                renderer.SameLineOutput(string.Format(this.constants.PlayerNamePrompt, i));
               
                var playerName = renderer.LineReader();
                var id = 1; // TODO: This option is not use in demo version, IMPLEMENT IN FUTURE!!
                var spawns = new List<ISpawn>();

                if (this.data.Players.Any(x => x.Key == playerName))
                {
                    var msg = string.Format(this.constants.PlayerFailsToBelAdded, playerName);

                    renderer.Output(msg);
                    resultBuilder.AppendLine(msg);

                    i--;                   
                }
                else
                {
                    var player = this.playerFactory.CreateNewPlayer(playerName, id, spawns);
                    data.AddPlayer(player);

                    var msg = string.Format(this.constants.PlayerSuccessfullAdded, playerName);

                    renderer.Output(msg);
                    resultBuilder.AppendLine(msg);
                    
                }
                             
            }

            //DEMO VERSION BATTLE INITIALIZER 
            //RETURNS -> DISPLAYS -> DO BATTLE ACTIONS
            //TO MANY THING FOR THIS VARIABLE !!
            var battleResults = newGameManager.ExecuteBattle();

            return resultBuilder.AppendLine(battleResults).ToString();
            
        }
    }
}
