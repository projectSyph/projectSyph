using Syph_V02.Core.Components.Engine.GameManager.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syph_V02.Core.Components.Engine.LogSaver.Contracts;
using Syph_V02.Core.Components.Engine.GameManager.NewGameComponents.Contracts;
using Syph_V02.Core.Components.Engine.Contracts;

namespace Syph_V02.Core.Components.Engine.GameManager
{
    public class NewGame : IGameManager
    {
        private  readonly IBattleField battleField;
        private readonly IBattleCalculator battleCalculator;
        private readonly IInputLineExecuter inputExecutor;
        private readonly IRenderer renderer;

        public NewGame
            (
                IBattleField battleField,
                IBattleCalculator battleCalculator, 
                IInputLineExecuter inputExecutor,
                IRenderer renderer
            )
        {
            this.battleField = battleField;
            this.battleCalculator = battleCalculator;
            this.inputExecutor = inputExecutor;
            this.renderer = renderer;
        }


        public string ExecuteBattle(IDataStore data)
        {
            //TEST SCENARIO
            var players = data.Players.Values;

            var playerOne = players.First();
            var playerTwo = players.Last();

            while (playerOne.IsAlive && playerTwo.IsAlive)
            {
                playerOne.TakeDamage(2000);

                Console.WriteLine($"PLAYER {playerOne.Name} TAKES DAMAGE IS ALIVE");
                Console.WriteLine(playerOne.Souls);
               
            }                               
                //1. Battle start message display - Using BattleFiel class and ConsoleVisualizer

                // 1.2. Battle keys and rlz - Using BattleFiel class and ConsoleVisualizer

                // 2. Player ? turn - based on the while loop we are in

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
