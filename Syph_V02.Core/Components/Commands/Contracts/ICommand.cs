using System.Collections.Generic;

namespace Syph_V02.Core.Components.Commands.Contracts
{
   public  interface ICommand
    {
        string Execute(IList<string> parameters);
    }
}
