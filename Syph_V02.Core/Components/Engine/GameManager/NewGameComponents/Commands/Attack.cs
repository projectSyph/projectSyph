using Syph_V02.Core.Components.Commands.Contracts;
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

        public Attack(IDataStore data)
        {
            this.data = data;
        }
     
        public string Execute(IList<string> parameters)
        {
            var players = data.Players.Values;

            var playerOne = players.First();
            var playerTwo = players.Last();

            while (playerOne.IsAlive && playerTwo.IsAlive)
            {
                playerOne.TakeDamage(2000);

                Console.WriteLine($"PLAYER {playerOne.Name} TAKES DAMAGE => IS ALIVE");
                Console.WriteLine(playerOne.Souls);

            }

            return string.Empty;
        }
    }
}
