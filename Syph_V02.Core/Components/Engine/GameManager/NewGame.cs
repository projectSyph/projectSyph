using Syph_V02.Core.Components.Engine.GameManager.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syph_V02.Core.Components.Engine.LogSaver.Contracts;
using Syph_V02.Core.Components.Engine.GameManager.NewGameComponents.Contracts;

namespace Syph_V02.Core.Components.Engine.GameManager
{
    public class NewGame : IGameManager
    {
        private  readonly IBattleField battleField;
        private readonly IBattleCalculator battleCalculator;

        public NewGame(IBattleField battleField, IBattleCalculator battleCalculator)
        {
            this.battleField = battleField;
            this.battleCalculator = battleCalculator;
        }


        public string Battle(IDataStore data)
        {
            return "BATTLE BEGINS";
        }
    }
}
