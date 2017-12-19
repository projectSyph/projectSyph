using System;
using System.Collections.Generic;
using System.Text;

namespace Syph.Core.Contracts
{
    public interface IInventory
    {
        ISpawn[][] PlayerInventory { get; }
    }
}
