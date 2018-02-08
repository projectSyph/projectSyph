using System.Collections.Generic;
using Syph_V02.Core.Components.Commands.Contracts;

namespace Syph_V02.Core.Components.Commands
{
    public class StartNewGame : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            return string.Empty;
        }
    }
}
