using Syph_V02.Core.Components.Engine.Contracts;
using System.Collections.Generic;
using HinterLib;
using System;
using Syph_V02.Core.Components.Commands;

namespace Syph_V02.Core.Components.Engine.ConsoleClient
{

    public class ConsoleRenderer : IRenderer
    {
        public IEnumerable<string> Input()
        {
            var input = Hinter.ReadHintedLine(CommandsList.CommandsLibrary, d => d);
            
            while (!string.IsNullOrEmpty(input))
            {
                yield return input;
                input = Hinter.ReadHintedLine(CommandsList.CommandsLibrary, d => d);
            }

        }

        public void Output(IEnumerable<string> output)
        {
            throw new NotImplementedException();
        }
    }
}
