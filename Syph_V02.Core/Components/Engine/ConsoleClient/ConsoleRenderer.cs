using Syph_V02.Core.Components.Engine.Contracts;
using System.Collections.Generic;
using System.Text;
using System;
using HinterLib;
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
                if (CommandsList.CommandsLibrary.Contains(input))
                {
                    yield return input;                 
                }
                else
                {
                    Output("BAD INPUT");
                } 

                input = Hinter.ReadHintedLine(CommandsList.CommandsLibrary, d => d);
            }

        }

        public void Output(string output)
        {

            Console.WriteLine(output);
        }
    }
}
