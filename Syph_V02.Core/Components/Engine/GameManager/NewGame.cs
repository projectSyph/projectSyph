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

namespace Syph_V02.Core.Components.Engine.GameManager
{
    public class NewGame : IGameManager
    {
        private  readonly IBattleField battleField;
        private readonly IBattleCalculator battleCalculator;
        private readonly IInputLineExecuter inputExecutor;
        private readonly IRenderer renderer;
        private readonly BattleConstants constants;

        public NewGame
            (
                IBattleField battleField,
                IBattleCalculator battleCalculator, 
                IInputLineExecuter inputExecutor,
                IRenderer renderer,
                BattleConstants constants
            )
        {
            this.battleField = battleField;
            this.battleCalculator = battleCalculator;
            this.inputExecutor = inputExecutor;
            this.renderer = renderer;
            this.constants = constants;
        }


        public string ExecuteBattle(IDataStore data)
        {
            //DEMO VERSION WORKS WITH TWO PLAYERS
            //IN THE FUTURE THIS PART IS GOING TO BE DIFFERENT

            inputExecutor.InputExecuter(this.constants.BattleMenuCommand);

            var players = data.Players.Values;

            var playerOne = players.First();
            var playerTwo = players.Last();

            while (playerOne.IsAlive && playerTwo.IsAlive)
            {
                playerOne.TakeDamage(2000);

                Console.WriteLine($"PLAYER {playerOne.Name} TAKES DAMAGE IS ALIVE");
                Console.WriteLine(playerOne.Souls);
               
            }                               
                

  
                // 2.2. Attack commands display - Using BattleFiel class and ConsoleVisualizer

                //3. Make attack - using taken command ADD NEW COMMAND 

                //4. Display attack - - Using BattleFiel class and ConsoleVisualizer

                //5. Calculate Attack - using taken command  ADD NEW COMMAND 

                //6. Display results - from return of point 3 and 5 - Using BattleFiel class and ConsoleVisualizer

                //7. next player turn - loop till player isAlive
            

            Console.WriteLine("PLAYER IS DEATH");
            return "BATTLE BEGINS";
        }
    }
}
