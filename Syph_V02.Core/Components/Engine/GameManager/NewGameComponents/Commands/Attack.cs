using Syph_V02.Core.Components.Commands.Contracts;
using Syph_V02.Core.Components.Engine.GameManager.NewGameComponents.Constants;
using Syph_V02.Core.Components.Engine.GameManager.NewGameComponents.Contracts;
using Syph_V02.Core.Components.Engine.LogSaver.Contracts;
using Syph_V02.Core.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syph_V02.Core.Components.Engine.GameManager.NewGameComponents.Commands
{
    public class Attack : ICommand
    {
        private readonly IDataStore data;
        private readonly IBattleVisualizer visualizer;
        private readonly BattleConstants constants;

        public Attack(IDataStore data, IBattleVisualizer visualizer, BattleConstants constants)
        {
            this.data = data;
            this.visualizer = visualizer;
            this.constants = constants;
        }
     
        public string Execute(IList<string> parameters)
        {
            var players = data.Players.Values;

            var playerOne = players.First();
            var playerTwo = players.Last();

            //TESTING ATTACK
            //THIS IS HARD CODED TO KILL SECOND OPPONENT
            while (playerTwo.IsAlive)
            {
                playerTwo.TakeDamage(2000);

                this.visualizer.FieldOutputer(this.constants.FirstPlayerAttackDisplay);

                Console.WriteLine($"PLAYER {playerTwo.Name} TAKES DAMAGE => IS ALIVE");
                Console.WriteLine($"PLAYER {playerTwo.Name} SOULS {playerTwo.Souls}");

            }
            this.visualizer.FieldOutputer(this.constants.FirstPlayerWinsGamekDisplay);

            return string.Empty;
        }
    }
}
