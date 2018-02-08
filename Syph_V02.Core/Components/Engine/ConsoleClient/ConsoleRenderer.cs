using Syph_V02.Core.Components.Engine.Contracts;
using System.Collections.Generic;
using HinterLib;
using Syph_V02.Core.Components.Commands;
using System.Text;
using System;

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

        public void Output(string output)
        {

            Console.WriteLine(output);
        }
    }
}
