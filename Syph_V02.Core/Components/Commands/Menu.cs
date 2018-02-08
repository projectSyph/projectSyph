using Syph_V02.Core.Components.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syph_V02.Core.Components.Commands
{
    public class Menu : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            return string.Empty;
        }
    }
}
