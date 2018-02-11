using Syph_V02.Core.Components.Engine.Contracts;
using Syph_V02.Core.Components.Engine.GameManager.NewGameComponents.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syph_V02.Core.Components.Engine.GameManager.NewGameComponents
{
    public class BattleVisualizer : IBattleVisualizer
    {
        private readonly IVisualizer battleVisualizer;
        private readonly IRenderer renderer;

        public BattleVisualizer(IVisualizer battleVisualizer, IRenderer renderer)
        {
            this.battleVisualizer = battleVisualizer;
            this.renderer = renderer;
        }

        public void FieldOutputer(string data)
        {
            //NOTE : ReadTextFile(data, false = DONT DELETE CONSOLE )
            var output = this.battleVisualizer.ReadTextFile(data,false);

            renderer.Output(output);
        }
    }
}
