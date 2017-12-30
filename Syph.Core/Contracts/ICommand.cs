using System;
using System.Collections.Generic;
using System.Text;

namespace Syph.Core.Contracts
{
    public interface ICommand
    {
        string Name { get; }

        List<string> Parameters { get; }

        /// <summary>
        /// returns an explanation of why the command is invalid. Null when the command is valid 
        /// </summary>
        string InvalidReason { get; }

        bool IsValid(IList<IPlayer> alivePlayers, IPlayer player);
    }
}
