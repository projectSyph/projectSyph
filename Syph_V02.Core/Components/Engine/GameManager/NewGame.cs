using Syph_V02.Core.Components.Engine.GameManager.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syph_V02.Core.Components.Engine.LogSaver.Contracts;
using Syph_V02.Core.Components.Engine.GameManager.NewGameComponents.Contracts;
using Syph_V02.Core.Components.Engine.Contracts;
using Syph_V02.Core.Components.Engine.GameManager.NewGameComponents.Constants;
using Syph_V02.Core.Components.Engine.GameManager.NewGameComponents.Commands;

namespace Syph_V02.Core.Components.Engine.GameManager
{
    public class NewGame : IGameManager
    {
        private readonly IBattleField battleField;
        private readonly IBattleCalculator battleCalculator;
        private readonly IExecute inputExecutor;
        private readonly IRenderer renderer;
        private readonly BattleConstants constants;

        private readonly IDataStore data;

        public NewGame
            (
                IBattleField battleField,
                IBattleCalculator battleCalculator,
                IExecute inputExecutor,
                IRenderer renderer,
                IDataStore data,
                BattleConstants constants
            )
        {
            this.battleField = battleField;
            this.battleCalculator = battleCalculator;
            this.inputExecutor = inputExecutor;
            this.renderer = renderer;
            this.data = data;
            this.constants = constants;
        }

        public string ExecuteBattle()
        {
            //TODO: ADD WHILE LOOP
            //IN THE FUTURE THIS PART IS GOING TO BE DIFFERENT

            inputExecutor.Execute(this.constants.BattleMenuCommand);

            Console.WriteLine("PLAYER IS DEAD");
            return "BATTLE BEGINS";
        }
    }
}
