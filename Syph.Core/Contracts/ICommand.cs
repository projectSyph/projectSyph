using System;
using System.Collections.Generic;
using System.Text;

namespace Syph.Core.Contracts
{
    interface ICommand
    {
         string NameOfMove { get; }
        List<string> Parameters { get; }
    }
}
