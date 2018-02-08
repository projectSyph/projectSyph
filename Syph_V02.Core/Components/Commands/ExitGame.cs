using Syph_V02.Core.Components.Commands.Contracts;
using System;
using System.Collections.Generic;

namespace Syph_V02.Core.Components.Commands
{
    public class ExitGame : ICommand
    {
        public string Execute(IList<string> parameters)
        {          
            return "EXITS FROM GAME ..... ..";
        }
    }
}
