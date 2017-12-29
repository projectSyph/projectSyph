using System;
using System.Collections.Generic;
using System.Text;

namespace Syph.Core.Contracts
{
    public interface ICommand
    {
        string Name { get; }

        List<string> Parameters { get; }

        string InvalidReason { get; }

        bool IsValid();
    }
}
